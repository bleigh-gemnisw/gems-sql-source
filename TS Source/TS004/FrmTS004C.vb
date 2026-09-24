Public Class FrmTS004C
  Inherits System.Windows.Forms.Form
  Dim myMFTRAN As MFTRAN.myData
  Dim MyMFTCLS As MFTCLS.myData
  Dim MyMFTptyp As MFTPTYP.myData
  Dim MyMFTtype As MFTTYPE.myData


  Dim ds As DataSet = New DataSet

  Dim myMFTRANL1 As MFTRANL1.myData
  Dim ds2 As DataSet = New DataSet

  Dim myMFTRNH As MFTRNH.mydata
  Dim dsH As DataSet = New DataSet

  Friend WithEvents txtmfyear As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtmfadd1 As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents txtmfadd2 As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents txtmfzip4 As System.Windows.Forms.TextBox
  Friend WithEvents txtmfzip5 As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents txtmfst As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents txtmfcity As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents LnkCls As System.Windows.Forms.LinkLabel
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip

  Friend wrkmfyear As Integer
  Friend wrkmfnam As String
  Friend wrkmfcatg As String
  Friend wrkmfadd1 As String
  Friend wrkstampd As Double
  Friend wrkstampt As Double
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
  Friend WithEvents lblclassd As System.Windows.Forms.Label
  Friend WithEvents lblclassfee As System.Windows.Forms.Label
  Friend WithEvents txtmftel As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Lnkmfttype As System.Windows.Forms.LinkLabel
  Friend WithEvents txtmftyp As System.Windows.Forms.TextBox
  Friend WithEvents Lnkmftptyp As System.Windows.Forms.LinkLabel
  Friend WithEvents txtmfptyp As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents BtnGetPrev As System.Windows.Forms.Button
  Friend WithEvents txtmfregno As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents txtmfcap As System.Windows.Forms.TextBox
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents txtmfcolr As System.Windows.Forms.TextBox
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents txtmfmake As System.Windows.Forms.TextBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents txtmfcyr As System.Windows.Forms.TextBox
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents txtmfvinno As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents txtmflic As System.Windows.Forms.TextBox
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents txtmftfee As System.Windows.Forms.TextBox
  Friend WithEvents btnprintrenewal As System.Windows.Forms.Button
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents txtmfmod As System.Windows.Forms.TextBox
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
Friend WithEvents Txtmfcls As System.Windows.Forms.TextBox
Friend WithEvents txtmfnam As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTS004C))
    Me.Txtmfcls = New System.Windows.Forms.TextBox()
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
    Me.LnkCls = New System.Windows.Forms.LinkLabel()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
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
    Me.txtmftfee = New System.Windows.Forms.TextBox()
    Me.Lnkmfttype = New System.Windows.Forms.LinkLabel()
    Me.txtmftyp = New System.Windows.Forms.TextBox()
    Me.Lnkmftptyp = New System.Windows.Forms.LinkLabel()
    Me.txtmfptyp = New System.Windows.Forms.TextBox()
    Me.gbhistory = New System.Windows.Forms.GroupBox()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.lblclassd = New System.Windows.Forms.Label()
    Me.lblclassfee = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.txtmftel = New System.Windows.Forms.TextBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.txtmfmod = New System.Windows.Forms.TextBox()
    Me.txtmflic = New System.Windows.Forms.TextBox()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.txtmfcap = New System.Windows.Forms.TextBox()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.txtmfcolr = New System.Windows.Forms.TextBox()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.txtmfmake = New System.Windows.Forms.TextBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.txtmfcyr = New System.Windows.Forms.TextBox()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.txtmfvinno = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.BtnGetPrev = New System.Windows.Forms.Button()
    Me.txtmfregno = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.btnprintrenewal = New System.Windows.Forms.Button()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.gbhistory.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'Txtmfcls
    '
    Me.Txtmfcls.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.Txtmfcls.Location = New System.Drawing.Point(98, 19)
    Me.Txtmfcls.MaxLength = 2
    Me.Txtmfcls.Name = "Txtmfcls"
    Me.Txtmfcls.Size = New System.Drawing.Size(28, 20)
    Me.Txtmfcls.TabIndex = 0
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(12, 45)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(69, 16)
    Me.Label2.TabIndex = 28
    Me.Label2.Text = "Name"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtmfnam
    '
    Me.txtmfnam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfnam.Location = New System.Drawing.Point(98, 45)
    Me.txtmfnam.MaxLength = 35
    Me.txtmfnam.Name = "txtmfnam"
    Me.txtmfnam.Size = New System.Drawing.Size(373, 20)
    Me.txtmfnam.TabIndex = 2
    '
    'txtmfyear
    '
    Me.txtmfyear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfyear.Location = New System.Drawing.Point(97, -1)
    Me.txtmfyear.MaxLength = 4
    Me.txtmfyear.Name = "txtmfyear"
    Me.txtmfyear.ReadOnly = True
    Me.txtmfyear.Size = New System.Drawing.Size(60, 20)
    Me.txtmfyear.TabIndex = 30
    Me.txtmfyear.TabStop = False
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(19, 3)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(62, 16)
    Me.Label3.TabIndex = 29
    Me.Label3.Text = "Year"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'txtmfadd1
    '
    Me.txtmfadd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfadd1.Location = New System.Drawing.Point(97, 71)
    Me.txtmfadd1.MaxLength = 35
    Me.txtmfadd1.Name = "txtmfadd1"
    Me.txtmfadd1.Size = New System.Drawing.Size(373, 20)
    Me.txtmfadd1.TabIndex = 3
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(11, 71)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(69, 16)
    Me.Label4.TabIndex = 32
    Me.Label4.Text = "Street 1"
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtmfadd2
    '
    Me.txtmfadd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfadd2.Location = New System.Drawing.Point(97, 97)
    Me.txtmfadd2.MaxLength = 35
    Me.txtmfadd2.Name = "txtmfadd2"
    Me.txtmfadd2.Size = New System.Drawing.Size(373, 20)
    Me.txtmfadd2.TabIndex = 4
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(11, 97)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(69, 16)
    Me.Label5.TabIndex = 34
    Me.Label5.Text = "Street 2"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtmfcity
    '
    Me.txtmfcity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfcity.Location = New System.Drawing.Point(98, 123)
    Me.txtmfcity.MaxLength = 25
    Me.txtmfcity.Name = "txtmfcity"
    Me.txtmfcity.Size = New System.Drawing.Size(186, 20)
    Me.txtmfcity.TabIndex = 5
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(12, 123)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(69, 16)
    Me.Label6.TabIndex = 36
    Me.Label6.Text = "City"
    Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtmfst
    '
    Me.txtmfst.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfst.Location = New System.Drawing.Point(317, 126)
    Me.txtmfst.MaxLength = 2
    Me.txtmfst.Name = "txtmfst"
    Me.txtmfst.Size = New System.Drawing.Size(29, 20)
    Me.txtmfst.TabIndex = 6
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(290, 127)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(21, 16)
    Me.Label7.TabIndex = 38
    Me.Label7.Text = "St"
    Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtmfzip5
    '
    Me.txtmfzip5.Location = New System.Drawing.Point(394, 126)
    Me.txtmfzip5.MaxLength = 5
    Me.txtmfzip5.Name = "txtmfzip5"
    Me.txtmfzip5.Size = New System.Drawing.Size(48, 20)
    Me.txtmfzip5.TabIndex = 7
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(352, 127)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(36, 16)
    Me.Label8.TabIndex = 40
    Me.Label8.Text = "Zip"
    Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtmfzip4
    '
    Me.txtmfzip4.Location = New System.Drawing.Point(448, 126)
    Me.txtmfzip4.MaxLength = 4
    Me.txtmfzip4.Name = "txtmfzip4"
    Me.txtmfzip4.Size = New System.Drawing.Size(48, 20)
    Me.txtmfzip4.TabIndex = 8
    '
    'LnkCls
    '
    Me.LnkCls.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkCls.Location = New System.Drawing.Point(19, 21)
    Me.LnkCls.Name = "LnkCls"
    Me.LnkCls.Size = New System.Drawing.Size(62, 16)
    Me.LnkCls.TabIndex = 237
    Me.LnkCls.TabStop = True
    Me.LnkCls.Text = "Class"
    Me.LnkCls.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label10
    '
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
    Me.Label10.Location = New System.Drawing.Point(9, 23)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(103, 16)
    Me.Label10.TabIndex = 45
    Me.Label10.Text = "Permit Number"
    Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtmfperno
    '
    Me.txtmfperno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtmfperno.Location = New System.Drawing.Point(118, 20)
    Me.txtmfperno.MaxLength = 6
    Me.txtmfperno.Name = "txtmfperno"
    Me.txtmfperno.Size = New System.Drawing.Size(72, 22)
    Me.txtmfperno.TabIndex = 40
    '
    'Label11
    '
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
    Me.Label11.Location = New System.Drawing.Point(198, 20)
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
    Me.DtPckmfliss.Location = New System.Drawing.Point(276, 17)
    Me.DtPckmfliss.Name = "DtPckmfliss"
    Me.DtPckmfliss.Size = New System.Drawing.Size(97, 22)
    Me.DtPckmfliss.TabIndex = 41
    '
    'Label12
    '
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
    Me.Label12.Location = New System.Drawing.Point(23, 115)
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
    Me.txtmfcomm.Location = New System.Drawing.Point(118, 109)
    Me.txtmfcomm.MaxLength = 40
    Me.txtmfcomm.Name = "txtmfcomm"
    Me.txtmfcomm.Size = New System.Drawing.Size(341, 22)
    Me.txtmfcomm.TabIndex = 53
    '
    'lblrepno
    '
    Me.lblrepno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblrepno.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
    Me.lblrepno.Location = New System.Drawing.Point(9, 84)
    Me.lblrepno.Name = "lblrepno"
    Me.lblrepno.Size = New System.Drawing.Size(98, 16)
    Me.lblrepno.TabIndex = 52
    Me.lblrepno.Text = "Replacement Nbr"
    Me.lblrepno.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtmfrepl
    '
    Me.txtmfrepl.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfrepl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtmfrepl.Location = New System.Drawing.Point(118, 81)
    Me.txtmfrepl.MaxLength = 8
    Me.txtmfrepl.Name = "txtmfrepl"
    Me.txtmfrepl.Size = New System.Drawing.Size(83, 22)
    Me.txtmfrepl.TabIndex = 50
    '
    'lblrepd
    '
    Me.lblrepd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblrepd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
    Me.lblrepd.Location = New System.Drawing.Point(232, 84)
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
    Me.dtpckmfrdat.Location = New System.Drawing.Point(357, 81)
    Me.dtpckmfrdat.Name = "dtpckmfrdat"
    Me.dtpckmfrdat.Size = New System.Drawing.Size(97, 22)
    Me.dtpckmfrdat.TabIndex = 51
    '
    'txtmflfee
    '
    Me.txtmflfee.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtmflfee.Location = New System.Drawing.Point(500, 81)
    Me.txtmflfee.MaxLength = 5
    Me.txtmflfee.Name = "txtmflfee"
    Me.txtmflfee.Size = New System.Drawing.Size(67, 22)
    Me.txtmflfee.TabIndex = 52
    '
    'lblfee
    '
    Me.lblfee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblfee.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
    Me.lblfee.Location = New System.Drawing.Point(460, 84)
    Me.lblfee.Name = "lblfee"
    Me.lblfee.Size = New System.Drawing.Size(34, 16)
    Me.lblfee.TabIndex = 56
    Me.lblfee.Text = "Fee"
    Me.lblfee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.txtmftfee)
    Me.GroupBox1.Controls.Add(Me.Lnkmfttype)
    Me.GroupBox1.Controls.Add(Me.txtmftyp)
    Me.GroupBox1.Controls.Add(Me.Lnkmftptyp)
    Me.GroupBox1.Controls.Add(Me.txtmfptyp)
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
    Me.GroupBox1.Location = New System.Drawing.Point(12, 280)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(599, 139)
    Me.GroupBox1.TabIndex = 32
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Current Permit Information"
    '
    'txtmftfee
    '
    Me.txtmftfee.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtmftfee.Location = New System.Drawing.Point(500, 17)
    Me.txtmftfee.MaxLength = 5
    Me.txtmftfee.Name = "txtmftfee"
    Me.txtmftfee.Size = New System.Drawing.Size(67, 22)
    Me.txtmftfee.TabIndex = 242
    Me.txtmftfee.TabStop = False
    Me.txtmftfee.Visible = False
    '
    'Lnkmfttype
    '
    Me.Lnkmfttype.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Lnkmfttype.Location = New System.Drawing.Point(163, 58)
    Me.Lnkmfttype.Name = "Lnkmfttype"
    Me.Lnkmfttype.Size = New System.Drawing.Size(104, 16)
    Me.Lnkmfttype.TabIndex = 901
    Me.Lnkmfttype.TabStop = True
    Me.Lnkmfttype.Text = "Renewal Type"
    Me.Lnkmfttype.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'txtmftyp
    '
    Me.txtmftyp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmftyp.Location = New System.Drawing.Point(276, 52)
    Me.txtmftyp.MaxLength = 2
    Me.txtmftyp.Name = "txtmftyp"
    Me.txtmftyp.Size = New System.Drawing.Size(28, 22)
    Me.txtmftyp.TabIndex = 48
    '
    'Lnkmftptyp
    '
    Me.Lnkmftptyp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Lnkmftptyp.Location = New System.Drawing.Point(30, 55)
    Me.Lnkmftptyp.Name = "Lnkmftptyp"
    Me.Lnkmftptyp.Size = New System.Drawing.Size(62, 16)
    Me.Lnkmftptyp.TabIndex = 900
    Me.Lnkmftptyp.TabStop = True
    Me.Lnkmftptyp.Text = "Pay Type"
    Me.Lnkmftptyp.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'txtmfptyp
    '
    Me.txtmfptyp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfptyp.Location = New System.Drawing.Point(118, 49)
    Me.txtmfptyp.MaxLength = 2
    Me.txtmfptyp.Name = "txtmfptyp"
    Me.txtmfptyp.Size = New System.Drawing.Size(28, 22)
    Me.txtmfptyp.TabIndex = 46
    '
    'gbhistory
    '
    Me.gbhistory.Controls.Add(Me.DataGrdView)
    Me.gbhistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.gbhistory.ForeColor = System.Drawing.Color.Maroon
    Me.gbhistory.Location = New System.Drawing.Point(15, 420)
    Me.gbhistory.Name = "gbhistory"
    Me.gbhistory.Size = New System.Drawing.Size(597, 133)
    Me.gbhistory.TabIndex = 239
    Me.gbhistory.TabStop = False
    Me.gbhistory.Text = "History"
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView.DefaultCellStyle = DataGridViewCellStyle1
    Me.DataGrdView.Location = New System.Drawing.Point(9, 21)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(582, 106)
    Me.DataGrdView.TabIndex = 39
    '
    'lblclassd
    '
    Me.lblclassd.Location = New System.Drawing.Point(132, 21)
    Me.lblclassd.Name = "lblclassd"
    Me.lblclassd.Size = New System.Drawing.Size(275, 16)
    Me.lblclassd.TabIndex = 241
    Me.lblclassd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'lblclassfee
    '
    Me.lblclassfee.Location = New System.Drawing.Point(403, 21)
    Me.lblclassfee.Name = "lblclassfee"
    Me.lblclassfee.Size = New System.Drawing.Size(117, 16)
    Me.lblclassfee.TabIndex = 242
    Me.lblclassfee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(4, 149)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(77, 16)
    Me.Label1.TabIndex = 243
    Me.Label1.Text = "Telephone No"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtmftel
    '
    Me.txtmftel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmftel.Location = New System.Drawing.Point(97, 149)
    Me.txtmftel.MaxLength = 10
    Me.txtmftel.Name = "txtmftel"
    Me.txtmftel.Size = New System.Drawing.Size(186, 20)
    Me.txtmftel.TabIndex = 9
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.txtmfmod)
    Me.GroupBox2.Controls.Add(Me.txtmflic)
    Me.GroupBox2.Controls.Add(Me.Label19)
    Me.GroupBox2.Controls.Add(Me.txtmfcap)
    Me.GroupBox2.Controls.Add(Me.Label18)
    Me.GroupBox2.Controls.Add(Me.txtmfcolr)
    Me.GroupBox2.Controls.Add(Me.Label17)
    Me.GroupBox2.Controls.Add(Me.Label16)
    Me.GroupBox2.Controls.Add(Me.txtmfmake)
    Me.GroupBox2.Controls.Add(Me.Label15)
    Me.GroupBox2.Controls.Add(Me.txtmfcyr)
    Me.GroupBox2.Controls.Add(Me.Label14)
    Me.GroupBox2.Controls.Add(Me.txtmfvinno)
    Me.GroupBox2.Controls.Add(Me.Label13)
    Me.GroupBox2.Controls.Add(Me.BtnGetPrev)
    Me.GroupBox2.Controls.Add(Me.txtmfregno)
    Me.GroupBox2.Controls.Add(Me.Label9)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.ForeColor = System.Drawing.Color.Maroon
    Me.GroupBox2.Location = New System.Drawing.Point(12, 175)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(599, 99)
    Me.GroupBox2.TabIndex = 15
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Motor Vehicle Information"
    '
    'txtmfmod
    '
    Me.txtmfmod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfmod.Location = New System.Drawing.Point(138, 71)
    Me.txtmfmod.MaxLength = 8
    Me.txtmfmod.Name = "txtmfmod"
    Me.txtmfmod.Size = New System.Drawing.Size(90, 22)
    Me.txtmfmod.TabIndex = 27
    '
    'txtmflic
    '
    Me.txtmflic.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmflic.Location = New System.Drawing.Point(424, 73)
    Me.txtmflic.MaxLength = 5
    Me.txtmflic.Name = "txtmflic"
    Me.txtmflic.Size = New System.Drawing.Size(89, 22)
    Me.txtmflic.TabIndex = 31
    '
    'Label19
    '
    Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label19.ForeColor = System.Drawing.Color.Black
    Me.Label19.Location = New System.Drawing.Point(425, 51)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(88, 16)
    Me.Label19.TabIndex = 255
    Me.Label19.Text = "Type License"
    Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'txtmfcap
    '
    Me.txtmfcap.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfcap.Location = New System.Drawing.Point(329, 73)
    Me.txtmfcap.MaxLength = 6
    Me.txtmfcap.Name = "txtmfcap"
    Me.txtmfcap.Size = New System.Drawing.Size(89, 22)
    Me.txtmfcap.TabIndex = 30
    '
    'Label18
    '
    Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label18.ForeColor = System.Drawing.Color.Black
    Me.Label18.Location = New System.Drawing.Point(360, 51)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(58, 16)
    Me.Label18.TabIndex = 253
    Me.Label18.Text = "Capacity"
    Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'txtmfcolr
    '
    Me.txtmfcolr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfcolr.Location = New System.Drawing.Point(234, 73)
    Me.txtmfcolr.MaxLength = 10
    Me.txtmfcolr.Name = "txtmfcolr"
    Me.txtmfcolr.Size = New System.Drawing.Size(89, 22)
    Me.txtmfcolr.TabIndex = 29
    '
    'Label17
    '
    Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label17.ForeColor = System.Drawing.Color.Black
    Me.Label17.Location = New System.Drawing.Point(237, 51)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(69, 16)
    Me.Label17.TabIndex = 251
    Me.Label17.Text = "Color"
    Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label16
    '
    Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label16.ForeColor = System.Drawing.Color.Black
    Me.Label16.Location = New System.Drawing.Point(133, 51)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(69, 16)
    Me.Label16.TabIndex = 249
    Me.Label16.Text = "Model"
    Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'txtmfmake
    '
    Me.txtmfmake.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfmake.Location = New System.Drawing.Point(65, 73)
    Me.txtmfmake.MaxLength = 5
    Me.txtmfmake.Name = "txtmfmake"
    Me.txtmfmake.Size = New System.Drawing.Size(64, 22)
    Me.txtmfmake.TabIndex = 26
    '
    'Label15
    '
    Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label15.ForeColor = System.Drawing.Color.Black
    Me.Label15.Location = New System.Drawing.Point(71, 51)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(41, 16)
    Me.Label15.TabIndex = 247
    Me.Label15.Text = "Make"
    Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'txtmfcyr
    '
    Me.txtmfcyr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfcyr.Location = New System.Drawing.Point(17, 73)
    Me.txtmfcyr.MaxLength = 4
    Me.txtmfcyr.Name = "txtmfcyr"
    Me.txtmfcyr.Size = New System.Drawing.Size(42, 22)
    Me.txtmfcyr.TabIndex = 24
    '
    'Label14
    '
    Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label14.ForeColor = System.Drawing.Color.Black
    Me.Label14.Location = New System.Drawing.Point(16, 51)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(39, 16)
    Me.Label14.TabIndex = 245
    Me.Label14.Text = "Year"
    Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'txtmfvinno
    '
    Me.txtmfvinno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfvinno.Location = New System.Drawing.Point(340, 21)
    Me.txtmfvinno.MaxLength = 17
    Me.txtmfvinno.Name = "txtmfvinno"
    Me.txtmfvinno.Size = New System.Drawing.Size(168, 22)
    Me.txtmfvinno.TabIndex = 22
    '
    'Label13
    '
    Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label13.ForeColor = System.Drawing.Color.Black
    Me.Label13.Location = New System.Drawing.Point(278, 21)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(53, 16)
    Me.Label13.TabIndex = 243
    Me.Label13.Text = "Vin No"
    Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'BtnGetPrev
    '
    Me.BtnGetPrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnGetPrev.ForeColor = System.Drawing.Color.Black
    Me.BtnGetPrev.Location = New System.Drawing.Point(192, 17)
    Me.BtnGetPrev.Name = "BtnGetPrev"
    Me.BtnGetPrev.Size = New System.Drawing.Size(84, 24)
    Me.BtnGetPrev.TabIndex = 241
    Me.BtnGetPrev.TabStop = False
    Me.BtnGetPrev.Text = "Get Prev Yr"
    '
    'txtmfregno
    '
    Me.txtmfregno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmfregno.Location = New System.Drawing.Point(98, 21)
    Me.txtmfregno.MaxLength = 8
    Me.txtmfregno.Name = "txtmfregno"
    Me.txtmfregno.Size = New System.Drawing.Size(89, 22)
    Me.txtmfregno.TabIndex = 20
    '
    'Label9
    '
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.ForeColor = System.Drawing.Color.Black
    Me.Label9.Location = New System.Drawing.Point(12, 21)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(69, 16)
    Me.Label9.TabIndex = 240
    Me.Label9.Text = "MV Reg#"
    Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'btnprintrenewal
    '
    Me.btnprintrenewal.ImageIndex = 1
    Me.btnprintrenewal.ImageList = Me.ImageList1
    Me.btnprintrenewal.Location = New System.Drawing.Point(500, 40)
    Me.btnprintrenewal.Name = "btnprintrenewal"
    Me.btnprintrenewal.Size = New System.Drawing.Size(96, 47)
    Me.btnprintrenewal.TabIndex = 244
    Me.btnprintrenewal.Text = " Print Renewal"
    Me.btnprintrenewal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.btnprintrenewal.UseVisualStyleBackColor = True
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "print_24.png")
    Me.ImageList1.Images.SetKeyName(1, "PRINT.BMP")
    '
    'FrmTS004C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(623, 565)
    Me.Controls.Add(Me.btnprintrenewal)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.txtmftel)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.lblclassfee)
    Me.Controls.Add(Me.lblclassd)
    Me.Controls.Add(Me.gbhistory)
    Me.Controls.Add(Me.LnkCls)
    Me.Controls.Add(Me.GroupBox1)
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
    Me.Controls.Add(Me.Txtmfcls)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTS004C"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.gbhistory.ResumeLayout(False)
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region
Private Sub TS004C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  MyMFTCLS = New MFTCLS.mydata(MyDBConnect)
  MyMFTptyp = New MFTPTYP.mydata(MyDBConnect)
  MyMFTtype = New MFTTYPE.mydata(MyDBConnect)

  myMFTRANL1 = New MFTRANL1.mydata(MyDBConnect)
  myMFTRNH = New MFTRNH.mydata(MyDBConnect)
  myMFTRAN = New MFTRAN.mydata(MyDBConnect)

  MyfrmTS004.TBarNew.Enabled = False
  MyfrmTS004.TBarSave.Enabled = True
  MyfrmTS004.TBarPrint.Enabled = False
  txtmfyear.Text = wrkmfyear
  If Trim(wrkmfnam) <> "" Then
    MyfrmTS004.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(Txtmfcls)
    Txtmfcls.ReadOnly = True
    txtmfnam.ReadOnly = True
    txtmfadd1.ReadOnly = True
    txtmfperno.ReadOnly = True
    DtPckmfliss.Enabled = False
    LnkCls.Enabled = False

  Else
    txtmfrepl.Visible = False
    dtpckmfrdat.Visible = False
    txtmflfee.Visible = False
    lblrepno.Visible = False
    lblrepd.Visible = False
    lblfee.Visible = False
    gbhistory.Visible = False
    btnprintrenewal.Visible = False
  End If
  If wrkmfnam = "" Then
    Me.Text = "Add " & Me.Text
    MyfrmTS004.TBarDelete.Enabled = False
    Exit Sub
    End If
  myMFTRAN.GetOneRecordP(wrkmfyear, wrkmfcatg, wrkmfnam, wrkmfadd1, wrkstampd, wrkstampt)
  If myMFTRAN.RecordNotFound Then Exit Sub
  txtmfyear.Text = wrkmfyear
  Txtmfcls.Text = wrkmfcatg
  txtmfnam.Text = wrkmfnam
  txtmfadd1.Text = wrkmfadd1
 ' txtmfstampd.text = wrkmfstamp
 ' txmfstampt.text = wrkmfstampt

  If s_chg = False And s_full = False Then    '#sec
    MyfrmTS004.TBarSave.Visible = False
  End If

  With myMFTRAN
    txtmfadd2.Text = Trim(._MFADD2)
    txtmfcity.Text = Trim(._MFCITY)
    txtmfst.Text = Trim(._MFST)
    txtmfzip5.Text = Format(._MFZIP5, "00000")
    txtmfzip4.Text = Format(._MFZIP4, "0000")
    txtmfregno.Text = Trim(._MFREGNo)
    txtmfperno.Text = ._MFPERNo
    txtmftel.Text = ._MFTEL
    txtmfvinno.Text = Trim(._MFVINNo)
    txtmfmake.Text = Trim(._MFMAKE)
    txtmfmod.Text = Trim(._MFMOD)
    txtmfcyr.Text = ._MFCYR
    txtmfcolr.Text = Trim(._MFCOLR)
    txtmflic.Text = Trim(._MFLIC)
    txtmfcap.Text = ._MFCAP
    txtmftyp.Text = Trim(._MFTYP)
    txtmfptyp.Text = Trim(._MFPTYP)




    Gettcls()
    Gettptyp()
    Getttype()

    If ._MFLISS > 0 Then
        DtPckmfliss.Value = MyUtils.GetDBDate(._MFLISS)
    End If
   ' txtmfcomm.Text = Trim((._MFCOMM))  
  End With
  HistoryFormatGrid()
  BtnGetPrev.Visible = False
