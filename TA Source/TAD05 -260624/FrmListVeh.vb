Public Class FrmListVeh
  Inherits System.Windows.Forms.Form
  Dim myTXVEHL2 As TXVEHL2.myData
  Dim ds As DataSet = New DataSet
  Dim WrkBlocking As Boolean
  Friend WrkCustID As Integer
  Friend WithEvents LblCustID As System.Windows.Forms.Label

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
  Friend WithEvents LblCurrent As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListVeh))
Me.LblCurrent = New System.Windows.Forms.Label
Me.Label1 = New System.Windows.Forms.Label
Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
Me.LblCustID = New System.Windows.Forms.Label
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'LblCurrent
'
Me.LblCurrent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
Me.LblCurrent.Location = New System.Drawing.Point(8, 56)
Me.LblCurrent.Name = "LblCurrent"
Me.LblCurrent.Size = New System.Drawing.Size(248, 16)
Me.LblCurrent.TabIndex = 49
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(12, 4)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(46, 20)
Me.Label1.TabIndex = 55
Me.Label1.Text = "Cust ID"
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
Me.C1DataGrdList.Location = New System.Drawing.Point(8, 34)
Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
Me.C1DataGrdList.Name = "C1DataGrdList"
Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75
Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.C1DataGrdList.Size = New System.Drawing.Size(651, 353)
Me.C1DataGrdList.TabIndex = 195
Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
'
'LblCustID
'
Me.LblCustID.BackColor = System.Drawing.Color.Aqua
Me.LblCustID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LblCustID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblCustID.Location = New System.Drawing.Point(64, 4)
Me.LblCustID.Name = "LblCustID"
Me.LblCustID.Size = New System.Drawing.Size(64, 16)
Me.LblCustID.TabIndex = 196
Me.LblCustID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'FrmListVeh
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(669, 399)
Me.Controls.Add(Me.LblCustID)
Me.Controls.Add(Me.C1DataGrdList)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.LblCurrent)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmListVeh"
Me.Text = "Select DMV Vehicle"
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)

End Sub

#End Region
  Public Sub FormatGrid()
    Call ShowGrid()

    With C1DataGrdList
      .Rebind(True)
      .Splits(0).DisplayColumns(0).Visible = False
      .Splits(0).DisplayColumns(1).Visible = False
      .Columns(2).Caption = "Reg No"
      .Splits(0).DisplayColumns(2).Width = 60
      .Columns(3).Caption = "VIN"
      .Splits(0).DisplayColumns(3).Width = 150
      .Splits(0).DisplayColumns(4).Visible = False
      .Columns(5).Caption = "Vehicle ID"
      .Splits(0).DisplayColumns(5).Width = 60
      .Columns(6).Caption = "Lease?"
      .Splits(0).DisplayColumns(6).Width = 50
    End With
  End Sub
  Public Sub ShowGrid()
    ds = myTXVEHL2.GetViewbyPcust(WrkCustID, 0, 50)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

  End Sub
  Private Sub FrmListVeh_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAD05.SbpScreen.Text = "ListVeh"
    MyUtils.CenterForm(Me.ParentForm, Me)
    FormatGrid()
  End Sub
  Private Sub FrmListVeh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXVEHL2 = New TXVEHL2.mydata(MyDBConnect)
    If MyServer = "SQL" Then
      WrkBlocking = False
    Else
      WrkBlocking = True
    End If
    LblCustID.Text = WrkCustID
    FormatGrid()
  End Sub
Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    With MyFrmTAD05DMV
      .TxtOid.Text = C1DataGrdList.Item(C1DataGrdList.Row, 5)
    End With

    Me.Close()
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub FrmListVeh_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    With MyFrmTAD05DMV

      .Show()
    End With
  'Memory Cleanup
  myTXVEHL2 = Nothing
  MyFrmListVeh = Nothing
End Sub

End Class






