Public Class FrmTAP20B
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
Friend WithEvents TxtYear As System.Windows.Forms.TextBox
Friend WithEvents Label13 As System.Windows.Forms.Label
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
Friend WithEvents ChkMVAddr As System.Windows.Forms.CheckBox
Friend WithEvents ChkMVLoc As System.Windows.Forms.CheckBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents ChkBackup As System.Windows.Forms.CheckBox
Friend WithEvents ChkZero As System.Windows.Forms.CheckBox
  Friend WithEvents ChkComments As CheckBox
  Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.ChkComments = New System.Windows.Forms.CheckBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.ChkMVLoc = New System.Windows.Forms.CheckBox()
    Me.ChkMVAddr = New System.Windows.Forms.CheckBox()
    Me.ChkMailAddr = New System.Windows.Forms.CheckBox()
    Me.ChkLoc = New System.Windows.Forms.CheckBox()
    Me.ChkName = New System.Windows.Forms.CheckBox()
    Me.ChkExemptCode = New System.Windows.Forms.CheckBox()
    Me.ChkPropCode = New System.Windows.Forms.CheckBox()
    Me.ChkPost = New System.Windows.Forms.CheckBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbSortList = New System.Windows.Forms.RadioButton()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
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
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
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
    "d from Personal Property Declarations. Inactive records will NOT be processed."
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.ChkComments)
    Me.GroupBox1.Controls.Add(Me.Label3)
    Me.GroupBox1.Controls.Add(Me.Label2)
    Me.GroupBox1.Controls.Add(Me.ChkMVLoc)
    Me.GroupBox1.Controls.Add(Me.ChkMVAddr)
    Me.GroupBox1.Controls.Add(Me.ChkMailAddr)
    Me.GroupBox1.Controls.Add(Me.ChkLoc)
    Me.GroupBox1.Controls.Add(Me.ChkName)
    Me.GroupBox1.Controls.Add(Me.ChkExemptCode)
    Me.GroupBox1.Controls.Add(Me.ChkPropCode)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox1.Location = New System.Drawing.Point(46, 60)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(411, 155)
    Me.GroupBox1.TabIndex = 0
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Information to Import"
    '
    'ChkComments
    '
    Me.ChkComments.AutoSize = True
    Me.ChkComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkComments.ForeColor = System.Drawing.SystemColors.WindowText
    Me.ChkComments.Location = New System.Drawing.Point(11, 128)
    Me.ChkComments.Name = "ChkComments"
    Me.ChkComments.Size = New System.Drawing.Size(146, 17)
    Me.ChkComments.TabIndex = 9
    Me.ChkComments.Text = "Comments (Overlay Daily)"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.ForeColor = System.Drawing.Color.Black
    Me.Label3.Location = New System.Drawing.Point(241, 60)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(34, 16)
    Me.Label3.TabIndex = 8
    Me.Label3.Text = "- or -"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.ForeColor = System.Drawing.Color.Black
    Me.Label2.Location = New System.Drawing.Point(241, 37)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(34, 16)
    Me.Label2.TabIndex = 7
    Me.Label2.Text = "- or -"
    '
    'ChkMVLoc
    '
    Me.ChkMVLoc.AutoSize = True
    Me.ChkMVLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkMVLoc.ForeColor = System.Drawing.SystemColors.WindowText
    Me.ChkMVLoc.Location = New System.Drawing.Point(284, 61)
    Me.ChkMVLoc.Name = "ChkMVLoc"
    Me.ChkMVLoc.Size = New System.Drawing.Size(112, 17)
    Me.ChkMVLoc.TabIndex = 6
    Me.ChkMVLoc.Text = "MV Form Location"
    '
    'ChkMVAddr
    '
    Me.ChkMVAddr.AutoSize = True
    Me.ChkMVAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkMVAddr.ForeColor = System.Drawing.SystemColors.WindowText
    Me.ChkMVAddr.Location = New System.Drawing.Point(284, 38)
    Me.ChkMVAddr.Name = "ChkMVAddr"
    Me.ChkMVAddr.Size = New System.Drawing.Size(109, 17)
    Me.ChkMVAddr.TabIndex = 5
    Me.ChkMVAddr.Text = "MV Form Address"
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
    Me.ChkLoc.Location = New System.Drawing.Point(11, 61)
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
    Me.ChkExemptCode.Location = New System.Drawing.Point(11, 105)
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
    Me.ChkPropCode.Location = New System.Drawing.Point(11, 82)
    Me.ChkPropCode.Name = "ChkPropCode"
    Me.ChkPropCode.Size = New System.Drawing.Size(163, 17)
    Me.ChkPropCode.TabIndex = 0
    Me.ChkPropCode.Text = "Property Codes and Amounts"
    '
    'ChkPost
    '
    Me.ChkPost.Location = New System.Drawing.Point(12, 344)
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
    Me.GroupBox2.Location = New System.Drawing.Point(463, 10)
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
    'TxtYear
    '
    Me.TxtYear.Location = New System.Drawing.Point(108, 315)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtYear.TabIndex = 2
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(9, 318)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(93, 23)
    Me.Label13.TabIndex = 207
    Me.Label13.Text = "Grand List Year"
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
    Me.ChkMissing.Location = New System.Drawing.Point(31, 374)
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
    Me.ChkBackup.Location = New System.Drawing.Point(122, 348)
    Me.ChkBackup.Name = "ChkBackup"
    Me.ChkBackup.Size = New System.Drawing.Size(189, 17)
    Me.ChkBackup.TabIndex = 211
    Me.ChkBackup.Text = "Create a Backup file? (CAMPPRP)"
    '
    'ChkZero
    '
    Me.ChkZero.AutoSize = True
    Me.ChkZero.Enabled = False
    Me.ChkZero.Location = New System.Drawing.Point(31, 397)
    Me.ChkZero.Name = "ChkZero"
    Me.ChkZero.Size = New System.Drawing.Size(228, 17)
    Me.ChkZero.TabIndex = 212
    Me.ChkZero.TabStop = False
    Me.ChkZero.Text = "Update zero value filers? (Active/Increase)"
    '
    'FrmTAP20B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(610, 423)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkZero)
    Me.Controls.Add(Me.ChkBackup)
    Me.Controls.Add(Me.ChkMissing)
    Me.Controls.Add(Me.GroupBox4)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.ChkPost)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.MaximizeBox = False
    Me.Name = "FrmTAP20B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTAP20B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  Dim myTXDCFRM As TXDCFRM.myData
  myTXDCFRM = New TXDCFRM.mydata(MyDBConnect)
  myTXDCFRM.GetOneRecordP(1)
  With myTXDCFRM
    If Not .RecordNotFound Then
      TxtYear.Text = ._CURRYR
    End If
  End With
