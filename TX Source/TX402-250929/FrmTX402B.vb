Public Class FrmTX402B
  Inherits System.Windows.Forms.Form
	Dim MyTXREALC As TXREALC.myData
	Dim MyTXPPRPC As TXPPRPC.myData
	Dim MyTXMVDC As TXMVDC.myData
	Dim MyTXSUPP As TXSupp.myData
  Dim WrkType As String
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbSU As System.Windows.Forms.RadioButton
  Friend WithEvents RbMV As System.Windows.Forms.RadioButton
  Friend WithEvents RbPP As System.Windows.Forms.RadioButton
  Friend WithEvents RbRE As System.Windows.Forms.RadioButton
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Dim LoadScrn As Boolean
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
Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
Friend WithEvents BtnAdd As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.BtnAdd = New System.Windows.Forms.Button()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbSU = New System.Windows.Forms.RadioButton()
    Me.RbMV = New System.Windows.Forms.RadioButton()
    Me.RbPP = New System.Windows.Forms.RadioButton()
    Me.RbRE = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox3.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.DataGrdView)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.ForeColor = System.Drawing.Color.Maroon
    Me.GroupBox3.Location = New System.Drawing.Point(76, 39)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(336, 368)
    Me.GroupBox3.TabIndex = 304
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "List #'s to be Flagged for Back Tax"
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DataGrdView.Location = New System.Drawing.Point(6, 18)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(324, 344)
    Me.DataGrdView.TabIndex = 38
    '
    'TxtListNo
    '
    Me.TxtListNo.Location = New System.Drawing.Point(107, 413)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(62, 20)
    Me.TxtListNo.TabIndex = 0
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(51, 417)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(48, 16)
    Me.Label3.TabIndex = 336
    Me.Label3.Text = "List #"
    '
    'BtnAdd
    '
    Me.BtnAdd.Location = New System.Drawing.Point(175, 413)
    Me.BtnAdd.Name = "BtnAdd"
    Me.BtnAdd.Size = New System.Drawing.Size(52, 20)
    Me.BtnAdd.TabIndex = 1
    Me.BtnAdd.Text = "Add"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbSU)
    Me.GroupBox1.Controls.Add(Me.RbMV)
    Me.GroupBox1.Controls.Add(Me.RbPP)
    Me.GroupBox1.Controls.Add(Me.RbRE)
    Me.GroupBox1.Location = New System.Drawing.Point(3, 1)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(464, 32)
    Me.GroupBox1.TabIndex = 338
    Me.GroupBox1.TabStop = False
    '
    'RbSU
    '
    Me.RbSU.Location = New System.Drawing.Point(344, 8)
    Me.RbSU.Name = "RbSU"
    Me.RbSU.Size = New System.Drawing.Size(112, 16)
    Me.RbSU.TabIndex = 7
    Me.RbSU.Text = "S&upplemental MV"
    '
    'RbMV
    '
    Me.RbMV.Location = New System.Drawing.Point(232, 8)
    Me.RbMV.Name = "RbMV"
    Me.RbMV.Size = New System.Drawing.Size(96, 16)
    Me.RbMV.TabIndex = 6
    Me.RbMV.Text = "&Motor Vehicle"
    '
    'RbPP
    '
    Me.RbPP.Location = New System.Drawing.Point(104, 8)
    Me.RbPP.Name = "RbPP"
    Me.RbPP.Size = New System.Drawing.Size(120, 16)
    Me.RbPP.TabIndex = 5
    Me.RbPP.Text = "P&ersonal Property"
    '
    'RbRE
    '
    Me.RbRE.Checked = True
    Me.RbRE.Location = New System.Drawing.Point(8, 8)
    Me.RbRE.Name = "RbRE"
    Me.RbRE.Size = New System.Drawing.Size(88, 16)
    Me.RbRE.TabIndex = 4
    Me.RbRE.TabStop = True
    Me.RbRE.Text = "&Real Estate"
    '
    'FrmTX402B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(474, 441)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.BtnAdd)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtListNo)
    Me.Controls.Add(Me.GroupBox3)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX402B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Warning: Screen Data will not be saved upon program exit"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox3.ResumeLayout(False)
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

Private Sub FrmTX402B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	MyTXREALC = New TXREALC.mydata(MyDBConnect)
	MyTXPPRPC = New TXPPRPC.mydata(MyDBConnect)
	MyTXMVDC = New TXMVDC.mydata(MyDBConnect)
	MyTXSUPP = New TXSupp.mydata(MyDBConnect)

  LoadScrn = True

  BuildDs()
  FormatGrid()
  WrkType = "R"
  LoadScrn = False
  End Sub
  Private Sub RbRE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbRE.Click
     WrkType = "R"
  End Sub
  Private Sub RbPP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPP.Click
    WrkType = "P"
  End Sub
  Private Sub RbMV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbMV.Click
    WrkType = "M"
  End Sub
  Private Sub RbSU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbSU.Click
    WrkType = "S"
  End Sub
  Private Sub BuildDs()
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Name", Type.GetType("System.String"))
    End With
    myds.Tables.Add(myTable)

  End Sub
