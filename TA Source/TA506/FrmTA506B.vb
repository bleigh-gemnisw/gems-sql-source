Imports System.Data
Public Class FrmTA506B
  Inherits System.Windows.Forms.Form

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
  Friend WithEvents BtnRefresh As System.Windows.Forms.Button
  Friend WithEvents LnkClass As System.Windows.Forms.LinkLabel
	Friend WithEvents TxtFindClass As System.Windows.Forms.TextBox
	Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
	Friend WithEvents TxtFindMake As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents RbValue As System.Windows.Forms.RadioButton
	Friend WithEvents RbBookValue As System.Windows.Forms.RadioButton
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents BtnFast As System.Windows.Forms.Button
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents GrpMV As System.Windows.Forms.GroupBox
	Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
	Friend WithEvents TxtName As System.Windows.Forms.TextBox
	Friend WithEvents Label19 As System.Windows.Forms.Label
	Friend WithEvents Label20 As System.Windows.Forms.Label
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents TxtMinValue As System.Windows.Forms.TextBox
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents TxtBookPct As System.Windows.Forms.TextBox
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents TxtBookValue As System.Windows.Forms.TextBox
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents TxtRegno As System.Windows.Forms.TextBox
	Friend WithEvents TxtVIN As System.Windows.Forms.TextBox
	Friend WithEvents TxtClass As System.Windows.Forms.TextBox
	Friend WithEvents TxtYear As System.Windows.Forms.TextBox
	Friend WithEvents TxtModel As System.Windows.Forms.TextBox
	Friend WithEvents TxtValue As System.Windows.Forms.TextBox
	Friend WithEvents TxtMake As System.Windows.Forms.TextBox
	Friend WithEvents Label18 As System.Windows.Forms.Label
	Friend WithEvents Label17 As System.Windows.Forms.Label
	Friend WithEvents Label16 As System.Windows.Forms.Label
	Friend WithEvents Label15 As System.Windows.Forms.Label
	Friend WithEvents Label13 As System.Windows.Forms.Label
	Friend WithEvents Label12 As System.Windows.Forms.Label
	Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents DataGrdView As DataGridView
  Friend WithEvents TxtFindListNo As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.BtnRefresh = New System.Windows.Forms.Button()
    Me.LnkClass = New System.Windows.Forms.LinkLabel()
    Me.TxtFindClass = New System.Windows.Forms.TextBox()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.TxtFindMake = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.RbValue = New System.Windows.Forms.RadioButton()
    Me.RbBookValue = New System.Windows.Forms.RadioButton()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.BtnFast = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtFindListNo = New System.Windows.Forms.TextBox()
    Me.GrpMV = New System.Windows.Forms.GroupBox()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtMinValue = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtBookPct = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtBookValue = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtRegno = New System.Windows.Forms.TextBox()
    Me.TxtVIN = New System.Windows.Forms.TextBox()
    Me.TxtClass = New System.Windows.Forms.TextBox()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.TxtModel = New System.Windows.Forms.TextBox()
    Me.TxtValue = New System.Windows.Forms.TextBox()
    Me.TxtMake = New System.Windows.Forms.TextBox()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.GroupBox2.SuspendLayout()
    Me.GrpMV.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'BtnRefresh
    '
    Me.BtnRefresh.Location = New System.Drawing.Point(249, 12)
    Me.BtnRefresh.Name = "BtnRefresh"
    Me.BtnRefresh.Size = New System.Drawing.Size(53, 24)
    Me.BtnRefresh.TabIndex = 2
    Me.BtnRefresh.Text = "Refresh"
    '
    'LnkClass
    '
    Me.LnkClass.AutoSize = True
    Me.LnkClass.Location = New System.Drawing.Point(12, 18)
    Me.LnkClass.Name = "LnkClass"
    Me.LnkClass.Size = New System.Drawing.Size(32, 13)
    Me.LnkClass.TabIndex = 198
    Me.LnkClass.TabStop = True
    Me.LnkClass.Text = "Class"
    '
    'TxtFindClass
    '
    Me.TxtFindClass.Location = New System.Drawing.Point(50, 15)
    Me.TxtFindClass.MaxLength = 2
    Me.TxtFindClass.Name = "TxtFindClass"
    Me.TxtFindClass.Size = New System.Drawing.Size(25, 20)
    Me.TxtFindClass.TabIndex = 0
    '
    'TxtFindMake
    '
    Me.TxtFindMake.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFindMake.Location = New System.Drawing.Point(152, 15)
    Me.TxtFindMake.MaxLength = 5
    Me.TxtFindMake.Name = "TxtFindMake"
    Me.TxtFindMake.Size = New System.Drawing.Size(66, 20)
    Me.TxtFindMake.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(107, 18)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(34, 13)
    Me.Label1.TabIndex = 200
    Me.Label1.Text = "Make"
    '
    'RbValue
    '
    Me.RbValue.AutoSize = True
    Me.RbValue.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbValue.Checked = True
    Me.RbValue.Location = New System.Drawing.Point(353, 11)
    Me.RbValue.Name = "RbValue"
    Me.RbValue.Size = New System.Drawing.Size(71, 17)
    Me.RbValue.TabIndex = 201
    Me.RbValue.TabStop = True
    Me.RbValue.Text = "Full Value"
    Me.RbValue.UseVisualStyleBackColor = True
    '
    'RbBookValue
    '
    Me.RbBookValue.AutoSize = True
    Me.RbBookValue.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbBookValue.Location = New System.Drawing.Point(344, 28)
    Me.RbBookValue.Name = "RbBookValue"
    Me.RbBookValue.Size = New System.Drawing.Size(80, 17)
    Me.RbBookValue.TabIndex = 202
    Me.RbBookValue.Text = "Book Value"
    Me.RbBookValue.UseVisualStyleBackColor = True
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.BtnFast)
    Me.GroupBox2.Controls.Add(Me.Label2)
    Me.GroupBox2.Controls.Add(Me.TxtFindListNo)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(555, 3)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(179, 42)
    Me.GroupBox2.TabIndex = 205
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Fast Path"
    '
    'BtnFast
    '
    Me.BtnFast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFast.Location = New System.Drawing.Point(109, 13)
    Me.BtnFast.Name = "BtnFast"
    Me.BtnFast.Size = New System.Drawing.Size(53, 24)
    Me.BtnFast.TabIndex = 3
    Me.BtnFast.Text = "S&how"
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(8, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(32, 16)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "List#"
    '
    'TxtFindListNo
    '
    Me.TxtFindListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFindListNo.Location = New System.Drawing.Point(40, 16)
    Me.TxtFindListNo.MaxLength = 7
    Me.TxtFindListNo.Name = "TxtFindListNo"
    Me.TxtFindListNo.Size = New System.Drawing.Size(63, 20)
    Me.TxtFindListNo.TabIndex = 1
    '
    'GrpMV
    '
    Me.GrpMV.Controls.Add(Me.TxtListNo)
    Me.GrpMV.Controls.Add(Me.TxtName)
    Me.GrpMV.Controls.Add(Me.Label19)
    Me.GrpMV.Controls.Add(Me.Label20)
    Me.GrpMV.Controls.Add(Me.Label7)
    Me.GrpMV.Controls.Add(Me.Label6)
    Me.GrpMV.Controls.Add(Me.TxtMinValue)
    Me.GrpMV.Controls.Add(Me.Label4)
    Me.GrpMV.Controls.Add(Me.TxtBookPct)
    Me.GrpMV.Controls.Add(Me.Label3)
    Me.GrpMV.Controls.Add(Me.TxtBookValue)
    Me.GrpMV.Controls.Add(Me.Label5)
    Me.GrpMV.Controls.Add(Me.TxtRegno)
    Me.GrpMV.Controls.Add(Me.TxtVIN)
    Me.GrpMV.Controls.Add(Me.TxtClass)
    Me.GrpMV.Controls.Add(Me.TxtYear)
    Me.GrpMV.Controls.Add(Me.TxtModel)
    Me.GrpMV.Controls.Add(Me.TxtValue)
    Me.GrpMV.Controls.Add(Me.TxtMake)
    Me.GrpMV.Controls.Add(Me.Label18)
    Me.GrpMV.Controls.Add(Me.Label17)
    Me.GrpMV.Controls.Add(Me.Label16)
    Me.GrpMV.Controls.Add(Me.Label15)
    Me.GrpMV.Controls.Add(Me.Label13)
    Me.GrpMV.Controls.Add(Me.Label12)
    Me.GrpMV.Controls.Add(Me.Label10)
    Me.GrpMV.Location = New System.Drawing.Point(123, 279)
    Me.GrpMV.Name = "GrpMV"
    Me.GrpMV.Size = New System.Drawing.Size(524, 139)
    Me.GrpMV.TabIndex = 240
    Me.GrpMV.TabStop = False
    '
    'TxtListNo
    '
    Me.TxtListNo.Location = New System.Drawing.Point(67, 17)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(64, 20)
    Me.TxtListNo.TabIndex = 269
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Location = New System.Drawing.Point(210, 16)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(280, 20)
    Me.TxtName.TabIndex = 270
    '
    'Label19
    '
    Me.Label19.Location = New System.Drawing.Point(6, 16)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(40, 16)
    Me.Label19.TabIndex = 272
    Me.Label19.Text = "List No"
    '
    'Label20
    '
    Me.Label20.Location = New System.Drawing.Point(161, 17)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(48, 16)
    Me.Label20.TabIndex = 271
    Me.Label20.Text = "Name"
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(156, 63)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(35, 17)
    Me.Label7.TabIndex = 262
    Me.Label7.Text = "- OR -"
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(207, 44)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(64, 13)
    Me.Label6.TabIndex = 261
    Me.Label6.Text = "Min Value"
    '
    'TxtMinValue
    '
    Me.TxtMinValue.Location = New System.Drawing.Point(207, 60)
    Me.TxtMinValue.MaxLength = 9
    Me.TxtMinValue.Name = "TxtMinValue"
    Me.TxtMinValue.Size = New System.Drawing.Size(44, 20)
    Me.TxtMinValue.TabIndex = 241
    Me.TxtMinValue.TabStop = False
    Me.TxtMinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(93, 44)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(71, 13)
    Me.Label4.TabIndex = 260
    Me.Label4.Text = "Percentage"
    '
    'TxtBookPct
    '
    Me.TxtBookPct.Location = New System.Drawing.Point(106, 60)
    Me.TxtBookPct.MaxLength = 9
    Me.TxtBookPct.Name = "TxtBookPct"
    Me.TxtBookPct.Size = New System.Drawing.Size(37, 20)
    Me.TxtBookPct.TabIndex = 240
    Me.TxtBookPct.TabStop = False
    Me.TxtBookPct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(76, 63)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(14, 17)
    Me.Label3.TabIndex = 259
    Me.Label3.Text = "X"
    '
    'TxtBookValue
    '
    Me.TxtBookValue.Location = New System.Drawing.Point(6, 60)
    Me.TxtBookValue.MaxLength = 9
    Me.TxtBookValue.Name = "TxtBookValue"
    Me.TxtBookValue.Size = New System.Drawing.Size(64, 20)
    Me.TxtBookValue.TabIndex = 239
    Me.TxtBookValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(6, 44)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(64, 13)
    Me.Label5.TabIndex = 258
    Me.Label5.Text = "Book Value"
    '
    'TxtRegno
    '
    Me.TxtRegno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRegno.Location = New System.Drawing.Point(389, 113)
    Me.TxtRegno.MaxLength = 8
    Me.TxtRegno.Name = "TxtRegno"
    Me.TxtRegno.Size = New System.Drawing.Size(72, 20)
    Me.TxtRegno.TabIndex = 249
    '
    'TxtVIN
    '
    Me.TxtVIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVIN.Location = New System.Drawing.Point(269, 113)
    Me.TxtVIN.MaxLength = 17
    Me.TxtVIN.Name = "TxtVIN"
    Me.TxtVIN.Size = New System.Drawing.Size(120, 20)
    Me.TxtVIN.TabIndex = 248
    '
    'TxtClass
    '
    Me.TxtClass.Location = New System.Drawing.Point(237, 113)
    Me.TxtClass.MaxLength = 2
    Me.TxtClass.Name = "TxtClass"
    Me.TxtClass.Size = New System.Drawing.Size(28, 20)
    Me.TxtClass.TabIndex = 247
    '
    'TxtYear
    '
    Me.TxtYear.Location = New System.Drawing.Point(197, 113)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(40, 20)
    Me.TxtYear.TabIndex = 246
    '
    'TxtModel
    '
    Me.TxtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtModel.Location = New System.Drawing.Point(123, 113)
    Me.TxtModel.MaxLength = 8
    Me.TxtModel.Name = "TxtModel"
    Me.TxtModel.Size = New System.Drawing.Size(68, 20)
    Me.TxtModel.TabIndex = 244
    '
    'TxtValue
    '
    Me.TxtValue.Location = New System.Drawing.Point(6, 113)
    Me.TxtValue.MaxLength = 9
    Me.TxtValue.Name = "TxtValue"
    Me.TxtValue.Size = New System.Drawing.Size(64, 20)
    Me.TxtValue.TabIndex = 242
    Me.TxtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtMake
    '
    Me.TxtMake.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMake.Location = New System.Drawing.Point(71, 113)
    Me.TxtMake.MaxLength = 5
    Me.TxtMake.Name = "TxtMake"
    Me.TxtMake.Size = New System.Drawing.Size(52, 20)
    Me.TxtMake.TabIndex = 243
    '
    'Label18
    '
    Me.Label18.Location = New System.Drawing.Point(389, 97)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(44, 16)
    Me.Label18.TabIndex = 257
    Me.Label18.Text = "Reg #"
    '
    'Label17
    '
    Me.Label17.Location = New System.Drawing.Point(269, 97)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(44, 16)
    Me.Label17.TabIndex = 256
    Me.Label17.Text = "VIN #"
    '
    'Label16
    '
    Me.Label16.Location = New System.Drawing.Point(237, 97)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(44, 16)
    Me.Label16.TabIndex = 255
    Me.Label16.Text = "Class"
    '
    'Label15
    '
    Me.Label15.Location = New System.Drawing.Point(197, 97)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(36, 16)
    Me.Label15.TabIndex = 254
    Me.Label15.Text = "Year"
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(123, 97)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(44, 16)
    Me.Label13.TabIndex = 252
    Me.Label13.Text = "Model"
    '
    'Label12
    '
    Me.Label12.Location = New System.Drawing.Point(6, 97)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(44, 16)
    Me.Label12.TabIndex = 251
    Me.Label12.Text = "Value"
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(71, 97)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(44, 16)
    Me.Label10.TabIndex = 250
    Me.Label10.Text = "Make"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView.DefaultCellStyle = DataGridViewCellStyle1
    Me.DataGrdView.Location = New System.Drawing.Point(12, 51)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(719, 222)
    Me.DataGrdView.TabIndex = 241
    '
    'FrmTA506B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(747, 423)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.GrpMV)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.RbBookValue)
    Me.Controls.Add(Me.RbValue)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtFindMake)
    Me.Controls.Add(Me.LnkClass)
    Me.Controls.Add(Me.TxtFindClass)
    Me.Controls.Add(Me.BtnRefresh)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "FrmTA506B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GrpMV.ResumeLayout(False)
    Me.GrpMV.PerformLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region
  Dim myTXMCTL As TXMctl.myData
  Dim myTXSUPP As TXSupp.myData
  Dim ds As DataSet = New DataSet
  Private Sub FrmTA506B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXMCTL = New TXMctl.mydata(MyDBConnect)
    myTXSUPP = New TXSupp.mydata(MyDBConnect)
    myTXMCTL.GetOneRecordP(1)
    BuildDS(ds)

    If Not myTXMCTL.RecordNotFound Then
      With myTXMCTL
        MyBookPct = ._VALPER
        MyMinValue = ._VALMIN
      End With
    End If

    GrpMV.Visible = False
    MyUtils.SetTxtReadOnly(TxtBookValue)
    MyFrmTA506.TBarSave.Enabled = False

  End Sub
  Private Sub BtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
    RefreshData()
  End Sub
  Public Sub FormatGrid()

    Call ShowGrid()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "List No"
      .Columns(0).Width = 50
      .Columns(1).HeaderText = "Owner Name"
      .Columns(1).Width = 250
      .Columns(2).HeaderText = "Class"
      .Columns(2).Width = 40
      .Columns(3).HeaderText = "Make"
      .Columns(3).Width = 60
      .Columns(4).HeaderText = "Year"
      .Columns(4).Width = 40
      .Columns(5).HeaderText = "VIN"
      .Columns(5).Width = 150
      .Columns(6).HeaderText = "Model"
      .Columns(6).Width = 80
    End With
  End Sub
  Public Sub ShowGrid()
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
  End Sub
  Private Sub FrmTA506C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA506.SbpScreen.Text = "TA506B"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    GetMV(DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value)
  End Sub
  Public Sub PrintData()
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds.Copy
    MyCrViewer.Show()
  End Sub
  Private Sub LnkClass_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkClass.LinkClicked
	MyFrmListCodes = New FrmListCodes
	MyFrmListCodes.MdiParent = Me.ParentForm
	MyFrmListCodes.WrkType = "M"
  MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtFindClass.Text)
  MyFrmListCodes.Show()
  Me.Hide()
