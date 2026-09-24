Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend WithEvents TabCtl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabPgOPM As System.Windows.Forms.TabPage
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TabPgDetail As System.Windows.Forms.TabPage
  Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend Wrkds As DataSet
  Friend WrkdsDtl As DataSet

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
Me.TabCtl1 = New System.Windows.Forms.TabControl
Me.TabPgOPM = New System.Windows.Forms.TabPage
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabPgDetail = New System.Windows.Forms.TabPage
Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabCtl1.SuspendLayout()
Me.TabPgOPM.SuspendLayout()
Me.TabPgDetail.SuspendLayout()
Me.SuspendLayout()
'
'TabCtl1
'
Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabCtl1.Controls.Add(Me.TabPgOPM)
Me.TabCtl1.Controls.Add(Me.TabPgDetail)
Me.TabCtl1.Location = New System.Drawing.Point(4, 3)
Me.TabCtl1.Name = "TabCtl1"
Me.TabCtl1.SelectedIndex = 0
Me.TabCtl1.Size = New System.Drawing.Size(656, 380)
Me.TabCtl1.TabIndex = 1
'
'TabPgOPM
'
Me.TabPgOPM.Controls.Add(Me.Crv1)
Me.TabPgOPM.Location = New System.Drawing.Point(4, 22)
Me.TabPgOPM.Name = "TabPgOPM"
Me.TabPgOPM.Size = New System.Drawing.Size(648, 354)
Me.TabPgOPM.TabIndex = 0
Me.TabPgOPM.Text = "OPM"
Me.TabPgOPM.UseVisualStyleBackColor = True
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
Me.Crv1.Size = New System.Drawing.Size(648, 352)
Me.Crv1.TabIndex = 1
Me.Crv1.ViewTimeSelectionFormula = ""
'
'TabPgDetail
'
Me.TabPgDetail.Controls.Add(Me.Crv2)
Me.TabPgDetail.Location = New System.Drawing.Point(4, 22)
Me.TabPgDetail.Name = "TabPgDetail"
Me.TabPgDetail.Size = New System.Drawing.Size(648, 354)
Me.TabPgDetail.TabIndex = 2
Me.TabPgDetail.Text = "Detail Listing"
Me.TabPgDetail.UseVisualStyleBackColor = True
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
Me.Crv2.Location = New System.Drawing.Point(0, 1)
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
Me.TabPgOPM.ResumeLayout(False)
Me.TabPgDetail.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub CrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    RunReport()
    If MyFrmTO206B.ChkDetail.Checked Then
      RunReportDtl()
    Else
      TabCtl1.TabPages.Remove(TabPgDetail)
    End If
End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport1.Close()
  myreport1.Dispose()
  myreport2.Close()
  myreport2.Dispose()
End Sub
  Private Sub RunReport()
   Dim ReportPath As String
   Dim WrkGLPeriod As String
   Dim WrkGLYear2 As Integer

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTO206.rpt", myTOWN._TOWNBR)
   WrkGLYear2 = MyUtils.CnvSng(Mid(MyFrmTO206B.TxtGLYear.Text, 3, 2))
   WrkGLPeriod = "'" & (Format(WrkGLYear2, "00")) & "-'" & Format(WrkGLYear2 + 1, "00")
   With myreport1
    .Load(ReportPath)
    .SetDataSource(Wrkds)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyTownNbr", myTOWN._TOWNBR)
    .SetParameterValue("MyCollector", Trim(myTOWN._COLCTR))
    .SetParameterValue("MyGLYear", MyUtils.CnvSng(MyFrmTO206B.TxtGLYear.Text))
    .SetParameterValue("MyGLPeriod", WrkGLPeriod)
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
  Private Sub RunReportDtl()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTO206Dtl.rpt", myTOWN._TOWNBR)
   With myreport2
    .Load(ReportPath)
    .SetDataSource(WrkdsDtl)
    .SetParameterValue("myreportTitle", "M-1 Detail List")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyGLYear", MyUtils.CnvSng(MyFrmTO206B.TxtGLYear.Text))
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






