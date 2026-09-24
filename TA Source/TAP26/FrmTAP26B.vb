Public Class FrmTAP26B
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
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
  Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
  Friend WithEvents TxtGLYear2 As TextBox
  Friend WithEvents Label1 As Label
    Friend WithEvents LnkCode As LinkLabel
    Friend WithEvents TxtCode As TextBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTAP26B))
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TxtGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtGLYear2 = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.LnkCode = New System.Windows.Forms.LinkLabel()
    Me.TxtCode = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    '
    'TxtGLYear
    '
    Me.TxtGLYear.Location = New System.Drawing.Point(165, 31)
    Me.TxtGLYear.MaxLength = 4
    Me.TxtGLYear.Name = "TxtGLYear"
    Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtGLYear.TabIndex = 1
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(34, 34)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(125, 13)
    Me.Label4.TabIndex = 11
    Me.Label4.Text = "Compare Grand List Year"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtGLYear2
    '
    Me.TxtGLYear2.Location = New System.Drawing.Point(165, 59)
    Me.TxtGLYear2.MaxLength = 4
    Me.TxtGLYear2.Name = "TxtGLYear2"
    Me.TxtGLYear2.Size = New System.Drawing.Size(32, 20)
    Me.TxtGLYear2.TabIndex = 12
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(34, 62)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(96, 13)
    Me.Label1.TabIndex = 13
    Me.Label1.Text = "To Grand List Year"
    '
    'LnkCode
    '
    Me.LnkCode.Location = New System.Drawing.Point(34, 88)
    Me.LnkCode.Name = "LnkCode"
    Me.LnkCode.Size = New System.Drawing.Size(37, 20)
    Me.LnkCode.TabIndex = 15
    Me.LnkCode.TabStop = True
    Me.LnkCode.Text = "Code"
    '
    'TxtCode
    '
    Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode.Location = New System.Drawing.Point(77, 85)
    Me.TxtCode.MaxLength = 3
    Me.TxtCode.Name = "TxtCode"
    Me.TxtCode.Size = New System.Drawing.Size(32, 20)
    Me.TxtCode.TabIndex = 14
    '
    'FrmTAP26B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(225, 136)
    Me.ControlBox = False
    Me.Controls.Add(Me.LnkCode)
    Me.Controls.Add(Me.TxtCode)
    Me.Controls.Add(Me.TxtGLYear2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtGLYear)
    Me.Controls.Add(Me.Label4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTAP26B"
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
    Private Sub FrmTAP26B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        MyFrmTAP26.SbpScreen.Text = "TAP26B"
    End Sub
    Private Sub FrmTAP26B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        Me.Refresh()
    End Sub
    Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
        Dim I As Integer
        ErrProv.Clear()

        For I = 0 To ErrorField.GetUpperBound(0)
            Select Case ErrorField(I)
                Case "glyear"
                    ErrProv.SetError(TxtGLYear, ErrorMsg(I))
                Case "glyear2"
                    ErrProv.SetError(TxtGLYear2, ErrorMsg(I))
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

        If MyUtils.CnvSng(TxtGLYear.Text) = 0 Then
            ErrorField(I) = "glyear"
            ErrorMsg(I) = "Invalid Year"
            I = I + 1
        End If

        If MyUtils.CnvSng(TxtGLYear2.Text) = 0 Then
            ErrorField(I) = "glyear2"
            ErrorMsg(I) = "Invalid Year"
            I = I + 1
        End If
    End Sub
    Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
        e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
    End Sub
    Private Sub TxtGLYear2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear2.KeyPress
        e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
    End Sub
  Private Sub TxtCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub LnkCode_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkCode.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkYear = MyUtils.CnvSng(TxtGLYear.Text)
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode.Text)
    MyFrmListCodes.Show()
  End Sub
End Class
