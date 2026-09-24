Public Class FrmGLA44C
  Inherits System.Windows.Forms.Form
  Dim myMUNMIL As MUNMIL.myData
  Dim ds As DataSet = New DataSet
  Friend WrkCode As String
 Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
 Friend WithEvents Label5 As System.Windows.Forms.Label
 Friend WithEvents TxtCode As System.Windows.Forms.TextBox
 Friend WithEvents Label3 As System.Windows.Forms.Label
 Friend WithEvents TxtObject As System.Windows.Forms.TextBox
 Friend WithEvents TxtOrig As System.Windows.Forms.TextBox
 Friend WithEvents Label2 As System.Windows.Forms.Label
 Friend WithEvents RbDebit As System.Windows.Forms.RadioButton
 Friend WithEvents Label1 As System.Windows.Forms.Label
 Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
 Friend WithEvents RbCredit As System.Windows.Forms.RadioButton

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.TxtCode = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtOrig = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtObject = New System.Windows.Forms.TextBox()
    Me.RbCredit = New System.Windows.Forms.RadioButton()
    Me.RbDebit = New System.Windows.Forms.RadioButton()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtDesc = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtCode
    '
    Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode.Location = New System.Drawing.Point(55, 12)
    Me.TxtCode.MaxLength = 5
    Me.TxtCode.Name = "TxtCode"
    Me.TxtCode.Size = New System.Drawing.Size(62, 20)
    Me.TxtCode.TabIndex = 0
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(10, 12)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(39, 20)
    Me.Label5.TabIndex = 343
    Me.Label5.Text = "Code"
    '
    'TxtOrig
    '
    Me.TxtOrig.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOrig.Location = New System.Drawing.Point(55, 57)
    Me.TxtOrig.MaxLength = 8
    Me.TxtOrig.Name = "TxtOrig"
    Me.TxtOrig.Size = New System.Drawing.Size(56, 20)
    Me.TxtOrig.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(8, 60)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(30, 20)
    Me.Label2.TabIndex = 344
    Me.Label2.Text = "Orig"
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(8, 83)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(41, 20)
    Me.Label3.TabIndex = 347
    Me.Label3.Text = "Object"
    '
    'TxtObject
    '
    Me.TxtObject.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObject.Location = New System.Drawing.Point(55, 80)
    Me.TxtObject.MaxLength = 6
    Me.TxtObject.Name = "TxtObject"
    Me.TxtObject.Size = New System.Drawing.Size(46, 20)
    Me.TxtObject.TabIndex = 2
    '
    'RbCredit
    '
    Me.RbCredit.AutoSize = True
    Me.RbCredit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbCredit.Checked = True
    Me.RbCredit.Location = New System.Drawing.Point(84, 129)
    Me.RbCredit.Name = "RbCredit"
    Me.RbCredit.Size = New System.Drawing.Size(52, 17)
    Me.RbCredit.TabIndex = 4
    Me.RbCredit.TabStop = True
    Me.RbCredit.Text = "Credit"
    Me.RbCredit.UseVisualStyleBackColor = True
    '
    'RbDebit
    '
    Me.RbDebit.AutoSize = True
    Me.RbDebit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbDebit.Location = New System.Drawing.Point(167, 129)
    Me.RbDebit.Name = "RbDebit"
    Me.RbDebit.Size = New System.Drawing.Size(50, 17)
    Me.RbDebit.TabIndex = 5
    Me.RbDebit.Text = "Debit"
    Me.RbDebit.UseVisualStyleBackColor = True
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(10, 106)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(39, 20)
    Me.Label1.TabIndex = 351
    Me.Label1.Text = "Desc"
    '
    'TxtDesc
    '
    Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDesc.Location = New System.Drawing.Point(55, 103)
    Me.TxtDesc.MaxLength = 35
    Me.TxtDesc.Name = "TxtDesc"
    Me.TxtDesc.Size = New System.Drawing.Size(250, 20)
    Me.TxtDesc.TabIndex = 3
    '
    'FrmGLA44C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(317, 160)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtDesc)
    Me.Controls.Add(Me.RbDebit)
    Me.Controls.Add(Me.RbCredit)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtObject)
    Me.Controls.Add(Me.TxtOrig)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtCode)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGLA44C"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region


  Private Sub FrmGLA44C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myMUNMIL = New MUNMIL.MyData()
    myMUNMIL.MyDBConn = myDBConnect
    LoadForm()
  End Sub
