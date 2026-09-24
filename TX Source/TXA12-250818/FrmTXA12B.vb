Public Class FrmTXA12B
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
  Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents TxtType As System.Windows.Forms.TextBox
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents LnkType As System.Windows.Forms.LinkLabel
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
Friend WithEvents DtPckPost As System.Windows.Forms.DateTimePicker
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtToGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TxtType = New System.Windows.Forms.TextBox
Me.TxtFromGLYear = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.LnkType = New System.Windows.Forms.LinkLabel
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.ChkPost = New System.Windows.Forms.CheckBox
Me.DtPckPost = New System.Windows.Forms.DateTimePicker
Me.Label2 = New System.Windows.Forms.Label
Me.TxtToGLYear = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.Label5 = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
Me.Label6 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'TxtType
'
Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtType.Location = New System.Drawing.Point(106, 34)
Me.TxtType.MaxLength = 20
Me.TxtType.Name = "TxtType"
Me.TxtType.Size = New System.Drawing.Size(16, 20)
Me.TxtType.TabIndex = 0
'
'TxtFromGLYear
'
Me.TxtFromGLYear.Location = New System.Drawing.Point(106, 62)
Me.TxtFromGLYear.MaxLength = 4
Me.TxtFromGLYear.Name = "TxtFromGLYear"
Me.TxtFromGLYear.Size = New System.Drawing.Size(32, 20)
Me.TxtFromGLYear.TabIndex = 1
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(22, 66)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(72, 16)
Me.Label4.TabIndex = 11
Me.Label4.Text = "From Year"
'
'LnkType
'
Me.LnkType.Location = New System.Drawing.Point(22, 38)
Me.LnkType.Name = "LnkType"
Me.LnkType.Size = New System.Drawing.Size(80, 16)
Me.LnkType.TabIndex = 17
Me.LnkType.TabStop = True
Me.LnkType.Text = "Tax Type"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'ChkPost
'
Me.ChkPost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkPost.Location = New System.Drawing.Point(25, 123)
Me.ChkPost.Name = "ChkPost"
Me.ChkPost.Size = New System.Drawing.Size(124, 20)
Me.ChkPost.TabIndex = 4
Me.ChkPost.Text = "Post to invoice file?"
'
'DtPckPost
'
Me.DtPckPost.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckPost.Location = New System.Drawing.Point(106, 91)
Me.DtPckPost.Name = "DtPckPost"
Me.DtPckPost.Size = New System.Drawing.Size(84, 20)
Me.DtPckPost.TabIndex = 3
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(22, 95)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(80, 16)
Me.Label2.TabIndex = 23
Me.Label2.Text = "Posting Date*"
'
'TxtToGLYear
'
Me.TxtToGLYear.Location = New System.Drawing.Point(230, 62)
Me.TxtToGLYear.MaxLength = 4
Me.TxtToGLYear.Name = "TxtToGLYear"
Me.TxtToGLYear.Size = New System.Drawing.Size(32, 20)
Me.TxtToGLYear.TabIndex = 2
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(165, 66)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(59, 16)
Me.Label1.TabIndex = 305
Me.Label1.Text = "To Year"
'
'Label5
'
Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label5.Location = New System.Drawing.Point(51, 159)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(189, 28)
Me.Label5.TabIndex = 345
Me.Label5.Text = "*Accounts with activity after the posting date will be skipped"
Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
'
'Label3
'
Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label3.Location = New System.Drawing.Point(51, 0)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(189, 17)
Me.Label3.TabIndex = 346
Me.Label3.Text = "Mass Transfer"
Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
'
'Label6
'
Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label6.Location = New System.Drawing.Point(12, 198)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(264, 28)
Me.Label6.TabIndex = 347
Me.Label6.Text = "*** NOTICE: Fees are NOT handled, use single transfer if there are fees to pay **" & _
    "*"
Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
'
'FrmTXA12B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(288, 235)
Me.ControlBox = False
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.TxtToGLYear)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.DtPckPost)
Me.Controls.Add(Me.ChkPost)
Me.Controls.Add(Me.TxtFromGLYear)
Me.Controls.Add(Me.TxtType)
Me.Controls.Add(Me.LnkType)
Me.Controls.Add(Me.Label4)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTXA12B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTXA12B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTXA12.SbpScreen.Text = "TXA12"
End Sub

Private Sub LnkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkType.LinkClicked
  MyFrmListTypes = New FrmListTypes
  MyFrmListTypes.MdiParent = Me.ParentForm
  MyFrmListTypes.WrkType = TxtType.Text
  MyFrmListTypes.Show()
  Me.Hide()
End Sub
Private Sub FrmTXA12B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFromGLYear, "")
    ErrProv.SetError(TxtToGLYear, "")
    ErrProv.SetError(TxtType, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "fromglyear"
        ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
      Case "toglyear"
        ErrProv.SetError(TxtToGLYear, ErrorMsg(I))
      Case "type"
        ErrProv.SetError(TxtType, ErrorMsg(I))
      Case Nothing
        Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim WrkFamily As String
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtFromGLYear.Text) = 0 Then
      ErrorField(I) = "fromglyear"
      ErrorMsg(I) = "Invalid From Year"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtToGLYear.Text) = 0 Then
      ErrorField(I) = "toglyear"
      ErrorMsg(I) = "Invalid To Year"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtToGLYear.Text) = MyUtils.CnvSng(TxtFromGLYear.Text) Then
      ErrorField(I) = "toglyear"
      ErrorMsg(I) = "Years cannot be the same"
      I = I + 1
    End If

    If TxtType.Text = "" Then
      ErrorField(I) = "type"
      ErrorMsg(I) = "Type is required"
      I = I + 1
    End If

    WrkFamily = GetTXTypeFamily(TxtType.Text)
    If WrkFamily = "A" Then
      ErrorField(I) = "type"
      ErrorMsg(I) = "UB Assessment Tax Types are not valid for this option. Run similar option in UB system."
      I = I + 1
    End If

  End Sub
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
    MassXfer()

    'Reset screen to defaults after posting
    If ChkPost.Checked Then
      ChkPost.Checked = False
    End If
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub

Private Sub FrmTXA12B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  InitCASHINT()
  InitTXHSTL4()
  DtPckPost.Value = Date.Today
End Sub
Private Sub TxtFromGLYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtToGLYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

End Sub
End Class






