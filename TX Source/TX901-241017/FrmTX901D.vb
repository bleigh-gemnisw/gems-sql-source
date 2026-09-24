Public Class FrmTX901D
  Inherits System.Windows.Forms.Form
	Dim myBCHHDR As BCHHDR.myData
	Dim myTSPBCH As TSPBCH.myData
	Dim myTXINV As TXINV.myData
	Friend WrkBatchNo As Integer
  Friend WrkList As Integer
  Friend WrkYear As Integer
  Friend WrkType As String
  Friend WithEvents LnkSusp As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtSusp As System.Windows.Forms.TextBox
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Dim LoadScrn As Boolean
  Friend WithEvents LblName As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents LblAmount As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents LblMsg As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Dim AddMode As Boolean

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
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtType As System.Windows.Forms.TextBox
Friend WithEvents TxtYear As System.Windows.Forms.TextBox
Friend WithEvents TxtList As System.Windows.Forms.TextBox
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents TxtComment As System.Windows.Forms.TextBox
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents LblBatch As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.TxtList = New System.Windows.Forms.TextBox()
    Me.TxtComment = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.LblBatch = New System.Windows.Forms.Label()
    Me.LnkSusp = New System.Windows.Forms.LinkLabel()
    Me.TxtSusp = New System.Windows.Forms.TextBox()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.Label4 = New System.Windows.Forms.Label()
    Me.LblName = New System.Windows.Forms.Label()
    Me.LblAmount = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.LblMsg = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(12, 82)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(48, 24)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "District"
    '
    'TxtDist
    '
    Me.TxtDist.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDist.Location = New System.Drawing.Point(107, 82)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(28, 20)
    Me.TxtDist.TabIndex = 3
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtType.Location = New System.Drawing.Point(175, 6)
    Me.TxtType.MaxLength = 1
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(16, 20)
    Me.TxtType.TabIndex = 1
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(191, 6)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtYear.TabIndex = 2
    '
    'TxtList
    '
    Me.TxtList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtList.Location = New System.Drawing.Point(107, 6)
    Me.TxtList.MaxLength = 12
    Me.TxtList.Name = "TxtList"
    Me.TxtList.Size = New System.Drawing.Size(68, 20)
    Me.TxtList.TabIndex = 0
    '
    'TxtComment
    '
    Me.TxtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtComment.Location = New System.Drawing.Point(107, 131)
    Me.TxtComment.MaxLength = 20
    Me.TxtComment.Name = "TxtComment"
    Me.TxtComment.Size = New System.Drawing.Size(164, 20)
    Me.TxtComment.TabIndex = 6
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(12, 131)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(68, 16)
    Me.Label7.TabIndex = 23
    Me.Label7.Text = "Comment"
    Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(296, 9)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(36, 14)
    Me.Label8.TabIndex = 24
    Me.Label8.Text = "Batch"
    '
    'LblBatch
    '
    Me.LblBatch.Location = New System.Drawing.Point(340, 9)
    Me.LblBatch.Name = "LblBatch"
    Me.LblBatch.Size = New System.Drawing.Size(48, 12)
    Me.LblBatch.TabIndex = 25
    '
    'LnkSusp
    '
    Me.LnkSusp.Location = New System.Drawing.Point(12, 106)
    Me.LnkSusp.Name = "LnkSusp"
    Me.LnkSusp.Size = New System.Drawing.Size(89, 21)
    Me.LnkSusp.TabIndex = 237
    Me.LnkSusp.TabStop = True
    Me.LnkSusp.Text = "Suspense Code"
    '
    'TxtSusp
    '
    Me.TxtSusp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSusp.Location = New System.Drawing.Point(107, 105)
    Me.TxtSusp.MaxLength = 1
    Me.TxtSusp.Name = "TxtSusp"
    Me.TxtSusp.Size = New System.Drawing.Size(16, 20)
    Me.TxtSusp.TabIndex = 4
    Me.TxtSusp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(14, 29)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(36, 14)
    Me.Label4.TabIndex = 241
    Me.Label4.Text = "Name"
    '
    'LblName
    '
    Me.LblName.Location = New System.Drawing.Point(56, 29)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(215, 14)
    Me.LblName.TabIndex = 242
    '
    'LblAmount
    '
    Me.LblAmount.Location = New System.Drawing.Point(66, 52)
    Me.LblAmount.Name = "LblAmount"
    Me.LblAmount.Size = New System.Drawing.Size(79, 14)
    Me.LblAmount.TabIndex = 244
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(14, 52)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(46, 14)
    Me.Label6.TabIndex = 243
    Me.Label6.Text = "Amount"
    '
    'LblMsg
    '
    Me.LblMsg.ForeColor = System.Drawing.Color.Red
    Me.LblMsg.Location = New System.Drawing.Point(14, 160)
    Me.LblMsg.Name = "LblMsg"
    Me.LblMsg.Size = New System.Drawing.Size(374, 14)
    Me.LblMsg.TabIndex = 246
    Me.LblMsg.Text = "(message)"
    Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(14, 7)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(79, 13)
    Me.Label1.TabIndex = 247
    Me.Label1.Text = "List/Type/Year"
    '
    'FrmTX901D
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(395, 183)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LblMsg)
    Me.Controls.Add(Me.LblAmount)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.LblName)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.LnkSusp)
    Me.Controls.Add(Me.TxtSusp)
    Me.Controls.Add(Me.LblBatch)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.TxtComment)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TxtType)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.TxtList)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.Label2)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX901D"
    Me.Text = "Suspense Entries"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTX901D_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myTSPBCH = New TSPBCH.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)

    MyFrmTX901.TBarNew.Enabled = False
    MyFrmTX901.TBarSave.Enabled = True
    LblBatch.Text = WrkBatchNo
    LblMsg.Text = String.Empty

    If WrkList > 0 Then
      MyUtils.SetTxtReadOnly(TxtList)
      MyUtils.SetTxtReadOnly(TxtYear)
      MyUtils.SetTxtReadOnly(TxtType)
      TxtList.Text = WrkList
      TxtYear.Text = WrkYear
      TxtType.Text = WrkType
      GetTXINV()
    End If

    myTSPBCH.GetOneRecordP(WrkBatchNo, WrkList, WrkYear, WrkType)
    If Not myTSPBCH.RecordNotFound Then
      MyFrmTX901.TBarDelete.Enabled = True
    Else
      AddMode = True
      myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
      Exit Sub
    End If

    With myTSPBCH
      TxtDist.Text = ._DIST
      TxtSusp.Text = Trim(._SCD)
      TxtComment.Text = Trim(._COMM)
    End With
  End Sub

  Private Sub FrmTX901D_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX901.SbpScreen.Text = "TX901D"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub FrmTX901D_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTX901.TBarNew.Enabled = True
  MyFrmTX901.TBarDelete.Enabled = False
  MyFrmTX901.TBarSave.Enabled = False
  MyFrmTX901C.FormatGrid()
  MyFrmTX901C.Show()
  'Memory Cleanup
  myTSPBCH = Nothing
  MyFrmTX901D = Nothing
