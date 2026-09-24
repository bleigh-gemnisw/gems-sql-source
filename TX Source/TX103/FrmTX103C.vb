Public Class FrmTX103C
  Inherits System.Windows.Forms.Form
	Dim myTXENDRS As TXENDRS.MyData
	Friend Wrktype As String
	Friend WrkAddMode As Boolean

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
Friend WithEvents Txttype As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents Txtel1 As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents Txtel2 As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents Txtel3 As System.Windows.Forms.TextBox
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents Txtel4 As System.Windows.Forms.TextBox
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents Txtel5 As System.Windows.Forms.TextBox
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents Txtel6 As System.Windows.Forms.TextBox
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents Txtel7 As System.Windows.Forms.TextBox
Friend WithEvents Label9 As System.Windows.Forms.Label
Friend WithEvents Txtel8 As System.Windows.Forms.TextBox
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.ErrProv = New System.Windows.Forms.ErrorProvider
Me.Txttype = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.Txtel1 = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
Me.Txtel2 = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.Txtel3 = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
Me.Txtel4 = New System.Windows.Forms.TextBox
Me.Label6 = New System.Windows.Forms.Label
Me.Txtel5 = New System.Windows.Forms.TextBox
Me.Label7 = New System.Windows.Forms.Label
Me.Txtel6 = New System.Windows.Forms.TextBox
Me.Label8 = New System.Windows.Forms.Label
Me.Txtel7 = New System.Windows.Forms.TextBox
Me.Label9 = New System.Windows.Forms.Label
Me.Txtel8 = New System.Windows.Forms.TextBox
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Txttype
'
Me.Txttype.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txttype.Location = New System.Drawing.Point(48, 16)
Me.Txttype.MaxLength = 1
Me.Txttype.Name = "Txttype"
Me.Txttype.Size = New System.Drawing.Size(20, 20)
Me.Txttype.TabIndex = 0
Me.Txttype.Text = ""
'
'Label1
'
Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label1.Location = New System.Drawing.Point(8, 20)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(36, 16)
Me.Label1.TabIndex = 1
Me.Label1.Text = "Type:"
Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Txtel1
'
Me.Txtel1.Location = New System.Drawing.Point(160, 52)
Me.Txtel1.MaxLength = 30
Me.Txtel1.Name = "Txtel1"
Me.Txtel1.Size = New System.Drawing.Size(336, 20)
Me.Txtel1.TabIndex = 2
Me.Txtel1.Text = ""
'
'Label2
'
Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label2.Location = New System.Drawing.Point(36, 52)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(120, 20)
Me.Label2.TabIndex = 3
Me.Label2.Text = "Endorsement Line 1:"
Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label3
'
Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label3.Location = New System.Drawing.Point(36, 80)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(120, 20)
Me.Label3.TabIndex = 5
Me.Label3.Text = "Endorsement Line 2:"
Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Txtel2
'
Me.Txtel2.Location = New System.Drawing.Point(160, 80)
Me.Txtel2.MaxLength = 30
Me.Txtel2.Name = "Txtel2"
Me.Txtel2.Size = New System.Drawing.Size(336, 20)
Me.Txtel2.TabIndex = 4
Me.Txtel2.Text = ""
'
'Label4
'
Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label4.Location = New System.Drawing.Point(36, 108)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(120, 20)
Me.Label4.TabIndex = 7
Me.Label4.Text = "Endorsement Line 3:"
Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Txtel3
'
Me.Txtel3.Location = New System.Drawing.Point(160, 108)
Me.Txtel3.MaxLength = 30
Me.Txtel3.Name = "Txtel3"
Me.Txtel3.Size = New System.Drawing.Size(336, 20)
Me.Txtel3.TabIndex = 6
Me.Txtel3.Text = ""
'
'Label5
'
Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label5.Location = New System.Drawing.Point(36, 136)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(120, 20)
Me.Label5.TabIndex = 9
Me.Label5.Text = "Endorsement Line 4:"
Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Txtel4
'
Me.Txtel4.Location = New System.Drawing.Point(160, 136)
Me.Txtel4.MaxLength = 30
Me.Txtel4.Name = "Txtel4"
Me.Txtel4.Size = New System.Drawing.Size(336, 20)
Me.Txtel4.TabIndex = 8
Me.Txtel4.Text = ""
'
'Label6
'
Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label6.Location = New System.Drawing.Point(36, 164)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(120, 20)
Me.Label6.TabIndex = 11
Me.Label6.Text = "Endorsement Line 5:"
Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Txtel5
'
Me.Txtel5.Location = New System.Drawing.Point(160, 164)
Me.Txtel5.MaxLength = 30
Me.Txtel5.Name = "Txtel5"
Me.Txtel5.Size = New System.Drawing.Size(336, 20)
Me.Txtel5.TabIndex = 10
Me.Txtel5.Text = ""
'
'Label7
'
Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label7.Location = New System.Drawing.Point(36, 192)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(120, 20)
Me.Label7.TabIndex = 13
Me.Label7.Text = "Endorsement Line 6:"
Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Txtel6
'
Me.Txtel6.Location = New System.Drawing.Point(160, 192)
Me.Txtel6.MaxLength = 30
Me.Txtel6.Name = "Txtel6"
Me.Txtel6.Size = New System.Drawing.Size(336, 20)
Me.Txtel6.TabIndex = 12
Me.Txtel6.Text = ""
'
'Label8
'
Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label8.Location = New System.Drawing.Point(36, 220)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(120, 20)
Me.Label8.TabIndex = 15
Me.Label8.Text = "Endorsement Line 7:"
Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Txtel7
'
Me.Txtel7.Location = New System.Drawing.Point(160, 220)
Me.Txtel7.MaxLength = 30
Me.Txtel7.Name = "Txtel7"
Me.Txtel7.Size = New System.Drawing.Size(336, 20)
Me.Txtel7.TabIndex = 14
Me.Txtel7.Text = ""
'
'Label9
'
Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label9.Location = New System.Drawing.Point(36, 248)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(120, 20)
Me.Label9.TabIndex = 17
Me.Label9.Text = "Endorsement Line 8:"
Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Txtel8
'
Me.Txtel8.Location = New System.Drawing.Point(160, 248)
Me.Txtel8.MaxLength = 30
Me.Txtel8.Name = "Txtel8"
Me.Txtel8.Size = New System.Drawing.Size(336, 20)
Me.Txtel8.TabIndex = 16
Me.Txtel8.Text = ""
'
'FrmTX103C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(506, 280)
Me.Controls.Add(Me.Label9)
Me.Controls.Add(Me.Txtel8)
Me.Controls.Add(Me.Label8)
Me.Controls.Add(Me.Txtel7)
Me.Controls.Add(Me.Label7)
Me.Controls.Add(Me.Txtel6)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.Txtel5)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.Txtel4)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.Txtel3)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Txtel2)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Txtel1)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.Txttype)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX103C"
Me.Text = "Maintain Check Endorsement Information"
Me.ResumeLayout(False)

		End Sub

