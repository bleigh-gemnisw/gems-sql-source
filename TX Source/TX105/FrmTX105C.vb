Public Class FrmTX105C
  Inherits System.Windows.Forms.Form
  Dim myTXPEN As TXPEN.myData
  Friend wrkpncode As String
  Friend wrkpndesc As String
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
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Txtpncode As System.Windows.Forms.TextBox
  Friend WithEvents Txtpndesc As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Me.Label1 = New System.Windows.Forms.Label
    Me.Txtpncode = New System.Windows.Forms.TextBox
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label2 = New System.Windows.Forms.Label
    Me.Txtpndesc = New System.Windows.Forms.TextBox
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Code"
    '
    'Txtpncode
    '
    Me.Txtpncode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.Txtpncode.Location = New System.Drawing.Point(54, 9)
    Me.Txtpncode.MaxLength = 2
    Me.Txtpncode.Name = "Txtpncode"
    Me.Txtpncode.Size = New System.Drawing.Size(28, 20)
    Me.Txtpncode.TabIndex = 0
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(105, 12)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(69, 16)
    Me.Label2.TabIndex = 28
    Me.Label2.Text = "Description"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Txtpndesc
    '
    Me.Txtpndesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.Txtpndesc.Location = New System.Drawing.Point(178, 8)
    Me.Txtpndesc.MaxLength = 30
    Me.Txtpndesc.Name = "Txtpndesc"
    Me.Txtpndesc.Size = New System.Drawing.Size(344, 20)
    Me.Txtpndesc.TabIndex = 2
    '
    'FrmTX105C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(531, 36)
    Me.Controls.Add(Me.Txtpndesc)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Txtpncode)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX105C"
    Me.Text = "Maintain Fee Codes"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region
  Private Sub FrmTX105C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXPEN = New TXPEN.mydata(myDBConnect)
    MyFrmTX105.TBarNew.Enabled = False
    MyFrmTX105.TBarSave.Enabled = True
    MyFrmTX105.TBarPrint.Enabled = False
    If wrkpncode <> "" Then
      MyFrmTX105.TBarDelete.Enabled = True
      MyUtils.SetTxtReadOnly(Txtpncode)
    End If
    If wrkpncode = "" Then
      Me.Text = "Add " & Me.Text
      MyFrmTX105.TBarDelete.Enabled = False
      Exit Sub
    End If
    myTXPEN.GetOneRecordP(wrkpncode)
    Txtpncode.Text = wrkpncode
    Txtpndesc.Text = wrkpndesc

    If myTXPEN.RecordNotFound Then
      MyFrmTX105.TBarNew.Enabled = False
      MyFrmTX105.TBarSave.Enabled = False
      MyFrmTX105.TBarDelete.Enabled = False
      Me.ErrProv.SetError(Txtpncode, "Record not found")
      Exit Sub
    End If

    If s_chg = False And s_full = False Then    '#sec
      MyFrmTX105.TBarSave.Visible = False
    End If
    Txtpndesc.Text = wrkpndesc
  End Sub
  Private Sub FrmTX105C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTX105.SbpScreen.Text = "TX105C"
    MyUtils.CenterForm(Me.ParentForm, Me)
    If wrkpncode <> "" Then
    End If
  End Sub
  Private Sub FrmTX105C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTX105.TBarNew.Enabled = True
    MyFrmTX105.TBarDelete.Enabled = False
    MyFrmTX105.TBarSave.Enabled = False
    MyFrmTX105.TBarPrint.Enabled = False
    MyFrmTX105B.FormatGrid()
    MyFrmTX105B.Show()
  End Sub
  Public Sub DeleteData()
    Dim Answer As Integer
    Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
    If Answer = vbNo Then
      Exit Sub
    End If
    myTXPEN.DeleteOneRecordP()
    Me.Close()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    myTXPEN.GetOneRecordP(Txtpncode.Text)
    If wrkpncode = "" Then
      If Not myTXPEN.RecordNotFound Then
        Me.ErrProv.SetError(Txtpncode, "Record already exists")
        Exit Sub
      End If
    End If
    If wrkpncode <> "" Then
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXPEN.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      myTXPEN._PNCODE = Txtpncode.Text
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXPEN.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()
  End Sub
  Private Sub MovetoFile()
    With myTXPEN
      ._PNDESC = Txtpndesc.Text
    End With
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If Txtpncode.Text = String.Empty Then
      ErrorField(I) = "code"
      ErrorMsg(I) = "Code is required"
      I = I + 1
    End If

    If Txtpndesc.Text = String.Empty Then
      ErrorField(I) = "desc"
      ErrorMsg(I) = "Description is required"
      I = I + 1
    End If
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(Txtpncode, "")
    ErrProv.SetError(Txtpndesc, "")
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "code"
          ErrProv.SetError(Txtpncode, ErrorMsg(I))
        Case "desc"
          ErrProv.SetError(Txtpndesc, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
End Class