Sub AddOneRecord()
	Dim myDr As Data.DataRow
	Dim ListNo As Integer
	Dim WrkName As String

		ListNo = Val(TxtListNo.Text)
		WrkName = String.Empty
		Select Case WrkType
		Case "M"
			MyTXMVDC.GetOneRecordP(ListNo)
			If Not MyTXMVDC.RecordNotFound Then
				WrkName = Trim(MyTXMVDC._NAME)
			End If
		Case "P"
			MyTXPPRPC.GetOneRecordP(ListNo)
			If Not MyTXPPRPC.RecordNotFound Then
				WrkName = Trim(MyTXPPRPC._NAME)
			End If
		Case "R"
			MyTXREALC.GetOneRecordP(ListNo)
			If Not MyTXREALC.RecordNotFound Then
				WrkName = Trim(MyTXREALC._NAME)
			End If
		Case "S"
			MyTXSUPP.GetOneRecordP(ListNo)
			If Not MyTXSUPP.RecordNotFound Then
				WrkName = Trim(MyTXSUPP._NAME)
			End If
		End Select
		If WrkName <> String.Empty Then
			myDr = myds.Tables(0).NewRow
			myDr("ListNo") = Val(TxtListNo.Text)
			myDr("Type") = WrkType
			myDr("name") = WrkName
			myds.Tables(0).Rows.Add(myDr)
		Else
			MsgBox("Invalid List", MsgBoxStyle.Exclamation, "Cannot Add record")
			Exit Sub
		End If
		FormatGrid()
		TxtListNo.Text = ""
End Sub
  Private Sub FrmTX402B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

    MyFrmTX402.SbpScreen.Text = "TX402B"
    MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmTX402
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
Private Sub TxtListNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
  If Asc(e.KeyChar) = Keys.Return Then
    AddOneRecord()
    Exit Sub
  End If

  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Public Sub FormatGrid()
 Dim Style As DataGridViewCellStyle
 Call ShowGrid()

 With DataGrdView
   .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
   .RowHeadersWidth = 25
   .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
   Style = DataGrdView.ColumnHeadersDefaultCellStyle
   Style.Font = New Font(DataGrdView.Font, FontStyle.Regular)
   Style = DataGrdView.DefaultCellStyle
   Style.Font = New Font(DataGrdView.Font, FontStyle.Regular)
   .Columns(0).HeaderText = "List#"
   .Columns(0).Width = 50
   .Columns(1).HeaderText = "Type"
   .Columns(1).Width = 35
   .Columns(2).HeaderText = "Name"
   .Columns(2).Width = 195
 End With

End Sub
Public Sub ShowGrid()
'  Dim WrkView As DataView

'  WrkView = New DataView(myds.Tables(0), "", "ListNo DESC", DataViewRowState.CurrentRows)

  Windows.Forms.Cursor.Current = Cursors.WaitCursor

'  C1DataGrdList.DataSource = WrkView
  DataGrdView.DataSource = myds.Tables(0)
  DataGrdView.Refresh()
  Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
  AddOneRecord()
End Sub
Public Sub RemoveData()
  Dim row As Integer

  If DataGrdView.SelectedRows.Count > 0 Then
    For Each row In DataGrdView.SelectedRows
      myds.Tables(0).Rows(row).Delete()
      Exit For
    Next
  End If

End Sub
Public Sub PostUpdates()
	Dim ListNo As Integer
  Dim Type As String
	Dim I As Integer

  For I = 0 To (MyFrmTX402B.DataGrdView.Rows.Count - 1)
    ListNo = myds.Tables(0).Rows(I).Item("ListNo")
    Type = myds.Tables(0).Rows(I).Item("Type")
    Select Case Type
    Case "M"
      With MyTXMVDC
        .GetOneRecordP(ListNo)
        ._BTC = "BT"
        .UpdateOneRecordP()
      End With
    Case "P"
      With MyTXPPRPC
        .GetOneRecordP(ListNo)
        ._BTC = "BT"
        .UpdateOneRecordP()
      End With
    Case "R"
      With MyTXREALC
        .GetOneRecordP(ListNo)
        ._BTC = "BT"
        .UpdateOneRecordP()
      End With
    Case "S"
      With MyTXSUPP
        .GetOneRecordP(ListNo)
        ._BTC = "BT"
        .UpdateOneRecordP()
      End With
    End Select
  Next

  myds.Clear()
End Sub
End Class






