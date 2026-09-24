Public Class FrmTX816B
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
Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
Friend WithEvents TxtGLFromYear As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
Friend WithEvents TxtGLToYear As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents ChkMVRegNo As System.Windows.Forms.CheckBox
Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents TxtOmit As System.Windows.Forms.TextBox
Friend WithEvents LnkOmit As System.Windows.Forms.LinkLabel
Friend WithEvents LblFilePath As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.LblFilePath = New System.Windows.Forms.Label
Me.LnkFilePath = New System.Windows.Forms.LinkLabel
Me.TxtGLFromYear = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.LnkTypes = New System.Windows.Forms.LinkLabel
Me.TxtTypes = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.TxtGLToYear = New System.Windows.Forms.TextBox
Me.DtPckTo = New System.Windows.Forms.DateTimePicker
Me.Label2 = New System.Windows.Forms.Label
Me.DtPckFrom = New System.Windows.Forms.DateTimePicker
Me.Label4 = New System.Windows.Forms.Label
Me.ChkMVRegNo = New System.Windows.Forms.CheckBox
Me.TxtOmit = New System.Windows.Forms.TextBox
Me.LnkOmit = New System.Windows.Forms.LinkLabel
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox1.SuspendLayout()
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
Me.GroupBox1.Location = New System.Drawing.Point(21, 174)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(408, 72)
Me.GroupBox1.TabIndex = 7
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "WEBHIST File Details"
'
'LblFilePath
'
Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblFilePath.Location = New System.Drawing.Point(70, 24)
Me.LblFilePath.Name = "LblFilePath"
Me.LblFilePath.Size = New System.Drawing.Size(324, 36)
Me.LblFilePath.TabIndex = 67
'
'LnkFilePath
'
Me.LnkFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkFilePath.Location = New System.Drawing.Point(12, 24)
Me.LnkFilePath.Name = "LnkFilePath"
Me.LnkFilePath.Size = New System.Drawing.Size(52, 16)
Me.LnkFilePath.TabIndex = 8
Me.LnkFilePath.TabStop = True
Me.LnkFilePath.Text = "File Path"
'
'TxtGLFromYear
'
Me.TxtGLFromYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtGLFromYear.Location = New System.Drawing.Point(129, 19)
Me.TxtGLFromYear.MaxLength = 4
Me.TxtGLFromYear.Name = "TxtGLFromYear"
Me.TxtGLFromYear.Size = New System.Drawing.Size(32, 20)
Me.TxtGLFromYear.TabIndex = 0
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(20, 21)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(84, 16)
Me.Label3.TabIndex = 48
Me.Label3.Text = "Grand List Year"
'
'LnkTypes
'
Me.LnkTypes.AutoSize = True
Me.LnkTypes.Location = New System.Drawing.Point(18, 76)
Me.LnkTypes.Name = "LnkTypes"
Me.LnkTypes.Size = New System.Drawing.Size(69, 13)
Me.LnkTypes.TabIndex = 65
Me.LnkTypes.TabStop = True
Me.LnkTypes.Text = "Select Types"
'
'TxtTypes
'
Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtTypes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtTypes.Location = New System.Drawing.Point(129, 73)
Me.TxtTypes.MaxLength = 20
Me.TxtTypes.Name = "TxtTypes"
Me.TxtTypes.Size = New System.Drawing.Size(129, 20)
Me.TxtTypes.TabIndex = 4
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(167, 21)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(18, 16)
Me.Label1.TabIndex = 67
Me.Label1.Text = "to"
'
'TxtGLToYear
'
Me.TxtGLToYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtGLToYear.Location = New System.Drawing.Point(191, 19)
Me.TxtGLToYear.MaxLength = 4
Me.TxtGLToYear.Name = "TxtGLToYear"
Me.TxtGLToYear.Size = New System.Drawing.Size(32, 20)
Me.TxtGLToYear.TabIndex = 1
'
'DtPckTo
'
Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckTo.Location = New System.Drawing.Point(240, 47)
Me.DtPckTo.Name = "DtPckTo"
Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
Me.DtPckTo.TabIndex = 3
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(188, 51)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(52, 16)
Me.Label2.TabIndex = 70
Me.Label2.Text = "To Date"
'
'DtPckFrom
'
Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckFrom.Location = New System.Drawing.Point(80, 47)
Me.DtPckFrom.Name = "DtPckFrom"
Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
Me.DtPckFrom.TabIndex = 2
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(20, 51)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(60, 16)
Me.Label4.TabIndex = 68
Me.Label4.Text = "From Date"
'
'ChkMVRegNo
'
Me.ChkMVRegNo.AutoSize = True
Me.ChkMVRegNo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkMVRegNo.Location = New System.Drawing.Point(21, 140)
Me.ChkMVRegNo.Name = "ChkMVRegNo"
Me.ChkMVRegNo.Size = New System.Drawing.Size(121, 17)
Me.ChkMVRegNo.TabIndex = 6
Me.ChkMVRegNo.Text = "Include MV Regno?" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
Me.ChkMVRegNo.UseVisualStyleBackColor = True
'
'TxtOmit
'
Me.TxtOmit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtOmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtOmit.Location = New System.Drawing.Point(130, 99)
Me.TxtOmit.MaxLength = 20
Me.TxtOmit.Name = "TxtOmit"
Me.TxtOmit.Size = New System.Drawing.Size(129, 20)
Me.TxtOmit.TabIndex = 5
'
'LnkOmit
'
Me.LnkOmit.AutoSize = True
Me.LnkOmit.Location = New System.Drawing.Point(20, 102)
Me.LnkOmit.Name = "LnkOmit"
Me.LnkOmit.Size = New System.Drawing.Size(104, 13)
Me.LnkOmit.TabIndex = 73
Me.LnkOmit.TabStop = True
Me.LnkOmit.Text = "Codes-Omit Records"
'
'FrmTX816B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(448, 262)
Me.ControlBox = False
Me.Controls.Add(Me.TxtOmit)
Me.Controls.Add(Me.LnkOmit)
Me.Controls.Add(Me.ChkMVRegNo)
Me.Controls.Add(Me.DtPckTo)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.DtPckFrom)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.TxtGLToYear)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.TxtTypes)
Me.Controls.Add(Me.LnkTypes)
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.TxtGLFromYear)
Me.Controls.Add(Me.Label3)
Me.KeyPreview = True
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX816B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox1.ResumeLayout(False)
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
Private Sub FrmTX816B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmTX816.SbpPgmID.Text = "TX816B"
    MyFrmTX816.SbpEnvironment.Text = myDBConnect.PgmDB
    LblFilePath.Text = MyUtils.GetDataPath() & "WEBHIST.csv"
