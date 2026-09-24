Public Class FrmLOG
    Inherits System.Windows.Forms.Form
  Friend WrkListNo As Integer
  Friend WrkType As String
  Friend ds As DataSet = New DataSet
  Friend WithEvents RbNormal As System.Windows.Forms.RadioButton
  Friend WithEvents RbMerged As System.Windows.Forms.RadioButton

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
Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLOG))
Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
Me.RbNormal = New System.Windows.Forms.RadioButton
Me.RbMerged = New System.Windows.Forms.RadioButton
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'C1DataGrdList
'
Me.C1DataGrdList.AllowColSelect = False
Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
Me.C1DataGrdList.AlternatingRows = True
Me.C1DataGrdList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
Me.C1DataGrdList.Location = New System.Drawing.Point(16, 29)
Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
Me.C1DataGrdList.Name = "C1DataGrdList"
Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75
Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.C1DataGrdList.Size = New System.Drawing.Size(737, 345)
Me.C1DataGrdList.TabIndex = 196
Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
'
'RbNormal
'
Me.RbNormal.AutoSize = True
Me.RbNormal.CheckAlign = System.Drawing.ContentAlignment.TopRight
Me.RbNormal.Location = New System.Drawing.Point(188, 6)
Me.RbNormal.Name = "RbNormal"
Me.RbNormal.Size = New System.Drawing.Size(113, 17)
Me.RbNormal.TabIndex = 200
Me.RbNormal.Text = "Normal (Full Detail)"
Me.RbNormal.UseVisualStyleBackColor = True
'
'RbMerged
'
Me.RbMerged.AutoSize = True
Me.RbMerged.CheckAlign = System.Drawing.ContentAlignment.TopRight
Me.RbMerged.Checked = True
Me.RbMerged.Location = New System.Drawing.Point(16, 6)
Me.RbMerged.Name = "RbMerged"
Me.RbMerged.Size = New System.Drawing.Size(148, 17)
Me.RbMerged.TabIndex = 199
Me.RbMerged.TabStop = True
Me.RbMerged.Text = "Merged (Differences Only)"
Me.RbMerged.UseVisualStyleBackColor = True
'
'FrmLOG
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(769, 388)
Me.ControlBox = False
Me.Controls.Add(Me.RbNormal)
Me.Controls.Add(Me.RbMerged)
Me.Controls.Add(Me.C1DataGrdList)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.Name = "FrmLOG"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Change Log"
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmLOG_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Select Case WrkType
  Case "M"
    Me.Text = "Motor Vehicle " & Me.Text
  Case "P"
    Me.Text = "Personal Property " & Me.Text
  Case "R"
    Me.Text = "Real Estate " & Me.Text
  Case "S"
    Me.Text = "Supplemental Motor Vehicle " & Me.Text
  End Select

  FormatGrid()
  MyFrmTA330.SbpScreen.Text = "LOG"
End Sub
Public Sub FormatGrid()
  Select Case WrkType
  Case "M"
    Call FormatGridMV()
  Case "P"
    Call FormatGridPP()
  Case "R"
    Call FormatGridRE()
  Case "S"
    Call FormatGridSU()
  End Select
