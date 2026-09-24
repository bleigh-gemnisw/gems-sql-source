Public Class FrmPO320B
Inherits System.Windows.Forms.Form
  Dim myVENDOR As VENDOR.MyData
  Dim myLOCATN As LOCATN.MyData
  Dim ds As DataSet = New DataSet

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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtAmount As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbSortVName As System.Windows.Forms.RadioButton
  Friend WithEvents RbSortDate As System.Windows.Forms.RadioButton
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents RbStatusClosed As System.Windows.Forms.RadioButton
  Friend WithEvents RbStatusOpen As System.Windows.Forms.RadioButton
  Friend WithEvents RbSortPO As System.Windows.Forms.RadioButton
  Friend WithEvents RbStatusAny As System.Windows.Forms.RadioButton
  Friend WithEvents ChkDetail As System.Windows.Forms.CheckBox
  Friend WithEvents TxtFundTo As System.Windows.Forms.TextBox
  Friend WithEvents LnkFundTo As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtFundFrom As System.Windows.Forms.TextBox
  Friend WithEvents LnkFundFrom As System.Windows.Forms.LinkLabel
  Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
  Friend WithEvents LblLlocndesc As Label
  Friend WithEvents TxtLlocn As TextBox
  Friend WithEvents LblLlocn As LinkLabel
  Friend WithEvents LblVennm As Label
  Friend WithEvents TxtVndnr As TextBox
  Friend WithEvents LnkVndnr As LinkLabel
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtAmount = New System.Windows.Forms.TextBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbSortPO = New System.Windows.Forms.RadioButton()
    Me.RbSortVName = New System.Windows.Forms.RadioButton()
    Me.RbSortDate = New System.Windows.Forms.RadioButton()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbStatusAny = New System.Windows.Forms.RadioButton()
    Me.RbStatusClosed = New System.Windows.Forms.RadioButton()
    Me.RbStatusOpen = New System.Windows.Forms.RadioButton()
    Me.ChkDetail = New System.Windows.Forms.CheckBox()
    Me.TxtFundTo = New System.Windows.Forms.TextBox()
    Me.LnkFundTo = New System.Windows.Forms.LinkLabel()
    Me.TxtFundFrom = New System.Windows.Forms.TextBox()
    Me.LnkFundFrom = New System.Windows.Forms.LinkLabel()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LblVennm = New System.Windows.Forms.Label()
    Me.TxtVndnr = New System.Windows.Forms.TextBox()
    Me.LnkVndnr = New System.Windows.Forms.LinkLabel()
    Me.LblLlocndesc = New System.Windows.Forms.Label()
    Me.TxtLlocn = New System.Windows.Forms.TextBox()
    Me.LblLlocn = New System.Windows.Forms.LinkLabel()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(19, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(60, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "From Date"
    '
    'DtPckFrom
    '
    Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFrom.Location = New System.Drawing.Point(79, 12)
    Me.DtPckFrom.Name = "DtPckFrom"
    Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
    Me.DtPckFrom.TabIndex = 0
    '
    'DtPckTo
    '
    Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTo.Location = New System.Drawing.Point(239, 12)
    Me.DtPckTo.Name = "DtPckTo"
    Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
    Me.DtPckTo.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(187, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(52, 16)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "To Date"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtAmount
    '
    Me.TxtAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAmount.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAmount.Location = New System.Drawing.Point(140, 185)
    Me.TxtAmount.MaxLength = 11
    Me.TxtAmount.Name = "TxtAmount"
    Me.TxtAmount.Size = New System.Drawing.Size(82, 22)
    Me.TxtAmount.TabIndex = 12
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbSortPO)
    Me.GroupBox1.Controls.Add(Me.RbSortVName)
    Me.GroupBox1.Controls.Add(Me.RbSortDate)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(437, 12)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(108, 81)
    Me.GroupBox1.TabIndex = 14
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Sort Options"
    '
    'RbSortPO
    '
    Me.RbSortPO.AutoSize = True
    Me.RbSortPO.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortPO.Location = New System.Drawing.Point(6, 55)
    Me.RbSortPO.Name = "RbSortPO"
    Me.RbSortPO.Size = New System.Drawing.Size(80, 17)
    Me.RbSortPO.TabIndex = 8
    Me.RbSortPO.Text = "PO Number"
    '
    'RbSortVName
    '
    Me.RbSortVName.AutoSize = True
    Me.RbSortVName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortVName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortVName.Location = New System.Drawing.Point(6, 36)
    Me.RbSortVName.Name = "RbSortVName"
    Me.RbSortVName.Size = New System.Drawing.Size(90, 17)
    Me.RbSortVName.TabIndex = 7
    Me.RbSortVName.Text = "Vendor Name"
    '
    'RbSortDate
    '
    Me.RbSortDate.AutoSize = True
    Me.RbSortDate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortDate.Checked = True
    Me.RbSortDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortDate.Location = New System.Drawing.Point(6, 16)
    Me.RbSortDate.Name = "RbSortDate"
    Me.RbSortDate.Size = New System.Drawing.Size(48, 17)
    Me.RbSortDate.TabIndex = 0
    Me.RbSortDate.TabStop = True
    Me.RbSortDate.Text = "Date"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(15, 189)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(119, 13)
    Me.Label3.TabIndex = 355
    Me.Label3.Text = "Greater than or equal to"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbStatusAny)
    Me.GroupBox2.Controls.Add(Me.RbStatusClosed)
    Me.GroupBox2.Controls.Add(Me.RbStatusOpen)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(22, 43)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(217, 38)
    Me.GroupBox2.TabIndex = 2
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Status"
    '
    'RbStatusAny
    '
    Me.RbStatusAny.AutoSize = True
    Me.RbStatusAny.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbStatusAny.Checked = True
    Me.RbStatusAny.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbStatusAny.Location = New System.Drawing.Point(6, 15)
    Me.RbStatusAny.Name = "RbStatusAny"
    Me.RbStatusAny.Size = New System.Drawing.Size(43, 17)
    Me.RbStatusAny.TabIndex = 0
    Me.RbStatusAny.TabStop = True
    Me.RbStatusAny.Text = "Any"
    Me.RbStatusAny.UseVisualStyleBackColor = True
    '
    'RbStatusClosed
    '
    Me.RbStatusClosed.AutoSize = True
    Me.RbStatusClosed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbStatusClosed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbStatusClosed.Location = New System.Drawing.Point(154, 15)
    Me.RbStatusClosed.Name = "RbStatusClosed"
    Me.RbStatusClosed.Size = New System.Drawing.Size(57, 17)
    Me.RbStatusClosed.TabIndex = 2
    Me.RbStatusClosed.Text = "Closed"
    Me.RbStatusClosed.UseVisualStyleBackColor = True
    '
    'RbStatusOpen
    '
    Me.RbStatusOpen.AutoSize = True
    Me.RbStatusOpen.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbStatusOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbStatusOpen.Location = New System.Drawing.Point(77, 15)
    Me.RbStatusOpen.Name = "RbStatusOpen"
    Me.RbStatusOpen.Size = New System.Drawing.Size(51, 17)
    Me.RbStatusOpen.TabIndex = 1
    Me.RbStatusOpen.Text = "Open"
    Me.RbStatusOpen.UseVisualStyleBackColor = True
    '
    'ChkDetail
    '
    Me.ChkDetail.AutoSize = True
    Me.ChkDetail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkDetail.Location = New System.Drawing.Point(12, 213)
    Me.ChkDetail.Name = "ChkDetail"
    Me.ChkDetail.Size = New System.Drawing.Size(89, 17)
    Me.ChkDetail.TabIndex = 13
    Me.ChkDetail.Text = "Show Detail?"
    Me.ChkDetail.UseVisualStyleBackColor = True
    '
    'TxtFundTo
    '
    Me.TxtFundTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFundTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFundTo.Location = New System.Drawing.Point(210, 96)
    Me.TxtFundTo.MaxLength = 3
    Me.TxtFundTo.Name = "TxtFundTo"
    Me.TxtFundTo.Size = New System.Drawing.Size(26, 20)
    Me.TxtFundTo.TabIndex = 6
    '
    'LnkFundTo
    '
    Me.LnkFundTo.AutoSize = True
    Me.LnkFundTo.Location = New System.Drawing.Point(157, 99)
    Me.LnkFundTo.Name = "LnkFundTo"
    Me.LnkFundTo.Size = New System.Drawing.Size(47, 13)
    Me.LnkFundTo.TabIndex = 5
    Me.LnkFundTo.TabStop = True
    Me.LnkFundTo.Text = "To Fund"
    '
    'TxtFundFrom
    '
    Me.TxtFundFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFundFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFundFrom.Location = New System.Drawing.Point(109, 96)
    Me.TxtFundFrom.MaxLength = 3
    Me.TxtFundFrom.Name = "TxtFundFrom"
    Me.TxtFundFrom.Size = New System.Drawing.Size(28, 20)
    Me.TxtFundFrom.TabIndex = 4
    '
    'LnkFundFrom
    '
    Me.LnkFundFrom.AutoSize = True
    Me.LnkFundFrom.Location = New System.Drawing.Point(44, 99)
    Me.LnkFundFrom.Name = "LnkFundFrom"
    Me.LnkFundFrom.Size = New System.Drawing.Size(57, 13)
    Me.LnkFundFrom.TabIndex = 3
    Me.LnkFundFrom.TabStop = True
    Me.LnkFundFrom.Text = "From Fund"
    '
    'LblVennm
    '
    Me.LblVennm.AutoSize = True
    Me.LblVennm.Location = New System.Drawing.Point(160, 129)
    Me.LblVennm.Name = "LblVennm"
    Me.LblVennm.Size = New System.Drawing.Size(84, 13)
    Me.LblVennm.TabIndex = 398
    Me.LblVennm.Text = "<Vendor Name>"
    Me.LblVennm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.LblVennm.UseMnemonic = False
    '
    'TxtVndnr
    '
    Me.TxtVndnr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVndnr.Location = New System.Drawing.Point(109, 126)
    Me.TxtVndnr.MaxLength = 5
    Me.TxtVndnr.Name = "TxtVndnr"
    Me.TxtVndnr.Size = New System.Drawing.Size(45, 20)
    Me.TxtVndnr.TabIndex = 8
    '
    'LnkVndnr
    '
    Me.LnkVndnr.AutoSize = True
    Me.LnkVndnr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkVndnr.ForeColor = System.Drawing.Color.Maroon
    Me.LnkVndnr.Location = New System.Drawing.Point(22, 129)
    Me.LnkVndnr.Name = "LnkVndnr"
    Me.LnkVndnr.Size = New System.Drawing.Size(81, 13)
    Me.LnkVndnr.TabIndex = 7
    Me.LnkVndnr.TabStop = True
    Me.LnkVndnr.Text = "Vendor Number"
    '
    'LblLlocndesc
    '
    Me.LblLlocndesc.AutoSize = True
    Me.LblLlocndesc.Location = New System.Drawing.Point(161, 155)
    Me.LblLlocndesc.Name = "LblLlocndesc"
    Me.LblLlocndesc.Size = New System.Drawing.Size(88, 13)
    Me.LblLlocndesc.TabIndex = 11
    Me.LblLlocndesc.Text = "<Location Desc>"
    Me.LblLlocndesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.LblLlocndesc.UseMnemonic = False
    '
    'TxtLlocn
    '
    Me.TxtLlocn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLlocn.Location = New System.Drawing.Point(110, 152)
    Me.TxtLlocn.MaxLength = 5
    Me.TxtLlocn.Name = "TxtLlocn"
    Me.TxtLlocn.Size = New System.Drawing.Size(45, 20)
    Me.TxtLlocn.TabIndex = 10
    '
    'LblLlocn
    '
    Me.LblLlocn.AutoSize = True
    Me.LblLlocn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLlocn.ForeColor = System.Drawing.Color.Maroon
    Me.LblLlocn.Location = New System.Drawing.Point(23, 155)
    Me.LblLlocn.Name = "LblLlocn"
    Me.LblLlocn.Size = New System.Drawing.Size(48, 13)
    Me.LblLlocn.TabIndex = 9
    Me.LblLlocn.TabStop = True
    Me.LblLlocn.Text = "Location"
    '
    'FrmPO320B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(557, 242)
    Me.ControlBox = False
    Me.Controls.Add(Me.LblLlocndesc)
    Me.Controls.Add(Me.TxtLlocn)
    Me.Controls.Add(Me.LblLlocn)
    Me.Controls.Add(Me.LblVennm)
    Me.Controls.Add(Me.TxtVndnr)
    Me.Controls.Add(Me.LnkVndnr)
    Me.Controls.Add(Me.TxtFundTo)
    Me.Controls.Add(Me.LnkFundTo)
    Me.Controls.Add(Me.TxtFundFrom)
    Me.Controls.Add(Me.LnkFundFrom)
    Me.Controls.Add(Me.ChkDetail)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.TxtAmount)
    Me.Controls.Add(Me.DtPckTo)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.DtPckFrom)
    Me.Controls.Add(Me.Label1)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmPO320B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region
  Private Sub FrmPO320B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myVENDOR = New VENDOR.MyData()
    myVENDOR.MyDBConn = myDBConnect
    myLOCATN = New LOCATN.MyData()
    myLOCATN.MyDBConn = myDBConnect
    DtPckFrom.Value = Date.Today
    DtPckTo.Value = Date.Today
    LblLlocndesc.Text = ""
    LblVennm.Text = ""
  End Sub
  Private Sub FrmPO320B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmPO320.SbpScreen.Text = "PO320B"
  End Sub
  Private Sub FrmPO320B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    'ErrProv.SetError(TxtType, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      'Case "type"
      '  ErrProv.SetError(TxtType, ErrorMsg(I))
      Case Nothing
        Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next
  End Sub

