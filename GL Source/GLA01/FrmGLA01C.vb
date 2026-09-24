Public Class FrmGLA01C
	Inherits System.Windows.Forms.Form
	Dim myTXGL As TXGL.myData
	Dim myGLACCT As GLACCT.myData
	Dim ds As DataSet = New DataSet
	Friend WrkYear As Integer
	Friend WrkType As String
	Friend WrkCode As String
	Friend WrkSusp As String
	Friend WrkDist As Integer
	Friend WrkPhs As String
 Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
 Friend WithEvents LnkGLAcctRD As System.Windows.Forms.LinkLabel
 Friend WithEvents LnkGLAcctRC As System.Windows.Forms.LinkLabel
 Friend WithEvents TxtSfcnRD As System.Windows.Forms.TextBox
 Friend WithEvents TxtFcnRD As System.Windows.Forms.TextBox
 Friend WithEvents TxtObjRD As System.Windows.Forms.TextBox
 Friend WithEvents TxtDptRD As System.Windows.Forms.TextBox
 Friend WithEvents TxtSfndRD As System.Windows.Forms.TextBox
 Friend WithEvents TxtSfcnRC As System.Windows.Forms.TextBox
 Friend WithEvents TxtFcnRC As System.Windows.Forms.TextBox
 Friend WithEvents TxtObjRC As System.Windows.Forms.TextBox
 Friend WithEvents TxtDptRC As System.Windows.Forms.TextBox
 Friend WithEvents TxtSfndRC As System.Windows.Forms.TextBox
 Friend WithEvents TxtFndRD As System.Windows.Forms.TextBox
 Friend WithEvents TxtFndRC As System.Windows.Forms.TextBox
 Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
 Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
 Friend WithEvents LnkGLAcctLD As System.Windows.Forms.LinkLabel
 Friend WithEvents LnkGLAcctLC As System.Windows.Forms.LinkLabel
 Friend WithEvents TxtSfcnLD As System.Windows.Forms.TextBox
 Friend WithEvents TxtFcnLD As System.Windows.Forms.TextBox
 Friend WithEvents TxtObjLD As System.Windows.Forms.TextBox
 Friend WithEvents TxtDptLD As System.Windows.Forms.TextBox
 Friend WithEvents TxtSfndLD As System.Windows.Forms.TextBox
 Friend WithEvents TxtSfcnLC As System.Windows.Forms.TextBox
 Friend WithEvents TxtFcnLC As System.Windows.Forms.TextBox
 Friend WithEvents TxtObjLC As System.Windows.Forms.TextBox
 Friend WithEvents TxtDptLC As System.Windows.Forms.TextBox
 Friend WithEvents TxtSfndLC As System.Windows.Forms.TextBox
 Friend WithEvents TxtFndLD As System.Windows.Forms.TextBox
 Friend WithEvents TxtFndLC As System.Windows.Forms.TextBox
 Friend WithEvents ChkSusp As System.Windows.Forms.CheckBox
 Friend WithEvents Label5 As System.Windows.Forms.Label
 Friend WithEvents TxtCode As System.Windows.Forms.TextBox
 Friend WithEvents Label4 As System.Windows.Forms.Label
 Friend WithEvents TxtDist As System.Windows.Forms.TextBox
 Friend WithEvents TxtPhs As System.Windows.Forms.TextBox
 Friend WithEvents Label2 As System.Windows.Forms.Label
 Friend WithEvents TxtYear As System.Windows.Forms.TextBox
 Friend WithEvents TxtType As System.Windows.Forms.TextBox
 Friend WithEvents Label3 As System.Windows.Forms.Label
 Friend WithEvents Label1 As System.Windows.Forms.Label
 Friend WrkCopyMode As Boolean

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
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.LnkGLAcctRD = New System.Windows.Forms.LinkLabel
Me.LnkGLAcctRC = New System.Windows.Forms.LinkLabel
Me.TxtSfcnRD = New System.Windows.Forms.TextBox
Me.TxtFcnRD = New System.Windows.Forms.TextBox
Me.TxtObjRD = New System.Windows.Forms.TextBox
Me.TxtDptRD = New System.Windows.Forms.TextBox
Me.TxtSfndRD = New System.Windows.Forms.TextBox
Me.TxtSfcnRC = New System.Windows.Forms.TextBox
Me.TxtFcnRC = New System.Windows.Forms.TextBox
Me.TxtObjRC = New System.Windows.Forms.TextBox
Me.TxtDptRC = New System.Windows.Forms.TextBox
Me.TxtSfndRC = New System.Windows.Forms.TextBox
Me.TxtFndRD = New System.Windows.Forms.TextBox
Me.TxtFndRC = New System.Windows.Forms.TextBox
Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.GroupBox2 = New System.Windows.Forms.GroupBox
Me.LnkGLAcctLD = New System.Windows.Forms.LinkLabel
Me.LnkGLAcctLC = New System.Windows.Forms.LinkLabel
Me.TxtSfcnLD = New System.Windows.Forms.TextBox
Me.TxtFcnLD = New System.Windows.Forms.TextBox
Me.TxtObjLD = New System.Windows.Forms.TextBox
Me.TxtDptLD = New System.Windows.Forms.TextBox
Me.TxtSfndLD = New System.Windows.Forms.TextBox
Me.TxtSfcnLC = New System.Windows.Forms.TextBox
Me.TxtFcnLC = New System.Windows.Forms.TextBox
Me.TxtObjLC = New System.Windows.Forms.TextBox
Me.TxtDptLC = New System.Windows.Forms.TextBox
Me.TxtSfndLC = New System.Windows.Forms.TextBox
Me.TxtFndLD = New System.Windows.Forms.TextBox
Me.TxtFndLC = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
Me.TxtType = New System.Windows.Forms.TextBox
Me.TxtYear = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.TxtPhs = New System.Windows.Forms.TextBox
Me.TxtDist = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.TxtCode = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
Me.ChkSusp = New System.Windows.Forms.CheckBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox1.SuspendLayout()
Me.GroupBox2.SuspendLayout()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.LnkGLAcctRD)
Me.GroupBox1.Controls.Add(Me.LnkGLAcctRC)
Me.GroupBox1.Controls.Add(Me.TxtSfcnRD)
Me.GroupBox1.Controls.Add(Me.TxtFcnRD)
Me.GroupBox1.Controls.Add(Me.TxtObjRD)
Me.GroupBox1.Controls.Add(Me.TxtDptRD)
Me.GroupBox1.Controls.Add(Me.TxtSfndRD)
Me.GroupBox1.Controls.Add(Me.TxtSfcnRC)
Me.GroupBox1.Controls.Add(Me.TxtFcnRC)
Me.GroupBox1.Controls.Add(Me.TxtObjRC)
Me.GroupBox1.Controls.Add(Me.TxtDptRC)
Me.GroupBox1.Controls.Add(Me.TxtSfndRC)
Me.GroupBox1.Controls.Add(Me.TxtFndRD)
Me.GroupBox1.Controls.Add(Me.TxtFndRC)
Me.GroupBox1.Location = New System.Drawing.Point(108, 60)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(333, 79)
Me.GroupBox1.TabIndex = 6
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "Revenue/Cash Account"
'
'LnkGLAcctRD
'
Me.LnkGLAcctRD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkGLAcctRD.ForeColor = System.Drawing.Color.Maroon
Me.LnkGLAcctRD.Location = New System.Drawing.Point(6, 53)
Me.LnkGLAcctRD.Name = "LnkGLAcctRD"
Me.LnkGLAcctRD.Size = New System.Drawing.Size(60, 18)
Me.LnkGLAcctRD.TabIndex = 6
Me.LnkGLAcctRD.TabStop = True
Me.LnkGLAcctRD.Text = "Debit Acct"
'
'LnkGLAcctRC
'
Me.LnkGLAcctRC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkGLAcctRC.ForeColor = System.Drawing.Color.Maroon
Me.LnkGLAcctRC.Location = New System.Drawing.Point(6, 29)
Me.LnkGLAcctRC.Name = "LnkGLAcctRC"
Me.LnkGLAcctRC.Size = New System.Drawing.Size(60, 18)
Me.LnkGLAcctRC.TabIndex = 0
Me.LnkGLAcctRC.TabStop = True
Me.LnkGLAcctRC.Text = "Credit Acct"
'
'TxtSfcnRD
'
Me.TxtSfcnRD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtSfcnRD.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtSfcnRD.Location = New System.Drawing.Point(282, 49)
Me.TxtSfcnRD.MaxLength = 4
Me.TxtSfcnRD.Name = "TxtSfcnRD"
Me.TxtSfcnRD.Size = New System.Drawing.Size(45, 22)
Me.TxtSfcnRD.TabIndex = 11
'
'TxtFcnRD
'
Me.TxtFcnRD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtFcnRD.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFcnRD.Location = New System.Drawing.Point(231, 49)
Me.TxtFcnRD.MaxLength = 4
Me.TxtFcnRD.Name = "TxtFcnRD"
Me.TxtFcnRD.Size = New System.Drawing.Size(45, 22)
Me.TxtFcnRD.TabIndex = 10
'
'TxtObjRD
'
Me.TxtObjRD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtObjRD.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtObjRD.Location = New System.Drawing.Point(195, 49)
Me.TxtObjRD.MaxLength = 3
Me.TxtObjRD.Name = "TxtObjRD"
Me.TxtObjRD.Size = New System.Drawing.Size(32, 22)
Me.TxtObjRD.TabIndex = 9
'
'TxtDptRD
'
Me.TxtDptRD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtDptRD.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDptRD.Location = New System.Drawing.Point(144, 49)
Me.TxtDptRD.MaxLength = 4
Me.TxtDptRD.Name = "TxtDptRD"
Me.TxtDptRD.Size = New System.Drawing.Size(45, 22)
Me.TxtDptRD.TabIndex = 8
'
'TxtSfndRD
'
Me.TxtSfndRD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtSfndRD.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtSfndRD.Location = New System.Drawing.Point(106, 49)
Me.TxtSfndRD.MaxLength = 3
Me.TxtSfndRD.Name = "TxtSfndRD"
Me.TxtSfndRD.Size = New System.Drawing.Size(32, 22)
Me.TxtSfndRD.TabIndex = 7
'
'TxtSfcnRC
'
Me.TxtSfcnRC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtSfcnRC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtSfcnRC.Location = New System.Drawing.Point(282, 23)
Me.TxtSfcnRC.MaxLength = 4
Me.TxtSfcnRC.Name = "TxtSfcnRC"
Me.TxtSfcnRC.Size = New System.Drawing.Size(45, 22)
Me.TxtSfcnRC.TabIndex = 5
'
'TxtFcnRC
'
Me.TxtFcnRC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtFcnRC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFcnRC.Location = New System.Drawing.Point(231, 23)
Me.TxtFcnRC.MaxLength = 4
Me.TxtFcnRC.Name = "TxtFcnRC"
Me.TxtFcnRC.Size = New System.Drawing.Size(45, 22)
Me.TxtFcnRC.TabIndex = 4
'
'TxtObjRC
'
Me.TxtObjRC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtObjRC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtObjRC.Location = New System.Drawing.Point(195, 23)
Me.TxtObjRC.MaxLength = 3
Me.TxtObjRC.Name = "TxtObjRC"
Me.TxtObjRC.Size = New System.Drawing.Size(32, 22)
Me.TxtObjRC.TabIndex = 3
'
'TxtDptRC
'
Me.TxtDptRC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtDptRC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDptRC.Location = New System.Drawing.Point(144, 23)
Me.TxtDptRC.MaxLength = 4
Me.TxtDptRC.Name = "TxtDptRC"
Me.TxtDptRC.Size = New System.Drawing.Size(45, 22)
Me.TxtDptRC.TabIndex = 2
'
'TxtSfndRC
'
Me.TxtSfndRC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtSfndRC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtSfndRC.Location = New System.Drawing.Point(106, 23)
Me.TxtSfndRC.MaxLength = 3
Me.TxtSfndRC.Name = "TxtSfndRC"
Me.TxtSfndRC.Size = New System.Drawing.Size(32, 22)
Me.TxtSfndRC.TabIndex = 1
'
'TxtFndRD
'
Me.TxtFndRD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtFndRD.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFndRD.Location = New System.Drawing.Point(68, 49)
Me.TxtFndRD.MaxLength = 3
Me.TxtFndRD.Name = "TxtFndRD"
Me.TxtFndRD.Size = New System.Drawing.Size(32, 22)
Me.TxtFndRD.TabIndex = 6
'
'TxtFndRC
'
Me.TxtFndRC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtFndRC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFndRC.Location = New System.Drawing.Point(68, 23)
Me.TxtFndRC.MaxLength = 3
Me.TxtFndRC.Name = "TxtFndRC"
Me.TxtFndRC.Size = New System.Drawing.Size(32, 22)
Me.TxtFndRC.TabIndex = 0
'
'GroupBox2
'
Me.GroupBox2.Controls.Add(Me.LnkGLAcctLD)
Me.GroupBox2.Controls.Add(Me.LnkGLAcctLC)
Me.GroupBox2.Controls.Add(Me.TxtSfcnLD)
Me.GroupBox2.Controls.Add(Me.TxtFcnLD)
Me.GroupBox2.Controls.Add(Me.TxtObjLD)
Me.GroupBox2.Controls.Add(Me.TxtDptLD)
Me.GroupBox2.Controls.Add(Me.TxtSfndLD)
Me.GroupBox2.Controls.Add(Me.TxtSfcnLC)
Me.GroupBox2.Controls.Add(Me.TxtFcnLC)
Me.GroupBox2.Controls.Add(Me.TxtObjLC)
Me.GroupBox2.Controls.Add(Me.TxtDptLC)
Me.GroupBox2.Controls.Add(Me.TxtSfndLC)
Me.GroupBox2.Controls.Add(Me.TxtFndLD)
Me.GroupBox2.Controls.Add(Me.TxtFndLC)
Me.GroupBox2.Location = New System.Drawing.Point(108, 145)
Me.GroupBox2.Name = "GroupBox2"
Me.GroupBox2.Size = New System.Drawing.Size(333, 79)
Me.GroupBox2.TabIndex = 7
Me.GroupBox2.TabStop = False
Me.GroupBox2.Text = "Liability/Asset Account"
'
'LnkGLAcctLD
'
Me.LnkGLAcctLD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkGLAcctLD.ForeColor = System.Drawing.Color.Maroon
Me.LnkGLAcctLD.Location = New System.Drawing.Point(6, 53)
Me.LnkGLAcctLD.Name = "LnkGLAcctLD"
Me.LnkGLAcctLD.Size = New System.Drawing.Size(60, 18)
Me.LnkGLAcctLD.TabIndex = 6
Me.LnkGLAcctLD.TabStop = True
Me.LnkGLAcctLD.Text = "Debit Acct"
'
'LnkGLAcctLC
'
Me.LnkGLAcctLC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkGLAcctLC.ForeColor = System.Drawing.Color.Maroon
Me.LnkGLAcctLC.Location = New System.Drawing.Point(6, 29)
Me.LnkGLAcctLC.Name = "LnkGLAcctLC"
Me.LnkGLAcctLC.Size = New System.Drawing.Size(60, 18)
Me.LnkGLAcctLC.TabIndex = 0
Me.LnkGLAcctLC.TabStop = True
Me.LnkGLAcctLC.Text = "Credit Acct"
'
'TxtSfcnLD
'
Me.TxtSfcnLD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtSfcnLD.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtSfcnLD.Location = New System.Drawing.Point(282, 49)
Me.TxtSfcnLD.MaxLength = 4
Me.TxtSfcnLD.Name = "TxtSfcnLD"
Me.TxtSfcnLD.Size = New System.Drawing.Size(45, 22)
Me.TxtSfcnLD.TabIndex = 11
'
'TxtFcnLD
'
Me.TxtFcnLD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtFcnLD.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFcnLD.Location = New System.Drawing.Point(231, 49)
Me.TxtFcnLD.MaxLength = 4
Me.TxtFcnLD.Name = "TxtFcnLD"
Me.TxtFcnLD.Size = New System.Drawing.Size(45, 22)
Me.TxtFcnLD.TabIndex = 10
'
'TxtObjLD
'
Me.TxtObjLD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtObjLD.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtObjLD.Location = New System.Drawing.Point(195, 49)
Me.TxtObjLD.MaxLength = 3
Me.TxtObjLD.Name = "TxtObjLD"
Me.TxtObjLD.Size = New System.Drawing.Size(32, 22)
Me.TxtObjLD.TabIndex = 9
'
'TxtDptLD
'
Me.TxtDptLD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtDptLD.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDptLD.Location = New System.Drawing.Point(144, 49)
Me.TxtDptLD.MaxLength = 4
Me.TxtDptLD.Name = "TxtDptLD"
Me.TxtDptLD.Size = New System.Drawing.Size(45, 22)
Me.TxtDptLD.TabIndex = 8
'
'TxtSfndLD
'
Me.TxtSfndLD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtSfndLD.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtSfndLD.Location = New System.Drawing.Point(106, 49)
Me.TxtSfndLD.MaxLength = 3
Me.TxtSfndLD.Name = "TxtSfndLD"
Me.TxtSfndLD.Size = New System.Drawing.Size(32, 22)
Me.TxtSfndLD.TabIndex = 7
'
'TxtSfcnLC
'
Me.TxtSfcnLC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtSfcnLC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtSfcnLC.Location = New System.Drawing.Point(282, 23)
Me.TxtSfcnLC.MaxLength = 4
Me.TxtSfcnLC.Name = "TxtSfcnLC"
Me.TxtSfcnLC.Size = New System.Drawing.Size(45, 22)
Me.TxtSfcnLC.TabIndex = 5
'
'TxtFcnLC
'
Me.TxtFcnLC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtFcnLC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFcnLC.Location = New System.Drawing.Point(231, 23)
Me.TxtFcnLC.MaxLength = 4
Me.TxtFcnLC.Name = "TxtFcnLC"
Me.TxtFcnLC.Size = New System.Drawing.Size(45, 22)
Me.TxtFcnLC.TabIndex = 4
'
'TxtObjLC
'
Me.TxtObjLC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtObjLC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtObjLC.Location = New System.Drawing.Point(195, 23)
Me.TxtObjLC.MaxLength = 3
Me.TxtObjLC.Name = "TxtObjLC"
Me.TxtObjLC.Size = New System.Drawing.Size(32, 22)
Me.TxtObjLC.TabIndex = 3
'
'TxtDptLC
'
Me.TxtDptLC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtDptLC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDptLC.Location = New System.Drawing.Point(144, 23)
Me.TxtDptLC.MaxLength = 4
Me.TxtDptLC.Name = "TxtDptLC"
Me.TxtDptLC.Size = New System.Drawing.Size(45, 22)
Me.TxtDptLC.TabIndex = 2
'
'TxtSfndLC
'
Me.TxtSfndLC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtSfndLC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtSfndLC.Location = New System.Drawing.Point(106, 23)
Me.TxtSfndLC.MaxLength = 3
Me.TxtSfndLC.Name = "TxtSfndLC"
Me.TxtSfndLC.Size = New System.Drawing.Size(32, 22)
Me.TxtSfndLC.TabIndex = 1
'
'TxtFndLD
'
Me.TxtFndLD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtFndLD.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFndLD.Location = New System.Drawing.Point(68, 49)
Me.TxtFndLD.MaxLength = 3
Me.TxtFndLD.Name = "TxtFndLD"
Me.TxtFndLD.Size = New System.Drawing.Size(32, 22)
Me.TxtFndLD.TabIndex = 6
'
'TxtFndLC
'
Me.TxtFndLC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtFndLC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFndLC.Location = New System.Drawing.Point(68, 23)
Me.TxtFndLC.MaxLength = 3
Me.TxtFndLC.Name = "TxtFndLC"
Me.TxtFndLC.Size = New System.Drawing.Size(32, 22)
Me.TxtFndLC.TabIndex = 0
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 14)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(35, 20)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Year"
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(492, 14)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(40, 24)
Me.Label3.TabIndex = 4
Me.Label3.Text = "Phase"
'
'TxtType
'
Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtType.Location = New System.Drawing.Point(150, 14)
Me.TxtType.MaxLength = 1
Me.TxtType.Name = "TxtType"
Me.TxtType.Size = New System.Drawing.Size(16, 20)
Me.TxtType.TabIndex = 1
'
'TxtYear
'
Me.TxtYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtYear.Location = New System.Drawing.Point(49, 14)
Me.TxtYear.MaxLength = 4
Me.TxtYear.Name = "TxtYear"
Me.TxtYear.Size = New System.Drawing.Size(36, 20)
Me.TxtYear.TabIndex = 0
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(393, 14)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(48, 20)
Me.Label2.TabIndex = 5
Me.Label2.Text = "District"
'
'TxtPhs
'
Me.TxtPhs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtPhs.Location = New System.Drawing.Point(538, 14)
Me.TxtPhs.MaxLength = 1
Me.TxtPhs.Name = "TxtPhs"
Me.TxtPhs.Size = New System.Drawing.Size(20, 20)
Me.TxtPhs.TabIndex = 5
'
'TxtDist
'
Me.TxtDist.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtDist.Location = New System.Drawing.Point(447, 14)
Me.TxtDist.MaxLength = 3
Me.TxtDist.Name = "TxtDist"
Me.TxtDist.Size = New System.Drawing.Size(28, 20)
Me.TxtDist.TabIndex = 4
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(105, 14)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(39, 20)
Me.Label4.TabIndex = 341
Me.Label4.Text = "Type"
'
'TxtCode
'
Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtCode.Location = New System.Drawing.Point(237, 14)
Me.TxtCode.MaxLength = 2
Me.TxtCode.Name = "TxtCode"
Me.TxtCode.Size = New System.Drawing.Size(27, 20)
Me.TxtCode.TabIndex = 2
'
'Label5
'
Me.Label5.Location = New System.Drawing.Point(192, 14)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(39, 20)
Me.Label5.TabIndex = 343
Me.Label5.Text = "Code"
'
'ChkSusp
'
Me.ChkSusp.AutoSize = True
Me.ChkSusp.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkSusp.Location = New System.Drawing.Point(288, 14)
Me.ChkSusp.Name = "ChkSusp"
Me.ChkSusp.Size = New System.Drawing.Size(79, 17)
Me.ChkSusp.TabIndex = 3
Me.ChkSusp.Text = "Suspense?"
Me.ChkSusp.UseVisualStyleBackColor = True
'
'FrmGLA01C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(566, 232)
Me.Controls.Add(Me.ChkSusp)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.TxtCode)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.GroupBox2)
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.TxtDist)
Me.Controls.Add(Me.TxtPhs)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.TxtYear)
Me.Controls.Add(Me.TxtType)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.KeyPreview = True
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmGLA01C"
Me.Text = "Maintain Tax Interface"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox1.ResumeLayout(False)
Me.GroupBox1.PerformLayout()
Me.GroupBox2.ResumeLayout(False)
Me.GroupBox2.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region


	Private Sub FrmGLA01C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myTXGL = New TXGL.myData()
  myTXGL.MyDBConn = myDBConnect
  myGLACCT = New GLACCT.MyData()
  myGLACCT.MyDBConn = myDBConnect

	MyFrmGLA01.TBarNew.Enabled = False
	MyFrmGLA01.TBarSave.Enabled = True
	MyFrmGLA01.TBarCopy.Enabled = False
	If WrkCopyMode Then
		MyFrmGLA01.TBarDelete.Enabled = False
	End If
	If WrkType <> String.Empty Then
		MyFrmGLA01.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(TxtType)
    MyUtils.SetTxtReadOnly(TxtYear)
    MyUtils.SetTxtReadOnly(TxtCode)
		ChkSusp.Enabled = False
    MyUtils.SetTxtReadOnly(TxtDist)
    MyUtils.SetTxtReadOnly(TxtPhs)
	Else
	End If
	MyFrmGLA01.TBarPrint.Enabled = False
	myTXGL.GetOneRecordP(WrkYear, WrkType, WrkCode, WrkSusp, WrkDist, WrkPhs)

	TxtType.Text = WrkType
  TxtYear.Text = MyUtils.CnvSng(WrkYear)
  TxtCode.Text = WrkCode
  If WrkSusp = "Y" Then ChkSusp.Checked = True
  TxtType.Text = WrkType
  TxtPhs.Text = WrkPhs
  TxtDist.Text = WrkDist

  If WrkCopyMode Then
    'Copy mode - Use last year's data
    WrkYear = WrkYear - 1
    myTXGL.GetOneRecordP(WrkYear, WrkType, WrkCode, WrkSusp, WrkDist, WrkPhs)
  Else
    If myTXGL.RecordNotFound Then
      Exit Sub
    End If
  End If

  With myTXGL
   TxtFndRC.Text = ._FDNRC
   TxtSfndRC.Text = ._SFURC
   TxtDptRC.Text = ._DPNRC
   TxtObjRC.Text = ._OBNRC
   TxtFcnRC.Text = ._FNPRC
   TxtSfcnRC.Text = ._SUBRC
   TxtFndRD.Text = ._FDNRD
   TxtSfndRD.Text = ._SFURD
   TxtDptRD.Text = ._DPNRD
   TxtObjRD.Text = ._OBNRD
   TxtFcnRD.Text = ._FNPRD
   TxtSfcnRD.Text = ._SUBRD
   TxtFndLC.Text = ._FDNLC
   TxtSfndLC.Text = ._SFULC
   TxtDptLC.Text = ._DPNLC
   TxtObjLC.Text = ._OBNLC
   TxtFcnLC.Text = ._FNPLC
   TxtSfcnLC.Text = ._SUBLC
   TxtFndLD.Text = ._FDNLD
   TxtSfndLD.Text = ._SFULD
   TxtDptLD.Text = ._DPNLD
   TxtObjLD.Text = ._OBNLD
   TxtFcnLD.Text = ._FNPLD
   TxtSfcnLD.Text = ._SUBLD
  End With