End Sub
Public Sub FormatGridMV()
  Dim I As Integer

  Call ShowGrid()
  With C1DataGrdList
      .Rebind(True)
			.Columns(0).Caption = "Category"
      .Columns(1).Caption = "Make"
      .Columns(2).Caption = "Vehicle Year"
      .Columns(3).Caption = "Model"
      .Columns(4).Caption = "Body"
      .Columns(5).Caption = "Dist"
      .Columns(6).Caption = "Name"
      .Columns(7).Caption = "2nd Name"
      .Columns(8).Caption = "Address 1"
      .Columns(9).Caption = "Address 2"
      .Columns(10).Caption = "City"
      .Columns(11).Caption = "St"
      .Columns(12).Caption = "Zip"
			.Columns(13).Caption = "Zip 4"
			.Columns(14).Caption = "Exp Date"
      .Columns(15).Caption = "Class"
      .Columns(16).Caption = "Reg#"
      .Columns(17).Caption = "Vin#"
      .Columns(18).Caption = "Cylinder Axle"
      .Columns(19).Caption = "Primary Color"
      .Columns(20).Caption = "Secondary Color"
      .Columns(21).Caption = "Seating Cap"
      .Columns(22).Caption = "Light Weight"
      .Columns(23).Caption = "Gross Weight"
      .Columns(24).Caption = "Value"
      .Columns(25).Caption = "Assessment Code"
      .Columns(26).Caption = "Cycle Code"
      .Columns(27).Caption = "Rounding Code"
      .Columns(28).Caption = "Output Code"
      .Columns(29).Caption = "% of Assess"
      .Columns(30).Caption = "List#"
      .Columns(31).Caption = "Previ Class"
      .Columns(32).Caption = "Prev Reg#"
      .Columns(33).Caption = "Standing Cap"
      .Columns(34).Caption = "Trans Date"
      .Columns(35).Caption = "Exmpt Code 1"
      .Columns(36).Caption = "Exmpt Code 2"
      .Columns(37).Caption = "Exmpt Code 3"
      .Columns(38).Caption = "Exmpt Code 4"
      .Columns(39).Caption = "Exmpt Code 5"
			.Columns(40).Caption = "Exmpt Amt 1"
			.Columns(41).Caption = "Exmpt Amt 2"
			.Columns(42).Caption = "Exmpt Amt 3"
			.Columns(43).Caption = "Exmpt Amt 4"
			.Columns(44).Caption = "Exmpt Amt 5"
			.Columns(45).Caption = "C/C No"
			.Columns(46).Caption = "C/C Gross"
			.Columns(47).Caption = "C/C Exmpt Amt"
			.Columns(48).Caption = "C/C Reason"
			.Columns(49).Caption = "C/C Date"
			.Columns(50).Caption = "C/C Exmpt Code 1"
			.Columns(51).Caption = "C/C Exmpt Code 2"
			.Columns(52).Caption = "C/C Exmpt Code 3"
			.Columns(53).Caption = "C/C Exmpt Code 4"
			.Columns(54).Caption = "C/C Exmpt Code 5"
			.Columns(55).Caption = "C/C Exmpt Amt 1"
			.Columns(56).Caption = "C/C Exmpt Amt 2"
			.Columns(57).Caption = "C/C Exmpt Amt 3"
			.Columns(58).Caption = "C/C Exmpt Amt 4"
			.Columns(59).Caption = "C/C Exmpt Amt 5"
      .Columns(60).Caption = "Cred Veh Cls"
      .Columns(61).Caption = "Cred Veh Make"
      .Columns(62).Caption = "Cred Veh Year"
      .Columns(63).Caption = "Cred Veh Model"
      .Columns(64).Caption = "Cred Veh Reg#"
      .Columns(65).Caption = "Cred Veh Vin#"
      .Columns(66).Caption = "Cred Veh Assmt"
      .Columns(67).Caption = "Cred Veh Value"
      .Columns(68).Caption = "Cred Veh Pro Val"
      .Columns(69).Caption = "Cred Veh Pro Net"
      .Columns(70).Caption = "Cred Veh List#"
			.Columns(71).Caption = "BTR"
      .Columns(72).Caption = "DOB"
      .Columns(73).Caption = "SSN"
      .Columns(74).Caption = "Back Tax Code"
      .Columns(75).Caption = "Leasing Co"
      .Columns(76).Caption = "Orig 100% Val"
      .Columns(77).Caption = "Trade In Value"
      .Columns(78).Caption = "Loan Value"
      .Columns(79).Caption = "MSRP Value"
      .Columns(80).Caption = "NADA Return Codes"
      .Columns(81).Caption = "User Id"
      .Columns(82).Caption = "Date Changed"
      .Columns(83).Caption = "Time Changed"
      .Columns(84).Caption = "Letter"
      .Columns(85).Caption = "Type"
      .Columns(86).Caption = "BTR Denied"
      .Columns(87).Caption = "BTR App Date"
      .Columns(88).Caption = "Print Dist"
      .Columns(89).Caption = "Owner Id"
      .Columns(90).Caption = "SSN"
      .Columns(91).Caption = "TIN"
      .Columns(92).Caption = "Res Address 1"
      .Columns(93).Caption = "Res address 2"
      .Columns(94).Caption = "Res City"
      .Columns(95).Caption = "Res State"
      .Columns(96).Caption = "Res Zip"
      .Columns(97).Caption = "Res Zip Ext"
      .Columns(98).Caption = "Log Comment "
      .Columns(99).Caption = "Log Date"
      .Columns(100).Caption = "Log Time"

			.Splits(0).DisplayColumns(0).Width = 55
			.Columns(0).ValueItems.Values.Clear()
			.Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("1", "Taxable"))
			.Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("3", "Exempt"))
			.Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("T", "Transfer"))
			.Columns(0).ValueItems.Translate = True
			.Splits(0).DisplayColumns(1).Width = 50
      .Splits(0).DisplayColumns(2).Width = 40
      .Splits(0).DisplayColumns(3).Width = 80
      .Splits(0).DisplayColumns(4).Width = 60
      .Splits(0).DisplayColumns(5).Width = 30
			.Splits(0).DisplayColumns(6).Width = 250
			.Splits(0).DisplayColumns(7).Width = 250
			.Splits(0).DisplayColumns(8).Width = 250
			.Splits(0).DisplayColumns(9).Width = 250
      '
			.Splits(0).DisplayColumns(10).Width = 200
			.Splits(0).DisplayColumns(11).Width = 40
      .Splits(0).DisplayColumns(12).Width = 50
      .Splits(0).DisplayColumns(13).Width = 40
      .Splits(0).DisplayColumns(14).Width = 80
			.Splits(0).DisplayColumns(15).Width = 40
      .Splits(0).DisplayColumns(16).Width = 80
      .Splits(0).DisplayColumns(17).Width = 170
			.Splits(0).DisplayColumns(18).Width = 40
      .Splits(0).DisplayColumns(19).Width = 30

      .Splits(0).DisplayColumns(20).Width = 30
			.Splits(0).DisplayColumns(21).Width = 40
      .Splits(0).DisplayColumns(22).Width = 60
      .Splits(0).DisplayColumns(23).Width = 60
      .Splits(0).DisplayColumns(24).Width = 90
			.Splits(0).DisplayColumns(25).Width = 40
			.Splits(0).DisplayColumns(26).Width = 40
			.Splits(0).DisplayColumns(27).Width = 40
			.Splits(0).DisplayColumns(28).Width = 40
      .Splits(0).DisplayColumns(29).Width = 30

      .Splits(0).DisplayColumns(30).Width = 60
			.Splits(0).DisplayColumns(31).Width = 40
      .Splits(0).DisplayColumns(32).Width = 80
			.Splits(0).DisplayColumns(33).Width = 40
      .Splits(0).DisplayColumns(34).Width = 80
      .Splits(0).DisplayColumns(35).Width = 30
      .Splits(0).DisplayColumns(36).Width = 30
      .Splits(0).DisplayColumns(37).Width = 30
      .Splits(0).DisplayColumns(38).Width = 30
      .Splits(0).DisplayColumns(39).Width = 30

      .Splits(0).DisplayColumns(40).Width = 70
      .Splits(0).DisplayColumns(41).Width = 70
      .Splits(0).DisplayColumns(42).Width = 70
      .Splits(0).DisplayColumns(43).Width = 70
      .Splits(0).DisplayColumns(44).Width = 70
      .Splits(0).DisplayColumns(45).Width = 50
      .Splits(0).DisplayColumns(46).Width = 90
      .Splits(0).DisplayColumns(47).Width = 90
			.Splits(0).DisplayColumns(48).Width = 40
      .Splits(0).DisplayColumns(49).Width = 80

      .Splits(0).DisplayColumns(50).Width = 30
      .Splits(0).DisplayColumns(51).Width = 30
      .Splits(0).DisplayColumns(52).Width = 30
      .Splits(0).DisplayColumns(53).Width = 30
      .Splits(0).DisplayColumns(54).Width = 30
      .Splits(0).DisplayColumns(55).Width = 70
      .Splits(0).DisplayColumns(56).Width = 70
      .Splits(0).DisplayColumns(57).Width = 70
      .Splits(0).DisplayColumns(58).Width = 70
      .Splits(0).DisplayColumns(59).Width = 70

      .Splits(0).DisplayColumns(60).Width = 20
      .Splits(0).DisplayColumns(61).Width = 50
      .Splits(0).DisplayColumns(62).Width = 40
      .Splits(0).DisplayColumns(63).Width = 80
      .Splits(0).DisplayColumns(64).Width = 80
      .Splits(0).DisplayColumns(65).Width = 170
			.Splits(0).DisplayColumns(66).Width = 40
      .Splits(0).DisplayColumns(67).Width = 90
      .Splits(0).DisplayColumns(68).Width = 90
      .Splits(0).DisplayColumns(69).Width = 90

      .Splits(0).DisplayColumns(70).Width = 60
      .Splits(0).DisplayColumns(71).Width = 90
      .Splits(0).DisplayColumns(72).Width = 80
      .Splits(0).DisplayColumns(73).Width = 90
			.Splits(0).DisplayColumns(74).Width = 40
			.Splits(0).DisplayColumns(75).Width = 40
      .Splits(0).DisplayColumns(76).Width = 90
      .Splits(0).DisplayColumns(77).Width = 90
      .Splits(0).DisplayColumns(78).Width = 90
      .Splits(0).DisplayColumns(79).Width = 90
