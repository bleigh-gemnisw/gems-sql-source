Public Class FrmGL802B
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
  Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtSelFund = New System.Windows.Forms.TextBox()
    Me.TxtSelSfund = New System.Windows.Forms.TextBox()
    Me.LnkFund = New System.Windows.Forms.LinkLabel()
    Me.TxtDesc = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox3.SuspendLayout()
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
    Me.TxtSelFund.TabIndex = 0
    '
    'TxtSelSfund
    '
    Me.TxtSelSfund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSelSfund.Location = New System.Drawing.Point(308, 12)
    Me.TxtSelSfund.MaxLength = 3
    Me.TxtSelSfund.Name = "TxtSelSfund"
    Me.TxtSelSfund.Size = New System.Drawing.Size(34, 22)
    Me.TxtSelSfund.TabIndex = 1
    Me.TxtSelSfund.Visible = False
    '
    'LnkFund
    '
    Me.LnkFund.AutoSize = True
    Me.LnkFund.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFund.Location = New System.Drawing.Point(97, 30)
    Me.LnkFund.Name = "LnkFund"
    Me.LnkFund.Size = New System.Drawing.Size(31, 13)
    Me.LnkFund.TabIndex = 319
    Me.LnkFund.TabStop = True
    Me.LnkFund.Text = "Fund"
    '
    'TxtDesc
    '
    Me.TxtDesc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDesc.Location = New System.Drawing.Point(155, 60)
    Me.TxtDesc.MaxLength = 4
    Me.TxtDesc.Name = "TxtDesc"
    Me.TxtDesc.Size = New System.Drawing.Size(164, 22)
    Me.TxtDesc.TabIndex = 2
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(30, 64)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(119, 13)
    Me.Label1.TabIndex = 330
    Me.Label1.Text = "Transaction Description"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.DtPckTo)
    Me.GroupBox3.Controls.Add(Me.Label2)
    Me.GroupBox3.Controls.Add(Me.DtPckFrom)
    Me.GroupBox3.Controls.Add(Me.Label3)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(33, 88)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(286, 52)
    Me.GroupBox3.TabIndex = 3
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Transaction Date Range"
    '
    'DtPckTo
    '
    Me.DtPckTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTo.Location = New System.Drawing.Point(185, 20)
    Me.DtPckTo.Name = "DtPckTo"
    Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
    Me.DtPckTo.TabIndex = 1
    Me.DtPckTo.Value = New Date(2005, 10, 6, 9, 11, 0, 906)
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(151, 24)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(28, 16)
    Me.Label2.TabIndex = 9
    Me.Label2.Text = "To "
    '
    'DtPckFrom
    '
    Me.DtPckFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFrom.Location = New System.Drawing.Point(52, 20)
    Me.DtPckFrom.Name = "DtPckFrom"
    Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
    Me.DtPckFrom.TabIndex = 0
    Me.DtPckFrom.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(12, 20)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(36, 16)
    Me.Label3.TabIndex = 7
    Me.Label3.Text = "From"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(249, 16)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(53, 13)
    Me.Label4.TabIndex = 331
    Me.Label4.Text = "Sub Fund"
    Me.Label4.Visible = False
    '
    'FrmGL802B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(354, 166)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtDesc)
    Me.Controls.Add(Me.LnkFund)
    Me.Controls.Add(Me.TxtSelSfund)
    Me.Controls.Add(Me.TxtSelFund)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL802B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox3.ResumeLayout(False)
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
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub FrmGL802B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    InitFiles()
    If Now.Date.Month >= 7 Then
      DtPckFrom.Value = "#7/1/" & Now.Date.Year & "#"
    Else
      DtPckFrom.Value = "#7/1/" & Now.Date.Year - 1 & "#"
    End If
    DtPckTo.Value = Now.Date
    TxtDesc.Text = "CLOSE FISCAL YEAR"
  End Sub
  Private Sub FrmGL802B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGL802.SbpScreen.Text = "GL802B"
  End Sub
  Private Sub FrmGL802B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
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
End Class
