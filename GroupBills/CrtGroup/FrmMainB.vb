Public Class FrmMainB
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
Friend WithEvents LblName As System.Windows.Forms.Label
Friend WithEvents ChkLastName As System.Windows.Forms.CheckBox
Friend WithEvents ChkReduction As System.Windows.Forms.CheckBox
Friend WithEvents Label11 As System.Windows.Forms.Label
Friend WithEvents TxtTownNo As System.Windows.Forms.TextBox
Friend WithEvents LblTypes As System.Windows.Forms.Label
Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.LblName = New System.Windows.Forms.Label()
    Me.ChkLastName = New System.Windows.Forms.CheckBox()
    Me.ChkReduction = New System.Windows.Forms.CheckBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.TxtTownNo = New System.Windows.Forms.TextBox()
    Me.LblTypes = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LblName
    '
    Me.LblName.AutoSize = True
    Me.LblName.Location = New System.Drawing.Point(197, 53)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(64, 13)
    Me.LblName.TabIndex = 4
    Me.LblName.Text = "<File name>"
    '
    'ChkLastName
    '
    Me.ChkLastName.AutoSize = True
    Me.ChkLastName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkLastName.Location = New System.Drawing.Point(106, 101)
    Me.ChkLastName.Name = "ChkLastName"
    Me.ChkLastName.Size = New System.Drawing.Size(230, 17)
    Me.ChkLastName.TabIndex = 5
    Me.ChkLastName.Text = "Group Same Address/Last Name together?"
    Me.ChkLastName.UseVisualStyleBackColor = True
    '
    'ChkReduction
    '
    Me.ChkReduction.AutoSize = True
    Me.ChkReduction.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkReduction.Location = New System.Drawing.Point(106, 124)
    Me.ChkReduction.Name = "ChkReduction"
    Me.ChkReduction.Size = New System.Drawing.Size(148, 17)
    Me.ChkReduction.TabIndex = 7
    Me.ChkReduction.Text = "Only Reduction numbers?"
    Me.ChkReduction.UseVisualStyleBackColor = True
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(103, 53)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(51, 13)
    Me.Label11.TabIndex = 102
    Me.Label11.Text = "Town No"
    '
    'TxtTownNo
    '
    Me.TxtTownNo.Location = New System.Drawing.Point(161, 50)
    Me.TxtTownNo.Name = "TxtTownNo"
    Me.TxtTownNo.Size = New System.Drawing.Size(30, 20)
    Me.TxtTownNo.TabIndex = 0
    '
    'LblTypes
    '
    Me.LblTypes.AutoSize = True
    Me.LblTypes.Location = New System.Drawing.Point(197, 69)
    Me.LblTypes.Name = "LblTypes"
    Me.LblTypes.Size = New System.Drawing.Size(48, 13)
    Me.LblTypes.TabIndex = 103
    Me.LblTypes.Text = "<Types>"
    '
    'FrmMainB
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(434, 184)
    Me.ControlBox = False
    Me.Controls.Add(Me.LblTypes)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.TxtTownNo)
    Me.Controls.Add(Me.ChkReduction)
    Me.Controls.Add(Me.ChkLastName)
    Me.Controls.Add(Me.LblName)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmMainB"
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
    ProcFile()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
Private Sub FrmMainB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmMain.SbpPgmID.Text = "Main"
    LblName.Text = ""
    LblTypes.Text = ""
End Sub
Private Sub FrmMainB_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmMain.SbpScreen.Text = "MainB"
End Sub
Private Sub FrmMainB_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
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
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next
 End Sub
  Private Sub TxtTownNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTownNo.LostFocus
    LoadSettings()
  End Sub
Private Sub LoadSettings()
    MyTownNo = CnvSng(TxtTownNo.Text)
    GetAppSettings()
    If MyAppSettings.DBName = String.Empty Then Exit Sub

    With MyFrmMainB
      .LblName.Text = MyAppSettings.DBName
      If MyAppSettings.IsRPM Then
        .LblTypes.Text = "R/P/M"
      Else
        .LblTypes.Text = "S"
      End If
    End With
End Sub

Private Sub TxtTownNo_TextChanged(sender As Object, e As EventArgs) Handles TxtTownNo.TextChanged

End Sub
End Class
