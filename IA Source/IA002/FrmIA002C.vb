Imports System.Text
Public Class FrmIA002C

  Inherits System.Windows.Forms.Form

  Dim myGNETGROUP As GNETGROUP.MyData
  Dim myGNETSEC As GNETSEC.MyData
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents ChkAll As System.Windows.Forms.CheckBox
  Friend WithEvents ChkTX As System.Windows.Forms.CheckBox
  Friend WithEvents ChkTA As System.Windows.Forms.CheckBox
  Friend WithEvents ChkPR As System.Windows.Forms.CheckBox
  Friend WithEvents ChkAP As System.Windows.Forms.CheckBox
  Friend WithEvents ChkUB As System.Windows.Forms.CheckBox
  Friend WithEvents ChkFA As System.Windows.Forms.CheckBox
  Friend WithEvents ChkPO As System.Windows.Forms.CheckBox
  Friend WithEvents ChkGL As System.Windows.Forms.CheckBox
  Friend WithEvents LblRights As System.Windows.Forms.Label
  Friend WithEvents ChkPB As System.Windows.Forms.CheckBox
  Friend WithEvents ChkTS As System.Windows.Forms.CheckBox
  Friend WithEvents ChkPS As System.Windows.Forms.CheckBox
  Friend WithEvents ChkIA As System.Windows.Forms.CheckBox
  Friend WithEvents ChkTO As System.Windows.Forms.CheckBox
  Friend WithEvents ChkMR As System.Windows.Forms.CheckBox
  Friend WithEvents ChkBD As System.Windows.Forms.CheckBox
  Friend WithEvents ChkPK As System.Windows.Forms.CheckBox
  Friend WrkGNETGROUP As String
  Friend WithEvents ChkFI As System.Windows.Forms.CheckBox
  Friend WithEvents ChkAR As CheckBox
  Friend WithEvents LblPgms As Label
  Friend WrkCopyGroup As String

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
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents BtnOptions As System.Windows.Forms.Button
  Friend WithEvents TxtGroup As System.Windows.Forms.TextBox
  Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtGroup = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtDesc = New System.Windows.Forms.TextBox()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.BtnOptions = New System.Windows.Forms.Button()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.ChkAR = New System.Windows.Forms.CheckBox()
    Me.ChkFI = New System.Windows.Forms.CheckBox()
    Me.ChkPK = New System.Windows.Forms.CheckBox()
    Me.ChkBD = New System.Windows.Forms.CheckBox()
    Me.ChkMR = New System.Windows.Forms.CheckBox()
    Me.ChkIA = New System.Windows.Forms.CheckBox()
    Me.ChkTO = New System.Windows.Forms.CheckBox()
    Me.ChkTS = New System.Windows.Forms.CheckBox()
    Me.ChkPS = New System.Windows.Forms.CheckBox()
    Me.ChkPB = New System.Windows.Forms.CheckBox()
    Me.LblRights = New System.Windows.Forms.Label()
    Me.ChkPO = New System.Windows.Forms.CheckBox()
    Me.ChkGL = New System.Windows.Forms.CheckBox()
    Me.ChkPR = New System.Windows.Forms.CheckBox()
    Me.ChkAP = New System.Windows.Forms.CheckBox()
    Me.ChkUB = New System.Windows.Forms.CheckBox()
    Me.ChkFA = New System.Windows.Forms.CheckBox()
    Me.ChkAll = New System.Windows.Forms.CheckBox()
    Me.ChkTX = New System.Windows.Forms.CheckBox()
    Me.ChkTA = New System.Windows.Forms.CheckBox()
    Me.LblPgms = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'TxtGroup
    '
    Me.TxtGroup.Location = New System.Drawing.Point(219, 9)
    Me.TxtGroup.MaxLength = 20
    Me.TxtGroup.Name = "TxtGroup"
    Me.TxtGroup.Size = New System.Drawing.Size(200, 20)
    Me.TxtGroup.TabIndex = 0
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(115, 9)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(92, 24)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "Group"
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(107, 41)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(92, 24)
    Me.Label4.TabIndex = 6
    Me.Label4.Text = "Description"
    '
    'TxtDesc
    '
    Me.TxtDesc.Location = New System.Drawing.Point(219, 41)
    Me.TxtDesc.MaxLength = 100
    Me.TxtDesc.Multiline = True
    Me.TxtDesc.Name = "TxtDesc"
    Me.TxtDesc.Size = New System.Drawing.Size(288, 40)
    Me.TxtDesc.TabIndex = 1
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'BtnOptions
    '
    Me.BtnOptions.Location = New System.Drawing.Point(143, 301)
    Me.BtnOptions.Name = "BtnOptions"
    Me.BtnOptions.Size = New System.Drawing.Size(168, 24)
    Me.BtnOptions.TabIndex = 3
    Me.BtnOptions.Text = "Selected Programs Options...."
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.ChkAR)
    Me.GroupBox1.Controls.Add(Me.ChkFI)
    Me.GroupBox1.Controls.Add(Me.ChkPK)
    Me.GroupBox1.Controls.Add(Me.ChkBD)
    Me.GroupBox1.Controls.Add(Me.ChkMR)
    Me.GroupBox1.Controls.Add(Me.ChkIA)
    Me.GroupBox1.Controls.Add(Me.ChkTO)
    Me.GroupBox1.Controls.Add(Me.ChkTS)
    Me.GroupBox1.Controls.Add(Me.ChkPS)
    Me.GroupBox1.Controls.Add(Me.ChkPB)
    Me.GroupBox1.Controls.Add(Me.LblRights)
    Me.GroupBox1.Controls.Add(Me.ChkPO)
    Me.GroupBox1.Controls.Add(Me.ChkGL)
    Me.GroupBox1.Controls.Add(Me.ChkPR)
    Me.GroupBox1.Controls.Add(Me.ChkAP)
    Me.GroupBox1.Controls.Add(Me.ChkUB)
    Me.GroupBox1.Controls.Add(Me.ChkFA)
    Me.GroupBox1.Controls.Add(Me.ChkAll)
    Me.GroupBox1.Controls.Add(Me.ChkTX)
    Me.GroupBox1.Controls.Add(Me.ChkTA)
    Me.GroupBox1.Location = New System.Drawing.Point(143, 87)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(423, 200)
    Me.GroupBox1.TabIndex = 16
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Full Rights (Add/Change/Delete)"
    '
    'ChkAR
    '
    Me.ChkAR.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkAR.Location = New System.Drawing.Point(147, 60)
    Me.ChkAR.Name = "ChkAR"
    Me.ChkAR.Size = New System.Drawing.Size(115, 16)
    Me.ChkAR.TabIndex = 36
    Me.ChkAR.Text = "Accts Recievable"
    Me.ChkAR.UseVisualStyleBackColor = True
    '
    'ChkFI
    '
    Me.ChkFI.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkFI.Location = New System.Drawing.Point(147, 140)
    Me.ChkFI.Name = "ChkFI"
    Me.ChkFI.Size = New System.Drawing.Size(115, 17)
    Me.ChkFI.TabIndex = 35
    Me.ChkFI.Text = "Financials Inquiry"
    Me.ChkFI.UseVisualStyleBackColor = True
    '
    'ChkPK
    '
    Me.ChkPK.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPK.Location = New System.Drawing.Point(291, 80)
    Me.ChkPK.Name = "ChkPK"
    Me.ChkPK.Size = New System.Drawing.Size(115, 18)
    Me.ChkPK.TabIndex = 34
    Me.ChkPK.Text = "Parking Tickets"
    Me.ChkPK.UseVisualStyleBackColor = True
    '
    'ChkBD
    '
    Me.ChkBD.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkBD.Location = New System.Drawing.Point(6, 140)
    Me.ChkBD.Name = "ChkBD"
    Me.ChkBD.Size = New System.Drawing.Size(115, 18)
    Me.ChkBD.TabIndex = 33
    Me.ChkBD.Text = "Building Dept"
    Me.ChkBD.UseVisualStyleBackColor = True
    '
    'ChkMR
    '
    Me.ChkMR.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkMR.Location = New System.Drawing.Point(291, 100)
    Me.ChkMR.Name = "ChkMR"
    Me.ChkMR.Size = New System.Drawing.Size(115, 18)
    Me.ChkMR.TabIndex = 32
    Me.ChkMR.Text = "Misc. Receipts"
    Me.ChkMR.UseVisualStyleBackColor = True
    '
    'ChkIA
    '
    Me.ChkIA.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkIA.Location = New System.Drawing.Point(295, 20)
    Me.ChkIA.Name = "ChkIA"
    Me.ChkIA.Size = New System.Drawing.Size(111, 19)
    Me.ChkIA.TabIndex = 31
    Me.ChkIA.Text = "Security (IA)"
    Me.ChkIA.UseVisualStyleBackColor = True
    '
    'ChkTO
    '
    Me.ChkTO.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkTO.Location = New System.Drawing.Point(6, 80)
    Me.ChkTO.Name = "ChkTO"
    Me.ChkTO.Size = New System.Drawing.Size(115, 19)
    Me.ChkTO.TabIndex = 30
    Me.ChkTO.Text = "OPM Reports"
    Me.ChkTO.UseVisualStyleBackColor = True
    '
    'ChkTS
    '
    Me.ChkTS.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkTS.Location = New System.Drawing.Point(291, 40)
    Me.ChkTS.Name = "ChkTS"
    Me.ChkTS.Size = New System.Drawing.Size(115, 18)
    Me.ChkTS.TabIndex = 29
    Me.ChkTS.Text = "Transfer Station"
    Me.ChkTS.UseVisualStyleBackColor = True
    '
    'ChkPS
    '
    Me.ChkPS.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPS.Location = New System.Drawing.Point(6, 120)
    Me.ChkPS.Name = "ChkPS"
    Me.ChkPS.Size = New System.Drawing.Size(115, 18)
    Me.ChkPS.TabIndex = 28
    Me.ChkPS.Text = "Parking Stickers"
    Me.ChkPS.UseVisualStyleBackColor = True
    '
    'ChkPB
    '
    Me.ChkPB.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPB.Location = New System.Drawing.Point(147, 20)
    Me.ChkPB.Name = "ChkPB"
    Me.ChkPB.Size = New System.Drawing.Size(115, 17)
    Me.ChkPB.TabIndex = 27
    Me.ChkPB.Text = "*Public Access"
    Me.ChkPB.UseVisualStyleBackColor = True
    '
    'LblRights
    '
    Me.LblRights.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblRights.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblRights.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblRights.Location = New System.Drawing.Point(86, 169)
    Me.LblRights.Name = "LblRights"
    Me.LblRights.Size = New System.Drawing.Size(260, 16)
    Me.LblRights.TabIndex = 26
    Me.LblRights.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'ChkPO
    '
    Me.ChkPO.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPO.Location = New System.Drawing.Point(147, 120)
    Me.ChkPO.Name = "ChkPO"
    Me.ChkPO.Size = New System.Drawing.Size(115, 19)
    Me.ChkPO.TabIndex = 25
    Me.ChkPO.Text = "Purchase Orders"
    Me.ChkPO.UseVisualStyleBackColor = True
    '
    'ChkGL
    '
    Me.ChkGL.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkGL.Location = New System.Drawing.Point(147, 100)
    Me.ChkGL.Name = "ChkGL"
    Me.ChkGL.Size = New System.Drawing.Size(115, 17)
    Me.ChkGL.TabIndex = 24
    Me.ChkGL.Text = "General Ledger"
    Me.ChkGL.UseVisualStyleBackColor = True
    '
    'ChkPR
    '
    Me.ChkPR.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPR.Location = New System.Drawing.Point(147, 80)
    Me.ChkPR.Name = "ChkPR"
    Me.ChkPR.Size = New System.Drawing.Size(115, 16)
    Me.ChkPR.TabIndex = 23
    Me.ChkPR.Text = "Payroll"
    Me.ChkPR.UseVisualStyleBackColor = True
    '
    'ChkAP
    '
    Me.ChkAP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkAP.Location = New System.Drawing.Point(147, 40)
    Me.ChkAP.Name = "ChkAP"
    Me.ChkAP.Size = New System.Drawing.Size(115, 16)
    Me.ChkAP.TabIndex = 22
    Me.ChkAP.Text = "Accts Payable"
    Me.ChkAP.UseVisualStyleBackColor = True
    '
    'ChkUB
    '
    Me.ChkUB.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkUB.Location = New System.Drawing.Point(6, 100)
    Me.ChkUB.Name = "ChkUB"
    Me.ChkUB.Size = New System.Drawing.Size(115, 19)
    Me.ChkUB.TabIndex = 21
    Me.ChkUB.Text = "Utility Billing"
    Me.ChkUB.UseVisualStyleBackColor = True
    '
    'ChkFA
    '
    Me.ChkFA.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkFA.Location = New System.Drawing.Point(291, 60)
    Me.ChkFA.Name = "ChkFA"
    Me.ChkFA.Size = New System.Drawing.Size(115, 19)
    Me.ChkFA.TabIndex = 20
    Me.ChkFA.Text = "Fixed Assets"
    Me.ChkFA.UseVisualStyleBackColor = True
    '
    'ChkAll
    '
    Me.ChkAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkAll.Location = New System.Drawing.Point(6, 20)
    Me.ChkAll.Name = "ChkAll"
    Me.ChkAll.Size = New System.Drawing.Size(115, 17)
    Me.ChkAll.TabIndex = 19
    Me.ChkAll.Text = "*All Apps"
    Me.ChkAll.UseVisualStyleBackColor = True
    '
    'ChkTX
    '
    Me.ChkTX.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkTX.Location = New System.Drawing.Point(6, 60)
    Me.ChkTX.Name = "ChkTX"
    Me.ChkTX.Size = New System.Drawing.Size(115, 19)
    Me.ChkTX.TabIndex = 18
    Me.ChkTX.Text = "Tax Collector"
    Me.ChkTX.UseVisualStyleBackColor = True
    '
    'ChkTA
    '
    Me.ChkTA.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkTA.Location = New System.Drawing.Point(6, 40)
    Me.ChkTA.Name = "ChkTA"
    Me.ChkTA.Size = New System.Drawing.Size(115, 19)
    Me.ChkTA.TabIndex = 17
    Me.ChkTA.Text = "Assessor"
    Me.ChkTA.UseVisualStyleBackColor = True
    '
    'LblPgms
    '
    Me.LblPgms.Location = New System.Drawing.Point(15, 330)
    Me.LblPgms.Name = "LblPgms"
    Me.LblPgms.Size = New System.Drawing.Size(626, 94)
    Me.LblPgms.TabIndex = 17
    Me.LblPgms.Text = "<Programs>"
    '
    'FrmIA002C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(653, 433)
    Me.Controls.Add(Me.LblPgms)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.BtnOptions)
    Me.Controls.Add(Me.TxtDesc)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtGroup)
    Me.Controls.Add(Me.Label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmIA002C"
    Me.Text = "Maintain Group Id"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmIA002C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim ds As DataSet = New DataSet
    Dim WrkPgms As String
    Dim I As Integer
    myGNETGROUP = New GNETGROUP.MyData()
    myGNETGROUP.MyDBConn = myDBConnect
    myGNETSEC = New GNETSEC.MyData()
    myGNETSEC.MyDBConn = myDBConnect

    MyFrmIA002.TBarCopy.Enabled = False
    MyFrmIA002.TBarNew.Enabled = False
    MyFrmIA002.TBarSave.Enabled = True
    If WrkGNETGROUP > "" Then
      MyFrmIA002.TBarDelete.Enabled = True
      TxtGroup.ReadOnly = True
      TxtGroup.TabStop = False
    End If
    MyFrmIA002.TBarPrint.Enabled = True

    If WrkCopyGroup = "" Then
      myGNETGROUP.GetOneRecordP(WrkGNETGROUP)
      TxtGroup.Text = WrkGNETGROUP
    Else
      MsgBox("To copy program options, click selected program options and change as needed then save options and then save group. Clicking options again will reset them all.", vbInformation, "Copy mode")
      myGNETGROUP.GetOneRecordP(WrkCopyGroup)
      TxtGroup.Text = ""
    End If
    If myGNETGROUP.RecordNotFound Then
      Exit Sub
    End If
    If s_chg = False And s_full = False Then    '#sec
      MyFrmIA002.TBarSave.Visible = False
    End If

    With myGNETGROUP
      LblRights.Text = Trim(._GRIGHT)
      TxtDesc.Text = Trim(._GDESC)
      ChkAll.Checked = ChkRights("**")
      ChkPB.Checked = ChkRights("PB")
      ChkAR.Checked = ChkRights("AR")
      ChkAP.Checked = ChkRights("AP")
      ChkBD.Checked = ChkRights("BD")
      ChkFA.Checked = ChkRights("FA")
      ChkFI.Checked = ChkRights("FI")
      ChkGL.Checked = ChkRights("GL")
      ChkIA.Checked = ChkRights("IA")
      ChkMR.Checked = ChkRights("MR")
      ChkPK.Checked = ChkRights("PK")
      ChkPO.Checked = ChkRights("PO")
      ChkPR.Checked = ChkRights("PR")
      ChkPS.Checked = ChkRights("PS")
      ChkTA.Checked = ChkRights("TA")
      ChkTO.Checked = ChkRights("TO")
      ChkTS.Checked = ChkRights("TS")
      ChkTX.Checked = ChkRights("TX")
      ChkUB.Checked = ChkRights("UB")
    End With

    WrkPgms = ""
    ds = myGNETSEC.PosData(Trim(WrkGNETGROUP), "")
    If ds.Tables(0).Rows.Count > 0 Then
      For I = 0 To ds.Tables(0).Rows.Count - 1
        If Trim(WrkGNETGROUP) <> Trim(ds.Tables(0).Rows(I).Item("grpid")) Then
          Exit For
        End If
        WrkPgms = WrkPgms & Trim(ds.Tables(0).Rows(I).Item("pgmid")) & " "
      Next
    End If
    lblPgms.text = WrkPgms
  End Sub

  Private Sub FrmIA002C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmIA002.SbpScreen.Text = "IA002C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub

  Private Sub FrmIA002C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmIA002.TBarCopy.Enabled = True
    MyFrmIA002.TBarNew.Enabled = True
    MyFrmIA002.TBarDelete.Enabled = False
    MyFrmIA002.TBarSave.Enabled = False
    MyFrmIA002.TBarSave.Visible = True
    MyFrmIA002B.FormatGrid()
    MyFrmIA002B.Show()
  End Sub
  Public Sub DeleteData(ByRef WrkCancel As Boolean)
    Dim Answer As Integer
    WrkCancel = True
    Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
    If Answer = vbNo Then
      Exit Sub
    End If
    WrkCancel = False
    myGNETGROUP.DeleteOneRecordP()
    Me.Close()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    myGNETGROUP.GetOneRecordP(TxtGroup.Text)
    If WrkGNETGROUP = "" Then
      If Not myGNETGROUP.RecordNotFound Then
        Me.ErrProv.SetError(TxtGroup, "Record already exists")
        Exit Sub
      End If
    End If
    If WrkGNETGROUP <> "" Then
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myGNETGROUP.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      myGNETGROUP._GGROUP = TxtGroup.Text
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myGNETGROUP.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()

  End Sub
  Private Sub MovetoFile()
    With myGNETGROUP
      ._GDESC = TxtDesc.Text
      ._GRIGHT = LblRights.Text
    End With
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    'Dim Pos As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If TxtGroup.Text = String.Empty Then
      ErrorField(I) = "group"
      ErrorMsg(I) = "Group ID is required"
      I = I + 1
    End If

    If TxtDesc.Text = String.Empty Then
      ErrorField(I) = "desc"
      ErrorMsg(I) = "Description is required"
      I = I + 1
    End If
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGroup, "")
    ErrProv.SetError(TxtDesc, "")
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "group"
          ErrProv.SetError(TxtGroup, ErrorMsg(I))
        Case "desc"
          ErrProv.SetError(TxtDesc, ErrorMsg(I))
        Case ""
          Exit Sub
      End Select
    Next I
  End Sub

  Private Sub BtnOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOptions.Click
    If Trim(TxtGroup.Text) = "" Then
      MsgBox("Group name is required", vbExclamation, "Group name")
    Else
      MyFrmIA002D = New FrmIA002D
      MyFrmIA002D.MdiParent = Me.ParentForm
      MyFrmIA002D.WrkGroup = TxtGroup.Text
      MyFrmIA002D.WrkWKGNETSEC = TxtGroup.Text
      MyFrmIA002D.WrkCopyGroup = WrkCopyGroup
      MyFrmIA002D.Show()
      MyFrmIA002C.Hide()
    End If
  End Sub
  Private Sub ChkAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkAll.Click
    If ChkAll.Checked Then
      LblRights.Text = "**"
      ChkPB.Checked = False
      ChkAR.Checked = False
      ChkAP.Checked = False
      ChkBD.Checked = False
      ChkFA.Checked = False
      ChkFI.Checked = False
      ChkGL.Checked = False
      ChkIA.Checked = False
      ChkMR.Checked = False
      ChkPK.Checked = False
      ChkPO.Checked = False
      ChkPR.Checked = False
      ChkPS.Checked = False
      ChkTA.Checked = False
      ChkTO.Checked = False
      ChkTS.Checked = False
      ChkTX.Checked = False
      ChkUB.Checked = False
      ProtectFields(True)
    Else
      LblRights.Text = String.Empty
      ProtectFields(False)
    End If
  End Sub
  Private Sub ChkPB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkPB.Click
    If ChkPB.Checked Then
      LblRights.Text = "PB"
      ChkAll.Checked = False
      ChkAR.Checked = False
      ChkAP.Checked = False
      ChkBD.Checked = False
      ChkFA.Checked = False
      ChkFI.Checked = False
      ChkIA.Checked = False
      ChkGL.Checked = False
      ChkMR.Checked = False
      ChkPK.Checked = False
      ChkPO.Checked = False
      ChkPR.Checked = False
      ChkPS.Checked = False
      ChkTA.Checked = False
      ChkTO.Checked = False
      ChkTS.Checked = False
      ChkTX.Checked = False
      ChkUB.Checked = False
      ProtectFields(True)
    Else
      LblRights.Text = String.Empty
      ProtectFields(False)
    End If
  End Sub
  Private Sub ChkAR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkAR.Click
    If ChkAR.Checked Then
      ChangeRights("AR", True)
    Else
      ChangeRights("AR", False)
    End If
  End Sub
  Private Sub ChkAP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkAP.Click
    If ChkAP.Checked Then
      ChangeRights("AP", True)
    Else
      ChangeRights("AP", False)
    End If
  End Sub
  Private Sub ChkBD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkBD.Click
    If ChkBD.Checked Then
      ChangeRights("BD", True)
    Else
      ChangeRights("BD", False)
    End If
  End Sub
  Private Sub ChkFA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkFA.Click
    If ChkFA.Checked Then
      ChangeRights("FA", True)
    Else
      ChangeRights("FA", False)
    End If
  End Sub
  Private Sub ChkFI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkFI.Click
    If ChkFI.Checked Then
      ChangeRights("FI", True)
    Else
      ChangeRights("FI", False)
    End If
  End Sub
  Private Sub ChkGL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkGL.Click
    If ChkGL.Checked Then
      ChangeRights("GL", True)
    Else
      ChangeRights("GL", False)
    End If
  End Sub
  Private Sub ChkIA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkIA.Click
    If ChkIA.Checked Then
      ChangeRights("IA", True)
    Else
      ChangeRights("IA", False)
    End If
  End Sub
  Private Sub ChkMR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkMR.Click
    If ChkMR.Checked Then
      ChangeRights("MR", True)
    Else
      ChangeRights("MR", False)
    End If
  End Sub
  Private Sub ChkPK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkPK.Click
    If ChkPK.Checked Then
      ChangeRights("PK", True)
    Else
      ChangeRights("PK", False)
    End If
  End Sub
  Private Sub ChkPO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkPO.Click
    If ChkPO.Checked Then
      ChangeRights("PO", True)
    Else
      ChangeRights("PO", False)
    End If
  End Sub
  Private Sub ChkPR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkPR.Click
    If ChkPR.Checked Then
      ChangeRights("PR", True)
    Else
      ChangeRights("PR", False)
    End If
  End Sub
  Private Sub ChkPS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkPS.Click
    If ChkPS.Checked Then
      ChangeRights("PS", True)
    Else
      ChangeRights("PS", False)
    End If
  End Sub
  Private Sub ChkTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkTA.Click
    If ChkTA.Checked Then
      ChangeRights("TA", True)
    Else
      ChangeRights("TA", False)
    End If
  End Sub
  Private Sub ChkTO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkTO.Click
    If ChkTO.Checked Then
      ChangeRights("TO", True)
    Else
      ChangeRights("TO", False)
    End If
  End Sub
  Private Sub ChkTS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkTS.Click
    If ChkTS.Checked Then
      ChangeRights("TS", True)
    Else
      ChangeRights("TS", False)
    End If
  End Sub
  Private Sub ChkTX_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkTX.Click
    If ChkTX.Checked Then
      ChangeRights("TX", True)
    Else
      ChangeRights("TX", False)
    End If
  End Sub
  Private Sub ChkUB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkUB.Click
    If ChkUB.Checked Then
      ChangeRights("UB", True)
    Else
      ChangeRights("UB", False)
    End If
  End Sub
  Private Function ChkRights(ByVal AppID As String) As Boolean
    Dim Pos As Integer

    Pos = InStr(LblRights.Text, AppID)
    If Pos > 0 Then
      Return True
    End If

    Return False
  End Function
  Private Sub ChangeRights(ByVal AppID As String, ByVal IsChecked As Boolean)
    If IsChecked Then
      If LblRights.Text <> String.Empty Then
        LblRights.Text = LblRights.Text & ";" & AppID
      Else
        LblRights.Text = AppID
      End If
    Else
      LblRights.Text = Replace(LblRights.Text, AppID & ";", String.Empty)
      LblRights.Text = Replace(LblRights.Text, ";" & AppID, String.Empty)
      LblRights.Text = Replace(LblRights.Text, AppID, String.Empty)
    End If
  End Sub
  Private Sub ProtectFields(ByVal IsDisabled As Boolean)

    If IsDisabled Then
      ChkAR.Enabled = False
      ChkAP.Enabled = False
      ChkBD.Enabled = False
      ChkFA.Enabled = False
      ChkFI.Enabled = False
      ChkGL.Enabled = False
      ChkGL.Enabled = False
      ChkIA.Enabled = False
      ChkMR.Enabled = False
      ChkPK.Enabled = False
      ChkPO.Enabled = False
      ChkPR.Enabled = False
      ChkPS.Enabled = False
      ChkTA.Enabled = False
      ChkTO.Enabled = False
      ChkTS.Enabled = False
      ChkTX.Enabled = False
      ChkUB.Enabled = False
    Else
      ChkAR.Enabled = True
      ChkAP.Enabled = True
      ChkBD.Enabled = True
      ChkFA.Enabled = True
      ChkFI.Enabled = True
      ChkGL.Enabled = True
      ChkIA.Enabled = True
      ChkMR.Enabled = False
      ChkPK.Enabled = True
      ChkPO.Enabled = True
      ChkPR.Enabled = True
      ChkPS.Enabled = True
      ChkTA.Enabled = True
      ChkTO.Enabled = True
      ChkTS.Enabled = True
      ChkTX.Enabled = True
      ChkUB.Enabled = True
    End If
  End Sub
End Class
