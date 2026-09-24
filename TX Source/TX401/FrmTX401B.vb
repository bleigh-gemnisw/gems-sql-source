Imports System.Data
Public Class FrmTX401B
  Inherits System.Windows.Forms.Form
	Dim myTXRELCL2 As TXRELCL2.myData
	Dim myTXRELCL1 As TXRELCL1.myData
	Dim myTXPRPCL2 As TXPRPCL2.myData
	Dim myTXMVDCL5 As TXMVDCL5.myData
	Dim myTXPPRPC As TXPPRPC.myData
	Dim myTXMVDC As TXMVDC.MyData
  Dim myTXSUPPCL5 As TXSUPPCL5.MyData
  Dim ds As DataSet = New DataSet
	Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
	Friend WithEvents Gbsort As System.Windows.Forms.GroupBox
	Friend WithEvents RbView2 As System.Windows.Forms.RadioButton
	Friend WithEvents RbView1 As System.Windows.Forms.RadioButton
	Friend WithEvents TxtPosNo As System.Windows.Forms.TextBox
	Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
	Friend WithEvents TbMain As System.Windows.Forms.ToolBar
	Friend WithEvents TbarProcess As System.Windows.Forms.ToolBarButton
	Dim WrkTxType As String

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
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents BtnFast As System.Windows.Forms.Button
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents groupbox1 As System.Windows.Forms.GroupBox
	Friend WithEvents RbSU As System.Windows.Forms.RadioButton
	Friend WithEvents RbMV As System.Windows.Forms.RadioButton
	Friend WithEvents RbPP As System.Windows.Forms.RadioButton
	Friend WithEvents RbRE As System.Windows.Forms.RadioButton
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents BtnFind As System.Windows.Forms.Button
	Friend WithEvents TxtPos As System.Windows.Forms.TextBox
	Friend WithEvents BtnNext As System.Windows.Forms.Button
Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTX401B))
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.BtnFast = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.groupbox1 = New System.Windows.Forms.GroupBox()
    Me.RbSU = New System.Windows.Forms.RadioButton()
    Me.RbMV = New System.Windows.Forms.RadioButton()
    Me.RbPP = New System.Windows.Forms.RadioButton()
    Me.RbRE = New System.Windows.Forms.RadioButton()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.Gbsort = New System.Windows.Forms.GroupBox()
    Me.RbView2 = New System.Windows.Forms.RadioButton()
    Me.RbView1 = New System.Windows.Forms.RadioButton()
    Me.TxtPosNo = New System.Windows.Forms.TextBox()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TbarProcess = New System.Windows.Forms.ToolBarButton()
    Me.GroupBox2.SuspendLayout()
    Me.groupbox1.SuspendLayout()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Gbsort.SuspendLayout()
    Me.SuspendLayout()
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.TxtListNo)
    Me.GroupBox2.Controls.Add(Me.BtnFast)
    Me.GroupBox2.Controls.Add(Me.Label2)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(520, 12)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(177, 48)
    Me.GroupBox2.TabIndex = 26
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Fast Path"
    '
    'TxtListNo
    '
    Me.TxtListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtListNo.Location = New System.Drawing.Point(46, 13)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(57, 20)
    Me.TxtListNo.TabIndex = 4
    '
    'BtnFast
    '
    Me.BtnFast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFast.Location = New System.Drawing.Point(109, 13)
    Me.BtnFast.Name = "BtnFast"
    Me.BtnFast.Size = New System.Drawing.Size(53, 24)
    Me.BtnFast.TabIndex = 3
    Me.BtnFast.Text = "S&how"
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(8, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(32, 16)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "List#"
    '
    'groupbox1
    '
    Me.groupbox1.Controls.Add(Me.RbSU)
    Me.groupbox1.Controls.Add(Me.RbMV)
    Me.groupbox1.Controls.Add(Me.RbPP)
    Me.groupbox1.Controls.Add(Me.RbRE)
    Me.groupbox1.Location = New System.Drawing.Point(8, 8)
    Me.groupbox1.Name = "groupbox1"
    Me.groupbox1.Size = New System.Drawing.Size(464, 32)
    Me.groupbox1.TabIndex = 25
    Me.groupbox1.TabStop = False
    '
    'RbSU
    '
    Me.RbSU.Location = New System.Drawing.Point(344, 8)
    Me.RbSU.Name = "RbSU"
    Me.RbSU.Size = New System.Drawing.Size(112, 16)
    Me.RbSU.TabIndex = 7
    Me.RbSU.Text = "S&upplemental MV"
    '
    'RbMV
    '
    Me.RbMV.Location = New System.Drawing.Point(232, 8)
    Me.RbMV.Name = "RbMV"
    Me.RbMV.Size = New System.Drawing.Size(96, 16)
    Me.RbMV.TabIndex = 6
    Me.RbMV.Text = "&Motor Vehicle"
    '
    'RbPP
    '
    Me.RbPP.Location = New System.Drawing.Point(104, 8)
    Me.RbPP.Name = "RbPP"
    Me.RbPP.Size = New System.Drawing.Size(120, 16)
    Me.RbPP.TabIndex = 5
    Me.RbPP.Text = "P&ersonal Property"
    '
    'RbRE
    '
    Me.RbRE.Checked = True
    Me.RbRE.Location = New System.Drawing.Point(8, 8)
    Me.RbRE.Name = "RbRE"
    Me.RbRE.Size = New System.Drawing.Size(88, 16)
    Me.RbRE.TabIndex = 4
    Me.RbRE.TabStop = True
    Me.RbRE.Text = "&Real Estate"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(23, 51)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 16)
    Me.Label1.TabIndex = 24
    Me.Label1.Text = "Position To"
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(307, 46)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 20
    Me.BtnFind.Text = "&Find"
    '
    'TxtPos
    '
    Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPos.Location = New System.Drawing.Point(135, 48)
    Me.TxtPos.MaxLength = 20
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(162, 20)
    Me.TxtPos.TabIndex = 19
    '
    'BtnNext
    '
    Me.BtnNext.Location = New System.Drawing.Point(363, 46)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(53, 24)
    Me.BtnNext.TabIndex = 27
    Me.BtnNext.Text = "Ne&xt"
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColSelect = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AlternatingRows = True
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(8, 118)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    Me.C1DataGrdList.Size = New System.Drawing.Size(714, 339)
    Me.C1DataGrdList.TabIndex = 195
    '
    'Gbsort
    '
    Me.Gbsort.Controls.Add(Me.RbView2)
    Me.Gbsort.Controls.Add(Me.RbView1)
    Me.Gbsort.Location = New System.Drawing.Point(26, 74)
    Me.Gbsort.Name = "Gbsort"
    Me.Gbsort.Size = New System.Drawing.Size(264, 38)
    Me.Gbsort.TabIndex = 196
    Me.Gbsort.TabStop = False
    '
    'RbView2
    '
    Me.RbView2.Location = New System.Drawing.Point(131, 16)
    Me.RbView2.Name = "RbView2"
    Me.RbView2.Size = New System.Drawing.Size(104, 16)
    Me.RbView2.TabIndex = 24
    Me.RbView2.Text = "&Loc#/Location"
    '
    'RbView1
    '
    Me.RbView1.Checked = True
    Me.RbView1.Location = New System.Drawing.Point(12, 16)
    Me.RbView1.Name = "RbView1"
    Me.RbView1.Size = New System.Drawing.Size(104, 16)
    Me.RbView1.TabIndex = 23
    Me.RbView1.TabStop = True
    Me.RbView1.Text = "&Owner's Name"
    '
    'TxtPosNo
    '
    Me.TxtPosNo.Location = New System.Drawing.Point(93, 48)
    Me.TxtPosNo.MaxLength = 7
    Me.TxtPosNo.Name = "TxtPosNo"
    Me.TxtPosNo.Size = New System.Drawing.Size(41, 20)
    Me.TxtPosNo.TabIndex = 18
    Me.TxtPosNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    Me.TxtPosNo.Visible = False
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    Me.ImageList1.Images.SetKeyName(1, "select type_24.png")
    '
    'TbMain
    '
    Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TbarProcess})
    Me.TbMain.ButtonSize = New System.Drawing.Size(150, 22)
    Me.TbMain.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.TbMain.DropDownArrows = True
    Me.TbMain.ImageList = Me.ImageList1
    Me.TbMain.Location = New System.Drawing.Point(0, 461)
    Me.TbMain.Name = "TbMain"
    Me.TbMain.ShowToolTips = True
    Me.TbMain.Size = New System.Drawing.Size(734, 36)
    Me.TbMain.TabIndex = 197
    Me.TbMain.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
    '
    'TbarProcess
    '
    Me.TbarProcess.ImageIndex = 0
    Me.TbarProcess.Name = "TbarProcess"
    Me.TbarProcess.Text = "Process Selected Items"
    '
    'FrmTX401B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(734, 497)
    Me.ControlBox = False
    Me.Controls.Add(Me.TbMain)
    Me.Controls.Add(Me.TxtPosNo)
    Me.Controls.Add(Me.Gbsort)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.Controls.Add(Me.BtnNext)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.groupbox1)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnFind)
    Me.Controls.Add(Me.TxtPos)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Name = "FrmTX401B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.groupbox1.ResumeLayout(False)
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Gbsort.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

	Private Sub FrmTX401B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

		myTXRELCL2 = New TXRELCL2.mydata(MyDBConnect)
		myTXPPRPC = New TXPPRPC.mydata(MyDBConnect)
		myTXMVDC = New TXMVDC.mydata(MyDBConnect)
    myTXSUPPCL5 = New TXSUPPCL5.MyData(myDBConnect)
    myTXPRPCL2 = New TXPRPCL2.mydata(MyDBConnect)
		myTXMVDCL5 = New TXMVDCL5.mydata(MyDBConnect)
		myTXRELCL1 = New TXRELCL1.mydata(MyDBConnect)

		WrkTxType = "R"
		Call FormatGrid(False)

	End Sub
	Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
		Call FormatGrid(False)
	End Sub
