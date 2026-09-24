Public Class FrmGLA01B
  Inherits System.Windows.Forms.Form
  Dim myTXGL As TXGL.MyData
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
    Me.DataGrdView.Location = New System.Drawing.Point(12, 38)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(257, 350)
    Me.DataGrdView.TabIndex = 202
    '
    'FrmGLA01B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(281, 400)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.TxtPosYear)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtPosType)
    Me.Controls.Add(Me.BtnFind)
    Me.Name = "FrmGLA01B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmGLA01B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXGL = New TXGL.MyData()
    myTXGL.MyDBConn = myDBConnect
    Call FormatGrid()
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    FormatGrid()
  End Sub
  Public Sub FormatGrid()
    Dim I As Integer
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
      .Columns(3).HeaderText = "Susp?"
      .Columns(3).Width = 40
      .Columns(4).HeaderText = "Dist"
      .Columns(4).Width = 30
      .Columns(5).HeaderText = "Phs"
      .Columns(5).Width = 30
      For I = 6 To 30
        .Columns(I).Visible = False
      Next
    End With
  End Sub
  Public Sub ShowGrid()
    ds.Clear()
    ds = Nothing
    ds = myTXGL.PosData(MyUtils.CnvSng(TxtPosYear.Text), TxtPosType.Text, String.Empty, String.Empty, 0, String.Empty)

    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
  End Sub
  Private Sub FrmGLA01B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGLA01.SbpScreen.Text = "GLA01B"
    MyFrmGLA01.TBarPrint.Enabled = True
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    MyFrmGLA01C = New FrmGLA01C
    MyFrmGLA01C.MdiParent = Me.ParentForm
    MyFrmGLA01C.WrkYear = MyUtils.CnvSng(DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value)
    MyFrmGLA01C.WrkType = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
    MyFrmGLA01C.WrkCode = DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value
    MyFrmGLA01C.WrkSusp = DataGrdView.Item(3, DataGrdView.CurrentRow.Index).Value
    MyFrmGLA01C.WrkDist = DataGrdView.Item(4, DataGrdView.CurrentRow.Index).Value
    MyFrmGLA01C.WrkPhs = DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value
    MyFrmGLA01C.WrkCopyMode = False
    MyFrmGLA01C.Show()
    Me.Hide()
  End Sub
  Public Sub CopyData()
    Dim myTXGL As TXGL.MyData
    Dim WrkYear1 As Integer
    Dim WrkType1 As String
    Dim WrkCode1 As String
    Dim WrkSusp1 As String
    Dim WrkDist1 As Integer
    Dim WrkPhs1 As String

    myTXGL = New TXGL.MyData()
    myTXGL.MyDBConn = myDBConnect
    WrkYear1 = MyUtils.CnvSng(DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value) + 1
    WrkType1 = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
    WrkCode1 = DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value
    WrkSusp1 = DataGrdView.Item(3, DataGrdView.CurrentRow.Index).Value
    WrkDist1 = MyUtils.CnvSng(DataGrdView.Item(4, DataGrdView.CurrentRow.Index).Value)
    WrkPhs1 = DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value

    myTXGL.GetOneRecordP(WrkYear1, WrkType1, WrkCode1, WrkSusp1, WrkDist1, WrkPhs1)
    If Not myTXGL.RecordNotFound Then
      MsgBox("Next year's data already exists", MsgBoxStyle.Exclamation, "Copy cancelled")
      myTXGL.CloseFile()
      myTXGL = Nothing
      Exit Sub
    End If

    myTXGL.CloseFile()
    myTXGL = Nothing

    MyFrmGLA01C = New FrmGLA01C
    MyFrmGLA01C.MdiParent = Me.ParentForm
    MyFrmGLA01C.WrkYear = WrkYear1
    MyFrmGLA01C.WrkType = WrkType1
    MyFrmGLA01C.WrkCode = WrkCode1
    MyFrmGLA01C.WrkSusp = WrkSusp1
    MyFrmGLA01C.WrkDist = WrkDist1
    MyFrmGLA01C.WrkPhs = WrkPhs1
    MyFrmGLA01C.WrkCopyMode = True
    MyFrmGLA01C.Show()
    Me.Hide()
  End Sub
  Public Sub MassCopy()
    Dim myTXGL As TXGL.MyData
    Dim myTXGLNew As TXGL.MyData
    Dim WrkYear As Integer
    Dim WrkCopied As Integer
    Dim WrkSkipped As Integer
    Dim Answer As Integer

    myTXGL = New TXGL.MyData()
    myTXGL.MyDBConn = myDBConnect
    myTXGLNew = New TXGL.MyData()
    myTXGLNew.MyDBConn = myDBConnect
    WrkYear = MyUtils.CnvSng(DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value)
    Answer = MsgBox("New Year records already created will be skipped. Confirm year to copy is correct", MsgBoxStyle.OkCancel, "Mass Copy Year " & WrkYear & " to " & WrkYear + 1 & "?")
    If Answer = MsgBoxResult.Cancel Then Exit Sub

    With myTXGL
      .SetRange(WrkYear)
      If Not .IsEOF Then
        Do While Not .IsEOF
          .ReadFileE()
          If .IsEOF Then Exit Do
          myTXGLNew.GetOneRecordP(WrkYear + 1, ._TXTYP, ._TXCD, ._TXSUP, ._TXDIST, ._TXPHS)
          If myTXGLNew.RecordNotFound Then
            myTXGLNew._DPNLC = ._DPNLC
            myTXGLNew._DPNLD = ._DPNLD
            myTXGLNew._DPNRC = ._DPNRC
            myTXGLNew._DPNRD = ._DPNRD
            myTXGLNew._FDNLC = ._FDNLC
            myTXGLNew._FDNLD = ._FDNLD
            myTXGLNew._FDNRC = ._FDNRC
            myTXGLNew._FDNRD = ._FDNRD
            myTXGLNew._FNPLC = ._FNPLC
            myTXGLNew._FNPLD = ._FNPLD
            myTXGLNew._FNPRC = ._FNPRC
            myTXGLNew._FNPRD = ._FNPRD
            myTXGLNew._OBNLC = ._OBNLC
            myTXGLNew._OBNLD = ._OBNLD
            myTXGLNew._OBNRC = ._OBNRC
            myTXGLNew._OBNRD = ._OBNRD
            myTXGLNew._SFULC = ._SFULC
            myTXGLNew._SFULD = ._SFULD
            myTXGLNew._SFURC = ._SFURC
            myTXGLNew._SFURD = ._SFURD
            myTXGLNew._SUBLC = ._SUBLC
            myTXGLNew._SUBLD = ._SUBLD
            myTXGLNew._SUBRC = ._SUBRC
            myTXGLNew._SUBRD = ._SUBRD
            myTXGLNew._TXADD = ._TXADD
            myTXGLNew._TXCD = ._TXCD
            myTXGLNew._TXDIST = ._TXDIST
            myTXGLNew._TXPHS = ._TXPHS
            myTXGLNew._TXSUP = ._TXSUP
            myTXGLNew._TXTYP = ._TXTYP
            myTXGLNew._TXYR = ._TXYR + 1
            myTXGLNew.AddOneRecordP()
            WrkCopied = WrkCopied + 1
          Else
            WrkSkipped = WrkSkipped + 1
          End If
        Loop
      End If
    End With

    MsgBox("Records copied: " & WrkCopied & " / Records skipped: " & WrkSkipped, MsgBoxStyle.Exclamation, "Mass Copy processed")
    myTXGL.CloseFile()
    myTXGL = Nothing
    MyFrmGLA01B.TxtPosYear.Text = WrkYear + 1
    MyFrmGLA01B.FormatGrid()
  End Sub
  Public Sub MassReplace()
    Dim myTXGL As TXGL.MyData
    Dim myTXGLNew As TXGL.MyData
    Dim WrkYear As Integer
    Dim WrkCopied As Integer
    Dim WrkReplaced As Integer
    Dim Answer As Integer

    myTXGL = New TXGL.MyData()
    myTXGL.MyDBConn = myDBConnect
    myTXGLNew = New TXGL.MyData()
    myTXGLNew.MyDBConn = myDBConnect
    WrkYear = MyUtils.CnvSng(DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value)
    Answer = MsgBox("New Year records will be Replaced. Missing records will be copied. Confirm year to replace is correct", MsgBoxStyle.OkCancel, "Mass Copy Year " & WrkYear & " to " & WrkYear + 1 & "?")
    If Answer = MsgBoxResult.Cancel Then Exit Sub

    With myTXGL
      .SetRange(WrkYear)
      If Not .IsEOF Then
        Do While Not .IsEOF
          .ReadFileE()
          If .IsEOF Then Exit Do
          myTXGLNew.GetOneRecordP(WrkYear + 1, ._TXTYP, ._TXCD, ._TXSUP, ._TXDIST, ._TXPHS)
          If myTXGLNew.RecordNotFound Then
            myTXGLNew._DPNLC = ._DPNLC
            myTXGLNew._DPNLD = ._DPNLD
            myTXGLNew._DPNRC = ._DPNRC
            myTXGLNew._DPNRD = ._DPNRD
            myTXGLNew._FDNLC = ._FDNLC
            myTXGLNew._FDNLD = ._FDNLD
            myTXGLNew._FDNRC = ._FDNRC
            myTXGLNew._FDNRD = ._FDNRD
            myTXGLNew._FNPLC = ._FNPLC
            myTXGLNew._FNPLD = ._FNPLD
            myTXGLNew._FNPRC = ._FNPRC
            myTXGLNew._FNPRD = ._FNPRD
            myTXGLNew._OBNLC = ._OBNLC
            myTXGLNew._OBNLD = ._OBNLD
            myTXGLNew._OBNRC = ._OBNRC
            myTXGLNew._OBNRD = ._OBNRD
            myTXGLNew._SFULC = ._SFULC
            myTXGLNew._SFULD = ._SFULD
            myTXGLNew._SFURC = ._SFURC
            myTXGLNew._SFURD = ._SFURD
            myTXGLNew._SUBLC = ._SUBLC
            myTXGLNew._SUBLD = ._SUBLD
            myTXGLNew._SUBRC = ._SUBRC
            myTXGLNew._SUBRD = ._SUBRD
            myTXGLNew._TXADD = ._TXADD
            myTXGLNew._TXCD = ._TXCD
            myTXGLNew._TXDIST = ._TXDIST
            myTXGLNew._TXPHS = ._TXPHS
            myTXGLNew._TXSUP = ._TXSUP
            myTXGLNew._TXTYP = ._TXTYP
            myTXGLNew._TXYR = ._TXYR + 1
            myTXGLNew.AddOneRecordP()
            WrkCopied = WrkCopied + 1
          Else
            myTXGLNew._DPNLC = ._DPNLC
            myTXGLNew._DPNLD = ._DPNLD
            myTXGLNew._DPNRC = ._DPNRC
            myTXGLNew._DPNRD = ._DPNRD
            myTXGLNew._FDNLC = ._FDNLC
            myTXGLNew._FDNLD = ._FDNLD
            myTXGLNew._FDNRC = ._FDNRC
            myTXGLNew._FDNRD = ._FDNRD
            myTXGLNew._FNPLC = ._FNPLC
            myTXGLNew._FNPLD = ._FNPLD
            myTXGLNew._FNPRC = ._FNPRC
            myTXGLNew._FNPRD = ._FNPRD
            myTXGLNew._OBNLC = ._OBNLC
            myTXGLNew._OBNLD = ._OBNLD
            myTXGLNew._OBNRC = ._OBNRC
            myTXGLNew._OBNRD = ._OBNRD
            myTXGLNew._SFULC = ._SFULC
            myTXGLNew._SFULD = ._SFULD
            myTXGLNew._SFURC = ._SFURC
            myTXGLNew._SFURD = ._SFURD
            myTXGLNew._SUBLC = ._SUBLC
            myTXGLNew._SUBLD = ._SUBLD
            myTXGLNew._SUBRC = ._SUBRC
            myTXGLNew._SUBRD = ._SUBRD
            myTXGLNew._TXADD = ._TXADD
            myTXGLNew.UpdateOneRecordP()
            WrkReplaced = WrkReplaced + 1
          End If
        Loop
      End If
    End With

    MsgBox("Records copied: " & WrkCopied & " / Records replaced: " & WrkReplaced, MsgBoxStyle.Exclamation, "Mass Replace processed")
    myTXGL.CloseFile()
    myTXGL = Nothing
    MyFrmGLA01B.TxtPosYear.Text = WrkYear + 1
    MyFrmGLA01B.FormatGrid()
  End Sub
  Public Sub PrintData()
    Dim ds2 As DataSet = New DataSet
    Dim dr As DataRow
    Dim WrkAcct As String
    Dim I As Integer

    BuildDs2(ds2)
    For I = 0 To ds.Tables(0).Rows.Count - 1
      dr = ds2.Tables(0).NewRow
      With ds.Tables(0).Rows(I)
        dr.Item("txyr") = .Item("txyr")
        dr.Item("txtyp") = .Item("txtyp")
        dr.Item("txcd") = .Item("txcd")
        dr.Item("txsup") = .Item("txsup")
        dr.Item("txdist") = .Item("txdist")
        dr.Item("txphs") = .Item("txphs")
        WrkAcct = BuildAcct(.Item("fdnrc"), .Item("sfurc"), .Item("dpnrc"), .Item("obnrc"), .Item("fnprc"), .Item("subrc"))
        dr.Item("acctrc") = WrkAcct
        WrkAcct = BuildAcct(.Item("fdnrd"), .Item("sfurd"), .Item("dpnrd"), .Item("obnrd"), .Item("fnprd"), .Item("subrd"))
        dr.Item("acctrd") = WrkAcct
        WrkAcct = BuildAcct(.Item("fdnlc"), .Item("sfulc"), .Item("dpnlc"), .Item("obnlc"), .Item("fnplc"), .Item("sublc"))
        dr.Item("acctlc") = WrkAcct
        WrkAcct = BuildAcct(.Item("fdnld"), .Item("sfuld"), .Item("dpnld"), .Item("obnld"), .Item("fnpld"), .Item("subld"))
        dr.Item("acctld") = WrkAcct
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
      .Columns.Add("Txsup", Type.GetType("System.String"))
      .Columns.Add("Txdist", Type.GetType("System.Int32"))
      .Columns.Add("Txphs", Type.GetType("System.String"))
      .Columns.Add("Acctrc", Type.GetType("System.String"))
      .Columns.Add("Acctrd", Type.GetType("System.String"))
      .Columns.Add("Acctlc", Type.GetType("System.String"))
      .Columns.Add("Acctld", Type.GetType("System.String"))
    End With
    Ds2.Tables.Add(myTable)
  End Sub

End Class
