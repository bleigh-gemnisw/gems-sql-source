Public Class FrmTX904B
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
Friend WithEvents ChkPrev As System.Windows.Forms.CheckBox
Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
Friend WithEvents TxtGLFromYear As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
Friend WithEvents TxtGLToYear As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TxtStatus As System.Windows.Forms.TextBox
Friend WithEvents LinkStatus As System.Windows.Forms.LinkLabel
Friend WithEvents txtsresn As System.Windows.Forms.TextBox
Friend WithEvents Linksresn As System.Windows.Forms.LinkLabel
Friend WithEvents GroupSusdt As System.Windows.Forms.GroupBox
Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents CHKSusdt As System.Windows.Forms.CheckBox
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents DtPckInt As System.Windows.Forms.DateTimePicker
Friend WithEvents CHKPOSTINV As System.Windows.Forms.CheckBox
Friend WithEvents ChkDOB As System.Windows.Forms.CheckBox
Friend WithEvents ChkOmitStatus As System.Windows.Forms.CheckBox
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents ChkDOBModel As System.Windows.Forms.CheckBox
Friend WithEvents LblFilePath As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.ChkPrev = New System.Windows.Forms.CheckBox
Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.LblFilePath = New System.Windows.Forms.Label
Me.LnkFilePath = New System.Windows.Forms.LinkLabel
Me.TxtGLFromYear = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.LnkTypes = New System.Windows.Forms.LinkLabel
Me.TxtTypes = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.TxtGLToYear = New System.Windows.Forms.TextBox
Me.TxtStatus = New System.Windows.Forms.TextBox
Me.LinkStatus = New System.Windows.Forms.LinkLabel
Me.txtsresn = New System.Windows.Forms.TextBox
Me.Linksresn = New System.Windows.Forms.LinkLabel
Me.GroupSusdt = New System.Windows.Forms.GroupBox
Me.DtPckTo = New System.Windows.Forms.DateTimePicker
Me.Label2 = New System.Windows.Forms.Label
Me.DtPckFrom = New System.Windows.Forms.DateTimePicker
Me.Label4 = New System.Windows.Forms.Label
Me.CHKSusdt = New System.Windows.Forms.CheckBox
Me.Label5 = New System.Windows.Forms.Label
Me.DtPckInt = New System.Windows.Forms.DateTimePicker
Me.CHKPOSTINV = New System.Windows.Forms.CheckBox
Me.ChkDOB = New System.Windows.Forms.CheckBox
Me.ChkOmitStatus = New System.Windows.Forms.CheckBox
Me.ChkDOBModel = New System.Windows.Forms.CheckBox
Me.Label6 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox1.SuspendLayout()
Me.GroupSusdt.SuspendLayout()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'ChkPrev
'
Me.ChkPrev.AutoSize = True
Me.ChkPrev.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkPrev.Location = New System.Drawing.Point(35, 142)
Me.ChkPrev.Name = "ChkPrev"
Me.ChkPrev.Size = New System.Drawing.Size(193, 17)
Me.ChkPrev.TabIndex = 6
Me.ChkPrev.Text = "Include previously marked records?"
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.LblFilePath)
Me.GroupBox1.Controls.Add(Me.LnkFilePath)
Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox1.Location = New System.Drawing.Point(21, 353)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(408, 72)
Me.GroupBox1.TabIndex = 13
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "Collection Agency File Details"
'
'LblFilePath
'
Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblFilePath.Location = New System.Drawing.Point(70, 24)
Me.LblFilePath.Name = "LblFilePath"
Me.LblFilePath.Size = New System.Drawing.Size(324, 36)
Me.LblFilePath.TabIndex = 67
'
'LnkFilePath
'
Me.LnkFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkFilePath.Location = New System.Drawing.Point(12, 24)
Me.LnkFilePath.Name = "LnkFilePath"
Me.LnkFilePath.Size = New System.Drawing.Size(52, 16)
Me.LnkFilePath.TabIndex = 8
Me.LnkFilePath.TabStop = True
Me.LnkFilePath.Text = "File Path"
'
'TxtGLFromYear
'
Me.TxtGLFromYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtGLFromYear.Location = New System.Drawing.Point(120, 41)
Me.TxtGLFromYear.MaxLength = 4
Me.TxtGLFromYear.Name = "TxtGLFromYear"
Me.TxtGLFromYear.Size = New System.Drawing.Size(32, 20)
Me.TxtGLFromYear.TabIndex = 1
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(32, 45)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(84, 16)
Me.Label3.TabIndex = 48
Me.Label3.Text = "Grand List Year"
'
'LnkTypes
'
Me.LnkTypes.AutoSize = True
Me.LnkTypes.Location = New System.Drawing.Point(32, 14)
Me.LnkTypes.Name = "LnkTypes"
Me.LnkTypes.Size = New System.Drawing.Size(69, 13)
Me.LnkTypes.TabIndex = 65
Me.LnkTypes.TabStop = True
Me.LnkTypes.Text = "Select Types"
'
'TxtTypes
'
Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtTypes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtTypes.Location = New System.Drawing.Point(119, 11)
Me.TxtTypes.MaxLength = 20
Me.TxtTypes.Name = "TxtTypes"
Me.TxtTypes.Size = New System.Drawing.Size(129, 20)
Me.TxtTypes.TabIndex = 0
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(158, 45)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(18, 16)
Me.Label1.TabIndex = 67
Me.Label1.Text = "to"
'
'TxtGLToYear
'
Me.TxtGLToYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtGLToYear.Location = New System.Drawing.Point(182, 41)
Me.TxtGLToYear.MaxLength = 4
Me.TxtGLToYear.Name = "TxtGLToYear"
Me.TxtGLToYear.Size = New System.Drawing.Size(32, 20)
Me.TxtGLToYear.TabIndex = 2
'
'TxtStatus
'
Me.TxtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtStatus.Location = New System.Drawing.Point(211, 112)
Me.TxtStatus.MaxLength = 20
Me.TxtStatus.Name = "TxtStatus"
Me.TxtStatus.Size = New System.Drawing.Size(129, 20)
Me.TxtStatus.TabIndex = 5
'
'LinkStatus
'
Me.LinkStatus.AutoSize = True
Me.LinkStatus.Location = New System.Drawing.Point(34, 112)
Me.LinkStatus.Name = "LinkStatus"
Me.LinkStatus.Size = New System.Drawing.Size(70, 13)
Me.LinkStatus.TabIndex = 69
Me.LinkStatus.TabStop = True
Me.LinkStatus.Text = "Status Codes"
'
'txtsresn
'
Me.txtsresn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtsresn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.txtsresn.Location = New System.Drawing.Point(211, 72)
Me.txtsresn.MaxLength = 20
Me.txtsresn.Name = "txtsresn"
Me.txtsresn.Size = New System.Drawing.Size(129, 20)
Me.txtsresn.TabIndex = 3
'
'Linksresn
'
Me.Linksresn.AutoSize = True
Me.Linksresn.Location = New System.Drawing.Point(34, 79)
Me.Linksresn.Name = "Linksresn"
Me.Linksresn.Size = New System.Drawing.Size(150, 13)
Me.Linksresn.TabIndex = 71
Me.Linksresn.TabStop = True
Me.Linksresn.Text = "Omit Suspense Reason codes"
'
'GroupSusdt
'
Me.GroupSusdt.Controls.Add(Me.DtPckTo)
Me.GroupSusdt.Controls.Add(Me.Label2)
Me.GroupSusdt.Controls.Add(Me.DtPckFrom)
Me.GroupSusdt.Controls.Add(Me.Label4)
Me.GroupSusdt.Location = New System.Drawing.Point(37, 227)
Me.GroupSusdt.Name = "GroupSusdt"
Me.GroupSusdt.Size = New System.Drawing.Size(300, 52)
Me.GroupSusdt.TabIndex = 9
Me.GroupSusdt.TabStop = False
Me.GroupSusdt.Text = "Suspense Date Range"
Me.GroupSusdt.Visible = False
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
Me.Label2.Location = New System.Drawing.Point(156, 24)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(28, 16)
Me.Label2.TabIndex = 9
Me.Label2.Text = "To "
'
'DtPckFrom
'
Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckFrom.Location = New System.Drawing.Point(52, 20)
Me.DtPckFrom.MinDate = New Date(1970, 1, 1, 0, 0, 0, 0)
Me.DtPckFrom.Name = "DtPckFrom"
Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
Me.DtPckFrom.TabIndex = 0
Me.DtPckFrom.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(12, 20)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(36, 16)
Me.Label4.TabIndex = 7
Me.Label4.Text = "From"
'
'CHKSusdt
'
Me.CHKSusdt.AutoSize = True
Me.CHKSusdt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.CHKSusdt.Location = New System.Drawing.Point(37, 203)
Me.CHKSusdt.Name = "CHKSusdt"
Me.CHKSusdt.Size = New System.Drawing.Size(129, 17)
Me.CHKSusdt.TabIndex = 8
Me.CHKSusdt.Text = "Filter Suspense Dates"
'
'Label5
'
Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label5.Location = New System.Drawing.Point(37, 177)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(72, 16)
Me.Label5.TabIndex = 185
Me.Label5.Text = "Interest Date"
'
'DtPckInt
'
Me.DtPckInt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckInt.Location = New System.Drawing.Point(133, 177)
Me.DtPckInt.Name = "DtPckInt"
Me.DtPckInt.Size = New System.Drawing.Size(88, 20)
Me.DtPckInt.TabIndex = 7
'
'CHKPOSTINV
'
Me.CHKPOSTINV.AutoSize = True
Me.CHKPOSTINV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.CHKPOSTINV.Checked = True
Me.CHKPOSTINV.CheckState = System.Windows.Forms.CheckState.Checked
Me.CHKPOSTINV.Location = New System.Drawing.Point(21, 297)
Me.CHKPOSTINV.Name = "CHKPOSTINV"
Me.CHKPOSTINV.Size = New System.Drawing.Size(150, 17)
Me.CHKPOSTINV.TabIndex = 10
Me.CHKPOSTINV.Text = "Flag records as being sent"
'
'ChkDOB
'
Me.ChkDOB.AutoSize = True
Me.ChkDOB.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkDOB.Location = New System.Drawing.Point(22, 321)
Me.ChkDOB.Name = "ChkDOB"
Me.ChkDOB.Size = New System.Drawing.Size(159, 17)
Me.ChkDOB.TabIndex = 11
Me.ChkDOB.Text = "Append Date of Birth to file?"
'
'ChkOmitStatus
'
Me.ChkOmitStatus.AutoSize = True
Me.ChkOmitStatus.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkOmitStatus.Location = New System.Drawing.Point(152, 115)
Me.ChkOmitStatus.Name = "ChkOmitStatus"
Me.ChkOmitStatus.Size = New System.Drawing.Size(53, 17)
Me.ChkOmitStatus.TabIndex = 4
Me.ChkOmitStatus.Text = "Omit?"
Me.ChkOmitStatus.UseVisualStyleBackColor = True
'
'ChkDOBModel
'
Me.ChkDOBModel.AutoSize = True
Me.ChkDOBModel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkDOBModel.Location = New System.Drawing.Point(222, 321)
Me.ChkDOBModel.Name = "ChkDOBModel"
Me.ChkDOBModel.Size = New System.Drawing.Size(193, 17)
Me.ChkDOBModel.TabIndex = 12
Me.ChkDOBModel.Text = "Append Date of Birth/Model to file?"
'
'Label6
'
Me.Label6.AutoSize = True
Me.Label6.Location = New System.Drawing.Point(193, 322)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(23, 13)
Me.Label6.TabIndex = 190
Me.Label6.Text = "OR"
'
'FrmTX904B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(462, 437)
Me.ControlBox = False
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.ChkDOBModel)
Me.Controls.Add(Me.ChkOmitStatus)
Me.Controls.Add(Me.ChkDOB)
Me.Controls.Add(Me.CHKPOSTINV)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.DtPckInt)
Me.Controls.Add(Me.CHKSusdt)
Me.Controls.Add(Me.GroupSusdt)
Me.Controls.Add(Me.txtsresn)
Me.Controls.Add(Me.Linksresn)
Me.Controls.Add(Me.TxtStatus)
Me.Controls.Add(Me.LinkStatus)
Me.Controls.Add(Me.TxtGLToYear)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.TxtTypes)
Me.Controls.Add(Me.LnkTypes)
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.ChkPrev)
Me.Controls.Add(Me.TxtGLFromYear)
Me.Controls.Add(Me.Label3)
Me.KeyPreview = True
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX904B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox1.ResumeLayout(False)
Me.GroupSusdt.ResumeLayout(False)
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
Private Sub FrmTX904B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
Dim myyear As Integer
  myyear = Now.Year - 15
  DtPckFrom.MinDate = New DateTime(myyear, Now.Month, Now.Day)
  DtPckFrom.Value = DtPckFrom.MinDate
  DtPckTo.Value = Date.Today

  MyFrmTX904.SbpPgmID.Text = "TX904B"
  MyFrmTX904.SbpEnvironment.Text = myDBConnect.PgmDB
  LblFilePath.Text = MyUtils.GetDataPath() & "CollData.txt"

