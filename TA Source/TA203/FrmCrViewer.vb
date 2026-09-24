Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  Dim WrkMargin As CrystalDecisions.Shared.PageMargins
  Friend Wrkds As DataSet
  Friend WrkType As String
  Friend WrkGross As Boolean
  Friend WrkFile As String
  Friend WrkGLYear As Integer
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
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
    Me.SuspendLayout()
    '
    'Crv1
    '
    Me.Crv1.ActiveViewIndex = -1
    Me.Crv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv1.Location = New System.Drawing.Point(8, 8)
    Me.Crv1.Name = "Crv1"
    Me.Crv1.ReportSource = Nothing
    Me.Crv1.Size = New System.Drawing.Size(652, 376)
    Me.Crv1.TabIndex = 0
    '
    'FrmCrViewer
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(664, 386)
    Me.Controls.Add(Me.Crv1)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmCrViewer"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "CrViewer"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub CrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim ReportPath As String
    Dim WrkTypeDesc As String
    Dim WrkFileDesc As String

    With WrkMargin
      .leftMargin = 500
      .rightMargin = 150
      .topMargin = 250
      .bottomMargin = 150
    End With

    WrkTypeDesc = ""
    Select Case WrkType
      Case "*"
        WrkTypeDesc = "Overall"
      Case "R"
        WrkTypeDesc = "Real Estate"
      Case "P"
        WrkTypeDesc = "Personal Property"
      Case "M"
        WrkTypeDesc = "Motor Vehicle"
      Case "S"
        WrkTypeDesc = "Supplemental MV"
    End Select
    If WrkGLYear = 0 Then
      WrkFileDesc = WrkFile
    Else
      WrkFileDesc = WrkFile & " " & WrkGLYear
    End If

    Me.Text = "Report Viewer"
    ReportPath = MyUtils.GetReportPath("PrtTA203.rpt", myTOWN._TOWNBR)
    With myreport
      .Load(ReportPath)
      If MyReportLandscape Then
        .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
        .PrintOptions.DissociatePageSizeAndPrinterPaperSize = False
        .PrintOptions.ApplyPageMargins(WrkMargin)
      End If
      .SetDataSource(Wrkds)
      If MyUtils.CnvSng(MyFrmTA203B.TxtNo.Text) > 0 Then
        .SetParameterValue("MyReportTitle", WrkFileDesc & " " & WrkTypeDesc & " " & MyFrmTA203B.TxtNo.Text & " Highest Assessment List")
      Else
        .SetParameterValue("MyReportTitle", WrkFileDesc & " " & WrkTypeDesc & " Assessment List")
      End If
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyGross", WrkGross)
      .SetParameterValue("MyMin", MyUtils.CnvSng(MyFrmTA203B.TxtMin.Text))
      .SetParameterValue("MyMax", MyUtils.CnvSng(MyFrmTA203B.TxtMax.Text))
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
  Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    myreport.Close()
    myreport.Dispose()
  End Sub
End Class






