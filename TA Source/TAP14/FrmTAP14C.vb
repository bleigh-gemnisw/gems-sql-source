Public Class FrmTAP14C
  Inherits System.Windows.Forms.Form
  Dim myTXDMLES As TXDMLES.myData
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents TxtZip4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtZip5 As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtState As System.Windows.Forms.TextBox
  Friend WithEvents TxtAddr As System.Windows.Forms.TextBox
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WrkLease As String
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
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtLease As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Label2 = New System.Windows.Forms.Label
Me.TxtLease = New System.Windows.Forms.TextBox
Me.Label15 = New System.Windows.Forms.Label
Me.TxtZip4 = New System.Windows.Forms.TextBox
Me.TxtZip5 = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
Me.TxtCity = New System.Windows.Forms.TextBox
Me.TxtState = New System.Windows.Forms.TextBox
Me.TxtAddr = New System.Windows.Forms.TextBox
Me.TxtName = New System.Windows.Forms.TextBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(8, 9)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(80, 19)
Me.Label2.TabIndex = 28
Me.Label2.Text = "Lease ID"
Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'TxtLease
'
Me.TxtLease.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtLease.Location = New System.Drawing.Point(98, 8)
Me.TxtLease.MaxLength = 20
Me.TxtLease.Name = "TxtLease"
Me.TxtLease.Size = New System.Drawing.Size(185, 20)
Me.TxtLease.TabIndex = 0
'
'Label15
'
Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label15.Location = New System.Drawing.Point(8, 68)
Me.Label15.Name = "Label15"
Me.Label15.Size = New System.Drawing.Size(80, 16)
Me.Label15.TabIndex = 249
Me.Label15.Text = "Address"
'
'TxtZip4
'
Me.TxtZip4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtZip4.Location = New System.Drawing.Point(421, 88)
Me.TxtZip4.MaxLength = 4
Me.TxtZip4.Name = "TxtZip4"
Me.TxtZip4.Size = New System.Drawing.Size(32, 20)
Me.TxtZip4.TabIndex = 6
'
'TxtZip5
'
Me.TxtZip5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtZip5.Location = New System.Drawing.Point(373, 88)
Me.TxtZip5.MaxLength = 5
Me.TxtZip5.Name = "TxtZip5"
Me.TxtZip5.Size = New System.Drawing.Size(40, 20)
Me.TxtZip5.TabIndex = 5
'
'Label4
'
Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label4.Location = New System.Drawing.Point(8, 92)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(80, 16)
Me.Label4.TabIndex = 248
Me.Label4.Text = "City/State/Zip"
'
'Label3
'
Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label3.Location = New System.Drawing.Point(8, 43)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(80, 16)
Me.Label3.TabIndex = 247
Me.Label3.Text = "Name"
'
'TxtCity
'
Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtCity.Location = New System.Drawing.Point(98, 88)
Me.TxtCity.MaxLength = 25
Me.TxtCity.Name = "TxtCity"
Me.TxtCity.Size = New System.Drawing.Size(232, 20)
Me.TxtCity.TabIndex = 3
'
'TxtState
'
Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtState.Location = New System.Drawing.Point(341, 88)
Me.TxtState.MaxLength = 2
Me.TxtState.Name = "TxtState"
Me.TxtState.Size = New System.Drawing.Size(24, 20)
Me.TxtState.TabIndex = 4
'
'TxtAddr
'
Me.TxtAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtAddr.Location = New System.Drawing.Point(98, 64)
Me.TxtAddr.MaxLength = 35
Me.TxtAddr.Name = "TxtAddr"
Me.TxtAddr.Size = New System.Drawing.Size(280, 20)
Me.TxtAddr.TabIndex = 2
'
'TxtName
'
Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtName.Location = New System.Drawing.Point(98, 40)
Me.TxtName.MaxLength = 35
Me.TxtName.Name = "TxtName"
Me.TxtName.Size = New System.Drawing.Size(280, 20)
Me.TxtName.TabIndex = 1
'
'FrmTAP14C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(466, 128)
Me.Controls.Add(Me.Label15)
Me.Controls.Add(Me.TxtZip4)
Me.Controls.Add(Me.TxtZip5)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.TxtCity)
Me.Controls.Add(Me.TxtState)
Me.Controls.Add(Me.TxtAddr)
Me.Controls.Add(Me.TxtName)
Me.Controls.Add(Me.TxtLease)
Me.Controls.Add(Me.Label2)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTAP14C"
Me.Text = "Maintain Lessor"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region
Private Sub FrmTAP14C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myTXDMLES = New TXDMLES.mydata(MyDBConnect)
  MyFrmTAP14.TBarNew.Enabled = False
  MyFrmTAP14.TBarSave.Enabled = True
  MyFrmTAP14.TBarPrint.Enabled = False
  If WrkLease <> "" Then
    MyFrmTAP14.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(TxtLease)
  End If
  If WrkLease = "" Then
    Me.Text = "Add " & Me.Text
    MyFrmTAP14.TBarDelete.Enabled = False
    Exit Sub
  End If
  myTXDMLES.GetOneRecordP(WrkLease)

  If myTXDMLES.RecordNotFound Then
    MyFrmTAP14.TBarNew.Enabled = False
    MyFrmTAP14.TBarSave.Enabled = False
    MyFrmTAP14.TBarDelete.Enabled = False
    Me.ErrProv.SetError(TxtLease, "Record not found")
    Exit Sub
  End If

  If s_chg = False And s_full = False Then    '#sec
    MyFrmTAP14.TBarSave.Visible = False
  End If

  With myTXDMLES
    TxtLease.Text = WrkLease
    TxtName.Text = Trim(._NAME)
    TxtAddr.Text = Trim(._ADDR)
    TxtCity.Text = Trim(._CITY)
    TxtState.Text = Trim(._STATE)
    If ._ZIP5 > 0 Then
      TxtZip5.Text = Format(._ZIP5, "00000")
    End If
    If ._ZIP4 > 0 Then
      TxtZip4.Text = Format(._ZIP4, "0000")
    End If
  End With
