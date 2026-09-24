Public Class FrmTXA09Ben
  Inherits System.Windows.Forms.Form
	Dim myTXINV As TXINV.myData
	Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkType As String
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents LblLocAmt As System.Windows.Forms.Label
  Friend WithEvents LblProgram As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents LblName As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents LblType As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents LblYear As System.Windows.Forms.Label
  Friend WithEvents LblList As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents LblStBenefit As System.Windows.Forms.Label

  Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox

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
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.GroupBox5 = New System.Windows.Forms.GroupBox
Me.LblStBenefit = New System.Windows.Forms.Label
Me.Label6 = New System.Windows.Forms.Label
Me.LblProgram = New System.Windows.Forms.Label
Me.Label12 = New System.Windows.Forms.Label
Me.LblLocAmt = New System.Windows.Forms.Label
Me.LblName = New System.Windows.Forms.Label
Me.Label7 = New System.Windows.Forms.Label
Me.LblType = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
Me.LblYear = New System.Windows.Forms.Label
Me.LblList = New System.Windows.Forms.Label
Me.Label5 = New System.Windows.Forms.Label
Me.Label8 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox5.SuspendLayout()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'GroupBox5
'
Me.GroupBox5.Controls.Add(Me.LblStBenefit)
Me.GroupBox5.Controls.Add(Me.Label6)
Me.GroupBox5.Controls.Add(Me.LblProgram)
Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox5.ForeColor = System.Drawing.Color.Blue
Me.GroupBox5.Location = New System.Drawing.Point(15, 51)
Me.GroupBox5.Name = "GroupBox5"
Me.GroupBox5.Size = New System.Drawing.Size(137, 61)
Me.GroupBox5.TabIndex = 142
Me.GroupBox5.TabStop = False
Me.GroupBox5.Text = "Heart/Frozen Program"
'
'LblStBenefit
'
Me.LblStBenefit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblStBenefit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LblStBenefit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblStBenefit.ForeColor = System.Drawing.Color.Black
Me.LblStBenefit.Location = New System.Drawing.Point(60, 34)
Me.LblStBenefit.Name = "LblStBenefit"
Me.LblStBenefit.Size = New System.Drawing.Size(64, 16)
Me.LblStBenefit.TabIndex = 173
Me.LblStBenefit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label6
'
Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label6.ForeColor = System.Drawing.Color.Black
Me.Label6.Location = New System.Drawing.Point(6, 36)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(48, 17)
Me.Label6.TabIndex = 172
Me.Label6.Text = "Benefit"
'
'LblProgram
'
Me.LblProgram.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblProgram.ForeColor = System.Drawing.Color.Black
Me.LblProgram.Location = New System.Drawing.Point(25, 16)
Me.LblProgram.Name = "LblProgram"
Me.LblProgram.Size = New System.Drawing.Size(91, 18)
Me.LblProgram.TabIndex = 169
Me.LblProgram.Text = "(program)"
Me.LblProgram.TextAlign = System.Drawing.ContentAlignment.TopCenter
'
'Label12
'
Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label12.Location = New System.Drawing.Point(12, 131)
Me.Label12.Name = "Label12"
Me.Label12.Size = New System.Drawing.Size(78, 16)
Me.Label12.TabIndex = 162
Me.Label12.Text = "Local Benefit"
'
'LblLocAmt
'
Me.LblLocAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblLocAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LblLocAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblLocAmt.Location = New System.Drawing.Point(96, 129)
Me.LblLocAmt.Name = "LblLocAmt"
Me.LblLocAmt.Size = New System.Drawing.Size(64, 16)
Me.LblLocAmt.TabIndex = 161
Me.LblLocAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'LblName
'
Me.LblName.BackColor = System.Drawing.SystemColors.Control
Me.LblName.Location = New System.Drawing.Point(104, 23)
Me.LblName.Name = "LblName"
Me.LblName.Size = New System.Drawing.Size(216, 16)
Me.LblName.TabIndex = 170
'
'Label7
'
Me.Label7.BackColor = System.Drawing.SystemColors.Control
Me.Label7.Location = New System.Drawing.Point(120, 3)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(32, 13)
Me.Label7.TabIndex = 169
Me.Label7.Text = "Type"
'
'LblType
'
Me.LblType.BackColor = System.Drawing.SystemColors.Control
Me.LblType.Location = New System.Drawing.Point(156, 3)
Me.LblType.Name = "LblType"
Me.LblType.Size = New System.Drawing.Size(16, 16)
Me.LblType.TabIndex = 168
'
'Label3
'
Me.Label3.BackColor = System.Drawing.SystemColors.Control
Me.Label3.Location = New System.Drawing.Point(180, 3)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(32, 12)
Me.Label3.TabIndex = 167
Me.Label3.Text = "Year"
'
'LblYear
'
Me.LblYear.BackColor = System.Drawing.SystemColors.Control
Me.LblYear.Location = New System.Drawing.Point(212, 3)
Me.LblYear.Name = "LblYear"
Me.LblYear.Size = New System.Drawing.Size(48, 16)
Me.LblYear.TabIndex = 166
'
'LblList
'
Me.LblList.BackColor = System.Drawing.SystemColors.Control
Me.LblList.Location = New System.Drawing.Point(57, 3)
Me.LblList.Name = "LblList"
Me.LblList.Size = New System.Drawing.Size(48, 16)
Me.LblList.TabIndex = 165
'
'Label5
'
Me.Label5.BackColor = System.Drawing.SystemColors.Control
Me.Label5.Location = New System.Drawing.Point(12, 23)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(84, 12)
Me.Label5.TabIndex = 164
Me.Label5.Text = "Name of Owner"
'
'Label8
'
Me.Label8.BackColor = System.Drawing.SystemColors.Control
Me.Label8.Location = New System.Drawing.Point(12, 3)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(36, 12)
Me.Label8.TabIndex = 163
Me.Label8.Text = "List #"
'
'FrmTXA09Ben
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(335, 155)
Me.Controls.Add(Me.LblName)
Me.Controls.Add(Me.Label7)
Me.Controls.Add(Me.LblType)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.LblYear)
Me.Controls.Add(Me.LblList)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.Label8)
Me.Controls.Add(Me.Label12)
Me.Controls.Add(Me.LblLocAmt)
Me.Controls.Add(Me.GroupBox5)
Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTXA09Ben"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
Me.Text = "Benefits/Elderly Information"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox5.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

  Private Sub FrmTXA09Ben_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkFrozenCode As String

		myTXINV = New TXINV.mydata(MyDBConnect)

    LblList.Text = WrkListNo
    LblYear.Text = WrkYear
    LblType.Text = WrkType
    LblName.Text = MyFrmTXA09B.LblName.Text

		myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
		With myTXINV
      LblLocAmt.Text = MyUtils.FmtCurrency(._TWNBN)
				WrkFrozenCode = Trim(._FRCD)
				Select Case WrkFrozenCode
				Case Is = "F"
					LblProgram.Text = "Frozen"
				Case Is = "C"
					LblProgram.Text = "Heart"
				Case Else
					LblProgram.Text = String.Empty
				End Select
				LblStBenefit.Text = ._FTAX
				LblLocAmt.Text = ._TWNBN
			End With
 End Sub

  Private Sub FrmTXA09Ben_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
'    MyFrmTXA09B.TBarSave.Enabled = False
		myTXINV.CloseFile()
		myTXINV = Nothing
    MyFrmTXA09B.Show()

  End Sub
  Private Sub FrmTXA09Ben_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA09.SbpScreen.Text = "TXA09Ben"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
 End Class






