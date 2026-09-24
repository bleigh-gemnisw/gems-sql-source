Imports System.Web.Security

Public Class FrmIA001C

Inherits System.windows.forms.Form

Dim myGNETUSER As GNETUSER.MyData
Dim mygnetgroup As GNETGROUP.myData
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
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtPassword_verify As System.Windows.Forms.TextBox
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents cbstatus As System.Windows.Forms.ComboBox
Friend WithEvents Lnkgroup As System.Windows.Forms.LinkLabel
Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
Friend WithEvents TxtUser As System.Windows.Forms.TextBox
Friend WithEvents TxtName As System.Windows.Forms.TextBox
Friend WithEvents TxtGroup As System.Windows.Forms.TextBox
Friend WithEvents TxtPassword As System.Windows.Forms.TextBox
<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmIA001C))
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtUser = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtPassword = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtPassword_verify = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.cbstatus = New System.Windows.Forms.ComboBox()
    Me.Lnkgroup = New System.Windows.Forms.LinkLabel()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.TxtGroup = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(12, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(92, 12)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "User Id"
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
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(12, 36)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(92, 12)
    Me.Label4.TabIndex = 6
    Me.Label4.Text = "Name"
    '
    'TxtName
    '
    Me.TxtName.Location = New System.Drawing.Point(120, 36)
    Me.TxtName.MaxLength = 40
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(288, 20)
    Me.TxtName.TabIndex = 1
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(12, 132)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(92, 12)
    Me.Label5.TabIndex = 8
    Me.Label5.Text = "Status"
    '
    'TxtPassword
    '
    Me.TxtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPassword.Location = New System.Drawing.Point(120, 84)
    Me.TxtPassword.MaxLength = 40
    Me.TxtPassword.Name = "TxtPassword"
    Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.TxtPassword.Size = New System.Drawing.Size(200, 20)
    Me.TxtPassword.TabIndex = 9
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(12, 84)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(92, 12)
    Me.Label2.TabIndex = 10
    Me.Label2.Text = "Password"
    '
    'TxtPassword_verify
    '
    Me.TxtPassword_verify.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPassword_verify.Location = New System.Drawing.Point(120, 108)
    Me.TxtPassword_verify.MaxLength = 40
    Me.TxtPassword_verify.Name = "TxtPassword_verify"
    Me.TxtPassword_verify.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.TxtPassword_verify.Size = New System.Drawing.Size(200, 20)
    Me.TxtPassword_verify.TabIndex = 11
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(12, 108)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(92, 12)
    Me.Label6.TabIndex = 12
    Me.Label6.Text = "Verify Password"
    '
    'cbstatus
    '
    Me.cbstatus.AllowDrop = True
    Me.cbstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbstatus.Items.AddRange(New Object() {"Enabled", "Disabled"})
    Me.cbstatus.Location = New System.Drawing.Point(120, 132)
    Me.cbstatus.MaxDropDownItems = 2
    Me.cbstatus.Name = "cbstatus"
    Me.cbstatus.Size = New System.Drawing.Size(144, 21)
    Me.cbstatus.TabIndex = 13
    '
    'Lnkgroup
    '
    Me.Lnkgroup.Location = New System.Drawing.Point(16, 64)
    Me.Lnkgroup.Name = "Lnkgroup"
    Me.Lnkgroup.Size = New System.Drawing.Size(80, 16)
    Me.Lnkgroup.TabIndex = 154
    Me.Lnkgroup.TabStop = True
    Me.Lnkgroup.Text = "Group Code"
    '
    'TxtGroup
    '
    Me.TxtGroup.Location = New System.Drawing.Point(120, 60)
    Me.TxtGroup.MaxLength = 20
    Me.TxtGroup.Name = "TxtGroup"
    Me.TxtGroup.Size = New System.Drawing.Size(200, 20)
    Me.TxtGroup.TabIndex = 3
    '
    'FrmIA001C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(416, 166)
    Me.Controls.Add(Me.Lnkgroup)
    Me.Controls.Add(Me.cbstatus)
    Me.Controls.Add(Me.TxtPassword_verify)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.TxtPassword)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtName)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtGroup)
    Me.Controls.Add(Me.TxtUser)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmIA001C"
    Me.Text = "Maintain User Id"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region
Private Sub FrmIA001C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myGNETUSER = New GNETUSER.MyData()
    myGNETUSER.MyDBConn = myDBConnect
    mygnetgroup = New GNETGROUP.MyData()
    mygnetgroup.MyDBConn = myDBConnect
    MyFrmIA001.TBarNew.Enabled = False
    MyFrmIA001.TBarSave.Enabled = True
    If WrkGNETUSER <> "" Then
      MyFrmIA001.TBarDelete.Enabled = True
      TxtUser.ReadOnly = True
      TxtUser.TabStop = False
    End If
    MyFrmIA001.TBarPrint.Enabled = False

		myGNETUSER.GetOneRecordP(WrkGNETUSER)
    TxtUser.Text = WrkGNETUSER
		If myGNETUSER.RecordNotFound Then
			If s_chg = False And s_full = False Then		'#sec
				MyFrmIA001.TBarSave.Visible = False
			End If
				cbstatus.Text = "Enabled"
				oldhashpw = ""
				Exit Sub
		End If
		With myGNETUSER
				oldhashpw = Trim(._GPWORD)
				TxtGroup.Text = Trim(._GGROUP)
				TxtName.Text = Trim(._GNAME)
				If Trim(._GSTATUS) > "" Then
						cbstatus.Text = Trim(._GSTATUS)
				End If
		End With
