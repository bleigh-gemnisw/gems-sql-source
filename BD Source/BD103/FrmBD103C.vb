Public Class FrmBD103C
  Inherits System.Windows.Forms.Form
  Dim myBDCON As BDCON.myData
  Friend WrkRecID As Integer
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents LblCoID As System.Windows.Forms.Label
  Friend WithEvents TxtCoCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtCoState As System.Windows.Forms.TextBox
  Friend WithEvents TxtCoZip As System.Windows.Forms.TextBox
  Friend WithEvents TxtCoAddr As System.Windows.Forms.TextBox
  Friend WithEvents TxtCoPhon As System.Windows.Forms.TextBox
  Friend WithEvents TxtCoLic1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtCoName As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtCoLic5 As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TxtCoLic4 As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtCoLic3 As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtCoLic2 As System.Windows.Forms.TextBox
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.LblCoID = New System.Windows.Forms.Label()
    Me.TxtCoCity = New System.Windows.Forms.TextBox()
    Me.TxtCoState = New System.Windows.Forms.TextBox()
    Me.TxtCoZip = New System.Windows.Forms.TextBox()
    Me.TxtCoAddr = New System.Windows.Forms.TextBox()
    Me.TxtCoPhon = New System.Windows.Forms.TextBox()
    Me.TxtCoLic1 = New System.Windows.Forms.TextBox()
    Me.TxtCoName = New System.Windows.Forms.TextBox()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.Label22 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtCoLic2 = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtCoLic3 = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtCoLic4 = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtCoLic5 = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(399, 60)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(22, 13)
    Me.Label4.TabIndex = 476
    Me.Label4.Text = "Zip"
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(329, 60)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(32, 13)
    Me.Label8.TabIndex = 475
    Me.Label8.Text = "State"
    '
    'LblCoID
    '
    Me.LblCoID.AutoSize = True
    Me.LblCoID.Location = New System.Drawing.Point(406, 16)
    Me.LblCoID.Name = "LblCoID"
    Me.LblCoID.Size = New System.Drawing.Size(30, 13)
    Me.LblCoID.TabIndex = 474
    Me.LblCoID.Text = "<ID>"
    '
    'TxtCoCity
    '
    Me.TxtCoCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCoCity.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCoCity.Location = New System.Drawing.Point(112, 56)
    Me.TxtCoCity.MaxLength = 25
    Me.TxtCoCity.Name = "TxtCoCity"
    Me.TxtCoCity.Size = New System.Drawing.Size(210, 22)
    Me.TxtCoCity.TabIndex = 2
    '
    'TxtCoState
    '
    Me.TxtCoState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCoState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCoState.Location = New System.Drawing.Point(367, 56)
    Me.TxtCoState.MaxLength = 2
    Me.TxtCoState.Name = "TxtCoState"
    Me.TxtCoState.Size = New System.Drawing.Size(24, 22)
    Me.TxtCoState.TabIndex = 3
    '
    'TxtCoZip
    '
    Me.TxtCoZip.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCoZip.Location = New System.Drawing.Point(427, 55)
    Me.TxtCoZip.MaxLength = 5
    Me.TxtCoZip.Name = "TxtCoZip"
    Me.TxtCoZip.Size = New System.Drawing.Size(48, 22)
    Me.TxtCoZip.TabIndex = 4
    '
    'TxtCoAddr
    '
    Me.TxtCoAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCoAddr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCoAddr.Location = New System.Drawing.Point(112, 34)
    Me.TxtCoAddr.MaxLength = 35
    Me.TxtCoAddr.Name = "TxtCoAddr"
    Me.TxtCoAddr.Size = New System.Drawing.Size(219, 22)
    Me.TxtCoAddr.TabIndex = 1
    '
    'TxtCoPhon
    '
    Me.TxtCoPhon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCoPhon.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCoPhon.Location = New System.Drawing.Point(112, 79)
    Me.TxtCoPhon.MaxLength = 20
    Me.TxtCoPhon.Name = "TxtCoPhon"
    Me.TxtCoPhon.Size = New System.Drawing.Size(175, 22)
    Me.TxtCoPhon.TabIndex = 5
    '
    'TxtCoLic1
    '
    Me.TxtCoLic1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCoLic1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCoLic1.Location = New System.Drawing.Point(112, 107)
    Me.TxtCoLic1.MaxLength = 25
    Me.TxtCoLic1.Name = "TxtCoLic1"
    Me.TxtCoLic1.Size = New System.Drawing.Size(209, 22)
    Me.TxtCoLic1.TabIndex = 6
    '
    'TxtCoName
    '
    Me.TxtCoName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCoName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCoName.Location = New System.Drawing.Point(112, 12)
    Me.TxtCoName.MaxLength = 35
    Me.TxtCoName.Name = "TxtCoName"
    Me.TxtCoName.Size = New System.Drawing.Size(288, 22)
    Me.TxtCoName.TabIndex = 0
    '
    'Label19
    '
    Me.Label19.AutoSize = True
    Me.Label19.Location = New System.Drawing.Point(10, 60)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(24, 13)
    Me.Label19.TabIndex = 480
    Me.Label19.Text = "City"
    '
    'Label20
    '
    Me.Label20.AutoSize = True
    Me.Label20.Location = New System.Drawing.Point(9, 38)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(76, 13)
    Me.Label20.TabIndex = 479
    Me.Label20.Text = "Street Address"
    '
    'Label21
    '
    Me.Label21.AutoSize = True
    Me.Label21.Location = New System.Drawing.Point(10, 83)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(38, 13)
    Me.Label21.TabIndex = 478
    Me.Label21.Text = "Phone"
    '
    'Label22
    '
    Me.Label22.AutoSize = True
    Me.Label22.Location = New System.Drawing.Point(10, 111)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(53, 13)
    Me.Label22.TabIndex = 477
    Me.Label22.Text = "License 1"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(10, 12)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(35, 13)
    Me.Label2.TabIndex = 481
    Me.Label2.Text = "Name"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(10, 139)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(53, 13)
    Me.Label1.TabIndex = 483
    Me.Label1.Text = "License 2"
    '
    'TxtCoLic2
    '
    Me.TxtCoLic2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCoLic2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCoLic2.Location = New System.Drawing.Point(112, 135)
    Me.TxtCoLic2.MaxLength = 25
    Me.TxtCoLic2.Name = "TxtCoLic2"
    Me.TxtCoLic2.Size = New System.Drawing.Size(209, 22)
    Me.TxtCoLic2.TabIndex = 7
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(10, 167)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(53, 13)
    Me.Label3.TabIndex = 485
    Me.Label3.Text = "License 3"
    '
    'TxtCoLic3
    '
    Me.TxtCoLic3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCoLic3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCoLic3.Location = New System.Drawing.Point(112, 163)
    Me.TxtCoLic3.MaxLength = 25
    Me.TxtCoLic3.Name = "TxtCoLic3"
    Me.TxtCoLic3.Size = New System.Drawing.Size(209, 22)
    Me.TxtCoLic3.TabIndex = 8
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(11, 195)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(53, 13)
    Me.Label5.TabIndex = 487
    Me.Label5.Text = "License 4"
    '
    'TxtCoLic4
    '
    Me.TxtCoLic4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCoLic4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCoLic4.Location = New System.Drawing.Point(113, 191)
    Me.TxtCoLic4.MaxLength = 25
    Me.TxtCoLic4.Name = "TxtCoLic4"
    Me.TxtCoLic4.Size = New System.Drawing.Size(209, 22)
    Me.TxtCoLic4.TabIndex = 9
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(10, 224)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(53, 13)
    Me.Label6.TabIndex = 489
    Me.Label6.Text = "License 5"
    '
    'TxtCoLic5
    '
    Me.TxtCoLic5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCoLic5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCoLic5.Location = New System.Drawing.Point(112, 220)
    Me.TxtCoLic5.MaxLength = 25
    Me.TxtCoLic5.Name = "TxtCoLic5"
    Me.TxtCoLic5.Size = New System.Drawing.Size(209, 22)
    Me.TxtCoLic5.TabIndex = 10
    '
    'FrmBD103C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(506, 254)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.TxtCoLic5)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtCoLic4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtCoLic3)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtCoLic2)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label19)
    Me.Controls.Add(Me.Label20)
    Me.Controls.Add(Me.Label21)
    Me.Controls.Add(Me.Label22)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.LblCoID)
    Me.Controls.Add(Me.TxtCoCity)
    Me.Controls.Add(Me.TxtCoState)
    Me.Controls.Add(Me.TxtCoZip)
    Me.Controls.Add(Me.TxtCoAddr)
    Me.Controls.Add(Me.TxtCoPhon)
    Me.Controls.Add(Me.TxtCoLic1)
    Me.Controls.Add(Me.TxtCoName)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmBD103C"
    Me.Text = "Maintain Contractor"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

  Private Sub FrmBD103C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myBDCON = New BDCON.mydata(MyDBConnect)
  MyFrmBD103.TBarNew.Enabled = False
  MyFrmBD103.TBarSave.Enabled = True
  If Not WrkAddMode Then
    MyFrmBD103.TBarDelete.Enabled = True
  Else
    Exit Sub
  End If

  MyFrmBD103.TBarPrint.Enabled = False
  myBDCON.GetOneRecordP(WrkRecID)
  LblCoID.Text = WrkRecID
  If myBDCON.RecordNotFound Then Exit Sub
    With myBDCON
      TxtCoName.Text = Trim(._CONAME)
      TxtCoAddr.Text = Trim(._COADD1)
      TxtCoCity.Text = Trim(._COCITY)
      TxtCoState.Text = Trim(._COST)
      TxtCoZip.Text = ._COZIP
      TxtCoPhon.Text = Trim(._COPHON)
      TxtCoLic1.Text = Trim(._COLIC1)
      TxtCoLic2.Text = Trim(._COLIC2)
      TxtCoLic3.Text = Trim(._COLIC3)
      TxtCoLic4.Text = Trim(._COLIC4)
      TxtCoLic5.Text = Trim(._COLIC5)
    End With
  End Sub

