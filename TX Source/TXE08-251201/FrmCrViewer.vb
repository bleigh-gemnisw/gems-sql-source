Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport4 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport5 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport6 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport7 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport8 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim WrkReportPath As String
  Dim WrkReportBy As String
  Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpTotalCR As System.Windows.Forms.TabPage
  Friend WithEvents TpTotalSusp As System.Windows.Forms.TabPage
  Friend WithEvents Crv4 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents Crv5 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend wrkds As DataSet = New DataSet
  Friend wrkdsSusp As DataSet = New DataSet
  Friend wrkdsCR As DataSet = New DataSet
  Friend wrkdsTot As DataSet = New DataSet
  Friend wrkdsTotCR As DataSet = New DataSet
  Friend wrkdsAudit As DataSet = New DataSet
  Friend wrkRecovery As Boolean
  Friend wrkAuditRefund As Boolean
  Friend WithEvents TpSummary As System.Windows.Forms.TabPage
  Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend wrkdsTotSusp As DataSet = New DataSet
  Friend WithEvents RbYear As System.Windows.Forms.RadioButton
  Friend WithEvents RbType As System.Windows.Forms.RadioButton
  Friend WithEvents TpDetailCR As System.Windows.Forms.TabPage
  Friend WithEvents Crv6 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpDetailSusp As System.Windows.Forms.TabPage
  Friend WithEvents Crv7 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpAudit As System.Windows.Forms.TabPage
  Friend WithEvents Crv8 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend wrkdsTotSum As DataSet = New DataSet

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
  Friend WithEvents TpDetail As System.Windows.Forms.TabPage
  Friend WithEvents TpTotal As System.Windows.Forms.TabPage
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TpAudit = New System.Windows.Forms.TabPage()
    Me.Crv8 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpSummary = New System.Windows.Forms.TabPage()
    Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpTotal = New System.Windows.Forms.TabPage()
    Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpTotalCR = New System.Windows.Forms.TabPage()
    Me.Crv4 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpTotalSusp = New System.Windows.Forms.TabPage()
    Me.Crv5 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpDetail = New System.Windows.Forms.TabPage()
    Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpDetailCR = New System.Windows.Forms.TabPage()
    Me.Crv6 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpDetailSusp = New System.Windows.Forms.TabPage()
    Me.Crv7 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.RbYear = New System.Windows.Forms.RadioButton()
    Me.RbType = New System.Windows.Forms.RadioButton()
    Me.TabControl1.SuspendLayout()
    Me.TpAudit.SuspendLayout()
    Me.TpSummary.SuspendLayout()
    Me.TpTotal.SuspendLayout()
    Me.TpTotalCR.SuspendLayout()
    Me.TpTotalSusp.SuspendLayout()
    Me.TpDetail.SuspendLayout()
    Me.TpDetailCR.SuspendLayout()
    Me.TpDetailSusp.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabControl1.Controls.Add(Me.TpAudit)
    Me.TabControl1.Controls.Add(Me.TpSummary)
    Me.TabControl1.Controls.Add(Me.TpTotal)
    Me.TabControl1.Controls.Add(Me.TpTotalCR)
    Me.TabControl1.Controls.Add(Me.TpTotalSusp)
    Me.TabControl1.Controls.Add(Me.TpDetail)
    Me.TabControl1.Controls.Add(Me.TpDetailCR)
    Me.TabControl1.Controls.Add(Me.TpDetailSusp)
    Me.TabControl1.Location = New System.Drawing.Point(12, 31)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(731, 349)
    Me.TabControl1.TabIndex = 1
    '
    'TpAudit
    '
    Me.TpAudit.Controls.Add(Me.Crv8)
    Me.TpAudit.Location = New System.Drawing.Point(4, 22)
    Me.TpAudit.Name = "TpAudit"
    Me.TpAudit.Size = New System.Drawing.Size(723, 323)
    Me.TpAudit.TabIndex = 11
    Me.TpAudit.Text = "Audit (Legal Size)"
    Me.TpAudit.UseVisualStyleBackColor = True
    '
    'Crv8
    '
    Me.Crv8.ActiveViewIndex = -1
    Me.Crv8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv8.AutoScroll = True
    Me.Crv8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv8.Cursor = System.Windows.Forms.Cursors.Default
    Me.Crv8.DisplayStatusBar = False
    Me.Crv8.DisplayToolbar = False
    Me.Crv8.Location = New System.Drawing.Point(-2, -1)
    Me.Crv8.Name = "Crv8"
    Me.Crv8.SelectionFormula = ""
    Me.Crv8.Size = New System.Drawing.Size(727, 325)
    Me.Crv8.TabIndex = 5
    Me.Crv8.ViewTimeSelectionFormula = ""
    '
    'TpSummary
    '
    Me.TpSummary.Controls.Add(Me.Crv2)
    Me.TpSummary.Location = New System.Drawing.Point(4, 22)
    Me.TpSummary.Name = "TpSummary"
    Me.TpSummary.Size = New System.Drawing.Size(723, 323)
    Me.TpSummary.TabIndex = 8
    Me.TpSummary.Text = "Summary"
    Me.TpSummary.UseVisualStyleBackColor = True
    '
    'Crv2
    '
    Me.Crv2.ActiveViewIndex = -1
    Me.Crv2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv2.AutoScroll = True
    Me.Crv2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv2.DisplayStatusBar = False
    Me.Crv2.DisplayToolbar = False
    Me.Crv2.Location = New System.Drawing.Point(-2, -1)
    Me.Crv2.Name = "Crv2"
    Me.Crv2.SelectionFormula = ""
    Me.Crv2.Size = New System.Drawing.Size(727, 325)
    Me.Crv2.TabIndex = 4
    Me.Crv2.ViewTimeSelectionFormula = ""
    '
    'TpTotal
    '
    Me.TpTotal.AutoScroll = True
    Me.TpTotal.Controls.Add(Me.Crv3)
    Me.TpTotal.Location = New System.Drawing.Point(4, 22)
    Me.TpTotal.Name = "TpTotal"
    Me.TpTotal.Size = New System.Drawing.Size(723, 323)
    Me.TpTotal.TabIndex = 1
    Me.TpTotal.Text = "Totals"
    Me.TpTotal.UseVisualStyleBackColor = True
    '
    'Crv3
    '
    Me.Crv3.ActiveViewIndex = -1
    Me.Crv3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv3.AutoScroll = True
    Me.Crv3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv3.DisplayStatusBar = False
    Me.Crv3.DisplayToolbar = False
    Me.Crv3.Location = New System.Drawing.Point(-2, -1)
    Me.Crv3.Name = "Crv3"
    Me.Crv3.SelectionFormula = ""
    Me.Crv3.Size = New System.Drawing.Size(727, 325)
    Me.Crv3.TabIndex = 2
    Me.Crv3.ViewTimeSelectionFormula = ""
    '
    'TpTotalCR
    '
    Me.TpTotalCR.Controls.Add(Me.Crv4)
    Me.TpTotalCR.Location = New System.Drawing.Point(4, 22)
    Me.TpTotalCR.Name = "TpTotalCR"
    Me.TpTotalCR.Size = New System.Drawing.Size(723, 323)
    Me.TpTotalCR.TabIndex = 2
    Me.TpTotalCR.Text = "Totals - Credit"
    Me.TpTotalCR.UseVisualStyleBackColor = True
    '
    'Crv4
    '
    Me.Crv4.ActiveViewIndex = -1
    Me.Crv4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv4.AutoScroll = True
    Me.Crv4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv4.DisplayStatusBar = False
    Me.Crv4.DisplayToolbar = False
    Me.Crv4.Location = New System.Drawing.Point(-2, -1)
    Me.Crv4.Name = "Crv4"
    Me.Crv4.SelectionFormula = ""
    Me.Crv4.Size = New System.Drawing.Size(727, 325)
    Me.Crv4.TabIndex = 2
    Me.Crv4.ViewTimeSelectionFormula = ""
    '
    'TpTotalSusp
    '
    Me.TpTotalSusp.Controls.Add(Me.Crv5)
    Me.TpTotalSusp.Location = New System.Drawing.Point(4, 22)
    Me.TpTotalSusp.Name = "TpTotalSusp"
    Me.TpTotalSusp.Size = New System.Drawing.Size(723, 323)
    Me.TpTotalSusp.TabIndex = 3
    Me.TpTotalSusp.Text = "Totals - Suspense"
    Me.TpTotalSusp.UseVisualStyleBackColor = True
    '
    'Crv5
    '
    Me.Crv5.ActiveViewIndex = -1
    Me.Crv5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv5.AutoScroll = True
    Me.Crv5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv5.DisplayStatusBar = False
    Me.Crv5.DisplayToolbar = False
    Me.Crv5.Location = New System.Drawing.Point(-2, -1)
    Me.Crv5.Name = "Crv5"
    Me.Crv5.SelectionFormula = ""
    Me.Crv5.Size = New System.Drawing.Size(727, 325)
    Me.Crv5.TabIndex = 2
    Me.Crv5.ViewTimeSelectionFormula = ""
    '
    'TpDetail
    '
    Me.TpDetail.Controls.Add(Me.Crv1)
    Me.TpDetail.Location = New System.Drawing.Point(4, 22)
    Me.TpDetail.Name = "TpDetail"
    Me.TpDetail.Size = New System.Drawing.Size(723, 323)
    Me.TpDetail.TabIndex = 0
    Me.TpDetail.Text = "Detail"
    Me.TpDetail.UseVisualStyleBackColor = True
    '
    'Crv1
    '
    Me.Crv1.ActiveViewIndex = -1
    Me.Crv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv1.AutoScroll = True
    Me.Crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv1.DisplayStatusBar = False
    Me.Crv1.DisplayToolbar = False
    Me.Crv1.Location = New System.Drawing.Point(0, 0)
    Me.Crv1.Name = "Crv1"
    Me.Crv1.SelectionFormula = ""
    Me.Crv1.Size = New System.Drawing.Size(727, 325)
    Me.Crv1.TabIndex = 1
    Me.Crv1.ViewTimeSelectionFormula = ""
    '
    'TpDetailCR
    '
    Me.TpDetailCR.Controls.Add(Me.Crv6)
    Me.TpDetailCR.Location = New System.Drawing.Point(4, 22)
    Me.TpDetailCR.Name = "TpDetailCR"
    Me.TpDetailCR.Size = New System.Drawing.Size(723, 323)
    Me.TpDetailCR.TabIndex = 9
    Me.TpDetailCR.Text = "Detail - Credit"
    Me.TpDetailCR.UseVisualStyleBackColor = True
    '
    'Crv6
    '
    Me.Crv6.ActiveViewIndex = -1
    Me.Crv6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv6.AutoScroll = True
    Me.Crv6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv6.DisplayStatusBar = False
    Me.Crv6.DisplayToolbar = False
    Me.Crv6.Location = New System.Drawing.Point(-2, -1)
    Me.Crv6.Name = "Crv6"
    Me.Crv6.SelectionFormula = ""
    Me.Crv6.Size = New System.Drawing.Size(727, 325)
    Me.Crv6.TabIndex = 2
    Me.Crv6.ViewTimeSelectionFormula = ""
    '
    'TpDetailSusp
    '
    Me.TpDetailSusp.Controls.Add(Me.Crv7)
    Me.TpDetailSusp.Location = New System.Drawing.Point(4, 22)
    Me.TpDetailSusp.Name = "TpDetailSusp"
    Me.TpDetailSusp.Size = New System.Drawing.Size(723, 323)
    Me.TpDetailSusp.TabIndex = 10
    Me.TpDetailSusp.Text = "Detail - Suspense"
    Me.TpDetailSusp.UseVisualStyleBackColor = True
    '
    'Crv7
    '
    Me.Crv7.ActiveViewIndex = -1
    Me.Crv7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv7.AutoScroll = True
    Me.Crv7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv7.DisplayStatusBar = False
    Me.Crv7.DisplayToolbar = False
    Me.Crv7.Location = New System.Drawing.Point(-2, -1)
    Me.Crv7.Name = "Crv7"
    Me.Crv7.SelectionFormula = ""
    Me.Crv7.Size = New System.Drawing.Size(727, 325)
    Me.Crv7.TabIndex = 3
    Me.Crv7.ViewTimeSelectionFormula = ""
    '
    'RbYear
    '
    Me.RbYear.AutoSize = True
    Me.RbYear.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbYear.Checked = True
    Me.RbYear.Location = New System.Drawing.Point(16, 8)
    Me.RbYear.Name = "RbYear"
    Me.RbYear.Size = New System.Drawing.Size(93, 17)
    Me.RbYear.TabIndex = 2
    Me.RbYear.TabStop = True
    Me.RbYear.Text = "Totals by Year"
    Me.RbYear.UseVisualStyleBackColor = True
    '
    'RbType
    '
    Me.RbType.AutoSize = True
    Me.RbType.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbType.Location = New System.Drawing.Point(146, 8)
    Me.RbType.Name = "RbType"
    Me.RbType.Size = New System.Drawing.Size(95, 17)
    Me.RbType.TabIndex = 3
    Me.RbType.Text = "Totals by Type"
    Me.RbType.UseVisualStyleBackColor = True
    '
    'FrmCrViewer
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(751, 386)
    Me.Controls.Add(Me.RbType)
    Me.Controls.Add(Me.RbYear)
    Me.Controls.Add(Me.TabControl1)
    Me.MaximizeBox = False
    Me.Name = "FrmCrViewer"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "CrViewer"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    Me.TabControl1.ResumeLayout(False)
    Me.TpAudit.ResumeLayout(False)
    Me.TpSummary.ResumeLayout(False)
    Me.TpTotal.ResumeLayout(False)
    Me.TpTotalCR.ResumeLayout(False)
    Me.TpTotalSusp.ResumeLayout(False)
    Me.TpDetail.ResumeLayout(False)
    Me.TpDetailCR.ResumeLayout(False)
    Me.TpDetailSusp.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If Not MyFrmTXE08B.RbDetNoprint.Checked Then
      RunReport()
    End If
    If MyFrmTXE08B.RbDetCombine.Checked Then
      TabControl1.TabPages.Remove(TpDetailCR)
      TabControl1.TabPages.Remove(TpDetailSusp)
    End If
    If MyFrmTXE08B.RbDetSplit.Checked Then
      RunReportCR()
      RunReportSusp()
    End If
    If MyFrmTXE08B.RbDetNoprint.Checked Then
      TabControl1.TabPages.Remove(TpDetail)
      TabControl1.TabPages.Remove(TpDetailCR)
      TabControl1.TabPages.Remove(TpDetailSusp)
    End If

    If MyFrmTXE08B.RbTotSplit.Checked Then
      LoadReportsTot()
    Else
      TabControl1.TabPages.Remove(TpAudit)
      TabControl1.TabPages.Remove(TpSummary)
      TabControl1.TabPages.Remove(TpTotalCR)
      TabControl1.TabPages.Remove(TpTotalSusp)
      LoadReportsCom()
    End If
  End Sub
  Private Sub FrmCrViewer() Handles Me.SizeChanged
    MyFrmTXE08.WindowState = FormWindowState.Minimized
  End Sub
  Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    myreport.Close()
    myreport.Dispose()
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
    myreport7.Close()
    myreport7.Dispose()
    myreport8.Close()
    myreport8.Dispose()
    MyFrmTXE08.TBarPrint.Enabled = True
  End Sub
  Private Sub LoadReportsTot()
    If RbYear.Checked Then
      WrkReportPath = MyUtils.GetReportPath("PrtTXE08Tot.rpt", myTOWN._TOWNBR)
      WrkReportBy = "Year"
    Else
      WrkReportPath = MyUtils.GetReportPath("PrtTXE08TotB.rpt", myTOWN._TOWNBR)
      WrkReportBy = "Type"
    End If

    RunReportAudit()
    RunReportTot()
    RunReportTotCR()
    RunReportTotSusp()
    RunReportTotSum()

  End Sub
  Private Sub LoadReportsCom()
    If RbYear.Checked Then
      WrkReportPath = MyUtils.GetReportPath("PrtTXE08Com.rpt", myTOWN._TOWNBR)
      WrkReportBy = "Year"
    Else
      WrkReportPath = MyUtils.GetReportPath("PrtTXE08ComB.rpt", myTOWN._TOWNBR)
      WrkReportBy = "Type"
    End If

    RunReportTot()

  End Sub
  Private Sub RunReport()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTXE08.rpt", myTOWN._TOWNBR)
    With myreport
      .Load(ReportPath)
      .SetDataSource(wrkds)
      .SetParameterValue("myreportTitle", "Balance Sheet")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyFromDate", MyFrmTXE08B.DtPckFrom.Value)
      .SetParameterValue("MyToDate", MyFrmTXE08B.DtPckTo.Value)
      .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTXE08B.TxtFromGLYear.Text))
      .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTXE08B.TxtToGLYear.Text))
      .SetParameterValue("MyDist", MyUtils.CnvSng(MyFrmTXE08B.TxtDist.Text))
      .SetParameterValue("MyPhase", MyUtils.CnvSng(MyFrmTXE08B.TxtPhase.Text))
      .SetParameterValue("MyTypes", MyFrmTXE08B.TxtTypes.Text)
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
  Private Sub RunReportCR()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTXE08.rpt", myTOWN._TOWNBR)
    With myreport6
      .Load(ReportPath)
      .SetDataSource(wrkdsCR)
      .SetParameterValue("myreportTitle", "Balance Sheet (Credits)")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyFromDate", MyFrmTXE08B.DtPckFrom.Value)
      .SetParameterValue("MyToDate", MyFrmTXE08B.DtPckTo.Value)
      .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTXE08B.TxtFromGLYear.Text))
      .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTXE08B.TxtToGLYear.Text))
      .SetParameterValue("MyDist", MyUtils.CnvSng(MyFrmTXE08B.TxtDist.Text))
      .SetParameterValue("MyPhase", MyUtils.CnvSng(MyFrmTXE08B.TxtPhase.Text))
      .SetParameterValue("MyTypes", MyFrmTXE08B.TxtTypes.Text)
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
  Private Sub RunReportSusp()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTXE08.rpt", myTOWN._TOWNBR)
    With myreport7
      .Load(ReportPath)
      .SetDataSource(wrkdsSusp)
      .SetParameterValue("myreportTitle", "Balance Sheet (Suspense)")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyFromDate", MyFrmTXE08B.DtPckFrom.Value)
      .SetParameterValue("MyToDate", MyFrmTXE08B.DtPckTo.Value)
      .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTXE08B.TxtFromGLYear.Text))
      .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTXE08B.TxtToGLYear.Text))
      .SetParameterValue("MyDist", MyUtils.CnvSng(MyFrmTXE08B.TxtDist.Text))
      .SetParameterValue("MyPhase", MyUtils.CnvSng(MyFrmTXE08B.TxtPhase.Text))
      .SetParameterValue("MyTypes", MyFrmTXE08B.TxtTypes.Text)
    End With
    With Crv7
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreport7
      .Zoom(75)
    End With

  End Sub
  Private Sub RunReportTotSum()
    Dim ReportPath As String

    If RbYear.Checked Then
      ReportPath = MyUtils.GetReportPath("PrtTXE08Sum.rpt", myTOWN._TOWNBR)
      WrkReportBy = "Year"
    Else
      ReportPath = MyUtils.GetReportPath("PrtTXE08SumB.rpt", myTOWN._TOWNBR)
      WrkReportBy = "Type"
    End If
    With myreport2
      .Load(ReportPath)
      .SetDataSource(wrkdsTotSum)
      .SetParameterValue("myreportTitle", "Balance Sheet Summary by " & WrkReportBy)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyFromDate", MyFrmTXE08B.DtPckFrom.Value)
      .SetParameterValue("MyToDate", MyFrmTXE08B.DtPckTo.Value)
      .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTXE08B.TxtFromGLYear.Text))
      .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTXE08B.TxtToGLYear.Text))
      .SetParameterValue("MyDist", MyUtils.CnvSng(MyFrmTXE08B.TxtDist.Text))
      .SetParameterValue("MyPhase", MyUtils.CnvSng(MyFrmTXE08B.TxtPhase.Text))
      .SetParameterValue("MyTypes", MyFrmTXE08B.TxtTypes.Text)
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
  Private Sub RunReportAudit()
    Dim ReportPath As String
    Me.Text = "Report Viewer"
    If wrkRecovery Then
      ReportPath = MyUtils.GetReportPath("PrtTXE08AuditRV.rpt", myTOWN._TOWNBR)
    Else
      If wrkAuditRefund Then
        ReportPath = MyUtils.GetReportPath("PrtTXE08AuditRef.rpt", myTOWN._TOWNBR)
      Else
        ReportPath = MyUtils.GetReportPath("PrtTXE08Audit.rpt", myTOWN._TOWNBR)
      End If
    End If
    With myreport8
      .Load(ReportPath)
      .SetDataSource(wrkdsAudit)
      .SetParameterValue("myreportTitle", "Balance Sheet Audit Data")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyFromDate", MyFrmTXE08B.DtPckFrom.Value)
      .SetParameterValue("MyToDate", MyFrmTXE08B.DtPckTo.Value)
      .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTXE08B.TxtFromGLYear.Text))
      .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTXE08B.TxtToGLYear.Text))
      .SetParameterValue("MyDist", MyUtils.CnvSng(MyFrmTXE08B.TxtDist.Text))
      .SetParameterValue("MyPhase", MyUtils.CnvSng(MyFrmTXE08B.TxtPhase.Text))
      .SetParameterValue("MyTypes", MyFrmTXE08B.TxtTypes.Text)
    End With
    With Crv8
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreport8
      .Zoom(75)
    End With
  End Sub
  Private Sub RunReportTot()
    With myreport3
      .Load(WrkReportPath)
      .SetDataSource(wrkdsTot)
      .SetParameterValue("myreportTitle", "Balance Sheet Totals by " & WrkReportBy)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyFromDate", MyFrmTXE08B.DtPckFrom.Value)
      .SetParameterValue("MyToDate", MyFrmTXE08B.DtPckTo.Value)
      .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTXE08B.TxtFromGLYear.Text))
      .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTXE08B.TxtToGLYear.Text))
      .SetParameterValue("MyDist", MyUtils.CnvSng(MyFrmTXE08B.TxtDist.Text))
      .SetParameterValue("MyPhase", MyUtils.CnvSng(MyFrmTXE08B.TxtPhase.Text))
      .SetParameterValue("MyTypes", MyFrmTXE08B.TxtTypes.Text)
      .SetParameterValue("MyShowOverpd", False)
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
  Private Sub RunReportTotCR()
    With myreport4
      .Load(WrkReportPath)
      .SetDataSource(wrkdsTotCR)
      .SetParameterValue("myreportTitle", "Credit Balance Sheet Totals by " & WrkReportBy)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyFromDate", MyFrmTXE08B.DtPckFrom.Value)
      .SetParameterValue("MyToDate", MyFrmTXE08B.DtPckTo.Value)
      .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTXE08B.TxtFromGLYear.Text))
      .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTXE08B.TxtToGLYear.Text))
      .SetParameterValue("MyDist", MyUtils.CnvSng(MyFrmTXE08B.TxtDist.Text))
      .SetParameterValue("MyPhase", MyUtils.CnvSng(MyFrmTXE08B.TxtPhase.Text))
      .SetParameterValue("MyTypes", MyFrmTXE08B.TxtTypes.Text)
      .SetParameterValue("MyShowOverpd", True)
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
  Private Sub RunReportTotSusp()
    With myreport5
      .Load(WrkReportPath)
      .SetDataSource(wrkdsTotSusp)
      .SetParameterValue("myreportTitle", "Suspense Balance Sheet Totals by " & WrkReportBy)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyFromDate", MyFrmTXE08B.DtPckFrom.Value)
      .SetParameterValue("MyToDate", MyFrmTXE08B.DtPckTo.Value)
      .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTXE08B.TxtFromGLYear.Text))
      .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTXE08B.TxtToGLYear.Text))
      .SetParameterValue("MyDist", MyUtils.CnvSng(MyFrmTXE08B.TxtDist.Text))
      .SetParameterValue("MyPhase", MyUtils.CnvSng(MyFrmTXE08B.TxtPhase.Text))
      .SetParameterValue("MyTypes", MyFrmTXE08B.TxtTypes.Text)
      .SetParameterValue("MyShowOverpd", False)
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
  Private Sub RbYear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbYear.Click
    If MyFrmTXE08B.RbTotSplit.Checked Then
      LoadReportsTot()
    Else
      LoadReportsCom()
    End If
  End Sub
  Private Sub RbType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbType.Click
    If MyFrmTXE08B.RbTotSplit.Checked Then
      LoadReportsTot()
    Else
      LoadReportsCom()
    End If
  End Sub
End Class




