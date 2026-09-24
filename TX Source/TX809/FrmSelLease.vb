Public Class FrmSelLease
  Dim myTXLEASE As TXLEASE.MyData
  Dim ds As DataSet = New DataSet
  Friend WrkCode As String
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    Call FormatGrid()
  End Sub
  Public Sub FormatGrid()

    Call ShowGrid()

    With C1DataGrdList
      .Rebind(True)
      .Columns(0).Caption = "Code"
      .Splits(0).DisplayColumns(0).Width = 40
      .Columns(1).Caption = "Name"
      .Splits(0).DisplayColumns(1).Width = 150
      .Columns(2).Caption = "Address"
      .Splits(0).DisplayColumns(1).Width = 200
      .Splits(0).DisplayColumns(2).Visible = False
    End With
  End Sub
  Public Sub ShowGrid()
    ds = myTXLEASE.PosData(TxtPos.Text)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()
  End Sub
  Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    With MyFrmTX809B
      .TxtLease.Text = C1DataGrdList.Item(C1DataGrdList.Row, 0)
      .Show()
    End With

    Me.Close()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub FrmSelLease_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    myTXLEASE = New TXLEASE.MyData(myDBConnect)
    LblCurrent.Text = "(Lease Code = " & WrkCode & ")"
    FormatGrid()
  End Sub
  Private Sub FrmSelLease_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTX809.SbpScreen.Text = "SelLease"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub FrmSelLease_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    'Memory Cleanup
    MyFrmSelLease = Nothing
  End Sub
End Class






