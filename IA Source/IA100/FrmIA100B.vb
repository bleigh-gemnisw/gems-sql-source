Public Class FrmIA100B
  Inherits System.Windows.Forms.Form
	Dim myTOWN As TOWN.myData
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
		Friend WithEvents label3 As System.Windows.Forms.Label
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TxtTown As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents TxtAddr1 As System.Windows.Forms.TextBox
Friend WithEvents TxtAddr2 As System.Windows.Forms.TextBox
Friend WithEvents TxtCity As System.Windows.Forms.TextBox
Friend WithEvents TxtZip As System.Windows.Forms.TextBox
Friend WithEvents TxtPhone As System.Windows.Forms.TextBox
Friend WithEvents TxtAssr As System.Windows.Forms.TextBox
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents TxtColctr As System.Windows.Forms.TextBox
Friend WithEvents Label9 As System.Windows.Forms.Label
Friend WithEvents TxtClerk As System.Windows.Forms.TextBox
Friend WithEvents Label10 As System.Windows.Forms.Label
Friend WithEvents TxtCounty As System.Windows.Forms.TextBox
Friend WithEvents Label11 As System.Windows.Forms.Label
Friend WithEvents TxtTownbr As System.Windows.Forms.TextBox
Friend WithEvents Label12 As System.Windows.Forms.Label
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.ErrProv = New System.Windows.Forms.ErrorProvider
Me.label3 = New System.Windows.Forms.Label
Me.Label1 = New System.Windows.Forms.Label
Me.TxtTown = New System.Windows.Forms.TextBox
Me.TxtAddr1 = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.TxtAddr2 = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.TxtCity = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
Me.Label6 = New System.Windows.Forms.Label
Me.TxtZip = New System.Windows.Forms.TextBox
Me.TxtPhone = New System.Windows.Forms.TextBox
Me.Label7 = New System.Windows.Forms.Label
Me.TxtAssr = New System.Windows.Forms.TextBox
Me.Label8 = New System.Windows.Forms.Label
Me.TxtColctr = New System.Windows.Forms.TextBox
Me.Label9 = New System.Windows.Forms.Label
Me.TxtClerk = New System.Windows.Forms.TextBox
Me.Label10 = New System.Windows.Forms.Label
Me.TxtCounty = New System.Windows.Forms.TextBox
Me.Label11 = New System.Windows.Forms.Label
Me.TxtTownbr = New System.Windows.Forms.TextBox
Me.Label12 = New System.Windows.Forms.Label
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'label3
'
Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.label3.Location = New System.Drawing.Point(-100, 74)
Me.label3.Name = "label3"
Me.label3.TabIndex = 6
Me.label3.Text = "New file name"
Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(12, 8)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(100, 16)
Me.Label1.TabIndex = 7
Me.Label1.Text = "Town Name"
'
'TxtTown
'
Me.TxtTown.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtTown.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtTown.Location = New System.Drawing.Point(116, 4)
Me.TxtTown.MaxLength = 30
Me.TxtTown.Name = "TxtTown"
Me.TxtTown.Size = New System.Drawing.Size(248, 22)
Me.TxtTown.TabIndex = 1
Me.TxtTown.Text = ""
'
'TxtAddr1
'
Me.TxtAddr1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtAddr1.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtAddr1.Location = New System.Drawing.Point(116, 28)
Me.TxtAddr1.MaxLength = 30
Me.TxtAddr1.Name = "TxtAddr1"
Me.TxtAddr1.Size = New System.Drawing.Size(248, 22)
Me.TxtAddr1.TabIndex = 8
Me.TxtAddr1.Text = ""
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(12, 32)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(100, 16)
Me.Label2.TabIndex = 9
Me.Label2.Text = "Address 1"
'
'TxtAddr2
'
Me.TxtAddr2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtAddr2.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtAddr2.Location = New System.Drawing.Point(116, 52)
Me.TxtAddr2.MaxLength = 30
Me.TxtAddr2.Name = "TxtAddr2"
Me.TxtAddr2.Size = New System.Drawing.Size(248, 22)
Me.TxtAddr2.TabIndex = 10
Me.TxtAddr2.Text = ""
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(12, 56)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(100, 16)
Me.Label4.TabIndex = 11
Me.Label4.Text = "Address 2"
'
'TxtCity
'
Me.TxtCity.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtCity.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtCity.Location = New System.Drawing.Point(116, 76)
Me.TxtCity.MaxLength = 25
Me.TxtCity.Name = "TxtCity"
Me.TxtCity.Size = New System.Drawing.Size(204, 22)
Me.TxtCity.TabIndex = 12
Me.TxtCity.Text = ""
'
'Label5
'
Me.Label5.Location = New System.Drawing.Point(12, 80)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(100, 16)
Me.Label5.TabIndex = 13
Me.Label5.Text = "City"
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(328, 80)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(20, 16)
Me.Label6.TabIndex = 14
Me.Label6.Text = "Zip"
'
'TxtZip
'
Me.TxtZip.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtZip.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtZip.Location = New System.Drawing.Point(356, 76)
Me.TxtZip.MaxLength = 5
Me.TxtZip.Name = "TxtZip"
Me.TxtZip.Size = New System.Drawing.Size(48, 22)
Me.TxtZip.TabIndex = 15
Me.TxtZip.Text = ""
'
'TxtPhone
'
Me.TxtPhone.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtPhone.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtPhone.Location = New System.Drawing.Point(116, 100)
Me.TxtPhone.MaxLength = 9
Me.TxtPhone.Name = "TxtPhone"
Me.TxtPhone.Size = New System.Drawing.Size(80, 22)
Me.TxtPhone.TabIndex = 16
Me.TxtPhone.Text = ""
'
'Label7
'
Me.Label7.Location = New System.Drawing.Point(12, 104)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(100, 16)
Me.Label7.TabIndex = 17
Me.Label7.Text = "Phone"
'
'TxtAssr
'
Me.TxtAssr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtAssr.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtAssr.Location = New System.Drawing.Point(116, 132)
Me.TxtAssr.MaxLength = 30
Me.TxtAssr.Name = "TxtAssr"
Me.TxtAssr.Size = New System.Drawing.Size(248, 22)
Me.TxtAssr.TabIndex = 18
Me.TxtAssr.Text = ""
'
'Label8
'
Me.Label8.Location = New System.Drawing.Point(12, 136)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(100, 16)
Me.Label8.TabIndex = 19
Me.Label8.Text = "Assessor Name"
'
'TxtColctr
'
Me.TxtColctr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtColctr.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtColctr.Location = New System.Drawing.Point(116, 156)
Me.TxtColctr.MaxLength = 30
Me.TxtColctr.Name = "TxtColctr"
Me.TxtColctr.Size = New System.Drawing.Size(248, 22)
Me.TxtColctr.TabIndex = 20
Me.TxtColctr.Text = ""
'
'Label9
'
Me.Label9.Location = New System.Drawing.Point(12, 160)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(100, 16)
Me.Label9.TabIndex = 21
Me.Label9.Text = "Collector Name"
'
'TxtClerk
'
Me.TxtClerk.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtClerk.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtClerk.Location = New System.Drawing.Point(116, 180)
Me.TxtClerk.MaxLength = 30
Me.TxtClerk.Name = "TxtClerk"
Me.TxtClerk.Size = New System.Drawing.Size(248, 22)
Me.TxtClerk.TabIndex = 22
Me.TxtClerk.Text = ""
'
'Label10
'
Me.Label10.Location = New System.Drawing.Point(12, 184)
Me.Label10.Name = "Label10"
Me.Label10.Size = New System.Drawing.Size(100, 16)
Me.Label10.TabIndex = 23
Me.Label10.Text = "Town Clerk Name"
'
'TxtCounty
'
Me.TxtCounty.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtCounty.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtCounty.Location = New System.Drawing.Point(116, 204)
Me.TxtCounty.MaxLength = 12
Me.TxtCounty.Name = "TxtCounty"
Me.TxtCounty.Size = New System.Drawing.Size(104, 22)
Me.TxtCounty.TabIndex = 24
Me.TxtCounty.Text = ""
'
'Label11
'
Me.Label11.Location = New System.Drawing.Point(12, 208)
Me.Label11.Name = "Label11"
Me.Label11.Size = New System.Drawing.Size(100, 16)
Me.Label11.TabIndex = 25
Me.Label11.Text = "County"
'
'TxtTownbr
'
Me.TxtTownbr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtTownbr.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtTownbr.Location = New System.Drawing.Point(116, 228)
Me.TxtTownbr.MaxLength = 3
Me.TxtTownbr.Name = "TxtTownbr"
Me.TxtTownbr.Size = New System.Drawing.Size(32, 22)
Me.TxtTownbr.TabIndex = 26
Me.TxtTownbr.Text = ""
'
'Label12
'
Me.Label12.Location = New System.Drawing.Point(12, 232)
Me.Label12.Name = "Label12"
Me.Label12.Size = New System.Drawing.Size(100, 16)
Me.Label12.TabIndex = 27
Me.Label12.Text = "Town Number"
'
'FrmIA100B
'
Me.AllowDrop = True
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(418, 260)
Me.ControlBox = False
Me.Controls.Add(Me.TxtTownbr)
Me.Controls.Add(Me.Label12)
Me.Controls.Add(Me.TxtCounty)
Me.Controls.Add(Me.Label11)
Me.Controls.Add(Me.TxtClerk)
Me.Controls.Add(Me.Label10)
Me.Controls.Add(Me.TxtColctr)
Me.Controls.Add(Me.Label9)
Me.Controls.Add(Me.TxtAssr)
Me.Controls.Add(Me.Label8)
Me.Controls.Add(Me.TxtPhone)
Me.Controls.Add(Me.Label7)
Me.Controls.Add(Me.TxtZip)
Me.Controls.Add(Me.TxtCity)
Me.Controls.Add(Me.TxtAddr2)
Me.Controls.Add(Me.TxtAddr1)
Me.Controls.Add(Me.TxtTown)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.label3)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmIA100B"
Me.ResumeLayout(False)

		End Sub

