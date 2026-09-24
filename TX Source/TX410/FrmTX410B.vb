Public Class FrmTX410B
  Inherits System.Windows.Forms.Form

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
  Friend WithEvents TxtBankSvc As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents TxtBankCd As System.Windows.Forms.TextBox
  Friend WithEvents LnkBankCd As System.Windows.Forms.LinkLabel
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents RbChange As RadioButton
  Friend WithEvents RbRemove As RadioButton
  Friend WithEvents TxtBankCd2 As TextBox
  Friend WithEvents LnkBankCd2 As LinkLabel

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ChkPost = New System.Windows.Forms.CheckBox()
    Me.TxtBankSvc = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtBankCd = New System.Windows.Forms.TextBox()
    Me.LnkBankCd = New System.Windows.Forms.LinkLabel()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.RbRemove = New System.Windows.Forms.RadioButton()
    Me.RbChange = New System.Windows.Forms.RadioButton()
    Me.TxtBankCd2 = New System.Windows.Forms.TextBox()
    Me.LnkBankCd2 = New System.Windows.Forms.LinkLabel()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ChkPost
    '
    Me.ChkPost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPost.Location = New System.Drawing.Point(32, 105)
    Me.ChkPost.Name = "ChkPost"
    Me.ChkPost.Size = New System.Drawing.Size(84, 16)
    Me.ChkPost.TabIndex = 3
    Me.ChkPost.Text = "Post to file?"
    '
    'TxtBankSvc
    '
    Me.TxtBankSvc.Location = New System.Drawing.Point(105, 69)
    Me.TxtBankSvc.MaxLength = 1
    Me.TxtBankSvc.Name = "TxtBankSvc"
    Me.TxtBankSvc.Size = New System.Drawing.Size(22, 20)
    Me.TxtBankSvc.TabIndex = 2
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(29, 72)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(71, 13)
    Me.Label1.TabIndex = 60
    Me.Label1.Text = "Bank Service"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtBankCd
    '
    Me.TxtBankCd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBankCd.Location = New System.Drawing.Point(105, 43)
    Me.TxtBankCd.MaxLength = 2
    Me.TxtBankCd.Name = "TxtBankCd"
    Me.TxtBankCd.Size = New System.Drawing.Size(24, 20)
    Me.TxtBankCd.TabIndex = 0
    '
    'LnkBankCd
    '
    Me.LnkBankCd.AutoSize = True
    Me.LnkBankCd.Location = New System.Drawing.Point(29, 47)
    Me.LnkBankCd.Name = "LnkBankCd"
    Me.LnkBankCd.Size = New System.Drawing.Size(70, 13)
    Me.LnkBankCd.TabIndex = 6
    Me.LnkBankCd.TabStop = True
    Me.LnkBankCd.Text = "Escrow Bank"
    '
    'RbRemove
    '
    Me.RbRemove.AutoSize = True
    Me.RbRemove.Checked = True
    Me.RbRemove.Location = New System.Drawing.Point(32, 13)
    Me.RbRemove.Name = "RbRemove"
    Me.RbRemove.Size = New System.Drawing.Size(93, 17)
    Me.RbRemove.TabIndex = 4
    Me.RbRemove.TabStop = True
    Me.RbRemove.Text = "Remove Code"
    Me.RbRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbRemove.UseVisualStyleBackColor = True
    '
    'RbChange
    '
    Me.RbChange.AutoSize = True
    Me.RbChange.Location = New System.Drawing.Point(156, 12)
    Me.RbChange.Name = "RbChange"
    Me.RbChange.Size = New System.Drawing.Size(90, 17)
    Me.RbChange.TabIndex = 5
    Me.RbChange.Text = "Change Code"
    Me.RbChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbChange.UseVisualStyleBackColor = True
    '
    'TxtBankCd2
    '
    Me.TxtBankCd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBankCd2.Location = New System.Drawing.Point(216, 43)
    Me.TxtBankCd2.MaxLength = 2
    Me.TxtBankCd2.Name = "TxtBankCd2"
    Me.TxtBankCd2.Size = New System.Drawing.Size(24, 20)
    Me.TxtBankCd2.TabIndex = 1
    '
    'LnkBankCd2
    '
    Me.LnkBankCd2.AutoSize = True
    Me.LnkBankCd2.Location = New System.Drawing.Point(162, 47)
    Me.LnkBankCd2.Name = "LnkBankCd2"
    Me.LnkBankCd2.Size = New System.Drawing.Size(48, 13)
    Me.LnkBankCd2.TabIndex = 7
    Me.LnkBankCd2.TabStop = True
    Me.LnkBankCd2.Text = "To Bank"
    '
    'FrmTX410B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(286, 149)
    Me.ControlBox = False
    Me.Controls.Add(Me.TxtBankCd2)
    Me.Controls.Add(Me.LnkBankCd2)
    Me.Controls.Add(Me.RbChange)
    Me.Controls.Add(Me.RbRemove)
    Me.Controls.Add(Me.TxtBankCd)
    Me.Controls.Add(Me.LnkBankCd)
    Me.Controls.Add(Me.TxtBankSvc)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.ChkPost)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX410B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region
  Dim myTXBANKS As TXBANKS.myData

  Public Sub RunReport()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    myTXBANKS = New TXBANKS.mydata(MyDBConnect)

    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If

    Me.Refresh()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    PrtReport()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtBankCd, "")
    ErrProv.SetError(TxtBankSvc, "")
    ErrProv.SetError(TxtBankCd2, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "code"
          ErrProv.SetError(TxtBankCd, ErrorMsg(I))
        Case "code2"
          ErrProv.SetError(TxtBankCd2, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim ds As DataSet = New DataSet
    Dim I As Integer
    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If RbChange.Checked Then
      If TxtBankCd.Text = "" Then
        ErrorField(I) = "code"
        ErrorMsg(I) = "Bank Code is required"
        I = I + 1
      End If

      myTXBANKS.GetOneRecordP(TxtBankCd2.Text)
      If myTXBANKS.RecordNotFound Then
        ErrorField(I) = "code2"
        ErrorMsg(I) = "Bank Code is invalid"
        I = I + 1
      End If
    End If

  End Sub
  Private Sub FrmTX410B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTX410.SbpScreen.Text = "TX410B"
  End Sub
  Private Sub LnkBankCd1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBankCd.LinkClicked
    MyFrmListBanks = New FrmListBanks
    MyFrmListBanks.MdiParent = Me.ParentForm
    MyFrmListBanks.WrkCode = TxtBankCd.Text
    MyFrmListBanks.WrkField = "1"
    MyFrmListBanks.Show()
  End Sub
  Private Sub LnkBankCd2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBankCd2.LinkClicked
    MyFrmListBanks = New FrmListBanks
    MyFrmListBanks.MdiParent = Me.ParentForm
    MyFrmListBanks.WrkCode = TxtBankCd2.Text
    MyFrmListBanks.WrkField = "2"
    MyFrmListBanks.Show()
  End Sub
  Private Sub RbChange_Click(sender As Object, e As EventArgs) Handles RbChange.Click
    LnkBankCd2.Enabled = True
    TxtBankCd2.Enabled = True
  End Sub

  Private Sub RbRemove_Click(sender As Object, e As EventArgs) Handles RbRemove.Click
    LnkBankCd2.Enabled = False
    TxtBankCd2.Text = ""
    TxtBankCd2.Enabled = False
  End Sub
  Private Sub FrmTX410B_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    LnkBankCd2.Enabled = False
    TxtBankCd2.Enabled = False
  End Sub
End Class






