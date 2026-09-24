Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim WrkMargin As CrystalDecisions.Shared.PageMargins
  Dim WrkAltFormID As String
  Dim myTXFMSTMT As TXFMSTMT.myData
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpBlanket As System.Windows.Forms.TabPage
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpIndividual As System.Windows.Forms.TabPage
  Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend wrkds As DataSet = New DataSet
  Friend wrkds2 As DataSet = New DataSet

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
Me.TabControl1 = New System.Windows.Forms.TabControl
Me.TpBlanket = New System.Windows.Forms.TabPage
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpIndividual = New System.Windows.Forms.TabPage
Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabControl1.SuspendLayout()
Me.TpBlanket.SuspendLayout()
Me.TpIndividual.SuspendLayout()
Me.SuspendLayout()
'
'TabControl1
'
Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabControl1.Controls.Add(Me.TpBlanket)
Me.TabControl1.Controls.Add(Me.TpIndividual)
Me.TabControl1.Location = New System.Drawing.Point(10, 5)
Me.TabControl1.Name = "TabControl1"
Me.TabControl1.SelectedIndex = 0
Me.TabControl1.Size = New System.Drawing.Size(644, 376)
Me.TabControl1.TabIndex = 3
'
'TpBlanket
'
Me.TpBlanket.Controls.Add(Me.Crv1)
Me.TpBlanket.Location = New System.Drawing.Point(4, 22)
Me.TpBlanket.Name = "TpBlanket"
Me.TpBlanket.Size = New System.Drawing.Size(636, 350)
Me.TpBlanket.TabIndex = 2
Me.TpBlanket.Text = "Blanket"
Me.TpBlanket.UseVisualStyleBackColor = True
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
Me.Crv1.Location = New System.Drawing.Point(-2, -1)
Me.Crv1.Name = "Crv1"
Me.Crv1.SelectionFormula = ""
Me.Crv1.Size = New System.Drawing.Size(640, 352)
Me.Crv1.TabIndex = 2
Me.Crv1.ViewTimeSelectionFormula = ""
'
'TpIndividual
'
Me.TpIndividual.Controls.Add(Me.Crv2)
Me.TpIndividual.Location = New System.Drawing.Point(4, 22)
Me.TpIndividual.Name = "TpIndividual"
Me.TpIndividual.Size = New System.Drawing.Size(636, 350)
Me.TpIndividual.TabIndex = 0
Me.TpIndividual.Text = "Individual"
Me.TpIndividual.UseVisualStyleBackColor = True
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
Me.TpBlanket.ResumeLayout(False)
Me.TpIndividual.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  WrkAltFormID = MyFrmTXE42B.TxtAltFormID.Text
  GetTXFMSTMT(WrkAltFormID)
  If Trim(myTXFMSTMT._LINE1) = String.Empty Then
    GetTXFMSTMT(" ")
  End If

  With WrkMargin
    .leftMargin = 150
    .rightMargin = 150
    .topMargin = 150
    .bottomMargin = 150
  End With
  If MyFrmTXE42B.RbBlanket.Checked Then
    TabControl1.TabPages.Remove(TpIndividual)
    RunReport1()
  Else
    TabControl1.TabPages.Remove(TpBlanket)
    RunReport2()
  End If
 End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport.Close()
  myreport.Dispose()
  myreport2.Close()
  myreport2.Dispose()
End Sub

  Private Sub RunReport1()
   Dim ReportName As String
   Dim ReportPath As String
   Dim WrkExists As Boolean

   Me.Text = "Report Viewer"
   ReportName = "PrtTXE42" & WrkAltFormID & ".rpt"
   ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
   If WrkAltFormID <> "" Then
     WrkExists = MyUtils.CheckFileExists(ReportPath)
     If Not WrkExists Then
       MsgBox("Close and retry with correct Form ID", MsgBoxStyle.Critical, "Cannot find report")
       Exit Sub
     End If
   End If
   With myreport
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      .PrintOptions.ApplyPageMargins(WrkMargin)
    End If
    .SetDataSource(wrkds)
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyTownCounty", Trim(myTOWN._COUNTY))
    .SetParameterValue("MyPayTo", Trim(myTXFMSTMT._PAYTO))
    .SetParameterValue("MyTitle", Trim(myTXFMSTMT._TITLE))
    .SetParameterValue("MyClerk", Trim(myTXFMSTMT._CLERK))
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
   Dim ReportName As String
   Dim ReportPath As String
   Dim WrkExists As Boolean

   Me.Text = "Report Viewer"
   ReportName = "PrtTXA09M" & WrkAltFormID & ".rpt"
   ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
   If WrkAltFormID <> "" Then
     WrkExists = MyUtils.CheckFileExists(ReportPath)
     If Not WrkExists Then
       MsgBox("Close and retry with correct Form ID", MsgBoxStyle.Critical, "Cannot find report")
       Exit Sub
     End If
   End If
   With myreport2
    .Load(ReportPath)
    If MyReportLandscape Then
      .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
      .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
      .PrintOptions.ApplyPageMargins(WrkMargin)
    End If
    .SetDataSource(wrkds2)
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyTownCounty", Trim(myTOWN._COUNTY))
    .SetParameterValue("MyPayTo", Trim(myTXFMSTMT._PAYTO))
    .SetParameterValue("MyTitle", Trim(myTXFMSTMT._TITLE))
    .SetParameterValue("MySigned", Trim(myTXFMSTMT._SIGNED))
    .SetParameterValue("MyClerk", Trim(myTXFMSTMT._CLERK))
    .SetParameterValue("MyTownShort", Trim(myTXFMSTMT._TWNAME))
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
Public Sub GetTXFMSTMT(ByVal WrkType As String)
  myTXFMSTMT = New TXFMSTMT.mydata(MyDBConnect)

  myTXFMSTMT.GetOneRecordP(WrkType)
End Sub

End Class






