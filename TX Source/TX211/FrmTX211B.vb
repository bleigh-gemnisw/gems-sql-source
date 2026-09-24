Public Class FrmTX211B
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
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
Friend WithEvents TxtType As System.Windows.Forms.TextBox
Friend WithEvents ChkHeaders As System.Windows.Forms.CheckBox
Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents ChkBreakout As System.Windows.Forms.CheckBox
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents LnkType As System.Windows.Forms.LinkLabel
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents TxtFromCCNo As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents TxtToCCNo As System.Windows.Forms.TextBox
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents TxtToReason As System.Windows.Forms.TextBox
Friend WithEvents TxtFromReason As System.Windows.Forms.TextBox
Friend WithEvents LnkToReason As System.Windows.Forms.LinkLabel
Friend WithEvents LnkFrmReason As System.Windows.Forms.LinkLabel
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTX211B))
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.TxtType = New System.Windows.Forms.TextBox
Me.ChkHeaders = New System.Windows.Forms.CheckBox
Me.GroupBox3 = New System.Windows.Forms.GroupBox
Me.DtPckTo = New System.Windows.Forms.DateTimePicker
Me.Label2 = New System.Windows.Forms.Label
Me.DtPckFrom = New System.Windows.Forms.DateTimePicker
Me.Label1 = New System.Windows.Forms.Label
Me.ChkBreakout = New System.Windows.Forms.CheckBox
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.LnkType = New System.Windows.Forms.LinkLabel
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.TxtToCCNo = New System.Windows.Forms.TextBox
Me.TxtFromCCNo = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.Label4 = New System.Windows.Forms.Label
Me.GroupBox2 = New System.Windows.Forms.GroupBox
Me.TxtToReason = New System.Windows.Forms.TextBox
Me.TxtFromReason = New System.Windows.Forms.TextBox
Me.LnkToReason = New System.Windows.Forms.LinkLabel
Me.LnkFrmReason = New System.Windows.Forms.LinkLabel
Me.Label5 = New System.Windows.Forms.Label
Me.GroupBox3.SuspendLayout()
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox1.SuspendLayout()
Me.GroupBox2.SuspendLayout()
Me.SuspendLayout()
'
'ImageList1
'
Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
Me.ImageList1.Images.SetKeyName(0, "")
'
'TxtType
'
Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtType.Location = New System.Drawing.Point(116, 12)
Me.TxtType.MaxLength = 1
Me.TxtType.Name = "TxtType"
Me.TxtType.Size = New System.Drawing.Size(16, 20)
Me.TxtType.TabIndex = 0
'
'ChkHeaders
'
Me.ChkHeaders.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkHeaders.Checked = True
Me.ChkHeaders.CheckState = System.Windows.Forms.CheckState.Checked
Me.ChkHeaders.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.ChkHeaders.Location = New System.Drawing.Point(28, 36)
Me.ChkHeaders.Name = "ChkHeaders"
Me.ChkHeaders.Size = New System.Drawing.Size(104, 16)
Me.ChkHeaders.TabIndex = 1
Me.ChkHeaders.Text = "Print Headers?"
'
'GroupBox3
'
Me.GroupBox3.Controls.Add(Me.DtPckTo)
Me.GroupBox3.Controls.Add(Me.Label2)
Me.GroupBox3.Controls.Add(Me.DtPckFrom)
Me.GroupBox3.Controls.Add(Me.Label1)
Me.GroupBox3.ForeColor = System.Drawing.Color.Black
Me.GroupBox3.Location = New System.Drawing.Point(28, 58)
Me.GroupBox3.Name = "GroupBox3"
Me.GroupBox3.Size = New System.Drawing.Size(300, 52)
Me.GroupBox3.TabIndex = 3
Me.GroupBox3.TabStop = False
Me.GroupBox3.Text = "C/C Date Range (Optional)"
'
'DtPckTo
'
Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckTo.Location = New System.Drawing.Point(190, 20)
Me.DtPckTo.Name = "DtPckTo"
Me.DtPckTo.ShowCheckBox = True
Me.DtPckTo.Size = New System.Drawing.Size(104, 20)
Me.DtPckTo.TabIndex = 1
Me.DtPckTo.Value = New Date(2005, 10, 6, 9, 11, 0, 906)
'
'Label2
'
Me.Label2.ForeColor = System.Drawing.Color.Black
Me.Label2.Location = New System.Drawing.Point(156, 24)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(28, 16)
Me.Label2.TabIndex = 9
Me.Label2.Text = "To "
'
'DtPckFrom
'
Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckFrom.Location = New System.Drawing.Point(52, 20)
Me.DtPckFrom.Name = "DtPckFrom"
Me.DtPckFrom.ShowCheckBox = True
Me.DtPckFrom.Size = New System.Drawing.Size(98, 20)
Me.DtPckFrom.TabIndex = 0
Me.DtPckFrom.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
'
'Label1
'
Me.Label1.ForeColor = System.Drawing.Color.Black
Me.Label1.Location = New System.Drawing.Point(12, 20)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(36, 16)
Me.Label1.TabIndex = 7
Me.Label1.Text = "From"
'
'ChkBreakout
'
Me.ChkBreakout.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkBreakout.Location = New System.Drawing.Point(28, 226)
Me.ChkBreakout.Name = "ChkBreakout"
Me.ChkBreakout.Size = New System.Drawing.Size(116, 16)
Me.ChkBreakout.TabIndex = 5
Me.ChkBreakout.Text = "Interest Breakout?"
Me.ChkBreakout.Visible = False
'
'LnkType
'
Me.LnkType.Location = New System.Drawing.Point(32, 16)
Me.LnkType.Name = "LnkType"
Me.LnkType.Size = New System.Drawing.Size(80, 16)
Me.LnkType.TabIndex = 17
Me.LnkType.TabStop = True
Me.LnkType.Text = "Type to print"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.TxtToCCNo)
Me.GroupBox1.Controls.Add(Me.TxtFromCCNo)
Me.GroupBox1.Controls.Add(Me.Label3)
Me.GroupBox1.Controls.Add(Me.Label4)
Me.GroupBox1.ForeColor = System.Drawing.Color.Black
Me.GroupBox1.Location = New System.Drawing.Point(28, 116)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(200, 52)
Me.GroupBox1.TabIndex = 18
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "C/C Number Range (Optional)"
'
'TxtToCCNo
'
Me.TxtToCCNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtToCCNo.Location = New System.Drawing.Point(146, 19)
Me.TxtToCCNo.MaxLength = 5
Me.TxtToCCNo.Name = "TxtToCCNo"
Me.TxtToCCNo.Size = New System.Drawing.Size(38, 20)
Me.TxtToCCNo.TabIndex = 11
'
'TxtFromCCNo
'
Me.TxtFromCCNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtFromCCNo.Location = New System.Drawing.Point(54, 20)
Me.TxtFromCCNo.MaxLength = 5
Me.TxtFromCCNo.Name = "TxtFromCCNo"
Me.TxtFromCCNo.Size = New System.Drawing.Size(38, 20)
Me.TxtFromCCNo.TabIndex = 10
'
'Label3
'
Me.Label3.ForeColor = System.Drawing.Color.Black
Me.Label3.Location = New System.Drawing.Point(112, 24)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(28, 16)
Me.Label3.TabIndex = 9
Me.Label3.Text = "To "
'
'Label4
'
Me.Label4.ForeColor = System.Drawing.Color.Black
Me.Label4.Location = New System.Drawing.Point(12, 20)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(36, 16)
Me.Label4.TabIndex = 7
Me.Label4.Text = "From"
'
'GroupBox2
'
Me.GroupBox2.Controls.Add(Me.TxtToReason)
Me.GroupBox2.Controls.Add(Me.TxtFromReason)
Me.GroupBox2.Controls.Add(Me.LnkToReason)
Me.GroupBox2.Controls.Add(Me.LnkFrmReason)
Me.GroupBox2.ForeColor = System.Drawing.Color.Black
Me.GroupBox2.Location = New System.Drawing.Point(28, 174)
Me.GroupBox2.Name = "GroupBox2"
Me.GroupBox2.Size = New System.Drawing.Size(165, 46)
Me.GroupBox2.TabIndex = 19
Me.GroupBox2.TabStop = False
Me.GroupBox2.Text = "Reason Codes (Optional)"
'
'TxtToReason
'
Me.TxtToReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtToReason.Location = New System.Drawing.Point(130, 19)
Me.TxtToReason.MaxLength = 1
Me.TxtToReason.Name = "TxtToReason"
Me.TxtToReason.Size = New System.Drawing.Size(16, 20)
Me.TxtToReason.TabIndex = 26
'
'TxtFromReason
'
Me.TxtFromReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtFromReason.Location = New System.Drawing.Point(59, 18)
Me.TxtFromReason.MaxLength = 1
Me.TxtFromReason.Name = "TxtFromReason"
Me.TxtFromReason.Size = New System.Drawing.Size(16, 20)
Me.TxtFromReason.TabIndex = 25
'
'LnkToReason
'
Me.LnkToReason.Location = New System.Drawing.Point(104, 22)
Me.LnkToReason.Name = "LnkToReason"
Me.LnkToReason.Size = New System.Drawing.Size(20, 16)
Me.LnkToReason.TabIndex = 28
Me.LnkToReason.TabStop = True
Me.LnkToReason.Text = "To"
'
'LnkFrmReason
'
Me.LnkFrmReason.Location = New System.Drawing.Point(17, 22)
Me.LnkFrmReason.Name = "LnkFrmReason"
Me.LnkFrmReason.Size = New System.Drawing.Size(38, 16)
Me.LnkFrmReason.TabIndex = 27
Me.LnkFrmReason.TabStop = True
Me.LnkFrmReason.Text = "From"
'
'Label5
'
Me.Label5.AutoSize = True
Me.Label5.Location = New System.Drawing.Point(140, 16)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(52, 13)
Me.Label5.TabIndex = 20
Me.Label5.Text = "(Optional)"
'
'FrmTX211B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(352, 254)
Me.ControlBox = False
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.GroupBox2)
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.LnkType)
Me.Controls.Add(Me.ChkBreakout)
Me.Controls.Add(Me.GroupBox3)
Me.Controls.Add(Me.ChkHeaders)
Me.Controls.Add(Me.TxtType)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX211B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.GroupBox3.ResumeLayout(False)
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox1.ResumeLayout(False)
Me.GroupBox1.PerformLayout()
Me.GroupBox2.ResumeLayout(False)
Me.GroupBox2.PerformLayout()
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
Private Sub FrmTX211B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    DtPckFrom.Value = Date.Today
    DtPckFrom.Checked = False
    DtPckTo.Value = Date.Today
    DtPckTo.Checked = False
