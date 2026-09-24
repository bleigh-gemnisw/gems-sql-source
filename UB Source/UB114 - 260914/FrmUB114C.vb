Public Class FrmUB114C
  Inherits System.Windows.Forms.Form

  Dim myUTDEDDIFF As UTDEDDIFF.MyData
  Friend WrkListNo As Integer
  Friend WrkMeterNo As String
  Friend WrkName As String
  Dim WrkEditDate As Integer
  Dim LoadScrn As Boolean
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Dim StrDebug As String

#Region " Windows Form Designer generated code "
  Public Sub New()
    MyBase.New()
    InitializeComponent()
  End Sub

  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing Then
      If Not (components Is Nothing) Then components.Dispose()
    End If
    MyBase.Dispose(disposing)
  End Sub

  Private components As System.ComponentModel.IContainer
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents LblName As System.Windows.Forms.Label
  Friend WithEvents LblListNo As System.Windows.Forms.Label
  Friend WithEvents LblMeterNo As System.Windows.Forms.Label
  Friend WithEvents LabelMeter As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents DtPckRead As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtReading As System.Windows.Forms.TextBox
  Friend WithEvents BtnAdd As System.Windows.Forms.Button
  Friend WithEvents TxtReason As System.Windows.Forms.TextBox
  Friend WithEvents LnkReason As System.Windows.Forms.LinkLabel

  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LblName = New System.Windows.Forms.Label()
    Me.LblListNo = New System.Windows.Forms.Label()
    Me.LblMeterNo = New System.Windows.Forms.Label()
    Me.LabelMeter = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.DtPckRead = New System.Windows.Forms.DateTimePicker()
    Me.TxtReading = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.BtnAdd = New System.Windows.Forms.Button()
    Me.TxtReason = New System.Windows.Forms.TextBox()
    Me.LnkReason = New System.Windows.Forms.LinkLabel()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
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
    'LabelMeter
    '
    Me.LabelMeter.Location = New System.Drawing.Point(420, 12)
    Me.LabelMeter.Name = "LabelMeter"
    Me.LabelMeter.Size = New System.Drawing.Size(48, 16)
    Me.LabelMeter.TabIndex = 342
    Me.LabelMeter.Text = "Meter #"
    '
    'LblMeterNo
    '
    Me.LblMeterNo.Location = New System.Drawing.Point(468, 12)
    Me.LblMeterNo.Name = "LblMeterNo"
    Me.LblMeterNo.Size = New System.Drawing.Size(140, 16)
    Me.LblMeterNo.TabIndex = 343
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
    'TxtReason
    '
    Me.TxtReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtReason.Location = New System.Drawing.Point(207, 416)
    Me.TxtReason.MaxLength = 3
    Me.TxtReason.Name = "TxtReason"
    Me.TxtReason.Size = New System.Drawing.Size(32, 20)
    Me.TxtReason.TabIndex = 2
    '
    'LnkReason
    '
    Me.LnkReason.AutoSize = True
    Me.LnkReason.Location = New System.Drawing.Point(204, 400)
    Me.LnkReason.Name = "LnkReason"
    Me.LnkReason.Size = New System.Drawing.Size(44, 13)
    Me.LnkReason.TabIndex = 340
    Me.LnkReason.TabStop = True
    Me.LnkReason.Text = "Reason"
    '
    'BtnAdd
    '
    Me.BtnAdd.Location = New System.Drawing.Point(267, 415)
    Me.BtnAdd.Name = "BtnAdd"
    Me.BtnAdd.Size = New System.Drawing.Size(82, 22)
    Me.BtnAdd.TabIndex = 3
    Me.BtnAdd.Text = "Add Item"
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
    Me.DataGrdView.Location = New System.Drawing.Point(44, 39)
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
    Me.DataGrdView.Size = New System.Drawing.Size(520, 334)
    Me.DataGrdView.TabIndex = 341
    '
    'FrmUB114C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(620, 469)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.LnkReason)
    Me.Controls.Add(Me.TxtReason)
    Me.Controls.Add(Me.BtnAdd)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtReading)
    Me.Controls.Add(Me.DtPckRead)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LabelMeter)
    Me.Controls.Add(Me.LblMeterNo)
    Me.Controls.Add(Me.LblListNo)
    Me.Controls.Add(Me.LblName)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmUB114C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Customer Meter/Deduct History"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()
  End Sub
