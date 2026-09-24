Public Class FrmGL505B
  Inherits System.Windows.Forms.Form
 Dim myGLHEAD As GLHEAD.myData
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
Friend WithEvents txtbudc3 As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents txtbudc4 As System.Windows.Forms.TextBox
Friend WithEvents txtbuda1 As System.Windows.Forms.TextBox
Friend WithEvents txtbudc1 As System.Windows.Forms.TextBox
Friend WithEvents txtbudc2 As System.Windows.Forms.TextBox
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents txtbudb4 As System.Windows.Forms.TextBox
Friend WithEvents txtbuda4 As System.Windows.Forms.TextBox
Friend WithEvents txtbudb3 As System.Windows.Forms.TextBox
Friend WithEvents txtbuda3 As System.Windows.Forms.TextBox
Friend WithEvents txtbudb2 As System.Windows.Forms.TextBox
Friend WithEvents txtbuda2 As System.Windows.Forms.TextBox
Friend WithEvents txtbudb1 As System.Windows.Forms.TextBox
Friend WithEvents Label13 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.label3 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.txtbudc3 = New System.Windows.Forms.TextBox()
    Me.txtbudc4 = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.txtbuda1 = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.txtbudc1 = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.txtbudc2 = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.txtbudb1 = New System.Windows.Forms.TextBox()
    Me.txtbuda2 = New System.Windows.Forms.TextBox()
    Me.txtbudb2 = New System.Windows.Forms.TextBox()
    Me.txtbuda3 = New System.Windows.Forms.TextBox()
    Me.txtbudb3 = New System.Windows.Forms.TextBox()
    Me.txtbuda4 = New System.Windows.Forms.TextBox()
    Me.txtbudb4 = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
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
    Me.Label1.Location = New System.Drawing.Point(33, 148)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(85, 16)
    Me.Label1.TabIndex = 7
    Me.Label1.Text = "Column 3"
    '
    'txtbudc3
    '
    Me.txtbudc3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtbudc3.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.txtbudc3.Location = New System.Drawing.Point(104, 145)
    Me.txtbudc3.MaxLength = 20
    Me.txtbudc3.Name = "txtbudc3"
    Me.txtbudc3.Size = New System.Drawing.Size(204, 22)
    Me.txtbudc3.TabIndex = 2
    '
    'txtbudc4
    '
    Me.txtbudc4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtbudc4.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.txtbudc4.Location = New System.Drawing.Point(104, 173)
    Me.txtbudc4.MaxLength = 20
    Me.txtbudc4.Name = "txtbudc4"
    Me.txtbudc4.Size = New System.Drawing.Size(204, 22)
    Me.txtbudc4.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(33, 176)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(85, 16)
    Me.Label2.TabIndex = 9
    Me.Label2.Text = "Column 4"
    '
    'txtbuda1
    '
    Me.txtbuda1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtbuda1.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.txtbuda1.Location = New System.Drawing.Point(332, 88)
    Me.txtbuda1.MaxLength = 5
    Me.txtbuda1.Name = "txtbuda1"
    Me.txtbuda1.Size = New System.Drawing.Size(58, 22)
    Me.txtbuda1.TabIndex = 4
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(329, 47)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(164, 24)
    Me.Label4.TabIndex = 11
    Me.Label4.Text = "Abbreviated Heading"
    '
    'txtbudc1
    '
    Me.txtbudc1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtbudc1.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.txtbudc1.Location = New System.Drawing.Point(104, 89)
    Me.txtbudc1.MaxLength = 20
    Me.txtbudc1.Name = "txtbudc1"
    Me.txtbudc1.Size = New System.Drawing.Size(204, 22)
    Me.txtbudc1.TabIndex = 0
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(33, 92)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(85, 16)
    Me.Label7.TabIndex = 17
    Me.Label7.Text = "Column 1"
    '
    'txtbudc2
    '
    Me.txtbudc2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtbudc2.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.txtbudc2.Location = New System.Drawing.Point(104, 117)
    Me.txtbudc2.MaxLength = 20
    Me.txtbudc2.Name = "txtbudc2"
    Me.txtbudc2.Size = New System.Drawing.Size(204, 22)
    Me.txtbudc2.TabIndex = 1
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(33, 120)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(85, 16)
    Me.Label13.TabIndex = 30
    Me.Label13.Text = "Column 2"
    '
    'txtbudb1
    '
    Me.txtbudb1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtbudb1.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.txtbudb1.Location = New System.Drawing.Point(417, 88)
    Me.txtbudb1.MaxLength = 5
    Me.txtbudb1.Name = "txtbudb1"
    Me.txtbudb1.Size = New System.Drawing.Size(58, 22)
    Me.txtbudb1.TabIndex = 54
    '
    'txtbuda2
    '
    Me.txtbuda2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtbuda2.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.txtbuda2.Location = New System.Drawing.Point(332, 116)
    Me.txtbuda2.MaxLength = 5
    Me.txtbuda2.Name = "txtbuda2"
    Me.txtbuda2.Size = New System.Drawing.Size(58, 22)
    Me.txtbuda2.TabIndex = 55
    '
    'txtbudb2
    '
    Me.txtbudb2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtbudb2.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.txtbudb2.Location = New System.Drawing.Point(417, 116)
    Me.txtbudb2.MaxLength = 5
    Me.txtbudb2.Name = "txtbudb2"
    Me.txtbudb2.Size = New System.Drawing.Size(58, 22)
    Me.txtbudb2.TabIndex = 56
    '
    'txtbuda3
    '
    Me.txtbuda3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtbuda3.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.txtbuda3.Location = New System.Drawing.Point(332, 144)
    Me.txtbuda3.MaxLength = 5
    Me.txtbuda3.Name = "txtbuda3"
    Me.txtbuda3.Size = New System.Drawing.Size(58, 22)
    Me.txtbuda3.TabIndex = 57
    '
    'txtbudb3
    '
    Me.txtbudb3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtbudb3.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.txtbudb3.Location = New System.Drawing.Point(417, 144)
    Me.txtbudb3.MaxLength = 5
    Me.txtbudb3.Name = "txtbudb3"
    Me.txtbudb3.Size = New System.Drawing.Size(58, 22)
    Me.txtbudb3.TabIndex = 58
    '
    'txtbuda4
    '
    Me.txtbuda4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtbuda4.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.txtbuda4.Location = New System.Drawing.Point(332, 172)
    Me.txtbuda4.MaxLength = 5
    Me.txtbuda4.Name = "txtbuda4"
    Me.txtbuda4.Size = New System.Drawing.Size(58, 22)
    Me.txtbuda4.TabIndex = 59
    '
    'txtbudb4
    '
    Me.txtbudb4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtbudb4.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.txtbudb4.Location = New System.Drawing.Point(417, 172)
    Me.txtbudb4.MaxLength = 5
    Me.txtbudb4.Name = "txtbudb4"
    Me.txtbudb4.Size = New System.Drawing.Size(58, 22)
    Me.txtbudb4.TabIndex = 60
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(101, 48)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(146, 24)
    Me.Label5.TabIndex = 61
    Me.Label5.Text = "Full Heading"
    '
    'FrmGL505B
    '
    Me.AllowDrop = True
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(504, 260)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.txtbudb4)
    Me.Controls.Add(Me.txtbuda4)
    Me.Controls.Add(Me.txtbudb3)
    Me.Controls.Add(Me.txtbuda3)
    Me.Controls.Add(Me.txtbudb2)
    Me.Controls.Add(Me.txtbuda2)
    Me.Controls.Add(Me.txtbudb1)
    Me.Controls.Add(Me.txtbudc2)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.txtbudc1)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.txtbuda1)
    Me.Controls.Add(Me.txtbudc4)
    Me.Controls.Add(Me.txtbudc3)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL505B"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub GL505B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 myGLHEAD = New GLHEAD.MyData()
 myGLHEAD.MyDBConn = myDBConnect
 With MyFrmGL505
  .TBarNew.Visible = False
  .TBarSave.Visible = True
  .TBarPrint.Visible = False
  .TBarDelete.Visible = False
 End With
 If s_chg = False And s_full = False Then    '#sec
  MyFrmGL505.TBarSave.Visible = False
 End If

 myGLHEAD.GetOneRecordP(0, 0)
 If myGLHEAD.RecordNotFound Then

   Exit Sub
 End If
 With myGLHEAD
  txtbudc1.Text = Trim(._BUDC1)
  txtbudc2.Text = Trim(._BUDC2)
  txtbudc3.Text = Trim(._BUDC3)
  txtbudc4.Text = Trim(._BUDC4)
  txtbuda1.Text = Trim(._BUDA1)
  txtbuda2.Text = Trim(._BUDA2)
  txtbuda3.Text = Trim(._BUDA3)
  txtbuda4.Text = Trim(._BUDA4)
  txtbudb1.Text = Trim(._BUDB1)
  txtbudb2.Text = Trim(._BUDB2)
  txtbudb3.Text = Trim(._BUDB3)
  txtbudb4.Text = Trim(._BUDB4)
 End With
