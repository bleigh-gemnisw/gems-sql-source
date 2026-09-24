Public Class FrmTXE56B
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
Friend WithEvents ChkAdjust As System.Windows.Forms.CheckBox
Friend WithEvents ChkShowAdjust As System.Windows.Forms.CheckBox
Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
Friend WithEvents ChkOtherBreak As System.Windows.Forms.CheckBox
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ChkTransfer As CheckBox
    Friend WithEvents ChkShowTransfer As CheckBox
    Friend WithEvents ChkRefunds As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChkRefunds = New System.Windows.Forms.CheckBox()
        Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ChkAdjust = New System.Windows.Forms.CheckBox()
        Me.ChkShowAdjust = New System.Windows.Forms.CheckBox()
        Me.LnkTypes = New System.Windows.Forms.LinkLabel()
        Me.TxtTypes = New System.Windows.Forms.TextBox()
        Me.ChkOtherBreak = New System.Windows.Forms.CheckBox()
        Me.TxtDist = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ChkTransfer = New System.Windows.Forms.CheckBox()
        Me.ChkShowTransfer = New System.Windows.Forms.CheckBox()
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
        Me.GroupBox3.Location = New System.Drawing.Point(24, 20)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(300, 52)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Payment Date Range"
        '
        'DtPckTo
        '
        Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckTo.Location = New System.Drawing.Point(196, 20)
        Me.DtPckTo.Name = "DtPckTo"
        Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
        Me.DtPckTo.TabIndex = 1
        Me.DtPckTo.Value = New Date(2005, 10, 6, 9, 11, 0, 906)
        '
        'Label2
        '
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
        Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
        Me.DtPckFrom.TabIndex = 0
        Me.DtPckFrom.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "From"
        '
        'ChkRefunds
        '
        Me.ChkRefunds.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkRefunds.Location = New System.Drawing.Point(24, 141)
        Me.ChkRefunds.Name = "ChkRefunds"
        Me.ChkRefunds.Size = New System.Drawing.Size(140, 16)
        Me.ChkRefunds.TabIndex = 3
        Me.ChkRefunds.Text = "Include refunds?"
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'ChkAdjust
        '
        Me.ChkAdjust.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkAdjust.Checked = True
        Me.ChkAdjust.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkAdjust.Location = New System.Drawing.Point(24, 163)
        Me.ChkAdjust.Name = "ChkAdjust"
        Me.ChkAdjust.Size = New System.Drawing.Size(140, 16)
        Me.ChkAdjust.TabIndex = 4
        Me.ChkAdjust.Text = "Include adjustments?"
        '
        'ChkShowAdjust
        '
        Me.ChkShowAdjust.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkShowAdjust.Location = New System.Drawing.Point(183, 163)
        Me.ChkShowAdjust.Name = "ChkShowAdjust"
        Me.ChkShowAdjust.Size = New System.Drawing.Size(140, 16)
        Me.ChkShowAdjust.TabIndex = 5
        Me.ChkShowAdjust.Text = "Show adjustment total?"
        '
        'LnkTypes
        '
        Me.LnkTypes.Location = New System.Drawing.Point(31, 88)
        Me.LnkTypes.Name = "LnkTypes"
        Me.LnkTypes.Size = New System.Drawing.Size(72, 16)
        Me.LnkTypes.TabIndex = 27
        Me.LnkTypes.TabStop = True
        Me.LnkTypes.Text = "Select Types"
        '
        'TxtTypes
        '
        Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTypes.Location = New System.Drawing.Point(109, 85)
        Me.TxtTypes.MaxLength = 20
        Me.TxtTypes.Name = "TxtTypes"
        Me.TxtTypes.Size = New System.Drawing.Size(116, 20)
        Me.TxtTypes.TabIndex = 1
        '
        'ChkOtherBreak
        '
        Me.ChkOtherBreak.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkOtherBreak.Location = New System.Drawing.Point(24, 218)
        Me.ChkOtherBreak.Name = "ChkOtherBreak"
        Me.ChkOtherBreak.Size = New System.Drawing.Size(237, 18)
        Me.ChkOtherBreak.TabIndex = 8
        Me.ChkOtherBreak.Text = "Other types: Page break after each type?"
        '
        'TxtDist
        '
        Me.TxtDist.Location = New System.Drawing.Point(109, 108)
        Me.TxtDist.MaxLength = 4
        Me.TxtDist.Name = "TxtDist"
        Me.TxtDist.Size = New System.Drawing.Size(32, 20)
        Me.TxtDist.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(36, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 17)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "District"
        '
        'ChkTransfer
        '
        Me.ChkTransfer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkTransfer.Checked = True
        Me.ChkTransfer.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkTransfer.Location = New System.Drawing.Point(24, 185)
        Me.ChkTransfer.Name = "ChkTransfer"
        Me.ChkTransfer.Size = New System.Drawing.Size(140, 16)
        Me.ChkTransfer.TabIndex = 6
        Me.ChkTransfer.Text = "Include transfers?"
        '
        'ChkShowTransfer
        '
        Me.ChkShowTransfer.AutoSize = True
        Me.ChkShowTransfer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkShowTransfer.Location = New System.Drawing.Point(203, 185)
        Me.ChkShowTransfer.Name = "ChkShowTransfer"
        Me.ChkShowTransfer.Size = New System.Drawing.Size(120, 17)
        Me.ChkShowTransfer.TabIndex = 7
        Me.ChkShowTransfer.Text = "Show transfer total?"
        '
        'FrmTXE56B
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(352, 248)
        Me.ControlBox = False
        Me.Controls.Add(Me.ChkShowTransfer)
        Me.Controls.Add(Me.ChkTransfer)
        Me.Controls.Add(Me.TxtDist)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ChkOtherBreak)
        Me.Controls.Add(Me.LnkTypes)
        Me.Controls.Add(Me.TxtTypes)
        Me.Controls.Add(Me.ChkShowAdjust)
        Me.Controls.Add(Me.ChkAdjust)
        Me.Controls.Add(Me.ChkRefunds)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTXE56B"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox3.ResumeLayout(False)
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
Private Sub FrmTXE56B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    DtPckFrom.Value = Date.Today
    DtPckTo.Value = Date.Today
End Sub
Private Sub FrmTXE56B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTXE56.SbpScreen.Text = "TXE56B"
End Sub
Private Sub FrmTXE56B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(DtPckFrom, "")
    ErrProv.SetError(DtPckTo, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "from"
        ErrProv.SetError(DtPckFrom, ErrorMsg(I))
      Case "to"
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

    If MyUtils.SetDBDate(DtPckFrom.Value) > MyUtils.SetDBDate(DtPckTo.Value) Then
      ErrorField(I) = "to"
      ErrorMsg(I) = "Invalid date Range"
      I = I + 1
    End If

  End Sub

Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
  MyTypes = TxtTypes.Text
  myFrmSelTypes = New FrmSelTypes
  myFrmSelTypes.MdiParent = Me.ParentForm
  myFrmSelTypes.Show()

End Sub
End Class