#End Region

Private Sub IA100B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myTOWN = New TOWN.MyData()
  myTOWN.MyDBConn = myDBConnect
	With MyFrmIA100
		.TBarNew.Visible = False
		.TBarSave.Visible = True
		.TBarPrint.Visible = False
		.TBarDelete.Visible = False
	End With
	If s_chg = False And s_full = False Then		'#sec
		MyFrmIA100.TBarSave.Visible = False
	End If

	myTOWN.GetOneRecordP(1)
	If myTOWN.RecordNotFound Then Exit Sub
	With myTOWN
		TxtTown.Text = Trim(._TOWN)
		TxtAddr1.Text = Trim(._ADDR1)
		TxtAddr2.Text = Trim(._ADDR2)
		TxtCity.Text = Trim(._CITY)
		TxtZip.Text = Trim(._ZIP)
		TxtPhone.Text = Trim(._PHONE)
		TxtAssr.Text = Trim(._ASSR)
		TxtColctr.Text = Trim(._COLCTR)
		TxtClerk.Text = Trim(._CLERK)
		TxtCounty.Text = Trim(._COUNTY)
		TxtTownbr.Text = Trim(._TOWNBR)
	End With
End Sub
Private Sub IA100B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmIA100.SbpScreen.Text = "IA100B"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Public Sub SaveData()
	Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
	myTOWN.GetOneRecordP(1)
  MovetoFile()
	EditChecks(ErrorField, ErrorMsg)
	If IsNothing(ErrorMsg(0)) Then
		If myTOWN.RecordNotFound Then
			myTOWN.AddOneRecordP()
		Else
			myTOWN.UpdateOneRecordP()
		End If
	Else
		ShowError(ErrorField, ErrorMsg)
		Exit Sub
	End If
	End
  End Sub
