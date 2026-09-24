Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim WrkMargin As CrystalDecisions.Shared.PageMargins
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpRegular As System.Windows.Forms.TabPage
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend wrkds As DataSet = New DataSet
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
    Me.TabControl1.SuspendLayout()
    Me.TpRegular.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabControl1.Controls.Add(Me.TpRegular)
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

    RunReport()
  End Sub
  Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    myreport.Close()
    myreport.Dispose()
  End Sub

  Private Sub RunReport()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTXE58.rpt", myTOWN._TOWNBR)
    With myreport
      .Load(ReportPath)
      If MyReportLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        .PrintOptions.ApplyPageMargins(WrkMargin)
      End If
      .SetDataSource(wrkds)
      .SetParameterValue("myreportTitle", "Grouped Deliquent List")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTXE58B.TxtFromGLYear.Text))
      .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTXE58B.TxtToGLYear.Text))
      .SetParameterValue("MyDist", MyUtils.CnvSng(MyFrmTXE58B.TxtDist.Text))
      .SetParameterValue("MyIntDate", MyFrmTXE58B.DtPckDue.Value)
      .SetParameterValue("MyBank", MyFrmTXE58B.TxtBankCd.Text)
      .SetParameterValue("MySuspense", MyFrmTXE58B.ChkSuspense.Checked)
      .SetParameterValue("MyUnposted", MyFrmTXE58B.ChkUnPosted.Checked)
      .SetParameterValue("MyTypes", MyTypes)
      .SetParameterValue("MyMin", MyUtils.CnvSng(MyFrmTXE58B.TxtMin.Text))
      .SetParameterValue("MyMinYr", MyUtils.CnvSng(MyFrmTXE58B.TxtMinYrs.Text))
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
End Class
