Public Class FrmTA106C
  Inherits System.Windows.Forms.Form
	Dim myTXCRESN As TXCRESN.MyData
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
Friend WithEvents txtcrdesc As System.Windows.Forms.TextBox
Friend WithEvents Txtcresn As System.Windows.Forms.TextBox
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
Me.Label1.Location = New System.Drawing.Point(8, 12)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(76, 24)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Reason Code:"
'
'Txtcresn
'
Me.Txtcresn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtcresn.Location = New System.Drawing.Point(96, 12)
Me.Txtcresn.MaxLength = 1
Me.Txtcresn.Name = "Txtcresn"
Me.Txtcresn.Size = New System.Drawing.Size(18, 20)
Me.Txtcresn.TabIndex = 0
'
'txtcrdesc
'
Me.txtcrdesc.Location = New System.Drawing.Point(96, 36)
Me.txtcrdesc.MaxLength = 30
Me.txtcrdesc.Name = "txtcrdesc"
Me.txtcrdesc.Size = New System.Drawing.Size(280, 20)
Me.txtcrdesc.TabIndex = 1
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(8, 36)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(76, 24)
Me.Label3.TabIndex = 4
Me.Label3.Text = "Description:"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'FrmTA106C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(404, 62)
Me.Controls.Add(Me.txtcrdesc)
Me.Controls.Add(Me.Txtcresn)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA106C"
Me.Text = "Maintain C of C Reason Codes"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTA106C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	myTXCRESN = New TXCRESN.mydata(MyDBConnect)
	MyFrmTA106.TBarNew.Enabled = False
	MyFrmTA106.TBarSave.Enabled = True
	If Wrkcresn <> "" Then
		MyFrmTA106.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(Txtcresn)
	End If
	MyFrmTA106.TBarPrint.Enabled = False
	myTXCRESN.GetOneRecordP(Wrkcresn)
	Txtcresn.Text = Wrkcresn
	If myTXCRESN.RecordNotFound Then Exit Sub
		If s_chg = False And s_full = False Then		'#sec
			MyFrmTA106.TBarSave.Visible = False
		End If
	With myTXCRESN
		txtcrdesc.Text = Trim(._CRDESC)
	 End With
End Sub
Private Sub FrmTA106C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA106.SbpScreen.Text = "TA106C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmTA106C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTA106.TBarNew.Enabled = True
  MyFrmTA106.TBarDelete.Enabled = False
  MyFrmTA106.TBarSave.Enabled = False
  MyFrmTA106.TBarPrint.Enabled = False
  MyFrmTA106.TBarSave.Visible = True
  MyFrmTA106B.FormatGrid()
  MyFrmTA106B.Show()
End Sub
Public Sub DeleteData(byref wrkcancel as Boolean)
  Dim Answer As Integer
  wrkcancel = True
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
		Exit Sub
  End If
  wrkcancel = False
	myTXCRESN.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
	Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
	myTXCRESN.GetOneRecordP(Txtcresn.Text)
  If Wrkcresn = "" Then
		If Not myTXCRESN.RecordNotFound Then
			Me.ErrProv.SetError(Txtcresn, "Record already exists")
		Exit Sub
		End If
  End If
  If Wrkcresn <> "" Then
    MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
			myTXCRESN.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
			Exit Sub
    End If
  Else
		myTXCRESN._CRESN = Txtcresn.Text
    MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
			myTXCRESN.AddOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
	With myTXCRESN
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
			ErrorMsg(I) = "description is required"
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
Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
End Sub
Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
End Sub
End Class






