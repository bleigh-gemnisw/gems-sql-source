Public Class FrmTX808B
    Inherits System.Windows.Forms.Form
    Friend Wrkrelegal As Integer
    Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblFilePath As System.Windows.Forms.Label
    Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rb4 As System.Windows.Forms.RadioButton
    Friend WithEvents rb3 As System.Windows.Forms.RadioButton
    Friend WithEvents rb2 As System.Windows.Forms.RadioButton
    Friend WithEvents rb1 As System.Windows.Forms.RadioButton
    Friend WithEvents LnkBankCd As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtBankCd As System.Windows.Forms.TextBox
    Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
		Friend WithEvents ChkPaid As System.Windows.Forms.CheckBox
		Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
		Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
    Friend WithEvents RbSortType As System.Windows.Forms.RadioButton
  Friend WithEvents ChkBalDue As System.Windows.Forms.CheckBox
    Friend WrkTxType As String

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
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents TxtGlYear As System.Windows.Forms.TextBox
    Friend WithEvents label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.TxtGlYear = New System.Windows.Forms.TextBox
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.label3 = New System.Windows.Forms.Label
Me.LnkTypes = New System.Windows.Forms.LinkLabel
Me.TxtTypes = New System.Windows.Forms.TextBox
Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.LblFilePath = New System.Windows.Forms.Label
Me.LnkFilePath = New System.Windows.Forms.LinkLabel
Me.GroupBox2 = New System.Windows.Forms.GroupBox
Me.rb4 = New System.Windows.Forms.RadioButton
Me.rb3 = New System.Windows.Forms.RadioButton
Me.rb2 = New System.Windows.Forms.RadioButton
Me.rb1 = New System.Windows.Forms.RadioButton
Me.LnkBankCd = New System.Windows.Forms.LinkLabel
Me.TxtBankCd = New System.Windows.Forms.TextBox
Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ChkPaid = New System.Windows.Forms.CheckBox
Me.GroupBox3 = New System.Windows.Forms.GroupBox
Me.RbSortName = New System.Windows.Forms.RadioButton
Me.RbSortType = New System.Windows.Forms.RadioButton
Me.ChkBalDue = New System.Windows.Forms.CheckBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox1.SuspendLayout()
Me.GroupBox2.SuspendLayout()
Me.GroupBox3.SuspendLayout()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label1.Location = New System.Drawing.Point(9, 29)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(135, 16)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Enter Grand List Year"
'
'TxtGlYear
'
Me.TxtGlYear.Location = New System.Drawing.Point(150, 25)
Me.TxtGlYear.MaxLength = 4
Me.TxtGlYear.Name = "TxtGlYear"
Me.TxtGlYear.Size = New System.Drawing.Size(40, 20)
Me.TxtGlYear.TabIndex = 0
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'label3
'
Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.label3.Location = New System.Drawing.Point(-100, 74)
Me.label3.Name = "label3"
Me.label3.Size = New System.Drawing.Size(89, 23)
Me.label3.TabIndex = 6
Me.label3.Text = "New file name"
Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'LnkTypes
'
Me.LnkTypes.Location = New System.Drawing.Point(10, 55)
Me.LnkTypes.Name = "LnkTypes"
Me.LnkTypes.Size = New System.Drawing.Size(72, 16)
Me.LnkTypes.TabIndex = 1
Me.LnkTypes.TabStop = True
Me.LnkTypes.Text = "Select Types"
'
'TxtTypes
'
Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtTypes.Location = New System.Drawing.Point(86, 51)
Me.TxtTypes.MaxLength = 20
Me.TxtTypes.Name = "TxtTypes"
Me.TxtTypes.Size = New System.Drawing.Size(116, 20)
Me.TxtTypes.TabIndex = 1
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.LblFilePath)
Me.GroupBox1.Controls.Add(Me.LnkFilePath)
Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox1.ForeColor = System.Drawing.Color.Black
Me.GroupBox1.Location = New System.Drawing.Point(12, 223)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(408, 65)
Me.GroupBox1.TabIndex = 7
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "Bank File Details"
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
Me.LnkFilePath.TabIndex = 29
Me.LnkFilePath.TabStop = True
Me.LnkFilePath.Text = "File Path"
'
'GroupBox2
'
Me.GroupBox2.Controls.Add(Me.rb4)
Me.GroupBox2.Controls.Add(Me.rb3)
Me.GroupBox2.Controls.Add(Me.rb2)
Me.GroupBox2.Controls.Add(Me.rb1)
Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox2.ForeColor = System.Drawing.Color.Black
Me.GroupBox2.Location = New System.Drawing.Point(12, 77)
Me.GroupBox2.Name = "GroupBox2"
Me.GroupBox2.Size = New System.Drawing.Size(190, 39)
Me.GroupBox2.TabIndex = 2
Me.GroupBox2.TabStop = False
Me.GroupBox2.Text = "Select Payment"
'
'rb4
'
Me.rb4.AutoSize = True
Me.rb4.Location = New System.Drawing.Point(146, 16)
Me.rb4.Name = "rb4"
Me.rb4.Size = New System.Drawing.Size(32, 17)
Me.rb4.TabIndex = 7
Me.rb4.TabStop = True
Me.rb4.Text = "4"
Me.rb4.UseVisualStyleBackColor = True
'
'rb3
'
Me.rb3.AutoSize = True
Me.rb3.Location = New System.Drawing.Point(100, 16)
Me.rb3.Name = "rb3"
Me.rb3.Size = New System.Drawing.Size(32, 17)
Me.rb3.TabIndex = 6
Me.rb3.TabStop = True
Me.rb3.Text = "3"
Me.rb3.UseVisualStyleBackColor = True
'
'rb2
'
Me.rb2.AutoSize = True
Me.rb2.Location = New System.Drawing.Point(53, 16)
Me.rb2.Name = "rb2"
Me.rb2.Size = New System.Drawing.Size(32, 17)
Me.rb2.TabIndex = 5
Me.rb2.TabStop = True
Me.rb2.Text = "2"
Me.rb2.UseVisualStyleBackColor = True
'
'rb1
'
Me.rb1.AutoSize = True
Me.rb1.Checked = True
Me.rb1.Location = New System.Drawing.Point(6, 16)
Me.rb1.Name = "rb1"
Me.rb1.Size = New System.Drawing.Size(32, 17)
Me.rb1.TabIndex = 4
Me.rb1.TabStop = True
Me.rb1.Text = "1"
Me.rb1.UseVisualStyleBackColor = True
'
'LnkBankCd
'
Me.LnkBankCd.Location = New System.Drawing.Point(12, 125)
Me.LnkBankCd.Name = "LnkBankCd"
Me.LnkBankCd.Size = New System.Drawing.Size(115, 16)
Me.LnkBankCd.TabIndex = 3
Me.LnkBankCd.TabStop = True
Me.LnkBankCd.Text = "Bank Code (Optional)"
'
'TxtBankCd
'
Me.TxtBankCd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtBankCd.Location = New System.Drawing.Point(133, 122)
Me.TxtBankCd.MaxLength = 2
Me.TxtBankCd.Name = "TxtBankCd"
Me.TxtBankCd.Size = New System.Drawing.Size(24, 20)
Me.TxtBankCd.TabIndex = 4
'
'ChkPaid
'
Me.ChkPaid.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkPaid.Location = New System.Drawing.Point(18, 181)
Me.ChkPaid.Name = "ChkPaid"
Me.ChkPaid.Size = New System.Drawing.Size(152, 18)
Me.ChkPaid.TabIndex = 6
Me.ChkPaid.Text = "Include Paid Accts?"
Me.ChkPaid.UseVisualStyleBackColor = True
'
'GroupBox3
'
Me.GroupBox3.Controls.Add(Me.RbSortName)
Me.GroupBox3.Controls.Add(Me.RbSortType)
Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox3.Location = New System.Drawing.Point(307, 12)
Me.GroupBox3.Name = "GroupBox3"
Me.GroupBox3.Size = New System.Drawing.Size(128, 59)
Me.GroupBox3.TabIndex = 8
Me.GroupBox3.TabStop = False
Me.GroupBox3.Text = "Sort Order"
'
'RbSortName
'
Me.RbSortName.AutoSize = True
Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbSortName.Location = New System.Drawing.Point(9, 39)
Me.RbSortName.Name = "RbSortName"
Me.RbSortName.Size = New System.Drawing.Size(53, 17)
Me.RbSortName.TabIndex = 1
Me.RbSortName.Text = "Name"
Me.RbSortName.UseVisualStyleBackColor = True
'
'RbSortType
'
Me.RbSortType.AutoSize = True
Me.RbSortType.Checked = True
Me.RbSortType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbSortType.Location = New System.Drawing.Point(9, 23)
Me.RbSortType.Name = "RbSortType"
Me.RbSortType.Size = New System.Drawing.Size(82, 17)
Me.RbSortType.TabIndex = 0
Me.RbSortType.TabStop = True
Me.RbSortType.Text = "Type/Name"
Me.RbSortType.UseVisualStyleBackColor = True
'
'ChkBalDue
'
Me.ChkBalDue.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkBalDue.Checked = True
Me.ChkBalDue.CheckState = System.Windows.Forms.CheckState.Checked
Me.ChkBalDue.Location = New System.Drawing.Point(18, 158)
Me.ChkBalDue.Name = "ChkBalDue"
Me.ChkBalDue.Size = New System.Drawing.Size(152, 17)
Me.ChkBalDue.TabIndex = 5
Me.ChkBalDue.Text = "Based on Balance Due?"
Me.ChkBalDue.UseVisualStyleBackColor = True
'
'FrmTX808B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(447, 300)
Me.ControlBox = False
Me.Controls.Add(Me.ChkBalDue)
Me.Controls.Add(Me.GroupBox3)
Me.Controls.Add(Me.ChkPaid)
Me.Controls.Add(Me.TxtBankCd)
Me.Controls.Add(Me.LnkBankCd)
Me.Controls.Add(Me.GroupBox2)
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.LnkTypes)
Me.Controls.Add(Me.TxtTypes)
Me.Controls.Add(Me.label3)
Me.Controls.Add(Me.TxtGlYear)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.KeyPreview = True
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX808B"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox1.ResumeLayout(False)
Me.GroupBox2.ResumeLayout(False)
Me.GroupBox2.PerformLayout()
Me.GroupBox3.ResumeLayout(False)
Me.GroupBox3.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

    Private Sub TX808B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dft_year As Integer
        Dim dft_month As Integer

        dft_year = Year(Today)
        dft_month = Month(Today)
        If dft_month >= 7 Then
            dft_year = dft_year - 1
        End If

        TxtGlYear.Text = Format(Val(dft_year), "General Number")


    End Sub
    Private Sub TX808B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        MyFrmTX808.SbpScreen.Text = "TX808B"
        MyUtils.CenterForm(Me.ParentForm, Me)
    End Sub
  Public Sub runData()
    Dim my_yr2 As Integer
    Dim myerr As String
    myerr = ""
    Me.ErrProv.Clear()
    If Trim(TxtTypes.Text) = "" Then
      Me.ErrProv.SetError(TxtTypes, "Please enter type(s)")
      myerr = "Errors exist"
    End If
    If Trim(TxtGlYear.Text) = "" Then
      Me.ErrProv.SetError(TxtGlYear, "Please enter grand list Year")
      myerr = "Errors exist"
    End If
    If Trim(LblFilePath.Text) = "" Then
      Me.ErrProv.SetError(LnkFilePath, "Please select file path")
      myerr = "Errors exist"
    End If
    If myerr = "Errors exist" Then
      Exit Sub
    End If

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    my_yr2 = TxtGlYear.Text

    Me.Refresh()
    PrtBankbill()

    Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

Private Sub TxtGlYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGlYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
  MyTypes = TxtTypes.Text
  myFrmSelTypes = New FrmSelTypes
  myFrmSelTypes.MdiParent = Me.ParentForm
  myFrmSelTypes.Show()
End Sub

Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
  With SaveFileDialog1
    .ShowDialog()
    LblFilePath.Text = .FileName
  End With
End Sub


Private Sub LnkBankCd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBankCd.LinkClicked
  MyFrmListBanks = New FrmListBanks
    MyFrmListBanks.MdiParent = Me.ParentForm
    MyFrmListBanks.WrkCode = TxtBankCd.Text
    MyFrmListBanks.Show()
End Sub
End Class






