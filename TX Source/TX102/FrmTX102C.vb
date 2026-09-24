Public Class FrmTX102C
  Inherits System.Windows.Forms.Form
	Dim myTXMRATE As TXMRATE.myData
  Friend WrkYear As Integer
  Friend WrkType As String
  Friend WrkDist As Integer
  Friend WithEvents TxtType As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents TxtYear As System.Windows.Forms.TextBox
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents Txtmrdesc As System.Windows.Forms.TextBox
Friend WithEvents Txtmrrate As System.Windows.Forms.TextBox
Friend WithEvents Txtmrfire As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.TxtYear = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TxtDist = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.Txtmrdesc = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
Me.Label6 = New System.Windows.Forms.Label
Me.Txtmrrate = New System.Windows.Forms.TextBox
Me.Txtmrfire = New System.Windows.Forms.TextBox
Me.TxtType = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 16)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(37, 15)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Year"
'
'TxtYear
'
Me.TxtYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtYear.Location = New System.Drawing.Point(51, 16)
Me.TxtYear.MaxLength = 4
Me.TxtYear.Name = "TxtYear"
Me.TxtYear.Size = New System.Drawing.Size(40, 20)
Me.TxtYear.TabIndex = 0
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(199, 16)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(45, 15)
Me.Label3.TabIndex = 4
Me.Label3.Text = "District"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'TxtDist
'
Me.TxtDist.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtDist.Location = New System.Drawing.Point(250, 16)
Me.TxtDist.MaxLength = 3
Me.TxtDist.Name = "TxtDist"
Me.TxtDist.Size = New System.Drawing.Size(32, 20)
Me.TxtDist.TabIndex = 2
'
'Label4
'
Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
Me.Label4.Location = New System.Drawing.Point(51, 56)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(76, 16)
Me.Label4.TabIndex = 7
Me.Label4.Text = "Description"
Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Txtmrdesc
'
Me.Txtmrdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtmrdesc.Location = New System.Drawing.Point(131, 52)
Me.Txtmrdesc.MaxLength = 25
Me.Txtmrdesc.Name = "Txtmrdesc"
Me.Txtmrdesc.Size = New System.Drawing.Size(148, 20)
Me.Txtmrdesc.TabIndex = 3
'
'Label5
'
Me.Label5.Location = New System.Drawing.Point(31, 78)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(92, 24)
Me.Label5.TabIndex = 8
Me.Label5.Text = "Mill Rate"
Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(31, 102)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(92, 24)
Me.Label6.TabIndex = 9
Me.Label6.Text = "Fire Mill Rate"
Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
'
'Txtmrrate
'
Me.Txtmrrate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtmrrate.Location = New System.Drawing.Point(131, 78)
Me.Txtmrrate.MaxLength = 8
Me.Txtmrrate.Name = "Txtmrrate"
Me.Txtmrrate.Size = New System.Drawing.Size(56, 20)
Me.Txtmrrate.TabIndex = 4
'
'Txtmrfire
'
Me.Txtmrfire.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtmrfire.Location = New System.Drawing.Point(131, 102)
Me.Txtmrfire.MaxLength = 8
Me.Txtmrfire.Name = "Txtmrfire"
Me.Txtmrfire.Size = New System.Drawing.Size(56, 20)
Me.Txtmrfire.TabIndex = 5
'
'TxtType
'
Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtType.Location = New System.Drawing.Point(153, 16)
Me.TxtType.MaxLength = 1
Me.TxtType.Name = "TxtType"
Me.TxtType.Size = New System.Drawing.Size(16, 20)
Me.TxtType.TabIndex = 1
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(112, 16)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(35, 16)
Me.Label2.TabIndex = 10
Me.Label2.Text = "Type"
'
'FrmTX102C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(302, 140)
Me.Controls.Add(Me.TxtType)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Txtmrfire)
Me.Controls.Add(Me.Txtmrrate)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.Txtmrdesc)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.TxtDist)
Me.Controls.Add(Me.TxtYear)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX102C"
Me.Text = "Maintain Billing Information"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTX102C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myTXMRATE = New TXMRATE.mydata(MyDBConnect)
  MyFrmTX102.TBarNew.Enabled = False
  MyFrmTX102.TBarSave.Enabled = True
  MyFrmTX102.TBarPrint.Enabled = False
  If Wrkyear <> 0 Then
    MyFrmTX102.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(TxtYear)
    MyUtils.SetTxtReadOnly(TxtType)
    MyUtils.SetTxtReadOnly(TxtDist)
  End If
  If Wrkyear = 0 Then
    Me.Text = "Add " & Me.Text
    MyFrmTX102.TBarDelete.Enabled = False
    Txtmrrate.Text = "0.000000"
    Txtmrfire.Text = "0.000000"
    Exit Sub
    End If
  myTXMRATE.GetOneRecordP(WrkYear, WrkType, WrkDist)
  TxtYear.Text = MyUtils.CnvSng(Wrkyear)
  txttype.text = WrkType
  TxtDist.Text = MyUtils.CnvSng(WrkDist)
  If myTXMRATE.RecordNotFound Then
    MyFrmTX102.TBarNew.Enabled = False
    MyFrmTX102.TBarSave.Enabled = False
    MyFrmTX102.TBarDelete.Enabled = False
    Me.ErrProv.SetError(TxtYear, "Record not found")
    Exit Sub
  End If

  If s_chg = False And s_full = False Then    '#sec
    MyFrmTX102.TBarSave.Visible = False
  End If
  With myTXMRATE
    'TxtYear.Text = ._YEAR
    'TxtType.Text = ._TYPE
    'TxtDist.Text = ._DIST
    Txtmrdesc.Text = Trim(._MRDESC)
    Txtmrrate.Text = ._MRRATE
    Txtmrfire.Text = ._MRFIRE
  End With
