Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport4 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend Wrkds1 As DataSet
  Friend Wrkds2 As DataSet
  Friend WrkSortby As String
  Friend WithEvents TabPgSel As System.Windows.Forms.TabPage
  Friend WithEvents Crv4 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Dim WrkHistRange As String
  Dim WrkRptType As String

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
Friend WithEvents TabPgLetter As System.Windows.Forms.TabPage
Friend WithEvents TabPgTotals As System.Windows.Forms.TabPage
Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.TabCtl1 = New System.Windows.Forms.TabControl()
    Me.TabPgLetter = New System.Windows.Forms.TabPage()
    Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabPgTotals = New System.Windows.Forms.TabPage()
    Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabPgSel = New System.Windows.Forms.TabPage()
    Me.Crv4 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabCtl1.SuspendLayout()
    Me.TabPgLetter.SuspendLayout()
    Me.TabPgTotals.SuspendLayout()
    Me.TabPgSel.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabCtl1
    '
    Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabCtl1.Controls.Add(Me.TabPgLetter)
    Me.TabCtl1.Controls.Add(Me.TabPgTotals)
    Me.TabCtl1.Controls.Add(Me.TabPgSel)
    Me.TabCtl1.Location = New System.Drawing.Point(4, 4)
    Me.TabCtl1.Name = "TabCtl1"
    Me.TabCtl1.SelectedIndex = 0
    Me.TabCtl1.Size = New System.Drawing.Size(656, 380)
    Me.TabCtl1.TabIndex = 0
    '
    'TabPgLetter
    '
    Me.TabPgLetter.Controls.Add(Me.Crv1)
    Me.TabPgLetter.Location = New System.Drawing.Point(4, 22)
    Me.TabPgLetter.Name = "TabPgLetter"
    Me.TabPgLetter.Size = New System.Drawing.Size(648, 354)
    Me.TabPgLetter.TabIndex = 0
    Me.TabPgLetter.Text = "Detail - Letter Size"
    Me.TabPgLetter.UseVisualStyleBackColor = True
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
    Me.Crv1.Location = New System.Drawing.Point(0, 0)
    Me.Crv1.Name = "Crv1"
    Me.Crv1.SelectionFormula = ""
    Me.Crv1.Size = New System.Drawing.Size(648, 352)
    Me.Crv1.TabIndex = 1
    Me.Crv1.ViewTimeSelectionFormula = ""
    '
    'TabPgTotals
    '
    Me.TabPgTotals.Controls.Add(Me.Crv3)
    Me.TabPgTotals.Location = New System.Drawing.Point(4, 22)
    Me.TabPgTotals.Name = "TabPgTotals"
    Me.TabPgTotals.Size = New System.Drawing.Size(648, 354)
    Me.TabPgTotals.TabIndex = 1
    Me.TabPgTotals.Text = "Totals"
    Me.TabPgTotals.UseVisualStyleBackColor = True
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
    Me.Crv3.Location = New System.Drawing.Point(0, 0)
    Me.Crv3.Name = "Crv3"
    Me.Crv3.SelectionFormula = ""
    Me.Crv3.Size = New System.Drawing.Size(648, 352)
    Me.Crv3.TabIndex = 2
    Me.Crv3.ViewTimeSelectionFormula = ""
    '
    'TabPgSel
    '
    Me.TabPgSel.Controls.Add(Me.Crv4)
    Me.TabPgSel.Location = New System.Drawing.Point(4, 22)
    Me.TabPgSel.Name = "TabPgSel"
    Me.TabPgSel.Size = New System.Drawing.Size(648, 354)
    Me.TabPgSel.TabIndex = 2
    Me.TabPgSel.Text = "Selections"
    Me.TabPgSel.UseVisualStyleBackColor = True
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
    Me.Crv4.Location = New System.Drawing.Point(0, 1)
    Me.Crv4.Name = "Crv4"
    Me.Crv4.SelectionFormula = ""
    Me.Crv4.Size = New System.Drawing.Size(648, 352)
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
    Me.TabPgLetter.ResumeLayout(False)
    Me.TabPgTotals.ResumeLayout(False)
    Me.TabPgSel.ResumeLayout(False)
    Me.ResumeLayout(False)

End Sub

#End Region

