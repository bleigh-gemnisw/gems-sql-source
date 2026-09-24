Public Class FrmTX4041B
 Inherits System.Windows.Forms.Form
 Dim WrkName As String
 Dim WrkSName As String
 Dim WrkAdd1 As String
 Dim WrkAdd2 As String
 Dim WrkCity As String
 Dim WrkState As String
 Dim WrkZip5 As String
 Dim WrkZip4 As String

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
  Friend WithEvents LblAdd2 As System.Windows.Forms.Label
  Friend WithEvents LblAdd1 As System.Windows.Forms.Label
  Friend WithEvents LblSname As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents LblName As System.Windows.Forms.Label
  Friend WithEvents label1 As System.Windows.Forms.Label
Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
Friend WithEvents TbMain As System.Windows.Forms.ToolBar
Friend WithEvents TBarReturn As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarSep1 As System.Windows.Forms.ToolBarButton
Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
Friend WithEvents LblCity As System.Windows.Forms.Label
Friend WithEvents LblState As System.Windows.Forms.Label
Friend WithEvents LblZip5 As System.Windows.Forms.Label
Friend WithEvents LblZip4 As System.Windows.Forms.Label
Friend WithEvents BtnClearAddr As System.Windows.Forms.Button
Friend WithEvents TBarAccept As System.Windows.Forms.ToolBarButton
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTX4041B))
Me.LblAdd2 = New System.Windows.Forms.Label
Me.LblAdd1 = New System.Windows.Forms.Label
Me.LblSname = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
Me.LblName = New System.Windows.Forms.Label
Me.label1 = New System.Windows.Forms.Label
Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
Me.TbMain = New System.Windows.Forms.ToolBar
Me.TBarReturn = New System.Windows.Forms.ToolBarButton
Me.TBarSep1 = New System.Windows.Forms.ToolBarButton
Me.TBarAccept = New System.Windows.Forms.ToolBarButton
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.LblCity = New System.Windows.Forms.Label
Me.LblState = New System.Windows.Forms.Label
Me.LblZip5 = New System.Windows.Forms.Label
Me.LblZip4 = New System.Windows.Forms.Label
Me.BtnClearAddr = New System.Windows.Forms.Button
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'LblAdd2
'
Me.LblAdd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblAdd2.Location = New System.Drawing.Point(72, 61)
Me.LblAdd2.Name = "LblAdd2"
Me.LblAdd2.Size = New System.Drawing.Size(216, 16)
Me.LblAdd2.TabIndex = 186
'
'LblAdd1
'
Me.LblAdd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblAdd1.Location = New System.Drawing.Point(72, 40)
Me.LblAdd1.Name = "LblAdd1"
Me.LblAdd1.Size = New System.Drawing.Size(216, 16)
Me.LblAdd1.TabIndex = 185
'
'LblSname
'
Me.LblSname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblSname.Location = New System.Drawing.Point(72, 24)
Me.LblSname.Name = "LblSname"
Me.LblSname.Size = New System.Drawing.Size(216, 16)
Me.LblSname.TabIndex = 184
Me.LblSname.UseMnemonic = False
'
'Label3
'
Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label3.Location = New System.Drawing.Point(8, 40)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(48, 16)
Me.Label3.TabIndex = 183
Me.Label3.Text = "Address"
'
'LblName
'
Me.LblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblName.Location = New System.Drawing.Point(72, 8)
Me.LblName.Name = "LblName"
Me.LblName.Size = New System.Drawing.Size(216, 16)
Me.LblName.TabIndex = 182
Me.LblName.UseMnemonic = False
'
'label1
'
Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.label1.Location = New System.Drawing.Point(8, 8)
Me.label1.Name = "label1"
Me.label1.Size = New System.Drawing.Size(48, 16)
Me.label1.TabIndex = 181
Me.label1.Text = "Name"
'
'C1DataGrdList
'
Me.C1DataGrdList.AllowColMove = False
Me.C1DataGrdList.AllowColSelect = False
Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
Me.C1DataGrdList.AlternatingRows = True
Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
Me.C1DataGrdList.Location = New System.Drawing.Point(8, 96)
Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
Me.C1DataGrdList.Name = "C1DataGrdList"
Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75
Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.C1DataGrdList.Size = New System.Drawing.Size(680, 280)
Me.C1DataGrdList.TabIndex = 197
Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
'
'TbMain
'
Me.TbMain.Anchor = System.Windows.Forms.AnchorStyles.Bottom
Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarReturn, Me.TBarSep1, Me.TBarAccept})
Me.TbMain.Dock = System.Windows.Forms.DockStyle.None
Me.TbMain.DropDownArrows = True
Me.TbMain.ImageList = Me.ImageList1
Me.TbMain.Location = New System.Drawing.Point(8, 376)
Me.TbMain.Name = "TbMain"
Me.TbMain.ShowToolTips = True
Me.TbMain.Size = New System.Drawing.Size(312, 50)
Me.TbMain.TabIndex = 198
'
'TBarReturn
'
Me.TBarReturn.ImageIndex = 0
Me.TBarReturn.Name = "TBarReturn"
Me.TBarReturn.Text = "&Return (accounts accepted will be included) "
'
'TBarSep1
'
Me.TBarSep1.Name = "TBarSep1"
Me.TBarSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
'
'TBarAccept
'
Me.TBarAccept.Name = "TBarAccept"
Me.TBarAccept.Text = "Accept All"
'
'ImageList1
'
Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
Me.ImageList1.Images.SetKeyName(0, "")
Me.ImageList1.Images.SetKeyName(1, "")
'
'LblCity
'
Me.LblCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblCity.Location = New System.Drawing.Point(72, 80)
Me.LblCity.Name = "LblCity"
Me.LblCity.Size = New System.Drawing.Size(130, 16)
Me.LblCity.TabIndex = 203
'
'LblState
'
Me.LblState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblState.Location = New System.Drawing.Point(211, 80)
Me.LblState.Name = "LblState"
Me.LblState.Size = New System.Drawing.Size(20, 16)
Me.LblState.TabIndex = 204
'
'LblZip5
'
Me.LblZip5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblZip5.Location = New System.Drawing.Point(230, 80)
Me.LblZip5.Name = "LblZip5"
Me.LblZip5.Size = New System.Drawing.Size(47, 15)
Me.LblZip5.TabIndex = 205
'
'LblZip4
'
Me.LblZip4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblZip4.Location = New System.Drawing.Point(283, 80)
Me.LblZip4.Name = "LblZip4"
Me.LblZip4.Size = New System.Drawing.Size(32, 16)
Me.LblZip4.TabIndex = 206
'
'BtnClearAddr
'
Me.BtnClearAddr.AllowDrop = True
Me.BtnClearAddr.Location = New System.Drawing.Point(313, 12)
Me.BtnClearAddr.Name = "BtnClearAddr"
Me.BtnClearAddr.Size = New System.Drawing.Size(93, 65)
Me.BtnClearAddr.TabIndex = 207
Me.BtnClearAddr.Text = "Clear address (Double click a row to repopulate)"
Me.BtnClearAddr.UseVisualStyleBackColor = True
'
'FrmTX4041B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(698, 432)
Me.Controls.Add(Me.BtnClearAddr)
Me.Controls.Add(Me.LblZip4)
Me.Controls.Add(Me.LblZip5)
Me.Controls.Add(Me.LblState)
Me.Controls.Add(Me.LblCity)
Me.Controls.Add(Me.C1DataGrdList)
Me.Controls.Add(Me.LblAdd2)
Me.Controls.Add(Me.LblAdd1)
Me.Controls.Add(Me.LblSname)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.LblName)
Me.Controls.Add(Me.label1)
Me.Controls.Add(Me.TbMain)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX4041B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Verify  Address Differences"
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

  Private Sub FrmTX4041B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmTX404.TBarSettings.Enabled = False
		WrkName = MyFrmTX4042.TxtName.Text
		WrkSName = MyFrmTX4042.TxtSname.Text
		WrkAdd1 = MyFrmTX4042.TxtAdd1.Text
		WrkAdd2 = MyFrmTX4042.TxtAdd2.Text
		WrkCity = MyFrmTX4042.TxtCity.Text
		WrkState = MyFrmTX4042.TxtState.Text
		WrkZip5 = MyFrmTX4042.TxtZip5.Text
		WrkZip4 = MyFrmTX4042.TxtZip4.Text
		ShowGrid()
  End Sub
  Private Sub FrmTX4041B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
     MyFrmTX404.SbpScreen.Text = "TX4041B"
  End Sub
