Public Class FrmTA105C
  Inherits System.Windows.Forms.Form
	Dim myTXHOME As TXHOME.MyData
  Friend Wrkcrperc As Decimal
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
Friend WithEvents txtcrmax As System.Windows.Forms.TextBox
Friend WithEvents TxTcrmin As System.Windows.Forms.TextBox
Friend WithEvents Txtcrperc As System.Windows.Forms.TextBox
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.Txtcrperc = New System.Windows.Forms.TextBox
Me.txtcrmax = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Label2 = New System.Windows.Forms.Label
Me.TxTcrmin = New System.Windows.Forms.TextBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 12)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(112, 24)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Tax Credit %"
'
'Txtcrperc
'
Me.Txtcrperc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtcrperc.Location = New System.Drawing.Point(124, 12)
Me.Txtcrperc.MaxLength = 3
Me.Txtcrperc.Name = "Txtcrperc"
Me.Txtcrperc.Size = New System.Drawing.Size(56, 20)
Me.Txtcrperc.TabIndex = 0
'
'txtcrmax
'
Me.txtcrmax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtcrmax.Location = New System.Drawing.Point(124, 36)
Me.txtcrmax.MaxLength = 5
Me.txtcrmax.Name = "txtcrmax"
Me.txtcrmax.Size = New System.Drawing.Size(56, 20)
Me.txtcrmax.TabIndex = 1
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(8, 36)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(112, 24)
Me.Label3.TabIndex = 4
Me.Label3.Text = "Tax Credit Maximum"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(8, 60)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(112, 24)
Me.Label2.TabIndex = 5
Me.Label2.Text = "Tax Credit Minimum"
'
'TxTcrmin
'
Me.TxTcrmin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxTcrmin.Location = New System.Drawing.Point(124, 60)
Me.TxTcrmin.MaxLength = 5
Me.TxTcrmin.Name = "TxTcrmin"
Me.TxTcrmin.Size = New System.Drawing.Size(56, 20)
Me.TxTcrmin.TabIndex = 6
'
'FrmTA105C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(268, 98)
Me.Controls.Add(Me.TxTcrmin)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.txtcrmax)
Me.Controls.Add(Me.Txtcrperc)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA105C"
Me.Text = "Maintain Homeowners Percentages"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTA105C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	myTXHOME = New TXHOME.mydata(MyDBConnect)
	MyFrmTA105.TBarNew.Enabled = False
	MyFrmTA105.TBarSave.Enabled = True
    If Wrkcrperc > 0 Then
      MyFrmTA105.TBarDelete.Enabled = True
      Txtcrperc.TabStop = False
      Txtcrperc.ReadOnly = True
    End If
    MyFrmTA105.TBarPrint.Enabled = False
    myTXHOME.GetOneRecordP(Wrkcrperc)
    Txtcrperc.Text = Wrkcrperc
	If myTXHOME.RecordNotFound Then Exit Sub

	If s_chg = False And s_full = False Then		'#sec
		MyFrmTA105.TBarSave.Visible = False
	End If
	With myTXHOME
		txtcrmax.Text = ._CRMAX
		TxTcrmin.Text = ._CRMIN
	End With
End Sub
Private Sub FrmTA105C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA105.SbpScreen.Text = "TA105C"
  MyUtils.CenterForm(Me.ParentForm, Me)
    If Wrkcrperc > 0 Then
      Txtcrperc.ReadOnly = True
      txtcrmax.Focus()
    End If
  End Sub
Private Sub FrmTA105C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTA105.TBarNew.Enabled = True
  MyFrmTA105.TBarDelete.Enabled = False
  MyFrmTA105.TBarSave.Enabled = False
  MyFrmTA105.TBarPrint.Enabled = False
  MyFrmTA105.TBarSave.Visible = True
  MyFrmTA105B.FormatGrid()
  MyFrmTA105B.Show()
End Sub
Public Sub DeleteData(ByRef WrkCancel As Boolean)
  Dim Answer As Integer
  WrkCancel = True
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
  WrkCancel = False
	myTXHOME.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
	Dim ErrorField(25) As String
	Dim ErrorMsg(25) As String
	If Txtcrperc Is Nothing Then
		Me.ErrProv.SetError(Txtcrperc, "Percentage cannot be blank")
		Exit Sub
	End If
  myTXHOME.GetOneRecordP(MyUtils.CnvSng(Txtcrperc.Text))
    If Wrkcrperc = 0 Then
      If Not myTXHOME.RecordNotFound Then
        Me.ErrProv.SetError(Txtcrperc, "Record already exists")
        Exit Sub
      End If
    End If
    If Wrkcrperc < 0 Then
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXHOME.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      myTXHOME._CRPERC = MyUtils.CnvSng(Txtcrperc.Text)
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXHOME.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()
End Sub
Private Sub MovetoFile()
  With myTXHOME
    ._CRMAX = MyUtils.CnvSng(txtcrmax.Text)
    ._CRMIN = MyUtils.CnvSng(TxTcrmin.Text)
  End With
End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(Txtcrperc.Text) = 0 Then
      ErrorField(I) = "crperc"
      ErrorMsg(I) = "Percentage cannot be zero"
      I = I + 1
    End If

    If MyUtils.CnvSng(txtcrmax.Text) = 0 Then
      ErrorField(I) = "crmax"
      ErrorMsg(I) = "Maximum cannot be zero"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxTcrmin.Text) = 0 Then
      ErrorField(I) = "crmin"
      ErrorMsg(I) = "Minimum cannot be zero"
      I = I + 1
    End If
End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
	Dim I As Integer
	ErrProv.SetError(Txtcrperc, "")
	ErrProv.SetError(txtcrmax, "")
	ErrProv.SetError(TxTcrmin, "")
	For I = 0 To ErrorField.GetUpperBound(0)
		Select Case ErrorField(I)
		Case "crperc"
			ErrProv.SetError(Txtcrperc, ErrorMsg(I))
		Case "crmax"
			ErrProv.SetError(txtcrmax, ErrorMsg(I))
		Case "crmin"
			ErrProv.SetError(TxTcrmin, ErrorMsg(I))
		Case Nothing
			Exit Sub
		End Select
	Next I
End Sub
Private Sub Txtcrperc_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtcrperc.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub txtcrmax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcrmax.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxTcrmin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxTcrmin.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
End Class






