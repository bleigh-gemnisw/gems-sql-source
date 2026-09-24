Public Class FrmTA138C
  Inherits System.Windows.Forms.Form
  Dim myTXM37LND As TXM37LND.myData
  Friend WrkDesc As String
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
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtExmpt As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtExmpt = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(3, 8)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(84, 13)
    Me.Label2.TabIndex = 28
    Me.Label2.Text = "Exemption Code"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtExmpt
    '
    Me.TxtExmpt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExmpt.Location = New System.Drawing.Point(93, 5)
    Me.TxtExmpt.MaxLength = 4
    Me.TxtExmpt.Name = "TxtExmpt"
    Me.TxtExmpt.Size = New System.Drawing.Size(34, 20)
    Me.TxtExmpt.TabIndex = 0
    '
    'FrmTA138C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(258, 36)
    Me.Controls.Add(Me.TxtExmpt)
    Me.Controls.Add(Me.Label2)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA138C"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region
Private Sub FrmTA138C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myTXM37LND = New TXM37LND.mydata(MyDBConnect)
  MyFrmTA138.TBarNew.Enabled = False
  MyFrmTA138.TBarSave.Enabled = True
  MyFrmTA138.TBarPrint.Enabled = False
  If WrkDesc <> "" Then
    MyFrmTA138.TBarDelete.Enabled = True
    MyFrmTA138.TBarSave.Enabled = False
    MyUtils.SetTxtReadOnly(TxtExmpt)
  End If
  If WrkDesc = "" Then
    Me.Text = "Add " & Me.Text
    MyFrmTA138.TBarDelete.Enabled = False
    Exit Sub
    End If
  myTXM37LND.GetOneRecordP(WrkDesc)

  If myTXM37LND.RecordNotFound Then
    MyFrmTA138.TBarNew.Enabled = False
    MyFrmTA138.TBarSave.Enabled = False
    MyFrmTA138.TBarDelete.Enabled = False
    Me.ErrProv.SetError(TxtExmpt, "Record not found")
    Exit Sub
  End If

  If s_chg = False And s_full = False Then    '#sec
    MyFrmTA138.TBarSave.Visible = False
  End If

  With myTXM37LND
    TxtExmpt.Text = Trim(._EXMPT)
  End With
End Sub
Private Sub FrmTA138C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA138.SbpScreen.Text = "TA138C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmTA138C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTA138.TBarNew.Enabled = True
  MyFrmTA138.TBarDelete.Enabled = False
  MyFrmTA138.TBarSave.Enabled = False
  MyFrmTA138.TBarPrint.Enabled = False
  MyFrmTA138B.FormatGrid()
  MyFrmTA138B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
  myTXM37LND.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  myTXM37LND.GetOneRecordP(TxtExmpt.Text)
  If WrkDesc = "" Then
    If Not myTXM37LND.RecordNotFound Then
      Me.ErrProv.SetError(TxtExmpt, "Record already exists")
      Exit Sub
    End If
  End If
  If WrkDesc <> "" Then
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myTXM37LND.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  Else
    myTXM37LND._EXMPT = TxtExmpt.Text
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myTXM37LND.AddOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myTXM37LND
  End With
End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If TxtExmpt.Text = String.Empty Then
      ErrorField(I) = "code"
      ErrorMsg(I) = "Exemption Code is required"
      I = I + 1
    End If

  End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtExmpt, "")
  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
    Case "code"
      ErrProv.SetError(TxtExmpt, ErrorMsg(I))
    Case Nothing
      Exit Sub
    End Select
  Next I
End Sub
End Class