End Sub
Private Sub FrmTX211B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX211.SbpScreen.Text = "TX211B"
End Sub

Private Sub LnkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkType.LinkClicked
  MyFrmListTypes = New FrmListTypes
  MyFrmListTypes.MdiParent = Me.ParentForm
  MyFrmListTypes.WrkType = TxtType.Text
  MyFrmListTypes.Show()

End Sub
Private Sub LnkFrmReason_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFrmReason.LinkClicked
  MyFrmListCCReason = New FrmListCCReason
  MyFrmListCCReason.MdiParent = Me.ParentForm
  MyFrmListCCReason.WrkCode = TxtFromReason.Text
  MyFrmListCCReason.WrkField = "From"
  MyFrmListCCReason.Show()
End Sub
Private Sub LnkToReason_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkToReason.LinkClicked
  MyFrmListCCReason = New FrmListCCReason
  MyFrmListCCReason.MdiParent = Me.ParentForm
  MyFrmListCCReason.WrkCode = TxtToReason.Text
  MyFrmListCCReason.WrkField = "To"
  MyFrmListCCReason.Show()
End Sub
Private Sub FrmTX211B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtType, "")
    ErrProv.SetError(DtPckFrom, "")
    ErrProv.SetError(DtPckTo, "")
    ErrProv.SetError(TxtFromCCNo, "")
    ErrProv.SetError(TxtToCCNo, "")
    ErrProv.SetError(TxtFromReason, "")
    ErrProv.SetError(TxtToReason, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "type"
        ErrProv.SetError(TxtType, ErrorMsg(I))
      Case "date"
        ErrProv.SetError(DtPckFrom, ErrorMsg(I))
        ErrProv.SetError(DtPckTo, ErrorMsg(I))
      Case "ccno"
        ErrProv.SetError(TxtFromCCNo, ErrorMsg(I))
        ErrProv.SetError(TxtToCCNo, ErrorMsg(I))
      Case "reason"
        ErrProv.SetError(TxtFromReason, ErrorMsg(I))
        ErrProv.SetError(TxtToReason, ErrorMsg(I))
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

    If MyUtils.SetDBDate(DtPckFrom.Value) > MyUtils.SetDBDate(DtPckTo.Value) Then
      ErrorField(I) = "date"
      ErrorMsg(I) = "Invalid date Range"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtFromCCNo.Text) > MyUtils.CnvSng(TxtToCCNo.Text) Then
      ErrorField(I) = "ccno"
      ErrorMsg(I) = "Invalid C/C Number Range"
      I = I + 1
    End If

    If TxtFromReason.Text > TxtToReason.Text Then
      ErrorField(I) = "reason"
      ErrorMsg(I) = "Invalid Reason Range"
      I = I + 1
    End If
  End Sub
Private Sub TxtFromCCNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromCCNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtToCCNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToCCNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






