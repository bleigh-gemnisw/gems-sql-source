Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myUTCUSTQ As UTCUSTQ.myData
Dim myUTCUSTAS As UTCUSTAS.myData
Dim myUTCUSTRT As UTCUSTRT.myData

Dim ds As DataSet = New DataSet
Dim DsUTCUST As DataSet = New DataSet
Dim dr As DataRow

'Screen fields
Dim WrkYear As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkPhase As Integer
Dim WrkSortBy As String
'Common Work fields
Dim WrkListNo As Integer
Dim WrkTaxType As String
Dim WrkUBType As String
Dim WrkBillDesc As String
Dim WrkCode As String
Dim WrkFamily As String
'Assessment Work Fields
Dim WrkOrigAssmnt As Decimal
Dim WrkAssmntLeft As Decimal
Dim WrkDeferred As Decimal
  Public Sub PrtReport()
	myUTCUSTQ = New UTCUSTQ.mydata(MyDBConnect)
  myUTCUSTAS = New UTCUSTAS.mydata(MyDBConnect)
  myUTCUSTRT = New UTCUSTRT.mydata(MyDBConnect)

  With MyFrmUB210B
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    WrkPhase = MyUtils.CnvSng(.TxtPhase.Text)
    WrkUBType = .TxtUBType.Text
    If .TxtDist.Text = "" Then
      WrkDistAll = True
    End If
    If .RbSortList.Checked Then
      WrkSortBy = "List"
    End If
    If .RbSortName.Checked Then
      WrkSortBy = "Name"
    End If
    If .RbSortLocation.Checked Then
      WrkSortBy = "Location"
    End If
  End With

  If ds.Tables.Count = 0 Then
		BuildDS()
	Else
		ds.Clear()
	End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  With MyCrViewer
    .wrkds = ds
    .WrkUBType = WrkUBType
    .Show()
  End With

	End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("BillType", Type.GetType("System.String"))
      .Columns.Add("Name", Type.GetType("System.String"))
			.Columns.Add("Location", Type.GetType("System.String"))
			.Columns.Add("Original", Type.GetType("System.Decimal"))
      .Columns.Add("Unbilled", Type.GetType("System.Decimal"))
      .Columns.Add("Deferred", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
Private Sub GetDetail()
Dim WrkPhaseA As String
Dim WrkQry As String
Dim WrkSort As String
Dim I As Integer
Dim WrkAnd As String

WrkBillDesc = GetUTTypeDesc(WrkUBType)
WrkTaxType = GetUTTYPETaxType(WrkUBType)
WrkFamily = GetUTTYPEFamily(WrkUBType)

If MyServer = "DB2" Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

WrkQry = ""
If Not WrkDistAll Then
  WrkQry = "cudst=" & WrkDist
End If

WrkSort = ""
Select Case WrkSortBy
Case "List"
  WrkSort = "CUACCT"
Case "Name"
  WrkSort = "CUNAM1"
Case "Location"
  WrkSort = "CULOC, CULOC#"
End Select

If WrkPhase = 0 Then
  WrkPhaseA = ""
Else
  WrkPhaseA = WrkPhase
End If

DsUTCUST = myUTCUSTQ.GetQry(WrkSort, WrkQry, 0)
If DsUTCUST.Tables(0).Rows.Count = 0 Then Exit Sub
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()

For I = 0 To (DsUTCUST.Tables(0).Rows.Count - 1)
  With DsUTCUST.Tables(0).Rows(I)
    WrkListNo = .Item("cuacct")
    WrkCode = GetRateCode(WrkUBType)
    If WrkCode = "" Then GoTo NextRec

    Select Case WrkFamily
    Case "A"
      CalcAssmnt(I)
    End Select

  End With

  If WrkDeferred = 0 Then GoTo NextRec

Report:
 'Billing Report
  dr = ds.Tables(0).NewRow
  dr.Item("listno") = WrkListNo
  dr.Item("BillType") = WrkBillDesc
  With DsUTCUST.Tables(0).Rows(I)
    dr.Item("name") = .Item("cunam1")
		dr.Item("location") = .Item("culoc#") & " " & .Item("culoc")
	End With
  dr.Item("original") = WrkOrigAssmnt
  dr.Item("unbilled") = WrkAssmntLeft
  dr.Item("deferred") = WrkDeferred
  ds.Tables(0).Rows.Add(dr)

NextRec:
With myFrmProgress
  WrkPct = ((I + 1) / DsUTCUST.Tables(0).Rows.Count) * 100
  If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .Refresh()
    SavePct = WrkPct
  End If
End With
Next

myFrmProgress.Close()
myUTCUSTQ.CloseFile()

End Sub
  Private Sub CalcAssmnt(ByVal I As Integer)
    Dim MyUBCalcBill As UBCalcBill.BillAssessment

    MyUBCalcBill = New UBCalcBill.BillAssessment(myDBConnect)

    WrkOrigAssmnt = 0
    WrkAssmntLeft = 0
    WrkDeferred = 0

    myUTCUSTAS.GetOneRecordP(WrkListNo, WrkUBType)
    If myUTCUSTAS.RecordNotFound Then Exit Sub

    With MyUBCalcBill
      .In_RateType = WrkUBType
      .In_RateCode = WrkCode
      .In_DwellUnits = DsUTCUST.Tables(0).Rows(I).Item("cuaunt")
      .In_PropVal = DsUTCUST.Tables(0).Rows(I).Item("cupval")
      .In_Footage = DsUTCUST.Tables(0).Rows(I).Item("cufoot")
      .In_Acreage = DsUTCUST.Tables(0).Rows(I).Item("cuacre")
      .In_LateralFee = myUTCUSTAS._CALAT
      .In_UniformFee = myUTCUSTAS._CAUNIF
      .In_AssmntAdjust = myUTCUSTAS._CAADJ
      .In_DeferredAmt = myUTCUSTAS._CADEF
      .In_PrevBilled = myUTCUSTAS._CAAMT
      .CalcAssessment()
      WrkOrigAssmnt = MyUtils.Round(.Out_OrigBill, 2)
      WrkAssmntLeft = MyUtils.Round(.Out_AmtLeft, 2)
      WrkDeferred = myUTCUSTAS._CADEF
    End With

  End Sub
Private Function GetRateCode(ByVal WrkUBType As String) As String

  GetRateCode = ""
  myUTCUSTRT.GetOneRecordP(WrkListNo, WrkUBType)
  If myUTCUSTRT.RecordNotFound Then Exit Function

  With myUTCUSTRT
    GetRateCode = ._CRCODE
  End With
End Function
End Module






