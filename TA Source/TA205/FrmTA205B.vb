Public Class FrmTA205B
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
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbChanges As System.Windows.Forms.RadioButton
  Friend WithEvents RbIncrease As System.Windows.Forms.RadioButton
  Friend WithEvents DtPckReturn As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents RbPP As System.Windows.Forms.RadioButton
  Friend WithEvents RbRE As System.Windows.Forms.RadioButton
  Friend WithEvents RbAll As System.Windows.Forms.RadioButton
  Friend WithEvents ChkNewOPM As System.Windows.Forms.CheckBox
  Friend WithEvents ChkNoDetail As System.Windows.Forms.CheckBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtPhone As System.Windows.Forms.TextBox
  Friend WithEvents ChkExemptions As System.Windows.Forms.CheckBox
  Friend WithEvents RbDecl As System.Windows.Forms.RadioButton
  Friend WithEvents RbReval As RadioButton
  Friend WithEvents DtPckPrint As DateTimePicker
  Friend WithEvents Label3 As Label
  Friend WithEvents Label5 As Label
  Friend WithEvents CboMeets As ComboBox
    Friend WithEvents RbReArchive As RadioButton
  Friend WithEvents lblccrs As Label
  Friend WithEvents TxtCcrs As TextBox
    Friend WithEvents TxtPropCode As TextBox
  Friend WithEvents LblPropCode As Label
  Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbAll = New System.Windows.Forms.RadioButton()
    Me.RbChanges = New System.Windows.Forms.RadioButton()
    Me.RbIncrease = New System.Windows.Forms.RadioButton()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.DtPckReturn = New System.Windows.Forms.DateTimePicker()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.TxtPropCode = New System.Windows.Forms.TextBox()
    Me.LblPropCode = New System.Windows.Forms.Label()
    Me.TxtCcrs = New System.Windows.Forms.TextBox()
    Me.lblccrs = New System.Windows.Forms.Label()
    Me.RbReArchive = New System.Windows.Forms.RadioButton()
    Me.RbReval = New System.Windows.Forms.RadioButton()
    Me.RbDecl = New System.Windows.Forms.RadioButton()
    Me.RbPP = New System.Windows.Forms.RadioButton()
    Me.RbRE = New System.Windows.Forms.RadioButton()
    Me.ChkNewOPM = New System.Windows.Forms.CheckBox()
    Me.ChkNoDetail = New System.Windows.Forms.CheckBox()
    Me.TxtPhone = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.ChkExemptions = New System.Windows.Forms.CheckBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.DtPckPrint = New System.Windows.Forms.DateTimePicker()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.CboMeets = New System.Windows.Forms.ComboBox()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtGLYear
        '
        Me.TxtGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGLYear.Location = New System.Drawing.Point(177, 142)
        Me.TxtGLYear.MaxLength = 4
        Me.TxtGLYear.Name = "TxtGLYear"
        Me.TxtGLYear.Size = New System.Drawing.Size(36, 20)
        Me.TxtGLYear.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(87, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Grand List Year"
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RbAll)
        Me.GroupBox1.Controls.Add(Me.RbChanges)
        Me.GroupBox1.Controls.Add(Me.RbIncrease)
        Me.GroupBox1.Location = New System.Drawing.Point(46, 165)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(248, 81)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'RbAll
        '
        Me.RbAll.Location = New System.Drawing.Point(11, 58)
        Me.RbAll.Name = "RbAll"
        Me.RbAll.Size = New System.Drawing.Size(94, 17)
        Me.RbAll.TabIndex = 16
        Me.RbAll.Text = "All"
        Me.RbAll.UseVisualStyleBackColor = True
        '
        'RbChanges
        '
        Me.RbChanges.Location = New System.Drawing.Point(11, 38)
        Me.RbChanges.Name = "RbChanges"
        Me.RbChanges.Size = New System.Drawing.Size(94, 17)
        Me.RbChanges.TabIndex = 15
        Me.RbChanges.Text = "Changes only"
        Me.RbChanges.UseVisualStyleBackColor = True
        '
        'RbIncrease
        '
        Me.RbIncrease.Checked = True
        Me.RbIncrease.Location = New System.Drawing.Point(11, 15)
        Me.RbIncrease.Name = "RbIncrease"
        Me.RbIncrease.Size = New System.Drawing.Size(94, 17)
        Me.RbIncrease.TabIndex = 14
        Me.RbIncrease.TabStop = True
        Me.RbIncrease.Text = "Increase only"
        Me.RbIncrease.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(-1, 311)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(199, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Form To Be Completed And Returned By"
        '
        'DtPckReturn
        '
        Me.DtPckReturn.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckReturn.Location = New System.Drawing.Point(204, 307)
        Me.DtPckReturn.Name = "DtPckReturn"
        Me.DtPckReturn.Size = New System.Drawing.Size(90, 20)
        Me.DtPckReturn.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtPropCode)
        Me.GroupBox2.Controls.Add(Me.LblPropCode)
        Me.GroupBox2.Controls.Add(Me.TxtCcrs)
        Me.GroupBox2.Controls.Add(Me.lblccrs)
        Me.GroupBox2.Controls.Add(Me.RbReArchive)
        Me.GroupBox2.Controls.Add(Me.RbReval)
        Me.GroupBox2.Controls.Add(Me.RbDecl)
        Me.GroupBox2.Controls.Add(Me.RbPP)
        Me.GroupBox2.Controls.Add(Me.RbRE)
        Me.GroupBox2.Location = New System.Drawing.Point(46, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(237, 128)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'TxtPropCode
        '
        Me.TxtPropCode.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPropCode.Location = New System.Drawing.Point(203, 52)
        Me.TxtPropCode.MaxLength = 2
        Me.TxtPropCode.Name = "TxtPropCode"
        Me.TxtPropCode.Size = New System.Drawing.Size(24, 20)
        Me.TxtPropCode.TabIndex = 25
        '
        'LblPropCode
        '
        Me.LblPropCode.AutoSize = True
        Me.LblPropCode.Location = New System.Drawing.Point(125, 57)
        Me.LblPropCode.Name = "LblPropCode"
        Me.LblPropCode.Size = New System.Drawing.Size(74, 13)
        Me.LblPropCode.TabIndex = 24
        Me.LblPropCode.Text = "Property Code"
        '
        'TxtCcrs
        '
        Me.TxtCcrs.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCcrs.Location = New System.Drawing.Point(203, 97)
        Me.TxtCcrs.MaxLength = 1
        Me.TxtCcrs.Name = "TxtCcrs"
        Me.TxtCcrs.Size = New System.Drawing.Size(24, 20)
        Me.TxtCcrs.TabIndex = 23
        '
        'lblccrs
        '
        Me.lblccrs.AutoSize = True
        Me.lblccrs.Location = New System.Drawing.Point(125, 100)
        Me.lblccrs.Name = "lblccrs"
        Me.lblccrs.Size = New System.Drawing.Size(72, 13)
        Me.lblccrs.TabIndex = 22
        Me.lblccrs.Text = "Reason Code"
        '
        'RbReArchive
        '
        Me.RbReArchive.AutoSize = True
        Me.RbReArchive.Location = New System.Drawing.Point(11, 98)
        Me.RbReArchive.Name = "RbReArchive"
        Me.RbReArchive.Size = New System.Drawing.Size(79, 17)
        Me.RbReArchive.TabIndex = 18
        Me.RbReArchive.Text = "RE Archive"
        Me.RbReArchive.UseVisualStyleBackColor = True
        '
        'RbReval
        '
        Me.RbReval.AutoSize = True
        Me.RbReval.Location = New System.Drawing.Point(11, 35)
        Me.RbReval.Name = "RbReval"
        Me.RbReval.Size = New System.Drawing.Size(100, 17)
        Me.RbReval.TabIndex = 17
        Me.RbReval.Text = "RE Revaluation"
        Me.RbReval.UseVisualStyleBackColor = True
        '
        'RbDecl
        '
        Me.RbDecl.AutoSize = True
        Me.RbDecl.Location = New System.Drawing.Point(11, 75)
        Me.RbDecl.Name = "RbDecl"
        Me.RbDecl.Size = New System.Drawing.Size(96, 17)
        Me.RbDecl.TabIndex = 16
        Me.RbDecl.Text = "PP Declaration"
        Me.RbDecl.UseVisualStyleBackColor = True
        '
        'RbPP
        '
        Me.RbPP.AutoSize = True
        Me.RbPP.Location = New System.Drawing.Point(11, 55)
        Me.RbPP.Name = "RbPP"
        Me.RbPP.Size = New System.Drawing.Size(108, 17)
        Me.RbPP.TabIndex = 15
        Me.RbPP.Text = "Personal Property"
        Me.RbPP.UseVisualStyleBackColor = True
        '
        'RbRE
        '
        Me.RbRE.AutoSize = True
        Me.RbRE.Checked = True
        Me.RbRE.Location = New System.Drawing.Point(11, 15)
        Me.RbRE.Name = "RbRE"
        Me.RbRE.Size = New System.Drawing.Size(80, 17)
        Me.RbRE.TabIndex = 0
        Me.RbRE.TabStop = True
        Me.RbRE.Text = "Real Estate"
        Me.RbRE.UseVisualStyleBackColor = True
        '
        'ChkNewOPM
        '
        Me.ChkNewOPM.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkNewOPM.Checked = True
        Me.ChkNewOPM.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkNewOPM.Location = New System.Drawing.Point(77, 383)
        Me.ChkNewOPM.Name = "ChkNewOPM"
        Me.ChkNewOPM.Size = New System.Drawing.Size(150, 16)
        Me.ChkNewOPM.TabIndex = 5
        Me.ChkNewOPM.Text = "Use New OPM Codes?"
        '
        'ChkNoDetail
        '
        Me.ChkNoDetail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkNoDetail.Location = New System.Drawing.Point(77, 339)
        Me.ChkNoDetail.Name = "ChkNoDetail"
        Me.ChkNoDetail.Size = New System.Drawing.Size(150, 17)
        Me.ChkNoDetail.TabIndex = 3
        Me.ChkNoDetail.Text = "Suppress Codes (Detail)?"
        '
        'TxtPhone
        '
        Me.TxtPhone.Location = New System.Drawing.Point(135, 412)
        Me.TxtPhone.MaxLength = 20
        Me.TxtPhone.Name = "TxtPhone"
        Me.TxtPhone.Size = New System.Drawing.Size(148, 20)
        Me.TxtPhone.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(43, 415)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 16)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Phone Number"
        '
        'ChkExemptions
        '
        Me.ChkExemptions.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkExemptions.Checked = True
        Me.ChkExemptions.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkExemptions.Location = New System.Drawing.Point(77, 362)
        Me.ChkExemptions.Name = "ChkExemptions"
        Me.ChkExemptions.Size = New System.Drawing.Size(150, 17)
        Me.ChkExemptions.TabIndex = 4
        Me.ChkExemptions.Text = "Show exemptions total?"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(113, 287)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Form Print Date"
        '
        'DtPckPrint
        '
        Me.DtPckPrint.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckPrint.Location = New System.Drawing.Point(206, 283)
        Me.DtPckPrint.Name = "DtPckPrint"
        Me.DtPckPrint.Size = New System.Drawing.Size(90, 20)
        Me.DtPckPrint.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(119, 261)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "BAA Meets in "
        '
        'CboMeets
        '
        Me.CboMeets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMeets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMeets.FormattingEnabled = True
        Me.CboMeets.Location = New System.Drawing.Point(201, 258)
        Me.CboMeets.Name = "CboMeets"
        Me.CboMeets.Size = New System.Drawing.Size(95, 21)
        Me.CboMeets.TabIndex = 22
        '
        'FrmTA205B
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(315, 449)
        Me.ControlBox = False
        Me.Controls.Add(Me.CboMeets)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DtPckPrint)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ChkExemptions)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtPhone)
        Me.Controls.Add(Me.ChkNoDetail)
        Me.Controls.Add(Me.ChkNewOPM)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.DtPckReturn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TxtGLYear)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTA205B"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FrmTA205B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA205.SbpScreen.Text = "TA205"
  End Sub
  Private Sub FrmTA205B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLYear, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "glyear"
          ErrProv.SetError(TxtGLYear, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtGLYear.Text) = 0 Then
      ErrorField(I) = "glyear"
      ErrorMsg(I) = "Year is required"
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

    WrkAssrPhone = TxtPhone.Text
    Me.Refresh()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    If RbRE.Checked Or RbReval.Checked Then
      PrtReportRE()
    End If
    If RbReArchive.Checked Then
      PrtReportREarch()
    End If
    If RbPP.Checked Then
      PrtReportPP()
    End If
    If RbDecl.Checked Then
      PrtReportDecl()
    End If
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub

  Private Sub FrmTA205B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    DtPckReturn.Value = Date.Today
    DtPckPrint.Value = Date.Today
    CboMeets.Items.Clear()
    CboMeets.Items.Add("March")
    CboMeets.Items.Add("April")
    CboMeets.SelectedItem = "March"

    LblPropCode.Visible = False
    TxtPropCode.Visible = False
    lblccrs.Visible = False
    TxtCcrs.Visible = False

    MyTypes = ""
    GetTXCNTL()
    If myTOWN._TOWNBR = 121 Then
      TxtPhone.Text = "(860) 859-3873 Ext 130"
    Else
      TxtPhone.Text = WrkAssrPhone
    End If
  End Sub
  Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub ChkNoDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkNoDetail.Click
    If ChkNoDetail.Checked Then
      ChkNewOPM.Checked = False
      ChkNewOPM.Enabled = False
    Else
      ChkNewOPM.Enabled = True
    End If
  End Sub
  Private Sub RbRE_Click(sender As Object, e As EventArgs) Handles RbRE.Click
    RbChanges.Enabled = True
    RbAll.Enabled = True
    ChkExemptions.Enabled = True
    ChkNewOPM.Enabled = True
    ChkNoDetail.Enabled = True
    LblPropCode.Visible = False
    TxtPropCode.Visible = False
    lblccrs.Visible = False
    TxtCcrs.Visible = False
  End Sub
  Private Sub RbReval_Click(sender As Object, e As EventArgs) Handles RbReval.Click
    RbChanges.Enabled = True
    RbAll.Enabled = True
    ChkExemptions.Enabled = False
    ChkNewOPM.Enabled = False
    ChkNoDetail.Enabled = False
    LblPropCode.Visible = False
    TxtPropCode.Visible = False
    lblccrs.Visible = False
    TxtCcrs.Visible = False
  End Sub
  Private Sub RbPP_Click(sender As Object, e As EventArgs) Handles RbPP.Click
    RbChanges.Enabled = True
    RbAll.Enabled = True
    ChkExemptions.Enabled = True
    ChkNewOPM.Enabled = True
    ChkNoDetail.Enabled = True
    LblPropCode.Visible = True
    TxtPropCode.Visible = True
    lblccrs.Visible = False
    TxtCcrs.Visible = False
  End Sub
  Private Sub RbDecl_Click(sender As Object, e As EventArgs) Handles RbDecl.Click
    RbChanges.Enabled = False
    RbAll.Enabled = False
    ChkExemptions.Enabled = True
    ChkNewOPM.Enabled = True
    ChkNoDetail.Enabled = True
    LblPropCode.Visible = False
    TxtPropCode.Visible = False
    lblccrs.Visible = False
    TxtCcrs.Visible = False
  End Sub
  Private Sub RbReArchive_Click(sender As Object, e As EventArgs) Handles RbReArchive.Click
    RbChanges.Enabled = True
    RbAll.Enabled = True
    ChkExemptions.Enabled = True
    ChkNewOPM.Enabled = True
    ChkNoDetail.Enabled = True
    LblPropCode.Visible = False
    TxtPropCode.Visible = False
    lblccrs.Visible = True
    TxtCcrs.Visible = True
  End Sub
  Private Sub RbRE_CheckedChanged(sender As Object, e As EventArgs) Handles RbRE.CheckedChanged

  End Sub

  Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RbReArchive.CheckedChanged

  End Sub

  Private Sub Label6_Click(sender As Object, e As EventArgs) Handles lblccrs.Click

  End Sub

  Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

  End Sub
End Class






