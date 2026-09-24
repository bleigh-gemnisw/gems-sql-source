Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
	Dim WrkAltFormId As String
	Dim WrkType As String
	Friend wrkds As DataSet = New DataSet
  Friend wrkdsTot As DataSet = New DataSet
  Friend WrkRptID As String
  Friend WrkLienFee As Decimal
  Friend WrkDueDate1 As String
  Friend WrkDueDate2 As String
  Friend WrkIntDate As Date
  Friend WrkLienDate As Date
  Dim myTXFMSTMT As TXFMSTMT.myData
	Dim MyTXPROF As TXPROF.myData

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
Friend WithEvents crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents TpTotals As System.Windows.Forms.TabPage
Friend WithEvents TpDetail As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.TabControl1 = New System.Windows.Forms.TabControl
Me.TpTotals = New System.Windows.Forms.TabPage
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpDetail = New System.Windows.Forms.TabPage
Me.crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabControl1.SuspendLayout()
Me.TpTotals.SuspendLayout()
Me.TpDetail.SuspendLayout()
Me.SuspendLayout()
'
'TabControl1
'
Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabControl1.Controls.Add(Me.TpTotals)
Me.TabControl1.Controls.Add(Me.TpDetail)
Me.TabControl1.Location = New System.Drawing.Point(12, 4)
Me.TabControl1.Name = "TabControl1"
Me.TabControl1.SelectedIndex = 0
Me.TabControl1.Size = New System.Drawing.Size(644, 376)
Me.TabControl1.TabIndex = 1
'
'TpTotals
'
Me.TpTotals.Controls.Add(Me.Crv1)
Me.TpTotals.Location = New System.Drawing.Point(4, 22)
Me.TpTotals.Name = "TpTotals"
Me.TpTotals.Size = New System.Drawing.Size(636, 350)
Me.TpTotals.TabIndex = 0
Me.TpTotals.Text = "Totals"
Me.TpTotals.UseVisualStyleBackColor = True
'
'Crv1
'
Me.Crv1.ActiveViewIndex = -1
Me.Crv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.Crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Crv1.Location = New System.Drawing.Point(0, 0)
Me.Crv1.Name = "Crv1"
Me.Crv1.SelectionFormula = ""
Me.Crv1.Size = New System.Drawing.Size(640, 352)
Me.Crv1.TabIndex = 1
Me.Crv1.ViewTimeSelectionFormula = ""
'
'TpDetail
'
Me.TpDetail.Controls.Add(Me.crv2)
Me.TpDetail.Location = New System.Drawing.Point(4, 22)
Me.TpDetail.Name = "TpDetail"
Me.TpDetail.Size = New System.Drawing.Size(636, 350)
Me.TpDetail.TabIndex = 1
Me.TpDetail.Text = "Detail"
Me.TpDetail.UseVisualStyleBackColor = True
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
Me.TpTotals.ResumeLayout(False)
Me.TpDetail.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport.Close()
  myreport.Dispose()
  myreport2.Close()
  myreport2.Dispose()
End Sub

