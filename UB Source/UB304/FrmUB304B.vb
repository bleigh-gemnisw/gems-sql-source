Public Class FrmUB304B
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
Friend WithEvents ChkTransfer As System.Windows.Forms.CheckBox
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents ChkName As System.Windows.Forms.CheckBox
Friend WithEvents ChkMap As System.Windows.Forms.CheckBox
Friend WithEvents ChkDist As System.Windows.Forms.CheckBox
Friend WithEvents ChkLoc As System.Windows.Forms.CheckBox
Friend WithEvents ChkVol As System.Windows.Forms.CheckBox
Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbSortList As System.Windows.Forms.RadioButton
Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
Friend WithEvents ChkShowLines As System.Windows.Forms.CheckBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents ChkPDist As System.Windows.Forms.CheckBox
Friend WithEvents ChkAdd As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label1 = New System.Windows.Forms.Label()
    Me.ChkTransfer = New System.Windows.Forms.CheckBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.ChkPDist = New System.Windows.Forms.CheckBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.ChkVol = New System.Windows.Forms.CheckBox()
    Me.ChkLoc = New System.Windows.Forms.CheckBox()
    Me.ChkDist = New System.Windows.Forms.CheckBox()
    Me.ChkMap = New System.Windows.Forms.CheckBox()
    Me.ChkName = New System.Windows.Forms.CheckBox()
    Me.ChkAdd = New System.Windows.Forms.CheckBox()
    Me.ChkPost = New System.Windows.Forms.CheckBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbSortList = New System.Windows.Forms.RadioButton()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
    Me.ChkShowLines = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
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
    Me.Label1.Location = New System.Drawing.Point(81, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(488, 48)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "This option will update the Utility Billing Customer Data with information Import" &
    "ed from Assessor Real Estate. Only accounts checked ""Sewer"" will be processed."
    '
    'ChkTransfer
    '
    Me.ChkTransfer.AutoSize = True
    Me.ChkTransfer.Location = New System.Drawing.Point(570, 291)
    Me.ChkTransfer.Name = "ChkTransfer"
    Me.ChkTransfer.Size = New System.Drawing.Size(158, 17)
    Me.ChkTransfer.TabIndex = 1
    Me.ChkTransfer.TabStop = False
    Me.ChkTransfer.Text = "Include Transfer Information"
    Me.ChkTransfer.Visible = False
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.ChkPDist)
    Me.GroupBox1.Controls.Add(Me.Label2)
    Me.GroupBox1.Controls.Add(Me.ChkVol)
    Me.GroupBox1.Controls.Add(Me.ChkLoc)
    Me.GroupBox1.Controls.Add(Me.ChkDist)
    Me.GroupBox1.Controls.Add(Me.ChkMap)
    Me.GroupBox1.Controls.Add(Me.ChkName)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
    Me.GroupBox1.Location = New System.Drawing.Point(32, 112)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(408, 126)
    Me.GroupBox1.TabIndex = 2
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Information to Import"
    '
    'ChkPDist
    '
    Me.ChkPDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkPDist.ForeColor = System.Drawing.SystemColors.WindowText
    Me.ChkPDist.Location = New System.Drawing.Point(48, 94)
    Me.ChkPDist.Name = "ChkPDist"
    Me.ChkPDist.Size = New System.Drawing.Size(112, 24)
    Me.ChkPDist.TabIndex = 6
    Me.ChkPDist.Text = "Prt Dist==> Dist"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.ForeColor = System.Drawing.Color.Black
    Me.Label2.Location = New System.Drawing.Point(60, 42)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(124, 15)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "(Wipes out Mailing Address)"
    '
    'ChkVol
    '
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
    Me.ChkLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkLoc.ForeColor = System.Drawing.SystemColors.WindowText
    Me.ChkLoc.Location = New System.Drawing.Point(240, 24)
    Me.ChkLoc.Name = "ChkLoc"
    Me.ChkLoc.Size = New System.Drawing.Size(72, 24)
    Me.ChkLoc.TabIndex = 3
    Me.ChkLoc.Text = "Location"
    '
    'ChkDist
    '
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
    Me.ChkName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkName.ForeColor = System.Drawing.SystemColors.WindowText
    Me.ChkName.Location = New System.Drawing.Point(48, 24)
    Me.ChkName.Name = "ChkName"
    Me.ChkName.Size = New System.Drawing.Size(136, 24)
    Me.ChkName.TabIndex = 0
    Me.ChkName.Text = "Name and  Address"
    '
    'ChkAdd
    '
    Me.ChkAdd.AutoSize = True
    Me.ChkAdd.Location = New System.Drawing.Point(80, 73)
    Me.ChkAdd.Name = "ChkAdd"
    Me.ChkAdd.Size = New System.Drawing.Size(131, 17)
    Me.ChkAdd.TabIndex = 3
    Me.ChkAdd.TabStop = False
    Me.ChkAdd.Text = "Add Missing Accounts"
    '
    'ChkPost
    '
    Me.ChkPost.Location = New System.Drawing.Point(32, 274)
    Me.ChkPost.Name = "ChkPost"
    Me.ChkPost.Size = New System.Drawing.Size(148, 24)
    Me.ChkPost.TabIndex = 4
    Me.ChkPost.TabStop = False
    Me.ChkPost.Text = "Post to File?"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbSortList)
    Me.GroupBox2.Controls.Add(Me.RbSortName)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox2.Location = New System.Drawing.Point(479, 112)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(135, 88)
    Me.GroupBox2.TabIndex = 5
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Report Order"
    '
    'RbSortList
    '
    Me.RbSortList.Checked = True
    Me.RbSortList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortList.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbSortList.Location = New System.Drawing.Point(20, 28)
    Me.RbSortList.Name = "RbSortList"
    Me.RbSortList.Size = New System.Drawing.Size(70, 20)
    Me.RbSortList.TabIndex = 0
    Me.RbSortList.TabStop = True
    Me.RbSortList.Text = "List #"
    '
    'RbSortName
    '
    Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortName.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbSortName.Location = New System.Drawing.Point(20, 54)
    Me.RbSortName.Name = "RbSortName"
    Me.RbSortName.Size = New System.Drawing.Size(106, 20)
    Me.RbSortName.TabIndex = 1
    Me.RbSortName.Text = "Name (Current)"
    '
    'ChkShowLines
    '
    Me.ChkShowLines.Location = New System.Drawing.Point(32, 244)
    Me.ChkShowLines.Name = "ChkShowLines"
    Me.ChkShowLines.Size = New System.Drawing.Size(148, 24)
    Me.ChkShowLines.TabIndex = 6
    Me.ChkShowLines.TabStop = False
    Me.ChkShowLines.Text = "Show All Address Lines?"
    '
    'FrmUB304B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(635, 310)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkShowLines)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.ChkPost)
    Me.Controls.Add(Me.ChkAdd)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.ChkTransfer)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.MaximizeBox = False
    Me.Name = "FrmUB304B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = " "
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

