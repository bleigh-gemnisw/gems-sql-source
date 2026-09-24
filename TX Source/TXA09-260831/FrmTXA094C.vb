Public Class FrmTXA094C
  Inherits System.Windows.Forms.Form
  Dim ds2 As DataSet
  Dim dr As DataRow
  Friend WithEvents BtnProcess As System.Windows.Forms.Button
  Friend WithEvents LblPay As System.Windows.Forms.Label
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents TxtEMail As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Dim myTXINV As TXINV.myData
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Dim myTXBATCH As TXBATCH.myData

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
  Friend WithEvents Label34 As System.Windows.Forms.Label
  Friend WithEvents DtPckInt As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTXA094C))
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.Label34 = New System.Windows.Forms.Label()
    Me.DtPckInt = New System.Windows.Forms.DateTimePicker()
    Me.BtnProcess = New System.Windows.Forms.Button()
    Me.LblPay = New System.Windows.Forms.Label()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.TxtEMail = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColMove = False
    Me.C1DataGrdList.AllowColSelect = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(8, 34)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.Size = New System.Drawing.Size(782, 312)
    Me.C1DataGrdList.TabIndex = 6
    Me.C1DataGrdList.Text = "C1TrueDBGrid1"
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    '
    'Label34
    '
    Me.Label34.Location = New System.Drawing.Point(7, 12)
    Me.Label34.Name = "Label34"
    Me.Label34.Size = New System.Drawing.Size(72, 16)
    Me.Label34.TabIndex = 165
    Me.Label34.Text = "Interest Date"
    '
    'DtPckInt
    '
    Me.DtPckInt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckInt.Location = New System.Drawing.Point(98, 8)
    Me.DtPckInt.Name = "DtPckInt"
    Me.DtPckInt.ShowCheckBox = True
    Me.DtPckInt.Size = New System.Drawing.Size(96, 20)
    Me.DtPckInt.TabIndex = 164
    '
    'BtnProcess
    '
    Me.BtnProcess.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.BtnProcess.Location = New System.Drawing.Point(599, 5)
    Me.BtnProcess.Name = "BtnProcess"
    Me.BtnProcess.Size = New System.Drawing.Size(62, 20)
    Me.BtnProcess.TabIndex = 170
    Me.BtnProcess.Text = "Process"
    Me.BtnProcess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnProcess.UseVisualStyleBackColor = True
    '
    'LblPay
    '
    Me.LblPay.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblPay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPay.Location = New System.Drawing.Point(698, 7)
    Me.LblPay.Name = "LblPay"
    Me.LblPay.Size = New System.Drawing.Size(72, 20)
    Me.LblPay.TabIndex = 179
    Me.LblPay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label21
    '
    Me.Label21.AutoSize = True
    Me.Label21.BackColor = System.Drawing.SystemColors.Control
    Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label21.Location = New System.Drawing.Point(667, 9)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(25, 13)
    Me.Label21.TabIndex = 178
    Me.Label21.Text = "Pay"
    Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'TxtEMail
    '
    Me.TxtEMail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtEMail.Location = New System.Drawing.Point(302, 7)
    Me.TxtEMail.MaxLength = 50
    Me.TxtEMail.Name = "TxtEMail"
    Me.TxtEMail.Size = New System.Drawing.Size(241, 20)
    Me.TxtEMail.TabIndex = 180
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(209, 11)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(87, 16)
    Me.Label1.TabIndex = 181
    Me.Label1.Text = "Email receipt to:"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(8, 353)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(260, 13)
    Me.Label2.TabIndex = 182
    Me.Label2.Text = "Click Continue or Close Screen to Add more accounts"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'FrmTXA094C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(802, 371)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtEMail)
    Me.Controls.Add(Me.LblPay)
    Me.Controls.Add(Me.Label21)
    Me.Controls.Add(Me.BtnProcess)
    Me.Controls.Add(Me.Label34)
    Me.Controls.Add(Me.DtPckInt)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXA094C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Pay by Credit (Web)"
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTXA094C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  Windows.Forms.Cursor.Current = Cursors.Default

  myTXINV = New TXINV.mydata(MyDBConnect)
  myTXBATCH = New TXBATCH.mydata(MyDBConnect)

  With MyFrmTXA09
    .TBarView.Enabled = False
    .TBarContinue.Visible = True
  End With

  ds2 = New DataSet
  BuildDS2()
  DtPckInt.Value = MyInterestDate
  DtPckInt.Checked = False
  RemapDS()
  Call FormatGrid()

End Sub
Public Sub FormatGrid()

  With C1DataGrdList
    .Rebind(True)
    .DataSource = ds2.Tables(0)
  End With
  Call ShowGrid()
