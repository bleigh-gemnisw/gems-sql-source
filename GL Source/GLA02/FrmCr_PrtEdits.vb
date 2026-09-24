Public Class FrmCr_PrtEdits
  Inherits System.Windows.Forms.Form
  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim WrkMargin As CrystalDecisions.Shared.PageMargins
  Friend Wrkds As DataSet
	Friend Wrkds2 As DataSet
  Friend WrkdsDtl As DataSet
  Friend WrkPost As Boolean
  Friend WithEvents TpDetail As System.Windows.Forms.TabPage
  Friend WithEvents crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
	Friend WrkError As Boolean

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
	Friend WithEvents TabCtl1 As System.Windows.Forms.TabControl
	Friend WithEvents TpSeq As System.Windows.Forms.TabPage
	Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
	Friend WithEvents TpAcct As System.Windows.Forms.TabPage
Friend WithEvents PrtDialog As System.Windows.Forms.PrintDialog
Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.TabCtl1 = New System.Windows.Forms.TabControl
Me.TpSeq = New System.Windows.Forms.TabPage
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpAcct = New System.Windows.Forms.TabPage
Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.PrtDialog = New System.Windows.Forms.PrintDialog
Me.TpDetail = New System.Windows.Forms.TabPage
Me.crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabCtl1.SuspendLayout()
Me.TpSeq.SuspendLayout()
Me.TpAcct.SuspendLayout()
Me.TpDetail.SuspendLayout()
Me.SuspendLayout()
'
'TabCtl1
'
Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabCtl1.Controls.Add(Me.TpSeq)
Me.TabCtl1.Controls.Add(Me.TpAcct)
Me.TabCtl1.Controls.Add(Me.TpDetail)
Me.TabCtl1.Location = New System.Drawing.Point(0, 8)
Me.TabCtl1.Name = "TabCtl1"
Me.TabCtl1.SelectedIndex = 0
Me.TabCtl1.Size = New System.Drawing.Size(640, 344)
Me.TabCtl1.TabIndex = 0
'
'TpSeq
'
Me.TpSeq.Controls.Add(Me.Crv1)
Me.TpSeq.Location = New System.Drawing.Point(4, 22)
Me.TpSeq.Name = "TpSeq"
Me.TpSeq.Size = New System.Drawing.Size(632, 318)
Me.TpSeq.TabIndex = 0
Me.TpSeq.Text = "Sequential Order"
Me.TpSeq.UseVisualStyleBackColor = True
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
Me.Crv1.Size = New System.Drawing.Size(616, 304)
Me.Crv1.TabIndex = 2
Me.Crv1.ViewTimeSelectionFormula = ""
'
'TpAcct
'
Me.TpAcct.Controls.Add(Me.Crv2)
Me.TpAcct.Location = New System.Drawing.Point(4, 22)
Me.TpAcct.Name = "TpAcct"
Me.TpAcct.Size = New System.Drawing.Size(632, 318)
Me.TpAcct.TabIndex = 2
Me.TpAcct.Text = "Acct Order"
Me.TpAcct.UseVisualStyleBackColor = True
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
Me.Crv2.Size = New System.Drawing.Size(616, 304)
Me.Crv2.TabIndex = 4
Me.Crv2.ViewTimeSelectionFormula = ""
'
'TpDetail
'
Me.TpDetail.Controls.Add(Me.crv3)
Me.TpDetail.Location = New System.Drawing.Point(4, 22)
Me.TpDetail.Name = "TpDetail"
Me.TpDetail.Size = New System.Drawing.Size(632, 318)
Me.TpDetail.TabIndex = 3
Me.TpDetail.Text = "Detail"
Me.TpDetail.UseVisualStyleBackColor = True
'
'crv3
'
Me.crv3.ActiveViewIndex = -1
Me.crv3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.crv3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.crv3.DisplayStatusBar = False
Me.crv3.DisplayToolbar = False
Me.crv3.Location = New System.Drawing.Point(8, 7)
Me.crv3.Name = "crv3"
Me.crv3.SelectionFormula = ""
Me.crv3.Size = New System.Drawing.Size(616, 304)
Me.crv3.TabIndex = 3
Me.crv3.ViewTimeSelectionFormula = ""
'
'FrmCr_PrtEdits
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(648, 358)
Me.Controls.Add(Me.TabCtl1)
Me.KeyPreview = True
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmCr_PrtEdits"
Me.Text = "Print Batch Edits (Press Enter to print all)"
Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
Me.TabCtl1.ResumeLayout(False)
Me.TpSeq.ResumeLayout(False)
Me.TpAcct.ResumeLayout(False)
Me.TpDetail.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

	Private Sub FrmCr_PrtEdits_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		With WrkMargin
			.leftMargin = 500
			.rightMargin = 150
			.topMargin = 250
			.bottomMargin = 150
		End With

		If WrkPost Then
			Me.Text = "** POSTING RUN ** - " & Me.Text
		End If

		RptEditBySeqNo()
    RptEditByAcct()
    RptEditDetail()

	End Sub
  Private Sub FrmCr_PrtEdits_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Dim WrkPrinter As String

    With WrkMargin
      .leftMargin = 150
      .rightMargin = 150
      .topMargin = 150
      .bottomMargin = 150
    End With

    WrkPrinter = ""
    If e.KeyCode = Keys.Enter Then
      PrtDialog.PrinterSettings = New Printing.PrinterSettings
      Dim result As DialogResult = PrtDialog.ShowDialog()
      If (result = Windows.Forms.DialogResult.OK) Then
        WrkPrinter = PrtDialog.PrinterSettings.PrinterName()
      End If

      With myreport1
        If MyReportLandscape Then
          .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
          .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
          .PrintOptions.ApplyPageMargins(WrkMargin)
        End If
        .PrintOptions.PrinterName = WrkPrinter
        .PrintToPrinter(1, True, 0, 0)
      End With
      With myreport2
        If MyReportLandscape Then
          .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
          .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
          .PrintOptions.ApplyPageMargins(WrkMargin)
        End If
        .PrintOptions.PrinterName = WrkPrinter
        .PrintToPrinter(1, True, 0, 0)
      End With
    End If
  End Sub

  Private Sub FrmCr_PrtEdits_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
	myreport1.Close()
  myreport1.Dispose()
  myreport2.Close()
  myreport2.Dispose()
  myreport3.Close()
  myreport3.Dispose()
