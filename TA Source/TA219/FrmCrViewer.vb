Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport4 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport5 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim WrkMargin As CrystalDecisions.Shared.PageMargins
  Friend wrkds As DataSet = New DataSet
  Friend wrkdsFarm As DataSet = New DataSet
  Friend wrkdsForest As DataSet = New DataSet
  Friend wrkdsOpen As DataSet = New DataSet
  Friend WithEvents TabCtl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabAll As System.Windows.Forms.TabPage
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TabTotals As System.Windows.Forms.TabPage
  Friend WithEvents CrvTot As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TabFarm As System.Windows.Forms.TabPage
  Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TabForest As System.Windows.Forms.TabPage
  Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TabOpen As System.Windows.Forms.TabPage
  Friend WithEvents Crv4 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend wrkdsTot As DataSet = New DataSet


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
  Friend WithEvents Cr1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.TabCtl1 = New System.Windows.Forms.TabControl
Me.TabAll = New System.Windows.Forms.TabPage
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabTotals = New System.Windows.Forms.TabPage
Me.CrvTot = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabFarm = New System.Windows.Forms.TabPage
Me.TabForest = New System.Windows.Forms.TabPage
Me.TabOpen = New System.Windows.Forms.TabPage
Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.Crv4 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabCtl1.SuspendLayout()
Me.TabAll.SuspendLayout()
Me.TabTotals.SuspendLayout()
Me.TabFarm.SuspendLayout()
Me.TabForest.SuspendLayout()
Me.TabOpen.SuspendLayout()
Me.SuspendLayout()
'
'TabCtl1
'
Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabCtl1.Controls.Add(Me.TabAll)
Me.TabCtl1.Controls.Add(Me.TabFarm)
Me.TabCtl1.Controls.Add(Me.TabForest)
Me.TabCtl1.Controls.Add(Me.TabOpen)
Me.TabCtl1.Controls.Add(Me.TabTotals)
Me.TabCtl1.Location = New System.Drawing.Point(4, 3)
Me.TabCtl1.Name = "TabCtl1"
Me.TabCtl1.SelectedIndex = 0
Me.TabCtl1.Size = New System.Drawing.Size(656, 380)
Me.TabCtl1.TabIndex = 1
'
'TabAll
'
Me.TabAll.Controls.Add(Me.Crv1)
Me.TabAll.Location = New System.Drawing.Point(4, 22)
Me.TabAll.Name = "TabAll"
Me.TabAll.Size = New System.Drawing.Size(648, 354)
Me.TabAll.TabIndex = 0
Me.TabAll.Text = "All"
Me.TabAll.UseVisualStyleBackColor = True
'
'Crv1
'
Me.Crv1.ActiveViewIndex = -1
Me.Crv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.Crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Crv1.DisplayToolbar = False
Me.Crv1.Location = New System.Drawing.Point(8, 8)
Me.Crv1.Name = "Crv1"
Me.Crv1.SelectionFormula = ""
Me.Crv1.Size = New System.Drawing.Size(632, 344)
Me.Crv1.TabIndex = 1
Me.Crv1.ViewTimeSelectionFormula = ""
'
'TabTotals
'
Me.TabTotals.Controls.Add(Me.CrvTot)
Me.TabTotals.Location = New System.Drawing.Point(4, 22)
Me.TabTotals.Name = "TabTotals"
Me.TabTotals.Size = New System.Drawing.Size(648, 354)
Me.TabTotals.TabIndex = 1
Me.TabTotals.Text = "Totals"
Me.TabTotals.UseVisualStyleBackColor = True
'
'CrvTot
'
Me.CrvTot.ActiveViewIndex = -1
Me.CrvTot.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.CrvTot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.CrvTot.DisplayStatusBar = False
Me.CrvTot.DisplayToolbar = False
Me.CrvTot.Location = New System.Drawing.Point(8, 5)
Me.CrvTot.Name = "CrvTot"
Me.CrvTot.SelectionFormula = ""
Me.CrvTot.Size = New System.Drawing.Size(632, 344)
Me.CrvTot.TabIndex = 2
Me.CrvTot.ViewTimeSelectionFormula = ""
'
'TabFarm
'
Me.TabFarm.Controls.Add(Me.Crv2)
Me.TabFarm.Location = New System.Drawing.Point(4, 22)
Me.TabFarm.Name = "TabFarm"
Me.TabFarm.Size = New System.Drawing.Size(648, 354)
Me.TabFarm.TabIndex = 2
Me.TabFarm.Text = "Farm"
Me.TabFarm.UseVisualStyleBackColor = True
'
'TabForest
'
Me.TabForest.Controls.Add(Me.Crv3)
Me.TabForest.Location = New System.Drawing.Point(4, 22)
Me.TabForest.Name = "TabForest"
Me.TabForest.Size = New System.Drawing.Size(648, 354)
Me.TabForest.TabIndex = 3
Me.TabForest.Text = "Forest"
Me.TabForest.UseVisualStyleBackColor = True
'
'TabOpen
'
Me.TabOpen.Controls.Add(Me.Crv4)
Me.TabOpen.Location = New System.Drawing.Point(4, 22)
Me.TabOpen.Name = "TabOpen"
Me.TabOpen.Size = New System.Drawing.Size(648, 354)
Me.TabOpen.TabIndex = 4
Me.TabOpen.Text = "Open Space"
Me.TabOpen.UseVisualStyleBackColor = True
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
Me.Crv2.Location = New System.Drawing.Point(8, 5)
Me.Crv2.Name = "Crv2"
Me.Crv2.SelectionFormula = ""
Me.Crv2.Size = New System.Drawing.Size(632, 344)
Me.Crv2.TabIndex = 2
Me.Crv2.ViewTimeSelectionFormula = ""
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
Me.Crv3.Location = New System.Drawing.Point(8, 5)
Me.Crv3.Name = "Crv3"
Me.Crv3.SelectionFormula = ""
Me.Crv3.Size = New System.Drawing.Size(632, 344)
Me.Crv3.TabIndex = 2
Me.Crv3.ViewTimeSelectionFormula = ""
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
Me.Crv4.Location = New System.Drawing.Point(8, 5)
Me.Crv4.Name = "Crv4"
Me.Crv4.SelectionFormula = ""
Me.Crv4.Size = New System.Drawing.Size(632, 344)
Me.Crv4.TabIndex = 2
Me.Crv4.ViewTimeSelectionFormula = ""
'
'FrmCrViewer
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(664, 386)
Me.Controls.Add(Me.TabCtl1)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmCrViewer"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
Me.Text = "CrViewer"
Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
Me.TabCtl1.ResumeLayout(False)
Me.TabAll.ResumeLayout(False)
Me.TabTotals.ResumeLayout(False)
Me.TabFarm.ResumeLayout(False)
Me.TabForest.ResumeLayout(False)
Me.TabOpen.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    With WrkMargin
      .leftMargin = 500
      .rightMargin = 150
      .topMargin = 250
      .bottomMargin = 150
    End With
    RunReport1()
    RunReport2()
    RunReport3()
    RunReport4()
    RunReportTot()
 End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport.Close()
  myreport.Dispose()
  myreport2.Close()
  myreport2.Dispose()
  myreport3.Close()
  myreport3.Dispose()
  myreport4.Close()
  myreport4.Dispose()
  myreport5.Close()
  myreport5.Dispose()
