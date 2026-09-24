Public Class FrmBD101C
  Inherits System.Windows.Forms.Form
  Dim myBDENDRS As BDENDRS.MyData
  Friend Wrktype As String
  Friend WrkAddMode As Boolean

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
Friend WithEvents Txttype As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents Txtel1 As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents Txtel2 As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents Txtel3 As System.Windows.Forms.TextBox
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents Txtel4 As System.Windows.Forms.TextBox
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents Txtel5 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Txttype = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.Txtel1 = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
Me.Txtel2 = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.Txtel3 = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
Me.Txtel4 = New System.Windows.Forms.TextBox
Me.Label6 = New System.Windows.Forms.Label
Me.Txtel5 = New System.Windows.Forms.TextBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Txttype
'
Me.Txttype.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txttype.Location = New System.Drawing.Point(48, 16)
Me.Txttype.MaxLength = 5
Me.Txttype.Name = "Txttype"
Me.Txttype.Size = New System.Drawing.Size(49, 20)
Me.Txttype.TabIndex = 0
'
'Label1
'
Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label1.Location = New System.Drawing.Point(8, 20)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(36, 16)
Me.Label1.TabIndex = 1
Me.Label1.Text = "Type:"
Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Txtel1
'
Me.Txtel1.Location = New System.Drawing.Point(160, 52)
Me.Txtel1.MaxLength = 30
Me.Txtel1.Name = "Txtel1"
Me.Txtel1.Size = New System.Drawing.Size(336, 20)
Me.Txtel1.TabIndex = 2
'
'Label2
'
Me.Label2.AutoSize = True
Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label2.Location = New System.Drawing.Point(31, 55)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(123, 13)
Me.Label2.TabIndex = 3
Me.Label2.Text = "Endorsement Line 1:"
Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label3
'
Me.Label3.AutoSize = True
Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label3.Location = New System.Drawing.Point(31, 83)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(123, 13)
Me.Label3.TabIndex = 5
Me.Label3.Text = "Endorsement Line 2:"
Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Txtel2
'
Me.Txtel2.Location = New System.Drawing.Point(160, 80)
Me.Txtel2.MaxLength = 30
Me.Txtel2.Name = "Txtel2"
Me.Txtel2.Size = New System.Drawing.Size(336, 20)
Me.Txtel2.TabIndex = 4
'
'Label4
'
Me.Label4.AutoSize = True
Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label4.Location = New System.Drawing.Point(31, 111)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(123, 13)
Me.Label4.TabIndex = 7
Me.Label4.Text = "Endorsement Line 3:"
Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Txtel3
'
Me.Txtel3.Location = New System.Drawing.Point(160, 108)
Me.Txtel3.MaxLength = 30
Me.Txtel3.Name = "Txtel3"
Me.Txtel3.Size = New System.Drawing.Size(336, 20)
Me.Txtel3.TabIndex = 6
'
'Label5
'
Me.Label5.AutoSize = True
Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label5.Location = New System.Drawing.Point(31, 139)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(123, 13)
Me.Label5.TabIndex = 9
Me.Label5.Text = "Endorsement Line 4:"
Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Txtel4
'
Me.Txtel4.Location = New System.Drawing.Point(160, 136)
Me.Txtel4.MaxLength = 30
Me.Txtel4.Name = "Txtel4"
Me.Txtel4.Size = New System.Drawing.Size(336, 20)
Me.Txtel4.TabIndex = 8
'
'Label6
'
Me.Label6.AutoSize = True
Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label6.Location = New System.Drawing.Point(31, 167)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(123, 13)
Me.Label6.TabIndex = 11
Me.Label6.Text = "Endorsement Line 5:"
Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Txtel5
'
Me.Txtel5.Location = New System.Drawing.Point(160, 164)
Me.Txtel5.MaxLength = 30
Me.Txtel5.Name = "Txtel5"
Me.Txtel5.Size = New System.Drawing.Size(336, 20)
Me.Txtel5.TabIndex = 10
'
'FrmBD101C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(506, 197)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.Txtel5)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.Txtel4)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.Txtel3)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Txtel2)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Txtel1)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.Txttype)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmBD101C"
Me.Text = "Maintain Check Endorsement Information"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

  Private Sub FrmBD101C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myBDENDRS = New BDENDRS.mydata(MyDBConnect)
  MyFrmBD101.TBarNew.Enabled = False
  MyFrmBD101.TBarSave.Enabled = True
  If Not WrkAddMode Then
    MyFrmBD101.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(Txttype)
  Else
    Exit Sub
  End If

  MyFrmBD101.TBarPrint.Enabled = False
  myBDENDRS.GetOneRecordP(Wrktype)
  Txttype.Text = Wrktype
  If myBDENDRS.RecordNotFound Then Exit Sub
    With myBDENDRS
      Txtel1.Text = Trim(._EL1)
      Txtel2.Text = Trim(._EL2)
      Txtel3.Text = Trim(._EL3)
      Txtel4.Text = Trim(._EL4)
      Txtel5.Text = Trim(._EL5)
    End With
  End Sub

Private Sub FrmBD101C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmBD101.SbpScreen.Text = "BD101C"
  MyUtils.CenterForm(Me.ParentForm, Me)
    If Wrktype <> "" Then
    End If
End Sub

Private Sub FrmBD101C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmBD101.TBarNew.Enabled = True
  MyFrmBD101.TBarDelete.Enabled = False
  MyFrmBD101.TBarSave.Enabled = False
  MyFrmBD101.TBarPrint.Enabled = False
  MyFrmBD101B.FormatGrid()
  MyFrmBD101B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
  myBDENDRS.DeleteOneRecordP()
  Me.Close()
End Sub

Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  myBDENDRS.GetOneRecordP(Txttype.Text)
  If WrkAddMode Then
    If Not myBDENDRS.RecordNotFound Then
      Me.ErrProv.SetError(Txttype, "Record already exists")
      Exit Sub
    End If
  End If
  If Not WrkAddMode Then
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myBDENDRS.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
    Else
    myBDENDRS._TYPE = Txttype.Text
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myBDENDRS.AddOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myBDENDRS
  ._EL1 = Txtel1.Text
  ._EL2 = Txtel2.Text
  ._EL3 = Txtel3.Text
  ._EL4 = Txtel4.Text
  ._EL5 = Txtel5.Text
 End With
 End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    'If Txttype.Text = String.Empty Then
    '	ErrorField(I) = "type"
    '	ErrorMsg(I) = "Type is required"
    '	I = I + 1
    'End If

End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
'	ErrProv.SetError(Txttype, "")
  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
'		Case "type"
'			ErrProv.SetError(Txttype, ErrorMsg(I))
    Case Nothing
      Exit Sub
    End Select
  Next I
End Sub
End Class






