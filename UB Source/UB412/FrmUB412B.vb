Public Class FrmUB412B
Inherits System.Windows.Forms.Form
Dim MyUTTYPE As UTTYPE.myData

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
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TxtPhase As System.Windows.Forms.TextBox
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents ChkAddress As System.Windows.Forms.CheckBox
Friend WithEvents TxtYear As System.Windows.Forms.TextBox
Friend WithEvents DtPckInterest As System.Windows.Forms.DateTimePicker
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents LnkDistrict As System.Windows.Forms.LinkLabel
Friend WithEvents TxtUBType As System.Windows.Forms.TextBox
Friend WithEvents LinkUBType As System.Windows.Forms.LinkLabel
Friend WithEvents GrpSorting As System.Windows.Forms.GroupBox
Friend WithEvents RbSortLocation As System.Windows.Forms.RadioButton
Friend WithEvents RbSortList As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents TxtLocNo As System.Windows.Forms.TextBox
Friend WithEvents TxtLoc As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents ChkZeroBal As System.Windows.Forms.CheckBox
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbReport As System.Windows.Forms.RadioButton
Friend WithEvents RbLetter As System.Windows.Forms.RadioButton
Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TxtDist = New System.Windows.Forms.TextBox
Me.TxtYear = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.TxtPhase = New System.Windows.Forms.TextBox
Me.Label6 = New System.Windows.Forms.Label
Me.TxtUBType = New System.Windows.Forms.TextBox
Me.ChkAddress = New System.Windows.Forms.CheckBox
Me.LinkUBType = New System.Windows.Forms.LinkLabel
Me.DtPckInterest = New System.Windows.Forms.DateTimePicker
Me.Label4 = New System.Windows.Forms.Label
Me.LnkDistrict = New System.Windows.Forms.LinkLabel
Me.GrpSorting = New System.Windows.Forms.GroupBox
Me.RbSortLocation = New System.Windows.Forms.RadioButton
Me.RbSortList = New System.Windows.Forms.RadioButton
Me.RbSortName = New System.Windows.Forms.RadioButton
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.TxtLocNo = New System.Windows.Forms.TextBox
Me.TxtLoc = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.TxtListNo = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.ChkZeroBal = New System.Windows.Forms.CheckBox
Me.Label5 = New System.Windows.Forms.Label
Me.GroupBox2 = New System.Windows.Forms.GroupBox
Me.RbReport = New System.Windows.Forms.RadioButton
Me.RbLetter = New System.Windows.Forms.RadioButton
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GrpSorting.SuspendLayout()
Me.GroupBox1.SuspendLayout()
Me.GroupBox2.SuspendLayout()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'TxtDist
'
Me.TxtDist.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDist.Location = New System.Drawing.Point(120, 64)
Me.TxtDist.MaxLength = 3
Me.TxtDist.Name = "TxtDist"
Me.TxtDist.Size = New System.Drawing.Size(38, 22)
Me.TxtDist.TabIndex = 1
'
'TxtYear
'
Me.TxtYear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtYear.Location = New System.Drawing.Point(120, 16)
Me.TxtYear.MaxLength = 4
Me.TxtYear.Name = "TxtYear"
Me.TxtYear.Size = New System.Drawing.Size(40, 22)
Me.TxtYear.TabIndex = 0
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(12, 20)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(82, 18)
Me.Label3.TabIndex = 52
Me.Label3.Text = "Billing Year*"
'
'TxtPhase
'
Me.TxtPhase.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtPhase.Location = New System.Drawing.Point(208, 64)
Me.TxtPhase.MaxLength = 1
Me.TxtPhase.Name = "TxtPhase"
Me.TxtPhase.Size = New System.Drawing.Size(16, 22)
Me.TxtPhase.TabIndex = 2
'
'Label6
'
Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label6.Location = New System.Drawing.Point(164, 64)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(44, 16)
Me.Label6.TabIndex = 64
Me.Label6.Text = "Phase"
'
'TxtUBType
'
Me.TxtUBType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtUBType.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtUBType.Location = New System.Drawing.Point(120, 88)
Me.TxtUBType.MaxLength = 2
Me.TxtUBType.Name = "TxtUBType"
Me.TxtUBType.Size = New System.Drawing.Size(24, 22)
Me.TxtUBType.TabIndex = 3
'
'ChkAddress
'
Me.ChkAddress.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.ChkAddress.Location = New System.Drawing.Point(8, 148)
Me.ChkAddress.Name = "ChkAddress"
Me.ChkAddress.Size = New System.Drawing.Size(150, 16)
Me.ChkAddress.TabIndex = 5
Me.ChkAddress.Text = "Include Address?"
'
'LinkUBType
'
Me.LinkUBType.Location = New System.Drawing.Point(12, 92)
Me.LinkUBType.Name = "LinkUBType"
Me.LinkUBType.Size = New System.Drawing.Size(68, 16)
Me.LinkUBType.TabIndex = 71
Me.LinkUBType.TabStop = True
Me.LinkUBType.Text = "Bill Type"
'
'DtPckInterest
'
Me.DtPckInterest.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckInterest.Location = New System.Drawing.Point(120, 116)
Me.DtPckInterest.Name = "DtPckInterest"
Me.DtPckInterest.Size = New System.Drawing.Size(96, 20)
Me.DtPckInterest.TabIndex = 4
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(12, 120)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(72, 16)
Me.Label4.TabIndex = 73
Me.Label4.Text = "Interest Date"
'
'LnkDistrict
'
Me.LnkDistrict.Location = New System.Drawing.Point(12, 68)
Me.LnkDistrict.Name = "LnkDistrict"
Me.LnkDistrict.Size = New System.Drawing.Size(40, 16)
Me.LnkDistrict.TabIndex = 297
Me.LnkDistrict.TabStop = True
Me.LnkDistrict.Text = "District"
'
'GrpSorting
'
Me.GrpSorting.Controls.Add(Me.RbSortLocation)
Me.GrpSorting.Controls.Add(Me.RbSortList)
Me.GrpSorting.Controls.Add(Me.RbSortName)
Me.GrpSorting.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GrpSorting.ForeColor = System.Drawing.Color.Maroon
Me.GrpSorting.Location = New System.Drawing.Point(324, 8)
Me.GrpSorting.Name = "GrpSorting"
Me.GrpSorting.Size = New System.Drawing.Size(128, 88)
Me.GrpSorting.TabIndex = 8
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
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.TxtLocNo)
Me.GroupBox1.Controls.Add(Me.TxtLoc)
Me.GroupBox1.Controls.Add(Me.Label2)
Me.GroupBox1.Controls.Add(Me.TxtListNo)
Me.GroupBox1.Controls.Add(Me.Label1)
Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
Me.GroupBox1.Location = New System.Drawing.Point(12, 193)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(277, 65)
Me.GroupBox1.TabIndex = 7
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "Optional Selections"
'
'TxtLocNo
'
Me.TxtLocNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtLocNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtLocNo.Location = New System.Drawing.Point(61, 37)
Me.TxtLocNo.MaxLength = 7
Me.TxtLocNo.Name = "TxtLocNo"
Me.TxtLocNo.Size = New System.Drawing.Size(52, 22)
Me.TxtLocNo.TabIndex = 1
'
'TxtLoc
'
Me.TxtLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtLoc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtLoc.Location = New System.Drawing.Point(117, 37)
Me.TxtLoc.MaxLength = 20
Me.TxtLoc.Name = "TxtLoc"
Me.TxtLoc.Size = New System.Drawing.Size(154, 22)
Me.TxtLoc.TabIndex = 2
'
'Label2
'
Me.Label2.ForeColor = System.Drawing.Color.Black
Me.Label2.Location = New System.Drawing.Point(6, 41)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(49, 16)
Me.Label2.TabIndex = 304
Me.Label2.Text = "Location"
'
'TxtListNo
'
Me.TxtListNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtListNo.Location = New System.Drawing.Point(61, 12)
Me.TxtListNo.MaxLength = 6
Me.TxtListNo.Name = "TxtListNo"
Me.TxtListNo.Size = New System.Drawing.Size(52, 22)
Me.TxtListNo.TabIndex = 0
'
'Label1
'
Me.Label1.ForeColor = System.Drawing.Color.Black
Me.Label1.Location = New System.Drawing.Point(6, 16)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(49, 18)
Me.Label1.TabIndex = 303
Me.Label1.Text = "List #"
'
'ChkZeroBal
'
Me.ChkZeroBal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkZeroBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.ChkZeroBal.Location = New System.Drawing.Point(8, 170)
Me.ChkZeroBal.Name = "ChkZeroBal"
Me.ChkZeroBal.Size = New System.Drawing.Size(150, 17)
Me.ChkZeroBal.TabIndex = 6
Me.ChkZeroBal.Text = "Include Zero Balances?"
'
'Label5
'
Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label5.Location = New System.Drawing.Point(87, 275)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(309, 28)
Me.Label5.TabIndex = 298
Me.Label5.Text = "*Notice: Payoff Bond Interest is calculated based on the latest year previously b" & _
    "illed and Interest Date. "
