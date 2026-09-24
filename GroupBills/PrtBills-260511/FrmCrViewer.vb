Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend wrkdsBill As DataSet = New DataSet
  Friend wrkdsTot As DataSet = New DataSet
  Friend WrkTotTax As Decimal
  Friend WithEvents TpBacks As System.Windows.Forms.TabPage
  Friend WithEvents crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Dim WrkYear As Integer

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
Friend WithEvents crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents TpTotals As System.Windows.Forms.TabPage
Friend WithEvents TpBills As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.TabCtl1 = New System.Windows.Forms.TabControl()
    Me.TpBills = New System.Windows.Forms.TabPage()
    Me.crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpTotals = New System.Windows.Forms.TabPage()
    Me.crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpBacks = New System.Windows.Forms.TabPage()
    Me.crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabCtl1.SuspendLayout()
    Me.TpBills.SuspendLayout()
    Me.TpTotals.SuspendLayout()
    Me.TpBacks.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabCtl1
    '
    Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabCtl1.Controls.Add(Me.TpBills)
    Me.TabCtl1.Controls.Add(Me.TpTotals)
    Me.TabCtl1.Controls.Add(Me.TpBacks)
    Me.TabCtl1.Location = New System.Drawing.Point(12, 4)
    Me.TabCtl1.Name = "TabCtl1"
    Me.TabCtl1.SelectedIndex = 0
    Me.TabCtl1.Size = New System.Drawing.Size(548, 376)
    Me.TabCtl1.TabIndex = 1
    '
    'TpBills
    '
    Me.TpBills.Controls.Add(Me.crv1)
    Me.TpBills.Location = New System.Drawing.Point(4, 22)
    Me.TpBills.Name = "TpBills"
    Me.TpBills.Size = New System.Drawing.Size(540, 350)
    Me.TpBills.TabIndex = 1
    Me.TpBills.Text = "Bills"
    Me.TpBills.UseVisualStyleBackColor = True
    '
    'crv1
    '
    Me.crv1.ActiveViewIndex = -1
    Me.crv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.crv1.Cursor = System.Windows.Forms.Cursors.Default
    Me.crv1.DisplayStatusBar = False
    Me.crv1.DisplayToolbar = False
    Me.crv1.Location = New System.Drawing.Point(-2, -1)
    Me.crv1.Name = "crv1"
    Me.crv1.SelectionFormula = ""
    Me.crv1.Size = New System.Drawing.Size(544, 352)
    Me.crv1.TabIndex = 2
    Me.crv1.ViewTimeSelectionFormula = ""
    '
    'TpTotals
    '
    Me.TpTotals.Controls.Add(Me.crv2)
    Me.TpTotals.Location = New System.Drawing.Point(4, 22)
    Me.TpTotals.Name = "TpTotals"
    Me.TpTotals.Size = New System.Drawing.Size(636, 350)
    Me.TpTotals.TabIndex = 2
    Me.TpTotals.Text = "Totals"
    Me.TpTotals.UseVisualStyleBackColor = True
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
    'TpBacks
    '
    Me.TpBacks.Controls.Add(Me.crv3)
    Me.TpBacks.Location = New System.Drawing.Point(4, 22)
    Me.TpBacks.Name = "TpBacks"
    Me.TpBacks.Size = New System.Drawing.Size(636, 350)
    Me.TpBacks.TabIndex = 3
    Me.TpBacks.Text = "Backs"
    Me.TpBacks.UseVisualStyleBackColor = True
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
    Me.crv3.TabIndex = 3
    Me.crv3.ViewTimeSelectionFormula = ""
    '
    'FrmCrViewer
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(568, 386)
    Me.Controls.Add(Me.TabCtl1)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmCrViewer"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "CrViewer"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    Me.TabCtl1.ResumeLayout(False)
    Me.TpBills.ResumeLayout(False)
    Me.TpTotals.ResumeLayout(False)
    Me.TpBacks.ResumeLayout(False)
    Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  If wrkdsBill.Tables(0).Rows.Count > 0 Then
    WrkYear = wrkdsBill.Tables(0).Rows(0).Item("year")
  End If
  RunTotals(MyTownNo)
  If MyFrmMainB.RbPrint.Checked Then
    RunReportBills(MyTownNo)
    RunBacks(MyTownNo)
  Else
    TabCtl1.TabPages.Remove(TpBills)
    TabCtl1.TabPages.Remove(TpBacks)
  End If

 End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport1.Close()
  myreport1.Dispose()
  myreport2.Close()
  myreport2.Dispose()
  myreport3.Close()
  myreport3.Dispose()
End Sub
  Private Sub RunReportBills(ByVal WrkTownNo As Integer)
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = ""
   ReportPath = GetReportPath("PrtBills.rpt", WrkTownNo)

   With myreport1
    .Load(ReportPath)
    .SetDataSource(wrkdsBill)
    .SetParameterValue("MyDueDate1", MyFrmMainB.DtPckDue1.Value.ToString("M/d/yyyy"))
    .SetParameterValue("MyDueDate2", MyFrmMainB.DtPckDue2.Value.ToString("M/d/yyyy"))
    .SetParameterValue("MyPayTo", MyFrmMainB.TxtPayTo.Text)
    .SetParameterValue("MyLine1", MyFrmMainB.TxtLine1.Text)
    .SetParameterValue("MyLine2", MyFrmMainB.TxtLine2.Text)
    .SetParameterValue("MyLine3", MyFrmMainB.TxtLine3.Text)
    .SetParameterValue("MyLine4", MyFrmMainB.TxtLine4.Text)
    .SetParameterValue("MyLine5", MyFrmMainB.TxtLine5.Text)
    .SetParameterValue("MyOnLine", MyFrmMainB.TxtOnline.Text)
    .SetParameterValue("MyAssrPhone", MyFrmMainB.TxtAssrPhone.Text)
    .SetParameterValue("MyStateMillRt", CnvSng(MyStateMillrt))
    .SetParameterValue("MyStateMoney", MyStateMoney)
    .SetParameterValue("MyGraceDate1", MyFrmMainB.DtPckGrace1.Value.ToString("M/d/yyyy"))
    .SetParameterValue("MyGraceDate2", MyFrmMainB.DtPckGrace2.Value.ToString("M/d/yyyy"))
   End With
   With crv1
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
  Private Sub RunTotals(ByVal WrkTownNo As Integer)
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = GetReportPath("PrtTot.rpt", WrkTownNo)
   With myreport2
    .Load(ReportPath)
    .SetDataSource(wrkdsTot)
    .SetParameterValue("myreportTitle", "Billing Totals")
    .SetParameterValue("MyTownName", MyFrmMainB.TxtTownName.Text)
    .SetParameterValue("MyTax", WrkTotTax)
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
  Private Sub RunBacks(ByVal WrkTownNo As Integer)
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = GetReportPath("PrtBack.rpt", WrkTownNo)
   With myreport3
    .Load(ReportPath)
    .SetParameterValue("MyAssrPhone", MyFrmMainB.TxtAssrPhone.Text)
    .SetParameterValue("MyStateMillRt", MyStateMillrt)
    .SetParameterValue("MyStateMoney", MyStateMoney)
    .SetParameterValue("MyYear", WrkYear)
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
End Class
