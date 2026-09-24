Public Class FrmGL520B
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
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents TxtFund As System.Windows.Forms.TextBox
Friend WithEvents TxtSfund As System.Windows.Forms.TextBox
Friend WithEvents LnkFund As System.Windows.Forms.LinkLabel
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents ChkAct3 As CheckBox
  Friend WithEvents ChkAct2 As CheckBox
  Friend WithEvents ChkAct1 As CheckBox
  Friend WithEvents ChkAct5 As CheckBox
  Friend WithEvents ChkAct4 As CheckBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtFund = New System.Windows.Forms.TextBox()
    Me.TxtSfund = New System.Windows.Forms.TextBox()
    Me.LnkFund = New System.Windows.Forms.LinkLabel()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.ChkAct1 = New System.Windows.Forms.CheckBox()
    Me.ChkAct2 = New System.Windows.Forms.CheckBox()
    Me.ChkAct3 = New System.Windows.Forms.CheckBox()
    Me.ChkAct4 = New System.Windows.Forms.CheckBox()
    Me.ChkAct5 = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox3.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtFund
    '
    Me.TxtFund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFund.Location = New System.Drawing.Point(187, 17)
    Me.TxtFund.MaxLength = 3
    Me.TxtFund.Name = "TxtFund"
    Me.TxtFund.Size = New System.Drawing.Size(30, 22)
    Me.TxtFund.TabIndex = 0
    '
    'TxtSfund
    '
    Me.TxtSfund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfund.Location = New System.Drawing.Point(232, 17)
    Me.TxtSfund.MaxLength = 3
    Me.TxtSfund.Name = "TxtSfund"
    Me.TxtSfund.Size = New System.Drawing.Size(34, 22)
    Me.TxtSfund.TabIndex = 1
    '
    'LnkFund
    '
    Me.LnkFund.AutoSize = True
    Me.LnkFund.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFund.Location = New System.Drawing.Point(150, 21)
    Me.LnkFund.Name = "LnkFund"
    Me.LnkFund.Size = New System.Drawing.Size(31, 13)
    Me.LnkFund.TabIndex = 319
    Me.LnkFund.TabStop = True
    Me.LnkFund.Text = "Fund"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(12, 58)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(400, 13)
    Me.Label3.TabIndex = 322
    Me.Label3.Text = "The Next Set Of Dates Will Be Used To Update Previous Actual Amounts Checked"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.DtPckTo)
    Me.GroupBox3.Controls.Add(Me.Label7)
    Me.GroupBox3.Controls.Add(Me.DtPckFrom)
    Me.GroupBox3.Controls.Add(Me.Label8)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(63, 97)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(286, 52)
    Me.GroupBox3.TabIndex = 326
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Current Fiscal Year Date Range"
    '
    'DtPckTo
    '
    Me.DtPckTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTo.Location = New System.Drawing.Point(185, 20)
    Me.DtPckTo.Name = "DtPckTo"
    Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
    Me.DtPckTo.TabIndex = 1
    Me.DtPckTo.Value = New Date(2005, 10, 6, 9, 11, 0, 906)
    '
    'Label7
    '
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(151, 24)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(28, 16)
    Me.Label7.TabIndex = 9
    Me.Label7.Text = "To "
    '
    'DtPckFrom
    '
    Me.DtPckFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFrom.Location = New System.Drawing.Point(52, 20)
    Me.DtPckFrom.Name = "DtPckFrom"
    Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
    Me.DtPckFrom.TabIndex = 0
    Me.DtPckFrom.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
    '
    'Label8
    '
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(12, 20)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(36, 16)
    Me.Label8.TabIndex = 7
    Me.Label8.Text = "From"
    '
    'ChkAct1
    '
    Me.ChkAct1.AutoSize = True
    Me.ChkAct1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkAct1.Location = New System.Drawing.Point(60, 170)
    Me.ChkAct1.Name = "ChkAct1"
    Me.ChkAct1.Size = New System.Drawing.Size(79, 17)
    Me.ChkAct1.TabIndex = 327
    Me.ChkAct1.Text = "1 Year Ago"
    Me.ChkAct1.UseVisualStyleBackColor = True
    '
    'ChkAct2
    '
    Me.ChkAct2.AutoSize = True
    Me.ChkAct2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkAct2.Location = New System.Drawing.Point(163, 170)
    Me.ChkAct2.Name = "ChkAct2"
    Me.ChkAct2.Size = New System.Drawing.Size(84, 17)
    Me.ChkAct2.TabIndex = 328
    Me.ChkAct2.Text = "2 Years Ago"
    Me.ChkAct2.UseVisualStyleBackColor = True
    '
    'ChkAct3
    '
    Me.ChkAct3.AutoSize = True
    Me.ChkAct3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkAct3.Location = New System.Drawing.Point(270, 170)
    Me.ChkAct3.Name = "ChkAct3"
    Me.ChkAct3.Size = New System.Drawing.Size(84, 17)
    Me.ChkAct3.TabIndex = 329
    Me.ChkAct3.Text = "3 Years Ago"
    Me.ChkAct3.UseVisualStyleBackColor = True
    '
    'ChkAct4
    '
    Me.ChkAct4.AutoSize = True
    Me.ChkAct4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkAct4.Location = New System.Drawing.Point(55, 193)
    Me.ChkAct4.Name = "ChkAct4"
    Me.ChkAct4.Size = New System.Drawing.Size(84, 17)
    Me.ChkAct4.TabIndex = 330
    Me.ChkAct4.Text = "4 Years Ago"
    Me.ChkAct4.UseVisualStyleBackColor = True
    '
    'ChkAct5
    '
    Me.ChkAct5.AutoSize = True
    Me.ChkAct5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkAct5.Location = New System.Drawing.Point(163, 193)
    Me.ChkAct5.Name = "ChkAct5"
    Me.ChkAct5.Size = New System.Drawing.Size(84, 17)
    Me.ChkAct5.TabIndex = 331
    Me.ChkAct5.Text = "5 Years Ago"
    Me.ChkAct5.UseVisualStyleBackColor = True
    '
    'FrmGL520B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(423, 227)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkAct5)
    Me.Controls.Add(Me.ChkAct4)
    Me.Controls.Add(Me.ChkAct3)
    Me.Controls.Add(Me.ChkAct2)
    Me.Controls.Add(Me.ChkAct1)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.LnkFund)
    Me.Controls.Add(Me.TxtSfund)
    Me.Controls.Add(Me.TxtFund)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL520B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox3.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Public Sub RunReport()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If

    Me.Refresh()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    ProcFile()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub FrmGL520B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    DtPckFrom.Value = Date.Today
    DtPckTo.Value = Date.Today
  End Sub
  Private Sub FrmGL520B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGL520.SbpScreen.Text = "GL520B"
  End Sub
  Private Sub FrmGL520B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    ErrProv.SetError(TxtFund, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "fund"
        ErrProv.SetError(TxtFund, ErrorMsg(I))
      Case Nothing
        Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If TxtFund.Text = "" Then
      ErrorField(I) = "fund"
      ErrorMsg(I) = "Invalid Fund"
      I = I + 1
    End If
  End Sub
Private Sub TxtFund_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFund.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtSfund_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSfund.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub LnkFund_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFund.LinkClicked
  MyFrmListFund = New FrmListFund
  MyFrmListFund.MdiParent = Me.ParentForm
  MyFrmListFund.WrkFund = MyUtils.CnvSng(TxtFund.Text)
  MyFrmListFund.WrkID = "From"
  MyFrmListFund.Show()
  Me.Hide()
End Sub
End Class
