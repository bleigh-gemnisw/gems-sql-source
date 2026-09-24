Public Class FrmFixB
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
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LblAMSPath As Label
    Friend WithEvents LnkAMSPath As LinkLabel
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents GrpFile As GroupBox
    Friend WithEvents LblNewPath As Label
    Friend WithEvents LnkNewPath As LinkLabel
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents LblBaldPath As Label
    Friend WithEvents LnkBaldPath As LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label1 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblAMSPath = New System.Windows.Forms.Label()
        Me.LnkAMSPath = New System.Windows.Forms.LinkLabel()
        Me.GrpFile = New System.Windows.Forms.GroupBox()
        Me.LblNewPath = New System.Windows.Forms.Label()
        Me.LnkNewPath = New System.Windows.Forms.LinkLabel()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LblBaldPath = New System.Windows.Forms.Label()
        Me.LnkBaldPath = New System.Windows.Forms.LinkLabel()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GrpFile.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 211)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(488, 38)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Change CC's to use UNique ID instead of Bill Number"
        Me.Label1.UseMnemonic = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblAMSPath)
        Me.GroupBox1.Controls.Add(Me.LnkAMSPath)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(15, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 56)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "AMS Original File"
        '
        'LblAMSPath
        '
        Me.LblAMSPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAMSPath.Location = New System.Drawing.Point(72, 16)
        Me.LblAMSPath.Name = "LblAMSPath"
        Me.LblAMSPath.Size = New System.Drawing.Size(324, 36)
        Me.LblAMSPath.TabIndex = 67
        '
        'LnkAMSPath
        '
        Me.LnkAMSPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LnkAMSPath.Location = New System.Drawing.Point(12, 24)
        Me.LnkAMSPath.Name = "LnkAMSPath"
        Me.LnkAMSPath.Size = New System.Drawing.Size(52, 16)
        Me.LnkAMSPath.TabIndex = 65
        Me.LnkAMSPath.TabStop = True
        Me.LnkAMSPath.Text = "File Path"
        '
        'GrpFile
        '
        Me.GrpFile.Controls.Add(Me.LblNewPath)
        Me.GrpFile.Controls.Add(Me.LnkNewPath)
        Me.GrpFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpFile.Location = New System.Drawing.Point(15, 152)
        Me.GrpFile.Name = "GrpFile"
        Me.GrpFile.Size = New System.Drawing.Size(408, 56)
        Me.GrpFile.TabIndex = 67
        Me.GrpFile.TabStop = False
        Me.GrpFile.Text = "New AMS File"
        '
        'LblNewPath
        '
        Me.LblNewPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNewPath.Location = New System.Drawing.Point(72, 16)
        Me.LblNewPath.Name = "LblNewPath"
        Me.LblNewPath.Size = New System.Drawing.Size(324, 36)
        Me.LblNewPath.TabIndex = 67
        '
        'LnkNewPath
        '
        Me.LnkNewPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LnkNewPath.Location = New System.Drawing.Point(12, 24)
        Me.LnkNewPath.Name = "LnkNewPath"
        Me.LnkNewPath.Size = New System.Drawing.Size(52, 16)
        Me.LnkNewPath.TabIndex = 65
        Me.LnkNewPath.TabStop = True
        Me.LnkNewPath.Text = "File Path"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LblBaldPath)
        Me.GroupBox2.Controls.Add(Me.LnkBaldPath)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(15, 94)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(408, 56)
        Me.GroupBox2.TabIndex = 68
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Balance Due File"
        '
        'LblBaldPath
        '
        Me.LblBaldPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBaldPath.Location = New System.Drawing.Point(72, 16)
        Me.LblBaldPath.Name = "LblBaldPath"
        Me.LblBaldPath.Size = New System.Drawing.Size(324, 36)
        Me.LblBaldPath.TabIndex = 67
        '
        'LnkBaldPath
        '
        Me.LnkBaldPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LnkBaldPath.Location = New System.Drawing.Point(12, 24)
        Me.LnkBaldPath.Name = "LnkBaldPath"
        Me.LnkBaldPath.Size = New System.Drawing.Size(52, 16)
        Me.LnkBaldPath.TabIndex = 65
        Me.LnkBaldPath.TabStop = True
        Me.LnkBaldPath.Text = "File Path"
        '
        'FrmFixB
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(512, 258)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GrpFile)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "FrmFixB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GrpFile.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmFixB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    LblAMSPath.Text = "C:/bills/files/southington/so combined2.csv"
    LblBaldPath.Text = "C:/bills/files/southington/bald.csv"
    LblNewPath.Text = "C:/bills/files/southington/soplants.csv"
  End Sub


  Private Sub FrmFixB_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmFix.SbpScreen.Text = "FixB"
    MyFrmFix.TBarProcess.Enabled = True
    'CenterForm(Me.ParentForm, Me)
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

  Private Sub LnkAMSPath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkAMSPath.LinkClicked
    With OpenFileDialog1
      .ReadOnlyChecked = True
      .ShowDialog()
      LblAMSPath.Text = .FileName
    End With
  End Sub
  Private Sub LnkBaldPath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBaldPath.LinkClicked
    With OpenFileDialog1
      .ReadOnlyChecked = True
      .ShowDialog()
      LblBaldPath.Text = .FileName
    End With
  End Sub

  Private Sub LnkNewPath_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkNewPath.LinkClicked
    With SaveFileDialog1
      .ShowDialog()
      LblNewPath.Text = .FileName
    End With
  End Sub
End Class
