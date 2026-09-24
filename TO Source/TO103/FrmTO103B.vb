Public Class FrmTO103B
Inherits System.Windows.Forms.Form
Dim MyTXDIST As TXDIST.myData
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
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents TxtAppYear As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents RbOnly As System.Windows.Forms.RadioButton
Friend WithEvents RbPrev As System.Windows.Forms.RadioButton
Friend WithEvents LnkDist As System.Windows.Forms.LinkLabel
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTO103B))
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.TxtGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtAppYear = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.RbOnly = New System.Windows.Forms.RadioButton()
    Me.RbPrev = New System.Windows.Forms.RadioButton()
    Me.LnkDist = New System.Windows.Forms.LinkLabel()
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
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(175, 72)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(28, 20)
    Me.TxtDist.TabIndex = 2
    '
    'TxtGLYear
    '
    Me.TxtGLYear.Location = New System.Drawing.Point(175, 20)
    Me.TxtGLYear.MaxLength = 4
    Me.TxtGLYear.Name = "TxtGLYear"
    Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtGLYear.TabIndex = 0
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(75, 20)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(84, 16)
    Me.Label4.TabIndex = 56
    Me.Label4.Text = "Grand List Year"
    '
    'TxtAppYear
    '
    Me.TxtAppYear.Location = New System.Drawing.Point(175, 46)
    Me.TxtAppYear.MaxLength = 4
    Me.TxtAppYear.Name = "TxtAppYear"
    Me.TxtAppYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtAppYear.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(75, 46)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(94, 17)
    Me.Label2.TabIndex = 59
    Me.Label2.Text = "Application Year"
    '
    'RbOnly
    '
    Me.RbOnly.AutoSize = True
    Me.RbOnly.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbOnly.Location = New System.Drawing.Point(169, 108)
    Me.RbOnly.Name = "RbOnly"
    Me.RbOnly.Size = New System.Drawing.Size(101, 17)
    Me.RbOnly.TabIndex = 192
    Me.RbOnly.Text = "G/L Year ONLY"
    Me.RbOnly.UseVisualStyleBackColor = True
    '
    'RbPrev
    '
    Me.RbPrev.AutoSize = True
    Me.RbPrev.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPrev.Checked = True
    Me.RbPrev.Location = New System.Drawing.Point(12, 108)
    Me.RbPrev.Name = "RbPrev"
    Me.RbPrev.Size = New System.Drawing.Size(133, 17)
    Me.RbPrev.TabIndex = 191
    Me.RbPrev.TabStop = True
    Me.RbPrev.Text = "G/L Year and previous"
    Me.RbPrev.UseVisualStyleBackColor = True
    '
    'LnkDist
    '
    Me.LnkDist.AutoSize = True
    Me.LnkDist.Location = New System.Drawing.Point(75, 75)
    Me.LnkDist.Name = "LnkDist"
    Me.LnkDist.Size = New System.Drawing.Size(39, 13)
    Me.LnkDist.TabIndex = 193
    Me.LnkDist.TabStop = True
    Me.LnkDist.Text = "District"
    '
    'FrmTO103B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(281, 146)
    Me.ControlBox = False
    Me.Controls.Add(Me.LnkDist)
    Me.Controls.Add(Me.RbOnly)
    Me.Controls.Add(Me.RbPrev)
    Me.Controls.Add(Me.TxtAppYear)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.TxtGLYear)
    Me.Controls.Add(Me.Label4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTO103B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Public Sub RunReport()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    MyTXDIST = New TXDIST.MyData(myDBConnect)

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
  Private Sub FrmTO103B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTO103.SbpScreen.Text = "TO103B"
  End Sub
  Private Sub FrmTO103B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.Clear()

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "glyear"
          ErrProv.SetError(TxtGLYear, ErrorMsg(I))
        Case "appyear"
          ErrProv.SetError(TxtAppYear, ErrorMsg(I))
        Case "dist"
          ErrProv.SetError(TxtDist, ErrorMsg(I))
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
      ErrorMsg(I) = "Invalid GL Year"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtAppYear.Text) = 0 Then
      ErrorField(I) = "appyear"
      ErrorMsg(I) = "Invalid Application Year"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtDist.Text) <> 0 Then
      MyTXDIST.GetOneRecordP(MyUtils.CnvSng(TxtDist.Text))
      If MyTXDIST.RecordNotFound Then
        ErrorField(I) = "dist"
        ErrorMsg(I) = "Invalid District"
        I = I + 1
      End If
    End If
  End Sub
  Private Sub LnkDistrict_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    MyFrmListDist = New FrmListDist
    MyFrmListDist.MdiParent = Me.ParentForm
    MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
    MyFrmListDist.Show()
    Me.Hide()
  End Sub
  Private Sub LnkDist_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkDist.LinkClicked
    MyFrmListDist = New FrmListDist
    MyFrmListDist.MdiParent = Me.ParentForm
    MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
    MyFrmListDist.Show()
    Me.Hide()
  End Sub
  Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtGLYear_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles TxtGLYear.Leave
    If TxtAppYear.Text = "" Then
      TxtAppYear.Text = TxtGLYear.Text
    End If
  End Sub
  Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAppYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAppYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Private Sub FrmTO103B_Load(sender As Object, e As EventArgs) Handles MyBase.Load

  End Sub
End Class






