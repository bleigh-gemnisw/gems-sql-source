Public Class FrmUB102US
  Inherits System.Windows.Forms.Form
	Dim myUTCUST As UTCUST.myData
	Dim myUTCUSTRT As UTCUSTRT.myData
  Dim myLOGUTUS As LOGUTUS.myData
  Dim dsLog As DataSet = New DataSet
  Dim LoadScrn As Boolean
  Dim StrDebug As String

  Friend WrkListNo As Integer
  Friend WrkFamily As String
  Friend WrkUBType As String
  Friend WrkDesc As String
  Friend WithEvents TxtEDU As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Dim AddMode As Boolean

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
Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
Friend WithEvents LblName As System.Windows.Forms.Label
Friend WithEvents LblListNo As System.Windows.Forms.Label
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents LblBillAmt As System.Windows.Forms.Label
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TxtSewerSurChg As System.Windows.Forms.TextBox
Friend WithEvents Label45 As System.Windows.Forms.Label
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents TxtWaterFixt As System.Windows.Forms.TextBox
Friend WithEvents Label39 As System.Windows.Forms.Label
Friend WithEvents TxtSewerFixt As System.Windows.Forms.TextBox
Friend WithEvents Label35 As System.Windows.Forms.Label
Friend WithEvents TxtExtras As System.Windows.Forms.TextBox
Friend WithEvents Label34 As System.Windows.Forms.Label
Friend WithEvents TxtUnits As System.Windows.Forms.TextBox
Friend WithEvents Label33 As System.Windows.Forms.Label
Friend WithEvents TxtUPermitNo As System.Windows.Forms.TextBox
Friend WithEvents Label32 As System.Windows.Forms.Label
Friend WithEvents LnkCode As System.Windows.Forms.LinkLabel
Friend WithEvents TxtCode As System.Windows.Forms.TextBox
Friend WithEvents LblDesc As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.GroupBox4 = New System.Windows.Forms.GroupBox
Me.LblBillAmt = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
Me.LnkCode = New System.Windows.Forms.LinkLabel
Me.TxtCode = New System.Windows.Forms.TextBox
Me.LblName = New System.Windows.Forms.Label
Me.LblListNo = New System.Windows.Forms.Label
Me.Label1 = New System.Windows.Forms.Label
Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TxtSewerSurChg = New System.Windows.Forms.TextBox
Me.Label45 = New System.Windows.Forms.Label
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.TxtWaterFixt = New System.Windows.Forms.TextBox
Me.Label39 = New System.Windows.Forms.Label
Me.TxtSewerFixt = New System.Windows.Forms.TextBox
Me.Label35 = New System.Windows.Forms.Label
Me.TxtExtras = New System.Windows.Forms.TextBox
Me.Label34 = New System.Windows.Forms.Label
Me.TxtUnits = New System.Windows.Forms.TextBox
Me.Label33 = New System.Windows.Forms.Label
Me.TxtUPermitNo = New System.Windows.Forms.TextBox
Me.Label32 = New System.Windows.Forms.Label
Me.LblDesc = New System.Windows.Forms.Label
Me.TxtEDU = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.GroupBox4.SuspendLayout()
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox1.SuspendLayout()
Me.SuspendLayout()
'
'GroupBox4
'
Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
Me.GroupBox4.Controls.Add(Me.LblBillAmt)
Me.GroupBox4.Controls.Add(Me.Label3)
Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox4.ForeColor = System.Drawing.Color.Black
Me.GroupBox4.Location = New System.Drawing.Point(488, 8)
Me.GroupBox4.Name = "GroupBox4"
Me.GroupBox4.Size = New System.Drawing.Size(192, 48)
Me.GroupBox4.TabIndex = 316
Me.GroupBox4.TabStop = False
Me.GroupBox4.Text = "Bill Calcs"
'
'LblBillAmt
'
Me.LblBillAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblBillAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LblBillAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblBillAmt.Location = New System.Drawing.Point(96, 24)
Me.LblBillAmt.Name = "LblBillAmt"
Me.LblBillAmt.Size = New System.Drawing.Size(88, 16)
Me.LblBillAmt.TabIndex = 29
Me.LblBillAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label3
'
Me.Label3.BackColor = System.Drawing.SystemColors.Control
Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label3.Location = New System.Drawing.Point(8, 24)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(88, 16)
Me.Label3.TabIndex = 28
Me.Label3.Text = "Bill Amt"
'
'LnkCode
'
Me.LnkCode.Location = New System.Drawing.Point(8, 64)
Me.LnkCode.Name = "LnkCode"
Me.LnkCode.Size = New System.Drawing.Size(72, 16)
Me.LnkCode.TabIndex = 304
Me.LnkCode.TabStop = True
Me.LnkCode.Text = "Usage Code"
'
'TxtCode
'
Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtCode.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtCode.Location = New System.Drawing.Point(112, 64)
Me.TxtCode.MaxLength = 3
Me.TxtCode.Name = "TxtCode"
Me.TxtCode.Size = New System.Drawing.Size(32, 22)
Me.TxtCode.TabIndex = 0
'
'LblName
'
Me.LblName.Location = New System.Drawing.Point(128, 8)
Me.LblName.Name = "LblName"
Me.LblName.Size = New System.Drawing.Size(272, 16)
Me.LblName.TabIndex = 322
Me.LblName.UseMnemonic = False
'
'LblListNo
'
Me.LblListNo.Location = New System.Drawing.Point(72, 8)
Me.LblListNo.Name = "LblListNo"
Me.LblListNo.Size = New System.Drawing.Size(48, 16)
Me.LblListNo.TabIndex = 321
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 8)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(56, 16)
Me.Label1.TabIndex = 320
Me.Label1.Text = "Account #"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'TxtSewerSurChg
'
Me.TxtSewerSurChg.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtSewerSurChg.Location = New System.Drawing.Point(112, 195)
Me.TxtSewerSurChg.MaxLength = 5
Me.TxtSewerSurChg.Name = "TxtSewerSurChg"
Me.TxtSewerSurChg.Size = New System.Drawing.Size(48, 22)
Me.TxtSewerSurChg.TabIndex = 5
Me.TxtSewerSurChg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label45
'
Me.Label45.Location = New System.Drawing.Point(8, 201)
Me.Label45.Name = "Label45"
Me.Label45.Size = New System.Drawing.Size(104, 16)
Me.Label45.TabIndex = 331
Me.Label45.Text = "Sewer Sur Charge"
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.TxtWaterFixt)
Me.GroupBox1.Controls.Add(Me.Label39)
Me.GroupBox1.Controls.Add(Me.TxtSewerFixt)
Me.GroupBox1.Controls.Add(Me.Label35)
Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox1.Location = New System.Drawing.Point(216, 88)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(104, 72)
Me.GroupBox1.TabIndex = 6
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "Fixtures"
'
'TxtWaterFixt
'
Me.TxtWaterFixt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtWaterFixt.Location = New System.Drawing.Point(56, 48)
Me.TxtWaterFixt.MaxLength = 4
Me.TxtWaterFixt.Name = "TxtWaterFixt"
Me.TxtWaterFixt.Size = New System.Drawing.Size(40, 22)
Me.TxtWaterFixt.TabIndex = 1
Me.TxtWaterFixt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label39
'
Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label39.Location = New System.Drawing.Point(10, 52)
Me.Label39.Name = "Label39"
Me.Label39.Size = New System.Drawing.Size(40, 16)
Me.Label39.TabIndex = 250
Me.Label39.Text = "Water"
'
'TxtSewerFixt
'
Me.TxtSewerFixt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtSewerFixt.Location = New System.Drawing.Point(56, 24)
Me.TxtSewerFixt.MaxLength = 4
Me.TxtSewerFixt.Name = "TxtSewerFixt"
Me.TxtSewerFixt.Size = New System.Drawing.Size(40, 22)
Me.TxtSewerFixt.TabIndex = 0
Me.TxtSewerFixt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label35
'
Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label35.Location = New System.Drawing.Point(10, 28)
Me.Label35.Name = "Label35"
Me.Label35.Size = New System.Drawing.Size(40, 16)
Me.Label35.TabIndex = 248
Me.Label35.Text = "Sewer"
'
'TxtExtras
'
Me.TxtExtras.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtExtras.Location = New System.Drawing.Point(112, 171)
Me.TxtExtras.MaxLength = 2
Me.TxtExtras.Name = "TxtExtras"
Me.TxtExtras.Size = New System.Drawing.Size(24, 22)
Me.TxtExtras.TabIndex = 4
Me.TxtExtras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label34
'
Me.Label34.Location = New System.Drawing.Point(8, 148)
Me.Label34.Name = "Label34"
Me.Label34.Size = New System.Drawing.Size(40, 16)
Me.Label34.TabIndex = 329
Me.Label34.Text = "EDUs"
'
'TxtUnits
'
Me.TxtUnits.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtUnits.Location = New System.Drawing.Point(112, 120)
Me.TxtUnits.MaxLength = 8
Me.TxtUnits.Name = "TxtUnits"
Me.TxtUnits.Size = New System.Drawing.Size(74, 22)
Me.TxtUnits.TabIndex = 2
Me.TxtUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label33
'
Me.Label33.Location = New System.Drawing.Point(8, 124)
Me.Label33.Name = "Label33"
Me.Label33.Size = New System.Drawing.Size(48, 16)
Me.Label33.TabIndex = 328
Me.Label33.Text = "Units"
'
'TxtUPermitNo
'
Me.TxtUPermitNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtUPermitNo.Location = New System.Drawing.Point(112, 96)
Me.TxtUPermitNo.MaxLength = 10
Me.TxtUPermitNo.Name = "TxtUPermitNo"
Me.TxtUPermitNo.Size = New System.Drawing.Size(88, 22)
Me.TxtUPermitNo.TabIndex = 1
'
'Label32
'
Me.Label32.Location = New System.Drawing.Point(8, 100)
Me.Label32.Name = "Label32"
Me.Label32.Size = New System.Drawing.Size(48, 16)
Me.Label32.TabIndex = 327
Me.Label32.Text = "Permit #"
'
'LblDesc
'
Me.LblDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblDesc.Location = New System.Drawing.Point(8, 40)
Me.LblDesc.Name = "LblDesc"
Me.LblDesc.Size = New System.Drawing.Size(160, 16)
Me.LblDesc.TabIndex = 332
'
'TxtEDU
'
Me.TxtEDU.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtEDU.Location = New System.Drawing.Point(112, 144)
Me.TxtEDU.MaxLength = 4
Me.TxtEDU.Name = "TxtEDU"
Me.TxtEDU.Size = New System.Drawing.Size(32, 22)
Me.TxtEDU.TabIndex = 3
Me.TxtEDU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(8, 177)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(40, 16)
Me.Label2.TabIndex = 334
Me.Label2.Text = "Extras"
'
'FrmUB102US
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(688, 226)
Me.Controls.Add(Me.TxtEDU)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.LblDesc)
Me.Controls.Add(Me.TxtSewerSurChg)
Me.Controls.Add(Me.Label45)
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.TxtExtras)
Me.Controls.Add(Me.Label34)
Me.Controls.Add(Me.TxtUnits)
Me.Controls.Add(Me.Label33)
Me.Controls.Add(Me.TxtUPermitNo)
Me.Controls.Add(Me.Label32)
Me.Controls.Add(Me.LblName)
Me.Controls.Add(Me.LblListNo)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.GroupBox4)
Me.Controls.Add(Me.LnkCode)
Me.Controls.Add(Me.TxtCode)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmUB102US"
Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
Me.Text = "Maintain Customer - Usage Data"
Me.GroupBox4.ResumeLayout(False)
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox1.ResumeLayout(False)
Me.GroupBox1.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmUB102US_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	myUTCUST = New UTCUST.myData(myDBConnect)
	myUTCUSTRT = New UTCUSTRT.myData(myDBConnect)
  myLOGUTUS = New LOGUTUS.myData(myDBConnect)

  LoadScrn = True
  MyFrmUB102.TBarSave.Enabled = True
  MyFrmUB102.TBarDelete.Enabled = False

  LblListNo.Text = WrkListNo
  LblName.Text = MyFrmUB102C.TxtName.Text
  LblDesc.Text = WrkDesc

  'New record
  If s_chg = False And s_full = False Then  '#sec
    MyFrmUB102.TBarSave.Visible = False  '#sec
  End If  '#sec

  'change log
  MyFrmUB102.TBarLog.Enabled = False
  dsLog = myLOGUTUS.GetAllList(WrkListNo, WrkUBType)
  If dsLog.Tables(0).Rows.Count > 0 Then
    MyFrmUB102.TBarLog.Enabled = True
  End If

  myUTCUST.GetOneRecordP(WrkListNo)
	With myUTCUST
		TxtUPermitNo.Text = Trim(._CUUPMT)
    TxtUnits.Text = ._CUUNIT
    TxtEDU.Text = ._CUEDU
		TxtExtras.Text = ._CUXTRA
		TxtSewerSurChg.Text = ._CUSCHR
		TxtSewerFixt.Text = ._CUSFIX
		TxtWaterFixt.Text = ._CUWFIX
	End With

	TxtCode.Text = GetRateCode(WrkListNo, WrkUBType)
  AddMode = False
  If TxtCode.Text = "" Then
    AddMode = True
  End If

  SetUsageCodeTip()
  CalcUsage()

  LoadScrn = False
  End Sub
