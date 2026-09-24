Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend wrkds As DataSet = New DataSet
  Friend wrkds2 As DataSet = New DataSet
  Friend Wrkdistphase As String
  Friend Wrksort As String
  Dim WrkBillType As String
  Dim WrkFamily As String
  Friend WithEvents TabCtl1 As TabControl
  Friend WithEvents TPDetail As TabPage
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpTotals As TabPage
  Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WrkUBType As String

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
    Me.TPDetail = New System.Windows.Forms.TabPage()
    Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpTotals = New System.Windows.Forms.TabPage()
    Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabCtl1.SuspendLayout()
    Me.TPDetail.SuspendLayout()
    Me.TpTotals.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabCtl1
    '
    Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabCtl1.Controls.Add(Me.TPDetail)
    Me.TabCtl1.Controls.Add(Me.TpTotals)
    Me.TabCtl1.Location = New System.Drawing.Point(4, 3)
    Me.TabCtl1.Name = "TabCtl1"
    Me.TabCtl1.SelectedIndex = 0
    Me.TabCtl1.Size = New System.Drawing.Size(656, 380)
    Me.TabCtl1.TabIndex = 1
    '
    'TPDetail
    '
    Me.TPDetail.Controls.Add(Me.Crv1)
    Me.TPDetail.Location = New System.Drawing.Point(4, 22)
    Me.TPDetail.Name = "TPDetail"
    Me.TPDetail.Size = New System.Drawing.Size(648, 354)
    Me.TPDetail.TabIndex = 0
    Me.TPDetail.Text = "Posted Rate Book"
    Me.TPDetail.UseVisualStyleBackColor = True
    '
    'Crv1
    '
    Me.Crv1.ActiveViewIndex = -1
    Me.Crv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv1.Cursor = System.Windows.Forms.Cursors.Default
    Me.Crv1.Location = New System.Drawing.Point(0, 0)
    Me.Crv1.Name = "Crv1"
    Me.Crv1.SelectionFormula = ""
    Me.Crv1.Size = New System.Drawing.Size(648, 352)
    Me.Crv1.TabIndex = 1
    Me.Crv1.ViewTimeSelectionFormula = ""
    '
    'TpTotals
    '
    Me.TpTotals.Controls.Add(Me.Crv2)
    Me.TpTotals.Location = New System.Drawing.Point(4, 22)
    Me.TpTotals.Name = "TpTotals"
    Me.TpTotals.Size = New System.Drawing.Size(648, 354)
    Me.TpTotals.TabIndex = 1
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
    Me.Crv2.Size = New System.Drawing.Size(648, 352)
    Me.Crv2.TabIndex = 2
    Me.Crv2.ViewTimeSelectionFormula = ""
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
    Me.TPDetail.ResumeLayout(False)
    Me.TpTotals.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    WrkBillType = GetUTTypeDesc(WrkUBType)
    WrkFamily = GetUTTYPEFamily(WrkUBType)

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

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtUB237.rpt", myTOWN._TOWNBR)
    With myreport
      .Load(ReportPath)
      .SetDataSource(wrkds)
      .SetParameterValue("myreportTitle", Trim(WrkBillType) & " Posted Rate Book")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyFromDate", MyFrmUB237B.DtPckFrom.Value)
      .SetParameterValue("MyToDate", MyFrmUB237B.DtPckTo.Value)
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
    ReportPath = MyUtils.GetReportPath("PrtUB237Tot.rpt", myTOWN._TOWNBR)
    With myreport2
      .Load(ReportPath)
      .SetDataSource(wrkds2)
      .SetParameterValue("myreportTitle", Trim(WrkBillType) & " Posted Rate Book")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyFromDate", MyFrmUB237B.DtPckFrom.Value)
      .SetParameterValue("MyToDate", MyFrmUB237B.DtPckTo.Value)
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



  Private Sub Crv1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

  End Sub
End Class