Private Sub LoadForm()
  MyFrmGLA44.TBarNew.Enabled = False
  MyFrmGLA44.TBarSave.Enabled = True
  MyFrmGLA44.TBarDelete.Enabled = True
  MyFrmGLA44.TBarPrint.Enabled = False

  myMUNMIL.GetOneRecordP(WrkCode)
  If myMUNMIL.RecordNotFound Then
    MyFrmGLA44.TBarDelete.Enabled = False
    Exit Sub
  End If

  With myMUNMIL
    MyUtils.SetTxtReadOnly(TxtCode)
    TxtCode.Text = WrkCode
    TxtOrig.Text = Trim(._ORIG)
    TxtObject.Text = Trim(._OBJ)
    TxtDesc.Text = Trim(._DESC)
    If ._DBCR = "C" Then
      RbCredit.Checked = True
    Else
      RbDebit.Checked = True
    End If
  End With
End Sub
Private Sub FrmGLA44C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmGLA44.SbpScreen.Text = "GLA44C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub FrmGLA44C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmGLA44.TBarNew.Enabled = True
  MyFrmGLA44.TBarDelete.Enabled = False
  MyFrmGLA44.TBarSave.Enabled = False
  MyFrmGLA44.TBarNew.Enabled = True
  MyFrmGLA44.TBarPrint.Enabled = False
  MyFrmGLA44B.FormatGridAccts()
  MyFrmGLA44B.Show()
  'Memory Cleanup
  myMUNMIL = Nothing
  MyFrmGLA44C = Nothing
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If

  myMUNMIL.GetOneRecordP(TxtCode.Text)
  myMUNMIL.DeleteOneRecordP()
  Me.Close()
End Sub

Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String

  myMUNMIL.GetOneRecordP(TxtCode.Text)
  If WrkCode = String.Empty Then
    If Not myMUNMIL.RecordNotFound Then
      Me.ErrProv.SetError(TxtCode, "Record already exists")
      Exit Sub
    End If
  End If
  If Not myMUNMIL.RecordNotFound Then
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myMUNMIL.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  Else
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      With myMUNMIL
        ._CODE = TxtCode.Text
      End With
      myMUNMIL.AddOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myMUNMIL
    ._ORIG = TxtOrig.Text
    ._OBJ = TxtObject.Text
    ._DESC = TxtDesc.Text
    If RbCredit.Checked Then
      ._DBCR = "C"
    Else
      ._DBCR = "D"
    End If
  End With
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
      ErrorMsg(I) = "Code is required"
      I = I + 1
    End If

    If TxtOrig.Text = String.Empty Then
      ErrorField(I) = "orig"
      ErrorMsg(I) = "Orig is required"
      I = I + 1
    End If

    If TxtObject.Text = String.Empty Then
      ErrorField(I) = "obj"
      ErrorMsg(I) = "Object is required"
      I = I + 1
    End If

    If TxtDesc.Text = String.Empty Then
      ErrorField(I) = "desc"
      ErrorMsg(I) = "Description is required"
      I = I + 1
    End If
  End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtCode, String.Empty)
  ErrProv.SetError(TxtOrig, String.Empty)
  ErrProv.SetError(TxtObject, String.Empty)
  ErrProv.SetError(TxtDesc, String.Empty)
  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
    Case "code"
      ErrProv.SetError(TxtCode, ErrorMsg(I))
    Case "orig"
      ErrProv.SetError(TxtOrig, ErrorMsg(I))
    Case "obj"
      ErrProv.SetError(TxtObject, ErrorMsg(I))
    Case "desc"
      ErrProv.SetError(TxtDesc, ErrorMsg(I))
    Case Nothing
      Exit Sub
    End Select
  Next I
End Sub
End Class
