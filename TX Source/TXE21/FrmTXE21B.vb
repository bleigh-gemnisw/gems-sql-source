Public Class FrmTXE21B
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
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents TxtBankCd As System.Windows.Forms.TextBox
Friend WithEvents LnkBankCd As System.Windows.Forms.LinkLabel
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.TxtBankCd = New System.Windows.Forms.TextBox
Me.LnkBankCd = New System.Windows.Forms.LinkLabel
Me.TxtGLYear = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'TxtBankCd
'
Me.TxtBankCd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtBankCd.Location = New System.Drawing.Point(108, 49)
Me.TxtBankCd.MaxLength = 2
Me.TxtBankCd.Name = "TxtBankCd"
Me.TxtBankCd.Size = New System.Drawing.Size(24, 20)
Me.TxtBankCd.TabIndex = 3
'
'LnkBankCd
'
Me.LnkBankCd.Location = New System.Drawing.Point(12, 52)
Me.LnkBankCd.Name = "LnkBankCd"
Me.LnkBankCd.Size = New System.Drawing.Size(80, 16)
Me.LnkBankCd.TabIndex = 164
Me.LnkBankCd.TabStop = True
Me.LnkBankCd.Text = "Escrow Bank"
'
'TxtGLYear
'
Me.TxtGLYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtGLYear.Location = New System.Drawing.Point(108, 18)
Me.TxtGLYear.MaxLength = 4
Me.TxtGLYear.Name = "TxtGLYear"
Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
Me.TxtGLYear.TabIndex = 2
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(11, 21)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(84, 16)
Me.Label3.TabIndex = 168
Me.Label3.Text = "Grand List Year"
'
'FrmTXE21B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(174, 90)
Me.ControlBox = False
Me.Controls.Add(Me.TxtGLYear)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.TxtBankCd)
Me.Controls.Add(Me.LnkBankCd)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTXE21B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTXE21B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTXE21.SbpScreen.Text = "TXE21"
End Sub
Private Sub FrmTXE21B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLYear, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "glyear"
        ErrProv.SetError(TxtGLYear, ErrorMsg(I))
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
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub LnkBankCd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBankCd.LinkClicked
  MyFrmListBanks = New FrmListBanks
  MyFrmListBanks.MdiParent = Me.ParentForm
  MyFrmListBanks.WrkCode = TxtBankCd.Text
  MyFrmListBanks.Show()
End Sub

Private Sub FrmTXE21B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

End Sub
End Class






