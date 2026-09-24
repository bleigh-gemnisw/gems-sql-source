Public Class FrmTA111C
  Inherits System.Windows.Forms.Form
	Dim myTXLOCCD As TXLOCCD.myData
	Friend wrkbncode As String
  Friend wrkbndsc As String
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
Friend WithEvents Txtbncode As System.Windows.Forms.TextBox
Friend WithEvents Txtbndsc As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.Txtbncode = New System.Windows.Forms.TextBox
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Label2 = New System.Windows.Forms.Label
Me.Txtbndsc = New System.Windows.Forms.TextBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 12)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(76, 16)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Benefit Code"
'
'Txtbncode
'
Me.Txtbncode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtbncode.Location = New System.Drawing.Point(90, 9)
Me.Txtbncode.MaxLength = 2
Me.Txtbncode.Name = "Txtbncode"
Me.Txtbncode.Size = New System.Drawing.Size(28, 20)
Me.Txtbncode.TabIndex = 0
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(132, 12)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(92, 16)
Me.Label2.TabIndex = 28
Me.Label2.Text = "Code Description"
Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Txtbndsc
'
Me.Txtbndsc.Location = New System.Drawing.Point(228, 8)
Me.Txtbndsc.MaxLength = 30
Me.Txtbndsc.Name = "Txtbndsc"
Me.Txtbndsc.Size = New System.Drawing.Size(344, 20)
Me.Txtbndsc.TabIndex = 2
'
'FrmTA111C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(598, 36)
Me.Controls.Add(Me.Txtbndsc)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Txtbncode)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA111C"
Me.Text = "Maintain Local Benefit Codes"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region
Private Sub FrmTA111C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	myTXLOCCD = New TXLOCCD.mydata(MyDBConnect)
  MyFrmTA111.TBarNew.Enabled = False
  MyFrmTA111.TBarSave.Enabled = True
  MyFrmTA111.TBarPrint.Enabled = False
  If wrkbncode <> "" Then
    MyFrmTA111.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(Txtbncode)
  End If
  If wrkbncode = "" Then
    Me.Text = "Add " & Me.Text
    MyFrmTA111.TBarDelete.Enabled = False
    Exit Sub
    End If
	myTXLOCCD.GetOneRecordP(wrkbncode)
  Txtbncode.Text = wrkbncode
  Txtbndsc.Text = wrkbndsc

	If myTXLOCCD.RecordNotFound Then
		MyFrmTA111.TBarNew.Enabled = False
		MyFrmTA111.TBarSave.Enabled = False
		MyFrmTA111.TBarDelete.Enabled = False
		Me.ErrProv.SetError(Txtbncode, "Record not found")
		Exit Sub
	End If

  If s_chg = False And s_full = False Then    '#sec
    MyFrmTA111.TBarSave.Visible = False
  End If

	With myTXLOCCD
		Txtbndsc.Text = Trim(._BNDSC)
	End With
End Sub
Private Sub FrmTA111C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA111.SbpScreen.Text = "TA111C"
  MyUtils.CenterForm(Me.ParentForm, Me)
    If wrkbncode <> "" Then
  End If
End Sub
Private Sub FrmTA111C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTA111.TBarNew.Enabled = True
  MyFrmTA111.TBarDelete.Enabled = False
  MyFrmTA111.TBarSave.Enabled = False
  MyFrmTA111.TBarPrint.Enabled = False
  MyFrmTA111B.FormatGrid()
  MyFrmTA111B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
	myTXLOCCD.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
	Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
	myTXLOCCD.GetOneRecordP(Txtbncode.Text)
  If wrkbncode = "" Then
		If Not myTXLOCCD.RecordNotFound Then
			Me.ErrProv.SetError(Txtbncode, "Record already exists")
			Exit Sub
		End If
  End If
  If wrkbncode <> "" Then
    MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
			myTXLOCCD.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  Else
		myTXLOCCD._BNCODE = Txtbncode.Text
    MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
			myTXLOCCD.AddOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
	With myTXLOCCD
		._BNDSC = Txtbndsc.Text
	End With
End Sub
	Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer

		For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next

		If Txtbncode.Text = String.Empty Then
			ErrorField(I) = "bncode"
			ErrorMsg(I) = "Code is required"
			I = I + 1
		End If

		If Txtbndsc.Text = String.Empty Then
			ErrorField(I) = "bndsc"
			ErrorMsg(I) = "Description is required"
			I = I + 1
		End If

	End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
	Dim I As Integer
	ErrProv.SetError(Txtbncode, "")
	ErrProv.SetError(Txtbndsc, "")
	For I = 0 To ErrorField.GetUpperBound(0)
		Select Case ErrorField(I)
		Case "bncode"
			ErrProv.SetError(Txtbncode, ErrorMsg(I))
		Case "bndsc"
			ErrProv.SetError(Txtbndsc, ErrorMsg(I))
		Case Nothing
			Exit Sub
		End Select
	Next I
End Sub
End Class






