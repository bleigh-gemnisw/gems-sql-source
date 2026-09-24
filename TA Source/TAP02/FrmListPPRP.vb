Public Class FrmListPPRP
  Inherits System.Windows.Forms.Form
  Dim myTXPPRPL1 As TXPPRPL1.myData
  Dim myTXPPRPL2 As TXPPRPL2.myData
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkField As String

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
  Friend WithEvents BtnNext As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtPosNo As System.Windows.Forms.TextBox
  Friend WithEvents RbView2 As System.Windows.Forms.RadioButton
  Friend WithEvents RbView1 As System.Windows.Forms.RadioButton
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents TxtPos As System.Windows.Forms.TextBox
  Friend WithEvents LblCurrent As System.Windows.Forms.Label
Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListPPRP))
Me.BtnNext = New System.Windows.Forms.Button
Me.Label1 = New System.Windows.Forms.Label
Me.TxtPosNo = New System.Windows.Forms.TextBox
Me.RbView2 = New System.Windows.Forms.RadioButton
Me.RbView1 = New System.Windows.Forms.RadioButton
Me.BtnFind = New System.Windows.Forms.Button
Me.TxtPos = New System.Windows.Forms.TextBox
Me.LblCurrent = New System.Windows.Forms.Label
Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'BtnNext
'
Me.BtnNext.Location = New System.Drawing.Point(304, 8)
Me.BtnNext.Name = "BtnNext"
Me.BtnNext.Size = New System.Drawing.Size(53, 24)
Me.BtnNext.TabIndex = 65
Me.BtnNext.Text = "Ne&xt"
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 8)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(64, 16)
Me.Label1.TabIndex = 64
Me.Label1.Text = "Position To"
'
'TxtPosNo
'
Me.TxtPosNo.Location = New System.Drawing.Point(72, 8)
Me.TxtPosNo.Name = "TxtPosNo"
Me.TxtPosNo.Size = New System.Drawing.Size(41, 20)
Me.TxtPosNo.TabIndex = 57
Me.TxtPosNo.Visible = False
'
'RbView2
'
Me.RbView2.Location = New System.Drawing.Point(128, 40)
Me.RbView2.Name = "RbView2"
Me.RbView2.Size = New System.Drawing.Size(104, 16)
Me.RbView2.TabIndex = 63
Me.RbView2.Text = "Loc#/Location"
'
'RbView1
'
Me.RbView1.Checked = True
Me.RbView1.Location = New System.Drawing.Point(8, 40)
Me.RbView1.Name = "RbView1"
Me.RbView1.Size = New System.Drawing.Size(104, 16)
Me.RbView1.TabIndex = 62
Me.RbView1.TabStop = True
Me.RbView1.Text = "Owner's Name"
'
'BtnFind
'
Me.BtnFind.Location = New System.Drawing.Point(248, 8)
Me.BtnFind.Name = "BtnFind"
Me.BtnFind.Size = New System.Drawing.Size(53, 24)
Me.BtnFind.TabIndex = 61
Me.BtnFind.Text = "&Find"
'
'TxtPos
'
Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtPos.Location = New System.Drawing.Point(112, 8)
Me.TxtPos.Name = "TxtPos"
Me.TxtPos.Size = New System.Drawing.Size(128, 20)
Me.TxtPos.TabIndex = 58
'
'LblCurrent
'
Me.LblCurrent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
Me.LblCurrent.Location = New System.Drawing.Point(8, 64)
Me.LblCurrent.Name = "LblCurrent"
Me.LblCurrent.Size = New System.Drawing.Size(248, 16)
Me.LblCurrent.TabIndex = 60
'
'C1DataGrdList
'
Me.C1DataGrdList.AllowColSelect = False
Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
Me.C1DataGrdList.AlternatingRows = True
Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
Me.C1DataGrdList.Location = New System.Drawing.Point(8, 80)
Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
Me.C1DataGrdList.Name = "C1DataGrdList"
Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75
Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.C1DataGrdList.Size = New System.Drawing.Size(798, 260)
Me.C1DataGrdList.TabIndex = 200
Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
'
'FrmListPPRP
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(818, 350)
Me.Controls.Add(Me.C1DataGrdList)
Me.Controls.Add(Me.BtnNext)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.TxtPosNo)
Me.Controls.Add(Me.RbView2)
Me.Controls.Add(Me.RbView1)
Me.Controls.Add(Me.BtnFind)
Me.Controls.Add(Me.TxtPos)
Me.Controls.Add(Me.LblCurrent)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmListPPRP"
Me.Text = "Select PP List Number"
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
      .Columns(0).Caption = "List No"
      .Splits(0).DisplayColumns(0).Width = 50
    End With

    If RbView1.Checked Then
      GridNameLoc()
    End If

    If RbView2.Checked Then
      GridLocName()
    End If

  End Sub
  Public Sub ShowGrid()
      If RbView1.Checked Then
        ds = myTXPPRPL2.GetViewbyName(TxtPos.Text, 50, MyBlocking)
      End If
      If RbView2.Checked Then
        ds = myTXPPRPL1.GetViewbyLoc(TxtPos.Text, TxtPosNo.Text, 50, MyBlocking)
      End If

    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

  End Sub
  Private Sub FrmListReal_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP02.SbpScreen.Text = "ListRealC"
    MyUtils.CenterForm(Me.ParentForm, Me)

  End Sub
  Private Sub DataGrdList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

  End Sub
  Private Sub GridNameLoc()
    With C1DataGrdList
      .Rebind(True)
      .Columns(1).Caption = "Owner Name"
      .Splits(0).DisplayColumns(1).Width = 250
      .Columns(2).Caption = "Loc No"
      .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
      .Splits(0).DisplayColumns(2).Width = 50
      .Columns(3).Caption = "Location"
      .Splits(0).DisplayColumns(3).Width = 150
      .Columns(4).Caption = "Second Name"
      .Splits(0).DisplayColumns(4).Width = 250
      .Splits(0).DisplayColumns(5).Visible = False
    End With

  End Sub
