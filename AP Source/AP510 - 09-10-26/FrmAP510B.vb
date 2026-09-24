Public Class FrmAP510B
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
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
Friend WithEvents LnkBank As System.Windows.Forms.LinkLabel
Friend WithEvents TxtBank As System.Windows.Forms.TextBox
Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents RbPRTD As System.Windows.Forms.RadioButton
Friend WithEvents RbAPBOA As System.Windows.Forms.RadioButton
Friend WithEvents RbAPTD As System.Windows.Forms.RadioButton
Friend WithEvents RbAP As System.Windows.Forms.RadioButton
Friend WithEvents RbPRBOA As System.Windows.Forms.RadioButton
Friend WithEvents RbPRBOAShort As System.Windows.Forms.RadioButton
Friend WithEvents TxtChkTo As System.Windows.Forms.TextBox
Friend WithEvents LblChkTo As System.Windows.Forms.Label
Friend WithEvents TxtChkFrom As System.Windows.Forms.TextBox
Friend WithEvents LblChkFrom As System.Windows.Forms.Label
Friend WithEvents LblChkNum As System.Windows.Forms.Label
Friend WithEvents RbAPBOAShort As System.Windows.Forms.RadioButton
Friend WithEvents RbAPWebster As System.Windows.Forms.RadioButton
Friend WithEvents RbPRWebster As System.Windows.Forms.RadioButton
Friend WithEvents RbAPCSV As System.Windows.Forms.RadioButton
Friend WithEvents RbPRCSV As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbDataAll As System.Windows.Forms.RadioButton
Friend WithEvents RbDataSupport As System.Windows.Forms.RadioButton
Friend WithEvents RbDataRegular As System.Windows.Forms.RadioButton
  Friend WithEvents RbAPIon As RadioButton
  Friend WithEvents RbPRIon As RadioButton
  Friend WithEvents LblFilePath As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.LnkBank = New System.Windows.Forms.LinkLabel()
    Me.TxtBank = New System.Windows.Forms.TextBox()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.RbPRTD = New System.Windows.Forms.RadioButton()
    Me.RbAP = New System.Windows.Forms.RadioButton()
    Me.RbAPTD = New System.Windows.Forms.RadioButton()
    Me.RbAPBOA = New System.Windows.Forms.RadioButton()
    Me.RbPRBOA = New System.Windows.Forms.RadioButton()
    Me.RbPRBOAShort = New System.Windows.Forms.RadioButton()
    Me.LblChkFrom = New System.Windows.Forms.Label()
    Me.TxtChkFrom = New System.Windows.Forms.TextBox()
    Me.TxtChkTo = New System.Windows.Forms.TextBox()
    Me.LblChkTo = New System.Windows.Forms.Label()
    Me.LblChkNum = New System.Windows.Forms.Label()
    Me.RbAPBOAShort = New System.Windows.Forms.RadioButton()
    Me.RbAPWebster = New System.Windows.Forms.RadioButton()
    Me.RbPRWebster = New System.Windows.Forms.RadioButton()
    Me.RbAPCSV = New System.Windows.Forms.RadioButton()
    Me.RbPRCSV = New System.Windows.Forms.RadioButton()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbDataSupport = New System.Windows.Forms.RadioButton()
    Me.RbDataRegular = New System.Windows.Forms.RadioButton()
    Me.RbDataAll = New System.Windows.Forms.RadioButton()
    Me.RbAPIon = New System.Windows.Forms.RadioButton()
    Me.RbPRIon = New System.Windows.Forms.RadioButton()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        Me.GroupBox1.Location = New System.Drawing.Point(16, 297)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 72)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "File Details"
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
        'LnkBank
        '
        Me.LnkBank.AutoSize = True
        Me.LnkBank.Location = New System.Drawing.Point(36, 86)
        Me.LnkBank.Name = "LnkBank"
        Me.LnkBank.Size = New System.Drawing.Size(60, 13)
        Me.LnkBank.TabIndex = 65
        Me.LnkBank.TabStop = True
        Me.LnkBank.Text = "Bank Code"
        '
        'TxtBank
        '
        Me.TxtBank.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBank.Location = New System.Drawing.Point(102, 83)
        Me.TxtBank.MaxLength = 5
        Me.TxtBank.Name = "TxtBank"
        Me.TxtBank.Size = New System.Drawing.Size(48, 20)
        Me.TxtBank.TabIndex = 4
        '
        'DtPckTo
        '
        Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckTo.Location = New System.Drawing.Point(262, 23)
        Me.DtPckTo.Name = "DtPckTo"
        Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
        Me.DtPckTo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(210, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "To Date"
        '
        'DtPckFrom
        '
        Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckFrom.Location = New System.Drawing.Point(102, 23)
        Me.DtPckFrom.Name = "DtPckFrom"
        Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
        Me.DtPckFrom.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(42, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "From Date"
        '
        'RbPRTD
        '
        Me.RbPRTD.AutoSize = True
        Me.RbPRTD.Enabled = False
        Me.RbPRTD.Location = New System.Drawing.Point(348, 146)
        Me.RbPRTD.Name = "RbPRTD"
        Me.RbPRTD.Size = New System.Drawing.Size(91, 17)
        Me.RbPRTD.TabIndex = 72
        Me.RbPRTD.Text = "P/R TD Bank"
        Me.RbPRTD.UseVisualStyleBackColor = True
        Me.RbPRTD.Visible = False
        '
        'RbAP
        '
        Me.RbAP.AutoSize = True
        Me.RbAP.Checked = True
        Me.RbAP.Location = New System.Drawing.Point(38, 123)
        Me.RbAP.Name = "RbAP"
        Me.RbAP.Size = New System.Drawing.Size(47, 17)
        Me.RbAP.TabIndex = 5
        Me.RbAP.TabStop = True
        Me.RbAP.Text = "A/P "
        Me.RbAP.UseVisualStyleBackColor = True
        '
        'RbAPTD
        '
        Me.RbAPTD.AutoSize = True
        Me.RbAPTD.Location = New System.Drawing.Point(38, 146)
        Me.RbAPTD.Name = "RbAPTD"
        Me.RbAPTD.Size = New System.Drawing.Size(90, 17)
        Me.RbAPTD.TabIndex = 73
        Me.RbAPTD.Text = "A/P TD Bank"
        Me.RbAPTD.UseVisualStyleBackColor = True
        '
        'RbAPBOA
        '
        Me.RbAPBOA.AutoSize = True
        Me.RbAPBOA.Location = New System.Drawing.Point(38, 169)
        Me.RbAPBOA.Name = "RbAPBOA"
        Me.RbAPBOA.Size = New System.Drawing.Size(69, 17)
        Me.RbAPBOA.TabIndex = 74
        Me.RbAPBOA.Text = "A/P BOA"
        Me.RbAPBOA.UseVisualStyleBackColor = True
        '
        'RbPRBOA
        '
        Me.RbPRBOA.AutoSize = True
        Me.RbPRBOA.Enabled = False
        Me.RbPRBOA.Location = New System.Drawing.Point(348, 169)
        Me.RbPRBOA.Name = "RbPRBOA"
        Me.RbPRBOA.Size = New System.Drawing.Size(70, 17)
        Me.RbPRBOA.TabIndex = 75
        Me.RbPRBOA.Text = "P/R BOA"
        Me.RbPRBOA.UseVisualStyleBackColor = True
        Me.RbPRBOA.Visible = False
        '
        'RbPRBOAShort
        '
        Me.RbPRBOAShort.AutoSize = True
        Me.RbPRBOAShort.Enabled = False
        Me.RbPRBOAShort.Location = New System.Drawing.Point(348, 192)
        Me.RbPRBOAShort.Name = "RbPRBOAShort"
        Me.RbPRBOAShort.Size = New System.Drawing.Size(104, 17)
        Me.RbPRBOAShort.TabIndex = 76
        Me.RbPRBOAShort.Text = "P/R BOA (Short)"
        Me.RbPRBOAShort.UseVisualStyleBackColor = True
        Me.RbPRBOAShort.Visible = False
        '
        'LblChkFrom
        '
        Me.LblChkFrom.Location = New System.Drawing.Point(36, 52)
        Me.LblChkFrom.Name = "LblChkFrom"
        Me.LblChkFrom.Size = New System.Drawing.Size(81, 15)
        Me.LblChkFrom.TabIndex = 77
        Me.LblChkFrom.Text = "From Number*"
        '
        'TxtChkFrom
        '
        Me.TxtChkFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtChkFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtChkFrom.Location = New System.Drawing.Point(123, 49)
        Me.TxtChkFrom.MaxLength = 7
        Me.TxtChkFrom.Name = "TxtChkFrom"
        Me.TxtChkFrom.Size = New System.Drawing.Size(57, 20)
        Me.TxtChkFrom.TabIndex = 2
        '
        'TxtChkTo
        '
        Me.TxtChkTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtChkTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtChkTo.Location = New System.Drawing.Point(262, 49)
        Me.TxtChkTo.MaxLength = 7
        Me.TxtChkTo.Name = "TxtChkTo"
        Me.TxtChkTo.Size = New System.Drawing.Size(60, 20)
        Me.TxtChkTo.TabIndex = 3
        '
        'LblChkTo
        '
        Me.LblChkTo.Location = New System.Drawing.Point(186, 52)
        Me.LblChkTo.Name = "LblChkTo"
        Me.LblChkTo.Size = New System.Drawing.Size(70, 15)
        Me.LblChkTo.TabIndex = 79
        Me.LblChkTo.Text = "To Number*"
        '
        'LblChkNum
        '
        Me.LblChkNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChkNum.Location = New System.Drawing.Point(0, 375)
        Me.LblChkNum.Name = "LblChkNum"
        Me.LblChkNum.Size = New System.Drawing.Size(439, 15)
        Me.LblChkNum.TabIndex = 81
        Me.LblChkNum.Text = "*=When Check Number range is entered then Date Range will be ignored"
        Me.LblChkNum.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'RbAPBOAShort
        '
        Me.RbAPBOAShort.AutoSize = True
        Me.RbAPBOAShort.Location = New System.Drawing.Point(39, 192)
        Me.RbAPBOAShort.Name = "RbAPBOAShort"
        Me.RbAPBOAShort.Size = New System.Drawing.Size(103, 17)
        Me.RbAPBOAShort.TabIndex = 82
        Me.RbAPBOAShort.Text = "A/P BOA (Short)"
        Me.RbAPBOAShort.UseVisualStyleBackColor = True
        '
        'RbAPWebster
        '
        Me.RbAPWebster.AutoSize = True
        Me.RbAPWebster.Location = New System.Drawing.Point(39, 215)
        Me.RbAPWebster.Name = "RbAPWebster"
        Me.RbAPWebster.Size = New System.Drawing.Size(87, 17)
        Me.RbAPWebster.TabIndex = 83
        Me.RbAPWebster.Text = "A/P Webster"
        Me.RbAPWebster.UseVisualStyleBackColor = True
        '
        'RbPRWebster
        '
        Me.RbPRWebster.AutoSize = True
        Me.RbPRWebster.Enabled = False
        Me.RbPRWebster.Location = New System.Drawing.Point(348, 215)
        Me.RbPRWebster.Name = "RbPRWebster"
        Me.RbPRWebster.Size = New System.Drawing.Size(88, 17)
        Me.RbPRWebster.TabIndex = 84
        Me.RbPRWebster.Text = "P/R Webster"
        Me.RbPRWebster.UseVisualStyleBackColor = True
        Me.RbPRWebster.Visible = False
        '
        'RbAPCSV
        '
        Me.RbAPCSV.AutoSize = True
        Me.RbAPCSV.Location = New System.Drawing.Point(39, 238)
        Me.RbAPCSV.Name = "RbAPCSV"
        Me.RbAPCSV.Size = New System.Drawing.Size(103, 17)
        Me.RbAPCSV.TabIndex = 85
        Me.RbAPCSV.Text = "A/P CSV (Excel)"
        Me.RbAPCSV.UseVisualStyleBackColor = True
        '
        'RbPRCSV
        '
        Me.RbPRCSV.AutoSize = True
        Me.RbPRCSV.Location = New System.Drawing.Point(194, 238)
        Me.RbPRCSV.Name = "RbPRCSV"
        Me.RbPRCSV.Size = New System.Drawing.Size(104, 17)
        Me.RbPRCSV.TabIndex = 86
        Me.RbPRCSV.Text = "P/R CSV (Excel)"
        Me.RbPRCSV.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RbDataSupport)
        Me.GroupBox2.Controls.Add(Me.RbDataRegular)
        Me.GroupBox2.Controls.Add(Me.RbDataAll)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(194, 100)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(216, 40)
        Me.GroupBox2.TabIndex = 87
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "P/R Check Selection"
        '
        'RbDataSupport
        '
        Me.RbDataSupport.AutoSize = True
        Me.RbDataSupport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbDataSupport.Location = New System.Drawing.Point(141, 17)
        Me.RbDataSupport.Name = "RbDataSupport"
        Me.RbDataSupport.Size = New System.Drawing.Size(62, 17)
        Me.RbDataSupport.TabIndex = 8
        Me.RbDataSupport.Text = "Support"
        Me.RbDataSupport.UseVisualStyleBackColor = True
        '
        'RbDataRegular
        '
        Me.RbDataRegular.AutoSize = True
        Me.RbDataRegular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbDataRegular.Location = New System.Drawing.Point(61, 17)
        Me.RbDataRegular.Name = "RbDataRegular"
        Me.RbDataRegular.Size = New System.Drawing.Size(62, 17)
        Me.RbDataRegular.TabIndex = 7
        Me.RbDataRegular.Text = "Regular"
        Me.RbDataRegular.UseVisualStyleBackColor = True
        '
        'RbDataAll
        '
        Me.RbDataAll.AutoSize = True
        Me.RbDataAll.Checked = True
        Me.RbDataAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbDataAll.Location = New System.Drawing.Point(13, 17)
        Me.RbDataAll.Name = "RbDataAll"
        Me.RbDataAll.Size = New System.Drawing.Size(36, 17)
        Me.RbDataAll.TabIndex = 6
        Me.RbDataAll.TabStop = True
        Me.RbDataAll.Text = "All"
        Me.RbDataAll.UseVisualStyleBackColor = True
        '
        'RbAPIon
        '
        Me.RbAPIon.AutoSize = True
        Me.RbAPIon.Location = New System.Drawing.Point(40, 261)
        Me.RbAPIon.Name = "RbAPIon"
        Me.RbAPIon.Size = New System.Drawing.Size(62, 17)
        Me.RbAPIon.TabIndex = 89
        Me.RbAPIon.Text = "A/P Ion"
        Me.RbAPIon.UseVisualStyleBackColor = True
        '
        'RbPRIon
        '
        Me.RbPRIon.AutoSize = True
        Me.RbPRIon.Location = New System.Drawing.Point(194, 261)
        Me.RbPRIon.Name = "RbPRIon"
        Me.RbPRIon.Size = New System.Drawing.Size(63, 17)
        Me.RbPRIon.TabIndex = 90
        Me.RbPRIon.Text = "P/R Ion"
        Me.RbPRIon.UseVisualStyleBackColor = True
        '
        'FrmAP510B
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(449, 403)
        Me.ControlBox = False
        Me.Controls.Add(Me.RbPRIon)
        Me.Controls.Add(Me.RbAPIon)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.RbPRCSV)
        Me.Controls.Add(Me.RbAPCSV)
        Me.Controls.Add(Me.RbPRWebster)
        Me.Controls.Add(Me.RbAPWebster)
        Me.Controls.Add(Me.RbAPBOAShort)
        Me.Controls.Add(Me.LblChkNum)
        Me.Controls.Add(Me.TxtChkTo)
        Me.Controls.Add(Me.LblChkTo)
        Me.Controls.Add(Me.TxtChkFrom)
        Me.Controls.Add(Me.LblChkFrom)
        Me.Controls.Add(Me.RbPRBOAShort)
        Me.Controls.Add(Me.RbPRBOA)
        Me.Controls.Add(Me.RbAPBOA)
        Me.Controls.Add(Me.RbAPTD)
        Me.Controls.Add(Me.RbPRTD)
        Me.Controls.Add(Me.RbAP)
        Me.Controls.Add(Me.DtPckTo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DtPckFrom)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtBank)
        Me.Controls.Add(Me.LnkBank)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAP510B"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
