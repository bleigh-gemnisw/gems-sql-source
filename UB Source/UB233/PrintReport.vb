Imports System.Text
Module PrintReport
Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myUTCUSTQ As UTCUSTQ.myData
Dim myUTCUSTRT As UTCUSTRT.myData
Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkPhase As Integer
Dim WrkLoc As Boolean
Dim WrkUBType As String
Dim WrkRpt As String
  Public Sub PrtReport()
  myUTCUSTQ = New UTCUSTQ.mydata(MyDBConnect)
  myUTCUSTRT = New UTCUSTRT.mydata(MyDBConnect)

  With MyFrmUB233B
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    WrkPhase = MyUtils.CnvSng(.TxtPhase.Text)
    WrkUBType = .TxtUBType.Text
    If .TxtDist.Text = "" Then
      WrkDistAll = True
    End If
    WrkLoc = .RbLoc.Checked
  End With

  If ds.Tables.Count = 0 Then
    BuildDS(ds)
  Else
    ds.Clear()
  End If

  GetDetail()

  MyCrViewer = New FrmCrViewer
  With MyCrViewer
    .wrkds = ds
    .WrkRpt = WrkRpt
    .WrkUBType = WrkUBType
    .Show()
  End With
  End Sub
Private Sub GetDetail()
Dim WrkUBCode As String
Dim WrkSort As String
Dim WrkQry As String
Dim Counter As Integer
Dim WrkAnd As String
Dim WrkOr As String

If myDBConnect.ServerAS400 Then
  WrkOr = " *or "
  WrkAnd = " *and "
Else
  WrkOr = " or "
  WrkAnd = " and "
 End If

WrkSort = "CUZONE, CUROUT, CUNAM1"
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
    If WrkUBType <> "" Then
      WrkUBCode = GetRateCode(._CUACCT, WrkUBType)
      If Trim(WrkUBCode) = "" Then GoTo NextRec
    End If

    dr = ds.Tables(0).NewRow
    dr.Item("listno") = ._CUACCT
    dr.Item("zone") = Trim(._CUZONE)
    dr.Item("route") = Trim(._CUROUT)
    dr.Item("cumsiz") = Trim(._CUMSIZ)
    dr.Item("name") = Trim(._CUNAM1)
    dr.Item("name2") = Trim(._CUNAM2)
    If WrkLoc Then
      dr.Item("addr1") = Trim(._CULOCNO) & " " & Trim(._CULOC)
      dr.Item("addr2") = ""
      dr.Item("addr3") = ""
    Else
      dr.Item("addr1") = Trim(._CUADD1)
      If Trim(._CUADD2) <> "" Then
        dr.Item("addr2") = Trim(._CUADD2)
        dr.Item("addr3") = Trim(._CUCITY) & " " & Trim(._CUST) & " " & Trim(._CUZIP)
      Else
        dr.Item("addr2") = Trim(._CUCITY) & " " & Trim(._CUST) & " " & Trim(._CUZIP)
        dr.Item("addr3") = ""
      End If
    End If
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
Application.DoEvents()
myUTCUSTQ.CloseFile()

End Sub
Friend Sub BuildDS(ByRef ds As DataSet)
  Dim myTable As New DataTable

  With myTable
    .TableName = "mytable"
    .Columns.Add("listno", Type.GetType("System.Int64"))
    .Columns.Add("zone", Type.GetType("System.String"))
    .Columns.Add("route", Type.GetType("System.String"))
    .Columns.Add("cumsiz", Type.GetType("System.String"))
    .Columns.Add("name", Type.GetType("System.String"))
    .Columns.Add("name2", Type.GetType("System.String"))
    .Columns.Add("addr1", Type.GetType("System.String"))
    .Columns.Add("addr2", Type.GetType("System.String"))
    .Columns.Add("addr3", Type.GetType("System.String"))
  End With
  ds.Tables.Add(myTable)
End Sub
Private Function GetRateCode(ByVal WrkListno As Integer, ByVal WrkUBType As String) As String
  GetRateCode = ""
  myUTCUSTRT.GetOneRecordP(WrkListNo, WrkUBType)
  If myUTCUSTRT.RecordNotFound Then Exit Function

  With myUTCUSTRT
    GetRateCode = ._CRCODE
  End With
End Function
End Module