'
'GroupBox2
'
Me.GroupBox2.Controls.Add(Me.RbReport)
Me.GroupBox2.Controls.Add(Me.RbLetter)
Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox2.ForeColor = System.Drawing.Color.Maroon
Me.GroupBox2.Location = New System.Drawing.Point(324, 102)
Me.GroupBox2.Name = "GroupBox2"
Me.GroupBox2.Size = New System.Drawing.Size(128, 62)
Me.GroupBox2.TabIndex = 299
Me.GroupBox2.TabStop = False
Me.GroupBox2.Text = "Print Format"
'
'RbReport
'
Me.RbReport.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbReport.Checked = True
Me.RbReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbReport.ForeColor = System.Drawing.SystemColors.ControlText
Me.RbReport.Location = New System.Drawing.Point(8, 16)
Me.RbReport.Name = "RbReport"
Me.RbReport.Size = New System.Drawing.Size(108, 20)
Me.RbReport.TabIndex = 0
Me.RbReport.TabStop = True
Me.RbReport.Text = "Report"
'
'RbLetter
'
Me.RbLetter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbLetter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbLetter.ForeColor = System.Drawing.SystemColors.ControlText
Me.RbLetter.Location = New System.Drawing.Point(8, 40)
Me.RbLetter.Name = "RbLetter"
Me.RbLetter.Size = New System.Drawing.Size(108, 20)
Me.RbLetter.TabIndex = 1
Me.RbLetter.Text = "Letter"
'
'FrmUB412B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(456, 312)
Me.ControlBox = False
Me.Controls.Add(Me.GroupBox2)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.ChkZeroBal)
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.GrpSorting)
Me.Controls.Add(Me.LnkDistrict)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.DtPckInterest)
Me.Controls.Add(Me.LinkUBType)
Me.Controls.Add(Me.ChkAddress)
Me.Controls.Add(Me.TxtUBType)
Me.Controls.Add(Me.TxtPhase)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.TxtDist)
Me.Controls.Add(Me.TxtYear)
Me.Controls.Add(Me.Label3)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.KeyPreview = True
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmUB412B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GrpSorting.ResumeLayout(False)
Me.GroupBox1.ResumeLayout(False)
Me.GroupBox1.PerformLayout()
Me.GroupBox2.ResumeLayout(False)
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

  Public Sub RunReport()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    MyUTTYPE = New UTTYPE.mydata(MyDBConnect)

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
Private Sub FrmUB412B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    TxtYear.Text = Date.Now.Year
End Sub
Private Sub FrmUB412B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB412.SbpScreen.Text = "UB412B"
End Sub
Private Sub FrmUB412B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtUBType, "")
    ErrProv.SetError(TxtYear, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "ubtype"
        ErrProv.SetError(TxtUBType, ErrorMsg(I))
      Case "year"
        ErrProv.SetError(TxtYear, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtYear.Text) = 0 Then
      ErrorField(I) = "year"
      ErrorMsg(I) = "Invalid Year"
      I = I + 1
    End If

    MyUTTYPE.GetOneRecordP(TxtUBType.Text)
    If MyUTTYPE.RecordNotFound Then
      ErrorField(I) = "ubtype"
      ErrorMsg(I) = "Invalid Bill Type"
      I = I + 1
    End If

  End Sub
Private Sub TxtYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtPhase_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPhase.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtListNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub LnkDistrict_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDistrict.LinkClicked
  MyFrmListDist = New FrmListDist
  MyFrmListDist.MdiParent = Me.ParentForm
  MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
  MyFrmListDist.WrkPhase = MyUtils.CnvSng(TxtPhase.Text)
  MyFrmListDist.Show()
  Me.Hide()
End Sub
Private Sub LinkUBType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkUBType.LinkClicked
  MyFrmListUBType = New FrmListUBType
  MyFrmListUBType.MdiParent = Me.ParentForm
  MyFrmListUBType.WrkType = TxtUBType.Text
  MyFrmListUBType.Show()
  Me.Hide()
End Sub
End Class






