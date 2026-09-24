Public Class FrmPO201D

Inherits System.Windows.Forms.Form
Dim myBCHHDR As BCHHDR.myData
Dim myRQEBCHL1 As RQEBCHL1.myData
Dim myPURCTLL1 As PURCTLL1.MyData
Dim ds As DataSet = New DataSet
Friend WithEvents BtnFind As System.Windows.Forms.Button
Friend WithEvents TxtPos As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WrkLlocn As String
Friend WithEvents LblLlocn As System.Windows.Forms.Label
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents LblFiscHdr As System.Windows.Forms.Label
Friend WithEvents LblFiscyr As System.Windows.Forms.Label
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPO201D))
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.LblLlocn = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.LblFiscHdr = New System.Windows.Forms.Label()
    Me.LblFiscyr = New System.Windows.Forms.Label()
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
    'BtnFind
    '
    Me.BtnFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFind.Location = New System.Drawing.Point(146, 3)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(56, 24)
    Me.BtnFind.TabIndex = 1
    Me.BtnFind.TabStop = False
    Me.BtnFind.Text = "&Find"
    '
    'TxtPos
    '
    Me.TxtPos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPos.Location = New System.Drawing.Point(81, 6)
    Me.TxtPos.MaxLength = 25
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(59, 20)
    Me.TxtPos.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(12, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(63, 18)
    Me.Label1.TabIndex = 11
    Me.Label1.Text = "Position to"
    '
    'LblLlocn
    '
    Me.LblLlocn.AutoSize = True
    Me.LblLlocn.BackColor = System.Drawing.SystemColors.Control
    Me.LblLlocn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLlocn.Location = New System.Drawing.Point(286, 9)
    Me.LblLlocn.Name = "LblLlocn"
    Me.LblLlocn.Size = New System.Drawing.Size(45, 13)
    Me.LblLlocn.TabIndex = 453
    Me.LblLlocn.Text = "<Llocn>"
    Me.LblLlocn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(234, 9)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(48, 13)
    Me.Label5.TabIndex = 452
    Me.Label5.Text = "Location"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblFiscHdr
    '
    Me.LblFiscHdr.AutoSize = True
    Me.LblFiscHdr.Location = New System.Drawing.Point(337, 9)
    Me.LblFiscHdr.Name = "LblFiscHdr"
    Me.LblFiscHdr.Size = New System.Drawing.Size(47, 13)
    Me.LblFiscHdr.TabIndex = 454
    Me.LblFiscHdr.Text = "Fiscal Yr"
    Me.LblFiscHdr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblFiscyr
    '
    Me.LblFiscyr.AutoSize = True
    Me.LblFiscyr.BackColor = System.Drawing.SystemColors.Control
    Me.LblFiscyr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFiscyr.Location = New System.Drawing.Point(387, 9)
    Me.LblFiscyr.Name = "LblFiscyr"
    Me.LblFiscyr.Size = New System.Drawing.Size(46, 13)
    Me.LblFiscyr.TabIndex = 455
    Me.LblFiscyr.Text = "<Fiscyr>"
    Me.LblFiscyr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
    Me.DataGrdView.Location = New System.Drawing.Point(12, 33)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(421, 347)
    Me.DataGrdView.TabIndex = 463
    '
    'FrmPO201D
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(445, 392)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.LblFiscyr)
    Me.Controls.Add(Me.LblFiscHdr)
    Me.Controls.Add(Me.LblLlocn)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnFind)
    Me.Controls.Add(Me.TxtPos)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmPO201D"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Batch"
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmPO201B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkNextBatch As Integer
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myRQEBCHL1 = New RQEBCHL1.MyData()
    myRQEBCHL1.MyDBConn = myDBConnect
    myPURCTLL1 = New PURCTLL1.MyData()
    myPURCTLL1.MyDBConn = myDBConnect
    With MyFrmPO201
      .TBarNew.Enabled = True
      .TBarNew.Text = "New"
      .TBarDelete.Enabled = False
      .TBarDelete.Text = "Delete"
      .TBarPrtEdits.Enabled = False
      .TBarPost.Enabled = False
    End With

    myBCHHDR.GetOneRecordP(MyBatch, 0)
    If WrkBatchNo = 0 Then
      If myBCHHDR.RecordNotFound Then
        With myBCHHDR
          ._APPID = MyBatch
          ._BCHNO = 0
          .AddOneRecordP()
        End With
      End If

      WrkNextBatch = myBCHHDR.AutoGenKey(MyBatch)
      myBCHHDR.GetOneRecordP(MyBatch, WrkNextBatch)
      If myBCHHDR.RecordNotFound Then
        With myBCHHDR
          ._APPID = MyBatch
          ._BCHNO = WrkNextBatch
          ._ORGUS = "GEMSNET"
          ._STATS = "S"
          ._SUBST = ""
          ._LSBCH = 0
          ._ENTPM = WrkLlocn
          ._PSDT = MyUtils.SetDBDate(MyPostDate)
          .AddOneRecordP()
        End With

        myBCHHDR.GetOneRecordP(MyBatch, 0)
        If Not myBCHHDR.RecordNotFound Then
          With myBCHHDR
            ._LSBCH = WrkNextBatch
            .UpdateOneRecordP()
          End With
        End If
      End If
      WrkBatchNo = WrkNextBatch
    End If

    MyFiscyr = myPURCTLL1.GetFscyr(MyUtils.SetDBDate(MyPostDate))
    LblFiscyr.Text = MyFiscyr
    LblLlocn.Text = WrkLlocn
    If MyFiscyr = 0 Then
      LblFiscHdr.ForeColor = Color.Red
      LblFiscyr.ForeColor = Color.Red
    End If

    With MyFrmPO201
      .TBarNew.Enabled = True
      .TBarNew.Text = "New"
      .TBarDelete.Enabled = False
      .TBarDelete.Text = "Delete"
      .TBarPrtEdits.Enabled = False
      .TBarPost.Enabled = False
    End With

    Me.Text = Me.Text & " " & WrkBatchNo & " " & MyPostDate
    Call FormatGrid()
  End Sub
  Public Sub FormatGrid()
    Call ShowGrid()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "Req No"
      .Columns(0).Width = 50
      .Columns(1).HeaderText = "Vendor Name"
      .Columns(1).Width = 200
      .Columns(2).HeaderText = "Amount"
      .Columns(2).Width = 75
    End With
  End Sub
  Public Sub ShowGrid()
    ds = myRQEBCHL1.GetViewbyBatch(WrkLlocn, WrkBatchNo, 0)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
  End Sub
  Private Sub FrmPO201D_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmPO201.SbpScreen.Text = "PO201D"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Dim WrkReceiptDate As Date

    If DataGrdView.RowCount = 0 Then Exit Sub
    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    With myBCHHDR
      WrkReceiptDate = MyUtils.GetDBDate(._PSDT)
    End With

    MyFrmPO201E = New FrmPO201E
    MyFrmPO201E.MdiParent = Me.ParentForm
    MyFrmPO201E.WrkLlocn = WrkLlocn
    MyFrmPO201E.WrkBatchNo = WrkBatchNo
    MyFrmPO201E.WrkRqnbr = Trim(DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value)
    MyFrmPO201E.Show()
    Me.Hide()
  End Sub
  Private Sub FrmPO201D_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    Dim WrkRecs As Integer
    WrkRecs = DataGrdView.RowCount
    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    With myBCHHDR
      ._STATS = "S"
      If WrkRecs <> ._NBRRC Then
        ._LSTUS = MyUserID
        ._NBRRC = WrkRecs
      End If
      .UpdateOneRecordP()
    End With
    With MyFrmPO201
      .TBarNew.Text = "New Batch"
      .TBarNew.Enabled = True
      .TBarDelete.Text = "Delete"
      .TBarDelete.Enabled = True
      .TBarPrtEdits.Enabled = True
      .TBarPost.Enabled = False
    End With
    MyFrmPO201B.FormatGrid()
    MyFrmPO201B.Show()

  End Sub

  Private Sub BtnFind_Click(sender As Object, e As EventArgs) Handles BtnFind.Click
    FormatGrid()
  End Sub

  Private Sub DataGrdView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrdView.CellContentClick

  End Sub
End Class
