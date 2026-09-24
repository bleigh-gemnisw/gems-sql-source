Public Class FrmSelTypes
    'Put this code in Main.vb: 
    'Public MyTypes As String
    Inherits System.Windows.Forms.Form
		Dim mytxtype As TXTYPE.myData
    Dim ds As DataSet = New DataSet
    Dim mydstxtype As DataSet = New DataSet

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
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  Friend WithEvents TbMain As System.Windows.Forms.ToolBar
  Friend WithEvents TBarReturn As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarSep1 As System.Windows.Forms.ToolBarButton
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents TBarAll As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarClear As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrmSelTypes))
Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
Me.TbMain = New System.Windows.Forms.ToolBar
Me.TBarReturn = New System.Windows.Forms.ToolBarButton
Me.TBarSep1 = New System.Windows.Forms.ToolBarButton
Me.TBarAll = New System.Windows.Forms.ToolBarButton
Me.TBarClear = New System.Windows.Forms.ToolBarButton
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'C1DataGrdList
'
Me.C1DataGrdList.AlternatingRows = True
Me.C1DataGrdList.CaptionHeight = 17
Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
Me.C1DataGrdList.Images.Add(CType(resources.GetObject("resource"), System.Drawing.Image))
Me.C1DataGrdList.Location = New System.Drawing.Point(8, 8)
Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
Me.C1DataGrdList.Name = "C1DataGrdList"
Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75
Me.C1DataGrdList.RecordSelectorWidth = 17
Me.C1DataGrdList.RowDivider.Color = System.Drawing.Color.DarkGray
Me.C1DataGrdList.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
Me.C1DataGrdList.RowHeight = 15
Me.C1DataGrdList.RowSubDividerColor = System.Drawing.Color.DarkGray
Me.C1DataGrdList.Size = New System.Drawing.Size(368, 236)
Me.C1DataGrdList.TabIndex = 176
Me.C1DataGrdList.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
"r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
"ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Lavender;}Selec" & _
"ted{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inac" & _
"tiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:" & _
"Center;}Style1{}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight" & _
";}Style12{}OddRow{}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:True;" & _
"BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Cent" & _
"er;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style9{}</Data></" & _
"Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""True""" & _
" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyl" & _
"e=""NoMarquee"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""" & _
"1"" HorizontalScrollGroup=""1""><CaptionStyle parent=""Style2"" me=""Style10"" /><Edito" & _
"rStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" " & _
"/><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer""" & _
" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""H" & _
"eading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><In" & _
"activeStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Sty" & _
"le9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyl" & _
"e parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRe" & _
"ct>0, 0, 364, 232</ClientRect><BorderSide>0</BorderSide></C1.Win.C1TrueDBGrid.Me" & _
"rgeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Norm" & _
"al"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading""" & _
" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" m" & _
"e=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""H" & _
"ighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""" & _
"OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" m" & _
"e=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1" & _
"</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>" & _
"17</DefaultRecSelWidth><ClientArea>0, 0, 364, 232</ClientArea><PrintPageHeaderSt" & _
"yle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Bl" & _
"ob>"
'
'TbMain
'
Me.TbMain.Anchor = System.Windows.Forms.AnchorStyles.Bottom
Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarReturn, Me.TBarSep1, Me.TBarAll, Me.TBarClear})
Me.TbMain.Dock = System.Windows.Forms.DockStyle.None
Me.TbMain.DropDownArrows = True
Me.TbMain.ImageList = Me.ImageList1
Me.TbMain.Location = New System.Drawing.Point(8, 248)
Me.TbMain.Name = "TbMain"
Me.TbMain.ShowToolTips = True
Me.TbMain.Size = New System.Drawing.Size(192, 50)
Me.TbMain.TabIndex = 192
'
'TBarReturn
'
Me.TBarReturn.ImageIndex = 2
Me.TBarReturn.Text = "&Return"
'
'TBarSep1
'
Me.TBarSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
'
'TBarAll
'
Me.TBarAll.ImageIndex = 0
Me.TBarAll.Text = "&Select All"
'
'TBarClear
'
Me.TBarClear.ImageIndex = 1
Me.TBarClear.Text = "&Clear All"
'
'ImageList1
'
Me.ImageList1.ImageSize = New System.Drawing.Size(24, 24)
Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
'
'FrmSelTypes
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(384, 302)
Me.Controls.Add(Me.C1DataGrdList)
Me.Controls.Add(Me.TbMain)
Me.KeyPreview = True
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmSelTypes"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
Me.Text = "Select Tax Types"
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmSelTypes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			mytxtype = New TXTYPE.mydata(MyDBConnect)
      MyFrmTX810.TBarProcess.Enabled = False
      BuildDS()
      RefreshDS()
      Call FormatGrid()

    End Sub
    Public Sub FormatGrid()

    Dim I As Integer

    Call ShowGrid()

    With C1DataGrdList
      .Rebind(True)
      .MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
      .Columns(0).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
      .Columns(0).ValueItems.Values.Clear()
      .Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(0, False)) ' checked
      .Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(1, True)) ' unchecked
      .Columns(0).ValueItems.Translate = True
      .Columns(0).Caption = "Select"
      .Splits(0).DisplayColumns(0).Width = 40
      .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
      .Columns(1).Caption = "Type"
      .Splits(0).DisplayColumns(1).Width = 40
      .Columns(2).Caption = "Description"
      .Splits(0).DisplayColumns(2).Width = 150
      For I = 1 To 2
        .Splits(0).DisplayColumns(I).Locked = True
      Next
    End With

    End Sub
    Public Sub ShowGrid()
      Windows.Forms.Cursor.Current = Cursors.WaitCursor
      C1DataGrdList.DataSource = mydstxtype.Tables(0)
      C1DataGrdList.Refresh()
      Windows.Forms.Cursor.Current = Cursors.Default

    End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Select", Type.GetType("System.Boolean"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Description", Type.GetType("System.String"))
    End With
    mydstxtype.Tables.Add(myTable)
  End Sub
