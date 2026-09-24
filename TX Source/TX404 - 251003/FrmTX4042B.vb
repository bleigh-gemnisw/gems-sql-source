Public Class FrmTX4042B
  Inherits System.Windows.Forms.Form
  Dim MyTXINV As TXINV.MyData
  Dim MyTXHST As TXHST.MyData

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
  Friend WithEvents TxtStatusCD As System.Windows.Forms.TextBox
  Friend WithEvents LnkStatusCD As System.Windows.Forms.LinkLabel
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  Friend WithEvents TBarAll As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarRow As System.Windows.Forms.ToolBarButton
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtComment As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents DtPckAsof As System.Windows.Forms.DateTimePicker
  Friend WithEvents TBarReturn As System.Windows.Forms.ToolBarButton
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTX4042B))
    Me.TxtStatusCD = New System.Windows.Forms.TextBox
    Me.RbStatusAdd = New System.Windows.Forms.RadioButton
    Me.RbStatusRemove = New System.Windows.Forms.RadioButton
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TbMain = New System.Windows.Forms.ToolBar
    Me.TBarReturn = New System.Windows.Forms.ToolBarButton
    Me.TBarAll = New System.Windows.Forms.ToolBarButton
    Me.TBarRow = New System.Windows.Forms.ToolBarButton
    Me.LnkStatusCD = New System.Windows.Forms.LinkLabel
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Me.Label1 = New System.Windows.Forms.Label
    Me.TxtComment = New System.Windows.Forms.TextBox
    Me.Label5 = New System.Windows.Forms.Label
    Me.DtPckAsof = New System.Windows.Forms.DateTimePicker
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TxtStatusCD
    '
    Me.TxtStatusCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtStatusCD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtStatusCD.Location = New System.Drawing.Point(80, 16)
    Me.TxtStatusCD.MaxLength = 1
    Me.TxtStatusCD.Name = "TxtStatusCD"
    Me.TxtStatusCD.Size = New System.Drawing.Size(19, 20)
    Me.TxtStatusCD.TabIndex = 1
    '
    'RbStatusAdd
    '
    Me.RbStatusAdd.Checked = True
    Me.RbStatusAdd.Location = New System.Drawing.Point(120, 8)
    Me.RbStatusAdd.Name = "RbStatusAdd"
    Me.RbStatusAdd.Size = New System.Drawing.Size(48, 16)
    Me.RbStatusAdd.TabIndex = 2
    Me.RbStatusAdd.TabStop = True
    Me.RbStatusAdd.Text = "A&dd"
    '
    'RbStatusRemove
    '
    Me.RbStatusRemove.Location = New System.Drawing.Point(120, 30)
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
    Me.TbMain.Location = New System.Drawing.Point(9, 297)
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
    'LnkStatusCD
    '
    Me.LnkStatusCD.Location = New System.Drawing.Point(6, 18)
    Me.LnkStatusCD.Name = "LnkStatusCD"
    Me.LnkStatusCD.Size = New System.Drawing.Size(72, 16)
    Me.LnkStatusCD.TabIndex = 0
    Me.LnkStatusCD.TabStop = True
    Me.LnkStatusCD.Text = "Status Code"
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
    Me.C1DataGrdList.Location = New System.Drawing.Point(9, 86)
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.Size = New System.Drawing.Size(392, 184)
    Me.C1DataGrdList.TabIndex = 193
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(12, 63)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(62, 17)
    Me.Label1.TabIndex = 205
    Me.Label1.Text = "Comment"
    '
    'TxtComment
    '
    Me.TxtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtComment.Location = New System.Drawing.Point(80, 60)
    Me.TxtComment.MaxLength = 20
    Me.TxtComment.Name = "TxtComment"
    Me.TxtComment.Size = New System.Drawing.Size(126, 20)
    Me.TxtComment.TabIndex = 4
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(229, 63)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(40, 16)
    Me.Label5.TabIndex = 204
    Me.Label5.Text = "Date"
    '
    'DtPckAsof
    '
    Me.DtPckAsof.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckAsof.Location = New System.Drawing.Point(275, 60)
    Me.DtPckAsof.Name = "DtPckAsof"
    Me.DtPckAsof.Size = New System.Drawing.Size(88, 20)
    Me.DtPckAsof.TabIndex = 5
    '
    'FrmTX4042B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(413, 353)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtComment)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.DtPckAsof)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.Controls.Add(Me.LnkStatusCD)
    Me.Controls.Add(Me.TbMain)
    Me.Controls.Add(Me.RbStatusRemove)
    Me.Controls.Add(Me.RbStatusAdd)
    Me.Controls.Add(Me.TxtStatusCD)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX4042B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Change Status Code"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub LnkStatusCD_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkStatusCD.LinkClicked
    MyFrmListSts = New FrmListSts
    MyFrmListSts.MdiParent = Me.ParentForm
    MyFrmListSts.WrkCode = TxtStatusCD.Text
    MyFrmListSts.Show()
  End Sub
  Private Sub TxtStatusCD_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtStatusCD.Leave
    Dim WrkDesc As String

    If Not TxtStatusCD.Modified Then Exit Sub

    WrkDesc = GetTXStsDesc(TxtStatusCD.Text)
    Ttp1.SetToolTip(TxtStatusCD, WrkDesc)

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

    TxtStatusCD.Text = String.Empty
    TxtComment.Text = String.Empty
    ErrProv.SetError(TxtStatusCD, String.Empty)
  End Sub
  Private Sub UpdateDS()
    Dim ListNo As Integer
    Dim Year As Integer
    Dim Type As String
    Dim I As Integer
    Dim WrkStCd(4) As String
    Dim Good As Boolean

    If TxtStatusCD.Text = "" Then Exit Sub

    For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
      ListNo = myds.Tables(0).Rows(I).Item("ListNo")
      Year = myds.Tables(0).Rows(I).Item("Year")
      Type = myds.Tables(0).Rows(I).Item("Type")
      MyTXINV.GetOneRecordP(ListNo, Year, Type)
      With myds.Tables(0).Rows(I)
        WrkStCd(0) = myds.Tables(0).Rows(I).Item("stcd1")
        WrkStCd(1) = myds.Tables(0).Rows(I).Item("stcd2")
        WrkStCd(2) = myds.Tables(0).Rows(I).Item("stcd3")
        WrkStCd(3) = myds.Tables(0).Rows(I).Item("stcd4")
        WrkStCd(4) = myds.Tables(0).Rows(I).Item("stcd5")
        Good = UpdateStatusCD(WrkStCd)
        If Good Then
          myds.Tables(0).Rows(I).Item("stcd1") = WrkStCd(0)
          myds.Tables(0).Rows(I).Item("stcd2") = WrkStCd(1)
          myds.Tables(0).Rows(I).Item("stcd3") = WrkStCd(2)
          myds.Tables(0).Rows(I).Item("stcd4") = WrkStCd(3)
          myds.Tables(0).Rows(I).Item("stcd5") = WrkStCd(4)
          myds.Tables(0).Rows(I).Item("status") = Trim(WrkStCd(0)) & Trim(WrkStCd(1)) _
          & Trim(WrkStCd(2)) & Trim(WrkStCd(3)) & Trim(WrkStCd(4))
          MyTXINV._STCD1 = WrkStCd(0)
          MyTXINV._STCD2 = WrkStCd(1)
          MyTXINV._STCD3 = WrkStCd(2)
          MyTXINV._STCD4 = WrkStCd(3)
          MyTXINV._STCD5 = WrkStCd(4)
          MyTXINV._CHDATE = MyUtils.SetDBDate(DateTime.Today)
          MyTXINV._CHTIME = Format(DateTime.Now, "hhmmss")
          MyTXINV.UpdateOneRecordP()
          WriteHistory(ListNo, Year, Type)
        End If
      End With
    Next
  End Sub
  Private Sub UpdateRow()
    Dim ListNo As Integer
    Dim Year As Integer
    Dim Type As String
    Dim I As Integer
    Dim WrkStCd(4) As String
    Dim Good As Boolean

    If TxtStatusCD.Text = "" Then Exit Sub

    For Each I In C1DataGrdList.SelectedRows
      ListNo = myds.Tables(0).Rows(I).Item("ListNo")
      Year = myds.Tables(0).Rows(I).Item("Year")
      Type = myds.Tables(0).Rows(I).Item("Type")
      MyTXINV.GetOneRecordP(ListNo, Year, Type)
      With myds.Tables(0).Rows(I)
        WrkStCd(0) = myds.Tables(0).Rows(I).Item("stcd1")
        WrkStCd(1) = myds.Tables(0).Rows(I).Item("stcd2")
        WrkStCd(2) = myds.Tables(0).Rows(I).Item("stcd3")
        WrkStCd(3) = myds.Tables(0).Rows(I).Item("stcd4")
        WrkStCd(4) = myds.Tables(0).Rows(I).Item("stcd5")
        Good = UpdateStatusCD(WrkStCd)
        If Good Then
          myds.Tables(0).Rows(I).Item("stcd1") = WrkStCd(0)
          myds.Tables(0).Rows(I).Item("stcd2") = WrkStCd(1)
          myds.Tables(0).Rows(I).Item("stcd3") = WrkStCd(2)
          myds.Tables(0).Rows(I).Item("stcd4") = WrkStCd(3)
          myds.Tables(0).Rows(I).Item("stcd5") = WrkStCd(4)
          myds.Tables(0).Rows(I).Item("status") = Trim(WrkStCd(0)) & Trim(WrkStCd(1)) _
          & Trim(WrkStCd(2)) & Trim(WrkStCd(3)) & Trim(WrkStCd(4))
          MyTXINV._STCD1 = WrkStCd(0)
          MyTXINV._STCD2 = WrkStCd(1)
          MyTXINV._STCD3 = WrkStCd(2)
          MyTXINV._STCD4 = WrkStCd(3)
          MyTXINV._STCD5 = WrkStCd(4)
          MyTXINV._CHDATE = MyUtils.SetDBDate(DateTime.Today)
          MyTXINV._CHTIME = Format(DateTime.Now, "hhmmss")
          MyTXINV.UpdateOneRecordP()
          WriteHistory(ListNo, Year, Type)
        End If
      End With
    Next
  End Sub
  Private Sub FrmTX4042B_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    Me.Dispose()
  End Sub
  Private Sub FrmTX4042B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
      .Splits(0).DisplayColumns(1).Width = 40
      .Splits(0).DisplayColumns(2).Width = 30
      .Splits(0).DisplayColumns(3).Visible = False
      .Splits(0).DisplayColumns(4).Width = 30
      For I = 5 To 22
        .Splits(0).DisplayColumns(I).Visible = False
      Next
      .Columns(23).Caption = "Code 1"
      .Splits(0).DisplayColumns(23).Width = 50
      .Columns(24).Caption = "Code 2"
      .Splits(0).DisplayColumns(24).Width = 50
      .Columns(25).Caption = "Code 3"
      .Splits(0).DisplayColumns(25).Width = 50
      .Columns(26).Caption = "Code 4"
      .Splits(0).DisplayColumns(26).Width = 50
      .Columns(27).Caption = "Code 5"
      .Splits(0).DisplayColumns(27).Width = 50
      For I = 28 To 40
        .Splits(0).DisplayColumns(I).Visible = False
      Next
    End With

    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Function UpdateStatusCD(ByRef WrkStCd() As String) As Boolean

    Dim J As Integer
    Dim Good As Boolean
    Dim Found As Boolean

    Good = False
    Found = False

    If RbStatusAdd.Checked Then
      For J = 0 To 4
        If WrkStCd(J) = TxtStatusCD.Text Then Return Good 'Already there 
        If WrkStCd(J) = "" Then
          WrkStCd(J) = TxtStatusCD.Text
          Good = True
          Exit For
        End If
      Next
    Else
      For J = 0 To 4
        If WrkStCd(J) = TxtStatusCD.Text Then
          WrkStCd(J) = ""
          Found = True
          Good = True
        End If
        If Found And J <> 4 Then
          WrkStCd(J) = WrkStCd(J + 1)
          WrkStCd(J + 1) = ""
        End If
      Next
    End If

    Return Good
  End Function
  Private Sub WriteHistory(ByVal ListNo As Integer, ByVal Year As Integer, ByVal Type As String)
    Dim WrkStatusDesc As String
    Dim WrkRecID As Integer

    If Not MyStatusHistory Then Exit Sub

    WrkStatusDesc = TxtStatusCD.Text & "-" & Trim(GetTXStsDesc(TxtStatusCD.Text))
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
      ._REF = MyUtils.JustifyLeft(WrkStatusDesc, 10)
      If RbStatusAdd.Checked Then
        ._CORC = "A"
      Else
        ._CORC = "R"
      End If
      ._COMM = TxtComment.Text
      ._PRF = Mid(MyUserID, 1, 10)
      ._CHDATE = MyUtils.SetDBDate(Date.Now.Date)
      ._CHTIME = MyUtils.SetDBTime(Date.Now)
      .AddOneRecordP()
    End With

  End Sub
  Private Sub FrmTX4042B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
  Private Sub FrmTX4042B_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTX404.TBarBack.Enabled = True
    If MyPrinter <> String.Empty Then
      MyFrmTX404.TBarPrint.Enabled = True
    End If
    MyFrmTX404.TBarSetPrinter.Enabled = True
    MyFrmTX404.TBarSettings.Enabled = True
    'Memory Cleanup
    MyTXHST = Nothing
    MyTXINV = Nothing
    MyFrmTX4042B = Nothing
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If Mid(GetTXStsDesc(TxtStatusCD.Text), 1, 3) = "***" Then
      ErrorField(I) = "status"
      ErrorMsg(I) = "Invalid Status Code"
    End If

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtStatusCD, String.Empty)
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "status"
          ErrProv.SetError(TxtStatusCD, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
End Class






