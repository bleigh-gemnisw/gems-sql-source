Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport5 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim WrkMargin As CrystalDecisions.Shared.PageMargins
  Friend Wrkds As DataSet
  Friend WrkdsTot As DataSet
  Friend WrkdsTotEx As DataSet
  Friend WrkdsErr As DataSet
  Friend WrkType As String
  Friend WrkFamily As String
  Friend WithEvents TabPgTotEx As System.Windows.Forms.TabPage
  Friend WithEvents Crv5 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents PrtDialog As System.Windows.Forms.PrintDialog
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
Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents TabPgRateBook As System.Windows.Forms.TabPage
Friend WithEvents TabPgTotals As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.TabCtl1 = New System.Windows.Forms.TabControl
Me.TabPgRateBook = New System.Windows.Forms.TabPage
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabPgTotals = New System.Windows.Forms.TabPage
Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabPgTotEx = New System.Windows.Forms.TabPage
Me.Crv5 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.PrtDialog = New System.Windows.Forms.PrintDialog
Me.TabCtl1.SuspendLayout()
Me.TabPgRateBook.SuspendLayout()
Me.TabPgTotals.SuspendLayout()
Me.TabPgTotEx.SuspendLayout()
Me.SuspendLayout()
'
'TabCtl1
'
Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabCtl1.Controls.Add(Me.TabPgRateBook)
Me.TabCtl1.Controls.Add(Me.TabPgTotals)
Me.TabCtl1.Controls.Add(Me.TabPgTotEx)
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
Me.Crv1.DisplayStatusBar = False
Me.Crv1.DisplayToolbar = False
Me.Crv1.Location = New System.Drawing.Point(0, 0)
Me.Crv1.Name = "Crv1"
Me.Crv1.SelectionFormula = ""
Me.Crv1.Size = New System.Drawing.Size(648, 352)
Me.Crv1.TabIndex = 1
Me.Crv1.ViewTimeSelectionFormula = ""
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
'TabPgTotEx
'
Me.TabPgTotEx.Controls.Add(Me.Crv5)
Me.TabPgTotEx.Location = New System.Drawing.Point(4, 22)
Me.TabPgTotEx.Name = "TabPgTotEx"
Me.TabPgTotEx.Size = New System.Drawing.Size(648, 354)
Me.TabPgTotEx.TabIndex = 4
Me.TabPgTotEx.Text = "Exemption Totals"
Me.TabPgTotEx.UseVisualStyleBackColor = True
'
'Crv5
'
Me.Crv5.ActiveViewIndex = -1
Me.Crv5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.Crv5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Crv5.DisplayStatusBar = False
Me.Crv5.DisplayToolbar = False
Me.Crv5.Location = New System.Drawing.Point(0, 1)
Me.Crv5.Name = "Crv5"
Me.Crv5.SelectionFormula = ""
Me.Crv5.Size = New System.Drawing.Size(648, 352)
Me.Crv5.TabIndex = 3
Me.Crv5.ViewTimeSelectionFormula = ""
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
Me.TabPgTotals.ResumeLayout(False)
Me.TabPgTotEx.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  'To do: Add report for DsErr when needed
  myreport1.Close()
  myreport1.Dispose()
  myreport3.Close()
  myreport3.Dispose()
  myreport5.Close()
  myreport5.Dispose()
End Sub

Private Sub CrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  With WrkMargin
    .leftMargin = MyReportLeftMargin
    .rightMargin = 150
    .topMargin = MyReportTopMargin
    .bottomMargin = 150
  End With
  RunReport1()
  RunReport3()
  RunReport5()
End Sub
  Private Sub RunReport1()
   Dim ReportPath As String

   Select Case wrkfamily
   Case "S"
     ReportPath = MyUtils.GetReportPath("PrtTX351SU.rpt", myTOWN._TOWNBR)
   Case Else
     ReportPath = MyUtils.GetReportPath("PrtTX351.rpt", myTOWN._TOWNBR)
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
  Private Sub RunReport3()
   Dim ReportPath As String

   Select Case WrkFamily
   Case "S"
     ReportPath = MyUtils.GetReportPath("PrtTX351TotSU.rpt", myTOWN._TOWNBR)
   Case Else
     ReportPath = MyUtils.GetReportPath("PrtTX351Tot.rpt", myTOWN._TOWNBR)
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
    .SetParameterValue("MyYear", MyFrmTX351B.TxtGLYear.Text)
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
  Private Sub RunReport5()
   Dim ReportPath As String

  ReportPath = MyUtils.GetReportPath("PrtTX351TotEx.rpt", myTOWN._TOWNBR)
   With myreport5
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
    End If
    .PrintOptions.ApplyPageMargins(WrkMargin)
    .SetDataSource(WrkdsTotEx)
    .SetParameterValue("myreportTitle", "Ratebook Exemption Totals")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyMillRate", MrateMillrt * 1000)
    .SetParameterValue("MyYear", MyFrmTX351B.TxtGLYear.Text)
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
      With myreport3
        .PrintOptions.PrinterName = WrkPrinter
        If MyReportLandscape Then
          .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
          .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        End If
        .PrintOptions.ApplyPageMargins(WrkMargin)
        .PrintToPrinter(1, True, 0, 0)
      End With
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