End Sub
Private Sub FrmTX102C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX102.SbpScreen.Text = "TX102C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmTX102C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTX102.TBarNew.Enabled = True
  MyFrmTX102.TBarDelete.Enabled = False
  MyFrmTX102.TBarSave.Enabled = False
  MyFrmTX102.TBarPrint.Enabled = False
  MyFrmTX102B.FormatGrid()
  MyFrmTX102B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
  myTXMRATE.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  myTXMRATE.GetOneRecordP(MyUtils.CnvSng(TxtYear.Text), TxtType.Text, MyUtils.CnvSng(TxtDist.Text))
  If Wrkyear = 0 Then
    If Not myTXMRATE.RecordNotFound Then
      Me.ErrProv.SetError(TxtYear, "Record already exists")
      Exit Sub
    End If
  End If
  If Wrkyear > 0 Then
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myTXMRATE.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  Else
    myTXMRATE._YEAR = MyUtils.CnvSng(TxtYear.Text)
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXMRATE.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
   End If
   Me.Close()
End Sub
Private Sub MovetoFile()
  With myTXMRATE
    ._YEAR = MyUtils.CnvSng(TxtYear.Text)
    ._TYPE = TxtType.Text
    ._DIST = MyUtils.CnvSng(TxtDist.Text)
    ._MRDESC = Txtmrdesc.Text
    ._MRRATE = MyUtils.CnvSng(Txtmrrate.Text)
    ._MRFIRE = MyUtils.CnvSng(Txtmrfire.Text)
  End With
End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If TxtYear.Text = String.Empty Then
      ErrorField(I) = "year"
      ErrorMsg(I) = "Year is required"
      I = I + 1
    End If

    If TxtDist.Text = String.Empty Then
      ErrorField(I) = "dist"
      ErrorMsg(I) = "Description is required"
      I = I + 1
    End If

  End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtYear, "")
  ErrProv.SetError(TxtDist, "")
  For I = 0 To ErrorField.GetUpperBound(0)
     Select Case ErrorField(I)
     Case "year"
       ErrProv.SetError(TxtYear, ErrorMsg(I))
     Case "dist"
       ErrProv.SetError(TxtDist, ErrorMsg(I))
     Case Nothing
       Exit Sub
    End Select
  Next I
End Sub

Private Sub txtyear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub txtdist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub Txtmrrate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtmrrate.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub

Private Sub Txtmrfire_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtmrfire.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
End Class