Private Sub LnkUsageCode_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode.LinkClicked
		MyFrmListRates = New FrmListRates
		MyFrmListRates.MdiParent = Me.ParentForm
		MyFrmListRates.WrkFamily = WrkFamily
		MyFrmListRates.WrkUBType = WrkUBType
		MyFrmListRates.WrkCode = TxtCode.Text
		MyFrmListRates.Show()
		Me.Hide()
End Sub
  Public Sub SaveData()
		Dim ErrorField(50) As String
    Dim ErrorMsg(50) As String

    SetUsageCodeTip()

		myUTCUST.GetOneRecordP(WrkListNo)
		If Not myUTCUST.RecordNotFound Then
      If Not AddMode And Not MyFrmUB102.TBarLog.Enabled Then
        MoveToLog("")
        myLOGUTUS.AddOneRecordP()
      End If
      MoveToFile()
			EditChecks(ErrorField, ErrorMsg)
			If IsNothing(ErrorMsg(0)) Then
				myUTCUST.UpdateOneRecordP()
        If myUTCUST.ErrMsg <> "" Then
          WriteErrorLog(myUTCUST.ErrMsg)
          Exit Sub
        End If
      Else
        ShowError(ErrorField, ErrorMsg)
				Exit Sub
			End If
		End If

		myUTCUSTRT.GetOneRecordP(WrkListNo, WrkUBType)
		If Not myUTCUSTRT.RecordNotFound Then
      If Trim(TxtCode.Text = "") Then
        MoveToLog("Delete")
        myUTCUSTRT.DeleteOneRecordP()
        myLOGUTUS.AddOneRecordP()
      Else
        MoveToFileRT(False)
        MoveToLog("Change")
        myUTCUSTRT.UpdateOneRecordP()
        myLOGUTUS.AddOneRecordP()
      End If
		Else
			MoveToFileRT(True)
      MoveToLog("Change")
      myUTCUSTRT.AddOneRecordP()
      If myUTCUSTRT.ErrMsg <> "" Then
        WriteErrorLog(myUTCUSTRT.ErrMsg)
        Exit Sub
      End If
      myLOGUTUS.AddOneRecordP()
    End If

		Me.Close()

  End Sub
   Private Sub MoveToFile()
			With myUTCUST
				._CUUPMT = TxtUPermitNo.Text
        ._CUUNIT = MyUtils.CnvSng(TxtUnits.Text)
        ._CUEDU = MyUtils.CnvSng(TxtEDU.Text)
        ._CUXTRA = MyUtils.CnvSng(TxtExtras.Text)
        ._CUSCHR = MyUtils.CnvSng(TxtSewerSurChg.Text)
        ._CUSFIX = MyUtils.CnvSng(TxtSewerFixt.Text)
        ._CUWFIX = MyUtils.CnvSng(TxtWaterFixt.Text)
      End With
   End Sub
   Private Sub MoveToFileRT(ByVal AddMode As Boolean)
      With myUTCUSTRT
        If AddMode Then
          ._CRACCT = WrkListNo
          ._CRTYPE = WrkUBType
        End If
        ._CRCODE = TxtCode.Text
      End With
   End Sub
  Private Sub MoveToLog(ByVal WrkMode As String)
