Public Class FrmListLocsec
  Inherits System.Windows.Forms.Form
  Dim myLOCSEC As LOCSEC.myData
  Dim myLOCATN As LOCATN.MyData
  Dim ds As DataSet = New DataSet
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Dim WrkSave As Boolean
  Dim WrkDelete As Boolean

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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents TxtPos As System.Windows.Forms.TextBox
  Friend WithEvents LblCurrent As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.LblCurrent = New System.Windows.Forms.Label()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 16)
    Me.Label1.TabIndex = 30
    Me.Label1.Text = "Position To"
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(208, 4)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 29
    Me.BtnFind.Text = "&Find"
    '
    'TxtPos
    '
    Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPos.Location = New System.Drawing.Point(72, 8)
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(128, 20)
    Me.TxtPos.TabIndex = 28
    '
    'LblCurrent
    '
    Me.LblCurrent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.LblCurrent.Location = New System.Drawing.Point(40, 36)
    Me.LblCurrent.Name = "LblCurrent"
    Me.LblCurrent.Size = New System.Drawing.Size(248, 16)
    Me.LblCurrent.TabIndex = 32
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
    Me.DataGrdView.Location = New System.Drawing.Point(17, 36)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(271, 278)
    Me.DataGrdView.TabIndex = 202
    '
    'FrmListLocsec
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(306, 326)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.LblCurrent)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnFind)
    Me.Controls.Add(Me.TxtPos)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmListLocsec"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Select Location"
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    FormatGrid()
  End Sub

  Public Sub FormatGrid()

    Call ShowGrid()

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).Visible = False
      .Columns(0).Width = 50
      .Columns(1).HeaderText = "Locn"
      .Columns(1).Width = 50
      .Columns(2).HeaderText = "Descr"
      .Columns(2).Width = 150
    End With

  End Sub
  Public Sub ShowGrid()
      Dim ds2 As DataSet = New DataSet
      ds.Clear()
      ds2 = myLOCSEC.GetViewbyUser(MyUserID)
      CreateDS(ds2)
      DataGrdView.DataSource = ds.Tables(0)
      DataGrdView.Refresh()
  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("User", Type.GetType("System.String"))
      .Columns.Add("Llocn", Type.GetType("System.String"))
      .Columns.Add("Descr", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
Private Sub CreateDS(ByVal ds2 As DataSet)
  Dim dr As Data.DataRow
  Dim I As Integer

  Windows.Forms.Cursor.Current = Cursors.WaitCursor()
  For I = 0 To (ds2.Tables(0).Rows.Count - 1)
    With ds2.Tables(0).Rows(I)
      dr = ds.Tables(0).NewRow
      dr("User") = ds2.Tables(0).Rows(I).Item("usrprf")
      dr("Llocn") = ds2.Tables(0).Rows(I).Item("llocn")
      myLOCATN.GetOneRecordP(ds2.Tables(0).Rows(I).Item("llocn"))
      dr("Descr") = Trim(myLOCATN._LDESC)
      ds.Tables(0).Rows.Add(dr)
    End With
  Next

  Windows.Forms.Cursor.Current = Cursors.Default

End Sub
  Private Sub FrmListLocsec_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmPO301.SbpScreen.Text = "ListLocsec"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub TxtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    If e.KeyChar = MyUtils.VbKeyEnter Then
      FormatGrid()
    End If
  End Sub
  Private Sub FrmListLocsec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myLOCSEC = New LOCSEC.MyData()
    myLOCSEC.MyDBConn = myDBConnect
    myLOCATN = New LOCATN.MyData()
    myLOCATN.MyDBConn = myDBConnect
    WrkSave = MyFrmPO301.TBarSave.Enabled
    WrkDelete = MyFrmPO301.TBarDelete.Enabled
    MyFrmPO301.TBarDelete.Enabled = False
    MyFrmPO301.TBarSave.Enabled = False
    BuildDS()
    FormatGrid()
  End Sub
Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    With MyFrmPO301E
      .TxtLlocn.Text = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
      .LblLlocndesc.Text = DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value
      .Show()
    End With
    Windows.Forms.Cursor.Current = Cursors.Default
    Me.Close()

End Sub
Private Sub FrmListLocsec_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmPO301.TBarSave.Enabled = WrkSave
  MyFrmPO301.TBarDelete.Enabled = WrkDelete
  MyFrmPO301E.Show()
End Sub
End Class
