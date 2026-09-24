Public Class FrmTX113C
  Inherits System.Windows.Forms.Form
  Dim myTXFMSTMT As TXFMSTMT.myData
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtPayTo As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents TxtState As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents TxtTwname As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend Wrktype As String
  Friend WithEvents TxtClerk As System.Windows.Forms.TextBox
	Friend WithEvents TxtSigned As System.Windows.Forms.TextBox
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
Friend WithEvents TxtLine1 As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtLine2 As System.Windows.Forms.TextBox
Friend WithEvents TxtLine3 As System.Windows.Forms.TextBox
Friend WithEvents TxtLine4 As System.Windows.Forms.TextBox
Friend WithEvents TxtLine5 As System.Windows.Forms.TextBox
Friend WithEvents TxtTitle As System.Windows.Forms.TextBox
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Txttype = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.TxtLine1 = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.TxtLine2 = New System.Windows.Forms.TextBox
Me.TxtLine3 = New System.Windows.Forms.TextBox
Me.TxtLine4 = New System.Windows.Forms.TextBox
Me.TxtLine5 = New System.Windows.Forms.TextBox
Me.TxtTitle = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.TxtPayTo = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.Label5 = New System.Windows.Forms.Label
Me.Label6 = New System.Windows.Forms.Label
Me.Label7 = New System.Windows.Forms.Label
Me.Label8 = New System.Windows.Forms.Label
Me.Label9 = New System.Windows.Forms.Label
Me.Label10 = New System.Windows.Forms.Label
Me.Label11 = New System.Windows.Forms.Label
Me.TxtTwname = New System.Windows.Forms.TextBox
Me.Label12 = New System.Windows.Forms.Label
Me.TxtState = New System.Windows.Forms.TextBox
Me.TxtSigned = New System.Windows.Forms.TextBox
Me.TxtClerk = New System.Windows.Forms.TextBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Txttype
'
Me.Txttype.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txttype.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Txttype.Location = New System.Drawing.Point(48, 16)
Me.Txttype.MaxLength = 1
Me.Txttype.Name = "Txttype"
Me.Txttype.Size = New System.Drawing.Size(20, 22)
Me.Txttype.TabIndex = 0
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
'TxtLine1
'
Me.TxtLine1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtLine1.Location = New System.Drawing.Point(162, 82)
Me.TxtLine1.MaxLength = 40
Me.TxtLine1.Name = "TxtLine1"
Me.TxtLine1.Size = New System.Drawing.Size(326, 22)
Me.TxtLine1.TabIndex = 2
'
'Label2
'
Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label2.Location = New System.Drawing.Point(36, 82)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(120, 20)
Me.Label2.TabIndex = 3
Me.Label2.Text = "Line 1"
Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'TxtLine2
'
Me.TxtLine2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtLine2.Location = New System.Drawing.Point(162, 108)
Me.TxtLine2.MaxLength = 40
Me.TxtLine2.Name = "TxtLine2"
Me.TxtLine2.Size = New System.Drawing.Size(326, 22)
Me.TxtLine2.TabIndex = 3
'
'TxtLine3
'
Me.TxtLine3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtLine3.Location = New System.Drawing.Point(162, 136)
Me.TxtLine3.MaxLength = 40
Me.TxtLine3.Name = "TxtLine3"
Me.TxtLine3.Size = New System.Drawing.Size(326, 22)
Me.TxtLine3.TabIndex = 4
'
'TxtLine4
'
Me.TxtLine4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtLine4.Location = New System.Drawing.Point(162, 164)
Me.TxtLine4.MaxLength = 40
Me.TxtLine4.Name = "TxtLine4"
Me.TxtLine4.Size = New System.Drawing.Size(326, 22)
Me.TxtLine4.TabIndex = 5
'
'TxtLine5
'
Me.TxtLine5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtLine5.Location = New System.Drawing.Point(162, 192)
Me.TxtLine5.MaxLength = 40
Me.TxtLine5.Name = "TxtLine5"
Me.TxtLine5.Size = New System.Drawing.Size(326, 22)
Me.TxtLine5.TabIndex = 6
'
'TxtTitle
'
Me.TxtTitle.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtTitle.Location = New System.Drawing.Point(162, 220)
Me.TxtTitle.MaxLength = 25
Me.TxtTitle.Name = "TxtTitle"
Me.TxtTitle.Size = New System.Drawing.Size(211, 22)
Me.TxtTitle.TabIndex = 7
'
'Label3
'
Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label3.Location = New System.Drawing.Point(36, 56)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(120, 20)
Me.Label3.TabIndex = 19
Me.Label3.Text = "Pay to"
Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'TxtPayTo
'
Me.TxtPayTo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtPayTo.Location = New System.Drawing.Point(162, 56)
Me.TxtPayTo.MaxLength = 30
Me.TxtPayTo.Name = "TxtPayTo"
Me.TxtPayTo.Size = New System.Drawing.Size(250, 22)
Me.TxtPayTo.TabIndex = 1
'
'Label4
'
Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label4.Location = New System.Drawing.Point(36, 108)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(120, 20)
Me.Label4.TabIndex = 20
Me.Label4.Text = "Line 2"
Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label5
'
Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label5.Location = New System.Drawing.Point(36, 136)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(120, 20)
Me.Label5.TabIndex = 21
Me.Label5.Text = "Line 3"
Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label6
'
Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label6.Location = New System.Drawing.Point(36, 164)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(120, 20)
Me.Label6.TabIndex = 22
Me.Label6.Text = "Line 4"
Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label7
'
Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label7.Location = New System.Drawing.Point(36, 192)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(120, 20)
Me.Label7.TabIndex = 23
Me.Label7.Text = "Line 5"
Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label8
'
Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label8.Location = New System.Drawing.Point(36, 219)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(120, 20)
Me.Label8.TabIndex = 24
Me.Label8.Text = "Collector Title"
Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label9
'
Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label9.Location = New System.Drawing.Point(36, 247)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(120, 20)
Me.Label9.TabIndex = 25
Me.Label9.Text = "Signed"
Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label10
'
Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label10.Location = New System.Drawing.Point(38, 274)
Me.Label10.Name = "Label10"
Me.Label10.Size = New System.Drawing.Size(120, 20)
Me.Label10.TabIndex = 27
Me.Label10.Text = "Clerk Title"
Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label11
'
Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label11.Location = New System.Drawing.Point(38, 299)
Me.Label11.Name = "Label11"
Me.Label11.Size = New System.Drawing.Size(120, 20)
Me.Label11.TabIndex = 29
Me.Label11.Text = "Town Name"
Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'TxtTwname
'
Me.TxtTwname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtTwname.Location = New System.Drawing.Point(162, 299)
Me.TxtTwname.MaxLength = 20
Me.TxtTwname.Name = "TxtTwname"
Me.TxtTwname.Size = New System.Drawing.Size(171, 22)
Me.TxtTwname.TabIndex = 10
'
'Label12
'
Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label12.Location = New System.Drawing.Point(36, 324)
Me.Label12.Name = "Label12"
Me.Label12.Size = New System.Drawing.Size(120, 20)
Me.Label12.TabIndex = 31
Me.Label12.Text = "State"
Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'TxtState
'
Me.TxtState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtState.Location = New System.Drawing.Point(162, 325)
Me.TxtState.MaxLength = 2
Me.TxtState.Name = "TxtState"
Me.TxtState.Size = New System.Drawing.Size(30, 22)
Me.TxtState.TabIndex = 11
'
'TxtSigned
'
Me.TxtSigned.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtSigned.Location = New System.Drawing.Point(162, 248)
Me.TxtSigned.MaxLength = 50
Me.TxtSigned.Name = "TxtSigned"
Me.TxtSigned.Size = New System.Drawing.Size(412, 22)
Me.TxtSigned.TabIndex = 32
'
'TxtClerk
'
Me.TxtClerk.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtClerk.Location = New System.Drawing.Point(162, 274)
Me.TxtClerk.MaxLength = 25
Me.TxtClerk.Name = "TxtClerk"
Me.TxtClerk.Size = New System.Drawing.Size(211, 22)
Me.TxtClerk.TabIndex = 33
'
'FrmTX113C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(588, 352)
Me.Controls.Add(Me.TxtClerk)
Me.Controls.Add(Me.TxtSigned)
Me.Controls.Add(Me.Label12)
Me.Controls.Add(Me.TxtState)
Me.Controls.Add(Me.Label11)
Me.Controls.Add(Me.TxtTwname)
Me.Controls.Add(Me.Label10)
Me.Controls.Add(Me.Label9)
Me.Controls.Add(Me.Label8)
Me.Controls.Add(Me.Label7)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.TxtPayTo)
Me.Controls.Add(Me.TxtTitle)
Me.Controls.Add(Me.TxtLine5)
Me.Controls.Add(Me.TxtLine4)
Me.Controls.Add(Me.TxtLine3)
Me.Controls.Add(Me.TxtLine2)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.TxtLine1)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.Txttype)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX113C"
Me.Text = "Maintain Statement & Lien Information"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

	Private Sub FrmTX113C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	myTXFMSTMT = New TXFMSTMT.mydata(MyDBConnect)
	MyFrmTX113.TBarNew.Enabled = False
	MyFrmTX113.TBarSave.Enabled = True
	If Not WrkAddMode Then
		MyFrmTX113.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(Txttype)
	Else
		Exit Sub
	End If
	MyFrmTX113.TBarPrint.Enabled = False

	myTXFMSTMT.GetOneRecordP(Wrktype)
	Txttype.Text = Wrktype
	If myTXFMSTMT.RecordNotFound Then Exit Sub

	With myTXFMSTMT
		TxtPayTo.Text = Trim(._PAYTO)
		TxtLine1.Text = Trim(._LINE1)
		TxtLine2.Text = Trim(._LINE2)
		TxtLine3.Text = Trim(._LINE3)
		TxtLine4.Text = Trim(._LINE4)
		TxtLine5.Text = Trim(._LINE5)
		TxtTitle.Text = Trim(._TITLE)
		TxtSigned.Text = Trim(._SIGNED)
		TxtClerk.Text = Trim(._CLERK)
		TxtTwname.Text = Trim(._TWNAME)
		TxtState.Text = Trim(._STATE)
	End With
 End Sub

