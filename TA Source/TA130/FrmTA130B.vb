Public Class FrmTA130B
  Inherits System.Windows.Forms.Form
  Dim myTXCNTL As TXCNTL.myData
  Friend WithEvents GrpSoft As System.Windows.Forms.GroupBox
  Friend WithEvents ChkSoftRE As System.Windows.Forms.CheckBox
  Friend WithEvents ChkSoftMV As System.Windows.Forms.CheckBox
  Friend WithEvents TxtAsrgl As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents ChkSoftPP As System.Windows.Forms.CheckBox
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
Friend WithEvents TxtAssrName As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents TxtAssrPhone As System.Windows.Forms.TextBox
Friend WithEvents TxtLastCCNo As System.Windows.Forms.TextBox
Friend WithEvents TxtState As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.label3 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtAssrName = New System.Windows.Forms.TextBox()
    Me.TxtAssrPhone = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtLastCCNo = New System.Windows.Forms.TextBox()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.GrpSoft = New System.Windows.Forms.GroupBox()
    Me.ChkSoftMV = New System.Windows.Forms.CheckBox()
    Me.ChkSoftPP = New System.Windows.Forms.CheckBox()
    Me.ChkSoftRE = New System.Windows.Forms.CheckBox()
    Me.TxtAsrgl = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpSoft.SuspendLayout()
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
    Me.Label1.Location = New System.Drawing.Point(12, 72)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(88, 18)
    Me.Label1.TabIndex = 7
    Me.Label1.Text = "Assessor Name"
    '
    'TxtAssrName
    '
    Me.TxtAssrName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssrName.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtAssrName.Location = New System.Drawing.Point(106, 68)
    Me.TxtAssrName.MaxLength = 30
    Me.TxtAssrName.Name = "TxtAssrName"
    Me.TxtAssrName.Size = New System.Drawing.Size(248, 22)
    Me.TxtAssrName.TabIndex = 3
    '
    'TxtAssrPhone
    '
    Me.TxtAssrPhone.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssrPhone.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtAssrPhone.Location = New System.Drawing.Point(105, 96)
    Me.TxtAssrPhone.MaxLength = 14
    Me.TxtAssrPhone.Name = "TxtAssrPhone"
    Me.TxtAssrPhone.Size = New System.Drawing.Size(121, 22)
    Me.TxtAssrPhone.TabIndex = 4
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(12, 101)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(88, 17)
    Me.Label2.TabIndex = 9
    Me.Label2.Text = "Assessor Phone"
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(12, 37)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(126, 14)
    Me.Label6.TabIndex = 14
    Me.Label6.Text = "Last C/C Number used"
    '
    'TxtLastCCNo
    '
    Me.TxtLastCCNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLastCCNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtLastCCNo.Location = New System.Drawing.Point(144, 33)
    Me.TxtLastCCNo.MaxLength = 5
    Me.TxtLastCCNo.Name = "TxtLastCCNo"
    Me.TxtLastCCNo.Size = New System.Drawing.Size(48, 22)
    Me.TxtLastCCNo.TabIndex = 1
    '
    'TxtState
    '
    Me.TxtState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtState.Location = New System.Drawing.Point(277, 33)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(30, 22)
    Me.TxtState.TabIndex = 2
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(230, 37)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(41, 18)
    Me.Label7.TabIndex = 17
    Me.Label7.Text = "State"
    '
    'GrpSoft
    '
    Me.GrpSoft.Controls.Add(Me.ChkSoftMV)
    Me.GrpSoft.Controls.Add(Me.ChkSoftPP)
    Me.GrpSoft.Controls.Add(Me.ChkSoftRE)
    Me.GrpSoft.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpSoft.Location = New System.Drawing.Point(438, 12)
    Me.GrpSoft.Name = "GrpSoft"
    Me.GrpSoft.Size = New System.Drawing.Size(158, 98)
    Me.GrpSoft.TabIndex = 5
    Me.GrpSoft.TabStop = False
    Me.GrpSoft.Text = "Soft Freeze"
    '
    'ChkSoftMV
    '
    Me.ChkSoftMV.AutoSize = True
    Me.ChkSoftMV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkSoftMV.Location = New System.Drawing.Point(11, 66)
    Me.ChkSoftMV.Name = "ChkSoftMV"
    Me.ChkSoftMV.Size = New System.Drawing.Size(91, 17)
    Me.ChkSoftMV.TabIndex = 31
    Me.ChkSoftMV.Text = "Motor Vehicle"
    Me.ChkSoftMV.UseVisualStyleBackColor = True
    '
    'ChkSoftPP
    '
    Me.ChkSoftPP.AutoSize = True
    Me.ChkSoftPP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkSoftPP.Location = New System.Drawing.Point(11, 43)
    Me.ChkSoftPP.Name = "ChkSoftPP"
    Me.ChkSoftPP.Size = New System.Drawing.Size(109, 17)
    Me.ChkSoftPP.TabIndex = 30
    Me.ChkSoftPP.Text = "Personal Property"
    Me.ChkSoftPP.UseVisualStyleBackColor = True
    '
    'ChkSoftRE
    '
    Me.ChkSoftRE.AutoSize = True
    Me.ChkSoftRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkSoftRE.Location = New System.Drawing.Point(11, 20)
    Me.ChkSoftRE.Name = "ChkSoftRE"
    Me.ChkSoftRE.Size = New System.Drawing.Size(81, 17)
    Me.ChkSoftRE.TabIndex = 29
    Me.ChkSoftRE.Text = "Real Estate"
    Me.ChkSoftRE.UseVisualStyleBackColor = True
    '
    'TxtAsrgl
    '
    Me.TxtAsrgl.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAsrgl.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtAsrgl.Location = New System.Drawing.Point(144, 5)
    Me.TxtAsrgl.MaxLength = 4
    Me.TxtAsrgl.Name = "TxtAsrgl"
    Me.TxtAsrgl.Size = New System.Drawing.Size(39, 22)
    Me.TxtAsrgl.TabIndex = 0
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(12, 9)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(126, 14)
    Me.Label4.TabIndex = 19
    Me.Label4.Text = "Current Grand List Year"
    '
    'FrmTA130B
    '
    Me.AllowDrop = True
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(608, 130)
    Me.ControlBox = False
    Me.Controls.Add(Me.TxtAsrgl)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.GrpSoft)
    Me.Controls.Add(Me.TxtState)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TxtLastCCNo)
    Me.Controls.Add(Me.TxtAssrPhone)
    Me.Controls.Add(Me.TxtAssrName)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA130B"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpSoft.ResumeLayout(False)
    Me.GrpSoft.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub TA130B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myTXCNTL = New TXCNTL.mydata(MyDBConnect)

  MyFrmTA130.TBarNew.Visible = False
  MyFrmTA130.TBarSave.Visible = True
  MyFrmTA130.TBarPrint.Visible = False
  MyFrmTA130.TBarDelete.Visible = False
  myTXCNTL.GetOneRecordP("")

  If s_chg = False And s_full = False Then    '#sec
    MyFrmTA130.TBarSave.Visible = False
  End If

  If myTXCNTL.RecordNotFound Then Exit Sub

  With myTXCNTL
    If ._SFR = "Y" Then
      ChkSoftRE.Checked = True
    End If
    If ._SFP = "Y" Then
      ChkSoftPP.Checked = True
    End If
    If ._SFM = "Y" Then
      ChkSoftMV.Checked = True
    End If
    TxtAsrgl.Text = ._ASRGL
    TxtAssrName.Text = Trim(._ASRNAM)
    TxtAssrPhone.Text = Trim(._ASRPHN)
    TxtLastCCNo.Text = ._COFC
    TxtState.Text = Trim(._STACD)
  End With
