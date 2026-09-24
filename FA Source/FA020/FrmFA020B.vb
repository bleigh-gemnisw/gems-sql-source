Public Class FrmFA020B
  Inherits System.Windows.Forms.Form
	Dim myFACAPT As FACAPT.myData
	Friend WithEvents TxtClass As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtBldg As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtAstype As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TxtDept As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtUser5 As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents TxtUser4 As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents TxtUser3 As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TxtUser2 As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents TxtUser1 As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TxtEqup As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WrkFcthld As Integer
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
Friend WithEvents TxtCode As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.label3 = New System.Windows.Forms.Label
Me.Label1 = New System.Windows.Forms.Label
Me.TxtCode = New System.Windows.Forms.TextBox
Me.TxtClass = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.TxtDept = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.TxtAstype = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
Me.TxtBldg = New System.Windows.Forms.TextBox
Me.Label6 = New System.Windows.Forms.Label
Me.TxtEqup = New System.Windows.Forms.TextBox
Me.Label7 = New System.Windows.Forms.Label
Me.TxtUser1 = New System.Windows.Forms.TextBox
Me.Label8 = New System.Windows.Forms.Label
Me.TxtUser2 = New System.Windows.Forms.TextBox
Me.Label9 = New System.Windows.Forms.Label
Me.TxtUser3 = New System.Windows.Forms.TextBox
Me.Label10 = New System.Windows.Forms.Label
Me.TxtUser4 = New System.Windows.Forms.TextBox
Me.Label11 = New System.Windows.Forms.Label
Me.TxtUser5 = New System.Windows.Forms.TextBox
Me.Label12 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
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
Me.label3.Size = New System.Drawing.Size(100, 23)
Me.label3.TabIndex = 6
Me.label3.Text = "New file name"
Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(23, -3)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(85, 18)
Me.Label1.TabIndex = 7
Me.Label1.Text = "Caption Code"
Me.Label1.Visible = False
'
'TxtCode
'
Me.TxtCode.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtCode.Location = New System.Drawing.Point(105, -7)
Me.TxtCode.MaxLength = 3
Me.TxtCode.Name = "TxtCode"
Me.TxtCode.Size = New System.Drawing.Size(33, 22)
Me.TxtCode.TabIndex = 0
Me.TxtCode.Visible = False
'
'TxtClass
'
Me.TxtClass.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtClass.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtClass.Location = New System.Drawing.Point(105, 175)
Me.TxtClass.MaxLength = 20
Me.TxtClass.Name = "TxtClass"
Me.TxtClass.Size = New System.Drawing.Size(168, 22)
Me.TxtClass.TabIndex = 1
Me.TxtClass.Visible = False
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(21, 179)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(85, 18)
Me.Label2.TabIndex = 9
Me.Label2.Text = "Class"
Me.Label2.Visible = False
'
'TxtDept
'
Me.TxtDept.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDept.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtDept.Location = New System.Drawing.Point(105, 201)
Me.TxtDept.MaxLength = 20
Me.TxtDept.Name = "TxtDept"
Me.TxtDept.Size = New System.Drawing.Size(168, 22)
Me.TxtDept.TabIndex = 2
Me.TxtDept.Visible = False
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(23, 205)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(83, 18)
Me.Label4.TabIndex = 11
Me.Label4.Text = "Department"
Me.Label4.Visible = False
'
'TxtAstype
'
Me.TxtAstype.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtAstype.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtAstype.Location = New System.Drawing.Point(105, 227)
Me.TxtAstype.MaxLength = 20
Me.TxtAstype.Name = "TxtAstype"
Me.TxtAstype.Size = New System.Drawing.Size(168, 22)
Me.TxtAstype.TabIndex = 3
Me.TxtAstype.Visible = False
'
'Label5
'
Me.Label5.Location = New System.Drawing.Point(23, 231)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(76, 18)
Me.Label5.TabIndex = 13
Me.Label5.Text = "Asset Type"
Me.Label5.Visible = False
'
'TxtBldg
'
Me.TxtBldg.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtBldg.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtBldg.Location = New System.Drawing.Point(105, 253)
Me.TxtBldg.MaxLength = 20
Me.TxtBldg.Name = "TxtBldg"
Me.TxtBldg.Size = New System.Drawing.Size(168, 22)
Me.TxtBldg.TabIndex = 4
Me.TxtBldg.Visible = False
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(23, 257)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(85, 18)
Me.Label6.TabIndex = 15
Me.Label6.Text = "Location"
Me.Label6.Visible = False
'
'TxtEqup
'
Me.TxtEqup.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtEqup.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtEqup.Location = New System.Drawing.Point(105, 279)
Me.TxtEqup.MaxLength = 20
Me.TxtEqup.Name = "TxtEqup"
Me.TxtEqup.Size = New System.Drawing.Size(168, 22)
Me.TxtEqup.TabIndex = 5
Me.TxtEqup.Visible = False
'
'Label7
'
Me.Label7.Location = New System.Drawing.Point(23, 283)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(85, 18)
Me.Label7.TabIndex = 17
Me.Label7.Text = "Equip Cond"
Me.Label7.Visible = False
'
'TxtUser1
'
Me.TxtUser1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtUser1.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtUser1.Location = New System.Drawing.Point(105, 41)
Me.TxtUser1.MaxLength = 20
Me.TxtUser1.Name = "TxtUser1"
Me.TxtUser1.Size = New System.Drawing.Size(168, 22)
Me.TxtUser1.TabIndex = 6
'
'Label8
'
Me.Label8.Location = New System.Drawing.Point(23, 45)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(85, 18)
Me.Label8.TabIndex = 19
Me.Label8.Text = "User Defined 1"
'
'TxtUser2
'
Me.TxtUser2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtUser2.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtUser2.Location = New System.Drawing.Point(105, 67)
Me.TxtUser2.MaxLength = 20
Me.TxtUser2.Name = "TxtUser2"
Me.TxtUser2.Size = New System.Drawing.Size(168, 22)
Me.TxtUser2.TabIndex = 7
'
'Label9
'
Me.Label9.Location = New System.Drawing.Point(23, 71)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(85, 18)
Me.Label9.TabIndex = 21
Me.Label9.Text = "User Defined 2"
'
'TxtUser3
'
Me.TxtUser3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtUser3.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtUser3.Location = New System.Drawing.Point(105, 93)
Me.TxtUser3.MaxLength = 20
Me.TxtUser3.Name = "TxtUser3"
Me.TxtUser3.Size = New System.Drawing.Size(168, 22)
Me.TxtUser3.TabIndex = 8
'
'Label10
'
Me.Label10.Location = New System.Drawing.Point(23, 97)
Me.Label10.Name = "Label10"
Me.Label10.Size = New System.Drawing.Size(85, 18)
Me.Label10.TabIndex = 23
Me.Label10.Text = "User Defined 3"
'
'TxtUser4
'
Me.TxtUser4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtUser4.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtUser4.Location = New System.Drawing.Point(105, 119)
Me.TxtUser4.MaxLength = 20
Me.TxtUser4.Name = "TxtUser4"
Me.TxtUser4.Size = New System.Drawing.Size(168, 22)
Me.TxtUser4.TabIndex = 9
'
'Label11
'
Me.Label11.Location = New System.Drawing.Point(23, 123)
Me.Label11.Name = "Label11"
Me.Label11.Size = New System.Drawing.Size(85, 18)
Me.Label11.TabIndex = 25
Me.Label11.Text = "User Defined 4"
'
'TxtUser5
'
Me.TxtUser5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtUser5.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtUser5.Location = New System.Drawing.Point(105, 145)
Me.TxtUser5.MaxLength = 20
Me.TxtUser5.Name = "TxtUser5"
Me.TxtUser5.Size = New System.Drawing.Size(168, 22)
Me.TxtUser5.TabIndex = 10
'
'Label12
'
Me.Label12.Location = New System.Drawing.Point(23, 149)
Me.Label12.Name = "Label12"
Me.Label12.Size = New System.Drawing.Size(85, 18)
Me.Label12.TabIndex = 27
Me.Label12.Text = "User Defined 5"
'
'FrmFA020B
'
Me.AllowDrop = True
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(285, 192)
Me.ControlBox = False
Me.Controls.Add(Me.TxtUser5)
Me.Controls.Add(Me.Label12)
Me.Controls.Add(Me.TxtUser4)
Me.Controls.Add(Me.Label11)
Me.Controls.Add(Me.TxtUser3)
Me.Controls.Add(Me.Label10)
Me.Controls.Add(Me.TxtUser2)
Me.Controls.Add(Me.Label9)
Me.Controls.Add(Me.TxtUser1)
Me.Controls.Add(Me.Label8)
Me.Controls.Add(Me.TxtEqup)
Me.Controls.Add(Me.Label7)
Me.Controls.Add(Me.TxtBldg)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.TxtAstype)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.TxtDept)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.TxtClass)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.TxtCode)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.label3)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmFA020B"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

  Private Sub FA020B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myFACAPT = New FACAPT.MyData()
    myFACAPT.MyDBConn = myDBConnect
    MyFrmFA020.TBarNew.Visible = False
    MyFrmFA020.TBarSave.Visible = True
    MyFrmFA020.TBarPrint.Visible = False
    MyFrmFA020.TBarDelete.Visible = False
    myFACAPT.GetOneRecordP(1)
    If myFACAPT.RecordNotFound Then Exit Sub
    If s_chg = False And s_full = False Then    '#sec
      MyFrmFA020.TBarSave.Visible = False
    End If
    With myFACAPT
      TxtCode.Text = Trim(._CAPT)
      TxtClass.Text = Trim(._CAP01)
      TxtDept.Text = Trim(._CAP02)
      TxtAstype.Text = Trim(._CAP03)
      TxtBldg.Text = Trim(._CAP04)
      TxtEqup.Text = Trim(._CAP05)
      TxtUser1.Text = Trim(._CAP06)
      TxtUser2.Text = Trim(._CAP07)
      TxtUser3.Text = Trim(._CAP08)
      TxtUser4.Text = Trim(._CAP09)
      TxtUser5.Text = Trim(._CAP10)
    End With
  End Sub
  Private Sub FA020B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmFA020.SbpScreen.Text = "FA020B"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Public Sub SaveData()
	Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
	myFACAPT.GetOneRecordP(1)
  MovetoFile()
  ' added this too
	EditChecks(ErrorField, ErrorMsg)
  If IsNothing(ErrorMsg(0)) Then
		If myFACAPT.RecordNotFound Then
			myFACAPT.AddOneRecordP()
		Else
			myFACAPT.UpdateOneRecordP()
		End If
  Else
    ShowError(ErrorField, ErrorMsg)
    Exit Sub
  End If
  Me.Close()
  End Sub
Private Sub MovetoFile()
	With myFACAPT
		._CAPT = TxtCode.Text
		._CAP01 = TxtClass.Text
		._CAP02 = TxtDept.Text
		._CAP03 = TxtAstype.Text
		._CAP04 = TxtBldg.Text
		._CAP05 = TxtEqup.Text
		._CAP06 = TxtUser1.Text
		._CAP07 = TxtUser2.Text
		._CAP08 = TxtUser3.Text
		._CAP09 = TxtUser4.Text
		._CAP10 = TxtUser5.Text
	End With
End Sub
	Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer

		For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next
	End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
	Dim I As Integer
	ErrProv.SetError(TxtCode, "")
	For I = 0 To ErrorField.GetUpperBound(0)
		 Select Case ErrorField(I)
		 End Select
		 Next I
End Sub
End Class
