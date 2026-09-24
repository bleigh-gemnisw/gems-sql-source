Public Class FrmGLA32B
  Inherits System.Windows.Forms.Form
  Dim myTXGLAD As TXGLAD.MyData
  Friend WithEvents DataGrdView As DataGridView
  Dim ds As DataSet = New DataSet

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
    Me.TxtPosType.Location = New System.Drawing.Point(124, 8)
    Me.TxtPosType.MaxLength = 1
    Me.TxtPosType.Name = "TxtPosType"
    Me.TxtPosType.Size = New System.Drawing.Size(16, 20)
    Me.TxtPosType.TabIndex = 1
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
    Me.TxtPosYear.Location = New System.Drawing.Point(86, 8)
    Me.TxtPosYear.MaxLength = 4
    Me.TxtPosYear.Name = "TxtPosYear"
    Me.TxtPosYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtPosYear.TabIndex = 0
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
    Me.DataGrdView.Location = New System.Drawing.Point(12, 48)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(251, 340)
    Me.DataGrdView.TabIndex = 207
    '
    'FrmGLA32B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(275, 400)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.TxtPosYear)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtPosType)
    Me.Controls.Add(Me.BtnFind)
    Me.Name = "FrmGLA32B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmGLA32B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXGLAD = New TXGLAD.MyData(myDBConnect)
    Call FormatGrid()
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    FormatGrid()
    TxtPosYear.Text = String.Empty
    TxtPosType.Text = String.Empty
  End Sub
  Public Sub FormatGrid()
    Call ShowGrid()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "Year"
      .Columns(0).Width = 40
      .Columns(1).HeaderText = "Type"
      .Columns(1).Width = 30
      .Columns(2).HeaderText = "Code"
      .Columns(2).Width = 40
      .Columns(3).HeaderText = "AdYear"
      .Columns(3).Width = 45
      .Columns(4).HeaderText = "AdCode"
      .Columns(4).Width = 50
    End With
  End Sub
  Public Sub ShowGrid()
    ds.Clear()
    ds = Nothing
    ds = myTXGLAD.PosData(MyUtils.CnvSng(TxtPosYear.Text), TxtPosType.Text, String.Empty)

    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
  End Sub
  Private Sub FrmGLA32B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGLA32.SbpScreen.Text = "GLA32B"
    MyFrmGLA32.TBarPrint.Enabled = True
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    MyFrmGLA32C = New FrmGLA32C
    MyFrmGLA32C.MdiParent = Me.ParentForm
    MyFrmGLA32C.WrkYear = MyUtils.CnvSng(DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value)
    MyFrmGLA32C.WrkType = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
    MyFrmGLA32C.WrkCode = DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value
    MyFrmGLA32C.WrkCopyMode = False
    MyFrmGLA32C.Show()
    Me.Hide()
  End Sub
  Public Sub CopyData()
    Dim myTXGLAD As TXGLAD.myData
    Dim WrkYear1 As Integer
    Dim WrkType1 As String
    Dim WrkCode1 As String

    myTXGLAD = New TXGLAD.MyData(myDBConnect)
    WrkYear1 = MyUtils.CnvSng(DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value) + 1
    WrkType1 = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
    WrkCode1 = DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value

    myTXGLAD.GetOneRecordP(WrkYear1, WrkType1, WrkCode1)
    If Not myTXGLAD.RecordNotFound Then
      MsgBox("Next year's data already exists", MsgBoxStyle.Exclamation, "Copy cancelled")
      myTXGLAD.CloseFile()
      myTXGLAD = Nothing
      Exit Sub
    End If

    myTXGLAD.CloseFile()
    myTXGLAD = Nothing

    MyFrmGLA32C = New FrmGLA32C
    MyFrmGLA32C.MdiParent = Me.ParentForm
    MyFrmGLA32C.WrkYear = WrkYear1
    MyFrmGLA32C.WrkType = WrkType1
    MyFrmGLA32C.WrkCode = WrkCode1
    MyFrmGLA32C.WrkCopyMode = True
    MyFrmGLA32C.Show()
    Me.Hide()
  End Sub
  Public Sub PrintData()
    Dim ds2 As DataSet = New DataSet
    Dim dr As DataRow
    Dim I As Integer

    BuildDs2(ds2)
    For I = 0 To ds.Tables(0).Rows.Count - 1
      dr = ds2.Tables(0).NewRow
      With ds.Tables(0).Rows(I)
        dr.Item("txyr") = .Item("txyr")
        dr.Item("txtyp") = .Item("txtyp")
        dr.Item("txcd") = .Item("txcd")
        dr.Item("adyr") = .Item("adyr")
        dr.Item("adcd") = .Item("adcd")
      End With
      ds2.Tables(0).Rows.Add(dr)
    Next

    MyCRViewer = New FrmCrViewer
    MyCRViewer.Wrkds = ds2
    MyCRViewer.Show()
  End Sub
  Public Sub BuildDs2(ByRef Ds2 As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Txyr", Type.GetType("System.Int32"))
      .Columns.Add("Txtyp", Type.GetType("System.String"))
      .Columns.Add("Txcd", Type.GetType("System.String"))
      .Columns.Add("Adyr", Type.GetType("System.Int32"))
      .Columns.Add("Adcd", Type.GetType("System.String"))
    End With
    Ds2.Tables.Add(myTable)
  End Sub

End Class
