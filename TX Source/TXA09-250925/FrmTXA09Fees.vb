Public Class FrmTXA09Fees
	Inherits System.Windows.Forms.Form
	Friend WrkListNo As Integer
	Friend WrkYear As Integer
	Friend WrkType As String
	Friend WrkCode1 As String
	Friend WrkCode2 As String
	Friend WrkCode3 As String
	Friend WrkCode4 As String
	Friend WrkCode5 As String
	Friend WrkAmt1 As Decimal
	Friend WrkAmt2 As Decimal
	Friend WrkAmt3 As Decimal
	Friend WrkAmt4 As Decimal
	Friend WrkAmt5 As Decimal
	Friend WrkMVFee As Decimal
  Friend WrkCAFee As Decimal
  Friend WithEvents LblName As System.Windows.Forms.Label
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents LblType As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents LblYear As System.Windows.Forms.Label
	Friend WithEvents LblList As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
	Friend WithEvents Label8 As System.Windows.Forms.Label
	Dim ds As DataSet = New DataSet
	Dim myTXPEN As TXPEN.myData
	Dim WrkCodes(4) As String
	Dim WrkAmts(4) As Decimal

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
	Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
	Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTXA09Fees))
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.LblName = New System.Windows.Forms.Label
Me.Label7 = New System.Windows.Forms.Label
Me.LblType = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
Me.LblYear = New System.Windows.Forms.Label
Me.LblList = New System.Windows.Forms.Label
Me.Label5 = New System.Windows.Forms.Label
Me.Label8 = New System.Windows.Forms.Label
Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'LblName
'
Me.LblName.BackColor = System.Drawing.SystemColors.Control
Me.LblName.Location = New System.Drawing.Point(104, 23)
Me.LblName.Name = "LblName"
Me.LblName.Size = New System.Drawing.Size(216, 16)
Me.LblName.TabIndex = 170
'
'Label7
'
Me.Label7.BackColor = System.Drawing.SystemColors.Control
Me.Label7.Location = New System.Drawing.Point(120, 3)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(32, 13)
Me.Label7.TabIndex = 169
Me.Label7.Text = "Type"
'
'LblType
'
Me.LblType.BackColor = System.Drawing.SystemColors.Control
Me.LblType.Location = New System.Drawing.Point(156, 3)
Me.LblType.Name = "LblType"
Me.LblType.Size = New System.Drawing.Size(16, 16)
Me.LblType.TabIndex = 168
'
'Label3
'
Me.Label3.BackColor = System.Drawing.SystemColors.Control
Me.Label3.Location = New System.Drawing.Point(180, 3)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(32, 12)
Me.Label3.TabIndex = 167
Me.Label3.Text = "Year"
'
'LblYear
'
Me.LblYear.BackColor = System.Drawing.SystemColors.Control
Me.LblYear.Location = New System.Drawing.Point(212, 3)
Me.LblYear.Name = "LblYear"
Me.LblYear.Size = New System.Drawing.Size(48, 16)
Me.LblYear.TabIndex = 166
'
'LblList
'
Me.LblList.BackColor = System.Drawing.SystemColors.Control
Me.LblList.Location = New System.Drawing.Point(57, 3)
Me.LblList.Name = "LblList"
Me.LblList.Size = New System.Drawing.Size(48, 16)
Me.LblList.TabIndex = 165
'
'Label5
'
Me.Label5.BackColor = System.Drawing.SystemColors.Control
Me.Label5.Location = New System.Drawing.Point(12, 23)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(84, 12)
Me.Label5.TabIndex = 164
Me.Label5.Text = "Name of Owner"
'
'Label8
'
Me.Label8.BackColor = System.Drawing.SystemColors.Control
Me.Label8.Location = New System.Drawing.Point(12, 3)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(36, 12)
Me.Label8.TabIndex = 163
Me.Label8.Text = "List #"
'
'C1DataGrdList
'
Me.C1DataGrdList.AllowColSelect = False
Me.C1DataGrdList.AllowRowSelect = False
Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
Me.C1DataGrdList.AllowUpdate = False
Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
Me.C1DataGrdList.Location = New System.Drawing.Point(12, 42)
Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
Me.C1DataGrdList.Name = "C1DataGrdList"
Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75
Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.C1DataGrdList.RecordSelectors = False
Me.C1DataGrdList.Size = New System.Drawing.Size(294, 141)
Me.C1DataGrdList.TabIndex = 171
Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
'
'FrmTXA09Fees
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(335, 202)
Me.Controls.Add(Me.C1DataGrdList)
Me.Controls.Add(Me.LblName)
Me.Controls.Add(Me.Label7)
Me.Controls.Add(Me.LblType)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.LblYear)
Me.Controls.Add(Me.LblList)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.Label8)
Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTXA09Fees"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
Me.Text = "Fee Codes/Amounts"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)

