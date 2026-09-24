Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreportTot As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend Wrkds As DataSet
  Friend Wrkdistphase As String
  Friend Wrksort As String
  Friend WrkUBType As String
  Friend WrkFamily As String
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpReport As System.Windows.Forms.TabPage
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpTotals As System.Windows.Forms.TabPage
  Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Dim WrkBillType As String
  Dim WrkAmtHdr1 As String
  Dim WrkAmtHdr2 As String
  Dim WrkAmtHdr3 As String
  Dim WrkAmtHdr4 As String
  Dim WrkAmtHdr5 As String
  Dim WrkAmtHdr6 As String

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
    Me.TabControl1 = New System.Windows.Forms.TabControl
    Me.TpTotals = New System.Windows.Forms.TabPage
    Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
    Me.TpReport = New System.Windows.Forms.TabPage
    Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
    Me.TabControl1.SuspendLayout()
    Me.TpTotals.SuspendLayout()
    Me.TpReport.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabControl1.Controls.Add(Me.TpReport)
    Me.TabControl1.Controls.Add(Me.TpTotals)
    Me.TabControl1.Location = New System.Drawing.Point(10, 5)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(644, 376)
    Me.TabControl1.TabIndex = 2
    '
    'TpTotals
    '
    Me.TpTotals.Controls.Add(Me.Crv2)
    Me.TpTotals.Location = New System.Drawing.Point(4, 22)
    Me.TpTotals.Name = "TpTotals"
    Me.TpTotals.Size = New System.Drawing.Size(636, 350)
    Me.TpTotals.TabIndex = 0
    Me.TpTotals.Text = "Totals"
    Me.TpTotals.UseVisualStyleBackColor = True
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
    Me.Crv2.Location = New System.Drawing.Point(0, 0)
    Me.Crv2.Name = "Crv2"
    Me.Crv2.SelectionFormula = ""
    Me.Crv2.Size = New System.Drawing.Size(640, 352)
    Me.Crv2.TabIndex = 1
    Me.Crv2.ViewTimeSelectionFormula = ""
    '
    'TpReport
    '
    Me.TpReport.Controls.Add(Me.Crv1)
    Me.TpReport.Location = New System.Drawing.Point(4, 22)
    Me.TpReport.Name = "TpReport"
    Me.TpReport.Size = New System.Drawing.Size(636, 350)
    Me.TpReport.TabIndex = 2
    Me.TpReport.Text = "Report"
    Me.TpReport.UseVisualStyleBackColor = True
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
    Me.Crv1.Location = New System.Drawing.Point(-2, -1)
    Me.Crv1.Name = "Crv1"
    Me.Crv1.SelectionFormula = ""
    Me.Crv1.Size = New System.Drawing.Size(640, 352)
    Me.Crv1.TabIndex = 2
    Me.Crv1.ViewTimeSelectionFormula = ""
    '
    'FrmCrViewer
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(664, 386)
    Me.Controls.Add(Me.TabControl1)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmCrViewer"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "CrViewer"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    Me.TabControl1.ResumeLayout(False)
    Me.TpTotals.ResumeLayout(False)
    Me.TpReport.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    WrkBillType = GetUTTypeDesc(WrkUBType)
    Select Case WrkFamily
      Case "A"
        WrkAmtHdr1 = "Unit"
        WrkAmtHdr2 = "PropVal"
        WrkAmtHdr3 = "Footage"
        WrkAmtHdr4 = "Acreage"
        WrkAmtHdr5 = "Other"
        WrkAmtHdr6 = ""
      Case "M"
        WrkAmtHdr1 = "Usage"
        WrkAmtHdr2 = "MinBill"
        WrkAmtHdr3 = "Base"
        WrkAmtHdr4 = "Unit"
        WrkAmtHdr5 = "Markup"
        WrkAmtHdr6 = "EDU"
      Case "U"
        WrkAmtHdr1 = "Unit"
        WrkAmtHdr2 = "Fixt"
        WrkAmtHdr3 = "Extra"
        WrkAmtHdr4 = "Base"
        WrkAmtHdr5 = "Markup"
        WrkAmtHdr6 = "EDU"
    End Select
    RunReport1()
    RunReportTot()
  End Sub
  Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    myreport1.Close()
    myreport1.Dispose()
    myreportTot.Close()
    myreportTot.Dispose()
  End Sub
  Private Sub RunReport1()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtUB230.rpt", myTOWN._TOWNBR)
    With myreport1
      .Load(ReportPath)
      .SetDataSource(Wrkds)
      .SetParameterValue("myreportTitle", WrkBillType & " Billing Breakdown")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MySort", Wrksort)
      .SetParameterValue("Mydistphase", Wrkdistphase)
      .SetParameterValue("MyAmtHdr1", WrkAmtHdr1)
      .SetParameterValue("MyAmtHdr2", WrkAmtHdr2)
      .SetParameterValue("MyAmtHdr3", WrkAmtHdr3)
      .SetParameterValue("MyAmtHdr4", WrkAmtHdr4)
      .SetParameterValue("MyAmtHdr5", WrkAmtHdr5)
      .SetParameterValue("MyAmtHdr6", WrkAmtHdr6)
      .SetParameterValue("MyUserHdr1", MyUserHdr1)
      .SetParameterValue("MyUserHdr2", MyUserHdr2)
      .SetParameterValue("MyUserHdr3", MyUserHdr3)
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
  Private Sub RunReportTot()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtUB230Tot.rpt", myTOWN._TOWNBR)
    With myreportTot
      .Load(ReportPath)
      .SetDataSource(Wrkds)
      .SetParameterValue("myreportTitle", WrkBillType & " Billing Breakdown Totals")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MySort", Wrksort)
      .SetParameterValue("Mydistphase", Wrkdistphase)
      .SetParameterValue("MyAmtHdr1", WrkAmtHdr1)
      .SetParameterValue("MyAmtHdr2", WrkAmtHdr2)
      .SetParameterValue("MyAmtHdr3", WrkAmtHdr3)
      .SetParameterValue("MyAmtHdr4", WrkAmtHdr4)
      .SetParameterValue("MyAmtHdr5", WrkAmtHdr5)
      .SetParameterValue("MyAmtHdr6", WrkAmtHdr6)
      .SetParameterValue("MyUserHdr1", MyUserHdr1)
      .SetParameterValue("MyUserHdr2", MyUserHdr2)
      .SetParameterValue("MyUserHdr3", MyUserHdr3)
    End With
    With Crv2
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreportTot
      .Zoom(75)
    End With
  End Sub
End Class
