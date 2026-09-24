Public Class FrmUB212B
  Inherits System.Windows.Forms.Form

  Friend ds As DataSet = New DataSet
  Dim Wrkdistr As Decimal
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents DtPckRead As System.Windows.Forms.DateTimePicker
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents RbPerQtr As System.Windows.Forms.RadioButton
  Friend WithEvents RbPerAnnual As System.Windows.Forms.RadioButton
  Friend WithEvents RbSortUsage As System.Windows.Forms.RadioButton
  Friend WithEvents TxtRoute As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents RBSortZone As RadioButton
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
    Me.RbSortUsage = New System.Windows.Forms.RadioButton()
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
    Me.DtPckRead = New System.Windows.Forms.DateTimePicker()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbPerQtr = New System.Windows.Forms.RadioButton()
    Me.RbPerAnnual = New System.Windows.Forms.RadioButton()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtRoute = New System.Windows.Forms.TextBox()
    Me.RBSortZone = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpSorting.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GrpSorting
    '
    Me.GrpSorting.Controls.Add(Me.RBSortZone)
    Me.GrpSorting.Controls.Add(Me.RbSortUsage)
    Me.GrpSorting.Controls.Add(Me.RbSortLocation)
    Me.GrpSorting.Controls.Add(Me.RbSortList)
    Me.GrpSorting.Controls.Add(Me.RbSortName)
    Me.GrpSorting.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpSorting.ForeColor = System.Drawing.Color.Maroon
    Me.GrpSorting.Location = New System.Drawing.Point(248, 8)
    Me.GrpSorting.Name = "GrpSorting"
    Me.GrpSorting.Size = New System.Drawing.Size(128, 143)
    Me.GrpSorting.TabIndex = 7
    Me.GrpSorting.TabStop = False
    Me.GrpSorting.Text = "Sort Order"
    '
    'RbSortUsage
    '
    Me.RbSortUsage.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortUsage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortUsage.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbSortUsage.Location = New System.Drawing.Point(8, 90)
    Me.RbSortUsage.Name = "RbSortUsage"
    Me.RbSortUsage.Size = New System.Drawing.Size(108, 20)
    Me.RbSortUsage.TabIndex = 3
    Me.RbSortUsage.Text = "Usage"
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
    Me.TxtType.TabIndex = 4
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
    Me.Label4.Location = New System.Drawing.Point(11, 108)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(113, 20)
    Me.Label4.TabIndex = 324
    Me.Label4.Text = "Meter Reading Date"
    '
    'DtPckRead
    '
    Me.DtPckRead.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckRead.Location = New System.Drawing.Point(130, 108)
    Me.DtPckRead.Name = "DtPckRead"
    Me.DtPckRead.Size = New System.Drawing.Size(96, 20)
    Me.DtPckRead.TabIndex = 6
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbPerQtr)
    Me.GroupBox2.Controls.Add(Me.RbPerAnnual)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.ForeColor = System.Drawing.Color.Maroon
    Me.GroupBox2.Location = New System.Drawing.Point(383, 8)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(128, 57)
    Me.GroupBox2.TabIndex = 8
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Billing Cycle"
    '
    'RbPerQtr
    '
    Me.RbPerQtr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPerQtr.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbPerQtr.Location = New System.Drawing.Point(8, 32)
    Me.RbPerQtr.Name = "RbPerQtr"
    Me.RbPerQtr.Size = New System.Drawing.Size(76, 16)
    Me.RbPerQtr.TabIndex = 304
    Me.RbPerQtr.Text = "Quarterly"
    '
    'RbPerAnnual
    '
    Me.RbPerAnnual.Checked = True
    Me.RbPerAnnual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPerAnnual.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbPerAnnual.Location = New System.Drawing.Point(8, 16)
    Me.RbPerAnnual.Name = "RbPerAnnual"
    Me.RbPerAnnual.Size = New System.Drawing.Size(60, 16)
    Me.RbPerAnnual.TabIndex = 303
    Me.RbPerAnnual.TabStop = True
    Me.RbPerAnnual.Text = "Annual"
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
    Me.TxtRoute.TabIndex = 326
    '
    'RBSortZone
    '
    Me.RBSortZone.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RBSortZone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RBSortZone.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RBSortZone.Location = New System.Drawing.Point(8, 116)
    Me.RBSortZone.Name = "RBSortZone"
    Me.RBSortZone.Size = New System.Drawing.Size(108, 20)
    Me.RBSortZone.TabIndex = 4
    Me.RBSortZone.Text = "Zone"
    '
    'FrmUB212B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(523, 160)
    Me.ControlBox = False
    Me.Controls.Add(Me.TxtRoute)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.DtPckRead)
    Me.Controls.Add(Me.TxtType)
    Me.Controls.Add(Me.LinkType)
    Me.Controls.Add(Me.TxtPhase)
    Me.Controls.Add(Me.Label44)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.LnkDistrict)
    Me.Controls.Add(Me.GrpSorting)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.MaximizeBox = False
    Me.Name = "FrmUB212B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpSorting.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

Private Sub FrmUB212B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  Wrkdistr = 0
  Wrkdiphas = 0
  DtPckRead.Value = Date.Today
End Sub


Private Sub FrmUB212B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB212.SbpScreen.Text = "UB212B"
  MyFrmUB212.TBarPrint.Enabled = True
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


End Class






