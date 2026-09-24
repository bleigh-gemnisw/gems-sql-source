Public Class FrmTX117B
  Inherits System.Windows.Forms.Form
  Dim myTXLEASE As TXLEASE.myData
  Friend ds As DataSet = New DataSet
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbName As System.Windows.Forms.RadioButton
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Friend WithEvents RbCode As System.Windows.Forms.RadioButton
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
    Friend WithEvents TxtCode As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.TxtCode = New System.Windows.Forms.TextBox()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbName = New System.Windows.Forms.RadioButton()
    Me.RbCode = New System.Windows.Forms.RadioButton()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.GroupBox1.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TxtCode
    '
    Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode.Location = New System.Drawing.Point(52, 5)
    Me.TxtCode.MaxLength = 2
    Me.TxtCode.Name = "TxtCode"
    Me.TxtCode.Size = New System.Drawing.Size(29, 20)
    Me.TxtCode.TabIndex = 0
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(87, 2)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 2
    Me.BtnFind.Text = "&Find"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(16, 8)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 20)
    Me.Label1.TabIndex = 14
    Me.Label1.Text = "Code"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbName)
    Me.GroupBox1.Controls.Add(Me.RbCode)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(427, 0)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(137, 37)
    Me.GroupBox1.TabIndex = 21
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Sort by"
    '
    'RbName
    '
    Me.RbName.AutoSize = True
    Me.RbName.Checked = True
    Me.RbName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbName.Location = New System.Drawing.Point(71, 14)
    Me.RbName.Name = "RbName"
    Me.RbName.Size = New System.Drawing.Size(53, 17)
    Me.RbName.TabIndex = 21
    Me.RbName.TabStop = True
    Me.RbName.Text = "Name"
    Me.RbName.UseVisualStyleBackColor = True
    '
    'RbCode
    '
    Me.RbCode.AutoSize = True
    Me.RbCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCode.Location = New System.Drawing.Point(6, 14)
    Me.RbCode.Name = "RbCode"
    Me.RbCode.Size = New System.Drawing.Size(50, 17)
    Me.RbCode.TabIndex = 20
    Me.RbCode.Text = "Code"
    Me.RbCode.UseVisualStyleBackColor = True
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
    Me.DataGrdView.Location = New System.Drawing.Point(12, 43)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(552, 353)
    Me.DataGrdView.TabIndex = 37
    '
    'FrmTX117B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(576, 408)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.TxtCode)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnFind)
    Me.Name = "FrmTX117B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTX117B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myTXLEASE = New TXLEASE.mydata(MyDBConnect)
  Call FormatGrid()
End Sub
Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
  FormatGrid()
End Sub
Public Sub FormatGrid()
  Call ShowGrid()
  With DataGrdView
    .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
    .RowHeadersWidth = 25
    .Columns(0).HeaderText = "Code"
    .Columns(0).Width = 35
    .Columns(1).HeaderText = "Name"
    .Columns(1).Width = 175
    .Columns(2).HeaderText = "Address 1"
    .Columns(2).Width = 150
    .Columns(3).Visible = False
    .Columns(4).HeaderText = "City"
    .Columns(4).Width = 100
    .Columns(5).HeaderText = "State"
    .Columns(5).Width = 35
    .Columns(6).Visible = False
    .Columns(7).Visible = False
    .Columns(8).Visible = False
  End With
End Sub
Public Sub ShowGrid()
  Dim dv As DataView = New DataView
  ds = myTXLEASE.PosData(TxtCode.Text)
  If MyFrmTX117B.RbCode.Checked Then
    dv.Table = ds.Tables(0)
    dv.Sort = "code"
  Else
    dv.Table = ds.Tables(0)
    dv.Sort = "name"
  End If
  DataGrdView.DataSource = dv
  DataGrdView.Refresh()
  dv = Nothing
End Sub
Private Sub FrmTX117B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX117.SbpScreen.Text = "TX117B"
  MyFrmTX117.TBarPrint.Enabled = True
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub TxtCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode.KeyPress
  If e.KeyChar = MyUtils.VbKeyEnter Then
    MyFrmTX117C = New FrmTX117C
    MyFrmTX117C.MdiParent = Me.ParentForm
    MyFrmTX117C.WrkCode = TxtCode.Text
    MyFrmTX117C.Show()
    Me.Hide()
  End If
End Sub
Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
  MyFrmTX117C = New FrmTX117C
  MyFrmTX117C.MdiParent = Me.ParentForm
  MyFrmTX117C.WrkCode = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
  MyFrmTX117C.Show()
  Me.Hide()
End Sub
Private Sub RbCode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbCode.Click
  FormatGrid()
End Sub
Private Sub RbName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbName.Click
  FormatGrid()
End Sub
End Class






