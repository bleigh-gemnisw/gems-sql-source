Public Class FrmAP307B
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
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
Friend WithEvents LnkBank As System.Windows.Forms.LinkLabel
Friend WithEvents TxtBank As System.Windows.Forms.TextBox
Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents TxtChkTo As System.Windows.Forms.TextBox
Friend WithEvents LblChkTo As System.Windows.Forms.Label
Friend WithEvents TxtChkFrom As System.Windows.Forms.TextBox
Friend WithEvents LblChkFrom As System.Windows.Forms.Label
Friend WithEvents LblChkNum As System.Windows.Forms.Label
Friend WithEvents LblFilePath As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.LnkBank = New System.Windows.Forms.LinkLabel()
    Me.TxtBank = New System.Windows.Forms.TextBox()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.LblChkFrom = New System.Windows.Forms.Label()
    Me.TxtChkFrom = New System.Windows.Forms.TextBox()
    Me.TxtChkTo = New System.Windows.Forms.TextBox()
    Me.LblChkTo = New System.Windows.Forms.Label()
    Me.LblChkNum = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LblFilePath)
    Me.GroupBox1.Controls.Add(Me.LnkFilePath)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(12, 120)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(408, 72)
    Me.GroupBox1.TabIndex = 6
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Optional: CSV File Details"
    '
    'LblFilePath
    '
    Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath.Location = New System.Drawing.Point(70, 24)
    Me.LblFilePath.Name = "LblFilePath"
    Me.LblFilePath.Size = New System.Drawing.Size(324, 36)
    Me.LblFilePath.TabIndex = 67
    '
    'LnkFilePath
    '
    Me.LnkFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePath.Location = New System.Drawing.Point(12, 24)
    Me.LnkFilePath.Name = "LnkFilePath"
    Me.LnkFilePath.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePath.TabIndex = 8
    Me.LnkFilePath.TabStop = True
    Me.LnkFilePath.Text = "File Path"
    '
    'LnkBank
    '
    Me.LnkBank.AutoSize = True
    Me.LnkBank.Location = New System.Drawing.Point(36, 86)
    Me.LnkBank.Name = "LnkBank"
    Me.LnkBank.Size = New System.Drawing.Size(60, 13)
    Me.LnkBank.TabIndex = 65
    Me.LnkBank.TabStop = True
    Me.LnkBank.Text = "Bank Code"
    '
    'TxtBank
    '
    Me.TxtBank.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBank.Location = New System.Drawing.Point(102, 83)
    Me.TxtBank.MaxLength = 5
    Me.TxtBank.Name = "TxtBank"
    Me.TxtBank.Size = New System.Drawing.Size(48, 20)
    Me.TxtBank.TabIndex = 4
    '
    'DtPckTo
    '
    Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTo.Location = New System.Drawing.Point(262, 23)
    Me.DtPckTo.Name = "DtPckTo"
    Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
    Me.DtPckTo.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(210, 27)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(52, 16)
    Me.Label2.TabIndex = 70
    Me.Label2.Text = "To Date"
    '
    'DtPckFrom
    '
    Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFrom.Location = New System.Drawing.Point(102, 23)
    Me.DtPckFrom.Name = "DtPckFrom"
    Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
    Me.DtPckFrom.TabIndex = 0
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(42, 27)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(60, 16)
    Me.Label4.TabIndex = 68
    Me.Label4.Text = "From Date"
    '
    'LblChkFrom
    '
    Me.LblChkFrom.Location = New System.Drawing.Point(36, 52)
    Me.LblChkFrom.Name = "LblChkFrom"
    Me.LblChkFrom.Size = New System.Drawing.Size(81, 15)
    Me.LblChkFrom.TabIndex = 77
    Me.LblChkFrom.Text = "From Number*"
    '
    'TxtChkFrom
    '
    Me.TxtChkFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtChkFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtChkFrom.Location = New System.Drawing.Point(123, 49)
    Me.TxtChkFrom.MaxLength = 7
    Me.TxtChkFrom.Name = "TxtChkFrom"
    Me.TxtChkFrom.Size = New System.Drawing.Size(57, 20)
    Me.TxtChkFrom.TabIndex = 2
    '
    'TxtChkTo
    '
    Me.TxtChkTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtChkTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtChkTo.Location = New System.Drawing.Point(262, 49)
    Me.TxtChkTo.MaxLength = 7
    Me.TxtChkTo.Name = "TxtChkTo"
    Me.TxtChkTo.Size = New System.Drawing.Size(60, 20)
    Me.TxtChkTo.TabIndex = 3
    '
    'LblChkTo
    '
    Me.LblChkTo.Location = New System.Drawing.Point(186, 52)
    Me.LblChkTo.Name = "LblChkTo"
    Me.LblChkTo.Size = New System.Drawing.Size(70, 15)
    Me.LblChkTo.TabIndex = 79
    Me.LblChkTo.Text = "To Number*"
    '
    'LblChkNum
    '
    Me.LblChkNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChkNum.Location = New System.Drawing.Point(9, 195)
    Me.LblChkNum.Name = "LblChkNum"
    Me.LblChkNum.Size = New System.Drawing.Size(439, 15)
    Me.LblChkNum.TabIndex = 81
    Me.LblChkNum.Text = "*=When Check Number range is entered then Date Range will be ignored"
    Me.LblChkNum.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'FrmAP307B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(444, 221)
    Me.ControlBox = False
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
    Me.Controls.Add(Me.GroupBox1)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmAP307B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
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
Private Sub FrmAP307B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  MyFrmAP307.SbpPgmID.Text = "AP307B"
  MyFrmAP307.SbpEnvironment.Text = myDBConnect.PgmDB
  DtPckFrom.Value = Date.Today
  DtPckTo.Value = Date.Today
End Sub
Private Sub FrmAP307B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
 MyFrmAP307.SbpScreen.Text = "AP307B"
End Sub
Private Sub FrmAP307B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
 Me.Refresh()
End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtBank, "")
  ErrProv.SetError(TxtChkTo, "")
  ErrProv.SetError(DtPckTo, "")

  For I = 0 To ErrorField.GetUpperBound(0)
   Select Case ErrorField(I)
   Case "date"
    ErrProv.SetError(DtPckTo, ErrorMsg(I))
   Case "check"
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
  End If
 End Sub
Private Sub FrmAP307B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
 If Not e.Alt Then Exit Sub

  If e.KeyCode = Keys.F12 Then
   MyUtils.PrtScreen(Form.ActiveForm)
  End If
End Sub
Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
 With SaveFileDialog1
  .ShowDialog()
  If .FileName <> String.Empty Then
   LblFilePath.Text = .FileName
  End If
 End With
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
End Class
