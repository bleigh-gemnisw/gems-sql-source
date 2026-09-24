Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport4 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport5 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport6 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend WithEvents TabCtl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpChecks As System.Windows.Forms.TabPage
  Friend WithEvents Crv4 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpOverflow As System.Windows.Forms.TabPage
  Friend WithEvents crv5 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpRegisterCheck As System.Windows.Forms.TabPage
  Friend WithEvents crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpRegisterDept As System.Windows.Forms.TabPage
  Friend WithEvents TpRegisterFund As System.Windows.Forms.TabPage
  Friend WithEvents crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TpGL As System.Windows.Forms.TabPage
  Friend WithEvents crv6 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WrkError As Boolean
  Friend wrkds As DataSet = New DataSet
  Friend wrkdsChk As DataSet = New DataSet
  Friend wrkdsChk2 As DataSet = New DataSet
  Friend wrkdsChkOvr As DataSet = New DataSet
  Friend wrkdsGL As DataSet = New DataSet
  Friend WrkBank As String

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
Me.TabCtl1 = New System.Windows.Forms.TabControl
Me.TpRegisterCheck = New System.Windows.Forms.TabPage
Me.crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpRegisterFund = New System.Windows.Forms.TabPage
Me.crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpRegisterDept = New System.Windows.Forms.TabPage
Me.crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpChecks = New System.Windows.Forms.TabPage
Me.Crv4 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpOverflow = New System.Windows.Forms.TabPage
Me.crv5 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TpGL = New System.Windows.Forms.TabPage
Me.crv6 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabCtl1.SuspendLayout()
Me.TpRegisterCheck.SuspendLayout()
Me.TpRegisterFund.SuspendLayout()
Me.TpRegisterDept.SuspendLayout()
Me.TpChecks.SuspendLayout()
Me.TpOverflow.SuspendLayout()
Me.TpGL.SuspendLayout()
Me.SuspendLayout()
'
'TabCtl1
'
Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabCtl1.Controls.Add(Me.TpRegisterCheck)
Me.TabCtl1.Controls.Add(Me.TpRegisterFund)
Me.TabCtl1.Controls.Add(Me.TpRegisterDept)
Me.TabCtl1.Controls.Add(Me.TpChecks)
Me.TabCtl1.Controls.Add(Me.TpOverflow)
Me.TabCtl1.Controls.Add(Me.TpGL)
Me.TabCtl1.Location = New System.Drawing.Point(-1, 0)
Me.TabCtl1.Name = "TabCtl1"
Me.TabCtl1.SelectedIndex = 0
Me.TabCtl1.Size = New System.Drawing.Size(666, 388)
Me.TabCtl1.TabIndex = 2
'
'TpRegisterCheck
'
Me.TpRegisterCheck.Controls.Add(Me.crv1)
Me.TpRegisterCheck.Location = New System.Drawing.Point(4, 22)
Me.TpRegisterCheck.Name = "TpRegisterCheck"
Me.TpRegisterCheck.Size = New System.Drawing.Size(658, 362)
Me.TpRegisterCheck.TabIndex = 3
Me.TpRegisterCheck.Text = "Register by Check"
Me.TpRegisterCheck.UseVisualStyleBackColor = True
'
'crv1
'
Me.crv1.ActiveViewIndex = -1
Me.crv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.crv1.DisplayStatusBar = False
Me.crv1.DisplayToolbar = False
Me.crv1.Location = New System.Drawing.Point(-2, -1)
Me.crv1.Name = "crv1"
Me.crv1.SelectionFormula = ""
Me.crv1.Size = New System.Drawing.Size(662, 364)
Me.crv1.TabIndex = 2
Me.crv1.ViewTimeSelectionFormula = ""
'
'TpRegisterFund
'
Me.TpRegisterFund.Controls.Add(Me.crv2)
Me.TpRegisterFund.Location = New System.Drawing.Point(4, 22)
Me.TpRegisterFund.Name = "TpRegisterFund"
Me.TpRegisterFund.Size = New System.Drawing.Size(658, 362)
Me.TpRegisterFund.TabIndex = 5
Me.TpRegisterFund.Text = "Register by Fund"
Me.TpRegisterFund.UseVisualStyleBackColor = True
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
Me.crv2.Size = New System.Drawing.Size(662, 364)
Me.crv2.TabIndex = 3
Me.crv2.ViewTimeSelectionFormula = ""
'
'TpRegisterDept
'
Me.TpRegisterDept.Controls.Add(Me.crv3)
Me.TpRegisterDept.Location = New System.Drawing.Point(4, 22)
Me.TpRegisterDept.Name = "TpRegisterDept"
Me.TpRegisterDept.Size = New System.Drawing.Size(658, 362)
Me.TpRegisterDept.TabIndex = 4
Me.TpRegisterDept.Text = "Register by Dept"
Me.TpRegisterDept.UseVisualStyleBackColor = True
'
'crv3
'
Me.crv3.ActiveViewIndex = -1
Me.crv3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.crv3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.crv3.DisplayStatusBar = False
Me.crv3.DisplayToolbar = False
Me.crv3.Location = New System.Drawing.Point(-2, -1)
Me.crv3.Name = "crv3"
Me.crv3.SelectionFormula = ""
Me.crv3.Size = New System.Drawing.Size(662, 364)
Me.crv3.TabIndex = 3
Me.crv3.ViewTimeSelectionFormula = ""
'
'TpChecks
'
Me.TpChecks.Controls.Add(Me.Crv4)
Me.TpChecks.Location = New System.Drawing.Point(4, 22)
Me.TpChecks.Name = "TpChecks"
Me.TpChecks.Size = New System.Drawing.Size(658, 362)
Me.TpChecks.TabIndex = 0
Me.TpChecks.Text = "Checks"
Me.TpChecks.UseVisualStyleBackColor = True
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
Me.Crv4.Location = New System.Drawing.Point(-2, 2)
Me.Crv4.Name = "Crv4"
Me.Crv4.SelectionFormula = ""
Me.Crv4.Size = New System.Drawing.Size(662, 364)
Me.Crv4.TabIndex = 1
Me.Crv4.ViewTimeSelectionFormula = ""
'
'TpOverflow
'
Me.TpOverflow.Controls.Add(Me.crv5)
Me.TpOverflow.Location = New System.Drawing.Point(4, 22)
Me.TpOverflow.Name = "TpOverflow"
Me.TpOverflow.Size = New System.Drawing.Size(658, 362)
Me.TpOverflow.TabIndex = 2
Me.TpOverflow.Text = "Overflow"
Me.TpOverflow.UseVisualStyleBackColor = True
'
'crv5
'
Me.crv5.ActiveViewIndex = -1
Me.crv5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.crv5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.crv5.DisplayStatusBar = False
Me.crv5.DisplayToolbar = False
Me.crv5.Location = New System.Drawing.Point(-2, -1)
Me.crv5.Name = "crv5"
Me.crv5.SelectionFormula = ""
Me.crv5.Size = New System.Drawing.Size(662, 364)
Me.crv5.TabIndex = 2
Me.crv5.ViewTimeSelectionFormula = ""
'
'TpGL
'
Me.TpGL.Controls.Add(Me.crv6)
Me.TpGL.Location = New System.Drawing.Point(4, 22)
Me.TpGL.Name = "TpGL"
Me.TpGL.Size = New System.Drawing.Size(658, 362)
Me.TpGL.TabIndex = 6
Me.TpGL.Text = "G/L Entries"
Me.TpGL.UseVisualStyleBackColor = True
'
'crv6
'
Me.crv6.ActiveViewIndex = -1
Me.crv6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.crv6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.crv6.DisplayStatusBar = False
Me.crv6.DisplayToolbar = False
Me.crv6.Location = New System.Drawing.Point(-2, -1)
Me.crv6.Name = "crv6"
Me.crv6.SelectionFormula = ""
Me.crv6.Size = New System.Drawing.Size(662, 364)
Me.crv6.TabIndex = 3
Me.crv6.ViewTimeSelectionFormula = ""
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
Me.TpRegisterCheck.ResumeLayout(False)
Me.TpRegisterFund.ResumeLayout(False)
Me.TpRegisterDept.ResumeLayout(False)
Me.TpChecks.ResumeLayout(False)
Me.TpOverflow.ResumeLayout(False)
Me.TpGL.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    If WrkError Then
      RunReport1()
      TabCtl1.TabPages.Remove(TpRegisterDept)
      TabCtl1.TabPages.Remove(TpRegisterFund)
      TabCtl1.TabPages.Remove(TpChecks)
      TabCtl1.TabPages.Remove(TpGL)
      TabCtl1.TabPages.Remove(TpOverflow)
      Exit Sub
    End If

    wrkdsChk.Merge(wrkdsChk2)
    If MyCheckType = "R" Then
		RunReport1()
		RunReport2()
		RunReport3()
		RunReport6()
	Else
		TabCtl1.TabPages.Remove(TpRegisterCheck)
		TabCtl1.TabPages.Remove(TpRegisterDept)
		TabCtl1.TabPages.Remove(TpRegisterFund)
		TabCtl1.TabPages.Remove(TpGL)
	End If

	RunReport4()
	If wrkdsChkOvr.Tables(0).Rows.Count > 0 Then
		RunReport5()
	Else
		TabCtl1.TabPages.Remove(TpOverflow)
	End If

 End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport.Close()
  myreport.Dispose()
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

	If MyCheckType = "R" Then
		MyFrmAP403B.Show()
	Else
		MyFrmAP403C.Show()
	End If