'
      .Splits(0).DisplayColumns(80).Width = 80
      .Splits(0).DisplayColumns(81).Width = 100
      .Splits(0).DisplayColumns(82).Width = 80
      .Splits(0).DisplayColumns(83).Width = 60
			.Splits(0).DisplayColumns(84).Width = 40
			.Splits(0).DisplayColumns(85).Width = 40
			.Splits(0).DisplayColumns(86).Width = 40
      .Splits(0).DisplayColumns(87).Width = 80
      .Splits(0).DisplayColumns(88).Width = 30
      .Splits(0).DisplayColumns(89).Width = 150

      .Splits(0).DisplayColumns(90).Width = 90
			.Splits(0).DisplayColumns(91).Width = 40
      .Splits(0).DisplayColumns(92).Width = 350
      .Splits(0).DisplayColumns(93).Width = 350
      .Splits(0).DisplayColumns(94).Width = 250
			.Splits(0).DisplayColumns(95).Width = 40
      .Splits(0).DisplayColumns(96).Width = 50
      .Splits(0).DisplayColumns(97).Width = 40
      .Splits(0).DisplayColumns(98).Width = 200
      .Splits(0).DisplayColumns(99).Width = 80

      .Splits(0).DisplayColumns(100).Width = 60
      For I = 0 To 100
        If RbMerged.Checked Then
          .Splits(0).DisplayColumns(I).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.Free
        Else
          .Splits(0).DisplayColumns(I).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.None
        End If
      Next
   End With
End Sub
Public Sub FormatGridPP()
  Dim I As Integer

  Call ShowGrid()
  With C1DataGrdList
      .Rebind(True)
			.Columns(0).Caption = "Category"
      .Columns(1).Caption = "List#"
      .Columns(2).Caption = "Owner Name"
      .Columns(3).Caption = "Second Name"
      .Columns(4).Caption = "Address 1"
      .Columns(5).Caption = "Address 2"
      .Columns(6).Caption = "City"
      .Columns(7).Caption = "St"
      .Columns(8).Caption = "Zip"
			.Columns(9).Caption = "Zip 4"
			.Columns(10).Caption = "Loc #"
      .Columns(11).Caption = "Location"
      .Columns(12).Caption = "District"
      .Columns(13).Caption = "Gross"
      .Columns(14).Caption = "Net"
			.Columns(15).Caption = "Asmt 1"
			.Columns(16).Caption = "Asmt 2"
			.Columns(17).Caption = "Asmt 3"
			.Columns(18).Caption = "Asmt 4"
			.Columns(19).Caption = "Asmt 5"
			.Columns(20).Caption = "Asmt 6"
			.Columns(21).Caption = "Asmt 7"
			.Columns(22).Caption = "Asmt 8"
			.Columns(23).Caption = "Asmt 9"
			.Columns(24).Caption = "Asmt 10"
      .Columns(25).Caption = "Code 1"
      .Columns(26).Caption = "Code 2"
      .Columns(27).Caption = "Code 3"
      .Columns(28).Caption = "Code 4"
      .Columns(29).Caption = "Code 5"
      .Columns(30).Caption = "Code 6"
      .Columns(31).Caption = "Code 7"
      .Columns(32).Caption = "Code 8"
      .Columns(33).Caption = "Code 9"
      .Columns(34).Caption = "Code 10"
      .Columns(35).Caption = "Unit 1"
      .Columns(36).Caption = "Unit 2"
      .Columns(37).Caption = "Unit 3"
      .Columns(38).Caption = "Unit 4"
      .Columns(39).Caption = "Unit 5"
      .Columns(40).Caption = "Unit 6"
      .Columns(41).Caption = "Unit 7"
      .Columns(42).Caption = "Unit 8"
      .Columns(43).Caption = "Unit 9"
      .Columns(44).Caption = "Unit 10"
      .Columns(45).Caption = "Exmpt Code 1"
      .Columns(46).Caption = "Exmpt Code 2"
      .Columns(47).Caption = "Exmpt Code 3"
      .Columns(48).Caption = "Exmpt Code 4"
      .Columns(49).Caption = "Exmpt Code 5"
			.Columns(50).Caption = "Exmpt Amt 1"
			.Columns(51).Caption = "Exmpt Amt 2"
			.Columns(52).Caption = "Exmpt Amt 3"
			.Columns(53).Caption = "Exmpt Amt 4"
			.Columns(54).Caption = "Exmpt Amt 5"
			.Columns(55).Caption = "C/C No"
			.Columns(56).Caption = "C/C Gross"
			.Columns(57).Caption = "C/C Exemption"
			.Columns(58).Caption = "C/C Reason "
			.Columns(59).Caption = "C/C Date"
			.Columns(60).Caption = "C/C Asmt Value 1"
			.Columns(61).Caption = "C/C Asmt Value 2"
			.Columns(62).Caption = "C/C Asmt Value 3"
			.Columns(63).Caption = "C/C Asmt Value 4"
			.Columns(64).Caption = "C/C Asmt Value 5"
			.Columns(65).Caption = "C/C Asmt Value 6"
			.Columns(66).Caption = "C/C Asmt Value 7"
			.Columns(67).Caption = "C/C Asmt Value 8"
			.Columns(68).Caption = "C/C Asmt Value 9"
			.Columns(69).Caption = "C/C Asmt Value 10"
			.Columns(70).Caption = "C/C Exemp Code 1"
			.Columns(71).Caption = "C/C Exmpt Code 2"
			.Columns(72).Caption = "C/C Exmpt Code 3"
			.Columns(73).Caption = "C/C Exmpt Code 4"
			.Columns(74).Caption = "C/C Exmpt Code 5"
			.Columns(75).Caption = "C/C Exmpt Amt 1"
			.Columns(76).Caption = "C/C Exmpt Amt 2"
			.Columns(77).Caption = "C/C Exmpt Amt 3"
			.Columns(78).Caption = "C/C Exmpt Amt 4"
			.Columns(79).Caption = "C/C Exmpt Amt 5"
			.Columns(80).Caption = "BTR"
      .Columns(81).Caption = "Back Tax"
      .Columns(82).Caption = "SSN"
      .Columns(83).Caption = "Business Type"
      .Columns(84).Caption = "Sq Ft"
      .Columns(85).Caption = "Business Y/N"
      .Columns(86).Caption = "Renewal Date"
      .Columns(87).Caption = "User Id"
      .Columns(88).Caption = "Date Changed"
      .Columns(89).Caption = "Time"
      .Columns(90).Caption = "Ltr"
      .Columns(91).Caption = "Type"
      .Columns(92).Caption = "Btr Denied"
      .Columns(93).Caption = "Btr Applied"
      .Columns(94).Caption = "Audit Year"
      .Columns(95).Caption = "Printing District"
      .Columns(96).Caption = "Owner ID"
      .Columns(97).Caption = "2nd SSN"
      .Columns(98).Caption = "TIN"
      .Columns(99).Caption = "Log Comment"
      .Columns(100).Caption = "Log Date"
      .Columns(101).Caption = "Log Time"

