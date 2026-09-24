Public Class FrmTA236B
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
  Friend WithEvents TxtNewBen As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
 Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
 Friend WithEvents TxtOldBen As System.Windows.Forms.TextBox
 Friend WithEvents Label1 As System.Windows.Forms.Label
 Friend WithEvents Label3 As System.Windows.Forms.Label
 Friend WithEvents Label2 As System.Windows.Forms.Label
 Friend WithEvents LnkCode As System.Windows.Forms.LinkLabel
 Friend WithEvents TxtCode As System.Windows.Forms.TextBox
    Friend WithEvents TxtGLYear As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TxtNewBen = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ChkPost = New System.Windows.Forms.CheckBox()
        Me.TxtOldBen = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LnkCode = New System.Windows.Forms.LinkLabel()
        Me.TxtCode = New System.Windows.Forms.TextBox()
        Me.TxtGLYear = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtNewBen
        '
        Me.TxtNewBen.Location = New System.Drawing.Point(113, 111)
        Me.TxtNewBen.MaxLength = 4
        Me.TxtNewBen.Name = "TxtNewBen"
        Me.TxtNewBen.Size = New System.Drawing.Size(55, 20)
        Me.TxtNewBen.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(38, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 20)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "New Benefit"
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'ChkPost
        '
        Me.ChkPost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkPost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkPost.Location = New System.Drawing.Point(38, 137)
        Me.ChkPost.Name = "ChkPost"
        Me.ChkPost.Size = New System.Drawing.Size(101, 19)
        Me.ChkPost.TabIndex = 3
        Me.ChkPost.Text = "Post to File?"
        '
        'TxtOldBen
        '
        Me.TxtOldBen.Location = New System.Drawing.Point(113, 85)
        Me.TxtOldBen.MaxLength = 4
        Me.TxtOldBen.Name = "TxtOldBen"
        Me.TxtOldBen.Size = New System.Drawing.Size(55, 20)
        Me.TxtOldBen.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(38, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 20)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Old Benefit"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(174, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 20)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "(0 = all)"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(174, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 20)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "(0 = remove)"
        '
        'LnkCode
        '
        Me.LnkCode.AutoSize = True
        Me.LnkCode.Location = New System.Drawing.Point(38, 34)
        Me.LnkCode.Name = "LnkCode"
        Me.LnkCode.Size = New System.Drawing.Size(32, 13)
        Me.LnkCode.TabIndex = 343
        Me.LnkCode.TabStop = True
        Me.LnkCode.Text = "Code"
        '
        'TxtCode
        '
        Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCode.Location = New System.Drawing.Point(113, 31)
        Me.TxtCode.MaxLength = 2
        Me.TxtCode.Name = "TxtCode"
        Me.TxtCode.Size = New System.Drawing.Size(22, 20)
        Me.TxtCode.TabIndex = 0
        '
        'TxtGLYear
        '
        Me.TxtGLYear.Location = New System.Drawing.Point(113, 56)
        Me.TxtGLYear.MaxLength = 4
        Me.TxtGLYear.Name = "TxtGLYear"
        Me.TxtGLYear.Size = New System.Drawing.Size(55, 20)
        Me.TxtGLYear.TabIndex = 344
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(38, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 20)
        Me.Label5.TabIndex = 345
        Me.Label5.Text = "G/L Year"
        '
        'FrmTA236B
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(277, 166)
        Me.ControlBox = False
        Me.Controls.Add(Me.TxtGLYear)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LnkCode)
        Me.Controls.Add(Me.TxtCode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtOldBen)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ChkPost)
        Me.Controls.Add(Me.TxtNewBen)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTA236B"
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

  Me.Refresh()
  Windows.Forms.Cursor.Current = Cursors.WaitCursor
  PrtReport()
  Windows.Forms.Cursor.Current = Cursors.Default

 End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtCode, "")
  ErrProv.SetError(TxtOldBen, "")
  ErrProv.SetError(TxtNewBen, "")

  For I = 0 To ErrorField.GetUpperBound(0)
   Select Case ErrorField(I)
   Case "code"
    ErrProv.SetError(TxtCode, ErrorMsg(I))
   Case "oldben"
    ErrProv.SetError(TxtOldBen, ErrorMsg(I))
   Case "newben"
    ErrProv.SetError(TxtNewBen, ErrorMsg(I))
   Case Nothing
    Exit Sub
   End Select
  Next I
 End Sub
 Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim ds As DataSet = New DataSet
  Dim I As Integer
  For I = 0 To ErrorField.GetUpperBound(0)
   If IsNothing(ErrorField(I)) Then
    Exit For
   End If
  Next

  If TxtCode.Text = "" Then
   ErrorField(I) = "code"
   ErrorMsg(I) = "Code is required"
   I = I + 1
  End If

  If MyUtils.CnvSng(TxtOldBen.Text) <> 0 And MyUtils.CnvSng(TxtOldBen.Text) = MyUtils.CnvSng(TxtNewBen.Text) Then
   ErrorField(I) = "oldben"
   ErrorMsg(I) = "Old Benefit cannot be same as new"
   I = I + 1
  End If

  If TxtOldBen.Text = "" Then
   ErrorField(I) = "oldben"
   ErrorMsg(I) = "Old Benefit is required"
   I = I + 1
  End If

  If TxtNewBen.Text = "" Then
   ErrorField(I) = "newben"
   ErrorMsg(I) = "New Benefit is required"
   I = I + 1
  End If

 End Sub
Private Sub FrmTA236B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
 MyFrmTA236.SbpScreen.Text = "TA236B"
End Sub
Private Sub TxtOldBen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOldBen.KeyPress
 e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtNewBen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNewBen.KeyPress
 e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub LnkCode_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode.LinkClicked
  MyFrmListLocalCodes = New FrmListLocalCodes
  MyFrmListLocalCodes.MdiParent = Me.ParentForm
  MyFrmListLocalCodes.WrkCode = TxtCode.Text
  MyFrmListLocalCodes.Show()
End Sub

Private Sub FrmTA236B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

End Sub
End Class






