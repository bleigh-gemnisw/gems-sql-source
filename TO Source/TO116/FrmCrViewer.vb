Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim myreport3 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend wrkds As DataSet = New DataSet
  Friend wrkds2 As DataSet = New DataSet
  Friend wrkds3 As DataSet = New DataSet
  Friend WrkCodea As Integer
  Friend WrkCodeb As Integer
  Friend WithEvents TabCtl1 As System.Windows.Forms.TabControl
  Friend WithEvents Tab15a As System.Windows.Forms.TabPage
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents Tab15b As System.Windows.Forms.TabPage
  Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents TabExemptions As System.Windows.Forms.TabPage
  Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer

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
Me.Tab15a = New System.Windows.Forms.TabPage
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.Tab15b = New System.Windows.Forms.TabPage
Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabExemptions = New System.Windows.Forms.TabPage
Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.TabCtl1.SuspendLayout()
Me.Tab15a.SuspendLayout()
Me.Tab15b.SuspendLayout()
Me.TabExemptions.SuspendLayout()
Me.SuspendLayout()
'
'TabCtl1
'
Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TabCtl1.Controls.Add(Me.Tab15a)
Me.TabCtl1.Controls.Add(Me.Tab15b)
Me.TabCtl1.Controls.Add(Me.TabExemptions)
Me.TabCtl1.Location = New System.Drawing.Point(4, 3)
Me.TabCtl1.Name = "TabCtl1"
Me.TabCtl1.SelectedIndex = 0
Me.TabCtl1.Size = New System.Drawing.Size(656, 380)
Me.TabCtl1.TabIndex = 1
'
'Tab15a
'
Me.Tab15a.Controls.Add(Me.Crv1)
Me.Tab15a.Location = New System.Drawing.Point(4, 22)
Me.Tab15a.Name = "Tab15a"
Me.Tab15a.Size = New System.Drawing.Size(648, 354)
Me.Tab15a.TabIndex = 0
Me.Tab15a.Text = "Code 15a"
Me.Tab15a.UseVisualStyleBackColor = True
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
Me.Crv1.Size = New System.Drawing.Size(632, 344)
Me.Crv1.TabIndex = 1
Me.Crv1.ViewTimeSelectionFormula = ""
'
'Tab15b
'
Me.Tab15b.Controls.Add(Me.Crv2)
Me.Tab15b.Location = New System.Drawing.Point(4, 22)
Me.Tab15b.Name = "Tab15b"
Me.Tab15b.Size = New System.Drawing.Size(648, 354)
Me.Tab15b.TabIndex = 1
Me.Tab15b.Text = "Code 15b"
Me.Tab15b.UseVisualStyleBackColor = True
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
Me.Crv2.Size = New System.Drawing.Size(632, 340)
Me.Crv2.TabIndex = 2
Me.Crv2.ViewTimeSelectionFormula = ""
'
'TabExemptions
'
Me.TabExemptions.Controls.Add(Me.Crv3)
Me.TabExemptions.Location = New System.Drawing.Point(4, 22)
Me.TabExemptions.Name = "TabExemptions"
Me.TabExemptions.Size = New System.Drawing.Size(648, 354)
Me.TabExemptions.TabIndex = 5
Me.TabExemptions.Text = "R Exemptions"
Me.TabExemptions.UseVisualStyleBackColor = True
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
Me.Crv3.Location = New System.Drawing.Point(8, 5)
Me.Crv3.Name = "Crv3"
Me.Crv3.SelectionFormula = ""
Me.Crv3.Size = New System.Drawing.Size(632, 344)
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
Me.Tab15a.ResumeLayout(False)
Me.Tab15b.ResumeLayout(False)
Me.TabExemptions.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If WrkCodea > 0 Then
      RunReport1()
    Else
      TabCtl1.TabPages.Remove(Tab15a)
    End If
    If WrkCodeb > 0 Then
      RunReport2()
    Else
      TabCtl1.TabPages.Remove(Tab15b)
    End If
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
   ReportPath = MyUtils.GetReportPath("PrtTO1161.rpt", myTOWN._TOWNBR)
   With myreport
    .Load(ReportPath)
    .SetDataSource(wrkds)
    .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyTownNum", myTOWN._TOWNBR)
    .SetParameterValue("MyYear", MyUtils.CnvSng(MyFrmTO116B.TxtGLYear.Text))
    .SetParameterValue("MyCode", WrkCodea)
    .SetParameterValue("MyDist", MyFrmTO116B.TxtDist.Text)
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
   ReportPath = MyUtils.GetReportPath("PrtTO1162.rpt", myTOWN._TOWNBR)
   With myreport2
    .Load(ReportPath)
    .SetDataSource(wrkds2)
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyTownNum", myTOWN._TOWNBR)
    .SetParameterValue("MyYear", MyUtils.CnvSng(MyFrmTO116B.TxtGLYear.Text))
    .SetParameterValue("MyCode", WrkCodeb)
    .SetParameterValue("MyDist", MyFrmTO116B.TxtDist.Text)
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
   ReportPath = MyUtils.GetReportPath("PrtTO1163.rpt", myTOWN._TOWNBR)
   With myreport3
    .Load(ReportPath)
    .SetDataSource(wrkds3)
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyTownNum", myTOWN._TOWNBR)
    .SetParameterValue("MyYear", MyUtils.CnvSng(MyFrmTO116B.TxtGLYear.Text))
    .SetParameterValue("MyDist", MyFrmTO116B.TxtDist.Text)
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

Private Sub Crv1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

End Sub
End Class






