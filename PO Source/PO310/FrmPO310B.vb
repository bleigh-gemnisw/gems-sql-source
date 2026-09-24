Public Class FrmPO310B
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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbSortDept As System.Windows.Forms.RadioButton
  Friend WithEvents RbSortAcct As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents RbStatusClosed As System.Windows.Forms.RadioButton
  Friend WithEvents RbStatusOpen As System.Windows.Forms.RadioButton
  Friend WithEvents RbStatusAny As System.Windows.Forms.RadioButton
  Friend WithEvents ChkDetail As System.Windows.Forms.CheckBox
  Friend WithEvents TxtFundTo As System.Windows.Forms.TextBox
  Friend WithEvents LnkFundTo As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtFundFrom As System.Windows.Forms.TextBox
  Friend WithEvents LnkFundFrom As System.Windows.Forms.LinkLabel
  Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
  Friend WithEvents TxtDeptTo As System.Windows.Forms.TextBox
  Friend WithEvents TxtDeptFrom As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbSortDept = New System.Windows.Forms.RadioButton()
    Me.RbSortAcct = New System.Windows.Forms.RadioButton()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbStatusAny = New System.Windows.Forms.RadioButton()
    Me.RbStatusClosed = New System.Windows.Forms.RadioButton()
    Me.RbStatusOpen = New System.Windows.Forms.RadioButton()
    Me.ChkDetail = New System.Windows.Forms.CheckBox()
    Me.TxtFundTo = New System.Windows.Forms.TextBox()
    Me.LnkFundTo = New System.Windows.Forms.LinkLabel()
    Me.TxtFundFrom = New System.Windows.Forms.TextBox()
    Me.LnkFundFrom = New System.Windows.Forms.LinkLabel()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.TxtDeptTo = New System.Windows.Forms.TextBox()
    Me.TxtDeptFrom = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(19, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(60, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "From Date"
    '
    'DtPckFrom
    '
    Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFrom.Location = New System.Drawing.Point(79, 12)
    Me.DtPckFrom.Name = "DtPckFrom"
    Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
    Me.DtPckFrom.TabIndex = 0
    '
    'DtPckTo
    '
    Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTo.Location = New System.Drawing.Point(239, 12)
    Me.DtPckTo.Name = "DtPckTo"
    Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
    Me.DtPckTo.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(187, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(52, 16)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "To Date"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbSortDept)
    Me.GroupBox1.Controls.Add(Me.RbSortAcct)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(437, 12)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(108, 63)
    Me.GroupBox1.TabIndex = 9
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Sort Options"
    '
    'RbSortDept
    '
    Me.RbSortDept.AutoSize = True
    Me.RbSortDept.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortDept.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortDept.Location = New System.Drawing.Point(6, 36)
    Me.RbSortDept.Name = "RbSortDept"
    Me.RbSortDept.Size = New System.Drawing.Size(80, 17)
    Me.RbSortDept.TabIndex = 7
    Me.RbSortDept.Text = "Department"
    '
    'RbSortAcct
    '
    Me.RbSortAcct.AutoSize = True
    Me.RbSortAcct.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortAcct.Checked = True
    Me.RbSortAcct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortAcct.Location = New System.Drawing.Point(6, 16)
    Me.RbSortAcct.Name = "RbSortAcct"
    Me.RbSortAcct.Size = New System.Drawing.Size(65, 17)
    Me.RbSortAcct.TabIndex = 0
    Me.RbSortAcct.TabStop = True
    Me.RbSortAcct.Text = "Account"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbStatusAny)
    Me.GroupBox2.Controls.Add(Me.RbStatusClosed)
    Me.GroupBox2.Controls.Add(Me.RbStatusOpen)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(22, 43)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(217, 38)
    Me.GroupBox2.TabIndex = 358
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Status"
    '
    'RbStatusAny
    '
    Me.RbStatusAny.AutoSize = True
    Me.RbStatusAny.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbStatusAny.Checked = True
    Me.RbStatusAny.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbStatusAny.Location = New System.Drawing.Point(6, 15)
    Me.RbStatusAny.Name = "RbStatusAny"
    Me.RbStatusAny.Size = New System.Drawing.Size(43, 17)
    Me.RbStatusAny.TabIndex = 0
    Me.RbStatusAny.TabStop = True
    Me.RbStatusAny.Text = "Any"
    Me.RbStatusAny.UseVisualStyleBackColor = True
    '
    'RbStatusClosed
    '
    Me.RbStatusClosed.AutoSize = True
    Me.RbStatusClosed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbStatusClosed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbStatusClosed.Location = New System.Drawing.Point(154, 15)
    Me.RbStatusClosed.Name = "RbStatusClosed"
    Me.RbStatusClosed.Size = New System.Drawing.Size(57, 17)
    Me.RbStatusClosed.TabIndex = 2
    Me.RbStatusClosed.Text = "Closed"
    Me.RbStatusClosed.UseVisualStyleBackColor = True
    '
    'RbStatusOpen
    '
    Me.RbStatusOpen.AutoSize = True
    Me.RbStatusOpen.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbStatusOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbStatusOpen.Location = New System.Drawing.Point(77, 15)
    Me.RbStatusOpen.Name = "RbStatusOpen"
    Me.RbStatusOpen.Size = New System.Drawing.Size(51, 17)
    Me.RbStatusOpen.TabIndex = 1
    Me.RbStatusOpen.Text = "Open"
    Me.RbStatusOpen.UseVisualStyleBackColor = True
    '
    'ChkDetail
    '
    Me.ChkDetail.AutoSize = True
    Me.ChkDetail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkDetail.Location = New System.Drawing.Point(15, 161)
    Me.ChkDetail.Name = "ChkDetail"
    Me.ChkDetail.Size = New System.Drawing.Size(89, 17)
    Me.ChkDetail.TabIndex = 8
    Me.ChkDetail.Text = "Show Detail?"
    Me.ChkDetail.UseVisualStyleBackColor = True
    '
    'TxtFundTo
    '
    Me.TxtFundTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFundTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFundTo.Location = New System.Drawing.Point(186, 96)
    Me.TxtFundTo.MaxLength = 3
    Me.TxtFundTo.Name = "TxtFundTo"
    Me.TxtFundTo.Size = New System.Drawing.Size(26, 20)
    Me.TxtFundTo.TabIndex = 5
    '
    'LnkFundTo
    '
    Me.LnkFundTo.AutoSize = True
    Me.LnkFundTo.Location = New System.Drawing.Point(133, 99)
    Me.LnkFundTo.Name = "LnkFundTo"
    Me.LnkFundTo.Size = New System.Drawing.Size(47, 13)
    Me.LnkFundTo.TabIndex = 4
    Me.LnkFundTo.TabStop = True
    Me.LnkFundTo.Text = "To Fund"
    '
    'TxtFundFrom
    '
    Me.TxtFundFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFundFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFundFrom.Location = New System.Drawing.Point(88, 96)
    Me.TxtFundFrom.MaxLength = 3
    Me.TxtFundFrom.Name = "TxtFundFrom"
    Me.TxtFundFrom.Size = New System.Drawing.Size(28, 20)
    Me.TxtFundFrom.TabIndex = 3
    '
    'LnkFundFrom
    '
    Me.LnkFundFrom.AutoSize = True
    Me.LnkFundFrom.Location = New System.Drawing.Point(22, 99)
    Me.LnkFundFrom.Name = "LnkFundFrom"
    Me.LnkFundFrom.Size = New System.Drawing.Size(57, 13)
    Me.LnkFundFrom.TabIndex = 2
    Me.LnkFundFrom.TabStop = True
    Me.LnkFundFrom.Text = "From Fund"
    '
    'TxtDeptTo
    '
    Me.TxtDeptTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDeptTo.Location = New System.Drawing.Point(148, 121)
    Me.TxtDeptTo.MaxLength = 4
    Me.TxtDeptTo.Name = "TxtDeptTo"
    Me.TxtDeptTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtDeptTo.TabIndex = 7
    '
    'TxtDeptFrom
    '
    Me.TxtDeptFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDeptFrom.Location = New System.Drawing.Point(86, 122)
    Me.TxtDeptFrom.MaxLength = 4
    Me.TxtDeptFrom.Name = "TxtDeptFrom"
    Me.TxtDeptFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtDeptFrom.TabIndex = 6
    '
    'Label6
    '
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(126, 125)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(16, 16)
    Me.Label6.TabIndex = 367
    Me.Label6.Text = "to"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(19, 125)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(62, 13)
    Me.Label7.TabIndex = 366
    Me.Label7.Text = "Department"
    '
    'FrmPO310B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(557, 189)
    Me.ControlBox = False
    Me.Controls.Add(Me.TxtDeptTo)
    Me.Controls.Add(Me.TxtDeptFrom)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TxtFundTo)
    Me.Controls.Add(Me.LnkFundTo)
    Me.Controls.Add(Me.TxtFundFrom)
    Me.Controls.Add(Me.LnkFundFrom)
    Me.Controls.Add(Me.ChkDetail)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.DtPckTo)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.DtPckFrom)
    Me.Controls.Add(Me.Label1)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmPO310B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmPO310B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmPO310.SbpScreen.Text = "PO310"
End Sub
Private Sub FrmPO310B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
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
Private Sub FrmPO310B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  DtPckFrom.Value = Date.Today
  DtPckTo.Value = Date.Today
End Sub
Private Sub TxtViol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub LnkFundFrom_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFundFrom.LinkClicked
 MyFrmListFund = New FrmListFund
 MyFrmListFund.WrkField = "From"
 MyFrmListFund.WrkFund = MyUtils.CnvSng(TxtFundFrom.Text)
 MyFrmListFund.MdiParent = Me.ParentForm
 MyFrmListFund.Show()
End Sub
Private Sub LnkFundTo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFundTo.LinkClicked
 MyFrmListFund = New FrmListFund
 MyFrmListFund.WrkField = "To"
 MyFrmListFund.WrkFund = MyUtils.CnvSng(TxtFundTo.Text)
 MyFrmListFund.MdiParent = Me.ParentForm
 MyFrmListFund.Show()
End Sub
Private Sub TxtFundFrom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFundFrom.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtFundTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFundTo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDeptFrom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDeptFrom.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDeptTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDeptTo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class