End Sub
 Public Sub ShowGrid()
  Dim I As Integer
  With C1DataGrdList
    .Rebind(True)
    .FetchRowStyles = True
    .Columns(0).Caption = "Description"
    .Splits(0).DisplayColumns(0).Width = 150
    .Columns(1).Caption = "List #"
    .Splits(0).DisplayColumns(1).Width = 50
    .Columns(2).Caption = "Ty"
    .Splits(0).DisplayColumns(2).Width = 25
    .Columns(3).Caption = "Year"
    .Splits(0).DisplayColumns(3).Width = 35
    .Columns(4).Caption = "Tax"
    .Splits(0).DisplayColumns(4).Width = 70
    .Columns(5).Caption = "Interest"
    .Splits(0).DisplayColumns(5).Width = 70
    .Columns(6).Caption = "Fee"
    .Splits(0).DisplayColumns(6).Width = 40
    .Columns(7).Caption = "Lien"
    .Splits(0).DisplayColumns(7).Width = 40
    .Columns(8).Caption = "Bond"
    .Splits(0).DisplayColumns(8).Width = 60
    .Columns(9).Caption = "Total"
    .Splits(0).DisplayColumns(9).Width = 65
    .Columns(10).Caption = "Balance"
    .Splits(0).DisplayColumns(10).Width = 65
    For I = 0 To 10
      .Splits(0).DisplayColumns(I).Locked = True
      .Splits(0).DisplayColumns(I).Style.BackColor = cLightBlue
    Next
    .Columns(11).Caption = "Pay"
    .Splits(0).DisplayColumns(11).Width = 65
  End With
End Sub
  Private Sub FrmTXA094C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA09.SbpScreen.Text = "TXA094C"
    With MyFrmTXA09
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
Private Sub FrmTXA094C_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
  With MyFrmTXA09
    .TBarView.Enabled = False
    .TBarContinue.Visible = False
  End With

  MyFrmTXA094.Show()
  'Memory Cleanup
  myTXINV.CloseFile()
  myTXINV = Nothing
  MyFrmTXA094C = Nothing
