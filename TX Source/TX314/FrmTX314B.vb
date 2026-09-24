Public Class FrmTX314B
Inherits System.Windows.Forms.Form

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
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
Friend WithEvents GrpFiles As System.Windows.Forms.GroupBox
Friend WithEvents LnkFile As System.Windows.Forms.LinkLabel
Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents LnkCode As System.Windows.Forms.LinkLabel
Friend WithEvents TxtCode As System.Windows.Forms.TextBox
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbSortList As System.Windows.Forms.RadioButton
Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TxtToGLYear As System.Windows.Forms.TextBox
Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents LblFile As System.Windows.Forms.Label
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.GrpFiles = New System.Windows.Forms.GroupBox()
    Me.LblFile = New System.Windows.Forms.Label()
    Me.LnkFile = New System.Windows.Forms.LinkLabel()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.LnkCode = New System.Windows.Forms.LinkLabel()
    Me.TxtCode = New System.Windows.Forms.TextBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbSortList = New System.Windows.Forms.RadioButton()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtToGLYear = New System.Windows.Forms.TextBox()
    Me.TxtFromGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpFiles.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GrpFiles
    '
    Me.GrpFiles.Controls.Add(Me.LblFile)
    Me.GrpFiles.Controls.Add(Me.LnkFile)
    Me.GrpFiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpFiles.Location = New System.Drawing.Point(23, 162)
    Me.GrpFiles.Name = "GrpFiles"
    Me.GrpFiles.Size = New System.Drawing.Size(429, 52)
    Me.GrpFiles.TabIndex = 5
    Me.GrpFiles.TabStop = False
    Me.GrpFiles.Text = "File Details"
    '
    'LblFile
    '
    Me.LblFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFile.Location = New System.Drawing.Point(70, 24)
    Me.LblFile.Name = "LblFile"
    Me.LblFile.Size = New System.Drawing.Size(324, 16)
    Me.LblFile.TabIndex = 1
    '
    'LnkFile
    '
    Me.LnkFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFile.Location = New System.Drawing.Point(12, 24)
    Me.LnkFile.Name = "LnkFile"
    Me.LnkFile.Size = New System.Drawing.Size(52, 16)
    Me.LnkFile.TabIndex = 0
    Me.LnkFile.TabStop = True
    Me.LnkFile.Text = "File Path"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.DtPckTo)
    Me.GroupBox3.Controls.Add(Me.Label2)
    Me.GroupBox3.Controls.Add(Me.DtPckFrom)
    Me.GroupBox3.Controls.Add(Me.Label1)
    Me.GroupBox3.Location = New System.Drawing.Point(23, 47)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(296, 52)
    Me.GroupBox3.TabIndex = 2
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Date Range"
    '
    'DtPckTo
    '
    Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTo.Location = New System.Drawing.Point(196, 20)
    Me.DtPckTo.Name = "DtPckTo"
    Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
    Me.DtPckTo.TabIndex = 1
    Me.DtPckTo.Value = New Date(2005, 10, 6, 9, 11, 0, 906)
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(164, 24)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(28, 16)
    Me.Label2.TabIndex = 9
    Me.Label2.Text = "To "
    '
    'DtPckFrom
    '
    Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFrom.Location = New System.Drawing.Point(52, 20)
    Me.DtPckFrom.Name = "DtPckFrom"
    Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
    Me.DtPckFrom.TabIndex = 0
    Me.DtPckFrom.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(12, 20)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(36, 16)
    Me.Label1.TabIndex = 7
    Me.Label1.Text = "From"
    '
    'LnkCode
    '
    Me.LnkCode.Location = New System.Drawing.Point(31, 117)
    Me.LnkCode.Name = "LnkCode"
    Me.LnkCode.Size = New System.Drawing.Size(72, 16)
    Me.LnkCode.TabIndex = 3
    Me.LnkCode.TabStop = True
    Me.LnkCode.Text = "Status Code"
    '
    'TxtCode
    '
    Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCode.Location = New System.Drawing.Point(106, 113)
    Me.TxtCode.MaxLength = 1
    Me.TxtCode.Name = "TxtCode"
    Me.TxtCode.Size = New System.Drawing.Size(17, 20)
    Me.TxtCode.TabIndex = 4
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbSortList)
    Me.GroupBox2.Controls.Add(Me.RbSortName)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(328, 12)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(127, 63)
    Me.GroupBox2.TabIndex = 52
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Sort Options"
    '
    'RbSortList
    '
    Me.RbSortList.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortList.Location = New System.Drawing.Point(6, 35)
    Me.RbSortList.Name = "RbSortList"
    Me.RbSortList.Size = New System.Drawing.Size(115, 20)
    Me.RbSortList.TabIndex = 2
    Me.RbSortList.Text = "Year/Type/List #"
    '
    'RbSortName
    '
    Me.RbSortName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortName.Checked = True
    Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortName.Location = New System.Drawing.Point(6, 19)
    Me.RbSortName.Name = "RbSortName"
    Me.RbSortName.Size = New System.Drawing.Size(115, 20)
    Me.RbSortName.TabIndex = 1
    Me.RbSortName.TabStop = True
    Me.RbSortName.Text = "Year/Type/Name"
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(152, 22)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(20, 16)
    Me.Label3.TabIndex = 56
    Me.Label3.Text = "To "
    '
    'TxtToGLYear
    '
    Me.TxtToGLYear.Location = New System.Drawing.Point(180, 18)
    Me.TxtToGLYear.MaxLength = 4
    Me.TxtToGLYear.Name = "TxtToGLYear"
    Me.TxtToGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtToGLYear.TabIndex = 1
    '
    'TxtFromGLYear
    '
    Me.TxtFromGLYear.Location = New System.Drawing.Point(116, 18)
    Me.TxtFromGLYear.MaxLength = 4
    Me.TxtFromGLYear.Name = "TxtFromGLYear"
    Me.TxtFromGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtFromGLYear.TabIndex = 0
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(20, 18)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(84, 16)
    Me.Label4.TabIndex = 55
    Me.Label4.Text = "Grand List Year"
    '
    'FrmTX314B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(467, 229)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtToGLYear)
    Me.Controls.Add(Me.TxtFromGLYear)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.LnkCode)
    Me.Controls.Add(Me.TxtCode)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.GrpFiles)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX314B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpFiles.ResumeLayout(False)
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

	Public Sub RunReport()
		Dim ErrorField(25) As String
		Dim ErrorMsg(25) As String

		Array.Clear(ErrorField, 0, 25)
		Array.Clear(ErrorMsg, 0, 25)

		EditChecks(ErrorField, ErrorMsg)
		ShowError(ErrorField, ErrorMsg)
		If Not IsNothing(ErrorMsg(0)) Then
			Exit Sub
		End If

		Me.Refresh()
		Windows.Forms.Cursor.Current = Cursors.WaitCursor
		PrtReport()
		Windows.Forms.Cursor.Current = Cursors.Default

	End Sub
