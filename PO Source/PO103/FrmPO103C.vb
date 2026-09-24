Public Class FrmPO103C
  Inherits System.Windows.Forms.Form
  Dim myPURCTL As PURCTL.myData
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents DtPckStart As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtDyord As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents DtPckEnd As System.Windows.Forms.DateTimePicker
  Friend WrkFscyr As Integer
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
Friend WithEvents TxtNxtPO As System.Windows.Forms.TextBox
Friend WithEvents TxtFscyr As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtNxtPO = New System.Windows.Forms.TextBox()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtFscyr = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.DtPckStart = New System.Windows.Forms.DateTimePicker()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.DtPckEnd = New System.Windows.Forms.DateTimePicker()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtDyord = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 72)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(101, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Starting PO Number"
    '
    'TxtNxtPO
    '
    Me.TxtNxtPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtNxtPO.Location = New System.Drawing.Point(119, 69)
    Me.TxtNxtPO.MaxLength = 7
    Me.TxtNxtPO.Name = "TxtNxtPO"
    Me.TxtNxtPO.Size = New System.Drawing.Size(50, 20)
    Me.TxtNxtPO.TabIndex = 2
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtFscyr
    '
    Me.TxtFscyr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFscyr.Location = New System.Drawing.Point(77, 12)
    Me.TxtFscyr.MaxLength = 4
    Me.TxtFscyr.Name = "TxtFscyr"
    Me.TxtFscyr.Size = New System.Drawing.Size(32, 20)
    Me.TxtFscyr.TabIndex = 0
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 15)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(59, 13)
    Me.Label2.TabIndex = 30
    Me.Label2.Text = "Fiscal Year"
    '
    'DtPckStart
    '
    Me.DtPckStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckStart.Location = New System.Drawing.Point(93, 43)
    Me.DtPckStart.Name = "DtPckStart"
    Me.DtPckStart.Size = New System.Drawing.Size(88, 20)
    Me.DtPckStart.TabIndex = 35
    Me.DtPckStart.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(14, 44)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(73, 13)
    Me.Label3.TabIndex = 36
    Me.Label3.Text = "Fiscal Starting"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(187, 44)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(70, 13)
    Me.Label4.TabIndex = 38
    Me.Label4.Text = "Fiscal Ending"
    '
    'DtPckEnd
    '
    Me.DtPckEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckEnd.Location = New System.Drawing.Point(266, 43)
    Me.DtPckEnd.Name = "DtPckEnd"
    Me.DtPckEnd.Size = New System.Drawing.Size(88, 20)
    Me.DtPckEnd.TabIndex = 37
    Me.DtPckEnd.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(14, 101)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(100, 13)
    Me.Label5.TabIndex = 39
    Me.Label5.Text = "Days to Keep Open"
    '
    'TxtDyord
    '
    Me.TxtDyord.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDyord.Location = New System.Drawing.Point(120, 95)
    Me.TxtDyord.MaxLength = 3
    Me.TxtDyord.Name = "TxtDyord"
    Me.TxtDyord.Size = New System.Drawing.Size(24, 20)
    Me.TxtDyord.TabIndex = 40
    '
    'FrmPO103C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(480, 138)
    Me.Controls.Add(Me.TxtDyord)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.DtPckEnd)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.DtPckStart)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtFscyr)
    Me.Controls.Add(Me.TxtNxtPO)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmPO103C"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

  Private Sub FrmPO103C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myPURCTL = New PURCTL.myData()
  myPURCTL.MyDBConn = myDBConnect
  MyFrmPO103.TBarNew.Enabled = False
  MyFrmPO103.TBarSave.Enabled = True
  MyFrmPO103.TBarPrint.Enabled = False
  If WrkFscyr > 0 Then
    MyFrmPO103.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(TxtFscyr)
  End If
  If WrkFscyr = 0 Then
    Me.Text = "Add " & Me.Text
    DtPckStart.Value = Date.Today
    DtPckEnd.Value = Date.Today
    MyFrmPO103.TBarDelete.Enabled = False
    Exit Sub
  End If
  myPURCTL.GetOneRecordP(WrkFscyr)
  TxtFscyr.Text = WrkFscyr

 If myPURCTL.RecordNotFound Then
  MyFrmPO103.TBarNew.Enabled = False
  MyFrmPO103.TBarSave.Enabled = False
  MyFrmPO103.TBarDelete.Enabled = False
  Me.ErrProv.SetError(TxtNxtPO, "Record not found")
  Exit Sub
 End If

  If s_chg = False And s_full = False Then    '#sec
    MyFrmPO103.TBarSave.Visible = False
  End If

  With myPURCTL
   DtPckStart.Value = MyUtils.GetDBDate(._FSCS8)
   DtPckEnd.Value = MyUtils.GetDBDate(._FSCE8)
   TxtNxtPO.Text = ._NXTPO
   TxtDyord.Text = ._DYORD
  End With
