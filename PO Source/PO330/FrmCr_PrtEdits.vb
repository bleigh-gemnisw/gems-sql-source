Public Class FrmCr_PrtEdits
  Inherits System.Windows.Forms.Form
  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim WrkMargin As CrystalDecisions.Shared.PageMargins
  Friend Wrkds As DataSet

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
  Friend WithEvents TabCtl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpAcct As System.Windows.Forms.TabPage
Friend WithEvents PrtDialog As System.Windows.Forms.PrintDialog
Friend WithEvents Crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.TabCtl1 = New System.Windows.Forms.TabControl()
    Me.TpAcct = New System.Windows.Forms.TabPage()
    Me.Crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.PrtDialog = New System.Windows.Forms.PrintDialog()
    Me.TabCtl1.SuspendLayout()
    Me.TpAcct.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabCtl1
    '
    Me.TabCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabCtl1.Controls.Add(Me.TpAcct)
    Me.TabCtl1.Location = New System.Drawing.Point(0, 8)
    Me.TabCtl1.Name = "TabCtl1"
    Me.TabCtl1.SelectedIndex = 0
    Me.TabCtl1.Size = New System.Drawing.Size(640, 344)
    Me.TabCtl1.TabIndex = 0
    '
    'TpAcct
    '
    Me.TpAcct.Controls.Add(Me.Crv2)
    Me.TpAcct.Location = New System.Drawing.Point(4, 22)
    Me.TpAcct.Name = "TpAcct"
    Me.TpAcct.Size = New System.Drawing.Size(632, 318)
    Me.TpAcct.TabIndex = 2
    Me.TpAcct.Text = "Acct Order"
    Me.TpAcct.UseVisualStyleBackColor = True
    '
    'Crv2
    '
    Me.Crv2.ActiveViewIndex = -1
    Me.Crv2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv2.Cursor = System.Windows.Forms.Cursors.Default
    Me.Crv2.DisplayStatusBar = False
    Me.Crv2.DisplayToolbar = False
    Me.Crv2.Location = New System.Drawing.Point(8, 7)
    Me.Crv2.Name = "Crv2"
    Me.Crv2.SelectionFormula = ""
    Me.Crv2.Size = New System.Drawing.Size(616, 304)
    Me.Crv2.TabIndex = 4
    Me.Crv2.ViewTimeSelectionFormula = ""
    '
    'FrmCr_PrtEdits
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(648, 358)
    Me.Controls.Add(Me.TabCtl1)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmCr_PrtEdits"
    Me.Text = "Print PO Change entries"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    Me.TabCtl1.ResumeLayout(False)
    Me.TpAcct.ResumeLayout(False)
    Me.ResumeLayout(False)

End Sub

#End Region

  Private Sub FrmCr_PrtEdits_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    With WrkMargin
      .leftMargin = 500
      .rightMargin = 150
      .topMargin = 250
      .bottomMargin = 150
    End With
    RptEditByAcct()
  End Sub

Private Sub FrmCr_PrtEdits_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  myreport1.Close()
  myreport1.Dispose()
End Sub
  Private Sub RptEditByAcct()
   Dim ReportPath As String

   ReportPath = MyUtils.GetReportPath("PrtPO330.rpt", myTOWN._TOWNBR)
   With myreport1
    .Load(ReportPath)
    .SetDataSource(Wrkds)
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyReportTitle", "Summary of Entries Posted To LEDGER")
    .SetParameterValue("MyPost", True)
    .SetParameterValue("MyError", False)
   End With
   With Crv2
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
