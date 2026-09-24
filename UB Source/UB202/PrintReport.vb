Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myUTCUSTQ As UTCUSTQ.myData
Dim myUTCUSTRT As UTCUSTRT.myData

Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow

'Screen fields
Dim WrkDist As Integer
Dim WrkPhase As Integer
Dim WrkDistto As Integer
Dim WrkPhaseto As Integer
Dim WrkSortBy As String
Dim WrkAddress As Boolean

'Common Work fields
Dim wrkadist As Integer
Dim wrkaphase As Integer
Dim WrkListNo As Integer
Dim WrkTaxType As String
Dim WrkUBType As String
Dim WrkFamily As String
Dim WrkRateCode As String
Dim WrkCode As String
Public Sub PrtReport()
myUTCUSTQ = New UTCUSTQ.mydata(MyDBConnect)
myUTCUSTRT = New UTCUSTRT.mydata(MyDBConnect)

With MyFrmUB202B
  WrkDist = MyUtils.CnvSng(.TxtDist.Text)
  WrkDistto = MyUtils.CnvSng(.txtdistto.Text)
  WrkPhase = MyUtils.CnvSng(.TxtPhase.Text)
  WrkPhaseto = MyUtils.CnvSng(.txtphaseto.Text)
  WrkUBType = .TxtType.Text
  If WrkDist = 0 And WrkDistto = 0 Then
    WrkDistto = 999
    If WrkPhase = 0 And WrkPhaseto = 0 Then
      WrkPhaseto = 9
    End If
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
  WrkCode = .TxtCode.Text
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
  Select Case WrkSortBy
  Case "List"
    .Wrksort = "By Account"
  Case "Name"
    .Wrksort = "By Name"
  Case "Location"
    .Wrksort = "By Location"
  End Select
  .Wrkdistphase = "District / Phase " + WrkDist.ToString + " / " + WrkPhase.ToString _
    + " To: " + WrkDistto.ToString + " / " + WrkPhaseto.ToString
  .Show()
End With
End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("Location", Type.GetType("System.String"))
      .Columns.Add("RateCode", Type.GetType("System.String"))
      .Columns.Add("Units", Type.GetType("System.Decimal"))
      .Columns.Add("Extras", Type.GetType("System.Int16"))
      .Columns.Add("Fixtures", Type.GetType("System.Int16"))
      .Columns.Add("SurChg", Type.GetType("System.Decimal"))
      .Columns.Add("EDUs", Type.GetType("System.Decimal"))
      .Columns.Add("MeterSize", Type.GetType("System.String"))
      .Columns.Add("PropVal", Type.GetType("System.Int32"))
      .Columns.Add("Footage", Type.GetType("System.Decimal"))
      .Columns.Add("Acreage", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub

Private Sub GetDetail()
Dim AddrLine() As String
Dim WrkQry As String
Dim WrkSort As String
Dim Counter As Integer
Dim WrkAnd As String

WrkFamily = GetUTTYPEFamily(WrkUBType)

If MyServer = "DB2" Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

    'MK 7/17/25 Begin
    'WrkQry = ""
    WrkQry = "RCODE<>'I'"
    'MK 7/17/25 End
    If WrkDistto > WrkDist Then
    WrkQry = "cudst>=" & WrkDist & WrkAnd & "cudst<=" & WrkDistto
  Else
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
    'filter phase..  cannot go phae to phase in call cases  as i can run dist 1 phase 3 to dist 4 phase 2
    wrkaphase = ._CUPHAS
    wrkadist = ._CUDST

    If WrkDist = WrkDistto Then
      If wrkaphase < WrkPhase Or wrkaphase > WrkPhaseto Then GoTo nextrec
    End If
    If WrkDist < WrkDistto Then
      If wrkaphase < WrkPhase And wrkadist = WrkDist Then GoTo nextrec
      If wrkaphase > WrkPhaseto And wrkadist = WrkDistto Then GoTo nextrec
    End If
    ' end phase filter.

    WrkListNo = ._CUACCT
    WrkRateCode = GetRateCode(WrkUBType)
    If Trim(WrkRateCode) = "" Then GoTo NextRec
    If WrkCode <> String.Empty Then
      If Trim(WrkCode) <> Trim(WrkRateCode) Then
        GoTo NextRec
      End If
    End If

    AddrLine = MyUtils.SetAddrLine(._CUNAM1, ._CUNAM2, ._CUADD1, ._CUADD2, ._CUCITY, ._CUST, 0, 0, ._CUZIP)

   'Report
    dr = ds.Tables(0).NewRow
    dr.Item("listno") = WrkListNo
    dr.Item("addr1") = AddrLine(0)
    dr.Item("addr2") = AddrLine(1)
    dr.Item("addr3") = AddrLine(2)
    dr.Item("addr4") = AddrLine(3)
    dr.Item("addr5") = AddrLine(4)
    dr.Item("location") = Trim(._CULOCNO) & " " & Trim(._CULOC)
    dr.Item("ratecode") = WrkRateCode
    Select Case WrkFamily
    Case "A"
      dr.Item("units") = ._CUAUNT
      dr.Item("propval") = ._CUPVAL
      dr.Item("footage") = ._CUFOOT
      dr.Item("acreage") = ._CUACRE
    Case "U"
      dr.Item("units") = ._CUUNIT
      dr.Item("extras") = ._CUXTRA
      If WrkUBType = "U" Then
        dr.Item("fixtures") = ._CUSFIX
      Else
        dr.Item("fixtures") = ._CUWFIX
      End If
      dr.Item("surchg") = ._CUXTRA
      dr.Item("edus") = ._CUEDU
    Case "M"
      dr.Item("units") = ._CUUNIT
      dr.Item("metersize") = Trim(._CUMSIZ)
      dr.Item("edus") = ._CUEDU
    End Select
    ds.Tables(0).Rows.Add(dr)
  End With

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
myUTCUSTQ.CloseFile()
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






