Public Class FrmTA203B
Inherits System.Windows.Forms.Form
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
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbSU As System.Windows.Forms.RadioButton
Friend WithEvents RbRE As System.Windows.Forms.RadioButton
Friend WithEvents RbMV As System.Windows.Forms.RadioButton
Friend WithEvents RbPP As System.Windows.Forms.RadioButton
Friend WithEvents RbGross As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents TxtMin As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TxtMax As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TxtNo As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents ChkMVPublic As System.Windows.Forms.CheckBox
Friend WithEvents RbAll As System.Windows.Forms.RadioButton
  Friend WithEvents CboFile As ComboBox
  Friend WithEvents TxtGLYear As TextBox
  Friend WithEvents LblGLYear As Label
  Friend WithEvents RbNet As System.Windows.Forms.RadioButton
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbAll = New System.Windows.Forms.RadioButton()
    Me.RbSU = New System.Windows.Forms.RadioButton()
    Me.RbRE = New System.Windows.Forms.RadioButton()
    Me.RbMV = New System.Windows.Forms.RadioButton()
    Me.RbPP = New System.Windows.Forms.RadioButton()
    Me.RbGross = New System.Windows.Forms.RadioButton()
    Me.RbNet = New System.Windows.Forms.RadioButton()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtMin = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtMax = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtNo = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.ChkMVPublic = New System.Windows.Forms.CheckBox()
    Me.CboFile = New System.Windows.Forms.ComboBox()
    Me.TxtGLYear = New System.Windows.Forms.TextBox()
    Me.LblGLYear = New System.Windows.Forms.Label()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbAll)
    Me.GroupBox2.Controls.Add(Me.RbSU)
    Me.GroupBox2.Controls.Add(Me.RbRE)
    Me.GroupBox2.Controls.Add(Me.RbMV)
    Me.GroupBox2.Controls.Add(Me.RbPP)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(16, 12)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(142, 122)
    Me.GroupBox2.TabIndex = 0
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Bill Type"
    '
    'RbAll
    '
    Me.RbAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbAll.Location = New System.Drawing.Point(12, 96)
    Me.RbAll.Name = "RbAll"
    Me.RbAll.Size = New System.Drawing.Size(124, 20)
    Me.RbAll.TabIndex = 4
    Me.RbAll.Text = "Overall (RE/PP/MV)"
    '
    'RbSU
    '
    Me.RbSU.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSU.Location = New System.Drawing.Point(12, 76)
    Me.RbSU.Name = "RbSU"
    Me.RbSU.Size = New System.Drawing.Size(124, 20)
    Me.RbSU.TabIndex = 3
    Me.RbSU.Text = "Supplemental MV"
    '
    'RbRE
    '
    Me.RbRE.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbRE.Checked = True
    Me.RbRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbRE.Location = New System.Drawing.Point(12, 16)
    Me.RbRE.Name = "RbRE"
    Me.RbRE.Size = New System.Drawing.Size(124, 20)
    Me.RbRE.TabIndex = 0
    Me.RbRE.TabStop = True
    Me.RbRE.Text = "Real Estate"
    '
    'RbMV
    '
    Me.RbMV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbMV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbMV.Location = New System.Drawing.Point(12, 56)
    Me.RbMV.Name = "RbMV"
    Me.RbMV.Size = New System.Drawing.Size(124, 20)
    Me.RbMV.TabIndex = 2
    Me.RbMV.Text = "Motor Vehicle"
    '
    'RbPP
    '
    Me.RbPP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPP.Location = New System.Drawing.Point(12, 36)
    Me.RbPP.Name = "RbPP"
    Me.RbPP.Size = New System.Drawing.Size(124, 20)
    Me.RbPP.TabIndex = 1
    Me.RbPP.Text = "Personal Property"
    '
    'RbGross
    '
    Me.RbGross.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbGross.Checked = True
    Me.RbGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbGross.Location = New System.Drawing.Point(12, 315)
    Me.RbGross.Name = "RbGross"
    Me.RbGross.Size = New System.Drawing.Size(56, 20)
    Me.RbGross.TabIndex = 4
    Me.RbGross.TabStop = True
    Me.RbGross.Text = "Gross"
    '
    'RbNet
    '
    Me.RbNet.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbNet.Location = New System.Drawing.Point(88, 315)
    Me.RbNet.Name = "RbNet"
    Me.RbNet.Size = New System.Drawing.Size(56, 20)
    Me.RbNet.TabIndex = 5
    Me.RbNet.Text = "Net"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.Label4)
    Me.GroupBox1.Controls.Add(Me.TxtMin)
    Me.GroupBox1.Controls.Add(Me.Label1)
    Me.GroupBox1.Controls.Add(Me.TxtMax)
    Me.GroupBox1.Controls.Add(Me.Label3)
    Me.GroupBox1.Controls.Add(Me.TxtNo)
    Me.GroupBox1.Controls.Add(Me.Label2)
    Me.GroupBox1.Location = New System.Drawing.Point(16, 199)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(215, 110)
    Me.GroupBox1.TabIndex = 3
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Optional selections"
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(69, 41)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(43, 22)
    Me.Label4.TabIndex = 9
    Me.Label4.Text = "- OR -"
    '
    'TxtMin
    '
    Me.TxtMin.Location = New System.Drawing.Point(148, 63)
    Me.TxtMin.Name = "TxtMin"
    Me.TxtMin.Size = New System.Drawing.Size(61, 20)
    Me.TxtMin.TabIndex = 1
    Me.TxtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 86)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(87, 16)
    Me.Label1.TabIndex = 8
    Me.Label1.Text = "Maximum Value"
    '
    'TxtMax
    '
    Me.TxtMax.Location = New System.Drawing.Point(148, 86)
    Me.TxtMax.Name = "TxtMax"
    Me.TxtMax.Size = New System.Drawing.Size(61, 20)
    Me.TxtMax.TabIndex = 2
    Me.TxtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(8, 63)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(87, 16)
    Me.Label3.TabIndex = 6
    Me.Label3.Text = "Minimum Value"
    '
    'TxtNo
    '
    Me.TxtNo.Location = New System.Drawing.Point(169, 18)
    Me.TxtNo.Name = "TxtNo"
    Me.TxtNo.Size = New System.Drawing.Size(40, 20)
    Me.TxtNo.TabIndex = 0
    Me.TxtNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(8, 21)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(149, 20)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "Maximum number of records"
    '
    'ChkMVPublic
    '
    Me.ChkMVPublic.AutoSize = True
    Me.ChkMVPublic.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkMVPublic.Location = New System.Drawing.Point(167, 71)
    Me.ChkMVPublic.Name = "ChkMVPublic"
    Me.ChkMVPublic.Size = New System.Drawing.Size(121, 17)
    Me.ChkMVPublic.TabIndex = 6
    Me.ChkMVPublic.Text = "Include MV Regno?"
    '
    'CboFile
    '
    Me.CboFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.CboFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CboFile.FormattingEnabled = True
    Me.CboFile.Location = New System.Drawing.Point(42, 140)
    Me.CboFile.Name = "CboFile"
    Me.CboFile.Size = New System.Drawing.Size(102, 21)
    Me.CboFile.TabIndex = 1
    '
    'TxtGLYear
    '
    Me.TxtGLYear.Location = New System.Drawing.Point(112, 167)
    Me.TxtGLYear.MaxLength = 4
    Me.TxtGLYear.Name = "TxtGLYear"
    Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtGLYear.TabIndex = 2
    '
    'LblGLYear
    '
    Me.LblGLYear.AutoSize = True
    Me.LblGLYear.Location = New System.Drawing.Point(24, 170)
    Me.LblGLYear.Name = "LblGLYear"
    Me.LblGLYear.Size = New System.Drawing.Size(80, 13)
    Me.LblGLYear.TabIndex = 56
    Me.LblGLYear.Text = "Grand List Year"
    '
    'FrmTA203B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(300, 349)
    Me.ControlBox = False
    Me.Controls.Add(Me.CboFile)
    Me.Controls.Add(Me.TxtGLYear)
    Me.Controls.Add(Me.LblGLYear)
    Me.Controls.Add(Me.ChkMVPublic)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.RbNet)
    Me.Controls.Add(Me.RbGross)
    Me.Controls.Add(Me.GroupBox2)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA203B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Public Sub RunReport()
    PrtReport()
  End Sub
  Private Sub FrmTA203B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    SetFileList()
  End Sub
  Private Sub FrmTA203B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA203.SbpScreen.Text = "TA203B"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub SetFileList()
    CboFile.Items.Clear()
    CboFile.Items.Add("Regular")
    If Not RbSU.Checked Then
      CboFile.Items.Add("Frozen")
    End If
    CboFile.Items.Add("Archive")
    CboFile.SelectedItem = "Regular"
  End Sub
  Private Sub CboFile_SelectedValueChanged(sender As Object, e As EventArgs) Handles CboFile.SelectedValueChanged

    Select Case CboFile.SelectedItem.ToString
      Case "Regular", "Frozen"
        LblGLYear.Visible = False
        TxtGLYear.Text = ""
        TxtGLYear.Visible = False
      Case "Archive"
        LblGLYear.Visible = True
        TxtGLYear.Visible = True
    End Select
  End Sub
  Private Sub RbAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbRE.Click
    RbNet.Enabled = True
    ChkMVPublic.Enabled = True
    SetFileList()
  End Sub
  Private Sub RbRE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbRE.Click
    RbNet.Enabled = True
    ChkMVPublic.Enabled = False
    SetFileList()
  End Sub
  Private Sub RbPP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPP.Click
    RbNet.Enabled = True
    ChkMVPublic.Enabled = False
    SetFileList()
  End Sub
  Private Sub RbMV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbMV.Click
    RbNet.Enabled = False
    ChkMVPublic.Enabled = True
    SetFileList()
  End Sub
  Private Sub RbSU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbSU.Click
    RbNet.Enabled = False
    ChkMVPublic.Enabled = True
    SetFileList()
  End Sub
  Private Sub TxtNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtMax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMax.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtMin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMin.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub RbRE_CheckedChanged(sender As Object, e As EventArgs) Handles RbRE.CheckedChanged

End Sub
End Class






