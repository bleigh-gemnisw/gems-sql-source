Public Class FrmTA810_NEW
  Inherits System.Windows.Forms.Form
  Dim WrkType As String
 Friend WithEvents Label2 As System.Windows.Forms.Label
 Friend WithEvents GrpOpenCC As System.Windows.Forms.GroupBox
 Friend WithEvents Label3 As System.Windows.Forms.Label
 Friend WithEvents TxtYear As System.Windows.Forms.TextBox
 Friend WithEvents Label5 As System.Windows.Forms.Label
 Friend WithEvents Label4 As System.Windows.Forms.Label
 Friend WithEvents TxtCCNo As System.Windows.Forms.TextBox
 Friend WithEvents DtPckCC As System.Windows.Forms.DateTimePicker
  Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RbSU As RadioButton
    Dim WrkContinue As Boolean

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
  Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents LblYearTxt As System.Windows.Forms.Label
  Friend WithEvents BtnContinue As System.Windows.Forms.Button
  Friend WithEvents LnkListNo As System.Windows.Forms.LinkLabel
  Friend WithEvents RbRE As System.Windows.Forms.RadioButton
  Friend WithEvents RbPP As System.Windows.Forms.RadioButton
  Friend WithEvents RbMV As System.Windows.Forms.RadioButton
