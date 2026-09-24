Imports System.Data
Public Class FrmPO306B
  Inherits System.Windows.Forms.Form

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
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents TxtFscyr As System.Windows.Forms.TextBox
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents TxtPONbr As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents ChkUnprintedOnly As System.Windows.Forms.CheckBox
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents LblLocation As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TbLeft As System.Windows.Forms.ToolBar
  Friend WithEvents TxtPONbrTo As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents BtnSelRange As System.Windows.Forms.Button
  Friend WithEvents TBarSelLoc As System.Windows.Forms.ToolBarButton
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPO306B))
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.TxtFscyr = New System.Windows.Forms.TextBox()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.TxtPONbr = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.ChkUnprintedOnly = New System.Windows.Forms.CheckBox()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.LblLocation = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TbLeft = New System.Windows.Forms.ToolBar()
    Me.TBarSelLoc = New System.Windows.Forms.ToolBarButton()
    Me.TxtPONbrTo = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.BtnSelRange = New System.Windows.Forms.Button()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(224, 7)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 20
    Me.BtnFind.Text = "Find"
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
    Me.C1DataGrdList.Location = New System.Drawing.Point(13, 63)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    Me.C1DataGrdList.Size = New System.Drawing.Size(575, 325)
    Me.C1DataGrdList.TabIndex = 196
    '
    'TxtFscyr
    '
    Me.TxtFscyr.Location = New System.Drawing.Point(50, 15)
    Me.TxtFscyr.MaxLength = 4
    Me.TxtFscyr.Name = "TxtFscyr"
    Me.TxtFscyr.Size = New System.Drawing.Size(32, 20)
    Me.TxtFscyr.TabIndex = 197
    '
    'TxtPONbr
    '
    Me.TxtPONbr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPONbr.Location = New System.Drawing.Point(152, 10)
    Me.TxtPONbr.MaxLength = 7
    Me.TxtPONbr.Name = "TxtPONbr"
    Me.TxtPONbr.Size = New System.Drawing.Size(66, 20)
    Me.TxtPONbr.TabIndex = 199
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(104, 13)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(42, 13)
    Me.Label1.TabIndex = 200
    Me.Label1.Text = "PO Nbr"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 18)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(29, 13)
    Me.Label2.TabIndex = 201
    Me.Label2.Text = "Year"
    '
    'ChkUnprintedOnly
    '
    Me.ChkUnprintedOnly.AutoSize = True
    Me.ChkUnprintedOnly.Location = New System.Drawing.Point(193, 402)
    Me.ChkUnprintedOnly.Name = "ChkUnprintedOnly"
    Me.ChkUnprintedOnly.RightToLeft = System.Windows.Forms.RightToLeft.Yes
    Me.ChkUnprintedOnly.Size = New System.Drawing.Size(96, 17)
    Me.ChkUnprintedOnly.TabIndex = 203
    Me.ChkUnprintedOnly.Text = "Unprinted Only"
    Me.ChkUnprintedOnly.UseVisualStyleBackColor = True
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    Me.ImageList1.Images.SetKeyName(1, "select type_24.png")
    '
    'LblLocation
    '
    Me.LblLocation.AutoSize = True
    Me.LblLocation.Location = New System.Drawing.Point(553, 22)
    Me.LblLocation.Name = "LblLocation"
    Me.LblLocation.Size = New System.Drawing.Size(0, 13)
    Me.LblLocation.TabIndex = 206
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(496, 22)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(51, 13)
    Me.Label3.TabIndex = 207
    Me.Label3.Text = "Location:"
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(480, 2)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(98, 20)
    Me.Label5.TabIndex = 208
    Me.Label5.Text = "Filter"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'TbLeft
    '
    Me.TbLeft.AutoSize = False
    Me.TbLeft.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarSelLoc})
    Me.TbLeft.ButtonSize = New System.Drawing.Size(150, 22)
    Me.TbLeft.Dock = System.Windows.Forms.DockStyle.None
    Me.TbLeft.DropDownArrows = True
    Me.TbLeft.ImageList = Me.ImageList1
    Me.TbLeft.Location = New System.Drawing.Point(348, 394)
    Me.TbLeft.Name = "TbLeft"
    Me.TbLeft.ShowToolTips = True
    Me.TbLeft.Size = New System.Drawing.Size(114, 33)
    Me.TbLeft.TabIndex = 209
    Me.TbLeft.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
    Me.TbLeft.Wrappable = False
    '
    'TBarSelLoc
    '
    Me.TBarSelLoc.ImageIndex = 1
    Me.TBarSelLoc.Name = "TBarSelYear"
    Me.TBarSelLoc.Text = "Set Location"
    '
    'TxtPONbrTo
    '
    Me.TxtPONbrTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPONbrTo.Location = New System.Drawing.Point(152, 37)
    Me.TxtPONbrTo.MaxLength = 7
    Me.TxtPONbrTo.Name = "TxtPONbrTo"
    Me.TxtPONbrTo.Size = New System.Drawing.Size(66, 20)
    Me.TxtPONbrTo.TabIndex = 210
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(104, 40)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(34, 13)
    Me.Label4.TabIndex = 211
    Me.Label4.Text = "to PO"
    '
    'BtnSelRange
    '
    Me.BtnSelRange.Location = New System.Drawing.Point(224, 34)
    Me.BtnSelRange.Name = "BtnSelRange"
    Me.BtnSelRange.Size = New System.Drawing.Size(83, 24)
    Me.BtnSelRange.TabIndex = 212
    Me.BtnSelRange.Text = "Select Range"
    '
    'FrmPO306B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(604, 431)
    Me.ControlBox = False
    Me.Controls.Add(Me.BtnSelRange)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtPONbrTo)
    Me.Controls.Add(Me.TbLeft)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.LblLocation)
    Me.Controls.Add(Me.ChkUnprintedOnly)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtPONbr)
    Me.Controls.Add(Me.TxtFscyr)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.Controls.Add(Me.BtnFind)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "FrmPO306B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region
  Dim myPOMAST As POMAST.MyData
 Dim myPOMASTL1 As POMASTL1.MyData
 Dim ds As DataSet = New DataSet
 Dim WrkAnd As String
 Dim WrkOr As String

  Private Sub FrmPO306B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myPOMAST = New POMAST.MyData()
    myPOMAST.MyDBConn = myDBConnect
    myPOMASTL1 = New POMASTL1.MyData()
    myPOMASTL1.MyDBConn = myDBConnect

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    If MyInquiryMode Then
      ChkUnprintedOnly.Visible = False
    End If

    If MyAppSettings.Year > 0 Then
      TxtFscyr.Text = MyAppSettings.Year
    End If
    MyPrinter = MyAppSettings.Printer
    MyPrinter2 = MyAppSettings.Printer2
    MyPrinter3 = MyAppSettings.Printer3
    MyDrawers = MyAppSettings.Drawers

    MySelLoc = ""
    Call FormatGrid("")
    LblLocation.Text = "ALL"
  End Sub
  Public Sub FormatGrid(ByVal WrkMode As String)

    Call ShowGrid(WrkMode)
    With C1DataGrdList
      .Rebind(True)
      .MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
      .Columns(0).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
      .Columns(0).ValueItems.Values.Clear()
      .Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(0, False)) ' unchecked
      .Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(1, True)) ' checked
      .Columns(0).ValueItems.Translate = True
      .Columns(0).Caption = "Select"
      .Splits(0).DisplayColumns(0).Width = 40
      .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
      .Columns(1).Caption = "Fiscal Yr"
      .Splits(0).DisplayColumns(1).Width = 50
      .Columns(2).Caption = "PO No"
      .Splits(0).DisplayColumns(2).Width = 50
      .Splits(0).DisplayColumns(3).Visible = False
      .Columns(4).Caption = "Vndr No"
      .Splits(0).DisplayColumns(4).Width = 50
      .Columns(5).Caption = "Vndr Name"
      .Splits(0).DisplayColumns(5).Width = 200
      .Columns(6).Caption = "Total Net"
      .Splits(0).DisplayColumns(6).Width = 75
      .Columns(6).NumberFormat = "###,###,##0.00"
      .Columns(7).Caption = "PO Date"
      .Splits(0).DisplayColumns(7).Width = 65
      .Columns(7).NumberFormat = "##/##/####"
    End With
  End Sub
  Public Sub ShowGrid(ByVal WrkMode As String)
    Dim WrkFscyr As Integer
    Dim WrkPONbr As Integer
    Dim WrkPONbrTo As Integer
    Dim WrkPrtfg As Boolean
    Dim I As Integer

    myPOMASTL1.CloseFile()
    If ChkUnprintedOnly.Checked Then
      WrkPrtfg = True
    Else
      WrkPrtfg = False
    End If
    WrkFscyr = MyUtils.CnvSng(TxtFscyr.Text)
    WrkPONbr = MyUtils.CnvSng(TxtPONbr.Text)
    WrkPONbrTo = MyUtils.CnvSng(TxtPONbrTo.Text)
    ds = myPOMASTL1.GetViewbyPOL8(MySelLoc, WrkFscyr, WrkPONbr, WrkPrtfg, 0)
    If ChkUnprintedOnly.Checked Then
      For I = 0 To ds.Tables(0).Rows.Count - 1
        ds.Tables(0).Rows(I).Item("wsel") = 1
      Next
    End If
    If WrkMode = "SelRange" And WrkPONbrTo > 0 Then
      For I = 0 To ds.Tables(0).Rows.Count - 1
        If ds.Tables(0).Rows(I).Item("ponbr") >= WrkPONbr And ds.Tables(0).Rows(I).Item("ponbr") <= WrkPONbrTo Then
          ds.Tables(0).Rows(I).Item("wsel") = 1
        End If
      Next
    End If
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()
  End Sub
  Private Sub FrmPO306C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmPO306.SbpScreen.Text = "PO306B"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
