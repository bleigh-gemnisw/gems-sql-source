Public Class FrmComments
  Inherits System.Windows.Forms.Form
  Dim myTXDCCOM As TXDCCOM.MyData
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Dim dsCOM As DataSet = New DataSet
  Friend WithEvents LblYear As System.Windows.Forms.Label
  Friend WithEvents LblListNo As System.Windows.Forms.Label
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents Label29 As System.Windows.Forms.Label
  Friend WithEvents TxtComment As System.Windows.Forms.TextBox
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
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.LblListNo = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.TxtComment = New System.Windows.Forms.TextBox()
    Me.SuspendLayout()
    '
    'LblYear
    '
    Me.LblYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblYear.Location = New System.Drawing.Point(184, 8)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(33, 18)
    Me.LblYear.TabIndex = 207
    Me.LblYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblListNo
    '
    Me.LblListNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblListNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblListNo.Location = New System.Drawing.Point(62, 8)
    Me.LblListNo.Name = "LblListNo"
    Me.LblListNo.Size = New System.Drawing.Size(56, 18)
    Me.LblListNo.TabIndex = 206
    Me.LblListNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label30
    '
    Me.Label30.Location = New System.Drawing.Point(5, 9)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(51, 17)
    Me.Label30.TabIndex = 209
    Me.Label30.Text = "List No"
    '
    'Label29
    '
    Me.Label29.Location = New System.Drawing.Point(147, 9)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(35, 17)
    Me.Label29.TabIndex = 208
    Me.Label29.Text = "Year"
    '
    'TxtComment
    '
    Me.TxtComment.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtComment.Location = New System.Drawing.Point(12, 31)
    Me.TxtComment.Multiline = True
    Me.TxtComment.Name = "TxtComment"
    Me.TxtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.TxtComment.Size = New System.Drawing.Size(426, 340)
    Me.TxtComment.TabIndex = 210
    '
    'FrmComments
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(451, 383)
    Me.Controls.Add(Me.TxtComment)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.LblListNo)
    Me.Controls.Add(Me.Label30)
    Me.Controls.Add(Me.Label29)
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

    With MyFrmTAP01
      SaveDelete = .TBarDelete.Enabled
      .TBarDelete.Enabled = False
      .TBarComments.Enabled = False
      .TbForms.Visible = False
    End With

    If s_full = True Or s_add = True Or s_chg = True Then
      MyFrmTAP01.TBarSave.Enabled = True
      MyFrmTAP01.TBarSave.Visible = True
    End If

    myTXDCCOM = New TXDCCOM.MyData(myDBConnect)
    LblListNo.Text = WrkListNo
    LblYear.Text = WrkYear

    BuildDS()
    Call FormatText()
  End Sub
  Public Sub FormatText()
    Dim ds As DataSet
    Dim I As Integer
    Dim WrkStr As String

    ds = myTXDCCOM.Getcomments(WrkListNo, WrkYear)
    WrkStr = ""
    For I = 0 To ds.Tables(0).Rows.Count - 1
      If Len(ds.Tables(0).Rows(I).Item("cmnt")) = 49 Then
        WrkStr = WrkStr + ds.Tables(0).Rows(I).Item("cmnt") & " "
      Else
        WrkStr = WrkStr + ds.Tables(0).Rows(I).Item("cmnt")
      End If
    Next
    TxtComment.Text = Trim(WrkStr)
  End Sub

  Private Sub FrmComments_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

    MyFrmTAP01.TBarSave.Enabled = True
    If SaveDelete Then
      MyFrmTAP01.TBarDelete.Enabled = True
      MyFrmTAP01.TBarComments.Enabled = True
      MyFrmTAP01.TbForms.Visible = True
    End If

    MyFrmTAP01C.Show()

    'Memory Cleanup
    myTXDCCOM = Nothing
    MyFrmComments = Nothing
  End Sub
  Private Sub FrmComments_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP01.SbpScreen.Text = "Comments"
    Call MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub SaveData()
    Dim I As Integer
    Dim WrkLen As Integer
    Dim WrkRecs As Integer
    Dim WrkPos As Integer

    myTXDCCOM.DeleteKEYcomment(WrkListNo, WrkYear)
    WrkLen = Len(TxtComment.Text)
    WrkRecs = Math.Ceiling(WrkLen / 50)
    For I = 0 To WrkRecs - 1
      WrkPos = (I * 50) + 1
      With myTXDCCOM
        .GetOneRecordP(WrkListNo, WrkYear, I)
        ._CMNT = Mid(TxtComment.Text, WrkPos, 50)
        ._SEQNO = I
        ._LISTNO = WrkListNo
        ._YEAR = WrkYear
        .AddOneRecordP()
      End With
    Next

    MyFrmTAP01.TBarComments.ImageKey = ""
    If WrkRecs > 0 Then
      MyFrmTAP01.TBarComments.ImageKey = "comment_24.png"
    End If
    Me.Close()
  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Cmnt", Type.GetType("System.String"))
      .Columns.Add("seqno", Type.GetType("System.Int32"))
    End With
    dsCOM.Tables.Add(myTable)
  End Sub
End Class






