Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport4 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport5 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport6 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport7 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim WrkMargin As CrystalDecisions.Shared.PageMargins
  Friend Wrkds As DataSet
  Friend WrkdsElderly As DataSet
  Friend WrkdsTot As DataSet
  Friend WrkdsTotEx As DataSet
  Friend WrkdsBCCTotEx As DataSet
  Friend WrkdsErr As DataSet
  Friend WrkType As String
  Friend WithEvents TabPgTotEx As System.Windows.Forms.TabPage
  Friend WithEvents Crv5 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents PrtDialog As System.Windows.Forms.PrintDialog
  Friend WithEvents TabBalancing As System.Windows.Forms.TabPage
  Friend WithEvents Crv6 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TabPgCC As System.Windows.Forms.TabPage
  Friend WithEvents Crv7 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WrkTypeDesc As String

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
Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents Crv4 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents TabPgRateBook As System.Windows.Forms.TabPage
Friend WithEvents TabPgElderly As System.Windows.Forms.TabPage
Friend WithEvents TabPgTotals As System.Windows.Forms.TabPage
Friend WithEvents TabPgBCCTotEx As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.TabCtl1 = New System.Windows.Forms.TabControl()
    Me.TabPgRateBook = New System.Windows.Forms.TabPage()
    Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabPgElderly = New System.Windows.Forms.TabPage()
    Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabPgTotals = New System.Windows.Forms.TabPage()
    Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabPgBCCTotEx = New System.Windows.Forms.TabPage()
    Me.Crv4 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabPgTotEx = New System.Windows.Forms.TabPage()
    Me.Crv5 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabBalancing = New System.Windows.Forms.TabPage()
    Me.Crv6 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.PrtDialog = New System.Windows.Forms.PrintDialog()
    Me.TabPgCC = New System.Windows.Forms.TabPage()
    Me.Crv7 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabCtl1.SuspendLayout()
    Me.TabPgRateBook.SuspendLayout()
    Me.TabPgElderly.SuspendLayout()
    Me.TabPgTotals.SuspendLayout()
    Me.TabPgBCCTotEx.SuspendLayout()
    Me.TabPgTotEx.SuspendLayout()
    Me.TabBalancing.SuspendLayout()
    Me.TabPgCC.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabCtl1
    '
    Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabCtl1.Controls.Add(Me.TabPgRateBook)
    Me.TabCtl1.Controls.Add(Me.TabPgElderly)
    Me.TabCtl1.Controls.Add(Me.TabPgTotals)
    Me.TabCtl1.Controls.Add(Me.TabPgBCCTotEx)
    Me.TabCtl1.Controls.Add(Me.TabPgTotEx)
    Me.TabCtl1.Controls.Add(Me.TabBalancing)
    Me.TabCtl1.Controls.Add(Me.TabPgCC)
    Me.TabCtl1.Location = New System.Drawing.Point(4, 4)
    Me.TabCtl1.Name = "TabCtl1"
    Me.TabCtl1.SelectedIndex = 0
    Me.TabCtl1.Size = New System.Drawing.Size(656, 380)
    Me.TabCtl1.TabIndex = 0
    '
    'TabPgRateBook
    '
    Me.TabPgRateBook.Controls.Add(Me.Crv1)
    Me.TabPgRateBook.Location = New System.Drawing.Point(4, 22)
    Me.TabPgRateBook.Name = "TabPgRateBook"
    Me.TabPgRateBook.Size = New System.Drawing.Size(648, 354)
    Me.TabPgRateBook.TabIndex = 0
    Me.TabPgRateBook.Text = "Rate Book"
    Me.TabPgRateBook.UseVisualStyleBackColor = True
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
    Me.Crv1.Location = New System.Drawing.Point(0, 0)
    Me.Crv1.Name = "Crv1"
    Me.Crv1.SelectionFormula = ""
    Me.Crv1.Size = New System.Drawing.Size(648, 352)
    Me.Crv1.TabIndex = 1
    Me.Crv1.ViewTimeSelectionFormula = ""
    '
    'TabPgElderly
    '
    Me.TabPgElderly.Controls.Add(Me.Crv2)
    Me.TabPgElderly.Location = New System.Drawing.Point(4, 22)
    Me.TabPgElderly.Name = "TabPgElderly"
    Me.TabPgElderly.Size = New System.Drawing.Size(648, 354)
    Me.TabPgElderly.TabIndex = 2
    Me.TabPgElderly.Text = "Elderly"
    Me.TabPgElderly.UseVisualStyleBackColor = True
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
    Me.Crv2.Location = New System.Drawing.Point(0, 1)
    Me.Crv2.Name = "Crv2"
    Me.Crv2.SelectionFormula = ""
    Me.Crv2.Size = New System.Drawing.Size(648, 352)
    Me.Crv2.TabIndex = 2
    Me.Crv2.ViewTimeSelectionFormula = ""
    '
    'TabPgTotals
    '
    Me.TabPgTotals.Controls.Add(Me.Crv3)
    Me.TabPgTotals.Location = New System.Drawing.Point(4, 22)
    Me.TabPgTotals.Name = "TabPgTotals"
    Me.TabPgTotals.Size = New System.Drawing.Size(648, 354)
    Me.TabPgTotals.TabIndex = 1
    Me.TabPgTotals.Text = "Totals"
    Me.TabPgTotals.UseVisualStyleBackColor = True
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
    Me.Crv3.Location = New System.Drawing.Point(0, 0)
    Me.Crv3.Name = "Crv3"
    Me.Crv3.SelectionFormula = ""
    Me.Crv3.Size = New System.Drawing.Size(648, 352)
    Me.Crv3.TabIndex = 2
    Me.Crv3.ViewTimeSelectionFormula = ""
    '
    'TabPgBCCTotEx
    '
    Me.TabPgBCCTotEx.Controls.Add(Me.Crv4)
    Me.TabPgBCCTotEx.Location = New System.Drawing.Point(4, 22)
    Me.TabPgBCCTotEx.Name = "TabPgBCCTotEx"
    Me.TabPgBCCTotEx.Size = New System.Drawing.Size(648, 354)
    Me.TabPgBCCTotEx.TabIndex = 3
    Me.TabPgBCCTotEx.Text = "Before C/C Exemption Totals"
    Me.TabPgBCCTotEx.UseVisualStyleBackColor = True
    '
    'Crv4
    '
    Me.Crv4.ActiveViewIndex = -1
    Me.Crv4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv4.DisplayStatusBar = False
    Me.Crv4.DisplayToolbar = False
    Me.Crv4.Location = New System.Drawing.Point(0, 1)
    Me.Crv4.Name = "Crv4"
    Me.Crv4.SelectionFormula = ""
    Me.Crv4.Size = New System.Drawing.Size(648, 352)
    Me.Crv4.TabIndex = 2
    Me.Crv4.ViewTimeSelectionFormula = ""
    '
    'TabPgTotEx
    '
    Me.TabPgTotEx.Controls.Add(Me.Crv5)
    Me.TabPgTotEx.Location = New System.Drawing.Point(4, 22)
    Me.TabPgTotEx.Name = "TabPgTotEx"
    Me.TabPgTotEx.Size = New System.Drawing.Size(648, 354)
    Me.TabPgTotEx.TabIndex = 4
    Me.TabPgTotEx.Text = "After C/C Exemption Totals"
    Me.TabPgTotEx.UseVisualStyleBackColor = True
    '
    'Crv5
    '
    Me.Crv5.ActiveViewIndex = -1
    Me.Crv5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv5.Cursor = System.Windows.Forms.Cursors.Default
    Me.Crv5.DisplayStatusBar = False
    Me.Crv5.DisplayToolbar = False
    Me.Crv5.Location = New System.Drawing.Point(0, 1)
    Me.Crv5.Name = "Crv5"
    Me.Crv5.SelectionFormula = ""
    Me.Crv5.Size = New System.Drawing.Size(648, 352)
    Me.Crv5.TabIndex = 3
    Me.Crv5.ViewTimeSelectionFormula = ""
    '
    'TabBalancing
    '
    Me.TabBalancing.Controls.Add(Me.Crv6)
    Me.TabBalancing.Location = New System.Drawing.Point(4, 22)
    Me.TabBalancing.Name = "TabBalancing"
    Me.TabBalancing.Size = New System.Drawing.Size(648, 354)
    Me.TabBalancing.TabIndex = 5
    Me.TabBalancing.Text = "Balancing"
    Me.TabBalancing.UseVisualStyleBackColor = True
    '
    'Crv6
    '
    Me.Crv6.ActiveViewIndex = -1
    Me.Crv6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv6.Cursor = System.Windows.Forms.Cursors.Default
    Me.Crv6.DisplayStatusBar = False
    Me.Crv6.DisplayToolbar = False
    Me.Crv6.Location = New System.Drawing.Point(0, 1)
    Me.Crv6.Name = "Crv6"
    Me.Crv6.SelectionFormula = ""
    Me.Crv6.Size = New System.Drawing.Size(648, 352)
    Me.Crv6.TabIndex = 2
    Me.Crv6.ViewTimeSelectionFormula = ""
    '
    'TabPgCC
    '
    Me.TabPgCC.Controls.Add(Me.Crv7)
    Me.TabPgCC.Location = New System.Drawing.Point(4, 22)
    Me.TabPgCC.Name = "TabPgCC"
    Me.TabPgCC.Size = New System.Drawing.Size(648, 354)
    Me.TabPgCC.TabIndex = 6
    Me.TabPgCC.Text = "C/C Detail"
    Me.TabPgCC.UseVisualStyleBackColor = True
    '
    'Crv7
    '
    Me.Crv7.ActiveViewIndex = -1
    Me.Crv7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv7.Cursor = System.Windows.Forms.Cursors.Default
    Me.Crv7.DisplayStatusBar = False
    Me.Crv7.DisplayToolbar = False
    Me.Crv7.Location = New System.Drawing.Point(0, 1)
    Me.Crv7.Name = "Crv7"
    Me.Crv7.SelectionFormula = ""
    Me.Crv7.Size = New System.Drawing.Size(648, 352)
    Me.Crv7.TabIndex = 4
    Me.Crv7.ViewTimeSelectionFormula = ""
    '
    'FrmCrViewer
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(664, 386)
    Me.Controls.Add(Me.TabCtl1)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmCrViewer"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Report Viewer (Press ENTER to Print all)"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    Me.TabCtl1.ResumeLayout(False)
    Me.TabPgRateBook.ResumeLayout(False)
    Me.TabPgElderly.ResumeLayout(False)
    Me.TabPgTotals.ResumeLayout(False)
    Me.TabPgBCCTotEx.ResumeLayout(False)
    Me.TabPgTotEx.ResumeLayout(False)
    Me.TabBalancing.ResumeLayout(False)
    Me.TabPgCC.ResumeLayout(False)
    Me.ResumeLayout(False)

