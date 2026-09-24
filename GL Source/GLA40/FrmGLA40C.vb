Public Class FrmGLA40C
  Inherits System.Windows.Forms.Form
  Dim myTXGLEL As TXGLEL.myData
  Dim ds As DataSet = New DataSet
  Friend WrkTran As String
  Friend WrkCode As String
 Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
 Friend WithEvents Label5 As System.Windows.Forms.Label
 Friend WithEvents TxtCode As System.Windows.Forms.TextBox
 Friend WithEvents TxtAcctDB As System.Windows.Forms.TextBox
 Friend WithEvents Label2 As System.Windows.Forms.Label
 Friend WithEvents Label1 As System.Windows.Forms.Label
 Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
 Friend WithEvents Label4 As System.Windows.Forms.Label
 Friend WithEvents TxtAcctCR As System.Windows.Forms.TextBox
 Friend WithEvents Label3 As System.Windows.Forms.Label
 Friend WithEvents TxtTran As System.Windows.Forms.TextBox

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
    Me.TxtAcctDB = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtDesc = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtTran = New System.Windows.Forms.TextBox()
    Me.TxtAcctCR = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
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
    Me.TxtCode.Location = New System.Drawing.Point(167, 9)
    Me.TxtCode.MaxLength = 5
    Me.TxtCode.Name = "TxtCode"
    Me.TxtCode.Size = New System.Drawing.Size(51, 20)
    Me.TxtCode.TabIndex = 1
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(129, 9)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(32, 13)
    Me.Label5.TabIndex = 343
    Me.Label5.Text = "Code"
    '
    'TxtAcctDB
    '
    Me.TxtAcctDB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAcctDB.Location = New System.Drawing.Point(89, 72)
    Me.TxtAcctDB.MaxLength = 30
    Me.TxtAcctDB.Name = "TxtAcctDB"
    Me.TxtAcctDB.Size = New System.Drawing.Size(232, 20)
    Me.TxtAcctDB.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(8, 75)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(75, 13)
    Me.Label2.TabIndex = 344
    Me.Label2.Text = "Debit Account"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(10, 49)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(39, 20)
    Me.Label1.TabIndex = 351
    Me.Label1.Text = "Desc"
    '
    'TxtDesc
    '
    Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDesc.Location = New System.Drawing.Point(55, 46)
    Me.TxtDesc.MaxLength = 40
    Me.TxtDesc.Name = "TxtDesc"
    Me.TxtDesc.Size = New System.Drawing.Size(290, 20)
    Me.TxtDesc.TabIndex = 2
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(10, 9)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(29, 13)
    Me.Label4.TabIndex = 353
    Me.Label4.Text = "Tran"
    '
    'TxtTran
    '
    Me.TxtTran.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTran.Location = New System.Drawing.Point(55, 9)
    Me.TxtTran.MaxLength = 3
    Me.TxtTran.Name = "TxtTran"
    Me.TxtTran.Size = New System.Drawing.Size(36, 20)
    Me.TxtTran.TabIndex = 0
    '
    'TxtAcctCR
    '
    Me.TxtAcctCR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAcctCR.Location = New System.Drawing.Point(89, 98)
    Me.TxtAcctCR.MaxLength = 30
    Me.TxtAcctCR.Name = "TxtAcctCR"
    Me.TxtAcctCR.Size = New System.Drawing.Size(232, 20)
    Me.TxtAcctCR.TabIndex = 4
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(8, 101)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(77, 13)
    Me.Label3.TabIndex = 355
    Me.Label3.Text = "Credit Account"
    '
    'FrmGLA40C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(357, 135)
    Me.Controls.Add(Me.TxtAcctCR)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtTran)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtDesc)
    Me.Controls.Add(Me.TxtAcctDB)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtCode)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGLA40C"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region


  Private Sub FrmGLA40C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXGLEL = New TXGLEL.MyData()
    myTXGLEL.MyDBConn = myDBConnect
    LoadForm()
  End Sub
Private Sub LoadForm()
  MyFrmGLA40.TBarNew.Enabled = False
  MyFrmGLA40.TBarSave.Enabled = True
  MyFrmGLA40.TBarDelete.Enabled = True
  MyFrmGLA40.TBarPrint.Enabled = False

  myTXGLEL.GetOneRecordP(WrkTran, WrkCode)
  If myTXGLEL.RecordNotFound Then
    MyFrmGLA40.TBarDelete.Enabled = False
    Exit Sub
  End If

  With myTXGLEL
    MyUtils.SetTxtReadOnly(TxtTran)
    MyUtils.SetTxtReadOnly(TxtCode)
    TxtTran.Text = WrkTran
    TxtCode.Text = WrkCode
    TxtAcctDB.Text = Trim(._ACCTDB)
    TxtAcctCR.Text = Trim(._ACCTCR)
    TxtDesc.Text = Trim(._DESC)
  End With
End Sub
Private Sub FrmGLA40C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmGLA40.SbpScreen.Text = "GLA40C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub FrmGLA40C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmGLA40.TBarNew.Enabled = True
  MyFrmGLA40.TBarDelete.Enabled = False
  MyFrmGLA40.TBarSave.Enabled = False
  MyFrmGLA40.TBarNew.Enabled = True
  MyFrmGLA40.TBarPrint.Enabled = False
  MyFrmGLA40B.FormatGrid()
  MyFrmGLA40B.Show()
  'Memory Cleanup
  myTXGLEL = Nothing
  MyFrmGLA40C = Nothing
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If

  myTXGLEL.GetOneRecordP(TxtTran.text, TxtCode.Text)
  myTXGLEL.DeleteOneRecordP()
  Me.Close()
End Sub

Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String

  myTXGLEL.GetOneRecordP(TxtTran.text, TxtCode.Text)
  If WrkCode = String.Empty Then
    If Not myTXGLEL.RecordNotFound Then
      Me.ErrProv.SetError(TxtCode, "Record already exists")
      Exit Sub
    End If
  End If
  If Not myTXGLEL.RecordNotFound Then
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myTXGLEL.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  Else
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      With myTXGLEL
        ._TRAN = TxtTran.Text
        ._CODE = TxtCode.Text
      End With
      myTXGLEL.AddOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myTXGLEL
    ._ACCTCR = TxtAcctCR.Text
    ._ACCTDB = TxtAcctDB.Text
    ._DESC = TxtDesc.Text
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

    If TxtDesc.Text = String.Empty Then
      ErrorField(I) = "desc"
      ErrorMsg(I) = "Description is required"
      I = I + 1
    End If
  End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtCode, String.Empty)
  ErrProv.SetError(TxtDesc, String.Empty)
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
End Class
