Public Class FrmTA440B
Inherits System.Windows.Forms.Form
  Dim WrkClassDesc As String

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
    Friend WithEvents LnkFromClass As System.Windows.Forms.LinkLabel
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RbSortList As System.Windows.Forms.RadioButton
    Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
  Friend WithEvents TxtMake As TextBox
  Friend WithEvents Label1 As Label
  Friend WithEvents TxtGross As TextBox
  Friend WithEvents Label2 As Label
  Friend WithEvents ChkZero As CheckBox
    Friend WithEvents RbSortMake As RadioButton

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents TxtClass As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtClass = New System.Windows.Forms.TextBox()
    Me.LnkFromClass = New System.Windows.Forms.LinkLabel()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.RbSortMake = New System.Windows.Forms.RadioButton()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
    Me.RbSortList = New System.Windows.Forms.RadioButton()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtMake = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtGross = New System.Windows.Forms.TextBox()
    Me.ChkZero = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox3.SuspendLayout()
    Me.SuspendLayout()
    '
    'TxtClass
    '
    Me.TxtClass.Location = New System.Drawing.Point(101, 33)
    Me.TxtClass.MaxLength = 2
    Me.TxtClass.Name = "TxtClass"
    Me.TxtClass.Size = New System.Drawing.Size(25, 20)
    Me.TxtClass.TabIndex = 0
    '
    'LnkFromClass
    '
    Me.LnkFromClass.AutoSize = True
    Me.LnkFromClass.Location = New System.Drawing.Point(63, 36)
    Me.LnkFromClass.Name = "LnkFromClass"
    Me.LnkFromClass.Size = New System.Drawing.Size(32, 13)
    Me.LnkFromClass.TabIndex = 8
    Me.LnkFromClass.TabStop = True
    Me.LnkFromClass.Text = "Class"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.RbSortMake)
    Me.GroupBox3.Controls.Add(Me.RbSortName)
    Me.GroupBox3.Controls.Add(Me.RbSortList)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(284, 12)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(162, 94)
    Me.GroupBox3.TabIndex = 4
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Sort Order"
    '
    'RbSortMake
    '
    Me.RbSortMake.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortMake.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortMake.Location = New System.Drawing.Point(12, 65)
    Me.RbSortMake.Name = "RbSortMake"
    Me.RbSortMake.Size = New System.Drawing.Size(144, 20)
    Me.RbSortMake.TabIndex = 5
    Me.RbSortMake.Text = "Make"
    '
    'RbSortName
    '
    Me.RbSortName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortName.Checked = True
    Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortName.Location = New System.Drawing.Point(12, 43)
    Me.RbSortName.Name = "RbSortName"
    Me.RbSortName.Size = New System.Drawing.Size(144, 20)
    Me.RbSortName.TabIndex = 4
    Me.RbSortName.TabStop = True
    Me.RbSortName.Text = "Name"
    '
    'RbSortList
    '
    Me.RbSortList.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortList.Location = New System.Drawing.Point(12, 20)
    Me.RbSortList.Name = "RbSortList"
    Me.RbSortList.Size = New System.Drawing.Size(144, 20)
    Me.RbSortList.TabIndex = 3
    Me.RbSortList.Text = "List Number"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(146, 36)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(34, 13)
    Me.Label1.TabIndex = 13
    Me.Label1.Text = "Make"
    '
    'TxtMake
    '
    Me.TxtMake.Location = New System.Drawing.Point(186, 33)
    Me.TxtMake.MaxLength = 5
    Me.TxtMake.Name = "TxtMake"
    Me.TxtMake.Size = New System.Drawing.Size(46, 20)
    Me.TxtMake.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(63, 81)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(89, 13)
    Me.Label2.TabIndex = 14
    Me.Label2.Text = "Gross Weight <= "
    '
    'TxtGross
    '
    Me.TxtGross.Location = New System.Drawing.Point(171, 78)
    Me.TxtGross.MaxLength = 6
    Me.TxtGross.Name = "TxtGross"
    Me.TxtGross.Size = New System.Drawing.Size(71, 20)
    Me.TxtGross.TabIndex = 2
    '
    'ChkZero
    '
    Me.ChkZero.AutoSize = True
    Me.ChkZero.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkZero.Location = New System.Drawing.Point(62, 104)
    Me.ChkZero.Name = "ChkZero"
    Me.ChkZero.Size = New System.Drawing.Size(108, 17)
    Me.ChkZero.TabIndex = 3
    Me.ChkZero.TabStop = False
    Me.ChkZero.Text = "Only Zero Value?"
    Me.ChkZero.TextAlign = System.Drawing.ContentAlignment.BottomRight
    Me.ChkZero.UseVisualStyleBackColor = True
    '
    'FrmTA440B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(519, 133)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkZero)
    Me.Controls.Add(Me.TxtGross)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtMake)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.LnkFromClass)
    Me.Controls.Add(Me.TxtClass)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA440B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox3.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region


  Public Sub ProcessMe()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    WrkClassDesc = String.Empty
    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If
    ' stick code to get records for the class and make load into grid..
    MyFrmTA440.TBarProcess.Enabled = False
    MyFrmTA440.TBarPrint.Enabled = True
    MyFrmTA440.SbpScreen.Text = "TA440C"
    MyFrmTA440C = New FrmTA440C
    MyFrmTA440C.MdiParent = Me.ParentForm
    MyFrmTA440C.wrkclassdesc = WrkClassDesc
    MyFrmTA440C.Show()
    Me.Hide()

  End Sub
  Private Sub FrmTA440B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    TxtClass.Focus()
  End Sub
  Private Sub FrmTA440B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

    TxtClass.Focus()
    Me.Refresh()
    MyFrmTA440.SbpScreen.Text = "TA440B"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtClass, "")
    ErrProv.SetError(TxtMake, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "class"
          ErrProv.SetError(TxtClass, ErrorMsg(I))
        Case "make"
          ErrProv.SetError(TxtMake, ErrorMsg(I))

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
    If MyUtils.CnvSng(TxtClass.Text) > 0 Then
      WrkClassDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtClass.Text), "M")
      If Mid(WrkClassDesc, 1, 3) = "***" Then
        ErrorField(I) = "class"
        ErrorMsg(I) = "Invalid Class"
        I = I + 1
      End If
    End If

    'If TxtMake.Text = "" Then
    '  ErrorField(I) = "make"
    '  ErrorMsg(I) = "Invalid Make"
    '  I = I + 1
    'End If
  End Sub
  Private Sub LnkFromClass_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFromClass.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkField = "From"
    MyFrmListCodes.WrkType = "M"
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtClass.Text)
    MyFrmListCodes.Show()
    Me.Hide()
  End Sub

  Private Sub TxtClass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClass.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Private Sub RbSortName_CheckedChanged(sender As Object, e As EventArgs) Handles RbSortName.CheckedChanged
    If RbSortName.Checked = True Then
      wrksort = "name"
    End If
  End Sub

  Private Sub RbSortList_CheckedChanged(sender As Object, e As EventArgs) Handles RbSortList.CheckedChanged
    If RbSortList.Checked = True Then
      wrksort = "list#"
    End If
  End Sub
  Private Sub RbSortMake_CheckedChanged(sender As Object, e As EventArgs) Handles RbSortMake.CheckedChanged
    If RbSortMake.Checked = True Then
      wrksort = "make,year,model"
    End If
  End Sub

  Private Sub TxtGross_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGross.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
End Class






