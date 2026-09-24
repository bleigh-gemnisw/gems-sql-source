Public Class FrmListLease
  Inherits System.Windows.Forms.Form
  Dim myTXDMLES As TXDMLESL1.myData
  Dim ds As DataSet = New DataSet
  Friend WrkCode As String
  Dim SaveDelete As Boolean

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
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents TxtPos As System.Windows.Forms.TextBox
Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListLease))
Me.LblCurrent = New System.Windows.Forms.Label
Me.Label1 = New System.Windows.Forms.Label
Me.BtnFind = New System.Windows.Forms.Button
Me.TxtPos = New System.Windows.Forms.TextBox
Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'LblCurrent
'
Me.LblCurrent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
Me.LblCurrent.Location = New System.Drawing.Point(12, 32)
Me.LblCurrent.Name = "LblCurrent"
Me.LblCurrent.Size = New System.Drawing.Size(248, 16)
Me.LblCurrent.TabIndex = 49
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 8)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(64, 16)
Me.Label1.TabIndex = 48
Me.Label1.Text = "Position To"
'
'BtnFind
'
Me.BtnFind.Location = New System.Drawing.Point(218, 2)
Me.BtnFind.Name = "BtnFind"
Me.BtnFind.Size = New System.Drawing.Size(53, 24)
Me.BtnFind.TabIndex = 47
Me.BtnFind.Text = "&Find"
'
'TxtPos
'
Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtPos.Location = New System.Drawing.Point(72, 4)
Me.TxtPos.MaxLength = 20
Me.TxtPos.Name = "TxtPos"
Me.TxtPos.Size = New System.Drawing.Size(140, 20)
Me.TxtPos.TabIndex = 46
'
'C1DataGrdList
'
Me.C1DataGrdList.AllowColSelect = False
Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
Me.C1DataGrdList.AlternatingRows = True
Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
Me.C1DataGrdList.Location = New System.Drawing.Point(8, 52)
Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
Me.C1DataGrdList.Name = "C1DataGrdList"
Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75
Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.C1DataGrdList.Size = New System.Drawing.Size(847, 383)
Me.C1DataGrdList.TabIndex = 196
Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
'
'FrmListLease
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(867, 447)
Me.Controls.Add(Me.C1DataGrdList)
Me.Controls.Add(Me.LblCurrent)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.BtnFind)
Me.Controls.Add(Me.TxtPos)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmListLease"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Select Lease "
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    Call FormatGrid()
  End Sub

  Public Sub FormatGrid()

    Call ShowGrid()

    With C1DataGrdList
      .Rebind(True)
      .Columns(0).Caption = "Lease ID"
      .Splits(0).DisplayColumns(0).Width = 200
      .Columns(1).Caption = "Name"
      .Splits(0).DisplayColumns(1).Width = 200
      .Columns(2).Caption = "Addr"
      .Splits(0).DisplayColumns(2).Width = 200
      .Columns(3).Caption = "City"
      .Splits(0).DisplayColumns(3).Width = 200
    End With

  End Sub
  Public Sub ShowGrid()
    ds = myTXDMLES.GetViewbyName(TxtPos.Text, 50)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

  End Sub
  Private Sub FrmListLease_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP02.SbpScreen.Text = "ListLease"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Dim I As Integer
    I = ds.Tables(0).Rows.Count - 1
    TxtPos.Text = C1DataGrdList.Item(I, 1)
    FormatGrid()
    TxtPos.Text = ""
  End Sub
  Private Sub FrmListLease_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXDMLES = New TXDMLESL1.mydata(MyDBConnect)

    MyFrmTAP02.TBarDelete.Enabled = False
    MyFrmTAP02.TBarSave.Enabled = False
    LblCurrent.Text = "(Lease ID = " & WrkCode & ")"
    FormatGrid()
  End Sub

Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    With MyFrmTAP02LST2
      .TxtLease.Text = C1DataGrdList.Item(C1DataGrdList.Row, 0)
      .Ttp1.SetToolTip(.TxtLease, C1DataGrdList.Item(C1DataGrdList.Row, 1))
      .Show()
    End With

    Me.Close()
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub

Private Sub FrmListLease_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  'Memory Cleanup
  If MyFrmTAP02LST2.WrkSeqNo > 0 Then
    MyFrmTAP02.TBarDelete.Enabled = True
  End If
  MyFrmTAP02.TBarSave.Enabled = True
  myTXDMLES = Nothing
  MyFrmListLease = Nothing
End Sub
End Class






