Public Class FrmPO101C
  Inherits System.Windows.Forms.Form
  Dim myLOCATN As LOCATN.myData
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbNoMsg As System.Windows.Forms.RadioButton
  Friend WithEvents RbCrit As System.Windows.Forms.RadioButton
  Friend WithEvents RbWarn As System.Windows.Forms.RadioButton
  Friend WithEvents TxtRzipe As System.Windows.Forms.TextBox
  Friend WithEvents TxtRzip As System.Windows.Forms.TextBox
  Friend WithEvents TxtRadr4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtRadr3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtRadr2 As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtRadr1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtSzipe As System.Windows.Forms.TextBox
  Friend WithEvents TxtSzip As System.Windows.Forms.TextBox
  Friend WithEvents TxtSadr4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtSadr3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtSadr2 As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtSadr1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtRname As System.Windows.Forms.TextBox
  Friend WithEvents TxtSname As System.Windows.Forms.TextBox
  Friend WrkLlocn As String
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
  Friend WithEvents TxtLdesc As System.Windows.Forms.TextBox
  Friend WithEvents TxtLlocn As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtLdesc = New System.Windows.Forms.TextBox()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtLlocn = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbNoMsg = New System.Windows.Forms.RadioButton()
    Me.RbCrit = New System.Windows.Forms.RadioButton()
    Me.RbWarn = New System.Windows.Forms.RadioButton()
    Me.TxtSzipe = New System.Windows.Forms.TextBox()
    Me.TxtSzip = New System.Windows.Forms.TextBox()
    Me.TxtSadr4 = New System.Windows.Forms.TextBox()
    Me.TxtSadr3 = New System.Windows.Forms.TextBox()
    Me.TxtSadr2 = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtSadr1 = New System.Windows.Forms.TextBox()
    Me.TxtRzipe = New System.Windows.Forms.TextBox()
    Me.TxtRzip = New System.Windows.Forms.TextBox()
    Me.TxtRadr4 = New System.Windows.Forms.TextBox()
    Me.TxtRadr3 = New System.Windows.Forms.TextBox()
    Me.TxtRadr2 = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtRadr1 = New System.Windows.Forms.TextBox()
    Me.TxtSname = New System.Windows.Forms.TextBox()
    Me.TxtRname = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(120, 15)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(60, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Description"
    '
    'TxtLdesc
    '
    Me.TxtLdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLdesc.Location = New System.Drawing.Point(186, 12)
    Me.TxtLdesc.MaxLength = 30
    Me.TxtLdesc.Name = "TxtLdesc"
    Me.TxtLdesc.Size = New System.Drawing.Size(282, 20)
    Me.TxtLdesc.TabIndex = 1
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtLlocn
    '
    Me.TxtLlocn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLlocn.Location = New System.Drawing.Point(66, 12)
    Me.TxtLlocn.MaxLength = 4
    Me.TxtLlocn.Name = "TxtLlocn"
    Me.TxtLlocn.Size = New System.Drawing.Size(36, 20)
    Me.TxtLlocn.TabIndex = 0
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 15)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(48, 13)
    Me.Label2.TabIndex = 30
    Me.Label2.Text = "Location"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbNoMsg)
    Me.GroupBox1.Controls.Add(Me.RbCrit)
    Me.GroupBox1.Controls.Add(Me.RbWarn)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(15, 192)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(309, 45)
    Me.GroupBox1.TabIndex = 16
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Over-Expenditure Error Message"
    '
    'RbNoMsg
    '
    Me.RbNoMsg.AutoSize = True
    Me.RbNoMsg.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbNoMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbNoMsg.Location = New System.Drawing.Point(209, 19)
    Me.RbNoMsg.Name = "RbNoMsg"
    Me.RbNoMsg.Size = New System.Drawing.Size(85, 17)
    Me.RbNoMsg.TabIndex = 2
    Me.RbNoMsg.Text = "No Message"
    Me.RbNoMsg.UseVisualStyleBackColor = True
    '
    'RbCrit
    '
    Me.RbCrit.AutoSize = True
    Me.RbCrit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbCrit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCrit.Location = New System.Drawing.Point(111, 19)
    Me.RbCrit.Name = "RbCrit"
    Me.RbCrit.Size = New System.Drawing.Size(56, 17)
    Me.RbCrit.TabIndex = 1
    Me.RbCrit.Text = "Critical"
    Me.RbCrit.UseVisualStyleBackColor = True
    '
    'RbWarn
    '
    Me.RbWarn.AutoSize = True
    Me.RbWarn.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbWarn.Checked = True
    Me.RbWarn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbWarn.Location = New System.Drawing.Point(6, 19)
    Me.RbWarn.Name = "RbWarn"
    Me.RbWarn.Size = New System.Drawing.Size(65, 17)
    Me.RbWarn.TabIndex = 0
    Me.RbWarn.TabStop = True
    Me.RbWarn.Text = "Warning"
    Me.RbWarn.UseVisualStyleBackColor = True
    '
    'TxtSzipe
    '
    Me.TxtSzipe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSzipe.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSzipe.Location = New System.Drawing.Point(293, 148)
    Me.TxtSzipe.MaxLength = 4
    Me.TxtSzipe.Name = "TxtSzipe"
    Me.TxtSzipe.Size = New System.Drawing.Size(41, 22)
    Me.TxtSzipe.TabIndex = 8
    '
    'TxtSzip
    '
    Me.TxtSzip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSzip.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSzip.Location = New System.Drawing.Point(236, 148)
    Me.TxtSzip.MaxLength = 5
    Me.TxtSzip.Name = "TxtSzip"
    Me.TxtSzip.Size = New System.Drawing.Size(51, 22)
    Me.TxtSzip.TabIndex = 7
    '
    'TxtSadr4
    '
    Me.TxtSadr4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSadr4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSadr4.Location = New System.Drawing.Point(65, 148)
    Me.TxtSadr4.MaxLength = 20
    Me.TxtSadr4.Name = "TxtSadr4"
    Me.TxtSadr4.Size = New System.Drawing.Size(165, 22)
    Me.TxtSadr4.TabIndex = 6
    '
    'TxtSadr3
    '
    Me.TxtSadr3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSadr3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSadr3.Location = New System.Drawing.Point(65, 126)
    Me.TxtSadr3.MaxLength = 20
    Me.TxtSadr3.Name = "TxtSadr3"
    Me.TxtSadr3.Size = New System.Drawing.Size(165, 22)
    Me.TxtSadr3.TabIndex = 5
    '
    'TxtSadr2
    '
    Me.TxtSadr2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSadr2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSadr2.Location = New System.Drawing.Point(65, 104)
    Me.TxtSadr2.MaxLength = 20
    Me.TxtSadr2.Name = "TxtSadr2"
    Me.TxtSadr2.Size = New System.Drawing.Size(165, 22)
    Me.TxtSadr2.TabIndex = 4
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.ForeColor = System.Drawing.Color.Black
    Me.Label3.Location = New System.Drawing.Point(12, 64)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(47, 13)
    Me.Label3.TabIndex = 200
    Me.Label3.Text = "Ship To:"
    '
    'TxtSadr1
    '
    Me.TxtSadr1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSadr1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSadr1.Location = New System.Drawing.Point(65, 82)
    Me.TxtSadr1.MaxLength = 20
    Me.TxtSadr1.Name = "TxtSadr1"
    Me.TxtSadr1.Size = New System.Drawing.Size(165, 22)
    Me.TxtSadr1.TabIndex = 3
    '
    'TxtRzipe
    '
    Me.TxtRzipe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRzipe.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRzipe.Location = New System.Drawing.Point(614, 148)
    Me.TxtRzipe.MaxLength = 4
    Me.TxtRzipe.Name = "TxtRzipe"
    Me.TxtRzipe.Size = New System.Drawing.Size(41, 22)
    Me.TxtRzipe.TabIndex = 15
    '
    'TxtRzip
    '
    Me.TxtRzip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRzip.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRzip.Location = New System.Drawing.Point(557, 148)
    Me.TxtRzip.MaxLength = 5
    Me.TxtRzip.Name = "TxtRzip"
    Me.TxtRzip.Size = New System.Drawing.Size(51, 22)
    Me.TxtRzip.TabIndex = 14
    '
    'TxtRadr4
    '
    Me.TxtRadr4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRadr4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRadr4.Location = New System.Drawing.Point(386, 148)
    Me.TxtRadr4.MaxLength = 20
    Me.TxtRadr4.Name = "TxtRadr4"
    Me.TxtRadr4.Size = New System.Drawing.Size(165, 22)
    Me.TxtRadr4.TabIndex = 13
    '
    'TxtRadr3
    '
    Me.TxtRadr3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRadr3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRadr3.Location = New System.Drawing.Point(386, 126)
    Me.TxtRadr3.MaxLength = 20
    Me.TxtRadr3.Name = "TxtRadr3"
    Me.TxtRadr3.Size = New System.Drawing.Size(165, 22)
    Me.TxtRadr3.TabIndex = 12
    '
    'TxtRadr2
    '
    Me.TxtRadr2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRadr2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRadr2.Location = New System.Drawing.Point(386, 104)
    Me.TxtRadr2.MaxLength = 20
    Me.TxtRadr2.Name = "TxtRadr2"
    Me.TxtRadr2.Size = New System.Drawing.Size(165, 22)
    Me.TxtRadr2.TabIndex = 11
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.ForeColor = System.Drawing.Color.Black
    Me.Label4.Location = New System.Drawing.Point(330, 64)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(39, 13)
    Me.Label4.TabIndex = 207
    Me.Label4.Text = "Bill To:"
    '
    'TxtRadr1
    '
    Me.TxtRadr1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRadr1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRadr1.Location = New System.Drawing.Point(386, 82)
    Me.TxtRadr1.MaxLength = 20
    Me.TxtRadr1.Name = "TxtRadr1"
    Me.TxtRadr1.Size = New System.Drawing.Size(165, 22)
    Me.TxtRadr1.TabIndex = 10
    '
    'TxtSname
    '
    Me.TxtSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSname.Location = New System.Drawing.Point(65, 60)
    Me.TxtSname.MaxLength = 25
    Me.TxtSname.Name = "TxtSname"
    Me.TxtSname.Size = New System.Drawing.Size(165, 22)
    Me.TxtSname.TabIndex = 2
    '
    'TxtRname
    '
    Me.TxtRname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRname.Location = New System.Drawing.Point(386, 60)
    Me.TxtRname.MaxLength = 25
    Me.TxtRname.Name = "TxtRname"
    Me.TxtRname.Size = New System.Drawing.Size(165, 22)
    Me.TxtRname.TabIndex = 9
    '
    'FrmPO101C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(668, 249)
    Me.Controls.Add(Me.TxtRname)
    Me.Controls.Add(Me.TxtSname)
    Me.Controls.Add(Me.TxtRzipe)
    Me.Controls.Add(Me.TxtRzip)
    Me.Controls.Add(Me.TxtRadr4)
    Me.Controls.Add(Me.TxtRadr3)
    Me.Controls.Add(Me.TxtRadr2)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtRadr1)
    Me.Controls.Add(Me.TxtSzipe)
    Me.Controls.Add(Me.TxtSzip)
    Me.Controls.Add(Me.TxtSadr4)
    Me.Controls.Add(Me.TxtSadr3)
    Me.Controls.Add(Me.TxtSadr2)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtSadr1)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtLlocn)
    Me.Controls.Add(Me.TxtLdesc)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmPO101C"
    Me.Text = "Maintain Location"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmPO101C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myLOCATN = New LOCATN.MyData()
    myLOCATN.MyDBConn = myDBConnect
    MyFrmPO101.TBarNew.Enabled = False
    MyFrmPO101.TBarSave.Enabled = True
    MyFrmPO101.TBarPrint.Enabled = False
    If WrkLlocn <> "" Then
      MyFrmPO101.TBarDelete.Enabled = True
      MyUtils.SetTxtReadOnly(TxtLlocn)
    End If
    If WrkLlocn = "" Then
      Me.Text = "Add " & Me.Text
      MyFrmPO101.TBarDelete.Enabled = False
      Exit Sub
    End If
    myLOCATN.GetOneRecordP(WrkLlocn)
    TxtLlocn.Text = WrkLlocn

    If myLOCATN.RecordNotFound Then
      MyFrmPO101.TBarNew.Enabled = False
      MyFrmPO101.TBarSave.Enabled = False
      MyFrmPO101.TBarDelete.Enabled = False
      Me.ErrProv.SetError(TxtLdesc, "Record not found")
      Exit Sub
    End If

    If s_chg = False And s_full = False Then    '#sec
      MyFrmPO101.TBarSave.Visible = False
    End If

    With myLOCATN
      TxtLdesc.Text = Trim(._LDESC)
      TxtRadr1.Text = Trim(._RADR1)
      TxtRadr2.Text = Trim(._RADR2)
      TxtRadr3.Text = Trim(._RADR3)
      TxtRadr4.Text = Trim(._RADR4)
      TxtRname.Text = Trim(._RNAME)
      TxtRzip.Text = Trim(._RZIP)
      TxtRzipe.Text = Trim(._RZIPE)
      TxtSadr1.Text = Trim(._SADR1)
      TxtSadr2.Text = Trim(._SADR2)
      TxtSadr3.Text = Trim(._SADR3)
      TxtSadr4.Text = Trim(._SADR4)
      TxtSname.Text = Trim(._SNAME)
      TxtSzip.Text = Trim(._SZIP)
      TxtSzipe.Text = Trim(._SZIPE)
      Select Case Trim(._EXERR)
        Case "C"
          RbCrit.Checked = True
        Case "W"
          RbWarn.Checked = True
        Case Else
          RbNoMsg.Checked = True
      End Select
    End With
  End Sub
  Private Sub FrmPO101C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmPO101.SbpScreen.Text = "PO101C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub

  Private Sub FrmPO101C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmPO101.TBarNew.Enabled = True
    MyFrmPO101.TBarDelete.Enabled = False
    MyFrmPO101.TBarSave.Enabled = False
    MyFrmPO101.TBarPrint.Enabled = False
    MyFrmPO101B.FormatGrid()
    MyFrmPO101B.Show()
  End Sub
  Public Sub DeleteData()
    Dim Answer As Integer
    Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
    If Answer = vbNo Then
      Exit Sub
    End If
    myLOCATN.DeleteOneRecordP()
    Me.Close()
  End Sub

  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    myLOCATN.GetOneRecordP(TxtLlocn.Text)
    If WrkLlocn = "" Then
      If Not myLOCATN.RecordNotFound Then
        Me.ErrProv.SetError(TxtLdesc, "Record already exists")
        Exit Sub
      End If
    End If
    If WrkLlocn <> "" Then
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myLOCATN.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      myLOCATN._LLOCN = TxtLlocn.Text
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myLOCATN.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()
  End Sub
  Private Sub MovetoFile()
    With myLOCATN
      ._LDESC = TxtLdesc.Text
      ._RADR1 = TxtRadr1.Text
      ._RADR2 = TxtRadr2.Text
      ._RADR3 = TxtRadr3.Text
      ._RADR4 = TxtRadr4.Text
      ._RNAME = TxtRname.Text
      ._RZIP = TxtRzip.Text
      ._RZIPE = TxtRzipe.Text
      ._SADR1 = TxtSadr1.Text
      ._SADR2 = TxtSadr2.Text
      ._SADR3 = TxtSadr3.Text
      ._SADR4 = TxtSadr4.Text
      ._SNAME = TxtSname.Text
      ._SZIP = TxtSzip.Text
      ._SZIPE = TxtSzipe.Text
      ._EXERR = ""
      If RbWarn.Checked Then ._EXERR = "W"
      If RbCrit.Checked Then ._EXERR = "C"
    End With
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If TxtLlocn.Text = String.Empty Then
      ErrorField(I) = "object"
      ErrorMsg(I) = "Object is required"
      I = I + 1
    End If

    If TxtLdesc.Text = String.Empty Then
      ErrorField(I) = "desc"
      ErrorMsg(I) = "Description is required"
      I = I + 1
    End If

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtLdesc, "")
    ErrProv.SetError(TxtLlocn, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "desc"
          ErrProv.SetError(TxtLdesc, ErrorMsg(I))
        Case "object"
          ErrProv.SetError(TxtLlocn, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
End Class
