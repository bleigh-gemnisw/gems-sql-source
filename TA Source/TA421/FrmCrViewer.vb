Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend wrkds As DataSet = New DataSet
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpName As System.Windows.Forms.TabPage
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpTown As System.Windows.Forms.TabPage
  Friend WithEvents crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WrkPost As Boolean


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
Me.TpName = New System.Windows.Forms.TabPage
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpTown = New System.Windows.Forms.TabPage
Me.crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabControl1.SuspendLayout()
Me.TpName.SuspendLayout()
Me.TpTown.SuspendLayout()
Me.SuspendLayout()
'
'TabControl1
'
Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabControl1.Controls.Add(Me.TpName)
Me.TabControl1.Controls.Add(Me.TpTown)
Me.TabControl1.Location = New System.Drawing.Point(10, 5)
Me.TabControl1.Name = "TabControl1"
Me.TabControl1.SelectedIndex = 0
Me.TabControl1.Size = New System.Drawing.Size(644, 376)
Me.TabControl1.TabIndex = 3
'
'TpName
'
Me.TpName.Controls.Add(Me.Crv1)
Me.TpName.Location = New System.Drawing.Point(4, 22)
Me.TpName.Name = "TpName"
Me.TpName.Size = New System.Drawing.Size(636, 350)
Me.TpName.TabIndex = 0
Me.TpName.Text = "By Name"
Me.TpName.UseVisualStyleBackColor = True
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
Me.Crv1.Location = New System.Drawing.Point(0, 0)
Me.Crv1.Name = "Crv1"
Me.Crv1.SelectionFormula = ""
Me.Crv1.Size = New System.Drawing.Size(640, 352)
Me.Crv1.TabIndex = 1
Me.Crv1.ViewTimeSelectionFormula = ""
'
'TpTown
'
Me.TpTown.Controls.Add(Me.crv2)
Me.TpTown.Location = New System.Drawing.Point(4, 22)
Me.TpTown.Name = "TpTown"
Me.TpTown.Size = New System.Drawing.Size(636, 350)
Me.TpTown.TabIndex = 1
Me.TpTown.Text = "By Town"
Me.TpTown.UseVisualStyleBackColor = True
Me.TpTown.Visible = False
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
Me.TpName.ResumeLayout(False)
Me.TpTown.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    RunReport()
    RunReport2()
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
   ReportPath = MyUtils.GetReportPath("PrtTA421.rpt", myTOWN._TOWNBR)

   With myreport
    .Load(ReportPath)
    .SetDataSource(wrkds)
    .SetParameterValue("myreportTitle", "Purge Motor Vehicle Transfers")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyPost", WrkPost)
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
   ReportPath = MyUtils.GetReportPath("PrtTA421B.rpt", myTOWN._TOWNBR)

   With myreport2
    .Load(ReportPath)
    .SetDataSource(wrkds)
    .SetParameterValue("myreportTitle", "Purge Motor Vehicle Transfers by Town")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyPost", WrkPost)
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