End Sub
Private Sub TS004C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyfrmTS004.SbpScreen.Text = "TS004C"
  If Trim(wrkmfnam) <> "" Then
    txtmfrepl.Focus()
  End If
  MyUtils.CenterForm(Me.ParentForm, Me)

End Sub
Private Sub TS004C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
' added these 3 might not need.
  myMFTRAN = Nothing
  myMFTRANL1 = Nothing
  myMFTRNH = Nothing

  MyfrmTS004.TBarNew.Enabled = True
  MyfrmTS004.TBarDelete.Enabled = False
  MyfrmTS004.TBarSave.Enabled = False
  MyfrmTS004.TBarPrint.Enabled = False
  MyfrmTS004B.FormatGrid()
  MyfrmTS004B.Show()
End Sub
Public Sub DeleteData(ByRef Cancel As Boolean)
  Dim Answer As Integer
  Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
  myMFTRAN.DeleteOneRecordP()
End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String

  myMFTRAN.GetOneRecordP(wrkmfyear, wrkmfcatg, wrkmfnam, wrkmfadd1, wrkstampd, wrkstampt)
  If Not myMFTRAN.RecordNotFound Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MovetoFile()
        myMFTRAN.UpdateOneRecordP()
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
        myMFTRAN.AddOneRecordP()
        WriteToHistory()  ' on add we always write to history
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

  Me.Close()
