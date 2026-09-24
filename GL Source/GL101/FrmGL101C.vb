Public Class FrmGL101C
  Inherits System.Windows.Forms.Form
  Dim myGLGRUP As GLGRUP.myData
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbAcct As System.Windows.Forms.RadioButton
  Friend WithEvents RbFud As System.Windows.Forms.RadioButton
  Friend WithEvents RbProp As System.Windows.Forms.RadioButton
  Friend WithEvents RbGov As System.Windows.Forms.RadioButton
  Friend WrkGROUP As Integer
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
Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
Friend WithEvents TxtGroup As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtDesc = New System.Windows.Forms.TextBox()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtGroup = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbAcct = New System.Windows.Forms.RadioButton()
    Me.RbFud = New System.Windows.Forms.RadioButton()
    Me.RbProp = New System.Windows.Forms.RadioButton()
    Me.RbGov = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(120, 15)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(60, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Description"
    '
    'TxtDesc
    '
    Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDesc.Location = New System.Drawing.Point(186, 12)
    Me.TxtDesc.MaxLength = 30
    Me.TxtDesc.Name = "TxtDesc"
    Me.TxtDesc.Size = New System.Drawing.Size(282, 20)
    Me.TxtDesc.TabIndex = 2
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtGroup
    '
    Me.TxtGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtGroup.Location = New System.Drawing.Point(76, 12)
    Me.TxtGroup.MaxLength = 2
    Me.TxtGroup.Name = "TxtGroup"
    Me.TxtGroup.Size = New System.Drawing.Size(23, 20)
    Me.TxtGroup.TabIndex = 0
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 15)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(58, 13)
    Me.Label2.TabIndex = 30
    Me.Label2.Text = "Fund Type"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbAcct)
    Me.GroupBox1.Controls.Add(Me.RbFud)
    Me.GroupBox1.Controls.Add(Me.RbProp)
    Me.GroupBox1.Controls.Add(Me.RbGov)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(12, 52)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(456, 43)
    Me.GroupBox1.TabIndex = 35
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Fund Classification"
    '
    'RbAcct
    '
    Me.RbAcct.AutoSize = True
    Me.RbAcct.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbAcct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbAcct.Location = New System.Drawing.Point(346, 19)
    Me.RbAcct.Name = "RbAcct"
    Me.RbAcct.Size = New System.Drawing.Size(97, 17)
    Me.RbAcct.TabIndex = 38
    Me.RbAcct.TabStop = True
    Me.RbAcct.Text = "Account Group"
    Me.RbAcct.UseVisualStyleBackColor = True
    '
    'RbFud
    '
    Me.RbFud.AutoSize = True
    Me.RbFud.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbFud.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFud.Location = New System.Drawing.Point(244, 19)
    Me.RbFud.Name = "RbFud"
    Me.RbFud.Size = New System.Drawing.Size(65, 17)
    Me.RbFud.TabIndex = 37
    Me.RbFud.TabStop = True
    Me.RbFud.Text = "Fudicary"
    Me.RbFud.UseVisualStyleBackColor = True
    '
    'RbProp
    '
    Me.RbProp.AutoSize = True
    Me.RbProp.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbProp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbProp.Location = New System.Drawing.Point(130, 19)
    Me.RbProp.Name = "RbProp"
    Me.RbProp.Size = New System.Drawing.Size(75, 17)
    Me.RbProp.TabIndex = 36
    Me.RbProp.TabStop = True
    Me.RbProp.Text = "Proprietary"
    Me.RbProp.UseVisualStyleBackColor = True
    '
    'RbGov
    '
    Me.RbGov.AutoSize = True
    Me.RbGov.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbGov.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbGov.Location = New System.Drawing.Point(6, 19)
    Me.RbGov.Name = "RbGov"
    Me.RbGov.Size = New System.Drawing.Size(91, 17)
    Me.RbGov.TabIndex = 35
    Me.RbGov.TabStop = True
    Me.RbGov.Text = "Governmental"
    Me.RbGov.UseVisualStyleBackColor = True
    '
    'FrmGL101C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(480, 110)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtGroup)
    Me.Controls.Add(Me.TxtDesc)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL101C"
    Me.Text = "Maintain Fund Type"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

  Private Sub FrmGL101C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myGLGRUP = New GLGRUP.myData()
  myGLGRUP.MyDBConn = myDBConnect
  MyFrmGL101.TBarNew.Enabled = False
  MyFrmGL101.TBarSave.Enabled = True
  MyFrmGL101.TBarPrint.Enabled = False
  If WrkGROUP > 0 Then
    MyFrmGL101.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(TxtGroup)
  End If
  If WrkGROUP = 0 Then
    Me.Text = "Add " & Me.Text
    MyFrmGL101.TBarDelete.Enabled = False
    Exit Sub
  End If
  myGLGRUP.GetOneRecordP(WrkGROUP)
  TxtGroup.Text = WrkGROUP

 If myGLGRUP.RecordNotFound Then
  MyFrmGL101.TBarNew.Enabled = False
  MyFrmGL101.TBarSave.Enabled = False
  MyFrmGL101.TBarDelete.Enabled = False
  Me.ErrProv.SetError(TxtDesc, "Record not found")
  Exit Sub
 End If

  If s_chg = False And s_full = False Then    '#sec
    MyFrmGL101.TBarSave.Visible = False
  End If

  With myGLGRUP
   Select Case ._FCCDE
   Case 1
     RbGov.Checked = True
   Case 2
     RbProp.Checked = True
   Case 3
     RbFud.Checked = True
   Case 4
     RbAcct.Checked = True
   End Select
   TxtDesc.Text = Trim(._GRDSC)
  End With
