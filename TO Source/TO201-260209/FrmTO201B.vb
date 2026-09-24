Imports System.Data
Public Class FrmTO201B
  Inherits System.Windows.Forms.Form
  Dim MyTXM35H As TXM35H.myData
  Dim MyTXM35HL1 As TXM35HL1.myData
  Dim ds As DataSet = New DataSet
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Friend WithEvents TxtFName As System.Windows.Forms.TextBox

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
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents BtnFast As System.Windows.Forms.Button
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents TxtLName As System.Windows.Forms.TextBox
  Friend WithEvents BtnNext As System.Windows.Forms.Button
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.BtnFast = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtLName = New System.Windows.Forms.TextBox()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.TxtFName = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.GroupBox2.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.TxtYear)
    Me.GroupBox2.Controls.Add(Me.BtnFast)
    Me.GroupBox2.Controls.Add(Me.Label2)
    Me.GroupBox2.Controls.Add(Me.TxtListNo)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(336, 0)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(219, 42)
    Me.GroupBox2.TabIndex = 26
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Fast Path"
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(122, 15)
    Me.TxtYear.MaxLength = 6
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtYear.TabIndex = 2
    '
    'BtnFast
    '
    Me.BtnFast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFast.Location = New System.Drawing.Point(160, 12)
    Me.BtnFast.Name = "BtnFast"
    Me.BtnFast.Size = New System.Drawing.Size(53, 24)
    Me.BtnFast.TabIndex = 3
    Me.BtnFast.Text = "&Show"
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(19, 12)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(36, 27)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "List#/Year"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'TxtListNo
    '
    Me.TxtListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtListNo.Location = New System.Drawing.Point(61, 15)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(58, 20)
    Me.TxtListNo.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 6)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 16)
    Me.Label1.TabIndex = 24
    Me.Label1.Text = "Last Name"
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(212, 12)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 20
    Me.BtnFind.Text = "&Find"
    '
    'TxtLName
    '
    Me.TxtLName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLName.Location = New System.Drawing.Point(78, 2)
    Me.TxtLName.Name = "TxtLName"
    Me.TxtLName.Size = New System.Drawing.Size(128, 20)
    Me.TxtLName.TabIndex = 0
    '
    'BtnNext
    '
    Me.BtnNext.Location = New System.Drawing.Point(268, 12)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(53, 24)
    Me.BtnNext.TabIndex = 27
    Me.BtnNext.Text = "&Next"
    '
    'TxtFName
    '
    Me.TxtFName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFName.Location = New System.Drawing.Point(78, 22)
    Me.TxtFName.Name = "TxtFName"
    Me.TxtFName.Size = New System.Drawing.Size(114, 20)
    Me.TxtFName.TabIndex = 197
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(8, 25)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(64, 16)
    Me.Label3.TabIndex = 198
    Me.Label3.Text = "First Name"
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.AllowUserToResizeRows = False
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
    Me.DataGrdView.Location = New System.Drawing.Point(78, 48)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(407, 300)
    Me.DataGrdView.TabIndex = 203
    '
    'FrmTO201B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(560, 360)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtFName)
    Me.Controls.Add(Me.BtnNext)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnFind)
    Me.Controls.Add(Me.TxtLName)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "FrmTO201B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTO201B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    MyTXM35H = New TXM35H.mydata(MyDBConnect)
    MyTXM35HL1 = New TXM35HL1.mydata(MyDBConnect)
    If MyLocEld = "" Then
      MyFrmTO201.TbarLocal.Visible = False
    End If
    Call FormatGrid()

  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    Call FormatGrid()
  End Sub
  Public Sub FormatGrid()

    Call ShowGrid()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "List No"
      .Columns(0).Width = 50
      .Columns(1).HeaderText = "Year"
      .Columns(1).Width = 50
      .Columns(2).Visible = False
      .Columns(3).HeaderText = "Last Name"
      .Columns(3).Width = 150
      .Columns(4).HeaderText = "First Name"
      .Columns(4).Width = 100
    End With
  End Sub
  Public Sub ShowGrid()
    ds = MyTXM35HL1.GetViewName(TxtLName.Text, TxtFName.Text, 50)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()

  End Sub
  Private Sub FrmTO201B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTO201.SbpScreen.Text = "TO201B"
    MyUtils.CenterForm(Me.ParentForm, Me)

  End Sub
  Private Sub BtnFast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFast.Click
    ShowFastPath()
  End Sub
  Private Sub ShowFastPath()
    Dim ds2 As DataSet = New DataSet
    Dim WrkListNo As Integer
    Dim WrkYear As Integer

    WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    WrkYear = MyUtils.CnvSng(TxtYear.Text)
    If WrkListNo = 0 Or WrkYear = 0 Then Exit Sub

    ds2 = MyTXM35H.GetbyList(WrkListNo, WrkYear)
    If ds2.Tables(0).Rows.Count = 0 Then
      MsgBox("Cannot find record in M35H file", MsgBoxStyle.Exclamation, "Fast Path Error")
      Exit Sub
    End If

    If ds2.Tables(0).Rows.Count = 1 Then
      MyFrmTO201D = New FrmTO201D
      MyFrmTO201D.MdiParent = Me.ParentForm
      MyFrmTO201D.WrkListNo = WrkListNo
      MyFrmTO201D.WrkYear = WrkYear
      MyFrmTO201D.WrkSeq = ds2.Tables(0).Rows(0).Item("seq")
      MyFrmTO201D.Show()
    Else
      MyFrmTO201C = New FrmTO201C
      MyFrmTO201C.MdiParent = Me.ParentForm
      MyFrmTO201C.Wrkds = ds2
      MyFrmTO201C.Show()
    End If

    TxtListNo.Text = ""
    Me.Hide()

  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
    Dim I As Integer
    I = ds.Tables(0).Rows.Count - 1
    TxtLName.Text = DataGrdView.Item(3, I).Value
    TxtFName.Text = DataGrdView.Item(4, I).Value
    FormatGrid()
    TxtLName.Text = ""
    TxtFName.Text = ""
  End Sub
Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    MyFrmTO201D = New FrmTO201D
    MyFrmTO201D.MdiParent = Me.ParentForm
    MyFrmTO201D.WrkListNo = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    MyFrmTO201D.WrkYear = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
    MyFrmTO201D.WrkSeq = DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value
    MyFrmTO201D.Show()
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
    ShowFastPath()
    Exit Sub
  End If

  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