Private Sub CrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
   WrkHistRange = ""
   With MyFrmFA104B
     If .DtPckHistFrom.Checked Then
       WrkHistRange = "From: " & .DtPckHistFrom.Value & "  To: " & .DtPckHistTo.Value
     End If
     If .DtPckHistTo.Checked Then
       If WrkHistRange = "" Then
         WrkHistRange = "To: " & .DtPckHistTo.Value
       Else
         WrkHistRange = WrkHistRange & "  To: " & .DtPckHistTo.Value
       End If
     End If
     If .RbHistAdjust.Checked Then WrkRptType = "Adjustments"
     If .RbHistDepr.Checked Then WrkRptType = "Depreciation"
     If .RbHistBoth.Checked Then WrkRptType = "Both"
  End With
  RunReport1()
  RunReport3()
  RunReport4()
End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport1.Close()
  myreport1.Dispose()
  myreport3.Close()
  myreport3.Dispose()
  myreport4.Close()
  myreport4.Dispose()
End Sub
  Private Sub RunReport1()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtFA104.rpt", myTOWN._TOWNBR)
   With myreport1
    .Load(ReportPath)
    .SetDataSource(Wrkds1)
    .SetParameterValue("myreportTitle", "Fixed Assets History" & WrkSortby)
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyHistRange", WrkHistRange)
    .SetParameterValue("MyRptType", WrkRptType)
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
  Private Sub RunReport3()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtFA104Tot.rpt", myTOWN._TOWNBR)
   With myreport3
    .Load(ReportPath)
    .SetDataSource(Wrkds2)
    .SetParameterValue("myreportTitle", "Fixed Assets History" & WrkSortby)
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyHistRange", WrkHistRange)
    .SetParameterValue("MyRptType", WrkRptType)
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
   Dim WrkAsTypeRange As String
   Dim WrkBldgRange As String
   Dim WrkClassRange As String
   Dim WrkDeptRange As String
   Dim WrkEqupRange As String
   Dim WrkUser1Range As String
   Dim WrkUser2Range As String
   Dim WrkUser3Range As String
   Dim WrkAssetValRange As String

   With MyFrmFA104B
     WrkAsTypeRange = "From: " & MyUtils.JustifyLeft(.TxtAsTypeFrom.Text, 5) & "  To: " & MyUtils.JustifyLeft(.TxtAsTypeTo.Text, 5)
     WrkBldgRange = "From: " & MyUtils.JustifyLeft(.TxtBldgFrom.Text, 5) & "  To: " & MyUtils.JustifyLeft(.TxtBldgTo.Text, 5)
     WrkClassRange = "From: " & MyUtils.JustifyLeft(.TxtClassFrom.Text, 5) & "  To: " & MyUtils.JustifyLeft(.TxtClassTo.Text, 5)
     WrkDeptRange = "From: " & MyUtils.JustifyLeft(.TxtDeptFrom.Text, 5) & "  To: " & MyUtils.JustifyLeft(.TxtDeptTo.Text, 5)
     WrkEqupRange = "From: " & MyUtils.JustifyLeft(.TxtEqupFrom.Text, 5) & "  To: " & MyUtils.JustifyLeft(.TxtEqupTo.Text, 5)
     WrkUser1Range = "From: " & MyUtils.JustifyLeft(.TxtUser1From.Text, 5) & "  To: " & MyUtils.JustifyLeft(.TxtUser1To.Text, 5)
     WrkUser2Range = "From: " & MyUtils.JustifyLeft(.TxtUser2From.Text, 5) & "  To: " & MyUtils.JustifyLeft(.TxtUser2To.Text, 5)
     WrkUser3Range = "From: " & MyUtils.JustifyLeft(.TxtUser3From.Text, 5) & "  To: " & MyUtils.JustifyLeft(.TxtUser3To.Text, 5)
     WrkAssetValRange = "From: " & .TxtAssetValFrom.Text & "  To: " & .TxtAssetValTo.Text
   End With

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtFA104Sel.rpt", myTOWN._TOWNBR)
   With myreport4
    .Load(ReportPath)
    .SetParameterValue("myreportTitle", "Fixed Assets History" & WrkSortby)
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyAsTypeRange", WrkAsTypeRange)
    .SetParameterValue("MyBldgRange", WrkBldgRange)
    .SetParameterValue("MyClassRange", WrkClassRange)
    .SetParameterValue("MyDeptRange", WrkDeptRange)
    .SetParameterValue("MyEqupRange", WrkEqupRange)
    .SetParameterValue("MyUser1Range", WrkUser1Range)
    .SetParameterValue("MyUser2Range", WrkUser1Range)
    .SetParameterValue("MyUser3Range", WrkUser1Range)
    .SetParameterValue("MyAssetValRange", WrkAssetValRange)
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

Private Sub TabCtl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabCtl1.SelectedIndexChanged

End Sub
End Class
