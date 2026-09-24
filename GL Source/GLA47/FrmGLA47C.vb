Public Class FrmGLA47C
  Inherits System.Windows.Forms.Form
  Dim myTXGLNB As TXGLNB.myData
  Dim ds As DataSet = New DataSet
  Friend WrkTxyr As Integer
  Friend WrkTran As String
  Friend WrkCode As String
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TxtCode As System.Windows.Forms.TextBox
  Friend WithEvents TxtAcctDB As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtAcctCR As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtTxyr As System.Windows.Forms.TextBox
  Friend WithEvents TxtAcctCR2 As TextBox
  Friend WithEvents Label7 As Label
  Friend WithEvents TxtAcctDB2 As TextBox
  Friend WithEvents Label8 As Label
  Friend WithEvents TxtTran As System.Windows.Forms.TextBox

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
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.TxtCode = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtAcctDB = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtDesc = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtTran = New System.Windows.Forms.TextBox()
    Me.TxtAcctCR = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtTxyr = New System.Windows.Forms.TextBox()
    Me.TxtAcctCR2 = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtAcctDB2 = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtCode
    '
    Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode.Location = New System.Drawing.Point(295, 9)
    Me.TxtCode.MaxLength = 5
    Me.TxtCode.Name = "TxtCode"
    Me.TxtCode.Size = New System.Drawing.Size(51, 20)
    Me.TxtCode.TabIndex = 2
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(257, 9)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(32, 13)
    Me.Label5.TabIndex = 343
    Me.Label5.Text = "Code"
    '
    'TxtAcctDB
    '
    Me.TxtAcctDB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAcctDB.Location = New System.Drawing.Point(55, 72)
    Me.TxtAcctDB.MaxLength = 50
    Me.TxtAcctDB.Name = "TxtAcctDB"
    Me.TxtAcctDB.Size = New System.Drawing.Size(362, 20)
    Me.TxtAcctDB.TabIndex = 4
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(8, 75)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(32, 13)
    Me.Label2.TabIndex = 344
    Me.Label2.Text = "Debit"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(10, 49)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(39, 20)
    Me.Label1.TabIndex = 351
    Me.Label1.Text = "Desc"
    '
    'TxtDesc
    '
    Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDesc.Location = New System.Drawing.Point(55, 46)
    Me.TxtDesc.MaxLength = 40
    Me.TxtDesc.Name = "TxtDesc"
    Me.TxtDesc.Size = New System.Drawing.Size(290, 20)
    Me.TxtDesc.TabIndex = 3
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(138, 9)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(29, 13)
    Me.Label4.TabIndex = 353
    Me.Label4.Text = "Tran"
    '
    'TxtTran
    '
    Me.TxtTran.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTran.Location = New System.Drawing.Point(183, 9)
    Me.TxtTran.MaxLength = 5
    Me.TxtTran.Name = "TxtTran"
    Me.TxtTran.Size = New System.Drawing.Size(49, 20)
    Me.TxtTran.TabIndex = 1
    '
    'TxtAcctCR
    '
    Me.TxtAcctCR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAcctCR.Location = New System.Drawing.Point(55, 98)
    Me.TxtAcctCR.MaxLength = 50
    Me.TxtAcctCR.Name = "TxtAcctCR"
    Me.TxtAcctCR.Size = New System.Drawing.Size(362, 20)
    Me.TxtAcctCR.TabIndex = 5
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(8, 101)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(34, 13)
    Me.Label3.TabIndex = 355
    Me.Label3.Text = "Credit"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(12, 9)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(29, 13)
    Me.Label6.TabIndex = 357
    Me.Label6.Text = "Year"
    '
    'TxtTxyr
    '
    Me.TxtTxyr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTxyr.Location = New System.Drawing.Point(57, 9)
    Me.TxtTxyr.MaxLength = 4
    Me.TxtTxyr.Name = "TxtTxyr"
    Me.TxtTxyr.Size = New System.Drawing.Size(36, 20)
    Me.TxtTxyr.TabIndex = 0
    '
    'TxtAcctCR2
    '
    Me.TxtAcctCR2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAcctCR2.Location = New System.Drawing.Point(55, 150)
    Me.TxtAcctCR2.MaxLength = 50
    Me.TxtAcctCR2.Name = "TxtAcctCR2"
    Me.TxtAcctCR2.Size = New System.Drawing.Size(362, 20)
    Me.TxtAcctCR2.TabIndex = 359
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(8, 153)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(43, 13)
    Me.Label7.TabIndex = 361
    Me.Label7.Text = "Credit 2"
    '
    'TxtAcctDB2
    '
    Me.TxtAcctDB2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAcctDB2.Location = New System.Drawing.Point(55, 124)
    Me.TxtAcctDB2.MaxLength = 50
    Me.TxtAcctDB2.Name = "TxtAcctDB2"
    Me.TxtAcctDB2.Size = New System.Drawing.Size(362, 20)
    Me.TxtAcctDB2.TabIndex = 358
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(8, 127)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(41, 13)
    Me.Label8.TabIndex = 360
    Me.Label8.Text = "Debit 2"
    '
    'FrmGLA47C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(429, 175)
    Me.Controls.Add(Me.TxtAcctCR2)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TxtAcctDB2)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.TxtTxyr)
    Me.Controls.Add(Me.TxtAcctCR)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtTran)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtDesc)
    Me.Controls.Add(Me.TxtAcctDB)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtCode)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGLA47C"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region


  Private Sub FrmGLA47C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXGLNB = New TXGLNB.MyData()
    myTXGLNB.MyDBConn = myDBConnect
    LoadForm()
  End Sub
  Private Sub LoadForm()
    MyFrmGLA47.TBarNew.Enabled = False
    MyFrmGLA47.TBarSave.Enabled = True
    MyFrmGLA47.TBarDelete.Enabled = True
    MyFrmGLA47.TBarPrint.Enabled = False
    MyFrmGLA47.TBarMass.Enabled = False

    myTXGLNB.GetOneRecordP(WrkTxyr, WrkTran, WrkCode)
    If myTXGLNB.RecordNotFound Then
      MyFrmGLA47.TBarDelete.Enabled = False
      Exit Sub
    End If

    With myTXGLNB
      MyUtils.SetTxtReadOnly(TxtTxyr)
      MyUtils.SetTxtReadOnly(TxtTran)
      MyUtils.SetTxtReadOnly(TxtCode)
      TxtTxyr.Text = WrkTxyr
      TxtTran.Text = WrkTran
      TxtCode.Text = WrkCode
      TxtDesc.Text = Trim(._DESCR)
      TxtAcctDB.Text = Trim(._ACCTDB)
      TxtAcctCR.Text = Trim(._ACCTCR)
      TxtAcctDB2.Text = Trim(._ACCTDB2)
      TxtAcctCR2.Text = Trim(._ACCTCR2)
    End With
  End Sub
  Private Sub FrmGLA47C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGLA47.SbpScreen.Text = "GLA47C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub

  Private Sub FrmGLA47C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmGLA47.TBarNew.Enabled = True
    MyFrmGLA47.TBarDelete.Enabled = False
    MyFrmGLA47.TBarSave.Enabled = False
    MyFrmGLA47.TBarNew.Enabled = True
    MyFrmGLA47.TBarPrint.Enabled = False
    MyFrmGLA47.TBarMass.Enabled = True
    MyFrmGLA47B.FormatGrid()
    MyFrmGLA47B.Show()
    'Memory Cleanup
    myTXGLNB = Nothing
    MyFrmGLA47C = Nothing
  End Sub
  Public Sub DeleteData()
    Dim Answer As Integer
    Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
    If Answer = vbNo Then
      Exit Sub
    End If

    '  myTXGLNB.GetOneRecordP(MyUtils.CnvSng(TxtTxyr.Text), TxtTran.Text, TxtCode.Text)
    myTXGLNB.DeleteOneRecordP()
    Me.Close()
  End Sub

  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    myTXGLNB.GetOneRecordP(MyUtils.CnvSng(TxtTxyr.Text), TxtTran.Text, TxtCode.Text)
    If WrkCode = String.Empty Then
      If Not myTXGLNB.RecordNotFound Then
        Me.ErrProv.SetError(TxtCode, "Record already exists")
        Exit Sub
      End If
    End If
    If Not myTXGLNB.RecordNotFound Then
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXGLNB.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        With myTXGLNB
          ._TXYR = MyUtils.CnvSng(TxtTxyr.Text)
          ._TRTY = TxtTran.Text
          ._CODE = TxtCode.Text
        End With
        myTXGLNB.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()
  End Sub
  Private Sub MovetoFile()
    With myTXGLNB
      ._DESCR = TxtDesc.Text
      ._ACCTCR = TxtAcctCR.Text
      ._ACCTDB = TxtAcctDB.Text
      ._ACCTCR2 = TxtAcctCR2.Text
      ._ACCTDB2 = TxtAcctDB2.Text
    End With
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If TxtCode.Text = String.Empty Then
      ErrorField(I) = "code"
      ErrorMsg(I) = "Code is required"
      I = I + 1
    End If

    If TxtDesc.Text = String.Empty Then
      ErrorField(I) = "desc"
      ErrorMsg(I) = "Description is required"
      I = I + 1
    End If
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtCode, String.Empty)
    ErrProv.SetError(TxtDesc, String.Empty)
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "code"
          ErrProv.SetError(TxtCode, ErrorMsg(I))
        Case "desc"
          ErrProv.SetError(TxtDesc, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
End Class
