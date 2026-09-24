Public Class FrmInvDetail
  Dim myTXINVDTL As TXINVDTL.MyData
  Dim ds As DataSet = New DataSet
  Dim mydstxinvdtl As DataSet = New DataSet

  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkType As String

  Private Sub FrmInvDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    myTXINVDTL = New TXINVDTL.MyData(myDBConnect)
    BuildDs()
    RefreshDS()
    Call FormatGrid()
  End Sub
  Private Sub FrmInvDetail_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA09.SbpScreen.Text = "InvDetail"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub FrmInvDetail_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    'Memory Cleanup
    myTXINVDTL = Nothing
    MyFrmInvDetail = Nothing
  End Sub
  Public Sub FormatGrid()

    Dim I As Integer

    Call ShowGrid()
    With C1DataGrdList
      .Rebind(True)
      .Columns(0).Caption = "Period"
      .Splits(0).DisplayColumns(0).Width = 40
      .Columns(1).Caption = "Code"
      .Splits(0).DisplayColumns(1).Width = 40
      .Columns(2).Caption = "Amount"
      .Splits(0).DisplayColumns(2).Width = 150
      For I = 0 To 2
        .Splits(0).DisplayColumns(I).Locked = True
      Next
    End With
  End Sub
  Public Sub ShowGrid()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    C1DataGrdList.DataSource = mydstxinvdtl.Tables(0)
    C1DataGrdList.Refresh()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Period", Type.GetType("System.Int32"))
      .Columns.Add("Code", Type.GetType("System.String"))
      .Columns.Add("Amount", Type.GetType("System.Decimal"))
    End With
    mydstxinvdtl.Tables.Add(myTable)
  End Sub
  Private Sub RefreshDS()
    Dim myDr As Data.DataRow
    Dim I As Integer

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    ds = myTXINVDTL.GetAllLisYearType(WrkListNo, WrkYear, WrkType)
    For I = 0 To ds.Tables(0).Rows.Count - 1
      myDr = mydstxinvdtl.Tables(0).NewRow
      myDr("Period") = ds.Tables(0).Rows(I).Item("perd")
      myDr("Code") = ds.Tables(0).Rows(I).Item("code")
      myDr("Amount") = ds.Tables(0).Rows(I).Item("amount")
      mydstxinvdtl.Tables(0).Rows.Add(myDr)
    Next
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
End Class