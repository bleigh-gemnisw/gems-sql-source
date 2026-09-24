Public Class FrmUB102MT
  Inherits System.Windows.Forms.Form
  Dim myUTCUST As UTCUST.MyData
  Dim myUTCUSTRT As UTCUSTRT.MyData
  Dim myUTCUSTMT As UTCUSTMT.MyData
  Dim LoadScrn As Boolean
  Dim StrDebug As String

  Friend WrkListNo As Integer
  Friend WrkFamily As String
  Friend WrkUBType As String
  Friend WrkDesc As String
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents BtnRecalc As System.Windows.Forms.Button
  Friend WithEvents DtPckRead As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtEDU As TextBox
    Friend WithEvents TxtUnits As TextBox
    Friend AddMode As Boolean

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
  Friend WithEvents LblListNo As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents LblBillAmt As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents LnkCode As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtCode As System.Windows.Forms.TextBox
  Friend WithEvents TxtMeterSize As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents LblTotalUse As System.Windows.Forms.Label
  Friend WithEvents LblActualUse As System.Windows.Forms.Label
  Friend WithEvents LblDesc As System.Windows.Forms.Label
  Friend WithEvents LblName As System.Windows.Forms.Label
  Friend WithEvents LnkMeterSize As System.Windows.Forms.LinkLabel
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUB102MT))
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.LblTotalUse = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.LblActualUse = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.LblBillAmt = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.LnkCode = New System.Windows.Forms.LinkLabel()
    Me.TxtCode = New System.Windows.Forms.TextBox()
    Me.LblListNo = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.LnkMeterSize = New System.Windows.Forms.LinkLabel()
    Me.TxtMeterSize = New System.Windows.Forms.TextBox()
    Me.LblDesc = New System.Windows.Forms.Label()
    Me.LblName = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.BtnRecalc = New System.Windows.Forms.Button()
    Me.DtPckRead = New System.Windows.Forms.DateTimePicker()
    Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtEDU = New System.Windows.Forms.TextBox()
        Me.TxtUnits = New System.Windows.Forms.TextBox()
        Me.GroupBox4.SuspendLayout()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox4.Controls.Add(Me.LblTotalUse)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.LblActualUse)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.LblBillAmt)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(486, 38)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(176, 96)
        Me.GroupBox4.TabIndex = 316
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Bill Calcs"
        '
        'LblTotalUse
        '
        Me.LblTotalUse.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblTotalUse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblTotalUse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalUse.Location = New System.Drawing.Point(80, 40)
        Me.LblTotalUse.Name = "LblTotalUse"
        Me.LblTotalUse.Size = New System.Drawing.Size(72, 16)
        Me.LblTotalUse.TabIndex = 33
        Me.LblTotalUse.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Total Use"
        '
        'LblActualUse
        '
        Me.LblActualUse.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblActualUse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblActualUse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblActualUse.Location = New System.Drawing.Point(80, 16)
        Me.LblActualUse.Name = "LblActualUse"
        Me.LblActualUse.Size = New System.Drawing.Size(72, 16)
        Me.LblActualUse.TabIndex = 31
        Me.LblActualUse.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Actual Use"
        '
        'LblBillAmt
        '
        Me.LblBillAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblBillAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblBillAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBillAmt.Location = New System.Drawing.Point(80, 72)
        Me.LblBillAmt.Name = "LblBillAmt"
        Me.LblBillAmt.Size = New System.Drawing.Size(88, 16)
        Me.LblBillAmt.TabIndex = 29
        Me.LblBillAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Bill Amt"
        '
        'LnkCode
        '
        Me.LnkCode.AutoSize = True
        Me.LnkCode.Location = New System.Drawing.Point(8, 64)
        Me.LnkCode.Name = "LnkCode"
        Me.LnkCode.Size = New System.Drawing.Size(98, 13)
        Me.LnkCode.TabIndex = 304
        Me.LnkCode.TabStop = True
        Me.LnkCode.Text = "Meter/Usage Code"
        '
        'TxtCode
        '
        Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCode.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCode.Location = New System.Drawing.Point(112, 59)
        Me.TxtCode.MaxLength = 3
        Me.TxtCode.Name = "TxtCode"
        Me.TxtCode.Size = New System.Drawing.Size(32, 22)
        Me.TxtCode.TabIndex = 0
        '
        'LblListNo
        '
        Me.LblListNo.Location = New System.Drawing.Point(72, 8)
        Me.LblListNo.Name = "LblListNo"
        Me.LblListNo.Size = New System.Drawing.Size(72, 16)
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
        'LnkMeterSize
        '
        Me.LnkMeterSize.AutoSize = True
        Me.LnkMeterSize.Location = New System.Drawing.Point(8, 92)
        Me.LnkMeterSize.Name = "LnkMeterSize"
        Me.LnkMeterSize.Size = New System.Drawing.Size(93, 13)
        Me.LnkMeterSize.TabIndex = 324
        Me.LnkMeterSize.TabStop = True
        Me.LnkMeterSize.Text = "Meter/Usage Size"
        '
        'TxtMeterSize
        '
        Me.TxtMeterSize.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMeterSize.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMeterSize.Location = New System.Drawing.Point(112, 88)
        Me.TxtMeterSize.MaxLength = 3
        Me.TxtMeterSize.Name = "TxtMeterSize"
        Me.TxtMeterSize.Size = New System.Drawing.Size(16, 22)
        Me.TxtMeterSize.TabIndex = 1
        '
        'LblDesc
        '
        Me.LblDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDesc.Location = New System.Drawing.Point(8, 40)
        Me.LblDesc.Name = "LblDesc"
        Me.LblDesc.Size = New System.Drawing.Size(160, 16)
        Me.LblDesc.TabIndex = 328
        '
        'LblName
        '
        Me.LblName.Location = New System.Drawing.Point(128, 8)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(280, 16)
        Me.LblName.TabIndex = 329
        Me.LblName.UseMnemonic = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(449, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 17)
        Me.Label2.TabIndex = 350
        Me.Label2.Text = "Reading Date"
        '
        'BtnRecalc
        '
        Me.BtnRecalc.Location = New System.Drawing.Point(621, 8)
        Me.BtnRecalc.Name = "BtnRecalc"
        Me.BtnRecalc.Size = New System.Drawing.Size(51, 24)
        Me.BtnRecalc.TabIndex = 5
        Me.BtnRecalc.TabStop = False
        Me.BtnRecalc.Text = "Recalc"
        Me.BtnRecalc.UseVisualStyleBackColor = True
        '
        'DtPckRead
        '
        Me.DtPckRead.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckRead.Location = New System.Drawing.Point(531, 10)
        Me.DtPckRead.Name = "DtPckRead"
        Me.DtPckRead.Size = New System.Drawing.Size(84, 20)
        Me.DtPckRead.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 351
        Me.Label5.Text = "Usage Units"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.C1DataGrdList)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(202, 38)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(278, 166)
        Me.GroupBox3.TabIndex = 353
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Meter/Usage Readings History"
        '
        'C1DataGrdList
        '
        Me.C1DataGrdList.AllowColMove = False
        Me.C1DataGrdList.AllowRowSelect = False
        Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.C1DataGrdList.AllowUpdate = False
        Me.C1DataGrdList.AlternatingRows = True
        Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.C1DataGrdList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
        Me.C1DataGrdList.Location = New System.Drawing.Point(8, 16)
        Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
        Me.C1DataGrdList.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.C1DataGrdList.Name = "C1DataGrdList"
        Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
        Me.C1DataGrdList.PrintInfo.MeasurementDevice = C1.Win.C1TrueDBGrid.PrintInfo.MeasurementDeviceEnum.Screen
        Me.C1DataGrdList.PrintInfo.MeasurementPrinterName = Nothing
        Me.C1DataGrdList.RecordSelectors = False
        Me.C1DataGrdList.Size = New System.Drawing.Size(264, 144)
        Me.C1DataGrdList.TabIndex = 304
        Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 142)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 354
        Me.Label8.Text = "Usage EDUs"
        '
        'TxtEDU
        '
        Me.TxtEDU.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEDU.Location = New System.Drawing.Point(88, 138)
        Me.TxtEDU.MaxLength = 7
        Me.TxtEDU.Name = "TxtEDU"
        Me.TxtEDU.Size = New System.Drawing.Size(56, 22)
        Me.TxtEDU.TabIndex = 3
        Me.TxtEDU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtUnits
        '
        Me.TxtUnits.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUnits.Location = New System.Drawing.Point(88, 113)
        Me.TxtUnits.MaxLength = 7
        Me.TxtUnits.Name = "TxtUnits"
        Me.TxtUnits.Size = New System.Drawing.Size(56, 22)
        Me.TxtUnits.TabIndex = 2
        Me.TxtUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FrmUB102MT
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(674, 211)
        Me.Controls.Add(Me.TxtUnits)
        Me.Controls.Add(Me.TxtEDU)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnRecalc)
        Me.Controls.Add(Me.DtPckRead)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.LblDesc)
        Me.Controls.Add(Me.LnkMeterSize)
        Me.Controls.Add(Me.TxtMeterSize)
        Me.Controls.Add(Me.LblListNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.LnkCode)
        Me.Controls.Add(Me.TxtCode)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmUB102MT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Maintain Customer - Metered/Usage Data"
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FrmUB102MT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myUTCUST = New UTCUST.MyData(myDBConnect)
    myUTCUSTRT = New UTCUSTRT.MyData(myDBConnect)
    myUTCUSTMT = New UTCUSTMT.MyData(myDBConnect)

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

    myUTCUST.GetOneRecordP(WrkListNo)
    With myUTCUST
      TxtMeterSize.Text = Trim(._CUMSIZ)
      TxtUnits.Text = ._CUUNIT
      If MyEDU1 Then
        TxtEDU.Text = "1"
      Else
        TxtEDU.Text = ._CUEDU
      End If
    End With

    TxtCode.Text = GetRateCode(WrkListNo, WrkUBType)

    SetMeteredCodeTip()
    SetMeteredSizeTip()
    CalcMetered()
    FormatGrid()

    LoadScrn = False
  End Sub
  Private Sub LnkMeteredCode_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode.LinkClicked
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

    SetMeteredCodeTip()
    SetMeteredSizeTip()

    myUTCUST.GetOneRecordP(WrkListNo)
    If Not myUTCUST.RecordNotFound Then
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
        myUTCUSTRT.DeleteOneRecordP()
      Else
        MoveToFileRT(False)
        myUTCUSTRT.UpdateOneRecordP()
      End If
    Else
      MoveToFileRT(True)
      myUTCUSTRT.AddOneRecordP()
      If myUTCUSTRT.ErrMsg <> "" Then
        WriteErrorLog(myUTCUSTRT.ErrMsg)
        Exit Sub
      End If
    End If

    Me.Close()

  End Sub
  Private Sub MoveToFile()
    With myUTCUST
      ._CUMSIZ = TxtMeterSize.Text
      ._CUUNIT = MyUtils.CnvSng(TxtUnits.Text)
      ._CUEDU = MyUtils.CnvSng(TxtEDU.Text)
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
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtCode, "")
    ErrProv.SetError(TxtMeterSize, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Me.ForeColor = Color.DarkRed
      Select Case ErrorField(I)
        Case "code"
          ErrProv.SetError(TxtCode, ErrorMsg(I))
        Case "size"
          ErrProv.SetError(TxtMeterSize, ErrorMsg(I))
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

    If Trim(TxtCode.Text <> "") Then
      WrkTip = Ttp1.GetToolTip(TxtCode)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "code"
        ErrorMsg(I) = "Invalid Meter Code"
        I = I + 1
      End If
    End If

    If Trim(TxtMeterSize.Text <> "") Then
      WrkTip = Ttp1.GetToolTip(TxtMeterSize)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "size"
        ErrorMsg(I) = "Invalid Meter Size"
        I = I + 1
      End If
    End If
  End Sub
  Private Sub CalcMetered()
    Dim MyUBCalcReading As UBCalcReading.MyData
    Dim MyUBCalcBill As UBCalcBill.MeteredUse
    Dim MyUBCalcBill2 As UBCalcBill.BillMetered
    Dim WrkReadingCurr As Integer
    Dim WrkReadingPrev As Integer
    Dim WrkReading2 As Integer
    Dim WrkReading3 As Integer
    Dim WrkBlcd As String

    MyUBCalcReading = New UBCalcReading.MyData(myDBConnect)
    MyUBCalcBill = New UBCalcBill.MeteredUse(myDBConnect)
    MyUBCalcBill2 = New UBCalcBill.BillMetered(myDBConnect)
    WrkBlcd = GetUTMeterBlcd(WrkUBType, TxtMeterSize.Text)

    With MyUBCalcReading
      .In_ListNo = WrkListNo
      .In_RateType = WrkUBType
      If WrkBlcd = "W" Or WrkBlcd = "Y" Or WrkBlcd = "D" Then
        .In_AnnualBill = True
      Else
        .In_AnnualBill = False
      End If
      .In_BillDate = DtPckRead.Value
      .GetMeterReadings()
      WrkReadingCurr = .Out_MeterReadCurr
      WrkReadingPrev = .Out_MeterReadPrev
      WrkReading2 = .Out_MeterRead2
      WrkReading3 = .Out_MeterRead3
      StrDebug = "CalcReading:" & vbCrLf & .Out_Debug
    End With

    With MyUBCalcBill
      .In_RateType = WrkUBType
      .In_MeterSize = TxtMeterSize.Text
      .In_MeterReadCurr = WrkReadingCurr
      .In_MeterReadPrev = WrkReadingPrev
      .In_MeterRead2 = WrkReading2
      .In_MeterRead3 = WrkReading3
      .In_Units = MyUtils.CnvSng(TxtUnits.Text)
      .In_EDUs = MyUtils.CnvSng(TxtEDU.Text)
      .CalcMeteredUse()
      LblTotalUse.Text = .Out_TotalUse
      LblActualUse.Text = .Out_ActualUse
      StrDebug = StrDebug & vbCrLf & "CalcBill:" & vbCrLf & .Out_Debug
    End With

    With MyUBCalcBill2
      .In_RateType = WrkUBType
      .In_RateCode = TxtCode.Text
      .In_TotalUse = MyUBCalcBill.Out_TotalUse
      .In_MinBill = MyUBCalcBill.Out_MinBill
      .In_UseMinCharge = MyUBCalcBill.Out_UseMinCharge
      .In_UnitCharge = MyUBCalcBill.Out_UnitCharge
      .In_EDUCharge = MyUBCalcBill.Out_EDUCharge
      .In_MarkupPct = MyUBCalcBill.Out_MarkupPct
      .CalcMetered()
      LblBillAmt.Text = MyUtils.FmtCurrency(.Out_Bill)
      StrDebug = StrDebug & vbCrLf & "CalcBill2:" & vbCrLf & .Out_Debug
    End With
  End Sub
  Private Sub SetMeteredCodeTip()
    Dim WrkDesc As String

    If Not TxtCode.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetUTRateMTDesc(WrkUBType, TxtCode.Text)
    Ttp1.SetToolTip(TxtCode, WrkDesc)
  End Sub
  Private Sub SetMeteredSizeTip()
    Dim WrkDesc As String

    If Not TxtMeterSize.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetUTMeterDesc(WrkUBType, TxtMeterSize.Text)
    Ttp1.SetToolTip(TxtMeterSize, WrkDesc)
  End Sub
  Private Sub FrmUB102MT_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmUB102.TBarSave.Enabled = True
    MyFrmUB102.TBarDelete.Enabled = True
    MyFrmUB102C.FormatGrid()
    MyFrmUB102C.Show()
    'Memory Cleanup
    myUTCUST = Nothing
    myUTCUSTRT = Nothing
    myUTCUSTMT = Nothing
    MyFrmUB102MT = Nothing
  End Sub
  Private Sub FrmUB102MT_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmUB102.SbpScreen.Text = "UB102MT"
    MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmUB102
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub TxtCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCode.TextChanged
    CalcMetered()
  End Sub
  Private Sub TxtCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCode.Leave
    SetMeteredCodeTip()
  End Sub
  Private Sub GroupBox4_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox4.DoubleClick
    MsgBox(StrDebug)
  End Sub
  Private Sub LnkMeterSize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkMeterSize.LinkClicked
    MyFrmListMeterSize = New FrmListMeterSize
    MyFrmListMeterSize.MdiParent = Me.ParentForm
    MyFrmListMeterSize.WrkUBType = WrkUBType
    MyFrmListMeterSize.WrkMeter = TxtMeterSize.Text
    MyFrmListMeterSize.Show()
    Me.Hide()
  End Sub
  Private Sub TxtMeterSize_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMeterSize.TextChanged
    CalcMetered()
  End Sub
  Public Sub FormatGrid()
    Call ShowGrid()

    With C1DataGrdList
      .Rebind(True)
      .Splits(0).DisplayColumns(0).Visible = False
      .Splits(0).DisplayColumns(1).Visible = False
      .Columns(2).Caption = "Date"
      .Splits(0).DisplayColumns(2).Width = 60
      .Columns(3).Caption = "Reading"
      .Splits(0).DisplayColumns(3).Width = 70
      .Columns(4).Caption = "Use"
      .Splits(0).DisplayColumns(4).Width = 70
      .Columns(5).Caption = "Rsn"
      .Splits(0).DisplayColumns(5).Width = 35
    End With

  End Sub
  Public Sub ShowGrid()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    Dim ds As DataSet = New DataSet

    ds = myUTCUSTMT.GetAllListNo(WrkListNo, "", 0, 99999999)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub

  Private Sub BtnRecalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRecalc.Click
    CalcMetered()
  End Sub

  Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

  End Sub
End Class
