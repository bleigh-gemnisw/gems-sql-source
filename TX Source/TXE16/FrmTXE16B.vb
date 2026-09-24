Public Class FrmTXE16B
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
Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.DtPckFrom = New System.Windows.Forms.DateTimePicker
Me.DtPckTo = New System.Windows.Forms.DateTimePicker
Me.Label2 = New System.Windows.Forms.Label
Me.TxtTypes = New System.Windows.Forms.TextBox
Me.LnkTypes = New System.Windows.Forms.LinkLabel
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
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
'TxtTypes
'
Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtTypes.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtTypes.Location = New System.Drawing.Point(119, 75)
Me.TxtTypes.MaxLength = 20
Me.TxtTypes.Name = "TxtTypes"
Me.TxtTypes.Size = New System.Drawing.Size(148, 20)
Me.TxtTypes.TabIndex = 3
'
'LnkTypes
'
Me.LnkTypes.Location = New System.Drawing.Point(33, 78)
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
'FrmTXE16B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(352, 155)
Me.ControlBox = False
Me.Controls.Add(Me.TxtTypes)
Me.Controls.Add(Me.LnkTypes)
Me.Controls.Add(Me.DtPckTo)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.DtPckFrom)
Me.Controls.Add(Me.Label1)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTXE16B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTXE16B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTXE16.SbpScreen.Text = "TXE16"
End Sub
Private Sub FrmTXE16B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(DtPckFrom, "")
    ErrProv.SetError(DtPckTo, "")
    ErrProv.SetError(TxtTypes, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "from"
        ErrProv.SetError(DtPckFrom, ErrorMsg(I))
      Case "to"
        ErrProv.SetError(DtPckTo, ErrorMsg(I))
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

    If DtPckFrom.Value > DtPckTo.Value Then
      ErrorField(I) = "from"
      ErrorMsg(I) = "Invalid Date Range"
      I = I + 1
      ErrorField(I) = "to"
      ErrorMsg(I) = "Invalid Date Range"
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
Private Sub FrmTXE16B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  MyTypes = ""
End Sub
Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
  MyTypes = TxtTypes.Text
  MyFrmSelTypes = New FrmSelTypes
  MyFrmSelTypes.MdiParent = Me.ParentForm
  MyFrmSelTypes.Show()
  Me.Hide()

End Sub
End Class






