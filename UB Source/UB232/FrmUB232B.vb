Public Class FrmUB232B
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
Friend WithEvents BtnSelCodes As System.Windows.Forms.Button
Friend WithEvents LblCodesComm As System.Windows.Forms.Label
Friend WithEvents RbAll As System.Windows.Forms.RadioButton
Friend WithEvents RbResid As System.Windows.Forms.RadioButton
Friend WithEvents RbMulti As System.Windows.Forms.RadioButton
Friend WithEvents RbMixed As System.Windows.Forms.RadioButton
Friend WithEvents RbExempt As System.Windows.Forms.RadioButton
Friend WithEvents RbComm As System.Windows.Forms.RadioButton
Friend WithEvents LblCodesResid As System.Windows.Forms.Label
Friend WithEvents LblCodesMulti As System.Windows.Forms.Label
Friend WithEvents LblCodesMixed As System.Windows.Forms.Label
Friend WithEvents LnkDistrict As System.Windows.Forms.LinkLabel
Friend WithEvents LinkUBType As System.Windows.Forms.LinkLabel
Friend WithEvents TxtUBType As System.Windows.Forms.TextBox
Friend WithEvents TxtPhase As System.Windows.Forms.TextBox
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUB232B))
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.BtnSelCodes = New System.Windows.Forms.Button()
    Me.LblCodesComm = New System.Windows.Forms.Label()
    Me.RbComm = New System.Windows.Forms.RadioButton()
    Me.RbExempt = New System.Windows.Forms.RadioButton()
    Me.RbMixed = New System.Windows.Forms.RadioButton()
    Me.RbMulti = New System.Windows.Forms.RadioButton()
    Me.RbResid = New System.Windows.Forms.RadioButton()
    Me.RbAll = New System.Windows.Forms.RadioButton()
    Me.LblCodesMixed = New System.Windows.Forms.Label()
    Me.LblCodesMulti = New System.Windows.Forms.Label()
    Me.LblCodesResid = New System.Windows.Forms.Label()
    Me.LnkDistrict = New System.Windows.Forms.LinkLabel()
    Me.LinkUBType = New System.Windows.Forms.LinkLabel()
    Me.TxtUBType = New System.Windows.Forms.TextBox()
    Me.TxtPhase = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtDist = New System.Windows.Forms.TextBox()
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
    'BtnSelCodes
    '
    Me.BtnSelCodes.Location = New System.Drawing.Point(26, 225)
    Me.BtnSelCodes.Name = "BtnSelCodes"
    Me.BtnSelCodes.Size = New System.Drawing.Size(87, 21)
    Me.BtnSelCodes.TabIndex = 11
    Me.BtnSelCodes.Text = "Select Codes"
    Me.BtnSelCodes.UseVisualStyleBackColor = True
    '
    'LblCodesComm
    '
    Me.LblCodesComm.AutoSize = True
    Me.LblCodesComm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCodesComm.ForeColor = System.Drawing.Color.Black
    Me.LblCodesComm.Location = New System.Drawing.Point(122, 100)
    Me.LblCodesComm.Name = "LblCodesComm"
    Me.LblCodesComm.Size = New System.Drawing.Size(73, 13)
    Me.LblCodesComm.TabIndex = 208
    Me.LblCodesComm.Text = "<Commercial>"
    Me.LblCodesComm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'RbComm
    '
    Me.RbComm.AutoSize = True
    Me.RbComm.Location = New System.Drawing.Point(26, 100)
    Me.RbComm.Name = "RbComm"
    Me.RbComm.Size = New System.Drawing.Size(79, 17)
    Me.RbComm.TabIndex = 6
    Me.RbComm.Text = "Commercial"
    Me.RbComm.UseVisualStyleBackColor = True
    '
    'RbExempt
    '
    Me.RbExempt.AutoSize = True
    Me.RbExempt.Location = New System.Drawing.Point(26, 123)
    Me.RbExempt.Name = "RbExempt"
    Me.RbExempt.Size = New System.Drawing.Size(60, 17)
    Me.RbExempt.TabIndex = 7
    Me.RbExempt.Text = "Exempt"
    Me.RbExempt.UseVisualStyleBackColor = True
    '
    'RbMixed
    '
    Me.RbMixed.AutoSize = True
    Me.RbMixed.Location = New System.Drawing.Point(26, 146)
    Me.RbMixed.Name = "RbMixed"
    Me.RbMixed.Size = New System.Drawing.Size(53, 17)
    Me.RbMixed.TabIndex = 8
    Me.RbMixed.Text = "Mixed"
    Me.RbMixed.UseVisualStyleBackColor = True
    '
    'RbMulti
    '
    Me.RbMulti.AutoSize = True
    Me.RbMulti.Location = New System.Drawing.Point(26, 169)
    Me.RbMulti.Name = "RbMulti"
    Me.RbMulti.Size = New System.Drawing.Size(76, 17)
    Me.RbMulti.TabIndex = 9
    Me.RbMulti.Text = "MultiFamily"
    Me.RbMulti.UseVisualStyleBackColor = True
    '
    'RbResid
    '
    Me.RbResid.AutoSize = True
    Me.RbResid.Location = New System.Drawing.Point(26, 192)
    Me.RbResid.Name = "RbResid"
    Me.RbResid.Size = New System.Drawing.Size(77, 17)
    Me.RbResid.TabIndex = 10
    Me.RbResid.Text = "Residential"
    Me.RbResid.UseVisualStyleBackColor = True
    '
    'RbAll
    '
    Me.RbAll.AutoSize = True
    Me.RbAll.Checked = True
    Me.RbAll.Location = New System.Drawing.Point(26, 77)
    Me.RbAll.Name = "RbAll"
    Me.RbAll.Size = New System.Drawing.Size(103, 17)
    Me.RbAll.TabIndex = 5
    Me.RbAll.TabStop = True
    Me.RbAll.Text = "All (Non Exempt)"
    Me.RbAll.UseVisualStyleBackColor = True
    '
    'LblCodesMixed
    '
    Me.LblCodesMixed.AutoSize = True
    Me.LblCodesMixed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCodesMixed.ForeColor = System.Drawing.Color.Black
    Me.LblCodesMixed.Location = New System.Drawing.Point(122, 150)
    Me.LblCodesMixed.Name = "LblCodesMixed"
    Me.LblCodesMixed.Size = New System.Drawing.Size(47, 13)
    Me.LblCodesMixed.TabIndex = 215
    Me.LblCodesMixed.Text = "<Mixed>"
    Me.LblCodesMixed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblCodesMulti
    '
    Me.LblCodesMulti.AutoSize = True
    Me.LblCodesMulti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCodesMulti.ForeColor = System.Drawing.Color.Black
    Me.LblCodesMulti.Location = New System.Drawing.Point(122, 173)
    Me.LblCodesMulti.Name = "LblCodesMulti"
    Me.LblCodesMulti.Size = New System.Drawing.Size(73, 13)
    Me.LblCodesMulti.TabIndex = 216
    Me.LblCodesMulti.Text = "<Multi-Family>"
    Me.LblCodesMulti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblCodesResid
    '
    Me.LblCodesResid.AutoSize = True
    Me.LblCodesResid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCodesResid.ForeColor = System.Drawing.Color.Black
    Me.LblCodesResid.Location = New System.Drawing.Point(122, 192)
    Me.LblCodesResid.Name = "LblCodesResid"
    Me.LblCodesResid.Size = New System.Drawing.Size(71, 13)
    Me.LblCodesResid.TabIndex = 217
    Me.LblCodesResid.Text = "<Residential>"
    Me.LblCodesResid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LnkDistrict
    '
    Me.LnkDistrict.Location = New System.Drawing.Point(23, 19)
    Me.LnkDistrict.Name = "LnkDistrict"
    Me.LnkDistrict.Size = New System.Drawing.Size(40, 16)
    Me.LnkDistrict.TabIndex = 0
    Me.LnkDistrict.TabStop = True
    Me.LnkDistrict.Text = "District"
    '
    'LinkUBType
    '
    Me.LinkUBType.Location = New System.Drawing.Point(23, 43)
    Me.LinkUBType.Name = "LinkUBType"
    Me.LinkUBType.Size = New System.Drawing.Size(68, 16)
    Me.LinkUBType.TabIndex = 3
    Me.LinkUBType.TabStop = True
    Me.LinkUBType.Text = "Bill Type"
    '
    'TxtUBType
    '
    Me.TxtUBType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUBType.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUBType.Location = New System.Drawing.Point(131, 39)
    Me.TxtUBType.MaxLength = 2
    Me.TxtUBType.Name = "TxtUBType"
    Me.TxtUBType.Size = New System.Drawing.Size(24, 22)
    Me.TxtUBType.TabIndex = 4
    '
    'TxtPhase
    '
    Me.TxtPhase.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPhase.Location = New System.Drawing.Point(219, 15)
    Me.TxtPhase.MaxLength = 1
    Me.TxtPhase.Name = "TxtPhase"
    Me.TxtPhase.Size = New System.Drawing.Size(16, 22)
    Me.TxtPhase.TabIndex = 2
    '
    'Label6
    '
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(175, 15)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(44, 16)
    Me.Label6.TabIndex = 301
    Me.Label6.Text = "Phase"
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(131, 15)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(28, 22)
    Me.TxtDist.TabIndex = 1
    '
    'FrmUB232B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(290, 258)
    Me.ControlBox = False
    Me.Controls.Add(Me.LnkDistrict)
    Me.Controls.Add(Me.LinkUBType)
    Me.Controls.Add(Me.TxtUBType)
    Me.Controls.Add(Me.TxtPhase)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.LblCodesResid)
    Me.Controls.Add(Me.LblCodesMulti)
    Me.Controls.Add(Me.LblCodesMixed)
    Me.Controls.Add(Me.RbAll)
    Me.Controls.Add(Me.RbResid)
    Me.Controls.Add(Me.RbMulti)
    Me.Controls.Add(Me.RbMixed)
    Me.Controls.Add(Me.RbExempt)
    Me.Controls.Add(Me.RbComm)
    Me.Controls.Add(Me.LblCodesComm)
    Me.Controls.Add(Me.BtnSelCodes)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmUB232B"
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
    If MyAppSettings.Commercial <> LblCodesComm.Text Or MyAppSettings.Mixed <> LblCodesMixed.Text _
     Or MyAppSettings.MultiFamily <> LblCodesMulti.Text Or MyAppSettings.Residential <> LblCodesResid.Text Then
      MyAppSettings.Commercial = LblCodesComm.Text
      MyAppSettings.Mixed = LblCodesMixed.Text
      MyAppSettings.MultiFamily = LblCodesMulti.Text
      MyAppSettings.Residential = LblCodesResid.Text
      SaveAppSettings()
    End If
    PrtReport()
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
Private Sub FrmUB232B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB232.SbpScreen.Text = "UB232B"
End Sub
Private Sub FrmUB232B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
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

    MyUTTYPE.GetOneRecordP(TxtUBType.Text)
    If MyUTTYPE.RecordNotFound Then
      ErrorField(I) = "ubtype"
      ErrorMsg(I) = "Invalid Bill Type"
      I = I + 1
    End If

  End Sub
