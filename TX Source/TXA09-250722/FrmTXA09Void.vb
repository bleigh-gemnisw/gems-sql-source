Public Class FrmTXA09Void
  Inherits System.Windows.Forms.Form
  Dim myTBATCH As TBATCH.myData
  Dim myTXBATCH As TXBATCH.myData
  Dim myTXINV As TXINV.myData
  Dim ds As DataSet = New DataSet
  Friend WrkSeqNo As Integer

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
  Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
  Friend WithEvents LblUnposted As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents TbMain As System.Windows.Forms.ToolBar
  Friend WithEvents TBarVoid As System.Windows.Forms.ToolBarButton
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents LblName As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents LblType As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents LblYear As System.Windows.Forms.Label
  Friend WithEvents LblList As System.Windows.Forms.Label
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents LblPrincipal As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents LblFee As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents LblInterest As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents LblLien As System.Windows.Forms.Label
  Friend WithEvents LblAdjust As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Me.GroupBox5 = New System.Windows.Forms.GroupBox
    Me.LblLien = New System.Windows.Forms.Label
    Me.Label9 = New System.Windows.Forms.Label
    Me.LblInterest = New System.Windows.Forms.Label
    Me.Label8 = New System.Windows.Forms.Label
    Me.LblFee = New System.Windows.Forms.Label
    Me.Label6 = New System.Windows.Forms.Label
    Me.LblPrincipal = New System.Windows.Forms.Label
    Me.Label5 = New System.Windows.Forms.Label
    Me.LblUnposted = New System.Windows.Forms.Label
    Me.Label16 = New System.Windows.Forms.Label
    Me.TbMain = New System.Windows.Forms.ToolBar
    Me.TBarVoid = New System.Windows.Forms.ToolBarButton
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.LblName = New System.Windows.Forms.Label
    Me.Label7 = New System.Windows.Forms.Label
    Me.LblType = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.LblYear = New System.Windows.Forms.Label
    Me.LblList = New System.Windows.Forms.Label
    Me.label2 = New System.Windows.Forms.Label
    Me.label1 = New System.Windows.Forms.Label
    Me.LblAdjust = New System.Windows.Forms.Label
    Me.GroupBox5.SuspendLayout()
    Me.SuspendLayout()
    '
    'GroupBox5
    '
    Me.GroupBox5.BackColor = System.Drawing.SystemColors.Control
    Me.GroupBox5.Controls.Add(Me.LblLien)
    Me.GroupBox5.Controls.Add(Me.Label9)
    Me.GroupBox5.Controls.Add(Me.LblInterest)
    Me.GroupBox5.Controls.Add(Me.Label8)
    Me.GroupBox5.Controls.Add(Me.LblFee)
    Me.GroupBox5.Controls.Add(Me.Label6)
    Me.GroupBox5.Controls.Add(Me.LblPrincipal)
    Me.GroupBox5.Controls.Add(Me.Label5)
    Me.GroupBox5.Controls.Add(Me.LblUnposted)
    Me.GroupBox5.Controls.Add(Me.Label16)
    Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox5.Location = New System.Drawing.Point(88, 80)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(160, 104)
    Me.GroupBox5.TabIndex = 156
    Me.GroupBox5.TabStop = False
    Me.GroupBox5.Text = "Voided Amounts"
    '
    'LblLien
    '
    Me.LblLien.BackColor = System.Drawing.SystemColors.Control
    Me.LblLien.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLien.Location = New System.Drawing.Point(88, 48)
    Me.LblLien.Name = "LblLien"
    Me.LblLien.Size = New System.Drawing.Size(60, 16)
    Me.LblLien.TabIndex = 136
    Me.LblLien.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label9
    '
    Me.Label9.BackColor = System.Drawing.SystemColors.Control
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(10, 48)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(76, 16)
    Me.Label9.TabIndex = 135
    Me.Label9.Text = "Lien"
    '
    'LblInterest
    '
    Me.LblInterest.BackColor = System.Drawing.SystemColors.Control
    Me.LblInterest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblInterest.Location = New System.Drawing.Point(88, 32)
    Me.LblInterest.Name = "LblInterest"
    Me.LblInterest.Size = New System.Drawing.Size(60, 16)
    Me.LblInterest.TabIndex = 134
    Me.LblInterest.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label8
    '
    Me.Label8.BackColor = System.Drawing.SystemColors.Control
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(10, 32)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(76, 16)
    Me.Label8.TabIndex = 133
    Me.Label8.Text = "Interest"
    '
    'LblFee
    '
    Me.LblFee.BackColor = System.Drawing.SystemColors.Control
    Me.LblFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFee.Location = New System.Drawing.Point(88, 64)
    Me.LblFee.Name = "LblFee"
    Me.LblFee.Size = New System.Drawing.Size(60, 16)
    Me.LblFee.TabIndex = 132
    Me.LblFee.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label6
    '
    Me.Label6.BackColor = System.Drawing.SystemColors.Control
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(10, 64)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(76, 16)
    Me.Label6.TabIndex = 131
    Me.Label6.Text = "Fee"
    '
    'LblPrincipal
    '
    Me.LblPrincipal.BackColor = System.Drawing.SystemColors.Control
    Me.LblPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPrincipal.Location = New System.Drawing.Point(90, 16)
    Me.LblPrincipal.Name = "LblPrincipal"
    Me.LblPrincipal.Size = New System.Drawing.Size(60, 16)
    Me.LblPrincipal.TabIndex = 130
    Me.LblPrincipal.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label5
    '
    Me.Label5.BackColor = System.Drawing.SystemColors.Control
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(10, 16)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(76, 16)
    Me.Label5.TabIndex = 129
    Me.Label5.Text = "Principal "
    '
    'LblUnposted
    '
    Me.LblUnposted.BackColor = System.Drawing.SystemColors.Control
    Me.LblUnposted.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblUnposted.Location = New System.Drawing.Point(88, 80)
    Me.LblUnposted.Name = "LblUnposted"
    Me.LblUnposted.Size = New System.Drawing.Size(60, 16)
    Me.LblUnposted.TabIndex = 127
    Me.LblUnposted.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label16
    '
    Me.Label16.BackColor = System.Drawing.SystemColors.Control
    Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label16.Location = New System.Drawing.Point(10, 80)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(76, 16)
    Me.Label16.TabIndex = 0
    Me.Label16.Text = "Unposted Pmt"
    '
    'TbMain
    '
    Me.TbMain.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarVoid})
    Me.TbMain.Dock = System.Windows.Forms.DockStyle.None
    Me.TbMain.DropDownArrows = True
    Me.TbMain.Location = New System.Drawing.Point(8, 144)
    Me.TbMain.Name = "TbMain"
    Me.TbMain.ShowToolTips = True
    Me.TbMain.Size = New System.Drawing.Size(48, 42)
    Me.TbMain.TabIndex = 170
    '
    'TBarVoid
    '
    Me.TBarVoid.Text = "&Void"
    '
    'ImageList1
    '
    Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    '
    'LblName
    '
    Me.LblName.BackColor = System.Drawing.SystemColors.Control
    Me.LblName.Location = New System.Drawing.Point(104, 32)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(216, 16)
    Me.LblName.TabIndex = 178
    Me.LblName.UseMnemonic = False
    '
    'Label7
    '
    Me.Label7.BackColor = System.Drawing.SystemColors.Control
    Me.Label7.Location = New System.Drawing.Point(160, 8)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(32, 12)
    Me.Label7.TabIndex = 177
    Me.Label7.Text = "Type"
    '
    'LblType
    '
    Me.LblType.BackColor = System.Drawing.SystemColors.Control
    Me.LblType.Location = New System.Drawing.Point(200, 8)
    Me.LblType.Name = "LblType"
    Me.LblType.Size = New System.Drawing.Size(16, 16)
    Me.LblType.TabIndex = 176
    '
    'Label3
    '
    Me.Label3.BackColor = System.Drawing.SystemColors.Control
    Me.Label3.Location = New System.Drawing.Point(224, 8)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(32, 12)
    Me.Label3.TabIndex = 175
    Me.Label3.Text = "Year"
    '
    'LblYear
    '
    Me.LblYear.BackColor = System.Drawing.SystemColors.Control
    Me.LblYear.Location = New System.Drawing.Point(256, 8)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(48, 16)
    Me.LblYear.TabIndex = 174
    '
    'LblList
    '
    Me.LblList.BackColor = System.Drawing.SystemColors.Control
    Me.LblList.Location = New System.Drawing.Point(104, 8)
    Me.LblList.Name = "LblList"
    Me.LblList.Size = New System.Drawing.Size(48, 16)
    Me.LblList.TabIndex = 173
    '
    'label2
    '
    Me.label2.BackColor = System.Drawing.SystemColors.Control
    Me.label2.Location = New System.Drawing.Point(8, 32)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(84, 12)
    Me.label2.TabIndex = 172
    Me.label2.Text = "Name of Owner"
    '
    'label1
    '
    Me.label1.BackColor = System.Drawing.SystemColors.Control
    Me.label1.Location = New System.Drawing.Point(8, 8)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(36, 12)
    Me.label1.TabIndex = 171
    Me.label1.Text = "List #"
    '
    'LblAdjust
    '
    Me.LblAdjust.BackColor = System.Drawing.SystemColors.Control
    Me.LblAdjust.Location = New System.Drawing.Point(136, 64)
    Me.LblAdjust.Name = "LblAdjust"
    Me.LblAdjust.Size = New System.Drawing.Size(84, 12)
    Me.LblAdjust.TabIndex = 179
    Me.LblAdjust.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'FrmTXA09Void
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(322, 192)
    Me.Controls.Add(Me.LblAdjust)
    Me.Controls.Add(Me.LblName)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.LblType)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.LblList)
    Me.Controls.Add(Me.label2)
    Me.Controls.Add(Me.label1)
    Me.Controls.Add(Me.GroupBox5)
    Me.Controls.Add(Me.TbMain)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXA09Void"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Void Transaction"
    Me.GroupBox5.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmTXA09Void_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmTXA09.TBarBack.Enabled = False
    MyFrmTXA09.TBarChange.Enabled = False
    MyFrmTXA09.TBarClose.Enabled = False
    MyFrmTXA09.TBarPost.Enabled = False
    MyFrmTXA09.TBarPrtEdits.Enabled = False

    myTBATCH = New TBATCH.mydata(MyDBConnect)
    myTXBATCH = New TXBATCH.mydata(MyDBConnect)
    myTXINV = New TXINV.mydata(MyDBConnect)

    myTXBATCH.GetOneRecordP(MyBatch, MyBatchNo, WrkSeqNo)
    With myTXBATCH
      LblList.Text = ._LISTNo
      LblYear.Text = ._YEAR
      LblType.Text = ._TYPE
      LblName.Text = Trim(._NAME)
      LblPrincipal.Text = ._PAMT * -1
      LblInterest.Text = ._IAMT * -1
      LblLien.Text = ._LAMT * -1
      LblFee.Text = ._TCAMT * -1
      LblUnposted.Text = ._PAMT * -1
      If ._ADJCD = "A" Then
        LblAdjust.Text = "Adjust"
      End If
      If ._ADJCD = "R" Then
        LblAdjust.Text = "Refund"
      End If
    End With

  End Sub

  Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
    If e.Button Is TBarVoid Then
      SaveData()
    End If

  End Sub
  Public Sub SaveData()
    myTXBATCH.GetOneRecordP(MyBatch, MyBatchNo, WrkSeqNo)
    If myTXBATCH._JSTAT = "V" Then Exit Sub

    MoveToFile()
    myTXBATCH.UpdateOneRecordP()

    MoveToTXINV()
    MoveToTBATCH()
    myTXBATCH.CloseFile()
    Me.Close()
  End Sub
  Private Sub MoveToFile()
    With myTXBATCH
      ._JSTAT = "V" 'Void
    End With
  End Sub
  Private Sub MoveToTXINV()
    Dim WrkFamily As String

    WrkFamily = GetTXTypeFamily(LblType.Text)

    myTXINV.GetOneRecordP(MyUtils.CnvSng(LblList.Text), MyUtils.CnvSng(LblYear.Text), LblType.Text)
    With myTXINV
      ._NEWPAY = ._NEWPAY + MyUtils.CnvSng(LblUnposted.Text)
      If WrkFamily = "A" Then
        If MyUtils.CnvSng(LblFee.Text) <> 0 Then
          ._BONT = ._BONT + MyUtils.CnvSng(LblFee.Text)
        End If
      End If
    End With
    myTXINV.UpdateOneRecordP()

  End Sub
  Private Sub MoveToTBATCH()
    myTBATCH.GetOneRecordP(MyBatch, MyBatchNo)
    With myTBATCH
      ._KBEND = ._KBEND + MyUtils.CnvSng(LblPrincipal.Text) + MyUtils.CnvSng(LblInterest.Text) +
        MyUtils.CnvSng(LblLien.Text) + MyUtils.CnvSng(LblFee.Text)
    End With
    myTBATCH.UpdateOneRecordP()
    myTBATCH.CloseFile()

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  End Sub
  Private Sub FrmTXA09Void_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA09.SbpScreen.Text = "TXA09Void"
    With MyFrmTXA09
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub FrmTXA09Void_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    MyFrmTXA09.TBarBack.Enabled = True
    MyFrmTXA09.TBarChange.Enabled = True
    MyFrmTXA09.TBarClose.Enabled = True
    MyFrmTXA09.TBarPost.Enabled = True
    MyFrmTXA09.TBarPrtEdits.Enabled = True
    MyFrmTXA09.SbpScreen.Text = "TXA09View"
    'Memory Cleanup
    Me.Dispose()
    ds.Clear()
    ds = Nothing
    myTBATCH.CloseFile()
    myTXBATCH.CloseFile()
    myTXINV.CloseFile()
    myTBATCH = Nothing
    myTXBATCH = Nothing
    myTXINV = Nothing
    MyFrmTXA09Void = Nothing
  End Sub
End Class






