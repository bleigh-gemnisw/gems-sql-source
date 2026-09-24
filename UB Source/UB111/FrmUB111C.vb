Public Class FrmUB111C
  Inherits System.Windows.Forms.Form
  Dim myUTBREAK As UTBREAK.myData
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtDesc1 As System.Windows.Forms.TextBox
  Friend Wrktype As String
  Friend WithEvents TxtPct1 As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtPct3 As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtDesc3 As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents TxtPct2 As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtDesc2 As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Txttype = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
Me.TxtDesc1 = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.TxtPct1 = New System.Windows.Forms.TextBox
Me.TxtPct2 = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.TxtDesc2 = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
Me.TxtPct3 = New System.Windows.Forms.TextBox
Me.Label6 = New System.Windows.Forms.Label
Me.TxtDesc3 = New System.Windows.Forms.TextBox
Me.Label7 = New System.Windows.Forms.Label
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
Me.Txttype.MaxLength = 1
Me.Txttype.Name = "Txttype"
Me.Txttype.Size = New System.Drawing.Size(20, 20)
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
'Label3
'
Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label3.Location = New System.Drawing.Point(36, 56)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(120, 20)
Me.Label3.TabIndex = 19
Me.Label3.Text = "Description 1"
Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'TxtDesc1
'
Me.TxtDesc1.Location = New System.Drawing.Point(160, 56)
Me.TxtDesc1.MaxLength = 25
Me.TxtDesc1.Name = "TxtDesc1"
Me.TxtDesc1.Size = New System.Drawing.Size(249, 20)
Me.TxtDesc1.TabIndex = 1
'
'Label2
'
Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label2.Location = New System.Drawing.Point(36, 82)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(120, 20)
Me.Label2.TabIndex = 3
Me.Label2.Text = "Percentage 1"
Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'TxtPct1
'
Me.TxtPct1.Location = New System.Drawing.Point(160, 83)
Me.TxtPct1.MaxLength = 10
Me.TxtPct1.Name = "TxtPct1"
Me.TxtPct1.Size = New System.Drawing.Size(100, 20)
Me.TxtPct1.TabIndex = 30
Me.TxtPct1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'TxtPct2
'
Me.TxtPct2.Location = New System.Drawing.Point(160, 153)
Me.TxtPct2.MaxLength = 10
Me.TxtPct2.Name = "TxtPct2"
Me.TxtPct2.Size = New System.Drawing.Size(100, 20)
Me.TxtPct2.TabIndex = 34
Me.TxtPct2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label4
'
Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label4.Location = New System.Drawing.Point(36, 126)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(120, 20)
Me.Label4.TabIndex = 33
Me.Label4.Text = "Description 2"
Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'TxtDesc2
'
Me.TxtDesc2.Location = New System.Drawing.Point(160, 126)
Me.TxtDesc2.MaxLength = 25
Me.TxtDesc2.Name = "TxtDesc2"
Me.TxtDesc2.Size = New System.Drawing.Size(249, 20)
Me.TxtDesc2.TabIndex = 31
'
'Label5
'
Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label5.Location = New System.Drawing.Point(36, 152)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(120, 20)
Me.Label5.TabIndex = 32
Me.Label5.Text = "Percentage 2"
Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'TxtPct3
'
Me.TxtPct3.Location = New System.Drawing.Point(160, 223)
Me.TxtPct3.MaxLength = 10
Me.TxtPct3.Name = "TxtPct3"
Me.TxtPct3.Size = New System.Drawing.Size(100, 20)
Me.TxtPct3.TabIndex = 38
Me.TxtPct3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label6
'
Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label6.Location = New System.Drawing.Point(36, 196)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(120, 20)
Me.Label6.TabIndex = 37
Me.Label6.Text = "Description 3"
Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'TxtDesc3
'
Me.TxtDesc3.Location = New System.Drawing.Point(160, 196)
Me.TxtDesc3.MaxLength = 25
Me.TxtDesc3.Name = "TxtDesc3"
Me.TxtDesc3.Size = New System.Drawing.Size(249, 20)
Me.TxtDesc3.TabIndex = 35
'
'Label7
'
Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label7.Location = New System.Drawing.Point(36, 222)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(120, 20)
Me.Label7.TabIndex = 36
Me.Label7.Text = "Percentage 3"
Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'FrmUB111C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(666, 256)
Me.Controls.Add(Me.TxtPct3)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.TxtDesc3)
Me.Controls.Add(Me.Label7)
Me.Controls.Add(Me.TxtPct2)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.TxtDesc2)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.TxtPct1)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.TxtDesc1)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.Txttype)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmUB111C"
Me.Text = "Maintain Rate Breakout"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

  Private Sub FrmUB111C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myUTBREAK = New UTBREAK.mydata(MyDBConnect)
  MyFrmUB111.TBarNew.Enabled = False
  MyFrmUB111.TBarSave.Enabled = True
  If Not WrkAddMode Then
    MyFrmUB111.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(Txttype)
  Else
    Exit Sub
  End If
  MyFrmUB111.TBarPrint.Enabled = False

  myUTBREAK.GetOneRecordP(Wrktype)
  Txttype.Text = Wrktype
  If myUTBREAK.RecordNotFound Then Exit Sub

  With myUTBREAK
    TxtDesc1.Text = Trim(._BDESC1)
    TxtPct1.Text = ._BPCT1
    TxtDesc2.Text = Trim(._BDESC2)
    TxtPct2.Text = ._BPCT2
    TxtDesc3.Text = Trim(._BDESC3)
    TxtPct3.Text = ._BPCT3
  End With
 End Sub

