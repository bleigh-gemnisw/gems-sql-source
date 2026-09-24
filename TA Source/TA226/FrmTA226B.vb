Public Class FrmTA226B
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
Friend WithEvents ChkFrozenFile As System.Windows.Forms.CheckBox
Friend WithEvents LnkDist As System.Windows.Forms.LinkLabel
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtVetYear As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents LnkExempt5 As System.Windows.Forms.LinkLabel
Friend WithEvents TxtExempt5 As System.Windows.Forms.TextBox
Friend WithEvents LnkExempt3 As System.Windows.Forms.LinkLabel
Friend WithEvents TxtExempt3 As System.Windows.Forms.TextBox
Friend WithEvents LnkExempt4 As System.Windows.Forms.LinkLabel
Friend WithEvents TxtExempt4 As System.Windows.Forms.TextBox
Friend WithEvents LnkExempt2 As System.Windows.Forms.LinkLabel
Friend WithEvents TxtExempt2 As System.Windows.Forms.TextBox
Friend WithEvents LnkExempt1 As System.Windows.Forms.LinkLabel
Friend WithEvents TxtExempt1 As System.Windows.Forms.TextBox
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTA226B))
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TxtDist = New System.Windows.Forms.TextBox
Me.TxtGLYear = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.ChkFrozenFile = New System.Windows.Forms.CheckBox
Me.LnkDist = New System.Windows.Forms.LinkLabel
Me.TxtVetYear = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.Label2 = New System.Windows.Forms.Label
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.LnkExempt5 = New System.Windows.Forms.LinkLabel
Me.TxtExempt5 = New System.Windows.Forms.TextBox
Me.LnkExempt3 = New System.Windows.Forms.LinkLabel
Me.TxtExempt3 = New System.Windows.Forms.TextBox
Me.LnkExempt4 = New System.Windows.Forms.LinkLabel
Me.TxtExempt4 = New System.Windows.Forms.TextBox
Me.LnkExempt2 = New System.Windows.Forms.LinkLabel
Me.TxtExempt2 = New System.Windows.Forms.TextBox
Me.LnkExempt1 = New System.Windows.Forms.LinkLabel
Me.TxtExempt1 = New System.Windows.Forms.TextBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox1.SuspendLayout()
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
Me.TxtDist.Location = New System.Drawing.Point(125, 85)
Me.TxtDist.MaxLength = 3
Me.TxtDist.Name = "TxtDist"
Me.TxtDist.Size = New System.Drawing.Size(28, 20)
Me.TxtDist.TabIndex = 2
'
'TxtGLYear
'
Me.TxtGLYear.Location = New System.Drawing.Point(125, 30)
Me.TxtGLYear.MaxLength = 4
Me.TxtGLYear.Name = "TxtGLYear"
Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
Me.TxtGLYear.TabIndex = 0
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(15, 34)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(84, 16)
Me.Label4.TabIndex = 56
Me.Label4.Text = "Grand List Year"
'
'ChkFrozenFile
'
Me.ChkFrozenFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkFrozenFile.Location = New System.Drawing.Point(22, 120)
Me.ChkFrozenFile.Name = "ChkFrozenFile"
Me.ChkFrozenFile.Size = New System.Drawing.Size(122, 15)
Me.ChkFrozenFile.TabIndex = 3
Me.ChkFrozenFile.Text = "Use Frozen List?"
'
'LnkDist
'
Me.LnkDist.Location = New System.Drawing.Point(19, 89)
Me.LnkDist.Name = "LnkDist"
Me.LnkDist.Size = New System.Drawing.Size(80, 16)
Me.LnkDist.TabIndex = 69
Me.LnkDist.TabStop = True
Me.LnkDist.Text = "District"
'
'TxtVetYear
'
Me.TxtVetYear.Location = New System.Drawing.Point(125, 57)
Me.TxtVetYear.MaxLength = 4
Me.TxtVetYear.Name = "TxtVetYear"
Me.TxtVetYear.Size = New System.Drawing.Size(32, 20)
Me.TxtVetYear.TabIndex = 1
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(15, 60)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(113, 17)
Me.Label1.TabIndex = 71
Me.Label1.Text = "Vet Application Year"
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(163, 60)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(55, 19)
Me.Label2.TabIndex = 72
Me.Label2.Text = "(Optional)"
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.LnkExempt5)
Me.GroupBox1.Controls.Add(Me.TxtExempt5)
Me.GroupBox1.Controls.Add(Me.LnkExempt3)
Me.GroupBox1.Controls.Add(Me.TxtExempt3)
Me.GroupBox1.Controls.Add(Me.LnkExempt4)
Me.GroupBox1.Controls.Add(Me.TxtExempt4)
Me.GroupBox1.Controls.Add(Me.LnkExempt2)
Me.GroupBox1.Controls.Add(Me.TxtExempt2)
Me.GroupBox1.Controls.Add(Me.LnkExempt1)
Me.GroupBox1.Controls.Add(Me.TxtExempt1)
Me.GroupBox1.ForeColor = System.Drawing.Color.Black
Me.GroupBox1.Location = New System.Drawing.Point(22, 141)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(165, 144)
Me.GroupBox1.TabIndex = 4
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "Select Exemptions (optional)"
'
'LnkExempt5
'
Me.LnkExempt5.Location = New System.Drawing.Point(50, 118)
Me.LnkExempt5.Name = "LnkExempt5"
Me.LnkExempt5.Size = New System.Drawing.Size(24, 16)
Me.LnkExempt5.TabIndex = 199
Me.LnkExempt5.TabStop = True
Me.LnkExempt5.Text = "5"
'
'TxtExempt5
'
Me.TxtExempt5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtExempt5.Location = New System.Drawing.Point(74, 118)
Me.TxtExempt5.MaxLength = 3
Me.TxtExempt5.Name = "TxtExempt5"
Me.TxtExempt5.Size = New System.Drawing.Size(32, 20)
Me.TxtExempt5.TabIndex = 5
'
'LnkExempt3
'
Me.LnkExempt3.Location = New System.Drawing.Point(50, 66)
Me.LnkExempt3.Name = "LnkExempt3"
Me.LnkExempt3.Size = New System.Drawing.Size(24, 16)
Me.LnkExempt3.TabIndex = 198
Me.LnkExempt3.TabStop = True
Me.LnkExempt3.Text = "3"
'
'TxtExempt3
'
Me.TxtExempt3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtExempt3.Location = New System.Drawing.Point(74, 66)
Me.TxtExempt3.MaxLength = 3
Me.TxtExempt3.Name = "TxtExempt3"
Me.TxtExempt3.Size = New System.Drawing.Size(32, 20)
Me.TxtExempt3.TabIndex = 3
'
'LnkExempt4
'
Me.LnkExempt4.Location = New System.Drawing.Point(50, 92)
Me.LnkExempt4.Name = "LnkExempt4"
Me.LnkExempt4.Size = New System.Drawing.Size(24, 16)
Me.LnkExempt4.TabIndex = 197
Me.LnkExempt4.TabStop = True
Me.LnkExempt4.Text = "4"
'
'TxtExempt4
'
Me.TxtExempt4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtExempt4.Location = New System.Drawing.Point(74, 92)
Me.TxtExempt4.MaxLength = 3
Me.TxtExempt4.Name = "TxtExempt4"
Me.TxtExempt4.Size = New System.Drawing.Size(32, 20)
Me.TxtExempt4.TabIndex = 4
'
'LnkExempt2
'
Me.LnkExempt2.Location = New System.Drawing.Point(50, 40)
Me.LnkExempt2.Name = "LnkExempt2"
Me.LnkExempt2.Size = New System.Drawing.Size(24, 16)
Me.LnkExempt2.TabIndex = 196
Me.LnkExempt2.TabStop = True
Me.LnkExempt2.Text = "2"
'
'TxtExempt2
'
Me.TxtExempt2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtExempt2.Location = New System.Drawing.Point(74, 40)
Me.TxtExempt2.MaxLength = 3
Me.TxtExempt2.Name = "TxtExempt2"
Me.TxtExempt2.Size = New System.Drawing.Size(32, 20)
Me.TxtExempt2.TabIndex = 2
'
'LnkExempt1
'
Me.LnkExempt1.Location = New System.Drawing.Point(50, 17)
Me.LnkExempt1.Name = "LnkExempt1"
Me.LnkExempt1.Size = New System.Drawing.Size(24, 16)
Me.LnkExempt1.TabIndex = 0
Me.LnkExempt1.TabStop = True
Me.LnkExempt1.Text = "1"
'
'TxtExempt1
'
Me.TxtExempt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtExempt1.Location = New System.Drawing.Point(74, 17)
Me.TxtExempt1.MaxLength = 3
Me.TxtExempt1.Name = "TxtExempt1"
Me.TxtExempt1.Size = New System.Drawing.Size(32, 20)
Me.TxtExempt1.TabIndex = 1
'
'FrmTA226B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(224, 297)
Me.ControlBox = False
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.TxtVetYear)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.LnkDist)
Me.Controls.Add(Me.TxtDist)
Me.Controls.Add(Me.ChkFrozenFile)
Me.Controls.Add(Me.TxtGLYear)
Me.Controls.Add(Me.Label4)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA226B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox1.ResumeLayout(False)
Me.GroupBox1.PerformLayout()
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
Private Sub FrmTA226B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA226.SbpScreen.Text = "TA226B"
End Sub
Private Sub FrmTA226B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLYear, "")

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
Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtAppYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub FrmTA226B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

End Sub
  Private Sub LnkExempt1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt1.LinkClicked
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkFieldNo = LnkExempt1.Text
    MyFrmListExemption.WrkCode = TxtExempt1.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt2.LinkClicked
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkFieldNo = LnkExempt2.Text
    MyFrmListExemption.WrkCode = TxtExempt2.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt3.LinkClicked
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkFieldNo = LnkExempt3.Text
    MyFrmListExemption.WrkCode = TxtExempt3.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt4.LinkClicked
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkFieldNo = LnkExempt4.Text
    MyFrmListExemption.WrkCode = TxtExempt4.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt5.LinkClicked
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkFieldNo = LnkExempt5.Text
    MyFrmListExemption.WrkCode = TxtExempt5.Text
    MyFrmListExemption.Show()
  End Sub
End Class






