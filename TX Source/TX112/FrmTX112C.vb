Public Class FrmTX112C
  Inherits System.Windows.Forms.Form
  Dim myTXFMBILL As TXFMBILL.myData
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtPayTo As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents TxtCPhone As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents TxtAPhone As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TxtHours2 As System.Windows.Forms.TextBox
  Friend Wrktype As String
  Friend WithEvents GrpScan As System.Windows.Forms.GroupBox
  Friend WithEvents RbScanWebster As System.Windows.Forms.RadioButton
  Friend WithEvents RbScanDefault As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbModWeight7 As System.Windows.Forms.RadioButton
  Friend WithEvents RbModEven As System.Windows.Forms.RadioButton
  Friend WithEvents RbModOdd As System.Windows.Forms.RadioButton
  Friend WithEvents RbScanSewer As System.Windows.Forms.RadioButton
  Friend WrkAddMode As Boolean

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
Friend WithEvents Txttype As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TxtLine1 As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtLine2 As System.Windows.Forms.TextBox
Friend WithEvents TxtLine3 As System.Windows.Forms.TextBox
Friend WithEvents TxtLine4 As System.Windows.Forms.TextBox
Friend WithEvents TxtLine5 As System.Windows.Forms.TextBox
Friend WithEvents TxtTitle As System.Windows.Forms.TextBox
Friend WithEvents TxtHours1 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Txttype = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtLine1 = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtLine2 = New System.Windows.Forms.TextBox()
    Me.TxtLine3 = New System.Windows.Forms.TextBox()
    Me.TxtLine4 = New System.Windows.Forms.TextBox()
    Me.TxtLine5 = New System.Windows.Forms.TextBox()
    Me.TxtTitle = New System.Windows.Forms.TextBox()
    Me.TxtHours1 = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtPayTo = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtHours2 = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.TxtAPhone = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.TxtCPhone = New System.Windows.Forms.TextBox()
    Me.GrpScan = New System.Windows.Forms.GroupBox()
    Me.RbScanWebster = New System.Windows.Forms.RadioButton()
    Me.RbScanDefault = New System.Windows.Forms.RadioButton()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbModWeight7 = New System.Windows.Forms.RadioButton()
    Me.RbModEven = New System.Windows.Forms.RadioButton()
    Me.RbModOdd = New System.Windows.Forms.RadioButton()
    Me.RbScanSewer = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpScan.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Txttype
    '
    Me.Txttype.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.Txttype.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Txttype.Location = New System.Drawing.Point(48, 16)
    Me.Txttype.MaxLength = 1
    Me.Txttype.Name = "Txttype"
    Me.Txttype.Size = New System.Drawing.Size(20, 22)
    Me.Txttype.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(6, 17)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(36, 16)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "Type:"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtLine1
    '
    Me.TxtLine1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLine1.Location = New System.Drawing.Point(160, 82)
    Me.TxtLine1.MaxLength = 40
    Me.TxtLine1.Name = "TxtLine1"
    Me.TxtLine1.Size = New System.Drawing.Size(326, 22)
    Me.TxtLine1.TabIndex = 2
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(36, 82)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(120, 20)
    Me.Label2.TabIndex = 3
    Me.Label2.Text = "Line 1"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtLine2
    '
    Me.TxtLine2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLine2.Location = New System.Drawing.Point(160, 108)
    Me.TxtLine2.MaxLength = 40
    Me.TxtLine2.Name = "TxtLine2"
    Me.TxtLine2.Size = New System.Drawing.Size(326, 22)
    Me.TxtLine2.TabIndex = 3
    '
    'TxtLine3
    '
    Me.TxtLine3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLine3.Location = New System.Drawing.Point(160, 136)
    Me.TxtLine3.MaxLength = 40
    Me.TxtLine3.Name = "TxtLine3"
    Me.TxtLine3.Size = New System.Drawing.Size(326, 22)
    Me.TxtLine3.TabIndex = 4
    '
    'TxtLine4
    '
    Me.TxtLine4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLine4.Location = New System.Drawing.Point(160, 164)
    Me.TxtLine4.MaxLength = 40
    Me.TxtLine4.Name = "TxtLine4"
    Me.TxtLine4.Size = New System.Drawing.Size(326, 22)
    Me.TxtLine4.TabIndex = 5
    '
    'TxtLine5
    '
    Me.TxtLine5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLine5.Location = New System.Drawing.Point(160, 192)
    Me.TxtLine5.MaxLength = 40
    Me.TxtLine5.Name = "TxtLine5"
    Me.TxtLine5.Size = New System.Drawing.Size(326, 22)
    Me.TxtLine5.TabIndex = 6
    '
    'TxtTitle
    '
    Me.TxtTitle.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTitle.Location = New System.Drawing.Point(160, 220)
    Me.TxtTitle.MaxLength = 25
    Me.TxtTitle.Name = "TxtTitle"
    Me.TxtTitle.Size = New System.Drawing.Size(211, 22)
    Me.TxtTitle.TabIndex = 7
    '
    'TxtHours1
    '
    Me.TxtHours1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtHours1.Location = New System.Drawing.Point(160, 248)
    Me.TxtHours1.MaxLength = 60
    Me.TxtHours1.Multiline = True
    Me.TxtHours1.Name = "TxtHours1"
    Me.TxtHours1.Size = New System.Drawing.Size(250, 32)
    Me.TxtHours1.TabIndex = 8
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(36, 56)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(120, 20)
    Me.Label3.TabIndex = 19
    Me.Label3.Text = "Pay to"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtPayTo
    '
    Me.TxtPayTo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPayTo.Location = New System.Drawing.Point(160, 56)
    Me.TxtPayTo.MaxLength = 30
    Me.TxtPayTo.Name = "TxtPayTo"
    Me.TxtPayTo.Size = New System.Drawing.Size(250, 22)
    Me.TxtPayTo.TabIndex = 1
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(36, 108)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(120, 20)
    Me.Label4.TabIndex = 20
    Me.Label4.Text = "Line 2"
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(36, 136)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(120, 20)
    Me.Label5.TabIndex = 21
    Me.Label5.Text = "Line 3"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label6
    '
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(36, 164)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(120, 20)
    Me.Label6.TabIndex = 22
    Me.Label6.Text = "Line 4"
    Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label7
    '
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(36, 192)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(120, 20)
    Me.Label7.TabIndex = 23
    Me.Label7.Text = "Line 5"
    Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label8
    '
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(36, 219)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(120, 20)
    Me.Label8.TabIndex = 24
    Me.Label8.Text = "Collector Title"
    Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label9
    '
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(36, 247)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(120, 20)
    Me.Label9.TabIndex = 25
    Me.Label9.Text = "Office Hours 1"
    Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label10
    '
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(36, 285)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(120, 20)
    Me.Label10.TabIndex = 27
    Me.Label10.Text = "Office Hours 2"
    Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtHours2
    '
    Me.TxtHours2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtHours2.Location = New System.Drawing.Point(160, 286)
    Me.TxtHours2.MaxLength = 60
    Me.TxtHours2.Multiline = True
    Me.TxtHours2.Name = "TxtHours2"
    Me.TxtHours2.Size = New System.Drawing.Size(250, 32)
    Me.TxtHours2.TabIndex = 9
    '
    'Label11
    '
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.Location = New System.Drawing.Point(36, 328)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(120, 20)
    Me.Label11.TabIndex = 29
    Me.Label11.Text = "Assessor Phone"
    Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtAPhone
    '
    Me.TxtAPhone.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAPhone.Location = New System.Drawing.Point(160, 328)
    Me.TxtAPhone.MaxLength = 15
    Me.TxtAPhone.Name = "TxtAPhone"
    Me.TxtAPhone.Size = New System.Drawing.Size(134, 22)
    Me.TxtAPhone.TabIndex = 10
    '
    'Label12
    '
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(36, 353)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(120, 20)
    Me.Label12.TabIndex = 31
    Me.Label12.Text = "Collector Phone"
    Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtCPhone
    '
    Me.TxtCPhone.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCPhone.Location = New System.Drawing.Point(160, 354)
    Me.TxtCPhone.MaxLength = 15
    Me.TxtCPhone.Name = "TxtCPhone"
    Me.TxtCPhone.Size = New System.Drawing.Size(134, 22)
    Me.TxtCPhone.TabIndex = 11
    '
    'GrpScan
    '
    Me.GrpScan.Controls.Add(Me.RbScanSewer)
    Me.GrpScan.Controls.Add(Me.RbScanWebster)
    Me.GrpScan.Controls.Add(Me.RbScanDefault)
    Me.GrpScan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpScan.Location = New System.Drawing.Point(12, 389)
    Me.GrpScan.Name = "GrpScan"
    Me.GrpScan.Size = New System.Drawing.Size(255, 51)
    Me.GrpScan.TabIndex = 33
    Me.GrpScan.TabStop = False
    Me.GrpScan.Text = "OCR Scanline Format"
    '
    'RbScanWebster
    '
    Me.RbScanWebster.AutoSize = True
    Me.RbScanWebster.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbScanWebster.Location = New System.Drawing.Point(94, 19)
    Me.RbScanWebster.Name = "RbScanWebster"
    Me.RbScanWebster.Size = New System.Drawing.Size(65, 17)
    Me.RbScanWebster.TabIndex = 34
    Me.RbScanWebster.Text = "Webster"
    Me.RbScanWebster.UseVisualStyleBackColor = True
    '
    'RbScanDefault
    '
    Me.RbScanDefault.AutoSize = True
    Me.RbScanDefault.Checked = True
    Me.RbScanDefault.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbScanDefault.Location = New System.Drawing.Point(6, 19)
    Me.RbScanDefault.Name = "RbScanDefault"
    Me.RbScanDefault.Size = New System.Drawing.Size(59, 17)
    Me.RbScanDefault.TabIndex = 33
    Me.RbScanDefault.TabStop = True
    Me.RbScanDefault.Text = "Default"
    Me.RbScanDefault.UseVisualStyleBackColor = True
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbModWeight7)
    Me.GroupBox1.Controls.Add(Me.RbModEven)
    Me.GroupBox1.Controls.Add(Me.RbModOdd)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(322, 389)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(321, 51)
    Me.GroupBox1.TabIndex = 34
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "OCR Check Digit - Modulus 10 Calc Method"
    '
    'RbModWeight7
    '
    Me.RbModWeight7.AutoSize = True
    Me.RbModWeight7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbModWeight7.Location = New System.Drawing.Point(229, 19)
    Me.RbModWeight7.Name = "RbModWeight7"
    Me.RbModWeight7.Size = New System.Drawing.Size(86, 17)
    Me.RbModWeight7.TabIndex = 35
    Me.RbModWeight7.Text = "Weight 7,3,1"
    Me.RbModWeight7.UseVisualStyleBackColor = True
    '
    'RbModEven
    '
    Me.RbModEven.AutoSize = True
    Me.RbModEven.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbModEven.Location = New System.Drawing.Point(109, 19)
    Me.RbModEven.Name = "RbModEven"
    Me.RbModEven.Size = New System.Drawing.Size(87, 17)
    Me.RbModEven.TabIndex = 34
    Me.RbModEven.Text = "Double Even"
    Me.RbModEven.UseVisualStyleBackColor = True
    '
    'RbModOdd
    '
    Me.RbModOdd.AutoSize = True
    Me.RbModOdd.Checked = True
    Me.RbModOdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbModOdd.Location = New System.Drawing.Point(6, 19)
    Me.RbModOdd.Name = "RbModOdd"
    Me.RbModOdd.Size = New System.Drawing.Size(82, 17)
    Me.RbModOdd.TabIndex = 33
    Me.RbModOdd.TabStop = True
    Me.RbModOdd.Text = "Double Odd"
    Me.RbModOdd.UseVisualStyleBackColor = True
    '
    'RbScanSewer
    '
    Me.RbScanSewer.AutoSize = True
    Me.RbScanSewer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbScanSewer.Location = New System.Drawing.Point(184, 19)
    Me.RbScanSewer.Name = "RbScanSewer"
    Me.RbScanSewer.Size = New System.Drawing.Size(55, 17)
    Me.RbScanSewer.TabIndex = 35
    Me.RbScanSewer.Text = "Sewer"
    Me.RbScanSewer.UseVisualStyleBackColor = True
    '
    'FrmTX112C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(666, 454)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.GrpScan)
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.TxtCPhone)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.TxtAPhone)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.TxtHours2)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtPayTo)
    Me.Controls.Add(Me.TxtHours1)
    Me.Controls.Add(Me.TxtTitle)
    Me.Controls.Add(Me.TxtLine5)
    Me.Controls.Add(Me.TxtLine4)
    Me.Controls.Add(Me.TxtLine3)
    Me.Controls.Add(Me.TxtLine2)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtLine1)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Txttype)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX112C"
    Me.Text = "Maintain Bill Information"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpScan.ResumeLayout(False)
    Me.GrpScan.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

  Private Sub FrmTX112C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myTXFMBILL = New TXFMBILL.mydata(MyDBConnect)
  MyFrmTX112.TBarNew.Enabled = False
  MyFrmTX112.TBarSave.Enabled = True
  If Not WrkAddMode Then
    MyFrmTX112.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(Txttype)
  Else
    Exit Sub
  End If
  MyFrmTX112.TBarPrint.Enabled = False

  myTXFMBILL.GetOneRecordP(Wrktype)
  Txttype.Text = Wrktype
  If myTXFMBILL.RecordNotFound Then Exit Sub

  With myTXFMBILL
    TxtPayTo.Text = Trim(._PAYTO)
    TxtLine1.Text = Trim(._LINE1)
    TxtLine2.Text = Trim(._LINE2)
    TxtLine3.Text = Trim(._LINE3)
    TxtLine4.Text = Trim(._LINE4)
    TxtLine5.Text = Trim(._LINE5)
    TxtTitle.Text = Trim(._TITLE)
    TxtHours1.Text = Trim(._HOURS1)
    TxtHours2.Text = Trim(._HOURS2)
    TxtAPhone.Text = Trim(._APHONE)
    TxtCPhone.Text = Trim(._CPHONE)
    Select Case Trim(._SCAN)
    Case "S"
      RbScanSewer.Checked = True
    Case "W"
      RbScanWebster.Checked = True
    Case Else
      RbScanDefault.Checked = True
    End Select
    Select Case Trim(._MOD10)
    Case "E"
      RbModEven.Checked = True
    Case "O"
      RbModOdd.Checked = True
    Case "7"
      RbModWeight7.Checked = True
    End Select
  End With
 End Sub

