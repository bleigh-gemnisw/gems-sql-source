Public Class FrmGL104C
  Inherits System.Windows.Forms.Form
  Dim myGLPROG As GLPROG.myData
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents ChkAcrec As System.Windows.Forms.CheckBox
  Friend WrkFnpgm As Integer
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
Friend WithEvents TxtFunction As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtDesc = New System.Windows.Forms.TextBox()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtFunction = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ChkAcrec = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
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
    'TxtFunction
    '
    Me.TxtFunction.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFunction.Location = New System.Drawing.Point(66, 12)
    Me.TxtFunction.MaxLength = 3
    Me.TxtFunction.Name = "TxtFunction"
    Me.TxtFunction.Size = New System.Drawing.Size(32, 20)
    Me.TxtFunction.TabIndex = 0
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 15)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(48, 13)
    Me.Label2.TabIndex = 30
    Me.Label2.Text = "Function"
    '
    'ChkAcrec
    '
    Me.ChkAcrec.AutoSize = True
    Me.ChkAcrec.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkAcrec.Location = New System.Drawing.Point(15, 54)
    Me.ChkAcrec.Name = "ChkAcrec"
    Me.ChkAcrec.Size = New System.Drawing.Size(165, 17)
    Me.ChkAcrec.TabIndex = 3
    Me.ChkAcrec.Text = "Inactivate on Ledger Report?"
    Me.ChkAcrec.UseVisualStyleBackColor = True
    Me.ChkAcrec.Visible = False
    '
    'FrmGL104C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(480, 64)
    Me.Controls.Add(Me.ChkAcrec)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtFunction)
    Me.Controls.Add(Me.TxtDesc)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL104C"
    Me.Text = "Maintain Function"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

  Private Sub FrmGL104C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myGLPROG = New GLPROG.myData()
  myGLPROG.MyDBConn = myDBConnect
  MyFrmGL104.TBarNew.Enabled = False
  MyFrmGL104.TBarSave.Enabled = True
  MyFrmGL104.TBarPrint.Enabled = False
  If WrkFnpgm > 0 Then
    MyFrmGL104.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(TxtFunction)
  End If
  If WrkFnpgm = 0 Then
    Me.Text = "Add " & Me.Text
    MyFrmGL104.TBarDelete.Enabled = False
    Exit Sub
  End If
  myGLPROG.GetOneRecordP(WrkFnpgm)
  TxtFunction.Text = WrkFnpgm

 If myGLPROG.RecordNotFound Then
  MyFrmGL104.TBarNew.Enabled = False
  MyFrmGL104.TBarSave.Enabled = False
  MyFrmGL104.TBarDelete.Enabled = False
  Me.ErrProv.SetError(TxtDesc, "Record not found")
  Exit Sub
 End If

  If s_chg = False And s_full = False Then    '#sec
    MyFrmGL104.TBarSave.Visible = False
  End If

  With myGLPROG
   If Trim(._ACREC) = "Y" Then
     ChkAcrec.Checked = True
   Else
     ChkAcrec.Checked = False
   End If
   TxtDesc.Text = Trim(._PGDSC)
  End With
End Sub
Private Sub FrmGL104C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmGL104.SbpScreen.Text = "GL104C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub FrmGL104C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmGL104.TBarNew.Enabled = True
  MyFrmGL104.TBarDelete.Enabled = False
  MyFrmGL104.TBarSave.Enabled = False
  MyFrmGL104.TBarPrint.Enabled = False
  MyFrmGL104B.FormatGrid()
  MyFrmGL104B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
 myGLPROG.DeleteOneRecordP()
  Me.Close()
End Sub

Public Sub SaveData()
 Dim ErrorField(25) As String
 Dim ErrorMsg(25) As String
 myGLPROG.GetOneRecordP(MyUtils.CnvSng(TxtFunction.Text))
 If WrkFnpgm = 0 Then
   If Not myGLPROG.RecordNotFound Then
     Me.ErrProv.SetError(TxtDesc, "Record already exists")
     Exit Sub
   End If
 End If
 If WrkFnpgm > 0 Then
   MovetoFile()
   EditChecks(ErrorField, ErrorMsg)
   If IsNothing(ErrorMsg(0)) Then
     myGLPROG.UpdateOneRecordP()
   Else
     ShowError(ErrorField, ErrorMsg)
     Exit Sub
   End If
 Else
   myGLPROG._FNPGM = MyUtils.CnvSng(TxtFunction.Text)
   MovetoFile()
   EditChecks(ErrorField, ErrorMsg)
   If IsNothing(ErrorMsg(0)) Then
     myGLPROG.AddOneRecordP()
   Else
     ShowError(ErrorField, ErrorMsg)
     Exit Sub
   End If
 End If
 Me.Close()
End Sub
Private Sub MovetoFile()
 With myGLPROG
   If ChkAcrec.Checked Then
     ._ACREC = "Y"
   Else
     ._ACREC = ""
   End If
   ._PGDSC = TxtDesc.Text
   ._FIL01 = ""
 End With
End Sub
 Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer

  For I = 0 To ErrorField.GetUpperBound(0)
   If IsNothing(ErrorField(I)) Then
    Exit For
   End If
  Next

  If TxtFunction.Text = 0 Then
   ErrorField(I) = "function"
   ErrorMsg(I) = "Function is required"
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
 ErrProv.SetError(TxtFunction, "")

 For I = 0 To ErrorField.GetUpperBound(0)
  Select Case ErrorField(I)
  Case "desc"
    ErrProv.SetError(TxtDesc, ErrorMsg(I))
  Case "function"
    ErrProv.SetError(TxtFunction, ErrorMsg(I))
  Case Nothing
    Exit Sub
  End Select
 Next I
End Sub
Private Sub TxtFunction_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFunction.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class
