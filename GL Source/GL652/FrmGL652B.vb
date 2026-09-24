Public Class FrmGL652B
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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtDept As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents LblToYear As Label
  Friend WithEvents Label7 As Label
  Friend WithEvents TxtFromYear As TextBox
  Friend WithEvents Label3 As Label
    Friend WithEvents ChkOmit As CheckBox
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtFund = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtDept = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.LblToYear = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtFromYear = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
        Me.ChkOmit = New System.Windows.Forms.CheckBox()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'TxtFund
        '
        Me.TxtFund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFund.Location = New System.Drawing.Point(195, 31)
        Me.TxtFund.MaxLength = 3
        Me.TxtFund.Name = "TxtFund"
        Me.TxtFund.Size = New System.Drawing.Size(30, 22)
        Me.TxtFund.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(85, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 18)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Fund"
        '
        'TxtDept
        '
        Me.TxtDept.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDept.Location = New System.Drawing.Point(195, 56)
        Me.TxtDept.MaxLength = 4
        Me.TxtDept.Name = "TxtDept"
        Me.TxtDept.Size = New System.Drawing.Size(40, 22)
        Me.TxtDept.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(85, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 18)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Dept"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(243, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 18)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "(Optional)"
        '
        'LblToYear
        '
        Me.LblToYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblToYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblToYear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblToYear.Location = New System.Drawing.Point(256, 84)
        Me.LblToYear.Name = "LblToYear"
        Me.LblToYear.Size = New System.Drawing.Size(43, 22)
        Me.LblToYear.TabIndex = 350
        Me.LblToYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(243, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(10, 13)
        Me.Label7.TabIndex = 349
        Me.Label7.Text = "-"
        '
        'TxtFromYear
        '
        Me.TxtFromYear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFromYear.Location = New System.Drawing.Point(195, 84)
        Me.TxtFromYear.MaxLength = 4
        Me.TxtFromYear.Name = "TxtFromYear"
        Me.TxtFromYear.Size = New System.Drawing.Size(40, 22)
        Me.TxtFromYear.TabIndex = 347
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(85, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 348
        Me.Label3.Text = "Budget Starting Year"
        '
        'ChkOmit
        '
        Me.ChkOmit.AutoSize = True
        Me.ChkOmit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkOmit.Location = New System.Drawing.Point(88, 112)
        Me.ChkOmit.Name = "ChkOmit"
        Me.ChkOmit.Size = New System.Drawing.Size(151, 17)
        Me.ChkOmit.TabIndex = 351
        Me.ChkOmit.Text = "Omit No activity (2 Years)?"
        Me.ChkOmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkOmit.UseVisualStyleBackColor = True
        '
        'FrmGL652B
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(352, 161)
        Me.ControlBox = False
        Me.Controls.Add(Me.ChkOmit)
        Me.Controls.Add(Me.LblToYear)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtFromYear)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtDept)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtFund)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGL652B"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
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
    PrtReport()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub FrmGL652B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  End Sub
  Private Sub FrmGL652B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGL652.SbpScreen.Text = "GL652B"
  End Sub
  Private Sub FrmGL652B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    ErrProv.SetError(TxtFund, "")
    ErrProv.SetError(TxtFromYear, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "fund"
          ErrProv.SetError(TxtFund, ErrorMsg(I))
        Case "year"
          ErrProv.SetError(TxtFromYear, ErrorMsg(I))
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

    If TxtFromYear.Text = "" Then
      ErrorField(I) = "year"
      ErrorMsg(I) = "Invalid Year"
      I = I + 1
    End If

  End Sub
  Private Sub TxtFund_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFund.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDept_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDept.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFromYear_KeyUp(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles TxtFromYear.KeyUp
    LblToYear.Text = MyUtils.CnvSng(TxtFromYear.Text) + 1
  End Sub
End Class