End Sub
Public Sub DeleteData(ByRef Cancel As Boolean)
  Dim Answer As Integer
  Cancel = False
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Cancel = True
    Exit Sub
  End If

  myTSPBCH.DeleteOneRecordP()
End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  myTSPBCH.GetOneRecordP(WrkBatchNo, MyUtils.CnvSng(TxtList.Text), MyUtils.CnvSng(TxtYear.Text), TxtType.Text)
  If Not myTSPBCH.RecordNotFound And AddMode Then
    ErrorField(0) = "acct"
    ErrorMsg(0) = "List/Year/Type is already in batch"
    ShowError(ErrorField, ErrorMsg)
    Exit Sub
  End If

  If Not AddMode Then
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myTSPBCH.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  Else
    With myTSPBCH
      ._BCHNO = WrkBatchNo
      ._LISTNo = MyUtils.CnvSng(TxtList.Text)
      ._TYPE = TxtType.Text
      ._YEAR = MyUtils.CnvSng(TxtYear.Text)
    End With
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myTSPBCH.AddOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myTSPBCH
    ._DIST = MyUtils.CnvSng(TxtDist.Text)
    ._COMM = TxtComment.Text
    ._SCD = TxtSusp.Text
    ._PDATE = 0
    ._NAME = LblName.Text
    ._TAXT = MyUtils.CnvSng(LblAmount.Text)
 End With
 End Sub

 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtList, "")
  ErrProv.SetError(TxtType, "")
  ErrProv.SetError(TxtYear, "")
  ErrProv.SetError(TxtSusp, "")
  ErrProv.SetError(LblAmount, "")

  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
    Case "acct"
      ErrProv.SetError(TxtYear, ErrorMsg(I))
    Case "amount"
      ErrProv.SetError(LblAmount, ErrorMsg(I))
    Case "list"
      ErrProv.SetError(TxtList, ErrorMsg(I))
    Case "susp"
      ErrProv.SetError(TxtSusp, ErrorMsg(I))
    Case "type"
      ErrProv.SetError(TxtType, ErrorMsg(I))
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

    myTXINV.GetOneRecordP(MyUtils.CnvSng(TxtList.Text), MyUtils.CnvSng(TxtYear.Text), TxtType.Text)
    If myTXINV.RecordNotFound Then
      ErrorField(I) = "acct"
      ErrorMsg(I) = "Invalid List/Year/Type"
      I = I + 1
    End If

    If MyUtils.CnvSng(LblAmount.Text) <= 0 Then
      ErrorField(I) = "amount"
      ErrorMsg(I) = "Accounts with no balance due are not allowed"
      I = I + 1
    End If

    If TxtSusp.Text = String.Empty Then
      ErrorField(I) = "susp"
      ErrorMsg(I) = "Suspense code is required"
      I = I + 1
    End If
  End Sub
