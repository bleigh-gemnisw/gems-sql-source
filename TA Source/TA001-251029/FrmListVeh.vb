Public Class FrmListVeh
  Inherits System.Windows.Forms.Form
  Dim myTXVEHL2 As TXVEHL2.myData
  Dim ds As DataSet = New DataSet
  Dim WrkBlocking As Boolean
  Friend WrkCustID As Integer
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Friend WithEvents LblCustID As System.Windows.Forms.Label

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
  Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.LblCurrent = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.LblCustID = New System.Windows.Forms.Label()
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
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(12, 4)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(46, 20)
    Me.Label1.TabIndex = 55
    Me.Label1.Text = "Cust ID"
    '
    'LblCustID
    '
    Me.LblCustID.BackColor = System.Drawing.Color.Aqua
    Me.LblCustID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCustID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCustID.Location = New System.Drawing.Point(64, 4)
    Me.LblCustID.Name = "LblCustID"
    Me.LblCustID.Size = New System.Drawing.Size(64, 16)
    Me.LblCustID.TabIndex = 196
    Me.LblCustID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
    Me.DataGrdView.Location = New System.Drawing.Point(11, 27)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(646, 360)
    Me.DataGrdView.TabIndex = 197
    '
    'FrmListVeh
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(669, 399)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.LblCustID)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LblCurrent)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmListVeh"
    Me.Text = "Select DMV Vehicle"
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

End Sub

#End Region
  Public Sub FormatGrid()
    Call ShowGrid()

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).Visible = False
      .Columns(1).Visible = False
      .Columns(2).HeaderText = "Reg No"
      .Columns(2).Width = 60
      .Columns(3).HeaderText = "VIN"
      .Columns(3).Width = 150
      .Columns(4).Visible = False
      .Columns(5).HeaderText = "Vehicle ID"
      .Columns(5).Width = 60
      .Columns(6).HeaderText = "Lease?"
      .Columns(6).Width = 50
    End With
  End Sub
  Public Sub ShowGrid()
    ds = myTXVEHL2.GetViewbyPcust(WrkCustID, 99999999, 50)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()

  End Sub
  Private Sub FrmListVeh_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA001.SbpScreen.Text = "ListVeh"
    MyUtils.CenterForm(Me.ParentForm, Me)
    FormatGrid()
  End Sub
  Private Sub FrmListVeh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXVEHL2 = New TXVEHL2.mydata(MyDBConnect)
    If MyServer = "SQL" Then
      WrkBlocking = False
    Else
      WrkBlocking = True
    End If
    LblCustID.Text = WrkCustID
    FormatGrid()
  End Sub
Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    With MyFrmTA001DMV
      .TxtOid.Text = DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value
    End With

    Me.Close()
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub FrmListVeh_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    With MyFrmTA001DMV

      .Show()
    End With
    'Memory Cleanup
    myTXVEHL2 = Nothing
    MyFrmListVeh = Nothing
End Sub

End Class






