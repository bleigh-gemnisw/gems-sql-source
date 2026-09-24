Public Class FrmMR001C

  Inherits System.Windows.Forms.Form
  Dim myMRBCH As MRBCH.myData
  Dim myMRBCHD As MRBCHD.myData
  Dim myMRCODE As MRCODE.myData
  Dim ds As DataSet = New DataSet
  Friend WithEvents BtnShowCode As System.Windows.Forms.Button
  Friend WithEvents TxtGetCode As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WrkBatchNo As Integer
  Friend WithEvents LblAmount2 As System.Windows.Forms.Label
  Friend WithEvents TxtCheck As System.Windows.Forms.TextBox
  Friend WithEvents BtnAdd As System.Windows.Forms.Button
  Friend WithEvents LblAmount1 As System.Windows.Forms.Label
  Friend WithEvents TxtCash As System.Windows.Forms.TextBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents TxtCode As System.Windows.Forms.TextBox
  Friend WithEvents LblCheck As System.Windows.Forms.Label
  Friend WithEvents LblCash As System.Windows.Forms.Label
  Friend WithEvents LblTotal As System.Windows.Forms.Label
  Friend WithEvents LnkCode As System.Windows.Forms.LinkLabel
  Friend WithEvents DataGrdView As DataGridView
  Friend WithEvents RbBatch As RadioButton
  Friend WithEvents RbCodes As RadioButton
  Dim WrkSeqNo As Integer
  Friend WithEvents LblCredit As Label
  Friend WithEvents TxtCredit As TextBox
  Friend WithEvents LblAmount3 As Label
  Dim SaveAddLeftPos As Integer

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
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMR001C))
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.BtnShowCode = New System.Windows.Forms.Button()
    Me.TxtGetCode = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.LblAmount2 = New System.Windows.Forms.Label()
    Me.TxtCheck = New System.Windows.Forms.TextBox()
    Me.BtnAdd = New System.Windows.Forms.Button()
    Me.LblAmount1 = New System.Windows.Forms.Label()
    Me.TxtCash = New System.Windows.Forms.TextBox()
    Me.TxtCode = New System.Windows.Forms.TextBox()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.LblCash = New System.Windows.Forms.Label()
    Me.LblCheck = New System.Windows.Forms.Label()
    Me.LblTotal = New System.Windows.Forms.Label()
    Me.LnkCode = New System.Windows.Forms.LinkLabel()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.RbCodes = New System.Windows.Forms.RadioButton()
    Me.RbBatch = New System.Windows.Forms.RadioButton()
    Me.LblCredit = New System.Windows.Forms.Label()
    Me.LblAmount3 = New System.Windows.Forms.Label()
    Me.TxtCredit = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    '
    'BtnShowCode
    '
    Me.BtnShowCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnShowCode.Location = New System.Drawing.Point(122, 3)
    Me.BtnShowCode.Name = "BtnShowCode"
    Me.BtnShowCode.Size = New System.Drawing.Size(56, 24)
    Me.BtnShowCode.TabIndex = 1
    Me.BtnShowCode.TabStop = False
    Me.BtnShowCode.Text = "&Show"
    '
    'TxtGetCode
    '
    Me.TxtGetCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtGetCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGetCode.Location = New System.Drawing.Point(74, 6)
    Me.TxtGetCode.MaxLength = 3
    Me.TxtGetCode.Name = "TxtGetCode"
    Me.TxtGetCode.Size = New System.Drawing.Size(40, 20)
    Me.TxtGetCode.TabIndex = 50
    Me.TxtGetCode.TabStop = False
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(12, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(56, 18)
    Me.Label1.TabIndex = 11
    Me.Label1.Text = "Find Code"
    '
    'LblAmount2
    '
    Me.LblAmount2.AutoSize = True
    Me.LblAmount2.Location = New System.Drawing.Point(196, 343)
    Me.LblAmount2.Name = "LblAmount2"
    Me.LblAmount2.Size = New System.Drawing.Size(38, 13)
    Me.LblAmount2.TabIndex = 346
    Me.LblAmount2.Text = "Check"
    '
    'TxtCheck
    '
    Me.TxtCheck.Location = New System.Drawing.Point(173, 362)
    Me.TxtCheck.MaxLength = 12
    Me.TxtCheck.Name = "TxtCheck"
    Me.TxtCheck.Size = New System.Drawing.Size(88, 20)
    Me.TxtCheck.TabIndex = 2
    Me.TxtCheck.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'BtnAdd
    '
    Me.BtnAdd.Location = New System.Drawing.Point(361, 363)
    Me.BtnAdd.Name = "BtnAdd"
    Me.BtnAdd.Size = New System.Drawing.Size(52, 20)
    Me.BtnAdd.TabIndex = 4
    Me.BtnAdd.Text = "Add"
    '
    'LblAmount1
    '
    Me.LblAmount1.AutoSize = True
    Me.LblAmount1.Location = New System.Drawing.Point(92, 343)
    Me.LblAmount1.Name = "LblAmount1"
    Me.LblAmount1.Size = New System.Drawing.Size(31, 13)
    Me.LblAmount1.TabIndex = 343
    Me.LblAmount1.Text = "Cash"
    '
    'TxtCash
    '
    Me.TxtCash.Location = New System.Drawing.Point(75, 362)
    Me.TxtCash.MaxLength = 12
    Me.TxtCash.Name = "TxtCash"
    Me.TxtCash.Size = New System.Drawing.Size(88, 20)
    Me.TxtCash.TabIndex = 1
    Me.TxtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtCode
    '
    Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode.Location = New System.Drawing.Point(25, 362)
    Me.TxtCode.MaxLength = 3
    Me.TxtCode.Name = "TxtCode"
    Me.TxtCode.Size = New System.Drawing.Size(40, 20)
    Me.TxtCode.TabIndex = 0
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LblCash
    '
    Me.LblCash.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCash.Location = New System.Drawing.Point(368, 14)
    Me.LblCash.Name = "LblCash"
    Me.LblCash.Size = New System.Drawing.Size(62, 16)
    Me.LblCash.TabIndex = 347
    Me.LblCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCheck
    '
    Me.LblCheck.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCheck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCheck.Location = New System.Drawing.Point(436, 14)
    Me.LblCheck.Name = "LblCheck"
    Me.LblCheck.Size = New System.Drawing.Size(62, 16)
    Me.LblCheck.TabIndex = 348
    Me.LblCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTotal
    '
    Me.LblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotal.Location = New System.Drawing.Point(572, 14)
    Me.LblTotal.Name = "LblTotal"
    Me.LblTotal.Size = New System.Drawing.Size(62, 16)
    Me.LblTotal.TabIndex = 349
    Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LnkCode
    '
    Me.LnkCode.Location = New System.Drawing.Point(22, 343)
    Me.LnkCode.Name = "LnkCode"
    Me.LnkCode.Size = New System.Drawing.Size(38, 16)
    Me.LnkCode.TabIndex = 350
    Me.LnkCode.TabStop = True
    Me.LnkCode.Text = "Code"
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView.DefaultCellStyle = DataGridViewCellStyle2
    Me.DataGrdView.Location = New System.Drawing.Point(15, 44)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(621, 285)
    Me.DataGrdView.TabIndex = 351
    '
    'RbCodes
    '
    Me.RbCodes.AutoSize = True
    Me.RbCodes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbCodes.Checked = True
    Me.RbCodes.Location = New System.Drawing.Point(581, 341)
    Me.RbCodes.Name = "RbCodes"
    Me.RbCodes.Size = New System.Drawing.Size(55, 17)
    Me.RbCodes.TabIndex = 352
    Me.RbCodes.TabStop = True
    Me.RbCodes.Text = "Codes"
    Me.RbCodes.UseVisualStyleBackColor = True
    '
    'RbBatch
    '
    Me.RbBatch.AutoSize = True
    Me.RbBatch.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbBatch.Location = New System.Drawing.Point(488, 362)
    Me.RbBatch.Name = "RbBatch"
    Me.RbBatch.Size = New System.Drawing.Size(148, 17)
    Me.RbBatch.TabIndex = 353
    Me.RbBatch.Text = "Batch Cash/Check/Credit"
    Me.RbBatch.UseVisualStyleBackColor = True
    '
    'LblCredit
    '
    Me.LblCredit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCredit.Location = New System.Drawing.Point(504, 14)
    Me.LblCredit.Name = "LblCredit"
    Me.LblCredit.Size = New System.Drawing.Size(62, 16)
    Me.LblCredit.TabIndex = 354
    Me.LblCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblAmount3
    '
    Me.LblAmount3.AutoSize = True
    Me.LblAmount3.Location = New System.Drawing.Point(291, 345)
    Me.LblAmount3.Name = "LblAmount3"
    Me.LblAmount3.Size = New System.Drawing.Size(34, 13)
    Me.LblAmount3.TabIndex = 355
    Me.LblAmount3.Text = "Credit"
    '
    'TxtCredit
    '
    Me.TxtCredit.Location = New System.Drawing.Point(267, 362)
    Me.TxtCredit.MaxLength = 12
    Me.TxtCredit.Name = "TxtCredit"
    Me.TxtCredit.Size = New System.Drawing.Size(88, 20)
    Me.TxtCredit.TabIndex = 3
    Me.TxtCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'FrmMR001C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(648, 392)
    Me.Controls.Add(Me.TxtCredit)
    Me.Controls.Add(Me.LblAmount3)
    Me.Controls.Add(Me.LblCredit)
    Me.Controls.Add(Me.RbBatch)
    Me.Controls.Add(Me.RbCodes)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.LnkCode)
    Me.Controls.Add(Me.LblTotal)
    Me.Controls.Add(Me.LblCheck)
    Me.Controls.Add(Me.LblCash)
    Me.Controls.Add(Me.TxtCode)
    Me.Controls.Add(Me.LblAmount2)
    Me.Controls.Add(Me.TxtCheck)
    Me.Controls.Add(Me.BtnAdd)
    Me.Controls.Add(Me.LblAmount1)
    Me.Controls.Add(Me.TxtCash)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnShowCode)
    Me.Controls.Add(Me.TxtGetCode)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmMR001C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Batch"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmMR001B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myMRBCH = New MRBCH.MyData()
    myMRBCH.MyDBConn = myDBConnect
    myMRBCHD = New MRBCHD.MyData()
    myMRBCHD.MyDBConn = myDBConnect
    myMRCODE = New MRCODE.MyData()
    myMRCODE.MyDBConn = myDBConnect
    SaveAddLeftPos = BtnAdd.Left
    With MyFrmMR001
      .TBarNew.Enabled = False
      .TBarChange.Enabled = False
      .TBarDelete.Enabled = False
      .TBarDelete.Text = "Delete"
      .TBarPrtEdits.Enabled = False
      .TBarPost.Enabled = False
    End With
    If MyTotalEntry Then
      LblAmount1.Text = "Total"
      LblAmount2.Visible = False
      LblAmount3.Visible = False
      TxtCheck.Visible = False
      TxtCredit.Visible = False
      BtnAdd.Left = TxtCheck.Left
    Else
      LblAmount1.Text = "Cash"
      LblAmount2.Visible = True
      TxtCheck.Visible = True
      RbCodes.Visible = False
      RbBatch.Visible = False
    End If

    FormatGrid()
    Me.Text = Me.Text & " " & WrkBatchNo
  End Sub
  Private Sub GetTotals()
    With myMRBCH
      .GetOneRecordP(WrkBatchNo)
      LblCash.Text = Format(._TCASH, "fixed")
      LblCheck.Text = Format(._TCHECK, "fixed")
      LblCredit.Text = Format(._TCREDIT, "fixed")
      LblTotal.Text = Format(._TAMT, "fixed")
    End With
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    FormatGrid()
  End Sub
  Public Sub FormatGrid()
    Call ShowGrid()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "Acct No"
      .Columns(0).Width = 100
      .Columns(1).HeaderText = "Description"
      .Columns(1).Width = 200
      .Columns(2).HeaderText = "Code"
      .Columns(2).Width = 50
      .Columns(3).HeaderText = "Cash"
      .Columns(3).Width = 60
      .Columns(4).HeaderText = "Check"
      .Columns(4).Width = 60
      .Columns(5).HeaderText = "Credit"
      .Columns(5).Width = 60
      .Columns(6).HeaderText = "Total"
      .Columns(6).Width = 60
    End With
  End Sub
  Public Sub ShowGrid()
    Dim ds2 As DataSet

    ds = myMRBCHD.GetViewbyBatch(WrkBatchNo, 9999)
    ds2 = PopulateGrid()
    DataGrdView.DataSource = ds2.Tables(0)
    DataGrdView.Refresh()
    GetTotals()
    myMRBCHD.CloseFile()
  End Sub
  Private Sub FrmMR001C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmMR001.SbpScreen.Text = "MR001C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub DataGrdview_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    MyFrmMR001D = New FrmMR001D
    MyFrmMR001D.MdiParent = Me.ParentForm
    MyFrmMR001D.WrkBatchNo = WrkBatchNo
    MyFrmMR001D.WrkCode = DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value
    MyFrmMR001D.Show()
    Me.Hide()
  End Sub
  Private Sub FrmMR001C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    myMRBCH.GetOneRecordP(WrkBatchNo)
    With myMRBCH
      ._STATUS = "S"
      .UpdateOneRecordP()
    End With
    With MyFrmMR001
      .TBarNew.Text = "New Batch"
      .TBarNew.Enabled = True
      .TBarChange.Enabled = True
      .TBarDelete.Text = "Delete Batch"
      .TBarDelete.Enabled = True
      .TBarPrtEdits.Enabled = True
      .TBarPost.Enabled = True
    End With
    MyFrmMR001B.FormatGrid()
    MyFrmMR001B.Show()

  End Sub
  Private Sub BtnShowCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShowCode.Click
    ShowCode()
  End Sub
  Private Sub ShowCode()

    If TxtGetCode.Text = String.Empty Then Exit Sub

    myMRBCHD.GetOneRecordP(WrkBatchNo, TxtGetCode.Text)
    If myMRBCHD.RecordNotFound Then
      MsgBox("Cannot find code", MsgBoxStyle.Exclamation, "Code is not found")
      Exit Sub
    End If

    FormatGrid()

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    TxtGetCode.Focus()
    MyFrmMR001D = New FrmMR001D

    With MyFrmMR001D
      .WrkBatchNo = WrkBatchNo
      .WrkCode = TxtGetCode.Text
      .MdiParent = Me.ParentForm
      .Show()
    End With

    TxtGetCode.Text = ""
    Windows.Forms.Cursor.Current = Cursors.Default
    Me.Hide()

  End Sub
  Private Sub TxtCash_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCash.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, True)
  End Sub
  Private Sub TxtCheck_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCheck.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      AddRecord()
      Exit Sub
    End If
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, True)
  End Sub
  Private Sub TxtGetCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGetCode.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      ShowCode()
      Exit Sub
    End If
  End Sub
  Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
    If RbCodes.Checked Then
      AddRecord()
    Else
      With myMRBCH
        .GetOneRecordP(WrkBatchNo)
        ._TCASH = MyUtils.CnvSng(TxtCash.Text)
        ._TCHECK = MyUtils.CnvSng(TxtCheck.Text)
        ._TCREDIT = MyUtils.CnvSng(TxtCredit.Text)
        If ._TCASH + ._TCHECK + ._TCREDIT = ._TAMT Then
          .UpdateOneRecordP()
          LblCash.Text = Format(._TCASH, "fixed")
          LblCheck.Text = Format(._TCHECK, "fixed")
          LblCredit.Text = Format(._TCREDIT, "fixed")
        Else
          MsgBox("Correct and retry", MsgBoxStyle.Exclamation, "Cash + Check + Credit does not match Total")
        End If
      End With
    End If
  End Sub
  Public Sub AddRecord()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      SaveData()
    Else
      ShowError(ErrorField, ErrorMsg)
    End If
    FormatGrid()
    GetTotals()
    TxtCode.Text = String.Empty
    TxtCash.Text = String.Empty
    TxtCheck.Text = String.Empty
    TxtCredit.Text = String.Empty
    TxtCode.Focus()
  End Sub
  Public Sub SaveData()

    With myMRBCH
      .GetOneRecordP(WrkBatchNo)
      If MyTotalEntry Then
        ._TAMT = ._TAMT + +MyUtils.CnvSng(TxtCash.Text)
      Else
        ._TCASH = ._TCASH + MyUtils.CnvSng(TxtCash.Text)
        ._TCHECK = ._TCHECK + MyUtils.CnvSng(TxtCheck.Text)
        ._TCREDIT = ._TCREDIT + MyUtils.CnvSng(TxtCredit.Text)
        ._TAMT = ._TCASH + ._TCHECK + ._TCREDIT
      End If
      .UpdateOneRecordP()
    End With

    With myMRBCHD
      .GetOneRecordP(WrkBatchNo, TxtCode.Text)
      If .RecordNotFound Then
        ._BCHNO = WrkBatchNo
        ._CODE = TxtCode.Text
        If MyTotalEntry Then
          ._CASH = 0
          ._CHECK = 0
          ._CREDIT = 0
          ._TOTAL = MyUtils.CnvSng(TxtCash.Text)
        Else
          ._CASH = MyUtils.CnvSng(TxtCash.Text)
          ._CHECK = MyUtils.CnvSng(TxtCheck.Text)
          ._CREDIT = MyUtils.CnvSng(TxtCredit.Text)
          ._TOTAL = ._CASH + ._CHECK + ._CREDIT
        End If
        .AddOneRecordP()
      Else
        If MyTotalEntry Then
          ._CASH = 0
          ._CHECK = 0
          ._CREDIT = 0
          ._TOTAL = MyUtils.CnvSng(TxtCash.Text)
        Else
          ._CASH = MyUtils.CnvSng(TxtCash.Text)
          ._CHECK = MyUtils.CnvSng(TxtCheck.Text)
          ._CREDIT = MyUtils.CnvSng(TxtCredit.Text)
          ._TOTAL = ._CASH + ._CHECK + ._CREDIT
        End If
        .UpdateOneRecordP()
      End If
    End With
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    ErrProv.SetError(TxtCode, "")
    Dim I As Integer
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "code"
          ErrProv.SetError(TxtCode, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    Dim Pos As Integer
    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    myMRCODE.GetOneRecordP(TxtCode.Text)
    If myMRCODE.RecordNotFound Then
      ErrorField(I) = "code"
      ErrorMsg(I) = "Invalid Code"
      I = I + 1
    Else
      myMRBCH.GetOneRecordP(WrkBatchNo)
      Pos = InStr(Trim(MySelCodes), TxtCode.Text)
      If MySelCodes = "" Or Pos > 0 Then
      Else
        ErrorField(I) = "code"
        ErrorMsg(I) = "Code is not valid for this batch"
        I = I + 1
      End If
    End If
  End Sub
  Private Function PopulateGrid() As DataSet
    Dim dsGrid As New DataSet
    Dim myTable As New DataTable
    Dim dr As DataRow
    Dim I As Integer

    With myTable
      .TableName = "mytable"
      .Columns.Add("AcctNo", Type.GetType("System.String"))
      .Columns.Add("Description", Type.GetType("System.String"))
      .Columns.Add("Code", Type.GetType("System.String"))
      .Columns.Add("Cash", Type.GetType("System.Decimal"))
      .Columns.Add("Check", Type.GetType("System.Decimal"))
      .Columns.Add("Credit", Type.GetType("System.Decimal"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
    End With
    dsGrid.Tables.Add(myTable)

    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        dsGrid.Tables(0).NewRow()
        dr = dsGrid.Tables(0).NewRow
        myMRCODE.GetOneRecordP(.Item("code"))
        If Not myMRCODE.RecordNotFound Then
          dr("acctno") = myMRCODE._ACCT
          dr("description") = myMRCODE._DESCR
        End If
        dr("code") = .Item("code")
        dr("cash") = .Item("cash")
        dr("check") = .Item("check")
        dr("credit") = .Item("credit")
        dr("total") = .Item("total")
        dsGrid.Tables(0).Rows.Add(dr)
      End With
    Next

    Return dsGrid
  End Function


  Private Sub LnkCode_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode.LinkClicked
    MyFrmListCode = New FrmListCode
    MyFrmListCode.MdiParent = Me.ParentForm
    MyFrmListCode.WrkBatchNo = WrkBatchNo
    MyFrmListCode.Show()
    Me.Hide()
  End Sub

  Private Sub RbCodes_Click(sender As Object, e As EventArgs) Handles RbCodes.Click
    TxtCode.Visible = True
    LnkCode.Visible = True
    LblAmount1.Text = "Total"
    LblAmount2.Visible = False
    LblAmount3.Visible = False
    TxtCash.Text = ""
    TxtCheck.Visible = False
    TxtCredit.Visible = False
    BtnAdd.Left = TxtCheck.Left
    BtnAdd.Text = "Add"
  End Sub
  Private Sub RbBatch_Click(sender As Object, e As EventArgs) Handles RbBatch.Click
    TxtCode.Visible = False
    LnkCode.Visible = False
    LblAmount1.Text = "Cash"
    LblAmount2.Visible = True
    LblAmount3.Visible = True
    TxtCheck.Visible = True
    TxtCredit.Visible = True
    BtnAdd.Left = SaveAddLeftPos
    BtnAdd.Text = "Update"
  End Sub

End Class
