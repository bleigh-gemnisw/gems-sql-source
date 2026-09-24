Public Class FrmTA420B
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
  Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
  Friend WithEvents ChkUpdate As System.Windows.Forms.CheckBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents RbIncr As System.Windows.Forms.RadioButton
  Friend WithEvents RbDecr As System.Windows.Forms.RadioButton
  Friend WithEvents LblPct As System.Windows.Forms.Label
  Friend WithEvents TxtPct As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbSU As System.Windows.Forms.RadioButton
  Friend WithEvents RbMV As System.Windows.Forms.RadioButton
  Friend WithEvents LnkClass As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtClass As System.Windows.Forms.TextBox
  Friend WithEvents RbRegMV As System.Windows.Forms.RadioButton
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtToYear As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtFromYear As System.Windows.Forms.TextBox
  Friend WithEvents LblMinVal As Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTA420B))
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.ChkUpdate = New System.Windows.Forms.CheckBox()
    Me.RbMV = New System.Windows.Forms.RadioButton()
    Me.RbSU = New System.Windows.Forms.RadioButton()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbRegMV = New System.Windows.Forms.RadioButton()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.LblMinVal = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.RbIncr = New System.Windows.Forms.RadioButton()
    Me.RbDecr = New System.Windows.Forms.RadioButton()
    Me.LblPct = New System.Windows.Forms.Label()
    Me.TxtPct = New System.Windows.Forms.TextBox()
    Me.LnkClass = New System.Windows.Forms.LinkLabel()
    Me.TxtClass = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtFromYear = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtToYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
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
    'ChkUpdate
    '
    Me.ChkUpdate.AutoSize = True
    Me.ChkUpdate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkUpdate.Location = New System.Drawing.Point(18, 280)
    Me.ChkUpdate.Name = "ChkUpdate"
    Me.ChkUpdate.Size = New System.Drawing.Size(89, 17)
    Me.ChkUpdate.TabIndex = 5
    Me.ChkUpdate.Text = "Update File? "
    '
    'RbMV
    '
    Me.RbMV.AutoSize = True
    Me.RbMV.Enabled = False
    Me.RbMV.Location = New System.Drawing.Point(6, 19)
    Me.RbMV.Name = "RbMV"
    Me.RbMV.Size = New System.Drawing.Size(198, 17)
    Me.RbMV.TabIndex = 61
    Me.RbMV.Text = "Prior Year Regular Motor Vehicle File"
    Me.RbMV.UseVisualStyleBackColor = True
    '
    'RbSU
    '
    Me.RbSU.AutoSize = True
    Me.RbSU.Enabled = False
    Me.RbSU.Location = New System.Drawing.Point(6, 41)
    Me.RbSU.Name = "RbSU"
    Me.RbSU.Size = New System.Drawing.Size(217, 17)
    Me.RbSU.TabIndex = 62
    Me.RbSU.Text = "Prior Year Supplement Motor Vehicle File"
    Me.RbSU.UseVisualStyleBackColor = True
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbRegMV)
    Me.GroupBox1.Controls.Add(Me.RbSU)
    Me.GroupBox1.Controls.Add(Me.RbMV)
    Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(256, 87)
    Me.GroupBox1.TabIndex = 0
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Price Vehicles against"
    '
    'RbRegMV
    '
    Me.RbRegMV.AutoSize = True
    Me.RbRegMV.Checked = True
    Me.RbRegMV.Location = New System.Drawing.Point(6, 64)
    Me.RbRegMV.Name = "RbRegMV"
    Me.RbRegMV.Size = New System.Drawing.Size(192, 17)
    Me.RbRegMV.TabIndex = 63
    Me.RbRegMV.TabStop = True
    Me.RbRegMV.Text = "Regular Motor Vehicle File (Current)"
    Me.RbRegMV.UseVisualStyleBackColor = True
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.LblMinVal)
    Me.GroupBox2.Controls.Add(Me.Label2)
    Me.GroupBox2.Controls.Add(Me.RbIncr)
    Me.GroupBox2.Controls.Add(Me.RbDecr)
    Me.GroupBox2.Controls.Add(Me.LblPct)
    Me.GroupBox2.Controls.Add(Me.TxtPct)
    Me.GroupBox2.Location = New System.Drawing.Point(12, 105)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(256, 105)
    Me.GroupBox2.TabIndex = 1
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Set Values"
    '
    'LblMinVal
    '
    Me.LblMinVal.BackColor = System.Drawing.Color.Aqua
    Me.LblMinVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblMinVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMinVal.Location = New System.Drawing.Point(128, 75)
    Me.LblMinVal.Name = "LblMinVal"
    Me.LblMinVal.Size = New System.Drawing.Size(64, 16)
    Me.LblMinVal.TabIndex = 83
    Me.LblMinVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(6, 77)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(78, 13)
    Me.Label2.TabIndex = 69
    Me.Label2.Text = "Minimum Value"
    '
    'RbIncr
    '
    Me.RbIncr.AutoSize = True
    Me.RbIncr.Enabled = False
    Me.RbIncr.Location = New System.Drawing.Point(110, 19)
    Me.RbIncr.Name = "RbIncr"
    Me.RbIncr.Size = New System.Drawing.Size(66, 17)
    Me.RbIncr.TabIndex = 1
    Me.RbIncr.Text = "Increase"
    Me.RbIncr.UseVisualStyleBackColor = True
    '
    'RbDecr
    '
    Me.RbDecr.AutoSize = True
    Me.RbDecr.Checked = True
    Me.RbDecr.Enabled = False
    Me.RbDecr.Location = New System.Drawing.Point(13, 19)
    Me.RbDecr.Name = "RbDecr"
    Me.RbDecr.Size = New System.Drawing.Size(71, 17)
    Me.RbDecr.TabIndex = 0
    Me.RbDecr.TabStop = True
    Me.RbDecr.Text = "Decrease"
    Me.RbDecr.UseVisualStyleBackColor = True
    '
    'LblPct
    '
    Me.LblPct.AutoSize = True
    Me.LblPct.Enabled = False
    Me.LblPct.Location = New System.Drawing.Point(3, 49)
    Me.LblPct.Name = "LblPct"
    Me.LblPct.Size = New System.Drawing.Size(140, 13)
    Me.LblPct.TabIndex = 65
    Me.LblPct.Text = "Percent to Decrease Values"
    '
    'TxtPct
    '
    Me.TxtPct.Enabled = False
    Me.TxtPct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPct.Location = New System.Drawing.Point(154, 48)
    Me.TxtPct.MaxLength = 5
    Me.TxtPct.Name = "TxtPct"
    Me.TxtPct.Size = New System.Drawing.Size(38, 20)
    Me.TxtPct.TabIndex = 2
    Me.TxtPct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LnkClass
    '
    Me.LnkClass.AutoSize = True
    Me.LnkClass.Location = New System.Drawing.Point(18, 226)
    Me.LnkClass.Name = "LnkClass"
    Me.LnkClass.Size = New System.Drawing.Size(32, 13)
    Me.LnkClass.TabIndex = 1
    Me.LnkClass.TabStop = True
    Me.LnkClass.Text = "Class"
    '
    'TxtClass
    '
    Me.TxtClass.Location = New System.Drawing.Point(56, 223)
    Me.TxtClass.MaxLength = 2
    Me.TxtClass.Name = "TxtClass"
    Me.TxtClass.Size = New System.Drawing.Size(25, 20)
    Me.TxtClass.TabIndex = 2
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(87, 226)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(138, 13)
    Me.Label3.TabIndex = 71
    Me.Label3.Text = "(Blank= All except Class 25)"
    '
    'TxtFromYear
    '
    Me.TxtFromYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFromYear.Location = New System.Drawing.Point(72, 253)
    Me.TxtFromYear.MaxLength = 5
    Me.TxtFromYear.Name = "TxtFromYear"
    Me.TxtFromYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtFromYear.TabIndex = 3
    Me.TxtFromYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(18, 256)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(48, 13)
    Me.Label1.TabIndex = 73
    Me.Label1.Text = "MV Year"
    '
    'TxtToYear
    '
    Me.TxtToYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtToYear.Location = New System.Drawing.Point(141, 253)
    Me.TxtToYear.MaxLength = 5
    Me.TxtToYear.Name = "TxtToYear"
    Me.TxtToYear.Size = New System.Drawing.Size(30, 20)
    Me.TxtToYear.TabIndex = 4
    Me.TxtToYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(116, 256)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(16, 13)
    Me.Label4.TabIndex = 75
    Me.Label4.Text = "to"
    '
    'FrmTA420B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(280, 309)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtToYear)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtFromYear)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.LnkClass)
    Me.Controls.Add(Me.TxtClass)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.ChkUpdate)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA420B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
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

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    PrtReport()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub FrmTA420B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA420.SbpScreen.Text = "TA420B"
  End Sub
  Private Sub FrmTA420B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    ErrProv.Clear()
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "fromyear"
          ErrProv.SetError(TxtFromYear, ErrorMsg(I))
        Case "toyear"
          ErrProv.SetError(TxtToYear, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtFromYear.Text) > MyUtils.CnvSng(TxtToYear.Text) Then
      ErrorField(I) = "fromyear"
      ErrorMsg(I) = "Invalid Year range"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtToYear.Text) = 0 Or MyUtils.CnvSng(TxtToYear.Text) > Now.Year - 19 Then
      ErrorField(I) = "toyear"
      ErrorMsg(I) = "To year must be at least 20 years old"
      I = I + 1
    End If
  End Sub
  Private Sub TxtPct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPct.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub LnkClass_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkClass.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = "M"
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtClass.Text)
    MyFrmListCodes.Show()
    Me.Hide()
  End Sub
  Private Sub TxtClass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClass.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFromYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxToYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub RbDecr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbDecr.Click
    LblPct.Text = "Percent to Decrease Values"
  End Sub
  Private Sub RbIncr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbIncr.Click
    LblPct.Text = "Percent to Increase Values"
  End Sub
  Private Sub FrmTA420B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim myTXCTL As TXMCTL.MyData

    myTXCTL = New TXMCTL.MyData(myDBConnect)
    With myTXCTL
      .GetOneRecordP(1)
      If ._VALMIN > 0 Then
        LblMinVal.Text = ._VALMIN
      End If
    End With
    SetPrior(True)
  End Sub
  Private Sub SetPrior(WrkPrior As Boolean)
    'RbDecr.Enabled = WrkPrior
    'RbIncr.Enabled = WrkPrior
    'TxtPct.Enabled = WrkPrior
  End Sub
  Private Sub RbMV_Click(sender As Object, e As EventArgs) Handles RbMV.Click
    SetPrior(True)
  End Sub
  Private Sub RbSU_Click(sender As Object, e As EventArgs) Handles RbSU.Click
    SetPrior(True)
  End Sub
  Private Sub RbRegMV_Click(sender As Object, e As EventArgs) Handles RbRegMV.Click
    SetPrior(False)
  End Sub
End Class






