Public Class FrmMenuTX
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
  Friend WithEvents tab As System.Windows.Forms.TabControl
  Friend WithEvents tabdaily As System.Windows.Forms.TabPage
  Friend WithEvents btntx405 As System.Windows.Forms.Button
  Friend WithEvents btntx404 As System.Windows.Forms.Button
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents btntxa09i As System.Windows.Forms.Button
  Friend WithEvents btntxa09 As System.Windows.Forms.Button
  Friend WithEvents btntx710 As System.Windows.Forms.Button
  Friend WithEvents btntx702 As System.Windows.Forms.Button
  Friend WithEvents btntx701 As System.Windows.Forms.Button
  Friend WithEvents label4 As System.Windows.Forms.Label
  Friend WithEvents btntx302 As System.Windows.Forms.Button
  Friend WithEvents label6 As System.Windows.Forms.Label
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents btntx111 As System.Windows.Forms.Button
  Friend WithEvents btntx110 As System.Windows.Forms.Button
  Friend WithEvents btntx109 As System.Windows.Forms.Button
  Friend WithEvents btntx108 As System.Windows.Forms.Button
  Friend WithEvents btntx107 As System.Windows.Forms.Button
  Friend WithEvents btntx106 As System.Windows.Forms.Button
  Friend WithEvents btntx105 As System.Windows.Forms.Button
  Friend WithEvents btntx104 As System.Windows.Forms.Button
  Friend WithEvents btntx103 As System.Windows.Forms.Button
  Friend WithEvents btntx102 As System.Windows.Forms.Button
  Friend WithEvents btntx101 As System.Windows.Forms.Button
  Friend WithEvents label3 As System.Windows.Forms.Label
  Friend WithEvents label5 As System.Windows.Forms.Label
  Friend WithEvents tabControl2 As System.Windows.Forms.TabControl
  Friend WithEvents tabPage5 As System.Windows.Forms.TabPage
  Friend WithEvents label11 As System.Windows.Forms.Label
  Friend WithEvents tabPage9 As System.Windows.Forms.TabPage
  Friend WithEvents label13 As System.Windows.Forms.Label
  Friend WithEvents tabPage10 As System.Windows.Forms.TabPage
  Friend WithEvents label14 As System.Windows.Forms.Label
  Friend WithEvents btntx210 As System.Windows.Forms.Button
  Friend WithEvents tabPage12 As System.Windows.Forms.TabPage
  Friend WithEvents label15 As System.Windows.Forms.Label
  Friend WithEvents btntxe05 As System.Windows.Forms.Button
  Friend WithEvents label7 As System.Windows.Forms.Label
  Friend WithEvents label8 As System.Windows.Forms.Label
  Friend WithEvents label9 As System.Windows.Forms.Label
  Friend WithEvents BtnTX801 As System.Windows.Forms.Button
  Friend WithEvents btntx301 As System.Windows.Forms.Button
  Friend WithEvents btntxe08 As System.Windows.Forms.Button
  Friend WithEvents btntx311 As System.Windows.Forms.Button
  Friend WithEvents btntx310 As System.Windows.Forms.Button
  Friend WithEvents btntxe13 As System.Windows.Forms.Button
  Friend WithEvents btntxe02 As System.Windows.Forms.Button
  Friend WithEvents btntx201 As System.Windows.Forms.Button
  Friend WithEvents btntx303 As System.Windows.Forms.Button
  Friend WithEvents btntx407 As System.Windows.Forms.Button
  Friend WithEvents btntxa02 As System.Windows.Forms.Button
  Friend WithEvents btntxa01 As System.Windows.Forms.Button
  Friend WithEvents tabCC As System.Windows.Forms.TabPage
  Friend WithEvents tabBills As System.Windows.Forms.TabPage
  Friend WithEvents tabprebilling As System.Windows.Forms.TabPage
  Friend WithEvents tabtables As System.Windows.Forms.TabPage
  Friend WithEvents tabreports As System.Windows.Forms.TabPage
  Friend WithEvents tabsuspense As System.Windows.Forms.TabPage
  Friend WithEvents tabelectronicbanking As System.Windows.Forms.TabPage
  Friend WithEvents tabutilities As System.Windows.Forms.TabPage
  Friend WithEvents tabassessorinq As System.Windows.Forms.TabPage
  Friend WithEvents btnTXD01 As System.Windows.Forms.Button
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents btntx304 As System.Windows.Forms.Button
  Friend WithEvents btntx314 As System.Windows.Forms.Button
  Friend WithEvents btntx313 As System.Windows.Forms.Button
  Friend WithEvents btntx312 As System.Windows.Forms.Button
  Friend WithEvents btntx410 As System.Windows.Forms.Button
  Friend WithEvents btntx402 As System.Windows.Forms.Button
  Friend WithEvents btntx401 As System.Windows.Forms.Button
  Friend WithEvents btntxe15 As System.Windows.Forms.Button
  Friend WithEvents btntxe24 As System.Windows.Forms.Button
  Friend WithEvents btntxe06 As System.Windows.Forms.Button
  Friend WithEvents btntxe14 As System.Windows.Forms.Button
  Friend WithEvents btntxe25 As System.Windows.Forms.Button
  Friend WithEvents btntx505 As System.Windows.Forms.Button
  Friend WithEvents btntx506 As System.Windows.Forms.Button
  Friend WithEvents btntxe09 As System.Windows.Forms.Button
  Friend WithEvents btntxe12 As System.Windows.Forms.Button
  Friend WithEvents btntxe10 As System.Windows.Forms.Button
  Friend WithEvents btnto107 As System.Windows.Forms.Button
  Friend WithEvents btnto114 As System.Windows.Forms.Button
  Friend WithEvents btnto113 As System.Windows.Forms.Button
  Friend WithEvents btnto112 As System.Windows.Forms.Button
  Friend WithEvents btnto111 As System.Windows.Forms.Button
  Friend WithEvents btnto110 As System.Windows.Forms.Button
  Friend WithEvents btnto105 As System.Windows.Forms.Button
  Friend WithEvents btnto104 As System.Windows.Forms.Button
  Friend WithEvents btnto103 As System.Windows.Forms.Button
  Friend WithEvents btnto109 As System.Windows.Forms.Button
  Friend WithEvents btnto106 As System.Windows.Forms.Button
  Friend WithEvents btnto102 As System.Windows.Forms.Button
  Friend WithEvents btnto101 As System.Windows.Forms.Button
  Friend WithEvents btntx211 As System.Windows.Forms.Button
  Friend WithEvents btntxe20 As System.Windows.Forms.Button
  Friend WithEvents btntxe16 As System.Windows.Forms.Button
  Friend WithEvents btntxe18 As System.Windows.Forms.Button
  Friend WithEvents btntxe04 As System.Windows.Forms.Button
  Friend WithEvents btntxe17 As System.Windows.Forms.Button
  Friend WithEvents btntxe11 As System.Windows.Forms.Button
  Friend WithEvents btntx901 As System.Windows.Forms.Button
  Friend WithEvents btntx902 As System.Windows.Forms.Button
  Friend WithEvents btntx904 As System.Windows.Forms.Button
  Friend WithEvents btntx903 As System.Windows.Forms.Button
  Friend WithEvents btntx406 As System.Windows.Forms.Button
  Friend WithEvents btntxa12 As System.Windows.Forms.Button
  Friend WithEvents btntx802 As System.Windows.Forms.Button
  Friend WithEvents btntx810 As System.Windows.Forms.Button
  Friend WithEvents btntx808 As System.Windows.Forms.Button
  Friend WithEvents btntx411 As System.Windows.Forms.Button
  Friend WithEvents BtnTXA04 As System.Windows.Forms.Button
  Friend WithEvents Btntxe26 As System.Windows.Forms.Button
  Friend WithEvents BtnTXA03 As System.Windows.Forms.Button
  Friend WithEvents BtnTXA05 As System.Windows.Forms.Button
  Friend WithEvents BtnTxa08 As System.Windows.Forms.Button
  Friend WithEvents btntxe03 As System.Windows.Forms.Button
  Friend WithEvents BtnTO120 As System.Windows.Forms.Button
  Friend WithEvents BtnTX203 As System.Windows.Forms.Button
  Friend WithEvents BtnTXE40 As System.Windows.Forms.Button
  Friend WithEvents BtnTX412 As System.Windows.Forms.Button
  Friend WithEvents btnto116 As System.Windows.Forms.Button
  Friend WithEvents BtnTXE42 As System.Windows.Forms.Button
  Friend WithEvents btntxe21 As System.Windows.Forms.Button
  Friend WithEvents BtnTO206 As System.Windows.Forms.Button
  Friend WithEvents BtnTO200 As System.Windows.Forms.Button
  Friend WithEvents BtnTX112 As System.Windows.Forms.Button
  Friend WithEvents BtnTX113 As System.Windows.Forms.Button
  Friend WithEvents BtnTX340 As System.Windows.Forms.Button
  Friend WithEvents BtnTXE43 As System.Windows.Forms.Button
  Friend WithEvents BtnTX830 As System.Windows.Forms.Button
  Friend WithEvents BtnTXE44 As System.Windows.Forms.Button
  Friend WithEvents BtnTX114 As System.Windows.Forms.Button
  Friend WithEvents BtnTXE45 As System.Windows.Forms.Button
  Friend WithEvents BtnTXE46 As System.Windows.Forms.Button
  Friend WithEvents BtnTXE47 As System.Windows.Forms.Button
  Friend WithEvents BtnTXE48 As System.Windows.Forms.Button
  Friend WithEvents BtnTXE49 As System.Windows.Forms.Button
  Friend WithEvents tabAddl As System.Windows.Forms.TabPage
  Friend WithEvents BtnTX351 As System.Windows.Forms.Button
  Friend WithEvents BtnTX352 As System.Windows.Forms.Button
  Friend WithEvents BtnTX350 As System.Windows.Forms.Button
  Friend WithEvents btntx501 As System.Windows.Forms.Button
  Friend WithEvents BtnTX115 As System.Windows.Forms.Button
  Friend WithEvents BtnTXE50 As System.Windows.Forms.Button
  Friend WithEvents BtnTXE51 As System.Windows.Forms.Button
  Friend WithEvents BtnTO300 As System.Windows.Forms.Button
  Friend WithEvents BtnTO301 As System.Windows.Forms.Button
  Friend WithEvents BtnTX116 As System.Windows.Forms.Button
  Friend WithEvents BtnTXE52 As System.Windows.Forms.Button
  Friend WithEvents BtnTXE53 As System.Windows.Forms.Button
  Friend WithEvents BtnTX809 As System.Windows.Forms.Button
  Friend WithEvents BtnTXA06 As System.Windows.Forms.Button
  Friend WithEvents BtnTX117 As System.Windows.Forms.Button
  Friend WithEvents BtnTXE54 As System.Windows.Forms.Button
  Friend WithEvents BtnTX430 As System.Windows.Forms.Button
  Friend WithEvents BtnTX118 As System.Windows.Forms.Button
  Friend WithEvents BtnTXE55 As System.Windows.Forms.Button
  Friend WithEvents Label10 As Label
  Friend WithEvents BtnTXA31 As Button
  Friend WithEvents BtnTXA32 As Button
  Friend WithEvents BtnTX831 As Button
    Friend WithEvents BtnTXE56 As Button
    Friend WithEvents btntx816 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMenuTX))
    Me.tab = New System.Windows.Forms.TabControl()
    Me.tabdaily = New System.Windows.Forms.TabPage()
    Me.BtnTXA06 = New System.Windows.Forms.Button()
    Me.BtnTxa08 = New System.Windows.Forms.Button()
    Me.BtnTXA05 = New System.Windows.Forms.Button()
    Me.BtnTXA03 = New System.Windows.Forms.Button()
    Me.BtnTXA04 = New System.Windows.Forms.Button()
    Me.btntx405 = New System.Windows.Forms.Button()
    Me.btntx404 = New System.Windows.Forms.Button()
    Me.label1 = New System.Windows.Forms.Label()
    Me.btntxa02 = New System.Windows.Forms.Button()
    Me.btntxa01 = New System.Windows.Forms.Button()
    Me.btntxa09i = New System.Windows.Forms.Button()
    Me.btntxa09 = New System.Windows.Forms.Button()
    Me.tabelectronicbanking = New System.Windows.Forms.TabPage()
        Me.BtnTX831 = New System.Windows.Forms.Button()
        Me.BtnTXE55 = New System.Windows.Forms.Button()
        Me.BtnTX809 = New System.Windows.Forms.Button()
        Me.BtnTX830 = New System.Windows.Forms.Button()
        Me.btntx816 = New System.Windows.Forms.Button()
        Me.BtnTX801 = New System.Windows.Forms.Button()
        Me.btntx802 = New System.Windows.Forms.Button()
        Me.btntx810 = New System.Windows.Forms.Button()
        Me.btntx808 = New System.Windows.Forms.Button()
        Me.label8 = New System.Windows.Forms.Label()
        Me.tabassessorinq = New System.Windows.Forms.TabPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnTXD01 = New System.Windows.Forms.Button()
        Me.tabutilities = New System.Windows.Forms.TabPage()
        Me.BtnTXA32 = New System.Windows.Forms.Button()
        Me.BtnTXA31 = New System.Windows.Forms.Button()
        Me.BtnTXE54 = New System.Windows.Forms.Button()
        Me.BtnTXE53 = New System.Windows.Forms.Button()
        Me.BtnTO301 = New System.Windows.Forms.Button()
        Me.BtnTO300 = New System.Windows.Forms.Button()
        Me.BtnTXE50 = New System.Windows.Forms.Button()
        Me.BtnTXE49 = New System.Windows.Forms.Button()
        Me.BtnTXE48 = New System.Windows.Forms.Button()
        Me.BtnTXE46 = New System.Windows.Forms.Button()
        Me.BtnTXE44 = New System.Windows.Forms.Button()
        Me.BtnTX412 = New System.Windows.Forms.Button()
        Me.btntxa12 = New System.Windows.Forms.Button()
        Me.btntx406 = New System.Windows.Forms.Button()
        Me.btntx407 = New System.Windows.Forms.Button()
        Me.label9 = New System.Windows.Forms.Label()
        Me.tabBills = New System.Windows.Forms.TabPage()
        Me.BtnTX340 = New System.Windows.Forms.Button()
        Me.BtnTXE42 = New System.Windows.Forms.Button()
        Me.btntx302 = New System.Windows.Forms.Button()
        Me.btntx314 = New System.Windows.Forms.Button()
        Me.btntx313 = New System.Windows.Forms.Button()
        Me.btntx312 = New System.Windows.Forms.Button()
        Me.btntx311 = New System.Windows.Forms.Button()
        Me.btntx310 = New System.Windows.Forms.Button()
        Me.btntx304 = New System.Windows.Forms.Button()
        Me.btntx303 = New System.Windows.Forms.Button()
        Me.btntx301 = New System.Windows.Forms.Button()
        Me.label6 = New System.Windows.Forms.Label()
        Me.tabprebilling = New System.Windows.Forms.TabPage()
        Me.BtnTX430 = New System.Windows.Forms.Button()
        Me.btntx501 = New System.Windows.Forms.Button()
        Me.BtnTXE45 = New System.Windows.Forms.Button()
        Me.btntxe15 = New System.Windows.Forms.Button()
        Me.btntx411 = New System.Windows.Forms.Button()
        Me.btntx410 = New System.Windows.Forms.Button()
        Me.btntx402 = New System.Windows.Forms.Button()
        Me.btntx401 = New System.Windows.Forms.Button()
        Me.label2 = New System.Windows.Forms.Label()
        Me.tabtables = New System.Windows.Forms.TabPage()
        Me.BtnTX118 = New System.Windows.Forms.Button()
        Me.BtnTX117 = New System.Windows.Forms.Button()
        Me.BtnTX116 = New System.Windows.Forms.Button()
        Me.BtnTX115 = New System.Windows.Forms.Button()
        Me.BtnTX114 = New System.Windows.Forms.Button()
        Me.BtnTX113 = New System.Windows.Forms.Button()
        Me.BtnTX112 = New System.Windows.Forms.Button()
        Me.btntx111 = New System.Windows.Forms.Button()
        Me.btntx110 = New System.Windows.Forms.Button()
        Me.btntx109 = New System.Windows.Forms.Button()
        Me.btntx108 = New System.Windows.Forms.Button()
        Me.btntx107 = New System.Windows.Forms.Button()
        Me.btntx106 = New System.Windows.Forms.Button()
        Me.btntx105 = New System.Windows.Forms.Button()
        Me.btntx104 = New System.Windows.Forms.Button()
        Me.btntx103 = New System.Windows.Forms.Button()
        Me.btntx102 = New System.Windows.Forms.Button()
        Me.btntx101 = New System.Windows.Forms.Button()
        Me.label3 = New System.Windows.Forms.Label()
        Me.tabreports = New System.Windows.Forms.TabPage()
        Me.label5 = New System.Windows.Forms.Label()
        Me.tabControl2 = New System.Windows.Forms.TabControl()
        Me.tabPage5 = New System.Windows.Forms.TabPage()
        Me.BtnTXE52 = New System.Windows.Forms.Button()
        Me.BtnTXE47 = New System.Windows.Forms.Button()
        Me.BtnTXE43 = New System.Windows.Forms.Button()
        Me.btntxe21 = New System.Windows.Forms.Button()
        Me.btntxe12 = New System.Windows.Forms.Button()
        Me.btntx506 = New System.Windows.Forms.Button()
        Me.btntx505 = New System.Windows.Forms.Button()
        Me.label11 = New System.Windows.Forms.Label()
        Me.btntxe25 = New System.Windows.Forms.Button()
        Me.btntxe24 = New System.Windows.Forms.Button()
        Me.btntxe10 = New System.Windows.Forms.Button()
        Me.btntxe09 = New System.Windows.Forms.Button()
        Me.btntxe06 = New System.Windows.Forms.Button()
        Me.btntxe14 = New System.Windows.Forms.Button()
        Me.btntxe11 = New System.Windows.Forms.Button()
        Me.tabPage9 = New System.Windows.Forms.TabPage()
        Me.BtnTO206 = New System.Windows.Forms.Button()
        Me.BtnTO200 = New System.Windows.Forms.Button()
        Me.btnto116 = New System.Windows.Forms.Button()
        Me.BtnTO120 = New System.Windows.Forms.Button()
        Me.label13 = New System.Windows.Forms.Label()
        Me.btnto107 = New System.Windows.Forms.Button()
        Me.btnto114 = New System.Windows.Forms.Button()
        Me.btnto113 = New System.Windows.Forms.Button()
        Me.btnto112 = New System.Windows.Forms.Button()
        Me.btnto111 = New System.Windows.Forms.Button()
        Me.btnto110 = New System.Windows.Forms.Button()
        Me.btnto105 = New System.Windows.Forms.Button()
        Me.btnto104 = New System.Windows.Forms.Button()
        Me.btnto103 = New System.Windows.Forms.Button()
        Me.btnto109 = New System.Windows.Forms.Button()
        Me.btnto106 = New System.Windows.Forms.Button()
        Me.btnto102 = New System.Windows.Forms.Button()
        Me.btnto101 = New System.Windows.Forms.Button()
        Me.tabPage10 = New System.Windows.Forms.TabPage()
        Me.BtnTX203 = New System.Windows.Forms.Button()
        Me.label14 = New System.Windows.Forms.Label()
        Me.btntx211 = New System.Windows.Forms.Button()
        Me.btntx210 = New System.Windows.Forms.Button()
        Me.btntx201 = New System.Windows.Forms.Button()
        Me.tabPage12 = New System.Windows.Forms.TabPage()
        Me.BtnTXE56 = New System.Windows.Forms.Button()
        Me.BtnTXE51 = New System.Windows.Forms.Button()
        Me.BtnTXE40 = New System.Windows.Forms.Button()
        Me.btntxe03 = New System.Windows.Forms.Button()
        Me.Btntxe26 = New System.Windows.Forms.Button()
        Me.btntxe04 = New System.Windows.Forms.Button()
        Me.btntxe20 = New System.Windows.Forms.Button()
        Me.btntxe18 = New System.Windows.Forms.Button()
        Me.btntxe17 = New System.Windows.Forms.Button()
        Me.btntxe16 = New System.Windows.Forms.Button()
        Me.btntxe13 = New System.Windows.Forms.Button()
        Me.label15 = New System.Windows.Forms.Label()
        Me.btntxe08 = New System.Windows.Forms.Button()
        Me.btntxe05 = New System.Windows.Forms.Button()
        Me.btntxe02 = New System.Windows.Forms.Button()
        Me.tabsuspense = New System.Windows.Forms.TabPage()
        Me.btntx901 = New System.Windows.Forms.Button()
        Me.btntx902 = New System.Windows.Forms.Button()
        Me.btntx904 = New System.Windows.Forms.Button()
        Me.btntx903 = New System.Windows.Forms.Button()
        Me.label7 = New System.Windows.Forms.Label()
        Me.tabCC = New System.Windows.Forms.TabPage()
        Me.btntx710 = New System.Windows.Forms.Button()
        Me.btntx702 = New System.Windows.Forms.Button()
        Me.btntx701 = New System.Windows.Forms.Button()
        Me.label4 = New System.Windows.Forms.Label()
        Me.tabAddl = New System.Windows.Forms.TabPage()
        Me.BtnTX351 = New System.Windows.Forms.Button()
        Me.BtnTX352 = New System.Windows.Forms.Button()
        Me.BtnTX350 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tab.SuspendLayout()
        Me.tabdaily.SuspendLayout()
        Me.tabelectronicbanking.SuspendLayout()
        Me.tabassessorinq.SuspendLayout()
        Me.tabutilities.SuspendLayout()
        Me.tabBills.SuspendLayout()
        Me.tabprebilling.SuspendLayout()
        Me.tabtables.SuspendLayout()
        Me.tabreports.SuspendLayout()
        Me.tabControl2.SuspendLayout()
        Me.tabPage5.SuspendLayout()
        Me.tabPage9.SuspendLayout()
        Me.tabPage10.SuspendLayout()
        Me.tabPage12.SuspendLayout()
        Me.tabsuspense.SuspendLayout()
        Me.tabCC.SuspendLayout()
        Me.tabAddl.SuspendLayout()
        Me.SuspendLayout()
        '
        'tab
        '
        Me.tab.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.tab.Controls.Add(Me.tabdaily)
        Me.tab.Controls.Add(Me.tabelectronicbanking)
        Me.tab.Controls.Add(Me.tabassessorinq)
        Me.tab.Controls.Add(Me.tabutilities)
        Me.tab.Controls.Add(Me.tabBills)
        Me.tab.Controls.Add(Me.tabprebilling)
        Me.tab.Controls.Add(Me.tabtables)
        Me.tab.Controls.Add(Me.tabreports)
        Me.tab.Controls.Add(Me.tabsuspense)
        Me.tab.Controls.Add(Me.tabCC)
        Me.tab.Controls.Add(Me.tabAddl)
        Me.tab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tab.Location = New System.Drawing.Point(16, 56)
        Me.tab.Multiline = True
        Me.tab.Name = "tab"
        Me.tab.SelectedIndex = 0
        Me.tab.Size = New System.Drawing.Size(582, 437)
        Me.tab.TabIndex = 0
        '
        'tabdaily
        '
        Me.tabdaily.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabdaily.Controls.Add(Me.BtnTXA06)
        Me.tabdaily.Controls.Add(Me.BtnTxa08)
        Me.tabdaily.Controls.Add(Me.BtnTXA05)
        Me.tabdaily.Controls.Add(Me.BtnTXA03)
        Me.tabdaily.Controls.Add(Me.BtnTXA04)
        Me.tabdaily.Controls.Add(Me.btntx405)
        Me.tabdaily.Controls.Add(Me.btntx404)
        Me.tabdaily.Controls.Add(Me.label1)
        Me.tabdaily.Controls.Add(Me.btntxa02)
        Me.tabdaily.Controls.Add(Me.btntxa01)
        Me.tabdaily.Controls.Add(Me.btntxa09i)
        Me.tabdaily.Controls.Add(Me.btntxa09)
        Me.tabdaily.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabdaily.Location = New System.Drawing.Point(4, 53)
        Me.tabdaily.Name = "tabdaily"
        Me.tabdaily.Size = New System.Drawing.Size(574, 380)
        Me.tabdaily.TabIndex = 0
        Me.tabdaily.Text = "Daily Cash Receipts"
        Me.tabdaily.UseVisualStyleBackColor = True
        '
        'BtnTXA06
        '
        Me.BtnTXA06.Location = New System.Drawing.Point(142, 219)
        Me.BtnTXA06.Name = "BtnTXA06"
        Me.BtnTXA06.Size = New System.Drawing.Size(248, 24)
        Me.BtnTXA06.TabIndex = 10
        Me.BtnTXA06.Text = "Load Leasing Company"
        '
        'BtnTxa08
        '
        Me.BtnTxa08.Location = New System.Drawing.Point(142, 249)
        Me.BtnTxa08.Name = "BtnTxa08"
        Me.BtnTxa08.Size = New System.Drawing.Size(248, 24)
        Me.BtnTxa08.TabIndex = 9
        Me.BtnTxa08.Text = "Load Web Receipts"
        '
        'BtnTXA05
        '
        Me.BtnTXA05.Location = New System.Drawing.Point(142, 277)
        Me.BtnTXA05.Name = "BtnTXA05"
        Me.BtnTXA05.Size = New System.Drawing.Size(248, 24)
        Me.BtnTXA05.TabIndex = 6
        Me.BtnTXA05.Text = "Load Create Penny Batch/Report"
        '
        'BtnTXA03
        '
        Me.BtnTXA03.Location = New System.Drawing.Point(142, 161)
        Me.BtnTXA03.Name = "BtnTXA03"
        Me.BtnTXA03.Size = New System.Drawing.Size(248, 24)
        Me.BtnTXA03.TabIndex = 4
        Me.BtnTXA03.Text = "Load Bank Escrow"
        '
        'BtnTXA04
        '
        Me.BtnTXA04.Location = New System.Drawing.Point(142, 189)
        Me.BtnTXA04.Name = "BtnTXA04"
        Me.BtnTXA04.Size = New System.Drawing.Size(248, 24)
        Me.BtnTXA04.TabIndex = 5
        Me.BtnTXA04.Text = "Load Bank Services"
        '
        'btntx405
        '
        Me.btntx405.ForeColor = System.Drawing.Color.Black
        Me.btntx405.Location = New System.Drawing.Point(142, 333)
        Me.btntx405.Name = "btntx405"
        Me.btntx405.Size = New System.Drawing.Size(248, 24)
        Me.btntx405.TabIndex = 8
        Me.btntx405.Text = "Maintain Tax Invoices"
        '
        'btntx404
        '
        Me.btntx404.ForeColor = System.Drawing.Color.Black
        Me.btntx404.Location = New System.Drawing.Point(142, 305)
        Me.btntx404.Name = "btntx404"
        Me.btntx404.Size = New System.Drawing.Size(248, 24)
        Me.btntx404.TabIndex = 7
        Me.btntx404.Text = "On Line Statements"
        '
        'label1
        '
        Me.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.Maroon
        Me.label1.Image = CType(resources.GetObject("label1.Image"), System.Drawing.Image)
        Me.label1.Location = New System.Drawing.Point(0, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(536, 32)
        Me.label1.TabIndex = 5
        '
        'btntxa02
        '
        Me.btntxa02.Location = New System.Drawing.Point(142, 133)
        Me.btntxa02.Name = "btntxa02"
        Me.btntxa02.Size = New System.Drawing.Size(248, 24)
        Me.btntxa02.TabIndex = 3
        Me.btntxa02.Text = "Load Bank Receipts (Lockbox)"
        '
        'btntxa01
        '
        Me.btntxa01.Location = New System.Drawing.Point(142, 105)
        Me.btntxa01.Name = "btntxa01"
        Me.btntxa01.Size = New System.Drawing.Size(248, 24)
        Me.btntxa01.TabIndex = 2
        Me.btntxa01.Text = "Edit and Post Electronic Receipts"
        '
        'btntxa09i
        '
        Me.btntxa09i.Location = New System.Drawing.Point(142, 77)
        Me.btntxa09i.Name = "btntxa09i"
        Me.btntxa09i.Size = New System.Drawing.Size(248, 24)
        Me.btntxa09i.TabIndex = 1
        Me.btntxa09i.Text = "Inquiry"
        '
        'btntxa09
        '
        Me.btntxa09.Location = New System.Drawing.Point(142, 49)
        Me.btntxa09.Name = "btntxa09"
        Me.btntxa09.Size = New System.Drawing.Size(248, 24)
        Me.btntxa09.TabIndex = 0
        Me.btntxa09.Text = "Daily Cash Register"
        '
        'tabelectronicbanking
        '
        Me.tabelectronicbanking.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabelectronicbanking.Controls.Add(Me.BtnTX831)
        Me.tabelectronicbanking.Controls.Add(Me.BtnTXE55)
        Me.tabelectronicbanking.Controls.Add(Me.BtnTX809)
        Me.tabelectronicbanking.Controls.Add(Me.BtnTX830)
        Me.tabelectronicbanking.Controls.Add(Me.btntx816)
        Me.tabelectronicbanking.Controls.Add(Me.BtnTX801)
        Me.tabelectronicbanking.Controls.Add(Me.btntx802)
        Me.tabelectronicbanking.Controls.Add(Me.btntx810)
        Me.tabelectronicbanking.Controls.Add(Me.btntx808)
        Me.tabelectronicbanking.Controls.Add(Me.label8)
        Me.tabelectronicbanking.Location = New System.Drawing.Point(4, 53)
        Me.tabelectronicbanking.Name = "tabelectronicbanking"
        Me.tabelectronicbanking.Size = New System.Drawing.Size(574, 380)
        Me.tabelectronicbanking.TabIndex = 9
        Me.tabelectronicbanking.Text = "Electronic Banking"
        Me.tabelectronicbanking.UseVisualStyleBackColor = True
        Me.tabelectronicbanking.Visible = False
        '
        'BtnTX831
        '
        Me.BtnTX831.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTX831.Location = New System.Drawing.Point(144, 278)
        Me.BtnTX831.Name = "BtnTX831"
        Me.BtnTX831.Size = New System.Drawing.Size(272, 24)
        Me.BtnTX831.TabIndex = 17
        Me.BtnTX831.Text = "Create File for Tax Adds (WEBADDS)"
        '
        'BtnTXE55
        '
        Me.BtnTXE55.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTXE55.Location = New System.Drawing.Point(144, 308)
        Me.BtnTXE55.Name = "BtnTXE55"
        Me.BtnTXE55.Size = New System.Drawing.Size(272, 24)
        Me.BtnTXE55.TabIndex = 16
        Me.BtnTXE55.Text = "Create Current/Delq File (Corelogic)"
        '
        'BtnTX809
        '
        Me.BtnTX809.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTX809.Location = New System.Drawing.Point(144, 158)
        Me.BtnTX809.Name = "BtnTX809"
        Me.BtnTX809.Size = New System.Drawing.Size(272, 24)
        Me.BtnTX809.TabIndex = 15
        Me.BtnTX809.Text = "Leasing Company List"
        '
        'BtnTX830
        '
        Me.BtnTX830.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTX830.Location = New System.Drawing.Point(144, 248)
        Me.BtnTX830.Name = "BtnTX830"
        Me.BtnTX830.Size = New System.Drawing.Size(272, 24)
        Me.BtnTX830.TabIndex = 14
        Me.BtnTX830.Text = "Create File for Tax Payments (WEBPAY)"
        '
        'btntx816
        '
        Me.btntx816.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx816.Location = New System.Drawing.Point(144, 218)
        Me.btntx816.Name = "btntx816"
        Me.btntx816.Size = New System.Drawing.Size(272, 24)
        Me.btntx816.TabIndex = 13
        Me.btntx816.Text = "Create File for Tax History (WEBHIST)"
        '
        'BtnTX801
        '
        Me.BtnTX801.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTX801.Location = New System.Drawing.Point(144, 68)
        Me.BtnTX801.Name = "BtnTX801"
        Me.BtnTX801.Size = New System.Drawing.Size(272, 24)
        Me.BtnTX801.TabIndex = 11
        Me.BtnTX801.Text = "Create Bank Service Pre-Billing File"
        '
        'btntx802
        '
        Me.btntx802.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx802.Location = New System.Drawing.Point(144, 98)
        Me.btntx802.Name = "btntx802"
        Me.btntx802.Size = New System.Drawing.Size(272, 24)
        Me.btntx802.TabIndex = 10
        Me.btntx802.Text = "Interface Bank Codes To Billing File"
        '
        'btntx810
        '
        Me.btntx810.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx810.Location = New System.Drawing.Point(144, 188)
        Me.btntx810.Name = "btntx810"
        Me.btntx810.Size = New System.Drawing.Size(272, 24)
        Me.btntx810.TabIndex = 9
        Me.btntx810.Text = "Create Delinquent Bill File"
        '
        'btntx808
        '
        Me.btntx808.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx808.Location = New System.Drawing.Point(144, 128)
        Me.btntx808.Name = "btntx808"
        Me.btntx808.Size = New System.Drawing.Size(272, 24)
        Me.btntx808.TabIndex = 7
        Me.btntx808.Text = "Create Bank Service Billing File"
        '
        'label8
        '
        Me.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label8.ForeColor = System.Drawing.Color.Maroon
        Me.label8.Image = CType(resources.GetObject("label8.Image"), System.Drawing.Image)
        Me.label8.Location = New System.Drawing.Point(-8, 0)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(544, 32)
        Me.label8.TabIndex = 6
        '
        'tabassessorinq
        '
        Me.tabassessorinq.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabassessorinq.Controls.Add(Me.Label12)
        Me.tabassessorinq.Controls.Add(Me.btnTXD01)
        Me.tabassessorinq.Location = New System.Drawing.Point(4, 53)
        Me.tabassessorinq.Name = "tabassessorinq"
        Me.tabassessorinq.Size = New System.Drawing.Size(574, 380)
        Me.tabassessorinq.TabIndex = 11
        Me.tabassessorinq.Text = "Assessor Inquiry"
        Me.tabassessorinq.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Maroon
        Me.Label12.Image = CType(resources.GetObject("Label12.Image"), System.Drawing.Image)
        Me.Label12.Location = New System.Drawing.Point(0, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(536, 32)
        Me.Label12.TabIndex = 7
        '
        'btnTXD01
        '
        Me.btnTXD01.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTXD01.Location = New System.Drawing.Point(140, 112)
        Me.btnTXD01.Name = "btnTXD01"
        Me.btnTXD01.Size = New System.Drawing.Size(248, 24)
        Me.btnTXD01.TabIndex = 1
        Me.btnTXD01.Text = "Assessment Information"
        '
        'tabutilities
        '
        Me.tabutilities.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabutilities.Controls.Add(Me.BtnTXA32)
        Me.tabutilities.Controls.Add(Me.BtnTXA31)
        Me.tabutilities.Controls.Add(Me.BtnTXE54)
        Me.tabutilities.Controls.Add(Me.BtnTXE53)
        Me.tabutilities.Controls.Add(Me.BtnTO301)
        Me.tabutilities.Controls.Add(Me.BtnTO300)
        Me.tabutilities.Controls.Add(Me.BtnTXE50)
        Me.tabutilities.Controls.Add(Me.BtnTXE49)
        Me.tabutilities.Controls.Add(Me.BtnTXE48)
        Me.tabutilities.Controls.Add(Me.BtnTXE46)
        Me.tabutilities.Controls.Add(Me.BtnTXE44)
        Me.tabutilities.Controls.Add(Me.BtnTX412)
        Me.tabutilities.Controls.Add(Me.btntxa12)
        Me.tabutilities.Controls.Add(Me.btntx406)
        Me.tabutilities.Controls.Add(Me.btntx407)
        Me.tabutilities.Controls.Add(Me.label9)
        Me.tabutilities.Location = New System.Drawing.Point(4, 53)
        Me.tabutilities.Name = "tabutilities"
        Me.tabutilities.Size = New System.Drawing.Size(574, 380)
        Me.tabutilities.TabIndex = 10
        Me.tabutilities.Text = "Utilities"
        Me.tabutilities.UseVisualStyleBackColor = True
        Me.tabutilities.Visible = False
        '
        'BtnTXA32
        '
        Me.BtnTXA32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTXA32.Location = New System.Drawing.Point(29, 307)
        Me.BtnTXA32.Name = "BtnTXA32"
        Me.BtnTXA32.Size = New System.Drawing.Size(248, 24)
        Me.BtnTXA32.TabIndex = 40
        Me.BtnTXA32.Text = "Copy Comments"
        '
        'BtnTXA31
        '
        Me.BtnTXA31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTXA31.Location = New System.Drawing.Point(29, 277)
        Me.BtnTXA31.Name = "BtnTXA31"
        Me.BtnTXA31.Size = New System.Drawing.Size(248, 24)
        Me.BtnTXA31.TabIndex = 39
        Me.BtnTXA31.Text = "Copy Status Code"
        '
        'BtnTXE54
        '
        Me.BtnTXE54.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTXE54.ForeColor = System.Drawing.Color.Black
        Me.BtnTXE54.Location = New System.Drawing.Point(29, 247)
        Me.BtnTXE54.Name = "BtnTXE54"
        Me.BtnTXE54.Size = New System.Drawing.Size(248, 24)
        Me.BtnTXE54.TabIndex = 38
        Me.BtnTXE54.Text = "Update Leasing Company"
        '
        'BtnTXE53
        '
        Me.BtnTXE53.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTXE53.ForeColor = System.Drawing.Color.Black
        Me.BtnTXE53.Location = New System.Drawing.Point(299, 217)
        Me.BtnTXE53.Name = "BtnTXE53"
        Me.BtnTXE53.Size = New System.Drawing.Size(248, 24)
        Me.BtnTXE53.TabIndex = 37
        Me.BtnTXE53.Text = "Create ViewPermit Delinquent File"
        '
        'BtnTO301
        '
        Me.BtnTO301.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTO301.ForeColor = System.Drawing.Color.Black
        Me.BtnTO301.Location = New System.Drawing.Point(29, 129)
        Me.BtnTO301.Name = "BtnTO301"
        Me.BtnTO301.Size = New System.Drawing.Size(248, 24)
        Me.BtnTO301.TabIndex = 36
        Me.BtnTO301.Text = "Maintain DMV Vehicle Data"
        '
        'BtnTO300
        '
        Me.BtnTO300.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTO300.ForeColor = System.Drawing.Color.Black
        Me.BtnTO300.Location = New System.Drawing.Point(29, 99)
        Me.BtnTO300.Name = "BtnTO300"
        Me.BtnTO300.Size = New System.Drawing.Size(248, 24)
        Me.BtnTO300.TabIndex = 35
        Me.BtnTO300.Text = "Maintain DMV Customer Data"
        '
        'BtnTXE50
        '
        Me.BtnTXE50.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTXE50.ForeColor = System.Drawing.Color.Black
        Me.BtnTXE50.Location = New System.Drawing.Point(299, 189)
        Me.BtnTXE50.Name = "BtnTXE50"
        Me.BtnTXE50.Size = New System.Drawing.Size(248, 24)
        Me.BtnTXE50.TabIndex = 34
        Me.BtnTXE50.Text = "Flag Accts for Collection Agency"
        '
        'BtnTXE49
        '
        Me.BtnTXE49.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTXE49.ForeColor = System.Drawing.Color.Black
        Me.BtnTXE49.Location = New System.Drawing.Point(299, 129)
        Me.BtnTXE49.Name = "BtnTXE49"
        Me.BtnTXE49.Size = New System.Drawing.Size(248, 24)
        Me.BtnTXE49.TabIndex = 33
        Me.BtnTXE49.Text = "Update Tax Invoice Name/Address"
        '
        'BtnTXE48
        '
        Me.BtnTXE48.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTXE48.ForeColor = System.Drawing.Color.Black
        Me.BtnTXE48.Location = New System.Drawing.Point(299, 159)
        Me.BtnTXE48.Name = "BtnTXE48"
        Me.BtnTXE48.Size = New System.Drawing.Size(248, 24)
        Me.BtnTXE48.TabIndex = 32
        Me.BtnTXE48.Text = "Refresh Delinquent Status by List # File"
        '
        'BtnTXE46
        '
        Me.BtnTXE46.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTXE46.ForeColor = System.Drawing.Color.Black
        Me.BtnTXE46.Location = New System.Drawing.Point(299, 99)
        Me.BtnTXE46.Name = "BtnTXE46"
        Me.BtnTXE46.Size = New System.Drawing.Size(248, 24)
        Me.BtnTXE46.TabIndex = 31
        Me.BtnTXE46.Text = "Update Tax Invoice Property Location"
        '
        'BtnTXE44
        '
        Me.BtnTXE44.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTXE44.ForeColor = System.Drawing.Color.Black
        Me.BtnTXE44.Location = New System.Drawing.Point(299, 69)
        Me.BtnTXE44.Name = "BtnTXE44"
        Me.BtnTXE44.Size = New System.Drawing.Size(248, 24)
        Me.BtnTXE44.TabIndex = 30
        Me.BtnTXE44.Text = "Reset Back Tax Codes"
        '
        'BtnTX412
        '
        Me.BtnTX412.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTX412.ForeColor = System.Drawing.Color.Black
        Me.BtnTX412.Location = New System.Drawing.Point(29, 217)
        Me.BtnTX412.Name = "BtnTX412"
        Me.BtnTX412.Size = New System.Drawing.Size(248, 24)
        Me.BtnTX412.TabIndex = 29
        Me.BtnTX412.Text = "DMV Name && Address Update"
        '
        'btntxa12
        '
        Me.btntxa12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntxa12.Location = New System.Drawing.Point(29, 187)
        Me.btntxa12.Name = "btntxa12"
        Me.btntxa12.Size = New System.Drawing.Size(248, 24)
        Me.btntxa12.TabIndex = 28
        Me.btntxa12.Text = "Transfer Credit Balances"
        '
        'btntx406
        '
        Me.btntx406.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx406.ForeColor = System.Drawing.Color.Black
        Me.btntx406.Location = New System.Drawing.Point(29, 157)
        Me.btntx406.Name = "btntx406"
        Me.btntx406.Size = New System.Drawing.Size(248, 24)
        Me.btntx406.TabIndex = 27
        Me.btntx406.Text = "Select / Purge Accounts By Year"
        '
        'btntx407
        '
        Me.btntx407.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx407.ForeColor = System.Drawing.Color.Black
        Me.btntx407.Location = New System.Drawing.Point(29, 69)
        Me.btntx407.Name = "btntx407"
        Me.btntx407.Size = New System.Drawing.Size(248, 24)
        Me.btntx407.TabIndex = 26
        Me.btntx407.Text = "Put Ons / Take Offs"
        '
        'label9
        '
        Me.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label9.ForeColor = System.Drawing.Color.Maroon
        Me.label9.Image = CType(resources.GetObject("label9.Image"), System.Drawing.Image)
        Me.label9.Location = New System.Drawing.Point(0, 0)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(528, 32)
        Me.label9.TabIndex = 6
        '
        'tabBills
        '
        Me.tabBills.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabBills.Controls.Add(Me.BtnTX340)
        Me.tabBills.Controls.Add(Me.BtnTXE42)
        Me.tabBills.Controls.Add(Me.btntx302)
        Me.tabBills.Controls.Add(Me.btntx314)
        Me.tabBills.Controls.Add(Me.btntx313)
        Me.tabBills.Controls.Add(Me.btntx312)
        Me.tabBills.Controls.Add(Me.btntx311)
        Me.tabBills.Controls.Add(Me.btntx310)
        Me.tabBills.Controls.Add(Me.btntx304)
        Me.tabBills.Controls.Add(Me.btntx303)
        Me.tabBills.Controls.Add(Me.btntx301)
        Me.tabBills.Controls.Add(Me.label6)
        Me.tabBills.Location = New System.Drawing.Point(4, 53)
        Me.tabBills.Name = "tabBills"
        Me.tabBills.Size = New System.Drawing.Size(574, 380)
        Me.tabBills.TabIndex = 5
        Me.tabBills.Text = "Bills & Notices"
        Me.tabBills.UseVisualStyleBackColor = True
        Me.tabBills.Visible = False
        '
        'BtnTX340
        '
        Me.BtnTX340.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTX340.Location = New System.Drawing.Point(288, 140)
        Me.BtnTX340.Name = "BtnTX340"
        Me.BtnTX340.Size = New System.Drawing.Size(248, 24)
        Me.BtnTX340.TabIndex = 38
        Me.BtnTX340.Text = "Manual RE or PP Bill"
        '
        'BtnTXE42
        '
        Me.BtnTXE42.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTXE42.Location = New System.Drawing.Point(28, 172)
        Me.BtnTXE42.Name = "BtnTXE42"
        Me.BtnTXE42.Size = New System.Drawing.Size(248, 24)
        Me.BtnTXE42.TabIndex = 37
        Me.BtnTXE42.Text = "Print Lien Releases"
        '
        'btntx302
        '
        Me.btntx302.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx302.Location = New System.Drawing.Point(28, 78)
        Me.btntx302.Name = "btntx302"
        Me.btntx302.Size = New System.Drawing.Size(248, 24)
        Me.btntx302.TabIndex = 36
        Me.btntx302.Text = "Print Delinquent Notices/List"
        '
        'btntx314
        '
        Me.btntx314.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx314.Location = New System.Drawing.Point(288, 110)
        Me.btntx314.Name = "btntx314"
        Me.btntx314.Size = New System.Drawing.Size(248, 24)
        Me.btntx314.TabIndex = 35
        Me.btntx314.Text = "Capture Payments for a Status Code"
        '
        'btntx313
        '
        Me.btntx313.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx313.Location = New System.Drawing.Point(288, 78)
        Me.btntx313.Name = "btntx313"
        Me.btntx313.Size = New System.Drawing.Size(248, 24)
        Me.btntx313.TabIndex = 34
        Me.btntx313.Text = "Multiple Status Code Update"
        '
        'btntx312
        '
        Me.btntx312.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx312.Location = New System.Drawing.Point(288, 46)
        Me.btntx312.Name = "btntx312"
        Me.btntx312.Size = New System.Drawing.Size(248, 24)
        Me.btntx312.TabIndex = 33
        Me.btntx312.Text = "Mass Clear Status Code from Collector"
        '
        'btntx311
        '
        Me.btntx311.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx311.Location = New System.Drawing.Point(28, 234)
        Me.btntx311.Name = "btntx311"
        Me.btntx311.Size = New System.Drawing.Size(248, 24)
        Me.btntx311.TabIndex = 32
        Me.btntx311.Text = "Maintain Prorates"
        '
        'btntx310
        '
        Me.btntx310.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx310.Location = New System.Drawing.Point(28, 204)
        Me.btntx310.Name = "btntx310"
        Me.btntx310.Size = New System.Drawing.Size(248, 24)
        Me.btntx310.TabIndex = 31
        Me.btntx310.Text = "Get Prorates For Billing"
        '
        'btntx304
        '
        Me.btntx304.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx304.Location = New System.Drawing.Point(28, 142)
        Me.btntx304.Name = "btntx304"
        Me.btntx304.Size = New System.Drawing.Size(248, 24)
        Me.btntx304.TabIndex = 29
        Me.btntx304.Text = "Print Lien Notices"
        '
        'btntx303
        '
        Me.btntx303.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx303.Location = New System.Drawing.Point(28, 110)
        Me.btntx303.Name = "btntx303"
        Me.btntx303.Size = New System.Drawing.Size(248, 24)
        Me.btntx303.TabIndex = 27
        Me.btntx303.Text = "Print Delinquent Bills/ List"
        '
        'btntx301
        '
        Me.btntx301.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx301.Location = New System.Drawing.Point(28, 46)
        Me.btntx301.Name = "btntx301"
        Me.btntx301.Size = New System.Drawing.Size(248, 24)
        Me.btntx301.TabIndex = 26
        Me.btntx301.Text = "Print Bills/Posted"
        '
        'label6
        '
        Me.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label6.ForeColor = System.Drawing.Color.Maroon
        Me.label6.Image = CType(resources.GetObject("label6.Image"), System.Drawing.Image)
        Me.label6.Location = New System.Drawing.Point(0, 0)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(536, 32)
        Me.label6.TabIndex = 6
        '
        'tabprebilling
        '
        Me.tabprebilling.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabprebilling.Controls.Add(Me.BtnTX430)
        Me.tabprebilling.Controls.Add(Me.btntx501)
        Me.tabprebilling.Controls.Add(Me.BtnTXE45)
        Me.tabprebilling.Controls.Add(Me.btntxe15)
        Me.tabprebilling.Controls.Add(Me.btntx411)
        Me.tabprebilling.Controls.Add(Me.btntx410)
        Me.tabprebilling.Controls.Add(Me.btntx402)
        Me.tabprebilling.Controls.Add(Me.btntx401)
        Me.tabprebilling.Controls.Add(Me.label2)
        Me.tabprebilling.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabprebilling.Location = New System.Drawing.Point(4, 53)
        Me.tabprebilling.Name = "tabprebilling"
        Me.tabprebilling.Size = New System.Drawing.Size(574, 380)
        Me.tabprebilling.TabIndex = 1
        Me.tabprebilling.Text = "Pre Billing"
        Me.tabprebilling.UseVisualStyleBackColor = True
        Me.tabprebilling.Visible = False
        '
        'BtnTX430
        '
        Me.BtnTX430.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTX430.Location = New System.Drawing.Point(142, 321)
        Me.BtnTX430.Name = "BtnTX430"
        Me.BtnTX430.Size = New System.Drawing.Size(248, 24)
        Me.BtnTX430.TabIndex = 57
        Me.BtnTX430.Text = "Update Leasing Codes"
        '
        'btntx501
        '
        Me.btntx501.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx501.Location = New System.Drawing.Point(142, 231)
        Me.btntx501.Name = "btntx501"
        Me.btntx501.Size = New System.Drawing.Size(248, 24)
        Me.btntx501.TabIndex = 56
        Me.btntx501.Text = "Back Tax List"
        '
        'BtnTXE45
        '
        Me.BtnTXE45.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTXE45.Location = New System.Drawing.Point(142, 291)
        Me.BtnTXE45.Name = "BtnTXE45"
        Me.BtnTXE45.Size = New System.Drawing.Size(248, 24)
        Me.BtnTXE45.TabIndex = 54
        Me.BtnTXE45.Text = "Load Bank Codes from Invoice File"
        '
        'btntxe15
        '
        Me.btntxe15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntxe15.Location = New System.Drawing.Point(142, 261)
        Me.btntxe15.Name = "btntxe15"
        Me.btntxe15.Size = New System.Drawing.Size(248, 24)
        Me.btntxe15.TabIndex = 53
        Me.btntxe15.Text = "Update Back Tax - Billing Files"
        '
        'btntx411
        '
        Me.btntx411.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx411.ForeColor = System.Drawing.Color.Black
        Me.btntx411.Location = New System.Drawing.Point(142, 200)
        Me.btntx411.Name = "btntx411"
        Me.btntx411.Size = New System.Drawing.Size(248, 24)
        Me.btntx411.TabIndex = 11
        Me.btntx411.Text = "Name and Address Update"
        '
        'btntx410
        '
        Me.btntx410.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx410.ForeColor = System.Drawing.Color.Black
        Me.btntx410.Location = New System.Drawing.Point(142, 170)
        Me.btntx410.Name = "btntx410"
        Me.btntx410.Size = New System.Drawing.Size(248, 24)
        Me.btntx410.TabIndex = 10
        Me.btntx410.Text = "Remove or Change Bank Codes"
        '
        'btntx402
        '
        Me.btntx402.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx402.ForeColor = System.Drawing.Color.Black
        Me.btntx402.Location = New System.Drawing.Point(142, 140)
        Me.btntx402.Name = "btntx402"
        Me.btntx402.Size = New System.Drawing.Size(248, 24)
        Me.btntx402.TabIndex = 9
        Me.btntx402.Text = "Multiple Back Tax Update"
        '
        'btntx401
        '
        Me.btntx401.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx401.ForeColor = System.Drawing.Color.Black
        Me.btntx401.Location = New System.Drawing.Point(142, 110)
        Me.btntx401.Name = "btntx401"
        Me.btntx401.Size = New System.Drawing.Size(248, 24)
        Me.btntx401.TabIndex = 8
        Me.btntx401.Text = "Billing Master Files"
        '
        'label2
        '
        Me.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.Color.Maroon
        Me.label2.Image = CType(resources.GetObject("label2.Image"), System.Drawing.Image)
        Me.label2.Location = New System.Drawing.Point(0, 0)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(536, 32)
        Me.label2.TabIndex = 6
        '
        'tabtables
        '
        Me.tabtables.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabtables.Controls.Add(Me.BtnTX118)
        Me.tabtables.Controls.Add(Me.BtnTX117)
        Me.tabtables.Controls.Add(Me.BtnTX116)
        Me.tabtables.Controls.Add(Me.BtnTX115)
        Me.tabtables.Controls.Add(Me.BtnTX114)
        Me.tabtables.Controls.Add(Me.BtnTX113)
        Me.tabtables.Controls.Add(Me.BtnTX112)
        Me.tabtables.Controls.Add(Me.btntx111)
        Me.tabtables.Controls.Add(Me.btntx110)
        Me.tabtables.Controls.Add(Me.btntx109)
        Me.tabtables.Controls.Add(Me.btntx108)
        Me.tabtables.Controls.Add(Me.btntx107)
        Me.tabtables.Controls.Add(Me.btntx106)
        Me.tabtables.Controls.Add(Me.btntx105)
        Me.tabtables.Controls.Add(Me.btntx104)
        Me.tabtables.Controls.Add(Me.btntx103)
        Me.tabtables.Controls.Add(Me.btntx102)
        Me.tabtables.Controls.Add(Me.btntx101)
        Me.tabtables.Controls.Add(Me.label3)
        Me.tabtables.Location = New System.Drawing.Point(4, 53)
        Me.tabtables.Name = "tabtables"
        Me.tabtables.Size = New System.Drawing.Size(574, 380)
        Me.tabtables.TabIndex = 2
        Me.tabtables.Text = "Tables"
        Me.tabtables.UseVisualStyleBackColor = True
        Me.tabtables.Visible = False
        '
        'BtnTX118
        '
        Me.BtnTX118.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTX118.Location = New System.Drawing.Point(282, 297)
        Me.BtnTX118.Name = "BtnTX118"
        Me.BtnTX118.Size = New System.Drawing.Size(248, 24)
        Me.BtnTX118.TabIndex = 17
        Me.BtnTX118.Text = "Webtax Product ID"
        '
        'BtnTX117
        '
        Me.BtnTX117.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTX117.Location = New System.Drawing.Point(282, 237)
        Me.BtnTX117.Name = "BtnTX117"
        Me.BtnTX117.Size = New System.Drawing.Size(248, 24)
        Me.BtnTX117.TabIndex = 16
        Me.BtnTX117.Text = "Leasing Companies"
        '
        'BtnTX116
        '
        Me.BtnTX116.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTX116.Location = New System.Drawing.Point(282, 267)
        Me.BtnTX116.Name = "BtnTX116"
        Me.BtnTX116.Size = New System.Drawing.Size(248, 24)
        Me.BtnTX116.TabIndex = 15
        Me.BtnTX116.Text = "Credit Card Provider (Cash Register)"
        '
        'BtnTX115
        '
        Me.BtnTX115.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTX115.Location = New System.Drawing.Point(15, 267)
        Me.BtnTX115.Name = "BtnTX115"
        Me.BtnTX115.Size = New System.Drawing.Size(248, 24)
        Me.BtnTX115.TabIndex = 7
        Me.BtnTX115.Text = "Tax Types"
        '
        'BtnTX114
        '
        Me.BtnTX114.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTX114.Location = New System.Drawing.Point(15, 237)
        Me.BtnTX114.Name = "BtnTX114"
        Me.BtnTX114.Size = New System.Drawing.Size(248, 24)
        Me.BtnTX114.TabIndex = 6
        Me.BtnTX114.Text = "MV Fee"
        '
        'BtnTX113
        '
        Me.BtnTX113.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTX113.Location = New System.Drawing.Point(282, 207)
        Me.BtnTX113.Name = "BtnTX113"
        Me.BtnTX113.Size = New System.Drawing.Size(248, 24)
        Me.BtnTX113.TabIndex = 14
        Me.BtnTX113.Text = "Tax Form - Statement && Lien  Info"
        '
        'BtnTX112
        '
        Me.BtnTX112.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTX112.Location = New System.Drawing.Point(282, 177)
        Me.BtnTX112.Name = "BtnTX112"
        Me.BtnTX112.Size = New System.Drawing.Size(248, 24)
        Me.BtnTX112.TabIndex = 13
        Me.BtnTX112.Text = "Tax Form - Bill Info"
        '
        'btntx111
        '
        Me.btntx111.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx111.Location = New System.Drawing.Point(282, 143)
        Me.btntx111.Name = "btntx111"
        Me.btntx111.Size = New System.Drawing.Size(248, 24)
        Me.btntx111.TabIndex = 12
        Me.btntx111.Text = "Owner Identification"
        '
        'btntx110
        '
        Me.btntx110.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx110.Location = New System.Drawing.Point(282, 111)
        Me.btntx110.Name = "btntx110"
        Me.btntx110.Size = New System.Drawing.Size(248, 24)
        Me.btntx110.TabIndex = 11
        Me.btntx110.Text = "Zip Codes"
        '
        'btntx109
        '
        Me.btntx109.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx109.Location = New System.Drawing.Point(15, 297)
        Me.btntx109.Name = "btntx109"
        Me.btntx109.Size = New System.Drawing.Size(248, 24)
        Me.btntx109.TabIndex = 8
        Me.btntx109.Text = "District Codes"
        '
        'btntx108
        '
        Me.btntx108.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx108.Location = New System.Drawing.Point(282, 47)
        Me.btntx108.Name = "btntx108"
        Me.btntx108.Size = New System.Drawing.Size(248, 24)
        Me.btntx108.TabIndex = 9
        Me.btntx108.Text = "Bank Services"
        '
        'btntx107
        '
        Me.btntx107.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx107.Location = New System.Drawing.Point(282, 79)
        Me.btntx107.Name = "btntx107"
        Me.btntx107.Size = New System.Drawing.Size(248, 24)
        Me.btntx107.TabIndex = 10
        Me.btntx107.Text = "Bank Codes"
        '
        'btntx106
        '
        Me.btntx106.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx106.Location = New System.Drawing.Point(15, 207)
        Me.btntx106.Name = "btntx106"
        Me.btntx106.Size = New System.Drawing.Size(248, 24)
        Me.btntx106.TabIndex = 5
        Me.btntx106.Text = "Suspense Reason Codes"
        '
        'btntx105
        '
        Me.btntx105.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx105.Location = New System.Drawing.Point(15, 175)
        Me.btntx105.Name = "btntx105"
        Me.btntx105.Size = New System.Drawing.Size(248, 24)
        Me.btntx105.TabIndex = 4
        Me.btntx105.Text = "Fee Codes"
        '
        'btntx104
        '
        Me.btntx104.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx104.Location = New System.Drawing.Point(15, 143)
        Me.btntx104.Name = "btntx104"
        Me.btntx104.Size = New System.Drawing.Size(248, 24)
        Me.btntx104.TabIndex = 3
        Me.btntx104.Text = "Status Codes"
        '
        'btntx103
        '
        Me.btntx103.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx103.Location = New System.Drawing.Point(15, 111)
        Me.btntx103.Name = "btntx103"
        Me.btntx103.Size = New System.Drawing.Size(248, 24)
        Me.btntx103.TabIndex = 2
        Me.btntx103.Text = "Endorsement Info"
        '
        'btntx102
        '
        Me.btntx102.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx102.Location = New System.Drawing.Point(15, 79)
        Me.btntx102.Name = "btntx102"
        Me.btntx102.Size = New System.Drawing.Size(248, 24)
        Me.btntx102.TabIndex = 1
        Me.btntx102.Text = "Mill Rate"
        '
        'btntx101
        '
        Me.btntx101.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx101.Location = New System.Drawing.Point(15, 47)
        Me.btntx101.Name = "btntx101"
        Me.btntx101.Size = New System.Drawing.Size(248, 24)
        Me.btntx101.TabIndex = 0
        Me.btntx101.Text = "Bill Type (Tax Profile) info"
        '
        'label3
        '
        Me.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.Color.Maroon
        Me.label3.Image = CType(resources.GetObject("label3.Image"), System.Drawing.Image)
        Me.label3.Location = New System.Drawing.Point(-56, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(648, 32)
        Me.label3.TabIndex = 6
        '
        'tabreports
        '
        Me.tabreports.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabreports.Controls.Add(Me.label5)
        Me.tabreports.Controls.Add(Me.tabControl2)
        Me.tabreports.Location = New System.Drawing.Point(4, 53)
        Me.tabreports.Name = "tabreports"
        Me.tabreports.Size = New System.Drawing.Size(574, 380)
        Me.tabreports.TabIndex = 4
        Me.tabreports.Text = "Reports"
        Me.tabreports.UseVisualStyleBackColor = True
        Me.tabreports.Visible = False
        '
        'label5
        '
        Me.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.ForeColor = System.Drawing.Color.Maroon
        Me.label5.Image = CType(resources.GetObject("label5.Image"), System.Drawing.Image)
        Me.label5.Location = New System.Drawing.Point(0, 0)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(536, 32)
        Me.label5.TabIndex = 6
        '
        'tabControl2
        '
        Me.tabControl2.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.tabControl2.Controls.Add(Me.tabPage5)
        Me.tabControl2.Controls.Add(Me.tabPage9)
        Me.tabControl2.Controls.Add(Me.tabPage10)
        Me.tabControl2.Controls.Add(Me.tabPage12)
        Me.tabControl2.Location = New System.Drawing.Point(8, 40)
        Me.tabControl2.Name = "tabControl2"
        Me.tabControl2.SelectedIndex = 0
        Me.tabControl2.Size = New System.Drawing.Size(559, 335)
        Me.tabControl2.TabIndex = 0
        '
        'tabPage5
        '
        Me.tabPage5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabPage5.Controls.Add(Me.BtnTXE52)
        Me.tabPage5.Controls.Add(Me.BtnTXE47)
        Me.tabPage5.Controls.Add(Me.BtnTXE43)
        Me.tabPage5.Controls.Add(Me.btntxe21)
        Me.tabPage5.Controls.Add(Me.btntxe12)
        Me.tabPage5.Controls.Add(Me.btntx506)
        Me.tabPage5.Controls.Add(Me.btntx505)
        Me.tabPage5.Controls.Add(Me.label11)
        Me.tabPage5.Controls.Add(Me.btntxe25)
        Me.tabPage5.Controls.Add(Me.btntxe24)
        Me.tabPage5.Controls.Add(Me.btntxe10)
        Me.tabPage5.Controls.Add(Me.btntxe09)
        Me.tabPage5.Controls.Add(Me.btntxe06)
        Me.tabPage5.Controls.Add(Me.btntxe14)
        Me.tabPage5.Controls.Add(Me.btntxe11)
        Me.tabPage5.Location = New System.Drawing.Point(4, 27)
        Me.tabPage5.Name = "tabPage5"
        Me.tabPage5.Size = New System.Drawing.Size(551, 304)
        Me.tabPage5.TabIndex = 0
        Me.tabPage5.Text = "Listings"
        '
        'BtnTXE52
        '
        Me.BtnTXE52.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTXE52.Location = New System.Drawing.Point(20, 206)
        Me.BtnTXE52.Name = "BtnTXE52"
        Me.BtnTXE52.Size = New System.Drawing.Size(228, 24)
        Me.BtnTXE52.TabIndex = 64
        Me.BtnTXE52.Text = "Top Taxpayers"
        '
        'BtnTXE47
        '
        Me.BtnTXE47.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTXE47.Location = New System.Drawing.Point(20, 60)
        Me.BtnTXE47.Name = "BtnTXE47"
        Me.BtnTXE47.Size = New System.Drawing.Size(228, 24)
        Me.BtnTXE47.TabIndex = 63
        Me.BtnTXE47.Text = "Billed Prorates List"
        '
        'BtnTXE43
        '
        Me.BtnTXE43.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTXE43.Location = New System.Drawing.Point(20, 90)
        Me.BtnTXE43.Name = "BtnTXE43"
        Me.BtnTXE43.Size = New System.Drawing.Size(228, 24)
        Me.BtnTXE43.TabIndex = 62
        Me.BtnTXE43.Text = "Billed Taxes Status"
        '
        'btntxe21
        '
        Me.btntxe21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntxe21.Location = New System.Drawing.Point(264, 176)
        Me.btntxe21.Name = "btntxe21"
        Me.btntxe21.Size = New System.Drawing.Size(228, 24)
        Me.btntxe21.TabIndex = 61
        Me.btntxe21.Text = "Bank Billing Report"
        '
        'btntxe12
        '
        Me.btntxe12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntxe12.Location = New System.Drawing.Point(264, 148)
        Me.btntxe12.Name = "btntxe12"
        Me.btntxe12.Size = New System.Drawing.Size(228, 24)
        Me.btntxe12.TabIndex = 60
        Me.btntxe12.Text = "Second Payment Reminder"
        '
        'btntx506
        '
        Me.btntx506.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx506.Location = New System.Drawing.Point(264, 90)
        Me.btntx506.Name = "btntx506"
        Me.btntx506.Size = New System.Drawing.Size(228, 24)
        Me.btntx506.TabIndex = 59
        Me.btntx506.Text = "Motor Vehicle/Supple Date of Birth"
        '
        'btntx505
        '
        Me.btntx505.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx505.Location = New System.Drawing.Point(264, 60)
        Me.btntx505.Name = "btntx505"
        Me.btntx505.Size = New System.Drawing.Size(228, 24)
        Me.btntx505.TabIndex = 58
        Me.btntx505.Text = "Real Estate List By Bank Code"
        '
        'label11
        '
        Me.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.label11.ForeColor = System.Drawing.Color.Maroon
        Me.label11.Image = CType(resources.GetObject("label11.Image"), System.Drawing.Image)
        Me.label11.Location = New System.Drawing.Point(-8, 0)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(544, 24)
        Me.label11.TabIndex = 54
        '
        'btntxe25
        '
        Me.btntxe25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntxe25.Location = New System.Drawing.Point(264, 32)
        Me.btntxe25.Name = "btntxe25"
        Me.btntxe25.Size = New System.Drawing.Size(228, 24)
        Me.btntxe25.TabIndex = 53
        Me.btntxe25.Text = "Address Changes"
        '
        'btntxe24
        '
        Me.btntxe24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntxe24.Location = New System.Drawing.Point(20, 176)
        Me.btntxe24.Name = "btntxe24"
        Me.btntxe24.Size = New System.Drawing.Size(228, 24)
        Me.btntxe24.TabIndex = 52
        Me.btntxe24.Text = "Accounts for Status Codes"
        '
        'btntxe10
        '
        Me.btntxe10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntxe10.Location = New System.Drawing.Point(264, 204)
        Me.btntxe10.Name = "btntxe10"
        Me.btntxe10.Size = New System.Drawing.Size(228, 24)
        Me.btntxe10.TabIndex = 47
        Me.btntxe10.Text = "Name/Address Status"
        '
        'btntxe09
        '
        Me.btntxe09.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntxe09.Location = New System.Drawing.Point(264, 120)
        Me.btntxe09.Name = "btntxe09"
        Me.btntxe09.Size = New System.Drawing.Size(228, 24)
        Me.btntxe09.TabIndex = 46
        Me.btntxe09.Text = "BT/Foreclosure/Inactive/Suspense"
        '
        'btntxe06
        '
        Me.btntxe06.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntxe06.Location = New System.Drawing.Point(20, 32)
        Me.btntxe06.Name = "btntxe06"
        Me.btntxe06.Size = New System.Drawing.Size(228, 24)
        Me.btntxe06.TabIndex = 43
        Me.btntxe06.Text = "Billed Taxes List"
        '
        'btntxe14
        '
        Me.btntxe14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntxe14.Location = New System.Drawing.Point(20, 120)
        Me.btntxe14.Name = "btntxe14"
        Me.btntxe14.Size = New System.Drawing.Size(228, 24)
        Me.btntxe14.TabIndex = 41
        Me.btntxe14.Text = "Top Delinquent Taxpayers"
        '
        'btntxe11
        '
        Me.btntxe11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntxe11.Location = New System.Drawing.Point(20, 148)
        Me.btntxe11.Name = "btntxe11"
        Me.btntxe11.Size = New System.Drawing.Size(228, 24)
        Me.btntxe11.TabIndex = 38
        Me.btntxe11.Text = "Liened Accounts "
        '
        'tabPage9
        '
        Me.tabPage9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabPage9.Controls.Add(Me.BtnTO206)
        Me.tabPage9.Controls.Add(Me.BtnTO200)
        Me.tabPage9.Controls.Add(Me.btnto116)
        Me.tabPage9.Controls.Add(Me.BtnTO120)
        Me.tabPage9.Controls.Add(Me.label13)
        Me.tabPage9.Controls.Add(Me.btnto107)
        Me.tabPage9.Controls.Add(Me.btnto114)
        Me.tabPage9.Controls.Add(Me.btnto113)
        Me.tabPage9.Controls.Add(Me.btnto112)
        Me.tabPage9.Controls.Add(Me.btnto111)
        Me.tabPage9.Controls.Add(Me.btnto110)
        Me.tabPage9.Controls.Add(Me.btnto105)
        Me.tabPage9.Controls.Add(Me.btnto104)
        Me.tabPage9.Controls.Add(Me.btnto103)
        Me.tabPage9.Controls.Add(Me.btnto109)
        Me.tabPage9.Controls.Add(Me.btnto106)
        Me.tabPage9.Controls.Add(Me.btnto102)
        Me.tabPage9.Controls.Add(Me.btnto101)
        Me.tabPage9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabPage9.Location = New System.Drawing.Point(4, 25)
        Me.tabPage9.Name = "tabPage9"
        Me.tabPage9.Size = New System.Drawing.Size(551, 306)
        Me.tabPage9.TabIndex = 2
        Me.tabPage9.Text = "O.P.M."
        Me.tabPage9.Visible = False
        '
        'BtnTO206
        '
        Me.BtnTO206.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTO206.Location = New System.Drawing.Point(289, 23)
        Me.BtnTO206.Name = "BtnTO206"
        Me.BtnTO206.Size = New System.Drawing.Size(257, 24)
        Me.BtnTO206.TabIndex = 87
        Me.BtnTO206.Text = "M1 Municipal Collectors Certificate"
        Me.BtnTO206.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnTO200
        '
        Me.BtnTO200.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTO200.Location = New System.Drawing.Point(9, 23)
        Me.BtnTO200.Name = "BtnTO200"
        Me.BtnTO200.Size = New System.Drawing.Size(265, 24)
        Me.BtnTO200.TabIndex = 86
        Me.BtnTO200.Text = "Maintain OPM Contact Info"
        Me.BtnTO200.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnto116
        '
        Me.btnto116.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnto116.Location = New System.Drawing.Point(289, 244)
        Me.btnto116.Name = "btnto116"
        Me.btnto116.Size = New System.Drawing.Size(255, 23)
        Me.btnto116.TabIndex = 85
        Me.btnto116.Text = "15a/15b/R-Exempt/ for Mfg. && Biotech "
        Me.btnto116.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnTO120
        '
        Me.BtnTO120.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTO120.Location = New System.Drawing.Point(9, 276)
        Me.BtnTO120.Name = "BtnTO120"
        Me.BtnTO120.Size = New System.Drawing.Size(265, 23)
        Me.BtnTO120.TabIndex = 84
        Me.BtnTO120.Text = "DVA Veterans Exemptions File"
        Me.BtnTO120.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'label13
        '
        Me.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.label13.ForeColor = System.Drawing.Color.Maroon
        Me.label13.Image = CType(resources.GetObject("label13.Image"), System.Drawing.Image)
        Me.label13.Location = New System.Drawing.Point(0, 0)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(528, 20)
        Me.label13.TabIndex = 68
        '
        'btnto107
        '
        Me.btnto107.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnto107.Location = New System.Drawing.Point(9, 247)
        Me.btnto107.Name = "btnto107"
        Me.btnto107.Size = New System.Drawing.Size(265, 23)
        Me.btnto107.TabIndex = 67
        Me.btnto107.Text = "M-37  State Owned Property and M37 C & H"
        Me.btnto107.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnto107.UseMnemonic = False
        '
        'btnto114
        '
        Me.btnto114.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnto114.Location = New System.Drawing.Point(289, 215)
        Me.btnto114.Name = "btnto114"
        Me.btnto114.Size = New System.Drawing.Size(255, 23)
        Me.btnto114.TabIndex = 66
        Me.btnto114.Text = "M65a-MV MV/Supp Exempt Vehicles (NBB)"
        Me.btnto114.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnto113
        '
        Me.btnto113.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnto113.Location = New System.Drawing.Point(289, 183)
        Me.btnto113.Name = "btnto113"
        Me.btnto113.Size = New System.Drawing.Size(255, 23)
        Me.btnto113.TabIndex = 65
        Me.btnto113.Text = "BAA Listing"
        Me.btnto113.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnto112
        '
        Me.btnto112.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnto112.Location = New System.Drawing.Point(289, 151)
        Me.btnto112.Name = "btnto112"
        Me.btnto112.Size = New System.Drawing.Size(255, 23)
        Me.btnto112.TabIndex = 64
        Me.btnto112.Text = "Tax Credit for Per Prop Code (Computer)"
        Me.btnto112.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnto111
        '
        Me.btnto111.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnto111.Location = New System.Drawing.Point(289, 119)
        Me.btnto111.Name = "btnto111"
        Me.btnto111.Size = New System.Drawing.Size(255, 23)
        Me.btnto111.TabIndex = 63
        Me.btnto111.Text = "M-65a  Revenue Loss due to New Machinery "
        Me.btnto111.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnto110
        '
        Me.btnto110.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnto110.Location = New System.Drawing.Point(289, 85)
        Me.btnto110.Name = "btnto110"
        Me.btnto110.Size = New System.Drawing.Size(255, 23)
        Me.btnto110.TabIndex = 62
        Me.btnto110.Text = "M-59a  Rev Loss due to Addl. Vet Exemptions"
        Me.btnto110.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnto105
        '
        Me.btnto105.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnto105.Location = New System.Drawing.Point(9, 183)
        Me.btnto105.Name = "btnto105"
        Me.btnto105.Size = New System.Drawing.Size(265, 23)
        Me.btnto105.TabIndex = 61
        Me.btnto105.Text = "M-36  Revenue Loss State Program Elderly Freeze"
        Me.btnto105.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnto104
        '
        Me.btnto104.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnto104.Location = New System.Drawing.Point(9, 151)
        Me.btnto104.Name = "btnto104"
        Me.btnto104.Size = New System.Drawing.Size(265, 23)
        Me.btnto104.TabIndex = 60
        Me.btnto104.Text = "M-35p Reduction to Owners Reimb"
        Me.btnto104.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnto103
        '
        Me.btnto103.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnto103.Location = New System.Drawing.Point(9, 117)
        Me.btnto103.Name = "btnto103"
        Me.btnto103.Size = New System.Drawing.Size(265, 23)
        Me.btnto103.TabIndex = 59
        Me.btnto103.Text = "M-35b   Revenue Loss Owners Program for Elderly"
        Me.btnto103.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnto109
        '
        Me.btnto109.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnto109.Location = New System.Drawing.Point(289, 53)
        Me.btnto109.Name = "btnto109"
        Me.btnto109.Size = New System.Drawing.Size(255, 23)
        Me.btnto109.TabIndex = 58
        Me.btnto109.Text = "M-42b  Totally Disabled Program"
        Me.btnto109.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnto106
        '
        Me.btnto106.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnto106.Location = New System.Drawing.Point(9, 215)
        Me.btnto106.Name = "btnto106"
        Me.btnto106.Size = New System.Drawing.Size(265, 23)
        Me.btnto106.TabIndex = 56
        Me.btnto106.Text = "M-36p  Reduction to Freeze Reimbursement"
        Me.btnto106.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnto102
        '
        Me.btnto102.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnto102.Location = New System.Drawing.Point(9, 85)
        Me.btnto102.Name = "btnto102"
        Me.btnto102.Size = New System.Drawing.Size(265, 23)
        Me.btnto102.TabIndex = 55
        Me.btnto102.Text = "M-13a  Grand List of Tax Exempt Property"
        Me.btnto102.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnto101
        '
        Me.btnto101.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnto101.Location = New System.Drawing.Point(9, 53)
        Me.btnto101.Name = "btnto101"
        Me.btnto101.Size = New System.Drawing.Size(265, 23)
        Me.btnto101.TabIndex = 54
        Me.btnto101.Text = "M-13  Grand List of Taxable Property"
        Me.btnto101.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabPage10
        '
        Me.tabPage10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabPage10.Controls.Add(Me.BtnTX203)
        Me.tabPage10.Controls.Add(Me.label14)
        Me.tabPage10.Controls.Add(Me.btntx211)
        Me.tabPage10.Controls.Add(Me.btntx210)
        Me.tabPage10.Controls.Add(Me.btntx201)
        Me.tabPage10.Location = New System.Drawing.Point(4, 25)
        Me.tabPage10.Name = "tabPage10"
        Me.tabPage10.Size = New System.Drawing.Size(551, 306)
        Me.tabPage10.TabIndex = 3
        Me.tabPage10.Text = "Rate Books"
        Me.tabPage10.Visible = False
        '
        'BtnTX203
        '
        Me.BtnTX203.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTX203.Location = New System.Drawing.Point(131, 73)
        Me.BtnTX203.Name = "BtnTX203"
        Me.BtnTX203.Size = New System.Drawing.Size(248, 24)
        Me.BtnTX203.TabIndex = 56
        Me.BtnTX203.Text = "Print Front Page (Rate Book) "
        '
        'label14
        '
        Me.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.label14.ForeColor = System.Drawing.Color.Maroon
        Me.label14.Image = CType(resources.GetObject("label14.Image"), System.Drawing.Image)
        Me.label14.Location = New System.Drawing.Point(0, 0)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(528, 20)
        Me.label14.TabIndex = 55
        '
        'btntx211
        '
        Me.btntx211.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx211.Location = New System.Drawing.Point(131, 134)
        Me.btntx211.Name = "btntx211"
        Me.btntx211.Size = New System.Drawing.Size(248, 23)
        Me.btntx211.TabIndex = 37
        Me.btntx211.Text = "C of C Posted Rate Books"
        '
        'btntx210
        '
        Me.btntx210.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx210.Location = New System.Drawing.Point(131, 102)
        Me.btntx210.Name = "btntx210"
        Me.btntx210.Size = New System.Drawing.Size(248, 23)
        Me.btntx210.TabIndex = 36
        Me.btntx210.Text = "Posted Rate Books"
        '
        'btntx201
        '
        Me.btntx201.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx201.Location = New System.Drawing.Point(131, 44)
        Me.btntx201.Name = "btntx201"
        Me.btntx201.Size = New System.Drawing.Size(248, 23)
        Me.btntx201.TabIndex = 33
        Me.btntx201.Text = "Print Rate Books"
        '
        'tabPage12
        '
        Me.tabPage12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabPage12.Controls.Add(Me.BtnTXE56)
        Me.tabPage12.Controls.Add(Me.BtnTXE51)
        Me.tabPage12.Controls.Add(Me.BtnTXE40)
        Me.tabPage12.Controls.Add(Me.btntxe03)
        Me.tabPage12.Controls.Add(Me.Btntxe26)
        Me.tabPage12.Controls.Add(Me.btntxe04)
        Me.tabPage12.Controls.Add(Me.btntxe20)
        Me.tabPage12.Controls.Add(Me.btntxe18)
        Me.tabPage12.Controls.Add(Me.btntxe17)
        Me.tabPage12.Controls.Add(Me.btntxe16)
        Me.tabPage12.Controls.Add(Me.btntxe13)
        Me.tabPage12.Controls.Add(Me.label15)
        Me.tabPage12.Controls.Add(Me.btntxe08)
        Me.tabPage12.Controls.Add(Me.btntxe05)
        Me.tabPage12.Controls.Add(Me.btntxe02)
        Me.tabPage12.Location = New System.Drawing.Point(4, 25)
        Me.tabPage12.Name = "tabPage12"
        Me.tabPage12.Size = New System.Drawing.Size(551, 306)
        Me.tabPage12.TabIndex = 4
        Me.tabPage12.Text = "Balancing"
        Me.tabPage12.Visible = False
        '
        'BtnTXE56
        '
        Me.BtnTXE56.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTXE56.Location = New System.Drawing.Point(256, 234)
        Me.BtnTXE56.Name = "BtnTXE56"
        Me.BtnTXE56.Size = New System.Drawing.Size(232, 23)
        Me.BtnTXE56.TabIndex = 66
        Me.BtnTXE56.Text = "Treasurer Report (All Types)"
        '
        'BtnTXE51
        '
        Me.BtnTXE51.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTXE51.Location = New System.Drawing.Point(8, 234)
        Me.BtnTXE51.Name = "BtnTXE51"
        Me.BtnTXE51.Size = New System.Drawing.Size(232, 23)
        Me.BtnTXE51.TabIndex = 65
        Me.BtnTXE51.Text = "Payment History Breakout"
        '
        'BtnTXE40
        '
        Me.BtnTXE40.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTXE40.Location = New System.Drawing.Point(8, 205)
        Me.BtnTXE40.Name = "BtnTXE40"
        Me.BtnTXE40.Size = New System.Drawing.Size(232, 23)
        Me.BtnTXE40.TabIndex = 64
        Me.BtnTXE40.Text = "Cash/Check/Credit Detail"
        '
        'btntxe03
        '
        Me.btntxe03.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntxe03.Location = New System.Drawing.Point(256, 205)
        Me.btntxe03.Name = "btntxe03"
        Me.btntxe03.Size = New System.Drawing.Size(245, 23)
        Me.btntxe03.TabIndex = 63
        Me.btntxe03.Text = "Taxes Due"
        '
        'Btntxe26
        '
        Me.Btntxe26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btntxe26.Location = New System.Drawing.Point(8, 176)
        Me.Btntxe26.Name = "Btntxe26"
        Me.Btntxe26.Size = New System.Drawing.Size(232, 23)
        Me.Btntxe26.TabIndex = 62
        Me.Btntxe26.Text = "Payment Detail History"
        '
        'btntxe04
        '
        Me.btntxe04.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntxe04.Location = New System.Drawing.Point(256, 176)
        Me.btntxe04.Name = "btntxe04"
        Me.btntxe04.Size = New System.Drawing.Size(245, 23)
        Me.btntxe04.TabIndex = 61
        Me.btntxe04.Text = "Open Accounts"
        '
        'btntxe20
        '
        Me.btntxe20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntxe20.Location = New System.Drawing.Point(8, 144)
        Me.btntxe20.Name = "btntxe20"
        Me.btntxe20.Size = New System.Drawing.Size(232, 23)
        Me.btntxe20.TabIndex = 60
        Me.btntxe20.Text = "Batch Summary"
        '
        'btntxe18
        '
        Me.btntxe18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntxe18.Location = New System.Drawing.Point(256, 80)
        Me.btntxe18.Name = "btntxe18"
        Me.btntxe18.Size = New System.Drawing.Size(245, 23)
        Me.btntxe18.TabIndex = 59
        Me.btntxe18.Text = "Fees Collected"
        '
        'btntxe17
        '
        Me.btntxe17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntxe17.Location = New System.Drawing.Point(256, 112)
        Me.btntxe17.Name = "btntxe17"
        Me.btntxe17.Size = New System.Drawing.Size(245, 23)
        Me.btntxe17.TabIndex = 58
        Me.btntxe17.Text = "Liened Accounts Payments"
        '
        'btntxe16
        '
        Me.btntxe16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntxe16.Location = New System.Drawing.Point(256, 48)
        Me.btntxe16.Name = "btntxe16"
        Me.btntxe16.Size = New System.Drawing.Size(245, 23)
        Me.btntxe16.TabIndex = 57
        Me.btntxe16.Text = "Interest Override History"
        '
        'btntxe13
        '
        Me.btntxe13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntxe13.Location = New System.Drawing.Point(256, 144)
        Me.btntxe13.Name = "btntxe13"
        Me.btntxe13.Size = New System.Drawing.Size(245, 23)
        Me.btntxe13.TabIndex = 56
        Me.btntxe13.Text = "Over Payment List/Letter"
        '
        'label15
        '
        Me.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.label15.ForeColor = System.Drawing.Color.Maroon
        Me.label15.Image = CType(resources.GetObject("label15.Image"), System.Drawing.Image)
        Me.label15.Location = New System.Drawing.Point(0, 0)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(528, 20)
        Me.label15.TabIndex = 55
        '
        'btntxe08
        '
        Me.btntxe08.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntxe08.Location = New System.Drawing.Point(8, 112)
        Me.btntxe08.Name = "btntxe08"
        Me.btntxe08.Size = New System.Drawing.Size(232, 23)
        Me.btntxe08.TabIndex = 49
        Me.btntxe08.Text = "Balance Sheet"
        '
        'btntxe05
        '
        Me.btntxe05.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntxe05.Location = New System.Drawing.Point(8, 80)
        Me.btntxe05.Name = "btntxe05"
        Me.btntxe05.Size = New System.Drawing.Size(232, 23)
        Me.btntxe05.TabIndex = 47
        Me.btntxe05.Text = "Collection Breakdown Report"
        '
        'btntxe02
        '
        Me.btntxe02.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntxe02.Location = New System.Drawing.Point(8, 48)
        Me.btntxe02.Name = "btntxe02"
        Me.btntxe02.Size = New System.Drawing.Size(232, 23)
        Me.btntxe02.TabIndex = 46
        Me.btntxe02.Text = "Payment History/Refund"
        '
        'tabsuspense
        '
        Me.tabsuspense.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabsuspense.Controls.Add(Me.btntx901)
        Me.tabsuspense.Controls.Add(Me.btntx902)
        Me.tabsuspense.Controls.Add(Me.btntx904)
        Me.tabsuspense.Controls.Add(Me.btntx903)
        Me.tabsuspense.Controls.Add(Me.label7)
        Me.tabsuspense.Location = New System.Drawing.Point(4, 53)
        Me.tabsuspense.Name = "tabsuspense"
        Me.tabsuspense.Size = New System.Drawing.Size(574, 380)
        Me.tabsuspense.TabIndex = 7
        Me.tabsuspense.Text = "Suspense"
        Me.tabsuspense.UseVisualStyleBackColor = True
        Me.tabsuspense.Visible = False
        '
        'btntx901
        '
        Me.btntx901.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx901.Location = New System.Drawing.Point(104, 64)
        Me.btntx901.Name = "btntx901"
        Me.btntx901.Size = New System.Drawing.Size(334, 24)
        Me.btntx901.TabIndex = 16
        Me.btntx901.Text = "Maintain Suspense Batches"
        '
        'btntx902
        '
        Me.btntx902.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx902.Location = New System.Drawing.Point(104, 104)
        Me.btntx902.Name = "btntx902"
        Me.btntx902.Size = New System.Drawing.Size(334, 24)
        Me.btntx902.TabIndex = 15
        Me.btntx902.Text = "Create Suspense Batch"
        '
        'btntx904
        '
        Me.btntx904.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx904.Location = New System.Drawing.Point(104, 184)
        Me.btntx904.Name = "btntx904"
        Me.btntx904.Size = New System.Drawing.Size(334, 24)
        Me.btntx904.TabIndex = 14
        Me.btntx904.Text = "Create Suspense File For Collection Agency"
        '
        'btntx903
        '
        Me.btntx903.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx903.Location = New System.Drawing.Point(104, 144)
        Me.btntx903.Name = "btntx903"
        Me.btntx903.Size = New System.Drawing.Size(334, 24)
        Me.btntx903.TabIndex = 12
        Me.btntx903.Text = "Print Suspense History"
        '
        'label7
        '
        Me.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label7.ForeColor = System.Drawing.Color.Maroon
        Me.label7.Image = CType(resources.GetObject("label7.Image"), System.Drawing.Image)
        Me.label7.Location = New System.Drawing.Point(0, 0)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(536, 32)
        Me.label7.TabIndex = 6
        '
        'tabCC
        '
        Me.tabCC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabCC.Controls.Add(Me.btntx710)
        Me.tabCC.Controls.Add(Me.btntx702)
        Me.tabCC.Controls.Add(Me.btntx701)
        Me.tabCC.Controls.Add(Me.label4)
        Me.tabCC.Location = New System.Drawing.Point(4, 53)
        Me.tabCC.Name = "tabCC"
        Me.tabCC.Size = New System.Drawing.Size(574, 380)
        Me.tabCC.TabIndex = 3
        Me.tabCC.Text = "Certificate of Correction"
        Me.tabCC.UseVisualStyleBackColor = True
        Me.tabCC.Visible = False
        '
        'btntx710
        '
        Me.btntx710.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx710.Location = New System.Drawing.Point(144, 159)
        Me.btntx710.Name = "btntx710"
        Me.btntx710.Size = New System.Drawing.Size(248, 24)
        Me.btntx710.TabIndex = 10
        Me.btntx710.Text = "Maintain Change of Certificate"
        '
        'btntx702
        '
        Me.btntx702.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx702.Location = New System.Drawing.Point(144, 130)
        Me.btntx702.Name = "btntx702"
        Me.btntx702.Size = New System.Drawing.Size(248, 23)
        Me.btntx702.TabIndex = 8
        Me.btntx702.Text = "Print Bills"
        '
        'btntx701
        '
        Me.btntx701.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntx701.Location = New System.Drawing.Point(144, 98)
        Me.btntx701.Name = "btntx701"
        Me.btntx701.Size = New System.Drawing.Size(248, 26)
        Me.btntx701.TabIndex = 7
        Me.btntx701.Text = "Print Register"
        '
        'label4
        '
        Me.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.ForeColor = System.Drawing.Color.Maroon
        Me.label4.Image = CType(resources.GetObject("label4.Image"), System.Drawing.Image)
        Me.label4.Location = New System.Drawing.Point(0, 0)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(536, 32)
        Me.label4.TabIndex = 6
        '
        'tabAddl
        '
        Me.tabAddl.Controls.Add(Me.BtnTX351)
        Me.tabAddl.Controls.Add(Me.BtnTX352)
        Me.tabAddl.Controls.Add(Me.BtnTX350)
        Me.tabAddl.Location = New System.Drawing.Point(4, 53)
        Me.tabAddl.Name = "tabAddl"
        Me.tabAddl.Size = New System.Drawing.Size(574, 380)
        Me.tabAddl.TabIndex = 12
        Me.tabAddl.Text = "Addl. Billing"
        Me.tabAddl.UseVisualStyleBackColor = True
        '
        'BtnTX351
        '
        Me.BtnTX351.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTX351.Location = New System.Drawing.Point(152, 76)
        Me.BtnTX351.Name = "BtnTX351"
        Me.BtnTX351.Size = New System.Drawing.Size(248, 26)
        Me.BtnTX351.TabIndex = 10
        Me.BtnTX351.Text = "Print Addl. Billing Ratebook"
        '
        'BtnTX352
        '
        Me.BtnTX352.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTX352.Location = New System.Drawing.Point(152, 108)
        Me.BtnTX352.Name = "BtnTX352"
        Me.BtnTX352.Size = New System.Drawing.Size(248, 26)
        Me.BtnTX352.TabIndex = 9
        Me.BtnTX352.Text = "Print Add.Billing Grand List"
        '
        'BtnTX350
        '
        Me.BtnTX350.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTX350.Location = New System.Drawing.Point(152, 44)
        Me.BtnTX350.Name = "BtnTX350"
        Me.BtnTX350.Size = New System.Drawing.Size(248, 26)
        Me.BtnTX350.TabIndex = 8
        Me.BtnTX350.Text = "Print Addl. Bills"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label10.Font = New System.Drawing.Font("Cooper Black", 21.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label10.ImageIndex = 4
        Me.Label10.Location = New System.Drawing.Point(48, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(510, 40)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Collector"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmMenuTX
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(604, 498)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.tab)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmMenuTX"
        Me.tab.ResumeLayout(False)
        Me.tabdaily.ResumeLayout(False)
        Me.tabelectronicbanking.ResumeLayout(False)
        Me.tabassessorinq.ResumeLayout(False)
        Me.tabutilities.ResumeLayout(False)
        Me.tabBills.ResumeLayout(False)
        Me.tabprebilling.ResumeLayout(False)
        Me.tabtables.ResumeLayout(False)
        Me.tabreports.ResumeLayout(False)
        Me.tabControl2.ResumeLayout(False)
        Me.tabPage5.ResumeLayout(False)
        Me.tabPage9.ResumeLayout(False)
        Me.tabPage10.ResumeLayout(False)
        Me.tabPage12.ResumeLayout(False)
        Me.tabsuspense.ResumeLayout(False)
        Me.tabCC.ResumeLayout(False)
        Me.tabAddl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmMenuTX_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmMain.SbpScreen.Text = "MenuTX"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub FrmMenuTX_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    AddHandler btnto101.MouseDown, AddressOf DoMouseDown
    AddHandler btnto102.MouseDown, AddressOf DoMouseDown
    AddHandler btnto103.MouseDown, AddressOf DoMouseDown
    AddHandler btnto104.MouseDown, AddressOf DoMouseDown
    AddHandler btnto105.MouseDown, AddressOf DoMouseDown
    AddHandler btnto106.MouseDown, AddressOf DoMouseDown
    AddHandler btnto107.MouseDown, AddressOf DoMouseDown
    AddHandler btnto109.MouseDown, AddressOf DoMouseDown
    AddHandler btnto110.MouseDown, AddressOf DoMouseDown
    AddHandler btnto111.MouseDown, AddressOf DoMouseDown
    AddHandler btnto112.MouseDown, AddressOf DoMouseDown
    AddHandler btnto113.MouseDown, AddressOf DoMouseDown
    AddHandler btnto114.MouseDown, AddressOf DoMouseDown
    AddHandler btnto116.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTO120.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTO200.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTO206.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTO300.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTO301.MouseDown, AddressOf DoMouseDown
    AddHandler btntx101.MouseDown, AddressOf DoMouseDown
    AddHandler btntx102.MouseDown, AddressOf DoMouseDown
    AddHandler btntx103.MouseDown, AddressOf DoMouseDown
    AddHandler btntx104.MouseDown, AddressOf DoMouseDown
    AddHandler btntx105.MouseDown, AddressOf DoMouseDown
    AddHandler btntx106.MouseDown, AddressOf DoMouseDown
    AddHandler btntx107.MouseDown, AddressOf DoMouseDown
    AddHandler btntx108.MouseDown, AddressOf DoMouseDown
    AddHandler btntx109.MouseDown, AddressOf DoMouseDown
    AddHandler btntx110.MouseDown, AddressOf DoMouseDown
    AddHandler btntx111.MouseDown, AddressOf DoTA110
    AddHandler BtnTX112.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTX113.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTX114.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTX115.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTX116.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTX117.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTX118.MouseDown, AddressOf DoMouseDown
    AddHandler btntx201.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTX203.MouseDown, AddressOf DoMouseDown
    AddHandler btntx210.MouseDown, AddressOf DoMouseDown
    AddHandler btntx211.MouseDown, AddressOf DoMouseDown
    AddHandler btntx301.MouseDown, AddressOf DoMouseDown
    AddHandler btntx302.MouseDown, AddressOf DoMouseDown
    AddHandler btntx303.MouseDown, AddressOf DoMouseDown
    AddHandler btntx304.MouseDown, AddressOf DoMouseDown
    AddHandler btntx310.MouseDown, AddressOf DoMouseDown
    AddHandler btntx311.MouseDown, AddressOf DoMouseDown
    AddHandler btntx312.MouseDown, AddressOf DoMouseDown
    AddHandler btntx313.MouseDown, AddressOf DoMouseDown
    AddHandler btntx314.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTX340.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTX350.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTX351.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTX352.MouseDown, AddressOf DoMouseDown
    AddHandler btntx401.MouseDown, AddressOf DoMouseDown
    AddHandler btntx402.MouseDown, AddressOf DoMouseDown
    AddHandler btntx404.MouseDown, AddressOf DoMouseDown
    AddHandler btntx405.MouseDown, AddressOf DoMouseDown
    AddHandler btntx406.MouseDown, AddressOf DoMouseDown
    AddHandler btntx407.MouseDown, AddressOf DoMouseDown
    AddHandler btntx410.MouseDown, AddressOf DoMouseDown
    AddHandler btntx411.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTX412.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTX430.MouseDown, AddressOf DoMouseDown
    AddHandler btntx501.MouseDown, AddressOf DoMouseDown
    AddHandler btntx505.MouseDown, AddressOf DoMouseDown
    AddHandler btntx506.MouseDown, AddressOf DoMouseDown
    AddHandler btntx701.MouseDown, AddressOf DoTA801
    AddHandler btntx702.MouseDown, AddressOf DoMouseDown
    AddHandler btntx710.MouseDown, AddressOf DoTA811
    AddHandler BtnTX801.MouseDown, AddressOf DoMouseDown
    AddHandler btntx802.MouseDown, AddressOf DoMouseDown
    AddHandler btntx808.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTX809.MouseDown, AddressOf DoMouseDown
    AddHandler btntx810.MouseDown, AddressOf DoMouseDown
    AddHandler btntx816.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTX830.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTX831.MouseDown, AddressOf DoMouseDown
    AddHandler btntx901.MouseDown, AddressOf DoMouseDown
    AddHandler btntx902.MouseDown, AddressOf DoMouseDown
    AddHandler btntx903.MouseDown, AddressOf DoMouseDown
    AddHandler btntx904.MouseDown, AddressOf DoMouseDown
    AddHandler btntxa01.MouseDown, AddressOf DoMouseDown
    AddHandler btntxa02.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTXA03.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTXA04.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTXA05.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTXA06.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTxa08.MouseDown, AddressOf DoMouseDown
    AddHandler btntxa09.MouseDown, AddressOf DoMouseDown
    AddHandler btntxa09i.MouseDown, AddressOf DoTXA09I
    AddHandler btntxa12.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTXA31.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTXA32.MouseDown, AddressOf DoMouseDown
    AddHandler btnTXD01.MouseDown, AddressOf DoTA001I
    AddHandler btntxe02.MouseDown, AddressOf DoMouseDown
    AddHandler btntxe03.MouseDown, AddressOf DoMouseDown
    AddHandler btntxe04.MouseDown, AddressOf DoMouseDown
    AddHandler btntxe05.MouseDown, AddressOf DoMouseDown
    AddHandler btntxe06.MouseDown, AddressOf DoMouseDown
    AddHandler btntxe08.MouseDown, AddressOf DoMouseDown
    AddHandler btntxe09.MouseDown, AddressOf DoMouseDown
    AddHandler btntxe10.MouseDown, AddressOf DoMouseDown
    AddHandler btntxe11.MouseDown, AddressOf DoMouseDown
    AddHandler btntxe12.MouseDown, AddressOf DoMouseDown
    AddHandler btntxe13.MouseDown, AddressOf DoMouseDown
    AddHandler btntxe14.MouseDown, AddressOf DoMouseDown
    AddHandler btntxe15.MouseDown, AddressOf DoMouseDown
    AddHandler btntxe16.MouseDown, AddressOf DoMouseDown
    AddHandler btntxe17.MouseDown, AddressOf DoMouseDown
    AddHandler btntxe18.MouseDown, AddressOf DoMouseDown
    AddHandler btntxe20.MouseDown, AddressOf DoMouseDown
    AddHandler btntxe21.MouseDown, AddressOf DoMouseDown
    AddHandler btntxe24.MouseDown, AddressOf DoMouseDown
    AddHandler btntxe25.MouseDown, AddressOf DoMouseDown
    AddHandler Btntxe26.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTXE40.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTXE42.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTXE43.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTXE44.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTXE45.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTXE46.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTXE47.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTXE48.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTXE49.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTXE50.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTXE51.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTXE52.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTXE53.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTXE54.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTXE55.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTXE56.MouseDown, AddressOf DoMouseDown
  End Sub
  Public Sub DoMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    'Handles all button Mouse Clicks on form
    If e.Clicks = 1 Then
      LaunchEXE(Me.ActiveControl.Name)
    End If
  End Sub
  Public Sub DoTA001(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    If e.Clicks = 1 Then
      LaunchEXE("TA001")
    End If
  End Sub
  Public Sub DoTA001I(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    If e.Clicks = 1 Then
      LaunchEXE("TA001", "inquiry")
    End If
  End Sub
  Public Sub DoTA110(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    If e.Clicks = 1 Then
      LaunchEXE("TA110")
    End If
  End Sub
  Public Sub DoTA801(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    If e.Clicks = 1 Then
      LaunchEXE("TA801")
    End If
  End Sub
  Public Sub DoTA811(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    If e.Clicks = 1 Then
      LaunchEXE("TA811")
    End If
  End Sub
  Public Sub DoTXA09I(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    If e.Clicks = 1 Then
      LaunchEXE("TXA09", "inquiry")
    End If
  End Sub
  Private Sub FrmMenuTX_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmMenu.Show()
  End Sub
  Private Sub FrmMenuTX_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
    If Me.WindowState = FormWindowState.Minimized Then
      Me.Text = "TX"
    Else
      Me.Text = ""
    End If
  End Sub
  Private Sub FrmMenuTX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If Not e.Alt Then Exit Sub
    If e.KeyCode = Keys.F12 Then
      MyUtils.PrtScreen(Form.ActiveForm)
    End If
  End Sub

  Private Sub btntxe21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntxe21.Click

  End Sub


  Private Sub tabelectronicbanking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabelectronicbanking.Click

  End Sub

  Private Sub tabdaily_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabdaily.Click

  End Sub

  Private Sub tabutilities_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabutilities.Click

  End Sub

  Private Sub tabtables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabtables.Click

  End Sub

  Private Sub tabprebilling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabprebilling.Click
  End Sub

  Private Sub tabPage5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabPage5.Click

  End Sub

  Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

  End Sub
End Class
