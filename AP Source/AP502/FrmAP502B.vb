Public Class FrmAP502B
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
  Friend WithEvents rblist As System.Windows.Forms.RadioButton
  Friend WithEvents DtPckpdate As DateTimePicker
  Friend WithEvents DtPckcdate As DateTimePicker
  Friend WithEvents TxtChkTo As TextBox
  Friend WithEvents LblChkTo As Label
  Friend WithEvents TxtChkFrom As TextBox
  Friend WithEvents LblChkFrom As Label
  Friend WithEvents lblpdate As Label
  Friend WithEvents lblcdate As Label
  Friend WithEvents Rbvoid As System.Windows.Forms.RadioButton
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.LnkBank = New System.Windows.Forms.LinkLabel()
    Me.TxtBank = New System.Windows.Forms.TextBox()
    Me.Rbvoid = New System.Windows.Forms.RadioButton()
    Me.rblist = New System.Windows.Forms.RadioButton()
    Me.DtPckpdate = New System.Windows.Forms.DateTimePicker()
    Me.DtPckcdate = New System.Windows.Forms.DateTimePicker()
    Me.TxtChkTo = New System.Windows.Forms.TextBox()
    Me.LblChkTo = New System.Windows.Forms.Label()
    Me.TxtChkFrom = New System.Windows.Forms.TextBox()
    Me.LblChkFrom = New System.Windows.Forms.Label()
    Me.lblpdate = New System.Windows.Forms.Label()
    Me.lblcdate = New System.Windows.Forms.Label()
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
    Me.LnkBank.Location = New System.Drawing.Point(35, 42)
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
    Me.TxtBank.Location = New System.Drawing.Point(101, 39)
    Me.TxtBank.MaxLength = 5
    Me.TxtBank.Name = "TxtBank"
    Me.TxtBank.Size = New System.Drawing.Size(48, 20)
    Me.TxtBank.TabIndex = 1
    '
    'Rbvoid
    '
    Me.Rbvoid.AutoSize = True
    Me.Rbvoid.Checked = True
    Me.Rbvoid.Location = New System.Drawing.Point(38, 78)
    Me.Rbvoid.Name = "Rbvoid"
    Me.Rbvoid.Size = New System.Drawing.Size(85, 17)
    Me.Rbvoid.TabIndex = 2
    Me.Rbvoid.TabStop = True
    Me.Rbvoid.Text = "Void Checks"
    Me.Rbvoid.UseVisualStyleBackColor = True
    '
    'rblist
    '
    Me.rblist.AutoSize = True
    Me.rblist.Location = New System.Drawing.Point(166, 78)
    Me.rblist.Name = "rblist"
    Me.rblist.Size = New System.Drawing.Size(116, 17)
    Me.rblist.TabIndex = 3
    Me.rblist.Text = "List Voided Checks"
    Me.rblist.UseVisualStyleBackColor = True
    '
    'DtPckpdate
    '
    Me.DtPckpdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckpdate.Location = New System.Drawing.Point(144, 135)
    Me.DtPckpdate.Name = "DtPckpdate"
    Me.DtPckpdate.Size = New System.Drawing.Size(88, 20)
    Me.DtPckpdate.TabIndex = 85
    '
    'DtPckcdate
    '
    Me.DtPckcdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckcdate.Location = New System.Drawing.Point(144, 109)
    Me.DtPckcdate.Name = "DtPckcdate"
    Me.DtPckcdate.Size = New System.Drawing.Size(88, 20)
    Me.DtPckcdate.TabIndex = 84
    '
    'TxtChkTo
    '
    Me.TxtChkTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtChkTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtChkTo.Location = New System.Drawing.Point(335, 169)
    Me.TxtChkTo.MaxLength = 7
    Me.TxtChkTo.Name = "TxtChkTo"
    Me.TxtChkTo.Size = New System.Drawing.Size(60, 20)
    Me.TxtChkTo.TabIndex = 87
    '
    'LblChkTo
    '
    Me.LblChkTo.AutoSize = True
    Me.LblChkTo.Location = New System.Drawing.Point(227, 173)
    Me.LblChkTo.Name = "LblChkTo"
    Me.LblChkTo.Size = New System.Drawing.Size(102, 13)
    Me.LblChkTo.TabIndex = 91
    Me.LblChkTo.Text = "To Check (Optional)"
    '
    'TxtChkFrom
    '
    Me.TxtChkFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtChkFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtChkFrom.Location = New System.Drawing.Point(144, 169)
    Me.TxtChkFrom.MaxLength = 7
    Me.TxtChkFrom.Name = "TxtChkFrom"
    Me.TxtChkFrom.Size = New System.Drawing.Size(57, 20)
    Me.TxtChkFrom.TabIndex = 86
    '
    'LblChkFrom
    '
    Me.LblChkFrom.AutoSize = True
    Me.LblChkFrom.Location = New System.Drawing.Point(35, 173)
    Me.LblChkFrom.Name = "LblChkFrom"
    Me.LblChkFrom.Size = New System.Drawing.Size(64, 13)
    Me.LblChkFrom.TabIndex = 90
    Me.LblChkFrom.Text = "From Check"
    '
    'lblpdate
    '
    Me.lblpdate.Location = New System.Drawing.Point(35, 139)
    Me.lblpdate.Name = "lblpdate"
    Me.lblpdate.Size = New System.Drawing.Size(103, 16)
    Me.lblpdate.TabIndex = 89
    Me.lblpdate.Text = "Posting Date"
    '
    'lblcdate
    '
    Me.lblcdate.Location = New System.Drawing.Point(35, 116)
    Me.lblcdate.Name = "lblcdate"
    Me.lblcdate.Size = New System.Drawing.Size(103, 16)
    Me.lblcdate.TabIndex = 88
    Me.lblcdate.Text = "From Date"
    '
    'FrmAP502B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(424, 216)
    Me.ControlBox = False
    Me.Controls.Add(Me.DtPckpdate)
    Me.Controls.Add(Me.DtPckcdate)
    Me.Controls.Add(Me.TxtChkTo)
    Me.Controls.Add(Me.LblChkTo)
    Me.Controls.Add(Me.TxtChkFrom)
    Me.Controls.Add(Me.LblChkFrom)
    Me.Controls.Add(Me.lblpdate)
    Me.Controls.Add(Me.lblcdate)
    Me.Controls.Add(Me.rblist)
    Me.Controls.Add(Me.Rbvoid)
    Me.Controls.Add(Me.TxtBank)
    Me.Controls.Add(Me.LnkBank)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmAP502B"
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
    If rblist.Checked = True Then
      PrtReport()
    End If

    If Rbvoid.Checked = True Then
      passpostdate = Me.DtPckpdate.Value
      DoVoid()
      TxtChkFrom.Text = ""
      TxtChkTo.Text = ""
    End If
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub FrmAP502B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmAP502.SbpPgmID.Text = "AP502B"
    MyFrmAP502.SbpEnvironment.Text = myDBConnect.PgmDB
    DtPckcdate.Value = Date.Today
    DtPckpdate.Value = Date.Today
    setvoidscreen()
  End Sub
  Private Sub FrmAP502B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmAP502.SbpScreen.Text = "AP502B"
  End Sub
  Private Sub FrmAP502B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.Clear()

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "date"
          ErrProv.SetError(DtPckpdate, ErrorMsg(I))
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

    If rblist.Checked And DtPckcdate.Value > DtPckpdate.Value Then
      ErrorField(I) = "date"
      ErrorMsg(I) = "Invalid Date Range"
      I = I + 1
    End If

    If Rbvoid.Checked Then
      If MyUtils.CnvSng(TxtChkFrom.Text) = 0 Then
        ErrorField(I) = "check"
        ErrorMsg(I) = "Check Number is required"
        I = I + 1
      End If

      If MyUtils.CnvSng(TxtChkTo.Text) > 0 And MyUtils.CnvSng(TxtChkFrom.Text) > MyUtils.CnvSng(TxtChkTo.Text) Then
        ErrorField(I) = "check"
        ErrorMsg(I) = "Invalid Check Range"
        I = I + 1
      End If
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
  Private Sub FrmAP502B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
  Private Sub TxtChkFrom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtChkFrom.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtChkTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtChkTo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub rblist_Click(sender As Object, e As EventArgs) Handles rblist.Click
    setlistscreen()
  End Sub
  Private Sub Rbvoid_Click(sender As Object, e As EventArgs) Handles Rbvoid.Click
    setvoidscreen()
  End Sub
  Private Sub setvoidscreen()
    lblcdate.Visible = False
    DtPckcdate.Visible = False
    lblpdate.Text = "Posting Date"
    LblChkFrom.Text = "From Check"
    LblChkTo.Text = "To Check (Optional)"
    LblChkFrom.Visible = True
    LblChkTo.Visible = True
    TxtChkFrom.Visible = True
    TxtChkTo.Visible = True
  End Sub
  Private Sub setlistscreen()
    lblcdate.Visible = True
    DtPckcdate.Visible = True
    lblpdate.Text = "To Date"
    LblChkFrom.Visible = False
    LblChkTo.Visible = False
    TxtChkFrom.Visible = False
    TxtChkTo.Visible = False
  End Sub

  Private Sub Rbvoid_CheckedChanged(sender As Object, e As EventArgs) Handles Rbvoid.CheckedChanged

  End Sub
End Class
