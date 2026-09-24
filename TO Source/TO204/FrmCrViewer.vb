Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend wrkds As DataSet = New DataSet
  Friend WrkPgm As String
  Dim WrkVet As Boolean

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
  Select Case WrkPgm
  Case "State"
    RunReportState()
  Case "Local"
    WrkVet = True
    If MyFrmTO204C.LblLocPgm.Text = "DAC" Then
      RunReportLocal("DAC")
    Else
      RunReportLocal("LOC")
    End If
  Case "EBC"
    WrkVet = False
    RunReportLocal("EBC")
  Case "FBC"
    WrkVet = False
    RunReportLocal("FBC")
  End Select
 End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport1.Close()
  myreport1.Dispose()
End Sub

  Private Sub RunReportState()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTO204.rpt", myTOWN._TOWNBR)
   With myreport1
    .Load(ReportPath)
    .SetDataSource(wrkds)
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
Private Sub RunReportLocal(ByVal WrkLocPgm As String)
   Dim ReportPath As String
   Dim WrkHeader1 As String
   Dim WrkHeader2 As String
   Dim WrkHeader3 As String

   WrkHeader1 = ""
   WrkHeader2 = ""
   WrkHeader3 = ""
    Select Case Trim(WrkLocPgm)
      Case "LOC", "DAC"
        If MyLocEld = "045" Or MyLocEld = "162" Then
          WrkHeader1 = "APPLICATION For LOCAL Option ADDITIONAL VETERAN'S EXEMPTION"
          WrkHeader2 = "FILE BIENNIALLY"
          WrkHeader3 = "FILING PERIOD FEB 1 - OCT 1"
        End If
        If MyLocEld = "084" Then
          WrkHeader1 = "APPLICATION FOR VETERANS ADDITIONAL LOCAL OPTION"
          WrkHeader2 = "Ordiance 20.5-7 as authorized by Section 12-81 CGS as amended by"
          WrkHeader3 = "Public Act 82-318, PA02-137, PA03-44"
        End If
      Case "EBC"
        WrkHeader1 = "APPLICATION FOR TOTALLY DISABLED EXEMPTION"
        WrkHeader2 = "Public Act 85-294"
        WrkHeader3 = ""
      Case "FBC"
        WrkHeader1 = "APPLICATION FOR BLIND EXEMPTION"
        WrkHeader2 = "Public Act 85-294"
        WrkHeader3 = ""
      Case Else
    End Select

    Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTO204LP.rpt", myTOWN._TOWNBR)
   With myreport1
    .Load(ReportPath)
    .SetDataSource(wrkds)
    .SetParameterValue("MyTown", Trim(myTOWN._TOWN))
    .SetParameterValue("MySingle", MyUtils.CnvSng(MyFrmTO204C.LblLocSingle.Text))
    .SetParameterValue("MyMarried", MyUtils.CnvSng(MyFrmTO204C.LblLocMarried.Text))
    .SetParameterValue("MyHeader1", WrkHeader1)
    .SetParameterValue("MyHeader2", WrkHeader2)
    .SetParameterValue("MyHeader3", WrkHeader3)
    .SetParameterValue("MyPgm", WrkLocPgm)
    .SetParameterValue("MyVet", WrkVet)
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
End Class






