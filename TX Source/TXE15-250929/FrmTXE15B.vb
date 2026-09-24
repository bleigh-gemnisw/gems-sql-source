Public Class FrmTXE15B
Inherits System.Windows.Forms.Form

Dim WrkTxType As String

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
  Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
Friend WithEvents TxtToGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents groupbox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbSU As System.Windows.Forms.RadioButton
Friend WithEvents RbMV As System.Windows.Forms.RadioButton
Friend WithEvents RbPP As System.Windows.Forms.RadioButton
Friend WithEvents RbRE As System.Windows.Forms.RadioButton
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents DtPckInt As System.Windows.Forms.DateTimePicker
Friend WithEvents Chkupdatebacktax As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TxtFromGLYear = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TxtToGLYear = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.Chkupdatebacktax = New System.Windows.Forms.CheckBox
Me.groupbox1 = New System.Windows.Forms.GroupBox
Me.RbSU = New System.Windows.Forms.RadioButton
Me.RbMV = New System.Windows.Forms.RadioButton
Me.RbPP = New System.Windows.Forms.RadioButton
Me.RbRE = New System.Windows.Forms.RadioButton
Me.Label1 = New System.Windows.Forms.Label
Me.DtPckInt = New System.Windows.Forms.DateTimePicker
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.groupbox1.SuspendLayout()
Me.SuspendLayout()
'
'TxtFromGLYear
'
Me.TxtFromGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFromGLYear.Location = New System.Drawing.Point(128, 56)
Me.TxtFromGLYear.MaxLength = 4
Me.TxtFromGLYear.Name = "TxtFromGLYear"
Me.TxtFromGLYear.Size = New System.Drawing.Size(36, 20)
Me.TxtFromGLYear.TabIndex = 1
'
'Label4
'
Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label4.Location = New System.Drawing.Point(19, 60)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(101, 16)
Me.Label4.TabIndex = 11
Me.Label4.Text = "Grand List Year"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'TxtToGLYear
'
Me.TxtToGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtToGLYear.Location = New System.Drawing.Point(192, 56)
Me.TxtToGLYear.MaxLength = 4
Me.TxtToGLYear.Name = "TxtToGLYear"
Me.TxtToGLYear.Size = New System.Drawing.Size(36, 20)
Me.TxtToGLYear.TabIndex = 2
'
'Label3
'
Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label3.Location = New System.Drawing.Point(168, 60)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(27, 16)
Me.Label3.TabIndex = 19
Me.Label3.Text = "to"
'
'Chkupdatebacktax
'
Me.Chkupdatebacktax.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.Chkupdatebacktax.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Chkupdatebacktax.Location = New System.Drawing.Point(19, 119)
Me.Chkupdatebacktax.Name = "Chkupdatebacktax"
Me.Chkupdatebacktax.Size = New System.Drawing.Size(240, 30)
Me.Chkupdatebacktax.TabIndex = 4
Me.Chkupdatebacktax.Text = "Update records with back tax code?"
'
'groupbox1
'
Me.groupbox1.Controls.Add(Me.RbSU)
Me.groupbox1.Controls.Add(Me.RbMV)
Me.groupbox1.Controls.Add(Me.RbPP)
Me.groupbox1.Controls.Add(Me.RbRE)
Me.groupbox1.Location = New System.Drawing.Point(12, 6)
Me.groupbox1.Name = "groupbox1"
Me.groupbox1.Size = New System.Drawing.Size(464, 44)
Me.groupbox1.TabIndex = 0
Me.groupbox1.TabStop = False
Me.groupbox1.Text = "Select Type For Back Tax"
'
'RbSU
'
Me.RbSU.Location = New System.Drawing.Point(343, 19)
Me.RbSU.Name = "RbSU"
Me.RbSU.Size = New System.Drawing.Size(112, 17)
Me.RbSU.TabIndex = 7
Me.RbSU.Text = "S&upplemental MV"
'
'RbMV
'
Me.RbMV.Location = New System.Drawing.Point(231, 19)
Me.RbMV.Name = "RbMV"
Me.RbMV.Size = New System.Drawing.Size(96, 17)
Me.RbMV.TabIndex = 6
Me.RbMV.Text = "&Motor Vehicle"
'
'RbPP
'
Me.RbPP.Location = New System.Drawing.Point(103, 19)
Me.RbPP.Name = "RbPP"
Me.RbPP.Size = New System.Drawing.Size(120, 17)
Me.RbPP.TabIndex = 5
Me.RbPP.Text = "P&ersonal Property"
'
'RbRE
'
Me.RbRE.Checked = True
Me.RbRE.Location = New System.Drawing.Point(7, 19)
Me.RbRE.Name = "RbRE"
Me.RbRE.Size = New System.Drawing.Size(88, 17)
Me.RbRE.TabIndex = 4
Me.RbRE.TabStop = True
Me.RbRE.Text = "&Real Estate"
'
'Label1
'
Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label1.Location = New System.Drawing.Point(23, 90)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(112, 20)
Me.Label1.TabIndex = 32
Me.Label1.Text = "Balances as of "
'
'DtPckInt
'
Me.DtPckInt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckInt.Location = New System.Drawing.Point(141, 90)
Me.DtPckInt.Name = "DtPckInt"
Me.DtPckInt.Size = New System.Drawing.Size(88, 20)
Me.DtPckInt.TabIndex = 3
Me.DtPckInt.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
'
'FrmTXE15B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(479, 161)
Me.ControlBox = False
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.DtPckInt)
Me.Controls.Add(Me.groupbox1)
Me.Controls.Add(Me.Chkupdatebacktax)
Me.Controls.Add(Me.TxtToGLYear)
Me.Controls.Add(Me.TxtFromGLYear)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Label4)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTXE15B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.groupbox1.ResumeLayout(False)
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTXE15B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTXE15.SbpScreen.Text = "TXE15"
End Sub


Private Sub FrmTXE15B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFromGLYear, "")
    ErrProv.SetError(TxtToGLYear, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "fromglyear"
        ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
      Case "toglyear"
        ErrProv.SetError(TxtToGLYear, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtFromGLYear.Text) > MyUtils.CnvSng(TxtToGLYear.Text) Then
      ErrorField(I) = "fromglyear"
      ErrorMsg(I) = "Invalid Year Range"
      I = I + 1
      ErrorField(I) = "toglyear"
      ErrorMsg(I) = "Invalid Year Range"
      I = I + 1
    End If

  End Sub

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
Private Sub TxtFromGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtToGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub FrmTXE15B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	DtPckInt.Value = Date.Today
End Sub
End Class






