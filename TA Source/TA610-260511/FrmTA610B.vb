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
    Friend WithEvents TxtTotalYears As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents ChkBTR As CheckBox

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
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtTotalYears = New System.Windows.Forms.TextBox()
    Me.ChkBTR = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ChkPost
    '
    Me.ChkPost.AutoSize = True
    Me.ChkPost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPost.Location = New System.Drawing.Point(29, 99)
    Me.ChkPost.Name = "ChkPost"
    Me.ChkPost.Size = New System.Drawing.Size(81, 17)
    Me.ChkPost.TabIndex = 4
    Me.ChkPost.Text = "Post to file?"
    '
    'TxtCurrYear
    '
    Me.TxtCurrYear.Location = New System.Drawing.Point(125, 38)
    Me.TxtCurrYear.MaxLength = 3
    Me.TxtCurrYear.Name = "TxtCurrYear"
    Me.TxtCurrYear.Size = New System.Drawing.Size(27, 20)
    Me.TxtCurrYear.TabIndex = 1
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(29, 41)
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
    Me.LblMsg.Location = New System.Drawing.Point(29, 126)
    Me.LblMsg.Name = "LblMsg"
    Me.LblMsg.Size = New System.Drawing.Size(71, 13)
    Me.LblMsg.TabIndex = 210
    Me.LblMsg.Text = "<Message>"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(168, 41)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(84, 13)
    Me.Label7.TabIndex = 213
    Me.Label7.Text = "Number of years"
    '
    'TxtTotalYears
    '
    Me.TxtTotalYears.Location = New System.Drawing.Point(253, 38)
    Me.TxtTotalYears.MaxLength = 3
    Me.TxtTotalYears.Name = "TxtTotalYears"
    Me.TxtTotalYears.Size = New System.Drawing.Size(27, 20)
    Me.TxtTotalYears.TabIndex = 214
    '
    'ChkBTR
    '
    Me.ChkBTR.AutoSize = True
    Me.ChkBTR.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkBTR.Location = New System.Drawing.Point(29, 76)
    Me.ChkBTR.Name = "ChkBTR"
    Me.ChkBTR.Size = New System.Drawing.Size(83, 17)
    Me.ChkBTR.TabIndex = 216
    Me.ChkBTR.Text = "Apply BTR?"
    '
    'FrmTA610B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(401, 168)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkBTR)
    Me.Controls.Add(Me.TxtTotalYears)
    Me.Controls.Add(Me.Label7)
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
    LblMsg.Text = ""

    With myTXPHCNTL
      .GetOneRecordP("")
      If .RecordNotFound Then
        TxtCurrYear.Text = "1"
        LblMsg.Text = "Create Phase in data and update Real Estate"
      Else
        TxtCurrYear.Text = ._CURRYEAR + 1
        TxtTotalYears.Text = ._TOTALYEARS
        LblMsg.Text = "Update Phase in data"
      End If
    End With
  End Sub

  Private Sub ChkBTR_Click(sender As Object, e As EventArgs) Handles ChkBTR.Click
    If ChkBTR.Checked Then
      LblMsg.Text = "Apply Phase In"
    Else
      With myTXPHCNTL
        .GetOneRecordP("")
        If .RecordNotFound Then
          TxtCurrYear.Text = "1"
          LblMsg.Text = "Create Phase in data and update Real Estate"
        Else
          TxtCurrYear.Text = ._CURRYEAR + 1
          TxtTotalYears.Text = ._TOTALYEARS
          LblMsg.Text = "Update Phase in data"
        End If
      End With
    End If
  End Sub
End Class






