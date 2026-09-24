Imports System.io
Imports System.Security.Cryptography
Imports System.Text
Public Class FrmSignOn
    Inherits System.Windows.Forms.Form
    Dim MyGNETUSER As GNETUSER.MyData
    Dim WrkDatabaseName As String
    Dim WrkAttempts As Integer
    Dim WrkPubRecs As Integer
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
Friend WithEvents label4 As System.Windows.Forms.Label
Friend WithEvents label3 As System.Windows.Forms.Label
Friend WithEvents label2 As System.Windows.Forms.Label
Friend WithEvents label1 As System.Windows.Forms.Label
Friend WithEvents BtnCancel As System.Windows.Forms.Button
Friend WithEvents TxtPassword As System.Windows.Forms.TextBox
Friend WithEvents TxtUser As System.Windows.Forms.TextBox
Friend WithEvents BtnContinue As System.Windows.Forms.Button
Friend WithEvents CboDatabase As System.Windows.Forms.ComboBox
Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSignOn))
    Me.BtnCancel = New System.Windows.Forms.Button()
    Me.label4 = New System.Windows.Forms.Label()
    Me.label3 = New System.Windows.Forms.Label()
    Me.label2 = New System.Windows.Forms.Label()
    Me.TxtPassword = New System.Windows.Forms.TextBox()
    Me.TxtUser = New System.Windows.Forms.TextBox()
    Me.label1 = New System.Windows.Forms.Label()
    Me.BtnContinue = New System.Windows.Forms.Button()
    Me.CboDatabase = New System.Windows.Forms.ComboBox()
    Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
    Me.SuspendLayout()
    '
    'BtnCancel
    '
    Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.BtnCancel.Location = New System.Drawing.Point(236, 204)
    Me.BtnCancel.Name = "BtnCancel"
    Me.BtnCancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
    Me.BtnCancel.Size = New System.Drawing.Size(104, 48)
    Me.BtnCancel.TabIndex = 4
    Me.BtnCancel.TabStop = False
    Me.BtnCancel.Text = "Cancel"
    '
    'label4
    '
    Me.label4.Font = New System.Drawing.Font("Arial", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label4.ForeColor = System.Drawing.Color.Maroon
    Me.label4.Image = CType(resources.GetObject("label4.Image"), System.Drawing.Image)
    Me.label4.Location = New System.Drawing.Point(61, 9)
    Me.label4.Name = "label4"
    Me.label4.Size = New System.Drawing.Size(288, 56)
    Me.label4.TabIndex = 19
    '
    'label3
    '
    Me.label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label3.Location = New System.Drawing.Point(50, 122)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(136, 24)
    Me.label3.TabIndex = 18
    Me.label3.Text = "Password"
    '
    'label2
    '
    Me.label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label2.Location = New System.Drawing.Point(48, 88)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(136, 24)
    Me.label2.TabIndex = 16
    Me.label2.Text = "User Name"
    '
    'TxtPassword
    '
    Me.TxtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPassword.Location = New System.Drawing.Point(192, 120)
    Me.TxtPassword.Name = "TxtPassword"
    Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.TxtPassword.Size = New System.Drawing.Size(168, 26)
    Me.TxtPassword.TabIndex = 1
    '
    'TxtUser
    '
    Me.TxtUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUser.Location = New System.Drawing.Point(192, 88)
    Me.TxtUser.Name = "TxtUser"
    Me.TxtUser.Size = New System.Drawing.Size(168, 26)
    Me.TxtUser.TabIndex = 0
    '
    'label1
    '
    Me.label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label1.Location = New System.Drawing.Point(48, 156)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(136, 24)
    Me.label1.TabIndex = 12
    Me.label1.Text = "Select Database"
    '
    'BtnContinue
    '
    Me.BtnContinue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnContinue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.BtnContinue.Location = New System.Drawing.Point(82, 204)
    Me.BtnContinue.Name = "BtnContinue"
    Me.BtnContinue.Size = New System.Drawing.Size(104, 48)
    Me.BtnContinue.TabIndex = 3
    Me.BtnContinue.Text = "Continue"
    '
    'CboDatabase
    '
    Me.CboDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.CboDatabase.Location = New System.Drawing.Point(190, 152)
    Me.CboDatabase.Name = "CboDatabase"
    Me.CboDatabase.Size = New System.Drawing.Size(180, 28)
    Me.CboDatabase.TabIndex = 2
    '
    'FrmSignOn
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
    Me.ClientSize = New System.Drawing.Size(392, 277)
    Me.Controls.Add(Me.BtnCancel)
    Me.Controls.Add(Me.label4)
    Me.Controls.Add(Me.label3)
    Me.Controls.Add(Me.label2)
    Me.Controls.Add(Me.TxtPassword)
    Me.Controls.Add(Me.TxtUser)
    Me.Controls.Add(Me.label1)
    Me.Controls.Add(Me.BtnContinue)
    Me.Controls.Add(Me.CboDatabase)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmSignOn"
    Me.HelpProvider1.SetShowHelp(Me, True)
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "GEMS"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmSignOn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    HelpProvider1.HelpNamespace = DataPath & "GemsHelp\signon.chm"

    CboDatabase.Items.Add(MyDBSettings.DatabaseName)
    If Trim(MyDBSettings.DatabaseName2) <> "" Then
      CboDatabase.Items.Add(MyDBSettings.DatabaseName2)
    End If
    If (MyAppSettings.DatabaseName & "") <> String.Empty Then
        CboDatabase.Text = MyAppSettings.DatabaseName
      End If
      WrkAttempts = 0
  End Sub
  Private Sub BtnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnContinue.Click
	LogIn()
End Sub
Private Sub CheckSubDirs()
	Try
    If Not Directory.Exists(MyUtils.GetDataPath() & "GemsHelp") Then
      Directory.CreateDirectory(MyUtils.GetDataPath() & "GemsHelp")
    End If
    If Not Directory.Exists(MyUtils.GetDataPath() & "Logs") Then
      Directory.CreateDirectory(MyUtils.GetDataPath() & "Logs")
    End If
    If Not Directory.Exists(MyUtils.GetDataPath() & "RWA") Then
      Directory.CreateDirectory(MyUtils.GetDataPath() & "RWA")
    End If
    If Not Directory.Exists(MyUtils.GetDataPath() & "Settings") Then
      Directory.CreateDirectory(MyUtils.GetDataPath() & "Settings")
    End If
	Catch
	End Try
End Sub
  Private Sub LogIn()
    'Dim Good As Boolean
    Dim WrkDBName As String
    Dim WrkHash As String
    Dim WrkSecGroup As String
    Dim WrkEXECall As String
    Dim WrkVal As Integer

    CheckSubDirs()
    If CboDatabase.SelectedIndex < 0 Then
      MsgBox("Please Select Database to Log into", MsgBoxStyle.Exclamation, "Login ERROR")
      Exit Sub
    End If

    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    WrkDBName = CboDatabase.Text
    myDBConnect = New SQLConnect.DBConnection(WrkDBName)

    Try
      myDBConnect.Open()
    Catch ex As Exception
      MsgBox("Error connecting to " & WrkDBName, MsgBoxStyle.Critical, "Program aborting")
      Windows.Forms.Cursor.Current = Cursors.Default
      Exit Sub
    End Try

    myDBConnect.Close()
    MyGNETUSER = New GNETUSER.MyData()
    MyGNETUSER.MyDBConn = myDBConnect
    'chain for user id & password
    MyGNETUSER.GetOneRecordP(TxtUser.Text)
    If MyGNETUSER.RecordNotFound Then
      MsgBox("Invalid User Name", MsgBoxStyle.Exclamation)
      Exit Sub
    End If

    With MyGNETUSER
      If ._GSTATUS = "Disabled" Then
        MsgBox(" User Profile Disabled. Contact your Security Officer for Assistance - Program Ending ")
        End
      End If

      If Trim(._GPWORD) = String.Empty Then
        LaunchEXE("IA001", WrkDBName, TxtUser.Text, "password")
        Exit Sub
      Else
        WrkHash = CreateHash(TxtPassword.Text)
        If Trim(._GPWORD) <> WrkHash Then
          MsgBox("Invalid Password", MsgBoxStyle.Exclamation)
          WrkAttempts = WrkAttempts + 1
          If WrkAttempts = 5 Then
            ._GSTATUS = "Disabled"
            '          .UpdateOneRecordP(ds)
            MsgBox(" You have reached limit for log in attempts - Program Ending ")
            End
          End If
          Exit Sub
        End If
        WrkSecGroup = Trim(._GGROUP)
      End If
    End With

    WrkEXECall = DataPath & "Gems Menus.exe " & WrkDBName & " " &
    TxtUser.Text & " " & WrkSecGroup

    WrkVal = Shell(WrkEXECall, AppWinStyle.NormalFocus)
    If WrkVal = 0 Then
      MsgBox("Error running Gems Menus. Please contact Hotline", MsgBoxStyle.Critical, "Program error")
    End If

    If MyAppSettings.DatabaseName <> CboDatabase.Text Then
      SaveAppSettings()
    End If
    End
  End Sub
  Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
  End
End Sub
Private Sub FrmSignOn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If e.KeyCode = Keys.Enter Then
    LogIn()
    Exit Sub
  End If

End Sub
 Public Shared Function CreateHash(ByVal saltAndPassword As String) As String
    Dim Algorithm As SHA1 = SHA1.Create()
    Dim Data As Byte() = Algorithm.ComputeHash(Encoding.UTF8.GetBytes(saltAndPassword))
    Dim Hashed As String = ""

    For i As Integer = 0 To Data.Length - 1
        Hashed &= Data(i).ToString("x2").ToUpperInvariant()
    Next

    Return Hashed
End Function
End Class
