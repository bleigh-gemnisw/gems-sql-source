Public Class FrmTAP17C
	Inherits System.Windows.Forms.Form
	Dim myTXCODE As TXCode.myData
	Dim myTXDVCD As TXDVCD.myData
	Dim ds As DataSet = New DataSet
	Friend WrkYear As Integer
	Friend WrkTXDVCD As String
	Friend WrkTxType As String
	Friend WithEvents TxtAspct As System.Windows.Forms.TextBox
 Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
	Friend WithEvents Label5 As System.Windows.Forms.Label

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
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents TxtAscode As System.Windows.Forms.TextBox
	Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.TxtCode = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.Label4 = New System.Windows.Forms.Label
Me.TxtAscode = New System.Windows.Forms.TextBox
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TxtAspct = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
Me.TxtDesc = New System.Windows.Forms.TextBox
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
'TxtCode
'
Me.TxtCode.Location = New System.Drawing.Point(124, 12)
Me.TxtCode.MaxLength = 3
Me.TxtCode.Name = "TxtCode"
Me.TxtCode.Size = New System.Drawing.Size(36, 20)
Me.TxtCode.TabIndex = 0
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(8, 36)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(92, 24)
Me.Label2.TabIndex = 2
Me.Label2.Text = "Description"
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(8, 60)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(112, 24)
Me.Label4.TabIndex = 6
Me.Label4.Text = "Assessment Code"
'
'TxtAscode
'
Me.TxtAscode.Location = New System.Drawing.Point(124, 60)
Me.TxtAscode.MaxLength = 3
Me.TxtAscode.Name = "TxtAscode"
Me.TxtAscode.Size = New System.Drawing.Size(36, 20)
Me.TxtAscode.TabIndex = 2
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'TxtAspct
'
Me.TxtAspct.Location = New System.Drawing.Point(124, 84)
Me.TxtAspct.MaxLength = 3
Me.TxtAspct.Name = "TxtAspct"
Me.TxtAspct.Size = New System.Drawing.Size(36, 20)
Me.TxtAspct.TabIndex = 3
'
'Label5
'
Me.Label5.Location = New System.Drawing.Point(8, 84)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(110, 24)
Me.Label5.TabIndex = 7
Me.Label5.Text = "Assessment Percent"
'
'TxtDesc
'
Me.TxtDesc.Location = New System.Drawing.Point(124, 36)
Me.TxtDesc.MaxLength = 50
Me.TxtDesc.Name = "TxtDesc"
Me.TxtDesc.Size = New System.Drawing.Size(288, 20)
Me.TxtDesc.TabIndex = 1
'
'FrmTAP17C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(421, 120)
Me.Controls.Add(Me.TxtDesc)
Me.Controls.Add(Me.TxtAspct)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.TxtAscode)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.TxtCode)
Me.Controls.Add(Me.Label1)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTAP17C"
Me.Text = "Maintain MV - Property Codes"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTAP17C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	WrkTxType = "P"
	myTXCODE = New TXCode.mydata(MyDBConnect)
	myTXDVCD = New TXDVCD.mydata(MyDBConnect)

	MyFrmTAP17.TBarNew.Enabled = False
	MyFrmTAP17.TBarSave.Enabled = True
	If WrkTXDVCD > 0 Then
		MyFrmTAP17.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(TxtCode)
	End If

	myTXDVCD.GetOneRecordP(WrkYear, WrkTXDVCD)
	If myTXDVCD.RecordNotFound Then Exit Sub
	TxtCode.Text = WrkTXDVCD

	If s_chg = False And s_full = False Then		'#sec
		MyFrmTAP17.TBarSave.Visible = False
	End If
	With myTXDVCD
		TxtDesc.Text = Trim(._DESC)
		TxtAscode.Text = ._ASCODE
		TxtAspct.Text = ._ASPCT
	End With
End Sub
Private Sub FrmTAP17C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmTAP17.SbpScreen.Text = "TAP17C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmTAP17C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
	MyFrmTAP17.TBarNew.Enabled = True
	MyFrmTAP17.TBarDelete.Enabled = False
	MyFrmTAP17.TBarSave.Enabled = False
	MyFrmTAP17.TBarSave.Visible = True	 '#sec
	MyFrmTAP17B.FormatGrid()
	MyFrmTAP17B.Show()
End Sub
Public Sub DeleteData(ByRef Cancel As Boolean)
	Dim Answer As Integer
		Cancel = True
		Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
		If Answer = vbNo Then Exit Sub

		Cancel = False
		myTXDVCD.DeleteOneRecordP()

End Sub
Public Sub SaveData()
	Dim ErrorField(25) As String
	Dim ErrorMsg(25) As String

	ErrProv.SetError(TxtCode, "")
	ErrProv.SetError(TxtAscode, "")
	WrkTxType = "P"
  myTXDVCD.GetOneRecordP(WrkYear, MyUtils.CnvSng(TxtCode.Text))
  If WrkTXDVCD = "" Then
    If myTXDVCD.RecordNotFound = False Then
      Me.ErrProv.SetError(TxtCode, "Record already exists")
      Exit Sub
    End If
  End If

  If Not myTXDVCD.RecordNotFound Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MovetoFile()
        myTXDVCD.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MovetoFile()
        myTXDVCD.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
  Me.Close()
End Sub
Private Sub MovetoFile()

   With myTXDVCD
    ._YEAR = WrkYear
    ._CODE = MyUtils.CnvSng(TxtCode.Text)
    ._ASCODE = MyUtils.CnvSng(TxtAscode.Text)
    ._ASPCT = MyUtils.CnvSng(TxtAspct.Text)
    ._DESC = TxtDesc.Text
  End With

End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtAscode, "")
  ErrProv.SetError(TxtCode, "")
  ErrProv.SetError(TxtDesc, "")

  For I = 0 To ErrorField.GetUpperBound(0)
  Select Case ErrorField(I)
    Case "ascode"
      ErrProv.SetError(TxtAscode, ErrorMsg(I))
    Case "code"
      ErrProv.SetError(TxtCode, ErrorMsg(I))
    Case "desc"
      ErrProv.SetError(TxtDesc, ErrorMsg(I))
    Case Nothing
      Exit Sub
  End Select
  Next I
End Sub
Private Sub TxtCode_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode.KeyPress
e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtAscode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAscode.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtAspct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAspct.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

  If TxtCode.Text = String.Empty Then
      ErrorField(I) = "code"
      ErrorMsg(I) = "Invalid Code"
      I = I + 1
  End If

  If TxtDesc.Text = String.Empty Then
      ErrorField(I) = "desc"
      ErrorMsg(I) = "Invalid Description"
      I = I + 1
  End If

  myTXCODE.GetOneRecordP(MyUtils.CnvSng(TxtAscode.Text), WrkTxType)
  If myTXCODE.RecordNotFound Then
      ErrorField(I) = "ascode"
      ErrorMsg(I) = "Invalid Property Code"
      I = I + 1
  End If
  End Sub
End Class






