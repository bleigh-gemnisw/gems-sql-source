Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
	Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
	Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
	Dim WrkMargin As CrystalDecisions.Shared.PageMargins
 Friend WithEvents TabCtl1 As System.Windows.Forms.TabControl
 Friend WithEvents TpDetail As System.Windows.Forms.TabPage
 Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
 Friend WithEvents TpTotType As System.Windows.Forms.TabPage
 Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
 Friend WithEvents TpTotYear As System.Windows.Forms.TabPage
 Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
	Friend wrkds As DataSet = New DataSet
	Friend WrkBatchNo As Integer

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
Me.TpDetail = New System.Windows.Forms.TabPage
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpTotType = New System.Windows.Forms.TabPage
Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpTotYear = New System.Windows.Forms.TabPage
Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabCtl1.SuspendLayout()
Me.TpDetail.SuspendLayout()
Me.TpTotType.SuspendLayout()
Me.TpTotYear.SuspendLayout()
Me.SuspendLayout()
'
'TabCtl1
'
Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabCtl1.Controls.Add(Me.TpDetail)
Me.TabCtl1.Controls.Add(Me.TpTotType)
Me.TabCtl1.Controls.Add(Me.TpTotYear)
Me.TabCtl1.Location = New System.Drawing.Point(1, 2)
Me.TabCtl1.Name = "TabCtl1"
Me.TabCtl1.SelectedIndex = 0
Me.TabCtl1.Size = New System.Drawing.Size(660, 387)
Me.TabCtl1.TabIndex = 1
'
'TpDetail
'
Me.TpDetail.Controls.Add(Me.Crv1)
Me.TpDetail.Location = New System.Drawing.Point(4, 22)
Me.TpDetail.Name = "TpDetail"
Me.TpDetail.Size = New System.Drawing.Size(652, 361)
Me.TpDetail.TabIndex = 0
Me.TpDetail.Text = "Detail "
Me.TpDetail.UseVisualStyleBackColor = True
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
Me.Crv1.Size = New System.Drawing.Size(636, 347)
Me.Crv1.TabIndex = 2
Me.Crv1.ViewTimeSelectionFormula = ""
'
'TpTotType
'
Me.TpTotType.Controls.Add(Me.Crv2)
Me.TpTotType.Location = New System.Drawing.Point(4, 22)
Me.TpTotType.Name = "TpTotType"
Me.TpTotType.Size = New System.Drawing.Size(652, 361)
Me.TpTotType.TabIndex = 2
Me.TpTotType.Text = "Totals by Type/Year"
Me.TpTotType.UseVisualStyleBackColor = True
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
Me.Crv2.Location = New System.Drawing.Point(8, 7)
Me.Crv2.Name = "Crv2"
Me.Crv2.SelectionFormula = ""
Me.Crv2.Size = New System.Drawing.Size(636, 347)
Me.Crv2.TabIndex = 4
Me.Crv2.ViewTimeSelectionFormula = ""
'
'TpTotYear
'
Me.TpTotYear.Controls.Add(Me.Crv3)
Me.TpTotYear.Location = New System.Drawing.Point(4, 22)
Me.TpTotYear.Name = "TpTotYear"
Me.TpTotYear.Size = New System.Drawing.Size(652, 361)
Me.TpTotYear.TabIndex = 3
Me.TpTotYear.Text = "Totals by Year/Type"
Me.TpTotYear.UseVisualStyleBackColor = True
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
Me.Crv3.Location = New System.Drawing.Point(8, 7)
Me.Crv3.Name = "Crv3"
Me.Crv3.SelectionFormula = ""
Me.Crv3.Size = New System.Drawing.Size(636, 347)
Me.Crv3.TabIndex = 5
Me.Crv3.ViewTimeSelectionFormula = ""
'
'FrmCrViewer
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(659, 386)
Me.Controls.Add(Me.TabCtl1)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmCrViewer"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
Me.Text = "CrViewer"
Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
Me.TabCtl1.ResumeLayout(False)
Me.TpDetail.ResumeLayout(False)
Me.TpTotType.ResumeLayout(False)
Me.TpTotYear.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		With WrkMargin
			.leftMargin = 150
			.rightMargin = 150
			.topMargin = 150
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
   ReportPath = MyUtils.GetReportPath("PrtTXA05.rpt", myTOWN._TOWNBR)
   With myreport
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      .PrintOptions.ApplyPageMargins(WrkMargin)
    End If
    .SetDataSource(wrkds)
    .SetParameterValue("myreportTitle", "Create Penny Batch")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTXA05B.TxtFromGLYear.Text))
    .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTXA05B.TxtToGLYear.Text))
    .SetParameterValue("MyTypes", MyTypes)
    .SetParameterValue("MyUnder", MyUtils.CnvSng(MyFrmTXA05B.TxtUnder.Text))
    .SetParameterValue("MyOver", MyUtils.CnvSng(MyFrmTXA05B.TxtOver.Text))
    .SetParameterValue("MyBatchNo", WrkBatchNo)
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
   ReportPath = MyUtils.GetReportPath("PrtTXA05Tot.rpt", myTOWN._TOWNBR)
   With myreport2
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      .PrintOptions.ApplyPageMargins(WrkMargin)
    End If
    .SetDataSource(wrkds)
    .SetParameterValue("myreportTitle", "Penny Batch Totals by Type")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTXA05B.TxtFromGLYear.Text))
    .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTXA05B.TxtToGLYear.Text))
    .SetParameterValue("MyTypes", MyTypes)
    .SetParameterValue("MyUnder", MyUtils.CnvSng(MyFrmTXA05B.TxtUnder.Text))
    .SetParameterValue("MyOver", MyUtils.CnvSng(MyFrmTXA05B.TxtOver.Text))
    .SetParameterValue("MyBatchNo", WrkBatchNo)
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
   ReportPath = MyUtils.GetReportPath("PrtTXA05TotB.rpt", myTOWN._TOWNBR)
   With myreport3
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      .PrintOptions.ApplyPageMargins(WrkMargin)
    End If
    .SetDataSource(wrkds)
    .SetParameterValue("myreportTitle", "Penny Batch Totals by Year")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTXA05B.TxtFromGLYear.Text))
    .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTXA05B.TxtToGLYear.Text))
    .SetParameterValue("MyTypes", MyTypes)
    .SetParameterValue("MyUnder", MyUtils.CnvSng(MyFrmTXA05B.TxtUnder.Text))
    .SetParameterValue("MyOver", MyUtils.CnvSng(MyFrmTXA05B.TxtOver.Text))
    .SetParameterValue("MyBatchNo", WrkBatchNo)
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






