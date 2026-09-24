Imports System.Data
Imports System.Text
Public Class FrmGL503B
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
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents RbBamt1 As System.Windows.Forms.RadioButton
  Friend WithEvents RbBamt2 As System.Windows.Forms.RadioButton
 Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
 Friend WithEvents GrpBudget As System.Windows.Forms.GroupBox
 Friend WithEvents PosSfunc As System.Windows.Forms.TextBox
 Friend WithEvents PosFunc As System.Windows.Forms.TextBox
 Friend WithEvents PosObj As System.Windows.Forms.TextBox
 Friend WithEvents PosDept As System.Windows.Forms.TextBox
 Friend WithEvents PosSfund As System.Windows.Forms.TextBox
 Friend WithEvents PosFund As System.Windows.Forms.TextBox
 Friend WithEvents TxtBamt1 As System.Windows.Forms.TextBox
 Friend WithEvents LblBamt1 As System.Windows.Forms.Label
 Friend WithEvents TxtBamt2 As System.Windows.Forms.TextBox
 Friend WithEvents LblBamt2 As System.Windows.Forms.Label
 Friend WithEvents RbNarr As System.Windows.Forms.RadioButton
 Friend WithEvents RbBamt4 As System.Windows.Forms.RadioButton
 Friend WithEvents RbBamt3 As System.Windows.Forms.RadioButton
 Friend WithEvents TxtBamt4 As System.Windows.Forms.TextBox
 Friend WithEvents LblBamt4 As System.Windows.Forms.Label
 Friend WithEvents TxtBamt3 As System.Windows.Forms.TextBox
 Friend WithEvents LblBamt3 As System.Windows.Forms.Label
 Friend WithEvents LblProj As System.Windows.Forms.Label
 Friend WithEvents LblCurr As System.Windows.Forms.Label
 Friend WithEvents label27 As System.Windows.Forms.Label
 Friend WithEvents label26 As System.Windows.Forms.Label
 Friend WithEvents label25 As System.Windows.Forms.Label
 Friend WithEvents label24 As System.Windows.Forms.Label
 Friend WithEvents LblOrig As System.Windows.Forms.Label
 Friend WithEvents LblExp As System.Windows.Forms.Label
 Friend WithEvents TxtSfunc As System.Windows.Forms.TextBox
 Friend WithEvents TxtFunc As System.Windows.Forms.TextBox
 Friend WithEvents TxtObj As System.Windows.Forms.TextBox
 Friend WithEvents TxtDept As System.Windows.Forms.TextBox
 Friend WithEvents TxtSfund As System.Windows.Forms.TextBox
 Friend WithEvents TxtFund As System.Windows.Forms.TextBox
 Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
 Friend WithEvents TxtNarr As System.Windows.Forms.TextBox
Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGL503B))
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.RbBamt1 = New System.Windows.Forms.RadioButton()
    Me.RbBamt2 = New System.Windows.Forms.RadioButton()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GrpBudget = New System.Windows.Forms.GroupBox()
    Me.LblProj = New System.Windows.Forms.Label()
    Me.LblCurr = New System.Windows.Forms.Label()
    Me.label27 = New System.Windows.Forms.Label()
    Me.label26 = New System.Windows.Forms.Label()
    Me.label25 = New System.Windows.Forms.Label()
    Me.label24 = New System.Windows.Forms.Label()
    Me.LblOrig = New System.Windows.Forms.Label()
    Me.LblExp = New System.Windows.Forms.Label()
    Me.TxtBamt4 = New System.Windows.Forms.TextBox()
    Me.LblBamt4 = New System.Windows.Forms.Label()
    Me.TxtBamt3 = New System.Windows.Forms.TextBox()
    Me.LblBamt3 = New System.Windows.Forms.Label()
    Me.TxtBamt2 = New System.Windows.Forms.TextBox()
    Me.LblBamt2 = New System.Windows.Forms.Label()
    Me.LblBamt1 = New System.Windows.Forms.Label()
    Me.TxtBamt1 = New System.Windows.Forms.TextBox()
    Me.PosSfunc = New System.Windows.Forms.TextBox()
    Me.PosFunc = New System.Windows.Forms.TextBox()
    Me.PosObj = New System.Windows.Forms.TextBox()
    Me.PosDept = New System.Windows.Forms.TextBox()
    Me.PosSfund = New System.Windows.Forms.TextBox()
    Me.PosFund = New System.Windows.Forms.TextBox()
    Me.RbBamt3 = New System.Windows.Forms.RadioButton()
    Me.RbBamt4 = New System.Windows.Forms.RadioButton()
    Me.RbNarr = New System.Windows.Forms.RadioButton()
    Me.TxtSfunc = New System.Windows.Forms.TextBox()
    Me.TxtFunc = New System.Windows.Forms.TextBox()
    Me.TxtObj = New System.Windows.Forms.TextBox()
    Me.TxtDept = New System.Windows.Forms.TextBox()
    Me.TxtSfund = New System.Windows.Forms.TextBox()
    Me.TxtFund = New System.Windows.Forms.TextBox()
    Me.TxtDesc = New System.Windows.Forms.TextBox()
    Me.TxtNarr = New System.Windows.Forms.TextBox()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpBudget.SuspendLayout()
    Me.SuspendLayout()
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(277, 14)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 2
    Me.BtnFind.Text = "Find"
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColSelect = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AllowUpdate = False
    Me.C1DataGrdList.AlternatingRows = True
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(13, 47)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    Me.C1DataGrdList.Size = New System.Drawing.Size(722, 231)
    Me.C1DataGrdList.TabIndex = 196
    '
    'RbBamt1
    '
    Me.RbBamt1.AutoSize = True
    Me.RbBamt1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbBamt1.Checked = True
    Me.RbBamt1.Location = New System.Drawing.Point(336, 3)
    Me.RbBamt1.Name = "RbBamt1"
    Me.RbBamt1.Size = New System.Drawing.Size(101, 17)
    Me.RbBamt1.TabIndex = 201
    Me.RbBamt1.TabStop = True
    Me.RbBamt1.Text = "<Budget Amt 1>"
    Me.RbBamt1.UseVisualStyleBackColor = True
    '
    'RbBamt2
    '
    Me.RbBamt2.AutoSize = True
    Me.RbBamt2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbBamt2.Location = New System.Drawing.Point(336, 24)
    Me.RbBamt2.Name = "RbBamt2"
    Me.RbBamt2.Size = New System.Drawing.Size(101, 17)
    Me.RbBamt2.TabIndex = 202
    Me.RbBamt2.Text = "<Budget Amt 2>"
    Me.RbBamt2.UseVisualStyleBackColor = True
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GrpBudget
    '
    Me.GrpBudget.Controls.Add(Me.LblProj)
    Me.GrpBudget.Controls.Add(Me.LblCurr)
    Me.GrpBudget.Controls.Add(Me.label27)
    Me.GrpBudget.Controls.Add(Me.label26)
    Me.GrpBudget.Controls.Add(Me.label25)
    Me.GrpBudget.Controls.Add(Me.label24)
    Me.GrpBudget.Controls.Add(Me.LblOrig)
    Me.GrpBudget.Controls.Add(Me.LblExp)
    Me.GrpBudget.Controls.Add(Me.TxtBamt4)
    Me.GrpBudget.Controls.Add(Me.LblBamt4)
    Me.GrpBudget.Controls.Add(Me.TxtBamt3)
    Me.GrpBudget.Controls.Add(Me.LblBamt3)
    Me.GrpBudget.Controls.Add(Me.TxtBamt2)
    Me.GrpBudget.Controls.Add(Me.LblBamt2)
    Me.GrpBudget.Controls.Add(Me.LblBamt1)
    Me.GrpBudget.Controls.Add(Me.TxtBamt1)
    Me.GrpBudget.Location = New System.Drawing.Point(13, 312)
    Me.GrpBudget.Name = "GrpBudget"
    Me.GrpBudget.Size = New System.Drawing.Size(447, 120)
    Me.GrpBudget.TabIndex = 239
    Me.GrpBudget.TabStop = False
    '
    'LblProj
    '
    Me.LblProj.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblProj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblProj.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblProj.Location = New System.Drawing.Point(364, 75)
    Me.LblProj.Name = "LblProj"
    Me.LblProj.Size = New System.Drawing.Size(72, 20)
    Me.LblProj.TabIndex = 298
    Me.LblProj.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCurr
    '
    Me.LblCurr.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCurr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblCurr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCurr.Location = New System.Drawing.Point(364, 35)
    Me.LblCurr.Name = "LblCurr"
    Me.LblCurr.Size = New System.Drawing.Size(72, 20)
    Me.LblCurr.TabIndex = 296
    Me.LblCurr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'label27
    '
    Me.label27.BackColor = System.Drawing.SystemColors.Control
    Me.label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label27.Location = New System.Drawing.Point(273, 79)
    Me.label27.Name = "label27"
    Me.label27.Size = New System.Drawing.Size(85, 16)
    Me.label27.TabIndex = 294
    Me.label27.Text = "Projected"
    '
    'label26
    '
    Me.label26.BackColor = System.Drawing.SystemColors.Control
    Me.label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label26.Location = New System.Drawing.Point(273, 59)
    Me.label26.Name = "label26"
    Me.label26.Size = New System.Drawing.Size(85, 20)
    Me.label26.TabIndex = 293
    Me.label26.Text = "Current Exp"
    '
    'label25
    '
    Me.label25.BackColor = System.Drawing.SystemColors.Control
    Me.label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label25.Location = New System.Drawing.Point(273, 39)
    Me.label25.Name = "label25"
    Me.label25.Size = New System.Drawing.Size(85, 16)
    Me.label25.TabIndex = 292
    Me.label25.Text = "Current Budget"
    '
    'label24
    '
    Me.label24.BackColor = System.Drawing.SystemColors.Control
    Me.label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label24.Location = New System.Drawing.Point(273, 19)
    Me.label24.Name = "label24"
    Me.label24.Size = New System.Drawing.Size(85, 15)
    Me.label24.TabIndex = 291
    Me.label24.Text = "Original Budget"
    '
    'LblOrig
    '
    Me.LblOrig.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrig.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblOrig.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrig.Location = New System.Drawing.Point(364, 15)
    Me.LblOrig.Name = "LblOrig"
    Me.LblOrig.Size = New System.Drawing.Size(72, 20)
    Me.LblOrig.TabIndex = 295
    Me.LblOrig.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExp
    '
    Me.LblExp.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblExp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExp.Location = New System.Drawing.Point(364, 55)
    Me.LblExp.Name = "LblExp"
    Me.LblExp.Size = New System.Drawing.Size(72, 20)
    Me.LblExp.TabIndex = 297
    Me.LblExp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtBamt4
    '
    Me.TxtBamt4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBamt4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBamt4.Location = New System.Drawing.Point(165, 92)
    Me.TxtBamt4.MaxLength = 11
    Me.TxtBamt4.Name = "TxtBamt4"
    Me.TxtBamt4.Size = New System.Drawing.Size(86, 22)
    Me.TxtBamt4.TabIndex = 290
    Me.TxtBamt4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblBamt4
    '
    Me.LblBamt4.AutoSize = True
    Me.LblBamt4.Location = New System.Drawing.Point(6, 92)
    Me.LblBamt4.Name = "LblBamt4"
    Me.LblBamt4.Size = New System.Drawing.Size(83, 13)
    Me.LblBamt4.TabIndex = 289
    Me.LblBamt4.Text = "<Budget Amt 4>"
    '
    'TxtBamt3
    '
    Me.TxtBamt3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBamt3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBamt3.Location = New System.Drawing.Point(165, 66)
    Me.TxtBamt3.MaxLength = 11
    Me.TxtBamt3.Name = "TxtBamt3"
    Me.TxtBamt3.Size = New System.Drawing.Size(86, 22)
    Me.TxtBamt3.TabIndex = 288
    Me.TxtBamt3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblBamt3
    '
    Me.LblBamt3.AutoSize = True
    Me.LblBamt3.Location = New System.Drawing.Point(6, 66)
    Me.LblBamt3.Name = "LblBamt3"
    Me.LblBamt3.Size = New System.Drawing.Size(83, 13)
    Me.LblBamt3.TabIndex = 287
    Me.LblBamt3.Text = "<Budget Amt 3>"
    '
    'TxtBamt2
    '
    Me.TxtBamt2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBamt2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBamt2.Location = New System.Drawing.Point(165, 40)
    Me.TxtBamt2.MaxLength = 11
    Me.TxtBamt2.Name = "TxtBamt2"
    Me.TxtBamt2.Size = New System.Drawing.Size(86, 22)
    Me.TxtBamt2.TabIndex = 286
    Me.TxtBamt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblBamt2
    '
    Me.LblBamt2.AutoSize = True
    Me.LblBamt2.Location = New System.Drawing.Point(6, 40)
    Me.LblBamt2.Name = "LblBamt2"
    Me.LblBamt2.Size = New System.Drawing.Size(83, 13)
    Me.LblBamt2.TabIndex = 285
    Me.LblBamt2.Text = "<Budget Amt 2>"
    '
    'LblBamt1
    '
    Me.LblBamt1.AutoSize = True
    Me.LblBamt1.Location = New System.Drawing.Point(6, 16)
    Me.LblBamt1.Name = "LblBamt1"
    Me.LblBamt1.Size = New System.Drawing.Size(83, 13)
    Me.LblBamt1.TabIndex = 284
    Me.LblBamt1.Text = "<Budget Amt 1>"
    '
    'TxtBamt1
    '
    Me.TxtBamt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBamt1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBamt1.Location = New System.Drawing.Point(165, 12)
    Me.TxtBamt1.MaxLength = 11
    Me.TxtBamt1.Name = "TxtBamt1"
    Me.TxtBamt1.Size = New System.Drawing.Size(86, 22)
    Me.TxtBamt1.TabIndex = 283
    Me.TxtBamt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'PosSfunc
    '
    Me.PosSfunc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.PosSfunc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.PosSfunc.Location = New System.Drawing.Point(226, 14)
    Me.PosSfunc.MaxLength = 4
    Me.PosSfunc.Name = "PosSfunc"
    Me.PosSfunc.Size = New System.Drawing.Size(45, 22)
    Me.PosSfunc.TabIndex = 245
    '
    'PosFunc
    '
    Me.PosFunc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.PosFunc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.PosFunc.Location = New System.Drawing.Point(175, 14)
    Me.PosFunc.MaxLength = 4
    Me.PosFunc.Name = "PosFunc"
    Me.PosFunc.Size = New System.Drawing.Size(45, 22)
    Me.PosFunc.TabIndex = 244
    '
    'PosObj
    '
    Me.PosObj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.PosObj.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.PosObj.Location = New System.Drawing.Point(139, 14)
    Me.PosObj.MaxLength = 3
    Me.PosObj.Name = "PosObj"
    Me.PosObj.Size = New System.Drawing.Size(32, 22)
    Me.PosObj.TabIndex = 243
    '
    'PosDept
    '
    Me.PosDept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.PosDept.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.PosDept.Location = New System.Drawing.Point(88, 14)
    Me.PosDept.MaxLength = 4
    Me.PosDept.Name = "PosDept"
    Me.PosDept.Size = New System.Drawing.Size(45, 22)
    Me.PosDept.TabIndex = 242
    '
    'PosSfund
    '
    Me.PosSfund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.PosSfund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.PosSfund.Location = New System.Drawing.Point(50, 14)
    Me.PosSfund.MaxLength = 3
    Me.PosSfund.Name = "PosSfund"
    Me.PosSfund.Size = New System.Drawing.Size(32, 22)
    Me.PosSfund.TabIndex = 241
    '
    'PosFund
    '
    Me.PosFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.PosFund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.PosFund.Location = New System.Drawing.Point(12, 14)
    Me.PosFund.MaxLength = 3
    Me.PosFund.Name = "PosFund"
    Me.PosFund.Size = New System.Drawing.Size(32, 22)
    Me.PosFund.TabIndex = 240
    '
    'RbBamt3
    '
    Me.RbBamt3.AutoSize = True
    Me.RbBamt3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbBamt3.Location = New System.Drawing.Point(466, 3)
    Me.RbBamt3.Name = "RbBamt3"
    Me.RbBamt3.Size = New System.Drawing.Size(101, 17)
    Me.RbBamt3.TabIndex = 246
    Me.RbBamt3.Text = "<Budget Amt 3>"
    Me.RbBamt3.UseVisualStyleBackColor = True
    '
    'RbBamt4
    '
    Me.RbBamt4.AutoSize = True
    Me.RbBamt4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbBamt4.Location = New System.Drawing.Point(466, 21)
    Me.RbBamt4.Name = "RbBamt4"
    Me.RbBamt4.Size = New System.Drawing.Size(101, 17)
    Me.RbBamt4.TabIndex = 247
    Me.RbBamt4.Text = "<Budget Amt 4>"
    Me.RbBamt4.UseVisualStyleBackColor = True
    '
    'RbNarr
    '
    Me.RbNarr.AutoSize = True
    Me.RbNarr.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbNarr.Location = New System.Drawing.Point(597, 14)
    Me.RbNarr.Name = "RbNarr"
    Me.RbNarr.Size = New System.Drawing.Size(68, 17)
    Me.RbNarr.TabIndex = 248
    Me.RbNarr.Text = "Narrative"
    Me.RbNarr.UseVisualStyleBackColor = True
    '
    'TxtSfunc
    '
    Me.TxtSfunc.BackColor = System.Drawing.Color.Aqua
    Me.TxtSfunc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfunc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfunc.Location = New System.Drawing.Point(227, 284)
    Me.TxtSfunc.MaxLength = 4
    Me.TxtSfunc.Name = "TxtSfunc"
    Me.TxtSfunc.ReadOnly = True
    Me.TxtSfunc.Size = New System.Drawing.Size(45, 22)
    Me.TxtSfunc.TabIndex = 289
    '
    'TxtFunc
    '
    Me.TxtFunc.BackColor = System.Drawing.Color.Aqua
    Me.TxtFunc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFunc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFunc.Location = New System.Drawing.Point(176, 284)
    Me.TxtFunc.MaxLength = 4
    Me.TxtFunc.Name = "TxtFunc"
    Me.TxtFunc.ReadOnly = True
    Me.TxtFunc.Size = New System.Drawing.Size(45, 22)
    Me.TxtFunc.TabIndex = 288
    '
    'TxtObj
    '
    Me.TxtObj.BackColor = System.Drawing.Color.Aqua
    Me.TxtObj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObj.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObj.Location = New System.Drawing.Point(140, 284)
    Me.TxtObj.MaxLength = 3
    Me.TxtObj.Name = "TxtObj"
    Me.TxtObj.ReadOnly = True
    Me.TxtObj.Size = New System.Drawing.Size(32, 22)
    Me.TxtObj.TabIndex = 287
    '
    'TxtDept
    '
    Me.TxtDept.BackColor = System.Drawing.Color.Aqua
    Me.TxtDept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDept.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDept.Location = New System.Drawing.Point(89, 284)
    Me.TxtDept.MaxLength = 4
    Me.TxtDept.Name = "TxtDept"
    Me.TxtDept.ReadOnly = True
    Me.TxtDept.Size = New System.Drawing.Size(45, 22)
    Me.TxtDept.TabIndex = 286
    '
    'TxtSfund
    '
    Me.TxtSfund.BackColor = System.Drawing.Color.Aqua
    Me.TxtSfund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfund.Location = New System.Drawing.Point(51, 284)
    Me.TxtSfund.MaxLength = 3
    Me.TxtSfund.Name = "TxtSfund"
    Me.TxtSfund.ReadOnly = True
    Me.TxtSfund.Size = New System.Drawing.Size(32, 22)
    Me.TxtSfund.TabIndex = 285
    '
    'TxtFund
    '
    Me.TxtFund.BackColor = System.Drawing.Color.Aqua
    Me.TxtFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFund.Location = New System.Drawing.Point(13, 284)
    Me.TxtFund.MaxLength = 3
    Me.TxtFund.Name = "TxtFund"
    Me.TxtFund.ReadOnly = True
    Me.TxtFund.Size = New System.Drawing.Size(32, 22)
    Me.TxtFund.TabIndex = 284
    '
    'TxtDesc
    '
    Me.TxtDesc.BackColor = System.Drawing.Color.Aqua
    Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDesc.Location = New System.Drawing.Point(278, 285)
    Me.TxtDesc.MaxLength = 34
    Me.TxtDesc.Name = "TxtDesc"
    Me.TxtDesc.ReadOnly = True
    Me.TxtDesc.Size = New System.Drawing.Size(280, 20)
    Me.TxtDesc.TabIndex = 283
    '
    'TxtNarr
    '
    Me.TxtNarr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtNarr.Location = New System.Drawing.Point(466, 324)
    Me.TxtNarr.MaxLength = 7000
    Me.TxtNarr.Multiline = True
    Me.TxtNarr.Name = "TxtNarr"
    Me.TxtNarr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.TxtNarr.Size = New System.Drawing.Size(171, 102)
    Me.TxtNarr.TabIndex = 290
    '
    'FrmGL503B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(747, 480)
    Me.ControlBox = False
    Me.Controls.Add(Me.TxtNarr)
    Me.Controls.Add(Me.TxtSfunc)
    Me.Controls.Add(Me.TxtFunc)
    Me.Controls.Add(Me.TxtObj)
    Me.Controls.Add(Me.TxtDept)
    Me.Controls.Add(Me.TxtSfund)
    Me.Controls.Add(Me.TxtFund)
    Me.Controls.Add(Me.TxtDesc)
    Me.Controls.Add(Me.RbNarr)
    Me.Controls.Add(Me.RbBamt4)
    Me.Controls.Add(Me.RbBamt3)
    Me.Controls.Add(Me.PosSfunc)
    Me.Controls.Add(Me.PosFunc)
    Me.Controls.Add(Me.PosObj)
    Me.Controls.Add(Me.PosDept)
    Me.Controls.Add(Me.PosSfund)
    Me.Controls.Add(Me.PosFund)
    Me.Controls.Add(Me.GrpBudget)
    Me.Controls.Add(Me.RbBamt2)
    Me.Controls.Add(Me.RbBamt1)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.Controls.Add(Me.BtnFind)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "FrmGL503B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpBudget.ResumeLayout(False)
    Me.GrpBudget.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region
  Dim myGLHEAD As GLHEAD.MyData
  Dim myGLBUDGET As GLBUDGET.MyData
  Dim myBUDNAR As BUDNAR.MyData
  Dim myDEPSEC As DEPSEC.MyData
  Dim ds As DataSet = New DataSet
  Const CFieldLen As Integer = 70

  Private Sub FrmGL503B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myGLHEAD = New GLHEAD.MyData()
    myGLHEAD.MyDBConn = myDBConnect
    myGLBUDGET = New GLBUDGET.MyData()
    myGLBUDGET.MyDBConn = myDBConnect
    myBUDNAR = New BUDNAR.MyData()
    myBUDNAR.MyDBConn = myDBConnect
    myDEPSEC = New DEPSEC.MyData()
    myDEPSEC.MyDBConn = myDBConnect

    If s_chg = False And s_full = False Then    '#sec
      MyFrmGL503.TBarSave.Visible = False
    End If
    myGLHEAD.GetOneRecordP(0, 0)
    LblBamt1.Text = ""
    LblBamt2.Text = ""
    LblBamt3.Text = ""
    LblBamt4.Text = ""

    If Not myGLHEAD.RecordNotFound Then
      With myGLHEAD
        LblBamt1.Text = Trim(._BUDC1)
        RbBamt1.Text = Trim(._BUDA1)
        LblBamt2.Text = Trim(._BUDC2)
        RbBamt2.Text = Trim(._BUDA2)
        LblBamt3.Text = Trim(._BUDC3)
        RbBamt3.Text = Trim(._BUDA3)
        LblBamt4.Text = Trim(._BUDC4)
        RbBamt4.Text = Trim(._BUDA4)
      End With
    End If

    ShowDetail(False)
    MyFrmGL503.TBarSave.Enabled = False
    Select Case MyAppSettings.Selection
      Case 1
        RbBamt1.Checked = True
      Case 2
        RbBamt2.Checked = True
      Case 3
        RbBamt3.Checked = True
      Case 4
        RbBamt4.Checked = True
      Case 5
        RbNarr.Checked = True
      Case Else
        RbBamt1.Checked = True
        MyAppSettings.Selection = 1
    End Select
    SetBamt(MyAppSettings.Selection)

  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    RefreshData()
  End Sub
  Public Sub FormatGrid()

    Call ShowGrid()
    With C1DataGrdList
      .Rebind(True)
      .Columns(0).Caption = "Fund"
      .Splits(0).DisplayColumns(0).Width = 40
      .Columns(1).Caption = "Sfund"
      .Splits(0).DisplayColumns(1).Width = 40
      .Columns(2).Caption = "Dept"
      .Splits(0).DisplayColumns(2).Width = 40
      .Columns(3).Caption = "Obj"
      .Splits(0).DisplayColumns(3).Width = 40
      .Columns(4).Caption = "Func"
      .Splits(0).DisplayColumns(4).Width = 40
      .Columns(5).Caption = "Sfunc"
      .Splits(0).DisplayColumns(5).Width = 40
      .Columns(6).Caption = "Type"
      .Splits(0).DisplayColumns(6).Width = 40
      .Columns(7).Caption = "Description"
      .Splits(0).DisplayColumns(7).Width = 250
    End With
  End Sub
  Public Sub ShowGrid()

    Dim Wrkhasdepsec As Boolean
    Dim Wrkfund As Integer
    Dim wrksfund As Integer
    Dim wrkdept As Integer
    Dim i As Integer
    ds = myGLBUDGET.GetViewbyAcct(MyUtils.CnvSng(PosFund.Text), MyUtils.CnvSng(PosSfund.Text),
     MyUtils.CnvSng(PosDept.Text), MyUtils.CnvSng(PosObj.Text), MyUtils.CnvSng(PosFunc.Text),
     MyUtils.CnvSng(PosSfunc.Text), 100)

    'filter out non secure depts
    'i = ds.Tables(0).Rows.Count - 1

    For i = (ds.Tables(0).Rows.Count - 1) To 0 Step -1

      Wrkfund = ds.Tables(0).Rows(i).Item("fund")
      wrksfund = ds.Tables(0).Rows(i).Item("sfund")
      wrkdept = ds.Tables(0).Rows(i).Item("dept")

      Wrkhasdepsec = CheckDepSec(Wrkfund, wrksfund, wrkdept)
      If Wrkhasdepsec = False Then
        ds.Tables(0).Rows(i).Delete()

      End If
      ' i = i - 1
    Next

    ds.AcceptChanges()


    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()
  End Sub
  Private Sub FrmGL503C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGL503.SbpScreen.Text = "GL503B"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub PrintData()
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds.Copy
    MyCrViewer.Show()
  End Sub
  Public Sub RefreshData()
    Dim WrkFund As Integer
    Dim WrkSfund As Integer
    Dim WrkDept As Integer
    Dim WrkObj As Integer
    Dim WrkFunc As Integer
    Dim WrkSfunc As Integer

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    Call FormatGrid()
    If ds.Tables(0).Rows.Count > 0 Then
      WrkFund = ds.Tables(0).Rows(0).Item("fund")
      WrkSfund = ds.Tables(0).Rows(0).Item("sfund")
      WrkDept = ds.Tables(0).Rows(0).Item("dept")
      WrkObj = ds.Tables(0).Rows(0).Item("obj")
      WrkFunc = ds.Tables(0).Rows(0).Item("func")
      WrkSfunc = ds.Tables(0).Rows(0).Item("sfunc")
      If RbNarr.Checked Then
        GetNarr(WrkFund, WrkSfund, WrkDept, WrkObj, WrkFunc, WrkSfunc)
      Else
        GetBudget(WrkFund, WrkSfund, WrkDept, WrkObj, WrkFunc, WrkSfunc)
      End If
    End If
    MyFrmGL503.TBarPrint.Enabled = True
    GetDepSec(WrkFund, WrkSfund, WrkDept)
    ShowDetail(True)
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Public Sub GetBudget(ByVal WrkFund As Integer, WrkSfund As Integer, WrkDept As Integer, WrkObj As Integer,
   WrkFunc As Integer, WrkSfunc As Integer)
    myGLBUDGET.GetOneRecordP(WrkFund, WrkSfund, WrkDept, WrkObj, WrkFunc, WrkSfunc)
    If myGLBUDGET.RecordNotFound Then Exit Sub

    GetDepSec(WrkFund, WrkSfund, WrkDept)
    With myGLBUDGET
      TxtFund.Text = ._FUND
      TxtSfund.Text = ._SFUND
      TxtDept.Text = ._DEPT
      TxtObj.Text = ._OBJ
      TxtFunc.Text = ._FUNC
      TxtSfunc.Text = ._SFUNC
      TxtDesc.Text = Trim(._DESCD)
      TxtBamt1.Text = Format(._BAMT1, "###########")
      TxtBamt2.Text = Format(._BAMT2, "###########")
      TxtBamt3.Text = Format(._BAMT3, "###########")
      TxtBamt4.Text = Format(._BAMT4, "###########")
      LblOrig.Text = Format(._ORIG, "###########")
      LblCurr.Text = Format(._CURR, "###########")
      LblExp.Text = Format(._EXP, "###########")
      LblProj.Text = Format(._PROP, "###########")
    End With

    MyUtils.SetTxtReadOnly(TxtFund)
    MyUtils.SetTxtReadOnly(TxtSfund)
    MyUtils.SetTxtReadOnly(TxtDept)
    MyUtils.SetTxtReadOnly(TxtObj)
    MyUtils.SetTxtReadOnly(TxtFunc)
    MyUtils.SetTxtReadOnly(TxtSfunc)
    MyUtils.SetTxtReadOnly(TxtDesc)

  End Sub
  Public Sub GetNarr(ByVal WrkFund As Integer, WrkSfund As Integer, WrkDept As Integer, WrkObj As Integer,
   WrkFunc As Integer, WrkSfunc As Integer)

    myGLBUDGET.GetOneRecordP(WrkFund, WrkSfund, WrkDept, WrkObj, WrkFunc, WrkSfunc)
    MyFrmGL503.TBarSave.Enabled = True
    With myGLBUDGET
      TxtFund.Text = ._FUND
      TxtSfund.Text = ._SFUND
      TxtDept.Text = ._DEPT
      TxtObj.Text = ._OBJ
      TxtFunc.Text = ._FUNC
      TxtSfunc.Text = ._SFUNC
      TxtDesc.Text = Trim(._DESCD)
    End With
    FormatNarr()
  End Sub
  Public Sub FormatNarr()
    Dim ds As DataSet
    Dim I As Integer
    Dim WrkStr As String

    ds = myBUDNAR.GetViewbyAcct(MyUtils.CnvSng(TxtFund.Text), MyUtils.CnvSng(TxtSfund.Text),
    MyUtils.CnvSng(TxtDept.Text), MyUtils.CnvSng(TxtObj.Text), MyUtils.CnvSng(TxtFunc.Text),
    MyUtils.CnvSng(TxtSfunc.Text), 0)
    WrkStr = ""
    For I = 0 To ds.Tables(0).Rows.Count - 1
      If Len(ds.Tables(0).Rows(I).Item("nar1")) = CFieldLen - 1 Then
        WrkStr = WrkStr + ds.Tables(0).Rows(I).Item("nar1") & " "
      Else
        WrkStr = WrkStr + ds.Tables(0).Rows(I).Item("nar1")
      End If
    Next
    TxtNarr.Text = Trim(WrkStr)
  End Sub
    Public Sub GetDepSec(ByVal WrkFund As Integer, WrkSfund As Integer, WrkDept As Integer)
        MyFrmGL503.TBarSave.Enabled = True 'added this 12/13/23
        With myDEPSEC

            .GetOneRecordP(MyUserID, 0, 0, 0) ' added this 12/13/23
            If .RecordNotFound Then
                .GetOneRecordP(MyUserID, WrkFund, WrkSfund, 0)
                If .RecordNotFound Then
                    .GetOneRecordP(MyUserID, WrkFund, WrkSfund, WrkDept)
                End If
                If .RecordNotFound Then
                    MyFrmGL503.TBarSave.Enabled = False
                Else
                    MyFrmGL503.TBarSave.Enabled = True
                End If
            End If

        End With
    End Sub
    Public Function CheckDepSec(ByVal WrkFund As Integer, WrkSfund As Integer, WrkDept As Integer) As Boolean
    Dim Wrkhasdepsec As Boolean
    Wrkhasdepsec = True
    With myDEPSEC
      ' if all zeros then got access t oeverything
      .GetOneRecordP(MyUserID, 0, 0, 0)
      If .RecordNotFound Then
        'dept zero then gets all of department
        .GetOneRecordP(MyUserID, WrkFund, WrkSfund, 0)
        If .RecordNotFound Then
          'check if has the dept
          .GetOneRecordP(MyUserID, WrkFund, WrkSfund, WrkDept)
        End If
        If .RecordNotFound Then
          Wrkhasdepsec = False
        End If
      End If ' all zeros
      Return Wrkhasdepsec
    End With

  End Function
  Public Sub ShowDetail(WrkVisible As Boolean)
    TxtFund.Visible = WrkVisible
    TxtSfund.Visible = WrkVisible
    TxtDept.Visible = WrkVisible
    TxtObj.Visible = WrkVisible
    TxtFunc.Visible = WrkVisible
    TxtSfunc.Visible = WrkVisible
    TxtDesc.Visible = WrkVisible
  End Sub

  Public Sub SetBamt(WrkNo As Integer)

    Select Case WrkNo
      Case 1
        TxtNarr.Visible = False
        GrpBudget.Visible = True
        TxtBamt1.ReadOnly = False
        TxtBamt1.BackColor = Color.White
        MyUtils.SetTxtReadOnly(TxtBamt2)
        MyUtils.SetTxtReadOnly(TxtBamt3)
        MyUtils.SetTxtReadOnly(TxtBamt4)
      Case 2
        TxtNarr.Visible = False
        GrpBudget.Visible = True
        TxtBamt2.ReadOnly = False
        TxtBamt2.BackColor = Color.White
        MyUtils.SetTxtReadOnly(TxtBamt1)
        MyUtils.SetTxtReadOnly(TxtBamt3)
        MyUtils.SetTxtReadOnly(TxtBamt4)
      Case 3
        TxtNarr.Visible = False
        GrpBudget.Visible = True
        TxtBamt3.ReadOnly = False
        TxtBamt3.BackColor = Color.White
        MyUtils.SetTxtReadOnly(TxtBamt1)
        MyUtils.SetTxtReadOnly(TxtBamt2)
        MyUtils.SetTxtReadOnly(TxtBamt4)
      Case 4
        TxtNarr.Visible = False
        GrpBudget.Visible = True
        TxtBamt4.ReadOnly = False
        TxtBamt4.BackColor = Color.White
        MyUtils.SetTxtReadOnly(TxtBamt1)
        MyUtils.SetTxtReadOnly(TxtBamt2)
        MyUtils.SetTxtReadOnly(TxtBamt3)
      Case 5
        TxtNarr.Visible = True
        TxtNarr.Location = GrpBudget.Location
        TxtNarr.Width = 725
        GrpBudget.Visible = False
        MyUtils.SetTxtReadOnly(TxtBamt1)
        MyUtils.SetTxtReadOnly(TxtBamt2)
        MyUtils.SetTxtReadOnly(TxtBamt3)
        MyUtils.SetTxtReadOnly(TxtBamt4)
    End Select

  End Sub
  Public Sub SaveData()
    If RbNarr.Checked Then
      SaveDataNar()
    Else
      SaveDataBud()
    End If
  End Sub

  Public Sub SaveDataBud()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    myGLBUDGET.GetOneRecordP(MyUtils.CnvSng(TxtFund.Text), MyUtils.CnvSng(TxtSfund.Text),
    MyUtils.CnvSng(TxtDept.Text), MyUtils.CnvSng(TxtObj.Text), MyUtils.CnvSng(TxtFunc.Text),
    MyUtils.CnvSng(TxtSfunc.Text))
    MovetoFile()
    If IsNothing(ErrorMsg(0)) Then
      myGLBUDGET.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If

    If C1DataGrdList.Row < C1DataGrdList.RowCount - 1 Then
      C1DataGrdList.Row = C1DataGrdList.Row + 1
      GetBudget(C1DataGrdList.Item(C1DataGrdList.Row, 0), C1DataGrdList.Item(C1DataGrdList.Row, 1),
      C1DataGrdList.Item(C1DataGrdList.Row, 2), C1DataGrdList.Item(C1DataGrdList.Row, 3),
      C1DataGrdList.Item(C1DataGrdList.Row, 4), C1DataGrdList.Item(C1DataGrdList.Row, 5))
    Else
      ShowDetail(False)
    End If
  End Sub
  Public Sub SaveDataNar()
    Dim I As Integer
    Dim WrkFund As Integer
    Dim WrkSfund As Integer
    Dim WrkDept As Integer
    Dim WrkObj As Integer
    Dim WrkFunc As Integer
    Dim WrkSfunc As Integer
    Dim WrkLen As Integer
    Dim WrkRecs As Integer
    Dim WrkPos As Integer

    WrkFund = MyUtils.CnvSng(TxtFund.Text)
    WrkSfund = MyUtils.CnvSng(TxtSfund.Text)
    WrkDept = MyUtils.CnvSng(TxtDept.Text)
    WrkObj = MyUtils.CnvSng(TxtObj.Text)
    WrkFunc = MyUtils.CnvSng(TxtFunc.Text)
    WrkSfunc = MyUtils.CnvSng(TxtSfunc.Text)
    myBUDNAR.DeleteAcct(WrkFund, WrkSfund, WrkDept, WrkObj, WrkFunc, WrkSfunc)
    WrkLen = Len(TxtNarr.Text)
    WrkRecs = Math.Ceiling(WrkLen / CFieldLen)
    For I = 0 To WrkRecs - 1
      WrkPos = (I * CFieldLen) + 1
      With myBUDNAR
        .GetOneRecordP(WrkFund, WrkSfund, WrkDept, WrkObj, WrkFunc, WrkSfunc, I)
        ._NAR1 = Mid(TxtNarr.Text, WrkPos, CFieldLen)
        If .RecordNotFound Then
          ._FUND = WrkFund
          ._SFUND = WrkSfund
          ._DEPT = WrkDept
          ._OBJ = WrkObj
          ._FUNC = WrkFunc
          ._SFUNC = WrkSfunc
          ._SEQ = I
          .AddOneRecordP()
        Else
          .UpdateOneRecordP()
        End If
      End With
    Next

    If C1DataGrdList.Row < C1DataGrdList.RowCount - 1 Then
      C1DataGrdList.Row = C1DataGrdList.Row + 1
      GetNarr(C1DataGrdList.Item(C1DataGrdList.Row, 0), C1DataGrdList.Item(C1DataGrdList.Row, 1),
      C1DataGrdList.Item(C1DataGrdList.Row, 2), C1DataGrdList.Item(C1DataGrdList.Row, 3),
      C1DataGrdList.Item(C1DataGrdList.Row, 4), C1DataGrdList.Item(C1DataGrdList.Row, 5))
    Else
      ShowDetail(False)
    End If
  End Sub
  Private Sub MovetoFile()
    With myGLBUDGET
      ._BAMT1 = MyUtils.CnvSng(TxtBamt1.Text)
      ._BAMT2 = MyUtils.CnvSng(TxtBamt2.Text)
      ._BAMT3 = MyUtils.CnvSng(TxtBamt3.Text)
      ._BAMT4 = MyUtils.CnvSng(TxtBamt4.Text)
    End With
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    'Dim I As Integer
    'ErrProv.SetError(TxtBamt1, "")
    'For I = 0 To ErrorField.GetUpperBound(0)
    '  Select Case ErrorField(I)
    '  Case "bamt1"
    '    ErrProv.SetError(TxtBamt1, ErrorMsg(I))
    '  Case Nothing
    '    Exit Sub
    '  End Select
    'Next I
  End Sub
  Private Sub TxtBamt1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBamt1.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      SaveData()
      Exit Sub
    End If

    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBamt2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBamt2.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      SaveData()
      Exit Sub
    End If

    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBamt3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBamt3.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      SaveData()
      Exit Sub
    End If

    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBamt4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBamt4.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      SaveData()
      Exit Sub
    End If

    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub RbBamt1_Click(sender As Object, e As EventArgs) Handles RbBamt1.Click
    SetBamt(1)
  End Sub
  Private Sub RbBamt2_Click(sender As Object, e As EventArgs) Handles RbBamt2.Click
    SetBamt(2)
  End Sub
  Private Sub RbBamt3_Click(sender As Object, e As EventArgs) Handles RbBamt3.Click
    SetBamt(3)
  End Sub
  Private Sub RbBamt4_Click(sender As Object, e As EventArgs) Handles RbBamt4.Click
    SetBamt(4)
  End Sub

  Private Sub RbNarr_CheckedChanged(sender As Object, e As EventArgs) Handles RbNarr.CheckedChanged
    SetBamt(5)
  End Sub
  Private Sub PosFund_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PosFund.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub PosSfund_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PosSfund.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub PosDept_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PosDept.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub PosObj_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PosObj.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub PosFunc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PosFunc.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub PosSfunc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PosSfunc.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub C1DataGrdList_DoubleClick(sender As Object, e As EventArgs) Handles C1DataGrdList.DoubleClick
    If RbNarr.Checked Then
      GetNarr(C1DataGrdList.Item(C1DataGrdList.Row, 0), C1DataGrdList.Item(C1DataGrdList.Row, 1),
      C1DataGrdList.Item(C1DataGrdList.Row, 2), C1DataGrdList.Item(C1DataGrdList.Row, 3),
      C1DataGrdList.Item(C1DataGrdList.Row, 4), C1DataGrdList.Item(C1DataGrdList.Row, 5))
    Else
      GetBudget(C1DataGrdList.Item(C1DataGrdList.Row, 0), C1DataGrdList.Item(C1DataGrdList.Row, 1),
      C1DataGrdList.Item(C1DataGrdList.Row, 2), C1DataGrdList.Item(C1DataGrdList.Row, 3),
      C1DataGrdList.Item(C1DataGrdList.Row, 4), C1DataGrdList.Item(C1DataGrdList.Row, 5))
    End If
  End Sub

  Private Sub C1DataGrdCom_Click(sender As Object, e As EventArgs)

  End Sub

  Private Sub C1DataGrdList_Click(sender As Object, e As EventArgs) Handles C1DataGrdList.Click

  End Sub
End Class
