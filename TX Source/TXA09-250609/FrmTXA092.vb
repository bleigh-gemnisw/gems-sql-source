Public Class FrmTXA092
    Inherits System.Windows.Forms.Form

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
  Friend WithEvents Label34 As System.Windows.Forms.Label
  Friend WithEvents DtPckInt As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents DTPckReceipt As System.Windows.Forms.DateTimePicker
  Friend WithEvents BtnContinue As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.Label34 = New System.Windows.Forms.Label
Me.DtPckInt = New System.Windows.Forms.DateTimePicker
Me.Label1 = New System.Windows.Forms.Label
Me.DTPckReceipt = New System.Windows.Forms.DateTimePicker
Me.BtnContinue = New System.Windows.Forms.Button
Me.SuspendLayout()
'
'Label34
'
Me.Label34.Location = New System.Drawing.Point(52, 36)
Me.Label34.Name = "Label34"
Me.Label34.Size = New System.Drawing.Size(72, 16)
Me.Label34.TabIndex = 165
Me.Label34.Text = "Interest Date"
'
'DtPckInt
'
Me.DtPckInt.Format = System.Windows.Forms.DateTimePickerFormat.Short
Me.DtPckInt.Location = New System.Drawing.Point(124, 32)
Me.DtPckInt.Name = "DtPckInt"
Me.DtPckInt.Size = New System.Drawing.Size(88, 20)
Me.DtPckInt.TabIndex = 164
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(52, 64)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(72, 16)
Me.Label1.TabIndex = 167
Me.Label1.Text = "Receipt Date"
'
'DTPckReceipt
'
Me.DTPckReceipt.Format = System.Windows.Forms.DateTimePickerFormat.Short
Me.DTPckReceipt.Location = New System.Drawing.Point(124, 60)
Me.DTPckReceipt.Name = "DTPckReceipt"
Me.DTPckReceipt.Size = New System.Drawing.Size(88, 20)
Me.DTPckReceipt.TabIndex = 166
'
'BtnContinue
'
Me.BtnContinue.Location = New System.Drawing.Point(92, 92)
Me.BtnContinue.Name = "BtnContinue"
Me.BtnContinue.Size = New System.Drawing.Size(80, 28)
Me.BtnContinue.TabIndex = 168
Me.BtnContinue.Text = "C&ontinue"
'
'FrmTXA092
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(256, 134)
Me.Controls.Add(Me.BtnContinue)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.DTPckReceipt)
Me.Controls.Add(Me.Label34)
Me.Controls.Add(Me.DtPckInt)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.KeyPreview = True
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTXA092"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Inquiry Cash Register"
Me.ResumeLayout(False)

    End Sub

#End Region

  Private Sub FrmTXA092_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    DtPckInt.Value = Now
    DTPckReceipt.Value = Now
  End Sub

  Private Sub FrmTXA092_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA09.SbpScreen.Text = "TXA092"
    Call MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmTXA09
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
Private Sub FrmTXA092_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    MyInterestDate = DtPckInt.Value
    MyReceiptDate = DTPckReceipt.Value

    MyFrmTXA094 = New FrmTXA094
    MyFrmTXA094.MdiParent = Me.ParentForm
    MyFrmTXA094.Show()
    'Memory Cleanup
    MyFrmTXA092 = Nothing
  End Sub
  Private Sub BtnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnContinue.Click
    Me.Close()
  End Sub
Private Sub FrmTXA092_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      Me.Close()
    End If
End Sub
End Class






