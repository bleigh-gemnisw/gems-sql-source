Public Class FrmBD200B
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
  Friend WithEvents LnkType As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtType As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents ChkCredit As System.Windows.Forms.CheckBox
  Friend WithEvents ChkCheck As System.Windows.Forms.CheckBox
  Friend WithEvents ChkCash As System.Windows.Forms.CheckBox
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.LnkType = New System.Windows.Forms.LinkLabel()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.ChkCash = New System.Windows.Forms.CheckBox()
    Me.ChkCheck = New System.Windows.Forms.CheckBox()
    Me.ChkCredit = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
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
    Me.DtPckFrom.TabIndex = 4
    '
    'DtPckTo
    '
    Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTo.Location = New System.Drawing.Point(239, 12)
    Me.DtPckTo.Name = "DtPckTo"
    Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
    Me.DtPckTo.TabIndex = 6
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
    'LnkType
    '
    Me.LnkType.AutoSize = True
    Me.LnkType.Location = New System.Drawing.Point(19, 47)
    Me.LnkType.Name = "LnkType"
    Me.LnkType.Size = New System.Drawing.Size(63, 13)
    Me.LnkType.TabIndex = 36
    Me.LnkType.TabStop = True
    Me.LnkType.Text = "Permit Type"
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Location = New System.Drawing.Point(103, 44)
    Me.TxtType.MaxLength = 5
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(56, 20)
    Me.TxtType.TabIndex = 37
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(58, 110)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(211, 13)
    Me.Label3.TabIndex = 38
    Me.Label3.Text = "PENDING permits are NOT included"
    '
    'ChkCash
    '
    Me.ChkCash.AutoSize = True
    Me.ChkCash.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkCash.Checked = True
    Me.ChkCash.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkCash.Location = New System.Drawing.Point(24, 77)
    Me.ChkCash.Name = "ChkCash"
    Me.ChkCash.Size = New System.Drawing.Size(50, 17)
    Me.ChkCash.TabIndex = 39
    Me.ChkCash.Text = "Cash"
    Me.ChkCash.UseVisualStyleBackColor = True
    '
    'ChkCheck
    '
    Me.ChkCheck.AutoSize = True
    Me.ChkCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkCheck.Checked = True
    Me.ChkCheck.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkCheck.Location = New System.Drawing.Point(103, 77)
    Me.ChkCheck.Name = "ChkCheck"
    Me.ChkCheck.Size = New System.Drawing.Size(57, 17)
    Me.ChkCheck.TabIndex = 40
    Me.ChkCheck.Text = "Check"
    Me.ChkCheck.UseVisualStyleBackColor = True
    '
    'ChkCredit
    '
    Me.ChkCredit.AutoSize = True
    Me.ChkCredit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkCredit.Checked = True
    Me.ChkCredit.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkCredit.Location = New System.Drawing.Point(186, 77)
    Me.ChkCredit.Name = "ChkCredit"
    Me.ChkCredit.Size = New System.Drawing.Size(53, 17)
    Me.ChkCredit.TabIndex = 41
    Me.ChkCredit.Text = "Credit"
    Me.ChkCredit.UseVisualStyleBackColor = True
    '
    'FrmBD200B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(345, 141)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkCredit)
    Me.Controls.Add(Me.ChkCheck)
    Me.Controls.Add(Me.ChkCash)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.LnkType)
    Me.Controls.Add(Me.TxtType)
    Me.Controls.Add(Me.DtPckTo)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.DtPckFrom)
    Me.Controls.Add(Me.Label1)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmBD200B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmBD200B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmBD200.SbpScreen.Text = "BD200"
End Sub
Private Sub FrmBD200B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtType, "")

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
Private Sub FrmBD200B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  MyTypes = ""
End Sub
Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
  MyTypes = TxtType.Text
  MyFrmListTypes = New FrmListTypes
  MyFrmListTypes.MdiParent = Me.ParentForm
  MyFrmListTypes.Show()
  Me.Hide()

End Sub
Private Sub TxtFromGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtToGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub LnkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkType.LinkClicked
  MyFrmListTypes = New FrmListTypes
  MyFrmListTypes.MdiParent = Me.ParentForm
  MyFrmListTypes.WrkType = TxtType.Text
  MyFrmListTypes.Show()
  Me.Hide()
End Sub
End Class






