Public Class FrmTA110C
  Inherits System.Windows.Forms.Form
	Dim myTXOWN As TXOWN.myData
	Friend Wrkoid As String
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
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtOid As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents TxtName As System.Windows.Forms.TextBox
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents Txtsname As System.Windows.Forms.TextBox
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents label7 As System.Windows.Forms.Label
Friend WithEvents Txtssn As System.Windows.Forms.TextBox
Friend WithEvents Txtss2 As System.Windows.Forms.TextBox
Friend WithEvents txtadd1 As System.Windows.Forms.TextBox
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents Txtadd2 As System.Windows.Forms.TextBox
Friend WithEvents Label9 As System.Windows.Forms.Label
Friend WithEvents TxtCity As System.Windows.Forms.TextBox
Friend WithEvents Label10 As System.Windows.Forms.Label
Friend WithEvents TxtState As System.Windows.Forms.TextBox
Friend WithEvents Label11 As System.Windows.Forms.Label
Friend WithEvents Txtzip5 As System.Windows.Forms.TextBox
Friend WithEvents Txtzip4 As System.Windows.Forms.TextBox
Friend WithEvents Label12 As System.Windows.Forms.Label
Friend WithEvents Label13 As System.Windows.Forms.Label
Friend WithEvents Txtdob As System.Windows.Forms.TextBox
Friend WithEvents Txttel As System.Windows.Forms.TextBox
Friend WithEvents Label14 As System.Windows.Forms.Label
Friend WithEvents Txttin As System.Windows.Forms.TextBox
Friend WithEvents Label15 As System.Windows.Forms.Label
Friend WithEvents Txtcomt As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.TxtOid = New System.Windows.Forms.TextBox
Me.txtadd1 = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Label2 = New System.Windows.Forms.Label
Me.Txttel = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.TxtName = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
Me.Txtsname = New System.Windows.Forms.TextBox
Me.Label6 = New System.Windows.Forms.Label
Me.label7 = New System.Windows.Forms.Label
Me.Txtssn = New System.Windows.Forms.TextBox
Me.Txtss2 = New System.Windows.Forms.TextBox
Me.Label8 = New System.Windows.Forms.Label
Me.Txtadd2 = New System.Windows.Forms.TextBox
Me.Label9 = New System.Windows.Forms.Label
Me.TxtCity = New System.Windows.Forms.TextBox
Me.Label10 = New System.Windows.Forms.Label
Me.TxtState = New System.Windows.Forms.TextBox
Me.Label11 = New System.Windows.Forms.Label
Me.Txtzip5 = New System.Windows.Forms.TextBox
Me.Txtzip4 = New System.Windows.Forms.TextBox
Me.Label12 = New System.Windows.Forms.Label
Me.Label13 = New System.Windows.Forms.Label
Me.Txtdob = New System.Windows.Forms.TextBox
Me.Label14 = New System.Windows.Forms.Label
Me.Txttin = New System.Windows.Forms.TextBox
Me.Label15 = New System.Windows.Forms.Label
Me.Txtcomt = New System.Windows.Forms.TextBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(20, 12)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(56, 24)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Owner ID"
'
'TxtOid
'
Me.TxtOid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtOid.Location = New System.Drawing.Point(88, 12)
Me.TxtOid.MaxLength = 15
Me.TxtOid.Name = "TxtOid"
Me.TxtOid.Size = New System.Drawing.Size(112, 20)
Me.TxtOid.TabIndex = 0
'
'txtadd1
'
Me.txtadd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtadd1.Location = New System.Drawing.Point(80, 192)
Me.txtadd1.MaxLength = 35
Me.txtadd1.Name = "txtadd1"
Me.txtadd1.Size = New System.Drawing.Size(268, 20)
Me.txtadd1.TabIndex = 7
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(12, 192)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(60, 24)
Me.Label3.TabIndex = 4
Me.Label3.Text = "Address 1"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(12, 284)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(116, 20)
Me.Label2.TabIndex = 5
Me.Label2.Text = "Telephone Number"
'
'Txttel
'
Me.Txttel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txttel.Location = New System.Drawing.Point(136, 280)
Me.Txttel.MaxLength = 10
Me.Txttel.Name = "Txttel"
Me.Txttel.Size = New System.Drawing.Size(120, 20)
Me.Txttel.TabIndex = 13
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(8, 48)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(72, 16)
Me.Label4.TabIndex = 7
Me.Label4.Text = "Owner Name"
'
'TxtName
'
Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtName.Location = New System.Drawing.Point(88, 44)
Me.TxtName.MaxLength = 35
Me.TxtName.Name = "TxtName"
Me.TxtName.Size = New System.Drawing.Size(272, 20)
Me.TxtName.TabIndex = 1
'
'Label5
'
Me.Label5.Location = New System.Drawing.Point(8, 84)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(72, 32)
Me.Label5.TabIndex = 9
Me.Label5.Text = "Second Owner Name"
'
'Txtsname
'
Me.Txtsname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtsname.Location = New System.Drawing.Point(88, 88)
Me.Txtsname.MaxLength = 35
Me.Txtsname.Name = "Txtsname"
Me.Txtsname.Size = New System.Drawing.Size(272, 20)
Me.Txtsname.TabIndex = 3
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(392, 92)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(32, 20)
Me.Label6.TabIndex = 11
Me.Label6.Text = "SSN"
'
'label7
'
Me.label7.Location = New System.Drawing.Point(392, 48)
Me.label7.Name = "label7"
Me.label7.Size = New System.Drawing.Size(32, 16)
Me.label7.TabIndex = 12
Me.label7.Text = "SSN"
'
'Txtssn
'
Me.Txtssn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtssn.Location = New System.Drawing.Point(432, 44)
Me.Txtssn.MaxLength = 9
Me.Txtssn.Name = "Txtssn"
Me.Txtssn.Size = New System.Drawing.Size(104, 20)
Me.Txtssn.TabIndex = 2
'
'Txtss2
'
Me.Txtss2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtss2.Location = New System.Drawing.Point(432, 88)
Me.Txtss2.MaxLength = 9
Me.Txtss2.Name = "Txtss2"
Me.Txtss2.Size = New System.Drawing.Size(104, 20)
Me.Txtss2.TabIndex = 4
'
'Label8
'
Me.Label8.Location = New System.Drawing.Point(12, 224)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(60, 20)
Me.Label8.TabIndex = 16
Me.Label8.Text = "Address 2"
'
'Txtadd2
'
Me.Txtadd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtadd2.Location = New System.Drawing.Point(80, 220)
Me.Txtadd2.MaxLength = 35
Me.Txtadd2.Name = "Txtadd2"
Me.Txtadd2.Size = New System.Drawing.Size(268, 20)
Me.Txtadd2.TabIndex = 8
'
'Label9
'
Me.Label9.Location = New System.Drawing.Point(12, 252)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(60, 16)
Me.Label9.TabIndex = 18
Me.Label9.Text = "City"
'
'TxtCity
'
Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtCity.Location = New System.Drawing.Point(80, 248)
Me.TxtCity.MaxLength = 25
Me.TxtCity.Name = "TxtCity"
Me.TxtCity.Size = New System.Drawing.Size(188, 20)
Me.TxtCity.TabIndex = 9
'
'Label10
'
Me.Label10.Location = New System.Drawing.Point(276, 252)
Me.Label10.Name = "Label10"
Me.Label10.Size = New System.Drawing.Size(32, 16)
Me.Label10.TabIndex = 20
Me.Label10.Text = "State"
'
'TxtState
'
Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtState.Location = New System.Drawing.Point(316, 248)
Me.TxtState.MaxLength = 2
Me.TxtState.Name = "TxtState"
Me.TxtState.Size = New System.Drawing.Size(32, 20)
Me.TxtState.TabIndex = 10
'
'Label11
'
Me.Label11.Location = New System.Drawing.Point(360, 252)
Me.Label11.Name = "Label11"
Me.Label11.Size = New System.Drawing.Size(32, 16)
Me.Label11.TabIndex = 22
Me.Label11.Text = "ZIP"
'
'Txtzip5
'
Me.Txtzip5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtzip5.Location = New System.Drawing.Point(384, 248)
Me.Txtzip5.MaxLength = 5
Me.Txtzip5.Name = "Txtzip5"
Me.Txtzip5.Size = New System.Drawing.Size(52, 20)
Me.Txtzip5.TabIndex = 11
'
'Txtzip4
'
Me.Txtzip4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtzip4.Location = New System.Drawing.Point(444, 248)
Me.Txtzip4.MaxLength = 4
Me.Txtzip4.Name = "Txtzip4"
Me.Txtzip4.Size = New System.Drawing.Size(48, 20)
Me.Txtzip4.TabIndex = 12
'
'Label12
'
Me.Label12.Location = New System.Drawing.Point(436, 252)
Me.Label12.Name = "Label12"
Me.Label12.Size = New System.Drawing.Size(8, 16)
Me.Label12.TabIndex = 25
Me.Label12.Text = "-"
'
'Label13
'
Me.Label13.Location = New System.Drawing.Point(8, 124)
Me.Label13.Name = "Label13"
Me.Label13.Size = New System.Drawing.Size(72, 20)
Me.Label13.TabIndex = 26
Me.Label13.Text = "Date of Birth"
'
'Txtdob
'
Me.Txtdob.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtdob.Location = New System.Drawing.Point(88, 120)
Me.Txtdob.MaxLength = 8
Me.Txtdob.Name = "Txtdob"
Me.Txtdob.Size = New System.Drawing.Size(92, 20)
Me.Txtdob.TabIndex = 5
'
'Label14
'
Me.Label14.Location = New System.Drawing.Point(392, 120)
Me.Label14.Name = "Label14"
Me.Label14.Size = New System.Drawing.Size(32, 20)
Me.Label14.TabIndex = 28
Me.Label14.Text = "TIN"
'
'Txttin
'
Me.Txttin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txttin.Location = New System.Drawing.Point(432, 116)
Me.Txttin.MaxLength = 1
Me.Txttin.Name = "Txttin"
Me.Txttin.Size = New System.Drawing.Size(28, 20)
Me.Txttin.TabIndex = 6
'
'Label15
'
Me.Label15.Location = New System.Drawing.Point(12, 316)
Me.Label15.Name = "Label15"
Me.Label15.Size = New System.Drawing.Size(60, 20)
Me.Label15.TabIndex = 30
Me.Label15.Text = "Comments"
'
'Txtcomt
'
Me.Txtcomt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtcomt.Location = New System.Drawing.Point(84, 316)
Me.Txtcomt.MaxLength = 30
Me.Txtcomt.Name = "Txtcomt"
Me.Txtcomt.Size = New System.Drawing.Size(460, 20)
Me.Txtcomt.TabIndex = 14
'
'FrmTA110C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(560, 346)
Me.Controls.Add(Me.Txtcomt)
Me.Controls.Add(Me.Label15)
Me.Controls.Add(Me.Txttin)
Me.Controls.Add(Me.Label14)
Me.Controls.Add(Me.Txtdob)
Me.Controls.Add(Me.Label13)
Me.Controls.Add(Me.Label12)
Me.Controls.Add(Me.Txtzip4)
Me.Controls.Add(Me.Txtzip5)
Me.Controls.Add(Me.Label11)
Me.Controls.Add(Me.TxtState)
Me.Controls.Add(Me.Label10)
Me.Controls.Add(Me.TxtCity)
Me.Controls.Add(Me.Label9)
Me.Controls.Add(Me.Txtadd2)
Me.Controls.Add(Me.Label8)
Me.Controls.Add(Me.Txtss2)
Me.Controls.Add(Me.Txtssn)
Me.Controls.Add(Me.label7)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.Txtsname)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.TxtName)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.Txttel)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.txtadd1)
Me.Controls.Add(Me.TxtOid)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA110C"
Me.Text = "Maintain Owner Identification"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTA110C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	myTXOWN = New TXOWN.mydata(MyDBConnect)
  MyFrmTA110.TBarNew.Enabled = True
  MyFrmTA110.TBarSave.Enabled = True
  If Wrkoid <> "" Then
    MyFrmTA110.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(TxtOid)
  End If
  MyFrmTA110.TBarPrint.Enabled = False
	myTXOWN.GetOneRecordp(Wrkoid)
  TxtOid.Text = Wrkoid
	If myTXOWN.RecordNotFound Then Exit Sub

  If s_chg = False And s_full = False Then    '#sec
    MyFrmTA110.TBarSave.Visible = False
   End If
	 With myTXOWN
		 TxtName.Text = Trim(._NAME)
		 Txtsname.Text = Trim(._SNAME)
		 txtadd1.Text = Trim(._ADD1)
		 Txtadd2.Text = Trim(._ADD2)
		 TxtCity.Text = Trim(._CITY)
		 TxtState.Text = Trim(._STATE)
		 Txtzip5.Text = Format(._ZIP5, "00000")
		 Txtzip4.Text = Format(._ZIP4, "0000")
		 Txtssn.Text = ._SSNo
		 Txtss2.Text = ._SS2
		 Txttin.Text = Trim(._TIN)
		 Txttel.Text = ._TEL
		 Txtdob.Text = ._DOB
		 Txtcomt.Text = Trim(._COMT)
	 End With