Private Sub BtnSelCodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelCodes.Click
    MyFrmSelCodes = New FrmSelCodes
    MyFrmSelCodes.ShowDialog()
    If RbComm.Checked Then LblCodesComm.Text = MySelCodes
    If RbMixed.Checked Then LblCodesMixed.Text = MySelCodes
    If RbMulti.Checked Then LblCodesMulti.Text = MySelCodes
    If RbResid.Checked Then LblCodesResid.Text = MySelCodes
End Sub
Private Sub FrmUB232B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  MySelCodes = String.Empty
  BtnSelCodes.Visible = False
  LblCodesComm.Text = MyAppSettings.Commercial
  LblCodesMixed.Text = MyAppSettings.Mixed
  LblCodesMulti.Text = MyAppSettings.MultiFamily
  LblCodesResid.Text = MyAppSettings.Residential
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
Private Sub LinkUBType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkUBType.LinkClicked
  MyFrmListUBType = New FrmListUBType
  MyFrmListUBType.MdiParent = Me.ParentForm
  MyFrmListUBType.WrkType = TxtUBType.Text
  MyFrmListUBType.Show()
  Me.Hide()
End Sub
Private Sub RbAll_Click(sender As Object, e As EventArgs) Handles RbAll.Click
  BtnSelCodes.Visible = False
  MySelCodes = ""
End Sub
Private Sub RbComm_Click(sender As Object, e As EventArgs) Handles RbComm.Click
  BtnSelCodes.Visible = True
  MySelCodes = MyAppSettings.Commercial
End Sub
Private Sub RbExempt_Click(sender As Object, e As EventArgs) Handles RbExempt.Click
  BtnSelCodes.Visible = False
  MySelCodes = ""
End Sub
Private Sub RbMixed_Click(sender As Object, e As EventArgs) Handles RbMixed.Click
  BtnSelCodes.Visible = True
  MySelCodes = MyAppSettings.Mixed
End Sub
Private Sub RbMulti_Click(sender As Object, e As EventArgs) Handles RbMulti.Click
  BtnSelCodes.Visible = True
  MySelCodes = MyAppSettings.MultiFamily
End Sub
Private Sub RbResid_Click(sender As Object, e As EventArgs) Handles RbResid.Click
  BtnSelCodes.Visible = True
  MySelCodes = MyAppSettings.Residential
End Sub

Private Sub RbMixed_CheckedChanged(sender As Object, e As EventArgs) Handles RbMixed.CheckedChanged

End Sub
End Class






