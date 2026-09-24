Public Class FrmTX108C
  Inherits System.Windows.Forms.Form
	Dim myTXBSER As TXBSER.myData
	Friend Wrkbksr As String
  Friend Wrkbsname As String
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
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Txtbksr As System.Windows.Forms.TextBox
Friend WithEvents Txtbsname As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.Label1 = New System.Windows.Forms.Label
Me.Txtbksr = New System.Windows.Forms.TextBox
Me.ErrProv = New System.Windows.Forms.ErrorProvider
Me.Label2 = New System.Windows.Forms.Label
Me.Txtbsname = New System.Windows.Forms.TextBox
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 12)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(104, 16)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Bank Service Code"
'
'Txtbksr
'
Me.Txtbksr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtbksr.Location = New System.Drawing.Point(120, 8)
Me.Txtbksr.MaxLength = 1
Me.Txtbksr.Name = "Txtbksr"
Me.Txtbksr.Size = New System.Drawing.Size(28, 20)
Me.Txtbksr.TabIndex = 0
Me.Txtbksr.Text = ""
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(8, 36)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(104, 16)
Me.Label2.TabIndex = 28
Me.Label2.Text = "Bank Service Name"
'
'Txtbsname
'
Me.Txtbsname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtbsname.Location = New System.Drawing.Point(120, 32)
Me.Txtbsname.MaxLength = 30
Me.Txtbsname.Name = "Txtbsname"
Me.Txtbsname.Size = New System.Drawing.Size(344, 20)
Me.Txtbsname.TabIndex = 2
Me.Txtbsname.Text = ""
'
'FrmTX108C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(486, 64)
Me.Controls.Add(Me.Txtbsname)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Txtbksr)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX108C"
Me.Text = "Maintain Bank Service Codes"
Me.ResumeLayout(False)

    End Sub

#End Region
Private Sub FrmTX108C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	myTXBSER = New TXBSER.mydata(MyDBConnect)
  MyFrmTX108.TBarNew.Enabled = False
  MyFrmTX108.TBarSave.Enabled = True
  MyFrmTX108.TBarPrint.Enabled = False
  If Wrkbksr <> "" Then
    MyFrmTX108.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(Txtbksr)
  End If
  If Wrkbksr = "" Then
    Me.Text = "Add " & Me.Text
    MyFrmTX108.TBarDelete.Enabled = False
    Exit Sub
	End If
	myTXBSER.GetOneRecordP(Wrkbksr)
  Txtbksr.Text = Wrkbksr
	If myTXBSER.RecordNotFound Then
		MyFrmTX108.TBarNew.Enabled = False
		MyFrmTX108.TBarSave.Enabled = False
		MyFrmTX108.TBarDelete.Enabled = False
		Me.ErrProv.SetError(Txtbksr, "Record not found")
		Exit Sub
	End If
  If s_chg = False And s_full = False Then    '#sec
		MyFrmTX108.TBarSave.Visible = False
	End If
	With myTXBSER
		Txtbsname.Text = Trim(._BSNAME)
	End With
End Sub
Private Sub FrmTX108C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX108.SbpScreen.Text = "TX108C"
  MyUtils.CenterForm(Me.ParentForm, Me)
	If Wrkbksr <> "" Then
	End If
End Sub
Private Sub FrmTX108C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTX108.TBarNew.Enabled = True
  MyFrmTX108.TBarDelete.Enabled = False
  MyFrmTX108.TBarSave.Enabled = False
  MyFrmTX108.TBarPrint.Enabled = False
  MyFrmTX108B.FormatGrid()
  MyFrmTX108B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
	myTXBSER.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
	Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
	myTXBSER.GetOneRecordP(Txtbksr.Text)
  If Wrkbksr = "" Then
		If Not myTXBSER.RecordNotFound Then
			Me.ErrProv.SetError(Txtbksr, "Record already exists")
			Exit Sub
		End If
  End If
  If Wrkbksr <> "" Then
    MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
			myTXBSER.UpdateOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If
	Else
		myTXBSER._BKSR = Txtbksr.Text
		MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
			myTXBSER.AddOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
	With myTXBSER
		._BSNAME = Txtbsname.Text
	End With
 End Sub
	Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer

		For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next

		If Txtbksr.Text = String.Empty Then
			ErrorField(I) = "code"
			ErrorMsg(I) = "Code is required"
			I = I + 1
		End If

		If Txtbsname.Text = String.Empty Then
			ErrorField(I) = "name"
			ErrorMsg(I) = "Name is required"
			I = I + 1
		End If
	End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
	Dim I As Integer
	ErrProv.SetError(Txtbksr, "")
	ErrProv.SetError(Txtbsname, "")
	For I = 0 To ErrorField.GetUpperBound(0)
		Select Case ErrorField(I)
		Case "code"
			ErrProv.SetError(Txtbksr, ErrorMsg(I))
		Case "name"
			ErrProv.SetError(Txtbsname, ErrorMsg(I))
		Case Nothing
			Exit Sub
		End Select
	Next I
End Sub

End Class






