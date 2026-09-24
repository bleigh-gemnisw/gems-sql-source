Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport4 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend Wrkds As DataSet
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpOwners As System.Windows.Forms.TabPage
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpNew As System.Windows.Forms.TabPage
  Friend WithEvents crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpOPM As System.Windows.Forms.TabPage
  Friend WithEvents crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpErrors As System.Windows.Forms.TabPage
  Friend WithEvents Crv4 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend Wrkds2 As DataSet
  Friend WrkdsErr As DataSet
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
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TpOwners = New System.Windows.Forms.TabPage()
    Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpNew = New System.Windows.Forms.TabPage()
    Me.crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpOPM = New System.Windows.Forms.TabPage()
    Me.crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpErrors = New System.Windows.Forms.TabPage()
    Me.Crv4 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabControl1.SuspendLayout()
    Me.TpOwners.SuspendLayout()
    Me.TpNew.SuspendLayout()
    Me.TpOPM.SuspendLayout()
    Me.TpErrors.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabControl1.Controls.Add(Me.TpOwners)
    Me.TabControl1.Controls.Add(Me.TpNew)
    Me.TabControl1.Controls.Add(Me.TpOPM)
    Me.TabControl1.Controls.Add(Me.TpErrors)
    Me.TabControl1.Location = New System.Drawing.Point(10, 5)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(644, 376)
    Me.TabControl1.TabIndex = 2
    '
    'TpOwners
    '
    Me.TpOwners.Controls.Add(Me.Crv1)
    Me.TpOwners.Location = New System.Drawing.Point(4, 22)
    Me.TpOwners.Name = "TpOwners"
    Me.TpOwners.Size = New System.Drawing.Size(636, 350)
    Me.TpOwners.TabIndex = 0
    Me.TpOwners.Text = "Renewals"
    Me.TpOwners.UseVisualStyleBackColor = True
    '
    'Crv1
    '
    Me.Crv1.ActiveViewIndex = -1
    Me.Crv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv1.Cursor = System.Windows.Forms.Cursors.Default
    Me.Crv1.Location = New System.Drawing.Point(0, 0)
    Me.Crv1.Name = "Crv1"
    Me.Crv1.SelectionFormula = ""
    Me.Crv1.Size = New System.Drawing.Size(640, 352)
    Me.Crv1.TabIndex = 1
    Me.Crv1.ViewTimeSelectionFormula = ""
    '
    'TpNew
    '
    Me.TpNew.Controls.Add(Me.crv2)
    Me.TpNew.Location = New System.Drawing.Point(4, 22)
    Me.TpNew.Name = "TpNew"
    Me.TpNew.Size = New System.Drawing.Size(636, 350)
    Me.TpNew.TabIndex = 1
    Me.TpNew.Text = "New Applicants"
    Me.TpNew.UseVisualStyleBackColor = True
    '
    'crv2
    '
    Me.crv2.ActiveViewIndex = -1
    Me.crv2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.crv2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.crv2.Cursor = System.Windows.Forms.Cursors.Default
    Me.crv2.DisplayStatusBar = False
    Me.crv2.DisplayToolbar = False
    Me.crv2.Location = New System.Drawing.Point(0, 0)
    Me.crv2.Name = "crv2"
    Me.crv2.SelectionFormula = ""
    Me.crv2.Size = New System.Drawing.Size(640, 352)
    Me.crv2.TabIndex = 2
    Me.crv2.ViewTimeSelectionFormula = ""
    '
    'TpOPM
    '
    Me.TpOPM.Controls.Add(Me.crv3)
    Me.TpOPM.Location = New System.Drawing.Point(4, 22)
    Me.TpOPM.Name = "TpOPM"
    Me.TpOPM.Size = New System.Drawing.Size(636, 350)
    Me.TpOPM.TabIndex = 2
    Me.TpOPM.Text = "OPM"
    Me.TpOPM.UseVisualStyleBackColor = True
    '
    'crv3
    '
    Me.crv3.ActiveViewIndex = -1
    Me.crv3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.crv3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.crv3.Cursor = System.Windows.Forms.Cursors.Default
    Me.crv3.DisplayStatusBar = False
    Me.crv3.DisplayToolbar = False
    Me.crv3.Location = New System.Drawing.Point(0, 0)
    Me.crv3.Name = "crv3"
    Me.crv3.SelectionFormula = ""
    Me.crv3.Size = New System.Drawing.Size(640, 352)
    Me.crv3.TabIndex = 3
    Me.crv3.ViewTimeSelectionFormula = ""
    '
    'TpErrors
    '
    Me.TpErrors.Controls.Add(Me.Crv4)
    Me.TpErrors.Location = New System.Drawing.Point(4, 22)
    Me.TpErrors.Name = "TpErrors"
    Me.TpErrors.Size = New System.Drawing.Size(636, 350)
    Me.TpErrors.TabIndex = 3
    Me.TpErrors.Text = "Errors"
    Me.TpErrors.UseVisualStyleBackColor = True
    '
    'Crv4
    '
    Me.Crv4.ActiveViewIndex = -1
    Me.Crv4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv4.Cursor = System.Windows.Forms.Cursors.Default
    Me.Crv4.Location = New System.Drawing.Point(0, 0)
    Me.Crv4.Name = "Crv4"
    Me.Crv4.SelectionFormula = ""
    Me.Crv4.Size = New System.Drawing.Size(640, 352)
    Me.Crv4.TabIndex = 2
    Me.Crv4.ViewTimeSelectionFormula = ""
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
    Me.TpOwners.ResumeLayout(False)
    Me.TpNew.ResumeLayout(False)
    Me.TpOPM.ResumeLayout(False)
    Me.TpErrors.ResumeLayout(False)
    Me.ResumeLayout(False)

