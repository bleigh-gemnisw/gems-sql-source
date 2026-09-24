Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport4 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport5 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport6 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend wrkds As DataSet = New DataSet
  Friend wrkdsSwr As DataSet = New DataSet
  Friend wrkdsEscrow As DataSet = New DataSet
  Friend wrkdsEscrowSwr As DataSet = New DataSet
  Friend wrkdsBill As DataSet = New DataSet
  Friend wrkdsTot As DataSet = New DataSet
  Friend WrkType As String
  Friend WrkMillRt As Decimal
  Friend WrkDueDate1 As Date
  Friend WrkDueDate2 As Date
  Friend WrkGraceDate1 As Date
  Friend WrkGraceDate2 As Date
  Friend WrkStateMoney As Decimal
  Friend WrkStateMillRt As Decimal
  Friend WrkPost As Boolean
  Friend WrkBillCount As Integer
  Friend WithEvents TpReport As System.Windows.Forms.TabPage
  Friend WithEvents crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpEscrow As System.Windows.Forms.TabPage
  Friend WithEvents Crv4 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpReportSwr As System.Windows.Forms.TabPage
  Friend WithEvents TpEscrowSwr As System.Windows.Forms.TabPage
  Friend WithEvents Crv5 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents Crv6 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Dim WrkBillType As String

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
Me.TpReportSwr = New System.Windows.Forms.TabPage
Me.TpEscrowSwr = New System.Windows.Forms.TabPage
Me.Crv5 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.Crv6 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabCtl1.SuspendLayout()
Me.TpTotals.SuspendLayout()
Me.TpBills.SuspendLayout()
Me.TpReport.SuspendLayout()
Me.TpEscrow.SuspendLayout()
Me.TpReportSwr.SuspendLayout()
Me.TpEscrowSwr.SuspendLayout()
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
Me.TabCtl1.Controls.Add(Me.TpReportSwr)
Me.TabCtl1.Controls.Add(Me.TpEscrowSwr)
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
'TpReportSwr
'
Me.TpReportSwr.Controls.Add(Me.Crv5)
Me.TpReportSwr.Location = New System.Drawing.Point(4, 22)
Me.TpReportSwr.Name = "TpReportSwr"
Me.TpReportSwr.Size = New System.Drawing.Size(636, 350)
Me.TpReportSwr.TabIndex = 4
Me.TpReportSwr.Text = "Report - Sewer"
Me.TpReportSwr.UseVisualStyleBackColor = True
'
'TpEscrowSwr
'
Me.TpEscrowSwr.Controls.Add(Me.Crv6)
Me.TpEscrowSwr.Location = New System.Drawing.Point(4, 22)
Me.TpEscrowSwr.Name = "TpEscrowSwr"
Me.TpEscrowSwr.Size = New System.Drawing.Size(636, 350)
Me.TpEscrowSwr.TabIndex = 5
Me.TpEscrowSwr.Text = "Escrow - Sewer"
Me.TpEscrowSwr.UseVisualStyleBackColor = True
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
Me.Crv5.TabIndex = 4
Me.Crv5.ViewTimeSelectionFormula = ""
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
Me.TpReportSwr.ResumeLayout(False)
Me.TpEscrowSwr.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    If MyFrmTX301B.RbPrtNoBill.Checked Then
      TabCtl1.TabPages.Remove(TpBills)
    End If

    Select Case WrkType
    Case "R"
      WrkBillType = GetTXTypeDesc(WrkType)
      TabCtl1.TabPages.Remove(TpReportSwr)
      TabCtl1.TabPages.Remove(TpEscrowSwr)
      If MyFrmTX301B.RbSelAll.Checked Then
        TabCtl1.TabPages.Remove(TpEscrow)
      End If
      TabCtl1.Refresh()
      RunReport()
      RunReportBills(WrkType)
      RunReportTotals(WrkType)
      If Not MyFrmTX301B.RbSelAll.Checked Then
        RunReportEscrow()
      End If
    Case "U"
      WrkBillType = GetTXTypeDesc("R")
      If MyFrmTX301B.RbSelAll.Checked Then
        TabCtl1.TabPages.Remove(TpEscrowSwr)
      End If
      TabCtl1.Refresh()
      RunReport()
      RunReportBills(WrkType)
      If Not MyFrmTX301B.RbSelAll.Checked Then
        RunReportEscrow()
      End If
      RunReportTotals(WrkType)
      WrkBillType = GetTXTypeDesc("U")
      RunReportSwr()
      If Not MyFrmTX301B.RbSelAll.Checked Then
        RunReportEscrowSwr()
      End If
    Case "X"
      WrkBillType = GetTXTypeDesc(WrkType)
      TabCtl1.TabPages.Remove(TpReportSwr)
      TabCtl1.TabPages.Remove(TpEscrow)
      TabCtl1.TabPages.Remove(TpEscrowSwr)
      TabCtl1.Refresh()
      RunReport()
      RunReportProrates()
      RunReportTotals(WrkType)
    Case Else
      WrkBillType = GetTXTypeDesc(WrkType)
      TabCtl1.TabPages.Remove(TpReportSwr)
      TabCtl1.TabPages.Remove(TpEscrow)
      TabCtl1.TabPages.Remove(TpEscrowSwr)
      TabCtl1.Refresh()
      RunReport()
      RunReportBills(WrkType)
      RunReportTotals(WrkType)
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
  Private Sub RunReportTotals(ByVal WrkType As String)
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   Select Case WrkType
   Case "S"
     ReportPath = MyUtils.GetReportPath("PrtTX301TotSU.rpt", myTOWN._TOWNBR, MyCustomDir)
   Case Else
     ReportPath = MyUtils.GetReportPath("PrtTX301Tot.rpt", myTOWN._TOWNBR, MyCustomDir)
   End Select
   With myreport
    .Load(ReportPath)
    .SetDataSource(wrkdsTot)
    .SetParameterValue("myreportTitle", WrkBillType & " Bill Totals")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyPost", WrkPost)
    .SetParameterValue("MyBillCount", WrkBillCount)
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
  Private Sub RunReportBills(ByVal WrkType As String)
   Dim ReportPath As String

   If MyFrmTX301B.RbPrtNoBill.Checked Then Exit Sub

   Me.Text = "Report Viewer"
   ReportPath = ""
   Select Case WrkType
   Case "M"
     ReportPath = MyUtils.GetReportPath("PrtTX301MV.rpt", myTOWN._TOWNBR, MyCustomDir)
   Case "P"
     ReportPath = MyUtils.GetReportPath("PrtTX301PP.rpt", myTOWN._TOWNBR, MyCustomDir)
   Case "R"
     ReportPath = MyUtils.GetReportPath("PrtTX301RE.rpt", myTOWN._TOWNBR, MyCustomDir)
   Case "S"
     ReportPath = MyUtils.GetReportPath("PrtTX301SU.rpt", myTOWN._TOWNBR, MyCustomDir)
   Case "U"
     ReportPath = MyUtils.GetReportPath("PrtTX301RESwr.rpt", myTOWN._TOWNBR, MyCustomDir)
   End Select

   With myreport2
    .Load(ReportPath)
    .SetDataSource(wrkdsBill)
    .SetParameterValue("MyMillRt", WrkMillRt)
    .SetParameterValue("MyDueDate1", WrkDueDate1.ToString("M/d/yyyy"))
    .SetParameterValue("MyDueDate2", WrkDueDate2.ToString("M/d/yyyy"))
    .SetParameterValue("MyGraceDate1", WrkGraceDate1.ToString("M/d/yyyy"))
    .SetParameterValue("MyGraceDate2", WrkGraceDate2.ToString("M/d/yyyy"))
    .SetParameterValue("MyStateMoney", WrkStateMoney)
    .SetParameterValue("MyStateMillRt", WrkStateMillRt)
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
  Private Sub RunReportProrates()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTX301Prorate.rpt", myTOWN._TOWNBR, MyCustomDir)

   With myreport2
    .Load(ReportPath)
    .SetDataSource(wrkdsBill)
    .SetParameterValue("MyMillRt", WrkMillRt)
    .SetParameterValue("MyDueDate1", WrkDueDate1.ToString("M/d/yyyy"))
    .SetParameterValue("MyDueDate2", WrkDueDate2.ToString("M/d/yyyy"))
    .SetParameterValue("MyGraceDate1", WrkGraceDate1.ToString("M/d/yyyy"))
    .SetParameterValue("MyGraceDate2", WrkGraceDate2.ToString("M/d/yyyy"))
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
   ReportPath = MyUtils.GetReportPath("PrtTX301.rpt", myTOWN._TOWNBR)
   With myreport3
    .Load(ReportPath)
    .SetDataSource(wrkds)
    .SetParameterValue("myreportTitle", WrkBillType & " Billing Report")
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
  Private Sub RunReportSwr()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTX301.rpt", myTOWN._TOWNBR)
   With myreport5
    .Load(ReportPath)
    .SetDataSource(wrkdsSwr)
    .SetParameterValue("myreportTitle", WrkBillType & " Billing Report")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyPost", WrkPost)
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
  Private Sub RunReportEscrow()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTX301.rpt", myTOWN._TOWNBR)
   With myreport4
    .Load(ReportPath)
    .SetDataSource(wrkdsEscrow)
    .SetParameterValue("myreportTitle", WrkBillType & " Escrow List")
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
  Private Sub RunReportEscrowSwr()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTX301.rpt", myTOWN._TOWNBR)
   With myreport6
    .Load(ReportPath)
    .SetDataSource(wrkdsEscrowSwr)
    .SetParameterValue("myreportTitle", WrkBillType & " Escrow List")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyPost", WrkPost)
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
