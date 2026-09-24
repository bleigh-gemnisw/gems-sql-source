Public Class FRMIA003C

    Inherits System.windows.forms.Form

		Dim myGNETPGM As GNETPGM.myData
		Friend WrkGNETPGM As String
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
		Friend WithEvents TxtPgmID As System.Windows.Forms.TextBox
		Friend WithEvents Label6 As System.Windows.Forms.Label
		Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
		Friend WithEvents TxtAppID As System.Windows.Forms.TextBox
		Friend WithEvents TxtEXE As System.Windows.Forms.TextBox
		Friend WithEvents Label1 As System.Windows.Forms.Label
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRMIA003C))
Me.TxtPgmID = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.Label4 = New System.Windows.Forms.Label
Me.TxtDesc = New System.Windows.Forms.TextBox
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TxtAppID = New System.Windows.Forms.TextBox
Me.Label6 = New System.Windows.Forms.Label
Me.TxtEXE = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'TxtPgmID
'
Me.TxtPgmID.Location = New System.Drawing.Point(120, 24)
Me.TxtPgmID.MaxLength = 10
Me.TxtPgmID.Name = "TxtPgmID"
Me.TxtPgmID.Size = New System.Drawing.Size(200, 20)
Me.TxtPgmID.TabIndex = 3
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(8, 24)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(92, 24)
Me.Label3.TabIndex = 4
Me.Label3.Text = "Program Id"
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(8, 51)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(92, 24)
Me.Label4.TabIndex = 6
Me.Label4.Text = "Description"
'
'TxtDesc
'
Me.TxtDesc.Location = New System.Drawing.Point(120, 48)
Me.TxtDesc.MaxLength = 100
Me.TxtDesc.Multiline = True
Me.TxtDesc.Name = "TxtDesc"
Me.TxtDesc.Size = New System.Drawing.Size(288, 40)
Me.TxtDesc.TabIndex = 4
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'TxtAppID
'
Me.TxtAppID.Location = New System.Drawing.Point(120, 96)
Me.TxtAppID.MaxLength = 2
Me.TxtAppID.Name = "TxtAppID"
Me.TxtAppID.Size = New System.Drawing.Size(32, 20)
Me.TxtAppID.TabIndex = 5
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(8, 96)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(92, 24)
Me.Label6.TabIndex = 12
Me.Label6.Text = "App Id"
'
'TxtEXE
'
Me.TxtEXE.Location = New System.Drawing.Point(120, 120)
Me.TxtEXE.MaxLength = 50
Me.TxtEXE.Name = "TxtEXE"
Me.TxtEXE.Size = New System.Drawing.Size(280, 20)
Me.TxtEXE.TabIndex = 6
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 120)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(92, 24)
Me.Label1.TabIndex = 14
Me.Label1.Text = "Executable"
'
'FRMIA003C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(424, 166)
Me.Controls.Add(Me.TxtEXE)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.TxtAppID)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.TxtDesc)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.TxtPgmID)
Me.Controls.Add(Me.Label3)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FRMIA003C"
Me.Text = "Maintain Program Id"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region
Private Sub FRMIA003C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myGNETPGM = New GNETPGM.MyData()
    myGNETPGM.MyDBConn = myDBConnect
		MyFRMIA003.TBarNew.Enabled = False
		MyFRMIA003.TBarSave.Enabled = True
		MyFRMIA003.TBarFTP.Enabled = False
		If WrkGNETPGM <> "" Then
			MyFRMIA003.TBarDelete.Enabled = True
			TxtPgmID.ReadOnly = True
			TxtPgmID.TabStop = False
		End If

		myGNETPGM.GetOneRecordP(WrkGNETPGM)
		TxtPgmID.Text = WrkGNETPGM
		If myGNETPGM.RecordNotFound Then
				Exit Sub
		End If
		If s_chg = False And s_full = False Then		'#sec
			MyFRMIA003.TBarSave.Visible = False
		End If
		With myGNETPGM
			TxtAppID.Text = Trim(._PGMAPP)
			TxtDesc.Text = Trim(._PGMDESC)
			TxtEXE.Text = Trim(._PGMEXE)
		End With
