Imports System.ComponentModel
Imports System.Net.Security
Imports System.Reflection
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXMVDQ As TXMVDQ.MyData
  Dim myTXMVDCL8 As TXMVDCL8.MyData

  Dim ds As DataSet = New DataSet
  Dim DsTXMVDC As DataSet = New DataSet
  Dim dr As Data.DataRow

  Public Sub PrtReport()

    myTXMVDQ = New TXMVDQ.MyData(myDBConnect)
    myTXMVDCL8 = New TXMVDCL8.MyData(myDBConnect)

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
    With myTable
      .TableName = "mytable"
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Vinno", Type.GetType("System.String"))
      .Columns.Add("Regno", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("PrevListNo", Type.GetType("System.Int32"))
      .Columns.Add("Excd1", Type.GetType("System.String"))
      .Columns.Add("Excd2", Type.GetType("System.String"))
      .Columns.Add("Excd3", Type.GetType("System.String"))
      .Columns.Add("Excd4", Type.GetType("System.String"))
      .Columns.Add("Excd5", Type.GetType("System.String"))
      .Columns.Add("Exam1", Type.GetType("System.Int32"))
      .Columns.Add("Exam2", Type.GetType("System.Int32"))
      .Columns.Add("Exam3", Type.GetType("System.Int32"))
      .Columns.Add("Exam4", Type.GetType("System.Int32"))
      .Columns.Add("Exam5", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim I As Integer
    Dim Counter As Integer
    Dim WrkAnd As String
    Dim WrkOr As String
    Dim WrkMVExam As Integer
    Dim WrkExam As Integer
    Dim WrkPrevListNo As Integer
    Dim WrkErrMsg As String

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkSort = "SS#"
    WrkQry = "CAT <> '2'"

    myTXMVDQ.OpenQry(WrkSort, WrkQry)
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXMVDQ.ReadQry()
    If Not myTXMVDQ.IsEOF Then
      With myTXMVDQ
        Counter = Counter + 1
        WrkErrMsg = ""
        If ._CCNO > 0 Then
          WrkMVExam = ._CEXA1 + ._CEXA2 + ._CEXA3 + ._CEXA4 + ._CEXA5
        Else
          WrkMVExam = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5
        End If

        DsTXMVDC = myTXMVDCL8.GetViewbyCustID(._SSNo, 0)
        If DsTXMVDC.Tables(0).Rows.Count = 0 Then
          GoTo ShowPct
        End If

        For I = 0 To DsTXMVDC.Tables(0).Rows.Count - 1
          With DsTXMVDC.Tables(0).Rows(I)
            WrkPrevListNo = .Item("List#")
            If .Item("CCNO") > 0 Then
              WrkExam = .Item("CEXA1") + .Item("CEXA2") + .Item("CEXA3") + .Item("CEXA4") + .Item("CEXA5")
            Else
              WrkExam = .Item("EXAM1") + .Item("EXAM2") + .Item("EXAM3") + .Item("EXAM4") + .Item("EXAM5")
            End If
            If WrkExam = 0 Then
              Continue For
            End If
          End With
          If WrkExam > 0 And WrkExam <> WrkMVExam Then
            dr = ds.Tables(0).NewRow
            dr.Item("name") = ._NAME
            dr.Item("vinno") = ._VINNO
            dr.Item("regno") = ._REGNO
            dr.Item("listno") = ._LISTNo
            dr.Item("prevlistno") = WrkPrevListNo
            With DsTXMVDC.Tables(0).Rows(I)
              If .Item("CCNO") > 0 Then
                dr.Item("excd1") = .Item("CCCD1")
                dr.Item("excd2") = .Item("CCCD2")
                dr.Item("excd3") = .Item("CCCD3")
                dr.Item("excd4") = .Item("CCCD4")
                dr.Item("excd5") = .Item("CCCD5")
                dr.Item("exam1") = .Item("CEXA1")
                dr.Item("exam2") = .Item("CEXA2")
                dr.Item("exam3") = .Item("CEXA3")
                dr.Item("exam4") = .Item("CEXA4")
                dr.Item("exam5") = .Item("CEXA5")
              Else
                dr.Item("excd1") = .Item("EXCD1")
                dr.Item("excd2") = .Item("EXCD2")
                dr.Item("excd3") = .Item("EXCD3")
                dr.Item("excd4") = .Item("EXCD4")
                dr.Item("excd5") = .Item("EXCD5")
                dr.Item("exam1") = .Item("EXAM1")
                dr.Item("exam2") = .Item("EXAM2")
                dr.Item("exam3") = .Item("EXAM3")
                dr.Item("exam4") = .Item("EXAM4")
                dr.Item("exam5") = .Item("EXAM5")
              End If
            End With
            ds.Tables(0).Rows.Add(dr)
          End If
        Next
      End With

ShowPct:
      With myFrmProgress
        WrkPct = (Counter / 10) Mod 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .LblMsg.Text = "Records processed: " & Counter
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
        GoTo ReadNext
      End With
    End If

    myFrmProgress.Close()
    myTXMVDQ.CloseFile()
  End Sub
End Module
