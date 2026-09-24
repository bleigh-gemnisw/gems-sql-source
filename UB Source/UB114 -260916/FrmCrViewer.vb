Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Public wrkds As DataSet
  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument

  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpReport As System.Windows.Forms.TabPage
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpTotals As System.Windows.Forms.TabPage
  Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer

  Public Sub New()
    MyBase.New()
    InitializeComponent()
  End Sub

  Private Sub InitializeComponent()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TpReport = New System.Windows.Forms.TabPage()
    Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpTotals = New System.Windows.Forms.TabPage()
    Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabControl1.SuspendLayout()
    Me.TpReport.SuspendLayout()
    Me.TpTotals.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TabControl1.Controls.Add(Me.TpReport)
    Me.TabControl1.Controls.Add(Me.TpTotals)
    Me.TabControl1.Location = New System.Drawing.Point(0, 0)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(1008, 729)
    Me.TabControl1.TabIndex = 0
    '
    'TpReport
    '
    Me.TpReport.Controls.Add(Me.Crv1)
    Me.TpReport.Location = New System.Drawing.Point(4, 22)
    Me.TpReport.Name = "TpReport"
    Me.TpReport.Padding = New System.Windows.Forms.Padding(3)
    Me.TpReport.Size = New System.Drawing.Size(1000, 703)
    Me.TpReport.TabIndex = 0
    Me.TpReport.Text = "Main Report"
    Me.TpReport.UseVisualStyleBackColor = True
    '
    'Crv1
    '
    Me.Crv1.ActiveViewIndex = -1
    Me.Crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv1.Cursor = System.Windows.Forms.Cursors.Default
    Me.Crv1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Crv1.Location = New System.Drawing.Point(3, 3)
    Me.Crv1.Name = "Crv1"
    Me.Crv1.Size = New System.Drawing.Size(994, 697)
    Me.Crv1.TabIndex = 0
    Me.Crv1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
    '
    'TpTotals
    '
    Me.TpTotals.Controls.Add(Me.Crv2)
    Me.TpTotals.Location = New System.Drawing.Point(4, 22)
    Me.TpTotals.Name = "TpTotals"
    Me.TpTotals.Padding = New System.Windows.Forms.Padding(3)
    Me.TpTotals.Size = New System.Drawing.Size(1000, 703)
    Me.TpTotals.TabIndex = 1
    Me.TpTotals.Text = "Totals"
    Me.TpTotals.UseVisualStyleBackColor = True
    '
    'Crv2
    '
    Me.Crv2.ActiveViewIndex = -1
    Me.Crv2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv2.Cursor = System.Windows.Forms.Cursors.Default
    Me.Crv2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Crv2.Location = New System.Drawing.Point(3, 3)
    Me.Crv2.Name = "Crv2"
    Me.Crv2.Size = New System.Drawing.Size(994, 697)
    Me.Crv2.TabIndex = 0
    Me.Crv2.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
    '
    'FrmCrViewer
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(1008, 729)
    Me.Controls.Add(Me.TabControl1)
    Me.Name = "FrmCrViewer"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Report Viewer"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    Me.TabControl1.ResumeLayout(False)
    Me.TpReport.ResumeLayout(False)
    Me.TpTotals.ResumeLayout(False)
    Me.ResumeLayout(False)
  End Sub

  Private Sub FrmCrViewer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    RunReport1()
    RunReport2()
  End Sub

  Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    myreport.Close()
    myreport.Dispose()
    myreport2.Close()
    myreport2.Dispose()
  End Sub

  Private Sub RunReport1()
    Dim ReportPath As String

    ReportPath = MyUtils.GetReportPath("PrtUB114.rpt", myTOWN._TOWNBR)
    With myreport
      .Load(ReportPath)
      .SetDataSource(wrkds)
      .SetParameterValue("myreportTitle", "Customer Meter/Deduct - Latest Readings")
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
      .Zoom(90)
    End With
  End Sub

  Private Sub RunReport2()
    Dim ReportPath As String

    ReportPath = MyUtils.GetReportPath("PrtUB114Tot.rpt", myTOWN._TOWNBR)
    With myreport2
      .Load(ReportPath)
      .SetDataSource(wrkds)
      .SetParameterValue("myreportTitle", "Customer Meter/Deduct - Latest Readings Totals")
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
      .Zoom(90)
    End With
  End Sub
End Class