End Sub
Private Sub TxtFindClass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFindClass.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtClass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClass.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtBookValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBookValue.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtMinValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMinValue.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtValue.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtBookValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBookValue.TextChanged
  If TxtBookValue.ReadOnly = False Then
    CalcValue()
  End If
End Sub
Private Sub CalcValue()
  Dim WrkValue As Integer
  WrkValue = MyUtils.CnvSng(TxtBookValue.Text) * MyUtils.CnvSng(TxtBookPct.Text)
  If WrkValue < MyUtils.CnvSng(TxtMinValue.Text) Then
    WrkValue = MyUtils.CnvSng(TxtMinValue.Text)
  End If
  TxtValue.Text = WrkValue
End Sub
  Private Function CalcProRate(ByVal Gross As Single, ByVal Pct As Single) As Single
    CalcProRate = Gross * Pct
    Return CalcProRate
  End Function
  Private Sub RbValue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbValue.Click
    TxtValue.ReadOnly = False
    TxtValue.BackColor = Color.White
    TxtValue.Focus()
    MyUtils.SetTxtReadOnly(TxtBookValue)
  End Sub
  Private Sub RbBookValue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbBookValue.Click
    TxtBookValue.ReadOnly = False
    TxtBookValue.BackColor = Color.White
    TxtBookValue.Focus()
    MyUtils.SetTxtReadOnly(TxtValue)
  End Sub
  Private Sub TxtFindMake_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFindMake.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      RefreshData()
    End If

  End Sub
