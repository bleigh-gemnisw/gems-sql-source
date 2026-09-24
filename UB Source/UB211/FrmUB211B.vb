Public Class FrmUB211B
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
Friend WithEvents DtPckLien As System.Windows.Forms.DateTimePicker
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
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbRptClerk As System.Windows.Forms.RadioButton
Friend WithEvents RbRptBlanket As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbOrig As System.Windows.Forms.RadioButton
Friend WithEvents RbPayoff As System.Windows.Forms.RadioButton
Friend WithEvents RbRptNotice As System.Windows.Forms.RadioButton
Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
Friend WithEvents RbRptEdit As System.Windows.Forms.RadioButton
Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.TxtPhase = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtUBType = New System.Windows.Forms.TextBox()
    Me.LinkUBType = New System.Windows.Forms.LinkLabel()
    Me.DtPckLien = New System.Windows.Forms.DateTimePicker()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.LnkDistrict = New System.Windows.Forms.LinkLabel()
    Me.GrpSorting = New System.Windows.Forms.GroupBox()
    Me.RbSortLocation = New System.Windows.Forms.RadioButton()
    Me.RbSortList = New System.Windows.Forms.RadioButton()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbRptNotice = New System.Windows.Forms.RadioButton()
    Me.RbRptClerk = New System.Windows.Forms.RadioButton()
    Me.RbRptBlanket = New System.Windows.Forms.RadioButton()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbOrig = New System.Windows.Forms.RadioButton()
    Me.RbPayoff = New System.Windows.Forms.RadioButton()
    Me.ChkPost = New System.Windows.Forms.CheckBox()
    Me.RbRptEdit = New System.Windows.Forms.RadioButton()
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
    Me.TxtDist.Location = New System.Drawing.Point(125, 31)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(28, 22)
    Me.TxtDist.TabIndex = 1
    '
    'TxtPhase
    '
    Me.TxtPhase.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPhase.Location = New System.Drawing.Point(209, 31)
    Me.TxtPhase.MaxLength = 1
    Me.TxtPhase.Name = "TxtPhase"
    Me.TxtPhase.Size = New System.Drawing.Size(16, 22)
    Me.TxtPhase.TabIndex = 2
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(166, 35)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(37, 13)
    Me.Label6.TabIndex = 64
    Me.Label6.Text = "Phase"
    '
    'TxtUBType
    '
    Me.TxtUBType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUBType.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUBType.Location = New System.Drawing.Point(125, 55)
    Me.TxtUBType.MaxLength = 2
    Me.TxtUBType.Name = "TxtUBType"
    Me.TxtUBType.Size = New System.Drawing.Size(24, 22)
    Me.TxtUBType.TabIndex = 3
    '
    'LinkUBType
    '
    Me.LinkUBType.Location = New System.Drawing.Point(35, 59)
    Me.LinkUBType.Name = "LinkUBType"
    Me.LinkUBType.Size = New System.Drawing.Size(68, 16)
    Me.LinkUBType.TabIndex = 71
    Me.LinkUBType.TabStop = True
    Me.LinkUBType.Text = "Bill Type"
    '
    'DtPckLien
    '
    Me.DtPckLien.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckLien.Location = New System.Drawing.Point(125, 84)
    Me.DtPckLien.Name = "DtPckLien"
    Me.DtPckLien.Size = New System.Drawing.Size(88, 20)
    Me.DtPckLien.TabIndex = 4
    Me.DtPckLien.Value = New Date(2016, 9, 21, 0, 0, 0, 0)
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(35, 88)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(72, 16)
    Me.Label4.TabIndex = 73
    Me.Label4.Text = "Lien Date"
    '
    'LnkDistrict
    '
    Me.LnkDistrict.Location = New System.Drawing.Point(35, 35)
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
    Me.GrpSorting.Location = New System.Drawing.Point(261, 4)
    Me.GrpSorting.Name = "GrpSorting"
    Me.GrpSorting.Size = New System.Drawing.Size(90, 88)
    Me.GrpSorting.TabIndex = 6
    Me.GrpSorting.TabStop = False
    Me.GrpSorting.Text = "Sort Order"
    '
    'RbSortLocation
    '
    Me.RbSortLocation.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortLocation.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbSortLocation.Location = New System.Drawing.Point(8, 55)
    Me.RbSortLocation.Name = "RbSortLocation"
    Me.RbSortLocation.Size = New System.Drawing.Size(72, 20)
    Me.RbSortLocation.TabIndex = 2
    Me.RbSortLocation.Text = "Location"
    '
    'RbSortList
    '
    Me.RbSortList.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortList.Checked = True
    Me.RbSortList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortList.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbSortList.Location = New System.Drawing.Point(8, 15)
    Me.RbSortList.Name = "RbSortList"
    Me.RbSortList.Size = New System.Drawing.Size(72, 20)
    Me.RbSortList.TabIndex = 0
    Me.RbSortList.TabStop = True
    Me.RbSortList.Text = "List #"
    '
    'RbSortName
    '
    Me.RbSortName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortName.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbSortName.Location = New System.Drawing.Point(8, 35)
    Me.RbSortName.Name = "RbSortName"
    Me.RbSortName.Size = New System.Drawing.Size(72, 20)
    Me.RbSortName.TabIndex = 1
    Me.RbSortName.Text = "Name"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(35, 116)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(84, 16)
    Me.Label1.TabIndex = 299
    Me.Label1.Text = "List # (optional)"
    '
    'TxtListNo
    '
    Me.TxtListNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtListNo.Location = New System.Drawing.Point(125, 112)
    Me.TxtListNo.MaxLength = 6
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(57, 22)
    Me.TxtListNo.TabIndex = 5
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(125, 5)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(39, 22)
    Me.TxtYear.TabIndex = 0
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(35, 9)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(84, 16)
    Me.Label2.TabIndex = 302
    Me.Label2.Text = "Grand List Year"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbRptEdit)
    Me.GroupBox1.Controls.Add(Me.RbRptNotice)
    Me.GroupBox1.Controls.Add(Me.RbRptClerk)
    Me.GroupBox1.Controls.Add(Me.RbRptBlanket)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
    Me.GroupBox1.Location = New System.Drawing.Point(242, 99)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(109, 106)
    Me.GroupBox1.TabIndex = 303
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Rpt Format"
    '
    'RbRptNotice
    '
    Me.RbRptNotice.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbRptNotice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbRptNotice.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbRptNotice.Location = New System.Drawing.Point(8, 35)
    Me.RbRptNotice.Name = "RbRptNotice"
    Me.RbRptNotice.Size = New System.Drawing.Size(95, 20)
    Me.RbRptNotice.TabIndex = 2
    Me.RbRptNotice.Text = "Lien Notice"
    '
    'RbRptClerk
    '
    Me.RbRptClerk.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbRptClerk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbRptClerk.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbRptClerk.Location = New System.Drawing.Point(8, 55)
    Me.RbRptClerk.Name = "RbRptClerk"
    Me.RbRptClerk.Size = New System.Drawing.Size(95, 17)
    Me.RbRptClerk.TabIndex = 0
    Me.RbRptClerk.Text = "Town Clerk"
    '
    'RbRptBlanket
    '
    Me.RbRptBlanket.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbRptBlanket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbRptBlanket.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbRptBlanket.Location = New System.Drawing.Point(6, 75)
    Me.RbRptBlanket.Name = "RbRptBlanket"
    Me.RbRptBlanket.Size = New System.Drawing.Size(97, 20)
    Me.RbRptBlanket.TabIndex = 1
    Me.RbRptBlanket.Text = "Blanket Lien"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbOrig)
    Me.GroupBox2.Controls.Add(Me.RbPayoff)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.ForeColor = System.Drawing.Color.Maroon
    Me.GroupBox2.Location = New System.Drawing.Point(27, 140)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(198, 41)
    Me.GroupBox2.TabIndex = 304
    Me.GroupBox2.TabStop = False
    '
    'RbOrig
    '
    Me.RbOrig.AutoSize = True
    Me.RbOrig.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbOrig.Checked = True
    Me.RbOrig.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbOrig.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbOrig.Location = New System.Drawing.Point(8, 16)
    Me.RbOrig.Name = "RbOrig"
    Me.RbOrig.Size = New System.Drawing.Size(97, 17)
    Me.RbOrig.TabIndex = 0
    Me.RbOrig.TabStop = True
    Me.RbOrig.Text = "Original Assmnt"
    '
    'RbPayoff
    '
    Me.RbPayoff.AutoSize = True
    Me.RbPayoff.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPayoff.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPayoff.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbPayoff.Location = New System.Drawing.Point(131, 16)
    Me.RbPayoff.Name = "RbPayoff"
    Me.RbPayoff.Size = New System.Drawing.Size(55, 17)
    Me.RbPayoff.TabIndex = 1
    Me.RbPayoff.Text = "Payoff"
    '
    'ChkPost
    '
    Me.ChkPost.AutoSize = True
    Me.ChkPost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkPost.Location = New System.Drawing.Point(27, 188)
    Me.ChkPost.Name = "ChkPost"
    Me.ChkPost.Size = New System.Drawing.Size(109, 17)
    Me.ChkPost.TabIndex = 305
    Me.ChkPost.Text = "Post Lien Codes?"
    '
    'RbRptEdit
    '
    Me.RbRptEdit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbRptEdit.Checked = True
    Me.RbRptEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbRptEdit.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbRptEdit.Location = New System.Drawing.Point(8, 15)
    Me.RbRptEdit.Name = "RbRptEdit"
    Me.RbRptEdit.Size = New System.Drawing.Size(95, 20)
    Me.RbRptEdit.TabIndex = 3
    Me.RbRptEdit.TabStop = True
    Me.RbRptEdit.Text = "Lien Edit"
    '
    'FrmUB211B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(362, 217)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkPost)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.GrpSorting)
    Me.Controls.Add(Me.TxtListNo)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LnkDistrict)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.DtPckLien)
    Me.Controls.Add(Me.LinkUBType)
    Me.Controls.Add(Me.TxtUBType)
    Me.Controls.Add(Me.TxtPhase)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.TxtDist)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmUB211B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpSorting.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
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
Private Sub FrmUB211B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB211.SbpScreen.Text = "UB211B"
End Sub
Private Sub FrmUB211B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
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

Private Sub FrmUB211B_Load(sender As Object, e As EventArgs) Handles MyBase.Load
  DtPckLien.Value = Date.Today
End Sub
End Class






