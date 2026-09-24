Public Class FrmTA206B
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
  Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbLoc As System.Windows.Forms.RadioButton
Friend WithEvents RbName As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbPP As System.Windows.Forms.RadioButton
Friend WithEvents RbRE As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
Friend WithEvents RbSelDen As System.Windows.Forms.RadioButton
Friend WithEvents RbSelApp As System.Windows.Forms.RadioButton
Friend WithEvents RbSelAll As System.Windows.Forms.RadioButton
Friend WithEvents RbMV As System.Windows.Forms.RadioButton
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbLoc = New System.Windows.Forms.RadioButton()
    Me.RbName = New System.Windows.Forms.RadioButton()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbPP = New System.Windows.Forms.RadioButton()
    Me.RbRE = New System.Windows.Forms.RadioButton()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.RbSelDen = New System.Windows.Forms.RadioButton()
    Me.RbSelApp = New System.Windows.Forms.RadioButton()
    Me.RbSelAll = New System.Windows.Forms.RadioButton()
    Me.RbMV = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.SuspendLayout()
    '
    'TxtGLYear
    '
    Me.TxtGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGLYear.Location = New System.Drawing.Point(147, 111)
    Me.TxtGLYear.MaxLength = 4
    Me.TxtGLYear.Name = "TxtGLYear"
    Me.TxtGLYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtGLYear.TabIndex = 2
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(57, 115)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(84, 16)
    Me.Label4.TabIndex = 11
    Me.Label4.Text = "Grand List Year"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbLoc)
    Me.GroupBox1.Controls.Add(Me.RbName)
    Me.GroupBox1.Location = New System.Drawing.Point(60, 137)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(130, 61)
    Me.GroupBox1.TabIndex = 14
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Sort By"
    '
    'RbLoc
    '
    Me.RbLoc.Location = New System.Drawing.Point(11, 38)
    Me.RbLoc.Name = "RbLoc"
    Me.RbLoc.Size = New System.Drawing.Size(94, 17)
    Me.RbLoc.TabIndex = 15
    Me.RbLoc.Text = "Location"
    Me.RbLoc.UseVisualStyleBackColor = True
    '
    'RbName
    '
    Me.RbName.AutoSize = True
    Me.RbName.Checked = True
    Me.RbName.Location = New System.Drawing.Point(11, 15)
    Me.RbName.Name = "RbName"
    Me.RbName.Size = New System.Drawing.Size(94, 17)
    Me.RbName.TabIndex = 14
    Me.RbName.TabStop = True
    Me.RbName.Text = "Owner's Name"
    Me.RbName.UseVisualStyleBackColor = True
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbMV)
    Me.GroupBox2.Controls.Add(Me.RbPP)
    Me.GroupBox2.Controls.Add(Me.RbRE)
    Me.GroupBox2.Location = New System.Drawing.Point(60, 13)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(130, 79)
    Me.GroupBox2.TabIndex = 19
    Me.GroupBox2.TabStop = False
    '
    'RbPP
    '
    Me.RbPP.AutoSize = True
    Me.RbPP.Location = New System.Drawing.Point(11, 33)
    Me.RbPP.Name = "RbPP"
    Me.RbPP.Size = New System.Drawing.Size(108, 17)
    Me.RbPP.TabIndex = 15
    Me.RbPP.Text = "Personal Property"
    Me.RbPP.UseVisualStyleBackColor = True
    '
    'RbRE
    '
    Me.RbRE.Checked = True
    Me.RbRE.Location = New System.Drawing.Point(11, 10)
    Me.RbRE.Name = "RbRE"
    Me.RbRE.Size = New System.Drawing.Size(94, 17)
    Me.RbRE.TabIndex = 14
    Me.RbRE.TabStop = True
    Me.RbRE.Text = "Real Estate"
    Me.RbRE.UseVisualStyleBackColor = True
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.RbSelDen)
    Me.GroupBox3.Controls.Add(Me.RbSelApp)
    Me.GroupBox3.Controls.Add(Me.RbSelAll)
    Me.GroupBox3.Location = New System.Drawing.Point(60, 213)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(130, 90)
    Me.GroupBox3.TabIndex = 20
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Selection"
    '
    'RbSelDen
    '
    Me.RbSelDen.Location = New System.Drawing.Point(11, 61)
    Me.RbSelDen.Name = "RbSelDen"
    Me.RbSelDen.Size = New System.Drawing.Size(94, 17)
    Me.RbSelDen.TabIndex = 16
    Me.RbSelDen.Text = "Denied Only"
    Me.RbSelDen.UseVisualStyleBackColor = True
    '
    'RbSelApp
    '
    Me.RbSelApp.Location = New System.Drawing.Point(11, 38)
    Me.RbSelApp.Name = "RbSelApp"
    Me.RbSelApp.Size = New System.Drawing.Size(100, 17)
    Me.RbSelApp.TabIndex = 15
    Me.RbSelApp.Text = "Approved Only"
    Me.RbSelApp.UseVisualStyleBackColor = True
    '
    'RbSelAll
    '
    Me.RbSelAll.AutoSize = True
    Me.RbSelAll.Checked = True
    Me.RbSelAll.Location = New System.Drawing.Point(11, 15)
    Me.RbSelAll.Name = "RbSelAll"
    Me.RbSelAll.Size = New System.Drawing.Size(36, 17)
    Me.RbSelAll.TabIndex = 14
    Me.RbSelAll.TabStop = True
    Me.RbSelAll.Text = "All"
    Me.RbSelAll.UseVisualStyleBackColor = True
    '
    'RbMV
    '
    Me.RbMV.AutoSize = True
    Me.RbMV.Location = New System.Drawing.Point(11, 56)
    Me.RbMV.Name = "RbMV"
    Me.RbMV.Size = New System.Drawing.Size(90, 17)
    Me.RbMV.TabIndex = 16
    Me.RbMV.Text = "Motor Vehicle"
    Me.RbMV.UseVisualStyleBackColor = True
    '
    'FrmTA206B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(261, 315)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.TxtGLYear)
    Me.Controls.Add(Me.Label4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA206B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTA206B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA206.SbpScreen.Text = "TA206"
End Sub
Private Sub FrmTA206B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLYear, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "glyear"
        ErrProv.SetError(TxtGLYear, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtGLYear.Text) = 0 Then
      ErrorField(I) = "glyear"
      ErrorMsg(I) = "Year is required"
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
    If RbRE.Checked Then
      PrtReportRE()
    End If
    If RbPP.Checked Then
      PrtReportPP()
    End If
    If RbMV.Checked Then
      PrtReportMV()
    End If
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
  Private Sub RbRE_Click(sender As Object, e As EventArgs) Handles RbRE.Click
    RbLoc.Enabled = True
  End Sub
  Private Sub RbPP_Click(sender As Object, e As EventArgs) Handles RbPP.Click
    RbLoc.Enabled = False
  End Sub
  Private Sub RbMV_Click(sender As Object, e As EventArgs) Handles RbMV.Click
    RbLoc.Enabled = False
  End Sub
End Class






