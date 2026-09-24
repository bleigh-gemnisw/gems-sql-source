Public Class FrmTX411B
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
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents ChkName As System.Windows.Forms.CheckBox
Friend WithEvents ChkMap As System.Windows.Forms.CheckBox
Friend WithEvents ChkDist As System.Windows.Forms.CheckBox
Friend WithEvents ChkLoc As System.Windows.Forms.CheckBox
Friend WithEvents RbPP As System.Windows.Forms.RadioButton
Friend WithEvents RbRE As System.Windows.Forms.RadioButton
Friend WithEvents ChkVol As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.ChkVol = New System.Windows.Forms.CheckBox()
    Me.ChkLoc = New System.Windows.Forms.CheckBox()
    Me.ChkDist = New System.Windows.Forms.CheckBox()
    Me.ChkMap = New System.Windows.Forms.CheckBox()
    Me.ChkName = New System.Windows.Forms.CheckBox()
    Me.RbRE = New System.Windows.Forms.RadioButton()
    Me.RbPP = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(12, 187)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(440, 41)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "This option will update the Collector's Billing Data with information Imported fr" & _
    "om the Assessor File."
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.ChkVol)
    Me.GroupBox1.Controls.Add(Me.ChkLoc)
    Me.GroupBox1.Controls.Add(Me.ChkDist)
    Me.GroupBox1.Controls.Add(Me.ChkMap)
    Me.GroupBox1.Controls.Add(Me.ChkName)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
    Me.GroupBox1.Location = New System.Drawing.Point(32, 72)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(408, 112)
    Me.GroupBox1.TabIndex = 2
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Information to Import"
    '
    'ChkVol
    '
    Me.ChkVol.Checked = True
    Me.ChkVol.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkVol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkVol.ForeColor = System.Drawing.SystemColors.WindowText
    Me.ChkVol.Location = New System.Drawing.Point(240, 64)
    Me.ChkVol.Name = "ChkVol"
    Me.ChkVol.Size = New System.Drawing.Size(136, 24)
    Me.ChkVol.TabIndex = 4
    Me.ChkVol.Text = "Volume and Page"
    '
    'ChkLoc
    '
    Me.ChkLoc.Checked = True
    Me.ChkLoc.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkLoc.ForeColor = System.Drawing.SystemColors.WindowText
    Me.ChkLoc.Location = New System.Drawing.Point(240, 32)
    Me.ChkLoc.Name = "ChkLoc"
    Me.ChkLoc.Size = New System.Drawing.Size(72, 24)
    Me.ChkLoc.TabIndex = 3
    Me.ChkLoc.Text = "Location"
    '
    'ChkDist
    '
    Me.ChkDist.Checked = True
    Me.ChkDist.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkDist.ForeColor = System.Drawing.SystemColors.WindowText
    Me.ChkDist.Location = New System.Drawing.Point(48, 64)
    Me.ChkDist.Name = "ChkDist"
    Me.ChkDist.Size = New System.Drawing.Size(64, 24)
    Me.ChkDist.TabIndex = 2
    Me.ChkDist.Text = "District"
    '
    'ChkMap
    '
    Me.ChkMap.Checked = True
    Me.ChkMap.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkMap.ForeColor = System.Drawing.SystemColors.WindowText
    Me.ChkMap.Location = New System.Drawing.Point(144, 64)
    Me.ChkMap.Name = "ChkMap"
    Me.ChkMap.Size = New System.Drawing.Size(56, 24)
    Me.ChkMap.TabIndex = 1
    Me.ChkMap.Text = "Map"
    '
    'ChkName
    '
    Me.ChkName.Checked = True
    Me.ChkName.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkName.ForeColor = System.Drawing.SystemColors.WindowText
    Me.ChkName.Location = New System.Drawing.Point(48, 32)
    Me.ChkName.Name = "ChkName"
    Me.ChkName.Size = New System.Drawing.Size(136, 24)
    Me.ChkName.TabIndex = 0
    Me.ChkName.Text = "Name and  Address"
    '
    'RbRE
    '
    Me.RbRE.AutoSize = True
    Me.RbRE.Checked = True
    Me.RbRE.Location = New System.Drawing.Point(113, 23)
    Me.RbRE.Name = "RbRE"
    Me.RbRE.Size = New System.Drawing.Size(80, 17)
    Me.RbRE.TabIndex = 3
    Me.RbRE.TabStop = True
    Me.RbRE.Text = "Real Estate"
    Me.RbRE.UseVisualStyleBackColor = True
    '
    'RbPP
    '
    Me.RbPP.AutoSize = True
    Me.RbPP.Location = New System.Drawing.Point(240, 23)
    Me.RbPP.Name = "RbPP"
    Me.RbPP.Size = New System.Drawing.Size(108, 17)
    Me.RbPP.TabIndex = 4
    Me.RbPP.Text = "Personal Property"
    Me.RbPP.UseVisualStyleBackColor = True
    '
    'FrmTX411B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(474, 237)
    Me.ControlBox = False
    Me.Controls.Add(Me.RbPP)
    Me.Controls.Add(Me.RbRE)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.MaximizeBox = False
    Me.Name = "FrmTX411B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTX411B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

 End Sub


Private Sub FrmTX411B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX411.SbpScreen.Text = "TX411B"
  MyFrmTX411.TBarProcess.Enabled = True
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If RbRE.Checked Then
      If ChkName.Checked = False And ChkLoc.Checked = False _
        And ChkDist.Checked = False And ChkMap.Checked = False And ChkVol.Checked = False Then
        ErrorField(I) = "name"
        ErrorMsg(I) = "No fields selected for update"
        I = I + 1
      End If
    Else
      If ChkName.Checked = False And ChkLoc.Checked = False _
        And ChkDist.Checked = False Then
        ErrorField(I) = "name"
        ErrorMsg(I) = "No fields selected for update"
        I = I + 1
      End If
    End If

  End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(ChkName, "")


    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "name"
        ErrProv.SetError(ChkName, ErrorMsg(I))
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

    ImpData()
    Windows.Forms.Cursor.Current = Cursors.Default
End Sub
  Private Sub RbRE_Click(sender As Object, e As EventArgs) Handles RbRE.Click
    ChkDist.Visible = True
    ChkLoc.Visible = True
    ChkMap.Visible = True
    ChkVol.Visible = True
    ChkName.Text = "Name and Address"
  End Sub
  Private Sub RbPP_Click(sender As Object, e As EventArgs) Handles RbPP.Click
    ChkDist.Visible = False
    ChkLoc.Visible = False
    ChkMap.Visible = False
    ChkVol.Visible = False
    ChkName.Text = "Address"
  End Sub

Private Sub RbRE_CheckedChanged(sender As Object, e As EventArgs) Handles RbRE.CheckedChanged

End Sub
End Class






