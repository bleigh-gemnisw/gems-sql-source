Public Class FrmTXA03B
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
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
Friend WithEvents LblFilePath As System.Windows.Forms.Label
Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
Friend WithEvents DtPckReceipt As System.Windows.Forms.DateTimePicker
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents TxtBankCd As System.Windows.Forms.TextBox
Friend WithEvents LnkBankCd As System.Windows.Forms.LinkLabel
Friend WithEvents TxtCheckNo As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbPayWhole As System.Windows.Forms.RadioButton
Friend WithEvents RbPay4th As System.Windows.Forms.RadioButton
Friend WithEvents RbPay3rd As System.Windows.Forms.RadioButton
Friend WithEvents RbPay2nd As System.Windows.Forms.RadioButton
Friend WithEvents RbPay1st As System.Windows.Forms.RadioButton
Friend WithEvents RbPayBalance As System.Windows.Forms.RadioButton
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TxtType As System.Windows.Forms.TextBox
Friend WithEvents LnkType As System.Windows.Forms.LinkLabel
  Friend WithEvents DtPckInterest As DateTimePicker
  Friend WithEvents Label5 As Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.DtPckReceipt = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtBankCd = New System.Windows.Forms.TextBox()
    Me.LnkBankCd = New System.Windows.Forms.LinkLabel()
    Me.TxtCheckNo = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbPayBalance = New System.Windows.Forms.RadioButton()
    Me.RbPayWhole = New System.Windows.Forms.RadioButton()
    Me.RbPay4th = New System.Windows.Forms.RadioButton()
    Me.RbPay3rd = New System.Windows.Forms.RadioButton()
    Me.RbPay2nd = New System.Windows.Forms.RadioButton()
    Me.RbPay1st = New System.Windows.Forms.RadioButton()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.LnkType = New System.Windows.Forms.LinkLabel()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.DtPckInterest = New System.Windows.Forms.DateTimePicker()
    Me.Label5 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LblFilePath)
    Me.GroupBox1.Controls.Add(Me.LnkFilePath)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(9, 181)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(408, 56)
    Me.GroupBox1.TabIndex = 7
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "(Optional) Escrow File Details"
    '
    'LblFilePath
    '
    Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePath.Name = "LblFilePath"
    Me.LblFilePath.Size = New System.Drawing.Size(324, 36)
    Me.LblFilePath.TabIndex = 0
    '
    'LnkFilePath
    '
    Me.LnkFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePath.Location = New System.Drawing.Point(12, 24)
    Me.LnkFilePath.Name = "LnkFilePath"
    Me.LnkFilePath.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePath.TabIndex = 65
    Me.LnkFilePath.TabStop = True
    Me.LnkFilePath.Text = "File Path"
    '
    'DtPckReceipt
    '
    Me.DtPckReceipt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckReceipt.Location = New System.Drawing.Point(100, 119)
    Me.DtPckReceipt.Name = "DtPckReceipt"
    Me.DtPckReceipt.Size = New System.Drawing.Size(84, 20)
    Me.DtPckReceipt.TabIndex = 4
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(9, 123)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(72, 12)
    Me.Label1.TabIndex = 66
    Me.Label1.Text = "Receipt Date"
    '
    'TxtGLYear
    '
    Me.TxtGLYear.Location = New System.Drawing.Point(100, 46)
    Me.TxtGLYear.MaxLength = 4
    Me.TxtGLYear.Name = "TxtGLYear"
    Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtGLYear.TabIndex = 1
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(12, 50)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(84, 16)
    Me.Label4.TabIndex = 69
    Me.Label4.Text = "Grand List Year"
    '
    'TxtBankCd
    '
    Me.TxtBankCd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBankCd.Location = New System.Drawing.Point(101, 69)
    Me.TxtBankCd.MaxLength = 2
    Me.TxtBankCd.Name = "TxtBankCd"
    Me.TxtBankCd.Size = New System.Drawing.Size(32, 20)
    Me.TxtBankCd.TabIndex = 2
    '
    'LnkBankCd
    '
    Me.LnkBankCd.Location = New System.Drawing.Point(10, 73)
    Me.LnkBankCd.Name = "LnkBankCd"
    Me.LnkBankCd.Size = New System.Drawing.Size(80, 16)
    Me.LnkBankCd.TabIndex = 72
    Me.LnkBankCd.TabStop = True
    Me.LnkBankCd.Text = "Bank Code"
    '
    'TxtCheckNo
    '
    Me.TxtCheckNo.Location = New System.Drawing.Point(100, 143)
    Me.TxtCheckNo.MaxLength = 10
    Me.TxtCheckNo.Name = "TxtCheckNo"
    Me.TxtCheckNo.Size = New System.Drawing.Size(69, 20)
    Me.TxtCheckNo.TabIndex = 5
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(9, 147)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(84, 16)
    Me.Label2.TabIndex = 74
    Me.Label2.Text = "Check Number"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbPayBalance)
    Me.GroupBox2.Controls.Add(Me.RbPayWhole)
    Me.GroupBox2.Controls.Add(Me.RbPay4th)
    Me.GroupBox2.Controls.Add(Me.RbPay3rd)
    Me.GroupBox2.Controls.Add(Me.RbPay2nd)
    Me.GroupBox2.Controls.Add(Me.RbPay1st)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(225, 8)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(197, 167)
    Me.GroupBox2.TabIndex = 6
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Payment Selection"
    '
    'RbPayBalance
    '
    Me.RbPayBalance.AutoSize = True
    Me.RbPayBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPayBalance.Location = New System.Drawing.Point(14, 134)
    Me.RbPayBalance.Name = "RbPayBalance"
    Me.RbPayBalance.Size = New System.Drawing.Size(170, 17)
    Me.RbPayBalance.TabIndex = 5
    Me.RbPayBalance.Text = "Open Balance (All installments)"
    Me.RbPayBalance.UseVisualStyleBackColor = True
    '
    'RbPayWhole
    '
    Me.RbPayWhole.AutoSize = True
    Me.RbPayWhole.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPayWhole.Location = New System.Drawing.Point(14, 111)
    Me.RbPayWhole.Name = "RbPayWhole"
    Me.RbPayWhole.Size = New System.Drawing.Size(72, 17)
    Me.RbPayWhole.TabIndex = 4
    Me.RbPayWhole.Text = "Whole Bill"
    Me.RbPayWhole.UseVisualStyleBackColor = True
    '
    'RbPay4th
    '
    Me.RbPay4th.AutoSize = True
    Me.RbPay4th.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPay4th.Location = New System.Drawing.Point(14, 88)
    Me.RbPay4th.Name = "RbPay4th"
    Me.RbPay4th.Size = New System.Drawing.Size(164, 17)
    Me.RbPay4th.TabIndex = 3
    Me.RbPay4th.Text = " Fourth Quarter Payment Only"
    Me.RbPay4th.UseVisualStyleBackColor = True
    '
    'RbPay3rd
    '
    Me.RbPay3rd.AutoSize = True
    Me.RbPay3rd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPay3rd.Location = New System.Drawing.Point(14, 65)
    Me.RbPay3rd.Name = "RbPay3rd"
    Me.RbPay3rd.Size = New System.Drawing.Size(155, 17)
    Me.RbPay3rd.TabIndex = 2
    Me.RbPay3rd.Text = "Third Quarter Payment Only"
    Me.RbPay3rd.UseVisualStyleBackColor = True
    '
    'RbPay2nd
    '
    Me.RbPay2nd.AutoSize = True
    Me.RbPay2nd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPay2nd.Location = New System.Drawing.Point(15, 42)
    Me.RbPay2nd.Name = "RbPay2nd"
    Me.RbPay2nd.Size = New System.Drawing.Size(155, 17)
    Me.RbPay2nd.TabIndex = 1
    Me.RbPay2nd.Text = " Second Half Payment Only"
    Me.RbPay2nd.UseVisualStyleBackColor = True
    '
    'RbPay1st
    '
    Me.RbPay1st.AutoSize = True
    Me.RbPay1st.Checked = True
    Me.RbPay1st.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPay1st.Location = New System.Drawing.Point(15, 19)
    Me.RbPay1st.Name = "RbPay1st"
    Me.RbPay1st.Size = New System.Drawing.Size(137, 17)
    Me.RbPay1st.TabIndex = 0
    Me.RbPay1st.TabStop = True
    Me.RbPay1st.Text = " First Half Payment Only"
    Me.RbPay1st.UseVisualStyleBackColor = True
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Location = New System.Drawing.Point(104, 23)
    Me.TxtType.MaxLength = 1
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(16, 20)
    Me.TxtType.TabIndex = 0
    '
    'LnkType
    '
    Me.LnkType.Location = New System.Drawing.Point(12, 27)
    Me.LnkType.Name = "LnkType"
    Me.LnkType.Size = New System.Drawing.Size(80, 16)
    Me.LnkType.TabIndex = 76
    Me.LnkType.TabStop = True
    Me.LnkType.Text = "Type to print"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(126, 26)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(52, 13)
    Me.Label3.TabIndex = 77
    Me.Label3.Text = "(Optional)"
    '
    'DtPckInterest
    '
    Me.DtPckInterest.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckInterest.Location = New System.Drawing.Point(100, 95)
    Me.DtPckInterest.Name = "DtPckInterest"
    Me.DtPckInterest.Size = New System.Drawing.Size(84, 20)
    Me.DtPckInterest.TabIndex = 3
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(9, 98)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(68, 13)
    Me.Label5.TabIndex = 79
    Me.Label5.Text = "Interest Date"
    '
    'FrmTXA03B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(434, 249)
    Me.ControlBox = False
    Me.Controls.Add(Me.DtPckInterest)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtType)
    Me.Controls.Add(Me.LnkType)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.TxtCheckNo)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtBankCd)
    Me.Controls.Add(Me.LnkBankCd)
    Me.Controls.Add(Me.TxtGLYear)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.DtPckReceipt)
    Me.Controls.Add(Me.GroupBox1)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXA03B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
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

    Me.Refresh()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    PrtReport()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
