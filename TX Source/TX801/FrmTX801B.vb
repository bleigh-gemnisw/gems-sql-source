Public Class FrmTX801B
    Inherits System.Windows.Forms.Form
  Dim ds As DataSet = New DataSet
  Friend Wrkrelegal As Integer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblFilePath As System.Windows.Forms.Label
    Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WrkTxType As String

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents TxtYear As System.Windows.Forms.TextBox
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents lblcount As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.TxtYear = New System.Windows.Forms.TextBox
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.label3 = New System.Windows.Forms.Label
Me.lblcount = New System.Windows.Forms.Label
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.LblFilePath = New System.Windows.Forms.Label
Me.LnkFilePath = New System.Windows.Forms.LinkLabel
Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox1.SuspendLayout()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label1.Location = New System.Drawing.Point(104, 22)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(133, 16)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Enter Grand List Year"
'
'TxtYear
'
Me.TxtYear.Location = New System.Drawing.Point(243, 18)
Me.TxtYear.MaxLength = 4
Me.TxtYear.Name = "TxtYear"
Me.TxtYear.Size = New System.Drawing.Size(32, 20)
Me.TxtYear.TabIndex = 0
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
Me.label3.Size = New System.Drawing.Size(89, 23)
Me.label3.TabIndex = 6
Me.label3.Text = "New file name"
Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'lblcount
'
Me.lblcount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.lblcount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lblcount.ForeColor = System.Drawing.Color.Maroon
Me.lblcount.Location = New System.Drawing.Point(62, 129)
Me.lblcount.Name = "lblcount"
Me.lblcount.Size = New System.Drawing.Size(324, 20)
Me.lblcount.TabIndex = 8
Me.lblcount.Text = "Total records transmitted "
Me.lblcount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
Me.lblcount.Visible = False
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.LblFilePath)
Me.GroupBox1.Controls.Add(Me.LnkFilePath)
Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox1.Location = New System.Drawing.Point(29, 55)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(408, 56)
Me.GroupBox1.TabIndex = 65
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "Bank Service File Details"
'
'LblFilePath
'
Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblFilePath.Location = New System.Drawing.Point(72, 16)
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
Me.LnkFilePath.TabIndex = 65
Me.LnkFilePath.TabStop = True
Me.LnkFilePath.Text = "File Path"
'
'FrmTX801B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(464, 165)
Me.ControlBox = False
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.lblcount)
Me.Controls.Add(Me.label3)
Me.Controls.Add(Me.TxtYear)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.KeyPreview = True
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX801B"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox1.ResumeLayout(False)
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

  Private Sub TX801B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim dft_year As Integer
    Dim dft_month As Integer

    dft_year = Year(Today)
    dft_month = Month(Today)
    If dft_month >= 7 Then
      dft_year = dft_year - 1
    End If

    TxtYear.Text = Format(Val(dft_year), "General Number")
  End Sub
  Private Sub TX801B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        MyFrmTX801.SbpScreen.Text = "TX801B"
        MyUtils.CenterForm(Me.ParentForm, Me)
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
  Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "path"
        ErrProv.SetError(LblFilePath, ErrorMsg(I))
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

    If LblFilePath.Text = "" Then
      ErrorField(I) = "path"
      ErrorMsg(I) = "File Path cannot be blank. Click on link to set."
      I = I + 1
    End If

  End Sub
Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
  With SaveFileDialog1
    .Filter = "Text files|*.txt"
    .ShowDialog()
    LblFilePath.Text = .FileName
  End With
End Sub
End Class






