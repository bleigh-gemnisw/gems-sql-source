Public Class FrmUB107C
  Inherits System.Windows.Forms.Form
  Dim myUTCUSTMT As UTCUSTMT.MyData
  Dim myUTCUSTMTD As UTCUSTMTD.MyData
  Friend WrkListNo As Integer
  Friend WrkName As String
  Dim LoadScrn As Boolean
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtUsage As System.Windows.Forms.TextBox
  Friend WithEvents BtnRecalc As System.Windows.Forms.Button
  Friend WithEvents TxtReason As System.Windows.Forms.TextBox
  Friend WithEvents LnkReason As System.Windows.Forms.LinkLabel
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Friend WithEvents RbDetail As RadioButton
  Friend WithEvents RbReading As RadioButton
  Friend WithEvents LblXref As Label
  Friend WithEvents TxtXref As TextBox
  Friend WithEvents LblPos As Label
  Friend WithEvents TxtPos As TextBox
  Dim StrDebug As String
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
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents LblName As System.Windows.Forms.Label
  Friend WithEvents LblListNo As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents DtPckRead As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtReading As System.Windows.Forms.TextBox
  Friend WithEvents BtnAdd As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LblName = New System.Windows.Forms.Label()
    Me.LblListNo = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.DtPckRead = New System.Windows.Forms.DateTimePicker()
    Me.TxtReading = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.BtnAdd = New System.Windows.Forms.Button()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtUsage = New System.Windows.Forms.TextBox()
    Me.BtnRecalc = New System.Windows.Forms.Button()
    Me.TxtReason = New System.Windows.Forms.TextBox()
    Me.LnkReason = New System.Windows.Forms.LinkLabel()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.RbReading = New System.Windows.Forms.RadioButton()
    Me.RbDetail = New System.Windows.Forms.RadioButton()
    Me.TxtXref = New System.Windows.Forms.TextBox()
    Me.LblXref = New System.Windows.Forms.Label()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.LblPos = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LblName
    '
    Me.LblName.Location = New System.Drawing.Point(132, 12)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(280, 16)
    Me.LblName.TabIndex = 332
    '
    'LblListNo
    '
    Me.LblListNo.Location = New System.Drawing.Point(76, 12)
    Me.LblListNo.Name = "LblListNo"
    Me.LblListNo.Size = New System.Drawing.Size(48, 16)
    Me.LblListNo.TabIndex = 331
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(12, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(56, 16)
    Me.Label1.TabIndex = 330
    Me.Label1.Text = "Account #"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(36, 397)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(32, 16)
    Me.Label2.TabIndex = 333
    Me.Label2.Text = "Date"
    '
    'DtPckRead
    '
    Me.DtPckRead.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckRead.Location = New System.Drawing.Point(13, 416)
    Me.DtPckRead.Name = "DtPckRead"
    Me.DtPckRead.Size = New System.Drawing.Size(84, 20)
    Me.DtPckRead.TabIndex = 0
    '
    'TxtReading
    '
    Me.TxtReading.Location = New System.Drawing.Point(107, 417)
    Me.TxtReading.MaxLength = 9
    Me.TxtReading.Name = "TxtReading"
    Me.TxtReading.Size = New System.Drawing.Size(88, 20)
    Me.TxtReading.TabIndex = 1
    Me.TxtReading.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(123, 397)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(48, 16)
    Me.Label3.TabIndex = 336
    Me.Label3.Text = "Reading"
    '
    'BtnAdd
    '
    Me.BtnAdd.Location = New System.Drawing.Point(342, 415)
    Me.BtnAdd.Name = "BtnAdd"
    Me.BtnAdd.Size = New System.Drawing.Size(70, 22)
    Me.BtnAdd.TabIndex = 4
    Me.BtnAdd.Text = "Add"
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(224, 398)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(48, 16)
    Me.Label4.TabIndex = 339
    Me.Label4.Text = "Usage"
    '
    'TxtUsage
    '
    Me.TxtUsage.Location = New System.Drawing.Point(201, 417)
    Me.TxtUsage.MaxLength = 9
    Me.TxtUsage.Name = "TxtUsage"
    Me.TxtUsage.Size = New System.Drawing.Size(88, 20)
    Me.TxtUsage.TabIndex = 2
    Me.TxtUsage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'BtnRecalc
    '
    Me.BtnRecalc.Location = New System.Drawing.Point(342, 442)
    Me.BtnRecalc.Name = "BtnRecalc"
    Me.BtnRecalc.Size = New System.Drawing.Size(109, 22)
    Me.BtnRecalc.TabIndex = 5
    Me.BtnRecalc.Text = "Recalc Usage"
    '
    'TxtReason
    '
    Me.TxtReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtReason.Location = New System.Drawing.Point(295, 416)
    Me.TxtReason.MaxLength = 3
    Me.TxtReason.Name = "TxtReason"
    Me.TxtReason.Size = New System.Drawing.Size(32, 20)
    Me.TxtReason.TabIndex = 3
    '
    'LnkReason
    '
    Me.LnkReason.AutoSize = True
    Me.LnkReason.Location = New System.Drawing.Point(292, 400)
    Me.LnkReason.Name = "LnkReason"
    Me.LnkReason.Size = New System.Drawing.Size(44, 13)
    Me.LnkReason.TabIndex = 340
    Me.LnkReason.TabStop = True
    Me.LnkReason.Text = "Reason"
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DataGrdView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView.DefaultCellStyle = DataGridViewCellStyle8
    Me.DataGrdView.Location = New System.Drawing.Point(44, 54)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DataGrdView.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(439, 319)
    Me.DataGrdView.TabIndex = 341
    '
    'RbReading
    '
    Me.RbReading.AutoSize = True
    Me.RbReading.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbReading.Checked = True
    Me.RbReading.Location = New System.Drawing.Point(79, 31)
    Me.RbReading.Name = "RbReading"
    Me.RbReading.Size = New System.Drawing.Size(65, 17)
    Me.RbReading.TabIndex = 342
    Me.RbReading.TabStop = True
    Me.RbReading.Text = "Reading"
    Me.RbReading.UseVisualStyleBackColor = True
    '
    'RbDetail
    '
    Me.RbDetail.AutoSize = True
    Me.RbDetail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbDetail.Location = New System.Drawing.Point(187, 31)
    Me.RbDetail.Name = "RbDetail"
    Me.RbDetail.Size = New System.Drawing.Size(95, 17)
    Me.RbDetail.TabIndex = 343
    Me.RbDetail.Text = "Reading Detail"
    Me.RbDetail.UseVisualStyleBackColor = True
    '
    'TxtXref
    '
    Me.TxtXref.Location = New System.Drawing.Point(44, 442)
    Me.TxtXref.MaxLength = 20
    Me.TxtXref.Name = "TxtXref"
    Me.TxtXref.Size = New System.Drawing.Size(177, 20)
    Me.TxtXref.TabIndex = 344
    '
    'LblXref
    '
    Me.LblXref.Location = New System.Drawing.Point(10, 446)
    Me.LblXref.Name = "LblXref"
    Me.LblXref.Size = New System.Drawing.Size(32, 16)
    Me.LblXref.TabIndex = 345
    Me.LblXref.Text = "Xref"
    '
    'TxtPos
    '
    Me.TxtPos.Location = New System.Drawing.Point(350, 31)
    Me.TxtPos.MaxLength = 20
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(148, 20)
    Me.TxtPos.TabIndex = 346
    '
    'LblPos
    '
    Me.LblPos.AutoSize = True
    Me.LblPos.Location = New System.Drawing.Point(288, 33)
    Me.LblPos.Name = "LblPos"
    Me.LblPos.Size = New System.Drawing.Size(56, 13)
    Me.LblPos.TabIndex = 347
    Me.LblPos.Text = "Position to"
    '
    'FrmUB107C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(524, 469)
    Me.Controls.Add(Me.LblPos)
    Me.Controls.Add(Me.TxtPos)
    Me.Controls.Add(Me.LblXref)
    Me.Controls.Add(Me.TxtXref)
    Me.Controls.Add(Me.RbDetail)
    Me.Controls.Add(Me.RbReading)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.LnkReason)
    Me.Controls.Add(Me.TxtReason)
    Me.Controls.Add(Me.BtnRecalc)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtUsage)
    Me.Controls.Add(Me.BtnAdd)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtReading)
    Me.Controls.Add(Me.DtPckRead)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LblListNo)
    Me.Controls.Add(Me.LblName)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmUB107C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Customer Meter Reading History"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmUB107C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myUTCUSTMT = New UTCUSTMT.MyData(myDBConnect)
    myUTCUSTMTD = New UTCUSTMTD.MyData(myDBConnect)

    LblXref.Visible = False
    TxtXref.Visible = False
    LblPos.Visible = False
    TxtPos.Visible = False
    LoadScrn = True
    MyFrmUB107.TBarSave.Enabled = False
    LblListNo.Text = WrkListNo
    LblName.Text = WrkName

    If RbReading.Checked Then
      FormatGrid()
    Else
      FormatGridDtl()
    End If
    LoadScrn = False
  End Sub
  Private Sub FrmUB107C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmUB107B.FormatGrid()
    MyFrmUB107B.Show()
  End Sub
  Public Sub SaveData()
    Dim WrkUse As Integer
    Dim WrkDate As Integer
    Dim ErrorField(50) As String
    Dim ErrorMsg(50) As String
    WrkDate = MyUtils.SetDBDate(DtPckRead.Value)

    SetMResnTip()
    If RbReading.Checked Then
      myUTCUSTMT.GetOneRecordP(WrkListNo, "", WrkDate)
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        If myUTCUSTMT.RecordNotFound Then
          myUTCUSTMT.AddOneRecordP()
        Else
          myUTCUSTMT.UpdateOneRecordP()
        End If
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      myUTCUSTMTD.GetOneRecordP(WrkListNo, TxtXref.Text, "", WrkDate)
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        If myUTCUSTMTD.RecordNotFound Then
          myUTCUSTMTD._CMDESC1 = ""
          myUTCUSTMTD._CMDESC2 = ""
          myUTCUSTMTD.AddOneRecordP()
        Else
          myUTCUSTMTD.UpdateOneRecordP()
        End If
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
      WrkUse = myUTCUSTMTD.GetAcctSumDate(WrkListNo, "", myUTCUSTMTD._CMDATE)
      With myUTCUSTMT
        .GetOneRecordP(WrkListNo, "", myUTCUSTMTD._CMDATE)
        ._CMUSE = WrkUse
        .UpdateOneRecordP()
      End With
    End If

    DtPckRead.Value = Date.Now
    TxtPos.Text = TxtXref.Text
    TxtXref.Text = ""
    TxtReading.Text = ""
    TxtUsage.Text = ""
    TxtReason.Text = ""
    If RbReading.Checked Then
      FormatGrid()
    Else
      FormatGridDtl()
    End If
    BtnAdd.Text = "Add Item"
  End Sub
  Private Sub MoveToFile()
    If RbReading.Checked Then
      With myUTCUSTMT
        ._CMACCT = MyUtils.CnvSng(LblListNo.Text)
        ._CMTYPE = ""
        ._CMDATE = MyUtils.SetDBDate(DtPckRead.Text)
        ._CMREAD = MyUtils.CnvSng(TxtReading.Text)
        ._CMUSE = MyUtils.CnvSng(TxtUsage.Text)
        ._CMRESN = Trim(TxtReason.Text)
      End With
    Else
      With myUTCUSTMTD
        ._CMACCT = MyUtils.CnvSng(LblListNo.Text)
        ._CMXREF = Trim(TxtXref.Text)
        ._CMTYPE = ""
        ._CMDATE = MyUtils.SetDBDate(DtPckRead.Text)
        ._CMREAD = MyUtils.CnvSng(TxtReading.Text)
        ._CMUSE = MyUtils.CnvSng(TxtUsage.Text)
        ._CMRESN = Trim(TxtReason.Text)
      End With
    End If

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtXref, "")
    ErrProv.SetError(TxtReading, "")
    ErrProv.SetError(TxtReason, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Me.ForeColor = Color.DarkRed
      Select Case ErrorField(I)
        Case "cmxref"
          ErrProv.SetError(TxtXref, ErrorMsg(I))
        Case "cmread"
          ErrProv.SetError(TxtReading, ErrorMsg(I))
        Case "rsncd"
          ErrProv.SetError(TxtReason, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    Dim WrkTip As String

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If RbDetail.Checked And TxtXref.Text = "" Then
      ErrorField(I) = "cmxref"
      ErrorMsg(I) = "Xref is required"
      I = I + 1
    End If

    If TxtReading.Text = "" Then
      ErrorField(I) = "cmread"
      ErrorMsg(I) = "Reading cann be 0"
      I = I + 1
    End If

    WrkTip = Ttp1.GetToolTip(TxtReason)
    If Mid(WrkTip, 1, 1) = "*" Then
      ErrorField(I) = "rsncd"
      ErrorMsg(I) = "Invalid Reason Code"
      I = I + 1
    End If

  End Sub
  Private Sub FrmUB107C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

    MyFrmUB107.SbpScreen.Text = "UB107C"
    MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmUB107
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub TxtReading_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtReading.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtUse_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUsage.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Public Sub FormatGrid()
    Call ShowGrid()

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).Visible = False
      .Columns(1).Visible = False
      .Columns(2).Visible = True
      .Columns(2).HeaderText = "Date"
      .Columns(2).Width = 60
      .Columns(3).HeaderText = "Reading"
      .Columns(3).Width = 70
      .Columns(4).HeaderText = "Use"
      .Columns(4).Width = 70
      .Columns(5).HeaderText = "Rsn"
      .Columns(5).Width = 35
    End With

  End Sub
  Public Sub ShowGrid()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    Dim ds As DataSet = New DataSet
    ds = myUTCUSTMT.GetAllListNo(WrkListNo, "", 0, 0)
    DataGrdView.Columns.Clear()
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Public Sub FormatGridDtl()
    Call ShowGridDtl()

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).Visible = False
      .Columns(1).Visible = True
      .Columns(1).HeaderText = "Xref"
      .Columns(1).Width = 100
      .Columns(2).Visible = False
      .Columns(3).HeaderText = "Date"
      .Columns(3).Width = 60
      .Columns(4).HeaderText = "Reading"
      .Columns(4).Width = 70
      .Columns(5).HeaderText = "Use"
      .Columns(5).Width = 70
      .Columns(6).HeaderText = "Rsn"
      .Columns(6).Width = 35
      .Columns(7).HeaderText = "Desc1"
      .Columns(7).Width = 150
      .Columns(8).HeaderText = "Desc2"
      .Columns(8).Width = 150
    End With
  End Sub
  Public Sub ShowGridDtl()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    Dim ds As DataSet = New DataSet
    ds = myUTCUSTMTD.GetAllListNo(WrkListNo, TxtPos.Text, "", 0, 99999999)
    DataGrdView.Columns.Clear()
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    If RbReading.Checked Then
      DtPckRead.Value = MyUtils.GetDBDate(DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value)
      TxtReading.Text = Trim(DataGrdView.Item(3, DataGrdView.CurrentRow.Index).Value)
      TxtUsage.Text = DataGrdView.Item(4, DataGrdView.CurrentRow.Index).Value
      TxtReason.Text = DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value
    Else
      TxtXref.Text = Trim(DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value)
      DtPckRead.Value = MyUtils.GetDBDate(DataGrdView.Item(3, DataGrdView.CurrentRow.Index).Value)
      TxtReading.Text = Trim(DataGrdView.Item(4, DataGrdView.CurrentRow.Index).Value)
      TxtUsage.Text = DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value
      TxtReason.Text = DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value
    End If
    BtnAdd.Text = "Update"
  End Sub
  Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
    SaveData()
  End Sub
  Private Sub BtnRecalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRecalc.Click
    TxtUsage.Text = RecalcUsage(WrkListNo, String.Empty, MyUtils.SetDBDate(DtPckRead.Value), MyUtils.CnvSng(TxtReading.Text))
  End Sub

  Private Sub LnkReason_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkReason.LinkClicked
    MyFrmListMResn = New FrmListMResn
    MyFrmListMResn.MdiParent = Me.ParentForm
    MyFrmListMResn.WrkScreen = "C"
    MyFrmListMResn.WrkCode = TxtReason.Text
    MyFrmListMResn.Show()
  End Sub
  Private Sub SetMResnTip()
    Dim WrkDesc As String

    If Not TxtReason.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetUTMRESNDesc(TxtReason.Text)
    Ttp1.SetToolTip(TxtReason, WrkDesc)
  End Sub

  Private Sub RbReading_Click(sender As Object, e As EventArgs) Handles RbReading.Click
    LblXref.Visible = False
    TxtXref.Visible = False
    LblPos.Visible = False
    TxtPos.Visible = False
    FormatGrid()
  End Sub
  Private Sub RbDetail_Click(sender As Object, e As EventArgs) Handles RbDetail.Click
    LblXref.Visible = True
    TxtXref.Visible = True
    LblPos.Visible = True
    TxtPos.Visible = True
    FormatGridDtl()
  End Sub

  Private Sub RbReading_CheckedChanged(sender As Object, e As EventArgs) Handles RbReading.CheckedChanged

  End Sub

  Private Sub RbDetail_CheckedChanged(sender As Object, e As EventArgs) Handles RbDetail.CheckedChanged

  End Sub
End Class






