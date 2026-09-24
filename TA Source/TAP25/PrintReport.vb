Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXDCPPQ As TXDCPPQ.MyData
  Dim myTXDCPP As TXDCPP.MyData
  Dim myTXDCSUM As TXDCSUM.MyData

  Dim ds As DataSet = New DataSet
  Dim DsTXPPRP As DataSet = New DataSet
  Dim dr As Data.DataRow
  'Screen fields
  Dim WrkYear As Integer
  Dim WrkMissing As Boolean
  Dim WrkActive As Boolean
  Dim WrkPending As Boolean
  Dim WrkPenCode As String
  Dim WrkPenAmount As Integer
  Dim WrkPenPct As Decimal
  Dim WrkPost As Boolean
  'File
  Dim WrkAss(9) As Integer
  Dim WrkCode(9) As Integer
  Dim WrkUnit(9) As Integer

  Public Sub PrtReport()

    myTXDCPPQ = New TXDCPPQ.MyData(myDBConnect)
    myTXDCPP = New TXDCPP.MyData(myDBConnect)
    myTXDCSUM = New TXDCSUM.MyData(myDBConnect)
    WrkMissing = False
    WrkPost = False

    With MyFrmTAP25B
      WrkYear = MyUtils.CnvSng(.TxtYear.Text)
      WrkActive = .ChkActive.Checked
      WrkPending = .ChkPending.Checked
      If .RbMissing.Checked Then WrkMissing = True
      WrkPenCode = .TxtPenCode.Text
      WrkPenAmount = MyUtils.CnvSng(.TxtPenAmount.Text)
      WrkPenPct = MyUtils.CnvSng(.TxtPenPct.Text) / 100
      If .ChkPost.Checked Then WrkPost = True
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.WrkPenCode = WrkPenCode
    MyCrViewer.WrkPost = WrkPost
    MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("PropLoc", Type.GetType("System.String"))
      .Columns.Add("PenAmount", Type.GetType("System.Decimal"))
      .Columns.Add("Error", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub GetDetail()
    Dim WrkNet As Integer
    Dim WrkAmount As Integer
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim WrkAnd As String

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkSort = "OWNAME"
    WrkQry = "YEAR=" & WrkYear
    myTXDCPPQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXDCPPQ.ReadQry()
    If Not myTXDCPPQ.IsEOF Then
      With myTXDCPPQ
        Counter = Counter + 1
        myTXDCPP.GetOneRecordP(._LISTNO, WrkYear)
        If WrkMissing Then
          If Not myTXDCPP.RecordNotFound Then GoTo NextRec
        Else
          If myTXDCPP._FILSTS <> "N" Then GoTo NextRec
          If WrkActive And Trim(myTXDCPP._STATUS) = "" Then GoTo Process
          If WrkPending And Trim(myTXDCPP._STATUS) = "P" Then GoTo Process
          GoTo NextRec
        End If

Process:
        WrkNet = CalcSummary(._LISTNO)
        If WrkPenAmount > 0 Then
          WrkAmount = WrkPenAmount
        Else
          WrkAmount = WrkNet * WrkPenPct
        End If

        dr = ds.Tables(0).NewRow
        dr.Item("listno") = ._LISTNO
        dr.Item("name") = ._OWNAME
        dr.Item("proploc") = Trim(._LOCNO) & " " & ._LOC
        dr.Item("penamount") = WrkAmount
        dr.Item("error") = ""
        ds.Tables(0).Rows.Add(dr)

        If WrkPost Then
          With myTXDCSUM
            .GetOneRecordP(myTXDCPPQ._LISTNO, WrkYear, WrkPenCode)
            ._VALUE = WrkAmount
            ._NET = WrkAmount
            ._STATUS = ""
            If .RecordNotFound Then
              ._LISTNO = myTXDCPPQ._LISTNO
              ._YEAR = WrkYear
              ._CODE = WrkPenCode
              .AddOneRecordP()
            Else
              .UpdateOneRecordP()
            End If
          End With
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
    myTXDCPPQ.CloseFile()
    myTXDCPP.CloseFile()
  End Sub
  Private Function CalcSummary(ByVal WrkListNo As Integer) As Long
    Dim ds2 As DataSet = New DataSet
    Dim WrkAssrNet As Long
    Dim I As Integer

    Windows.Forms.Cursor.Current = Cursors.WaitCursor()
    WrkAssrNet = 0
    ds2 = myTXDCSUM.GetByList(WrkListNo, WrkYear)
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      If ds2.Tables(0).Rows(I).Item("code") <> WrkPenCode Then
        WrkAssrNet = WrkAssrNet + ds2.Tables(0).Rows(I).Item("net")
      End If
    Next
    Windows.Forms.Cursor.Current = Cursors.Default
    Return WrkAssrNet
  End Function
  Public Function RoundNumber(ByVal WrkNumber As Integer, ByVal RoundMethod As String) As Integer
    Dim RoundDown As Boolean
    Dim J As Integer

    Select Case RoundMethod
      Case "Down"
        RoundDown = True
      Case "Normal"
        RoundDown = False
      Case Else
        Return WrkNumber
    End Select

    J = WrkNumber Mod 10
    If J <> 0 Then
      If RoundDown Then
        WrkNumber = WrkNumber - J
      Else
        If J < 5 Then
          WrkNumber = WrkNumber - J
        Else
          WrkNumber = WrkNumber + (10 - J)
        End If
      End If
    End If

    Return WrkNumber
  End Function
End Module






