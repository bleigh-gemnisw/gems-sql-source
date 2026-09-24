Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myUTCUSTQ As UTCUSTQ.myData
Dim myUTCUSTRT As UTCUSTRT.myData
Dim myUTCUSTAS As UTCUSTAS.myData
Dim myUTCOEA As UTCOEA.myData
Dim myTXINV As TXINV.myData
Dim ds1 As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkType As String
Dim WrkYear As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkPhase As Integer
Dim WrkPost As Boolean
Dim WrkListNo As Integer
Dim WrkUBType As String
Dim WrkBillDesc As String
Dim WrkFamily As String
Dim WrkCode As String
Dim WrkOverAmt As Decimal
Dim WrkAdjAmt As Decimal
Dim WrkAdjAmt1 As Decimal
Dim WrkAdjAmt2 As Decimal
Dim WrkAdjNo As Integer
'Assessment Work Fields
Dim WrkAssmntLeft As Decimal
Dim WrkBillAmt As Decimal

Public Sub PrtReport()
  Dim WrkTypeDesc As String

  myUTCUSTQ = New UTCUSTQ.mydata(MyDBConnect)
  myUTCUSTRT = New UTCUSTRT.mydata(MyDBConnect)
  myUTCUSTAS = New UTCUSTAS.mydata(MyDBConnect)
  myUTCOEA = New UTCOEA.mydata(MyDBConnect)
  myTXINV = New TXINV.mydata(MyDBConnect)

  With MyFrmUB401B
    WrkType = .TxtType.Text
    WrkYear = MyUtils.CnvSng(.TxtGLYear.Text)
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    WrkPhase = MyUtils.CnvSng(.TxtPhase.Text)
    WrkDistAll = False
    If .TxtDist.Text = "" Then
     WrkDistAll = True
    End If
    WrkPost = .ChkPost.Checked
  End With

  If ds1.Tables.Count = 0 Then
    BuildDS()
  Else
    ds1.Clear()
  End If

  GetDetail()

Done:
	WrkTypeDesc = GetUTTypeDescL2(WrkType)

  MyCrViewer = New FrmCrViewer
  MyCrViewer.Wrkds1 = ds1
  MyCrViewer.WrkTypeDesc = WrkTypeDesc
  MyCrViewer.Show()

End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Unbilled", Type.GetType("System.Double"))
      .Columns.Add("Overpaid", Type.GetType("System.Double"))
      .Columns.Add("BillAmt", Type.GetType("System.Double"))
      .Columns.Add("AdjAmt", Type.GetType("System.Double"))
      .Columns.Add("AdjNo", Type.GetType("System.Int32"))
    End With
    ds1.Tables.Add(myTable)

  End Sub
Private Sub GetDetail()

Dim WrkSort As String
Dim WrkQry As String
Dim I As Integer
Dim WrkAnd As String
Dim Counter As Integer

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

Counter = 0
WrkQry = ""
If Not WrkDistAll Then
  WrkQry = "cudst=" & WrkDist
End If
If WrkPhase > 0 Then
  If WrkQry = String.Empty Then
    WrkQry = "cuphas = " & WrkPhase
  Else
    WrkQry = WrkQry & WrkAnd & "cuphas = " & WrkPhase
  End If
End If
WrkSort = "CUNAM1, CUACCT"
WrkUBType = GetUTTypeUBType(WrkType)
WrkAdjNo = myUTCOEA.AutoGenKey

myUTCUSTQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
 myUTCUSTQ.ReadQry()
 If Not myUTCUSTQ.IsEOF Then
 With myUTCUSTQ
  Counter = Counter + 1
  WrkListNo = ._CUACCT
  WrkCode = GetRateCode(WrkType)
  If WrkCode = "" Then GoTo NextRec

  CalcAssmnt(I)
  If WrkAssmntLeft = 0 Then GoTo NextRec
  WrkOverAmt = 0
  WrkAdjAmt = 0
  WrkAdjAmt1 = 0
  WrkAdjAmt2 = 0

  dr = ds1.Tables(0).NewRow
  dr.Item("listno") = WrkListNo
  dr.Item("name") = Trim(._CUNAM1)
  dr.Item("unbilled") = WrkAssmntLeft
  myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
  If myTXINV.RecordNotFound Then GoTo NextRec

  With myTXINV
   dr.Item("billamt") = ._TAXT
   'Filter Paid off
   If MyFrmUB401B.RbPaidOff.Checked Then
    If WrkAssmntLeft + ._BALD > 0 Then
     GoTo NextRec
    End If
   End If
   'Filter All Overpaid
   If MyFrmUB401B.RbAll.Checked Then
    If ._BALD >= 0 Then
     GoTo NextRec
    End If
   End If
   WrkDist = ._DIST
   WrkOverAmt = Math.Abs(._BALD)
   dr.Item("overpaid") = WrkOverAmt
   If WrkOverAmt > WrkAssmntLeft Then
    WrkOverAmt = WrkAssmntLeft
   End If
   If ._CCNO > 0 Then
    WrkAdjAmt = WrkOverAmt + ._CCETAX
    If ._CCTX2 = 0 Then
     WrkAdjAmt1 = WrkOverAmt + ._CCTX1
     WrkAdjAmt2 = 0
    Else
     WrkAdjAmt1 = ._CCTX1
     WrkAdjAmt2 = WrkOverAmt + ._CCTX2
    End If
    WrkBillAmt = ._CCETAX
   Else
    WrkAdjAmt = WrkOverAmt + ._TAXT
    If ._TAX2 = 0 Then
     WrkAdjAmt1 = WrkOverAmt + ._TAX1
     WrkAdjAmt2 = 0
    Else
     WrkAdjAmt1 = ._TAX1
     WrkAdjAmt2 = WrkOverAmt + ._TAX2
    End If
    WrkBillAmt = ._TAXT
   End If
   'Filter out if no adjustment
   If WrkAdjAmt = 0 Then GoTo NextRec
  End With

  dr.Item("adjamt") = WrkAdjAmt
  dr.Item("adjno") = WrkAdjNo
 End With
 If WrkPost Then
  WriteFiles(I)
  UpdateCUSTAS()
 End If
 ds1.Tables(0).Rows.Add(dr)
 WrkAdjNo = WrkAdjNo + 1

