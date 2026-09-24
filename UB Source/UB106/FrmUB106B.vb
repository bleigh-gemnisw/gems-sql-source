Public Class FrmUB106B
  Inherits System.Windows.Forms.Form
  Dim myUTCNTL As UTCNTL.myData
  Friend WrkUbadj As Decimal
  Friend WithEvents TxtCaveat As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents RbNoDelqBond As System.Windows.Forms.RadioButton
  Friend WrkUasdv As String
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
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtUbadj As System.Windows.Forms.TextBox
Friend WithEvents RbSimple As System.Windows.Forms.RadioButton
Friend WithEvents RbRedivide As System.Windows.Forms.RadioButton
Friend WithEvents RbPayEqual As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.label3 = New System.Windows.Forms.Label
Me.Label1 = New System.Windows.Forms.Label
Me.Label2 = New System.Windows.Forms.Label
Me.TxtUbadj = New System.Windows.Forms.TextBox
Me.RbSimple = New System.Windows.Forms.RadioButton
Me.RbRedivide = New System.Windows.Forms.RadioButton
Me.RbPayEqual = New System.Windows.Forms.RadioButton
Me.TxtCaveat = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.RbNoDelqBond = New System.Windows.Forms.RadioButton
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
Me.Label1.Location = New System.Drawing.Point(12, 8)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(100, 16)
Me.Label1.TabIndex = 7
Me.Label1.Text = "Last Adjustment #:"
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(12, 44)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(104, 32)
Me.Label2.TabIndex = 8
Me.Label2.Text = "Assessment Calculation Method:"
'
'TxtUbadj
'
Me.TxtUbadj.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtUbadj.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtUbadj.Location = New System.Drawing.Point(132, 4)
Me.TxtUbadj.MaxLength = 5
Me.TxtUbadj.Name = "TxtUbadj"
Me.TxtUbadj.Size = New System.Drawing.Size(48, 22)
Me.TxtUbadj.TabIndex = 1
'
'RbSimple
'
Me.RbSimple.Checked = True
Me.RbSimple.Location = New System.Drawing.Point(132, 36)
Me.RbSimple.Name = "RbSimple"
Me.RbSimple.Size = New System.Drawing.Size(227, 18)
Me.RbSimple.TabIndex = 9
Me.RbSimple.TabStop = True
Me.RbSimple.Text = "Simple (Principal same/Bond decreases)"
'
'RbRedivide
'
Me.RbRedivide.Location = New System.Drawing.Point(132, 56)
Me.RbRedivide.Name = "RbRedivide"
Me.RbRedivide.Size = New System.Drawing.Size(299, 18)
Me.RbRedivide.TabIndex = 10
Me.RbRedivide.Text = "Redivide (assessment left by number of years left)"
'
'RbPayEqual
'
Me.RbPayEqual.Location = New System.Drawing.Point(132, 76)
Me.RbPayEqual.Name = "RbPayEqual"
Me.RbPayEqual.Size = New System.Drawing.Size(321, 18)
Me.RbPayEqual.TabIndex = 11
Me.RbPayEqual.Text = "Payments Equal (Principal + Bond) Bond Interest is required"
'
'TxtCaveat
'
Me.TxtCaveat.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtCaveat.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtCaveat.Location = New System.Drawing.Point(132, 139)
Me.TxtCaveat.MaxLength = 5
Me.TxtCaveat.Name = "TxtCaveat"
Me.TxtCaveat.Size = New System.Drawing.Size(48, 22)
Me.TxtCaveat.TabIndex = 12
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(12, 143)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(114, 18)
Me.Label4.TabIndex = 13
Me.Label4.Text = "Caveat Lien Amount"
'
'RbNoDelqBond
'
Me.RbNoDelqBond.Location = New System.Drawing.Point(132, 98)
Me.RbNoDelqBond.Name = "RbNoDelqBond"
Me.RbNoDelqBond.Size = New System.Drawing.Size(204, 18)
Me.RbNoDelqBond.TabIndex = 14
Me.RbNoDelqBond.Text = "No Delq Bond Interest (IE: CPACE)"
'
'FrmUB106B
'
Me.AllowDrop = True
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(465, 172)
Me.ControlBox = False
Me.Controls.Add(Me.RbNoDelqBond)
Me.Controls.Add(Me.TxtCaveat)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.RbPayEqual)
Me.Controls.Add(Me.RbRedivide)
Me.Controls.Add(Me.RbSimple)
Me.Controls.Add(Me.TxtUbadj)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.label3)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmUB106B"
Me.Text = "Utility Billing Control File"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub UB106B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myUTCNTL = New UTCNTL.mydata(MyDBConnect)
  MyFrmUB106.TBarNew.Visible = False
  MyFrmUB106.TBarSave.Visible = True
  MyFrmUB106.TBarPrint.Visible = False
  MyFrmUB106.TBarDelete.Visible = False
  myUTCNTL.GetOneRecordP(1)
  If myUTCNTL.RecordNotFound Then Exit Sub
  If s_chg = False And s_full = False Then    '#sec
    MyFrmUB106.TBarSave.Visible = False
  End If
  With myUTCNTL
    TxtUbadj.Text = ._UBADJNo
    If ._UASDV = "S" Then
      RbSimple.Checked = True
    End If
    If ._UASDV = "R" Then
      RbRedivide.Checked = True
    End If
    If ._UASDV = "P" Then
      RbPayEqual.Checked = True
    End If
    If ._UASDV = "N" Then
      RbNoDelqBond.Checked = True
    End If
    TxtCaveat.Text = ._UBCAV
  End With
End Sub
Private Sub UB106B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB106.SbpScreen.Text = "UB106B"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  myUTCNTL.GetOneRecordP(1)
  MovetoFile()
  ' added this too
  If myUTCNTL.RecordNotFound Then
    myUTCNTL.AddOneRecordP()
  Else
    myUTCNTL.UpdateOneRecordP()
  End If
  Me.Close()
  End Sub
Private Sub MovetoFile()
  With myUTCNTL
    ._UBADJNo = MyUtils.CnvSng(TxtUbadj.Text)
    If RbSimple.Checked Then
      ._UASDV = "S"
    End If
    If RbRedivide.Checked Then
      ._UASDV = "R"
    End If
    If RbPayEqual.Checked Then
      ._UASDV = "P"
    End If
    If RbNoDelqBond.Checked Then
      ._UASDV = "N"
    End If
    ._UBCAV = MyUtils.CnvSng(TxtCaveat.Text)
  End With
End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtUbadj, "")
  For I = 0 To ErrorField.GetUpperBound(0)
     Select Case ErrorField(I)
       Case "ubadj#"
       ErrProv.SetError(TxtUbadj, ErrorMsg(I))
       Case Nothing
       Exit Sub
     End Select
     Next I
End Sub

Private Sub TxtUbadj_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUbadj.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtCaveat_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCaveat.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
End Class






