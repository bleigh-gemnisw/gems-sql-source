Public Class FrmTA137B
  Inherits System.Windows.Forms.Form
  Dim myTXLOCHB As TXLOCHB.myData
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
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtYear As System.Windows.Forms.TextBox
    Friend WithEvents BtnShow As System.Windows.Forms.Button
    Friend WithEvents GrpData As System.Windows.Forms.GroupBox
    Friend WithEvents TxtLimit1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtBenamt4 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtBenamt3 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtBenamt2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtBenamt1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtLimit4 As System.Windows.Forms.TextBox
    Friend WithEvents TxtLimit3 As System.Windows.Forms.TextBox
    Friend WithEvents TxtLimit2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtLimit5 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtBenamt5 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.label3 = New System.Windows.Forms.Label()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.BtnShow = New System.Windows.Forms.Button()
    Me.GrpData = New System.Windows.Forms.GroupBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtLimit5 = New System.Windows.Forms.TextBox()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.TxtBenamt5 = New System.Windows.Forms.TextBox()
    Me.TxtLimit4 = New System.Windows.Forms.TextBox()
    Me.TxtLimit3 = New System.Windows.Forms.TextBox()
    Me.TxtLimit2 = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtLimit1 = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtBenamt4 = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtBenamt3 = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtBenamt2 = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtBenamt1 = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpData.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'label3
    '
    Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label3.Location = New System.Drawing.Point(-100, 74)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(100, 23)
    Me.label3.TabIndex = 6
    Me.label3.Text = "New file name"
    Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtYear
    '
    Me.TxtYear.Location = New System.Drawing.Point(61, 12)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(35, 20)
    Me.TxtYear.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(26, 15)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(29, 13)
    Me.Label1.TabIndex = 34
    Me.Label1.Text = "Year"
    '
    'BtnShow
    '
    Me.BtnShow.Location = New System.Drawing.Point(106, 12)
    Me.BtnShow.Name = "BtnShow"
    Me.BtnShow.Size = New System.Drawing.Size(48, 19)
    Me.BtnShow.TabIndex = 1
    Me.BtnShow.Text = "Show"
    Me.BtnShow.UseVisualStyleBackColor = True
    '
    'GrpData
    '
    Me.GrpData.Controls.Add(Me.Label10)
    Me.GrpData.Controls.Add(Me.TxtLimit5)
    Me.GrpData.Controls.Add(Me.Label14)
    Me.GrpData.Controls.Add(Me.TxtBenamt5)
    Me.GrpData.Controls.Add(Me.TxtLimit4)
    Me.GrpData.Controls.Add(Me.TxtLimit3)
    Me.GrpData.Controls.Add(Me.TxtLimit2)
    Me.GrpData.Controls.Add(Me.Label9)
    Me.GrpData.Controls.Add(Me.Label8)
    Me.GrpData.Controls.Add(Me.Label7)
    Me.GrpData.Controls.Add(Me.TxtLimit1)
    Me.GrpData.Controls.Add(Me.Label6)
    Me.GrpData.Controls.Add(Me.TxtBenamt4)
    Me.GrpData.Controls.Add(Me.Label5)
    Me.GrpData.Controls.Add(Me.TxtBenamt3)
    Me.GrpData.Controls.Add(Me.Label4)
    Me.GrpData.Controls.Add(Me.TxtBenamt2)
    Me.GrpData.Controls.Add(Me.Label2)
    Me.GrpData.Controls.Add(Me.TxtBenamt1)
    Me.GrpData.Location = New System.Drawing.Point(12, 49)
    Me.GrpData.Name = "GrpData"
    Me.GrpData.Size = New System.Drawing.Size(166, 187)
    Me.GrpData.TabIndex = 36
    Me.GrpData.TabStop = False
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(97, 35)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(40, 13)
    Me.Label10.TabIndex = 48
    Me.Label10.Text = "Benefit"
    '
    'TxtLimit5
    '
    Me.TxtLimit5.Location = New System.Drawing.Point(37, 158)
    Me.TxtLimit5.MaxLength = 5
    Me.TxtLimit5.Name = "TxtLimit5"
    Me.TxtLimit5.Size = New System.Drawing.Size(47, 20)
    Me.TxtLimit5.TabIndex = 44
    Me.TxtLimit5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label14
    '
    Me.Label14.AutoSize = True
    Me.Label14.Location = New System.Drawing.Point(10, 161)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(13, 13)
    Me.Label14.TabIndex = 47
    Me.Label14.Text = "5"
    '
    'TxtBenamt5
    '
    Me.TxtBenamt5.Location = New System.Drawing.Point(100, 158)
    Me.TxtBenamt5.MaxLength = 7
    Me.TxtBenamt5.Name = "TxtBenamt5"
    Me.TxtBenamt5.Size = New System.Drawing.Size(50, 20)
    Me.TxtBenamt5.TabIndex = 45
    Me.TxtBenamt5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtLimit4
    '
    Me.TxtLimit4.Location = New System.Drawing.Point(37, 132)
    Me.TxtLimit4.MaxLength = 5
    Me.TxtLimit4.Name = "TxtLimit4"
    Me.TxtLimit4.Size = New System.Drawing.Size(47, 20)
    Me.TxtLimit4.TabIndex = 15
    Me.TxtLimit4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtLimit3
    '
    Me.TxtLimit3.Location = New System.Drawing.Point(37, 108)
    Me.TxtLimit3.MaxLength = 5
    Me.TxtLimit3.Name = "TxtLimit3"
    Me.TxtLimit3.Size = New System.Drawing.Size(47, 20)
    Me.TxtLimit3.TabIndex = 12
    Me.TxtLimit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtLimit2
    '
    Me.TxtLimit2.Location = New System.Drawing.Point(37, 82)
    Me.TxtLimit2.MaxLength = 5
    Me.TxtLimit2.Name = "TxtLimit2"
    Me.TxtLimit2.Size = New System.Drawing.Size(47, 20)
    Me.TxtLimit2.TabIndex = 9
    Me.TxtLimit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(46, 35)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(28, 13)
    Me.Label9.TabIndex = 3
    Me.Label9.Text = "Limit"
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(39, 16)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(45, 13)
    Me.Label8.TabIndex = 0
    Me.Label8.Text = "Income "
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(6, 35)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(25, 13)
    Me.Label7.TabIndex = 43
    Me.Label7.Text = "Tier"
    '
    'TxtLimit1
    '
    Me.TxtLimit1.Location = New System.Drawing.Point(37, 56)
    Me.TxtLimit1.MaxLength = 5
    Me.TxtLimit1.Name = "TxtLimit1"
    Me.TxtLimit1.Size = New System.Drawing.Size(47, 20)
    Me.TxtLimit1.TabIndex = 6
    Me.TxtLimit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(10, 135)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(13, 13)
    Me.Label6.TabIndex = 40
    Me.Label6.Text = "4"
    '
    'TxtBenamt4
    '
    Me.TxtBenamt4.Location = New System.Drawing.Point(100, 132)
    Me.TxtBenamt4.MaxLength = 7
    Me.TxtBenamt4.Name = "TxtBenamt4"
    Me.TxtBenamt4.Size = New System.Drawing.Size(50, 20)
    Me.TxtBenamt4.TabIndex = 16
    Me.TxtBenamt4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(10, 111)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(13, 13)
    Me.Label5.TabIndex = 38
    Me.Label5.Text = "3"
    '
    'TxtBenamt3
    '
    Me.TxtBenamt3.Location = New System.Drawing.Point(100, 108)
    Me.TxtBenamt3.MaxLength = 7
    Me.TxtBenamt3.Name = "TxtBenamt3"
    Me.TxtBenamt3.Size = New System.Drawing.Size(50, 20)
    Me.TxtBenamt3.TabIndex = 13
    Me.TxtBenamt3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(10, 85)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(13, 13)
    Me.Label4.TabIndex = 36
    Me.Label4.Text = "2"
    '
    'TxtBenamt2
    '
    Me.TxtBenamt2.Location = New System.Drawing.Point(100, 82)
    Me.TxtBenamt2.MaxLength = 7
    Me.TxtBenamt2.Name = "TxtBenamt2"
    Me.TxtBenamt2.Size = New System.Drawing.Size(50, 20)
    Me.TxtBenamt2.TabIndex = 10
    Me.TxtBenamt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(10, 59)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(13, 13)
    Me.Label2.TabIndex = 34
    Me.Label2.Text = "1"
    '
    'TxtBenamt1
    '
    Me.TxtBenamt1.Location = New System.Drawing.Point(100, 56)
    Me.TxtBenamt1.MaxLength = 7
    Me.TxtBenamt1.Name = "TxtBenamt1"
    Me.TxtBenamt1.Size = New System.Drawing.Size(50, 20)
    Me.TxtBenamt1.TabIndex = 7
    Me.TxtBenamt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'FrmTA137B
    '
    Me.AllowDrop = True
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(202, 262)
    Me.ControlBox = False
    Me.Controls.Add(Me.GrpData)
    Me.Controls.Add(Me.BtnShow)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA137B"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpData.ResumeLayout(False)
    Me.GrpData.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub TA137B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myTXLOCHB = New TXLOCHB.mydata(MyDBConnect)

  MyFrmTA137.TBarNew.Visible = False
  MyFrmTA137.TBarSave.Visible = True
  MyFrmTA137.TBarDelete.Visible = False

  If s_chg = False And s_full = False Then    '#sec
    MyFrmTA137.TBarSave.Visible = False
  End If
  GrpData.Enabled = False

