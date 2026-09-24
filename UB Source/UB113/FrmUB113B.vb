Public Class FrmUB113B
  Inherits System.Windows.Forms.Form
  Dim myUTMUSER As UTMUSER.MyData
  Friend WithEvents TxtUser3 As TextBox
  Friend WithEvents Label4 As Label
  Friend WithEvents TxtUser2 As TextBox
  Friend WithEvents Label2 As Label
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
  Friend WithEvents TxtUser1 As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.label3 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtUser1 = New System.Windows.Forms.TextBox()
    Me.TxtUser2 = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtUser3 = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
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
    Me.Label1.Location = New System.Drawing.Point(21, 20)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(75, 13)
    Me.Label1.TabIndex = 7
    Me.Label1.Text = "User 1 Charge"
    '
    'TxtUser1
    '
    Me.TxtUser1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUser1.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtUser1.Location = New System.Drawing.Point(102, 16)
    Me.TxtUser1.MaxLength = 10
    Me.TxtUser1.Name = "TxtUser1"
    Me.TxtUser1.Size = New System.Drawing.Size(92, 22)
    Me.TxtUser1.TabIndex = 1
    '
    'TxtUser2
    '
    Me.TxtUser2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUser2.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtUser2.Location = New System.Drawing.Point(102, 42)
    Me.TxtUser2.MaxLength = 10
    Me.TxtUser2.Name = "TxtUser2"
    Me.TxtUser2.Size = New System.Drawing.Size(92, 22)
    Me.TxtUser2.TabIndex = 8
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(21, 46)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(75, 13)
    Me.Label2.TabIndex = 9
    Me.Label2.Text = "User 2 Charge"
    '
    'TxtUser3
    '
    Me.TxtUser3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUser3.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtUser3.Location = New System.Drawing.Point(102, 67)
    Me.TxtUser3.MaxLength = 10
    Me.TxtUser3.Name = "TxtUser3"
    Me.TxtUser3.Size = New System.Drawing.Size(92, 22)
    Me.TxtUser3.TabIndex = 10
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(21, 71)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(75, 13)
    Me.Label4.TabIndex = 11
    Me.Label4.Text = "User 3 Charge"
    '
    'FrmUB113B
    '
    Me.AllowDrop = True
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(236, 111)
    Me.ControlBox = False
    Me.Controls.Add(Me.TxtUser3)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtUser2)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtUser1)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmUB113B"
    Me.Text = "Maintain Meter User Charge Descriptions"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub UB113B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myUTMUSER = New UTMUSER.MyData(myDBConnect)
    MyFrmUB113.TBarNew.Visible = False
    MyFrmUB113.TBarSave.Visible = True
    MyFrmUB113.TBarPrint.Visible = False
    MyFrmUB113.TBarDelete.Visible = False
    myUTMUSER.GetOneRecordP(1)
    If myUTMUSER.RecordNotFound Then Exit Sub
    If s_chg = False And s_full = False Then    '#sec
      MyFrmUB113.TBarSave.Visible = False
    End If
    With myUTMUSER
      TxtUser1.Text = Trim(._USER1)
      TxtUser2.Text = Trim(._USER2)
      TxtUser3.Text = Trim(._USER3)
    End With
  End Sub
  Private Sub UB113B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmUB113.SbpScreen.Text = "UB113B"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub

  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    myUTMUSER.GetOneRecordP(1)
    MovetoFile()
    ' added this too
    If myUTMUSER.RecordNotFound Then
      myUTMUSER.AddOneRecordP()
    Else
      myUTMUSER.UpdateOneRecordP()
    End If
    Me.Close()
  End Sub
  Private Sub MovetoFile()
    With myUTMUSER
      ._USER1 = Trim(TxtUser1.Text)
      ._USER2 = Trim(TxtUser2.Text)
      ._USER3 = Trim(TxtUser3.Text)
    End With
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  End Sub
End Class
