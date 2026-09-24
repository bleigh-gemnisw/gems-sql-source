Public Class FrmTX902B
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
Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
Friend WithEvents GrpSorting As System.Windows.Forms.GroupBox
Friend WithEvents RbSortYear As System.Windows.Forms.RadioButton
Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
Friend WithEvents ChkMail As System.Windows.Forms.CheckBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
Friend WithEvents LnkStatus4 As System.Windows.Forms.LinkLabel
Friend WithEvents TxtStatus4 As System.Windows.Forms.TextBox
Friend WithEvents LnkStatus3 As System.Windows.Forms.LinkLabel
Friend WithEvents TxtStatus3 As System.Windows.Forms.TextBox
Friend WithEvents LnkStatus2 As System.Windows.Forms.LinkLabel
Friend WithEvents TxtStatus2 As System.Windows.Forms.TextBox
Friend WithEvents LnkStatus1 As System.Windows.Forms.LinkLabel
Friend WithEvents TxtStatus1 As System.Windows.Forms.TextBox
Friend WithEvents LnkSusp As System.Windows.Forms.LinkLabel
Friend WithEvents TxtSusp As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents DtPckPost As System.Windows.Forms.DateTimePicker
Friend WithEvents ChkBatch As System.Windows.Forms.CheckBox
Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
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
Me.GrpSorting = New System.Windows.Forms.GroupBox
Me.RbSortYear = New System.Windows.Forms.RadioButton
Me.RbSortName = New System.Windows.Forms.RadioButton
Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ChkMail = New System.Windows.Forms.CheckBox
Me.GroupBox4 = New System.Windows.Forms.GroupBox
Me.LnkStatus4 = New System.Windows.Forms.LinkLabel
Me.TxtStatus4 = New System.Windows.Forms.TextBox
Me.LnkStatus3 = New System.Windows.Forms.LinkLabel
Me.TxtStatus3 = New System.Windows.Forms.TextBox
Me.LnkStatus2 = New System.Windows.Forms.LinkLabel
Me.TxtStatus2 = New System.Windows.Forms.TextBox
Me.LnkStatus1 = New System.Windows.Forms.LinkLabel
Me.TxtStatus1 = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.ChkBatch = New System.Windows.Forms.CheckBox
Me.DtPckPost = New System.Windows.Forms.DateTimePicker
Me.Label1 = New System.Windows.Forms.Label
Me.TxtSusp = New System.Windows.Forms.TextBox
Me.LnkSusp = New System.Windows.Forms.LinkLabel
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GrpSorting.SuspendLayout()
Me.GroupBox4.SuspendLayout()
Me.SuspendLayout()
'
'TxtTypes
'
Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtTypes.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtTypes.Location = New System.Drawing.Point(128, 18)
Me.TxtTypes.MaxLength = 20
Me.TxtTypes.Name = "TxtTypes"
Me.TxtTypes.Size = New System.Drawing.Size(148, 20)
Me.TxtTypes.TabIndex = 0
'
'TxtFromGLYear
'
Me.TxtFromGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFromGLYear.Location = New System.Drawing.Point(132, 185)
Me.TxtFromGLYear.MaxLength = 4
Me.TxtFromGLYear.Name = "TxtFromGLYear"
Me.TxtFromGLYear.Size = New System.Drawing.Size(36, 20)
Me.TxtFromGLYear.TabIndex = 2
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(33, 189)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(84, 16)
Me.Label4.TabIndex = 11
Me.Label4.Text = "Grand List Year"
'
'LnkTypes
'
Me.LnkTypes.Location = New System.Drawing.Point(32, 22)
Me.LnkTypes.Name = "LnkTypes"
Me.LnkTypes.Size = New System.Drawing.Size(85, 16)
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
Me.TxtToGLYear.Location = New System.Drawing.Point(196, 185)
Me.TxtToGLYear.MaxLength = 4
Me.TxtToGLYear.Name = "TxtToGLYear"
Me.TxtToGLYear.Size = New System.Drawing.Size(36, 20)
Me.TxtToGLYear.TabIndex = 3
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(172, 189)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(16, 16)
Me.Label3.TabIndex = 19
Me.Label3.Text = "to"
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(240, 189)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(56, 16)
Me.Label6.TabIndex = 28
Me.Label6.Text = "(Optional)"
'
'GrpSorting
'
Me.GrpSorting.Controls.Add(Me.RbSortYear)
Me.GrpSorting.Controls.Add(Me.RbSortName)
Me.GrpSorting.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GrpSorting.ForeColor = System.Drawing.Color.Maroon
Me.GrpSorting.Location = New System.Drawing.Point(334, 12)
Me.GrpSorting.Name = "GrpSorting"
Me.GrpSorting.Size = New System.Drawing.Size(132, 64)
Me.GrpSorting.TabIndex = 8
Me.GrpSorting.TabStop = False
Me.GrpSorting.Text = "Sort Order"
'
'RbSortYear
'
Me.RbSortYear.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbSortYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbSortYear.ForeColor = System.Drawing.SystemColors.ControlText
Me.RbSortYear.Location = New System.Drawing.Point(8, 40)
Me.RbSortYear.Name = "RbSortYear"
Me.RbSortYear.Size = New System.Drawing.Size(120, 20)
Me.RbSortYear.TabIndex = 0
Me.RbSortYear.Text = "Year/Type"
'
'RbSortName
'
Me.RbSortName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbSortName.Checked = True
Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbSortName.ForeColor = System.Drawing.SystemColors.ControlText
Me.RbSortName.Location = New System.Drawing.Point(8, 16)
Me.RbSortName.Name = "RbSortName"
Me.RbSortName.Size = New System.Drawing.Size(120, 20)
Me.RbSortName.TabIndex = 1
Me.RbSortName.TabStop = True
Me.RbSortName.Text = "Name"
'
'ChkMail
'
Me.ChkMail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkMail.Checked = True
Me.ChkMail.CheckState = System.Windows.Forms.CheckState.Checked
Me.ChkMail.Location = New System.Drawing.Point(36, 216)
Me.ChkMail.Name = "ChkMail"
Me.ChkMail.Size = New System.Drawing.Size(122, 16)
Me.ChkMail.TabIndex = 4
Me.ChkMail.Text = "Mail Returns only?"
'
'GroupBox4
'
Me.GroupBox4.Controls.Add(Me.LnkStatus4)
Me.GroupBox4.Controls.Add(Me.TxtStatus4)
Me.GroupBox4.Controls.Add(Me.LnkStatus3)
Me.GroupBox4.Controls.Add(Me.TxtStatus3)
Me.GroupBox4.Controls.Add(Me.LnkStatus2)
Me.GroupBox4.Controls.Add(Me.TxtStatus2)
Me.GroupBox4.Controls.Add(Me.LnkStatus1)
Me.GroupBox4.Controls.Add(Me.TxtStatus1)
Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox4.Location = New System.Drawing.Point(31, 52)
Me.GroupBox4.Name = "GroupBox4"
Me.GroupBox4.Size = New System.Drawing.Size(127, 116)
Me.GroupBox4.TabIndex = 1
Me.GroupBox4.TabStop = False
Me.GroupBox4.Text = "Status Codes"
'
'LnkStatus4
'
Me.LnkStatus4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkStatus4.Location = New System.Drawing.Point(6, 89)
Me.LnkStatus4.Name = "LnkStatus4"
Me.LnkStatus4.Size = New System.Drawing.Size(81, 16)
Me.LnkStatus4.TabIndex = 59
Me.LnkStatus4.TabStop = True
Me.LnkStatus4.Text = "Status Code 4"
'
'TxtStatus4
'
Me.TxtStatus4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtStatus4.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtStatus4.Location = New System.Drawing.Point(103, 85)
Me.TxtStatus4.MaxLength = 1
Me.TxtStatus4.Name = "TxtStatus4"
Me.TxtStatus4.Size = New System.Drawing.Size(17, 20)
Me.TxtStatus4.TabIndex = 58
'
'LnkStatus3
'
Me.LnkStatus3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkStatus3.Location = New System.Drawing.Point(6, 67)
Me.LnkStatus3.Name = "LnkStatus3"
Me.LnkStatus3.Size = New System.Drawing.Size(81, 16)
Me.LnkStatus3.TabIndex = 57
Me.LnkStatus3.TabStop = True
Me.LnkStatus3.Text = "Status Code 3"
'
'TxtStatus3
'
Me.TxtStatus3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtStatus3.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtStatus3.Location = New System.Drawing.Point(103, 63)
Me.TxtStatus3.MaxLength = 1
Me.TxtStatus3.Name = "TxtStatus3"
Me.TxtStatus3.Size = New System.Drawing.Size(17, 20)
Me.TxtStatus3.TabIndex = 56
'
'LnkStatus2
'
Me.LnkStatus2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkStatus2.Location = New System.Drawing.Point(6, 45)
Me.LnkStatus2.Name = "LnkStatus2"
Me.LnkStatus2.Size = New System.Drawing.Size(81, 16)
Me.LnkStatus2.TabIndex = 55
Me.LnkStatus2.TabStop = True
Me.LnkStatus2.Text = "Status Code 2"
'
'TxtStatus2
'
Me.TxtStatus2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtStatus2.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtStatus2.Location = New System.Drawing.Point(103, 41)
Me.TxtStatus2.MaxLength = 1
Me.TxtStatus2.Name = "TxtStatus2"
Me.TxtStatus2.Size = New System.Drawing.Size(17, 20)
Me.TxtStatus2.TabIndex = 54
'
'LnkStatus1
'
Me.LnkStatus1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkStatus1.Location = New System.Drawing.Point(6, 23)
Me.LnkStatus1.Name = "LnkStatus1"
Me.LnkStatus1.Size = New System.Drawing.Size(81, 16)
Me.LnkStatus1.TabIndex = 53
Me.LnkStatus1.TabStop = True
Me.LnkStatus1.Text = "Status Code 1"
'
'TxtStatus1
'
Me.TxtStatus1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtStatus1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtStatus1.Location = New System.Drawing.Point(103, 19)
Me.TxtStatus1.MaxLength = 1
Me.TxtStatus1.Name = "TxtStatus1"
Me.TxtStatus1.Size = New System.Drawing.Size(17, 20)
Me.TxtStatus1.TabIndex = 52
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(172, 97)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(56, 17)
Me.Label2.TabIndex = 241
Me.Label2.Text = "(Optional)"
'
'ChkBatch
'
Me.ChkBatch.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkBatch.Checked = True
Me.ChkBatch.CheckState = System.Windows.Forms.CheckState.Checked
Me.ChkBatch.Location = New System.Drawing.Point(35, 302)
Me.ChkBatch.Name = "ChkBatch"
Me.ChkBatch.Size = New System.Drawing.Size(122, 16)
Me.ChkBatch.TabIndex = 7
Me.ChkBatch.Text = "Create Batch?"
'
'DtPckPost
'
Me.DtPckPost.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckPost.Location = New System.Drawing.Point(131, 271)
Me.DtPckPost.Name = "DtPckPost"
Me.DtPckPost.Size = New System.Drawing.Size(88, 20)
Me.DtPckPost.TabIndex = 6
Me.DtPckPost.Value = New Date(2006, 9, 25, 0, 0, 0, 0)
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(34, 275)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(84, 16)
Me.Label1.TabIndex = 30
Me.Label1.Text = "Posting Date"
'
'TxtSusp
'
Me.TxtSusp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtSusp.Location = New System.Drawing.Point(131, 245)
Me.TxtSusp.MaxLength = 1
Me.TxtSusp.Name = "TxtSusp"
Me.TxtSusp.Size = New System.Drawing.Size(16, 20)
Me.TxtSusp.TabIndex = 5
Me.TxtSusp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'LnkSusp
'
Me.LnkSusp.Location = New System.Drawing.Point(35, 248)
Me.LnkSusp.Name = "LnkSusp"
Me.LnkSusp.Size = New System.Drawing.Size(89, 21)
Me.LnkSusp.TabIndex = 239
Me.LnkSusp.TabStop = True
Me.LnkSusp.Text = "Suspense Code"
'
'FrmTX902B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(478, 330)
Me.ControlBox = False
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.GroupBox4)
Me.Controls.Add(Me.ChkMail)
Me.Controls.Add(Me.LnkSusp)
Me.Controls.Add(Me.TxtSusp)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.DtPckPost)
Me.Controls.Add(Me.GrpSorting)
Me.Controls.Add(Me.ChkBatch)
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
Me.Name = "FrmTX902B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GrpSorting.ResumeLayout(False)
Me.GroupBox4.ResumeLayout(False)
Me.GroupBox4.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTX902B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX902.SbpScreen.Text = "TX902"
End Sub

Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
  MyTypes = TxtTypes.Text
  MyFrmSelTypes = New FrmSelTypes
  MyFrmSelTypes.MdiParent = Me.ParentForm
  MyFrmSelTypes.Show()
  Me.Hide()
