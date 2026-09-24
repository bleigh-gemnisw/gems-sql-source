Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport4 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport5 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport6 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend wrkds As DataSet = New DataSet
  Friend wrkdsEscrow As DataSet = New DataSet
  Friend wrkdsBill As DataSet = New DataSet
  Friend wrkdsTot As DataSet = New DataSet
  Friend WrkType As String
  Friend WrkFamily As String
  Friend WrkMillRt As Decimal
  Friend WrkDueDate1 As Date
  Friend WrkGraceDate1 As Date
  Friend WrkPost As Boolean
  Friend WithEvents TpReport As System.Windows.Forms.TabPage
  Friend WithEvents crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpEscrow As System.Windows.Forms.TabPage
  Friend WithEvents Crv4 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Dim WrkTypeDesc As String

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
Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents TpTotals As System.Windows.Forms.TabPage
Friend WithEvents TpBills As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.TabCtl1 = New System.Windows.Forms.TabControl
Me.TpTotals = New System.Windows.Forms.TabPage
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpBills = New System.Windows.Forms.TabPage
Me.crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpReport = New System.Windows.Forms.TabPage
Me.crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpEscrow = New System.Windows.Forms.TabPage
Me.Crv4 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabCtl1.SuspendLayout()
Me.TpTotals.SuspendLayout()
Me.TpBills.SuspendLayout()
Me.TpReport.SuspendLayout()
Me.TpEscrow.SuspendLayout()
Me.SuspendLayout()
'
'TabCtl1
'
Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabCtl1.Controls.Add(Me.TpTotals)
Me.TabCtl1.Controls.Add(Me.TpBills)
Me.TabCtl1.Controls.Add(Me.TpReport)
Me.TabCtl1.Controls.Add(Me.TpEscrow)
Me.TabCtl1.Location = New System.Drawing.Point(12, 4)
Me.TabCtl1.Name = "TabCtl1"
Me.TabCtl1.SelectedIndex = 0
Me.TabCtl1.Size = New System.Drawing.Size(644, 376)
Me.TabCtl1.TabIndex = 1
'
'TpTotals
'
Me.TpTotals.Controls.Add(Me.Crv1)
Me.TpTotals.Location = New System.Drawing.Point(4, 22)
Me.TpTotals.Name = "TpTotals"
Me.TpTotals.Size = New System.Drawing.Size(636, 350)
Me.TpTotals.TabIndex = 0
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
Me.Crv1.Location = New System.Drawing.Point(0, 0)
Me.Crv1.Name = "Crv1"
Me.Crv1.SelectionFormula = ""
Me.Crv1.Size = New System.Drawing.Size(640, 352)
Me.Crv1.TabIndex = 1
Me.Crv1.ViewTimeSelectionFormula = ""
'
'TpBills
'
Me.TpBills.Controls.Add(Me.crv2)
Me.TpBills.Location = New System.Drawing.Point(4, 22)
Me.TpBills.Name = "TpBills"
Me.TpBills.Size = New System.Drawing.Size(636, 350)
Me.TpBills.TabIndex = 1
Me.TpBills.Text = "Bills"
Me.TpBills.UseVisualStyleBackColor = True
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
'TpReport
'
Me.TpReport.Controls.Add(Me.crv3)
Me.TpReport.Location = New System.Drawing.Point(4, 22)
Me.TpReport.Name = "TpReport"
Me.TpReport.Size = New System.Drawing.Size(636, 350)
Me.TpReport.TabIndex = 2
Me.TpReport.Text = "Report"
Me.TpReport.UseVisualStyleBackColor = True
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
Me.crv3.Location = New System.Drawing.Point(-2, -1)
Me.crv3.Name = "crv3"
Me.crv3.SelectionFormula = ""
Me.crv3.Size = New System.Drawing.Size(640, 352)
Me.crv3.TabIndex = 2
Me.crv3.ViewTimeSelectionFormula = ""
'
'TpEscrow
'
Me.TpEscrow.Controls.Add(Me.Crv4)
Me.TpEscrow.Location = New System.Drawing.Point(4, 22)
Me.TpEscrow.Name = "TpEscrow"
Me.TpEscrow.Size = New System.Drawing.Size(636, 350)
Me.TpEscrow.TabIndex = 3
Me.TpEscrow.Text = "Escrow List"
Me.TpEscrow.UseVisualStyleBackColor = True
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
Me.Crv4.TabIndex = 3
Me.Crv4.ViewTimeSelectionFormula = ""
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
Me.TpTotals.ResumeLayout(False)
Me.TpBills.ResumeLayout(False)
Me.TpReport.ResumeLayout(False)
Me.TpEscrow.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    If MyFrmTX350B.RbPrtNoBill.Checked Then
      TabCtl1.TabPages.Remove(TpBills)
    End If

    WrkTypeDesc = GetTXTypeDesc(WrkType)
    Select Case WrkFamily
    Case "R"
      If MyFrmTX350B.RbSelAll.Checked Then
        TabCtl1.TabPages.Remove(TpEscrow)
      End If
      TabCtl1.Refresh()
      RunReport()
      RunReportBills()
      RunReportTotals()
      If Not MyFrmTX350B.RbSelAll.Checked Then
        RunReportEscrow()
      End If
    Case Else
      TabCtl1.TabPages.Remove(TpEscrow)
      TabCtl1.Refresh()
      RunReport()
      RunReportBills()
      RunReportTotals()
    End Select

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
   ReportPath = MyUtils.GetReportPath("PrtTX350Tot.rpt", myTOWN._TOWNBR)
   With myreport
    .Load(ReportPath)
    .SetDataSource(wrkdsTot)
    .SetParameterValue("myreportTitle", wrkTypeDesc & " Bill Totals")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyPost", WrkPost)
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
  Private Sub RunReportBills()
   Dim ReportPath As String

   If MyFrmTX350B.RbPrtNoBill.Checked Then Exit Sub

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTX350Bill.rpt", myTOWN._TOWNBR)

   With myreport2
    .Load(ReportPath)
    .SetDataSource(wrkdsBill)
    .SetParameterValue("MyMillRt", WrkMillRt)
    .SetParameterValue("MyDueDate1", WrkDueDate1.ToString("M/d/yyyy"))
    .SetParameterValue("MyGraceDate1", WrkGraceDate1.ToString("M/d/yyyy"))
    .SetParameterValue("MyPayTo", Trim(myTXFMBILL._PAYTO))
    .SetParameterValue("MyLine1", Trim(myTXFMBILL._LINE1))
    .SetParameterValue("MyLine2", Trim(myTXFMBILL._LINE2))
    .SetParameterValue("MyLine3", Trim(myTXFMBILL._LINE3))
    .SetParameterValue("MyLine4", Trim(myTXFMBILL._LINE4))
    .SetParameterValue("MyLine5", Trim(myTXFMBILL._LINE5))
    .SetParameterValue("MyOfficeHours1", "Office Hours: " & Trim(myTXFMBILL._HOURS1))
    .SetParameterValue("MyOfficeHours2", Trim(myTXFMBILL._HOURS2))
    .SetParameterValue("MyAssrPhone", Trim(myTXFMBILL._APHONE))
    .SetParameterValue("MyCollPhone", Trim(myTXFMBILL._CPHONE))
    .SetParameterValue("MyType", WrkType)
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
  Private Sub RunReport()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
  ReportPath = MyUtils.GetReportPath("PrtTX350.rpt", myTOWN._TOWNBR)
   With myreport3
    .Load(ReportPath)
    .SetDataSource(wrkds)
    .SetParameterValue("myreportTitle", WrkTypeDesc & " Billing Report")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyPost", WrkPost)
  End With
  With crv3
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
  Private Sub RunReportEscrow()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
  ReportPath = MyUtils.GetReportPath("PrtTX350.rpt", myTOWN._TOWNBR)
   With myreport4
    .Load(ReportPath)
    .SetDataSource(wrkdsEscrow)
    .SetParameterValue("myreportTitle", WrkTypeDesc & " Escrow List")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyPost", WrkPost)
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
End Class






