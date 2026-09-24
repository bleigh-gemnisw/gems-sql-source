Public Class FrmGL111B
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
  Friend WithEvents RbObj As RadioButton
  Friend WithEvents RbDept As RadioButton
  Friend WithEvents RbFund As RadioButton
  Friend WithEvents LnkObjTo As LinkLabel
  Friend WithEvents LnkFundTo As LinkLabel
  Friend WithEvents LnkObjFrom As LinkLabel
  Friend WithEvents TxtObjTo As TextBox
  Friend WithEvents TxtObjFrom As TextBox
  Friend WithEvents TxtDeptTo As TextBox
  Friend WithEvents TxtDeptFrom As TextBox
  Friend WithEvents Label6 As Label
  Friend WithEvents Label7 As Label
  Friend WithEvents TxtSfundTo As TextBox
  Friend WithEvents TxtSfundFrom As TextBox
  Friend WithEvents Label5 As Label
  Friend WithEvents Label4 As Label
  Friend WithEvents LnkFundFrom As LinkLabel
  Friend WithEvents TxtFundTo As TextBox
  Friend WithEvents TxtFundFrom As TextBox
  Friend WithEvents LblMsg As Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.RbFund = New System.Windows.Forms.RadioButton()
    Me.RbDept = New System.Windows.Forms.RadioButton()
    Me.RbObj = New System.Windows.Forms.RadioButton()
    Me.LnkObjTo = New System.Windows.Forms.LinkLabel()
    Me.LnkFundTo = New System.Windows.Forms.LinkLabel()
    Me.LnkObjFrom = New System.Windows.Forms.LinkLabel()
    Me.TxtObjTo = New System.Windows.Forms.TextBox()
    Me.TxtObjFrom = New System.Windows.Forms.TextBox()
    Me.TxtDeptTo = New System.Windows.Forms.TextBox()
    Me.TxtDeptFrom = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtSfundTo = New System.Windows.Forms.TextBox()
    Me.TxtSfundFrom = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.LnkFundFrom = New System.Windows.Forms.LinkLabel()
    Me.TxtFundTo = New System.Windows.Forms.TextBox()
    Me.TxtFundFrom = New System.Windows.Forms.TextBox()
    Me.LblMsg = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'RbFund
    '
    Me.RbFund.AutoSize = True
    Me.RbFund.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbFund.Location = New System.Drawing.Point(25, 12)
    Me.RbFund.Name = "RbFund"
    Me.RbFund.Size = New System.Drawing.Size(85, 17)
    Me.RbFund.TabIndex = 323
    Me.RbFund.TabStop = True
    Me.RbFund.Text = "Fund/SFund"
    Me.RbFund.UseVisualStyleBackColor = True
    '
    'RbDept
    '
    Me.RbDept.AutoSize = True
    Me.RbDept.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbDept.Location = New System.Drawing.Point(153, 12)
    Me.RbDept.Name = "RbDept"
    Me.RbDept.Size = New System.Drawing.Size(113, 17)
    Me.RbDept.TabIndex = 324
    Me.RbDept.TabStop = True
    Me.RbDept.Text = "Fund/SFund/Dept"
    Me.RbDept.UseVisualStyleBackColor = True
    '
    'RbObj
    '
    Me.RbObj.AutoSize = True
    Me.RbObj.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbObj.Location = New System.Drawing.Point(303, 12)
    Me.RbObj.Name = "RbObj"
    Me.RbObj.Size = New System.Drawing.Size(134, 17)
    Me.RbObj.TabIndex = 325
    Me.RbObj.TabStop = True
    Me.RbObj.Text = "Fund/SFund/Dept/Obj"
    Me.RbObj.UseVisualStyleBackColor = True
    '
    'LnkObjTo
    '
    Me.LnkObjTo.AutoSize = True
    Me.LnkObjTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkObjTo.Location = New System.Drawing.Point(230, 122)
    Me.LnkObjTo.Name = "LnkObjTo"
    Me.LnkObjTo.Size = New System.Drawing.Size(16, 13)
    Me.LnkObjTo.TabIndex = 359
    Me.LnkObjTo.TabStop = True
    Me.LnkObjTo.Text = "to"
    '
    'LnkFundTo
    '
    Me.LnkFundTo.AutoSize = True
    Me.LnkFundTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFundTo.Location = New System.Drawing.Point(230, 45)
    Me.LnkFundTo.Name = "LnkFundTo"
    Me.LnkFundTo.Size = New System.Drawing.Size(16, 13)
    Me.LnkFundTo.TabIndex = 358
    Me.LnkFundTo.TabStop = True
    Me.LnkFundTo.Text = "to"
    '
    'LnkObjFrom
    '
    Me.LnkObjFrom.AutoSize = True
    Me.LnkObjFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkObjFrom.Location = New System.Drawing.Point(125, 122)
    Me.LnkObjFrom.Name = "LnkObjFrom"
    Me.LnkObjFrom.Size = New System.Drawing.Size(38, 13)
    Me.LnkObjFrom.TabIndex = 357
    Me.LnkObjFrom.TabStop = True
    Me.LnkObjFrom.Text = "Object"
    '
    'TxtObjTo
    '
    Me.TxtObjTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObjTo.Location = New System.Drawing.Point(252, 118)
    Me.TxtObjTo.MaxLength = 3
    Me.TxtObjTo.Name = "TxtObjTo"
    Me.TxtObjTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtObjTo.TabIndex = 351
    '
    'TxtObjFrom
    '
    Me.TxtObjFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObjFrom.Location = New System.Drawing.Point(190, 118)
    Me.TxtObjFrom.MaxLength = 3
    Me.TxtObjFrom.Name = "TxtObjFrom"
    Me.TxtObjFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtObjFrom.TabIndex = 350
    '
    'TxtDeptTo
    '
    Me.TxtDeptTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDeptTo.Location = New System.Drawing.Point(252, 94)
    Me.TxtDeptTo.MaxLength = 4
    Me.TxtDeptTo.Name = "TxtDeptTo"
    Me.TxtDeptTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtDeptTo.TabIndex = 349
    '
    'TxtDeptFrom
    '
    Me.TxtDeptFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDeptFrom.Location = New System.Drawing.Point(190, 94)
    Me.TxtDeptFrom.MaxLength = 4
    Me.TxtDeptFrom.Name = "TxtDeptFrom"
    Me.TxtDeptFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtDeptFrom.TabIndex = 348
    '
    'Label6
    '
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(230, 97)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(16, 16)
    Me.Label6.TabIndex = 356
    Me.Label6.Text = "to"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(123, 97)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(62, 13)
    Me.Label7.TabIndex = 355
    Me.Label7.Text = "Department"
    '
    'TxtSfundTo
    '
    Me.TxtSfundTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfundTo.Location = New System.Drawing.Point(252, 68)
    Me.TxtSfundTo.MaxLength = 3
    Me.TxtSfundTo.Name = "TxtSfundTo"
    Me.TxtSfundTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtSfundTo.TabIndex = 347
    '
    'TxtSfundFrom
    '
    Me.TxtSfundFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfundFrom.Location = New System.Drawing.Point(190, 68)
    Me.TxtSfundFrom.MaxLength = 3
    Me.TxtSfundFrom.Name = "TxtSfundFrom"
    Me.TxtSfundFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtSfundFrom.TabIndex = 346
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(230, 71)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(16, 16)
    Me.Label5.TabIndex = 354
    Me.Label5.Text = "to"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(123, 71)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(53, 13)
    Me.Label4.TabIndex = 353
    Me.Label4.Text = "Sub Fund"
    '
    'LnkFundFrom
    '
    Me.LnkFundFrom.AutoSize = True
    Me.LnkFundFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFundFrom.Location = New System.Drawing.Point(125, 46)
    Me.LnkFundFrom.Name = "LnkFundFrom"
    Me.LnkFundFrom.Size = New System.Drawing.Size(31, 13)
    Me.LnkFundFrom.TabIndex = 352
    Me.LnkFundFrom.TabStop = True
    Me.LnkFundFrom.Text = "Fund"
    '
    'TxtFundTo
    '
    Me.TxtFundTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFundTo.Location = New System.Drawing.Point(252, 42)
    Me.TxtFundTo.MaxLength = 3
    Me.TxtFundTo.Name = "TxtFundTo"
    Me.TxtFundTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtFundTo.TabIndex = 345
    '
    'TxtFundFrom
    '
    Me.TxtFundFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFundFrom.Location = New System.Drawing.Point(190, 42)
    Me.TxtFundFrom.MaxLength = 3
    Me.TxtFundFrom.Name = "TxtFundFrom"
    Me.TxtFundFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtFundFrom.TabIndex = 344
    '
    'LblMsg
    '
    Me.LblMsg.AutoSize = True
    Me.LblMsg.Location = New System.Drawing.Point(71, 150)
    Me.LblMsg.Name = "LblMsg"
    Me.LblMsg.Size = New System.Drawing.Size(62, 13)
    Me.LblMsg.TabIndex = 360
    Me.LblMsg.Text = "<Message>"
    '
    'FrmGL111B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(464, 181)
    Me.ControlBox = False
    Me.Controls.Add(Me.LblMsg)
    Me.Controls.Add(Me.LnkObjTo)
    Me.Controls.Add(Me.LnkFundTo)
    Me.Controls.Add(Me.LnkObjFrom)
    Me.Controls.Add(Me.TxtObjTo)
    Me.Controls.Add(Me.TxtObjFrom)
    Me.Controls.Add(Me.TxtDeptTo)
    Me.Controls.Add(Me.TxtDeptFrom)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TxtSfundTo)
    Me.Controls.Add(Me.TxtSfundFrom)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.LnkFundFrom)
    Me.Controls.Add(Me.TxtFundTo)
    Me.Controls.Add(Me.TxtFundFrom)
    Me.Controls.Add(Me.RbObj)
    Me.Controls.Add(Me.RbDept)
    Me.Controls.Add(Me.RbFund)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL111B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region
  Dim MyGLFUND As GLFUND.MyData

  Public Sub RunReport()
    MyGLFUND = New GLFUND.MyData
    MyGLFUND.MyDBConn = myDBConnect
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
    ProcFile()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub FrmGL111B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    LblMsg.Text = ""
  End Sub
  Private Sub FrmGL111B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGL111.SbpScreen.Text = "GL111B"
  End Sub
  Private Sub FrmGL111B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    ErrProv.Clear()

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "rbfund"
          ErrProv.SetError(RbFund, ErrorMsg(I))
        Case "fund"
          ErrProv.SetError(TxtFundFrom, ErrorMsg(I))
        Case "fundto"
          ErrProv.SetError(TxtFundTo, ErrorMsg(I))
        Case "sfundfrom"
          ErrProv.SetError(TxtSfundFrom, ErrorMsg(I))
        Case "sfundto"
          ErrProv.SetError(TxtSfundTo, ErrorMsg(I))
        Case "deptfrom"
          ErrProv.SetError(TxtDeptFrom, ErrorMsg(I))
        Case "deptto"
          ErrProv.SetError(TxtDeptTo, ErrorMsg(I))
        Case "objfrom"
          ErrProv.SetError(TxtObjFrom, ErrorMsg(I))
        Case "objto"
          ErrProv.SetError(TxtObjTo, ErrorMsg(I))
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

    If Not RbFund.Checked And Not RbDept.Checked And Not RbObj.Checked Then
      ErrorField(I) = "rbfund"
      ErrorMsg(I) = "You must select a copy option"
      I = I + 1
    End If

    If RbFund.Checked Then
      MyGLFUND.GetOneRecordP(MyUtils.CnvSng(MyFrmGL111B.TxtFundFrom.Text), MyUtils.CnvSng(MyFrmGL111B.TxtSfundFrom.Text))
      If MyGLFUND.RecordNotFound Then
        ErrorField(I) = "fund"
        ErrorMsg(I) = "Invalid From Fund"
        I = I + 1
      End If
      MyGLFUND.GetOneRecordP(MyUtils.CnvSng(MyFrmGL111B.TxtFundTo.Text), MyUtils.CnvSng(MyFrmGL111B.TxtSfundTo.Text))
      If Not MyGLFUND.RecordNotFound Then
        ErrorField(I) = "fundto"
        ErrorMsg(I) = "Fund already exists"
        I = I + 1
      End If
    End If

    If Not RbFund.Checked Then
      MyGLFUND.GetOneRecordP(MyUtils.CnvSng(MyFrmGL111B.TxtFundTo.Text), MyUtils.CnvSng(MyFrmGL111B.TxtSfundTo.Text))
      If MyGLFUND.RecordNotFound Then
        ErrorField(I) = "fundto"
        ErrorMsg(I) = "Invalid To Fund"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtFundFrom.Text) = 0 Then
      ErrorField(I) = "fund"
      ErrorMsg(I) = "Invalid From Fund"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtFundTo.Text) = 0 Then
      ErrorField(I) = "fundto"
      ErrorMsg(I) = "Invalid To Fund"
      I = I + 1
    End If

    If RbFund.Checked And MyUtils.CnvSng(TxtFundFrom.Text) = MyUtils.CnvSng(TxtFundTo.Text) Then
      ErrorField(I) = "fundto"
      ErrorMsg(I) = "From/To Fund must be different"
      I = I + 1
    End If
  End Sub
  Private Sub TxtFundFrom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFundFrom.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfundFrom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfundFrom.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDeptFrom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDeptFrom.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtObjFrom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtObjFrom.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFundTo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFundTo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfundTo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfundTo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDeptTo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDeptTo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtObjTo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtObjTo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Private Sub LnkFundFrom_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFundFrom.LinkClicked
    MyFrmListFund = New FrmListFund
    MyFrmListFund.MdiParent = Me.ParentForm
    MyFrmListFund.WrkFund = MyUtils.CnvSng(TxtFundFrom.Text)
    MyFrmListFund.WrkID = "From"
    MyFrmListFund.Show()
    Me.Hide()
  End Sub
  Private Sub LnkFundTo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFundTo.LinkClicked
    MyFrmListFund = New FrmListFund
    MyFrmListFund.MdiParent = Me.ParentForm
    MyFrmListFund.WrkFund = MyUtils.CnvSng(TxtFundTo.Text)
    MyFrmListFund.WrkID = "To"
    MyFrmListFund.Show()
    Me.Hide()
  End Sub
  Private Sub LnkObjFrom_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkObjFrom.LinkClicked
    MyFrmListObj = New FrmListObj
    MyFrmListObj.MdiParent = Me.ParentForm
    MyFrmListObj.WrkObj = MyUtils.CnvSng(TxtObjFrom.Text)
    MyFrmListObj.WrkID = "From"
    MyFrmListObj.Show()
    Me.Hide()
  End Sub
  Private Sub LnkObjTo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkObjTo.LinkClicked
    MyFrmListObj = New FrmListObj
    MyFrmListObj.MdiParent = Me.ParentForm
    MyFrmListObj.WrkObj = MyUtils.CnvSng(TxtObjTo.Text)
    MyFrmListObj.WrkID = "To"
    MyFrmListObj.Show()
    Me.Hide()
  End Sub
End Class
