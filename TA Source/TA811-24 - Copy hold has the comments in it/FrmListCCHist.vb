Public Class FrmListCCHist
  Inherits System.Windows.Forms.Form
  Dim ds As DataSet = New DataSet
  Dim dsTXINV As DataSet = New DataSet
  Dim MyTXINV As TXINV.myData
  Dim mytxcoeal1 As TXCOEAL1.myData
  Dim dsTXCOEAL1 As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WithEvents DataGrdView As DataGridView
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
    Me.DataGrdView.Location = New System.Drawing.Point(12, 7)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(610, 229)
    Me.DataGrdView.TabIndex = 43
    '
    'FrmListCCHist
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(634, 248)
    Me.Controls.Add(Me.DataGrdView)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmListCCHist"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "C/C History"
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmListCCHist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXINV = New TXINV.mydata(MyDBConnect)
    mytxcoeal1 = New TXCOEAL1.mydata(MyDBConnect)
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
      .Columns.Add("Descr", Type.GetType("System.String"))
      .Columns.Add("Nnet", Type.GetType("System.Int32"))
      .Columns.Add("Namt", Type.GetType("System.Decimal"))
      .Columns.Add("ChangeTax", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub

  Private Sub AddRecords()
    Dim myDr As Data.DataRow
    Dim I As Integer
    Dim SaveTax As Decimal
    Dim WrkFirst As Boolean

    SaveTax = 0
    MyTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
    If Not MyTXINV.RecordNotFound Then
      With MyTXINV
        myDr = ds.Tables(0).NewRow
        myDr("ccno") = 0
        myDr("rsndesc") = String.Empty
        myDr("descr") = "* Original *"
        myDr("nnet") = ._NETASS
        myDr("namt") = ._TAXT
        myDr("changetax") = 0
        ds.Tables(0).Rows.Add(myDr)
        SaveTax = ._TAXT
        WrkFirst = True
      End With
    End If

    dsTXCOEAL1 = mytxcoeal1.GetViewbyList(WrkListNo, WrkYear, WrkType, 50)
    For I = 0 To dsTXCOEAL1.Tables(0).Rows.Count - 1
      With dsTXCOEAL1.Tables(0).Rows(I)
        myDr = ds.Tables(0).NewRow
        myDr("ccno") = .Item("ccno")
        myDr("cdate") = MyUtils.GetDBDate(.Item("cdate"))
        myDr("rsndesc") = GetTXCResnDesc(.Item("rsncd"))
        myDr("descr") = .Item("cdesc")
        myDr("nnet") = .Item("cnetas")
        myDr("namt") = .Item("cetax")
        If WrkFirst Then
          myDr("changetax") = .Item("cetax") - SaveTax
        Else
          myDr("changetax") = 0
        End If
        SaveTax = .Item("cetax")
        WrkFirst = True
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
      .Columns(0).HeaderText = "C/C #"
      .Columns(0).Width = 40
      .Columns(1).HeaderText = "Date"
      .Columns(1).Width = 70
      .Columns(2).HeaderText = "Reason"
      .Columns(2).Width = 100
      .Columns(3).HeaderText = "Description"
      .Columns(3).Width = 150
      .Columns(4).HeaderText = "Net"
      .Columns(4).Width = 70
      .Columns(5).HeaderText = "Tax"
      .Columns(5).Width = 70
      .Columns(6).HeaderText = "Chg Tax"
      .Columns(6).Width = 70
    End With

  End Sub
End Class