Private Sub FrmUB304B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  With MyAppSettings
    If .Add Then
      ChkAdd.Checked = True
    End If
    If .Name Then
      ChkName.Checked = True
    End If
    If .Dist Then
      ChkDist.Checked = True
    End If
    If .PDist Then
      ChkPDist.Checked = True
    End If
    If .Loc Then
      ChkLoc.Checked = True
    End If
    If .Map Then
      ChkMap.Checked = True
    End If
    If .Vol Then
      ChkVol.Checked = True
    End If

    If myTOWN._TOWNBR = 162 Then 'Winchester
      ChkVol.Checked = False
      ChkVol.Enabled = False
    End If
  End With
 End Sub


Private Sub FrmUB304B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB304.SbpScreen.Text = "UB304B"
  MyFrmUB304.TBarProcess.Enabled = True
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If ChkName.Checked = False And ChkLoc.Checked = False _
      And ChkDist.Checked = False And ChkMap.Checked = False _
      And ChkVol.Checked = False And ChkPDist.Checked = False Then
        ErrorField(I) = "cbname"
        ErrorMsg(I) = "No fields selected for update"
        I = I + 1
      End If


  End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(ChkName, "")


    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "cbname"
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
Public Sub SaveSettings()
  With MyAppSettings
    .Add = ChkAdd.Checked
    .Name = ChkName.Checked
    .Dist = ChkDist.Checked
    .PDist = ChkPDist.Checked
    .Loc = ChkLoc.Checked
    .Map = ChkMap.Checked
    .Vol = ChkVol.Checked
  End With
  SaveAppSettings()
End Sub
Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAdd.CheckedChanged

End Sub

Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

End Sub
End Class