End Sub
Private Sub FrmTX904B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX904.SbpScreen.Text = "TX904B"
End Sub
Private Sub FrmTX904B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLFromYear, "")
    ErrProv.SetError(TxtTypes, "")
    ErrProv.SetError(DtPckFrom, "")
    ErrProv.SetError(DtPckTo, "")
    ErrProv.SetError(LblFilePath, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "glyear"
        ErrProv.SetError(TxtGLFromYear, ErrorMsg(I))
      Case "types"
        ErrProv.SetError(TxtTypes, ErrorMsg(I))
      Case "from"
        ErrProv.SetError(DtPckFrom, ErrorMsg(I))
      Case "to"
        ErrProv.SetError(DtPckTo, ErrorMsg(I))
      Case "file"
        ErrProv.SetError(LblFilePath, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtGLFromYear.Text) > MyUtils.CnvSng(TxtGLToYear.Text) Then
      ErrorField(I) = "to"
      ErrorMsg(I) = "Invalid GL Year Range"
      I = I + 1
    End If
    If MyUtils.SetDBDate(DtPckFrom.Value) > MyUtils.SetDBDate(DtPckTo.Value) Then
      ErrorField(I) = "to"
      ErrorMsg(I) = "Invalid date Range"
      I = I + 1
    End If
    If LblFilePath.Text = String.Empty Then
      ErrorField(I) = "file"
      ErrorMsg(I) = "File Path is required"
      I = I + 1
    End If

  End Sub
Private Sub FrmTX904B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub

   If e.KeyCode = Keys.F12 Then
     MyUtils.PrtScreen(Form.ActiveForm)
   End If
End Sub
Private Sub TxtGLYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLFromYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
  With SaveFileDialog1
    .ShowDialog()
    LblFilePath.Text = .FileName
  End With
End Sub

Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
  MyTypes = TxtTypes.Text
  MyFrmSelTypes = New FrmSelTypes
  MyFrmSelTypes.MdiParent = Me.ParentForm
  MyFrmSelTypes.Show()

End Sub

Private Sub LinkStatus_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkStatus.LinkClicked
  MySts = TxtStatus.Text
  MyFrmSelStatus = New FrmSelStatus
  MyFrmSelStatus.MdiParent = Me.ParentForm
  MyFrmSelStatus.Show()
End Sub

Private Sub Linksresn_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Linksresn.LinkClicked
  MySresn = txtsresn.Text
  MyFrmSelreason = New FrmSelReason
  MyFrmSelreason.MdiParent = Me.ParentForm
  MyFrmSelreason.Show()
End Sub


Private Sub CHKSusdt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSusdt.CheckedChanged
  If CHKSusdt.Checked Then
    GroupSusdt.Visible = True
  Else
    GroupSusdt.Visible = False

  End If
End Sub
  Private Sub ChkDOB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkDOB.Click
      ChkDOBModel.Checked = False
  End Sub
  Private Sub ChkDOBModel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkDOBModel.Click
      ChkDOB.Checked = False
  End Sub
End Class






