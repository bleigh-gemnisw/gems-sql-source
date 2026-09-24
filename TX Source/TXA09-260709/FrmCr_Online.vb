Public Class FrmCr_Online
  Inherits System.Windows.Forms.Form

  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myTXFMSTMT As TXFMSTMT.myData
	Dim myTXPROF As TXPROF.myData
	Friend Wrkds As DataSet
  Friend WrkRptNo As Integer
  Dim WrkAltFormID As String

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
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
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
Me.Crv1.Location = New System.Drawing.Point(8, 8)
Me.Crv1.Name = "Crv1"
Me.Crv1.ReportSource = Nothing
Me.Crv1.Size = New System.Drawing.Size(652, 376)
Me.Crv1.TabIndex = 0
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

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  WrkAltFormId = MyFrmTXA094B.TxtAltFormID.Text
  GetTXFMSTMT(WrkAltFormId)
  If Trim(myTXFMSTMT._LINE1) = String.Empty Then
    GetTXFMSTMT(" ")
  End If

  Select Case WrkRptNo
  Case Is = 1
    RunReport1()
  Case Is = 2
    RunReport2()
  Case Is = 3
    RunReport3()
  End Select
End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
	myTXFMSTMT.CloseFile()
	myreport1.Close()
  myreport1.Dispose()
End Sub
  Private Sub GetTXPROF(ByVal Type As String, ByVal Year As Integer, _
    ByVal Phase As String, ByVal District As Integer)

	myTXPROF = New TXPROF.mydata(MyDBConnect)
	myTXPROF.GetOneRecordP(Type, Year, Phase, District)

  End Sub
  Private Sub RunReport1()
   Dim ReportName As String
   Dim ReportPath As String
   Dim WrkExists As Boolean

   Me.Text = "Report Viewer"
   ReportName = "PrtTX3023" & WrkAltFormID & ".rpt"
   ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
   If WrkAltFormID <> "" Then
     WrkExists = MyUtils.CheckFileExists(ReportPath)
     If Not WrkExists Then
       MsgBox("Close and retry with correct Form ID", MsgBoxStyle.Critical, "Cannot find report")
       Exit Sub
     End If
   End If

   With myreport1
    .Load(ReportPath)
    .SetDataSource(Wrkds)
    .SetParameterValue("myreportTitle", "Delinquent Statement")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("AddlInt2", Format(MyFrmTXA094B.DtPckComp.Value, "short date"))
    If Wrkds.Tables(0).Rows.Count > 0 Then
      With Wrkds.Tables(0).Rows(0)
        GetTXPROF(.Item("type"), .Item("year"), "", 0)
      End With
      .SetParameterValue("MyMinInt", myTXPROF._PRMINI)
      myTXPROF.CloseFile()
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
    .SetParameterValue("MyPageNos", False)
    .SetParameterValue("MyMsg", Trim(MyFrmTXA094B.TxtMsg.Text))
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
   ReportName = "PrtTX3024" & WrkAltFormID & ".rpt"
   ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
   If WrkAltFormID <> "" Then
     WrkExists = MyUtils.CheckFileExists(ReportPath)
     If Not WrkExists Then
       MsgBox("Close and retry with correct Form ID", MsgBoxStyle.Critical, "Cannot find report")
       Exit Sub
     End If
   End If

   With myreport1
    .Load(ReportPath)
    .SetDataSource(Wrkds)
    .SetParameterValue("myreportTitle", "Collector's Demand")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("IntDate", Format(MyFrmTXA094B.DtPckInt.Value, "short date"))
    .SetParameterValue("CompDate", Format(MyFrmTXA094B.DtPckComp.Value, "short date"))
    .SetParameterValue("MyLine1", Trim(myTXFMSTMT._LINE1))
    .SetParameterValue("MyLine2", Trim(myTXFMSTMT._LINE2))
    .SetParameterValue("MyLine3", Trim(myTXFMSTMT._LINE3))
    .SetParameterValue("MyLine4", Trim(myTXFMSTMT._LINE4))
    .SetParameterValue("MyLine5", Trim(myTXFMSTMT._LINE5))
    .SetParameterValue("MyTitle", Trim(myTXFMSTMT._TITLE))
    .SetParameterValue("MyPageNos", False)
    .SetParameterValue("MyMsg", Trim(MyFrmTXA094B.TxtMsg.Text))
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
   Dim ReportName As String
   Dim ReportPath As String
   Dim WrkExists As Boolean
   Dim WrkTownState As String

   Me.Text = "Report Viewer"
   WrkTownState = Trim(myTXFMSTMT._TWNAME) & ", " & myTXFMSTMT._STATE
   ReportName = "PrtTX3025" & WrkAltFormID & ".rpt"
   ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
   If WrkAltFormID <> "" Then
     WrkExists = MyUtils.CheckFileExists(ReportPath)
     If Not WrkExists Then
       MsgBox("Close and retry with correct Form ID", MsgBoxStyle.Critical, "Cannot find report")
       Exit Sub
     End If
   End If

   With myreport1
    .Load(ReportPath)
    .SetDataSource(Wrkds)
    .SetParameterValue("myreportTitle", "Property Alias Tax Warrant")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyTownCounty", Trim(myTOWN._COUNTY))
    .SetParameterValue("IntDate", Format(MyFrmTXA094B.DtPckInt.Value, "short date"))
    .SetParameterValue("MyLine1", Trim(myTXFMSTMT._LINE1))
    .SetParameterValue("MyLine2", Trim(myTXFMSTMT._LINE2))
    .SetParameterValue("MyLine3", Trim(myTXFMSTMT._LINE3))
    .SetParameterValue("MyLine4", Trim(myTXFMSTMT._LINE4))
    .SetParameterValue("MyLine5", Trim(myTXFMSTMT._LINE5))
    .SetParameterValue("MyTitle", Trim(myTXFMSTMT._TITLE))
    .SetParameterValue("MyTownState", WrkTownState)
    .SetParameterValue("MySigned", Trim(myTXFMSTMT._SIGNED))
    .SetParameterValue("MyPageNos", False)
    .SetParameterValue("MyWarrantFee", MyWarrantFee)
    .SetParameterValue("MyMsg", Trim(MyFrmTXA094B.TxtMsg.Text))
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
Private Sub FrmCr_Online_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  'Memory Cleanup
  myreport1 = Nothing
  MyFrmCr_Online = Nothing
End Sub
Public Sub GetTXFMSTMT(ByVal WrkType As String)
  myTXFMSTMT = New TXFMSTMT.mydata(MyDBConnect)

  myTXFMSTMT.GetOneRecordP(WrkType)
End Sub

End Class






