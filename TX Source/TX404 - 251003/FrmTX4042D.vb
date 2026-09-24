Public Class FrmTX4042D
  Inherits System.Windows.Forms.Form
  Dim MyTXINV As TXINV.MyData
  Dim MyTXHST As TXHST.MyData
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtComment As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents DtPckAsof As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label3 As Label
  Friend WithEvents ChkMVUnflag As CheckBox
  Friend WithEvents TxtAmount As System.Windows.Forms.TextBox

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
  Friend WithEvents RbStatusAdd As System.Windows.Forms.RadioButton
  Friend WithEvents RbStatusRemove As System.Windows.Forms.RadioButton
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents TbMain As System.Windows.Forms.ToolBar
  Friend WithEvents TxtFeeCD As System.Windows.Forms.TextBox
  Friend WithEvents LnkFeeCD As System.Windows.Forms.LinkLabel
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  Friend WithEvents TBarAll As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarRow As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarReturn As System.Windows.Forms.ToolBarButton
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTX4042D))
    Me.TxtFeeCD = New System.Windows.Forms.TextBox()
    Me.RbStatusAdd = New System.Windows.Forms.RadioButton()
    Me.RbStatusRemove = New System.Windows.Forms.RadioButton()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarReturn = New System.Windows.Forms.ToolBarButton()
    Me.TBarAll = New System.Windows.Forms.ToolBarButton()
    Me.TBarRow = New System.Windows.Forms.ToolBarButton()
    Me.LnkFeeCD = New System.Windows.Forms.LinkLabel()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.TxtAmount = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtComment = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.DtPckAsof = New System.Windows.Forms.DateTimePicker()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.ChkMVUnflag = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TxtFeeCD
    '
    Me.TxtFeeCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFeeCD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFeeCD.Location = New System.Drawing.Point(80, 16)
    Me.TxtFeeCD.MaxLength = 2
    Me.TxtFeeCD.Name = "TxtFeeCD"
    Me.TxtFeeCD.Size = New System.Drawing.Size(25, 20)
    Me.TxtFeeCD.TabIndex = 1
    '
    'RbStatusAdd
    '
    Me.RbStatusAdd.Checked = True
    Me.RbStatusAdd.Location = New System.Drawing.Point(248, 2)
    Me.RbStatusAdd.Name = "RbStatusAdd"
    Me.RbStatusAdd.Size = New System.Drawing.Size(48, 16)
    Me.RbStatusAdd.TabIndex = 2
    Me.RbStatusAdd.TabStop = True
    Me.RbStatusAdd.Text = "A&dd"
    '
    'RbStatusRemove
    '
    Me.RbStatusRemove.Location = New System.Drawing.Point(248, 24)
    Me.RbStatusRemove.Name = "RbStatusRemove"
    Me.RbStatusRemove.Size = New System.Drawing.Size(72, 16)
    Me.RbStatusRemove.TabIndex = 3
    Me.RbStatusRemove.Text = "Re&move"
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.White
    Me.ImageList1.Images.SetKeyName(0, "")
    Me.ImageList1.Images.SetKeyName(1, "")
    Me.ImageList1.Images.SetKeyName(2, "")
    '
    'TbMain
    '
    Me.TbMain.Anchor = System.Windows.Forms.AnchorStyles.Bottom
    Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarReturn, Me.TBarAll, Me.TBarRow})
    Me.TbMain.Dock = System.Windows.Forms.DockStyle.None
    Me.TbMain.DropDownArrows = True
    Me.TbMain.ImageList = Me.ImageList1
    Me.TbMain.Location = New System.Drawing.Point(17, 294)
    Me.TbMain.Name = "TbMain"
    Me.TbMain.ShowToolTips = True
    Me.TbMain.Size = New System.Drawing.Size(208, 50)
    Me.TbMain.TabIndex = 6
    '
    'TBarReturn
    '
    Me.TBarReturn.ImageIndex = 0
    Me.TBarReturn.Name = "TBarReturn"
    Me.TBarReturn.Text = "&Return"
    '
    'TBarAll
    '
    Me.TBarAll.ImageIndex = 1
    Me.TBarAll.Name = "TBarAll"
    Me.TBarAll.Text = "Update &All"
    '
    'TBarRow
    '
    Me.TBarRow.ImageIndex = 2
    Me.TBarRow.Name = "TBarRow"
    Me.TBarRow.Text = "Update R&ow"
    '
    'LnkFeeCD
    '
    Me.LnkFeeCD.Location = New System.Drawing.Point(6, 18)
    Me.LnkFeeCD.Name = "LnkFeeCD"
    Me.LnkFeeCD.Size = New System.Drawing.Size(72, 16)
    Me.LnkFeeCD.TabIndex = 0
    Me.LnkFeeCD.TabStop = True
    Me.LnkFeeCD.Text = "Fee Code"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowUpdate = False
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(9, 93)
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    Me.C1DataGrdList.Size = New System.Drawing.Size(733, 195)
    Me.C1DataGrdList.TabIndex = 193
    '
    'TxtAmount
    '
    Me.TxtAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAmount.Location = New System.Drawing.Point(179, 18)
    Me.TxtAmount.MaxLength = 8
    Me.TxtAmount.Name = "TxtAmount"
    Me.TxtAmount.Size = New System.Drawing.Size(51, 20)
    Me.TxtAmount.TabIndex = 194
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(130, 21)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(43, 13)
    Me.Label1.TabIndex = 195
    Me.Label1.Text = "Amount"
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(12, 56)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(62, 17)
    Me.Label2.TabIndex = 209
    Me.Label2.Text = "Comment"
    '
    'TxtComment
    '
    Me.TxtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtComment.Location = New System.Drawing.Point(80, 53)
    Me.TxtComment.MaxLength = 20
    Me.TxtComment.Name = "TxtComment"
    Me.TxtComment.Size = New System.Drawing.Size(126, 20)
    Me.TxtComment.TabIndex = 206
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(229, 56)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(40, 16)
    Me.Label5.TabIndex = 208
    Me.Label5.Text = "Date"
    '
    'DtPckAsof
    '
    Me.DtPckAsof.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckAsof.Location = New System.Drawing.Point(275, 53)
    Me.DtPckAsof.Name = "DtPckAsof"
    Me.DtPckAsof.Size = New System.Drawing.Size(88, 20)
    Me.DtPckAsof.TabIndex = 207
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(326, 16)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(35, 13)
    Me.Label3.TabIndex = 210
    Me.Label3.Text = "- OR -"
    '
    'ChkMVUnflag
    '
    Me.ChkMVUnflag.AutoSize = True
    Me.ChkMVUnflag.Location = New System.Drawing.Point(379, 17)
    Me.ChkMVUnflag.Name = "ChkMVUnflag"
    Me.ChkMVUnflag.Size = New System.Drawing.Size(131, 17)
    Me.ChkMVUnflag.TabIndex = 213
    Me.ChkMVUnflag.Text = "Remove MV Fee/Flag"
    '
    'FrmTX4042D
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(754, 353)
    Me.Controls.Add(Me.ChkMVUnflag)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtComment)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.DtPckAsof)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtAmount)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.Controls.Add(Me.LnkFeeCD)
    Me.Controls.Add(Me.TbMain)
    Me.Controls.Add(Me.RbStatusRemove)
    Me.Controls.Add(Me.RbStatusAdd)
    Me.Controls.Add(Me.TxtFeeCD)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX4042D"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Change Fee Code"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub LnkFeeCD_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFeeCD.LinkClicked
    MyFrmListPenCd = New FrmListPenCd
    MyFrmListPenCd.MdiParent = Me.ParentForm
    MyFrmListPenCd.WrkCode = TxtFeeCD.Text
    MyFrmListPenCd.Show()
  End Sub
  Private Sub TxtFeeCD_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFeeCD.Leave
    Dim WrkDesc As String

    If Not TxtFeeCD.Modified Then Exit Sub

    WrkDesc = GetTXPenDesc(TxtFeeCD.Text)
    Ttp1.SetToolTip(TxtFeeCD, WrkDesc)

  End Sub

  Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    If e.Button Is TBarReturn Then
      Me.Close()
    End If

    EditChecks(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If

    If e.Button Is TBarAll Then
      UpdateDS()
    End If

    If e.Button Is TBarRow Then
      UpdateRow()
    End If

    TxtFeeCD.Text = String.Empty
    TxtAmount.Text = String.Empty
    TxtComment.Text = String.Empty
    'MK 8/13/25 Begin
    ChkMVUnflag.Checked = False
    'MK 8/13/25 End
    ErrProv.SetError(TxtFeeCD, String.Empty)
  End Sub
  Private Sub UpdateDS()
    Dim ListNo As Integer
    Dim Year As Integer
    Dim Type As String
    Dim I As Integer
    Dim J As Integer
    Dim WrkFeeCd(4) As String
    Dim WrkFeeAmt(4) As Decimal
    Dim WrkMVFee As Decimal
    Dim WrkFees As Decimal
    Dim WrkWhere As String
    Dim WrkSet As String
    Dim Good As Boolean

    'MK 8/13/25 Begin
    'If TxtFeeCD.Text = "" Then Exit Sub
    'MK 8/13/25 End
    For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
      ListNo = myds.Tables(0).Rows(I).Item("ListNo")
      Year = myds.Tables(0).Rows(I).Item("Year")
      Type = myds.Tables(0).Rows(I).Item("Type")
      MyTXINV.GetOneRecordP(ListNo, Year, Type)
      'MK 8/13/25 Begin
      If TxtFeeCD.Text = "" Then
        If ChkMVUnflag.Checked And myds.Tables(0).Rows(I).Item("mvfee") > 0 Then
          With myds.Tables(0).Rows(I)
            .Item("fees") = Format(.Item("fees") - .Item("mvfee"), "fixed")
            .Item("mvfee") = 0
            .Item("Balance") = Format(.Item("amtdue") + .Item("Interest") + .Item("fees") + .Item("liens") + .Item("bond"), "fixed")
          End With
          WrkSet = " set mvflag=''"
          WrkWhere = " where list#=" & ListNo & " and year=" & Year & " and type='" & Type & "'"
          MyTXINV.RunUpdateQuery(WrkSet, WrkWhere)
          WriteHistory(ListNo, Year, Type)
        End If
      Else
        'MK 8/13/25 End
        With myds.Tables(0).Rows(I)
          WrkFeeCd(0) = .Item("fec1")
          WrkFeeCd(1) = .Item("fec2")
          WrkFeeCd(2) = .Item("fec3")
          WrkFeeCd(3) = .Item("fec4")
          WrkFeeCd(4) = .Item("fec5")
          WrkFeeAmt(0) = .Item("fed1")
          WrkFeeAmt(1) = .Item("fed2")
          WrkFeeAmt(2) = .Item("fed3")
          WrkFeeAmt(3) = .Item("fed4")
          WrkFeeAmt(4) = .Item("fed5")
          WrkMVFee = .Item("mvfee")
          Good = UpdateFeeCD(WrkFeeCd, WrkFeeAmt)
          If Good Then
            WrkFees = 0
            For J = 0 To 4
              WrkFees = WrkFees + WrkFeeAmt(J)
            Next
            WrkFees = WrkFees + WrkMVFee
            If .Item("amtdue") > 0 Then
              .Item("fees") = Format(WrkFees, "fixed")
            Else
              .Item("fees") = Format(0, "fixed")
            End If
            .Item("fec1") = WrkFeeCd(0)
            .Item("fec2") = WrkFeeCd(1)
            .Item("fec3") = WrkFeeCd(2)
            .Item("fec4") = WrkFeeCd(3)
            .Item("fec5") = WrkFeeCd(4)
            .Item("fed1") = Format(WrkFeeAmt(0), "fixed")
            .Item("fed2") = Format(WrkFeeAmt(1), "fixed")
            .Item("fed3") = Format(WrkFeeAmt(2), "fixed")
            .Item("fed4") = Format(WrkFeeAmt(3), "fixed")
            .Item("fed5") = Format(WrkFeeAmt(4), "fixed")
            .Item("Balance") = Format(.Item("amtdue") + .Item("Interest") + .Item("fees") + .Item("liens") + .Item("bond"), "fixed")
            MyTXINV._FEC1 = WrkFeeCd(0)
            WrkSet = " set fec1='" & MyTXINV._FEC1 & "'"
            MyTXINV._FEC2 = WrkFeeCd(1)
            WrkSet = WrkSet & ",fec2='" & MyTXINV._FEC2 & "'"
            MyTXINV._FEC3 = WrkFeeCd(2)
            WrkSet = WrkSet & ",fec3='" & MyTXINV._FEC3 & "'"
            MyTXINV._FEC4 = WrkFeeCd(3)
            WrkSet = WrkSet & ",fec4='" & MyTXINV._FEC4 & "'"
            MyTXINV._FEC5 = WrkFeeCd(4)
            WrkSet = WrkSet & ",fec5='" & MyTXINV._FEC5 & "'"
            MyTXINV._FED1 = WrkFeeAmt(0)
            WrkSet = WrkSet & ",fed1=" & MyTXINV._FED1
            MyTXINV._FED2 = WrkFeeAmt(1)
            WrkSet = WrkSet & ",fed2=" & MyTXINV._FED2
            MyTXINV._FED3 = WrkFeeAmt(2)
            WrkSet = WrkSet & ",fed3=" & MyTXINV._FED3
            MyTXINV._FED4 = WrkFeeAmt(3)
            WrkSet = WrkSet & ",fed4=" & MyTXINV._FED4
            MyTXINV._FED5 = WrkFeeAmt(4)
            WrkSet = WrkSet & ",fed5=" & MyTXINV._FED5
            MyTXINV._CHDATE = MyUtils.SetDBDate(DateTime.Today)
            WrkSet = WrkSet & ",chdate=" & MyTXINV._CHDATE
            MyTXINV._CHTIME = Format(DateTime.Now, "HHmmss")
            WrkSet = WrkSet & ",chtime=" & MyTXINV._CHTIME
            'MyTXINV.UpdateOneRecordP()
            WrkWhere = " where list#=" & ListNo & " and year=" & Year & " and type='" & Type & "'"
            MyTXINV.RunUpdateQuery(WrkSet, WrkWhere)
            WriteHistory(ListNo, Year, Type)
          End If
        End With
        'MK 8/13/25 Begin
      End If
      'MK 8/13/25 End
    Next
    MyFrmTX4042.CalcTotals()
  End Sub
  Private Sub UpdateRow()
    Dim ListNo As Integer
    Dim Year As Integer
    Dim Type As String
    Dim I As Integer
    Dim J As Integer
    Dim WrkFeeCd(4) As String
    Dim WrkFeeAmt(4) As Decimal
    Dim WrkMVFee As Decimal
    Dim WrkFees As Decimal
    Dim WrkWhere As String
    Dim WrkSet As String
    Dim Good As Boolean

    'MK 8/13/25 Begin
    'If TxtFeeCD.Text = "" Then Exit Sub
    'MK 8/13/25 End

    For Each I In C1DataGrdList.SelectedRows
      ListNo = myds.Tables(0).Rows(I).Item("ListNo")
      Year = myds.Tables(0).Rows(I).Item("Year")
      Type = myds.Tables(0).Rows(I).Item("Type")
      MyTXINV.GetOneRecordP(ListNo, Year, Type)
      'MK 8/13/25 Begin
      If TxtFeeCD.Text = "" Then
        If ChkMVUnflag.Checked And myds.Tables(0).Rows(I).Item("mvfee") > 0 Then
          With myds.Tables(0).Rows(I)
            .Item("fees") = Format(.Item("fees") - .Item("mvfee"), "fixed")
            .Item("mvfee") = 0
            .Item("Balance") = Format(.Item("amtdue") + .Item("Interest") + .Item("fees") + .Item("liens") + .Item("bond"), "fixed")
          End With
          WrkSet = " set mvflag=''"
          WrkWhere = " where list#=" & ListNo & " and year=" & Year & " and type='" & Type & "'"
          MyTXINV.RunUpdateQuery(WrkSet, WrkWhere)
          WriteHistory(ListNo, Year, Type)
        End If
      Else
        'MK 8/13/25 End
        With myds.Tables(0).Rows(I)
          WrkFeeCd(0) = .Item("fec1")
          WrkFeeCd(1) = .Item("fec2")
          WrkFeeCd(2) = .Item("fec3")
          WrkFeeCd(3) = .Item("fec4")
          WrkFeeCd(4) = .Item("fec5")
          WrkFeeAmt(0) = .Item("fed1")
          WrkFeeAmt(1) = .Item("fed2")
          WrkFeeAmt(2) = .Item("fed3")
          WrkFeeAmt(3) = .Item("fed4")
          WrkFeeAmt(4) = .Item("fed5")
          WrkMVFee = .Item("mvfee")
          Good = UpdateFeeCD(WrkFeeCd, WrkFeeAmt)
          If Good Then
            WrkFees = 0
            For J = 0 To 4
              WrkFees = WrkFees + WrkFeeAmt(J)
            Next
            WrkFees = WrkFees + WrkMVFee
            If .Item("amtdue") > 0 Then
              .Item("fees") = Format(WrkFees, "fixed")
            Else
              .Item("fees") = Format(0, "fixed")
            End If
            .Item("fec1") = WrkFeeCd(0)
            .Item("fec2") = WrkFeeCd(1)
            .Item("fec3") = WrkFeeCd(2)
            .Item("fec4") = WrkFeeCd(3)
            .Item("fec5") = WrkFeeCd(4)
            .Item("fed1") = Format(WrkFeeAmt(0), "fixed")
            .Item("fed2") = Format(WrkFeeAmt(1), "fixed")
            .Item("fed3") = Format(WrkFeeAmt(2), "fixed")
            .Item("fed4") = Format(WrkFeeAmt(3), "fixed")
            .Item("fed5") = Format(WrkFeeAmt(4), "fixed")
            .Item("Balance") = Format(.Item("amtdue") + .Item("Interest") + .Item("fees") + .Item("liens") + .Item("bond"), "fixed")
            MyTXINV._FEC1 = WrkFeeCd(0)
            WrkSet = " set fec1='" & MyTXINV._FEC1 & "'"
            MyTXINV._FEC2 = WrkFeeCd(1)
            WrkSet = WrkSet & ",fec2='" & MyTXINV._FEC2 & "'"
            MyTXINV._FEC3 = WrkFeeCd(2)
            WrkSet = WrkSet & ",fec3='" & MyTXINV._FEC3 & "'"
            MyTXINV._FEC4 = WrkFeeCd(3)
            WrkSet = WrkSet & ",fec4='" & MyTXINV._FEC4 & "'"
            MyTXINV._FEC5 = WrkFeeCd(4)
            WrkSet = WrkSet & ",fec5='" & MyTXINV._FEC5 & "'"
            MyTXINV._FED1 = WrkFeeAmt(0)
            WrkSet = WrkSet & ",fed1=" & MyTXINV._FED1
            MyTXINV._FED2 = WrkFeeAmt(1)
            WrkSet = WrkSet & ",fed2=" & MyTXINV._FED2
            MyTXINV._FED3 = WrkFeeAmt(2)
            WrkSet = WrkSet & ",fed3=" & MyTXINV._FED3
            MyTXINV._FED4 = WrkFeeAmt(3)
            WrkSet = WrkSet & ",fed4=" & MyTXINV._FED4
            MyTXINV._FED5 = WrkFeeAmt(4)
            WrkSet = WrkSet & ",fed5=" & MyTXINV._FED5
            MyTXINV._CHDATE = MyUtils.SetDBDate(DateTime.Today)
            WrkSet = WrkSet & ",chdate=" & MyTXINV._CHDATE
            MyTXINV._CHTIME = Format(DateTime.Now, "HHmmss")
            WrkSet = WrkSet & ",chtime=" & MyTXINV._CHTIME
            'MyTXINV.UpdateOneRecordP()
            WrkWhere = " where list#=" & ListNo & " and year=" & Year & " and type='" & Type & "'"
            MyTXINV.RunUpdateQuery(WrkSet, WrkWhere)
            WriteHistory(ListNo, Year, Type)
          End If
        End With
        'MK 8/13/25 Begin
      End If
      'MK 8/13/25 End
    Next
    MyFrmTX4042.CalcTotals()
  End Sub
  Private Sub FrmTX4042D_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    Me.Dispose()
  End Sub
  Private Sub FrmTX4042D_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXINV = New TXINV.MyData(myDBConnect)
    MyTXHST = New TXHST.MyData(myDBConnect)
    MyFrmTX404.TBarBack.Enabled = False
    MyFrmTX404.TBarPrint.Enabled = False
    MyFrmTX404.TBarSetPrinter.Enabled = False
    MyFrmTX404.TBarSettings.Enabled = False
    DtPckAsof.Value = Date.Today
    If Not MyStatusHistory Then
      TxtComment.Enabled = False
      DtPckAsof.Enabled = False
    End If
    ShowGrid()
  End Sub
  Public Sub ShowGrid()
    Dim I As Integer
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    With C1DataGrdList
      .DataSource = myds.Tables(0)
      .Refresh()
      .Splits(0).DisplayColumns(0).Visible = False
      .Columns(1).Caption = "List#"
      .Splits(0).DisplayColumns(1).Width = 45
      .Splits(0).DisplayColumns(1).Style.BackColor = Color.Cyan
      .Splits(0).DisplayColumns(2).Width = 30
      .Splits(0).DisplayColumns(2).Style.BackColor = Color.Cyan
      .Splits(0).DisplayColumns(3).Visible = False
      .Splits(0).DisplayColumns(4).Width = 30
      .Splits(0).DisplayColumns(4).Style.BackColor = Color.Cyan
      For I = 5 To 9
        .Splits(0).DisplayColumns(I).Visible = False
      Next
      .Columns(10).Caption = "Tot Fee"
      .Splits(0).DisplayColumns(10).Width = 50
      For I = 11 To 29
        .Splits(0).DisplayColumns(I).Visible = False
      Next
      .Columns(30).Caption = "Code 1"
      .Splits(0).DisplayColumns(30).Width = 45
      .Columns(31).Caption = "Code 2"
      .Splits(0).DisplayColumns(31).Width = 45
      .Columns(32).Caption = "Code 3"
      .Splits(0).DisplayColumns(32).Width = 45
      .Columns(33).Caption = "Code 4"
      .Splits(0).DisplayColumns(33).Width = 45
      .Columns(34).Caption = "Code 5"
      .Splits(0).DisplayColumns(34).Width = 45
      .Columns(35).Caption = "Amt 1"
      .Splits(0).DisplayColumns(35).Width = 50
      .Columns(36).Caption = "Amt 2"
      .Splits(0).DisplayColumns(36).Width = 50
      .Columns(37).Caption = "Amt 3"
      .Splits(0).DisplayColumns(37).Width = 50
      .Columns(38).Caption = "Amt 4"
      .Splits(0).DisplayColumns(38).Width = 50
      .Columns(39).Caption = "Amt 5"
      .Splits(0).DisplayColumns(39).Width = 50
      .Columns(40).Caption = "MV Fee"
      .Splits(0).DisplayColumns(40).Width = 50
      .Splits(0).DisplayColumns(40).Style.BackColor = Color.Cyan
    End With
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Function UpdateFeeCD(ByRef WrkFeeCd() As String, ByRef WrkFeeAmt() As Decimal) As Boolean

    Dim J As Integer
    Dim Good As Boolean
    Dim Found As Boolean

    Good = False
    Found = False

    If RbStatusAdd.Checked Then
      For J = 0 To 4
        If WrkFeeCd(J) = TxtFeeCD.Text Then Return Good 'Already there 
        If WrkFeeCd(J) = "" Then
          WrkFeeCd(J) = TxtFeeCD.Text
          WrkFeeAmt(J) = MyUtils.CnvSng(TxtAmount.Text)
          Good = True
          Exit For
        End If
      Next
    Else
      For J = 0 To 4
        If WrkFeeCd(J) = TxtFeeCD.Text Then
          WrkFeeCd(J) = ""
          WrkFeeAmt(J) = 0
          Found = True
          Good = True
        End If
        If Found And J <> 4 Then
          WrkFeeCd(J) = WrkFeeCd(J + 1)
          WrkFeeCd(J + 1) = ""
          WrkFeeAmt(J) = WrkFeeAmt(J + 1)
          WrkFeeAmt(J + 1) = 0
        End If
      Next
    End If

    Return Good
  End Function
  Private Sub WriteHistory(ByVal ListNo As Integer, ByVal Year As Integer, ByVal Type As String)
    Dim WrkFeeDesc As String
    Dim WrkRecID As Integer

    If Not MyStatusHistory Then Exit Sub

    'MK 8/13/25 Begin
    'WrkFeeDesc = TxtFeeCD.Text & "-" & Trim(GetTXPenDesc(TxtFeeCD.Text))
    If TxtFeeCD.Text = "" Then
      WrkFeeDesc = "MV Flag"
    Else
      WrkFeeDesc = TxtFeeCD.Text & "-" & Trim(GetTXPenDesc(TxtFeeCD.Text))
    End If
    'MK 8/13/25 End
    With MyTXHST
      WrkRecID = .AutoGenKey()
      .GetOneRecordP(WrkRecID)
      ._RECID = WrkRecID
      ._RCODE = "I"
      ._LISTNO = ListNo
      ._YEAR = Year
      ._TYPE = Type
      ._CDATE = MyUtils.SetDBDate(DtPckAsof.Value)
      ._PDATE = MyUtils.SetDBDate(DtPckAsof.Value)
      ._REF = MyUtils.JustifyLeft(WrkFeeDesc, 10)
      'MK 8/13/25 Begin
      'If RbStatusAdd.Checked Then
      If RbStatusAdd.Checked And Not ChkMVUnflag.Checked Then
        'MK 8/13/25 End
        ._CORC = "A"
      Else
        ._CORC = "R"
      End If
      ._COMM = TxtComment.Text
      ._PCAMT = MyUtils.CnvSng(TxtAmount.Text)
      ._PRF = Mid(MyUserID, 1, 10)
      ._CHDATE = MyUtils.SetDBDate(Date.Now.Date)
      ._CHTIME = MyUtils.SetDBTime(Date.Now)
      .AddOneRecordP()
    End With

  End Sub
  Private Sub FrmTX4042D_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If Not e.Alt Then Exit Sub

    If e.KeyCode = Keys.A Then
      UpdateDS()
    End If

    If e.KeyCode = Keys.R Then
      Me.Close()
    End If

    If e.KeyCode = Keys.O Then
      UpdateRow()
    End If
  End Sub
  Private Sub FrmTX4042D_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTX404.SbpScreen.Text = "TX4042"
    MyFrmTX404.TBarBack.Enabled = True
    If MyPrinter <> String.Empty Then
      MyFrmTX404.TBarPrint.Enabled = True
    End If
    MyFrmTX404.TBarSetPrinter.Enabled = True
    MyFrmTX404.TBarSettings.Enabled = True
    'Memory Cleanup
    MyTXINV = Nothing
    MyTXHST = Nothing
    MyFrmTX4042D = Nothing
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    'MK 8/13/25 Begin
    'If Mid(GetTXPenDesc(TxtFeeCD.Text), 1, 3) = "***" Then
    If Not ChkMVUnflag.Checked And Mid(GetTXPenDesc(TxtFeeCD.Text), 1, 3) = "***" Then
      'MK 8/13/25 End
      ErrorField(I) = "fee"
      ErrorMsg(I) = "Invalid Fee Code"
    End If

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFeeCD, String.Empty)
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "fee"
          ErrProv.SetError(TxtFeeCD, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub

  Private Sub RbFeeCd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    ShowGrid()
  End Sub
  Private Sub RbFeeAmt_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    ShowGrid()
  End Sub
End Class






