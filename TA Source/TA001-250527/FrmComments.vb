Public Class FrmComments
  Inherits System.Windows.Forms.Form
  Dim myTAXCOM As TAXCOM.MyData
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkType As String
  Friend WrkPrevScreen As String
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
    Me.TxtComment.Location = New System.Drawing.Point(12, 31)
    Me.TxtComment.Multiline = True
    Me.TxtComment.Name = "TxtComment"
    Me.TxtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.TxtComment.Size = New System.Drawing.Size(426, 340)
    Me.TxtComment.TabIndex = 212
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

    With MyFrmTA001
      SaveDelete = .TBarDelete.Enabled
      .TBarDelete.Enabled = False
      .TBarComments.Enabled = False
      .TBarLog.Enabled = False
    End With

    If s_full = True Or s_add = True Or s_chg = True Then
      MyFrmTA001.TBarSave.Enabled = True
      MyFrmTA001.TBarSave.Visible = True
    End If

    myTAXCOM = New TAXCOM.MyData(myDBConnect)
    LblList.Text = WrkListNo

    Select Case WrkType
      Case "M"
        LblName.Text = MyFrmTA001MV.TxtName.Text
      Case "P"
        LblName.Text = MyFrmTA001PP.TxtName.Text
      Case "R"
        LblName.Text = MyFrmTA001RE.TxtName.Text
      Case "S"
        LblName.Text = MyFrmTA001SU.TxtName.Text
    End Select

    Call FormatText()
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
    MyFrmTA001.SbpScreen.Text = WrkPrevScreen

    MyFrmTA001.TBarSave.Enabled = True
    If SaveDelete Then
      MyFrmTA001.TBarDelete.Enabled = True
      MyFrmTA001.TBarComments.Enabled = True
    End If
    MyFrmTA001.TBarLog.Enabled = True

    Select Case WrkPrevScreen
      Case "TA001MV"
        MyFrmTA001MV.Show()
      Case "TA001PP"
        MyFrmTA001PP.Show()
      Case "TA001RE"
        MyFrmTA001RE.Show()
      Case "TA001SU"
        MyFrmTA001SU.Show()
    End Select

    'Memory Cleanup
    myTAXCOM = Nothing
    MyFrmComments = Nothing
  End Sub
  Private Sub FrmComments_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA001.SbpScreen.Text = "Comments"
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

    MyFrmTA001.TBarComments.ImageKey = ""
    If WrkRecs > 0 Then
      MyFrmTA001.TBarComments.ImageKey = "comment_24.png"
    End If
    Me.Close()
  End Sub
End Class






