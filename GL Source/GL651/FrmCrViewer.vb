Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend wrkds As DataSet = New DataSet
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer

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
Me.Crv1.AutoSize = True
Me.Crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Crv1.Location = New System.Drawing.Point(12, 17)
Me.Crv1.Name = "Crv1"
Me.Crv1.SelectionFormula = ""
Me.Crv1.Size = New System.Drawing.Size(640, 352)
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
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    RunReport1()
 End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport.Close()
  myreport.Dispose()
End Sub

  Private Sub RunReport1()
   Dim ReportPath As String
   Dim WrkYear As Integer

    WrkYear = MyUtils.CnvSng(MyFrmGL651B.LblToYear.Text)

    Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtGL651.rpt", myTOWN._TOWNBR)
   With myreport
    .Load(ReportPath)
    .SetDataSource(wrkds)
    .SetParameterValue("myreportTitle", "Estimate of Revenue")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyFund", MyUtils.CnvSng(MyFrmGL651B.TxtFund.Text))
    .SetParameterValue("MyDept", MyUtils.CnvSng(MyFrmGL651B.TxtDept.Text))
    .SetParameterValue("MyYear", WrkYear)
    .SetParameterValue("MyPrevYrs4", BuildYears(WrkYear, -4))
    .SetParameterValue("MyPrevYrs3", BuildYears(WrkYear, -3))
    .SetParameterValue("MyPrevYrs2", BuildYears(WrkYear, -2))
    .SetParameterValue("MyPrevYrs1", BuildYears(WrkYear, -1))
    .SetParameterValue("MyCurrYrs", BuildYears(WrkYear, 0))
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
Private Function BuildYears(ByVal WrkYear As Integer, ByVal YearsDiff As Integer) As String
  Dim WrkStr As String

  WrkStr = (WrkYear + YearsDiff - 1) & "-" & (WrkYear + YearsDiff)
  Return WrkStr
End Function
End Class
