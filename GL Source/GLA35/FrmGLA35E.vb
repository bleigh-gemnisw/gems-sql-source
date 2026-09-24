Public Class FrmGLA35E
  Inherits System.Windows.Forms.Form
  Dim myBCHHDR As BCHHDR.myData
  Dim myMSCBCH As MSCBCH.myData
  Dim myMSCBCHL1 As MSCBCHL1.MyData
  Dim myGLACCT As GLACCT.MyData
  Friend WrkBatchNo As Integer
  Friend WrkTran As Integer
  Friend WrkSeq As Integer
  Friend WithEvents TxtRef As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
 Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
 Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
 Friend WithEvents RbDebit As System.Windows.Forms.RadioButton
 Friend WithEvents RbCredit As System.Windows.Forms.RadioButton
 Friend WithEvents LnkGLAcct As System.Windows.Forms.LinkLabel
 Friend WithEvents TxtSfcn As System.Windows.Forms.TextBox
 Friend WithEvents TxtFcn As System.Windows.Forms.TextBox
 Friend WithEvents TxtObj As System.Windows.Forms.TextBox
 Friend WithEvents TxtDept As System.Windows.Forms.TextBox
 Friend WithEvents TxtSFund As System.Windows.Forms.TextBox
 Friend WithEvents TxtFund As System.Windows.Forms.TextBox
  Dim AddMode As Boolean
  Dim WrkReceiptDate As Date

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
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents TxtAmount As System.Windows.Forms.TextBox
Friend WithEvents TxtDescr As System.Windows.Forms.TextBox
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents LblBatch As System.Windows.Forms.Label
Friend WithEvents Label10 As System.Windows.Forms.Label
Friend WithEvents LblSeq As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtAmount = New System.Windows.Forms.TextBox()
    Me.TxtDescr = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.LblBatch = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.LblSeq = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtRef = New System.Windows.Forms.TextBox()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.RbCredit = New System.Windows.Forms.RadioButton()
    Me.RbDebit = New System.Windows.Forms.RadioButton()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.LnkGLAcct = New System.Windows.Forms.LinkLabel()
    Me.TxtSfcn = New System.Windows.Forms.TextBox()
    Me.TxtFcn = New System.Windows.Forms.TextBox()
    Me.TxtObj = New System.Windows.Forms.TextBox()
    Me.TxtDept = New System.Windows.Forms.TextBox()
    Me.TxtSFund = New System.Windows.Forms.TextBox()
    Me.TxtFund = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(16, 78)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(72, 16)
    Me.Label5.TabIndex = 8
    Me.Label5.Text = "Amount"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtAmount
    '
    Me.TxtAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAmount.Location = New System.Drawing.Point(92, 74)
    Me.TxtAmount.MaxLength = 10
    Me.TxtAmount.Name = "TxtAmount"
    Me.TxtAmount.Size = New System.Drawing.Size(80, 20)
    Me.TxtAmount.TabIndex = 6
    Me.TxtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtDescr
    '
    Me.TxtDescr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDescr.Location = New System.Drawing.Point(92, 100)
    Me.TxtDescr.MaxLength = 30
    Me.TxtDescr.Name = "TxtDescr"
    Me.TxtDescr.Size = New System.Drawing.Size(242, 20)
    Me.TxtDescr.TabIndex = 7
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(18, 101)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(68, 16)
    Me.Label7.TabIndex = 23
    Me.Label7.Text = "Description"
    Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(12, 8)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(36, 14)
    Me.Label8.TabIndex = 24
    Me.Label8.Text = "Batch"
    '
    'LblBatch
    '
    Me.LblBatch.Location = New System.Drawing.Point(56, 8)
    Me.LblBatch.Name = "LblBatch"
    Me.LblBatch.Size = New System.Drawing.Size(48, 12)
    Me.LblBatch.TabIndex = 25
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(116, 8)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(32, 14)
    Me.Label10.TabIndex = 26
    Me.Label10.Text = "Seq"
    '
    'LblSeq
    '
    Me.LblSeq.Location = New System.Drawing.Point(148, 8)
    Me.LblSeq.Name = "LblSeq"
    Me.LblSeq.Size = New System.Drawing.Size(32, 12)
    Me.LblSeq.TabIndex = 27
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(16, 130)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(68, 16)
    Me.Label1.TabIndex = 238
    Me.Label1.Text = "Reference"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtRef
    '
    Me.TxtRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRef.Location = New System.Drawing.Point(92, 126)
    Me.TxtRef.MaxLength = 7
    Me.TxtRef.Name = "TxtRef"
    Me.TxtRef.Size = New System.Drawing.Size(56, 20)
    Me.TxtRef.TabIndex = 8
    '
    'RbCredit
    '
    Me.RbCredit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbCredit.Location = New System.Drawing.Point(104, 13)
    Me.RbCredit.Name = "RbCredit"
    Me.RbCredit.Size = New System.Drawing.Size(57, 28)
    Me.RbCredit.TabIndex = 3
    Me.RbCredit.Text = "Credit"
    Me.RbCredit.UseVisualStyleBackColor = True
    '
    'RbDebit
    '
    Me.RbDebit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbDebit.Checked = True
    Me.RbDebit.Location = New System.Drawing.Point(10, 16)
    Me.RbDebit.Name = "RbDebit"
    Me.RbDebit.Size = New System.Drawing.Size(59, 25)
    Me.RbDebit.TabIndex = 2
    Me.RbDebit.TabStop = True
    Me.RbDebit.Text = "Debit"
    Me.RbDebit.UseVisualStyleBackColor = True
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbDebit)
    Me.GroupBox2.Controls.Add(Me.RbCredit)
    Me.GroupBox2.Location = New System.Drawing.Point(15, 162)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(178, 45)
    Me.GroupBox2.TabIndex = 9
    Me.GroupBox2.TabStop = False
    '
    'LnkGLAcct
    '
    Me.LnkGLAcct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkGLAcct.ForeColor = System.Drawing.Color.Maroon
    Me.LnkGLAcct.Location = New System.Drawing.Point(12, 39)
    Me.LnkGLAcct.Name = "LnkGLAcct"
    Me.LnkGLAcct.Size = New System.Drawing.Size(36, 18)
    Me.LnkGLAcct.TabIndex = 7
    Me.LnkGLAcct.TabStop = True
    Me.LnkGLAcct.Text = "Acct"
    '
    'TxtSfcn
    '
    Me.TxtSfcn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfcn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfcn.Location = New System.Drawing.Point(273, 35)
    Me.TxtSfcn.MaxLength = 4
    Me.TxtSfcn.Name = "TxtSfcn"
    Me.TxtSfcn.Size = New System.Drawing.Size(45, 22)
    Me.TxtSfcn.TabIndex = 5
    '
    'TxtFcn
    '
    Me.TxtFcn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFcn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFcn.Location = New System.Drawing.Point(222, 35)
    Me.TxtFcn.MaxLength = 4
    Me.TxtFcn.Name = "TxtFcn"
    Me.TxtFcn.Size = New System.Drawing.Size(45, 22)
    Me.TxtFcn.TabIndex = 4
    '
    'TxtObj
    '
    Me.TxtObj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObj.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObj.Location = New System.Drawing.Point(186, 35)
    Me.TxtObj.MaxLength = 3
    Me.TxtObj.Name = "TxtObj"
    Me.TxtObj.Size = New System.Drawing.Size(32, 22)
    Me.TxtObj.TabIndex = 3
    '
    'TxtDept
    '
    Me.TxtDept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDept.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDept.Location = New System.Drawing.Point(135, 35)
    Me.TxtDept.MaxLength = 4
    Me.TxtDept.Name = "TxtDept"
    Me.TxtDept.Size = New System.Drawing.Size(45, 22)
    Me.TxtDept.TabIndex = 2
    '
    'TxtSFund
    '
    Me.TxtSFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSFund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSFund.Location = New System.Drawing.Point(97, 35)
    Me.TxtSFund.MaxLength = 3
    Me.TxtSFund.Name = "TxtSFund"
    Me.TxtSFund.Size = New System.Drawing.Size(32, 22)
    Me.TxtSFund.TabIndex = 1
    '
    'TxtFund
    '
    Me.TxtFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFund.Location = New System.Drawing.Point(59, 35)
    Me.TxtFund.MaxLength = 3
    Me.TxtFund.Name = "TxtFund"
    Me.TxtFund.Size = New System.Drawing.Size(32, 22)
    Me.TxtFund.TabIndex = 0
    '
    'FrmGLA35E
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(402, 220)
    Me.Controls.Add(Me.LnkGLAcct)
    Me.Controls.Add(Me.TxtSfcn)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.TxtFcn)
    Me.Controls.Add(Me.TxtRef)
    Me.Controls.Add(Me.TxtObj)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtDept)
    Me.Controls.Add(Me.LblSeq)
    Me.Controls.Add(Me.TxtSFund)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.TxtFund)
    Me.Controls.Add(Me.LblBatch)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.TxtDescr)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TxtAmount)
    Me.Controls.Add(Me.Label5)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGLA35E"
    Me.Text = "Electronic Receipts"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmGLA35E_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myBCHHDR = New BCHHDR.MyData()
  myBCHHDR.MyDBConn = myDBConnect
  myMSCBCH = New MSCBCH.myData()
  myMSCBCH.MyDBConn = myDBConnect
  myMSCBCHL1 = New MSCBCHL1.MyData()
  myMSCBCHL1.MyDBConn = myDBConnect
  myGLACCT = New GLACCT.MyData()
  myGLACCT.MyDBConn = myDBConnect

  MyFrmGLA35.TBarNew.Enabled = False
  MyFrmGLA35.TBarSave.Enabled = True
  LblBatch.Text = WrkBatchNo

  If WrkSeq > 0 Then
    MyFrmGLA35.TBarDelete.Enabled = True
  Else
    AddMode = True
    WrkSeq = myMSCBCH.AutoGenKey(WrkBatchNo)
    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    myMSCBCH.GetOneRecordP(WrkBatchNo, WrkTran, 0)
    With myMSCBCH
      WrkReceiptDate = MyUtils.GetDBDate(._JACT8)
    End With
  End If

  LblSeq.Text = WrkSeq

  myMSCBCH.GetOneRecordP(WrkBatchNo, WrkTran, WrkSeq)
  If myMSCBCH.RecordNotFound Then Exit Sub

  With myMSCBCH
    TxtFund.Text = ._FDNBR
    TxtSFund.Text = ._SFUND
    TxtDept.Text = ._DPNBR
    TxtObj.Text = ._OBNBR
    TxtFcn.Text = ._FNPGM
    TxtSfcn.Text = ._SUBFN
    TxtDescr.Text = Trim(._DESCR)
    TxtAmount.Text = ._AMT
    TxtRef.Text = ._REFNO
    Select Case ._AMTTYP
    Case "C"
      RbCredit.Checked = True
    Case "D"
      RbDebit.Checked = True
    End Select
  End With
