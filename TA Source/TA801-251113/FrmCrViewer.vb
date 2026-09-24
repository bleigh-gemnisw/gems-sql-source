Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim WrkMargin As CrystalDecisions.Shared.PageMargins
  Friend Wrkds1 As DataSet
  Friend Wrkds2 As DataSet
  Friend WrkTypeDesc As String
  Friend WrkReportType As String
  Friend WrkMultMethod As String
  Friend WrkTaxMethod As String

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
Friend WithEvents TabPg1 As System.Windows.Forms.TabPage
Friend WithEvents TabPg2 As System.Windows.Forms.TabPage
Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.TabCtl1 = New System.Windows.Forms.TabControl
Me.TabPg1 = New System.Windows.Forms.TabPage
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabPg2 = New System.Windows.Forms.TabPage
Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabCtl1.SuspendLayout()
Me.TabPg1.SuspendLayout()
Me.TabPg2.SuspendLayout()
Me.SuspendLayout()
'
'TabCtl1
'
Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabCtl1.Controls.Add(Me.TabPg1)
Me.TabCtl1.Controls.Add(Me.TabPg2)
Me.TabCtl1.Location = New System.Drawing.Point(4, 4)
Me.TabCtl1.Name = "TabCtl1"
Me.TabCtl1.SelectedIndex = 0
Me.TabCtl1.Size = New System.Drawing.Size(656, 380)
Me.TabCtl1.TabIndex = 0
'
'TabPg1
'
Me.TabPg1.Controls.Add(Me.Crv1)
Me.TabPg1.Location = New System.Drawing.Point(4, 22)
Me.TabPg1.Name = "TabPg1"
Me.TabPg1.Size = New System.Drawing.Size(648, 354)
Me.TabPg1.TabIndex = 0
Me.TabPg1.Text = "C/C Register"
'
'Crv1
'
Me.Crv1.ActiveViewIndex = -1
Me.Crv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.Crv1.Location = New System.Drawing.Point(0, 0)
Me.Crv1.Name = "Crv1"
Me.Crv1.ReportSource = Nothing
Me.Crv1.Size = New System.Drawing.Size(648, 352)
Me.Crv1.TabIndex = 1
'
'TabPg2
'
Me.TabPg2.Controls.Add(Me.Crv2)
Me.TabPg2.Location = New System.Drawing.Point(4, 22)
Me.TabPg2.Name = "TabPg2"
Me.TabPg2.Size = New System.Drawing.Size(648, 354)
Me.TabPg2.TabIndex = 1
Me.TabPg2.Text = "Totals"
'
'Crv2
'
Me.Crv2.ActiveViewIndex = -1
Me.Crv2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.Crv2.DisplayToolbar = False
Me.Crv2.Location = New System.Drawing.Point(0, 0)
Me.Crv2.Name = "Crv2"
Me.Crv2.ReportSource = Nothing
Me.Crv2.Size = New System.Drawing.Size(648, 352)
Me.Crv2.TabIndex = 2
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
Me.TabPg1.ResumeLayout(False)
Me.TabPg2.ResumeLayout(False)
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
   ReportPath = MyUtils.GetReportPath("PrtTA801.rpt", myTOWN._TOWNBR)
   With myreport1
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      .PrintOptions.ApplyPageMargins(WrkMargin)
    End If
    .SetDataSource(Wrkds1)
    .SetParameterValue("myreportTitle", WrkTypeDesc & " C/C Register")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyFromDate", MyFrmTA801B.DtPckFrom.Value)
    .SetParameterValue("MyToDate", MyFrmTA801B.DtPckTo.Value)
    .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTA801B.TxtFromGLYear.Text))
    .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTA801B.TxtToGLYear.Text))
    .SetParameterValue("MyFromReason", MyFrmTA801B.TxtFromReason.Text)
    .SetParameterValue("MyToreason", MyFrmTA801B.TxtToReason.Text)
    .SetParameterValue("MyReportType", WrkReportType)
    .SetParameterValue("MyGross", MyFrmTA801B.ChkGross.Checked)
    .SetParameterValue("MyMultMethod", WrkMultMethod)
    .SetParameterValue("MyTaxMethod", WrkTaxMethod)
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
   ReportPath = MyUtils.GetReportPath("PrtTA801Tot.rpt", myTOWN._TOWNBR)
   With myreport2
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      .PrintOptions.ApplyPageMargins(WrkMargin)
    End If
    .SetDataSource(Wrkds2)
    .SetParameterValue("myreportTitle", WrkTypeDesc & " C/C Register Totals")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyFromDate", MyFrmTA801B.DtPckFrom.Value)
    .SetParameterValue("MyToDate", MyFrmTA801B.DtPckTo.Value)
    .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTA801B.TxtFromGLYear.Text))
    .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTA801B.TxtToGLYear.Text))
    .SetParameterValue("MyFromReason", MyFrmTA801B.TxtFromReason.Text)
    .SetParameterValue("MyToreason", MyFrmTA801B.TxtToReason.Text)
    .SetParameterValue("MyReportType", WrkReportType)
    .SetParameterValue("MyGross", MyFrmTA801B.ChkGross.Checked)
    .SetParameterValue("MyMultMethod", WrkMultMethod)
    .SetParameterValue("MyTaxMethod", WrkTaxMethod)
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

Private Sub TabCtl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabCtl1.SelectedIndexChanged

End Sub
End Class






