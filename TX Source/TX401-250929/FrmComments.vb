Public Class FrmComments
  Inherits System.Windows.Forms.Form
  Dim mytaxcom As TAXCOM.myData
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkType As String
  Friend WrkPrevScreen As String
  Friend WithEvents TxtComment As TextBox
  Dim dscom As DataSet = New DataSet

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
  Friend WithEvents LblList As System.Windows.Forms.Label
  Friend WithEvents label1 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.LblName = New System.Windows.Forms.Label()
    Me.LblList = New System.Windows.Forms.Label()
    Me.label1 = New System.Windows.Forms.Label()
    Me.TxtComment = New System.Windows.Forms.TextBox()
    Me.SuspendLayout()
    '
    'LblName
    '
    Me.LblName.BackColor = System.Drawing.SystemColors.Control
    Me.LblName.Location = New System.Drawing.Point(112, 8)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(272, 16)
    Me.LblName.TabIndex = 160
    Me.LblName.UseMnemonic = False
    '
    'LblList
    '
    Me.LblList.BackColor = System.Drawing.SystemColors.Control
    Me.LblList.Location = New System.Drawing.Point(64, 8)
    Me.LblList.Name = "LblList"
    Me.LblList.Size = New System.Drawing.Size(48, 16)
    Me.LblList.TabIndex = 156
    '
    'label1
    '
    Me.label1.BackColor = System.Drawing.SystemColors.Control
    Me.label1.Location = New System.Drawing.Point(8, 8)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(48, 12)
    Me.label1.TabIndex = 154
    Me.label1.Text = "Account"
    '
    'TxtComment
    '
    Me.TxtComment.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtComment.Location = New System.Drawing.Point(11, 31)
    Me.TxtComment.Multiline = True
    Me.TxtComment.Name = "TxtComment"
    Me.TxtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.TxtComment.Size = New System.Drawing.Size(435, 340)
    Me.TxtComment.TabIndex = 213
    '
    'FrmComments
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(450, 383)
    Me.Controls.Add(Me.TxtComment)
    Me.Controls.Add(Me.LblName)
    Me.Controls.Add(Me.LblList)
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
    With MyFrmTX401
      .TBarComments.Enabled = False
    End With

    If s_full = True Or s_add = True Or s_chg = True Then
      MyFrmTX401.TBarSave.Enabled = True
      MyFrmTX401.TBarSave.Visible = True
    End If

    mytaxcom = New TAXCOM.mydata(MyDBConnect)
    LblList.Text = WrkListNo

    Select Case WrkType
      Case "M"
        LblName.Text = MyFrmTX401MV.TxtName.Text
      Case "P"
        LblName.Text = MyFrmTX401PP.TxtName.Text
      Case "R"
        LblName.Text = MyFrmTX401RE.TxtName.Text
      Case "S"
        LblName.Text = MyFrmTX401SU.TxtName.Text
    End Select

    Call FormatText()
  End Sub
  Public Sub FormatText()
    Dim ds As DataSet
    Dim I As Integer
    Dim WrkStr As String

    ds = mytaxcom.Getcomments(WrkListNo, WrkType, WrkYear)
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
    MyFrmTX401.SbpScreen.Text = WrkPrevScreen

    MyFrmTX401.TBarSave.Enabled = True
    MyFrmTX401.TBarComments.Enabled = True

    Select Case WrkPrevScreen
      Case "TX401MV"
        MyFrmTX401MV.Show()
      Case "TX401PP"
        MyFrmTX401PP.Show()
      Case "TX401RE"
        MyFrmTX401RE.Show()
      Case "TX401SU"
        MyFrmTX401SU.Show()
    End Select

    'Memory Cleanup
    mytaxcom = Nothing
    MyFrmComments = Nothing
  End Sub
  Private Sub FrmComments_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTX401.SbpScreen.Text = "Comments"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub SaveData()
    Dim I As Integer
    Dim WrkLen As Integer
    Dim WrkRecs As Integer
    Dim WrkPos As Integer

    mytaxcom.DeleteKeyComment(WrkListNo, WrkType, WrkYear)
    WrkLen = Len(TxtComment.Text)
    WrkRecs = Math.Ceiling(WrkLen / 60)
    For I = 0 To WrkRecs - 1
      WrkPos = (I * 60) + 1
      With mytaxcom
        .GetOneRecordP(WrkListNo, WrkType, WrkYear, I)
        ._CMNT = Mid(TxtComment.Text, WrkPos, 60)
        ._CSEQ = I
        ._LISTNO = WrkListNo
        ._TYPE = WrkType
        ._YEAR = WrkYear
        .AddOneRecordP()
      End With
    Next

    MyFrmTX401.TBarComments.ImageKey = ""
    If WrkRecs > 0 Then
      MyFrmTX401.TBarComments.ImageKey = "comment_24.png"
    End If
    Me.Close()
  End Sub
End Class






