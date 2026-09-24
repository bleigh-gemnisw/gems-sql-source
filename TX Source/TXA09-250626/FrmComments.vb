Public Class FrmComments
  Inherits System.Windows.Forms.Form
  Dim myTAXCOM As TAXCOM.MyData
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkType As String
  Friend WrkName As String
  Friend WithEvents TxtComment As System.Windows.Forms.TextBox
  Dim dsCOM As DataSet = New DataSet

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
  Friend WithEvents LblName As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents LblType As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents LblList As System.Windows.Forms.Label
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents LblYear As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.LblName = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.LblType = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.LblList = New System.Windows.Forms.Label()
    Me.label2 = New System.Windows.Forms.Label()
    Me.label1 = New System.Windows.Forms.Label()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.TxtComment = New System.Windows.Forms.TextBox()
    Me.SuspendLayout()
    '
    'LblName
    '
    Me.LblName.BackColor = System.Drawing.SystemColors.Control
    Me.LblName.Location = New System.Drawing.Point(104, 24)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(216, 16)
    Me.LblName.TabIndex = 160
    Me.LblName.UseMnemonic = False
    '
    'Label7
    '
    Me.Label7.BackColor = System.Drawing.SystemColors.Control
    Me.Label7.Location = New System.Drawing.Point(160, 8)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(32, 12)
    Me.Label7.TabIndex = 159
    Me.Label7.Text = "Type"
    '
    'LblType
    '
    Me.LblType.BackColor = System.Drawing.SystemColors.Control
    Me.LblType.Location = New System.Drawing.Point(200, 8)
    Me.LblType.Name = "LblType"
    Me.LblType.Size = New System.Drawing.Size(16, 16)
    Me.LblType.TabIndex = 158
    '
    'Label3
    '
    Me.Label3.BackColor = System.Drawing.SystemColors.Control
    Me.Label3.Location = New System.Drawing.Point(224, 8)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(32, 12)
    Me.Label3.TabIndex = 157
    Me.Label3.Text = "Year"
    '
    'LblList
    '
    Me.LblList.BackColor = System.Drawing.SystemColors.Control
    Me.LblList.Location = New System.Drawing.Point(104, 8)
    Me.LblList.Name = "LblList"
    Me.LblList.Size = New System.Drawing.Size(48, 16)
    Me.LblList.TabIndex = 156
    '
    'label2
    '
    Me.label2.BackColor = System.Drawing.SystemColors.Control
    Me.label2.Location = New System.Drawing.Point(8, 24)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(84, 12)
    Me.label2.TabIndex = 155
    Me.label2.Text = "Name of Owner"
    '
    'label1
    '
    Me.label1.BackColor = System.Drawing.SystemColors.Control
    Me.label1.Location = New System.Drawing.Point(8, 8)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(36, 12)
    Me.label1.TabIndex = 154
    Me.label1.Text = "List #"
    '
    'LblYear
    '
    Me.LblYear.BackColor = System.Drawing.SystemColors.Control
    Me.LblYear.Location = New System.Drawing.Point(256, 8)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(48, 16)
    Me.LblYear.TabIndex = 162
    '
    'TxtComment
    '
    Me.TxtComment.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtComment.Location = New System.Drawing.Point(12, 43)
    Me.TxtComment.Multiline = True
    Me.TxtComment.Name = "TxtComment"
    Me.TxtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.TxtComment.Size = New System.Drawing.Size(426, 340)
    Me.TxtComment.TabIndex = 211
    '
    'FrmComments
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(450, 406)
    Me.Controls.Add(Me.TxtComment)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.LblName)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.LblType)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.LblList)
    Me.Controls.Add(Me.label2)
    Me.Controls.Add(Me.label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmComments"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Comments"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmComments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmTXA09.TBarSave.Enabled = False
    MyFrmTXA09.TBarSave.Visible = False
    If Not MyInquiryAssr Then
      If s_full = True Or s_add = True Or s_chg = True Then
        MyFrmTXA09.TBarSave.Enabled = True
        MyFrmTXA09.TBarSave.Visible = True
      End If
    End If

    myTAXCOM = New TAXCOM.MyData(myDBConnect)
    LblList.Text = WrkListNo
    LblYear.Text = WrkYear
    LblType.Text = WrkType
    LblName.Text = WrkName

    BuildDS()
    FormatText()
  End Sub
  Public Sub FormatText()
    Dim ds As DataSet
    Dim I As Integer
    Dim WrkStr As String

    ds = myTAXCOM.Getcomments(WrkListNo, WrkType, WrkYear)
    WrkStr = ""
    For I = 0 To ds.Tables(0).Rows.Count - 1
      If Len(ds.Tables(0).Rows(I).Item("cmnt")) = 59 Then
        WrkStr = WrkStr + ds.Tables(0).Rows(I).Item("cmnt") & " "
      Else
        WrkStr = WrkStr + ds.Tables(0).Rows(I).Item("cmnt")
      End If
    Next
    TxtComment.Text = Trim(WrkStr)
  End Sub
  Private Sub FrmComments_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTXA09.SbpScreen.Text = "TXA09B"
    With MyFrmTXA09
      .TBarSave.Enabled = False
      If MyInquiryMode = True Then
        .TBarSave.Visible = False
      End If
    End With
    MyFrmTXA09B.ShowComments()
    MyFrmTXA09B.Show()
    'Memory Cleanup
    myTAXCOM = Nothing
    MyFrmComments = Nothing
  End Sub
  Private Sub FrmComments_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA09.SbpScreen.Text = "Comments"
    Call MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub SaveData()
    Dim I As Integer
    Dim WrkLen As Integer
    Dim WrkRecs As Integer
    Dim WrkPos As Integer

    myTAXCOM.DeleteKeyComment(WrkListNo, WrkType, WrkYear)
    WrkLen = Len(TxtComment.Text)
    WrkRecs = Math.Ceiling(WrkLen / 60)
    For I = 0 To WrkRecs - 1
      WrkPos = (I * 60) + 1
      With myTAXCOM
        .GetOneRecordP(WrkListNo, WrkType, WrkYear, I)
        ._CMNT = Mid(TxtComment.Text, WrkPos, 60)
        ._CSEQ = I
        ._LISTNO = WrkListNo
        ._TYPE = WrkType
        ._YEAR = WrkYear
        .AddOneRecordP()
      End With
    Next

    MyFrmTXA09B.BtnComments.ImageKey = ""
    If dsCOM.Tables(0).Rows.Count > 0 Then
      MyFrmTXA09B.BtnComments.ImageKey = "comment_24.png"
    End If
    Me.Close()
  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Cmnt", Type.GetType("System.String"))
      .Columns.Add("Cseq", Type.GetType("System.Int32"))
    End With
    dsCOM.Tables.Add(myTable)
  End Sub
End Class






