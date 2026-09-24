Public Class FrmTXE25B
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
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents TxtToGLYear As System.Windows.Forms.TextBox
Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents ChkPP As System.Windows.Forms.CheckBox
Friend WithEvents ChkRE As System.Windows.Forms.CheckBox
Friend WithEvents ChkMV As System.Windows.Forms.CheckBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.DtPckFrom = New System.Windows.Forms.DateTimePicker
Me.DtPckTo = New System.Windows.Forms.DateTimePicker
Me.Label2 = New System.Windows.Forms.Label
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.Label6 = New System.Windows.Forms.Label
Me.TxtToGLYear = New System.Windows.Forms.TextBox
Me.TxtFromGLYear = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.Label7 = New System.Windows.Forms.Label
Me.ChkRE = New System.Windows.Forms.CheckBox
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.ChkMV = New System.Windows.Forms.CheckBox
Me.ChkPP = New System.Windows.Forms.CheckBox
Me.Label3 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox1.SuspendLayout()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(29, 40)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(60, 16)
Me.Label1.TabIndex = 0
Me.Label1.Text = "From Date"
'
'DtPckFrom
'
Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckFrom.Location = New System.Drawing.Point(89, 36)
Me.DtPckFrom.Name = "DtPckFrom"
Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
Me.DtPckFrom.TabIndex = 0
'
'DtPckTo
'
Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckTo.Location = New System.Drawing.Point(249, 36)
Me.DtPckTo.Name = "DtPckTo"
Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
Me.DtPckTo.TabIndex = 1
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(197, 40)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(52, 16)
Me.Label2.TabIndex = 5
Me.Label2.Text = "To Date"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(227, 178)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(56, 16)
Me.Label6.TabIndex = 40
Me.Label6.Text = "(Optional)"
'
'TxtToGLYear
'
Me.TxtToGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtToGLYear.Location = New System.Drawing.Point(185, 174)
Me.TxtToGLYear.MaxLength = 4
Me.TxtToGLYear.Name = "TxtToGLYear"
Me.TxtToGLYear.Size = New System.Drawing.Size(36, 20)
Me.TxtToGLYear.TabIndex = 3
'
'TxtFromGLYear
'
Me.TxtFromGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFromGLYear.Location = New System.Drawing.Point(113, 174)
Me.TxtFromGLYear.MaxLength = 4
Me.TxtFromGLYear.Name = "TxtFromGLYear"
Me.TxtFromGLYear.Size = New System.Drawing.Size(36, 20)
Me.TxtFromGLYear.TabIndex = 2
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(161, 178)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(16, 16)
Me.Label4.TabIndex = 39
Me.Label4.Text = "to"
'
'Label7
'
Me.Label7.Location = New System.Drawing.Point(29, 178)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(84, 16)
Me.Label7.TabIndex = 38
Me.Label7.Text = "Grand List Year"
'
'ChkRE
'
Me.ChkRE.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkRE.Checked = True
Me.ChkRE.CheckState = System.Windows.Forms.CheckState.Checked
Me.ChkRE.Location = New System.Drawing.Point(13, 20)
Me.ChkRE.Name = "ChkRE"
Me.ChkRE.Size = New System.Drawing.Size(126, 17)
Me.ChkRE.TabIndex = 0
Me.ChkRE.Text = "Real Estate"
Me.ChkRE.UseVisualStyleBackColor = True
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.ChkMV)
Me.GroupBox1.Controls.Add(Me.ChkPP)
Me.GroupBox1.Controls.Add(Me.ChkRE)
Me.GroupBox1.Location = New System.Drawing.Point(104, 73)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(153, 87)
Me.GroupBox1.TabIndex = 42
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "Tax Types"
'
'ChkMV
'
Me.ChkMV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkMV.Checked = True
Me.ChkMV.CheckState = System.Windows.Forms.CheckState.Checked
Me.ChkMV.Location = New System.Drawing.Point(13, 64)
Me.ChkMV.Name = "ChkMV"
Me.ChkMV.Size = New System.Drawing.Size(126, 17)
Me.ChkMV.TabIndex = 2
Me.ChkMV.Text = "Motor Vehicle"
Me.ChkMV.UseVisualStyleBackColor = True
'
'ChkPP
'
Me.ChkPP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkPP.Checked = True
Me.ChkPP.CheckState = System.Windows.Forms.CheckState.Checked
Me.ChkPP.Location = New System.Drawing.Point(13, 43)
Me.ChkPP.Name = "ChkPP"
Me.ChkPP.Size = New System.Drawing.Size(126, 15)
Me.ChkPP.TabIndex = 1
Me.ChkPP.Text = "Personal Property"
Me.ChkPP.UseVisualStyleBackColor = True
'
'Label3
'
Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label3.Location = New System.Drawing.Point(32, 215)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(274, 33)
Me.Label3.TabIndex = 43
Me.Label3.Text = "NOTICE: This report is best when run for Last G/L Billed year only"
'
'FrmTXE25B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(352, 248)
Me.ControlBox = False
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.Label6)
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
Me.Name = "FrmTXE25B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox1.ResumeLayout(False)
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTXE25B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTXE25.SbpScreen.Text = "TXE25"
End Sub
Private Sub FrmTXE25B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(DtPckFrom, "")
    ErrProv.SetError(DtPckTo, "")
    ErrProv.SetError(TxtFromGLYear, "")
    ErrProv.SetError(TxtToGLYear, "")
    ErrProv.SetError(ChkRE, "")
    ErrProv.SetError(ChkPP, "")
    ErrProv.SetError(ChkMV, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "from"
        ErrProv.SetError(DtPckFrom, ErrorMsg(I))
      Case "to"
        ErrProv.SetError(DtPckTo, ErrorMsg(I))
      Case "fromglyear"
        ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
      Case "toglyear"
        ErrProv.SetError(TxtToGLYear, ErrorMsg(I))
      Case "type"
        ErrProv.SetError(ChkRE, ErrorMsg(I))
        ErrProv.SetError(ChkPP, ErrorMsg(I))
        ErrProv.SetError(ChkMV, ErrorMsg(I))
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

    If DtPckFrom.Value > DtPckTo.Value Then
      ErrorField(I) = "from"
      ErrorMsg(I) = "Invalid Date Range"
      I = I + 1
      ErrorField(I) = "to"
      ErrorMsg(I) = "Invalid Date Range"
      I = I + 1
    End If

    If Not ChkRE.Checked And Not ChkPP.Checked And Not ChkMV.Checked Then
      ErrorField(I) = "type"
      ErrorMsg(I) = "You must select at least one tax type"
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
Private Sub FrmTXE25B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  MyTypes = ""
End Sub
Private Sub TxtFromGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtToGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






