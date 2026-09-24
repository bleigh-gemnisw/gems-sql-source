Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport4 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
	Dim myreport5 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
	Dim myreport6 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
	Dim myreportErr As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim WrkFile As String
  Friend WithEvents TpErr As System.Windows.Forms.TabPage
	Friend WithEvents CrvErr As CrystalDecisions.Windows.Forms.CrystalReportViewer
	Friend WithEvents TpD As System.Windows.Forms.TabPage
	Friend WithEvents Crv4 As CrystalDecisions.Windows.Forms.CrystalReportViewer
	Friend Wrkds1 As DataSet
	Friend Wrkds2 As DataSet
	Friend Wrkds3 As DataSet
	Friend Wrkds4 As DataSet
	Friend WrkdsTotMC As DataSet
	Friend WithEvents TpE As System.Windows.Forms.TabPage
 Friend WithEvents Crv5 As CrystalDecisions.Windows.Forms.CrystalReportViewer
 Friend WithEvents TpTotMC As System.Windows.Forms.TabPage
 Friend WithEvents Crv6 As CrystalDecisions.Windows.Forms.CrystalReportViewer
	Friend WrkdsErr As DataSet

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
Friend WithEvents TpB As System.Windows.Forms.TabPage
Friend WithEvents crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents TpA As System.Windows.Forms.TabPage
Friend WithEvents TpC As System.Windows.Forms.TabPage
Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.TabControl1 = New System.Windows.Forms.TabControl
Me.TpA = New System.Windows.Forms.TabPage
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpB = New System.Windows.Forms.TabPage
Me.crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpC = New System.Windows.Forms.TabPage
Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpD = New System.Windows.Forms.TabPage
Me.Crv4 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpE = New System.Windows.Forms.TabPage
Me.Crv5 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpErr = New System.Windows.Forms.TabPage
Me.CrvErr = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpTotMC = New System.Windows.Forms.TabPage
Me.Crv6 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabControl1.SuspendLayout()
Me.TpA.SuspendLayout()
Me.TpB.SuspendLayout()
Me.TpC.SuspendLayout()
Me.TpD.SuspendLayout()
Me.TpE.SuspendLayout()
Me.TpErr.SuspendLayout()
Me.TpTotMC.SuspendLayout()
Me.SuspendLayout()
'
'TabControl1
'
Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabControl1.Controls.Add(Me.TpA)
Me.TabControl1.Controls.Add(Me.TpB)
Me.TabControl1.Controls.Add(Me.TpTotMC)
Me.TabControl1.Controls.Add(Me.TpC)
Me.TabControl1.Controls.Add(Me.TpD)
Me.TabControl1.Controls.Add(Me.TpE)
Me.TabControl1.Controls.Add(Me.TpErr)
Me.TabControl1.Location = New System.Drawing.Point(10, 5)
Me.TabControl1.Name = "TabControl1"
Me.TabControl1.SelectedIndex = 0
Me.TabControl1.Size = New System.Drawing.Size(644, 376)
Me.TabControl1.TabIndex = 2
'
'TpA
'
Me.TpA.Controls.Add(Me.Crv1)
Me.TpA.Location = New System.Drawing.Point(4, 22)
Me.TpA.Name = "TpA"
Me.TpA.Size = New System.Drawing.Size(636, 350)
Me.TpA.TabIndex = 0
Me.TpA.Text = "Bridged Data"
Me.TpA.UseVisualStyleBackColor = True
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
'TpB
'
Me.TpB.Controls.Add(Me.crv2)
Me.TpB.Location = New System.Drawing.Point(4, 22)
Me.TpB.Name = "TpB"
Me.TpB.Size = New System.Drawing.Size(636, 350)
Me.TpB.TabIndex = 1
Me.TpB.Text = "CAMA Only"
Me.TpB.UseVisualStyleBackColor = True
Me.TpB.Visible = False
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
'TpC
'
Me.TpC.Controls.Add(Me.Crv3)
Me.TpC.Location = New System.Drawing.Point(4, 22)
Me.TpC.Name = "TpC"
Me.TpC.Size = New System.Drawing.Size(636, 350)
Me.TpC.TabIndex = 2
Me.TpC.Text = "GEMS ONLY "
Me.TpC.UseVisualStyleBackColor = True
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
'TpD
'
Me.TpD.Controls.Add(Me.Crv4)
Me.TpD.Location = New System.Drawing.Point(4, 22)
Me.TpD.Name = "TpD"
Me.TpD.Size = New System.Drawing.Size(636, 350)
Me.TpD.TabIndex = 4
Me.TpD.Text = "Net Diff"
Me.TpD.UseVisualStyleBackColor = True
'
'Crv4
'
Me.Crv4.ActiveViewIndex = -1
Me.Crv4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.Crv4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Crv4.DisplayStatusBar = False
Me.Crv4.DisplayToolbar = False
Me.Crv4.Location = New System.Drawing.Point(-2, -1)
Me.Crv4.Name = "Crv4"
Me.Crv4.SelectionFormula = ""
Me.Crv4.Size = New System.Drawing.Size(640, 352)
Me.Crv4.TabIndex = 5
Me.Crv4.ViewTimeSelectionFormula = ""
'
'TpE
'
Me.TpE.Controls.Add(Me.Crv5)
Me.TpE.Location = New System.Drawing.Point(4, 22)
Me.TpE.Name = "TpE"
Me.TpE.Size = New System.Drawing.Size(636, 350)
Me.TpE.TabIndex = 5
Me.TpE.Text = "Omitted"
Me.TpE.UseVisualStyleBackColor = True
'
'Crv5
'
Me.Crv5.ActiveViewIndex = -1
Me.Crv5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.Crv5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Crv5.DisplayStatusBar = False
Me.Crv5.DisplayToolbar = False
Me.Crv5.Location = New System.Drawing.Point(-2, -1)
Me.Crv5.Name = "Crv5"
Me.Crv5.SelectionFormula = ""
Me.Crv5.Size = New System.Drawing.Size(640, 352)
Me.Crv5.TabIndex = 5
Me.Crv5.ViewTimeSelectionFormula = ""
'
'TpErr
'
Me.TpErr.Controls.Add(Me.CrvErr)
Me.TpErr.Location = New System.Drawing.Point(4, 22)
Me.TpErr.Name = "TpErr"
Me.TpErr.Size = New System.Drawing.Size(636, 350)
Me.TpErr.TabIndex = 3
Me.TpErr.Text = "Error List"
Me.TpErr.UseVisualStyleBackColor = True
'
'CrvErr
'
Me.CrvErr.ActiveViewIndex = -1
Me.CrvErr.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.CrvErr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.CrvErr.DisplayStatusBar = False
Me.CrvErr.DisplayToolbar = False
Me.CrvErr.Location = New System.Drawing.Point(-2, -1)
Me.CrvErr.Name = "CrvErr"
Me.CrvErr.SelectionFormula = ""
Me.CrvErr.Size = New System.Drawing.Size(640, 352)
Me.CrvErr.TabIndex = 4
Me.CrvErr.ViewTimeSelectionFormula = ""
'
'TpTotMC
'
Me.TpTotMC.Controls.Add(Me.Crv6)
Me.TpTotMC.Location = New System.Drawing.Point(4, 22)
Me.TpTotMC.Name = "TpTotMC"
Me.TpTotMC.Size = New System.Drawing.Size(636, 350)
Me.TpTotMC.TabIndex = 6
Me.TpTotMC.Text = "CAMA File Totals"
Me.TpTotMC.UseVisualStyleBackColor = True
'
'Crv6
'
Me.Crv6.ActiveViewIndex = -1
Me.Crv6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.Crv6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Crv6.DisplayStatusBar = False
Me.Crv6.DisplayToolbar = False
Me.Crv6.Location = New System.Drawing.Point(-2, -1)
Me.Crv6.Name = "Crv6"
Me.Crv6.SelectionFormula = ""
Me.Crv6.Size = New System.Drawing.Size(640, 352)
Me.Crv6.TabIndex = 4
Me.Crv6.ViewTimeSelectionFormula = ""
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
Me.TpA.ResumeLayout(False)
Me.TpB.ResumeLayout(False)
Me.TpC.ResumeLayout(False)
Me.TpD.ResumeLayout(False)
Me.TpE.ResumeLayout(False)
Me.TpErr.ResumeLayout(False)
Me.TpTotMC.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If MyFrmTAC01B.rbtxreal.Checked Then
		WrkFile = "Real Estate"
	Else
		WrkFile = "Personal Property"
	End If

	RunReport1()
	RunReport2()
	RunReport3()
	If MyFrmTAC01B.ChkAssmnt.Checked Then
		RunReport4()
		RunReportTotMC()
	Else
		TabControl1.TabPages.Remove(TpD)
		TabControl1.TabPages.Remove(TpTotMC)
	End If
	If Wrkds4.Tables(0).Rows.Count > 0 Then
		RunReport5()
	Else
		TabControl1.TabPages.Remove(TpE)
	End If
	If WrkdsErr.Tables(0).Rows.Count > 0 Then
		RunReportErr()
	Else
		TabControl1.TabPages.Remove(TpErr)
	End If

