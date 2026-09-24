Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport5 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreportTot As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend Wrkds As DataSet
  Friend Wrkds2 As DataSet
  Friend WrkdsTot As DataSet
  Friend WrkdsErr As DataSet
  Friend WithEvents TpListing As System.Windows.Forms.TabPage
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpErrors As System.Windows.Forms.TabPage
  Friend WithEvents Crv5 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpTotals As System.Windows.Forms.TabPage
  Friend WithEvents Crvtot As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer

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
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpDetail As System.Windows.Forms.TabPage
  Friend WithEvents TpMissing As System.Windows.Forms.TabPage
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TpListing = New System.Windows.Forms.TabPage()
    Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpDetail = New System.Windows.Forms.TabPage()
    Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpMissing = New System.Windows.Forms.TabPage()
    Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpTotals = New System.Windows.Forms.TabPage()
    Me.Crvtot = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpErrors = New System.Windows.Forms.TabPage()
    Me.Crv5 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabControl1.SuspendLayout()
    Me.TpListing.SuspendLayout()
    Me.TpDetail.SuspendLayout()
    Me.TpMissing.SuspendLayout()
    Me.TpTotals.SuspendLayout()
    Me.TpErrors.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabControl1.Controls.Add(Me.TpListing)
    Me.TabControl1.Controls.Add(Me.TpDetail)
    Me.TabControl1.Controls.Add(Me.TpMissing)
    Me.TabControl1.Controls.Add(Me.TpTotals)
    Me.TabControl1.Controls.Add(Me.TpErrors)
    Me.TabControl1.Location = New System.Drawing.Point(10, 5)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(644, 376)
    Me.TabControl1.TabIndex = 2
    '
    'TpListing
    '
    Me.TpListing.Controls.Add(Me.Crv1)
    Me.TpListing.Location = New System.Drawing.Point(4, 22)
    Me.TpListing.Name = "TpListing"
    Me.TpListing.Size = New System.Drawing.Size(636, 350)
    Me.TpListing.TabIndex = 3
    Me.TpListing.Text = "Listing"
    Me.TpListing.UseVisualStyleBackColor = True
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
    Me.Crv1.TabIndex = 2
    Me.Crv1.ViewTimeSelectionFormula = ""
    '
    'TpDetail
    '
    Me.TpDetail.Controls.Add(Me.Crv2)
    Me.TpDetail.Location = New System.Drawing.Point(4, 22)
    Me.TpDetail.Name = "TpDetail"
    Me.TpDetail.Size = New System.Drawing.Size(636, 350)
    Me.TpDetail.TabIndex = 0
    Me.TpDetail.Text = "Detail"
    Me.TpDetail.UseVisualStyleBackColor = True
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
    Me.Crv2.TabIndex = 4
    Me.Crv2.ViewTimeSelectionFormula = ""
    '
    'TpMissing
    '
    Me.TpMissing.Controls.Add(Me.Crv3)
    Me.TpMissing.Location = New System.Drawing.Point(4, 22)
    Me.TpMissing.Name = "TpMissing"
    Me.TpMissing.Size = New System.Drawing.Size(636, 350)
    Me.TpMissing.TabIndex = 2
    Me.TpMissing.Text = "Missing/Zero"
    Me.TpMissing.UseVisualStyleBackColor = True
    '
    'Crv3
    '
    Me.Crv3.ActiveViewIndex = -1
    Me.Crv3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv3.Cursor = System.Windows.Forms.Cursors.Default
    Me.Crv3.DisplayStatusBar = False
    Me.Crv3.DisplayToolbar = False
    Me.Crv3.Location = New System.Drawing.Point(-2, -1)
    Me.Crv3.Name = "Crv3"
    Me.Crv3.SelectionFormula = ""
    Me.Crv3.Size = New System.Drawing.Size(640, 352)
    Me.Crv3.TabIndex = 5
    Me.Crv3.ViewTimeSelectionFormula = ""
    '
    'TpTotals
    '
    Me.TpTotals.Controls.Add(Me.Crvtot)
    Me.TpTotals.Location = New System.Drawing.Point(4, 22)
    Me.TpTotals.Name = "TpTotals"
    Me.TpTotals.Size = New System.Drawing.Size(636, 350)
    Me.TpTotals.TabIndex = 6
    Me.TpTotals.Text = "Totals"
    Me.TpTotals.UseVisualStyleBackColor = True
    '
    'Crvtot
    '
    Me.Crvtot.ActiveViewIndex = -1
    Me.Crvtot.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crvtot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crvtot.DisplayStatusBar = False
    Me.Crvtot.DisplayToolbar = False
    Me.Crvtot.Location = New System.Drawing.Point(-2, -1)
    Me.Crvtot.Name = "Crvtot"
    Me.Crvtot.SelectionFormula = ""
    Me.Crvtot.Size = New System.Drawing.Size(640, 352)
    Me.Crvtot.TabIndex = 8
    Me.Crvtot.ViewTimeSelectionFormula = ""
    '
    'TpErrors
    '
    Me.TpErrors.Controls.Add(Me.Crv5)
    Me.TpErrors.Location = New System.Drawing.Point(4, 22)
    Me.TpErrors.Name = "TpErrors"
    Me.TpErrors.Size = New System.Drawing.Size(636, 350)
    Me.TpErrors.TabIndex = 4
    Me.TpErrors.Text = "Errors"
    Me.TpErrors.UseVisualStyleBackColor = True
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
    Me.Crv5.Location = New System.Drawing.Point(-2, -1)
    Me.Crv5.Name = "Crv5"
    Me.Crv5.SelectionFormula = ""
    Me.Crv5.Size = New System.Drawing.Size(640, 352)
    Me.Crv5.TabIndex = 6
    Me.Crv5.ViewTimeSelectionFormula = ""
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
    Me.TpListing.ResumeLayout(False)
    Me.TpDetail.ResumeLayout(False)
    Me.TpMissing.ResumeLayout(False)
    Me.TpTotals.ResumeLayout(False)
    Me.TpErrors.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    RunReport1()
    RunReport2()
    RunReport3()
    If WrkdsErr.Tables(0).Rows.Count > 0 Then
      RunReport5()
    Else
      TabControl1.TabPages.Remove(TpErrors)
    End If
    RunReportTot()
  End Sub
  Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    myreport1.Close()
    myreport1.Dispose()
    myreport2.Close()
    myreport2.Dispose()
    myreport3.Close()
    myreport3.Dispose()
    myreport5.Close()
    myreport5.Dispose()
    myreportTot.Close()
    myreportTot.Dispose()
  End Sub
  Private Sub RunReport1()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTAP30.rpt", myTOWN._TOWNBR)
    With myreport1
      .Load(ReportPath)
      .SetDataSource(Wrkds)
      .SetParameterValue("myreportTitle", "Personal Property Declarations Listing")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyPost", MyFrmTAP30B.ChkPost.Checked)
      .SetParameterValue("MyUpdCode", MyFrmTAP30B.ChkPropCode.Checked)
      .SetParameterValue("MyUpdExempt", MyFrmTAP30B.ChkExemptCode.Checked)
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
    ReportPath = MyUtils.GetReportPath("PrtTAP30B.rpt", myTOWN._TOWNBR)
    With myreport2
      .Load(ReportPath)
      .SetDataSource(Wrkds)
      .SetParameterValue("myreportTitle", "Update Personal Property from Declarations")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyPost", MyFrmTAP30B.ChkPost.Checked)
      .SetParameterValue("MyUpdCode", MyFrmTAP30B.ChkPropCode.Checked)
      .SetParameterValue("MyUpdExempt", MyFrmTAP30B.ChkExemptCode.Checked)
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
    ReportPath = MyUtils.GetReportPath("PrtTAP30B.rpt", myTOWN._TOWNBR)
    With myreport3
      .Load(ReportPath)
      .SetDataSource(Wrkds2)
      .SetParameterValue("myreportTitle", "Missing/Zero Personal Property in Declarations")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyPost", MyFrmTAP30B.ChkPost.Checked)
      .SetParameterValue("MyUpdCode", MyFrmTAP30B.ChkPropCode.Checked)
      .SetParameterValue("MyUpdExempt", MyFrmTAP30B.ChkExemptCode.Checked)
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
  Private Sub RunReport5()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTAP30Err.rpt", myTOWN._TOWNBR)
    With myreport5
      .Load(ReportPath)
      .SetDataSource(WrkdsErr)
      .SetParameterValue("myreportTitle", "Personal Property Declarations Bridge Errors")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyPost", MyFrmTAP30B.ChkPost.Checked)
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
  Private Sub RunReportTot()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTAP30Tot.rpt", myTOWN._TOWNBR)
    With myreportTot
      .Load(ReportPath)
      .SetDataSource(WrkdsTot)
      .SetParameterValue("myreportTitle", "Personal Property Declarations Bridge Totals")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyPost", MyFrmTAP30B.ChkPost.Checked)
      .SetParameterValue("MyUpdCode", MyFrmTAP30B.ChkPropCode.Checked)
      .SetParameterValue("MyUpdExempt", MyFrmTAP30B.ChkExemptCode.Checked)
    End With
    With Crvtot
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







