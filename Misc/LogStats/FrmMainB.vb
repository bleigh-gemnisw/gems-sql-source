Public Class FrmMainB
Friend WrkDescr As String
Private Sub FrmMainB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
  Dim WrkSelect As String
  Dim drSel() As DataRow
  Dim dr As DataRow
  Dim dsSel As DataSet = New DataSet
  Dim I As Integer
  dsSel = dsDtl.Clone
  Windows.Forms.Cursor.Current = Cursors.WaitCursor

  WrkSelect = "descr='" & WrkDescr & "'"
  drSel = dsDtl.Tables(0).Select(WrkSelect)
  LblDescr.Text = drSel(0).Item("descr")
  For I = 0 To drSel.GetUpperBound(0) - 1
    dr = dsSel.Tables(0).NewRow
    dr("Descr") = drSel(I).Item("descr")
    dr("Program") = drSel(I).Item("program")
    dr("User") = drSel(I).Item("user")
    dr("Date") = drSel(I).Item("date")
    dsSel.Tables(0).Rows.Add(dr)
  Next

  With C1DataGrdList
    .DataSource = dsSel.Tables(0)
    .Refresh()
    .Rebind(True)
    .Splits(0).DisplayColumns(0).Visible = False
    .Splits(0).DisplayColumns(1).Width = 70
    .Splits(0).DisplayColumns(2).Width = 100
    .Splits(0).DisplayColumns(3).Width = 150
  End With
  Windows.Forms.Cursor.Current = Cursors.Default
End Sub

End Class