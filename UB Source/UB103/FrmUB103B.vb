Public Class FrmUB103B
 Inherits System.Windows.Forms.Form
 Dim myUTRATEAS As UTRATEAS.myData
 Dim myUTRATEMT As UTRATEMT.myData
 Dim myUTRATEUS As UTRATEUS.myData
 Friend ds As DataSet = New DataSet
 Dim Wrktype As String
 Dim Dsptype As String
 Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
 Dim Wrkcode As String

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
Friend WithEvents RbAssess As System.Windows.Forms.RadioButton
Friend WithEvents RbMeter As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbUsage As System.Windows.Forms.RadioButton
Friend WithEvents TxtPosType As System.Windows.Forms.TextBox
Friend WithEvents TxtPosCode As System.Windows.Forms.TextBox
Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.TxtPosType = New System.Windows.Forms.TextBox()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.RbAssess = New System.Windows.Forms.RadioButton()
    Me.RbMeter = New System.Windows.Forms.RadioButton()
    Me.RbUsage = New System.Windows.Forms.RadioButton()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.TxtPosCode = New System.Windows.Forms.TextBox()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TxtPosType
    '
    Me.TxtPosType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPosType.Location = New System.Drawing.Point(80, 48)
    Me.TxtPosType.Name = "TxtPosType"
    Me.TxtPosType.Size = New System.Drawing.Size(24, 20)
    Me.TxtPosType.TabIndex = 4
    Me.Ttp1.SetToolTip(Me.TxtPosType, "Enter Type")
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(144, 48)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 6
    Me.BtnFind.Text = "&Find"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(16, 48)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 16)
    Me.Label1.TabIndex = 14
    Me.Label1.Text = "Position To"
    '
    'RbAssess
    '
    Me.RbAssess.Location = New System.Drawing.Point(24, 16)
    Me.RbAssess.Name = "RbAssess"
    Me.RbAssess.Size = New System.Drawing.Size(88, 16)
    Me.RbAssess.TabIndex = 1
    Me.RbAssess.Text = "Assessment"
    '
    'RbMeter
    '
    Me.RbMeter.Location = New System.Drawing.Point(136, 16)
    Me.RbMeter.Name = "RbMeter"
    Me.RbMeter.Size = New System.Drawing.Size(64, 16)
    Me.RbMeter.TabIndex = 2
    Me.RbMeter.Text = "Metered"
    '
    'RbUsage
    '
    Me.RbUsage.Location = New System.Drawing.Point(224, 16)
    Me.RbUsage.Name = "RbUsage"
    Me.RbUsage.Size = New System.Drawing.Size(56, 18)
    Me.RbUsage.TabIndex = 3
    Me.RbUsage.Text = "Usage"
    '
    'GroupBox1
    '
    Me.GroupBox1.Location = New System.Drawing.Point(16, 0)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(272, 40)
    Me.GroupBox1.TabIndex = 0
    Me.GroupBox1.TabStop = False
    '
    'TxtPosCode
    '
    Me.TxtPosCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPosCode.Location = New System.Drawing.Point(104, 48)
    Me.TxtPosCode.Name = "TxtPosCode"
    Me.TxtPosCode.Size = New System.Drawing.Size(32, 20)
    Me.TxtPosCode.TabIndex = 5
    Me.Ttp1.SetToolTip(Me.TxtPosCode, "Enter Code")
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
    Me.DataGrdView.Location = New System.Drawing.Point(12, 78)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(375, 318)
    Me.DataGrdView.TabIndex = 20
    '
    'FrmUB103B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(399, 408)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.TxtPosCode)
    Me.Controls.Add(Me.RbUsage)
    Me.Controls.Add(Me.RbMeter)
    Me.Controls.Add(Me.RbAssess)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtPosType)
    Me.Controls.Add(Me.BtnFind)
    Me.Controls.Add(Me.GroupBox1)
    Me.Name = "FrmUB103B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmUB103B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myUTRATEAS = New UTRATEAS.mydata(MyDBConnect)
  myUTRATEMT = New UTRATEMT.mydata(MyDBConnect)
  myUTRATEUS = New UTRATEUS.mydata(MyDBConnect)
  Wrktype = ""
  RbAssess.Checked = True
  Dsptype = "A"
  Call FormatGrid()
End Sub
Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
  If Not TxtPosType.Text = "" Then
    Wrktype = TxtPosType.Text
    Wrkcode = TxtPosCode.Text
  Else
    TxtPosType.Text = ""
    TxtPosCode.Text = ""
  End If
  FormatGrid()
  TxtPosType.Text = ""
  TxtPosCode.Text = ""
End Sub
Public Sub FormatGrid()
  Call ShowGrid()

  With DataGrdView
    .Columns(0).HeaderText = "Type"
    .Columns(0).Width = 30
    .Columns(1).HeaderText = "Code"
    .Columns(1).Width = 40
  End With
