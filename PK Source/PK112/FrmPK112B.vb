Public Class FrmPK112B
  Inherits System.Windows.Forms.Form
  Dim myPKCNTL As PKCNTL.MyData
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
  Friend WithEvents TxtLine2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtLine3 As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtLine1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtLine4 As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtLine5 As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents TxtDayDbl As System.Windows.Forms.TextBox
  Friend WithEvents TxtPayTo As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtSigned As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TxtTitle As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TxtTwname As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.label3 = New System.Windows.Forms.Label()
    Me.TxtLine1 = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtLine3 = New System.Windows.Forms.TextBox()
    Me.TxtLine2 = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtLine4 = New System.Windows.Forms.TextBox()
    Me.TxtLine5 = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtDayDbl = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtPayTo = New System.Windows.Forms.TextBox()
    Me.TxtTitle = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtSigned = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtTwname = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
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
    'TxtLine1
    '
    Me.TxtLine1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLine1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLine1.Location = New System.Drawing.Point(86, 30)
    Me.TxtLine1.MaxLength = 40
    Me.TxtLine1.Name = "TxtLine1"
    Me.TxtLine1.Size = New System.Drawing.Size(325, 22)
    Me.TxtLine1.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(13, 31)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(36, 13)
    Me.Label2.TabIndex = 9
    Me.Label2.Text = "Line 1"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(13, 59)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(36, 13)
    Me.Label4.TabIndex = 10
    Me.Label4.Text = "Line 2"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(13, 86)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(36, 13)
    Me.Label5.TabIndex = 11
    Me.Label5.Text = "Line 3"
    '
    'TxtLine3
    '
    Me.TxtLine3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLine3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLine3.Location = New System.Drawing.Point(86, 85)
    Me.TxtLine3.MaxLength = 40
    Me.TxtLine3.Name = "TxtLine3"
    Me.TxtLine3.Size = New System.Drawing.Size(325, 22)
    Me.TxtLine3.TabIndex = 3
    '
    'TxtLine2
    '
    Me.TxtLine2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLine2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLine2.Location = New System.Drawing.Point(86, 58)
    Me.TxtLine2.MaxLength = 40
    Me.TxtLine2.Name = "TxtLine2"
    Me.TxtLine2.Size = New System.Drawing.Size(325, 22)
    Me.TxtLine2.TabIndex = 2
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(13, 113)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(36, 13)
    Me.Label6.TabIndex = 14
    Me.Label6.Text = "Line 4"
    '
    'TxtLine4
    '
    Me.TxtLine4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLine4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLine4.Location = New System.Drawing.Point(86, 112)
    Me.TxtLine4.MaxLength = 40
    Me.TxtLine4.Name = "TxtLine4"
    Me.TxtLine4.Size = New System.Drawing.Size(325, 22)
    Me.TxtLine4.TabIndex = 4
    '
    'TxtLine5
    '
    Me.TxtLine5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLine5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLine5.Location = New System.Drawing.Point(86, 140)
    Me.TxtLine5.MaxLength = 40
    Me.TxtLine5.Name = "TxtLine5"
    Me.TxtLine5.Size = New System.Drawing.Size(325, 22)
    Me.TxtLine5.TabIndex = 5
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(13, 141)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(36, 13)
    Me.Label7.TabIndex = 16
    Me.Label7.Text = "Line 5"
    '
    'TxtDayDbl
    '
    Me.TxtDayDbl.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDayDbl.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtDayDbl.Location = New System.Drawing.Point(98, 256)
    Me.TxtDayDbl.MaxLength = 4
    Me.TxtDayDbl.Name = "TxtDayDbl"
    Me.TxtDayDbl.Size = New System.Drawing.Size(38, 22)
    Me.TxtDayDbl.TabIndex = 9
    Me.TxtDayDbl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(12, 260)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(80, 13)
    Me.Label9.TabIndex = 21
    Me.Label9.Text = "Days to Double"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(14, 6)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(41, 13)
    Me.Label1.TabIndex = 22
    Me.Label1.Text = "Pay To"
    '
    'TxtPayTo
    '
    Me.TxtPayTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPayTo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPayTo.Location = New System.Drawing.Point(86, 2)
    Me.TxtPayTo.MaxLength = 30
    Me.TxtPayTo.Name = "TxtPayTo"
    Me.TxtPayTo.Size = New System.Drawing.Size(247, 22)
    Me.TxtPayTo.TabIndex = 0
    '
    'TxtTitle
    '
    Me.TxtTitle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTitle.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTitle.Location = New System.Drawing.Point(86, 168)
    Me.TxtTitle.MaxLength = 25
    Me.TxtTitle.Name = "TxtTitle"
    Me.TxtTitle.Size = New System.Drawing.Size(218, 22)
    Me.TxtTitle.TabIndex = 6
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(14, 172)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(27, 13)
    Me.Label8.TabIndex = 24
    Me.Label8.Text = "Title"
    '
    'TxtSigned
    '
    Me.TxtSigned.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSigned.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSigned.Location = New System.Drawing.Point(85, 196)
    Me.TxtSigned.MaxLength = 30
    Me.TxtSigned.Name = "TxtSigned"
    Me.TxtSigned.Size = New System.Drawing.Size(248, 22)
    Me.TxtSigned.TabIndex = 7
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(13, 200)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(40, 13)
    Me.Label10.TabIndex = 26
    Me.Label10.Text = "Signed"
    '
    'TxtTwname
    '
    Me.TxtTwname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTwname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTwname.Location = New System.Drawing.Point(85, 227)
    Me.TxtTwname.MaxLength = 30
    Me.TxtTwname.Name = "TxtTwname"
    Me.TxtTwname.Size = New System.Drawing.Size(248, 22)
    Me.TxtTwname.TabIndex = 8
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(13, 231)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(65, 13)
    Me.Label11.TabIndex = 28
    Me.Label11.Text = "Town Name"
    '
    'FrmPK112B
    '
    Me.AllowDrop = True
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(422, 290)
    Me.ControlBox = False
    Me.Controls.Add(Me.TxtTwname)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.TxtSigned)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.TxtTitle)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.TxtPayTo)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtDayDbl)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.TxtLine5)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TxtLine4)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.TxtLine2)
    Me.Controls.Add(Me.TxtLine3)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtLine1)
    Me.Controls.Add(Me.label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmPK112B"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub PK112B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myPKCNTL = New PKCNTL.MyData(myDBConnect)
    MyFrmPK112.TBarNew.Visible = False
    MyFrmPK112.TBarSave.Visible = True
    MyFrmPK112.TBarPrint.Visible = False
    MyFrmPK112.TBarDelete.Visible = False
    myPKCNTL.GetOneRecordP("")
    If myPKCNTL.RecordNotFound Then Exit Sub
    If s_chg = False And s_full = False Then    '#sec
      MyFrmPK112.TBarSave.Visible = False
    End If
    With myPKCNTL
      TxtLine1.Text = Trim(._LINE1)
      TxtLine2.Text = Trim(._LINE2)
      TxtLine3.Text = Trim(._LINE3)
      TxtLine4.Text = Trim(._LINE4)
      TxtLine5.Text = Trim(._LINE5)
      TxtPayTo.Text = Trim(._PAYTO)
      TxtTitle.Text = Trim(._TITLE)
      TxtSigned.Text = Trim(._SIGNED)
      TxtTwname.Text = Trim(._TWNAME)
      TxtDayDbl.Text = ._DAYDBL
    End With
  End Sub
  Private Sub PK112B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmPK112.SbpScreen.Text = "PK112B"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub

  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    myPKCNTL.GetOneRecordP("")
    MovetoFile()
    ' added this too
    If myPKCNTL.RecordNotFound Then
      myPKCNTL.AddOneRecordP()
    Else
      myPKCNTL.UpdateOneRecordP()
    End If
    Me.Close()
  End Sub
  Private Sub MovetoFile()
    With myPKCNTL
      ._LINE1 = TxtLine1.Text
      ._LINE2 = TxtLine2.Text
      ._LINE3 = TxtLine3.Text
      ._LINE4 = TxtLine4.Text
      ._LINE5 = TxtLine5.Text
      ._PAYTO = TxtPayTo.Text
      ._TITLE = TxtTitle.Text
      ._SIGNED = TxtSigned.Text
      ._TWNAME = TxtTwname.Text
      ._DAYDBL = MyUtils.CnvSng(TxtDayDbl.Text)
      TxtDayDbl.Text = ._DAYDBL
    End With
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtDayDbl, "")
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "daydbl"
          ErrProv.SetError(TxtDayDbl, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub TxtDaydbl_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDayDbl.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
End Class
