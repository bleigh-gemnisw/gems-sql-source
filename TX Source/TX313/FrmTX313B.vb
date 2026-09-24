Public Class FrmTX313B
  Inherits System.Windows.Forms.Form
  Dim MyTXINV As TXINV.myData
  Friend WithEvents LnkType As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtType As System.Windows.Forms.TextBox
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents LnkStatusCD As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtStatusCD As System.Windows.Forms.TextBox
  Friend WithEvents DataGrdView As DataGridView
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
    Me.LnkType = New System.Windows.Forms.LinkLabel()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.LnkStatusCD = New System.Windows.Forms.LinkLabel()
    Me.TxtStatusCD = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox3.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
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
    Me.GroupBox3.Location = New System.Drawing.Point(55, 35)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(376, 368)
    Me.GroupBox3.TabIndex = 304
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "List #'s to coded with Status Code"
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DataGrdView.Location = New System.Drawing.Point(6, 16)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(364, 346)
    Me.DataGrdView.TabIndex = 431
    '
    'TxtListNo
    '
    Me.TxtListNo.Location = New System.Drawing.Point(116, 409)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(62, 20)
    Me.TxtListNo.TabIndex = 1
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(73, 413)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(37, 16)
    Me.Label3.TabIndex = 336
    Me.Label3.Text = "List #"
    '
    'BtnAdd
    '
    Me.BtnAdd.Location = New System.Drawing.Point(362, 409)
    Me.BtnAdd.Name = "BtnAdd"
    Me.BtnAdd.Size = New System.Drawing.Size(52, 20)
    Me.BtnAdd.TabIndex = 4
    Me.BtnAdd.Text = "Add"
    '
    'LnkType
    '
    Me.LnkType.Location = New System.Drawing.Point(184, 409)
    Me.LnkType.Name = "LnkType"
    Me.LnkType.Size = New System.Drawing.Size(32, 16)
    Me.LnkType.TabIndex = 342
    Me.LnkType.TabStop = True
    Me.LnkType.Text = "Type"
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtType.Location = New System.Drawing.Point(224, 409)
    Me.TxtType.MaxLength = 1
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(16, 20)
    Me.TxtType.TabIndex = 2
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(307, 409)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtYear.TabIndex = 3
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(267, 409)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(32, 16)
    Me.Label1.TabIndex = 340
    Me.Label1.Text = "Year"
    '
    'LnkStatusCD
    '
    Me.LnkStatusCD.Location = New System.Drawing.Point(184, 9)
    Me.LnkStatusCD.Name = "LnkStatusCD"
    Me.LnkStatusCD.Size = New System.Drawing.Size(72, 16)
    Me.LnkStatusCD.TabIndex = 344
    Me.LnkStatusCD.TabStop = True
    Me.LnkStatusCD.Text = "Status Code"
    '
    'TxtStatusCD
    '
    Me.TxtStatusCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtStatusCD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtStatusCD.Location = New System.Drawing.Point(256, 9)
    Me.TxtStatusCD.Name = "TxtStatusCD"
    Me.TxtStatusCD.Size = New System.Drawing.Size(24, 20)
    Me.TxtStatusCD.TabIndex = 0
    '
    'FrmTX313B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(474, 441)
    Me.ControlBox = False
    Me.Controls.Add(Me.LnkStatusCD)
    Me.Controls.Add(Me.TxtStatusCD)
    Me.Controls.Add(Me.LnkType)
    Me.Controls.Add(Me.TxtType)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnAdd)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtListNo)
    Me.Controls.Add(Me.GroupBox3)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX313B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Warning: Screen Data will not be saved upon program exit"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox3.ResumeLayout(False)
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTX313B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXINV = New TXINV.mydata(MyDBConnect)

    LoadScrn = True

    BuildDs()
    FormatGrid()
    LoadScrn = False
  End Sub
  Private Sub BuildDs()
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("ErrMsg", Type.GetType("System.String"))
    End With
    myds.Tables.Add(myTable)
  End Sub
  Sub AddOneRecord()
    Dim myDr As Data.DataRow
    Dim WrkStCd(4) As String

    MyTXINV.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text), MyUtils.CnvSng(TxtYear.Text), TxtType.Text)
    If Not MyTXINV.RecordNotFound Then
      myDr = myds.Tables(0).NewRow
      myDr("ListNo") = MyUtils.CnvSng(TxtListNo.Text)
      myDr("Type") = TxtType.Text
      myDr("Year") = MyUtils.CnvSng(TxtYear.Text)
      With MyTXINV
        myDr("name") = Trim(._NAME)
      End With
      myds.Tables(0).Rows.Add(myDr)
    Else
      MsgBox("Invalid List/Type/Year", MsgBoxStyle.Exclamation, "Cannot Add record")
      Exit Sub
    End If

    FormatGrid()
    TxtListNo.Text = ""
    TxtYear.Text = ""
    TxtType.Text = ""
    TxtListNo.Focus()
  End Sub
  Private Sub FrmTX313B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

    MyFrmTX313.SbpScreen.Text = "TX313B"
    MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmTX313
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub TxtListNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      MyUtils.KeyEnter_isTab(Me, e)
      Exit Sub
    End If

    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub LnkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkType.LinkClicked
    MyFrmListTypes = New FrmListTypes
    MyFrmListTypes.MdiParent = Me.ParentForm
    MyFrmListTypes.WrkType = TxtType.Text
    MyFrmListTypes.Show()
  End Sub
  Private Sub TxtType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtType.KeyPress
    'Move to next field after anything has been typed since it's only 1 char allowed
    Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
  End Sub
  Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      AddOneRecord()
      Exit Sub
    End If

    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Public Sub FormatGrid()
    Call ShowGrid()

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "List #"
      .Columns(0).Width = 50
      .Columns(1).HeaderText = "Type"
      .Columns(1).Width = 30
      .Columns(2).HeaderText = "Year"
      .Columns(2).Width = 40
      .Columns(3).HeaderText = "Name"
      .Columns(3).Width = 200
      .Columns(4).Visible = False
    End With

  End Sub
  Public Sub ShowGrid()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

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
    Dim WrkListNo As Integer
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkMsg As String
    Dim WrkStCd(4) As String
    Dim I As Integer

    For I = 0 To (MyFrmTX313B.DataGrdView.Rows.Count - 1)
      WrkListNo = myds.Tables(0).Rows(I).Item("ListNo")
      WrkType = myds.Tables(0).Rows(I).Item("Type")
      WrkYear = myds.Tables(0).Rows(I).Item("Year")
      MyTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
      With MyTXINV
        WrkStCd(0) = Trim(._STCD1)
        WrkStCd(1) = Trim(._STCD2)
        WrkStCd(2) = Trim(._STCD3)
        WrkStCd(3) = Trim(._STCD4)
        WrkStCd(4) = Trim(._STCD5)
        WrkMsg = UpdateStatusCD(WrkStCd)
        If WrkMsg <> "" Then
          myds.Tables(0).Rows(I).Item("ErrMsg") = WrkMsg
        End If
        ._STCD1 = WrkStCd(0)
        ._STCD2 = WrkStCd(1)
        ._STCD3 = WrkStCd(2)
        ._STCD4 = WrkStCd(3)
        ._STCD5 = WrkStCd(4)
        .UpdateOneRecordP()
      End With
    Next

  End Sub
  Private Function UpdateStatusCD(ByRef WrkStCd() As String) As String
    Dim WrkMsg As String
    Dim J As Integer
    Dim Found As Boolean

    Found = False
    WrkMsg = ""

    For J = 0 To 4
      If WrkStCd(J) = TxtStatusCD.Text Then
        Return "Status already on record"
      End If

      If WrkStCd(J) = "" Then
        WrkStCd(J) = TxtStatusCD.Text
        Return ""
      End If
    Next

    Return "No room for another status"
  End Function
  Private Sub LnkStatusCD_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkStatusCD.LinkClicked
    MyFrmListSts = New FrmListSts
    MyFrmListSts.MdiParent = Me.ParentForm
    MyFrmListSts.WrkCode = TxtStatusCD.Text
    MyFrmListSts.Show()
  End Sub
End Class