End Sub
Private Sub MovetoFile()
Dim mydate As String
Dim mytime As String
Dim myTdate As String
  ' for time stamp 
  mydate = Format$(Today, "MMddyyyy")
  mytime = Format$(TimeOfDay, "HHmmss")
  myTdate = Format$(Today, "yyyyMMdd")

  If wrkmfnam = "" Then
    wrkstampd = MyUtils.CnvSng(mydate)
    wrkstampt = MyUtils.CnvSng(mytime)
  End If


  With myMFTRAN
    ._MFADD1 = Trim(txtmfadd1.Text)
    ._MFADD2 = Trim(txtmfadd2.Text)
    ._MFCLS = Trim(Txtmfcls.Text)
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
    ._MFTEL = MyUtils.CnvSng(txtmftel.Text)
    ._MFVINNo = Trim(txtmfvinno.Text)
    ._MFMAKE = Trim(txtmfmake.Text)
    ._MFMOD = Trim(txtmfmod.Text)
    ._MFCYR = MyUtils.CnvSng(txtmfcyr.Text)
    ._MFCOLR = Trim(txtmfcolr.Text)
    ._MFLIC = Trim(txtmflic.Text)
    ._MFCAP = MyUtils.CnvSng(txtmfcap.Text)
    ._MFPTYP = Trim(txtmfptyp.Text)
    ._MFTYP = Trim(txtmftyp.Text)



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
  Dim myTdate As String
  Dim myTtime As String
  myTdate = Format$(Today, "yyyyMMdd")
  myTtime = Format$(TimeOfDay, "HHmmss")
  With myMFTRNH
    ._MFADD1 = Trim(txtmfadd1.Text)
    ._MFCLS = Trim(Txtmfcls.Text)
    ._MFCOMM = Trim(txtmfcomm.Text)
    ._MFLISS = MyUtils.SetDBDate(DtPckmfliss.Value)
    ._MFNAM = Trim(txtmfnam.Text)
    ._MFPERNo = MyUtils.CnvSng(txtmfperno.Text)
    ._MFYEAR = MyUtils.CnvSng(txtmfyear.Text)
    ._STAMPD = wrkstampd
    ._STAMPT = wrkstampt
    ._MFTDAT = MyUtils.CnvSng(myTdate)
    ._MFTTIM = MyUtils.CnvSng(myTtime)
    If Trim(txtmfcomm.Text) = "" Then
      ._MFCOMM = "PERMIT ISSUED"
    End If
