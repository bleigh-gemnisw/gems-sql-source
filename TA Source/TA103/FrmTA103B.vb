Public Class FrmTA103B
  Inherits System.Windows.Forms.Form
  Dim myTXCODE As TXCODE.MyData
  Friend ds As DataSet = New DataSet
  Dim WrkTxType As String
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Dim WrkFind As Boolean
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
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbRE As System.Windows.Forms.RadioButton
  Friend WithEvents RbPP As System.Windows.Forms.RadioButton
  Friend WithEvents RbMV As System.Windows.Forms.RadioButton
  Friend WithEvents RbAll As System.Windows.Forms.RadioButton
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbAll = New System.Windows.Forms.RadioButton()
    Me.RbMV = New System.Windows.Forms.RadioButton()
    Me.RbPP = New System.Windows.Forms.RadioButton()
    Me.RbRE = New System.Windows.Forms.RadioButton()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.GroupBox1.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TxtPos
    '
    Me.TxtPos.Location = New System.Drawing.Point(80, 40)
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(32, 20)
    Me.TxtPos.TabIndex = 0
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(120, 40)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 2
    Me.BtnFind.Text = "&Find"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(16, 40)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 16)
    Me.Label1.TabIndex = 14
    Me.Label1.Text = "Position To"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbAll)
    Me.GroupBox1.Controls.Add(Me.RbMV)
    Me.GroupBox1.Controls.Add(Me.RbPP)
    Me.GroupBox1.Controls.Add(Me.RbRE)
    Me.GroupBox1.Location = New System.Drawing.Point(8, 0)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(392, 32)
    Me.GroupBox1.TabIndex = 15
    Me.GroupBox1.TabStop = False
    '
    'RbAll
    '
    Me.RbAll.Checked = True
    Me.RbAll.Location = New System.Drawing.Point(8, 8)
    Me.RbAll.Name = "RbAll"
    Me.RbAll.Size = New System.Drawing.Size(40, 16)
    Me.RbAll.TabIndex = 7
    Me.RbAll.TabStop = True
    Me.RbAll.Text = "&All"
    '
    'RbMV
    '
    Me.RbMV.Location = New System.Drawing.Point(288, 8)
    Me.RbMV.Name = "RbMV"
    Me.RbMV.Size = New System.Drawing.Size(96, 16)
    Me.RbMV.TabIndex = 6
    Me.RbMV.Text = "&Motor Vehicle"
    '
    'RbPP
    '
    Me.RbPP.Location = New System.Drawing.Point(160, 8)
    Me.RbPP.Name = "RbPP"
    Me.RbPP.Size = New System.Drawing.Size(120, 16)
    Me.RbPP.TabIndex = 5
    Me.RbPP.Text = "P&ersonal Property"
    '
    'RbRE
    '
    Me.RbRE.Location = New System.Drawing.Point(64, 8)
    Me.RbRE.Name = "RbRE"
    Me.RbRE.Size = New System.Drawing.Size(88, 16)
    Me.RbRE.TabIndex = 4
    Me.RbRE.Text = "&Real Estate"
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
    Me.DataGrdView.Location = New System.Drawing.Point(8, 70)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(429, 366)
    Me.DataGrdView.TabIndex = 20
    '
    'FrmTA103B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(449, 448)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtPos)
    Me.Controls.Add(Me.BtnFind)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "FrmTA103B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.GroupBox1.ResumeLayout(False)
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region
  Private Sub FrmTA103B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXCODE = New TXCODE.MyData(myDBConnect)
    WrkTxType = ""
    Call FormatGrid()
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    ds = myTXCODE.PosData(Val(TxtPos.Text), WrkTxType)
    WrkFind = True
    FormatGrid()
    WrkFind = False
    TxtPos.Text() = ""
  End Sub
  Public Sub FormatGrid()
    ShowGrid()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "Code"
      .Columns(0).Width = 40
      .Columns(1).HeaderText = "Type"
      .Columns(1).Width = 35
      .Columns(2).HeaderText = "Description"
      .Columns(2).Width = 200
      .Columns(3).HeaderText = "OPM"
      .Columns(3).Width = 35
      .Columns(4).HeaderText = "GRP"
      .Columns(4).Width = 35
      .Columns(5).Visible = False
      .Columns(6).HeaderText = "MV"
      .Columns(6).Width = 35
    End With
  End Sub
  Public Sub ShowGrid()
    If RbAll.Checked Then
      ds = myTXCODE.PosData(0, "")
    Else
      ds = myTXCODE.GetAllType(WrkTxType)
    End If
    DataGrdView.DataSource = ds.Tables(0)
    myTXCODE.CloseFile()
  End Sub
  Private Sub FrmTA103B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA103.SbpScreen.Text = "TA103B"
    MyFrmTA103.TBarPrint.Enabled = True
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub TxtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPos.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
    If e.KeyChar = MyUtils.VbKeyEnter Then
      ds = myTXCODE.PosData(Val(TxtPos.Text), WrkTxType)
      WrkFind = True
      FormatGrid()
      WrkFind = False
      TxtPos.Text() = ""
    End If
  End Sub
  Private Sub RbRE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbRE.CheckedChanged
    WrkTxType = "R"
    Call FormatGrid()
  End Sub
  Private Sub RbPP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbPP.CheckedChanged
    WrkTxType = "P"
    Call FormatGrid()
  End Sub
  Private Sub RbMV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbMV.CheckedChanged
    WrkTxType = "M"
    Call FormatGrid()
  End Sub
  Private Sub RbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbAll.CheckedChanged
    If IsNothing(WrkTxType) Then Exit Sub
    WrkTxType = ""
    Call FormatGrid()
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    MyFrmTA103C = New FrmTA103C
    MyFrmTA103C.MdiParent = Me.ParentForm
    MyFrmTA103C.WrkTxCode = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    MyFrmTA103C.WrkTxType = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
    MyFrmTA103C.Show()
    Me.Hide()
  End Sub

End Class
