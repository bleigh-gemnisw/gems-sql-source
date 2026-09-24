Public Class FrmTA102C
  Inherits System.Windows.Forms.Form
	Dim myTXEXEM As TXEXEM.MyData
	Friend WrkTxCode As String
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
	Friend WithEvents TxtCode As System.Windows.Forms.TextBox
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents TxtOPM As System.Windows.Forms.TextBox
	Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
	Friend WithEvents TxtFixam As System.Windows.Forms.TextBox
	Friend WithEvents TxtPerc As System.Windows.Forms.TextBox
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents TxtAss As System.Windows.Forms.TextBox
	Friend WithEvents Label6 As System.Windows.Forms.Label
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.TxtCode = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.TxtFixam = New System.Windows.Forms.TextBox
Me.TxtDesc = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.Label4 = New System.Windows.Forms.Label
Me.TxtOPM = New System.Windows.Forms.TextBox
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TxtPerc = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
Me.TxtAss = New System.Windows.Forms.TextBox
Me.Label6 = New System.Windows.Forms.Label
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
Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'TxtCode
'
Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtCode.Location = New System.Drawing.Point(124, 12)
Me.TxtCode.MaxLength = 3
Me.TxtCode.Name = "TxtCode"
Me.TxtCode.Size = New System.Drawing.Size(32, 20)
Me.TxtCode.TabIndex = 0
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(8, 72)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(92, 24)
Me.Label2.TabIndex = 2
Me.Label2.Text = "Fixed Amount"
Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'TxtFixam
'
Me.TxtFixam.Location = New System.Drawing.Point(124, 72)
Me.TxtFixam.MaxLength = 9
Me.TxtFixam.Name = "TxtFixam"
Me.TxtFixam.Size = New System.Drawing.Size(64, 20)
Me.TxtFixam.TabIndex = 2
'
'TxtDesc
'
Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtDesc.Location = New System.Drawing.Point(124, 36)
Me.TxtDesc.MaxLength = 61
Me.TxtDesc.Multiline = True
Me.TxtDesc.Name = "TxtDesc"
Me.TxtDesc.Size = New System.Drawing.Size(352, 32)
Me.TxtDesc.TabIndex = 1
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(8, 40)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(92, 24)
Me.Label3.TabIndex = 4
Me.Label3.Text = "Description"
Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(8, 140)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(112, 24)
Me.Label4.TabIndex = 6
Me.Label4.Text = "OPM Reporting Code"
Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'TxtOPM
'
Me.TxtOPM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtOPM.Location = New System.Drawing.Point(124, 144)
Me.TxtOPM.MaxLength = 1
Me.TxtOPM.Name = "TxtOPM"
Me.TxtOPM.Size = New System.Drawing.Size(20, 20)
Me.TxtOPM.TabIndex = 5
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'TxtPerc
'
Me.TxtPerc.Location = New System.Drawing.Point(124, 96)
Me.TxtPerc.MaxLength = 3
Me.TxtPerc.Name = "TxtPerc"
Me.TxtPerc.Size = New System.Drawing.Size(32, 20)
Me.TxtPerc.TabIndex = 3
'
'Label5
'
Me.Label5.Location = New System.Drawing.Point(8, 92)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(92, 24)
Me.Label5.TabIndex = 8
Me.Label5.Text = "Percentage"
Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'TxtAss
'
Me.TxtAss.Location = New System.Drawing.Point(124, 120)
Me.TxtAss.MaxLength = 9
Me.TxtAss.Name = "TxtAss"
Me.TxtAss.Size = New System.Drawing.Size(64, 20)
Me.TxtAss.TabIndex = 4
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(8, 116)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(92, 24)
Me.Label6.TabIndex = 10
Me.Label6.Text = "Assessment"
Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'FrmTA102C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(484, 170)
Me.Controls.Add(Me.TxtAss)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.TxtPerc)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.TxtOPM)
Me.Controls.Add(Me.TxtDesc)
Me.Controls.Add(Me.TxtFixam)
Me.Controls.Add(Me.TxtCode)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA102C"
Me.Text = "Maintain Tax Codes"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTA102C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	myTXEXEM = New TXEXEM.mydata(MyDBConnect)
	MyFrmTA102.TBarNew.Enabled = False
	MyFrmTA102.TBarSave.Enabled = True
	If WrkTxCode <> "" Then
		MyFrmTA102.TBarDelete.Enabled = True
		MyFrmTA102.TBarUpdate.Enabled = True
    MyUtils.SetTxtReadOnly(TxtCode)
	End If
	MyFrmTA102.TBarPrint.Enabled = False
	myTXEXEM.GetOneRecordP(WrkTxCode)
	TxtCode.Text = WrkTxCode
	If myTXEXEM.RecordNotFound Then Exit Sub

	If s_chg = False And s_full = False Then		'#sec
		MyFrmTA102.TBarSave.Visible = False
	End If
	With myTXEXEM
		TxtDesc.Text = Trim(._TDESC)
		TxtFixam.Text = ._TFIXAM
		TxtPerc.Text = ._TPERC
		TxtAss.Text = ._TASS
		TxtOPM.Text = Trim(._TXSCD)
	End With