Private Sub FrmUB111C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB111.SbpScreen.Text = "UB111C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub FrmUB111C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmUB111.TBarNew.Enabled = True
  MyFrmUB111.TBarDelete.Enabled = False
  MyFrmUB111.TBarSave.Enabled = False
  MyFrmUB111.TBarPrint.Enabled = False
  MyFrmUB111B.FormatGrid()
  MyFrmUB111B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
  myUTBREAK.DeleteOneRecordP()
  Me.Close()
End Sub

Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  myUTBREAK.GetOneRecordP(Txttype.Text)
  If WrkAddMode Then
    If Not myUTBREAK.RecordNotFound Then
      Me.ErrProv.SetError(Txttype, "Record already exists")
      Exit Sub
    End If
  End If

  If Not WrkAddMode Then
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myUTBREAK.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  Else
    myUTBREAK._BTYPE = Txttype.Text
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myUTBREAK.AddOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myUTBREAK
    ._BDESC1 = TxtDesc1.Text
    ._BPCT1 = MyUtils.CnvSng(TxtPct1.Text)
    ._BDESC2 = TxtDesc2.Text
    ._BPCT2 = MyUtils.CnvSng(TxtPct2.Text)
    ._BDESC3 = TxtDesc3.Text
    ._BPCT3 = MyUtils.CnvSng(TxtPct3.Text)
 End With
 End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtPct1.Text) + MyUtils.CnvSng(TxtPct2.Text) + MyUtils.CnvSng(TxtPct3.Text) <> 100 Then
      ErrorField(I) = "pct"
      ErrorMsg(I) = "Total Percentage must be 100"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtPct1.Text) >= 100 Or MyUtils.CnvSng(TxtPct2.Text) >= 100 Or MyUtils.CnvSng(TxtPct3.Text) >= 100 Then
      ErrorField(I) = "pct"
      ErrorMsg(I) = "Percentage cannot be 100 or higher"
      I = I + 1
    End If
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(Txttype, "")
  ErrProv.SetError(TxtPct1, "")
  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
    Case "type"
      ErrProv.SetError(Txttype, ErrorMsg(I))
    Case "pct"
      ErrProv.SetError(TxtPct1, ErrorMsg(I))
    Case Nothing
      Exit Sub
    End Select
  Next I
End Sub
End Class






