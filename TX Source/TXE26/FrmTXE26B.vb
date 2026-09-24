Public Class FrmTXE26B
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
  Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents TxtToGLYear As System.Windows.Forms.TextBox
Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents TxtName As System.Windows.Forms.TextBox
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents TxtCustID As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents Label9 As System.Windows.Forms.Label
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbNameDate As System.Windows.Forms.RadioButton
Friend WithEvents RbDateList As System.Windows.Forms.RadioButton
Friend WithEvents RbDateName As System.Windows.Forms.RadioButton
Friend WithEvents ChkRegno As System.Windows.Forms.CheckBox
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtToGLYear = New System.Windows.Forms.TextBox()
    Me.TxtFromGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtTypes = New System.Windows.Forms.TextBox()
    Me.LnkTypes = New System.Windows.Forms.LinkLabel()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtCustID = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbDateName = New System.Windows.Forms.RadioButton()
    Me.RbNameDate = New System.Windows.Forms.RadioButton()
    Me.RbDateList = New System.Windows.Forms.RadioButton()
    Me.ChkRegno = New System.Windows.Forms.CheckBox()
    Me.Label6 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(32, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(60, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "From Date"
    '
    'DtPckFrom
    '
    Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFrom.Location = New System.Drawing.Point(92, 8)
    Me.DtPckFrom.Name = "DtPckFrom"
    Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
    Me.DtPckFrom.TabIndex = 0
    '
    'DtPckTo
    '
    Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTo.Location = New System.Drawing.Point(252, 8)
    Me.DtPckTo.Name = "DtPckTo"
    Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
    Me.DtPckTo.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(200, 12)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(52, 16)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "To Date"
    '
    'TxtListNo
    '
    Me.TxtListNo.Location = New System.Drawing.Point(92, 186)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(50, 20)
    Me.TxtListNo.TabIndex = 4
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(32, 189)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(44, 16)
    Me.Label5.TabIndex = 14
    Me.Label5.Text = "List #"
    '
    'TxtToGLYear
    '
    Me.TxtToGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtToGLYear.Location = New System.Drawing.Point(185, 262)
    Me.TxtToGLYear.MaxLength = 4
    Me.TxtToGLYear.Name = "TxtToGLYear"
    Me.TxtToGLYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtToGLYear.TabIndex = 8
    '
    'TxtFromGLYear
    '
    Me.TxtFromGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFromGLYear.Location = New System.Drawing.Point(115, 262)
    Me.TxtFromGLYear.MaxLength = 4
    Me.TxtFromGLYear.Name = "TxtFromGLYear"
    Me.TxtFromGLYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtFromGLYear.TabIndex = 7
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(163, 266)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(16, 16)
    Me.Label4.TabIndex = 32
    Me.Label4.Text = "to"
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(31, 266)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(84, 16)
    Me.Label7.TabIndex = 31
    Me.Label7.Text = "Grand List Year"
    '
    'TxtTypes
    '
    Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTypes.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTypes.Location = New System.Drawing.Point(116, 288)
    Me.TxtTypes.MaxLength = 20
    Me.TxtTypes.Name = "TxtTypes"
    Me.TxtTypes.Size = New System.Drawing.Size(148, 20)
    Me.TxtTypes.TabIndex = 9
    '
    'LnkTypes
    '
    Me.LnkTypes.Location = New System.Drawing.Point(30, 291)
    Me.LnkTypes.Name = "LnkTypes"
    Me.LnkTypes.Size = New System.Drawing.Size(80, 16)
    Me.LnkTypes.TabIndex = 35
    Me.LnkTypes.TabStop = True
    Me.LnkTypes.Text = "Types to print"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtCustID
    '
    Me.TxtCustID.Location = New System.Drawing.Point(92, 212)
    Me.TxtCustID.MaxLength = 10
    Me.TxtCustID.Name = "TxtCustID"
    Me.TxtCustID.Size = New System.Drawing.Size(59, 20)
    Me.TxtCustID.TabIndex = 5
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(32, 215)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(42, 13)
    Me.Label3.TabIndex = 36
    Me.Label3.Text = "Cust ID"
    '
    'TxtName
    '
    Me.TxtName.Location = New System.Drawing.Point(92, 236)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(265, 20)
    Me.TxtName.TabIndex = 6
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(32, 241)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(44, 16)
    Me.Label8.TabIndex = 38
    Me.Label8.Text = "Name"
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(31, 138)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(170, 20)
    Me.Label9.TabIndex = 40
    Me.Label9.Text = "Optional Selections:"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbDateName)
    Me.GroupBox1.Controls.Add(Me.RbNameDate)
    Me.GroupBox1.Controls.Add(Me.RbDateList)
    Me.GroupBox1.Location = New System.Drawing.Point(40, 34)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(148, 88)
    Me.GroupBox1.TabIndex = 2
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Sort by"
    '
    'RbDateName
    '
    Me.RbDateName.AutoSize = True
    Me.RbDateName.Location = New System.Drawing.Point(6, 42)
    Me.RbDateName.Name = "RbDateName"
    Me.RbDateName.Size = New System.Drawing.Size(126, 17)
    Me.RbDateName.TabIndex = 2
    Me.RbDateName.Text = "Payment Date, Name"
    Me.RbDateName.UseVisualStyleBackColor = True
    '
    'RbNameDate
    '
    Me.RbNameDate.AutoSize = True
    Me.RbNameDate.Location = New System.Drawing.Point(6, 65)
    Me.RbNameDate.Name = "RbNameDate"
    Me.RbNameDate.Size = New System.Drawing.Size(126, 17)
    Me.RbNameDate.TabIndex = 1
    Me.RbNameDate.Text = "Name, Payment Date"
    Me.RbNameDate.UseVisualStyleBackColor = True
    '
    'RbDateList
    '
    Me.RbDateList.AutoSize = True
    Me.RbDateList.Checked = True
    Me.RbDateList.Location = New System.Drawing.Point(6, 19)
    Me.RbDateList.Name = "RbDateList"
    Me.RbDateList.Size = New System.Drawing.Size(124, 17)
    Me.RbDateList.TabIndex = 0
    Me.RbDateList.TabStop = True
    Me.RbDateList.Text = "Payment Date, List #"
    Me.RbDateList.UseVisualStyleBackColor = True
    '
    'ChkRegno
    '
    Me.ChkRegno.AutoSize = True
    Me.ChkRegno.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkRegno.Location = New System.Drawing.Point(30, 161)
    Me.ChkRegno.Name = "ChkRegno"
    Me.ChkRegno.Size = New System.Drawing.Size(121, 17)
    Me.ChkRegno.TabIndex = 3
    Me.ChkRegno.Text = "Include MV Regno?"
    Me.ChkRegno.UseVisualStyleBackColor = True
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(12, 311)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(345, 14)
    Me.Label6.TabIndex = 41
    Me.Label6.Text = "Detail Report uses Arial Narrow font. Contact hotline if data is cut off."
    '
    'FrmTXE26B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(361, 334)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.ChkRegno)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.TxtName)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.TxtCustID)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtTypes)
    Me.Controls.Add(Me.LnkTypes)
    Me.Controls.Add(Me.TxtToGLYear)
    Me.Controls.Add(Me.TxtFromGLYear)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TxtListNo)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.DtPckTo)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.DtPckFrom)
    Me.Controls.Add(Me.Label1)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXE26B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

Private Sub FrmTXE26B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTXE26.SbpScreen.Text = "TXE26"
End Sub
Private Sub FrmTXE26B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFromGLYear, "")
    ErrProv.SetError(TxtToGLYear, "")
    ErrProv.SetError(TxtTypes, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "fromglyear"
        ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
      Case "toglyear"
        ErrProv.SetError(TxtToGLYear, ErrorMsg(I))
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
Private Sub FrmTXE26B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  MyTypes = ""
End Sub
Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
  MyTypes = TxtTypes.Text
  MyFrmSelTypes = New FrmSelTypes
  MyFrmSelTypes.MdiParent = Me.ParentForm
  MyFrmSelTypes.Show()
  Me.Hide()

End Sub
Private Sub TxtListNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtListNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtFromGLYear_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFromGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtToGLYear_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtToGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtCustID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCustID.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






