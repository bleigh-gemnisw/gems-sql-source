Public Class FrmListAdjHist
  Inherits System.Windows.Forms.Form
  Dim ds As DataSet = New DataSet
	Dim myTXINV As TXINV.myData
	Dim myUTCOEAL1 As UTCOEAL1.myData
  Dim dsUTCOEAL1 As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Friend WrkType As String

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
    Me.DataGrdView.Location = New System.Drawing.Point(12, 17)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(328, 242)
    Me.DataGrdView.TabIndex = 39
    '
    'FrmListAdjHist
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(352, 271)
    Me.Controls.Add(Me.DataGrdView)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmListAdjHist"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Adjustment History"
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmListAdjHist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	myTXINV = New TXINV.mydata(MyDBConnect)
	myUTCOEAL1 = New UTCOEAL1.mydata(MyDBConnect)
  BuildDS()
  AddRecords()
  FormatGrid()
End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("CCNo", Type.GetType("System.Int32"))
      .Columns.Add("Cdate", Type.GetType("System.DateTime"))
      .Columns.Add("RsnDesc", Type.GetType("System.String"))
      .Columns.Add("Namt", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub

Private Sub AddRecords()
  Dim myDr As Data.DataRow
	Dim I As Integer

	myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
	If Not myTXINV.RecordNotFound Then
	With myTXINV
		myDr = ds.Tables(0).NewRow
		myDr("ccno") = 0
		myDr("rsndesc") = "* Original *"
		myDr("namt") = ._TAXT
		ds.Tables(0).Rows.Add(myDr)
	End With
	End If

  dsUTCOEAL1 = myUTCOEAL1.GetViewbyList(WrkListNo, WrkYear, WrkType, 50)
  For I = 0 To dsUTCOEAL1.Tables(0).Rows.Count - 1
    With dsUTCOEAL1.Tables(0).Rows(I)
    myDr = ds.Tables(0).NewRow
    myDr("ccno") = .Item("ccno")
    myDr("cdate") = MyUtils.GetDBDate(.Item("cdate"))
    myDr("rsndesc") = GetUTCRESNDesc(.Item("rsncd"))
    myDr("namt") = .Item("cetax")
    ds.Tables(0).Rows.Add(myDr)
    End With
  Next

End Sub
  Public Sub FormatGrid()

    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "Adj #"
      .Columns(0).Width = 40
      .Columns(1).HeaderText = "Date"
      .Columns(1).Width = 70
      .Columns(2).HeaderText = "Reason"
      .Columns(2).Width = 100
      .Columns(3).HeaderText = "Tax"
      .Columns(3).Width = 70
    End With

  End Sub

End Class






