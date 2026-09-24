Public Class FrmPRA02C
  Inherits System.Windows.Forms.Form
  Dim myPRGLMAP As PRGLMAP.MyData
  Dim myGLACCT As GLACCT.MyData

  Friend WrkFdnbr As Integer
  Friend WrkSfund As Integer
  Friend WrkDpnbr As Integer
  Friend WrkObnbr As Integer
  Friend WrkFnpgm As Integer
  Friend WrkSubfn As Integer
  Friend WrkDesc As String
  Friend WithEvents LnkGLAcctM As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtSfcnM As System.Windows.Forms.TextBox
  Friend WithEvents TxtFcnM As System.Windows.Forms.TextBox
  Friend WithEvents TxtObjM As System.Windows.Forms.TextBox
  Friend WithEvents TxtDptM As System.Windows.Forms.TextBox
  Friend WithEvents TxtSfndM As System.Windows.Forms.TextBox
  Friend WithEvents TxtFndM As System.Windows.Forms.TextBox
  Friend WithEvents LnkGLAcctD As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkGLAcctC As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtSfcnD As System.Windows.Forms.TextBox
  Friend WithEvents TxtFcnD As System.Windows.Forms.TextBox
  Friend WithEvents TxtObjD As System.Windows.Forms.TextBox
  Friend WithEvents TxtDptD As System.Windows.Forms.TextBox
  Friend WithEvents TxtSfndD As System.Windows.Forms.TextBox
  Friend WithEvents TxtSfcnC As System.Windows.Forms.TextBox
  Friend WithEvents TxtFcnC As System.Windows.Forms.TextBox
  Friend WithEvents TxtObjC As System.Windows.Forms.TextBox
  Friend WithEvents TxtDptC As System.Windows.Forms.TextBox
  Friend WithEvents TxtSfndC As System.Windows.Forms.TextBox
  Friend WithEvents TxtFndD As System.Windows.Forms.TextBox
  Friend WithEvents TxtFndC As System.Windows.Forms.TextBox
  Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WrkGLType As String

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
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LnkGLAcctD = New System.Windows.Forms.LinkLabel
    Me.LnkGLAcctC = New System.Windows.Forms.LinkLabel
    Me.TxtSfcnD = New System.Windows.Forms.TextBox
    Me.TxtFcnD = New System.Windows.Forms.TextBox
    Me.TxtObjD = New System.Windows.Forms.TextBox
    Me.TxtDptD = New System.Windows.Forms.TextBox
    Me.TxtSfndD = New System.Windows.Forms.TextBox
    Me.TxtSfcnC = New System.Windows.Forms.TextBox
    Me.TxtFcnC = New System.Windows.Forms.TextBox
    Me.TxtObjC = New System.Windows.Forms.TextBox
    Me.TxtDptC = New System.Windows.Forms.TextBox
    Me.TxtSfndC = New System.Windows.Forms.TextBox
    Me.TxtFndD = New System.Windows.Forms.TextBox
    Me.TxtFndC = New System.Windows.Forms.TextBox
    Me.LnkGLAcctM = New System.Windows.Forms.LinkLabel
    Me.TxtSfcnM = New System.Windows.Forms.TextBox
    Me.TxtFcnM = New System.Windows.Forms.TextBox
    Me.TxtObjM = New System.Windows.Forms.TextBox
    Me.TxtDptM = New System.Windows.Forms.TextBox
    Me.TxtSfndM = New System.Windows.Forms.TextBox
    Me.TxtFndM = New System.Windows.Forms.TextBox
    Me.TxtDesc = New System.Windows.Forms.TextBox
    Me.Label4 = New System.Windows.Forms.Label
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LnkGLAcctD
    '
    Me.LnkGLAcctD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkGLAcctD.ForeColor = System.Drawing.Color.Maroon
    Me.LnkGLAcctD.Location = New System.Drawing.Point(12, 112)
    Me.LnkGLAcctD.Name = "LnkGLAcctD"
    Me.LnkGLAcctD.Size = New System.Drawing.Size(60, 18)
    Me.LnkGLAcctD.TabIndex = 20
    Me.LnkGLAcctD.TabStop = True
    Me.LnkGLAcctD.Text = "Debit Acct"
    '
    'LnkGLAcctC
    '
    Me.LnkGLAcctC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkGLAcctC.ForeColor = System.Drawing.Color.Maroon
    Me.LnkGLAcctC.Location = New System.Drawing.Point(12, 88)
    Me.LnkGLAcctC.Name = "LnkGLAcctC"
    Me.LnkGLAcctC.Size = New System.Drawing.Size(60, 18)
    Me.LnkGLAcctC.TabIndex = 12
    Me.LnkGLAcctC.TabStop = True
    Me.LnkGLAcctC.Text = "Credit Acct"
    '
    'TxtSfcnD
    '
    Me.TxtSfcnD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfcnD.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfcnD.Location = New System.Drawing.Point(302, 108)
    Me.TxtSfcnD.MaxLength = 4
    Me.TxtSfcnD.Name = "TxtSfcnD"
    Me.TxtSfcnD.Size = New System.Drawing.Size(45, 22)
    Me.TxtSfcnD.TabIndex = 25
    '
    'TxtFcnD
    '
    Me.TxtFcnD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFcnD.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFcnD.Location = New System.Drawing.Point(251, 108)
    Me.TxtFcnD.MaxLength = 4
    Me.TxtFcnD.Name = "TxtFcnD"
    Me.TxtFcnD.Size = New System.Drawing.Size(45, 22)
    Me.TxtFcnD.TabIndex = 24
    '
    'TxtObjD
    '
    Me.TxtObjD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObjD.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObjD.Location = New System.Drawing.Point(215, 108)
    Me.TxtObjD.MaxLength = 3
    Me.TxtObjD.Name = "TxtObjD"
    Me.TxtObjD.Size = New System.Drawing.Size(32, 22)
    Me.TxtObjD.TabIndex = 23
    '
    'TxtDptD
    '
    Me.TxtDptD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDptD.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDptD.Location = New System.Drawing.Point(164, 108)
    Me.TxtDptD.MaxLength = 4
    Me.TxtDptD.Name = "TxtDptD"
    Me.TxtDptD.Size = New System.Drawing.Size(45, 22)
    Me.TxtDptD.TabIndex = 22
    '
    'TxtSfndD
    '
    Me.TxtSfndD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfndD.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfndD.Location = New System.Drawing.Point(126, 108)
    Me.TxtSfndD.MaxLength = 3
    Me.TxtSfndD.Name = "TxtSfndD"
    Me.TxtSfndD.Size = New System.Drawing.Size(32, 22)
    Me.TxtSfndD.TabIndex = 21
    '
    'TxtSfcnC
    '
    Me.TxtSfcnC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfcnC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfcnC.Location = New System.Drawing.Point(302, 82)
    Me.TxtSfcnC.MaxLength = 4
    Me.TxtSfcnC.Name = "TxtSfcnC"
    Me.TxtSfcnC.Size = New System.Drawing.Size(45, 22)
    Me.TxtSfcnC.TabIndex = 18
    '
    'TxtFcnC
    '
    Me.TxtFcnC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFcnC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFcnC.Location = New System.Drawing.Point(251, 82)
    Me.TxtFcnC.MaxLength = 4
    Me.TxtFcnC.Name = "TxtFcnC"
    Me.TxtFcnC.Size = New System.Drawing.Size(45, 22)
    Me.TxtFcnC.TabIndex = 17
    '
    'TxtObjC
    '
    Me.TxtObjC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObjC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObjC.Location = New System.Drawing.Point(215, 82)
    Me.TxtObjC.MaxLength = 3
    Me.TxtObjC.Name = "TxtObjC"
    Me.TxtObjC.Size = New System.Drawing.Size(32, 22)
    Me.TxtObjC.TabIndex = 16
    '
    'TxtDptC
    '
    Me.TxtDptC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDptC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDptC.Location = New System.Drawing.Point(164, 82)
    Me.TxtDptC.MaxLength = 4
    Me.TxtDptC.Name = "TxtDptC"
    Me.TxtDptC.Size = New System.Drawing.Size(45, 22)
    Me.TxtDptC.TabIndex = 15
    '
    'TxtSfndC
    '
    Me.TxtSfndC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfndC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfndC.Location = New System.Drawing.Point(126, 82)
    Me.TxtSfndC.MaxLength = 3
    Me.TxtSfndC.Name = "TxtSfndC"
    Me.TxtSfndC.Size = New System.Drawing.Size(32, 22)
    Me.TxtSfndC.TabIndex = 14
    '
    'TxtFndD
    '
    Me.TxtFndD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFndD.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFndD.Location = New System.Drawing.Point(88, 108)
    Me.TxtFndD.MaxLength = 3
    Me.TxtFndD.Name = "TxtFndD"
    Me.TxtFndD.Size = New System.Drawing.Size(32, 22)
    Me.TxtFndD.TabIndex = 19
    '
    'TxtFndC
    '
    Me.TxtFndC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFndC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFndC.Location = New System.Drawing.Point(88, 82)
    Me.TxtFndC.MaxLength = 3
    Me.TxtFndC.Name = "TxtFndC"
    Me.TxtFndC.Size = New System.Drawing.Size(32, 22)
    Me.TxtFndC.TabIndex = 13
    '
    'LnkGLAcctM
    '
    Me.LnkGLAcctM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkGLAcctM.ForeColor = System.Drawing.Color.Maroon
    Me.LnkGLAcctM.Location = New System.Drawing.Point(12, 19)
    Me.LnkGLAcctM.Name = "LnkGLAcctM"
    Me.LnkGLAcctM.Size = New System.Drawing.Size(60, 18)
    Me.LnkGLAcctM.TabIndex = 26
    Me.LnkGLAcctM.TabStop = True
    Me.LnkGLAcctM.Text = "Map Acct"
    '
    'TxtSfcnM
    '
    Me.TxtSfcnM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfcnM.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfcnM.Location = New System.Drawing.Point(302, 13)
    Me.TxtSfcnM.MaxLength = 4
    Me.TxtSfcnM.Name = "TxtSfcnM"
    Me.TxtSfcnM.Size = New System.Drawing.Size(45, 22)
    Me.TxtSfcnM.TabIndex = 32
    '
    'TxtFcnM
    '
    Me.TxtFcnM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFcnM.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFcnM.Location = New System.Drawing.Point(251, 13)
    Me.TxtFcnM.MaxLength = 4
    Me.TxtFcnM.Name = "TxtFcnM"
    Me.TxtFcnM.Size = New System.Drawing.Size(45, 22)
    Me.TxtFcnM.TabIndex = 31
    '
    'TxtObjM
    '
    Me.TxtObjM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObjM.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObjM.Location = New System.Drawing.Point(215, 13)
    Me.TxtObjM.MaxLength = 3
    Me.TxtObjM.Name = "TxtObjM"
    Me.TxtObjM.Size = New System.Drawing.Size(32, 22)
    Me.TxtObjM.TabIndex = 30
    '
    'TxtDptM
    '
    Me.TxtDptM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDptM.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDptM.Location = New System.Drawing.Point(164, 13)
    Me.TxtDptM.MaxLength = 4
    Me.TxtDptM.Name = "TxtDptM"
    Me.TxtDptM.Size = New System.Drawing.Size(45, 22)
    Me.TxtDptM.TabIndex = 29
    '
    'TxtSfndM
    '
    Me.TxtSfndM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfndM.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfndM.Location = New System.Drawing.Point(126, 13)
    Me.TxtSfndM.MaxLength = 3
    Me.TxtSfndM.Name = "TxtSfndM"
    Me.TxtSfndM.Size = New System.Drawing.Size(32, 22)
    Me.TxtSfndM.TabIndex = 28
    '
    'TxtFndM
    '
    Me.TxtFndM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFndM.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFndM.Location = New System.Drawing.Point(88, 13)
    Me.TxtFndM.MaxLength = 3
    Me.TxtFndM.Name = "TxtFndM"
    Me.TxtFndM.Size = New System.Drawing.Size(32, 22)
    Me.TxtFndM.TabIndex = 27
    '
    'TxtDesc
    '
    Me.TxtDesc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDesc.Location = New System.Drawing.Point(88, 41)
    Me.TxtDesc.MaxLength = 20
    Me.TxtDesc.Name = "TxtDesc"
    Me.TxtDesc.Size = New System.Drawing.Size(145, 22)
    Me.TxtDesc.TabIndex = 33
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(12, 45)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(70, 20)
    Me.Label4.TabIndex = 342
    Me.Label4.Text = "Description"
    '
    'FrmPRA02C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(355, 141)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtDesc)
    Me.Controls.Add(Me.LnkGLAcctM)
    Me.Controls.Add(Me.TxtSfcnM)
    Me.Controls.Add(Me.TxtFcnM)
    Me.Controls.Add(Me.TxtObjM)
    Me.Controls.Add(Me.TxtDptM)
    Me.Controls.Add(Me.TxtSfndM)
    Me.Controls.Add(Me.TxtFndM)
    Me.Controls.Add(Me.LnkGLAcctD)
    Me.Controls.Add(Me.LnkGLAcctC)
    Me.Controls.Add(Me.TxtSfcnD)
    Me.Controls.Add(Me.TxtFcnD)
    Me.Controls.Add(Me.TxtObjD)
    Me.Controls.Add(Me.TxtDptD)
    Me.Controls.Add(Me.TxtSfndD)
    Me.Controls.Add(Me.TxtSfcnC)
    Me.Controls.Add(Me.TxtFcnC)
    Me.Controls.Add(Me.TxtObjC)
    Me.Controls.Add(Me.TxtDptC)
    Me.Controls.Add(Me.TxtSfndC)
    Me.Controls.Add(Me.TxtFndD)
    Me.Controls.Add(Me.TxtFndC)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmPRA02C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmPRA02C_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  End Sub

  Private Sub FrmPRA02C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    myPRGLMAP = New PRGLMAP.MyData(myDBConnect)
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect

    MyFrmPRA02.TbarNew.Enabled = False
    MyFrmPRA02.TBarSave.Enabled = True
    MyFrmPRA02.TBarDelete.Enabled = False
    If WrkFdnbr > 0 Then
      MyUtils.SetTxtReadOnly(TxtFndM)
      MyUtils.SetTxtReadOnly(TxtSfndM)
      MyUtils.SetTxtReadOnly(TxtDptM)
      MyUtils.SetTxtReadOnly(TxtObjM)
      MyUtils.SetTxtReadOnly(TxtFcnM)
      MyUtils.SetTxtReadOnly(TxtSfcnM)
      MyUtils.SetTxtReadOnly(TxtDesc)
      LnkGLAcctM.Enabled = False
    End If

    If s_chg = False And s_full = False Then    '#sec
      MyFrmPRA02.TBarSave.Visible = False
    End If
    If s_del = False And s_full = False Then    '#sec
      MyFrmPRA02.TBarDelete.Visible = False
    End If

    myPRGLMAP.GetOneRecordP(WrkFdnbr, WrkSfund, WrkDpnbr, WrkObnbr, WrkFnpgm, WrkSubfn, WrkDesc)
    If Not myPRGLMAP.RecordNotFound Then
      MyFrmPRA02.TBarDelete.Enabled = True
    End If

    With myPRGLMAP
      TxtFndM.Text = Format(._PFUND, "000")
      TxtSfndM.Text = Format(._PSFUND, "000")
      TxtDptM.Text = Format(._PDEPT, "0000")
      TxtObjM.Text = Format(._POBJ, "000")
      TxtFcnM.Text = Format(._PFUNC, "0000")
      TxtSfcnM.Text = Format(._PSFUNC, "0000")
      TxtDesc.Text = Trim(._PDESC)
      TxtFndC.Text = Format(._CFUND, "000")
      TxtSfndC.Text = Format(._CSFUND, "000")
      TxtDptC.Text = Format(._CDEPT, "0000")
      TxtObjC.Text = Format(._COBJ, "000")
      TxtFcnC.Text = Format(._CFUNC, "0000")
      TxtSfcnC.Text = Format(._CSFUNC, "0000")
      TxtFndD.Text = Format(._DFUND, "000")
      TxtSfndD.Text = Format(._DSFUND, "000")
      TxtDptD.Text = Format(._DDEPT, "0000")
      TxtObjD.Text = Format(._DOBJ, "000")
      TxtFcnD.Text = Format(._DFUNC, "0000")
      TxtSfcnD.Text = Format(._DSFUNC, "0000")
    End With
  End Sub

  Private Sub FrmPRA02C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmPRA02.TbarNew.Enabled = True
    MyFrmPRA02.TBarDelete.Enabled = False
    MyFrmPRA02.TBarSave.Enabled = False
    With MyFrmPRA02B
      .TxtFdnbr.Text = WrkFdnbr
      .TxtSfund.Text = WrkSfund
      .TxtDpnbr.Text = WrkDpnbr
      .TxtFnpgm.Text = WrkFnpgm
      .TxtObnbr.Text = WrkObnbr
      .TxtSubfn.Text = WrkSubfn
      .FormatGrid()
      .Show()
    End With

  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer

    myPRGLMAP.GetOneRecordP(MyUtils.CnvSng(TxtFndM.Text), MyUtils.CnvSng(TxtSfndM.Text), MyUtils.CnvSng(TxtDptM.Text),
    MyUtils.CnvSng(TxtObjM.Text), MyUtils.CnvSng(TxtFcnM.Text), MyUtils.CnvSng(TxtSfcnM.Text), TxtDesc.Text)
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    myPRGLMAP.DeleteOneRecordP()
    Me.Close()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    myPRGLMAP.GetOneRecordP(MyUtils.CnvSng(TxtFndM.Text), MyUtils.CnvSng(TxtSfndM.Text), MyUtils.CnvSng(TxtDptM.Text),
    MyUtils.CnvSng(TxtObjM.Text), MyUtils.CnvSng(TxtFcnM.Text), MyUtils.CnvSng(TxtSfcnM.Text), TxtDesc.Text)
    If WrkFdnbr = 0 Then
      If Not myPRGLMAP.RecordNotFound Then
        Me.ErrProv.SetError(TxtFcnM, "Record already exists")
        Exit Sub
      End If
    End If

    If WrkFdnbr > 0 Then
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myPRGLMAP.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      myPRGLMAP._PFUND = MyUtils.CnvSng(TxtFndM.Text)
      myPRGLMAP._PSFUND = MyUtils.CnvSng(TxtSfndM.Text)
      myPRGLMAP._PDEPT = MyUtils.CnvSng(TxtDptM.Text)
      myPRGLMAP._POBJ = MyUtils.CnvSng(TxtObjM.Text)
      myPRGLMAP._PFUNC = MyUtils.CnvSng(TxtFcnM.Text)
      myPRGLMAP._PSFUNC = MyUtils.CnvSng(TxtSfcnM.Text)
      myPRGLMAP._PDESC = TxtDesc.Text
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myPRGLMAP.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()
  End Sub
  Private Sub MoveToFile()
    With myPRGLMAP
      ._CFUND = MyUtils.CnvSng(TxtFndC.Text)
      ._CSFUND = MyUtils.CnvSng(TxtSfndC.Text)
      ._CDEPT = MyUtils.CnvSng(TxtDptC.Text)
      ._COBJ = MyUtils.CnvSng(TxtObjC.Text)
      ._CFUNC = MyUtils.CnvSng(TxtFcnC.Text)
      ._CSFUNC = MyUtils.CnvSng(TxtSfcnC.Text)
      ._DFUND = MyUtils.CnvSng(TxtFndD.Text)
      ._DSFUND = MyUtils.CnvSng(TxtSfndD.Text)
      ._DDEPT = MyUtils.CnvSng(TxtDptD.Text)
      ._DOBJ = MyUtils.CnvSng(TxtObjD.Text)
      ._DFUNC = MyUtils.CnvSng(TxtFcnD.Text)
      ._DSFUNC = MyUtils.CnvSng(TxtSfcnD.Text)
    End With
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    'If MyUtils.CnvSng(TxtFndM.Text) > 0 Or MyUtils.CnvSng(TxtSfndM.Text) > 0 Or MyUtils.CnvSng(TxtDptM.Text) > 0 Or _
    '  MyUtils.CnvSng(TxtObjM.Text) > 0 Or MyUtils.CnvSng(TxtFcnM.Text) > 0 Or MyUtils.CnvSng(TxtSfcnM.Text) > 0 Then
    '  myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFndM.Text), MyUtils.CnvSng(TxtSfndM.Text), MyUtils.CnvSng(TxtDptM.Text), _
    '  MyUtils.CnvSng(TxtObjM.Text), MyUtils.CnvSng(TxtFcnM.Text), MyUtils.CnvSng(TxtSfcnM.Text))
    '  If myGLACCT.RecordNotFound Then
    '    ErrorField(I) = "acctm"
    '    ErrorMsg(I) = "Acct is invalid"
    '    I = I + 1
    '  End If
    'End If

    If MyUtils.CnvSng(TxtFndC.Text) > 0 Or MyUtils.CnvSng(TxtSfndC.Text) > 0 Or MyUtils.CnvSng(TxtDptC.Text) > 0 Or
    MyUtils.CnvSng(TxtObjC.Text) > 0 Or MyUtils.CnvSng(TxtFcnC.Text) > 0 Or MyUtils.CnvSng(TxtSfcnC.Text) > 0 Then
      myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFndC.Text), MyUtils.CnvSng(TxtSfndC.Text), MyUtils.CnvSng(TxtDptC.Text),
      MyUtils.CnvSng(TxtObjC.Text), MyUtils.CnvSng(TxtFcnC.Text), MyUtils.CnvSng(TxtSfcnC.Text))
      If myGLACCT.RecordNotFound Then
        ErrorField(I) = "acctc"
        ErrorMsg(I) = "Acct is invalid"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtFndD.Text) > 0 Or MyUtils.CnvSng(TxtSfndD.Text) > 0 Or MyUtils.CnvSng(TxtDptD.Text) > 0 Or
    MyUtils.CnvSng(TxtObjD.Text) > 0 Or MyUtils.CnvSng(TxtFcnD.Text) > 0 Or MyUtils.CnvSng(TxtSfcnD.Text) > 0 Then
      myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFndD.Text), MyUtils.CnvSng(TxtSfndD.Text), MyUtils.CnvSng(TxtDptD.Text),
      MyUtils.CnvSng(TxtObjD.Text), MyUtils.CnvSng(TxtFcnD.Text), MyUtils.CnvSng(TxtSfcnD.Text))
      If myGLACCT.RecordNotFound Then
        ErrorField(I) = "acctd"
        ErrorMsg(I) = "Acct is invalid"
        I = I + 1
      End If
    End If

    If TxtDesc.Text = String.Empty Then
      ErrorField(I) = "desc"
      ErrorMsg(I) = "Description is required"
      I = I + 1
    End If

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    'ErrProv.SetError(TxtFndM, "")
    ErrProv.SetError(TxtFndC, "")
    ErrProv.SetError(TxtFndD, "")
    ErrProv.SetError(TxtDesc, "")
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
   'Case "acctm"
   ' ErrProv.SetError(TxtFndM, ErrorMsg(I))
        Case "acctc"
          ErrProv.SetError(TxtFndC, ErrorMsg(I))
        Case "acctd"
          ErrProv.SetError(TxtFndD, ErrorMsg(I))
        Case "desc"
          ErrProv.SetError(TxtDesc, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub FrmPRA02C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmPRA02.SbpScreen.Text = "PRA02C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub TxtFndM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFndM.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfndM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSfcnM.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDptM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDptM.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtObjM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtObjM.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFcnM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFcnM.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfcmM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSfcnM.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFndC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFndC.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfndC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSfcnC.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDptC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDptC.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtObjC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtObjC.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFcnC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFcnC.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfcmC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSfcnC.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFndD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFndD.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfndD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSfcnD.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDptD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDptD.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtObjD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtObjD.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFcnD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFcnD.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfcmD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSfcnD.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub LnkGLAcctM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkGLAcctM.LinkClicked
    Dim WrkAcct As String

    WrkAcct = BuildAcct(MyUtils.CnvSng(TxtFndM.Text), MyUtils.CnvSng(TxtSfndM.Text), MyUtils.CnvSng(TxtDptM.Text),
    MyUtils.CnvSng(TxtObjM.Text), MyUtils.CnvSng(TxtFcnM.Text), MyUtils.CnvSng(TxtSfcnM.Text))
    MyFrmListGLAcct = New FrmListGLAcct
    MyFrmListGLAcct.MdiParent = Me.ParentForm
    MyFrmListGLAcct.WrkField = "M"
    MyFrmListGLAcct.WrkCode = WrkAcct
    MyFrmListGLAcct.Show()
    Me.Hide()
  End Sub
  Private Sub LnkGLAcctC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkGLAcctC.LinkClicked
    Dim WrkAcct As String

    WrkAcct = BuildAcct(MyUtils.CnvSng(TxtFndC.Text), MyUtils.CnvSng(TxtSfndC.Text), MyUtils.CnvSng(TxtDptC.Text),
    MyUtils.CnvSng(TxtObjC.Text), MyUtils.CnvSng(TxtFcnC.Text), MyUtils.CnvSng(TxtSfcnC.Text))
    MyFrmListGLAcct = New FrmListGLAcct
    MyFrmListGLAcct.MdiParent = Me.ParentForm
    MyFrmListGLAcct.WrkField = "C"
    MyFrmListGLAcct.WrkCode = WrkAcct
    MyFrmListGLAcct.Show()
    Me.Hide()
  End Sub
  Private Sub LnkGLAcctD_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkGLAcctD.LinkClicked
    Dim WrkAcct As String

    WrkAcct = BuildAcct(MyUtils.CnvSng(TxtFndD.Text), MyUtils.CnvSng(TxtSfndD.Text), MyUtils.CnvSng(TxtDptD.Text),
    MyUtils.CnvSng(TxtObjD.Text), MyUtils.CnvSng(TxtFcnD.Text), MyUtils.CnvSng(TxtSfcnD.Text))
    MyFrmListGLAcct = New FrmListGLAcct
    MyFrmListGLAcct.MdiParent = Me.ParentForm
    MyFrmListGLAcct.WrkField = "D"
    MyFrmListGLAcct.WrkCode = WrkAcct
    MyFrmListGLAcct.Show()
    Me.Hide()
  End Sub
End Class
