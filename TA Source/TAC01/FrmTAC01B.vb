Imports System
Imports System.IO
Public Class FrmTAC01B
  Inherits System.Windows.Forms.Form
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents LblFilePath As System.Windows.Forms.Label
  Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
  Friend WithEvents ChkPurchase As System.Windows.Forms.CheckBox
  Friend WithEvents RbCLT As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents RbSortList As System.Windows.Forms.RadioButton
  Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
  Friend WithEvents RbCLT2 As System.Windows.Forms.RadioButton
  Friend WithEvents ChkAddr As System.Windows.Forms.CheckBox
  Friend WithEvents ChkAcreage As System.Windows.Forms.CheckBox
  Friend WithEvents ChkPrtDist As System.Windows.Forms.CheckBox
  Friend WithEvents RbAdmins As RadioButton
  Friend WithEvents GrpName As GroupBox
  Friend WithEvents RbOwnerLast As RadioButton
  Friend WithEvents RbOwnerofRecord As RadioButton
  Friend WithEvents LblPhaseIn As Label
  Friend WithEvents ChkBackup As System.Windows.Forms.CheckBox

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
  Friend WithEvents label3 As System.Windows.Forms.Label
  Friend WithEvents GrpCompany As System.Windows.Forms.GroupBox
  Friend WithEvents RbVision As System.Windows.Forms.RadioButton
  Friend WithEvents RbProVal As System.Windows.Forms.RadioButton
  Friend WithEvents GrpBridge As System.Windows.Forms.GroupBox
  Friend WithEvents rbtxreal As System.Windows.Forms.RadioButton
  Friend WithEvents rbtxpprp As System.Windows.Forms.RadioButton
  Friend WithEvents ChkName As System.Windows.Forms.CheckBox
  Friend WithEvents ChkOther As System.Windows.Forms.CheckBox
  Friend WithEvents ChkExemption As System.Windows.Forms.CheckBox
  Friend WithEvents ChkAssmnt As System.Windows.Forms.CheckBox
  Friend WithEvents GrpUpdate As System.Windows.Forms.GroupBox
  Friend WithEvents ChkAddList As System.Windows.Forms.CheckBox
  Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
  Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
  Friend WithEvents ChkCat As System.Windows.Forms.CheckBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.label3 = New System.Windows.Forms.Label()
    Me.GrpCompany = New System.Windows.Forms.GroupBox()
    Me.RbAdmins = New System.Windows.Forms.RadioButton()
    Me.RbCLT2 = New System.Windows.Forms.RadioButton()
    Me.RbCLT = New System.Windows.Forms.RadioButton()
    Me.RbProVal = New System.Windows.Forms.RadioButton()
    Me.RbVision = New System.Windows.Forms.RadioButton()
    Me.GrpBridge = New System.Windows.Forms.GroupBox()
    Me.rbtxpprp = New System.Windows.Forms.RadioButton()
    Me.rbtxreal = New System.Windows.Forms.RadioButton()
    Me.GrpUpdate = New System.Windows.Forms.GroupBox()
    Me.ChkPrtDist = New System.Windows.Forms.CheckBox()
    Me.ChkAcreage = New System.Windows.Forms.CheckBox()
    Me.ChkPurchase = New System.Windows.Forms.CheckBox()
    Me.ChkCat = New System.Windows.Forms.CheckBox()
    Me.ChkAddList = New System.Windows.Forms.CheckBox()
    Me.ChkAssmnt = New System.Windows.Forms.CheckBox()
    Me.ChkExemption = New System.Windows.Forms.CheckBox()
    Me.ChkOther = New System.Windows.Forms.CheckBox()
    Me.ChkName = New System.Windows.Forms.CheckBox()
    Me.ChkPost = New System.Windows.Forms.CheckBox()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbSortList = New System.Windows.Forms.RadioButton()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
    Me.ChkBackup = New System.Windows.Forms.CheckBox()
    Me.ChkAddr = New System.Windows.Forms.CheckBox()
    Me.GrpName = New System.Windows.Forms.GroupBox()
    Me.RbOwnerLast = New System.Windows.Forms.RadioButton()
    Me.RbOwnerofRecord = New System.Windows.Forms.RadioButton()
    Me.LblPhaseIn = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpCompany.SuspendLayout()
    Me.GrpBridge.SuspendLayout()
    Me.GrpUpdate.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GrpName.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'label3
    '
    Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label3.Location = New System.Drawing.Point(-100, 74)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(100, 23)
    Me.label3.TabIndex = 6
    Me.label3.Text = "New file name"
    Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'GrpCompany
    '
    Me.GrpCompany.Controls.Add(Me.RbAdmins)
    Me.GrpCompany.Controls.Add(Me.RbCLT2)
    Me.GrpCompany.Controls.Add(Me.RbCLT)
    Me.GrpCompany.Controls.Add(Me.RbProVal)
    Me.GrpCompany.Controls.Add(Me.RbVision)
    Me.GrpCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpCompany.ForeColor = System.Drawing.Color.Blue
    Me.GrpCompany.Location = New System.Drawing.Point(40, 25)
    Me.GrpCompany.Name = "GrpCompany"
    Me.GrpCompany.Size = New System.Drawing.Size(184, 118)
    Me.GrpCompany.TabIndex = 0
    Me.GrpCompany.TabStop = False
    Me.GrpCompany.Text = "Company Used"
    '
    'RbAdmins
    '
    Me.RbAdmins.AutoSize = True
    Me.RbAdmins.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbAdmins.ForeColor = System.Drawing.Color.Black
    Me.RbAdmins.Location = New System.Drawing.Point(15, 99)
    Me.RbAdmins.Name = "RbAdmins"
    Me.RbAdmins.Size = New System.Drawing.Size(59, 17)
    Me.RbAdmins.TabIndex = 15
    Me.RbAdmins.Text = "Admins"
    '
    'RbCLT2
    '
    Me.RbCLT2.AutoSize = True
    Me.RbCLT2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCLT2.ForeColor = System.Drawing.Color.Black
    Me.RbCLT2.Location = New System.Drawing.Point(15, 80)
    Me.RbCLT2.Name = "RbCLT2"
    Me.RbCLT2.Size = New System.Drawing.Size(102, 17)
    Me.RbCLT2.TabIndex = 14
    Me.RbCLT2.Text = "CLT (IAS World)"
    '
    'RbCLT
    '
    Me.RbCLT.AutoSize = True
    Me.RbCLT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCLT.ForeColor = System.Drawing.Color.Black
    Me.RbCLT.Location = New System.Drawing.Point(15, 61)
    Me.RbCLT.Name = "RbCLT"
    Me.RbCLT.Size = New System.Drawing.Size(90, 17)
    Me.RbCLT.TabIndex = 13
    Me.RbCLT.Text = "CLT (Univers)"
    '
    'RbProVal
    '
    Me.RbProVal.AutoSize = True
    Me.RbProVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbProVal.ForeColor = System.Drawing.Color.Black
    Me.RbProVal.Location = New System.Drawing.Point(15, 42)
    Me.RbProVal.Name = "RbProVal"
    Me.RbProVal.Size = New System.Drawing.Size(56, 17)
    Me.RbProVal.TabIndex = 12
    Me.RbProVal.Text = "ProVal"
    '
    'RbVision
    '
    Me.RbVision.AutoSize = True
    Me.RbVision.Checked = True
    Me.RbVision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbVision.ForeColor = System.Drawing.Color.Black
    Me.RbVision.Location = New System.Drawing.Point(15, 23)
    Me.RbVision.Name = "RbVision"
    Me.RbVision.Size = New System.Drawing.Size(53, 17)
    Me.RbVision.TabIndex = 11
    Me.RbVision.TabStop = True
    Me.RbVision.Text = "Vision"
    '
    'GrpBridge
    '
    Me.GrpBridge.Controls.Add(Me.rbtxpprp)
    Me.GrpBridge.Controls.Add(Me.rbtxreal)
    Me.GrpBridge.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpBridge.ForeColor = System.Drawing.Color.Blue
    Me.GrpBridge.Location = New System.Drawing.Point(272, 17)
    Me.GrpBridge.Name = "GrpBridge"
    Me.GrpBridge.Size = New System.Drawing.Size(176, 67)
    Me.GrpBridge.TabIndex = 1
    Me.GrpBridge.TabStop = False
    Me.GrpBridge.Text = "Data to Bridge"
    '
    'rbtxpprp
    '
    Me.rbtxpprp.Enabled = False
    Me.rbtxpprp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.rbtxpprp.ForeColor = System.Drawing.SystemColors.ControlText
    Me.rbtxpprp.Location = New System.Drawing.Point(20, 42)
    Me.rbtxpprp.Name = "rbtxpprp"
    Me.rbtxpprp.Size = New System.Drawing.Size(133, 20)
    Me.rbtxpprp.TabIndex = 1
    Me.rbtxpprp.Text = "Personal Property"
    Me.rbtxpprp.Visible = False
    '
    'rbtxreal
    '
    Me.rbtxreal.Checked = True
    Me.rbtxreal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.rbtxreal.ForeColor = System.Drawing.SystemColors.ControlText
    Me.rbtxreal.Location = New System.Drawing.Point(20, 21)
    Me.rbtxreal.Name = "rbtxreal"
    Me.rbtxreal.Size = New System.Drawing.Size(133, 20)
    Me.rbtxreal.TabIndex = 0
    Me.rbtxreal.TabStop = True
    Me.rbtxreal.Text = "Real Estate"
    '
    'GrpUpdate
    '
    Me.GrpUpdate.Controls.Add(Me.ChkPrtDist)
    Me.GrpUpdate.Controls.Add(Me.ChkAcreage)
    Me.GrpUpdate.Controls.Add(Me.ChkPurchase)
    Me.GrpUpdate.Controls.Add(Me.ChkCat)
    Me.GrpUpdate.Controls.Add(Me.ChkAddList)
    Me.GrpUpdate.Controls.Add(Me.ChkAssmnt)
    Me.GrpUpdate.Controls.Add(Me.ChkExemption)
    Me.GrpUpdate.Controls.Add(Me.ChkOther)
    Me.GrpUpdate.Controls.Add(Me.ChkName)
    Me.GrpUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpUpdate.ForeColor = System.Drawing.Color.Blue
    Me.GrpUpdate.Location = New System.Drawing.Point(40, 149)
    Me.GrpUpdate.Name = "GrpUpdate"
    Me.GrpUpdate.Size = New System.Drawing.Size(604, 126)
    Me.GrpUpdate.TabIndex = 3
    Me.GrpUpdate.TabStop = False
    Me.GrpUpdate.Text = "Data to Update"
    '
    'ChkPrtDist
    '
    Me.ChkPrtDist.AutoSize = True
    Me.ChkPrtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkPrtDist.ForeColor = System.Drawing.SystemColors.ControlText
    Me.ChkPrtDist.Location = New System.Drawing.Point(458, 21)
    Me.ChkPrtDist.Name = "ChkPrtDist"
    Me.ChkPrtDist.Size = New System.Drawing.Size(82, 17)
    Me.ChkPrtDist.TabIndex = 8
    Me.ChkPrtDist.Text = "Print District"
    '
    'ChkAcreage
    '
    Me.ChkAcreage.AutoSize = True
    Me.ChkAcreage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkAcreage.ForeColor = System.Drawing.SystemColors.ControlText
    Me.ChkAcreage.Location = New System.Drawing.Point(20, 69)
    Me.ChkAcreage.Name = "ChkAcreage"
    Me.ChkAcreage.Size = New System.Drawing.Size(66, 17)
    Me.ChkAcreage.TabIndex = 7
    Me.ChkAcreage.Text = "Acreage"
    '
    'ChkPurchase
    '
    Me.ChkPurchase.AutoSize = True
    Me.ChkPurchase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkPurchase.ForeColor = System.Drawing.SystemColors.ControlText
    Me.ChkPurchase.Location = New System.Drawing.Point(458, 42)
    Me.ChkPurchase.Name = "ChkPurchase"
    Me.ChkPurchase.Size = New System.Drawing.Size(126, 17)
    Me.ChkPurchase.TabIndex = 5
    Me.ChkPurchase.Text = "Purchase Price/Date"
    '
    'ChkCat
    '
    Me.ChkCat.AutoSize = True
    Me.ChkCat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkCat.ForeColor = System.Drawing.SystemColors.ControlText
    Me.ChkCat.Location = New System.Drawing.Point(262, 67)
    Me.ChkCat.Name = "ChkCat"
    Me.ChkCat.Size = New System.Drawing.Size(136, 17)
    Me.ChkCat.TabIndex = 4
    Me.ChkCat.Text = "Category/Exempt Code"
    '
    'ChkAddList
    '
    Me.ChkAddList.AutoSize = True
    Me.ChkAddList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkAddList.ForeColor = System.Drawing.SystemColors.ControlText
    Me.ChkAddList.Location = New System.Drawing.Point(20, 98)
    Me.ChkAddList.Name = "ChkAddList"
    Me.ChkAddList.Size = New System.Drawing.Size(413, 17)
    Me.ChkAddList.TabIndex = 6
    Me.ChkAddList.Text = "Add Missing List#'s (Category must also be checked to add Tax Exempt accounts)"
    '
    'ChkAssmnt
    '
    Me.ChkAssmnt.AutoSize = True
    Me.ChkAssmnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkAssmnt.ForeColor = System.Drawing.SystemColors.ControlText
    Me.ChkAssmnt.Location = New System.Drawing.Point(262, 21)
    Me.ChkAssmnt.Name = "ChkAssmnt"
    Me.ChkAssmnt.Size = New System.Drawing.Size(82, 17)
    Me.ChkAssmnt.TabIndex = 1
    Me.ChkAssmnt.Text = "Assessment"
    '
    'ChkExemption
    '
    Me.ChkExemption.AutoSize = True
    Me.ChkExemption.Enabled = False
    Me.ChkExemption.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkExemption.ForeColor = System.Drawing.SystemColors.ControlText
    Me.ChkExemption.Location = New System.Drawing.Point(262, 44)
    Me.ChkExemption.Name = "ChkExemption"
    Me.ChkExemption.Size = New System.Drawing.Size(80, 17)
    Me.ChkExemption.TabIndex = 2
    Me.ChkExemption.Text = "Exemptions"
    '
    'ChkOther
    '
    Me.ChkOther.AutoSize = True
    Me.ChkOther.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkOther.ForeColor = System.Drawing.SystemColors.ControlText
    Me.ChkOther.Location = New System.Drawing.Point(20, 46)
    Me.ChkOther.Name = "ChkOther"
    Me.ChkOther.Size = New System.Drawing.Size(209, 17)
    Me.ChkOther.TabIndex = 3
    Me.ChkOther.Text = "Other (Map,Location,Volume/Page,....)"
    '
    'ChkName
    '
    Me.ChkName.AutoSize = True
    Me.ChkName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkName.ForeColor = System.Drawing.SystemColors.ControlText
    Me.ChkName.Location = New System.Drawing.Point(20, 21)
    Me.ChkName.Name = "ChkName"
    Me.ChkName.Size = New System.Drawing.Size(116, 17)
    Me.ChkName.TabIndex = 0
    Me.ChkName.Text = "Name and Address"
    '
    'ChkPost
    '
    Me.ChkPost.Location = New System.Drawing.Point(40, 366)
    Me.ChkPost.Name = "ChkPost"
    Me.ChkPost.Size = New System.Drawing.Size(192, 36)
    Me.ChkPost.TabIndex = 5
    Me.ChkPost.Text = "Post Records To Assessor File"
    '
    'OpenFileDialog1
    '
    Me.OpenFileDialog1.Title = "Select File to Import"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LblFilePath)
    Me.GroupBox1.Controls.Add(Me.LnkFilePath)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(40, 281)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(408, 56)
    Me.GroupBox1.TabIndex = 4
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "CAMA Details"
    '
    'LblFilePath
    '
    Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePath.Name = "LblFilePath"
    Me.LblFilePath.Size = New System.Drawing.Size(324, 36)
    Me.LblFilePath.TabIndex = 67
    '
    'LnkFilePath
    '
    Me.LnkFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePath.Location = New System.Drawing.Point(12, 24)
    Me.LnkFilePath.Name = "LnkFilePath"
    Me.LnkFilePath.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePath.TabIndex = 65
    Me.LnkFilePath.TabStop = True
    Me.LnkFilePath.Text = "File Path"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbSortList)
    Me.GroupBox2.Controls.Add(Me.RbSortName)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox2.Location = New System.Drawing.Point(509, 17)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(135, 78)
    Me.GroupBox2.TabIndex = 2
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Report Order"
    '
    'RbSortList
    '
    Me.RbSortList.Checked = True
    Me.RbSortList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortList.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbSortList.Location = New System.Drawing.Point(20, 28)
    Me.RbSortList.Name = "RbSortList"
    Me.RbSortList.Size = New System.Drawing.Size(70, 20)
    Me.RbSortList.TabIndex = 0
    Me.RbSortList.TabStop = True
    Me.RbSortList.Text = "List #"
    '
    'RbSortName
    '
    Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortName.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbSortName.Location = New System.Drawing.Point(20, 54)
    Me.RbSortName.Name = "RbSortName"
    Me.RbSortName.Size = New System.Drawing.Size(106, 20)
    Me.RbSortName.TabIndex = 1
    Me.RbSortName.Text = "Name (Current)"
    '
    'ChkBackup
    '
    Me.ChkBackup.Location = New System.Drawing.Point(261, 366)
    Me.ChkBackup.Name = "ChkBackup"
    Me.ChkBackup.Size = New System.Drawing.Size(255, 36)
    Me.ChkBackup.TabIndex = 69
    Me.ChkBackup.Text = "Create a Backup file? (CAMREAL/CAMPPRP)"
    '
    'ChkAddr
    '
    Me.ChkAddr.Location = New System.Drawing.Point(40, 343)
    Me.ChkAddr.Name = "ChkAddr"
    Me.ChkAddr.Size = New System.Drawing.Size(263, 24)
    Me.ChkAddr.TabIndex = 70
    Me.ChkAddr.Text = "Show address line on missing CAMA report?"
    '
    'GrpName
    '
    Me.GrpName.Controls.Add(Me.RbOwnerLast)
    Me.GrpName.Controls.Add(Me.RbOwnerofRecord)
    Me.GrpName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpName.ForeColor = System.Drawing.Color.Blue
    Me.GrpName.Location = New System.Drawing.Point(272, 86)
    Me.GrpName.Name = "GrpName"
    Me.GrpName.Size = New System.Drawing.Size(176, 67)
    Me.GrpName.TabIndex = 71
    Me.GrpName.TabStop = False
    Me.GrpName.Text = "Owner Name"
    '
    'RbOwnerLast
    '
    Me.RbOwnerLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbOwnerLast.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbOwnerLast.Location = New System.Drawing.Point(20, 42)
    Me.RbOwnerLast.Name = "RbOwnerLast"
    Me.RbOwnerLast.Size = New System.Drawing.Size(133, 20)
    Me.RbOwnerLast.TabIndex = 1
    Me.RbOwnerLast.Text = "Last Sales Owner"
    '
    'RbOwnerofRecord
    '
    Me.RbOwnerofRecord.Checked = True
    Me.RbOwnerofRecord.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbOwnerofRecord.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbOwnerofRecord.Location = New System.Drawing.Point(20, 21)
    Me.RbOwnerofRecord.Name = "RbOwnerofRecord"
    Me.RbOwnerofRecord.Size = New System.Drawing.Size(133, 20)
    Me.RbOwnerofRecord.TabIndex = 0
    Me.RbOwnerofRecord.TabStop = True
    Me.RbOwnerofRecord.Text = "Owner of Record"
    '
    'LblPhaseIn
    '
    Me.LblPhaseIn.AutoSize = True
    Me.LblPhaseIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPhaseIn.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblPhaseIn.Location = New System.Drawing.Point(65, 9)
    Me.LblPhaseIn.Name = "LblPhaseIn"
    Me.LblPhaseIn.Size = New System.Drawing.Size(57, 13)
    Me.LblPhaseIn.TabIndex = 72
    Me.LblPhaseIn.Text = "Phase In"
    '
    'FrmTAC01B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(663, 412)
    Me.ControlBox = False
    Me.Controls.Add(Me.LblPhaseIn)
    Me.Controls.Add(Me.GrpName)
    Me.Controls.Add(Me.ChkAddr)
    Me.Controls.Add(Me.ChkBackup)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.GrpUpdate)
    Me.Controls.Add(Me.ChkPost)
    Me.Controls.Add(Me.GrpBridge)
    Me.Controls.Add(Me.GrpCompany)
    Me.Controls.Add(Me.label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTAC01B"
    Me.Text = "Cama Bridge"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpCompany.ResumeLayout(False)
    Me.GrpCompany.PerformLayout()
    Me.GrpBridge.ResumeLayout(False)
    Me.GrpUpdate.ResumeLayout(False)
    Me.GrpUpdate.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.GrpName.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub TAC01B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    LblPhaseIn.Visible = False
    If MyPhaseIn Then
      LblPhaseIn.Visible = True
    End If
    GrpName.Visible = False
    With MyAppSettings
      Select Case .Company
        Case "Admins"
          RbAdmins.Checked = True
        Case "CLT"
          RbCLT.Checked = True
        Case "CLT2"
          RbCLT2.Checked = True
        Case "ProVal"
          RbProVal.Checked = True
        Case "Vision"
          RbVision.Checked = True
          GrpName.Visible = True
      End Select
      If .Acreage Then
        ChkAcreage.Checked = True
      End If
      If .Add Then
        ChkAddList.Checked = True
      End If
      If .Address Then
        ChkAddr.Checked = True
      End If
      If .Assmnt Then
        ChkAssmnt.Checked = True
      End If
      If .Category Then
        ChkCat.Checked = True
      End If
      If .Exemption Then
        ChkExemption.Checked = True
      End If
      If .Name Then
        ChkName.Checked = True
      End If
      If .Other Then
        ChkOther.Checked = True
      End If
      If .Purchase Then
        ChkPurchase.Checked = True
      End If
      If .PrtDist Then
        ChkPrtDist.Checked = True
      End If
      LblFilePath.Text = .FilePath
      ChkBackup.Enabled = False
    End With
  End Sub

  Private Sub TAC01B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAC01.SbpScreen.Text = "TAC01B"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub RunData()

    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If

    If rbtxreal.Checked = True Then
      Windows.Forms.Cursor.Current = Cursors.WaitCursor
      Application.DoEvents()
      PrtReportRE()
      Windows.Forms.Cursor.Current = Cursors.Default
    End If
    If rbtxpprp.Checked = True Then
      Windows.Forms.Cursor.Current = Cursors.WaitCursor
      Application.DoEvents()
      PrtReportPP()
      Windows.Forms.Cursor.Current = Cursors.Default
    End If

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "path"
          ErrProv.SetError(LblFilePath, ErrorMsg(I))
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

    If LblFilePath.Text = "" Then
      ErrorField(I) = "path"
      ErrorMsg(I) = "File Path cannot be blank. Click on link to set."
      I = I + 1
    End If

  End Sub
  Private Sub FrmTAC01B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If Not e.Alt Then Exit Sub

    If e.KeyCode = Keys.F12 Then
      MyUtils.PrtScreen(Form.ActiveForm)
    End If
  End Sub
  Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
    With OpenFileDialog1
      .ReadOnlyChecked = True
      .ShowDialog()
      LblFilePath.Text = .FileName
    End With
  End Sub
  Private Sub rbtxpprp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtxpprp.Click
    GrpName.Visible = False
    ChkExemption.Enabled = False
    ChkExemption.Checked = False
    ChkCat.Enabled = False
    ChkCat.Checked = False
    ChkAcreage.Enabled = False
    ChkAcreage.Checked = False
    ChkPurchase.Enabled = False
    ChkPurchase.Checked = False
    ChkPrtDist.Enabled = False
    ChkPrtDist.Checked = False
  End Sub
  Private Sub rbtxreal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtxreal.Click
    If RbVision.Checked Then
      GrpName.Visible = True
    End If
    ChkExemption.Enabled = True
    If RbProVal.Checked Then
      ChkCat.Enabled = True
    End If
    ChkPurchase.Enabled = True
    ChkAcreage.Enabled = True
    SetREOptions()
  End Sub

  Private Sub RbVision_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbVision.Click
    GrpName.Visible = True
    rbtxpprp.Enabled = True
    If myTOWN._TOWNBR = 32 Then
      ChkCat.Enabled = True
      ChkCat.Checked = True
    Else
      ChkCat.Enabled = False
      ChkCat.Checked = False
    End If
    ChkExemption.Enabled = True
    ChkPurchase.Enabled = True
    ChkPrtDist.Enabled = True
  End Sub
  Private Sub RbProVal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbProVal.Click
    GrpName.Visible = False
    rbtxpprp.Enabled = False
    rbtxreal.Checked = True
    ChkCat.Enabled = True
    ChkExemption.Enabled = True
    ChkPurchase.Enabled = True
    ChkPrtDist.Enabled = False
  End Sub
  Private Sub RbCLT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbCLT.Click
    GrpName.Visible = False
    rbtxpprp.Enabled = False
    rbtxreal.Checked = True
    ChkCat.Enabled = False
    ChkCat.Checked = False
    ChkExemption.Enabled = False
    ChkExemption.Checked = False
    ChkPurchase.Enabled = True
    ChkPrtDist.Enabled = False
  End Sub
  Private Sub RbCLT2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbCLT2.Click
    GrpName.Visible = False
    rbtxpprp.Enabled = False
    rbtxreal.Checked = True
    ChkCat.Enabled = False
    ChkCat.Checked = False
    ChkExemption.Enabled = False
    ChkExemption.Checked = False
    ChkPurchase.Enabled = False
    ChkPurchase.Checked = False
  End Sub
  Private Sub ChkPost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkPost.Click
    ChkBackup.Enabled = Not ChkBackup.Enabled
  End Sub
  Private Sub SetREOptions()
    If RbVision.Checked Then
      ChkCat.Enabled = False
      ChkCat.Checked = False
    End If
    If RbProVal.Checked Then
      ChkCat.Enabled = True
    End If
    If RbCLT.Checked Then
      ChkCat.Enabled = False
      ChkCat.Checked = False
      ChkExemption.Enabled = False
      ChkExemption.Checked = False
    End If
    If RbCLT2.Checked Then
      ChkCat.Enabled = False
      ChkCat.Checked = False
      ChkExemption.Enabled = False
      ChkExemption.Checked = False
      ChkPurchase.Enabled = False
      ChkPurchase.Checked = False
    End If
  End Sub
  Public Sub SaveSettings()
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
    Dim sw As IO.StreamWriter
    Dim WrkProgName As String
    Dim WrkXMLPath As String

    With MyAppSettings
      If RbVision.Checked Then
        .Company = "Vision"
      End If
      If RbProVal.Checked Then
        .Company = "ProVal"
      End If
      If RbCLT.Checked Then
        .Company = "CLT"
      End If
      If RbCLT2.Checked Then
        .Company = "CLT2"
      End If
      If RbAdmins.Checked Then
        .Company = "Admins"
      End If
      .Acreage = ChkAcreage.Checked
      .Assmnt = ChkAssmnt.Checked
      .Add = ChkAddList.Checked
      .Address = ChkAddr.Checked
      .Category = ChkCat.Checked
      .Exemption = ChkExemption.Checked
      .Name = ChkName.Checked
      .Other = ChkOther.Checked
      .Purchase = ChkPurchase.Checked
      .PrtDist = ChkPrtDist.Checked
      .FilePath = LblFilePath.Text
    End With

    WrkProgName = Replace(MyUtils.GetProgramName, ".exe", "")
    WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & " " & MyUtils.GetComputerName() & ".xml"
    sw = New IO.StreamWriter(WrkXMLPath)
    xs.Serialize(sw, MyAppSettings)
    sw.Close()
  End Sub

  Private Sub ChkPrtDist_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkPrtDist.Click
    If Not myTOWN._TOWNBR = 45 Then
      MsgBox("Contact hotline for help", MsgBoxStyle.Exclamation, "This option is not configured")
      ChkPrtDist.Checked = False
    End If
  End Sub

End Class






