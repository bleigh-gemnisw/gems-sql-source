Public Class FrmLOG
    Inherits System.Windows.Forms.Form
  Friend WrkListNo As Integer
  Friend WrkType As String
  Friend ds As DataSet = New DataSet
  Friend WithEvents RbNormal As System.Windows.Forms.RadioButton
  Friend WithEvents RbMerged As System.Windows.Forms.RadioButton

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
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLOG))
Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
Me.RbNormal = New System.Windows.Forms.RadioButton
Me.RbMerged = New System.Windows.Forms.RadioButton
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'C1DataGrdList
'
Me.C1DataGrdList.AllowColSelect = False
Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
Me.C1DataGrdList.AlternatingRows = True
Me.C1DataGrdList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
Me.C1DataGrdList.Location = New System.Drawing.Point(16, 29)
Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
Me.C1DataGrdList.Name = "C1DataGrdList"
Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75
Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.C1DataGrdList.Size = New System.Drawing.Size(640, 283)
Me.C1DataGrdList.TabIndex = 196
Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
'
'RbNormal
'
Me.RbNormal.AutoSize = True
Me.RbNormal.CheckAlign = System.Drawing.ContentAlignment.TopRight
Me.RbNormal.Location = New System.Drawing.Point(188, 6)
Me.RbNormal.Name = "RbNormal"
Me.RbNormal.Size = New System.Drawing.Size(113, 17)
Me.RbNormal.TabIndex = 200
Me.RbNormal.Text = "Normal (Full Detail)"
Me.RbNormal.UseVisualStyleBackColor = True
'
'RbMerged
'
Me.RbMerged.AutoSize = True
Me.RbMerged.CheckAlign = System.Drawing.ContentAlignment.TopRight
Me.RbMerged.Checked = True
Me.RbMerged.Location = New System.Drawing.Point(16, 6)
Me.RbMerged.Name = "RbMerged"
Me.RbMerged.Size = New System.Drawing.Size(148, 17)
Me.RbMerged.TabIndex = 199
Me.RbMerged.TabStop = True
Me.RbMerged.Text = "Merged (Differences Only)"
Me.RbMerged.UseVisualStyleBackColor = True
'
'FrmLOG
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(672, 326)
Me.Controls.Add(Me.RbNormal)
Me.Controls.Add(Me.RbMerged)
Me.Controls.Add(Me.C1DataGrdList)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.Name = "FrmLOG"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Change Log"
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmLOG_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Select Case WrkType
  Case ""
    Me.Text = "Customer " & Me.Text
  Case "A"
    Me.Text = "Assessment " & Me.Text
  Case "U"
    Me.Text = "Usage " & Me.Text
  End Select

  FormatGrid()
End Sub
Public Sub FormatGrid()
  Select Case WrkType
  Case ""
    Call FormatGridCust()
  Case "A"
    Call FormatGridAS()
  Case "U"
    Call FormatGridUS()
  End Select
