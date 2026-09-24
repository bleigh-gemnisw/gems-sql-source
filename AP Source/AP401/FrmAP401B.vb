Imports System.Data
Public Class FrmAP401B
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
  Friend WithEvents BtnSelect As System.Windows.Forms.Button
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents TxtVendor As System.Windows.Forms.TextBox
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents TBarSelLoc As System.Windows.Forms.ToolBarButton
  Friend WithEvents LnkVendor As System.Windows.Forms.LinkLabel
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents LnkFundTo As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkFundFrom As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtFundTo As System.Windows.Forms.TextBox
  Friend WithEvents TxtFundFrom As System.Windows.Forms.TextBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents BtnClearAll As System.Windows.Forms.Button
  Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAP401B))
    Me.BtnSelect = New System.Windows.Forms.Button()
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.TxtVendor = New System.Windows.Forms.TextBox()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.LnkVendor = New System.Windows.Forms.LinkLabel()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.LnkFundTo = New System.Windows.Forms.LinkLabel()
    Me.LnkFundFrom = New System.Windows.Forms.LinkLabel()
    Me.TxtFundTo = New System.Windows.Forms.TextBox()
    Me.TxtFundFrom = New System.Windows.Forms.TextBox()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.BtnClearAll = New System.Windows.Forms.Button()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'BtnSelect
    '
    Me.BtnSelect.Location = New System.Drawing.Point(30, 24)
    Me.BtnSelect.Name = "BtnSelect"
    Me.BtnSelect.Size = New System.Drawing.Size(53, 37)
    Me.BtnSelect.TabIndex = 20
    Me.BtnSelect.Text = "Select"
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColSelect = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AlternatingRows = True
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(12, 96)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.MeasurementDevice = C1.Win.C1TrueDBGrid.PrintInfo.MeasurementDeviceEnum.Screen
    Me.C1DataGrdList.PrintInfo.MeasurementPrinterName = Nothing
    Me.C1DataGrdList.Size = New System.Drawing.Size(904, 330)
    Me.C1DataGrdList.TabIndex = 196
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    '
    'TxtVendor
    '
    Me.TxtVendor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVendor.Location = New System.Drawing.Point(263, 6)
    Me.TxtVendor.MaxLength = 7
    Me.TxtVendor.Name = "TxtVendor"
    Me.TxtVendor.Size = New System.Drawing.Size(41, 20)
    Me.TxtVendor.TabIndex = 199
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    Me.ImageList1.Images.SetKeyName(1, "select type_24.png")
    '
    'LnkVendor
    '
    Me.LnkVendor.AutoSize = True
    Me.LnkVendor.Location = New System.Drawing.Point(197, 9)
    Me.LnkVendor.Name = "LnkVendor"
    Me.LnkVendor.Size = New System.Drawing.Size(51, 13)
    Me.LnkVendor.TabIndex = 201
    Me.LnkVendor.TabStop = True
    Me.LnkVendor.Text = "Vendor #"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(342, 36)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(23, 13)
    Me.Label2.TabIndex = 205
    Me.Label2.Text = "To "
    '
    'DtPckFrom
    '
    Me.DtPckFrom.Checked = False
    Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFrom.Location = New System.Drawing.Point(234, 32)
    Me.DtPckFrom.Name = "DtPckFrom"
    Me.DtPckFrom.ShowCheckBox = True
    Me.DtPckFrom.Size = New System.Drawing.Size(102, 20)
    Me.DtPckFrom.TabIndex = 202
    Me.DtPckFrom.Value = New Date(2005, 10, 16, 9, 11, 0, 0)
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(198, 36)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(30, 13)
    Me.Label1.TabIndex = 204
    Me.Label1.Text = "From"
    '
    'LnkFundTo
    '
    Me.LnkFundTo.AutoSize = True
    Me.LnkFundTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFundTo.Location = New System.Drawing.Point(302, 64)
    Me.LnkFundTo.Name = "LnkFundTo"
    Me.LnkFundTo.Size = New System.Drawing.Size(16, 13)
    Me.LnkFundTo.TabIndex = 344
    Me.LnkFundTo.TabStop = True
    Me.LnkFundTo.Text = "to"
    '
    'LnkFundFrom
    '
    Me.LnkFundFrom.AutoSize = True
    Me.LnkFundFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFundFrom.Location = New System.Drawing.Point(197, 65)
    Me.LnkFundFrom.Name = "LnkFundFrom"
    Me.LnkFundFrom.Size = New System.Drawing.Size(31, 13)
    Me.LnkFundFrom.TabIndex = 343
    Me.LnkFundFrom.TabStop = True
    Me.LnkFundFrom.Text = "Fund"
    '
    'TxtFundTo
    '
    Me.TxtFundTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFundTo.Location = New System.Drawing.Point(324, 61)
    Me.TxtFundTo.MaxLength = 3
    Me.TxtFundTo.Name = "TxtFundTo"
    Me.TxtFundTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtFundTo.TabIndex = 342
    '
    'TxtFundFrom
    '
    Me.TxtFundFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFundFrom.Location = New System.Drawing.Point(262, 61)
    Me.TxtFundFrom.MaxLength = 3
    Me.TxtFundFrom.Name = "TxtFundFrom"
    Me.TxtFundFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtFundFrom.TabIndex = 341
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'BtnClearAll
    '
    Me.BtnClearAll.Location = New System.Drawing.Point(526, 24)
    Me.BtnClearAll.Name = "BtnClearAll"
    Me.BtnClearAll.Size = New System.Drawing.Size(131, 37)
    Me.BtnClearAll.TabIndex = 345
    Me.BtnClearAll.Text = "Clear All Selected"
    '
    'DtPckTo
    '
    Me.DtPckTo.Checked = False
    Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTo.Location = New System.Drawing.Point(371, 32)
    Me.DtPckTo.Name = "DtPckTo"
    Me.DtPckTo.ShowCheckBox = True
    Me.DtPckTo.Size = New System.Drawing.Size(102, 20)
    Me.DtPckTo.TabIndex = 346
    Me.DtPckTo.Value = New Date(2005, 10, 16, 9, 11, 0, 0)
    '
    'FrmAP401B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(945, 455)
    Me.ControlBox = False
    Me.Controls.Add(Me.DtPckTo)
    Me.Controls.Add(Me.BtnClearAll)
    Me.Controls.Add(Me.LnkFundTo)
    Me.Controls.Add(Me.LnkFundFrom)
    Me.Controls.Add(Me.TxtFundTo)
    Me.Controls.Add(Me.TxtFundFrom)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.DtPckFrom)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LnkVendor)
    Me.Controls.Add(Me.TxtVendor)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.Controls.Add(Me.BtnSelect)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "FrmAP401B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region
 Dim myAPEOPNL1 As APEOPNL1.MyData
 Dim ds As DataSet = New DataSet
 Dim WrkAnd As String
 Dim WrkOr As String

 Private Sub FrmAP401B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myAPEOPNL1 = New APEOPNL1.MyData()
  myAPEOPNL1.MyDBConn = myDBConnect

  If MyServer = "DB2" Then
   WrkAnd = " *and "
   WrkOr = " *or "
  Else
   WrkAnd = " and "
   WrkOr = " or "
  End If

  DtPckFrom.Value = Date.Today
  DtPckFrom.Checked = False
  DtPckTo.Value = Date.Today
  DtPckTo.Checked = False
  Call FormatGrid()
 End Sub
  Public Sub FormatGrid()

    Call ShowGrid()
    With C1DataGrdList
      .Rebind(True)
      .MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
      .Columns(0).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
      .Columns(0).ValueItems.Values.Clear()
      .Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(0, False)) ' unchecked
      .Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(1, True)) ' checked
      .Columns(0).ValueItems.Translate = True
      .Columns(0).Caption = "Select"
      .Splits(0).DisplayColumns(0).Width = 40
      .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
      .Splits(0).DisplayColumns(1).Visible = False
      .Columns(2).Caption = "Vend#"
      .Splits(0).DisplayColumns(2).Width = 40
      .Columns(3).Caption = "Vendor"
      .Splits(0).DisplayColumns(3).Width = 250
      .Columns(4).Caption = "Invoice"
      .Splits(0).DisplayColumns(4).Width = 125
      .Columns(5).Caption = "Amount"
      .Splits(0).DisplayColumns(5).Width = 70
      .Columns(5).NumberFormat = "###,###,##0.00"
      .Columns(6).Caption = "Open"
      .Splits(0).DisplayColumns(6).Width = 70
      .Columns(6).NumberFormat = "###,###,##0.00"
      .Splits(0).DisplayColumns(7).Visible = False
      .Columns(8).Caption = "Due Date"
      .Splits(0).DisplayColumns(8).Width = 70
      .Columns(8).NumberFormat = "##/##/####"
      .Columns(9).Caption = "Fund"
      .Splits(0).DisplayColumns(9).Width = 40
      '.Columns(9).NumberFormat = "000"
      End With
  End Sub
  Public Sub ShowGrid()
    Dim I As Integer

    ds = myAPEOPNL1.PosDataViewL1(TxtVendor.Text, "", 0, 2000)
    For I = 0 To ds.Tables(0).Rows.Count - 1
      If ds.Tables(0).Rows(I).Item("sltpy") = "1" Then
        ds.Tables(0).Rows(I).Item("wsel") = 1
      End If
    Next
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()
  End Sub
  Private Sub FrmAP401B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmAP401.SbpScreen.Text = "AP401B"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