End Sub
Private Sub TA130B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA130.SbpScreen.Text = "TA130B"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Public Sub SaveData()
  myTXCNTL.GetOneRecordP("")
  MovetoFile()
  ' added this too
  If myTXCNTL.RecordNotFound Then
    myTXCNTL.AddOneRecordP()
  Else
    myTXCNTL.UpdateOneRecordP()
  End If
  Me.Close()
  End Sub
Private Sub MovetoFile()
  With myTXCNTL
    ._ASRGL = MyUtils.CnvSng(TxtAsrgl.Text)
    ._COFC = MyUtils.CnvSng(TxtLastCCNo.Text)
    ._STACD = TxtState.Text
    If ChkSoftRE.Checked Then
      ._SFR = "Y"
    Else
      ._SFR = "N"
    End If
    If ChkSoftPP.Checked Then
      ._SFP = "Y"
    Else
      ._SFP = "N"
    End If
    If ChkSoftMV.Checked Then
      ._SFM = "Y"
    Else
      ._SFM = "N"
    End If
    ._ASRNAM = TxtAssrName.Text
    ._ASRPHN = TxtAssrPhone.Text
  End With
End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtAsrgl, "")
  ErrProv.SetError(TxtAssrName, "")
  For I = 0 To ErrorField.GetUpperBound(0)
     Select Case ErrorField(I)
       Case "year"
         ErrProv.SetError(TxtAsrgl, ErrorMsg(I))
       Case "town"
         ErrProv.SetError(TxtAssrName, ErrorMsg(I))
       Case Nothing
         Exit Sub
     End Select
     Next I
End Sub
Private Sub TxtAsrgl_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAsrgl.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtLastCCNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLastCCNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






