Public Class FrmTXA04B
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
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
Friend WithEvents LblFilePath As System.Windows.Forms.Label
Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
Friend WithEvents DtPckReceipt As System.Windows.Forms.DateTimePicker
Friend WithEvents TxtBankCd As System.Windows.Forms.TextBox
Friend WithEvents LnkBankCd As System.Windows.Forms.LinkLabel
Friend WithEvents ChkYear4 As System.Windows.Forms.CheckBox
Friend WithEvents TxtCheckNo As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents ChkDist As System.Windows.Forms.CheckBox
Friend WithEvents BtnAdd As System.Windows.Forms.Button
Friend WithEvents GrpBank As System.Windows.Forms.GroupBox
Friend WithEvents ChkOverride As System.Windows.Forms.CheckBox
Friend WithEvents TxtComment As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Friend WithEvents DtPckInterest As DateTimePicker
  Friend WithEvents Label5 As Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.DtPckReceipt = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtBankCd = New System.Windows.Forms.TextBox()
    Me.LnkBankCd = New System.Windows.Forms.LinkLabel()
    Me.TxtCheckNo = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.ChkYear4 = New System.Windows.Forms.CheckBox()
    Me.ChkDist = New System.Windows.Forms.CheckBox()
    Me.GrpBank = New System.Windows.Forms.GroupBox()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.BtnAdd = New System.Windows.Forms.Button()
    Me.ChkOverride = New System.Windows.Forms.CheckBox()
    Me.TxtComment = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.DtPckInterest = New System.Windows.Forms.DateTimePicker()
    Me.Label5 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GrpBank.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
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
    Me.GroupBox1.Location = New System.Drawing.Point(12, 199)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(408, 56)
    Me.GroupBox1.TabIndex = 4
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Bank Service File Details"
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
    'DtPckReceipt
    '
    Me.DtPckReceipt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckReceipt.Location = New System.Drawing.Point(102, 40)
    Me.DtPckReceipt.Name = "DtPckReceipt"
    Me.DtPckReceipt.Size = New System.Drawing.Size(84, 20)
    Me.DtPckReceipt.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(17, 46)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(72, 12)
    Me.Label1.TabIndex = 66
    Me.Label1.Text = "Receipt Date"
    '
    'TxtBankCd
    '
    Me.TxtBankCd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBankCd.Location = New System.Drawing.Point(82, 270)
    Me.TxtBankCd.MaxLength = 2
    Me.TxtBankCd.Name = "TxtBankCd"
    Me.TxtBankCd.Size = New System.Drawing.Size(32, 20)
    Me.TxtBankCd.TabIndex = 6
    '
    'LnkBankCd
    '
    Me.LnkBankCd.Location = New System.Drawing.Point(12, 272)
    Me.LnkBankCd.Name = "LnkBankCd"
    Me.LnkBankCd.Size = New System.Drawing.Size(64, 18)
    Me.LnkBankCd.TabIndex = 5
    Me.LnkBankCd.TabStop = True
    Me.LnkBankCd.Text = "Bank Code"
    '
    'TxtCheckNo
    '
    Me.TxtCheckNo.Location = New System.Drawing.Point(220, 271)
    Me.TxtCheckNo.MaxLength = 10
    Me.TxtCheckNo.Name = "TxtCheckNo"
    Me.TxtCheckNo.Size = New System.Drawing.Size(69, 20)
    Me.TxtCheckNo.TabIndex = 7
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(130, 274)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(84, 17)
    Me.Label2.TabIndex = 74
    Me.Label2.Text = "Check Number"
    '
    'ChkYear4
    '
    Me.ChkYear4.AutoSize = True
    Me.ChkYear4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkYear4.Location = New System.Drawing.Point(12, 79)
    Me.ChkYear4.Name = "ChkYear4"
    Me.ChkYear4.Size = New System.Drawing.Size(138, 17)
    Me.ChkYear4.TabIndex = 2
    Me.ChkYear4.Text = "4 Digit Year from Bank?"
    Me.ChkYear4.UseVisualStyleBackColor = True
    '
    'ChkDist
    '
    Me.ChkDist.AutoSize = True
    Me.ChkDist.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkDist.Location = New System.Drawing.Point(12, 111)
    Me.ChkDist.Name = "ChkDist"
    Me.ChkDist.Size = New System.Drawing.Size(169, 17)
    Me.ChkDist.TabIndex = 3
    Me.ChkDist.Text = "Use districts from Invoice File?"
    Me.ChkDist.UseVisualStyleBackColor = True
    '
    'GrpBank
    '
    Me.GrpBank.Controls.Add(Me.DataGrdView)
    Me.GrpBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpBank.ForeColor = System.Drawing.Color.Maroon
    Me.GrpBank.Location = New System.Drawing.Point(222, 6)
    Me.GrpBank.Name = "GrpBank"
    Me.GrpBank.Size = New System.Drawing.Size(311, 187)
    Me.GrpBank.TabIndex = 305
    Me.GrpBank.TabStop = False
    Me.GrpBank.Text = "Bank/Check numbers"
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DataGrdView.Location = New System.Drawing.Point(6, 19)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(299, 162)
    Me.DataGrdView.TabIndex = 51
    '
    'BtnAdd
    '
    Me.BtnAdd.Location = New System.Drawing.Point(295, 272)
    Me.BtnAdd.Name = "BtnAdd"
    Me.BtnAdd.Size = New System.Drawing.Size(52, 20)
    Me.BtnAdd.TabIndex = 8
    Me.BtnAdd.Text = "Add"
    '
    'ChkOverride
    '
    Me.ChkOverride.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkOverride.Location = New System.Drawing.Point(15, 134)
    Me.ChkOverride.Name = "ChkOverride"
    Me.ChkOverride.Size = New System.Drawing.Size(171, 53)
    Me.ChkOverride.TabIndex = 4
    Me.ChkOverride.Text = "Override with bank code and check number entered below?"
    Me.ChkOverride.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    Me.ChkOverride.ThreeState = True
    Me.ChkOverride.UseVisualStyleBackColor = True
    '
    'TxtComment
    '
    Me.TxtComment.Location = New System.Drawing.Point(82, 295)
    Me.TxtComment.MaxLength = 20
    Me.TxtComment.Name = "TxtComment"
    Me.TxtComment.Size = New System.Drawing.Size(144, 20)
    Me.TxtComment.TabIndex = 306
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(12, 299)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(69, 19)
    Me.Label3.TabIndex = 307
    Me.Label3.Text = "Comment"
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(232, 299)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(176, 19)
    Me.Label4.TabIndex = 308
    Me.Label4.Text = "(Leave blank to use bank name)"
    '
    'DtPckInterest
    '
    Me.DtPckInterest.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckInterest.Location = New System.Drawing.Point(102, 12)
    Me.DtPckInterest.Name = "DtPckInterest"
    Me.DtPckInterest.Size = New System.Drawing.Size(84, 20)
    Me.DtPckInterest.TabIndex = 0
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(21, 17)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(68, 13)
    Me.Label5.TabIndex = 310
    Me.Label5.Text = "Interest Date"
    '
    'FrmTXA04B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(539, 327)
    Me.ControlBox = False
    Me.Controls.Add(Me.DtPckInterest)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtComment)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.ChkOverride)
    Me.Controls.Add(Me.BtnAdd)
    Me.Controls.Add(Me.GrpBank)
    Me.Controls.Add(Me.ChkDist)
    Me.Controls.Add(Me.ChkYear4)
    Me.Controls.Add(Me.TxtCheckNo)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtBankCd)
    Me.Controls.Add(Me.LnkBankCd)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.DtPckReceipt)
    Me.Controls.Add(Me.GroupBox1)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXA04B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GrpBank.ResumeLayout(False)
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
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
  Private Sub FrmTXA04B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmTXA04.SbpPgmID.Text = "TXA04B"
    MyFrmTXA04.SbpEnvironment.Text = myDBConnect.PgmDB
    LblFilePath.Text = ""
    BuildDs()
    FormatGrid()

  End Sub
  Private Sub FrmTXA04B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA04.SbpScreen.Text = "TXA04B"
  End Sub
  Private Sub FrmTXA04B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtBankCd, "")
    ErrProv.SetError(LblFilePath, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "path"
          ErrProv.SetError(LblFilePath, ErrorMsg(I))
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

    If LblFilePath.Text = "" Then
      ErrorField(I) = "path"
      ErrorMsg(I) = "File Path cannot be blank. Click on link to set."
      I = I + 1
    End If

  End Sub
  Private Sub FrmTXA04B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If Not e.Alt Then Exit Sub

    If e.KeyCode = Keys.F12 Then
      MyUtils.PrtScreen(Form.ActiveForm)
    End If
  End Sub
  Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
    With OpenFileDialog1
      .ReadOnlyChecked = True
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
  Public Sub FormatGrid()
    Dim Style As DataGridViewCellStyle
    Call ShowGrid()

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      Style = DataGrdView.ColumnHeadersDefaultCellStyle
      Style.Font = New Font(DataGrdView.Font, FontStyle.Regular)
      Style = DataGrdView.DefaultCellStyle
      Style.Font = New Font(DataGrdView.Font, FontStyle.Regular)
      .Columns(0).HeaderText = "Bank Cd"
      .Columns(0).Width = 50
      .Columns(1).HeaderText = "Bank Name"
      .Columns(1).Width = 150
      .Columns(2).HeaderText = "Check No"
      .Columns(2).Width = 60
    End With

  End Sub
  Public Sub ShowGrid()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    DataGrdView.DataSource = myds.Tables(0)
    DataGrdView.Refresh()
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Private Sub BuildDs()
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("BankCd", Type.GetType("System.String"))
      .Columns.Add("BankName", Type.GetType("System.String"))
      .Columns.Add("CheckNo", Type.GetType("System.String"))
    End With
    myds.Tables.Add(myTable)

  End Sub
  Sub AddOneRecord()
    Dim myDr As Data.DataRow
    Dim WrkBankName As String

    myDr = myds.Tables(0).NewRow
    myDr("BankCd") = TxtBankCd.Text
    myDr("CheckNo") = TxtCheckNo.Text
    WrkBankName = GetTXBanksDesc(TxtBankCd.Text)
    If Mid(WrkBankName, 1, 1) <> "**" Then
      myDr("bankname") = WrkBankName
      myds.Tables(0).Rows.Add(myDr)
    Else
      MsgBox("Invalid Bank Code", MsgBoxStyle.Exclamation, "Cannot Add record")
      Exit Sub
    End If
    FormatGrid()
    TxtBankCd.Text = ""
    TxtCheckNo.Text = ""
  End Sub
  Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
    AddOneRecord()
  End Sub
  Public Sub RemoveData()
    Dim row As Integer

    If DataGrdView.SelectedRows.Count > 0 Then
      For Each row In DataGrdView.SelectedRows
        myds.Tables(0).Rows(row).Delete()
        Exit For
      Next
    End If

  End Sub
  Private Sub ChkOverride_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkOverride.Click
    BtnAdd.Enabled = Not BtnAdd.Enabled
    MyFrmTXA04.TBarRemove.Enabled = Not MyFrmTXA04.TBarRemove.Enabled
    GrpBank.Visible = Not GrpBank.Visible
  End Sub
  Private Sub TxtComment_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtComment.GotFocus
    If TxtComment.Text <> String.Empty Then Exit Sub
  End Sub

  Private Sub ChkOverride_CheckedChanged(sender As Object, e As EventArgs) Handles ChkOverride.CheckedChanged

  End Sub
End Class






