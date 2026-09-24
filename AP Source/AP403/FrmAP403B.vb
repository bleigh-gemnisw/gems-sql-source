Public Class FrmAP403B
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
Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
Friend WithEvents GrpSorting As System.Windows.Forms.GroupBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TxtCheckNo As System.Windows.Forms.TextBox
Friend WithEvents DtPckCheck As System.Windows.Forms.DateTimePicker
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents RbSortNumber As System.Windows.Forms.RadioButton
Friend WithEvents LnkVendor As System.Windows.Forms.LinkLabel
Friend WithEvents TxtAltForm As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TxtBank As System.Windows.Forms.TextBox
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GrpSorting = New System.Windows.Forms.GroupBox()
    Me.RbSortNumber = New System.Windows.Forms.RadioButton()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
    Me.TxtCheckNo = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.DtPckCheck = New System.Windows.Forms.DateTimePicker()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtBank = New System.Windows.Forms.TextBox()
    Me.LnkVendor = New System.Windows.Forms.LinkLabel()
    Me.TxtAltForm = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpSorting.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GrpSorting
    '
    Me.GrpSorting.Controls.Add(Me.RbSortNumber)
    Me.GrpSorting.Controls.Add(Me.RbSortName)
    Me.GrpSorting.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpSorting.ForeColor = System.Drawing.Color.Maroon
    Me.GrpSorting.Location = New System.Drawing.Point(261, 12)
    Me.GrpSorting.Name = "GrpSorting"
    Me.GrpSorting.Size = New System.Drawing.Size(128, 75)
    Me.GrpSorting.TabIndex = 5
    Me.GrpSorting.TabStop = False
    Me.GrpSorting.Text = "Sort Order"
    '
    'RbSortNumber
    '
    Me.RbSortNumber.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortNumber.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbSortNumber.Location = New System.Drawing.Point(6, 45)
    Me.RbSortNumber.Name = "RbSortNumber"
    Me.RbSortNumber.Size = New System.Drawing.Size(108, 20)
    Me.RbSortNumber.TabIndex = 2
    Me.RbSortNumber.Text = "Vendor Number"
    '
    'RbSortName
    '
    Me.RbSortName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortName.Checked = True
    Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortName.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbSortName.Location = New System.Drawing.Point(6, 21)
    Me.RbSortName.Name = "RbSortName"
    Me.RbSortName.Size = New System.Drawing.Size(108, 20)
    Me.RbSortName.TabIndex = 1
    Me.RbSortName.TabStop = True
    Me.RbSortName.Text = "Vendor Name"
    '
    'TxtCheckNo
    '
    Me.TxtCheckNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCheckNo.Location = New System.Drawing.Point(146, 44)
    Me.TxtCheckNo.MaxLength = 7
    Me.TxtCheckNo.Name = "TxtCheckNo"
    Me.TxtCheckNo.Size = New System.Drawing.Size(63, 22)
    Me.TxtCheckNo.TabIndex = 1
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(22, 48)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(129, 18)
    Me.Label3.TabIndex = 52
    Me.Label3.Text = "Starting Check Number"
    '
    'DtPckCheck
    '
    Me.DtPckCheck.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckCheck.Location = New System.Drawing.Point(125, 12)
    Me.DtPckCheck.Name = "DtPckCheck"
    Me.DtPckCheck.Size = New System.Drawing.Size(96, 20)
    Me.DtPckCheck.TabIndex = 0
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(17, 16)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(72, 16)
    Me.Label4.TabIndex = 73
    Me.Label4.Text = "Check Date"
    '
    'TxtBank
    '
    Me.TxtBank.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBank.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBank.Location = New System.Drawing.Point(146, 72)
    Me.TxtBank.MaxLength = 5
    Me.TxtBank.Name = "TxtBank"
    Me.TxtBank.Size = New System.Drawing.Size(47, 22)
    Me.TxtBank.TabIndex = 2
    '
    'LnkVendor
    '
    Me.LnkVendor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkVendor.ForeColor = System.Drawing.Color.Maroon
    Me.LnkVendor.Location = New System.Drawing.Point(22, 77)
    Me.LnkVendor.Name = "LnkVendor"
    Me.LnkVendor.Size = New System.Drawing.Size(87, 17)
    Me.LnkVendor.TabIndex = 74
    Me.LnkVendor.TabStop = True
    Me.LnkVendor.Text = "Bank Account"
    '
    'TxtAltForm
    '
    Me.TxtAltForm.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAltForm.Location = New System.Drawing.Point(146, 100)
    Me.TxtAltForm.MaxLength = 5
    Me.TxtAltForm.Name = "TxtAltForm"
    Me.TxtAltForm.Size = New System.Drawing.Size(47, 22)
    Me.TxtAltForm.TabIndex = 75
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(22, 104)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(117, 13)
    Me.Label1.TabIndex = 76
    Me.Label1.Text = "Alternative Check Form"
    '
    'FrmAP403B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(404, 131)
    Me.ControlBox = False
    Me.Controls.Add(Me.TxtAltForm)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LnkVendor)
    Me.Controls.Add(Me.TxtBank)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.DtPckCheck)
    Me.Controls.Add(Me.TxtCheckNo)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.GrpSorting)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmAP403B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpSorting.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region
  Dim MyAPEHSTL1 As APEHSTL1.MyData

  Public Sub RunReport()
		Dim ErrorField(25) As String
		Dim ErrorMsg(25) As String

    myAPEHSTL1 = New APEHSTL1.MyData()
    MyAPEHSTL1.MyDBConn = myDBConnect

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
Private Sub FrmAP403B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmAP403.SbpScreen.Text = "AP403B"
End Sub
Private Sub FrmAP403B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
	Me.Refresh()
