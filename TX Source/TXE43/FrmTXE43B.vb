Public Class FrmTXE43B
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
Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbName As System.Windows.Forms.RadioButton
Friend WithEvents RbLocation As System.Windows.Forms.RadioButton
Friend WithEvents ChkAddress As System.Windows.Forms.CheckBox
Friend WithEvents LblCodes As System.Windows.Forms.Label
Friend WithEvents BtnSelCodes As System.Windows.Forms.Button
  Friend WithEvents LnkDistrict As LinkLabel
  Friend WithEvents TxtPhase As TextBox
  Friend WithEvents Label12 As Label
  Friend WithEvents TxtDist As TextBox
  Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtTypes = New System.Windows.Forms.TextBox()
    Me.TxtGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.LnkTypes = New System.Windows.Forms.LinkLabel()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbName = New System.Windows.Forms.RadioButton()
    Me.RbLocation = New System.Windows.Forms.RadioButton()
    Me.ChkAddress = New System.Windows.Forms.CheckBox()
    Me.LblCodes = New System.Windows.Forms.Label()
    Me.BtnSelCodes = New System.Windows.Forms.Button()
    Me.LnkDistrict = New System.Windows.Forms.LinkLabel()
    Me.TxtPhase = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'TxtTypes
    '
    Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTypes.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTypes.Location = New System.Drawing.Point(107, 38)
    Me.TxtTypes.MaxLength = 20
    Me.TxtTypes.Name = "TxtTypes"
    Me.TxtTypes.Size = New System.Drawing.Size(148, 20)
    Me.TxtTypes.TabIndex = 1
    '
    'TxtGLYear
    '
    Me.TxtGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGLYear.Location = New System.Drawing.Point(107, 12)
    Me.TxtGLYear.MaxLength = 4
    Me.TxtGLYear.Name = "TxtGLYear"
    Me.TxtGLYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtGLYear.TabIndex = 0
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(15, 16)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(84, 16)
    Me.Label4.TabIndex = 11
    Me.Label4.Text = "Grand List Year"
    '
    'LnkTypes
    '
    Me.LnkTypes.Location = New System.Drawing.Point(23, 42)
    Me.LnkTypes.Name = "LnkTypes"
    Me.LnkTypes.Size = New System.Drawing.Size(80, 16)
    Me.LnkTypes.TabIndex = 17
    Me.LnkTypes.TabStop = True
    Me.LnkTypes.Text = "Types to print"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbName)
    Me.GroupBox1.Controls.Add(Me.RbLocation)
    Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox1.Location = New System.Drawing.Point(281, 12)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(96, 63)
    Me.GroupBox1.TabIndex = 2
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Sort by"
    '
    'RbName
    '
    Me.RbName.AutoSize = True
    Me.RbName.Checked = True
    Me.RbName.ForeColor = System.Drawing.Color.Black
    Me.RbName.Location = New System.Drawing.Point(17, 17)
    Me.RbName.Name = "RbName"
    Me.RbName.Size = New System.Drawing.Size(53, 17)
    Me.RbName.TabIndex = 0
    Me.RbName.TabStop = True
    Me.RbName.Text = "Name"
    Me.RbName.UseVisualStyleBackColor = True
    '
    'RbLocation
    '
    Me.RbLocation.AutoSize = True
    Me.RbLocation.ForeColor = System.Drawing.Color.Black
    Me.RbLocation.Location = New System.Drawing.Point(17, 40)
    Me.RbLocation.Name = "RbLocation"
    Me.RbLocation.Size = New System.Drawing.Size(66, 17)
    Me.RbLocation.TabIndex = 1
    Me.RbLocation.Text = "Location"
    Me.RbLocation.UseVisualStyleBackColor = True
    '
    'ChkAddress
    '
    Me.ChkAddress.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkAddress.Location = New System.Drawing.Point(18, 102)
    Me.ChkAddress.Name = "ChkAddress"
    Me.ChkAddress.Size = New System.Drawing.Size(117, 17)
    Me.ChkAddress.TabIndex = 18
    Me.ChkAddress.Text = "Show Address?"
    Me.ChkAddress.UseVisualStyleBackColor = True
    '
    'LblCodes
    '
    Me.LblCodes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCodes.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblCodes.Location = New System.Drawing.Point(9, 186)
    Me.LblCodes.Name = "LblCodes"
    Me.LblCodes.Size = New System.Drawing.Size(371, 43)
    Me.LblCodes.TabIndex = 210
    Me.LblCodes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'BtnSelCodes
    '
    Me.BtnSelCodes.Location = New System.Drawing.Point(142, 139)
    Me.BtnSelCodes.Name = "BtnSelCodes"
    Me.BtnSelCodes.Size = New System.Drawing.Size(87, 35)
    Me.BtnSelCodes.TabIndex = 209
    Me.BtnSelCodes.Text = "Select Codes"
    Me.BtnSelCodes.UseVisualStyleBackColor = True
    '
    'LnkDistrict
    '
    Me.LnkDistrict.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkDistrict.Location = New System.Drawing.Point(59, 68)
    Me.LnkDistrict.Name = "LnkDistrict"
    Me.LnkDistrict.Size = New System.Drawing.Size(40, 16)
    Me.LnkDistrict.TabIndex = 302
    Me.LnkDistrict.TabStop = True
    Me.LnkDistrict.Text = "District"
    '
    'TxtPhase
    '
    Me.TxtPhase.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPhase.Location = New System.Drawing.Point(189, 63)
    Me.TxtPhase.MaxLength = 1
    Me.TxtPhase.Name = "TxtPhase"
    Me.TxtPhase.Size = New System.Drawing.Size(16, 22)
    Me.TxtPhase.TabIndex = 300
    '
    'Label12
    '
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(139, 68)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(44, 14)
    Me.Label12.TabIndex = 301
    Me.Label12.Text = "Phase"
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(105, 65)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(28, 20)
    Me.TxtDist.TabIndex = 299
    '
    'FrmTXE43B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(389, 254)
    Me.ControlBox = False
    Me.Controls.Add(Me.LnkDistrict)
    Me.Controls.Add(Me.TxtPhase)
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.LblCodes)
    Me.Controls.Add(Me.BtnSelCodes)
    Me.Controls.Add(Me.ChkAddress)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.TxtGLYear)
    Me.Controls.Add(Me.TxtTypes)
    Me.Controls.Add(Me.LnkTypes)
    Me.Controls.Add(Me.Label4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXE43B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTXE43B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXE43.SbpScreen.Text = "TXE43B"
  End Sub

  Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
    MyTypes = TxtTypes.Text
    MyFrmSelTypes = New FrmSelTypes
    MyFrmSelTypes.MdiParent = Me.ParentForm
    MyFrmSelTypes.Show()
    Me.Hide()
  End Sub
  Private Sub FrmTXE43B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLYear, "")
    ErrProv.SetError(TxtTypes, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "glyear"
          ErrProv.SetError(TxtGLYear, ErrorMsg(I))
        Case "type"
          ErrProv.SetError(TxtTypes, ErrorMsg(I))
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
    PrtReport()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub

  Private Sub FrmTXE43B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTypes = ""
    MySelCodes = ""
  End Sub
  Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Private Sub BtnSelCodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelCodes.Click
    MyFrmSelCodes = New FrmSelCodes
    MyFrmSelCodes.WrkType = ""
    If MyFrmTXE43B.TxtTypes.Text = "R" Then
      MyFrmSelCodes.WrkType = "R"
    End If
    If MyFrmTXE43B.TxtTypes.Text = "P" Then
      MyFrmSelCodes.WrkType = "P"
    End If
    If MyFrmTXE43B.TxtTypes.Text = "M" Or MyFrmTXE43B.TxtTypes.Text = "S" Then
      MyFrmSelCodes.WrkType = "M"
    End If
    If Not MyFrmSelCodes.WrkType = "" Then
      MyFrmSelCodes.ShowDialog()
    Else
      MsgBox("One tax type must be entered to select codes", MsgBoxStyle.Exclamation, "Cannot select Codes")
    End If
    If MySelCodes = "" Then
      LblCodes.Text = "* ALL Codes *"
    Else
      LblCodes.Text = MySelCodes
    End If
  End Sub
  Private Sub LnkDistrict_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkDistrict.LinkClicked
    MyFrmListDist = New FrmListDist
    MyFrmListDist.MdiParent = Me.ParentForm
    MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
    MyFrmListDist.Show()
    Me.Hide()
  End Sub
End Class






