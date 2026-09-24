Public Class FrmTAP11C
  Inherits System.Windows.Forms.Form
  Dim myTXDCDEP As TXDCDEP.myData
  Dim ds As DataSet = New DataSet
	Friend WrkYear As Integer
	Friend Wrkdecode As String
  Friend Wrkyearno As String
  Friend WithEvents Txtpct As System.Windows.Forms.TextBox
  Friend WithEvents ChkPrior As System.Windows.Forms.CheckBox
  Friend WithEvents TxtProPct As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtDecode As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Txtyearno As System.Windows.Forms.TextBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.TxtDecode = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.Txtyearno = New System.Windows.Forms.TextBox
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Txtpct = New System.Windows.Forms.TextBox
Me.Label6 = New System.Windows.Forms.Label
Me.ChkPrior = New System.Windows.Forms.CheckBox
Me.TxtProPct = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.Label4 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 12)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(110, 24)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Depreciation Code"
'
'TxtDecode
'
Me.TxtDecode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtDecode.Location = New System.Drawing.Point(165, 12)
Me.TxtDecode.MaxLength = 3
Me.TxtDecode.Name = "TxtDecode"
Me.TxtDecode.Size = New System.Drawing.Size(44, 20)
Me.TxtDecode.TabIndex = 0
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(8, 36)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(74, 24)
Me.Label2.TabIndex = 2
Me.Label2.Text = "Year No"
'
'Txtyearno
'
Me.Txtyearno.Location = New System.Drawing.Point(165, 36)
Me.Txtyearno.MaxLength = 2
Me.Txtyearno.Name = "Txtyearno"
Me.Txtyearno.Size = New System.Drawing.Size(31, 20)
Me.Txtyearno.TabIndex = 1
Me.Txtyearno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Txtpct
'
Me.Txtpct.Location = New System.Drawing.Point(165, 86)
Me.Txtpct.MaxLength = 3
Me.Txtpct.Name = "Txtpct"
Me.Txtpct.Size = New System.Drawing.Size(44, 20)
Me.Txtpct.TabIndex = 3
Me.Txtpct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(8, 86)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(151, 20)
Me.Label6.TabIndex = 10
Me.Label6.Text = "Depreciation Percentage"
'
'ChkPrior
'
Me.ChkPrior.AutoSize = True
Me.ChkPrior.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkPrior.Location = New System.Drawing.Point(11, 113)
Me.ChkPrior.Name = "ChkPrior"
Me.ChkPrior.Size = New System.Drawing.Size(71, 17)
Me.ChkPrior.TabIndex = 4
Me.ChkPrior.Text = "Prior Yrs?"
Me.ChkPrior.UseVisualStyleBackColor = True
'
'TxtProPct
'
Me.TxtProPct.Location = New System.Drawing.Point(165, 62)
Me.TxtProPct.MaxLength = 3
Me.TxtProPct.Name = "TxtProPct"
Me.TxtProPct.Size = New System.Drawing.Size(44, 20)
Me.TxtProPct.TabIndex = 2
Me.TxtProPct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(8, 62)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(155, 20)
Me.Label3.TabIndex = 13
Me.Label3.Text = "Prorate Cost by Percentage"
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(224, 65)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(91, 20)
Me.Label4.TabIndex = 14
Me.Label4.Text = "(default is 100%)"
'
'FrmTAP11C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(370, 142)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.TxtProPct)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.ChkPrior)
Me.Controls.Add(Me.Txtpct)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.Txtyearno)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.TxtDecode)
Me.Controls.Add(Me.Label1)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTAP11C"
Me.Text = "Maintain PP Declaration Depreciation Table"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTAP11C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


  myTXDCDEP = New TXDCDEP.mydata(MyDBConnect)

  MyFrmTAP11.TBarNew.Enabled = False
  MyFrmTAP11.TBarSave.Enabled = True
  If Wrkdecode > " " Then
    MyFrmTAP11.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(TxtDecode)
    MyUtils.SetTxtReadOnly(Txtyearno)
  End If

	myTXDCDEP.GetOneRecordP(WrkYear, Wrkdecode, Wrkyearno)
  If myTXDCDEP.RecordNotFound Then Exit Sub
  TxtDecode.Text = Wrkdecode
  Txtyearno.Text = Wrkyearno

  If s_chg = False And s_full = False Then    '#sec
    MyFrmTAP11.TBarSave.Visible = False
  End If
  With myTXDCDEP
    TxtProPct.Text = ._PROPCT
    Txtpct.Text = ._PCT
    If ._PRIOR = "Y" Then
      ChkPrior.Checked = True
    End If

  End With
