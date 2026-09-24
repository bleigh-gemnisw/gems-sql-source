Public Class FrmAP504B
  Inherits System.Windows.Forms.Form
  Dim myAPEBNK As APEBNK.MyData
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
  Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
  Friend WithEvents LnkBank As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtBank As System.Windows.Forms.TextBox
  Friend WithEvents TxtChkTo As TextBox
  Friend WithEvents LblChkTo As Label
  Friend WithEvents TxtChkFrom As TextBox
  Friend WithEvents LblChkFrom As Label
  Friend WithEvents DtPckTo As DateTimePicker
  Friend WithEvents Label2 As Label
  Friend WithEvents DtPckFrom As DateTimePicker
  Friend WithEvents ChkRecon As CheckBox
  Friend WithEvents ChkOpen As CheckBox
  Friend WithEvents LblChkNum As Label
  Friend WithEvents Label4 As Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.LnkBank = New System.Windows.Forms.LinkLabel()
    Me.TxtBank = New System.Windows.Forms.TextBox()
    Me.TxtChkTo = New System.Windows.Forms.TextBox()
    Me.LblChkTo = New System.Windows.Forms.Label()
    Me.TxtChkFrom = New System.Windows.Forms.TextBox()
    Me.LblChkFrom = New System.Windows.Forms.Label()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.LblChkNum = New System.Windows.Forms.Label()
    Me.ChkOpen = New System.Windows.Forms.CheckBox()
    Me.ChkRecon = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LnkBank
    '
    Me.LnkBank.AutoSize = True
    Me.LnkBank.Location = New System.Drawing.Point(36, 32)
    Me.LnkBank.Name = "LnkBank"
    Me.LnkBank.Size = New System.Drawing.Size(60, 13)
    Me.LnkBank.TabIndex = 0
    Me.LnkBank.TabStop = True
    Me.LnkBank.Text = "Bank Code"
    '
    'TxtBank
    '
    Me.TxtBank.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBank.Location = New System.Drawing.Point(102, 29)
    Me.TxtBank.MaxLength = 5
    Me.TxtBank.Name = "TxtBank"
    Me.TxtBank.Size = New System.Drawing.Size(48, 20)
    Me.TxtBank.TabIndex = 1
    '
    'TxtChkTo
    '
    Me.TxtChkTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtChkTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtChkTo.Location = New System.Drawing.Point(254, 86)
    Me.TxtChkTo.MaxLength = 7
    Me.TxtChkTo.Name = "TxtChkTo"
    Me.TxtChkTo.Size = New System.Drawing.Size(60, 20)
    Me.TxtChkTo.TabIndex = 83
    '
    'LblChkTo
    '
    Me.LblChkTo.Location = New System.Drawing.Point(181, 89)
    Me.LblChkTo.Name = "LblChkTo"
    Me.LblChkTo.Size = New System.Drawing.Size(70, 15)
    Me.LblChkTo.TabIndex = 87
    Me.LblChkTo.Text = "To Number*"
    '
    'TxtChkFrom
    '
    Me.TxtChkFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtChkFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtChkFrom.Location = New System.Drawing.Point(117, 86)
    Me.TxtChkFrom.MaxLength = 7
    Me.TxtChkFrom.Name = "TxtChkFrom"
    Me.TxtChkFrom.Size = New System.Drawing.Size(57, 20)
    Me.TxtChkFrom.TabIndex = 82
    '
    'LblChkFrom
    '
    Me.LblChkFrom.Location = New System.Drawing.Point(30, 89)
    Me.LblChkFrom.Name = "LblChkFrom"
    Me.LblChkFrom.Size = New System.Drawing.Size(81, 15)
    Me.LblChkFrom.TabIndex = 86
    Me.LblChkFrom.Text = "From Number*"
    '
    'DtPckTo
    '
    Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTo.Location = New System.Drawing.Point(254, 60)
    Me.DtPckTo.Name = "DtPckTo"
    Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
    Me.DtPckTo.TabIndex = 81
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(199, 64)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(52, 16)
    Me.Label2.TabIndex = 85
    Me.Label2.Text = "To Date"
    '
    'DtPckFrom
    '
    Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFrom.Location = New System.Drawing.Point(96, 60)
    Me.DtPckFrom.Name = "DtPckFrom"
    Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
    Me.DtPckFrom.TabIndex = 80
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(36, 64)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(60, 16)
    Me.Label4.TabIndex = 84
    Me.Label4.Text = "From Date"
    '
    'LblChkNum
    '
    Me.LblChkNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChkNum.Location = New System.Drawing.Point(-1, 174)
    Me.LblChkNum.Name = "LblChkNum"
    Me.LblChkNum.Size = New System.Drawing.Size(439, 15)
    Me.LblChkNum.TabIndex = 88
    Me.LblChkNum.Text = "*=When Check Number range is entered then Date Range will be ignored"
    Me.LblChkNum.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'ChkOpen
    '
    Me.ChkOpen.AutoSize = True
    Me.ChkOpen.Checked = True
    Me.ChkOpen.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkOpen.Location = New System.Drawing.Point(30, 124)
    Me.ChkOpen.Name = "ChkOpen"
    Me.ChkOpen.Size = New System.Drawing.Size(52, 17)
    Me.ChkOpen.TabIndex = 89
    Me.ChkOpen.Text = "Open"
    Me.ChkOpen.UseVisualStyleBackColor = True
    '
    'ChkRecon
    '
    Me.ChkRecon.AutoSize = True
    Me.ChkRecon.Checked = True
    Me.ChkRecon.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkRecon.Location = New System.Drawing.Point(96, 124)
    Me.ChkRecon.Name = "ChkRecon"
    Me.ChkRecon.Size = New System.Drawing.Size(80, 17)
    Me.ChkRecon.TabIndex = 90
    Me.ChkRecon.Text = "Reconciled"
    Me.ChkRecon.UseVisualStyleBackColor = True
    '
    'FrmAP504B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(437, 192)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkRecon)
    Me.Controls.Add(Me.ChkOpen)
    Me.Controls.Add(Me.LblChkNum)
    Me.Controls.Add(Me.TxtChkTo)
    Me.Controls.Add(Me.LblChkTo)
    Me.Controls.Add(Me.TxtChkFrom)
    Me.Controls.Add(Me.LblChkFrom)
    Me.Controls.Add(Me.DtPckTo)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.DtPckFrom)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtBank)
    Me.Controls.Add(Me.LnkBank)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmAP504B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Public Sub RunReport()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

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
  Private Sub FrmAP504B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmAP504.SbpPgmID.Text = "AP504B"
    MyFrmAP504.SbpEnvironment.Text = myDBConnect.PgmDB
    DtPckFrom.Value = Date.Today
    DtPckTo.Value = Date.Today
  End Sub
  Private Sub FrmAP504B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmAP504.SbpScreen.Text = "AP504B"
  End Sub
  Private Sub FrmAP504B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.Clear()

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "date"
          ErrProv.SetError(DtPckTo, ErrorMsg(I))
        Case "check"
          ErrProv.SetError(TxtChkFrom, ErrorMsg(I))
          ErrProv.SetError(TxtChkTo, ErrorMsg(I))
        Case "bank"
          ErrProv.SetError(TxtBank, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    myAPEBNK = New APEBNK.MyData()
    myAPEBNK.MyDBConn = myDBConnect
    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If DtPckFrom.Value > DtPckTo.Value Then
      ErrorField(I) = "date"
      ErrorMsg(I) = "Invalid Date Range"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtChkFrom.Text) > MyUtils.CnvSng(TxtChkTo.Text) Then
      ErrorField(I) = "check"
      ErrorMsg(I) = "Invalid Check Range"
      I = I + 1
    End If

    If TxtBank.Text = String.Empty Then
      ErrorField(I) = "bank"
      ErrorMsg(I) = "Bank Code is required"
      I = I + 1
    Else
      myAPEBNK.GetOneRecordP(TxtBank.Text)
      If myAPEBNK.RecordNotFound = True Then
        ErrorField(I) = "bank"
        ErrorMsg(I) = "Bank Code is Invalid"
        I = I + 1
      End If
    End If

    myAPEBNK = Nothing
  End Sub
  Private Sub FrmAP504B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If Not e.Alt Then Exit Sub

    If e.KeyCode = Keys.F12 Then
      MyUtils.PrtScreen(Form.ActiveForm)
    End If
  End Sub
  Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBank.LinkClicked
    MyFrmListApebnk = New FrmListApebnk
    MyFrmListApebnk.TxtPos.Text = TxtBank.Text
    MyFrmListApebnk.MdiParent = Me.ParentForm
    MyFrmListApebnk.Show()
  End Sub
  Private Sub TxtChkFrom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtChkTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
End Class
