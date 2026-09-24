Imports System.Data
Public Class FrmTAP02B
  Inherits System.Windows.Forms.Form
  Dim MyTXDCFRM As TXDCFRM.myData
  Dim MyTXDMPP As TXDMPP.myData
  Dim MyTXDMPPL1 As TXDMPPL1.myData
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
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
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents BtnFast As System.Windows.Forms.Button
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents BtnFind As System.Windows.Forms.Button
	Friend WithEvents TxtName As System.Windows.Forms.TextBox
	Friend WithEvents BtnNext As System.Windows.Forms.Button
Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTAP02B))
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.BtnFast = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GroupBox2.SuspendLayout()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.BtnFast)
    Me.GroupBox2.Controls.Add(Me.Label2)
    Me.GroupBox2.Controls.Add(Me.TxtListNo)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(250, 38)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(180, 44)
    Me.GroupBox2.TabIndex = 26
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Fast Path"
    '
    'BtnFast
    '
    Me.BtnFast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFast.Location = New System.Drawing.Point(121, 12)
    Me.BtnFast.Name = "BtnFast"
    Me.BtnFast.Size = New System.Drawing.Size(53, 24)
    Me.BtnFast.TabIndex = 3
    Me.BtnFast.Text = "&Show"
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(9, 17)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(36, 20)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "List#"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'TxtListNo
    '
    Me.TxtListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtListNo.Location = New System.Drawing.Point(51, 15)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(64, 20)
    Me.TxtListNo.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(7, 52)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(71, 16)
    Me.Label1.TabIndex = 24
    Me.Label1.Text = "Owner Name"
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(84, 74)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 20
    Me.BtnFind.Text = "&Find"
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Location = New System.Drawing.Point(84, 48)
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(160, 20)
    Me.TxtName.TabIndex = 0
    '
    'BtnNext
    '
    Me.BtnNext.Location = New System.Drawing.Point(143, 74)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(53, 24)
    Me.BtnNext.TabIndex = 27
    Me.BtnNext.Text = "&Next"
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
    Me.C1DataGrdList.Location = New System.Drawing.Point(23, 107)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    Me.C1DataGrdList.Size = New System.Drawing.Size(525, 281)
    Me.C1DataGrdList.TabIndex = 196
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(56, 12)
    Me.TxtYear.MaxLength = 6
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtYear.TabIndex = 197
    Me.TxtYear.TabStop = False
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(14, 12)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(36, 20)
    Me.Label3.TabIndex = 198
    Me.Label3.Text = "Year"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'FrmTAP02B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(574, 403)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.Controls.Add(Me.BtnNext)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnFind)
    Me.Controls.Add(Me.TxtName)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "FrmTAP02B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

	Private Sub FrmTAP02B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

		MyTXDCFRM = New TXDCFRM.mydata(MyDBConnect)
		MyTXDMPP = New TXDMPP.mydata(MyDBConnect)
		MyTXDMPPL1 = New TXDMPPL1.mydata(MyDBConnect)
		MyTXDCFRM.GetOneRecordP(1)
		If Not MyTXDCFRM.RecordNotFound Then
			TxtYear.Text = MyTXDCFRM._CURRYR
			MyLastYearNo = GetLastYearNo(MyTXDCFRM._CURRYR)
		End If
		If MyLastYearNo = 0 Then
      MsgBox("There is no M65 depreciation table for year " & MyUtils.CnvSng(TxtYear.Text), MsgBoxStyle.Exclamation, "Year is invalid")
    End If
    Call FormatGrid()

  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    Call FormatGrid()
  End Sub
  Public Sub FormatGrid()

    Call ShowGrid()
    With C1DataGrdList
      .Rebind(True)
      .Columns(0).Caption = "List No"
      .Splits(0).DisplayColumns(0).Width = 50
      .Columns(1).Caption = "Year"
      .Splits(0).DisplayColumns(1).Width = 50
      .Columns(2).Caption = "Name"
      .Splits(0).DisplayColumns(2).Width = 175
      .Columns(3).Caption = "Loc No"
      .Splits(0).DisplayColumns(3).Width = 50
      .Columns(4).Caption = "Location"
      .Splits(0).DisplayColumns(4).Width = 150
    End With
  End Sub
  Public Sub ShowGrid()
    Dim WrkPos As String
    WrkPos = Replace(TxtName.Text, "'", "''")
    ds = MyTXDMPPL1.GetViewName(MyUtils.CnvSng(TxtYear.Text), WrkPos, 50)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

  End Sub
  Private Sub FrmTAP02B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP02.SbpScreen.Text = "TAP02B"
    MyUtils.CenterForm(Me.ParentForm, Me)

  End Sub
  Private Sub BtnFast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFast.Click
    Dim ds2 As DataSet = New DataSet
    Dim WrkListNo As Integer
    Dim WrkYear As Integer

    ErrProv.SetError(TxtListNo, "")
    WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    WrkYear = MyUtils.CnvSng(TxtYear.Text)
    If WrkListNo = 0 Or WrkYear = 0 Then Exit Sub

    MyTXDMPP.GetOneRecordP(WrkListNo, WrkYear)
    If Not MyTXDMPP.RecordNotFound Then
      MyFrmTAP02C = New FrmTAP02C
      MyFrmTAP02C.MdiParent = Me.ParentForm
      MyFrmTAP02C.WrkListNo = WrkListNo
      MyFrmTAP02C.WrkYear = WrkYear
      MyFrmTAP02C.Show()
      TxtListNo.Text = ""
      Me.Hide()
    Else
      ErrProv.SetError(TxtListNo, "Manufacturing data not found for this account")
    End If

  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
    Dim I As Integer
    I = ds.Tables(0).Rows.Count - 1
    TxtName.Text = Trim(C1DataGrdList.Item(I, 3))
    FormatGrid()
    TxtName.Text = ""
  End Sub
Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    MyFrmTAP02C = New FrmTAP02C
    MyFrmTAP02C.MdiParent = Me.ParentForm
    MyFrmTAP02C.WrkListNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
    MyFrmTAP02C.WrkYear = C1DataGrdList.Item(C1DataGrdList.Row, 1)
    MyFrmTAP02C.Show()
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtYear_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtYear.Leave
  Dim WrkYearNo As Integer
  If TxtYear.Modified Then
    WrkYearNo = GetLastYearNo(MyUtils.CnvSng(TxtYear.Text))
  End If

  If WrkYearNo = 0 Then
    MsgBox("There is no M65 depreciation table for year " & MyUtils.CnvSng(TxtYear.Text), MsgBoxStyle.Exclamation, "Year is invalid")
    Exit Sub
  End If

  MyLastYearNo = WrkYearNo
End Sub

Private Sub TxtYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtYear.TextChanged

End Sub
End Class






