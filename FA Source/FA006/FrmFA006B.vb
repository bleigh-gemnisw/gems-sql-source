Public Class FrmFA006B
  Inherits System.Windows.Forms.Form
  Dim myFACNTL As FACNTL.myData
 Friend WithEvents Label2 As System.Windows.Forms.Label
 Friend WithEvents DtPckAsof As System.Windows.Forms.DateTimePicker
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
Friend WithEvents TxtThreshold As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.label3 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtThreshold = New System.Windows.Forms.TextBox()
    Me.DtPckAsof = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
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
    Me.Label1.Location = New System.Drawing.Point(58, 37)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(85, 18)
    Me.Label1.TabIndex = 7
    Me.Label1.Text = "Depr Threshold"
    '
    'TxtThreshold
    '
    Me.TxtThreshold.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtThreshold.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtThreshold.Location = New System.Drawing.Point(149, 33)
    Me.TxtThreshold.MaxLength = 7
    Me.TxtThreshold.Name = "TxtThreshold"
    Me.TxtThreshold.Size = New System.Drawing.Size(68, 22)
    Me.TxtThreshold.TabIndex = 1
    '
    'DtPckAsof
    '
    Me.DtPckAsof.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckAsof.Location = New System.Drawing.Point(129, 61)
    Me.DtPckAsof.Name = "DtPckAsof"
    Me.DtPckAsof.Size = New System.Drawing.Size(88, 20)
    Me.DtPckAsof.TabIndex = 8
    Me.DtPckAsof.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(58, 63)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(61, 18)
    Me.Label2.TabIndex = 9
    Me.Label2.Text = "Depr Asof"
    '
    'FrmFA006B
    '
    Me.AllowDrop = True
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(264, 98)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.DtPckAsof)
    Me.Controls.Add(Me.TxtThreshold)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmFA006B"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

  Private Sub FA006B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myFACNTL = New FACNTL.MyData()
    myFACNTL.MyDBConn = myDBConnect
    MyFrmFA006.TBarNew.Visible = False
    MyFrmFA006.TBarSave.Visible = True
    MyFrmFA006.TBarPrint.Visible = False
    MyFrmFA006.TBarDelete.Visible = False
    myFACNTL.GetOneRecordP("A")
    If myFACNTL.RecordNotFound Then Exit Sub
    If s_chg = False And s_full = False Then    '#sec
      MyFrmFA006.TBarSave.Visible = False
    End If
    With myFACNTL
      TxtThreshold.Text = ._FCTHLD
      DtPckAsof.Value = MyUtils.GetDBDate(._FCASOF)
    End With
  End Sub
  Private Sub FA006B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmFA006.SbpScreen.Text = "FA006B"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Public Sub SaveData()
	Dim ErrorField(25) As String
	Dim ErrorMsg(25) As String
  myFACNTL.GetOneRecordP("A")
	If Not myFACNTL.RecordNotFound Then
		MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
			myFACNTL.UpdateOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If
	Else
		MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
      myFACNTL._FCKEY = "A"
      myFACNTL.AddOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If
	End If
	Me.Close()
End Sub
Private Sub MovetoFile()
	With myFACNTL
    ._FCTHLD = MyUtils.CnvSng(TxtThreshold.Text)
    ._FCASOF = MyUtils.SetDBDate(DtPckAsof.Value)
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
	For I = 0 To ErrorField.GetUpperBound(0)
		Select Case ErrorField(I)
		End Select
	Next I
End Sub
Private Sub TxtThreshold_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtThreshold.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class
