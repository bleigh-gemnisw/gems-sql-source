Public Class FrmFastPath
  Inherits System.Windows.Forms.Form
	Dim myGNETRIGHTS As GNETRIGHTS.myData
	Dim ds As DataSet = New DataSet
	Friend WithEvents BtnPopulate As System.Windows.Forms.Button
  Friend WrkCode As String

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
Friend WithEvents TbMain As System.Windows.Forms.ToolBar
Friend WithEvents TBarBack As System.Windows.Forms.ToolBarButton
Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
Friend WithEvents label2 As System.Windows.Forms.Label
Friend WithEvents LblMsg As System.Windows.Forms.Label
Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
Friend WithEvents BtnExecute As System.Windows.Forms.Button
Friend WithEvents TxtProgramID As System.Windows.Forms.TextBox
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFastPath))
Me.TbMain = New System.Windows.Forms.ToolBar
Me.TBarBack = New System.Windows.Forms.ToolBarButton
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.label2 = New System.Windows.Forms.Label
Me.LblMsg = New System.Windows.Forms.Label
Me.BtnExecute = New System.Windows.Forms.Button
Me.TxtProgramID = New System.Windows.Forms.TextBox
Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
Me.BtnPopulate = New System.Windows.Forms.Button
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'TbMain
'
Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarBack})
Me.TbMain.DropDownArrows = True
Me.TbMain.ImageList = Me.ImageList1
Me.TbMain.Location = New System.Drawing.Point(0, 0)
Me.TbMain.Name = "TbMain"
Me.TbMain.ShowToolTips = True
Me.TbMain.Size = New System.Drawing.Size(500, 50)
Me.TbMain.TabIndex = 12
'
'TBarBack
'
Me.TBarBack.ImageIndex = 0
Me.TBarBack.Name = "TBarBack"
Me.TBarBack.Text = "Back"
'
'ImageList1
'
Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
Me.ImageList1.TransparentColor = System.Drawing.Color.White
Me.ImageList1.Images.SetKeyName(0, "")
Me.ImageList1.Images.SetKeyName(1, "")
Me.ImageList1.Images.SetKeyName(2, "")
Me.ImageList1.Images.SetKeyName(3, "")
Me.ImageList1.Images.SetKeyName(4, "")
'
'label2
'
Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.label2.Location = New System.Drawing.Point(12, 60)
Me.label2.Name = "label2"
Me.label2.Size = New System.Drawing.Size(88, 16)
Me.label2.TabIndex = 11
Me.label2.Text = "Program Id"
'
'LblMsg
'
Me.LblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblMsg.Location = New System.Drawing.Point(8, 96)
Me.LblMsg.Name = "LblMsg"
Me.LblMsg.Size = New System.Drawing.Size(312, 16)
Me.LblMsg.TabIndex = 10
Me.LblMsg.Text = "Double click on a program in list to execute"
Me.LblMsg.Visible = False
'
'BtnExecute
'
Me.BtnExecute.Image = CType(resources.GetObject("BtnExecute.Image"), System.Drawing.Image)
Me.BtnExecute.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.BtnExecute.Location = New System.Drawing.Point(204, 52)
Me.BtnExecute.Name = "BtnExecute"
Me.BtnExecute.Size = New System.Drawing.Size(88, 32)
Me.BtnExecute.TabIndex = 8
Me.BtnExecute.Text = "Execute"
'
'TxtProgramID
'
Me.TxtProgramID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtProgramID.Location = New System.Drawing.Point(100, 56)
Me.TxtProgramID.Name = "TxtProgramID"
Me.TxtProgramID.Size = New System.Drawing.Size(96, 20)
Me.TxtProgramID.TabIndex = 7
'
'C1DataGrdList
'
Me.C1DataGrdList.AllowColSelect = False
Me.C1DataGrdList.AllowHorizontalSplit = True
Me.C1DataGrdList.AllowUpdate = False
Me.C1DataGrdList.AllowUpdateOnBlur = False
Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.C1DataGrdList.FilterBar = True
Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Popup
Me.C1DataGrdList.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images1"), System.Drawing.Image))
Me.C1DataGrdList.Location = New System.Drawing.Point(8, 116)
Me.C1DataGrdList.Name = "C1DataGrdList"
Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75
Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.C1DataGrdList.RowDivider.Color = System.Drawing.Color.DarkGray
Me.C1DataGrdList.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Raised
Me.C1DataGrdList.Size = New System.Drawing.Size(488, 356)
Me.C1DataGrdList.TabIndex = 9
Me.C1DataGrdList.Text = "c1TrueDBGrid1"
Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
'
'BtnPopulate
'
Me.BtnPopulate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.BtnPopulate.Location = New System.Drawing.Point(338, 80)
Me.BtnPopulate.Name = "BtnPopulate"
Me.BtnPopulate.Size = New System.Drawing.Size(158, 32)
Me.BtnPopulate.TabIndex = 13
Me.BtnPopulate.Text = "Populate Programs List"
'
'FrmFastPath
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(500, 477)
Me.ControlBox = False
Me.Controls.Add(Me.BtnPopulate)
Me.Controls.Add(Me.label2)
Me.Controls.Add(Me.LblMsg)
Me.Controls.Add(Me.BtnExecute)
Me.Controls.Add(Me.TxtProgramID)
Me.Controls.Add(Me.C1DataGrdList)
Me.Controls.Add(Me.TbMain)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmFastPath"
Me.Text = "Fast Path"
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Public Sub FormatGrid()

    Call ShowGrid()

    With C1DataGrdList
        .Rebind(True)
        .Columns(0).Caption = "Code"
        .Splits(0).DisplayColumns(0).Width = 150
        .Columns(1).Caption = "Description"
        .Splits(0).DisplayColumns(1).Width = 200
        .Columns(2).Caption = "Pgmexe"
        .Splits(0).DisplayColumns(2).Width = 75
    End With

End Sub
Public Sub ShowGrid()
    ds = myGNETRIGHTS.Get_user_pgms(MyUserID)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()
End Sub
Private Sub FrmFastPath_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmMain.SbpScreen.Text = "FastPath"
    MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmFastPath_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    myGNETRIGHTS = New GNETRIGHTS.MyData()
    myGNETRIGHTS.MyDBConn = myDBConnect
    Windows.Forms.Cursor.Current = Cursors.Default
End Sub
Private Sub C1DataGrdList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    LaunchEXE(C1DataGrdList.Item(C1DataGrdList.Row, 2))
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default
End Sub
Private Sub BtnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExecute.Click
  LaunchEXE(TxtProgramID.Text)
End Sub
Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
  If e.Button Is TBarBack Then
    DoBtnBack()
    Exit Sub
  End If
End Sub
Private Sub DoBtnBack()
  Me.Hide()
End Sub

Private Sub BtnPopulate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPopulate.Click
	FormatGrid()
	LblMsg.Visible = True
End Sub
End Class