Private Sub FrmAP510B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  MyFrmAP510.SbpPgmID.Text = "AP510B"
  MyFrmAP510.SbpEnvironment.Text = myDBConnect.PgmDB
  DtPckFrom.Value = Date.Today
  DtPckTo.Value = Date.Today
  MyAP = True
End Sub
Private Sub FrmAP510B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
 MyFrmAP510.SbpScreen.Text = "AP510B"
End Sub
Private Sub FrmAP510B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
 Me.Refresh()
End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtBank, "")
  ErrProv.SetError(TxtChkTo, "")
  ErrProv.SetError(DtPckTo, "")
  ErrProv.SetError(LblFilePath, "")

  For I = 0 To ErrorField.GetUpperBound(0)
   Select Case ErrorField(I)
   Case "date"
    ErrProv.SetError(DtPckTo, ErrorMsg(I))
   Case "check"
    ErrProv.SetError(TxtChkTo, ErrorMsg(I))
   Case "bank"
    ErrProv.SetError(TxtBank, ErrorMsg(I))
   Case "path"
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

  If DtPckFrom.Value > DtPckTo.Value Then
   ErrorField(I) = "date"
   ErrorMsg(I) = "Invalid Date Range"
   I = I + 1
  End If

  If MyUtils.CnvSng(TxtChkFrom.Text) > MyUtils.CnvSng(TxtChkTo.Text) Then
   ErrorField(I) = "check"
   ErrorMsg(I) = "Invalid Check Range"
   I = I + 1
  End If

  If TxtBank.Text = String.Empty Then
   ErrorField(I) = "bank"
   ErrorMsg(I) = "Bank Code is required"
   I = I + 1
  End If

  If LblFilePath.Text = String.Empty Then
   ErrorField(I) = "path"
   ErrorMsg(I) = "File Path is required"
   I = I + 1
  End If
 End Sub
