Public Class FrmListHome
  Inherits System.Windows.Forms.Form
  Dim myTXHOME As TXHOME.myData
  Dim ds As DataSet = New DataSet
  Friend WrkPct As Decimal
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Friend WrkPropPct As Decimal

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.LblCurrent = New System.Windows.Forms.Label()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'LblCurrent
    '
    Me.LblCurrent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.LblCurrent.Location = New System.Drawing.Point(12, 9)
    Me.LblCurrent.Name = "LblCurrent"
    Me.LblCurrent.Size = New System.Drawing.Size(237, 20)
    Me.LblCurrent.TabIndex = 200
    Me.LblCurrent.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
    Me.DataGrdView.Location = New System.Drawing.Point(38, 45)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(184, 173)
    Me.DataGrdView.TabIndex = 202
    '
    'FrmListHome
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(261, 230)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.LblCurrent)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmListHome"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Select Homeowner's Percentage"
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

End Sub

#End Region

  Public Sub FormatGrid()

    Call ShowGrid()

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "Pct"
      .Columns(0).Width = 40
      .Columns(1).HeaderText = "Max"
      .Columns(1).DefaultCellStyle.Format = "N2" 'Fixed
      .Columns(1).Width = 50
      .Columns(2).HeaderText = "Min"
      .Columns(2).DefaultCellStyle.Format = "N2" 'Fixed
      .Columns(2).Width = 50
    End With

  End Sub
  Public Sub ShowGrid()
    ds = myTXHOME.GetAllDataPct
    UpdateDs()
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()

  End Sub
  Private Sub UpdateDs()
    Dim I As Integer
    WrkPropPct = WrkPropPct / 100

    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        .Item("crmax") = MyUtils.Round(.Item("crmax") * WrkPropPct, 2)
'        .Item("crmin") = MyUtils.Round(.Item("crmin") * WrkPropPct, 2)
      End With
    Next
  End Sub

  Private Sub FrmListHome_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTO201.SbpScreen.Text = "ListHome"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub FrmListHome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXHOME = New TXHOME.mydata(MyDBConnect)
    LblCurrent.Text = "(Prop Pct = " & WrkPropPct & " / Table Pct = " & WrkPct & ")"
    FormatGrid()
  End Sub

Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Dim WrkTip As String
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    WrkTip = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value & "/" & _
      DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value
    With MyFrmTO201D
      .TxtTablePct.Text = Format(MyUtils.CnvSng(DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value), "fixed")
      .TxtCeiling.Text = Format(MyUtils.CnvSng(DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value), "fixed")
      .TxtMinGrant.Text = Format(MyUtils.CnvSng(DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value), "fixed")
      .Ttp1.SetToolTip(.TxtTablePct, WrkTip)
      .CalcCredit(True)
      .Show()
    End With

    Me.Close()
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub FrmListHome_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  'Memory Cleanup
  myTXHOME = Nothing
  MyFrmListHome = Nothing
End Sub
End Class