End Sub
Private Sub LoadForm(ByVal WrkYear As Integer)
  myTXLOCHB.GetOneRecordP(WrkYear, 1)
  If myTXLOCHB.RecordNotFound Then
    If TxtLimit1.Text = "" Then
      MsgBox("Tip: you can copy a previous year by viewing it and then key in new year. Screen data is not cleared.", MsgBoxStyle.Exclamation, "Year not found")
    Else
      MsgBox("Change values as needed and save ", MsgBoxStyle.Exclamation, "Year not found")
    End If
    Exit Sub
  End If

  With myTXLOCHB
    TxtLimit1.Text = ._LIMIT
    TxtBenamt1.Text = ._BENAMT
  End With

  myTXLOCHB.GetOneRecordP(WrkYear, 2)
  With myTXLOCHB
    TxtLimit2.Text = ._LIMIT
    TxtBenamt2.Text = ._BENAMT
  End With

  myTXLOCHB.GetOneRecordP(WrkYear, 3)
  With myTXLOCHB
    TxtLimit3.Text = ._LIMIT
    TxtBenamt3.Text = ._BENAMT
  End With

  myTXLOCHB.GetOneRecordP(WrkYear, 4)
  With myTXLOCHB
    TxtLimit4.Text = ._LIMIT
    TxtBenamt4.Text = ._BENAMT
  End With

  myTXLOCHB.GetOneRecordP(WrkYear, 5)
  With myTXLOCHB
    TxtLimit5.Text = ._LIMIT
    TxtBenamt5.Text = ._BENAMT
  End With