End Sub

#End Region
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  'To do: Add report for DsErr when needed
  myreport1.Close()
  myreport1.Dispose()
  myreport2.Close()
  myreport2.Dispose()
  myreport3.Close()
  myreport3.Dispose()
  myreport4.Close()
  myreport4.Dispose()
  myreport5.Close()
  myreport5.Dispose()
  myreport6.Close()
  myreport6.Dispose()
  myreport7.Close()
  myreport7.Dispose()
End Sub

Private Sub CrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  With WrkMargin
    .leftMargin = MyReportLeftMargin
    .rightMargin = 150
    .topMargin = MyReportTopMargin
    .bottomMargin = 150
  End With
  RunReport1()
  If WrkType = "R" Then
    RunReport2()
  Else
    TabCtl1.TabPages.Remove(TabPgElderly)
  End If
  RunReport3()
  If WrkType <> "X" Then
    RunReport4()
  Else
    TabCtl1.TabPages.Remove(TabPgBCCTotEx)
  End If
  If WrkType <> "S" And WrkType <> "X" Then
    RunReport5()
  Else
    TabCtl1.TabPages.Remove(TabPgTotEx)
  End If
  RunReport6()
  RunReport7()
End Sub
  Private Sub RunReport1()
   Dim ReportPath As String

   ReportPath = ""
   Select Case WrkType
   Case "P", "M"
     ReportPath = MyUtils.GetReportPath("PrtTX201PP.rpt", myTOWN._TOWNBR)
   Case "R"
     ReportPath = MyUtils.GetReportPath("PrtTX201RE.rpt", myTOWN._TOWNBR)
   Case "S"
     ReportPath = MyUtils.GetReportPath("PrtTX201SU.rpt", myTOWN._TOWNBR)
   Case "X"
     ReportPath = MyUtils.GetReportPath("PrtTX201Prorate.rpt", myTOWN._TOWNBR)
   End Select
   With myreport1
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
    End If
    .PrintOptions.ApplyPageMargins(WrkMargin)
    .SetDataSource(Wrkds)
    .SetParameterValue("myreportTitle", "Ratebook")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyMillRate", MrateMillrt * 1000)
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
   Dim ReportPath As String

   ReportPath = MyUtils.GetReportPath("PrtTX201RE.rpt", myTOWN._TOWNBR)
   With myreport2
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
    End If
    .PrintOptions.ApplyPageMargins(WrkMargin)
    .SetDataSource(WrkdsElderly)
    .SetParameterValue("myreportTitle", "Elderly Ratebook")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyMillRate", MrateMillrt * 1000)
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
     .Zoom(75)
   End With

  End Sub
  Private Sub RunReport3()
   Dim ReportPath As String

   ReportPath = ""
   Select Case WrkType
   Case "M"
     ReportPath = MyUtils.GetReportPath("PrtTX201TotMV.rpt", myTOWN._TOWNBR)
   Case "P"
     ReportPath = MyUtils.GetReportPath("PrtTX201TotPP.rpt", myTOWN._TOWNBR)
   Case "R"
     ReportPath = MyUtils.GetReportPath("PrtTX201TotRE.rpt", myTOWN._TOWNBR)
   Case "S"
     ReportPath = MyUtils.GetReportPath("PrtTX201TotSU.rpt", myTOWN._TOWNBR)
   Case "X"
     ReportPath = MyUtils.GetReportPath("PrtTX201TotProrate.rpt", myTOWN._TOWNBR)
   End Select
   With myreport3
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
    End If
    .PrintOptions.ApplyPageMargins(WrkMargin)
    .SetDataSource(WrkdsTot)
    .SetParameterValue("myreportTitle", "Ratebook Totals")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyMillRate", MrateMillrt * 1000)
		.SetParameterValue("MyYear", MyFrmTX201B.TxtGLYear.Text)
    .SetParameterValue("MyTypeDesc", WrkTypeDesc)
   End With
   With Crv3
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
   Dim ReportPath As String

   ReportPath = MyUtils.GetReportPath("PrtTX201TotEx.rpt", myTOWN._TOWNBR)
   With myreport4
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
    End If
    .PrintOptions.ApplyPageMargins(WrkMargin)
    .SetDataSource(WrkdsBCCTotEx)
    .SetParameterValue("myreportTitle", "Ratebook Before C/C Exemption Totals")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyMillRate", MrateMillrt * 1000)
		.SetParameterValue("MyYear", MyFrmTX201B.TxtGLYear.Text)
    .SetParameterValue("MyTypeDesc", WrkTypeDesc)
   End With
   With Crv4
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
  Private Sub RunReport5()
   Dim ReportPath As String

   ReportPath = MyUtils.GetReportPath("PrtTX201TotEx.rpt", myTOWN._TOWNBR)
   With myreport5
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
    End If
    .PrintOptions.ApplyPageMargins(WrkMargin)
    .SetDataSource(WrkdsTotEx)
    .SetParameterValue("myreportTitle", "Ratebook After C/C Exemption Totals")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyMillRate", MrateMillrt * 1000)
		.SetParameterValue("MyYear", MyFrmTX201B.TxtGLYear.Text)
    .SetParameterValue("MyTypeDesc", WrkTypeDesc)
   End With
   With Crv5
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
  Private Sub RunReport6()
   Dim ReportPath As String

   ReportPath = MyUtils.GetReportPath("PrtTX201TotBal.rpt", myTOWN._TOWNBR)
   With myreport6
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
    End If
    .PrintOptions.ApplyPageMargins(WrkMargin)
    .SetDataSource(WrkdsTot)
    .SetParameterValue("myreportTitle", "Ratebook Balancing Totals")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyMillRate", MrateMillrt * 1000)
    .SetParameterValue("MyYear", MyFrmTX201B.TxtGLYear.Text)
    .SetParameterValue("MyTypeDesc", WrkTypeDesc)
   End With
   With Crv6
     .DisplayToolbar = True
     .ShowGroupTreeButton = False
     .ShowCloseButton = False
     .ShowCopyButton = False
     .ShowRefreshButton = False
     .ShowParameterPanelButton = False
     .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
     .ReportSource = myreport6
     .Zoom(75)
   End With

  End Sub
  Private Sub RunReport7()
   Dim ReportPath As String

   ReportPath = MyUtils.GetReportPath("PrtTX201CC.rpt", myTOWN._TOWNBR)
   With myreport7
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
    End If
    .PrintOptions.ApplyPageMargins(WrkMargin)
    .SetDataSource(Wrkds)
    .SetParameterValue("myreportTitle", "Ratebook C/C Detail")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyMillRate", MrateMillrt * 1000)
   End With
   With Crv7
     .DisplayToolbar = True
     .ShowGroupTreeButton = False
     .ShowCloseButton = False
     .ShowCopyButton = False
     .ShowRefreshButton = False
     .ShowParameterPanelButton = False
     .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
     .ReportSource = myreport7
     .Zoom(75)
   End With

  End Sub
