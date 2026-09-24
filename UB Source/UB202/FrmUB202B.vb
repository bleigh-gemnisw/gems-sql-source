Public Class FrmUB202B
  Inherits System.Windows.Forms.Form

  Friend ds As DataSet = New DataSet
  Dim Wrkdistr As Decimal
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents LnkCode As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtCode As System.Windows.Forms.TextBox
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
Friend WithEvents txtphaseto As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents txtdistto As System.Windows.Forms.TextBox
Friend WithEvents LinkDistrictto As System.Windows.Forms.LinkLabel
Friend WithEvents Label1 As System.Windows.Forms.Label
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
    Me.txtphaseto = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.txtdistto = New System.Windows.Forms.TextBox()
    Me.LinkDistrictto = New System.Windows.Forms.LinkLabel()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.LinkType = New System.Windows.Forms.LinkLabel()
    Me.TxtPhase = New System.Windows.Forms.TextBox()
    Me.Label44 = New System.Windows.Forms.Label()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.LnkDistrict = New System.Windows.Forms.LinkLabel()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.LnkCode = New System.Windows.Forms.LinkLabel()
    Me.TxtCode = New System.Windows.Forms.TextBox()
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
    Me.GrpSorting.Size = New System.Drawing.Size(128, 98)
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
    'txtphaseto
    '
    Me.txtphaseto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtphaseto.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtphaseto.Location = New System.Drawing.Point(180, 68)
    Me.txtphaseto.MaxLength = 2
    Me.txtphaseto.Name = "txtphaseto"
    Me.txtphaseto.Size = New System.Drawing.Size(24, 22)
    Me.txtphaseto.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.BackColor = System.Drawing.SystemColors.Control
    Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
    Me.Label2.Location = New System.Drawing.Point(140, 72)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(40, 18)
    Me.Label2.TabIndex = 322
    Me.Label2.Text = "Phase"
    '
    'txtdistto
    '
    Me.txtdistto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtdistto.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtdistto.Location = New System.Drawing.Point(92, 68)
    Me.txtdistto.MaxLength = 3
    Me.txtdistto.Name = "txtdistto"
    Me.txtdistto.Size = New System.Drawing.Size(32, 22)
    Me.txtdistto.TabIndex = 2
    '
    'LinkDistrictto
    '
    Me.LinkDistrictto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LinkDistrictto.Location = New System.Drawing.Point(12, 68)
    Me.LinkDistrictto.Name = "LinkDistrictto"
    Me.LinkDistrictto.Size = New System.Drawing.Size(48, 16)
    Me.LinkDistrictto.TabIndex = 8
    Me.LinkDistrictto.Text = "District"
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
    Me.Label1.Location = New System.Drawing.Point(124, 48)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(31, 17)
    Me.Label1.TabIndex = 321
    Me.Label1.Text = "To"
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtType.Location = New System.Drawing.Point(92, 112)
    Me.TxtType.MaxLength = 2
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(24, 22)
    Me.TxtType.TabIndex = 4
    '
    'LinkType
    '
    Me.LinkType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LinkType.Location = New System.Drawing.Point(12, 112)
    Me.LinkType.Name = "LinkType"
    Me.LinkType.Size = New System.Drawing.Size(64, 16)
    Me.LinkType.TabIndex = 9
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
    Me.LnkDistrict.TabIndex = 7
    Me.LnkDistrict.Text = "District"
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(130, 144)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(50, 13)
    Me.Label8.TabIndex = 355
    Me.Label8.Text = "(optional)"
    '
    'LnkCode
    '
    Me.LnkCode.AutoSize = True
    Me.LnkCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkCode.Location = New System.Drawing.Point(12, 144)
    Me.LnkCode.Name = "LnkCode"
    Me.LnkCode.Size = New System.Drawing.Size(73, 16)
    Me.LnkCode.TabIndex = 10
    Me.LnkCode.Text = "Rate Code"
    '
    'TxtCode
    '
    Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCode.Location = New System.Drawing.Point(92, 140)
    Me.TxtCode.MaxLength = 3
    Me.TxtCode.Name = "TxtCode"
    Me.TxtCode.Size = New System.Drawing.Size(32, 22)
    Me.TxtCode.TabIndex = 5
    '
    'FrmUB202B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(388, 175)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.LnkCode)
    Me.Controls.Add(Me.TxtCode)
    Me.Controls.Add(Me.txtphaseto)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.txtdistto)
    Me.Controls.Add(Me.LinkDistrictto)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtType)
    Me.Controls.Add(Me.LinkType)
    Me.Controls.Add(Me.TxtPhase)
    Me.Controls.Add(Me.Label44)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.LnkDistrict)
    Me.Controls.Add(Me.GrpSorting)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.MaximizeBox = False
    Me.Name = "FrmUB202B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpSorting.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmUB202B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  Wrkdistr = 0
  Wrkdiphas = 0

End Sub


Private Sub FrmUB202B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB202.SbpScreen.Text = "UB202B"
  MyFrmUB202.TBarPrint.Enabled = True
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub LnkDistrict_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDistrict.LinkClicked
  MyFrmListDist = New FrmListDist
  MyFrmListDist.MdiParent = Me.ParentForm
  MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
  MyFrmListDist.WrkPhase = MyUtils.CnvSng(TxtPhase.Text)
  MyFrmListDist.Wrkwhichdist = "F"
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

Private Sub LinkDistrictto_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkDistrictto.LinkClicked
  MyFrmListDist = New FrmListDist
  MyFrmListDist.MdiParent = Me.ParentForm
  MyFrmListDist.WrkDist = MyUtils.CnvSng(txtdistto.Text)
  MyFrmListDist.WrkPhase = MyUtils.CnvSng(txtphaseto.Text)
  MyFrmListDist.Wrkwhichdist = "T"
  MyFrmListDist.Show()
  Me.Hide()
End Sub

Private Sub txtDistto_Keypressed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub txtPhaseto_Keypressed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
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

    If MyUtils.CnvSng(TxtDist.Text) > MyUtils.CnvSng(txtdistto.Text) Then
      ErrorField(I) = "TxtDist"
      ErrorMsg(I) = "Invalid District Range"
      I = I + 1
      ErrorField(I) = "TxtDistTo"
      ErrorMsg(I) = "Invalid District Range"
      I = I + 1
    End If
    If MyUtils.CnvSng(TxtDist.Text) = MyUtils.CnvSng(txtdistto.Text) And _
      MyUtils.CnvSng(TxtPhase.Text) > MyUtils.CnvSng(txtphaseto.Text) Then
      ErrorField(I) = "TxtPhase"
      ErrorMsg(I) = "Invalid Phase Range"
      I = I + 1
    End If

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
    ErrProv.SetError(txtdistto, "")
    ErrProv.SetError(TxtPhase, "")
    ErrProv.SetError(TxtType, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "TxtDist"
        ErrProv.SetError(TxtDist, ErrorMsg(I))
      Case "TxtDistTo"
        ErrProv.SetError(txtdistto, ErrorMsg(I))
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
Private Sub LnkCode_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkCode.LinkClicked
  Dim WrkFamily As String
  WrkFamily = GetUTTYPEFamily(TxtType.Text)
  MyFrmListRates = New FrmListRates
  MyFrmListRates.MdiParent = Me.ParentForm
  MyFrmListRates.WrkFamily = wrkfamily
  MyFrmListRates.WrkUBType = TxtType.Text
  MyFrmListRates.WrkCode = TxtCode.Text
  MyFrmListRates.Show()
  Me.Hide()
End Sub
End Class