End Sub

Private Sub FrmGLA01C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmGLA01.SbpScreen.Text = "GLA01C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub FrmGLA01C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmGLA01.TBarNew.Enabled = True
  MyFrmGLA01.TBarDelete.Enabled = False
  MyFrmGLA01.TBarSave.Enabled = False
  MyFrmGLA01.TBarCopy.Enabled = True
  MyFrmGLA01.TBarNew.Enabled = True
  MyFrmGLA01.TBarPrint.Enabled = False
  MyFrmGLA01B.FormatGrid()
  MyFrmGLA01B.Show()
  'Memory Cleanup
  myTXGL.CloseFile()
  myTXGL = Nothing
  MyFrmGLA01C = Nothing
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If

  If ChkSusp.Checked Then
    WrkSusp = "Y"
  Else
    WrkSusp = "N"
  End If
  myTXGL.GetOneRecordP(MyUtils.CnvSng(TxtYear.Text), TxtType.Text, TxtCode.Text, WrkSusp, MyUtils.CnvSng(TxtDist.Text), TxtPhs.Text)
  myTXGL.DeleteOneRecordP()
  myTXGL.CloseFile()
  Me.Close()
End Sub

Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String

  If ChkSusp.Checked Then
    WrkSusp = "Y"
  Else
    WrkSusp = "N"
  End If
  myTXGL.GetOneRecordP(MyUtils.CnvSng(TxtYear.Text), TxtType.Text, TxtCode.Text, WrkSusp, MyUtils.CnvSng(TxtDist.Text), TxtPhs.Text)
  If WrkType = String.Empty Then
    If Not myTXGL.RecordNotFound Then
      Me.ErrProv.SetError(TxtType, "Record already exists")
      Exit Sub
    End If
  End If
  If Not myTXGL.RecordNotFound Then
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myTXGL.UpdateOneRecordP()
      myTXGL.CloseFile()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  Else
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      With myTXGL
        ._TXYR = MyUtils.CnvSng(TxtYear.Text)
        ._TXTYP = TxtType.Text
        ._TXCD = TxtCode.Text
        If ChkSusp.Checked Then
          ._TXSUP = "Y"
        Else
          ._TXSUP = "N"
        End If
        ._TXDIST = MyUtils.CnvSng(TxtDist.Text)
        If MyUtils.CnvSng(TxtPhs.Text) = 0 Then
          ._TXPHS = String.Empty
        Else
          ._TXPHS = MyUtils.CnvSng(TxtPhs.Text)
        End If
      End With
      myTXGL.AddOneRecordP()
      myTXGL.CloseFile()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End If

  Me.Close()
