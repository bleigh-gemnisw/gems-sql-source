Public Class FrmBD202B
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
  Friend WithEvents LnkType As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtType As System.Windows.Forms.TextBox
  Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents RbSortDate As System.Windows.Forms.RadioButton
  Friend WithEvents RbSortLoc As System.Windows.Forms.RadioButton
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.LnkType = New System.Windows.Forms.LinkLabel()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbSortDate = New System.Windows.Forms.RadioButton()
    Me.RbSortLoc = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LnkType
    '
    Me.LnkType.Location = New System.Drawing.Point(11, 46)
    Me.LnkType.Name = "LnkType"
    Me.LnkType.Size = New System.Drawing.Size(78, 16)
    Me.LnkType.TabIndex = 36
    Me.LnkType.TabStop = True
    Me.LnkType.Text = "Permit Type"
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Location = New System.Drawing.Point(95, 43)
    Me.TxtType.MaxLength = 5
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(56, 20)
    Me.TxtType.TabIndex = 37
    '
    'DtPckTo
    '
    Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTo.Location = New System.Drawing.Point(231, 14)
    Me.DtPckTo.Name = "DtPckTo"
    Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
    Me.DtPckTo.TabIndex = 41
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(179, 18)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(52, 16)
    Me.Label2.TabIndex = 40
    Me.Label2.Text = "To Date"
    '
    'DtPckFrom
    '
    Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFrom.Location = New System.Drawing.Point(71, 14)
    Me.DtPckFrom.Name = "DtPckFrom"
    Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
    Me.DtPckFrom.TabIndex = 39
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(11, 18)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(60, 16)
    Me.Label1.TabIndex = 38
    Me.Label1.Text = "From Date"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbSortDate)
    Me.GroupBox2.Controls.Add(Me.RbSortLoc)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(336, 12)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(127, 62)
    Me.GroupBox2.TabIndex = 42
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Sort Options"
    '
    'RbSortDate
    '
    Me.RbSortDate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortDate.Checked = True
    Me.RbSortDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortDate.Location = New System.Drawing.Point(6, 16)
    Me.RbSortDate.Name = "RbSortDate"
    Me.RbSortDate.Size = New System.Drawing.Size(115, 20)
    Me.RbSortDate.TabIndex = 0
    Me.RbSortDate.TabStop = True
    Me.RbSortDate.Text = "Date/Name"
    '
    'RbSortLoc
    '
    Me.RbSortLoc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortLoc.Location = New System.Drawing.Point(6, 36)
    Me.RbSortLoc.Name = "RbSortLoc"
    Me.RbSortLoc.Size = New System.Drawing.Size(115, 20)
    Me.RbSortLoc.TabIndex = 1
    Me.RbSortLoc.Text = "Location"
    '
    'FrmBD202B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(475, 83)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.DtPckTo)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.DtPckFrom)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LnkType)
    Me.Controls.Add(Me.TxtType)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmBD202B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmBD202B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmBD202.SbpScreen.Text = "BD202"
End Sub
Private Sub FrmBD202B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
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
Private Sub FrmBD202B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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






