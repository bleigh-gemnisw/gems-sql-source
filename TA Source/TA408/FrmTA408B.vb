Public Class FrmTA408B
Inherits System.Windows.Forms.Form
Dim WrkClassDesc As String
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
    Friend WithEvents LnkClass As System.Windows.Forms.LinkLabel
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
  Friend WithEvents TxtClass As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TxtClass = New System.Windows.Forms.TextBox
Me.LnkClass = New System.Windows.Forms.LinkLabel
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'TxtClass
'
Me.TxtClass.Location = New System.Drawing.Point(101, 49)
Me.TxtClass.MaxLength = 2
Me.TxtClass.Name = "TxtClass"
Me.TxtClass.Size = New System.Drawing.Size(25, 20)
Me.TxtClass.TabIndex = 1
'
'LnkClass
'
Me.LnkClass.AutoSize = True
Me.LnkClass.Location = New System.Drawing.Point(63, 52)
Me.LnkClass.Name = "LnkClass"
Me.LnkClass.Size = New System.Drawing.Size(32, 13)
Me.LnkClass.TabIndex = 2
Me.LnkClass.TabStop = True
Me.LnkClass.Text = "Class"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'FrmTA408B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(191, 124)
Me.ControlBox = False
Me.Controls.Add(Me.LnkClass)
Me.Controls.Add(Me.TxtClass)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA408B"
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

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    PrtReport(WrkClassDesc)
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub FrmTA408B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  End Sub
Private Sub FrmTA408B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA408.SbpScreen.Text = "TA408B"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtClass, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "class"
        ErrProv.SetError(TxtClass, ErrorMsg(I))
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
    If MyUtils.CnvSng(TxtClass.Text) <> 0 Then
      WrkClassDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtClass.Text), "M")
      If Mid(WrkClassDesc, 1, 3) = "***" Then
        ErrorField(I) = "class"
        ErrorMsg(I) = "Invalid Class"
        I = I + 1
      End If
    Else
      ErrorField(I) = "class"
      ErrorMsg(I) = "Class is required"
      I = I + 1
    End If
  End Sub
Private Sub LnkClass_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkClass.LinkClicked
  MyFrmListCodes = New FrmListCodes
  MyFrmListCodes.MdiParent = Me.ParentForm
  MyFrmListCodes.WrkType = "M"
  MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtClass.Text)
  MyFrmListCodes.Show()
  Me.Hide()
End Sub
Private Sub TxtClass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClass.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






