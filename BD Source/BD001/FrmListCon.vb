Public Class FrmListCon
  Inherits System.Windows.Forms.Form
  Dim myBDCONL1 As BDCONL1.myData
  Dim ds As DataSet = New DataSet
  Dim WrkBlocking As Boolean
  Friend WrkName As String
  Friend WithEvents DataGrdView As DataGridView
  Friend WrkFormID As String

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
  Friend WithEvents LblCurrent As System.Windows.Forms.Label
  Friend WithEvents BtnNext As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents TxtPos As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.LblCurrent = New System.Windows.Forms.Label()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'LblCurrent
    '
    Me.LblCurrent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.LblCurrent.Location = New System.Drawing.Point(8, 56)
    Me.LblCurrent.Name = "LblCurrent"
    Me.LblCurrent.Size = New System.Drawing.Size(248, 16)
    Me.LblCurrent.TabIndex = 49
    '
    'BtnNext
    '
    Me.BtnNext.Location = New System.Drawing.Point(274, 4)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(53, 24)
    Me.BtnNext.TabIndex = 56
    Me.BtnNext.Text = "&Next"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(12, 4)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 16)
    Me.Label1.TabIndex = 55
    Me.Label1.Text = "Position To"
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(218, 4)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 52
    Me.BtnFind.Text = "&Find"
    '
    'TxtPos
    '
    Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPos.Location = New System.Drawing.Point(82, 4)
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(128, 20)
    Me.TxtPos.TabIndex = 1
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView.DefaultCellStyle = DataGridViewCellStyle1
    Me.DataGrdView.Location = New System.Drawing.Point(12, 34)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(677, 300)
    Me.DataGrdView.TabIndex = 57
    '
    'FrmListCon
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(701, 346)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.BtnNext)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnFind)
    Me.Controls.Add(Me.TxtPos)
    Me.Controls.Add(Me.LblCurrent)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmListCon"
    Me.Text = "Select Contractor"
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    Call FormatGrid()
  End Sub

  Public Sub FormatGrid()
    Call ShowGrid()

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).Visible = False
      .Columns(1).HeaderText = "Name"
      .Columns(1).Width = 250
      .Columns(2).Visible = False
      .Columns(3).Visible = False
      .Columns(4).Visible = False
      .Columns(5).Visible = False
      .Columns(7).Visible = False
      .Columns(8).Visible = False
      .Columns(9).Visible = False
      .Columns(10).Visible = False
      .Columns(11).Visible = False
    End With
  End Sub
  Public Sub ShowGrid()
    ds = myBDCONL1.GetViewbyName(TxtPos.Text, 50, WrkBlocking)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
  End Sub
  Private Sub FrmListCon_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmBD001.SbpScreen.Text = "ListCon"
    MyUtils.CenterForm(Me.ParentForm, Me)

  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
    Dim I As Integer
    I = ds.Tables(0).Rows.Count - 1
    TxtPos.Text = DataGrdView.Item(1, I).Value
    FormatGrid()
    TxtPos.Text = ""
  End Sub
  Private Sub FrmListCon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myBDCONL1 = New BDCONL1.mydata(MyDBConnect)
    MyFrmBD001.TBarSave.Enabled = False
    MyFrmBD001.TBarDelete.Enabled = False
    MyFrmBD001.TBarAuth.Enabled = False
    If MyServer = "SQL" Then
      WrkBlocking = False
    Else
      WrkBlocking = True
    End If
    TxtPos.Text = WrkName
    FormatGrid()
  End Sub
  Private Sub DataGrdview_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    Select Case WrkFormID
      Case "CD"
        With MyFrmBD001CD
          .LblCoID.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
          .TxtCoName.Text = Trim(DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value)
          .TxtCoAddr.Text = Trim(DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value)
          .TxtCoCity.Text = Trim(DataGrdView.Item(3, DataGrdView.CurrentRow.Index).Value)
          .TxtCoState.Text = Trim(DataGrdView.Item(4, DataGrdView.CurrentRow.Index).Value)
          If DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value > 0 Then
            .TxtCoZip.Text = DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value
          Else
            .TxtCoZip.Text = ""
          End If
          .TxtCoPhon.Text = Trim(DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
          If Trim(DataGrdView.Item(8, DataGrdView.CurrentRow.Index).Value) = "" Then
            .TxtCoLic.Text = Trim(DataGrdView.Item(7, DataGrdView.CurrentRow.Index).Value)
            Me.Close()
          Else
            MyFrmListConLic = New FrmListConLic
            MyFrmListConLic.MdiParent = Me.ParentForm
            MyFrmListConLic.WrkFormID = WrkFormID
            MyFrmListConLic.WrkLic1 = Trim(DataGrdView.Item(7, DataGrdView.CurrentRow.Index).Value)
            MyFrmListConLic.WrkLic2 = Trim(DataGrdView.Item(8, DataGrdView.CurrentRow.Index).Value)
            MyFrmListConLic.WrkLic3 = Trim(DataGrdView.Item(9, DataGrdView.CurrentRow.Index).Value)
            MyFrmListConLic.WrkLic4 = Trim(DataGrdView.Item(10, DataGrdView.CurrentRow.Index).Value)
            MyFrmListConLic.WrkLic5 = Trim(DataGrdView.Item(11, DataGrdView.CurrentRow.Index).Value)
            MyFrmListConLic.Show()
            Me.Hide()
          End If
        End With
      Case "CE"
        With MyFrmBD001CE
          .LblCoID.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
          .TxtCoName.Text = Trim(DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value)
          .TxtCoAddr.Text = Trim(DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value)
          .TxtCoCity.Text = Trim(DataGrdView.Item(3, DataGrdView.CurrentRow.Index).Value)
          .TxtCoState.Text = Trim(DataGrdView.Item(4, DataGrdView.CurrentRow.Index).Value)
          If DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value > 0 Then
            .TxtCoZip.Text = DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value
          Else
            .TxtCoZip.Text = ""
          End If
          .TxtCoPhon.Text = Trim(DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
          If Trim(DataGrdView.Item(8, DataGrdView.CurrentRow.Index).Value) = "" Then
            .TxtCoLic.Text = Trim(DataGrdView.Item(7, DataGrdView.CurrentRow.Index).Value)
            Me.Close()
          Else
            MyFrmListConLic = New FrmListConLic
            MyFrmListConLic.MdiParent = Me.ParentForm
            MyFrmListConLic.WrkFormID = WrkFormID
            MyFrmListConLic.WrkLic1 = Trim(DataGrdView.Item(7, DataGrdView.CurrentRow.Index).Value)
            MyFrmListConLic.WrkLic2 = Trim(DataGrdView.Item(8, DataGrdView.CurrentRow.Index).Value)
            MyFrmListConLic.WrkLic3 = Trim(DataGrdView.Item(9, DataGrdView.CurrentRow.Index).Value)
            MyFrmListConLic.WrkLic4 = Trim(DataGrdView.Item(10, DataGrdView.CurrentRow.Index).Value)
            MyFrmListConLic.WrkLic5 = Trim(DataGrdView.Item(11, DataGrdView.CurrentRow.Index).Value)
            MyFrmListConLic.Show()
            Me.Hide()
          End If
        End With
      Case "CH"
        With MyFrmBD001CH
          .LblCoID.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
          .TxtCoName.Text = Trim(DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value)
          .TxtCoAddr.Text = Trim(DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value)
          .TxtCoCity.Text = Trim(DataGrdView.Item(3, DataGrdView.CurrentRow.Index).Value)
          .TxtCoState.Text = Trim(DataGrdView.Item(4, DataGrdView.CurrentRow.Index).Value)
          If DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value > 0 Then
            .TxtCoZip.Text = DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value
          Else
            .TxtCoZip.Text = ""
          End If
          .TxtCoPhon.Text = Trim(DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
          If Trim(DataGrdView.Item(8, DataGrdView.CurrentRow.Index).Value) = "" Then
            .TxtCoLic.Text = Trim(DataGrdView.Item(7, DataGrdView.CurrentRow.Index).Value)
            Me.Close()
          Else
            MyFrmListConLic = New FrmListConLic
            MyFrmListConLic.MdiParent = Me.ParentForm
            MyFrmListConLic.WrkFormID = WrkFormID
            MyFrmListConLic.WrkLic1 = Trim(DataGrdView.Item(7, DataGrdView.CurrentRow.Index).Value)
            MyFrmListConLic.WrkLic2 = Trim(DataGrdView.Item(8, DataGrdView.CurrentRow.Index).Value)
            MyFrmListConLic.WrkLic3 = Trim(DataGrdView.Item(9, DataGrdView.CurrentRow.Index).Value)
            MyFrmListConLic.WrkLic4 = Trim(DataGrdView.Item(10, DataGrdView.CurrentRow.Index).Value)
            MyFrmListConLic.WrkLic5 = Trim(DataGrdView.Item(11, DataGrdView.CurrentRow.Index).Value)
            MyFrmListConLic.Show()
            Me.Hide()
          End If
        End With
      Case Else
        With MyFrmBD001C
          .LblCoID.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
          .TxtCoName.Text = Trim(DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value)
          .TxtCoAddr.Text = Trim(DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value)
          .TxtCoCity.Text = Trim(DataGrdView.Item(3, DataGrdView.CurrentRow.Index).Value)
          .TxtCoState.Text = Trim(DataGrdView.Item(4, DataGrdView.CurrentRow.Index).Value)
          If DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value > 0 Then
            .TxtCoZip.Text = DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value
          Else
            .TxtCoZip.Text = ""
          End If
          .TxtCoPhon.Text = Trim(DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
          If Trim(DataGrdView.Item(8, DataGrdView.CurrentRow.Index).Value) = "" Then
            .TxtCoLic.Text = Trim(DataGrdView.Item(7, DataGrdView.CurrentRow.Index).Value)
            Me.Close()
          Else
            MyFrmListConLic = New FrmListConLic
            MyFrmListConLic.MdiParent = Me.ParentForm
            MyFrmListConLic.WrkFormID = WrkFormID
            MyFrmListConLic.WrkLic1 = Trim(DataGrdView.Item(7, DataGrdView.CurrentRow.Index).Value)
            MyFrmListConLic.WrkLic2 = Trim(DataGrdView.Item(8, DataGrdView.CurrentRow.Index).Value)
            MyFrmListConLic.WrkLic3 = Trim(DataGrdView.Item(9, DataGrdView.CurrentRow.Index).Value)
            MyFrmListConLic.WrkLic4 = Trim(DataGrdView.Item(10, DataGrdView.CurrentRow.Index).Value)
            MyFrmListConLic.WrkLic5 = Trim(DataGrdView.Item(11, DataGrdView.CurrentRow.Index).Value)
            MyFrmListConLic.Show()
            Me.Hide()
          End If
        End With
    End Select

    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Private Sub FrmListCon_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmBD001.TBarAuth.Enabled = True
    Select Case WrkFormID
      Case "CD"
        If MyFrmBD001CD.WrkRecID > 0 Then
          MyFrmBD001.TBarDelete.Enabled = True
        End If
        MyFrmBD001.TBarSave.Enabled = True
        With MyFrmBD001CD
          .Show()
        End With
      Case "CE"
        If MyFrmBD001CE.WrkRecID > 0 Then
          MyFrmBD001.TBarDelete.Enabled = True
        End If
        MyFrmBD001.TBarSave.Enabled = True
        With MyFrmBD001CE
          .Show()
        End With
      Case "CH"
        If MyFrmBD001CH.WrkRecID > 0 Then
          MyFrmBD001.TBarDelete.Enabled = True
        End If
        MyFrmBD001.TBarSave.Enabled = True
        With MyFrmBD001CH
          .Show()
        End With
      Case "CZ"
        If MyFrmBD001CZ.WrkRecID > 0 Then
          MyFrmBD001.TBarDelete.Enabled = True
        End If
        MyFrmBD001.TBarSave.Enabled = True
        With MyFrmBD001CZ
          .Show()
        End With
      Case Else
        If MyFrmBD001C.WrkRecID > 0 Then
          MyFrmBD001.TBarDelete.Enabled = True
        End If
        MyFrmBD001.TBarSave.Enabled = True
        With MyFrmBD001C
          .Show()
        End With
    End Select
    'Memory Cleanup
    myBDCONL1 = Nothing
    MyFrmListCon = Nothing
  End Sub

End Class






