Public Class FrmTX4042C
    Inherits System.Windows.Forms.Form
    Dim MyTXINV As TXINV.myData

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents TbMain As System.Windows.Forms.ToolBar
  Friend WithEvents TBarUpdate As System.Windows.Forms.ToolBarButton
  Friend WithEvents TxtComment As System.Windows.Forms.TextBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
Friend WithEvents TBarReturn As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTX4042C))
Me.TxtComment = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.TbMain = New System.Windows.Forms.ToolBar
Me.TBarReturn = New System.Windows.Forms.ToolBarButton
Me.TBarUpdate = New System.Windows.Forms.ToolBarButton
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'TxtComment
'
Me.TxtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtComment.Location = New System.Drawing.Point(64, 8)
Me.TxtComment.MaxLength = 20
Me.TxtComment.Name = "TxtComment"
Me.TxtComment.Size = New System.Drawing.Size(128, 20)
Me.TxtComment.TabIndex = 186
'
'Label1
'
Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label1.Location = New System.Drawing.Point(8, 8)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(56, 16)
Me.Label1.TabIndex = 187
Me.Label1.Text = "Comment"
'
'ImageList1
'
Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
Me.ImageList1.TransparentColor = System.Drawing.Color.White
Me.ImageList1.Images.SetKeyName(0, "")
Me.ImageList1.Images.SetKeyName(1, "")
'
'TbMain
'
Me.TbMain.Anchor = System.Windows.Forms.AnchorStyles.Bottom
Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarReturn, Me.TBarUpdate})
Me.TbMain.Dock = System.Windows.Forms.DockStyle.None
Me.TbMain.DropDownArrows = True
Me.TbMain.ImageList = Me.ImageList1
Me.TbMain.Location = New System.Drawing.Point(8, 216)
Me.TbMain.Name = "TbMain"
Me.TbMain.ShowToolTips = True
Me.TbMain.Size = New System.Drawing.Size(168, 50)
Me.TbMain.TabIndex = 191
'
'TBarReturn
'
Me.TBarReturn.ImageIndex = 0
Me.TBarReturn.Name = "TBarReturn"
Me.TBarReturn.Text = "&Return"
'
'TBarUpdate
'
Me.TBarUpdate.ImageIndex = 1
Me.TBarUpdate.Name = "TBarUpdate"
Me.TBarUpdate.Text = "Update &Comment"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'C1DataGrdList
'
Me.C1DataGrdList.AllowUpdate = False
Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
Me.C1DataGrdList.Location = New System.Drawing.Point(8, 32)
Me.C1DataGrdList.Name = "C1DataGrdList"
Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75
Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.C1DataGrdList.Size = New System.Drawing.Size(272, 184)
Me.C1DataGrdList.TabIndex = 193
Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
'
'FrmTX4042C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(290, 272)
Me.Controls.Add(Me.C1DataGrdList)
Me.Controls.Add(Me.TbMain)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.TxtComment)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.KeyPreview = True
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX4042C"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Change Comment"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

  Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
    If e.Button Is TBarReturn Then
      Me.Close()
    End If

    If e.Button Is TBarUpdate Then
      UpdateDS()
    End If
  End Sub
  Private Sub UpdateDS()
    Dim ListNo As Integer
    Dim Year As Integer
    Dim Type As String
    Dim Answer As Integer
    Dim WrkWhere As String
    Dim WrkSet As String
    Dim I As Integer

    If TxtComment.Text = "" Then
      Answer = MsgBox("Click OK to confirm", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Clear all Comments requested")
      If Answer = MsgBoxResult.Cancel Then Exit Sub
    End If

    For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
      ListNo = myds.Tables(0).Rows(I).Item("ListNo")
      Year = myds.Tables(0).Rows(I).Item("Year")
      Type = myds.Tables(0).Rows(I).Item("Type")
      MyTXINV.GetOneRecordP(ListNo, Year, Type)
      With myds.Tables(0).Rows(I)
        myds.Tables(0).Rows(I).Item("ccm") = TxtComment.Text
        MyTXINV._CCM = Replace(TxtComment.Text, "'", "''")
      End With
      WrkWhere = " where list#=" & ListNo & " and year=" & Year & " and type='" & Type & "'"
      WrkSet = " set ccm='" & MyTXINV._CCM & "'"
      MyTXINV.RunUpdateQuery(WrkSet, WrkWhere)
      'MyTXINV.UpdateOneRecordP()
    Next
  End Sub
  Private Sub FrmTX4042C_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		Me.Dispose()
	End Sub
	Private Sub FrmTX4042C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		MyFrmTX404.TBarBack.Enabled = False
		MyFrmTX404.TBarPrint.Enabled = False
		MyFrmTX404.TBarSetPrinter.Enabled = False
		MyFrmTX404.TBarSettings.Enabled = False
		MyTXINV = New TXINV.mydata(MyDBConnect)
		ShowGrid()
	End Sub
		Public Sub ShowGrid()
		 Dim I As Integer
		 Windows.Forms.Cursor.Current = Cursors.WaitCursor

		 With C1DataGrdList
			.DataSource = myds.Tables(0)
			.Refresh()
			.Splits(0).DisplayColumns(0).Visible = False
			.Columns(1).Caption = "List#"
			.Splits(0).DisplayColumns(1).Width = 40
			.Splits(0).DisplayColumns(2).Width = 30
			.Splits(0).DisplayColumns(3).Visible = False
			.Splits(0).DisplayColumns(4).Width = 30
			For I = 5 To 28
				.Splits(0).DisplayColumns(I).Visible = False
			Next
			.Columns(29).Caption = "Comment"
			.Splits(0).DisplayColumns(29).Width = 130
      For I = 30 To 40
        .Splits(0).DisplayColumns(I).Visible = False
      Next
		End With

		Windows.Forms.Cursor.Current = Cursors.Default

		End Sub

  Private Sub FrmTX4042C_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub

  If e.KeyCode = Keys.R Then
    Me.Close()
  End If

  If e.KeyCode = Keys.C Then
    UpdateDS()
  End If
  End Sub
Private Sub FrmTX4042C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
	MyFrmTX404.SbpScreen.Text = "TX4042"
	MyFrmTX404.TBarBack.Enabled = True
	If MyPrinter <> String.Empty Then
		MyFrmTX404.TBarPrint.Enabled = True
	End If
	MyFrmTX404.TBarSetPrinter.Enabled = True
	MyFrmTX404.TBarSettings.Enabled = True
  'Memory Cleanup
  mytxinv = Nothing
  MyFrmTX4042C = Nothing
End Sub
End Class






