Imports System.Text
Public Class FrmIA002D
    Inherits System.Windows.Forms.Form
    Dim myGNETPGM As GNETPGM.MyData
    Dim myGNETSEC As GNETSEC.MyData
    Dim ds As DataSet = New DataSet
    Friend WrkGroup As String
    Friend WrkCopyGroup As String

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
    Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents lblgname As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmIA002D))
Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
Me.lblgname = New System.Windows.Forms.Label
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
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
Me.C1DataGrdList.Size = New System.Drawing.Size(832, 328)
Me.C1DataGrdList.TabIndex = 19
Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
'
'lblgname
'
Me.lblgname.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lblgname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
Me.lblgname.Location = New System.Drawing.Point(24, 8)
Me.lblgname.Name = "lblgname"
Me.lblgname.Size = New System.Drawing.Size(336, 24)
Me.lblgname.TabIndex = 20
'
'FrmIA002D
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(848, 384)
Me.ControlBox = False
Me.Controls.Add(Me.lblgname)
Me.Controls.Add(Me.C1DataGrdList)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.Name = "FrmIA002D"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)

End Sub

#End Region

    Private Sub FrmIA002D_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        myGNETPGM = New GNETPGM.MyData()
        myGNETPGM.MyDBConn = myDBConnect
        myGNETSEC = New GNETSEC.MyData()
        myGNETSEC.MyDBConn = myDBConnect
        MyFrmIA002.TBarDelete.Enabled = False
        BuildDS()
        Call FormatGrid()

    End Sub
    Private Sub FrmIA002D_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

        MyFrmIA002.SbpScreen.Text = "IA002D"
        lblgname.Text = "Group:  " + WrkGroup
        MyFrmIA002.TBarPrint.Enabled = False
        MyUtils.CenterForm(Me.ParentForm, Me)

    End Sub
    Private Sub FRMIA002D_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        MyFrmIA002.TBarDelete.Enabled = True
        MyFrmIA002C.Show()
    End Sub
    Public Sub FormatGrid()
    Call ShowGrid()

    With C1DataGrdList
      .Rebind(True)
      .MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
      .Columns(0).Caption = "Program Id"
      .Splits(0).DisplayColumns(0).Width = 60
      .Columns(1).Caption = "Description"
      .Splits(0).DisplayColumns(1).Width = 225

      .Columns(2).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
      .Columns(2).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(0, False)) ' checked
      .Columns(2).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(1, True)) ' unchecked
      .Columns(2).ValueItems.Translate = True
      .Columns(2).Caption = "Full"
      .Splits(0).DisplayColumns(2).Width = 50
      .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

      .Columns(3).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
      .Columns(3).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(0, False)) ' checked
      .Columns(3).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(1, True)) ' unchecked
      .Columns(3).ValueItems.Translate = True
      .Columns(3).Caption = "Add"
      .Splits(0).DisplayColumns(3).Width = 50
      .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

      .Columns(4).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
      .Columns(4).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(0, False)) ' checked
      .Columns(4).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(1, True)) ' unchecked
      .Columns(4).ValueItems.Translate = True
      .Columns(4).Caption = "Delete"
      .Splits(0).DisplayColumns(4).Width = 50
      .Splits(0).DisplayColumns(4).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

      .Columns(5).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
      .Columns(5).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(0, False)) ' checked
      .Columns(5).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(1, True)) ' unchecked
      .Columns(5).ValueItems.Translate = True
      .Columns(5).Caption = "Change"
      .Splits(0).DisplayColumns(5).Width = 50
      .Splits(0).DisplayColumns(5).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

      .Columns(6).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
      .Columns(6).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(0, False)) ' checked
      .Columns(6).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(1, True)) ' unchecked
      .Columns(6).ValueItems.Translate = True
      .Columns(6).Caption = "Inquiry"
      .Splits(0).DisplayColumns(6).Width = 50
      .Splits(0).DisplayColumns(6).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

      .Columns(7).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
      .Columns(7).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(0, False)) ' checked
      .Columns(7).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(1, True)) ' unchecked
      .Columns(7).ValueItems.Translate = True
      .Columns(7).Caption = "Edit"
      .Splits(0).DisplayColumns(7).Width = 50
      .Splits(0).DisplayColumns(7).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

      .Columns(8).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
      .Columns(8).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(0, False)) ' checked
      .Columns(8).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(1, True)) ' unchecked
      .Columns(8).ValueItems.Translate = True
      .Columns(8).Caption = "Post"
      .Splits(0).DisplayColumns(8).Width = 50
      .Splits(0).DisplayColumns(8).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    End With
    End Sub
    Public Sub ShowGrid()
      CreateGrid()
      C1DataGrdList.DataSource = ds.Tables(0)
      C1DataGrdList.Refresh()
    End Sub
    Public Sub CreateGrid()
      Dim ds2 As DataSet = New DataSet
      Dim dr As DataRow
      Dim I As Integer
      ds2 = myGNETPGM.PosData("")
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        dr = ds.Tables(0).NewRow
        dr("pgmid") = ds2.Tables(0).Rows(I).Item("pgmid")
        dr("pgmdesc") = ds2.Tables(0).Rows(I).Item("pgmdesc")
        myGNETSEC.GetOneRecordP(WrkGroup, ds2.Tables(0).Rows(I).Item("pgmid"))
        If Not myGNETSEC.RecordNotFound Then
          dr("full") = GetSec("*")
          dr("add") = GetSec("A")
          dr("del") = GetSec("D")
          dr("chg") = GetSec("C")
          dr("inq") = GetSec("I")
          dr("edit") = GetSec("E")
          dr("post") = GetSec("P")
        Else
          dr("full") = 0
          dr("add") = 0
          dr("del") = 0
          dr("chg") = 0
          dr("inq") = 0
          dr("edit") = 0
          dr("post") = 0
        End If
        ds.Tables(0).Rows.Add(dr)
      Next
    End Sub
    Public Function GetSec(ByVal WrkCode As String) As Integer
      Dim Pos As Integer
      Pos = InStr(Trim(myGNETSEC._RIGHTS), WrkCode)
      Return Pos
    End Function
    Public Sub SaveData()
      Dim WrkRights As String
      Dim sb As StringBuilder
      Dim I As Integer

      Windows.Forms.Cursor.Current = Cursors.WaitCursor()
      myGNETSEC.DeleteRange(WrkGroup)
      For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
        WrkRights = ""
        sb = New StringBuilder
        If C1DataGrdList.Item(I, 2) = 1 Then
          sb.Append("*")
        End If
        If C1DataGrdList.Item(I, 3) = 1 Then
          sb.Append("A")
        End If
        If C1DataGrdList.Item(I, 4) = 1 Then
          sb.Append("D")
        End If
        If C1DataGrdList.Item(I, 5) = 1 Then
          sb.Append("C")
        End If
        If C1DataGrdList.Item(I, 6) = 1 Then
          sb.Append("I")
        End If
        If C1DataGrdList.Item(I, 7) = 1 Then
          sb.Append("E")
        End If
        If C1DataGrdList.Item(I, 8) = 1 Then
          sb.Append("P")
        End If
        WrkRights = sb.ToString
        sb.Clear()
        If WrkRights <> String.Empty Then
          With myGNETSEC
            ._GRPID = WrkGroup
            ._PGMID = Trim(C1DataGrdList.Item(I, 0))
            ._PGMTYP = ""
            ._RIGHTS = WrkRights
            .AddOneRecordP()
          End With
        End If
      Next
      Windows.Forms.Cursor.Current = Cursors.Default
      Me.Close()
    End Sub
    Private Sub BuildDS()
        Dim myTable As New DataTable
        With myTable
          .TableName = "mytable"
          .Columns.Add("pgmid", Type.GetType("System.String"))
          .Columns.Add("pgmdesc", Type.GetType("System.String"))
          .Columns.Add("full", Type.GetType("System.Decimal"))
          .Columns.Add("add", Type.GetType("System.Decimal"))
          .Columns.Add("del", Type.GetType("System.Decimal"))
          .Columns.Add("chg", Type.GetType("System.Decimal"))
          .Columns.Add("inq", Type.GetType("System.Decimal"))
          .Columns.Add("edit", Type.GetType("System.Decimal"))
          .Columns.Add("post", Type.GetType("System.Decimal"))
        End With
        ds.Tables.Add(myTable)
    End Sub
End Class
