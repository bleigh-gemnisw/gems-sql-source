Public Class FrmTA135B
  Inherits System.Windows.Forms.Form
  Dim myTXLOCEX As TXLOCEX.myData
  Dim ErrorField(25) As String
  Friend WithEvents TxtDACAmount As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents TxtDACMarried As System.Windows.Forms.TextBox
  Friend WithEvents TxtDACSingle As System.Windows.Forms.TextBox
  Friend WithEvents TxtLOCAmount As System.Windows.Forms.TextBox
  Friend WithEvents LblLOC As System.Windows.Forms.Label
  Friend WithEvents TxtLOCMarried As System.Windows.Forms.TextBox
  Friend WithEvents TxtLOCSingle As System.Windows.Forms.TextBox
  Friend WithEvents TxtFBCAmount As System.Windows.Forms.TextBox
  Friend WithEvents LblFBC As System.Windows.Forms.Label
  Friend WithEvents TxtFBCMarried As System.Windows.Forms.TextBox
  Friend WithEvents TxtFBCSingle As System.Windows.Forms.TextBox
  Friend WithEvents TxtEBCAmount As System.Windows.Forms.TextBox
  Friend WithEvents LblEBC As System.Windows.Forms.Label
  Friend WithEvents TxtEBCMarried As System.Windows.Forms.TextBox
  Friend WithEvents TxtEBCSingle As System.Windows.Forms.TextBox
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
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.label3 = New System.Windows.Forms.Label()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.BtnShow = New System.Windows.Forms.Button()
    Me.GrpData = New System.Windows.Forms.GroupBox()
    Me.TxtFBCAmount = New System.Windows.Forms.TextBox()
    Me.LblFBC = New System.Windows.Forms.Label()
    Me.TxtFBCMarried = New System.Windows.Forms.TextBox()
    Me.TxtFBCSingle = New System.Windows.Forms.TextBox()
    Me.TxtEBCAmount = New System.Windows.Forms.TextBox()
    Me.LblEBC = New System.Windows.Forms.Label()
    Me.TxtEBCMarried = New System.Windows.Forms.TextBox()
    Me.TxtEBCSingle = New System.Windows.Forms.TextBox()
    Me.TxtDACAmount = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.TxtDACMarried = New System.Windows.Forms.TextBox()
    Me.TxtDACSingle = New System.Windows.Forms.TextBox()
    Me.TxtLOCAmount = New System.Windows.Forms.TextBox()
    Me.LblLOC = New System.Windows.Forms.Label()
    Me.TxtLOCMarried = New System.Windows.Forms.TextBox()
    Me.TxtLOCSingle = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
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
    Me.GrpData.Controls.Add(Me.TxtFBCAmount)
    Me.GrpData.Controls.Add(Me.LblFBC)
    Me.GrpData.Controls.Add(Me.TxtFBCMarried)
    Me.GrpData.Controls.Add(Me.TxtFBCSingle)
    Me.GrpData.Controls.Add(Me.TxtEBCAmount)
    Me.GrpData.Controls.Add(Me.LblEBC)
    Me.GrpData.Controls.Add(Me.TxtEBCMarried)
    Me.GrpData.Controls.Add(Me.TxtEBCSingle)
    Me.GrpData.Controls.Add(Me.TxtDACAmount)
    Me.GrpData.Controls.Add(Me.Label12)
    Me.GrpData.Controls.Add(Me.TxtDACMarried)
    Me.GrpData.Controls.Add(Me.TxtDACSingle)
    Me.GrpData.Controls.Add(Me.TxtLOCAmount)
    Me.GrpData.Controls.Add(Me.LblLOC)
    Me.GrpData.Controls.Add(Me.TxtLOCMarried)
    Me.GrpData.Controls.Add(Me.TxtLOCSingle)
    Me.GrpData.Controls.Add(Me.Label7)
    Me.GrpData.Controls.Add(Me.Label6)
    Me.GrpData.Controls.Add(Me.Label4)
    Me.GrpData.Controls.Add(Me.Label2)
    Me.GrpData.Controls.Add(Me.Label9)
    Me.GrpData.Controls.Add(Me.Label8)
    Me.GrpData.Location = New System.Drawing.Point(12, 53)
    Me.GrpData.Name = "GrpData"
    Me.GrpData.Size = New System.Drawing.Size(232, 167)
    Me.GrpData.TabIndex = 36
    Me.GrpData.TabStop = False
    '
    'TxtFBCAmount
    '
    Me.TxtFBCAmount.Location = New System.Drawing.Point(166, 133)
    Me.TxtFBCAmount.MaxLength = 5
    Me.TxtFBCAmount.Name = "TxtFBCAmount"
    Me.TxtFBCAmount.Size = New System.Drawing.Size(47, 20)
    Me.TxtFBCAmount.TabIndex = 71
    Me.TxtFBCAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblFBC
    '
    Me.LblFBC.AutoSize = True
    Me.LblFBC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFBC.Location = New System.Drawing.Point(14, 136)
    Me.LblFBC.Name = "LblFBC"
    Me.LblFBC.Size = New System.Drawing.Size(27, 13)
    Me.LblFBC.TabIndex = 72
    Me.LblFBC.Text = "FBC"
    '
    'TxtFBCMarried
    '
    Me.TxtFBCMarried.Location = New System.Drawing.Point(104, 133)
    Me.TxtFBCMarried.MaxLength = 5
    Me.TxtFBCMarried.Name = "TxtFBCMarried"
    Me.TxtFBCMarried.Size = New System.Drawing.Size(47, 20)
    Me.TxtFBCMarried.TabIndex = 70
    Me.TxtFBCMarried.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtFBCSingle
    '
    Me.TxtFBCSingle.Location = New System.Drawing.Point(44, 133)
    Me.TxtFBCSingle.MaxLength = 5
    Me.TxtFBCSingle.Name = "TxtFBCSingle"
    Me.TxtFBCSingle.Size = New System.Drawing.Size(47, 20)
    Me.TxtFBCSingle.TabIndex = 69
    Me.TxtFBCSingle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtEBCAmount
    '
    Me.TxtEBCAmount.Location = New System.Drawing.Point(166, 107)
    Me.TxtEBCAmount.MaxLength = 5
    Me.TxtEBCAmount.Name = "TxtEBCAmount"
    Me.TxtEBCAmount.Size = New System.Drawing.Size(47, 20)
    Me.TxtEBCAmount.TabIndex = 67
    Me.TxtEBCAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblEBC
    '
    Me.LblEBC.AutoSize = True
    Me.LblEBC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblEBC.Location = New System.Drawing.Point(14, 110)
    Me.LblEBC.Name = "LblEBC"
    Me.LblEBC.Size = New System.Drawing.Size(28, 13)
    Me.LblEBC.TabIndex = 68
    Me.LblEBC.Text = "EBC"
    '
    'TxtEBCMarried
    '
    Me.TxtEBCMarried.Location = New System.Drawing.Point(104, 107)
    Me.TxtEBCMarried.MaxLength = 5
    Me.TxtEBCMarried.Name = "TxtEBCMarried"
    Me.TxtEBCMarried.Size = New System.Drawing.Size(47, 20)
    Me.TxtEBCMarried.TabIndex = 66
    Me.TxtEBCMarried.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtEBCSingle
    '
    Me.TxtEBCSingle.Location = New System.Drawing.Point(44, 107)
    Me.TxtEBCSingle.MaxLength = 5
    Me.TxtEBCSingle.Name = "TxtEBCSingle"
    Me.TxtEBCSingle.Size = New System.Drawing.Size(47, 20)
    Me.TxtEBCSingle.TabIndex = 65
    Me.TxtEBCSingle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtDACAmount
    '
    Me.TxtDACAmount.Location = New System.Drawing.Point(166, 81)
    Me.TxtDACAmount.MaxLength = 5
    Me.TxtDACAmount.Name = "TxtDACAmount"
    Me.TxtDACAmount.Size = New System.Drawing.Size(47, 20)
    Me.TxtDACAmount.TabIndex = 63
    Me.TxtDACAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(14, 84)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(29, 13)
    Me.Label12.TabIndex = 64
    Me.Label12.Text = "DAC"
    '
    'TxtDACMarried
    '
    Me.TxtDACMarried.Location = New System.Drawing.Point(104, 81)
    Me.TxtDACMarried.MaxLength = 5
    Me.TxtDACMarried.Name = "TxtDACMarried"
    Me.TxtDACMarried.Size = New System.Drawing.Size(47, 20)
    Me.TxtDACMarried.TabIndex = 62
    Me.TxtDACMarried.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtDACSingle
    '
    Me.TxtDACSingle.Location = New System.Drawing.Point(44, 81)
    Me.TxtDACSingle.MaxLength = 5
    Me.TxtDACSingle.Name = "TxtDACSingle"
    Me.TxtDACSingle.Size = New System.Drawing.Size(47, 20)
    Me.TxtDACSingle.TabIndex = 61
    Me.TxtDACSingle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtLOCAmount
    '
    Me.TxtLOCAmount.Location = New System.Drawing.Point(166, 55)
    Me.TxtLOCAmount.MaxLength = 5
    Me.TxtLOCAmount.Name = "TxtLOCAmount"
    Me.TxtLOCAmount.Size = New System.Drawing.Size(47, 20)
    Me.TxtLOCAmount.TabIndex = 59
    Me.TxtLOCAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblLOC
    '
    Me.LblLOC.AutoSize = True
    Me.LblLOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLOC.Location = New System.Drawing.Point(14, 58)
    Me.LblLOC.Name = "LblLOC"
    Me.LblLOC.Size = New System.Drawing.Size(28, 13)
    Me.LblLOC.TabIndex = 60
    Me.LblLOC.Text = "LOC"
    '
    'TxtLOCMarried
    '
    Me.TxtLOCMarried.Location = New System.Drawing.Point(104, 55)
    Me.TxtLOCMarried.MaxLength = 5
    Me.TxtLOCMarried.Name = "TxtLOCMarried"
    Me.TxtLOCMarried.Size = New System.Drawing.Size(47, 20)
    Me.TxtLOCMarried.TabIndex = 58
    Me.TxtLOCMarried.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtLOCSingle
    '
    Me.TxtLOCSingle.Location = New System.Drawing.Point(44, 55)
    Me.TxtLOCSingle.MaxLength = 5
    Me.TxtLOCSingle.Name = "TxtLOCSingle"
    Me.TxtLOCSingle.Size = New System.Drawing.Size(47, 20)
    Me.TxtLOCSingle.TabIndex = 57
    Me.TxtLOCSingle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(170, 16)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(56, 13)
    Me.Label7.TabIndex = 53
    Me.Label7.Text = "Exemption"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(170, 35)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(43, 13)
    Me.Label6.TabIndex = 52
    Me.Label6.Text = "Amount"
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
    'FrmTA135B
    '
    Me.AllowDrop = True
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(256, 231)
    Me.ControlBox = False
    Me.Controls.Add(Me.GrpData)
    Me.Controls.Add(Me.BtnShow)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA135B"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpData.ResumeLayout(False)
    Me.GrpData.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub TA135B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myTXLOCEX = New TXLOCEX.mydata(MyDBConnect)

  MyFrmTA135.TBarNew.Visible = False
  MyFrmTA135.TBarSave.Visible = True
  MyFrmTA135.TBarDelete.Visible = False

  If s_chg = False And s_full = False Then    '#sec
    MyFrmTA135.TBarSave.Visible = False
  End If
  GrpData.Enabled = False
  If MyLocEld = "045" Then
    LblLOC.Visible = False
    TxtLOCAmount.Visible = False
    TxtLOCSingle.Visible = False
    TxtLOCMarried.Visible = False
    LblEBC.Visible = False
    TxtEBCAmount.Visible = False
    TxtEBCSingle.Visible = False
    TxtEBCMarried.Visible = False
    LblFBC.Visible = False
    TxtFBCAmount.Visible = False
    TxtFBCSingle.Visible = False
    TxtFBCMarried.Visible = False
  End If
