Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend wrkds As DataSet = New DataSet
  Friend WrkUBType As String
  Friend WrkDueDate As Date
  Friend WrkDueDate2 As Date
  Friend WrkNoYears As Integer
  Friend WrkRptFmt As String
  Friend WrkLienFee As Decimal
  Dim WrkBillType As String
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
Me.Crv1.Location = New System.Drawing.Point(0, 0)
Me.Crv1.Name = "Crv1"
Me.Crv1.ReportSource = Nothing
Me.Crv1.Size = New System.Drawing.Size(668, 388)
Me.Crv1.TabIndex = 2
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
    myTXFMSTMT = New TXFMSTMT.mydata(MyDBConnect)

    WrkBillType = GetUTTypeDesc(WrkUBType)
    myTXFMSTMT.GetOneRecordP(WrkUBType)
    If myTXFMSTMT.RecordNotFound Then
      myTXFMSTMT.GetOneRecordP("")
    End If
    Select Case WrkRptFmt
    Case "Edit"
      RunReport()
    Case "Notice"
      RunReportC()
    Case "Clerk"
      RunReportD()
    Case "Blanket"
      RunReportB()
    End Select
 End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport.Close()
  myreport.Dispose()
End Sub
  Private Sub RunReport()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtUB211.rpt", myTOWN._TOWNBR)

   With myreport
    .Load(ReportPath)
    .SetDataSource(wrkds)
    .SetParameterValue("MyReportTitle", "Lien Edit")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyLienDate", Format(MyFrmUB211B.DtPckLien.Value, "M/d/yyyy"))
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
  Private Sub RunReportB()
   Dim ReportPath As String
   Dim WrkDueDates As String
   Dim WrkTownState As String
   Dim WrkDate As Date

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtUB211B.rpt", myTOWN._TOWNBR)
   WrkTownState = Trim(myTXFMSTMT._TWNAME) & ", " & myTXFMSTMT._STATE
   WrkDueDates = WrkDueDate
   If WrkDueDate2 <> WrkDate Then
    WrkDueDates = WrkDueDates & " & " & WrkDueDate2
   End If

   With myreport
    .Load(ReportPath)
    .SetDataSource(wrkds)
    .SetParameterValue("MyReportTitle", "Blanket Lien")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyTownCounty", Trim(myTOWN._COUNTY))
    .SetParameterValue("MyGLYear", MyFrmUB211B.TxtYear.Text)
    .SetParameterValue("MyLienDate", Format(MyFrmUB211B.DtPckLien.Value, "M/d/yyyy"))
    .SetParameterValue("MyDueDates", WrkDueDates)
    .SetParameterValue("MyTownState", WrkTownState)
    .SetParameterValue("MyTitle", Trim(myTXFMSTMT._TITLE))
    .SetParameterValue("MyClerk", Trim(myTXFMSTMT._CLERK))
    .SetParameterValue("MySigned", Trim(myTXFMSTMT._SIGNED))
    .SetParameterValue("MyDueDate1", WrkDueDate)
    .SetParameterValue("MyDueDate2", WrkDueDate2)
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
  Private Sub RunReportC()
   Dim ReportPath As String
   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtUB211C.rpt", myTOWN._TOWNBR)

   With myreport
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
    .SetParameterValue("MyIntDate", Format(MyFrmUB211B.DtPckLien.Value, "M/d/yyyy"))
    .SetParameterValue("MyPayTo", Trim(myTXFMSTMT._PAYTO))
    .SetParameterValue("MyLine1", Trim(myTXFMSTMT._LINE1))
    .SetParameterValue("MyLine2", Trim(myTXFMSTMT._LINE2))
    .SetParameterValue("MyLine3", Trim(myTXFMSTMT._LINE3))
    .SetParameterValue("MyLine4", Trim(myTXFMSTMT._LINE4))
    .SetParameterValue("MyLine5", Trim(myTXFMSTMT._LINE5))
    .SetParameterValue("MyTitle", Trim(myTXFMSTMT._TITLE))
    .SetParameterValue("MyLienDate", Format(MyFrmUB211B.DtPckLien.Value, "M/d/yyyy"))
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
  Private Sub RunReportD()
   Dim ReportPath As String
   Dim ReportTitle As String
   Dim WrkUntilDate As Date

   WrkUntilDate = DateAdd(DateInterval.Year, WrkNoYears, WrkDueDate)
   WrkUntilDate = DateAdd(DateInterval.Month, 1, WrkUntilDate)
   WrkUntilDate = DateAdd(DateInterval.Day, -1, WrkUntilDate)
   ReportTitle = "Assessment Benefit Liens"
   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtUB211D.rpt", myTOWN._TOWNBR)
    With myreport
    .Load(ReportPath)
    .SetDataSource(wrkds)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyTownCounty", Trim(myTOWN._COUNTY))
    .SetParameterValue("MyLienDate", MyUtils.StripTime(MyFrmUB211B.DtPckLien.Value))
    .SetParameterValue("MyDueDate", WrkDueDate)
    .SetParameterValue("MyUntilDate", WrkUntilDate)
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






