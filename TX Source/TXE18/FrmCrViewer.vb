Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim WrkMargin As CrystalDecisions.Shared.PageMargins
  Friend wrkds As DataSet = New DataSet
  Friend wrkdsTot As DataSet = New DataSet
  Friend WrkFromCode As String
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpDetails As System.Windows.Forms.TabPage
  Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpTotals As System.Windows.Forms.TabPage
  Friend WithEvents crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WrkToCode As String

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
Me.TpDetails = New System.Windows.Forms.TabPage
Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpTotals = New System.Windows.Forms.TabPage
Me.crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabControl1.SuspendLayout()
Me.TpDetails.SuspendLayout()
Me.TpTotals.SuspendLayout()
Me.SuspendLayout()
'
'TabControl1
'
Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabControl1.Controls.Add(Me.TpTotals)
Me.TabControl1.Controls.Add(Me.TpDetails)
Me.TabControl1.Location = New System.Drawing.Point(0, -2)
Me.TabControl1.Name = "TabControl1"
Me.TabControl1.SelectedIndex = 0
Me.TabControl1.Size = New System.Drawing.Size(665, 391)
Me.TabControl1.TabIndex = 2
'
'TpDetails
'
Me.TpDetails.Controls.Add(Me.Crv2)
Me.TpDetails.Location = New System.Drawing.Point(4, 22)
Me.TpDetails.Name = "TpDetails"
Me.TpDetails.Size = New System.Drawing.Size(657, 365)
Me.TpDetails.TabIndex = 0
Me.TpDetails.Text = "Details"
Me.TpDetails.UseVisualStyleBackColor = True
'
'Crv2
'
Me.Crv2.ActiveViewIndex = -1
Me.Crv2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.Crv2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Crv2.Location = New System.Drawing.Point(-4, 0)
Me.Crv2.Name = "Crv2"
Me.Crv2.SelectionFormula = ""
Me.Crv2.Size = New System.Drawing.Size(665, 367)
Me.Crv2.TabIndex = 1
Me.Crv2.ViewTimeSelectionFormula = ""
'
'TpTotals
'
Me.TpTotals.Controls.Add(Me.crv1)
Me.TpTotals.Location = New System.Drawing.Point(4, 22)
Me.TpTotals.Name = "TpTotals"
Me.TpTotals.Size = New System.Drawing.Size(657, 365)
Me.TpTotals.TabIndex = 1
Me.TpTotals.Text = "Totals"
Me.TpTotals.UseVisualStyleBackColor = True
'
'crv1
'
Me.crv1.ActiveViewIndex = -1
Me.crv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.crv1.DisplayStatusBar = False
Me.crv1.DisplayToolbar = False
Me.crv1.Location = New System.Drawing.Point(-2, -1)
Me.crv1.Name = "crv1"
Me.crv1.SelectionFormula = ""
Me.crv1.Size = New System.Drawing.Size(661, 367)
Me.crv1.TabIndex = 2
Me.crv1.ViewTimeSelectionFormula = ""
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
		RunReport()
		If MyFrmTXE18B.ChkDetail.Checked Then
			RunReport2()
		Else
			TabControl1.TabPages.Remove(TpDetails)
		End If
 End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
	myreport.Close()
	myreport.Dispose()
End Sub

	Private Sub RunReport()
	 Dim ReportPath As String

	 Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTXE18.rpt", myTOWN._TOWNBR)
	 With myreport
		.Load(ReportPath)
		If MyReportLandscape Then
			.PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
			.PrintOptions.ApplyPageMargins(WrkMargin)
		End If
		.SetDataSource(wrkdsTot)
		.SetParameterValue("myreportTitle", "Fees Collected Totals")
		.SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyFromDate", MyFrmTXE18B.DtPckFrom.Value)
		.SetParameterValue("MyToDate", MyFrmTXE18B.DtPckTo.Value)
		.SetParameterValue("MyTypes", MyTypes)
		.SetParameterValue("MyFromCode", WrkFromCode)
		.SetParameterValue("MyToCode", WrkToCode)
	 End With
	 With crv1
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
   ReportPath = MyUtils.GetReportPath("PrtTXE18B.rpt", myTOWN._TOWNBR)
	 With myreport2
		.Load(ReportPath)
		If MyReportLandscape Then
			.PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
			.PrintOptions.ApplyPageMargins(WrkMargin)
		End If
		.SetDataSource(wrkds)
		.SetParameterValue("myreportTitle", "Fees Collected")
		.SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyFromDate", MyFrmTXE18B.DtPckFrom.Value)
		.SetParameterValue("MyToDate", MyFrmTXE18B.DtPckTo.Value)
		.SetParameterValue("MyTypes", MyTypes)
		.SetParameterValue("MyFromCode", WrkFromCode)
		.SetParameterValue("MyToCode", WrkToCode)
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






