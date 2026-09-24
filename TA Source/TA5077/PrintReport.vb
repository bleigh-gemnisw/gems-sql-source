Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim found As Boolean
  Dim myTXSUPPQ As TXSUPPQ.MyData

  Dim ds As DataSet = New DataSet
  Dim DsTXSUPP As DataSet = New DataSet
  Dim dr As Data.DataRow
  'Buffered files
  Dim WrkSupCode(25) As String
  Dim WrkSupPct(25) As Decimal

  Public Sub PrtReport()

    myTXSUPPQ = New TXSUPPQ.MyData(myDBConnect)

    BufferTXSupcd()
    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With (myTable)
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("sname", Type.GetType("System.String"))
      .Columns.Add("addr", Type.GetType("System.String"))
      .Columns.Add("city", Type.GetType("System.String"))
      .Columns.Add("State", Type.GetType("System.String"))
      .Columns.Add("value", Type.GetType("System.Int32"))
      .Columns.Add("oval", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()

    Dim WrkSort As String
    Dim WrkQry As String
    Dim I As Integer
    Dim WrkAnd As String
    Dim WrkOr As String
    Dim WrkNet As Integer

    WrkSort = "LIST#, NAME"

    With MyFrmTA5077B
    End With

    WrkAnd = " and "
    WrkOr = " or "
    WrkQry = "OVAL > 0"

    DsTXSUPP = myTXSUPPQ.GetQry(WrkSort, WrkQry, 0)
    If DsTXSUPP.Tables(0).Rows.Count = 0 Then Exit Sub
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (DsTXSUPP.Tables(0).Rows.Count - 1)
      If MyReportCancel Then Exit Sub
      With DsTXSUPP.Tables(0).Rows(I)
        WrkNet = CalcNet(I)
        If WrkNet > 0 Then GoTo NextRec
        dr = ds.Tables(0).NewRow
        dr.Item("listno") = .Item("list#")
        dr.Item("name") = .Item("name")
        dr.Item("sname") = .Item("sname")
        dr.Item("addr") = .Item("add1")
        dr.Item("city") = .Item("city")
        dr.Item("state") = .Item("state")
        dr.Item("value") = .Item("value")
        dr.Item("oval") = .Item("oval")
      End With
      ds.Tables(0).Rows.Add(dr)

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsTXSUPP.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next


    myFrmProgress.Close()
    myTXSUPPQ.CloseFile()

  End Sub
  Private Function CalcNet(ByVal I As Integer)
    Dim WrkAssPct As Decimal
    Dim WrkProrate As Integer
    Dim WrkCredit As Integer
    Dim WrkExam As Integer
    Dim WrkNet As Integer

    With DsTXSUPP.Tables(0).Rows(I)
      WrkAssPct = CalcPct(.Item("ass"))
      If WrkAssPct > 0 Then
        WrkProrate = CalcAssmt(.Item("value"), WrkAssPct)
      End If
      WrkAssPct = CalcPct(.Item("oass"))
      If WrkAssPct > 0 Then
        WrkCredit = CalcAssmt(.Item("oval"), WrkAssPct)
      End If
      If WrkCredit > WrkProrate Then
        WrkCredit = WrkProrate
      End If
      WrkExam = .Item("exam1") + .Item("exam2") + .Item("exam3") + .Item("exam4") + .Item("exam5")
      WrkNet = WrkProrate - WrkCredit - WrkExam
    End With

    Return WrkNet
  End Function
  Public Function CalcPct(ByVal AssCd As String) As Decimal
    Dim K As Integer
    Dim WrkPct As Decimal

    K = LookupTxSupcd(AssCd)
    If K >= 0 Then
      WrkPct = WrkSupPct(K)
    Else
      WrkPct = -1
    End If
    Return WrkPct
  End Function
  Public Function CalcAssmt(ByVal Value As Integer, ByVal Pct As Decimal) As Integer
    Dim WrkProRate As Decimal

    WrkProRate = MyUtils.Round(Value * Pct, 0)
    Return WrkProRate
  End Function
  Private Sub BufferTXSupcd()
    Dim I As Integer

    Dim myTXSUPCD As TXSUPCD.MyData
    Dim dsTXSupcd As DataSet = New DataSet

    myTXSUPCD = New TXSUPCD.MyData(myDBConnect)

    dsTXSupcd = myTXSUPCD.GetAllData
    For I = 0 To dsTXSupcd.Tables(0).Rows.Count - 1
      With dsTXSupcd.Tables(0).Rows(I)
        WrkSupCode(I) = .Item("scod")
        WrkSupPct(I) = .Item("spct")
      End With
    Next

  End Sub
  Private Function LookupTxSupcd(ByVal Code As String) As Integer
    Dim I As Integer

    For I = 0 To WrkSupCode.GetUpperBound(0)
      If Trim(WrkSupCode(I)) = "" Then
        Return I
      End If
      If Trim(Code) = Trim(WrkSupCode(I)) Then
        Return I
      End If
    Next
    Return -1

  End Function
End Module






