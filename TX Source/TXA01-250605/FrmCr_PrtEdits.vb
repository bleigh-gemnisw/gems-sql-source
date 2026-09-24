Public Class FrmCr_PrtEdits
  Inherits System.Windows.Forms.Form
  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport4 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport5 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport6 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport7 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim WrkMargin As CrystalDecisions.Shared.PageMargins
  Friend Wrkds As DataSet
  Friend WrkBatchTypeDesc As String
  Friend WrkReceiptDate As Date
  Friend WrkInterestDate As Date
  Friend WrkPost As Boolean
  Friend WithEvents TpTotDistYear As System.Windows.Forms.TabPage
  Friend WithEvents Crv4 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpDistBreak As System.Windows.Forms.TabPage
  Friend WithEvents Crv5 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WrkErrors As Boolean
  Friend WithEvents TpErrors As System.Windows.Forms.TabPage
  Friend WithEvents Crv6 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpName As System.Windows.Forms.TabPage
  Friend WithEvents Crv7 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WrkDistBreakout As Boolean

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
  Friend WithEvents TpSeq As System.Windows.Forms.TabPage
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpTotYearType As System.Windows.Forms.TabPage
  Friend WithEvents TpTotType As System.Windows.Forms.TabPage
  Friend WithEvents PrtDialog As System.Windows.Forms.PrintDialog
  Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.TabCtl1 = New System.Windows.Forms.TabControl()
    Me.TpSeq = New System.Windows.Forms.TabPage()
    Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpTotYearType = New System.Windows.Forms.TabPage()
    Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpTotType = New System.Windows.Forms.TabPage()
    Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpTotDistYear = New System.Windows.Forms.TabPage()
    Me.Crv4 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpDistBreak = New System.Windows.Forms.TabPage()
    Me.Crv5 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpErrors = New System.Windows.Forms.TabPage()
    Me.Crv6 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.PrtDialog = New System.Windows.Forms.PrintDialog()
    Me.TpName = New System.Windows.Forms.TabPage()
    Me.Crv7 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabCtl1.SuspendLayout()
    Me.TpSeq.SuspendLayout()
    Me.TpTotYearType.SuspendLayout()
    Me.TpTotType.SuspendLayout()
    Me.TpTotDistYear.SuspendLayout()
    Me.TpDistBreak.SuspendLayout()
    Me.TpErrors.SuspendLayout()
    Me.TpName.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabCtl1
    '
    Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabCtl1.Controls.Add(Me.TpSeq)
    Me.TabCtl1.Controls.Add(Me.TpName)
    Me.TabCtl1.Controls.Add(Me.TpTotYearType)
    Me.TabCtl1.Controls.Add(Me.TpTotType)
    Me.TabCtl1.Controls.Add(Me.TpTotDistYear)
    Me.TabCtl1.Controls.Add(Me.TpDistBreak)
    Me.TabCtl1.Controls.Add(Me.TpErrors)
    Me.TabCtl1.Location = New System.Drawing.Point(0, 8)
    Me.TabCtl1.Name = "TabCtl1"
    Me.TabCtl1.SelectedIndex = 0
    Me.TabCtl1.Size = New System.Drawing.Size(712, 344)
    Me.TabCtl1.TabIndex = 0
    '
    'TpSeq
    '
    Me.TpSeq.Controls.Add(Me.Crv1)
    Me.TpSeq.Location = New System.Drawing.Point(4, 22)
    Me.TpSeq.Name = "TpSeq"
    Me.TpSeq.Size = New System.Drawing.Size(704, 318)
    Me.TpSeq.TabIndex = 0
    Me.TpSeq.Text = "Detail in Sequential Order"
    Me.TpSeq.UseVisualStyleBackColor = True
    '
    'Crv1
    '
    Me.Crv1.ActiveViewIndex = -1
    Me.Crv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv1.Cursor = System.Windows.Forms.Cursors.Default
    Me.Crv1.DisplayStatusBar = False
    Me.Crv1.DisplayToolbar = False
    Me.Crv1.Location = New System.Drawing.Point(8, 8)
    Me.Crv1.Name = "Crv1"
    Me.Crv1.SelectionFormula = ""
    Me.Crv1.Size = New System.Drawing.Size(688, 304)
    Me.Crv1.TabIndex = 2
    Me.Crv1.ViewTimeSelectionFormula = ""
    '
    'TpTotYearType
    '
    Me.TpTotYearType.Controls.Add(Me.Crv2)
    Me.TpTotYearType.Location = New System.Drawing.Point(4, 22)
    Me.TpTotYearType.Name = "TpTotYearType"
    Me.TpTotYearType.Size = New System.Drawing.Size(687, 318)
    Me.TpTotYearType.TabIndex = 2
    Me.TpTotYearType.Text = "Totals by Year/Type"
    Me.TpTotYearType.UseVisualStyleBackColor = True
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
    Me.Crv2.Location = New System.Drawing.Point(8, 7)
    Me.Crv2.Name = "Crv2"
    Me.Crv2.SelectionFormula = ""
    Me.Crv2.Size = New System.Drawing.Size(671, 304)
    Me.Crv2.TabIndex = 4
    Me.Crv2.ViewTimeSelectionFormula = ""
    '
    'TpTotType
    '
    Me.TpTotType.Controls.Add(Me.Crv3)
    Me.TpTotType.Location = New System.Drawing.Point(4, 22)
    Me.TpTotType.Name = "TpTotType"
    Me.TpTotType.Size = New System.Drawing.Size(687, 318)
    Me.TpTotType.TabIndex = 3
    Me.TpTotType.Text = "Totals by Type"
    Me.TpTotType.UseVisualStyleBackColor = True
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
    Me.Crv3.Size = New System.Drawing.Size(671, 304)
    Me.Crv3.TabIndex = 5
    Me.Crv3.ViewTimeSelectionFormula = ""
    '
    'TpTotDistYear
    '
    Me.TpTotDistYear.Controls.Add(Me.Crv4)
    Me.TpTotDistYear.Location = New System.Drawing.Point(4, 22)
    Me.TpTotDistYear.Name = "TpTotDistYear"
    Me.TpTotDistYear.Size = New System.Drawing.Size(687, 318)
    Me.TpTotDistYear.TabIndex = 4
    Me.TpTotDistYear.Text = "Totals by Dist/Year/Type"
    Me.TpTotDistYear.UseVisualStyleBackColor = True
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
    Me.Crv4.Size = New System.Drawing.Size(671, 304)
    Me.Crv4.TabIndex = 6
    Me.Crv4.ViewTimeSelectionFormula = ""
    '
    'TpDistBreak
    '
    Me.TpDistBreak.Controls.Add(Me.Crv5)
    Me.TpDistBreak.Location = New System.Drawing.Point(4, 22)
    Me.TpDistBreak.Name = "TpDistBreak"
    Me.TpDistBreak.Size = New System.Drawing.Size(687, 318)
    Me.TpDistBreak.TabIndex = 5
    Me.TpDistBreak.Text = "District Breakout Totals"
    Me.TpDistBreak.UseVisualStyleBackColor = True
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
    Me.Crv5.Size = New System.Drawing.Size(671, 304)
    Me.Crv5.TabIndex = 7
    Me.Crv5.ViewTimeSelectionFormula = ""
    '
    'TpErrors
    '
    Me.TpErrors.Controls.Add(Me.Crv6)
    Me.TpErrors.Location = New System.Drawing.Point(4, 22)
    Me.TpErrors.Name = "TpErrors"
    Me.TpErrors.Size = New System.Drawing.Size(687, 318)
    Me.TpErrors.TabIndex = 6
    Me.TpErrors.Text = "Errors"
    Me.TpErrors.UseVisualStyleBackColor = True
    '
    'Crv6
    '
    Me.Crv6.ActiveViewIndex = -1
    Me.Crv6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv6.DisplayToolbar = False
    Me.Crv6.Location = New System.Drawing.Point(8, 7)
    Me.Crv6.Name = "Crv6"
    Me.Crv6.SelectionFormula = ""
    Me.Crv6.Size = New System.Drawing.Size(671, 304)
    Me.Crv6.TabIndex = 8
    Me.Crv6.ViewTimeSelectionFormula = ""
    '
    'TpName
    '
    Me.TpName.Controls.Add(Me.Crv7)
    Me.TpName.Location = New System.Drawing.Point(4, 22)
    Me.TpName.Name = "TpName"
    Me.TpName.Size = New System.Drawing.Size(704, 318)
    Me.TpName.TabIndex = 7
    Me.TpName.Text = "Detail by Name"
    Me.TpName.UseVisualStyleBackColor = True
    '
    'Crv7
    '
    Me.Crv7.ActiveViewIndex = -1
    Me.Crv7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv7.Cursor = System.Windows.Forms.Cursors.Default
    Me.Crv7.DisplayStatusBar = False
    Me.Crv7.DisplayToolbar = False
    Me.Crv7.Location = New System.Drawing.Point(8, 7)
    Me.Crv7.Name = "Crv7"
    Me.Crv7.SelectionFormula = ""
    Me.Crv7.Size = New System.Drawing.Size(688, 304)
    Me.Crv7.TabIndex = 3
    Me.Crv7.ViewTimeSelectionFormula = ""
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
    Me.TpSeq.ResumeLayout(False)
    Me.TpTotYearType.ResumeLayout(False)
    Me.TpTotType.ResumeLayout(False)
    Me.TpTotDistYear.ResumeLayout(False)
    Me.TpDistBreak.ResumeLayout(False)
    Me.TpErrors.ResumeLayout(False)
    Me.TpName.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmCr_PrtEdits_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    With WrkMargin
      .leftMargin = 150
      .rightMargin = 150
      .topMargin = 150
      .bottomMargin = 150
    End With

    If WrkPost Then
      Me.Text = "** POSTING RUN ** - " & Me.Text
    End If

    RptEditBySeqNo()
    RptEditByName()
    RptTotalsByYearType()
    RptTotalsByType()
    RptTotalsByDist()
    If WrkDistBreakout Then
      RptDistrictBreakout()
    Else
      TabCtl1.TabPages.Remove(TpDistBreak)
    End If
    If WrkErrors Then
      RptErrors()
    Else
      TabCtl1.TabPages.Remove(TpErrors)
    End If

  End Sub
  Private Sub FrmCr_PrtEdits_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Dim WrkPrinter As String

    WrkPrinter = ""
    If e.KeyCode = Keys.Enter Then
      PrtDialog.PrinterSettings = New Printing.PrinterSettings
      Dim result As DialogResult = PrtDialog.ShowDialog()
      If (result = Windows.Forms.DialogResult.OK) Then
        WrkPrinter = PrtDialog.PrinterSettings.PrinterName()
      End If

      With myreport1
        If MyReportLandscape Then
          .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
          .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
          .PrintOptions.ApplyPageMargins(WrkMargin)
        End If
        .PrintOptions.PrinterName = WrkPrinter
        .PrintToPrinter(1, True, 0, 0)
      End With
      With myreport2
        If MyReportLandscape Then
          .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
          .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
          .PrintOptions.ApplyPageMargins(WrkMargin)
        End If
        .PrintOptions.PrinterName = WrkPrinter
        .PrintToPrinter(1, True, 0, 0)
      End With
      With myreport3
        If MyReportLandscape Then
          .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
          .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
          .PrintOptions.ApplyPageMargins(WrkMargin)
        End If
        .PrintOptions.PrinterName = WrkPrinter
        .PrintToPrinter(1, True, 0, 0)
      End With
      With myreport4
        If MyReportLandscape Then
          .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
          .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
          .PrintOptions.ApplyPageMargins(WrkMargin)
        End If
        .PrintOptions.PrinterName = WrkPrinter
        .PrintToPrinter(1, True, 0, 0)
      End With
      If WrkDistBreakout Then
        With myreport5
          If MyReportLandscape Then
            .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
            .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
            .PrintOptions.ApplyPageMargins(WrkMargin)
          End If
          .PrintOptions.PrinterName = WrkPrinter
          .PrintToPrinter(1, True, 0, 0)
        End With
      End If
      If WrkErrors Then
        With myreport6
          If MyReportLandscape Then
            .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
            .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
            .PrintOptions.ApplyPageMargins(WrkMargin)
          End If
          .PrintOptions.PrinterName = WrkPrinter
          .PrintToPrinter(1, True, 0, 0)
        End With
      End If
      With myreport7
        If MyReportLandscape Then
          .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
          .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
          .PrintOptions.ApplyPageMargins(WrkMargin)
        End If
        .PrintOptions.PrinterName = WrkPrinter
        .PrintToPrinter(1, True, 0, 0)
      End With
    End If
  End Sub

  Private Sub FrmCr_PrtEdits_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    myreport1.Close()
    myreport2.Close()
    myreport3.Close()
    myreport4.Close()
    myreport5.Close()
    myreport6.Close()
    myreport7.Close()
    myreport1.Dispose()
    myreport2.Dispose()
    myreport3.Dispose()
    myreport4.Dispose()
    myreport5.Dispose()
    myreport6.Dispose()
    myreport7.Dispose()
  End Sub
  Private Sub RptEditBySeqNo()
    Dim ReportPath As String

    ReportPath = MyUtils.GetReportPath("PrtTXA011.rpt", myTOWN._TOWNBR)
    With myreport1
      .Load(ReportPath)
      If MyReportLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        .PrintOptions.ApplyPageMargins(WrkMargin)
      End If
      .SetDataSource(Wrkds)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("Post", WrkPost)
      .SetParameterValue("Errors", WrkErrors)
      .SetParameterValue("MyBatchTypeDesc", WrkBatchTypeDesc)
      .SetParameterValue("MyReceiptDate", WrkReceiptDate)
      .SetParameterValue("MyInterestDate", WrkInterestDate)
    End With
    With Crv1
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreport1
      .Zoom(75)
    End With

  End Sub
  Private Sub RptEditByName()
    Dim ReportPath As String

    ReportPath = MyUtils.GetReportPath("PrtTXA017.rpt", myTOWN._TOWNBR)
    With myreport7
      .Load(ReportPath)
      If MyReportLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        .PrintOptions.ApplyPageMargins(WrkMargin)
      End If
      .SetDataSource(Wrkds)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("Post", WrkPost)
      .SetParameterValue("Errors", WrkErrors)
      .SetParameterValue("MyBatchTypeDesc", WrkBatchTypeDesc)
      .SetParameterValue("MyReceiptDate", WrkReceiptDate)
      .SetParameterValue("MyInterestDate", WrkInterestDate)
    End With
    With Crv7
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreport7
      .Zoom(75)
    End With

  End Sub
  Private Sub RptTotalsByYearType()
    Dim ReportPath As String

    ReportPath = MyUtils.GetReportPath("PrtTXA012.rpt", myTOWN._TOWNBR)
    With myreport2
      .Load(ReportPath)
      If MyReportLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        .PrintOptions.ApplyPageMargins(WrkMargin)
      End If
      .SetDataSource(Wrkds)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("Post", WrkPost)
      .SetParameterValue("Errors", WrkErrors)
      .SetParameterValue("MyBatchTypeDesc", WrkBatchTypeDesc)
      .SetParameterValue("MyReceiptDate", WrkReceiptDate)
      .SetParameterValue("MyInterestDate", WrkInterestDate)
    End With
    With Crv2
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreport2
      .Zoom(75)
    End With
  End Sub
  Private Sub RptTotalsByType()
    Dim ReportPath As String

    ReportPath = MyUtils.GetReportPath("PrtTXA013.rpt", myTOWN._TOWNBR)
    With myreport3
      .Load(ReportPath)
      If MyReportLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        .PrintOptions.ApplyPageMargins(WrkMargin)
      End If
      .SetDataSource(Wrkds)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("Post", WrkPost)
      .SetParameterValue("Errors", WrkErrors)
      .SetParameterValue("MyBatchTypeDesc", WrkBatchTypeDesc)
      .SetParameterValue("MyReceiptDate", WrkReceiptDate)
      .SetParameterValue("MyInterestDate", WrkInterestDate)
    End With
    With Crv3
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreport3
      .Zoom(75)
    End With
  End Sub
  Private Sub RptTotalsByDist()
    Dim ReportPath As String

    ReportPath = MyUtils.GetReportPath("PrtTXA014.rpt", myTOWN._TOWNBR)
    With myreport4
      .Load(ReportPath)
      If MyReportLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        .PrintOptions.ApplyPageMargins(WrkMargin)
      End If
      .SetDataSource(Wrkds)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("Post", WrkPost)
      .SetParameterValue("Errors", WrkErrors)
      .SetParameterValue("MyBatchTypeDesc", WrkBatchTypeDesc)
      .SetParameterValue("MyReceiptDate", WrkReceiptDate)
      .SetParameterValue("MyInterestDate", WrkInterestDate)
    End With
    With Crv4
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreport4
      .Zoom(75)
    End With
  End Sub
  Private Sub RptDistrictBreakout()
    Dim ReportPath As String

    ReportPath = MyUtils.GetReportPath("PrtTXA015.rpt", myTOWN._TOWNBR)
    With myreport5
      .Load(ReportPath)
      If MyReportLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        .PrintOptions.ApplyPageMargins(WrkMargin)
      End If
      .SetDataSource(Wrkds)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("Post", WrkPost)
      .SetParameterValue("Errors", WrkErrors)
      .SetParameterValue("MyBatchTypeDesc", WrkBatchTypeDesc)
      .SetParameterValue("MyReceiptDate", WrkReceiptDate)
      .SetParameterValue("MyInterestDate", WrkInterestDate)
    End With
    With Crv5
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreport5
      .Zoom(75)
    End With
  End Sub
  Private Sub RptErrors()
    Dim ReportPath As String

    ReportPath = MyUtils.GetReportPath("PrtTXA016.rpt", myTOWN._TOWNBR)
    With myreport6
      .Load(ReportPath)
      If MyReportLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        .PrintOptions.ApplyPageMargins(WrkMargin)
      End If
      .SetDataSource(Wrkds)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyBatchTypeDesc", WrkBatchTypeDesc)
      .SetParameterValue("MyReceiptDate", WrkReceiptDate)
      .SetParameterValue("MyInterestDate", WrkInterestDate)
    End With
    With Crv6
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreport6
      .Zoom(75)
    End With
  End Sub
End Class






