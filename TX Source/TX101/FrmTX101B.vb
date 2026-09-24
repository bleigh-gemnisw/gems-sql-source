Public Class FrmTX101B
  Inherits System.Windows.Forms.Form
  Dim myTXPROF As TXPROF.MyData
  Dim ds As DataSet = New DataSet
  Dim Wrkprtype As String
  Dim Wrkpryear As Integer
  Dim Wrkphs As String
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Dim Wrkdist As Single

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
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtPosType As System.Windows.Forms.TextBox
  Friend WithEvents TxtPosYear As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.TxtPosType = New System.Windows.Forms.TextBox()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtPosYear = New System.Windows.Forms.TextBox()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TxtPosType
    '
    Me.TxtPosType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPosType.Location = New System.Drawing.Point(80, 8)
    Me.TxtPosType.MaxLength = 1
    Me.TxtPosType.Name = "TxtPosType"
    Me.TxtPosType.Size = New System.Drawing.Size(16, 20)
    Me.TxtPosType.TabIndex = 0
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(152, 8)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 2
    Me.BtnFind.Text = "&Find"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(16, 8)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 16)
    Me.Label1.TabIndex = 14
    Me.Label1.Text = "Position To"
    '
    'TxtPosYear
    '
    Me.TxtPosYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPosYear.Location = New System.Drawing.Point(96, 8)
    Me.TxtPosYear.MaxLength = 4
    Me.TxtPosYear.Name = "TxtPosYear"
    Me.TxtPosYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtPosYear.TabIndex = 1
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
    Me.DataGrdView.Location = New System.Drawing.Point(12, 38)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(216, 350)
    Me.DataGrdView.TabIndex = 37
    '
    'FrmTX101B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(240, 400)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.TxtPosYear)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtPosType)
    Me.Controls.Add(Me.BtnFind)
    Me.Name = "FrmTX101B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTX101B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXPROF = New TXPROF.MyData(myDBConnect)
    Wrkprtype = String.Empty
    Call FormatGrid()
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    Wrkprtype = TxtPosType.Text
    Wrkpryear = MyUtils.CnvSng(TxtPosYear.Text)
    FormatGrid()
  End Sub
  Public Sub FormatGrid()
    Call ShowGrid()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "Type"
      .Columns(0).Width = 45
      .Columns(1).HeaderText = "Year"
      .Columns(1).Width = 35
      .Columns(2).Visible = False
      .Columns(3).Visible = False
      .Columns(4).Visible = False
      .Columns(5).Visible = False
      .Columns(6).Visible = False
      .Columns(7).Visible = False
      .Columns(8).Visible = False
      .Columns(9).Visible = False
      .Columns(10).Visible = False
      .Columns(11).Visible = False
      .Columns(12).Visible = False
      .Columns(13).Visible = False
      .Columns(14).Visible = False
      .Columns(15).Visible = False
      .Columns(16).Visible = False
      .Columns(17).Visible = False
      .Columns(18).Visible = False
      .Columns(19).HeaderText = "Phase"
      .Columns(19).Width = 40
      .Columns(20).HeaderText = "District"
      .Columns(20).Width = 50
    End With
  End Sub
  Public Sub ShowGrid()
    ds.Clear()
    ds = Nothing
    ds = myTXPROF.PosData(TxtPosType.Text, MyUtils.CnvSng(TxtPosYear.Text), String.Empty, 0)

    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
  End Sub
  Private Sub FrmTX101B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTX101.SbpScreen.Text = "TX101B"
    MyFrmTX101.TBarPrint.Enabled = True
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    MyFrmTX101C = New FrmTX101C
    MyFrmTX101C.MdiParent = Me.ParentForm
    MyFrmTX101C.Wrkprtype = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    MyFrmTX101C.Wrkpryear = MyUtils.CnvSng(DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value)
    MyFrmTX101C.Wrkphs = DataGrdView.Item(19, DataGrdView.CurrentRow.Index).Value
    MyFrmTX101C.Wrkdist = MyUtils.CnvSng(DataGrdView.Item(20, DataGrdView.CurrentRow.Index).Value)
    MyFrmTX101C.WrkCopyMode = False
    MyFrmTX101C.Show()
    Me.Hide()
  End Sub
  Public Sub CopyData()
    Dim myTXPROF As TXPROF.MyData
    Dim WrkPrtype1 As String
    Dim WrkPryear1 As Integer
    Dim WrkPhs1 As String
    Dim WrkDist1 As Integer

    myTXPROF = New TXPROF.MyData(myDBConnect)
    WrkPrtype1 = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    WrkPryear1 = MyUtils.CnvSng(DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value) + 1
    WrkPhs1 = DataGrdView.Item(19, DataGrdView.CurrentRow.Index).Value
    WrkDist1 = MyUtils.CnvSng(DataGrdView.Item(20, DataGrdView.CurrentRow.Index).Value)

    myTXPROF.GetOneRecordP(WrkPrtype1, WrkPryear1, WrkPhs1, WrkDist1)
    If Not myTXPROF.RecordNotFound Then
      MsgBox("Next year's data already exists", MsgBoxStyle.Exclamation, "Copy cancelled")
      myTXPROF.CloseFile()
      myTXPROF = Nothing
      Exit Sub
    End If

    myTXPROF.CloseFile()
    myTXPROF = Nothing

    MyFrmTX101C = New FrmTX101C
    MyFrmTX101C.MdiParent = Me.ParentForm
    MyFrmTX101C.Wrkprtype = WrkPrtype1
    MyFrmTX101C.Wrkpryear = WrkPryear1
    MyFrmTX101C.Wrkphs = WrkPhs1
    MyFrmTX101C.Wrkdist = WrkDist1
    MyFrmTX101C.WrkCopyMode = True
    MyFrmTX101C.Show()
    Me.Hide()
  End Sub
  Public Sub PrintData()
    MyCRViewer = New FrmCrViewer
    MyCRViewer.Wrkds = ds.Copy
    MyCRViewer.Show()
  End Sub
End Class






