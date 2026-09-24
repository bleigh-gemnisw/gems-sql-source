Public Class FrmBD001App

  Inherits System.Windows.Forms.Form
  Dim myBDMASTLA As BDMASTLA.myData
  'General
  Dim WrkAnd As String
  Friend WithEvents DataGrdView As DataGridView
  Dim WrkOr As String


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
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBD001App))
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    Me.ImageList1.Images.SetKeyName(1, "select type_24.png")
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView.DefaultCellStyle = DataGridViewCellStyle1
    Me.DataGrdView.Location = New System.Drawing.Point(12, 12)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(701, 397)
    Me.DataGrdView.TabIndex = 34
    '
    'FrmBD001App
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(725, 421)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmBD001App"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Select Pending Application"
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmBD001App_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myBDMASTLA = New BDMASTLA.mydata(MyDBConnect)
    MyFrmBD001.TBarPending.Enabled = False
    If MyPublic Then
      MyFrmBD001.TBarBack.Visible = True
      MyFrmBD001.TBarSave.Enabled = False
      MyFrmBD001.TBarAuth.Enabled = False
      MyFrmBD001.TBarPending.Enabled = False
    Else
      MyFrmBD001.TBarSave.Enabled = False
      MyFrmBD001.TBarDelete.Enabled = False
    End If
    Call FormatGrid()
  End Sub
  Public Sub FormatGrid()

    Call ShowGrid()

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).Visible = False
    End With
    GridName()
  End Sub
  Public Sub ShowGrid()
    Dim ds As DataSet = New DataSet
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    ds = myBDMASTLA.GetPending()
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Private Sub GridName()
    With DataGrdView
      .Columns(1).HeaderText = "Permit"
      .Columns(1).Width = 50
      .Columns(2).HeaderText = "Type"
      .Columns(2).Width = 50
      .Columns(3).HeaderText = "Name"
      .Columns(3).Width = 220
      .Columns(4).HeaderText = "Loc #"
      .Columns(4).Width = 50
      .Columns(5).HeaderText = "Loc"
      .Columns(5).Width = 150
    End With

  End Sub
  Private Sub FrmBD001App_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmBD001.SbpScreen.Text = "BD001App"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Dim WrkRecID As Integer
    Dim WrkType As String
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    WrkRecID = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    WrkType = DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value
    Select Case Trim(WrkType)
      Case "DEMO"
        MyFrmBD001CD = New FrmBD001CD
        MyFrmBD001CD.WrkRecID = WrkRecID
        MyFrmBD001CD.WrkType = WrkType
        MyFrmBD001CD.WrkApp = False
        MyFrmBD001CD.MdiParent = Me.ParentForm
        MyFrmBD001CD.Show()
      Case "ELECT"
        MyFrmBD001CE = New FrmBD001CE
        MyFrmBD001CE.WrkRecID = WrkRecID
        MyFrmBD001CE.WrkType = WrkType
        MyFrmBD001CE.WrkApp = False
        MyFrmBD001CE.MdiParent = Me.ParentForm
        MyFrmBD001CE.Show()
      Case "FLIQ", "HVAC"
        MyFrmBD001CH = New FrmBD001CH
        MyFrmBD001CH.WrkRecID = WrkRecID
        MyFrmBD001CH.WrkType = WrkType
        MyFrmBD001CH.WrkApp = False
        MyFrmBD001CH.MdiParent = Me.ParentForm
        MyFrmBD001CH.Show()
      Case "P&Z"
        MyFrmBD001CZ = New FrmBD001CZ
        MyFrmBD001CZ.WrkRecID = WrkRecID
        MyFrmBD001CZ.WrkType = WrkType
        MyFrmBD001CZ.WrkApp = False
        MyFrmBD001CZ.MdiParent = Me.ParentForm
        MyFrmBD001CZ.Show()
      Case Else
        MyFrmBD001C = New FrmBD001C
        MyFrmBD001C.WrkRecID = WrkRecID
        MyFrmBD001C.WrkType = WrkType
        MyFrmBD001C.WrkApp = False
        MyFrmBD001C.MdiParent = Me.ParentForm
        MyFrmBD001C.Show()
    End Select
    Me.Close()
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub

End Class