End Sub
Private Sub FrmPO103C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmPO103.SbpScreen.Text = "PO103C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub FrmPO103C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmPO103.TBarNew.Enabled = True
  MyFrmPO103.TBarDelete.Enabled = False
  MyFrmPO103.TBarSave.Enabled = False
  MyFrmPO103.TBarPrint.Enabled = False
  MyFrmPO103B.FormatGrid()
  MyFrmPO103B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
 myPURCTL.DeleteOneRecordP()
  Me.Close()
End Sub

Public Sub SaveData()
 Dim ErrorField(25) As String
 Dim ErrorMsg(25) As String
 myPURCTL.GetOneRecordP(TxtFscyr.Text)
 If WrkFscyr = 0 Then
   If Not myPURCTL.RecordNotFound Then
     Me.ErrProv.SetError(TxtNxtPO, "Record already exists")
     Exit Sub
   End If
 End If
 If WrkFscyr > 0 Then
   MovetoFile()
   EditChecks(ErrorField, ErrorMsg)
   If IsNothing(ErrorMsg(0)) Then
     myPURCTL.UpdateOneRecordP()
   Else
     ShowError(ErrorField, ErrorMsg)
     Exit Sub
   End If
 Else
   myPURCTL._FSCYR = MyUtils.CnvSng(TxtFscyr.Text)
   MovetoFile()
   EditChecks(ErrorField, ErrorMsg)
   If IsNothing(ErrorMsg(0)) Then
     myPURCTL.AddOneRecordP()
   Else
     ShowError(ErrorField, ErrorMsg)
     Exit Sub
   End If
 End If
 Me.Close()
End Sub
Private Sub MovetoFile()
 With myPURCTL
   ._FSCS8 = MyUtils.SetDBDate(DtPckStart.Value)
   ._FSCE8 = MyUtils.SetDBDate(DtPckEnd.Value)
   ._NXTPO = MyUtils.CnvSng(TxtNxtPO.Text)
   ._DYORD = MyUtils.CnvSng(TxtDyord.Text)
 End With
End Sub
 Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer

  For I = 0 To ErrorField.GetUpperBound(0)
   If IsNothing(ErrorField(I)) Then
    Exit For
   End If
  Next

  If TxtFscyr.Text = 0 Then
   ErrorField(I) = "fscyr"
   ErrorMsg(I) = "Fiscal Year is required"
   I = I + 1
  End If

  If TxtNxtPO.Text = String.Empty Then
   ErrorField(I) = "nxtpo"
   ErrorMsg(I) = "Starting PO is required"
   I = I + 1
  End If

 End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
 Dim I As Integer
 ErrProv.SetError(TxtNxtPO, "")
 ErrProv.SetError(TxtFscyr, "")

 For I = 0 To ErrorField.GetUpperBound(0)
  Select Case ErrorField(I)
  Case "fscyr"
    ErrProv.SetError(TxtNxtPO, ErrorMsg(I))
  Case "nxtpo"
    ErrProv.SetError(TxtFscyr, ErrorMsg(I))
  Case Nothing
    Exit Sub
  End Select
 Next I
End Sub
Private Sub TxtFscyr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFscyr.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtNxtpo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNxtPO.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class
