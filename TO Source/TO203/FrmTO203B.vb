Public Class FrmTO203B
 Inherits System.Windows.Forms.Form
 Dim myTXM35EX As TXM35EX.myData
 Public WrkCat As String
 Friend WithEvents RbBlind As System.Windows.Forms.RadioButton
 Friend WithEvents RbAddl As System.Windows.Forms.RadioButton
 Friend WithEvents RbLocal As System.Windows.Forms.RadioButton
 Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
 Public ds As DataSet = New DataSet

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
Friend WithEvents RbDisabled As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbVets As System.Windows.Forms.RadioButton
Friend WithEvents TxtPosExcd As System.Windows.Forms.TextBox
Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.RbDisabled = New System.Windows.Forms.RadioButton()
    Me.RbVets = New System.Windows.Forms.RadioButton()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbBlind = New System.Windows.Forms.RadioButton()
    Me.RbAddl = New System.Windows.Forms.RadioButton()
    Me.RbLocal = New System.Windows.Forms.RadioButton()
    Me.TxtPosExcd = New System.Windows.Forms.TextBox()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.GroupBox1.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(61, 218)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 6
    Me.BtnFind.Text = "&Find"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(12, 192)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 16)
    Me.Label1.TabIndex = 14
    Me.Label1.Text = "Position To"
    '
    'RbDisabled
    '
    Me.RbDisabled.Location = New System.Drawing.Point(8, 38)
    Me.RbDisabled.Name = "RbDisabled"
    Me.RbDisabled.Size = New System.Drawing.Size(79, 16)
    Me.RbDisabled.TabIndex = 2
    Me.RbDisabled.Text = "Disabled"
    '
    'RbVets
    '
    Me.RbVets.Location = New System.Drawing.Point(8, 60)
    Me.RbVets.Name = "RbVets"
    Me.RbVets.Size = New System.Drawing.Size(70, 16)
    Me.RbVets.TabIndex = 3
    Me.RbVets.Text = "Veterans"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbBlind)
    Me.GroupBox1.Controls.Add(Me.RbAddl)
    Me.GroupBox1.Controls.Add(Me.RbLocal)
    Me.GroupBox1.Controls.Add(Me.RbDisabled)
    Me.GroupBox1.Controls.Add(Me.RbVets)
    Me.GroupBox1.Location = New System.Drawing.Point(12, 40)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(109, 130)
    Me.GroupBox1.TabIndex = 0
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Exemption "
    '
    'RbBlind
    '
    Me.RbBlind.Checked = True
    Me.RbBlind.Location = New System.Drawing.Point(8, 16)
    Me.RbBlind.Name = "RbBlind"
    Me.RbBlind.Size = New System.Drawing.Size(56, 16)
    Me.RbBlind.TabIndex = 6
    Me.RbBlind.TabStop = True
    Me.RbBlind.Text = "Blind"
    '
    'RbAddl
    '
    Me.RbAddl.Location = New System.Drawing.Point(8, 106)
    Me.RbAddl.Name = "RbAddl"
    Me.RbAddl.Size = New System.Drawing.Size(76, 18)
    Me.RbAddl.TabIndex = 5
    Me.RbAddl.Text = "Addl Vets"
    '
    'RbLocal
    '
    Me.RbLocal.Location = New System.Drawing.Point(8, 84)
    Me.RbLocal.Name = "RbLocal"
    Me.RbLocal.Size = New System.Drawing.Size(94, 18)
    Me.RbLocal.TabIndex = 4
    Me.RbLocal.Text = "Local Option"
    '
    'TxtPosExcd
    '
    Me.TxtPosExcd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPosExcd.Location = New System.Drawing.Point(82, 192)
    Me.TxtPosExcd.Name = "TxtPosExcd"
    Me.TxtPosExcd.Size = New System.Drawing.Size(32, 20)
    Me.TxtPosExcd.TabIndex = 5
    Me.Ttp1.SetToolTip(Me.TxtPosExcd, "Enter Code")
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.AllowUserToResizeRows = False
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
    Me.DataGrdView.Location = New System.Drawing.Point(136, 12)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(85, 268)
    Me.DataGrdView.TabIndex = 39
    '
    'FrmTO203B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(233, 292)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.TxtPosExcd)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnFind)
    Me.Controls.Add(Me.GroupBox1)
    Me.Name = "FrmTO203B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.GroupBox1.ResumeLayout(False)
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTO203B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myTXM35EX = New TXM35EX.mydata(MyDBConnect)
  WrkCat = "B"
  Call FormatGrid()
End Sub
Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
  FormatGrid()
  TxtPosExcd.Text = ""
End Sub
Public Sub FormatGrid()
  Call ShowGrid()

  With DataGrdView
    .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
    .RowHeadersWidth = 25
    .Columns(0).Visible = False
    .Columns(1).HeaderText = "Code"
    .Columns(1).Width = 35
  End With
End Sub
Public Sub ShowGrid()
  ds = myTXM35EX.GetAllCat(WrkCat, TxtPosExcd.Text)
  DataGrdView.DataSource = ds.Tables(0)
End Sub
Private Sub FrmTO203B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTO203.SbpScreen.Text = "TO203B"
  MyFrmTO203.TBarPrint.Enabled = True
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
  MyFrmTO203C = New FrmTO203C
  MyFrmTO203C.MdiParent = Me.ParentForm
  MyFrmTO203C.WrkCat = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
  MyFrmTO203C.WrkExcd = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
  MyFrmTO203C.Show()
  Me.Hide()
End Sub
Private Sub RbBlind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbBlind.Click
  WrkCat = "B"
  FormatGrid()
End Sub
Private Sub RbDisabled_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbDisabled.Click
  WrkCat = "D"
  FormatGrid()
End Sub
Private Sub RbVets_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbVets.Click
  WrkCat = "V"
  FormatGrid()
End Sub
Private Sub RbLocal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbLocal.Click
  WrkCat = "L"
  FormatGrid()
End Sub
Private Sub RbAddl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbAddl.Click
  WrkCat = "A"
  FormatGrid()
End Sub
End Class






