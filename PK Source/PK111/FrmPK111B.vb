Public Class FrmPK111B
  Inherits System.Windows.Forms.Form
  Dim myPKOFCR As PKOFCR.myData
  Friend ds As DataSet = New DataSet
  Friend WithEvents ChkDelete As System.Windows.Forms.CheckBox
  Friend WithEvents DataGrdView As DataGridView
  Dim WrkCode As String


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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtPos As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.ChkDelete = New System.Windows.Forms.CheckBox()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TxtPos
    '
    Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPos.Location = New System.Drawing.Point(80, 8)
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(40, 20)
    Me.TxtPos.TabIndex = 0
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(128, 8)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 2
    Me.BtnFind.Text = "&Find"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(16, 8)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 16)
    Me.Label1.TabIndex = 14
    Me.Label1.Text = "Position To"
    '
    'ChkDelete
    '
    Me.ChkDelete.AutoSize = True
    Me.ChkDelete.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkDelete.Location = New System.Drawing.Point(187, 12)
    Me.ChkDelete.Name = "ChkDelete"
    Me.ChkDelete.Size = New System.Drawing.Size(99, 17)
    Me.ChkDelete.TabIndex = 19
    Me.ChkDelete.Text = "Show Deleted?"
    Me.ChkDelete.UseVisualStyleBackColor = True
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView.DefaultCellStyle = DataGridViewCellStyle2
    Me.DataGrdView.Location = New System.Drawing.Point(12, 38)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(303, 353)
    Me.DataGrdView.TabIndex = 42
    '
    'FrmPK111B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(330, 403)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.ChkDelete)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtPos)
    Me.Controls.Add(Me.BtnFind)
    Me.Name = "FrmPK111B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmPK111B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myPKOFCR = New PKOFCR.MyData(myDBConnect)
    WrkCode = ""
    Call FormatGrid()
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    WrkCode = TxtPos.Text
    FormatGrid()
    TxtPos.Text = ""
  End Sub
  Public Sub FormatGrid()
    Call ShowGrid()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "Code"
      .Columns(0).Width = 50
      .Columns(1).HeaderText = "Name"
      .Columns(1).Width = 150
      .Columns(2).HeaderText = "Del"
      .Columns(2).Width = 50
    End With
  End Sub
  Public Sub ShowGrid()
    ds = myPKOFCR.PosData(TxtPos.Text, ChkDelete.Checked)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
  End Sub
  Private Sub FrmPK111B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmPK111.SbpScreen.Text = "PK111B"
    MyFrmPK111.TBarPrint.Enabled = True
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub TxtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPos.KeyPress
    If e.KeyChar = MyUtils.VbKeyEnter Then
      WrkCode = TxtPos.Text
      FormatGrid()
      TxtPos.Text = ""
      Exit Sub
    End If
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    MyFrmPK111C = New FrmPK111C
    MyFrmPK111C.MdiParent = Me.ParentForm
    MyFrmPK111C.WrkCode = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    MyFrmPK111C.WrkAddMode = False
    MyFrmPK111C.Show()
    Me.Hide()
  End Sub
End Class
