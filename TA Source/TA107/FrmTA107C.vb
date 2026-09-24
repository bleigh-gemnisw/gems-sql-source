Public Class FrmTA107C
  Inherits System.Windows.Forms.Form
	Dim myTXBUSTY As TXBUSTY.myData
	Friend Wrkbtcode As String
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
    Friend WithEvents Txtbtcode As System.Windows.Forms.TextBox
    Friend WithEvents txtbtdesc As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.Txtbtcode = New System.Windows.Forms.TextBox
Me.txtbtdesc = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 12)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(92, 24)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Code"
'
'Txtbtcode
'
Me.Txtbtcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtbtcode.Location = New System.Drawing.Point(116, 12)
Me.Txtbtcode.MaxLength = 4
Me.Txtbtcode.Name = "Txtbtcode"
Me.Txtbtcode.Size = New System.Drawing.Size(52, 20)
Me.Txtbtcode.TabIndex = 0
'
'txtbtdesc
'
Me.txtbtdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtbtdesc.Location = New System.Drawing.Point(116, 36)
Me.txtbtdesc.MaxLength = 30
Me.txtbtdesc.Name = "txtbtdesc"
Me.txtbtdesc.Size = New System.Drawing.Size(348, 20)
Me.txtbtdesc.TabIndex = 1
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(8, 36)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(92, 24)
Me.Label3.TabIndex = 4
Me.Label3.Text = "Description"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'FrmTA107C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(478, 62)
Me.Controls.Add(Me.txtbtdesc)
Me.Controls.Add(Me.Txtbtcode)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA107C"
Me.Text = "Maintain Business Type Codes"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTA107C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	myTXBUSTY = New TXBUSTY.mydata(MyDBConnect)
  MyFrmTA107.TBarNew.Enabled = False
  MyFrmTA107.TBarSave.Enabled = True
  If Wrkbtcode <> "" Then
    MyFrmTA107.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(Txtbtcode)
  End If
  MyFrmTA107.TBarPrint.Enabled = False
	myTXBUSTY.GetOneRecordP(Wrkbtcode)
  Txtbtcode.Text = Wrkbtcode
	If myTXBUSTY.RecordNotFound Then Exit Sub

    If s_chg = False And s_full = False Then    '#sec
      MyFrmTA107.TBarSave.Visible = False
    End If
		With myTXBUSTY
			txtbtdesc.Text = Trim(._BTDESC)
		End With
End Sub
Private Sub FrmTA107C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA107.SbpScreen.Text = "TA107C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmTA107C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTA107.TBarNew.Enabled = True
  MyFrmTA107.TBarDelete.Enabled = False
  MyFrmTA107.TBarSave.Enabled = False
  MyFrmTA107.TBarPrint.Enabled = False
  MyFrmTA107.TBarSave.Visible = True
  MyFrmTA107B.FormatGrid()
  MyFrmTA107B.Show()
End Sub
Public Sub DeleteData(ByRef wrkcancel As Boolean)
  Dim Answer As Integer
  wrkcancel = True
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
  Exit Sub
  End If
  wrkcancel = False
	myTXBUSTY.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
	Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
	myTXBUSTY.GetOneRecordP(Txtbtcode.Text)
  If Wrkbtcode = "" Then
		If Not myTXBUSTY.RecordNotFound Then
			Me.ErrProv.SetError(Txtbtcode, "Record already exists")
		Exit Sub
		End If
  End If
  If Wrkbtcode <> "" Then
    MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
			myTXBUSTY.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
    Exit Sub
    End If
  Else
		myTXBUSTY._BTCODE = Txtbtcode.Text
		MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
			myTXBUSTY.AddOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
	With myTXBUSTY
	 ._BTDESC = txtbtdesc.Text
	End With
End Sub
	Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer

		For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next

		If Txtbtcode.Text = String.Empty Then
			ErrorField(I) = "btcode"
			ErrorMsg(I) = "Code is required"
			I = I + 1
		End If

		If txtbtdesc.Text = String.Empty Then
			ErrorField(I) = "btdesc"
			ErrorMsg(I) = "Description is required"
			I = I + 1
		End If

	End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
	Dim I As Integer
	ErrProv.SetError(Txtbtcode, "")
	ErrProv.SetError(txtbtdesc, "")
	For I = 0 To ErrorField.GetUpperBound(0)
	Select Case ErrorField(I)
	Case "btcode"
		ErrProv.SetError(Txtbtcode, ErrorMsg(I))
	Case "btdesc"
		ErrProv.SetError(txtbtdesc, ErrorMsg(I))
	Case ""
		Exit Sub
	End Select
	Next I
End Sub
End Class






