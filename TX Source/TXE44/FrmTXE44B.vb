Public Class FrmTXE44B
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
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents TxtType As System.Windows.Forms.TextBox
Friend WithEvents LnkType As System.Windows.Forms.LinkLabel
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents Chkupdatebacktax As System.Windows.Forms.CheckBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Chkupdatebacktax = New System.Windows.Forms.CheckBox
Me.TxtType = New System.Windows.Forms.TextBox
Me.LnkType = New System.Windows.Forms.LinkLabel
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Chkupdatebacktax
'
Me.Chkupdatebacktax.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.Chkupdatebacktax.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Chkupdatebacktax.Location = New System.Drawing.Point(24, 57)
Me.Chkupdatebacktax.Name = "Chkupdatebacktax"
Me.Chkupdatebacktax.Size = New System.Drawing.Size(240, 30)
Me.Chkupdatebacktax.TabIndex = 2
Me.Chkupdatebacktax.Text = "Update records with back tax code?"
'
'TxtType
'
Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtType.Location = New System.Drawing.Point(111, 21)
Me.TxtType.MaxLength = 1
Me.TxtType.Name = "TxtType"
Me.TxtType.Size = New System.Drawing.Size(16, 20)
Me.TxtType.TabIndex = 0
'
'LnkType
'
Me.LnkType.Location = New System.Drawing.Point(21, 25)
Me.LnkType.Name = "LnkType"
Me.LnkType.Size = New System.Drawing.Size(80, 16)
Me.LnkType.TabIndex = 64
Me.LnkType.TabStop = True
Me.LnkType.Text = "Type to print"
'
'FrmTXE44B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(282, 120)
Me.ControlBox = False
Me.Controls.Add(Me.TxtType)
Me.Controls.Add(Me.LnkType)
Me.Controls.Add(Me.Chkupdatebacktax)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTXE44B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTXE44B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
 MyFrmTXE44.SbpScreen.Text = "TXE44"
End Sub


Private Sub FrmTXE44B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
 Me.Refresh()
End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtType, "")

  For I = 0 To ErrorField.GetUpperBound(0)
   Select Case ErrorField(I)
   Case "type"
    ErrProv.SetError(TxtType, ErrorMsg(I))
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

  If TxtType.Text = String.Empty Then
   ErrorField(I) = "type"
   ErrorMsg(I) = "Type is required"
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
  Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
 e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub FrmTXE44B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
End Sub
Private Sub LnkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkType.LinkClicked
 MyFrmListTypes = New FrmListTypes
 MyFrmListTypes.MdiParent = Me.ParentForm
 MyFrmListTypes.WrkType = TxtType.Text
 MyFrmListTypes.Show()
End Sub
End Class