Private Sub FrmTX112C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX112.SbpScreen.Text = "TX112C"
  MyUtils.CenterForm(Me.ParentForm, Me)
    If Wrktype <> "" Then
    End If
End Sub

Private Sub FrmTX112C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTX112.TBarNew.Enabled = True
  MyFrmTX112.TBarDelete.Enabled = False
  MyFrmTX112.TBarSave.Enabled = False
  MyFrmTX112.TBarPrint.Enabled = False
  MyFrmTX112B.FormatGrid()
  MyFrmTX112B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
  myTXFMBILL.DeleteOneRecordP()
  Me.Close()
End Sub

Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  myTXFMBILL.GetOneRecordP(Txttype.Text)
  If WrkAddMode Then
    If Not myTXFMBILL.RecordNotFound Then
      Me.ErrProv.SetError(Txttype, "Record already exists")
      Exit Sub
    End If
  End If
  If Not WrkAddMode Then
    MovetoFile()
    If IsNothing(ErrorMsg(0)) Then
      myTXFMBILL.UpdateOneRecordP()
      Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  Else
    myTXFMBILL._TYPE = Txttype.Text
    MovetoFile()
    If IsNothing(ErrorMsg(0)) Then
      myTXFMBILL.AddOneRecordP()
      Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myTXFMBILL
    ._PAYTO = TxtPayTo.Text
    ._LINE1 = TxtLine1.Text
    ._LINE2 = TxtLine2.Text
    ._LINE3 = TxtLine3.Text
    ._LINE4 = TxtLine4.Text
    ._LINE5 = TxtLine5.Text
    ._TITLE = TxtTitle.Text
    ._HOURS1 = TxtHours1.Text
    ._HOURS2 = TxtHours2.Text
    ._APHONE = TxtAPhone.Text
    ._CPHONE = TxtCPhone.Text
    If RbScanDefault.Checked Then ._SCAN = String.Empty
    If RbScanSewer.Checked Then ._SCAN = "S"
    If RbScanWebster.Checked Then ._SCAN = "W"
    If RbModOdd.Checked Then ._MOD10 = "O"
    If RbModEven.Checked Then ._MOD10 = "E"
    If RbModWeight7.Checked Then ._MOD10 = "7"
 End With
 End Sub

 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(Txttype, "")
  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
      Case "type"
      ErrProv.SetError(Txttype, ErrorMsg(I))
    Case Nothing
      Exit Sub
    End Select
  Next I
End Sub
End Class






