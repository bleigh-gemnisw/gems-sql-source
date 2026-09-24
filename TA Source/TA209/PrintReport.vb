Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALQ As TXREALQ.myData

Dim ds As DataSet = New DataSet
Dim DsTXREAL As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkFrom As Integer
Dim WrkTo As Integer

  Public Sub PrtReport()

    myTXREALQ = New TXREALQ.myData(MyDBConnect)

    With MyFrmTA209B
      WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
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
    MyCrViewer.Show()

  End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Cat", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("PurDate", Type.GetType("System.DateTime"))
      .Columns.Add("ExCd1", Type.GetType("System.String"))
      .Columns.Add("ExAm1", Type.GetType("System.Int32"))
      .Columns.Add("ExCd2", Type.GetType("System.String"))
      .Columns.Add("ExAm2", Type.GetType("System.Int32"))
      .Columns.Add("ExCd3", Type.GetType("System.String"))
      .Columns.Add("ExAm3", Type.GetType("System.Int32"))
      .Columns.Add("ExCd4", Type.GetType("System.String"))
      .Columns.Add("ExAm4", Type.GetType("System.Int32"))
      .Columns.Add("ExCd5", Type.GetType("System.String"))
      .Columns.Add("ExAm5", Type.GetType("System.Int32"))
      .Columns.Add("ExCd6", Type.GetType("System.String"))
      .Columns.Add("ExAm6", Type.GetType("System.Int32"))
      .Columns.Add("ExCd7", Type.GetType("System.String"))
      .Columns.Add("ExAm7", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)
  End Sub

  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim I As Integer
    Dim WrkAnd As String

    If MyDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkSort = "PURDT, LIST#"
    WrkQry = "PURDT >= " & WrkFrom & WrkAnd & "PURDT <= " & WrkTo

    'The checkbox only limits which parcels are selected.
    'Exemption fields are always passed to the report and printed when populated.
    If MyFrmTA209B.ChkExemptionsOnly.Checked Then
      WrkQry = WrkQry & WrkAnd & "(EXCD1 > '' OR EXCD2 > '' OR EXCD3 > '' OR EXCD4 > '' OR EXCD5 > '' OR EXCD6 > '' OR EXCD7 > '')"
    End If

    DsTXREAL = myTXREALQ.GetQry(WrkSort, WrkQry, 0)
    If DsTXREAL.Tables(0).Rows.Count = 0 Then GoTo CloseFiles

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (DsTXREAL.Tables(0).Rows.Count - 1)
      If MyReportCancel Then GoTo CloseFiles

      dr = ds.Tables(0).NewRow
      With DsTXREAL.Tables(0).Rows(I)
        dr.Item("Cat") = Trim(.Item("CAT").ToString)
        dr.Item("ListNo") = .Item("LIST#")
        dr.Item("Name") = Trim(.Item("NAME").ToString)
        dr.Item("PurDate") = MyUtils.GetDBDate(.Item("PURDT"))
        dr.Item("ExCd1") = Trim(.Item("EXCD1").ToString)
        dr.Item("ExAm1") = .Item("EXAM1")
        dr.Item("ExCd2") = Trim(.Item("EXCD2").ToString)
        dr.Item("ExAm2") = .Item("EXAM2")
        dr.Item("ExCd3") = Trim(.Item("EXCD3").ToString)
        dr.Item("ExAm3") = .Item("EXAM3")
        dr.Item("ExCd4") = Trim(.Item("EXCD4").ToString)
        dr.Item("ExAm4") = .Item("EXAM4")
        dr.Item("ExCd5") = Trim(.Item("EXCD5").ToString)
        dr.Item("ExAm5") = .Item("EXAM5")
        dr.Item("ExCd6") = Trim(.Item("EXCD6").ToString)
        dr.Item("ExAm6") = .Item("EXAM6")
        dr.Item("ExCd7") = Trim(.Item("EXCD7").ToString)
        dr.Item("ExAm7") = .Item("EXAM7")
      End With
      ds.Tables(0).Rows.Add(dr)

      With myFrmProgress
        If DsTXREAL.Tables(0).Rows.Count > 1 Then
          WrkPct = ((I + 1) / DsTXREAL.Tables(0).Rows.Count) * 100
          If SavePct <> WrkPct Then
            .ProgBar1.Value = WrkPct
            .Refresh()
            SavePct = WrkPct
            Application.DoEvents()
          End If
        End If
      End With
    Next

    myFrmProgress.Close()

CloseFiles:
    myTXREALQ.CloseFile()
  End Sub
End Module
