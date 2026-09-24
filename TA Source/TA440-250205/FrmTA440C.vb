Imports System.Net.Security
Imports System.Runtime.InteropServices
Imports System.Windows.Forms.VisualStyles
Imports C1.Win.Util.Toolbox
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmTA440C
  Dim ds As DataSet = New DataSet
  Dim mytxmvdq As New TXMVDQ.MyData(myDBConnect)
  Friend wrkclassdesc As String

  Private Sub FrmTA440C_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    TxTSearch.Focus()

    Call FormatGrid()
  End Sub
  Private Sub FrmTA440C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA440.SbpScreen.Text = "TA440C"
    MyUtils.CenterForm(Me.ParentForm, Me)
    TxTSearch.Focus()
  End Sub
  Private Sub FrmTA440C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTA440.TBarProcess.Enabled = True
    MyFrmTA440.TBarPrint.Enabled = False
    MyFrmTA440B.TxtClass.Focus()
    MyFrmTA440B.Show()
  End Sub
  Public Sub FormatGrid()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    Call ShowGrid()

    With C1TrueDBGrid1

      C1TrueDBGrid1.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
      C1TrueDBGrid1.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Extended
      C1TrueDBGrid1.MultiSelect = True


      ' Set alternating row styles
      .AlternatingRows = True
      .Styles("EvenRow").BackColor = Color.Lavender
      .RowHeight = 15


      ' Customize columns
      .Columns("listno").Caption = "List No"
      .Splits(0).DisplayColumns("listno").Width = 50
      .Columns("name").Caption = "Name"
      .Splits(0).DisplayColumns("name").Width = 250
      .Columns("year").Caption = "Year"
      .Splits(0).DisplayColumns("year").Width = 40
      .Columns("class").Caption = "Class"
      .Splits(0).DisplayColumns("class").Width = 35
      .Columns("make").Caption = "Make"
      .Splits(0).DisplayColumns("make").Width = 40
      .Columns("model").Caption = "Model"
      .Splits(0).DisplayColumns("model").Width = 50
      .Columns("vinno").Caption = "Vin No"
      .Splits(0).DisplayColumns("vinno").Width = 150
      .Columns("gwt").Caption = "Gross Weight"
      .Splits(0).DisplayColumns("gwt").Width = 75
      .Columns("lwt").Caption = "Light Weight"
      .Splits(0).DisplayColumns("lwt").Width = 75


    End With

    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Public Sub ShowGrid()
    Dim wrkqry As String
    Dim wrkclass As Integer
    Dim wrkgross As Integer
    Dim wrkmake As String
    Dim wrksortfield As String
    Dim dt As New DataTable("mytable")
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    wrkclass = MyUtils.CnvSng(MyFrmTA440B.TxtClass.Text)
    wrkgross = MyUtils.CnvSng(MyFrmTA440B.TxtGross.Text)
    wrkmake = UCase(MyFrmTA440B.TxtMake.Text)
    wrksortfield = wrksort
    wrkqry = "cat <> '2' AND class =  " & wrkclass
    If wrkmake <> "" Then
      wrkqry = wrkqry & " AND make = '" & wrkmake & "'"
    End If
    If wrkgross > 0 Then
      wrkqry = wrkqry & " AND gwt <= " & wrkgross
    End If
    If MyFrmTA440B.ChkZero.Checked Then
      wrkqry = wrkqry & " AND value=0"
    End If
    'wrkfields2 = "listno,name,year,class,make,model,vinno,gwt,lwt"
    mytxmvdq.OpenQry(wrksortfield, wrkqry)

    ' Define the DataTable structure based on wrkfields
    ' Dim fields() As String = wrkfields2.Split(","c)
    ' For Each field As String In fields
    'dt.Columns.Add(field.Trim(), GetType(String))
    ' Next
    dt = BuildDT()
    ds.Tables.Add(dt)

    ' Populate the DataTable
