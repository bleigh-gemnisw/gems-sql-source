Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend WrkdsTotMC As DataSet
  Friend WrkdsTotEx As DataSet
  Friend WrkdsTot As DataSet
  Friend WrkBTR As Boolean
  Dim ReportTitle As String

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
Friend WithEvents TabCtl1 As System.Windows.Forms.TabControl
Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents TabPart1 As System.Windows.Forms.TabPage
Friend WithEvents TabSummary As System.Windows.Forms.TabPage
Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents TabTotex As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.TabCtl1 = New System.Windows.Forms.TabControl
Me.TabPart1 = New System.Windows.Forms.TabPage
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabTotex = New System.Windows.Forms.TabPage
Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabSummary = New System.Windows.Forms.TabPage
Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabCtl1.SuspendLayout()
Me.TabPart1.SuspendLayout()
Me.TabTotex.SuspendLayout()
Me.TabSummary.SuspendLayout()
Me.SuspendLayout()
'
'TabCtl1
'
Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabCtl1.Controls.Add(Me.TabPart1)
Me.TabCtl1.Controls.Add(Me.TabTotex)
Me.TabCtl1.Controls.Add(Me.TabSummary)
Me.TabCtl1.Location = New System.Drawing.Point(4, 4)
Me.TabCtl1.Name = "TabCtl1"
Me.TabCtl1.SelectedIndex = 0
Me.TabCtl1.Size = New System.Drawing.Size(656, 380)
Me.TabCtl1.TabIndex = 0
'
'TabPart1
'
Me.TabPart1.Controls.Add(Me.Crv1)
Me.TabPart1.Location = New System.Drawing.Point(4, 22)
Me.TabPart1.Name = "TabPart1"
Me.TabPart1.Size = New System.Drawing.Size(648, 354)
Me.TabPart1.TabIndex = 0
Me.TabPart1.Text = "Parts 1 to 3 (Category Totals)"
Me.TabPart1.UseVisualStyleBackColor = True
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
Me.Crv1.Location = New System.Drawing.Point(8, 8)
Me.Crv1.Name = "Crv1"
Me.Crv1.SelectionFormula = ""
Me.Crv1.Size = New System.Drawing.Size(632, 344)
Me.Crv1.TabIndex = 1
Me.Crv1.ViewTimeSelectionFormula = ""
'
'TabTotex
'
Me.TabTotex.Controls.Add(Me.Crv2)
Me.TabTotex.Location = New System.Drawing.Point(4, 22)
Me.TabTotex.Name = "TabTotex"
Me.TabTotex.Size = New System.Drawing.Size(648, 354)
Me.TabTotex.TabIndex = 1
Me.TabTotex.Text = "Part 4 (Exemption Totals)"
Me.TabTotex.UseVisualStyleBackColor = True
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
Me.Crv2.Location = New System.Drawing.Point(8, 8)
Me.Crv2.Name = "Crv2"
Me.Crv2.SelectionFormula = ""
Me.Crv2.Size = New System.Drawing.Size(632, 340)
Me.Crv2.TabIndex = 2
Me.Crv2.ViewTimeSelectionFormula = ""
'
'TabSummary
'
Me.TabSummary.Controls.Add(Me.Crv3)
Me.TabSummary.Location = New System.Drawing.Point(4, 22)
Me.TabSummary.Name = "TabSummary"
Me.TabSummary.Size = New System.Drawing.Size(648, 354)
Me.TabSummary.TabIndex = 5
Me.TabSummary.Text = "Summary"
Me.TabSummary.UseVisualStyleBackColor = True
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
Me.TabPart1.ResumeLayout(False)
Me.TabTotex.ResumeLayout(False)
Me.TabSummary.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub CrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If MyFrmTO101B.ChkLocal.Checked Then
      ReportTitle = "Local Exemptions Included"
    Else
      ReportTitle = "STATE OF CONNECTICUT"
    End If

    RunReportTotMC()
    RunReportTotEx()
    RunReportTot()
End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport1.Close()
  myreport1.Dispose()
  myreport2.Close()
  myreport2.Dispose()
  myreport3.Close()
  myreport3.Dispose()
End Sub
  Private Sub RunReportTotMC()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTO101TotMC.rpt", myTOWN._TOWNBR)
   With myreport1
    .Load(ReportPath)
    .SetDataSource(WrkdsTotMC)
    .SetParameterValue("MyReportTitle", ReportTitle)
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyTownNum", myTOWN._TOWNBR)
    .SetParameterValue("MyYear", MyUtils.CnvSng(MyFrmTO101B.TxtGLYear.Text))
    .SetParameterValue("MyBTR", WrkBTR)
    .SetParameterValue("MyLocal", MyFrmTO101B.ChkLocal.Checked)
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
  Private Sub RunReportTotEx()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTO101TotEx.rpt", myTOWN._TOWNBR)
   With myreport2
    .Load(ReportPath)
    .SetDataSource(WrkdsTotEx)
    .SetParameterValue("MyReportTitle", ReportTitle)
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyTownNum", myTOWN._TOWNBR)
    .SetParameterValue("MyYear", MyUtils.CnvSng(MyFrmTO101B.TxtGLYear.Text))
    .SetParameterValue("MyBTR", WrkBTR)
    .SetParameterValue("MyLocal", MyFrmTO101B.ChkLocal.Checked)
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
  Private Sub RunReportTot()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTO101Tot.rpt", myTOWN._TOWNBR)
   With myreport3
    .Load(ReportPath)
    .SetDataSource(WrkdsTot)
    .SetParameterValue("MyReportTitle", ReportTitle)
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyTownNum", myTOWN._TOWNBR)
    .SetParameterValue("MyYear", MyUtils.CnvSng(MyFrmTO101B.TxtGLYear.Text))
    .SetParameterValue("MyBTR", WrkBTR)
    .SetParameterValue("MyAddress", WrkAddress)
    .SetParameterValue("MyTownZip", WrkTownZip)
    .SetParameterValue("MyPhone", WrkPhone)
    .SetParameterValue("MyFax", WrkFax)
    .SetParameterValue("MyEmail", WrkEmail)
    .SetParameterValue("MyAssrName", WrkAssrName)
    .SetParameterValue("MyCertYes", WrkCertYes)
    .SetParameterValue("MyCertNo", WrkCertNo)
    .SetParameterValue("MyCert", WrkCert)
    .SetParameterValue("MyDate", Date.Now)
    .SetParameterValue("MyLocal", MyFrmTO101B.ChkLocal.Checked)
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
Private Sub TabCtl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabCtl1.SelectedIndexChanged

End Sub

Private Sub TabGL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPart1.Click

End Sub
End Class






