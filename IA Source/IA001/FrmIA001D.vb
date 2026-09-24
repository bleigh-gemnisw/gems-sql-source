Imports System.Web.Security
Public Class FrmIA001D
Inherits System.Windows.Forms.Form
Dim myGNETUSER As GNETUSER.myData
Friend WrkGNETUSER As String
Dim oldhashpw As String
Dim hashedpw As String

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
Friend WithEvents TxtPasswordVerify As System.Windows.Forms.TextBox
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents TxtNewPassword As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtUser As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TxtOldPassword As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtPasswordVerify = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtNewPassword = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtUser = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtOldPassword = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TxtPasswordVerify
    '
    Me.TxtPasswordVerify.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPasswordVerify.Location = New System.Drawing.Point(120, 92)
    Me.TxtPasswordVerify.MaxLength = 40
    Me.TxtPasswordVerify.Name = "TxtPasswordVerify"
    Me.TxtPasswordVerify.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.TxtPasswordVerify.Size = New System.Drawing.Size(200, 20)
    Me.TxtPasswordVerify.TabIndex = 3
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(12, 92)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(92, 12)
    Me.Label6.TabIndex = 164
    Me.Label6.Text = "Verify Password"
    '
    'TxtNewPassword
    '
    Me.TxtNewPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtNewPassword.Location = New System.Drawing.Point(120, 68)
    Me.TxtNewPassword.MaxLength = 40
    Me.TxtNewPassword.Name = "TxtNewPassword"
    Me.TxtNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.TxtNewPassword.Size = New System.Drawing.Size(200, 20)
    Me.TxtNewPassword.TabIndex = 2
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(12, 68)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(92, 12)
    Me.Label2.TabIndex = 162
    Me.Label2.Text = "New Password"
    '
    'TxtUser
    '
    Me.TxtUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUser.Location = New System.Drawing.Point(120, 12)
    Me.TxtUser.MaxLength = 10
    Me.TxtUser.Name = "TxtUser"
    Me.TxtUser.Size = New System.Drawing.Size(116, 20)
    Me.TxtUser.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(12, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(92, 12)
    Me.Label1.TabIndex = 156
    Me.Label1.Text = "User Id"
    '
    'TxtOldPassword
    '
    Me.TxtOldPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOldPassword.Location = New System.Drawing.Point(120, 44)
    Me.TxtOldPassword.MaxLength = 40
    Me.TxtOldPassword.Name = "TxtOldPassword"
    Me.TxtOldPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.TxtOldPassword.Size = New System.Drawing.Size(200, 20)
    Me.TxtOldPassword.TabIndex = 1
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(12, 44)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(92, 12)
    Me.Label3.TabIndex = 166
    Me.Label3.Text = "Old Password"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'FrmIA001D
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(338, 120)
    Me.Controls.Add(Me.TxtOldPassword)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtPasswordVerify)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.TxtNewPassword)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtUser)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmIA001D"
    Me.Text = "Change Password"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmIA001D_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myGNETUSER = New GNETUSER.MyData()
    myGNETUSER.MyDBConn = myDBConnect
    MyFrmIA001.TBarNew.Visible = False
    MyFrmIA001.TBarSave.Enabled = True
    MyFrmIA001.TBarDelete.Visible = False
    MyFrmIA001.TBarPrint.Visible = False

    TxtUser.ReadOnly = True
    TxtUser.TabStop = False
    TxtUser.BackColor = Color.Aqua

		myGNETUSER.GetOneRecordP(WrkGNETUSER)
    TxtUser.Text = WrkGNETUSER
		If myGNETUSER.RecordNotFound Then
			oldhashpw = ""
			Exit Sub
		End If
		With myGNETUSER
			oldhashpw = Trim(._GPWORD)
		End With

End Sub
Private Sub FrmIA001D_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmIA001.SbpScreen.Text = "IA001D"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmIA001D_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  End
End Sub
Public Sub SaveData()
		Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

		myGNETUSER.GetOneRecordP(TxtUser.Text)

    MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
			myGNETUSER.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If

    MsgBox("Password has been changed", MsgBoxStyle.Information, "Confirmation")
    Me.Close()

End Sub
Private Sub MovetoFile()
		With myGNETUSER
			hashedpw = FormsAuthentication.HashPasswordForStoringInConfigFile(TxtNewPassword.Text, "sha1")
			._GPWORD = hashedpw
		End With
End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtOldPassword, "")
    ErrProv.SetError(TxtNewPassword, "")
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "oldpassword"
        ErrProv.SetError(TxtOldPassword, ErrorMsg(I))
      Case "newpassword"
        ErrProv.SetError(TxtNewPassword, ErrorMsg(I))
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

    If oldhashpw <> "" And TxtOldPassword.Text = String.Empty Then
      ErrorField(I) = "oldpassword"
      ErrorMsg(I) = "Old Password must be entered"
      I = I + 1
    End If

    If TxtOldPassword.Text <> String.Empty Then
      hashedpw = FormsAuthentication.HashPasswordForStoringInConfigFile(TxtOldPassword.Text, "sha1")
      If oldhashpw <> "" And oldhashpw <> hashedpw Then
        ErrorField(I) = "oldpassword"
        ErrorMsg(I) = "Old Password not correct. Please reenter"
        I = I + 1
      End If
    End If

    If Len(TxtNewPassword.Text) < 5 Then
      ErrorField(I) = "newpassword"
      ErrorMsg(I) = "New Password must be at least 5 chars long"
      I = I + 1
    End If

    If Trim(TxtNewPassword.Text) = "" Then
      ErrorField(I) = "newpassword"
      ErrorMsg(I) = "New Password cannot be blank"
      I = I + 1
    End If

    If Trim(TxtNewPassword.Text) > "" Then
      If TxtNewPassword.Text <> TxtPasswordVerify.Text Then
        ErrorField(I) = "newpassword"
        ErrorMsg(I) = "New Passwords do not match. Please reenter"
        I = I + 1
      End If
    End If
  End Sub

End Class