Private Sub FrmTX113C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmTX113.SbpScreen.Text = "TX113C"
  MyUtils.CenterForm(Me.ParentForm, Me)
		If Wrktype <> "" Then
		End If
End Sub

Private Sub FrmTX113C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
	MyFrmTX113.TBarNew.Enabled = True
	MyFrmTX113.TBarDelete.Enabled = False
	MyFrmTX113.TBarSave.Enabled = False
	MyFrmTX113.TBarPrint.Enabled = False
	MyFrmTX113B.FormatGrid()
	MyFrmTX113B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
  myTXFMSTMT.DeleteOneRecordP()
  Me.Close()
End Sub

Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  myTXFMSTMT.GetOneRecordP(Txttype.Text)
  If WrkAddMode Then
    If Not myTXFMSTMT.RecordNotFound Then
      Me.ErrProv.SetError(Txttype, "Record already exists")
      Exit Sub
    End If
  End If
  If Not WrkAddMode Then
    MovetoFile()
    If IsNothing(ErrorMsg(0)) Then
      myTXFMSTMT.UpdateOneRecordP()
      Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  Else
    myTXFMSTMT._TYPE = Txttype.Text
    MovetoFile()
    If IsNothing(ErrorMsg(0)) Then
      myTXFMSTMT.AddOneRecordP()
      Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myTXFMSTMT
    ._PAYTO = TxtPayTo.Text
    ._LINE1 = TxtLine1.Text
    ._LINE2 = TxtLine2.Text
    ._LINE3 = TxtLine3.Text
    ._LINE4 = TxtLine4.Text
    ._LINE5 = TxtLine5.Text
    ._TITLE = TxtTitle.Text
    ._SIGNED = TxtSigned.Text
    ._CLERK = TxtClerk.Text
    ._TWNAME = TxtTwname.Text
    ._STATE = TxtState.Text
 End With
 End Sub

 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(Txttype, "")
  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
      Case "type"
      ErrProv.SetError(Txttype, ErrorMsg(I))
    Case Nothing
      Exit Sub
    End Select
  Next I
End Sub
End Class






