Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend Wrkds As DataSet

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
Friend WithEvents crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents TpReport As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.TabControl1 = New System.Windows.Forms.TabControl
Me.TpReport = New System.Windows.Forms.TabPage
Me.crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabControl1.SuspendLayout()
Me.TpReport.SuspendLayout()
Me.SuspendLayout()
'
'TabControl1
'
Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabControl1.Controls.Add(Me.TpReport)
Me.TabControl1.Location = New System.Drawing.Point(12, 4)
Me.TabControl1.Name = "TabControl1"
Me.TabControl1.SelectedIndex = 0
Me.TabControl1.Size = New System.Drawing.Size(644, 376)
Me.TabControl1.TabIndex = 1
'
'TpReport
'
Me.TpReport.Controls.Add(Me.crv1)
Me.TpReport.Location = New System.Drawing.Point(4, 22)
Me.TpReport.Name = "TpReport"
Me.TpReport.Size = New System.Drawing.Size(636, 350)
Me.TpReport.TabIndex = 1
Me.TpReport.Text = "Report"
Me.TpReport.UseVisualStyleBackColor = True
'
'crv1
'
Me.crv1.ActiveViewIndex = -1
Me.crv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.crv1.DisplayToolbar = False
Me.crv1.Location = New System.Drawing.Point(-2, -1)
Me.crv1.Name = "crv1"
Me.crv1.SelectionFormula = ""
Me.crv1.Size = New System.Drawing.Size(640, 352)
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
Me.TpReport.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    RunReport()
 End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport.Close()
  myreport.Dispose()
End Sub
  Private Sub RunReport()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTO202.rpt", myTOWN._TOWNBR)

   With myreport
    .Load(ReportPath)
    .SetDataSource(Wrkds)
    .SetParameterValue("myreportTitle", "Create M35H Electronic File")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyYear", MyUtils.CnvSng(MyFrmTO202B.TxtYear.Text))
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

Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

End Sub
End Class






