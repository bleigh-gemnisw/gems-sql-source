Public Class FrmUB402B
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
Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TxtType = New System.Windows.Forms.TextBox
Me.TxtFromGLYear = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.LnkType = New System.Windows.Forms.LinkLabel
Me.ErrProv = New System.Windows.Forms.ErrorProvider
Me.ChkPost = New System.Windows.Forms.CheckBox
Me.DtPckPost = New System.Windows.Forms.DateTimePicker
Me.Label2 = New System.Windows.Forms.Label
Me.SuspendLayout()
'
'TxtType
'
Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtType.Location = New System.Drawing.Point(120, 12)
Me.TxtType.MaxLength = 20
Me.TxtType.Name = "TxtType"
Me.TxtType.Size = New System.Drawing.Size(16, 20)
Me.TxtType.TabIndex = 0
Me.TxtType.Text = ""
'
'TxtFromGLYear
'
Me.TxtFromGLYear.Location = New System.Drawing.Point(120, 40)
Me.TxtFromGLYear.MaxLength = 4
Me.TxtFromGLYear.Name = "TxtFromGLYear"
Me.TxtFromGLYear.Size = New System.Drawing.Size(32, 20)
Me.TxtFromGLYear.TabIndex = 2
Me.TxtFromGLYear.Text = ""
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(36, 44)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(72, 16)
Me.Label4.TabIndex = 11
Me.Label4.Text = "From Year"
'
'LnkType
'
Me.LnkType.Location = New System.Drawing.Point(36, 16)
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
Me.ChkPost.Location = New System.Drawing.Point(36, 68)
Me.ChkPost.Name = "ChkPost"
Me.ChkPost.Size = New System.Drawing.Size(124, 20)
Me.ChkPost.TabIndex = 18
Me.ChkPost.Text = "Post to invoice file?"
'
'DtPckPost
'
Me.DtPckPost.Format = System.Windows.Forms.DateTimePickerFormat.Short
Me.DtPckPost.Location = New System.Drawing.Point(144, 92)
Me.DtPckPost.Name = "DtPckPost"
Me.DtPckPost.Size = New System.Drawing.Size(84, 20)
Me.DtPckPost.TabIndex = 22
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(36, 96)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(72, 16)
Me.Label2.TabIndex = 23
Me.Label2.Text = "Posting Date"
'
'FrmUB402B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(352, 130)
Me.ControlBox = False
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
Me.Name = "FrmUB402B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.ResumeLayout(False)

    End Sub

#End Region

Private Sub FrmUB402B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB402.SbpScreen.Text = "UB402"
End Sub

Private Sub LnkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkType.LinkClicked
  MyFrmListUBType_Tax = New FrmListUBType_Tax
  MyFrmListUBType_Tax.MdiParent = Me.ParentForm
  MyFrmListUBType_Tax.WrkType = TxtType.Text
  MyFrmListUBType_Tax.Show()
  Me.Hide()
End Sub
Private Sub FrmUB402B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFromGLYear, "")
    ErrProv.SetError(TxtType, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "glyear"
        ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
      Case "type"
        ErrProv.SetError(TxtType, ErrorMsg(I))
      Case Nothing
        Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim WrkUBType As String
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtFromGLYear.Text) = 0 Then
      ErrorField(I) = "glyear"
      ErrorMsg(I) = "Invalid Year"
      I = I + 1
    End If

    If TxtType.Text = "" Then
      ErrorField(I) = "type"
      ErrorMsg(I) = "Type is required"
      I = I + 1
    End If

    WrkUBType = GetUTTypeUBType(TxtType.Text)
    If WrkUBType <> "A" Then
      ErrorField(I) = "type"
      ErrorMsg(I) = "Only Assessment types are valid for this option"
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
    PrtReport()

    'Reset screen to defaults
    TxtType.Text = ""
    TxtFromGLYear.Text = ""
    ChkPost.Checked = False
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub

Private Sub FrmUB402B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  DtPckPost.Value = Date.Today
End Sub
End Class