End Sub
  Private Sub RunReport1()
    Dim ReportPath As String

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtAP403.rpt", myTOWN._TOWNBR)
    With myreport
      .Load(ReportPath)
      .SetDataSource(wrkds)
      .SetParameterValue("MyReportTitle", "Check Register by Check")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyBank", WrkBank)
      .SetParameterValue("MyError", WrkError)
    End With
    With crv1
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
   ReportPath = MyUtils.GetReportPath("PrtAP403B.rpt", myTOWN._TOWNBR)
    With myreport2
    .Load(ReportPath)
    .SetDataSource(wrkds)
    .SetParameterValue("MyReportTitle", "Check Register by Fund")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyBank", WrkBank)
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

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtAP403C.rpt", myTOWN._TOWNBR)
    With myreport3
    .Load(ReportPath)
    .SetDataSource(wrkds)
    .SetParameterValue("MyReportTitle", "Check Register by Dept")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyBank", WrkBank)
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
  Private Sub RunReport4()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   If MyFrmAP403B.TxtAltForm.Text = "" Then
     ReportPath = MyUtils.GetReportPath("PrtAPLECHK.rpt", myTOWN._TOWNBR)
   Else
     ReportPath = MyUtils.GetReportPath("PrtAPLECHK_" & MyFrmAP403B.TxtAltForm.Text & ".rpt", myTOWN._TOWNBR)
   End If
    With myreport4
    .Load(ReportPath)
    .SetDataSource(wrkdsChk)
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    If MyCheckType = "M" Then
      .SetParameterValue("MyManualCheckNoSig", MyManualCheckNoSig)
    Else
      .SetParameterValue("MyManualCheckNoSig", False)
    End If
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

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtAPLECHKB.rpt", myTOWN._TOWNBR)
    With myreport5
    .Load(ReportPath)
    .SetDataSource(wrkdsChkOvr)
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
	 End With
   With crv5
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

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtAP403D.rpt", myTOWN._TOWNBR)
    With myreport6
    .Load(ReportPath)
    .SetDataSource(wrkdsGL)
    .SetParameterValue("MyReportTitle", "G/L Entries to be Posted")
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
	 End With
   With crv6
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
End Class


  