End Sub
Private Sub FrmTX816B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX816.SbpScreen.Text = "TX816B"
End Sub
Private Sub FrmTX816B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLFromYear, "")
    ErrProv.SetError(TxtTypes, "")
    ErrProv.SetError(DtPckTo, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "date"
        ErrProv.SetError(DtPckTo, ErrorMsg(I))
      Case "glyear"
        ErrProv.SetError(TxtGLFromYear, ErrorMsg(I))
      Case "types"
        ErrProv.SetError(TxtTypes, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtGLFromYear.Text) > MyUtils.CnvSng(TxtGLToYear.Text) Then
      ErrorField(I) = "to"
      ErrorMsg(I) = "Invalid GL Year Range"
      I = I + 1
    End If

    If DtPckFrom.Value > DtPckTo.Value Then
      ErrorField(I) = "date"
      ErrorMsg(I) = "Invalid Date Range"
      I = I + 1
    End If

  End Sub
Private Sub FrmTX816B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub

   If e.KeyCode = Keys.F12 Then
     MyUtils.PrtScreen(Form.ActiveForm)
   End If
End Sub
Private Sub TxtGLFromYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLFromYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtGLToYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLToYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
  With SaveFileDialog1
    .Filter = "Comma Seperated Values (csv)|*.csv"
    .ShowDialog()
    If .FileName <> String.Empty Then
      LblFilePath.Text = .FileName
    End If
  End With
End Sub

Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
  MyTypes = TxtTypes.Text
  MyFrmSelTypes = New FrmSelTypes
  MyFrmSelTypes.MdiParent = Me.ParentForm
  MyFrmSelTypes.Show()

End Sub
Private Sub LnkOmit_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkOmit.LinkClicked
  MyStsOmit = TxtOmit.Text
  MyFrmSelSts = New FrmSelSts
  MyFrmSelSts.WrkBlocked = False
  MyFrmSelSts.MdiParent = Me.ParentForm
  MyFrmSelSts.Show()
  Me.Hide()
End Sub
End Class