End Sub
Private Sub LoadForm(ByVal WrkYear As Integer)
  myTXLOCEX.GetOneRecordP(WrkYear, "DAC")
  If myTXLOCEX.RecordNotFound Then
    If TxtDACSingle.Text = "" Then
      MsgBox("Tip: you can copy a previous year by viewing it and then key in new year. Screen data is not cleared.", MsgBoxStyle.Exclamation, "Year not found")
    Else
      MsgBox("Change values as needed and save ", MsgBoxStyle.Exclamation, "Year not found")
    End If
    Exit Sub
  End If

  myTXLOCEX.GetOneRecordP(WrkYear, "DAC")
  With myTXLOCEX
    TxtDACSingle.Text = ._SNGINC
    TxtDACMarried.Text = ._MRYINC
    TxtDACAmount.Text = ._AMOUNT
  End With

  If MyLocEld = "084" Then
    myTXLOCEX.GetOneRecordP(WrkYear, "LOC")
    With myTXLOCEX
      TxtLOCSingle.Text = ._SNGINC
      TxtLOCMarried.Text = ._MRYINC
      TxtLOCAmount.Text = ._AMOUNT
    End With
    myTXLOCEX.GetOneRecordP(WrkYear, "EBC")
    With myTXLOCEX
      TxtEBCSingle.Text = ._SNGINC
      TxtEBCMarried.Text = ._MRYINC
      TxtEBCAmount.Text = ._AMOUNT
    End With
    myTXLOCEX.GetOneRecordP(WrkYear, "FBC")
    With myTXLOCEX
      TxtFBCSingle.Text = ._SNGINC
      TxtFBCMarried.Text = ._MRYINC
      TxtFBCAmount.Text = ._AMOUNT
    End With
  End If

