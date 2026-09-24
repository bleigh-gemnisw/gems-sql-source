Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend wrkds As DataSet = New DataSet
  Friend wrkds2 As DataSet = New DataSet
  Friend wrkdsDD As DataSet = New DataSet
  Friend wrkdsDD2 As DataSet = New DataSet
  Friend WithEvents TpStubs As System.Windows.Forms.TabPage
  Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Dim wrkdsSTUB As DataSet = New DataSet
  Dim wrkdsSTUB2 As DataSet = New DataSet

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
Friend WithEvents crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents TpDirect As System.Windows.Forms.TabPage
Friend WithEvents TpChecks As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.TabCtl1 = New System.Windows.Forms.TabControl
Me.TpChecks = New System.Windows.Forms.TabPage
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpDirect = New System.Windows.Forms.TabPage
Me.crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpStubs = New System.Windows.Forms.TabPage
Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabCtl1.SuspendLayout()
Me.TpChecks.SuspendLayout()
Me.TpDirect.SuspendLayout()
Me.TpStubs.SuspendLayout()
Me.SuspendLayout()
'
'TabCtl1
'
Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabCtl1.Controls.Add(Me.TpChecks)
Me.TabCtl1.Controls.Add(Me.TpDirect)
Me.TabCtl1.Controls.Add(Me.TpStubs)
Me.TabCtl1.Location = New System.Drawing.Point(12, 4)
Me.TabCtl1.Name = "TabCtl1"
Me.TabCtl1.SelectedIndex = 0
Me.TabCtl1.Size = New System.Drawing.Size(644, 376)
Me.TabCtl1.TabIndex = 1
'
'TpChecks
'
Me.TpChecks.Controls.Add(Me.Crv1)
Me.TpChecks.Location = New System.Drawing.Point(4, 22)
Me.TpChecks.Name = "TpChecks"
Me.TpChecks.Size = New System.Drawing.Size(636, 350)
Me.TpChecks.TabIndex = 0
Me.TpChecks.Text = "Checks"
Me.TpChecks.UseVisualStyleBackColor = True
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
'TpDirect
'
Me.TpDirect.Controls.Add(Me.crv2)
Me.TpDirect.Location = New System.Drawing.Point(4, 22)
Me.TpDirect.Name = "TpDirect"
Me.TpDirect.Size = New System.Drawing.Size(636, 350)
Me.TpDirect.TabIndex = 1
Me.TpDirect.Text = "Direct Deposit"
Me.TpDirect.UseVisualStyleBackColor = True
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
'TpStubs
'
Me.TpStubs.Controls.Add(Me.Crv3)
Me.TpStubs.Location = New System.Drawing.Point(4, 22)
Me.TpStubs.Name = "TpStubs"
Me.TpStubs.Size = New System.Drawing.Size(636, 350)
Me.TpStubs.TabIndex = 2
Me.TpStubs.Text = "Stubs"
Me.TpStubs.UseVisualStyleBackColor = True
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
Me.Crv3.TabIndex = 4
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
Me.TpChecks.ResumeLayout(False)
Me.TpDirect.ResumeLayout(False)
Me.TpStubs.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  wrkds.Merge(wrkds2)
  RunReport1()

  If MyCheckType = "P" Then
    wrkdsDD.Merge(wrkdsDD2)
    RunReport2()
  Else
    TabCtl1.TabPages.Remove(TpDirect)
  End If

  wrkdsSTUB.Merge(wrkds)
  wrkdsSTUB.Merge(wrkdsDD)
  wrkdsSTUB2.Merge(wrkds2)
  wrkdsSTUB2.Merge(wrkdsDD2)
  RunReport3()

 End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport.Close()
  myreport.Dispose()
  If MyCheckType = "P" Then
    myreport2.Close()
    myreport2.Dispose()
  End If
  myreport3.Close()
  myreport3.Dispose()
End Sub
  Private Sub RunReport1()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   If MyCheckType <> "S" Then
     ReportPath = MyUtils.GetReportPath("PrtPRPRTCHK.rpt", myTOWN._TOWNBR)
   Else
     ReportPath = MyUtils.GetReportPath("PrtPRPRTCHKSU.rpt", myTOWN._TOWNBR)
   End If
   With myreport
    .Load(ReportPath)
    .SetDataSource(wrkds)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    If MyCheckType = "M" Then
      .SetParameterValue("MyManualCheckNoSig", MyManualCheckNoSig)
    Else
      .SetParameterValue("MyManualCheckNoSig", False)
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
   ReportPath = MyUtils.GetReportPath("PrtPRPRTCHKDD.rpt", myTOWN._TOWNBR)
   With myreport2
    .Load(ReportPath)
    .SetDataSource(wrkdsDD)
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
     .ReportSource = myreport2
     .Zoom(75)
   End With
  End Sub
  Private Sub RunReport3()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtPRPRTCHKStub.rpt", myTOWN._TOWNBR)
   With myreport3
    .Load(ReportPath)
    .SetDataSource(wrkdsSTUB)
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
