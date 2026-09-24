Public Class FrmTX109C
  Inherits System.Windows.Forms.Form
  Dim myTXDIST As TXDIST.MyData
  Dim ds As DataSet = New DataSet
  Friend wrkddist As Integer
  Friend wrkddesc1 As String
  Friend wrkdaddr1 As String
  Friend wrkdaddr2 As String

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
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Txtddist As System.Windows.Forms.TextBox
Friend WithEvents Txtddesc1 As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents Txtdaddr1 As System.Windows.Forms.TextBox
Friend WithEvents Txtdaddr2 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.Label1 = New System.Windows.Forms.Label
Me.Txtddist = New System.Windows.Forms.TextBox
Me.ErrProv = New System.Windows.Forms.ErrorProvider
Me.Label2 = New System.Windows.Forms.Label
Me.Txtddesc1 = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
Me.Txtdaddr1 = New System.Windows.Forms.TextBox
Me.Txtdaddr2 = New System.Windows.Forms.TextBox
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 12)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(72, 16)
Me.Label1.TabIndex = 0
Me.Label1.Text = "District Code"
Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Txtddist
'
Me.Txtddist.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtddist.Location = New System.Drawing.Point(84, 8)
Me.Txtddist.MaxLength = 3
Me.Txtddist.Name = "Txtddist"
Me.Txtddist.Size = New System.Drawing.Size(36, 20)
Me.Txtddist.TabIndex = 0
Me.Txtddist.Text = ""
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(8, 36)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(68, 16)
Me.Label2.TabIndex = 28
Me.Label2.Text = "Description"
Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Txtddesc1
'
Me.Txtddesc1.AutoSize = False
Me.Txtddesc1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtddesc1.Location = New System.Drawing.Point(84, 32)
Me.Txtddesc1.MaxLength = 30
Me.Txtddesc1.Name = "Txtddesc1"
Me.Txtddesc1.Size = New System.Drawing.Size(256, 20)
Me.Txtddesc1.TabIndex = 1
Me.Txtddesc1.Text = ""
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(12, 60)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(68, 16)
Me.Label4.TabIndex = 30
Me.Label4.Text = "Address 1"
Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(12, 80)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(68, 16)
Me.Label3.TabIndex = 31
Me.Label3.Text = "Address 2"
Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Txtdaddr1
'
Me.Txtdaddr1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtdaddr1.Location = New System.Drawing.Point(84, 56)
Me.Txtdaddr1.MaxLength = 30
Me.Txtdaddr1.Name = "Txtdaddr1"
Me.Txtdaddr1.Size = New System.Drawing.Size(256, 20)
Me.Txtdaddr1.TabIndex = 3
Me.Txtdaddr1.Text = ""
'
'Txtdaddr2
'
Me.Txtdaddr2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtdaddr2.Location = New System.Drawing.Point(84, 80)
Me.Txtdaddr2.MaxLength = 30
Me.Txtdaddr2.Name = "Txtdaddr2"
Me.Txtdaddr2.Size = New System.Drawing.Size(256, 20)
Me.Txtdaddr2.TabIndex = 33
Me.Txtdaddr2.Text = ""
'
'FrmTX109C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(354, 104)
Me.Controls.Add(Me.Txtdaddr2)
Me.Controls.Add(Me.Txtdaddr1)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.Txtddesc1)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Txtddist)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX109C"
Me.Text = "Maintain District Codes"
Me.ResumeLayout(False)

    End Sub

#End Region

  Private Sub FrmTX109C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myTXDIST = New TXDIST.mydata(MyDBConnect)
  MyFrmTX109.TBarNew.Enabled = False
  MyFrmTX109.TBarSave.Enabled = True
  MyFrmTX109.TBarPrint.Enabled = False
  If wrkddist <> 0 Then
    MyFrmTX109.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(Txtddist)
  End If
  If wrkddist = 0 Then
    Me.Text = "Add " & Me.Text
    MyFrmTX109.TBarDelete.Enabled = False
    Exit Sub
    End If
  myTXDIST.GetOneRecordP(wrkddist)
  Txtddist.Text = Format(wrkddist, "000")

  If myTXDIST.RecordNotFound Then
      MyFrmTX109.TBarNew.Enabled = False
      MyFrmTX109.TBarSave.Enabled = False
      MyFrmTX109.TBarDelete.Enabled = False
      Me.ErrProv.SetError(Txtddist, "Record not found")
      Exit Sub
    End If

  If s_chg = False And s_full = False Then    '#sec
          MyFrmTX109.TBarSave.Visible = False
        End If
    With myTXDIST
      Txtddist.Text = ._DDIST
      Txtddesc1.Text = Trim(._DDESC1)
      Txtdaddr1.Text = Trim(._DADDR1)
      Txtdaddr2.Text = Trim(._DADDR2)
    End With
    End Sub

Private Sub FrmTX109C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX109.SbpScreen.Text = "TX109C"
  MyUtils.CenterForm(Me.ParentForm, Me)

End Sub
Private Sub FrmTX109C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTX109.TBarNew.Enabled = True
  MyFrmTX109.TBarDelete.Enabled = False
  MyFrmTX109.TBarSave.Enabled = False
  MyFrmTX109.TBarPrint.Enabled = False
  MyFrmTX109B.FormatGrid()
  MyFrmTX109B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
  myTXDIST.DeleteOneRecordP()
  Me.Close()
End Sub

Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  myTXDIST.GetOneRecordP(MyUtils.CnvSng(Txtddist.Text))
  If wrkddist = 0 Then
    If Not myTXDIST.RecordNotFound Then
      Me.ErrProv.SetError(Txtddist, "Record already exists")
      Exit Sub
    End If
  End If
  If wrkddist > 0 Then
    MovetoFile()
    If IsNothing(ErrorMsg(0)) Then
      myTXDIST.UpdateOneRecordP()
      Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
    Else
    myTXDIST._DDIST = MyUtils.CnvSng(Txtddist.Text)
    MovetoFile()
    If IsNothing(ErrorMsg(0)) Then
      myTXDIST.AddOneRecordP()
      Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myTXDIST
    ._DDESC1 = Txtddesc1.Text
    ._DADDR1 = Txtdaddr1.Text
    ._DADDR2 = Txtdaddr2.Text
  End With
 End Sub

 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(Txtddist, "")

  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
    Case "ddist"
      ErrProv.SetError(Txtddist, ErrorMsg(I))
    Case Nothing
      Exit Sub
    End Select
  Next I
End Sub

End Class