'
			.Splits(0).DisplayColumns(0).Width = 55
			.Columns(0).ValueItems.Values.Clear()
			.Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("5", "Taxable"))
			.Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("3", "Exempt"))
			.Columns(0).ValueItems.Translate = True
			.Splits(0).DisplayColumns(1).Width = 40
			.Splits(0).DisplayColumns(2).Width = 250
			.Splits(0).DisplayColumns(3).Width = 250
			.Splits(0).DisplayColumns(4).Width = 250
			.Splits(0).DisplayColumns(5).Width = 250
			.Splits(0).DisplayColumns(6).Width = 200
			.Splits(0).DisplayColumns(7).Width = 20
			.Splits(0).DisplayColumns(8).Width = 40
			.Columns(8).NumberFormat = "00000"
			.Splits(0).DisplayColumns(9).Width = 30
			'
      .Splits(0).DisplayColumns(10).Width = 70
      .Splits(0).DisplayColumns(11).Width = 250
      .Splits(0).DisplayColumns(12).Width = 30
			.Splits(0).DisplayColumns(13).Width = 60
			.Splits(0).DisplayColumns(14).Width = 60
			.Splits(0).DisplayColumns(15).Width = 60
			.Splits(0).DisplayColumns(16).Width = 60
			.Splits(0).DisplayColumns(17).Width = 60
			.Splits(0).DisplayColumns(18).Width = 60
			.Splits(0).DisplayColumns(19).Width = 60

			.Splits(0).DisplayColumns(20).Width = 60
			.Splits(0).DisplayColumns(21).Width = 60
			.Splits(0).DisplayColumns(22).Width = 60
			.Splits(0).DisplayColumns(23).Width = 60
			.Splits(0).DisplayColumns(24).Width = 60
			.Splits(0).DisplayColumns(25).Width = 45
			.Splits(0).DisplayColumns(26).Width = 45
			.Splits(0).DisplayColumns(27).Width = 45
			.Splits(0).DisplayColumns(28).Width = 45
			.Splits(0).DisplayColumns(29).Width = 45

			.Splits(0).DisplayColumns(30).Width = 45
			.Splits(0).DisplayColumns(31).Width = 45
			.Splits(0).DisplayColumns(32).Width = 45
			.Splits(0).DisplayColumns(33).Width = 45
			.Splits(0).DisplayColumns(34).Width = 45
			.Splits(0).DisplayColumns(35).Width = 40
			.Splits(0).DisplayColumns(36).Width = 40
			.Splits(0).DisplayColumns(37).Width = 40
			.Splits(0).DisplayColumns(38).Width = 40
			.Splits(0).DisplayColumns(39).Width = 40

      .Splits(0).DisplayColumns(40).Width = 30
      .Splits(0).DisplayColumns(41).Width = 30
      .Splits(0).DisplayColumns(42).Width = 30
      .Splits(0).DisplayColumns(43).Width = 30
      .Splits(0).DisplayColumns(44).Width = 30
      .Splits(0).DisplayColumns(45).Width = 30
      .Splits(0).DisplayColumns(46).Width = 30
      .Splits(0).DisplayColumns(47).Width = 30
      .Splits(0).DisplayColumns(48).Width = 30
      .Splits(0).DisplayColumns(49).Width = 30

      .Splits(0).DisplayColumns(50).Width = 70
      .Splits(0).DisplayColumns(51).Width = 70
      .Splits(0).DisplayColumns(52).Width = 70
      .Splits(0).DisplayColumns(53).Width = 70
      .Splits(0).DisplayColumns(54).Width = 70
      .Splits(0).DisplayColumns(55).Width = 50
			.Splits(0).DisplayColumns(56).Width = 60
			.Splits(0).DisplayColumns(57).Width = 60
			.Splits(0).DisplayColumns(58).Width = 50
      .Splits(0).DisplayColumns(59).Width = 80

      .Splits(0).DisplayColumns(60).Width = 90
      .Splits(0).DisplayColumns(61).Width = 90
      .Splits(0).DisplayColumns(62).Width = 90
      .Splits(0).DisplayColumns(63).Width = 90
      .Splits(0).DisplayColumns(64).Width = 90
      .Splits(0).DisplayColumns(65).Width = 90
      .Splits(0).DisplayColumns(66).Width = 90
      .Splits(0).DisplayColumns(67).Width = 90
      .Splits(0).DisplayColumns(68).Width = 90
      .Splits(0).DisplayColumns(69).Width = 90

      .Splits(0).DisplayColumns(70).Width = 30
      .Splits(0).DisplayColumns(71).Width = 30
      .Splits(0).DisplayColumns(72).Width = 30
      .Splits(0).DisplayColumns(73).Width = 30
      .Splits(0).DisplayColumns(74).Width = 30
      .Splits(0).DisplayColumns(75).Width = 70
      .Splits(0).DisplayColumns(76).Width = 70
      .Splits(0).DisplayColumns(77).Width = 70
      .Splits(0).DisplayColumns(78).Width = 70
      .Splits(0).DisplayColumns(79).Width = 70

      .Splits(0).DisplayColumns(80).Width = 90
			.Splits(0).DisplayColumns(81).Width = 40
      .Splits(0).DisplayColumns(82).Width = 90
      .Splits(0).DisplayColumns(83).Width = 40
      .Splits(0).DisplayColumns(84).Width = 90
			.Splits(0).DisplayColumns(85).Width = 40
      .Splits(0).DisplayColumns(86).Width = 80
			.Splits(0).DisplayColumns(87).Width = 40
      .Splits(0).DisplayColumns(88).Width = 80
      .Splits(0).DisplayColumns(89).Width = 60

			.Splits(0).DisplayColumns(90).Width = 40
			.Splits(0).DisplayColumns(91).Width = 40
			.Splits(0).DisplayColumns(92).Width = 40
      .Splits(0).DisplayColumns(93).Width = 80
      .Splits(0).DisplayColumns(94).Width = 40
      .Splits(0).DisplayColumns(95).Width = 30
      .Splits(0).DisplayColumns(96).Width = 150
      .Splits(0).DisplayColumns(97).Width = 90
			.Splits(0).DisplayColumns(98).Width = 40
      .Splits(0).DisplayColumns(99).Width = 200

      .Splits(0).DisplayColumns(100).Width = 80
      .Splits(0).DisplayColumns(101).Width = 60
      For I = 0 To 101
        If RbMerged.Checked Then
          .Splits(0).DisplayColumns(I).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.Free
        Else
          .Splits(0).DisplayColumns(I).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.None
        End If
      Next
   End With
