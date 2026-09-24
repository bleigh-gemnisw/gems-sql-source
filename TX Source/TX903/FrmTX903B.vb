Public Class FrmTX903B
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
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents TxtToGLYear As System.Windows.Forms.TextBox
Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents LnkSusp As System.Windows.Forms.LinkLabel
Friend WithEvents TxtSusp As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label6 = New System.Windows.Forms.Label
Me.TxtToGLYear = New System.Windows.Forms.TextBox
Me.TxtFromGLYear = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.Label7 = New System.Windows.Forms.Label
Me.TxtTypes = New System.Windows.Forms.TextBox
Me.LnkTypes = New System.Windows.Forms.LinkLabel
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.DtPckTo = New System.Windows.Forms.DateTimePicker
Me.Label2 = New System.Windows.Forms.Label
Me.DtPckFrom = New System.Windows.Forms.DateTimePicker
Me.Label1 = New System.Windows.Forms.Label
Me.LnkSusp = New System.Windows.Forms.LinkLabel
Me.TxtSusp = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.Label5 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox1.SuspendLayout()
Me.SuspendLayout()
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(242, 98)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(56, 16)
Me.Label6.TabIndex = 33
Me.Label6.Text = "(Optional)"
'
'TxtToGLYear
'
Me.TxtToGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtToGLYear.Location = New System.Drawing.Point(198, 94)
Me.TxtToGLYear.MaxLength = 4
Me.TxtToGLYear.Name = "TxtToGLYear"
Me.TxtToGLYear.Size = New System.Drawing.Size(36, 20)
Me.TxtToGLYear.TabIndex = 3
'
'TxtFromGLYear
'
Me.TxtFromGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFromGLYear.Location = New System.Drawing.Point(126, 94)
Me.TxtFromGLYear.MaxLength = 4
Me.TxtFromGLYear.Name = "TxtFromGLYear"
Me.TxtFromGLYear.Size = New System.Drawing.Size(36, 20)
Me.TxtFromGLYear.TabIndex = 2
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(174, 98)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(16, 16)
Me.Label4.TabIndex = 32
Me.Label4.Text = "to"
'
'Label7
'
Me.Label7.Location = New System.Drawing.Point(31, 99)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(84, 16)
Me.Label7.TabIndex = 31
Me.Label7.Text = "Grand List Year"
'
'TxtTypes
'
Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtTypes.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtTypes.Location = New System.Drawing.Point(126, 70)
Me.TxtTypes.MaxLength = 20
Me.TxtTypes.Name = "TxtTypes"
Me.TxtTypes.Size = New System.Drawing.Size(148, 20)
Me.TxtTypes.TabIndex = 1
'
'LnkTypes
'
Me.LnkTypes.Location = New System.Drawing.Point(31, 75)
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
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.DtPckTo)
Me.GroupBox1.Controls.Add(Me.Label2)
Me.GroupBox1.Controls.Add(Me.DtPckFrom)
Me.GroupBox1.Controls.Add(Me.Label1)
Me.GroupBox1.Location = New System.Drawing.Point(35, 13)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(289, 48)
Me.GroupBox1.TabIndex = 0
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "Suspense Date Range (Optional)"
'
'DtPckTo
'
Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckTo.Location = New System.Drawing.Point(185, 20)
Me.DtPckTo.Name = "DtPckTo"
Me.DtPckTo.ShowCheckBox = True
Me.DtPckTo.Size = New System.Drawing.Size(98, 20)
Me.DtPckTo.TabIndex = 10
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(150, 24)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(29, 16)
Me.Label2.TabIndex = 9
Me.Label2.Text = "To"
'
'DtPckFrom
'
Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckFrom.Location = New System.Drawing.Point(43, 20)
Me.DtPckFrom.Name = "DtPckFrom"
Me.DtPckFrom.ShowCheckBox = True
Me.DtPckFrom.Size = New System.Drawing.Size(101, 20)
Me.DtPckFrom.TabIndex = 8
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(6, 24)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(40, 16)
Me.Label1.TabIndex = 7
Me.Label1.Text = "From"
'
'LnkSusp
'
Me.LnkSusp.Location = New System.Drawing.Point(31, 122)
Me.LnkSusp.Name = "LnkSusp"
Me.LnkSusp.Size = New System.Drawing.Size(89, 21)
Me.LnkSusp.TabIndex = 239
Me.LnkSusp.TabStop = True
Me.LnkSusp.Text = "Suspense Code"
'
'TxtSusp
'
Me.TxtSusp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtSusp.Location = New System.Drawing.Point(126, 120)
Me.TxtSusp.MaxLength = 1
Me.TxtSusp.Name = "TxtSusp"
Me.TxtSusp.Size = New System.Drawing.Size(16, 20)
Me.TxtSusp.TabIndex = 4
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(148, 122)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(56, 16)
Me.Label3.TabIndex = 240
Me.Label3.Text = "(Optional)"
'
'Label5
'
Me.Label5.Location = New System.Drawing.Point(284, 73)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(56, 16)
Me.Label5.TabIndex = 241
Me.Label5.Text = "(Optional)"
'
'FrmTX903B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(352, 152)
Me.ControlBox = False
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.LnkSusp)
Me.Controls.Add(Me.TxtSusp)
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.TxtTypes)
Me.Controls.Add(Me.LnkTypes)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.TxtToGLYear)
Me.Controls.Add(Me.TxtFromGLYear)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.Label7)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX903B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox1.ResumeLayout(False)
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTX903B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX903.SbpScreen.Text = "TX903"
End Sub
Private Sub FrmTX903B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
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
Private Sub FrmTX903B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  MyTypes = ""
  DtPckFrom.Value = Date.Today
  DtPckFrom.Checked = False
  DtPckTo.Value = Date.Today
  DtPckTo.Checked = False
End Sub
Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
  MyTypes = TxtTypes.Text
  MyFrmSelTypes = New FrmSelTypes
  MyFrmSelTypes.MdiParent = Me.ParentForm
  MyFrmSelTypes.Show()
  Me.Hide()

End Sub
Private Sub LnkSusp_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkSusp.LinkClicked
    MyFrmListSResn = New FrmListSResn
    MyFrmListSResn.MdiParent = Me.ParentForm
    MyFrmListSResn.WrkCode = TxtSusp.Text
    MyFrmListSResn.Show()
End Sub
End Class






