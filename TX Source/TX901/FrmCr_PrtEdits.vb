Public Class FrmCr_PrtEdits
  Inherits System.Windows.Forms.Form
  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport4 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport5 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim WrkMargin As CrystalDecisions.Shared.PageMargins
  Friend Wrkds As DataSet
  Friend WrkPost As Boolean
  Friend WrkPostDate As Date
  Friend WithEvents TpDetailB As System.Windows.Forms.TabPage
  Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpDetailsC As System.Windows.Forms.TabPage
  Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WrkErrors As Boolean

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
  Friend WithEvents TpDetail As System.Windows.Forms.TabPage
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpTotalsYear As System.Windows.Forms.TabPage
  Friend WithEvents TpTotalsType As System.Windows.Forms.TabPage
Friend WithEvents PrtDialog As System.Windows.Forms.PrintDialog
Friend WithEvents Crv4 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents Crv5 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.TabCtl1 = New System.Windows.Forms.TabControl
Me.TpDetail = New System.Windows.Forms.TabPage
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpDetailB = New System.Windows.Forms.TabPage
Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpTotalsYear = New System.Windows.Forms.TabPage
Me.Crv4 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpTotalsType = New System.Windows.Forms.TabPage
Me.Crv5 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.PrtDialog = New System.Windows.Forms.PrintDialog
Me.TpDetailsC = New System.Windows.Forms.TabPage
Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabCtl1.SuspendLayout()
Me.TpDetail.SuspendLayout()
Me.TpDetailB.SuspendLayout()
Me.TpTotalsYear.SuspendLayout()
Me.TpTotalsType.SuspendLayout()
Me.TpDetailsC.SuspendLayout()
Me.SuspendLayout()
'
'TabCtl1
'
Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabCtl1.Controls.Add(Me.TpDetail)
Me.TabCtl1.Controls.Add(Me.TpDetailB)
Me.TabCtl1.Controls.Add(Me.TpDetailsC)
Me.TabCtl1.Controls.Add(Me.TpTotalsYear)
Me.TabCtl1.Controls.Add(Me.TpTotalsType)
Me.TabCtl1.Location = New System.Drawing.Point(0, 8)
Me.TabCtl1.Name = "TabCtl1"
Me.TabCtl1.SelectedIndex = 0
Me.TabCtl1.Size = New System.Drawing.Size(640, 344)
Me.TabCtl1.TabIndex = 0
'
'TpDetail
'
Me.TpDetail.Controls.Add(Me.Crv1)
Me.TpDetail.Location = New System.Drawing.Point(4, 22)
Me.TpDetail.Name = "TpDetail"
Me.TpDetail.Size = New System.Drawing.Size(632, 318)
Me.TpDetail.TabIndex = 0
Me.TpDetail.Text = "Detail in Sequential Order"
Me.TpDetail.UseVisualStyleBackColor = True
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
Me.Crv1.Size = New System.Drawing.Size(616, 304)
Me.Crv1.TabIndex = 2
Me.Crv1.ViewTimeSelectionFormula = ""
'
'TpDetailB
'
Me.TpDetailB.Controls.Add(Me.Crv2)
Me.TpDetailB.Location = New System.Drawing.Point(4, 22)
Me.TpDetailB.Name = "TpDetailB"
Me.TpDetailB.Size = New System.Drawing.Size(632, 318)
Me.TpDetailB.TabIndex = 4
Me.TpDetailB.Text = "Detail in Year/Type/Name Order"
Me.TpDetailB.UseVisualStyleBackColor = True
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
Me.Crv2.Size = New System.Drawing.Size(616, 304)
Me.Crv2.TabIndex = 3
Me.Crv2.ViewTimeSelectionFormula = ""
'
'TpTotalsYear
'
Me.TpTotalsYear.Controls.Add(Me.Crv4)
Me.TpTotalsYear.Location = New System.Drawing.Point(4, 22)
Me.TpTotalsYear.Name = "TpTotalsYear"
Me.TpTotalsYear.Size = New System.Drawing.Size(632, 318)
Me.TpTotalsYear.TabIndex = 2
Me.TpTotalsYear.Text = "Totals by Year/Type"
Me.TpTotalsYear.UseVisualStyleBackColor = True
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
Me.Crv4.Size = New System.Drawing.Size(616, 304)
Me.Crv4.TabIndex = 4
Me.Crv4.ViewTimeSelectionFormula = ""
'
'TpTotalsType
'
Me.TpTotalsType.Controls.Add(Me.Crv5)
Me.TpTotalsType.Location = New System.Drawing.Point(4, 22)
Me.TpTotalsType.Name = "TpTotalsType"
Me.TpTotalsType.Size = New System.Drawing.Size(632, 318)
Me.TpTotalsType.TabIndex = 3
Me.TpTotalsType.Text = "Totals by Type"
Me.TpTotalsType.UseVisualStyleBackColor = True
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
Me.Crv5.Size = New System.Drawing.Size(616, 304)
Me.Crv5.TabIndex = 5
Me.Crv5.ViewTimeSelectionFormula = ""
'
'TpDetailsC
'
Me.TpDetailsC.Controls.Add(Me.Crv3)
Me.TpDetailsC.Location = New System.Drawing.Point(4, 22)
Me.TpDetailsC.Name = "TpDetailsC"
Me.TpDetailsC.Size = New System.Drawing.Size(632, 318)
Me.TpDetailsC.TabIndex = 5
Me.TpDetailsC.Text = "Detail in Name Order"
Me.TpDetailsC.UseVisualStyleBackColor = True
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
Me.Crv3.Size = New System.Drawing.Size(616, 304)
Me.Crv3.TabIndex = 3
Me.Crv3.ViewTimeSelectionFormula = ""
'
'FrmCr_PrtEdits
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(648, 358)
Me.Controls.Add(Me.TabCtl1)
Me.KeyPreview = True
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmCr_PrtEdits"
Me.Text = "Print Batch Edits (Press Enter to print all)"
Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
Me.TabCtl1.ResumeLayout(False)
Me.TpDetail.ResumeLayout(False)
Me.TpDetailB.ResumeLayout(False)
Me.TpTotalsYear.ResumeLayout(False)
Me.TpTotalsType.ResumeLayout(False)
Me.TpDetailsC.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

  Private Sub RptEditBySeqNo()
   Dim ReportPath As String

   ReportPath = MyUtils.GetReportPath("PrtTX9011.rpt", myTOWN._TOWNBR)
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
    .SetParameterValue("PostDate", WrkPostDate)
    .SetParameterValue("Errors", WrkErrors)
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
  Private Sub RptEditByYear()
   Dim ReportPath As String

   ReportPath = MyUtils.GetReportPath("PrtTX9011B.rpt", myTOWN._TOWNBR)
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
    .SetParameterValue("PostDate", WrkPostDate)
    .SetParameterValue("Errors", WrkErrors)
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
  Private Sub RptEditByName()
   Dim ReportPath As String

   ReportPath = MyUtils.GetReportPath("PrtTX9011C.rpt", myTOWN._TOWNBR)
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
    .SetParameterValue("PostDate", WrkPostDate)
    .SetParameterValue("Errors", WrkErrors)
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
  Private Sub RptTotalsByYearType()
   Dim ReportPath As String

   ReportPath = MyUtils.GetReportPath("PrtTX9012.rpt", myTOWN._TOWNBR)
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
    .SetParameterValue("PostDate", WrkPostDate)
    .SetParameterValue("Errors", WrkErrors)
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
  Private Sub RptTotalsByType()
   Dim ReportPath As String

   ReportPath = MyUtils.GetReportPath("PrtTX9013.rpt", myTOWN._TOWNBR)
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
    .SetParameterValue("PostDate", WrkPostDate)
    .SetParameterValue("Errors", WrkErrors)
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
  Private Sub FrmCr_PrtEdits_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    With WrkMargin
      .leftMargin = 500
      .rightMargin = 150
      .topMargin = 250
      .bottomMargin = 150
    End With

    If WrkPost Then
      Me.Text = "** POSTING RUN ** - " & Me.Text
    End If

    RptEditBySeqNo()
    RptEditByYear()
    RptEditByName()
    RptTotalsByYearType()
    RptTotalsByType()
  End Sub
Private Sub FrmCr_PrtEdits_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
Dim WrkPrinter As String

With WrkMargin
  .leftMargin = 500
  .rightMargin = 150
  .topMargin = 250
  .bottomMargin = 150
End With

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
  End Sub

Private Sub FrmCr_PrtEdits_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  myreport1.Close()
  myreport2.Close()
  myreport3.Close()
  myreport4.Close()
  myreport5.Close()
  myreport1.Dispose()
  myreport2.Dispose()
  myreport3.Dispose()
  myreport4.Dispose()
  myreport5.Dispose()
End Sub

Private Sub TabCtl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabCtl1.SelectedIndexChanged

End Sub
End Class