End Sub
Public Sub FormatGridRE()
  Dim I As Integer

  Call ShowGrid()
  With C1DataGrdList
      .Rebind(True)
			.Columns(0).Caption = "Category"
      .Columns(1).Caption = "List#"
      .Columns(2).Caption = "Owner Name"
      .Columns(3).Caption = "Second Name"
      .Columns(4).Caption = "Address 1"
      .Columns(5).Caption = "Address 2"
      .Columns(6).Caption = "City"
      .Columns(7).Caption = "St"
      .Columns(8).Caption = "Zip"
			.Columns(9).Caption = "Zip 4"
      .Columns(10).Caption = "Unit#"
			.Columns(11).Caption = "Loc #"
      .Columns(12).Caption = "Location"
      .Columns(13).Caption = "Volume"
      .Columns(14).Caption = "Page"
      .Columns(15).Caption = "Map"
      .Columns(16).Caption = "S Map"
      .Columns(17).Caption = "District"
      .Columns(18).Caption = "Exempt Code"
      .Columns(19).Caption = "Sewer"
      .Columns(20).Caption = "Owner%"
      .Columns(21).Caption = "Gross"
      .Columns(22).Caption = "Net"
			.Columns(23).Caption = "Asmt 1"
			.Columns(24).Caption = "Asmt 2"
			.Columns(25).Caption = "Asmt 3"
			.Columns(26).Caption = "Asmt 4"
			.Columns(27).Caption = "Asmt 5"
			.Columns(28).Caption = "Asmt 6"
			.Columns(29).Caption = "Asmt 7"
      .Columns(30).Caption = "Code 1"
      .Columns(31).Caption = "Code 2"
      .Columns(32).Caption = "Code 3"
      .Columns(33).Caption = "Code 4"
      .Columns(34).Caption = "Code 5"
      .Columns(35).Caption = "Code 6"
      .Columns(36).Caption = "Code 7"
      .Columns(37).Caption = "Unit 1"
      .Columns(38).Caption = "Unit 2"
      .Columns(39).Caption = "Unit 3"
      .Columns(40).Caption = "Unit 4"
      .Columns(41).Caption = "Unit 5"
      .Columns(42).Caption = "Unit 6"
      .Columns(43).Caption = "Unit 7"
      .Columns(44).Caption = "Acre 1"
      .Columns(45).Caption = "Acre 2"
      .Columns(46).Caption = "Acre 3"
      .Columns(47).Caption = "Acre 4"
      .Columns(48).Caption = "Acre 5"
      .Columns(49).Caption = "Acre 6"
      .Columns(50).Caption = "Acre 7"
			.Columns(51).Caption = "Eld Code"
			.Columns(52).Caption = "Eld Year"
      .Columns(53).Caption = "Cir %"
			.Columns(54).Caption = "Eld Max"
			.Columns(55).Caption = "Eld Min"
			.Columns(56).Caption = "Eld Adj"
      .Columns(57).Caption = "Frozen Tax"
      .Columns(58).Caption = "Frozen Assessment"
			.Columns(59).Caption = "Town Ben"
			.Columns(60).Caption = "Exmpt Code 1"
      .Columns(61).Caption = "Exmpt Code 2"
      .Columns(62).Caption = "Exmpt Code 3"
      .Columns(63).Caption = "Exmpt Code 4"
      .Columns(64).Caption = "Exmpt Code 5"
      .Columns(65).Caption = "Exmpt Code 6"
      .Columns(66).Caption = "Exmpt Code 7"
			.Columns(67).Caption = "Exmpt Amt 1"
			.Columns(68).Caption = "Exmpt Amt 2"
			.Columns(69).Caption = "Exmpt Amt 3"
			.Columns(70).Caption = "Exmpt Amt 4"
			.Columns(71).Caption = "Exmpt Amt 5"
			.Columns(72).Caption = "Exmpt Amt 6"
			.Columns(73).Caption = "Exmpt Amt 7"
			.Columns(74).Caption = "C/C No"
			.Columns(75).Caption = "C/C Gross"
			.Columns(76).Caption = "C/C Exemption"
			.Columns(77).Caption = "C/C Reason "
			.Columns(78).Caption = "C/C Date"
			.Columns(79).Caption = "C/C Asmt Value 1"
			.Columns(80).Caption = "C/C Asmt Value 2"
			.Columns(81).Caption = "C/C Asmt Value 3"
			.Columns(82).Caption = "C/C Asmt Value 4"
			.Columns(83).Caption = "C/C Asmt Value 5"
			.Columns(84).Caption = "C/C Asmt Value 6"
			.Columns(85).Caption = "C/C Asmt Value 7"
			.Columns(86).Caption = "C/C Code 1"
			.Columns(87).Caption = "C/C Code 2"
			.Columns(88).Caption = "C/C Code 3"
			.Columns(89).Caption = "C/C Code 4"
			.Columns(90).Caption = "C/C Code 5"
			.Columns(91).Caption = "C/C Code 6"
			.Columns(92).Caption = "C/C Code 7"
			.Columns(93).Caption = "C/C Exmpt Amt 1"
			.Columns(94).Caption = "C/C Exmpt Amt 2"
			.Columns(95).Caption = "C/C Exmpt Amt 3"
			.Columns(96).Caption = "C/C Exmpt Amt 4"
			.Columns(97).Caption = "C/C Exmpt Amt 5"
			.Columns(98).Caption = "C/C Exmpt Amt 6"
			.Columns(99).Caption = "C/C Exmpt Amt 7"
			.Columns(100).Caption = "BTR"
      .Columns(101).Caption = "Back Tax"
			.Columns(102).Caption = "Bank Svc"
      .Columns(103).Caption = "Bank Code"
      .Columns(104).Caption = "Purch Date"
      .Columns(105).Caption = "Purch Price"
      .Columns(106).Caption = "Census Block"
      .Columns(107).Caption = "Census Tract"
      .Columns(108).Caption = "Print Prop card"
      .Columns(109).Caption = "Vet Year"
      .Columns(110).Caption = "SSN"
      .Columns(111).Caption = "User Id"
      .Columns(112).Caption = "Date Changed"
      .Columns(113).Caption = "Time"
      .Columns(114).Caption = "Ltr"
      .Columns(115).Caption = "Type"
      .Columns(116).Caption = "Acq Date"
      .Columns(117).Caption = "Expiration Date"
      .Columns(118).Caption = "Acres Classification"
      .Columns(119).Caption = "Btr Denied"
      .Columns(120).Caption = "Date Btr Applied"
      .Columns(121).Caption = "Escrow Acct"
      .Columns(122).Caption = "Mail Where"
      .Columns(123).Caption = "Printing District"
      .Columns(124).Caption = "Ref List#"
      .Columns(125).Caption = "Owner ID"
      .Columns(126).Caption = "2nd SSN"
      .Columns(127).Caption = "TIN"
      .Columns(128).Caption = "Log Comment"
      .Columns(129).Caption = "Log Date"
      .Columns(130).Caption = "Log Time"
