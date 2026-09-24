Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXPPRPQ As TXPPRPQ.MyData
  Dim myTXPPRP As TXPPRP.MyData
  Dim myTXDCPP As TXDCPP.MyData

  Dim ds As DataSet = New DataSet
  Dim DsTXPPRP As DataSet = New DataSet
  Dim dr As Data.DataRow
  'Screen fields
  Dim WrkYear As Integer
  Dim WrkMissing As Boolean
  Dim WrkPenCode As String
  Dim WrkPenAmount As Integer
  Dim WrkPenPct As Decimal
  Dim WrkPost As Boolean
  'File
  Dim WrkAss(9) As Integer
  Dim WrkCode(9) As Integer
  Dim WrkUnit(9) As Integer

  Public Sub PrtReport()

    myTXPPRPQ = New TXPPRPQ.MyData(myDBConnect)
    myTXPPRP = New TXPPRP.MyData(myDBConnect)
    myTXDCPP = New TXDCPP.MyData(myDBConnect)
    WrkMissing = False
    WrkPost = False

    With MyFrmTA304B
      WrkYear = MyUtils.CnvSng(.TxtYear.Text)
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
    Dim WrkAmount As Integer

    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim J As Integer
    Dim WrkAnd As String
    Dim Good As Boolean

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkSort = "NAME"
    WrkQry = ""
    myTXPPRPQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXPPRPQ.ReadQry()
    If Not myTXPPRPQ.IsEOF Then
      With myTXPPRPQ
        Counter = Counter + 1
        myTXDCPP.GetOneRecordP(._LISTNO, WrkYear)
        If WrkMissing Then
          If Not myTXDCPP.RecordNotFound Then GoTo NextRec
        Else
          If myTXDCPP._FILSTS <> "N" Then GoTo NextRec
        End If
        WrkAss(0) = ._ASS1
        WrkAss(1) = ._ASS2
        WrkAss(2) = ._ASS3
        WrkAss(3) = ._ASS4
        WrkAss(4) = ._ASS5
        WrkAss(5) = ._ASS6
        WrkAss(6) = ._ASS7
        WrkAss(7) = ._ASS8
        WrkAss(8) = ._ASS9
        WrkAss(9) = ._ASS10
        WrkCode(0) = ._CODE1
        WrkCode(1) = ._CODE2
        WrkCode(2) = ._CODE3
        WrkCode(3) = ._CODE4
        WrkCode(4) = ._CODE5
        WrkCode(5) = ._CODE6
        WrkCode(6) = ._CODE7
        WrkCode(7) = ._CODE8
        WrkCode(8) = ._CODE9
        WrkCode(9) = ._CODEA
        WrkUnit(0) = ._UNIT1
        WrkUnit(1) = ._UNIT2
        WrkUnit(2) = ._UNIT3
        WrkUnit(3) = ._UNIT4
        WrkUnit(4) = ._UNIT5
        WrkUnit(5) = ._UNIT6
        WrkUnit(6) = ._UNIT7
        WrkUnit(7) = ._UNIT8
        WrkUnit(8) = ._UNIT9
        WrkUnit(9) = ._UNITA

        If WrkPenAmount > 0 Then
          WrkAmount = WrkPenAmount
        Else
          WrkAmount = MyUtils.Round(._NET * WrkPenPct, 0)
        End If

        Good = False
        'Find an available bucket to use
        For J = 0 To 9
          If WrkAss(J) = WrkPenCode Then
            Exit For
          End If
          If WrkCode(J) = 0 Then
            WrkAss(J) = WrkAmount
            WrkCode(J) = WrkPenCode
            WrkUnit(J) = 1
            Good = True
            Exit For
          End If
        Next

        dr = ds.Tables(0).NewRow
        dr.Item("listno") = ._LISTNO
        dr.Item("name") = ._NAME
        dr.Item("proploc") = Trim(._LOCNO) & " " & ._LOC
        dr.Item("penamount") = WrkAmount
        dr.Item("error") = ""
        If Not Good Then
          dr.Item("error") = "* Cannot apply penalty *"
        End If
        ds.Tables(0).Rows.Add(dr)

        If WrkPost Then
          UpdateTXPPRP(._LISTNO)
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
    myTXPPRPQ.CloseFile()
    myTXPPRP.CloseFile()

  End Sub
  Private Sub UpdateTXPPRP(ByVal List As Integer)
    myTXPPRP.GetOneRecordP(List)
    If Not myTXPPRP.RecordNotFound Then
      With myTXPPRP
        ._ASS1 = WrkAss(0)
        ._ASS2 = WrkAss(1)
        ._ASS3 = WrkAss(2)
        ._ASS4 = WrkAss(3)
        ._ASS5 = WrkAss(4)
        ._ASS6 = WrkAss(5)
        ._ASS7 = WrkAss(6)
        ._ASS8 = WrkAss(7)
        ._ASS9 = WrkAss(8)
        ._ASS10 = WrkAss(9)
        ._CODE1 = WrkCode(0)
        ._CODE2 = WrkCode(1)
        ._CODE3 = WrkCode(2)
        ._CODE4 = WrkCode(3)
        ._CODE5 = WrkCode(4)
        ._CODE6 = WrkCode(5)
        ._CODE7 = WrkCode(6)
        ._CODE8 = WrkCode(7)
        ._CODE9 = WrkCode(8)
        ._CODEA = WrkCode(9)
        ._UNIT1 = WrkUnit(0)
        ._UNIT2 = WrkUnit(1)
        ._UNIT3 = WrkUnit(2)
        ._UNIT4 = WrkUnit(3)
        ._UNIT5 = WrkUnit(4)
        ._UNIT6 = WrkUnit(5)
        ._UNIT7 = WrkUnit(6)
        ._UNIT8 = WrkUnit(7)
        ._UNIT9 = WrkUnit(8)
        ._UNITA = WrkUnit(9)
      End With
      myTXPPRP.UpdateOneRecordP()
    End If
  End Sub
End Module






