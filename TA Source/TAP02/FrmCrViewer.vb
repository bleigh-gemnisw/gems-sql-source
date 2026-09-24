Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

 Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
 Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
 Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
 Friend WithEvents TpList As System.Windows.Forms.TabPage
 Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
 Friend WithEvents TpSummary As System.Windows.Forms.TabPage
 Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
 Friend wrkds As DataSet = New DataSet
 Friend wrkdsSum As DataSet = New DataSet
 Friend WrkYear As Integer

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
Me.TpList = New System.Windows.Forms.TabPage
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpSummary = New System.Windows.Forms.TabPage
Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabControl1.SuspendLayout()
Me.TpList.SuspendLayout()
Me.TpSummary.SuspendLayout()
Me.SuspendLayout()
'
'TabControl1
'
Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabControl1.Controls.Add(Me.TpList)
Me.TabControl1.Controls.Add(Me.TpSummary)
Me.TabControl1.Location = New System.Drawing.Point(-1, 1)
Me.TabControl1.Name = "TabControl1"
Me.TabControl1.SelectedIndex = 0
Me.TabControl1.Size = New System.Drawing.Size(664, 380)
Me.TabControl1.TabIndex = 2
'
'TpList
'
Me.TpList.Controls.Add(Me.Crv1)
Me.TpList.Location = New System.Drawing.Point(4, 22)
Me.TpList.Name = "TpList"
Me.TpList.Size = New System.Drawing.Size(656, 354)
Me.TpList.TabIndex = 0
Me.TpList.Text = "List"
Me.TpList.UseVisualStyleBackColor = True
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
Me.Crv1.Size = New System.Drawing.Size(660, 367)
Me.Crv1.TabIndex = 1
Me.Crv1.ViewTimeSelectionFormula = ""
'
'TpSummary
'
Me.TpSummary.Controls.Add(Me.Crv2)
Me.TpSummary.Location = New System.Drawing.Point(4, 22)
Me.TpSummary.Name = "TpSummary"
Me.TpSummary.Size = New System.Drawing.Size(656, 354)
Me.TpSummary.TabIndex = 1
Me.TpSummary.Text = "Summary"
Me.TpSummary.UseVisualStyleBackColor = True
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
Me.Crv2.Size = New System.Drawing.Size(660, 356)
Me.Crv2.TabIndex = 2
Me.Crv2.ViewTimeSelectionFormula = ""
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
Me.TpList.ResumeLayout(False)
Me.TpSummary.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    RunReport1()
    RunReport2()
 End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport1.Close()
  myreport1.Dispose()
  myreport2.Close()
  myreport2.Dispose()
End Sub

  Private Sub RunReport1()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTAP02Lst.rpt", myTOWN._TOWNBR)
   With myreport1
    .Load(ReportPath)
		.SetDataSource(wrkds)
		.SetParameterValue("MyReportTitle", "PP Declarations M-65 Assets List")
		.SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", myTOWN._TOWN)
		.SetParameterValue("MyCode", cCode)
		.SetParameterValue("MyYear", WrkYear)
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
  ReportPath = MyUtils.GetReportPath("PrtTAP02Sum.rpt", myTOWN._TOWNBR)
   With myreport2
    .Load(ReportPath)
    .SetDataSource(wrkdsSum)
    .SetParameterValue("MyReportTitle", "PP Declarations M-65 Summary")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", myTOWN._TOWN)
    .SetParameterValue("MyYear", WrkYear)
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
End Class






