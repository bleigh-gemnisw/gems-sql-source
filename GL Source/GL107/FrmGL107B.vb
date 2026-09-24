Imports System.Data
Public Class FrmGL107B
  Inherits System.Windows.Forms.Form
    Dim myGLACCT As GLACCT.MyData
    Dim myDEPSEC As DEPSEC.MyData
    Dim ds As DataSet = New DataSet
 Friend WithEvents TxtSubfn As System.Windows.Forms.TextBox
 Friend WithEvents TxtFnpgm As System.Windows.Forms.TextBox
 Friend WithEvents TxtObnbr As System.Windows.Forms.TextBox
 Friend WithEvents TxtDpnbr As System.Windows.Forms.TextBox
 Friend WithEvents TxtSfund As System.Windows.Forms.TextBox
 Friend WithEvents TxtFdnbr As System.Windows.Forms.TextBox
 Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
 Friend WithEvents Label3 As System.Windows.Forms.Label

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
 Friend WithEvents BtnNext As System.Windows.Forms.Button
 <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtSubfn = New System.Windows.Forms.TextBox()
    Me.TxtFnpgm = New System.Windows.Forms.TextBox()
    Me.TxtObnbr = New System.Windows.Forms.TextBox()
    Me.TxtDpnbr = New System.Windows.Forms.TextBox()
    Me.TxtSfund = New System.Windows.Forms.TextBox()
    Me.TxtFdnbr = New System.Windows.Forms.TextBox()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(354, 10)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 6
    Me.BtnFind.Text = "&Find"
    '
    'BtnNext
    '
    Me.BtnNext.Location = New System.Drawing.Point(413, 10)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(53, 24)
    Me.BtnNext.TabIndex = 7
    Me.BtnNext.Text = "&Next"
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(9, 16)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(64, 16)
    Me.Label3.TabIndex = 201
    Me.Label3.Text = "Position To"
    '
    'TxtSubfn
    '
    Me.TxtSubfn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSubfn.Location = New System.Drawing.Point(295, 10)
    Me.TxtSubfn.MaxLength = 4
    Me.TxtSubfn.Name = "TxtSubfn"
    Me.TxtSubfn.Size = New System.Drawing.Size(45, 22)
    Me.TxtSubfn.TabIndex = 5
    '
    'TxtFnpgm
    '
    Me.TxtFnpgm.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFnpgm.Location = New System.Drawing.Point(244, 10)
    Me.TxtFnpgm.MaxLength = 4
    Me.TxtFnpgm.Name = "TxtFnpgm"
    Me.TxtFnpgm.Size = New System.Drawing.Size(45, 22)
    Me.TxtFnpgm.TabIndex = 4
    '
    'TxtObnbr
    '
    Me.TxtObnbr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObnbr.Location = New System.Drawing.Point(206, 10)
    Me.TxtObnbr.MaxLength = 3
    Me.TxtObnbr.Name = "TxtObnbr"
    Me.TxtObnbr.Size = New System.Drawing.Size(32, 22)
    Me.TxtObnbr.TabIndex = 3
    '
    'TxtDpnbr
    '
    Me.TxtDpnbr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDpnbr.Location = New System.Drawing.Point(155, 10)
    Me.TxtDpnbr.MaxLength = 4
    Me.TxtDpnbr.Name = "TxtDpnbr"
    Me.TxtDpnbr.Size = New System.Drawing.Size(45, 22)
    Me.TxtDpnbr.TabIndex = 2
    '
    'TxtSfund
    '
    Me.TxtSfund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfund.Location = New System.Drawing.Point(117, 10)
    Me.TxtSfund.MaxLength = 3
    Me.TxtSfund.Name = "TxtSfund"
    Me.TxtSfund.Size = New System.Drawing.Size(32, 22)
    Me.TxtSfund.TabIndex = 1
    '
    'TxtFdnbr
    '
    Me.TxtFdnbr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFdnbr.Location = New System.Drawing.Point(79, 10)
    Me.TxtFdnbr.MaxLength = 3
    Me.TxtFdnbr.Name = "TxtFdnbr"
    Me.TxtFdnbr.Size = New System.Drawing.Size(32, 22)
    Me.TxtFdnbr.TabIndex = 0
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
    Me.DataGrdView.Location = New System.Drawing.Point(12, 40)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(582, 317)
    Me.DataGrdView.TabIndex = 351
    '
    'FrmGL107B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(606, 363)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.TxtSubfn)
    Me.Controls.Add(Me.TxtFnpgm)
    Me.Controls.Add(Me.TxtObnbr)
    Me.Controls.Add(Me.TxtDpnbr)
    Me.Controls.Add(Me.TxtSfund)
    Me.Controls.Add(Me.TxtFdnbr)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.BtnNext)
    Me.Controls.Add(Me.BtnFind)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "FrmGL107B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

  Private Sub FrmGL107B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    myGLACCT = New GLACCT.MyData()
        myGLACCT.MyDBConn = myDBConnect

        myDEPSEC = New DEPSEC.MyData()
        myDEPSEC.MyDBConn = myDBConnect

        If Date.Today.Month <= 6 Then
      myFromDate = "#7/1/" & Date.Today.Year - 1 & "#"
    Else
      myFromDate = "#7/1/" & Date.Today.Year & "#"
    End If
    myToDate = Date.Today
        Call FormatGrid()
        MyIsLedger = True

  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
  Call FormatGrid()
 End Sub

 Public Sub FormatGrid()

  Call ShowGrid()
  With DataGrdView
   .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
   .RowHeadersWidth = 25
   .Columns(0).HeaderText = "Fund"
   .Columns(0).Width = 35
   .Columns(1).HeaderText = "Sfund"
   .Columns(1).Width = 35
   .Columns(2).HeaderText = "Dept"
   .Columns(2).Width = 35
   .Columns(3).HeaderText = "Obj"
   .Columns(3).Width = 35
   .Columns(4).HeaderText = "Func"
   .Columns(4).Width = 35
   .Columns(5).HeaderText = "Sfnc"
   .Columns(5).Width = 35
   .Columns(6).HeaderText = "Description"
   .Columns(6).Width = 250
   .Columns(7).HeaderText = "Type"
   .Columns(7).Width = 75
   .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
  End With

 End Sub
  Private Sub DataGrdView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGrdView.CellFormatting
    Dim Temp As String
    If (e.ColumnIndex = 7) Then
    Temp = DataGrdView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
      Select Case Temp
      Case "A"
        e.Value = "Asset"
      Case "H"
        e.Value = "Header"
      Case "L"
        e.Value = "Liability"
      Case "R"
        e.Value = "Revenue"
      Case "Q"
        e.Value = "Equity"
      Case "X"
        e.Value = "Expenditure"
      Case Else
      End Select
    End If
  End Sub
    Public Sub ShowGrid()
        Dim Wrkhasdepsec As Boolean
        Dim Wrkfund As Integer
        Dim wrksfund As Integer
        Dim wrkdept As Integer
        Dim i As Integer
        ds = myGLACCT.GetViewbyAcct(MyUtils.CnvSng(TxtFdnbr.Text), MyUtils.CnvSng(TxtSfund.Text), MyUtils.CnvSng(TxtDpnbr.Text),
    MyUtils.CnvSng(TxtObnbr.Text), MyUtils.CnvSng(TxtFnpgm.Text), MyUtils.CnvSng(TxtSubfn.Text), 100)

        'filter out non secure depts
        'i = ds.Tables(0).Rows.Count - 1

        For i = (ds.Tables(0).Rows.Count - 1) To 0 Step -1

            Wrkfund = ds.Tables(0).Rows(i).Item("fdnbr")
            wrksfund = ds.Tables(0).Rows(i).Item("sfund")
            wrkdept = ds.Tables(0).Rows(i).Item("dpnbr")

            Wrkhasdepsec = CheckDepSec(Wrkfund, wrksfund, wrkdept)
            If Wrkhasdepsec = False Then
                ds.Tables(0).Rows(i).Delete()

            End If
            ' i = i - 1
        Next

        ds.AcceptChanges()




        DataGrdView.DataSource = ds.Tables(0)
        DataGrdView.Refresh()
    End Sub
    Public Function CheckDepSec(ByVal WrkFund As Integer, WrkSfund As Integer, WrkDept As Integer) As Boolean
        Dim Wrkhasdepsec As Boolean
        Wrkhasdepsec = True
        With myDEPSEC
            ' if all zeros then got access t oeverything
            .GetOneRecordP(MyUserID, 0, 0, 0)
            If .RecordNotFound Then
                'dept zero then gets all of department
                .GetOneRecordP(MyUserID, WrkFund, WrkSfund, 0)
                If .RecordNotFound Then
                    'check if has the dept
                    .GetOneRecordP(MyUserID, WrkFund, WrkSfund, WrkDept)
                End If
                If .RecordNotFound Then
                    Wrkhasdepsec = False
                End If
            End If ' all zeros
            Return Wrkhasdepsec
        End With

    End Function
    Private Sub FrmGL107B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGL107.SbpScreen.Text = "GL107B"
    MyUtils.CenterForm(Me.ParentForm, Me)

  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
    Dim I As Integer
    I = ds.Tables(0).Rows.Count - 1
    TxtFdnbr.Text = DataGrdView.Item(0, I).Value
    TxtSfund.Text = DataGrdView.Item(1, I).Value
    TxtDpnbr.Text = DataGrdView.Item(2, I).Value
    TxtObnbr.Text = DataGrdView.Item(3, I).Value
    TxtFnpgm.Text = DataGrdView.Item(4, I).Value
    TxtSubfn.Text = DataGrdView.Item(5, I).Value
    FormatGrid()
  End Sub
Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    MyFrmGL107C = New FrmGL107C
    MyFrmGL107C.MdiParent = Me.ParentForm
    MyFrmGL107C.WrkFdnbr = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    MyFrmGL107C.WrkSfund = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
    MyFrmGL107C.WrkDpnbr = DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value
    MyFrmGL107C.WrkObnbr = DataGrdView.Item(3, DataGrdView.CurrentRow.Index).Value
    MyFrmGL107C.WrkFnpgm = DataGrdView.Item(4, DataGrdView.CurrentRow.Index).Value
    MyFrmGL107C.WrkSubfn = DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value
    MyFrmGL107C.WrkGLType = DataGrdView.Item(7, DataGrdView.CurrentRow.Index).Value
    MyFrmGL107C.Show()
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub TxtFdnbr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFdnbr.KeyPress
 e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtSfund_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSfund.KeyPress
 e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDpnbr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDpnbr.KeyPress
 e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtObnbr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtObnbr.KeyPress
 e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtFnpgm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFnpgm.KeyPress
 e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtSubfn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSubfn.KeyPress
 e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class
