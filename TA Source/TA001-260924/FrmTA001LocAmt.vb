Public Class FrmTA001LocAmt
  Inherits System.Windows.Forms.Form
  Friend WrkListNo As Integer
  Friend WrkType As String
  Friend WithEvents LblName As System.Windows.Forms.Label
  Friend WithEvents LblList As System.Windows.Forms.Label
 Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Dim ds As DataSet = New DataSet
  Dim myTXLOCAL As TXLOCAL.myData


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
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTA001LocAmt))
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LblName = New System.Windows.Forms.Label()
    Me.LblList = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LblName
    '
    Me.LblName.BackColor = System.Drawing.SystemColors.Control
    Me.LblName.Location = New System.Drawing.Point(111, 3)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(216, 16)
    Me.LblName.TabIndex = 170
    '
    'LblList
    '
    Me.LblList.BackColor = System.Drawing.SystemColors.Control
    Me.LblList.Location = New System.Drawing.Point(57, 3)
    Me.LblList.Name = "LblList"
    Me.LblList.Size = New System.Drawing.Size(48, 16)
    Me.LblList.TabIndex = 165
    '
    'Label8
    '
    Me.Label8.BackColor = System.Drawing.SystemColors.Control
    Me.Label8.Location = New System.Drawing.Point(12, 3)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(36, 12)
    Me.Label8.TabIndex = 163
    Me.Label8.Text = "List #"
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColSelect = False
    Me.C1DataGrdList.AllowRowSelect = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AllowUpdate = False
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(12, 22)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.MeasurementDevice = C1.Win.C1TrueDBGrid.PrintInfo.MeasurementDeviceEnum.Screen
    Me.C1DataGrdList.PrintInfo.MeasurementPrinterName = Nothing
    Me.C1DataGrdList.RecordSelectors = False
    Me.C1DataGrdList.Size = New System.Drawing.Size(168, 120)
    Me.C1DataGrdList.TabIndex = 171
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    '
    'FrmTA001LocAmt
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(335, 153)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.Controls.Add(Me.LblName)
    Me.Controls.Add(Me.LblList)
    Me.Controls.Add(Me.Label8)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA001LocAmt"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Local Benefit Detail"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmTA001LocAmt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    myTXLOCAL = New TXLOCAL.mydata(MyDBConnect)
    MyFrmTA001.TBarAttach.Enabled = False
    LblList.Text = WrkListNo
    LblName.Text = MyFrmTA001RE.TxtName.Text
    BuildDS()
    CreateGrid()
 End Sub
  Private Sub FrmTA001LocAmt_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTA001.TBarAttach.Enabled = True
    MyFrmTA001RE.Show()
  End Sub
  Private Sub FrmTA001LocAmt_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA001.SbpScreen.Text = "TA001LocAmt"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Year", Type.GetType("System.Int16"))
      .Columns.Add("Code", Type.GetType("System.String"))
      .Columns.Add("Amount", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
End Sub
  Private Sub CreateGrid()
    Dim ds2 As DataSet = New DataSet
    Dim myDr As Data.DataRow
    Dim I As Integer

    ds2 = myTXLOCAL.GetViewbyList(WrkListNo, MyGLYear, WrkType, 100)
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      myDr = ds.Tables(0).NewRow
      myDr("Year") = ds2.Tables(0).Rows(I).Item("year")
      myDr("Code") = ds2.Tables(0).Rows(I).Item("bencde")
      myDr("Amount") = ds2.Tables(0).Rows(I).Item("benamt")
      ds.Tables(0).Rows.Add(myDr)
    Next
    If ds.Tables(0).Rows.Count = 0 Then
      ds2 = myTXLOCAL.GetViewbyList(WrkListNo, MyGLYear - 1, WrkType, 100)
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        myDr = ds.Tables(0).NewRow
        myDr("Year") = ds2.Tables(0).Rows(I).Item("year")
        myDr("Code") = ds2.Tables(0).Rows(I).Item("bencde")
        myDr("Amount") = ds2.Tables(0).Rows(I).Item("benamt")
        ds.Tables(0).Rows.Add(myDr)
      Next
    End If

    With C1DataGrdList
      .DataSource = ds.Tables(0)
      .Refresh()
      .Columns(0).Caption = "Year"
      .Splits(0).DisplayColumns(0).Width = 40
      .Columns(1).Caption = "Code"
      .Splits(0).DisplayColumns(1).Width = 40
      .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
      .Columns(2).Caption = "Amount"
      .Splits(0).DisplayColumns(2).Width = 60
    End With
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
End Class






