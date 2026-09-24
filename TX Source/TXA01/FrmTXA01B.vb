Public Class FrmTXA01B
  Inherits System.Windows.Forms.Form
  Dim myBCHHDR As BCHHDR.MyData
  Dim myBCHHDRL1 As BCHHDRL1.MyData
  Dim myTCRBCH As TCRBCH.MyData
  Dim ds As DataSet = New DataSet
  Dim WrkBatchNo As Integer
  Friend WithEvents DataGrdView As DataGridView
  Dim WrkBatchType As String

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
  Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DataGrdView.Location = New System.Drawing.Point(12, 12)
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.Size = New System.Drawing.Size(334, 258)
    Me.DataGrdView.TabIndex = 435
    '
    'FrmTXA01B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(357, 282)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Name = "FrmTXA01B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Select Batch"
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmTXA01B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myBCHHDRL1 = New BCHHDRL1.MyData()
    myBCHHDRL1.MyDBConn = myDBConnect
    myTCRBCH = New TCRBCH.MyData(myDBConnect)
    Call FormatGrid()
  End Sub
  Public Sub FormatGrid()
    Dim I As Integer
    Call ShowGrid()

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).Visible = False
      .Columns(1).HeaderText = "Batch"
      .Columns(1).Width = 40
      .Columns(2).HeaderText = "Status"
      .Columns(2).Width = 70
      .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      .Columns(3).HeaderText = "Batch Type"
      .Columns(3).Width = 100
      For I = 4 To 16
        .Columns(I).Visible = False
      Next
      .Columns(17).Width = 80
      .Columns(17).HeaderText = "Post Date"
    End With

  End Sub
  Public Sub ShowGrid()
    ds = myBCHHDRL1.GetViewbyAppID(MyBatch, 999)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
  End Sub

  Private Sub FrmTXA01B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA01.SbpScreen.Text = "TXA01B"
    With MyFrmTXA01
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Dim WrkStatus As String

    WrkStatus = DataGrdView.Item(9, DataGrdView.CurrentRow.Index).Value
    If WrkStatus = "A" Then
      MsgBox("Batch is already active", MsgBoxStyle.Exclamation, "Active Batch not available")
      Exit Sub
    End If

    If WrkStatus = "P" Then
      MsgBox("Reports will show overpaid any previous posted records. Those accounts will be skipped.", MsgBoxStyle.Information, "Notice: Recovery mode reports")
      Exit Sub
    End If

    WrkBatchNo = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
    WrkBatchType = DataGrdView.Item(3, DataGrdView.CurrentRow.Index).Value

    OpenBatch()
    MyFrmTXA01.TBarNew.Enabled = False
    MyFrmTXA01.TBarDelete.Enabled = False
    MyFrmTXA01C = New FrmTXA01C
    MyFrmTXA01C.MdiParent = Me.ParentForm
    MyFrmTXA01C.WrkBatchNo = WrkBatchNo
    MyFrmTXA01C.WrkBatchType = WrkBatchType
    MyFrmTXA01C.Show()
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub DataGrdView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGrdView.CellFormatting
    Dim Temp As String
    If DataGrdView.Columns(e.ColumnIndex).Name = "stats" Then
      If e.Value = "A" Then
        DataGrdView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
      End If
      If e.Value = "P" Then
        DataGrdView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
      End If
    End If

    If (e.ColumnIndex = 2) Then
      Temp = DataGrdView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
      Select Case Temp
        Case "A"
          e.Value = "Active"
        Case "E"
          e.Value = "Edited"
        Case "I"
          e.Value = "Incomplete"
        Case "P"
          e.Value = "Posting"
        Case "S"
          e.Value = "Suspended"
        Case Else
      End Select
    End If

    If (e.ColumnIndex = 3) Then
      Temp = DataGrdView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
      Select Case Temp
        Case "B"
          e.Value = "Lock Box"
        Case "E"
          e.Value = "Escrow"
        Case "K"
          e.Value = "Bank Service"
        Case "G"
          e.Value = "Leasing"
        Case "M"
          e.Value = "Misc/Penny Batch"
        Case "W"
          e.Value = "Web Payments"
        Case Else
      End Select
    End If
  End Sub
  Private Sub OpenBatch()
    WrkBatchNo = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    With myBCHHDR
      ._STATS = "A"
      .UpdateOneRecordP()
    End With

  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer

    WrkBatchNo = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
    Cancel = False
    Answer = MsgBox("Delete batch " & WrkBatchNo & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete Batch")
    If Answer = vbNo Then
      Cancel = True
      Exit Sub
    End If

    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    If Not myBCHHDR.RecordNotFound Then
      myBCHHDR.DeleteOneRecordP()
      myTCRBCH.DeleteBatch(WrkBatchNo)
    End If
    FormatGrid()
  End Sub
  Private Sub FrmTXA01B_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    'Memory Cleanup
    myBCHHDR = Nothing
    MyFrmTXA01B = Nothing
  End Sub
End Class






