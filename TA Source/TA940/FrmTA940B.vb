Public Class FrmTA940B
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
Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
Friend WithEvents LblMsg1 As System.Windows.Forms.Label
Friend WithEvents LblMsg2 As System.Windows.Forms.Label
Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
Friend WithEvents RbTruck As System.Windows.Forms.RadioButton
Friend WithEvents RbTrailer As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbSupp As System.Windows.Forms.RadioButton
Friend WithEvents RbMV As System.Windows.Forms.RadioButton
Friend WithEvents LblFilePath As System.Windows.Forms.Label
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.LblFilePath = New System.Windows.Forms.Label
Me.LnkFilePath = New System.Windows.Forms.LinkLabel
Me.LblMsg1 = New System.Windows.Forms.Label
Me.LblMsg2 = New System.Windows.Forms.Label
Me.GroupBox2 = New System.Windows.Forms.GroupBox
Me.RbSupp = New System.Windows.Forms.RadioButton
Me.RbMV = New System.Windows.Forms.RadioButton
Me.GroupBox3 = New System.Windows.Forms.GroupBox
Me.RbTruck = New System.Windows.Forms.RadioButton
Me.RbTrailer = New System.Windows.Forms.RadioButton
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox1.SuspendLayout()
Me.GroupBox2.SuspendLayout()
Me.GroupBox3.SuspendLayout()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.LblFilePath)
Me.GroupBox1.Controls.Add(Me.LnkFilePath)
Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox1.Location = New System.Drawing.Point(23, 131)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(408, 72)
Me.GroupBox1.TabIndex = 6
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "File Details"
'
'LblFilePath
'
Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblFilePath.Location = New System.Drawing.Point(70, 24)
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
Me.LnkFilePath.TabIndex = 8
Me.LnkFilePath.TabStop = True
Me.LnkFilePath.Text = "File Path"
'
'LblMsg1
'
Me.LblMsg1.AutoSize = True
Me.LblMsg1.Location = New System.Drawing.Point(20, 22)
Me.LblMsg1.Name = "LblMsg1"
Me.LblMsg1.Size = New System.Drawing.Size(132, 13)
Me.LblMsg1.TabIndex = 7
Me.LblMsg1.Text = "Use .CSV for file extension"
'
'LblMsg2
'
Me.LblMsg2.AutoSize = True
Me.LblMsg2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblMsg2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
Me.LblMsg2.Location = New System.Drawing.Point(20, 219)
Me.LblMsg2.Name = "LblMsg2"
Me.LblMsg2.Size = New System.Drawing.Size(285, 13)
Me.LblMsg2.TabIndex = 11
Me.LblMsg2.Text = "In Express Software, Import as CSV at 70% value"
Me.LblMsg2.Visible = False
'
'GroupBox2
'
Me.GroupBox2.Controls.Add(Me.RbSupp)
Me.GroupBox2.Controls.Add(Me.RbMV)
Me.GroupBox2.Location = New System.Drawing.Point(23, 48)
Me.GroupBox2.Name = "GroupBox2"
Me.GroupBox2.Size = New System.Drawing.Size(226, 46)
Me.GroupBox2.TabIndex = 13
Me.GroupBox2.TabStop = False
'
'RbSupp
'
Me.RbSupp.AutoSize = True
Me.RbSupp.Location = New System.Drawing.Point(135, 19)
Me.RbSupp.Name = "RbSupp"
Me.RbSupp.Size = New System.Drawing.Size(74, 17)
Me.RbSupp.TabIndex = 12
Me.RbSupp.Text = "Suppl. MV"
Me.RbSupp.UseVisualStyleBackColor = True
'
'RbMV
'
Me.RbMV.AutoSize = True
Me.RbMV.Checked = True
Me.RbMV.Location = New System.Drawing.Point(6, 19)
Me.RbMV.Name = "RbMV"
Me.RbMV.Size = New System.Drawing.Size(90, 17)
Me.RbMV.TabIndex = 11
Me.RbMV.TabStop = True
Me.RbMV.Text = "Motor Vehicle"
Me.RbMV.UseVisualStyleBackColor = True
'
'GroupBox3
'
Me.GroupBox3.Controls.Add(Me.RbTruck)
Me.GroupBox3.Controls.Add(Me.RbTrailer)
Me.GroupBox3.Location = New System.Drawing.Point(282, 48)
Me.GroupBox3.Name = "GroupBox3"
Me.GroupBox3.Size = New System.Drawing.Size(149, 46)
Me.GroupBox3.TabIndex = 14
Me.GroupBox3.TabStop = False
'
'RbTruck
'
Me.RbTruck.AutoSize = True
Me.RbTruck.Location = New System.Drawing.Point(84, 19)
Me.RbTruck.Name = "RbTruck"
Me.RbTruck.Size = New System.Drawing.Size(53, 17)
Me.RbTruck.TabIndex = 12
Me.RbTruck.Text = "Truck"
Me.RbTruck.UseVisualStyleBackColor = True
'
'RbTrailer
'
Me.RbTrailer.AutoSize = True
Me.RbTrailer.Checked = True
Me.RbTrailer.Location = New System.Drawing.Point(6, 19)
Me.RbTrailer.Name = "RbTrailer"
Me.RbTrailer.Size = New System.Drawing.Size(54, 17)
Me.RbTrailer.TabIndex = 11
Me.RbTrailer.TabStop = True
Me.RbTrailer.Text = "Trailer"
Me.RbTrailer.UseVisualStyleBackColor = True
'
'FrmTA940B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(462, 272)
Me.ControlBox = False
Me.Controls.Add(Me.GroupBox3)
Me.Controls.Add(Me.GroupBox2)
Me.Controls.Add(Me.LblMsg2)
Me.Controls.Add(Me.LblMsg1)
Me.Controls.Add(Me.GroupBox1)
Me.KeyPreview = True
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA940B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox1.ResumeLayout(False)
Me.GroupBox2.ResumeLayout(False)
Me.GroupBox2.PerformLayout()
Me.GroupBox3.ResumeLayout(False)
Me.GroupBox3.PerformLayout()
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
		PrtReport()
		Windows.Forms.Cursor.Current = Cursors.Default
		LblMsg2.Visible = True

	End Sub
Private Sub FrmTA940B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		MyFrmTA940.SbpPgmID.Text = "TA940B"
		MyFrmTA940.SbpEnvironment.Text = myDBConnect.PgmDB
    LblFilePath.Text = MyUtils.GetDataPath() & "vin.csv"
End Sub
Private Sub FrmTA940B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmTA940.SbpScreen.Text = "TA940B"
End Sub
Private Sub FrmTA940B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
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
Private Sub FrmTA940B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
	If Not e.Alt Then Exit Sub

	 If e.KeyCode = Keys.F12 Then
     MyUtils.PrtScreen(Form.ActiveForm)
	 End If
End Sub
Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
	With SaveFileDialog1
		.Filter = "Comma Seperated Values (csv)|*.csv"
		.ShowDialog()
		If .FileName <> String.Empty Then
			LblFilePath.Text = .FileName
		End If
	End With
End Sub
End Class






