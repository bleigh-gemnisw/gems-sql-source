Public Class FrmPS002C
  Inherits System.Windows.Forms.Form
  Dim myMFPARK As MFPARK.MyData
  Dim ds As DataSet = New DataSet

  Dim myMFPARKL1 As MFPARKL1.MyData
  Dim ds2 As DataSet = New DataSet

  Dim myMFPRKH As MFPRKH.MyData
  Dim dsH As DataSet = New DataSet

  Friend WithEvents txtmfyear As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtmfadd1 As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents txtmfadd2 As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents txtmfregno As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents txtmfzip4 As System.Windows.Forms.TextBox
  Friend WithEvents txtmfzip5 As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents txtmfst As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents txtmfcity As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents LnkCategory As System.Windows.Forms.LinkLabel
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents BtnGetPrev As System.Windows.Forms.Button

  Friend wrkmfyear As Integer
  Friend wrkmfnam As String
  Friend wrkmfcatg As String
  Friend wrkmfadd1 As String
  Friend wrkstampd As Integer
  Friend wrkstampt As Integer
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents lblfee As System.Windows.Forms.Label
  Friend WithEvents txtmflfee As System.Windows.Forms.TextBox
  Friend WithEvents dtpckmfrdat As System.Windows.Forms.DateTimePicker
  Friend WithEvents lblrepd As System.Windows.Forms.Label
  Friend WithEvents txtmfrepl As System.Windows.Forms.TextBox
  Friend WithEvents lblrepno As System.Windows.Forms.Label
  Friend WithEvents txtmfcomm As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents DtPckmfliss As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents txtmfperno As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents gbhistory As System.Windows.Forms.GroupBox
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView

  Friend wrkyear As Integer

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
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Txtmfcatg As System.Windows.Forms.TextBox
  Friend WithEvents txtmfnam As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Txtmfcatg = New System.Windows.Forms.TextBox()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label2 = New System.Windows.Forms.Label()
    Me.txtmfnam = New System.Windows.Forms.TextBox()
    Me.txtmfyear = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.txtmfadd1 = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.txtmfadd2 = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.txtmfcity = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.txtmfst = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.txtmfzip5 = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.txtmfzip4 = New System.Windows.Forms.TextBox()
    Me.txtmfregno = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.LnkCategory = New System.Windows.Forms.LinkLabel()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.BtnGetPrev = New System.Windows.Forms.Button()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.txtmfperno = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.DtPckmfliss = New System.Windows.Forms.DateTimePicker()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.txtmfcomm = New System.Windows.Forms.TextBox()
    Me.lblrepno = New System.Windows.Forms.Label()
    Me.txtmfrepl = New System.Windows.Forms.TextBox()
    Me.lblrepd = New System.Windows.Forms.Label()
    Me.dtpckmfrdat = New System.Windows.Forms.DateTimePicker()
    Me.txtmflfee = New System.Windows.Forms.TextBox()
    Me.lblfee = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.gbhistory = New System.Windows.Forms.GroupBox()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.gbhistory.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Txtmfcatg
    '
    Me.Txtmfcatg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.Txtmfcatg.Location = New System.Drawing.Point(98, 30)
    Me.Txtmfcatg.MaxLength = 2
    Me.Txtmfcatg.Name = "Txtmfcatg"
    Me.Txtmfcatg.Size = New System.Drawing.Size(28, 20)
    Me.Txtmfcatg.TabIndex = 0
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(11, 60)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(69, 16)
    Me.Label2.TabIndex = 28
    Me.Label2.Text = "Name"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtmfnam
    '
    Me.txtmfnam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfnam.Location = New System.Drawing.Point(97, 60)
    Me.txtmfnam.MaxLength = 35
    Me.txtmfnam.Name = "txtmfnam"
    Me.txtmfnam.Size = New System.Drawing.Size(373, 20)
    Me.txtmfnam.TabIndex = 2
    '
    'txtmfyear
    '
    Me.txtmfyear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfyear.Location = New System.Drawing.Point(95, 4)
    Me.txtmfyear.MaxLength = 4
    Me.txtmfyear.Name = "txtmfyear"
    Me.txtmfyear.ReadOnly = True
    Me.txtmfyear.Size = New System.Drawing.Size(60, 20)
    Me.txtmfyear.TabIndex = 30
    Me.txtmfyear.TabStop = False
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(19, 7)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(62, 16)
    Me.Label3.TabIndex = 29
    Me.Label3.Text = "Year"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'txtmfadd1
    '
    Me.txtmfadd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfadd1.Location = New System.Drawing.Point(97, 86)
    Me.txtmfadd1.MaxLength = 35
    Me.txtmfadd1.Name = "txtmfadd1"
    Me.txtmfadd1.Size = New System.Drawing.Size(373, 20)
    Me.txtmfadd1.TabIndex = 3
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(11, 86)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(69, 16)
    Me.Label4.TabIndex = 32
    Me.Label4.Text = "Street 1"
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtmfadd2
    '
    Me.txtmfadd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfadd2.Location = New System.Drawing.Point(97, 112)
    Me.txtmfadd2.MaxLength = 35
    Me.txtmfadd2.Name = "txtmfadd2"
    Me.txtmfadd2.Size = New System.Drawing.Size(373, 20)
    Me.txtmfadd2.TabIndex = 4
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(11, 112)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(69, 16)
    Me.Label5.TabIndex = 34
    Me.Label5.Text = "Street 2"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtmfcity
    '
    Me.txtmfcity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfcity.Location = New System.Drawing.Point(97, 138)
    Me.txtmfcity.MaxLength = 25
    Me.txtmfcity.Name = "txtmfcity"
    Me.txtmfcity.Size = New System.Drawing.Size(186, 20)
    Me.txtmfcity.TabIndex = 5
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(11, 138)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(69, 16)
    Me.Label6.TabIndex = 36
    Me.Label6.Text = "City"
    Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtmfst
    '
    Me.txtmfst.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfst.Location = New System.Drawing.Point(316, 141)
    Me.txtmfst.MaxLength = 2
    Me.txtmfst.Name = "txtmfst"
    Me.txtmfst.Size = New System.Drawing.Size(29, 20)
    Me.txtmfst.TabIndex = 6
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(289, 142)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(21, 16)
    Me.Label7.TabIndex = 38
    Me.Label7.Text = "St"
    Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtmfzip5
    '
    Me.txtmfzip5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfzip5.Location = New System.Drawing.Point(393, 141)
    Me.txtmfzip5.MaxLength = 5
    Me.txtmfzip5.Name = "txtmfzip5"
    Me.txtmfzip5.Size = New System.Drawing.Size(48, 20)
    Me.txtmfzip5.TabIndex = 7
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(351, 142)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(36, 16)
    Me.Label8.TabIndex = 40
    Me.Label8.Text = "Zip"
    Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtmfzip4
    '
    Me.txtmfzip4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfzip4.Location = New System.Drawing.Point(447, 141)
    Me.txtmfzip4.MaxLength = 4
    Me.txtmfzip4.Name = "txtmfzip4"
    Me.txtmfzip4.Size = New System.Drawing.Size(48, 20)
    Me.txtmfzip4.TabIndex = 8
    '
    'txtmfregno
    '
    Me.txtmfregno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfregno.Location = New System.Drawing.Point(97, 174)
    Me.txtmfregno.MaxLength = 8
    Me.txtmfregno.Name = "txtmfregno"
    Me.txtmfregno.Size = New System.Drawing.Size(122, 20)
    Me.txtmfregno.TabIndex = 9
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(11, 174)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(69, 16)
    Me.Label9.TabIndex = 43
    Me.Label9.Text = "MV Reg#"
    Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LnkCategory
    '
    Me.LnkCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkCategory.Location = New System.Drawing.Point(19, 34)
    Me.LnkCategory.Name = "LnkCategory"
    Me.LnkCategory.Size = New System.Drawing.Size(62, 16)
    Me.LnkCategory.TabIndex = 237
    Me.LnkCategory.TabStop = True
    Me.LnkCategory.Text = "Category"
    Me.LnkCategory.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'BtnGetPrev
    '
    Me.BtnGetPrev.Location = New System.Drawing.Point(248, 174)
    Me.BtnGetPrev.Name = "BtnGetPrev"
    Me.BtnGetPrev.Size = New System.Drawing.Size(112, 24)
    Me.BtnGetPrev.TabIndex = 238
    Me.BtnGetPrev.TabStop = False
    Me.BtnGetPrev.Text = "Get Previous Year"
    '
    'Label10
    '
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
    Me.Label10.Location = New System.Drawing.Point(37, 32)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(103, 16)
    Me.Label10.TabIndex = 45
    Me.Label10.Text = "Permit Number"
    Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtmfperno
    '
    Me.txtmfperno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtmfperno.Location = New System.Drawing.Point(146, 29)
    Me.txtmfperno.MaxLength = 6
    Me.txtmfperno.Name = "txtmfperno"
    Me.txtmfperno.Size = New System.Drawing.Size(101, 22)
    Me.txtmfperno.TabIndex = 30
    '
    'Label11
    '
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
    Me.Label11.Location = New System.Drawing.Point(333, 32)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(69, 16)
    Me.Label11.TabIndex = 47
    Me.Label11.Text = "Issue Date"
    Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'DtPckmfliss
    '
    Me.DtPckmfliss.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckmfliss.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckmfliss.Location = New System.Drawing.Point(408, 29)
    Me.DtPckmfliss.Name = "DtPckmfliss"
    Me.DtPckmfliss.Size = New System.Drawing.Size(97, 22)
    Me.DtPckmfliss.TabIndex = 32
    '
    'Label12
    '
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
    Me.Label12.Location = New System.Drawing.Point(71, 118)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(69, 16)
    Me.Label12.TabIndex = 50
    Me.Label12.Text = "Comment"
    Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtmfcomm
    '
    Me.txtmfcomm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfcomm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtmfcomm.Location = New System.Drawing.Point(146, 112)
    Me.txtmfcomm.MaxLength = 40
    Me.txtmfcomm.Name = "txtmfcomm"
    Me.txtmfcomm.Size = New System.Drawing.Size(341, 22)
    Me.txtmfcomm.TabIndex = 50
    '
    'lblrepno
    '
    Me.lblrepno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblrepno.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
    Me.lblrepno.Location = New System.Drawing.Point(18, 62)
    Me.lblrepno.Name = "lblrepno"
    Me.lblrepno.Size = New System.Drawing.Size(122, 16)
    Me.lblrepno.TabIndex = 52
    Me.lblrepno.Text = "Replacement Number"
    Me.lblrepno.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtmfrepl
    '
    Me.txtmfrepl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtmfrepl.Location = New System.Drawing.Point(146, 59)
    Me.txtmfrepl.MaxLength = 8
    Me.txtmfrepl.Name = "txtmfrepl"
    Me.txtmfrepl.Size = New System.Drawing.Size(122, 22)
    Me.txtmfrepl.TabIndex = 38
    '
    'lblrepd
    '
    Me.lblrepd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblrepd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
    Me.lblrepd.Location = New System.Drawing.Point(283, 62)
    Me.lblrepd.Name = "lblrepd"
    Me.lblrepd.Size = New System.Drawing.Size(119, 16)
    Me.lblrepd.TabIndex = 53
    Me.lblrepd.Text = "Replacement Date"
    Me.lblrepd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'dtpckmfrdat
    '
    Me.dtpckmfrdat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.dtpckmfrdat.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.dtpckmfrdat.Location = New System.Drawing.Point(408, 59)
    Me.dtpckmfrdat.Name = "dtpckmfrdat"
    Me.dtpckmfrdat.Size = New System.Drawing.Size(97, 22)
    Me.dtpckmfrdat.TabIndex = 40
    '
    'txtmflfee
    '
    Me.txtmflfee.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtmflfee.Location = New System.Drawing.Point(146, 84)
    Me.txtmflfee.MaxLength = 5
    Me.txtmflfee.Name = "txtmflfee"
    Me.txtmflfee.Size = New System.Drawing.Size(101, 22)
    Me.txtmflfee.TabIndex = 45
    '
    'lblfee
    '
    Me.lblfee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblfee.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
    Me.lblfee.Location = New System.Drawing.Point(71, 90)
    Me.lblfee.Name = "lblfee"
    Me.lblfee.Size = New System.Drawing.Size(69, 16)
    Me.lblfee.TabIndex = 56
    Me.lblfee.Text = "Fee"
    Me.lblfee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.lblfee)
    Me.GroupBox1.Controls.Add(Me.txtmflfee)
    Me.GroupBox1.Controls.Add(Me.dtpckmfrdat)
    Me.GroupBox1.Controls.Add(Me.lblrepd)
    Me.GroupBox1.Controls.Add(Me.txtmfrepl)
    Me.GroupBox1.Controls.Add(Me.lblrepno)
    Me.GroupBox1.Controls.Add(Me.txtmfcomm)
    Me.GroupBox1.Controls.Add(Me.Label12)
    Me.GroupBox1.Controls.Add(Me.DtPckmfliss)
    Me.GroupBox1.Controls.Add(Me.Label11)
    Me.GroupBox1.Controls.Add(Me.txtmfperno)
    Me.GroupBox1.Controls.Add(Me.Label10)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
    Me.GroupBox1.Location = New System.Drawing.Point(15, 204)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(596, 149)
    Me.GroupBox1.TabIndex = 22
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Current Permit Information"
    '
    'gbhistory
    '
    Me.gbhistory.Controls.Add(Me.DataGrdView)
    Me.gbhistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.gbhistory.ForeColor = System.Drawing.Color.Maroon
    Me.gbhistory.Location = New System.Drawing.Point(14, 359)
    Me.gbhistory.Name = "gbhistory"
    Me.gbhistory.Size = New System.Drawing.Size(597, 172)
    Me.gbhistory.TabIndex = 239
    Me.gbhistory.TabStop = False
    Me.gbhistory.Text = "History"
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.AllowUserToResizeRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DataGrdView.Location = New System.Drawing.Point(8, 17)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(583, 146)
    Me.DataGrdView.TabIndex = 34
    '
    'FrmPS002C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(651, 534)
    Me.Controls.Add(Me.gbhistory)
    Me.Controls.Add(Me.BtnGetPrev)
    Me.Controls.Add(Me.LnkCategory)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.txtmfregno)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.txtmfzip4)
    Me.Controls.Add(Me.txtmfzip5)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.txtmfst)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.txtmfcity)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.txtmfadd2)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.txtmfadd1)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.txtmfyear)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.txtmfnam)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Txtmfcatg)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmPS002C"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.gbhistory.ResumeLayout(False)
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region
  Private Sub PS002C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    myMFPARKL1 = New MFPARKL1.MyData(myDBConnect)
    myMFPRKH = New MFPRKH.MyData(myDBConnect)
    myMFPARK = New MFPARK.MyData(myDBConnect)

    MyfrmPS002.TBarNew.Enabled = False
    MyfrmPS002.TBarSave.Enabled = True
    MyfrmPS002.TBarPrint.Enabled = False
    txtmfyear.Text = wrkmfyear
    If Trim(wrkmfnam) <> "" Then
      MyfrmPS002.TBarDelete.Enabled = True
      MyUtils.SetTxtReadOnly(Txtmfcatg)
      Txtmfcatg.ReadOnly = True
      txtmfnam.ReadOnly = True
      txtmfadd1.ReadOnly = True
      txtmfperno.ReadOnly = True
      DtPckmfliss.Enabled = False
      LnkCategory.Enabled = False

    Else
      txtmfrepl.Visible = False
      dtpckmfrdat.Visible = False
      txtmflfee.Visible = False
      lblrepno.Visible = False
      lblrepd.Visible = False
      lblfee.Visible = False
      gbhistory.Visible = False
    End If
    If wrkmfnam = "" Then
      Me.Text = "Add " & Me.Text
      MyfrmPS002.TBarDelete.Enabled = False
      Exit Sub
    End If
    myMFPARK.GetOneRecordP(wrkmfyear, wrkmfcatg, wrkmfnam, wrkmfadd1, wrkstampd, wrkstampt)
    If myMFPARK.RecordNotFound Then Exit Sub
    txtmfyear.Text = wrkmfyear
    Txtmfcatg.Text = wrkmfcatg
    txtmfnam.Text = wrkmfnam
    txtmfadd1.Text = wrkmfadd1
    ' txtmfstampd.text = wrkmfstamp
    ' txmfstampt.text = wrkmfstampt

    If s_chg = False And s_full = False Then    '#sec
      MyfrmPS002.TBarSave.Visible = False
    End If

    With myMFPARK
      txtmfadd2.Text = Trim(._MFADD2)
      txtmfcity.Text = Trim(._MFCITY)
      txtmfst.Text = Trim(._MFST)
      txtmfzip5.Text = Format(._MFZIP5, "00000")
      txtmfzip4.Text = Format(._MFZIP5, "0000")
      txtmfregno.Text = Trim(._MFREGNo)
      txtmfperno.Text = ._MFPERNo
      If ._MFLISS > 0 Then
        DtPckmfliss.Value = MyUtils.GetDBDate(._MFLISS)
      End If
      ' txtmfcomm.Text = Trim((._MFCOMM))  
    End With
    HistoryFormatGrid()
    BtnGetPrev.Visible = False
  End Sub
  Private Sub PS002C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyfrmPS002.SbpScreen.Text = "PS002C"
    If Trim(wrkmfnam) <> "" Then
      txtmfrepl.Focus()
    End If
    MyUtils.CenterForm(Me.ParentForm, Me)

  End Sub
  Private Sub PS002C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    ' added these 3 might not need.
    myMFPARK = Nothing
    myMFPARKL1 = Nothing
    myMFPRKH = Nothing

    MyfrmPS002.TBarNew.Enabled = True
    MyfrmPS002.TBarDelete.Enabled = False
    MyfrmPS002.TBarSave.Enabled = False
    MyfrmPS002.TBarPrint.Enabled = False
    MyfrmPS002B.FormatGrid()
    MyfrmPS002B.Show()
  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    myMFPARK.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    myMFPARK.GetOneRecordP(wrkmfyear, wrkmfcatg, wrkmfnam, wrkmfadd1, wrkstampd, wrkstampt)
    If Not myMFPARK.RecordNotFound Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MovetoFile()
        myMFPARK.UpdateOneRecordP()
        If MyUtils.CnvSng(Trim(txtmfrepl.Text)) <> 0 Or MyUtils.CnvSng(Trim(txtmflfee.Text)) <> 0 Then
          WriteToHistory()
        End If
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MovetoFile()
        myMFPARK.AddOneRecordP()
        WriteToHistory()  ' on add we always write to history
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    Me.Close()
  End Sub
  Private Sub MovetoFile()
    Dim WrkDate As String
    Dim WrkTime As String
    ' for time stamp 
    WrkDate = Format$(Today, "MMddyyyy")
    WrkTime = Format$(TimeOfDay, "HHmmss")

    If wrkmfnam = "" Then
      wrkstampd = MyUtils.CnvSng(WrkDate)
      wrkstampt = MyUtils.CnvSng(WrkTime)
    End If

    With myMFPARK
      ._MFADD1 = Trim(txtmfadd1.Text)
      ._MFADD2 = Trim(txtmfadd2.Text)
      ._MFCATG = Trim(Txtmfcatg.Text)
      ._MFCITY = Trim(txtmfcity.Text)
      ._MFCOMM = Trim(txtmfcomm.Text)
      ._MFLISS = MyUtils.SetDBDate(DtPckmfliss.Value)
      ._MFNAM = Trim(txtmfnam.Text)
      ._MFPERNo = MyUtils.CnvSng(txtmfperno.Text)
      ._MFREGNo = Trim(txtmfregno.Text)
      ._MFST = Trim(txtmfst.Text)
      ._MFYEAR = MyUtils.CnvSng(txtmfyear.Text)
      ._MFZIP4 = MyUtils.CnvSng(txtmfzip4.Text)
      ._MFZIP5 = MyUtils.CnvSng(txtmfzip5.Text)
      ._STAMPD = wrkstampd
      ._STAMPT = wrkstampt
      If Trim(txtmfcomm.Text) = "" Then
        ._MFCOMM = "PERMIT ISSUED"
      End If
      ' replacement
      If Trim(txtmfrepl.Text) > "" Then
        ._MFPERNo = MyUtils.CnvSng(txtmfrepl.Text)
        ._MFLISS = MyUtils.SetDBDate(dtpckmfrdat.Value)
        If Trim(txtmfcomm.Text) = "" Then
          ._MFCOMM = "REPLACEMNET ISSUED"
        End If
      End If
    End With
  End Sub
  Private Sub WriteToHistory()
    Dim WrkTdate As String
    Dim WrkTtime As String
    wrkmfyear = MyUtils.CnvSng(txtmfyear.Text)
    wrkmfcatg = Trim(Txtmfcatg.Text)
    wrkmfnam = Trim(txtmfnam.Text)
    wrkmfadd1 = Trim(txtmfadd1.Text)
    WrkTdate = Format$(Today, "yyyyMMdd")
    WrkTtime = Format$(TimeOfDay, "HHmmss")
    With myMFPRKH
      .GetOneRecordP(wrkmfyear, wrkmfcatg, wrkmfnam, wrkmfadd1, wrkstampd, wrkstampt, WrkTdate, WrkTtime)
      ._MFADD1 = wrkmfadd1
      ._MFCATG = wrkmfcatg
      ._MFCOMM = Trim(txtmfcomm.Text)
      ._MFLFEE = MyUtils.CnvSng(txtmflfee.Text)
      ._MFLISS = MyUtils.SetDBDate(DtPckmfliss.Value)
      ._MFNAM = wrkmfnam
      ._MFPERNo = MyUtils.CnvSng(txtmfperno.Text)
      ._MFYEAR = wrkmfyear
      ._STAMPD = wrkstampd
      ._STAMPT = wrkstampt
      ._MFTDAT = MyUtils.CnvSng(WrkTdate)
      ._MFTTIM = MyUtils.CnvSng(WrkTtime)
      If Trim(txtmfcomm.Text) = "" Then
        ._MFCOMM = "PERMIT ISSUED"
      End If
      ' replacement
      If Trim(txtmfrepl.Text) > "" Then
        ._MFPERNo = MyUtils.CnvSng(txtmfrepl.Text)
        ._MFLISS = MyUtils.SetDBDate(dtpckmfrdat.Value)
        If Trim(txtmfcomm.Text) = "" Then
          ._MFCOMM = "REPLACEMENT ISSUED"
        End If
      End If
      .AddOneRecordP()
    End With
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(Txtmfcatg, "")
    ErrProv.SetError(txtmfnam, "")
    ErrProv.SetError(txtmfadd1, "")
    ErrProv.SetError(txtmfperno, "")
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "mfcat"
          ErrProv.SetError(Txtmfcatg, ErrorMsg(I))
        Case "mfnam"
          ErrProv.SetError(txtmfnam, ErrorMsg(I))
        Case "mfadd1"
          ErrProv.SetError(txtmfadd1, ErrorMsg(I))
        Case "mfperno"
          ErrProv.SetError(txtmfperno, ErrorMsg(I))
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

    If Txtmfcatg.Text = Trim("") Then
      ErrorField(I) = "mfcat"
      ErrorMsg(I) = "Category Required"
      I = I + 1
    End If

    If txtmfnam.Text = Trim("") Then
      ErrorField(I) = "mfnam"
      ErrorMsg(I) = "Name required"
      I = I + 1
    End If
    If txtmfadd1.Text = Trim("") Then
      ErrorField(I) = "mfadd1"
      ErrorMsg(I) = "Address required"
      I = I + 1
    End If
    If txtmfperno.Text = Trim("") Then
      ErrorField(I) = "mfperno"
      ErrorMsg(I) = "Permit Number required"
      I = I + 1
    End If

  End Sub


  Private Sub LnkCategory_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCategory.LinkClicked
    MyfrmListmfpcat = New FrmListmfpcat
    MyfrmListmfpcat.MdiParent = Me.ParentForm
    MyfrmListmfpcat.Wrkmfpcat = Txtmfcatg.Text
    MyfrmListmfpcat.Show()
  End Sub

  Private Sub txtmfzip5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmfzip5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub


  Private Sub txtmfzip4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmfzip4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Private Sub txtmfperno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmfperno.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Private Sub txtmfrepl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmfrepl.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetPrev.Click
    Dim myyear As Integer
    Dim myreg As String
    myreg = Trim(txtmfregno.Text)
    myyear = MyUtils.CnvSng(txtmfyear.Text) - 1
    ds = myMFPARKL1.GetViewReg(myyear, myreg, 1)
    If ds.Tables(0).Rows.Count = 0 Then
      MsgBox("No previous year data exists for Regno")
      Exit Sub
    End If
    With ds.Tables(0).Rows(0)
      txtmfnam.Text = .Item("MFNAM")
      txtmfadd1.Text = .Item("MFADD1")
      txtmfadd2.Text = .Item("MFADD2")
      txtmfcity.Text = .Item("MFCITY")
      txtmfst.Text = .Item("MFST")
      txtmfzip5.Text = .Item("MFZIP5")
      txtmfzip4.Text = .Item("MFZIP4")
      Txtmfcatg.Text = .Item("MFCATG")
    End With
    txtmfperno.Focus()
  End Sub

  Public Sub HistoryFormatGrid()
    Dim Style As DataGridViewCellStyle
    Style = DataGrdView.ColumnHeadersDefaultCellStyle
    Style.Font = New Font(DataGrdView.Font, FontStyle.Regular)
    Style = DataGrdView.DefaultCellStyle
    Style.Font = New Font(DataGrdView.Font, FontStyle.Regular)

    Call ShowGrid()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "Trans Date"
      .Columns(0).DefaultCellStyle.Format = "##/##/####"
      .Columns(0).Width = 75
      .Columns(1).Visible = False
      .Columns(2).HeaderText = "Permit#"
      .Columns(2).Width = 75
      .Columns(3).HeaderText = "Issue Date"
      .Columns(3).Width = 75
      .Columns(4).HeaderText = "Fee"
      .Columns(4).Width = 65
      .Columns(5).HeaderText = "Comment"
      .Columns(5).Width = 250
    End With

  End Sub
  Public Sub ShowGrid()
    ' note wrkstampd and wrkstampt are not TIME stamps for history file.  PArt of key of the mfpark file
    dsH = myMFPRKH.GetViewbyPerson(wrkmfyear, wrkmfcatg, wrkmfnam, wrkmfadd1, wrkstampd, wrkstampt)
    DataGrdView.DataSource = dsH.Tables(0)
    DataGrdView.Refresh()
  End Sub
  Private Sub txtmflfee_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmflfee.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
End Class






