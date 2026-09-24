Public Class FrmTX114B
	Inherits System.Windows.Forms.Form
	Dim myTXMVFEE As TXMVFEE.myData
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
Friend WithEvents TxtAmount As System.Windows.Forms.TextBox
Friend WithEvents Label12 As System.Windows.Forms.Label
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.label3 = New System.Windows.Forms.Label
Me.TxtAmount = New System.Windows.Forms.TextBox
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
'TxtAmount
'
Me.TxtAmount.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtAmount.Location = New System.Drawing.Point(87, 31)
Me.TxtAmount.MaxLength = 6
Me.TxtAmount.Name = "TxtAmount"
Me.TxtAmount.Size = New System.Drawing.Size(55, 22)
Me.TxtAmount.TabIndex = 26
Me.TxtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label12
'
Me.Label12.Location = New System.Drawing.Point(30, 35)
Me.Label12.Name = "Label12"
Me.Label12.Size = New System.Drawing.Size(51, 18)
Me.Label12.TabIndex = 27
Me.Label12.Text = "Amount"
'
'FrmTX114B
'
Me.AllowDrop = True
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(202, 89)
Me.ControlBox = False
Me.Controls.Add(Me.TxtAmount)
Me.Controls.Add(Me.Label12)
Me.Controls.Add(Me.label3)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX114B"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub TX114B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXMVFEE = New TXMVFEE.MyData(myDBConnect)
    With MyFrmTX114
		.TBarNew.Visible = False
		.TBarSave.Visible = True
		.TBarPrint.Visible = False
		.TBarDelete.Visible = False
	End With
	If s_chg = False And s_full = False Then		'#sec
		MyFrmTX114.TBarSave.Visible = False
	End If

	myTXMVFEE.GetOneRecordP(1)
	If myTXMVFEE.RecordNotFound Then Exit Sub
	With myTXMVFEE
		TxtAmount.Text = Format(._MVFEE, "fixed")
	End With
End Sub
Private Sub TX114B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmTX114.SbpScreen.Text = "TX114B"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Public Sub SaveData()
	Dim ErrorField(25) As String
	Dim ErrorMsg(25) As String
	myTXMVFEE.GetOneRecordP(1)
	MovetoFile()
	EditChecks(ErrorField, ErrorMsg)
	If IsNothing(ErrorMsg(0)) Then
		If myTXMVFEE.RecordNotFound Then
			myTXMVFEE.AddOneRecordP()
		Else
			myTXMVFEE.UpdateOneRecordP()
		End If
	Else
		ShowError(ErrorField, ErrorMsg)
		Exit Sub
	End If
	End
	End Sub
Private Sub MovetoFile()
	With myTXMVFEE
    ._MVFEE = MyUtils.CnvSng(TxtAmount.Text)
	End With
End Sub
	Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer

		For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next

    If MyUtils.CnvSng(TxtAmount.Text) >= 1000 Then
      ErrorField(I) = "amount"
      ErrorMsg(I) = "Maximum Amount is 999.99"
      I = I + 1
    End If
	End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
	Dim I As Integer
	ErrProv.SetError(TxtAmount, "")
	For I = 0 To ErrorField.GetUpperBound(0)
		 Select Case ErrorField(I)
			 Case "amount"
				 ErrProv.SetError(TxtAmount, ErrorMsg(I))
			 Case Nothing
				 Exit Sub
		 End Select
		 Next I
End Sub
Private Sub TxtAmount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAmount.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
End Class
