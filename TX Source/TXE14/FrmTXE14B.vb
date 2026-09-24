Public Class FrmTXE14B
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
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents TxtToGLYear As System.Windows.Forms.TextBox
Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents ChkSuspense As System.Windows.Forms.CheckBox
Friend WithEvents TxtNo As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbAll As System.Windows.Forms.RadioButton
Friend WithEvents RbPrin As System.Windows.Forms.RadioButton
Friend WithEvents GrpDownload As System.Windows.Forms.GroupBox
Friend WithEvents LblFilePath As System.Windows.Forms.Label
Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbLoc As System.Windows.Forms.RadioButton
Friend WithEvents RbMail As System.Windows.Forms.RadioButton
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents ChkOmitStatus As System.Windows.Forms.CheckBox
Friend WithEvents TxtStatus As System.Windows.Forms.TextBox
Friend WithEvents LinkStatus As System.Windows.Forms.LinkLabel
Friend WithEvents ChkInGracePeriod As System.Windows.Forms.CheckBox
Friend WithEvents ChkCityState As System.Windows.Forms.CheckBox
  Friend WithEvents RbList As RadioButton
  Friend WithEvents DtPckAsof As System.Windows.Forms.DateTimePicker
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.DtPckAsof = New System.Windows.Forms.DateTimePicker()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtToGLYear = New System.Windows.Forms.TextBox()
    Me.TxtFromGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtTypes = New System.Windows.Forms.TextBox()
    Me.LnkTypes = New System.Windows.Forms.LinkLabel()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.ChkSuspense = New System.Windows.Forms.CheckBox()
    Me.TxtNo = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbAll = New System.Windows.Forms.RadioButton()
    Me.RbPrin = New System.Windows.Forms.RadioButton()
    Me.GrpDownload = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbList = New System.Windows.Forms.RadioButton()
    Me.RbLoc = New System.Windows.Forms.RadioButton()
    Me.RbMail = New System.Windows.Forms.RadioButton()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.ChkOmitStatus = New System.Windows.Forms.CheckBox()
    Me.TxtStatus = New System.Windows.Forms.TextBox()
    Me.LinkStatus = New System.Windows.Forms.LinkLabel()
    Me.ChkInGracePeriod = New System.Windows.Forms.CheckBox()
    Me.ChkCityState = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GrpDownload.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(32, 26)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(60, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "As of Date"
    '
    'DtPckAsof
    '
    Me.DtPckAsof.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckAsof.Location = New System.Drawing.Point(92, 22)
    Me.DtPckAsof.Name = "DtPckAsof"
    Me.DtPckAsof.Size = New System.Drawing.Size(88, 20)
    Me.DtPckAsof.TabIndex = 0
    Me.DtPckAsof.Value = New Date(2006, 9, 25, 0, 0, 0, 0)
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(235, 81)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(56, 16)
    Me.Label6.TabIndex = 33
    Me.Label6.Text = "(Optional)"
    '
    'TxtToGLYear
    '
    Me.TxtToGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtToGLYear.Location = New System.Drawing.Point(191, 77)
    Me.TxtToGLYear.MaxLength = 4
    Me.TxtToGLYear.Name = "TxtToGLYear"
    Me.TxtToGLYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtToGLYear.TabIndex = 3
    '
    'TxtFromGLYear
    '
    Me.TxtFromGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFromGLYear.Location = New System.Drawing.Point(119, 77)
    Me.TxtFromGLYear.MaxLength = 4
    Me.TxtFromGLYear.Name = "TxtFromGLYear"
    Me.TxtFromGLYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtFromGLYear.TabIndex = 2
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(167, 81)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(16, 16)
    Me.Label4.TabIndex = 32
    Me.Label4.Text = "to"
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(35, 81)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(84, 16)
    Me.Label7.TabIndex = 31
    Me.Label7.Text = "Grand List Year"
    '
    'TxtTypes
    '
    Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTypes.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTypes.Location = New System.Drawing.Point(119, 101)
    Me.TxtTypes.MaxLength = 20
    Me.TxtTypes.Name = "TxtTypes"
    Me.TxtTypes.Size = New System.Drawing.Size(148, 20)
    Me.TxtTypes.TabIndex = 4
    '
    'LnkTypes
    '
    Me.LnkTypes.Location = New System.Drawing.Point(35, 105)
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
    'ChkSuspense
    '
    Me.ChkSuspense.AutoSize = True
    Me.ChkSuspense.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkSuspense.Location = New System.Drawing.Point(35, 156)
    Me.ChkSuspense.Name = "ChkSuspense"
    Me.ChkSuspense.Size = New System.Drawing.Size(79, 17)
    Me.ChkSuspense.TabIndex = 7
    Me.ChkSuspense.Text = "Suspense?"
    '
    'TxtNo
    '
    Me.TxtNo.Location = New System.Drawing.Point(117, 52)
    Me.TxtNo.Name = "TxtNo"
    Me.TxtNo.Size = New System.Drawing.Size(40, 20)
    Me.TxtNo.TabIndex = 1
    Me.TxtNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(163, 55)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(79, 16)
    Me.Label2.TabIndex = 38
    Me.Label2.Text = "Delinquencies"
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(35, 55)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(76, 16)
    Me.Label3.TabIndex = 36
    Me.Label3.Text = "Enter the Top"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbAll)
    Me.GroupBox1.Controls.Add(Me.RbPrin)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(323, 12)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(177, 77)
    Me.GroupBox1.TabIndex = 39
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Report Format"
    '
    'RbAll
    '
    Me.RbAll.AutoSize = True
    Me.RbAll.Checked = True
    Me.RbAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbAll.Location = New System.Drawing.Point(11, 47)
    Me.RbAll.Name = "RbAll"
    Me.RbAll.Size = New System.Drawing.Size(153, 17)
    Me.RbAll.TabIndex = 1
    Me.RbAll.TabStop = True
    Me.RbAll.Text = "Principal, Interest && Penalty"
    Me.RbAll.UseVisualStyleBackColor = True
    '
    'RbPrin
    '
    Me.RbPrin.AutoSize = True
    Me.RbPrin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPrin.Location = New System.Drawing.Point(11, 24)
    Me.RbPrin.Name = "RbPrin"
    Me.RbPrin.Size = New System.Drawing.Size(112, 17)
    Me.RbPrin.TabIndex = 0
    Me.RbPrin.Text = "Principal Due Only"
    Me.RbPrin.UseVisualStyleBackColor = True
    '
    'GrpDownload
    '
    Me.GrpDownload.Controls.Add(Me.LblFilePath)
    Me.GrpDownload.Controls.Add(Me.LnkFilePath)
    Me.GrpDownload.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpDownload.ForeColor = System.Drawing.Color.Black
    Me.GrpDownload.Location = New System.Drawing.Point(35, 224)
    Me.GrpDownload.Name = "GrpDownload"
    Me.GrpDownload.Size = New System.Drawing.Size(429, 44)
    Me.GrpDownload.TabIndex = 310
    Me.GrpDownload.TabStop = False
    Me.GrpDownload.Text = "Optional: Report Detail Records File (CSV)"
    '
    'LblFilePath
    '
    Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath.Location = New System.Drawing.Point(68, 16)
    Me.LblFilePath.Name = "LblFilePath"
    Me.LblFilePath.Size = New System.Drawing.Size(346, 16)
    Me.LblFilePath.TabIndex = 67
    '
    'LnkFilePath
    '
    Me.LnkFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePath.Location = New System.Drawing.Point(10, 16)
    Me.LnkFilePath.Name = "LnkFilePath"
    Me.LnkFilePath.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePath.TabIndex = 0
    Me.LnkFilePath.TabStop = True
    Me.LnkFilePath.Text = "File Path"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbList)
    Me.GroupBox2.Controls.Add(Me.RbLoc)
    Me.GroupBox2.Controls.Add(Me.RbMail)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(323, 95)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(177, 100)
    Me.GroupBox2.TabIndex = 311
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Group by"
    '
    'RbList
    '
    Me.RbList.AutoSize = True
    Me.RbList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbList.Location = New System.Drawing.Point(11, 70)
    Me.RbList.Name = "RbList"
    Me.RbList.Size = New System.Drawing.Size(85, 17)
    Me.RbList.TabIndex = 2
    Me.RbList.Text = "List Number*"
    Me.RbList.UseVisualStyleBackColor = True
    '
    'RbLoc
    '
    Me.RbLoc.AutoSize = True
    Me.RbLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbLoc.Location = New System.Drawing.Point(11, 47)
    Me.RbLoc.Name = "RbLoc"
    Me.RbLoc.Size = New System.Drawing.Size(112, 17)
    Me.RbLoc.TabIndex = 1
    Me.RbLoc.Text = "Property Location*"
    Me.RbLoc.UseVisualStyleBackColor = True
    '
    'RbMail
    '
    Me.RbMail.AutoSize = True
    Me.RbMail.Checked = True
    Me.RbMail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbMail.Location = New System.Drawing.Point(11, 24)
    Me.RbMail.Name = "RbMail"
    Me.RbMail.Size = New System.Drawing.Size(99, 17)
    Me.RbMail.TabIndex = 0
    Me.RbMail.TabStop = True
    Me.RbMail.Text = "Mailing Address"
    Me.RbMail.UseVisualStyleBackColor = True
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(12, 271)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(197, 13)
    Me.Label5.TabIndex = 312
    Me.Label5.Text = "* Option is NOT valid for Motor Vehicles "
    '
    'ChkOmitStatus
    '
    Me.ChkOmitStatus.AutoSize = True
    Me.ChkOmitStatus.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkOmitStatus.Location = New System.Drawing.Point(254, 130)
    Me.ChkOmitStatus.Name = "ChkOmitStatus"
    Me.ChkOmitStatus.Size = New System.Drawing.Size(53, 17)
    Me.ChkOmitStatus.TabIndex = 6
    Me.ChkOmitStatus.Text = "Omit?"
    Me.ChkOmitStatus.UseVisualStyleBackColor = True
    '
    'TxtStatus
    '
    Me.TxtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtStatus.Location = New System.Drawing.Point(119, 127)
    Me.TxtStatus.MaxLength = 20
    Me.TxtStatus.Name = "TxtStatus"
    Me.TxtStatus.Size = New System.Drawing.Size(129, 20)
    Me.TxtStatus.TabIndex = 5
    '
    'LinkStatus
    '
    Me.LinkStatus.AutoSize = True
    Me.LinkStatus.Location = New System.Drawing.Point(12, 130)
    Me.LinkStatus.Name = "LinkStatus"
    Me.LinkStatus.Size = New System.Drawing.Size(103, 13)
    Me.LinkStatus.TabIndex = 315
    Me.LinkStatus.TabStop = True
    Me.LinkStatus.Text = "Select Status Codes"
    '
    'ChkInGracePeriod
    '
    Me.ChkInGracePeriod.AutoSize = True
    Me.ChkInGracePeriod.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkInGracePeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkInGracePeriod.Location = New System.Drawing.Point(35, 178)
    Me.ChkInGracePeriod.Name = "ChkInGracePeriod"
    Me.ChkInGracePeriod.Size = New System.Drawing.Size(106, 17)
    Me.ChkInGracePeriod.TabIndex = 316
    Me.ChkInGracePeriod.Text = "In Grace Period?"
    '
    'ChkCityState
    '
    Me.ChkCityState.AutoSize = True
    Me.ChkCityState.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkCityState.Location = New System.Drawing.Point(323, 201)
    Me.ChkCityState.Name = "ChkCityState"
    Me.ChkCityState.Size = New System.Drawing.Size(141, 17)
    Me.ChkCityState.TabIndex = 317
    Me.ChkCityState.Text = "Report: Omit City/State?"
    '
    'FrmTXE14B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(502, 293)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkCityState)
    Me.Controls.Add(Me.ChkInGracePeriod)
    Me.Controls.Add(Me.ChkOmitStatus)
    Me.Controls.Add(Me.TxtStatus)
    Me.Controls.Add(Me.LinkStatus)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GrpDownload)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.TxtNo)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.ChkSuspense)
    Me.Controls.Add(Me.TxtTypes)
    Me.Controls.Add(Me.LnkTypes)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.TxtToGLYear)
    Me.Controls.Add(Me.TxtFromGLYear)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.DtPckAsof)
    Me.Controls.Add(Me.Label1)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXE14B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GrpDownload.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTXE14B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTXE14.SbpScreen.Text = "TXE14"
