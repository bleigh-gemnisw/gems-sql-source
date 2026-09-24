Public Class FrmTO203C
  Inherits System.Windows.Forms.Form
  Dim myTXM35EX As TXM35EX.myData
  Dim ds As DataSet = New DataSet
  Friend WrkCat As String
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents LblCategory As System.Windows.Forms.Label
  Friend WithEvents RbEx As System.Windows.Forms.RadioButton
  Friend WithEvents RbLocal As System.Windows.Forms.RadioButton
  Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
  Friend WrkExcd As String


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
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents TxtExcd As System.Windows.Forms.TextBox
Friend WithEvents LnkExcd As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TxtExcd = New System.Windows.Forms.TextBox
Me.LnkExcd = New System.Windows.Forms.LinkLabel
Me.Label1 = New System.Windows.Forms.Label
Me.LblCategory = New System.Windows.Forms.Label
Me.RbEx = New System.Windows.Forms.RadioButton
Me.RbLocal = New System.Windows.Forms.RadioButton
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'TxtExcd
'
Me.TxtExcd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtExcd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtExcd.Location = New System.Drawing.Point(217, 16)
Me.TxtExcd.MaxLength = 3
Me.TxtExcd.Name = "TxtExcd"
Me.TxtExcd.Size = New System.Drawing.Size(32, 20)
Me.TxtExcd.TabIndex = 1
'
'LnkExcd
'
Me.LnkExcd.Location = New System.Drawing.Point(179, 15)
Me.LnkExcd.Name = "LnkExcd"
Me.LnkExcd.Size = New System.Drawing.Size(32, 23)
Me.LnkExcd.TabIndex = 14
Me.LnkExcd.TabStop = True
Me.LnkExcd.Text = "Code"
Me.LnkExcd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(12, 17)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(54, 17)
Me.Label1.TabIndex = 15
Me.Label1.Text = "Category"
Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'LblCategory
'
Me.LblCategory.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LblCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblCategory.Location = New System.Drawing.Point(72, 17)
Me.LblCategory.Name = "LblCategory"
Me.LblCategory.Size = New System.Drawing.Size(86, 18)
Me.LblCategory.TabIndex = 195
Me.LblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'RbEx
'
Me.RbEx.AutoSize = True
Me.RbEx.Checked = True
Me.RbEx.Location = New System.Drawing.Point(175, 55)
Me.RbEx.Name = "RbEx"
Me.RbEx.Size = New System.Drawing.Size(74, 17)
Me.RbEx.TabIndex = 196
Me.RbEx.TabStop = True
Me.RbEx.Text = "Exemption"
Me.RbEx.UseVisualStyleBackColor = True
'
'RbLocal
'
Me.RbLocal.AutoSize = True
Me.RbLocal.Location = New System.Drawing.Point(175, 78)
Me.RbLocal.Name = "RbLocal"
Me.RbLocal.Size = New System.Drawing.Size(51, 17)
Me.RbLocal.TabIndex = 197
Me.RbLocal.Text = "Local"
Me.RbLocal.UseVisualStyleBackColor = True
'
'FrmTO203C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(260, 107)
Me.Controls.Add(Me.RbLocal)
Me.Controls.Add(Me.RbEx)
Me.Controls.Add(Me.LblCategory)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.LnkExcd)
Me.Controls.Add(Me.TxtExcd)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTO203C"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTO203C_AS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	myTXM35EX = New TXM35EX.mydata(MyDBConnect)
  MyFrmTO203.TBarNew.Enabled = False
  MyFrmTO203.TBarSave.Enabled = True
  LblCategory.Text = GetCategory(WrkCat)

  If WrkExcd <> "" Then
    MyFrmTO203.TBarDelete.Enabled = True
    LnkExcd.Enabled = False
    RbEx.Enabled = False
    RbLocal.Enabled = False
    MyUtils.SetTxtReadOnly(TxtExcd)
  End If
  MyFrmTO203.TBarPrint.Enabled = False
  myTXM35EX.GetOneRecordP(WrkCat, WrkExcd)
  TxtExcd.Text = WrkExcd
  If myTXM35EX.RecordNotFound Then Exit Sub
    If s_chg = False And s_full = False Then    '#sec
      MyFrmTO203.TBarSave.Visible = False
    End If

  With myTXM35EX
    TxtExcd.Text = Trim(._EXCD)
    If Len(TxtExcd.Text) = 3 Then
      RbEx.Checked = True
    Else
      RbLocal.Checked = True
    End If
  End With
End Sub
Private Sub FrmTO203C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTO203.SbpScreen.Text = "TO203C"
  MyUtils.CenterForm(Me.ParentForm, Me)
  With MyFrmTO203
    .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
    .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
  End With
End Sub
Private Sub FrmTO203C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTO203.TBarNew.Enabled = True
  MyFrmTO203.TBarDelete.Enabled = False
  MyFrmTO203.TBarSave.Enabled = False
  MyFrmTO203.TBarPrint.Enabled = False
  MyFrmTO203.TBarSave.Visible = True   '#sec
  MyFrmTO203B.FormatGrid()
  MyFrmTO203B.Show()
End Sub
Public Sub DeleteData(ByRef WrkCancel As Boolean)
  Dim Answer As Integer
  WrkCancel = True
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
		Exit Sub
  End If
  WrkCancel = False
  myTXM35EX.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String

  EditChecks(ErrorField, ErrorMsg)
  If IsNothing(ErrorMsg(0)) Then
    myTXM35EX.GetOneRecordP(WrkCat, TxtExcd.Text)
    MovetoFile()
    If myTXM35EX.RecordNotFound Then
      myTXM35EX.AddOneRecordP()
    Else
      myTXM35EX.UpdateOneRecordP()
    End If
  Else
    ShowError(ErrorField, ErrorMsg)
    Exit Sub
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myTXM35EX
    ._CAT = WrkCat
    ._EXCD = TxtExcd.Text
  End With
End Sub
Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim WrkTxExem As String()
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If RbEx.Checked Then
      WrkTxExem = GetTXExem(TxtExcd.Text)
      If Mid(WrkTxExem(1), 1, 3) = "***" Then
          ErrorField(I) = "excd"
          ErrorMsg(I) = "Invalid Exemption Code"
          I = I + 1
      End If
    End If
End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtExcd, "")

  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
		Case "excd"
			ErrProv.SetError(TxtExcd, ErrorMsg(I))
		Case Nothing
			Exit Sub
		End Select
  Next I
End Sub
Private Sub LinkExcd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExcd.LinkClicked
  If RbEx.Checked Then
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = "R"
    MyFrmListExemption.WrkExcd = TxtExcd.Text
    MyFrmListExemption.Show()
  Else
    MyFrmListLocalCodes = New FrmListLocalCodes
    MyFrmListLocalCodes.MdiParent = Me.ParentForm
    MyFrmListLocalCodes.WrkCode = TxtExcd.Text
    MyFrmListLocalCodes.Show()
  End If

  Me.Hide()
End Sub
End Class