Private Sub RefreshDS()
  Dim myDr As Data.DataRow
  Dim I As Integer
  Dim Pos As Integer

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    ds = mytxtype.GetAllData
    For I = 0 To ds.Tables(0).Rows.Count - 1
      myDr = mydstxtype.Tables(0).NewRow
      Pos = InStr(MyTypes, ds.Tables(0).Rows(I).Item("tycode"))
      If Pos > 0 Then
        myDr("select") = True
      Else
        myDr("select") = False
      End If
      myDr("type") = ds.Tables(0).Rows(I).Item("tycode")
      myDr("description") = ds.Tables(0).Rows(I).Item("tydesc")
      mydstxtype.Tables(0).Rows.Add(myDr)
    Next

  Windows.Forms.Cursor.Current = Cursors.Default
  Me.Refresh()
End Sub
  Private Sub SelGridItems()

  Dim WrkAllTypes As Boolean
  Dim I As Integer

  MyTypes = ""
  WrkAllTypes = True
  Windows.Forms.Cursor.Current = Cursors.WaitCursor()
  For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
    If C1DataGrdList.Item(I, 0) Then
      MyTypes = MyTypes + C1DataGrdList.Item(I, 1)
    Else
      WrkAllTypes = False
    End If
  Next

  If WrkAllTypes Then
    MyTypes = ""
  End If

  Windows.Forms.Cursor.Current = Cursors.Default
  Me.Close()

  End Sub
  Private Sub SelGridAll()

  Dim I As Integer

  Windows.Forms.Cursor.Current = Cursors.WaitCursor()
  For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
    mydstxtype.Tables(0).Rows(I).Item("Select") = True
  Next

  MyTypes = ""

  Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Private Sub SelGridClear()

  Dim I As Integer

  Windows.Forms.Cursor.Current = Cursors.WaitCursor()
  For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
    mydstxtype.Tables(0).Rows(I).Item("Select") = False
  Next
  C1DataGrdList.Rebind(True)
  MyTypes = ""

  Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
Private Sub FrmSelTypes_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
     MyFrmTX810.SbpScreen.Text = "SelTypes"
  End Sub
  Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
    If e.Button Is TBarReturn Then
       SelGridItems()
       Exit Sub
    End If

    If e.Button Is TBarAll Then
      SelGridAll()
      Exit Sub
    End If

    If e.Button Is TBarClear Then
      SelGridClear()
      Exit Sub
    End If

  End Sub

  Private Sub FrmSelTypes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub

  If e.KeyCode = Keys.S Then
    SelGridAll()
  End If

  If e.KeyCode = Keys.C Then
    SelGridClear()
  End If

  If e.KeyCode = Keys.R Then
    SelGridItems()
  End If
  End Sub

Private Sub C1DataGrdList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.Click

End Sub

Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick

End Sub

Private Sub FrmSelTypes_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTX810.TBarProcess.Enabled = True
  MyFrmTX810B.TxtTypes.Text = MyTypes
End Sub
End Class






