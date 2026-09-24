Public Class FrmUB109D
  Inherits System.Windows.Forms.Form
  Dim myUTXREF As UTXREF.MyData
  Dim LoadScrn As Boolean

  Friend WrkListNo As Integer
  Friend WrkCode As String
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents LblXref As System.Windows.Forms.Label
  Friend WithEvents Label2 As Label
  Friend WrkXRef As String
  Friend WithEvents TxtUse As TextBox
  Friend WrkUse As String

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
    Me.Label3 = New System.Windows.Forms.Label()
    Me.LblXref = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtUse = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'LblListNo
    '
    Me.LblListNo.Location = New System.Drawing.Point(72, 8)
    Me.LblListNo.Name = "LblListNo"
    Me.LblListNo.Size = New System.Drawing.Size(48, 16)
    Me.LblListNo.TabIndex = 321
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 8)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(56, 16)
    Me.Label1.TabIndex = 320
    Me.Label1.Text = "Account #"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LblName
    '
    Me.LblName.Location = New System.Drawing.Point(128, 8)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(280, 16)
    Me.LblName.TabIndex = 329
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(12, 36)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(48, 16)
    Me.Label3.TabIndex = 338
    Me.Label3.Text = "Meter #"
    '
    'LblXref
    '
    Me.LblXref.Location = New System.Drawing.Point(66, 36)
    Me.LblXref.Name = "LblXref"
    Me.LblXref.Size = New System.Drawing.Size(149, 16)
    Me.LblXref.TabIndex = 339
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(221, 36)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(31, 16)
    Me.Label2.TabIndex = 340
    Me.Label2.Text = "Use"
    '
    'TxtUse
    '
    Me.TxtUse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUse.Location = New System.Drawing.Point(258, 33)
    Me.TxtUse.MaxLength = 1
    Me.TxtUse.Name = "TxtUse"
    Me.TxtUse.Size = New System.Drawing.Size(23, 20)
    Me.TxtUse.TabIndex = 341
    '
    'FrmUB109D
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(425, 69)
    Me.ControlBox = False
    Me.Controls.Add(Me.TxtUse)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.LblXref)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.LblName)
    Me.Controls.Add(Me.LblListNo)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmUB109D"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmUB109D_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myUTXREF = New UTXREF.MyData(myDBConnect)

    LoadScrn = True
    MyFrmUB109.TBarSave.Enabled = True
    MyFrmUB109.TBarDelete.Enabled = True

    LblListNo.Text = WrkListNo
    LblName.Text = MyFrmUB109C.LblName.Text
    LblXref.Text = WrkXRef
    TxtUse.Text = WrkUse
    LoadScrn = False
  End Sub
  Public Sub SaveData()
    myUTXREF.GetOneRecordP(WrkListNo, "", WrkXRef)
    myUTXREF._CXUSE = TxtUse.Text
    myUTXREF.UpdateOneRecordP()
    Me.Close()
  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer

    myUTXREF.GetOneRecordP(WrkListNo, WrkCode, WrkXRef)
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    myUTXREF.DeleteOneRecordP()
    Me.Close()

  End Sub
  Private Sub FrmUB109D_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmUB109.TBarSave.Enabled = False
    MyFrmUB109.TBarDelete.Enabled = False
    MyFrmUB109C.FormatGrid()
    MyFrmUB109C.Show()
  End Sub
  Private Sub FrmUB109D_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmUB109.SbpScreen.Text = "UB109D"
    MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmUB109
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
End Class






