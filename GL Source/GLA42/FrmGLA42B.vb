Public Class FrmGLA42B
  Inherits System.Windows.Forms.Form
  Dim myTXGLDA As TXGLDA.myData
  Friend WithEvents TxtPos2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtPosYear As System.Windows.Forms.TextBox
  Friend WithEvents RbRevenue As System.Windows.Forms.RadioButton
  Friend WithEvents RbAr As System.Windows.Forms.RadioButton
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
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
Friend WithEvents TxtPos As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.TxtPos2 = New System.Windows.Forms.TextBox()
    Me.TxtPosYear = New System.Windows.Forms.TextBox()
    Me.RbRevenue = New System.Windows.Forms.RadioButton()
    Me.RbAr = New System.Windows.Forms.RadioButton()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(209, 2)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 3
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
    'TxtPos
    '
    Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPos.Location = New System.Drawing.Point(115, 5)
    Me.TxtPos.MaxLength = 3
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(32, 20)
    Me.TxtPos.TabIndex = 1
    '
    'TxtPos2
    '
    Me.TxtPos2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPos2.Location = New System.Drawing.Point(153, 5)
    Me.TxtPos2.MaxLength = 5
    Me.TxtPos2.Name = "TxtPos2"
    Me.TxtPos2.Size = New System.Drawing.Size(50, 20)
    Me.TxtPos2.TabIndex = 2
    '
    'TxtPosYear
    '
    Me.TxtPosYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPosYear.Location = New System.Drawing.Point(77, 5)
    Me.TxtPosYear.MaxLength = 4
    Me.TxtPosYear.Name = "TxtPosYear"
    Me.TxtPosYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtPosYear.TabIndex = 0
    '
    'RbRevenue
    '
    Me.RbRevenue.AutoSize = True
    Me.RbRevenue.Checked = True
    Me.RbRevenue.Location = New System.Drawing.Point(306, 2)
    Me.RbRevenue.Name = "RbRevenue"
    Me.RbRevenue.Size = New System.Drawing.Size(129, 17)
    Me.RbRevenue.TabIndex = 19
    Me.RbRevenue.TabStop = True
    Me.RbRevenue.Text = "Revenue Accts (Print)"
    Me.RbRevenue.UseVisualStyleBackColor = True
    '
    'RbAr
    '
    Me.RbAr.AutoSize = True
    Me.RbAr.Location = New System.Drawing.Point(306, 17)
    Me.RbAr.Name = "RbAr"
    Me.RbAr.Size = New System.Drawing.Size(105, 17)
    Me.RbAr.TabIndex = 20
    Me.RbAr.Text = "A/R Accts (Print)"
    Me.RbAr.UseVisualStyleBackColor = True
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
    Me.DataGrdView.Location = New System.Drawing.Point(12, 40)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(423, 348)
    Me.DataGrdView.TabIndex = 201
    '
    'FrmGLA42B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(447, 400)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.RbAr)
    Me.Controls.Add(Me.RbRevenue)
    Me.Controls.Add(Me.TxtPosYear)
    Me.Controls.Add(Me.TxtPos2)
    Me.Controls.Add(Me.TxtPos)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnFind)
    Me.Name = "FrmGLA42B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

 Private Sub FrmGLA42B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
   myTXGLDA = New TXGLDA.MyData()
   myTXGLDA.MyDBConn = myDBConnect
   Call FormatGrid()
End Sub
Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
  FormatGrid()
  TxtPos.Text = String.Empty
End Sub
Public Sub FormatGrid()
  Call ShowGrid()
  With DataGrdView
    .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
    .RowHeadersWidth = 25
    .Columns(0).HeaderText = "Year"
    .Columns(0).Width = 40
    .Columns(1).HeaderText = "Tran"
    .Columns(1).Width = 40
    .Columns(2).HeaderText = "Code"
    .Columns(2).Width = 50
    .Columns(3).HeaderText = "Description"
    .Columns(3).Width = 240
    .Columns(4).Visible = False
    .Columns(5).Visible = False
    .Columns(6).Visible = False
    .Columns(7).Visible = False
   End With