End Sub
	Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer
    ErrProv.SetError(TxtAltForm, "")
    ErrProv.SetError(TxtCheckNo, "")
		ErrProv.SetError(TxtBank, "")

		For I = 0 To ErrorField.GetUpperBound(0)
			Select Case ErrorField(I)
      Case "altid"
        ErrProv.SetError(TxtAltForm, ErrorMsg(I))
      Case "check"
        ErrProv.SetError(TxtCheckNo, ErrorMsg(I))
			Case "bank"
				ErrProv.SetError(TxtBank, ErrorMsg(I))
			Case Nothing
				Exit Sub
			End Select
		Next I
	End Sub
	Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim WrkBankName As String
    Dim Found As Boolean
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next

    If MyUtils.CnvSng(TxtCheckNo.Text) = 0 Then
      ErrorField(I) = "check"
      ErrorMsg(I) = "Check number is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtCheckNo.Text) > 0 Then
      Found = MyAPEHSTL1.IsCheckUsed(TxtBank.Text, TxtCheckNo.Text, MyUtils.SetDBDate(Date.Today))
      If Found Then
        ErrorField(I) = "check"
        ErrorMsg(I) = "Check number has been used"
        I = I + 1
      End If
    End If

    WrkBankName = GetAPEBNKName(TxtBank.Text)
    If WrkBankName = "" Or Mid(WrkBankName, 1, 3) = "***" Then
			ErrorField(I) = "bank"
			ErrorMsg(I) = "Invalid Bank code"
			I = I + 1
		End If

    If Mid(TxtBank.Text, 1, 2) = "PR" Then
      ErrorField(I) = "bank"
      ErrorMsg(I) = "Cannot use P/R Bank code"
      I = I + 1
    End If

    'If TxtAltForm.Text <> "" Then
    '  WrkRptFile = MyUtils.GetReportPath("PrtAPLECHK_" & TxtAltForm.Text, myTOWN._TOWNBR)
    '  If Not MyUtils.CheckFileExists(WrkRptFile) Then
    '    ErrorField(I) = "altid"
    '    ErrorMsg(I) = "Invalid Alternative Form ID"
    '    I = I + 1
    '  End If
    'End If
End Sub
Private Sub TxtYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCheckNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub FrmAP403B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyCheckType = "R"
    If MyManualManCheck Then
      MyFrmAP403.TBarManual.Visible = True
    Else
      MyFrmAP403.TBarManual.Visible = False
    End If
  End Sub
Private Sub LnkVendor_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkVendor.LinkClicked
	MyFrmListApebnk = New FrmListApebnk
	MyFrmListApebnk.MdiParent = Me.ParentForm
	MyFrmListApebnk.WrkCode = TxtBank.Text
	MyFrmListApebnk.Show()

End Sub
End Class
