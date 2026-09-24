Public Class FrmTAP30B
  Inherits System.Windows.Forms.Form

  Friend ds As DataSet = New DataSet

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

Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents ChkPropCode As System.Windows.Forms.CheckBox
Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbSortList As System.Windows.Forms.RadioButton
Friend WithEvents ChkExemptCode As System.Windows.Forms.CheckBox
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents RbOtherNo As System.Windows.Forms.RadioButton
Friend WithEvents RbOtherNormal As System.Windows.Forms.RadioButton
Friend WithEvents RbOtherDown As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
Friend WithEvents RbMVNo As System.Windows.Forms.RadioButton
Friend WithEvents RbMVNormal As System.Windows.Forms.RadioButton
Friend WithEvents RbMVDown As System.Windows.Forms.RadioButton
Friend WithEvents ChkMissing As System.Windows.Forms.CheckBox
Friend WithEvents ChkName As System.Windows.Forms.CheckBox
Friend WithEvents ChkLoc As System.Windows.Forms.CheckBox
Friend WithEvents ChkMailAddr As System.Windows.Forms.CheckBox
    Friend WithEvents ChkBackup As System.Windows.Forms.CheckBox
    Friend WithEvents ChkZero As System.Windows.Forms.CheckBox
  Friend WithEvents ChkComments As CheckBox
    Friend WithEvents GrpFile As GroupBox
    Friend WithEvents LblFilePath As Label
    Friend WithEvents LnkFilePath As LinkLabel
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.ChkComments = New System.Windows.Forms.CheckBox()
    Me.ChkMailAddr = New System.Windows.Forms.CheckBox()
    Me.ChkLoc = New System.Windows.Forms.CheckBox()
    Me.ChkName = New System.Windows.Forms.CheckBox()
    Me.ChkExemptCode = New System.Windows.Forms.CheckBox()
    Me.ChkPropCode = New System.Windows.Forms.CheckBox()
    Me.ChkPost = New System.Windows.Forms.CheckBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbSortList = New System.Windows.Forms.RadioButton()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.RbMVNo = New System.Windows.Forms.RadioButton()
    Me.RbMVDown = New System.Windows.Forms.RadioButton()
    Me.RbMVNormal = New System.Windows.Forms.RadioButton()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.RbOtherNo = New System.Windows.Forms.RadioButton()
    Me.RbOtherDown = New System.Windows.Forms.RadioButton()
    Me.RbOtherNormal = New System.Windows.Forms.RadioButton()
    Me.ChkMissing = New System.Windows.Forms.CheckBox()
    Me.ChkBackup = New System.Windows.Forms.CheckBox()
    Me.ChkZero = New System.Windows.Forms.CheckBox()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.GrpFile = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.GrpFile.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(43, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(414, 48)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Update Personal Property file with Assessment values, codes or exemptions importe" &
    "d from Personal Property Declaration File. "
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.ChkComments)
    Me.GroupBox1.Controls.Add(Me.ChkMailAddr)
    Me.GroupBox1.Controls.Add(Me.ChkLoc)
    Me.GroupBox1.Controls.Add(Me.ChkName)
    Me.GroupBox1.Controls.Add(Me.ChkExemptCode)
    Me.GroupBox1.Controls.Add(Me.ChkPropCode)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox1.Location = New System.Drawing.Point(46, 119)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(503, 87)
    Me.GroupBox1.TabIndex = 0
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Information to Import"
    '
    'ChkComments
    '
    Me.ChkComments.AutoSize = True
    Me.ChkComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkComments.ForeColor = System.Drawing.SystemColors.WindowText
    Me.ChkComments.Location = New System.Drawing.Point(265, 57)
    Me.ChkComments.Name = "ChkComments"
    Me.ChkComments.Size = New System.Drawing.Size(146, 17)
    Me.ChkComments.TabIndex = 9
    Me.ChkComments.Text = "Comments (Overlay Daily)"
    '
    'ChkMailAddr
    '
    Me.ChkMailAddr.AutoSize = True
    Me.ChkMailAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkMailAddr.ForeColor = System.Drawing.SystemColors.WindowText
    Me.ChkMailAddr.Location = New System.Drawing.Point(11, 39)
    Me.ChkMailAddr.Name = "ChkMailAddr"
    Me.ChkMailAddr.Size = New System.Drawing.Size(224, 17)
    Me.ChkMailAddr.TabIndex = 4
    Me.ChkMailAddr.Text = "Question 1 Addr (Decl) ==> Maint Str Addr"
    '
    'ChkLoc
    '
    Me.ChkLoc.AutoSize = True
    Me.ChkLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkLoc.ForeColor = System.Drawing.SystemColors.WindowText
    Me.ChkLoc.Location = New System.Drawing.Point(11, 57)
    Me.ChkLoc.Name = "ChkLoc"
    Me.ChkLoc.Size = New System.Drawing.Size(109, 17)
    Me.ChkLoc.TabIndex = 3
    Me.ChkLoc.Text = "Property Location"
    '
    'ChkName
    '
    Me.ChkName.AutoSize = True
    Me.ChkName.Checked = True
    Me.ChkName.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkName.ForeColor = System.Drawing.SystemColors.WindowText
    Me.ChkName.Location = New System.Drawing.Point(11, 21)
    Me.ChkName.Name = "ChkName"
    Me.ChkName.Size = New System.Drawing.Size(127, 17)
    Me.ChkName.TabIndex = 2
    Me.ChkName.Text = "Name/Second Name"
    '
    'ChkExemptCode
    '
    Me.ChkExemptCode.AutoSize = True
    Me.ChkExemptCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkExemptCode.ForeColor = System.Drawing.SystemColors.WindowText
    Me.ChkExemptCode.Location = New System.Drawing.Point(265, 39)
    Me.ChkExemptCode.Name = "ChkExemptCode"
    Me.ChkExemptCode.Size = New System.Drawing.Size(80, 17)
    Me.ChkExemptCode.TabIndex = 1
    Me.ChkExemptCode.Text = "Exemptions"
    '
    'ChkPropCode
    '
    Me.ChkPropCode.AutoSize = True
    Me.ChkPropCode.Checked = True
    Me.ChkPropCode.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkPropCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkPropCode.ForeColor = System.Drawing.SystemColors.WindowText
    Me.ChkPropCode.Location = New System.Drawing.Point(265, 20)
    Me.ChkPropCode.Name = "ChkPropCode"
    Me.ChkPropCode.Size = New System.Drawing.Size(163, 17)
    Me.ChkPropCode.TabIndex = 0
    Me.ChkPropCode.Text = "Property Codes and Amounts"
    '
    'ChkPost
    '
    Me.ChkPost.Location = New System.Drawing.Point(14, 317)
    Me.ChkPost.Name = "ChkPost"
    Me.ChkPost.Size = New System.Drawing.Size(95, 24)
    Me.ChkPost.TabIndex = 3
    Me.ChkPost.TabStop = False
    Me.ChkPost.Text = "Post to File?"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbSortList)
    Me.GroupBox2.Controls.Add(Me.RbSortName)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox2.Location = New System.Drawing.Point(555, 9)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(135, 88)
    Me.GroupBox2.TabIndex = 1
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Report Order"
    '
    'RbSortList
    '
    Me.RbSortList.Checked = True
    Me.RbSortList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortList.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbSortList.Location = New System.Drawing.Point(20, 28)
    Me.RbSortList.Name = "RbSortList"
    Me.RbSortList.Size = New System.Drawing.Size(70, 20)
    Me.RbSortList.TabIndex = 0
    Me.RbSortList.TabStop = True
    Me.RbSortList.Text = "List #"
    '
    'RbSortName
    '
    Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortName.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbSortName.Location = New System.Drawing.Point(20, 54)
    Me.RbSortName.Name = "RbSortName"
    Me.RbSortName.Size = New System.Drawing.Size(106, 20)
    Me.RbSortName.TabIndex = 1
    Me.RbSortName.Text = "Name"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.RbMVNo)
    Me.GroupBox3.Controls.Add(Me.RbMVDown)
    Me.GroupBox3.Controls.Add(Me.RbMVNormal)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(12, 221)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(283, 83)
    Me.GroupBox3.TabIndex = 208
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Only Property Codes 9 and 24 (MV)"
    '
    'RbMVNo
    '
    Me.RbMVNo.AutoSize = True
    Me.RbMVNo.Checked = True
    Me.RbMVNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbMVNo.Location = New System.Drawing.Point(7, 19)
    Me.RbMVNo.Name = "RbMVNo"
    Me.RbMVNo.Size = New System.Drawing.Size(88, 17)
    Me.RbMVNo.TabIndex = 60
    Me.RbMVNo.TabStop = True
    Me.RbMVNo.Text = "No Rounding"
    Me.RbMVNo.UseVisualStyleBackColor = True
    '
    'RbMVDown
    '
    Me.RbMVDown.AutoSize = True
    Me.RbMVDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbMVDown.Location = New System.Drawing.Point(7, 59)
    Me.RbMVDown.Name = "RbMVDown"
    Me.RbMVDown.Size = New System.Drawing.Size(253, 17)
    Me.RbMVDown.TabIndex = 58
    Me.RbMVDown.Text = "Truncate Down (IE: 103 ==> 100,  105 ==> 100)"
    Me.RbMVDown.UseVisualStyleBackColor = True
    '
    'RbMVNormal
    '
    Me.RbMVNormal.AutoSize = True
    Me.RbMVNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbMVNormal.Location = New System.Drawing.Point(7, 39)
    Me.RbMVNormal.Name = "RbMVNormal"
    Me.RbMVNormal.Size = New System.Drawing.Size(258, 17)
    Me.RbMVNormal.TabIndex = 59
    Me.RbMVNormal.Text = "Normal Rounding (IE: 103 ==> 100, 105 ==> 110)"
    Me.RbMVNormal.UseVisualStyleBackColor = True
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.RbOtherNo)
    Me.GroupBox4.Controls.Add(Me.RbOtherDown)
    Me.GroupBox4.Controls.Add(Me.RbOtherNormal)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(311, 221)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(291, 83)
    Me.GroupBox4.TabIndex = 209
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "All other Property Codes (excludes 9, 24, 25)"
    '
    'RbOtherNo
    '
    Me.RbOtherNo.AutoSize = True
    Me.RbOtherNo.Checked = True
    Me.RbOtherNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbOtherNo.Location = New System.Drawing.Point(7, 19)
    Me.RbOtherNo.Name = "RbOtherNo"
    Me.RbOtherNo.Size = New System.Drawing.Size(88, 17)
    Me.RbOtherNo.TabIndex = 60
    Me.RbOtherNo.TabStop = True
    Me.RbOtherNo.Text = "No Rounding"
    Me.RbOtherNo.UseVisualStyleBackColor = True
    '
    'RbOtherDown
    '
    Me.RbOtherDown.AutoSize = True
    Me.RbOtherDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbOtherDown.Location = New System.Drawing.Point(7, 59)
    Me.RbOtherDown.Name = "RbOtherDown"
    Me.RbOtherDown.Size = New System.Drawing.Size(253, 17)
    Me.RbOtherDown.TabIndex = 58
    Me.RbOtherDown.Text = "Truncate Down (IE: 103 ==> 100,  105 ==> 100)"
    Me.RbOtherDown.UseVisualStyleBackColor = True
    '
    'RbOtherNormal
    '
    Me.RbOtherNormal.AutoSize = True
    Me.RbOtherNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbOtherNormal.Location = New System.Drawing.Point(7, 39)
    Me.RbOtherNormal.Name = "RbOtherNormal"
    Me.RbOtherNormal.Size = New System.Drawing.Size(258, 17)
    Me.RbOtherNormal.TabIndex = 59
    Me.RbOtherNormal.Text = "Normal Rounding (IE: 103 ==> 100, 105 ==> 110)"
    Me.RbOtherNormal.UseVisualStyleBackColor = True
    '
    'ChkMissing
    '
    Me.ChkMissing.AutoSize = True
    Me.ChkMissing.Enabled = False
    Me.ChkMissing.Location = New System.Drawing.Point(33, 347)
    Me.ChkMissing.Name = "ChkMissing"
    Me.ChkMissing.Size = New System.Drawing.Size(466, 17)
    Me.ChkMissing.TabIndex = 210
    Me.ChkMissing.TabStop = False
    Me.ChkMissing.Text = "Update missing filers? (Clear Assessments/Exemptions values for Accts without a D" &
    "eclaration)"
    '
    'ChkBackup
    '
    Me.ChkBackup.AutoSize = True
    Me.ChkBackup.Location = New System.Drawing.Point(124, 321)
    Me.ChkBackup.Name = "ChkBackup"
    Me.ChkBackup.Size = New System.Drawing.Size(189, 17)
    Me.ChkBackup.TabIndex = 211
    Me.ChkBackup.Text = "Create a Backup file? (CAMPPRP)"
    '
    'ChkZero
    '
    Me.ChkZero.AutoSize = True
    Me.ChkZero.Enabled = False
    Me.ChkZero.Location = New System.Drawing.Point(33, 370)
    Me.ChkZero.Name = "ChkZero"
    Me.ChkZero.Size = New System.Drawing.Size(228, 17)
    Me.ChkZero.TabIndex = 212
    Me.ChkZero.TabStop = False
    Me.ChkZero.Text = "Update zero value filers? (Active/Increase)"
    '
    'GrpFile
    '
    Me.GrpFile.Controls.Add(Me.LblFilePath)
    Me.GrpFile.Controls.Add(Me.LnkFilePath)
    Me.GrpFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpFile.Location = New System.Drawing.Point(49, 57)
    Me.GrpFile.Name = "GrpFile"
    Me.GrpFile.Size = New System.Drawing.Size(408, 56)
    Me.GrpFile.TabIndex = 213
    Me.GrpFile.TabStop = False
    Me.GrpFile.Text = "Declaration File Details"
    '
    'LblFilePath
    '
    Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath.Location = New System.Drawing.Point(72, 16)
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
    Me.LnkFilePath.TabIndex = 65
    Me.LnkFilePath.TabStop = True
    Me.LnkFilePath.Text = "File Path"
    '
    'FrmTAP30B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(702, 398)
    Me.ControlBox = False
    Me.Controls.Add(Me.GrpFile)
    Me.Controls.Add(Me.ChkZero)
    Me.Controls.Add(Me.ChkBackup)
    Me.Controls.Add(Me.ChkMissing)
    Me.Controls.Add(Me.GroupBox4)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.ChkPost)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.MaximizeBox = False
    Me.Name = "FrmTAP30B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
    Me.GrpFile.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTAP30B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  End Sub
  Private Sub FrmTAP30B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP30.SbpScreen.Text = "TAP30B"
    MyFrmTAP30.TBarProcess.Enabled = True
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub

  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If LblFilePath.Text = "" Then
      ErrorField(I) = "path"
      ErrorMsg(I) = "File Path cannot be blank. Click on link to set."
      I = I + 1
    End If

    If ChkPropCode.Checked = False And ChkExemptCode.Checked = False Then
      ErrorField(I) = "fields"
      ErrorMsg(I) = "No fields selected for update"
      I = I + 1
    End If
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(LblFilePath, "")
    ErrProv.SetError(ChkPropCode, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "path"
          ErrProv.SetError(LblFilePath, ErrorMsg(I))
        Case "fields"
          ErrProv.SetError(ChkPropCode, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Public Sub RunImport()
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

        Impdata()
        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub ChkPost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkPost.Click
        ChkMissing.Enabled = Not ChkMissing.Enabled
        ChkZero.Enabled = Not ChkZero.Enabled
    End Sub
  Private Sub LnkFilePath_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
    With OpenFileDialog1
      .ReadOnlyChecked = True
      .ShowDialog()
      LblFilePath.Text = .FileName
    End With
  End Sub
End Class







