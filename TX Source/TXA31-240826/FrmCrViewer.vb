Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim WrkMargin As CrystalDecisions.Shared.PageMargins
  Friend WithEvents TabCtl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpReport As System.Windows.Forms.TabPage
  Friend WithEvents crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpError As System.Windows.Forms.TabPage
  Friend WithEvents crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend wrkds As DataSet = New DataSet
  Friend wrkdserr As DataSet = New DataSet
  Dim WrkStatus As String
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
    Me.TabCtl1 = New System.Windows.Forms.TabControl()
    Me.TpReport = New System.Windows.Forms.TabPage()
    Me.crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpError = New System.Windows.Forms.TabPage()
    Me.crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabCtl1.SuspendLayout()
    Me.TpReport.SuspendLayout()
    Me.TpError.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabCtl1
    '
    Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabCtl1.Controls.Add(Me.TpReport)
    Me.TabCtl1.Controls.Add(Me.TpError)
    Me.TabCtl1.Location = New System.Drawing.Point(10, 5)
    Me.TabCtl1.Name = "TabCtl1"
    Me.TabCtl1.SelectedIndex = 0
    Me.TabCtl1.Size = New System.Drawing.Size(644, 376)
    Me.TabCtl1.TabIndex = 2
    '
    'TpReport
    '
    Me.TpReport.Controls.Add(Me.crv1)
    Me.TpReport.Location = New System.Drawing.Point(4, 22)
    Me.TpReport.Name = "TpReport"
    Me.TpReport.Size = New System.Drawing.Size(636, 350)
    Me.TpReport.TabIndex = 1
    Me.TpReport.Text = "Report"
    Me.TpReport.UseVisualStyleBackColor = True
    '
    'crv1
    '
    Me.crv1.ActiveViewIndex = -1
    Me.crv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.crv1.Cursor = System.Windows.Forms.Cursors.Default
    Me.crv1.DisplayStatusBar = False
    Me.crv1.DisplayToolbar = False
    Me.crv1.Location = New System.Drawing.Point(-2, -1)
    Me.crv1.Name = "crv1"
    Me.crv1.SelectionFormula = ""
    Me.crv1.Size = New System.Drawing.Size(640, 352)
    Me.crv1.TabIndex = 2
    Me.crv1.ViewTimeSelectionFormula = ""
    '
    'TpError
    '
    Me.TpError.Controls.Add(Me.crv2)
    Me.TpError.Location = New System.Drawing.Point(4, 22)
    Me.TpError.Name = "TpError"
    Me.TpError.Size = New System.Drawing.Size(636, 350)
    Me.TpError.TabIndex = 2
    Me.TpError.Text = "Errors"
    Me.TpError.UseVisualStyleBackColor = True
    '
    'crv2
    '
    Me.crv2.ActiveViewIndex = -1
    Me.crv2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.crv2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.crv2.Cursor = System.Windows.Forms.Cursors.Default
    Me.crv2.DisplayStatusBar = False
    Me.crv2.DisplayToolbar = False
    Me.crv2.Location = New System.Drawing.Point(-2, -1)
    Me.crv2.Name = "crv2"
    Me.crv2.SelectionFormula = ""
    Me.crv2.Size = New System.Drawing.Size(640, 352)
    Me.crv2.TabIndex = 2
    Me.crv2.ViewTimeSelectionFormula = ""
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
    Me.TpReport.ResumeLayout(False)
    Me.TpError.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    WrkStatus = MyFrmTXA31B.TxtStatus.Text

    With WrkMargin
      .leftMargin = 150
      .rightMargin = 150
      .topMargin = 150
      .bottomMargin = 150
    End With
    RunReport()
    If wrkdserr.Tables(0).Rows.Count = 0 Then
      TabCtl1.TabPages.Remove(TpError)
      TabCtl1.Refresh()
    Else
      TabCtl1.SelectTab(TpError)
      RunReport2()
    End If
  End Sub
  Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    myreport.Close()
    myreport.Dispose()
    myreport2.Close()
    myreport2.Dispose()
  End Sub

  Private Sub RunReport()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTXA31.rpt", myTOWN._TOWNBR)
    With myreport
      .Load(ReportPath)
      .SetDataSource(wrkds)
      .SetParameterValue("myreportTitle", "Copy Status Codes")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyType", MyFrmTXA31B.TxtType.Text)
      .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTXA31B.TxtFromGLYear.Text))
      .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTXA31B.TxtToGLYear.Text))
      .SetParameterValue("MyStatus", WrkStatus)
    End With
    With crv1
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
    ReportPath = MyUtils.GetReportPath("PrtTXA31.rpt", myTOWN._TOWNBR)
    With myreport2
      .Load(ReportPath)
      .SetDataSource(wrkdserr)
      .SetParameterValue("myreportTitle", "Copy Status Codes Errors")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyType", MyFrmTXA31B.TxtType.Text)
      .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTXA31B.TxtFromGLYear.Text))
      .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTXA31B.TxtToGLYear.Text))
      .SetParameterValue("MyStatus", WrkStatus)
    End With
    With crv2
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
End Class