Private Sub FrmCrViewer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  Dim WrkPrinter As String

    If e.KeyCode = Keys.Enter Then

      PrtDialog.PrinterSettings = New Printing.PrinterSettings
      Dim result As DialogResult = PrtDialog.ShowDialog()
      WrkPrinter = String.Empty
      If (result = Windows.Forms.DialogResult.OK) Then
        WrkPrinter = PrtDialog.PrinterSettings.PrinterName()
      Else
        Exit Sub
      End If

      With myreport1
        .PrintOptions.PrinterName = WrkPrinter
        If MyReportLandscape Then
          .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
          .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        End If
        .PrintOptions.ApplyPageMargins(WrkMargin)
        .PrintToPrinter(1, True, 0, 0)
      End With
      If WrkType = "R" Then
        With myreport2
          .PrintOptions.PrinterName = WrkPrinter
          If MyReportLandscape Then
            .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
            .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
          End If
          .PrintOptions.ApplyPageMargins(WrkMargin)
          .PrintToPrinter(1, True, 0, 0)
        End With
      End If
      With myreport3
        .PrintOptions.PrinterName = WrkPrinter
        If MyReportLandscape Then
          .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
          .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        End If
        .PrintOptions.ApplyPageMargins(WrkMargin)
        .PrintToPrinter(1, True, 0, 0)
      End With
      If WrkType <> "X" Then
        With myreport4
          .PrintOptions.PrinterName = WrkPrinter
          If MyReportLandscape Then
            .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
            .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
          End If
          .PrintOptions.ApplyPageMargins(WrkMargin)
          .PrintToPrinter(1, True, 0, 0)
        End With
      End If
      If WrkType <> "S" And WrkType <> "X" Then
        With myreport5
          .PrintOptions.PrinterName = WrkPrinter
          If MyReportLandscape Then
            .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
            .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
          End If
          .PrintOptions.ApplyPageMargins(WrkMargin)
          .PrintToPrinter(1, True, 0, 0)
        End With
      End If
    End If
  End Sub

Private Sub TabCtl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabCtl1.SelectedIndexChanged

End Sub
End Class






