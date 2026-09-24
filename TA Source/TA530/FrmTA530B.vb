Public Class FrmTA530B
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LnkToClass As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtToClass As System.Windows.Forms.TextBox
    Friend WithEvents TxtToYear As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtFromYear As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtNADA As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
  Friend WithEvents TxtFromClass As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TxtFromClass = New System.Windows.Forms.TextBox
Me.LnkFromClass = New System.Windows.Forms.LinkLabel
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.LnkToClass = New System.Windows.Forms.LinkLabel
Me.TxtToClass = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.Label2 = New System.Windows.Forms.Label
Me.TxtFromYear = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.Label4 = New System.Windows.Forms.Label
Me.TxtToYear = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
Me.TxtNADA = New System.Windows.Forms.TextBox
Me.Label6 = New System.Windows.Forms.Label
Me.Label7 = New System.Windows.Forms.Label
Me.Label8 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'TxtFromClass
'
Me.TxtFromClass.Location = New System.Drawing.Point(101, 33)
Me.TxtFromClass.MaxLength = 2
Me.TxtFromClass.Name = "TxtFromClass"
Me.TxtFromClass.Size = New System.Drawing.Size(25, 20)
Me.TxtFromClass.TabIndex = 1
'
'LnkFromClass
'
Me.LnkFromClass.AutoSize = True
Me.LnkFromClass.Location = New System.Drawing.Point(63, 36)
Me.LnkFromClass.Name = "LnkFromClass"
Me.LnkFromClass.Size = New System.Drawing.Size(32, 13)
Me.LnkFromClass.TabIndex = 0
Me.LnkFromClass.TabStop = True
Me.LnkFromClass.Text = "Class"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'LnkToClass
'
Me.LnkToClass.AutoSize = True
Me.LnkToClass.Location = New System.Drawing.Point(169, 36)
Me.LnkToClass.Name = "LnkToClass"
Me.LnkToClass.Size = New System.Drawing.Size(32, 13)
Me.LnkToClass.TabIndex = 2
Me.LnkToClass.TabStop = True
Me.LnkToClass.Text = "Class"
'
'TxtToClass
'
Me.TxtToClass.Location = New System.Drawing.Point(207, 33)
Me.TxtToClass.MaxLength = 2
Me.TxtToClass.Name = "TxtToClass"
Me.TxtToClass.Size = New System.Drawing.Size(25, 20)
Me.TxtToClass.TabIndex = 3
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(25, 36)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(30, 13)
Me.Label1.TabIndex = 5
Me.Label1.Text = "From"
'
'Label2
'
Me.Label2.AutoSize = True
Me.Label2.Location = New System.Drawing.Point(143, 36)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(20, 13)
Me.Label2.TabIndex = 6
Me.Label2.Text = "To"
'
'TxtFromYear
'
Me.TxtFromYear.Location = New System.Drawing.Point(101, 59)
Me.TxtFromYear.MaxLength = 4
Me.TxtFromYear.Name = "TxtFromYear"
Me.TxtFromYear.Size = New System.Drawing.Size(32, 20)
Me.TxtFromYear.TabIndex = 7
'
'Label3
'
Me.Label3.AutoSize = True
Me.Label3.Location = New System.Drawing.Point(25, 62)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(55, 13)
Me.Label3.TabIndex = 8
Me.Label3.Text = "From Year"
'
'Label4
'
Me.Label4.AutoSize = True
Me.Label4.Location = New System.Drawing.Point(143, 62)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(45, 13)
Me.Label4.TabIndex = 9
Me.Label4.Text = "To Year"
'
'TxtToYear
'
Me.TxtToYear.Location = New System.Drawing.Point(207, 59)
Me.TxtToYear.MaxLength = 4
Me.TxtToYear.Name = "TxtToYear"
Me.TxtToYear.Size = New System.Drawing.Size(32, 20)
Me.TxtToYear.TabIndex = 10
'
'Label5
'
Me.Label5.AutoSize = True
Me.Label5.Location = New System.Drawing.Point(25, 88)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(65, 13)
Me.Label5.TabIndex = 12
Me.Label5.Text = "NADA Code"
'
'TxtNADA
'
Me.TxtNADA.Location = New System.Drawing.Point(101, 85)
Me.TxtNADA.MaxLength = 4
Me.TxtNADA.Name = "TxtNADA"
Me.TxtNADA.Size = New System.Drawing.Size(15, 20)
Me.TxtNADA.TabIndex = 11
'
'Label6
'
Me.Label6.AutoSize = True
Me.Label6.Location = New System.Drawing.Point(122, 88)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(52, 13)
Me.Label6.TabIndex = 13
Me.Label6.Text = "(Optional)"
'
'Label7
'
Me.Label7.AutoSize = True
Me.Label7.Location = New System.Drawing.Point(253, 62)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(52, 13)
Me.Label7.TabIndex = 14
Me.Label7.Text = "(Optional)"
'
'Label8
'
Me.Label8.AutoSize = True
Me.Label8.Location = New System.Drawing.Point(253, 36)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(52, 13)
Me.Label8.TabIndex = 15
Me.Label8.Text = "(Optional)"
'
'FrmTA530B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(317, 143)
Me.ControlBox = False
Me.Controls.Add(Me.Label8)
Me.Controls.Add(Me.Label7)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.TxtNADA)
Me.Controls.Add(Me.TxtToYear)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.TxtFromYear)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.LnkToClass)
Me.Controls.Add(Me.TxtToClass)
Me.Controls.Add(Me.LnkFromClass)
Me.Controls.Add(Me.TxtFromClass)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA530B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
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

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    PrtReport(WrkClassDesc)
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub FrmTA530B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  End Sub
Private Sub FrmTA530B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA530.SbpScreen.Text = "TA530B"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFromClass, "")
    ErrProv.SetError(TxtToClass, "")
    ErrProv.SetError(TxtFromYear, "")
    ErrProv.SetError(TxtToYear, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "fromclass"
        ErrProv.SetError(TxtFromClass, ErrorMsg(I))
      Case "toclass"
        ErrProv.SetError(TxtToClass, ErrorMsg(I))
      Case "fromyear"
        ErrProv.SetError(TxtFromYear, ErrorMsg(I))
      Case "toyear"
        ErrProv.SetError(TxtToYear, ErrorMsg(I))
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
    If MyUtils.CnvSng(TxtFromClass.Text) > 0 Then
      WrkClassDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtFromClass.Text), "M")
      If Mid(WrkClassDesc, 1, 3) = "***" Then
        ErrorField(I) = "fromclass"
        ErrorMsg(I) = "Invalid From Class"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtToClass.Text) > 0 Then
      WrkClassDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtToClass.Text), "M")
      If Mid(WrkClassDesc, 1, 3) = "***" Then
        ErrorField(I) = "toclass"
        ErrorMsg(I) = "Invalid To Class"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtFromClass.Text) > MyUtils.CnvSng(TxtToClass.Text) Then
      ErrorField(I) = "fromclass"
      ErrorMsg(I) = "Invalid Class Range"
      I = I + 1
      ErrorField(I) = "toclass"
      ErrorMsg(I) = "Invalid Class Range"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtFromYear.Text) > MyUtils.CnvSng(TxtToYear.Text) Then
      ErrorField(I) = "fromyear"
      ErrorMsg(I) = "Invalid Year Range"
      I = I + 1
      ErrorField(I) = "toyear"
      ErrorMsg(I) = "Invalid Year Range"
      I = I + 1
    End If
  End Sub
Private Sub LnkFromClass_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFromClass.LinkClicked
  MyFrmListCodes = New FrmListCodes
  MyFrmListCodes.MdiParent = Me.ParentForm
  MyFrmListCodes.WrkField = "From"
  MyFrmListCodes.WrkType = "M"
  MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtFromClass.Text)
  MyFrmListCodes.Show()
  Me.Hide()
End Sub
Private Sub LnkToClass_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkToClass.LinkClicked
  MyFrmListCodes = New FrmListCodes
  MyFrmListCodes.MdiParent = Me.ParentForm
  MyFrmListCodes.WrkField = "To"
  MyFrmListCodes.WrkType = "M"
  MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtToClass.Text)
  MyFrmListCodes.Show()
  Me.Hide()
End Sub
Private Sub TxtFromClass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromClass.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtToClass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToClass.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtFromYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtToYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