Friend WithEvents LblYear As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.BtnContinue = New System.Windows.Forms.Button()
    Me.LblYearTxt = New System.Windows.Forms.Label()
    Me.LnkListNo = New System.Windows.Forms.LinkLabel()
    Me.RbRE = New System.Windows.Forms.RadioButton()
    Me.RbPP = New System.Windows.Forms.RadioButton()
    Me.RbMV = New System.Windows.Forms.RadioButton()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.GrpOpenCC = New System.Windows.Forms.GroupBox()
    Me.DtPckCC = New System.Windows.Forms.DateTimePicker()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtCCNo = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RbSU = New System.Windows.Forms.RadioButton()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpOpenCC.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtListNo
        '
        Me.TxtListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtListNo.Location = New System.Drawing.Point(50, 96)
        Me.TxtListNo.MaxLength = 7
        Me.TxtListNo.Name = "TxtListNo"
        Me.TxtListNo.Size = New System.Drawing.Size(67, 20)
        Me.TxtListNo.TabIndex = 3
        Me.TxtListNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'BtnContinue
        '
        Me.BtnContinue.Location = New System.Drawing.Point(165, 182)
        Me.BtnContinue.Name = "BtnContinue"
        Me.BtnContinue.Size = New System.Drawing.Size(64, 24)
        Me.BtnContinue.TabIndex = 4
        Me.BtnContinue.Text = "&Continue"
        '
        'LblYearTxt
        '
        Me.LblYearTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblYearTxt.Location = New System.Drawing.Point(18, 120)
        Me.LblYearTxt.Name = "LblYearTxt"
        Me.LblYearTxt.Size = New System.Drawing.Size(32, 16)
        Me.LblYearTxt.TabIndex = 228
        Me.LblYearTxt.Text = "Year"
        '
        'LnkListNo
        '
        Me.LnkListNo.Location = New System.Drawing.Point(18, 96)
        Me.LnkListNo.Name = "LnkListNo"
        Me.LnkListNo.Size = New System.Drawing.Size(24, 16)
        Me.LnkListNo.TabIndex = 233
        Me.LnkListNo.TabStop = True
        Me.LnkListNo.Text = "List"
        '
        'RbRE
        '
        Me.RbRE.AutoSize = True
        Me.RbRE.Checked = True
        Me.RbRE.Location = New System.Drawing.Point(27, 11)
        Me.RbRE.Name = "RbRE"
        Me.RbRE.Size = New System.Drawing.Size(80, 17)
        Me.RbRE.TabIndex = 0
        Me.RbRE.TabStop = True
        Me.RbRE.Text = "Real Estate"
        '
        'RbPP
        '
        Me.RbPP.AutoSize = True
        Me.RbPP.Location = New System.Drawing.Point(27, 27)
        Me.RbPP.Name = "RbPP"
        Me.RbPP.Size = New System.Drawing.Size(108, 17)
        Me.RbPP.TabIndex = 1
        Me.RbPP.Text = "Personal Property"
        '
        'RbMV
        '
        Me.RbMV.AutoSize = True
        Me.RbMV.Location = New System.Drawing.Point(27, 43)
        Me.RbMV.Name = "RbMV"
        Me.RbMV.Size = New System.Drawing.Size(90, 17)
        Me.RbMV.TabIndex = 2
        Me.RbMV.Text = "Motor Vehicle"
        '
        'LblYear
        '
        Me.LblYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblYear.Location = New System.Drawing.Point(50, 120)
        Me.LblYear.Name = "LblYear"
        Me.LblYear.Size = New System.Drawing.Size(32, 16)
        Me.LblYear.TabIndex = 237
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(118, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(229, 20)
        Me.Label2.TabIndex = 238
        Me.Label2.Text = "(Adds: Leave blank to auto assign next list #)"
        '
        'GrpOpenCC
        '
        Me.GrpOpenCC.Controls.Add(Me.DtPckCC)
        Me.GrpOpenCC.Controls.Add(Me.Label5)
        Me.GrpOpenCC.Controls.Add(Me.Label4)
        Me.GrpOpenCC.Controls.Add(Me.TxtCCNo)
        Me.GrpOpenCC.Controls.Add(Me.Label3)
        Me.GrpOpenCC.Controls.Add(Me.TxtYear)
        Me.GrpOpenCC.Location = New System.Drawing.Point(11, 138)
        Me.GrpOpenCC.Name = "GrpOpenCC"
        Me.GrpOpenCC.Size = New System.Drawing.Size(350, 40)
        Me.GrpOpenCC.TabIndex = 241
        Me.GrpOpenCC.TabStop = False
        '
        'DtPckCC
        '
        Me.DtPckCC.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckCC.Location = New System.Drawing.Point(256, 14)
        Me.DtPckCC.Name = "DtPckCC"
        Me.DtPckCC.Size = New System.Drawing.Size(86, 20)
        Me.DtPckCC.TabIndex = 2
        Me.DtPckCC.Value = New Date(2015, 5, 20, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(220, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 245
        Me.Label5.Text = "Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(107, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 244
        Me.Label4.Text = "C/C No"
        '
        'TxtCCNo
        '
        Me.TxtCCNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCCNo.Location = New System.Drawing.Point(154, 14)
        Me.TxtCCNo.MaxLength = 6
        Me.TxtCCNo.Name = "TxtCCNo"
        Me.TxtCCNo.Size = New System.Drawing.Size(60, 20)
        Me.TxtCCNo.TabIndex = 1
        Me.TxtCCNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 242
        Me.Label3.Text = "Year"
        '
        'TxtYear
        '
        Me.TxtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtYear.Location = New System.Drawing.Point(42, 14)
        Me.TxtYear.MaxLength = 6
        Me.TxtYear.Name = "TxtYear"
        Me.TxtYear.Size = New System.Drawing.Size(48, 20)
        Me.TxtYear.TabIndex = 0
        Me.TxtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(189, 76)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(129, 17)
        Me.RadioButton1.TabIndex = 242
        Me.RadioButton1.Text = "Motor Vehicle Archive"
        Me.RadioButton1.Visible = False
        '
        'RbSU
        '
        Me.RbSU.AutoSize = True
        Me.RbSU.Location = New System.Drawing.Point(27, 59)
        Me.RbSU.Name = "RbSU"
        Me.RbSU.Size = New System.Drawing.Size(120, 17)
        Me.RbSU.TabIndex = 243
        Me.RbSU.Text = "Suppl Motor Vehicle"
        '
        'FrmTA810_NEW
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(374, 218)
        Me.Controls.Add(Me.RbSU)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.GrpOpenCC)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblYear)
        Me.Controls.Add(Me.RbMV)
        Me.Controls.Add(Me.RbPP)
        Me.Controls.Add(Me.RbRE)
        Me.Controls.Add(Me.LnkListNo)
        Me.Controls.Add(Me.TxtListNo)
        Me.Controls.Add(Me.LblYearTxt)
        Me.Controls.Add(Me.BtnContinue)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTA810_NEW"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New C/C Information"
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpOpenCC.ResumeLayout(False)
        Me.GrpOpenCC.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub BtnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnContinue.Click
    Me.ErrProv.SetError(TxtListNo, "")
    Me.ErrProv.SetError(RbRE, "")
    Me.ErrProv.SetError(TxtCCNo, "")
    Me.ErrProv.SetError(TxtYear, "")

    If WrkType = "" Then
      Me.ErrProv.SetError(RbRE, "Type is required")
      Exit Sub
    End If

    If MyOpenCC Then
      If MyUtils.CnvSng(TxtYear.Text) = 0 Then
        Me.ErrProv.SetError(TxtYear, "Year is required")
        Exit Sub
      End If
      If MyUtils.CnvSng(TxtCCNo.Text) = 0 Then
        Me.ErrProv.SetError(TxtCCNo, "C/C No is required")
        Exit Sub
      End If
    End If

    Select Case WrkType
      Case Is = "M"
        MyFrmTA8104R = New FrmTA8104R
        MyFrmTA8104R.MdiParent = Me.ParentForm
        MyFrmTA8104R.WrkAddMode = True
        If MyOpenCC Then
          MyFrmTA8104R.WrkCCNo = MyUtils.CnvSng(TxtCCNo.Text)
          MyFrmTA8104R.WrkYear = MyUtils.CnvSng(TxtYear.Text)
          MyFrmTA8104R.WrkCCDate = DtPckCC.Value
        Else
          MyFrmTA8104R.WrkCCNo = 0
          MyFrmTA8104R.WrkYear = LblYear.Text
        End If
        MyFrmTA8104R.WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
        MyFrmTA8104R.WrkType = WrkType
        MyFrmTA8104R.Show()
      Case Is = "P"
        MyFrmTA8103R = New FrmTA8103R
        MyFrmTA8103R.MdiParent = Me.ParentForm
        MyFrmTA8103R.WrkAddMode = True
        If MyOpenCC Then
          MyFrmTA8103R.WrkCCNo = MyUtils.CnvSng(TxtCCNo.Text)
          MyFrmTA8103R.WrkYear = MyUtils.CnvSng(TxtYear.Text)
          MyFrmTA8103R.WrkCCDate = DtPckCC.Value
        Else
          MyFrmTA8103R.WrkCCNo = 0
          MyFrmTA8103R.WrkYear = LblYear.Text
        End If
        MyFrmTA8103R.WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
        MyFrmTA8103R.WrkType = WrkType
        MyFrmTA8103R.Show()
      Case Is = "R"
        MyFrmTA8102R = New FrmTA8102R
        MyFrmTA8102R.MdiParent = Me.ParentForm
        MyFrmTA8102R.WrkAddMode = True
        If MyOpenCC Then
          MyFrmTA8102R.WrkCCNo = MyUtils.CnvSng(TxtCCNo.Text)
          MyFrmTA8102R.WrkYear = MyUtils.CnvSng(TxtYear.Text)
          MyFrmTA8102R.WrkCCDate = DtPckCC.Value
        Else
          MyFrmTA8102R.WrkCCNo = 0
          MyFrmTA8102R.WrkYear = LblYear.Text
        End If
        MyFrmTA8102R.WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
        MyFrmTA8102R.WrkType = WrkType
        MyFrmTA8102R.Show()
      Case Is = "S"
        MyFrmTA8105R = New FrmTA8105R
        MyFrmTA8105R.MdiParent = Me.ParentForm
        MyFrmTA8105R.WrkAddMode = True
        If MyOpenCC Then
          MyFrmTA8105R.WrkCCNo = MyUtils.CnvSng(TxtCCNo.Text)
          MyFrmTA8105R.WrkYear = MyUtils.CnvSng(TxtYear.Text)
          MyFrmTA8105R.WrkCCDate = DtPckCC.Value
        Else
          MyFrmTA8105R.WrkCCNo = 0
          MyFrmTA8105R.WrkYear = LblYear.Text
        End If
        MyFrmTA8105R.WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
        MyFrmTA8105R.WrkType = WrkType
        MyFrmTA8105R.Show()
    End Select

    WrkContinue = True
    Me.Close()

  End Sub

  Private Sub FrmTA810_NEW_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    WrkContinue = False
    WrkType = "R"
    With MyFrmTA810
      .TBarNew.Enabled = False
      .TBarPrint.Enabled = False
    End With

    If MyOpenCC Then
      LblYearTxt.Visible = False
      DtPckCC.Value = Date.Today
    Else
      GrpOpenCC.Visible = False
      LblYear.Text = MyGLYear
    End If
  End Sub
  Private Sub FrmTA810_NEW_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    If Not WrkContinue Then
      With MyFrmTA810
       .TBarNew.Enabled = True
       .TBarBack.Enabled = True
       .TBarPrint.Enabled = True
      End With
      MyFrmTA8101R.Show()
    End If
  End Sub
  Private Sub LnkListNo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkListNo.LinkClicked
    Select Case WrkType
      Case Is = "M"
        MyFrmListMVDC = New FrmListMVDC
        MyFrmListMVDC.MdiParent = Me.ParentForm
        MyFrmListMVDC.Show()
      Case Is = "P"
        MyFrmListPPRPC = New FrmListPPRPC
        MyFrmListPPRPC.MdiParent = Me.ParentForm
        MyFrmListPPRPC.Show()
      Case Is = "R"
        MyFrmListRealC = New FrmListRealC
        MyFrmListRealC.MdiParent = Me.ParentForm
        MyFrmListRealC.Show()
      Case Is = "S"
        MyFrmListSuppC = New FrmListSUPPC
        MyFrmListSuppC.MdiParent = Me.ParentForm
        MyFrmListSuppC.Show()
    End Select
  End Sub
  Private Sub RbRE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbRE.CheckedChanged
    WrkType = "R"
  End Sub
  Private Sub RbPP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbPP.CheckedChanged
    WrkType = "P"
  End Sub
  Private Sub RbMV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbMV.CheckedChanged
    WrkType = "M"
  End Sub
  Private Sub RbSU_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbSU.CheckedChanged
    WrkType = "S"
  End Sub
  Private Sub FrmTA810_NEW_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA810.SbpScreen.Text = "TA810_NEW"
  End Sub
  Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtCCNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCCNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






