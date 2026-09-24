Public Class FrmTA217B
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
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbLoc As System.Windows.Forms.RadioButton
Friend WithEvents RbMapDetail As System.Windows.Forms.RadioButton
Friend WithEvents RbMap As System.Windows.Forms.RadioButton
Friend WithEvents RbDist As System.Windows.Forms.RadioButton
Friend WithEvents RbName As System.Windows.Forms.RadioButton
Friend WithEvents ChkPrtDist As System.Windows.Forms.CheckBox
Friend WithEvents ChkFrozenFile As System.Windows.Forms.CheckBox
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTA217B))
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TxtDist = New System.Windows.Forms.TextBox
Me.LnkDist = New System.Windows.Forms.LinkLabel
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.RbName = New System.Windows.Forms.RadioButton
Me.RbLoc = New System.Windows.Forms.RadioButton
Me.RbMapDetail = New System.Windows.Forms.RadioButton
Me.RbMap = New System.Windows.Forms.RadioButton
Me.RbDist = New System.Windows.Forms.RadioButton
Me.ChkPrtDist = New System.Windows.Forms.CheckBox
Me.ChkFrozenFile = New System.Windows.Forms.CheckBox
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
Me.TxtDist.Location = New System.Drawing.Point(109, 171)
Me.TxtDist.MaxLength = 3
Me.TxtDist.Name = "TxtDist"
Me.TxtDist.Size = New System.Drawing.Size(28, 20)
Me.TxtDist.TabIndex = 1
'
'LnkDist
'
Me.LnkDist.Location = New System.Drawing.Point(41, 171)
Me.LnkDist.Name = "LnkDist"
Me.LnkDist.Size = New System.Drawing.Size(62, 20)
Me.LnkDist.TabIndex = 69
Me.LnkDist.TabStop = True
Me.LnkDist.Text = "District"
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.RbName)
Me.GroupBox1.Controls.Add(Me.RbLoc)
Me.GroupBox1.Controls.Add(Me.RbMapDetail)
Me.GroupBox1.Controls.Add(Me.RbMap)
Me.GroupBox1.Controls.Add(Me.RbDist)
Me.GroupBox1.Location = New System.Drawing.Point(21, 12)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(146, 135)
Me.GroupBox1.TabIndex = 0
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "Report Selection"
'
'RbName
'
Me.RbName.AutoSize = True
Me.RbName.Location = New System.Drawing.Point(16, 110)
Me.RbName.Name = "RbName"
Me.RbName.Size = New System.Drawing.Size(53, 17)
Me.RbName.TabIndex = 4
Me.RbName.Text = "Name"
Me.RbName.UseVisualStyleBackColor = True
'
'RbLoc
'
Me.RbLoc.AutoSize = True
Me.RbLoc.Checked = True
Me.RbLoc.Location = New System.Drawing.Point(16, 87)
Me.RbLoc.Name = "RbLoc"
Me.RbLoc.Size = New System.Drawing.Size(66, 17)
Me.RbLoc.TabIndex = 3
Me.RbLoc.TabStop = True
Me.RbLoc.Text = "Location"
Me.RbLoc.UseVisualStyleBackColor = True
'
'RbMapDetail
'
Me.RbMapDetail.AutoSize = True
Me.RbMapDetail.Enabled = False
Me.RbMapDetail.Location = New System.Drawing.Point(16, 65)
Me.RbMapDetail.Name = "RbMapDetail"
Me.RbMapDetail.Size = New System.Drawing.Size(101, 17)
Me.RbMapDetail.TabIndex = 2
Me.RbMapDetail.Text = "Map with details"
Me.RbMapDetail.UseVisualStyleBackColor = True
'
'RbMap
'
Me.RbMap.AutoSize = True
Me.RbMap.Location = New System.Drawing.Point(16, 42)
Me.RbMap.Name = "RbMap"
Me.RbMap.Size = New System.Drawing.Size(46, 17)
Me.RbMap.TabIndex = 1
Me.RbMap.Text = "Map"
Me.RbMap.UseVisualStyleBackColor = True
'
'RbDist
'
Me.RbDist.AutoSize = True
Me.RbDist.Location = New System.Drawing.Point(16, 19)
Me.RbDist.Name = "RbDist"
Me.RbDist.Size = New System.Drawing.Size(103, 17)
Me.RbDist.TabIndex = 0
Me.RbDist.Text = "District/Location"
Me.RbDist.UseVisualStyleBackColor = True
'
'ChkPrtDist
'
Me.ChkPrtDist.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkPrtDist.Location = New System.Drawing.Point(37, 197)
Me.ChkPrtDist.Name = "ChkPrtDist"
Me.ChkPrtDist.Size = New System.Drawing.Size(117, 17)
Me.ChkPrtDist.TabIndex = 70
Me.ChkPrtDist.Text = "Use Print Dist?"
'
'ChkFrozenFile
'
Me.ChkFrozenFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkFrozenFile.Location = New System.Drawing.Point(37, 220)
Me.ChkFrozenFile.Name = "ChkFrozenFile"
Me.ChkFrozenFile.Size = New System.Drawing.Size(117, 17)
Me.ChkFrozenFile.TabIndex = 71
Me.ChkFrozenFile.Text = "Use Frozen List?"
'
'FrmTA217B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(189, 272)
Me.ControlBox = False
Me.Controls.Add(Me.ChkFrozenFile)
Me.Controls.Add(Me.ChkPrtDist)
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.LnkDist)
Me.Controls.Add(Me.TxtDist)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA217B"
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
Private Sub FrmTA217B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA217.SbpScreen.Text = "TA217B"
End Sub
Private Sub FrmTA217B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtDist, "")

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
Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub RbLoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbLoc.Click
  MyFrmTA217.Text = "Real Estate by Location"
End Sub
Private Sub RbDist_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbDist.Click
  MyFrmTA217.Text = "Real Estate by District, Location"
End Sub
Private Sub RbMap_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbMap.Click
  MyFrmTA217.Text = "Real Estate by Map"
End Sub
Private Sub RbMapDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbMapDetail.Click
  MyFrmTA217.Text = "Real Estate by Map (Details)"
End Sub
End Class






