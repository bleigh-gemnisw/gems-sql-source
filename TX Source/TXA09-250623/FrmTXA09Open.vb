Imports System.Threading.Tasks

Public Class FrmTXA09Open
  Inherits System.Windows.Forms.Form
  Dim myTBATCH As TBATCH.MyData
  Dim myTXCBCH As TXCBCH.MyData
  Friend WrkBatch As String
  Friend WrkBatchNo As Integer

  Dim SaveDelete As Boolean
  Dim SaveClose As Boolean
  Dim SavedBatch As Boolean
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbAdjust As System.Windows.Forms.RadioButton
  Friend WithEvents RbRefund As System.Windows.Forms.RadioButton
  Friend WithEvents ChkEndorse As CheckBox
  Dim AddMode As Boolean
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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents ChkValidate As System.Windows.Forms.CheckBox
  Friend WithEvents TxtCash As System.Windows.Forms.TextBox
  Friend WithEvents DtPckInterest As System.Windows.Forms.DateTimePicker
  Friend WithEvents DtPckReceipt As System.Windows.Forms.DateTimePicker
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents LblBatchNo As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents LblDrawer As System.Windows.Forms.Label
  Friend WithEvents PrtDialog As System.Windows.Forms.PrintDialog
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.ChkValidate = New System.Windows.Forms.CheckBox()
    Me.TxtCash = New System.Windows.Forms.TextBox()
    Me.DtPckInterest = New System.Windows.Forms.DateTimePicker()
    Me.DtPckReceipt = New System.Windows.Forms.DateTimePicker()
    Me.LblBatchNo = New System.Windows.Forms.Label()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label9 = New System.Windows.Forms.Label()
    Me.LblDrawer = New System.Windows.Forms.Label()
    Me.PrtDialog = New System.Windows.Forms.PrintDialog()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbAdjust = New System.Windows.Forms.RadioButton()
    Me.RbRefund = New System.Windows.Forms.RadioButton()
    Me.ChkEndorse = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(32, 24)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(92, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Batch/Drawer #"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(32, 52)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(92, 16)
    Me.Label2.TabIndex = 8
    Me.Label2.Text = "Starting Cash"
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(32, 92)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(92, 16)
    Me.Label3.TabIndex = 2
    Me.Label3.Text = "Interest Date"
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(32, 116)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(92, 16)
    Me.Label4.TabIndex = 3
    Me.Label4.Text = "Receipt Date"
    '
    'ChkValidate
    '
    Me.ChkValidate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkValidate.Location = New System.Drawing.Point(35, 142)
    Me.ChkValidate.Name = "ChkValidate"
    Me.ChkValidate.Size = New System.Drawing.Size(108, 20)
    Me.ChkValidate.TabIndex = 5
    Me.ChkValidate.Text = "Validate?"
    '
    'TxtCash
    '
    Me.TxtCash.Location = New System.Drawing.Point(128, 48)
    Me.TxtCash.MaxLength = 11
    Me.TxtCash.Name = "TxtCash"
    Me.TxtCash.Size = New System.Drawing.Size(80, 20)
    Me.TxtCash.TabIndex = 1
    Me.TxtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'DtPckInterest
    '
    Me.DtPckInterest.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckInterest.Location = New System.Drawing.Point(128, 88)
    Me.DtPckInterest.Name = "DtPckInterest"
    Me.DtPckInterest.Size = New System.Drawing.Size(84, 20)
    Me.DtPckInterest.TabIndex = 3
    '
    'DtPckReceipt
    '
    Me.DtPckReceipt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckReceipt.Location = New System.Drawing.Point(128, 116)
    Me.DtPckReceipt.Name = "DtPckReceipt"
    Me.DtPckReceipt.Size = New System.Drawing.Size(84, 20)
    Me.DtPckReceipt.TabIndex = 4
    '
    'LblBatchNo
    '
    Me.LblBatchNo.Location = New System.Drawing.Point(128, 24)
    Me.LblBatchNo.Name = "LblBatchNo"
    Me.LblBatchNo.Size = New System.Drawing.Size(60, 16)
    Me.LblBatchNo.TabIndex = 0
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(32, 72)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(92, 16)
    Me.Label9.TabIndex = 12
    Me.Label9.Text = "Drawer Total"
    '
    'LblDrawer
    '
    Me.LblDrawer.Location = New System.Drawing.Point(128, 72)
    Me.LblDrawer.Name = "LblDrawer"
    Me.LblDrawer.Size = New System.Drawing.Size(80, 16)
    Me.LblDrawer.TabIndex = 2
    Me.LblDrawer.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbAdjust)
    Me.GroupBox1.Controls.Add(Me.RbRefund)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(35, 182)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(96, 56)
    Me.GroupBox1.TabIndex = 197
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Default to"
    '
    'RbAdjust
    '
    Me.RbAdjust.Checked = True
    Me.RbAdjust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbAdjust.Location = New System.Drawing.Point(8, 32)
    Me.RbAdjust.Name = "RbAdjust"
    Me.RbAdjust.Size = New System.Drawing.Size(80, 16)
    Me.RbAdjust.TabIndex = 1
    Me.RbAdjust.TabStop = True
    Me.RbAdjust.Text = "Adjustment"
    '
    'RbRefund
    '
    Me.RbRefund.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbRefund.Location = New System.Drawing.Point(8, 16)
    Me.RbRefund.Name = "RbRefund"
    Me.RbRefund.Size = New System.Drawing.Size(64, 16)
    Me.RbRefund.TabIndex = 0
    Me.RbRefund.Text = "Refund"
    '
    'ChkEndorse
    '
    Me.ChkEndorse.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkEndorse.Location = New System.Drawing.Point(35, 163)
    Me.ChkEndorse.Name = "ChkEndorse"
    Me.ChkEndorse.Size = New System.Drawing.Size(108, 20)
    Me.ChkEndorse.TabIndex = 198
    Me.ChkEndorse.Text = "Endorse?"
    '
    'FrmTXA09Open
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(258, 250)
    Me.Controls.Add(Me.ChkEndorse)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.LblDrawer)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.LblBatchNo)
    Me.Controls.Add(Me.DtPckReceipt)
    Me.Controls.Add(Me.DtPckInterest)
    Me.Controls.Add(Me.TxtCash)
    Me.Controls.Add(Me.ChkValidate)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXA09Open"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Cash Drawer Open/Change"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTXA09Open_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTBATCH = New TBATCH.MyData(myDBConnect)
    myTXCBCH = New TXCBCH.MyData(myDBConnect)

    With MyFrmTXA09
      If .TBarClose.Enabled Then SaveClose = True
      If .TBarDelete.Enabled Then SaveDelete = True
      .TBarDelete.Enabled = False
      .TBarChange.Enabled = False
      .TBarClose.Enabled = False
      .TBarNew.Enabled = False
      .TBarSave.Enabled = True
      .TBarView.Enabled = False
      .TBarPrtEdits.Enabled = False
      .TBarPost.Enabled = False
      .TBarSettings.Enabled = False
    End With

    If WrkBatchNo = 0 Then
      AddMode = True
      myTXCBCH.GetOneRecordP(1)
      SetNextBatch()
      LblBatchNo.Text = myTXCBCH._LCBCHNo
      ChkValidate.Checked = True
      ChkEndorse.Checked = True
    Else
      myTBATCH.GetOneRecordP(WrkBatch, WrkBatchNo)
      If myTBATCH.RecordNotFound Then Exit Sub
      With myTBATCH
        LblBatchNo.Text = ._KBTCHNo
        TxtCash.Text = ._KBCASH
        LblDrawer.Text = ._KBEND
        If ._KVALID = "Y" Then
          ChkValidate.Checked = True
        End If
        If ._KENDORSE = "Y" Then
          ChkEndorse.Checked = True
        End If
        DtPckInterest.Value = ._KIMM & "/" & ._KIDD & "/" & ._KIYY
        DtPckReceipt.Value = ._KRMM & "/" & ._KRDD & "/" & ._KRYY
        If ._KBTCHT = "01" Then
          RbRefund.Checked = True
        Else
          RbAdjust.Checked = True
        End If
      End With
    End If
  End Sub

  Private Sub FrmTXA09Open_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA09.SbpScreen.Text = "TXA09Open"
    MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmTXA09
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub

  Private Sub FrmTXA09Open_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

    If AddMode Then
      If Not SavedBatch Then
        MyFrmTXA09.TBarNew.Enabled = True
        MyFrmTXA09.TBarSave.Enabled = False
        MyFrmTXA091.Show()
        GoTo Cleanup
      End If
      With MyFrmTXA09
        .TBarChange.Enabled = False
        .TBarClose.Enabled = False
        .TBarDelete.Enabled = False
        .TBarSave.Enabled = False
        .TBarView.Enabled = True
        .TBarPrtEdits.Enabled = False
        .TBarPost.Enabled = False
      End With
      MyBatchNo = MyUtils.CnvSng(LblBatchNo.Text)
      MyReceiptDate = DtPckReceipt.Value
      MyInterestDate = DtPckInterest.Value
      MyValidation = False
      If ChkValidate.Checked Then
        MyValidation = True
      End If
      MyEndorseMe = False
      If ChkEndorse.Checked Then
        MyEndorseMe = True
      End If
      MyFrmTXA094 = New FrmTXA094
      MyFrmTXA094.MdiParent = Me.ParentForm
      MyFrmTXA094.Show()
    Else
      With MyFrmTXA09
        .TBarChange.Enabled = True
        .TBarClose.Enabled = SaveClose
        .TBarDelete.Enabled = SaveDelete
        .TBarSave.Enabled = False
        .TBarView.Enabled = True
        .TBarPrtEdits.Enabled = True
        .TBarPost.Enabled = True
      End With
      If SavedBatch Then
        MyReceiptDate = DtPckReceipt.Value
        MyInterestDate = DtPckInterest.Value
        MyValidation = False
        If ChkValidate.Checked Then
          MyValidation = True
        End If
        MyEndorseMe = False
        If ChkEndorse.Checked Then
          MyEndorseMe = True
        End If
      End If
      MyFrmTXA09View.LblStart.Text = Format(MyUtils.CnvSng(TxtCash.Text), "fixed")
      MyFrmTXA09View.LblEnd.Text = Format(MyUtils.CnvSng(LblDrawer.Text), "fixed")
      MyFrmTXA09View.CalcBatchTotals()
      MyFrmTXA09View.Show()
    End If

