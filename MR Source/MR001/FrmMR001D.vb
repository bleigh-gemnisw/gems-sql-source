Public Class FrmMR001D
  Inherits System.Windows.Forms.Form
  Dim myMRBCH As MRBCH.myData
  Dim myMRBCHD As MRBCHD.myData
  Dim MyMRCODE As MRCODE.myData
  Friend WrkBatchNo As Integer
  Friend WrkCode As String
 Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents LblAmountTot As System.Windows.Forms.Label
  Friend WithEvents LblTotal As System.Windows.Forms.Label
  Friend WithEvents LblAmount3 As Label
  Friend WithEvents TxtCredit As TextBox
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
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents LblAmount1 As System.Windows.Forms.Label
  Friend WithEvents LblAmount2 As System.Windows.Forms.Label
  Friend WithEvents TxtCash As System.Windows.Forms.TextBox
  Friend WithEvents TxtCheck As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents LblBatch As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents LblCode As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.LblAmount1 = New System.Windows.Forms.Label()
    Me.TxtCash = New System.Windows.Forms.TextBox()
    Me.TxtCheck = New System.Windows.Forms.TextBox()
    Me.LblAmount2 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.LblBatch = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.LblCode = New System.Windows.Forms.Label()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LblTotal = New System.Windows.Forms.Label()
    Me.LblAmountTot = New System.Windows.Forms.Label()
    Me.TxtCredit = New System.Windows.Forms.TextBox()
    Me.LblAmount3 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LblAmount1
    '
    Me.LblAmount1.Location = New System.Drawing.Point(12, 48)
    Me.LblAmount1.Name = "LblAmount1"
    Me.LblAmount1.Size = New System.Drawing.Size(72, 16)
    Me.LblAmount1.TabIndex = 8
    Me.LblAmount1.Text = "Cash"
    Me.LblAmount1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtCash
    '
    Me.TxtCash.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCash.Location = New System.Drawing.Point(88, 44)
    Me.TxtCash.MaxLength = 9
    Me.TxtCash.Name = "TxtCash"
    Me.TxtCash.Size = New System.Drawing.Size(80, 20)
    Me.TxtCash.TabIndex = 4
    Me.TxtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtCheck
    '
    Me.TxtCheck.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCheck.Location = New System.Drawing.Point(88, 68)
    Me.TxtCheck.MaxLength = 9
    Me.TxtCheck.Name = "TxtCheck"
    Me.TxtCheck.Size = New System.Drawing.Size(80, 20)
    Me.TxtCheck.TabIndex = 5
    Me.TxtCheck.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblAmount2
    '
    Me.LblAmount2.Location = New System.Drawing.Point(12, 72)
    Me.LblAmount2.Name = "LblAmount2"
    Me.LblAmount2.Size = New System.Drawing.Size(72, 16)
    Me.LblAmount2.TabIndex = 15
    Me.LblAmount2.Text = "Check"
    Me.LblAmount2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
    Me.Label10.Text = "Code"
    '
    'LblCode
    '
    Me.LblCode.AutoSize = True
    Me.LblCode.Location = New System.Drawing.Point(148, 8)
    Me.LblCode.Name = "LblCode"
    Me.LblCode.Size = New System.Drawing.Size(44, 13)
    Me.LblCode.TabIndex = 27
    Me.LblCode.Text = "<Code>"
    '
    'LblTotal
    '
    Me.LblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotal.Location = New System.Drawing.Point(88, 127)
    Me.LblTotal.Name = "LblTotal"
    Me.LblTotal.Size = New System.Drawing.Size(80, 20)
    Me.LblTotal.TabIndex = 350
    Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblAmountTot
    '
    Me.LblAmountTot.Location = New System.Drawing.Point(12, 129)
    Me.LblAmountTot.Name = "LblAmountTot"
    Me.LblAmountTot.Size = New System.Drawing.Size(72, 16)
    Me.LblAmountTot.TabIndex = 351
    Me.LblAmountTot.Text = "Total"
    Me.LblAmountTot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtCredit
    '
    Me.TxtCredit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCredit.Location = New System.Drawing.Point(88, 94)
    Me.TxtCredit.MaxLength = 9
    Me.TxtCredit.Name = "TxtCredit"
    Me.TxtCredit.Size = New System.Drawing.Size(80, 20)
    Me.TxtCredit.TabIndex = 352
    Me.TxtCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblAmount3
    '
    Me.LblAmount3.Location = New System.Drawing.Point(12, 98)
    Me.LblAmount3.Name = "LblAmount3"
    Me.LblAmount3.Size = New System.Drawing.Size(72, 16)
    Me.LblAmount3.TabIndex = 353
    Me.LblAmount3.Text = "Credit"
    Me.LblAmount3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'FrmMR001D
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(195, 156)
    Me.Controls.Add(Me.LblAmount3)
    Me.Controls.Add(Me.TxtCredit)
    Me.Controls.Add(Me.LblAmountTot)
    Me.Controls.Add(Me.LblTotal)
    Me.Controls.Add(Me.LblCode)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.LblBatch)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.LblAmount2)
    Me.Controls.Add(Me.TxtCheck)
    Me.Controls.Add(Me.TxtCash)
    Me.Controls.Add(Me.LblAmount1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmMR001D"
    Me.Text = "Misc Receipts"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmMR001D_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myMRBCH = New MRBCH.MyData()
    myMRBCH.MyDBConn = myDBConnect
    myMRBCHD = New MRBCHD.MyData()
    myMRBCHD.MyDBConn = myDBConnect
    MyMRCODE = New MRCODE.MyData()
    MyMRCODE.MyDBConn = myDBConnect

    MyFrmMR001.TBarNew.Enabled = False
    MyFrmMR001.TBarSave.Enabled = True
    LblBatch.Text = WrkBatchNo

    MyFrmMR001.TBarDelete.Enabled = True
    LblCode.Text = WrkCode
    myMRBCH.GetOneRecordP(WrkBatchNo)
    myMRBCHD.GetOneRecordP(WrkBatchNo, WrkCode)
    If myMRBCHD.RecordNotFound Then
      Exit Sub
    End If

    With myMRBCHD
      If MyTotalEntry Then
        TxtCash.Text = ._TOTAL
        LblAmount1.Text = "Total"
        LblAmount2.Visible = False
        LblAmount3.Visible = False
        LblAmountTot.Visible = False
        TxtCheck.Visible = False
        TxtCredit.Visible = False
        LblTotal.Visible = False
      Else
        TxtCash.Text = ._CASH
        TxtCheck.Text = ._CHECK
        TxtCredit.Text = ._CREDIT
        LblTotal.Text = Format(._CASH + ._CHECK + ._CREDIT, "fixed")
      End If
    End With
  End Sub

Private Sub FrmMR001D_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmMR001.SbpScreen.Text = "MR001D"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub FrmMR001D_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmMR001.TBarNew.Enabled = False
  MyFrmMR001.TBarDelete.Enabled = False
  MyFrmMR001.TBarSave.Enabled = False
  MyFrmMR001C.FormatGrid()
  MyFrmMR001C.Show()
  'Memory Cleanup
  myMRBCHD = Nothing
  MyFrmMR001D = Nothing
End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim WrkCash As Decimal
    Dim WrkCheck As Decimal
    Dim WrkCredit As Decimal

    Dim Answer As Integer
    Cancel = False
    Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
    If Answer = vbNo Then
      Cancel = True
      Exit Sub
    End If

    If MyTotalEntry Then
      WrkCash = MyUtils.CnvSng(TxtCash.Text) * -1
      UpdateTotals(WrkCash, 0, 0)
    Else
      WrkCash = MyUtils.CnvSng(TxtCash.Text) * -1
      WrkCheck = MyUtils.CnvSng(TxtCheck.Text) * -1
      WrkCredit = MyUtils.CnvSng(TxtCredit.Text) * -1
      UpdateTotals(WrkCash, WrkCheck, WrkCredit)
    End If
    myMRBCHD.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim WrkCash As Decimal
    Dim WrkCheck As Decimal
    Dim WrkCredit As Decimal
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    myMRBCH.GetOneRecordP(WrkBatchNo)
    If MyTotalEntry Then
      WrkCash = MyUtils.CnvSng(TxtCash.Text) - myMRBCHD._TOTAL
      UpdateTotals(WrkCash, 0, 0)
    Else
      WrkCash = MyUtils.CnvSng(TxtCash.Text) - myMRBCHD._CASH
      WrkCheck = MyUtils.CnvSng(TxtCheck.Text) - myMRBCHD._CHECK
      WrkCredit = MyUtils.CnvSng(TxtCredit.Text) - myMRBCHD._CREDIT
      UpdateTotals(WrkCash, WrkCheck, WrkCredit)
    End If

    myMRBCHD.GetOneRecordP(WrkBatchNo, WrkCode)
    If Not AddMode Then
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myMRBCHD.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()

  End Sub
  Private Sub MovetoFile()
    With myMRBCHD
      If MyTotalEntry Then
        ._CASH = 0
        ._CHECK = 0
        ._CREDIT = 0
        ._TOTAL = MyUtils.CnvSng(TxtCash.Text)
      Else
        ._CASH = MyUtils.CnvSng(TxtCash.Text)
        ._CHECK = MyUtils.CnvSng(TxtCheck.Text)
        ._CREDIT = MyUtils.CnvSng(TxtCredit.Text)
        ._TOTAL = ._CASH + ._CHECK + ._CREDIT
      End If
    End With
  End Sub

 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
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
  End Sub
Private Sub TxtCash_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCash.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, True)
End Sub
Private Sub TxtCash_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCash.TextChanged
  CalcTotal()
End Sub
Private Sub TxtCheck_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCheck.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, True)
End Sub
Private Sub TxtCheck_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCheck.TextChanged
  CalcTotal()
End Sub
  Private Sub TxtCredit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCredit.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, True)
  End Sub
  Private Sub TxtCredit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCredit.TextChanged
    CalcTotal()
  End Sub
  Private Sub CalcTotal()
    LblTotal.Text = MyUtils.CnvSng(TxtCash.Text) + MyUtils.CnvSng(TxtCheck.Text) + +MyUtils.CnvSng(TxtCredit.Text)
  End Sub
  Private Sub UpdateTotals(ByVal Cash As Decimal, ByVal Check As Decimal, ByVal Credit As Decimal)
    With myMRBCH
      .GetOneRecordP(WrkBatchNo)
      If MyTotalEntry Then
        ._TAMT = ._TAMT + Cash
      Else
        ._TCASH = ._TCASH + Cash
        ._TCHECK = ._TCHECK + Check
        ._TCREDIT = ._TCREDIT + Credit
        ._TAMT = ._TCASH + ._TCHECK + ._TCREDIT
      End If
      .UpdateOneRecordP()
    End With
  End Sub

End Class