Private Sub FrmTX4041B_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    mydsVerify.Clear()
		If MyPrinter <> String.Empty Then
			MyFrmTX404.TBarPrint.Enabled = True
		End If
		MyFrmTX404.TBarSettings.Enabled = True
    SetToolbar()
    MyFrmTX4042.ShowGrid()
    MyFrmTX4042.Show()
    'Memory Cleanup
    MyFrmTX4041B = Nothing
End Sub
    Public Sub ShowGrid()
		 Dim I As Integer
		 Windows.Forms.Cursor.Current = Cursors.WaitCursor

     RefreshDS()

     With C1DataGrdList
      .DataSource = mydsVerify.Tables(0)
      .Refresh()
      .MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
      .Columns(0).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
      .Columns(0).ValueItems.Values.Clear()
      .Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(0, False)) ' unchecked
      .Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(1, True)) ' checked
      .Columns(0).ValueItems.Translate = True
      .Columns(0).Caption = "Accept"
      .Splits(0).DisplayColumns(0).Width = 40
      .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
      .Columns(1).Caption = "List#"
			.Splits(0).DisplayColumns(1).Width = 50
			.Splits(0).DisplayColumns(1).Locked = True
			.Splits(0).DisplayColumns(2).Width = 30
			.Splits(0).DisplayColumns(2).Locked = True
			.Splits(0).DisplayColumns(3).Visible = False
      .Splits(0).DisplayColumns(4).Width = 30
			.Splits(0).DisplayColumns(4).Locked = True
      For I = 5 To 14
        .Splits(0).DisplayColumns(I).Visible = False
      Next
      For I = 15 To 23
        .Splits(0).DisplayColumns(I).Locked = True
      Next
      .Splits(0).DisplayColumns(15).Width = 175
      .Splits(0).DisplayColumns(16).Width = 175
      .Splits(0).DisplayColumns(17).Width = 175
      .Splits(0).DisplayColumns(18).Width = 175
      .Splits(0).DisplayColumns(19).Width = 150
      .Splits(0).DisplayColumns(20).Width = 40
      .Columns(20).NumberFormat = "00000"
      .Splits(0).DisplayColumns(21).Width = 40
      .Columns(21).NumberFormat = "0000"
      For I = 22 To 40
        .Splits(0).DisplayColumns(I).Visible = False
      Next


      .Splits(0).DisplayColumns(41).Visible = False 'added 10-3-25 Ken
    End With

     Windows.Forms.Cursor.Current = Cursors.Default

    End Sub
