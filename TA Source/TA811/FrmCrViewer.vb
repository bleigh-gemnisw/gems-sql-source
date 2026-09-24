Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreportRE As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreportPP As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreportMV As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreportSU As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreportMVCR As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim dsTXPROF As New DataSet
  Friend Wrkds As DataSet
  Friend WrkType As String

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
Friend WithEvents TabPgCC As System.Windows.Forms.TabPage
Friend WithEvents TabPgMVCR As System.Windows.Forms.TabPage
Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.TabCtl1 = New System.Windows.Forms.TabControl
Me.TabPgCC = New System.Windows.Forms.TabPage
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabPgMVCR = New System.Windows.Forms.TabPage
Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabCtl1.SuspendLayout()
Me.TabPgCC.SuspendLayout()
Me.TabPgMVCR.SuspendLayout()
Me.SuspendLayout()
'
'TabCtl1
'
Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabCtl1.Controls.Add(Me.TabPgCC)
Me.TabCtl1.Controls.Add(Me.TabPgMVCR)
Me.TabCtl1.Location = New System.Drawing.Point(4, 8)
Me.TabCtl1.Name = "TabCtl1"
Me.TabCtl1.SelectedIndex = 0
Me.TabCtl1.Size = New System.Drawing.Size(656, 372)
Me.TabCtl1.TabIndex = 0
'
'TabPgCC
'
Me.TabPgCC.Controls.Add(Me.Crv1)
Me.TabPgCC.Location = New System.Drawing.Point(4, 22)
Me.TabPgCC.Name = "TabPgCC"
Me.TabPgCC.Size = New System.Drawing.Size(648, 346)
Me.TabPgCC.TabIndex = 0
Me.TabPgCC.Text = "C/C"
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
Me.Crv1.Size = New System.Drawing.Size(648, 344)
Me.Crv1.TabIndex = 1
'
'TabPgMVCR
'
Me.TabPgMVCR.Controls.Add(Me.Crv2)
Me.TabPgMVCR.Location = New System.Drawing.Point(4, 22)
Me.TabPgMVCR.Name = "TabPgMVCR"
Me.TabPgMVCR.Size = New System.Drawing.Size(648, 346)
Me.TabPgMVCR.TabIndex = 1
Me.TabPgMVCR.Text = "MV Credit"
'
'Crv2
'
Me.Crv2.ActiveViewIndex = -1
Me.Crv2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.Crv2.DisplayToolbar = False
Me.Crv2.Location = New System.Drawing.Point(0, 1)
Me.Crv2.Name = "Crv2"
Me.Crv2.ReportSource = Nothing
Me.Crv2.Size = New System.Drawing.Size(648, 344)
Me.Crv2.TabIndex = 2
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
Me.TabPgCC.ResumeLayout(False)
Me.TabPgMVCR.ResumeLayout(False)
Me.ResumeLayout(False)

    End Sub

#End Region

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkTypeFamily As String
    Dim Good As Boolean

    If MyAppSettings.Printer <> "" Then
      Good = MyUtils.CheckPrinterExists(MyAppSettings.Printer)
      If Not Good Then
        MsgBox("Printer " & MyAppSettings.Printer & " does not exist. Return to search screen and then click on settings button to change.", MsgBoxStyle.Exclamation, "Report cannot be printed")
        Me.Close()
        Exit Sub
      End If
    End If

    WrkTypeFamily = GetTXTypeFamily(WrkType)
    Select Case WrkTypeFamily
    Case "R"
      TabCtl1.TabPages.Remove(TabPgMVCR)
      RunReportRE()
    Case "P"
      TabCtl1.TabPages.Remove(TabPgMVCR)
      RunReportPP()
    Case "M"
      RunReportMV()
      RunReportMVCR()
    Case "S"
      RunReportSU()
    End Select
    If MyAppSettings.Printer <> "" Then
      Me.Close()
    End If

End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreportRE.Close()
  myreportRE.Dispose()
  myreportPP.Close()
  myreportPP.Dispose()
  myreportMV.Close()
  myreportMV.Dispose()
  myreportSU.Close()
  myreportSU.Dispose()