' replacement
    If Trim(txtmfrepl.Text) > "" Then
      ._MFPERNo = MyUtils.CnvSng(txtmfrepl.Text)
      ._MFLISS = MyUtils.SetDBDate(dtpckmfrdat.Value)
      ._MFLFEE = MyUtils.CnvSng(txtmflfee.Text)     ' replacement fee
      If Trim(txtmfcomm.Text) = "" Then
        ._MFCOMM = "REPLACEMNET ISSUED"
      End If
    Else
        ._MFLFEE = MyUtils.CnvSng(txtmftfee.Text)    ' base fee from class
    End If

   myMFTRNH.AddOneRecordP()

  End With
End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(Txtmfcls, "")
  ErrProv.SetError(txtmfnam, "")
  ErrProv.SetError(txtmfadd1, "")
  ErrProv.SetError(txtmfperno, "")
  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
    Case "mfcls"
      ErrProv.SetError(Txtmfcls, ErrorMsg(I))
    Case "mfnam"
      ErrProv.SetError(txtmfnam, ErrorMsg(I))
    Case "mfadd1"
      ErrProv.SetError(txtmfadd1, ErrorMsg(I))
    'Case "mfperno"
      'ErrProv.SetError(txtmfperno, ErrorMsg(I))
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

  If Txtmfcls.Text = Trim("") Then
      ErrorField(I) = "mfcls"
      ErrorMsg(I) = "Class Required"
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
  'If txtmfperno.Text = Trim("") Then
  '    ErrorField(I) = "mfperno"
  '    ErrorMsg(I) = "Permit Number required"
  '    I = I + 1
  'End If