Private Sub RefreshDS()
  Dim ListNo As Integer
  Dim Year As Integer
  Dim Type As String
  Dim I As Integer

  Windows.Forms.Cursor.Current = Cursors.WaitCursor()

  For I = 0 To (mydsVerify.Tables(0).Rows.Count - 1)
    With mydsVerify.Tables(0).Rows(I)
      ListNo = .Item("ListNo")
      Year = .Item("Year")
      Type = .Item("Type")
			If WrkName = "" And I = (mydsVerify.Tables(0).Rows.Count - 1) Then
				WrkName = .Item("name")
				WrkSName = .Item("sname")
				WrkAdd1 = .Item("add1")
				WrkAdd2 = .Item("add2")
				WrkCity = .Item("city")
				WrkState = .Item("state")
				WrkZip5 = Format(.Item("zip5"), "00000")
				WrkZip4 = Format(.Item("zip4"), "0000")
			End If
			If LblName.Text = "" Then
				LblName.Text = WrkName
				LblSname.Text = WrkSName
				LblAdd1.Text = WrkAdd1
				LblAdd2.Text = WrkAdd2
				LblCity.Text = WrkCity
				LblState.Text = WrkState
				LblZip5.Text = WrkZip5
				LblZip4.Text = WrkZip4
			End If
			.Item("accept") = CheckAddr(I)
		End With
  Next

  Windows.Forms.Cursor.Current = Cursors.Default