Private Sub FrmAP510B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
 If Not e.Alt Then Exit Sub

  If e.KeyCode = Keys.F12 Then
   MyUtils.PrtScreen(Form.ActiveForm)
  End If
End Sub
Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
 With SaveFileDialog1
  .ShowDialog()
  If .FileName <> String.Empty Then
   LblFilePath.Text = .FileName
  End If
 End With
End Sub

Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBank.LinkClicked
 MyFrmListApebnk = New FrmListApebnk
 MyFrmListApebnk.TxtPos.Text = TxtBank.Text
 MyFrmListApebnk.MdiParent = Me.ParentForm
 MyFrmListApebnk.Show()

End Sub
Private Sub RbAP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbAP.Click
  MyAP = True
End Sub
Private Sub RbAPTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbAPTD.Click
  MyAP = True
End Sub
Private Sub RbAPBOA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbAPBOA.Click
  MyAP = True
End Sub
Private Sub RbAPBOAShort_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbAPBOAShort.Click
  MyAP = True
End Sub
Private Sub RbAPWebster_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbAPWebster.Click
  MyAP = True
End Sub
Private Sub RbPRTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPRTD.Click
  MyAP = False
End Sub
Private Sub RbPRBOA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPRBOA.Click
  MyAP = False
End Sub
Private Sub RbPRBOAShort_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPRBOAShort.Click
  MyAP = False
End Sub
Private Sub RbPRWebster_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPRWebster.Click
  MyAP = False
End Sub
  Private Sub RbAPCSV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbAPCSV.Click
    MyAP = True
  End Sub
  Private Sub RbPRCSV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPRCSV.Click
    MyAP = False
  End Sub
  Private Sub RbAPIon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbAPIon.Click
    MyAP = True
  End Sub
  Private Sub RbPRIon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPRIon.Click
    MyAP = False
  End Sub
  Private Sub TxtChkFrom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtChkFrom.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtChkTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtChkTo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
End Class
