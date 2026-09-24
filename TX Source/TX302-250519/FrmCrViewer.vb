Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport4 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport8 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport9 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreportTot As New CrystalDecisions.CrystalReports.Engine.ReportDocument
	Dim myreportErr As New CrystalDecisions.CrystalReports.Engine.ReportDocument
	Dim WrkAltFormId As String
  Friend Wrkds As DataSet
	Friend WrkdsErr As DataSet
	Friend WrkRptNo As Integer
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpReport As System.Windows.Forms.TabPage
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpTotals As System.Windows.Forms.TabPage
  Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WrkMinInt As Decimal
	Dim myTXFMSTMT As TXFMSTMT.myData
	Friend WithEvents TpErrors As System.Windows.Forms.TabPage
	Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Dim myTXPROF As TXPROF.myData


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
Me.TpReport = New System.Windows.Forms.TabPage
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpTotals = New System.Windows.Forms.TabPage
Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpErrors = New System.Windows.Forms.TabPage
Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabControl1.SuspendLayout()
Me.TpReport.SuspendLayout()
Me.TpTotals.SuspendLayout()
Me.TpErrors.SuspendLayout()
Me.SuspendLayout()
'
'TabControl1
'
Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabControl1.Controls.Add(Me.TpReport)
Me.TabControl1.Controls.Add(Me.TpTotals)
Me.TabControl1.Controls.Add(Me.TpErrors)
Me.TabControl1.Location = New System.Drawing.Point(10, 5)
Me.TabControl1.Name = "TabControl1"
Me.TabControl1.SelectedIndex = 0
Me.TabControl1.Size = New System.Drawing.Size(644, 376)
Me.TabControl1.TabIndex = 2
'
'TpReport
'
Me.TpReport.Controls.Add(Me.Crv1)
Me.TpReport.Location = New System.Drawing.Point(4, 22)
Me.TpReport.Name = "TpReport"
Me.TpReport.Size = New System.Drawing.Size(636, 350)
Me.TpReport.TabIndex = 2
Me.TpReport.Text = "Report"
Me.TpReport.UseVisualStyleBackColor = True
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
Me.Crv1.Location = New System.Drawing.Point(-2, -1)
Me.Crv1.Name = "Crv1"
Me.Crv1.SelectionFormula = ""
Me.Crv1.Size = New System.Drawing.Size(640, 352)
Me.Crv1.TabIndex = 2
Me.Crv1.ViewTimeSelectionFormula = ""
'
'TpTotals
'
Me.TpTotals.Controls.Add(Me.Crv2)
Me.TpTotals.Location = New System.Drawing.Point(4, 22)
Me.TpTotals.Name = "TpTotals"
Me.TpTotals.Size = New System.Drawing.Size(636, 350)
Me.TpTotals.TabIndex = 0
Me.TpTotals.Text = "Totals"
Me.TpTotals.UseVisualStyleBackColor = True
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
Me.Crv2.Location = New System.Drawing.Point(0, 0)
Me.Crv2.Name = "Crv2"
Me.Crv2.SelectionFormula = ""
Me.Crv2.Size = New System.Drawing.Size(640, 352)
Me.Crv2.TabIndex = 1
Me.Crv2.ViewTimeSelectionFormula = ""
'
'TpErrors
'
Me.TpErrors.Controls.Add(Me.Crv3)
Me.TpErrors.Location = New System.Drawing.Point(4, 22)
Me.TpErrors.Name = "TpErrors"
Me.TpErrors.Size = New System.Drawing.Size(636, 350)
Me.TpErrors.TabIndex = 3
Me.TpErrors.Text = "Errors"
Me.TpErrors.UseVisualStyleBackColor = True
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
Me.TpReport.ResumeLayout(False)
Me.TpTotals.ResumeLayout(False)
Me.TpErrors.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myTXPROF = New TXPROF.mydata(MyDBConnect)

  WrkAltFormId = MyFrmTX302B.TxtAltFormID.Text
  GetTXFMSTMT(WrkAltFormId)
  If Trim(myTXFMSTMT._LINE1) = String.Empty Then
    GetTXFMSTMT(" ")
  End If

    Select Case WrkRptNo
      Case Is = 1, 5, 6, 7
        RunReport1()
      Case Is = 2
        RunReport2()
      Case Is = 3
        RunReport3()
      Case Is = 4
        RunReport4()
      Case Is = 8
        RunReport8()
      Case Is = 9
        RunReport9()
    End Select

    RunReportTot()
	If WrkdsErr.Tables(0).Rows.Count > 0 Then
		RunReportErr()
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
    myreport8.Close()
    myreport8.Dispose()
    myreportTot.Close()
  myreportTot.Dispose()
	myreportErr.Close()
	myreportErr.Dispose()