End Sub

Private Sub FrmGLA35E_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmGLA35.SbpScreen.Text = "GLA35E"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub FrmGLA35E_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmGLA35.TBarNew.Enabled = True
  MyFrmGLA35.TBarDelete.Enabled = False
  MyFrmGLA35.TBarSave.Enabled = False
  MyFrmGLA35D.FormatGrid()
  MyFrmGLA35D.Show()
  'Memory Cleanup
  myMSCBCH = Nothing
  MyFrmGLA35E = Nothing
End Sub
Public Sub DeleteData(ByRef Cancel As Boolean)
  Dim Answer As Integer
  Cancel = False
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Cancel = True
    Exit Sub
  End If

  myMSCBCH.DeleteOneRecordP()
  UpdateHeader()
End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  myMSCBCH.GetOneRecordP(WrkBatchNo, WrkTran, WrkSeq)
  If Not AddMode Then
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myMSCBCH.UpdateOneRecordP()
      Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  Else
    With myMSCBCH
      ._BCHNO = WrkBatchNo
      ._TRNBR = WrkTran
      ._JRNSEQ = WrkSeq
      ._TRNTYP = "X"
      ._SRCDE = 5
    End With
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myMSCBCH.AddOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End If
  UpdateHeader()
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myMSCBCH
    ._FDNBR = MyUtils.CnvSng(TxtFund.Text)
    ._SFUND = MyUtils.CnvSng(TxtSFund.Text)
    ._DPNBR = MyUtils.CnvSng(TxtDept.Text)
    ._OBNBR = MyUtils.CnvSng(TxtObj.Text)
    ._FNPGM = MyUtils.CnvSng(TxtFcn.Text)
    ._SUBFN = MyUtils.CnvSng(TxtSfcn.Text)
    ._DESCR = TxtDescr.Text
    ._AMT = MyUtils.CnvSng(TxtAmount.Text)
      myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFund.Text), MyUtils.CnvSng(TxtSFund.Text), MyUtils.CnvSng(TxtDept.Text), _
        MyUtils.CnvSng(TxtObj.Text), MyUtils.CnvSng(TxtFcn.Text), MyUtils.CnvSng(TxtSfcn.Text))
    ._GLTYP = myGLACCT._GLTYP
    ._REFNO = MyUtils.CnvSng(TxtRef.Text)
    If RbCredit.Checked Then ._AMTTYP = "C"
    If RbDebit.Checked Then ._AMTTYP = "D"
    If ._JACT8 = 0 Then
      ._JACT8 = MyUtils.SetDBDate(WrkReceiptDate)
      ._JENT8 = MyUtils.SetDBDate(WrkReceiptDate)
    End If
  End With
 End Sub

 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtFund, "")
  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
    Case "acct"
      ErrProv.SetError(TxtFund, ErrorMsg(I))
    Case "desc"
      ErrProv.SetError(TxtDescr, ErrorMsg(I))
    Case Nothing
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

     If MyUtils.CnvSng(TxtFund.Text) > 0 Or MyUtils.CnvSng(TxtSFund.Text) > 0 Or MyUtils.CnvSng(TxtDept.Text) > 0 Or _
      MyUtils.CnvSng(TxtObj.Text) > 0 Or MyUtils.CnvSng(TxtFcn.Text) > 0 Or MyUtils.CnvSng(TxtSfcn.Text) > 0 Then
      myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFund.Text), MyUtils.CnvSng(TxtSFund.Text), MyUtils.CnvSng(TxtDept.Text), _
        MyUtils.CnvSng(TxtObj.Text), MyUtils.CnvSng(TxtFcn.Text), MyUtils.CnvSng(TxtSfcn.Text))
      If myGLACCT.RecordNotFound Then
        ErrorField(I) = "acct"
        ErrorMsg(I) = "Acct is invalid"
        I = I + 1
      End If
    End If

    If Instr(TxtDescr.Text,"'") Then 
      ErrorField(I) = "desc"
      ErrorMsg(I) = "Cannot have a Quote in Description"
      I = I + 1
    End If
  End Sub