End Sub
  Private Sub SelGridItems()

  Dim myDr As Data.DataRow
  Dim I As Integer
  Dim J As Integer

    Windows.Forms.Cursor.Current = Cursors.WaitCursor()
    For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
      If C1DataGrdList.Item(I, 0) Then
        myDr = myds.Tables(0).NewRow
        For J = 0 To C1DataGrdList.Columns.Count - 1
          myDr.Item(J) = C1DataGrdList.Item(I, J)
        Next
        myds.Tables(0).Rows.Add(myDr)
      End If
    Next

  End Sub
Private Function CheckAddr(ByVal I As Integer) As Boolean

Dim SameAddr As Boolean

SameAddr = False
'Check to see if same name & address
With mydsVerify.Tables(0).Rows(I)
  If WrkName = .Item("name") And WrkSName = .Item("sname") _
    And WrkAdd1 = .Item("add1") And WrkAdd2 = .Item("add2") _
    And WrkCity = .Item("city") And WrkState = .Item("state") _
    And MyUtils.CnvSng(WrkZip5) = .Item("zip5") And MyUtils.CnvSng(WrkZip4) = .Item("zip4") Then
      SameAddr = True
    End If
End With

Return SameAddr

End Function

Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
    If e.Button Is TBarReturn Then
			SelGridItems()
			SetAddress()
      Me.Close()
      Exit Sub
    End If

    If e.Button Is TBarAccept Then
      UpdateGrid()
    End If
End Sub
Private Sub SetToolbar()
  With MyFrmTX4042
    .TBarUpdate.Enabled = True
    .TBarRecalc.Enabled = True
    .TBarStatusCD.Enabled = True
		.TBarFeeCD.Enabled = True
		.TBarComment.Enabled = True
    .ChkEdit.Enabled = True
  End With
End Sub
Private Sub UpdateGrid()
  Dim I As Integer

  For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
    C1DataGrdList.Item(I, 0) = True
  Next
End Sub
Private Sub ClearGrid()
	Dim I As Integer

	For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
		C1DataGrdList.Item(I, 0) = False
	Next
End Sub

Private Sub BtnClearAddr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClearAddr.Click
		LblName.Text = String.Empty
		LblSname.Text = String.Empty
		LblAdd1.Text = String.Empty
		LblAdd2.Text = String.Empty
		LblCity.Text = String.Empty
		LblState.Text = String.Empty
		LblZip5.Text = String.Empty
		LblZip4.Text = String.Empty
		ClearGrid()
End Sub
	Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
		If LblName.Text <> String.Empty Then Exit Sub

		LblName.Text = C1DataGrdList.Item(C1DataGrdList.Row, 14)
		LblSname.Text = C1DataGrdList.Item(C1DataGrdList.Row, 15)
		LblAdd1.Text = C1DataGrdList.Item(C1DataGrdList.Row, 16)
		LblAdd2.Text = C1DataGrdList.Item(C1DataGrdList.Row, 17)
		LblCity.Text = C1DataGrdList.Item(C1DataGrdList.Row, 18)
		LblState.Text = C1DataGrdList.Item(C1DataGrdList.Row, 19)
		LblZip5.Text = C1DataGrdList.Item(C1DataGrdList.Row, 20)
		LblZip4.Text = C1DataGrdList.Item(C1DataGrdList.Row, 21)
		C1DataGrdList.Item(C1DataGrdList.Row, 0) = True

		WrkName = LblName.Text
		WrkSName = LblSname.Text
		WrkAdd1 = LblAdd1.Text
		WrkAdd2 = LblAdd2.Text
		WrkCity = LblCity.Text
		WrkState = LblState.Text
		WrkZip5 = LblZip5.Text
		WrkZip4 = LblZip4.Text
	End Sub
Private Sub SetAddress()
	MyFrmTX4042.TxtName.Text = WrkName
	MyFrmTX4042.TxtSname.Text = WrkSName
	MyFrmTX4042.TxtAdd1.Text = WrkAdd1
	MyFrmTX4042.TxtAdd2.Text = WrkAdd2
	MyFrmTX4042.TxtCity.Text = WrkCity
	MyFrmTX4042.TxtState.Text = WrkState
	MyFrmTX4042.TxtZip5.Text = WrkZip5
	MyFrmTX4042.TxtZip4.Text = WrkZip4
End Sub

Private Sub C1DataGrdList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.Click

End Sub
End Class






