Public Class FrmMainB
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
'    Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
Friend WithEvents GrpFile As System.Windows.Forms.GroupBox
Friend WithEvents LblFilePath As System.Windows.Forms.Label
Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
Friend WithEvents ChkAddr As System.Windows.Forms.CheckBox
Friend WithEvents ChkPostal As System.Windows.Forms.CheckBox
Friend WithEvents RbExport As System.Windows.Forms.RadioButton
Friend WithEvents RbImport As System.Windows.Forms.RadioButton
Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
Friend WithEvents TxtGroupID As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents Label11 As System.Windows.Forms.Label
Friend WithEvents TxtTownNo As System.Windows.Forms.TextBox
Friend WithEvents LblName As System.Windows.Forms.Label
Friend WithEvents LblTypes As System.Windows.Forms.Label
Friend WithEvents RbSetPostal As System.Windows.Forms.RadioButton
Friend WithEvents Label1 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label1 = New System.Windows.Forms.Label()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.GrpFile = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.ChkAddr = New System.Windows.Forms.CheckBox()
    Me.ChkPostal = New System.Windows.Forms.CheckBox()
    Me.RbImport = New System.Windows.Forms.RadioButton()
    Me.RbExport = New System.Windows.Forms.RadioButton()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.TxtGroupID = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.TxtTownNo = New System.Windows.Forms.TextBox()
    Me.LblName = New System.Windows.Forms.Label()
    Me.LblTypes = New System.Windows.Forms.Label()
    Me.RbSetPostal = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpFile.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(15, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(392, 38)
    Me.Label1.TabIndex = 0
    '
    'GrpFile
    '
    Me.GrpFile.Controls.Add(Me.LblFilePath)
    Me.GrpFile.Controls.Add(Me.LnkFilePath)
    Me.GrpFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpFile.Location = New System.Drawing.Point(11, 127)
    Me.GrpFile.Name = "GrpFile"
    Me.GrpFile.Size = New System.Drawing.Size(408, 56)
    Me.GrpFile.TabIndex = 69
    Me.GrpFile.TabStop = False
    Me.GrpFile.Text = "File Details"
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
    'ChkAddr
    '
    Me.ChkAddr.AutoSize = True
    Me.ChkAddr.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkAddr.Location = New System.Drawing.Point(14, 199)
    Me.ChkAddr.Name = "ChkAddr"
    Me.ChkAddr.Size = New System.Drawing.Size(70, 17)
    Me.ChkAddr.TabIndex = 71
    Me.ChkAddr.Text = "Address?"
    Me.ChkAddr.UseVisualStyleBackColor = True
    '
    'ChkPostal
    '
    Me.ChkPostal.AutoSize = True
    Me.ChkPostal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPostal.Checked = True
    Me.ChkPostal.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkPostal.Location = New System.Drawing.Point(110, 199)
    Me.ChkPostal.Name = "ChkPostal"
    Me.ChkPostal.Size = New System.Drawing.Size(61, 17)
    Me.ChkPostal.TabIndex = 72
    Me.ChkPostal.Text = "Postal?"
    Me.ChkPostal.UseVisualStyleBackColor = True
    '
    'RbImport
    '
    Me.RbImport.AutoSize = True
    Me.RbImport.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbImport.Checked = True
    Me.RbImport.Location = New System.Drawing.Point(14, 93)
    Me.RbImport.Name = "RbImport"
    Me.RbImport.Size = New System.Drawing.Size(54, 17)
    Me.RbImport.TabIndex = 73
    Me.RbImport.TabStop = True
    Me.RbImport.Text = "Import"
    Me.RbImport.UseVisualStyleBackColor = True
    '
    'RbExport
    '
    Me.RbExport.AutoSize = True
    Me.RbExport.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbExport.Location = New System.Drawing.Point(101, 93)
    Me.RbExport.Name = "RbExport"
    Me.RbExport.Size = New System.Drawing.Size(55, 17)
    Me.RbExport.TabIndex = 74
    Me.RbExport.Text = "Export"
    Me.RbExport.UseVisualStyleBackColor = True
    '
    'TxtGroupID
    '
    Me.TxtGroupID.Location = New System.Drawing.Point(233, 90)
    Me.TxtGroupID.Name = "TxtGroupID"
    Me.TxtGroupID.Size = New System.Drawing.Size(28, 20)
    Me.TxtGroupID.TabIndex = 75
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(177, 95)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(50, 13)
    Me.Label3.TabIndex = 76
    Me.Label3.Text = "Group ID"
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(17, 68)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(51, 13)
    Me.Label11.TabIndex = 105
    Me.Label11.Text = "Town No"
    '
    'TxtTownNo
    '
    Me.TxtTownNo.Location = New System.Drawing.Point(75, 65)
    Me.TxtTownNo.Name = "TxtTownNo"
    Me.TxtTownNo.Size = New System.Drawing.Size(30, 20)
    Me.TxtTownNo.TabIndex = 0
    '
    'LblName
    '
    Me.LblName.AutoSize = True
    Me.LblName.Location = New System.Drawing.Point(111, 59)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(64, 13)
    Me.LblName.TabIndex = 103
    Me.LblName.Text = "<File name>"
    '
    'LblTypes
    '
    Me.LblTypes.AutoSize = True
    Me.LblTypes.Location = New System.Drawing.Point(111, 72)
    Me.LblTypes.Name = "LblTypes"
    Me.LblTypes.Size = New System.Drawing.Size(48, 13)
    Me.LblTypes.TabIndex = 106
    Me.LblTypes.Text = "<Types>"
    '
    'RbSetPostal
    '
    Me.RbSetPostal.AutoSize = True
    Me.RbSetPostal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSetPostal.Location = New System.Drawing.Point(286, 93)
    Me.RbSetPostal.Name = "RbSetPostal"
    Me.RbSetPostal.Size = New System.Drawing.Size(73, 17)
    Me.RbSetPostal.TabIndex = 107
    Me.RbSetPostal.Text = "Set Postal"
    Me.RbSetPostal.UseVisualStyleBackColor = True
    '
    'FrmMainB
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(429, 241)
    Me.ControlBox = False
    Me.Controls.Add(Me.RbSetPostal)
    Me.Controls.Add(Me.LblTypes)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.TxtTownNo)
    Me.Controls.Add(Me.LblName)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtGroupID)
    Me.Controls.Add(Me.RbExport)
    Me.Controls.Add(Me.RbImport)
    Me.Controls.Add(Me.ChkPostal)
    Me.Controls.Add(Me.ChkAddr)
    Me.Controls.Add(Me.GrpFile)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.MaximizeBox = False
    Me.Name = "FrmMainB"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpFile.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmFixB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
   MyFrmMain.TBarExport.Enabled = False
   MyFrmMain.TBarSetPostal.Enabled = False
   LblName.Text = String.Empty
 End Sub


