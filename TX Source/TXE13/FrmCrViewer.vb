Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim WrkMargin As CrystalDecisions.Shared.PageMargins
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpListReason As System.Windows.Forms.TabPage
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpLetter As System.Windows.Forms.TabPage
  Friend WithEvents crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpListBank As System.Windows.Forms.TabPage
  Friend WithEvents crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend wrkds As DataSet = New DataSet
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TpListReason = New System.Windows.Forms.TabPage()
    Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpLetter = New System.Windows.Forms.TabPage()
    Me.crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpListBank = New System.Windows.Forms.TabPage()
    Me.crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabControl1.SuspendLayout()
    Me.TpListReason.SuspendLayout()
    Me.TpLetter.SuspendLayout()
    Me.TpListBank.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabControl1.Controls.Add(Me.TpListReason)
    Me.TabControl1.Controls.Add(Me.TpListBank)
    Me.TabControl1.Controls.Add(Me.TpLetter)
    Me.TabControl1.Location = New System.Drawing.Point(10, 5)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(644, 376)
    Me.TabControl1.TabIndex = 2
    '
    'TpListReason
    '
    Me.TpListReason.Controls.Add(Me.Crv1)
    Me.TpListReason.Location = New System.Drawing.Point(4, 22)
    Me.TpListReason.Name = "TpListReason"
    Me.TpListReason.Size = New System.Drawing.Size(636, 350)
    Me.TpListReason.TabIndex = 0
    Me.TpListReason.Text = "List (Reason)"
    Me.TpListReason.UseVisualStyleBackColor = True
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
    Me.Crv1.Size = New System.Drawing.Size(640, 352)
    Me.Crv1.TabIndex = 1
    Me.Crv1.ViewTimeSelectionFormula = ""
    '
    'TpLetter
    '
    Me.TpLetter.Controls.Add(Me.crv2)
    Me.TpLetter.Location = New System.Drawing.Point(4, 22)
    Me.TpLetter.Name = "TpLetter"
    Me.TpLetter.Size = New System.Drawing.Size(636, 350)
    Me.TpLetter.TabIndex = 1
    Me.TpLetter.Text = "Letter"
    Me.TpLetter.UseVisualStyleBackColor = True
    '
    'crv2
    '
    Me.crv2.ActiveViewIndex = -1
    Me.crv2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.crv2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.crv2.Cursor = System.Windows.Forms.Cursors.Default
    Me.crv2.DisplayStatusBar = False
    Me.crv2.DisplayToolbar = False
    Me.crv2.Location = New System.Drawing.Point(-2, -1)
    Me.crv2.Name = "crv2"
    Me.crv2.SelectionFormula = ""
    Me.crv2.Size = New System.Drawing.Size(640, 352)
    Me.crv2.TabIndex = 2
    Me.crv2.ViewTimeSelectionFormula = ""
    '
    'TpListBank
    '
    Me.TpListBank.Controls.Add(Me.crv3)
    Me.TpListBank.Location = New System.Drawing.Point(4, 22)
    Me.TpListBank.Name = "TpListBank"
    Me.TpListBank.Size = New System.Drawing.Size(636, 350)
    Me.TpListBank.TabIndex = 2
    Me.TpListBank.Text = "List (Bank)"
    Me.TpListBank.UseVisualStyleBackColor = True
    '
    'crv3
    '
    Me.crv3.ActiveViewIndex = -1
    Me.crv3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.crv3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.crv3.Cursor = System.Windows.Forms.Cursors.Default
    Me.crv3.DisplayStatusBar = False
    Me.crv3.DisplayToolbar = False
    Me.crv3.Location = New System.Drawing.Point(-2, -1)
    Me.crv3.Name = "crv3"
    Me.crv3.SelectionFormula = ""
    Me.crv3.Size = New System.Drawing.Size(640, 352)
    Me.crv3.TabIndex = 2
    Me.crv3.ViewTimeSelectionFormula = ""
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
    Me.TpListReason.ResumeLayout(False)
    Me.TpLetter.ResumeLayout(False)
    Me.TpListBank.ResumeLayout(False)
    Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    GetTXFMSTMT(" ")
    With WrkMargin
      .leftMargin = 500
      .rightMargin = 150
      .topMargin = 250
      .bottomMargin = 150
    End With
    RunReport1()
    RunReport2()
    RunReport3()
 End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport.Close()
  myreport.Dispose()
  myreport2.Close()
  myreport2.Dispose()
  myreport3.Close()
  myreport3.Dispose()