End Sub

Private Sub FrmIA001C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmIA001.SbpScreen.Text = "IA001C"
    MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub FrmIA001C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmIA001.TBarNew.Enabled = True
    MyFrmIA001.TBarDelete.Enabled = False
    MyFrmIA001.TBarSave.Enabled = False
    MyFrmIA001.TBarPrint.Enabled = False
    MyFrmIA001.TBarSave.Visible = True   '#sec
    MyFrmIA001B.FormatGrid()
    MyFrmIA001B.Show()
End Sub
Public Sub DeleteData(ByRef WrkCancel As Boolean)
  Dim Answer As Integer
  WrkCancel = True
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
		Exit Sub
  End If
  WrkCancel = False
  myGNETUSER.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
		Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

		myGNETUSER.GetOneRecordP(TxtUser.Text)
    If InStr(Trim(TxtUser.Text), " ") > 0 Then
      Me.ErrProv.SetError(TxtUser, "User Name cannot include a space")
      Exit Sub
    End If

    If Trim(TxtPassword.Text) <> "" Then
      If Len(TxtPassword.Text) < 5 Then
        Me.ErrProv.SetError(TxtPassword, "Passwords must be at least 5 chars long")
        Exit Sub
      End If
      If TxtPassword.Text <> TxtPassword_verify.Text Then
        Me.ErrProv.SetError(TxtPassword, "Passwords do not match. Please reenter")
        Exit Sub
      End If
    End If
    If cbstatus.SelectedIndex < 0 Then
        Me.ErrProv.SetError(cbstatus, "Invalid Status")
        Exit Sub
    End If
    If WrkGNETUSER = "" Then
      If Not myGNETUSER.RecordNotFound Then
        Me.ErrProv.SetError(TxtUser, "Record already exists")
        Exit Sub
      End If
    End If
    If WrkGNETUSER <> "" Then
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myGNETUSER.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      myGNETUSER._GUSER = TxtUser.Text
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
          myGNETUSER.AddOneRecordP()
      Else
          ShowError(ErrorField, ErrorMsg)
          Exit Sub
      End If
    End If
    Me.Close()

End Sub
Private Sub MovetoFile()
		With myGNETUSER
				If IsDBNull(TxtPassword.Text) Then TxtPassword.Text = ""
				._GPWORD = TxtPassword.Text
				._GGROUP = TxtGroup.Text
				._GNAME = TxtName.Text
				._GSTATUS = cbstatus.Text
      If TxtPassword.Text <> "" Then
        TxtPassword.GetHashCode()
        hashedpw = FormsAuthentication.HashPasswordForStoringInConfigFile(TxtPassword.Text, "sha1")
        ._GPWORD = hashedpw
      Else
        ._GPWORD = oldhashpw
				End If
		End With
End Sub
	Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer

		For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next

		If TxtUser.Text = String.Empty Then
			ErrorField(I) = "guser"
			ErrorMsg(I) = "User is required"
			I = I + 1
		End If

		If TxtGroup.Text = String.Empty Then
			ErrorField(I) = "ggroup"
			ErrorMsg(I) = "Group is required"
			I = I + 1
		Else
			mygnetgroup.GetOneRecordP(TxtGroup.Text)
			If mygnetgroup.RecordNotFound Then
				ErrorField(I) = "ggroup"
				ErrorMsg(I) = "Group is invalid"
				I = I + 1
			End If
		End If

		If TxtName.Text = String.Empty Then
			ErrorField(I) = "gname"
			ErrorMsg(I) = "Name is required"
			I = I + 1
		End If
	End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer
		ErrProv.SetError(TxtUser, "")
		ErrProv.SetError(TxtGroup, "")
		ErrProv.SetError(TxtName, "")
		For I = 0 To ErrorField.GetUpperBound(0)
			Select Case ErrorField(I)
			Case "guser"
				ErrProv.SetError(TxtUser, ErrorMsg(I))
			Case "ggroup"
				ErrProv.SetError(TxtGroup, ErrorMsg(I))
			Case "gname"
				ErrProv.SetError(TxtName, ErrorMsg(I))
			Case Nothing
				Exit Sub
			End Select
		Next I
End Sub
Private Sub Lnkgroup_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Lnkgroup.LinkClicked
    MyfrmListgroup = New FrmListgroup
    MyfrmListgroup.MdiParent = Me.ParentForm
    MyfrmListgroup.WrkCode = TxtGroup.Text
    MyfrmListgroup.Show()
End Sub
End Class
