Public Class FrmTO300C
  Inherits System.Windows.Forms.Form
  Dim myTXVCUS As TXVCUS.myData
  Dim myTXVEHL2 As TXVEHL2.myData
  Friend WrkCustID As Integer
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtZip As System.Windows.Forms.TextBox
  Friend WithEvents TxtState As System.Windows.Forms.TextBox
  Friend WithEvents TxtCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtAdd1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtCustID As System.Windows.Forms.TextBox
  Friend WithEvents ChkBus As System.Windows.Forms.CheckBox
  Friend WithEvents ChkConfid As System.Windows.Forms.CheckBox
  Friend WithEvents TxtSex As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents DtPckDOB As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents LblChgDate As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtRzip As System.Windows.Forms.TextBox
  Friend WithEvents TxtRstate As System.Windows.Forms.TextBox
  Friend WithEvents TxtRcity As System.Windows.Forms.TextBox
  Friend WithEvents TxtRadd1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtRadd2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAdd2 As System.Windows.Forms.TextBox
  Friend WithEvents DataGrdView As DataGridView
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
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.TxtZip = New System.Windows.Forms.TextBox()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.TxtAdd1 = New System.Windows.Forms.TextBox()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtSex = New System.Windows.Forms.TextBox()
    Me.ChkConfid = New System.Windows.Forms.CheckBox()
    Me.ChkBus = New System.Windows.Forms.CheckBox()
    Me.TxtCustID = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.DtPckDOB = New System.Windows.Forms.DateTimePicker()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.LblChgDate = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtRzip = New System.Windows.Forms.TextBox()
    Me.TxtRstate = New System.Windows.Forms.TextBox()
    Me.TxtRcity = New System.Windows.Forms.TextBox()
    Me.TxtRadd1 = New System.Windows.Forms.TextBox()
    Me.TxtRadd2 = New System.Windows.Forms.TextBox()
    Me.TxtAdd2 = New System.Windows.Forms.TextBox()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(8, 38)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(35, 13)
    Me.Label5.TabIndex = 9
    Me.Label5.Text = "Name"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtZip
    '
    Me.TxtZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip.Location = New System.Drawing.Point(237, 115)
    Me.TxtZip.MaxLength = 10
    Me.TxtZip.Name = "TxtZip"
    Me.TxtZip.Size = New System.Drawing.Size(87, 20)
    Me.TxtZip.TabIndex = 6
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(212, 115)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(24, 20)
    Me.TxtState.TabIndex = 5
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCity.Location = New System.Drawing.Point(70, 115)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(136, 20)
    Me.TxtCity.TabIndex = 4
    '
    'TxtAdd1
    '
    Me.TxtAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd1.Location = New System.Drawing.Point(70, 64)
    Me.TxtAdd1.MaxLength = 35
    Me.TxtAdd1.Name = "TxtAdd1"
    Me.TxtAdd1.Size = New System.Drawing.Size(216, 20)
    Me.TxtAdd1.TabIndex = 2
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(70, 38)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(216, 20)
    Me.TxtName.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(6, 64)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(45, 13)
    Me.Label1.TabIndex = 407
    Me.Label1.Text = "Address"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(5, 265)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(25, 13)
    Me.Label3.TabIndex = 408
    Me.Label3.Text = "Sex"
    '
    'TxtSex
    '
    Me.TxtSex.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSex.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSex.Location = New System.Drawing.Point(62, 262)
    Me.TxtSex.MaxLength = 1
    Me.TxtSex.Name = "TxtSex"
    Me.TxtSex.Size = New System.Drawing.Size(20, 20)
    Me.TxtSex.TabIndex = 13
    '
    'ChkConfid
    '
    Me.ChkConfid.AutoSize = True
    Me.ChkConfid.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkConfid.Location = New System.Drawing.Point(101, 265)
    Me.ChkConfid.Name = "ChkConfid"
    Me.ChkConfid.Size = New System.Drawing.Size(87, 17)
    Me.ChkConfid.TabIndex = 14
    Me.ChkConfid.Text = "Confidential?"
    Me.ChkConfid.UseVisualStyleBackColor = True
    '
    'ChkBus
    '
    Me.ChkBus.AutoSize = True
    Me.ChkBus.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkBus.Location = New System.Drawing.Point(209, 265)
    Me.ChkBus.Name = "ChkBus"
    Me.ChkBus.Size = New System.Drawing.Size(74, 17)
    Me.ChkBus.TabIndex = 15
    Me.ChkBus.Text = "Business?"
    Me.ChkBus.UseVisualStyleBackColor = True
    '
    'TxtCustID
    '
    Me.TxtCustID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCustID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCustID.Location = New System.Drawing.Point(70, 12)
    Me.TxtCustID.MaxLength = 9
    Me.TxtCustID.Name = "TxtCustID"
    Me.TxtCustID.Size = New System.Drawing.Size(73, 20)
    Me.TxtCustID.TabIndex = 0
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(8, 12)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(42, 13)
    Me.Label6.TabIndex = 415
    Me.Label6.Text = "Cust ID"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(8, 119)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(57, 13)
    Me.Label7.TabIndex = 416
    Me.Label7.Text = "City/St/Zp"
    '
    'DtPckDOB
    '
    Me.DtPckDOB.Checked = False
    Me.DtPckDOB.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckDOB.Location = New System.Drawing.Point(72, 236)
    Me.DtPckDOB.Name = "DtPckDOB"
    Me.DtPckDOB.ShowCheckBox = True
    Me.DtPckDOB.Size = New System.Drawing.Size(96, 20)
    Me.DtPckDOB.TabIndex = 12
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(0, 240)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(66, 13)
    Me.Label9.TabIndex = 418
    Me.Label9.Text = "Date of Birth"
    '
    'LblChgDate
    '
    Me.LblChgDate.AutoSize = True
    Me.LblChgDate.Location = New System.Drawing.Point(538, 9)
    Me.LblChgDate.Name = "LblChgDate"
    Me.LblChgDate.Size = New System.Drawing.Size(64, 13)
    Me.LblChgDate.TabIndex = 419
    Me.LblChgDate.Text = "<Chg Date>"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(0, 202)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(57, 13)
    Me.Label2.TabIndex = 428
    Me.Label2.Text = "City/St/Zp"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(-1, 150)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(67, 13)
    Me.Label4.TabIndex = 427
    Me.Label4.Text = "Res Address"
    '
    'TxtRzip
    '
    Me.TxtRzip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRzip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRzip.Location = New System.Drawing.Point(237, 199)
    Me.TxtRzip.MaxLength = 10
    Me.TxtRzip.Name = "TxtRzip"
    Me.TxtRzip.Size = New System.Drawing.Size(87, 20)
    Me.TxtRzip.TabIndex = 11
    '
    'TxtRstate
    '
    Me.TxtRstate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRstate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRstate.Location = New System.Drawing.Point(212, 199)
    Me.TxtRstate.MaxLength = 2
    Me.TxtRstate.Name = "TxtRstate"
    Me.TxtRstate.Size = New System.Drawing.Size(24, 20)
    Me.TxtRstate.TabIndex = 10
    '
    'TxtRcity
    '
    Me.TxtRcity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRcity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRcity.Location = New System.Drawing.Point(72, 199)
    Me.TxtRcity.MaxLength = 25
    Me.TxtRcity.Name = "TxtRcity"
    Me.TxtRcity.Size = New System.Drawing.Size(136, 20)
    Me.TxtRcity.TabIndex = 9
    '
    'TxtRadd1
    '
    Me.TxtRadd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRadd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRadd1.Location = New System.Drawing.Point(72, 147)
    Me.TxtRadd1.MaxLength = 35
    Me.TxtRadd1.Name = "TxtRadd1"
    Me.TxtRadd1.Size = New System.Drawing.Size(216, 20)
    Me.TxtRadd1.TabIndex = 7
    '
    'TxtRadd2
    '
    Me.TxtRadd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRadd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRadd2.Location = New System.Drawing.Point(72, 173)
    Me.TxtRadd2.MaxLength = 35
    Me.TxtRadd2.Name = "TxtRadd2"
    Me.TxtRadd2.Size = New System.Drawing.Size(216, 20)
    Me.TxtRadd2.TabIndex = 8
    '
    'TxtAdd2
    '
    Me.TxtAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd2.Location = New System.Drawing.Point(70, 89)
    Me.TxtAdd2.MaxLength = 35
    Me.TxtAdd2.Name = "TxtAdd2"
    Me.TxtAdd2.Size = New System.Drawing.Size(216, 20)
    Me.TxtAdd2.TabIndex = 3
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DataGrdView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView.DefaultCellStyle = DataGridViewCellStyle2
    Me.DataGrdView.Location = New System.Drawing.Point(333, 38)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DataGrdView.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(269, 181)
    Me.DataGrdView.TabIndex = 429
    '
    'FrmTO300C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(614, 287)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.TxtAdd2)
    Me.Controls.Add(Me.TxtRadd2)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtRzip)
    Me.Controls.Add(Me.TxtRstate)
    Me.Controls.Add(Me.TxtRcity)
    Me.Controls.Add(Me.TxtRadd1)
    Me.Controls.Add(Me.LblChgDate)
    Me.Controls.Add(Me.DtPckDOB)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.TxtCustID)
    Me.Controls.Add(Me.ChkBus)
    Me.Controls.Add(Me.ChkConfid)
    Me.Controls.Add(Me.TxtSex)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtZip)
    Me.Controls.Add(Me.TxtState)
    Me.Controls.Add(Me.TxtCity)
    Me.Controls.Add(Me.TxtAdd1)
    Me.Controls.Add(Me.TxtName)
    Me.Controls.Add(Me.Label5)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTO300C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Maintainence"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTO300C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXVCUS = New TXVCUS.mydata(MyDBConnect)
    myTXVEHL2 = New TXVEHL2.mydata(MyDBConnect)

    MyFrmTO300.TBarNew.Enabled = False
    MyFrmTO300.TBarSave.Enabled = True
    myTXVCUS.GetOneRecordP(WrkCustID)
    If myTXVCUS.RecordNotFound Then
      If WrkCustID > 0 Then
        TxtCustID.Text = WrkCustID
      End If
      LblChgDate.Text = ""
      Exit Sub
    End If

    If WrkCustID > 0 Then
      MyFrmTO300.TBarDelete.Enabled = True
    End If
    If s_chg = False And s_full = False Then    '#sec
      MyFrmTO300.TBarSave.Visible = False
    End If
    MyUtils.SetTxtReadOnly(TxtCustID)
    With myTXVCUS
      .GetOneRecordP(WrkCustID)
      TxtCustID.Text = ._CUSTID
      TxtName.Text = Trim(._NAME)
      TxtAdd1.Text = Trim(._ADD1)
      TxtAdd2.Text = Trim(._ADD2)
      TxtCity.Text = Trim(._CITY)
      TxtState.Text = Trim(._STATE)
      TxtZip.Text = Trim(._ZIPA)
      TxtRadd1.Text = Trim(._RADD1)
      TxtRadd2.Text = Trim(._RADD2)
      TxtRcity.Text = Trim(._RCITY)
      TxtRstate.Text = Trim(._RSTATE)
      TxtRzip.Text = Trim(._RZIPA)
      If ._DOB > 0 Then
        DtPckDOB.Value = MyUtils.GetDBDate(._DOB)
      Else
        DtPckDOB.Value = Date.Today
        DtPckDOB.Checked = False
      End If
      If ._BUS = "Y" Then
        ChkBus.Checked = True
      Else
        ChkBus.Checked = False
      End If
      TxtSex.Text = Trim(._SEX)
      If ._CONFID = "Y" Then
        ChkConfid.Checked = True
      Else
        ChkConfid.Checked = False
      End If
      If ._CHDATE > 0 Then
        LblChgDate.Text = MyUtils.GetDBDate(._CHDATE)
      Else
        LblChgDate.Text = "Manual Entry"
      End If
    End With
    FormatGrid()
  End Sub
  Public Sub FormatGrid()
    Dim ds As DataSet = New DataSet
    ds = myTXVEHL2.GetViewbyPcust(WrkCustID, 99999999, 0)
    With DataGrdView
      .DataSource = ds.Tables(0)
    End With
    Call ShowGrid()
  End Sub
  Public Sub ShowGrid()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersVisible = False
      .Columns(0).Visible = False
      .Columns(1).Visible = False
      .Columns(2).HeaderText = "RegNo"
      .Columns(2).Width = 60
      .Columns(3).Visible = False
      .Columns(4).Visible = False
      .Columns(5).HeaderText = "Vehicle ID"
      .Columns(5).Width = 70
      .Columns(6).HeaderText = "Lease?"
      .Columns(6).Width = 50
      .Columns(7).HeaderText = "Chg Date"
      .Columns(7).DefaultCellStyle.Format = "##/##/####"
      .Columns(7).Width = 65
    End With
  End Sub
  Private Sub FrmTO300C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTO300.TBarNew.Enabled = True
    MyFrmTO300.TBarDelete.Enabled = False
    MyFrmTO300.TBarSave.Enabled = False
    MyFrmTO300.TBarSave.Visible = True   '#sec
    MyFrmTO300B.FormatGrid()
    MyFrmTO300B.Show()
    MyFrmTO300C = Nothing
  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    myTXVCUS.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(50) As String
    Dim ErrorMsg(50) As String

    myTXVCUS.GetOneRecordP(MyUtils.CnvSng(TxtCustID.Text))
    If WrkCustID = 0 Then
      If Not myTXVCUS.RecordNotFound Then
        Me.ErrProv.SetError(TxtCustID, "Record already exists")
        Exit Sub
      End If
    End If

    If WrkCustID > 0 Then
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXVCUS.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXVCUS._CUSTID = MyUtils.CnvSng(TxtCustID.Text)
        myTXVCUS.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()

  End Sub
  Private Sub MoveToFile()
    With myTXVCUS
      ._NAME = TxtName.Text
      ._ADD1 = TxtAdd1.Text
      ._ADD2 = TxtAdd2.Text
      ._CITY = TxtCity.Text
      ._STATE = TxtState.Text
      ._ZIPA = TxtZip.Text
      ._RADD1 = TxtRadd1.Text
      ._RADD2 = TxtRadd2.Text
      ._RCITY = TxtRcity.Text
      ._RSTATE = TxtRstate.Text
      ._RZIPA = TxtRzip.Text
      If DtPckDOB.Checked Then
        ._DOB = MyUtils.SetDBDate(DtPckDOB.Value)
      Else
        ._DOB = 0
      End If
      If ChkBus.Checked Then
        ._BUS = "Y"
      Else
        ._BUS = "N"
      End If
      ._SEX = TxtSex.Text
      If ChkConfid.Checked Then
        ._CONFID = "Y"
      Else
        ._CONFID = "N"
      End If
    End With
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtCustID, "")
    ErrProv.SetError(TxtName, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Me.ForeColor = Color.DarkRed
      Select Case ErrorField(I)
        Case "custid"
          ErrProv.SetError(TxtCustID, ErrorMsg(I))
        Case "name"
          ErrProv.SetError(TxtName, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim ds2 As DataSet = New DataSet
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If TxtCustID.Text = String.Empty Then
      ErrorField(I) = "custid"
      ErrorMsg(I) = "CustID cannot be blank"
      I = I + 1
    End If

    If TxtName.Text = String.Empty Then
      ErrorField(I) = "name"
      ErrorMsg(I) = "Name cannot be blank"
      I = I + 1
    End If
  End Sub
  Private Sub FrmTO300C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

    MyFrmTO300.SbpScreen.Text = "TO300C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub TxtCustID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCustID.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub


End Class






