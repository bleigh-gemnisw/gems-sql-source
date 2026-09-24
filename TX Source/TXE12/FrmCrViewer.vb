Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend WrkReport As Boolean
  Friend WrkDueDate As Integer
  Friend WrkGraceDate As Integer
  Friend Wrkds As DataSet
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Dim myTXFMSTMT As TXFMSTMT.myData

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
    Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
    Me.SuspendLayout()
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
    Me.Crv1.Location = New System.Drawing.Point(2, 3)
    Me.Crv1.Name = "Crv1"
    Me.Crv1.SelectionFormula = ""
    Me.Crv1.Size = New System.Drawing.Size(661, 381)
    Me.Crv1.TabIndex = 2
    Me.Crv1.ViewTimeSelectionFormula = ""
    '
    'FrmCrViewer
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(664, 386)
    Me.Controls.Add(Me.Crv1)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmCrViewer"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "CrViewer"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub CrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    GetTXFMSTMT(" ")
    If WrkReport Then
      RunReport()
    Else
      RunReportLbl()
    End If
  End Sub
  Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    myreport1.Close()
    myreport1.Dispose()
  End Sub
  Private Sub RunReport()
    Dim ReportName As String
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportName = "PrtTXE12.rpt"
    ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, "")

    With myreport1
      .Load(ReportPath)
      .SetDataSource(Wrkds)
      .SetParameterValue("myreportTitle", "Payment Reminder")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyPayTo", Trim(myTXFMSTMT._PAYTO))
      .SetParameterValue("MyLine1", Trim(myTXFMSTMT._LINE1))
      .SetParameterValue("MyLine2", Trim(myTXFMSTMT._LINE2))
      .SetParameterValue("MyLine3", Trim(myTXFMSTMT._LINE3))
      .SetParameterValue("MyLine4", Trim(myTXFMSTMT._LINE4))
      .SetParameterValue("MyLine5", Trim(myTXFMSTMT._LINE5))
      .SetParameterValue("MyTitle", Trim(myTXFMSTMT._TITLE))
      .SetParameterValue("MyDueDate", MyUtils.GetDBDateMDY(WrkDueDate))
      .SetParameterValue("MyGraceDate", MyUtils.GetDBDateMDY(WrkGraceDate))
      .SetParameterValue("MyMsg", Trim(MyFrmTXE12B.TxtMsg.Text))
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
  Private Sub RunReportLbl()
    Dim WrkSection As CrystalDecisions.CrystalReports.Engine.Section
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTXE12Lbl.rpt", myTOWN._TOWNBR)
    With myreport1
      .Load(ReportPath)
      .SetDataSource(Wrkds)
    End With
    WrkSection = GetReportSection("Section2")
    WrkSection.Height = MyUtils.CnvSng(MyFrmTXE12B.TxtVAdjust1.Text)
    WrkSection = GetReportSection("DetailSection3")
    WrkSection.Height = MyUtils.CnvSng(MyFrmTXE12B.TxtVAdjust2.Text)
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
  Private Function GetReportSection _
     (ByVal reportSectionName As String) As CrystalDecisions.CrystalReports.Engine.Section
    Dim reportsection As CrystalDecisions.CrystalReports.Engine.Section

    reportsection = myreport1.ReportDefinition.Sections.Item(reportSectionName)
    GetReportSection = reportsection
  End Function
  Public Sub GetTXFMSTMT(ByVal WrkType As String)
    myTXFMSTMT = New TXFMSTMT.mydata(MyDBConnect)

    myTXFMSTMT.GetOneRecordP(WrkType)
  End Sub
End Class






