Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport4 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport5 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport6 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport7 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport8 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim WrkMargin As CrystalDecisions.Shared.PageMargins
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpBoth As System.Windows.Forms.TabPage
  Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpState As System.Windows.Forms.TabPage
  Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpLocal As System.Windows.Forms.TabPage
  Friend WithEvents Crv4 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpTotals As System.Windows.Forms.TabPage
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpSplits As System.Windows.Forms.TabPage
  Friend WithEvents Crv5 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend Wrkds As DataSet
  Friend WrkdsState As DataSet
  Friend WrkdsLocal As DataSet
  Friend WithEvents TpErrors As System.Windows.Forms.TabPage
  Friend WithEvents Crv6 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WrkdsSplit As DataSet
  Friend WrkdsElderly As DataSet
  Friend WrkdsErrors As DataSet
  Friend WrkLocalCd1 As String
  Friend WrkLocalCd2 As String
  Friend WrkLocalCd3 As String
  Friend WrkLocalCd4 As String
  Friend WrkLocalCd5 As String
  Friend WithEvents TpDetail As System.Windows.Forms.TabPage
  Friend WithEvents TpElderly As TabPage
  Friend WithEvents Crv8 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents Crv7 As CrystalDecisions.Windows.Forms.CrystalReportViewer
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
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TpTotals = New System.Windows.Forms.TabPage()
    Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpBoth = New System.Windows.Forms.TabPage()
    Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpState = New System.Windows.Forms.TabPage()
    Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpLocal = New System.Windows.Forms.TabPage()
    Me.Crv4 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpSplits = New System.Windows.Forms.TabPage()
    Me.Crv5 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpDetail = New System.Windows.Forms.TabPage()
    Me.Crv7 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpErrors = New System.Windows.Forms.TabPage()
    Me.Crv6 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpElderly = New System.Windows.Forms.TabPage()
    Me.Crv8 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabControl1.SuspendLayout()
    Me.TpTotals.SuspendLayout()
    Me.TpBoth.SuspendLayout()
    Me.TpState.SuspendLayout()
    Me.TpLocal.SuspendLayout()
    Me.TpSplits.SuspendLayout()
    Me.TpDetail.SuspendLayout()
    Me.TpErrors.SuspendLayout()
    Me.TpElderly.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabControl1.Controls.Add(Me.TpTotals)
    Me.TabControl1.Controls.Add(Me.TpBoth)
    Me.TabControl1.Controls.Add(Me.TpState)
    Me.TabControl1.Controls.Add(Me.TpLocal)
    Me.TabControl1.Controls.Add(Me.TpSplits)
    Me.TabControl1.Controls.Add(Me.TpDetail)
    Me.TabControl1.Controls.Add(Me.TpElderly)
    Me.TabControl1.Controls.Add(Me.TpErrors)
    Me.TabControl1.Location = New System.Drawing.Point(10, 5)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(644, 376)
    Me.TabControl1.TabIndex = 3
    '
    'TpTotals
    '
    Me.TpTotals.Controls.Add(Me.Crv1)
    Me.TpTotals.Location = New System.Drawing.Point(4, 22)
    Me.TpTotals.Name = "TpTotals"
    Me.TpTotals.Size = New System.Drawing.Size(636, 350)
    Me.TpTotals.TabIndex = 4
    Me.TpTotals.Text = "Totals"
    Me.TpTotals.UseVisualStyleBackColor = True
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
    Me.Crv1.Location = New System.Drawing.Point(-2, -1)
    Me.Crv1.Name = "Crv1"
    Me.Crv1.SelectionFormula = ""
    Me.Crv1.Size = New System.Drawing.Size(640, 352)
    Me.Crv1.TabIndex = 3
    Me.Crv1.ViewTimeSelectionFormula = ""
    '
    'TpBoth
    '
    Me.TpBoth.Controls.Add(Me.Crv2)
    Me.TpBoth.Location = New System.Drawing.Point(4, 22)
    Me.TpBoth.Name = "TpBoth"
    Me.TpBoth.Size = New System.Drawing.Size(636, 350)
    Me.TpBoth.TabIndex = 2
    Me.TpBoth.Text = "Both State & Local"
    Me.TpBoth.UseVisualStyleBackColor = True
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
    Me.Crv2.Location = New System.Drawing.Point(-2, -1)
    Me.Crv2.Name = "Crv2"
    Me.Crv2.SelectionFormula = ""
    Me.Crv2.Size = New System.Drawing.Size(640, 352)
    Me.Crv2.TabIndex = 2
    Me.Crv2.ViewTimeSelectionFormula = ""
    '
    'TpState
    '
    Me.TpState.Controls.Add(Me.Crv3)
    Me.TpState.Location = New System.Drawing.Point(4, 22)
    Me.TpState.Name = "TpState"
    Me.TpState.Size = New System.Drawing.Size(636, 350)
    Me.TpState.TabIndex = 0
    Me.TpState.Text = "State Only"
    Me.TpState.UseVisualStyleBackColor = True
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
    Me.Crv3.Location = New System.Drawing.Point(0, 0)
    Me.Crv3.Name = "Crv3"
    Me.Crv3.SelectionFormula = ""
    Me.Crv3.Size = New System.Drawing.Size(640, 352)
    Me.Crv3.TabIndex = 1
    Me.Crv3.ViewTimeSelectionFormula = ""
    '
    'TpLocal
    '
    Me.TpLocal.Controls.Add(Me.Crv4)
    Me.TpLocal.Location = New System.Drawing.Point(4, 22)
    Me.TpLocal.Name = "TpLocal"
    Me.TpLocal.Size = New System.Drawing.Size(636, 350)
    Me.TpLocal.TabIndex = 3
    Me.TpLocal.Text = "Local Only"
    Me.TpLocal.UseVisualStyleBackColor = True
    '
    'Crv4
    '
    Me.Crv4.ActiveViewIndex = -1
    Me.Crv4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv4.Cursor = System.Windows.Forms.Cursors.Default
    Me.Crv4.DisplayStatusBar = False
    Me.Crv4.DisplayToolbar = False
    Me.Crv4.Location = New System.Drawing.Point(-2, -1)
    Me.Crv4.Name = "Crv4"
    Me.Crv4.SelectionFormula = ""
    Me.Crv4.Size = New System.Drawing.Size(640, 352)
    Me.Crv4.TabIndex = 2
    Me.Crv4.ViewTimeSelectionFormula = ""
    '
    'TpSplits
    '
    Me.TpSplits.Controls.Add(Me.Crv5)
    Me.TpSplits.Location = New System.Drawing.Point(4, 22)
    Me.TpSplits.Name = "TpSplits"
    Me.TpSplits.Size = New System.Drawing.Size(636, 350)
    Me.TpSplits.TabIndex = 5
    Me.TpSplits.Text = "Splits"
    Me.TpSplits.UseVisualStyleBackColor = True
    '
    'Crv5
    '
    Me.Crv5.ActiveViewIndex = -1
    Me.Crv5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv5.Cursor = System.Windows.Forms.Cursors.Default
    Me.Crv5.DisplayStatusBar = False
    Me.Crv5.DisplayToolbar = False
    Me.Crv5.Location = New System.Drawing.Point(-2, -1)
    Me.Crv5.Name = "Crv5"
    Me.Crv5.SelectionFormula = ""
    Me.Crv5.Size = New System.Drawing.Size(640, 352)
    Me.Crv5.TabIndex = 3
    Me.Crv5.ViewTimeSelectionFormula = ""
    '
    'TpDetail
    '
    Me.TpDetail.Controls.Add(Me.Crv7)
    Me.TpDetail.Location = New System.Drawing.Point(4, 22)
    Me.TpDetail.Name = "TpDetail"
    Me.TpDetail.Size = New System.Drawing.Size(636, 350)
    Me.TpDetail.TabIndex = 7
    Me.TpDetail.Text = "State & Local Detail"
    Me.TpDetail.UseVisualStyleBackColor = True
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
    Me.Crv7.Location = New System.Drawing.Point(-2, -1)
    Me.Crv7.Name = "Crv7"
    Me.Crv7.SelectionFormula = ""
    Me.Crv7.Size = New System.Drawing.Size(640, 352)
    Me.Crv7.TabIndex = 4
    Me.Crv7.ViewTimeSelectionFormula = ""
    '
    'TpErrors
    '
    Me.TpErrors.Controls.Add(Me.Crv6)
    Me.TpErrors.Location = New System.Drawing.Point(4, 22)
    Me.TpErrors.Name = "TpErrors"
    Me.TpErrors.Size = New System.Drawing.Size(636, 350)
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
    Me.Crv6.Cursor = System.Windows.Forms.Cursors.Default
    Me.Crv6.DisplayStatusBar = False
    Me.Crv6.DisplayToolbar = False
    Me.Crv6.Location = New System.Drawing.Point(-2, -1)
    Me.Crv6.Name = "Crv6"
    Me.Crv6.SelectionFormula = ""
    Me.Crv6.Size = New System.Drawing.Size(640, 352)
    Me.Crv6.TabIndex = 4
    Me.Crv6.ViewTimeSelectionFormula = ""
    '
    'TpElderly
    '
    Me.TpElderly.Controls.Add(Me.Crv8)
    Me.TpElderly.Location = New System.Drawing.Point(4, 22)
    Me.TpElderly.Name = "TpElderly"
    Me.TpElderly.Size = New System.Drawing.Size(636, 350)
    Me.TpElderly.TabIndex = 8
    Me.TpElderly.Text = "Elderly (Rate Book)"
    Me.TpElderly.UseVisualStyleBackColor = True
    '
    'Crv8
    '
    Me.Crv8.ActiveViewIndex = -1
    Me.Crv8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv8.Cursor = System.Windows.Forms.Cursors.Default
    Me.Crv8.DisplayStatusBar = False
    Me.Crv8.DisplayToolbar = False
    Me.Crv8.Location = New System.Drawing.Point(-2, -1)
    Me.Crv8.Name = "Crv8"
    Me.Crv8.SelectionFormula = ""
    Me.Crv8.Size = New System.Drawing.Size(640, 352)
    Me.Crv8.TabIndex = 5
    Me.Crv8.ViewTimeSelectionFormula = ""
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
    Me.TpBoth.ResumeLayout(False)
    Me.TpState.ResumeLayout(False)
    Me.TpLocal.ResumeLayout(False)
    Me.TpSplits.ResumeLayout(False)
    Me.TpDetail.ResumeLayout(False)
    Me.TpErrors.ResumeLayout(False)
    Me.TpElderly.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub CrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    If WrkdsSplit.Tables(0).Rows.Count > 0 Then
      RunReport5()
    Else
      TabControl1.TabPages.Remove(TpSplits)
    End If
    If WrkdsErrors.Tables(0).Rows.Count > 0 Then
      RunReport6()
    Else
      TabControl1.TabPages.Remove(TpErrors)
    End If
    RunReport7()
    RunReport8()
  End Sub
  Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    myreport1.Close()
    myreport1.Dispose()
    myreport2.Close()
    myreport2.Dispose()
    myreport3.Close()
    myreport3.Dispose()
    myreport4.Close()
    myreport4.Dispose()
    myreport5.Close()
    myreport5.Dispose()
    myreport6.Close()
    myreport6.Dispose()
    myreport7.Close()
    myreport7.Dispose()
    myreport8.Close()
    myreport8.Dispose()
  End Sub
  Private Sub RunReport1()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTA208Tot.rpt", myTOWN._TOWNBR)
    With myreport1
      .Load(ReportPath)
      If MyReportLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        .PrintOptions.ApplyPageMargins(WrkMargin)
      End If
      .SetDataSource(Wrkds)
      .SetParameterValue("myreportTitle", "State & Local Tax Credit Totals")
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyYear", MyUtils.CnvSng(MyFrmTA208B.TxtGLYear.Text))
      .SetParameterValue("MyMillRate", MrateMillrt * 1000)
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
  Private Sub RunReport2()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTA208.rpt", myTOWN._TOWNBR)
    With myreport2
      .Load(ReportPath)
      If MyReportLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        .PrintOptions.ApplyPageMargins(WrkMargin)
      End If
      .SetDataSource(Wrkds)
      .SetParameterValue("myreportTitle", "State & Local Tax Credit")
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyYear", MyUtils.CnvSng(MyFrmTA208B.TxtGLYear.Text))
      .SetParameterValue("MyMillRate", MrateMillrt * 1000)
      .SetParameterValue("MyDouble", MyFrmTA208B.ChkDouble.Checked)
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
    ReportPath = MyUtils.GetReportPath("PrtTA208B.rpt", myTOWN._TOWNBR)
    With myreport3
      .Load(ReportPath)
      If MyReportLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        .PrintOptions.ApplyPageMargins(WrkMargin)
      End If
      .SetDataSource(WrkdsState)
      .SetParameterValue("myreportTitle", "State Only Tax Credit")
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyYear", MyUtils.CnvSng(MyFrmTA208B.TxtGLYear.Text))
      .SetParameterValue("MyMillRate", MrateMillrt * 1000)
      .SetParameterValue("MyDouble", MyFrmTA208B.ChkDouble.Checked)
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
    ReportPath = MyUtils.GetReportPath("PrtTA208C.rpt", myTOWN._TOWNBR)
    With myreport4
      .Load(ReportPath)
      If MyReportLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        .PrintOptions.ApplyPageMargins(WrkMargin)
      End If
      .SetDataSource(WrkdsLocal)
      .SetParameterValue("myreportTitle", "Local Only Tax Credit")
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyYear", MyUtils.CnvSng(MyFrmTA208B.TxtGLYear.Text))
      .SetParameterValue("MyMillRate", MrateMillrt * 1000)
      .SetParameterValue("MyDouble", MyFrmTA208B.ChkDouble.Checked)
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
  Private Sub RunReport5()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTA208D.rpt", myTOWN._TOWNBR)
    With myreport5
      .Load(ReportPath)
      If MyReportLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        .PrintOptions.ApplyPageMargins(WrkMargin)
      End If
      .SetDataSource(WrkdsSplit)
      .SetParameterValue("myreportTitle", "Account Splits")
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyYear", MyUtils.CnvSng(MyFrmTA208B.TxtGLYear.Text))
      .SetParameterValue("MyMillRate", MrateMillrt * 1000)
      .SetParameterValue("MyDouble", MyFrmTA208B.ChkDouble.Checked)
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
  Private Sub RunReport6()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTA208E.rpt", myTOWN._TOWNBR)
    With myreport6
      .Load(ReportPath)
      If MyReportLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        .PrintOptions.ApplyPageMargins(WrkMargin)
      End If
      .SetDataSource(WrkdsErrors)
      .SetParameterValue("myreportTitle", "State or Local Errors")
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyYear", MyUtils.CnvSng(MyFrmTA208B.TxtGLYear.Text))
      .SetParameterValue("MyMillRate", MrateMillrt * 1000)
      .SetParameterValue("MyDouble", MyFrmTA208B.ChkDouble.Checked)
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
  Private Sub RunReport7()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTA208F.rpt", myTOWN._TOWNBR)
    With myreport7
      .Load(ReportPath)
      If MyReportLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        .PrintOptions.ApplyPageMargins(WrkMargin)
      End If
      .SetDataSource(Wrkds)
      .SetParameterValue("myreportTitle", "Detail Tax Credits")
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyYear", MyUtils.CnvSng(MyFrmTA208B.TxtGLYear.Text))
      .SetParameterValue("MyMillRate", MrateMillrt * 1000)
      .SetParameterValue("MyLocalCd1", WrkLocalCd1)
      .SetParameterValue("MyLocalCd2", WrkLocalCd2)
      .SetParameterValue("MyLocalCd3", WrkLocalCd3)
      .SetParameterValue("MyLocalCd4", WrkLocalCd4)
      .SetParameterValue("MyLocalCd5", WrkLocalCd5)
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
  Private Sub RunReport8()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTA208Tot.rpt", myTOWN._TOWNBR)
    With myreport8
      .Load(ReportPath)
      If MyReportLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        .PrintOptions.ApplyPageMargins(WrkMargin)
      End If
      .SetDataSource(WrkdsElderly)
      .SetParameterValue("myreportTitle", "Elderly Totals")
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyYear", MyUtils.CnvSng(MyFrmTA208B.TxtGLYear.Text))
      .SetParameterValue("MyMillRate", MrateMillrt * 1000)
    End With
    With Crv8
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreport8
      .Zoom(75)
    End With

  End Sub
End Class