Private Sub CrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    WrkAltFormId = MyFrmTX304B.TxtAltFormID.Text
		WrkType = MyFrmTX304B.TxtTypes.Text
		GetTXFMSTMT(WrkType)
    If Trim(myTXFMSTMT._LINE1) = String.Empty Then
      GetTXFMSTMT(" ")
    End If

    Select Case WrkRptID
    Case "Edit"
      RunReportEdit()
    Case "Notice"
      RunReportNotice()
    Case "TownClerk"
      RunReportTownClerk()
    Case "Blanket"
      RunReportBlanket()
    End Select
    RunReportTotals()
 End Sub
  Private Sub RunReportTotals()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTX304Tot.rpt", myTOWN._TOWNBR)
   With myreport
    .Load(ReportPath)
    .SetDataSource(wrkdsTot)
    .SetParameterValue("myreportTitle", "Lien Totals")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyInterestDate", Format(WrkIntDate, "M/d/yyyy"))
    .SetParameterValue("MyLienDate", Format(WrkLienDate, "M/d/yyyy"))
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
  Private Sub RunReportNotice()
   Dim ReportName As String
   Dim ReportPath As String
   Dim WrkExists As Boolean

   Me.Text = "Report Viewer"
   ReportName = "PrtTX3043" & WrkAltFormId & ".rpt"
   ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
   If WrkAltFormId <> "" Then
     WrkExists = MyUtils.CheckFileExists(ReportPath)
     If Not WrkExists Then
       MsgBox("Close and retry with correct Form ID", MsgBoxStyle.Critical, "Cannot find report")
       Exit Sub
     End If
   End If

   With myreport2
    .Load(ReportPath)
    .SetDataSource(wrkds)
    .SetParameterValue("myreportTitle", "Notice of Lien")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    If wrkds.Tables(0).Rows.Count > 0 Then
      .SetParameterValue("MyLienFee", Format(WrkLienFee, "$#0.00"))
    Else
      .SetParameterValue("MyLienFee", "$0.00")
    End If
    .SetParameterValue("MyIntDate", Format(WrkIntDate, "short date"))
    .SetParameterValue("MyPayTo", Trim(myTXFMSTMT._PAYTO))
    .SetParameterValue("MyLine1", Trim(myTXFMSTMT._LINE1))
    .SetParameterValue("MyLine2", Trim(myTXFMSTMT._LINE2))
    .SetParameterValue("MyLine3", Trim(myTXFMSTMT._LINE3))
    .SetParameterValue("MyLine4", Trim(myTXFMSTMT._LINE4))
    .SetParameterValue("MyLine5", Trim(myTXFMSTMT._LINE5))
    .SetParameterValue("MyTitle", Trim(myTXFMSTMT._TITLE))
    .SetParameterValue("MyLienDate", Format(WrkLienDate, "short date"))
    .SetParameterValue("MyMsg", Trim(MyFrmTX304B.TxtMsg.Text))
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
  Private Sub RunReportTownClerk()
   Dim ReportName As String
   Dim ReportPath As String
   Dim WrkExists As Boolean
   Dim WrkFamily As String
   Dim WrkTownState As String
   Dim WrkShowVol As Boolean

   Me.Text = "Report Viewer"
   WrkTownState = Trim(myTXFMSTMT._TWNAME) & ", " & myTXFMSTMT._STATE
   ReportName = "PrtTX3044" & WrkAltFormId & ".rpt"
   ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
   If WrkAltFormId <> "" Then
     WrkExists = MyUtils.CheckFileExists(ReportPath)
     If Not WrkExists Then
       MsgBox("Close and retry with correct Form ID", MsgBoxStyle.Critical, "Cannot find report")
       Exit Sub
     End If
   End If

   WrkFamily = GetTXTypeFamily(MyFrmTX304B.TxtTypes.Text)
   Select Case WrkFamily
   Case "R", "A", "U"
     WrkShowVol = True
   Case Else
     WrkShowVol = False
   End Select

   With myreport2
    .Load(ReportPath)
    .SetDataSource(wrkds)
    .SetParameterValue("myreportTitle", "Certificate of Continuing Tax Lien")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyTownCounty", Trim(myTOWN._COUNTY))
    If wrkds.Tables(0).Rows.Count > 0 Then
      .SetParameterValue("MyDueDate1", WrkDueDate1)
      .SetParameterValue("MyDueDate2", WrkDueDate2)
      .SetParameterValue("MyShowVol", WrkShowVol)
    Else
      .SetParameterValue("MyDueDate1", "1/1/1900")
      .SetParameterValue("MyDueDate2", "1/1/1900")
      .SetParameterValue("MyShowVol", WrkShowVol)
    End If
    .SetParameterValue("MyTownState", WrkTownState)
    .SetParameterValue("MySigned", Trim(myTXFMSTMT._SIGNED))
    .SetParameterValue("MyLienDate", Format(WrkLienDate, "M/d/yyyy"))
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
  Private Sub RunReportEdit()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTX3045.rpt", myTOWN._TOWNBR)

   With myreport2
    .Load(ReportPath)
    .SetDataSource(wrkds)
    .SetParameterValue("MyReportTitle", "Lien Edit")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyInterestDate", Format(WrkIntDate, "M/d/yyyy"))
    .SetParameterValue("MyLienDate", Format(WrkLienDate, "M/d/yyyy"))
    .SetParameterValue("MyLienFee", Format(WrkLienFee))
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
  Private Sub RunReportBlanket()
   Dim ReportName As String
   Dim ReportPath As String
   Dim WrkExists As Boolean
   Dim WrkDueDates As String
   Dim WrkTownState As String

   Me.Text = "Report Viewer"
   WrkTownState = Trim(myTXFMSTMT._TWNAME) & ", " & myTXFMSTMT._STATE
   WrkDueDates = WrkDueDate1
   If WrkDueDate2 <> "" Then
    WrkDueDates = WrkDueDates & " & " & WrkDueDate2
   End If
   ReportName = "PrtTX3046" & WrkAltFormId & ".rpt"
   ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
   If WrkAltFormId <> "" Then
     WrkExists = MyUtils.CheckFileExists(ReportPath)
     If Not WrkExists Then
       MsgBox("Close and retry with correct Form ID", MsgBoxStyle.Critical, "Cannot find report")
       Exit Sub
     End If
   End If

   With myreport2
    .Load(ReportPath)
    .SetDataSource(wrkds)
    .SetParameterValue("MyReportTitle", "Blanket Lien")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyTownCounty", Trim(myTOWN._COUNTY))
    .SetParameterValue("MyGLYear", MyFrmTX304B.TxtGLYear.Text)
    .SetParameterValue("MyInterestDate", Format(WrkIntDate, "M/d/yyyy"))
    .SetParameterValue("MyLienDate", Format(WrkLienDate, "M/d/yyyy"))
    .SetParameterValue("MyDueDates", WrkDueDates)
    .SetParameterValue("MyTownState", WrkTownState)
    .SetParameterValue("MyTitle", Trim(myTXFMSTMT._TITLE))
    .SetParameterValue("MyClerk", Trim(myTXFMSTMT._CLERK))
    .SetParameterValue("MySigned", Trim(myTXFMSTMT._SIGNED))
    If wrkds.Tables(0).Rows.Count > 0 Then
      .SetParameterValue("MyDueDate1", WrkDueDate1)
      .SetParameterValue("MyDueDate2", WrkDueDate2)
    Else
      .SetParameterValue("MyDueDate1", "1/1/1900")
      .SetParameterValue("MyDueDate2", "1/1/1900")
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
Public Sub GetTXFMSTMT(ByVal WrkType As String)
  myTXFMSTMT = New TXFMSTMT.mydata(MyDBConnect)

  myTXFMSTMT.GetOneRecordP(WrkType)
End Sub

End Class










