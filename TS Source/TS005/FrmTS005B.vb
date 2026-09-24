Public Class FrmTS005B
Inherits System.Windows.Forms.Form
Dim ds As DataSet = New DataSet

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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtToGLYear As System.Windows.Forms.TextBox
Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents Label9 As System.Windows.Forms.Label
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbNameDate As System.Windows.Forms.RadioButton
Friend WithEvents RbDateName As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.DtPckFrom = New System.Windows.Forms.DateTimePicker
Me.DtPckTo = New System.Windows.Forms.DateTimePicker
Me.Label2 = New System.Windows.Forms.Label
Me.TxtToGLYear = New System.Windows.Forms.TextBox
Me.TxtFromGLYear = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.Label7 = New System.Windows.Forms.Label
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Label9 = New System.Windows.Forms.Label
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.RbDateName = New System.Windows.Forms.RadioButton
Me.RbNameDate = New System.Windows.Forms.RadioButton
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox1.SuspendLayout()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(29, 26)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(60, 16)
Me.Label1.TabIndex = 0
Me.Label1.Text = "From Date"
'
'DtPckFrom
'
Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckFrom.Location = New System.Drawing.Point(89, 22)
Me.DtPckFrom.Name = "DtPckFrom"
Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
Me.DtPckFrom.TabIndex = 0
'
'DtPckTo
'
Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckTo.Location = New System.Drawing.Point(249, 22)
Me.DtPckTo.Name = "DtPckTo"
Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
Me.DtPckTo.TabIndex = 1
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(197, 26)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(52, 16)
Me.Label2.TabIndex = 5
Me.Label2.Text = "To Date"
'
'TxtToGLYear
'
Me.TxtToGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtToGLYear.Location = New System.Drawing.Point(186, 198)
Me.TxtToGLYear.MaxLength = 4
Me.TxtToGLYear.Name = "TxtToGLYear"
Me.TxtToGLYear.Size = New System.Drawing.Size(36, 20)
Me.TxtToGLYear.TabIndex = 7
'
'TxtFromGLYear
'
Me.TxtFromGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFromGLYear.Location = New System.Drawing.Point(116, 198)
Me.TxtFromGLYear.MaxLength = 4
Me.TxtFromGLYear.Name = "TxtFromGLYear"
Me.TxtFromGLYear.Size = New System.Drawing.Size(36, 20)
Me.TxtFromGLYear.TabIndex = 6
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(164, 202)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(16, 16)
Me.Label4.TabIndex = 32
Me.Label4.Text = "to"
'
'Label7
'
Me.Label7.Location = New System.Drawing.Point(32, 202)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(84, 16)
Me.Label7.TabIndex = 31
Me.Label7.Text = "Sticker Year"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Label9
'
Me.Label9.AutoSize = True
Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label9.Location = New System.Drawing.Point(30, 164)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(170, 20)
Me.Label9.TabIndex = 40
Me.Label9.Text = "Optional Selections:"
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.RbDateName)
Me.GroupBox1.Controls.Add(Me.RbNameDate)
Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox1.Location = New System.Drawing.Point(35, 63)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(148, 70)
Me.GroupBox1.TabIndex = 2
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "Sort by"
'
'RbDateName
'
Me.RbDateName.AutoSize = True
Me.RbDateName.Checked = True
Me.RbDateName.Location = New System.Drawing.Point(16, 19)
Me.RbDateName.Name = "RbDateName"
Me.RbDateName.Size = New System.Drawing.Size(126, 17)
Me.RbDateName.TabIndex = 2
Me.RbDateName.TabStop = True
Me.RbDateName.Text = "Payment Date, Name"
Me.RbDateName.UseVisualStyleBackColor = True
'
'RbNameDate
'
Me.RbNameDate.AutoSize = True
Me.RbNameDate.Location = New System.Drawing.Point(16, 42)
Me.RbNameDate.Name = "RbNameDate"
Me.RbNameDate.Size = New System.Drawing.Size(126, 17)
Me.RbNameDate.TabIndex = 1
Me.RbNameDate.Text = "Name, Payment Date"
Me.RbNameDate.UseVisualStyleBackColor = True
'
'FrmTS005B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(352, 300)
Me.ControlBox = False
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.Label9)
Me.Controls.Add(Me.TxtToGLYear)
Me.Controls.Add(Me.TxtFromGLYear)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.Label7)
Me.Controls.Add(Me.DtPckTo)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.DtPckFrom)
Me.Controls.Add(Me.Label1)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTS005B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox1.ResumeLayout(False)
Me.GroupBox1.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTS005B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTS005.SbpScreen.Text = "TS005"
End Sub
Private Sub FrmTS005B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFromGLYear, "")
    ErrProv.SetError(TxtToGLYear, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "fromglyear"
        ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
      Case "toglyear"
        ErrProv.SetError(TxtToGLYear, ErrorMsg(I))

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

    If MyUtils.CnvSng(TxtFromGLYear.Text) > MyUtils.CnvSng(TxtToGLYear.Text) Then
      ErrorField(I) = "fromglyear"
      ErrorMsg(I) = "Invalid Year Range"
      I = I + 1
      ErrorField(I) = "toglyear"
      ErrorMsg(I) = "Invalid Year Range"
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


Private Sub FrmTS005B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

End Sub
End Class






