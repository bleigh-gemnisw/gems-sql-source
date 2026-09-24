Public Class FrmTX201B
  Inherits System.Windows.Forms.Form
  Dim myTXCNTL As TXCNTL.MyData
  Dim WrkType As String
  Friend WithEvents Label2 As Label
  Dim Wrkorigyear  ' grand list year from control file
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
  Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbProrate As System.Windows.Forms.RadioButton
Friend WithEvents RbSU As System.Windows.Forms.RadioButton
Friend WithEvents RbRE As System.Windows.Forms.RadioButton
Friend WithEvents RbMV As System.Windows.Forms.RadioButton
Friend WithEvents LblMsg As System.Windows.Forms.Label
Friend WithEvents RbPP As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbProrate = New System.Windows.Forms.RadioButton()
    Me.RbSU = New System.Windows.Forms.RadioButton()
    Me.RbRE = New System.Windows.Forms.RadioButton()
    Me.RbMV = New System.Windows.Forms.RadioButton()
    Me.RbPP = New System.Windows.Forms.RadioButton()
    Me.LblMsg = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'TxtGLYear
    '
    Me.TxtGLYear.Location = New System.Drawing.Point(185, 154)
    Me.TxtGLYear.MaxLength = 4
    Me.TxtGLYear.Name = "TxtGLYear"
    Me.TxtGLYear.Size = New System.Drawing.Size(40, 20)
    Me.TxtGLYear.TabIndex = 1
    Me.TxtGLYear.TabStop = False
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(52, 156)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(127, 16)
    Me.Label4.TabIndex = 11
    Me.Label4.Text = "Current Grand List Year"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtDist
    '
    Me.TxtDist.Location = New System.Drawing.Point(185, 182)
    Me.TxtDist.MaxLength = 4
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(40, 20)
    Me.TxtDist.TabIndex = 2
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(52, 185)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(84, 16)
    Me.Label1.TabIndex = 19
    Me.Label1.Text = "District"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbProrate)
    Me.GroupBox2.Controls.Add(Me.RbSU)
    Me.GroupBox2.Controls.Add(Me.RbRE)
    Me.GroupBox2.Controls.Add(Me.RbMV)
    Me.GroupBox2.Controls.Add(Me.RbPP)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(65, 28)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(160, 120)
    Me.GroupBox2.TabIndex = 20
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Bill Type"
    '
    'RbProrate
    '
    Me.RbProrate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbProrate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbProrate.Location = New System.Drawing.Point(12, 96)
    Me.RbProrate.Name = "RbProrate"
    Me.RbProrate.Size = New System.Drawing.Size(140, 20)
    Me.RbProrate.TabIndex = 4
    Me.RbProrate.Text = "Pro Rated Real Estate"
    '
    'RbSU
    '
    Me.RbSU.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSU.Location = New System.Drawing.Point(12, 76)
    Me.RbSU.Name = "RbSU"
    Me.RbSU.Size = New System.Drawing.Size(140, 20)
    Me.RbSU.TabIndex = 3
    Me.RbSU.Text = "Supplemental MV"
    '
    'RbRE
    '
    Me.RbRE.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbRE.Checked = True
    Me.RbRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbRE.Location = New System.Drawing.Point(12, 16)
    Me.RbRE.Name = "RbRE"
    Me.RbRE.Size = New System.Drawing.Size(140, 20)
    Me.RbRE.TabIndex = 0
    Me.RbRE.TabStop = True
    Me.RbRE.Text = "Real Estate"
    '
    'RbMV
    '
    Me.RbMV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbMV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbMV.Location = New System.Drawing.Point(12, 56)
    Me.RbMV.Name = "RbMV"
    Me.RbMV.Size = New System.Drawing.Size(140, 20)
    Me.RbMV.TabIndex = 2
    Me.RbMV.Text = "Motor Vehicle"
    '
    'RbPP
    '
    Me.RbPP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPP.Location = New System.Drawing.Point(12, 36)
    Me.RbPP.Name = "RbPP"
    Me.RbPP.Size = New System.Drawing.Size(140, 20)
    Me.RbPP.TabIndex = 1
    Me.RbPP.Text = "Personal Property"
    '
    'LblMsg
    '
    Me.LblMsg.ForeColor = System.Drawing.Color.Magenta
    Me.LblMsg.Location = New System.Drawing.Point(2, 9)
    Me.LblMsg.Name = "LblMsg"
    Me.LblMsg.Size = New System.Drawing.Size(280, 16)
    Me.LblMsg.TabIndex = 83
    Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.ForeColor = System.Drawing.Color.Red
    Me.Label2.Location = New System.Drawing.Point(42, 233)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(240, 16)
    Me.Label2.TabIndex = 84
    Me.Label2.Text = "Rate books  can only be run for current year "
    '
    'FrmTX201B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(299, 267)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.LblMsg)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.TxtGLYear)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Label4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX201B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Public Sub RunReport()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If

    CheckProfile()
    If LblMsg.Text <> "" Then Exit Sub

    Me.Refresh()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    GetReportMargins()
    If RbMV.Checked Then
      PrtReportMV()
    End If
    If RbRE.Checked Then
      PrtReportRE()
    End If
    If RbPP.Checked Then
      PrtReportPP()
    End If
    If RbProrate.Checked Then
      PrtReportProrate()
    End If
    If RbSU.Checked Then
      PrtReportSU()
    End If
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
Private Sub FrmTX201B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX201.SbpScreen.Text = "TX201B"
End Sub
Private Sub FrmTX201B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLYear, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "glyear"
        ErrProv.SetError(TxtGLYear, ErrorMsg(I))
      Case Nothing
        Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtGLYear.Text) = 0 Then
      ErrorField(I) = "glyear"
      ErrorMsg(I) = "Invalid Year"
      I = I + 1
    End If

  End Sub