End Sub
  Private Sub RunReport1()
   Dim ReportPath As String

    Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTX3026.rpt", myTOWN._TOWNBR)
   With myreport1
    .Load(ReportPath)
    .SetDataSource(Wrkds)
    .SetParameterValue("myreportTitle", "Delinquent List")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("IntDate", Format(MyFrmTX302B.DtPckInt.Value, "short date"))
    .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTX302B.TxtFromGLYear.Text))
    .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTX302B.TxtToGLYear.Text))
    .SetParameterValue("MyTypes", MyTypes)
    If WrkRptNo = 1 Or WrkRptNo = 6 Or WrkRptNo = 7 Then
      .SetParameterValue("MyShowAddr", False)
    Else
      .SetParameterValue("MyShowAddr", True)
    End If
    .SetParameterValue("MyDouble", MyFrmTX302B.ChkDouble.Checked)
    If WrkRptNo = 6 Then
      .SetParameterValue("MyStatus", True)
    Else
      .SetParameterValue("MyStatus", False)
    End If
    If WrkRptNo = 7 Then
      .SetParameterValue("MyShowLoc", True)
    Else
      .SetParameterValue("MyShowLoc", False)
    End If
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
   Dim ReportName As String
   Dim ReportPath As String
   Dim WrkExists As Boolean

   Me.Text = "Report Viewer"
   ReportName = "PrtTX3023" & WrkAltFormId & ".rpt"
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
    .SetDataSource(Wrkds)
    .SetParameterValue("myreportTitle", "Delinquent Statement")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("AddlInt2", Format(MyFrmTX302B.DtPckInt.Value, "short date"))
    If Wrkds.Tables(0).Rows.Count > 0 Then
      With Wrkds.Tables(0).Rows(0)
        GetTXPROF(.Item("type"), .Item("year"), "", 0)
      End With
      .SetParameterValue("MyMinInt", myTXPROF._PRMINI)
    Else
      .SetParameterValue("MyMinInt", 0)
    End If
    .SetParameterValue("MyPayTo", Trim(myTXFMSTMT._PAYTO))
    .SetParameterValue("MyLine1", Trim(myTXFMSTMT._LINE1))
    .SetParameterValue("MyLine2", Trim(myTXFMSTMT._LINE2))
    .SetParameterValue("MyLine3", Trim(myTXFMSTMT._LINE3))
    .SetParameterValue("MyLine4", Trim(myTXFMSTMT._LINE4))
    .SetParameterValue("MyLine5", Trim(myTXFMSTMT._LINE5))
    .SetParameterValue("MyTitle", Trim(myTXFMSTMT._TITLE))
    .SetParameterValue("MyPageNos", MyFrmTX302B.ChkPageNos.Checked)
    .SetParameterValue("MyMsg", Trim(MyFrmTX302B.TxtMsg.Text))
   End With
   With Crv1
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
   Dim ReportName As String
   Dim ReportPath As String
   Dim WrkExists As Boolean

   Me.Text = "Report Viewer"
   ReportName = "PrtTX3024" & WrkAltFormId & ".rpt"
   ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
   If WrkAltFormId <> "" Then
     WrkExists = MyUtils.CheckFileExists(ReportPath)
     If Not WrkExists Then
       MsgBox("Close and retry with correct Form ID", MsgBoxStyle.Critical, "Cannot find report")
       Exit Sub
     End If
   End If

   With myreport3
    .Load(ReportPath)
    .SetDataSource(Wrkds)
    .SetParameterValue("myreportTitle", "Collector's Demand")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("IntDate", Format(MyFrmTX302B.DtPckInt.Value, "short date"))
    .SetParameterValue("CompDate", Format(MyFrmTX302B.DtPckCompliance.Value, "short date"))
    .SetParameterValue("MyLine1", Trim(myTXFMSTMT._LINE1))
    .SetParameterValue("MyLine2", Trim(myTXFMSTMT._LINE2))
    .SetParameterValue("MyLine3", Trim(myTXFMSTMT._LINE3))
    .SetParameterValue("MyLine4", Trim(myTXFMSTMT._LINE4))
    .SetParameterValue("MyLine5", Trim(myTXFMSTMT._LINE5))
    .SetParameterValue("MyTitle", Trim(myTXFMSTMT._TITLE))
    .SetParameterValue("MyPageNos", MyFrmTX302B.ChkPageNos.Checked)
    .SetParameterValue("MyMsg", Trim(MyFrmTX302B.TxtMsg.Text))
   End With
   With Crv1
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
   Dim ReportName As String
   Dim ReportPath As String
   Dim WrkExists As Boolean
   Dim WrkTownState As String

   Me.Text = "Report Viewer"
   WrkTownState = Trim(myTXFMSTMT._TWNAME) & ", " & myTXFMSTMT._STATE
   ReportName = "PrtTX3025" & WrkAltFormId & ".rpt"
   ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
   If WrkAltFormId <> "" Then
     WrkExists = MyUtils.CheckFileExists(ReportPath)
     If Not WrkExists Then
       MsgBox("Close and retry with correct Form ID", MsgBoxStyle.Critical, "Cannot find report")
       Exit Sub
     End If
   End If

   With myreport4
    .Load(ReportPath)
    .SetDataSource(Wrkds)
    .SetParameterValue("myreportTitle", "Property Alias Tax Warrant")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyTownCounty", Trim(myTOWN._COUNTY))
    .SetParameterValue("IntDate", Format(MyFrmTX302B.DtPckInt.Value, "short date"))
    .SetParameterValue("MyLine1", Trim(myTXFMSTMT._LINE1))
    .SetParameterValue("MyLine2", Trim(myTXFMSTMT._LINE2))
    .SetParameterValue("MyLine3", Trim(myTXFMSTMT._LINE3))
    .SetParameterValue("MyLine4", Trim(myTXFMSTMT._LINE4))
    .SetParameterValue("MyLine5", Trim(myTXFMSTMT._LINE5))
    .SetParameterValue("MyTitle", Trim(myTXFMSTMT._TITLE))
    .SetParameterValue("MyTownState", WrkTownState)
    .SetParameterValue("MySigned", Trim(myTXFMSTMT._SIGNED))
    .SetParameterValue("MyPageNos", MyFrmTX302B.ChkPageNos.Checked)
    .SetParameterValue("MyWarrantFee", MyWarrantFee)
    .SetParameterValue("MyMsg", Trim(MyFrmTX302B.TxtMsg.Text))
