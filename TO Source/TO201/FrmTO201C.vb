Imports System.Data
Public Class FrmTO201C
  Inherits System.Windows.Forms.Form
  Friend Wrkds As DataSet
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Dim WrkNextScreen As String

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
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
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
    Me.DataGrdView.Location = New System.Drawing.Point(12, 12)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(574, 302)
    Me.DataGrdView.TabIndex = 203
    '
    'FrmTO201C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(598, 326)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "FrmTO201C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmTO201C_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
  If WrkNextScreen = String.Empty Then
    MyFrmTO201.TBarNew.Enabled = True
    MyFrmTO201B.Show()
  End If
End Sub

  Private Sub FrmTO201C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    MyFrmTO201.TBarNew.Enabled = False
    MyFrmTO201.TBarSave.Enabled = False
    WrkNextScreen = String.Empty
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
      .Columns(5).HeaderText = "Init"
      .Columns(5).Width = 40
      .Columns(6).Visible = False
      .Columns(7).HeaderText = "Prop%"
      .Columns(7).Width = 40
      .Columns(8).Visible = False
      .Columns(9).Visible = False
      .Columns(10).Visible = False
      .Columns(11).Visible = False
      .Columns(12).Visible = False
      .Columns(13).HeaderText = "Credit"
      .Columns(13).Width = 40
      .Columns(14).HeaderText = "Allow?"
      .Columns(14).Width = 40
      .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End With
  End Sub
  Public Sub ShowGrid()
    DataGrdView.DataSource = Wrkds.Tables(0)
    DataGrdView.Refresh()

  End Sub
  Private Sub FrmTO201C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTO201.SbpScreen.Text = "TO201C"
    MyUtils.CenterForm(Me.ParentForm, Me)

  End Sub
Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    WrkNextScreen = "TO201D"
    MyFrmTO201D = New FrmTO201D
    MyFrmTO201D.MdiParent = Me.ParentForm
    MyFrmTO201D.WrkListNo = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    MyFrmTO201D.WrkYear = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
    MyFrmTO201D.WrkSeq = DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value
    MyFrmTO201D.Show()
    Me.Close()
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub
End Class






