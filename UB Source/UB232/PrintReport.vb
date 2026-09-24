Imports System.Text
Module PrintReport
Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myUTCUSTQ As UTCUSTQ.myData
Dim myUTCUSTRT As UTCUSTRT.myData
Dim myTXREAL As TXReal.myData
Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkPhase As Integer
Dim WrkUBType As String
Dim WrkRpt As String
  Public Sub PrtReport()
  myUTCUSTQ = New UTCUSTQ.mydata(MyDBConnect)
  myUTCUSTRT = New UTCUSTRT.mydata(MyDBConnect)
  myTXREAL = New TXReal.mydata(MyDBConnect)

  With MyFrmUB232B
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    WrkPhase = MyUtils.CnvSng(.TxtPhase.Text)
    WrkUBType = .TxtUBType.Text
    If .TxtDist.Text = "" Then
      WrkDistAll = True
    End If
    If .RbAll.Checked Then WrkRpt = "All"
    If .RbComm.Checked Then WrkRpt = "Commercial"
    If .RbExempt.Checked Then WrkRpt = "Exempt"
    If .RbMixed.Checked Then WrkRpt = "Mixed"
    If .RbMulti.Checked Then WrkRpt = "Multi-Family"
    If .RbResid.Checked Then WrkRpt = "Residential"
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
Dim WrkPhaseA As String
Dim WrkUBCode As String
Dim WrkCode(6) As Integer
Dim WrkSort As String
Dim WrkQry As String
Dim Counter As Integer
Dim J As Integer
Dim WrkAnd As String
Dim WrkOr As String
Dim Pos As Integer
Dim Good As Boolean

If myDBConnect.ServerAS400 Then
  WrkOr = " *or "
  WrkAnd = " *and "
Else
  WrkOr = " or "
  WrkAnd = " and "
 End If

WrkSort = "CULOC, CULOC#"
WrkQry = ""
If Not WrkDistAll Then
  WrkQry = "cudst=" & WrkDist
End If
If WrkPhase = 0 Then
  WrkPhaseA = ""
Else
  WrkPhaseA = WrkPhase
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
    WrkUBCode = GetRateCode(._CUACCT, WrkUBType)
    If Trim(WrkUBCode) = "" Then GoTo NextRec
    myTXREAL.GetOneRecordP(._CUACCT)
    If Not myTXREAL.RecordNotFound Then
      WrkCode(0) = myTXREAL._CODE1
      WrkCode(1) = myTXREAL._CODE2
      WrkCode(2) = myTXREAL._CODE3
      WrkCode(3) = myTXREAL._CODE4
      WrkCode(4) = myTXREAL._CODE5
      WrkCode(5) = myTXREAL._CODE6
      WrkCode(6) = myTXREAL._CODE7
    Else
      Array.Clear(WrkCode, 0, 6)
    End If
    Good = False
    If Not MySelCodes = String.Empty Then
      For J = 0 To 6
        If WrkCode(J) = 0 Then Continue For
        Pos = InStr(MySelCodes, Format(WrkCode(J), " ###"))
        If Pos > 0 Then Good = True
      Next J
    End If

    If WrkRpt = "Exempt" Then
      If myTXREAL._CAT <> "3" Then
        GoTo NextRec
      End If
    Else
      If Not Good And Not MySelCodes = String.Empty Then
        GoTo NextRec
      End If
    End If

    dr = ds.Tables(0).NewRow
    dr.Item("listno") = ._CUACCT
    dr.Item("exmpt") = myTXREAL._EXMPT
    dr.Item("name") = ._CUNAM1
    dr.Item("proploc") = Trim(._CULOCNO) & " " & ._CULOC
    dr.Item("map") = myTXREAL._MAP
    dr.Item("cuunit") = ._CUUNIT
    dr.Item("code1") = WrkCode(0)
    dr.Item("code2") = WrkCode(1)
    dr.Item("code3") = WrkCode(2)
    dr.Item("code4") = WrkCode(3)
    dr.Item("code5") = WrkCode(4)
    dr.Item("code6") = WrkCode(5)
    dr.Item("code7") = WrkCode(6)
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
    .Columns.Add("exmpt", Type.GetType("System.String"))
    .Columns.Add("name", Type.GetType("System.String"))
    .Columns.Add("proploc", Type.GetType("System.String"))
    .Columns.Add("map", Type.GetType("System.String"))
    .Columns.Add("cuunit", Type.GetType("System.Decimal"))
    .Columns.Add("code1", Type.GetType("System.Int32"))
    .Columns.Add("code2", Type.GetType("System.Int32"))
    .Columns.Add("code3", Type.GetType("System.Int32"))
    .Columns.Add("code4", Type.GetType("System.Int32"))
    .Columns.Add("code5", Type.GetType("System.Int32"))
    .Columns.Add("code6", Type.GetType("System.Int32"))
    .Columns.Add("code7", Type.GetType("System.Int32"))
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