Private Sub TxtList_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtList.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub Txtdist_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub LnkSusp_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkSusp.LinkClicked
    MyFrmListSResn = New FrmListSResn
    MyFrmListSResn.MdiParent = Me.ParentForm
    MyFrmListSResn.WrkCode = TxtSusp.Text
    MyFrmListSResn.WrkScreen = "FrmTX901D"
    MyFrmListSResn.Show()
End Sub
Private Sub TxtSusp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSusp.Leave
  SetSResnTip()
End Sub
Private Sub SetSResnTip()
    Dim WrkDesc As String

    If Not TxtSusp.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXSResnDesc(TxtSusp.Text)
    Ttp1.SetToolTip(TxtSusp, WrkDesc)
End Sub
Private Sub TxtType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtType.KeyPress
  'Move to next field after anything has been typed since it's only 1 char allowed
  Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
End Sub
Private Sub TxtYear_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtYear.Leave
  GetTXINV()
End Sub
Public Sub GetTXINV()
    LblMsg.Text = String.Empty
    myTXINV.GetOneRecordP(MyUtils.CnvSng(TxtList.Text), MyUtils.CnvSng(TxtYear.Text), TxtType.Text)
    If Not myTXINV.RecordNotFound Then
      LblName.Text = Trim(myTXINV._NAME)
      LblAmount.Text = myTXINV._BALD
      If myTXINV._SUSDT > 0 Then LblMsg.Text = "*** Already in suspense ***"
    Else
      LblName.Text = "*** Invalid account ***"
      LblAmount.Text = ""
    End If

    If MyUtils.CnvSng(LblAmount.Text) <= 0 Then
      LblAmount.ForeColor = Color.Red
    End If
End Sub

Private Sub TxtSusp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSusp.TextChanged

End Sub

Private Sub LnkInv_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

End Sub
End Class