Private Sub ShowFastPath()
  If TxtFindListNo.Text = "" Then Exit Sub

  GetMV(MyUtils.CnvSng(TxtFindListNo.Text))
End Sub
Public Sub RefreshData()
    Dim WrkListNo As Integer

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    ds = BuildFile()
    Call FormatGrid()
    If ds.Tables(0).Rows.Count > 0 Then
      WrkListNo = ds.Tables(0).Rows(0).Item("listno")
      GetMV(WrkListNo)
    End If
    MyFrmTA506.TBarPrint.Enabled = True
    Windows.Forms.Cursor.Current = Cursors.Default
End Sub
Public Sub GetMV(ByVal WrkListNo As Integer)
  myTXSUPP = New TXSupp.mydata(MyDBConnect)
  myTXSUPP.GetOneRecordP(WrkListNo)
  If myTXSUPP.RecordNotFound Then Exit Sub

  MyFrmTA506.TBarSave.Enabled = True
  If s_chg = False And s_full = False Then    '#sec
    MyFrmTA506.TBarSave.Visible = False
  End If
  With myTXSUPP
    TxtListNo.Text = WrkListNo
    TxtName.Text = Trim(._NAME)
    TxtMake.Text = Trim(._OMAKE)
    TxtModel.Text = Trim(._OMOD)
    TxtYear.Text = ._OYEAR
    TxtClass.Text = ._OCLS
    TxtVIN.Text = Trim(._OVIN)
    TxtRegno.Text = Trim(._OREGNO)
    TxtBookValue.Text = String.Empty
    If ._OVAL > 0 Then
      TxtValue.Text = ._OVAL
    Else
      TxtValue.Text = String.Empty
    End If
  End With

  GrpMV.Visible = True
  TxtBookPct.Text = MyBookPct
  TxtMinValue.Text = MyMinValue
  MyUtils.SetTxtReadOnly(TxtListNo)
  MyUtils.SetTxtReadOnly(TxtName)
  MyUtils.SetTxtReadOnly(TxtVIN)
  MyUtils.SetTxtReadOnly(TxtRegno)
  MyUtils.SetTxtReadOnly(TxtBookPct)
  MyUtils.SetTxtReadOnly(TxtMinValue)
  If TxtBookValue.ReadOnly Then
    TxtValue.Focus()
  Else
    TxtBookValue.Focus()
  End If

