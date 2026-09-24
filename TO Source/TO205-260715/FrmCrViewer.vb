Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

	Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
	Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
	Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport4 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport5 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport6 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpForms As System.Windows.Forms.TabPage
	Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
	Friend WithEvents TpDenied As System.Windows.Forms.TabPage
	Friend WithEvents crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
 Friend WithEvents TpUndecided As System.Windows.Forms.TabPage
 Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
 Friend WithEvents TpAlllowed As System.Windows.Forms.TabPage
 Friend WithEvents crv4 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend wrkds As DataSet = New DataSet
  Friend wrkds2 As DataSet = New DataSet
  Friend wrkds3 As DataSet = New DataSet
  Friend wrkds4 As DataSet = New DataSet
  Friend wrkds5 As DataSet = New DataSet
  Friend wrkds6 As DataSet = New DataSet
  Friend WithEvents TpLocal As TabPage
  Friend WithEvents crv5 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpLocForms As TabPage
  Friend WithEvents Crv6 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WrkUpdate As Boolean

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
    Me.TpForms = New System.Windows.Forms.TabPage()
    Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpDenied = New System.Windows.Forms.TabPage()
    Me.crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpUndecided = New System.Windows.Forms.TabPage()
    Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpAlllowed = New System.Windows.Forms.TabPage()
    Me.crv4 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpLocal = New System.Windows.Forms.TabPage()
    Me.crv5 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpLocForms = New System.Windows.Forms.TabPage()
    Me.Crv6 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabControl1.SuspendLayout()
    Me.TpForms.SuspendLayout()
    Me.TpDenied.SuspendLayout()
    Me.TpUndecided.SuspendLayout()
    Me.TpAlllowed.SuspendLayout()
    Me.TpLocal.SuspendLayout()
    Me.TpLocForms.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabControl1.Controls.Add(Me.TpForms)
    Me.TabControl1.Controls.Add(Me.TpDenied)
    Me.TabControl1.Controls.Add(Me.TpUndecided)
    Me.TabControl1.Controls.Add(Me.TpAlllowed)
    Me.TabControl1.Controls.Add(Me.TpLocal)
    Me.TabControl1.Controls.Add(Me.TpLocForms)
    Me.TabControl1.Location = New System.Drawing.Point(10, 5)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(644, 376)
    Me.TabControl1.TabIndex = 3
    '
    'TpForms
    '
    Me.TpForms.Controls.Add(Me.Crv1)
    Me.TpForms.Location = New System.Drawing.Point(4, 22)
    Me.TpForms.Name = "TpForms"
    Me.TpForms.Size = New System.Drawing.Size(636, 350)
    Me.TpForms.TabIndex = 0
    Me.TpForms.Text = "Forms"
    Me.TpForms.UseVisualStyleBackColor = True
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
    Me.Crv1.Location = New System.Drawing.Point(0, 0)
    Me.Crv1.Name = "Crv1"
    Me.Crv1.SelectionFormula = ""
    Me.Crv1.Size = New System.Drawing.Size(640, 352)
    Me.Crv1.TabIndex = 1
    Me.Crv1.ViewTimeSelectionFormula = ""
    '
    'TpDenied
    '
    Me.TpDenied.Controls.Add(Me.crv2)
    Me.TpDenied.Location = New System.Drawing.Point(4, 22)
    Me.TpDenied.Name = "TpDenied"
    Me.TpDenied.Size = New System.Drawing.Size(636, 350)
    Me.TpDenied.TabIndex = 1
    Me.TpDenied.Text = "Disallowed"
    Me.TpDenied.UseVisualStyleBackColor = True
    '
    'crv2
    '
    Me.crv2.ActiveViewIndex = -1
    Me.crv2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.crv2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.crv2.DisplayStatusBar = False
    Me.crv2.DisplayToolbar = False
    Me.crv2.Location = New System.Drawing.Point(-2, -1)
    Me.crv2.Name = "crv2"
    Me.crv2.SelectionFormula = ""
    Me.crv2.Size = New System.Drawing.Size(640, 352)
    Me.crv2.TabIndex = 2
    Me.crv2.ViewTimeSelectionFormula = ""
    '
    'TpUndecided
    '
    Me.TpUndecided.Controls.Add(Me.Crv3)
    Me.TpUndecided.Location = New System.Drawing.Point(4, 22)
    Me.TpUndecided.Name = "TpUndecided"
    Me.TpUndecided.Size = New System.Drawing.Size(636, 350)
    Me.TpUndecided.TabIndex = 2
    Me.TpUndecided.Text = "Undecided"
    Me.TpUndecided.UseVisualStyleBackColor = True
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
    Me.Crv3.Location = New System.Drawing.Point(-2, -1)
    Me.Crv3.Name = "Crv3"
    Me.Crv3.SelectionFormula = ""
    Me.Crv3.Size = New System.Drawing.Size(640, 352)
    Me.Crv3.TabIndex = 3
    Me.Crv3.ViewTimeSelectionFormula = ""
    '
    'TpAlllowed
    '
    Me.TpAlllowed.Controls.Add(Me.crv4)
    Me.TpAlllowed.Location = New System.Drawing.Point(4, 22)
    Me.TpAlllowed.Name = "TpAlllowed"
    Me.TpAlllowed.Size = New System.Drawing.Size(636, 350)
    Me.TpAlllowed.TabIndex = 3
    Me.TpAlllowed.Text = "Allowed"
    Me.TpAlllowed.UseVisualStyleBackColor = True
    '
    'crv4
    '
    Me.crv4.ActiveViewIndex = -1
    Me.crv4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.crv4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.crv4.Cursor = System.Windows.Forms.Cursors.Default
    Me.crv4.DisplayStatusBar = False
    Me.crv4.DisplayToolbar = False
    Me.crv4.Location = New System.Drawing.Point(-2, -1)
    Me.crv4.Name = "crv4"
    Me.crv4.SelectionFormula = ""
    Me.crv4.Size = New System.Drawing.Size(640, 352)
    Me.crv4.TabIndex = 4
    Me.crv4.ViewTimeSelectionFormula = ""
    '
    'TpLocal
    '
    Me.TpLocal.Controls.Add(Me.crv5)
    Me.TpLocal.Location = New System.Drawing.Point(4, 22)
    Me.TpLocal.Name = "TpLocal"
    Me.TpLocal.Size = New System.Drawing.Size(636, 350)
    Me.TpLocal.TabIndex = 4
    Me.TpLocal.Text = "Local"
    Me.TpLocal.UseVisualStyleBackColor = True
    '
    'crv5
    '
    Me.crv5.ActiveViewIndex = -1
    Me.crv5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.crv5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.crv5.Cursor = System.Windows.Forms.Cursors.Default
    Me.crv5.DisplayStatusBar = False
    Me.crv5.DisplayToolbar = False
    Me.crv5.Location = New System.Drawing.Point(-2, -1)
    Me.crv5.Name = "crv5"
    Me.crv5.SelectionFormula = ""
    Me.crv5.Size = New System.Drawing.Size(640, 352)
    Me.crv5.TabIndex = 5
    Me.crv5.ViewTimeSelectionFormula = ""
    '
    'TpLocForms
    '
    Me.TpLocForms.Controls.Add(Me.Crv6)
    Me.TpLocForms.Location = New System.Drawing.Point(4, 22)
    Me.TpLocForms.Name = "TpLocForms"
    Me.TpLocForms.Size = New System.Drawing.Size(636, 350)
    Me.TpLocForms.TabIndex = 5
    Me.TpLocForms.Text = "Local Forms"
    Me.TpLocForms.UseVisualStyleBackColor = True
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
    Me.Crv6.TabIndex = 6
    Me.Crv6.ViewTimeSelectionFormula = ""
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
    Me.TpForms.ResumeLayout(False)
    Me.TpDenied.ResumeLayout(False)
    Me.TpUndecided.ResumeLayout(False)
    Me.TpAlllowed.ResumeLayout(False)
    Me.TpLocal.ResumeLayout(False)
    Me.TpLocForms.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    RunReport1()
    RunReport2()
    RunReport3()
    RunReport4()
    If wrkds5.Tables(0).Rows.Count > 0 Then
      RunReport5()
      RunReport6()
    Else
      TabControl1.TabPages.Remove(TpLocal)
      TabControl1.TabPages.Remove(TpLocForms)
    End If
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
  End Sub

  Private Sub RunReport1()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
  ReportPath = MyUtils.GetReportPath("PrtTO201.rpt", myTOWN._TOWNBR)
   With myreport1
    .Load(ReportPath)
    .SetDataSource(wrkds)
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
  ReportPath = MyUtils.GetReportPath("PrtTO205.rpt", myTOWN._TOWNBR)
  With myreport2
  .Load(ReportPath)
  .SetDataSource(wrkds2)
  .SetParameterValue("myreportTitle", "M35H Disallowed List")
  .SetParameterValue("MyUserID", MyUserID)
  .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
  .SetParameterValue("MyPost", WrkUpdate)
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
 Private Sub RunReport3()
  Dim ReportPath As String

  Me.Text = "Report Viewer"
  ReportPath = MyUtils.GetReportPath("PrtTO205.rpt", myTOWN._TOWNBR)
  With myreport3
  .Load(ReportPath)
  .SetDataSource(wrkds3)
  .SetParameterValue("myreportTitle", "M35H Undecided List")
  .SetParameterValue("MyUserID", MyUserID)
  .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
  .SetParameterValue("MyPost", WrkUpdate)
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
  ReportPath = MyUtils.GetReportPath("PrtTO205B.rpt", myTOWN._TOWNBR)
  With myreport4
  .Load(ReportPath)
  .SetDataSource(wrkds4)
  .SetParameterValue("myreportTitle", "M35H Allowed List")
  .SetParameterValue("MyUserID", MyUserID)
  .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
  .SetParameterValue("MyPost", WrkUpdate)
  End With
  With crv4
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
    ReportPath = MyUtils.GetReportPath("PrtTO205C.rpt", myTOWN._TOWNBR)
    With myreport5
      .Load(ReportPath)
      .SetDataSource(wrkds5)
      .SetParameterValue("myreportTitle", "Local List")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyPost", WrkUpdate)
    End With
    With crv5
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
    ReportPath = MyUtils.GetReportPath("PrtTO201LP.rpt", myTOWN._TOWNBR)
    With myreport6
      .Load(ReportPath)
      .SetDataSource(wrkds6)
      .SetParameterValue("MyTown", Trim(myTOWN._TOWN))
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






