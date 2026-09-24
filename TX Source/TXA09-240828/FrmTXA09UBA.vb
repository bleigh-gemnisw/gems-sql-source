Public Class FrmTXA09UBA
	Inherits System.Windows.Forms.Form
	Friend WrkListNo As Integer
	Friend WrkYear As Integer
	Friend WrkType As String
	Friend WithEvents LblName As System.Windows.Forms.Label
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents LblType As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents LblYear As System.Windows.Forms.Label
	Friend WithEvents LblList As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
 Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
 Friend WithEvents Label1 As System.Windows.Forms.Label
 Friend WithEvents LblDeferred As System.Windows.Forms.Label
 Friend WithEvents Label12 As System.Windows.Forms.Label
 Friend WithEvents LblAssmntLeft As System.Windows.Forms.Label
 Friend WithEvents Label4 As System.Windows.Forms.Label
 Friend WithEvents LblCaveat As System.Windows.Forms.Label
 Friend WithEvents Label8 As System.Windows.Forms.Label
Dim MyUTCUST As UTCUST.myData
Dim MyUTCUSTAS As UTCUSTAS.myData
Dim MyUTCUSTRT As UTCUSTRT.myData
Dim MyUTCNTL As UTCNTL.myData
Dim MyUBCalcBillA As UBCalcBill.BillAssessment
Dim WrkOrigAssmnt As Decimal
Dim WrkAssmntLeft As Decimal
Dim WrkDeferred As Decimal
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents LblOrigAssmnt As System.Windows.Forms.Label
Dim WrkCaveat As Decimal


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
Me.LblName = New System.Windows.Forms.Label
Me.Label7 = New System.Windows.Forms.Label
Me.LblType = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
Me.LblYear = New System.Windows.Forms.Label
Me.LblList = New System.Windows.Forms.Label
Me.Label5 = New System.Windows.Forms.Label
Me.Label8 = New System.Windows.Forms.Label
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.Label4 = New System.Windows.Forms.Label
Me.LblCaveat = New System.Windows.Forms.Label
Me.Label1 = New System.Windows.Forms.Label
Me.LblDeferred = New System.Windows.Forms.Label
Me.Label12 = New System.Windows.Forms.Label
Me.LblAssmntLeft = New System.Windows.Forms.Label
Me.Label2 = New System.Windows.Forms.Label
Me.LblOrigAssmnt = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox1.SuspendLayout()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'LblName
'
Me.LblName.BackColor = System.Drawing.SystemColors.Control
Me.LblName.Location = New System.Drawing.Point(102, 23)
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
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.Label4)
Me.GroupBox1.Controls.Add(Me.LblCaveat)
Me.GroupBox1.Controls.Add(Me.Label1)
Me.GroupBox1.Controls.Add(Me.LblDeferred)
Me.GroupBox1.Controls.Add(Me.Label12)
Me.GroupBox1.Controls.Add(Me.LblAssmntLeft)
Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox1.Location = New System.Drawing.Point(16, 86)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(207, 103)
Me.GroupBox1.TabIndex = 171
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "Unbilled amounts"
'
'Label4
'
Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label4.Location = New System.Drawing.Point(6, 75)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(93, 15)
Me.Label4.TabIndex = 168
Me.Label4.Text = "Caveat Lien"
'
'LblCaveat
'
Me.LblCaveat.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblCaveat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LblCaveat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblCaveat.Location = New System.Drawing.Point(117, 73)
Me.LblCaveat.Name = "LblCaveat"
Me.LblCaveat.Size = New System.Drawing.Size(79, 17)
Me.LblCaveat.TabIndex = 167
Me.LblCaveat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label1
'
Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label1.Location = New System.Drawing.Point(6, 49)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(93, 15)
Me.Label1.TabIndex = 166
Me.Label1.Text = "Deferred"
'
'LblDeferred
'
Me.LblDeferred.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblDeferred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LblDeferred.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblDeferred.Location = New System.Drawing.Point(117, 47)
Me.LblDeferred.Name = "LblDeferred"
Me.LblDeferred.Size = New System.Drawing.Size(79, 16)
Me.LblDeferred.TabIndex = 165
Me.LblDeferred.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label12
'
Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label12.Location = New System.Drawing.Point(6, 25)
Me.Label12.Name = "Label12"
Me.Label12.Size = New System.Drawing.Size(93, 15)
Me.Label12.TabIndex = 164
Me.Label12.Text = "Assessment Left"
'
'LblAssmntLeft
'
Me.LblAssmntLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblAssmntLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LblAssmntLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblAssmntLeft.Location = New System.Drawing.Point(117, 24)
Me.LblAssmntLeft.Name = "LblAssmntLeft"
Me.LblAssmntLeft.Size = New System.Drawing.Size(79, 16)
Me.LblAssmntLeft.TabIndex = 163
Me.LblAssmntLeft.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label2
'
Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label2.Location = New System.Drawing.Point(12, 50)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(115, 14)
Me.Label2.TabIndex = 173
Me.Label2.Text = "Original Assessment"
'
'LblOrigAssmnt
'
Me.LblOrigAssmnt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblOrigAssmnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LblOrigAssmnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblOrigAssmnt.Location = New System.Drawing.Point(133, 48)
Me.LblOrigAssmnt.Name = "LblOrigAssmnt"
Me.LblOrigAssmnt.Size = New System.Drawing.Size(79, 16)
Me.LblOrigAssmnt.TabIndex = 172
Me.LblOrigAssmnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'FrmTXA09UBA
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(335, 201)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.LblOrigAssmnt)
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.LblName)
Me.Controls.Add(Me.Label7)
Me.Controls.Add(Me.LblType)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.LblYear)
Me.Controls.Add(Me.LblList)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.Label8)
Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTXA09UBA"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
Me.Text = "Utility Billing Assessment Information"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox1.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmTXA09UBA_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
	MyUTCUST.CloseFile()
	MyUTCUSTAS.CloseFile()
	MyUTCUSTRT.CloseFile()
	MyUTCNTL.CloseFile()
	MyUTCUST = Nothing
	MyUTCUSTAS = Nothing
	MyUTCUSTRT = Nothing
	MyUTCNTL = Nothing
	MyUBCalcBillA = Nothing