Public Sub RunReport()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If

    Me.Refresh()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    PrtReport()
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub
  Private Sub TxtViol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub LnkFromFund_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFundFrom.LinkClicked
 MyFrmListFund = New FrmListFund
 MyFrmListFund.WrkField = "From"
 MyFrmListFund.WrkFund = MyUtils.CnvSng(TxtFundFrom.Text)
 MyFrmListFund.MdiParent = Me.ParentForm
 MyFrmListFund.Show()
End Sub
Private Sub LnkToFund_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFundTo.LinkClicked
 MyFrmListFund = New FrmListFund
 MyFrmListFund.WrkField = "To"
 MyFrmListFund.WrkFund = MyUtils.CnvSng(TxtFundTo.Text)
 MyFrmListFund.MdiParent = Me.ParentForm
 MyFrmListFund.Show()
End Sub
Private Sub TxtFromFund_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFundFrom.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtToFund_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFundTo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
  Private Sub LnkVndnr_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkVndnr.LinkClicked
    MyFrmListVendor = New FrmListVendor
    MyFrmListVendor.MdiParent = Me.ParentForm
    MyFrmListVendor.WrkCode = TxtVndnr.Text
    MyFrmListVendor.Show()
    Me.Hide()
  End Sub
  Private Function GetVendorName(ByVal Vndnr As String) As String
    myVENDOR.GetOneRecordP(Vndnr)
    With myVENDOR
      If .RecordNotFound Then Return String.Empty
      Return ._VENNM
    End With
  End Function
  Private Sub TxtVndnr_LostFocus(sender As Object, e As EventArgs) Handles TxtVndnr.LostFocus
    LblVennm.Text = GetVendorName(TxtVndnr.Text)
  End Sub
  Private Sub LblLlocn_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LblLlocn.LinkClicked
    MyFrmListLoc = New FrmListLoc
    MyFrmListLoc.MdiParent = Me.ParentForm
    MyFrmListLoc.Show()
    Me.Hide()
  End Sub
  Private Sub TxtLlocn_LostFocus(sender As Object, e As EventArgs) Handles TxtLlocn.LostFocus
    With myLOCATN
      .GetOneRecordP(TxtLlocn.Text)
      If Not .RecordNotFound Then
        LblLlocndesc.Text = ._LDESC
      End If
    End With
  End Sub
End Class
