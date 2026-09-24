Public Class FrmTA134B
  Inherits System.Windows.Forms.Form
  Dim myTXLOCIN As TXLOCIN.MyData
  Dim WrkPgm1 As String
  Dim WrkPgm2 As String
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
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
  Friend WithEvents TxtSinglePgm1 As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TxtMarriedPgm1 As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents LblPgm1 As System.Windows.Forms.Label
  Friend WithEvents TxtAmountPgm2 As System.Windows.Forms.TextBox
  Friend WithEvents LblPgm2 As System.Windows.Forms.Label
  Friend WithEvents TxtMarriedPgm2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtSinglePgm2 As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtAmountPgm1 As System.Windows.Forms.TextBox
  Friend WithEvents label3 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.label3 = New System.Windows.Forms.Label()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.BtnShow = New System.Windows.Forms.Button()
    Me.GrpData = New System.Windows.Forms.GroupBox()
    Me.TxtAmountPgm2 = New System.Windows.Forms.TextBox()
    Me.LblPgm2 = New System.Windows.Forms.Label()
    Me.TxtMarriedPgm2 = New System.Windows.Forms.TextBox()
    Me.TxtSinglePgm2 = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtAmountPgm1 = New System.Windows.Forms.TextBox()
    Me.LblPgm1 = New System.Windows.Forms.Label()
    Me.TxtMarriedPgm1 = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtSinglePgm1 = New System.Windows.Forms.TextBox()
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
    Me.GrpData.Controls.Add(Me.TxtAmountPgm2)
    Me.GrpData.Controls.Add(Me.LblPgm2)
    Me.GrpData.Controls.Add(Me.TxtMarriedPgm2)
    Me.GrpData.Controls.Add(Me.TxtSinglePgm2)
    Me.GrpData.Controls.Add(Me.Label7)
    Me.GrpData.Controls.Add(Me.Label6)
    Me.GrpData.Controls.Add(Me.TxtAmountPgm1)
    Me.GrpData.Controls.Add(Me.LblPgm1)
    Me.GrpData.Controls.Add(Me.TxtMarriedPgm1)
    Me.GrpData.Controls.Add(Me.Label4)
    Me.GrpData.Controls.Add(Me.Label2)
    Me.GrpData.Controls.Add(Me.Label9)
    Me.GrpData.Controls.Add(Me.Label8)
    Me.GrpData.Controls.Add(Me.TxtSinglePgm1)
    Me.GrpData.Location = New System.Drawing.Point(12, 53)
    Me.GrpData.Name = "GrpData"
    Me.GrpData.Size = New System.Drawing.Size(219, 112)
    Me.GrpData.TabIndex = 36
    Me.GrpData.TabStop = False
    '
    'TxtAmountPgm2
    '
    Me.TxtAmountPgm2.Location = New System.Drawing.Point(166, 82)
    Me.TxtAmountPgm2.MaxLength = 5
    Me.TxtAmountPgm2.Name = "TxtAmountPgm2"
    Me.TxtAmountPgm2.Size = New System.Drawing.Size(47, 20)
    Me.TxtAmountPgm2.TabIndex = 5
    Me.TxtAmountPgm2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblPgm2
    '
    Me.LblPgm2.AutoSize = True
    Me.LblPgm2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPgm2.Location = New System.Drawing.Point(14, 85)
    Me.LblPgm2.Name = "LblPgm2"
    Me.LblPgm2.Size = New System.Drawing.Size(21, 13)
    Me.LblPgm2.TabIndex = 56
    Me.LblPgm2.Text = "LH"
    '
    'TxtMarriedPgm2
    '
    Me.TxtMarriedPgm2.Location = New System.Drawing.Point(104, 82)
    Me.TxtMarriedPgm2.MaxLength = 5
    Me.TxtMarriedPgm2.Name = "TxtMarriedPgm2"
    Me.TxtMarriedPgm2.Size = New System.Drawing.Size(47, 20)
    Me.TxtMarriedPgm2.TabIndex = 4
    Me.TxtMarriedPgm2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtSinglePgm2
    '
    Me.TxtSinglePgm2.Location = New System.Drawing.Point(44, 82)
    Me.TxtSinglePgm2.MaxLength = 5
    Me.TxtSinglePgm2.Name = "TxtSinglePgm2"
    Me.TxtSinglePgm2.Size = New System.Drawing.Size(47, 20)
    Me.TxtSinglePgm2.TabIndex = 3
    Me.TxtSinglePgm2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(171, 16)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(40, 13)
    Me.Label7.TabIndex = 53
    Me.Label7.Text = "Benefit"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(171, 35)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(43, 13)
    Me.Label6.TabIndex = 52
    Me.Label6.Text = "Amount"
    '
    'TxtAmountPgm1
    '
    Me.TxtAmountPgm1.Location = New System.Drawing.Point(166, 56)
    Me.TxtAmountPgm1.MaxLength = 5
    Me.TxtAmountPgm1.Name = "TxtAmountPgm1"
    Me.TxtAmountPgm1.Size = New System.Drawing.Size(47, 20)
    Me.TxtAmountPgm1.TabIndex = 2
    Me.TxtAmountPgm1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblPgm1
    '
    Me.LblPgm1.AutoSize = True
    Me.LblPgm1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPgm1.Location = New System.Drawing.Point(14, 59)
    Me.LblPgm1.Name = "LblPgm1"
    Me.LblPgm1.Size = New System.Drawing.Size(19, 13)
    Me.LblPgm1.TabIndex = 50
    Me.LblPgm1.Text = "LL"
    '
    'TxtMarriedPgm1
    '
    Me.TxtMarriedPgm1.Location = New System.Drawing.Point(104, 56)
    Me.TxtMarriedPgm1.MaxLength = 5
    Me.TxtMarriedPgm1.Name = "TxtMarriedPgm1"
    Me.TxtMarriedPgm1.Size = New System.Drawing.Size(47, 20)
    Me.TxtMarriedPgm1.TabIndex = 1
    Me.TxtMarriedPgm1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(109, 35)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(42, 13)
    Me.Label4.TabIndex = 48
    Me.Label4.Text = "Income"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(101, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(66, 13)
    Me.Label2.TabIndex = 47
    Me.Label2.Text = "Addl Married"
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(49, 35)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(42, 13)
    Me.Label9.TabIndex = 3
    Me.Label9.Text = "Income"
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(37, 16)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(60, 13)
    Me.Label8.TabIndex = 0
    Me.Label8.Text = "Addl Single"
    '
    'TxtSinglePgm1
    '
    Me.TxtSinglePgm1.Location = New System.Drawing.Point(44, 56)
    Me.TxtSinglePgm1.MaxLength = 5
    Me.TxtSinglePgm1.Name = "TxtSinglePgm1"
    Me.TxtSinglePgm1.Size = New System.Drawing.Size(47, 20)
    Me.TxtSinglePgm1.TabIndex = 0
    Me.TxtSinglePgm1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'FrmTA134B
    '
    Me.AllowDrop = True
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(243, 178)
    Me.ControlBox = False
    Me.Controls.Add(Me.GrpData)
    Me.Controls.Add(Me.BtnShow)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA134B"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpData.ResumeLayout(False)
    Me.GrpData.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub TA134B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXLOCIN = New TXLOCIN.MyData(myDBConnect)

    MyFrmTA134.TBarNew.Visible = False
    MyFrmTA134.TBarSave.Visible = True
    MyFrmTA134.TBarDelete.Visible = False

    If s_chg = False And s_full = False Then    '#sec
      MyFrmTA134.TBarSave.Visible = False
    End If
    GrpData.Enabled = False
    If myTOWN._TOWNBR = 35 Then 'Coventry
      WrkPgm1 = "LOC"
      WrkPgm2 = "DEF"
      LblPgm1.Text = WrkPgm1
      LblPgm2.Text = WrkPgm2
      TxtAmountPgm1.Enabled = False
      TxtAmountPgm2.Enabled = False
    Else
      WrkPgm1 = "LL"
      WrkPgm2 = "LH"
    End If
  End Sub
  Private Sub LoadForm(ByVal WrkYear As Integer)
    myTXLOCIN.GetOneRecordP(WrkYear, WrkPgm1)
    If myTXLOCIN.RecordNotFound Then
      If TxtSinglePgm1.Text = "" Then
        MsgBox("Tip: you can copy a previous year by viewing it and then key in new year. Screen data is not cleared.", MsgBoxStyle.Exclamation, "Year not found")
      Else
        MsgBox("Change values as needed and save ", MsgBoxStyle.Exclamation, "Year not found")
      End If
      Exit Sub
    End If

    With myTXLOCIN
      TxtSinglePgm1.Text = ._SNGINC
      TxtMarriedPgm1.Text = ._MRYINC
      TxtAmountPgm1.Text = ._AMOUNT
    End With

    myTXLOCIN.GetOneRecordP(WrkYear, WrkPgm2)
    With myTXLOCIN
      TxtSinglePgm2.Text = ._SNGINC
      TxtMarriedPgm2.Text = ._MRYINC
      TxtAmountPgm2.Text = ._AMOUNT
    End With
  End Sub

  Private Sub TA134B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA134.SbpScreen.Text = "TA134B"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
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
  Public Sub SaveData(ByVal WrkYear As Integer, ByVal WrkCode As String, ByVal WrkSingle As Integer,
  ByVal WrkMarried As Integer, ByVal WrkAmount As Integer)
    myTXLOCIN.GetOneRecordP(WrkYear, WrkCode)
    With myTXLOCIN
      ._SNGINC = WrkSingle
      ._MRYINC = WrkMarried
      ._AMOUNT = WrkAmount
    End With
    If myTXLOCIN.RecordNotFound Then
      myTXLOCIN._YEAR = WrkYear
      myTXLOCIN._CODE = WrkCode
      myTXLOCIN.AddOneRecordP()
    Else
      myTXLOCIN.UpdateOneRecordP()
    End If
  End Sub
  Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
    ShowData()
  End Sub
  Private Sub ShowData()
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
  Private Sub TxtSinglePgm1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSinglePgm1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtMarriedPgm1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMarriedPgm1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAmountPgm1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAmountPgm1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSinglePgm2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSinglePgm2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtMarriedPgm2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMarriedPgm2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAmountPgm2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAmountPgm2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
End Class






