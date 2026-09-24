Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
	Dim myTXPROF As TXPROF.myData
	Friend Wrkds As DataSet
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
	RunReport()
End Sub
Public Sub RunReport()
	GetTXFMSTMT(MyAltFormID)
	If Trim(myTXFMSTMT._LINE1) = String.Empty Then
		GetTXFMSTMT(" ")
	End If

	Select Case MyReportName
		Case "Statement", String.Empty
			RunReport1()
		Case "Demand"
			RunReport2()
		Case "Warrant"
			RunReport3()
		Case "Lien"
			RunReport4()
		Case "Intent"
			RunReport5()
		Case "Letter"
			RunReport6()
		End Select
End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
	myreport1.Close()
	myreport1.Dispose()
End Sub
  Private Sub RunReport1()
	 'Delinquent Statement	
	 Dim ReportName As String
   Dim ReportPath As String
   Dim WrkExists As Boolean

   Me.Text = "Report Viewer"

	 ReportName = "PrtTX3023" & MyAltFormID & ".rpt"
   ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
	 If MyAltFormID <> "" Then
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
		.SetParameterValue("AddlInt2", Format(MyFrmTX4042.DtPckComp.Value, "short date"))
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
    .SetParameterValue("MyPageNos", False)
		.SetParameterValue("MyMsg", Trim(MyReportText))
		If Not MyPreview Then
			.PrintOptions.PrinterName = MyPrinter
			.PrintToPrinter(1, False, 0, 0)
			.Close()
			.Dispose()
			Exit Sub
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
	 'Demand Notice
	 Dim ReportName As String
   Dim ReportPath As String
   Dim WrkExists As Boolean

   Me.Text = "Report Viewer"
	 ReportName = "PrtTX3024" & MyAltFormID & ".rpt"
   ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
	 If MyAltFormID <> "" Then
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
		.SetParameterValue("IntDate", Format(MyFrmTX4042.DtPckInt.Value, "short date"))
    .SetParameterValue("CompDate", Format(MyFrmTX4042.DtPckComp.Value, "short date"))
    .SetParameterValue("MyLine1", Trim(myTXFMSTMT._LINE1))
    .SetParameterValue("MyLine2", Trim(myTXFMSTMT._LINE2))
    .SetParameterValue("MyLine3", Trim(myTXFMSTMT._LINE3))
    .SetParameterValue("MyLine4", Trim(myTXFMSTMT._LINE4))
    .SetParameterValue("MyLine5", Trim(myTXFMSTMT._LINE5))
    .SetParameterValue("MyTitle", Trim(myTXFMSTMT._TITLE))
    .SetParameterValue("MyPageNos", False)
    .SetParameterValue("MyMsg", Trim(MyReportText))
    If Not MyPreview Then
      .PrintOptions.PrinterName = MyPrinter
      .PrintToPrinter(1, False, 0, 0)
      .Close()
      .Dispose()
      Exit Sub
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
  Private Sub RunReport3()
	'Warrant
	 Dim ReportName As String
   Dim ReportPath As String
   Dim WrkExists As Boolean
   Dim WrkTownState As String

   Me.Text = "Report Viewer"
   WrkTownState = Trim(myTXFMSTMT._TWNAME) & ", " & myTXFMSTMT._STATE

	 ReportName = "PrtTX3025" & MyAltFormID & ".rpt"
   ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
	 If MyAltFormID <> "" Then
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
		.SetParameterValue("IntDate", Format(MyFrmTX4042.DtPckInt.Value, "short date"))
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
    .SetParameterValue("MyMsg", Trim(MyReportText))
    If Not MyPreview Then
      .PrintOptions.PrinterName = MyPrinter
      .PrintToPrinter(1, False, 0, 0)
      .Close()
      .Dispose()
      Exit Sub
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
  Private Sub RunReport4()
	 'Lien for Town Clerk	
	 Dim ReportName As String
   Dim ReportPath As String
   Dim WrkExists As Boolean
   Dim WrkFamily As String
   Dim WrkShowVol As Boolean
   Dim WrkTownState As String
	 Dim WrkTXType As String()

	 WrkTXType = LookupType(Wrkds.Tables(0).Rows(0).Item("type"))
	 WrkFamily = WrkTXType(1)
   WrkShowVol = False
   Select Case WrkFamily
   Case "R"
     WrkShowVol = True
   End Select

   Me.Text = "Report Viewer"
   WrkTownState = Trim(myTXFMSTMT._TWNAME) & ", " & myTXFMSTMT._STATE
	 ReportName = "PrtTX3044" & MyAltFormID & ".rpt"
   ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
	 If MyAltFormID <> "" Then
     WrkExists = MyUtils.CheckFileExists(ReportPath)
		 If Not WrkExists Then
			 MsgBox("Close and retry with correct Form ID", MsgBoxStyle.Critical, "Cannot find report")
			 Exit Sub
		 End If
	 End If
   With myreport1
    .Load(ReportPath)
    .SetDataSource(Wrkds)
    .SetParameterValue("myreportTitle", "Certificate of Continuing Tax Lien")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyTownCounty", Trim(myTOWN._COUNTY))
		If Wrkds.Tables(0).Rows.Count > 0 Then
			With Wrkds.Tables(0).Rows(0)
				GetTXPROF(.Item("type"), .Item("year"), "", 0)
			End With
      .SetParameterValue("MyDueDate1", Format(MyUtils.GetDBDateMDY(myTXPROF._PRDUE1)))
      .SetParameterValue("MyDueDate2", Format(MyUtils.GetDBDateMDY(myTXPROF._PRDUE2)))
			.SetParameterValue("MyShowVol", WrkShowVol)
		Else
			.SetParameterValue("MyDueDate1", "1/1/1900")
			.SetParameterValue("MyDueDate2", "1/1/1900")
			.SetParameterValue("MyShowVol", WrkShowVol)
		End If
    .SetParameterValue("MyTownState", WrkTownState)
    .SetParameterValue("MySigned", Trim(myTXFMSTMT._SIGNED))
		.SetParameterValue("MyLienDate", Format(MyFrmTX4042.DtPckComp.Value, "short date"))
		If Not MyPreview Then
			.PrintOptions.PrinterName = MyPrinter
			.PrintToPrinter(1, False, 0, 0)
			.Close()
			.Dispose()
			Exit Sub
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
  Private Sub RunReport5()
	 'Intent to Lien	
	 Dim ReportName As String
   Dim ReportPath As String
   Dim WrkExists As Boolean

   Me.Text = "Report Viewer"
	 ReportName = "PrtTX3043" & MyAltFormID & ".rpt"
   ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
	 If MyAltFormID <> "" Then
     WrkExists = MyUtils.CheckFileExists(ReportPath)
		 If Not WrkExists Then
			 MsgBox("Close and retry with correct Form ID", MsgBoxStyle.Critical, "Cannot find report")
			 Exit Sub
		 End If
	 End If
   With myreport1
    .Load(ReportPath)
    .SetDataSource(Wrkds)
    .SetParameterValue("myreportTitle", "Notice of Lien")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		If Wrkds.Tables(0).Rows.Count > 0 Then
			With Wrkds.Tables(0).Rows(0)
				GetTXPROF(.Item("type"), .Item("year"), "", 0)
			End With
			.SetParameterValue("MyLienFee", myTXPROF._PRLIEN)
		Else
			.SetParameterValue("MyLienFee", 0)
		End If
    .SetParameterValue("MyIntDate", Format(MyFrmTX4042.DtPckInt.Value, "short date"))
    .SetParameterValue("MyPayTo", Trim(myTXFMSTMT._PAYTO))
    .SetParameterValue("MyLine1", Trim(myTXFMSTMT._LINE1))
    .SetParameterValue("MyLine2", Trim(myTXFMSTMT._LINE2))
    .SetParameterValue("MyLine3", Trim(myTXFMSTMT._LINE3))
    .SetParameterValue("MyLine4", Trim(myTXFMSTMT._LINE4))
    .SetParameterValue("MyLine5", Trim(myTXFMSTMT._LINE5))
    .SetParameterValue("MyTitle", Trim(myTXFMSTMT._TITLE))
    .SetParameterValue("MyLienDate", Format(MyFrmTX4042.DtPckComp.Value, "short date"))
    .SetParameterValue("MyMsg", Trim(MyReportText))
    If Not MyPreview Then
      .PrintOptions.PrinterName = MyPrinter
      .PrintToPrinter(1, False, 0, 0)
      .Close()
      .Dispose()
      Exit Sub
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
  Private Sub RunReport6()
	 'Letter
	 Dim ReportName As String
   Dim ReportPath As String
   Dim WrkExists As Boolean

   Me.Text = "Report Viewer"
	 ReportName = "PrtTX4048" & MyAltFormID & ".rpt"
   ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
	 If MyAltFormID <> "" Then
     WrkExists = MyUtils.CheckFileExists(ReportPath)
		 If Not WrkExists Then
			 MsgBox("Close and retry with correct Form ID", MsgBoxStyle.Critical, "Cannot find report")
			 Exit Sub
		 End If
	 End If
   With myreport1
    .Load(ReportPath)
    .SetDataSource(Wrkds)
		.SetParameterValue("myreportTitle", MyReportTitle)
		.SetParameterValue("myreportText", MyReportText)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("IntDate", Format(MyFrmTX4042.DtPckInt.Value, "short date"))
    .SetParameterValue("MyPayTo", Trim(myTXFMSTMT._PAYTO))
    .SetParameterValue("MyLine1", Trim(myTXFMSTMT._LINE1))
    .SetParameterValue("MyLine2", Trim(myTXFMSTMT._LINE2))
    .SetParameterValue("MyLine3", Trim(myTXFMSTMT._LINE3))
    .SetParameterValue("MyLine4", Trim(myTXFMSTMT._LINE4))
    .SetParameterValue("MyLine5", Trim(myTXFMSTMT._LINE5))
    .SetParameterValue("MyTitle", Trim(myTXFMSTMT._TITLE))
		If Not MyPreview Then
			.PrintOptions.PrinterName = MyPrinter
			.PrintToPrinter(1, False, 0, 0)
			.Close()
			.Dispose()
			Exit Sub
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

Private Sub FrmCrViewer_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  'Memory Cleanup
  myreport1 = Nothing
	MyCrViewer = Nothing
	myTXFMSTMT = Nothing
	myTXPROF = Nothing
End Sub
  Private Sub GetTXPROF(ByVal Type As String, ByVal Year As Integer, _
    ByVal Phase As String, ByVal District As Integer)

	myTXPROF = New TXPROF.mydata(MyDBConnect)
	myTXPROF.GetOneRecordP(Type, Year, Phase, District)

  End Sub
Public Sub GetTXFMSTMT(ByVal WrkType As String)
  myTXFMSTMT = New TXFMSTMT.mydata(MyDBConnect)

  myTXFMSTMT.GetOneRecordP(WrkType)
End Sub

End Class










