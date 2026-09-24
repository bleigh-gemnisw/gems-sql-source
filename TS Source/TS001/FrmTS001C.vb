Public Class FrmTS001C
  Inherits System.Windows.Forms.Form
  Dim myMFTCLS As MFTCLS.myData
  Dim ds As DataSet = New DataSet
  Friend wrkmftcod As String
  Friend WithEvents lblfee As System.Windows.Forms.Label
  Friend WithEvents txtmftfee As System.Windows.Forms.TextBox
  Friend wrkmftdes As String
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
Friend WithEvents Txtmftcod As System.Windows.Forms.TextBox
Friend WithEvents Txtmftdes As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.Txtmftcod = New System.Windows.Forms.TextBox
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Label2 = New System.Windows.Forms.Label
Me.Txtmftdes = New System.Windows.Forms.TextBox
Me.lblfee = New System.Windows.Forms.Label
Me.txtmftfee = New System.Windows.Forms.TextBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
Me.Label1.Location = New System.Drawing.Point(16, 25)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(76, 16)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Class Code"
Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
'
'Txtmftcod
'
Me.Txtmftcod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtmftcod.Location = New System.Drawing.Point(98, 21)
Me.Txtmftcod.MaxLength = 2
Me.Txtmftcod.Name = "Txtmftcod"
Me.Txtmftcod.Size = New System.Drawing.Size(28, 20)
Me.Txtmftcod.TabIndex = 0
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(23, 53)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(69, 16)
Me.Label2.TabIndex = 28
Me.Label2.Text = "Description"
Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Txtmftdes
'
Me.Txtmftdes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtmftdes.Location = New System.Drawing.Point(98, 51)
Me.Txtmftdes.MaxLength = 50
Me.Txtmftdes.Name = "Txtmftdes"
Me.Txtmftdes.Size = New System.Drawing.Size(373, 20)
Me.Txtmftdes.TabIndex = 2
'
'lblfee
'
Me.lblfee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lblfee.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
Me.lblfee.Location = New System.Drawing.Point(23, 83)
Me.lblfee.Name = "lblfee"
Me.lblfee.Size = New System.Drawing.Size(69, 16)
Me.lblfee.TabIndex = 58
Me.lblfee.Text = "Fee"
Me.lblfee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'txtmftfee
'
Me.txtmftfee.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.txtmftfee.Location = New System.Drawing.Point(98, 77)
Me.txtmftfee.MaxLength = 5
Me.txtmftfee.Name = "txtmftfee"
Me.txtmftfee.Size = New System.Drawing.Size(101, 22)
Me.txtmftfee.TabIndex = 57
'
'FrmTS001C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(484, 169)
Me.Controls.Add(Me.lblfee)
Me.Controls.Add(Me.txtmftfee)
Me.Controls.Add(Me.Txtmftdes)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Txtmftcod)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTS001C"
Me.Text = "MaintainTransfer Station Classification"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region
Private Sub FrmTS001C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  myMFTCLS = New MFTCLS.mydata(MyDBConnect)
  MyFrmTS001.TBarNew.Enabled = False
  MyFrmTS001.TBarSave.Enabled = True
  MyFrmTS001.TBarPrint.Enabled = False
  If wrkmftcod <> "" Then
    MyFrmTS001.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(Txtmftcod)
  End If
  If wrkmftcod = "" Then
    Me.Text = "Add " & Me.Text
    MyFrmTS001.TBarDelete.Enabled = False
    Exit Sub
    End If
  myMFTCLS.GetOneRecordP(wrkmftcod)
  If myMFTCLS.RecordNotFound Then Exit Sub
  Txtmftcod.Text = wrkmftcod

  If s_chg = False And s_full = False Then    '#sec
    MyFrmTS001.TBarSave.Visible = False
  End If

  With myMFTCLS
    Txtmftdes.Text = Trim(._MFTDES)
    txtmftfee.Text = ._MFTFEE
  End With
End Sub
Private Sub FrmTS001C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTS001.SbpScreen.Text = "TS001C"
  MyUtils.CenterForm(Me.ParentForm, Me)

End Sub
Private Sub FrmTS001C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTS001.TBarNew.Enabled = True
  MyFrmTS001.TBarDelete.Enabled = False
  MyFrmTS001.TBarSave.Enabled = False
  MyFrmTS001.TBarPrint.Enabled = False
  MyFrmTS001B.FormatGrid()
  MyFrmTS001B.Show()
End Sub
Public Sub DeleteData(ByRef Cancel As Boolean)
  Dim Answer As Integer
  Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
  myMFTCLS.DeleteOneRecordP()
End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
 myMFTCLS.GetOneRecordP(Txtmftcod.Text)
  If wrkmftcod = "" Then
    If myMFTCLS.RecordNotFound = False Then
      Me.ErrProv.SetError(Txtmftcod, "Record already exists")
      Exit Sub
    End If
  End If
  If Not myMFTCLS.RecordNotFound Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MovetoFile()
        myMFTCLS.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MovetoFile()
        myMFTCLS.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myMFTCLS
    ._MFTCOD = Trim(Txtmftcod.Text)
    ._MFTDES = Trim(Txtmftdes.Text)
    ._MFTFEE = MyUtils.CnvSng(txtmftfee.Text)
  End With
End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(Txtmftcod, "")
  ErrProv.SetError(Txtmftdes, "")
  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
    Case "mftcod"
      ErrProv.SetError(Txtmftcod, ErrorMsg(I))
    Case "mftdes"
      ErrProv.SetError(Txtmftdes, ErrorMsg(I))
    Case Nothing
      Exit Sub
    End Select
  Next I
End Sub
Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

  If Txtmftcod.Text = Trim("") Then
      ErrorField(I) = "mytcod"
      ErrorMsg(I) = "Catagory Required"
      I = I + 1
  End If

  If Txtmftdes.Text = Trim("") Then
      ErrorField(I) = "mytdes"
      ErrorMsg(I) = "Description required"
      I = I + 1
  End If

End Sub

Private Sub txtmflfee_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmftfee.KeyPress
e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub


End Class






