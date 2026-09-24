Public Class FrmTXA31B
  Inherits System.Windows.Forms.Form
  Dim MyTXTYPE As TXTYPE.MyData
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
  Friend WithEvents TxtFromType As System.Windows.Forms.TextBox
  Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
  Friend WithEvents LnkFromType As System.Windows.Forms.LinkLabel
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents TxtToGLYear As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents LnkStatus As LinkLabel
  Friend WithEvents TxtStatus As TextBox
  Friend WithEvents ChkPost As CheckBox
  Friend WithEvents Label3 As Label
  Friend WithEvents Label2 As Label
  Friend WithEvents TxtToType As TextBox
  Friend WithEvents LnkToType As LinkLabel
  Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtFromType = New System.Windows.Forms.TextBox()
    Me.TxtFromGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LnkFromType = New System.Windows.Forms.LinkLabel()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtToGLYear = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.LnkStatus = New System.Windows.Forms.LinkLabel()
    Me.TxtStatus = New System.Windows.Forms.TextBox()
    Me.ChkPost = New System.Windows.Forms.CheckBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtToType = New System.Windows.Forms.TextBox()
    Me.LnkToType = New System.Windows.Forms.LinkLabel()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TxtFromType
    '
    Me.TxtFromType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFromType.Location = New System.Drawing.Point(106, 34)
    Me.TxtFromType.MaxLength = 1
    Me.TxtFromType.Name = "TxtFromType"
    Me.TxtFromType.Size = New System.Drawing.Size(16, 20)
    Me.TxtFromType.TabIndex = 1
    '
    'TxtFromGLYear
    '
    Me.TxtFromGLYear.Location = New System.Drawing.Point(106, 62)
    Me.TxtFromGLYear.MaxLength = 4
    Me.TxtFromGLYear.Name = "TxtFromGLYear"
    Me.TxtFromGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtFromGLYear.TabIndex = 4
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(48, 65)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(55, 13)
    Me.Label4.TabIndex = 11
    Me.Label4.Text = "From Year"
    '
    'LnkFromType
    '
    Me.LnkFromType.AutoSize = True
    Me.LnkFromType.Location = New System.Drawing.Point(48, 37)
    Me.LnkFromType.Name = "LnkFromType"
    Me.LnkFromType.Size = New System.Drawing.Size(52, 13)
    Me.LnkFromType.TabIndex = 0
    Me.LnkFromType.TabStop = True
    Me.LnkFromType.Text = "Tax Type"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtToGLYear
    '
    Me.TxtToGLYear.Location = New System.Drawing.Point(216, 62)
    Me.TxtToGLYear.MaxLength = 4
    Me.TxtToGLYear.Name = "TxtToGLYear"
    Me.TxtToGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtToGLYear.TabIndex = 5
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(165, 66)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(45, 13)
    Me.Label1.TabIndex = 305
    Me.Label1.Text = "To Year"
    '
    'LnkStatus
    '
    Me.LnkStatus.AutoSize = True
    Me.LnkStatus.Location = New System.Drawing.Point(32, 95)
    Me.LnkStatus.Name = "LnkStatus"
    Me.LnkStatus.Size = New System.Drawing.Size(65, 13)
    Me.LnkStatus.TabIndex = 6
    Me.LnkStatus.TabStop = True
    Me.LnkStatus.Text = "Status Code"
    '
    'TxtStatus
    '
    Me.TxtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtStatus.Location = New System.Drawing.Point(108, 92)
    Me.TxtStatus.MaxLength = 1
    Me.TxtStatus.Name = "TxtStatus"
    Me.TxtStatus.Size = New System.Drawing.Size(16, 20)
    Me.TxtStatus.TabIndex = 7
    '
    'ChkPost
    '
    Me.ChkPost.AutoSize = True
    Me.ChkPost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPost.Location = New System.Drawing.Point(55, 124)
    Me.ChkPost.Name = "ChkPost"
    Me.ChkPost.Size = New System.Drawing.Size(67, 17)
    Me.ChkPost.TabIndex = 8
    Me.ChkPost.Text = "Update?"
    Me.ChkPost.UseVisualStyleBackColor = True
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(37, 154)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(211, 15)
    Me.Label3.TabIndex = 312
    Me.Label3.Text = "Copy is from List# to same List#"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(12, 183)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(293, 15)
    Me.Label2.TabIndex = 313
    Me.Label2.Text = "unless it is Motor Vehicle where Vin# is used"
    '
    'TxtToType
    '
    Me.TxtToType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtToType.Location = New System.Drawing.Point(216, 34)
    Me.TxtToType.MaxLength = 1
    Me.TxtToType.Name = "TxtToType"
    Me.TxtToType.Size = New System.Drawing.Size(16, 20)
    Me.TxtToType.TabIndex = 3
    '
    'LnkToType
    '
    Me.LnkToType.AutoSize = True
    Me.LnkToType.Location = New System.Drawing.Point(158, 37)
    Me.LnkToType.Name = "LnkToType"
    Me.LnkToType.Size = New System.Drawing.Size(52, 13)
    Me.LnkToType.TabIndex = 2
    Me.LnkToType.TabStop = True
    Me.LnkToType.Text = "Tax Type"
    '
    'FrmTXA31B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(318, 228)
    Me.ControlBox = False
    Me.Controls.Add(Me.TxtToType)
    Me.Controls.Add(Me.LnkToType)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.ChkPost)
    Me.Controls.Add(Me.LnkStatus)
    Me.Controls.Add(Me.TxtStatus)
    Me.Controls.Add(Me.TxtToGLYear)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtFromGLYear)
    Me.Controls.Add(Me.TxtFromType)
    Me.Controls.Add(Me.LnkFromType)
    Me.Controls.Add(Me.Label4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXA31B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTXA31B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA31.SbpScreen.Text = "TXA31"
  End Sub

  Private Sub LnkTypeFrom_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFromType.LinkClicked
    MyFrmListTypes = New FrmListTypes
    MyFrmListTypes.MdiParent = Me.ParentForm
    MyFrmListTypes.WrkField = "From"
    MyFrmListTypes.WrkType = TxtFromType.Text
    MyFrmListTypes.Show()
    Me.Hide()
  End Sub
  Private Sub LnkTypeTo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkToType.LinkClicked
    MyFrmListTypes = New FrmListTypes
    MyFrmListTypes.MdiParent = Me.ParentForm
    MyFrmListTypes.WrkField = "To"
    MyFrmListTypes.WrkType = TxtToType.Text
    MyFrmListTypes.Show()
    Me.Hide()
  End Sub
  Private Sub FrmTXA31B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFromGLYear, "")
    ErrProv.SetError(TxtToGLYear, "")
    ErrProv.SetError(TxtFromType, "")
    ErrProv.SetError(TxtToType, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "fromglyear"
          ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
        Case "toglyear"
          ErrProv.SetError(TxtToGLYear, ErrorMsg(I))
        Case "fromtype"
          ErrProv.SetError(TxtFromType, ErrorMsg(I))
        Case "totype"
          ErrProv.SetError(TxtToType, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtFromGLYear.Text) = 0 Then
      ErrorField(I) = "fromglyear"
      ErrorMsg(I) = "Invalid From Year"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtToGLYear.Text) = 0 Then
      ErrorField(I) = "toglyear"
      ErrorMsg(I) = "Invalid To Year"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtToGLYear.Text) = MyUtils.CnvSng(TxtFromGLYear.Text) And TxtFromType.Text = TxtToType.Text Then
      ErrorField(I) = "toglyear"
      ErrorMsg(I) = "Types and Years cannot be the same"
      I = I + 1
    End If

    MyTXTYPE.GetOneRecordP(TxtFromType.Text)
    If MyTXTYPE.RecordNotFound Then
      ErrorField(I) = "fromtype"
      ErrorMsg(I) = "Invalid Type"
      I = I + 1
    End If

    MyTXTYPE.GetOneRecordP(TxtToType.Text)
    If MyTXTYPE.RecordNotFound Then
      ErrorField(I) = "totype"
      ErrorMsg(I) = "Invalid Type"
      I = I + 1
    End If
  End Sub
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

    Me.Refresh()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    '8-26-24 - added DMV routine to use VIN# since list# not same
    If MyTXTYPE._TXFAM = "M" Or MyTXTYPE._TXFAM = "S" Then
      ProcFileMV()
    Else
      ProcFile()
    End If

    Windows.Forms.Cursor.Current = Cursors.Default
    If MyFrmTXA31B.ChkPost.Checked Then
      MsgBox("Status Code updated", MsgBoxStyle.Information, "Processing completed")
    End If
  End Sub

  Private Sub FrmTXA31B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXTYPE = New TXTYPE.MyData(myDBConnect)
  End Sub
  Private Sub TxtFromGLYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromGLYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtToGLYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToGLYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Private Sub LnkStatus_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkStatus.LinkClicked
    MyFrmListSts = New FrmListSts
    MyFrmListSts.MdiParent = Me.ParentForm
    MyFrmListSts.WrkCode = TxtStatus.Text
    MyFrmListSts.Show()
    Me.Hide()
  End Sub
End Class






