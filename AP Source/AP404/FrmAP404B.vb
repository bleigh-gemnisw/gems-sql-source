Public Class FrmAP404B
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
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
Friend WithEvents DtPckPost As System.Windows.Forms.DateTimePicker
Friend WithEvents txtwarningmessage As System.Windows.Forms.TextBox
Friend WithEvents ChkContinue As System.Windows.Forms.CheckBox
Friend WithEvents lblpost As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.DtPckPost = New System.Windows.Forms.DateTimePicker()
    Me.lblpost = New System.Windows.Forms.Label()
    Me.txtwarningmessage = New System.Windows.Forms.TextBox()
    Me.ChkContinue = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'DtPckPost
    '
    Me.DtPckPost.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckPost.Location = New System.Drawing.Point(185, 195)
    Me.DtPckPost.Name = "DtPckPost"
    Me.DtPckPost.Size = New System.Drawing.Size(88, 20)
    Me.DtPckPost.TabIndex = 0
    '
    'lblpost
    '
    Me.lblpost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblpost.Location = New System.Drawing.Point(69, 197)
    Me.lblpost.Name = "lblpost"
    Me.lblpost.Size = New System.Drawing.Size(97, 16)
    Me.lblpost.TabIndex = 68
    Me.lblpost.Text = "Posting Date"
    '
    'txtwarningmessage
    '
    Me.txtwarningmessage.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtwarningmessage.Enabled = False
    Me.txtwarningmessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtwarningmessage.Location = New System.Drawing.Point(49, 33)
    Me.txtwarningmessage.Multiline = True
    Me.txtwarningmessage.Name = "txtwarningmessage"
    Me.txtwarningmessage.Size = New System.Drawing.Size(272, 83)
    Me.txtwarningmessage.TabIndex = 69
    '
    'ChkContinue
    '
    Me.ChkContinue.AutoSize = True
    Me.ChkContinue.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkContinue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkContinue.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkContinue.Location = New System.Drawing.Point(135, 155)
    Me.ChkContinue.Name = "ChkContinue"
    Me.ChkContinue.Size = New System.Drawing.Size(92, 24)
    Me.ChkContinue.TabIndex = 70
    Me.ChkContinue.Text = "Continue"
    Me.ChkContinue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    Me.ChkContinue.UseVisualStyleBackColor = True
    '
    'FrmAP404B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(358, 237)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkContinue)
    Me.Controls.Add(Me.txtwarningmessage)
    Me.Controls.Add(Me.DtPckPost)
    Me.Controls.Add(Me.lblpost)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmAP404B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

 Public Sub RunReport()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  Dim workpostdate As Date
  Array.Clear(ErrorField, 0, 25)
  Array.Clear(ErrorMsg, 0, 25)

  EditChecks(ErrorField, ErrorMsg)
  ShowError(ErrorField, ErrorMsg)
  If Not IsNothing(ErrorMsg(0)) Then
   Exit Sub
  End If
  workpostdate = DtPckPost.Value
  Windows.Forms.Cursor.Current = Cursors.WaitCursor
  Pstchecks(workpostdate)
  Windows.Forms.Cursor.Current = Cursors.Default

 End Sub
Private Sub FrmAP404B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  MyFrmAP404.SbpPgmID.Text = "AP404B"
  MyFrmAP404.SbpEnvironment.Text = myDBConnect.PgmDB
  DtPckPost.Value = Date.Today
  txtwarningmessage.Text = "This option will POST Checks to Accounts Payable History File and Check Reconciliation" _
   + " File.  It will also POST entries to General Ledger"
  ChkContinue.Checked = False
  lblpost.Visible = False
  DtPckPost.Visible = False
End Sub
Private Sub FrmAP404B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
 MyFrmAP404.SbpScreen.Text = "AP404B"
 ChkContinue.Focus()

End Sub
Private Sub FrmAP404B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
 Me.Refresh()
End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(DtPckPost, "")
  ErrProv.SetError(ChkContinue, "")
  For I = 0 To ErrorField.GetUpperBound(0)
   Select Case ErrorField(I)
   Case "date"
    ErrProv.SetError(DtPckPost, ErrorMsg(I))
  Case "continue"
    ErrProv.SetError(ChkContinue, ErrorMsg(I))
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
  If ChkContinue.Checked <> True Then
   ErrorField(I) = "continue"
   ErrorMsg(I) = "Must Check Continue before proceeding"
   I = I + 1
  End If
  If Not IsDate(DtPckPost.Value) Then
   ErrorField(I) = "date"
   ErrorMsg(I) = "Invalid Date"
   I = I + 1
  End If


 End Sub
Private Sub FrmAP404B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
 If Not e.Alt Then Exit Sub

  If e.KeyCode = Keys.F12 Then
   MyUtils.PrtScreen(Form.ActiveForm)
  End If
End Sub


Private Sub cbcontinue_CheckedChanged(sender As Object, e As EventArgs) Handles ChkContinue.CheckedChanged
  If ChkContinue.Checked = True Then
    DtPckPost.Visible = True
    lblpost.Visible = True
    Else
    DtPckPost.Visible = False
    lblpost.Visible = False
  End If
End Sub
End Class
