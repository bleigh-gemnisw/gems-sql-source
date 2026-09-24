Public Class FrmListSts
  Inherits System.Windows.Forms.Form
	Dim myTXSTS As TXSTS.MyData
	Dim ds As DataSet = New DataSet
	Friend WrkCode As String

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
	Friend WithEvents BtnFind As System.Windows.Forms.Button
	Friend WithEvents TxtPos As System.Windows.Forms.TextBox
Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListSts))
Me.LblCurrent = New System.Windows.Forms.Label
Me.Label1 = New System.Windows.Forms.Label
Me.BtnFind = New System.Windows.Forms.Button
Me.TxtPos = New System.Windows.Forms.TextBox
Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'LblCurrent
'
Me.LblCurrent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
Me.LblCurrent.Location = New System.Drawing.Point(12, 32)
Me.LblCurrent.Name = "LblCurrent"
Me.LblCurrent.Size = New System.Drawing.Size(248, 16)
Me.LblCurrent.TabIndex = 49
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 8)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(64, 16)
Me.Label1.TabIndex = 48
Me.Label1.Text = "Position To"
'
'BtnFind
'
Me.BtnFind.Location = New System.Drawing.Point(208, 0)
Me.BtnFind.Name = "BtnFind"
Me.BtnFind.Size = New System.Drawing.Size(53, 24)
Me.BtnFind.TabIndex = 47
Me.BtnFind.Text = "&Find"
'
'TxtPos
'
Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtPos.Location = New System.Drawing.Point(72, 4)
Me.TxtPos.Name = "TxtPos"
Me.TxtPos.Size = New System.Drawing.Size(128, 20)
Me.TxtPos.TabIndex = 46
'
'C1DataGrdList
'
Me.C1DataGrdList.AllowUpdate = False
Me.C1DataGrdList.AlternatingRows = True
Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
Me.C1DataGrdList.Location = New System.Drawing.Point(8, 56)
Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
Me.C1DataGrdList.Name = "C1DataGrdList"
Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75
Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.C1DataGrdList.Size = New System.Drawing.Size(424, 260)
Me.C1DataGrdList.TabIndex = 177
Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
'
'FrmListSts
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(440, 326)
Me.Controls.Add(Me.C1DataGrdList)
Me.Controls.Add(Me.LblCurrent)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.BtnFind)
Me.Controls.Add(Me.TxtPos)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmListSts"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Select Status Code"
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region
	Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
		Call FormatGrid()
	End Sub

	Public Sub FormatGrid()

		Call ShowGrid()

		With C1DataGrdList
			.Rebind(True)
			.Columns(0).Caption = "Code"
			.Splits(0).DisplayColumns(0).Width = 40
			.Columns(1).Caption = "Description"
			.Splits(0).DisplayColumns(1).Width = 250
		End With

	End Sub
	Public Sub ShowGrid()
		If TxtPos.Text = "" Then
			ds = myTXSTS.GetAllData
		Else
			ds = myTXSTS.PosData(TxtPos.Text)
		End If
		C1DataGrdList.DataSource = ds.Tables(0)
		C1DataGrdList.Refresh()

	End Sub
	Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
		Dim I As Integer
		I = ds.Tables(0).Rows.Count - 1
		TxtPos.Text = C1DataGrdList.Item(I, 1)
		FormatGrid()
		TxtPos.Text = ""
	End Sub
	Private Sub FrmListExemption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		myTXSTS = New TXSTS.mydata(MyDBConnect)
		LblCurrent.Text = "(Status Code = " & WrkCode & ")"
		FormatGrid()
	End Sub
Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    With MyFrmTX4042B
      .TxtStatusCD.Text = C1DataGrdList.Item(C1DataGrdList.Row, 0)
      .Ttp1.SetToolTip(.TxtStatusCD, C1DataGrdList.Item(C1DataGrdList.Row, 1))
      .Show()
    End With

    Me.Close()
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub FrmListSts_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  'Memory Cleanup
  myTXSTS = Nothing
  MyFrmListSts = Nothing
End Sub
End Class






