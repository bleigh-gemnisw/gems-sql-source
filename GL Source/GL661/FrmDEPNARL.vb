Public Class FrmDEPNARL
    Inherits System.Windows.Forms.Form
    Dim myDEPNARL As DEPNARL.MyData
    Friend WrkDept As Integer
    Dim SaveDelete As Boolean
    Friend WithEvents TxtComment As System.Windows.Forms.TextBox
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents LblList As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label
    Const cFieldLen As Integer = 74

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
    Me.TxtComment = New System.Windows.Forms.TextBox()
    Me.LblName = New System.Windows.Forms.Label()
    Me.LblList = New System.Windows.Forms.Label()
    Me.label1 = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'TxtComment
    '
    Me.TxtComment.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtComment.Location = New System.Drawing.Point(11, 27)
    Me.TxtComment.Multiline = True
    Me.TxtComment.Name = "TxtComment"
    Me.TxtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.TxtComment.Size = New System.Drawing.Size(426, 340)
    Me.TxtComment.TabIndex = 211
    '
    'LblName
    '
    Me.LblName.BackColor = System.Drawing.SystemColors.Control
    Me.LblName.Location = New System.Drawing.Point(116, 9)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(272, 16)
    Me.LblName.TabIndex = 214
    Me.LblName.UseMnemonic = False
    '
    'LblList
    '
    Me.LblList.BackColor = System.Drawing.SystemColors.Control
    Me.LblList.Location = New System.Drawing.Point(68, 9)
    Me.LblList.Name = "LblList"
    Me.LblList.Size = New System.Drawing.Size(48, 16)
    Me.LblList.TabIndex = 213
    '
    'label1
    '
    Me.label1.BackColor = System.Drawing.SystemColors.Control
    Me.label1.Location = New System.Drawing.Point(12, 9)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(48, 14)
    Me.label1.TabIndex = 212
    Me.label1.Text = "Dept"
    '
    'FrmComments
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(447, 383)
    Me.Controls.Add(Me.LblName)
    Me.Controls.Add(Me.LblList)
    Me.Controls.Add(Me.label1)
    Me.Controls.Add(Me.TxtComment)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmComments"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Narratives"
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmDEPNARL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  With MyFrmGL661
    SaveDelete = .TBarDelete.Enabled
    .TBarDelete.Enabled = False
    .TBarNarr.Enabled = False
  End With

  If s_full = True Or s_add = True Or s_chg = True Then
    MyFrmGL661.TBarSave.Enabled = True
    MyFrmGL661.TBarSave.Visible = True
  End If

  myDEPNARL = New DEPNARL.MyData()
  myDEPNARL.MyDBConn = myDBConnect
  LblList.Text = WrkDept

  LblName.Text = MyFrmGL661C.TxtDesc.Text
  Call FormatText()
  End Sub
Public Sub FormatText()
  Dim ds As DataSet
  Dim I As Integer
  Dim WrkStr As String

  ds = myDEPNARL.GetViewbyDept(WrkDept, 0)
  WrkStr = ""
  For I = 0 To ds.Tables(0).Rows.Count - 1
    If Len(ds.Tables(0).Rows(I).Item("narr")) = cFieldLen - 1 Then
      WrkStr = WrkStr + ds.Tables(0).Rows(I).Item("narr") & " "
    Else
      WrkStr = WrkStr + ds.Tables(0).Rows(I).Item("narr")
    End If
  Next
  TxtComment.Text = Trim(WrkStr)
End Sub
Private Sub FrmDEPNARL_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmGL661.SbpScreen.Text = "GL661C"

  MyFrmGL661.TBarSave.Enabled = True
  If SaveDelete Then
    MyFrmGL661.TBarDelete.Enabled = True
    MyFrmGL661.TBarNarr.Enabled = True
  End If

  MyFrmGL661C.Show()

  'Memory Cleanup
  myDEPNARL = Nothing
  MyFrmDEPNARL = Nothing
  End Sub
Private Sub FrmDEPNARL_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmGL661.SbpScreen.Text = "DEPNARL"
  Call MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Public Sub SaveData()
  Dim I As Integer
  Dim WrkLen As Integer
  Dim WrkRecs As Integer
  Dim WrkPos As Integer

  myDEPNARL.DeleteDept(WrkDept)
  WrkLen = Len(TxtComment.Text)
  WrkRecs = Math.Ceiling(WrkLen / cFieldLen)
  For I = 0 To WrkRecs - 1
    WrkPos = (I * cFieldLen) + 1
    With myDEPNARL
      .GetOneRecordP(WrkDept, I)
      ._DEPT = WrkDept
      ._SEQ4 = I
      ._NARR = Mid(TxtComment.Text, WrkPos, cFieldLen)
      .AddOneRecordP()
    End With
  Next

  MyFrmGL661.TBarNarr.ImageKey = ""
  If WrkLen > 0 Then
    MyFrmGL661.TBarNarr.ImageKey = "comment_24.png"
  End If
  Me.Close()
End Sub
End Class
