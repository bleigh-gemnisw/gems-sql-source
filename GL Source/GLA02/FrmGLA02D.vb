Public Class FrmGLA02D

  Inherits System.Windows.Forms.Form
  Dim myBCHHDR As BCHHDR.myData
  Dim myTAXBCH As TAXBCH.myData
  Dim myTAXBCHL1 As TAXBCHL1.myData
  Dim ds As DataSet = New DataSet
  Friend WithEvents BtnShowSeq As System.Windows.Forms.Button
  Friend WithEvents TxtSeq As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents LblDebit As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents LblCredit As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WrkBatchNo As Integer
  Friend WithEvents DataGrdView As DataGridView
  Friend WrkTran As Integer

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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGLA02D))
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.BtnShowSeq = New System.Windows.Forms.Button()
    Me.TxtSeq = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.LblDebit = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.LblCredit = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    '
    'BtnShowSeq
    '
    Me.BtnShowSeq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnShowSeq.Location = New System.Drawing.Point(108, 22)
    Me.BtnShowSeq.Name = "BtnShowSeq"
    Me.BtnShowSeq.Size = New System.Drawing.Size(56, 24)
    Me.BtnShowSeq.TabIndex = 1
    Me.BtnShowSeq.TabStop = False
    Me.BtnShowSeq.Text = "&Show"
    '
    'TxtSeq
    '
    Me.TxtSeq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSeq.Location = New System.Drawing.Point(60, 25)
    Me.TxtSeq.MaxLength = 11
    Me.TxtSeq.Name = "TxtSeq"
    Me.TxtSeq.Size = New System.Drawing.Size(42, 20)
    Me.TxtSeq.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(12, 28)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(42, 18)
    Me.Label1.TabIndex = 11
    Me.Label1.Text = "Seq #"
    '
    'LblDebit
    '
    Me.LblDebit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblDebit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDebit.Location = New System.Drawing.Point(495, 9)
    Me.LblDebit.Name = "LblDebit"
    Me.LblDebit.Size = New System.Drawing.Size(79, 18)
    Me.LblDebit.TabIndex = 223
    Me.LblDebit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(419, 9)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(70, 16)
    Me.Label6.TabIndex = 224
    Me.Label6.Text = "Total Debit"
    '
    'LblCredit
    '
    Me.LblCredit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCredit.Location = New System.Drawing.Point(495, 25)
    Me.LblCredit.Name = "LblCredit"
    Me.LblCredit.Size = New System.Drawing.Size(79, 18)
    Me.LblCredit.TabIndex = 221
    Me.LblCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(419, 25)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(70, 15)
    Me.Label3.TabIndex = 222
    Me.Label3.Text = "Total Credit"
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView.DefaultCellStyle = DataGridViewCellStyle1
    Me.DataGrdView.Location = New System.Drawing.Point(8, 65)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(570, 315)
    Me.DataGrdView.TabIndex = 225
    '
    'FrmGLA02D
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(586, 392)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.LblDebit)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.LblCredit)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnShowSeq)
    Me.Controls.Add(Me.TxtSeq)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGLA02D"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Batch"
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmGLA02B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myTAXBCH = New TAXBCH.MyData()
    myTAXBCH.MyDBConn = myDBConnect
    myTAXBCHL1 = New TAXBCHL1.MyData()
    myTAXBCHL1.MyDBConn = myDBConnect
    With MyFrmGLA02
      .TBarNew.Enabled = True
      .TBarNew.Text = "New"
      .TBarDelete.Enabled = False
      .TBarDelete.Text = "Delete"
      .TBarPrtEdits.Enabled = False
      .TBarPost.Enabled = False
    End With

    Me.Text = Me.Text & " " & WrkBatchNo
    Call FormatGrid()
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    FormatGrid()
  End Sub
  Public Sub FormatGrid()
    Call ShowGrid()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).Visible = False
      .Columns(1).HeaderText = "Seq #"
      .Columns(1).Width = 40
      .Columns(2).HeaderText = "Fund"
      .Columns(2).Width = 40
      .Columns(3).HeaderText = "SFund"
      .Columns(3).Width = 40
      .Columns(4).HeaderText = "Dept"
      .Columns(4).Width = 40
      .Columns(5).HeaderText = "Obj"
      .Columns(5).Width = 40
      .Columns(6).HeaderText = "Func"
      .Columns(6).Width = 40
      .Columns(7).HeaderText = "Subfn"
      .Columns(7).Width = 40
      .Columns(8).HeaderText = "Amount"
      .Columns(8).Width = 60
      .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns(9).HeaderText = "Type"
      .Columns(9).Width = 60
      .Columns(10).HeaderText = "Entry"
      .Columns(10).Width = 50
      .Columns(11).HeaderText = "Date"
      .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns(11).DefaultCellStyle.Format = "##/##/####"
      .Columns(11).Width = 65
    End With
  End Sub
  Public Sub ShowGrid()
    Dim WrkCredit As Decimal
    Dim WrkDebit As Decimal
    Dim I As Integer
    ds = myTAXBCHL1.GetViewbyBatch(WrkBatchNo, 0)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
    myTAXBCH.CloseFile()

    For I = 0 To (DataGrdView.Rows.Count - 1)
      If DataGrdView.Item(10, I).Value = "C" Then
        WrkCredit = WrkCredit + DataGrdView.Item(8, I).Value
      Else
        WrkDebit = WrkDebit + DataGrdView.Item(8, I).Value
      End If
    Next
    LblCredit.Text = Format(WrkCredit, "fixed")
    LblDebit.Text = Format(WrkDebit, "fixed")
  End Sub
  Private Sub FrmGLA02D_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGLA02.SbpScreen.Text = "GLA02D"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Dim WrkReceiptDate As Date

    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    With myBCHHDR
      WrkReceiptDate = MyUtils.GetDBDate(._PSDT)
    End With

    MyFrmGLA02E = New FrmGLA02E
    MyFrmGLA02E.MdiParent = Me.ParentForm
    MyFrmGLA02E.WrkBatchNo = WrkBatchNo
    MyFrmGLA02E.WrkTran = MyUtils.CnvSng(DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value)
    MyFrmGLA02E.WrkSeq = MyUtils.CnvSng(DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value)
    MyFrmGLA02E.Show()
    Me.Hide()
  End Sub
  Private Sub DataGrdView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGrdView.CellFormatting
    Dim Temp As String
    If (e.ColumnIndex = 9) Then
      Temp = DataGrdView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
      Select Case Temp
        Case "A"
          e.Value = "Asset"
        Case "H"
          e.Value = "Header"
        Case "L"
          e.Value = "Liability"
        Case "R"
          e.Value = "Revenue"
        Case "Q"
          e.Value = "Equity"
        Case "X"
          e.Value = "Expenditure"
        Case Else
      End Select
    End If
    If (e.ColumnIndex = 10) Then
      Temp = DataGrdView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
      Select Case Temp
        Case "C"
          e.Value = "Credit"
        Case "D"
          e.Value = "Debit"
        Case Else
      End Select
    End If
  End Sub
  Private Sub FrmGLA02D_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    With MyFrmGLA02
      .TBarNew.Text = "New"
      .TBarNew.Enabled = False
      .TBarDelete.Text = "Delete"
      .TBarDelete.Enabled = False
      .TBarPrtEdits.Enabled = False
      .TBarPost.Enabled = False
    End With
    MyFrmGLA02C.FormatGrid()
    MyFrmGLA02C.Show()

  End Sub
  Private Sub BtnShowTran_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShowSeq.Click
    If MyUtils.CnvSng(TxtSeq.Text) > 0 Then
      ShowSeq()
    End If
  End Sub
  Private Sub ShowSeq()

    If MyUtils.CnvSng(TxtSeq.Text) = 0 Then Exit Sub

    myTAXBCH.GetOneRecordP(WrkBatchNo, WrkBatchNo, MyUtils.CnvSng(TxtSeq.Text))
    If myTAXBCH.RecordNotFound Then
      MsgBox("Cannot find sequence", MsgBoxStyle.Exclamation, "Sequence number is invalid")
      Exit Sub
    End If

    '		FormatGrid()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    '		TxtSeq.Focus()
    MyFrmGLA02E = New FrmGLA02E
    With MyFrmGLA02E
      .WrkBatchNo = WrkBatchNo
      .WrkTran = WrkBatchNo
      .WrkSeq = MyUtils.CnvSng(TxtSeq.Text)
      .MdiParent = Me.ParentForm
      .Show()
    End With

    TxtSeq.Text = ""
    Windows.Forms.Cursor.Current = Cursors.Default
    Me.Hide()

  End Sub
  Private Sub TxtSeq_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSeq.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      ShowSeq()
      Exit Sub
    End If

    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

End Class