End Sub
Private Sub FRMIA003C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
		MyFRMIA003.SbpScreen.Text = "IA003C"
    MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FRMIA003C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		MyFRMIA003.TBarNew.Enabled = True
		MyFRMIA003.TBarDelete.Enabled = False
		MyFRMIA003.TBarSave.Enabled = False
		MyFRMIA003.TBarPrint.Enabled = False
		MyFRMIA003.TBarSave.Visible = True
		MyFRMIA003.TBarFTP.Enabled = True
		MyFRMIA003B.FormatGrid()
		MyFRMIA003B.Show()
End Sub
Public Sub DeleteData(ByRef WrkCancel As Boolean)
	Dim Answer As Integer
	WrkCancel = True
	Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
	If Answer = vbNo Then
		Exit Sub
	End If
	WrkCancel = False
	myGNETPGM.DeleteOneRecordP()
	Me.Close()
End Sub
Public Sub SaveData()
		Dim ErrorField(25) As String
		Dim ErrorMsg(25) As String

		myGNETPGM.GetOneRecordP(TxtPgmID.Text)

		If WrkGNETPGM = "" Then
			If Not myGNETPGM.RecordNotFound Then
				Me.ErrProv.SetError(TxtPgmID, "Record already exists")
				Exit Sub
			End If
		End If
		If WrkGNETPGM <> "" Then
				MovetoFile()
				EditChecks(ErrorField, ErrorMsg)
				If IsNothing(ErrorMsg(0)) Then
					myGNETPGM.UpdateOneRecordP()
				Else
					ShowError(ErrorField, ErrorMsg)
					Exit Sub
				End If
		Else
				myGNETPGM._PGMID = TxtPgmID.Text
				MovetoFile()
				EditChecks(ErrorField, ErrorMsg)
				If IsNothing(ErrorMsg(0)) Then
						myGNETPGM.AddOneRecordP()
				Else
						ShowError(ErrorField, ErrorMsg)
						Exit Sub
				End If
		End If
		Me.Close()

End Sub
Private Sub MovetoFile()
		With myGNETPGM
			._PGMDESC = TxtDesc.Text
			._PGMAPP = TxtAppID.Text
			._PGMEXE = TxtEXE.Text
		End With
End Sub
Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer

		For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next

		If TxtPgmID.Text = String.Empty Then
			ErrorField(I) = "pgmid"
			ErrorMsg(I) = "Program ID is required"
			I = I + 1
		End If

		If TxtDesc.Text = String.Empty Then
			ErrorField(I) = "pgmdesc"
			ErrorMsg(I) = "Program Descriptiopn is required"
			I = I + 1
		End If

		If TxtAppID.Text = String.Empty Then
			ErrorField(I) = "pgmapp"
			ErrorMsg(I) = "Application ID is required"
			I = I + 1
		End If

		If TxtEXE.Text = String.Empty Then
			ErrorField(I) = "pgmexe"
			ErrorMsg(I) = "Program EXE is required"
			I = I + 1
		End If
End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer
		ErrProv.SetError(TxtPgmID, "")
		ErrProv.SetError(TxtDesc, "")
		ErrProv.SetError(TxtAppID, "")
		ErrProv.SetError(TxtEXE, "")
		For I = 0 To ErrorField.GetUpperBound(0)
			Select Case ErrorField(I)
			Case "pgmid"
				ErrProv.SetError(TxtPgmID, ErrorMsg(I))
			Case "pgmdesc"
				ErrProv.SetError(TxtDesc, ErrorMsg(I))
			Case "pgmapp"
				ErrProv.SetError(TxtDesc, ErrorMsg(I))
			Case "pgmexe"
				ErrProv.SetError(TxtEXE, ErrorMsg(I))
			Case Nothing
				Exit Sub
			End Select
		Next I
End Sub
End Class