End Sub
Private Sub FrmGL101C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmGL101.SbpScreen.Text = "GL101C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub FrmGL101C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmGL101.TBarNew.Enabled = True
  MyFrmGL101.TBarDelete.Enabled = False
  MyFrmGL101.TBarSave.Enabled = False
  MyFrmGL101.TBarPrint.Enabled = False
  MyFrmGL101B.FormatGrid()
  MyFrmGL101B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
 myGLGRUP.DeleteOneRecordP()
  Me.Close()
End Sub

Public Sub SaveData()
 Dim ErrorField(25) As String
 Dim ErrorMsg(25) As String
 myGLGRUP.GetOneRecordP(MyUtils.CnvSng(TxtGroup.Text))
 If WrkGROUP = 0 Then
   If Not myGLGRUP.RecordNotFound Then
     Me.ErrProv.SetError(TxtDesc, "Record already exists")
     Exit Sub
   End If
 End If
 If WrkGROUP > 0 Then
   MovetoFile()
   EditChecks(ErrorField, ErrorMsg)
   If IsNothing(ErrorMsg(0)) Then
     myGLGRUP.UpdateOneRecordP()
   Else
     ShowError(ErrorField, ErrorMsg)
     Exit Sub
   End If
 Else
   myGLGRUP._GROUP = MyUtils.CnvSng(TxtGroup.Text)
   MovetoFile()
   EditChecks(ErrorField, ErrorMsg)
   If IsNothing(ErrorMsg(0)) Then
     myGLGRUP.AddOneRecordP()
   Else
     ShowError(ErrorField, ErrorMsg)
     Exit Sub
   End If
 End If
 Me.Close()
End Sub
Private Sub MovetoFile()
 With myGLGRUP
   If RbGov.Checked Then ._FCCDE = 1
   If RbProp.Checked Then ._FCCDE = 2
   If RbFud.Checked Then ._FCCDE = 3
   If RbAcct.Checked Then ._FCCDE = 4
   ._GRDSC = TxtDesc.Text
 End With
End Sub
 Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer

  For I = 0 To ErrorField.GetUpperBound(0)
   If IsNothing(ErrorField(I)) Then
    Exit For
   End If
  Next

  If TxtGroup.Text = 0 Then
   ErrorField(I) = "group"
   ErrorMsg(I) = "Group is required"
   I = I + 1
  End If

  If TxtDesc.Text = String.Empty Then
   ErrorField(I) = "desc"
   ErrorMsg(I) = "Description is required"
   I = I + 1
  End If

 End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
 Dim I As Integer
 ErrProv.SetError(TxtDesc, "")
 ErrProv.SetError(TxtGroup, "")

 For I = 0 To ErrorField.GetUpperBound(0)
  Select Case ErrorField(I)
  Case "desc"
    ErrProv.SetError(TxtDesc, ErrorMsg(I))
  Case "group"
    ErrProv.SetError(TxtGroup, ErrorMsg(I))
  Case Nothing
    Exit Sub
  End Select
 Next I
End Sub
Private Sub TxtGroup_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGroup.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class
