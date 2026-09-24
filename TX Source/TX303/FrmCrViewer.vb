Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend wrkds As DataSet = New DataSet
  Friend wrkds2 As DataSet = New DataSet
  Friend WrkType As String
  Friend WrkInterestDate As Date
  Dim WrkBillType As String
  Dim WrkFamily As String
  Dim myTXFMSTMT As TXFMSTMT.myData
  Dim myTXFMBILL As TXFMBILL.myData

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
Friend WithEvents TpBills As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.TabControl1 = New System.Windows.Forms.TabControl
Me.TpTotals = New System.Windows.Forms.TabPage
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpBills = New System.Windows.Forms.TabPage
Me.crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabControl1.SuspendLayout()
Me.TpTotals.SuspendLayout()
Me.TpBills.SuspendLayout()
Me.SuspendLayout()
'
'TabControl1
'
Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabControl1.Controls.Add(Me.TpTotals)
Me.TabControl1.Controls.Add(Me.TpBills)
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
Me.Crv1.Size = New System.Drawing.Size(640, 352)
Me.Crv1.TabIndex = 1
'
'TpBills
'
Me.TpBills.Controls.Add(Me.crv2)
Me.TpBills.Location = New System.Drawing.Point(4, 22)
Me.TpBills.Name = "TpBills"
Me.TpBills.Size = New System.Drawing.Size(636, 350)
Me.TpBills.TabIndex = 1
Me.TpBills.Text = "Bills"
'
'crv2
'
Me.crv2.ActiveViewIndex = -1
Me.crv2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.crv2.DisplayToolbar = False
Me.crv2.Location = New System.Drawing.Point(-2, -1)
Me.crv2.Name = "crv2"
Me.crv2.ReportSource = Nothing
Me.crv2.Size = New System.Drawing.Size(640, 352)
Me.crv2.TabIndex = 2
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
Me.TpBills.ResumeLayout(False)
Me.ResumeLayout(False)

    End Sub

#End Region

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    WrkBillType = GetTXTypeDesc(WrkType)
    WrkFamily = GetTXTypeFamily(WrkType)

    RunReportTotals()
    If wrkds2.Tables(0).Rows.Count > 0 Then
      RunReportBills()
    Else
      TabControl1.TabPages.Remove(TpBills)
    End If
 End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport.Close()
  myreport.Dispose()
  myreport2.Close()
  myreport2.Dispose()
End Sub
  Private Sub RunReportTotals()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTX303Tot.rpt", myTOWN._TOWNBR)
   With myreport
    .Load(ReportPath)
    .SetDataSource(wrkds)
    .SetParameterValue("myreportTitle", WrkBillType & " Bill Totals")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyInterestDate", WrkInterestDate)
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
  Private Sub RunReportBills()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   Dim WrkType As String

   'Check for Lien Release for Tax Type
   WrkType = wrkds2.Tables(0).Rows(0).Item("type")
   GetTXFMSTMT(WrkType)
   If Trim(myTXFMSTMT._LINE1) = String.Empty Then
     GetTXFMSTMT(" ")
   End If
   GetTXFMBILL(WrkType)
   If Trim(myTXFMBILL._LINE1) = String.Empty Then
     GetTXFMBILL(" ")
   End If
   Select Case WrkFamily
   Case "M", "S"
     ReportPath = MyUtils.GetReportPath("PrtTX303MV.rpt", myTOWN._TOWNBR)
   Case "A"
     ReportPath = MyUtils.GetReportPath("PrtTX303AS.rpt", myTOWN._TOWNBR)
   Case Else
     ReportPath = MyUtils.GetReportPath("PrtTX303.rpt", myTOWN._TOWNBR)
   End Select

   With myreport2
    .Load(ReportPath)
    .SetDataSource(wrkds2)
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyInterestDate", WrkInterestDate)
    .SetParameterValue("MyPayTo", Trim(myTXFMSTMT._PAYTO))
    .SetParameterValue("MyLine1", Trim(myTXFMSTMT._LINE1))
    .SetParameterValue("MyLine2", Trim(myTXFMSTMT._LINE2))
    .SetParameterValue("MyLine3", Trim(myTXFMSTMT._LINE3))
    .SetParameterValue("MyLine4", Trim(myTXFMSTMT._LINE4))
    .SetParameterValue("MyLine5", Trim(myTXFMSTMT._LINE5))
    .SetParameterValue("MyHours", Trim(myTXFMBILL._HOURS1) & " " & Trim(myTXFMBILL._HOURS2))
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
Public Sub GetTXFMBILL(ByVal WrkType As String)
  myTXFMBILL = New TXFMBILL.mydata(MyDBConnect)

  myTXFMBILL.GetOneRecordP(WrkType)
End Sub
End Class






