Public Class FrmTA230B
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
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents LnkCode As System.Windows.Forms.LinkLabel
Friend WithEvents TxtCode As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents ChkCC As System.Windows.Forms.CheckBox
Friend WithEvents ChkBAA As System.Windows.Forms.CheckBox
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents ChkSName As System.Windows.Forms.CheckBox
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTA230B))
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.LnkCode = New System.Windows.Forms.LinkLabel
Me.TxtCode = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.ChkCC = New System.Windows.Forms.CheckBox
Me.ChkBAA = New System.Windows.Forms.CheckBox
Me.TxtGLYear = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.ChkSName = New System.Windows.Forms.CheckBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'ImageList1
'
Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
Me.ImageList1.Images.SetKeyName(0, "")
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'LnkCode
'
Me.LnkCode.AutoSize = True
Me.LnkCode.Location = New System.Drawing.Point(25, 74)
Me.LnkCode.Name = "LnkCode"
Me.LnkCode.Size = New System.Drawing.Size(32, 13)
Me.LnkCode.TabIndex = 343
Me.LnkCode.TabStop = True
Me.LnkCode.Text = "Code"
'
'TxtCode
'
Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtCode.Location = New System.Drawing.Point(63, 71)
Me.TxtCode.MaxLength = 2
Me.TxtCode.Name = "TxtCode"
Me.TxtCode.Size = New System.Drawing.Size(20, 20)
Me.TxtCode.TabIndex = 1
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(93, 74)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(52, 13)
Me.Label1.TabIndex = 344
Me.Label1.Text = "(Optional)"
'
'ChkCC
'
Me.ChkCC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.ChkCC.Location = New System.Drawing.Point(28, 147)
Me.ChkCC.Name = "ChkCC"
Me.ChkCC.Size = New System.Drawing.Size(140, 16)
Me.ChkCC.TabIndex = 4
Me.ChkCC.Text = "Include C/C Amounts?"
'
'ChkBAA
'
Me.ChkBAA.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkBAA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.ChkBAA.Location = New System.Drawing.Point(28, 125)
Me.ChkBAA.Name = "ChkBAA"
Me.ChkBAA.Size = New System.Drawing.Size(140, 16)
Me.ChkBAA.TabIndex = 3
Me.ChkBAA.Text = "Include BAA Amounts?"
'
'TxtGLYear
'
Me.TxtGLYear.Location = New System.Drawing.Point(113, 42)
Me.TxtGLYear.MaxLength = 4
Me.TxtGLYear.Name = "TxtGLYear"
Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
Me.TxtGLYear.TabIndex = 0
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(25, 42)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(84, 16)
Me.Label4.TabIndex = 348
Me.Label4.Text = "Grand List Year"
'
'ChkSName
'
Me.ChkSName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkSName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.ChkSName.Location = New System.Drawing.Point(28, 103)
Me.ChkSName.Name = "ChkSName"
Me.ChkSName.Size = New System.Drawing.Size(140, 16)
Me.ChkSName.TabIndex = 2
Me.ChkSName.Text = "Show Second Name?"
'
'FrmTA230B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(189, 210)
Me.ControlBox = False
Me.Controls.Add(Me.ChkSName)
Me.Controls.Add(Me.ChkCC)
Me.Controls.Add(Me.ChkBAA)
Me.Controls.Add(Me.TxtGLYear)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.LnkCode)
Me.Controls.Add(Me.TxtCode)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA230B"
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
    PrtReport()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
Private Sub FrmTA230B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA230.SbpScreen.Text = "TA230B"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmTA230B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
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

Private Sub FrmTA230B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

End Sub
Private Sub LnkCode_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode.LinkClicked
  MyFrmListLocalCodes = New FrmListLocalCodes
  MyFrmListLocalCodes.MdiParent = Me.ParentForm
  MyFrmListLocalCodes.WrkCode = TxtCode.Text
  MyFrmListLocalCodes.Show()
End Sub
End Class