Private Sub FrmTX314B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		MyFrmTX314.SbpPgmID.Text = "TX314B"
		MyFrmTX314.SbpEnvironment.Text = myDBConnect.PgmDB
		DtPckFrom.Value = Date.Today
		DtPckTo.Value = Date.Today
    LblFile.Text = MyUtils.GetDataPath() & "TXDELPAY.TXT"
End Sub
Private Sub FrmTX314B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmTX314.SbpScreen.Text = "TX314B"
End Sub
Private Sub FrmTX314B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
	Me.Refresh()
End Sub
	Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer
    ErrProv.SetError(TxtFromGLYear, "")
    ErrProv.SetError(TxtToGLYear, "")
    ErrProv.SetError(TxtCode, "")
		ErrProv.SetError(DtPckFrom, "")
		ErrProv.SetError(DtPckTo, "")

		For I = 0 To ErrorField.GetUpperBound(0)
			Select Case ErrorField(I)
      Case "fromglyear"
        ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
      Case "fromglyear"
        ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
      Case "code"
        ErrProv.SetError(TxtCode, ErrorMsg(I))
			Case "from"
				ErrProv.SetError(DtPckFrom, ErrorMsg(I))
			Case "to"
				ErrProv.SetError(DtPckTo, ErrorMsg(I))
			Case Nothing
				Exit Sub
			End Select
		Next I
	End Sub
	Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer

		For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next

    If MyUtils.CnvSng(TxtFromGLYear.Text) = 0 Then
      ErrorField(I) = "fromglyear"
      ErrorMsg(I) = "Invalid From GL Year"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtToGLYear.Text) = 0 Then
      ErrorField(I) = "toglyear"
      ErrorMsg(I) = "Invalid To GL Year"
      I = I + 1
    End If

    If TxtCode.Text = "" Then
      ErrorField(I) = "code"
      ErrorMsg(I) = "Status Code is required"
      I = I + 1
    End If

    If MyUtils.SetDBDate(DtPckFrom.Value) > MyUtils.SetDBDate(DtPckTo.Value) Then
      ErrorField(I) = "to"
      ErrorMsg(I) = "Invalid date Range"
      I = I + 1
    End If
 End Sub
Private Sub FrmTX314B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
	If Not e.Alt Then Exit Sub

	 If e.KeyCode = Keys.F12 Then
     MyUtils.PrtScreen(Form.ActiveForm)
	 End If
End Sub

Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFile.LinkClicked
	With SaveFileDialog1
		.ShowDialog()
		LblFile.Text = .FileName
	End With
End Sub
Private Sub TxtFromGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtToGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub LnkCode_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode.LinkClicked
  MyFrmListSts = New FrmListSts
  MyFrmListSts.WrkCode = TxtCode.Text
  MyFrmListSts.MdiParent = Me.ParentForm
  MyFrmListSts.Show()
End Sub
End Class






