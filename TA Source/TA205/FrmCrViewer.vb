Imports System.Text
Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport4 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend wrkds As DataSet = New DataSet
  Friend wrkdsExempt As DataSet = New DataSet
  Friend WrkType As String
  Friend WrkAssrName As String
  Friend WrkAssrPhone As String
  Friend WithEvents TabCtl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpNotice As System.Windows.Forms.TabPage
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpReport As System.Windows.Forms.TabPage
  Friend WithEvents TpExmReport As System.Windows.Forms.TabPage
  Friend WithEvents TpExmNotice As System.Windows.Forms.TabPage
  Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents Crv4 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer

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
    Me.TabCtl1 = New System.Windows.Forms.TabControl
    Me.TpNotice = New System.Windows.Forms.TabPage
    Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
    Me.TpReport = New System.Windows.Forms.TabPage
    Me.crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
    Me.TpExmReport = New System.Windows.Forms.TabPage
    Me.TpExmNotice = New System.Windows.Forms.TabPage
    Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
    Me.Crv4 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
    Me.TabCtl1.SuspendLayout()
    Me.TpNotice.SuspendLayout()
    Me.TpReport.SuspendLayout()
    Me.TpExmReport.SuspendLayout()
    Me.TpExmNotice.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabCtl1
    '
    Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabCtl1.Controls.Add(Me.TpNotice)
    Me.TabCtl1.Controls.Add(Me.TpReport)
    Me.TabCtl1.Controls.Add(Me.TpExmNotice)
    Me.TabCtl1.Controls.Add(Me.TpExmReport)
    Me.TabCtl1.Location = New System.Drawing.Point(2, 3)
    Me.TabCtl1.Name = "TabCtl1"
    Me.TabCtl1.SelectedIndex = 0
    Me.TabCtl1.Size = New System.Drawing.Size(660, 381)
    Me.TabCtl1.TabIndex = 0
    '
    'TpNotice
    '
    Me.TpNotice.Controls.Add(Me.Crv1)
    Me.TpNotice.Location = New System.Drawing.Point(4, 22)
    Me.TpNotice.Name = "TpNotice"
    Me.TpNotice.Padding = New System.Windows.Forms.Padding(3)
    Me.TpNotice.Size = New System.Drawing.Size(652, 355)
    Me.TpNotice.TabIndex = 0
    Me.TpNotice.Text = "Notices"
    Me.TpNotice.UseVisualStyleBackColor = True
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
    Me.Crv1.Location = New System.Drawing.Point(0, 4)
    Me.Crv1.Name = "Crv1"
    Me.Crv1.SelectionFormula = ""
    Me.Crv1.Size = New System.Drawing.Size(646, 347)
    Me.Crv1.TabIndex = 4
    Me.Crv1.ViewTimeSelectionFormula = ""
    '
    'TpReport
    '
    Me.TpReport.Controls.Add(Me.crv2)
    Me.TpReport.Location = New System.Drawing.Point(4, 22)
    Me.TpReport.Name = "TpReport"
    Me.TpReport.Padding = New System.Windows.Forms.Padding(3)
    Me.TpReport.Size = New System.Drawing.Size(652, 355)
    Me.TpReport.TabIndex = 1
    Me.TpReport.Text = "Report"
    Me.TpReport.UseVisualStyleBackColor = True
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
    Me.crv2.Location = New System.Drawing.Point(0, 4)
    Me.crv2.Name = "crv2"
    Me.crv2.SelectionFormula = ""
    Me.crv2.Size = New System.Drawing.Size(649, 347)
    Me.crv2.TabIndex = 4
    Me.crv2.ViewTimeSelectionFormula = ""
    '
    'TpExmReport
    '
    Me.TpExmReport.Controls.Add(Me.Crv4)
    Me.TpExmReport.Location = New System.Drawing.Point(4, 22)
    Me.TpExmReport.Name = "TpExmReport"
    Me.TpExmReport.Size = New System.Drawing.Size(652, 355)
    Me.TpExmReport.TabIndex = 2
    Me.TpExmReport.Text = "Exempt Report"
    Me.TpExmReport.UseVisualStyleBackColor = True
    '
    'TpExmNotice
    '
    Me.TpExmNotice.Controls.Add(Me.Crv3)
    Me.TpExmNotice.Location = New System.Drawing.Point(4, 22)
    Me.TpExmNotice.Name = "TpExmNotice"
    Me.TpExmNotice.Size = New System.Drawing.Size(652, 355)
    Me.TpExmNotice.TabIndex = 3
    Me.TpExmNotice.Text = "Exempt Notices"
    Me.TpExmNotice.UseVisualStyleBackColor = True
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
    Me.Crv3.Location = New System.Drawing.Point(0, 4)
    Me.Crv3.Name = "Crv3"
    Me.Crv3.SelectionFormula = ""
    Me.Crv3.Size = New System.Drawing.Size(649, 347)
    Me.Crv3.TabIndex = 5
    Me.Crv3.ViewTimeSelectionFormula = ""
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
    Me.Crv4.Location = New System.Drawing.Point(0, 4)
    Me.Crv4.Name = "Crv4"
    Me.Crv4.SelectionFormula = ""
    Me.Crv4.Size = New System.Drawing.Size(649, 347)
    Me.Crv4.TabIndex = 5
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
    Me.TpNotice.ResumeLayout(False)
    Me.TpReport.ResumeLayout(False)
    Me.TpExmReport.ResumeLayout(False)
    Me.TpExmNotice.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub CrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    RunReport1()
    RunReport2()
    If wrkdsExempt.Tables(0).Rows.Count > 0 Then
      RunReport3()
      RunReport4()
    Else
      TabCtl1.TabPages.Remove(TpExmNotice)
      TabCtl1.TabPages.Remove(TpExmReport)
    End If
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
  End Sub
  Private Sub RunReport1()
    Dim ReportPath As String
    Dim sb As StringBuilder = New StringBuilder

    Me.Text = "Report Viewer"
    If WrkType = "R" Then
      If MyFrmTA205B.RbReval.Checked Then
        ReportPath = MyUtils.GetReportPath("PrtTA205Reval.rpt", myTOWN._TOWNBR)
      Else
        If MyFrmTA205B.RbReArchive.Checked Then
          ReportPath = MyUtils.GetReportPath("PrtTA205REARCH.rpt", myTOWN._TOWNBR)
        Else
          ReportPath = MyUtils.GetReportPath("PrtTA205RE.rpt", myTOWN._TOWNBR)
        End If
      End If
    Else
      ReportPath = MyUtils.GetReportPath("PrtTA205PP.rpt", myTOWN._TOWNBR)
    End If
    sb.Append(Trim(myTOWN._CITY))
    sb.Append(" ")
    sb.Append(myTOWN._ZIP)

    With myreport
      .Load(ReportPath)
      .SetDataSource(wrkds)
      .SetParameterValue("myreportTitle", "Change of Assessment Notice")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyTownAddr", Trim(myTOWN._ADDR1))
      .SetParameterValue("MyTownStZip", sb.ToString)
      .SetParameterValue("MyGLYear", MyUtils.CnvSng(MyFrmTA205B.TxtGLYear.Text))
      .SetParameterValue("MyMeetsIn", MyFrmTA205B.CboMeets.SelectedItem)
      .SetParameterValue("MyFormDate", MyFrmTA205B.DtPckReturn.Value)
      .SetParameterValue("MyPrintDate", MyFrmTA205B.DtPckPrint.Value)
      .SetParameterValue("MyAssrName", WrkAssrName)
      .SetParameterValue("MyAssrPhone", WrkAssrPhone)
      If MyFrmTA205B.RbDecl.Checked Then
        .SetParameterValue("MyTypeDesc", "PP Declaration Increase")
      Else
        .SetParameterValue("MyTypeDesc", GetTXTypeDesc(WrkType))
      End If
      .SetParameterValue("MyExemptions", MyFrmTA205B.ChkExemptions.Checked)
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
    ReportPath = MyUtils.GetReportPath("PrtTA205.rpt", myTOWN._TOWNBR)

    With myreport2
      .Load(ReportPath)
      .SetDataSource(wrkds)
      .SetParameterValue("myreportTitle", "Change of Assessment List")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      If MyFrmTA205B.RbDecl.Checked Then
        .SetParameterValue("MyTypeDesc", "PP Declaration Increase")
      Else
        .SetParameterValue("MyTypeDesc", GetTXTypeDesc(WrkType))
      End If
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
    Dim sb As StringBuilder = New StringBuilder

    Me.Text = "Report Viewer"
    If WrkType = "R" Then
      ReportPath = MyUtils.GetReportPath("PrtTA205RE.rpt", myTOWN._TOWNBR)
    Else
      ReportPath = MyUtils.GetReportPath("PrtTA205PP.rpt", myTOWN._TOWNBR)
    End If
    sb.Append(Trim(myTOWN._CITY))
    sb.Append(" ")
    sb.Append(myTOWN._ZIP)

    With myreport3
      .Load(ReportPath)
      .SetDataSource(wrkdsExempt)
      .SetParameterValue("myreportTitle", "Exempt Change of Assessment Notice")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyTownAddr", Trim(myTOWN._ADDR1))
      .SetParameterValue("MyTownStZip", sb.ToString)
      .SetParameterValue("MyGLYear", MyUtils.CnvSng(MyFrmTA205B.TxtGLYear.Text))
      .SetParameterValue("MyMeetsIn", MyFrmTA205B.CboMeets.SelectedItem)
      .SetParameterValue("MyFormDate", MyFrmTA205B.DtPckReturn.Value)
      .SetParameterValue("MyPrintDate", MyFrmTA205B.DtPckPrint.Value)
      .SetParameterValue("MyAssrName", WrkAssrName)
      .SetParameterValue("MyAssrPhone", WrkAssrPhone)
      .SetParameterValue("MyTypeDesc", GetTXTypeDesc(WrkType))
      .SetParameterValue("MyExemptions", MyFrmTA205B.ChkExemptions.Checked)
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
    ReportPath = MyUtils.GetReportPath("PrtTA205.rpt", myTOWN._TOWNBR)

    With myreport4
      .Load(ReportPath)
      .SetDataSource(wrkdsExempt)
      .SetParameterValue("myreportTitle", "Exempt Change of Assessment List")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyTypeDesc", GetTXTypeDesc(WrkType))
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