End Sub
Private Sub FrmTAP14C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTAP14.SbpScreen.Text = "TAP14C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmTAP14C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTAP14.TBarNew.Enabled = True
  MyFrmTAP14.TBarDelete.Enabled = False
  MyFrmTAP14.TBarSave.Enabled = False
  MyFrmTAP14.TBarPrint.Enabled = False
  MyFrmTAP14B.FormatGrid()
  MyFrmTAP14B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
  myTXDMLES.DeleteOneRecordP()
  Me.Close()
End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    myTXDMLES.GetOneRecordP(WrkLease)
    If WrkLease = String.Empty Then
      If Not myTXDMLES.RecordNotFound Then
        Me.ErrProv.SetError(TxtLease, "Record already exists")
        Exit Sub
      End If
    End If

    If Not WrkLease = String.Empty Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        myTXDMLES.UpdateOneRecordP()
        Me.Close()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        myTXDMLES.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    Me.Close()
  End Sub
   Private Sub MoveToFile()
      With myTXDMLES
        ._LEASE = TxtLease.Text
        ._NAME = TxtName.Text
        ._ADDR = TxtAddr.Text
        ._CITY = TxtCity.Text
        ._STATE = TxtState.Text
        ._ZIP5 = MyUtils.CnvSng(TxtZip5.Text)
        ._ZIP4 = MyUtils.CnvSng(TxtZip4.Text)
      End With
   End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If TxtLease.Text = String.Empty Then
      ErrorField(I) = "lease"
      ErrorMsg(I) = "Lease is required"
      I = I + 1
    End If

    If TxtName.Text = String.Empty Then
      ErrorField(I) = "name"
      ErrorMsg(I) = "Name is required"
      I = I + 1
    End If

    If TxtAddr.Text = String.Empty Then
      ErrorField(I) = "addr"
      ErrorMsg(I) = "Address is required"
      I = I + 1
    End If

    If TxtCity.Text = String.Empty Then
      ErrorField(I) = "city"
      ErrorMsg(I) = "City is required"
      I = I + 1
    End If
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtLease, "")
    ErrProv.SetError(TxtName, "")
    ErrProv.SetError(TxtAddr, "")
    ErrProv.SetError(TxtCity, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "lease"
        ErrProv.SetError(TxtLease, ErrorMsg(I))
      Case "name"
        ErrProv.SetError(TxtName, ErrorMsg(I))
      Case "addr"
        ErrProv.SetError(TxtAddr, ErrorMsg(I))
      Case "city"
        ErrProv.SetError(TxtCity, ErrorMsg(I))
      Case ""
        Exit Sub
      End Select
    Next I
  End Sub
End Class






