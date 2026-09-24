Public Class FrmTXA05B
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
Friend WithEvents ChkBatch As System.Windows.Forms.CheckBox
Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
Friend WithEvents GrpSorting As System.Windows.Forms.GroupBox
Friend WithEvents RbSortYear As System.Windows.Forms.RadioButton
Friend WithEvents TxtOver As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtUnder As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtTypes = New System.Windows.Forms.TextBox()
    Me.TxtFromGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.LnkTypes = New System.Windows.Forms.LinkLabel()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtToGLYear = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.ChkBatch = New System.Windows.Forms.CheckBox()
    Me.GrpSorting = New System.Windows.Forms.GroupBox()
    Me.RbSortYear = New System.Windows.Forms.RadioButton()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
    Me.TxtUnder = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtOver = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpSorting.SuspendLayout()
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
    Me.TxtFromGLYear.Location = New System.Drawing.Point(128, 93)
    Me.TxtFromGLYear.MaxLength = 4
    Me.TxtFromGLYear.Name = "TxtFromGLYear"
    Me.TxtFromGLYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtFromGLYear.TabIndex = 3
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(36, 97)
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
    Me.TxtToGLYear.Location = New System.Drawing.Point(192, 93)
    Me.TxtToGLYear.MaxLength = 4
    Me.TxtToGLYear.Name = "TxtToGLYear"
    Me.TxtToGLYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtToGLYear.TabIndex = 4
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(168, 97)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(16, 16)
    Me.Label3.TabIndex = 19
    Me.Label3.Text = "to"
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(236, 97)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(56, 16)
    Me.Label6.TabIndex = 28
    Me.Label6.Text = "(Optional)"
    '
    'ChkBatch
    '
    Me.ChkBatch.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkBatch.Location = New System.Drawing.Point(39, 150)
    Me.ChkBatch.Name = "ChkBatch"
    Me.ChkBatch.Size = New System.Drawing.Size(104, 16)
    Me.ChkBatch.TabIndex = 5
    Me.ChkBatch.Text = "Create Batch?"
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
    Me.GrpSorting.TabIndex = 6
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
    'TxtUnder
    '
    Me.TxtUnder.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnder.Location = New System.Drawing.Point(260, 37)
    Me.TxtUnder.MaxLength = 6
    Me.TxtUnder.Name = "TxtUnder"
    Me.TxtUnder.Size = New System.Drawing.Size(44, 20)
    Me.TxtUnder.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(36, 40)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(206, 17)
    Me.Label1.TabIndex = 32
    Me.Label1.Text = "Include balances less than or equal to"
    '
    'TxtOver
    '
    Me.TxtOver.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOver.Location = New System.Drawing.Point(260, 67)
    Me.TxtOver.MaxLength = 6
    Me.TxtOver.Name = "TxtOver"
    Me.TxtOver.Size = New System.Drawing.Size(44, 20)
    Me.TxtOver.TabIndex = 2
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(36, 70)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(232, 17)
    Me.Label2.TabIndex = 34
    Me.Label2.Text = "Include overpayments less than or equal to"
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(36, 122)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(84, 16)
    Me.Label5.TabIndex = 35
    Me.Label5.Text = "List Number"
    '
    'TxtListNo
    '
    Me.TxtListNo.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtListNo.Location = New System.Drawing.Point(126, 119)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(64, 20)
    Me.TxtListNo.TabIndex = 36
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(212, 122)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(56, 16)
    Me.Label7.TabIndex = 37
    Me.Label7.Text = "(Optional)"
    '
    'FrmTXA05B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(478, 178)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TxtListNo)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtOver)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtUnder)
    Me.Controls.Add(Me.Label1)
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
    Me.Name = "FrmTXA05B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpSorting.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

Private Sub FrmTXA05B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTXA05.SbpScreen.Text = "TXA05"
End Sub

Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
  MyTypes = TxtTypes.Text
  MyFrmSelTypes = New FrmSelTypes
  MyFrmSelTypes.MdiParent = Me.ParentForm
  MyFrmSelTypes.Show()
  Me.Hide()
End Sub
Private Sub FrmTXA05B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFromGLYear, "")
    ErrProv.SetError(TxtToGLYear, "")
    ErrProv.SetError(TxtTypes, "")
    ErrProv.SetError(TxtUnder, "")
    ErrProv.SetError(TxtOver, "")
    ErrProv.SetError(TxtListNo, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "fromglyear"
        ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
      Case "toglyear"
        ErrProv.SetError(TxtToGLYear, ErrorMsg(I))
      Case "type"
        ErrProv.SetError(TxtTypes, ErrorMsg(I))
      Case "under"
        ErrProv.SetError(TxtUnder, ErrorMsg(I))
      Case "over"
        ErrProv.SetError(TxtOver, ErrorMsg(I))
      Case "listno"
        ErrProv.SetError(TxtListNo, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtFromGLYear.Text) > MyUtils.CnvSng(TxtToGLYear.Text) And TxtListNo.Text = "" Then
      ErrorField(I) = "fromglyear"
      ErrorMsg(I) = "Invalid Year Range"
      I = I + 1
      ErrorField(I) = "toglyear"
      ErrorMsg(I) = "Invalid Year Range"
      I = I + 1
    End If

    If TxtOver.Text = "" And TxtUnder.Text = "" And TxtListNo.Text = "" Then
      ErrorField(I) = "under"
      ErrorMsg(I) = "Either Under or Over amount is required"
      I = I + 1
      ErrorField(I) = "over"
      ErrorMsg(I) = "Either Under or Over amount is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtListNo.Text) > 0 Then
     If MyUtils.CnvSng(TxtFromGLYear.Text) = 0 Or TxtTypes.Text = "" Then
      ErrorField(I) = "listno"
      ErrorMsg(I) = "Type and From Year are required"
      I = I + 1
     End If
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

Private Sub FrmTXA05B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
   MyTypes = ""
End Sub
Private Sub TxtUnder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUnder.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtOver_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOver.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtFromGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtToGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






