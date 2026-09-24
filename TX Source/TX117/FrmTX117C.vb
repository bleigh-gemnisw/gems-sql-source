Public Class FrmTX117C
  Inherits System.Windows.Forms.Form
  Dim myTXLEASE As TXLEASE.myData
  Friend WithEvents TxtPhone As System.Windows.Forms.TextBox
  Friend WithEvents TxtContact As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WrkCode As String
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
Friend WithEvents TxtCode As System.Windows.Forms.TextBox
Friend WithEvents TxtName As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents TxtAddr1 As System.Windows.Forms.TextBox
Friend WithEvents TxtAddr2 As System.Windows.Forms.TextBox
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents TxtState As System.Windows.Forms.TextBox
Friend WithEvents Label9 As System.Windows.Forms.Label
Friend WithEvents TxtZip As System.Windows.Forms.TextBox
Friend WithEvents TxtCity As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtCode = New System.Windows.Forms.TextBox()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtAddr1 = New System.Windows.Forms.TextBox()
    Me.TxtAddr2 = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.TxtZip = New System.Windows.Forms.TextBox()
    Me.TxtContact = New System.Windows.Forms.TextBox()
    Me.TxtPhone = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(8, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(32, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Code"
    '
    'TxtCode
    '
    Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode.Location = New System.Drawing.Point(46, 8)
    Me.TxtCode.MaxLength = 2
    Me.TxtCode.Name = "TxtCode"
    Me.TxtCode.Size = New System.Drawing.Size(28, 20)
    Me.TxtCode.TabIndex = 0
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(8, 39)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(64, 16)
    Me.Label2.TabIndex = 28
    Me.Label2.Text = "Name"
    '
    'TxtName
    '
    Me.TxtName.Location = New System.Drawing.Point(100, 34)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(256, 20)
    Me.TxtName.TabIndex = 2
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(8, 61)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(84, 16)
    Me.Label4.TabIndex = 30
    Me.Label4.Text = "Address Line 1"
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(8, 81)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(84, 16)
    Me.Label6.TabIndex = 32
    Me.Label6.Text = "Address Line 2"
    '
    'TxtAddr1
    '
    Me.TxtAddr1.Location = New System.Drawing.Point(100, 61)
    Me.TxtAddr1.MaxLength = 35
    Me.TxtAddr1.Name = "TxtAddr1"
    Me.TxtAddr1.Size = New System.Drawing.Size(288, 20)
    Me.TxtAddr1.TabIndex = 3
    '
    'TxtAddr2
    '
    Me.TxtAddr2.Location = New System.Drawing.Point(100, 81)
    Me.TxtAddr2.MaxLength = 35
    Me.TxtAddr2.Name = "TxtAddr2"
    Me.TxtAddr2.Size = New System.Drawing.Size(288, 20)
    Me.TxtAddr2.TabIndex = 4
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(10, 111)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(24, 13)
    Me.Label7.TabIndex = 33
    Me.Label7.Text = "City"
    '
    'TxtCity
    '
    Me.TxtCity.Location = New System.Drawing.Point(100, 107)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(212, 20)
    Me.TxtCity.TabIndex = 6
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(312, 111)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(32, 16)
    Me.Label8.TabIndex = 34
    Me.Label8.Text = "State"
    '
    'TxtState
    '
    Me.TxtState.Location = New System.Drawing.Point(348, 107)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(28, 20)
    Me.TxtState.TabIndex = 7
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(385, 110)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(55, 16)
    Me.Label9.TabIndex = 35
    Me.Label9.Text = "ZIP Code"
    '
    'TxtZip
    '
    Me.TxtZip.Location = New System.Drawing.Point(446, 107)
    Me.TxtZip.MaxLength = 10
    Me.TxtZip.Name = "TxtZip"
    Me.TxtZip.Size = New System.Drawing.Size(76, 20)
    Me.TxtZip.TabIndex = 8
    '
    'TxtContact
    '
    Me.TxtContact.Location = New System.Drawing.Point(100, 134)
    Me.TxtContact.MaxLength = 30
    Me.TxtContact.Name = "TxtContact"
    Me.TxtContact.Size = New System.Drawing.Size(244, 20)
    Me.TxtContact.TabIndex = 36
    '
    'TxtPhone
    '
    Me.TxtPhone.Location = New System.Drawing.Point(100, 156)
    Me.TxtPhone.MaxLength = 20
    Me.TxtPhone.Name = "TxtPhone"
    Me.TxtPhone.Size = New System.Drawing.Size(170, 20)
    Me.TxtPhone.TabIndex = 37
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(10, 137)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(44, 13)
    Me.Label3.TabIndex = 38
    Me.Label3.Text = "Contact"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(10, 159)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(78, 13)
    Me.Label5.TabIndex = 39
    Me.Label5.Text = "Phone Number"
    '
    'FrmTX117C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(542, 187)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtPhone)
    Me.Controls.Add(Me.TxtContact)
    Me.Controls.Add(Me.TxtZip)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.TxtState)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.TxtCity)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TxtAddr2)
    Me.Controls.Add(Me.TxtAddr1)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtName)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtCode)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX117C"
    Me.Text = "Maintain Leasing Company"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region
