Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim WrkMargin As CrystalDecisions.Shared.PageMargins
  Friend wrkds As DataSet = New DataSet
  Friend WithEvents TpTotalsB As System.Windows.Forms.TabPage
  Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend wrkds2 As DataSet = New DataSet

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
Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents TpDetails As System.Windows.Forms.TabPage
Friend WithEvents TpTotals As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.TabControl1 = New System.Windows.Forms.TabControl
Me.TpDetails = New System.Windows.Forms.TabPage
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpTotals = New System.Windows.Forms.TabPage
Me.crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpTotalsB = New System.Windows.Forms.TabPage
Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabControl1.SuspendLayout()
Me.TpDetails.SuspendLayout()
Me.TpTotals.SuspendLayout()
Me.TpTotalsB.SuspendLayout()
Me.SuspendLayout()
'
'TabControl1
'
Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabControl1.Controls.Add(Me.TpDetails)
Me.TabControl1.Controls.Add(Me.TpTotals)
Me.TabControl1.Controls.Add(Me.TpTotalsB)
Me.TabControl1.Location = New System.Drawing.Point(12, 4)
Me.TabControl1.Name = "TabControl1"
Me.TabControl1.SelectedIndex = 0
Me.TabControl1.Size = New System.Drawing.Size(644, 376)
Me.TabControl1.TabIndex = 1
'
'TpDetails
'
Me.TpDetails.Controls.Add(Me.Crv1)
Me.TpDetails.Location = New System.Drawing.Point(4, 22)
Me.TpDetails.Name = "TpDetails"
Me.TpDetails.Size = New System.Drawing.Size(636, 350)
Me.TpDetails.TabIndex = 0
Me.TpDetails.Text = "Details"
Me.TpDetails.UseVisualStyleBackColor = True
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
'TpTotals
'
Me.TpTotals.Controls.Add(Me.crv2)
Me.TpTotals.Location = New System.Drawing.Point(4, 22)
Me.TpTotals.Name = "TpTotals"
Me.TpTotals.Size = New System.Drawing.Size(636, 350)
Me.TpTotals.TabIndex = 1
Me.TpTotals.Text = "Totals by Year/Type"
Me.TpTotals.UseVisualStyleBackColor = True
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
'TpTotalsB
'
Me.TpTotalsB.Controls.Add(Me.Crv3)
Me.TpTotalsB.Location = New System.Drawing.Point(4, 22)
Me.TpTotalsB.Name = "TpTotalsB"
Me.TpTotalsB.Size = New System.Drawing.Size(636, 350)
Me.TpTotalsB.TabIndex = 2
Me.TpTotalsB.Text = "Totals by Type/Year"
Me.TpTotalsB.UseVisualStyleBackColor = True
'
'Crv3
'
Me.Crv3.ActiveViewIndex = -1
Me.Crv3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.Crv3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Crv3.DisplayToolbar = False
Me.Crv3.Location = New System.Drawing.Point(-2, -1)
Me.Crv3.Name = "Crv3"
Me.Crv3.SelectionFormula = ""
Me.Crv3.Size = New System.Drawing.Size(640, 352)
Me.Crv3.TabIndex = 3
Me.Crv3.ViewTimeSelectionFormula = ""
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
Me.TpDetails.ResumeLayout(False)
Me.TpTotals.ResumeLayout(False)
Me.TpTotalsB.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    With WrkMargin
      .leftMargin = 500
      .rightMargin = 150
      .topMargin = 250
      .bottomMargin = 150
    End With
    RunReport1()
    RunReport2()
    RunReport3()
 End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport.Close()
  myreport.Dispose()
  myreport2.Close()
  myreport2.Dispose()
  myreport3.Close()
  myreport3.Dispose()
End Sub

  Private Sub RunReport1()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTX903.rpt", myTOWN._TOWNBR)
   With myreport
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      .PrintOptions.ApplyPageMargins(WrkMargin)
    End If
    .SetDataSource(wrkds)
    .SetParameterValue("myreportTitle", "Suspense History List")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		If MyFrmTX903B.DtPckFrom.Checked Then
			.SetParameterValue("MyFromDate", Format(MyFrmTX903B.DtPckFrom.Value, "M/d/yyyy"))
		Else
			.SetParameterValue("MyFromDate", "")
		End If
    If MyFrmTX903B.DtPckTo.Checked Then
      .SetParameterValue("MyToDate", MyFrmTX903B.DtPckTo.Value)
    Else
      .SetParameterValue("MyToDate", "")
    End If
    .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTX903B.TxtFromGLYear.Text))
    .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTX903B.TxtToGLYear.Text))
    .SetParameterValue("MyTypes", MyTypes)
    .SetParameterValue("MySuspCd", MyFrmTX903B.TxtSusp.Text)
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
   ReportPath = MyUtils.GetReportPath("PrtTX903Tot.rpt", myTOWN._TOWNBR)
   With myreport2
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      .PrintOptions.ApplyPageMargins(WrkMargin)
    End If
    .SetDataSource(wrkds2)
    .SetParameterValue("myreportTitle", "Suspense History Totals by Year/Type")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    If MyFrmTX903B.DtPckFrom.Checked Then
      .SetParameterValue("MyFromDate", Format(MyFrmTX903B.DtPckFrom.Value, "M/d/yyyy"))
    Else
      .SetParameterValue("MyFromDate", "")
    End If
    If MyFrmTX903B.DtPckTo.Checked Then
      .SetParameterValue("MyToDate", MyFrmTX903B.DtPckTo.Value)
    Else
      .SetParameterValue("MyToDate", "")
    End If
    .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTX903B.TxtFromGLYear.Text))
    .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTX903B.TxtToGLYear.Text))
    .SetParameterValue("MyTypes", MyTypes)
    .SetParameterValue("MySuspCd", MyFrmTX903B.TxtSusp.Text)
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
   ReportPath = MyUtils.GetReportPath("PrtTX903TotB.rpt", myTOWN._TOWNBR)
   With myreport3
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      .PrintOptions.ApplyPageMargins(WrkMargin)
    End If
    .SetDataSource(wrkds2)
    .SetParameterValue("myreportTitle", "Suspense History Totals by Type/Year")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    If MyFrmTX903B.DtPckFrom.Checked Then
      .SetParameterValue("MyFromDate", Format(MyFrmTX903B.DtPckFrom.Value, "M/d/yyyy"))
    Else
      .SetParameterValue("MyFromDate", "")
    End If
    If MyFrmTX903B.DtPckTo.Checked Then
      .SetParameterValue("MyToDate", MyFrmTX903B.DtPckTo.Value)
    Else
      .SetParameterValue("MyToDate", "")
    End If
    .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTX903B.TxtFromGLYear.Text))
    .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTX903B.TxtToGLYear.Text))
    .SetParameterValue("MyTypes", MyTypes)
    .SetParameterValue("MySuspCd", MyFrmTX903B.TxtSusp.Text)
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

End Class






