Public Class FrmTA941C
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
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbSupp As System.Windows.Forms.RadioButton
Friend WithEvents RbMV As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
Friend WithEvents RbSortList As System.Windows.Forms.RadioButton
Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
Friend WithEvents RbValues70 As System.Windows.Forms.RadioButton
Friend WithEvents RbValues100 As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
Friend WithEvents RbNormal As System.Windows.Forms.RadioButton
Friend WithEvents RbDown As System.Windows.Forms.RadioButton
Friend WithEvents LblFilePath As System.Windows.Forms.Label
Friend WithEvents ChkSkip As System.Windows.Forms.CheckBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TxtMinVal As System.Windows.Forms.TextBox
    Friend WithEvents RbValuesMSRP As RadioButton
    Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.ChkPost = New System.Windows.Forms.CheckBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbSupp = New System.Windows.Forms.RadioButton()
    Me.RbMV = New System.Windows.Forms.RadioButton()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.RbSortList = New System.Windows.Forms.RadioButton()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.RbNormal = New System.Windows.Forms.RadioButton()
    Me.RbDown = New System.Windows.Forms.RadioButton()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.RbValues70 = New System.Windows.Forms.RadioButton()
    Me.RbValues100 = New System.Windows.Forms.RadioButton()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.ChkSkip = New System.Windows.Forms.CheckBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtMinVal = New System.Windows.Forms.TextBox()
        Me.RbValuesMSRP = New System.Windows.Forms.RadioButton()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'ChkPost
        '
        Me.ChkPost.AutoSize = True
        Me.ChkPost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkPost.Location = New System.Drawing.Point(34, 291)
        Me.ChkPost.Name = "ChkPost"
        Me.ChkPost.Size = New System.Drawing.Size(84, 17)
        Me.ChkPost.TabIndex = 5
        Me.ChkPost.TabStop = False
        Me.ChkPost.Text = "Post to File?"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RbSupp)
        Me.GroupBox2.Controls.Add(Me.RbMV)
        Me.GroupBox2.Location = New System.Drawing.Point(28, 54)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(246, 46)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'RbSupp
        '
        Me.RbSupp.AutoSize = True
        Me.RbSupp.Location = New System.Drawing.Point(135, 19)
        Me.RbSupp.Name = "RbSupp"
        Me.RbSupp.Size = New System.Drawing.Size(74, 17)
        Me.RbSupp.TabIndex = 12
        Me.RbSupp.Text = "Suppl. MV"
        Me.RbSupp.UseVisualStyleBackColor = True
        '
        'RbMV
        '
        Me.RbMV.AutoSize = True
        Me.RbMV.Checked = True
        Me.RbMV.Location = New System.Drawing.Point(6, 19)
        Me.RbMV.Name = "RbMV"
        Me.RbMV.Size = New System.Drawing.Size(90, 17)
        Me.RbMV.TabIndex = 11
        Me.RbMV.TabStop = True
        Me.RbMV.Text = "Motor Vehicle"
        Me.RbMV.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RbSortList)
        Me.GroupBox3.Controls.Add(Me.RbSortName)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox3.Location = New System.Drawing.Point(358, 54)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(135, 88)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Report Order"
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
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.RbNormal)
        Me.GroupBox4.Controls.Add(Me.RbDown)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(28, 158)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(290, 64)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Last Digit handling method (Value)"
        '
        'RbNormal
        '
        Me.RbNormal.AutoSize = True
        Me.RbNormal.Checked = True
        Me.RbNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbNormal.Location = New System.Drawing.Point(6, 19)
        Me.RbNormal.Name = "RbNormal"
        Me.RbNormal.Size = New System.Drawing.Size(258, 17)
        Me.RbNormal.TabIndex = 0
        Me.RbNormal.TabStop = True
        Me.RbNormal.Text = "Normal Rounding (IE: 103 ==> 100, 105 ==> 110)"
        Me.RbNormal.UseVisualStyleBackColor = True
        '
        'RbDown
        '
        Me.RbDown.AutoSize = True
        Me.RbDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbDown.Location = New System.Drawing.Point(6, 41)
        Me.RbDown.Name = "RbDown"
        Me.RbDown.Size = New System.Drawing.Size(253, 17)
        Me.RbDown.TabIndex = 1
        Me.RbDown.Text = "Truncate Down (IE: 103 ==> 100,  105 ==> 100)"
        Me.RbDown.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.RbValuesMSRP)
        Me.GroupBox5.Controls.Add(Me.RbValues70)
        Me.GroupBox5.Controls.Add(Me.RbValues100)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(28, 106)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(321, 46)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Tag = ""
        Me.GroupBox5.Text = "Imported Values Calculation"
        '
        'RbValues70
        '
        Me.RbValues70.AutoSize = True
        Me.RbValues70.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbValues70.Location = New System.Drawing.Point(92, 19)
        Me.RbValues70.Name = "RbValues70"
        Me.RbValues70.Size = New System.Drawing.Size(95, 17)
        Me.RbValues70.TabIndex = 0
        Me.RbValues70.Text = "Already at 70%"
        Me.RbValues70.UseVisualStyleBackColor = True
        '
        'RbValues100
        '
        Me.RbValues100.AutoSize = True
        Me.RbValues100.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbValues100.Location = New System.Drawing.Point(204, 19)
        Me.RbValues100.Name = "RbValues100"
        Me.RbValues100.Size = New System.Drawing.Size(95, 17)
        Me.RbValues100.TabIndex = 1
        Me.RbValues100.Text = "100% ==> 70%"
        Me.RbValues100.UseVisualStyleBackColor = True
        '
        'LblFilePath
        '
        Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFilePath.Location = New System.Drawing.Point(25, 9)
        Me.LblFilePath.Name = "LblFilePath"
        Me.LblFilePath.Size = New System.Drawing.Size(324, 36)
        Me.LblFilePath.TabIndex = 68
        '
        'ChkSkip
        '
        Me.ChkSkip.AutoSize = True
        Me.ChkSkip.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkSkip.Location = New System.Drawing.Point(34, 236)
        Me.ChkSkip.Name = "ChkSkip"
        Me.ChkSkip.Size = New System.Drawing.Size(164, 17)
        Me.ChkSkip.TabIndex = 3
        Me.ChkSkip.TabStop = False
        Me.ChkSkip.Text = "Skip already priced vehicles?"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 262)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 13)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "Minimum Assessment Value"
        '
        'TxtMinVal
        '
        Me.TxtMinVal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMinVal.Location = New System.Drawing.Point(183, 259)
        Me.TxtMinVal.MaxLength = 6
        Me.TxtMinVal.Name = "TxtMinVal"
        Me.TxtMinVal.Size = New System.Drawing.Size(56, 20)
        Me.TxtMinVal.TabIndex = 4
        '
        'RbValuesMSRP
        '
        Me.RbValuesMSRP.AutoSize = True
        Me.RbValuesMSRP.Checked = True
        Me.RbValuesMSRP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbValuesMSRP.Location = New System.Drawing.Point(9, 19)
        Me.RbValuesMSRP.Name = "RbValuesMSRP"
        Me.RbValuesMSRP.Size = New System.Drawing.Size(56, 17)
        Me.RbValuesMSRP.TabIndex = 2
        Me.RbValuesMSRP.Text = "MSRP"
        Me.RbValuesMSRP.UseVisualStyleBackColor = True
        '
        'FrmTA941C
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(505, 343)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtMinVal)
        Me.Controls.Add(Me.ChkSkip)
        Me.Controls.Add(Me.LblFilePath)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ChkPost)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "FrmTA941C"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FrmTA941C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  LblFilePath.Text = MyFrmTA941B.LblFilePath.Text
End Sub
Private Sub TxtMinVal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMinVal.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub FrmTA941C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA941.SbpScreen.Text = "TA941C"
  MyFrmTA941.TBarProcess.Enabled = True
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Public Sub RunImport()
    Me.Refresh()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    Impdata()
    Windows.Forms.Cursor.Current = Cursors.Default
End Sub
End Class