Cleanup:
    'Memory Cleanup
    myTBATCH.CloseFile()
    myTXCBCH.CloseFile()
    myTBATCH = Nothing
    myTXCBCH = Nothing
    MyFrmTXA09Open = Nothing
  End Sub
  Public Async Sub RunSaveData()
    Await Task.Run(Sub()
                     SaveData()
                   End Sub)

  End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    myTBATCH.GetOneRecordP(WrkBatch, WrkBatchNo)
    If AddMode Then
      If Not myTBATCH.RecordNotFound Then
        Me.ErrProv.SetError(LblBatchNo, "Record already exists")
        Exit Sub
      End If
    End If

    If Not AddMode Then
      MoveToFile()
      If IsNothing(ErrorMsg(0)) Then
        If Not myTBATCH.RecordNotFound Then
          myTBATCH.UpdateOneRecordP()
        End If
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      MoveToFile()
      If IsNothing(ErrorMsg(0)) Then
        myTBATCH.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    SavedBatch = True
    myTBATCH.CloseFile()
    Me.Close()

  End Sub
  Private Sub MoveToFile()
    Dim SvCash As Decimal

    With myTBATCH
      SvCash = ._KBCASH
      ._KBCASH = MyUtils.CnvSng(TxtCash.Text)
      If WrkBatchNo = 0 Then
        ._KBTCHNo = MyUtils.CnvSng(LblBatchNo.Text)
        ._KBEND = MyUtils.CnvSng(TxtCash.Text)
        ._KBSTAT = "O"
        ._KVALID = "N"
        ._KBTCHC = MyBatch
        ._KUSER = Mid(MyUserID, 1, 10)
      Else
        ._KBEND = ._KBEND - SvCash + MyUtils.CnvSng(TxtCash.Text)
      End If
      If RbRefund.Checked Then
        ._KBTCHT = "01"
        MyRefundBatch = True
      Else
        ._KBTCHT = "02"
        MyRefundBatch = False
      End If
      ._KVALID = "N"
      If ChkValidate.Checked Then
        ._KVALID = "Y"
      End If
      ._KENDORSE = "N"
      If ChkEndorse.Checked Then
        ._KENDORSE = "Y"
      End If
      ._KRMM = Month(DtPckReceipt.Text)
      ._KRDD = Microsoft.VisualBasic.DateAndTime.Day(DtPckReceipt.Text)
      ._KRYY = Year(DtPckReceipt.Text)
      ._KIMM = Month(Me.DtPckInterest.Text)
      ._KIDD = Microsoft.VisualBasic.DateAndTime.Day(Me.DtPckInterest.Text)
      ._KIYY = Year(Me.DtPckInterest.Text)
      ._KMMM = 0
      ._KMDD = 0
      ._KMYY = 0
      ._KPRINT = ""
      If ChkValidate.Checked Then
        ._KVALID = "Y"
      End If
      If ChkEndorse.Checked Then
        ._KENDORSE = "Y"
      End If
      ._KUCODE = 0
    End With
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(LblBatchNo, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "kbtch#"
          ErrProv.SetError(LblBatchNo, ErrorMsg(I))
        Case ""
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub SetNextBatch()
    With myTXCBCH
      ._LCBCHNo = ._LCBCHNo + 1
      If .RecordNotFound Then
        .AddOneRecordP()
      Else
        .UpdateOneRecordP()
      End If
      .CloseFile()
    End With

  End Sub

  Private Sub TxtCash_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCash.TextChanged

  End Sub
  Private Sub TxtCash_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCash.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub

  Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles ChkEndorse.CheckedChanged

  End Sub
End Class






