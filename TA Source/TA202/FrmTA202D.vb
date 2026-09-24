Public Class FrmTA202D
  Inherits System.Windows.Forms.Form
	Dim myTXLOCAL As TXLOCAL.myData
	Dim ds2 As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkType As String
  Friend WrkName As String
  Dim LoadScrn As Boolean
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents LblLocAmt As System.Windows.Forms.Label
  Friend WithEvents LnkCode As System.Windows.Forms.LinkLabel
	Friend WithEvents BtnReset As System.Windows.Forms.Button
	Friend WithEvents GrpFrztax As System.Windows.Forms.GroupBox
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents LblLocReq As System.Windows.Forms.Label
  Friend WithEvents DataGrdView As DataGridView
  Friend WithEvents LblYear As Label
  Friend WithEvents Label5 As Label
  Friend WithEvents TxtCode As System.Windows.Forms.TextBox
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
  Friend WithEvents LblName As System.Windows.Forms.Label
  Friend WithEvents LblListNo As System.Windows.Forms.Label
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TxtAmount As System.Windows.Forms.TextBox
Friend WithEvents BtnAdd As System.Windows.Forms.Button
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.LblName = New System.Windows.Forms.Label()
    Me.LblListNo = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtAmount = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.BtnAdd = New System.Windows.Forms.Button()
    Me.TxtCode = New System.Windows.Forms.TextBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.LblLocAmt = New System.Windows.Forms.Label()
    Me.LnkCode = New System.Windows.Forms.LinkLabel()
    Me.BtnReset = New System.Windows.Forms.Button()
    Me.GrpFrztax = New System.Windows.Forms.GroupBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.LblLocReq = New System.Windows.Forms.Label()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox3.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.GrpFrztax.SuspendLayout()
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
    Me.GroupBox3.Location = New System.Drawing.Point(24, 39)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(211, 268)
    Me.GroupBox3.TabIndex = 304
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Local Amounts"
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DataGrdView.Location = New System.Drawing.Point(6, 19)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(199, 242)
    Me.DataGrdView.TabIndex = 207
    '
    'LblName
    '
    Me.LblName.Location = New System.Drawing.Point(126, 12)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(280, 16)
    Me.LblName.TabIndex = 332
    Me.LblName.UseMnemonic = False
    '
    'LblListNo
    '
    Me.LblListNo.Location = New System.Drawing.Point(72, 12)
    Me.LblListNo.Name = "LblListNo"
    Me.LblListNo.Size = New System.Drawing.Size(48, 16)
    Me.LblListNo.TabIndex = 331
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(12, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(38, 16)
    Me.Label1.TabIndex = 330
    Me.Label1.Text = "List #"
    '
    'TxtAmount
    '
    Me.TxtAmount.Location = New System.Drawing.Point(243, 319)
    Me.TxtAmount.Name = "TxtAmount"
    Me.TxtAmount.Size = New System.Drawing.Size(48, 20)
    Me.TxtAmount.TabIndex = 335
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(187, 323)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(48, 16)
    Me.Label3.TabIndex = 336
    Me.Label3.Text = "Amount"
    '
    'BtnAdd
    '
    Me.BtnAdd.Location = New System.Drawing.Point(311, 319)
    Me.BtnAdd.Name = "BtnAdd"
    Me.BtnAdd.Size = New System.Drawing.Size(52, 20)
    Me.BtnAdd.TabIndex = 337
    Me.BtnAdd.Text = "Add"
    '
    'TxtCode
    '
    Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode.Location = New System.Drawing.Point(151, 319)
    Me.TxtCode.MaxLength = 2
    Me.TxtCode.Name = "TxtCode"
    Me.TxtCode.Size = New System.Drawing.Size(22, 20)
    Me.TxtCode.TabIndex = 338
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.Label12)
    Me.GroupBox2.Controls.Add(Me.LblLocAmt)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(243, 161)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(154, 39)
    Me.GroupBox2.TabIndex = 340
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Local Benefit Total"
    '
    'Label12
    '
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(12, 16)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(59, 17)
    Me.Label12.TabIndex = 154
    Me.Label12.Text = "Local Ben"
    '
    'LblLocAmt
    '
    Me.LblLocAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLocAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLocAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocAmt.Location = New System.Drawing.Point(72, 16)
    Me.LblLocAmt.Name = "LblLocAmt"
    Me.LblLocAmt.Size = New System.Drawing.Size(64, 16)
    Me.LblLocAmt.TabIndex = 153
    Me.LblLocAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LnkCode
    '
    Me.LnkCode.AutoSize = True
    Me.LnkCode.Location = New System.Drawing.Point(113, 323)
    Me.LnkCode.Name = "LnkCode"
    Me.LnkCode.Size = New System.Drawing.Size(32, 13)
    Me.LnkCode.TabIndex = 341
    Me.LnkCode.TabStop = True
    Me.LnkCode.Text = "Code"
    '
    'BtnReset
    '
    Me.BtnReset.Location = New System.Drawing.Point(270, 120)
    Me.BtnReset.Name = "BtnReset"
    Me.BtnReset.Size = New System.Drawing.Size(108, 35)
    Me.BtnReset.TabIndex = 342
    Me.BtnReset.Text = "Reset Total based on local amounts"
    '
    'GrpFrztax
    '
    Me.GrpFrztax.Controls.Add(Me.Label2)
    Me.GrpFrztax.Controls.Add(Me.LblLocReq)
    Me.GrpFrztax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpFrztax.Location = New System.Drawing.Point(243, 39)
    Me.GrpFrztax.Name = "GrpFrztax"
    Me.GrpFrztax.Size = New System.Drawing.Size(160, 39)
    Me.GrpFrztax.TabIndex = 343
    Me.GrpFrztax.TabStop = False
    Me.GrpFrztax.Text = "Local Frozen Tax"
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(12, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(59, 17)
    Me.Label2.TabIndex = 154
    Me.Label2.Text = "Local Ben"
    '
    'LblLocReq
    '
    Me.LblLocReq.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLocReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLocReq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocReq.Location = New System.Drawing.Point(72, 16)
    Me.LblLocReq.Name = "LblLocReq"
    Me.LblLocReq.Size = New System.Drawing.Size(64, 16)
    Me.LblLocReq.TabIndex = 153
    Me.LblLocReq.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblYear
    '
    Me.LblYear.Location = New System.Drawing.Point(66, 320)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(35, 16)
    Me.LblYear.TabIndex = 346
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(21, 320)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(39, 16)
    Me.Label5.TabIndex = 345
    Me.Label5.Text = "Year"
    '
    'FrmTA202D
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(409, 345)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.GrpFrztax)
    Me.Controls.Add(Me.BtnReset)
    Me.Controls.Add(Me.LnkCode)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.TxtCode)
    Me.Controls.Add(Me.BtnAdd)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtAmount)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LblListNo)
    Me.Controls.Add(Me.LblName)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA202D"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Maintain Local Benefit Amounts"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox3.ResumeLayout(False)
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.GrpFrztax.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTA202D_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXLOCAL = New TXLOCAL.mydata(MyDBConnect)

    LoadScrn = True
    MyFrmTA202.TBarSave.Enabled = False
    MyFrmTA202.TBarDelete.Enabled = False
    LblListNo.Text = WrkListNo
    LblYear.Text = WrkYear
    LblName.Text = WrkName
    LblLocAmt.Text = MyFrmTA202C.LblLocAmt.Text
    If MyUtils.CnvSng(MyFrmTA202C.TxtLocFrzTax.Text) > 0 Then
      LblLocReq.Text = MyFrmTA202C.LblLocAmt.Text
    Else
      GrpFrztax.Visible = False
    End If

    FormatGrid()
    LoadScrn = False
  End Sub
  Private Sub FrmTA202D_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTA202.TBarSave.Enabled = True
    MyFrmTA202C.LblLocAmt.Text = LblLocAmt.Text
    MyFrmTA202C.CalcLocal()
    MyFrmTA202C.Show()
  End Sub
  Public Sub SaveData()
    Dim Answer As Integer
    Dim ErrorField(50) As String
    Dim ErrorMsg(50) As String

    SetCodeTip()

    If MyLocEld = "032" Or MyLocEld = "045" Then
      Answer = MsgBox("WARNING: Note that M35H local for list # should not be added here",
      MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirm Local add")
      If Answer = MsgBoxResult.Cancel Then Exit Sub
    End If

    myTXLOCAL.GetOneRecordP(WrkListNo, MyGLYear, WrkType, TxtCode.Text)
    If myTXLOCAL.RecordNotFound Then
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXLOCAL.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      MsgBox("Record already exists", MsgBoxStyle.Exclamation, "Add cancelled")
    End If

    lblYear.Text = ""
    TxtCode.Text = ""
    TxtAmount.Text = ""
    FormatGrid()
  End Sub
  Private Sub MoveToFile()
    With myTXLOCAL
      ._LISTNo = MyUtils.CnvSng(LblListNo.Text)
      ._YEAR = MyUtils.CnvSng(lblYear.Text)
      ._TYPE = WrkType
      ._BENCDE = TxtCode.Text
      ._BENAMT = MyUtils.CnvSng(TxtAmount.Text)
    End With

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.Clear()

    For I = 0 To ErrorField.GetUpperBound(0)
      Me.ForeColor = Color.DarkRed
      Select Case ErrorField(I)
        Case "benamt"
          ErrProv.SetError(TxtAmount, ErrorMsg(I))
        Case "code"
          ErrProv.SetError(TxtCode, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim WrkTip As String
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    WrkTip = Ttp1.GetToolTip(TxtCode)
    If Mid(WrkTip, 1, 1) = "*" Then
      ErrorField(I) = "code"
      ErrorMsg(I) = "Invalid Local Code"
      I = I + 1
    End If

    If TxtCode.Text = "" Then
      ErrorField(I) = "code"
      ErrorMsg(I) = "Local Code cannot be blank"
      I = I + 1
    End If

    If TxtAmount.Text = "" Then
      ErrorField(I) = "benamt"
      ErrorMsg(I) = "Benefit Amount cannot be 0"
      I = I + 1
    End If

  End Sub
  Private Sub FrmTA202D_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

    MyFrmTA202.SbpScreen.Text = "TA202D"
    MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmTA202
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub TxtAmount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAmount.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Public Sub FormatGrid()
    Call ShowGrid()

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).Visible = False
      .Columns(1).HeaderText = "Year"
      .Columns(1).Width = 40
      .Columns(2).Visible = False
      .Columns(3).HeaderText = "Code"
      .Columns(3).Width = 50
      .Columns(4).HeaderText = "Amount"
      .Columns(4).Width = 60
    End With

  End Sub
  Public Sub ShowGrid()
    Dim ds3 As DataSet = New DataSet
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    ds2 = myTXLOCAL.GetViewbyList(WrkListNo, MyGLYear, "R", 100)
    If ds2.Tables(0).Rows.Count = 0 Then
      ds3 = myTXLOCAL.GetViewbyList(WrkListNo, MyGLYear - 1, "R", 100)
      ds2.Merge(ds3)
    End If
    DataGrdView.DataSource = ds2.Tables(0)
    DataGrdView.Refresh()
    Windows.Forms.Cursor.Current = Cursors.Default
    CalcLocAmt()
    ds3.Clear()
  End Sub
  Private Sub CalcLocAmt()
    Dim WrkLocAmt As Decimal
    Dim I As Integer

    WrkLocAmt = 0
    If ds2.Tables(0).Rows.Count > 0 Then
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        WrkLocAmt = WrkLocAmt + ds2.Tables(0).Rows(I).Item("benamt")
      Next
    End If

    LblLocAmt.Text = MyUtils.FmtCurrency(WrkLocAmt)
    ErrProv.SetError(LblLocAmt, "")
    If MyUtils.CnvSng(LblLocReq.Text) > 0 Then
      If MyUtils.CnvSng(LblLocReq.Text) <> MyUtils.CnvSng(LblLocAmt.Text) Then
        ErrProv.SetError(LblLocAmt, "Local Benefit Total must match Local Frozen Tax Benefit")
      End If
    End If
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    MyFrmTA202E = New FrmTA202E

    MyFrmTA202E.WrkListNo = WrkListNo
    MyFrmTA202E.WrkYear = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
    MyFrmTA202E.WrkType = DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value
    MyFrmTA202E.WrkCode = DataGrdView.Item(3, DataGrdView.CurrentRow.Index).Value
    MyFrmTA202E.MdiParent = Me.ParentForm
    MyFrmTA202E.Show()
    Me.Hide()

  End Sub
  Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
  SaveData()
End Sub
Private Sub LnkCode_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode.LinkClicked
  MyFrmListLocalCodes = New FrmListLocalCodes
  MyFrmListLocalCodes.MdiParent = Me.ParentForm
  MyFrmListLocalCodes.WrkCode = TxtCode.Text
  MyFrmListLocalCodes.Show()
End Sub
Private Sub SetCodeTip()
    Dim WrkDesc As String

    If Not TxtCode.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXloccdDesc(TxtCode.Text)
    Ttp1.SetToolTip(TxtCode, WrkDesc)
End Sub
Private Sub BtnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReset.Click
  CalcLocAmt()
End Sub
End Class