'
			.Splits(0).DisplayColumns(0).Width = 55
			.Columns(0).ValueItems.Values.Clear()
			.Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("1", "Taxable"))
			.Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("3", "Exempt"))
			.Columns(0).ValueItems.Translate = True
			.Splits(0).DisplayColumns(1).Width = 40
			.Splits(0).DisplayColumns(2).Width = 250
			.Splits(0).DisplayColumns(3).Width = 250
			.Splits(0).DisplayColumns(4).Width = 250
			.Splits(0).DisplayColumns(5).Width = 250
			.Splits(0).DisplayColumns(6).Width = 200
      .Splits(0).DisplayColumns(7).Width = 20
			.Splits(0).DisplayColumns(8).Width = 40
			.Columns(8).NumberFormat = "00000"
			.Splits(0).DisplayColumns(9).Width = 30
      '
			.Splits(0).DisplayColumns(10).Width = 50
			.Splits(0).DisplayColumns(11).Width = 50
			.Splits(0).DisplayColumns(12).Width = 200
      .Splits(0).DisplayColumns(13).Width = 50
      .Splits(0).DisplayColumns(14).Width = 50
      .Splits(0).DisplayColumns(15).Width = 170
      .Splits(0).DisplayColumns(16).Width = 80
      .Splits(0).DisplayColumns(17).Width = 30
			.Splits(0).DisplayColumns(18).Width = 50
			.Splits(0).DisplayColumns(19).Width = 40
			.Splits(0).DisplayColumns(19).Width = 40
			.Splits(0).DisplayColumns(19).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
			.Columns(19).ValueItems.Values.Clear()
			.Columns(19).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("N", "No"))
			.Columns(19).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("Y", "Yes"))
			.Columns(19).ValueItems.Translate = True

			.Splits(0).DisplayColumns(20).Width = 50
			.Splits(0).DisplayColumns(21).Width = 60
			.Splits(0).DisplayColumns(22).Width = 60
			.Splits(0).DisplayColumns(23).Width = 60
			.Splits(0).DisplayColumns(24).Width = 60
			.Splits(0).DisplayColumns(25).Width = 60
			.Splits(0).DisplayColumns(26).Width = 60
			.Splits(0).DisplayColumns(27).Width = 60
			.Splits(0).DisplayColumns(28).Width = 60
			.Splits(0).DisplayColumns(29).Width = 60

			.Splits(0).DisplayColumns(30).Width = 45
			.Splits(0).DisplayColumns(31).Width = 45
			.Splits(0).DisplayColumns(32).Width = 45
			.Splits(0).DisplayColumns(33).Width = 45
			.Splits(0).DisplayColumns(34).Width = 45
			.Splits(0).DisplayColumns(35).Width = 45
			.Splits(0).DisplayColumns(36).Width = 45
			.Splits(0).DisplayColumns(37).Width = 40
			.Splits(0).DisplayColumns(38).Width = 40
			.Splits(0).DisplayColumns(39).Width = 40

			.Splits(0).DisplayColumns(40).Width = 40
			.Splits(0).DisplayColumns(41).Width = 40
			.Splits(0).DisplayColumns(42).Width = 40
			.Splits(0).DisplayColumns(43).Width = 40
			.Splits(0).DisplayColumns(44).Width = 40
			.Splits(0).DisplayColumns(45).Width = 40
			.Splits(0).DisplayColumns(46).Width = 40
			.Splits(0).DisplayColumns(47).Width = 40
			.Splits(0).DisplayColumns(48).Width = 40
			.Splits(0).DisplayColumns(49).Width = 40

			.Splits(0).DisplayColumns(50).Width = 40
			.Splits(0).DisplayColumns(51).Width = 50
			.Splits(0).DisplayColumns(19).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
			.Columns(51).ValueItems.Values.Clear()
			.Columns(51).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("", ""))
			.Columns(51).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("C", "Heart"))
			.Columns(51).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("F", "Frozen"))
			.Columns(51).ValueItems.Translate = True
			.Splits(0).DisplayColumns(52).Width = 40
      .Splits(0).DisplayColumns(53).Width = 30
      .Splits(0).DisplayColumns(54).Width = 50
      .Splits(0).DisplayColumns(55).Width = 50
      .Splits(0).DisplayColumns(56).Width = 70
      .Splits(0).DisplayColumns(57).Width = 70
      .Splits(0).DisplayColumns(58).Width = 90
      .Splits(0).DisplayColumns(59).Width = 70

			.Splits(0).DisplayColumns(60).Width = 45
			.Splits(0).DisplayColumns(61).Width = 45
			.Splits(0).DisplayColumns(62).Width = 45
			.Splits(0).DisplayColumns(63).Width = 45
			.Splits(0).DisplayColumns(64).Width = 45
			.Splits(0).DisplayColumns(65).Width = 45
			.Splits(0).DisplayColumns(66).Width = 45
      .Splits(0).DisplayColumns(67).Width = 70
      .Splits(0).DisplayColumns(68).Width = 70
      .Splits(0).DisplayColumns(69).Width = 70

      .Splits(0).DisplayColumns(70).Width = 70
      .Splits(0).DisplayColumns(71).Width = 70
      .Splits(0).DisplayColumns(72).Width = 70
      .Splits(0).DisplayColumns(73).Width = 70
      .Splits(0).DisplayColumns(74).Width = 50
      .Splits(0).DisplayColumns(75).Width = 90
      .Splits(0).DisplayColumns(76).Width = 90
			.Splits(0).DisplayColumns(77).Width = 60
      .Splits(0).DisplayColumns(78).Width = 80
      .Splits(0).DisplayColumns(79).Width = 90

      .Splits(0).DisplayColumns(80).Width = 90
      .Splits(0).DisplayColumns(81).Width = 90
      .Splits(0).DisplayColumns(82).Width = 90
      .Splits(0).DisplayColumns(83).Width = 90
      .Splits(0).DisplayColumns(84).Width = 90
      .Splits(0).DisplayColumns(85).Width = 90
			.Splits(0).DisplayColumns(86).Width = 50
			.Splits(0).DisplayColumns(87).Width = 50
			.Splits(0).DisplayColumns(88).Width = 50
			.Splits(0).DisplayColumns(89).Width = 50

			.Splits(0).DisplayColumns(90).Width = 50
			.Splits(0).DisplayColumns(91).Width = 50
			.Splits(0).DisplayColumns(92).Width = 50
      .Splits(0).DisplayColumns(93).Width = 70
      .Splits(0).DisplayColumns(94).Width = 70
      .Splits(0).DisplayColumns(95).Width = 70
      .Splits(0).DisplayColumns(96).Width = 70
      .Splits(0).DisplayColumns(97).Width = 70
      .Splits(0).DisplayColumns(98).Width = 70
      .Splits(0).DisplayColumns(99).Width = 70

			.Splits(0).DisplayColumns(100).Width = 60
			.Splits(0).DisplayColumns(101).Width = 40
			.Splits(0).DisplayColumns(102).Width = 40
			.Splits(0).DisplayColumns(103).Width = 40
      .Splits(0).DisplayColumns(104).Width = 80
			.Splits(0).DisplayColumns(105).Width = 60
      .Splits(0).DisplayColumns(106).Width = 50
      .Splits(0).DisplayColumns(107).Width = 70
			.Splits(0).DisplayColumns(108).Width = 40
      .Splits(0).DisplayColumns(109).Width = 40
      '
			.Splits(0).DisplayColumns(110).Width = 40
      .Splits(0).DisplayColumns(111).Width = 100
      .Splits(0).DisplayColumns(112).Width = 80
      .Splits(0).DisplayColumns(113).Width = 60
			.Splits(0).DisplayColumns(114).Width = 40
			.Splits(0).DisplayColumns(115).Width = 40
      .Splits(0).DisplayColumns(116).Width = 80
      .Splits(0).DisplayColumns(117).Width = 80
      .Splits(0).DisplayColumns(118).Width = 50
			.Splits(0).DisplayColumns(119).Width = 40

      .Splits(0).DisplayColumns(120).Width = 80
      .Splits(0).DisplayColumns(121).Width = 150
			.Splits(0).DisplayColumns(122).Width = 40
			.Splits(0).DisplayColumns(123).Width = 40
      .Splits(0).DisplayColumns(124).Width = 60
			.Splits(0).DisplayColumns(125).Width = 40
			.Splits(0).DisplayColumns(126).Width = 40
			.Splits(0).DisplayColumns(127).Width = 40
      .Splits(0).DisplayColumns(128).Width = 200
      .Splits(0).DisplayColumns(129).Width = 80

      .Splits(0).DisplayColumns(130).Width = 60
      For I = 0 To 130
        If RbMerged.Checked Then
          .Splits(0).DisplayColumns(I).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.Free
        Else
          .Splits(0).DisplayColumns(I).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.None
        End If
      Next
   End With
