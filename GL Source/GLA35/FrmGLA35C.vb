Public Class FrmGLA35C

    Inherits System.Windows.Forms.Form
    Dim myBCHHDR As BCHHDR.myData
    Dim myMSCBCHL1 As MSCBCHL1.MyData
    Dim ds As DataSet = New DataSet
  Friend WithEvents DataGrdView As DataGridView
  Friend WrkBatchNo As Integer

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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGLA35C))
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
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
    Me.DataGrdView.Location = New System.Drawing.Point(12, 12)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(368, 326)
    Me.DataGrdView.TabIndex = 352
    '
    'FrmGLA35C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(392, 350)
    Me.Controls.Add(Me.DataGrdView)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGLA35C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Batch"
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmGLA35B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myMSCBCHL1 = New MSCBCHL1.MyData()
    myMSCBCHL1.MyDBConn = myDBConnect
    With MyFrmGLA35
      .TBarCreate.Enabled = False
      .TBarNew.Enabled = False
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
      .Columns(1).HeaderText = "Tran #"
      .Columns(1).Width = 40
      .Columns(2).HeaderText = "Description"
      .Columns(2).Width = 150
      .Columns(3).HeaderText = "Total Debit"
      .Columns(3).Width = 70
      .Columns(4).HeaderText = "Total Credit"
      .Columns(4).Width = 70
      .Columns(5).Visible = False
    End With
  End Sub
  Public Sub ShowGrid()
    ds = myMSCBCHL1.GetViewbyBatchTot(WrkBatchNo, 9999)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
    myMSCBCHL1.CloseFile()
  End Sub
  Private Sub FrmGLA35C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGLA35.SbpScreen.Text = "GLA35C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Dim WrkReceiptDate As Date

    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    With myBCHHDR
      WrkReceiptDate = MyUtils.GetDBDate(._PSDT)
    End With

    MyFrmGLA35D = New FrmGLA35D
    MyFrmGLA35D.MdiParent = Me.ParentForm
    MyFrmGLA35D.WrkBatchNo = WrkBatchNo
    MyFrmGLA35D.WrkTran = MyUtils.CnvSng(DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value)
    MyFrmGLA35D.Show()
    Me.Hide()
  End Sub
  Private Sub FrmGLA35C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    With myBCHHDR
      ._STATS = "S"
      .UpdateOneRecordP()
    End With
    With MyFrmGLA35
      .TBarCreate.Enabled = True
      .TBarNew.Enabled = False
      .TBarDelete.Text = "Delete Batch"
      .TBarDelete.Enabled = True
      .TBarPrtEdits.Enabled = True
      .TBarPost.Enabled = True
    End With
    MyFrmGLA35B.FormatGrid()
    MyFrmGLA35B.Show()

  End Sub
End Class
