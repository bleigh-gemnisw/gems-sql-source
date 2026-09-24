Public Class FrmUB108C
  Inherits System.Windows.Forms.Form
  Dim myUTTYPE As UTTYPE.myData
  Friend Wrktype As String
  Friend Wrktyuttp As String

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
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtdesc As System.Windows.Forms.TextBox
  Friend WithEvents Txttype As System.Windows.Forms.TextBox
  Friend WithEvents Txttxtp As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbUS As System.Windows.Forms.RadioButton
  Friend WithEvents RbMT As System.Windows.Forms.RadioButton
  Friend WithEvents RbAS As System.Windows.Forms.RadioButton
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Txttype = New System.Windows.Forms.TextBox()
    Me.txtdesc = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Txttxtp = New System.Windows.Forms.TextBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbUS = New System.Windows.Forms.RadioButton()
    Me.RbMT = New System.Windows.Forms.RadioButton()
    Me.RbAS = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(56, 24)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Rate Type"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Txttype
    '
    Me.Txttype.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.Txttype.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Txttype.Location = New System.Drawing.Point(72, 16)
    Me.Txttype.MaxLength = 2
    Me.Txttype.Name = "Txttype"
    Me.Txttype.Size = New System.Drawing.Size(24, 22)
    Me.Txttype.TabIndex = 0
    '
    'txtdesc
    '
    Me.txtdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtdesc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtdesc.Location = New System.Drawing.Point(72, 48)
    Me.txtdesc.MaxLength = 25
    Me.txtdesc.Name = "txtdesc"
    Me.txtdesc.Size = New System.Drawing.Size(288, 22)
    Me.txtdesc.TabIndex = 1
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(0, 48)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(64, 24)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "Description"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(16, 88)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(56, 24)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "Tax Type"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Txttxtp
    '
    Me.Txttxtp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.Txttxtp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Txttxtp.Location = New System.Drawing.Point(72, 88)
    Me.Txttxtp.MaxLength = 1
    Me.Txttxtp.Name = "Txttxtp"
    Me.Txttxtp.Size = New System.Drawing.Size(16, 22)
    Me.Txttxtp.TabIndex = 2
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbUS)
    Me.GroupBox1.Controls.Add(Me.RbMT)
    Me.GroupBox1.Controls.Add(Me.RbAS)
    Me.GroupBox1.Location = New System.Drawing.Point(72, 120)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(120, 72)
    Me.GroupBox1.TabIndex = 11
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Utility Type"
    '
    'RbUS
    '
    Me.RbUS.AutoSize = True
    Me.RbUS.Location = New System.Drawing.Point(8, 48)
    Me.RbUS.Name = "RbUS"
    Me.RbUS.Size = New System.Drawing.Size(56, 17)
    Me.RbUS.TabIndex = 13
    Me.RbUS.Text = "Usage"
    '
    'RbMT
    '
    Me.RbMT.AutoSize = True
    Me.RbMT.Location = New System.Drawing.Point(8, 32)
    Me.RbMT.Name = "RbMT"
    Me.RbMT.Size = New System.Drawing.Size(64, 17)
    Me.RbMT.TabIndex = 12
    Me.RbMT.Text = "Metered"
    '
    'RbAS
    '
    Me.RbAS.AutoSize = True
    Me.RbAS.Checked = True
    Me.RbAS.Location = New System.Drawing.Point(8, 16)
    Me.RbAS.Name = "RbAS"
    Me.RbAS.Size = New System.Drawing.Size(81, 17)
    Me.RbAS.TabIndex = 11
    Me.RbAS.TabStop = True
    Me.RbAS.Text = "Assessment"
    '
    'FrmUB108C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(376, 197)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Txttxtp)
    Me.Controls.Add(Me.txtdesc)
    Me.Controls.Add(Me.Txttype)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label1)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmUB108C"
    Me.Text = "Maintain Type Codes"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmUB108C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myUTTYPE = New UTTYPE.mydata(MyDBConnect)
    MyFrmUB108.TBarNew.Enabled = False
    MyFrmUB108.TBarSave.Enabled = True
    If Wrktype <> "" Then
      MyFrmUB108.TBarDelete.Enabled = True
      MyUtils.SetTxtReadOnly(Txttype)
    End If
    MyFrmUB108.TBarPrint.Enabled = False
    myUTTYPE.GetOneRecordP(Wrktype)
    Txttype.Text = Wrktype
    If myUTTYPE.RecordNotFound Then Exit Sub

    If s_chg = False And s_full = False Then    '#sec
      MyFrmUB108.TBarSave.Visible = False
    End If
    With myUTTYPE
      txtdesc.Text = Trim(._TYDESC)
      Txttxtp.Text = Trim(._TYTXTP)
      Wrktyuttp = "A"
      Select Case Trim(._TYUTTP)
        Case "A"
          RbAS.Checked = True
        Case "M"
          RbMT.Checked = True
        Case "U"
          RbUS.Checked = True
      End Select
    End With
  End Sub
  Private Sub FrmUB108C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmUB108.SbpScreen.Text = "UB108C"
    MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmUB108
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub FrmUB108C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmUB108.TBarNew.Enabled = True
    MyFrmUB108.TBarDelete.Enabled = False
    MyFrmUB108.TBarSave.Enabled = False
    MyFrmUB108.TBarPrint.Enabled = False
    MyFrmUB108.TBarSave.Visible = True   '#sec
    MyFrmUB108B.FormatGrid()
    MyFrmUB108B.Show()
  End Sub
  Public Sub DeleteData(ByRef WrkCancel As Boolean)
    Dim Answer As Integer

    WrkCancel = True
    Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
    If Answer = vbNo Then
      Exit Sub
    End If

    WrkCancel = False
    myUTTYPE.DeleteOneRecordP()
    Me.Close()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    myUTTYPE.GetOneRecordP(Txttype.Text)
    If Wrktype = "" Then
      If Not myUTTYPE.RecordNotFound Then
        Me.ErrProv.SetError(Txttype, "Record already exists")
        Exit Sub
      End If
    End If
    If Wrktype <> "" Then
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myUTTYPE.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      myUTTYPE._TYTYPE = Txttype.Text
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myUTTYPE.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()
  End Sub
  Private Sub MovetoFile()
    With myUTTYPE
      ._TYDESC = txtdesc.Text
      ._TYTXTP = Txttxtp.Text
      If RbAS.Checked = True Then ._TYUTTP = "A"
      If RbMT.Checked = True Then ._TYUTTP = "M"
      If RbUS.Checked = True Then ._TYUTTP = "U"
    End With
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If Txttype.Text = String.Empty Then
      ErrorField(I) = "tytype"
      ErrorMsg(I) = "Rate is required"
      I = I + 1
    End If
    If Txttxtp.Text = String.Empty Then
      ErrorField(I) = "tytxtp"
      ErrorMsg(I) = "Tax Type is required"
      I = I + 1
    End If
    If txtdesc.Text = String.Empty Then
      ErrorField(I) = "tydesc"
      ErrorMsg(I) = "Description is required"
      I = I + 1
    End If
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(Txttype, "")
    ErrProv.SetError(Txttxtp, "")
    ErrProv.SetError(txtdesc, "")
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "tytype"
          ErrProv.SetError(Txttype, ErrorMsg(I))
        Case "tytxtp"
          ErrProv.SetError(Txttxtp, ErrorMsg(I))
        Case "tydesc"
          ErrProv.SetError(txtdesc, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
End Class







