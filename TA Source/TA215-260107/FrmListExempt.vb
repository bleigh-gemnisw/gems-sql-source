Public Class FrmListExempt
  Inherits System.Windows.Forms.Form
	Dim myTXXPROP As TXXprop.myData
  Dim ds As DataSet = New DataSet
  Friend WrkFile As String
  Friend WithEvents ImageList1 As ImageList
  Friend WithEvents TbMain As ToolBar
    Friend WithEvents TBarReturn As ToolBarButton
    Friend WithEvents TBarSep1 As ToolBarButton
    Friend WithEvents TBarAll As ToolBarButton
    Friend WithEvents TBarClear As ToolBarButton
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WrkCode As String
    Dim mydsexcode As DataSet = New DataSet
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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents TxtPos As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListExempt))
    Me.Label1 = New System.Windows.Forms.Label()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarReturn = New System.Windows.Forms.ToolBarButton()
    Me.TBarSep1 = New System.Windows.Forms.ToolBarButton()
    Me.TBarAll = New System.Windows.Forms.ToolBarButton()
    Me.TBarClear = New System.Windows.Forms.ToolBarButton()
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Position To"
        '
        'BtnFind
        '
        Me.BtnFind.Location = New System.Drawing.Point(208, 11)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(53, 24)
        Me.BtnFind.TabIndex = 41
        Me.BtnFind.Text = "&Find"
        '
        'TxtPos
        '
        Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPos.Location = New System.Drawing.Point(72, 15)
        Me.TxtPos.Name = "TxtPos"
        Me.TxtPos.Size = New System.Drawing.Size(128, 20)
        Me.TxtPos.TabIndex = 40
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        '
        'TbMain
        '
        Me.TbMain.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarReturn, Me.TBarSep1, Me.TBarAll, Me.TBarClear})
        Me.TbMain.Dock = System.Windows.Forms.DockStyle.None
        Me.TbMain.DropDownArrows = True
        Me.TbMain.ImageList = Me.ImageList1
        Me.TbMain.Location = New System.Drawing.Point(22, 444)
        Me.TbMain.Name = "TbMain"
        Me.TbMain.ShowToolTips = True
        Me.TbMain.Size = New System.Drawing.Size(192, 50)
        Me.TbMain.TabIndex = 193
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
        'C1DataGrdList
        '
        Me.C1DataGrdList.AlternatingRows = True
        Me.C1DataGrdList.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
        Me.C1DataGrdList.Location = New System.Drawing.Point(14, 68)
        Me.C1DataGrdList.Name = "C1DataGrdList"
        Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
        Me.C1DataGrdList.PrintInfo.MeasurementDevice = C1.Win.C1TrueDBGrid.PrintInfo.MeasurementDeviceEnum.Screen
        Me.C1DataGrdList.PrintInfo.MeasurementPrinterName = Nothing
        Me.C1DataGrdList.Size = New System.Drawing.Size(456, 362)
        Me.C1DataGrdList.TabIndex = 194
        Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
        '
        'FrmListExempt
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(476, 501)
        Me.Controls.Add(Me.C1DataGrdList)
        Me.Controls.Add(Me.TbMain)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnFind)
        Me.Controls.Add(Me.TxtPos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmListExempt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selection Exemption Code"
        CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
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
      .Columns(1).Caption = "Code"
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
    C1DataGrdList.DataSource = mydsexcode.Tables(0)
    C1DataGrdList.Refresh()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub FrmListExempt_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA215.SbpScreen.Text = "ListExempt"
    ' MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub FrmListExempt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXXPROP = New TXXprop.mydata(MyDBConnect)


    BuildDS()
    RefreshDS()
    Call FormatGrid()
  End Sub


  Private Sub FrmListExempt_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    'Memroy Cleanup
    MyFrmTA215.SbpScreen.Text = "TA215B"
    myTXXPROP = Nothing
    MyFrmListExempt = Nothing
  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Select", Type.GetType("System.Boolean"))
      .Columns.Add("PREXEM", Type.GetType("System.String"))
      .Columns.Add("TXDESC", Type.GetType("System.String"))
    End With
    mydsexcode.Tables.Add(myTable)
  End Sub
  Private Sub RefreshDS()
    Dim myDr As Data.DataRow
    Dim I As Integer
    Dim Pos As Integer

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    ds = myTXXPROP.GetAllData
    For I = 0 To ds.Tables(0).Rows.Count - 1
      myDr = mydsexcode.Tables(0).NewRow

      Pos = InStr(MySelCodes, ds.Tables(0).Rows(I).Item("PREXEM"))

      If MySelCodes = "" Or Pos > 0 Then
        myDr("select") = True
      Else
        myDr("select") = False
      End If
      myDr("PREXEM") = ds.Tables(0).Rows(I).Item("PREXEM")
      myDr("TXDESC") = ds.Tables(0).Rows(I).Item("TXDESC")
      mydsexcode.Tables(0).Rows.Add(myDr)
    Next

    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub

  Private Sub SelGridItems()

    Dim WrkAllCodes As Boolean
    Dim I As Integer

    MySelCodes = ""
    WrkAllCodes = True
    Windows.Forms.Cursor.Current = Cursors.WaitCursor()
    For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
      If C1DataGrdList.Item(I, 0) Then

        MySelCodes = MySelCodes + " " + Trim(C1DataGrdList.Item(I, 1))

      Else
        WrkAllCodes = False
      End If
    Next

    If WrkAllCodes Then
      MySelCodes = ""
    End If

    Windows.Forms.Cursor.Current = Cursors.Default
    Me.Close()

  End Sub
  Private Sub SelGridAll()

    Dim I As Integer

    Windows.Forms.Cursor.Current = Cursors.WaitCursor()
    For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
      mydsexcode.Tables(0).Rows(I).Item("Select") = True
    Next

    MySelCodes = ""

    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Private Sub SelGridClear()

    Dim I As Integer

    Windows.Forms.Cursor.Current = Cursors.WaitCursor()
    For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
      mydsexcode.Tables(0).Rows(I).Item("Select") = False
    Next

    MySelCodes = ""

    Windows.Forms.Cursor.Current = Cursors.Default
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




End Class






