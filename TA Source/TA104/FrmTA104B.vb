Public Class FrmTA104B
  Inherits System.Windows.Forms.Form
	Dim myTXMCTL As TXMCTL.myData
	Friend WrkValper As String
  Friend WrkValmin As String
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
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtValper As System.Windows.Forms.TextBox
Friend WithEvents TxtValmin As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.label3 = New System.Windows.Forms.Label
Me.Label1 = New System.Windows.Forms.Label
Me.Label2 = New System.Windows.Forms.Label
Me.TxtValper = New System.Windows.Forms.TextBox
Me.TxtValmin = New System.Windows.Forms.TextBox
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
Me.label3.Size = New System.Drawing.Size(98, 23)
Me.label3.TabIndex = 6
Me.label3.Text = "New file name"
Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(12, 12)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(84, 16)
Me.Label1.TabIndex = 7
Me.Label1.Text = "Value Percent"
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(12, 40)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(84, 16)
Me.Label2.TabIndex = 8
Me.Label2.Text = "Minimum Value"
'
'TxtValper
'
Me.TxtValper.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtValper.Location = New System.Drawing.Point(96, 8)
Me.TxtValper.MaxLength = 3
Me.TxtValper.Name = "TxtValper"
Me.TxtValper.Size = New System.Drawing.Size(48, 20)
Me.TxtValper.TabIndex = 1
'
'TxtValmin
'
Me.TxtValmin.Location = New System.Drawing.Point(96, 36)
Me.TxtValmin.MaxLength = 7
Me.TxtValmin.Name = "TxtValmin"
Me.TxtValmin.Size = New System.Drawing.Size(48, 20)
Me.TxtValmin.TabIndex = 2
'
'FrmTA104B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(160, 66)
Me.Controls.Add(Me.TxtValmin)
Me.Controls.Add(Me.TxtValper)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.label3)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA104B"
Me.Text = "NADA Book Value"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub TA104B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	myTXMCTL = New TXMCTL.mydata(MyDBConnect)
  MyFrmTA104.TBarNew.Visible = False
  MyFrmTA104.TBarSave.Visible = True
  MyFrmTA104.TBarPrint.Visible = False
  MyFrmTA104.TBarDelete.Visible = False
	myTXMCTL.GetOneRecordP(1)
	If myTXMCTL.RecordNotFound Then Exit Sub

  If s_chg = False And s_full = False Then    '#sec
    MyFrmTA104.TBarSave.Visible = False
  End If
	With myTXMCTL
		TxtValper.Text = ._VALPER
		TxtValmin.Text = ._VALMIN
	End With
End Sub
Private Sub TA104B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA104.SbpScreen.Text = "TA104B"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Public Sub SaveData()
	Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String

	myTXMCTL.GetOneRecordP(1)
	MovetoFile()
	EditChecks(ErrorField, ErrorMsg)
  If IsNothing(ErrorMsg(0)) Then
		If myTXMCTL.RecordNotFound Then
			myTXMCTL.AddOneRecordP()
		Else
			myTXMCTL.UpdateOneRecordP()
		End If
  Else
    ShowError(ErrorField, ErrorMsg)
    Exit Sub
  End If
  MsgBox("Changes Saved", MsgBoxStyle.Information, "NADA Book Value")
  Me.Close()
  End Sub
Private Sub MovetoFile()
	With myTXMCTL
		._VALPER = TxtValper.Text
    ._VALMIN = MyUtils.CnvSng(TxtValmin.Text)
	End With
End Sub
Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer

		For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next

    If MyUtils.CnvSng(TxtValper.Text) = 0 Then
      ErrorField(I) = "valper"
      ErrorMsg(I) = "Percentage cannot be zero"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtValmin.Text) = 0 Then
      ErrorField(I) = "valmin"
      ErrorMsg(I) = "Minimum Value cannot be zero"
      I = I + 1
    End If
End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
	Dim I As Integer
	ErrProv.SetError(TxtValper, "")
	ErrProv.SetError(TxtValmin, "")
	For I = 0 To ErrorField.GetUpperBound(0)
		 Select Case ErrorField(I)
		 Case "valper"
			 ErrProv.SetError(TxtValper, ErrorMsg(I))
		 Case "valmin"
			 ErrProv.SetError(TxtValmin, ErrorMsg(I))
		 Case Nothing
			 Exit Sub
		 End Select
	 Next I
End Sub
Private Sub TxtValper_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtValper.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtValmin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtValmin.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






