Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend Wrkds As DataSet
  Friend WrkCurMillRt As Decimal
  Friend WrkMVMillRt As Decimal
  Friend WithEvents TabCtl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabReport As System.Windows.Forms.TabPage
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TabOPM As System.Windows.Forms.TabPage
  Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WrkPrvMillRt As Decimal

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
    Me.TabCtl1 = New System.Windows.Forms.TabControl()
    Me.TabReport = New System.Windows.Forms.TabPage()
    Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabOPM = New System.Windows.Forms.TabPage()
    Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabCtl1.SuspendLayout()
    Me.TabReport.SuspendLayout()
    Me.TabOPM.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabCtl1
    '
    Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabCtl1.Controls.Add(Me.TabReport)
    Me.TabCtl1.Controls.Add(Me.TabOPM)
    Me.TabCtl1.Location = New System.Drawing.Point(4, 3)
    Me.TabCtl1.Name = "TabCtl1"
    Me.TabCtl1.SelectedIndex = 0
    Me.TabCtl1.Size = New System.Drawing.Size(656, 380)
    Me.TabCtl1.TabIndex = 1
    '
    'TabReport
    '
    Me.TabReport.Controls.Add(Me.Crv1)
    Me.TabReport.Location = New System.Drawing.Point(4, 22)
    Me.TabReport.Name = "TabReport"
    Me.TabReport.Size = New System.Drawing.Size(648, 354)
    Me.TabReport.TabIndex = 0
    Me.TabReport.Text = "Report"
    Me.TabReport.UseVisualStyleBackColor = True
    '
    'Crv1
    '
    Me.Crv1.ActiveViewIndex = -1
    Me.Crv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv1.Cursor = System.Windows.Forms.Cursors.Default
    Me.Crv1.DisplayStatusBar = False
    Me.Crv1.DisplayToolbar = False
    Me.Crv1.Location = New System.Drawing.Point(8, 8)
    Me.Crv1.Name = "Crv1"
    Me.Crv1.SelectionFormula = ""
    Me.Crv1.Size = New System.Drawing.Size(632, 344)
    Me.Crv1.TabIndex = 1
    Me.Crv1.ViewTimeSelectionFormula = ""
    '
    'TabOPM
    '
    Me.TabOPM.Controls.Add(Me.Crv2)
    Me.TabOPM.Location = New System.Drawing.Point(4, 22)
    Me.TabOPM.Name = "TabOPM"
    Me.TabOPM.Size = New System.Drawing.Size(648, 354)
    Me.TabOPM.TabIndex = 6
    Me.TabOPM.Text = "OPM"
    Me.TabOPM.UseVisualStyleBackColor = True
    '
    'Crv2
    '
    Me.Crv2.ActiveViewIndex = -1
    Me.Crv2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv2.Cursor = System.Windows.Forms.Cursors.Default
    Me.Crv2.DisplayStatusBar = False
    Me.Crv2.DisplayToolbar = False
    Me.Crv2.Location = New System.Drawing.Point(8, 5)
    Me.Crv2.Name = "Crv2"
    Me.Crv2.SelectionFormula = ""
    Me.Crv2.Size = New System.Drawing.Size(632, 344)
    Me.Crv2.TabIndex = 3
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
    Me.TabReport.ResumeLayout(False)
    Me.TabOPM.ResumeLayout(False)
    Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    RunReport()
    RunReport2()
 End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport.Close()
  myreport.Dispose()
  myreport2.Close()
  myreport2.Dispose()
End Sub
  Private Sub RunReport()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTO207.rpt", myTOWN._TOWNBR)

   With myreport
    .Load(ReportPath)
    .SetDataSource(Wrkds)
    .SetParameterValue("myreportTitle", "Create M59A Electronic File")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyYear", MyUtils.CnvSng(MyFrmTO207B.TxtGLYear.Text))
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
   ReportPath = MyUtils.GetReportPath("PrtTO110OPM.rpt", myTOWN._TOWNBR)
   With myreport2
    .Load(ReportPath)
    .SetParameterValue("MyTown", WrkTown)
    .SetParameterValue("MyYear", MyUtils.CnvSng(MyFrmTO207B.TxtGLYear.Text))
    .SetParameterValue("MyDate", Date.Now)
    .SetParameterValue("MyCurMillRate", WrkCurMillRt)
    .SetParameterValue("MyCurAccts", MyCurAccts)
    .SetParameterValue("MyCurAmt", MyCurAmt)
    .SetParameterValue("MyPrvMillRate", WrkPrvMillRt)
    .SetParameterValue("MyPrvAccts", MyPrvAccts)
    .SetParameterValue("MyPrvAmt", MyPrvAmt)
    .SetParameterValue("MyCurRevLoss", MyCurRevLoss)
    .SetParameterValue("MyAssrPhone", WrkAssrPhone)
    .SetParameterValue("MyCollPhone", WrkCollPhone)
    .SetParameterValue("MyAssrEmail", WrkAssrEmail)
    .SetParameterValue("MyCollEmail", WrkCollEmail)
    .SetParameterValue("MyMVAccts", MyMVAccts)
    .SetParameterValue("MyMVAmt", MyMVAmt)
    .SetParameterValue("MyMVMillRate", WrkMVMillRt)
    .SetParameterValue("MyMVRevLoss", MyMVRevLoss)
    .SetParameterValue("MyPrvRevLoss", MyPrvRevLoss)
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
End Class






