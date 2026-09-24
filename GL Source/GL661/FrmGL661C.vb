Public Class FrmGL661C
  Inherits System.Windows.Forms.Form
	Dim myGLDEP As GLDEP.myData
  Dim myDEPNARL As DEPNARL.MyData
  Friend WrkDept As Integer
  Friend WithEvents LnkDeGrp As System.Windows.Forms.LinkLabel
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents TxtDeGrp As System.Windows.Forms.TextBox
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents TxtDept As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.TxtDept = New System.Windows.Forms.TextBox
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Label2 = New System.Windows.Forms.Label
Me.TxtDesc = New System.Windows.Forms.TextBox
Me.TxtDeGrp = New System.Windows.Forms.TextBox
Me.LnkDeGrp = New System.Windows.Forms.LinkLabel
Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 12)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(45, 16)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Dept"
'
'TxtDept
'
Me.TxtDept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtDept.Location = New System.Drawing.Point(82, 8)
Me.TxtDept.MaxLength = 4
Me.TxtDept.Name = "TxtDept"
Me.TxtDept.Size = New System.Drawing.Size(35, 20)
Me.TxtDept.TabIndex = 1
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(8, 38)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(68, 16)
Me.Label2.TabIndex = 28
Me.Label2.Text = "Description"
Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'TxtDesc
'
Me.TxtDesc.Location = New System.Drawing.Point(82, 34)
Me.TxtDesc.MaxLength = 30
Me.TxtDesc.Name = "TxtDesc"
Me.TxtDesc.Size = New System.Drawing.Size(344, 20)
Me.TxtDesc.TabIndex = 2
'
'TxtDeGrp
'
Me.TxtDeGrp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtDeGrp.Location = New System.Drawing.Point(82, 60)
Me.TxtDeGrp.MaxLength = 2
Me.TxtDeGrp.Name = "TxtDeGrp"
Me.TxtDeGrp.Size = New System.Drawing.Size(20, 20)
Me.TxtDeGrp.TabIndex = 29
'
'LnkDeGrp
'
Me.LnkDeGrp.Location = New System.Drawing.Point(8, 65)
Me.LnkDeGrp.Name = "LnkDeGrp"
Me.LnkDeGrp.Size = New System.Drawing.Size(68, 16)
Me.LnkDeGrp.TabIndex = 161
Me.LnkDeGrp.TabStop = True
Me.LnkDeGrp.Text = "Group"
'
'FrmGL661C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(438, 90)
Me.Controls.Add(Me.LnkDeGrp)
Me.Controls.Add(Me.TxtDeGrp)
Me.Controls.Add(Me.TxtDept)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.TxtDesc)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmGL661C"
Me.Text = "Maintain Department"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

  Private Sub FrmGL661C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myGLDEP = New GLDEP.MyData()
  myGLDEP.MyDBConn = myDBConnect
  myDEPNARL = New DEPNARL.MyData()
  myDEPNARL.MyDBConn = myDBConnect
  MyFrmGL661.TBarNew.Enabled = False
  MyFrmGL661.TBarSave.Enabled = True
  MyFrmGL661.TBarPrint.Enabled = False
  MyFrmGL661.TBarNarr.Enabled = True
  If WrkDept = 0 Then
    Me.Text = "Add " & Me.Text
    MyFrmGL661.TBarDelete.Enabled = False
    Exit Sub
  End If
  MyFrmGL661.TBarNarr.ImageKey = ""
  myDEPNARL.GetOneRecordP(WrkDept, 0)
  If Not myDEPNARL.RecordNotFound Then
    MyFrmGL661.TBarNarr.ImageKey = "comment_24.png"
  End If

  MyFrmGL661.TBarDelete.Enabled = True
  MyUtils.SetTxtReadOnly(TxtDept)
	myGLDEP.GetOneRecordP(WrkDept)
  TxtDept.Text = WrkDept

	If myGLDEP.RecordNotFound Then
			MyFrmGL661.TBarNew.Enabled = False
			MyFrmGL661.TBarSave.Enabled = False
			MyFrmGL661.TBarDelete.Enabled = False
			Me.ErrProv.SetError(TxtDept, "Record not found")
			Exit Sub
		End If

    If s_chg = False And s_full = False Then    '#sec
      MyFrmGL661.TBarSave.Visible = False
      End If
			With myGLDEP
				TxtDesc.Text = Trim(._DESC)
				TxtDeGrp.Text = Trim(._DEGRP)
			End With
    End Sub
Private Sub FrmGL661C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmGL661.SbpScreen.Text = "GL661C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub FrmGL661C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmGL661.TBarNew.Enabled = True
  MyFrmGL661.TBarDelete.Enabled = False
  MyFrmGL661.TBarSave.Enabled = False
  MyFrmGL661.TBarPrint.Enabled = False
  MyFrmGL661.TBarNarr.Enabled = False
  MyFrmGL661B.FormatGrid()
  MyFrmGL661B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If

	myGLDEP.DeleteOneRecordP()
  Me.Close()
End Sub

Public Sub SaveData()
	Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  myGLDEP.GetOneRecordP(MyUtils.CnvSng(TxtDept.Text))
  If WrkDept = 0 Then
    If Not myGLDEP.RecordNotFound Then
      Me.ErrProv.SetError(TxtDept, "Record already exists")
      Exit Sub
    End If
  End If
  If WrkDept <> 0 Then
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myGLDEP.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
    Else
    myGLDEP._DEPT = MyUtils.CnvSng(TxtDept.Text)
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myGLDEP.AddOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myGLDEP
    ._DESC = TxtDesc.Text
    ._DEGRP = MyUtils.CnvSng(TxtDeGrp.Text)
  End With
 End Sub
 Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If TxtDept.Text = String.Empty Then
      ErrorField(I) = "dept"
      ErrorMsg(I) = "Dept is required"
      I = I + 1
    End If

    If TxtDesc.Text = String.Empty Then
      ErrorField(I) = "desc"
      ErrorMsg(I) = "Description is required"
      I = I + 1
    End If

    If TxtDeGrp.Text = String.Empty Then
      ErrorField(I) = "degrp"
      ErrorMsg(I) = "Group is required"
      I = I + 1
    End If
End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtDept, "")
  ErrProv.SetError(TxtDesc, "")
  ErrProv.SetError(TxtDeGrp, "")

  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
    Case "dept"
      ErrProv.SetError(TxtDept, ErrorMsg(I))
    Case "desc"
      ErrProv.SetError(TxtDesc, ErrorMsg(I))
    Case "degrp"
      ErrProv.SetError(TxtDeGrp, ErrorMsg(I))
    Case Nothing
      Exit Sub
    End Select
  Next I
End Sub
Private Sub LnkDeGrp_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDeGrp.LinkClicked
    MyFrmListDegrp = New FrmListDeGrp
    MyFrmListDegrp.MdiParent = Me.ParentForm
    MyFrmListDegrp.WrkCode = MyUtils.CnvSng(TxtDeGrp.Text)
    MyFrmListDegrp.Show()
End Sub
End Class