End Sub

  Private Sub RunReport1()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTXE13.rpt", myTOWN._TOWNBR)
   With myreport
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      .PrintOptions.ApplyPageMargins(WrkMargin)
    End If
    .SetDataSource(wrkds)
    If MyFrmTXE13B.RbAll.Checked Then
      .SetParameterValue("myreportTitle", "All Overpaid Tax List")
    Else
      .SetParameterValue("myreportTitle", "Balance Sheet Overpaid Tax List")
    End If
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTXE13B.TxtFromGLYear.Text))
    .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTXE13B.TxtToGLYear.Text))
    .SetParameterValue("MyAddress", MyFrmTXE13B.ChkAddress.Checked)
    .SetParameterValue("MyMin", MyUtils.CnvSng(MyFrmTXE13B.TxtMin.Text))
    .SetParameterValue("MyDist", MyUtils.CnvSng(MyFrmTXE13B.TxtDist.Text))
    .SetParameterValue("MyPhase", MyUtils.CnvSng(MyFrmTXE13B.TxtPhase.Text))
    If MyFrmTXE13B.DtPckStart.Checked Then
      .SetParameterValue("MyStart", Format(MyFrmTXE13B.DtPckStart.Value, "Short Date"))
    Else
      .SetParameterValue("MyStart", "")
    End If
    If MyFrmTXE13B.DtPckAsof.Checked Then
      .SetParameterValue("MyAsof", Format(MyFrmTXE13B.DtPckAsof.Value, "Short Date"))
    Else
      .SetParameterValue("MyAsof", "")
    End If
    .SetParameterValue("MyPhase", MyUtils.CnvSng(MyFrmTXE13B.TxtPhase.Text))
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

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTXE13Let.rpt", myTOWN._TOWNBR)
    With myreport2
      .Load(ReportPath)
      If MyReportLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        .PrintOptions.ApplyPageMargins(WrkMargin)
      End If
      .SetDataSource(wrkds)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyTitle", MyFrmTXE13B.TxtTitle.Text)
      .SetParameterValue("MyText", MyFrmTXE13B.TxtText.Text)
      .SetParameterValue("MyLine1", Trim(myTXFMSTMT._LINE1))
      .SetParameterValue("MyLine2", Trim(myTXFMSTMT._LINE2))
      .SetParameterValue("MyLine3", Trim(myTXFMSTMT._LINE3))
      .SetParameterValue("MyLine4", Trim(myTXFMSTMT._LINE4))
      .SetParameterValue("MyLine5", Trim(myTXFMSTMT._LINE5))
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
  Private Sub RunReport3()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtTXE13B.rpt", myTOWN._TOWNBR)
   With myreport3
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      .PrintOptions.ApplyPageMargins(WrkMargin)
    End If
    .SetDataSource(wrkds)
    If MyFrmTXE13B.RbAll.Checked Then
      .SetParameterValue("myreportTitle", "All Overpaid Tax List")
    Else
      .SetParameterValue("myreportTitle", "Balance Sheet Overpaid Tax List")
    End If
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyFromGLYear", MyUtils.CnvSng(MyFrmTXE13B.TxtFromGLYear.Text))
    .SetParameterValue("MyToGLYear", MyUtils.CnvSng(MyFrmTXE13B.TxtToGLYear.Text))
    .SetParameterValue("MyAddress", MyFrmTXE13B.ChkAddress.Checked)
    .SetParameterValue("MyMin", MyUtils.CnvSng(MyFrmTXE13B.TxtMin.Text))
    .SetParameterValue("MyDist", MyUtils.CnvSng(MyFrmTXE13B.TxtDist.Text))
    .SetParameterValue("MyPhase", MyUtils.CnvSng(MyFrmTXE13B.TxtPhase.Text))
    If MyFrmTXE13B.DtPckStart.Checked Then
      .SetParameterValue("MyStart", Format(MyFrmTXE13B.DtPckStart.Value, "Short Date"))
    Else
      .SetParameterValue("MyStart", "")
    End If
    If MyFrmTXE13B.DtPckAsof.Checked Then
      .SetParameterValue("MyAsof", Format(MyFrmTXE13B.DtPckAsof.Value, "Short Date"))
    Else
      .SetParameterValue("MyAsof", "")
    End If
    .SetParameterValue("MyPhase", MyUtils.CnvSng(MyFrmTXE13B.TxtPhase.Text))
   End With
   With crv3
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
  Public Sub GetTXFMSTMT(ByVal WrkType As String)
    myTXFMSTMT = New TXFMSTMT.mydata(MyDBConnect)

    myTXFMSTMT.GetOneRecordP(WrkType)
  End Sub
End Class