End Sub
 Private Sub RunReportRE()
    Dim ReportPath As String
    Dim AddrLine() As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTA811RE.rpt", myTOWN._TOWNBR)
    With myreportRE
      .Load(ReportPath)
      If MyAppSettings.Printer <> "" Then
        .PrintOptions.PrinterName = MyAppSettings.Printer
        If MyAppSettings.Copies = 0 Then
          Exit Sub
        End If
      End If
      .SetDataSource(Wrkds)
    .SetParameterValue("myreportTitle", "CERTIFICATE OF CHANGE")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    With MyFrmTA8112R
      AddrLine = MyUtils.SetAddrLine(.TxtName.Text, .TxtSname.Text, .TxtAdd1.Text, _
       .TxtAdd2.Text, .TxtCity.Text, .TxtState.Text, MyUtils.CnvSng(.TxtZip5.Text), _
       MyUtils.CnvSng(.TxtZip4.Text))
    End With
    .SetParameterValue("AddrLine1", AddrLine(0))
    .SetParameterValue("AddrLine2", AddrLine(1))
    .SetParameterValue("AddrLine3", AddrLine(2))
    .SetParameterValue("AddrLine4", AddrLine(3))
    .SetParameterValue("AddrLine5", AddrLine(4))
    If MyAppSettings.Printer <> "" Then
      .PrintToPrinter(MyAppSettings.Copies, False, 0, 0)
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
     .ReportSource = myreportRE
     .Zoom(75)
   End With
  End Sub
 Private Sub RunReportPP()
    Dim ReportPath As String
    Dim AddrLine() As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTA811PP.rpt", myTOWN._TOWNBR)
    With myreportPP
      .Load(ReportPath)
      If MyAppSettings.Printer <> "" Then
        .PrintOptions.PrinterName = MyAppSettings.Printer
        If MyAppSettings.Copies = 0 Then
          Exit Sub
        End If
      End If
      .SetDataSource(Wrkds)
      .SetParameterValue("myreportTitle", "CERTIFICATE OF CHANGE")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      With MyFrmTA8113R
        AddrLine = MyUtils.SetAddrLine(.TxtName.Text, .TxtSname.Text, .TxtAdd1.Text,
       .TxtAdd2.Text, .TxtCity.Text, .TxtState.Text, MyUtils.CnvSng(.TxtZip5.Text),
       MyUtils.CnvSng(.TxtZip4.Text))
      End With
      .SetParameterValue("AddrLine1", AddrLine(0))
      .SetParameterValue("AddrLine2", AddrLine(1))
      .SetParameterValue("AddrLine3", AddrLine(2))
      .SetParameterValue("AddrLine4", AddrLine(3))
      .SetParameterValue("AddrLine5", AddrLine(4))
      If MyAppSettings.Printer <> "" Then
        .PrintToPrinter(MyAppSettings.Copies, False, 0, 0)
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
     .ReportSource = myreportPP
     .Zoom(75)
   End With
  End Sub
 Private Sub RunReportMV()
    Dim ReportPath As String
    Dim AddrLine() As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTA811MV.rpt", myTOWN._TOWNBR)
    With myreportMV
      .Load(ReportPath)
      If MyAppSettings.Printer <> "" Then
        .PrintOptions.PrinterName = MyAppSettings.Printer
        If MyAppSettings.Copies = 0 Then
          Exit Sub
        End If
      End If
      .SetDataSource(Wrkds)
      .SetParameterValue("myreportTitle", "CERTIFICATE OF CHANGE")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      With MyFrmTA8114R
        AddrLine = MyUtils.SetAddrLine(.TxtName.Text, .TxtSname.Text, .TxtAdd1.Text,
       .TxtAdd2.Text, .TxtCity.Text, .TxtState.Text, MyUtils.CnvSng(.TxtZip5.Text),
       MyUtils.CnvSng(.TxtZip4.Text))
      End With
      .SetParameterValue("AddrLine1", AddrLine(0))
      .SetParameterValue("AddrLine2", AddrLine(1))
      .SetParameterValue("AddrLine3", AddrLine(2))
      .SetParameterValue("AddrLine4", AddrLine(3))
      .SetParameterValue("AddrLine5", AddrLine(4))
      If MyAppSettings.Printer <> "" Then
        .PrintToPrinter(MyAppSettings.Copies, False, 0, 0)
        .Close()
        .Dispose()
      End If
    End With
    If MyAppSettings.Printer = "" Then
     With Crv1
     .DisplayToolbar = True
     .ShowGroupTreeButton = False
     .ShowCloseButton = False
     .ShowCopyButton = False
     .ShowRefreshButton = False
     .ShowParameterPanelButton = False
     .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
     .ReportSource = myreportMV
     .Zoom(75)
     End With
   End If
