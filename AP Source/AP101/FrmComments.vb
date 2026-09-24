Public Class FrmComments
  Inherits System.Windows.Forms.Form
  Dim myFINCOMMENTS As FINCOMMENTS.MyData
  Friend WrkTHEKEY As String
  Friend WrkAPPL As String
  Friend WrkDESC As String
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
  Friend WithEvents Lblkey As System.Windows.Forms.Label
  Friend WithEvents lblappl As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.LblName = New System.Windows.Forms.Label()
    Me.Lblkey = New System.Windows.Forms.Label()
    Me.lblappl = New System.Windows.Forms.Label()
    Me.TxtComment = New System.Windows.Forms.TextBox()
    Me.SuspendLayout()
    '
    'LblName
    '
    Me.LblName.BackColor = System.Drawing.SystemColors.Control
    Me.LblName.Location = New System.Drawing.Point(214, 8)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(272, 16)
    Me.LblName.TabIndex = 160
    Me.LblName.UseMnemonic = False
    '
    'Lblkey
    '
    Me.Lblkey.BackColor = System.Drawing.SystemColors.Control
    Me.Lblkey.Location = New System.Drawing.Point(104, 8)
    Me.Lblkey.Name = "Lblkey"
    Me.Lblkey.Size = New System.Drawing.Size(88, 16)
    Me.Lblkey.TabIndex = 156
    '
    'lblappl
    '
    Me.lblappl.BackColor = System.Drawing.SystemColors.Control
    Me.lblappl.Location = New System.Drawing.Point(8, 8)
    Me.lblappl.Name = "lblappl"
    Me.lblappl.Size = New System.Drawing.Size(74, 12)
    Me.lblappl.TabIndex = 154
    Me.lblappl.Text = "Account"
    '
    'TxtComment
    '
    Me.TxtComment.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtComment.Location = New System.Drawing.Point(12, 31)
    Me.TxtComment.Multiline = True
    Me.TxtComment.Name = "TxtComment"
    Me.TxtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.TxtComment.Size = New System.Drawing.Size(513, 340)
    Me.TxtComment.TabIndex = 212
    '
    'FrmComments
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(537, 383)
    Me.Controls.Add(Me.TxtComment)
    Me.Controls.Add(Me.LblName)
    Me.Controls.Add(Me.Lblkey)
    Me.Controls.Add(Me.lblappl)
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

    With MyFrmAP101
      SaveDelete = .TBarDelete.Enabled
      .TBarDelete.Enabled = False
      .TBarComments.Enabled = False

    End With

    If s_full = True Or s_add = True Or s_chg = True Then
      MyFrmAP101.TBarSave.Enabled = True
      MyFrmAP101.TBarSave.Visible = True
    End If

    myFINCOMMENTS = New FINCOMMENTS.MyData(myDBConnect)
    Lblkey.Text = WrkTHEKEY
    lblappl.Text = WrkAPPL
    LblName.Text = WrkDESC


    Call FormatText()
  End Sub
  Public Sub FormatText()
    Dim ds As DataSet
    Dim I As Integer
    Dim WrkStr As String

    ds = myFINCOMMENTS.Getcomments(WrkTHEKEY, WrkAPPL)
    WrkStr = ""
    For I = 0 To ds.Tables(0).Rows.Count - 1
      If Len(ds.Tables(0).Rows(I).Item("comment")) = 59 Then
        WrkStr = WrkStr + ds.Tables(0).Rows(I).Item("comment") & " "
      Else
        WrkStr = WrkStr + ds.Tables(0).Rows(I).Item("comment")
      End If
    Next
    TxtComment.Text = Trim(WrkStr)
  End Sub
  Private Sub FrmComments_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmAP101.SbpScreen.Text = WrkPrevScreen

    MyFrmAP101.TBarSave.Enabled = True
    MyFrmAP101.TBarDelete.Enabled = False
    MyFrmAP101.TBarComments.Enabled = True
    MyFrmAP101C.Show()

    'Memory Cleanup
    myFINCOMMENTS = Nothing
    MyFrmComments = Nothing
  End Sub
  Private Sub FrmComments_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmAP101.SbpScreen.Text = "Comments"
    Call MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub SaveData()
    Dim I As Integer
    Dim WrkLen As Integer
    Dim WrkRecs As Integer
    Dim WrkPos As Integer

    myFINCOMMENTS.DeleteKeyComment(WrkTHEKEY, WrkAPPL)
    WrkLen = Len(TxtComment.Text)
    WrkRecs = Math.Ceiling(WrkLen / 60)
    For I = 0 To WrkRecs - 1
      WrkPos = (I * 60) + 1
      With myFINCOMMENTS
        .GetOneRecordP(WrkTHEKEY, WrkAPPL, I)
        ._COMMENT = Mid(TxtComment.Text, WrkPos, 60)
        ._CSEQ = I
        ._THEKEY = WrkTHEKEY
        ._APPL = WrkAPPL

        .AddOneRecordP()
      End With
    Next

    MyFrmAP101.TBarComments.ImageKey = ""
    If WrkRecs > 0 Then
      MyFrmAP101.TBarComments.ImageKey = "comment_24.png"
    End If
    Me.Close()
  End Sub
End Class






