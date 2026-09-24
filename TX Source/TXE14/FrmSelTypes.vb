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
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelTypes))
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
Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
Me.C1DataGrdList.Location = New System.Drawing.Point(8, 8)
Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
Me.C1DataGrdList.Name = "C1DataGrdList"
Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75
Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.C1DataGrdList.Size = New System.Drawing.Size(368, 236)
Me.C1DataGrdList.TabIndex = 176
Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
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
Me.TBarReturn.Name = "TBarReturn"
Me.TBarReturn.Text = "&Return"
'
'TBarSep1
'
Me.TBarSep1.Name = "TBarSep1"
Me.TBarSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
'
'TBarAll
'
Me.TBarAll.ImageIndex = 0
Me.TBarAll.Name = "TBarAll"
Me.TBarAll.Text = "&Select All"
'
'TBarClear
'
Me.TBarClear.ImageIndex = 1
Me.TBarClear.Name = "TBarClear"
Me.TBarClear.Text = "&Clear All"
'
'ImageList1
'
Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
Me.ImageList1.Images.SetKeyName(0, "")
Me.ImageList1.Images.SetKeyName(1, "")
Me.ImageList1.Images.SetKeyName(2, "")
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
Me.PerformLayout()

End Sub

#End Region

    Private Sub FrmSelTypes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			mytxtype = New TXTYPE.mydata(MyDBConnect)
      MyFrmTXE14.TBarPrint.Enabled = False
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
      If MyTypes = "" Or Pos > 0 Then
        myDr("select") = True
      Else
        myDr("select") = False
      End If
      myDr("type") = ds.Tables(0).Rows(I).Item("tycode")
      myDr("description") = ds.Tables(0).Rows(I).Item("tydesc")
      mydstxtype.Tables(0).Rows.Add(myDr)
    Next

  Windows.Forms.Cursor.Current = Cursors.Default

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

  MyTypes = ""

  Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
Private Sub FrmSelTypes_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
     MyUtils.CenterForm(Me.ParentForm, Me)
     MyFrmTXE14.SbpScreen.Text = "SelTypes"
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
  MyFrmTXE14.TBarPrint.Enabled = True
  MyFrmTXE14B.TxtTypes.Text = MyTypes
  MyFrmTXE14B.Show()
End Sub
End Class