End Sub


Private Sub LnkCls_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCls.LinkClicked
  MyfrmListmftcls = New FrmListmftcls
  MyfrmListmftcls.MdiParent = Me.ParentForm
  MyfrmListmftcls.Wrkmftcod = Txtmfcls.Text
  MyfrmListmftcls.Show()
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



Public Sub HistoryFormatGrid()
    Dim Style As DataGridViewCellStyle
    Call ShowGrid()

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      Style = DataGrdView.ColumnHeadersDefaultCellStyle
      Style.Font = New Font(DataGrdView.Font, FontStyle.Regular)
      Style = DataGrdView.DefaultCellStyle
      Style.Font = New Font(DataGrdView.Font, FontStyle.Regular)
      .Columns(0).HeaderText = "Trans Date"
      .Columns(0).DefaultCellStyle.Format = "##/##/####"
      .Columns(0).Width = 100
      .Columns(1).Visible = False
      .Columns(2).HeaderText = "Permit#"
      .Columns(2).Width = 75
      .Columns(3).HeaderText = "Issue Date"
      .Columns(3).Width = 100
      .Columns(4).HeaderText = "Fee"
      .Columns(4).Width = 65
      .Columns(5).HeaderText = "Comment"
      .Columns(5).Width = 200
    End With

  End Sub
  Public Sub ShowGrid()
   ' note wrkstampd and wrkstampt are not TIME stamps for history file.  PArt of key of the MFTRAN file
    dsH = myMFTRNH.GetViewbyPerson(wrkmfyear, wrkmfcatg, wrkmfnam, wrkmfadd1, wrkstampd, wrkstampt)

    DataGrdView.DataSource = dsH.Tables(0)
    DataGrdView.Refresh()
  End Sub

  Private Sub txtmflfee_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmflfee.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub

Private Sub txtmfcyr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmfcyr.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub txtmfcap_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmfcap.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub


Private Sub Lnkmftptyp_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Lnkmftptyp.LinkClicked
MyfrmListmftptyp = New FrmListmftptyp
  MyfrmListmftptyp.MdiParent = Me.ParentForm
  MyfrmListmftptyp.Wrkmfrtyp = txtmfptyp.Text
  MyfrmListmftptyp.Show()
End Sub

Private Sub Lnkmfttype_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Lnkmfttype.LinkClicked
  MyfrmListmfttype = New FrmListmfttype
  MyfrmListmfttype.MdiParent = Me.ParentForm
  MyfrmListmfttype.Wrkmfttyp = txtmftyp.Text
  MyfrmListmfttype.Show()
End Sub

Private Sub BtnGetPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetPrev.Click
  Dim myyear As Integer
Dim myreg As String
  myreg = Trim(txtmfregno.Text)
  myyear = MyUtils.CnvSng(txtmfyear.Text) - 1
  myMFTRANL1.GetOneRecordP(myyear, myreg)
  If myMFTRANL1.RecordNotFound Then
    MsgBox("No previous year data exists for Regno")
    Exit Sub
  End If
  ' should get record back.   i added a 2009  REG1   with name KEN  etc..     I expect ken to get populated
  With myMFTRANL1
    txtmfnam.Text = Trim(._MFNAM)
    txtmfadd1.Text = Trim(._MFADD1)
    txtmfadd2.Text = Trim(._MFADD2)
    txtmfcity.Text = Trim(._MFCITY)
    txtmfst.Text = Trim(._MFST)
    txtmfzip5.Text = ._MFZIP5
    txtmfzip4.Text = ._MFZIP4
    Txtmfcls.Text = Trim(._MFCLS)
    txtmftel.Text = Trim(._MFTEL)
    txtmfcap.Text = ._MFCAP
    txtmfvinno.Text = Trim(._MFVINNo)
    txtmfmake.Text = Trim(._MFMAKE)
    txtmfmod.Text = Trim(._MFMOD)
    txtmfcyr.Text = ._MFCYR
    txtmfcolr.Text = Trim(._MFCOLR)
    txtmflic.Text = Trim(._MFLIC)
    txtmfcap.Text = ._MFCAP
    txtmftyp.Text = Trim(._MFTYP)
    txtmfptyp.Text = Trim(._MFPTYP)



  End With
  'need to populate the fee.  from the table.. TODO
    txtmfperno.Focus()