Private Sub GridLocName()
    With C1DataGrdList
      .Rebind(True)
      .Columns(1).Caption = "Loc No"
      .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
      .Splits(0).DisplayColumns(1).Width = 50
      .Columns(2).Caption = "Location"
      .Splits(0).DisplayColumns(2).Width = 150
      .Columns(3).Caption = "Owner Name"
      .Splits(0).DisplayColumns(3).Width = 250
      .Columns(4).Caption = "Second Name"
      .Splits(0).DisplayColumns(4).Width = 250
      .Splits(0).DisplayColumns(5).Visible = False
    End With

  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
    Dim I As Integer
    I = ds.Tables(0).Rows.Count - 1
    If TxtPosNo.Visible Then
      TxtPosNo.Text = C1DataGrdList.Item(I, 1)
      TxtPos.Text = C1DataGrdList.Item(I, 2)
    Else
      TxtPos.Text = C1DataGrdList.Item(I, 1)
    End If
    FormatGrid()
    TxtPos.Text = ""
    TxtPosNo.Text = ""
  End Sub
  Private Sub FrmListReal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXPPRPL1 = New TXPPRPL1.mydata(MyDBConnect)
    myTXPPRPL2 = New TXPPRPL2.mydata(MyDBConnect)
    FormatGrid()
  End Sub
  Private Sub RbView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbView1.Click
    TxtPosNo.Visible = False
    FormatGrid()
  End Sub
  Private Sub RbView2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbView2.Click
    TxtPosNo.Visible = True
    FormatGrid()
  End Sub

Private Sub C1DataGrdList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.Click

End Sub

Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    With MyFrmTAP02C
      .TxtListNo.Text = C1DataGrdList.Item(C1DataGrdList.Row, 0)
      .GetTXPPRP()
      .Show()
    End With

    Me.Close()
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub
End Class