End Sub
Public Sub FormatGridSU()
  Dim I As Integer

  Call ShowGrid()
  With C1DataGrdList
      .Rebind(True)
			.Columns(0).Caption = "Category"
      .Columns(1).Caption = "Make"
      .Columns(2).Caption = "Vehicle Year"
      .Columns(3).Caption = "Model"
      .Columns(4).Caption = "Body"
      .Columns(5).Caption = "Dist"
      .Columns(6).Caption = "Name"
      .Columns(7).Caption = "2nd Name"
      .Columns(8).Caption = "Address 1"
      .Columns(9).Caption = "Address 2"
      .Columns(10).Caption = "City"
      .Columns(11).Caption = "St"
      .Columns(12).Caption = "Zip"
			.Columns(13).Caption = "Zip 4"
			.Columns(14).Caption = "Exp Date"
      .Columns(15).Caption = "Class"
      .Columns(16).Caption = "Reg#"
      .Columns(17).Caption = "Vin#"
      .Columns(18).Caption = "Cylinder Axle"
      .Columns(19).Caption = "Primary Color"
      .Columns(20).Caption = "Secondary Color"
      .Columns(21).Caption = "Seating Cap"
      .Columns(22).Caption = "Light Weight"
      .Columns(23).Caption = "Gross Weight"
      .Columns(24).Caption = "Value"
      .Columns(25).Caption = "Assessment Code"
      .Columns(26).Caption = "Cycle Code"
      .Columns(27).Caption = "Rounding Code"
      .Columns(28).Caption = "Output Code"
      .Columns(29).Caption = "% of Assess"
      .Columns(30).Caption = "List#"
      .Columns(31).Caption = "Prev Class"
      .Columns(32).Caption = "Prev Reg#"
      .Columns(33).Caption = "Standing Cap"
      .Columns(34).Caption = "Trans Date"
      .Columns(35).Caption = "Exmpt Code 1"
      .Columns(36).Caption = "Exmpt Code 2"
      .Columns(37).Caption = "Exmpt Code 3"
      .Columns(38).Caption = "Exmpt Code 4"
      .Columns(39).Caption = "Exmpt Code 5"
			.Columns(40).Caption = "Exmpt Amt 1"
			.Columns(41).Caption = "Exmpt Amt 2"
			.Columns(42).Caption = "Exmpt Amt 3"
			.Columns(43).Caption = "Exmpt Amt 4"
			.Columns(44).Caption = "Exmpt Amt 5"
			.Columns(45).Caption = "C/C No"
			.Columns(46).Caption = "C/C Gross"
			.Columns(47).Caption = "C/C Exmpt Amt"
			.Columns(48).Caption = "C/C Reason"
			.Columns(49).Caption = "C/C Date"
			.Columns(50).Caption = "C/C Exmpt Code 1"
			.Columns(51).Caption = "C/C Exmpt Code 2"
			.Columns(52).Caption = "C/C Exmpt Code 3"
			.Columns(53).Caption = "C/C Exmpt Code 4"
			.Columns(54).Caption = "C/C Exmpt Code 5"
			.Columns(55).Caption = "C/C Exmpt Amt 1"
			.Columns(56).Caption = "C/C Exmpt Amt 2"
			.Columns(57).Caption = "C/C Exmpt Amt 3"
			.Columns(58).Caption = "C/C Exmpt Amt 4"
			.Columns(59).Caption = "C/C Exmpt Amt 5"
      .Columns(60).Caption = "Cred Veh Cls"
      .Columns(61).Caption = "Cred Veh Make"
      .Columns(62).Caption = "Cred Veh Year"
      .Columns(63).Caption = "Cred Veh Model"
      .Columns(64).Caption = "Cred Veh Reg#"
      .Columns(65).Caption = "Cred Veh Vin#"
      .Columns(66).Caption = "Cred Veh Assmt"
      .Columns(67).Caption = "Cred Veh Value"
      .Columns(68).Caption = "Cred Veh Pro Val"
      .Columns(69).Caption = "Prorated Value"
      .Columns(70).Caption = "Cred Veh Pro Net"
      .Columns(71).Caption = "Cred Veh List#"
			.Columns(72).Caption = "BTR"
      .Columns(73).Caption = "DOB"
      .Columns(74).Caption = "SSN"
      .Columns(75).Caption = "Back Tax Code"
      .Columns(76).Caption = "Leasing Co"
      .Columns(77).Caption = "Orig 100% Val"
      .Columns(78).Caption = "Trade In Value"
      .Columns(79).Caption = "Loan Value"

      .Columns(80).Caption = "MSRP Value"
      .Columns(81).Caption = "NADA Return Codes"
      .Columns(82).Caption = "User Id"
      .Columns(83).Caption = "Date Changed"
      .Columns(84).Caption = "Time Changed"
      .Columns(85).Caption = "Letter"
      .Columns(86).Caption = "Type"
      .Columns(87).Caption = "Print Dist"
      .Columns(88).Caption = "Owner Id"
      .Columns(89).Caption = "SSN"
      .Columns(90).Caption = "TIN"
      .Columns(91).Caption = "Log Comment "
      .Columns(92).Caption = "Log Date"
      .Columns(93).Caption = "Log Time"