End Sub
 Private Sub RunReportMVCR()
    Dim ReportPath As String
    Dim AddrLine() As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTA811MVCR.rpt", myTOWN._TOWNBR)
    'MV Credit
    With myreportMVCR
      .Load(ReportPath)
      If MyAppSettings.Printer <> "" Then
        .PrintOptions.PrinterName = MyAppSettings.Printer
        If MyAppSettings.CopiesCR = 0 Then
          Exit Sub
        End If
      End If
      .SetDataSource(Wrkds)
      .SetParameterValue("myreportTitle", "MOTOR VEHICLE TAX CREDIT")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      With MyFrmTA8114R
        AddrLine = MyUtils.SetAddrLine(.TxtName.Text, .TxtSname.Text, .TxtAdd1.Text,
       .TxtAdd2.Text, .TxtCity.Text, .TxtState.Text, MyUtils.CnvSng(.TxtZip5.Text),
       MyUtils.CnvSng(.TxtZip4.Text))
      End With
      .SetParameterValue("AddrLine1", AddrLine(0))
      .SetParameterValue("AddrLine2", AddrLine(1))
      .SetParameterValue("AddrLine3", AddrLine(2))
      .SetParameterValue("AddrLine4", AddrLine(3))
      .SetParameterValue("AddrLine5", AddrLine(4))
      If MyAppSettings.Printer <> "" Then
        .PrintToPrinter(MyAppSettings.CopiesCR, False, 0, 0)
        .Close()
        .Dispose()
        Exit Sub
      End If
    End With
    With Crv2
     .DisplayToolbar = True
     .ShowGroupTreeButton = False
     .ShowCloseButton = False
     .ShowCopyButton = False
     .ShowRefreshButton = False
     .ShowParameterPanelButton = False
     .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
     .ReportSource = myreportMVCR
     .Zoom(75)
   End With
  End Sub
 Private Sub RunReportSU()
    Dim ReportPath As String
    Dim ReportPath2 As String
    Dim AddrLine() As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTA811SU.rpt", myTOWN._TOWNBR)
    ReportPath2 = MyUtils.GetReportPath("PrtTA811MVCR.rpt", myTOWN._TOWNBR)
    With myreportSU
      .Load(ReportPath)
      If MyAppSettings.Printer <> "" Then
        .PrintOptions.PrinterName = MyAppSettings.Printer
        If MyAppSettings.Copies = 0 Then
          GoTo PrtCredit
        End If
      End If
      .SetDataSource(Wrkds)
      .SetParameterValue("myreportTitle", "CERTIFICATE OF CHANGE")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      With MyFrmTA8115R
        AddrLine = MyUtils.SetAddrLine(.TxtName.Text, .TxtSname.Text, .TxtAdd1.Text,
       .TxtAdd2.Text, .TxtCity.Text, .TxtState.Text, MyUtils.CnvSng(.TxtZip5.Text),
       MyUtils.CnvSng(.TxtZip4.Text))
      End With
      .SetParameterValue("AddrLine1", AddrLine(0))
      .SetParameterValue("AddrLine2", AddrLine(1))
      .SetParameterValue("AddrLine3", AddrLine(2))
      .SetParameterValue("AddrLine4", AddrLine(3))
      .SetParameterValue("AddrLine5", AddrLine(4))
      If MyAppSettings.Printer <> "" Then
        .PrintToPrinter(MyAppSettings.Copies, False, 0, 0)
        .Close()
        .Dispose()
      End If
    End With
    If MyAppSettings.Printer = "" Then
     With Crv1
     .DisplayToolbar = True
     .ShowGroupTreeButton = False
     .ShowCloseButton = False
     .ShowCopyButton = False
     .ShowRefreshButton = False
     .ShowParameterPanelButton = False
     .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
     .ReportSource = myreportSU
     .Zoom(75)
     End With
   End If

PrtCredit:
  'MV Credit 
   With myreportMVCR
      .Load(ReportPath2)
      If MyAppSettings.Printer <> "" Then
        .PrintOptions.PrinterName = MyAppSettings.Printer
        If MyAppSettings.CopiesCR = 0 Then
          Exit Sub
        End If
      End If
      .SetDataSource(Wrkds)
    .SetParameterValue("myreportTitle", "MOTOR VEHICLE TAX CREDIT")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    With MyFrmTA8115R
      AddrLine = MyUtils.SetAddrLine(.TxtName.Text, .TxtSname.Text, .TxtAdd1.Text, _
       .TxtAdd2.Text, .TxtCity.Text, .TxtState.Text, MyUtils.CnvSng(.TxtZip5.Text), _
       MyUtils.CnvSng(.TxtZip4.Text))
    End With
    .SetParameterValue("AddrLine1", AddrLine(0))
    .SetParameterValue("AddrLine2", AddrLine(1))
    .SetParameterValue("AddrLine3", AddrLine(2))
    .SetParameterValue("AddrLine4", AddrLine(3))
    .SetParameterValue("AddrLine5", AddrLine(4))
    If MyAppSettings.Printer <> "" Then
      .PrintToPrinter(MyAppSettings.CopiesCR, False, 0, 0)
      .Close()
      .Dispose()
      Exit Sub
    End If
   End With
   With Crv2
     .DisplayToolbar = True
     .ShowGroupTreeButton = False
     .ShowCloseButton = False
     .ShowCopyButton = False
     .ShowRefreshButton = False
     .ShowParameterPanelButton = False
     .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
     .ReportSource = myreportMVCR
     .Zoom(75)
   End With
  End Sub

Private Sub Crv1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

End Sub

Private Sub TabCtl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabCtl1.SelectedIndexChanged

End Sub
End Class






