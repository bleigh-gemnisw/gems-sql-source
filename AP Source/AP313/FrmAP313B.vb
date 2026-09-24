Public Class FrmAP313B
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
Friend WithEvents LblVennmTo As System.Windows.Forms.Label
Friend WithEvents LblVennmFrom As System.Windows.Forms.Label
Friend WithEvents LnkVndTo As System.Windows.Forms.LinkLabel
Friend WithEvents LnkVndFrom As System.Windows.Forms.LinkLabel
Friend WithEvents TxtToFund As System.Windows.Forms.TextBox
Friend WithEvents LnkToFund As System.Windows.Forms.LinkLabel
Friend WithEvents TxtFromFund As System.Windows.Forms.TextBox
Friend WithEvents LnkFromFund As System.Windows.Forms.LinkLabel
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TxtChkTo As System.Windows.Forms.TextBox
Friend WithEvents TxtChkFrom As System.Windows.Forms.TextBox
  Friend WithEvents ChkVoid As CheckBox
  Friend WithEvents TxtVndFrom As System.Windows.Forms.TextBox
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
    Me.LnkVndTo = New System.Windows.Forms.LinkLabel()
    Me.LnkVndFrom = New System.Windows.Forms.LinkLabel()
    Me.LblVennmTo = New System.Windows.Forms.Label()
    Me.LblVennmFrom = New System.Windows.Forms.Label()
    Me.TxtToFund = New System.Windows.Forms.TextBox()
    Me.LnkToFund = New System.Windows.Forms.LinkLabel()
    Me.TxtFromFund = New System.Windows.Forms.TextBox()
    Me.LnkFromFund = New System.Windows.Forms.LinkLabel()
    Me.TxtChkFrom = New System.Windows.Forms.TextBox()
    Me.TxtChkTo = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.ChkVoid = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
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
    Me.Label4.Location = New System.Drawing.Point(12, 27)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(90, 16)
    Me.Label4.TabIndex = 68
    Me.Label4.Text = "From Date Paid "
    '
    'TxtVndFrom
    '
    Me.TxtVndFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVndFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVndFrom.Location = New System.Drawing.Point(129, 56)
    Me.TxtVndFrom.MaxLength = 5
    Me.TxtVndFrom.Name = "TxtVndFrom"
    Me.TxtVndFrom.Size = New System.Drawing.Size(57, 20)
    Me.TxtVndFrom.TabIndex = 3
    '
    'TxtVndTo
    '
    Me.TxtVndTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVndTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVndTo.Location = New System.Drawing.Point(279, 56)
    Me.TxtVndTo.MaxLength = 5
    Me.TxtVndTo.Name = "TxtVndTo"
    Me.TxtVndTo.Size = New System.Drawing.Size(60, 20)
    Me.TxtVndTo.TabIndex = 5
    '
    'LnkVndTo
    '
    Me.LnkVndTo.AutoSize = True
    Me.LnkVndTo.Location = New System.Drawing.Point(210, 59)
    Me.LnkVndTo.Name = "LnkVndTo"
    Me.LnkVndTo.Size = New System.Drawing.Size(60, 13)
    Me.LnkVndTo.TabIndex = 4
    Me.LnkVndTo.TabStop = True
    Me.LnkVndTo.Text = "To Number"
    '
    'LnkVndFrom
    '
    Me.LnkVndFrom.AutoSize = True
    Me.LnkVndFrom.Location = New System.Drawing.Point(12, 59)
    Me.LnkVndFrom.Name = "LnkVndFrom"
    Me.LnkVndFrom.Size = New System.Drawing.Size(107, 13)
    Me.LnkVndFrom.TabIndex = 2
    Me.LnkVndFrom.TabStop = True
    Me.LnkVndFrom.Text = "From Vendor Number"
    '
    'LblVennmTo
    '
    Me.LblVennmTo.AutoSize = True
    Me.LblVennmTo.Location = New System.Drawing.Point(210, 81)
    Me.LblVennmTo.Name = "LblVennmTo"
    Me.LblVennmTo.Size = New System.Drawing.Size(84, 13)
    Me.LblVennmTo.TabIndex = 401
    Me.LblVennmTo.Text = "<Vendor Name>"
    Me.LblVennmTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.LblVennmTo.UseMnemonic = False
    '
    'LblVennmFrom
    '
    Me.LblVennmFrom.AutoSize = True
    Me.LblVennmFrom.Location = New System.Drawing.Point(12, 81)
    Me.LblVennmFrom.Name = "LblVennmFrom"
    Me.LblVennmFrom.Size = New System.Drawing.Size(84, 13)
    Me.LblVennmFrom.TabIndex = 400
    Me.LblVennmFrom.Text = "<Vendor Name>"
    Me.LblVennmFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.LblVennmFrom.UseMnemonic = False
    '
    'TxtToFund
    '
    Me.TxtToFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtToFund.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtToFund.Location = New System.Drawing.Point(413, 141)
    Me.TxtToFund.MaxLength = 3
    Me.TxtToFund.Name = "TxtToFund"
    Me.TxtToFund.Size = New System.Drawing.Size(26, 20)
    Me.TxtToFund.TabIndex = 11
    Me.TxtToFund.Visible = False
    '
    'LnkToFund
    '
    Me.LnkToFund.AutoSize = True
    Me.LnkToFund.Location = New System.Drawing.Point(382, 145)
    Me.LnkToFund.Name = "LnkToFund"
    Me.LnkToFund.Size = New System.Drawing.Size(47, 13)
    Me.LnkToFund.TabIndex = 10
    Me.LnkToFund.TabStop = True
    Me.LnkToFund.Text = "To Fund"
    Me.LnkToFund.Visible = False
    '
    'TxtFromFund
    '
    Me.TxtFromFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFromFund.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFromFund.Location = New System.Drawing.Point(348, 141)
    Me.TxtFromFund.MaxLength = 3
    Me.TxtFromFund.Name = "TxtFromFund"
    Me.TxtFromFund.Size = New System.Drawing.Size(28, 20)
    Me.TxtFromFund.TabIndex = 9
    Me.TxtFromFund.Visible = False
    '
    'LnkFromFund
    '
    Me.LnkFromFund.AutoSize = True
    Me.LnkFromFund.Location = New System.Drawing.Point(319, 141)
    Me.LnkFromFund.Name = "LnkFromFund"
    Me.LnkFromFund.Size = New System.Drawing.Size(57, 13)
    Me.LnkFromFund.TabIndex = 8
    Me.LnkFromFund.TabStop = True
    Me.LnkFromFund.Text = "From Fund"
    Me.LnkFromFund.Visible = False
    '
    'TxtChkFrom
    '
    Me.TxtChkFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtChkFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtChkFrom.Location = New System.Drawing.Point(129, 100)
    Me.TxtChkFrom.MaxLength = 7
    Me.TxtChkFrom.Name = "TxtChkFrom"
    Me.TxtChkFrom.Size = New System.Drawing.Size(57, 20)
    Me.TxtChkFrom.TabIndex = 6
    '
    'TxtChkTo
    '
    Me.TxtChkTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtChkTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtChkTo.Location = New System.Drawing.Point(279, 100)
    Me.TxtChkTo.MaxLength = 7
    Me.TxtChkTo.Name = "TxtChkTo"
    Me.TxtChkTo.Size = New System.Drawing.Size(60, 20)
    Me.TxtChkTo.TabIndex = 7
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 103)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(104, 13)
    Me.Label1.TabIndex = 404
    Me.Label1.Text = "From Check Number"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.Label1.UseMnemonic = False
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(210, 103)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(60, 13)
    Me.Label3.TabIndex = 405
    Me.Label3.Text = "To Number"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.Label3.UseMnemonic = False
    '
    'ChkVoid
    '
    Me.ChkVoid.AutoSize = True
    Me.ChkVoid.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkVoid.Location = New System.Drawing.Point(12, 128)
    Me.ChkVoid.Name = "ChkVoid"
    Me.ChkVoid.Size = New System.Drawing.Size(96, 17)
    Me.ChkVoid.TabIndex = 406
    Me.ChkVoid.Text = "Include Voids?"
    Me.ChkVoid.UseVisualStyleBackColor = True
    '
    'FrmAP313B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(444, 157)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkVoid)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtChkTo)
    Me.Controls.Add(Me.TxtChkFrom)
    Me.Controls.Add(Me.TxtToFund)
    Me.Controls.Add(Me.LnkToFund)
    Me.Controls.Add(Me.TxtFromFund)
    Me.Controls.Add(Me.LnkFromFund)
    Me.Controls.Add(Me.LblVennmTo)
    Me.Controls.Add(Me.LblVennmFrom)
    Me.Controls.Add(Me.LnkVndTo)
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
    Me.Name = "FrmAP313B"
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
Private Sub FrmAP313B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  MyFrmAP313.SbpPgmID.Text = "AP313B"
  MyFrmAP313.SbpEnvironment.Text = myDBConnect.PgmDB
  DtPckFrom.Value = Date.Today
  DtPckTo.Value = Date.Today
  LblVennmFrom.Text = ""
  LblVennmTo.Text = ""
End Sub
Private Sub FrmAP313B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
 MyFrmAP313.SbpScreen.Text = "AP313B"
End Sub
Private Sub FrmAP313B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
 Me.Refresh()
End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.Clear()

  For I = 0 To ErrorField.GetUpperBound(0)
   Select Case ErrorField(I)
   Case "date"
    ErrProv.SetError(DtPckTo, ErrorMsg(I))
   Case "fund"
    ErrProv.SetError(TxtToFund, ErrorMsg(I))
   Case "vendor"
    ErrProv.SetError(TxtVndTo, ErrorMsg(I))
   Case "check"
    ErrProv.SetError(TxtChkTo, ErrorMsg(I))
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
     ErrorMsg(I) = "Invalid Vendor Range"
     I = I + 1
    End If
  End If

  If MyUtils.CnvSng(TxtChkFrom.Text) > 0 Then
    If MyUtils.CnvSng(TxtChkFrom.Text) > Trim(TxtChkTo.Text) Then
     ErrorField(I) = "check"
     ErrorMsg(I) = "Invalid Check Range"
     I = I + 1
    End If
  End If
 End Sub
Private Sub FrmAP313B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
Private Sub TxtChkFund_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtChkFrom.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtChkTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtChkTo.KeyPress
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
