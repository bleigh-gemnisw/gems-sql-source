Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXMVDQ As TXMVDQ.myData
Dim myTXZIP As TXZIP.myData
Dim myTXCNTL As TXCNTL.myData
Dim myTXVCUS As TXVCUS.myData

Dim ds As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim ds3 As DataSet = New DataSet
Dim DsTXMVD As DataSet = New DataSet
Dim dr As Data.DataRow
Dim dr2 As Data.DataRow
Dim dr3 As Data.DataRow

Dim WrkTCount As Integer
Dim WrkTVal70 As Integer
Dim WrkTLYVal As Integer
Dim WrkTLNVal As Integer
Dim WrkTTIVal As Integer
Dim WrkTMSRPVal As Integer
Dim addrline As String

  Public Sub PrtReport()

	myTXMVDQ = New TXMVDQ.mydata(MyDBConnect)
  myTXZIP = New TXZIP.mydata(MyDBConnect)
	myTXCNTL = New TXCNTL.mydata(MyDBConnect)
  myTXVCUS = New TXVCUS.mydata(MyDBConnect)

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
    ds2.Clear()
    ds3.Clear()
    ClearTotals()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.wrkds = ds
  MyCrViewer.wrkds2 = ds2
  MyCrViewer.Show()

  End Sub
Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With (myTable)
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Sname", Type.GetType("System.String"))
      .Columns.Add("Addr", Type.GetType("System.String"))
      .Columns.Add("City", Type.GetType("System.String"))
      .Columns.Add("State", Type.GetType("System.String"))
      .Columns.Add("Zip5", Type.GetType("System.Int32"))
      .Columns.Add("Zip4", Type.GetType("System.Int32"))
      .Columns.Add("ZipPlus4", Type.GetType("System.String"))
      .Columns.Add("Break", Type.GetType("System.String"))
      .Columns.Add("Rad1", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)


    With myTable2
      .TableName = "mytable2"
      .Columns.Add("TCount", Type.GetType("System.Int32"))
      .Columns.Add("TVal70", Type.GetType("System.Int32"))
      .Columns.Add("TLYVal", Type.GetType("System.Int32"))
      .Columns.Add("TLNVal", Type.GetType("System.Int32"))
      .Columns.Add("TTIVal", Type.GetType("System.Int32"))
      .Columns.Add("TMSRPVal", Type.GetType("System.Int32"))
    End With
    ds2.Tables.Add(myTable2)

  End Sub
Private Sub ClearTotals()
  WrkTCount = 0
  WrkTVal70 = 0
  WrkTLYVal = 0
  WrkTLNVal = 0
  WrkTTIVal = 0
  WrkTMSRPVal = 0
End Sub
Private Sub GetDetail()
Dim WrkSort As String
Dim WrkQry As String
Dim I As Integer
Dim WrkAnd As String
Dim WrkOr As String
Dim WrkName As Boolean
Dim WrkZip As Integer
Dim WrkInState As Boolean
Dim WrkConfid As Boolean
Dim WrkTownZip As String
Dim WrkState As String

With MyFrmTA4074B
  WrkName = .RbName.Checked
  WrkInState = .ChkInState.Checked
  WrkConfid = .ChkConfid.Checked
End With

WrkTownZip = myTOWN._ZIP
myTXCNTL.GetOneRecordP("")
With myTXCNTL
  WrkState = Trim(._STACD)
End With

If WrkName Then
  WrkSort = "NAME"
Else
  WrkSort = "CITY, NAME"
End If

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

WrkQry = "ZIP5 != " + WrkTownZip
If WrkInState Then
  WrkQry = WrkQry & WrkAnd & "STATE=" & MyUtils.Quo(WrkState)
End If

DsTXMVD = myTXMVDQ.GetQry(WrkSort, WrkQry, 0)
If DsTXMVD.Tables(0).Rows.Count = 0 Then Exit Sub
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

For I = 0 To (DsTXMVD.Tables(0).Rows.Count - 1)
  With DsTXMVD.Tables(0).Rows(I)
    WrkZip = .Item("zip5")
    myTXZIP.GetOneRecordP(WrkZip)
    If Not myTXZIP.RecordNotFound Then
      GoTo NextRec
    Else
      If .Item("rz5") > 0 Then
        myTXZIP.GetOneRecordP(.Item("rz5"))
        If Not myTXZIP.RecordNotFound Then
          GoTo NextRec
        End If
      End If
    End If
    If WrkConfid Then
      myTXVCUS.GetOneRecordP(.Item("ss#"))
      If Not myTXVCUS.RecordNotFound Then
        If myTXVCUS._CONFID = "Y" Then
          GoTo NextRec
        End If
      End If
    End If
    dr = ds.Tables(0).NewRow
    dr.Item("listno") = .Item("list#")
    dr.Item("name") = .Item("name")
    dr.Item("sname") = .Item("sname")
    dr.Item("addr") = .Item("add1")
    dr.Item("City") = .Item("city")
    dr.Item("State") = .Item("state")
    dr.Item("ZIP5") = WrkZip
    dr.Item("ZIP4") = .Item("zip4")
    dr.Item("ZipPlus4") = Format(WrkZip, "00000") + "-" + Format(.Item("zip4"), "0000")
    If WrkName Then
      dr.Item("break") = String.Empty
    Else
      dr.Item("break") = .Item("city")
    End If
    dr.Item("rad1") = .Item("rad1")
    ds.Tables(0).Rows.Add(dr)

    WrkTVal70 = WrkTVal70 + .Item("value")
    WrkTLNVal = WrkTLNVal + .Item("lnval")
    WrkTTIVal = WrkTTIVal + .Item("trval")
    WrkTMSRPVal = WrkTMSRPVal + .Item("msrp")
  End With

  WrkTCount = WrkTCount + 1
  WriteTotals()

NextRec:
  With myFrmProgress
    WrkPct = ((I + 1) / DsTXMVD.Tables(0).Rows.Count) * 100
    If SavePct <> WrkPct Then
      .ProgBar1.Value = WrkPct
      .Refresh()
      SavePct = WrkPct
      Application.DoEvents()
    End If
  End With
Next

myFrmProgress.Close()
myTXMVDQ.CloseFile()
mytxzip.CloseFile()

End Sub
Private Sub WriteTotals()
  If WrkTCount = 0 Then Exit Sub

  dr2 = ds2.Tables(0).NewRow
  dr2.Item("tcount") = WrkTCount
  dr2.Item("tVal70") = WrkTVal70
  dr2.Item("tLYval") = WrkTLYVal
  dr2.Item("tLNVal") = WrkTLNVal
  dr2.Item("tTIVal") = WrkTTIVal
  dr2.Item("tMSRPVal") = WrkTMSRPVal
  ds2.Tables(0).Rows.Add(dr2)
End Sub
End Module






