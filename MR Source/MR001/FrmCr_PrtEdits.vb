Public Class FrmCr_PrtEdits
  Inherits System.Windows.Forms.Form
  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim WrkMargin As CrystalDecisions.Shared.PageMargins
  Friend Wrkds As DataSet
  Friend WrkTCash As Decimal
  Friend WrkTCheck As Decimal
  Friend WrkTCredit As Decimal
  Friend WrkTTotal As Decimal
  Friend WrkPost As Boolean
  Friend WrkErrors As Boolean
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer

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
Friend WithEvents PrtDialog As System.Windows.Forms.PrintDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.PrtDialog = New System.Windows.Forms.PrintDialog
Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
Me.SuspendLayout()
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
Me.Crv1.Location = New System.Drawing.Point(-1, 2)
Me.Crv1.Name = "Crv1"
Me.Crv1.SelectionFormula = ""
Me.Crv1.Size = New System.Drawing.Size(647, 359)
Me.Crv1.TabIndex = 3
Me.Crv1.ViewTimeSelectionFormula = ""
'
'FrmCr_PrtEdits
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(648, 358)
Me.Controls.Add(Me.Crv1)
Me.KeyPreview = True
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmCr_PrtEdits"
Me.Text = "Print Batch Edit"
Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
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

    If WrkPost Then
      Me.Text = "** POSTING RUN ** - " & Me.Text
    End If

    RptEdit()
  End Sub
Private Sub FrmCr_PrtEdits_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  myreport1.Close()
  myreport1.Dispose()
End Sub
  Private Sub RptEdit()
    Dim ReportPath As String

    ReportPath = MyUtils.GetReportPath("PrtMR001.rpt", myTOWN._TOWNBR)
    With myreport1
      .Load(ReportPath)
      If MyReportLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        .PrintOptions.ApplyPageMargins(WrkMargin)
      End If
      .SetDataSource(Wrkds)
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyTCash", WrkTCash)
      .SetParameterValue("MyTCheck", WrkTCheck)
      .SetParameterValue("MyTCredit", WrkTCredit)
      .SetParameterValue("MyTTotal", WrkTTotal)
      .SetParameterValue("Post", WrkPost)
      .SetParameterValue("MyErrors", WrkErrors)
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
