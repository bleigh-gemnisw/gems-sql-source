Public Class FrmTA140C
  Inherits System.Windows.Forms.Form
  Dim myTXMSRPDEP As TXMSRPDEP.MyData
  Friend WrkDeyear As Decimal
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
  Friend WithEvents TxtDepct As System.Windows.Forms.TextBox
  Friend WithEvents TxtDeyear As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtDeyear = New System.Windows.Forms.TextBox()
    Me.TxtDepct = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(8, 15)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(97, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Depreciation Years"
    '
    'TxtDeyear
    '
    Me.TxtDeyear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDeyear.Location = New System.Drawing.Point(124, 12)
    Me.TxtDeyear.MaxLength = 2
    Me.TxtDeyear.Name = "TxtDeyear"
    Me.TxtDeyear.Size = New System.Drawing.Size(30, 20)
    Me.TxtDeyear.TabIndex = 0
    '
    'TxtDepct
    '
    Me.TxtDepct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDepct.Location = New System.Drawing.Point(124, 36)
    Me.TxtDepct.MaxLength = 3
    Me.TxtDepct.Name = "TxtDepct"
    Me.TxtDepct.Size = New System.Drawing.Size(30, 20)
    Me.TxtDepct.TabIndex = 1
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(8, 39)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(86, 13)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "Depreciation Pct"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'FrmTA140C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(268, 68)
    Me.Controls.Add(Me.TxtDepct)
    Me.Controls.Add(Me.TxtDeyear)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA140C"
    Me.Text = "Maintain MSRP Depreciation"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTA140C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXMSRPDEP = New TXMSRPDEP.MyData(myDBConnect)
    MyFrmTA140.TBarNew.Enabled = False
    MyFrmTA140.TBarSave.Enabled = True
    If WrkDeyear > 0 Then
      MyFrmTA140.TBarDelete.Enabled = True
      TxtDeyear.TabStop = False
      TxtDeyear.ReadOnly = True
    End If
    MyFrmTA140.TBarPrint.Enabled = False
    myTXMSRPDEP.GetOneRecordP(WrkDeyear)
    TxtDeyear.Text = WrkDeyear
    If myTXMSRPDEP.RecordNotFound Then Exit Sub

    If s_chg = False And s_full = False Then    '#sec
      MyFrmTA140.TBarSave.Visible = False
    End If
    With myTXMSRPDEP
      TxtDepct.Text = ._DEPCT
    End With
  End Sub
  Private Sub FrmTA140C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA140.SbpScreen.Text = "TA140C"
    MyUtils.CenterForm(Me.ParentForm, Me)
    If WrkDeyear > 0 Then
      TxtDeyear.ReadOnly = True
      TxtDepct.Focus()
    End If
  End Sub
  Private Sub FrmTA140C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTA140.TBarNew.Enabled = True
    MyFrmTA140.TBarDelete.Enabled = False
    MyFrmTA140.TBarSave.Enabled = False
    MyFrmTA140.TBarPrint.Enabled = False
    MyFrmTA140.TBarSave.Visible = True
    MyFrmTA140B.FormatGrid()
    MyFrmTA140B.Show()
  End Sub
  Public Sub DeleteData(ByRef WrkCancel As Boolean)
    Dim Answer As Integer
    WrkCancel = True
    Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
    If Answer = vbNo Then
      Exit Sub
    End If
    WrkCancel = False
    myTXMSRPDEP.DeleteOneRecordP()
    Me.Close()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    If TxtDeyear Is Nothing Then
      Me.ErrProv.SetError(TxtDeyear, "Percentage cannot be blank")
      Exit Sub
    End If
    myTXMSRPDEP.GetOneRecordP(MyUtils.CnvSng(TxtDeyear.Text))
    If WrkDeyear = 0 Then
      If Not myTXMSRPDEP.RecordNotFound Then
        Me.ErrProv.SetError(TxtDeyear, "Record already exists")
        Exit Sub
      End If
    End If
    If WrkDeyear > 0 Then
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXMSRPDEP.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      myTXMSRPDEP._DEYEAR = MyUtils.CnvSng(TxtDeyear.Text)
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXMSRPDEP.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()
  End Sub
  Private Sub MovetoFile()
    With myTXMSRPDEP
      ._DEPCT = MyUtils.CnvSng(TxtDepct.Text)
    End With
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtDeyear.Text) = 0 Then
      ErrorField(I) = "deyear"
      ErrorMsg(I) = "Year cannot be zero"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtDepct.Text) = 0 Then
      ErrorField(I) = "depct"
      ErrorMsg(I) = "Must enter either percentage or amount"
      I = I + 1
    End If

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtDeyear, "")
    ErrProv.SetError(TxtDepct, "")
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "deyear"
          ErrProv.SetError(TxtDeyear, ErrorMsg(I))
        Case "depct"
          ErrProv.SetError(TxtDepct, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub TxtDeyear_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDeyear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDepct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDepct.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
End Class