End Sub

Private Sub TA137B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA137.SbpScreen.Text = "TA137B"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtLimit2.Text) > 0 And _
      MyUtils.CnvSng(TxtLimit1.Text) > MyUtils.CnvSng(TxtLimit2.Text) Then
        ErrorField(I) = "2"
        ErrorMsg(I) = "Limit must be greater than previous Tier"
        I = I + 1
    End If

    If MyUtils.CnvSng(TxtLimit3.Text) > 0 And _
      MyUtils.CnvSng(TxtLimit2.Text) > MyUtils.CnvSng(TxtLimit3.Text) Then
        ErrorField(I) = "3"
        ErrorMsg(I) = "Limit must be greater than previous Tier"
        I = I + 1
    End If

    If MyUtils.CnvSng(TxtLimit4.Text) > 0 And _
      MyUtils.CnvSng(TxtLimit3.Text) > MyUtils.CnvSng(TxtLimit4.Text) Then
        ErrorField(I) = "4"
        ErrorMsg(I) = "Limit must be greater than previous Tier"
        I = I + 1
    End If

    If MyUtils.CnvSng(TxtLimit5.Text) > 0 And _
      MyUtils.CnvSng(TxtLimit4.Text) > MyUtils.CnvSng(TxtLimit5.Text) Then
        ErrorField(I) = "5"
        ErrorMsg(I) = "Limit must be greater than previous Tier"
        I = I + 1
    End If
  End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtLimit2, "")
  ErrProv.SetError(TxtLimit3, "")
  ErrProv.SetError(TxtLimit4, "")
  ErrProv.SetError(TxtLimit5, "")
  For I = 0 To ErrorField.GetUpperBound(0)
     Select Case ErrorField(I)
       Case "2"
         ErrProv.SetError(TxtLimit2, ErrorMsg(I))
       Case "3"
         ErrProv.SetError(TxtLimit3, ErrorMsg(I))
       Case "4"
         ErrProv.SetError(TxtLimit4, ErrorMsg(I))
       Case "5"
         ErrProv.SetError(TxtLimit5, ErrorMsg(I))
       Case Nothing
         Exit Sub
     End Select
     Next I
End Sub
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
Public Function CheckErrors() As Boolean
  Array.Clear(ErrorField, 0, 25)
  Array.Clear(ErrorMsg, 0, 25)
  EditChecks(ErrorField, ErrorMsg)
  ShowError(ErrorField, ErrorMsg)
  If Not IsNothing(ErrorMsg(0)) Then
    Return True
  End If
  Return False
End Function
Public Sub SaveData(ByVal WrkYear As Integer, ByVal WrkTier As Integer, ByVal WrkLimit As Integer, _
  ByVal WrkBenamt As Integer)
  myTXLOCHB.GetOneRecordP(WrkYear, WrkTier)
  With myTXLOCHB
    ._LIMIT = WrkLimit
    ._BENAMT = WrkBenamt
  End With
  ' added this too
  If myTXLOCHB.RecordNotFound Then
    myTXLOCHB._YEAR = WrkYear
    myTXLOCHB._TIER = WrkTier
    myTXLOCHB.AddOneRecordP()
  Else
    myTXLOCHB.UpdateOneRecordP()
  End If
  End Sub
Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
  ShowData()
End Sub
Private Sub ShowData()
  If MyUtils.CnvSng(TxtYear.Text) = 0 Then Exit Sub

  GrpData.Enabled = True
  TxtYear.Enabled = False
  LoadForm(MyUtils.CnvSng(TxtYear.Text))
End Sub
  Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)

    If e.KeyChar = MyUtils.VbKeyEnter Then
      ShowData()
    End If
  End Sub
  Private Sub TxtLimit1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLimit1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBemamt1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBenamt1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtLimit2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLimit2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBemamt2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBenamt2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtLimit3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLimit3.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBemamt3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBenamt3.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtLimit4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLimit4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBemamt4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBenamt4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtLimit5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLimit5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBemamt5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBenamt5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
End Class






