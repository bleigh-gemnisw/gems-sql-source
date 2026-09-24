Public Class FrmTXE24B
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
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents TxtToGLYear As System.Windows.Forms.TextBox
Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents ChkBalances As System.Windows.Forms.CheckBox
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbSortYear As System.Windows.Forms.RadioButton
    Friend WithEvents RbSortType As System.Windows.Forms.RadioButton
    Friend WithEvents TxtSts As System.Windows.Forms.TextBox
    Friend WithEvents LnkSts As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChkAddress As System.Windows.Forms.CheckBox
    Friend WithEvents RbSortName As RadioButton
    Friend WithEvents RbSortNameList As RadioButton
    Friend WithEvents GrpDownload As GroupBox
    Friend WithEvents LblFilePath As Label
    Friend WithEvents LnkFilePath As LinkLabel
  Friend WithEvents SaveFileDialog1 As SaveFileDialog
  Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtToGLYear = New System.Windows.Forms.TextBox()
    Me.TxtFromGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtTypes = New System.Windows.Forms.TextBox()
    Me.LnkTypes = New System.Windows.Forms.LinkLabel()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ChkBalances = New System.Windows.Forms.CheckBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbSortNameList = New System.Windows.Forms.RadioButton()
    Me.RbSortType = New System.Windows.Forms.RadioButton()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
    Me.RbSortYear = New System.Windows.Forms.RadioButton()
    Me.LnkSts = New System.Windows.Forms.LinkLabel()
    Me.TxtSts = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.ChkAddress = New System.Windows.Forms.CheckBox()
    Me.GrpDownload = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GrpDownload.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(221, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "(Optional)"
        '
        'TxtToGLYear
        '
        Me.TxtToGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtToGLYear.Location = New System.Drawing.Point(177, 90)
        Me.TxtToGLYear.MaxLength = 4
        Me.TxtToGLYear.Name = "TxtToGLYear"
        Me.TxtToGLYear.Size = New System.Drawing.Size(36, 20)
        Me.TxtToGLYear.TabIndex = 3
        '
        'TxtFromGLYear
        '
        Me.TxtFromGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFromGLYear.Location = New System.Drawing.Point(105, 90)
        Me.TxtFromGLYear.MaxLength = 4
        Me.TxtFromGLYear.Name = "TxtFromGLYear"
        Me.TxtFromGLYear.Size = New System.Drawing.Size(36, 20)
        Me.TxtFromGLYear.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(153, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 16)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "to"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(21, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 16)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Grand List Year"
        '
        'TxtTypes
        '
        Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTypes.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTypes.Location = New System.Drawing.Point(105, 28)
        Me.TxtTypes.MaxLength = 20
        Me.TxtTypes.Name = "TxtTypes"
        Me.TxtTypes.Size = New System.Drawing.Size(148, 20)
        Me.TxtTypes.TabIndex = 0
        '
        'LnkTypes
        '
        Me.LnkTypes.Location = New System.Drawing.Point(21, 32)
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
        'ChkBalances
        '
        Me.ChkBalances.AutoSize = True
        Me.ChkBalances.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkBalances.Location = New System.Drawing.Point(24, 126)
        Me.ChkBalances.Name = "ChkBalances"
        Me.ChkBalances.Size = New System.Drawing.Size(138, 17)
        Me.ChkBalances.TabIndex = 4
        Me.ChkBalances.Text = "Include Balances Only?"
        Me.ChkBalances.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RbSortNameList)
        Me.GroupBox1.Controls.Add(Me.RbSortType)
        Me.GroupBox1.Controls.Add(Me.RbSortName)
        Me.GroupBox1.Controls.Add(Me.RbSortYear)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(283, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(163, 107)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sort Order"
        '
        'RbSortNameList
        '
        Me.RbSortNameList.AutoSize = True
        Me.RbSortNameList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbSortNameList.Location = New System.Drawing.Point(9, 80)
        Me.RbSortNameList.Name = "RbSortNameList"
        Me.RbSortNameList.Size = New System.Drawing.Size(152, 17)
        Me.RbSortNameList.TabIndex = 3
        Me.RbSortNameList.Text = "Location /Name/Type/List"
        Me.RbSortNameList.UseVisualStyleBackColor = True
        '
        'RbSortType
        '
        Me.RbSortType.AutoSize = True
        Me.RbSortType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbSortType.Location = New System.Drawing.Point(9, 41)
        Me.RbSortType.Name = "RbSortType"
        Me.RbSortType.Size = New System.Drawing.Size(99, 17)
        Me.RbSortType.TabIndex = 2
        Me.RbSortType.Text = "Type/Year/Dist"
        Me.RbSortType.UseVisualStyleBackColor = True
        '
        'RbSortName
        '
        Me.RbSortName.AutoSize = True
        Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbSortName.Location = New System.Drawing.Point(9, 60)
        Me.RbSortName.Name = "RbSortName"
        Me.RbSortName.Size = New System.Drawing.Size(82, 17)
        Me.RbSortName.TabIndex = 1
        Me.RbSortName.Text = "Name/Type"
        Me.RbSortName.UseVisualStyleBackColor = True
        '
        'RbSortYear
        '
        Me.RbSortYear.AutoSize = True
        Me.RbSortYear.Checked = True
        Me.RbSortYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbSortYear.Location = New System.Drawing.Point(9, 23)
        Me.RbSortYear.Name = "RbSortYear"
        Me.RbSortYear.Size = New System.Drawing.Size(99, 17)
        Me.RbSortYear.TabIndex = 0
        Me.RbSortYear.TabStop = True
        Me.RbSortYear.Text = "Year/Type/Dist"
        Me.RbSortYear.UseVisualStyleBackColor = True
        '
        'LnkSts
        '
        Me.LnkSts.Location = New System.Drawing.Point(21, 59)
        Me.LnkSts.Name = "LnkSts"
        Me.LnkSts.Size = New System.Drawing.Size(80, 16)
        Me.LnkSts.TabIndex = 39
        Me.LnkSts.TabStop = True
        Me.LnkSts.Text = "Status Codes*"
        '
        'TxtSts
        '
        Me.TxtSts.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSts.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSts.Location = New System.Drawing.Point(105, 56)
        Me.TxtSts.MaxLength = 20
        Me.TxtSts.Name = "TxtSts"
        Me.TxtSts.Size = New System.Drawing.Size(148, 20)
        Me.TxtSts.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 196)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(408, 13)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "*Leave blank for all accounts. Select all codes for only accounts having status c" &
    "odes"
        '
        'ChkAddress
        '
        Me.ChkAddress.AutoSize = True
        Me.ChkAddress.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkAddress.Location = New System.Drawing.Point(24, 149)
        Me.ChkAddress.Name = "ChkAddress"
        Me.ChkAddress.Size = New System.Drawing.Size(100, 17)
        Me.ChkAddress.TabIndex = 41
        Me.ChkAddress.Text = "Show Address?"
        Me.ChkAddress.UseVisualStyleBackColor = True
        '
        'GrpDownload
        '
        Me.GrpDownload.Controls.Add(Me.LblFilePath)
        Me.GrpDownload.Controls.Add(Me.LnkFilePath)
        Me.GrpDownload.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpDownload.ForeColor = System.Drawing.Color.Black
        Me.GrpDownload.Location = New System.Drawing.Point(6, 231)
        Me.GrpDownload.Name = "GrpDownload"
        Me.GrpDownload.Size = New System.Drawing.Size(429, 47)
        Me.GrpDownload.TabIndex = 311
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
        'FrmTXE24B
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(458, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpDownload)
        Me.Controls.Add(Me.ChkAddress)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtSts)
        Me.Controls.Add(Me.LnkSts)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ChkBalances)
        Me.Controls.Add(Me.TxtTypes)
        Me.Controls.Add(Me.LnkTypes)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtToGLYear)
        Me.Controls.Add(Me.TxtFromGLYear)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label7)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTXE24B"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GrpDownload.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FrmTXE24B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXE24.SbpScreen.Text = "TXE24"
  End Sub
  Private Sub FrmTXE24B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFromGLYear, "")
    ErrProv.SetError(TxtToGLYear, "")
    ErrProv.SetError(TxtTypes, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
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
  Private Sub FrmTXE24B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTypes = ""
    MySts = ""
  End Sub
  Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
    MyTypes = TxtTypes.Text
    MyFrmSelTypes = New FrmSelTypes
    MyFrmSelTypes.MdiParent = Me.ParentForm
    MyFrmSelTypes.Show()
    Me.Hide()

  End Sub
  Private Sub TxtFromGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromGLYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtToGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToGLYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Private Sub LnkSts_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkSts.LinkClicked
    MySts = TxtSts.Text
    MyFrmSelSts = New FrmSelSts
    MyFrmSelSts.MdiParent = Me.ParentForm
    MyFrmSelSts.Show()
    Me.Hide()
  End Sub

  Private Sub RbSortNameList_CheckedChanged(sender As Object, e As EventArgs) Handles RbSortNameList.CheckedChanged

  End Sub

  Private Sub LnkFilePath_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
    With SaveFileDialog1
      .ShowDialog()
      LblFilePath.Text = .FileName
    End With
  End Sub
End Class






