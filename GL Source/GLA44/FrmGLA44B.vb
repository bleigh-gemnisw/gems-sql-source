Public Class FrmGLA44B
  Inherits System.Windows.Forms.Form
  Dim myMUNMIL As MUNMIL.myData
  Dim myMUNMILD As MUNMILD.myData
  Friend WithEvents RbAccts As System.Windows.Forms.RadioButton
  Friend WithEvents RbDs As System.Windows.Forms.RadioButton
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Dim ds As DataSet = New DataSet

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
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.RbAccts = New System.Windows.Forms.RadioButton()
    Me.RbDs = New System.Windows.Forms.RadioButton()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(138, 5)
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
    'TxtPos
    '
    Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPos.Location = New System.Drawing.Point(86, 8)
    Me.TxtPos.MaxLength = 4
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(46, 20)
    Me.TxtPos.TabIndex = 0
    '
    'RbAccts
    '
    Me.RbAccts.AutoSize = True
    Me.RbAccts.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbAccts.Checked = True
    Me.RbAccts.Location = New System.Drawing.Point(219, 12)
    Me.RbAccts.Name = "RbAccts"
    Me.RbAccts.Size = New System.Drawing.Size(70, 17)
    Me.RbAccts.TabIndex = 19
    Me.RbAccts.TabStop = True
    Me.RbAccts.Text = "Accounts"
    Me.RbAccts.UseVisualStyleBackColor = True
    '
    'RbDs
    '
    Me.RbDs.AutoSize = True
    Me.RbDs.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbDs.Location = New System.Drawing.Point(310, 12)
    Me.RbDs.Name = "RbDs"
    Me.RbDs.Size = New System.Drawing.Size(87, 17)
    Me.RbDs.TabIndex = 20
    Me.RbDs.Text = "Debt Service"
    Me.RbDs.UseVisualStyleBackColor = True
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
    Me.DataGrdView.Location = New System.Drawing.Point(12, 35)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(508, 353)
    Me.DataGrdView.TabIndex = 201
    '
    'FrmGLA44B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(532, 400)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.RbDs)
    Me.Controls.Add(Me.RbAccts)
    Me.Controls.Add(Me.TxtPos)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnFind)
    Me.Name = "FrmGLA44B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

 Private Sub FrmGLA44B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
   myMUNMIL = New MUNMIL.MyData()
   myMUNMIL.MyDBConn = myDBConnect
   myMUNMILD = New MUNMILD.MyData()
   myMUNMILD.MyDBConn = myDBConnect
   Call FormatGridAccts()
End Sub
Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
  If RbAccts.Checked Then
    FormatGridAccts()
  Else
    FormatGridDS()
  End If
  TxtPos.Text = String.Empty
End Sub
Public Sub FormatGridAccts()
  Call ShowGridAccts()
  With DataGrdView
    .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
    .RowHeadersWidth = 25
    .Columns(0).HeaderText = "Code"
    .Columns(0).Width = 50
    .Columns(1).HeaderText = "Orig"
    .Columns(1).Width = 60
    .Columns(2).HeaderText = "Object"
    .Columns(2).Width = 50
    .Columns(3).HeaderText = "Description"
    .Columns(3).Width = 250
    .Columns(4).HeaderText = "DR/CR"
    .Columns(4).Width = 45
   End With
End Sub
Public Sub ShowGridAccts()
  ds = myMUNMIL.PosData(TxtPos.Text, 0)
  DataGrdView.DataSource = ds.Tables(0)
  DataGrdView.Refresh()
End Sub
Public Sub FormatGridDS()
  Call ShowGridDS()
  With DataGrdView
    .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
    .RowHeadersWidth = 25
    .Columns(0).HeaderText = "Year"
    .Columns(0).Width = 50
    .Columns(1).HeaderText = "Rate"
    .Columns(1).Width = 60
   End With
End Sub
Public Sub ShowGridDS()
  ds = myMUNMILD.PosData(MyUtils.CnvSng(TxtPos.Text), 0)
  DataGrdView.DataSource = ds.Tables(0)
  DataGrdView.Refresh()
End Sub
Private Sub FrmGLA44B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmGLA44.SbpScreen.Text = "GLA44B"
  MyFrmGLA44.TBarPrint.Enabled = True
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
  If RbAccts.Checked Then
    MyFrmGLA44C = New FrmGLA44C
    MyFrmGLA44C.MdiParent = Me.ParentForm
    MyFrmGLA44C.WrkCode = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    MyFrmGLA44C.Show()
  Else
    MyFrmGLA44D = New FrmGLA44D
    MyFrmGLA44D.MdiParent = Me.ParentForm
    MyFrmGLA44D.WrkYear = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    MyFrmGLA44D.Show()
  End If
  Me.Hide()
End Sub
Public Sub PrintData()
  MyCrViewer = New FrmCrViewer
  MyCrViewer.Wrkds = ds.Copy
  MyCrViewer.Show()
End Sub
  Private Sub RbAccts_Click(sender As Object, e As EventArgs) Handles RbAccts.Click
    FormatGridAccts()
  End Sub
  Private Sub RbDs_Click(sender As Object, e As EventArgs) Handles RbDs.Click
    FormatGridDS()
  End Sub
End Class
