Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport5 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend wrkds As DataSet = New DataSet
  Friend wrkds2 As DataSet = New DataSet
  Friend WrkUBType As String
  Friend WrkInterestRate As Decimal
  Friend WrkMinInterest As Decimal
  Friend WrkAddlBillDesc As String
  Friend WrkComment1 As String
  Friend WrkComment2 As String
  Friend WrkProfPerd As Integer
  Friend WrkPeriod As Integer
  Friend WrkPeriodDesc As String
  Friend WrkDueDate1 As String
  Friend WrkDueDate2 As String
  Friend WrkGraceDate1 As String
  Friend WrkGraceDate2 As String
  Friend WrkServiceFrom As String
  Friend WrkServiceTo As String
  Dim WrkBillType As String
  Friend WithEvents TpTotals As System.Windows.Forms.TabPage
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Dim WrkFamily As String

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
Friend WithEvents TabCtl1 As System.Windows.Forms.TabControl
Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents crv5 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents TpBills As System.Windows.Forms.TabPage
Friend WithEvents TpReport As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.TabCtl1 = New System.Windows.Forms.TabControl()
    Me.TpTotals = New System.Windows.Forms.TabPage()
    Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpReport = New System.Windows.Forms.TabPage()
    Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpBills = New System.Windows.Forms.TabPage()
    Me.crv5 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabCtl1.SuspendLayout()
    Me.TpTotals.SuspendLayout()
    Me.TpReport.SuspendLayout()
    Me.TpBills.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabCtl1
    '
    Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabCtl1.Controls.Add(Me.TpTotals)
    Me.TabCtl1.Controls.Add(Me.TpReport)
    Me.TabCtl1.Controls.Add(Me.TpBills)
    Me.TabCtl1.Location = New System.Drawing.Point(8, -2)
    Me.TabCtl1.Name = "TabCtl1"
    Me.TabCtl1.SelectedIndex = 0
    Me.TabCtl1.Size = New System.Drawing.Size(644, 376)
    Me.TabCtl1.TabIndex = 1
    '
    'TpTotals
    '
    Me.TpTotals.Controls.Add(Me.Crv1)
    Me.TpTotals.Location = New System.Drawing.Point(4, 22)
    Me.TpTotals.Name = "TpTotals"
    Me.TpTotals.Size = New System.Drawing.Size(636, 350)
    Me.TpTotals.TabIndex = 2
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
    Me.Crv1.Cursor = System.Windows.Forms.Cursors.Default
    Me.Crv1.DisplayStatusBar = False
    Me.Crv1.DisplayToolbar = False
    Me.Crv1.Location = New System.Drawing.Point(-2, -1)
    Me.Crv1.Name = "Crv1"
    Me.Crv1.SelectionFormula = ""
    Me.Crv1.Size = New System.Drawing.Size(640, 352)
    Me.Crv1.TabIndex = 3
    Me.Crv1.ViewTimeSelectionFormula = ""
    '
    'TpReport
    '
    Me.TpReport.Controls.Add(Me.Crv2)
    Me.TpReport.Location = New System.Drawing.Point(4, 22)
    Me.TpReport.Name = "TpReport"
    Me.TpReport.Size = New System.Drawing.Size(636, 350)
    Me.TpReport.TabIndex = 0
    Me.TpReport.Text = "Report"
    Me.TpReport.UseVisualStyleBackColor = True
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
    'TpBills
    '
    Me.TpBills.Controls.Add(Me.crv5)
    Me.TpBills.Location = New System.Drawing.Point(4, 22)
    Me.TpBills.Name = "TpBills"
    Me.TpBills.Size = New System.Drawing.Size(636, 350)
    Me.TpBills.TabIndex = 1
    Me.TpBills.Text = "Bills"
    Me.TpBills.UseVisualStyleBackColor = True
    '
    'crv5
    '
    Me.crv5.ActiveViewIndex = -1
    Me.crv5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.crv5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.crv5.DisplayStatusBar = False
    Me.crv5.DisplayToolbar = False
    Me.crv5.Location = New System.Drawing.Point(-2, -1)
    Me.crv5.Name = "crv5"
    Me.crv5.SelectionFormula = ""
    Me.crv5.Size = New System.Drawing.Size(640, 352)
    Me.crv5.TabIndex = 2
    Me.crv5.ViewTimeSelectionFormula = ""
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
    Me.TpTotals.ResumeLayout(False)
    Me.TpReport.ResumeLayout(False)
    Me.TpBills.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    WrkBillType = GetUTTypeDesc(WrkUBType)
    WrkFamily = GetUTTYPEFamily(WrkUBType)
    GetUTFMBILL(WrkUBType)
    If Trim(myUTFMBILL._LINE1) = String.Empty Then
      GetUTFMBILL("")
    End If

    If MyFrmUB410B.ChkReport.Checked Then
      RunReport()
      RunReportTot()
      '      TabCtl1.TabPages.Remove(TpReport)
      '     TabCtl1.TabPages.Remove(TpTotals)
    End If

    If MyFrmUB410B.ChkBills.Checked Then
      Select Case WrkFamily
        Case "M"
          RunReportMT()
        Case "U"
          RunReportUS()
      End Select
    Else
      TabCtl1.TabPages.Remove(TpBills)
    End If
 End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport.Close()
  myreport.Dispose()
  myreport2.Close()
  myreport2.Dispose()
    myreport5.Close()
    myreport5.Dispose()