End Sub
Private Sub GL505B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
 MyFrmGL505.SbpScreen.Text = "GL505B"
 MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Public Sub SaveData()
 Dim ErrorField(25) As String
 Dim ErrorMsg(25) As String
 myGLHEAD.GetOneRecordP(0, 0)
 MovetoFile()
 EditChecks(ErrorField, ErrorMsg)
 If IsNothing(ErrorMsg(0)) Then
  If myGLHEAD.RecordNotFound Then
   myGLHEAD.AddOneRecordP()
  Else

   myGLHEAD.UpdateOneRecordP()
  End If
 Else
  ShowError(ErrorField, ErrorMsg)
  Exit Sub
 End If
  Application.Exit()
  End Sub
Private Sub MovetoFile()
 With myGLHEAD
  
  ._BUDC1 = txtbudc1.Text
  ._BUDC2 = txtbudc2.Text
  ._BUDC3 = txtbudc3.Text
  ._BUDC4 = txtbudc4.Text
  ._BUDA1 = txtbuda1.Text
  ._BUDA2 = txtbuda2.Text
  ._BUDA3 = txtbuda3.Text
  ._BUDA4 = txtbuda4.Text
  ._BUDB1 = txtbudb1.Text
  ._BUDB2 = txtbudb2.Text
  ._BUDB3 = txtbudb3.Text
  ._BUDB4 = txtbudb4.Text

 End With
End Sub
 Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer

  For I = 0 To ErrorField.GetUpperBound(0)
   If IsNothing(ErrorField(I)) Then
    Exit For
   End If
  Next

  'If TxtFName.Text = String.Empty Then
  ' ErrorField(I) = "town"
  ' ErrorMsg(I) = "Town Name cannot be blank"
  ' I = I + 1
  'End If

 End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
 Dim I As Integer
 'ErrProv.SetError(TxtFName, "")
 For I = 0 To ErrorField.GetUpperBound(0)
   Select Case ErrorField(I)
    'Case "town"
    ' ErrProv.SetError(TxtFName, ErrorMsg(I))
    Case Nothing
     Exit Sub
   End Select
   Next I
End Sub

End Class
