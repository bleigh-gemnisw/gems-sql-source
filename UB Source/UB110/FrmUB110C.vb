Public Class FrmUB110C
  Inherits System.Windows.Forms.Form
  Dim myUTFMBILL As UTFMBILL.myData
  Dim myTXFMBILL As TXFMBILL.myData
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtPayTo As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents TxtPhone As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TxtHours2 As System.Windows.Forms.TextBox
  Friend Wrktype As String
  Friend WithEvents GrpDigit As System.Windows.Forms.GroupBox
  Friend WithEvents RbModWeight7 As System.Windows.Forms.RadioButton
  Friend WithEvents RbModEven As System.Windows.Forms.RadioButton
  Friend WithEvents RbModOdd As System.Windows.Forms.RadioButton
  Friend WithEvents GrpScan As System.Windows.Forms.GroupBox
  Friend WithEvents RbScanWebster As System.Windows.Forms.RadioButton
  Friend WithEvents RbScanDefault As System.Windows.Forms.RadioButton
  Friend WithEvents Label12 As System.Windows.Forms.Label
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
Friend WithEvents TxtLine1 As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtLine2 As System.Windows.Forms.TextBox
Friend WithEvents TxtLine3 As System.Windows.Forms.TextBox
Friend WithEvents TxtLine4 As System.Windows.Forms.TextBox
Friend WithEvents TxtLine5 As System.Windows.Forms.TextBox
Friend WithEvents TxtTitle As System.Windows.Forms.TextBox
Friend WithEvents TxtHours1 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Txttype = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.TxtLine1 = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.TxtLine2 = New System.Windows.Forms.TextBox
Me.TxtLine3 = New System.Windows.Forms.TextBox
Me.TxtLine4 = New System.Windows.Forms.TextBox
Me.TxtLine5 = New System.Windows.Forms.TextBox
Me.TxtTitle = New System.Windows.Forms.TextBox
Me.TxtHours1 = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.TxtPayTo = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.Label5 = New System.Windows.Forms.Label
Me.Label6 = New System.Windows.Forms.Label
Me.Label7 = New System.Windows.Forms.Label
Me.Label8 = New System.Windows.Forms.Label
Me.Label9 = New System.Windows.Forms.Label
Me.Label10 = New System.Windows.Forms.Label
Me.TxtHours2 = New System.Windows.Forms.TextBox
Me.Label11 = New System.Windows.Forms.Label
Me.TxtPhone = New System.Windows.Forms.TextBox
Me.GrpDigit = New System.Windows.Forms.GroupBox
Me.RbModWeight7 = New System.Windows.Forms.RadioButton
Me.RbModEven = New System.Windows.Forms.RadioButton
Me.RbModOdd = New System.Windows.Forms.RadioButton
Me.RbScanDefault = New System.Windows.Forms.RadioButton
Me.RbScanWebster = New System.Windows.Forms.RadioButton
Me.GrpScan = New System.Windows.Forms.GroupBox
Me.Label12 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GrpDigit.SuspendLayout()
Me.GrpScan.SuspendLayout()
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
'TxtLine1
'
Me.TxtLine1.Location = New System.Drawing.Point(160, 72)
Me.TxtLine1.MaxLength = 40
Me.TxtLine1.Name = "TxtLine1"
Me.TxtLine1.Size = New System.Drawing.Size(459, 20)
Me.TxtLine1.TabIndex = 2
'
'Label2
'
Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label2.Location = New System.Drawing.Point(36, 72)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(120, 20)
Me.Label2.TabIndex = 3
Me.Label2.Text = "Line 1"
Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'TxtLine2
'
Me.TxtLine2.Location = New System.Drawing.Point(160, 98)
Me.TxtLine2.MaxLength = 40
Me.TxtLine2.Name = "TxtLine2"
Me.TxtLine2.Size = New System.Drawing.Size(459, 20)
Me.TxtLine2.TabIndex = 3
'
'TxtLine3
'
Me.TxtLine3.Location = New System.Drawing.Point(160, 126)
Me.TxtLine3.MaxLength = 40
Me.TxtLine3.Name = "TxtLine3"
Me.TxtLine3.Size = New System.Drawing.Size(459, 20)
Me.TxtLine3.TabIndex = 4
'
'TxtLine4
'
Me.TxtLine4.Location = New System.Drawing.Point(160, 154)
Me.TxtLine4.MaxLength = 40
Me.TxtLine4.Name = "TxtLine4"
Me.TxtLine4.Size = New System.Drawing.Size(459, 20)
Me.TxtLine4.TabIndex = 5
'
'TxtLine5
'
Me.TxtLine5.Location = New System.Drawing.Point(160, 182)
Me.TxtLine5.MaxLength = 40
Me.TxtLine5.Name = "TxtLine5"
Me.TxtLine5.Size = New System.Drawing.Size(459, 20)
Me.TxtLine5.TabIndex = 6
'
'TxtTitle
'
Me.TxtTitle.Location = New System.Drawing.Point(160, 210)
Me.TxtTitle.MaxLength = 25
Me.TxtTitle.Name = "TxtTitle"
Me.TxtTitle.Size = New System.Drawing.Size(303, 20)
Me.TxtTitle.TabIndex = 7
'
'TxtHours1
'
Me.TxtHours1.Location = New System.Drawing.Point(160, 238)
Me.TxtHours1.MaxLength = 60
Me.TxtHours1.Multiline = True
Me.TxtHours1.Name = "TxtHours1"
Me.TxtHours1.Size = New System.Drawing.Size(336, 32)
Me.TxtHours1.TabIndex = 8
'
'Label3
'
Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label3.Location = New System.Drawing.Point(36, 46)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(120, 20)
Me.Label3.TabIndex = 19
Me.Label3.Text = "Pay to"
Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'TxtPayTo
'
Me.TxtPayTo.Location = New System.Drawing.Point(160, 46)
Me.TxtPayTo.MaxLength = 30
Me.TxtPayTo.Name = "TxtPayTo"
Me.TxtPayTo.Size = New System.Drawing.Size(336, 20)
Me.TxtPayTo.TabIndex = 1
'
'Label4
'
Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label4.Location = New System.Drawing.Point(36, 98)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(120, 20)
Me.Label4.TabIndex = 20
Me.Label4.Text = "Line 2"
Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label5
'
Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label5.Location = New System.Drawing.Point(36, 126)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(120, 20)
Me.Label5.TabIndex = 21
Me.Label5.Text = "Line 3"
Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label6
'
Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label6.Location = New System.Drawing.Point(36, 154)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(120, 20)
Me.Label6.TabIndex = 22
Me.Label6.Text = "Line 4"
Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label7
'
Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label7.Location = New System.Drawing.Point(36, 182)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(120, 20)
Me.Label7.TabIndex = 23
Me.Label7.Text = "Line 5"
Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label8
'
Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label8.Location = New System.Drawing.Point(36, 209)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(120, 20)
Me.Label8.TabIndex = 24
Me.Label8.Text = "Collector Title"
Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label9
'
Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label9.Location = New System.Drawing.Point(36, 237)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(120, 20)
Me.Label9.TabIndex = 25
Me.Label9.Text = "Office Hours 1"
Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label10
'
Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label10.Location = New System.Drawing.Point(36, 275)
Me.Label10.Name = "Label10"
Me.Label10.Size = New System.Drawing.Size(120, 20)
Me.Label10.TabIndex = 27
Me.Label10.Text = "Office Hours 2"
Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'TxtHours2
'
Me.TxtHours2.Location = New System.Drawing.Point(162, 276)
Me.TxtHours2.MaxLength = 60
Me.TxtHours2.Multiline = True
Me.TxtHours2.Name = "TxtHours2"
Me.TxtHours2.Size = New System.Drawing.Size(334, 32)
Me.TxtHours2.TabIndex = 9
'
'Label11
'
Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label11.Location = New System.Drawing.Point(38, 318)
Me.Label11.Name = "Label11"
Me.Label11.Size = New System.Drawing.Size(120, 20)
Me.Label11.TabIndex = 29
Me.Label11.Text = "Phone"
Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'TxtPhone
'
Me.TxtPhone.Location = New System.Drawing.Point(162, 318)
Me.TxtPhone.MaxLength = 15
Me.TxtPhone.Name = "TxtPhone"
Me.TxtPhone.Size = New System.Drawing.Size(183, 20)
Me.TxtPhone.TabIndex = 10
'
'GrpDigit
'
Me.GrpDigit.Controls.Add(Me.RbModWeight7)
Me.GrpDigit.Controls.Add(Me.RbModEven)
Me.GrpDigit.Controls.Add(Me.RbModOdd)
Me.GrpDigit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GrpDigit.Location = New System.Drawing.Point(322, 376)
Me.GrpDigit.Name = "GrpDigit"
Me.GrpDigit.Size = New System.Drawing.Size(321, 51)
Me.GrpDigit.TabIndex = 36
Me.GrpDigit.TabStop = False
Me.GrpDigit.Text = "OCR Check Digit - Modulus 10 Calc Method"
'
'RbModWeight7
'
Me.RbModWeight7.AutoSize = True
Me.RbModWeight7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbModWeight7.Location = New System.Drawing.Point(229, 19)
Me.RbModWeight7.Name = "RbModWeight7"
Me.RbModWeight7.Size = New System.Drawing.Size(86, 17)
Me.RbModWeight7.TabIndex = 35
Me.RbModWeight7.Text = "Weight 7,3,1"
Me.RbModWeight7.UseVisualStyleBackColor = True
'
'RbModEven
'
Me.RbModEven.AutoSize = True
Me.RbModEven.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbModEven.Location = New System.Drawing.Point(109, 19)
Me.RbModEven.Name = "RbModEven"
Me.RbModEven.Size = New System.Drawing.Size(87, 17)
Me.RbModEven.TabIndex = 34
Me.RbModEven.Text = "Double Even"
Me.RbModEven.UseVisualStyleBackColor = True
'
'RbModOdd
'
Me.RbModOdd.AutoSize = True
Me.RbModOdd.Checked = True
Me.RbModOdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbModOdd.Location = New System.Drawing.Point(6, 19)
Me.RbModOdd.Name = "RbModOdd"
Me.RbModOdd.Size = New System.Drawing.Size(82, 17)
Me.RbModOdd.TabIndex = 33
Me.RbModOdd.TabStop = True
Me.RbModOdd.Text = "Double Odd"
Me.RbModOdd.UseVisualStyleBackColor = True
'
'RbScanDefault
'
Me.RbScanDefault.AutoSize = True
Me.RbScanDefault.Checked = True
Me.RbScanDefault.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbScanDefault.Location = New System.Drawing.Point(6, 19)
Me.RbScanDefault.Name = "RbScanDefault"
Me.RbScanDefault.Size = New System.Drawing.Size(59, 17)
Me.RbScanDefault.TabIndex = 33
Me.RbScanDefault.TabStop = True
Me.RbScanDefault.Text = "Default"
Me.RbScanDefault.UseVisualStyleBackColor = True
'
'RbScanWebster
'
Me.RbScanWebster.AutoSize = True
Me.RbScanWebster.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbScanWebster.Location = New System.Drawing.Point(94, 19)
Me.RbScanWebster.Name = "RbScanWebster"
Me.RbScanWebster.Size = New System.Drawing.Size(65, 17)
Me.RbScanWebster.TabIndex = 34
Me.RbScanWebster.Text = "Webster"
Me.RbScanWebster.UseVisualStyleBackColor = True
'
'GrpScan
'
Me.GrpScan.Controls.Add(Me.RbScanWebster)
Me.GrpScan.Controls.Add(Me.RbScanDefault)
Me.GrpScan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GrpScan.Location = New System.Drawing.Point(12, 376)
Me.GrpScan.Name = "GrpScan"
Me.GrpScan.Size = New System.Drawing.Size(174, 51)
Me.GrpScan.TabIndex = 35
Me.GrpScan.TabStop = False
Me.GrpScan.Text = "OCR Scanline Format"
'
'Label12
'
Me.Label12.AutoSize = True
Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label12.Location = New System.Drawing.Point(116, 351)
Me.Label12.Name = "Label12"
Me.Label12.Size = New System.Drawing.Size(498, 16)
Me.Label12.TabIndex = 37
Me.Label12.Text = "*** From Collector Menu/Tables/Tax Form - Bill Info (DOES NOT SAVE BELOW) ***"
'
'FrmUB110C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(666, 437)
Me.Controls.Add(Me.Label12)
Me.Controls.Add(Me.GrpDigit)
Me.Controls.Add(Me.GrpScan)
Me.Controls.Add(Me.Label11)
Me.Controls.Add(Me.TxtPhone)
Me.Controls.Add(Me.Label10)
Me.Controls.Add(Me.TxtHours2)
Me.Controls.Add(Me.Label9)
Me.Controls.Add(Me.Label8)
Me.Controls.Add(Me.Label7)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.TxtPayTo)
Me.Controls.Add(Me.TxtHours1)
Me.Controls.Add(Me.TxtTitle)
Me.Controls.Add(Me.TxtLine5)
Me.Controls.Add(Me.TxtLine4)
Me.Controls.Add(Me.TxtLine3)
Me.Controls.Add(Me.TxtLine2)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.TxtLine1)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.Txttype)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmUB110C"
Me.Text = "Maintain Bill Information"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GrpDigit.ResumeLayout(False)
Me.GrpDigit.PerformLayout()
Me.GrpScan.ResumeLayout(False)
Me.GrpScan.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

  Private Sub FrmUB110C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myUTFMBILL = New UTFMBILL.mydata(MyDBConnect)
  myTXFMBILL = New TXFMBILL.mydata(MyDBConnect)
  MyFrmUB110.TBarNew.Enabled = False
  MyFrmUB110.TBarSave.Enabled = True
  If Not WrkAddMode Then
    MyFrmUB110.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(Txttype)
  Else
    Exit Sub
  End If
  MyFrmUB110.TBarPrint.Enabled = False

  myUTFMBILL.GetOneRecordP(Wrktype)
  Txttype.Text = Wrktype
  If Not myUTFMBILL.RecordNotFound Then
    With myUTFMBILL
      TxtPayTo.Text = Trim(._PAYTO)
      TxtLine1.Text = Trim(._LINE1)
      TxtLine2.Text = Trim(._LINE2)
      TxtLine3.Text = Trim(._LINE3)
      TxtLine4.Text = Trim(._LINE4)
      TxtLine5.Text = Trim(._LINE5)
      TxtTitle.Text = Trim(._TITLE)
      TxtHours1.Text = Trim(._HOURS1)
      TxtHours2.Text = Trim(._HOURS2)
      TxtPhone.Text = Trim(._PHONE)
    End With
  End If

  GrpScan.BackColor = Color.Aqua
  GrpDigit.BackColor = Color.Aqua
  myTXFMBILL.GetOneRecordP(Wrktype)
  If myTXFMBILL.RecordNotFound Then Exit Sub
  With myTXFMBILL
    Select Case Trim(._SCAN)
    Case "W"
      RbScanWebster.Checked = True
    Case Else
      RbScanDefault.Checked = True
    End Select
    Select Case Trim(._MOD10)
    Case "E"
      RbModEven.Checked = True
    Case "O"
      RbModOdd.Checked = True
    Case "7"
      RbModWeight7.Checked = True
    End Select
  End With
 End Sub

