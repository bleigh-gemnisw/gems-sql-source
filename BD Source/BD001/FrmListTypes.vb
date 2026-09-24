Public Class FrmListTypes
  Inherits System.Windows.Forms.Form
  Dim myBDRATE As BDRATE.myData
  Dim ds As DataSet = New DataSet
  Friend WithEvents DataGrdView As DataGridView
  Friend WrkRecID As Integer

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
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
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
    Me.DataGrdView.Size = New System.Drawing.Size(326, 302)
    Me.DataGrdView.TabIndex = 34
    '
    'FrmListTypes
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(350, 326)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmListTypes"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Select Permit Type "
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Call FormatGrid()
  End Sub

  Public Sub FormatGrid()

    Call ShowGrid()

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "Type"
      .Columns(0).Width = 50
      .Columns(1).HeaderText = "Description"
      .Columns(1).Width = 225
      .Columns(2).Visible = False
    End With

  End Sub
  Public Sub ShowGrid()
    ds = myBDRATE.GetAllTypes
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
  End Sub
  Private Sub FrmListTypes_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmBD001.SbpScreen.Text = "ListTypes"
    If MyPublic Then
      MyFrmBD001.TBarBack.Visible = False
    End If
    MyFrmBD001.TBarSettings.Enabled = False
    If WrkRecID > 0 Then
      MyFrmBD001.TBarPending.Enabled = False
      Me.Text = "Change Permit Type"
    Else
      MyFrmBD001.TBarPending.Enabled = True
    End If
    MyFrmBD001.TBarNew.Enabled = False
    MyFrmBD001.TBarChange.Enabled = False
  End Sub
  Private Sub FrmListTypes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myBDRATE = New BDRATE.mydata(MyDBConnect)
    If MyPublic Then
      Me.ControlBox = False
    End If
    FormatGrid()
  End Sub
  Private Sub DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Dim ds2 As DataSet = New DataSet
    Dim WrkType As String
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    WrkType = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    If WrkRecID = 0 Then
      Select Case Trim(WrkType)
        Case "DEMO"
          MyFrmBD001CD = New FrmBD001CD
          MyFrmBD001CD.WrkRecID = 0
          MyFrmBD001CD.WrkType = WrkType
          MyFrmBD001CD.WrkApp = False
          MyFrmBD001CD.MdiParent = Me.ParentForm
          MyFrmBD001CD.Show()
        Case "ELECT"
          MyFrmBD001CE = New FrmBD001CE
          MyFrmBD001CE.WrkRecID = 0
          MyFrmBD001CE.WrkType = WrkType
          MyFrmBD001CE.WrkApp = False
          MyFrmBD001CE.MdiParent = Me.ParentForm
          MyFrmBD001CE.Show()
        Case "FLIQ", "HVAC"
          MyFrmBD001CH = New FrmBD001CH
          MyFrmBD001CH.WrkRecID = 0
          MyFrmBD001CH.WrkType = WrkType
          MyFrmBD001CH.WrkApp = False
          MyFrmBD001CH.MdiParent = Me.ParentForm
          MyFrmBD001CH.Show()
        Case "P&Z"
          MyFrmBD001CZ = New FrmBD001CZ
          MyFrmBD001CZ.WrkRecID = 0
          MyFrmBD001CZ.WrkType = WrkType
          MyFrmBD001CZ.WrkApp = False
          MyFrmBD001CZ.MdiParent = Me.ParentForm
          MyFrmBD001CZ.Show()
        Case Else
          MyFrmBD001C = New FrmBD001C
          MyFrmBD001C.WrkRecID = 0
          MyFrmBD001C.MdiParent = Me.ParentForm
          MyFrmBD001C.WrkType = WrkType
          MyFrmBD001C.WrkApp = False
          MyFrmBD001C.Show()
      End Select
    Else
      MyFrmBD001D = New FrmBD001D
      MyFrmBD001D.MdiParent = Me.ParentForm
      MyFrmBD001D.WrkRecID = WrkRecID
      MyFrmBD001D.WrkType = WrkType
      MyFrmBD001D.Show()
    End If
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
End Class






