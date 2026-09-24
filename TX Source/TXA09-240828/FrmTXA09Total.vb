Public Class FrmTXA09Total
  Inherits System.Windows.Forms.Form
  Dim myTXBATCH As TXBATCH.myData
  Friend WrkBatchSeqNo As Integer
  Friend WrkPos As String
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtAmt4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAmt3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAmt2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAmt1 As System.Windows.Forms.TextBox
  Friend WithEvents BtnAmts As System.Windows.Forms.Button
  Friend WithEvents LblAmtRecv As Label
  Friend WrkPosNo As String

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
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents LblTotAmt As System.Windows.Forms.Label
  Friend WithEvents LblTotCredit As System.Windows.Forms.Label
  Friend WithEvents LblTotCheck As System.Windows.Forms.Label
  Friend WithEvents LblTotCash As System.Windows.Forms.Label
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents TxtReceived As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents TbMain As System.Windows.Forms.ToolBar
  Friend WithEvents TBarSave As System.Windows.Forms.ToolBarButton
  Friend WithEvents ChkEndorse As System.Windows.Forms.CheckBox
  Friend WithEvents TBarReturn As System.Windows.Forms.ToolBarButton
  Friend WithEvents LblChgDue As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTXA09Total))
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.LblTotAmt = New System.Windows.Forms.Label()
    Me.LblTotCredit = New System.Windows.Forms.Label()
    Me.LblTotCheck = New System.Windows.Forms.Label()
    Me.LblTotCash = New System.Windows.Forms.Label()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.Label22 = New System.Windows.Forms.Label()
    Me.Label23 = New System.Windows.Forms.Label()
    Me.TxtReceived = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.ChkEndorse = New System.Windows.Forms.CheckBox()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarSave = New System.Windows.Forms.ToolBarButton()
    Me.TBarReturn = New System.Windows.Forms.ToolBarButton()
    Me.LblChgDue = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.BtnAmts = New System.Windows.Forms.Button()
    Me.TxtAmt1 = New System.Windows.Forms.TextBox()
    Me.TxtAmt2 = New System.Windows.Forms.TextBox()
    Me.TxtAmt3 = New System.Windows.Forms.TextBox()
    Me.TxtAmt4 = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.LblAmtRecv = New System.Windows.Forms.Label()
    Me.GroupBox3.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.LblTotAmt)
    Me.GroupBox3.Controls.Add(Me.LblTotCredit)
    Me.GroupBox3.Controls.Add(Me.LblTotCheck)
    Me.GroupBox3.Controls.Add(Me.LblTotCash)
    Me.GroupBox3.Controls.Add(Me.Label19)
    Me.GroupBox3.Controls.Add(Me.Label21)
    Me.GroupBox3.Controls.Add(Me.Label22)
    Me.GroupBox3.Controls.Add(Me.Label23)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(56, 8)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(144, 112)
    Me.GroupBox3.TabIndex = 171
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Amounts (Total)"
    '
    'LblTotAmt
    '
    Me.LblTotAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotAmt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblTotAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotAmt.Location = New System.Drawing.Point(56, 88)
    Me.LblTotAmt.Name = "LblTotAmt"
    Me.LblTotAmt.Size = New System.Drawing.Size(80, 20)
    Me.LblTotAmt.TabIndex = 174
    Me.LblTotAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTotCredit
    '
    Me.LblTotCredit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotCredit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblTotCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotCredit.Location = New System.Drawing.Point(56, 64)
    Me.LblTotCredit.Name = "LblTotCredit"
    Me.LblTotCredit.Size = New System.Drawing.Size(80, 20)
    Me.LblTotCredit.TabIndex = 173
    Me.LblTotCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTotCheck
    '
    Me.LblTotCheck.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotCheck.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblTotCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotCheck.Location = New System.Drawing.Point(56, 40)
    Me.LblTotCheck.Name = "LblTotCheck"
    Me.LblTotCheck.Size = New System.Drawing.Size(80, 20)
    Me.LblTotCheck.TabIndex = 166
    Me.LblTotCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTotCash
    '
    Me.LblTotCash.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotCash.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblTotCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotCash.Location = New System.Drawing.Point(56, 16)
    Me.LblTotCash.Name = "LblTotCash"
    Me.LblTotCash.Size = New System.Drawing.Size(80, 20)
    Me.LblTotCash.TabIndex = 165
    Me.LblTotCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label19
    '
    Me.Label19.BackColor = System.Drawing.SystemColors.Control
    Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label19.Location = New System.Drawing.Point(8, 88)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(36, 12)
    Me.Label19.TabIndex = 163
    Me.Label19.Text = "Total"
    '
    'Label21
    '
    Me.Label21.BackColor = System.Drawing.SystemColors.Control
    Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label21.Location = New System.Drawing.Point(8, 64)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(36, 12)
    Me.Label21.TabIndex = 159
    Me.Label21.Text = "Credit"
    '
    'Label22
    '
    Me.Label22.BackColor = System.Drawing.SystemColors.Control
    Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label22.Location = New System.Drawing.Point(8, 40)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(42, 20)
    Me.Label22.TabIndex = 157
    Me.Label22.Text = "Check"
    '
    'Label23
    '
    Me.Label23.BackColor = System.Drawing.SystemColors.Control
    Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label23.Location = New System.Drawing.Point(8, 16)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(36, 12)
    Me.Label23.TabIndex = 155
    Me.Label23.Text = "Cash"
    '
    'TxtReceived
    '
    Me.TxtReceived.Location = New System.Drawing.Point(112, 128)
    Me.TxtReceived.MaxLength = 12
    Me.TxtReceived.Name = "TxtReceived"
    Me.TxtReceived.Size = New System.Drawing.Size(80, 20)
    Me.TxtReceived.TabIndex = 173
    Me.TxtReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(8, 152)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(96, 16)
    Me.Label2.TabIndex = 174
    Me.Label2.Text = "Change Due"
    '
    'ChkEndorse
    '
    Me.ChkEndorse.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkEndorse.Location = New System.Drawing.Point(8, 176)
    Me.ChkEndorse.Name = "ChkEndorse"
    Me.ChkEndorse.Size = New System.Drawing.Size(120, 20)
    Me.ChkEndorse.TabIndex = 176
    Me.ChkEndorse.Text = "Endorse Check?"
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    Me.ImageList1.Images.SetKeyName(1, "")
    '
    'TbMain
    '
    Me.TbMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarSave, Me.TBarReturn})
    Me.TbMain.Dock = System.Windows.Forms.DockStyle.None
    Me.TbMain.DropDownArrows = True
    Me.TbMain.ImageList = Me.ImageList1
    Me.TbMain.Location = New System.Drawing.Point(0, 202)
    Me.TbMain.Name = "TbMain"
    Me.TbMain.ShowToolTips = True
    Me.TbMain.Size = New System.Drawing.Size(222, 42)
    Me.TbMain.TabIndex = 190
    '
    'TBarSave
    '
    Me.TBarSave.ImageIndex = 0
    Me.TBarSave.Name = "TBarSave"
    Me.TBarSave.Text = "&Save"
    '
    'TBarReturn
    '
    Me.TBarReturn.ImageIndex = 1
    Me.TBarReturn.Name = "TBarReturn"
    Me.TBarReturn.Text = "&Return"
    '
    'LblChgDue
    '
    Me.LblChgDue.BackColor = System.Drawing.SystemColors.Control
    Me.LblChgDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChgDue.Location = New System.Drawing.Point(112, 152)
    Me.LblChgDue.Name = "LblChgDue"
    Me.LblChgDue.Size = New System.Drawing.Size(80, 12)
    Me.LblChgDue.TabIndex = 192
    Me.LblChgDue.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'BtnAmts
    '
    Me.BtnAmts.Location = New System.Drawing.Point(198, 127)
    Me.BtnAmts.Name = "BtnAmts"
    Me.BtnAmts.Size = New System.Drawing.Size(27, 23)
    Me.BtnAmts.TabIndex = 193
    Me.BtnAmts.Text = ">>"
    Me.BtnAmts.UseVisualStyleBackColor = True
    '
    'TxtAmt1
    '
    Me.TxtAmt1.Location = New System.Drawing.Point(244, 21)
    Me.TxtAmt1.MaxLength = 12
    Me.TxtAmt1.Name = "TxtAmt1"
    Me.TxtAmt1.Size = New System.Drawing.Size(80, 20)
    Me.TxtAmt1.TabIndex = 194
    Me.TxtAmt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAmt2
    '
    Me.TxtAmt2.Location = New System.Drawing.Point(244, 45)
    Me.TxtAmt2.MaxLength = 12
    Me.TxtAmt2.Name = "TxtAmt2"
    Me.TxtAmt2.Size = New System.Drawing.Size(80, 20)
    Me.TxtAmt2.TabIndex = 195
    Me.TxtAmt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAmt3
    '
    Me.TxtAmt3.Location = New System.Drawing.Point(244, 69)
    Me.TxtAmt3.MaxLength = 12
    Me.TxtAmt3.Name = "TxtAmt3"
    Me.TxtAmt3.Size = New System.Drawing.Size(80, 20)
    Me.TxtAmt3.TabIndex = 196
    Me.TxtAmt3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAmt4
    '
    Me.TxtAmt4.Location = New System.Drawing.Point(244, 93)
    Me.TxtAmt4.MaxLength = 12
    Me.TxtAmt4.Name = "TxtAmt4"
    Me.TxtAmt4.Size = New System.Drawing.Size(80, 20)
    Me.TxtAmt4.TabIndex = 197
    Me.TxtAmt4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(246, 5)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(81, 13)
    Me.Label3.TabIndex = 198
    Me.Label3.Text = "Amounts to add"
    '
    'LblAmtRecv
    '
    Me.LblAmtRecv.AutoSize = True
    Me.LblAmtRecv.BackColor = System.Drawing.SystemColors.Control
    Me.LblAmtRecv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAmtRecv.Location = New System.Drawing.Point(8, 132)
    Me.LblAmtRecv.Name = "LblAmtRecv"
    Me.LblAmtRecv.Size = New System.Drawing.Size(92, 13)
    Me.LblAmtRecv.TabIndex = 199
    Me.LblAmtRecv.Text = "Amount Received"
    '
    'FrmTXA09Total
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(334, 246)
    Me.Controls.Add(Me.LblAmtRecv)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtAmt4)
    Me.Controls.Add(Me.TxtAmt3)
    Me.Controls.Add(Me.TxtAmt2)
    Me.Controls.Add(Me.TxtAmt1)
    Me.Controls.Add(Me.BtnAmts)
    Me.Controls.Add(Me.LblChgDue)
    Me.Controls.Add(Me.ChkEndorse)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtReceived)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.TbMain)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXA09Total"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Tax Receipts Totals"
    Me.GroupBox3.ResumeLayout(False)
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTXA09Total_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkSubTots(2) As Decimal
    Dim WrkTotAmt As Decimal

    myTXBATCH = New TXBATCH.MyData(myDBConnect)

    MyFrmTXA09.TBarView.Enabled = False
    MyFrmTXA09.TBarBack.Enabled = False
    WrkSubTots = myTXBATCH.CalcBatchSubTotals(MyBatch, MyBatchNo)
    LblTotCash.Text = Format(WrkSubTots(0), "standard")
    LblTotCheck.Text = Format(WrkSubTots(1), "standard")
    LblTotCredit.Text = Format(WrkSubTots(2), "standard")
    WrkTotAmt = WrkSubTots(0) + WrkSubTots(1) + WrkSubTots(2)
    LblTotAmt.Text = Format(WrkTotAmt, "standard")

    'If WrkBatchSeqNo = 0 Then 'Total button pressed
    FindLastSeqNo()
    'End If

    If WrkBatchSeqNo = 0 Then 'No records in batch
      TBarSave.Enabled = False
    End If

    If MyValidation And WrkSubTots(1) > 0 Then
      ChkEndorse.Checked = True
    End If

    CalcDueAmt()
    myTXBATCH.CloseFile()
  End Sub

  Private Sub FrmTXA09Total_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA09Total.Width = 250
    MyFrmTXA09.SbpScreen.Text = "TXA09Total"
    MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmTXA09
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub FrmTXA09Total_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    'Memory Cleanup
    myTXBATCH.CloseFile()
    myTXBATCH = Nothing
    MyFrmTXA09Total = Nothing

    MyFrmTXA09.TBarBack.Enabled = True
    MyFrmTXA09.TBarView.Enabled = True
    MyFrmTXA094.FormatGrid(True, True, False)
    MyFrmTXA094.Show()
  End Sub
  Public Sub SaveData()
    Dim ds As DataSet = New DataSet
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    myTXBATCH.GetOneRecordP(MyBatch, MyBatchNo, WrkBatchSeqNo)

    MoveToFile()
    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If

    myTXBATCH.UpdateOneRecordP()

    If ChkEndorse.Checked Then
      If MyAppSettings.AdvDriver Then
        GetEndorsementDirect(WrkBatchSeqNo, MyUtils.CnvSng(LblTotCheck.Text))
      Else
        GetEndorsement(WrkBatchSeqNo, MyUtils.CnvSng(LblTotCheck.Text))
      End If
    End If

    If MyReceiptPrinted Then
      PrtTotalsDirect(LblTotCash.Text, LblTotCheck.Text, LblTotCredit.Text, LblTotAmt.Text,
        MyUtils.CnvSng(TxtReceived.Text), LblChgDue.Text)
    End If

    MyReceiptPrinted = False
    MyLastCheckNo = String.Empty
    MyLastComment = String.Empty
    MyLastCommentRefund = String.Empty
    MyCheckAmount = 0
    myTXBATCH.CloseFile()

    If WrkPos <> String.Empty Then
      MyFrmTXA094.TxtPos.Text = WrkPos
      MyFrmTXA094.TxtPosNo.Text = WrkPosNo
    End If
    myTXBATCH.CloseFile()
    Me.Close()

  End Sub
  Private Sub MoveToFile()
    With myTXBATCH
      ._TBL = MyUtils.CnvSng(LblTotAmt.Text)
      ._ARC = MyUtils.CnvSng(TxtReceived.Text)
    End With
  End Sub
  Sub CalcDueAmt()
    Dim WrkTotAmt As Decimal

    WrkTotAmt = MyUtils.CnvSng(TxtReceived.Text) - MyUtils.CnvSng(LblTotAmt.Text)
    LblChgDue.Text = Format(WrkTotAmt, "standard")

    LblChgDue.ForeColor = Color.Black
    If LblChgDue.Text <> 0 Then
      LblChgDue.ForeColor = Color.Red
    End If

  End Sub

  Private Sub TxtReceived_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtReceived.TextChanged
    CalcDueAmt()
  End Sub

  Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
    If e.Button Is TBarSave Then
      SaveData()
    End If

    If e.Button Is TBarReturn Then
      Me.Close()
    End If
  End Sub
  Private Sub FindLastSeqNo()
    WrkBatchSeqNo = myTXBATCH.AutoGenKey(MyBatch, MyBatchNo)

