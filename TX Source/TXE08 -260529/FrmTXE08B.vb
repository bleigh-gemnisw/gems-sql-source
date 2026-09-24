Public Class FrmTXE08B
  Inherits System.Windows.Forms.Form
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbDetNoprint As System.Windows.Forms.RadioButton
  Friend WithEvents RbDetSplit As System.Windows.Forms.RadioButton
  Friend WithEvents RbDetCombine As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents RbTotCombine As System.Windows.Forms.RadioButton
  Friend WithEvents RbTotSplit As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents RbAuditRefund As System.Windows.Forms.RadioButton
  Friend WithEvents RbAuditAdj As System.Windows.Forms.RadioButton
  Friend WithEvents GrpDownload As GroupBox
  Friend WithEvents LblFilePath As Label
  Friend WithEvents LnkFilePath As LinkLabel
  Friend WithEvents SaveFileDialog1 As SaveFileDialog
  Friend WithEvents LnkDistrict As LinkLabel
  Friend WithEvents TxtPhase As TextBox
  Friend WithEvents Label12 As Label
  Friend WithEvents TxtDist As TextBox
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
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtToGLYear As System.Windows.Forms.TextBox
  Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
  Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtToGLYear = New System.Windows.Forms.TextBox()
    Me.LnkTypes = New System.Windows.Forms.LinkLabel()
    Me.TxtFromGLYear = New System.Windows.Forms.TextBox()
    Me.TxtTypes = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbDetNoprint = New System.Windows.Forms.RadioButton()
    Me.RbDetSplit = New System.Windows.Forms.RadioButton()
    Me.RbDetCombine = New System.Windows.Forms.RadioButton()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbTotCombine = New System.Windows.Forms.RadioButton()
    Me.RbTotSplit = New System.Windows.Forms.RadioButton()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.RbAuditRefund = New System.Windows.Forms.RadioButton()
    Me.RbAuditAdj = New System.Windows.Forms.RadioButton()
    Me.GrpDownload = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.LnkDistrict = New System.Windows.Forms.LinkLabel()
    Me.TxtPhase = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.GroupBox3.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.GrpDownload.SuspendLayout()
    Me.SuspendLayout()
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.DtPckTo)
    Me.GroupBox3.Controls.Add(Me.Label2)
    Me.GroupBox3.Controls.Add(Me.DtPckFrom)
    Me.GroupBox3.Controls.Add(Me.Label1)
    Me.GroupBox3.Location = New System.Drawing.Point(21, 21)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(300, 52)
    Me.GroupBox3.TabIndex = 0
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Payment Date Range"
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
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(165, 83)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(20, 16)
    Me.Label3.TabIndex = 26
    Me.Label3.Text = "To "
    '
    'TxtToGLYear
    '
    Me.TxtToGLYear.Location = New System.Drawing.Point(191, 79)
    Me.TxtToGLYear.MaxLength = 4
    Me.TxtToGLYear.Name = "TxtToGLYear"
    Me.TxtToGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtToGLYear.TabIndex = 2
    '
    'LnkTypes
    '
    Me.LnkTypes.Location = New System.Drawing.Point(21, 113)
    Me.LnkTypes.Name = "LnkTypes"
    Me.LnkTypes.Size = New System.Drawing.Size(72, 16)
    Me.LnkTypes.TabIndex = 25
    Me.LnkTypes.TabStop = True
    Me.LnkTypes.Text = "Select Types"
    '
    'TxtFromGLYear
    '
    Me.TxtFromGLYear.Location = New System.Drawing.Point(117, 79)
    Me.TxtFromGLYear.MaxLength = 4
    Me.TxtFromGLYear.Name = "TxtFromGLYear"
    Me.TxtFromGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtFromGLYear.TabIndex = 1
    '
    'TxtTypes
    '
    Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTypes.Location = New System.Drawing.Point(97, 109)
    Me.TxtTypes.MaxLength = 20
    Me.TxtTypes.Name = "TxtTypes"
    Me.TxtTypes.Size = New System.Drawing.Size(116, 20)
    Me.TxtTypes.TabIndex = 3
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(21, 83)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(84, 16)
    Me.Label4.TabIndex = 24
    Me.Label4.Text = "Grand List Year"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbDetNoprint)
    Me.GroupBox1.Controls.Add(Me.RbDetSplit)
    Me.GroupBox1.Controls.Add(Me.RbDetCombine)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(352, 83)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(157, 87)
    Me.GroupBox1.TabIndex = 32
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Detail Report"
    '
    'RbDetNoprint
    '
    Me.RbDetNoprint.AutoSize = True
    Me.RbDetNoprint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbDetNoprint.Location = New System.Drawing.Point(11, 61)
    Me.RbDetNoprint.Name = "RbDetNoprint"
    Me.RbDetNoprint.Size = New System.Drawing.Size(97, 17)
    Me.RbDetNoprint.TabIndex = 34
    Me.RbDetNoprint.Text = "No detail report"
    Me.RbDetNoprint.UseVisualStyleBackColor = True
    '
    'RbDetSplit
    '
    Me.RbDetSplit.AutoSize = True
    Me.RbDetSplit.Checked = True
    Me.RbDetSplit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbDetSplit.Location = New System.Drawing.Point(11, 15)
    Me.RbDetSplit.Name = "RbDetSplit"
    Me.RbDetSplit.Size = New System.Drawing.Size(134, 17)
    Me.RbDetSplit.TabIndex = 33
    Me.RbDetSplit.TabStop = True
    Me.RbDetSplit.Text = "Split Regular/Susp/CR"
    Me.RbDetSplit.UseVisualStyleBackColor = True
    '
    'RbDetCombine
    '
    Me.RbDetCombine.AutoSize = True
    Me.RbDetCombine.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbDetCombine.Location = New System.Drawing.Point(11, 38)
    Me.RbDetCombine.Name = "RbDetCombine"
    Me.RbDetCombine.Size = New System.Drawing.Size(131, 17)
    Me.RbDetCombine.TabIndex = 32
    Me.RbDetCombine.Text = "Combined into 1 report"
    Me.RbDetCombine.UseVisualStyleBackColor = True
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbTotCombine)
    Me.GroupBox2.Controls.Add(Me.RbTotSplit)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(352, 12)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(157, 61)
    Me.GroupBox2.TabIndex = 33
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Totals Reports"
    '
    'RbTotCombine
    '
    Me.RbTotCombine.AutoSize = True
    Me.RbTotCombine.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbTotCombine.Location = New System.Drawing.Point(11, 38)
    Me.RbTotCombine.Name = "RbTotCombine"
    Me.RbTotCombine.Size = New System.Drawing.Size(131, 17)
    Me.RbTotCombine.TabIndex = 35
    Me.RbTotCombine.Text = "Combined into 1 report"
    Me.RbTotCombine.UseVisualStyleBackColor = True
    '
    'RbTotSplit
    '
    Me.RbTotSplit.AutoSize = True
    Me.RbTotSplit.Checked = True
    Me.RbTotSplit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbTotSplit.Location = New System.Drawing.Point(11, 19)
    Me.RbTotSplit.Name = "RbTotSplit"
    Me.RbTotSplit.Size = New System.Drawing.Size(134, 17)
    Me.RbTotSplit.TabIndex = 34
    Me.RbTotSplit.TabStop = True
    Me.RbTotSplit.Text = "Split Regular/Susp/CR"
    Me.RbTotSplit.UseVisualStyleBackColor = True
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.RbAuditRefund)
    Me.GroupBox4.Controls.Add(Me.RbAuditAdj)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(352, 176)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(157, 61)
    Me.GroupBox4.TabIndex = 34
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Audit Report format"
    '
    'RbAuditRefund
    '
    Me.RbAuditRefund.AutoSize = True
    Me.RbAuditRefund.Checked = True
    Me.RbAuditRefund.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbAuditRefund.Location = New System.Drawing.Point(11, 38)
    Me.RbAuditRefund.Name = "RbAuditRefund"
    Me.RbAuditRefund.Size = New System.Drawing.Size(117, 17)
    Me.RbAuditRefund.TabIndex = 35
    Me.RbAuditRefund.TabStop = True
    Me.RbAuditRefund.Text = "Show Refund Total"
    Me.RbAuditRefund.UseVisualStyleBackColor = True
    '
    'RbAuditAdj
    '
    Me.RbAuditAdj.AutoSize = True
    Me.RbAuditAdj.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbAuditAdj.Location = New System.Drawing.Point(11, 19)
    Me.RbAuditAdj.Name = "RbAuditAdj"
    Me.RbAuditAdj.Size = New System.Drawing.Size(126, 17)
    Me.RbAuditAdj.TabIndex = 34
    Me.RbAuditAdj.Text = "Show Adjusted Total "
    Me.RbAuditAdj.UseVisualStyleBackColor = True
    '
    'GrpDownload
    '
    Me.GrpDownload.Controls.Add(Me.LblFilePath)
    Me.GrpDownload.Controls.Add(Me.LnkFilePath)
    Me.GrpDownload.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpDownload.ForeColor = System.Drawing.Color.Black
    Me.GrpDownload.Location = New System.Drawing.Point(12, 243)
    Me.GrpDownload.Name = "GrpDownload"
    Me.GrpDownload.Size = New System.Drawing.Size(429, 47)
    Me.GrpDownload.TabIndex = 310
    Me.GrpDownload.TabStop = False
    Me.GrpDownload.Text = "Download Detail File (optional)"
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
    'LnkDistrict
    '
    Me.LnkDistrict.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkDistrict.Location = New System.Drawing.Point(53, 144)
    Me.LnkDistrict.Name = "LnkDistrict"
    Me.LnkDistrict.Size = New System.Drawing.Size(40, 16)
    Me.LnkDistrict.TabIndex = 314
    Me.LnkDistrict.TabStop = True
    Me.LnkDistrict.Text = "District"
    '
    'TxtPhase
    '
    Me.TxtPhase.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPhase.Location = New System.Drawing.Point(183, 139)
    Me.TxtPhase.MaxLength = 1
    Me.TxtPhase.Name = "TxtPhase"
    Me.TxtPhase.Size = New System.Drawing.Size(16, 22)
    Me.TxtPhase.TabIndex = 312
    '
    'Label12
    '
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(133, 144)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(44, 14)
    Me.Label12.TabIndex = 313
    Me.Label12.Text = "Phase"
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(99, 141)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(28, 20)
    Me.TxtDist.TabIndex = 311
    '
    'FrmTXE08B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(521, 304)
    Me.ControlBox = False
    Me.Controls.Add(Me.LnkDistrict)
    Me.Controls.Add(Me.TxtPhase)
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.GrpDownload)
    Me.Controls.Add(Me.GroupBox4)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtToGLYear)
    Me.Controls.Add(Me.LnkTypes)
    Me.Controls.Add(Me.TxtFromGLYear)
    Me.Controls.Add(Me.TxtTypes)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.GroupBox3)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXE08B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Balance Sheet"
    Me.GroupBox3.ResumeLayout(False)
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
    Me.GrpDownload.ResumeLayout(False)
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
    System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
    Application.DoEvents()
    PrtReport()
    System.Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub FrmTXE08_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    DtPckFrom.Value = Date.Today
    DtPckTo.Value = Date.Today
  End Sub
  Private Sub FrmTXE08B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXE08.SbpScreen.Text = "TXE08B"
  End Sub
  Private Sub LnkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
    MyTypes = TxtTypes.Text
    myFrmSelTypes = New FrmSelTypes
    myFrmSelTypes.MdiParent = Me.ParentForm
    myFrmSelTypes.Show()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFromGLYear, "")
    ErrProv.SetError(TxtToGLYear, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "fromglyear"
          ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
        Case "fromglyear"
          ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
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

  End Sub
  Private Sub TxtFromGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromGLYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtToGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToGLYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Private Sub LnkFilePath_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
    With SaveFileDialog1
      .ShowDialog()
      LblFilePath.Text = .FileName
    End With
  End Sub

  Private Sub LnkDistrict_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkDistrict.LinkClicked
    MyFrmListDist = New FrmListDist
    MyFrmListDist.MdiParent = Me.ParentForm
    MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
    MyFrmListDist.Show()
    Me.Hide()
  End Sub
End Class
