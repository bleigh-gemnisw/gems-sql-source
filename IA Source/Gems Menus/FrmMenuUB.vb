Public Class FrmMenuUB
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
  Friend WithEvents tab As System.Windows.Forms.TabControl
  Friend WithEvents tabdaily As System.Windows.Forms.TabPage
  Friend WithEvents btnub107 As System.Windows.Forms.Button
  Friend WithEvents btnub114 As System.Windows.Forms.Button
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents btnub304 As System.Windows.Forms.Button
  Friend WithEvents btnub102 As System.Windows.Forms.Button
  Friend WithEvents tabinterfaces As System.Windows.Forms.TabPage
  Friend WithEvents label4 As System.Windows.Forms.Label
  Friend WithEvents tabreports As System.Windows.Forms.TabPage
  Friend WithEvents btnub207 As System.Windows.Forms.Button
  Friend WithEvents btnub204 As System.Windows.Forms.Button
  Friend WithEvents btnub203 As System.Windows.Forms.Button
  Friend WithEvents btnub202 As System.Windows.Forms.Button
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents tabbilling As System.Windows.Forms.TabPage
  Friend WithEvents btnub412 As System.Windows.Forms.Button
  Friend WithEvents btnub411 As System.Windows.Forms.Button
  Friend WithEvents btnub404 As System.Windows.Forms.Button
  Friend WithEvents btnub402 As System.Windows.Forms.Button
  Friend WithEvents btnub401 As System.Windows.Forms.Button
  Friend WithEvents label6 As System.Windows.Forms.Label
  Friend WithEvents tabtables As System.Windows.Forms.TabPage
  Friend WithEvents btnub106 As System.Windows.Forms.Button
  Friend WithEvents btnub105 As System.Windows.Forms.Button
  Friend WithEvents btnub104 As System.Windows.Forms.Button
  Friend WithEvents btnub103 As System.Windows.Forms.Button
  Friend WithEvents btnub101 As System.Windows.Forms.Button
  Friend WithEvents label3 As System.Windows.Forms.Label
  Friend WithEvents tabadjustments As System.Windows.Forms.TabPage
  Friend WithEvents btnub501 As System.Windows.Forms.Button
  Friend WithEvents btnub502 As System.Windows.Forms.Button
  Friend WithEvents label7 As System.Windows.Forms.Label
  Friend WithEvents btnub108 As System.Windows.Forms.Button
  Friend WithEvents btnub302 As System.Windows.Forms.Button
  Friend WithEvents BtnUB305 As System.Windows.Forms.Button
  Friend WithEvents BtnUB211 As System.Windows.Forms.Button
  Friend WithEvents BtnUB413 As System.Windows.Forms.Button
  Friend WithEvents BtnUB306 As System.Windows.Forms.Button
  Friend WithEvents BtnUB109 As System.Windows.Forms.Button
  Friend WithEvents BtnUB110 As System.Windows.Forms.Button
  Friend WithEvents BtnUB414 As System.Windows.Forms.Button
  Friend WithEvents BtnUB212 As System.Windows.Forms.Button
  Friend WithEvents BtnUB111 As System.Windows.Forms.Button
  Friend WithEvents BtnUB213 As System.Windows.Forms.Button
  Friend WithEvents BtnUB340 As System.Windows.Forms.Button
  Friend WithEvents BtnUB214 As System.Windows.Forms.Button
  Friend WithEvents BtnUB341 As System.Windows.Forms.Button
  Friend WithEvents BtnUB230 As System.Windows.Forms.Button
  Friend WithEvents BtnUB231 As System.Windows.Forms.Button
  Friend WithEvents BtnUB430 As System.Windows.Forms.Button
  Friend WithEvents BtnUB232 As System.Windows.Forms.Button
  Friend WithEvents BtnUB112 As System.Windows.Forms.Button
  Friend WithEvents BtnUB233 As System.Windows.Forms.Button
  Friend WithEvents BtnUB234 As System.Windows.Forms.Button
  Friend WithEvents BtnUB235 As System.Windows.Forms.Button
  Friend WithEvents Label5 As Label
  Friend WithEvents BtnUB431 As Button
  Friend WithEvents BtnUB307 As Button
  Friend WithEvents BtnUB236 As Button
  Friend WithEvents BtnUB410 As Button
    Friend WithEvents btnub350 As Button
    Friend WithEvents BtnUB113 As Button
    Friend WithEvents BtnUB409 As Button
    Friend WithEvents BtnUB237 As Button
    Friend WithEvents btnub210 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMenuUB))
    Me.tab = New System.Windows.Forms.TabControl()
    Me.tabdaily = New System.Windows.Forms.TabPage()
        Me.btnub350 = New System.Windows.Forms.Button()
        Me.btnub107 = New System.Windows.Forms.Button()
        Me.btnub114 = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.btnub304 = New System.Windows.Forms.Button()
        Me.btnub102 = New System.Windows.Forms.Button()
        Me.tabinterfaces = New System.Windows.Forms.TabPage()
        Me.BtnUB307 = New System.Windows.Forms.Button()
        Me.BtnUB341 = New System.Windows.Forms.Button()
        Me.BtnUB340 = New System.Windows.Forms.Button()
        Me.BtnUB109 = New System.Windows.Forms.Button()
        Me.BtnUB306 = New System.Windows.Forms.Button()
        Me.BtnUB305 = New System.Windows.Forms.Button()
        Me.btnub302 = New System.Windows.Forms.Button()
        Me.label4 = New System.Windows.Forms.Label()
        Me.tabreports = New System.Windows.Forms.TabPage()
        Me.BtnUB237 = New System.Windows.Forms.Button()
        Me.BtnUB236 = New System.Windows.Forms.Button()
        Me.BtnUB235 = New System.Windows.Forms.Button()
        Me.BtnUB234 = New System.Windows.Forms.Button()
        Me.BtnUB233 = New System.Windows.Forms.Button()
        Me.BtnUB232 = New System.Windows.Forms.Button()
        Me.BtnUB231 = New System.Windows.Forms.Button()
        Me.BtnUB230 = New System.Windows.Forms.Button()
        Me.BtnUB214 = New System.Windows.Forms.Button()
        Me.BtnUB213 = New System.Windows.Forms.Button()
        Me.BtnUB212 = New System.Windows.Forms.Button()
        Me.BtnUB211 = New System.Windows.Forms.Button()
        Me.btnub210 = New System.Windows.Forms.Button()
        Me.btnub207 = New System.Windows.Forms.Button()
        Me.btnub204 = New System.Windows.Forms.Button()
        Me.btnub203 = New System.Windows.Forms.Button()
        Me.btnub202 = New System.Windows.Forms.Button()
        Me.label2 = New System.Windows.Forms.Label()
        Me.tabbilling = New System.Windows.Forms.TabPage()
        Me.BtnUB409 = New System.Windows.Forms.Button()
        Me.BtnUB410 = New System.Windows.Forms.Button()
        Me.BtnUB431 = New System.Windows.Forms.Button()
        Me.BtnUB430 = New System.Windows.Forms.Button()
        Me.BtnUB414 = New System.Windows.Forms.Button()
        Me.BtnUB413 = New System.Windows.Forms.Button()
        Me.btnub412 = New System.Windows.Forms.Button()
        Me.btnub411 = New System.Windows.Forms.Button()
        Me.btnub404 = New System.Windows.Forms.Button()
        Me.btnub402 = New System.Windows.Forms.Button()
        Me.btnub401 = New System.Windows.Forms.Button()
        Me.label6 = New System.Windows.Forms.Label()
        Me.tabtables = New System.Windows.Forms.TabPage()
        Me.BtnUB113 = New System.Windows.Forms.Button()
        Me.BtnUB112 = New System.Windows.Forms.Button()
        Me.BtnUB111 = New System.Windows.Forms.Button()
        Me.BtnUB110 = New System.Windows.Forms.Button()
        Me.btnub108 = New System.Windows.Forms.Button()
        Me.btnub106 = New System.Windows.Forms.Button()
        Me.btnub105 = New System.Windows.Forms.Button()
        Me.btnub104 = New System.Windows.Forms.Button()
        Me.btnub103 = New System.Windows.Forms.Button()
        Me.btnub101 = New System.Windows.Forms.Button()
        Me.label3 = New System.Windows.Forms.Label()
        Me.tabadjustments = New System.Windows.Forms.TabPage()
        Me.btnub501 = New System.Windows.Forms.Button()
        Me.btnub502 = New System.Windows.Forms.Button()
        Me.label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tab.SuspendLayout()
        Me.tabdaily.SuspendLayout()
        Me.tabinterfaces.SuspendLayout()
        Me.tabreports.SuspendLayout()
        Me.tabbilling.SuspendLayout()
        Me.tabtables.SuspendLayout()
        Me.tabadjustments.SuspendLayout()
        Me.SuspendLayout()
        '
        'tab
        '
        Me.tab.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.tab.Controls.Add(Me.tabdaily)
        Me.tab.Controls.Add(Me.tabinterfaces)
        Me.tab.Controls.Add(Me.tabreports)
        Me.tab.Controls.Add(Me.tabbilling)
        Me.tab.Controls.Add(Me.tabtables)
        Me.tab.Controls.Add(Me.tabadjustments)
        Me.tab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tab.Location = New System.Drawing.Point(8, 80)
        Me.tab.Multiline = True
        Me.tab.Name = "tab"
        Me.tab.SelectedIndex = 0
        Me.tab.Size = New System.Drawing.Size(544, 400)
        Me.tab.TabIndex = 11
        '
        'tabdaily
        '
        Me.tabdaily.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabdaily.Controls.Add(Me.btnub350)
        Me.tabdaily.Controls.Add(Me.btnub107)
        Me.tabdaily.Controls.Add(Me.btnub114)
        Me.tabdaily.Controls.Add(Me.label1)
        Me.tabdaily.Controls.Add(Me.btnub304)
        Me.tabdaily.Controls.Add(Me.btnub102)
        Me.tabdaily.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabdaily.Location = New System.Drawing.Point(4, 27)
        Me.tabdaily.Name = "tabdaily"
        Me.tabdaily.Size = New System.Drawing.Size(536, 369)
        Me.tabdaily.TabIndex = 0
        Me.tabdaily.Text = "Daily"
        '
        'btnub350
        '
        Me.btnub350.Location = New System.Drawing.Point(104, 248)
        Me.btnub350.Name = "btnub350"
        Me.btnub350.Size = New System.Drawing.Size(312, 24)
        Me.btnub350.TabIndex = 9
        Me.btnub350.Text = "Update Customer Billing Name / Address"
        '
        'btnub107
        '
        Me.btnub107.Location = New System.Drawing.Point(104, 152)
        Me.btnub107.Name = "btnub107"
        Me.btnub107.Size = New System.Drawing.Size(312, 24)
        Me.btnub107.TabIndex = 6
        Me.btnub107.Text = "Customer Meter/Usage Readings"
        '
        'btnub114
        '
        Me.btnub114.Location = New System.Drawing.Point(104, 184)
        Me.btnub114.Name = "btnub114"
        Me.btnub114.Size = New System.Drawing.Size(312, 24)
        Me.btnub114.TabIndex = 7
        Me.btnub114.Text = "Customer METER/DEDUCT"
        '
        'label1
        '
        Me.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.Maroon
        Me.label1.Image = CType(resources.GetObject("label1.Image"), System.Drawing.Image)
        Me.label1.Location = New System.Drawing.Point(-8, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(544, 32)
        Me.label1.TabIndex = 5
        '
        'btnub304
        '
        Me.btnub304.Location = New System.Drawing.Point(104, 216)
        Me.btnub304.Name = "btnub304"
        Me.btnub304.Size = New System.Drawing.Size(312, 24)
        Me.btnub304.TabIndex = 8
        Me.btnub304.Text = "Update/Add Customers from Assessor System"
        '
        'btnub102
        '
        Me.btnub102.Location = New System.Drawing.Point(104, 120)
        Me.btnub102.Name = "btnub102"
        Me.btnub102.Size = New System.Drawing.Size(312, 24)
        Me.btnub102.TabIndex = 0
        Me.btnub102.Text = "Customer Master"
        '
        'tabinterfaces
        '
        Me.tabinterfaces.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabinterfaces.Controls.Add(Me.BtnUB307)
        Me.tabinterfaces.Controls.Add(Me.BtnUB341)
        Me.tabinterfaces.Controls.Add(Me.BtnUB340)
        Me.tabinterfaces.Controls.Add(Me.BtnUB109)
        Me.tabinterfaces.Controls.Add(Me.BtnUB306)
        Me.tabinterfaces.Controls.Add(Me.BtnUB305)
        Me.tabinterfaces.Controls.Add(Me.btnub302)
        Me.tabinterfaces.Controls.Add(Me.label4)
        Me.tabinterfaces.Location = New System.Drawing.Point(4, 27)
        Me.tabinterfaces.Name = "tabinterfaces"
        Me.tabinterfaces.Size = New System.Drawing.Size(536, 369)
        Me.tabinterfaces.TabIndex = 3
        Me.tabinterfaces.Text = "Interfaces"
        Me.tabinterfaces.Visible = False
        '
        'BtnUB307
        '
        Me.BtnUB307.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB307.Location = New System.Drawing.Point(143, 269)
        Me.BtnUB307.Name = "BtnUB307"
        Me.BtnUB307.Size = New System.Drawing.Size(248, 24)
        Me.BtnUB307.TabIndex = 15
        Me.BtnUB307.Text = "Import Meter Xref Deducts"
        '
        'BtnUB341
        '
        Me.BtnUB341.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB341.Location = New System.Drawing.Point(143, 299)
        Me.BtnUB341.Name = "BtnUB341"
        Me.BtnUB341.Size = New System.Drawing.Size(248, 24)
        Me.BtnUB341.TabIndex = 14
        Me.BtnUB341.Text = "Interface Meter Usage (EDU)"
        '
        'BtnUB340
        '
        Me.BtnUB340.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB340.Location = New System.Drawing.Point(143, 178)
        Me.BtnUB340.Name = "BtnUB340"
        Me.BtnUB340.Size = New System.Drawing.Size(248, 24)
        Me.BtnUB340.TabIndex = 13
        Me.BtnUB340.Text = "EZRoute Meter Repair Letters"
        '
        'BtnUB109
        '
        Me.BtnUB109.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB109.Location = New System.Drawing.Point(143, 239)
        Me.BtnUB109.Name = "BtnUB109"
        Me.BtnUB109.Size = New System.Drawing.Size(248, 24)
        Me.BtnUB109.TabIndex = 12
        Me.BtnUB109.Text = "Maintain Meter XRef Numbers"
        '
        'BtnUB306
        '
        Me.BtnUB306.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB306.Location = New System.Drawing.Point(143, 209)
        Me.BtnUB306.Name = "BtnUB306"
        Me.BtnUB306.Size = New System.Drawing.Size(248, 24)
        Me.BtnUB306.TabIndex = 11
        Me.BtnUB306.Text = "Import Water Readings"
        '
        'BtnUB305
        '
        Me.BtnUB305.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB305.Location = New System.Drawing.Point(143, 148)
        Me.BtnUB305.Name = "BtnUB305"
        Me.BtnUB305.Size = New System.Drawing.Size(248, 24)
        Me.BtnUB305.TabIndex = 10
        Me.BtnUB305.Text = "Interface to Neptune"
        '
        'btnub302
        '
        Me.btnub302.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnub302.Location = New System.Drawing.Point(143, 118)
        Me.btnub302.Name = "btnub302"
        Me.btnub302.Size = New System.Drawing.Size(248, 24)
        Me.btnub302.TabIndex = 8
        Me.btnub302.Text = "Interface to Computel "
        '
        'label4
        '
        Me.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.ForeColor = System.Drawing.Color.Maroon
        Me.label4.Image = CType(resources.GetObject("label4.Image"), System.Drawing.Image)
        Me.label4.Location = New System.Drawing.Point(0, 0)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(528, 32)
        Me.label4.TabIndex = 6
        '
        'tabreports
        '
        Me.tabreports.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabreports.Controls.Add(Me.BtnUB237)
        Me.tabreports.Controls.Add(Me.BtnUB236)
        Me.tabreports.Controls.Add(Me.BtnUB235)
        Me.tabreports.Controls.Add(Me.BtnUB234)
        Me.tabreports.Controls.Add(Me.BtnUB233)
        Me.tabreports.Controls.Add(Me.BtnUB232)
        Me.tabreports.Controls.Add(Me.BtnUB231)
        Me.tabreports.Controls.Add(Me.BtnUB230)
        Me.tabreports.Controls.Add(Me.BtnUB214)
        Me.tabreports.Controls.Add(Me.BtnUB213)
        Me.tabreports.Controls.Add(Me.BtnUB212)
        Me.tabreports.Controls.Add(Me.BtnUB211)
        Me.tabreports.Controls.Add(Me.btnub210)
        Me.tabreports.Controls.Add(Me.btnub207)
        Me.tabreports.Controls.Add(Me.btnub204)
        Me.tabreports.Controls.Add(Me.btnub203)
        Me.tabreports.Controls.Add(Me.btnub202)
        Me.tabreports.Controls.Add(Me.label2)
        Me.tabreports.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabreports.Location = New System.Drawing.Point(4, 27)
        Me.tabreports.Name = "tabreports"
        Me.tabreports.Size = New System.Drawing.Size(536, 369)
        Me.tabreports.TabIndex = 1
        Me.tabreports.Text = "Reports"
        Me.tabreports.Visible = False
        '
        'BtnUB237
        '
        Me.BtnUB237.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB237.ForeColor = System.Drawing.Color.Black
        Me.BtnUB237.Location = New System.Drawing.Point(12, 139)
        Me.BtnUB237.Name = "BtnUB237"
        Me.BtnUB237.Size = New System.Drawing.Size(248, 24)
        Me.BtnUB237.TabIndex = 66
        Me.BtnUB237.Text = "Posted Rate Book"
        '
        'BtnUB236
        '
        Me.BtnUB236.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB236.ForeColor = System.Drawing.Color.Black
        Me.BtnUB236.Location = New System.Drawing.Point(266, 259)
        Me.BtnUB236.Name = "BtnUB236"
        Me.BtnUB236.Size = New System.Drawing.Size(248, 24)
        Me.BtnUB236.TabIndex = 65
        Me.BtnUB236.Text = "Meter Readings Details"
        '
        'BtnUB235
        '
        Me.BtnUB235.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB235.ForeColor = System.Drawing.Color.Black
        Me.BtnUB235.Location = New System.Drawing.Point(266, 289)
        Me.BtnUB235.Name = "BtnUB235"
        Me.BtnUB235.Size = New System.Drawing.Size(248, 24)
        Me.BtnUB235.TabIndex = 64
        Me.BtnUB235.Text = "Meter Serial Numbers"
        '
        'BtnUB234
        '
        Me.BtnUB234.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB234.ForeColor = System.Drawing.Color.Black
        Me.BtnUB234.Location = New System.Drawing.Point(12, 319)
        Me.BtnUB234.Name = "BtnUB234"
        Me.BtnUB234.Size = New System.Drawing.Size(248, 24)
        Me.BtnUB234.TabIndex = 63
        Me.BtnUB234.Text = "Accounts by Meter Size"
        '
        'BtnUB233
        '
        Me.BtnUB233.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB233.ForeColor = System.Drawing.Color.Black
        Me.BtnUB233.Location = New System.Drawing.Point(12, 289)
        Me.BtnUB233.Name = "BtnUB233"
        Me.BtnUB233.Size = New System.Drawing.Size(248, 24)
        Me.BtnUB233.TabIndex = 62
        Me.BtnUB233.Text = "Accounts by Zone / Unit"
        '
        'BtnUB232
        '
        Me.BtnUB232.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB232.ForeColor = System.Drawing.Color.Black
        Me.BtnUB232.Location = New System.Drawing.Point(12, 259)
        Me.BtnUB232.Name = "BtnUB232"
        Me.BtnUB232.Size = New System.Drawing.Size(248, 24)
        Me.BtnUB232.TabIndex = 61
        Me.BtnUB232.Text = "Commercial/Residential/Etc. List"
        '
        'BtnUB231
        '
        Me.BtnUB231.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB231.ForeColor = System.Drawing.Color.Black
        Me.BtnUB231.Location = New System.Drawing.Point(266, 109)
        Me.BtnUB231.Name = "BtnUB231"
        Me.BtnUB231.Size = New System.Drawing.Size(248, 24)
        Me.BtnUB231.TabIndex = 60
        Me.BtnUB231.Text = "Benefit Assessment Notices"
        '
        'BtnUB230
        '
        Me.BtnUB230.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB230.ForeColor = System.Drawing.Color.Black
        Me.BtnUB230.Location = New System.Drawing.Point(12, 169)
        Me.BtnUB230.Name = "BtnUB230"
        Me.BtnUB230.Size = New System.Drawing.Size(248, 24)
        Me.BtnUB230.TabIndex = 59
        Me.BtnUB230.Text = "Billing Breakdown"
        '
        'BtnUB214
        '
        Me.BtnUB214.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB214.ForeColor = System.Drawing.Color.Black
        Me.BtnUB214.Location = New System.Drawing.Point(266, 199)
        Me.BtnUB214.Name = "BtnUB214"
        Me.BtnUB214.Size = New System.Drawing.Size(248, 24)
        Me.BtnUB214.TabIndex = 58
        Me.BtnUB214.Text = "Meter Usage Variance"
        '
        'BtnUB213
        '
        Me.BtnUB213.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB213.ForeColor = System.Drawing.Color.Black
        Me.BtnUB213.Location = New System.Drawing.Point(266, 229)
        Me.BtnUB213.Name = "BtnUB213"
        Me.BtnUB213.Size = New System.Drawing.Size(248, 24)
        Me.BtnUB213.TabIndex = 57
        Me.BtnUB213.Text = "Meter Readings"
        '
        'BtnUB212
        '
        Me.BtnUB212.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB212.ForeColor = System.Drawing.Color.Black
        Me.BtnUB212.Location = New System.Drawing.Point(266, 169)
        Me.BtnUB212.Name = "BtnUB212"
        Me.BtnUB212.Size = New System.Drawing.Size(248, 24)
        Me.BtnUB212.TabIndex = 56
        Me.BtnUB212.Text = "Meter Usage "
        '
        'BtnUB211
        '
        Me.BtnUB211.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB211.ForeColor = System.Drawing.Color.Black
        Me.BtnUB211.Location = New System.Drawing.Point(266, 80)
        Me.BtnUB211.Name = "BtnUB211"
        Me.BtnUB211.Size = New System.Drawing.Size(248, 24)
        Me.BtnUB211.TabIndex = 55
        Me.BtnUB211.Text = "Benefit Assessment Liens"
        '
        'btnub210
        '
        Me.btnub210.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnub210.ForeColor = System.Drawing.Color.Black
        Me.btnub210.Location = New System.Drawing.Point(12, 229)
        Me.btnub210.Name = "btnub210"
        Me.btnub210.Size = New System.Drawing.Size(248, 24)
        Me.btnub210.TabIndex = 54
        Me.btnub210.Text = "Deferred Report"
        '
        'btnub207
        '
        Me.btnub207.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnub207.Location = New System.Drawing.Point(12, 199)
        Me.btnub207.Name = "btnub207"
        Me.btnub207.Size = New System.Drawing.Size(248, 24)
        Me.btnub207.TabIndex = 53
        Me.btnub207.Text = "Customer Report/Labels"
        '
        'btnub204
        '
        Me.btnub204.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnub204.ForeColor = System.Drawing.Color.Black
        Me.btnub204.Location = New System.Drawing.Point(266, 139)
        Me.btnub204.Name = "btnub204"
        Me.btnub204.Size = New System.Drawing.Size(248, 24)
        Me.btnub204.TabIndex = 10
        Me.btnub204.Text = "Amortization Table"
        '
        'btnub203
        '
        Me.btnub203.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnub203.ForeColor = System.Drawing.Color.Black
        Me.btnub203.Location = New System.Drawing.Point(12, 109)
        Me.btnub203.Name = "btnub203"
        Me.btnub203.Size = New System.Drawing.Size(248, 24)
        Me.btnub203.TabIndex = 9
        Me.btnub203.Text = "Rate Book"
        '
        'btnub202
        '
        Me.btnub202.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnub202.ForeColor = System.Drawing.Color.Black
        Me.btnub202.Location = New System.Drawing.Point(12, 80)
        Me.btnub202.Name = "btnub202"
        Me.btnub202.Size = New System.Drawing.Size(248, 24)
        Me.btnub202.TabIndex = 8
        Me.btnub202.Text = "Work Sheet"
        '
        'label2
        '
        Me.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.Color.Maroon
        Me.label2.Image = CType(resources.GetObject("label2.Image"), System.Drawing.Image)
        Me.label2.Location = New System.Drawing.Point(-8, 0)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(544, 32)
        Me.label2.TabIndex = 6
        '
        'tabbilling
        '
        Me.tabbilling.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabbilling.Controls.Add(Me.BtnUB409)
        Me.tabbilling.Controls.Add(Me.BtnUB410)
        Me.tabbilling.Controls.Add(Me.BtnUB431)
        Me.tabbilling.Controls.Add(Me.BtnUB430)
        Me.tabbilling.Controls.Add(Me.BtnUB414)
        Me.tabbilling.Controls.Add(Me.BtnUB413)
        Me.tabbilling.Controls.Add(Me.btnub412)
        Me.tabbilling.Controls.Add(Me.btnub411)
        Me.tabbilling.Controls.Add(Me.btnub404)
        Me.tabbilling.Controls.Add(Me.btnub402)
        Me.tabbilling.Controls.Add(Me.btnub401)
        Me.tabbilling.Controls.Add(Me.label6)
        Me.tabbilling.Location = New System.Drawing.Point(4, 27)
        Me.tabbilling.Name = "tabbilling"
        Me.tabbilling.Size = New System.Drawing.Size(536, 369)
        Me.tabbilling.TabIndex = 5
        Me.tabbilling.Text = "Billing"
        Me.tabbilling.Visible = False
        '
        'BtnUB409
        '
        Me.BtnUB409.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB409.Location = New System.Drawing.Point(72, 182)
        Me.BtnUB409.Name = "BtnUB409"
        Me.BtnUB409.Size = New System.Drawing.Size(386, 24)
        Me.BtnUB409.TabIndex = 40
        Me.BtnUB409.Text = "Print Monthly Report/Bills/Post"
        '
        'BtnUB410
        '
        Me.BtnUB410.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB410.Location = New System.Drawing.Point(72, 152)
        Me.BtnUB410.Name = "BtnUB410"
        Me.BtnUB410.Size = New System.Drawing.Size(386, 24)
        Me.BtnUB410.TabIndex = 39
        Me.BtnUB410.Text = "Print Combined Report/Bills/Post"
        '
        'BtnUB431
        '
        Me.BtnUB431.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB431.Location = New System.Drawing.Point(72, 329)
        Me.BtnUB431.Name = "BtnUB431"
        Me.BtnUB431.Size = New System.Drawing.Size(386, 24)
        Me.BtnUB431.TabIndex = 38
        Me.BtnUB431.Text = "Update Sold Properties Billing Codes"
        '
        'BtnUB430
        '
        Me.BtnUB430.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB430.Location = New System.Drawing.Point(72, 299)
        Me.BtnUB430.Name = "BtnUB430"
        Me.BtnUB430.Size = New System.Drawing.Size(386, 24)
        Me.BtnUB430.TabIndex = 37
        Me.BtnUB430.Text = "Create Deferred Tax Invoice Record"
        '
        'BtnUB414
        '
        Me.BtnUB414.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB414.Location = New System.Drawing.Point(72, 270)
        Me.BtnUB414.Name = "BtnUB414"
        Me.BtnUB414.Size = New System.Drawing.Size(386, 24)
        Me.BtnUB414.TabIndex = 36
        Me.BtnUB414.Text = "Estimate or Remove Meter Readings"
        '
        'BtnUB413
        '
        Me.BtnUB413.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB413.Location = New System.Drawing.Point(72, 241)
        Me.BtnUB413.Name = "BtnUB413"
        Me.BtnUB413.Size = New System.Drawing.Size(386, 24)
        Me.BtnUB413.TabIndex = 35
        Me.BtnUB413.Text = "Assessment Summary Report"
        '
        'btnub412
        '
        Me.btnub412.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnub412.Location = New System.Drawing.Point(72, 212)
        Me.btnub412.Name = "btnub412"
        Me.btnub412.Size = New System.Drawing.Size(386, 24)
        Me.btnub412.TabIndex = 34
        Me.btnub412.Text = "Payoff Balance Report/Letter"
        '
        'btnub411
        '
        Me.btnub411.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnub411.Location = New System.Drawing.Point(72, 125)
        Me.btnub411.Name = "btnub411"
        Me.btnub411.Size = New System.Drawing.Size(386, 24)
        Me.btnub411.TabIndex = 33
        Me.btnub411.Text = "Print Report/Bills/Post"
        '
        'btnub404
        '
        Me.btnub404.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnub404.Location = New System.Drawing.Point(72, 95)
        Me.btnub404.Name = "btnub404"
        Me.btnub404.Size = New System.Drawing.Size(386, 24)
        Me.btnub404.TabIndex = 30
        Me.btnub404.Text = "Calculate Average Billing Amounts"
        '
        'btnub402
        '
        Me.btnub402.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnub402.Location = New System.Drawing.Point(72, 65)
        Me.btnub402.Name = "btnub402"
        Me.btnub402.Size = New System.Drawing.Size(386, 24)
        Me.btnub402.TabIndex = 27
        Me.btnub402.Text = "Move Pre-paid Payments To Next Year (After Asmt Bill Post)"
        '
        'btnub401
        '
        Me.btnub401.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnub401.Location = New System.Drawing.Point(72, 35)
        Me.btnub401.Name = "btnub401"
        Me.btnub401.Size = New System.Drawing.Size(386, 24)
        Me.btnub401.TabIndex = 26
        Me.btnub401.Text = "Accelerate Paid Accounts (Before Asmt Bills)"
        '
        'label6
        '
        Me.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label6.ForeColor = System.Drawing.Color.Maroon
        Me.label6.Image = CType(resources.GetObject("label6.Image"), System.Drawing.Image)
        Me.label6.Location = New System.Drawing.Point(-8, 0)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(544, 32)
        Me.label6.TabIndex = 6
        '
        'tabtables
        '
        Me.tabtables.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabtables.Controls.Add(Me.BtnUB113)
        Me.tabtables.Controls.Add(Me.BtnUB112)
        Me.tabtables.Controls.Add(Me.BtnUB111)
        Me.tabtables.Controls.Add(Me.BtnUB110)
        Me.tabtables.Controls.Add(Me.btnub108)
        Me.tabtables.Controls.Add(Me.btnub106)
        Me.tabtables.Controls.Add(Me.btnub105)
        Me.tabtables.Controls.Add(Me.btnub104)
        Me.tabtables.Controls.Add(Me.btnub103)
        Me.tabtables.Controls.Add(Me.btnub101)
        Me.tabtables.Controls.Add(Me.label3)
        Me.tabtables.Location = New System.Drawing.Point(4, 27)
        Me.tabtables.Name = "tabtables"
        Me.tabtables.Size = New System.Drawing.Size(536, 369)
        Me.tabtables.TabIndex = 2
        Me.tabtables.Text = "Tables"
        Me.tabtables.Visible = False
        '
        'BtnUB113
        '
        Me.BtnUB113.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB113.Location = New System.Drawing.Point(140, 172)
        Me.BtnUB113.Name = "BtnUB113"
        Me.BtnUB113.Size = New System.Drawing.Size(248, 24)
        Me.BtnUB113.TabIndex = 16
        Me.BtnUB113.Text = "Meter User Headings"
        '
        'BtnUB112
        '
        Me.BtnUB112.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB112.Location = New System.Drawing.Point(140, 142)
        Me.BtnUB112.Name = "BtnUB112"
        Me.BtnUB112.Size = New System.Drawing.Size(248, 24)
        Me.BtnUB112.TabIndex = 15
        Me.BtnUB112.Text = "Meter Reading Reasons"
        '
        'BtnUB111
        '
        Me.BtnUB111.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB111.Location = New System.Drawing.Point(140, 326)
        Me.BtnUB111.Name = "BtnUB111"
        Me.BtnUB111.Size = New System.Drawing.Size(248, 24)
        Me.BtnUB111.TabIndex = 14
        Me.BtnUB111.Text = "Rate Breakout"
        '
        'BtnUB110
        '
        Me.BtnUB110.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUB110.Location = New System.Drawing.Point(140, 295)
        Me.BtnUB110.Name = "BtnUB110"
        Me.BtnUB110.Size = New System.Drawing.Size(248, 24)
        Me.BtnUB110.TabIndex = 13
        Me.BtnUB110.Text = "UB Form - Bill Info"
        '
        'btnub108
        '
        Me.btnub108.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnub108.Location = New System.Drawing.Point(140, 264)
        Me.btnub108.Name = "btnub108"
        Me.btnub108.Size = New System.Drawing.Size(248, 24)
        Me.btnub108.TabIndex = 12
        Me.btnub108.Text = "Type Codes"
        '
        'btnub106
        '
        Me.btnub106.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnub106.Location = New System.Drawing.Point(140, 233)
        Me.btnub106.Name = "btnub106"
        Me.btnub106.Size = New System.Drawing.Size(248, 24)
        Me.btnub106.TabIndex = 11
        Me.btnub106.Text = "Control File"
        '
        'btnub105
        '
        Me.btnub105.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnub105.Location = New System.Drawing.Point(140, 202)
        Me.btnub105.Name = "btnub105"
        Me.btnub105.Size = New System.Drawing.Size(248, 24)
        Me.btnub105.TabIndex = 10
        Me.btnub105.Text = "Adjustment Codes"
        '
        'btnub104
        '
        Me.btnub104.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnub104.Location = New System.Drawing.Point(140, 112)
        Me.btnub104.Name = "btnub104"
        Me.btnub104.Size = New System.Drawing.Size(248, 24)
        Me.btnub104.TabIndex = 9
        Me.btnub104.Text = "Meter Sizes"
        '
        'btnub103
        '
        Me.btnub103.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnub103.Location = New System.Drawing.Point(140, 81)
        Me.btnub103.Name = "btnub103"
        Me.btnub103.Size = New System.Drawing.Size(248, 24)
        Me.btnub103.TabIndex = 8
        Me.btnub103.Text = "Rate Codes"
        '
        'btnub101
        '
        Me.btnub101.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnub101.Location = New System.Drawing.Point(140, 50)
        Me.btnub101.Name = "btnub101"
        Me.btnub101.Size = New System.Drawing.Size(248, 24)
        Me.btnub101.TabIndex = 7
        Me.btnub101.Text = "District && Phase"
        '
        'label3
        '
        Me.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.Color.Maroon
        Me.label3.Image = CType(resources.GetObject("label3.Image"), System.Drawing.Image)
        Me.label3.Location = New System.Drawing.Point(-8, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(536, 32)
        Me.label3.TabIndex = 6
        '
        'tabadjustments
        '
        Me.tabadjustments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabadjustments.Controls.Add(Me.btnub501)
        Me.tabadjustments.Controls.Add(Me.btnub502)
        Me.tabadjustments.Controls.Add(Me.label7)
        Me.tabadjustments.Location = New System.Drawing.Point(4, 27)
        Me.tabadjustments.Name = "tabadjustments"
        Me.tabadjustments.Size = New System.Drawing.Size(536, 369)
        Me.tabadjustments.TabIndex = 7
        Me.tabadjustments.Text = "Adjustments"
        Me.tabadjustments.Visible = False
        '
        'btnub501
        '
        Me.btnub501.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnub501.Location = New System.Drawing.Point(104, 126)
        Me.btnub501.Name = "btnub501"
        Me.btnub501.Size = New System.Drawing.Size(334, 24)
        Me.btnub501.TabIndex = 16
        Me.btnub501.Text = "Maintain After Bills Adjustments"
        '
        'btnub502
        '
        Me.btnub502.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnub502.Location = New System.Drawing.Point(104, 166)
        Me.btnub502.Name = "btnub502"
        Me.btnub502.Size = New System.Drawing.Size(334, 24)
        Me.btnub502.TabIndex = 15
        Me.btnub502.Text = "Print After Bills Adj Register"
        '
        'label7
        '
        Me.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label7.ForeColor = System.Drawing.Color.Maroon
        Me.label7.Image = CType(resources.GetObject("label7.Image"), System.Drawing.Image)
        Me.label7.Location = New System.Drawing.Point(-8, 0)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(544, 32)
        Me.label7.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label5.Font = New System.Drawing.Font("Cooper Black", 21.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.ImageIndex = 4
        Me.Label5.Location = New System.Drawing.Point(21, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(510, 40)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Utilities"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmMenuUB
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(554, 477)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tab)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmMenuUB"
        Me.tab.ResumeLayout(False)
        Me.tabdaily.ResumeLayout(False)
        Me.tabinterfaces.ResumeLayout(False)
        Me.tabreports.ResumeLayout(False)
        Me.tabbilling.ResumeLayout(False)
        Me.tabtables.ResumeLayout(False)
        Me.tabadjustments.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmMenuUB_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmMain.SbpScreen.Text = "MenuUB"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub FrmMenuUB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    AddHandler btnub101.MouseDown, AddressOf DoMouseDown
    AddHandler btnub102.MouseDown, AddressOf DoMouseDown
    AddHandler btnub103.MouseDown, AddressOf DoMouseDown
    AddHandler btnub104.MouseDown, AddressOf DoMouseDown
    AddHandler btnub105.MouseDown, AddressOf DoMouseDown
    AddHandler btnub106.MouseDown, AddressOf DoMouseDown
    AddHandler btnub107.MouseDown, AddressOf DoMouseDown
    AddHandler btnub114.MouseDown, AddressOf DoMouseDown
    AddHandler btnub108.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB109.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB110.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB111.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB112.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB113.MouseDown, AddressOf DoMouseDown
    AddHandler btnub202.MouseDown, AddressOf DoMouseDown
    AddHandler btnub203.MouseDown, AddressOf DoMouseDown
    AddHandler btnub204.MouseDown, AddressOf DoMouseDown
    AddHandler btnub207.MouseDown, AddressOf DoMouseDown
    AddHandler btnub210.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB211.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB212.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB213.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB214.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB230.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB231.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB232.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB233.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB234.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB235.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB236.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB237.MouseDown, AddressOf DoMouseDown
    AddHandler btnub302.MouseDown, AddressOf DoMouseDown
    AddHandler btnub304.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB305.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB306.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB307.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB340.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB341.MouseDown, AddressOf DoMouseDown
    AddHandler btnub350.MouseDown, AddressOf DoMouseDown
    AddHandler btnub401.MouseDown, AddressOf DoMouseDown
    AddHandler btnub402.MouseDown, AddressOf DoMouseDown
    AddHandler btnub404.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB409.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB410.MouseDown, AddressOf DoMouseDown
    AddHandler btnub411.MouseDown, AddressOf DoMouseDown
    AddHandler btnub412.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB413.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB414.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB430.MouseDown, AddressOf DoMouseDown
    AddHandler BtnUB431.MouseDown, AddressOf DoMouseDown
    AddHandler btnub501.MouseDown, AddressOf DoMouseDown
    AddHandler btnub502.MouseDown, AddressOf DoMouseDown
  End Sub
  Public Sub DoMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    'Handles all button Mouse Clicks on form
    If e.Clicks = 1 Then
      LaunchEXE(Me.ActiveControl.Name)
    End If
  End Sub
  Private Sub FrmMenuUB_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmMenu.Show()
  End Sub
  Private Sub FrmMenuUB_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
    If Me.WindowState = FormWindowState.Minimized Then
      Me.Text = "UB"
    Else
      Me.Text = ""
    End If
  End Sub
  Private Sub FrmMenuUB_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If Not e.Alt Then Exit Sub
    If e.KeyCode = Keys.F12 Then
      MyUtils.PrtScreen(Form.ActiveForm)
    End If
  End Sub

  Private Sub tabdaily_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabdaily.Click

  End Sub

  Private Sub tabinterfaces_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabinterfaces.Click

  End Sub

  Private Sub tabreports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabreports.Click

  End Sub

  Private Sub tabtables_Click(sender As Object, e As EventArgs) Handles tabtables.Click

  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnUB410.Click

  End Sub
End Class
