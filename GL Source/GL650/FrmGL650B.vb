Public Class FrmGL650B
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
Friend WithEvents TxtFromYear As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TxtFund As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents TxtDept As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents DtPckAsof As System.Windows.Forms.DateTimePicker
Friend WithEvents cbhideactual As System.Windows.Forms.CheckBox
Friend WithEvents GrpDownload As System.Windows.Forms.GroupBox
Friend WithEvents LblFilePath As System.Windows.Forms.Label
Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbOrig As System.Windows.Forms.RadioButton
Friend WithEvents RbAdopted As System.Windows.Forms.RadioButton
Friend WithEvents RbPrev2 As System.Windows.Forms.RadioButton
Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
Friend WithEvents LblToYear As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents RbVar As System.Windows.Forms.RadioButton
  Friend WithEvents ChkOmit As CheckBox
  Friend WithEvents RbPrev5 As RadioButton
  Friend WithEvents ChkPageDept As CheckBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtFromYear = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtFund = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtDept = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.DtPckAsof = New System.Windows.Forms.DateTimePicker()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.cbhideactual = New System.Windows.Forms.CheckBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbPrev5 = New System.Windows.Forms.RadioButton()
    Me.RbVar = New System.Windows.Forms.RadioButton()
    Me.RbOrig = New System.Windows.Forms.RadioButton()
    Me.RbAdopted = New System.Windows.Forms.RadioButton()
    Me.RbPrev2 = New System.Windows.Forms.RadioButton()
    Me.GrpDownload = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.LblToYear = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.ChkOmit = New System.Windows.Forms.CheckBox()
    Me.ChkPageDept = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GrpDownload.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtFromYear
    '
    Me.TxtFromYear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFromYear.Location = New System.Drawing.Point(145, 84)
    Me.TxtFromYear.MaxLength = 4
    Me.TxtFromYear.Name = "TxtFromYear"
    Me.TxtFromYear.Size = New System.Drawing.Size(40, 22)
    Me.TxtFromYear.TabIndex = 2
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(35, 88)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(105, 13)
    Me.Label3.TabIndex = 54
    Me.Label3.Text = "Budget Starting Year"
    '
    'TxtFund
    '
    Me.TxtFund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFund.Location = New System.Drawing.Point(145, 24)
    Me.TxtFund.MaxLength = 3
    Me.TxtFund.Name = "TxtFund"
    Me.TxtFund.Size = New System.Drawing.Size(30, 22)
    Me.TxtFund.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(35, 28)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(73, 18)
    Me.Label1.TabIndex = 56
    Me.Label1.Text = "Fund"
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(193, 55)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(56, 18)
    Me.Label4.TabIndex = 63
    Me.Label4.Text = "(Optional)"
    '
    'TxtDept
    '
    Me.TxtDept.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDept.Location = New System.Drawing.Point(145, 51)
    Me.TxtDept.MaxLength = 4
    Me.TxtDept.Name = "TxtDept"
    Me.TxtDept.Size = New System.Drawing.Size(40, 22)
    Me.TxtDept.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(35, 55)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(73, 18)
    Me.Label2.TabIndex = 62
    Me.Label2.Text = "Dept"
    '
    'DtPckAsof
    '
    Me.DtPckAsof.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckAsof.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckAsof.Location = New System.Drawing.Point(145, 112)
    Me.DtPckAsof.Name = "DtPckAsof"
    Me.DtPckAsof.Size = New System.Drawing.Size(88, 20)
    Me.DtPckAsof.TabIndex = 64
    Me.DtPckAsof.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(14, 116)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(127, 13)
    Me.Label5.TabIndex = 65
    Me.Label5.Text = "*Expense/Revenue as of"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(11, 269)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(208, 13)
    Me.Label6.TabIndex = 66
    Me.Label6.Text = "* = Enter ending date from last data refresh"
    '
    'cbhideactual
    '
    Me.cbhideactual.AutoSize = True
    Me.cbhideactual.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.cbhideactual.Location = New System.Drawing.Point(319, 129)
    Me.cbhideactual.Name = "cbhideactual"
    Me.cbhideactual.Size = New System.Drawing.Size(81, 17)
    Me.cbhideactual.TabIndex = 68
    Me.cbhideactual.Text = "Hide Actual"
    Me.cbhideactual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.cbhideactual.UseVisualStyleBackColor = True
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbPrev5)
    Me.GroupBox1.Controls.Add(Me.RbVar)
    Me.GroupBox1.Controls.Add(Me.RbOrig)
    Me.GroupBox1.Controls.Add(Me.RbAdopted)
    Me.GroupBox1.Controls.Add(Me.RbPrev2)
    Me.GroupBox1.Location = New System.Drawing.Point(289, 12)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(134, 111)
    Me.GroupBox1.TabIndex = 69
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Report Format"
    '
    'RbPrev5
    '
    Me.RbPrev5.AutoSize = True
    Me.RbPrev5.Location = New System.Drawing.Point(6, 89)
    Me.RbPrev5.Name = "RbPrev5"
    Me.RbPrev5.Size = New System.Drawing.Size(81, 17)
    Me.RbPrev5.TabIndex = 5
    Me.RbPrev5.Text = "Prev 5 Year"
    Me.RbPrev5.UseVisualStyleBackColor = True
    '
    'RbVar
    '
    Me.RbVar.AutoSize = True
    Me.RbVar.Location = New System.Drawing.Point(6, 73)
    Me.RbVar.Name = "RbVar"
    Me.RbVar.Size = New System.Drawing.Size(109, 17)
    Me.RbVar.TabIndex = 4
    Me.RbVar.Text = "...Variance (Col 2)"
    Me.RbVar.UseVisualStyleBackColor = True
    '
    'RbOrig
    '
    Me.RbOrig.AutoSize = True
    Me.RbOrig.Location = New System.Drawing.Point(6, 55)
    Me.RbOrig.Name = "RbOrig"
    Me.RbOrig.Size = New System.Drawing.Size(78, 17)
    Me.RbOrig.TabIndex = 2
    Me.RbOrig.Text = "...Original..."
    Me.RbOrig.UseVisualStyleBackColor = True
    '
    'RbAdopted
    '
    Me.RbAdopted.AutoSize = True
    Me.RbAdopted.Location = New System.Drawing.Point(6, 37)
    Me.RbAdopted.Name = "RbAdopted"
    Me.RbAdopted.Size = New System.Drawing.Size(74, 17)
    Me.RbAdopted.TabIndex = 1
    Me.RbAdopted.Text = "...Adopted"
    Me.RbAdopted.UseVisualStyleBackColor = True
    '
    'RbPrev2
    '
    Me.RbPrev2.AutoSize = True
    Me.RbPrev2.Checked = True
    Me.RbPrev2.Location = New System.Drawing.Point(6, 19)
    Me.RbPrev2.Name = "RbPrev2"
    Me.RbPrev2.Size = New System.Drawing.Size(76, 17)
    Me.RbPrev2.TabIndex = 0
    Me.RbPrev2.TabStop = True
    Me.RbPrev2.Text = "Prev 2 yr..."
    Me.RbPrev2.UseVisualStyleBackColor = True
    '
    'GrpDownload
    '
    Me.GrpDownload.Controls.Add(Me.LblFilePath)
    Me.GrpDownload.Controls.Add(Me.LnkFilePath)
    Me.GrpDownload.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpDownload.ForeColor = System.Drawing.Color.Black
    Me.GrpDownload.Location = New System.Drawing.Point(3, 213)
    Me.GrpDownload.Name = "GrpDownload"
    Me.GrpDownload.Size = New System.Drawing.Size(420, 41)
    Me.GrpDownload.TabIndex = 344
    Me.GrpDownload.TabStop = False
    Me.GrpDownload.Text = "Optional Export to CSV File:"
    '
    'LblFilePath
    '
    Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath.Location = New System.Drawing.Point(66, 16)
    Me.LblFilePath.Name = "LblFilePath"
    Me.LblFilePath.Size = New System.Drawing.Size(346, 16)
    Me.LblFilePath.TabIndex = 67
    '
    'LnkFilePath
    '
    Me.LnkFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePath.Location = New System.Drawing.Point(8, 16)
    Me.LnkFilePath.Name = "LnkFilePath"
    Me.LnkFilePath.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePath.TabIndex = 0
    Me.LnkFilePath.TabStop = True
    Me.LnkFilePath.Text = "File Path"
    '
    'LblToYear
    '
    Me.LblToYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblToYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblToYear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblToYear.Location = New System.Drawing.Point(206, 84)
    Me.LblToYear.Name = "LblToYear"
    Me.LblToYear.Size = New System.Drawing.Size(43, 22)
    Me.LblToYear.TabIndex = 346
    Me.LblToYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(193, 88)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(10, 13)
    Me.Label7.TabIndex = 345
    Me.Label7.Text = "-"
    '
    'ChkOmit
    '
    Me.ChkOmit.AutoSize = True
    Me.ChkOmit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkOmit.Location = New System.Drawing.Point(17, 141)
    Me.ChkOmit.Name = "ChkOmit"
    Me.ChkOmit.Size = New System.Drawing.Size(151, 17)
    Me.ChkOmit.TabIndex = 347
    Me.ChkOmit.Text = "Omit No activity (2 Years)?"
    Me.ChkOmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkOmit.UseVisualStyleBackColor = True
    '
    'ChkPageDept
    '
    Me.ChkPageDept.AutoSize = True
    Me.ChkPageDept.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPageDept.Location = New System.Drawing.Point(17, 176)
    Me.ChkPageDept.Name = "ChkPageDept"
    Me.ChkPageDept.Size = New System.Drawing.Size(208, 17)
    Me.ChkPageDept.TabIndex = 348
    Me.ChkPageDept.Text = "Summary: Page break by Department?"
    Me.ChkPageDept.UseVisualStyleBackColor = True
    Me.ChkPageDept.Visible = False
    '
    'FrmGL650B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(431, 312)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkPageDept)
    Me.Controls.Add(Me.ChkOmit)
    Me.Controls.Add(Me.LblToYear)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.GrpDownload)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.cbhideactual)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.DtPckAsof)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtDept)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtFund)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtFromYear)
    Me.Controls.Add(Me.Label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL650B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
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
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    PrtReport()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub FrmGL650B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    DtPckAsof.Value = Date.Today
  End Sub
  Private Sub FrmGL650B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGL650.SbpScreen.Text = "GL650B"
  End Sub
  Private Sub FrmGL650B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    ErrProv.SetError(TxtFund, "")
    ErrProv.SetError(TxtFromYear, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "fund"
          ErrProv.SetError(TxtFund, ErrorMsg(I))
        Case "year"
          ErrProv.SetError(TxtFromYear, ErrorMsg(I))
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

    If TxtFund.Text = "" Then
      ErrorField(I) = "fund"
      ErrorMsg(I) = "Invalid Fund"
      I = I + 1
    End If

    If TxtFromYear.Text = "" Then
      ErrorField(I) = "year"
      ErrorMsg(I) = "Invalid Year"
      I = I + 1
    End If

  End Sub
  Private Sub TxtFund_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFund.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDept_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDept.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFromYear_KeyUp(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles TxtFromYear.KeyUp
    LblToYear.Text = MyUtils.CnvSng(TxtFromYear.Text) + 1
  End Sub
  Private Sub LnkFilePath_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
    With SaveFileDialog1
      .ShowDialog()
      LblFilePath.Text = .FileName
    End With
  End Sub

  Private Sub RbOrig_CheckedChanged(sender As Object, e As EventArgs) Handles RbOrig.CheckedChanged
    If RbOrig.Checked = True Then
      ChkPageDept.Visible = True
    Else
      ChkPageDept.Visible = False
    End If
  End Sub
End Class
