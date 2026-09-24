Public Class FrmTX107C
  Inherits System.Windows.Forms.Form
	Dim myTXBANKS As TXBANKS.myData
	Friend Wrkbkcode As String
  Friend WithEvents TxtZip4 As System.Windows.Forms.TextBox
  Friend WithEvents ChkBills As System.Windows.Forms.CheckBox
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
Friend WithEvents Txtbkcode As System.Windows.Forms.TextBox
Friend WithEvents Txtbkname As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents Txtbkadd1 As System.Windows.Forms.TextBox
Friend WithEvents Txtbkadd2 As System.Windows.Forms.TextBox
Friend WithEvents Txtbkadd3 As System.Windows.Forms.TextBox
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents Txtbkst As System.Windows.Forms.TextBox
Friend WithEvents Label9 As System.Windows.Forms.Label
Friend WithEvents Txtzip5 As System.Windows.Forms.TextBox
Friend WithEvents Txtbkcty As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.Txtbkcode = New System.Windows.Forms.TextBox
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Label2 = New System.Windows.Forms.Label
Me.Txtbkname = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.Label5 = New System.Windows.Forms.Label
Me.Label6 = New System.Windows.Forms.Label
Me.Txtbkadd1 = New System.Windows.Forms.TextBox
Me.Txtbkadd2 = New System.Windows.Forms.TextBox
Me.Txtbkadd3 = New System.Windows.Forms.TextBox
Me.Label7 = New System.Windows.Forms.Label
Me.Txtbkcty = New System.Windows.Forms.TextBox
Me.Label8 = New System.Windows.Forms.Label
Me.Txtbkst = New System.Windows.Forms.TextBox
Me.Label9 = New System.Windows.Forms.Label
Me.Txtzip5 = New System.Windows.Forms.TextBox
Me.ChkBills = New System.Windows.Forms.CheckBox
Me.TxtZip4 = New System.Windows.Forms.TextBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 12)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(60, 16)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Bank Code"
'
'Txtbkcode
'
Me.Txtbkcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtbkcode.Location = New System.Drawing.Point(76, 8)
Me.Txtbkcode.MaxLength = 2
Me.Txtbkcode.Name = "Txtbkcode"
Me.Txtbkcode.Size = New System.Drawing.Size(28, 20)
Me.Txtbkcode.TabIndex = 0
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(8, 39)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(64, 16)
Me.Label2.TabIndex = 28
Me.Label2.Text = "Bank Name"
'
'Txtbkname
'
Me.Txtbkname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtbkname.Location = New System.Drawing.Point(100, 34)
Me.Txtbkname.MaxLength = 30
Me.Txtbkname.Name = "Txtbkname"
Me.Txtbkname.Size = New System.Drawing.Size(256, 20)
Me.Txtbkname.TabIndex = 2
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(8, 61)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(84, 16)
Me.Label4.TabIndex = 30
Me.Label4.Text = "Address Line 1"
'
'Label5
'
Me.Label5.Location = New System.Drawing.Point(8, 101)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(84, 16)
Me.Label5.TabIndex = 31
Me.Label5.Text = "Address Line 3"
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(8, 81)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(84, 16)
Me.Label6.TabIndex = 32
Me.Label6.Text = "Address Line 2"
'
'Txtbkadd1
'
Me.Txtbkadd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtbkadd1.Location = New System.Drawing.Point(100, 61)
Me.Txtbkadd1.MaxLength = 30
Me.Txtbkadd1.Name = "Txtbkadd1"
Me.Txtbkadd1.Size = New System.Drawing.Size(288, 20)
Me.Txtbkadd1.TabIndex = 3
'
'Txtbkadd2
'
Me.Txtbkadd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtbkadd2.Location = New System.Drawing.Point(100, 81)
Me.Txtbkadd2.MaxLength = 30
Me.Txtbkadd2.Name = "Txtbkadd2"
Me.Txtbkadd2.Size = New System.Drawing.Size(288, 20)
Me.Txtbkadd2.TabIndex = 4
'
'Txtbkadd3
'
Me.Txtbkadd3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtbkadd3.Location = New System.Drawing.Point(100, 101)
Me.Txtbkadd3.MaxLength = 30
Me.Txtbkadd3.Name = "Txtbkadd3"
Me.Txtbkadd3.Size = New System.Drawing.Size(288, 20)
Me.Txtbkadd3.TabIndex = 5
'
'Label7
'
Me.Label7.Location = New System.Drawing.Point(8, 133)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(28, 16)
Me.Label7.TabIndex = 33
Me.Label7.Text = "City"
'
'Txtbkcty
'
Me.Txtbkcty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtbkcty.Location = New System.Drawing.Point(44, 129)
Me.Txtbkcty.MaxLength = 25
Me.Txtbkcty.Name = "Txtbkcty"
Me.Txtbkcty.Size = New System.Drawing.Size(212, 20)
Me.Txtbkcty.TabIndex = 6
'
'Label8
'
Me.Label8.Location = New System.Drawing.Point(256, 133)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(32, 16)
Me.Label8.TabIndex = 34
Me.Label8.Text = "State"
'
'Txtbkst
'
Me.Txtbkst.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtbkst.Location = New System.Drawing.Point(292, 129)
Me.Txtbkst.MaxLength = 2
Me.Txtbkst.Name = "Txtbkst"
Me.Txtbkst.Size = New System.Drawing.Size(28, 20)
Me.Txtbkst.TabIndex = 7
'
'Label9
'
Me.Label9.Location = New System.Drawing.Point(329, 132)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(55, 16)
Me.Label9.TabIndex = 35
Me.Label9.Text = "ZIP Code"
'
'Txtzip5
'
Me.Txtzip5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtzip5.Location = New System.Drawing.Point(390, 129)
Me.Txtzip5.MaxLength = 5
Me.Txtzip5.Name = "Txtzip5"
Me.Txtzip5.Size = New System.Drawing.Size(39, 20)
Me.Txtzip5.TabIndex = 8
'
'ChkBills
'
Me.ChkBills.AutoSize = True
Me.ChkBills.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkBills.Location = New System.Drawing.Point(384, 8)
Me.ChkBills.Name = "ChkBills"
Me.ChkBills.Size = New System.Drawing.Size(74, 17)
Me.ChkBills.TabIndex = 1
Me.ChkBills.Text = "Print Bills?"
Me.ChkBills.UseVisualStyleBackColor = True
'
'TxtZip4
'
Me.TxtZip4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtZip4.Location = New System.Drawing.Point(429, 129)
Me.TxtZip4.MaxLength = 4
Me.TxtZip4.Name = "TxtZip4"
Me.TxtZip4.Size = New System.Drawing.Size(38, 20)
Me.TxtZip4.TabIndex = 36
'
'FrmTX107C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(470, 163)
Me.Controls.Add(Me.TxtZip4)
Me.Controls.Add(Me.ChkBills)
Me.Controls.Add(Me.Txtzip5)
Me.Controls.Add(Me.Label9)
Me.Controls.Add(Me.Txtbkst)
Me.Controls.Add(Me.Label8)
Me.Controls.Add(Me.Txtbkcty)
Me.Controls.Add(Me.Label7)
Me.Controls.Add(Me.Txtbkadd3)
Me.Controls.Add(Me.Txtbkadd2)
Me.Controls.Add(Me.Txtbkadd1)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.Txtbkname)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Txtbkcode)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX107C"
Me.Text = "Maintain Bank Codes"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region
Private Sub FrmTX107C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Dim WrkStr As String
  Dim WrkStr5 As String
  Dim WrkStr4 As String

	myTXBANKS = New TXBANKS.mydata(MyDBConnect)
  MyFrmTX107.TBarNew.Enabled = False
  MyFrmTX107.TBarSave.Enabled = True
  MyFrmTX107.TBarPrint.Enabled = False
  If Wrkbkcode <> "" Then
    MyFrmTX107.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(Txtbkcode)
  End If
  If Wrkbkcode = "" Then
    Me.Text = "Add " & Me.Text
    MyFrmTX107.TBarDelete.Enabled = False
    Exit Sub
  End If

	myTXBANKS.GetOneRecordP(Wrkbkcode)
  Txtbkcode.Text = Wrkbkcode
	If myTXBANKS.RecordNotFound Then
		MyFrmTX107.TBarNew.Enabled = False
		MyFrmTX107.TBarSave.Enabled = False
		MyFrmTX107.TBarDelete.Enabled = False
		Me.ErrProv.SetError(Txtbkcode, "Record not found")
		Exit Sub
	End If

	If s_chg = False And s_full = False Then		'#sec
		MyFrmTX107.TBarSave.Visible = False
	End If

	With myTXBANKS
		Txtbkcode.Text = Wrkbkcode
		Txtbkname.Text = Trim(._BKNAME)
		ChkBills.Checked = False
		If Trim(._BKPRNT) = "Y" Then
			ChkBills.Checked = True
		End If
		Txtbkadd1.Text = Trim(._BKADD1)
		Txtbkadd2.Text = Trim(._BKADD2)
		Txtbkadd3.Text = Trim(._BKADD3)
		Txtbkcty.Text = Trim(._BKCTY)
		Txtbkst.Text = Trim(._BKST)
		WrkStr = ._ZIP9
		Select Case Len(WrkStr)
		Case 5
			WrkStr5 = ._ZIP9
			WrkStr4 = "0"
		Case 8
			WrkStr5 = Mid(._ZIP9, 1, 4)
			WrkStr4 = Mid(._ZIP9, 5, 4)
		Case 9
			WrkStr5 = Mid(._ZIP9, 1, 5)
			WrkStr4 = Mid(._ZIP9, 6, 4)
		Case Else
			WrkStr5 = "0"
			WrkStr4 = "0"
		End Select
    Txtzip5.Text = Format(MyUtils.CnvSng(WrkStr5), "00000")
    TxtZip4.Text = Format(MyUtils.CnvSng(WrkStr4), "0000")
  End With
