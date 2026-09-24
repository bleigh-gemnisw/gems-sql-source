Public Class FrmListCodes
  Inherits System.Windows.Forms.Form
	Dim myTXCODE As TXCode.myData
  Dim ds As DataSet = New DataSet
  Friend WrkType As String
  Friend WrkCode As Integer
  Friend WrkFieldNo As Integer

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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents TxtPos As System.Windows.Forms.TextBox
  Friend WithEvents LblCurrent As System.Windows.Forms.Label
Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListCodes))
Me.Label1 = New System.Windows.Forms.Label
Me.BtnFind = New System.Windows.Forms.Button
Me.TxtPos = New System.Windows.Forms.TextBox
Me.LblCurrent = New System.Windows.Forms.Label
Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 12)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(64, 16)
Me.Label1.TabIndex = 30
Me.Label1.Text = "Position To"
'
'BtnFind
'
Me.BtnFind.Location = New System.Drawing.Point(208, 4)
Me.BtnFind.Name = "BtnFind"
Me.BtnFind.Size = New System.Drawing.Size(53, 24)
Me.BtnFind.TabIndex = 29
Me.BtnFind.Text = "&Find"
'
'TxtPos
'
Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtPos.Location = New System.Drawing.Point(72, 8)
Me.TxtPos.Name = "TxtPos"
Me.TxtPos.Size = New System.Drawing.Size(128, 20)
Me.TxtPos.TabIndex = 28
'
'LblCurrent
'
Me.LblCurrent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
Me.LblCurrent.Location = New System.Drawing.Point(40, 36)
Me.LblCurrent.Name = "LblCurrent"
Me.LblCurrent.Size = New System.Drawing.Size(248, 16)
Me.LblCurrent.TabIndex = 32
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
Me.C1DataGrdList.Location = New System.Drawing.Point(28, 56)
Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
Me.C1DataGrdList.Name = "C1DataGrdList"
Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75
Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.C1DataGrdList.Size = New System.Drawing.Size(272, 260)
Me.C1DataGrdList.TabIndex = 198
Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
'
'FrmListCodes
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(328, 326)
Me.Controls.Add(Me.C1DataGrdList)
Me.Controls.Add(Me.LblCurrent)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.BtnFind)
Me.Controls.Add(Me.TxtPos)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmListCodes"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Select Assessment Code"
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
      .Splits(0).DisplayColumns(1).Visible = False
      .Columns(2).Caption = "Description"
      .Splits(0).DisplayColumns(2).Width = 150
      .Splits(0).DisplayColumns(3).Visible = False
      .Splits(0).DisplayColumns(4).Visible = False
      .Splits(0).DisplayColumns(5).Visible = False
    End With

  End Sub
  Public Sub ShowGrid()
    If TxtPos.Text = "" Then
			ds = myTXCODE.GetAllType(WrkType)
    Else
			ds = myTXCODE.PosData(TxtPos.Text, WrkType)
    End If
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

  End Sub
  Private Sub FrmListCodes_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTX405.SbpScreen.Text = "ListCodes"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub TxtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    If e.KeyChar = MyUtils.VbKeyEnter Then
      FormatGrid()
    End If
  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Dim I As Integer
    I = ds.Tables(0).Rows.Count - 1
    TxtPos.Text = C1DataGrdList.Item(I, 1)
    FormatGrid()
    TxtPos.Text = ""
  End Sub
  Private Sub FrmListCodes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		myTXCODE = New TXCode.mydata(MyDBConnect)
    LblCurrent.Text = "(Code " & WrkFieldNo & " = " & WrkCode & ")"
    FormatGrid()
  End Sub

Private Sub C1DataGrdList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.Click

End Sub

Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    With MyFrmTX405C
    Select Case WrkFieldNo
    Case 1
      .TxtCode1.Text = C1DataGrdList.Item(C1DataGrdList.Row, 0)
      .Ttp1.SetToolTip(.TxtCode1, C1DataGrdList.Item(C1DataGrdList.Row, 2))
    Case 2
      .TxtCode2.Text = C1DataGrdList.Item(C1DataGrdList.Row, 0)
      .Ttp1.SetToolTip(.TxtCode2, C1DataGrdList.Item(C1DataGrdList.Row, 2))
    Case 3
      .TxtCode3.Text = C1DataGrdList.Item(C1DataGrdList.Row, 0)
      .Ttp1.SetToolTip(.TxtCode3, C1DataGrdList.Item(C1DataGrdList.Row, 2))
    Case 4
      .TxtCode4.Text = C1DataGrdList.Item(C1DataGrdList.Row, 0)
      .Ttp1.SetToolTip(.TxtCode4, C1DataGrdList.Item(C1DataGrdList.Row, 2))
    Case 5
      .TxtCode5.Text = C1DataGrdList.Item(C1DataGrdList.Row, 0)
      .Ttp1.SetToolTip(.TxtCode5, C1DataGrdList.Item(C1DataGrdList.Row, 2))
    Case 6
      .TxtCode6.Text = C1DataGrdList.Item(C1DataGrdList.Row, 0)
      .Ttp1.SetToolTip(.TxtCode6, C1DataGrdList.Item(C1DataGrdList.Row, 2))
    Case 7
      .TxtCode7.Text = C1DataGrdList.Item(C1DataGrdList.Row, 0)
      .Ttp1.SetToolTip(.TxtCode7, C1DataGrdList.Item(C1DataGrdList.Row, 2))
    Case 8
      .TxtCode8.Text = C1DataGrdList.Item(C1DataGrdList.Row, 0)
      .Ttp1.SetToolTip(.TxtCode8, C1DataGrdList.Item(C1DataGrdList.Row, 2))
    Case 9
      .TxtCode9.Text = C1DataGrdList.Item(C1DataGrdList.Row, 0)
      .Ttp1.SetToolTip(.TxtCode9, C1DataGrdList.Item(C1DataGrdList.Row, 2))
    Case 10
      .TxtCode10.Text = C1DataGrdList.Item(C1DataGrdList.Row, 0)
      .Ttp1.SetToolTip(.TxtCode10, C1DataGrdList.Item(C1DataGrdList.Row, 2))
    End Select
    .Show()
  End With

  Me.Close()
  Windows.Forms.Cursor.Current = Cursors.Default

End Sub
End Class






