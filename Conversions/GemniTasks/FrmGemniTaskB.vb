Public Class FrmGemniTaskB
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
  Friend WithEvents Btntask1 As Button
  Friend WithEvents Label1 As Label
  Friend WithEvents GroupBox1 As GroupBox
  Friend WithEvents LblFilePath1 As Label
  Friend WithEvents LnkFilePath1 As LinkLabel
  Friend WithEvents OpenFileDialog1 As OpenFileDialog
  Friend WithEvents SaveFileDialog1 As SaveFileDialog
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Btntask1 = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblFilePath1 = New System.Windows.Forms.Label()
    Me.LnkFilePath1 = New System.Windows.Forms.LinkLabel()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Btntask1
    '
    Me.Btntask1.Location = New System.Drawing.Point(481, 92)
    Me.Btntask1.Name = "Btntask1"
    Me.Btntask1.Size = New System.Drawing.Size(118, 61)
    Me.Btntask1.TabIndex = 0
    Me.Btntask1.Text = "Load Meter#"
    Me.Btntask1.UseVisualStyleBackColor = True
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(64, 70)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(203, 13)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "Load Meter # to UTCUST using Regional"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LblFilePath1)
    Me.GroupBox1.Controls.Add(Me.LnkFilePath1)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(53, 97)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(408, 56)
    Me.GroupBox1.TabIndex = 6
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Load Meter# to UTCUST using Regional file format on Location"
    '
    'LblFilePath1
    '
    Me.LblFilePath1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath1.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePath1.Name = "LblFilePath1"
    Me.LblFilePath1.Size = New System.Drawing.Size(324, 36)
    Me.LblFilePath1.TabIndex = 67
    '
    'LnkFilePath1
    '
    Me.LnkFilePath1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePath1.Location = New System.Drawing.Point(12, 24)
    Me.LnkFilePath1.Name = "LnkFilePath1"
    Me.LnkFilePath1.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePath1.TabIndex = 65
    Me.LnkFilePath1.TabStop = True
    Me.LnkFilePath1.Text = "File Path"
    '
    'FrmGemniTaskB
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(984, 515)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Btntask1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.MaximizeBox = False
    Me.Name = "FrmGemniTaskB"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmGemniTaskB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  End Sub


  Private Sub FrmGemniTaskB_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGemniTask.SbpScreen.Text = "FixB"

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

  Private Sub LnkFilePath1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath1.LinkClicked
    With OpenFileDialog1
      .ReadOnlyChecked = True
      .ShowDialog()
      LblFilePath1.Text = .FileName
    End With

  End Sub

  Private Sub Btntask1_Click(sender As Object, e As EventArgs) Handles Btntask1.Click
    Dim result As DialogResult = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

    ' Check the result of the message box
    If result = DialogResult.Yes Then
      ' If Yes is pressed, perform the action
      Me.Refresh()

      Windows.Forms.Cursor.Current = Cursors.WaitCursor
      Task1()
      Windows.Forms.Cursor.Current = Cursors.Default

      ' Your action goes here
    Else
      ' If No is pressed, do nothing or handle accordingly
      MessageBox.Show("Task Cancelled")
    End If
  End Sub
End Class
