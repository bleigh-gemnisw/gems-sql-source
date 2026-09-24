Public Class FrmTA235B
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
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents ChkFrozenFile As System.Windows.Forms.CheckBox
Friend WithEvents ChkBAA As System.Windows.Forms.CheckBox
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTA235B))
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TxtDist = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.ChkFrozenFile = New System.Windows.Forms.CheckBox
Me.ChkBAA = New System.Windows.Forms.CheckBox
Me.TxtGLYear = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
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
Me.TxtDist.Location = New System.Drawing.Point(113, 43)
Me.TxtDist.MaxLength = 3
Me.TxtDist.Name = "TxtDist"
Me.TxtDist.Size = New System.Drawing.Size(28, 20)
Me.TxtDist.TabIndex = 1
'
'Label1
'
Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label1.Location = New System.Drawing.Point(25, 43)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(44, 16)
Me.Label1.TabIndex = 57
Me.Label1.Text = "District"
'
'ChkFrozenFile
'
Me.ChkFrozenFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkFrozenFile.Location = New System.Drawing.Point(28, 108)
Me.ChkFrozenFile.Name = "ChkFrozenFile"
Me.ChkFrozenFile.Size = New System.Drawing.Size(140, 16)
Me.ChkFrozenFile.TabIndex = 5
Me.ChkFrozenFile.Text = "Use Frozen List?"
'
'ChkBAA
'
Me.ChkBAA.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkBAA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.ChkBAA.Location = New System.Drawing.Point(28, 86)
Me.ChkBAA.Name = "ChkBAA"
Me.ChkBAA.Size = New System.Drawing.Size(140, 16)
Me.ChkBAA.TabIndex = 4
Me.ChkBAA.Text = "Include BAA Amounts?"
'
'TxtGLYear
'
Me.TxtGLYear.Location = New System.Drawing.Point(113, 19)
Me.TxtGLYear.MaxLength = 4
Me.TxtGLYear.Name = "TxtGLYear"
Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
Me.TxtGLYear.TabIndex = 0
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(25, 19)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(84, 16)
Me.Label4.TabIndex = 56
Me.Label4.Text = "Grand List Year"
'
'FrmTA235B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(189, 168)
Me.ControlBox = False
Me.Controls.Add(Me.TxtDist)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.ChkFrozenFile)
Me.Controls.Add(Me.ChkBAA)
Me.Controls.Add(Me.TxtGLYear)
Me.Controls.Add(Me.Label4)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA235B"
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
Private Sub FrmTA235B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Windows.Forms.Cursor.Current = Cursors.WaitCursor
  SetGLYear()
  Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub FrmTA235B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA235.SbpScreen.Text = "TA235B"
End Sub
Private Sub FrmTA235B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLYear, "")
    ErrProv.SetError(TxtDist, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "glyear"
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
      ErrorField(I) = "glyear"
      ErrorMsg(I) = "Grand List Year is required"
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
Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub ChkFrozenFile_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFrozenFile.CheckedChanged

End Sub
Private Sub SetGLYear()
    Dim WrkYear As Integer

    WrkYear = Date.Now.Year
    If Date.Now.Month < 10 Then
      WrkYear = WrkYear - 1
    End If
    TxtGLYear.Text = WrkYear
End Sub
End Class






