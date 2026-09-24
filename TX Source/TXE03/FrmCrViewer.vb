Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument  'added 12/8/25 Ken
  Dim WrkMargin As CrystalDecisions.Shared.PageMargins
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpRegular As System.Windows.Forms.TabPage
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpWide As System.Windows.Forms.TabPage
  Friend WithEvents crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend wrkds As DataSet = New DataSet
  Friend WithEvents TpLien As TabPage
  Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend wrkdsliensale As DataSet = New DataSet   'added 12/8/25 Ken
  Dim Wrklien As Boolean     '12/8/25 added Ken
  Dim WrkMin As Decimal        '12/8/25 added Ken
  Dim WrkMinYrs As Integer        '12/8/25 added Ken

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
    Me.TpRegular = New System.Windows.Forms.TabPage()
    Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpWide = New System.Windows.Forms.TabPage()
    Me.crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpLien = New System.Windows.Forms.TabPage()
    Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabControl1.SuspendLayout()
    Me.TpRegular.SuspendLayout()
    Me.TpWide.SuspendLayout()
    Me.TpLien.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabControl1.Controls.Add(Me.TpRegular)
    Me.TabControl1.Controls.Add(Me.TpWide)
    Me.TabControl1.Controls.Add(Me.TpLien)
    Me.TabControl1.Location = New System.Drawing.Point(10, 5)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(644, 376)
    Me.TabControl1.TabIndex = 3
    '
    'TpRegular
    '
    Me.TpRegular.Controls.Add(Me.Crv1)
    Me.TpRegular.Location = New System.Drawing.Point(4, 22)
    Me.TpRegular.Name = "TpRegular"
    Me.TpRegular.Size = New System.Drawing.Size(636, 350)
    Me.TpRegular.TabIndex = 0
    Me.TpRegular.Text = "Regular"
    Me.TpRegular.UseVisualStyleBackColor = True
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
    Me.Crv1.Size = New System.Drawing.Size(640, 352)
    Me.Crv1.TabIndex = 1
    Me.Crv1.ViewTimeSelectionFormula = ""
    '
    'TpWide
    '
    Me.TpWide.Controls.Add(Me.crv2)
    Me.TpWide.Location = New System.Drawing.Point(4, 22)
    Me.TpWide.Name = "TpWide"
    Me.TpWide.Size = New System.Drawing.Size(636, 350)
    Me.TpWide.TabIndex = 1
    Me.TpWide.Text = "Wide"
    Me.TpWide.UseVisualStyleBackColor = True
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
    Me.crv2.Location = New System.Drawing.Point(-2, -1)
    Me.crv2.Name = "crv2"
    Me.crv2.SelectionFormula = ""
    Me.crv2.Size = New System.Drawing.Size(640, 352)
    Me.crv2.TabIndex = 2
    Me.crv2.ViewTimeSelectionFormula = ""
    '
    'TpLien
    '
    Me.TpLien.Controls.Add(Me.Crv3)
    Me.TpLien.Location = New System.Drawing.Point(4, 22)
    Me.TpLien.Name = "TpLien"
    Me.TpLien.Size = New System.Drawing.Size(636, 350)
    Me.TpLien.TabIndex = 2
    Me.TpLien.Text = "Lien Sale"
    Me.TpLien.UseVisualStyleBackColor = True
    '
    'Crv3
    '
    Me.Crv3.ActiveViewIndex = -1
    Me.Crv3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv3.Cursor = System.Windows.Forms.Cursors.Default
    Me.Crv3.DisplayStatusBar = False
    Me.Crv3.DisplayToolbar = False
    Me.Crv3.Location = New System.Drawing.Point(-2, -1)
    Me.Crv3.Name = "Crv3"
    Me.Crv3.SelectionFormula = ""
    Me.Crv3.Size = New System.Drawing.Size(640, 352)
    Me.Crv3.TabIndex = 3
    Me.Crv3.ViewTimeSelectionFormula = ""
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
    Me.TpRegular.ResumeLayout(False)
    Me.TpWide.ResumeLayout(False)
    Me.TpLien.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    With WrkMargin
      .leftMargin = 250
      .rightMargin = 150
      .topMargin = 500
      .bottomMargin = 150
    End With

    'added 12/8/25 Ken
    Wrklien = False
    With MyFrmTXE03B
      If IsNumeric(.TxtMin.Text) Then
        WrkMin = CDec(.TxtMin.Text)
        Wrklien = True
      Else
        WrkMin = 0D
      End If
      If IsNumeric(.TxtMinYrs.Text) Then
        WrkMinYrs = CInt(.TxtMinYrs.Text)
        Wrklien = True
      Else
        WrkMinYrs = 0
      End If
    End With



    If Wrklien = False Then

      ' --- Regular mode ---
      TabControl1.TabPages.Clear()
      TabControl1.TabPages.Add(TpRegular)
      TabControl1.TabPages.Add(TpWide)

      Crv1.Visible = True
      crv2.Visible = True
      Crv3.Visible = False

      RunReport1()
      RunReport2()

    Else

      ' --- Lien Sale Mode ---
      TabControl1.TabPages.Clear()
      TabControl1.TabPages.Add(TpLien)

      Crv1.Visible = False
      crv2.Visible = False
      Crv3.Visible = True

      RunReport3()

    End If

  End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport.Close()
  myreport.Dispose()
  myreport2.Close()
    myreport2.Dispose()
    myreport3.Close()
    myreport3.Dispose()
  End Sub

  Private Sub RunReport1()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTXE03.rpt", myTOWN._TOWNBR)
   With myreport
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      .PrintOptions.ApplyPageMargins(WrkMargin)
    End If
    .SetDataSource(wrkds)
    .SetParameterValue("myreportTitle", "Tax Due List")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTXE03B.TxtFromGLYear.Text))
    .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTXE03B.TxtToGLYear.Text))
    .SetParameterValue("MyDist", MyUtils.CnvSng(MyFrmTXE03B.TxtDist.Text))
    .SetParameterValue("MyDueDt", MyFrmTXE03B.DtPckDue.Value)
    .SetParameterValue("MyBank", MyFrmTXE03B.TxtBankCd.Text)
    .SetParameterValue("MyPaidAccts", MyFrmTXE03B.ChkPaid.Checked)
    .SetParameterValue("MyUnposted", MyFrmTXE03B.ChkUnPosted.Checked)
    .SetParameterValue("MySuspense", MyFrmTXE03B.ChkSuspense.Checked)
    .SetParameterValue("MyTypes", MyTypes)
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
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTXE03B.rpt", myTOWN._TOWNBR)
    With myreport2
      .Load(ReportPath)
      .SetDataSource(wrkds)
      .SetParameterValue("myreportTitle", "Tax Due List")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTXE03B.TxtFromGLYear.Text))
      .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTXE03B.TxtToGLYear.Text))
      .SetParameterValue("MyDist", MyUtils.CnvSng(MyFrmTXE03B.TxtDist.Text))
      .SetParameterValue("MyDueDt", MyFrmTXE03B.DtPckDue.Value)
      .SetParameterValue("MyBank", MyFrmTXE03B.TxtBankCd.Text)
      .SetParameterValue("MyPaidAccts", MyFrmTXE03B.ChkPaid.Checked)
      .SetParameterValue("MyUnposted", MyFrmTXE03B.ChkUnPosted.Checked)
      .SetParameterValue("MySuspense", MyFrmTXE03B.ChkSuspense.Checked)
      .SetParameterValue("MyTypes", MyTypes)
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

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTXE03C.rpt", myTOWN._TOWNBR)
    With myreport3
      .Load(ReportPath)
      If MyReportLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        .PrintOptions.ApplyPageMargins(WrkMargin)
      End If
      .SetDataSource(wrkdsliensale)
      .SetParameterValue("myreportTitle", "Tax Lien Sale")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTXE03B.TxtFromGLYear.Text))
      .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTXE03B.TxtToGLYear.Text))
      .SetParameterValue("MyDist", MyUtils.CnvSng(MyFrmTXE03B.TxtDist.Text))
      .SetParameterValue("MyDueDt", MyFrmTXE03B.DtPckDue.Value)
      .SetParameterValue("MyBank", MyFrmTXE03B.TxtBankCd.Text)
      .SetParameterValue("MyPaidAccts", MyFrmTXE03B.ChkPaid.Checked)
      .SetParameterValue("MyUnposted", MyFrmTXE03B.ChkUnPosted.Checked)
      .SetParameterValue("MySuspense", MyFrmTXE03B.ChkSuspense.Checked)
      .SetParameterValue("MyTypes", MyTypes)
      .SetParameterValue("MyMin", WrkMin)
      .SetParameterValue("MyMinYr", WrkMinYrs)
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
End Class