End Sub
Private Sub FrmTA110C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA110.SbpScreen.Text = "TA110C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmTA110C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTA110.TBarNew.Enabled = True
  MyFrmTA110.TBarDelete.Enabled = False
  MyFrmTA110.TBarSave.Enabled = False
  MyFrmTA110.TBarPrint.Enabled = False
  MyFrmTA110.TBarSave.Visible = True
  MyFrmTA110B.FormatGrid()
  MyFrmTA110B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
  Exit Sub
  End If
	myTXOWN.DeleteOneRecordp()
  Me.Close()
End Sub
Public Sub SaveData()
	Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
	myTXOWN.GetOneRecordp(TxtOid.Text)
  If Wrkoid = "" Then
		If Not myTXOWN.RecordNotFound Then
			Me.ErrProv.SetError(TxtOid, "Record already exists")
		Exit Sub
		End If
  End If
  If Wrkoid <> "" Then
    MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
			myTXOWN.UpdateOneRecordp()
    Else
      ShowError(ErrorField, ErrorMsg)
    Exit Sub
    End If
  Else
		myTXOWN._OID = TxtOid.Text
    MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
			myTXOWN.AddOneRecordp()
		Else
			ShowError(ErrorField, ErrorMsg)
		Exit Sub
		End If
  End If
  MsgBox("Changes Saved", MsgBoxStyle.Information, "Owner Information")
        Me.Close()