End Sub

#End Region

Private Sub CrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If WrkAcctsRen > 0 Then
      RunReport()
    Else
      TabControl1.TabPages.Remove(TpOwners)
    End If
    RunReport2()
    Application.DoEvents()
    RunReport3()
    If WrkdsErr.Tables(0).Rows.Count > 0 Then
      RunReport4()
    Else
      TabControl1.TabPages.Remove(TpErrors)
    End If
End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport1.Close()
  myreport1.Dispose()
  myreport2.Close()
  myreport2.Dispose()
  myreport3.Close()
  myreport3.Dispose()
  myreport4.Close()
  myreport4.Dispose()
End Sub
  Private Sub RunReport()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTO103.rpt", myTOWN._TOWNBR)
   With myreport1
    .Load(ReportPath)
    .SetDataSource(Wrkds)
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyTownNum", myTOWN._TOWNBR)
    .SetParameterValue("MyYear", MyUtils.CnvSng(MyFrmTO103B.TxtGLYear.Text))
    .SetParameterValue("MyMillRate", MrateMillrt * 1000)
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
  Private Sub RunReport2()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTO103B.rpt", myTOWN._TOWNBR)
   With myreport2
    .Load(ReportPath)
    .SetDataSource(Wrkds2)
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyTownNum", myTOWN._TOWNBR)
    .SetParameterValue("MyYear", MyUtils.CnvSng(MyFrmTO103B.TxtGLYear.Text))
    .SetParameterValue("MyAppYear", MyUtils.CnvSng(MyFrmTO103B.TxtAppYear.Text))
    .SetParameterValue("MyMillRate", MrateMillrt * 1000)
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
   Dim WrkPagesRen As Integer
   Dim WrkPagesApp As Integer

   Crv1.ShowLastPage()
   WrkPagesRen = Crv1.GetCurrentPageNumber()
   Crv1.ShowFirstPage()
   crv2.ShowLastPage()
   WrkPagesApp = crv2.GetCurrentPageNumber()
   crv2.ShowFirstPage()

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTO103OPM.rpt", myTOWN._TOWNBR)
   With myreport3
    .Load(ReportPath)
    .SetParameterValue("MyTown", WrkTown)
    .SetParameterValue("MyYear", MyUtils.CnvSng(MyFrmTO103B.TxtGLYear.Text))
    .SetParameterValue("MyMillRate", MrateMillrt * 1000)
    .SetParameterValue("MyDate", Date.Now)
    .SetParameterValue("MyCompApp", WrkPagesApp)
    .SetParameterValue("MyCompRen", WrkPagesRen)
    .SetParameterValue("MyAcctsApp", WrkAcctsApp)
    .SetParameterValue("MyAcctsRen", WrkAcctsRen)
    .SetParameterValue("MyReimbApp", WrkReimbApp)
    .SetParameterValue("MyReimbRen", WrkReimbRen)
    .SetParameterValue("MyAssrPhone", WrkAssrPhone)
    .SetParameterValue("MyCollPhone", WrkCollPhone)
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
  Private Sub RunReport4()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTO103Err.rpt", myTOWN._TOWNBR)
   With myreport4
    .Load(ReportPath)
    .SetDataSource(WrkdsErr)
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyTownNum", myTOWN._TOWNBR)
    .SetParameterValue("MyMillRate", MrateMillrt * 1000)
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









