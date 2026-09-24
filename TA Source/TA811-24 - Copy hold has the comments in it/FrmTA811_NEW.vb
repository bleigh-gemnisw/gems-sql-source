Public Class FrmTA811_NEW
  Inherits System.Windows.Forms.Form
	Dim MyTXTYPE As TXTYPE.myData
  Dim MyTXINV As TXINV.myData
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents GrpOpenCC As System.Windows.Forms.GroupBox
  Friend WithEvents DtPckCC As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtCCNo As System.Windows.Forms.TextBox
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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents BtnContinue As System.Windows.Forms.Button
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  Friend WithEvents TxtType As System.Windows.Forms.TextBox
  Friend WithEvents TxtDist As System.Windows.Forms.TextBox
  Friend WithEvents LnkListNo As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.BtnContinue = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.LnkListNo = New System.Windows.Forms.LinkLabel()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.GrpOpenCC = New System.Windows.Forms.GroupBox()
    Me.DtPckCC = New System.Windows.Forms.DateTimePicker()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtCCNo = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpOpenCC.SuspendLayout()
    Me.SuspendLayout()
    '
    'TxtListNo
    '
    Me.TxtListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtListNo.Location = New System.Drawing.Point(56, 40)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(69, 20)
    Me.TxtListNo.TabIndex = 1
    Me.TxtListNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'BtnContinue
    '
    Me.BtnContinue.Location = New System.Drawing.Point(150, 165)
    Me.BtnContinue.Name = "BtnContinue"
    Me.BtnContinue.Size = New System.Drawing.Size(64, 24)
    Me.BtnContinue.TabIndex = 4
    Me.BtnContinue.Text = "&Continue"
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(24, 64)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(32, 16)
    Me.Label1.TabIndex = 228
    Me.Label1.Text = "Year"
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(56, 64)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtYear.TabIndex = 2
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(24, 16)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(32, 16)
    Me.Label3.TabIndex = 230
    Me.Label3.Text = "Type"
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtType.Location = New System.Drawing.Point(56, 16)
    Me.TxtType.MaxLength = 1
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(16, 20)
    Me.TxtType.TabIndex = 0
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(24, 88)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(32, 16)
    Me.Label4.TabIndex = 232
    Me.Label4.Text = "Dist"
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(56, 88)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(24, 20)
    Me.TxtDist.TabIndex = 3
    Me.TxtDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LnkListNo
    '
    Me.LnkListNo.Location = New System.Drawing.Point(24, 43)
    Me.LnkListNo.Name = "LnkListNo"
    Me.LnkListNo.Size = New System.Drawing.Size(24, 16)
    Me.LnkListNo.TabIndex = 233
    Me.LnkListNo.TabStop = True
    Me.LnkListNo.Text = "List"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(131, 43)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(219, 13)
    Me.Label2.TabIndex = 234
    Me.Label2.Text = "(Adds: Leave blank to auto assign next list #)"
    '
    'GrpOpenCC
    '
    Me.GrpOpenCC.Controls.Add(Me.DtPckCC)
    Me.GrpOpenCC.Controls.Add(Me.Label5)
    Me.GrpOpenCC.Controls.Add(Me.Label6)
    Me.GrpOpenCC.Controls.Add(Me.TxtCCNo)
    Me.GrpOpenCC.Location = New System.Drawing.Point(12, 114)
    Me.GrpOpenCC.Name = "GrpOpenCC"
    Me.GrpOpenCC.Size = New System.Drawing.Size(253, 40)
    Me.GrpOpenCC.TabIndex = 242
    Me.GrpOpenCC.TabStop = False
    '
    'DtPckCC
    '
    Me.DtPckCC.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckCC.Location = New System.Drawing.Point(155, 12)
    Me.DtPckCC.Name = "DtPckCC"
    Me.DtPckCC.Size = New System.Drawing.Size(86, 20)
    Me.DtPckCC.TabIndex = 2
    Me.DtPckCC.Value = New Date(2015, 5, 20, 0, 0, 0, 0)
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(119, 15)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(30, 13)
    Me.Label5.TabIndex = 245
    Me.Label5.Text = "Date"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(6, 16)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(43, 13)
    Me.Label6.TabIndex = 244
    Me.Label6.Text = "C/C No"
    '
    'TxtCCNo
    '
    Me.TxtCCNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCCNo.Location = New System.Drawing.Point(53, 12)
    Me.TxtCCNo.MaxLength = 6
    Me.TxtCCNo.Name = "TxtCCNo"
    Me.TxtCCNo.Size = New System.Drawing.Size(48, 20)
    Me.TxtCCNo.TabIndex = 1
    Me.TxtCCNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'FrmTA811_NEW
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(366, 201)
    Me.Controls.Add(Me.GrpOpenCC)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.LnkListNo)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.TxtType)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.TxtListNo)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnContinue)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA811_NEW"
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
    Dim WrkFamily As String
    Dim WrkDate As Date
    Dim ChkDate As Date

    Me.ErrProv.SetError(TxtListNo, "")
    Me.ErrProv.SetError(TxtYear, "")
    Me.ErrProv.SetError(TxtType, "")

    MyTXTYPE.GetOneRecordP(TxtType.Text)
    WrkFamily = ""
		If Not MyTXTYPE.RecordNotFound Then
			WrkFamily = GetTXTypeFamily(TxtType.Text)
		End If
		If WrkFamily <> "R" _
		And WrkFamily <> "P" _
		And WrkFamily <> "M" _
		And WrkFamily <> "S" Then
			Me.ErrProv.SetError(TxtType, "Tax Family/Type not valid for this program")
			Exit Sub
		End If

    If MyUtils.CnvSng(TxtYear.Text) = 0 Then
       Me.ErrProv.SetError(TxtYear, "Year is required")
       Exit Sub
    End If
    If TxtType.Text = "" Then
       Me.ErrProv.SetError(TxtType, "Type is required")
       Exit Sub
    End If

    WrkDate = CheckCCDate(Date.Today, TxtType.Text, MyUtils.CnvSng(TxtYear.Text), "", MyUtils.CnvSng(TxtDist.Text))
    If WrkDate = ChkDate Then
      Me.ErrProv.SetError(TxtYear, "Cannot find Year in Profile. Please setup first!")
      Exit Sub
    End If

    If MyOpenCC Then
      If MyUtils.CnvSng(TxtCCNo.Text) = 0 Then
       Me.ErrProv.SetError(TxtCCNo, "C/C No is required")
       Exit Sub
      End If
    End If

    Select Case WrkFamily
    Case Is = "M"
      MyFrmTA8114R = New FrmTA8114R
      With MyFrmTA8114R
        .MdiParent = Me.ParentForm
        .WrkAddMode = True
        .WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
        .WrkYear = TxtYear.Text
        .WrkType = TxtType.Text
        .WrkFamily = WrkFamily
        .WrkDist = MyUtils.CnvSng(TxtDist.Text)
        If MyOpenCC Then
          .WrkCCNo = MyUtils.CnvSng(TxtCCNo.Text)
          .WrkCCDate = DtPckCC.Value
        Else
          .WrkCCNo = 0
          .WrkCCDate = WrkDate
        End If
        .Show()
      End With
    Case Is = "S"
      MyFrmTA8115R = New FrmTA8115R
      With MyFrmTA8115R
        .MdiParent = Me.ParentForm
        .WrkAddMode = True
        .WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
        .WrkYear = TxtYear.Text
        .WrkType = TxtType.Text
        .WrkFamily = WrkFamily
        .WrkDist = MyUtils.CnvSng(TxtDist.Text)
        If MyOpenCC Then
          .WrkCCNo = MyUtils.CnvSng(TxtCCNo.Text)
          .WrkCCDate = DtPckCC.Value
        Else
          .WrkCCNo = 0
          .WrkCCDate = WrkDate
        End If
        .Show()
      End With
    Case Is = "P"
      MyFrmTA8113R = New FrmTA8113R
      With MyFrmTA8113R
        .MdiParent = Me.ParentForm
        .WrkAddMode = True
        .WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
        .WrkYear = TxtYear.Text
        .WrkType = TxtType.Text
        .WrkFamily = WrkFamily
        .WrkDist = MyUtils.CnvSng(TxtDist.Text)
        If MyOpenCC Then
          .WrkCCNo = MyUtils.CnvSng(TxtCCNo.Text)
          .WrkCCDate = DtPckCC.Value
        Else
          .WrkCCNo = 0
          .WrkCCDate = WrkDate
        End If
        .Show()
      End With
    Case Is = "R"
      MyFrmTA8112R = New FrmTA8112R
      With MyFrmTA8112R
        .MdiParent = Me.ParentForm
        .WrkAddMode = True
        .WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
        .WrkYear = TxtYear.Text
        .WrkType = TxtType.Text
        .WrkFamily = WrkFamily
        .WrkDist = MyUtils.CnvSng(TxtDist.Text)
        If MyOpenCC Then
          .WrkCCNo = MyUtils.CnvSng(TxtCCNo.Text)
          .WrkCCDate = DtPckCC.Value
        Else
          .WrkCCNo = 0
          .WrkCCDate = WrkDate
        End If
        .Show()
      End With
    End Select

    WrkContinue = True
    Me.Close()

  End Sub

  Private Sub FrmTA811_NEW_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXTYPE = New TXTYPE.mydata(MyDBConnect)
    MyTXINV = New TXINV.mydata(MyDBConnect)
    WrkContinue = False
    LnkListNo.Enabled = False
    MyFrmTA811.TBarNew.Enabled = False
    If MyOpenCC Then
      DtPckCC.Value = Date.Today
    Else
      GrpOpenCC.Visible = False
    End If
  End Sub
  Private Sub FrmTA811_NEW_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    If Not WrkContinue Then
      MyFrmTA811.TBarNew.Enabled = True
      MyFrmTA8111R.Show()
    End If
  End Sub

  Private Sub LnkListNo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkListNo.LinkClicked

    Dim WrkFamily As String
    Me.ErrProv.SetError(TxtType, "")

    WrkFamily = GetTXTypeFamily(TxtType.Text)
    If WrkFamily <> "R" _
    And WrkFamily <> "P" _
    And WrkFamily <> "M" _
    And WrkFamily <> "S" Then
      Me.ErrProv.SetError(TxtType, "Tax Family/Type not valid for this program")
      Exit Sub
    End If

    MyFrmListInv = New FrmListInv
    MyFrmListInv.MdiParent = Me.ParentForm
    MyFrmListInv.WrkType = TxtType.Text
    MyFrmListInv.Show()
  End Sub

  Private Sub TxtType_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtType.TextChanged
    If TxtType.Text <> "" Then
      LnkListNo.Enabled = True
    End If
  End Sub

Private Sub FrmTA811_NEW_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA811.SbpScreen.Text = "TA811_NEW"
 End Sub
Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtCCNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCCNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtYear_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtYear.LostFocus
  MyTXINV.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text), MyUtils.CnvSng(TxtYear.Text), TxtType.Text)
  With MyTXINV
    If .RecordNotFound Then Exit Sub
    TxtDist.Text = ._DIST
  End With
End Sub
End Class