CheckFile:
    With myLOGUTUS
      .GetOneRecordP(WrkListNo, WrkUBType, MyUtils.SetDBDate(DateTime.Today), Format(DateTime.Now, "HHmmss"))
      If .RecordNotFound Then
        ._CUACCT = myUTCUST._CUACCT
        ._CUEDU = myUTCUST._CUEDU
        ._CUSCHR = myUTCUST._CUSCHR
        ._CUSFIX = myUTCUST._CUSFIX
        ._CUTYPE = WrkUBType
        ._CUUNIT = myUTCUST._CUUNIT
        ._CUUPMT = myUTCUST._CUUPMT
        ._CUWFIX = myUTCUST._CUWFIX
        ._CUXTRA = myUTCUST._CUXTRA
        ._LOGDTE = MyUtils.SetDBDate(DateTime.Today)
        ._LOGTIM = Format(DateTime.Now, "HHmmss")
        Select Case WrkMode
          Case "Add"
            ._LOGCMT = "Record Added"
          Case "Change"
            ._LOGCMT = "Record Changed"
          Case "Delete"
            ._LOGCMT = "Record Deleted"
          Case Else
            ._LOGCMT = ""
        End Select
      Else
        Threading.Thread.Sleep(1000)
        GoTo CheckFile
      End If
    End With

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtCode, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Me.ForeColor = Color.DarkRed
      Select Case ErrorField(I)
      Case "code"
        ErrProv.SetError(TxtCode, ErrorMsg(I))
      Case Nothing
        Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim WrkTip As String
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If Trim(TxtCode.Text) <> "" Then
      WrkTip = Ttp1.GetToolTip(TxtCode)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "code"
        ErrorMsg(I) = "Invalid Usage Code"
        I = I + 1
      End If
    End If

  End Sub
  Private Sub CalcUsage()
    Dim MyUBCalcBill As UBCalcBill.BillUsage

    MyUBCalcBill = New UBCalcBill.BillUsage(myDBConnect)
    With MyUBCalcBill
      .In_RateType = WrkUBType
      .In_RateCode = TxtCode.Text
      If Trim(WrkUBType) = "U" Then
        .In_Fixtures = MyUtils.CnvSng(TxtSewerFixt.Text)
        .In_SurChg = MyUtils.CnvSng(TxtSewerSurChg.Text)
      Else
        .In_Fixtures = MyUtils.CnvSng(TxtWaterFixt.Text)
        .In_SurChg = 0
      End If
      .In_Units = MyUtils.CnvSng(TxtUnits.Text)
      If MyEDU1 Then
        .In_EDUs = "1"
      Else
        .In_EDUs = MyUtils.CnvSng(TxtEDU.Text)
      End If
      .In_Extras = MyUtils.CnvSng(TxtExtras.Text)
      .CalcUsage()
      LblBillAmt.Text = MyUtils.FmtCurrency(.Out_Bill)
      StrDebug = .Out_Debug
    End With

  End Sub