Public Sub PrintData()
  PrtReport(ds)
End Sub
Public Sub ProcessFlag()
  SetPrtFlag(ds)
  FormatGrid("")
End Sub
Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
  FormatGrid("")
End Sub
  Private Sub DoBtnSelLoc()
    MyFrmPO306.TBarPrint.Enabled = False
    MyFrmPO306.TBarBack.Enabled = False
    Me.Hide()
    MyFrmListLoc = New FrmListLoc
    MyFrmListLoc.WrkCode = MySelLoc
    MyFrmListLoc.ShowDialog()
    MyFrmPO306.TBarPrint.Enabled = True
    MyFrmPO306.TBarBack.Enabled = True
    If MySelLoc = "" Then
      LblLocation.Text = "ALL"
    Else
      LblLocation.Text = MySelLoc
    End If
    FormatGrid("")
    Me.Show()
  End Sub

Private Sub ChkUnprintedOnly_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkUnprintedOnly.Click
  FormatGrid("")
End Sub

Private Sub TbLeft_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbLeft.ButtonClick
  If e.Button Is TBarSelLoc Then
    DoBtnSelLoc()
    Exit Sub
  End If
End Sub
Private Sub BtnSelRange_Click(sender As Object, e As EventArgs) Handles BtnSelRange.Click
  FormatGrid("SelRange")
End Sub
Private Sub C1DataGrdList_DoubleClick(sender As Object, e As EventArgs) Handles C1DataGrdList.DoubleClick
  Windows.Forms.Cursor.Current = Cursors.WaitCursor
  MyFrmPO306C = New FrmPO306C
  MyFrmPO306C.MdiParent = Me.ParentForm
  MyFrmPO306C.WrkFscyr = C1DataGrdList.Item(C1DataGrdList.Row, 1)
  MyFrmPO306C.WrkPonbr = C1DataGrdList.Item(C1DataGrdList.Row, 2)
  MyFrmPO306C.Show()
  Me.Hide()
  Windows.Forms.Cursor.Current = Cursors.Default
End Sub
End Class