End Sub
  Private Sub RunReportTot()
   Dim ReportPath As String
   Dim ReportTitle As String

   ReportTitle = "Billing Report Totals"
   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtUB410Tot.rpt", myTOWN._TOWNBR)
    With myreport
    .Load(ReportPath)
    .SetDataSource(wrkds)
    .SetParameterValue("myreportTitle", ReportTitle)
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyInterestDate", MyFrmUB410B.DtPckInterest.Value)
    .SetParameterValue("MyFamily", WrkFamily)
    .SetParameterValue("MyDistrict", MyUtils.CnvSng(MyFrmUB410B.TxtDist.Text))
    .SetParameterValue("MyPhase", MyUtils.CnvSng(MyFrmUB410B.TxtPhase.Text))
    If MyFrmUB410B.ChkUpdate.Checked Then
      .SetParameterValue("MyPost", True)
    Else
      .SetParameterValue("MyPost", False)
    End If
    .SetParameterValue("MyPeriodDesc", WrkPeriodDesc)
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
  Private Sub RunReport()
   Dim ReportPath As String
   Dim ReportTitle As String

   ReportTitle = "Billing Report"
   If MyFrmUB410B.RbSortList.Checked Then
    ReportTitle = ReportTitle & " by List No"
   End If
   If MyFrmUB410B.RbSortName.Checked Then
    ReportTitle = ReportTitle & " by Name"
   End If
   If MyFrmUB410B.RbSortLocation.Checked Then
    ReportTitle = ReportTitle & " by Location"
   End If

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtUB410.rpt", myTOWN._TOWNBR)
    With myreport2
    .Load(ReportPath)
    .SetDataSource(wrkds)
    .SetParameterValue("myreportTitle", ReportTitle)
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyInterestDate", MyFrmUB410B.DtPckInterest.Value)
    .SetParameterValue("MyAddress", MyFrmUB410B.ChkAddress.Checked)
    .SetParameterValue("MyFamily", WrkFamily)
    .SetParameterValue("MyDistrict", MyUtils.CnvSng(MyFrmUB410B.TxtDist.Text))
    .SetParameterValue("MyPhase", MyUtils.CnvSng(MyFrmUB410B.TxtPhase.Text))
    If MyFrmUB410B.ChkUpdate.Checked Then
      .SetParameterValue("MyPost", True)
    Else
      .SetParameterValue("MyPost", False)
    End If
    .SetParameterValue("MyPeriodDesc", WrkPeriodDesc)
   End With
   With Crv2
     .DisplayToolbar = True
     .ShowGroupTreeButton = False
     .ShowCloseButton = False
     .ShowCopyButton = False
     .ShowRefreshButton = False
     .ShowParameterPanelButton = False
     .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
     .ReportSource = myreport2
      .Zoom(100)
    End With
  End Sub
  Private Sub RunReportMT()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    If myTOWN._TOWNBR = 219 And WrkPeriod = 0 Then
      ReportPath = MyUtils.GetReportPath("PrtUB410MT-FL.rpt", myTOWN._TOWNBR)
    Else
      ReportPath = MyUtils.GetReportPath("PrtUB410MT.rpt", myTOWN._TOWNBR)
    End If
    With myreport5
      .Load(ReportPath)
      .SetDataSource(wrkds2)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyInterestRate", WrkInterestRate)
      .SetParameterValue("MyMinInterest", WrkMinInterest)
      .SetParameterValue("MyDueDate1", WrkDueDate1)
      .SetParameterValue("MyDueDate2", WrkDueDate2)
      .SetParameterValue("MyGraceDate1", WrkGraceDate1)
      .SetParameterValue("MyGraceDate2", WrkGraceDate2)
      .SetParameterValue("MyAddlBillDesc", WrkAddlBillDesc)
      .SetParameterValue("MyComment1", WrkComment1)
      .SetParameterValue("MyComment2", WrkComment2)
      .SetParameterValue("MyServiceFrom", WrkServiceFrom)
      .SetParameterValue("MyServiceTo", WrkServiceTo)
      .SetParameterValue("MyPayTo", Trim(myUTFMBILL._PAYTO))
      .SetParameterValue("MyLine1", Trim(myUTFMBILL._LINE1))
      .SetParameterValue("MyLine2", Trim(myUTFMBILL._LINE2))
      .SetParameterValue("MyLine3", Trim(myUTFMBILL._LINE3))
      .SetParameterValue("MyLine4", Trim(myUTFMBILL._LINE4))
      .SetParameterValue("MyLine5", Trim(myUTFMBILL._LINE5))
      .SetParameterValue("MyOfficeHours1", "Office Hours: " & Trim(myUTFMBILL._HOURS1))
      .SetParameterValue("MyOfficeHours2", Trim(myUTFMBILL._HOURS2))
      .SetParameterValue("MyPhone", Trim(myUTFMBILL._PHONE))
    End With
    With crv5
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreport5
      .Zoom(75)
    End With

  End Sub
  Private Sub RunReportUS()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtUB410US.rpt", myTOWN._TOWNBR)
   With myreport5
    .Load(ReportPath)
    .SetDataSource(wrkds2)
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyInterestRate", WrkInterestRate)
    .SetParameterValue("MyMinInterest", WrkMinInterest)
    .SetParameterValue("MyDueDate1", WrkDueDate1)
    .SetParameterValue("MyDueDate2", WrkDueDate2)
    .SetParameterValue("MyGraceDate1", WrkGraceDate1)
    .SetParameterValue("MyGraceDate2", WrkGraceDate2)
    .SetParameterValue("MyComment1", WrkComment1)
    .SetParameterValue("MyComment2", WrkComment2)
    .SetParameterValue("MyPayTo", Trim(myUTFMBILL._PAYTO))
    .SetParameterValue("MyLine1", Trim(myUTFMBILL._LINE1))
    .SetParameterValue("MyLine2", Trim(myUTFMBILL._LINE2))
    .SetParameterValue("MyLine3", Trim(myUTFMBILL._LINE3))
    .SetParameterValue("MyLine4", Trim(myUTFMBILL._LINE4))
    .SetParameterValue("MyLine5", Trim(myUTFMBILL._LINE5))
    .SetParameterValue("MyOfficeHours1", "Office Hours: " & Trim(myUTFMBILL._HOURS1))
    .SetParameterValue("MyOfficeHours2", Trim(myUTFMBILL._HOURS2))
    .SetParameterValue("MyPhone", Trim(myUTFMBILL._PHONE))
   End With
   With crv5
     .DisplayToolbar = True
     .ShowGroupTreeButton = False
     .ShowCloseButton = False
     .ShowCopyButton = False
     .ShowRefreshButton = False
     .ShowParameterPanelButton = False
     .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
     .ReportSource = myreport5
     .Zoom(75)
   End With
  End Sub
End Class






