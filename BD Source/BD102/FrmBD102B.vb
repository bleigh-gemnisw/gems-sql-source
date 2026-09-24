Public Class FrmBD102B
  Inherits System.Windows.Forms.Form
  Dim myBDCNTL As BDCNTL.myData
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
    Friend WithEvents label3 As System.Windows.Forms.Label
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TxtAddr1 As System.Windows.Forms.TextBox
Friend WithEvents TxtAddr2 As System.Windows.Forms.TextBox
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtName As System.Windows.Forms.TextBox
Friend WithEvents TxtPhone As System.Windows.Forms.TextBox
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents TxtFax As System.Windows.Forms.TextBox
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents TxtIrcYr As System.Windows.Forms.TextBox
Friend WithEvents Label9 As System.Windows.Forms.Label
Friend WithEvents TxtNecYr As System.Windows.Forms.TextBox
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents TxtPermNo As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.label3 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtPermNo = New System.Windows.Forms.TextBox()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtAddr2 = New System.Windows.Forms.TextBox()
    Me.TxtAddr1 = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtPhone = New System.Windows.Forms.TextBox()
    Me.TxtFax = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtNecYr = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtIrcYr = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'label3
    '
    Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label3.Location = New System.Drawing.Point(-100, 74)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(100, 23)
    Me.label3.TabIndex = 6
    Me.label3.Text = "New file name"
    Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(8, 145)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(69, 13)
    Me.Label1.TabIndex = 7
    Me.Label1.Text = "Last Permit #"
    '
    'TxtPermNo
    '
    Me.TxtPermNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPermNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtPermNo.Location = New System.Drawing.Point(83, 141)
    Me.TxtPermNo.MaxLength = 5
    Me.TxtPermNo.Name = "TxtPermNo"
    Me.TxtPermNo.Size = New System.Drawing.Size(48, 22)
    Me.TxtPermNo.TabIndex = 7
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(83, 5)
    Me.TxtName.MaxLength = 30
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(246, 22)
    Me.TxtName.TabIndex = 0
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(8, 9)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(61, 13)
    Me.Label2.TabIndex = 9
    Me.Label2.Text = "Dept Name"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(8, 37)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(45, 13)
    Me.Label4.TabIndex = 10
    Me.Label4.Text = "Address"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(8, 64)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(74, 13)
    Me.Label5.TabIndex = 11
    Me.Label5.Text = "City/State/Zip"
    '
    'TxtAddr2
    '
    Me.TxtAddr2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAddr2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAddr2.Location = New System.Drawing.Point(83, 60)
    Me.TxtAddr2.MaxLength = 40
    Me.TxtAddr2.Name = "TxtAddr2"
    Me.TxtAddr2.Size = New System.Drawing.Size(325, 22)
    Me.TxtAddr2.TabIndex = 2
    '
    'TxtAddr1
    '
    Me.TxtAddr1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAddr1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAddr1.Location = New System.Drawing.Point(83, 33)
    Me.TxtAddr1.MaxLength = 40
    Me.TxtAddr1.Name = "TxtAddr1"
    Me.TxtAddr1.Size = New System.Drawing.Size(325, 22)
    Me.TxtAddr1.TabIndex = 1
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(8, 91)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(38, 13)
    Me.Label6.TabIndex = 14
    Me.Label6.Text = "Phone"
    '
    'TxtPhone
    '
    Me.TxtPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPhone.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPhone.Location = New System.Drawing.Point(83, 87)
    Me.TxtPhone.MaxLength = 40
    Me.TxtPhone.Name = "TxtPhone"
    Me.TxtPhone.Size = New System.Drawing.Size(127, 22)
    Me.TxtPhone.TabIndex = 3
    '
    'TxtFax
    '
    Me.TxtFax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFax.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFax.Location = New System.Drawing.Point(260, 87)
    Me.TxtFax.MaxLength = 40
    Me.TxtFax.Name = "TxtFax"
    Me.TxtFax.Size = New System.Drawing.Size(127, 22)
    Me.TxtFax.TabIndex = 4
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(230, 91)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(24, 13)
    Me.Label7.TabIndex = 16
    Me.Label7.Text = "Fax"
    '
    'TxtNecYr
    '
    Me.TxtNecYr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtNecYr.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtNecYr.Location = New System.Drawing.Point(83, 115)
    Me.TxtNecYr.MaxLength = 4
    Me.TxtNecYr.Name = "TxtNecYr"
    Me.TxtNecYr.Size = New System.Drawing.Size(38, 22)
    Me.TxtNecYr.TabIndex = 5
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(8, 119)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(54, 13)
    Me.Label8.TabIndex = 19
    Me.Label8.Text = "NEC Year"
    '
    'TxtIrcYr
    '
    Me.TxtIrcYr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtIrcYr.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtIrcYr.Location = New System.Drawing.Point(260, 115)
    Me.TxtIrcYr.MaxLength = 4
    Me.TxtIrcYr.Name = "TxtIrcYr"
    Me.TxtIrcYr.Size = New System.Drawing.Size(38, 22)
    Me.TxtIrcYr.TabIndex = 6
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(200, 119)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(50, 13)
    Me.Label9.TabIndex = 21
    Me.Label9.Text = "IRC Year"
    '
    'FrmBD102B
    '
    Me.AllowDrop = True
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(413, 172)
    Me.ControlBox = False
    Me.Controls.Add(Me.TxtIrcYr)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.TxtNecYr)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.TxtFax)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TxtPhone)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.TxtAddr1)
    Me.Controls.Add(Me.TxtAddr2)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtName)
    Me.Controls.Add(Me.TxtPermNo)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmBD102B"
    Me.Text = "Utility Billing Control File"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub BD102B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myBDCNTL = New BDCNTL.mydata(MyDBConnect)
  MyFrmBD102.TBarNew.Visible = False
  MyFrmBD102.TBarSave.Visible = True
  MyFrmBD102.TBarPrint.Visible = False
  MyFrmBD102.TBarDelete.Visible = False
  myBDCNTL.GetOneRecordP("")
  If myBDCNTL.RecordNotFound Then Exit Sub
  If s_chg = False And s_full = False Then    '#sec
    MyFrmBD102.TBarSave.Visible = False
  End If
  With myBDCNTL
    TxtName.Text = Trim(._NAME)
    TxtAddr1.Text = Trim(._ADDR1)
    TxtAddr2.Text = Trim(._ADDR2)
    TxtPhone.Text = Trim(._PHONE)
    TxtFax.Text = Trim(._FAX)
    TxtNecYr.Text = ._NECYR
    TxtIrcYr.Text = ._IRCYR
    TxtPermNo.Text = ._LPERM
  End With
