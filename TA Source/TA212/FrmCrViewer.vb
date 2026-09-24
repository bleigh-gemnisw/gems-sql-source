Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport4 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport5 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport6 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport7 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport8 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim WrkMargin As CrystalDecisions.Shared.PageMargins
  Friend Wrkds1 As DataSet
  Friend Wrkds2 As DataSet
  Friend WrkdsErr As DataSet
  Friend WrkdsTot As DataSet
  Friend WrkdsTotEx As DataSet
  Friend WrkdsTotMC As DataSet
  Friend WrkdsTotMC2 As DataSet
  Friend WrkdsTotExempt As DataSet
  Friend WrkType As String
  Friend WithEvents TabErrors As System.Windows.Forms.TabPage
  Friend WithEvents Crv8 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents PrtDialog As System.Windows.Forms.PrintDialog
  Friend WrkBTR As Boolean
  Friend WrkListZero As Boolean

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
Friend WithEvents TabGL As System.Windows.Forms.TabPage
Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents crv4 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents TabGLExempt As System.Windows.Forms.TabPage
Friend WithEvents TabMC As System.Windows.Forms.TabPage
Friend WithEvents TabExempt As System.Windows.Forms.TabPage
Friend WithEvents Crv5 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents TabMC2 As System.Windows.Forms.TabPage
Friend WithEvents Crv6 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents TabTotex As System.Windows.Forms.TabPage
Friend WithEvents TabTot As System.Windows.Forms.TabPage
Friend WithEvents Crv7 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.TabCtl1 = New System.Windows.Forms.TabControl
Me.TabGL = New System.Windows.Forms.TabPage
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabTot = New System.Windows.Forms.TabPage
Me.Crv7 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabTotex = New System.Windows.Forms.TabPage
Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabMC = New System.Windows.Forms.TabPage
Me.crv4 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabGLExempt = New System.Windows.Forms.TabPage
Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabExempt = New System.Windows.Forms.TabPage
Me.Crv5 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabMC2 = New System.Windows.Forms.TabPage
Me.Crv6 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabErrors = New System.Windows.Forms.TabPage
Me.Crv8 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.PrtDialog = New System.Windows.Forms.PrintDialog
Me.TabCtl1.SuspendLayout()
Me.TabGL.SuspendLayout()
Me.TabTot.SuspendLayout()
Me.TabTotex.SuspendLayout()
Me.TabMC.SuspendLayout()
Me.TabGLExempt.SuspendLayout()
Me.TabExempt.SuspendLayout()
Me.TabMC2.SuspendLayout()
Me.TabErrors.SuspendLayout()
Me.SuspendLayout()
'
'TabCtl1
'
Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabCtl1.Controls.Add(Me.TabGL)
Me.TabCtl1.Controls.Add(Me.TabTot)
Me.TabCtl1.Controls.Add(Me.TabTotex)
Me.TabCtl1.Controls.Add(Me.TabMC)
Me.TabCtl1.Controls.Add(Me.TabGLExempt)
Me.TabCtl1.Controls.Add(Me.TabExempt)
Me.TabCtl1.Controls.Add(Me.TabMC2)
Me.TabCtl1.Controls.Add(Me.TabErrors)
Me.TabCtl1.Location = New System.Drawing.Point(4, 4)
Me.TabCtl1.Name = "TabCtl1"
Me.TabCtl1.SelectedIndex = 0
Me.TabCtl1.Size = New System.Drawing.Size(680, 380)
Me.TabCtl1.TabIndex = 0
'
'TabGL
'
Me.TabGL.Controls.Add(Me.Crv1)
Me.TabGL.Location = New System.Drawing.Point(4, 22)
Me.TabGL.Name = "TabGL"
Me.TabGL.Size = New System.Drawing.Size(672, 354)
Me.TabGL.TabIndex = 0
Me.TabGL.Text = "Grand List"
Me.TabGL.UseVisualStyleBackColor = True
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
Me.Crv1.Location = New System.Drawing.Point(8, 8)
Me.Crv1.Name = "Crv1"
Me.Crv1.SelectionFormula = ""
Me.Crv1.Size = New System.Drawing.Size(656, 344)
Me.Crv1.TabIndex = 1
Me.Crv1.ViewTimeSelectionFormula = ""
'
'TabTot
'
Me.TabTot.Controls.Add(Me.Crv7)
Me.TabTot.Location = New System.Drawing.Point(4, 22)
Me.TabTot.Name = "TabTot"
Me.TabTot.Size = New System.Drawing.Size(672, 354)
Me.TabTot.TabIndex = 6
Me.TabTot.Text = "Totals"
Me.TabTot.UseVisualStyleBackColor = True
'
'Crv7
'
Me.Crv7.ActiveViewIndex = -1
Me.Crv7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.Crv7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Crv7.DisplayStatusBar = False
Me.Crv7.DisplayToolbar = False
Me.Crv7.Location = New System.Drawing.Point(8, 5)
Me.Crv7.Name = "Crv7"
Me.Crv7.SelectionFormula = ""
Me.Crv7.Size = New System.Drawing.Size(656, 344)
Me.Crv7.TabIndex = 2
Me.Crv7.ViewTimeSelectionFormula = ""
'
'TabTotex
'
Me.TabTotex.Controls.Add(Me.Crv2)
Me.TabTotex.Location = New System.Drawing.Point(4, 22)
Me.TabTotex.Name = "TabTotex"
Me.TabTotex.Size = New System.Drawing.Size(672, 354)
Me.TabTotex.TabIndex = 1
Me.TabTotex.Text = "Exemption Totals"
Me.TabTotex.UseVisualStyleBackColor = True
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
Me.Crv2.Location = New System.Drawing.Point(8, 8)
Me.Crv2.Name = "Crv2"
Me.Crv2.SelectionFormula = ""
Me.Crv2.Size = New System.Drawing.Size(656, 340)
Me.Crv2.TabIndex = 2
Me.Crv2.ViewTimeSelectionFormula = ""
'
'TabMC
'
Me.TabMC.Controls.Add(Me.crv4)
Me.TabMC.Location = New System.Drawing.Point(4, 22)
Me.TabMC.Name = "TabMC"
Me.TabMC.Size = New System.Drawing.Size(672, 354)
Me.TabMC.TabIndex = 3
Me.TabMC.Text = "Major Category Totals"
Me.TabMC.UseVisualStyleBackColor = True
'
'crv4
'
Me.crv4.ActiveViewIndex = -1
Me.crv4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.crv4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.crv4.DisplayStatusBar = False
Me.crv4.DisplayToolbar = False
Me.crv4.Location = New System.Drawing.Point(8, 7)
Me.crv4.Name = "crv4"
Me.crv4.SelectionFormula = ""
Me.crv4.Size = New System.Drawing.Size(656, 340)
Me.crv4.TabIndex = 3
Me.crv4.ViewTimeSelectionFormula = ""
'
'TabGLExempt
'
Me.TabGLExempt.Controls.Add(Me.Crv3)
Me.TabGLExempt.Location = New System.Drawing.Point(4, 22)
Me.TabGLExempt.Name = "TabGLExempt"
Me.TabGLExempt.Size = New System.Drawing.Size(672, 354)
Me.TabGLExempt.TabIndex = 2
Me.TabGLExempt.Text = "Exempt GL"
Me.TabGLExempt.UseVisualStyleBackColor = True
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
Me.Crv3.Location = New System.Drawing.Point(8, 8)
Me.Crv3.Name = "Crv3"
Me.Crv3.SelectionFormula = ""
Me.Crv3.Size = New System.Drawing.Size(656, 340)
Me.Crv3.TabIndex = 2
Me.Crv3.ViewTimeSelectionFormula = ""
'
'TabExempt
'
Me.TabExempt.Controls.Add(Me.Crv5)
Me.TabExempt.Location = New System.Drawing.Point(4, 22)
Me.TabExempt.Name = "TabExempt"
Me.TabExempt.Size = New System.Drawing.Size(672, 354)
Me.TabExempt.TabIndex = 4
Me.TabExempt.Text = "Exempt Totals"
Me.TabExempt.UseVisualStyleBackColor = True
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
Me.Crv5.Location = New System.Drawing.Point(8, 5)
Me.Crv5.Name = "Crv5"
Me.Crv5.SelectionFormula = ""
Me.Crv5.Size = New System.Drawing.Size(656, 344)
Me.Crv5.TabIndex = 2
Me.Crv5.ViewTimeSelectionFormula = ""
'
'TabMC2
'
Me.TabMC2.Controls.Add(Me.Crv6)
Me.TabMC2.Location = New System.Drawing.Point(4, 22)
Me.TabMC2.Name = "TabMC2"
Me.TabMC2.Size = New System.Drawing.Size(672, 354)
Me.TabMC2.TabIndex = 5
Me.TabMC2.Text = "Exempt Major Category Totals"
Me.TabMC2.UseVisualStyleBackColor = True
'
'Crv6
'
Me.Crv6.ActiveViewIndex = -1
Me.Crv6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.Crv6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Crv6.DisplayStatusBar = False
Me.Crv6.DisplayToolbar = False
Me.Crv6.Location = New System.Drawing.Point(8, 5)
Me.Crv6.Name = "Crv6"
Me.Crv6.SelectionFormula = ""
Me.Crv6.Size = New System.Drawing.Size(656, 344)
Me.Crv6.TabIndex = 2
Me.Crv6.ViewTimeSelectionFormula = ""
'
'TabErrors
'
Me.TabErrors.Controls.Add(Me.Crv8)
Me.TabErrors.Location = New System.Drawing.Point(4, 22)
Me.TabErrors.Name = "TabErrors"
Me.TabErrors.Size = New System.Drawing.Size(672, 354)
Me.TabErrors.TabIndex = 7
Me.TabErrors.Text = "Errors"
Me.TabErrors.UseVisualStyleBackColor = True
'
'Crv8
'
Me.Crv8.ActiveViewIndex = -1
Me.Crv8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.Crv8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Crv8.DisplayStatusBar = False
Me.Crv8.DisplayToolbar = False
Me.Crv8.Location = New System.Drawing.Point(8, 5)
Me.Crv8.Name = "Crv8"
Me.Crv8.SelectionFormula = ""
Me.Crv8.Size = New System.Drawing.Size(656, 344)
Me.Crv8.TabIndex = 3
Me.Crv8.ViewTimeSelectionFormula = ""
'
'FrmCrViewer
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(688, 386)
Me.Controls.Add(Me.TabCtl1)
Me.KeyPreview = True
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmCrViewer"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
Me.Text = "Report Viewer (Press ENTER to Print all)"
Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
Me.TabCtl1.ResumeLayout(False)
Me.TabGL.ResumeLayout(False)
Me.TabTot.ResumeLayout(False)
Me.TabTotex.ResumeLayout(False)
Me.TabMC.ResumeLayout(False)
Me.TabGLExempt.ResumeLayout(False)
Me.TabExempt.ResumeLayout(False)
Me.TabMC2.ResumeLayout(False)
Me.TabErrors.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub CrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  With WrkMargin
    .leftMargin = MyReportLeftMargin
    .rightMargin = 150
    .topMargin = MyReportTopMargin
    .bottomMargin = 150
  End With

  If WrkdsErr.Tables(0).Rows.Count = 0 Then
    TabCtl1.TabPages.Remove(TabErrors)
    TabCtl1.Refresh()
	Else
		TabCtl1.SelectTab(TabErrors)
		RunReportErrors()
  End If

  Select Case WrkType
  Case "M"
    TabCtl1.TabPages.Remove(TabExempt)
    TabCtl1.Refresh()
    RunReport1("MV")
    RunReport2("MV")
    RunReportTot()
    RunReportTotEx()
    RunReportTotMC()
    RunReportTotMC2()
  Case "P"
    TabCtl1.TabPages.Remove(TabExempt)
    TabCtl1.Refresh()
    RunReport1("PP")
    RunReport2("PP")
    RunReportTot()
    RunReportTotEx()
    RunReportTotMC()
    RunReportTotMC2()
	Case "R"
		If MyFrmTA212B.ChkPhaseIn.Checked Then
			RunReport1("RE-PI")
			RunReport2("RE-PI")
    Else
      If WrkListZero Then
        RunReport1("RE2")
        RunReport2("RE2")
      Else
        RunReport1("RE")
        RunReport2("RE")
      End If
    End If
    RunReportTot()
    RunReportTotEx()
    RunReportTotMC()
    RunReportTotMC2()
    RunReportTotExempt()
	Case "S"
    TabCtl1.TabPages.Remove(TabExempt)
    TabCtl1.Refresh()
    RunReport1("SU")
    RunReport2("SU")
    RunReportTot()
    RunReportTotEx()
    RunReportTotMC()
    RunReportTotMC2()
	End Select

  If MyFrmTA212B.ChkAddendum.Checked Then
    TabCtl1.TabPages.Remove(TabExempt)
    TabCtl1.TabPages.Remove(TabGLExempt)
    TabCtl1.TabPages.Remove(TabMC)
    TabCtl1.TabPages.Remove(TabMC2)
    TabCtl1.TabPages.Remove(TabTotex)
    TabCtl1.Refresh()
  End If

  TabCtl1.SelectedTab = TabGL

