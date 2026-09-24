Public Class FrmTA202E
  Inherits System.Windows.Forms.Form
	Dim myTXLOCAL As TXLOCAL.myData
	Dim LoadScrn As Boolean

  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkType As String
  Friend WrkCode As String
  Friend WithEvents TxtCode As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtAmount As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents LblYear As Label
  Friend WithEvents Label5 As Label
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
Friend WithEvents LblListNo As System.Windows.Forms.Label
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents LblName As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.LblListNo = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.LblName = New System.Windows.Forms.Label()
    Me.TxtCode = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtAmount = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'LblListNo
    '
    Me.LblListNo.Location = New System.Drawing.Point(53, 8)
    Me.LblListNo.Name = "LblListNo"
    Me.LblListNo.Size = New System.Drawing.Size(48, 16)
    Me.LblListNo.TabIndex = 321
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 8)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(39, 16)
    Me.Label1.TabIndex = 320
    Me.Label1.Text = "List #"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LblName
    '
    Me.LblName.Location = New System.Drawing.Point(107, 9)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(280, 16)
    Me.LblName.TabIndex = 329
    Me.LblName.UseMnemonic = False
    '
    'TxtCode
    '
    Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode.Location = New System.Drawing.Point(156, 38)
    Me.TxtCode.MaxLength = 2
    Me.TxtCode.Name = "TxtCode"
    Me.TxtCode.Size = New System.Drawing.Size(20, 20)
    Me.TxtCode.TabIndex = 342
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(192, 42)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(48, 16)
    Me.Label3.TabIndex = 341
    Me.Label3.Text = "Amount"
    '
    'TxtAmount
    '
    Me.TxtAmount.Location = New System.Drawing.Point(248, 38)
    Me.TxtAmount.Name = "TxtAmount"
    Me.TxtAmount.Size = New System.Drawing.Size(48, 20)
    Me.TxtAmount.TabIndex = 340
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(118, 42)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(32, 16)
    Me.Label2.TabIndex = 339
    Me.Label2.Text = "Code"
    '
    'LblYear
    '
    Me.LblYear.Location = New System.Drawing.Point(57, 42)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(35, 16)
    Me.LblYear.TabIndex = 344
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(12, 42)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(39, 16)
    Me.Label5.TabIndex = 343
    Me.Label5.Text = "Year"
    '
    'FrmTA202E
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(397, 79)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtCode)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtAmount)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.LblName)
    Me.Controls.Add(Me.LblListNo)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA202E"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
    Me.Text = "Maintain Local Benefit"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

Private Sub FrmTA202E_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	myTXLOCAL = New TXLOCAL.mydata(MyDBConnect)

  LoadScrn = True
  MyFrmTA202.TBarSave.Enabled = True
  If Not AddMode Then MyFrmTA202.TBarDelete.Enabled = True

    LblListNo.Text = WrkListNo
    LblYear.Text = WrkYear
    LblName.Text = MyFrmTA202C.LblREName.Text

  'New record
  If s_chg = False And s_full = False Then  '#sec
    MyFrmTA202.TBarSave.Visible = False  '#sec
  End If  '#sec

  If Not AddMode Then
    MyUtils.SetTxtReadOnly(TxtCode)
    TxtCode.Text = WrkCode
  End If

    myTXLOCAL.GetOneRecordP(WrkListNo, WrkYear, WrkType, WrkCode)
    If Not myTXLOCAL.RecordNotFound Then
		With myTXLOCAL
			TxtAmount.Text = ._BENAMT
		End With
	End If

  LoadScrn = False
  End Sub
Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = True

    If MyLocEld = "032" Or MyLocEld = "045" Then
      Answer = MsgBox("WARNING: Note that if current or renewal year M35H local(s) are active" &
     " for list# then you should NOT delete them here.", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirm Local delete")
      If Answer = MsgBoxResult.Cancel Then Exit Sub
    End If

    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
		myTXLOCAL.DeleteOneRecordP()
    Me.Close()

End Sub
  Public Sub SaveData()
    Dim Answer As Integer
    Dim ErrorField(50) As String
    Dim ErrorMsg(50) As String

    If MyLocEld = "032" Or MyLocEld = "045" Then
      Answer = MsgBox("WARNING: Note that if current or renewal year M35H local(s) are active" &
     " for list# then you should NOT change them here.", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirm Local change")
      If Answer = MsgBoxResult.Cancel Then Exit Sub
      End If

    myTXLOCAL.GetOneRecordP(WrkListNo, WrkYear, WrkType, WrkCode)
    If Not myTXLOCAL.RecordNotFound Then
			If TxtAmount.Text = "" Then
				myTXLOCAL.DeleteOneRecordP()
			Else
				MoveToFile()
				EditChecks(ErrorField, ErrorMsg)
				If IsNothing(ErrorMsg(0)) Then
					myTXLOCAL.UpdateOneRecordP()
				Else
					ShowError(ErrorField, ErrorMsg)
					Exit Sub
				End If
			End If
		Else
			MoveToFile()
			EditChecks(ErrorField, ErrorMsg)
			If IsNothing(ErrorMsg(0)) Then
				myTXLOCAL.AddOneRecordP()
			Else
				ShowError(ErrorField, ErrorMsg)
				Exit Sub
			End If
		End If

    Me.Close()

  End Sub
  Private Sub MoveToFile()
    With myTXLOCAL
      If AddMode Then
        ._LISTNo = WrkListNo
        ._YEAR = WrkYear
        ._TYPE = WrkType
        ._BENCDE = WrkCode
      End If
      ._BENAMT = MyUtils.CnvSng(TxtAmount.Text)
    End With
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtCode, "")
    ErrProv.SetError(TxtAmount, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Me.ForeColor = Color.DarkRed
      Select Case ErrorField(I)
      Case "bencde"
        ErrProv.SetError(TxtCode, ErrorMsg(I))
      Case "benamt"
        ErrProv.SetError(TxtAmount, ErrorMsg(I))
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

    If TxtAmount.Text = "" Then
      ErrorField(I) = "bencde"
      ErrorMsg(I) = "Code is required"
      I = I + 1
    End If

    If TxtAmount.Text = "" Then
      ErrorField(I) = "benamt"
      ErrorMsg(I) = "Amount is required"
      I = I + 1
    End If
	End Sub
Private Sub FrmTA202E_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTA202.TBarSave.Enabled = False
    MyFrmTA202.TBarDelete.Enabled = False
    MyFrmTA202D.FormatGrid()
    MyFrmTA202D.Show()
End Sub
Private Sub FrmTA202E_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA202.SbpScreen.Text = "TA202E"
  MyUtils.CenterForm(Me.ParentForm, Me)
  With MyFrmTA202
    .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
    .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
  End With
End Sub
  Private Sub TxtAmount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAmount.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub

End Class