ReadNext:
    mytxmvdq.ReadQry()
    If Not mytxmvdq.IsEOF Then
      With mytxmvdq
        Dim row As DataRow = dt.NewRow()
        'For Each field As String In fields
        row("listno") = ._LISTNo
        row("name") = ._NAME
        row("year") = ._YEAR
        row("class") = ._CLASS
        row("make") = ._MAKE
        row("model") = ._MODEL
        row("vinno") = ._VINNO
        row("gwt") = ._GWT
        row("lwt") = ._LWT
        'Next
        dt.Rows.Add(row)
      End With
      GoTo ReadNext
    End If

    ' Bind the DataTable to the grid
    C1TrueDBGrid1.DataSource = dt
    C1TrueDBGrid1.Refresh()
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Private Function BuildDT() As DataTable

    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("year", Type.GetType("System.Int32"))
      .Columns.Add("class", Type.GetType("System.Int32"))
      .Columns.Add("make", Type.GetType("System.String"))
      .Columns.Add("model", Type.GetType("System.String"))
      .Columns.Add("vinno", Type.GetType("System.String"))
      .Columns.Add("lwt", Type.GetType("System.Int32"))
      .Columns.Add("gwt", Type.GetType("System.Int32"))

    End With

    Return myTable
  End Function


  Private Sub C1TrueDBGrid1_DoubleClick(sender As Object, e As EventArgs) Handles C1TrueDBGrid1.DoubleClick
    Try
      ' Get the DataTable bound to the grid
      Dim dt As DataTable = CType(C1TrueDBGrid1.DataSource, DataTable)

      ' Get the currently selected row index
      Dim selectedRowIndex As Integer = C1TrueDBGrid1.Row

      ' Ensure the selected row index is valid
      If selectedRowIndex >= 0 And selectedRowIndex < dt.Rows.Count Then
        ' Delete the selected row
        dt.Rows(selectedRowIndex).Delete()
        dt.AcceptChanges()

        ' Notify the user (optional)
        MessageBox.Show("Row deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
    Catch ex As Exception
      ' Handle potential errors
      MessageBox.Show($"Error deleting row: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub
  Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles BtnFind.Click
    Dim searchText As String = TxTSearch.Text.Trim()
    Dim found As Boolean = False

    If String.IsNullOrEmpty(searchText) Then
      MessageBox.Show("Please enter a search term.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Return
    End If

    ' Loop through rows and columns to find the search text
    For rowIndex As Integer = 0 To C1TrueDBGrid1.RowCount - 1
      For colIndex As Integer = 0 To C1TrueDBGrid1.Columns.Count - 1
        Dim cellValue As String = C1TrueDBGrid1(rowIndex, colIndex)?.ToString()
        If Not String.IsNullOrEmpty(cellValue) AndAlso cellValue.ToLower().Contains(searchText.ToLower()) Then
          ' Highlight the matching cell
          C1TrueDBGrid1.Row = rowIndex
          C1TrueDBGrid1.Col = colIndex
          found = True
          Exit For
        End If
      Next
      If found Then Exit For
    Next

    ' Notify if no match is found
    If Not found Then
      MessageBox.Show("No matching text found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End If
  End Sub

  Public Sub RunReport()
    Dim reportDataSet As New DataSet()
    Dim originalDataTable As DataTable = CType(C1TrueDBGrid1.DataSource, DataTable)
    Dim filteredDataTable As DataTable = originalDataTable.Clone() ' Clone the structure

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    '===================================
    If ChkPost.Checked Then
      ' Show confirmation message
      Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to post the records as Non-Tax?",
            "Confirm Action",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )

      If result = DialogResult.No Then
        ' User canceled the action; exit the routine
        MessageBox.Show("Action canceled. Records were not posted.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return
      End If
    End If



    '=====================================

    ' Filter non-deleted rows
    For Each row As DataRow In originalDataTable.Rows
      If row.RowState <> DataRowState.Deleted Then
        filteredDataTable.ImportRow(row) ' Copy only non-deleted rows
      End If
    Next

    ' Wrap the DataTable in a DataSet (if required for Crystal Reports)

    reportDataSet.Tables.Add(filteredDataTable)



    PrtReport(reportDataSet, wrkclassdesc)
    Windows.Forms.Cursor.Current = Cursors.Default

    If ChkPost.Checked = True Then
      Me.Close()
    End If


  End Sub

  Private Sub TxTSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles TxTSearch.KeyDown
    If e.KeyCode = Keys.Enter Then
      ' Simulate the button click
      BtnFind.PerformClick()

      ' Prevent the default Enter key behavior (e.g., form submission)
      e.SuppressKeyPress = True
    End If
  End Sub
  Private Sub btnDelete_Click(sender As Object, e As EventArgs)
    ' Get the underlying DataTable
    Dim dt As DataTable = CType(C1TrueDBGrid1.DataSource, DataTable)

    ' Collect selected rows
    Dim selectedRows As List(Of Integer) = New List(Of Integer)()
    Dim rowIndex As Integer

    ' Use SelectedRows property to identify selected rows
    For Each selectedRow As Integer In C1TrueDBGrid1.SelectedRows
      rowIndex = C1TrueDBGrid1.RowBookmark(selectedRow)
      selectedRows.Add(rowIndex)
    Next

    ' Confirm deletion
    If selectedRows.Count > 0 Then
      Dim result As DialogResult = MessageBox.Show(
            $"Are you sure you want to delete {selectedRows.Count} row(s)?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )

      If result = DialogResult.Yes Then
        ' Loop through selected rows in reverse order to avoid index shifting
        For i As Integer = selectedRows.Count - 1 To 0 Step -1
          dt.Rows(selectedRows(i)).Delete()
        Next

        ' Accept changes to commit deletions
        dt.AcceptChanges()

        ' Refresh the grid
        C1TrueDBGrid1.Refresh()
        MessageBox.Show($"{selectedRows.Count} row(s) deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
    Else
      MessageBox.Show("No rows selected for deletion.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End If
  End Sub


End Class