Private Sub FrmTX117C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myTXLEASE = New TXLEASE.mydata(MyDBConnect)
  MyFrmTX117.TBarNew.Enabled = False
  MyFrmTX117.TBarSave.Enabled = True
  MyFrmTX117.TBarPrint.Enabled = False
  If WrkCode <> "" Then
    MyFrmTX117.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(TxtCode)
  Else
    Me.Text = "Add " & Me.Text
    MyFrmTX117.TBarDelete.Enabled = False
    Exit Sub
  End If

  myTXLEASE.GetOneRecordP(WrkCode)
  TxtCode.Text = WrkCode
  If myTXLEASE.RecordNotFound Then
    MyFrmTX117.TBarNew.Enabled = False
    MyFrmTX117.TBarSave.Enabled = False
    MyFrmTX117.TBarDelete.Enabled = False
    Me.ErrProv.SetError(TxtCode, "Record not found")
    Exit Sub
  End If

  If s_chg = False And s_full = False Then    '#sec
    MyFrmTX117.TBarSave.Visible = False
  End If

  With myTXLEASE
    TxtCode.Text = WrkCode
    TxtName.Text = Trim(._NAME)
    TxtAddr1.Text = Trim(._ADDR1)
    TxtAddr2.Text = Trim(._ADDR2)
    TxtCity.Text = Trim(._CITY)
    TxtState.Text = Trim(._STATE)
    TxtZip.Text = Trim(._ZIPA)
    TxtContact.Text = Trim(._CONTACT)
    TxtPhone.Text = Trim(._PHONE)
  End With
End Sub
Private Sub FrmTX117C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX117.SbpScreen.Text = "TX117C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmTX117C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTX117.TBarNew.Enabled = True
  MyFrmTX117.TBarDelete.Enabled = False
  MyFrmTX117.TBarSave.Enabled = False
  MyFrmTX117.TBarPrint.Enabled = False
  MyFrmTX117B.FormatGrid()
  MyFrmTX117B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
  myTXLEASE.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  myTXLEASE.GetOneRecordP(TxtCode.Text)
  If WrkCode = "" Then
    If Not myTXLEASE.RecordNotFound Then
      Me.ErrProv.SetError(TxtCode, "Record already exists")
      Exit Sub
    End If
  End If

  If WrkCode <> "" Then
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myTXLEASE.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  Else
    myTXLEASE._CODE = TxtCode.Text
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myTXLEASE.AddOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myTXLEASE
    ._NAME = TxtName.Text
    ._ADDR1 = TxtAddr1.Text
    ._ADDR2 = TxtAddr2.Text
    ._CITY = TxtCity.Text
    ._STATE = TxtState.Text
    ._ZIPA = TxtZip.Text
    ._CONTACT = TxtContact.Text
    ._PHONE = TxtPhone.Text
  End With
 End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If TxtCode.Text = String.Empty Then
      ErrorField(I) = "code"
      ErrorMsg(I) = "Code is required"
      I = I + 1
    End If
  End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtCode, "")

  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
    Case "code"
      ErrProv.SetError(TxtCode, ErrorMsg(I))
    Case Nothing
      Exit Sub
    End Select
  Next I
End Sub
End Class






