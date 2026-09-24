Public Class FrmGL704B
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
Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents LnkFundFrom As System.Windows.Forms.LinkLabel
Friend WithEvents TxtFundTo As System.Windows.Forms.TextBox
Friend WithEvents TxtFundFrom As System.Windows.Forms.TextBox
Friend WithEvents LnkFundTo As System.Windows.Forms.LinkLabel
Friend WithEvents ChkNoActivity As System.Windows.Forms.CheckBox
Friend WithEvents ChkInactiveRpt As System.Windows.Forms.CheckBox
Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.LnkFundFrom = New System.Windows.Forms.LinkLabel()
    Me.TxtFundTo = New System.Windows.Forms.TextBox()
    Me.TxtFundFrom = New System.Windows.Forms.TextBox()
    Me.LnkFundTo = New System.Windows.Forms.LinkLabel()
    Me.ChkNoActivity = New System.Windows.Forms.CheckBox()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.ChkInactiveRpt = New System.Windows.Forms.CheckBox()
    Me.GroupBox3.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.DtPckTo)
    Me.GroupBox3.Controls.Add(Me.Label2)
    Me.GroupBox3.Controls.Add(Me.DtPckFrom)
    Me.GroupBox3.Controls.Add(Me.Label1)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(22, 22)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(286, 52)
    Me.GroupBox3.TabIndex = 0
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Date Range"
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
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(12, 20)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(36, 16)
    Me.Label1.TabIndex = 7
    Me.Label1.Text = "From"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LnkFundFrom
    '
    Me.LnkFundFrom.AutoSize = True
    Me.LnkFundFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFundFrom.Location = New System.Drawing.Point(19, 91)
    Me.LnkFundFrom.Name = "LnkFundFrom"
    Me.LnkFundFrom.Size = New System.Drawing.Size(31, 13)
    Me.LnkFundFrom.TabIndex = 318
    Me.LnkFundFrom.TabStop = True
    Me.LnkFundFrom.Text = "Fund"
    '
    'TxtFundTo
    '
    Me.TxtFundTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFundTo.Location = New System.Drawing.Point(146, 87)
    Me.TxtFundTo.MaxLength = 3
    Me.TxtFundTo.Name = "TxtFundTo"
    Me.TxtFundTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtFundTo.TabIndex = 316
    '
    'TxtFundFrom
    '
    Me.TxtFundFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFundFrom.Location = New System.Drawing.Point(84, 87)
    Me.TxtFundFrom.MaxLength = 3
    Me.TxtFundFrom.Name = "TxtFundFrom"
    Me.TxtFundFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtFundFrom.TabIndex = 315
    '
    'LnkFundTo
    '
    Me.LnkFundTo.AutoSize = True
    Me.LnkFundTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFundTo.Location = New System.Drawing.Point(124, 90)
    Me.LnkFundTo.Name = "LnkFundTo"
    Me.LnkFundTo.Size = New System.Drawing.Size(16, 13)
    Me.LnkFundTo.TabIndex = 340
    Me.LnkFundTo.TabStop = True
    Me.LnkFundTo.Text = "to"
    '
    'ChkNoActivity
    '
    Me.ChkNoActivity.AutoSize = True
    Me.ChkNoActivity.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkNoActivity.Checked = True
    Me.ChkNoActivity.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkNoActivity.Location = New System.Drawing.Point(14, 126)
    Me.ChkNoActivity.Name = "ChkNoActivity"
    Me.ChkNoActivity.Size = New System.Drawing.Size(169, 17)
    Me.ChkNoActivity.TabIndex = 342
    Me.ChkNoActivity.Text = "Include funds with no activity?"
    Me.ChkNoActivity.UseVisualStyleBackColor = True
    '
    'ChkInactiveRpt
    '
    Me.ChkInactiveRpt.AutoSize = True
    Me.ChkInactiveRpt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkInactiveRpt.Checked = True
    Me.ChkInactiveRpt.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkInactiveRpt.Location = New System.Drawing.Point(14, 149)
    Me.ChkInactiveRpt.Name = "ChkInactiveRpt"
    Me.ChkInactiveRpt.Size = New System.Drawing.Size(181, 17)
    Me.ChkInactiveRpt.TabIndex = 343
    Me.ChkInactiveRpt.Text = "Include fund inactive on reports?"
    Me.ChkInactiveRpt.UseVisualStyleBackColor = True
    '
    'FrmGL704B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(329, 179)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkInactiveRpt)
    Me.Controls.Add(Me.ChkNoActivity)
    Me.Controls.Add(Me.LnkFundTo)
    Me.Controls.Add(Me.LnkFundFrom)
    Me.Controls.Add(Me.TxtFundTo)
    Me.Controls.Add(Me.TxtFundFrom)
    Me.Controls.Add(Me.GroupBox3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL704B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.GroupBox3.ResumeLayout(False)
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmGL704B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmGL704.SbpScreen.Text = "GL704"
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
Private Sub FrmGL704B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFundFrom, "")
    ErrProv.SetError(TxtFundTo, "")
    ErrProv.SetError(DtPckFrom, "")
    ErrProv.SetError(DtPckTo, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "fundfrom"
        ErrProv.SetError(TxtFundFrom, ErrorMsg(I))
      Case "fundto"
        ErrProv.SetError(TxtFundTo, ErrorMsg(I))
      Case "date"
        ErrProv.SetError(DtPckFrom, ErrorMsg(I))
      Case "date"
        ErrProv.SetError(DtPckTo, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtFundFrom.Text) > MyUtils.CnvSng(TxtFundTo.Text) Then
      ErrorField(I) = "fundfrom"
      ErrorMsg(I) = "Invalid Fund Range"
      I = I + 1
      ErrorField(I) = "fundto"
      ErrorMsg(I) = "Invalid Fund Range"
      I = I + 1
    End If

    If MyUtils.SetDBDate(DtPckFrom.Value) > MyUtils.SetDBDate(DtPckTo.Value) Then
      ErrorField(I) = "date"
      ErrorMsg(I) = "Invalid date Range"
      I = I + 1
    End If

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

Private Sub FrmGL704B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  InitFiles()
  If Now.Date.Month >= 7 Then
    DtPckFrom.Value = "#7/1/" & Now.Date.Year & "#"
  Else
    DtPckFrom.Value = "#7/1/" & Now.Date.Year - 1 & "#"
  End If
  DtPckTo.Value = Now.Date

End Sub
End Class
