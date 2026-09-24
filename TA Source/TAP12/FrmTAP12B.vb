Public Class FrmTAP12B
  Inherits System.Windows.Forms.Form
  Dim myTXDCEX As TXDCEX.myData
	Dim myTXDCFRM As TXDCFRM.myData
	Friend ds As DataSet = New DataSet
	Dim WrkYear As Integer
 Friend WithEvents LblYear As System.Windows.Forms.Label
 Friend WithEvents Label29 As System.Windows.Forms.Label
 Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
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
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TxtPos
    '
    Me.TxtPos.Location = New System.Drawing.Point(84, 41)
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(32, 20)
    Me.TxtPos.TabIndex = 0
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(124, 41)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 2
    Me.BtnFind.Text = "&Find"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(20, 41)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 16)
    Me.Label1.TabIndex = 14
    Me.Label1.Text = "Position To"
    '
    'LblYear
    '
    Me.LblYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblYear.Location = New System.Drawing.Point(61, 8)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(33, 18)
    Me.LblYear.TabIndex = 215
    Me.LblYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label29
    '
    Me.Label29.Location = New System.Drawing.Point(20, 9)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(35, 17)
    Me.Label29.TabIndex = 216
    Me.Label29.Text = "Year"
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
    Me.DataGrdView.Location = New System.Drawing.Point(12, 71)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(394, 358)
    Me.DataGrdView.TabIndex = 217
    '
    'FrmTAP12B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(418, 441)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.Label29)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtPos)
    Me.Controls.Add(Me.BtnFind)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "FrmTAP12B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region
Private Sub FrmTAP12B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myTXDCEX = New TXDCEX.mydata(MyDBConnect)
  myTXDCFRM = New TXDCFRM.mydata(MyDBConnect)
  WrkCode = ""
  myTXDCFRM.GetOneRecordP(1)
  LblYear.Text = myTXDCFRM._CURRYR
  WrkYear = myTXDCFRM._CURRYR
  Call FormatGrid()
End Sub
Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
  WrkCode = TxtPos.Text
  FormatGrid()
  WrkCode = ""
 End Sub
Public Sub FormatGrid()
  ShowGrid()
  With DataGrdView
    .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
    .RowHeadersWidth = 25
    .Columns(0).Visible = False
    .Columns(1).HeaderText = "Code"
    .Columns(1).Width = 40
    .Columns(2).HeaderText = "Description"
    .Columns(2).Width = 245
    .Columns(3).HeaderText = "Default"
    .Columns(3).Width = 60
  End With
End Sub
Public Sub ShowGrid()
  If WrkCode = "" Then
    ds = myTXDCEX.GetAllYear(WrkYear)
  Else
    ds = myTXDCEX.PosData(WrkYear, TxtPos.Text)
  End If
  DataGrdView.DataSource = ds.Tables(0)
  DataGrdView.Refresh()
End Sub
Private Sub FrmTAP12B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTAP12.SbpScreen.Text = "TAP12B"
  MyFrmTAP12.TBarPrint.Enabled = True
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub TxtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPos.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  If e.KeyChar = MyUtils.VbKeyEnter Then
    ds = myTXDCEX.PosData(WrkYear, TxtPos.Text)
    FormatGrid()
    TxtPos.Text() = ""
  End If
End Sub
Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
  MyFrmTAP12C = New FrmTAP12C
  MyFrmTAP12C.MdiParent = Me.ParentForm
  MyFrmTAP12C.WrkYear = WrkYear
  MyFrmTAP12C.WrkCode = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
  MyFrmTAP12C.Show()
  Me.Hide()
End Sub
End Class






