Public Class FrmUB213B
  Inherits System.Windows.Forms.Form

  Friend ds As DataSet = New DataSet
  Dim Wrkdistr As Decimal
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtRoute As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents LnkReason As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtReason As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents LnkCode As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtCode As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents LnkMeterSize As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtMeterSize As System.Windows.Forms.TextBox
  Dim Wrkdiphas As Decimal
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
Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents GrpSorting As System.Windows.Forms.GroupBox
Friend WithEvents RbSortLocation As System.Windows.Forms.RadioButton
Friend WithEvents RbSortList As System.Windows.Forms.RadioButton
Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
Friend WithEvents TxtType As System.Windows.Forms.TextBox
Friend WithEvents LinkType As System.Windows.Forms.LinkLabel
Friend WithEvents TxtPhase As System.Windows.Forms.TextBox
Friend WithEvents Label44 As System.Windows.Forms.Label
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents LnkDistrict As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GrpSorting = New System.Windows.Forms.GroupBox()
    Me.RbSortLocation = New System.Windows.Forms.RadioButton()
    Me.RbSortList = New System.Windows.Forms.RadioButton()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.LinkType = New System.Windows.Forms.LinkLabel()
    Me.TxtPhase = New System.Windows.Forms.TextBox()
    Me.Label44 = New System.Windows.Forms.Label()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.LnkDistrict = New System.Windows.Forms.LinkLabel()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtRoute = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.LnkReason = New System.Windows.Forms.LinkLabel()
    Me.TxtReason = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.LnkCode = New System.Windows.Forms.LinkLabel()
    Me.TxtCode = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.LnkMeterSize = New System.Windows.Forms.LinkLabel()
    Me.TxtMeterSize = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpSorting.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GrpSorting
    '
    Me.GrpSorting.Controls.Add(Me.RbSortLocation)
    Me.GrpSorting.Controls.Add(Me.RbSortList)
    Me.GrpSorting.Controls.Add(Me.RbSortName)
    Me.GrpSorting.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpSorting.ForeColor = System.Drawing.Color.Maroon
    Me.GrpSorting.Location = New System.Drawing.Point(248, 8)
    Me.GrpSorting.Name = "GrpSorting"
    Me.GrpSorting.Size = New System.Drawing.Size(128, 92)
    Me.GrpSorting.TabIndex = 6
    Me.GrpSorting.TabStop = False
    Me.GrpSorting.Text = "Sort Order"
    '
    'RbSortLocation
    '
    Me.RbSortLocation.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortLocation.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbSortLocation.Location = New System.Drawing.Point(8, 64)
    Me.RbSortLocation.Name = "RbSortLocation"
    Me.RbSortLocation.Size = New System.Drawing.Size(108, 20)
    Me.RbSortLocation.TabIndex = 2
    Me.RbSortLocation.Text = "Location"
    '
    'RbSortList
    '
    Me.RbSortList.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortList.Checked = True
    Me.RbSortList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortList.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbSortList.Location = New System.Drawing.Point(8, 16)
    Me.RbSortList.Name = "RbSortList"
    Me.RbSortList.Size = New System.Drawing.Size(108, 20)
    Me.RbSortList.TabIndex = 0
    Me.RbSortList.TabStop = True
    Me.RbSortList.Text = "List #"
    '
    'RbSortName
    '
    Me.RbSortName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortName.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbSortName.Location = New System.Drawing.Point(8, 40)
    Me.RbSortName.Name = "RbSortName"
    Me.RbSortName.Size = New System.Drawing.Size(108, 20)
    Me.RbSortName.TabIndex = 1
    Me.RbSortName.Text = "Name"
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtType.Location = New System.Drawing.Point(92, 52)
    Me.TxtType.MaxLength = 2
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(24, 22)
    Me.TxtType.TabIndex = 2
    '
    'LinkType
    '
    Me.LinkType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LinkType.Location = New System.Drawing.Point(12, 52)
    Me.LinkType.Name = "LinkType"
    Me.LinkType.Size = New System.Drawing.Size(64, 16)
    Me.LinkType.TabIndex = 318
    Me.LinkType.TabStop = True
    Me.LinkType.Text = "Bill Type"
    '
    'TxtPhase
    '
    Me.TxtPhase.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPhase.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPhase.Location = New System.Drawing.Point(180, 20)
    Me.TxtPhase.MaxLength = 2
    Me.TxtPhase.Name = "TxtPhase"
    Me.TxtPhase.Size = New System.Drawing.Size(24, 22)
    Me.TxtPhase.TabIndex = 1
    '
    'Label44
    '
    Me.Label44.BackColor = System.Drawing.SystemColors.Control
    Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label44.ForeColor = System.Drawing.SystemColors.WindowText
    Me.Label44.Location = New System.Drawing.Point(140, 24)
    Me.Label44.Name = "Label44"
    Me.Label44.Size = New System.Drawing.Size(40, 16)
    Me.Label44.TabIndex = 320
    Me.Label44.Text = "Phase"
    '
    'TxtDist
    '
    Me.TxtDist.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDist.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(92, 20)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(32, 22)
    Me.TxtDist.TabIndex = 0
    '
    'LnkDistrict
    '
    Me.LnkDistrict.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkDistrict.Location = New System.Drawing.Point(12, 20)
    Me.LnkDistrict.Name = "LnkDistrict"
    Me.LnkDistrict.Size = New System.Drawing.Size(48, 16)
    Me.LnkDistrict.TabIndex = 312
    Me.LnkDistrict.TabStop = True
    Me.LnkDistrict.Text = "District"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(11, 117)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(102, 13)
    Me.Label4.TabIndex = 324
    Me.Label4.Text = "Reading Date: From"
    '
    'DtPckFrom
    '
    Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFrom.Location = New System.Drawing.Point(119, 111)
    Me.DtPckFrom.Name = "DtPckFrom"
    Me.DtPckFrom.Size = New System.Drawing.Size(96, 20)
    Me.DtPckFrom.TabIndex = 4
    '
    'Label1
    '
    Me.Label1.BackColor = System.Drawing.SystemColors.Control
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
    Me.Label1.Location = New System.Drawing.Point(12, 84)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 16)
    Me.Label1.TabIndex = 325
    Me.Label1.Text = "Route"
    '
    'TxtRoute
    '
    Me.TxtRoute.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRoute.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRoute.Location = New System.Drawing.Point(92, 80)
    Me.TxtRoute.MaxLength = 2
    Me.TxtRoute.Name = "TxtRoute"
    Me.TxtRoute.Size = New System.Drawing.Size(24, 22)
    Me.TxtRoute.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(230, 117)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(23, 13)
    Me.Label2.TabIndex = 328
    Me.Label2.Text = "To "
    '
    'DtPckTo
    '
    Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTo.Location = New System.Drawing.Point(256, 111)
    Me.DtPckTo.Name = "DtPckTo"
    Me.DtPckTo.Size = New System.Drawing.Size(96, 20)
    Me.DtPckTo.TabIndex = 5
    '
    'TxtListNo
    '
    Me.TxtListNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtListNo.Location = New System.Drawing.Point(109, 146)
    Me.TxtListNo.MaxLength = 6
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(57, 22)
    Me.TxtListNo.TabIndex = 329
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(12, 150)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(33, 13)
    Me.Label3.TabIndex = 330
    Me.Label3.Text = "List #"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(172, 150)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(50, 13)
    Me.Label5.TabIndex = 331
    Me.Label5.Text = "(optional)"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(122, 84)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(50, 13)
    Me.Label6.TabIndex = 332
    Me.Label6.Text = "(optional)"
    '
    'LnkReason
    '
    Me.LnkReason.AutoSize = True
    Me.LnkReason.Location = New System.Drawing.Point(16, 175)
    Me.LnkReason.Name = "LnkReason"
    Me.LnkReason.Size = New System.Drawing.Size(87, 13)
    Me.LnkReason.TabIndex = 348
    Me.LnkReason.TabStop = True
    Me.LnkReason.Text = "Reading Reason"
    '
    'TxtReason
    '
    Me.TxtReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtReason.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtReason.Location = New System.Drawing.Point(109, 172)
    Me.TxtReason.MaxLength = 3
    Me.TxtReason.Name = "TxtReason"
    Me.TxtReason.Size = New System.Drawing.Size(32, 22)
    Me.TxtReason.TabIndex = 347
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(147, 175)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(50, 13)
    Me.Label7.TabIndex = 349
    Me.Label7.Text = "(optional)"
    '
    'LnkCode
    '
    Me.LnkCode.AutoSize = True
    Me.LnkCode.Location = New System.Drawing.Point(12, 203)
    Me.LnkCode.Name = "LnkCode"
    Me.LnkCode.Size = New System.Drawing.Size(58, 13)
    Me.LnkCode.TabIndex = 351
    Me.LnkCode.TabStop = True
    Me.LnkCode.Text = "Rate Code"
    '
    'TxtCode
    '
    Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCode.Location = New System.Drawing.Point(109, 199)
    Me.TxtCode.MaxLength = 3
    Me.TxtCode.Name = "TxtCode"
    Me.TxtCode.Size = New System.Drawing.Size(32, 22)
    Me.TxtCode.TabIndex = 350
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(147, 203)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(50, 13)
    Me.Label8.TabIndex = 352
    Me.Label8.Text = "(optional)"
    '
    'LnkMeterSize
    '
    Me.LnkMeterSize.Location = New System.Drawing.Point(12, 229)
    Me.LnkMeterSize.Name = "LnkMeterSize"
    Me.LnkMeterSize.Size = New System.Drawing.Size(64, 16)
    Me.LnkMeterSize.TabIndex = 354
    Me.LnkMeterSize.TabStop = True
    Me.LnkMeterSize.Text = "Meter Size"
    '
    'TxtMeterSize
    '
    Me.TxtMeterSize.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMeterSize.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMeterSize.Location = New System.Drawing.Point(109, 225)
    Me.TxtMeterSize.MaxLength = 3
    Me.TxtMeterSize.Name = "TxtMeterSize"
    Me.TxtMeterSize.Size = New System.Drawing.Size(16, 22)
    Me.TxtMeterSize.TabIndex = 353
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(131, 232)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(50, 13)
    Me.Label9.TabIndex = 355
    Me.Label9.Text = "(optional)"
    '
    'FrmUB213B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(390, 257)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.LnkMeterSize)
    Me.Controls.Add(Me.TxtMeterSize)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.LnkCode)
    Me.Controls.Add(Me.TxtCode)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.LnkReason)
    Me.Controls.Add(Me.TxtReason)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtListNo)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.DtPckTo)
    Me.Controls.Add(Me.TxtRoute)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.DtPckFrom)
    Me.Controls.Add(Me.TxtType)
    Me.Controls.Add(Me.LinkType)
    Me.Controls.Add(Me.TxtPhase)
    Me.Controls.Add(Me.Label44)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.LnkDistrict)
    Me.Controls.Add(Me.GrpSorting)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.MaximizeBox = False
    Me.Name = "FrmUB213B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpSorting.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmUB213B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  Wrkdistr = 0
  Wrkdiphas = 0
  DtPckFrom.Value = Date.Today
  DtPckTo.Value = Date.Today