End Sub
	Private Sub RptEditBySeqNo()
	 Dim ReportPath As String

   ReportPath = MyUtils.GetReportPath("PrtGLA02.rpt", myTOWN._TOWNBR)
	 With myreport1
		.Load(ReportPath)
		If MyReportLandscape Then
			.PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
			.PrintOptions.ApplyPageMargins(WrkMargin)
		End If
		.SetDataSource(Wrkds)
		.SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyReportTitle", "Daily Tax Receipts To Be Posted To LEDGER")
		.SetParameterValue("MyPost", WrkPost)
		.SetParameterValue("MyError", WrkError)
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
	Private Sub RptEditByAcct()
	 Dim ReportPath As String

   ReportPath = MyUtils.GetReportPath("PrtGLA02B.rpt", myTOWN._TOWNBR)
	 With myreport2
		.Load(ReportPath)
		If MyReportLandscape Then
			.PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
			.PrintOptions.ApplyPageMargins(WrkMargin)
		End If
		.SetDataSource(Wrkds2)
		.SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyReportTitle", "Daily Tax Receipts To Be Posted To LEDGER")
		.SetParameterValue("MyPost", WrkPost)
		.SetParameterValue("MyError", WrkError)
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
  Private Sub RptEditDetail()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtGLA02Dtl.rpt", myTOWN._TOWNBR)
   With myreport3
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      .PrintOptions.ApplyPageMargins(WrkMargin)
    End If
    .SetDataSource(WrkdsDtl)
    .SetParameterValue("myreportTitle", "Batch Details")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
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