End Sub

Private Sub TA135B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA135.SbpScreen.Text = "TA135B"
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
Public Sub SaveData(ByVal WrkYear As Integer, ByVal WrkCode As String, ByVal WrkSingle As Integer, _
  ByVal WrkMarried As Integer, ByVal WrkAmount As Integer)
  myTXLOCEX.GetOneRecordP(WrkYear, WrkCode)
  With myTXLOCEX
    ._SNGINC = WrkSingle
    ._MRYINC = WrkMarried
    ._AMOUNT = WrkAmount
  End With
  If myTXLOCEX.RecordNotFound Then
    myTXLOCEX._YEAR = WrkYear
    myTXLOCEX._CODE = WrkCode
    myTXLOCEX.AddOneRecordP()
  Else
    myTXLOCEX.UpdateOneRecordP()
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
  Private Sub TxtLOCSingle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLOCSingle.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtLOCMarried_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLOCMarried.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtLOCAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLOCAmount.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDACSingle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDACSingle.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDACMarried_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDACMarried.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDACAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDACAmount.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtEBCSingle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEBCSingle.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtEBCMarried_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEBCMarried.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtEBCAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEBCAmount.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFBCSingle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFBCSingle.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFBCMarried_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFBCMarried.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFBCAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFBCAmount.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
End Class