Private Sub FrmTXA03B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmTXA03.SbpPgmID.Text = "TXA03B"
    MyFrmTXA03.SbpEnvironment.Text = myDBConnect.PgmDB
    LblFilePath.Text = ""

End Sub
Private Sub FrmTXA03B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTXA03.SbpScreen.Text = "TXA03B"
End Sub
Private Sub FrmTXA03B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    ErrProv.SetError(TxtBankCd, "")
    ErrProv.SetError(TxtGLYear, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "bankcd"
        ErrProv.SetError(TxtBankCd, ErrorMsg(I))
      Case "year"
        ErrProv.SetError(TxtGLYear, ErrorMsg(I))
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

    If TxtGLYear.Text = "" Then
      ErrorField(I) = "year"
      ErrorMsg(I) = "Year is required"
      I = I + 1
    End If

		If TxtBankCd.Text = "" Or Mid(GetTXBanksDesc(TxtBankCd.Text), 1, 3) = "***" Then
			ErrorField(I) = "bankcd"
			ErrorMsg(I) = "Bank Code is invalid"
			I = I + 1
		End If
End Sub
Private Sub FrmTXA03B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub

   If e.KeyCode = Keys.F12 Then
     MyUtils.PrtScreen(Form.ActiveForm)
   End If
End Sub
Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
  With OpenFileDialog1
    .ReadOnlyChecked = True
    .ShowDialog()
    LblFilePath.Text = .FileName
  End With
End Sub
  Private Sub LnkBankCd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBankCd.LinkClicked
    MyFrmListBanks = New FrmListBanks
    MyFrmListBanks.MdiParent = Me.ParentForm
    MyFrmListBanks.WrkCode = TxtBankCd.Text
    MyFrmListBanks.Show()
  End Sub
Private Sub LnkType_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkType.LinkClicked
  MyFrmListTypes = New FrmListTypes
  MyFrmListTypes.MdiParent = Me.ParentForm
  MyFrmListTypes.WrkType = TxtType.Text
  MyFrmListTypes.Show()
End Sub
End Class