End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
	myreport1.Close()
	myreport1.Dispose()
	myreport2.Close()
	myreport2.Dispose()
	myreport3.Close()
	myreport3.Dispose()
	myreport4.Close()
	myreport4.Dispose()
	myreport5.Close()
	myreport5.Dispose()
	myreport6.Close()
	myreport6.Dispose()
	myreportErr.Close()
	myreportErr.Dispose()
End Sub

	Private Sub RunReport1()
	 Dim ReportPath As String

	 Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTAC01A.rpt", myTOWN._TOWNBR)
	 With myreport1
		.Load(ReportPath)
		.SetDataSource(Wrkds1)
		.SetParameterValue("myreportTitle", "Bridged Records")
		.SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyPost", MyFrmTAC01B.ChkPost.Checked)
		.SetParameterValue("MyUpdName", MyFrmTAC01B.ChkName.Checked)
		.SetParameterValue("MyUpdOther", MyFrmTAC01B.ChkOther.Checked)
		.SetParameterValue("MyUpdAssmnt", MyFrmTAC01B.ChkAssmnt.Checked)
		.SetParameterValue("MyUpdExemption", MyFrmTAC01B.ChkExemption.Checked)
		.SetParameterValue("MyUpdCat", MyFrmTAC01B.ChkCat.Checked)
		.SetParameterValue("MyUpdPurchase", MyFrmTAC01B.ChkPurchase.Checked)
		.SetParameterValue("MyAddList", MyFrmTAC01B.chkaddlist.Checked)
		.SetParameterValue("MyFile", WrkFile)
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
   ReportPath = MyUtils.GetReportPath("PrtTAC01B.rpt", myTOWN._TOWNBR)
	 With myreport2
		.Load(ReportPath)
		.SetDataSource(Wrkds2)
		.SetParameterValue("myreportTitle", "Records In CAMA Not in GEMS (Adds)")
		.SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyFile", WrkFile)
		.SetParameterValue("MyAddr", MyFrmTAC01B.ChkAddr.Checked)
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
    ReportPath = MyUtils.GetReportPath("PrtTAC01C.rpt", myTOWN._TOWNBR)
    With myreport3
      .Load(ReportPath)
      .SetDataSource(Wrkds3)
      .SetParameterValue("myreportTitle", "Records In Gems Omitted from CAMA Bridge")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyFile", WrkFile)
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
  Private Sub RunReport4()
	 Dim ReportPath As String

	 Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTAC01D.rpt", myTOWN._TOWNBR)
	 With myreport4
		.Load(ReportPath)
		.SetDataSource(Wrkds1)
		.SetParameterValue("myreportTitle", "CAMA Gross differences")
		.SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyFile", WrkFile)
	 End With
	 With Crv4
     .DisplayToolbar = True
     .ShowGroupTreeButton = False
     .ShowCloseButton = False
     .ShowCopyButton = False
     .ShowRefreshButton = False
     .ShowParameterPanelButton = False
     .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
     .ReportSource = myreport4
     .Zoom(75)
   End With
	End Sub
	Private Sub RunReport5()
	 Dim ReportPath As String

	 Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTAC01E.rpt", myTOWN._TOWNBR)
	 With myreport5
		.Load(ReportPath)
		.SetDataSource(Wrkds4)
		.SetParameterValue("myreportTitle", "Omitted from CAMA bridge")
		.SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyFile", WrkFile)
	 End With
	 With Crv5
     .DisplayToolbar = True
     .ShowGroupTreeButton = False
     .ShowCloseButton = False
     .ShowCopyButton = False
     .ShowRefreshButton = False
     .ShowParameterPanelButton = False
     .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
     .ReportSource = myreport5
     .Zoom(75)
   End With
	End Sub
	Private Sub RunReportErr()
	 Dim ReportPath As String

	 Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTAC01Err.rpt", myTOWN._TOWNBR)
	 With myreportErr
		.Load(ReportPath)
		.SetDataSource(WrkdsErr)
		.SetParameterValue("myreportTitle", "Error Report")
		.SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyFile", WrkFile)
	 End With
	 With CrvErr
     .DisplayToolbar = True
     .ShowGroupTreeButton = False
     .ShowCloseButton = False
     .ShowCopyButton = False
     .ShowRefreshButton = False
     .ShowParameterPanelButton = False
     .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
     .ReportSource = myreportErr
     .Zoom(75)
   End With
	End Sub
	Private Sub RunReportTotMC()
	 Dim ReportPath As String

	 Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTAC01TotMC.rpt", myTOWN._TOWNBR)
	 With myreport6
		.Load(ReportPath)
		.SetDataSource(WrkdsTotMC)
		.SetParameterValue("myreportTitle", "CAMA File Major Category Totals")
		.SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyFile", WrkFile)
	 End With
	 With Crv6
     .DisplayToolbar = True
     .ShowGroupTreeButton = False
     .ShowCloseButton = False
     .ShowCopyButton = False
     .ShowRefreshButton = False
     .ShowParameterPanelButton = False
     .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
     .ReportSource = myreport6
     .Zoom(75)
   End With
	End Sub
End Class