Private Sub FrmTX201B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    'Dim WrkYear As Integer
    myTXCNTL = New TXCNTL.MyData(myDBConnect)
    myTXCNTL.GetOneRecordP("")
    '  WrkYear = Date.Now.Year
    '  If Date.Now.Month < 10 Then
    ' WrkYear = WrkYear - 1
    ' End If
    ' TxtGLYear.Text = WrkYear
    Wrkorigyear = myTXCNTL._ASRGL
    TxtGLYear.Text = myTXCNTL._ASRGL
    TxtGLYear.ReadOnly = True
    WrkType = "R"
    CheckProfile()

End Sub
Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
  Private Sub CheckProfile()
    Dim MyTXPROF As TXPROF.myData

    LblMsg.Text = ""
    MyFrmTX201.TBarPrint.Enabled = False
    MyTXPROF = New TXPROF.mydata(MyDBConnect)
    MyTXPROF.GetOneRecordP(WrkType, MyUtils.CnvSng(TxtGLYear.Text), "", 0)


    If MyTXPROF.RecordNotFound Then
      LblMsg.Text = "Print disabled. Add via Bill Type Info program - " & WrkType & " " & TxtGLYear.Text
      Exit Sub
    End If

    MyFrmTX201.TBarPrint.Enabled = True

  End Sub
  Private Sub resetglyear()
    TxtGLYear.Text = Wrkorigyear
  End Sub
  Private Sub RbRE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbRE.Click
    WrkType = "R"
    resetglyear()
    CheckProfile()
End Sub
Private Sub RbPP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPP.Click
    WrkType = "P"
    resetglyear()
    CheckProfile()
End Sub
Private Sub RbMV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbMV.Click
    WrkType = "M"
    resetglyear()
    CheckProfile()
End Sub
Private Sub RbSU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbSU.Click
    Dim wrksyear As Integer
    wrksyear = TxtGLYear.Text
    WrkType = "S"
    If TxtGLYear.Text = Wrkorigyear And Today.Month >= 7 Then
      wrksyear = wrksyear - 1
    End If
    TxtGLYear.Text = wrksyear
    CheckProfile()
End Sub
Private Sub RbProrate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbProrate.Click
    WrkType = "X"
    resetglyear()
    CheckProfile()
End Sub
Private Sub TxtGLYear_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtGLYear.TextChanged
  CheckProfile()
End Sub

End Class






