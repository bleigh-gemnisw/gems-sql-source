Public Class FrmTS004B
  Inherits System.Windows.Forms.Form
  Dim myMFTRAN As MFTRAN.myData
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtyear As System.Windows.Forms.TextBox
  Friend WithEvents txtposmfname As System.Windows.Forms.TextBox
  Friend ds As DataSet = New DataSet
Dim wrkyear As Integer
Dim wrkmonth As Integer

Dim wrkmfcatg As String
Dim wrkmfnam As String
Dim wrkmfadd1 As String
Dim wrkstampd As Integer
Friend WithEvents BtnNext As System.Windows.Forms.Button
Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
Dim wrkstampt As Integer

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
  Friend WithEvents TxtPosmfcatg As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.TxtPosmfcatg = New System.Windows.Forms.TextBox()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.txtyear = New System.Windows.Forms.TextBox()
    Me.txtposmfname = New System.Windows.Forms.TextBox()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TxtPosmfcatg
    '
    Me.TxtPosmfcatg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPosmfcatg.Location = New System.Drawing.Point(87, 33)
    Me.TxtPosmfcatg.Name = "TxtPosmfcatg"
    Me.TxtPosmfcatg.Size = New System.Drawing.Size(32, 20)
    Me.TxtPosmfcatg.TabIndex = 0
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(352, 27)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 2
    Me.BtnFind.Text = "&Find"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(23, 33)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 16)
    Me.Label1.TabIndex = 14
    Me.Label1.Text = "Position To"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(23, 9)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(64, 16)
    Me.Label2.TabIndex = 20
    Me.Label2.Text = "Year"
    '
    'txtyear
    '
    Me.txtyear.Location = New System.Drawing.Point(87, 9)
    Me.txtyear.MaxLength = 4
    Me.txtyear.Name = "txtyear"
    Me.txtyear.Size = New System.Drawing.Size(32, 20)
    Me.txtyear.TabIndex = 19
    '
    'txtposmfname
    '
    Me.txtposmfname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtposmfname.Location = New System.Drawing.Point(125, 33)
    Me.txtposmfname.MaxLength = 35
    Me.txtposmfname.Name = "txtposmfname"
    Me.txtposmfname.Size = New System.Drawing.Size(221, 20)
    Me.txtposmfname.TabIndex = 21
    '
    'BtnNext
    '
    Me.BtnNext.Location = New System.Drawing.Point(411, 27)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(53, 24)
    Me.BtnNext.TabIndex = 28
    Me.BtnNext.Text = "&Next"
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
    Me.DataGrdView.Location = New System.Drawing.Point(12, 70)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(674, 365)
    Me.DataGrdView.TabIndex = 39
    '
    'FrmTS004B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(698, 447)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.BtnNext)
    Me.Controls.Add(Me.txtposmfname)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.txtyear)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtPosmfcatg)
    Me.Controls.Add(Me.BtnFind)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "FrmTS004B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region
Private Sub TS004B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myMFTRAN = New MFTRAN.mydata(MyDBConnect)

  wrkyear = Year(Today)
  wrkmonth = Month(Today)
  If wrkmonth >= 11 Then
    wrkyear = wrkyear + 1
  End If
  txtyear.Text = wrkyear

  Call FormatGrid()
End Sub
Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
  FormatGrid()
 End Sub
Public Sub FormatGrid()
  ShowGrid()
  With DataGrdView
    .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
    .RowHeadersWidth = 25
    .Columns(0).HeaderText = "Cat"
    .Columns(0).Width = 50
    .Columns(1).HeaderText = "Name"
    .Columns(1).Width = 150
    .Columns(2).HeaderText = "Reg#"
    .Columns(2).Width = 90
    .Columns(3).HeaderText = "Number"
    .Columns(3).Width = 90
    .Columns(4).HeaderText = "Year"
    .Columns(4).Width = 60
    .Columns(5).HeaderText = "Street"
    .Columns(5).Width = 150
    .Columns(6).Visible = False
    .Columns(7).Visible = False
  End With
End Sub
Public Sub ShowGrid()
    ds = myMFTRAN.GetViewbyYear(MyUtils.CnvSng(txtyear.Text), TxtPosmfcatg.Text, txtposmfname.Text, 50)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
End Sub
Private Sub TS004B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyfrmTS004.SbpScreen.Text = "TS004B"
  MyfrmTS004.TBarPrint.Enabled = False
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
    Dim I As Integer
    I = ds.Tables(0).Rows.Count - 1
    txtposmfname.Text = DataGrdView.Item(1, I).Value
    TxtPosmfcatg.Text = DataGrdView.Item(0, I).Value
    FormatGrid()
    txtposmfname.Text = ""
    TxtPosmfcatg.Text = ""
End Sub
Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
MyfrmTS004C = New FrmTS004C
  MyfrmTS004C.MdiParent = Me.ParentForm
  MyfrmTS004C.wrkmfyear = MyUtils.CnvSng(txtyear.Text)
  MyfrmTS004C.wrkmfcatg = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
  MyfrmTS004C.wrkmfnam = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
  MyfrmTS004C.wrkmfadd1 = DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value
  MyfrmTS004C.wrkstampd = DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value
  MyfrmTS004C.wrkstampt = DataGrdView.Item(7, DataGrdView.CurrentRow.Index).Value

  MyfrmTS004C.Show()
  Me.Hide()
End Sub
Private Sub txtyear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtyear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






