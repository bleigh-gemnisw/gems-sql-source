Public Class FrmUB401B
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
Friend WithEvents TxtType As System.Windows.Forms.TextBox
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents LnkType As System.Windows.Forms.LinkLabel
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbPaidOff As System.Windows.Forms.RadioButton
Friend WithEvents LnkDistrict As System.Windows.Forms.LinkLabel
Friend WithEvents TxtPhase As System.Windows.Forms.TextBox
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents RbAll As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TxtType = New System.Windows.Forms.TextBox
Me.TxtGLYear = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.LnkType = New System.Windows.Forms.LinkLabel
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.ChkPost = New System.Windows.Forms.CheckBox
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.RbAll = New System.Windows.Forms.RadioButton
Me.RbPaidOff = New System.Windows.Forms.RadioButton
Me.LnkDistrict = New System.Windows.Forms.LinkLabel
Me.TxtPhase = New System.Windows.Forms.TextBox
Me.Label6 = New System.Windows.Forms.Label
Me.TxtDist = New System.Windows.Forms.TextBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox1.SuspendLayout()
Me.SuspendLayout()
'
'TxtType
'
Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtType.Location = New System.Drawing.Point(120, 12)
Me.TxtType.MaxLength = 1
Me.TxtType.Name = "TxtType"
Me.TxtType.Size = New System.Drawing.Size(16, 20)
Me.TxtType.TabIndex = 0
'
'TxtGLYear
'
Me.TxtGLYear.Location = New System.Drawing.Point(120, 40)
Me.TxtGLYear.MaxLength = 4
Me.TxtGLYear.Name = "TxtGLYear"
Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
Me.TxtGLYear.TabIndex = 1
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(28, 44)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(84, 16)
Me.Label4.TabIndex = 11
Me.Label4.Text = "Year to adjust"
'
'LnkType
'
Me.LnkType.Location = New System.Drawing.Point(28, 16)
Me.LnkType.Name = "LnkType"
Me.LnkType.Size = New System.Drawing.Size(80, 16)
Me.LnkType.TabIndex = 17
Me.LnkType.TabStop = True
Me.LnkType.Text = "Type to print"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'ChkPost
'
Me.ChkPost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkPost.Location = New System.Drawing.Point(31, 172)
Me.ChkPost.Name = "ChkPost"
Me.ChkPost.Size = New System.Drawing.Size(124, 20)
Me.ChkPost.TabIndex = 5
Me.ChkPost.Text = "Post to invoice file?"
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.RbAll)
Me.GroupBox1.Controls.Add(Me.RbPaidOff)
Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox1.Location = New System.Drawing.Point(39, 108)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(116, 60)
Me.GroupBox1.TabIndex = 4
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "What Accounts?"
'
'RbAll
'
Me.RbAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbAll.Location = New System.Drawing.Point(12, 36)
Me.RbAll.Name = "RbAll"
Me.RbAll.Size = New System.Drawing.Size(92, 16)
Me.RbAll.TabIndex = 1
Me.RbAll.Text = "All Overpaid"
'
'RbPaidOff
'
Me.RbPaidOff.Checked = True
Me.RbPaidOff.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbPaidOff.Location = New System.Drawing.Point(12, 20)
Me.RbPaidOff.Name = "RbPaidOff"
Me.RbPaidOff.Size = New System.Drawing.Size(92, 16)
Me.RbPaidOff.TabIndex = 0
Me.RbPaidOff.TabStop = True
Me.RbPaidOff.Text = "Paid-off only"
'
'LnkDistrict
'
Me.LnkDistrict.Location = New System.Drawing.Point(28, 70)
Me.LnkDistrict.Name = "LnkDistrict"
Me.LnkDistrict.Size = New System.Drawing.Size(40, 16)
Me.LnkDistrict.TabIndex = 301
Me.LnkDistrict.TabStop = True
Me.LnkDistrict.Text = "District"
'
'TxtPhase
'
Me.TxtPhase.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtPhase.Location = New System.Drawing.Point(208, 66)
Me.TxtPhase.MaxLength = 1
Me.TxtPhase.Name = "TxtPhase"
Me.TxtPhase.Size = New System.Drawing.Size(16, 22)
Me.TxtPhase.TabIndex = 3
'
'Label6
'
Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label6.Location = New System.Drawing.Point(164, 70)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(44, 16)
Me.Label6.TabIndex = 300
Me.Label6.Text = "Phase"
'
'TxtDist
'
Me.TxtDist.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDist.Location = New System.Drawing.Point(120, 66)
Me.TxtDist.MaxLength = 3
Me.TxtDist.Name = "TxtDist"
Me.TxtDist.Size = New System.Drawing.Size(32, 22)
Me.TxtDist.TabIndex = 2
'
'FrmUB401B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(352, 221)
Me.ControlBox = False
Me.Controls.Add(Me.LnkDistrict)
Me.Controls.Add(Me.TxtPhase)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.TxtDist)
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.ChkPost)
Me.Controls.Add(Me.TxtGLYear)
Me.Controls.Add(Me.TxtType)
Me.Controls.Add(Me.LnkType)
Me.Controls.Add(Me.Label4)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmUB401B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox1.ResumeLayout(False)
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmUB401B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB401.SbpScreen.Text = "UB401"
End Sub

Private Sub LnkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkType.LinkClicked
  MyFrmListUBType_Tax = New FrmListUBType_Tax
  MyFrmListUBType_Tax.MdiParent = Me.ParentForm
  MyFrmListUBType_Tax.WrkType = TxtType.Text
  MyFrmListUBType_Tax.Show()
  Me.Hide()
End Sub
Private Sub FrmUB401B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLYear, "")
    ErrProv.SetError(TxtType, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "glyear"
        ErrProv.SetError(TxtGLYear, ErrorMsg(I))
      Case "type"
        ErrProv.SetError(TxtType, ErrorMsg(I))
      Case Nothing
        Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim WrkUBType As String
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtGLYear.Text) = 0 Then
      ErrorField(I) = "glyear"
      ErrorMsg(I) = "Invalid Year"
      I = I + 1
    End If

    If TxtType.Text = "" Then
      ErrorField(I) = "type"
      ErrorMsg(I) = "Type is required"
      I = I + 1
    End If

    WrkUBType = GetUTTypeUBType(TxtType.Text)
    If WrkUBType <> "A" Then
      ErrorField(I) = "type"
      ErrorMsg(I) = "Only Assessment types are valid for this option"
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

    'Reset screen to defaults
    TxtType.Text = ""
    TxtGLYear.Text = ""
    ChkPost.Checked = False
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub TxtGLYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtPhase_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPhase.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub LnkDistrict_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDistrict.LinkClicked
  MyFrmListDist = New FrmListDist
  MyFrmListDist.MdiParent = Me.ParentForm
  MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
  MyFrmListDist.WrkPhase = MyUtils.CnvSng(TxtPhase.Text)
  MyFrmListDist.Show()
  Me.Hide()
End Sub

Private Sub FrmUB401B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

End Sub
End Class






