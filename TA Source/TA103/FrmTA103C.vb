Public Class FrmTA103C
  Inherits System.Windows.Forms.Form
  Dim myTXCODE As TXCODE.MyData
  Friend WrkTxCode As String
  Friend WrkTxType As String
  Friend WithEvents RbNA As System.Windows.Forms.RadioButton
  Friend WithEvents GrpMV As GroupBox
  Friend WithEvents RbMVNA As RadioButton
  Friend WithEvents RBMVExempt As RadioButton
  Friend WithEvents RBMVZero As RadioButton
    Friend WithEvents RbMVMinVal As RadioButton
    Friend TxtGrp As String
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
  Friend WithEvents TxtCode As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtType As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtOPM As System.Windows.Forms.TextBox
  Friend WithEvents GrpGroup As System.Windows.Forms.GroupBox
  Friend WithEvents RbLand As System.Windows.Forms.RadioButton
  Friend WithEvents RbBuildings As System.Windows.Forms.RadioButton
  Friend WithEvents RbOther As System.Windows.Forms.RadioButton
  Friend WithEvents RbIgnore As System.Windows.Forms.RadioButton
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtCode = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.TxtDesc = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtOPM = New System.Windows.Forms.TextBox()
    Me.GrpGroup = New System.Windows.Forms.GroupBox()
    Me.RbNA = New System.Windows.Forms.RadioButton()
    Me.RbIgnore = New System.Windows.Forms.RadioButton()
    Me.RbOther = New System.Windows.Forms.RadioButton()
    Me.RbBuildings = New System.Windows.Forms.RadioButton()
    Me.RbLand = New System.Windows.Forms.RadioButton()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GrpMV = New System.Windows.Forms.GroupBox()
    Me.RbMVNA = New System.Windows.Forms.RadioButton()
    Me.RBMVExempt = New System.Windows.Forms.RadioButton()
    Me.RBMVZero = New System.Windows.Forms.RadioButton()
        Me.RbMVMinVal = New System.Windows.Forms.RadioButton()
        Me.GrpGroup.SuspendLayout()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpMV.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Code"
        '
        'TxtCode
        '
        Me.TxtCode.Location = New System.Drawing.Point(124, 12)
        Me.TxtCode.MaxLength = 3
        Me.TxtCode.Name = "TxtCode"
        Me.TxtCode.Size = New System.Drawing.Size(36, 20)
        Me.TxtCode.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Type"
        '
        'TxtType
        '
        Me.TxtType.Location = New System.Drawing.Point(124, 36)
        Me.TxtType.MaxLength = 1
        Me.TxtType.Name = "TxtType"
        Me.TxtType.Size = New System.Drawing.Size(20, 20)
        Me.TxtType.TabIndex = 1
        '
        'TxtDesc
        '
        Me.TxtDesc.Location = New System.Drawing.Point(124, 84)
        Me.TxtDesc.MaxLength = 30
        Me.TxtDesc.Name = "TxtDesc"
        Me.TxtDesc.Size = New System.Drawing.Size(288, 20)
        Me.TxtDesc.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Description"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "OPM Reporting Code"
        '
        'TxtOPM
        '
        Me.TxtOPM.Location = New System.Drawing.Point(124, 60)
        Me.TxtOPM.MaxLength = 3
        Me.TxtOPM.Name = "TxtOPM"
        Me.TxtOPM.Size = New System.Drawing.Size(36, 20)
        Me.TxtOPM.TabIndex = 2
        '
        'GrpGroup
        '
        Me.GrpGroup.Controls.Add(Me.RbNA)
        Me.GrpGroup.Controls.Add(Me.RbIgnore)
        Me.GrpGroup.Controls.Add(Me.RbOther)
        Me.GrpGroup.Controls.Add(Me.RbBuildings)
        Me.GrpGroup.Controls.Add(Me.RbLand)
        Me.GrpGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpGroup.Location = New System.Drawing.Point(11, 110)
        Me.GrpGroup.Name = "GrpGroup"
        Me.GrpGroup.Size = New System.Drawing.Size(336, 44)
        Me.GrpGroup.TabIndex = 8
        Me.GrpGroup.TabStop = False
        Me.GrpGroup.Text = "Group "
        '
        'RbNA
        '
        Me.RbNA.Checked = True
        Me.RbNA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbNA.Location = New System.Drawing.Point(6, 18)
        Me.RbNA.Name = "RbNA"
        Me.RbNA.Size = New System.Drawing.Size(47, 20)
        Me.RbNA.TabIndex = 4
        Me.RbNA.TabStop = True
        Me.RbNA.Text = "N/A"
        '
        'RbIgnore
        '
        Me.RbIgnore.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbIgnore.Location = New System.Drawing.Point(271, 18)
        Me.RbIgnore.Name = "RbIgnore"
        Me.RbIgnore.Size = New System.Drawing.Size(56, 20)
        Me.RbIgnore.TabIndex = 3
        Me.RbIgnore.Text = "Ignore"
        '
        'RbOther
        '
        Me.RbOther.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbOther.Location = New System.Drawing.Point(207, 18)
        Me.RbOther.Name = "RbOther"
        Me.RbOther.Size = New System.Drawing.Size(52, 20)
        Me.RbOther.TabIndex = 2
        Me.RbOther.Text = "Other"
        '
        'RbBuildings
        '
        Me.RbBuildings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbBuildings.Location = New System.Drawing.Point(127, 18)
        Me.RbBuildings.Name = "RbBuildings"
        Me.RbBuildings.Size = New System.Drawing.Size(68, 20)
        Me.RbBuildings.TabIndex = 1
        Me.RbBuildings.Text = "Buildings"
        '
        'RbLand
        '
        Me.RbLand.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbLand.Location = New System.Drawing.Point(59, 18)
        Me.RbLand.Name = "RbLand"
        Me.RbLand.Size = New System.Drawing.Size(62, 20)
        Me.RbLand.TabIndex = 0
        Me.RbLand.Text = "Land"
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'GrpMV
        '
        Me.GrpMV.Controls.Add(Me.RbMVMinVal)
        Me.GrpMV.Controls.Add(Me.RbMVNA)
        Me.GrpMV.Controls.Add(Me.RBMVExempt)
        Me.GrpMV.Controls.Add(Me.RBMVZero)
        Me.GrpMV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpMV.Location = New System.Drawing.Point(12, 160)
        Me.GrpMV.Name = "GrpMV"
        Me.GrpMV.Size = New System.Drawing.Size(326, 44)
        Me.GrpMV.TabIndex = 9
        Me.GrpMV.TabStop = False
        Me.GrpMV.Text = "MV Install"
        '
        'RbMVNA
        '
        Me.RbMVNA.Checked = True
        Me.RbMVNA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbMVNA.Location = New System.Drawing.Point(6, 18)
        Me.RbMVNA.Name = "RbMVNA"
        Me.RbMVNA.Size = New System.Drawing.Size(47, 20)
        Me.RbMVNA.TabIndex = 4
        Me.RbMVNA.TabStop = True
        Me.RbMVNA.Text = "N/A"
        '
        'RBMVExempt
        '
        Me.RBMVExempt.AutoSize = True
        Me.RBMVExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBMVExempt.Location = New System.Drawing.Point(146, 18)
        Me.RBMVExempt.Name = "RBMVExempt"
        Me.RBMVExempt.Size = New System.Drawing.Size(81, 17)
        Me.RBMVExempt.TabIndex = 1
        Me.RBMVExempt.Text = "Tax Exempt"
        '
        'RBMVZero
        '
        Me.RBMVZero.AutoSize = True
        Me.RBMVZero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBMVZero.Location = New System.Drawing.Point(59, 18)
        Me.RBMVZero.Name = "RBMVZero"
        Me.RBMVZero.Size = New System.Drawing.Size(81, 17)
        Me.RBMVZero.TabIndex = 0
        Me.RBMVZero.Text = "Zero MSRP"
        '
        'RbMVMinVal
        '
        Me.RbMVMinVal.AutoSize = True
        Me.RbMVMinVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbMVMinVal.Location = New System.Drawing.Point(233, 18)
        Me.RbMVMinVal.Name = "RbMVMinVal"
        Me.RbMVMinVal.Size = New System.Drawing.Size(72, 17)
        Me.RbMVMinVal.TabIndex = 5
        Me.RbMVMinVal.Text = "Min Value"
        '
        'FrmTA103C
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(440, 212)
        Me.Controls.Add(Me.GrpMV)
        Me.Controls.Add(Me.GrpGroup)
        Me.Controls.Add(Me.TxtOPM)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtDesc)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtCode)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTA103C"
        Me.Text = "Maintain Tax Codes"
        Me.GrpGroup.ResumeLayout(False)
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpMV.ResumeLayout(False)
        Me.GrpMV.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FrmTA103C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkGroup As String
    Dim WrkMvInst As String
    myTXCODE = New TXCODE.MyData(myDBConnect)
    MyFrmTA103.TBarNew.Enabled = False
    MyFrmTA103.TBarSave.Enabled = True
    If WrkTxCode > 0 Then
      MyFrmTA103.TBarDelete.Enabled = True
      MyUtils.SetTxtReadOnly(TxtCode)
      MyUtils.SetTxtReadOnly(TxtType)
    End If
    myTXCODE.GetOneRecordP(WrkTxCode, WrkTxType)
    TxtCode.Text = WrkTxCode
    TxtType.Text = WrkTxType
    If myTXCODE.RecordNotFound Then Exit Sub

    If s_chg = False And s_full = False Then    '#sec
      MyFrmTA103.TBarSave.Visible = False
    End If
    With myTXCODE
      TxtDesc.Text = Trim(._TCDESC)
      TxtOPM.Text = Trim(._TCOPMC)
      WrkGroup = Trim(._TCGRP)
      Select Case WrkGroup
        Case "B"
          RbBuildings.Checked = True
        Case "I"
          RbIgnore.Checked = True
        Case "L"
          RbLand.Checked = True
        Case "O"
          RbOther.Checked = True
        Case Else
          RbNA.Checked = True
      End Select
      WrkMvInst = Trim(._MVINST)
      Select Case WrkMvInst
        Case "M"
          RbMVMinVal.Checked = True
        Case "N"
          RBMVExempt.Checked = True
        Case "Z"
          RBMVZero.Checked = True
        Case Else
          RbMVNA.Checked = True
      End Select
      If WrkTxType = "M" Then
        GrpMV.Enabled = True
      Else
        GrpMV.Enabled = False
      End If
    End With
  End Sub
  Private Sub FrmTA103C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA103.SbpScreen.Text = "TA103C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub FrmTA103C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTA103.TBarNew.Enabled = True
    MyFrmTA103.TBarDelete.Enabled = False
    MyFrmTA103.TBarSave.Enabled = False
    MyFrmTA103.TBarSave.Visible = True   '#sec
    MyFrmTA103B.FormatGrid()
    MyFrmTA103B.Show()
  End Sub
  Public Sub DeleteData(ByRef Wrkcancel As Boolean)
    Dim Answer As Integer
    Wrkcancel = True
    Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
    If Answer = vbNo Then
      Exit Sub
    End If
    Wrkcancel = False
    myTXCODE.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    myTXCODE.GetOneRecordP(MyUtils.CnvSng(TxtCode.Text), TxtType.Text)
    If WrkTxType = "" Then
      If Not myTXCODE.RecordNotFound Then
        Me.ErrProv.SetError(TxtCode, "Record already exists")
        Exit Sub
      End If
    End If
    If WrkTxType <> "" Then
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXCODE.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      myTXCODE._TCCODE = MyUtils.CnvSng(TxtCode.Text)
      myTXCODE._TCTYPE = TxtType.Text
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXCODE.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()
  End Sub
  Private Sub MovetoFile()
    If TxtGrp Is Nothing Then
      TxtGrp = " "
    End If
    With myTXCODE
      ._TCDESC = TxtDesc.Text
      ._TCOPMC = Val(TxtOPM.Text)
      ._TCGRP = TxtGrp
      ._MVINST = ""
      If RbMVMinVal.Checked Then
        ._MVINST = "M"
      End If
      If RBMVExempt.Checked Then
        ._MVINST = "N"
      End If
      If RBMVZero.Checked Then
        ._MVINST = "Z"
      End If
    End With
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If TxtCode.Text = String.Empty Then
      ErrorField(I) = "tccode"
      ErrorMsg(I) = "Code is required"
      I = I + 1
    End If

    If TxtType.Text = String.Empty Then
      ErrorField(I) = "tctype"
      ErrorMsg(I) = "Type is required"
      I = I + 1
    End If

    If TxtDesc.Text = String.Empty Then
      ErrorField(I) = "tcdesc"
      ErrorMsg(I) = "Description is required"
      I = I + 1
    End If
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtCode, "")
    ErrProv.SetError(TxtType, "")
    ErrProv.SetError(TxtDesc, "")
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "tccode"
          ErrProv.SetError(TxtCode, ErrorMsg(I))
        Case "tctype"
          ErrProv.SetError(TxtType, ErrorMsg(I))
        Case "tcdesc"
          ErrProv.SetError(TxtDesc, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub TxtType_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtType.Leave
    TxtType.Text = UCase(TxtType.Text)
  End Sub
  Private Sub TxtCode_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub RbNA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbNA.CheckedChanged
    TxtGrp = ""
  End Sub

  Private Sub RbOther_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbOther.CheckedChanged
    TxtGrp = "O"
  End Sub

  Private Sub RbLand_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbLand.CheckedChanged
    TxtGrp = "L"
  End Sub

  Private Sub RbBuildings_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbBuildings.CheckedChanged
    TxtGrp = "B"
  End Sub

  Private Sub RbIgnore_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbIgnore.CheckedChanged
    TxtGrp = "I"
  End Sub
  Private Sub TxtOPM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOPM.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
End Class
