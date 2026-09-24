Public Class FrmTXA091
  Inherits System.Windows.Forms.Form
  Dim myTBATCH As TBATCH.MyData
  Dim myTBATCHL1 As TBATCHL1.MyData
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
  Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTXA091))
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColSelect = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AllowUpdate = False
    Me.C1DataGrdList.AlternatingRows = True
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(8, 7)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.Size = New System.Drawing.Size(574, 268)
    Me.C1DataGrdList.TabIndex = 8
    Me.ToolTip1.SetToolTip(Me.C1DataGrdList, "Yellow = Open Batch, Pink = AS400 Batch")
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    '
    'FrmTXA091
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(594, 282)
    Me.ControlBox = False
    Me.Controls.Add(Me.C1DataGrdList)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Name = "FrmTXA091"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Collections - Drawer"
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmTXA091_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTBATCH = New TBATCH.MyData(myDBConnect)
    myTBATCHL1 = New TBATCHL1.MyData(myDBConnect)
    Call FormatGrid()
    With MyAppSettings
      MyPrinterLandscape = False
      If .PrinterOrient = "L" Then
        MyPrinterLandscape = True
      End If
      MyCheckSort = .CheckSort
      If MyAppSettings.ValidateModel = "" And Not MyInquiryMode Then
        MyFrmSettings = New FrmSettings
        MyFrmSettings.ShowDialog()
      End If
    End With
  End Sub
  Public Sub FormatGrid()

    Call ShowGrid()

    With C1DataGrdList
      .Rebind(True)
      .FetchRowStyles = True
      .Columns(0).ValueItems.Values.Clear()
      .Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("A", "AS400"))
      .Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("P", "PC"))
      .Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("R", "AS400"))
      .Columns(0).ValueItems.Translate = True
      .Columns(0).Caption = "System"
      .Splits(0).DisplayColumns(0).Width = 50
      .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
      .Columns(1).Caption = "Batch"
      .Splits(0).DisplayColumns(1).Width = 40
      .Columns(2).Caption = "Default"
      .Columns(2).ValueItems.Values.Clear()
      .Columns(2).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("01", "Refund"))
      .Columns(2).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("02", "Adjust"))
      .Columns(2).ValueItems.Translate = True
      .Splits(0).DisplayColumns(2).Width = 50
      .Columns(3).Caption = "Rec Date"
      .Splits(0).DisplayColumns(3).Width = 70
      .Columns(4).Caption = "Int Date"
      .Splits(0).DisplayColumns(4).Width = 70
      .Splits(0).DisplayColumns(5).Visible = False 'Printer
      .Columns(6).ValueItems.Values.Clear()
      .Columns(6).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("N", "No"))
      .Columns(6).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("Y", "Yes"))
      .Columns(6).ValueItems.Translate = True
      .Columns(6).Caption = "Validate"
      .Splits(0).DisplayColumns(6).Width = 50
      .Splits(0).DisplayColumns(6).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
      .Columns(7).Caption = "User"
      .Splits(0).DisplayColumns(7).Width = 75
      .Splits(0).DisplayColumns(8).Visible = False
      .Columns(9).ValueItems.Values.Clear()
      .Columns(9).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("O", "Open"))
      .Columns(9).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("C", "Closed"))
      .Columns(9).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("P", "Posting"))
      .Columns(9).ValueItems.Translate = True
      .Columns(9).Caption = "Status"
      .Splits(0).DisplayColumns(9).Width = 40
      .Splits(0).DisplayColumns(9).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
      .Columns(10).Caption = "Drawer Total"
      .Splits(0).DisplayColumns(10).Width = 75
      .Columns(10).NumberFormat = "Fixed"
    End With

  End Sub
  Public Sub ShowGrid()
    ds.Clear()
    ds = Nothing

    If s_full Or s_post Then
      ds = myTBATCHL1.GetAllData_MDY(String.Empty)
    Else
      ds = myTBATCHL1.GetAllData_MDY(Mid(MyUserID, 1, 10))
    End If
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()
    myTBATCH.CloseFile()

  End Sub

  Private Sub FrmTXA091_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA09.Text = "Cash Register"
    MyBatchNo = 0
    MyFrmTXA09.SbpScreen.Text = "TXA091"
    MyFrmTXA09.TBarView.Enabled = True
    MyFrmTXA09.TBarSettings.Enabled = True
    With MyFrmTXA09
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub C1DataGrdList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    Dim WrkCancel As Boolean

    MyBatchNo = C1DataGrdList.Item(C1DataGrdList.Row, 1)
    myTBATCH.GetOneRecordP(MyBatch, MyBatchNo)
    If myTBATCH.RecordNotFound Then
      MsgBox("Batch no longer exists", MsgBoxStyle.Information, "Batch not available")
      myTBATCH.CloseFile()
      Exit Sub
    End If

    If myTBATCH._KBTCHC <> "P" Then
      MsgBox("This is not a PC Batch", MsgBoxStyle.Exclamation, "Batch not compatible")
      Exit Sub
    End If

    If myTBATCH._KBSTAT = "O" Then
      MsgBox("Batch is already open", MsgBoxStyle.Exclamation, "Open Batch not available")
      Exit Sub
    End If

    If myTBATCH._KBSTAT = "P" Then
      MsgBox("Batch must be reposted", MsgBoxStyle.Exclamation, "Partially posted Batch cannot be opened")
      Exit Sub
    End If

    WrkCancel = OpenBatch()
    If WrkCancel Then
      MsgBox("Batch is already open or no longer exists", MsgBoxStyle.Information, "Batch not available")
      Exit Sub
    End If

    MyReceiptDate = C1DataGrdList.Item(C1DataGrdList.Row, 3)
    MyInterestDate = C1DataGrdList.Item(C1DataGrdList.Row, 4)

    MyFrmTXA09.TBarNew.Enabled = False
    MyFrmTXA09.TBarChange.Enabled = False
    MyFrmTXA09.TBarDelete.Enabled = False
    MyFrmTXA094 = New FrmTXA094
    MyFrmTXA094.MdiParent = Me.ParentForm
    MyFrmTXA094.Show()
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Function OpenBatch() As Boolean
    Dim Cancel As Boolean

    MyValidation = False
    Cancel = False
    myTBATCH.GetOneRecordP(MyBatch, MyBatchNo)
    If myTBATCH.RecordNotFound Then
      myTBATCH.CloseFile()
      Return True
    End If

    With myTBATCH
      MyRefundBatch = False
      If ._KBTCHT = "01" Then
        MyRefundBatch = True
      End If
      If ._KVALID = "O" Then
        Return True
      End If
      ._KBSTAT = "O"
      If ._KVALID = "Y" Then
        MyValidation = True
      End If
    End With
    myTBATCH.UpdateOneRecordP()
    Return False

  End Function

  Public Sub ViewBatch()
    MyFrmTXA09View = New FrmTXA09View
    MyFrmTXA09View.MdiParent = MyFrmTXA091.ParentForm
    MyFrmTXA09View.WrkBatch = C1DataGrdList.Item(C1DataGrdList.Row, 0)
    MyFrmTXA09View.WrkBatchNo = C1DataGrdList.Item(C1DataGrdList.Row, 1)
    MyFrmTXA09View.WrkBackScreen = MyFrmTXA09.SbpScreen.Text
    MyFrmTXA09View.Show()
    '    MyFrmTXA09View = Nothing
    MyFrmTXA091.Hide()
  End Sub


  Private Sub C1DataGrdList_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles C1DataGrdList.FetchRowStyle
    If C1DataGrdList.Columns("kbstat").CellValue(e.Row) = "O" Then
      e.CellStyle.BackColor = System.Drawing.Color.Yellow
    End If

    If C1DataGrdList.Columns("kbtchc").CellValue(e.Row) = "R" Then
      e.CellStyle.BackColor = System.Drawing.Color.Pink
    End If

    If C1DataGrdList.Columns("kbstat").CellValue(e.Row) = "P" Then
      e.CellStyle.BackColor = System.Drawing.Color.Red
    End If
  End Sub

  Private Sub C1DataGrdList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.Click

  End Sub
  Private Sub FrmTXA091_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    'Memory Cleanup
    myTBATCH.CloseFile()
    myTBATCH = Nothing
    MyFrmTXA091 = Nothing
  End Sub
End Class






