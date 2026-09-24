Public Class FrmListAltID
  Inherits System.Windows.Forms.Form
  Dim ds As DataSet = New DataSet

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
Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListAltID))
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColSelect = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AlternatingRows = True
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(76, 12)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.Size = New System.Drawing.Size(60, 264)
    Me.C1DataGrdList.TabIndex = 196
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    '
    'FrmListAltID
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(200, 288)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmListAltID"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Select Alternative Form ID"
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

End Sub

#End Region
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Call FormatGrid()
  End Sub

  Public Sub FormatGrid()

    Call ShowGrid()

    With C1DataGrdList
      .Rebind(True)
      .Columns(0).Caption = "ID"
      .Splits(0).DisplayColumns(0).Width = 20
    End With

  End Sub
  Public Sub ShowGrid()
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

  End Sub
  Private Sub FrmListAltID_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTX302.SbpScreen.Text = "ListAltID"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub FrmListAltID_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Dim WrkReportName As String
  Dim WrkReportPath As String
  Dim WrkAltID As String
  Dim WrkExists As Boolean
  Dim dr As Data.DataRow
  Dim I As Integer

   BuildDS()
   For I = 0 To 25 'Check AltID (A to Z)
   WrkAltID = Chr(65 + I) '65=A
   WrkReportName = ""
   If MyFrmTX302B.RbPrtList.Checked Or MyFrmTX302B.RbPrtListAddr.Checked Or MyFrmTX302B.RbPrtListStatus.Checked Then
     WrkReportName = "PrtTX3026" & WrkAltID & ".rpt"
   End If
   If MyFrmTX302B.RbPrtStatement.Checked Then
     WrkReportName = "PrtTX3023" & WrkAltID & ".rpt"
   End If
   If MyFrmTX302B.RbPrtDemand.Checked Then
     WrkReportName = "PrtTX3024" & WrkAltID & ".rpt"
   End If
   If MyFrmTX302B.RbPrtWarrants.Checked Then
     WrkReportName = "PrtTX3025" & WrkAltID & ".rpt"
   End If
   If WrkReportName <> "" Then
     WrkReportPath = MyUtils.GetReportPath(WrkReportName, myTOWN._TOWNBR)
     WrkExists = MyUtils.CheckFileExists(WrkReportPath)
     If WrkExists Then
       dr = ds.Tables(0).NewRow
       dr("AltID") = WrkAltID
       ds.Tables(0).Rows.Add(dr)
     End If
   End If
   Next
   FormatGrid()
End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("AltID", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    With MyFrmTX302B
      .TxtAltFormID.Text = C1DataGrdList.Item(C1DataGrdList.Row, 0)
      .Show()
    End With

    Me.Close()
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub

Private Sub FrmListAltID_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  'Memory Cleanup
  MyFrmListAltID = Nothing
End Sub

Private Sub LblCurrent_Click(sender As Object, e As EventArgs)

End Sub
End Class






