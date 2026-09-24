Public Class FrmComments
  Inherits System.Windows.Forms.Form
  Dim MyFACMNTS As FACMNTS.myData
  Friend WrkTagNo As String
  Friend WithEvents TxtComment As System.Windows.Forms.TextBox

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
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents LblDesc As System.Windows.Forms.Label
  Friend WithEvents LblTagNo As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.LblDesc = New System.Windows.Forms.Label()
    Me.LblTagNo = New System.Windows.Forms.Label()
    Me.label1 = New System.Windows.Forms.Label()
    Me.TxtComment = New System.Windows.Forms.TextBox()
    Me.SuspendLayout()
    '
    'LblDesc
    '
    Me.LblDesc.BackColor = System.Drawing.SystemColors.Control
    Me.LblDesc.Location = New System.Drawing.Point(112, 8)
    Me.LblDesc.Name = "LblDesc"
    Me.LblDesc.Size = New System.Drawing.Size(272, 16)
    Me.LblDesc.TabIndex = 160
    Me.LblDesc.UseMnemonic = False
    '
    'LblTagNo
    '
    Me.LblTagNo.BackColor = System.Drawing.SystemColors.Control
    Me.LblTagNo.Location = New System.Drawing.Point(64, 8)
    Me.LblTagNo.Name = "LblTagNo"
    Me.LblTagNo.Size = New System.Drawing.Size(48, 16)
    Me.LblTagNo.TabIndex = 156
    '
    'label1
    '
    Me.label1.BackColor = System.Drawing.SystemColors.Control
    Me.label1.Location = New System.Drawing.Point(8, 8)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(48, 16)
    Me.label1.TabIndex = 154
    Me.label1.Text = "Tag "
    '
    'TxtComment
    '
    Me.TxtComment.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtComment.Location = New System.Drawing.Point(11, 31)
    Me.TxtComment.Multiline = True
    Me.TxtComment.Name = "TxtComment"
    Me.TxtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.TxtComment.Size = New System.Drawing.Size(635, 340)
    Me.TxtComment.TabIndex = 213
    '
    'FrmComments
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(658, 383)
    Me.Controls.Add(Me.TxtComment)
    Me.Controls.Add(Me.LblDesc)
    Me.Controls.Add(Me.LblTagNo)
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

    With MyFrmFA001
      .TBarDelete.Enabled = False
      .TBarComments.Enabled = False
    End With

    If s_full = True Or s_add = True Or s_chg = True Then
      MyFrmFA001.TBarSave.Enabled = True
      MyFrmFA001.TBarSave.Visible = True
    End If

    MyFACMNTS = New FACMNTS.MyData()
    MyFACMNTS.MyDBConn = myDBConnect
    LblTagNo.Text = WrkTagNo
    LblDesc.Text = MyFrmFA001C.TxtDesc.Text

    Call FormatText()
  End Sub
  Public Sub FormatText()
    Dim ds As DataSet
    Dim I As Integer
    Dim WrkStr As String

    ds = MyFACMNTS.Getcomments(WrkTagNo)
    WrkStr = ""
    For I = 0 To ds.Tables(0).Rows.Count - 1
      If Len(ds.Tables(0).Rows(I).Item("line")) = 109 Then
        WrkStr = WrkStr + ds.Tables(0).Rows(I).Item("line") & " "
      Else
        WrkStr = WrkStr + ds.Tables(0).Rows(I).Item("line")
      End If
    Next
    TxtComment.Text = Trim(WrkStr)
  End Sub
  Private Sub FrmComments_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmFA001.SbpScreen.Text = "FA001C"

    MyFrmFA001.TBarSave.Enabled = True
    MyFrmFA001.TBarComments.Enabled = True
    MyFrmFA001.TBarDelete.Enabled = True
    MyFrmFA001C.Show()
  End Sub
  Private Sub FrmComments_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmFA001.SbpScreen.Text = "Comments"
    Call MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub SaveData()
    Dim I As Integer
    Dim WrkLen As Integer
    Dim WrkRecs As Integer
    Dim WrkPos As Integer
    MyFACMNTS.DeleteKeyComment(WrkTagNo)
    WrkLen = Len(TxtComment.Text)
    WrkRecs = Math.Ceiling(WrkLen / 110)
    For I = 0 To WrkRecs - 1
      WrkPos = (I * 110) + 1
      With MyFACMNTS
        .GetOneRecordP(WrkTagNo, I + 1)
        ._FATAG = WrkTagNo
        ._SEQNO = I + 1
        ._LINE = Mid(TxtComment.Text, WrkPos, 110)
        .AddOneRecordP()
      End With
    Next

    MyFrmFA001.TBarComments.ImageKey = ""
    If WrkLen > 0 Then
      MyFrmFA001.TBarComments.ImageKey = "comment_24.png"
    End If
    Me.Close()
  End Sub
End Class
