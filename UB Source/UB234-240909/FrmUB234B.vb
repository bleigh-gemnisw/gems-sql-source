Public Class FrmUB234B
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
  Friend WithEvents Label9 As Label
  Friend WithEvents LnkMeterSize As LinkLabel
  Friend WithEvents TxtMeterSize As TextBox
  Friend WithEvents Label2 As Label
  Friend WithEvents TxtPropCat As TextBox
  Friend WithEvents Label14 As Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUB234B))
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
    Me.Label9 = New System.Windows.Forms.Label()
    Me.LnkMeterSize = New System.Windows.Forms.LinkLabel()
    Me.TxtMeterSize = New System.Windows.Forms.TextBox()
    Me.TxtPropCat = New System.Windows.Forms.TextBox()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
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
    Me.LinkUBType.TabIndex = 6
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
    Me.TxtUBType.TabIndex = 2
    '
    'LnkDistrict
    '
    Me.LnkDistrict.AutoSize = True
    Me.LnkDistrict.Location = New System.Drawing.Point(23, 28)
    Me.LnkDistrict.Name = "LnkDistrict"
    Me.LnkDistrict.Size = New System.Drawing.Size(39, 13)
    Me.LnkDistrict.TabIndex = 5
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
    Me.TxtPhase.TabIndex = 1
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
    Me.TxtDist.TabIndex = 0
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
    Me.RbAddress.Location = New System.Drawing.Point(154, 147)
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
    Me.RbLoc.Location = New System.Drawing.Point(28, 147)
    Me.RbLoc.Name = "RbLoc"
    Me.RbLoc.Size = New System.Drawing.Size(108, 17)
    Me.RbLoc.TabIndex = 308
    Me.RbLoc.TabStop = True
    Me.RbLoc.Text = "Property Location"
    Me.RbLoc.UseVisualStyleBackColor = True
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(114, 90)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(50, 13)
    Me.Label9.TabIndex = 358
    Me.Label9.Text = "(optional)"
    '
    'LnkMeterSize
    '
    Me.LnkMeterSize.Location = New System.Drawing.Point(18, 87)
    Me.LnkMeterSize.Name = "LnkMeterSize"
    Me.LnkMeterSize.Size = New System.Drawing.Size(64, 16)
    Me.LnkMeterSize.TabIndex = 7
    Me.LnkMeterSize.TabStop = True
    Me.LnkMeterSize.Text = "Meter Size"
    '
    'TxtMeterSize
    '
    Me.TxtMeterSize.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMeterSize.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMeterSize.Location = New System.Drawing.Point(92, 83)
    Me.TxtMeterSize.MaxLength = 3
    Me.TxtMeterSize.Name = "TxtMeterSize"
    Me.TxtMeterSize.Size = New System.Drawing.Size(16, 22)
    Me.TxtMeterSize.TabIndex = 3
    '
    'TxtPropCat
    '
    Me.TxtPropCat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPropCat.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPropCat.Location = New System.Drawing.Point(116, 113)
    Me.TxtPropCat.MaxLength = 5
    Me.TxtPropCat.Name = "TxtPropCat"
    Me.TxtPropCat.Size = New System.Drawing.Size(48, 22)
    Me.TxtPropCat.TabIndex = 4
    '
    'Label14
    '
    Me.Label14.Location = New System.Drawing.Point(20, 117)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(96, 16)
    Me.Label14.TabIndex = 360
    Me.Label14.Text = "Property Category"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(170, 117)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(50, 13)
    Me.Label2.TabIndex = 361
    Me.Label2.Text = "(optional)"
    '
    'FrmUB234B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(290, 176)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtPropCat)
    Me.Controls.Add(Me.Label14)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.LnkMeterSize)
    Me.Controls.Add(Me.TxtMeterSize)
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
    Me.Name = "FrmUB234B"
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
  Private Sub FrmUB234B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmUB234.SbpScreen.Text = "UB234B"
  End Sub
  Private Sub FrmUB234B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
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

  Private Sub LnkMeterSize_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkMeterSize.LinkClicked
    MyFrmListMeterSize = New FrmListMeterSize
    MyFrmListMeterSize.MdiParent = Me.ParentForm
    MyFrmListMeterSize.WrkUBType = TxtUBType.Text
    MyFrmListMeterSize.WrkMeter = TxtMeterSize.Text
    MyFrmListMeterSize.Show()
    Me.Hide()
  End Sub

End Class






