Public Class FrmTX110B
  Inherits System.Windows.Forms.Form
	Dim myTXZIP As TXZIP.myData
  Friend ds As DataSet = New DataSet
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Dim Wrkzip5 As Single
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
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
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
    Me.DataGrdView.Location = New System.Drawing.Point(12, 38)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(408, 207)
    Me.DataGrdView.TabIndex = 37
    '
    'FrmTX110B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(432, 257)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.TxtPos)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnFind)
    Me.Name = "FrmTX110B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTX110B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myTXZIP = New TXZIP.mydata(MyDBConnect)
  Wrkzip5 = 0
  Call FormatGrid()
End Sub
Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
  Wrkzip5 = TxtPos.Text
  FormatGrid()
  Wrkzip5 = ""
End Sub
Public Sub FormatGrid()
  Call ShowGrid()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "ZIP Code"
      .Columns(0).Width = 55
      .Columns(0).DefaultCellStyle.Format = ("00000")
      .Columns(1).HeaderText = "Town Name"
      .Columns(1).Width = 300
    End With
End Sub
Public Sub ShowGrid()
  If Wrkzip5 = 0 Then
    ds = myTXZIP.GetAllData
    Else
  End If
  DataGrdView.DataSource = ds.Tables(0)
  DataGrdView.Refresh()
End Sub
Private Sub FrmTX110B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX110.SbpScreen.Text = "TX110B"
  MyFrmTX110.TBarPrint.Enabled = True
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub TxtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPos.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  If e.KeyChar = MyUtils.VbKeyEnter Then
    Wrkzip5 = TxtPos.Text
    FormatGrid()
    Wrkzip5 = ""
    Exit Sub
  End If
End Sub
Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
  MyFrmTX110C = New FrmTX110C
  MyFrmTX110C.MdiParent = Me.ParentForm
  MyFrmTX110C.wrkzip5 = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
  MyFrmTX110C.wrkziptwn = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
  MyFrmTX110C.Show()
  Me.Hide()
End Sub
End Class