Private Sub BtnScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	Call FormatGrid(True)
End Sub

	Public Sub FormatGrid(ByVal Scan As Boolean)

		Call ShowGrid()

		With C1DataGrdList
			.Rebind(True)
			.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
			.Columns(0).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
			.Columns(0).ValueItems.Values.Clear()
			.Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(0, False)) ' unchecked
			.Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(1, True))	' checked
			.Columns(0).ValueItems.Translate = True
			.Columns(0).Caption = "Select"
			.Splits(0).DisplayColumns(0).Width = 40
			.Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
			.Columns(1).Caption = "List No"
			.Splits(0).DisplayColumns(1).Width = 45
		End With

		If RbRE.Checked Then
			If RbView1.Checked Then
				GridNameLoc()
			End If
			If RbView2.Checked Then
				GridLocName()
			End If
		End If
		If RbPP.Checked Then
			 GridNameLoc()
		End If
		If RbMV.Checked Then
			 GridNameMV()
		End If
		If RbSU.Checked Then
			 GridNameMV()
		End If

	End Sub
  Public Sub ShowGrid()
    Dim WrkPos As String
    Dim WrkPosNo As String
    Dim WrkListNo As Integer

    WrkPosNo = MyUtils.JustifyRight(TxtPosNo.Text, 7)
    WrkPos = Replace(TxtPos.Text, "'", "''")
    WrkListNo = 0

    Select Case WrkTxType
      Case "M"
        ds = myTXMVDCL5.GetViewgrid(WrkPos, cMax)
      Case "P"
        ds = myTXPRPCL2.GetViewgrid(WrkPos, cMax)
      Case "R"
        If RbView1.Checked Then
          ds = myTXRELCL2.GetViewgrid(WrkPos, cMax)
        End If
        If RbView2.Checked Then
          ds = myTXRELCL1.GetViewgrid(WrkPos, WrkPosNo, cMax)
        End If
      Case "S"
        ds = myTXSUPPCL5.GetViewgrid(WrkPos, cMax)
    End Select
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

  End Sub

  Private Sub FrmTX401B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
		MyFrmTX401.SbpScreen.Text = "TX401B"
    MyUtils.CenterForm(Me.ParentForm, Me)

	End Sub
	Private Sub GridNameLoc()
		Dim I As Integer
		With C1DataGrdList
			.Rebind(True)
			For I = 1 To 5
				.Splits(0).DisplayColumns(I).Locked = True
			Next
			.Columns(2).Caption = "Owner Name"
			.Splits(0).DisplayColumns(2).Width = 230
			.Columns(3).Caption = "Loc No"
			.Splits(0).DisplayColumns(3).Width = 45
			.Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
			.Columns(4).Caption = "Location"
			.Splits(0).DisplayColumns(4).Width = 150
			.Columns(5).Caption = "Second Name"
			.Splits(0).DisplayColumns(5).Width = 150
		End With