NextRec:
  With myFrmProgress
   WrkPct = (Counter / 10) Mod 100
   If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .LblMsg.Text = "Records processed: " & Counter
    .Refresh()
    SavePct = WrkPct
    Application.DoEvents()
   End If
  End With
  GoTo ReadNext
 End If

myFrmProgress.Close()

CloseFiles:
myUTCUSTQ.CloseFile()

End Sub
  Private Sub CalcAssmnt(ByVal I As Integer)
    Dim MyUBCalcBill As UBCalcBill.BillAssessment

    MyUBCalcBill = New UBCalcBill.BillAssessment(myDBConnect)

    WrkAssmntLeft = 0

    myUTCUSTAS.GetOneRecordP(WrkListNo, WrkType)
    If myUTCUSTAS.RecordNotFound Then Exit Sub

    With MyUBCalcBill
      .In_RateType = WrkType
      .In_RateCode = WrkCode
			.In_DwellUnits = myUTCUSTQ._CUAUNT
			.In_PropVal = myUTCUSTQ._CUPVAL
			.In_Footage = myUTCUSTQ._CUFOOT
			.In_Acreage = myUTCUSTQ._CUACRE
      .In_LateralFee = myUTCUSTAS._CALAT
      .In_UniformFee = myUTCUSTAS._CAUNIF
      .In_AssmntAdjust = myUTCUSTAS._CAADJ
      .In_DeferredAmt = myUTCUSTAS._CADEF
      .In_PrevBilled = myUTCUSTAS._CAAMT
      .CalcAssessment()
      WrkAssmntLeft = MyUtils.FmtCurrency(.Out_AmtLeft)
    End With

  End Sub
Private Sub WriteFiles(ByVal I As Integer)

  Dim WrkBond As Decimal

  With myTXINV
    ._BALD = ._BALD + WrkOverAmt
    ._CCNO = WrkAdjNo
    ._CDATE = MyUtils.SetDBDate(DateTime.Today)
    ._CCETAX = WrkAdjAmt
    ._CCTX1 = WrkAdjAmt1
    ._CCTX2 = WrkAdjAmt2
    ._CCTX3 = 0
    ._CCTX4 = 0
    ._CCRSN = "O"
    WrkBond = ._BOND
		.UpdateOneRecordP()
      If .ErrMsg <> "" Then
        WriteErrorLog(.ErrMsg)
        Exit Sub
      End If
    End With

    myUTCOEA.GetOneRecordP(WrkAdjNo)
    With myUTCOEA
      ._CCNO = WrkAdjNo
      ._LISTNO = WrkListNo
      ._YEAR = WrkYear
      ._TYPE = WrkType
      ._DIST = WrkDist
      ._NAME = Trim(myUTCUSTQ._CUNAM1)
      ._CETAX1 = WrkAdjAmt1
      ._CETAX2 = WrkAdjAmt2
      ._CETAX3 = 0
      ._CETAX4 = 0
      ._CETAX = WrkAdjAmt
      ._COBOND = WrkBond
      ._CNBOND = WrkBond
      ._CDATE = MyUtils.SetDBDate(DateTime.Today)
      ._RSNCD = "O"
      ._CDESC = "* AUTO GENERATED *"
      ._PRF = Mid(MyUserID, 1, 10)
      ._CHDATE = MyUtils.SetDBDate(DateTime.Today)
      ._CHTIME = Format(DateTime.Now, "hhmmss")
      .AddOneRecordP()
      If .ErrMsg <> "" Then
        WriteErrorLog(.ErrMsg)
        Exit Sub
      End If
    End With

  End Sub
  Private Sub UpdateCUSTAS()
    myUTCUSTAS.GetOneRecordP(WrkListNo, WrkType)
    If myUTCUSTAS.RecordNotFound Then Exit Sub

    With myUTCUSTAS
      ._CAAMT = ._CAAMT + WrkOverAmt
      .UpdateOneRecordP()
      If .ErrMsg <> "" Then
        WriteErrorLog(.ErrMsg)
        Exit Sub
      End If
    End With
  End Sub
  Private Function GetRateCode(ByVal WrkType As String) As String
  GetRateCode = ""
  myUTCUSTRT.GetOneRecordP(WrkListNo, WrkType)
  If myUTCUSTRT.RecordNotFound Then Exit Function

  With myUTCUSTRT
    GetRateCode = ._CRCODE
  End With
End Function

End Module






