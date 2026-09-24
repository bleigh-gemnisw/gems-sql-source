Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New PrtUB501
  Dim dsTXPROF As New DataSet
  Friend Wrkds As DataSet
  Friend WrkType As String

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

  Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Dim Good As Boolean

    If MyAppSettings.Printer <> "" Then
      Good = MyUtils.CheckPrinterExists(MyAppSettings.Printer)
      If Not Good Then
        MsgBox("Printer " & MyAppSettings.Printer & " does not exist. Return to search screen and then click on settings button to change.", MsgBoxStyle.Exclamation, "Report cannot be printed")
        Me.Close()
        Exit Sub
      End If
    End If

    RunReport(MyFrmUB501C.LblBond.Visible)
    If MyAppSettings.Printer <> "" Then
      Me.Close()
    End If

  End Sub
  Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    myreport.Close()
    myreport.Dispose()
  End Sub
  Private Sub RunReport(ByVal WrkBond As Boolean)
    Dim AddrLine() As String

    Me.Text = "Report Viewer"
    With myreport
      If MyAppSettings.Printer <> "" Then
        .PrintOptions.PrinterName = MyAppSettings.Printer
      End If
      .SetDataSource(Wrkds)
      .SetParameterValue("myreportTitle", "UB Adjustment")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      With MyFrmUB501C
        AddrLine = MyUtils.SetAddrLine(.TxtName.Text, .TxtSname.Text, .TxtAdd1.Text,
       .TxtAdd2.Text, .TxtCity.Text, .TxtState.Text, MyUtils.CnvSng(.TxtZip5.Text),
       MyUtils.CnvSng(.TxtZip4.Text))
      End With
      .SetParameterValue("AddrLine1", AddrLine(0))
      .SetParameterValue("AddrLine2", AddrLine(1))
      .SetParameterValue("AddrLine3", AddrLine(2))
      .SetParameterValue("AddrLine4", AddrLine(3))
      .SetParameterValue("AddrLine5", AddrLine(4))
      .SetParameterValue("MyBond", WrkBond)
      If MyAppSettings.Printer <> "" Then
        .PrintToPrinter(MyAppSettings.Copies, False, 0, 0)
        .Close()
        .Dispose()
        Exit Sub
      End If
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
End Class