End Sub


Private Sub FrmUB213B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB213.SbpScreen.Text = "UB213B"
  MyFrmUB213.TBarPrint.Enabled = True
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub LnkDistrict_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDistrict.LinkClicked
  MyFrmListDist = New FrmListDist
  MyFrmListDist.MdiParent = Me.ParentForm
  MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
  MyFrmListDist.WrkPhase = MyUtils.CnvSng(TxtPhase.Text)
  MyFrmListDist.Show()
  Me.Hide()
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtPhase_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub LinkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkType.LinkClicked
  MyFrmListUBType = New FrmListUBType
  MyFrmListUBType.MdiParent = Me.ParentForm
  MyFrmListUBType.WrkType = TxtType.Text
  MyFrmListUBType.Show()
  Me.Hide()
End Sub
Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    Dim myUTTYPE As UTTYPE.myData
    Dim dsUTTYPE As DataSet = New DataSet

    myUTTYPE = New UTTYPE.mydata(MyDBConnect)

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    myUTTYPE.GetOneRecordP(TxtType.Text)
    If myUTTYPE.RecordNotFound Then
      ErrorField(I) = "TxtType"
      ErrorMsg(I) = "Invalid Utility Type"
      I = I + 1
    End If

  End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtDist, "")
    ErrProv.SetError(TxtPhase, "")
    ErrProv.SetError(TxtType, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "TxtDist"
        ErrProv.SetError(TxtDist, ErrorMsg(I))
      Case "TxtPhase"
        ErrProv.SetError(TxtPhase, ErrorMsg(I))
      Case "TxtType"
        ErrProv.SetError(TxtType, ErrorMsg(I))
      Case Nothing
        Exit Sub
      End Select
    Next I
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
Private Sub LnkReason_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkReason.LinkClicked
  MyFrmListMResn = New FrmListMResn
  MyFrmListMResn.MdiParent = Me.ParentForm
  MyFrmListMResn.WrkScreen = ""
  MyFrmListMResn.WrkCode = TxtReason.Text
  MyFrmListMResn.Show()
End Sub

Private Sub LnkCode_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkCode.LinkClicked
  MyFrmListRates = New FrmListRates
  MyFrmListRates.MdiParent = Me.ParentForm
  MyFrmListRates.WrkFamily = "M"
  MyFrmListRates.WrkUBType = TxtType.Text
  MyFrmListRates.WrkCode = TxtCode.Text
  MyFrmListRates.Show()
  Me.Hide()
End Sub

Private Sub LnkMeterSize_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkMeterSize.LinkClicked
  MyFrmListMeterSize = New FrmListMeterSize
  MyFrmListMeterSize.MdiParent = Me.ParentForm
  MyFrmListMeterSize.WrkUBType = TxtType.Text
  MyFrmListMeterSize.WrkMeter = TxtMeterSize.Text
  MyFrmListMeterSize.Show()
  Me.Hide()
End Sub
End Class






