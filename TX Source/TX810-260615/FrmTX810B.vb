Public Class FrmTX810B
  Inherits System.Windows.Forms.Form
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents RbFmtExtendFixed As System.Windows.Forms.RadioButton
  Friend WithEvents RbFmtOrig As System.Windows.Forms.RadioButton
  Friend WithEvents RbFmtMailSol As System.Windows.Forms.RadioButton
  Friend WithEvents RbFmtExtendCSV As System.Windows.Forms.RadioButton
  Friend WithEvents ChkOmitStatus As System.Windows.Forms.CheckBox
  Friend WithEvents ChkGrace As System.Windows.Forms.CheckBox
  Friend WithEvents ChkSuspense As System.Windows.Forms.CheckBox
  Friend WithEvents ChkOmitAgency As System.Windows.Forms.CheckBox
  Friend WithEvents TxtBankCd As TextBox
  Friend WithEvents LnkBankCd As LinkLabel
  Dim WrkJobID As String

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
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents DtPckAsof As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtDist As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents GrpSorting As System.Windows.Forms.GroupBox
  Friend WithEvents RbSortList As System.Windows.Forms.RadioButton
  Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
  Friend WithEvents LblFilePath As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.TxtGLFromYear = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.LnkTypes = New System.Windows.Forms.LinkLabel()
    Me.TxtTypes = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtGLToYear = New System.Windows.Forms.TextBox()
    Me.TxtStatus = New System.Windows.Forms.TextBox()
    Me.LinkStatus = New System.Windows.Forms.LinkLabel()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.DtPckAsof = New System.Windows.Forms.DateTimePicker()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.GrpSorting = New System.Windows.Forms.GroupBox()
    Me.RbSortList = New System.Windows.Forms.RadioButton()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbFmtExtendCSV = New System.Windows.Forms.RadioButton()
    Me.RbFmtMailSol = New System.Windows.Forms.RadioButton()
    Me.RbFmtExtendFixed = New System.Windows.Forms.RadioButton()
    Me.RbFmtOrig = New System.Windows.Forms.RadioButton()
    Me.ChkOmitStatus = New System.Windows.Forms.CheckBox()
    Me.ChkGrace = New System.Windows.Forms.CheckBox()
    Me.ChkSuspense = New System.Windows.Forms.CheckBox()
    Me.ChkOmitAgency = New System.Windows.Forms.CheckBox()
    Me.TxtBankCd = New System.Windows.Forms.TextBox()
    Me.LnkBankCd = New System.Windows.Forms.LinkLabel()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GrpSorting.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LblFilePath)
    Me.GroupBox1.Controls.Add(Me.LnkFilePath)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(23, 243)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(408, 72)
    Me.GroupBox1.TabIndex = 11
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "DQBILL File Details"
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
    Me.TxtGLFromYear.Location = New System.Drawing.Point(129, 19)
    Me.TxtGLFromYear.MaxLength = 4
    Me.TxtGLFromYear.Name = "TxtGLFromYear"
    Me.TxtGLFromYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtGLFromYear.TabIndex = 0
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(20, 21)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(84, 16)
    Me.Label3.TabIndex = 48
    Me.Label3.Text = "Grand List Year"
    '
    'LnkTypes
    '
    Me.LnkTypes.AutoSize = True
    Me.LnkTypes.Location = New System.Drawing.Point(16, 103)
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
    Me.TxtTypes.Location = New System.Drawing.Point(127, 100)
    Me.TxtTypes.MaxLength = 20
    Me.TxtTypes.Name = "TxtTypes"
    Me.TxtTypes.Size = New System.Drawing.Size(129, 20)
    Me.TxtTypes.TabIndex = 4
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(167, 21)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(18, 16)
    Me.Label1.TabIndex = 67
    Me.Label1.Text = "to"
    '
    'TxtGLToYear
    '
    Me.TxtGLToYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGLToYear.Location = New System.Drawing.Point(191, 19)
    Me.TxtGLToYear.MaxLength = 4
    Me.TxtGLToYear.Name = "TxtGLToYear"
    Me.TxtGLToYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtGLToYear.TabIndex = 1
    '
    'TxtStatus
    '
    Me.TxtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtStatus.Location = New System.Drawing.Point(127, 126)
    Me.TxtStatus.MaxLength = 20
    Me.TxtStatus.Name = "TxtStatus"
    Me.TxtStatus.Size = New System.Drawing.Size(129, 20)
    Me.TxtStatus.TabIndex = 5
    '
    'LinkStatus
    '
    Me.LinkStatus.AutoSize = True
    Me.LinkStatus.Location = New System.Drawing.Point(18, 129)
    Me.LinkStatus.Name = "LinkStatus"
    Me.LinkStatus.Size = New System.Drawing.Size(103, 13)
    Me.LinkStatus.TabIndex = 69
    Me.LinkStatus.TabStop = True
    Me.LinkStatus.Text = "Select Status Codes"
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(22, 48)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(72, 16)
    Me.Label5.TabIndex = 185
    Me.Label5.Text = "As of Date" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
    '
    'DtPckAsof
    '
    Me.DtPckAsof.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckAsof.Location = New System.Drawing.Point(129, 45)
    Me.DtPckAsof.Name = "DtPckAsof"
    Me.DtPckAsof.Size = New System.Drawing.Size(88, 20)
    Me.DtPckAsof.TabIndex = 2
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(127, 74)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(28, 20)
    Me.TxtDist.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(20, 77)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(44, 16)
    Me.Label2.TabIndex = 188
    Me.Label2.Text = "District"
    '
    'GrpSorting
    '
    Me.GrpSorting.Controls.Add(Me.RbSortList)
    Me.GrpSorting.Controls.Add(Me.RbSortName)
    Me.GrpSorting.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpSorting.ForeColor = System.Drawing.Color.Black
    Me.GrpSorting.Location = New System.Drawing.Point(334, 2)
    Me.GrpSorting.Name = "GrpSorting"
    Me.GrpSorting.Size = New System.Drawing.Size(157, 63)
    Me.GrpSorting.TabIndex = 12
    Me.GrpSorting.TabStop = False
    Me.GrpSorting.Text = "Sort Order (Year/Type)"
    '
    'RbSortList
    '
    Me.RbSortList.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortList.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbSortList.Location = New System.Drawing.Point(8, 40)
    Me.RbSortList.Name = "RbSortList"
    Me.RbSortList.Size = New System.Drawing.Size(80, 20)
    Me.RbSortList.TabIndex = 0
    Me.RbSortList.Text = "List #"
    '
    'RbSortName
    '
    Me.RbSortName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortName.Checked = True
    Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortName.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbSortName.Location = New System.Drawing.Point(8, 16)
    Me.RbSortName.Name = "RbSortName"
    Me.RbSortName.Size = New System.Drawing.Size(80, 20)
    Me.RbSortName.TabIndex = 1
    Me.RbSortName.TabStop = True
    Me.RbSortName.Text = "Name"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbFmtExtendCSV)
    Me.GroupBox2.Controls.Add(Me.RbFmtMailSol)
    Me.GroupBox2.Controls.Add(Me.RbFmtExtendFixed)
    Me.GroupBox2.Controls.Add(Me.RbFmtOrig)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(334, 77)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(157, 126)
    Me.GroupBox2.TabIndex = 13
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "File Format "
    '
    'RbFmtExtendCSV
    '
    Me.RbFmtExtendCSV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbFmtExtendCSV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFmtExtendCSV.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbFmtExtendCSV.Location = New System.Drawing.Point(8, 66)
    Me.RbFmtExtendCSV.Name = "RbFmtExtendCSV"
    Me.RbFmtExtendCSV.Size = New System.Drawing.Size(143, 20)
    Me.RbFmtExtendCSV.TabIndex = 4
    Me.RbFmtExtendCSV.Text = "Extended (CSV)"
    '
    'RbFmtMailSol
    '
    Me.RbFmtMailSol.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbFmtMailSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFmtMailSol.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbFmtMailSol.Location = New System.Drawing.Point(8, 92)
    Me.RbFmtMailSol.Name = "RbFmtMailSol"
    Me.RbFmtMailSol.Size = New System.Drawing.Size(143, 20)
    Me.RbFmtMailSol.TabIndex = 3
    Me.RbFmtMailSol.Text = "Mail Solutions (Custom)"
    '
    'RbFmtExtendFixed
    '
    Me.RbFmtExtendFixed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbFmtExtendFixed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFmtExtendFixed.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbFmtExtendFixed.Location = New System.Drawing.Point(8, 40)
    Me.RbFmtExtendFixed.Name = "RbFmtExtendFixed"
    Me.RbFmtExtendFixed.Size = New System.Drawing.Size(143, 20)
    Me.RbFmtExtendFixed.TabIndex = 2
    Me.RbFmtExtendFixed.Text = "Extended"
    '
    'RbFmtOrig
    '
    Me.RbFmtOrig.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbFmtOrig.Checked = True
    Me.RbFmtOrig.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFmtOrig.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbFmtOrig.Location = New System.Drawing.Point(8, 19)
    Me.RbFmtOrig.Name = "RbFmtOrig"
    Me.RbFmtOrig.Size = New System.Drawing.Size(143, 20)
    Me.RbFmtOrig.TabIndex = 1
    Me.RbFmtOrig.TabStop = True
    Me.RbFmtOrig.Text = "Original"
    '
    'ChkOmitStatus
    '
    Me.ChkOmitStatus.AutoSize = True
    Me.ChkOmitStatus.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkOmitStatus.Location = New System.Drawing.Point(262, 129)
    Me.ChkOmitStatus.Name = "ChkOmitStatus"
    Me.ChkOmitStatus.Size = New System.Drawing.Size(53, 17)
    Me.ChkOmitStatus.TabIndex = 6
    Me.ChkOmitStatus.Text = "Omit?"
    Me.ChkOmitStatus.UseVisualStyleBackColor = True
    '
    'ChkGrace
    '
    Me.ChkGrace.AutoSize = True
    Me.ChkGrace.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkGrace.Location = New System.Drawing.Point(50, 203)
    Me.ChkGrace.Name = "ChkGrace"
    Me.ChkGrace.Size = New System.Drawing.Size(167, 17)
    Me.ChkGrace.TabIndex = 9
    Me.ChkGrace.Text = "Omit records in Grace Period?"
    Me.ChkGrace.UseVisualStyleBackColor = True
    '
    'ChkSuspense
    '
    Me.ChkSuspense.AutoSize = True
    Me.ChkSuspense.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkSuspense.Location = New System.Drawing.Point(114, 186)
    Me.ChkSuspense.Name = "ChkSuspense"
    Me.ChkSuspense.Size = New System.Drawing.Size(103, 17)
    Me.ChkSuspense.TabIndex = 8
    Me.ChkSuspense.Text = "Omit Suspense?"
    Me.ChkSuspense.UseVisualStyleBackColor = True
    '
    'ChkOmitAgency
    '
    Me.ChkOmitAgency.AutoSize = True
    Me.ChkOmitAgency.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkOmitAgency.Location = New System.Drawing.Point(27, 220)
    Me.ChkOmitAgency.Name = "ChkOmitAgency"
    Me.ChkOmitAgency.Size = New System.Drawing.Size(190, 17)
    Me.ChkOmitAgency.TabIndex = 10
    Me.ChkOmitAgency.Text = "Omit records in Collection Agency?"
    Me.ChkOmitAgency.UseVisualStyleBackColor = True
    '
    'TxtBankCd
    '
    Me.TxtBankCd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBankCd.Location = New System.Drawing.Point(127, 153)
    Me.TxtBankCd.MaxLength = 2
    Me.TxtBankCd.Name = "TxtBankCd"
    Me.TxtBankCd.Size = New System.Drawing.Size(24, 20)
    Me.TxtBankCd.TabIndex = 7
    '
    'LnkBankCd
    '
    Me.LnkBankCd.Location = New System.Drawing.Point(6, 156)
    Me.LnkBankCd.Name = "LnkBankCd"
    Me.LnkBankCd.Size = New System.Drawing.Size(115, 16)
    Me.LnkBankCd.TabIndex = 192
    Me.LnkBankCd.TabStop = True
    Me.LnkBankCd.Text = "Bank Code (Optional)"
    '
    'FrmTX810B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(503, 325)
    Me.ControlBox = False
    Me.Controls.Add(Me.TxtBankCd)
    Me.Controls.Add(Me.LnkBankCd)
    Me.Controls.Add(Me.ChkOmitAgency)
    Me.Controls.Add(Me.ChkGrace)
    Me.Controls.Add(Me.ChkSuspense)
    Me.Controls.Add(Me.ChkOmitStatus)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GrpSorting)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.DtPckAsof)
    Me.Controls.Add(Me.TxtStatus)
    Me.Controls.Add(Me.LinkStatus)
    Me.Controls.Add(Me.TxtGLToYear)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtTypes)
    Me.Controls.Add(Me.LnkTypes)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.TxtGLFromYear)
    Me.Controls.Add(Me.Label3)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX810B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GrpSorting.ResumeLayout(False)
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
  Private Sub FrmTX810B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmTX810.SbpPgmID.Text = "TX810B"
    MyFrmTX810.SbpEnvironment.Text = myDBConnect.PgmDB
    LblFilePath.Text = MyUtils.GetDataPath() & "DQBILL.txt"
  End Sub
  Private Sub FrmTX810B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTX810.SbpScreen.Text = "TX810B"
  End Sub
  Private Sub FrmTX810B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLToYear, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "glyear"
          ErrProv.SetError(TxtGLToYear, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtGLFromYear.Text) = 0 Or MyUtils.CnvSng(TxtGLToYear.Text) = 0 Then
      ErrorField(I) = "glyear"
      ErrorMsg(I) = "GL Year Range is required"
      I = I + 1
    End If
    If MyUtils.CnvSng(TxtGLFromYear.Text) > MyUtils.CnvSng(TxtGLToYear.Text) Then
      ErrorField(I) = "glyear"
      ErrorMsg(I) = "Invalid GL Year Range"
      I = I + 1
    End If

  End Sub
  Private Sub FrmTX810B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If Not e.Alt Then Exit Sub

    If e.KeyCode = Keys.F12 Then
      MyUtils.PrtScreen(Form.ActiveForm)
    End If
  End Sub
  Private Sub TxtGLFromYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLFromYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtGLToYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLToYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
    With SaveFileDialog1
      .Filter = "Text File|*.*"
      .ShowDialog()
      If .FileName <> String.Empty Then
        LblFilePath.Text = .FileName
      End If
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
    MyFrmStatus = New FrmStatus
    MyFrmStatus.MdiParent = Me.ParentForm
    MyFrmStatus.Show()
  End Sub

  Private Sub LnkBankCd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBankCd.LinkClicked
    MyFrmListBanks = New FrmListBanks
    MyFrmListBanks.MdiParent = Me.ParentForm
    MyFrmListBanks.WrkCode = TxtBankCd.Text
    MyFrmListBanks.Show()
  End Sub
End Class