End Sub
Private Sub Gettcls()
    MyMFTCLS.GetOneRecordP(Trim(Txtmfcls.Text))
    If Not MyMFTCLS.RecordNotFound Then
      With MyMFTCLS
        Me.Ttp1.SetToolTip(Txtmfcls, Trim(._MFTDES))
        lblclassd.Text = Trim(._MFTDES)
        lblclassfee.Text = "Class Fee: " + Format(._MFTFEE, "###.00")
        txtmftfee.Text = ._MFTFEE
      End With
    Else
      lblclassd.Text = "Not Found"
      lblclassfee.Text = ""
      txtmftfee.Text = 0

    End If

End Sub
Private Sub Gettptyp()
    MyMFTptyp.GetOneRecordP(Trim(txtmfptyp.Text))
    If Not MyMFTptyp.RecordNotFound Then
      With MyMFTptyp
        Me.Ttp1.SetToolTip(txtmfptyp, Trim(._MFRDES))

      End With
    Else
      Me.Ttp1.SetToolTip(txtmfptyp, "Not found")

    End If

End Sub
Private Sub Getttype()
    MyMFTptyp.GetOneRecordP(Trim(txtmftyp.Text))
    If Not MyMFTtype.RecordNotFound Then
      With MyMFTtype
        Me.Ttp1.SetToolTip(txtmftyp, Trim(._MFTYPD))

      End With
    Else
      Me.Ttp1.SetToolTip(txtmfptyp, "Not found")

    End If

End Sub

Private Sub txtmfptyp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmfptyp.TextChanged
    Gettptyp()

End Sub

Private Sub txtmftyp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmftyp.TextChanged
    Getttype()
End Sub

Private Sub Txtmfcls_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtmfcls.TextChanged
    Gettcls()
End Sub

Private Sub btnprintrenewal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprintrenewal.Click
  Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If

    Me.Refresh()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    PrintReport.wrkmfyear = wrkmfyear
  PrintReport.wrkmfcatg = wrkmfcatg
  PrintReport.wrkmfnam = wrkmfnam
  PrintReport.wrkmfadd1 = wrkmfadd1
  PrintReport.wrkstampd = wrkstampd
  PrintReport.wrkstampt = wrkstampt


    PrtReport()
    Windows.Forms.Cursor.Current = Cursors.Default
End Sub


End Class






