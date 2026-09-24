Public Class FrmUB233B
Inherits System.Windows.Forms.Form
Dim MyUTTYPE As UTTYPE.myData
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
Friend WithEvents LinkUBType As System.Windows.Forms.LinkLabel
Friend WithEvents TxtUBType As System.Windows.Forms.TextBox
Friend WithEvents LnkDistrict As System.Windows.Forms.LinkLabel
Friend WithEvents TxtPhase As System.Windows.Forms.TextBox
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents RbLoc As System.Windows.Forms.RadioButton
Friend WithEvents RbAddress As System.Windows.Forms.RadioButton
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUB233B))
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.LinkUBType = New System.Windows.Forms.LinkLabel()
    Me.TxtUBType = New System.Windows.Forms.TextBox()
    Me.LnkDistrict = New System.Windows.Forms.LinkLabel()
    Me.TxtPhase = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.RbAddress = New System.Windows.Forms.RadioButton()
    Me.RbLoc = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    Me.ImageList1.Images.SetKeyName(1, "select type_24.png")
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LinkUBType
    '
    Me.LinkUBType.AutoSize = True
    Me.LinkUBType.Location = New System.Drawing.Point(23, 58)
    Me.LinkUBType.Name = "LinkUBType"
    Me.LinkUBType.Size = New System.Drawing.Size(47, 13)
    Me.LinkUBType.TabIndex = 3
    Me.LinkUBType.TabStop = True
    Me.LinkUBType.Text = "Bill Type"
    '
    'TxtUBType
    '
    Me.TxtUBType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUBType.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUBType.Location = New System.Drawing.Point(92, 54)
    Me.TxtUBType.MaxLength = 2
    Me.TxtUBType.Name = "TxtUBType"
    Me.TxtUBType.Size = New System.Drawing.Size(24, 22)
    Me.TxtUBType.TabIndex = 4
    '
    'LnkDistrict
    '
    Me.LnkDistrict.AutoSize = True
    Me.LnkDistrict.Location = New System.Drawing.Point(23, 28)
    Me.LnkDistrict.Name = "LnkDistrict"
    Me.LnkDistrict.Size = New System.Drawing.Size(39, 13)
    Me.LnkDistrict.TabIndex = 302
    Me.LnkDistrict.TabStop = True
    Me.LnkDistrict.Text = "District"
    '
    'TxtPhase
    '
    Me.TxtPhase.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPhase.Location = New System.Drawing.Point(180, 24)
    Me.TxtPhase.MaxLength = 1
    Me.TxtPhase.Name = "TxtPhase"
    Me.TxtPhase.Size = New System.Drawing.Size(16, 22)
    Me.TxtPhase.TabIndex = 304
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(137, 28)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(37, 13)
    Me.Label6.TabIndex = 305
    Me.Label6.Text = "Phase"
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(92, 24)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(28, 22)
    Me.TxtDist.TabIndex = 303
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(122, 58)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(52, 13)
    Me.Label1.TabIndex = 306
    Me.Label1.Text = "(Optional)"
    '
    'RbAddress
    '
    Me.RbAddress.AutoSize = True
    Me.RbAddress.Location = New System.Drawing.Point(152, 94)
    Me.RbAddress.Name = "RbAddress"
    Me.RbAddress.Size = New System.Drawing.Size(63, 17)
    Me.RbAddress.TabIndex = 307
    Me.RbAddress.Text = "Address"
    Me.RbAddress.UseVisualStyleBackColor = True
    '
    'RbLoc
    '
    Me.RbLoc.AutoSize = True
    Me.RbLoc.Checked = True
    Me.RbLoc.Location = New System.Drawing.Point(26, 94)
    Me.RbLoc.Name = "RbLoc"
    Me.RbLoc.Size = New System.Drawing.Size(108, 17)
    Me.RbLoc.TabIndex = 308
    Me.RbLoc.TabStop = True
    Me.RbLoc.Text = "Property Location"
    Me.RbLoc.UseVisualStyleBackColor = True
    '
    'FrmUB233B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(290, 132)
    Me.ControlBox = False
    Me.Controls.Add(Me.RbLoc)
    Me.Controls.Add(Me.RbAddress)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LnkDistrict)
    Me.Controls.Add(Me.TxtPhase)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.LinkUBType)
    Me.Controls.Add(Me.TxtUBType)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmUB233B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

  Public Sub RunReport()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    MyUTTYPE = New UTTYPE.mydata(MyDBConnect)

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
Private Sub FrmUB233B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB233.SbpScreen.Text = "UB233B"
End Sub
Private Sub FrmUB233B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtUBType, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "ubtype"
        ErrProv.SetError(TxtUBType, ErrorMsg(I))
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

    If TxtUBType.Text <> "" Then
      MyUTTYPE.GetOneRecordP(TxtUBType.Text)
      If MyUTTYPE.RecordNotFound Then
        ErrorField(I) = "ubtype"
        ErrorMsg(I) = "Invalid Bill Type"
        I = I + 1
      End If
    End If

  End Sub
Private Sub LinkUBType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkUBType.LinkClicked
  MyFrmListUBType = New FrmListUBType
  MyFrmListUBType.MdiParent = Me.ParentForm
  MyFrmListUBType.WrkType = TxtUBType.Text
  MyFrmListUBType.Show()
  Me.Hide()
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtPhase_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPhase.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub LnkDistrict_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDistrict.LinkClicked
  MyFrmListDist = New FrmListDist
  MyFrmListDist.MdiParent = Me.ParentForm
  MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
  MyFrmListDist.WrkPhase = MyUtils.CnvSng(TxtPhase.Text)
  MyFrmListDist.Show()
  Me.Hide()
End Sub
End Class






