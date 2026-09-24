Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myGLHEAD As GLHEAD.MyData
  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabpgWork As System.Windows.Forms.TabPage
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TabPgTot As System.Windows.Forms.TabPage
  Friend WithEvents crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WrkReportFmt As String
  Friend wrkds As DataSet = New DataSet
  Friend wrkdsTot As DataSet = New DataSet
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
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.TabControl1 = New System.Windows.Forms.TabControl
    Me.TabpgWork = New System.Windows.Forms.TabPage
    Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
    Me.TabPgTot = New System.Windows.Forms.TabPage
    Me.crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
    Me.TabControl1.SuspendLayout()
    Me.TabpgWork.SuspendLayout()
    Me.TabPgTot.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabControl1.Controls.Add(Me.TabpgWork)
    Me.TabControl1.Controls.Add(Me.TabPgTot)
    Me.TabControl1.Location = New System.Drawing.Point(2, 2)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(660, 383)
    Me.TabControl1.TabIndex = 1
    '
    'TabpgWork
    '
    Me.TabpgWork.Controls.Add(Me.Crv1)
    Me.TabpgWork.Location = New System.Drawing.Point(4, 22)
    Me.TabpgWork.Name = "TabpgWork"
    Me.TabpgWork.Padding = New System.Windows.Forms.Padding(3)
    Me.TabpgWork.Size = New System.Drawing.Size(652, 357)
    Me.TabpgWork.TabIndex = 0
    Me.TabpgWork.Text = "Worksheet"
    Me.TabpgWork.UseVisualStyleBackColor = True
    '
    'Crv1
    '
    Me.Crv1.ActiveViewIndex = -1
    Me.Crv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv1.AutoSize = True
    Me.Crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv1.DisplayStatusBar = False
    Me.Crv1.DisplayToolbar = False
    Me.Crv1.Location = New System.Drawing.Point(6, 2)
    Me.Crv1.Name = "Crv1"
    Me.Crv1.SelectionFormula = ""
    Me.Crv1.Size = New System.Drawing.Size(640, 352)
    Me.Crv1.TabIndex = 3
    Me.Crv1.ViewTimeSelectionFormula = ""
    '
    'TabPgTot
    '
    Me.TabPgTot.Controls.Add(Me.crv2)
    Me.TabPgTot.Location = New System.Drawing.Point(4, 22)
    Me.TabPgTot.Name = "TabPgTot"
    Me.TabPgTot.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPgTot.Size = New System.Drawing.Size(652, 357)
    Me.TabPgTot.TabIndex = 1
    Me.TabPgTot.Text = "Summary"
    Me.TabPgTot.UseVisualStyleBackColor = True
    '
    'crv2
    '
    Me.crv2.ActiveViewIndex = -1
    Me.crv2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.crv2.AutoSize = True
    Me.crv2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.crv2.DisplayStatusBar = False
    Me.crv2.DisplayToolbar = False
    Me.crv2.Location = New System.Drawing.Point(6, 2)
    Me.crv2.Name = "crv2"
    Me.crv2.SelectionFormula = ""
    Me.crv2.Size = New System.Drawing.Size(640, 352)
    Me.crv2.TabIndex = 3
    Me.crv2.ViewTimeSelectionFormula = ""
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
    Me.TabpgWork.ResumeLayout(False)
    Me.TabpgWork.PerformLayout()
    Me.TabPgTot.ResumeLayout(False)
    Me.TabPgTot.PerformLayout()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myGLHEAD = New GLHEAD.MyData()
    myGLHEAD.MyDBConn = myDBConnect
    myGLHEAD.GetOneRecordP(0, 0)

    WrkYear = MyUtils.CnvSng(MyFrmGL650B.LblToYear.Text)
    RunReport1()
    RunReportTot()
  End Sub
  Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    myreport.Close()
    myreport.Dispose()
    myreport2.Close()
    myreport2.Dispose()
  End Sub

  Private Sub RunReport1()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = ""
    Select Case WrkReportFmt
      Case "Prev2"
        ReportPath = MyUtils.GetReportPath("PrtGL650.rpt", myTOWN._TOWNBR)
      Case "Adopted"
        ReportPath = MyUtils.GetReportPath("PrtGL650B.rpt", myTOWN._TOWNBR)
      Case "Original"
        ReportPath = MyUtils.GetReportPath("PrtGL650C.rpt", myTOWN._TOWNBR)
      Case "Variance"
        ReportPath = MyUtils.GetReportPath("PrtGL650D.rpt", myTOWN._TOWNBR)
      Case "Prev5"
        ReportPath = MyUtils.GetReportPath("PrtGL650E.rpt", myTOWN._TOWNBR)
    End Select
    With myreport
      .Load(ReportPath)
      .SetDataSource(wrkds)
      .SetParameterValue("myreportTitle", "Budget Expenditures and Revenues")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyFund", MyUtils.CnvSng(MyFrmGL650B.TxtFund.Text))
      .SetParameterValue("MyDept", MyUtils.CnvSng(MyFrmGL650B.TxtDept.Text))
      .SetParameterValue("MyYear", WrkYear)
      Select Case WrkReportFmt
        Case "Original"
          If MyFrmGL650B.ChkPageDept.Checked = True Then
            .SetParameterValue("MyPageDept", "True")
          Else
            .SetParameterValue("MyPageDept", "False")
          End If
        Case "Prev5"
          .SetParameterValue("MyPrevYrs5", BuildYears(WrkYear, -5))
          .SetParameterValue("MyPrevYrs4", BuildYears(WrkYear, -4))
        Case Else
      End Select
      .SetParameterValue("MyPrevYrs3", BuildYears(WrkYear, -3))
      .SetParameterValue("MyPrevYrs2", BuildYears(WrkYear, -2))
      .SetParameterValue("MyPrevYrs1", BuildYears(WrkYear, -1))
      .SetParameterValue("MyCurrYrs", BuildYears(WrkYear, 0))
      .SetParameterValue("MyGLHead1", Trim(myGLHEAD._BUDC1))
      .SetParameterValue("MyGLHead2", Trim(myGLHEAD._BUDC2))
      .SetParameterValue("MyGLHead3", Trim(myGLHEAD._BUDC3))
      .SetParameterValue("MyAsof", MyFrmGL650B.DtPckAsof.Value)
      .SetParameterValue("MyHide", MyFrmGL650B.cbhideactual.Checked.ToString)
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
  Private Sub RunReportTot()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = ""
    Select Case WrkReportFmt
      Case "Prev2"
        ReportPath = MyUtils.GetReportPath("PrtGL650Tot.rpt", myTOWN._TOWNBR)
      Case "Adopted"
        ReportPath = MyUtils.GetReportPath("PrtGL650TotB.rpt", myTOWN._TOWNBR)
      Case "Original"
        ReportPath = MyUtils.GetReportPath("PrtGL650TotC.rpt", myTOWN._TOWNBR)
      Case "Variance"
        ReportPath = MyUtils.GetReportPath("PrtGL650TotD.rpt", myTOWN._TOWNBR)
      Case "Prev5"
        ReportPath = MyUtils.GetReportPath("PrtGL650TotE.rpt", myTOWN._TOWNBR)
    End Select
    With myreport2
      .Load(ReportPath)
      .SetDataSource(wrkdsTot)
      .SetParameterValue("myreportTitle", "Budget Summary of Expenditures and Revenues")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyFund", MyUtils.CnvSng(MyFrmGL650B.TxtFund.Text))
      .SetParameterValue("MyYear", WrkYear)
      .SetParameterValue("MyDept", MyUtils.CnvSng(MyFrmGL650B.TxtDept.Text))
      Select Case WrkReportFmt
        Case "Prev5"
          .SetParameterValue("MyPrevYrs5", BuildYears(WrkYear, -5))
          .SetParameterValue("MyPrevYrs4", BuildYears(WrkYear, -4))
        Case Else
      End Select
      .SetParameterValue("MyPrevYrs3", BuildYears(WrkYear, -3))
      .SetParameterValue("MyPrevYrs2", BuildYears(WrkYear, -2))
      .SetParameterValue("MyPrevYrs1", BuildYears(WrkYear, -1))
      .SetParameterValue("MyCurrYrs", BuildYears(WrkYear, 0))
      .SetParameterValue("MyGLHead1", Trim(myGLHEAD._BUDC1))
      .SetParameterValue("MyGLHead2", Trim(myGLHEAD._BUDC2))
      .SetParameterValue("MyGLHead3", Trim(myGLHEAD._BUDC3))
      .SetParameterValue("MyAsof", MyFrmGL650B.DtPckAsof.Value)
      .SetParameterValue("MyHide", MyFrmGL650B.cbhideactual.Checked.ToString)
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
End Class