Private Sub FrmFixB_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
 MyFrmMain.SbpScreen.Text = "MainB"
 MyFrmMain.TBarImport.Enabled = True
 CenterForm(Me.ParentForm, Me)
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
Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If LblName.Text = String.Empty Then
      ErrorField(I) = "file"
      ErrorMsg(I) = "File not set"
      I = I + 1
    End If
  End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(LblName, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "file"
        ErrProv.SetError(LblName, ErrorMsg(I))
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

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    ProcTable()
    Windows.Forms.Cursor.Current = Cursors.Default
End Sub
Public Sub RunExport()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    ProcTable()
    Windows.Forms.Cursor.Current = Cursors.Default
End Sub
Public Sub RunPostalBarCode()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    ProcTable()
    Windows.Forms.Cursor.Current = Cursors.Default
End Sub
Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
  If RbImport.Checked Then
    With OpenFileDialog1
      .ShowDialog()
      LblFilePath.Text = .FileName
    End With
  Else
    With SaveFileDialog1
      .ShowDialog()
      LblFilePath.Text = .FileName
    End With
  End If
End Sub
  Private Sub RbImport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbImport.Click
    MyFrmMain.TBarImport.Enabled = True
    MyFrmMain.TBarExport.Enabled = False
    MyFrmMain.TBarSetPostal.Enabled = False
    ChkAddr.Enabled = False
    GrpFile.Enabled = True
  End Sub
  Private Sub RbExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbExport.Click
    MyFrmMain.TBarImport.Enabled = False
    MyFrmMain.TBarExport.Enabled = True
    MyFrmMain.TBarSetPostal.Enabled = False
    ChkAddr.Enabled = False
    GrpFile.Enabled = True
  End Sub
  Private Sub RbSetPostal_Click(sender As Object, e As EventArgs) Handles RbSetPostal.Click
    MyFrmMain.TBarImport.Enabled = False
    MyFrmMain.TBarExport.Enabled = False
    MyFrmMain.TBarSetPostal.Enabled = True
    ChkAddr.Enabled = False
    GrpFile.Enabled = False
  End Sub
End Class
