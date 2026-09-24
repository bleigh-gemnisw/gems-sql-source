Public Class FrmAP201D

Inherits System.Windows.Forms.Form
Dim myBCHHDR As BCHHDR.myData
Dim myAPEBCHL1 As APEBCHL1.myData
Dim ds As DataSet = New DataSet
Friend WithEvents BtnFind As System.Windows.Forms.Button
Friend WithEvents TxtPos As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WrkBatchNo As Integer
Friend WrkVendNo As String
Friend WrkInvNo As String
Friend WrkRecNo As Integer

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
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAP201D))
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1DataGrdList
        '
        Me.C1DataGrdList.AllowColMove = False
        Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.C1DataGrdList.AllowUpdate = False
        Me.C1DataGrdList.AlternatingRows = True
        Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.C1DataGrdList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
        Me.C1DataGrdList.Location = New System.Drawing.Point(12, 33)
        Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
        Me.C1DataGrdList.Name = "C1DataGrdList"
        Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
        Me.C1DataGrdList.PrintInfo.MeasurementDevice = C1.Win.C1TrueDBGrid.PrintInfo.MeasurementDeviceEnum.Screen
        Me.C1DataGrdList.PrintInfo.MeasurementPrinterName = Nothing
        Me.C1DataGrdList.RowHeight = 16
        Me.C1DataGrdList.Size = New System.Drawing.Size(420, 404)
        Me.C1DataGrdList.TabIndex = 8
        Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
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
        Me.BtnFind.Location = New System.Drawing.Point(172, 3)
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
        Me.TxtPos.Size = New System.Drawing.Size(85, 20)
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
        'FrmAP201D
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(445, 449)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnFind)
        Me.Controls.Add(Me.TxtPos)
        Me.Controls.Add(Me.C1DataGrdList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAP201D"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Batch"
        CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

 Private Sub FrmAP201B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
   Dim WrkNextBatch As Integer
   myBCHHDR = New BCHHDR.MyData()
   myBCHHDR.MyDBConn = myDBConnect
   myAPEBCHL1 = New APEBCHL1.MyData()
   myAPEBCHL1.MyDBConn = myDBConnect
   With MyFrmAP201
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

  myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
  MyPostDate = MyUtils.GetDBDate(myBCHHDR._PSDT)
  With MyFrmAP201
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
  With C1DataGrdList
    .Rebind(True)
    .Splits(0).DisplayColumns(0).Visible = False
    .Columns(1).Caption = "Invoice Number"
    .Splits(0).DisplayColumns(1).Width = 100
    .Splits(0).DisplayColumns(2).Visible = False
    .Columns(3).Caption = "Vendor Name"
    .Splits(0).DisplayColumns(3).Width = 200
    .Splits(0).DisplayColumns(4).Visible = False
    .Columns(5).Caption = "Amount"
    .Splits(0).DisplayColumns(5).Width = 75
    .Splits(0).DisplayColumns(6).Visible = False
   End With
End Sub
Public Sub ShowGrid()
  ds = myAPEBCHL1.GetViewbyInvno(WrkBatchNo, TxtPos.Text, "", 0)
  C1DataGrdList.DataSource = ds.Tables(0)
  C1DataGrdList.Refresh()
End Sub
Private Sub FrmAP201D_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmAP201.SbpScreen.Text = "AP201D"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
  Private Sub C1DataGrdList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    Dim WrkReceiptDate As Date

    If C1DataGrdList.VisibleRows = 0 Then
      Exit Sub
    End If

    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    With myBCHHDR
      WrkReceiptDate = MyUtils.GetDBDate(._PSDT)
    End With

    MyFrmAP201E = New FrmAP201E
    MyFrmAP201E.MdiParent = Me.ParentForm
    MyFrmAP201E.WrkBatchNo = WrkBatchNo
    MyFrmAP201E.WrkSeqno = MyUtils.CnvSng(C1DataGrdList.Item(C1DataGrdList.Row, 0))
    MyFrmAP201E.Show()
    Me.Hide()
  End Sub
  Private Sub FrmAP201D_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    Dim WrkRecs As Integer
    WrkRecs = C1DataGrdList.RowCount
    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    With myBCHHDR
      ._STATS = "S"
      If WrkRecs <> ._NBRRC Then
        ._LSTUS = MyUserID
        ._NBRRC = WrkRecs
      End If
      .UpdateOneRecordP()
    End With
   With MyFrmAP201
     .TBarNew.Text = "New Batch"
     .TBarNew.Enabled = True
     .TBarDelete.Text = "Delete"
     .TBarDelete.Enabled = True
     .TBarPrtEdits.Enabled = True
     .TBarPost.Enabled = True
   End With
   MyFrmAP201B.FormatGrid()
   MyFrmAP201B.Show()

  End Sub

 Private Sub BtnFind_Click(sender As Object, e As EventArgs) Handles BtnFind.Click
    FormatGrid()
End Sub
 End Class
