Public Class FrmUB109C
  Inherits System.Windows.Forms.Form
	Dim myUTXREF As UTXREF.myData
	Friend WrkListNo As Integer
  Friend WrkName As String
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Friend WithEvents TxtUse As TextBox
  Friend WithEvents Label2 As Label
  Dim LoadScrn As Boolean
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
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents LblName As System.Windows.Forms.Label
  Friend WithEvents LblListNo As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtXref As System.Windows.Forms.TextBox
  Friend WithEvents BtnAdd As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.LblName = New System.Windows.Forms.Label()
    Me.LblListNo = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtXref = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.BtnAdd = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtUse = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox3.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.DataGrdView)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.ForeColor = System.Drawing.Color.Maroon
    Me.GroupBox3.Location = New System.Drawing.Point(79, 31)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(255, 268)
    Me.GroupBox3.TabIndex = 304
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Meter Numbers"
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DataGrdView.Location = New System.Drawing.Point(8, 19)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.Size = New System.Drawing.Size(241, 243)
    Me.DataGrdView.TabIndex = 20
    '
    'LblName
    '
    Me.LblName.Location = New System.Drawing.Point(132, 12)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(280, 16)
    Me.LblName.TabIndex = 332
    '
    'LblListNo
    '
    Me.LblListNo.Location = New System.Drawing.Point(76, 12)
    Me.LblListNo.Name = "LblListNo"
    Me.LblListNo.Size = New System.Drawing.Size(48, 16)
    Me.LblListNo.TabIndex = 331
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(12, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(56, 16)
    Me.Label1.TabIndex = 330
    Me.Label1.Text = "Account #"
    '
    'TxtXref
    '
    Me.TxtXref.Location = New System.Drawing.Point(79, 327)
    Me.TxtXref.MaxLength = 20
    Me.TxtXref.Name = "TxtXref"
    Me.TxtXref.Size = New System.Drawing.Size(155, 20)
    Me.TxtXref.TabIndex = 0
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(76, 308)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(48, 16)
    Me.Label3.TabIndex = 336
    Me.Label3.Text = "Meter #"
    '
    'BtnAdd
    '
    Me.BtnAdd.Location = New System.Drawing.Point(278, 326)
    Me.BtnAdd.Name = "BtnAdd"
    Me.BtnAdd.Size = New System.Drawing.Size(52, 20)
    Me.BtnAdd.TabIndex = 1
    Me.BtnAdd.Text = "Add"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(244, 308)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(32, 13)
    Me.Label2.TabIndex = 337
    Me.Label2.Text = "Use?"
    '
    'TxtUse
    '
    Me.TxtUse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUse.Location = New System.Drawing.Point(247, 327)
    Me.TxtUse.MaxLength = 1
    Me.TxtUse.Name = "TxtUse"
    Me.TxtUse.Size = New System.Drawing.Size(23, 20)
    Me.TxtUse.TabIndex = 338
    '
    'FrmUB109C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(425, 361)
    Me.Controls.Add(Me.TxtUse)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.BtnAdd)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtXref)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LblListNo)
    Me.Controls.Add(Me.LblName)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmUB109C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Meter Cross Reference"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox3.ResumeLayout(False)
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmUB109C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myUTXREF = New UTXREF.MyData(myDBConnect)

    LoadScrn = True
    MyFrmUB109.TBarSave.Enabled = False
    MyFrmUB109.TBarDelete.Enabled = False
    LblListNo.Text = WrkListNo
    LblName.Text = WrkName

    FormatGrid()
    LoadScrn = False
  End Sub
  Private Sub FrmUB109C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmUB109B.FormatGrid()
    MyFrmUB109B.Show()

  End Sub
  Public Sub SaveData()
    Dim ErrorField(50) As String
    Dim ErrorMsg(50) As String

    myUTXREF.GetOneRecordP(WrkListNo, "", TxtXref.Text)
    If myUTXREF.RecordNotFound Then
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myUTXREF.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    TxtXref.Text = ""
    TxtUse.Text = ""
    FormatGrid()
  End Sub
  Private Sub MoveToFile()
    With myUTXREF
      ._CXACCT = WrkListNo
      ._CXCODE = ""
      ._CXREF = Trim(TxtXref.Text)
      ._CXUSE = Trim(TxtUse.Text)
    End With

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtXref, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Me.ForeColor = Color.DarkRed
      Select Case ErrorField(I)
        Case "cxref"
          ErrProv.SetError(TxtXref, ErrorMsg(I))
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

    If TxtXref.Text = "" Then
      ErrorField(I) = "cxref"
      ErrorMsg(I) = "Meter number cannot be 0"
      I = I + 1
    End If

  End Sub
  Private Sub FrmUB109C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

    MyFrmUB109.SbpScreen.Text = "UB109C"
    MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmUB109
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Public Sub FormatGrid()
    Call ShowGrid()

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).Visible = False
      .Columns(1).Visible = False
      .Columns(2).HeaderText = "Meter #"
      .Columns(2).Width = 165
      .Columns(3).HeaderText = "Use"
      .Columns(3).Width = 40
    End With

  End Sub
  Public Sub ShowGrid()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    Dim ds As DataSet = New DataSet

    ds = myUTXREF.GetAllAcct(WrkListNo, "")
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    MyFrmUB109D = New FrmUB109D
    MyFrmUB109D.WrkListNo = WrkListNo
    MyFrmUB109D.WrkCode = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
    MyFrmUB109D.WrkXRef = DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value
    MyFrmUB109D.WrkUse = DataGrdView.Item(3, DataGrdView.CurrentRow.Index).Value
    MyFrmUB109D.MdiParent = Me.ParentForm
    MyFrmUB109D.Show()
    Me.Hide()
  End Sub
  Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
    SaveData()
  End Sub

  Private Sub DataGrdView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrdView.CellContentClick

  End Sub
End Class






