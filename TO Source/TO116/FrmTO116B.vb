Public Class FrmTO116B
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
Friend WithEvents LnkDist As System.Windows.Forms.LinkLabel
Friend WithEvents LnkCodea As System.Windows.Forms.LinkLabel
Friend WithEvents TxtCodea As System.Windows.Forms.TextBox
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents LnkCodeb As System.Windows.Forms.LinkLabel
Friend WithEvents TxtCodeb As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTO116B))
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TxtDist = New System.Windows.Forms.TextBox
Me.LnkDist = New System.Windows.Forms.LinkLabel
Me.LnkCodea = New System.Windows.Forms.LinkLabel
Me.TxtCodea = New System.Windows.Forms.TextBox
Me.TxtGLYear = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.LnkCodeb = New System.Windows.Forms.LinkLabel
Me.TxtCodeb = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.Label2 = New System.Windows.Forms.Label
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
Me.TxtDist.Location = New System.Drawing.Point(128, 99)
Me.TxtDist.MaxLength = 3
Me.TxtDist.Name = "TxtDist"
Me.TxtDist.Size = New System.Drawing.Size(28, 20)
Me.TxtDist.TabIndex = 3
'
'LnkDist
'
Me.LnkDist.Location = New System.Drawing.Point(28, 102)
Me.LnkDist.Name = "LnkDist"
Me.LnkDist.Size = New System.Drawing.Size(46, 20)
Me.LnkDist.TabIndex = 69
Me.LnkDist.TabStop = True
Me.LnkDist.Text = "District"
'
'LnkCodea
'
Me.LnkCodea.Location = New System.Drawing.Point(28, 56)
Me.LnkCodea.Name = "LnkCodea"
Me.LnkCodea.Size = New System.Drawing.Size(61, 20)
Me.LnkCodea.TabIndex = 175
Me.LnkCodea.TabStop = True
Me.LnkCodea.Text = "15a Code"
'
'TxtCodea
'
Me.TxtCodea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtCodea.Location = New System.Drawing.Point(128, 53)
Me.TxtCodea.MaxLength = 3
Me.TxtCodea.Name = "TxtCodea"
Me.TxtCodea.Size = New System.Drawing.Size(24, 20)
Me.TxtCodea.TabIndex = 1
'
'TxtGLYear
'
Me.TxtGLYear.Location = New System.Drawing.Point(128, 22)
Me.TxtGLYear.MaxLength = 4
Me.TxtGLYear.Name = "TxtGLYear"
Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
Me.TxtGLYear.TabIndex = 0
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(28, 22)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(84, 16)
Me.Label4.TabIndex = 177
Me.Label4.Text = "Grand List Year"
'
'LnkCodeb
'
Me.LnkCodeb.Location = New System.Drawing.Point(28, 79)
Me.LnkCodeb.Name = "LnkCodeb"
Me.LnkCodeb.Size = New System.Drawing.Size(61, 20)
Me.LnkCodeb.TabIndex = 179
Me.LnkCodeb.TabStop = True
Me.LnkCodeb.Text = "15b Code"
'
'TxtCodeb
'
Me.TxtCodeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtCodeb.Location = New System.Drawing.Point(128, 76)
Me.TxtCodeb.MaxLength = 3
Me.TxtCodeb.Name = "TxtCodeb"
Me.TxtCodeb.Size = New System.Drawing.Size(24, 20)
Me.TxtCodeb.TabIndex = 2
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(158, 56)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(59, 17)
Me.Label1.TabIndex = 180
Me.Label1.Text = "(Optional)"
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(158, 76)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(59, 17)
Me.Label2.TabIndex = 181
Me.Label2.Text = "(Optional)"
'
'FrmTO116B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(228, 146)
Me.ControlBox = False
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.LnkCodeb)
Me.Controls.Add(Me.TxtCodeb)
Me.Controls.Add(Me.TxtGLYear)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.LnkCodea)
Me.Controls.Add(Me.TxtCodea)
Me.Controls.Add(Me.LnkDist)
Me.Controls.Add(Me.TxtDist)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTO116B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

  Public Sub RunReport()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
		MyTXDIST = New TXDIST.mydata(MyDBConnect)

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
Private Sub FrmTO116B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTO116.SbpScreen.Text = "TO116B"
End Sub
Private Sub FrmTO116B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLYear, "")
    ErrProv.SetError(TxtDist, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "year"
        ErrProv.SetError(TxtGLYear, ErrorMsg(I))
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
      ErrorField(I) = "year"
      ErrorMsg(I) = "G/L Year is required"
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
Private Sub LnkDist_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDist.LinkClicked
  MyFrmListDist = New FrmListDist
  MyFrmListDist.MdiParent = Me.ParentForm
  MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
  MyFrmListDist.Show()
  Me.Hide()
End Sub
Private Sub LnkCodea_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCodea.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = "P"
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCodea.Text)
    MyFrmListCodes.WrkField = "a"
    MyFrmListCodes.Show()
End Sub
Private Sub LnkCodeb_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCodeb.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = "P"
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCodeb.Text)
    MyFrmListCodes.WrkField = "b"
    MyFrmListCodes.Show()
End Sub
Private Sub TxtCodea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodea.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtCodeb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodeb.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub FrmTO116B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  TxtCodea.Text = ""
  TxtCodeb.Text = ""
End Sub
End Class






