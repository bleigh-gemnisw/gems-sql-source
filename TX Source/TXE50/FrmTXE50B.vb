Public Class FrmTXE50B
Inherits System.Windows.Forms.Form
  Dim WrkJobID As String

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
Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
Friend WithEvents TxtGLFromYear As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
Friend WithEvents TxtGLToYear As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TxtStatus As System.Windows.Forms.TextBox
Friend WithEvents LinkStatus As System.Windows.Forms.LinkLabel
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents DtPckAgency As System.Windows.Forms.DateTimePicker
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents ChkUpdate As System.Windows.Forms.CheckBox
Friend WithEvents Timer1 As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
Me.TxtGLFromYear = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.LnkTypes = New System.Windows.Forms.LinkLabel
Me.TxtTypes = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.TxtGLToYear = New System.Windows.Forms.TextBox
Me.TxtStatus = New System.Windows.Forms.TextBox
Me.LinkStatus = New System.Windows.Forms.LinkLabel
Me.Label5 = New System.Windows.Forms.Label
Me.DtPckAgency = New System.Windows.Forms.DateTimePicker
Me.TxtDist = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
Me.Label4 = New System.Windows.Forms.Label
Me.ChkUpdate = New System.Windows.Forms.CheckBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'TxtGLFromYear
'
Me.TxtGLFromYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtGLFromYear.Location = New System.Drawing.Point(151, 18)
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
Me.LnkTypes.Location = New System.Drawing.Point(18, 75)
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
Me.TxtTypes.Location = New System.Drawing.Point(151, 70)
Me.TxtTypes.MaxLength = 20
Me.TxtTypes.Name = "TxtTypes"
Me.TxtTypes.Size = New System.Drawing.Size(129, 20)
Me.TxtTypes.TabIndex = 3
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(189, 20)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(18, 16)
Me.Label1.TabIndex = 67
Me.Label1.Text = "to"
'
'TxtGLToYear
'
Me.TxtGLToYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtGLToYear.Location = New System.Drawing.Point(213, 18)
Me.TxtGLToYear.MaxLength = 4
Me.TxtGLToYear.Name = "TxtGLToYear"
Me.TxtGLToYear.Size = New System.Drawing.Size(32, 20)
Me.TxtGLToYear.TabIndex = 1
'
'TxtStatus
'
Me.TxtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtStatus.Location = New System.Drawing.Point(151, 96)
Me.TxtStatus.MaxLength = 20
Me.TxtStatus.Name = "TxtStatus"
Me.TxtStatus.Size = New System.Drawing.Size(129, 20)
Me.TxtStatus.TabIndex = 4
'
'LinkStatus
'
Me.LinkStatus.AutoSize = True
Me.LinkStatus.Location = New System.Drawing.Point(20, 101)
Me.LinkStatus.Name = "LinkStatus"
Me.LinkStatus.Size = New System.Drawing.Size(103, 13)
Me.LinkStatus.TabIndex = 69
Me.LinkStatus.TabStop = True
Me.LinkStatus.Text = "Select Status Codes"
'
'Label5
'
Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label5.Location = New System.Drawing.Point(22, 159)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(128, 17)
Me.Label5.TabIndex = 185
Me.Label5.Text = "Date sent to Collection"
'
'DtPckAgency
'
Me.DtPckAgency.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckAgency.Location = New System.Drawing.Point(151, 156)
Me.DtPckAgency.Name = "DtPckAgency"
Me.DtPckAgency.Size = New System.Drawing.Size(88, 20)
Me.DtPckAgency.TabIndex = 6
'
'TxtDist
'
Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDist.Location = New System.Drawing.Point(151, 44)
Me.TxtDist.MaxLength = 3
Me.TxtDist.Name = "TxtDist"
Me.TxtDist.Size = New System.Drawing.Size(28, 20)
Me.TxtDist.TabIndex = 2
'
'Label2
'
Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label2.Location = New System.Drawing.Point(22, 49)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(44, 16)
Me.Label2.TabIndex = 188
Me.Label2.Text = "District"
'
'Label4
'
Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label4.Location = New System.Drawing.Point(17, 207)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(271, 51)
Me.Label4.TabIndex = 189
Me.Label4.Text = "WARNING: No balance calculations are performed. Use this option to flag based onl" & _
    "y on status code(s)."
'
'ChkUpdate
'
Me.ChkUpdate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.ChkUpdate.Location = New System.Drawing.Point(23, 137)
Me.ChkUpdate.Name = "ChkUpdate"
Me.ChkUpdate.Size = New System.Drawing.Size(142, 19)
Me.ChkUpdate.TabIndex = 5
Me.ChkUpdate.Text = "Post flags to accts?"
'
'FrmTXE50B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(300, 270)
Me.ControlBox = False
Me.Controls.Add(Me.ChkUpdate)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.TxtDist)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.DtPckAgency)
Me.Controls.Add(Me.TxtStatus)
Me.Controls.Add(Me.LinkStatus)
Me.Controls.Add(Me.TxtGLToYear)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.TxtTypes)
Me.Controls.Add(Me.LnkTypes)
Me.Controls.Add(Me.TxtGLFromYear)
Me.Controls.Add(Me.Label3)
Me.KeyPreview = True
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTXE50B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
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
Private Sub FrmTXE50B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmTXE50.SbpPgmID.Text = "TXE50B"
    MyFrmTXE50.SbpEnvironment.Text = myDBConnect.PgmDB
End Sub
Private Sub FrmTXE50B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTXE50.SbpScreen.Text = "TXE50B"
End Sub
Private Sub FrmTXE50B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLToYear, "")
    ErrProv.SetError(TxtStatus, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "glyear"
        ErrProv.SetError(TxtGLToYear, ErrorMsg(I))
      Case "status"
        ErrProv.SetError(TxtStatus, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtGLFromYear.Text) = 0 Or MyUtils.CnvSng(TxtGLToYear.Text) = 0 Then
      ErrorField(I) = "glyear"
      ErrorMsg(I) = "GL Year Range is required"
      I = I + 1
    End If
    If MyUtils.CnvSng(TxtGLFromYear.Text) > MyUtils.CnvSng(TxtGLToYear.Text) Then
      ErrorField(I) = "glyear"
      ErrorMsg(I) = "Invalid GL Year Range"
      I = I + 1
    End If
    If TxtStatus.Text = "" Then
      ErrorField(I) = "status"
      ErrorMsg(I) = "Status code cannot be blank"
      I = I + 1
    End If

  End Sub
Private Sub FrmTXE50B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
  MyTypes = TxtTypes.Text
  MyFrmSelTypes = New FrmSelTypes
  MyFrmSelTypes.MdiParent = Me.ParentForm
  MyFrmSelTypes.Show()

End Sub

Private Sub LinkStatus_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkStatus.LinkClicked
  MySts = TxtStatus.Text
  MyFrmSelStatus = New FrmSelStatus
  MyFrmSelStatus.MdiParent = Me.ParentForm
  MyFrmSelStatus.Show()
End Sub
End Class






