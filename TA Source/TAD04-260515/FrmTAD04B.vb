Public Class FrmTAD04B
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
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TxtYear As System.Windows.Forms.TextBox
Friend WithEvents LblMsg As System.Windows.Forms.Label
Friend WithEvents GrpFreeze As System.Windows.Forms.GroupBox
Friend WithEvents LblMV As System.Windows.Forms.Label
Friend WithEvents LblPP As System.Windows.Forms.Label
Friend WithEvents LblRE As System.Windows.Forms.Label
Friend WithEvents RbSU As System.Windows.Forms.RadioButton
Friend WithEvents RbRE As System.Windows.Forms.RadioButton
  Friend WithEvents RbPro As RadioButton
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.LblMsg = New System.Windows.Forms.Label()
    Me.GrpFreeze = New System.Windows.Forms.GroupBox()
    Me.LblMV = New System.Windows.Forms.Label()
    Me.LblPP = New System.Windows.Forms.Label()
    Me.LblRE = New System.Windows.Forms.Label()
    Me.RbRE = New System.Windows.Forms.RadioButton()
    Me.RbSU = New System.Windows.Forms.RadioButton()
    Me.RbPro = New System.Windows.Forms.RadioButton()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpFreeze.SuspendLayout()
        Me.SuspendLayout()
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(38, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 17)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Freeze Year"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TxtYear
        '
        Me.TxtYear.Location = New System.Drawing.Point(130, 9)
        Me.TxtYear.MaxLength = 4
        Me.TxtYear.Name = "TxtYear"
        Me.TxtYear.Size = New System.Drawing.Size(36, 20)
        Me.TxtYear.TabIndex = 0
        '
        'LblMsg
        '
        Me.LblMsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblMsg.Location = New System.Drawing.Point(63, 124)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(154, 47)
        Me.LblMsg.TabIndex = 17
        Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GrpFreeze
        '
        Me.GrpFreeze.Controls.Add(Me.LblMV)
        Me.GrpFreeze.Controls.Add(Me.LblPP)
        Me.GrpFreeze.Controls.Add(Me.LblRE)
        Me.GrpFreeze.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpFreeze.Location = New System.Drawing.Point(85, 174)
        Me.GrpFreeze.Name = "GrpFreeze"
        Me.GrpFreeze.Size = New System.Drawing.Size(107, 76)
        Me.GrpFreeze.TabIndex = 18
        Me.GrpFreeze.TabStop = False
        Me.GrpFreeze.Text = "Archive..."
        Me.GrpFreeze.Visible = False
        '
        'LblMV
        '
        Me.LblMV.AutoSize = True
        Me.LblMV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMV.Location = New System.Drawing.Point(8, 52)
        Me.LblMV.Name = "LblMV"
        Me.LblMV.Size = New System.Drawing.Size(72, 13)
        Me.LblMV.TabIndex = 2
        Me.LblMV.Text = "Motor Vehicle"
        Me.LblMV.Visible = False
        '
        'LblPP
        '
        Me.LblPP.AutoSize = True
        Me.LblPP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPP.Location = New System.Drawing.Point(8, 34)
        Me.LblPP.Name = "LblPP"
        Me.LblPP.Size = New System.Drawing.Size(90, 13)
        Me.LblPP.TabIndex = 1
        Me.LblPP.Text = "Personal Property"
        Me.LblPP.Visible = False
        '
        'LblRE
        '
        Me.LblRE.AutoSize = True
        Me.LblRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRE.Location = New System.Drawing.Point(8, 16)
        Me.LblRE.Name = "LblRE"
        Me.LblRE.Size = New System.Drawing.Size(62, 13)
        Me.LblRE.TabIndex = 0
        Me.LblRE.Text = "Real Estate"
        '
        'RbRE
        '
        Me.RbRE.AutoSize = True
        Me.RbRE.Location = New System.Drawing.Point(12, 46)
        Me.RbRE.Name = "RbRE"
        Me.RbRE.Size = New System.Drawing.Size(258, 17)
        Me.RbRE.TabIndex = 19
        Me.RbRE.TabStop = True
        Me.RbRE.Text = "Real Estate, Personal Property and Motor Vehicle"
        Me.RbRE.UseVisualStyleBackColor = True
        '
        'RbSU
        '
        Me.RbSU.AutoSize = True
        Me.RbSU.Location = New System.Drawing.Point(12, 69)
        Me.RbSU.Name = "RbSU"
        Me.RbSU.Size = New System.Drawing.Size(157, 17)
        Me.RbSU.TabIndex = 20
        Me.RbSU.TabStop = True
        Me.RbSU.Text = "Supplemental Motor Vehicle"
        Me.RbSU.UseVisualStyleBackColor = True
        '
        'RbPro
        '
        Me.RbPro.AutoSize = True
        Me.RbPro.Location = New System.Drawing.Point(12, 92)
        Me.RbPro.Name = "RbPro"
        Me.RbPro.Size = New System.Drawing.Size(72, 17)
        Me.RbPro.TabIndex = 21
        Me.RbPro.TabStop = True
        Me.RbPro.Text = "Prorations"
        Me.RbPro.UseVisualStyleBackColor = True
        '
        'FrmTAD04B
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(301, 309)
        Me.ControlBox = False
        Me.Controls.Add(Me.RbPro)
        Me.Controls.Add(Me.RbSU)
        Me.Controls.Add(Me.RbRE)
        Me.Controls.Add(Me.GrpFreeze)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtYear)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "FrmTAD04B"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpFreeze.ResumeLayout(False)
        Me.GrpFreeze.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FrmTAD04B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub


  Private Sub FrmTAD04B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAD04.SbpScreen.Text = "TAD04B"
    MyFrmTAD04.TBarProcess.Enabled = True
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(RbRE, "")
    ErrProv.SetError(RbSU, "")
    ErrProv.SetError(TxtYear, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "re"
          ErrProv.SetError(RbRE, ErrorMsg(I))
          ErrProv.SetError(RbSU, ErrorMsg(I))
        Case "year"
          ErrProv.SetError(TxtYear, ErrorMsg(I))
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

    If Not RbRE.Checked And Not RbSU.Checked And Not RbPro.Checked Then
      ErrorField(I) = "re"
      ErrorMsg(I) = "Select File type(s) to process"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtYear.Text) = 0 Then
      ErrorField(I) = "year"
      ErrorMsg(I) = "Invalid GL Year"
      I = I + 1
    End If

  End Sub
  Public Sub RunProcess()
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
    MyFrmTAD04.TBarProcess.Enabled = False
    ProcData()
    MyFrmTAD04.TBarProcess.Enabled = True
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Private Sub RbSU_CheckedChanged(sender As Object, e As EventArgs) Handles RbSU.CheckedChanged

  End Sub
End Class