End Sub
Private Sub FrmTX107C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX107.SbpScreen.Text = "TX107C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmTX107C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTX107.TBarNew.Enabled = True
  MyFrmTX107.TBarDelete.Enabled = False
  MyFrmTX107.TBarSave.Enabled = False
  MyFrmTX107.TBarPrint.Enabled = False
  MyFrmTX107B.FormatGrid()
  MyFrmTX107B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
  myTXBANKS.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  myTXBANKS.GetOneRecordP(Txtbkcode.Text)
  If Wrkbkcode = "" Then
    If Not myTXBANKS.RecordNotFound Then
      Me.ErrProv.SetError(Txtbkcode, "Record already exists")
      Exit Sub
    End If
  End If
  If Wrkbkcode <> "" Then
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myTXBANKS.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
    Else
    myTXBANKS._BKCODE = Txtbkcode.Text
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myTXBANKS.AddOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myTXBANKS
    ._BKNAME = Txtbkname.Text
    If ChkBills.Checked Then
      ._BKPRNT = "Y"
    Else
      ._BKPRNT = "N"
    End If
    ._BKADD1 = Txtbkadd1.Text
    ._BKADD2 = Txtbkadd2.Text
    ._BKADD3 = Txtbkadd3.Text
    ._BKCTY = Txtbkcty.Text
    ._BKST = Txtbkst.Text
    ._ZIP9 = Format(MyUtils.CnvSng(Txtzip5.Text), "00000") & Format(MyUtils.CnvSng(TxtZip4.Text), "0000")
  End With
 End Sub
	Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer

		For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next

		If Txtbkcode.Text = String.Empty Then
			ErrorField(I) = "bkcode"
			ErrorMsg(I) = "Code is required"
			I = I + 1
		End If
	End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
	Dim I As Integer
	ErrProv.SetError(Txtbkcode, "")

	For I = 0 To ErrorField.GetUpperBound(0)
		Select Case ErrorField(I)
		Case "bkcode"
			ErrProv.SetError(Txtbkcode, ErrorMsg(I))
		Case Nothing
			Exit Sub
		End Select
	Next I
End Sub

Private Sub Txtzip9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtzip5.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, True)
End Sub
End Class