End Sub
Private Sub MovetoFile()
  With myTXGL
   ._FDNRC = MyUtils.CnvSng(TxtFndRC.Text)
   ._SFURC = MyUtils.CnvSng(TxtSfndRC.Text)
   ._DPNRC = MyUtils.CnvSng(TxtDptRC.Text)
   ._OBNRC = MyUtils.CnvSng(TxtObjRC.Text)
   ._FNPRC = MyUtils.CnvSng(TxtFcnRC.Text)
   ._SUBRC = MyUtils.CnvSng(TxtSfcnRC.Text)
   ._FDNRD = MyUtils.CnvSng(TxtFndRD.Text)
   ._SFURD = MyUtils.CnvSng(TxtSfndRD.Text)
   ._DPNRD = MyUtils.CnvSng(TxtDptRD.Text)
   ._OBNRD = MyUtils.CnvSng(TxtObjRD.Text)
   ._FNPRD = MyUtils.CnvSng(TxtFcnRD.Text)
   ._SUBRD = MyUtils.CnvSng(TxtSfcnRD.Text)
   ._FDNLC = MyUtils.CnvSng(TxtFndLC.Text)
   ._SFULC = MyUtils.CnvSng(TxtSfndLC.Text)
   ._DPNLC = MyUtils.CnvSng(TxtDptLC.Text)
   ._OBNLC = MyUtils.CnvSng(TxtObjLC.Text)
   ._FNPLC = MyUtils.CnvSng(TxtFcnLC.Text)
   ._SUBLC = MyUtils.CnvSng(TxtSfcnLC.Text)
   ._FDNLD = MyUtils.CnvSng(TxtFndLD.Text)
   ._SFULD = MyUtils.CnvSng(TxtSfndLD.Text)
   ._DPNLD = MyUtils.CnvSng(TxtDptLD.Text)
   ._OBNLD = MyUtils.CnvSng(TxtObjLD.Text)
   ._FNPLD = MyUtils.CnvSng(TxtFcnLD.Text)
   ._SUBLD = MyUtils.CnvSng(TxtSfcnLD.Text)
  End With
 End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtYear.Text) = 0 Then
      ErrorField(I) = "year"
      ErrorMsg(I) = "Year is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtYear.Text) = 0 Then
      ErrorField(I) = "type"
      ErrorMsg(I) = "Type is required"
      I = I + 1
    End If

     If MyUtils.CnvSng(TxtFndRC.Text) > 0 Or MyUtils.CnvSng(TxtSfndRC.Text) > 0 Or MyUtils.CnvSng(TxtDptRC.Text) > 0 Or _
      MyUtils.CnvSng(TxtObjRC.Text) > 0 Or MyUtils.CnvSng(TxtFcnRC.Text) > 0 Or MyUtils.CnvSng(TxtSfcnRC.Text) > 0 Then
      myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFndRC.Text), MyUtils.CnvSng(TxtSfndRC.Text), MyUtils.CnvSng(TxtDptRC.Text), _
        MyUtils.CnvSng(TxtObjRC.Text), MyUtils.CnvSng(TxtFcnRC.Text), MyUtils.CnvSng(TxtSfcnRC.Text))
      If myGLACCT.RecordNotFound Then
        ErrorField(I) = "acctrc"
        ErrorMsg(I) = "Acct is invalid"
        I = I + 1
      End If
    End If

     If MyUtils.CnvSng(TxtFndRD.Text) > 0 Or MyUtils.CnvSng(TxtSfndRD.Text) > 0 Or MyUtils.CnvSng(TxtDptRD.Text) > 0 Or _
      MyUtils.CnvSng(TxtObjRD.Text) > 0 Or MyUtils.CnvSng(TxtFcnRD.Text) > 0 Or MyUtils.CnvSng(TxtSfcnRD.Text) > 0 Then
      myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFndRD.Text), MyUtils.CnvSng(TxtSfndRD.Text), MyUtils.CnvSng(TxtDptRD.Text), _
        MyUtils.CnvSng(TxtObjRD.Text), MyUtils.CnvSng(TxtFcnRD.Text), MyUtils.CnvSng(TxtSfcnRD.Text))
      If myGLACCT.RecordNotFound Then
        ErrorField(I) = "acctrd"
        ErrorMsg(I) = "Acct is invalid"
        I = I + 1
      End If
    End If

     If MyUtils.CnvSng(TxtFndLC.Text) > 0 Or MyUtils.CnvSng(TxtSfndLC.Text) > 0 Or MyUtils.CnvSng(TxtDptLC.Text) > 0 Or _
      MyUtils.CnvSng(TxtObjLC.Text) > 0 Or MyUtils.CnvSng(TxtFcnLC.Text) > 0 Or MyUtils.CnvSng(TxtSfcnLC.Text) > 0 Then
      myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFndLC.Text), MyUtils.CnvSng(TxtSfndLC.Text), MyUtils.CnvSng(TxtDptLC.Text), _
        MyUtils.CnvSng(TxtObjLC.Text), MyUtils.CnvSng(TxtFcnLC.Text), MyUtils.CnvSng(TxtSfcnLC.Text))
      If myGLACCT.RecordNotFound Then
        ErrorField(I) = "acctlc"
        ErrorMsg(I) = "Acct is invalid"
        I = I + 1
      End If
    End If

     If MyUtils.CnvSng(TxtFndLD.Text) > 0 Or MyUtils.CnvSng(TxtSfndLD.Text) > 0 Or MyUtils.CnvSng(TxtDptLD.Text) > 0 Or _
      MyUtils.CnvSng(TxtObjLD.Text) > 0 Or MyUtils.CnvSng(TxtFcnLD.Text) > 0 Or MyUtils.CnvSng(TxtSfcnLD.Text) > 0 Then
      myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFndLD.Text), MyUtils.CnvSng(TxtSfndLD.Text), MyUtils.CnvSng(TxtDptLD.Text), _
        MyUtils.CnvSng(TxtObjLD.Text), MyUtils.CnvSng(TxtFcnLD.Text), MyUtils.CnvSng(TxtSfcnLD.Text))
      If myGLACCT.RecordNotFound Then
        ErrorField(I) = "acctld"
        ErrorMsg(I) = "Acct is invalid"
        I = I + 1
      End If
    End If
  End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtType, String.Empty)
  ErrProv.SetError(TxtYear, String.Empty)
  ErrProv.SetError(TxtFndRC, String.Empty)
  ErrProv.SetError(TxtFndRD, String.Empty)
  ErrProv.SetError(TxtFndLC, String.Empty)
  ErrProv.SetError(TxtFndLD, String.Empty)
  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
    Case "type"
      ErrProv.SetError(TxtType, ErrorMsg(I))
    Case "year"
      ErrProv.SetError(TxtYear, ErrorMsg(I))
    Case "acctrc"
      ErrProv.SetError(TxtFndRC, ErrorMsg(I))
    Case "acctrd"
      ErrProv.SetError(TxtFndRD, ErrorMsg(I))
    Case "acctlc"
      ErrProv.SetError(TxtFndLC, ErrorMsg(I))
    Case "acctld"
      ErrProv.SetError(TxtFndLD, ErrorMsg(I))
    Case Nothing
      Exit Sub
    End Select
  Next I
