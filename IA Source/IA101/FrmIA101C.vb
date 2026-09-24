Public Class FrmIA101C
  Inherits System.Windows.Forms.Form
  Dim myGNET As GNET.myData
  Dim ds As DataSet = New DataSet
  Friend WrkCode As String
  Friend WithEvents TxtValue As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label

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
  Friend WithEvents TxtCode As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.TxtCode = New System.Windows.Forms.TextBox
Me.TxtDesc = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TxtValue = New System.Windows.Forms.TextBox
Me.Label6 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 12)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(92, 24)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Code"
'
'TxtCode
'
Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtCode.Location = New System.Drawing.Point(124, 12)
Me.TxtCode.MaxLength = 5
Me.TxtCode.Name = "TxtCode"
Me.TxtCode.Size = New System.Drawing.Size(53, 20)
Me.TxtCode.TabIndex = 0
'
'TxtDesc
'
Me.TxtDesc.Location = New System.Drawing.Point(124, 37)
Me.TxtDesc.MaxLength = 20
Me.TxtDesc.Name = "TxtDesc"
Me.TxtDesc.Size = New System.Drawing.Size(145, 20)
Me.TxtDesc.TabIndex = 2
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(8, 37)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(92, 24)
Me.Label3.TabIndex = 4
Me.Label3.Text = "Description"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'TxtValue
'
Me.TxtValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtValue.Location = New System.Drawing.Point(124, 61)
Me.TxtValue.MaxLength = 1
Me.TxtValue.Name = "TxtValue"
Me.TxtValue.Size = New System.Drawing.Size(23, 20)
Me.TxtValue.TabIndex = 3
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(8, 61)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(110, 24)
Me.Label6.TabIndex = 10
Me.Label6.Text = "Value"
'
'FrmIA101C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(312, 91)
Me.Controls.Add(Me.TxtValue)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.TxtDesc)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.TxtCode)
Me.Controls.Add(Me.Label1)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmIA101C"
Me.Text = "Maintain GEMS.NET Control file"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmIA101C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myGNET = New GNET.MyData()
  myGNET.MyDBConn = myDBConnect

  MyFrmIA101.TBarNew.Enabled = False
  MyFrmIA101.TBarSave.Enabled = True
  If WrkCode <> String.Empty Then
    MyFrmIA101.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(TxtCode)
  End If

  myGNET.GetOneRecordP(WrkCode)
  If myGNET.RecordNotFound Then Exit Sub
  TxtCode.Text = WrkCode

  If s_chg = False And s_full = False Then    '#sec
    MyFrmIA101.TBarSave.Visible = False
  End If
  With myGNET
    TxtDesc.Text = Trim(._DESC)
    TxtValue.Text = Trim(._VALUE)
  End With
End Sub
Private Sub FrmIA101C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmIA101.SbpScreen.Text = "IA101C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmIA101C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmIA101.TBarNew.Enabled = True
  MyFrmIA101.TBarDelete.Enabled = False
  MyFrmIA101.TBarSave.Enabled = False
  MyFrmIA101.TBarSave.Visible = True   '#sec
  MyFrmIA101B.FormatGrid()
  MyFrmIA101B.Show()
End Sub
Public Sub DeleteData(ByRef Cancel As Boolean)
  Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    myGNET.DeleteOneRecordP()

End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String

  ErrProv.SetError(TxtCode, "")
  ErrProv.SetError(TxtDesc, "")
  myGNET.GetOneRecordP(TxtCode.Text)
  If WrkCode = "" Then
    If myGNET.RecordNotFound = False Then
      Me.ErrProv.SetError(TxtCode, "Record already exists")
      Exit Sub
    End If
  End If

  If Not myGNET.RecordNotFound Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MovetoFile()
        myGNET.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MovetoFile()
        myGNET.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
  Me.Close()
End Sub
Private Sub MovetoFile()

   With myGNET
    ._CODE = TxtCode.Text
    ._DESC = TxtDesc.Text
    ._VALUE = TxtValue.Text
  End With

End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtCode, "")
  ErrProv.SetError(TxtDesc, "")

  For I = 0 To ErrorField.GetUpperBound(0)
  Select Case ErrorField(I)
    Case "code"
      ErrProv.SetError(TxtCode, ErrorMsg(I))
    Case "desc"
      ErrProv.SetError(TxtDesc, ErrorMsg(I))
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

  If TxtCode.Text = String.Empty Then
      ErrorField(I) = "code"
      ErrorMsg(I) = "Invalid Code"
      I = I + 1
  End If

  If TxtDesc.Text = String.Empty Then
      ErrorField(I) = "desc"
      ErrorMsg(I) = "Invalid Description"
      I = I + 1
  End If

  End Sub
End Class