End Sub
Public Sub ShowGrid()
  ds = myTXGLDA.PosData(MyUtils.CnvSng(TxtPosYear.Text), TxtPos.Text, TxtPos2.Text)
  DataGrdView.DataSource = ds.Tables(0)
  DataGrdView.Refresh()
End Sub
Private Sub FrmGLA42B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmGLA42.SbpScreen.Text = "GLA42B"
  MyFrmGLA42.TBarPrint.Enabled = True
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
  If DataGrdView.RowCount = 0 Then Exit Sub

  MyFrmGLA42C = New FrmGLA42C
  MyFrmGLA42C.MdiParent = Me.ParentForm
  MyFrmGLA42C.WrkTxyr = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
  MyFrmGLA42C.WrkTran = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
  MyFrmGLA42C.WrkCode = DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value
  MyFrmGLA42C.Show()
  Me.Hide()
End Sub
Public Sub PrintData()
  MyCrViewer = New FrmCrViewer
  MyCrViewer.Wrkds = myTXGLDA.PosData(0, "", "")

  If RbRevenue.Checked Then
    MyCrViewer.WrkRevenue = True
  Else
    MyCrViewer.WrkRevenue = False
  End If
  MyCrViewer.Show()
End Sub
  Public Sub MassCopy()
    Dim myTXGLDA As TXGLDA.MyData
    Dim myTXGLDANew As TXGLDA.MyData
    Dim WrkYear As Integer
    Dim WrkCopied As Integer
    Dim WrkSkipped As Integer
    Dim Answer As Integer

    myTXGLDA = New TXGLDA.MyData()
    myTXGLDA.MyDBConn = myDBConnect
    myTXGLDANew = New TXGLDA.MyData()
    myTXGLDANew.MyDBConn = myDBConnect
    WrkYear = MyUtils.CnvSng(DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value)
    If WrkYear = 0 Then
      MsgBox("Cannot mass copy year 0", MsgBoxStyle.Exclamation, "Invalid Year")
      Exit Sub
    End If
    Answer = MsgBox("New Year records already created will be skipped. Confirm year to copy is correct", MsgBoxStyle.OkCancel, "Mass Copy Year " & WrkYear & " to " & WrkYear + 1 & "?")
    If Answer = MsgBoxResult.Cancel Then Exit Sub

    With myTXGLDA
      .SetRange(WrkYear)
      If Not .IsEOF Then
        Do While Not .IsEOF
          .ReadFileE()
          If .IsEOF Then Exit Do
          myTXGLDANew.GetOneRecordP(WrkYear + 1, ._TRAN, ._CODE)
          If myTXGLDANew.RecordNotFound Then
            myTXGLDANew._ACCTCR = ._ACCTCR
            myTXGLDANew._ACCTDB = ._ACCTDB
            myTXGLDANew._ACARCR = ._ACARCR
            myTXGLDANew._ACARDB = ._ACARDB
            myTXGLDANew._CODE = ._CODE
            myTXGLDANew._DESC = Replace(._DESC, WrkYear, WrkYear + 1, )
            myTXGLDANew._TRAN = ._TRAN
            myTXGLDANew._TXYR = ._TXYR + 1
            myTXGLDANew.AddOneRecordP()
            WrkCopied = WrkCopied + 1
          Else
            WrkSkipped = WrkSkipped + 1
          End If
        Loop
      End If
    End With

    MsgBox("Records copied: " & WrkCopied & " / Records skipped: " & WrkSkipped, MsgBoxStyle.Exclamation, "Mass Copy processed")
    myTXGLDA.CloseFile()
    myTXGLDA = Nothing
    MyFrmGLA42B.TxtPosYear.Text = WrkYear + 1
    MyFrmGLA42B.FormatGrid()
  End Sub
End Class
