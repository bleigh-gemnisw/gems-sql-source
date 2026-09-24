Public Class FrmTA136C
  Inherits System.Windows.Forms.Form
	Dim myTXVCLS As TXVCLS.myData
  Friend WrkDesc As String
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
Friend WithEvents TxtClass As System.Windows.Forms.TextBox
Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtClass = New System.Windows.Forms.TextBox()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtDesc = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(6, 37)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(61, 17)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Class"
    '
    'TxtClass
    '
    Me.TxtClass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtClass.Location = New System.Drawing.Point(73, 34)
    Me.TxtClass.MaxLength = 2
    Me.TxtClass.Name = "TxtClass"
    Me.TxtClass.Size = New System.Drawing.Size(28, 20)
    Me.TxtClass.TabIndex = 1
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(3, 8)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(64, 16)
    Me.Label2.TabIndex = 28
    Me.Label2.Text = "Description"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtDesc
    '
    Me.TxtDesc.Location = New System.Drawing.Point(73, 8)
    Me.TxtDesc.MaxLength = 30
    Me.TxtDesc.Name = "TxtDesc"
    Me.TxtDesc.Size = New System.Drawing.Size(344, 20)
    Me.TxtDesc.TabIndex = 0
    '
    'FrmTA136C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(425, 66)
    Me.Controls.Add(Me.TxtDesc)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtClass)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA136C"
    Me.Text = "Maintain CIVILS Class Lookup"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region
Private Sub FrmTA136C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myTXVCLS = New TXVCLS.mydata(MyDBConnect)
  MyFrmTA136.TBarNew.Enabled = False
  MyFrmTA136.TBarSave.Enabled = True
  MyFrmTA136.TBarPrint.Enabled = False
  If WrkDesc <> "" Then
    MyFrmTA136.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(TxtDesc)
  End If
  If WrkDesc = "" Then
    Me.Text = "Add " & Me.Text
    MyFrmTA136.TBarDelete.Enabled = False
    Exit Sub
    End If
  myTXVCLS.GetOneRecordP(WrkDesc)

  If myTXVCLS.RecordNotFound Then
    MyFrmTA136.TBarNew.Enabled = False
    MyFrmTA136.TBarSave.Enabled = False
    MyFrmTA136.TBarDelete.Enabled = False
    Me.ErrProv.SetError(TxtDesc, "Record not found")
    Exit Sub
  End If

  If s_chg = False And s_full = False Then    '#sec
    MyFrmTA136.TBarSave.Visible = False
  End If

  With myTXVCLS
    TxtDesc.Text = Trim(._DESC)
    TxtClass.Text = ._CLASS
  End With
End Sub
Private Sub FrmTA136C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA136.SbpScreen.Text = "TA136C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmTA136C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTA136.TBarNew.Enabled = True
  MyFrmTA136.TBarDelete.Enabled = False
  MyFrmTA136.TBarSave.Enabled = False
  MyFrmTA136.TBarPrint.Enabled = False
  MyFrmTA136B.FormatGrid()
  MyFrmTA136B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
  myTXVCLS.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  myTXVCLS.GetOneRecordP(TxtDesc.Text)
  If WrkDesc = "" Then
    If Not myTXVCLS.RecordNotFound Then
      Me.ErrProv.SetError(TxtDesc, "Record already exists")
      Exit Sub
    End If
  End If
  If WrkDesc <> "" Then
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myTXVCLS.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  Else
    myTXVCLS._DESC = TxtDesc.Text
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myTXVCLS.AddOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myTXVCLS
    ._CLASS = MyUtils.CnvSng(TxtClass.Text)
  End With
End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If TxtDesc.Text = String.Empty Then
      ErrorField(I) = "desc"
      ErrorMsg(I) = "Description is required"
      I = I + 1
    End If

  End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtClass, "")
  ErrProv.SetError(TxtDesc, "")
  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
    Case "desc"
      ErrProv.SetError(TxtDesc, ErrorMsg(I))
    Case Nothing
      Exit Sub
    End Select
  Next I
End Sub
Private Sub TxtClass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtClass.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