End Sub
Public Sub SaveData()
    Dim WrkRow As Integer
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    myTXSUPP.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text))
    MovetoFile()
    If IsNothing(ErrorMsg(0)) Then
      myTXSUPP.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If

    WrkRow = DataGrdView.CurrentCell.RowIndex
    If WrkRow < DataGrdView.RowCount - 1 Then
      DataGrdView.CurrentCell = DataGrdView(0, WrkRow + 1)
      GetMV(DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value)
    Else
      GrpMV.Visible = False
    End If
  End Sub
Private Sub MovetoFile()
  Dim WrkTxSupCd As String()
  Dim WrkPct As Decimal
  Dim TotExempt As Integer

  With myTXSUPP
    ._OMAKE = TxtMake.Text
    ._OMOD = TxtModel.Text
    ._OYEAR = MyUtils.CnvSng(TxtYear.Text)
    ._OCLS = MyUtils.CnvSng(TxtClass.Text)
    ._OVAL = MyUtils.CnvSng(TxtValue.Text)
    If Trim(._OASS) <> "" Then
      WrkTxSupCd = GetTXSupCd(._OASS)
      WrkPct = WrkTxSupCd(0)
      ._OPVAL = CalcProRate(._OVAL, WrkPct)
      If ._PVAL < ._OPVAL Then
        ._OPVAL = ._PVAL
      End If
      TotExempt = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5
      ._PNET = ._PVAL - ._OPVAL - TotExempt
      If ._PNET < 0 Then
        ._PNET = 0
      End If
    End If

  End With
End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
	Dim I As Integer
	ErrProv.SetError(TxtClass, "")
	For I = 0 To ErrorField.GetUpperBound(0)
		Select Case ErrorField(I)
		Case "class"
			ErrProv.SetError(TxtClass, ErrorMsg(I))
		Case Nothing
			Exit Sub
		End Select
	Next I
End Sub
End Class






