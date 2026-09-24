Public Class FrmTX104C
  Inherits System.Windows.Forms.Form
	Dim myTXSTS As TXSTS.myData
  Friend Wrkstcode As String
  Friend Wrkstdesc As String
  

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
Friend WithEvents Txtstcode As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Txtstdesc As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.Label1 = New System.Windows.Forms.Label
Me.Txtstcode = New System.Windows.Forms.TextBox
Me.ErrProv = New System.Windows.Forms.ErrorProvider
Me.Label2 = New System.Windows.Forms.Label
Me.Txtstdesc = New System.Windows.Forms.TextBox
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 12)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(68, 16)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Status Code"
'
'Txtstcode
'
Me.Txtstcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtstcode.Location = New System.Drawing.Point(76, 8)
Me.Txtstcode.MaxLength = 1
Me.Txtstcode.Name = "Txtstcode"
Me.Txtstcode.Size = New System.Drawing.Size(24, 20)
Me.Txtstcode.TabIndex = 1
Me.Txtstcode.Text = ""
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(116, 12)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(92, 16)
Me.Label2.TabIndex = 28
Me.Label2.Text = "Code Description"
Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Txtstdesc
'
Me.Txtstdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtstdesc.Location = New System.Drawing.Point(208, 8)
Me.Txtstdesc.MaxLength = 30
Me.Txtstdesc.Name = "Txtstdesc"
Me.Txtstdesc.Size = New System.Drawing.Size(344, 20)
Me.Txtstdesc.TabIndex = 2
Me.Txtstdesc.Text = ""
'
'FrmTX104C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(566, 44)
Me.Controls.Add(Me.Txtstdesc)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Txtstcode)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX104C"
Me.Text = "Maintain Status Codes"
Me.ResumeLayout(False)

    End Sub

#End Region

  Private Sub FrmTX104C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	myTXSTS = New TXSTS.mydata(MyDBConnect)
  MyFrmTX104.TBarNew.Enabled = False
  MyFrmTX104.TBarSave.Enabled = True
  MyFrmTX104.TBarPrint.Enabled = False
  If Wrkstcode <> "" Then
    MyFrmTX104.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(Txtstcode)
  End If
  If Wrkstcode = "" Then
    Me.Text = "Add " & Me.Text
    MyFrmTX104.TBarDelete.Enabled = False
    Exit Sub
    End If
	myTXSTS.GetOneRecordP(Wrkstcode)
  Txtstcode.Text = Wrkstcode
  Txtstdesc.Text = Wrkstdesc

	If myTXSTS.RecordNotFound Then
		MyFrmTX104.TBarNew.Enabled = False
		MyFrmTX104.TBarSave.Enabled = False
		MyFrmTX104.TBarDelete.Enabled = False
		Me.ErrProv.SetError(Txtstcode, "Record not found")
		Exit Sub
	End If

  If s_chg = False And s_full = False Then    '#sec
		MyFrmTX104.TBarSave.Visible = False
	End If
'	With myTXSTS
		Txtstdesc.Text = Wrkstdesc
'	End With
End Sub
Private Sub FrmTX104C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX104.SbpScreen.Text = "TX104C"
  MyUtils.CenterForm(Me.ParentForm, Me)
	If Wrkstcode <> "" Then
	End If
End Sub

Private Sub FrmTX104C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTX104.TBarNew.Enabled = True
  MyFrmTX104.TBarDelete.Enabled = False
  MyFrmTX104.TBarSave.Enabled = False
  MyFrmTX104.TBarPrint.Enabled = False
  MyFrmTX104B.FormatGrid()
  MyFrmTX104B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
	myTXSTS.DeleteOneRecordP()
  Me.Close()
End Sub

Public Sub SaveData()
	Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
	myTXSTS.GetOneRecordP(Txtstcode.Text)
  If Wrkstcode = "" Then
		If Not myTXSTS.RecordNotFound Then
			Me.ErrProv.SetError(Txtstcode, "Record already exists")
			Exit Sub
		End If
  End If
  If Wrkstcode <> "" Then
    MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
			myTXSTS.UpdateOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
    End If
	Else
		myTXSTS._STCODE = Txtstcode.Text
		MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
			myTXSTS.AddOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
	With myTXSTS
		._STDESC = Txtstdesc.Text
	End With
 End Sub
	Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer

		For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next

		If Txtstcode.Text = String.Empty Then
			ErrorField(I) = "code"
			ErrorMsg(I) = "Code is required"
			I = I + 1
		End If

		If Txtstdesc.Text = String.Empty Then
			ErrorField(I) = "desc"
			ErrorMsg(I) = "Description is required"
			I = I + 1
		End If

	End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
	Dim I As Integer
	ErrProv.SetError(Txtstcode, "")
	ErrProv.SetError(Txtstdesc, "")
	For I = 0 To ErrorField.GetUpperBound(0)
		Select Case ErrorField(I)
		Case "code"
			ErrProv.SetError(Txtstcode, ErrorMsg(I))
		Case "desc"
			ErrProv.SetError(Txtstdesc, ErrorMsg(I))
		Case Nothing
			Exit Sub
		End Select
	Next I
End Sub


End Class