Select Case Dsptype
    Case "A"
      GridNameAssess()
    Case "M"
      GridNameMeter()
    Case "U"
      GridNameUsage()
  End Select
End Sub
Public Sub ShowGrid()
  Select Case Dsptype
    Case "A"
      If Wrktype = "" Then
        ds = myUTRATEAS.GetAllData
      Else
      ds = myUTRATEAS.PosData(TxtPosType.Text, TxtPosCode.Text)
      End If
    Case "M"
      If Wrktype = "" Then
        ds = myUTRATEMT.GetAllData
      Else
      ds = myUTRATEMT.PosData(TxtPosType.Text, TxtPosCode.Text, 0)
      End If
    Case "U"
      If Wrktype = "" Then
        ds = myUTRATEUS.GetAllData
      Else
      ds = myUTRATEUS.PosData(TxtPosType.Text, TxtPosCode.Text)
      End If
  End Select
  DataGrdView.DataSource = ds.Tables(0)
End Sub
Private Sub GridNameAssess()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).Width = 35
      .Columns(1).Width = 35
      .Columns(2).HeaderText = "Description"
      .Columns(2).Width = 235
      .Columns(3).Visible = False
      .Columns(4).Visible = False
      .Columns(5).Visible = False
      .Columns(6).Visible = False
      .Columns(7).Visible = False
      .Columns(8).Visible = False
      .Columns(9).Visible = False
      .Columns(10).Visible = False
      .Columns(11).Visible = False
      .Columns(12).Visible = False
      .Columns(13).Visible = False
    End With
  End Sub
Private Sub GridNameMeter()
   With DataGrdView
    .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
    .RowHeadersWidth = 25
    .Columns(0).Width = 35
    .Columns(1).Width = 35
    .Columns(2).HeaderText = "Tier"
    .Columns(2).Width = 60
    .Columns(3).HeaderText = "Description"
    .Columns(3).Width = 125
    .Columns(4).HeaderText = "Rate"
    .Columns(4).Width = 80
  End With
End Sub
Private Sub GridNameUsage()
  With DataGrdView
    .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
    .RowHeadersWidth = 25
    .Columns(0).Width = 35
    .Columns(1).Width = 35
    .Columns(2).HeaderText = "Description"
    .Columns(2).Width = 235
    .Columns(3).Visible = False
    .Columns(4).Visible = False
    .Columns(5).Visible = False
    .Columns(6).Visible = False
    .Columns(7).Visible = False
    .Columns(8).Visible = False
  End With
End Sub

Private Sub FrmUB103B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB103.SbpScreen.Text = "UB103B"
  MyFrmUB103.TBarPrint.Enabled = True
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
Select Case Dsptype
    Case "A"
      MyFrmUB103C_AS = New FrmUB103C_AS
      MyFrmUB103C_AS.MdiParent = Me.ParentForm
      MyFrmUB103C_AS.Wrkratype = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      MyFrmUB103C_AS.Wrkracode = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
      MyFrmUB103C_AS.Show()
      Me.Hide()
    Case "M"
      MyFrmUB103C_MT = New FrmUB103C_MT
      MyFrmUB103C_MT.MdiParent = Me.ParentForm
      MyFrmUB103C_MT.Wrkrmtype = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      MyFrmUB103C_MT.Wrkrmcode = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
      MyFrmUB103C_MT.Wrkrmtier = DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value
      MyFrmUB103C_MT.Show()
      Me.Hide()
    Case "U"
      MyFrmUB103C_US = New FrmUB103C_US
      MyFrmUB103C_US.MdiParent = Me.ParentForm
      MyFrmUB103C_US.Wrkrutype = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      MyFrmUB103C_US.Wrkrucode = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
      MyFrmUB103C_US.Show()
      Me.Hide()
  End Select

End Sub
Private Sub TxtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPosType.KeyPress
  If e.KeyChar = MyUtils.VbKeyEnter Then
    Wrktype = TxtPosType.Text
    Wrkcode = TxtPosCode.Text
    FormatGrid()
    TxtPosType.Text = ""
    TxtPosCode.Text = ""
  End If
End Sub

  Private Sub RbAssess_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbAssess.Click
  Call rbstatus()
End Sub
  Private Sub RbMeter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbMeter.Click
  Call rbstatus()
End Sub
  Private Sub RbUsage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbUsage.Click
  Call rbstatus()
End Sub
Private Sub rbstatus()
  If RbAssess.Checked = True Then
    Dsptype = "A"
  Call FormatGrid()
  End If
  If RbMeter.Checked = True Then
    Dsptype = "M"
  Call FormatGrid()
  End If
 If RbUsage.Checked = True Then
    Dsptype = "U"
  Call FormatGrid()
  End If

End Sub

Private Sub RbMeter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbMeter.CheckedChanged

End Sub

Private Sub RbAssess_CheckedChanged(sender As Object, e As EventArgs) Handles RbAssess.CheckedChanged

End Sub
End Class






