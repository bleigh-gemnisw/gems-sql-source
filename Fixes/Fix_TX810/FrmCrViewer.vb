Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
	Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
	Dim WrkMargin As CrystalDecisions.Shared.PageMargins
  Friend wrkds As DataSet = New DataSet
  Friend wrkdsTot As DataSet = New DataSet
	Friend wrkdsErr As DataSet = New DataSet
	Friend WithEvents TpDetails As System.Windows.Forms.TabPage
  Friend WithEvents crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpTotals As System.Windows.Forms.TabPage
	Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
	Friend WithEvents TpErrors As System.Windows.Forms.TabPage
 Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WrkAsofDate As String


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
Me.TpDetails = New System.Windows.Forms.TabPage
Me.crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabControl1 = New System.Windows.Forms.TabControl
Me.TpTotals = New System.Windows.Forms.TabPage
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpErrors = New System.Windows.Forms.TabPage
Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpDetails.SuspendLayout()
Me.TabControl1.SuspendLayout()
Me.TpTotals.SuspendLayout()
Me.TpErrors.SuspendLayout()
Me.SuspendLayout()
'
'TpDetails
'
Me.TpDetails.Controls.Add(Me.crv2)
Me.TpDetails.Location = New System.Drawing.Point(4, 22)
Me.TpDetails.Name = "TpDetails"
Me.TpDetails.Size = New System.Drawing.Size(636, 350)
Me.TpDetails.TabIndex = 1
Me.TpDetails.Text = "Details"
Me.TpDetails.UseVisualStyleBackColor = True
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
'TabControl1
'
Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabControl1.Controls.Add(Me.TpTotals)
Me.TabControl1.Controls.Add(Me.TpDetails)
Me.TabControl1.Controls.Add(Me.TpErrors)
Me.TabControl1.Location = New System.Drawing.Point(12, 4)
Me.TabControl1.Name = "TabControl1"
Me.TabControl1.SelectedIndex = 0
Me.TabControl1.Size = New System.Drawing.Size(644, 376)
Me.TabControl1.TabIndex = 1
'
'TpTotals
'
Me.TpTotals.Controls.Add(Me.Crv1)
Me.TpTotals.Location = New System.Drawing.Point(4, 22)
Me.TpTotals.Name = "TpTotals"
Me.TpTotals.Size = New System.Drawing.Size(636, 350)
Me.TpTotals.TabIndex = 2
Me.TpTotals.Text = "Totals"
Me.TpTotals.UseVisualStyleBackColor = True
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
Me.Crv1.Location = New System.Drawing.Point(-2, -1)
Me.Crv1.Name = "Crv1"
Me.Crv1.SelectionFormula = ""
Me.Crv1.Size = New System.Drawing.Size(640, 352)
Me.Crv1.TabIndex = 3
Me.Crv1.ViewTimeSelectionFormula = ""
'
'TpErrors
'
Me.TpErrors.Controls.Add(Me.Crv3)
Me.TpErrors.Location = New System.Drawing.Point(4, 22)
Me.TpErrors.Name = "TpErrors"
Me.TpErrors.Size = New System.Drawing.Size(636, 350)
Me.TpErrors.TabIndex = 3
Me.TpErrors.Text = "Errors"
Me.TpErrors.UseVisualStyleBackColor = True
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
Me.TpDetails.ResumeLayout(False)
Me.TabControl1.ResumeLayout(False)
Me.TpTotals.ResumeLayout(False)
Me.TpErrors.ResumeLayout(False)
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
    RunReportTotals()
		RunReport()
		If wrkdsErr.Tables(0).Rows.Count = 0 Then
			TabControl1.TabPages.Remove(TpErrors)
		Else
			RunReportErr()
		End If
 End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport.Close()
  myreport.Dispose()
  myreport2.Close()
  myreport2.Dispose()
	myreport3.Close()
	myreport3.Dispose()
End Sub
  Private Sub RunReportTotals()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTX810Tot.rpt", myTOWN._TOWNBR)

    With myreport
      .Load(ReportPath)
      If MyReportLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.ApplyPageMargins(WrkMargin)
      End If
      .SetDataSource(wrkdsTot)
      .SetParameterValue("myreportTitle", "Delinquent Bill Totals")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyAsofDate", WrkAsofDate)
      .SetParameterValue("MyDistrict", MyUtils.CnvSng(MyFrmTX810B.TxtDist.Text))
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

  Private Sub RunReport()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTX810.rpt", myTOWN._TOWNBR)

    With myreport2
      .Load(ReportPath)
      If MyReportLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.ApplyPageMargins(WrkMargin)
      End If
      .SetDataSource(wrkds)
      .SetParameterValue("myreportTitle", "Delinquent Bill Report")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyAsofDate", WrkAsofDate)
      .SetParameterValue("MyDistrict", MyUtils.CnvSng(MyFrmTX810B.TxtDist.Text))
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

	Private Sub RunReportErr()
	 Dim ReportPath As String

	 Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTX810.rpt", myTOWN._TOWNBR)

	 With myreport3
		.Load(ReportPath)
		If MyReportLandscape Then
			.PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
			.PrintOptions.ApplyPageMargins(WrkMargin)
		End If
		.SetDataSource(wrkdsErr)
		.SetParameterValue("myreportTitle", "Delinquent Bill File Errors (Invalid Length)")
		.SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyAsofDate", WrkAsofDate)
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

Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

End Sub
End Class






