Public Class FrmBD100C
  Inherits System.Windows.Forms.Form
  Dim myBDRATE As BDRATE.myData
  Friend WrkType As String
  Friend WithEvents TxtTier As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtCert As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TxtPer As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
  Friend WithEvents TxtPermit As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WrkTier As Integer
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
Friend WithEvents TxtType As System.Windows.Forms.TextBox
Friend WithEvents TxtRate As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.TxtRate = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtTier = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtPer = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtCert = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtDesc = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtPermit = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(24, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 24)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Type"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtType.Location = New System.Drawing.Point(72, 16)
    Me.TxtType.MaxLength = 5
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(52, 22)
    Me.TxtType.TabIndex = 0
    '
    'TxtRate
    '
    Me.TxtRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRate.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRate.Location = New System.Drawing.Point(72, 70)
    Me.TxtRate.MaxLength = 8
    Me.TxtRate.Multiline = True
    Me.TxtRate.Name = "TxtRate"
    Me.TxtRate.Size = New System.Drawing.Size(63, 24)
    Me.TxtRate.TabIndex = 3
    Me.TxtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(27, 70)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(37, 24)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "Rate"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtTier
    '
    Me.TxtTier.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTier.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTier.Location = New System.Drawing.Point(196, 16)
    Me.TxtTier.MaxLength = 7
    Me.TxtTier.Name = "TxtTier"
    Me.TxtTier.Size = New System.Drawing.Size(73, 22)
    Me.TxtTier.TabIndex = 1
    Me.TxtTier.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(148, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(40, 24)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "Tier"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtPer
    '
    Me.TxtPer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPer.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPer.Location = New System.Drawing.Point(196, 70)
    Me.TxtPer.MaxLength = 6
    Me.TxtPer.Multiline = True
    Me.TxtPer.Name = "TxtPer"
    Me.TxtPer.Size = New System.Drawing.Size(63, 24)
    Me.TxtPer.TabIndex = 4
    Me.TxtPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(151, 70)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(37, 24)
    Me.Label4.TabIndex = 7
    Me.Label4.Text = "Per"
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtCert
    '
    Me.TxtCert.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCert.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCert.Location = New System.Drawing.Point(72, 100)
    Me.TxtCert.MaxLength = 8
    Me.TxtCert.Multiline = True
    Me.TxtCert.Name = "TxtCert"
    Me.TxtCert.Size = New System.Drawing.Size(63, 24)
    Me.TxtCert.TabIndex = 5
    Me.TxtCert.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(14, 104)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(52, 13)
    Me.Label5.TabIndex = 9
    Me.Label5.Text = "Cert Rate"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtDesc
    '
    Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDesc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDesc.Location = New System.Drawing.Point(72, 44)
    Me.TxtDesc.MaxLength = 40
    Me.TxtDesc.Name = "TxtDesc"
    Me.TxtDesc.Size = New System.Drawing.Size(335, 22)
    Me.TxtDesc.TabIndex = 2
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(4, 48)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(60, 13)
    Me.Label6.TabIndex = 11
    Me.Label6.Text = "Description"
    Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtPermit
    '
    Me.TxtPermit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPermit.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPermit.Location = New System.Drawing.Point(72, 130)
    Me.TxtPermit.MaxLength = 1
    Me.TxtPermit.Name = "TxtPermit"
    Me.TxtPermit.Size = New System.Drawing.Size(19, 22)
    Me.TxtPermit.TabIndex = 12
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(7, 130)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(57, 24)
    Me.Label7.TabIndex = 13
    Me.Label7.Text = "Big Letter"
    Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'FrmBD100C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(416, 158)
    Me.Controls.Add(Me.TxtPermit)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.TxtDesc)
    Me.Controls.Add(Me.TxtCert)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtPer)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtTier)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtRate)
    Me.Controls.Add(Me.TxtType)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmBD100C"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmBD100C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myBDRATE = New BDRATE.mydata(MyDBConnect)
  MyFrmBD100.TBarNew.Enabled = False
  MyFrmBD100.TBarSave.Enabled = True
  If WrkType <> "" Then
    MyFrmBD100.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(TxtType)
    MyUtils.SetTxtReadOnly(TxtTier)
  End If
  MyFrmBD100.TBarPrint.Enabled = False
  myBDRATE.GetOneRecordP(WrkType, WrkTier)
  TxtType.Text = WrkType
  TxtTier.Text = WrkTier
  If myBDRATE.RecordNotFound Then Exit Sub

  If s_chg = False And s_full = False Then    '#sec
    MyFrmBD100.TBarSave.Visible = False
  End If
  With myBDRATE
    TxtDesc.Text = Trim(._DESC)
    TxtRate.Text = ._RATE
    TxtPer.Text = ._PER
    TxtCert.Text = ._CERT
    TxtPermit.Text = Trim(._PERMIT)
  End With
End Sub
Private Sub FrmBD100C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmBD100.SbpScreen.Text = "BD100C"
  MyUtils.CenterForm(Me.ParentForm, Me)
  With MyFrmBD100
    .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
    .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
  End With
End Sub
Private Sub FrmBD100C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmBD100.TBarNew.Enabled = True
  MyFrmBD100.TBarDelete.Enabled = False
  MyFrmBD100.TBarSave.Enabled = False
  MyFrmBD100.TBarPrint.Enabled = False
  MyFrmBD100.TBarSave.Visible = True   '#sec
  MyFrmBD100B.FormatGrid()
  MyFrmBD100B.Show()
End Sub
Public Sub DeleteData(ByRef WrkCancel As Boolean)
  Dim Answer As Integer
  WrkCancel = True
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
  WrkCancel = False
  myBDRATE.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  myBDRATE.GetOneRecordP(TxtType.Text, MyUtils.CnvSng(TxtTier.Text))
  If WrkType = "" Then
    If Not myBDRATE.RecordNotFound Then
      Me.ErrProv.SetError(TxtType, "Record already exists")
      Exit Sub
    End If
  End If
  If WrkType <> "" Then
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myBDRATE.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  Else
    myBDRATE._TYPE = TxtType.Text
    myBDRATE._TIER = MyUtils.CnvSng(TxtTier.Text)
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myBDRATE.AddOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myBDRATE
    ._DESC = Trim(TxtDesc.Text)
    ._RATE = MyUtils.CnvSng(TxtRate.Text)
    ._PER = MyUtils.CnvSng(TxtPer.Text)
    ._CERT = MyUtils.CnvSng(TxtCert.Text)
    ._PERMIT = Trim(TxtPermit.Text)
  End With
End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If TxtType.Text = String.Empty Then
      ErrorField(I) = "type"
      ErrorMsg(I) = "Type is required"
      I = I + 1
    End If
    If MyUtils.CnvSng(TxtTier.Text) = 0 Then
      ErrorField(I) = "tier"
      ErrorMsg(I) = "Tier is required"
      I = I + 1
    End If
  End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtType, "")
  ErrProv.SetError(TxtTier, "")
  ErrProv.SetError(TxtRate, "")
  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
    Case "type"
      ErrProv.SetError(TxtType, ErrorMsg(I))
    Case "tier"
      ErrProv.SetError(TxtTier, ErrorMsg(I))
    Case "rate"
      ErrProv.SetError(TxtRate, ErrorMsg(I))
    Case Nothing
      Exit Sub
    End Select
  Next I
End Sub
Private Sub TxtTier_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTier.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtRate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRate.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtPer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPer.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtCert_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCert.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
End Class