Private Sub FrmUB110C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB110.SbpScreen.Text = "UB110C"
  MyUtils.CenterForm(Me.ParentForm, Me)
    If Wrktype <> "" Then
    End If
End Sub

Private Sub FrmUB110C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmUB110.TBarNew.Enabled = True
  MyFrmUB110.TBarDelete.Enabled = False
  MyFrmUB110.TBarSave.Enabled = False
  MyFrmUB110.TBarPrint.Enabled = False
  MyFrmUB110B.FormatGrid()
  MyFrmUB110B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
  myUTFMBILL.DeleteOneRecordP()
  Me.Close()
End Sub

Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  myUTFMBILL.GetOneRecordP(Txttype.Text)
  If WrkAddMode Then
    If Not myUTFMBILL.RecordNotFound Then
      Me.ErrProv.SetError(Txttype, "Record already exists")
      Exit Sub
    End If
  End If
  If Not WrkAddMode Then
    MovetoFile()
    If IsNothing(ErrorMsg(0)) Then
      myUTFMBILL.UpdateOneRecordP()
      Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  Else
    myUTFMBILL._TYPE = Txttype.Text
    MovetoFile()
    If IsNothing(ErrorMsg(0)) Then
      myUTFMBILL.AddOneRecordP()
      Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myUTFMBILL
    ._PAYTO = TxtPayTo.Text
    ._LINE1 = TxtLine1.Text
    ._LINE2 = TxtLine2.Text
    ._LINE3 = TxtLine3.Text
    ._LINE4 = TxtLine4.Text
    ._LINE5 = TxtLine5.Text
    ._TITLE = TxtTitle.Text
    ._HOURS1 = TxtHours1.Text
    ._HOURS2 = TxtHours2.Text
    ._PHONE = TxtPhone.Text
 End With
 End Sub

 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(Txttype, "")
  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
      Case "type"
      ErrProv.SetError(Txttype, ErrorMsg(I))
    Case Nothing
      Exit Sub
    End Select
  Next I
End Sub
End Class