End Sub
Private Sub FrmTA102C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA102.SbpScreen.Text = "TA102C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmTA102C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  With MyFrmTA102
    .TBarNew.Enabled = True
    .TBarDelete.Enabled = False
    .TBarSave.Enabled = False
    .TBarPrint.Enabled = False
    .TBarSave.Visible = True   '#sec
    .TBarUpdate.Enabled = False
  End With
  MyFrmTA102B.FormatGrid()
  MyFrmTA102B.Show()
End Sub
Public Sub DeleteData(ByRef WrkCancel As Boolean)
  Dim Answer As Integer
  WrkCancel = True
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
		Exit Sub
  End If
  WrkCancel = False
	myTXEXEM.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
	myTXEXEM.GetOneRecordP(TxtCode.Text)
  If WrkTxCode = "" Then
		If Not myTXEXEM.RecordNotFound Then
			Me.ErrProv.SetError(TxtCode, "Record already exists")
			Exit Sub
		End If
  End If
  If WrkTxCode <> "" Then
    MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
			myTXEXEM.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
			Exit Sub
    End If
  Else
		myTXEXEM._TEXEM = TxtCode.Text
    MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
			myTXEXEM.AddOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
	With myTXEXEM
		._TDESC = TxtDesc.Text
		._TFIXAM = Val(TxtFixam.Text)
		._TPERC = Val(TxtPerc.Text)
		._TASS = Val(TxtAss.Text)
		._TXSCD = TxtOPM.Text
	End With
End Sub
	Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer
		For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next

		If TxtCode.Text = String.Empty Then
			ErrorField(I) = "texem"
			ErrorMsg(I) = "Code is required"
			I = I + 1
		End If

		If TxtDesc.Text = String.Empty Then
			ErrorField(I) = "tdesc"
			ErrorMsg(I) = "Description is required"
			I = I + 1
		End If
	End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
	Dim I As Integer
	ErrProv.SetError(TxtCode, "")
	ErrProv.SetError(TxtDesc, "")
	For I = 0 To ErrorField.GetUpperBound(0)
		Select Case ErrorField(I)
		Case "texem"
			ErrProv.SetError(TxtCode, ErrorMsg(I))
		Case "tdesc"
			ErrProv.SetError(TxtDesc, ErrorMsg(I))
		Case Nothing
			Exit Sub
		End Select
	Next I
End Sub

Private Sub TxtCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCode.TextChanged

End Sub

Private Sub TxtFixam_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFixam.TextChanged

End Sub

Private Sub TxtFixam_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFixam.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub


Private Sub TxtPerc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPerc.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub TxtAss_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAss.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub TxtDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDesc.TextChanged

End Sub
End Class






