Public Class FrmTXA01C

  Inherits System.Windows.Forms.Form
  Dim myBCHHDR As BCHHDR.MyData
  Dim myBCHHDRL1 As BCHHDRL1.MyData
  Dim myTCRBCH As TCRBCH.MyData
  Dim myTCRBCHL1 As TCRBCHL1.MyData
  Dim ds As DataSet = New DataSet
  Friend WithEvents BtnShowTran As System.Windows.Forms.Button
  Friend WithEvents TxtTran As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WrkBatchNo As Integer
  Friend WithEvents DataGrdView As DataGridView
  Friend WithEvents BtnFind As Button
  Friend WrkBatchType As String

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
  Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  Friend WithEvents TxtType As System.Windows.Forms.TextBox
  Friend WithEvents TxtList As System.Windows.Forms.TextBox
  Friend WithEvents BtnShowFast As System.Windows.Forms.Button
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTXA01C))
    Me.groupBox2 = New System.Windows.Forms.GroupBox()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.BtnShowFast = New System.Windows.Forms.Button()
    Me.label2 = New System.Windows.Forms.Label()
    Me.TxtList = New System.Windows.Forms.TextBox()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.BtnShowTran = New System.Windows.Forms.Button()
    Me.TxtTran = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.groupBox2.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'groupBox2
    '
    Me.groupBox2.Controls.Add(Me.TxtType)
    Me.groupBox2.Controls.Add(Me.TxtYear)
    Me.groupBox2.Controls.Add(Me.BtnShowFast)
    Me.groupBox2.Controls.Add(Me.label2)
    Me.groupBox2.Controls.Add(Me.TxtList)
    Me.groupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.groupBox2.Location = New System.Drawing.Point(434, 4)
    Me.groupBox2.Name = "groupBox2"
    Me.groupBox2.Size = New System.Drawing.Size(302, 52)
    Me.groupBox2.TabIndex = 2
    Me.groupBox2.TabStop = False
    Me.groupBox2.Text = "Fast Path"
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtType.Location = New System.Drawing.Point(164, 24)
    Me.TxtType.MaxLength = 1
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(22, 20)
    Me.TxtType.TabIndex = 1
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(192, 24)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(28, 20)
    Me.TxtYear.TabIndex = 2
    '
    'BtnShowFast
    '
    Me.BtnShowFast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnShowFast.Location = New System.Drawing.Point(226, 23)
    Me.BtnShowFast.Name = "BtnShowFast"
    Me.BtnShowFast.Size = New System.Drawing.Size(56, 24)
    Me.BtnShowFast.TabIndex = 7
    Me.BtnShowFast.TabStop = False
    Me.BtnShowFast.Text = "&Show"
    '
    'label2
    '
    Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label2.Location = New System.Drawing.Point(4, 28)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(92, 16)
    Me.label2.TabIndex = 6
    Me.label2.Text = "List #/Type/Year"
    '
    'TxtList
    '
    Me.TxtList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtList.Location = New System.Drawing.Point(102, 24)
    Me.TxtList.MaxLength = 12
    Me.TxtList.Name = "TxtList"
    Me.TxtList.Size = New System.Drawing.Size(56, 20)
    Me.TxtList.TabIndex = 0
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    '
    'BtnShowTran
    '
    Me.BtnShowTran.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnShowTran.Location = New System.Drawing.Point(108, 22)
    Me.BtnShowTran.Name = "BtnShowTran"
    Me.BtnShowTran.Size = New System.Drawing.Size(56, 24)
    Me.BtnShowTran.TabIndex = 1
    Me.BtnShowTran.TabStop = False
    Me.BtnShowTran.Text = "&Show"
    '
    'TxtTran
    '
    Me.TxtTran.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTran.Location = New System.Drawing.Point(60, 25)
    Me.TxtTran.MaxLength = 11
    Me.TxtTran.Name = "TxtTran"
    Me.TxtTran.Size = New System.Drawing.Size(42, 20)
    Me.TxtTran.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(12, 28)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(42, 18)
    Me.Label1.TabIndex = 11
    Me.Label1.Text = "Tran #"
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DataGrdView.Location = New System.Drawing.Point(15, 62)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(721, 318)
    Me.DataGrdView.TabIndex = 434
    '
    'BtnFind
    '
    Me.BtnFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFind.Location = New System.Drawing.Point(166, 22)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(70, 24)
    Me.BtnFind.TabIndex = 435
    Me.BtnFind.TabStop = False
    Me.BtnFind.Text = "Find"
    '
    'FrmTXA01C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(748, 392)
    Me.Controls.Add(Me.BtnFind)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnShowTran)
    Me.Controls.Add(Me.TxtTran)
    Me.Controls.Add(Me.groupBox2)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXA01C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Batch"
    Me.groupBox2.ResumeLayout(False)
    Me.groupBox2.PerformLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTXA01B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkBatchTypeDesc As String

    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myBCHHDRL1 = New BCHHDRL1.MyData()
    myBCHHDRL1.MyDBConn = myDBConnect
    myTCRBCH = New TCRBCH.MyData(myDBConnect)
    myTCRBCHL1 = New TCRBCHL1.MyData(myDBConnect)
    With MyFrmTXA01
      .TBarNew.Enabled = True
      .TBarNew.Text = "New"
      .TBarDelete.Enabled = False
      .TBarDelete.Text = "Delete"
      .TBarPrtEdits.Enabled = False
      .TBarPost.Enabled = False
    End With

    Call FormatGrid()
    WrkBatchTypeDesc = GetBatchTypeDesc(WrkBatchType)
    Me.Text = Me.Text & " " & WrkBatchNo & "   Type: " & WrkBatchTypeDesc
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    FormatGrid()
  End Sub
  Public Sub FormatGrid()
    Call ShowGrid()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "Seq #"
      .Columns(0).Width = 40
      .Columns(1).HeaderText = "List#"
      .Columns(1).Width = 50
      .Columns(2).HeaderText = "Type"
      .Columns(2).Width = 40
      .Columns(3).HeaderText = "Year"
      .Columns(3).Width = 40
      .Columns(4).HeaderText = "Name"
      .Columns(4).Width = 200
      .Columns(5).HeaderText = "Principal"
      .Columns(5).Width = 70
      .Columns(6).HeaderText = "Interest"
      .Columns(6).Width = 70
      .Columns(7).HeaderText = "Liens"
      .Columns(7).Width = 50
      .Columns(8).HeaderText = "Fees"
      .Columns(8).Width = 50
      .Columns(9).HeaderText = "Adj"
      .Columns(9).Width = 50
    End With
  End Sub
  Public Sub ShowGrid()
    Dim WrkTrnbr As Integer
    WrkTrnbr = MyUtils.CnvSng(TxtTran.Text)
    ds = myTCRBCHL1.GetViewbyBatch(WrkBatchNo, WrkTrnbr, 9999)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
    myTCRBCH.CloseFile()
  End Sub
  Private Sub FrmTXA01C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA01.SbpScreen.Text = "TXA01C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Dim WrkReceiptDate As Date

    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    With myBCHHDR
      WrkReceiptDate = MyUtils.GetDBDate(._PSDT)
    End With

    MyFrmTXA01D = New FrmTXA01D
    MyFrmTXA01D.MdiParent = Me.ParentForm
    MyFrmTXA01D.WrkBatchNo = WrkBatchNo
    MyFrmTXA01D.WrkSeq = MyUtils.CnvSng(DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value)
    MyFrmTXA01D.WrkReceiptDate = WrkReceiptDate
    MyFrmTXA01D.Show()
    Me.Hide()
  End Sub
  Private Sub DataGrdView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGrdView.CellFormatting
    Dim Temp As String
    If (e.ColumnIndex = 9) Then
      Temp = DataGrdView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
      Select Case Temp
        Case "A"
          e.Value = "Adjust"
        Case "R"
          e.Value = "Refund"
        Case Else
      End Select
    End If
  End Sub
  Private Sub FrmTXA01C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    With myBCHHDR
      ._STATS = "S"
      .UpdateOneRecordP()
    End With
    With MyFrmTXA01
      .TBarNew.Text = "New Batch"
      .TBarNew.Enabled = True
      .TBarDelete.Text = "Delete Batch"
      .TBarDelete.Enabled = True
      .TBarPrtEdits.Enabled = True
      .TBarPost.Enabled = True
    End With
    MyFrmTXA01B.Show()

  End Sub
  Private Sub BtnShowTran_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShowTran.Click
    ShowTran()
  End Sub
  Private Sub ShowTran()

    If MyUtils.CnvSng(TxtTran.Text) = 0 Then Exit Sub

    myTCRBCH.GetOneRecordP(WrkBatchNo, MyUtils.CnvSng(TxtTran.Text))
    If myTCRBCH.RecordNotFound Then
      MsgBox("Cannot find transaction", MsgBoxStyle.Exclamation, "Transaction number is invalid")
      Exit Sub
    End If

    FormatGrid()

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    TxtTran.Focus()
    MyFrmTXA01D = New FrmTXA01D

    With MyFrmTXA01D
      .WrkBatchNo = WrkBatchNo
      .WrkSeq = MyUtils.CnvSng(TxtTran.Text)
      .MdiParent = Me.ParentForm
      .Show()
    End With

    TxtTran.Text = ""
    Windows.Forms.Cursor.Current = Cursors.Default
    Me.Hide()

  End Sub
  Private Sub BtnShowFast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShowFast.Click
    ShowFastPath()
  End Sub
  Private Sub ShowFastPath()
    Dim ds2 As DataSet = New DataSet

    If MyUtils.CnvSng(TxtList.Text) = 0 Then Exit Sub
    If TxtType.Text = "" Then Exit Sub
    If MyUtils.CnvSng(TxtYear.Text) = 0 Then Exit Sub

    ds2 = myTCRBCHL1.GetViewbyList(WrkBatchNo, MyUtils.CnvSng(TxtList.Text),
      MyUtils.CnvSng(TxtYear.Text), TxtType.Text, 1)
    If ds2.Tables(0).Rows.Count = 0 Then
      MsgBox("List/Year/Type not found in Batch", MsgBoxStyle.Exclamation, "Fast Path information is not valid")
      Exit Sub
    End If

    FormatGrid()

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    TxtList.Focus()
    MyFrmTXA01D = New FrmTXA01D

    With MyFrmTXA01D
      .WrkBatchNo = WrkBatchNo
      .WrkSeq = ds2.Tables(0).Rows(0).Item("trnbr")
      .MdiParent = Me.ParentForm
      .Show()
    End With

    TxtList.Text = ""
    TxtType.Text = ""
    TxtYear.Text = ""
    Windows.Forms.Cursor.Current = Cursors.Default
    Me.Hide()

  End Sub

  Private Sub TxtType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtType.KeyPress
    'Move to next field after anything has been typed since it's only 1 char allowed
    Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
  End Sub
  Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      ShowFastPath()
      Exit Sub
    End If

    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtList.KeyPress
    Dim WrkBarCode As String

    If Asc(e.KeyChar) = Keys.Return Then
      WrkBarCode = TxtList.Text
      'Check for Bar code entry
      If Len(WrkBarCode) > 6 Then
        TxtList.Text = Mid(WrkBarCode, 1, 7)
        TxtType.Text = Mid(WrkBarCode, 7, 1)
        TxtYear.Text = Mid(WrkBarCode, 8, 4)
        ShowFastPath()
      Else 'Bar Code
        MyUtils.KeyEnter_isTab(Me, e)
      End If
    End If

    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)

  End Sub
  Private Sub TxtTran_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTran.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      ShowTran()
      Exit Sub
    End If

    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
End Class






