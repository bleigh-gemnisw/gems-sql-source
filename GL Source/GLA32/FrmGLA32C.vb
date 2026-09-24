Public Class FrmGLA32C
  Inherits System.Windows.Forms.Form
  Dim myTXGLAD As TXGLAD.MyData
  Dim ds As DataSet = New DataSet
  Friend WrkYear As Integer
  Friend WrkType As String
  Friend WrkCode As String
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TxtCode As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  Friend WithEvents TxtType As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtAdCode As System.Windows.Forms.TextBox
  Friend WithEvents TxtAdYear As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WrkCopyMode As Boolean

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
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtCode = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtAdYear = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtAdCode = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 14)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(35, 20)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Year"
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Location = New System.Drawing.Point(150, 14)
    Me.TxtType.MaxLength = 1
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(16, 20)
    Me.TxtType.TabIndex = 1
    '
    'TxtYear
    '
    Me.TxtYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtYear.Location = New System.Drawing.Point(49, 14)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtYear.TabIndex = 0
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(105, 14)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(39, 20)
    Me.Label4.TabIndex = 341
    Me.Label4.Text = "Type"
    '
    'TxtCode
    '
    Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode.Location = New System.Drawing.Point(237, 14)
    Me.TxtCode.MaxLength = 2
    Me.TxtCode.Name = "TxtCode"
    Me.TxtCode.Size = New System.Drawing.Size(27, 20)
    Me.TxtCode.TabIndex = 2
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(192, 14)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(39, 20)
    Me.Label5.TabIndex = 343
    Me.Label5.Text = "Code"
    '
    'TxtAdYear
    '
    Me.TxtAdYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdYear.Location = New System.Drawing.Point(91, 57)
    Me.TxtAdYear.MaxLength = 4
    Me.TxtAdYear.Name = "TxtAdYear"
    Me.TxtAdYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtAdYear.TabIndex = 345
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(8, 60)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(77, 20)
    Me.Label2.TabIndex = 344
    Me.Label2.Text = "Admins Year"
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(8, 80)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(74, 20)
    Me.Label3.TabIndex = 347
    Me.Label3.Text = "Admins Code"
    '
    'TxtAdCode
    '
    Me.TxtAdCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdCode.Location = New System.Drawing.Point(91, 80)
    Me.TxtAdCode.MaxLength = 3
    Me.TxtAdCode.Name = "TxtAdCode"
    Me.TxtAdCode.Size = New System.Drawing.Size(36, 20)
    Me.TxtAdCode.TabIndex = 346
    '
    'FrmGLA32C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(281, 116)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtAdCode)
    Me.Controls.Add(Me.TxtAdYear)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtCode)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.TxtType)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGLA32C"
    Me.Text = "Maintain Tax Interface"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region


  Private Sub FrmGLA32C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXGLAD = New TXGLAD.MyData(myDBConnect)

    MyFrmGLA32.TBarNew.Enabled = False
    MyFrmGLA32.TBarSave.Enabled = True
    MyFrmGLA32.TBarCopy.Enabled = False
    If WrkCopyMode Then
      MyFrmGLA32.TBarDelete.Enabled = False
    End If
    If WrkType <> String.Empty Then
      MyFrmGLA32.TBarDelete.Enabled = True
      MyUtils.SetTxtReadOnly(TxtType)
      MyUtils.SetTxtReadOnly(TxtYear)
      MyUtils.SetTxtReadOnly(TxtCode)
    Else
    End If
    MyFrmGLA32.TBarPrint.Enabled = False
    LoadForm()
  End Sub
  Private Sub LoadForm()
    myTXGLAD.GetOneRecordP(WrkYear, WrkType, WrkCode)

    TxtType.Text = WrkType
    TxtYear.Text = MyUtils.CnvSng(WrkYear)
    TxtCode.Text = WrkCode

    If WrkCopyMode Then
      'Copy mode - Use last year's data
      WrkYear = WrkYear - 1
      myTXGLAD.GetOneRecordP(WrkYear, WrkType, WrkCode)
    Else
      If myTXGLAD.RecordNotFound Then
        Exit Sub
      End If
    End If

    With myTXGLAD
      If WrkCopyMode Then
        TxtAdYear.Text = ._ADYR + 1
      Else
        TxtAdYear.Text = ._ADYR
      End If
      TxtAdCode.Text = ._ADCD
    End With
  End Sub
  Private Sub FrmGLA32C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGLA32.SbpScreen.Text = "GLA32C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub

  Private Sub FrmGLA32C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmGLA32.TBarNew.Enabled = True
    MyFrmGLA32.TBarDelete.Enabled = False
    MyFrmGLA32.TBarSave.Enabled = False
    MyFrmGLA32.TBarCopy.Enabled = True
    MyFrmGLA32.TBarNew.Enabled = True
    MyFrmGLA32.TBarPrint.Enabled = False
    MyFrmGLA32B.FormatGrid()
    MyFrmGLA32B.Show()
    'Memory Cleanup
    myTXGLAD.CloseFile()
    myTXGLAD = Nothing
    MyFrmGLA32C = Nothing
  End Sub
  Public Sub DeleteData()
    Dim Answer As Integer
    Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
    If Answer = vbNo Then
      Exit Sub
    End If

    myTXGLAD.GetOneRecordP(MyUtils.CnvSng(TxtYear.Text), TxtType.Text, TxtCode.Text)
    myTXGLAD.DeleteOneRecordP()
    Me.Close()
  End Sub

  Public Sub SaveData()
    Dim Answer As Integer
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    myTXGLAD.GetOneRecordP(MyUtils.CnvSng(TxtYear.Text), TxtType.Text, TxtCode.Text)
    If WrkType = String.Empty Then
      If Not myTXGLAD.RecordNotFound Then
        Me.ErrProv.SetError(TxtType, "Record already exists")
        Exit Sub
      End If
    End If
    If Not myTXGLAD.RecordNotFound Then
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXGLAD.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        With myTXGLAD
          ._TXYR = MyUtils.CnvSng(TxtYear.Text)
          ._TXTYP = TxtType.Text
          ._TXCD = TxtCode.Text
        End With
        myTXGLAD.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    If WrkCopyMode Then
      Answer = MsgBox("Record has been saved", MsgBoxStyle.YesNo, "Copy to Following Year?")
      If Answer = MsgBoxResult.Yes Then
        WrkYear = MyUtils.CnvSng(TxtYear.Text) + 1
        LoadForm()
        Exit Sub
      End If
    End If
    Me.Close()
  End Sub
  Private Sub MovetoFile()
    With myTXGLAD
      ._ADYR = MyUtils.CnvSng(TxtAdYear.Text)
      ._ADCD = TxtAdCode.Text
    End With
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtYear.Text) = 0 Then
      ErrorField(I) = "year"
      ErrorMsg(I) = "Year is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtYear.Text) = 0 Then
      ErrorField(I) = "type"
      ErrorMsg(I) = "Type is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtAdYear.Text) = 0 Then
      ErrorField(I) = "adyear"
      ErrorMsg(I) = "AdYear is required"
      I = I + 1
    End If

    If TxtAdCode.Text = String.Empty Then
      ErrorField(I) = "adcode"
      ErrorMsg(I) = "AdCode is required"
      I = I + 1
    End If
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtType, String.Empty)
    ErrProv.SetError(TxtYear, String.Empty)
    ErrProv.SetError(TxtAdYear, String.Empty)
    ErrProv.SetError(TxtAdCode, String.Empty)
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "type"
          ErrProv.SetError(TxtType, ErrorMsg(I))
        Case "year"
          ErrProv.SetError(TxtYear, ErrorMsg(I))
        Case "adyear"
          ErrProv.SetError(TxtAdYear, ErrorMsg(I))
        Case "adcode"
          ErrProv.SetError(TxtAdCode, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAdYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAdYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
End Class