End Sub
Private Sub FrmTAP11C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTAP11.SbpScreen.Text = "TAP11C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmTAP11C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTAP11.TBarNew.Enabled = True
  MyFrmTAP11.TBarDelete.Enabled = False
  MyFrmTAP11.TBarSave.Enabled = False
  MyFrmTAP11.TBarSave.Visible = True   '#sec
  MyFrmTAP11B.FormatGrid()
  MyFrmTAP11B.Show()
End Sub
Public Sub DeleteData(ByRef Cancel As Boolean)
  Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    myTXDCDEP.DeleteOneRecordP()

End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String

  myTXDCDEP.GetOneRecordP(WrkYear, TxtDecode.Text, MyUtils.CnvSng(Txtyearno.Text))
  If Wrkdecode = "" Then
    If myTXDCDEP.RecordNotFound = False Then
      Me.ErrProv.SetError(TxtDecode, "Record already exists")
      Exit Sub
    End If
  End If

  If Not myTXDCDEP.RecordNotFound Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MovetoFile()
        myTXDCDEP.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MovetoFile()
        myTXDCDEP.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
  Me.Close()
End Sub
Private Sub MovetoFile()

   With myTXDCDEP
    ._YEAR = WrkYear
    ._DECODE = TxtDecode.Text
    ._YEARNO = MyUtils.CnvSng(Txtyearno.Text)
    ._PROPCT = MyUtils.CnvSng(TxtProPct.Text)
    ._PCT = MyUtils.CnvSng(Txtpct.Text)
    If ChkPrior.Checked Then
      ._PRIOR = "Y"
    Else
      ._PRIOR = ""
    End If

  End With

End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtDecode, "")
  ErrProv.SetError(Txtyearno, "")
  ErrProv.SetError(TxtProPct, "")
  ErrProv.SetError(Txtpct, "")

  For I = 0 To ErrorField.GetUpperBound(0)
  Select Case ErrorField(I)
    Case "decode"
      ErrProv.SetError(TxtDecode, ErrorMsg(I))
    Case "yearno"
      ErrProv.SetError(Txtyearno, ErrorMsg(I))
    Case "propct"
      ErrProv.SetError(Txtpct, ErrorMsg(I))
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
Private Sub Txtpropct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtProPct.KeyPress
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

  If TxtDecode.Text = String.Empty Then
      ErrorField(I) = "decode"
      ErrorMsg(I) = "Code is required"
      I = I + 1
  End If

  If MyUtils.CnvSng(Txtyearno.Text) = 0 Then
      ErrorField(I) = "yearno"
      ErrorMsg(I) = "Year is required"
      I = I + 1
  End If

  If MyUtils.CnvSng(TxtProPct.Text) > 100 Then
      ErrorField(I) = "propct"
      ErrorMsg(I) = "Invalid Percentage"
      I = I + 1
  End If

  If MyUtils.CnvSng(Txtpct.Text) = 0 Or MyUtils.CnvSng(Txtpct.Text) > 100 Then
      ErrorField(I) = "pct"
      ErrorMsg(I) = "Invalid Percentage"
      I = I + 1
  End If

  End Sub

End Class






