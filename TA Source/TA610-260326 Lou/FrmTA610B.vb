Public Class FrmTA610B
  Inherits System.Windows.Forms.Form
  Dim myTXPHCNTL As TXPHCNTL.MyData

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
  Friend WithEvents TxtCurrYear As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents LblMsg As System.Windows.Forms.Label
  Friend WithEvents RbNextYear As RadioButton
  Friend WithEvents RbFirstYear As RadioButton
  Friend WithEvents Label1 As Label
  Friend WithEvents TxtTotalYears As TextBox
  Friend WithEvents Label7 As Label

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ChkPost = New System.Windows.Forms.CheckBox()
    Me.TxtCurrYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.LblMsg = New System.Windows.Forms.Label()
    Me.RbFirstYear = New System.Windows.Forms.RadioButton()
    Me.RbNextYear = New System.Windows.Forms.RadioButton()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtTotalYears = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ChkPost
    '
    Me.ChkPost.AutoSize = True
    Me.ChkPost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPost.Location = New System.Drawing.Point(27, 132)
    Me.ChkPost.Name = "ChkPost"
    Me.ChkPost.Size = New System.Drawing.Size(81, 17)
    Me.ChkPost.TabIndex = 4
    Me.ChkPost.Text = "Post to file?"
    '
    'TxtCurrYear
    '
    Me.TxtCurrYear.Location = New System.Drawing.Point(123, 71)
    Me.TxtCurrYear.MaxLength = 3
    Me.TxtCurrYear.Name = "TxtCurrYear"
    Me.TxtCurrYear.Size = New System.Drawing.Size(27, 20)
    Me.TxtCurrYear.TabIndex = 1
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(27, 74)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(90, 13)
    Me.Label4.TabIndex = 58
    Me.Label4.Text = "Phase in Year No"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LblMsg
    '
    Me.LblMsg.AutoSize = True
    Me.LblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMsg.Location = New System.Drawing.Point(27, 159)
    Me.LblMsg.Name = "LblMsg"
    Me.LblMsg.Size = New System.Drawing.Size(71, 13)
    Me.LblMsg.TabIndex = 210
    Me.LblMsg.Text = "<Message>"
    '
    'RbFirstYear
    '
    Me.RbFirstYear.AutoSize = True
    Me.RbFirstYear.Location = New System.Drawing.Point(53, 25)
    Me.RbFirstYear.Name = "RbFirstYear"
    Me.RbFirstYear.Size = New System.Drawing.Size(114, 17)
    Me.RbFirstYear.TabIndex = 211
    Me.RbFirstYear.TabStop = True
    Me.RbFirstYear.Text = "First Year Phase In"
    Me.RbFirstYear.UseVisualStyleBackColor = True
    '
    'RbNextYear
    '
    Me.RbNextYear.AutoSize = True
    Me.RbNextYear.Location = New System.Drawing.Point(207, 25)
    Me.RbNextYear.Name = "RbNextYear"
    Me.RbNextYear.Size = New System.Drawing.Size(158, 17)
    Me.RbNextYear.TabIndex = 212
    Me.RbNextYear.TabStop = True
    Me.RbNextYear.Text = "Process Next Phase In Year"
    Me.RbNextYear.UseVisualStyleBackColor = True
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(166, 74)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(84, 13)
    Me.Label7.TabIndex = 213
    Me.Label7.Text = "Number of years"
    '
    'TxtTotalYears
    '
    Me.TxtTotalYears.Location = New System.Drawing.Point(251, 71)
    Me.TxtTotalYears.MaxLength = 3
    Me.TxtTotalYears.Name = "TxtTotalYears"
    Me.TxtTotalYears.Size = New System.Drawing.Size(27, 20)
    Me.TxtTotalYears.TabIndex = 214
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(166, 27)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(35, 13)
    Me.Label1.TabIndex = 215
    Me.Label1.Text = "- OR -"
    '
    'FrmTA610B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(401, 204)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtTotalYears)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.RbNextYear)
    Me.Controls.Add(Me.RbFirstYear)
    Me.Controls.Add(Me.LblMsg)
    Me.Controls.Add(Me.TxtCurrYear)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.ChkPost)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA610B"
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

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
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
  End Sub
  Private Sub FrmTA610B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA610.SbpScreen.Text = "TA610B"
  End Sub
  Private Sub FrmTA610B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXPHCNTL = New TXPHCNTL.MyData(myDBConnect)
    RbFirstYear.Enabled = False
    RbNextYear.Enabled = False

    With myTXPHCNTL
      .GetOneRecordP("")
      If .RecordNotFound Then
        RbFirstYear.Enabled = True
        RbFirstYear.Checked = True
        TxtCurrYear.Text = "1"
      Else
        If ._CURRYEAR = ._TOTALYEARS Then
          RbFirstYear.Enabled = True
          RbFirstYear.Checked = True
          TxtCurrYear.Text = "1"
          TxtTotalYears.Text = ""
        Else
          RbNextYear.Enabled = True
          RbNextYear.Checked = True
          TxtCurrYear.Text = ._CURRYEAR + 1
          TxtTotalYears.Text = ._TOTALYEARS
        End If
      End If
    End With
  End Sub
End Class






