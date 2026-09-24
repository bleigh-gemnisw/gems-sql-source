Public Class FrmTA108C
  Inherits System.Windows.Forms.Form
	Dim myTXTYPE As TXTYPE.myData
	Friend Wrktycode As String

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
Friend WithEvents Txttycode As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents txttydesc As System.Windows.Forms.TextBox
Friend WithEvents Txttxfam As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.Txttycode = New System.Windows.Forms.TextBox
Me.txttydesc = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Label2 = New System.Windows.Forms.Label
Me.Txttxfam = New System.Windows.Forms.TextBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 12)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(84, 24)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Property Type:"
'
'Txttycode
'
Me.Txttycode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txttycode.Location = New System.Drawing.Point(104, 12)
Me.Txttycode.MaxLength = 1
Me.Txttycode.Name = "Txttycode"
Me.Txttycode.Size = New System.Drawing.Size(20, 20)
Me.Txttycode.TabIndex = 0
'
'txttydesc
'
Me.txttydesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txttydesc.Location = New System.Drawing.Point(104, 36)
Me.txttydesc.MaxLength = 30
Me.txttydesc.Multiline = True
Me.txttydesc.Name = "txttydesc"
Me.txttydesc.Size = New System.Drawing.Size(237, 24)
Me.txttydesc.TabIndex = 1
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(8, 36)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(84, 24)
Me.Label3.TabIndex = 4
Me.Label3.Text = "Description:"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(8, 69)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(84, 20)
Me.Label2.TabIndex = 5
Me.Label2.Text = "Type Family:"
'
'Txttxfam
'
Me.Txttxfam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txttxfam.Location = New System.Drawing.Point(104, 66)
Me.Txttxfam.MaxLength = 30
Me.Txttxfam.Name = "Txttxfam"
Me.Txttxfam.Size = New System.Drawing.Size(20, 20)
Me.Txttxfam.TabIndex = 6
'
'FrmTA108C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(353, 95)
Me.Controls.Add(Me.Txttxfam)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.txttydesc)
Me.Controls.Add(Me.Txttycode)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA108C"
Me.Text = "Maintain Property Types"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTA108C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	myTXTYPE = New TXTYPE.mydata(MyDBConnect)
  MyFrmTA108.TBarNew.Enabled = False
  MyFrmTA108.TBarSave.Enabled = True
  If Wrktycode <> "" Then
    MyFrmTA108.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(Txttycode)
  End If
  MyFrmTA108.TBarPrint.Enabled = False
	myTXTYPE.GetOneRecordP(Wrktycode)
  Txttycode.Text = Wrktycode
	If myTXTYPE.RecordNotFound Then Exit Sub

    If s_chg = False And s_full = False Then    '#sec
      MyFrmTA108.TBarSave.Visible = False
    End If
	 With myTXTYPE
		 txttydesc.Text = Trim(._TYDESC)
		 Txttxfam.Text = Trim(._TXFAM)
	 End With
End Sub
Private Sub FrmTA108C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA108.SbpScreen.Text = "TA108C"
  MyUtils.CenterForm(Me.ParentForm, Me)
  If Wrktycode <> "" Then
    Txttycode.ReadOnly = True
    txttydesc.Focus()
  End If
End Sub
Private Sub FrmTA108C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTA108.TBarNew.Enabled = True
  MyFrmTA108.TBarDelete.Enabled = False
  MyFrmTA108.TBarSave.Enabled = False
  MyFrmTA108.TBarPrint.Enabled = True
  MyFrmTA108.TBarSave.Visible = True
  MyFrmTA108B.FormatGrid()
  MyFrmTA108B.Show()
End Sub
Public Sub DeleteData(ByRef wrkcancel As Boolean)
  Dim Answer As Integer
  wrkcancel = True
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
		Exit Sub
  End If
  wrkcancel = False
	myTXTYPE.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
	Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
	myTXTYPE.GetOneRecordP(Txttycode.Text)
  If Wrktycode = "" Then
		If Not myTXTYPE.RecordNotFound Then
			Me.ErrProv.SetError(Txttycode, "Record already exists")
		Exit Sub
		End If
  End If
  If Wrktycode <> "" Then
    MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
			myTXTYPE.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
    Exit Sub
    End If
  Else
		myTXTYPE._TYCODE = Txttycode.Text
    MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
			myTXTYPE.AddOneRecordP()
		Else
		ShowError(ErrorField, ErrorMsg)
		Exit Sub
		End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
	With myTXTYPE
		._TYDESC = txttydesc.Text
		._TXFAM = Txttxfam.Text
	End With
End Sub
	Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer

		For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next

		If Txttycode.Text = String.Empty Then
			ErrorField(I) = "tycode"
			ErrorMsg(I) = "Code is required"
			I = I + 1
		End If

		If txttydesc.Text = String.Empty Then
			ErrorField(I) = "tydesc"
			ErrorMsg(I) = "Description is required"
			I = I + 1
		End If

		If Txttxfam.Text = String.Empty Then
			ErrorField(I) = "txfam"
			ErrorMsg(I) = "Family is required"
			I = I + 1
		End If
	End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
	Dim I As Integer
	ErrProv.SetError(Txttycode, "")
	ErrProv.SetError(txttydesc, "")
	ErrProv.SetError(Txttxfam, "")
	For I = 0 To ErrorField.GetUpperBound(0)
		Select Case ErrorField(I)
		Case "tycode"
			ErrProv.SetError(Txttycode, ErrorMsg(I))
		Case "tydesc"
			ErrProv.SetError(txttydesc, ErrorMsg(I))
		Case "txfam"
			ErrProv.SetError(Txttxfam, ErrorMsg(I))
		Case Nothing
			Exit Sub
		End Select
	Next I
End Sub

End Class






