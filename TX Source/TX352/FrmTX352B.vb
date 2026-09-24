Public Class FrmTX352B
Inherits System.Windows.Forms.Form
Dim WrkType As String
Friend WithEvents LblMsg As System.Windows.Forms.Label
Dim WrkFamily As String

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
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents ChkMVPublic As System.Windows.Forms.CheckBox
Friend WithEvents ChkElderly As System.Windows.Forms.CheckBox
Friend WithEvents LblTypeDesc As System.Windows.Forms.Label
Friend WithEvents TxtType As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents ChkNewOPM As System.Windows.Forms.CheckBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTX352B))
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.TxtGLYear = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TxtDist = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.ChkNewOPM = New System.Windows.Forms.CheckBox
Me.ChkMVPublic = New System.Windows.Forms.CheckBox
Me.ChkElderly = New System.Windows.Forms.CheckBox
Me.LblTypeDesc = New System.Windows.Forms.Label
Me.TxtType = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.LblMsg = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'ImageList1
'
Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
Me.ImageList1.Images.SetKeyName(0, "")
'
'TxtGLYear
'
Me.TxtGLYear.Location = New System.Drawing.Point(109, 38)
Me.TxtGLYear.MaxLength = 4
Me.TxtGLYear.Name = "TxtGLYear"
Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
Me.TxtGLYear.TabIndex = 0
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(21, 38)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(84, 16)
Me.Label4.TabIndex = 11
Me.Label4.Text = "Grand List Year"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'TxtDist
'
Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDist.Location = New System.Drawing.Point(109, 62)
Me.TxtDist.MaxLength = 3
Me.TxtDist.Name = "TxtDist"
Me.TxtDist.Size = New System.Drawing.Size(28, 20)
Me.TxtDist.TabIndex = 1
'
'Label1
'
Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label1.Location = New System.Drawing.Point(21, 62)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(44, 16)
Me.Label1.TabIndex = 49
Me.Label1.Text = "District"
'
'ChkNewOPM
'
Me.ChkNewOPM.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkNewOPM.Checked = True
Me.ChkNewOPM.CheckState = System.Windows.Forms.CheckState.Checked
Me.ChkNewOPM.Location = New System.Drawing.Point(24, 127)
Me.ChkNewOPM.Name = "ChkNewOPM"
Me.ChkNewOPM.Size = New System.Drawing.Size(140, 16)
Me.ChkNewOPM.TabIndex = 3
Me.ChkNewOPM.Text = "Use New OPM Codes?"
'
'ChkMVPublic
'
Me.ChkMVPublic.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkMVPublic.Location = New System.Drawing.Point(24, 149)
Me.ChkMVPublic.Name = "ChkMVPublic"
Me.ChkMVPublic.Size = New System.Drawing.Size(149, 16)
Me.ChkMVPublic.TabIndex = 4
Me.ChkMVPublic.Text = "Include MV Public data?"
'
'ChkElderly
'
Me.ChkElderly.AutoSize = True
Me.ChkElderly.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkElderly.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.ChkElderly.Location = New System.Drawing.Point(24, 171)
Me.ChkElderly.Name = "ChkElderly"
Me.ChkElderly.Size = New System.Drawing.Size(149, 17)
Me.ChkElderly.TabIndex = 5
Me.ChkElderly.Text = "Include Elderly Accounts?"
Me.ChkElderly.UseVisualStyleBackColor = True
'
'LblTypeDesc
'
Me.LblTypeDesc.ForeColor = System.Drawing.Color.Magenta
Me.LblTypeDesc.Location = New System.Drawing.Point(147, 91)
Me.LblTypeDesc.Name = "LblTypeDesc"
Me.LblTypeDesc.Size = New System.Drawing.Size(234, 16)
Me.LblTypeDesc.TabIndex = 320
'
'TxtType
'
Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtType.Location = New System.Drawing.Point(111, 88)
Me.TxtType.MaxLength = 1
Me.TxtType.Name = "TxtType"
Me.TxtType.Size = New System.Drawing.Size(20, 20)
Me.TxtType.TabIndex = 2
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(21, 92)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(84, 16)
Me.Label2.TabIndex = 319
Me.Label2.Text = "Tax Type Code"
'
'LblMsg
'
Me.LblMsg.ForeColor = System.Drawing.Color.Magenta
Me.LblMsg.Location = New System.Drawing.Point(21, 9)
Me.LblMsg.Name = "LblMsg"
Me.LblMsg.Size = New System.Drawing.Size(280, 16)
Me.LblMsg.TabIndex = 321
Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter
'
'FrmTX352B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(401, 197)
Me.ControlBox = False
Me.Controls.Add(Me.LblMsg)
Me.Controls.Add(Me.LblTypeDesc)
Me.Controls.Add(Me.TxtType)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.ChkElderly)
Me.Controls.Add(Me.ChkMVPublic)
Me.Controls.Add(Me.ChkNewOPM)
Me.Controls.Add(Me.TxtDist)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.TxtGLYear)
Me.Controls.Add(Me.Label4)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX352B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
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
    PrtReport()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
Private Sub FrmTX352B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX352.SbpScreen.Text = "TX352B"
End Sub
Private Sub FrmTX352B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLYear, "")
    ErrProv.SetError(TxtType, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "glyear"
        ErrProv.SetError(TxtGLYear, ErrorMsg(I))
      Case "type"
        ErrProv.SetError(TxtType, ErrorMsg(I))
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

    If WrkType = WrkFamily Then
     ErrorField(I) = "type"
     ErrorMsg(I) = "Invalid Type"
     I = I + 1
    End If

    If WrkFamily <> "R" And WrkFamily <> "P" And WrkFamily <> "M" And WrkFamily <> "S" Then
     ErrorField(I) = "type"
     ErrorMsg(I) = "Invalid Type"
     I = I + 1
    End If
  End Sub
Private Sub FrmTX352B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Windows.Forms.Cursor.Current = Cursors.WaitCursor
  BufferExem()
  CheckProfile()
  ChkMVPublic.Enabled = False
  Windows.Forms.Cursor.Current = Cursors.Default
End Sub
Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtGLYear_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtGLYear.TextChanged
  CheckProfile()
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtType.TextChanged
 WrkType = TxtType.Text
 LblTypeDesc.Text = GetTXTypeDesc(WrkType)
 CheckProfile()
 WrkFamily = GetTXTypeFamily(WrkType)
 If WrkFamily = "R" Then
   ChkElderly.Enabled = True
 Else
   ChkElderly.Enabled = False
 End If
 If WrkFamily = "M" Or WrkFamily = "S" Then
   ChkMVPublic.Enabled = True
 Else
   ChkMVPublic.Enabled = False
 End If
End Sub
Private Sub CheckProfile()
 Dim MyTXPROF As TXPROF.myData

  LblMsg.Text = ""
  MyFrmTX352.TBarPrint.Enabled = False
  MyTXPROF = New TXPROF.mydata(MyDBConnect)
  MyTXPROF.GetOneRecordP(WrkType, MyUtils.CnvSng(TxtGLYear.Text), "", MyUtils.CnvSng(TxtDist.Text))
  If MyTXPROF.RecordNotFound Then
    LblMsg.Text = "Print disabled. Add via Bill Type Info program - " & WrkType & " " & TxtGLYear.Text
    Exit Sub
  End If

  MyFrmTX352.TBarPrint.Enabled = True

End Sub
End Class






