Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend wrkds As DataSet = New DataSet
  Friend WrkUBType As String
  Dim WrkBillType As String
  Dim WrkFamily As String
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Dim myUTFMBILL As UTFMBILL.myData

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
Me.Crv1.Location = New System.Drawing.Point(-2, -2)
Me.Crv1.Name = "Crv1"
Me.Crv1.SelectionFormula = ""
Me.Crv1.Size = New System.Drawing.Size(666, 391)
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

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    myUTFMBILL = New UTFMBILL.mydata(MyDBConnect)
    WrkBillType = GetUTTypeDesc(WrkUBType)
    WrkFamily = GetUTTYPEFamily(WrkUBType)
    GetUTFMBILL(WrkUBType)
    If Trim(myUTFMBILL._LINE1) = String.Empty Then
      GetUTFMBILL(" ")
    End If
    If MyFrmUB412B.RbReport.Checked Then
      RunReport1()
    Else
      RunReport2()
    End If

 End Sub
Private Sub GetUTFMBILL(ByVal WrkType As String)
  myUTFMBILL = New UTFMBILL.mydata(MyDBConnect)

  myUTFMBILL.GetOneRecordP(WrkType)
End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport.Close()
  myreport.Dispose()
End Sub
  Private Sub RunReport1()
   Dim ReportPath As String
   Dim ReportTitle As String

   ReportTitle = "Payoff Report"
   If MyFrmUB412B.RbSortList.Checked Then
    ReportTitle = ReportTitle & " by List No"
   End If
   If MyFrmUB412B.RbSortName.Checked Then
    ReportTitle = ReportTitle & " by Name"
   End If
   If MyFrmUB412B.RbSortLocation.Checked Then
    ReportTitle = ReportTitle & " by Location"
   End If

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtUB412.rpt", myTOWN._TOWNBR)
    With myreport
    .Load(ReportPath)
    .SetDataSource(wrkds)
    .SetParameterValue("myreportTitle", ReportTitle)
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyInterestDate", MyFrmUB412B.DtPckInterest.Value)
    .SetParameterValue("MyAddress", MyFrmUB412B.ChkAddress.Checked)
    .SetParameterValue("MyFamily", WrkFamily)
    .SetParameterValue("MyDistrict", MyUtils.CnvSng(MyFrmUB412B.TxtDist.Text))
    .SetParameterValue("MyPhase", MyUtils.CnvSng(MyFrmUB412B.TxtPhase.Text))
    .SetParameterValue("MyYear", MyUtils.CnvSng(MyFrmUB412B.TxtYear.Text))
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
   Dim ReportTitle As String

   ReportTitle = "Payoff Letter"
   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtUB412Ltr.rpt", myTOWN._TOWNBR)
    With myreport
    .Load(ReportPath)
    .SetDataSource(wrkds)
    .SetParameterValue("myreportTitle", ReportTitle)
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyInterestDate", MyFrmUB412B.DtPckInterest.Value)
    .SetParameterValue("MyPayTo", Trim(myUTFMBILL._PAYTO))
    .SetParameterValue("MyLine1", Trim(myUTFMBILL._LINE1))
    .SetParameterValue("MyLine2", Trim(myUTFMBILL._LINE2))
    .SetParameterValue("MyLine3", Trim(myUTFMBILL._LINE3))
    .SetParameterValue("MyLine4", Trim(myUTFMBILL._LINE4))
    '.SetParameterValue("MyLine5", Trim(myUTFMBILL._LINE5))
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






