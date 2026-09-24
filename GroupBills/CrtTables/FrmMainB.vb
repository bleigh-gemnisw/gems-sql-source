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
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtName As System.Windows.Forms.TextBox
Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
Friend WithEvents GrpMV As System.Windows.Forms.GroupBox
Friend WithEvents LblFilePathMV As System.Windows.Forms.Label
Friend WithEvents LnkFilePathMV As System.Windows.Forms.LinkLabel
Friend WithEvents GrpRE As System.Windows.Forms.GroupBox
Friend WithEvents LblFilePathRE As System.Windows.Forms.Label
Friend WithEvents LnkFilePathRE As System.Windows.Forms.LinkLabel
Friend WithEvents GrpPP As System.Windows.Forms.GroupBox
Friend WithEvents LblFilePathPP As System.Windows.Forms.Label
Friend WithEvents LnkFilePathPP As System.Windows.Forms.LinkLabel
Friend WithEvents Label11 As System.Windows.Forms.Label
Friend WithEvents TxtTownNo As System.Windows.Forms.TextBox
Friend WithEvents GrpMS As System.Windows.Forms.GroupBox
Friend WithEvents LblFilePathMS As System.Windows.Forms.Label
Friend WithEvents LnkFilePathMS As System.Windows.Forms.LinkLabel
Friend WithEvents RbRPM As System.Windows.Forms.RadioButton
Friend WithEvents RbS As System.Windows.Forms.RadioButton
Friend WithEvents Label1 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.GrpMV = New System.Windows.Forms.GroupBox()
    Me.LblFilePathMV = New System.Windows.Forms.Label()
    Me.LnkFilePathMV = New System.Windows.Forms.LinkLabel()
    Me.GrpRE = New System.Windows.Forms.GroupBox()
    Me.LblFilePathRE = New System.Windows.Forms.Label()
    Me.LnkFilePathRE = New System.Windows.Forms.LinkLabel()
    Me.GrpPP = New System.Windows.Forms.GroupBox()
    Me.LblFilePathPP = New System.Windows.Forms.Label()
    Me.LnkFilePathPP = New System.Windows.Forms.LinkLabel()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.TxtTownNo = New System.Windows.Forms.TextBox()
    Me.GrpMS = New System.Windows.Forms.GroupBox()
    Me.LblFilePathMS = New System.Windows.Forms.Label()
    Me.LnkFilePathMS = New System.Windows.Forms.LinkLabel()
    Me.RbRPM = New System.Windows.Forms.RadioButton()
    Me.RbS = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpMV.SuspendLayout()
    Me.GrpRE.SuspendLayout()
    Me.GrpPP.SuspendLayout()
    Me.GrpMS.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(12, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(392, 38)
    Me.Label1.TabIndex = 0
    '
    'TxtName
    '
    Me.TxtName.Location = New System.Drawing.Point(175, 58)
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(126, 20)
    Me.TxtName.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(117, 61)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(52, 13)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "File name"
    '
    'GrpMV
    '
    Me.GrpMV.Controls.Add(Me.LblFilePathMV)
    Me.GrpMV.Controls.Add(Me.LnkFilePathMV)
    Me.GrpMV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpMV.Location = New System.Drawing.Point(9, 218)
    Me.GrpMV.Name = "GrpMV"
    Me.GrpMV.Size = New System.Drawing.Size(408, 56)
    Me.GrpMV.TabIndex = 69
    Me.GrpMV.TabStop = False
    Me.GrpMV.Text = "MV Bill File Details"
    '
    'LblFilePathMV
    '
    Me.LblFilePathMV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePathMV.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePathMV.Name = "LblFilePathMV"
    Me.LblFilePathMV.Size = New System.Drawing.Size(324, 36)
    Me.LblFilePathMV.TabIndex = 67
    '
    'LnkFilePathMV
    '
    Me.LnkFilePathMV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePathMV.Location = New System.Drawing.Point(12, 24)
    Me.LnkFilePathMV.Name = "LnkFilePathMV"
    Me.LnkFilePathMV.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePathMV.TabIndex = 65
    Me.LnkFilePathMV.TabStop = True
    Me.LnkFilePathMV.Text = "File Path"
    '
    'GrpRE
    '
    Me.GrpRE.Controls.Add(Me.LblFilePathRE)
    Me.GrpRE.Controls.Add(Me.LnkFilePathRE)
    Me.GrpRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpRE.Location = New System.Drawing.Point(9, 94)
    Me.GrpRE.Name = "GrpRE"
    Me.GrpRE.Size = New System.Drawing.Size(408, 56)
    Me.GrpRE.TabIndex = 70
    Me.GrpRE.TabStop = False
    Me.GrpRE.Text = "RE Bill File Details"
    '
    'LblFilePathRE
    '
    Me.LblFilePathRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePathRE.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePathRE.Name = "LblFilePathRE"
    Me.LblFilePathRE.Size = New System.Drawing.Size(324, 36)
    Me.LblFilePathRE.TabIndex = 67
    '
    'LnkFilePathRE
    '
    Me.LnkFilePathRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePathRE.Location = New System.Drawing.Point(12, 24)
    Me.LnkFilePathRE.Name = "LnkFilePathRE"
    Me.LnkFilePathRE.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePathRE.TabIndex = 65
    Me.LnkFilePathRE.TabStop = True
    Me.LnkFilePathRE.Text = "File Path"
    '
    'GrpPP
    '
    Me.GrpPP.Controls.Add(Me.LblFilePathPP)
    Me.GrpPP.Controls.Add(Me.LnkFilePathPP)
    Me.GrpPP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpPP.Location = New System.Drawing.Point(9, 156)
    Me.GrpPP.Name = "GrpPP"
    Me.GrpPP.Size = New System.Drawing.Size(408, 56)
    Me.GrpPP.TabIndex = 72
    Me.GrpPP.TabStop = False
    Me.GrpPP.Text = "PP Bill File Details"
    '
    'LblFilePathPP
    '
    Me.LblFilePathPP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePathPP.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePathPP.Name = "LblFilePathPP"
    Me.LblFilePathPP.Size = New System.Drawing.Size(324, 36)
    Me.LblFilePathPP.TabIndex = 67
    '
    'LnkFilePathPP
    '
    Me.LnkFilePathPP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePathPP.Location = New System.Drawing.Point(12, 24)
    Me.LnkFilePathPP.Name = "LnkFilePathPP"
    Me.LnkFilePathPP.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePathPP.TabIndex = 65
    Me.LnkFilePathPP.TabStop = True
    Me.LnkFilePathPP.Text = "File Path"
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(12, 61)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(51, 13)
    Me.Label11.TabIndex = 100
    Me.Label11.Text = "Town No"
    '
    'TxtTownNo
    '
    Me.TxtTownNo.Location = New System.Drawing.Point(70, 58)
    Me.TxtTownNo.Name = "TxtTownNo"
    Me.TxtTownNo.Size = New System.Drawing.Size(30, 20)
    Me.TxtTownNo.TabIndex = 0
    '
    'GrpMS
    '
    Me.GrpMS.Controls.Add(Me.LblFilePathMS)
    Me.GrpMS.Controls.Add(Me.LnkFilePathMS)
    Me.GrpMS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpMS.Location = New System.Drawing.Point(9, 281)
    Me.GrpMS.Name = "GrpMS"
    Me.GrpMS.Size = New System.Drawing.Size(408, 56)
    Me.GrpMS.TabIndex = 101
    Me.GrpMS.TabStop = False
    Me.GrpMS.Text = "MS Bill File Details"
    '
    'LblFilePathMS
    '
    Me.LblFilePathMS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePathMS.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePathMS.Name = "LblFilePathMS"
    Me.LblFilePathMS.Size = New System.Drawing.Size(324, 36)
    Me.LblFilePathMS.TabIndex = 67
    '
    'LnkFilePathMS
    '
    Me.LnkFilePathMS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePathMS.Location = New System.Drawing.Point(12, 24)
    Me.LnkFilePathMS.Name = "LnkFilePathMS"
    Me.LnkFilePathMS.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePathMS.TabIndex = 65
    Me.LnkFilePathMS.TabStop = True
    Me.LnkFilePathMS.Text = "File Path"
    '
    'RbRPM
    '
    Me.RbRPM.AutoSize = True
    Me.RbRPM.Checked = True
    Me.RbRPM.Location = New System.Drawing.Point(307, 59)
    Me.RbRPM.Name = "RbRPM"
    Me.RbRPM.Size = New System.Drawing.Size(59, 17)
    Me.RbRPM.TabIndex = 102
    Me.RbRPM.TabStop = True
    Me.RbRPM.Text = "R/P/M"
    Me.RbRPM.UseVisualStyleBackColor = True
    '
    'RbS
    '
    Me.RbS.AutoSize = True
    Me.RbS.Location = New System.Drawing.Point(377, 59)
    Me.RbS.Name = "RbS"
    Me.RbS.Size = New System.Drawing.Size(32, 17)
    Me.RbS.TabIndex = 103
    Me.RbS.Text = "S"
    Me.RbS.UseVisualStyleBackColor = True
    '
    'FrmMainB
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(441, 358)
    Me.ControlBox = False
    Me.Controls.Add(Me.RbS)
    Me.Controls.Add(Me.RbRPM)
    Me.Controls.Add(Me.GrpMS)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.TxtTownNo)
    Me.Controls.Add(Me.GrpPP)
    Me.Controls.Add(Me.GrpRE)
    Me.Controls.Add(Me.GrpMV)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtName)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.MaximizeBox = False
    Me.Name = "FrmMainB"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpMV.ResumeLayout(False)
    Me.GrpRE.ResumeLayout(False)
    Me.GrpPP.ResumeLayout(False)
    Me.GrpMS.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmFixB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  SetTypes(True)
