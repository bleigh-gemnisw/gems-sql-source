Public Class FrmIA001B
  Inherits System.Windows.Forms.Form
	Dim myGNETUSER As GNETUSER.myData
  Dim WrkGNETUSER As String
 Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
	Friend ds As DataSet = New DataSet

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
    Me.TxtPos.Location = New System.Drawing.Point(80, 16)
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(176, 20)
    Me.TxtPos.TabIndex = 0
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(264, 16)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 2
    Me.BtnFind.Text = "Find"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(16, 16)
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
    Me.DataGrdView.Location = New System.Drawing.Point(12, 46)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(462, 350)
    Me.DataGrdView.TabIndex = 39
    '
    'FrmIA001B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(486, 408)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtPos)
    Me.Controls.Add(Me.BtnFind)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "FrmIA001B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmIA001B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myGNETUSER = New GNETUSER.MyData()
    myGNETUSER.MyDBConn = myDBConnect
    WrkGNETUSER = ""
    Call FormatGrid()
End Sub
Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    WrkGNETUSER = TxtPos.Text
    FormatGrid()
    WrkGNETUSER = ""
End Sub
Public Sub FormatGrid()
    ShowGrid()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "User Id"
      .Columns(0).Width = 100
      .Columns(1).Visible = False
      .Columns(2).HeaderText = "Group"
      .Columns(2).Width = 100
      .Columns(3).HeaderText = "Name"
      .Columns(3).Width = 150
      .Columns(4).HeaderText = "Status"
      .Columns(4).Width = 60
    End With
End Sub
Public Sub ShowGrid()
  ds = myGNETUSER.PosData(TxtPos.Text)
  DataGrdView.DataSource = ds.Tables(0)
  DataGrdView.Refresh()
End Sub
Private Sub FrmIA001B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmIA001.SbpScreen.Text = "IA001B"
    MyFrmIA001.TBarPrint.Enabled = True
    MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub TxtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPos.KeyPress
    If e.KeyChar = MyUtils.VbKeyEnter Then
        FormatGrid()
    End If
End Sub
Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    MyFrmIA001C = New FrmIA001C
    MyFrmIA001C.MdiParent = Me.ParentForm
    MyFrmIA001C.WrkGNETUSER = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    MyFrmIA001C.Show()
    Me.Hide()
End Sub
End Class
