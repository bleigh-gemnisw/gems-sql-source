Public Class FrmAP312B
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

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
  Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtVndTo As System.Windows.Forms.TextBox
  Friend WithEvents TxtVndFrom As System.Windows.Forms.TextBox
  Friend WithEvents LnkVndFrom As System.Windows.Forms.LinkLabel
  Friend WithEvents LblVennmFrom As System.Windows.Forms.Label
  Friend WithEvents LnkVndTo As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtToFund As System.Windows.Forms.TextBox
  Friend WithEvents LnkToFund As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtFromFund As System.Windows.Forms.TextBox
  Friend WithEvents LnkFromFund As System.Windows.Forms.LinkLabel
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents RbSortSort As System.Windows.Forms.RadioButton
  Friend WithEvents RbSortNumber As System.Windows.Forms.RadioButton
  Friend WithEvents ChkAddr As System.Windows.Forms.CheckBox
  Friend WithEvents ChkVoid As CheckBox
  Friend WithEvents LblVennmTo As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtVndFrom = New System.Windows.Forms.TextBox()
    Me.TxtVndTo = New System.Windows.Forms.TextBox()
    Me.LnkVndFrom = New System.Windows.Forms.LinkLabel()
    Me.LblVennmFrom = New System.Windows.Forms.Label()
    Me.LnkVndTo = New System.Windows.Forms.LinkLabel()
    Me.LblVennmTo = New System.Windows.Forms.Label()
    Me.TxtToFund = New System.Windows.Forms.TextBox()
    Me.LnkToFund = New System.Windows.Forms.LinkLabel()
    Me.TxtFromFund = New System.Windows.Forms.TextBox()
    Me.LnkFromFund = New System.Windows.Forms.LinkLabel()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbSortSort = New System.Windows.Forms.RadioButton()
    Me.RbSortNumber = New System.Windows.Forms.RadioButton()
    Me.ChkAddr = New System.Windows.Forms.CheckBox()
    Me.ChkVoid = New System.Windows.Forms.CheckBox()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'DtPckTo
        '
        Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckTo.Location = New System.Drawing.Point(264, 84)
        Me.DtPckTo.Name = "DtPckTo"
        Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
        Me.DtPckTo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(212, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "To Date"
        '
        'DtPckFrom
        '
        Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckFrom.Location = New System.Drawing.Point(104, 84)
        Me.DtPckFrom.Name = "DtPckFrom"
        Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
        Me.DtPckFrom.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(44, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "From Date"
        '
        'TxtVndFrom
        '
        Me.TxtVndFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtVndFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVndFrom.Location = New System.Drawing.Point(131, 117)
        Me.TxtVndFrom.MaxLength = 7
        Me.TxtVndFrom.Name = "TxtVndFrom"
        Me.TxtVndFrom.Size = New System.Drawing.Size(57, 20)
        Me.TxtVndFrom.TabIndex = 7
        '
        'TxtVndTo
        '
        Me.TxtVndTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtVndTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVndTo.Location = New System.Drawing.Point(298, 117)
        Me.TxtVndTo.MaxLength = 7
        Me.TxtVndTo.Name = "TxtVndTo"
        Me.TxtVndTo.Size = New System.Drawing.Size(60, 20)
        Me.TxtVndTo.TabIndex = 9
        '
        'LnkVndFrom
        '
        Me.LnkVndFrom.AutoSize = True
        Me.LnkVndFrom.Location = New System.Drawing.Point(14, 124)
        Me.LnkVndFrom.Name = "LnkVndFrom"
        Me.LnkVndFrom.Size = New System.Drawing.Size(107, 13)
        Me.LnkVndFrom.TabIndex = 6
        Me.LnkVndFrom.TabStop = True
        Me.LnkVndFrom.Text = "From Vendor Number"
        '
        'LblVennmFrom
        '
        Me.LblVennmFrom.AutoSize = True
        Me.LblVennmFrom.Location = New System.Drawing.Point(14, 137)
        Me.LblVennmFrom.Name = "LblVennmFrom"
        Me.LblVennmFrom.Size = New System.Drawing.Size(84, 13)
        Me.LblVennmFrom.TabIndex = 396
        Me.LblVennmFrom.Text = "<Vendor Name>"
        Me.LblVennmFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblVennmFrom.UseMnemonic = False
        '
        'LnkVndTo
        '
        Me.LnkVndTo.AutoSize = True
        Me.LnkVndTo.Location = New System.Drawing.Point(218, 124)
        Me.LnkVndTo.Name = "LnkVndTo"
        Me.LnkVndTo.Size = New System.Drawing.Size(60, 13)
        Me.LnkVndTo.TabIndex = 8
        Me.LnkVndTo.TabStop = True
        Me.LnkVndTo.Text = "To Number"
        '
        'LblVennmTo
        '
        Me.LblVennmTo.AutoSize = True
        Me.LblVennmTo.Location = New System.Drawing.Point(218, 140)
        Me.LblVennmTo.Name = "LblVennmTo"
        Me.LblVennmTo.Size = New System.Drawing.Size(84, 13)
        Me.LblVennmTo.TabIndex = 398
        Me.LblVennmTo.Text = "<Vendor Name>"
        Me.LblVennmTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblVennmTo.UseMnemonic = False
        '
        'TxtToFund
        '
        Me.TxtToFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtToFund.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtToFund.Location = New System.Drawing.Point(342, 193)
        Me.TxtToFund.MaxLength = 3
        Me.TxtToFund.Name = "TxtToFund"
        Me.TxtToFund.Size = New System.Drawing.Size(26, 20)
        Me.TxtToFund.TabIndex = 5
        Me.TxtToFund.Visible = False
        '
        'LnkToFund
        '
        Me.LnkToFund.AutoSize = True
        Me.LnkToFund.Location = New System.Drawing.Point(321, 196)
        Me.LnkToFund.Name = "LnkToFund"
        Me.LnkToFund.Size = New System.Drawing.Size(47, 13)
        Me.LnkToFund.TabIndex = 4
        Me.LnkToFund.TabStop = True
        Me.LnkToFund.Text = "To Fund"
        Me.LnkToFund.Visible = False
        '
        'TxtFromFund
        '
        Me.TxtFromFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFromFund.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFromFund.Location = New System.Drawing.Point(287, 193)
        Me.TxtFromFund.MaxLength = 3
        Me.TxtFromFund.Name = "TxtFromFund"
        Me.TxtFromFund.Size = New System.Drawing.Size(28, 20)
        Me.TxtFromFund.TabIndex = 3
        Me.TxtFromFund.Visible = False
        '
        'LnkFromFund
        '
        Me.LnkFromFund.AutoSize = True
        Me.LnkFromFund.Location = New System.Drawing.Point(258, 199)
        Me.LnkFromFund.Name = "LnkFromFund"
        Me.LnkFromFund.Size = New System.Drawing.Size(57, 13)
        Me.LnkFromFund.TabIndex = 2
        Me.LnkFromFund.TabStop = True
        Me.LnkFromFund.Text = "From Fund"
        Me.LnkFromFund.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RbSortSort)
        Me.GroupBox2.Controls.Add(Me.RbSortNumber)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(250, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(127, 62)
        Me.GroupBox2.TabIndex = 399
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sort Options"
        '
        'RbSortSort
        '
        Me.RbSortSort.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RbSortSort.Checked = True
        Me.RbSortSort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbSortSort.Location = New System.Drawing.Point(6, 16)
        Me.RbSortSort.Name = "RbSortSort"
        Me.RbSortSort.Size = New System.Drawing.Size(115, 20)
        Me.RbSortSort.TabIndex = 0
        Me.RbSortSort.TabStop = True
        Me.RbSortSort.Text = "Vendor Sort"
        '
        'RbSortNumber
        '
        Me.RbSortNumber.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RbSortNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbSortNumber.Location = New System.Drawing.Point(6, 36)
        Me.RbSortNumber.Name = "RbSortNumber"
        Me.RbSortNumber.Size = New System.Drawing.Size(115, 20)
        Me.RbSortNumber.TabIndex = 1
        Me.RbSortNumber.Text = "Vendor Number"
        '
        'ChkAddr
        '
        Me.ChkAddr.AutoSize = True
        Me.ChkAddr.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkAddr.Location = New System.Drawing.Point(13, 166)
        Me.ChkAddr.Name = "ChkAddr"
        Me.ChkAddr.Size = New System.Drawing.Size(100, 17)
        Me.ChkAddr.TabIndex = 400
        Me.ChkAddr.Text = "Show Address?"
        Me.ChkAddr.UseVisualStyleBackColor = True
        '
        'ChkVoid
        '
        Me.ChkVoid.AutoSize = True
        Me.ChkVoid.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkVoid.Location = New System.Drawing.Point(17, 182)
        Me.ChkVoid.Name = "ChkVoid"
        Me.ChkVoid.Size = New System.Drawing.Size(96, 17)
        Me.ChkVoid.TabIndex = 401
        Me.ChkVoid.Text = "Include Voids?"
        Me.ChkVoid.UseVisualStyleBackColor = True
        '
        'FrmAP312B
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(429, 249)
        Me.ControlBox = False
        Me.Controls.Add(Me.ChkVoid)
        Me.Controls.Add(Me.ChkAddr)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TxtToFund)
        Me.Controls.Add(Me.LnkToFund)
        Me.Controls.Add(Me.TxtFromFund)
        Me.Controls.Add(Me.LnkFromFund)
        Me.Controls.Add(Me.LblVennmTo)
        Me.Controls.Add(Me.LnkVndTo)
        Me.Controls.Add(Me.LblVennmFrom)
        Me.Controls.Add(Me.LnkVndFrom)
        Me.Controls.Add(Me.TxtVndTo)
        Me.Controls.Add(Me.TxtVndFrom)
        Me.Controls.Add(Me.DtPckTo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DtPckFrom)
        Me.Controls.Add(Me.Label4)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAP312B"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
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
  Private Sub FrmAP312B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmAP312.SbpPgmID.Text = "AP312B"
    MyFrmAP312.SbpEnvironment.Text = myDBConnect.PgmDB
    DtPckFrom.Value = Date.Today
    DtPckTo.Value = Date.Today
    LblVennmFrom.Text = ""
    LblVennmTo.Text = ""
  End Sub
  Private Sub FrmAP312B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmAP312.SbpScreen.Text = "AP312B"
  End Sub
  Private Sub FrmAP312B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtVndTo, "")
    ErrProv.SetError(DtPckTo, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "date"
          ErrProv.SetError(DtPckTo, ErrorMsg(I))
        Case "fund"
          ErrProv.SetError(TxtToFund, ErrorMsg(I))
        Case "vendor"
          ErrProv.SetError(TxtVndTo, ErrorMsg(I))
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

    If DtPckFrom.Value > DtPckTo.Value Then
      ErrorField(I) = "date"
      ErrorMsg(I) = "Invalid Date Range"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtFromFund.Text) > 0 Then
      If MyUtils.CnvSng(TxtFromFund.Text) > Trim(TxtToFund.Text) Then
        ErrorField(I) = "fund"
        ErrorMsg(I) = "Invalid Fund Range"
        I = I + 1
      End If
    End If

    If TxtVndTo.Text <> "" Then
      If Trim(TxtVndFrom.Text) > Trim(TxtVndTo.Text) Then
        ErrorField(I) = "vendor"
        ErrorMsg(I) = "Invalid VendorRange"
        I = I + 1
      End If
    End If

  End Sub
  Private Sub FrmAP312B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If Not e.Alt Then Exit Sub

    If e.KeyCode = Keys.F12 Then
      MyUtils.PrtScreen(Form.ActiveForm)
    End If
  End Sub
  Private Sub LnkFromFund_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFromFund.LinkClicked
    MyFrmListFund = New FrmListFund
    MyFrmListFund.WrkField = "From"
    MyFrmListFund.WrkFund = MyUtils.CnvSng(TxtFromFund.Text)
    MyFrmListFund.MdiParent = Me.ParentForm
    MyFrmListFund.Show()
    Me.Hide()
  End Sub
  Private Sub LnkToFund_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkToFund.LinkClicked
    MyFrmListFund = New FrmListFund
    MyFrmListFund.WrkField = "To"
    MyFrmListFund.WrkFund = MyUtils.CnvSng(TxtToFund.Text)
    MyFrmListFund.MdiParent = Me.ParentForm
    MyFrmListFund.Show()
    Me.Hide()
  End Sub
  Private Sub TxtFromFund_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromFund.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtToFund_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToFund.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub LnkVndFrom_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkVndFrom.LinkClicked
    MyFrmListVendor = New FrmListVendor
    MyFrmListVendor.MdiParent = Me.ParentForm
    MyFrmListVendor.WrkField = "From"
    MyFrmListVendor.WrkCode = TxtVndFrom.Text
    MyFrmListVendor.Show()
    Me.Hide()
  End Sub

  Private Sub LnkVndTo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkVndTo.LinkClicked
    MyFrmListVendor = New FrmListVendor
    MyFrmListVendor.MdiParent = Me.ParentForm
    MyFrmListVendor.WrkField = "To"
    MyFrmListVendor.WrkCode = TxtVndTo.Text
    MyFrmListVendor.Show()
    Me.Hide()
  End Sub
End Class
