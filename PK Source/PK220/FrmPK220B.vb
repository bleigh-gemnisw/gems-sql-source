Public Class FrmPK220B
Inherits System.Windows.Forms.Form
Dim ds As DataSet = New DataSet

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
  Friend WithEvents TxtViol As System.Windows.Forms.TextBox
  Friend WithEvents LnkViol As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtOffcno As System.Windows.Forms.TextBox
  Friend WithEvents LnkOffcno As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtRegNo As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbSortOffcno As System.Windows.Forms.RadioButton
  Friend WithEvents RbSortStreet As System.Windows.Forms.RadioButton
  Friend WithEvents RbSortDate As System.Windows.Forms.RadioButton
  Friend WithEvents RbSortRegNo As System.Windows.Forms.RadioButton
  Friend WithEvents RbSortViolNo As System.Windows.Forms.RadioButton
  Friend WithEvents RbSortTickNo As System.Windows.Forms.RadioButton
  Friend WithEvents TxtStreet As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents RbStatusAll As System.Windows.Forms.RadioButton
  Friend WithEvents RbStatusActive As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents RbDateRec As System.Windows.Forms.RadioButton
  Friend WithEvents RbDateViol As System.Windows.Forms.RadioButton
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtOffcno = New System.Windows.Forms.TextBox()
    Me.LnkOffcno = New System.Windows.Forms.LinkLabel()
    Me.TxtViol = New System.Windows.Forms.TextBox()
    Me.LnkViol = New System.Windows.Forms.LinkLabel()
    Me.TxtRegNo = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbSortOffcno = New System.Windows.Forms.RadioButton()
    Me.RbSortStreet = New System.Windows.Forms.RadioButton()
    Me.RbSortDate = New System.Windows.Forms.RadioButton()
    Me.RbSortRegNo = New System.Windows.Forms.RadioButton()
    Me.RbSortViolNo = New System.Windows.Forms.RadioButton()
    Me.RbSortTickNo = New System.Windows.Forms.RadioButton()
    Me.TxtStreet = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbStatusAll = New System.Windows.Forms.RadioButton()
    Me.RbStatusActive = New System.Windows.Forms.RadioButton()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.RbDateRec = New System.Windows.Forms.RadioButton()
    Me.RbDateViol = New System.Windows.Forms.RadioButton()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtOffcno
    '
    Me.TxtOffcno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOffcno.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOffcno.Location = New System.Drawing.Point(112, 78)
    Me.TxtOffcno.MaxLength = 4
    Me.TxtOffcno.Name = "TxtOffcno"
    Me.TxtOffcno.Size = New System.Drawing.Size(42, 22)
    Me.TxtOffcno.TabIndex = 3
    '
    'LnkOffcno
    '
    Me.LnkOffcno.AutoSize = True
    Me.LnkOffcno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkOffcno.ForeColor = System.Drawing.Color.Maroon
    Me.LnkOffcno.Location = New System.Drawing.Point(26, 82)
    Me.LnkOffcno.Name = "LnkOffcno"
    Me.LnkOffcno.Size = New System.Drawing.Size(78, 13)
    Me.LnkOffcno.TabIndex = 2
    Me.LnkOffcno.TabStop = True
    Me.LnkOffcno.Text = "Officer Number"
    '
    'TxtViol
    '
    Me.TxtViol.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtViol.Location = New System.Drawing.Point(112, 103)
    Me.TxtViol.MaxLength = 2
    Me.TxtViol.Name = "TxtViol"
    Me.TxtViol.Size = New System.Drawing.Size(24, 22)
    Me.TxtViol.TabIndex = 5
    Me.TxtViol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LnkViol
    '
    Me.LnkViol.AutoSize = True
    Me.LnkViol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkViol.ForeColor = System.Drawing.Color.Maroon
    Me.LnkViol.Location = New System.Drawing.Point(26, 107)
    Me.LnkViol.Name = "LnkViol"
    Me.LnkViol.Size = New System.Drawing.Size(47, 13)
    Me.LnkViol.TabIndex = 4
    Me.LnkViol.TabStop = True
    Me.LnkViol.Text = "Violation"
    '
    'TxtRegNo
    '
    Me.TxtRegNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRegNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRegNo.Location = New System.Drawing.Point(112, 131)
    Me.TxtRegNo.MaxLength = 12
    Me.TxtRegNo.Name = "TxtRegNo"
    Me.TxtRegNo.Size = New System.Drawing.Size(104, 22)
    Me.TxtRegNo.TabIndex = 6
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(24, 135)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(80, 13)
    Me.Label5.TabIndex = 303
    Me.Label5.Text = "Registration No"
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(112, 159)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(285, 22)
    Me.TxtName.TabIndex = 7
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(24, 163)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(35, 13)
    Me.Label4.TabIndex = 334
    Me.Label4.Text = "Name"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbSortOffcno)
    Me.GroupBox1.Controls.Add(Me.RbSortStreet)
    Me.GroupBox1.Controls.Add(Me.RbSortDate)
    Me.GroupBox1.Controls.Add(Me.RbSortRegNo)
    Me.GroupBox1.Controls.Add(Me.RbSortViolNo)
    Me.GroupBox1.Controls.Add(Me.RbSortTickNo)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(408, 12)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(143, 138)
    Me.GroupBox1.TabIndex = 335
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Sort Options"
    '
    'RbSortOffcno
    '
    Me.RbSortOffcno.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortOffcno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortOffcno.Location = New System.Drawing.Point(6, 36)
    Me.RbSortOffcno.Name = "RbSortOffcno"
    Me.RbSortOffcno.Size = New System.Drawing.Size(131, 20)
    Me.RbSortOffcno.TabIndex = 7
    Me.RbSortOffcno.Text = "Officer Number"
    '
    'RbSortStreet
    '
    Me.RbSortStreet.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortStreet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortStreet.Location = New System.Drawing.Point(6, 56)
    Me.RbSortStreet.Name = "RbSortStreet"
    Me.RbSortStreet.Size = New System.Drawing.Size(131, 20)
    Me.RbSortStreet.TabIndex = 2
    Me.RbSortStreet.Text = "Street"
    '
    'RbSortDate
    '
    Me.RbSortDate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortDate.Checked = True
    Me.RbSortDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortDate.Location = New System.Drawing.Point(6, 16)
    Me.RbSortDate.Name = "RbSortDate"
    Me.RbSortDate.Size = New System.Drawing.Size(131, 20)
    Me.RbSortDate.TabIndex = 0
    Me.RbSortDate.TabStop = True
    Me.RbSortDate.Text = "Date, Time"
    '
    'RbSortRegNo
    '
    Me.RbSortRegNo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortRegNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortRegNo.Location = New System.Drawing.Point(6, 116)
    Me.RbSortRegNo.Name = "RbSortRegNo"
    Me.RbSortRegNo.Size = New System.Drawing.Size(131, 20)
    Me.RbSortRegNo.TabIndex = 5
    Me.RbSortRegNo.Text = "Registration Number"
    '
    'RbSortViolNo
    '
    Me.RbSortViolNo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortViolNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortViolNo.Location = New System.Drawing.Point(6, 96)
    Me.RbSortViolNo.Name = "RbSortViolNo"
    Me.RbSortViolNo.Size = New System.Drawing.Size(131, 20)
    Me.RbSortViolNo.TabIndex = 4
    Me.RbSortViolNo.Text = "Violation 1 "
    '
    'RbSortTickNo
    '
    Me.RbSortTickNo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortTickNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortTickNo.Location = New System.Drawing.Point(6, 76)
    Me.RbSortTickNo.Name = "RbSortTickNo"
    Me.RbSortTickNo.Size = New System.Drawing.Size(131, 20)
    Me.RbSortTickNo.TabIndex = 3
    Me.RbSortTickNo.Text = "Ticket Number"
    '
    'TxtStreet
    '
    Me.TxtStreet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtStreet.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtStreet.Location = New System.Drawing.Point(112, 187)
    Me.TxtStreet.MaxLength = 30
    Me.TxtStreet.Name = "TxtStreet"
    Me.TxtStreet.Size = New System.Drawing.Size(276, 22)
    Me.TxtStreet.TabIndex = 8
    '
    'Label13
    '
    Me.Label13.AutoSize = True
    Me.Label13.Location = New System.Drawing.Point(24, 191)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(35, 13)
    Me.Label13.TabIndex = 353
    Me.Label13.Text = "Street"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbStatusAll)
    Me.GroupBox2.Controls.Add(Me.RbStatusActive)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(19, 215)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(146, 40)
    Me.GroupBox2.TabIndex = 354
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Record Selection"
    '
    'RbStatusAll
    '
    Me.RbStatusAll.AutoSize = True
    Me.RbStatusAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbStatusAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbStatusAll.Location = New System.Drawing.Point(93, 17)
    Me.RbStatusAll.Name = "RbStatusAll"
    Me.RbStatusAll.Size = New System.Drawing.Size(36, 17)
    Me.RbStatusAll.TabIndex = 1
    Me.RbStatusAll.Text = "All"
    '
    'RbStatusActive
    '
    Me.RbStatusActive.AutoSize = True
    Me.RbStatusActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbStatusActive.Checked = True
    Me.RbStatusActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbStatusActive.Location = New System.Drawing.Point(12, 16)
    Me.RbStatusActive.Name = "RbStatusActive"
    Me.RbStatusActive.Size = New System.Drawing.Size(55, 17)
    Me.RbStatusActive.TabIndex = 0
    Me.RbStatusActive.TabStop = True
    Me.RbStatusActive.Text = "Active"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.DtPckTo)
    Me.GroupBox3.Controls.Add(Me.Label2)
    Me.GroupBox3.Controls.Add(Me.DtPckFrom)
    Me.GroupBox3.Controls.Add(Me.Label1)
    Me.GroupBox3.Controls.Add(Me.RbDateRec)
    Me.GroupBox3.Controls.Add(Me.RbDateViol)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(15, 7)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(342, 61)
    Me.GroupBox3.TabIndex = 355
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Date Selection"
    '
    'RbDateRec
    '
    Me.RbDateRec.AutoSize = True
    Me.RbDateRec.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbDateRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbDateRec.Location = New System.Drawing.Point(97, 16)
    Me.RbDateRec.Name = "RbDateRec"
    Me.RbDateRec.Size = New System.Drawing.Size(62, 17)
    Me.RbDateRec.TabIndex = 1
    Me.RbDateRec.Text = "Receipt"
    '
    'RbDateViol
    '
    Me.RbDateViol.AutoSize = True
    Me.RbDateViol.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbDateViol.Checked = True
    Me.RbDateViol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbDateViol.Location = New System.Drawing.Point(12, 16)
    Me.RbDateViol.Name = "RbDateViol"
    Me.RbDateViol.Size = New System.Drawing.Size(65, 17)
    Me.RbDateViol.TabIndex = 0
    Me.RbDateViol.TabStop = True
    Me.RbDateViol.Text = "Violation"
    '
    'DtPckTo
    '
    Me.DtPckTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTo.Location = New System.Drawing.Point(237, 35)
    Me.DtPckTo.Name = "DtPckTo"
    Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
    Me.DtPckTo.TabIndex = 8
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(179, 39)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(52, 16)
    Me.Label2.TabIndex = 9
    Me.Label2.Text = "To Date"
    '
    'DtPckFrom
    '
    Me.DtPckFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFrom.Location = New System.Drawing.Point(71, 35)
    Me.DtPckFrom.Name = "DtPckFrom"
    Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
    Me.DtPckFrom.TabIndex = 6
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(11, 39)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(60, 16)
    Me.Label1.TabIndex = 7
    Me.Label1.Text = "From Date"
    '
    'FrmPK220B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(557, 264)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.TxtStreet)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.TxtName)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtRegNo)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtViol)
    Me.Controls.Add(Me.LnkViol)
    Me.Controls.Add(Me.TxtOffcno)
    Me.Controls.Add(Me.LnkOffcno)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmPK220B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmPK220B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmPK220.SbpScreen.Text = "PK220"
End Sub
Private Sub FrmPK220B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    'ErrProv.SetError(TxtType, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      'Case "type"
      '  ErrProv.SetError(TxtType, ErrorMsg(I))
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
  End Sub

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
Private Sub FrmPK220B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  DtPckFrom.Value = Date.Today
  DtPckTo.Value = Date.Today
End Sub
Private Sub LnkOffcno_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkOffcno.LinkClicked
  MyFrmListOfcr = New FrmListOfcr
  MyFrmListOfcr.MdiParent = Me.ParentForm
  MyFrmListOfcr.WrkCode = TxtOffcno.Text
  MyFrmListOfcr.Show()
End Sub
Private Sub LnkViol_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkViol.LinkClicked
  MyFrmListViol = New FrmListViol
  MyFrmListViol.MdiParent = Me.ParentForm
  MyFrmListViol.WrkCode = MyUtils.CnvSng(TxtViol.Text)
  MyFrmListViol.Show()
End Sub
Private Sub TxtViol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtViol.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class
