Public Class FrmTAP25B
Inherits System.Windows.Forms.Form
  Dim myTXDCCD As TXDCCD.MyData
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
  Friend WithEvents TxtPenCode As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtPenAmount As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtPenPct As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents RbNonFiler As RadioButton
  Friend WithEvents RbMissing As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ChkPending As CheckBox
    Friend WithEvents ChkActive As CheckBox

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ChkPost = New System.Windows.Forms.CheckBox()
    Me.TxtPenCode = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtPenAmount = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtPenPct = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.RbMissing = New System.Windows.Forms.RadioButton()
    Me.RbNonFiler = New System.Windows.Forms.RadioButton()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.ChkActive = New System.Windows.Forms.CheckBox()
    Me.ChkPending = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'ChkPost
    '
    Me.ChkPost.AutoSize = True
    Me.ChkPost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPost.Location = New System.Drawing.Point(28, 170)
    Me.ChkPost.Name = "ChkPost"
    Me.ChkPost.Size = New System.Drawing.Size(81, 17)
    Me.ChkPost.TabIndex = 4
    Me.ChkPost.Text = "Post to file?"
    '
    'TxtPenCode
    '
    Me.TxtPenCode.Location = New System.Drawing.Point(115, 109)
    Me.TxtPenCode.MaxLength = 3
    Me.TxtPenCode.Name = "TxtPenCode"
    Me.TxtPenCode.Size = New System.Drawing.Size(27, 20)
    Me.TxtPenCode.TabIndex = 1
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(28, 112)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(70, 13)
    Me.Label4.TabIndex = 58
    Me.Label4.Text = "Penalty Code"
    '
    'TxtPenAmount
    '
    Me.TxtPenAmount.Location = New System.Drawing.Point(115, 135)
    Me.TxtPenAmount.MaxLength = 9
    Me.TxtPenAmount.Name = "TxtPenAmount"
    Me.TxtPenAmount.Size = New System.Drawing.Size(63, 20)
    Me.TxtPenAmount.TabIndex = 2
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(28, 138)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(81, 13)
    Me.Label1.TabIndex = 60
    Me.Label1.Text = "Penalty Amount"
    '
    'TxtPenPct
    '
    Me.TxtPenPct.Location = New System.Drawing.Point(316, 136)
    Me.TxtPenPct.MaxLength = 4
    Me.TxtPenPct.Name = "TxtPenPct"
    Me.TxtPenPct.Size = New System.Drawing.Size(27, 20)
    Me.TxtPenPct.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(226, 139)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(82, 13)
    Me.Label2.TabIndex = 62
    Me.Label2.Text = "Penalty Percent"
    '
    'Label3
    '
    Me.Label3.ForeColor = System.Drawing.Color.Blue
    Me.Label3.Location = New System.Drawing.Point(184, 139)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(39, 15)
    Me.Label3.TabIndex = 63
    Me.Label3.Text = "- OR -"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(349, 140)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(35, 15)
    Me.Label5.TabIndex = 64
    Me.Label5.Text = "(99.9)"
    '
    'TxtYear
    '
    Me.TxtYear.Location = New System.Drawing.Point(118, 13)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtYear.TabIndex = 0
    '
    'Label13
    '
    Me.Label13.AutoSize = True
    Me.Label13.Location = New System.Drawing.Point(28, 16)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(80, 13)
    Me.Label13.TabIndex = 209
    Me.Label13.Text = "Grand List Year"
    '
    'RbMissing
    '
    Me.RbMissing.AutoSize = True
    Me.RbMissing.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbMissing.Checked = True
    Me.RbMissing.Location = New System.Drawing.Point(31, 84)
    Me.RbMissing.Name = "RbMissing"
    Me.RbMissing.Size = New System.Drawing.Size(87, 17)
    Me.RbMissing.TabIndex = 210
    Me.RbMissing.TabStop = True
    Me.RbMissing.Text = "Missing Filers"
    Me.RbMissing.UseVisualStyleBackColor = True
    '
    'RbNonFiler
    '
    Me.RbNonFiler.AutoSize = True
    Me.RbNonFiler.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbNonFiler.Location = New System.Drawing.Point(151, 84)
    Me.RbNonFiler.Name = "RbNonFiler"
    Me.RbNonFiler.Size = New System.Drawing.Size(72, 17)
    Me.RbNonFiler.TabIndex = 211
    Me.RbNonFiler.Text = "Non Filers"
    Me.RbNonFiler.UseVisualStyleBackColor = True
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.ChkPending)
    Me.GroupBox1.Controls.Add(Me.ChkActive)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(31, 39)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(167, 39)
    Me.GroupBox1.TabIndex = 213
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Select Status"
    '
    'ChkActive
    '
    Me.ChkActive.AutoSize = True
    Me.ChkActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkActive.Location = New System.Drawing.Point(8, 16)
    Me.ChkActive.Name = "ChkActive"
    Me.ChkActive.Size = New System.Drawing.Size(56, 17)
    Me.ChkActive.TabIndex = 213
    Me.ChkActive.Text = "Active"
    '
    'ChkPending
    '
    Me.ChkPending.AutoSize = True
    Me.ChkPending.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPending.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkPending.Location = New System.Drawing.Point(87, 16)
    Me.ChkPending.Name = "ChkPending"
    Me.ChkPending.Size = New System.Drawing.Size(65, 17)
    Me.ChkPending.TabIndex = 214
    Me.ChkPending.Text = "Pending"
    '
    'FrmTAP25B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(394, 209)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.RbNonFiler)
    Me.Controls.Add(Me.RbMissing)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtPenPct)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtPenAmount)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtPenCode)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.ChkPost)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTAP25B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
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
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.Clear()

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "code"
          ErrProv.SetError(TxtPenCode, ErrorMsg(I))
        Case "active"
          ErrProv.SetError(ChkActive, ErrorMsg(I))
          ErrProv.SetError(ChkPending, ErrorMsg(I))
        Case "amount"
          ErrProv.SetError(TxtPenAmount, ErrorMsg(I))
        Case "pct"
          ErrProv.SetError(TxtPenPct, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim ds As DataSet = New DataSet
    Dim I As Integer
    Dim WrkYear As Integer
    Dim WrkCode As Integer
    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next
    WrkYear = MyUtils.CnvSng(TxtYear.Text)
    WrkCode = MyUtils.CnvSng(TxtPenCode.Text)

    myTXDCCD.GetOneRecordP(WrkYear, WrkCode, "")
    If myTXDCCD.RecordNotFound Then
      ErrorField(I) = "code"
      ErrorMsg(I) = "Penalty Code invalid"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtPenCode.Text) = 0 Then
      ErrorField(I) = "code"
      ErrorMsg(I) = "Penalty Code is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtPenAmount.Text) = 0 And MyUtils.CnvSng(TxtPenPct.Text) = 0 Then
      ErrorField(I) = "amount"
      ErrorMsg(I) = "Either Penalty Amount or percent is required"
      I = I + 1
      ErrorField(I) = "pct"
      ErrorMsg(I) = "Either Penalty Amount or percent is required"
      I = I + 1
    End If

    If Not ChkActive.Checked And Not ChkPending.Checked Then
      ErrorField(I) = "active"
      ErrorMsg(I) = "Active and/or Pending must be checked"
      I = I + 1
    End If
  End Sub
  Private Sub FrmTAP25B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP25.SbpScreen.Text = "TAP25B"
  End Sub
  Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtPenCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPenCode.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtPenAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPenAmount.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtPenPct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPenPct.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub

  Private Sub FrmTAP25B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXDCCD = New TXDCCD.MyData(myDBConnect)
  End Sub
  Private Sub FrmTAP25B_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    myTXDCCD.CloseFile()
    myTXDCCD = Nothing
  End Sub
End Class






