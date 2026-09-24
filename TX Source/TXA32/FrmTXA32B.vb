Public Class FrmTXA32B
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
  Friend WithEvents TxtType As System.Windows.Forms.TextBox
  Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
  Friend WithEvents LnkType As System.Windows.Forms.LinkLabel
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents TxtToGLYear As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents ChkPost As CheckBox
  Friend WithEvents Label2 As Label
  Friend WithEvents Label3 As Label
  Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.TxtFromGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LnkType = New System.Windows.Forms.LinkLabel()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtToGLYear = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.ChkPost = New System.Windows.Forms.CheckBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Location = New System.Drawing.Point(106, 34)
    Me.TxtType.MaxLength = 20
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(16, 20)
    Me.TxtType.TabIndex = 0
    '
    'TxtFromGLYear
    '
    Me.TxtFromGLYear.Location = New System.Drawing.Point(106, 62)
    Me.TxtFromGLYear.MaxLength = 4
    Me.TxtFromGLYear.Name = "TxtFromGLYear"
    Me.TxtFromGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtFromGLYear.TabIndex = 1
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
    'LnkType
    '
    Me.LnkType.AutoSize = True
    Me.LnkType.Location = New System.Drawing.Point(48, 37)
    Me.LnkType.Name = "LnkType"
    Me.LnkType.Size = New System.Drawing.Size(52, 13)
    Me.LnkType.TabIndex = 17
    Me.LnkType.TabStop = True
    Me.LnkType.Text = "Tax Type"
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
    Me.TxtToGLYear.TabIndex = 2
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
    'ChkPost
    '
    Me.ChkPost.AutoSize = True
    Me.ChkPost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPost.Location = New System.Drawing.Point(55, 88)
    Me.ChkPost.Name = "ChkPost"
    Me.ChkPost.Size = New System.Drawing.Size(67, 17)
    Me.ChkPost.TabIndex = 308
    Me.ChkPost.Text = "Update?"
    Me.ChkPost.UseVisualStyleBackColor = True
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(48, 122)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(190, 15)
    Me.Label2.TabIndex = 309
    Me.Label2.Text = "Overwrite To Year comments"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(48, 137)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(211, 15)
    Me.Label3.TabIndex = 310
    Me.Label3.Text = "Copy is from List# to same List#"
    '
    'FrmTXA32B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(288, 161)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.ChkPost)
    Me.Controls.Add(Me.TxtToGLYear)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtFromGLYear)
    Me.Controls.Add(Me.TxtType)
    Me.Controls.Add(Me.LnkType)
    Me.Controls.Add(Me.Label4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXA32B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTXA32B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA32.SbpScreen.Text = "TXA32"
  End Sub

  Private Sub LnkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkType.LinkClicked
    MyFrmListTypes = New FrmListTypes
    MyFrmListTypes.MdiParent = Me.ParentForm
    MyFrmListTypes.WrkType = TxtType.Text
    MyFrmListTypes.Show()
    Me.Hide()
  End Sub
  Private Sub FrmTXA32B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFromGLYear, "")
    ErrProv.SetError(TxtToGLYear, "")
    ErrProv.SetError(TxtType, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "fromglyear"
          ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
        Case "toglyear"
          ErrProv.SetError(TxtToGLYear, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtToGLYear.Text) = MyUtils.CnvSng(TxtFromGLYear.Text) Then
      ErrorField(I) = "toglyear"
      ErrorMsg(I) = "Years cannot be the same"
      I = I + 1
    End If

    MyTXTYPE.GetOneRecordP(TxtType.Text)
    If MyTXTYPE.RecordNotFound Then
      ErrorField(I) = "type"
      ErrorMsg(I) = "Invalid Type"
      I = I + 1
    Else
      If MyTXTYPE._TXFAM = "M" Or MyTXTYPE._TXFAM = "S" Then
        ErrorField(I) = "type"
        ErrorMsg(I) = "Motor Veheilc types are not allowed"
        I = I + 1
      End If
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
    ProcFile()
    Windows.Forms.Cursor.Current = Cursors.Default
    If MyFrmTXA32B.ChkPost.Checked Then
      MsgBox("Comments updated", MsgBoxStyle.Information, "Processing completed")
      MyFrmTXA32B.ChkPost.Checked = False
    End If
  End Sub

  Private Sub FrmTXA32B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXTYPE = New TXTYPE.MyData(myDBConnect)
  End Sub
  Private Sub TxtFromGLYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromGLYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtToGLYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToGLYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
End Class