End Sub
	Private Sub FrmTXA09UBA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

		MyUTCUST = New UTCUST.mydata(MyDBConnect)
		MyUTCUSTAS = New UTCUSTAS.mydata(MyDBConnect)
		MyUTCUSTRT = New UTCUSTRT.mydata(MyDBConnect)
		MyUTCNTL = New UTCNTL.mydata(MyDBConnect)
    MyUBCalcBillA = New UBCalcBill.BillAssessment(myDBConnect)
    LblList.Text = WrkListNo
		LblYear.Text = WrkYear
		LblType.Text = WrkType
		LblName.Text = MyFrmTXA09B.LblName.Text
		CalcAssmnt()
    LblOrigAssmnt.Text = MyUtils.FmtCurrency(WrkOrigAssmnt)
    LblAssmntLeft.Text = MyUtils.FmtCurrency(WrkAssmntLeft)
    LblDeferred.Text = MyUtils.FmtCurrency(WrkDeferred)
    WrkCaveat = 0
    MyUTCNTL.GetOneRecordP(1)
    If Not MyUTCNTL.RecordNotFound Then
      WrkCaveat = MyUTCNTL._UBCAV
    End If
    If WrkAssmntLeft > 0 Then
      LblCaveat.Text = MyUtils.FmtCurrency(WrkCaveat)
    Else
      LblCaveat.Text = MyUtils.FmtCurrency(0)
    End If
 End Sub

	Private Sub FrmTXA09UTA_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		MyFrmTXA09B.Show()

	End Sub
	Private Sub FrmTXA09UTA_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
		MyFrmTXA09.SbpScreen.Text = "TXA09UBA"
    MyUtils.CenterForm(Me.ParentForm, Me)
	End Sub
	Private Sub CalcAssmnt()
		Dim WrkCode As String
		WrkOrigAssmnt = 0
		WrkAssmntLeft = 0

		MyUTCUST.GetOneRecordP(WrkListNo)
		If MyUTCUST.RecordNotFound Then Exit Sub

		MyUTCUSTAS.GetOneRecordP(WrkListNo, WrkType)
		If myUTCUSTAS.RecordNotFound Then Exit Sub

		WrkCode = GetRateCode(WrkType)

		With MyUBCalcBillA
			.In_RateType = WrkType
			.In_RateCode = WrkCode
			.In_DwellUnits = MyUTCUST._CUAUNT
			.In_PropVal = MyUTCUST._CUPVAL
			.In_Footage = MyUTCUST._CUFOOT
			.In_Acreage = MyUTCUST._CUACRE
			.In_LateralFee = MyUTCUSTAS._CALAT
			.In_UniformFee = MyUTCUSTAS._CAUNIF
			.In_AssmntAdjust = MyUTCUSTAS._CAADJ
			.In_DeferredAmt = MyUTCUSTAS._CADEF
			.In_PrevBilled = MyUTCUSTAS._CAAMT
			.CalcAssessment()
			WrkOrigAssmnt = .Out_OrigBill
			WrkAssmntLeft = .Out_AmtLeft
			WrkDeferred = MyUTCUSTAS._CADEF
		End With
	End Sub
	Private Function GetRateCode(ByVal WrkUBType As String) As String

	GetRateCode = ""
	myUTCUSTRT.GetOneRecordP(WrkListNo, WrkUBType)
	If myUTCUSTRT.RecordNotFound Then Exit Function

	With myUTCUSTRT
		GetRateCode = ._CRCODE
	End With
End Function
 End Class






