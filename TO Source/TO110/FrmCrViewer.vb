Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport4 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport5 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend Wrkds As DataSet
  Friend WrkdsCatB As DataSet
  Friend WrkdsCatC As DataSet
  Friend WrkdsErr As DataSet
  Friend WrkCurMillRt As Decimal
  Friend WrkMVMillRt As Decimal
  Friend WrkPrvMillRt As Decimal
  Friend WithEvents TpOPM As System.Windows.Forms.TabPage
  Friend WithEvents TpMissing As TabPage
  Friend WithEvents Crv5 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents crv4 As CrystalDecisions.Windows.Forms.CrystalReportViewer

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
  Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpAll As System.Windows.Forms.TabPage
  Friend WithEvents TpCatC As System.Windows.Forms.TabPage
  Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpCatB As System.Windows.Forms.TabPage
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.TabCtl1 = New System.Windows.Forms.TabControl()
    Me.TpAll = New System.Windows.Forms.TabPage()
    Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpCatB = New System.Windows.Forms.TabPage()
    Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpCatC = New System.Windows.Forms.TabPage()
    Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpOPM = New System.Windows.Forms.TabPage()
    Me.crv4 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpMissing = New System.Windows.Forms.TabPage()
    Me.Crv5 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabCtl1.SuspendLayout()
    Me.TpAll.SuspendLayout()
    Me.TpCatB.SuspendLayout()
    Me.TpCatC.SuspendLayout()
    Me.TpOPM.SuspendLayout()
    Me.TpMissing.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabCtl1
    '
    Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabCtl1.Controls.Add(Me.TpAll)
    Me.TabCtl1.Controls.Add(Me.TpCatB)
    Me.TabCtl1.Controls.Add(Me.TpCatC)
    Me.TabCtl1.Controls.Add(Me.TpOPM)
    Me.TabCtl1.Controls.Add(Me.TpMissing)
    Me.TabCtl1.Location = New System.Drawing.Point(4, 4)
    Me.TabCtl1.Name = "TabCtl1"
    Me.TabCtl1.SelectedIndex = 0
    Me.TabCtl1.Size = New System.Drawing.Size(656, 380)
    Me.TabCtl1.TabIndex = 0
    '
    'TpAll
    '
    Me.TpAll.Controls.Add(Me.Crv1)
    Me.TpAll.Location = New System.Drawing.Point(4, 22)
    Me.TpAll.Name = "TpAll"
    Me.TpAll.Size = New System.Drawing.Size(648, 354)
    Me.TpAll.TabIndex = 0
    Me.TpAll.Text = "Alll Categories"
    Me.TpAll.UseVisualStyleBackColor = True
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
    'TpCatB
    '
    Me.TpCatB.Controls.Add(Me.Crv2)
    Me.TpCatB.Location = New System.Drawing.Point(4, 22)
    Me.TpCatB.Name = "TpCatB"
    Me.TpCatB.Size = New System.Drawing.Size(648, 354)
    Me.TpCatB.TabIndex = 1
    Me.TpCatB.Text = "B-Category"
    Me.TpCatB.UseVisualStyleBackColor = True
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
    Me.Crv2.Size = New System.Drawing.Size(632, 340)
    Me.Crv2.TabIndex = 2
    Me.Crv2.ViewTimeSelectionFormula = ""
    '
    'TpCatC
    '
    Me.TpCatC.Controls.Add(Me.Crv3)
    Me.TpCatC.Location = New System.Drawing.Point(4, 22)
    Me.TpCatC.Name = "TpCatC"
    Me.TpCatC.Size = New System.Drawing.Size(648, 354)
    Me.TpCatC.TabIndex = 5
    Me.TpCatC.Text = "C-Category"
    Me.TpCatC.UseVisualStyleBackColor = True
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
    Me.Crv3.Location = New System.Drawing.Point(8, 5)
    Me.Crv3.Name = "Crv3"
    Me.Crv3.SelectionFormula = ""
    Me.Crv3.Size = New System.Drawing.Size(632, 344)
    Me.Crv3.TabIndex = 2
    Me.Crv3.ViewTimeSelectionFormula = ""
    '
    'TpOPM
    '
    Me.TpOPM.Controls.Add(Me.crv4)
    Me.TpOPM.Location = New System.Drawing.Point(4, 22)
    Me.TpOPM.Name = "TpOPM"
    Me.TpOPM.Size = New System.Drawing.Size(648, 354)
    Me.TpOPM.TabIndex = 6
    Me.TpOPM.Text = "OPM"
    Me.TpOPM.UseVisualStyleBackColor = True
    '
    'crv4
    '
    Me.crv4.ActiveViewIndex = -1
    Me.crv4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.crv4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.crv4.Cursor = System.Windows.Forms.Cursors.Default
    Me.crv4.DisplayStatusBar = False
    Me.crv4.DisplayToolbar = False
    Me.crv4.Location = New System.Drawing.Point(8, 5)
    Me.crv4.Name = "crv4"
    Me.crv4.SelectionFormula = ""
    Me.crv4.Size = New System.Drawing.Size(632, 344)
    Me.crv4.TabIndex = 3
    Me.crv4.ViewTimeSelectionFormula = ""
    '
    'TpMissing
    '
    Me.TpMissing.Controls.Add(Me.Crv5)
    Me.TpMissing.Location = New System.Drawing.Point(4, 22)
    Me.TpMissing.Name = "TpMissing"
    Me.TpMissing.Size = New System.Drawing.Size(648, 354)
    Me.TpMissing.TabIndex = 7
    Me.TpMissing.Text = "Missing"
    Me.TpMissing.UseVisualStyleBackColor = True
    '
    'Crv5
    '
    Me.Crv5.ActiveViewIndex = -1
    Me.Crv5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv5.Cursor = System.Windows.Forms.Cursors.Default
    Me.Crv5.DisplayStatusBar = False
    Me.Crv5.DisplayToolbar = False
    Me.Crv5.Location = New System.Drawing.Point(8, 5)
    Me.Crv5.Name = "Crv5"
    Me.Crv5.SelectionFormula = ""
    Me.Crv5.Size = New System.Drawing.Size(632, 344)
    Me.Crv5.TabIndex = 4
    Me.Crv5.ViewTimeSelectionFormula = ""
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
    Me.TpAll.ResumeLayout(False)
    Me.TpCatB.ResumeLayout(False)
    Me.TpCatC.ResumeLayout(False)
    Me.TpOPM.ResumeLayout(False)
    Me.TpMissing.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub CrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    RunReport1()
    RunReport2()
    RunReport3()
    RunReportErr()
    'RunReport4()
    TabCtl1.TabPages.Remove(TpOPM)
    If WrkdsErr.Tables(0).Rows.Count = 0 Then
      TabCtl1.TabPages.Remove(TpMissing)
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
    myreport5.Close()
    myreport5.Dispose()
  End Sub
  Private Sub RunReport1()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTO110.rpt", myTOWN._TOWNBR)
    With myreport1
      .Load(ReportPath)
      .SetDataSource(Wrkds)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyTownNum", myTOWN._TOWNBR)
      .SetParameterValue("MyCurYear", MyUtils.CnvSng(MyFrmTO110B.TxtGLYear.Text))
      .SetParameterValue("MyCurMillRate", WrkCurMillRt)
      .SetParameterValue("MyCategory", "All Categories")
      .SetParameterValue("MyPrvYear", MyUtils.CnvSng(MyFrmTO110B.TxtGLYear.Text) - 1)
      .SetParameterValue("MyPrvMillRate", WrkPrvMillRt)
      .SetParameterValue("MyMVMillRate", WrkMVMillRt)
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
    ReportPath = MyUtils.GetReportPath("PrtTO110.rpt", myTOWN._TOWNBR)
    With myreport2
      .Load(ReportPath)
      .SetDataSource(WrkdsCatB)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyTownNum", myTOWN._TOWNBR)
      .SetParameterValue("MyCurYear", MyUtils.CnvSng(MyFrmTO110B.TxtGLYear.Text))
      .SetParameterValue("MyCurMillRate", WrkCurMillRt)
      .SetParameterValue("MyCategory", "B-Category")
      .SetParameterValue("MyPrvYear", MyUtils.CnvSng(MyFrmTO110B.TxtGLYear.Text) - 1)
      .SetParameterValue("MyPrvMillRate", WrkPrvMillRt)
      .SetParameterValue("MyMVMillRate", WrkMVMillRt)
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
  Private Sub RunReport3()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTO110.rpt", myTOWN._TOWNBR)
    With myreport3
      .Load(ReportPath)
      .SetDataSource(WrkdsCatC)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyTownNum", myTOWN._TOWNBR)
      .SetParameterValue("MyCurYear", MyUtils.CnvSng(MyFrmTO110B.TxtGLYear.Text))
      .SetParameterValue("MyCurMillRate", WrkCurMillRt)
      .SetParameterValue("MyCategory", "C-Category")
      .SetParameterValue("MyPrvYear", MyUtils.CnvSng(MyFrmTO110B.TxtGLYear.Text) - 1)
      .SetParameterValue("MyPrvMillRate", WrkPrvMillRt)
      .SetParameterValue("MyMVMillRate", WrkMVMillRt)
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

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTO110OPM.rpt", myTOWN._TOWNBR)
    With myreport4
      .Load(ReportPath)
      .SetParameterValue("MyTown", WrkTown)
      .SetParameterValue("MyYear", MyUtils.CnvSng(MyFrmTO110B.TxtGLYear.Text))
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
    With crv4
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
  Private Sub RunReportErr()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTO110Err.rpt", myTOWN._TOWNBR)
    With myreport5
      .Load(ReportPath)
      .SetDataSource(WrkdsErr)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
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
End Class