End Sub


Private Sub FrmTAP20B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTAP20.SbpScreen.Text = "TAP20B"
  MyFrmTAP20.TBarProcess.Enabled = True
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If ChkPropCode.Checked = False And ChkExemptCode.Checked = False Then
      ErrorField(I) = "fields"
      ErrorMsg(I) = "No fields selected for update"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtYear.Text) = 0 Then
      ErrorField(I) = "year"
      ErrorMsg(I) = "year is required"
      I = I + 1
    End If

  End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(ChkPropCode, "")
    ErrProv.SetError(TxtYear, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "fields"
        ErrProv.SetError(ChkPropCode, ErrorMsg(I))
      Case "year"
        ErrProv.SetError(TxtYear, ErrorMsg(I))
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
  Private Sub ChkLoc_Click(sender As Object, e As EventArgs) Handles ChkLoc.Click
    ChkMVLoc.Checked = False
  End Sub
  Private Sub ChkMailAddr_Click(sender As Object, e As EventArgs) Handles ChkMailAddr.Click
    ChkMVAddr.Checked = False
  End Sub
  Private Sub ChkMVLoc_Click(sender As Object, e As EventArgs) Handles ChkMVLoc.Click
    ChkLoc.Checked = False
  End Sub
  Private Sub ChkMVAddr_Click(sender As Object, e As EventArgs) Handles ChkMVAddr.Click
    ChkMailAddr.Checked = False
  End Sub
End Class






