Public Class FrmTA231B
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
  Friend WithEvents TxtEldYear As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
 Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtEldYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.ChkPost = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TxtEldYear
    '
    Me.TxtEldYear.Location = New System.Drawing.Point(144, 24)
    Me.TxtEldYear.MaxLength = 4
    Me.TxtEldYear.Name = "TxtEldYear"
    Me.TxtEldYear.Size = New System.Drawing.Size(35, 20)
    Me.TxtEldYear.TabIndex = 0
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(54, 27)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(84, 16)
    Me.Label4.TabIndex = 58
    Me.Label4.Text = "Elderly Year"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'ChkPost
    '
    Me.ChkPost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkPost.Location = New System.Drawing.Point(57, 50)
    Me.ChkPost.Name = "ChkPost"
    Me.ChkPost.Size = New System.Drawing.Size(101, 19)
    Me.ChkPost.TabIndex = 2
    Me.ChkPost.Text = "Post to File?"
    '
    'FrmTA231B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(238, 90)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkPost)
    Me.Controls.Add(Me.TxtEldYear)
    Me.Controls.Add(Me.Label4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA231B"
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
  ErrProv.SetError(TxtEldYear, "")

  For I = 0 To ErrorField.GetUpperBound(0)
   Select Case ErrorField(I)
   Case "year"
    ErrProv.SetError(TxtEldYear, ErrorMsg(I))
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

  If MyUtils.CnvSng(TxtEldYear.Text) = 0 Then
   ErrorField(I) = "year"
   ErrorMsg(I) = "Year is required"
   I = I + 1
  End If

 End Sub
Private Sub FrmTA231B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
 MyFrmTA231.SbpScreen.Text = "TA231B"
End Sub
Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEldYear.KeyPress
 e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub FrmTA231B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

End Sub

Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

End Sub
End Class