NextSeq:
    WrkBatchSeqNo = WrkBatchSeqNo - 1
    If WrkBatchSeqNo = 0 Then Exit Sub

    myTXBATCH.GetOneRecordP(MyBatch, MyBatchNo, WrkBatchSeqNo)
    If myTXBATCH.RecordNotFound Then Exit Sub

    If myTXBATCH._JSTAT = "V" Then
      GoTo NextSeq
    End If
    myTXBATCH.CloseFile()

  End Sub
  Private Sub TxtReceived_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtReceived.KeyPress
    'Ledyard - Disable enter key
    If myTOWN._TOWNBR = 72 Then GoTo CheckIt

    If Asc(e.KeyChar) = Keys.Return Then
      SaveData()
      Exit Sub
    End If

CheckIt:
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, True)
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(LblChgDue, String.Empty)
    ErrProv.SetError(TxtReceived, String.Empty)

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "lbldue"
          ErrProv.SetError(LblChgDue, ErrorMsg(I))
        Case "lblrecv"
          ErrProv.SetError(TxtReceived, ErrorMsg(I))
        Case String.Empty
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtReceived.Text) = 0 Then
      If MyUtils.CnvSng(LblChgDue.Text) <> 0 Then
        ErrorField(I) = "lblrecv"
        ErrorMsg(I) = "Received amount cannot be 0"
        I = I + 1
      End If
    End If

    'Show error if Check has change back
    If MyUtils.CnvSng(LblTotCheck.Text) = MyUtils.CnvSng(LblTotAmt.Text) Then
      If Not MyAllowChange And MyUtils.CnvSng(LblChgDue.Text) <> 0 Then
        ErrorField(I) = "lbldue"
        ErrorMsg(I) = "No change allowed for checks"
        I = I + 1
      End If
    End If

  End Sub

  Private Sub BtnAmts_Click(sender As Object, e As EventArgs) Handles BtnAmts.Click
    MyFrmTXA09Total.Width = 350
  End Sub
  Private Sub TxtAmt1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtAmt1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, True)
  End Sub
  Private Sub TxtAmt2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtAmt2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, True)
  End Sub
  Private Sub TxtAmt3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtAmt3.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, True)
  End Sub
  Private Sub TxtAmt4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtAmt4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, True)
  End Sub
  Private Sub TxtAmt1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAmt1.TextChanged
    CalcAmt()
  End Sub
  Private Sub TxtAmt2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAmt2.TextChanged
    CalcAmt()
  End Sub
  Private Sub TxtAmt3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAmt3.TextChanged
    CalcAmt()
  End Sub
  Private Sub TxtAmt4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAmt4.TextChanged
    CalcAmt()
  End Sub
  Sub CalcAmt()
    Dim WrkAmt As Decimal
    WrkAmt = MyUtils.CnvSng(TxtAmt1.Text) + MyUtils.CnvSng(TxtAmt2.Text) + MyUtils.CnvSng(TxtAmt3.Text) _
   + MyUtils.CnvSng(TxtAmt4.Text)

    TxtReceived.Text = Format(WrkAmt, "standard")
  End Sub

  Private Sub LblAmtRecv_Click(sender As Object, e As EventArgs) Handles LblAmtRecv.Click
    TxtReceived.Text = Format(MyUtils.CnvSng(LblTotAmt.Text), "standard")
  End Sub
End Class