Private Sub FrmBD103C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmBD103.SbpScreen.Text = "BD103C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub FrmBD103C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmBD103.TBarNew.Enabled = True
  MyFrmBD103.TBarDelete.Enabled = False
  MyFrmBD103.TBarSave.Enabled = False
  MyFrmBD103.TBarPrint.Enabled = False
  MyFrmBD103B.FormatGrid()
  MyFrmBD103B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
  myBDCON.DeleteOneRecordP()
  Me.Close()
End Sub

  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    If Not WrkAddMode Then
      myBDCON.GetOneRecordP(LblCoID.Text)
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myBDCON.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      LblCoID.Text = myBDCON.AutoGenKey
      myBDCON.GetOneRecordP(LblCoID.Text)
      myBDCON._RECID = MyUtils.CnvSng(LblCoID.Text)
      myBDCON._PRF = Mid(MyUserID, 1, 10)
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myBDCON.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()
  End Sub
  Private Sub MovetoFile()
    With myBDCON
      ._CONAME = TxtCoName.Text
      ._COADD1 = TxtCoAddr.Text
      ._COCITY = TxtCoCity.Text
      ._COST = TxtCoState.Text
      ._COZIP = MyUtils.CnvSng(TxtCoZip.Text)
      ._COPHON = TxtCoPhon.Text
      ._COLIC1 = TxtCoLic1.Text
      ._COLIC2 = TxtCoLic2.Text
      ._COLIC3 = TxtCoLic3.Text
      ._COLIC4 = TxtCoLic4.Text
      ._COLIC5 = TxtCoLic5.Text
    End With
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If TxtCoName.Text = String.Empty Then
      ErrorField(I) = "name"
      ErrorMsg(I) = "Name is required"
      I = I + 1
    End If

End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtCoName, "")
  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
    Case "name"
      ErrProv.SetError(TxtCoName, ErrorMsg(I))
    Case Nothing
      Exit Sub
    End Select
  Next I
End Sub
End Class






