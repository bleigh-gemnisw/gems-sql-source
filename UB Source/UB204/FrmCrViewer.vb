Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
	Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
	Friend wrkds As DataSet = New DataSet
	Friend wrkdsTot As DataSet = New DataSet
	Friend WrkUBType As String
  Friend Wrksort As String
	Friend WrkCaveat As Decimal
	Dim WrkBillType As String
	Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
	Friend WithEvents TpDetails As System.Windows.Forms.TabPage
	Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
	Friend WithEvents TpTotals As System.Windows.Forms.TabPage
	Friend WithEvents crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Dim WrkFamily As String

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
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpTotals = New System.Windows.Forms.TabPage
Me.crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
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
Me.TabControl1.Controls.Add(Me.TpDetails)
Me.TabControl1.Controls.Add(Me.TpTotals)
Me.TabControl1.Location = New System.Drawing.Point(10, 5)
Me.TabControl1.Name = "TabControl1"
Me.TabControl1.SelectedIndex = 0
Me.TabControl1.Size = New System.Drawing.Size(644, 376)
Me.TabControl1.TabIndex = 2
'
'TpDetails
'
Me.TpDetails.Controls.Add(Me.Crv1)
Me.TpDetails.Location = New System.Drawing.Point(4, 22)
Me.TpDetails.Name = "TpDetails"
Me.TpDetails.Size = New System.Drawing.Size(636, 350)
Me.TpDetails.TabIndex = 0
Me.TpDetails.Text = "Details"
'
'Crv1
'
Me.Crv1.ActiveViewIndex = -1
Me.Crv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.Crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
Me.TpTotals.Text = "Totals"
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

		WrkBillType = GetUTTypeDesc(WrkUBType)
		WrkFamily = GetUTTYPEFamily(WrkUBType)

		RunReport1()
		RunReport2()
 End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
	myreport.Close()
	myreport.Dispose()
	myreport2.Close()
	myreport2.Dispose()
End Sub
	Private Sub RunReport1()
	 Dim ReportPath As String

	 Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtUB204.rpt", myTOWN._TOWNBR)
		With myreport
		.Load(ReportPath)
		.SetDataSource(wrkds)
		.SetParameterValue("myreportTitle", WrkBillType & " Amortization Schedule")
		.SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MySort", Wrksort)
		If WrkFamily = "A" And WrkCaveat > 0 Then
			.SetParameterValue("MyCaveat", Format(WrkCaveat, "Currency"))
		Else
			.SetParameterValue("MyCaveat", String.Empty)
		End If
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
   ReportPath = MyUtils.GetReportPath("PrtUB204Tot.rpt", myTOWN._TOWNBR)
		With myreport2
		.Load(ReportPath)
		.SetDataSource(wrkdsTot)
		.SetParameterValue("myreportTitle", WrkBillType & " Amortization Schedule Totals")
		.SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
	 End With
	 With crv2
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
End Class







