Public Class FrmAP602B
  Inherits System.Windows.Forms.Form
  Dim myAPERCN As APERCN.MyData
  Dim myAPEHSTL1 As APEHSTL1.myData
  Dim myAPEBNK As APEBNK.MyData
  Dim myVENDOR As VENDOR.MyData
  Friend WithEvents TxtBnkcd As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtPayck As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents BtnLookup As System.Windows.Forms.Button
  Friend WithEvents LblBnkName As System.Windows.Forms.Label
  Friend WithEvents LblChkDate As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents LblChkAmt As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents LblPayTo As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents LblReconDt As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents DataGrdView As DataGridView
  Friend WithEvents LblChkStatus As System.Windows.Forms.Label
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
    Me.components = New System.ComponentModel.Container()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.TxtBnkcd = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtPayck = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.BtnLookup = New System.Windows.Forms.Button()
    Me.LblBnkName = New System.Windows.Forms.Label()
    Me.LblChkDate = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.LblChkAmt = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.LblPayTo = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.LblReconDt = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.LblChkStatus = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TxtBnkcd
    '
    Me.TxtBnkcd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBnkcd.Location = New System.Drawing.Point(96, 42)
    Me.TxtBnkcd.MaxLength = 5
    Me.TxtBnkcd.Name = "TxtBnkcd"
    Me.TxtBnkcd.Size = New System.Drawing.Size(44, 20)
    Me.TxtBnkcd.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 45)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(60, 13)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "Bank Code"
    '
    'TxtPayck
    '
    Me.TxtPayck.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPayck.Location = New System.Drawing.Point(96, 19)
    Me.TxtPayck.MaxLength = 7
    Me.TxtPayck.Name = "TxtPayck"
    Me.TxtPayck.Size = New System.Drawing.Size(53, 20)
    Me.TxtPayck.TabIndex = 0
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 22)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(78, 13)
    Me.Label2.TabIndex = 4
    Me.Label2.Text = "Check Number"
    '
    'BtnLookup
    '
    Me.BtnLookup.Location = New System.Drawing.Point(164, 15)
    Me.BtnLookup.Name = "BtnLookup"
    Me.BtnLookup.Size = New System.Drawing.Size(54, 26)
    Me.BtnLookup.TabIndex = 2
    Me.BtnLookup.Text = "Lookup"
    Me.BtnLookup.UseVisualStyleBackColor = True
    '
    'LblBnkName
    '
    Me.LblBnkName.AutoSize = True
    Me.LblBnkName.Location = New System.Drawing.Point(152, 45)
    Me.LblBnkName.Name = "LblBnkName"
    Me.LblBnkName.Size = New System.Drawing.Size(75, 13)
    Me.LblBnkName.TabIndex = 6
    Me.LblBnkName.Text = "<Bank Name>"
    '
    'LblChkDate
    '
    Me.LblChkDate.AutoSize = True
    Me.LblChkDate.Location = New System.Drawing.Point(82, 80)
    Me.LblChkDate.Name = "LblChkDate"
    Me.LblChkDate.Size = New System.Drawing.Size(76, 13)
    Me.LblChkDate.TabIndex = 7
    Me.LblChkDate.Text = "<Check Date>"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(12, 80)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(64, 13)
    Me.Label3.TabIndex = 8
    Me.Label3.Text = "Check Date"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(180, 80)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(77, 13)
    Me.Label4.TabIndex = 10
    Me.Label4.Text = "Check Amount"
    '
    'LblChkAmt
    '
    Me.LblChkAmt.AutoSize = True
    Me.LblChkAmt.Location = New System.Drawing.Point(263, 80)
    Me.LblChkAmt.Name = "LblChkAmt"
    Me.LblChkAmt.Size = New System.Drawing.Size(89, 13)
    Me.LblChkAmt.TabIndex = 9
    Me.LblChkAmt.Text = "<Check Amount>"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(12, 105)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(40, 13)
    Me.Label5.TabIndex = 11
    Me.Label5.Text = "Pay to "
    '
    'LblPayTo
    '
    Me.LblPayTo.AutoSize = True
    Me.LblPayTo.Location = New System.Drawing.Point(58, 105)
    Me.LblPayTo.Name = "LblPayTo"
    Me.LblPayTo.Size = New System.Drawing.Size(53, 13)
    Me.LblPayTo.TabIndex = 12
    Me.LblPayTo.Text = "<Pay To>"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(12, 132)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(87, 13)
    Me.Label6.TabIndex = 14
    Me.Label6.Text = "Reconciled Date"
    '
    'LblReconDt
    '
    Me.LblReconDt.AutoSize = True
    Me.LblReconDt.Location = New System.Drawing.Point(105, 132)
    Me.LblReconDt.Name = "LblReconDt"
    Me.LblReconDt.Size = New System.Drawing.Size(99, 13)
    Me.LblReconDt.TabIndex = 13
    Me.LblReconDt.Text = "<Reconciled Date>"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(214, 132)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(71, 13)
    Me.Label7.TabIndex = 16
    Me.Label7.Text = "Check Status"
    '
    'LblChkStatus
    '
    Me.LblChkStatus.AutoSize = True
    Me.LblChkStatus.Location = New System.Drawing.Point(291, 132)
    Me.LblChkStatus.Name = "LblChkStatus"
    Me.LblChkStatus.Size = New System.Drawing.Size(83, 13)
    Me.LblChkStatus.TabIndex = 15
    Me.LblChkStatus.Text = "<Check Status>"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
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
    Me.DataGrdView.Location = New System.Drawing.Point(3, 159)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(465, 218)
    Me.DataGrdView.TabIndex = 207
    '
    'FrmAP602B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(472, 380)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.LblChkStatus)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.LblReconDt)
    Me.Controls.Add(Me.LblPayTo)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.LblChkAmt)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.LblChkDate)
    Me.Controls.Add(Me.LblBnkName)
    Me.Controls.Add(Me.BtnLookup)
    Me.Controls.Add(Me.TxtPayck)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtBnkcd)
    Me.Controls.Add(Me.Label1)
    Me.Name = "FrmAP602B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region
  Private Sub FrmAP602B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myAPERCN = New APERCN.MyData
    myAPERCN.MyDBConn = myDBConnect
    myAPEHSTL1 = New APEHSTL1.myData
    myAPEHSTL1.MyDBConn = myDBConnect
    myAPEBNK = New APEBNK.MyData
    myAPEBNK.MyDBConn = myDBConnect
    myVENDOR = New VENDOR.MyData
    myVENDOR.MyDBConn = myDBConnect

    LblBnkName.Text = ""
    LblChkAmt.Text = ""
    LblChkDate.Text = ""
    LblChkStatus.Text = ""
    LblPayTo.Text = ""
    LblReconDt.Text = ""
  End Sub
  Private Sub FrmAP602B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmAP602.SbpScreen.Text = "AP602B"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
  Private Sub BtnLookup_Click(sender As Object, e As EventArgs) Handles BtnLookup.Click
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)
    With myAPERCN
      .GetOneRecordP(TxtBnkcd.Text, MyUtils.CnvSng(TxtPayck.Text))
      If .RecordNotFound Then
        LblBnkName.Text = ""
        LblChkAmt.Text = ""
        LblChkDate.Text = ""
        LblChkStatus.Text = ""
        LblPayTo.Text = ""
        LblReconDt.Text = ""
      Else
        myAPEBNK.GetOneRecordP(TxtBnkcd.Text)
        myVENDOR.GetOneRecordP(._VNDNR)
        LblBnkName.Text = myAPEBNK._BNKNM
        LblChkAmt.Text = Format(._PAYAM, "Fixed")
        LblChkDate.Text = ""
        If ._PAYP8 > 0 Then
          LblChkDate.Text = MyUtils.GetDBDate(._PAYP8)
        End If
        LblChkStatus.ForeColor = Color.Black
        Select Case ._RCCDE
          Case "P"
            LblChkStatus.Text = "Voided Due to Printer"
            LblChkStatus.ForeColor = Color.Red
          Case "R"
            LblChkStatus.Text = "Reconciled"
          Case "V"
            LblChkStatus.Text = "Void"
            LblChkStatus.ForeColor = Color.Red
          Case Else
            LblChkStatus.Text = "Open"
        End Select
        If Trim(myVENDOR._PYNAM) <> "" Then
          LblPayTo.Text = myVENDOR._PYNAM
        Else
          LblPayTo.Text = myVENDOR._VENNM & " " & myVENDOR._VNDNR
        End If
        LblReconDt.Text = ""
        If ._PAYC8 > 0 Then
          LblReconDt.Text = MyUtils.GetDBDate(._PAYC8)
        End If
      End If
      EditChecks(ErrorField, ErrorMsg)
      ShowError(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        FormatGrid(True)
      Else
        FormatGrid(False)
      End If
    End With
  End Sub
  Public Sub FormatGrid(ByVal Good As Boolean)
    Dim ds As DataSet = New DataSet
    If Good Then
      ds = myAPEHSTL1.GetVndnrChkInv(myAPERCN._VNDNR, myAPERCN._PAYCK, myAPERCN._PAYP8)
      DataGrdView.DataSource = ds.Tables(0)
    Else
      DataGrdView.DataSource = Nothing
      DataGrdView.Rows.Clear()
    End If
    DataGrdView.Refresh()
    If Not Good Then Exit Sub

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "Invoice Number"
      .Columns(0).Width = 125
      .Columns(1).HeaderText = "Amount"
      .Columns(1).DefaultCellStyle.Format = "N2" 'Fixed
      .Columns(1).Width = 75
      .Columns(2).HeaderText = "Fund"
      .Columns(2).Width = 35
      .Columns(3).HeaderText = "Sfund"
      .Columns(3).Width = 35
      .Columns(4).HeaderText = "Dept"
      .Columns(4).Width = 35
      .Columns(5).HeaderText = "Obj"
      .Columns(5).Width = 35
      .Columns(6).HeaderText = "Func"
      .Columns(6).Width = 35
      .Columns(7).HeaderText = "Sfnc"
      .Columns(7).Width = 35
    End With
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtPayck.Text) = 0 Then
      ErrorField(I) = "payck"
      ErrorMsg(I) = "Check Number is required"
      I = I + 1
    End If

    If myAPERCN.RecordNotFound Then
      ErrorField(I) = "cknot"
      ErrorMsg(I) = "Check Number not found"
      I = I + 1
    End If
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
 Dim I As Integer
 ErrProv.Clear()
 For I = 0 To ErrorField.GetUpperBound(0)
   Select Case ErrorField(I)
   Case "cknot"
    ErrProv.SetError(TxtPayck, ErrorMsg(I))
   Case "payck"
    ErrProv.SetError(TxtPayck, ErrorMsg(I))
   Case Nothing
    Exit Sub
  End Select
 Next I
End Sub
End Class
