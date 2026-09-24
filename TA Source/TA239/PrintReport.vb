Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXREALQ As TXREALQ.MyData
  Dim myTXREAL As TXREAL.MyData

  Dim dsFile As DataSet = New DataSet
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim WrkPost As Boolean

  Public Sub PrtReport()
    myTXREALQ = New TXREALQ.MyData(myDBConnect)
    myTXREAL = New TXREAL.MyData(myDBConnect)

    With MyFrmTA239B
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
    MyCrViewer.WrkPost = WrkPost
    MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Exam", Type.GetType("System.Int32"))
      .Columns.Add("Nexam", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub GetDetail()
    Dim WrkAssCode(6) As Integer
    Dim WrkGross(6) As Long
    Dim WrkExcd(6) As String
    Dim WrkExam(6) As Integer
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkCode As String
    Dim WrkAssCode13 As Integer
    Dim WrkOldExam As Integer
    Dim WrkNewExam As Integer
    Dim WrkTotExam As Integer
    Dim I As Integer
    Dim J As Integer
    Dim WrkAnd As String
    Dim WrkOr As String

    WrkAnd = " and "
    WrkOr = " or "

    WrkCode = "APA"
    WrkSort = ""
    WrkQry = "EXCD1=" & MyUtils.Quo(WrkCode) & WrkOr & "EXCD2=" & MyUtils.Quo(WrkCode) & WrkOr &
    "EXCD3=" & MyUtils.Quo(WrkCode) & WrkOr & "EXCD4=" & MyUtils.Quo(WrkCode) & WrkOr &
    "EXCD5=" & MyUtils.Quo(WrkCode) & WrkOr & "EXCD6=" & MyUtils.Quo(WrkCode) & WrkOr &
    "EXCD7=" & MyUtils.Quo(WrkCode)


    dsFile = myTXREALQ.GetQry(WrkSort, WrkQry, 0)
    If Dsfile.Tables(0).Rows.Count = 0 Then
      myTXREALQ.CloseFile()
      Exit Sub
    End If

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    If dsFile.Tables(0).Rows.Count = 0 Then GoTo Done

    For I = 0 To (dsFile.Tables(0).Rows.Count - 1)
      WrkAssCode13 = 0
      WrkOldExam = 0
      WrkNewExam = 0
      With myTXREAL
        .GetOneRecordP(dsFile.Tables(0).Rows(I).Item("list#"))
        WrkAssCode(0) = ._CODE1
        WrkAssCode(1) = ._CODE2
        WrkAssCode(2) = ._CODE3
        WrkAssCode(3) = ._CODE4
        WrkAssCode(4) = ._CODE5
        WrkAssCode(5) = ._CODE6
        WrkAssCode(6) = ._CODE7
        WrkGross(0) = ._ASS1
        WrkGross(1) = ._ASS2
        WrkGross(2) = ._ASS3
        WrkGross(3) = ._ASS4
        WrkGross(4) = ._ASS5
        WrkGross(5) = ._ASS6
        WrkGross(6) = ._ASS7
        For J = 0 To 6
          If Trim(WrkAssCode(J)) = "13" Then
            WrkAssCode13 = WrkGross(J)
          End If
        Next J
        WrkExcd(0) = Trim(._EXCD1)
        WrkExcd(1) = Trim(._EXCD2)
        WrkExcd(2) = Trim(._EXCD3)
        WrkExcd(3) = Trim(._EXCD4)
        WrkExcd(4) = Trim(._EXCD5)
        WrkExcd(5) = Trim(._EXCD6)
        WrkExcd(6) = Trim(._EXCD7)
        WrkExam(0) = ._EXAM1
        WrkExam(1) = ._EXAM2
        WrkExam(2) = ._EXAM3
        WrkExam(3) = ._EXAM4
        WrkExam(4) = ._EXAM5
        WrkExam(5) = ._EXAM6
        WrkExam(6) = ._EXAM7
        For J = 0 To 6
          If WrkExcd(J) = WrkCode Then
            WrkOldExam = WrkExam(J)
            WrkNewExam = WrkAssCode13
            WrkExam(J) = WrkNewExam
          End If
        Next J
        If WrkOldExam = WrkNewExam Then
          Continue For
        End If

        dr = ds.Tables(0).NewRow
          dr.Item("listno") = ._LISTNO
          dr.Item("name") = ._NAME
          dr.Item("exam") = WrkOldExam
          dr.Item("nexam") = WrkNewExam
          ds.Tables(0).Rows.Add(dr)
          ._EXAM1 = WrkExam(0)
          ._EXAM2 = WrkExam(1)
          ._EXAM3 = WrkExam(2)
          ._EXAM4 = WrkExam(3)
          ._EXAM5 = WrkExam(4)
          ._EXAM6 = WrkExam(5)
          ._EXAM7 = WrkExam(6)
          For J = 0 To 6
            WrkTotExam = WrkTotExam + WrkExam(J)
          Next
          ._NET = ._GROSS - WrkTotExam
        If WrkPost Then
          .UpdateOneRecordP()
        End If
      End With
NextRec:
      With myFrmProgress
        If dsFile.Tables(0).Rows.Count > 1 Then
          WrkPct = ((I + 1) / dsFile.Tables(0).Rows.Count) * 100
          If SavePct <> WrkPct Then
            .ProgBar1.Value = WrkPct
            .Refresh()
            SavePct = WrkPct
            Application.DoEvents()
          End If
        End If
      End With
    Next

Done:
    myFrmProgress.Close()
  End Sub
End Module