End Sub
Public Sub FormatGridCust()
  Dim I As Integer

  Call ShowGrid()
  With C1DataGrdList
      .Rebind(True)
      .Columns(0).Caption = "Account #"
      .Columns(1).Caption = "Name 1"
      .Columns(2).Caption = "Name 2"
      .Columns(3).Caption = "Address 1"
      .Columns(4).Caption = "Address 2"
      .Columns(5).Caption = "City"
      .Columns(6).Caption = "State"
      .Columns(7).Caption = "Zip"
      .Columns(8).Caption = "Mail Address 1"
      .Columns(9).Caption = "Mail Address 2"
      .Columns(10).Caption = "Mail City"
      .Columns(11).Caption = "Mail State"
      .Columns(12).Caption = "Mail Zip"
      .Columns(13).Caption = "Phone #"
      .Columns(14).Caption = "District"
      .Columns(15).Caption = "Phase"
      .Columns(16).Caption = "Address Xref"
      .Columns(17).Caption = "Tie in Date"
      .Columns(18).Caption = "Map Block Lot"
      .Columns(19).Caption = "Volume"
      .Columns(20).Caption = "Page"
      .Columns(21).Caption = "Zone"
      .Columns(22).Caption = "Prop Category"
      .Columns(23).Caption = "XRef Number"
      .Columns(24).Caption = "Meter Size"
      .Columns(25).Caption = "Cycle Billing"
      .Columns(26).Caption = "Owner ID"
      .Columns(27).Caption = "Serial Number"
      .Columns(28).Caption = "Route Number"
      .Columns(29).Caption = "Meter Number"
      .Columns(30).Caption = "Prev Meter Number"
      .Columns(31).Caption = "Region Code"
      .Columns(32).Caption = "Location #"
      .Columns(33).Caption = "Location"
      .Columns(34).Caption = "Contract #"
      .Columns(35).Caption = "Application #"
      .Columns(36).Caption = "Fund"
      .Columns(37).Caption = "Section"
      .Columns(38).Caption = "Service Descr"
      .Columns(39).Caption = "Log Comment "
      .Columns(40).Caption = "Log Date"
      .Columns(41).Caption = "Log Time"

      .Splits(0).DisplayColumns(0).Width = 55
      .Splits(0).DisplayColumns(1).Width = 250
      .Splits(0).DisplayColumns(2).Width = 250
      .Splits(0).DisplayColumns(3).Width = 250
      .Splits(0).DisplayColumns(4).Width = 250
      .Splits(0).DisplayColumns(5).Width = 250
      .Splits(0).DisplayColumns(6).Width = 30
      .Splits(0).DisplayColumns(7).Width = 50
      .Splits(0).DisplayColumns(8).Width = 250
      .Splits(0).DisplayColumns(9).Width = 250
      '
      .Splits(0).DisplayColumns(10).Width = 250
      .Splits(0).DisplayColumns(11).Width = 30
      .Splits(0).DisplayColumns(12).Width = 50
      .Splits(0).DisplayColumns(13).Width = 60
      .Splits(0).DisplayColumns(14).Width = 60
      .Splits(0).DisplayColumns(15).Width = 60
      .Splits(0).DisplayColumns(16).Width = 60
      .Splits(0).DisplayColumns(17).Width = 60
      .Splits(0).DisplayColumns(18).Width = 40
      .Splits(0).DisplayColumns(19).Width = 30

      .Splits(0).DisplayColumns(20).Width = 60
      .Splits(0).DisplayColumns(21).Width = 60
      .Splits(0).DisplayColumns(22).Width = 60
      .Splits(0).DisplayColumns(23).Width = 60
      .Splits(0).DisplayColumns(24).Width = 60
      .Splits(0).DisplayColumns(25).Width = 60
      .Splits(0).DisplayColumns(26).Width = 60
      .Splits(0).DisplayColumns(27).Width = 60
      .Splits(0).DisplayColumns(28).Width = 60
      .Splits(0).DisplayColumns(29).Width = 60

      .Splits(0).DisplayColumns(30).Width = 60
      .Splits(0).DisplayColumns(31).Width = 60
      .Splits(0).DisplayColumns(32).Width = 60
      .Splits(0).DisplayColumns(33).Width = 60
      .Splits(0).DisplayColumns(34).Width = 60
      .Splits(0).DisplayColumns(35).Width = 60
      .Splits(0).DisplayColumns(36).Width = 60
      .Splits(0).DisplayColumns(37).Width = 60
      .Splits(0).DisplayColumns(38).Width = 60
      .Splits(0).DisplayColumns(39).Width = 60

      .Splits(0).DisplayColumns(40).Width = 60
      .Splits(0).DisplayColumns(41).Width = 60
      For I = 0 To 41
        If RbMerged.Checked Then
          .Splits(0).DisplayColumns(I).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.Free
        Else
          .Splits(0).DisplayColumns(I).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.None
        End If
      Next
   End With
