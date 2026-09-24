Public Class FrmTAP02LST
  Dim MyTXDMLSTL1 As TXDMLSTL1.myData
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
	Friend WrkYear As Integer
	Friend WrkName As String
Private Sub FrmTAP02LST_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP02
      .TBarNew.Enabled = False
      .TBarDelete.Enabled = True
      .TBarSave.Enabled = True
      .TBarDecl.Enabled = False
			.TBarLst.Enabled = True
			.TBarPrint.Enabled = False
    End With
End Sub
Private Sub FrmTAP02LST_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXDMLSTL1 = New TXDMLSTL1.mydata(MyDBConnect)

    With MyFrmTAP02
      .TBarNew.Enabled = True
      .TBarDelete.Enabled = False
      .TBarSave.Enabled = False
      .TBarDecl.Enabled = True
      .TBarLst.Enabled = False
			.TBarPrint.Enabled = True
		End With

    LblListNo.Text = WrkListNo
		LblYear.Text = WrkYear
		LblName.Text = WrkName

		Call FormatGrid(False)
End Sub
  Private Sub FrmTAP02LST_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP02.SbpScreen.Text = "TAP02LST"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
	Public Sub FormatGrid(ByVal WrkScan As Boolean)
		If Not WrkScan Then
			Call ShowGrid()
		Else
			Call ShowGridScan()
		End If
		With C1DataGrdList
			.Rebind(True)
			.Splits(0).DisplayColumns(0).Visible = False
			.Splits(0).DisplayColumns(1).Visible = False
			.Splits(0).DisplayColumns(2).Visible = False
			.Columns(3).Caption = "Description"
			.Splits(0).DisplayColumns(3).Width = 250
			.Columns(4).Caption = "G/L Year"
			.Splits(0).DisplayColumns(4).Width = 60
			.Columns(5).Caption = "Cost"
			.Splits(0).DisplayColumns(5).Width = 60
		End With
	End Sub
  Public Sub ShowGrid()
		ds = MyTXDMLSTL1.GetViewDesc(WrkListNo, WrkYear, TxtDesc.Text, 100)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

  End Sub
	Public Sub ShowGridScan()
		ds = MyTXDMLSTL1.GetViewDescScan(WrkListNo, WrkYear, TxtDesc.Text, 100)
		C1DataGrdList.DataSource = ds.Tables(0)
		C1DataGrdList.Refresh()

	End Sub
Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
			MyFrmTAP02LST2 = New FrmTAP02LST2
			MyFrmTAP02LST2.MdiParent = MyFrmTAP02B.ParentForm
			MyFrmTAP02LST2.WrkListNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
			MyFrmTAP02LST2.WrkYear = C1DataGrdList.Item(C1DataGrdList.Row, 1)
			MyFrmTAP02LST2.WrkSeqNo = C1DataGrdList.Item(C1DataGrdList.Row, 2)
			MyFrmTAP02LST2.Show()
			MyFrmTAP02LST.Hide()
End Sub
Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
	Call FormatGrid(False)
End Sub
Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
	Dim I As Integer
	I = ds.Tables(0).Rows.Count - 1
	TxtDesc.Text = C1DataGrdList.Item(I, 3)
	FormatGrid(False)
	TxtDesc.Text = ""
End Sub
Private Sub BtnScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnScan.Click
	Call FormatGrid(True)
End Sub
End Class