Private Sub MovetoFile()
	With myTOWN
		._TOWN = TxtTown.Text
		._ADDR1 = TxtAddr1.Text
		._ADDR2 = TxtAddr2.Text
		._CITY = TxtCity.Text
		._ZIP = TxtZip.Text
		._PHONE = TxtPhone.Text
		._ASSR = TxtAssr.Text
		._COLCTR = TxtColctr.Text
		._CLERK = TxtClerk.Text
		._COUNTY = TxtCounty.Text
    ._TOWNBR = MyUtils.CnvSng(TxtTownbr.Text)
	End With
End Sub
	Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer

		For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next

		If TxtTown.Text = String.Empty Then
			ErrorField(I) = "town"
			ErrorMsg(I) = "Town Name cannot be blank"
			I = I + 1
		End If

    If MyUtils.CnvSng(TxtTownbr.Text) = 0 Then
      ErrorField(I) = "townbr"
      ErrorMsg(I) = "Town Number cannot be zero"
      I = I + 1
    End If

	End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
	Dim I As Integer
	ErrProv.SetError(TxtTown, "")
	ErrProv.SetError(TxtTownbr, "")
	For I = 0 To ErrorField.GetUpperBound(0)
		 Select Case ErrorField(I)
			 Case "town"
				 ErrProv.SetError(TxtTown, ErrorMsg(I))
			 Case "townbr"
				 ErrProv.SetError(TxtTownbr, ErrorMsg(I))
			 Case Nothing
				 Exit Sub
		 End Select
		 Next I
End Sub
Private Sub TxtTownbr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTownbr.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class
