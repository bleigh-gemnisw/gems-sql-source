Imports System.Data
Public Class FrmTAP03B
  Inherits System.Windows.Forms.Form
  Dim MyTXDCFRM As TXDCFRM.myData
  Dim MyTXDVPP As TXDVPP.myData
	Dim MyTXDVPPL1 As TXDVPPL1.MyData
  Dim MyTXMCTL As TXMCTL.MyData
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTAP03B))
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
    Me.GroupBox2.SuspendLayout()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.BtnFast)
    Me.GroupBox2.Controls.Add(Me.Label2)
    Me.GroupBox2.Controls.Add(Me.TxtListNo)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(156, 46)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(181, 42)
    Me.GroupBox2.TabIndex = 26
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Fast Path"
    '
    'BtnFast
    '
    Me.BtnFast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFast.Location = New System.Drawing.Point(111, 12)
    Me.BtnFast.Name = "BtnFast"
    Me.BtnFast.Size = New System.Drawing.Size(53, 24)
    Me.BtnFast.TabIndex = 3
    Me.BtnFast.Text = "&Show"
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(6, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(36, 20)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "List#"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'TxtListNo
    '
    Me.TxtListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtListNo.Location = New System.Drawing.Point(48, 15)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(57, 20)
    Me.TxtListNo.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(12, 39)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(71, 16)
    Me.Label1.TabIndex = 24
    Me.Label1.Text = "Owner Name"
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(15, 81)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 20
    Me.BtnFind.Text = "&Find"
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Location = New System.Drawing.Point(16, 58)
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(128, 20)
    Me.TxtName.TabIndex = 0
    '
    'BtnNext
    '
    Me.BtnNext.Location = New System.Drawing.Point(74, 81)
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
    Me.C1DataGrdList.Location = New System.Drawing.Point(28, 111)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    Me.C1DataGrdList.Size = New System.Drawing.Size(320, 281)
    Me.C1DataGrdList.TabIndex = 196
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(55, 12)
    Me.TxtYear.MaxLength = 6
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtYear.TabIndex = 197
    Me.TxtYear.TabStop = False
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(13, 12)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(36, 20)
    Me.Label3.TabIndex = 198
    Me.Label3.Text = "Year"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'FrmTAP03B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(375, 404)
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
    Me.Name = "FrmTAP03B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

	Private Sub FrmTAP03B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

		MyTXDCFRM = New TXDCFRM.mydata(MyDBConnect)
		MyTXDVPP = New TXDVPP.mydata(MyDBConnect)
		MyTXDVPPL1 = New TXDVPPL1.mydata(MyDBConnect)
    MyTXMCTL = New TXMCTL.MyData(myDBConnect)

    MyTXDCFRM.GetOneRecordP(1)
		If Not MyTXDCFRM.RecordNotFound Then
			TxtYear.Text = MyTXDCFRM._CURRYR
		End If
    If MyBookPct = 0 Then
      myTXMCTL.GetOneRecordP(1)
      If Not myTXMCTL.RecordNotFound Then
        With myTXMCTL
          MyBookPct = ._VALPER
          MyMinValue = ._VALMIN
        End With
      End If
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
		End With
	End Sub
	Public Sub ShowGrid()
    Dim WrkPos As String
    WrkPos = Replace(TxtName.Text, "'", "''")
    ds = MyTXDVPPL1.GetViewOwname(MyUtils.CnvSng(TxtYear.Text), WrkPos, 50)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

  End Sub
  Private Sub FrmTAP03B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP03.SbpScreen.Text = "TAP03B"
    MyUtils.CenterForm(Me.ParentForm, Me)

  End Sub
  Private Sub BtnFast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFast.Click
    Dim ds2 As DataSet = New DataSet
    Dim WrkListNo As Integer
    Dim WrkYear As Integer

    WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    WrkYear = MyUtils.CnvSng(TxtYear.Text)
    If WrkListNo = 0 Or WrkYear = 0 Then Exit Sub

    MyTXDVPP.GetOneRecordP(WrkListNo, WrkYear)
    If Not MyTXDVPP.RecordNotFound Then
      MyFrmTAP03C = New FrmTAP03C
      MyFrmTAP03C.MdiParent = Me.ParentForm
      MyFrmTAP03C.WrkListNo = WrkListNo
      MyFrmTAP03C.WrkYear = WrkYear
      MyFrmTAP03C.Show()
      TxtListNo.Text = ""
      Me.Hide()
    Else
      MsgBox("Cannot find list#/year", MsgBoxStyle.Information, "Record not found")
    End If

  End Sub
	Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
		Dim I As Integer
		I = ds.Tables(0).Rows.Count - 1
		TxtName.Text = C1DataGrdList.Item(I, 2)
		FormatGrid()
		TxtName.Text = ""
	End Sub
Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
		Windows.Forms.Cursor.Current = Cursors.WaitCursor
		MyFrmTAP03C = New FrmTAP03C
		MyFrmTAP03C.MdiParent = Me.ParentForm
		MyFrmTAP03C.WrkListNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
		MyFrmTAP03C.WrkYear = C1DataGrdList.Item(C1DataGrdList.Row, 1)
		MyFrmTAP03C.Show()
		Me.Hide()
		Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub

Private Sub C1DataGrdList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.Click

End Sub
End Class






