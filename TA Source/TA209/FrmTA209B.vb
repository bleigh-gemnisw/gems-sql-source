Public Class FrmTA209B
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
Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents ChkExemptionsOnly As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.GroupBox3 = New System.Windows.Forms.GroupBox
Me.DtPckTo = New System.Windows.Forms.DateTimePicker
Me.Label2 = New System.Windows.Forms.Label
Me.DtPckFrom = New System.Windows.Forms.DateTimePicker
Me.Label1 = New System.Windows.Forms.Label
Me.ErrProv = New System.Windows.Forms.ErrorProvider
Me.ChkExemptionsOnly = New System.Windows.Forms.CheckBox
Me.GroupBox3.SuspendLayout()
Me.SuspendLayout()
'
'GroupBox3
'
Me.GroupBox3.Controls.Add(Me.ChkExemptionsOnly)
Me.GroupBox3.Controls.Add(Me.DtPckTo)
Me.GroupBox3.Controls.Add(Me.Label2)
Me.GroupBox3.Controls.Add(Me.DtPckFrom)
Me.GroupBox3.Controls.Add(Me.Label1)
Me.GroupBox3.Location = New System.Drawing.Point(16, 48)
Me.GroupBox3.Name = "GroupBox3"
Me.GroupBox3.Size = New System.Drawing.Size(296, 80)
Me.GroupBox3.TabIndex = 2
Me.GroupBox3.TabStop = False
Me.GroupBox3.Text = "Purchase Date Range"
'

'ChkExemptionsOnly
'
Me.ChkExemptionsOnly.Location = New System.Drawing.Point(52, 48)
Me.ChkExemptionsOnly.Name = "ChkExemptionsOnly"
Me.ChkExemptionsOnly.Size = New System.Drawing.Size(160, 20)
Me.ChkExemptionsOnly.TabIndex = 2
Me.ChkExemptionsOnly.Text = "Only with exemptions"

'DtPckTo
'
Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.Short
Me.DtPckTo.Location = New System.Drawing.Point(196, 20)
Me.DtPckTo.Name = "DtPckTo"
Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
Me.DtPckTo.TabIndex = 1
Me.DtPckTo.Value = New Date(2005, 10, 6, 9, 11, 0, 906)
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(164, 24)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(28, 16)
Me.Label2.TabIndex = 9
Me.Label2.Text = "To "
'
'DtPckFrom
'
Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short
Me.DtPckFrom.Location = New System.Drawing.Point(52, 20)
Me.DtPckFrom.Name = "DtPckFrom"
Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
Me.DtPckFrom.TabIndex = 0
Me.DtPckFrom.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(12, 20)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(36, 16)
Me.Label1.TabIndex = 7
Me.Label1.Text = "From"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'FrmTA209B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(326, 178)
Me.ControlBox = False
Me.Controls.Add(Me.GroupBox3)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA209B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.GroupBox3.ResumeLayout(False)
Me.ResumeLayout(False)

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

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(DtPckFrom, "")
    ErrProv.SetError(DtPckTo, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "from"
        ErrProv.SetError(DtPckFrom, ErrorMsg(I))
      Case "to"
        ErrProv.SetError(DtPckTo, ErrorMsg(I))
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

    If MyUtils.SetDBDate(DtPckFrom.Value) > MyUtils.SetDBDate(DtPckTo.Value) Then
      ErrorField(I) = "to"
      ErrorMsg(I) = "Invalid date Range"
      I = I + 1
    End If

  End Sub

Private Sub FrmTA209B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA209.SbpScreen.Text = "TA209B"
End Sub

Private Sub FrmTA209B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  DtPckFrom.Value = Now.Date
  DtPckTo.Value = Now.Date
End Sub
End Class






