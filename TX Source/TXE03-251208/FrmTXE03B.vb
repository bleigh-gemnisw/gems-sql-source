Public Class FrmTXE03B
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
  Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
Friend WithEvents TxtToGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents ChkSuspense As System.Windows.Forms.CheckBox
Friend WithEvents ChkPaid As System.Windows.Forms.CheckBox
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents TxtBankCd As System.Windows.Forms.TextBox
Friend WithEvents LnkBankCd As System.Windows.Forms.LinkLabel
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents ChkUnPosted As System.Windows.Forms.CheckBox
Friend WithEvents DtPckDue As System.Windows.Forms.DateTimePicker
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TxtTypes = New System.Windows.Forms.TextBox
Me.TxtFromGLYear = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.LnkTypes = New System.Windows.Forms.LinkLabel
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TxtToGLYear = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.Label6 = New System.Windows.Forms.Label
Me.ChkSuspense = New System.Windows.Forms.CheckBox
Me.ChkPaid = New System.Windows.Forms.CheckBox
Me.TxtDist = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
Me.TxtBankCd = New System.Windows.Forms.TextBox
Me.LnkBankCd = New System.Windows.Forms.LinkLabel
Me.Label1 = New System.Windows.Forms.Label
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ChkUnPosted = New System.Windows.Forms.CheckBox
Me.DtPckDue = New System.Windows.Forms.DateTimePicker
Me.Label2 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'TxtTypes
'
Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtTypes.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtTypes.Location = New System.Drawing.Point(120, 12)
Me.TxtTypes.MaxLength = 20
Me.TxtTypes.Name = "TxtTypes"
Me.TxtTypes.Size = New System.Drawing.Size(148, 20)
Me.TxtTypes.TabIndex = 0
'
'TxtFromGLYear
'
Me.TxtFromGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFromGLYear.Location = New System.Drawing.Point(128, 44)
Me.TxtFromGLYear.MaxLength = 4
Me.TxtFromGLYear.Name = "TxtFromGLYear"
Me.TxtFromGLYear.Size = New System.Drawing.Size(36, 20)
Me.TxtFromGLYear.TabIndex = 1
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(36, 48)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(84, 16)
Me.Label4.TabIndex = 11
Me.Label4.Text = "Grand List Year"
'
'LnkTypes
'
Me.LnkTypes.Location = New System.Drawing.Point(36, 16)
Me.LnkTypes.Name = "LnkTypes"
Me.LnkTypes.Size = New System.Drawing.Size(80, 16)
Me.LnkTypes.TabIndex = 17
Me.LnkTypes.TabStop = True
Me.LnkTypes.Text = "Types to print"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'TxtToGLYear
'
Me.TxtToGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtToGLYear.Location = New System.Drawing.Point(192, 44)
Me.TxtToGLYear.MaxLength = 4
Me.TxtToGLYear.Name = "TxtToGLYear"
Me.TxtToGLYear.Size = New System.Drawing.Size(36, 20)
Me.TxtToGLYear.TabIndex = 2
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(168, 48)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(16, 16)
Me.Label3.TabIndex = 19
Me.Label3.Text = "to"
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(236, 48)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(56, 16)
Me.Label6.TabIndex = 28
Me.Label6.Text = "(Optional)"
'
'ChkSuspense
'
Me.ChkSuspense.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkSuspense.Location = New System.Drawing.Point(39, 163)
Me.ChkSuspense.Name = "ChkSuspense"
Me.ChkSuspense.Size = New System.Drawing.Size(125, 22)
Me.ChkSuspense.TabIndex = 7
Me.ChkSuspense.Text = "Include Suspense?"
'
'ChkPaid
'
Me.ChkPaid.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkPaid.Location = New System.Drawing.Point(39, 126)
Me.ChkPaid.Name = "ChkPaid"
Me.ChkPaid.Size = New System.Drawing.Size(125, 21)
Me.ChkPaid.TabIndex = 5
Me.ChkPaid.Text = "Include Paid Accts?"
'
'TxtDist
'
Me.TxtDist.Location = New System.Drawing.Point(128, 100)
Me.TxtDist.MaxLength = 4
Me.TxtDist.Name = "TxtDist"
Me.TxtDist.Size = New System.Drawing.Size(32, 20)
Me.TxtDist.TabIndex = 4
'
'Label5
'
Me.Label5.Location = New System.Drawing.Point(36, 103)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(70, 17)
Me.Label5.TabIndex = 30
Me.Label5.Text = "District"
'
'TxtBankCd
'
Me.TxtBankCd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtBankCd.Location = New System.Drawing.Point(128, 75)
Me.TxtBankCd.MaxLength = 2
Me.TxtBankCd.Name = "TxtBankCd"
Me.TxtBankCd.Size = New System.Drawing.Size(24, 20)
Me.TxtBankCd.TabIndex = 3
'
'LnkBankCd
'
Me.LnkBankCd.Location = New System.Drawing.Point(36, 75)
Me.LnkBankCd.Name = "LnkBankCd"
Me.LnkBankCd.Size = New System.Drawing.Size(80, 16)
Me.LnkBankCd.TabIndex = 168
Me.LnkBankCd.TabStop = True
Me.LnkBankCd.Text = "Escrow Bank"
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(164, 78)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(56, 16)
Me.Label1.TabIndex = 169
Me.Label1.Text = "(Optional)"
'
'ChkUnPosted
'
Me.ChkUnPosted.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkUnPosted.Location = New System.Drawing.Point(39, 146)
Me.ChkUnPosted.Name = "ChkUnPosted"
Me.ChkUnPosted.Size = New System.Drawing.Size(125, 20)
Me.ChkUnPosted.TabIndex = 6
Me.ChkUnPosted.Text = "Include Unposted?"
'
'DtPckDue
'
Me.DtPckDue.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckDue.Location = New System.Drawing.Point(180, 191)
Me.DtPckDue.Name = "DtPckDue"
Me.DtPckDue.Size = New System.Drawing.Size(88, 20)
Me.DtPckDue.TabIndex = 170
Me.DtPckDue.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(36, 195)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(139, 16)
Me.Label2.TabIndex = 171
Me.Label2.Text = "Include Amounts due up to"
'
'FrmTXE03B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(308, 228)
Me.ControlBox = False
Me.Controls.Add(Me.DtPckDue)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.ChkUnPosted)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.TxtBankCd)
Me.Controls.Add(Me.LnkBankCd)
Me.Controls.Add(Me.TxtDist)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.ChkPaid)
Me.Controls.Add(Me.ChkSuspense)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.TxtToGLYear)
Me.Controls.Add(Me.TxtFromGLYear)
Me.Controls.Add(Me.TxtTypes)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.LnkTypes)
Me.Controls.Add(Me.Label4)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTXE03B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTXE03B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTXE03.SbpScreen.Text = "TXE03"
End Sub

Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
  MyTypes = TxtTypes.Text
  MyFrmSelTypes = New FrmSelTypes
  MyFrmSelTypes.MdiParent = Me.ParentForm
  MyFrmSelTypes.Show()
  Me.Hide()
End Sub
Private Sub FrmTXE03B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFromGLYear, "")
    ErrProv.SetError(TxtToGLYear, "")
    ErrProv.SetError(TxtTypes, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "fromglyear"
        ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
      Case "toglyear"
        ErrProv.SetError(TxtToGLYear, ErrorMsg(I))
      Case "type"
        ErrProv.SetError(TxtTypes, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtFromGLYear.Text) > MyUtils.CnvSng(TxtToGLYear.Text) Then
      ErrorField(I) = "fromglyear"
      ErrorMsg(I) = "Invalid Year Range"
      I = I + 1
      ErrorField(I) = "toglyear"
      ErrorMsg(I) = "Invalid Year Range"
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
Private Sub FrmTXE03B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  MyTypes = ""
  DtPckDue.Value = Now.Date
End Sub
Private Sub TxtFromGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtToGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub LnkBankCd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBankCd.LinkClicked
  MyFrmListBanks = New FrmListBanks
  MyFrmListBanks.MdiParent = Me.ParentForm
  MyFrmListBanks.WrkCode = TxtBankCd.Text
  MyFrmListBanks.Show()
End Sub
End Class