End Sub


Private Sub FrmFixB_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
 MyFrmMain.SbpScreen.Text = "MainB"
 MyFrmMain.TBarProcess.Enabled = True
 CenterForm(Me.ParentForm, Me)
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

    ProcTable()
    Windows.Forms.Cursor.Current = Cursors.Default
End Sub
Private Sub LnkFilePathRE_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePathRE.LinkClicked
  With OpenFileDialog1
   .ShowDialog()
   LblFilePathRE.Text = .FileName
  End With
End Sub
Private Sub LnkFilePathPP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePathPP.LinkClicked
  With OpenFileDialog1
   .ShowDialog()
   LblFilePathPP.Text = .FileName
  End With
End Sub
Private Sub LnkFilePathMV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePathMV.LinkClicked
  With OpenFileDialog1
   .ShowDialog()
   LblFilePathMV.Text = .FileName
  End With
End Sub
Private Sub LnkFilePathMS_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePathMS.LinkClicked
  With OpenFileDialog1
   .ShowDialog()
   LblFilePathMS.Text = .FileName
  End With
End Sub
  Private Sub TxtTownNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTownNo.LostFocus
    LoadSettings()
  End Sub
Private Sub LoadSettings()
    MyTownNo = CnvSng(TxtTownNo.Text)
    GetAppSettings()
    If MyAppSettings.DBName = String.Empty Then Exit Sub

    With MyFrmMainB
      .TxtName.Text = MyAppSettings.DBName
      If MyAppSettings.IsRPM Then
        .RbRPM.Checked = True
      Else
        .RbS.Checked = True
      End If
      .LblFilePathRE.Text = MyAppSettings.REFile
      .LblFilePathPP.Text = MyAppSettings.PPFile
      .LblFilePathMV.Text = MyAppSettings.MVFile
      .LblFilePathMS.Text = MyAppSettings.MSFile
      SetTypes(MyAppSettings.IsRPM)
    End With
End Sub
  Private Sub RbRPM_Click(sender As Object, e As EventArgs) Handles RbRPM.Click
    SetTypes(True)
  End Sub
  Private Sub RbS_Click(sender As Object, e As EventArgs) Handles RbS.Click
    SetTypes(False)
  End Sub
Private Sub SetTypes(ByVal IsRPM As Boolean)
  GrpRE.Enabled = IsRPM
  GrpPP.Enabled = IsRPM
  GrpMV.Enabled = IsRPM
  GrpMS.Enabled = Not IsRPM
End Sub

Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

End Sub
End Class