End Sub

#End Region

	Private Sub FrmTXA09Fees_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

		myTXPEN = New TXPEN.mydata(MyDBConnect)
		LblList.Text = WrkListNo
		LblYear.Text = WrkYear
		LblType.Text = WrkType
		LblName.Text = MyFrmTXA09B.LblName.Text
		WrkCodes(0) = WrkCode1
		WrkCodes(1) = WrkCode2
		WrkCodes(2) = WrkCode3
		WrkCodes(3) = WrkCode4
		WrkCodes(4) = WrkCode5
		WrkAmts(0) = WrkAmt1
		WrkAmts(1) = WrkAmt2
		WrkAmts(2) = WrkAmt3
		WrkAmts(3) = WrkAmt4
		WrkAmts(4) = WrkAmt5
		BuildDS()
		CreateGrid()

 End Sub

	Private Sub FrmTXA09Fees_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		myTXPEN.CloseFile()
		MyFrmTXA09B.Show()

	End Sub
	Private Sub FrmTXA09Fees_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
		MyFrmTXA09.SbpScreen.Text = "TXA09Fees"
    MyUtils.CenterForm(Me.ParentForm, Me)
	End Sub
	Private Sub BuildDS()
		Dim myTable As New DataTable
		With myTable
			.TableName = "mytable"
			.Columns.Add("Code", Type.GetType("System.String"))
			.Columns.Add("Descr", Type.GetType("System.String"))
			.Columns.Add("Amount", Type.GetType("System.Decimal"))
		End With
		ds.Tables.Add(myTable)
End Sub
Private Sub CreateGrid()
	Dim myDr As Data.DataRow
	Dim I As Integer

	For I = 0 To 4
    If WrkCodes(I) = String.Empty Then Continue For
		myDr = ds.Tables(0).NewRow
		myDr("Code") = WrkCodes(I)
		myTXPEN.GetOneRecordP(WrkCodes(I))
		If Not myTXPEN.RecordNotFound Then
			myDr("Descr") = Trim(myTXPEN._PNDESC)
		Else
			myDr("Descr") = String.Empty
		End If
		myDr("Amount") = WrkAmts(I)
		ds.Tables(0).Rows.Add(myDr)
	Next

	If WrkMVFee > 0 Then
		myDr = ds.Tables(0).NewRow
		myDr("Code") = "MV"
		myTXPEN.GetOneRecordP("MV")
		If Not myTXPEN.RecordNotFound Then
			myDr("Descr") = Trim(myTXPEN._PNDESC)
		Else
			myDr("Descr") = String.Empty
		End If
		myDr("Amount") = WrkMVFee
		ds.Tables(0).Rows.Add(myDr)
	End If

  If WrkCAFee > 0 Then
    myDr = ds.Tables(0).NewRow
    myDr("Code") = "CA"
    myTXPEN.GetOneRecordP("CA")
    If Not myTXPEN.RecordNotFound Then
      myDr("Descr") = Trim(myTXPEN._PNDESC)
    Else
      myDr("Descr") = String.Empty
    End If
    myDr("Amount") = WrkCAFee
    ds.Tables(0).Rows.Add(myDr)
  End If

  With C1DataGrdList
    .DataSource = ds.Tables(0)
    .Refresh()
    .Columns(0).Caption = "Code"
    .Splits(0).DisplayColumns(0).Width = 40
    .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    .Columns(1).Caption = "Description"
    .Splits(0).DisplayColumns(1).Width = 200
    .Columns(2).Caption = "Amount"
    .Splits(0).DisplayColumns(2).Width = 50
  End With

	Windows.Forms.Cursor.Current = Cursors.Default

End Sub
 End Class






