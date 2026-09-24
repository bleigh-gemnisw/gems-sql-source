Public Class FrmTAP16C
  Inherits System.Windows.Forms.Form
  Dim myTXDMDEP As TXDMDEP.myData
  Dim ds As DataSet = New DataSet
	Friend WrkYear As Integer
	Friend WrkYearNo As Integer
  Friend WithEvents Txtpct As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label

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
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Txtyearno As System.Windows.Forms.TextBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label2 = New System.Windows.Forms.Label
Me.Txtyearno = New System.Windows.Forms.TextBox
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Txtpct = New System.Windows.Forms.TextBox
Me.Label6 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(3, 9)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(74, 24)
Me.Label2.TabIndex = 2
Me.Label2.Text = "Year No"
'
'Txtyearno
'
Me.Txtyearno.Location = New System.Drawing.Point(83, 9)
Me.Txtyearno.MaxLength = 2
Me.Txtyearno.Name = "Txtyearno"
Me.Txtyearno.Size = New System.Drawing.Size(31, 20)
Me.Txtyearno.TabIndex = 1
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Txtpct
'
Me.Txtpct.Location = New System.Drawing.Point(83, 31)
Me.Txtpct.MaxLength = 3
Me.Txtpct.Name = "Txtpct"
Me.Txtpct.Size = New System.Drawing.Size(44, 20)
Me.Txtpct.TabIndex = 3
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(3, 31)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(74, 24)
Me.Label6.TabIndex = 10
Me.Label6.Text = "Percentage"
'
'FrmTAP16C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(312, 62)
Me.Controls.Add(Me.Txtpct)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.Txtyearno)
Me.Controls.Add(Me.Label2)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTAP16C"
Me.Text = "Maintain PP MFg & Equip -Depreciation Table"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTAP16C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


  myTXDMDEP = New TXDMDEP.mydata(MyDBConnect)

  MyFrmTAP16.TBarNew.Enabled = False
  MyFrmTAP16.TBarSave.Enabled = True
  If Wrkyearno > 0 Then
    MyFrmTAP16.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(Txtyearno)
  End If

	myTXDMDEP.GetOneRecordP(WrkYear, WrkYearNo)
  If myTXDMDEP.RecordNotFound Then Exit Sub
  Txtyearno.Text = Wrkyearno

  If s_chg = False And s_full = False Then    '#sec
    MyFrmTAP16.TBarSave.Visible = False
  End If
  With myTXDMDEP
    Txtpct.Text = ._PCT
  End With
End Sub
Private Sub FrmTAP16C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTAP16.SbpScreen.Text = "TAP16C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmTAP16C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTAP16.TBarNew.Enabled = True
  MyFrmTAP16.TBarDelete.Enabled = False
  MyFrmTAP16.TBarSave.Enabled = False
  MyFrmTAP16.TBarSave.Visible = True   '#sec
  MyFrmTAP16B.FormatGrid()
  MyFrmTAP16B.Show()
End Sub
Public Sub DeleteData(ByRef Cancel As Boolean)
  Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    myTXDMDEP.DeleteOneRecordP()

End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String

  myTXDMDEP.GetOneRecordP(WrkYear, MyUtils.CnvSng(Txtyearno.Text))
  If WrkYearNo = 0 Then
    If myTXDMDEP.RecordNotFound = False Then
      Me.ErrProv.SetError(Txtyearno, "Record already exists")
      Exit Sub
    End If
  End If

  If Not myTXDMDEP.RecordNotFound Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MovetoFile()
        myTXDMDEP.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MovetoFile()
        myTXDMDEP.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
  Me.Close()
End Sub
Private Sub MovetoFile()

   With myTXDMDEP
    ._YEAR = WrkYear
    ._YEARNO = MyUtils.CnvSng(Txtyearno.Text)
    ._PCT = MyUtils.CnvSng(Txtpct.Text)
  End With

End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(Txtyearno, "")
  ErrProv.SetError(Txtpct, "")

  For I = 0 To ErrorField.GetUpperBound(0)
  Select Case ErrorField(I)
    Case "yearno"
      ErrProv.SetError(Txtyearno, ErrorMsg(I))
    Case "pct"
      ErrProv.SetError(Txtpct, ErrorMsg(I))
    Case Nothing
      Exit Sub
  End Select
  Next I
End Sub
Private Sub Txtyearno_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtyearno.KeyPress
e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub Txtpct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtpct.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

  If MyUtils.CnvSng(Txtyearno.Text) = 0 Then
      ErrorField(I) = "yearno"
      ErrorMsg(I) = "Year is required"
      I = I + 1
  End If

  If MyUtils.CnvSng(Txtpct.Text) = 0 Or MyUtils.CnvSng(Txtpct.Text) > 100 Then
      ErrorField(I) = "pct"
      ErrorMsg(I) = "Invalid Percentage"
      I = I + 1
  End If

End Sub

End Class