Private Sub TxtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAmount.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub LnkGLAcctRC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkGLAcct.LinkClicked
  Dim WrkAcct As String

  WrkAcct = BuildAcct(MyUtils.CnvSng(TxtFund.Text), MyUtils.CnvSng(TxtSFund.Text), MyUtils.CnvSng(TxtDept.Text), _
    MyUtils.CnvSng(TxtObj.Text), MyUtils.CnvSng(TxtFcn.Text), MyUtils.CnvSng(TxtSfcn.Text))
  MyFrmListGLAcct = New FrmListGLAcct
  MyFrmListGLAcct.MdiParent = Me.ParentForm
  MyFrmListGLAcct.WrkCode = WrkAcct
  MyFrmListGLAcct.Show()
  Me.Hide()
End Sub
Private Sub UpdateHeader()
  Dim WrkCredit As Decimal
  Dim WrkDebit As Decimal

  CalcTotals(WrkCredit, WrkDebit)
  With myMSCBCH
    .GetOneRecordP(WrkBatchNo, WrkTran, 0)
    If Not .RecordNotFound Then
      ._TOTCR = WrkCredit
      ._TOTDR = WrkDebit
      .UpdateOneRecordP()
    Else
      ._BCHNO = WrkBatchNo
      ._TRNBR = WrkTran
      ._JRNSEQ = WrkSeq
      ._JACT8 = MyUtils.SetDBDate(WrkReceiptDate)
      ._JENT8 = MyUtils.SetDBDate(WrkReceiptDate)
      ._TOTCR = WrkCredit
      ._TOTDR = WrkDebit
      .AddOneRecordP()
    End If
  End With
End Sub
Private Sub CalcTotals(ByRef WrkCredit As Decimal, ByRef WrkDebit As Decimal)
  Dim Ds As DataSet = New DataSet
  Dim I As Integer

  Ds = myMSCBCHL1.GetViewbyBatch(WrkBatchNo, 9999)
  For I = 0 To Ds.Tables(0).Rows.Count - 1
    If Ds.Tables(0).Rows(I).Item("amttyp") = "C" Then
      WrkCredit = WrkCredit + Ds.Tables(0).Rows(I).Item("amt")
    Else
      WrkDebit = WrkDebit + Ds.Tables(0).Rows(I).Item("amt")
    End If
  Next
End Sub
End Class