End Sub
Private Sub MovetoFile()
	With myTXOWN
		._NAME = TxtName.Text
		._SNAME = Txtsname.Text
		._ADD1 = txtadd1.Text
		._ADD2 = Txtadd2.Text
		._CITY = TxtCity.Text
		._STATE = TxtState.Text
    ._ZIP5 = MyUtils.CnvSng(Txtzip5.Text)
    ._ZIP4 = MyUtils.CnvSng(Txtzip4.Text)
    ._SSNo = MyUtils.CnvSng(Txtssn.Text)
    ._SS2 = MyUtils.CnvSng(Txtss2.Text)
    ._TIN = Txttin.Text
    ._TEL = MyUtils.CnvSng(Txttel.Text)
    ._DOB = MyUtils.CnvSng(Txtdob.Text)
		._COMT = Txtcomt.Text
	End With
End Sub
	Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer

		For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next

		If TxtOid.Text = String.Empty Then
			ErrorField(I) = "oid"
			ErrorMsg(I) = "Owner ID is required"
			I = I + 1
		End If

		If TxtName.Text = String.Empty Then
			ErrorField(I) = "name"
			ErrorMsg(I) = "Owner Name is required"
			I = I + 1
		End If
	End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
	Dim I As Integer
	ErrProv.SetError(TxtOid, "")
	ErrProv.SetError(TxtName, "")
	For I = 0 To ErrorField.GetUpperBound(0)
		Select Case ErrorField(I)
		Case "oid"
			ErrProv.SetError(TxtOid, ErrorMsg(I))
		Case "name"
			ErrProv.SetError(TxtName, ErrorMsg(I))
		Case ""
			Exit Sub
		End Select
 Next I
End Sub
Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
End Sub
Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
End Sub
Private Sub Txtoid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtOid.TextChanged
End Sub
Private Sub Label2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
End Sub
Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
End Sub
Private Sub Txtssn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtssn.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub Txtss2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtss2.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub Txtdob_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtdob.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub Txtzip5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtzip5.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub Txtzip4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtzip4.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub Txttel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txttel.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