End Sub
Public Sub FormatGridAS()
  Dim I As Integer

  Call ShowGrid()
  With C1DataGrdList
      .Rebind(True)
      .Columns(0).Caption = "Account"
      .Columns(1).Caption = "Rate Type"
      .Columns(2).Caption = "Adjustment"
      .Columns(3).Caption = "Deferred"
      .Columns(4).Caption = "Deferred Pct"
      .Columns(5).Caption = "Amt Billed"
      .Columns(6).Caption = "# of Bills"
      .Columns(7).Caption = "Override"
      .Columns(8).Caption = "Lateral Fee"
      .Columns(9).Caption = "Uniform Min Fee"
      .Columns(10).Caption = "Permit #"
      .Columns(11).Caption = "Units"
      .Columns(12).Caption = "Property Value"
      .Columns(13).Caption = "Footage"
      .Columns(14).Caption = "Acreage"
      .Columns(15).Caption = "Log Comment"
      .Columns(16).Caption = "Log Date"
      .Columns(17).Caption = "Log Time"

'
      .Splits(0).DisplayColumns(0).Width = 55
      .Splits(0).DisplayColumns(1).Visible = False
      .Splits(0).DisplayColumns(2).Width = 60
      .Splits(0).DisplayColumns(3).Width = 60
      .Splits(0).DisplayColumns(4).Width = 60
      .Splits(0).DisplayColumns(5).Width = 60
      .Splits(0).DisplayColumns(6).Width = 50
      .Splits(0).DisplayColumns(7).Width = 60
      .Splits(0).DisplayColumns(8).Width = 60
      .Splits(0).DisplayColumns(9).Width = 60
      '
      .Splits(0).DisplayColumns(10).Width = 60
      .Splits(0).DisplayColumns(11).Width = 60
      .Splits(0).DisplayColumns(12).Width = 60
      .Splits(0).DisplayColumns(13).Width = 60
      .Splits(0).DisplayColumns(14).Width = 60
      .Splits(0).DisplayColumns(15).Width = 60
      .Splits(0).DisplayColumns(16).Width = 60
      .Splits(0).DisplayColumns(17).Width = 60
      For I = 0 To 17
        If RbMerged.Checked Then
          .Splits(0).DisplayColumns(I).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.Free
        Else
          .Splits(0).DisplayColumns(I).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.None
        End If
      Next
   End With
End Sub
Public Sub FormatGridUS()
  Dim I As Integer

  Call ShowGrid()
  With C1DataGrdList
      .Rebind(True)
      .Columns(0).Caption = "Account"
      .Columns(1).Caption = "Rate Type"
      .Columns(2).Caption = "Permit #"
      .Columns(3).Caption = "Units"
      .Columns(4).Caption = "EDUs"
      .Columns(5).Caption = "Sewer Fixtures"
      .Columns(6).Caption = "Extras"
      .Columns(7).Caption = "Water Fixtures"
      .Columns(8).Caption = "Sewer Sur-Charge"
      .Columns(9).Caption = "Log Comment "
      .Columns(10).Caption = "Log Date"
      .Columns(11).Caption = "Log Time"
'
      .Splits(0).DisplayColumns(0).Width = 55
      .Splits(0).DisplayColumns(1).Visible = False
      .Splits(0).DisplayColumns(2).Width = 60
      .Splits(0).DisplayColumns(3).Width = 60
      .Splits(0).DisplayColumns(4).Width = 60
      .Splits(0).DisplayColumns(5).Width = 60
      .Splits(0).DisplayColumns(6).Width = 60
      .Splits(0).DisplayColumns(7).Width = 60
      .Splits(0).DisplayColumns(8).Width = 60
      .Splits(0).DisplayColumns(9).Width = 60
      '
      .Splits(0).DisplayColumns(10).Width = 60
      .Splits(0).DisplayColumns(11).Width = 60

      For I = 0 To 11
        If RbMerged.Checked Then
          .Splits(0).DisplayColumns(I).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.Free
        Else
          .Splits(0).DisplayColumns(I).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.None
        End If
      Next
   End With
End Sub
Public Sub ShowGrid()
  C1DataGrdList.DataSource = ds.Tables(0)
  C1DataGrdList.Refresh()
End Sub
Private Sub RbMerged_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbMerged.Click
  FormatGrid()
End Sub
Private Sub RbNormal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbNormal.Click
  FormatGrid()
End Sub
End Class
