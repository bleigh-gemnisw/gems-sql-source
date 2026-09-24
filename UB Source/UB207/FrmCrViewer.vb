Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend wrkds As DataSet = New DataSet
  Friend Wrkdistphase As String
  Friend Wrksort As String
  

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
Friend WithEvents TabPgList As System.Windows.Forms.TabPage
Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents TabPgLbl As System.Windows.Forms.TabPage
Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.TabCtl1 = New System.Windows.Forms.TabControl
Me.TabPgList = New System.Windows.Forms.TabPage
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabPgLbl = New System.Windows.Forms.TabPage
Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabCtl1.SuspendLayout()
Me.TabPgList.SuspendLayout()
Me.TabPgLbl.SuspendLayout()
Me.SuspendLayout()
'
'TabCtl1
'
Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabCtl1.Controls.Add(Me.TabPgList)
Me.TabCtl1.Controls.Add(Me.TabPgLbl)
Me.TabCtl1.Location = New System.Drawing.Point(12, 12)
Me.TabCtl1.Name = "TabCtl1"
Me.TabCtl1.SelectedIndex = 0
Me.TabCtl1.Size = New System.Drawing.Size(704, 368)
Me.TabCtl1.TabIndex = 1
'
'TabPgList
'
Me.TabPgList.Controls.Add(Me.Crv1)
Me.TabPgList.Location = New System.Drawing.Point(4, 22)
Me.TabPgList.Name = "TabPgList"
Me.TabPgList.Size = New System.Drawing.Size(696, 342)
Me.TabPgList.TabIndex = 0
Me.TabPgList.Text = "Listing"
Me.TabPgList.UseVisualStyleBackColor = True
'
'Crv1
'
Me.Crv1.ActiveViewIndex = -1
Me.Crv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.Crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Crv1.DisplayToolbar = False
Me.Crv1.Location = New System.Drawing.Point(8, 8)
Me.Crv1.Name = "Crv1"
Me.Crv1.SelectionFormula = ""
Me.Crv1.Size = New System.Drawing.Size(680, 328)
Me.Crv1.TabIndex = 2
Me.Crv1.ViewTimeSelectionFormula = ""
'
'TabPgLbl
'
Me.TabPgLbl.Controls.Add(Me.Crv2)
Me.TabPgLbl.Location = New System.Drawing.Point(4, 22)
Me.TabPgLbl.Name = "TabPgLbl"
Me.TabPgLbl.Size = New System.Drawing.Size(696, 342)
Me.TabPgLbl.TabIndex = 1
Me.TabPgLbl.Text = "Labels"
Me.TabPgLbl.UseVisualStyleBackColor = True
Me.TabPgLbl.Visible = False
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
Me.Crv2.Location = New System.Drawing.Point(8, 8)
Me.Crv2.Name = "Crv2"
Me.Crv2.SelectionFormula = ""
Me.Crv2.Size = New System.Drawing.Size(680, 328)
Me.Crv2.TabIndex = 3
Me.Crv2.ViewTimeSelectionFormula = ""
'
'FrmCrViewer
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(736, 402)
Me.Controls.Add(Me.TabCtl1)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmCrViewer"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
Me.Text = "CrViewer"
Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
Me.TabCtl1.ResumeLayout(False)
Me.TabPgList.ResumeLayout(False)
Me.TabPgLbl.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Me.Text = "Report Viewer"

  If MyFrmUB207B.RbList.Checked Then
    RunReport1()
    TabCtl1.TabPages.Remove(TabPgLbl)
  Else
    RunReport2()
    TabCtl1.TabPages.Remove(TabPgList)
  End If

End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport.Close()
  myreport.Dispose()
  myreport2.Close()
  myreport2.Dispose()
End Sub
  Private Sub RunReport1()
   Dim ReportPath As String

   ReportPath = MyUtils.GetReportPath("PrtUB207.rpt", myTOWN._TOWNBR)
    With myreport
    .Load(ReportPath)
    .SetDataSource(wrkds)
    .SetParameterValue("myreportTitle", " Customer Listing By District/Phase")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MySort", Wrksort)
    .SetParameterValue("Mydistphase", Wrkdistphase)
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
   Dim WrkSection As CrystalDecisions.CrystalReports.Engine.Section
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtUB207Lbl.rpt", myTOWN._TOWNBR)
   With myreport2
    .Load(ReportPath)
    .SetDataSource(wrkds)
   End With
   WrkSection = GetReportSection("Section2")
   WrkSection.Height = MyUtils.CnvSng(MyFrmUB207B.TxtVAdjust1.Text)
   WrkSection = GetReportSection("DetailSection3")
   WrkSection.Height = MyUtils.CnvSng(MyFrmUB207B.TxtVAdjust2.Text)
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
  Private Function GetReportSection _
     (ByVal reportSectionName As String) As CrystalDecisions.CrystalReports.Engine.Section
     Dim reportsection As CrystalDecisions.CrystalReports.Engine.Section

     reportsection = myreport2.ReportDefinition.Sections.Item(reportSectionName)
     GetReportSection = reportsection
  End Function
End Class







