Public Class FrmUB105C
  Inherits System.Windows.Forms.Form
	Dim myUTCRESN As UTCRESN.myData
	Friend Wrkcresn As String
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents Txtcresn As System.Windows.Forms.TextBox
Friend WithEvents txtcrdesc As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.Txtcresn = New System.Windows.Forms.TextBox
Me.txtcrdesc = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(24, 16)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(40, 24)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Code"
Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Txtcresn
'
Me.Txtcresn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtcresn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Txtcresn.Location = New System.Drawing.Point(72, 16)
Me.Txtcresn.MaxLength = 1
Me.Txtcresn.Name = "Txtcresn"
Me.Txtcresn.Size = New System.Drawing.Size(16, 22)
Me.Txtcresn.TabIndex = 0
'
'txtcrdesc
'
Me.txtcrdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtcrdesc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.txtcrdesc.Location = New System.Drawing.Point(72, 48)
Me.txtcrdesc.MaxLength = 30
Me.txtcrdesc.Multiline = True
Me.txtcrdesc.Name = "txtcrdesc"
Me.txtcrdesc.Size = New System.Drawing.Size(256, 24)
Me.txtcrdesc.TabIndex = 4
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(0, 48)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(64, 24)
Me.Label3.TabIndex = 4
Me.Label3.Text = "Description"
Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'FrmUB105C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(354, 94)
Me.Controls.Add(Me.txtcrdesc)
Me.Controls.Add(Me.Txtcresn)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmUB105C"
Me.Text = "Maintain Adjustment Codes"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmUB105C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	myUTCRESN = New UTCRESN.mydata(MyDBConnect)
  MyFrmUB105.TBarNew.Enabled = False
  MyFrmUB105.TBarSave.Enabled = True
  If Wrkcresn <> "" Then
    MyFrmUB105.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(Txtcresn)
  End If
  MyFrmUB105.TBarPrint.Enabled = False
	myUTCRESN.GetOneRecordP(Wrkcresn)
  Txtcresn.Text = Wrkcresn
  If myUTCRESN.RecordNotFound Then Exit Sub

	If s_chg = False And s_full = False Then		'#sec
		MyFrmUB105.TBarSave.Visible = False
	End If
	With myUTCRESN
		txtcrdesc.Text = Trim(._CRDESC)
	End With
End Sub
Private Sub FrmUB105C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB105.SbpScreen.Text = "UB105C"
  MyUtils.CenterForm(Me.ParentForm, Me)
  With MyFrmUB105
    .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
    .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
  End With
End Sub
Private Sub FrmUB105C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmUB105.TBarNew.Enabled = True
  MyFrmUB105.TBarDelete.Enabled = False
  MyFrmUB105.TBarSave.Enabled = False
  MyFrmUB105.TBarPrint.Enabled = False
  MyFrmUB105.TBarSave.Visible = True   '#sec
  MyFrmUB105B.FormatGrid()
  MyFrmUB105B.Show()
End Sub
Public Sub DeleteData(ByRef WrkCancel As Boolean)
  Dim Answer As Integer
  WrkCancel = True
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
		Exit Sub
  End If
  WrkCancel = False
	myUTCRESN.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
	Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
	myUTCRESN.GetOneRecordP(Txtcresn.Text)
  If Wrkcresn = "" Then
		If Not myUTCRESN.RecordNotFound Then
			Me.ErrProv.SetError(Txtcresn, "Record already exists")
			Exit Sub
		End If
  End If
  If Wrkcresn <> "" Then
    MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
			myUTCRESN.UpdateOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If
  Else
		myUTCRESN._CRESN = Txtcresn.Text
    MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
			myUTCRESN.AddOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
	With myUTCRESN
		._CRDESC = txtcrdesc.Text
	End With
End Sub
	Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer

		For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next

		If Txtcresn.Text = String.Empty Then
			ErrorField(I) = "cresn"
			ErrorMsg(I) = "Code is required"
			I = I + 1
		End If
		If txtcrdesc.Text = String.Empty Then
			ErrorField(I) = "crdesc"
			ErrorMsg(I) = "Description is required"
			I = I + 1
		End If
	End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
	Dim I As Integer
	ErrProv.SetError(Txtcresn, "")
	ErrProv.SetError(txtcrdesc, "")
	For I = 0 To ErrorField.GetUpperBound(0)
		Select Case ErrorField(I)
		Case "cresn"
			ErrProv.SetError(Txtcresn, ErrorMsg(I))
		Case "crdesc"
			ErrProv.SetError(txtcrdesc, ErrorMsg(I))
		Case Nothing
			Exit Sub
		End Select
	Next I
End Sub
End Class