Private Sub SetUsageCodeTip()
    Dim WrkDesc As String

    If Not TxtCode.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetUTRateUSDesc(WrkUBType, TxtCode.Text)
    Ttp1.SetToolTip(TxtCode, WrkDesc)
End Sub
Private Sub FrmUB102US_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmUB102.TBarSave.Enabled = True
    MyFrmUB102.TBarDelete.Enabled = True
    MyFrmUB102.TBarLog.Enabled = False
    MyFrmUB102C.FormatGrid()
    MyFrmUB102C.Show()
    'Memory Cleanup
    myUTCUST = Nothing
    myUTCUSTRT = Nothing
    MyFrmUB102US = Nothing
End Sub
Private Sub FrmUB102US_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmLOG = New FrmLOG
  MyFrmLOG.WrkListNo = MyFrmUB102C.WrkListNo
  MyFrmLOG.ds = MyFrmUB102US.dsLog
  MyFrmLOG.WrkType = "U"

  MyFrmUB102.SbpScreen.Text = "UB102US"
  MyUtils.CenterForm(Me.ParentForm, Me)
  With MyFrmUB102
    .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
    .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
  End With
End Sub
Private Sub TxtCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCode.TextChanged
  CalcUsage()
End Sub
Private Sub TxtCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCode.Leave
  SetUsageCodeTip()
End Sub
Private Sub TxtUnits_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUnits.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtEDU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEDU.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtExtras_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtExtras.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtSewerSurChg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSewerSurChg.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtSewerFixt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSewerFixt.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtWaterFixt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtWaterFixt.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtUnits_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtUnits.TextChanged
  CalcUsage()
End Sub
Private Sub TxtEDU_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEDU.TextChanged
  CalcUsage()
End Sub
Private Sub TxtExtras_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExtras.TextChanged
  CalcUsage()
End Sub
Private Sub TxtSewerSurChg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSewerSurChg.TextChanged
  CalcUsage()
End Sub
Private Sub TxtSewerFixt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSewerFixt.TextChanged
  CalcUsage()
End Sub
Private Sub TxtWaterFixt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtWaterFixt.TextChanged
  CalcUsage()
End Sub
Private Sub GroupBox4_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox4.DoubleClick
  MsgBox(StrDebug)
End Sub

Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

End Sub
End Class