'
			.Splits(0).DisplayColumns(0).Width = 55
			.Columns(0).ValueItems.Values.Clear()
			.Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("1", "Taxable"))
			.Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("3", "Exempt"))
			.Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("T", "Transfer"))
			.Columns(0).ValueItems.Translate = True
			.Splits(0).DisplayColumns(1).Width = 50
      .Splits(0).DisplayColumns(2).Width = 40
      .Splits(0).DisplayColumns(3).Width = 80
      .Splits(0).DisplayColumns(4).Width = 60
      .Splits(0).DisplayColumns(5).Width = 30
      .Splits(0).DisplayColumns(6).Width = 350
      .Splits(0).DisplayColumns(7).Width = 350
      .Splits(0).DisplayColumns(8).Width = 350
      .Splits(0).DisplayColumns(9).Width = 350
      '
      .Splits(0).DisplayColumns(10).Width = 250
      .Splits(0).DisplayColumns(11).Width = 20
      .Splits(0).DisplayColumns(12).Width = 50
      .Splits(0).DisplayColumns(13).Width = 40
      .Splits(0).DisplayColumns(14).Width = 80
			.Splits(0).DisplayColumns(15).Width = 40
      .Splits(0).DisplayColumns(16).Width = 80
      .Splits(0).DisplayColumns(17).Width = 170
			.Splits(0).DisplayColumns(18).Width = 40
      .Splits(0).DisplayColumns(19).Width = 30

      .Splits(0).DisplayColumns(20).Width = 30
			.Splits(0).DisplayColumns(21).Width = 40
      .Splits(0).DisplayColumns(22).Width = 60
      .Splits(0).DisplayColumns(23).Width = 60
      .Splits(0).DisplayColumns(24).Width = 90
			.Splits(0).DisplayColumns(25).Width = 40
			.Splits(0).DisplayColumns(26).Width = 40
			.Splits(0).DisplayColumns(27).Width = 40
			.Splits(0).DisplayColumns(28).Width = 40
      .Splits(0).DisplayColumns(29).Width = 30

      .Splits(0).DisplayColumns(30).Width = 60
			.Splits(0).DisplayColumns(31).Width = 40
      .Splits(0).DisplayColumns(32).Width = 80
			.Splits(0).DisplayColumns(33).Width = 40
      .Splits(0).DisplayColumns(34).Width = 80
      .Splits(0).DisplayColumns(35).Width = 30
      .Splits(0).DisplayColumns(36).Width = 30
      .Splits(0).DisplayColumns(37).Width = 30
      .Splits(0).DisplayColumns(38).Width = 30
      .Splits(0).DisplayColumns(39).Width = 30

      .Splits(0).DisplayColumns(40).Width = 70
      .Splits(0).DisplayColumns(41).Width = 70
      .Splits(0).DisplayColumns(42).Width = 70
      .Splits(0).DisplayColumns(43).Width = 70
      .Splits(0).DisplayColumns(44).Width = 70
      .Splits(0).DisplayColumns(45).Width = 50
      .Splits(0).DisplayColumns(46).Width = 90
      .Splits(0).DisplayColumns(47).Width = 90
			.Splits(0).DisplayColumns(48).Width = 40
      .Splits(0).DisplayColumns(49).Width = 80

      .Splits(0).DisplayColumns(50).Width = 30
      .Splits(0).DisplayColumns(51).Width = 30
      .Splits(0).DisplayColumns(52).Width = 30
      .Splits(0).DisplayColumns(53).Width = 30
      .Splits(0).DisplayColumns(54).Width = 30
      .Splits(0).DisplayColumns(55).Width = 70
      .Splits(0).DisplayColumns(56).Width = 70
      .Splits(0).DisplayColumns(57).Width = 70
      .Splits(0).DisplayColumns(58).Width = 70
      .Splits(0).DisplayColumns(59).Width = 70

      .Splits(0).DisplayColumns(60).Width = 20
      .Splits(0).DisplayColumns(61).Width = 50
      .Splits(0).DisplayColumns(62).Width = 40
      .Splits(0).DisplayColumns(63).Width = 80
      .Splits(0).DisplayColumns(64).Width = 80
      .Splits(0).DisplayColumns(65).Width = 170
			.Splits(0).DisplayColumns(66).Width = 40
      .Splits(0).DisplayColumns(67).Width = 90
      .Splits(0).DisplayColumns(68).Width = 90
      .Splits(0).DisplayColumns(69).Width = 90

      .Splits(0).DisplayColumns(70).Width = 90
      .Splits(0).DisplayColumns(71).Width = 60
      .Splits(0).DisplayColumns(72).Width = 90
      .Splits(0).DisplayColumns(73).Width = 80
      .Splits(0).DisplayColumns(74).Width = 90
			.Splits(0).DisplayColumns(75).Width = 40
			.Splits(0).DisplayColumns(76).Width = 40
      .Splits(0).DisplayColumns(77).Width = 90
      .Splits(0).DisplayColumns(78).Width = 90
      .Splits(0).DisplayColumns(79).Width = 90
'
      .Splits(0).DisplayColumns(80).Width = 90
      .Splits(0).DisplayColumns(81).Width = 80
      .Splits(0).DisplayColumns(82).Width = 100
      .Splits(0).DisplayColumns(83).Width = 80
      .Splits(0).DisplayColumns(84).Width = 60
			.Splits(0).DisplayColumns(85).Width = 40
			.Splits(0).DisplayColumns(86).Width = 40
      .Splits(0).DisplayColumns(87).Width = 30
      .Splits(0).DisplayColumns(88).Width = 150
      .Splits(0).DisplayColumns(89).Width = 90

			.Splits(0).DisplayColumns(90).Width = 40
			.Splits(0).DisplayColumns(91).Width = 40
      .Splits(0).DisplayColumns(92).Width = 80
      .Splits(0).DisplayColumns(93).Width = 60

      For I = 0 To 93
        If RbMerged.Checked Then
          .Splits(0).DisplayColumns(I).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.Free
        Else
          .Splits(0).DisplayColumns(I).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.None
        End If
      Next
   End With
End Sub
Public Sub ShowGrid()
  C1DataGrdList.DataSource = ds.Tables(0)
  C1DataGrdList.Refresh()
End Sub
Private Sub RbMerged_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbMerged.Click
  FormatGrid()
End Sub
Private Sub RbNormal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbNormal.Click
  FormatGrid()
End Sub
End Class






