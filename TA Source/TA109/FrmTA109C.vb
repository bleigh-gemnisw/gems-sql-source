Public Class FrmTA109C
  Inherits System.Windows.Forms.Form
	Dim myTXPROETB As TXPROETB.myData
	Friend Wrkprmo As Integer
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
Friend WithEvents Txtprmo As System.Windows.Forms.TextBox
Friend WithEvents txtprpct As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.Txtprmo = New System.Windows.Forms.TextBox
Me.txtprpct = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(68, 20)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(84, 24)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Prorate Month"
'
'Txtprmo
'
Me.Txtprmo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtprmo.Location = New System.Drawing.Point(160, 20)
Me.Txtprmo.MaxLength = 2
Me.Txtprmo.Name = "Txtprmo"
Me.Txtprmo.Size = New System.Drawing.Size(26, 20)
Me.Txtprmo.TabIndex = 0
'
'txtprpct
'
Me.txtprpct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtprpct.Location = New System.Drawing.Point(160, 52)
Me.txtprpct.MaxLength = 5
Me.txtprpct.Name = "txtprpct"
Me.txtprpct.Size = New System.Drawing.Size(47, 20)
Me.txtprpct.TabIndex = 7
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(84, 52)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(68, 24)
Me.Label3.TabIndex = 4
Me.Label3.Text = "Percentage"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'FrmTA109C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(288, 102)
Me.Controls.Add(Me.txtprpct)
Me.Controls.Add(Me.Txtprmo)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA109C"
Me.Text = "Maintain Elderly Prorate Percentages"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTA109C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	myTXPROETB = New TXPROETB.mydata(MyDBConnect)
	MyFrmTA109.TBarNew.Enabled = False
  MyFrmTA109.TBarSave.Enabled = True
	If Wrkprmo <> 0 Then
		MyFrmTA109.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(Txtprmo)
	End If
  MyFrmTA109.TBarPrint.Enabled = False
	myTXPROETB.GetOneRecordP(Wrkprmo)
  Txtprmo.Text = Wrkprmo
	If myTXPROETB.RecordNotFound Then Exit Sub

    If s_chg = False And s_full = False Then    '#sec
      MyFrmTA109.TBarSave.Visible = False
    End If
	 With myTXPROETB
		 txtprpct.Text = ._PRPCT
	 End With
End Sub
Private Sub FrmTA109C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA109.SbpScreen.Text = "TA109C"
  MyUtils.CenterForm(Me.ParentForm, Me)
	If Wrkprmo <> 0 Then
		Txtprmo.ReadOnly = True
		txtprpct.Focus()
	End If
End Sub
Private Sub FrmTA109C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTA109.TBarNew.Enabled = True
  MyFrmTA109.TBarDelete.Enabled = False
  MyFrmTA109.TBarSave.Enabled = False
  MyFrmTA109.TBarPrint.Enabled = False
  MyFrmTA109.TBarSave.Visible = True
  MyFrmTA109B.FormatGrid()
  MyFrmTA109B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
		Exit Sub
  End If
	myTXPROETB.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
	Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
	myTXPROETB.GetOneRecordP(Txtprmo.Text)
	If Wrkprmo = 0 Then
		If Not myTXPROETB.RecordNotFound Then
			Me.ErrProv.SetError(Txtprmo, "Record already exists")
			Exit Sub
		End If
	End If
	If Wrkprmo <> 0 Then
		MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
			myTXPROETB.UpdateOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If
	Else
		myTXPROETB._PRMO = Txtprmo.Text
		MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
			myTXPROETB.AddOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If
	End If
	Me.Close()
End Sub
Private Sub MovetoFile()
	With myTXPROETB
    ._PRPCT = MyUtils.CnvSng(txtprpct.Text)
  End With
End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(Txtprmo.Text) = 0 Or MyUtils.CnvSng(Txtprmo.Text) > 12 Then
      ErrorField(I) = "prmo"
      ErrorMsg(I) = "Month is invalid"
      I = I + 1
    End If

    If MyUtils.CnvSng(txtprpct.Text) = 0 Or MyUtils.CnvSng(txtprpct.Text) > 1 Then
      ErrorField(I) = "prpct"
      ErrorMsg(I) = "Percentage is invalid"
      I = I + 1
    End If

  End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
	Dim I As Integer
	ErrProv.SetError(Txtprmo, "")
	ErrProv.SetError(txtprpct, "")
	For I = 0 To ErrorField.GetUpperBound(0)
		Select Case ErrorField(I)
		Case "prmo"
			ErrProv.SetError(Txtprmo, ErrorMsg(I))
		Case "prpct"
			ErrProv.SetError(txtprpct, ErrorMsg(I))
		Case ""
			Exit Sub
		End Select
	Next I
End Sub
Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
End Sub
Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
End Sub
Private Sub Txtprmo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtprmo.TextChanged
End Sub
Private Sub Label2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
End Sub
Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
End Sub

Private Sub Txtprmo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtprmo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub txtprpct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtprpct.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
End Class






