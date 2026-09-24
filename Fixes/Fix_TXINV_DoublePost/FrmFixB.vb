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
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtDBName As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TxtBatch As System.Windows.Forms.TextBox
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents DtPckPost As System.Windows.Forms.DateTimePicker
Friend WithEvents ChkUpdate As System.Windows.Forms.CheckBox
Friend WithEvents Label1 As System.Windows.Forms.Label
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtDBName = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtBatch = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.DtPckPost = New System.Windows.Forms.DateTimePicker()
    Me.ChkUpdate = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(12, 152)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(233, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Delete double posted batch records"
    '
    'TxtDBName
    '
    Me.TxtDBName.Location = New System.Drawing.Point(100, 23)
    Me.TxtDBName.Name = "TxtDBName"
    Me.TxtDBName.Size = New System.Drawing.Size(126, 20)
    Me.TxtDBName.TabIndex = 0
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 26)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(82, 13)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "Database name"
    '
    'TxtBatch
    '
    Me.TxtBatch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBatch.Location = New System.Drawing.Point(122, 49)
    Me.TxtBatch.MaxLength = 5
    Me.TxtBatch.Name = "TxtBatch"
    Me.TxtBatch.Size = New System.Drawing.Size(56, 20)
    Me.TxtBatch.TabIndex = 1
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(12, 60)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(35, 13)
    Me.Label3.TabIndex = 67
    Me.Label3.Text = "Batch"
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(12, 85)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(84, 16)
    Me.Label5.TabIndex = 69
    Me.Label5.Text = "Posted Date"
    '
    'DtPckPost
    '
    Me.DtPckPost.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckPost.Location = New System.Drawing.Point(122, 81)
    Me.DtPckPost.Name = "DtPckPost"
    Me.DtPckPost.Size = New System.Drawing.Size(88, 20)
    Me.DtPckPost.TabIndex = 3
    Me.DtPckPost.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
    '
    'ChkUpdate
    '
    Me.ChkUpdate.AutoSize = True
    Me.ChkUpdate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkUpdate.Location = New System.Drawing.Point(22, 115)
    Me.ChkUpdate.Name = "ChkUpdate"
    Me.ChkUpdate.Size = New System.Drawing.Size(67, 17)
    Me.ChkUpdate.TabIndex = 70
    Me.ChkUpdate.Text = "Update?"
    Me.ChkUpdate.UseVisualStyleBackColor = True
    '
    'FrmFixB
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(432, 192)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkUpdate)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.DtPckPost)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtBatch)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtDBName)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.MaximizeBox = False
    Me.Name = "FrmFixB"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmFixB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	DtPckPost.Value = Date.Today
End Sub


Private Sub FrmFixB_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmFix.SbpScreen.Text = "FixB"
	MyFrmFix.TBarProcess.Enabled = True
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

		Impdata()
		Windows.Forms.Cursor.Current = Cursors.Default
End Sub


Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

End Sub

Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

End Sub
End Class
