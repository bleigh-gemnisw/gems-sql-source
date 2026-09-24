Public Class FrmListGLAcct
  Inherits System.Windows.Forms.Form
	Dim myGLAcct As GLACCT.myData
	Dim ds As DataSet = New DataSet
  Dim WrkDelete As Boolean
  Friend WithEvents TxtSfcn As System.Windows.Forms.TextBox
  Friend WithEvents TxtFcn As System.Windows.Forms.TextBox
  Friend WithEvents TxtObj As System.Windows.Forms.TextBox
  Friend WithEvents TxtDpt As System.Windows.Forms.TextBox
  Friend WithEvents TxtSfnd As System.Windows.Forms.TextBox
  Friend WithEvents TxtFnd As System.Windows.Forms.TextBox
  Friend WrkCode As String
  Friend WrkField As String

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
  Friend WithEvents LblCurrent As System.Windows.Forms.Label
Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListGLAcct))
Me.Label1 = New System.Windows.Forms.Label
Me.BtnFind = New System.Windows.Forms.Button
Me.LblCurrent = New System.Windows.Forms.Label
Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
Me.TxtSfcn = New System.Windows.Forms.TextBox
Me.TxtFcn = New System.Windows.Forms.TextBox
Me.TxtObj = New System.Windows.Forms.TextBox
Me.TxtDpt = New System.Windows.Forms.TextBox
Me.TxtSfnd = New System.Windows.Forms.TextBox
Me.TxtFnd = New System.Windows.Forms.TextBox
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
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
Me.BtnFind.Location = New System.Drawing.Point(334, 8)
Me.BtnFind.Name = "BtnFind"
Me.BtnFind.Size = New System.Drawing.Size(53, 22)
Me.BtnFind.TabIndex = 29
Me.BtnFind.Text = "&Find"
'
'LblCurrent
'
Me.LblCurrent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
Me.LblCurrent.Location = New System.Drawing.Point(66, 34)
Me.LblCurrent.Name = "LblCurrent"
Me.LblCurrent.Size = New System.Drawing.Size(248, 14)
Me.LblCurrent.TabIndex = 32
'
'C1DataGrdList
'
Me.C1DataGrdList.AllowColSelect = False
Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
Me.C1DataGrdList.AlternatingRows = True
Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
Me.C1DataGrdList.Location = New System.Drawing.Point(12, 54)
Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
Me.C1DataGrdList.Name = "C1DataGrdList"
Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75
Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.C1DataGrdList.Size = New System.Drawing.Size(576, 260)
Me.C1DataGrdList.TabIndex = 198
Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
'
'TxtSfcn
'
Me.TxtSfcn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtSfcn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtSfcn.Location = New System.Drawing.Point(283, 8)
Me.TxtSfcn.MaxLength = 4
Me.TxtSfcn.Name = "TxtSfcn"
Me.TxtSfcn.Size = New System.Drawing.Size(45, 22)
Me.TxtSfcn.TabIndex = 204
'
'TxtFcn
'
Me.TxtFcn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtFcn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFcn.Location = New System.Drawing.Point(234, 8)
Me.TxtFcn.MaxLength = 4
Me.TxtFcn.Name = "TxtFcn"
Me.TxtFcn.Size = New System.Drawing.Size(45, 22)
Me.TxtFcn.TabIndex = 203
'
'TxtObj
'
Me.TxtObj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtObj.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtObj.Location = New System.Drawing.Point(196, 8)
Me.TxtObj.MaxLength = 3
Me.TxtObj.Name = "TxtObj"
Me.TxtObj.Size = New System.Drawing.Size(32, 22)
Me.TxtObj.TabIndex = 202
'
'TxtDpt
'
Me.TxtDpt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtDpt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDpt.Location = New System.Drawing.Point(145, 8)
Me.TxtDpt.MaxLength = 4
Me.TxtDpt.Name = "TxtDpt"
Me.TxtDpt.Size = New System.Drawing.Size(45, 22)
Me.TxtDpt.TabIndex = 201
'
'TxtSfnd
'
Me.TxtSfnd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtSfnd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtSfnd.Location = New System.Drawing.Point(107, 8)
Me.TxtSfnd.MaxLength = 3
Me.TxtSfnd.Name = "TxtSfnd"
Me.TxtSfnd.Size = New System.Drawing.Size(32, 22)
Me.TxtSfnd.TabIndex = 200
'
'TxtFnd
'
Me.TxtFnd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtFnd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFnd.Location = New System.Drawing.Point(69, 8)
Me.TxtFnd.MaxLength = 3
Me.TxtFnd.Name = "TxtFnd"
Me.TxtFnd.Size = New System.Drawing.Size(32, 22)
Me.TxtFnd.TabIndex = 199
'
'FrmListGLAcct
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(600, 326)
Me.Controls.Add(Me.TxtSfcn)
Me.Controls.Add(Me.TxtFcn)
Me.Controls.Add(Me.TxtObj)
Me.Controls.Add(Me.TxtDpt)
Me.Controls.Add(Me.TxtSfnd)
Me.Controls.Add(Me.TxtFnd)
Me.Controls.Add(Me.C1DataGrdList)
Me.Controls.Add(Me.LblCurrent)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.BtnFind)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmListGLAcct"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Select G/L Acct"
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    Call FormatGrid()
  End Sub

  Public Sub FormatGrid()

    Call ShowGrid()

    With C1DataGrdList
      .Rebind(True)
      .Columns(0).Caption = "Fund"
      .Splits(0).DisplayColumns(0).Width = 40
      .Columns(1).Caption = "Sfund"
      .Splits(0).DisplayColumns(1).Width = 40
      .Columns(2).Caption = "Dept"
      .Splits(0).DisplayColumns(2).Width = 40
      .Columns(3).Caption = "Obj"
      .Splits(0).DisplayColumns(3).Width = 40
      .Columns(4).Caption = "Func"
      .Splits(0).DisplayColumns(4).Width = 40
      .Columns(5).Caption = "Sfcn"
      .Splits(0).DisplayColumns(5).Width = 40
      .Columns(6).Caption = "Description"
      .Splits(0).DisplayColumns(6).Width = 200
			.Columns(7).Caption = "Type"
			.Splits(0).DisplayColumns(7).Width = 80
			.Columns(7).ValueItems.Values.Clear()
			.Columns(7).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("A", "Asset"))
			.Columns(7).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("H", "Header"))
			.Columns(7).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("L", "Liability"))
			.Columns(7).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("R", "Revenue"))
			.Columns(7).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("Q", "Equity"))
			.Columns(7).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("X", "Expenditure"))
			.Columns(7).ValueItems.Translate = True
		End With

  End Sub
  Public Sub ShowGrid()
    ds = myGLAcct.GetViewbyAcct(MyUtils.CnvSng(TxtFnd.Text), MyUtils.CnvSng(TxtSfnd.Text), MyUtils.CnvSng(TxtDpt.Text), _
        MyUtils.CnvSng(TxtObj.Text), MyUtils.CnvSng(TxtFcn.Text), MyUtils.CnvSng(TxtSfcn.Text), 250)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

  End Sub
  Private Sub FrmListGLAcct_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmAR101.SbpScreen.Text = "ListGLAcct"
  End Sub
  Private Sub TxtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    If e.KeyChar = MyUtils.VbKeyEnter Then
      FormatGrid()
    End If
  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Dim I As Integer
    I = ds.Tables(0).Rows.Count - 1
    TxtFnd.Text = C1DataGrdList.Item(I, 0)
    TxtSfnd.Text = C1DataGrdList.Item(I, 1)
    TxtDpt.Text = C1DataGrdList.Item(I, 2)
    TxtObj.Text = C1DataGrdList.Item(I, 3)
    TxtFcn.Text = C1DataGrdList.Item(I, 4)
    TxtSfcn.Text = C1DataGrdList.Item(I, 5)
    FormatGrid()
    TxtFnd.Text = ""
    TxtSfnd.Text = ""
    TxtDpt.Text = ""
    TxtObj.Text = ""
    TxtFcn.Text = ""
    TxtSfcn.Text = ""
  End Sub

  Private Sub FrmListGLAcct_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    MyFrmAR101.TBarDelete.Enabled = WrkDelete
    MyFrmAR101C.Show()
  End Sub
  Private Sub FrmListGLAcct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myGLAcct = New GLACCT.MyData()
    myGLAcct.MyDBConn = myDBConnect
    WrkDelete = MyFrmAR101.TBarDelete.Enabled
    MyFrmAR101.TBarDelete.Enabled = False
    If WrkCode <> String.Empty Then
      TxtFnd.Text = MyUtils.CnvSng(Mid(WrkCode, 1, 3))
      TxtSfnd.Text = MyUtils.CnvSng(Mid(WrkCode, 5, 3))
      TxtDpt.Text = MyUtils.CnvSng(Mid(WrkCode, 9, 4))
      TxtObj.Text = MyUtils.CnvSng(Mid(WrkCode, 14, 3))
      TxtFcn.Text = MyUtils.CnvSng(Mid(WrkCode, 18, 4))
      TxtSfcn.Text = MyUtils.CnvSng(Mid(WrkCode, 23, 4))
      LblCurrent.Text = "(G/L Acct =" & WrkCode & ")"
    End If
    FormatGrid()
  End Sub
Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    With MyFrmAR101C
      If WrkField = "Credit" Then
        .TxtFund.Text = C1DataGrdList.Item(C1DataGrdList.Row, 0)
        .TxtSFund.Text = C1DataGrdList.Item(C1DataGrdList.Row, 1)
        .TxtDept.Text = C1DataGrdList.Item(C1DataGrdList.Row, 2)
        .TxtObj.Text = C1DataGrdList.Item(C1DataGrdList.Row, 3)
        .TxtFcn.Text = C1DataGrdList.Item(C1DataGrdList.Row, 4)
        .TxtSfcn.Text = C1DataGrdList.Item(C1DataGrdList.Row, 5)
        .Ttp1.SetToolTip(.TxtFund, C1DataGrdList.Item(C1DataGrdList.Row, 6))
      Else
        .TxtFundd.Text = C1DataGrdList.Item(C1DataGrdList.Row, 0)
        .TxtSFundd.Text = C1DataGrdList.Item(C1DataGrdList.Row, 1)
        .TxtDeptd.Text = C1DataGrdList.Item(C1DataGrdList.Row, 2)
        .TxtObjd.Text = C1DataGrdList.Item(C1DataGrdList.Row, 3)
        .TxtFcnd.Text = C1DataGrdList.Item(C1DataGrdList.Row, 4)
        .TxtSfcnd.Text = C1DataGrdList.Item(C1DataGrdList.Row, 5)
        .Ttp1.SetToolTip(.TxtFundd, C1DataGrdList.Item(C1DataGrdList.Row, 6))
      End If
    End With
    Me.Close()
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub
End Class
