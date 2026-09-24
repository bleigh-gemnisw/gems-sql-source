Public Class FrmPO303B
  Inherits System.Windows.Forms.Form
  Dim myPOMAST As POMAST.MyData
  Dim myPOSUMF As POSUMF.MyData
  Dim myPURCTL As PURCTL.MyData
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
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtFscyr As System.Windows.Forms.TextBox
  Friend WithEvents TxtPOSufx As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents DtPckRent8 As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtPONbr As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents LblOpenAmt As System.Windows.Forms.Label
  Friend WithEvents LblPOAmt As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents LblVennm As System.Windows.Forms.Label
  Friend WithEvents BtnReset As System.Windows.Forms.Button
  Friend WithEvents BtnClose As System.Windows.Forms.Button
  Friend WithEvents BtnVerify As System.Windows.Forms.Button
  Friend WithEvents LblMsg As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents label3 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.label3 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.DtPckRent8 = New System.Windows.Forms.DateTimePicker()
    Me.TxtPONbr = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtPOSufx = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtFscyr = New System.Windows.Forms.TextBox()
    Me.LblPOAmt = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.LblOpenAmt = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.LblVennm = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.BtnClose = New System.Windows.Forms.Button()
    Me.BtnReset = New System.Windows.Forms.Button()
    Me.BtnVerify = New System.Windows.Forms.Button()
    Me.LblMsg = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'label3
    '
    Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label3.Location = New System.Drawing.Point(-100, 74)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(100, 23)
    Me.label3.TabIndex = 6
    Me.label3.Text = "New file name"
    Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(22, 95)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(86, 13)
    Me.Label7.TabIndex = 402
    Me.Label7.Text = "PO Posting Date"
    Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'DtPckRent8
    '
    Me.DtPckRent8.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckRent8.Location = New System.Drawing.Point(114, 89)
    Me.DtPckRent8.Name = "DtPckRent8"
    Me.DtPckRent8.Size = New System.Drawing.Size(84, 20)
    Me.DtPckRent8.TabIndex = 3
    '
    'TxtPONbr
    '
    Me.TxtPONbr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPONbr.Location = New System.Drawing.Point(91, 44)
    Me.TxtPONbr.MaxLength = 7
    Me.TxtPONbr.Name = "TxtPONbr"
    Me.TxtPONbr.Size = New System.Drawing.Size(60, 20)
    Me.TxtPONbr.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(21, 47)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(62, 13)
    Me.Label1.TabIndex = 403
    Me.Label1.Text = "PO Number"
    '
    'TxtPOSufx
    '
    Me.TxtPOSufx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPOSufx.Location = New System.Drawing.Point(187, 44)
    Me.TxtPOSufx.MaxLength = 5
    Me.TxtPOSufx.Name = "TxtPOSufx"
    Me.TxtPOSufx.Size = New System.Drawing.Size(33, 20)
    Me.TxtPOSufx.TabIndex = 2
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(24, 24)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(59, 13)
    Me.Label2.TabIndex = 406
    Me.Label2.Text = "Fiscal Year"
    '
    'TxtFscyr
    '
    Me.TxtFscyr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFscyr.Location = New System.Drawing.Point(91, 21)
    Me.TxtFscyr.MaxLength = 5
    Me.TxtFscyr.Name = "TxtFscyr"
    Me.TxtFscyr.Size = New System.Drawing.Size(45, 20)
    Me.TxtFscyr.TabIndex = 0
    '
    'LblPOAmt
    '
    Me.LblPOAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPOAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPOAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPOAmt.Location = New System.Drawing.Point(87, 139)
    Me.LblPOAmt.Name = "LblPOAmt"
    Me.LblPOAmt.Size = New System.Drawing.Size(64, 16)
    Me.LblPOAmt.TabIndex = 408
    Me.LblPOAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label16
    '
    Me.Label16.AutoSize = True
    Me.Label16.BackColor = System.Drawing.SystemColors.Control
    Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label16.Location = New System.Drawing.Point(20, 139)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(61, 13)
    Me.Label16.TabIndex = 407
    Me.Label16.Text = "PO Amount"
    '
    'LblOpenAmt
    '
    Me.LblOpenAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOpenAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOpenAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOpenAmt.Location = New System.Drawing.Point(87, 155)
    Me.LblOpenAmt.Name = "LblOpenAmt"
    Me.LblOpenAmt.Size = New System.Drawing.Size(64, 16)
    Me.LblOpenAmt.TabIndex = 409
    Me.LblOpenAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.BackColor = System.Drawing.SystemColors.Control
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(11, 158)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(72, 13)
    Me.Label5.TabIndex = 410
    Me.Label5.Text = "Open Amount"
    '
    'LblVennm
    '
    Me.LblVennm.AutoSize = True
    Me.LblVennm.Location = New System.Drawing.Point(88, 117)
    Me.LblVennm.Name = "LblVennm"
    Me.LblVennm.Size = New System.Drawing.Size(84, 13)
    Me.LblVennm.TabIndex = 411
    Me.LblVennm.Text = "<Vendor Name>"
    Me.LblVennm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.LblVennm.UseMnemonic = False
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.BackColor = System.Drawing.SystemColors.Control
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(20, 117)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(41, 13)
    Me.Label6.TabIndex = 412
    Me.Label6.Text = "Vendor"
    '
    'BtnClose
    '
    Me.BtnClose.Location = New System.Drawing.Point(42, 190)
    Me.BtnClose.Name = "BtnClose"
    Me.BtnClose.Size = New System.Drawing.Size(84, 34)
    Me.BtnClose.TabIndex = 5
    Me.BtnClose.Text = "Close PO"
    Me.BtnClose.UseVisualStyleBackColor = True
    '
    'BtnReset
    '
    Me.BtnReset.Location = New System.Drawing.Point(169, 190)
    Me.BtnReset.Name = "BtnReset"
    Me.BtnReset.Size = New System.Drawing.Size(84, 34)
    Me.BtnReset.TabIndex = 6
    Me.BtnReset.Text = "Reset"
    Me.BtnReset.UseVisualStyleBackColor = True
    '
    'BtnVerify
    '
    Me.BtnVerify.Location = New System.Drawing.Point(227, 33)
    Me.BtnVerify.Name = "BtnVerify"
    Me.BtnVerify.Size = New System.Drawing.Size(84, 34)
    Me.BtnVerify.TabIndex = 4
    Me.BtnVerify.Text = "Verify"
    Me.BtnVerify.UseVisualStyleBackColor = True
    '
    'LblMsg
    '
    Me.LblMsg.AutoSize = True
    Me.LblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMsg.Location = New System.Drawing.Point(12, 241)
    Me.LblMsg.Name = "LblMsg"
    Me.LblMsg.Size = New System.Drawing.Size(71, 13)
    Me.LblMsg.TabIndex = 416
    Me.LblMsg.Text = "<Message>"
    Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.LblMsg.UseMnemonic = False
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(157, 47)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(28, 13)
    Me.Label4.TabIndex = 417
    Me.Label4.Text = "Sufx"
    '
    'FrmPO303B
    '
    Me.AllowDrop = True
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(323, 263)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.LblMsg)
    Me.Controls.Add(Me.BtnVerify)
    Me.Controls.Add(Me.BtnReset)
    Me.Controls.Add(Me.BtnClose)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.LblVennm)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.LblOpenAmt)
    Me.Controls.Add(Me.LblPOAmt)
    Me.Controls.Add(Me.Label16)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtFscyr)
    Me.Controls.Add(Me.TxtPOSufx)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.DtPckRent8)
    Me.Controls.Add(Me.TxtPONbr)
    Me.Controls.Add(Me.label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmPO303B"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub PO303B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myPOMAST = New POMAST.MyData()
    myPOMAST.MyDBConn = myDBConnect
    myPOSUMF = New POSUMF.MyData()
    myPOSUMF.MyDBConn = myDBConnect
    myPURCTL = New PURCTL.MyData()
    myPURCTL.MyDBConn = myDBConnect
    With MyFrmPO303
      .TBarPrint.Visible = False
    End With

    LblVennm.Text = ""
    LblMsg.Text = ""
    DtPckRent8.Value = Date.Today
    BtnClose.Enabled = False
    BtnReset.Enabled = False
  End Sub
  Private Sub PO303B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmPO303.SbpScreen.Text = "PO303B"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub

  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    myPOMAST.GetOneRecordP(MyUtils.CnvSng(TxtFscyr.Text), MyUtils.CnvSng(TxtPONbr.Text),
   MyUtils.CnvSng(TxtPOSufx.Text), 0, 0)
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      If myPOMAST.RecordNotFound Then
        myPOMAST.AddOneRecordP()
      Else
        myPOMAST.UpdateOneRecordP()
      End If
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End Sub
  Private Sub MovetoFile()
    With myPOMAST
      ._CMPCD = "C"
      ._POPEN = 0
    End With
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtFscyr.Text) = 0 Then
      ErrorField(I) = "Fscyr"
      ErrorMsg(I) = "Fiscal Year cannot be zero"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtPONbr.Text) = 0 Then
      ErrorField(I) = "PONbr"
      ErrorMsg(I) = "PO Number cannot be zero"
      I = I + 1
    End If

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFscyr, "")
    ErrProv.SetError(TxtPONbr, "")
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "Fscyr"
          ErrProv.SetError(TxtFscyr, ErrorMsg(I))
        Case "PONbr"
          ErrProv.SetError(TxtPONbr, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub TxtFscyr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFscyr.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtPONbr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPONbr.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtPOSufx_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPOSufx.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Private Sub BtnVerify_Click(sender As Object, e As EventArgs) Handles BtnVerify.Click
    LblMsg.Text = ""
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    myPOMAST.GetOneRecordP(MyUtils.CnvSng(TxtFscyr.Text), MyUtils.CnvSng(TxtPONbr.Text),
   MyUtils.CnvSng(TxtPOSufx.Text), 0, 0)
    If Not myPOMAST.RecordNotFound Then
      If myPOMAST._CMPCD = "C" Then
        LblMsg.Text = "*** PO is closed ***"
        Exit Sub
      End If
      LblVennm.Text = myPOMAST._VENNM
      LblOpenAmt.Text = myPOMAST._POPEN
      LblPOAmt.Text = myPOMAST._AMTNT
    Else
      LblMsg.Text = "*** PO not found ***"
      Exit Sub
    End If

    With myPURCTL
      .GetOneRecordP(MyUtils.CnvSng(TxtFscyr.Text))
      If MyUtils.SetDBDate(DtPckRent8.Value) > ._FSCE8 Then
        DtPckRent8.Value = MyUtils.GetDBDate(._FSCE8)
      End If
    End With
    BtnVerify.Enabled = False
    BtnClose.Enabled = True
    BtnReset.Enabled = True
  End Sub

  Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
    BtnVerify.Enabled = True
    BtnClose.Enabled = False
    BtnReset.Enabled = False
    TxtPONbr.Text = ""
    TxtPOSufx.Text = ""
    LblVennm.Text = ""
    LblOpenAmt.Text = 0
    LblPOAmt.Text = 0
    LblMsg.Text = ""
  End Sub
  Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
    Dim WrkFscyr As Integer
    Dim WrkPOnbr As Integer
    WrkFscyr = MyUtils.CnvSng(TxtFscyr.Text)
    WrkPOnbr = MyUtils.CnvSng(TxtPONbr.Text)
    With myPURCTL
      .GetOneRecordP(MyUtils.CnvSng(TxtFscyr.Text))
      If MyUtils.SetDBDate(DtPckRent8.Value) > ._FSCE8 Then
        DtPckRent8.Value = MyUtils.GetDBDate(._FSCE8)
        MsgBox("Posting Date was not within valid range and set to ending date", MsgBoxStyle.Information, "Posting Date was changed")
        Exit Sub
      End If
    End With
    myPOMAST.GetOneRecordP(WrkFscyr, WrkPOnbr, MyUtils.CnvSng(TxtPOSufx.Text), 0, 0)
    MovetoFile()
    ProcFile(myPOMAST._POPST)
    myPOMAST.UpdateOneRecordP()
    myPOSUMF.RunUpdateQuery("Set POOPN=0", "Where FSCYR=" & WrkFscyr & " and PONBR=" & WrkPOnbr)

    BtnVerify.Enabled = True
    BtnClose.Enabled = False
    BtnReset.Enabled = False
    TxtPONbr.Text = ""
    TxtPOSufx.Text = ""
    LblVennm.Text = ""
    LblOpenAmt.Text = 0
    LblPOAmt.Text = 0
    LblMsg.Text = ""
  End Sub
End Class
