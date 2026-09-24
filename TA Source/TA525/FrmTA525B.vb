Public Class FrmTA525B
Inherits System.Windows.Forms.Form
Dim Mytxdist As TXDIST.myData
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
  Friend WithEvents LnkDist As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtCurrYear As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTA525B))
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.LnkDist = New System.Windows.Forms.LinkLabel()
    Me.TxtCurrYear = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
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
    Me.TxtDist.Location = New System.Drawing.Point(76, 67)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(28, 20)
    Me.TxtDist.TabIndex = 3
    '
    'LnkDist
    '
    Me.LnkDist.AutoSize = True
    Me.LnkDist.Location = New System.Drawing.Point(24, 70)
    Me.LnkDist.Name = "LnkDist"
    Me.LnkDist.Size = New System.Drawing.Size(39, 13)
    Me.LnkDist.TabIndex = 2
    Me.LnkDist.TabStop = True
    Me.LnkDist.Text = "District"
    '
    'TxtCurrYear
    '
    Me.TxtCurrYear.Location = New System.Drawing.Point(125, 42)
    Me.TxtCurrYear.MaxLength = 4
    Me.TxtCurrYear.Name = "TxtCurrYear"
    Me.TxtCurrYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtCurrYear.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(24, 45)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(88, 13)
    Me.Label1.TabIndex = 71
    Me.Label1.Text = "Current G/L Year"
    '
    'FrmTA525B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(215, 147)
    Me.ControlBox = False
    Me.Controls.Add(Me.TxtCurrYear)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LnkDist)
    Me.Controls.Add(Me.TxtDist)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA525B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Public Sub RunReport()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    Mytxdist = New TXDIST.mydata(MyDBConnect)

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
  Private Sub FrmTA525B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA525.SbpScreen.Text = "TA525B"
  End Sub
  Private Sub FrmTA525B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.Clear()

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "dist"
          ErrProv.SetError(TxtDist, ErrorMsg(I))
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
    If MyUtils.CnvSng(TxtDist.Text) <> 0 Then
      Mytxdist.GetOneRecordP(MyUtils.CnvSng(TxtDist.Text))
      If Mytxdist.RecordNotFound Then
        ErrorField(I) = "dist"
        ErrorMsg(I) = "Invalid District"
        I = I + 1
      End If
    End If


  End Sub
  Private Sub LnkDist_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDist.LinkClicked
    MyFrmListDist = New FrmListDist
    MyFrmListDist.MdiParent = Me.ParentForm
    MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
    MyFrmListDist.Show()
    Me.Hide()
  End Sub
  Private Sub TxtCurrYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCurrYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






