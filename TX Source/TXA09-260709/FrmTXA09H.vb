Public Class FrmTXA09H
  Inherits System.Windows.Forms.Form
  Dim myTXHSTLC As TXHSTLC.MyData
  Friend WithEvents Label34 As System.Windows.Forms.Label
  Friend WithEvents DtPckEnd As System.Windows.Forms.DateTimePicker
  Friend WithEvents BtnShow As System.Windows.Forms.Button
  Friend WithEvents TxtRef As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents DtPckStart As System.Windows.Forms.DateTimePicker
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
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTXA09H))
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Me.Label34 = New System.Windows.Forms.Label
    Me.DtPckEnd = New System.Windows.Forms.DateTimePicker
    Me.BtnShow = New System.Windows.Forms.Button
    Me.TxtRef = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.DtPckStart = New System.Windows.Forms.DateTimePicker
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColSelect = False
    Me.C1DataGrdList.AllowRowSelect = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AllowUpdate = False
    Me.C1DataGrdList.AllowUpdateOnBlur = False
    Me.C1DataGrdList.AlternatingRows = True
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FetchRowStyles = True
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(4, 56)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.RecordSelectors = False
    Me.C1DataGrdList.Size = New System.Drawing.Size(773, 280)
    Me.C1DataGrdList.TabIndex = 157
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    '
    'Label34
    '
    Me.Label34.Location = New System.Drawing.Point(191, 30)
    Me.Label34.Name = "Label34"
    Me.Label34.Size = New System.Drawing.Size(75, 18)
    Me.Label34.TabIndex = 165
    Me.Label34.Text = "End Date"
    '
    'DtPckEnd
    '
    Me.DtPckEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckEnd.Location = New System.Drawing.Point(272, 30)
    Me.DtPckEnd.Name = "DtPckEnd"
    Me.DtPckEnd.Size = New System.Drawing.Size(96, 20)
    Me.DtPckEnd.TabIndex = 2
    '
    'BtnShow
    '
    Me.BtnShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnShow.Location = New System.Drawing.Point(374, 10)
    Me.BtnShow.Name = "BtnShow"
    Me.BtnShow.Size = New System.Drawing.Size(43, 24)
    Me.BtnShow.TabIndex = 3
    Me.BtnShow.TabStop = False
    Me.BtnShow.Text = "&Show"
    '
    'TxtRef
    '
    Me.TxtRef.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRef.Location = New System.Drawing.Point(77, 14)
    Me.TxtRef.MaxLength = 10
    Me.TxtRef.Name = "TxtRef"
    Me.TxtRef.Size = New System.Drawing.Size(98, 20)
    Me.TxtRef.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(12, 17)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(59, 19)
    Me.Label1.TabIndex = 168
    Me.Label1.Text = "Check No"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(191, 6)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(62, 18)
    Me.Label2.TabIndex = 170
    Me.Label2.Text = "Start Date"
    '
    'DtPckStart
    '
    Me.DtPckStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckStart.Location = New System.Drawing.Point(259, 4)
    Me.DtPckStart.Name = "DtPckStart"
    Me.DtPckStart.ShowCheckBox = True
    Me.DtPckStart.Size = New System.Drawing.Size(109, 20)
    Me.DtPckStart.TabIndex = 1
    '
    'FrmTXA09H
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(788, 344)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.DtPckStart)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnShow)
    Me.Controls.Add(Me.TxtRef)
    Me.Controls.Add(Me.Label34)
    Me.Controls.Add(Me.DtPckEnd)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXA09H"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Check Payment History (Newest to Oldest date order)"
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTXA09H_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    ds.Clear()
    ds = Nothing

    'Memory Cleanup
    myTXHSTLC.CloseFile()
    myTXHSTLC = Nothing
    MyFrmTXA09Hist.Show()

    MyFrmTXA09H = Nothing
  End Sub

  Private Sub FrmTXA09H_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXHSTLC = New TXHSTLC.MyData(myDBConnect)

    DtPckEnd.Value = Date.Today
    DtPckStart.Value = DateAdd(DateInterval.Year, -2, Date.Today)
  End Sub
  Public Sub FormatGrid()
    ShowGrid()

    With C1DataGrdList
      .Rebind(True)
      .Splits(0).DisplayColumns(0).Visible = False
      .Columns(1).Caption = "List"
      .Splits(0).DisplayColumns(1).Width = 60
      .Columns(2).Caption = "Type"
      .Splits(0).DisplayColumns(2).Width = 40
      .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
      .Columns(3).Caption = "Year"
      .Splits(0).DisplayColumns(3).Width = 50
      .Columns(4).Caption = "Date Paid"
      .Columns(4).NumberFormat = "##/##/####"
      .Splits(0).DisplayColumns(4).Width = 65
      .Splits(0).DisplayColumns(5).Visible = False
      .Columns(6).Caption = "Pmt Amt"
      .Splits(0).DisplayColumns(6).Width = 60
      .Columns(7).Caption = "Interest"
      .Splits(0).DisplayColumns(7).Width = 50
      .Columns(8).Caption = "Fee/Bond"
      .Splits(0).DisplayColumns(8).Width = 50
      .Columns(9).Caption = "Lien"
      .Splits(0).DisplayColumns(9).Width = 40
      .Columns(10).Caption = "Total Amt"
      .Splits(0).DisplayColumns(10).Width = 60
      .Columns(11).Caption = "Adj"
      .Columns(11).ValueItems.Values.Clear()
      .Columns(11).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("A", "Adjust"))
      .Columns(11).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("R", "Refund"))
      .Columns(11).ValueItems.Translate = True
      .Splits(0).DisplayColumns(11).Width = 40
      .Columns(12).Caption = "FeeCd"
      .Splits(0).DisplayColumns(12).Width = 40
      .Columns(13).Caption = "Batch Ty"
      .Columns(13).ValueItems.Values.Clear()
      .Columns(13).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("B", "LockBox"))
      .Columns(13).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("E", "Escrow"))
      .Columns(13).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("G", "Leasing"))
      .Columns(13).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("K", "BankSvc"))
      .Columns(13).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("L", "Liened"))
      .Columns(13).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("P", "PC"))
      .Columns(13).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("R", "Regular"))
      .Columns(13).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("S", "Suspense"))
      .Columns(13).ValueItems.Translate = True
      .Splits(0).DisplayColumns(13).Width = 50
      .Columns(14).Caption = "Batch #"
      .Splits(0).DisplayColumns(14).Width = 50
      .Columns(15).Caption = "Comment"
      .Splits(0).DisplayColumns(15).Width = 130
    End With

  End Sub
  Public Sub ShowGrid()
    Dim WrkAsof As Integer
    Dim WrkCutoff As Integer

    WrkAsof = MyUtils.SetDBDate(DtPckEnd.Value)
    If DtPckStart.Checked Then
      WrkCutoff = MyUtils.SetDBDate(DtPckStart.Value)
    Else
      WrkCutoff = 0
    End If
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    ds = myTXHSTLC.GetViewbyRef(TxtRef.Text, WrkAsof, WrkCutoff)

    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub FrmTXA09H_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA09.SbpScreen.Text = "TXA09H"
    Call MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmTXA09
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
    If TxtRef.Text = String.Empty Then Exit Sub

    FormatGrid()
  End Sub
  Private Sub TxtRef_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRef.KeyPress
    If TxtRef.Text = String.Empty Then Exit Sub

    If Asc(e.KeyChar) = Keys.Return Then
      Call FormatGrid()
    End If
  End Sub

  Private Sub TxtRef_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRef.TextChanged

  End Sub
End Class