End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
  myreport8.Close()
  myreport8.Dispose()
End Sub
  Private Sub RunReport1(ByVal RptID As String)
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTA212" & RptID & ".rpt", myTOWN._TOWNBR)
   With myreport1
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
    End If
    .PrintOptions.ApplyPageMargins(WrkMargin)
    .SetDataSource(Wrkds1)
    If Not MyFrmTA212B.ChkAddendum.Checked Then
      .SetParameterValue("myreportTitle", "Grand List")
    Else
      .SetParameterValue("myreportTitle", "Addendum Grand List")
    End If
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyBTR", WrkBTR)
    .SetParameterValue("MyYear", MyFrmTA212B.TxtGLYear.Text)
   End With
   With Crv1
     .DisplayToolbar = True
     .ShowGroupTreeButton = True
     .ShowCloseButton = False
     .ShowCopyButton = False
     .ShowRefreshButton = False
     .ShowParameterPanelButton = False
     .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
     .ReportSource = myreport1
     .Zoom(75)
   End With

  End Sub
  Private Sub RunReport2(ByVal RptID As String)
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTA212" & RptID & ".rpt", myTOWN._TOWNBR)
   With myreport3
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
    End If
    .PrintOptions.ApplyPageMargins(WrkMargin)
    .SetDataSource(Wrkds2)
    .SetParameterValue("myreportTitle", "Exempt Grand List")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyBTR", WrkBTR)
    .SetParameterValue("MyYear", MyFrmTA212B.TxtGLYear.Text)
   End With
   With Crv3
     .DisplayToolbar = True
     .ShowGroupTreeButton = True
     .ShowCloseButton = False
     .ShowCopyButton = False
     .ShowRefreshButton = False
     .ShowParameterPanelButton = False
     .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
     .ReportSource = myreport3
     .Zoom(75)
   End With
  End Sub
  Private Sub RunReportTot()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTA212Tot.rpt", myTOWN._TOWNBR)
   With myreport7
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
    End If
    .PrintOptions.ApplyPageMargins(WrkMargin)
    .SetDataSource(WrkdsTot)
    If Not MyFrmTA212B.ChkAddendum.Checked Then
      .SetParameterValue("myreportTitle", "Grand List Final Totals")
    Else
      .SetParameterValue("myreportTitle", "Addendum Grand List Final Totals")
    End If
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyYear", MyFrmTA212B.TxtGLYear.Text)
    .SetParameterValue("MyTypeDesc", GetTXTypeDesc(WrkType))
    .SetParameterValue("MyBTR", WrkBTR)
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
  Private Sub RunReportTotEx()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTA212TotEx.rpt", myTOWN._TOWNBR)
   With myreport2
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
    End If
    .PrintOptions.ApplyPageMargins(WrkMargin)
    .SetDataSource(WrkdsTotEx)
    .SetParameterValue("myreportTitle", "Grand List Exemption Totals")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyYear", MyFrmTA212B.TxtGLYear.Text)
    .SetParameterValue("MyTypeDesc", GetTXTypeDesc(WrkType))
    .SetParameterValue("MyBTR", WrkBTR)
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
  Private Sub RunReportTotMC()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTA212TotMC.rpt", myTOWN._TOWNBR)
   With myreport4
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
    End If
    .PrintOptions.ApplyPageMargins(WrkMargin)
    .SetDataSource(WrkdsTotMC)
    .SetParameterValue("myreportTitle", "Grand List Major Category Totals")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyYear", MyFrmTA212B.TxtGLYear.Text)
    .SetParameterValue("MyTypeDesc", GetTXTypeDesc(WrkType))
    .SetParameterValue("MyBTR", WrkBTR)
   End With
   With crv4
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
  Private Sub RunReportTotMC2()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTA212TotMC.rpt", myTOWN._TOWNBR)
   With myreport6
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
    End If
    .PrintOptions.ApplyPageMargins(WrkMargin)
    .SetDataSource(WrkdsTotMC2)
    .SetParameterValue("myreportTitle", "Grand List Exempt Major Category Totals")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyYear", MyFrmTA212B.TxtGLYear.Text)
    .SetParameterValue("MyTypeDesc", GetTXTypeDesc(WrkType))
    .SetParameterValue("MyBTR", WrkBTR)
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
  Private Sub RunReportTotExempt()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTA212TotExempt.rpt", myTOWN._TOWNBR)
   With myreport5
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
    End If
    .PrintOptions.ApplyPageMargins(WrkMargin)
    .SetDataSource(WrkdsTotExempt)
    .SetParameterValue("myreportTitle", "Grand List Exempt Totals")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyYear", MyFrmTA212B.TxtGLYear.Text)
    .SetParameterValue("MyTypeDesc", GetTXTypeDesc(WrkType))
    .SetParameterValue("MyBTR", WrkBTR)
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
  Private Sub RunReportErrors()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTA212Err.rpt", myTOWN._TOWNBR)
   With myreport8
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
    End If
    .PrintOptions.ApplyPageMargins(WrkMargin)
    .SetDataSource(WrkdsErr)
    .SetParameterValue("myreportTitle", "Grand List")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyTypeDesc", GetTXTypeDesc(WrkType))
    .SetParameterValue("MyBTR", WrkBTR)
   End With
   With Crv8
     .DisplayToolbar = True
     .ShowGroupTreeButton = False
     .ShowCloseButton = False
     .ShowCopyButton = False
     .ShowRefreshButton = False
     .ShowParameterPanelButton = False
     .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
     .ReportSource = myreport8
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
        If MyReportLandscape Then
          .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
          .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        End If
        .PrintOptions.ApplyPageMargins(WrkMargin)
        .PrintOptions.PrinterName = WrkPrinter
        .PrintToPrinter(1, True, 0, 0)
      End With
      With myreport2
        If MyReportLandscape Then
          .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
          .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        End If
        .PrintOptions.ApplyPageMargins(WrkMargin)
        .PrintOptions.PrinterName = WrkPrinter
        .PrintToPrinter(1, True, 0, 0)
      End With
      With myreport3
        If MyReportLandscape Then
          .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
          .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        End If
        .PrintOptions.ApplyPageMargins(WrkMargin)
        .PrintOptions.PrinterName = WrkPrinter
        .PrintToPrinter(1, True, 0, 0)
      End With
      With myreport4
        If MyReportLandscape Then
          .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
          .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        End If
        .PrintOptions.ApplyPageMargins(WrkMargin)
        .PrintOptions.PrinterName = WrkPrinter
        .PrintToPrinter(1, True, 0, 0)
      End With
      If WrkType = "R" Then
        With myreport5
          If MyReportLandscape Then
            .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
            .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
          End If
          .PrintOptions.ApplyPageMargins(WrkMargin)
          .PrintOptions.PrinterName = WrkPrinter
          .PrintToPrinter(1, True, 0, 0)
        End With
      End If
      With myreport6
        If MyReportLandscape Then
          .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
          .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        End If
        .PrintOptions.ApplyPageMargins(WrkMargin)
        .PrintOptions.PrinterName = WrkPrinter
        .PrintToPrinter(1, True, 0, 0)
      End With
      With myreport7
        If MyReportLandscape Then
          .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
          .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        End If
        .PrintOptions.ApplyPageMargins(WrkMargin)
        .PrintOptions.PrinterName = WrkPrinter
        .PrintToPrinter(1, True, 0, 0)
      End With
      With myreport8
        If MyReportLandscape Then
          .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
          .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        End If
        .PrintOptions.ApplyPageMargins(WrkMargin)
        .PrintOptions.PrinterName = WrkPrinter
        .PrintToPrinter(1, True, 0, 0)
      End With
    End If
  End Sub

End Class






