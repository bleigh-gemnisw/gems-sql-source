Public Class FrmUB431B
  Inherits System.Windows.Forms.Form

  Friend ds As DataSet = New DataSet

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
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents TxtSoldCode As TextBox
  Friend WithEvents Label5 As Label
  Friend WithEvents TxtYear As TextBox
  Friend WithEvents Label2 As Label
  Friend WithEvents TxtRegCode As TextBox
  Friend WithEvents Label1 As Label
  Friend WithEvents TxtRegSize As TextBox
  Friend WithEvents Label3 As Label
  Friend WithEvents TxtSoldSize As TextBox
  Friend WithEvents Label4 As Label
  Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.ChkPost = New System.Windows.Forms.CheckBox()
    Me.TxtSoldCode = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtRegCode = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.TxtRegSize = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtSoldSize = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'ChkPost
    '
    Me.ChkPost.AutoSize = True
    Me.ChkPost.Location = New System.Drawing.Point(83, 158)
    Me.ChkPost.Name = "ChkPost"
    Me.ChkPost.Size = New System.Drawing.Size(84, 17)
    Me.ChkPost.TabIndex = 3
    Me.ChkPost.TabStop = False
    Me.ChkPost.Text = "Post to File?"
    '
    'TxtSoldCode
    '
    Me.TxtSoldCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSoldCode.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSoldCode.Location = New System.Drawing.Point(142, 74)
    Me.TxtSoldCode.MaxLength = 3
    Me.TxtSoldCode.Name = "TxtSoldCode"
    Me.TxtSoldCode.Size = New System.Drawing.Size(38, 22)
    Me.TxtSoldCode.TabIndex = 2
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(80, 78)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(56, 13)
    Me.Label5.TabIndex = 332
    Me.Label5.Text = "Sold Code"
    '
    'TxtRegCode
    '
    Me.TxtRegCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRegCode.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRegCode.Location = New System.Drawing.Point(142, 46)
    Me.TxtRegCode.MaxLength = 3
    Me.TxtRegCode.Name = "TxtRegCode"
    Me.TxtRegCode.Size = New System.Drawing.Size(38, 22)
    Me.TxtRegCode.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(64, 50)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(72, 13)
    Me.Label1.TabIndex = 334
    Me.Label1.Text = "Regular Code"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(45, 22)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(92, 13)
    Me.Label2.TabIndex = 335
    Me.Label2.Text = "Year property sold"
    '
    'TxtYear
    '
    Me.TxtYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtYear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(142, 18)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(38, 22)
    Me.TxtYear.TabIndex = 0
    '
    'TxtRegSize
    '
    Me.TxtRegSize.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRegSize.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRegSize.Location = New System.Drawing.Point(142, 102)
    Me.TxtRegSize.MaxLength = 1
    Me.TxtRegSize.Name = "TxtRegSize"
    Me.TxtRegSize.Size = New System.Drawing.Size(25, 22)
    Me.TxtRegSize.TabIndex = 336
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(40, 106)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(97, 13)
    Me.Label3.TabIndex = 339
    Me.Label3.Text = "Regular Meter Size"
    '
    'TxtSoldSize
    '
    Me.TxtSoldSize.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSoldSize.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSoldSize.Location = New System.Drawing.Point(142, 130)
    Me.TxtSoldSize.MaxLength = 1
    Me.TxtSoldSize.Name = "TxtSoldSize"
    Me.TxtSoldSize.Size = New System.Drawing.Size(25, 22)
    Me.TxtSoldSize.TabIndex = 337
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(55, 134)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(81, 13)
    Me.Label4.TabIndex = 338
    Me.Label4.Text = "Sold Meter Size"
    '
    'FrmUB431B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(242, 196)
    Me.ControlBox = False
    Me.Controls.Add(Me.TxtRegSize)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtSoldSize)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtRegCode)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtSoldCode)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.ChkPost)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.MaximizeBox = False
    Me.Name = "FrmUB431B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = " "
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmUB431B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    With MyAppSettings
      TxtRegCode.Text = .RegCode
      TxtSoldCode.Text = .SoldCode
      TxtRegSize.Text = .RegSize
      TxtSoldSize.Text = .SoldSize
    End With
  End Sub


  Private Sub FrmUB431B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmUB431.SbpScreen.Text = "UB431B"
    MyFrmUB431.TBarProcess.Enabled = True
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
  Public Sub RunImport()
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

    Impdata()
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Public Sub SaveSettings()
    With MyAppSettings
      .RegCode = TxtRegCode.Text
      .SoldCode = TxtSoldCode.Text
      .RegSize = TxtRegSize.Text
      .SoldSize = TxtSoldSize.Text
    End With
    SaveAppSettings()
  End Sub
End Class