End Sub
Private Sub GridLocName()
		Dim I As Integer
		With C1DataGrdList
			.Rebind(True)
			For I = 1 To 6
				.Splits(0).DisplayColumns(I).Locked = True
			Next
			.Columns(2).Caption = "Loc No"
			.Splits(0).DisplayColumns(2).Width = 45
			.Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
			.Columns(3).Caption = "Location"
			.Splits(0).DisplayColumns(3).Width = 150
			.Columns(4).Caption = "Unit No"
			.Splits(0).DisplayColumns(4).Width = 50
			.Columns(5).Caption = "Owner Name"
			.Splits(0).DisplayColumns(5).Width = 250
			.Columns(6).Caption = "Second Name"
			.Splits(0).DisplayColumns(6).Width = 150
		End With

End Sub
Private Sub GridNameMV()
		Dim I As Integer
		With C1DataGrdList
			.Rebind(True)
			For I = 1 To 6
				.Splits(0).DisplayColumns(I).Locked = True
			Next
			.Columns(2).Caption = "Owner Name"
			.Splits(0).DisplayColumns(2).Width = 230
			.Columns(3).Caption = "Make"
			.Splits(0).DisplayColumns(3).Width = 50
			.Columns(4).Caption = "Year"
			.Splits(0).DisplayColumns(4).Width = 50
			.Columns(5).Caption = "Model"
			.Splits(0).DisplayColumns(5).Width = 80
			.Columns(6).Caption = "Second Name"
      .Splits(0).DisplayColumns(6).Width = 150
      'MK 9/29/25 Begin
      'If RbSU.Checked Then
      '  .Splits(0).DisplayColumns(7).Visible = False
      'End If
      'MK 9/29/25 End
    End With

  End Sub

	Private Sub RbRE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbRE.Click
	 If WrkTxType <> "" Then
		 WrkTxType = "R"
			Gbsort.Visible = True

		 Call FormatGrid(False)

	 End If

	End Sub
	Private Sub RbPP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPP.Click
		If IsNothing(WrkTxType) Then Exit Sub
		WrkTxType = "P"
		TxtPosNo.Visible = False
		Gbsort.Visible = False
		Call FormatGrid(False)
	End Sub
	Private Sub RbMV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbMV.Click
		If IsNothing(WrkTxType) Then Exit Sub
		WrkTxType = "M"
		Gbsort.Visible = False
		TxtPosNo.Visible = False
		Call FormatGrid(False)

	End Sub
	Private Sub RbSU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbSU.Click
		If IsNothing(WrkTxType) Then Exit Sub
		WrkTxType = "S"
		Gbsort.Visible = False
		TxtPosNo.Visible = False
		Call FormatGrid(False)

	End Sub
	Private Sub BtnFast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFast.Click
		ShowFastPath()
	End Sub
	Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
		Dim I As Integer
		I = ds.Tables(0).Rows.Count - 1

		If TxtPosNo.Visible Then
			TxtPosNo.Text = C1DataGrdList.Item(I, 2)
			TxtPos.Text = Trim(C1DataGrdList.Item(I, 3))
		Else
			TxtPos.Text = Trim(C1DataGrdList.Item(I, 2))
		End If
		FormatGrid(False)

	End Sub
