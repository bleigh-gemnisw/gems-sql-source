Public Class FrmPK111C
  Inherits System.Windows.Forms.Form
  Dim myPKOFCR As PKOFCR.MyData
  Friend WrkCode As String
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtCode As System.Windows.Forms.TextBox
  Friend WithEvents LblDeleted As System.Windows.Forms.Label
  Friend WrkAddMode As Boolean

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
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtCode = New System.Windows.Forms.TextBox()
    Me.LblDeleted = New System.Windows.Forms.Label()
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
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(15, 39)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(35, 13)
    Me.Label2.TabIndex = 9
    Me.Label2.Text = "Name"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Location = New System.Drawing.Point(83, 36)
    Me.TxtName.MaxLength = 20
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(229, 20)
    Me.TxtName.TabIndex = 8
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(12, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(36, 16)
    Me.Label1.TabIndex = 7
    Me.Label1.Text = "Code"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtCode
    '
    Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode.Location = New System.Drawing.Point(83, 9)
    Me.TxtCode.MaxLength = 4
    Me.TxtCode.Name = "TxtCode"
    Me.TxtCode.Size = New System.Drawing.Size(41, 20)
    Me.TxtCode.TabIndex = 6
    '
    'LblDeleted
    '
    Me.LblDeleted.AutoSize = True
    Me.LblDeleted.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDeleted.Location = New System.Drawing.Point(235, 9)
    Me.LblDeleted.Name = "LblDeleted"
    Me.LblDeleted.Size = New System.Drawing.Size(78, 16)
    Me.LblDeleted.TabIndex = 10
    Me.LblDeleted.Text = "DELETED"
    '
    'FrmPK111C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(325, 71)
    Me.Controls.Add(Me.LblDeleted)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtName)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtCode)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmPK111C"
    Me.Text = "Maintain Officer"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmPK111C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myPKOFCR = New PKOFCR.MyData(myDBConnect)
    MyFrmPK111.TBarNew.Enabled = False
    MyFrmPK111.TBarSave.Enabled = True
    LblDeleted.Visible = False
    If Not WrkAddMode Then
      MyUtils.SetTxtReadOnly(TxtCode)
    Else
      Exit Sub
    End If

    MyFrmPK111.TBarPrint.Enabled = False
    myPKOFCR.GetOneRecordP(WrkCode)
    TxtCode.Text = WrkCode
    If myPKOFCR.RecordNotFound Then Exit Sub
    With myPKOFCR
      TxtName.Text = Trim(._OFNAM)
      If ._DELETT = "Y" Then
        LblDeleted.Visible = True
        MyUtils.SetTxtReadOnly(TxtName)
        MyFrmPK111.TBarSave.Enabled = False
      Else
        MyFrmPK111.TBarDelete.Enabled = True
      End If
    End With
  End Sub

  Private Sub FrmPK111C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmPK111.SbpScreen.Text = "PK111C"
    MyUtils.CenterForm(Me.ParentForm, Me)
    If WrkCode <> "" Then
    End If
  End Sub

  Private Sub FrmPK111C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmPK111.TBarNew.Enabled = True
    MyFrmPK111.TBarDelete.Enabled = False
    MyFrmPK111.TBarSave.Enabled = False
    MyFrmPK111.TBarPrint.Enabled = False
    MyFrmPK111B.FormatGrid()
    MyFrmPK111B.Show()
  End Sub
  Public Sub DeleteData()
    Dim Answer As Integer
    Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
    If Answer = vbNo Then
      Exit Sub
    End If
    With myPKOFCR
      .GetOneRecordP(TxtCode.Text)
      ._DELETT = "Y"
      .UpdateOneRecordP()
    End With
    Me.Close()
  End Sub

  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    myPKOFCR.GetOneRecordP(TxtCode.Text)
    If WrkAddMode Then
      If Not myPKOFCR.RecordNotFound Then
        Me.ErrProv.SetError(TxtCode, "Record already exists")
        Exit Sub
      End If
    End If
    If Not WrkAddMode Then
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myPKOFCR.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      myPKOFCR._OFNUM = TxtCode.Text
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myPKOFCR.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()
  End Sub
  Private Sub MovetoFile()
    With myPKOFCR
      ._OFNAM = TxtName.Text
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

    If TxtName.Text = String.Empty Then
      ErrorField(I) = "name"
      ErrorMsg(I) = "Name is required"
      I = I + 1
    End If
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtCode, "")
    ErrProv.SetError(TxtName, "")
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "code"
          ErrProv.SetError(TxtCode, ErrorMsg(I))
        Case "name"
          ErrProv.SetError(TxtName, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
End Class