End Sub
Private Sub FrmTXE14B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtNo, "")
    ErrProv.SetError(TxtFromGLYear, "")
    ErrProv.SetError(TxtToGLYear, "")
    ErrProv.SetError(TxtTypes, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "no"
        ErrProv.SetError(TxtNo, ErrorMsg(I))
      Case "fromglyear"
        ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
      Case "toglyear"
        ErrProv.SetError(TxtToGLYear, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtNo.Text) = 0 Then
      ErrorField(I) = "no"
      ErrorMsg(I) = "Top No cannot be blank or zero"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtFromGLYear.Text) > MyUtils.CnvSng(TxtToGLYear.Text) Then
      ErrorField(I) = "fromglyear"
      ErrorMsg(I) = "Invalid Year Range"
      I = I + 1
      ErrorField(I) = "toglyear"
      ErrorMsg(I) = "Invalid Year Range"
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
Private Sub FrmTXE14B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  MyTypes = ""
  TxtNo.Text = "50"
  DtPckAsof.Value = Today.Date
End Sub

Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
  MyTypes = TxtTypes.Text
  MyFrmSelTypes = New FrmSelTypes
  MyFrmSelTypes.MdiParent = Me.ParentForm
  MyFrmSelTypes.Show()
  Me.Hide()

End Sub
Private Sub TxtNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtFromGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtToGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
  With SaveFileDialog1
    .ShowDialog()
    LblFilePath.Text = .FileName
  End With
End Sub

Private Sub LinkStatus_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkStatus.LinkClicked
  MySts = TxtStatus.Text
  MyFrmStatus = New FrmStatus
  MyFrmStatus.MdiParent = Me.ParentForm
  MyFrmStatus.Show()
End Sub
End Class






