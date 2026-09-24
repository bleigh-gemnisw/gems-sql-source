Imports System.Data
Public Class FrmTA8101R
  Inherits System.Windows.Forms.Form
  Dim myTXCOEBL1 As TXCOEBL1.myData
  Dim myTXCOEBL4 As TXCOEBL4.myData
  Dim ds As DataSet = New DataSet
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtType As System.Windows.Forms.TextBox
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  Friend WithEvents BtnLookup As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtList As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents LblAsrgl As System.Windows.Forms.Label
  Friend WithEvents DataGrdView As DataGridView
  Dim WrkTxType As String

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
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents BtnFast As System.Windows.Forms.Button
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents TxtPos As System.Windows.Forms.TextBox
  Friend WithEvents BtnNext As System.Windows.Forms.Button
  Friend WithEvents TxtCCNo As System.Windows.Forms.TextBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.BtnFast = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtCCNo = New System.Windows.Forms.TextBox()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.BtnLookup = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtList = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.LblAsrgl = New System.Windows.Forms.Label()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.GroupBox2.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.BtnFast)
    Me.GroupBox2.Controls.Add(Me.Label2)
    Me.GroupBox2.Controls.Add(Me.TxtCCNo)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(405, -2)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(153, 38)
    Me.GroupBox2.TabIndex = 26
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Fast Path"
    '
    'BtnFast
    '
    Me.BtnFast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFast.Location = New System.Drawing.Point(96, 10)
    Me.BtnFast.Name = "BtnFast"
    Me.BtnFast.Size = New System.Drawing.Size(53, 24)
    Me.BtnFast.TabIndex = 4
    Me.BtnFast.Text = "S&how"
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(8, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(32, 16)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "C/C#"
    '
    'TxtCCNo
    '
    Me.TxtCCNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCCNo.Location = New System.Drawing.Point(44, 14)
    Me.TxtCCNo.MaxLength = 5
    Me.TxtCCNo.Name = "TxtCCNo"
    Me.TxtCCNo.Size = New System.Drawing.Size(40, 20)
    Me.TxtCCNo.TabIndex = 3
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(193, 61)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 1
    Me.BtnFind.Text = "&Find"
    '
    'TxtPos
    '
    Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPos.Location = New System.Drawing.Point(59, 64)
    Me.TxtPos.MaxLength = 25
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(128, 20)
    Me.TxtPos.TabIndex = 0
    '
    'BtnNext
    '
    Me.BtnNext.Location = New System.Drawing.Point(249, 61)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(53, 24)
    Me.BtnNext.TabIndex = 2
    Me.BtnNext.Text = "Ne&xt"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.TxtType)
    Me.GroupBox1.Controls.Add(Me.TxtYear)
    Me.GroupBox1.Controls.Add(Me.BtnLookup)
    Me.GroupBox1.Controls.Add(Me.Label1)
    Me.GroupBox1.Controls.Add(Me.TxtList)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(366, 38)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(191, 55)
    Me.GroupBox1.TabIndex = 30
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "List Number Lookup"
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtType.Location = New System.Drawing.Point(64, 30)
    Me.TxtType.MaxLength = 1
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(16, 20)
    Me.TxtType.TabIndex = 1
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(83, 30)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtYear.TabIndex = 2
    '
    'BtnLookup
    '
    Me.BtnLookup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnLookup.Location = New System.Drawing.Point(135, 23)
    Me.BtnLookup.Name = "BtnLookup"
    Me.BtnLookup.Size = New System.Drawing.Size(43, 24)
    Me.BtnLookup.TabIndex = 7
    Me.BtnLookup.TabStop = False
    Me.BtnLookup.Text = "Find"
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(6, 14)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(91, 13)
    Me.Label1.TabIndex = 6
    Me.Label1.Text = "List #/Type/Year"
    '
    'TxtList
    '
    Me.TxtList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtList.Location = New System.Drawing.Point(8, 30)
    Me.TxtList.MaxLength = 7
    Me.TxtList.Name = "TxtList"
    Me.TxtList.Size = New System.Drawing.Size(55, 20)
    Me.TxtList.TabIndex = 0
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(10, 67)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(43, 16)
    Me.Label3.TabIndex = 31
    Me.Label3.Text = "Name:"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(12, 10)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(51, 13)
    Me.Label4.TabIndex = 32
    Me.Label4.Text = "G/L Year"
    '
    'LblAsrgl
    '
    Me.LblAsrgl.BackColor = System.Drawing.Color.Aqua
    Me.LblAsrgl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAsrgl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAsrgl.Location = New System.Drawing.Point(69, 8)
    Me.LblAsrgl.Name = "LblAsrgl"
    Me.LblAsrgl.Size = New System.Drawing.Size(31, 15)
    Me.LblAsrgl.TabIndex = 34
    Me.LblAsrgl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
    Me.DataGrdView.Location = New System.Drawing.Point(2, 100)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(563, 346)
    Me.DataGrdView.TabIndex = 42
    '
    'FrmTA8101R
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(569, 447)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.LblAsrgl)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.BtnNext)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.BtnFind)
    Me.Controls.Add(Me.TxtPos)
    Me.Name = "FrmTA8101R"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTA8101R_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    myTXCOEBL1 = New TXCOEBL1.mydata(MyDBConnect)
    myTXCOEBL4 = New TXCOEBL4.mydata(MyDBConnect)

    MyFrmTA810.TBarHist.Enabled = False
    MyFrmTA810.TBarPrint.Enabled = False
    LblAsrgl.Text = MyGLYear
    Call FormatGrid(True)

  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    Call FormatGrid(True)
  End Sub
  Public Sub FormatGrid(ByVal WrkName As Boolean)
    Dim I As Integer

    If WrkName Then
      Call ShowGridByName()
    Else
      Call ShowGridByList()
    End If

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "C/C No"
      .Columns(0).Width = 50
      .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns(1).HeaderText = "Year"
      .Columns(1).Width = 40
      .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns(2).HeaderText = "ListNo"
      .Columns(2).Width = 50
      .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns(3).HeaderText = "Type"
      .Columns(3).Width = 40
      .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      .Columns(4).HeaderText = "Name"
      .Columns(4).Width = 250
      .Columns(5).Visible = False
      .Columns(6).HeaderText = "C/C Date"
      .Columns(6).Width = 70
      .Columns(6).DefaultCellStyle.Format = "##/##/####"
    End With

    With DataGrdView
      If Not WrkName Then
        For I = 7 To 9
          .Columns(I).Visible = False
        Next
      End If
    End With
  End Sub
  Public Sub ShowGridByName()
    Dim WrkPos As String
    WrkPos = Replace(TxtPos.Text, "'", "''")
    ds = myTXCOEBL1.GetViewbyName(WrkPos, 50)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
  End Sub
  Public Sub ShowGridByList()
    ds = myTXCOEBL4.GetViewDescList(MyUtils.CnvSng(TxtList.Text), MyUtils.CnvSng(TxtYear.Text), TxtType.Text, 99999999, 999999, 50)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
  End Sub
  Private Sub FrmTA8101R_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA810.SbpScreen.Text = "TA8101R"
    MyUtils.CenterForm(Me.ParentForm, Me)

  End Sub
  Private Sub BtnFast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFast.Click
    ShowFastPath()
  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
    Dim I As Integer
    I = ds.Tables(0).Rows.Count - 1
    TxtPos.Text = DataGrdView.Item(4, I).Value
    FormatGrid(True)
    TxtPos.Text = ""
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    WrkTxType = DataGrdView.Item(3, DataGrdView.CurrentRow.Index).Value

    Select Case WrkTxType
      Case "M"
        MyFrmTA8104R = New FrmTA8104R
        MyFrmTA8104R.MdiParent = Me.ParentForm
        MyFrmTA8104R.WrkCCNo = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
        MyFrmTA8104R.Show()
      Case "P"
        MyFrmTA8103R = New FrmTA8103R
        MyFrmTA8103R.MdiParent = Me.ParentForm
        MyFrmTA8103R.WrkCCNo = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
        MyFrmTA8103R.Show()
      Case Is = "R"
        MyFrmTA8102R = New FrmTA8102R
        MyFrmTA8102R.MdiParent = Me.ParentForm
        MyFrmTA8102R.WrkCCNo = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
        MyFrmTA8102R.Show()
    End Select

    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub TxtCCNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCCNo.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      ShowFastPath()
      Exit Sub
    End If

    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtList.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtType.KeyPress
    'Move to next field after anything has been typed since it's only 1 char allowed
    Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
  End Sub
  Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      FormatGrid(False)
      Exit Sub
    End If

    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub ShowFastPath()
    Dim myTXCOEB As TXCOEB.myData
    Dim WrkType As String

    ErrProv.SetError(TxtCCNo, "")
    If TxtCCNo.Text = "" Then Exit Sub

    myTXCOEB = New TXCOEB.mydata(MyDBConnect)
    myTXCOEB.GetOneRecordP(MyUtils.CnvSng(TxtCCNo.Text))
    If myTXCOEB.RecordNotFound Then
      ErrProv.SetError(TxtCCNo, "Invalid C/C Number")
      Exit Sub
    End If

    WrkType = Trim(myTXCOEB._CTYPE)
    Select Case WrkType
      Case "M"
        MyFrmTA8104R = New FrmTA8104R
        MyFrmTA8104R.MdiParent = Me.ParentForm
        MyFrmTA8104R.Wrkaddmode = False
        MyFrmTA8104R.WrkCCNo = TxtCCNo.Text
        MyFrmTA8104R.Show()
      Case "P"
        MyFrmTA8103R = New FrmTA8103R
        MyFrmTA8103R.MdiParent = Me.ParentForm
        MyFrmTA8103R.Wrkaddmode = False
        MyFrmTA8103R.WrkCCNo = TxtCCNo.Text
        MyFrmTA8103R.Show()
      Case "R"
        MyFrmTA8102R = New FrmTA8102R
        MyFrmTA8102R.MdiParent = Me.ParentForm
        MyFrmTA8102R.WrkAddMode = False
        MyFrmTA8102R.WrkCCNo = TxtCCNo.Text
        MyFrmTA8102R.Show()
    End Select

    TxtCCNo.Text = ""
    Me.Hide()

  End Sub

  Private Sub BtnLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLookup.Click
    FormatGrid(False)
  End Sub
End Class