End Sub

  Private Sub RunReport1()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTA219.rpt", myTOWN._TOWNBR)
   With myreport
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      .PrintOptions.ApplyPageMargins(WrkMargin)
    End If
    .SetDataSource(wrkds)
    .SetParameterValue("myreportTitle", "Public Act 490")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
	 End With
   With Crv1
     .DisplayToolbar = True
     .ShowGroupTreeButton = False
     .ShowCloseButton = False
     .ShowCopyButton = False
     .ShowRefreshButton = False
     .ShowParameterPanelButton = False
     .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
     .ReportSource = myreport
     .Zoom(75)
   End With

  End Sub
  Private Sub RunReport2()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTA219.rpt", myTOWN._TOWNBR)
   With myreport2
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      .PrintOptions.ApplyPageMargins(WrkMargin)
    End If
    .SetDataSource(wrkdsFarm)
    .SetParameterValue("myreportTitle", "Public Act 490 (Farm Only)")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
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
  Private Sub RunReport3()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTA219.rpt", myTOWN._TOWNBR)
   With myreport3
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      .PrintOptions.ApplyPageMargins(WrkMargin)
    End If
    .SetDataSource(wrkdsForest)
    .SetParameterValue("myreportTitle", "Public Act 490 (Forest Only)")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
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
  Private Sub RunReport4()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTA219.rpt", myTOWN._TOWNBR)
   With myreport4
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      .PrintOptions.ApplyPageMargins(WrkMargin)
    End If
    .SetDataSource(wrkdsOpen)
    .SetParameterValue("myreportTitle", "Public Act 490 (Open Space Only)")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
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
  Private Sub RunReportTot()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTA219Tot.rpt", myTOWN._TOWNBR)
   With myreport5
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      .PrintOptions.ApplyPageMargins(WrkMargin)
    End If
    .SetDataSource(wrkdsTot)
    .SetParameterValue("myreportTitle", "Public Act 490 Totals")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
	 End With
   With CrvTot
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
End Class






