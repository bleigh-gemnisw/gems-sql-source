Public Class FrmTXE04B
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
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents TxtToGLYear As System.Windows.Forms.TextBox
Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents ChkSuspense As System.Windows.Forms.CheckBox
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents ChkLetter As System.Windows.Forms.CheckBox
Friend WithEvents DtPckAsof As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.DtPckAsof = New System.Windows.Forms.DateTimePicker
Me.Label6 = New System.Windows.Forms.Label
Me.TxtToGLYear = New System.Windows.Forms.TextBox
Me.TxtFromGLYear = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.Label7 = New System.Windows.Forms.Label
Me.TxtTypes = New System.Windows.Forms.TextBox
Me.LnkTypes = New System.Windows.Forms.LinkLabel
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.ChkSuspense = New System.Windows.Forms.CheckBox
Me.TxtDist = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
Me.ChkLetter = New System.Windows.Forms.CheckBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(32, 12)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(60, 16)
Me.Label1.TabIndex = 0
Me.Label1.Text = "As of Date"
'
'DtPckAsof
'
Me.DtPckAsof.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckAsof.Location = New System.Drawing.Point(92, 8)
Me.DtPckAsof.Name = "DtPckAsof"
Me.DtPckAsof.Size = New System.Drawing.Size(88, 20)
Me.DtPckAsof.TabIndex = 0
Me.DtPckAsof.Value = New Date(2006, 9, 25, 0, 0, 0, 0)
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(232, 40)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(56, 16)
Me.Label6.TabIndex = 33
Me.Label6.Text = "(Optional)"
'
'TxtToGLYear
'
Me.TxtToGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtToGLYear.Location = New System.Drawing.Point(188, 36)
Me.TxtToGLYear.MaxLength = 4
Me.TxtToGLYear.Name = "TxtToGLYear"
Me.TxtToGLYear.Size = New System.Drawing.Size(36, 20)
Me.TxtToGLYear.TabIndex = 2
'
'TxtFromGLYear
'
Me.TxtFromGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFromGLYear.Location = New System.Drawing.Point(116, 36)
Me.TxtFromGLYear.MaxLength = 4
Me.TxtFromGLYear.Name = "TxtFromGLYear"
Me.TxtFromGLYear.Size = New System.Drawing.Size(36, 20)
Me.TxtFromGLYear.TabIndex = 1
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(164, 40)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(16, 16)
Me.Label4.TabIndex = 32
Me.Label4.Text = "to"
'
'Label7
'
Me.Label7.Location = New System.Drawing.Point(32, 40)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(84, 16)
Me.Label7.TabIndex = 31
Me.Label7.Text = "Grand List Year"
'
'TxtTypes
'
Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtTypes.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtTypes.Location = New System.Drawing.Point(116, 60)
Me.TxtTypes.MaxLength = 20
Me.TxtTypes.Name = "TxtTypes"
Me.TxtTypes.Size = New System.Drawing.Size(148, 20)
Me.TxtTypes.TabIndex = 3
'
'LnkTypes
'
Me.LnkTypes.Location = New System.Drawing.Point(32, 64)
Me.LnkTypes.Name = "LnkTypes"
Me.LnkTypes.Size = New System.Drawing.Size(80, 16)
Me.LnkTypes.TabIndex = 35
Me.LnkTypes.TabStop = True
Me.LnkTypes.Text = "Types to print"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'ChkSuspense
'
Me.ChkSuspense.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkSuspense.Location = New System.Drawing.Point(32, 88)
Me.ChkSuspense.Name = "ChkSuspense"
Me.ChkSuspense.Size = New System.Drawing.Size(120, 16)
Me.ChkSuspense.TabIndex = 4
Me.ChkSuspense.Text = "Suspense?"
'
'TxtDist
'
Me.TxtDist.Location = New System.Drawing.Point(116, 131)
Me.TxtDist.MaxLength = 4
Me.TxtDist.Name = "TxtDist"
Me.TxtDist.Size = New System.Drawing.Size(32, 20)
Me.TxtDist.TabIndex = 6
'
'Label5
'
Me.Label5.Location = New System.Drawing.Point(32, 134)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(70, 17)
Me.Label5.TabIndex = 37
Me.Label5.Text = "District"
'
'ChkLetter
'
Me.ChkLetter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkLetter.Location = New System.Drawing.Point(32, 110)
Me.ChkLetter.Name = "ChkLetter"
Me.ChkLetter.Size = New System.Drawing.Size(120, 15)
Me.ChkLetter.TabIndex = 5
Me.ChkLetter.Text = "Print Letter Totals?"
'
'FrmTXE04B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(340, 163)
Me.ControlBox = False
Me.Controls.Add(Me.ChkLetter)
Me.Controls.Add(Me.TxtDist)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.ChkSuspense)
Me.Controls.Add(Me.TxtTypes)
Me.Controls.Add(Me.LnkTypes)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.TxtToGLYear)
Me.Controls.Add(Me.TxtFromGLYear)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.Label7)
Me.Controls.Add(Me.DtPckAsof)
Me.Controls.Add(Me.Label1)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTXE04B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTXE04B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTXE04.SbpScreen.Text = "TXE04"
End Sub
Private Sub FrmTXE04B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
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
Private Sub FrmTXE04B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  MyTypes = ""
  DtPckAsof.Value = Today.Date
End Sub

Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
  MyTypes = TxtTypes.Text
  MyFrmSelTypes = New FrmSelTypes
  MyFrmSelTypes.MdiParent = Me.ParentForm
  MyFrmSelTypes.Show()
  Me.Hide()

End Sub
Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






