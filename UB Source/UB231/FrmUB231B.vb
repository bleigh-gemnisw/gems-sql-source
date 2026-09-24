Public Class FrmUB231B
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
Friend WithEvents TxtPhase As System.Windows.Forms.TextBox
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents DtPckNotice As System.Windows.Forms.DateTimePicker
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents LnkDistrict As System.Windows.Forms.LinkLabel
Friend WithEvents TxtUBType As System.Windows.Forms.TextBox
Friend WithEvents LinkUBType As System.Windows.Forms.LinkLabel
Friend WithEvents GrpSorting As System.Windows.Forms.GroupBox
Friend WithEvents RbSortLocation As System.Windows.Forms.RadioButton
Friend WithEvents RbSortList As System.Windows.Forms.RadioButton
Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TxtYear As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents DtPckPayoff As System.Windows.Forms.DateTimePicker
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents TxtRptTitle As System.Windows.Forms.TextBox
Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TxtDist = New System.Windows.Forms.TextBox
Me.TxtPhase = New System.Windows.Forms.TextBox
Me.Label6 = New System.Windows.Forms.Label
Me.TxtUBType = New System.Windows.Forms.TextBox
Me.LinkUBType = New System.Windows.Forms.LinkLabel
Me.DtPckNotice = New System.Windows.Forms.DateTimePicker
Me.Label4 = New System.Windows.Forms.Label
Me.LnkDistrict = New System.Windows.Forms.LinkLabel
Me.GrpSorting = New System.Windows.Forms.GroupBox
Me.RbSortLocation = New System.Windows.Forms.RadioButton
Me.RbSortList = New System.Windows.Forms.RadioButton
Me.RbSortName = New System.Windows.Forms.RadioButton
Me.Label1 = New System.Windows.Forms.Label
Me.TxtListNo = New System.Windows.Forms.TextBox
Me.TxtYear = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
Me.DtPckPayoff = New System.Windows.Forms.DateTimePicker
Me.TxtRptTitle = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GrpSorting.SuspendLayout()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'TxtDist
'
Me.TxtDist.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDist.Location = New System.Drawing.Point(120, 46)
Me.TxtDist.MaxLength = 3
Me.TxtDist.Name = "TxtDist"
Me.TxtDist.Size = New System.Drawing.Size(28, 22)
Me.TxtDist.TabIndex = 1
'
'TxtPhase
'
Me.TxtPhase.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtPhase.Location = New System.Drawing.Point(214, 44)
Me.TxtPhase.MaxLength = 1
Me.TxtPhase.Name = "TxtPhase"
Me.TxtPhase.Size = New System.Drawing.Size(16, 22)
Me.TxtPhase.TabIndex = 2
'
'Label6
'
Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label6.Location = New System.Drawing.Point(164, 46)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(44, 16)
Me.Label6.TabIndex = 64
Me.Label6.Text = "Phase"
'
'TxtUBType
'
Me.TxtUBType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtUBType.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtUBType.Location = New System.Drawing.Point(120, 70)
Me.TxtUBType.MaxLength = 2
Me.TxtUBType.Name = "TxtUBType"
Me.TxtUBType.Size = New System.Drawing.Size(24, 22)
Me.TxtUBType.TabIndex = 3
'
'LinkUBType
'
Me.LinkUBType.Location = New System.Drawing.Point(12, 74)
Me.LinkUBType.Name = "LinkUBType"
Me.LinkUBType.Size = New System.Drawing.Size(68, 16)
Me.LinkUBType.TabIndex = 71
Me.LinkUBType.TabStop = True
Me.LinkUBType.Text = "Bill Type"
'
'DtPckNotice
'
Me.DtPckNotice.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckNotice.Location = New System.Drawing.Point(120, 143)
Me.DtPckNotice.Name = "DtPckNotice"
Me.DtPckNotice.Size = New System.Drawing.Size(96, 20)
Me.DtPckNotice.TabIndex = 4
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(12, 147)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(72, 16)
Me.Label4.TabIndex = 73
Me.Label4.Text = "Notice Date"
'
'LnkDistrict
'
Me.LnkDistrict.Location = New System.Drawing.Point(12, 50)
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
'Label1
'
Me.Label1.Location = New System.Drawing.Point(12, 201)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(84, 16)
Me.Label1.TabIndex = 299
Me.Label1.Text = "List # (optional)"
'
'TxtListNo
'
Me.TxtListNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtListNo.Location = New System.Drawing.Point(120, 197)
Me.TxtListNo.MaxLength = 6
Me.TxtListNo.Name = "TxtListNo"
Me.TxtListNo.Size = New System.Drawing.Size(57, 22)
Me.TxtListNo.TabIndex = 5
'
'TxtYear
'
Me.TxtYear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtYear.Location = New System.Drawing.Point(120, 20)
Me.TxtYear.MaxLength = 4
Me.TxtYear.Name = "TxtYear"
Me.TxtYear.Size = New System.Drawing.Size(39, 22)
Me.TxtYear.TabIndex = 0
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(12, 24)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(84, 16)
Me.Label2.TabIndex = 302
Me.Label2.Text = "Grand List Year"
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(12, 172)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(93, 18)
Me.Label3.TabIndex = 303
Me.Label3.Text = "Payoff valid until"
'
'DtPckPayoff
'
Me.DtPckPayoff.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckPayoff.Location = New System.Drawing.Point(120, 172)
Me.DtPckPayoff.Name = "DtPckPayoff"
Me.DtPckPayoff.Size = New System.Drawing.Size(96, 20)
Me.DtPckPayoff.TabIndex = 304
'
'TxtRptTitle
'
Me.TxtRptTitle.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtRptTitle.Location = New System.Drawing.Point(120, 113)
Me.TxtRptTitle.MaxLength = 40
Me.TxtRptTitle.Name = "TxtRptTitle"
Me.TxtRptTitle.Size = New System.Drawing.Size(277, 22)
Me.TxtRptTitle.TabIndex = 305
'
'Label5
'
Me.Label5.Location = New System.Drawing.Point(12, 117)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(102, 18)
Me.Label5.TabIndex = 306
Me.Label5.Text = "Project Description"
'
'FrmUB231B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(456, 238)
Me.ControlBox = False
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.TxtRptTitle)
Me.Controls.Add(Me.DtPckPayoff)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.TxtYear)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.GrpSorting)
Me.Controls.Add(Me.TxtListNo)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.LnkDistrict)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.DtPckNotice)
Me.Controls.Add(Me.LinkUBType)
Me.Controls.Add(Me.TxtUBType)
Me.Controls.Add(Me.TxtPhase)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.TxtDist)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.KeyPreview = True
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmUB231B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GrpSorting.ResumeLayout(False)
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
Private Sub FrmUB231B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB231.SbpScreen.Text = "UB231B"
End Sub
Private Sub FrmUB231B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtYear, "")
    ErrProv.SetError(TxtUBType, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "year"
        ErrProv.SetError(TxtYear, ErrorMsg(I))
      Case "ubtype"
        ErrProv.SetError(TxtUBType, ErrorMsg(I))
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
      ErrorMsg(I) = "Year is required"
      I = I + 1
    End If

    MyUTTYPE.GetOneRecordP(TxtUBType.Text)
    If MyUTTYPE.RecordNotFound Then
      ErrorField(I) = "ubtype"
      ErrorMsg(I) = "Invalid Bill Type"
      I = I + 1
    End If

  End Sub
Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtPhase_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPhase.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
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

Private Sub FrmUB231B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

End Sub
End Class






