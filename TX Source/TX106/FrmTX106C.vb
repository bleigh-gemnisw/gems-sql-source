Public Class FrmTX106C
  Inherits System.Windows.Forms.Form
	Dim myTXSRESN As TXSRESN.myData
	Friend Wrksresn As String
  Friend Wrksrdesc As String
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
Friend WithEvents Txtsresn As System.Windows.Forms.TextBox
Friend WithEvents Txtsrdesc As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.Label1 = New System.Windows.Forms.Label
Me.Txtsresn = New System.Windows.Forms.TextBox
Me.ErrProv = New System.Windows.Forms.ErrorProvider
Me.Label2 = New System.Windows.Forms.Label
Me.Txtsrdesc = New System.Windows.Forms.TextBox
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 12)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(32, 16)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Code"
'
'Txtsresn
'
Me.Txtsresn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtsresn.Location = New System.Drawing.Point(48, 8)
Me.Txtsresn.MaxLength = 1
Me.Txtsresn.Name = "Txtsresn"
Me.Txtsresn.Size = New System.Drawing.Size(16, 20)
Me.Txtsresn.TabIndex = 0
Me.Txtsresn.Text = ""
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(76, 12)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(92, 16)
Me.Label2.TabIndex = 28
Me.Label2.Text = "Code Description"
'
'Txtsrdesc
'
Me.Txtsrdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtsrdesc.Location = New System.Drawing.Point(176, 8)
Me.Txtsrdesc.MaxLength = 30
Me.Txtsrdesc.Name = "Txtsrdesc"
Me.Txtsrdesc.Size = New System.Drawing.Size(348, 20)
Me.Txtsrdesc.TabIndex = 2
Me.Txtsrdesc.Text = ""
'
'FrmTX106C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(542, 44)
Me.Controls.Add(Me.Txtsrdesc)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Txtsresn)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX106C"
Me.Text = "Maintain Suspense Reason Codes"
Me.ResumeLayout(False)

    End Sub

#End Region

Private Sub FrmTX106C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	myTXSRESN = New TXSRESN.mydata(MyDBConnect)
  MyFrmTX106.TBarNew.Enabled = False
  MyFrmTX106.TBarSave.Enabled = True
  MyFrmTX106.TBarPrint.Enabled = False
  If Wrksresn <> "" Then
    MyFrmTX106.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(Txtsresn)
  End If
  If Wrksresn = "" Then
    Me.Text = "Add " & Me.Text
    MyFrmTX106.TBarDelete.Enabled = False
    Exit Sub
	End If
	myTXSRESN.GetOneRecordP(Wrksresn)

	If myTXSRESN.RecordNotFound Then
		MyFrmTX106.TBarNew.Enabled = False
		MyFrmTX106.TBarSave.Enabled = False
		MyFrmTX106.TBarDelete.Enabled = False
		Me.ErrProv.SetError(Txtsresn, "Record not found")
		Exit Sub
	End If

  If s_chg = False And s_full = False Then    '#sec
		MyFrmTX106.TBarSave.Visible = False
	End If

	Txtsresn.Text = Wrksresn
	Txtsrdesc.Text = Wrksrdesc
 End Sub
Private Sub FrmTX106C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX106.SbpScreen.Text = "TX106C"
  MyUtils.CenterForm(Me.ParentForm, Me)
	If Wrksresn <> "" Then
	End If
End Sub
Private Sub FrmTX106C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTX106.TBarNew.Enabled = True
  MyFrmTX106.TBarDelete.Enabled = False
  MyFrmTX106.TBarSave.Enabled = False
  MyFrmTX106.TBarPrint.Enabled = False
  MyFrmTX106B.FormatGrid()
  MyFrmTX106B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
	myTXSRESN.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
	Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
	myTXSRESN.GetOneRecordP(Txtsresn.Text)
  If Wrksresn = "" Then
    If Not myTXSRESN.RecordNotFound Then
      Me.ErrProv.SetError(Txtsresn, "Record already exists")
      Exit Sub
    End If
  End If
  If Wrksresn <> "" Then
    MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
			myTXSRESN.UpdateOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
    End If
    Else
		myTXSRESN._SRESN = Txtsresn.Text
    MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
			myTXSRESN.AddOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
	With myTXSRESN
		._SRDESC = Txtsrdesc.Text
	End With
 End Sub
	Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer

		For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next

		If Txtsresn.Text = String.Empty Then
			ErrorField(I) = "resn"
			ErrorMsg(I) = "Reason Code is required"
			I = I + 1
		End If

		If Txtsrdesc.Text = String.Empty Then
			ErrorField(I) = "desc"
			ErrorMsg(I) = "Description is required"
			I = I + 1
		End If

	End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
	Dim I As Integer
	ErrProv.SetError(Txtsresn, "")
	ErrProv.SetError(Txtsrdesc, "")
	For I = 0 To ErrorField.GetUpperBound(0)
		Select Case ErrorField(I)
		Case "resn"
			ErrProv.SetError(Txtsresn, ErrorMsg(I))
		Case "desc"
			ErrProv.SetError(Txtsrdesc, ErrorMsg(I))
		Case Nothing
			Exit Sub
		End Select
	Next I
End Sub
End Class






