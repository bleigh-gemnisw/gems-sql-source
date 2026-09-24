Imports System.Data
Public Class FrmGLA51B
  Inherits System.Windows.Forms.Form
  Dim myPRGLMAP As PRGLMAP.MyData
  Dim ds As DataSet = New DataSet
  Friend WithEvents TxtSubfn As System.Windows.Forms.TextBox
  Friend WithEvents TxtFnpgm As System.Windows.Forms.TextBox
  Friend WithEvents TxtObnbr As System.Windows.Forms.TextBox
  Friend WithEvents TxtDpnbr As System.Windows.Forms.TextBox
  Friend WithEvents TxtSfund As System.Windows.Forms.TextBox
  Friend WithEvents TxtFdnbr As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label

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
  Friend WithEvents BtnNext As System.Windows.Forms.Button
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGLA51B))
    Me.BtnFind = New System.Windows.Forms.Button
    Me.BtnNext = New System.Windows.Forms.Button
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Me.Label3 = New System.Windows.Forms.Label
    Me.TxtSubfn = New System.Windows.Forms.TextBox
    Me.TxtFnpgm = New System.Windows.Forms.TextBox
    Me.TxtObnbr = New System.Windows.Forms.TextBox
    Me.TxtDpnbr = New System.Windows.Forms.TextBox
    Me.TxtSfund = New System.Windows.Forms.TextBox
    Me.TxtFdnbr = New System.Windows.Forms.TextBox
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(354, 10)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 6
    Me.BtnFind.Text = "&Find"
    '
    'BtnNext
    '
    Me.BtnNext.Location = New System.Drawing.Point(413, 10)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(53, 24)
    Me.BtnNext.TabIndex = 7
    Me.BtnNext.Text = "&Next"
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
    Me.C1DataGrdList.Location = New System.Drawing.Point(13, 40)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.Size = New System.Drawing.Size(453, 308)
    Me.C1DataGrdList.TabIndex = 196
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(9, 16)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(64, 16)
    Me.Label3.TabIndex = 201
    Me.Label3.Text = "Position To"
    '
    'TxtSubfn
    '
    Me.TxtSubfn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSubfn.Location = New System.Drawing.Point(295, 10)
    Me.TxtSubfn.MaxLength = 4
    Me.TxtSubfn.Name = "TxtSubfn"
    Me.TxtSubfn.Size = New System.Drawing.Size(45, 22)
    Me.TxtSubfn.TabIndex = 5
    '
    'TxtFnpgm
    '
    Me.TxtFnpgm.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFnpgm.Location = New System.Drawing.Point(244, 10)
    Me.TxtFnpgm.MaxLength = 4
    Me.TxtFnpgm.Name = "TxtFnpgm"
    Me.TxtFnpgm.Size = New System.Drawing.Size(45, 22)
    Me.TxtFnpgm.TabIndex = 4
    '
    'TxtObnbr
    '
    Me.TxtObnbr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObnbr.Location = New System.Drawing.Point(206, 10)
    Me.TxtObnbr.MaxLength = 3
    Me.TxtObnbr.Name = "TxtObnbr"
    Me.TxtObnbr.Size = New System.Drawing.Size(32, 22)
    Me.TxtObnbr.TabIndex = 3
    '
    'TxtDpnbr
    '
    Me.TxtDpnbr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDpnbr.Location = New System.Drawing.Point(155, 10)
    Me.TxtDpnbr.MaxLength = 4
    Me.TxtDpnbr.Name = "TxtDpnbr"
    Me.TxtDpnbr.Size = New System.Drawing.Size(45, 22)
    Me.TxtDpnbr.TabIndex = 2
    '
    'TxtSfund
    '
    Me.TxtSfund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfund.Location = New System.Drawing.Point(117, 10)
    Me.TxtSfund.MaxLength = 3
    Me.TxtSfund.Name = "TxtSfund"
    Me.TxtSfund.Size = New System.Drawing.Size(32, 22)
    Me.TxtSfund.TabIndex = 1
    '
    'TxtFdnbr
    '
    Me.TxtFdnbr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFdnbr.Location = New System.Drawing.Point(79, 10)
    Me.TxtFdnbr.MaxLength = 3
    Me.TxtFdnbr.Name = "TxtFdnbr"
    Me.TxtFdnbr.Size = New System.Drawing.Size(32, 22)
    Me.TxtFdnbr.TabIndex = 0
    '
    'FrmGLA51B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(478, 363)
    Me.ControlBox = False
    Me.Controls.Add(Me.TxtSubfn)
    Me.Controls.Add(Me.TxtFnpgm)
    Me.Controls.Add(Me.TxtObnbr)
    Me.Controls.Add(Me.TxtDpnbr)
    Me.Controls.Add(Me.TxtSfund)
    Me.Controls.Add(Me.TxtFdnbr)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.Controls.Add(Me.BtnNext)
    Me.Controls.Add(Me.BtnFind)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "FrmGLA51B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmGLA51B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    myPRGLMAP = New PRGLMAP.MyData(myDBConnect)
    Call FormatGrid()

  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    Call FormatGrid()
  End Sub

  Public Sub FormatGrid()
    Dim I As Integer
    Call ShowGrid()
    With C1DataGrdList
      .Rebind(True)
      .Columns(0).Caption = "Fund"
      .Splits(0).DisplayColumns(0).Width = 35
      .Columns(1).Caption = "Sfund"
      .Splits(0).DisplayColumns(1).Width = 35
      .Columns(2).Caption = "Dept"
      .Splits(0).DisplayColumns(2).Width = 35
      .Columns(3).Caption = "Obj"
      .Splits(0).DisplayColumns(3).Width = 35
      .Columns(4).Caption = "Func"
      .Splits(0).DisplayColumns(4).Width = 35
      .Columns(5).Caption = "Sfnc"
      .Splits(0).DisplayColumns(5).Width = 35
      .Columns(6).Caption = "Description"
      .Splits(0).DisplayColumns(6).Width = 200
      For I = 7 To 18
        .Splits(0).DisplayColumns(I).Visible = False
      Next
    End With

  End Sub
  Public Sub ShowGrid()
    ds = myPRGLMAP.PosData(MyUtils.CnvSng(TxtFdnbr.Text), MyUtils.CnvSng(TxtSfund.Text), MyUtils.CnvSng(TxtDpnbr.Text),
    MyUtils.CnvSng(TxtObnbr.Text), MyUtils.CnvSng(TxtFnpgm.Text), MyUtils.CnvSng(TxtSubfn.Text), 0)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

  End Sub
  Private Sub FrmGLA51B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGLA51.SbpScreen.Text = "GLA51B"
    MyUtils.CenterForm(Me.ParentForm, Me)

  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
    Dim I As Integer
    I = ds.Tables(0).Rows.Count - 1
    TxtFdnbr.Text = C1DataGrdList.Item(I, 0)
    TxtSfund.Text = C1DataGrdList.Item(I, 1)
    TxtDpnbr.Text = C1DataGrdList.Item(I, 2)
    TxtObnbr.Text = C1DataGrdList.Item(I, 3)
    TxtFnpgm.Text = C1DataGrdList.Item(I, 4)
    TxtSubfn.Text = C1DataGrdList.Item(I, 5)
    FormatGrid()
  End Sub
  Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    MyFrmGLA51C = New FrmGLA51C
    MyFrmGLA51C.MdiParent = Me.ParentForm
    MyFrmGLA51C.WrkFdnbr = C1DataGrdList.Item(C1DataGrdList.Row, 0)
    MyFrmGLA51C.WrkSfund = C1DataGrdList.Item(C1DataGrdList.Row, 1)
    MyFrmGLA51C.WrkDpnbr = C1DataGrdList.Item(C1DataGrdList.Row, 2)
    MyFrmGLA51C.WrkObnbr = C1DataGrdList.Item(C1DataGrdList.Row, 3)
    MyFrmGLA51C.WrkFnpgm = C1DataGrdList.Item(C1DataGrdList.Row, 4)
    MyFrmGLA51C.WrkSubfn = C1DataGrdList.Item(C1DataGrdList.Row, 5)
    MyFrmGLA51C.WrkDesc = C1DataGrdList.Item(C1DataGrdList.Row, 6)
    MyFrmGLA51C.Show()
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub TxtFdnbr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFdnbr.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfund_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSfund.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDpnbr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDpnbr.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtObnbr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtObnbr.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFnpgm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFnpgm.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSubfn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSubfn.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub C1DataGrdList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.Click

  End Sub

  Private Sub TxtFdnbr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFdnbr.TextChanged

  End Sub
End Class
