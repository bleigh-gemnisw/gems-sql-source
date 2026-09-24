Public Class FrmTX304B
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
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents DtPckInt As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents RbSortZip As System.Windows.Forms.RadioButton
  Friend WithEvents RbSortList As System.Windows.Forms.RadioButton
  Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
  Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents DtPckLien As System.Windows.Forms.DateTimePicker
  Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbPrtEdit As System.Windows.Forms.RadioButton
  Friend WithEvents RbPrtBlanket As System.Windows.Forms.RadioButton
  Friend WithEvents RbPrtTownClerk As System.Windows.Forms.RadioButton
  Friend WithEvents RbPrtNotice As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtAddr As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtAltFormID As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents TxtMaxAccts As System.Windows.Forms.TextBox
  Friend WithEvents TxtDist As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TxtOmitStatus As System.Windows.Forms.TextBox
  Friend WithEvents LinkOmitStatus As System.Windows.Forms.LinkLabel
  Friend WithEvents ChkReprint As System.Windows.Forms.CheckBox
  Friend WithEvents TxtPhase As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents TxtOmitBelow As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents LnkAltID As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkStatus As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtStatus As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtMsg As System.Windows.Forms.TextBox
  Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.DtPckInt = New System.Windows.Forms.DateTimePicker()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbSortZip = New System.Windows.Forms.RadioButton()
    Me.RbSortList = New System.Windows.Forms.RadioButton()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
    Me.TxtTypes = New System.Windows.Forms.TextBox()
    Me.LnkTypes = New System.Windows.Forms.LinkLabel()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.DtPckLien = New System.Windows.Forms.DateTimePicker()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbPrtEdit = New System.Windows.Forms.RadioButton()
    Me.RbPrtBlanket = New System.Windows.Forms.RadioButton()
    Me.RbPrtTownClerk = New System.Windows.Forms.RadioButton()
    Me.RbPrtNotice = New System.Windows.Forms.RadioButton()
    Me.ChkPost = New System.Windows.Forms.CheckBox()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.TxtAddr = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtAltFormID = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtMaxAccts = New System.Windows.Forms.TextBox()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtOmitStatus = New System.Windows.Forms.TextBox()
    Me.LinkOmitStatus = New System.Windows.Forms.LinkLabel()
    Me.ChkReprint = New System.Windows.Forms.CheckBox()
    Me.TxtPhase = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.TxtOmitBelow = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.LnkAltID = New System.Windows.Forms.LinkLabel()
    Me.LnkStatus = New System.Windows.Forms.LinkLabel()
    Me.TxtStatus = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtMsg = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.SuspendLayout()
    '
    'TxtGLYear
    '
    Me.TxtGLYear.Location = New System.Drawing.Point(120, 32)
    Me.TxtGLYear.MaxLength = 4
    Me.TxtGLYear.Name = "TxtGLYear"
    Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtGLYear.TabIndex = 1
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(28, 36)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(84, 16)
    Me.Label4.TabIndex = 11
    Me.Label4.Text = "Grand List Year"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'DtPckInt
    '
    Me.DtPckInt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckInt.Location = New System.Drawing.Point(120, 133)
    Me.DtPckInt.Name = "DtPckInt"
    Me.DtPckInt.Size = New System.Drawing.Size(88, 20)
    Me.DtPckInt.TabIndex = 6
    Me.DtPckInt.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(30, 133)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(84, 16)
    Me.Label3.TabIndex = 21
    Me.Label3.Text = "Interest Date"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbSortZip)
    Me.GroupBox2.Controls.Add(Me.RbSortList)
    Me.GroupBox2.Controls.Add(Me.RbSortName)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(428, 8)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(116, 80)
    Me.GroupBox2.TabIndex = 15
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Sort Options"
    '
    'RbSortZip
    '
    Me.RbSortZip.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortZip.Checked = True
    Me.RbSortZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortZip.Location = New System.Drawing.Point(12, 16)
    Me.RbSortZip.Name = "RbSortZip"
    Me.RbSortZip.Size = New System.Drawing.Size(92, 20)
    Me.RbSortZip.TabIndex = 0
    Me.RbSortZip.TabStop = True
    Me.RbSortZip.Text = "Zip/Name"
    '
    'RbSortList
    '
    Me.RbSortList.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortList.Location = New System.Drawing.Point(12, 56)
    Me.RbSortList.Name = "RbSortList"
    Me.RbSortList.Size = New System.Drawing.Size(92, 20)
    Me.RbSortList.TabIndex = 2
    Me.RbSortList.Text = "List #"
    '
    'RbSortName
    '
    Me.RbSortName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortName.Location = New System.Drawing.Point(12, 36)
    Me.RbSortName.Name = "RbSortName"
    Me.RbSortName.Size = New System.Drawing.Size(92, 20)
    Me.RbSortName.TabIndex = 1
    Me.RbSortName.Text = "Name"
    '
    'TxtTypes
    '
    Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTypes.Location = New System.Drawing.Point(120, 8)
    Me.TxtTypes.MaxLength = 20
    Me.TxtTypes.Name = "TxtTypes"
    Me.TxtTypes.Size = New System.Drawing.Size(116, 20)
    Me.TxtTypes.TabIndex = 0
    '
    'LnkTypes
    '
    Me.LnkTypes.Location = New System.Drawing.Point(28, 12)
    Me.LnkTypes.Name = "LnkTypes"
    Me.LnkTypes.Size = New System.Drawing.Size(80, 16)
    Me.LnkTypes.TabIndex = 62
    Me.LnkTypes.TabStop = True
    Me.LnkTypes.Text = "Type to print"
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(238, 137)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(61, 16)
    Me.Label5.TabIndex = 64
    Me.Label5.Text = "Lien Date"
    '
    'DtPckLien
    '
    Me.DtPckLien.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckLien.Location = New System.Drawing.Point(305, 133)
    Me.DtPckLien.Name = "DtPckLien"
    Me.DtPckLien.Size = New System.Drawing.Size(88, 20)
    Me.DtPckLien.TabIndex = 7
    Me.DtPckLien.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbPrtEdit)
    Me.GroupBox1.Controls.Add(Me.RbPrtBlanket)
    Me.GroupBox1.Controls.Add(Me.RbPrtTownClerk)
    Me.GroupBox1.Controls.Add(Me.RbPrtNotice)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(23, 190)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(276, 64)
    Me.GroupBox1.TabIndex = 10
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Print Options"
    '
    'RbPrtEdit
    '
    Me.RbPrtEdit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPrtEdit.Checked = True
    Me.RbPrtEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPrtEdit.Location = New System.Drawing.Point(12, 16)
    Me.RbPrtEdit.Name = "RbPrtEdit"
    Me.RbPrtEdit.Size = New System.Drawing.Size(90, 20)
    Me.RbPrtEdit.TabIndex = 0
    Me.RbPrtEdit.TabStop = True
    Me.RbPrtEdit.Text = "Lien Edit"
    '
    'RbPrtBlanket
    '
    Me.RbPrtBlanket.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPrtBlanket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPrtBlanket.Location = New System.Drawing.Point(144, 40)
    Me.RbPrtBlanket.Name = "RbPrtBlanket"
    Me.RbPrtBlanket.Size = New System.Drawing.Size(120, 20)
    Me.RbPrtBlanket.TabIndex = 3
    Me.RbPrtBlanket.Text = "Blanket Lien Notice"
    '
    'RbPrtTownClerk
    '
    Me.RbPrtTownClerk.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPrtTownClerk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPrtTownClerk.Location = New System.Drawing.Point(144, 16)
    Me.RbPrtTownClerk.Name = "RbPrtTownClerk"
    Me.RbPrtTownClerk.Size = New System.Drawing.Size(120, 20)
    Me.RbPrtTownClerk.TabIndex = 2
    Me.RbPrtTownClerk.Text = "Lien for Town Clerk"
    '
    'RbPrtNotice
    '
    Me.RbPrtNotice.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPrtNotice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPrtNotice.Location = New System.Drawing.Point(12, 36)
    Me.RbPrtNotice.Name = "RbPrtNotice"
    Me.RbPrtNotice.Size = New System.Drawing.Size(90, 20)
    Me.RbPrtNotice.TabIndex = 1
    Me.RbPrtNotice.Text = "Lien Notice"
    '
    'ChkPost
    '
    Me.ChkPost.AutoSize = True
    Me.ChkPost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkPost.Location = New System.Drawing.Point(428, 94)
    Me.ChkPost.Name = "ChkPost"
    Me.ChkPost.Size = New System.Drawing.Size(109, 17)
    Me.ChkPost.TabIndex = 16
    Me.ChkPost.Text = "Post Lien Codes?"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.TxtAddr)
    Me.GroupBox3.Controls.Add(Me.Label2)
    Me.GroupBox3.Controls.Add(Me.TxtName)
    Me.GroupBox3.Controls.Add(Me.Label1)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(23, 305)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(312, 60)
    Me.GroupBox3.TabIndex = 12
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Optional Selections"
    '
    'TxtAddr
    '
    Me.TxtAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAddr.Location = New System.Drawing.Point(52, 34)
    Me.TxtAddr.MaxLength = 35
    Me.TxtAddr.Name = "TxtAddr"
    Me.TxtAddr.Size = New System.Drawing.Size(252, 20)
    Me.TxtAddr.TabIndex = 14
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(9, 37)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(43, 16)
    Me.Label2.TabIndex = 15
    Me.Label2.Text = "Addr"
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(52, 13)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(252, 20)
    Me.TxtName.TabIndex = 12
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(9, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(43, 16)
    Me.Label1.TabIndex = 13
    Me.Label1.Text = "Name"
    '
    'TxtAltFormID
    '
    Me.TxtAltFormID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAltFormID.Location = New System.Drawing.Point(126, 164)
    Me.TxtAltFormID.MaxLength = 1
    Me.TxtAltFormID.Name = "TxtAltFormID"
    Me.TxtAltFormID.Size = New System.Drawing.Size(20, 20)
    Me.TxtAltFormID.TabIndex = 9
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(20, 371)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(120, 13)
    Me.Label7.TabIndex = 71
    Me.Label7.Text = "Maximum # of accounts"
    '
    'TxtMaxAccts
    '
    Me.TxtMaxAccts.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMaxAccts.Location = New System.Drawing.Point(157, 368)
    Me.TxtMaxAccts.MaxLength = 3
    Me.TxtMaxAccts.Name = "TxtMaxAccts"
    Me.TxtMaxAccts.Size = New System.Drawing.Size(30, 20)
    Me.TxtMaxAccts.TabIndex = 13
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(120, 57)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(28, 20)
    Me.TxtDist.TabIndex = 2
    '
    'Label8
    '
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(28, 61)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(44, 16)
    Me.Label8.TabIndex = 73
    Me.Label8.Text = "District"
    '
    'TxtOmitStatus
    '
    Me.TxtOmitStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOmitStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOmitStatus.Location = New System.Drawing.Point(120, 107)
    Me.TxtOmitStatus.MaxLength = 20
    Me.TxtOmitStatus.Name = "TxtOmitStatus"
    Me.TxtOmitStatus.Size = New System.Drawing.Size(129, 20)
    Me.TxtOmitStatus.TabIndex = 5
    '
    'LinkOmitStatus
    '
    Me.LinkOmitStatus.AutoSize = True
    Me.LinkOmitStatus.Location = New System.Drawing.Point(20, 110)
    Me.LinkOmitStatus.Name = "LinkOmitStatus"
    Me.LinkOmitStatus.Size = New System.Drawing.Size(94, 13)
    Me.LinkOmitStatus.TabIndex = 86
    Me.LinkOmitStatus.TabStop = True
    Me.LinkOmitStatus.Text = "Omit Status Codes"
    '
    'ChkReprint
    '
    Me.ChkReprint.AutoSize = True
    Me.ChkReprint.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkReprint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkReprint.Location = New System.Drawing.Point(407, 109)
    Me.ChkReprint.Name = "ChkReprint"
    Me.ChkReprint.Size = New System.Drawing.Size(130, 17)
    Me.ChkReprint.TabIndex = 17
    Me.ChkReprint.Text = "Reprint Posted Liens?"
    '
    'TxtPhase
    '
    Me.TxtPhase.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPhase.Location = New System.Drawing.Point(214, 56)
    Me.TxtPhase.MaxLength = 1
    Me.TxtPhase.Name = "TxtPhase"
    Me.TxtPhase.Size = New System.Drawing.Size(16, 22)
    Me.TxtPhase.TabIndex = 3
    '
    'Label12
    '
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(164, 61)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(44, 14)
    Me.Label12.TabIndex = 88
    Me.Label12.Text = "Phase"
    '
    'Label9
    '
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(7, 413)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(552, 22)
    Me.Label9.TabIndex = 89
    Me.Label9.Text = "NOTICE:  Districts/Phases have to be run seperately if billing dates are differen" &
    "t "
    '
    'TxtOmitBelow
    '
    Me.TxtOmitBelow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOmitBelow.Location = New System.Drawing.Point(157, 390)
    Me.TxtOmitBelow.MaxLength = 6
    Me.TxtOmitBelow.Name = "TxtOmitBelow"
    Me.TxtOmitBelow.Size = New System.Drawing.Size(39, 20)
    Me.TxtOmitBelow.TabIndex = 14
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(25, 392)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(80, 13)
    Me.Label10.TabIndex = 91
    Me.Label10.Text = "Omit Bills below"
    '
    'LnkAltID
    '
    Me.LnkAltID.AutoSize = True
    Me.LnkAltID.Location = New System.Drawing.Point(20, 167)
    Me.LnkAltID.Name = "LnkAltID"
    Me.LnkAltID.Size = New System.Drawing.Size(97, 13)
    Me.LnkAltID.TabIndex = 8
    Me.LnkAltID.TabStop = True
    Me.LnkAltID.Text = "Alternative Form ID"
    '
    'LnkStatus
    '
    Me.LnkStatus.AutoSize = True
    Me.LnkStatus.Location = New System.Drawing.Point(28, 87)
    Me.LnkStatus.Name = "LnkStatus"
    Me.LnkStatus.Size = New System.Drawing.Size(70, 13)
    Me.LnkStatus.TabIndex = 93
    Me.LnkStatus.TabStop = True
    Me.LnkStatus.Text = "Status Codes"
    '
    'TxtStatus
    '
    Me.TxtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtStatus.Location = New System.Drawing.Point(120, 84)
    Me.TxtStatus.MaxLength = 20
    Me.TxtStatus.Name = "TxtStatus"
    Me.TxtStatus.Size = New System.Drawing.Size(129, 20)
    Me.TxtStatus.TabIndex = 4
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(25, 257)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(154, 13)
    Me.Label6.TabIndex = 95
    Me.Label6.Text = "Optional message (Lien Notice)"
    '
    'TxtMsg
    '
    Me.TxtMsg.Location = New System.Drawing.Point(26, 273)
    Me.TxtMsg.MaxLength = 1000
    Me.TxtMsg.Multiline = True
    Me.TxtMsg.Name = "TxtMsg"
    Me.TxtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
    Me.TxtMsg.Size = New System.Drawing.Size(518, 21)
    Me.TxtMsg.TabIndex = 11
    '
    'FrmTX304B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(552, 448)
    Me.ControlBox = False
    Me.Controls.Add(Me.TxtMsg)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.LnkStatus)
    Me.Controls.Add(Me.TxtStatus)
    Me.Controls.Add(Me.LnkAltID)
    Me.Controls.Add(Me.TxtOmitBelow)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.TxtPhase)
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.ChkReprint)
    Me.Controls.Add(Me.TxtOmitStatus)
    Me.Controls.Add(Me.LinkOmitStatus)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TxtMaxAccts)
    Me.Controls.Add(Me.TxtAltFormID)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.ChkPost)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.DtPckLien)
    Me.Controls.Add(Me.TxtTypes)
    Me.Controls.Add(Me.LnkTypes)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.DtPckInt)
    Me.Controls.Add(Me.TxtGLYear)
    Me.Controls.Add(Me.Label4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX304B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Public Sub RunReport()
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
    PrtReport()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub FrmTX304B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    DtPckInt.Value = Date.Today
    DtPckLien.Value = Date.Today
    TxtAltFormID.Text = MyAltFormID
    TxtMsg.Enabled = False
  End Sub
  Private Sub FrmTX304B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTX304.SbpScreen.Text = "TX304B"
  End Sub
  Private Sub LnkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
    MyTypes = TxtTypes.Text
    MyFrmSelTypes = New FrmSelTypes
    MyFrmSelTypes.MdiParent = Me.ParentForm
    MyFrmSelTypes.Show()
  End Sub
  Private Sub FrmTX304B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLYear, "")
    ErrProv.SetError(ChkPost, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "glyear"
          ErrProv.SetError(TxtGLYear, ErrorMsg(I))
        Case "post"
          ErrProv.SetError(ChkPost, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtGLYear.Text) = 0 Then
      ErrorField(I) = "glyear"
      ErrorMsg(I) = "Invalid GL Year"
      I = I + 1
    End If

    If ChkPost.Checked And ChkReprint.Checked Then
      ErrorField(I) = "post"
      ErrorMsg(I) = "Cannot Post & Reprint at same time"
      I = I + 1
    End If

  End Sub

  Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtMaxAccts_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMaxAccts.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub LnkStatus_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkStatus.LinkClicked
    MyFrmSelStatus = New FrmSelStatus
    MyFrmSelStatus.MdiParent = Me.ParentForm
    MyFrmSelStatus.WrkField = "Select"
    MyFrmSelStatus.Show()
  End Sub
  Private Sub LinkOmitStatus_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkOmitStatus.LinkClicked
    MyFrmSelStatus = New FrmSelStatus
    MyFrmSelStatus.MdiParent = Me.ParentForm
    MyFrmSelStatus.WrkField = "Omit"
    MyFrmSelStatus.Show()
  End Sub
  Private Sub ChkReprint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkReprint.Click
    ChkPost.Checked = False
  End Sub
  Private Sub LnkAltID_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkAltID.LinkClicked
    MyFrmListAltID = New FrmListAltID
    MyFrmListAltID.MdiParent = Me.ParentForm
    MyFrmListAltID.Show()
  End Sub
  Private Sub RbPrtEdit_Click(sender As Object, e As EventArgs) Handles RbPrtEdit.Click
    TxtMsg.Enabled = False
  End Sub
  Private Sub RbPrtNotice_Click(sender As Object, e As EventArgs) Handles RbPrtNotice.Click
    TxtMsg.Enabled = True
  End Sub
  Private Sub RbPrtTownClerk_Click(sender As Object, e As EventArgs) Handles RbPrtTownClerk.Click
    TxtMsg.Enabled = False
  End Sub
  Private Sub RbPrtBlanket_Click(sender As Object, e As EventArgs) Handles RbPrtBlanket.Click
    TxtMsg.Enabled = False
  End Sub
End Class