Public Sub PrintData()
  SetFlag(ds)
  PrtReport(ds)
End Sub
Private Sub BtnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelect.Click
  Dim I As Integer
  Dim WrkDueDate As Date
  Dim WrkFundFrom As Integer
  Dim WrkFundTo As Integer
  Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If

  Windows.Forms.Cursor.Current = Cursors.WaitCursor()
  WrkFundFrom = MyUtils.CnvSng(TxtFundFrom.Text)
  WrkFundTo = MyUtils.CnvSng(TxtFundTo.Text)
  For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
    With ds.Tables(0).Rows(I)
      If TxtVendor.Text <> "" And .Item("vndnr") <> TxtVendor.Text Then
        Continue For
      End If
      If WrkFundFrom > 0 And .Item("fdnbr") < WrkFundFrom Then
        Continue For
      End If
      If WrkFundTo > 0 And .Item("fdnbr") > WrkFundTo Then
        Continue For
      End If
      WrkDueDate = MyUtils.GetDBDateMDY(.Item("duedt"))
      If DtPckFrom.Checked Then
        If DtPckFrom.Value > WrkDueDate Then
          Continue For
        End If
      End If
      If DtPckTo.Checked Then
        If DtPckTo.Value < WrkDueDate Then
          Continue For
        End If
      End If
      .Item("wsel") = 1
    End With
  Next