End Sub
Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub LnkGLAcctRC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkGLAcctRC.LinkClicked
  Dim WrkAcct As String

  WrkAcct = BuildAcct(MyUtils.CnvSng(TxtFndRC.Text), MyUtils.CnvSng(TxtSfndRC.Text), MyUtils.CnvSng(TxtDptRC.Text), _
    MyUtils.CnvSng(TxtObjRC.Text), MyUtils.CnvSng(TxtFcnRC.Text), MyUtils.CnvSng(TxtSfcnRC.Text))
  MyFrmListGLAcct = New FrmListGLAcct
  MyFrmListGLAcct.MdiParent = Me.ParentForm
  MyFrmListGLAcct.WrkField = "RC"
  MyFrmListGLAcct.WrkCode = WrkAcct
  MyFrmListGLAcct.Show()
  Me.Hide()
End Sub
Private Sub LnkGLAcctRD_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkGLAcctRD.LinkClicked
  Dim WrkAcct As String

  WrkAcct = BuildAcct(MyUtils.CnvSng(TxtFndRD.Text), MyUtils.CnvSng(TxtSfndRD.Text), MyUtils.CnvSng(TxtDptRD.Text), _
    MyUtils.CnvSng(TxtObjRD.Text), MyUtils.CnvSng(TxtFcnRD.Text), MyUtils.CnvSng(TxtSfcnRD.Text))
  MyFrmListGLAcct = New FrmListGLAcct
  MyFrmListGLAcct.MdiParent = Me.ParentForm
  MyFrmListGLAcct.WrkField = "RD"
  MyFrmListGLAcct.WrkCode = WrkAcct
  MyFrmListGLAcct.Show()
  Me.Hide()
