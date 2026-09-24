Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXMVDCQ As TXMVDCQ.myData
Dim myTXMVDC As TXMVDC.myData
Dim myTXSUPPQ As TXSUPPQ.myData
Dim myTXSUPP As TXSupp.myData
Dim myTXLEASE As TXLEASE.myData

Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow
'Screen
Dim WrkMV As Boolean
Dim WrkSupp As Boolean
Dim WrkPost As Boolean
'General
Dim WrkAnd As String
Dim WrkOr As String
Dim WrkSortBy As String
Dim WrkCode(250) As String
Dim WrkName(250) As String
Dim WrkAddr1(250) As String
Dim WrkCity(250) As String
  Public Sub PrtReport()

  WrkMV = False
  WrkSupp = False
  With MyFrmTX430B
    If .RbMV.Checked Then WrkMV = True
    If .RbSupp.Checked Then WrkSupp = True
    WrkPost = .Chkupdatebacktax.Checked
  End With
  If Not WrkMV And Not WrkSupp Then
    MsgBox("Choose Motor Vehicle or Supplemental", vbExclamation, "Option has not been selected")
    Exit Sub
  End If

  If WrkMV Then
    myTXMVDCQ = New TXMVDCQ.mydata(MyDBConnect)
    myTXMVDC = New TXMVDC.mydata(MyDBConnect)
  Else
    myTXSUPPQ = New TXSUPPQ.mydata(MyDBConnect)
    myTXSUPP = New TXSupp.mydata(MyDBConnect)
  End If
  myTXLEASE = New TXLEASE.mydata(MyDBConnect)

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
  End If

  BufferLease()
  If WrkMV Then
    GetDetailMV()
  Else
    GetDetailSupp()
  End If

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.Wrkds = ds
  MyCrViewer.WrkPost = WrkPost
  MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Add1", Type.GetType("System.String"))
      .Columns.Add("City", Type.GetType("System.String"))
      .Columns.Add("Lease", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
Private Sub GetDetailMV()
Dim WrkQry As String
Dim WrkSort As String
Dim WrkLease As String
Dim Counter As Integer

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If
If MyServer = "SQL" Then
  MyBlocking = False
Else
  MyBlocking = True
End If

WrkSort = "NAME, LIST#"
WrkQry = ""
myTXMVDCQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
  myTXMVDCQ.ReadQry()
  If Not myTXMVDCQ.IsEOF Then
    With myTXMVDCQ
      Counter = Counter + 1
      WrkLease = LookupLease(Trim(._NAME), Trim(._ADD1), Trim(._CITY))
      If WrkLease <> "" Then
        WriteDsMV(WrkLease)
        If WrkPost Then
          myTXMVDC.GetOneRecordP(._LISTNO)
          myTXMVDC._LEASE = WrkLease
          myTXMVDC.UpdateOneRecordP()
        End If
      End If
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
myTXMVDCQ.CloseFile()

End Sub
Private Sub GetDetailSupp()
Dim WrkQry As String
Dim WrkSort As String
Dim WrkLease As String
Dim Counter As Integer

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If
If MyServer = "SQL" Then
  MyBlocking = False
Else
  MyBlocking = True
End If

WrkSort = "NAME, LIST#"
WrkQry = ""
myTXSUPPQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
  myTXSUPPQ.ReadQry()
  If Not myTXSUPPQ.IsEOF Then
    With myTXSUPPQ
      Counter = Counter + 1
      WrkLease = LookupLease(Trim(._NAME), Trim(._ADD1), Trim(._CITY))
      If WrkLease <> "" Then
        WriteDsSU(WrkLease)
        If WrkPost Then
          myTXSUPP.GetOneRecordP(._LISTNo)
          myTXSUPP._LEASE = WrkLease
          myTXSUPP.UpdateOneRecordP()
        End If
      End If
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
myTXSUPPQ.CloseFile()

End Sub
Private Sub WriteDsMV(ByVal WrkLease As String)
  With myTXMVDCQ
    dr = ds.Tables(0).NewRow
    dr.Item("listno") = ._LISTNO
    dr.Item("name") = Trim(._NAME)
    dr.Item("add1") = Trim(._ADD1)
    dr.Item("city") = Trim(._CITY)
    dr.Item("Lease") = WrkLease
  End With
  ds.Tables(0).Rows.Add(dr)
End Sub
Private Sub WriteDsSU(ByVal WrkLease As String)
  With myTXSUPPQ
    dr = ds.Tables(0).NewRow
    dr.Item("listno") = ._LISTNo
    dr.Item("name") = Trim(._NAME)
    dr.Item("add1") = Trim(._ADD1)
    dr.Item("city") = Trim(._CITY)
    dr.Item("Lease") = WrkLease
  End With
  ds.Tables(0).Rows.Add(dr)
End Sub
Private Sub BufferLease()
     Dim I As Integer
     Dim ds2 As DataSet = New DataSet

     ds2 = myTXLEASE.PosData("")
     For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        WrkCode(I) = .Item("code")
        WrkName(I) = UCase(.Item("name"))
        WrkAddr1(I) = UCase(.Item("addr1"))
        WrkCity(I) = UCase(.Item("city"))
      End With
    Next
    ds2 = Nothing
End Sub
Private Function LookupLease(ByVal Name As String, ByVal Addr1 As String, ByVal City As String) As String
    Dim I As Integer

    For I = 0 To WrkName.GetUpperBound(0)
      If WrkName(I) & "" = "" Then
        Return ""
      End If
      If Name = Trim(WrkName(I)) Then
        Return WrkCode(I)
      End If
    Next
    Return ""
End Function
End Module






