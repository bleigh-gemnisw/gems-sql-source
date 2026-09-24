Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend wrkds As DataSet = New DataSet
  Friend wrkds2 As DataSet = New DataSet
  Friend WrkRefunds As Boolean
  Friend WrkRefundTotal As Decimal
  Friend WrkRefundTotalOther As Decimal
  Friend WrkAdjust As Boolean
  Friend WrkAdjustTotal As Decimal
  Friend WrkAdjustTotalOther As Decimal
  Friend WrkShowAdjust As Boolean
  Friend WithEvents TpSuppl As System.Windows.Forms.TabPage
  Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WrkGrandTotal As Decimal

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
Friend WithEvents TpRegular As System.Windows.Forms.TabPage
Friend WithEvents TpOther As System.Windows.Forms.TabPage
Friend WithEvents crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.TabCtl1 = New System.Windows.Forms.TabControl
Me.TpRegular = New System.Windows.Forms.TabPage
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpOther = New System.Windows.Forms.TabPage
Me.crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpSuppl = New System.Windows.Forms.TabPage
Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabCtl1.SuspendLayout()
Me.TpRegular.SuspendLayout()
Me.TpOther.SuspendLayout()
Me.TpSuppl.SuspendLayout()
Me.SuspendLayout()
'
'TabCtl1
'
Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabCtl1.Controls.Add(Me.TpRegular)
Me.TabCtl1.Controls.Add(Me.TpOther)
Me.TabCtl1.Controls.Add(Me.TpSuppl)
Me.TabCtl1.Location = New System.Drawing.Point(12, 4)
Me.TabCtl1.Name = "TabCtl1"
Me.TabCtl1.SelectedIndex = 0
Me.TabCtl1.Size = New System.Drawing.Size(644, 376)
Me.TabCtl1.TabIndex = 1
'
'TpRegular
'
Me.TpRegular.Controls.Add(Me.Crv1)
Me.TpRegular.Location = New System.Drawing.Point(4, 22)
Me.TpRegular.Name = "TpRegular"
Me.TpRegular.Size = New System.Drawing.Size(636, 350)
Me.TpRegular.TabIndex = 0
Me.TpRegular.Text = "Regular"
Me.TpRegular.UseVisualStyleBackColor = True
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
Me.Crv1.Size = New System.Drawing.Size(640, 352)
Me.Crv1.TabIndex = 1
Me.Crv1.ViewTimeSelectionFormula = ""
'
'TpOther
'
Me.TpOther.Controls.Add(Me.crv2)
Me.TpOther.Location = New System.Drawing.Point(4, 22)
Me.TpOther.Name = "TpOther"
Me.TpOther.Size = New System.Drawing.Size(636, 350)
Me.TpOther.TabIndex = 1
Me.TpOther.Text = "Other"
Me.TpOther.UseVisualStyleBackColor = True
'
'crv2
'
Me.crv2.ActiveViewIndex = -1
Me.crv2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.crv2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.crv2.DisplayStatusBar = False
Me.crv2.DisplayToolbar = False
Me.crv2.Location = New System.Drawing.Point(-2, -1)
Me.crv2.Name = "crv2"
Me.crv2.SelectionFormula = ""
Me.crv2.Size = New System.Drawing.Size(640, 352)
Me.crv2.TabIndex = 2
Me.crv2.ViewTimeSelectionFormula = ""
'
'TpSuppl
'
Me.TpSuppl.Controls.Add(Me.Crv3)
Me.TpSuppl.Location = New System.Drawing.Point(4, 22)
Me.TpSuppl.Name = "TpSuppl"
Me.TpSuppl.Size = New System.Drawing.Size(636, 350)
Me.TpSuppl.TabIndex = 2
Me.TpSuppl.Text = "Regular split SUPP"
Me.TpSuppl.UseVisualStyleBackColor = True
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
Me.Crv3.Location = New System.Drawing.Point(-2, -1)
Me.Crv3.Name = "Crv3"
Me.Crv3.SelectionFormula = ""
Me.Crv3.Size = New System.Drawing.Size(640, 352)
Me.Crv3.TabIndex = 2
Me.Crv3.ViewTimeSelectionFormula = ""
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
Me.TpRegular.ResumeLayout(False)
Me.TpOther.ResumeLayout(False)
Me.TpSuppl.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If wrkds.Tables(0).Rows.Count = 0 Then
      TabCtl1.TabPages.Remove(TpRegular)
      TabCtl1.TabPages.Remove(TpSuppl)
    Else
      RunReport1()
      RunReport3()
    End If
    If wrkds2.Tables(0).Rows.Count = 0 And wrkds.Tables(0).Rows.Count > 0 Then
      TabCtl1.TabPages.Remove(TpOther)
    Else
      RunReport2()
    End If
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
   ReportPath = MyUtils.GetReportPath("PrtTXE051.rpt", myTOWN._TOWNBR)
   With myreport
    .Load(ReportPath)
    .SetDataSource(wrkds)
    .SetParameterValue("myreportTitle", "Collectors report to the Treasurer")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyFromDate", MyFrmTXE05B.DtPckFrom.Value)
    .SetParameterValue("MyToDate", MyFrmTXE05B.DtPckTo.Value)
    .SetParameterValue("MyRefunds", WrkRefunds)
    .SetParameterValue("MyRefundTotal", WrkRefundTotal)
		.SetParameterValue("MyCollectorName", Trim(myTOWN._COLCTR))
    .SetParameterValue("MyAdjust", WrkAdjust)
    .SetParameterValue("MyAdjustTotal", WrkAdjustTotal)
    .SetParameterValue("MyShowAdjust", WrkShowAdjust)
		.SetParameterValue("MyTypes", MyFrmTXE05B.TxtTypes.Text)
    .SetParameterValue("MyDist", MyUtils.CnvSng(MyFrmTXE05B.TxtDist.Text))
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
   ReportPath = MyUtils.GetReportPath("PrtTXE052.rpt", myTOWN._TOWNBR)
   With myreport2
    .Load(ReportPath)
    .SetDataSource(wrkds2)
    .SetParameterValue("myreportTitle", "Collectors report to the Treasurer")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyFromDate", MyFrmTXE05B.DtPckFrom.Value)
    .SetParameterValue("MyToDate", MyFrmTXE05B.DtPckTo.Value)
    .SetParameterValue("MyRefunds", WrkRefunds)
    .SetParameterValue("MyRefundTotal", WrkRefundTotalOther)
    .SetParameterValue("MyGrandTotal", WrkGrandTotal)
    .SetParameterValue("MyAdjust", WrkAdjust)
    .SetParameterValue("MyAdjustTotal", WrkAdjustTotalOther)
    .SetParameterValue("MyShowAdjust", WrkShowAdjust)
    .SetParameterValue("MyTypes", MyFrmTXE05B.TxtTypes.Text)
    .SetParameterValue("MyOtherBreak", MyFrmTXE05B.ChkOtherBreak.Checked)
    .SetParameterValue("MyDist", MyUtils.CnvSng(MyFrmTXE05B.TxtDist.Text))
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
   ReportPath = MyUtils.GetReportPath("PrtTXE053.rpt", myTOWN._TOWNBR)
   With myreport3
    .Load(ReportPath)
    .SetDataSource(wrkds)
    .SetParameterValue("myreportTitle", "Collectors report to the Treasurer")
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyFromDate", MyFrmTXE05B.DtPckFrom.Value)
    .SetParameterValue("MyToDate", MyFrmTXE05B.DtPckTo.Value)
    .SetParameterValue("MyRefunds", WrkRefunds)
    .SetParameterValue("MyRefundTotal", WrkRefundTotal)
    .SetParameterValue("MyCollectorName", Trim(myTOWN._COLCTR))
    .SetParameterValue("MyAdjust", WrkAdjust)
    .SetParameterValue("MyAdjustTotal", WrkAdjustTotal)
    .SetParameterValue("MyShowAdjust", WrkShowAdjust)
    .SetParameterValue("MyTypes", MyFrmTXE05B.TxtTypes.Text)
    .SetParameterValue("MyDist", MyUtils.CnvSng(MyFrmTXE05B.TxtDist.Text))
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
End Class






