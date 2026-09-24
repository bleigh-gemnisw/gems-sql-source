Public Class FrmIA002B
    Inherits System.Windows.Forms.Form
		Dim myGNETGROUP As GNETGROUP.MyData
    Friend ds As DataSet = New DataSet
    Dim WrkGNETGROUP As String

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
    Friend WithEvents BtnFind As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPos As System.Windows.Forms.TextBox
    Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmIA002B))
Me.TxtPos = New System.Windows.Forms.TextBox
Me.BtnFind = New System.Windows.Forms.Button
Me.Label1 = New System.Windows.Forms.Label
Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'TxtPos
'
Me.TxtPos.Location = New System.Drawing.Point(80, 16)
Me.TxtPos.Name = "TxtPos"
Me.TxtPos.Size = New System.Drawing.Size(176, 20)
Me.TxtPos.TabIndex = 0
'
'BtnFind
'
Me.BtnFind.Location = New System.Drawing.Point(264, 16)
Me.BtnFind.Name = "BtnFind"
Me.BtnFind.Size = New System.Drawing.Size(53, 24)
Me.BtnFind.TabIndex = 1
Me.BtnFind.Text = "Find"
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(16, 16)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(64, 16)
Me.Label1.TabIndex = 14
Me.Label1.Text = "Position To"
'
'C1DataGrdList
'
Me.C1DataGrdList.AllowColSelect = False
Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
Me.C1DataGrdList.Location = New System.Drawing.Point(8, 48)
Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
Me.C1DataGrdList.Name = "C1DataGrdList"
Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75
Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.C1DataGrdList.Size = New System.Drawing.Size(440, 352)
Me.C1DataGrdList.TabIndex = 19
Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
'
'FrmIA002B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(454, 408)
Me.ControlBox = False
Me.Controls.Add(Me.C1DataGrdList)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.TxtPos)
Me.Controls.Add(Me.BtnFind)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.Name = "FrmIA002B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

    Private Sub FrmIA002B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        myGNETGROUP = New GNETGROUP.MyData()
        myGNETGROUP.MyDBConn = myDBConnect
        WrkGNETGROUP = ""
        Call FormatGrid()

    End Sub

    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        WrkGNETGROUP = TxtPos.Text
        ds = myGNETGROUP.PosData(WrkGNETGROUP)

        FormatGrid()
        WrkGNETGROUP = ""
    End Sub

    Public Sub FormatGrid()

        ShowGrid()

        With C1DataGrdList
            .Rebind(True)
            .Columns(0).Caption = "Group Id"
            .Splits(0).DisplayColumns(0).Width = 150
            .Columns(1).Caption = "Group"
            .Splits(0).DisplayColumns(2).Width = 300
            .Columns(2).Caption = "Full Rights"
            .Splits(0).DisplayColumns(2).Width = 150


        End With

    End Sub
    Public Sub ShowGrid()

        ds = myGNETGROUP.PosData(TxtPos.Text)
        C1DataGrdList.DataSource = ds.Tables(0)
        C1DataGrdList.Refresh()
        myGNETGROUP.CloseFile()

    End Sub
Public Sub CopyData()
  MyFrmIA002C = New FrmIA002C
  MyFrmIA002C.MdiParent = Me.ParentForm
  MyFrmIA002C.WrkGNETGROUP = ""
  MyFrmIA002C.WrkCopyGroup = C1DataGrdList.Item(C1DataGrdList.Row, 0)
  MyFRMIA002C.Show()
  Me.Hide()
End Sub
    Private Sub FrmIA002B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        MyFRMIA002.SbpScreen.Text = "IA002B"
        MyFRMIA002.TBarPrint.Enabled = True
        MyUtils.CenterForm(Me.ParentForm, Me)

    End Sub
    Private Sub TxtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPos.KeyPress
        If e.KeyChar = MyUtils.VbKeyEnter Then
            FormatGrid()
        End If
    End Sub


    Private Sub C1DataGrdList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick

        MyFRMIA002C = New FRMIA002C
        MyFRMIA002C.MdiParent = Me.ParentForm
        MyFrmIA002C.WrkGNETGROUP = C1DataGrdList.Item(C1DataGrdList.Row, 0)
        MyFrmIA002C.WrkCopyGroup = ""
        MyFRMIA002C.Show()
        Me.Hide()

    End Sub



End Class
