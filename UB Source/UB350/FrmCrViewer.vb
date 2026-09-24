Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Friend WithEvents TpSkip As System.Windows.Forms.TabPage
  Friend WithEvents Crv3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend Wrkds1 As DataSet
  Friend Wrkds2 As DataSet
  Friend Wrkds3 As DataSet

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
Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
Friend WithEvents TpUpdate As System.Windows.Forms.TabPage
Friend WithEvents TpAdd As System.Windows.Forms.TabPage
Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TpUpdate = New System.Windows.Forms.TabPage()
    Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpAdd = New System.Windows.Forms.TabPage()
    Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TpSkip = New System.Windows.Forms.TabPage()
    Me.Crv3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.TabControl1.SuspendLayout()
    Me.TpUpdate.SuspendLayout()
    Me.TpAdd.SuspendLayout()
    Me.TpSkip.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabControl1.Controls.Add(Me.TpUpdate)
    Me.TabControl1.Controls.Add(Me.TpAdd)
    Me.TabControl1.Controls.Add(Me.TpSkip)
    Me.TabControl1.Location = New System.Drawing.Point(10, 5)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(644, 376)
    Me.TabControl1.TabIndex = 2
    '
    'TpUpdate
    '
    Me.TpUpdate.Controls.Add(Me.Crv1)
    Me.TpUpdate.Location = New System.Drawing.Point(4, 22)
    Me.TpUpdate.Name = "TpUpdate"
    Me.TpUpdate.Size = New System.Drawing.Size(636, 350)
    Me.TpUpdate.TabIndex = 0
    Me.TpUpdate.Text = "Updated"
    Me.TpUpdate.UseVisualStyleBackColor = True
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
    'TpAdd
    '
    Me.TpAdd.Controls.Add(Me.Crv2)
    Me.TpAdd.Location = New System.Drawing.Point(4, 22)
    Me.TpAdd.Name = "TpAdd"
    Me.TpAdd.Size = New System.Drawing.Size(636, 350)
    Me.TpAdd.TabIndex = 2
    Me.TpAdd.Text = "Added"
    Me.TpAdd.UseVisualStyleBackColor = True
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
    Me.Crv2.Location = New System.Drawing.Point(-2, -1)
    Me.Crv2.Name = "Crv2"
    Me.Crv2.SelectionFormula = ""
    Me.Crv2.Size = New System.Drawing.Size(640, 352)
    Me.Crv2.TabIndex = 3
    Me.Crv2.ViewTimeSelectionFormula = ""
    '
    'TpSkip
    '
    Me.TpSkip.Controls.Add(Me.Crv3)
    Me.TpSkip.Location = New System.Drawing.Point(4, 22)
    Me.TpSkip.Name = "TpSkip"
    Me.TpSkip.Size = New System.Drawing.Size(636, 350)
    Me.TpSkip.TabIndex = 3
    Me.TpSkip.Text = "Skipped"
    Me.TpSkip.UseVisualStyleBackColor = True
    '
    'Crv3
    '
    Me.Crv3.ActiveViewIndex = -1
    Me.Crv3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv3.Cursor = System.Windows.Forms.Cursors.Default
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
    Me.Controls.Add(Me.TabControl1)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmCrViewer"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "CrViewer"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    Me.TabControl1.ResumeLayout(False)
    Me.TpUpdate.ResumeLayout(False)
    Me.TpAdd.ResumeLayout(False)
    Me.TpSkip.ResumeLayout(False)
    Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  RunReport1()


  End Sub
Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  myreport1.Close()
  myreport1.Dispose()

  End Sub

  Private Sub RunReport1()
   Dim ReportPath As String

   Me.Text = "Report Viewer"
   ReportPath = MyUtils.GetReportPath("PrtUB350.rpt", myTOWN._TOWNBR)
   With myreport1
    .Load(ReportPath)
    .SetDataSource(Wrkds1)
      .SetParameterValue("myreportTitle", "Update Customer Billing Name / Address")
      .SetParameterValue("MyUserID", MyUserID)
		.SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
		.SetParameterValue("MyPost", MyFrmUB350B.ChkPost.Checked)
      .SetParameterValue("MyUpdName", MyFrmUB350B.ChkName.Checked)
      .SetParameterValue("MyUpdAddr", MyFrmUB350B.ChkAddr.Checked)

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






