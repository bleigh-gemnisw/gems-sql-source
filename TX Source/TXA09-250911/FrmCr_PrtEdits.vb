Public Class FrmCr_PrtEdits
  Inherits System.Windows.Forms.Form
  Dim myreportQ As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreportS As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreportT As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreportV As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreportW As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreportY As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreportZ As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreportZB As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreportVoid As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myTBATCH As TBATCH.myData
  Friend Wrkds As DataSet
  Friend WrkdsChk As DataSet
  Friend WrkdsVoid As DataSet
  Friend WithEvents TabPg8 As System.Windows.Forms.TabPage
  Friend WithEvents Crv8 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WrkPost As Boolean

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
  Friend WithEvents TabCtl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabPg1 As System.Windows.Forms.TabPage
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TabPg2 As System.Windows.Forms.TabPage
  Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TabPg3 As System.Windows.Forms.TabPage
  Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TabPg4 As System.Windows.Forms.TabPage
  Friend WithEvents Crv4 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TabPg5 As System.Windows.Forms.TabPage
  Friend WithEvents Crv5 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TabPg6 As System.Windows.Forms.TabPage
  Friend WithEvents Crv6 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TabPg7 As System.Windows.Forms.TabPage
  Friend WithEvents Crv7 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents PrtDialog As System.Windows.Forms.PrintDialog
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.TabCtl1 = New System.Windows.Forms.TabControl
    Me.TabPg1 = New System.Windows.Forms.TabPage
    Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
    Me.TabPg2 = New System.Windows.Forms.TabPage
    Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
    Me.TabPg3 = New System.Windows.Forms.TabPage
    Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
    Me.TabPg4 = New System.Windows.Forms.TabPage
    Me.Crv4 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
    Me.TabPg5 = New System.Windows.Forms.TabPage
    Me.Crv5 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
    Me.TabPg7 = New System.Windows.Forms.TabPage
    Me.Crv7 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
    Me.TabPg8 = New System.Windows.Forms.TabPage
    Me.Crv8 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
    Me.TabPg6 = New System.Windows.Forms.TabPage
    Me.Crv6 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
    Me.PrtDialog = New System.Windows.Forms.PrintDialog
    Me.TabCtl1.SuspendLayout()
    Me.TabPg1.SuspendLayout()
    Me.TabPg2.SuspendLayout()
    Me.TabPg3.SuspendLayout()
    Me.TabPg4.SuspendLayout()
    Me.TabPg5.SuspendLayout()
    Me.TabPg7.SuspendLayout()
    Me.TabPg8.SuspendLayout()
    Me.TabPg6.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabCtl1
    '
    Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabCtl1.Controls.Add(Me.TabPg1)
    Me.TabCtl1.Controls.Add(Me.TabPg2)
    Me.TabCtl1.Controls.Add(Me.TabPg3)
    Me.TabCtl1.Controls.Add(Me.TabPg4)
    Me.TabCtl1.Controls.Add(Me.TabPg5)
    Me.TabCtl1.Controls.Add(Me.TabPg7)
    Me.TabCtl1.Controls.Add(Me.TabPg8)
    Me.TabCtl1.Controls.Add(Me.TabPg6)
    Me.TabCtl1.Location = New System.Drawing.Point(0, 8)
    Me.TabCtl1.Name = "TabCtl1"
    Me.TabCtl1.SelectedIndex = 0
    Me.TabCtl1.Size = New System.Drawing.Size(712, 344)
    Me.TabCtl1.TabIndex = 0
    '
    'TabPg1
    '
    Me.TabPg1.Controls.Add(Me.Crv1)
    Me.TabPg1.Location = New System.Drawing.Point(4, 22)
    Me.TabPg1.Name = "TabPg1"
    Me.TabPg1.Size = New System.Drawing.Size(704, 318)
    Me.TabPg1.TabIndex = 0
    Me.TabPg1.Text = "Detail in Seq Order"
    Me.TabPg1.UseVisualStyleBackColor = True
    '
    'Crv1
    '
    Me.Crv1.ActiveViewIndex = -1
    Me.Crv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv1.DisplayStatusBar = False
    Me.Crv1.DisplayToolbar = False
    Me.Crv1.Location = New System.Drawing.Point(8, 8)
    Me.Crv1.Name = "Crv1"
    Me.Crv1.SelectionFormula = ""
    Me.Crv1.Size = New System.Drawing.Size(688, 304)
    Me.Crv1.TabIndex = 2
    Me.Crv1.ViewTimeSelectionFormula = ""
    '
    'TabPg2
    '
    Me.TabPg2.Controls.Add(Me.Crv2)
    Me.TabPg2.Location = New System.Drawing.Point(4, 22)
    Me.TabPg2.Name = "TabPg2"
    Me.TabPg2.Size = New System.Drawing.Size(704, 318)
    Me.TabPg2.TabIndex = 1
    Me.TabPg2.Text = "Detail by Year/Type/Dist"
    Me.TabPg2.UseVisualStyleBackColor = True
    '
    'Crv2
    '
    Me.Crv2.ActiveViewIndex = -1
    Me.Crv2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv2.DisplayStatusBar = False
    Me.Crv2.DisplayToolbar = False
    Me.Crv2.Location = New System.Drawing.Point(8, 8)
    Me.Crv2.Name = "Crv2"
    Me.Crv2.SelectionFormula = ""
    Me.Crv2.Size = New System.Drawing.Size(688, 304)
    Me.Crv2.TabIndex = 3
    Me.Crv2.ViewTimeSelectionFormula = ""
    '
    'TabPg3
    '
    Me.TabPg3.Controls.Add(Me.Crv3)
    Me.TabPg3.Location = New System.Drawing.Point(4, 22)
    Me.TabPg3.Name = "TabPg3"
    Me.TabPg3.Size = New System.Drawing.Size(704, 318)
    Me.TabPg3.TabIndex = 2
    Me.TabPg3.Text = "Totals by Year/Type/Dist"
    Me.TabPg3.UseVisualStyleBackColor = True
    '
    'Crv3
    '
    Me.Crv3.ActiveViewIndex = -1
    Me.Crv3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv3.DisplayStatusBar = False
    Me.Crv3.DisplayToolbar = False
    Me.Crv3.Location = New System.Drawing.Point(8, 7)
    Me.Crv3.Name = "Crv3"
    Me.Crv3.SelectionFormula = ""
    Me.Crv3.Size = New System.Drawing.Size(688, 304)
    Me.Crv3.TabIndex = 4
    Me.Crv3.ViewTimeSelectionFormula = ""
    '
    'TabPg4
    '
    Me.TabPg4.Controls.Add(Me.Crv4)
    Me.TabPg4.Location = New System.Drawing.Point(4, 22)
    Me.TabPg4.Name = "TabPg4"
    Me.TabPg4.Size = New System.Drawing.Size(704, 318)
    Me.TabPg4.TabIndex = 3
    Me.TabPg4.Text = "Totals by Type"
    Me.TabPg4.UseVisualStyleBackColor = True
    '
    'Crv4
    '
    Me.Crv4.ActiveViewIndex = -1
    Me.Crv4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv4.DisplayStatusBar = False
    Me.Crv4.DisplayToolbar = False
    Me.Crv4.Location = New System.Drawing.Point(8, 7)
    Me.Crv4.Name = "Crv4"
    Me.Crv4.SelectionFormula = ""
    Me.Crv4.Size = New System.Drawing.Size(688, 304)
    Me.Crv4.TabIndex = 5
    Me.Crv4.ViewTimeSelectionFormula = ""
    '
    'TabPg5
    '
    Me.TabPg5.Controls.Add(Me.Crv5)
    Me.TabPg5.Location = New System.Drawing.Point(4, 22)
    Me.TabPg5.Name = "TabPg5"
    Me.TabPg5.Size = New System.Drawing.Size(704, 318)
    Me.TabPg5.TabIndex = 4
    Me.TabPg5.Text = "Check Deposits"
    Me.TabPg5.UseVisualStyleBackColor = True
    '
    'Crv5
    '
    Me.Crv5.ActiveViewIndex = -1
    Me.Crv5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv5.DisplayStatusBar = False
    Me.Crv5.DisplayToolbar = False
    Me.Crv5.Location = New System.Drawing.Point(8, 7)
    Me.Crv5.Name = "Crv5"
    Me.Crv5.SelectionFormula = ""
    Me.Crv5.Size = New System.Drawing.Size(688, 304)
    Me.Crv5.TabIndex = 6
    Me.Crv5.ViewTimeSelectionFormula = ""
    '
    'TabPg7
    '
    Me.TabPg7.Controls.Add(Me.Crv7)
    Me.TabPg7.Location = New System.Drawing.Point(4, 22)
    Me.TabPg7.Name = "TabPg7"
    Me.TabPg7.Size = New System.Drawing.Size(704, 318)
    Me.TabPg7.TabIndex = 6
    Me.TabPg7.Text = "Check Detail"
    Me.TabPg7.UseVisualStyleBackColor = True
    '
    'Crv7
    '
    Me.Crv7.ActiveViewIndex = -1
    Me.Crv7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv7.DisplayStatusBar = False
    Me.Crv7.DisplayToolbar = False
    Me.Crv7.Location = New System.Drawing.Point(8, 7)
    Me.Crv7.Name = "Crv7"
    Me.Crv7.SelectionFormula = ""
    Me.Crv7.Size = New System.Drawing.Size(688, 304)
    Me.Crv7.TabIndex = 7
    Me.Crv7.ViewTimeSelectionFormula = ""
    '
    'TabPg8
    '
    Me.TabPg8.Controls.Add(Me.Crv8)
    Me.TabPg8.Location = New System.Drawing.Point(4, 22)
    Me.TabPg8.Name = "TabPg8"
    Me.TabPg8.Size = New System.Drawing.Size(704, 318)
    Me.TabPg8.TabIndex = 7
    Me.TabPg8.Text = "Fees"
    Me.TabPg8.UseVisualStyleBackColor = True
    '
    'Crv8
    '
    Me.Crv8.ActiveViewIndex = -1
    Me.Crv8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv8.DisplayStatusBar = False
    Me.Crv8.DisplayToolbar = False
    Me.Crv8.Location = New System.Drawing.Point(8, 7)
    Me.Crv8.Name = "Crv8"
    Me.Crv8.SelectionFormula = ""
    Me.Crv8.Size = New System.Drawing.Size(688, 304)
    Me.Crv8.TabIndex = 3
    Me.Crv8.ViewTimeSelectionFormula = ""
    '
    'TabPg6
    '
    Me.TabPg6.Controls.Add(Me.Crv6)
    Me.TabPg6.Location = New System.Drawing.Point(4, 22)
    Me.TabPg6.Name = "TabPg6"
    Me.TabPg6.Size = New System.Drawing.Size(704, 318)
    Me.TabPg6.TabIndex = 5
    Me.TabPg6.Text = "Voided"
    Me.TabPg6.UseVisualStyleBackColor = True
    '
    'Crv6
    '
    Me.Crv6.ActiveViewIndex = -1
    Me.Crv6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv6.DisplayStatusBar = False
    Me.Crv6.DisplayToolbar = False
    Me.Crv6.Location = New System.Drawing.Point(8, 7)
    Me.Crv6.Name = "Crv6"
    Me.Crv6.SelectionFormula = ""
    Me.Crv6.Size = New System.Drawing.Size(688, 305)
    Me.Crv6.TabIndex = 7
    Me.Crv6.ViewTimeSelectionFormula = ""
    '
    'PrtDialog
    '
    Me.PrtDialog.UseEXDialog = True
    '
    'FrmCr_PrtEdits
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(720, 358)
    Me.Controls.Add(Me.TabCtl1)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmCr_PrtEdits"
    Me.Text = "Print Batch Edits (Press Enter to print all)"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    Me.TabCtl1.ResumeLayout(False)
    Me.TabPg1.ResumeLayout(False)
    Me.TabPg2.ResumeLayout(False)
    Me.TabPg3.ResumeLayout(False)
    Me.TabPg4.ResumeLayout(False)
    Me.TabPg5.ResumeLayout(False)
    Me.TabPg7.ResumeLayout(False)
    Me.TabPg8.ResumeLayout(False)
    Me.TabPg6.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region
  Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    myreportQ.Close()
    myreportQ.Dispose()
    myreportS.Close()
    myreportS.Dispose()
    myreportT.Close()
    myreportT.Dispose()
    myreportV.Close()
    myreportV.Dispose()
    myreportW.Close()
    myreportW.Dispose()
    myreportY.Close()
    myreportY.Dispose()
    myreportZ.Close()
    myreportZ.Dispose()
    myreportZB.Close()
    myreportZB.Dispose()
    myreportVoid.Close()
    myreportVoid.Dispose()
  End Sub
  Private Sub RptEditBySeqNo()
    Dim ReportName As String
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportName = "PrtTXA09Q.rpt"
    ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)

    With myreportQ
      .Load(ReportPath)
      If MyPrinterLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      End If
      .SetDataSource(Wrkds)
      .SetParameterValue("Post", WrkPost)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("StartCash", myTBATCH._KBCASH)
      .SetParameterValue("EndCash", myTBATCH._KBEND)
      .SetParameterValue("MyBatchNo", MyBatchNo)
      .SetParameterValue("MyDrawerOwner", Trim(myTBATCH._KUSER))
      .SetParameterValue("MyInterestDate", MyInterestDate)
      .SetParameterValue("MyReceiptDate", MyReceiptDate)
    End With
    With Crv1
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreportQ
      .Zoom(75)
    End With

  End Sub
  Private Sub RptEditByYearType()
    Dim ReportName As String
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportName = "PrtTXA09T.rpt"
    ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)

    With myreportT
      .Load(ReportPath)
      If MyPrinterLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      End If
      .SetDataSource(Wrkds)
      .SetParameterValue("Post", WrkPost)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyBatchNo", MyBatchNo)
      .SetParameterValue("MyDrawerOwner", Trim(myTBATCH._KUSER))
      .SetParameterValue("MyInterestDate", MyInterestDate)
      .SetParameterValue("MyReceiptDate", MyReceiptDate)
    End With
    With Crv2
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreportT
      .Zoom(75)
    End With

  End Sub
  Private Sub RptTotalsByYearType()
    Dim ReportName As String
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportName = "PrtTXA09V.rpt"
    ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)

    With myreportV
      .Load(ReportPath)
      If MyPrinterLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      End If
      .SetDataSource(Wrkds)
      .SetParameterValue("Post", WrkPost)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyBatchNo", MyBatchNo)
      .SetParameterValue("MyDrawerOwner", Trim(myTBATCH._KUSER))
      .SetParameterValue("MyInterestDate", MyInterestDate)
      .SetParameterValue("MyReceiptDate", MyReceiptDate)
    End With
    With Crv3
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreportV
      .Zoom(75)
    End With

  End Sub
  Private Sub RptTotalsByType()
    Dim ReportName As String
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportName = "PrtTXA09W.rpt"
    ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)

    With myreportW
      .Load(ReportPath)
      If MyPrinterLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      End If
      .SetDataSource(Wrkds)
      .SetParameterValue("Post", WrkPost)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyBatchNo", MyBatchNo)
      .SetParameterValue("MyDrawerOwner", Trim(myTBATCH._KUSER))
      .SetParameterValue("MyInterestDate", MyInterestDate)
      .SetParameterValue("MyReceiptDate", MyReceiptDate)
    End With
    With Crv4
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreportW
      .Zoom(75)
    End With

  End Sub
  Private Sub RptChecks()
    Dim ReportName As String
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportName = "PrtTXA09Z.rpt"
    ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)

    With myreportZ
      .Load(ReportPath)
      If MyPrinterLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      End If
      .SetDataSource(WrkdsChk)
      .SetParameterValue("Post", WrkPost)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyBatchNo", MyBatchNo)
      .SetParameterValue("MyDrawerOwner", Trim(myTBATCH._KUSER))
    End With
    With Crv5
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreportZ
      .Zoom(75)
    End With

  End Sub
  Private Sub RptChecksB()
    Dim ReportName As String
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportName = "PrtTXA09ZB.rpt"
    ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)

    With myreportZB
      .Load(ReportPath)
      If MyPrinterLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      End If
      .SetDataSource(WrkdsChk)
      .SetParameterValue("Post", WrkPost)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyBatchNo", MyBatchNo)
      .SetParameterValue("MyDrawerOwner", Trim(myTBATCH._KUSER))
    End With
    With Crv5
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreportZB
      .Zoom(75)
    End With

  End Sub
  Private Sub RptChecksDetail()
    Dim ReportName As String
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportName = "PrtTXA09Y.rpt"
    ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)

    With myreportY
      .Load(ReportPath)
      If MyPrinterLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      End If
      .SetDataSource(WrkdsChk)
      .SetParameterValue("Post", WrkPost)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyBatchNo", MyBatchNo)
      .SetParameterValue("MyDrawerOwner", Trim(myTBATCH._KUSER))
      .SetParameterValue("MyCheckSort", "By " & MyCheckSort)
    End With
    With Crv7
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreportY
      .Zoom(75)
    End With

  End Sub
  Private Sub RptFees()
    Dim ReportName As String
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportName = "PrtTXA09S.rpt"
    ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)

    With myreportS
      .Load(ReportPath)
      If MyPrinterLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      End If
      .SetDataSource(Wrkds)
      .SetParameterValue("Post", WrkPost)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyBatchNo", MyBatchNo)
      .SetParameterValue("MyDrawerOwner", Trim(myTBATCH._KUSER))
    End With
    With Crv8
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreportS
      .Zoom(75)
    End With

  End Sub

  Private Sub RptVoided()
    Dim ReportName As String
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportName = "PrtTXA09Void.rpt"
    ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)

    With myreportVoid
      .Load(ReportPath)
      If MyPrinterLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      End If
      .SetDataSource(WrkdsVoid)
      .SetParameterValue("Post", WrkPost)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyBatchNo", MyBatchNo)
      .SetParameterValue("MyDrawerOwner", Trim(myTBATCH._KUSER))
      .SetParameterValue("MyInterestDate", MyInterestDate)
      .SetParameterValue("MyReceiptDate", MyReceiptDate)
    End With
    With Crv6
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreportVoid
      .Zoom(75)
    End With

  End Sub
  Private Sub FrmCr_PrtEdits_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    Me.Dispose()
  End Sub
  Private Sub FrmCr_PrtEdits_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If WrkPost Then
      Me.Text = "** POSTING RUN ** - " & Me.Text
    End If

    GetTBATCH()

    RptEditBySeqNo()
    RptEditByYearType()
    RptTotalsByYearType()
    RptTotalsByType()
    If MyCheckSort = "Sequence" Then
      RptChecksB()
    Else
      RptChecks()
    End If
    RptChecksDetail()
    RptFees()
    RptVoided()
  End Sub
  Private Sub FrmCr_PrtEdits_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Dim ReportName As String
    Dim ReportPath As String
    Dim WrkPrinter As String

    If e.KeyCode = Keys.Enter Then

      PrtDialog.PrinterSettings = New Printing.PrinterSettings
      Dim result As DialogResult = PrtDialog.ShowDialog()
      WrkPrinter = String.Empty
      If (result = Windows.Forms.DialogResult.OK) Then
        WrkPrinter = PrtDialog.PrinterSettings.PrinterName()
      Else
        Exit Sub
      End If

      With myreportQ
        ReportName = "PrtTXA09Q.rpt"
        ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
        .Load(ReportPath)
        If MyPrinterLandscape Then
          .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
          .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        End If
        .PrintOptions.PrinterDuplex = PrtDialog.PrinterSettings.Duplex
        .PrintOptions.PrinterName = WrkPrinter
        .PrintToPrinter(1, True, 0, 0)
      End With
      With myreportT
        ReportName = "PrtTXA09T.rpt"
        ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
        .Load(ReportPath)
        If MyPrinterLandscape Then
          .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
          .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        End If
        .PrintOptions.PrinterDuplex = PrtDialog.PrinterSettings.Duplex
        .PrintOptions.PrinterName = WrkPrinter
        .PrintToPrinter(1, True, 0, 0)
      End With
      With myreportV
        ReportName = "PrtTXA09V.rpt"
        ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
        .Load(ReportPath)
        If MyPrinterLandscape Then
          .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
          .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        End If
        .PrintOptions.PrinterDuplex = PrtDialog.PrinterSettings.Duplex
        .PrintOptions.PrinterName = WrkPrinter
        .PrintToPrinter(1, True, 0, 0)
      End With
      With myreportW
        ReportName = "PrtTXA09W.rpt"
        ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
        .Load(ReportPath)
        If MyPrinterLandscape Then
          .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
          .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        End If
        .PrintOptions.PrinterDuplex = PrtDialog.PrinterSettings.Duplex
        .PrintOptions.PrinterName = WrkPrinter
        .PrintToPrinter(1, True, 0, 0)
      End With
      If MyCheckSort = "Sequence" Then
        With myreportZB
          ReportName = "PrtTXA09ZB.rpt"
          ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
          .Load(ReportPath)
          If MyPrinterLandscape Then
            .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
            .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
          End If
          .PrintOptions.PrinterDuplex = PrtDialog.PrinterSettings.Duplex
          .PrintOptions.PrinterName = WrkPrinter
          .PrintToPrinter(1, True, 0, 0)
        End With
      Else
        With myreportZ
          ReportName = "PrtTXA09Z.rpt"
          ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
          .Load(ReportPath)
          If MyPrinterLandscape Then
            .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
            .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
          End If
          .PrintOptions.PrinterDuplex = PrtDialog.PrinterSettings.Duplex
          .PrintOptions.PrinterName = WrkPrinter
          .PrintToPrinter(1, True, 0, 0)
        End With
      End If
      With myreportY
        ReportName = "PrtTXA09Y.rpt"
        ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
        .Load(ReportPath)
        If MyPrinterLandscape Then
          .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
          .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        End If
        .PrintOptions.PrinterDuplex = PrtDialog.PrinterSettings.Duplex
        .PrintOptions.PrinterName = WrkPrinter
        .PrintToPrinter(1, True, 0, 0)
      End With
      With myreportS
        ReportName = "PrtTXA09S.rpt"
        ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
        .Load(ReportPath)
        If MyPrinterLandscape Then
          .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
          .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        End If
        .PrintOptions.PrinterDuplex = PrtDialog.PrinterSettings.Duplex
        .PrintOptions.PrinterName = WrkPrinter
        .PrintToPrinter(1, True, 0, 0)
      End With
      With myreportVoid
        ReportName = "PrtTXA09Void.rpt"
        ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
        .Load(ReportPath)
        If MyPrinterLandscape Then
          .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
          .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        End If
        .PrintOptions.PrinterDuplex = PrtDialog.PrinterSettings.Duplex
        .PrintOptions.PrinterName = WrkPrinter
        .PrintToPrinter(1, True, 0, 0)
      End With
    End If
  End Sub

  Private Sub FrmCr_PrtEdits_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    'Memory Cleanup
    myTBATCH.CloseFile()
    myreportQ = Nothing
    myreportS = Nothing
    myreportT = Nothing
    myreportV = Nothing
    myreportW = Nothing
    myreportY = Nothing
    myreportZ = Nothing
    myreportZB = Nothing
    myreportVoid = Nothing
    MyFrmCr_PrtEdits = Nothing
  End Sub
  Private Sub GetTBATCH()
    myTBATCH = New TBATCH.mydata(MyDBConnect)

    myTBATCH.GetOneRecordP(MyBatch, MyBatchNo)
  End Sub

End Class
