Public Class FrmGL801B
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
Friend WithEvents TxtSelFund As System.Windows.Forms.TextBox
Friend WithEvents TxtSelSfund As System.Windows.Forms.TextBox
Friend WithEvents LnkFund As System.Windows.Forms.LinkLabel
Friend WithEvents DtPckPost As System.Windows.Forms.DateTimePicker
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents TxtFiscyr As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents LnkGLAcct As System.Windows.Forms.LinkLabel
Friend WithEvents TxtSfcn As System.Windows.Forms.TextBox
Friend WithEvents TxtFcn As System.Windows.Forms.TextBox
Friend WithEvents TxtObj As System.Windows.Forms.TextBox
Friend WithEvents TxtDept As System.Windows.Forms.TextBox
Friend WithEvents TxtSfund As System.Windows.Forms.TextBox
Friend WithEvents TxtFund As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtSelFund = New System.Windows.Forms.TextBox()
    Me.TxtSelSfund = New System.Windows.Forms.TextBox()
    Me.LnkFund = New System.Windows.Forms.LinkLabel()
    Me.DtPckPost = New System.Windows.Forms.DateTimePicker()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtFiscyr = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.LnkGLAcct = New System.Windows.Forms.LinkLabel()
    Me.TxtSfcn = New System.Windows.Forms.TextBox()
    Me.TxtFcn = New System.Windows.Forms.TextBox()
    Me.TxtObj = New System.Windows.Forms.TextBox()
    Me.TxtDept = New System.Windows.Forms.TextBox()
    Me.TxtSfund = New System.Windows.Forms.TextBox()
    Me.TxtFund = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtSelFund
    '
    Me.TxtSelFund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSelFund.Location = New System.Drawing.Point(134, 26)
    Me.TxtSelFund.MaxLength = 3
    Me.TxtSelFund.Name = "TxtSelFund"
    Me.TxtSelFund.Size = New System.Drawing.Size(30, 22)
    Me.TxtSelFund.TabIndex = 1
    '
    'TxtSelSfund
    '
    Me.TxtSelSfund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSelSfund.Location = New System.Drawing.Point(179, 26)
    Me.TxtSelSfund.MaxLength = 3
    Me.TxtSelSfund.Name = "TxtSelSfund"
    Me.TxtSelSfund.Size = New System.Drawing.Size(34, 22)
    Me.TxtSelSfund.TabIndex = 2
    '
    'LnkFund
    '
    Me.LnkFund.AutoSize = True
    Me.LnkFund.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFund.Location = New System.Drawing.Point(97, 30)
    Me.LnkFund.Name = "LnkFund"
    Me.LnkFund.Size = New System.Drawing.Size(31, 13)
    Me.LnkFund.TabIndex = 0
    Me.LnkFund.TabStop = True
    Me.LnkFund.Text = "Fund"
    '
    'DtPckPost
    '
    Me.DtPckPost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckPost.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckPost.Location = New System.Drawing.Point(134, 88)
    Me.DtPckPost.Name = "DtPckPost"
    Me.DtPckPost.Size = New System.Drawing.Size(88, 20)
    Me.DtPckPost.TabIndex = 4
    Me.DtPckPost.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(30, 94)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(68, 13)
    Me.Label8.TabIndex = 328
    Me.Label8.Text = "Posting Date"
    '
    'TxtFiscyr
    '
    Me.TxtFiscyr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFiscyr.Location = New System.Drawing.Point(134, 60)
    Me.TxtFiscyr.MaxLength = 4
    Me.TxtFiscyr.Name = "TxtFiscyr"
    Me.TxtFiscyr.Size = New System.Drawing.Size(38, 22)
    Me.TxtFiscyr.TabIndex = 3
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(30, 64)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(99, 13)
    Me.Label1.TabIndex = 330
    Me.Label1.Text = "Fiscal Year to close"
    '
    'LnkGLAcct
    '
    Me.LnkGLAcct.AutoSize = True
    Me.LnkGLAcct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkGLAcct.ForeColor = System.Drawing.Color.Maroon
    Me.LnkGLAcct.Location = New System.Drawing.Point(12, 128)
    Me.LnkGLAcct.Name = "LnkGLAcct"
    Me.LnkGLAcct.Size = New System.Drawing.Size(66, 13)
    Me.LnkGLAcct.TabIndex = 5
    Me.LnkGLAcct.TabStop = True
    Me.LnkGLAcct.Text = "Liability Acct"
    '
    'TxtSfcn
    '
    Me.TxtSfcn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfcn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfcn.Location = New System.Drawing.Point(296, 124)
    Me.TxtSfcn.MaxLength = 4
    Me.TxtSfcn.Name = "TxtSfcn"
    Me.TxtSfcn.Size = New System.Drawing.Size(45, 22)
    Me.TxtSfcn.TabIndex = 11
    '
    'TxtFcn
    '
    Me.TxtFcn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFcn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFcn.Location = New System.Drawing.Point(245, 124)
    Me.TxtFcn.MaxLength = 4
    Me.TxtFcn.Name = "TxtFcn"
    Me.TxtFcn.Size = New System.Drawing.Size(45, 22)
    Me.TxtFcn.TabIndex = 10
    '
    'TxtObj
    '
    Me.TxtObj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObj.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObj.Location = New System.Drawing.Point(209, 124)
    Me.TxtObj.MaxLength = 3
    Me.TxtObj.Name = "TxtObj"
    Me.TxtObj.Size = New System.Drawing.Size(32, 22)
    Me.TxtObj.TabIndex = 9
    '
    'TxtDept
    '
    Me.TxtDept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDept.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDept.Location = New System.Drawing.Point(158, 124)
    Me.TxtDept.MaxLength = 4
    Me.TxtDept.Name = "TxtDept"
    Me.TxtDept.Size = New System.Drawing.Size(45, 22)
    Me.TxtDept.TabIndex = 8
    '
    'TxtSfund
    '
    Me.TxtSfund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfund.Location = New System.Drawing.Point(120, 124)
    Me.TxtSfund.MaxLength = 3
    Me.TxtSfund.Name = "TxtSfund"
    Me.TxtSfund.Size = New System.Drawing.Size(32, 22)
    Me.TxtSfund.TabIndex = 7
    '
    'TxtFund
    '
    Me.TxtFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFund.Location = New System.Drawing.Point(82, 124)
    Me.TxtFund.MaxLength = 3
    Me.TxtFund.Name = "TxtFund"
    Me.TxtFund.Size = New System.Drawing.Size(32, 22)
    Me.TxtFund.TabIndex = 6
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.ForeColor = System.Drawing.Color.Black
    Me.Label2.Location = New System.Drawing.Point(54, 7)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(262, 16)
    Me.Label2.TabIndex = 331
    Me.Label2.Text = "This will create a Journal Entry Batch"
    '
    'FrmGL801B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(354, 166)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.LnkGLAcct)
    Me.Controls.Add(Me.TxtSfcn)
    Me.Controls.Add(Me.TxtFcn)
    Me.Controls.Add(Me.TxtObj)
    Me.Controls.Add(Me.TxtDept)
    Me.Controls.Add(Me.TxtSfund)
    Me.Controls.Add(Me.TxtFund)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtFiscyr)
    Me.Controls.Add(Me.DtPckPost)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.LnkFund)
    Me.Controls.Add(Me.TxtSelSfund)
    Me.Controls.Add(Me.TxtSelFund)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL801B"
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
    ProcFile()
    TxtSelFund.Text = ""
    TxtSelSfund.Text = ""
    TxtFiscyr.Text = ""
    TxtFund.Text = ""
    TxtSfund.Text = ""
    TxtDept.Text = ""
    TxtObj.Text = ""
    TxtFcn.Text = ""
    TxtSfcn.Text = ""
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
Private Sub FrmGL801B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  DtPckPost.Value = Date.Today
End Sub
Private Sub FrmGL801B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmGL801.SbpScreen.Text = "GL801B"
End Sub
Private Sub FrmGL801B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    ErrProv.SetError(TxtSelFund, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "fund"
        ErrProv.SetError(TxtSelFund, ErrorMsg(I))
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

    If TxtSelFund.Text = "" Then
      ErrorField(I) = "fund"
      ErrorMsg(I) = "Invalid Fund"
      I = I + 1
    End If
  End Sub
Private Sub TxtSelFund_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSelFund.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtSelSfund_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSelSfund.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub LnkFund_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFund.LinkClicked
  MyFrmListFund = New FrmListFund
  MyFrmListFund.MdiParent = Me.ParentForm
  MyFrmListFund.WrkFund = MyUtils.CnvSng(TxtSelFund.Text)
  MyFrmListFund.WrkID = "From"
  MyFrmListFund.Show()
  Me.Hide()
End Sub
Private Sub LnkGLAcct_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkGLAcct.LinkClicked
  Dim WrkAcct As String

  WrkAcct = BuildAcct(MyUtils.CnvSng(TxtSelFund.Text), MyUtils.CnvSng(TxtSelSfund.Text), MyUtils.CnvSng(TxtDept.Text), _
    MyUtils.CnvSng(TxtObj.Text), MyUtils.CnvSng(TxtFcn.Text), MyUtils.CnvSng(TxtSfcn.Text))
  MyFrmListGLAcct = New FrmListGLAcct
  MyFrmListGLAcct.MdiParent = Me.ParentForm
  MyFrmListGLAcct.WrkField = ""
  MyFrmListGLAcct.WrkCode = WrkAcct
  MyFrmListGLAcct.Show()
  Me.Hide()
End Sub
Private Sub TxtFund_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSelFund.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtSfund_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSelSfund.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDept_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDept.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtObj_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtObj.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtFcn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFcn.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtSfcn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfcn.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class