End Sub
Private Sub LnkGLAcctLC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkGLAcctLC.LinkClicked
  Dim WrkAcct As String

  WrkAcct = BuildAcct(MyUtils.CnvSng(TxtFndLC.Text), MyUtils.CnvSng(TxtSfndLC.Text), MyUtils.CnvSng(TxtDptLC.Text), _
    MyUtils.CnvSng(TxtObjLC.Text), MyUtils.CnvSng(TxtFcnLC.Text), MyUtils.CnvSng(TxtSfcnLC.Text))
  MyFrmListGLAcct = New FrmListGLAcct
  MyFrmListGLAcct.MdiParent = Me.ParentForm
  MyFrmListGLAcct.WrkField = "LC"
  MyFrmListGLAcct.WrkCode = WrkAcct
  MyFrmListGLAcct.Show()
  Me.Hide()
End Sub
Private Sub LnkGLAcctLD_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkGLAcctLD.LinkClicked
  Dim WrkAcct As String

  WrkAcct = BuildAcct(MyUtils.CnvSng(TxtFndLD.Text), MyUtils.CnvSng(TxtSfndLD.Text), MyUtils.CnvSng(TxtDptLD.Text), _
    MyUtils.CnvSng(TxtObjLD.Text), MyUtils.CnvSng(TxtFcnLD.Text), MyUtils.CnvSng(TxtSfcnLD.Text))
  MyFrmListGLAcct = New FrmListGLAcct
  MyFrmListGLAcct.MdiParent = Me.ParentForm
  MyFrmListGLAcct.WrkField = "LD"
  MyFrmListGLAcct.WrkCode = WrkAcct
  MyFrmListGLAcct.Show()
  Me.Hide()
End Sub
End Class