#End Region

	Private Sub FrmTX103C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	myTXENDRS = New TXENDRS.mydata(MyDBConnect)
	MyFrmTX103.TBarNew.Enabled = False
	MyFrmTX103.TBarSave.Enabled = True
	If Not WrkAddMode Then
		MyFrmTX103.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(Txttype)
	Else
		Exit Sub
	End If

	MyFrmTX103.TBarPrint.Enabled = False
	myTXENDRS.GetOneRecordP(Wrktype)
	Txttype.Text = Wrktype
	If myTXENDRS.RecordNotFound Then Exit Sub
		With myTXENDRS
			Txtel1.Text = Trim(._EL1)
			Txtel2.Text = Trim(._EL2)
			Txtel3.Text = Trim(._EL3)
			Txtel4.Text = Trim(._EL4)
			Txtel5.Text = Trim(._EL5)
			Txtel6.Text = Trim(._EL6)
			Txtel7.Text = Trim(._EL7)
			Txtel8.Text = Trim(._EL8)
		End With
	End Sub

Private Sub FrmTX103C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX103.SbpScreen.Text = "TX103C"
  MyUtils.CenterForm(Me.ParentForm, Me)
    If Wrktype <> "" Then
    End If
End Sub

Private Sub FrmTX103C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTX103.TBarNew.Enabled = True
  MyFrmTX103.TBarDelete.Enabled = False
  MyFrmTX103.TBarSave.Enabled = False
  MyFrmTX103.TBarPrint.Enabled = False
  MyFrmTX103B.FormatGrid()
  MyFrmTX103B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
	myTXENDRS.DeleteOneRecordP()
  Me.Close()
End Sub

Public Sub SaveData()
	Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
	myTXENDRS.GetOneRecordP(Txttype.Text)
  If WrkAddMode Then
		If Not myTXENDRS.RecordNotFound Then
			Me.ErrProv.SetError(Txttype, "Record already exists")
			Exit Sub
		End If
  End If
  If Not WrkAddMode Then
    MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
			myTXENDRS.UpdateOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
    End If
    Else
		myTXENDRS._TYPE = Txttype.Text
    MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
			myTXENDRS.AddOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
	With myTXENDRS
	._EL1 = Txtel1.Text
	._EL2 = Txtel2.Text
	._EL3 = Txtel3.Text
	._EL4 = Txtel4.Text
	._EL5 = Txtel5.Text
	._EL6 = Txtel6.Text
	._EL7 = Txtel7.Text
	._EL8 = Txtel8.Text
 End With
 End Sub
	Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer

		For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next

		'If Txttype.Text = String.Empty Then
		'	ErrorField(I) = "type"
		'	ErrorMsg(I) = "Type is required"
		'	I = I + 1
		'End If

End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
	Dim I As Integer
'	ErrProv.SetError(Txttype, "")
	For I = 0 To ErrorField.GetUpperBound(0)
		Select Case ErrorField(I)
'		Case "type"
'			ErrProv.SetError(Txttype, ErrorMsg(I))
		Case Nothing
			Exit Sub
		End Select
	Next I
End Sub
End Class






