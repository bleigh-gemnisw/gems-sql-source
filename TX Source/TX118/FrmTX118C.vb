Public Class FrmTX118C
  Inherits System.Windows.Forms.Form
  Dim myTXPAYID As TXPAYID.myData
  Friend WrkCode As String
  Friend AddMode As Boolean

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
  Friend WithEvents TxtProdID As System.Windows.Forms.TextBox
  Friend WithEvents TxtCode As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtCode = New System.Windows.Forms.TextBox()
    Me.TxtProdID = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(56, 22)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Tax Type"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtCode
    '
    Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCode.Location = New System.Drawing.Point(72, 16)
    Me.TxtCode.MaxLength = 2
    Me.TxtCode.Name = "TxtCode"
    Me.TxtCode.Size = New System.Drawing.Size(24, 22)
    Me.TxtCode.TabIndex = 0
    '
    'TxtProdID
    '
    Me.TxtProdID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtProdID.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtProdID.Location = New System.Drawing.Point(72, 48)
    Me.TxtProdID.MaxLength = 7
    Me.TxtProdID.Name = "TxtProdID"
    Me.TxtProdID.Size = New System.Drawing.Size(77, 22)
    Me.TxtProdID.TabIndex = 1
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(0, 48)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(64, 24)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "Product ID"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'FrmTX118C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(267, 90)
    Me.Controls.Add(Me.TxtProdID)
    Me.Controls.Add(Me.TxtCode)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label1)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX118C"
    Me.Text = "Maintain Product IDs"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTX118C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXPAYID = New TXPAYID.mydata(MyDBConnect)
    MyFrmTX118.TBarNew.Enabled = False
    MyFrmTX118.TBarSave.Enabled = True
    MyFrmTX118.TBarPrint.Enabled = False
    myTXPAYID.GetOneRecordP(WrkCode)
    TxtCode.Text = WrkCode
    If myTXPAYID.RecordNotFound Then Exit Sub

    If s_chg = False And s_full = False Then    '#sec
      MyFrmTX118.TBarSave.Visible = False
    End If
    If Not AddMode Then
      MyFrmTX118.TBarDelete.Enabled = True
      MyUtils.SetTxtReadOnly(TxtCode)
      With myTXPAYID
        TxtProdID.Text = Trim(._PRODID)
      End With
    End If
  End Sub
  Private Sub FrmTX118C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTX118.SbpScreen.Text = "TX118C"
    MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmTX118
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub FrmTX118C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTX118.TBarNew.Enabled = True
    MyFrmTX118.TBarDelete.Enabled = False
    MyFrmTX118.TBarSave.Enabled = False
    MyFrmTX118.TBarPrint.Enabled = False
    MyFrmTX118.TBarSave.Visible = True   '#sec
    MyFrmTX118B.FormatGrid()
    MyFrmTX118B.Show()
  End Sub
  Public Sub DeleteData(ByRef WrkCancel As Boolean)
    Dim Answer As Integer

    WrkCancel = True
    Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
    If Answer = vbNo Then
      Exit Sub
    End If

    WrkCancel = False
    myTXPAYID.DeleteOneRecordP()
    Me.Close()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    myTXPAYID.GetOneRecordP(TxtCode.Text)
    If AddMode And Not myTXPAYID.RecordNotFound Then
      Me.ErrProv.SetError(TxtCode, "Record already exists")
      Exit Sub
    End If
    If Not AddMode Then
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXPAYID.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      myTXPAYID._TYPE = TxtCode.Text
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXPAYID.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()
  End Sub
  Private Sub MovetoFile()
    With myTXPAYID
      ._PRODID = MyUtils.CnvSng(TxtProdID.Text)
    End With
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtProdID.Text) = 0 Then
      ErrorField(I) = "prodid"
      ErrorMsg(I) = "Product ID is required"
      I = I + 1
    End If
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtProdID, "")
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "prodid"
          ErrProv.SetError(TxtProdID, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
End Class