End With
   With Crv1
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
  Private Sub RunReportTot()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTX3026Tot.rpt", myTOWN._TOWNBR)
   With myreportTot
    .Load(ReportPath)
    .SetDataSource(Wrkds)
    .SetParameterValue("myreportTitle", "Delinquent Totals")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("IntDate", Format(MyFrmTX302B.DtPckInt.Value, "short date"))
    .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTX302B.TxtFromGLYear.Text))
    .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTX302B.TxtToGLYear.Text))
    .SetParameterValue("MyTypes", MyTypes)
   End With
   With Crv2
     .DisplayToolbar = True
     .ShowGroupTreeButton = False
     .ShowCloseButton = False
     .ShowCopyButton = False
     .ShowRefreshButton = False
     .ShowParameterPanelButton = False
     .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
     .ReportSource = myreportTot
     .Zoom(75)
  End With

  End Sub
  Private Sub RunReportErr()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTX302Err.rpt", myTOWN._TOWNBR)
    With myreportErr
      .Load(ReportPath)
      .SetDataSource(WrkdsErr)
      .SetParameterValue("myreportTitle", "Error List - Status Code not updated")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    End With
    With Crv3
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreportErr
      .Zoom(75)
    End With

  End Sub
  Private Sub RunReport8()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTX3028.rpt", myTOWN._TOWNBR)
    With myreport8
      .Load(ReportPath)
      .SetDataSource(Wrkds)
      .SetParameterValue("myreportTitle", "Balance Due")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("IntDate", Format(MyFrmTX302B.DtPckInt.Value, "short date"))
      .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTX302B.TxtFromGLYear.Text))
      .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTX302B.TxtToGLYear.Text))
      .SetParameterValue("MyTypes", MyTypes)

      .SetParameterValue("MyShowAddr", False)   ' did this since jsut 8  and mimic report 1

      .SetParameterValue("MyDouble", MyFrmTX302B.ChkDouble.Checked)

      .SetParameterValue("MyStatus", False)   ' did this since it just 8 and mimic 1

      .SetParameterValue("MyShowLoc", True)   'need location

    End With
    With Crv1
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreport8
      .Zoom(100)
    End With

  End Sub
  Private Sub RunReport9()
    Dim ReportName As String
    Dim ReportPath As String
    Dim WrkExists As Boolean

    Me.Text = "Report Viewer"
    ReportName = "PrtTX3029" & WrkAltFormId & ".rpt"
    ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
    If WrkAltFormId <> "" Then
      WrkExists = MyUtils.CheckFileExists(ReportPath)
      If Not WrkExists Then
        MsgBox("Close and retry with correct Form ID", MsgBoxStyle.Critical, "Cannot find report")
        Exit Sub
      End If
    End If

    With myreport9
      .Load(ReportPath)
      .SetDataSource(Wrkds)
      .SetParameterValue("myreportTitle", "Shut Off Notice")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("IntDate", Format(MyFrmTX302B.DtPckInt.Value, "short date"))
      .SetParameterValue("CompDate", Format(MyFrmTX302B.DtPckCompliance.Value, "short date"))
      .SetParameterValue("MyLine1", Trim(myTXFMSTMT._LINE1))
      .SetParameterValue("MyLine2", Trim(myTXFMSTMT._LINE2))
      .SetParameterValue("MyLine3", Trim(myTXFMSTMT._LINE3))
      .SetParameterValue("MyLine4", Trim(myTXFMSTMT._LINE4))
      .SetParameterValue("MyLine5", Trim(myTXFMSTMT._LINE5))
      .SetParameterValue("MyTitle", Trim(myTXFMSTMT._TITLE))
      .SetParameterValue("MyPageNos", MyFrmTX302B.ChkPageNos.Checked)
      .SetParameterValue("MyMsg", Trim(MyFrmTX302B.TxtMsg.Text))
      .SetParameterValue("MySigned", Trim(myTXFMSTMT._SIGNED))
      .SetParameterValue("RecDate", Format(MyFrmTX302B.DtPckRecBefore.Value, "short date"))
      .SetParameterValue("ShutOffDate", Format(MyFrmTX302B.DtPckShutOff.Value, "short date"))
      .SetParameterValue("MyTel", Trim(myTOWN._PHONE))


    End With
    With Crv1
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreport9
      .Zoom(100)
    End With
  End Sub
  Public Sub GetTXFMSTMT(ByVal WrkType As String)
	myTXFMSTMT = New TXFMSTMT.mydata(MyDBConnect)

	myTXFMSTMT.GetOneRecordP(WrkType)
End Sub

  Private Sub GetTXPROF(ByVal Type As String, ByVal Year As Integer, _
    ByVal Phase As String, ByVal District As Integer)

  myTXPROF.GetOneRecordP(Type, Year, Phase, District)
  End Sub
End Class