End Sub
Private Sub BD102B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmBD102.SbpScreen.Text = "BD102B"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  myBDCNTL.GetOneRecordP("")
  MovetoFile()
  ' added this too
  If myBDCNTL.RecordNotFound Then
    myBDCNTL.AddOneRecordP()
  Else
    myBDCNTL.UpdateOneRecordP()
  End If
  Me.Close()
  End Sub
Private Sub MovetoFile()
  With myBDCNTL
    ._NAME = TxtName.Text
    ._ADDR1 = TxtAddr1.Text
    ._ADDR2 = TxtAddr2.Text
    ._PHONE = TxtPhone.Text
    ._FAX = TxtFax.Text
    ._NECYR = MyUtils.CnvSng(TxtNecYr.Text)
    ._IRCYR = MyUtils.CnvSng(TxtIrcYr.Text)
    ._LPERM = MyUtils.CnvSng(TxtPermNo.Text)
  End With
End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtPermNo, "")
  For I = 0 To ErrorField.GetUpperBound(0)
     Select Case ErrorField(I)
       Case "permno"
         ErrProv.SetError(TxtPermNo, ErrorMsg(I))
       Case Nothing
       Exit Sub
     End Select
     Next I
End Sub

Private Sub TxtNecYr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNecYr.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtIrcYr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtIrcYr.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtPermNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPermNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