#End Region

  Private Sub FrmUB114C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myUTDEDDIFF = New UTDEDDIFF.MyData(myDBConnect)
    LoadScrn = True
    MyFrmUB114.TBarSave.Enabled = False
    MyFrmUB114.TBarDelete.Enabled = False
    LblListNo.Text = WrkListNo
    LblMeterNo.Text = WrkMeterNo
    LblName.Text = WrkName
    FormatGrid()
    LoadScrn = False
  End Sub

  Private Sub FrmUB114C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmUB114.TBarDelete.Enabled = False
    MyFrmUB114B.FormatGrid()
    MyFrmUB114B.Show()
  End Sub

  Public Sub SaveData()
    Dim WrkDate As Integer
    Dim WrkDiff As Long
    Dim ErrorField(50) As String
    Dim ErrorMsg(50) As String
    Dim IsUpdate As Boolean = (BtnAdd.Text = "Update")

    If IsUpdate Then
      WrkDate = WrkEditDate
    Else
      WrkDate = MyUtils.SetDBDate(DtPckRead.Value)
    End If

    ClearErrors()
    SetMResnTip()
    EditChecks(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If

    myUTDEDDIFF.GetOneRecordP(WrkListNo, WrkMeterNo, WrkDate)

    If Not IsUpdate AndAlso Not myUTDEDDIFF.RecordNotFound Then
      MsgBox("A reading already exists for this account, meter and date.", MsgBoxStyle.Exclamation, "Duplicate reading date")
      Exit Sub
    End If
    If IsUpdate AndAlso myUTDEDDIFF.RecordNotFound Then
      MsgBox("The reading could not be found. Refresh the history and try again.", MsgBoxStyle.Exclamation, "Reading not found")
      Exit Sub
    End If

    WrkDiff = RecalcDedDiff(WrkListNo, WrkMeterNo, WrkDate, MyUtils.CnvSng(TxtReading.Text))
    MoveToFile(WrkDiff, WrkDate)

    If IsUpdate Then
      myUTDEDDIFF.UpdateOneRecordP()
    Else
      myUTDEDDIFF.AddOneRecordP()
    End If

    'Adding an older reading or changing an existing reading can affect every
    'difference after it, so keep this meter's history correct automatically.
    myUTDEDDIFF.RecalcAllDifferences(WrkListNo, WrkMeterNo)

    ResetEntry()
    FormatGrid()
    ClearErrors()
  End Sub

  Private Sub ResetEntry()
    WrkEditDate = 0
    DtPckRead.Enabled = True
    DtPckRead.Value = Date.Now
    TxtReading.Text = ""
    TxtReason.Text = ""
    BtnAdd.Text = "Add Item"
    MyFrmUB114.TBarDelete.Enabled = False
  End Sub

  Private Sub ClearErrors()
    ErrProv.SetError(TxtReading, "")
    ErrProv.SetError(TxtReason, "")
    Me.ForeColor = SystemColors.ControlText
  End Sub

  Private Sub MoveToFile(ByVal WrkDiff As Long, ByVal WrkDate As Integer)
    With myUTDEDDIFF
      ._DDACCT = MyUtils.CnvSng(LblListNo.Text)
      ._DDMETER = Trim(WrkMeterNo)
      ._DDDATE = WrkDate
      ._DDREAD = MyUtils.CnvSng(TxtReading.Text)
      ._DDDIFF = WrkDiff
      ._DDRESN = Trim(TxtReason.Text)
    End With
  End Sub

  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ClearErrors()

    For I = 0 To ErrorField.GetUpperBound(0)
      Me.ForeColor = Color.DarkRed
      Select Case ErrorField(I)
        Case "ddread"
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
    Dim WrkDate As Integer
    Dim WrkReading As Long
    Dim PrevReading As Long
    Dim NextReading As Long
    Dim dsReading As DataSet

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then Exit For
    Next

    If TxtReading.Text = "" Then
      ErrorField(I) = "ddread"
      ErrorMsg(I) = "Reading cannot be 0"
      I = I + 1
    Else
      If BtnAdd.Text = "Update" Then
        WrkDate = WrkEditDate
      Else
        WrkDate = MyUtils.SetDBDate(DtPckRead.Value)
      End If
      WrkReading = CLng(Val(TxtReading.Text))

      ' A reading cannot be less than the reading immediately before it
      ' for this same account and meter.
      dsReading = myUTDEDDIFF.GetLastbyDate(WrkListNo, WrkMeterNo, WrkDate - 1)
      If Not dsReading Is Nothing AndAlso dsReading.Tables.Count > 0 AndAlso dsReading.Tables(0).Rows.Count > 0 Then
        PrevReading = CLng(dsReading.Tables(0).Rows(0).Item("ddread"))
        If WrkReading < PrevReading Then
          ErrorField(I) = "ddread"
          ErrorMsg(I) = "Reading cannot be less than previous reading (" & PrevReading.ToString() & ")"
          I = I + 1
        End If
      End If

      ' If there is a later reading (update OR an older-date add), the entered
      ' reading cannot be greater than that following reading.  A normal newest
      ' add has no following record, so there is no upper check.
      dsReading = myUTDEDDIFF.GetNextbyDate(WrkListNo, WrkMeterNo, WrkDate)
      If Not dsReading Is Nothing AndAlso dsReading.Tables.Count > 0 AndAlso dsReading.Tables(0).Rows.Count > 0 Then
        NextReading = CLng(dsReading.Tables(0).Rows(0).Item("ddread"))
        If WrkReading > NextReading Then
          ErrorField(I) = "ddread"
          ErrorMsg(I) = "Reading cannot be greater than following reading (" & NextReading.ToString() & ")"
          I = I + 1
        End If
      End If
    End If

    WrkTip = Ttp1.GetToolTip(TxtReason)
    If Mid(WrkTip, 1, 1) = "*" Then
      ErrorField(I) = "rsncd"
      ErrorMsg(I) = "Invalid Reason Code"
      I = I + 1
    End If
  End Sub

  Private Sub FrmUB114C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmUB114.SbpScreen.Text = "UB114C"
    SetDeleteState()
    MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmUB114
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub

  Private Sub TxtReading_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtReading.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Public Sub FormatGrid()
    ShowGrid()
    SetDeleteState()
    If DataGrdView.Columns.Count = 0 Then Exit Sub
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).Visible = False             'Account
      .Columns(1).Visible = False             'Meter (shown above grid)
      .Columns(2).HeaderText = "Date"
      .Columns(2).Width = 75
      .Columns(3).HeaderText = "Reading"
      .Columns(3).Width = 95
      .Columns(4).HeaderText = "Difference"
      .Columns(4).Width = 95
      .Columns(5).HeaderText = "Rsn"
      .Columns(5).Width = 45
    End With
  End Sub

  Public Sub ShowGrid()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    Dim ds As DataSet = myUTDEDDIFF.GetAllListNo(WrkListNo, WrkMeterNo, 0, 0)
    DataGrdView.Columns.Clear()
    If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
      DataGrdView.DataSource = ds.Tables(0)
      DataGrdView.Refresh()
    End If
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub

  Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    If DataGrdView.CurrentRow Is Nothing Then Exit Sub
    WrkEditDate = CInt(DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value)
    DtPckRead.Value = MyUtils.GetDBDate(WrkEditDate)
    DtPckRead.Enabled = False                 'Date is part of the key and cannot be changed.
    TxtReading.Text = Trim(DataGrdView.Item(3, DataGrdView.CurrentRow.Index).Value)
    TxtReason.Text = DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value
    BtnAdd.Text = "Update"
    MyFrmUB114.TBarDelete.Enabled = True
  End Sub

  Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
    SaveData()
  End Sub

  Public Sub DeleteData(ByRef Cancel As Boolean)
    Cancel = True
    If DataGrdView.Rows.Count = 0 OrElse DataGrdView.CurrentRow Is Nothing Then Exit Sub

    'Delete acts on the currently selected history row.  A double-click is not
    'required just to enable/use the toolbar Delete button.
    WrkEditDate = CInt(DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value)

    Dim Answer As Integer
    Answer = MsgBox("Delete reading?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    myUTDEDDIFF.DeleteOneRecordP(WrkListNo, WrkMeterNo, WrkEditDate)
    myUTDEDDIFF.RecalcAllDifferences(WrkListNo, WrkMeterNo)
    Cancel = False

    ResetEntry()
    FormatGrid()
  End Sub

  Private Sub SetDeleteState()
    If MyFrmUB114 Is Nothing Then Exit Sub
    MyFrmUB114.TBarDelete.Enabled = (DataGrdView IsNot Nothing AndAlso DataGrdView.Rows.Count > 0)
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
End Class
