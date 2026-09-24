Public Class FrmGLA43B
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
Friend WithEvents TxtFilePath As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents ChkSuppSame As System.Windows.Forms.CheckBox
Friend WithEvents RbRevenue As System.Windows.Forms.RadioButton
Friend WithEvents RbAR As System.Windows.Forms.RadioButton
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
    Me.TxtFilePath = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.ChkSuppSame = New System.Windows.Forms.CheckBox()
    Me.RbRevenue = New System.Windows.Forms.RadioButton()
    Me.RbAR = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(12, 77)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(60, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "From Date"
    '
    'DtPckFrom
    '
    Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFrom.Location = New System.Drawing.Point(72, 73)
    Me.DtPckFrom.Name = "DtPckFrom"
    Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
    Me.DtPckFrom.TabIndex = 2
    '
    'DtPckTo
    '
    Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTo.Location = New System.Drawing.Point(232, 73)
    Me.DtPckTo.Name = "DtPckTo"
    Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
    Me.DtPckTo.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(180, 77)
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
    Me.GroupBox2.Location = New System.Drawing.Point(15, 152)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(125, 59)
    Me.GroupBox2.TabIndex = 5
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Optional Selection"
    '
    'TxtBatch
    '
    Me.TxtBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBatch.Location = New System.Drawing.Point(59, 24)
    Me.TxtBatch.MaxLength = 5
    Me.TxtBatch.Name = "TxtBatch"
    Me.TxtBatch.Size = New System.Drawing.Size(40, 20)
    Me.TxtBatch.TabIndex = 0
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
    'TxtFilePath
    '
    Me.TxtFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFilePath.Location = New System.Drawing.Point(74, 109)
    Me.TxtFilePath.MaxLength = 50
    Me.TxtFilePath.Name = "TxtFilePath"
    Me.TxtFilePath.Size = New System.Drawing.Size(218, 20)
    Me.TxtFilePath.TabIndex = 4
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(12, 112)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(56, 17)
    Me.Label3.TabIndex = 48
    Me.Label3.Text = "File Path"
    '
    'TxtGLYear
    '
    Me.TxtGLYear.Location = New System.Drawing.Point(108, 40)
    Me.TxtGLYear.MaxLength = 4
    Me.TxtGLYear.Name = "TxtGLYear"
    Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtGLYear.TabIndex = 0
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(12, 43)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(93, 17)
    Me.Label4.TabIndex = 50
    Me.Label4.Text = "Current G/L Year"
    '
    'ChkSuppSame
    '
    Me.ChkSuppSame.AutoSize = True
    Me.ChkSuppSame.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkSuppSame.Location = New System.Drawing.Point(190, 42)
    Me.ChkSuppSame.Name = "ChkSuppSame"
    Me.ChkSuppSame.Size = New System.Drawing.Size(130, 17)
    Me.ChkSuppSame.TabIndex = 1
    Me.ChkSuppSame.Text = "Mv Supp Same Year?"
    Me.ChkSuppSame.UseVisualStyleBackColor = True
    '
    'RbRevenue
    '
    Me.RbRevenue.AutoSize = True
    Me.RbRevenue.Checked = True
    Me.RbRevenue.Location = New System.Drawing.Point(12, 12)
    Me.RbRevenue.Name = "RbRevenue"
    Me.RbRevenue.Size = New System.Drawing.Size(99, 17)
    Me.RbRevenue.TabIndex = 51
    Me.RbRevenue.Text = "Revenue Accts"
    Me.RbRevenue.UseVisualStyleBackColor = True
    '
    'RbAR
    '
    Me.RbAR.AutoSize = True
    Me.RbAR.Location = New System.Drawing.Point(128, 12)
    Me.RbAR.Name = "RbAR"
    Me.RbAR.Size = New System.Drawing.Size(75, 17)
    Me.RbAR.TabIndex = 52
    Me.RbAR.Text = "A/R Accts"
    Me.RbAR.UseVisualStyleBackColor = True
    '
    'FrmGLA43B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(342, 227)
    Me.ControlBox = False
    Me.Controls.Add(Me.RbAR)
    Me.Controls.Add(Me.RbRevenue)
    Me.Controls.Add(Me.ChkSuppSame)
    Me.Controls.Add(Me.TxtGLYear)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtFilePath)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.DtPckTo)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.DtPckFrom)
    Me.Controls.Add(Me.Label1)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGLA43B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmGLA43B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmGLA43.SbpScreen.Text = "GLA43"
End Sub
Private Sub FrmGLA43B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
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

Public Sub RunReport()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    SaveSettings()
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

Private Sub FrmGLA43B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  TxtFilePath.Text = MyAppSettings.FilePath
  TxtGLYear.Text = MyAppSettings.GLYear
  If MyAppSettings.SuppSame Then
    ChkSuppSame.Checked = True
  End If
End Sub
Public Sub SaveSettings()
  Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
  Dim sw As IO.StreamWriter
  Dim WrkProgName As String
  Dim WrkXMLPath As String

  With MyAppSettings
    .FilePath = TxtFilePath.Text
    .GLYear = MyUtils.CnvSng(TxtGLYear.Text)
    .SuppSame = ChkSuppSame.Checked
  End With

  WrkProgName = Replace(MyUtils.GetProgramName, ".exe", "")
  WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & " " & MyUtils.GetComputerName() & ".xml"
  sw = New IO.StreamWriter(WrkXMLPath)
  xs.Serialize(sw, MyAppSettings)
  sw.Close()
End Sub

  Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
End Class