Private Sub C1DataGrdList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
		SelGridItems(C1DataGrdList.Item(C1DataGrdList.Row, 1))
		ProcessScreen()
End Sub
Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtPosNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub RbView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbView1.Click
  TxtPosNo.Visible = False
  TxtPos.Text = ""
  TxtPosNo.Text = ""
  FormatGrid(False)
End Sub
Private Sub RbView2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbView2.Click
  TxtPosNo.Visible = False
  TxtPos.Text = ""
  TxtPosNo.Text = ""
  If RbRE.Checked Then
    TxtPosNo.Visible = True
  End If

  FormatGrid(False)

  End Sub

Private Sub TxtListNo_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
  If Asc(e.KeyChar) = Keys.Return Then
    ShowFastPath()
    Exit Sub
  End If

  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub ShowFastPath()
		If TxtListNo.Text = "" Then Exit Sub

    SelGridItems(MyUtils.CnvSng(TxtListNo.Text))
		ProcessScreen()
		TxtListNo.Text = ""
		Me.Hide()
End Sub

Private Sub TxtPos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPos.KeyPress
	If Asc(e.KeyChar) = Keys.Return Then
		FormatGrid(False)
	End If
End Sub
Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
	If e.Button Is TbarProcess Then
		SelGridItems(0)
		ProcessScreen()
	End If
End Sub
Private Sub SelGridItems(ByVal WrkListNo As Integer)

	Dim I As Integer
	Dim J As Integer

	Array.Clear(SelListNo, 0, cMax)

	If WrkListNo > 0 Then
		SelListNo(0) = WrkListNo
		Exit Sub
	End If

	J = 0
	Windows.Forms.Cursor.Current = Cursors.WaitCursor()
	For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
		If C1DataGrdList.Item(I, 0) = 1 Then
			SelListNo(J) = C1DataGrdList.Item(I, 1)
			J = J + 1
		End If
	Next

	Windows.Forms.Cursor.Current = Cursors.Default
End Sub
Private Sub ProcessScreen()
		If RbRE.Checked Then
			MyFrmTX401RE = New FrmTX401RE
			MyFrmTX401RE.MdiParent = Me.ParentForm
			MyFrmTX401RE.Show()
		End If
		If RbPP.Checked Then
			MyFrmTX401PP = New FrmTX401PP
			MyFrmTX401PP.MdiParent = Me.ParentForm
			MyFrmTX401PP.Show()
		End If
		If RbMV.Checked Then
			MyFrmTX401MV = New FrmTX401MV
			MyFrmTX401MV.MdiParent = Me.ParentForm
			MyFrmTX401MV.Show()
		End If
		If RbSU.Checked Then
			MyFrmTX401SU = New FrmTX401SU
			MyFrmTX401SU.MdiParent = Me.ParentForm
			MyFrmTX401SU.Show()
		End If
		TxtListNo.Text = ""
		Me.Hide()
End Sub

Private Sub C1DataGrdList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.Click

End Sub
End Class