End Sub
Private Sub FrmTX902B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFromGLYear, "")
    ErrProv.SetError(TxtToGLYear, "")
    ErrProv.SetError(TxtSusp, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "fromglyear"
        ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
      Case "toglyear"
        ErrProv.SetError(TxtToGLYear, ErrorMsg(I))
      Case "susp"
        ErrProv.SetError(TxtSusp, ErrorMsg(I))
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

    If TxtSusp.Text = "" Then
      ErrorField(I) = "susp"
      ErrorMsg(I) = "Suspense Reason is required"
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

Private Sub FrmTX902B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
   MyTypes = ""
   DtPckPost.Value = Date.Today
End Sub
Private Sub LnkStatus1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkStatus1.LinkClicked
  MyFrmListSts = New FrmListSts
  MyFrmListSts.WrkCode = TxtStatus1.Text
  MyFrmListSts.WrkFieldNo = 1
  MyFrmListSts.MdiParent = Me.ParentForm
  MyFrmListSts.Show()
End Sub
Private Sub LnkStatus2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkStatus2.LinkClicked
  MyFrmListSts = New FrmListSts
  MyFrmListSts.WrkCode = TxtStatus2.Text
  MyFrmListSts.WrkFieldNo = 2
  MyFrmListSts.MdiParent = Me.ParentForm
  MyFrmListSts.Show()
End Sub
Private Sub LnkStatus3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkStatus3.LinkClicked
  MyFrmListSts = New FrmListSts
  MyFrmListSts.WrkCode = TxtStatus3.Text
  MyFrmListSts.WrkFieldNo = 3
  MyFrmListSts.MdiParent = Me.ParentForm
  MyFrmListSts.Show()
End Sub
Private Sub LnkStatus4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkStatus4.LinkClicked
  MyFrmListSts = New FrmListSts
  MyFrmListSts.WrkCode = TxtStatus4.Text
  MyFrmListSts.WrkFieldNo = 4
  MyFrmListSts.MdiParent = Me.ParentForm
  MyFrmListSts.Show()
End Sub
Private Sub LnkSusp_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkSusp.LinkClicked
    MyFrmListSResn = New FrmListSResn
    MyFrmListSResn.MdiParent = Me.ParentForm
    MyFrmListSResn.WrkCode = TxtSusp.Text
    MyFrmListSResn.Show()
End Sub
Private Sub TxtFromGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtToGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

End Sub
End Class






