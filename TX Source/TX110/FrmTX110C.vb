Public Class FrmTX110C
  Inherits System.Windows.Forms.Form
	Dim myTXZIP As TXZIP.myData
	Friend wrkzip5 As Single
  Friend wrkziptwn As String
  Friend pzip5 As Single
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
Friend WithEvents Txtzip5 As System.Windows.Forms.TextBox
Friend WithEvents Txtziptwn As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.Label1 = New System.Windows.Forms.Label
Me.Txtzip5 = New System.Windows.Forms.TextBox
Me.ErrProv = New System.Windows.Forms.ErrorProvider
Me.Label2 = New System.Windows.Forms.Label
Me.Txtziptwn = New System.Windows.Forms.TextBox
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 12)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(68, 16)
Me.Label1.TabIndex = 0
Me.Label1.Text = "ZIP Code"
Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
'
'Txtzip5
'
Me.Txtzip5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtzip5.Location = New System.Drawing.Point(80, 8)
Me.Txtzip5.MaxLength = 5
Me.Txtzip5.Name = "Txtzip5"
Me.Txtzip5.Size = New System.Drawing.Size(64, 20)
Me.Txtzip5.TabIndex = 0
Me.Txtzip5.Text = ""
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(8, 36)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(68, 16)
Me.Label2.TabIndex = 28
Me.Label2.Text = "Town Name"
Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
'
'Txtziptwn
'
Me.Txtziptwn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtziptwn.Location = New System.Drawing.Point(80, 32)
Me.Txtziptwn.MaxLength = 30
Me.Txtziptwn.Name = "Txtziptwn"
Me.Txtziptwn.Size = New System.Drawing.Size(348, 20)
Me.Txtziptwn.TabIndex = 2
Me.Txtziptwn.Text = ""
'
'FrmTX110C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(438, 64)
Me.Controls.Add(Me.Txtziptwn)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Txtzip5)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX110C"
Me.Text = "Maintain ZIP Codes"
Me.ResumeLayout(False)

    End Sub

#End Region
Private Sub FrmTX110C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	myTXZIP = New TXZIP.mydata(MyDBConnect)
  MyFrmTX110.TBarNew.Enabled = False
  MyFrmTX110.TBarSave.Enabled = True
  MyFrmTX110.TBarPrint.Enabled = False
  If wrkzip5 <> 0 Then
    MyFrmTX110.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(Txtzip5)
  End If
  If wrkzip5 = 0 Then
    Me.Text = "Add " & Me.Text
    MyFrmTX110.TBarDelete.Enabled = False
    Exit Sub
	End If
	myTXZIP.GetOneRecordP(wrkzip5)
  Txtzip5.Text = Format(wrkzip5, "00000")

	If myTXZIP.RecordNotFound Then
		MyFrmTX110.TBarNew.Enabled = False
		MyFrmTX110.TBarSave.Enabled = False
		MyFrmTX110.TBarDelete.Enabled = False
		Me.ErrProv.SetError(Txtzip5, "Record not found")
		Exit Sub
	End If

  If s_chg = False And s_full = False Then    '#sec
		MyFrmTX110.TBarSave.Visible = False
  End If
	With myTXZIP
		Txtziptwn.Text = Trim(._ZIPTWN)
	End With
End Sub
Private Sub FrmTX110C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX110.SbpScreen.Text = "TX110C"
  MyUtils.CenterForm(Me.ParentForm, Me)
    If wrkzip5 <> 0 Then
    End If
End Sub
Private Sub FrmTX110C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTX110.TBarNew.Enabled = True
  MyFrmTX110.TBarDelete.Enabled = False
  MyFrmTX110.TBarSave.Enabled = False
  MyFrmTX110.TBarPrint.Enabled = False
  MyFrmTX110B.FormatGrid()
  MyFrmTX110B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
	myTXZIP.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
	Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
	myTXZIP.GetOneRecordP(wrkzip5)
  If wrkzip5 = 0 Then
		If Not myTXZIP.RecordNotFound Then
			Me.ErrProv.SetError(Txtzip5, "Record already exists")
			Exit Sub
		End If
  End If
  If wrkzip5 > 0 Then
    MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
			myTXZIP.UpdateOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
    End If
	Else
    myTXZIP._ZIP5 = MyUtils.CnvSng(Txtzip5.Text)
		MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
			myTXZIP.AddOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
	With myTXZIP
		._ZIPTWN = Txtziptwn.Text
	End With
End Sub
	Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer

		For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next

		If Txtzip5.Text = String.Empty Then
			ErrorField(I) = "zip5"
			ErrorMsg(I) = "Zip Code is required"
			I = I + 1
		End If
	End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
	Dim I As Integer
	ErrProv.SetError(Txtzip5, "")
	For I = 0 To ErrorField.GetUpperBound(0)
		Select Case ErrorField(I)
		Case "zip5"
			ErrProv.SetError(Txtzip5, ErrorMsg(I))
		Case Nothing
			Exit Sub
		End Select
	Next I
End Sub

Private Sub Txtzip5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtzip5.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






