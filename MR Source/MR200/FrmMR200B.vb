Public Class FrmMR200B
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
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtBatch As System.Windows.Forms.TextBox
  Friend WithEvents LblCodes As Label
  Friend WithEvents BtnSelCodes As Button
  Friend WithEvents ChkDetail As CheckBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.TxtBatch = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.LblCodes = New System.Windows.Forms.Label()
    Me.BtnSelCodes = New System.Windows.Forms.Button()
    Me.ChkDetail = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(19, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(60, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "From Date"
    '
    'DtPckFrom
    '
    Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFrom.Location = New System.Drawing.Point(79, 12)
    Me.DtPckFrom.Name = "DtPckFrom"
    Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
    Me.DtPckFrom.TabIndex = 4
    '
    'DtPckTo
    '
    Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTo.Location = New System.Drawing.Point(239, 12)
    Me.DtPckTo.Name = "DtPckTo"
    Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
    Me.DtPckTo.TabIndex = 6
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(187, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(52, 16)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "To Date"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.TxtBatch)
    Me.GroupBox2.Controls.Add(Me.Label5)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(12, 162)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(157, 59)
    Me.GroupBox2.TabIndex = 38
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Optional Selection"
    '
    'TxtBatch
    '
    Me.TxtBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBatch.Location = New System.Drawing.Point(93, 24)
    Me.TxtBatch.MaxLength = 5
    Me.TxtBatch.Name = "TxtBatch"
    Me.TxtBatch.Size = New System.Drawing.Size(40, 20)
    Me.TxtBatch.TabIndex = 47
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(9, 28)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(44, 16)
    Me.Label5.TabIndex = 46
    Me.Label5.Text = "Batch #"
    '
    'LblCodes
    '
    Me.LblCodes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCodes.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblCodes.Location = New System.Drawing.Point(9, 45)
    Me.LblCodes.Name = "LblCodes"
    Me.LblCodes.Size = New System.Drawing.Size(324, 43)
    Me.LblCodes.TabIndex = 210
    Me.LblCodes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'BtnSelCodes
    '
    Me.BtnSelCodes.Location = New System.Drawing.Point(124, 91)
    Me.BtnSelCodes.Name = "BtnSelCodes"
    Me.BtnSelCodes.Size = New System.Drawing.Size(87, 35)
    Me.BtnSelCodes.TabIndex = 209
    Me.BtnSelCodes.Text = "Select Codes"
    Me.BtnSelCodes.UseVisualStyleBackColor = True
    '
    'ChkDetail
    '
    Me.ChkDetail.AutoSize = True
    Me.ChkDetail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkDetail.Location = New System.Drawing.Point(33, 139)
    Me.ChkDetail.Name = "ChkDetail"
    Me.ChkDetail.Size = New System.Drawing.Size(89, 17)
    Me.ChkDetail.TabIndex = 211
    Me.ChkDetail.Text = "Show Detail?"
    Me.ChkDetail.UseVisualStyleBackColor = True
    '
    'FrmMR200B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(342, 233)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkDetail)
    Me.Controls.Add(Me.LblCodes)
    Me.Controls.Add(Me.BtnSelCodes)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.DtPckTo)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.DtPckFrom)
    Me.Controls.Add(Me.Label1)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmMR200B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmMR200B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmMR200.SbpScreen.Text = "MR200B"
  End Sub
  Private Sub FrmMR200B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.Clear()

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
  Private Sub FrmMR200B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    LblCodes.Text = "* ALL Codes *"
    MySelCodes = String.Empty
  End Sub

  Private Sub BtnSelCodes_Click(sender As Object, e As EventArgs) Handles BtnSelCodes.Click
    MyFrmSelCodes = New FrmSelCodes
    MyFrmSelCodes.ShowDialog()
    If MySelCodes = "" Then
      LblCodes.Text = "* ALL Codes *"
    Else
      LblCodes.Text = MySelCodes
    End If
  End Sub
End Class
