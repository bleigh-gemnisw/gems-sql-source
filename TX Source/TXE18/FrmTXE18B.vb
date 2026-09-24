Public Class FrmTXE18B
Inherits System.Windows.Forms.Form
Dim ds As DataSet = New DataSet

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
  Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents TxtToCode As System.Windows.Forms.TextBox
Friend WithEvents LnkToCode As System.Windows.Forms.LinkLabel
Friend WithEvents TxtFromCode As System.Windows.Forms.TextBox
Friend WithEvents LnkFromCode As System.Windows.Forms.LinkLabel
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents ChkDetail As System.Windows.Forms.CheckBox
Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.DtPckFrom = New System.Windows.Forms.DateTimePicker
Me.DtPckTo = New System.Windows.Forms.DateTimePicker
Me.Label2 = New System.Windows.Forms.Label
Me.TxtTypes = New System.Windows.Forms.TextBox
Me.LnkTypes = New System.Windows.Forms.LinkLabel
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.TxtToCode = New System.Windows.Forms.TextBox
Me.LnkToCode = New System.Windows.Forms.LinkLabel
Me.TxtFromCode = New System.Windows.Forms.TextBox
Me.LnkFromCode = New System.Windows.Forms.LinkLabel
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ChkDetail = New System.Windows.Forms.CheckBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox1.SuspendLayout()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(32, 12)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(60, 16)
Me.Label1.TabIndex = 0
Me.Label1.Text = "From Date"
'
'DtPckFrom
'
Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckFrom.Location = New System.Drawing.Point(92, 8)
Me.DtPckFrom.Name = "DtPckFrom"
Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
Me.DtPckFrom.TabIndex = 0
'
'DtPckTo
'
Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckTo.Location = New System.Drawing.Point(252, 8)
Me.DtPckTo.Name = "DtPckTo"
Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
Me.DtPckTo.TabIndex = 1
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(200, 12)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(52, 16)
Me.Label2.TabIndex = 5
Me.Label2.Text = "To Date"
'
'TxtTypes
'
Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtTypes.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtTypes.Location = New System.Drawing.Point(122, 116)
Me.TxtTypes.MaxLength = 20
Me.TxtTypes.Name = "TxtTypes"
Me.TxtTypes.Size = New System.Drawing.Size(148, 20)
Me.TxtTypes.TabIndex = 3
'
'LnkTypes
'
Me.LnkTypes.Location = New System.Drawing.Point(36, 119)
Me.LnkTypes.Name = "LnkTypes"
Me.LnkTypes.Size = New System.Drawing.Size(80, 16)
Me.LnkTypes.TabIndex = 35
Me.LnkTypes.TabStop = True
Me.LnkTypes.Text = "Types to print"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.TxtToCode)
Me.GroupBox1.Controls.Add(Me.LnkToCode)
Me.GroupBox1.Controls.Add(Me.TxtFromCode)
Me.GroupBox1.Controls.Add(Me.LnkFromCode)
Me.GroupBox1.Location = New System.Drawing.Point(35, 45)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(305, 53)
Me.GroupBox1.TabIndex = 2
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "Fee Codes (optional)"
'
'TxtToCode
'
Me.TxtToCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtToCode.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtToCode.Location = New System.Drawing.Point(241, 24)
Me.TxtToCode.MaxLength = 2
Me.TxtToCode.Name = "TxtToCode"
Me.TxtToCode.Size = New System.Drawing.Size(22, 20)
Me.TxtToCode.TabIndex = 1
'
'LnkToCode
'
Me.LnkToCode.Location = New System.Drawing.Point(165, 27)
Me.LnkToCode.Name = "LnkToCode"
Me.LnkToCode.Size = New System.Drawing.Size(70, 17)
Me.LnkToCode.TabIndex = 41
Me.LnkToCode.TabStop = True
Me.LnkToCode.Text = "To Code"
'
'TxtFromCode
'
Me.TxtFromCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtFromCode.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFromCode.Location = New System.Drawing.Point(87, 24)
Me.TxtFromCode.MaxLength = 2
Me.TxtFromCode.Name = "TxtFromCode"
Me.TxtFromCode.Size = New System.Drawing.Size(22, 20)
Me.TxtFromCode.TabIndex = 0
'
'LnkFromCode
'
Me.LnkFromCode.Location = New System.Drawing.Point(11, 27)
Me.LnkFromCode.Name = "LnkFromCode"
Me.LnkFromCode.Size = New System.Drawing.Size(70, 17)
Me.LnkFromCode.TabIndex = 39
Me.LnkFromCode.TabStop = True
Me.LnkFromCode.Text = "From Code"
'
'ChkDetail
'
Me.ChkDetail.AutoSize = True
Me.ChkDetail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkDetail.Location = New System.Drawing.Point(39, 144)
Me.ChkDetail.Name = "ChkDetail"
Me.ChkDetail.Size = New System.Drawing.Size(132, 17)
Me.ChkDetail.TabIndex = 36
Me.ChkDetail.Text = "Include Detail Report?"
Me.ChkDetail.UseVisualStyleBackColor = True
'
'FrmTXE18B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(352, 173)
Me.ControlBox = False
Me.Controls.Add(Me.ChkDetail)
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.TxtTypes)
Me.Controls.Add(Me.LnkTypes)
Me.Controls.Add(Me.DtPckTo)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.DtPckFrom)
Me.Controls.Add(Me.Label1)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTXE18B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox1.ResumeLayout(False)
Me.GroupBox1.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTXE18B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmTXE18.SbpScreen.Text = "TXE18"
End Sub
Private Sub FrmTXE18B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
	Me.Refresh()
End Sub
	Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer
		ErrProv.SetError(DtPckFrom, "")
		ErrProv.SetError(DtPckTo, "")
		ErrProv.SetError(TxtTypes, "")

		For I = 0 To ErrorField.GetUpperBound(0)
			Select Case ErrorField(I)
			Case "from"
				ErrProv.SetError(DtPckFrom, ErrorMsg(I))
			Case "to"
				ErrProv.SetError(DtPckTo, ErrorMsg(I))
			Case "type"
				ErrProv.SetError(TxtTypes, ErrorMsg(I))
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

		If DtPckFrom.Value.Date > DtPckTo.Value.Date Then
			ErrorField(I) = "from"
			ErrorMsg(I) = "Invalid Date Range"
			I = I + 1
			ErrorField(I) = "to"
			ErrorMsg(I) = "Invalid Date Range"
			I = I + 1
		End If

	End Sub

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
Private Sub FrmTXE18B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	MyTypes = ""
End Sub
Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
	MyTypes = TxtTypes.Text
	MyFrmSelTypes = New FrmSelTypes
	MyFrmSelTypes.MdiParent = Me.ParentForm
	MyFrmSelTypes.Show()
	Me.Hide()

End Sub
Private Sub LnkFromCode_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFromCode.LinkClicked
	MyFrmListPenCd = New FrmListPenCd
	MyFrmListPenCd.MdiParent = Me.ParentForm
	MyFrmListPenCd.WrkCode = TxtFromCode.Text
	MyFrmListPenCd.WrkField = "From"
	MyFrmListPenCd.Show()
	Me.Hide()
End Sub
Private Sub LnkToCode_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkToCode.LinkClicked
	MyFrmListPenCd = New FrmListPenCd
	MyFrmListPenCd.MdiParent = Me.ParentForm
	MyFrmListPenCd.WrkCode = TxtToCode.Text
	MyFrmListPenCd.WrkField = "To"
	MyFrmListPenCd.Show()
	Me.Hide()
End Sub
End Class