End Sub
  Private Sub BuildDS2()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Tax", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("Fee", Type.GetType("System.Decimal"))
      .Columns.Add("Lien", Type.GetType("System.Decimal"))
      .Columns.Add("Bond", Type.GetType("System.Decimal"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
      .Columns.Add("Balance", Type.GetType("System.Decimal"))
      .Columns.Add("Pay", Type.GetType("System.Decimal"))
    End With
    ds2.Tables.Add(myTable)
  End Sub
Private Sub RemapDS()
  Dim WrkTPay As Decimal
  Dim I As Integer
  Windows.Forms.Cursor.Current = Cursors.WaitCursor()
  ds2.Clear()
  WrkTPay = 0
  For I = 0 To (MydsPayCredit.Tables(0).Rows.Count - 1)
    With MydsPayCredit.Tables(0).Rows(I)
      dr = ds2.Tables(0).NewRow
      dr("desc") = .Item("desc")
      dr("listno") = .Item("listno")
      dr("type") = .Item("type")
      dr("year") = .Item("year")
      dr("tax") = .Item("tax")
      dr("interest") = .Item("interest")
      dr("fee") = .Item("fee")
      dr("lien") = .Item("lien")
      dr("bond") = .Item("bond")
      dr("total") = .Item("total")
      dr("balance") = .Item("balance")
      dr("pay") = .Item("total")
      WrkTPay = WrkTPay + .Item("total")
      ds2.Tables(0).Rows.Add(dr)
    End With
  Next

  LblPay.Text = Format(WrkTPay, "fixed")
  Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub CalcIntDS()
  Dim ListNo As Integer
  Dim Year As Integer
  Dim Type As String
  Dim I As Integer
  Dim WrkPrin As Decimal
  Dim WrkInterest As Decimal
  Dim WrkDiffPrin As Decimal
  Dim WrkDiffInt As Decimal
  Dim WrkTotal As Decimal
  Dim WrkTPay As Decimal

  WrkTPay = 0
  Windows.Forms.Cursor.Current = Cursors.WaitCursor()
  For I = 0 To (ds2.Tables(0).Rows.Count - 1)
    With ds2.Tables(0).Rows(I)
      ListNo = .Item("listno")
      Type = .Item("type")
      Year = .Item("year")
        If myTOWN._TOWNBR = 219 And {"S", "W"}.Contains(Type) Then
          CalcInterest_219SW(ListNo, Type, Year, DtPckInt.Value, WrkPrin, WrkInterest, 0, 0, 0, 0)
        Else
          CalcInterest(ListNo, Type, Year, DtPckInt.Value, WrkPrin, WrkInterest, 0, 0, 0, 0)
        End If
        WrkDiffPrin = WrkPrin - .Item("tax")
        WrkDiffInt = WrkInterest - .Item("interest")
      WrkTotal = .Item("total") + WrkDiffPrin + WrkDiffInt
      If WrkDiffPrin <> 0 Or WrkDiffInt <> 0 Then
        .Item("tax") = Format(WrkPrin, "fixed")
        .Item("Interest") = Format(WrkInterest, "fixed")
        .Item("total") = Format(WrkTotal, "fixed")
        .Item("pay") = Format(WrkTotal, "fixed")
      End If
      WrkTPay = WrkTPay + .Item("pay")
    End With
  Next

  LblPay.Text = Format(WrkTPay, "fixed")
  Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub CalcPayDS()
  Dim I As Integer
  Dim WrkTPay As Decimal

  WrkTPay = 0
  Windows.Forms.Cursor.Current = Cursors.WaitCursor()
  For I = 0 To (ds2.Tables(0).Rows.Count - 1)
    With ds2.Tables(0).Rows(I)
      WrkTPay = WrkTPay + .Item("pay")
    End With
  Next
  LblPay.Text = Format(WrkTPay, "fixed")
  Windows.Forms.Cursor.Current = Cursors.Default
End Sub
  Private Sub DtPckInt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtPckInt.ValueChanged
    CalcIntDS()
  End Sub
  Private Sub C1DataGrdList_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles C1DataGrdList.MouseClick
  CalcPayDS()
End Sub
Private Sub C1DataGrdList_AfterColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles C1DataGrdList.AfterColEdit
  CalcPayDS()
End Sub

Public Sub PayCreditGridItems()
  Dim WrkAcct(100) As String
  Dim WrkAmount(100) As String
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  Dim I As Integer
  Dim J As Integer

  Windows.Forms.Cursor.Current = Cursors.WaitCursor()
  J = -1
  Array.Clear(WrkAcct, 0, 100)
  Array.Clear(WrkAmount, 0, 100)
  For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
    If C1DataGrdList.Item(I, 11) > 0 Then
      J = J + 1
      If J = 100 Then
        MsgBox("Too many transactions. Remove some and retry", MsgBoxStyle.Exclamation, "100 Limit reached")
        Exit Sub
      End If
      WrkAmount(J) = Format(C1DataGrdList.Item(I, 11), "fixed")
      WrkAcct(J) = Mid(C1DataGrdList.Item(I, 3), 3, 2) & _
        C1DataGrdList.Item(I, 2) & C1DataGrdList.Item(I, 1)
    End If
  Next

  If WrkAmount(0) = 0 Then
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End If

  'Write Info record to batch
    'With myTXBATCH
    ' ._JBTCHC = MyBatch
    ' ._JBATCH = MyBatchNo
    ' ._JSEQNO = NextSeqNo
    ' ._JSTAT = "I"
    ' ._LISTNo = WrkListNo
    ' ._YEAR = WrkYear
    ' ._TYPE = WrkType
    ' ._PAMT = 0
    ' ._IAMT = 0
    ' ._LAMT = 0
    ' ._TCAMT = 0
    ' ._CORC = "3"
    ' ._COMM = "Credit Counter"
    ' ._ADJCD = String.Empty
    ' ._JBTCHT = "01"
    ' ._JTCODE = String.Empty
    ' ._JUCODE = String.Empty
    ' ._NAME = LblName.Text
    ' ._CASH = 0
    ' ._CHECK = 0
    ' ._CREDIT = 0
    ' ._ASOFD = 0
    ' ._CPENCD = ""
    ' ._CINTPD = 0
    ' ._JIY = Year(MyInterestOverrideDate)
    ' ._JIM = Month(MyInterestOverrideDate)
    ' ._JID = Microsoft.VisualBasic.DateAndTime.Day(MyInterestOverrideDate)
    ' ._JRY = Year(MyReceiptDate)
    ' ._JRM = Month(MyReceiptDate)
    ' ._JRD = Microsoft.VisualBasic.DateAndTime.Day(MyReceiptDate)
    ' ._SIMT = 0
    ' ._TMSP = 0
    ' ._TBL = 0  'Total of all bills
    ' ._ARC = 0
    ' ._MR = String.Empty
    ' ._AD1 = String.Empty
    ' ._AD2 = String.Empty
    ' ._CY = String.Empty
    ' ._SAT = String.Empty
    ' ._ZI5 = 0
    ' ._ZI4 = 0
    'End With

  MydsPayCredit.Clear()

  MyFrmWeb = New FrmWeb
  'MyFrmWeb.MdiParent = Me.ParentForm
  MyFrmWeb.WrkEmail = TxtEMail.Text
  MyFrmWeb.WrkAcct = WrkAcct
  MyFrmWeb.WrkAmount = WrkAmount
  MyFrmWeb.ShowDialog()
  Me.Hide()
End Sub

Private Sub BtnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProcess.Click
  PayCreditGridItems()
End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(LblPay.Text) = 0 Then
      ErrorField(I) = "pay"
      ErrorMsg(I) = "Amount paid cannot be 0. Enter amount in pay column."
      I = I + 1
    End If
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(LblPay, String.Empty)

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "pay"
        ErrProv.SetError(LblPay, ErrorMsg(I))
      End Select
    Next I
  End Sub
End Class






