Public Class FrmTXA09CC
    Inherits System.Windows.Forms.Form
		Dim myTXCOEAL1 As TXCOEAL1.myData
		Dim myTXCRESN As TXCRESN.myData
    Dim ds As DataSet = New DataSet
    Friend WrkListNo As Integer
    Friend WrkYear As Integer
    Friend WrkType As String
    Friend WrkDate As Integer
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
  Friend WithEvents LblName As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents LblType As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents LblYear As System.Windows.Forms.Label
  Friend WithEvents LblList As System.Windows.Forms.Label
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTXA09CC))
Me.LblName = New System.Windows.Forms.Label
Me.Label7 = New System.Windows.Forms.Label
Me.LblType = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
Me.LblYear = New System.Windows.Forms.Label
Me.LblList = New System.Windows.Forms.Label
Me.label2 = New System.Windows.Forms.Label
Me.label1 = New System.Windows.Forms.Label
Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'LblName
'
Me.LblName.BackColor = System.Drawing.SystemColors.Control
Me.LblName.Location = New System.Drawing.Point(196, 24)
Me.LblName.Name = "LblName"
Me.LblName.Size = New System.Drawing.Size(216, 16)
Me.LblName.TabIndex = 153
'
'Label7
'
Me.Label7.BackColor = System.Drawing.SystemColors.Control
Me.Label7.Location = New System.Drawing.Point(256, 4)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(32, 12)
Me.Label7.TabIndex = 152
Me.Label7.Text = "Type"
'
'LblType
'
Me.LblType.BackColor = System.Drawing.SystemColors.Control
Me.LblType.Location = New System.Drawing.Point(292, 4)
Me.LblType.Name = "LblType"
Me.LblType.Size = New System.Drawing.Size(16, 16)
Me.LblType.TabIndex = 151
'
'Label3
'
Me.Label3.BackColor = System.Drawing.SystemColors.Control
Me.Label3.Location = New System.Drawing.Point(316, 4)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(32, 12)
Me.Label3.TabIndex = 150
Me.Label3.Text = "Year"
'
'LblYear
'
Me.LblYear.BackColor = System.Drawing.SystemColors.Control
Me.LblYear.Location = New System.Drawing.Point(348, 4)
Me.LblYear.Name = "LblYear"
Me.LblYear.Size = New System.Drawing.Size(48, 16)
Me.LblYear.TabIndex = 149
'
'LblList
'
Me.LblList.BackColor = System.Drawing.SystemColors.Control
Me.LblList.Location = New System.Drawing.Point(196, 4)
Me.LblList.Name = "LblList"
Me.LblList.Size = New System.Drawing.Size(48, 16)
Me.LblList.TabIndex = 148
'
'label2
'
Me.label2.BackColor = System.Drawing.SystemColors.Control
Me.label2.Location = New System.Drawing.Point(104, 24)
Me.label2.Name = "label2"
Me.label2.Size = New System.Drawing.Size(84, 12)
Me.label2.TabIndex = 147
Me.label2.Text = "Name of Owner"
'
'label1
'
Me.label1.BackColor = System.Drawing.SystemColors.Control
Me.label1.Location = New System.Drawing.Point(104, 4)
Me.label1.Name = "label1"
Me.label1.Size = New System.Drawing.Size(36, 12)
Me.label1.TabIndex = 146
Me.label1.Text = "List #"
'
'C1DataGrdList
'
Me.C1DataGrdList.AllowColSelect = False
Me.C1DataGrdList.AllowRowSelect = False
Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
Me.C1DataGrdList.AllowUpdate = False
Me.C1DataGrdList.AlternatingRows = True
Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
Me.C1DataGrdList.Location = New System.Drawing.Point(8, 48)
Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
Me.C1DataGrdList.Name = "C1DataGrdList"
Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75
Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.C1DataGrdList.Size = New System.Drawing.Size(606, 248)
Me.C1DataGrdList.TabIndex = 155
Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
'
'FrmTXA09CC
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(624, 302)
Me.Controls.Add(Me.C1DataGrdList)
Me.Controls.Add(Me.LblName)
Me.Controls.Add(Me.Label7)
Me.Controls.Add(Me.LblType)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.LblYear)
Me.Controls.Add(Me.LblList)
Me.Controls.Add(Me.label2)
Me.Controls.Add(Me.label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTXA09CC"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "C/C History"
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)

End Sub

#End Region

  Private Sub FrmTXA09CC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			myTXCOEAL1 = New TXCOEAL1.mydata(MyDBConnect)
			myTXCRESN = New TXCRESN.mydata(MyDBConnect)
      LblList.Text = WrkListNo
      LblYear.Text = WrkYear
      LblType.Text = WrkType
      LblName.Text = MyFrmTXA09B.LblName.Text

     Call FormatGrid()
  End Sub
 Public Sub FormatGrid()

   ShowGrid()
   GridList()
   End Sub
    Public Sub ShowGrid()
      Windows.Forms.Cursor.Current = Cursors.WaitCursor
      ds = myTXCOEAL1.GetViewbyList(WrkListNo, WrkYear, WrkType, 50)

      C1DataGrdList.DataSource = ds.Tables(0)
      C1DataGrdList.Refresh()
      Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub GridList()
  Dim I As Integer

  With C1DataGrdList
    .Rebind(True)
    .Columns(0).Caption = "C/C No"
    .Splits(0).DisplayColumns(0).Width = 50
    .Splits(0).DisplayColumns(1).Visible = False
    .Splits(0).DisplayColumns(2).Visible = False
    .Splits(0).DisplayColumns(3).Visible = False
    .Splits(0).DisplayColumns(4).Visible = False
    .Splits(0).DisplayColumns(5).Visible = False
    .Columns(6).Caption = "Date"
    .Columns(6).NumberFormat = "##/##/####"
    .Splits(0).DisplayColumns(6).Width = 70
    .Columns(7).Caption = "Reason"
    ds = myTXCRESN.GetAllData
    .Columns(7).ValueItems.Values.Clear()
    For I = 0 To ds.Tables(0).Rows.Count - 1
      .Columns(7).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem( _
         ds.Tables(0).Rows(I).Item("cresn"), ds.Tables(0).Rows(I).Item("crdesc")))
    Next
    .Columns(7).ValueItems.Translate = True
    .Splits(0).DisplayColumns(7).Width = 150
    .Columns(8).Caption = "Description"
    .Splits(0).DisplayColumns(8).Width = 150
    .Columns(9).Caption = "Assessment"
    .Columns(9).NumberFormat = "###,###,###,###"
    .Splits(0).DisplayColumns(9).Width = 70
    .Columns(10).Caption = "C/C Tax"
    .Columns(10).NumberFormat = "Standard"
    .Splits(0).DisplayColumns(10).Width = 70
		.Splits(0).DisplayColumns(11).Visible = False
		.Splits(0).DisplayColumns(12).Visible = False
End With

End Sub
Private Sub FrmTXA09CC_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    ds.Clear()
    ds = Nothing

		'Memory Cleanup
		myTXCOEAL1.CloseFile()
		myTXCRESN.CloseFile()
		myTXCOEAL1 = Nothing
		myTXCRESN = Nothing
    MyFrmTXA09CC = Nothing

    MyFrmTXA09B.Show()
  End Sub
  Private Sub FrmTXA09CC_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA09.SbpScreen.Text = "TXA09CC"
    Call MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmTXA09
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
End Class