End Sub
Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtFundFrom.Text) > MyUtils.CnvSng(TxtFundTo.Text) Then
      ErrorField(I) = "fundfrom"
      ErrorMsg(I) = "Invalid Fund Range"
      I = I + 1
      'ErrorField(I) = "fundto"
     ' ErrorMsg(I) = "Invalid Fund Range"
      'I = I + 1
    End If
    If MyUtils.SetDBDate(DtPckFrom.Value) > MyUtils.SetDBDate(DtPckTo.Value) Then
      ErrorField(I) = "date"
      ErrorMsg(I) = "Invalid date Range"
      I = I + 1
    End If

  End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
 Dim I As Integer
 ErrProv.SetError(TxtFundFrom, "")
 ErrProv.SetError(DtPckFrom, "")
 For I = 0 To ErrorField.GetUpperBound(0)
   Select Case ErrorField(I)
   Case "fundfrom"
    ErrProv.SetError(TxtFundFrom, ErrorMsg(I))
   Case "date"
    ErrProv.SetError(DtPckFrom, ErrorMsg(I))
   Case Nothing
    Exit Sub
  End Select
 Next I
End Sub
Private Sub LnkVendor_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkVendor.LinkClicked
  MyFrmListVendor = New FrmListVendor
  MyFrmListVendor.MdiParent = Me.ParentForm
  MyFrmListVendor.WrkCode = TxtVendor.Text
  MyFrmListVendor.Show()
End Sub

Private Sub LnkFundFrom_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFundFrom.LinkClicked
MyFrmListFund = New FrmListFund
  MyFrmListFund.MdiParent = Me.ParentForm
  MyFrmListFund.WrkFund = MyUtils.CnvSng(TxtFundFrom.Text)
  MyFrmListFund.WrkID = "From"
  MyFrmListFund.Show()
  Me.Hide()
End Sub

Private Sub LnkFundTo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFundTo.LinkClicked
MyFrmListFund = New FrmListFund
  MyFrmListFund.MdiParent = Me.ParentForm
  MyFrmListFund.WrkFund = MyUtils.CnvSng(TxtFundTo.Text)
  MyFrmListFund.WrkID = "To"
  MyFrmListFund.Show()
  Me.Hide()
End Sub

Private Sub BtnClearAll_Click(sender As Object, e As EventArgs) Handles BtnClearAll.Click
Dim myAPEOPN As APEOPN.MyData
 myAPEOPN = New APEOPN.MyData()
 myAPEOPN.MyDBConn = myDBConnect
 
Dim ask As MsgBoxResult = MsgBox("Are you sure you want to clear All seleted?", MsgBoxStyle.YesNo)
       If ask = MsgBoxResult.Yes Then
          myAPEOPN.clrselectQry()
          MsgBox("All Selections Cleared!")
         Call FormatGrid()
       End If
End Sub
End Class
