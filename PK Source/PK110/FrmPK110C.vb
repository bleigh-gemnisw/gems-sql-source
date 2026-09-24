Public Class FrmPK110C
  Inherits System.Windows.Forms.Form
  Dim myPKVIOL As PKVIOL.MyData
  Friend WrkCode As Integer
  Friend WrkAddMode As Boolean

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
  Friend WithEvents TxtCode As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtDescr As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtAmount As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtCode = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtDescr = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtAmount = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtCode
    '
    Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode.Location = New System.Drawing.Point(77, 16)
    Me.TxtCode.MaxLength = 2
    Me.TxtCode.Name = "TxtCode"
    Me.TxtCode.Size = New System.Drawing.Size(26, 20)
    Me.TxtCode.TabIndex = 0
    Me.TxtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(6, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(36, 16)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "Code"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtDescr
    '
    Me.TxtDescr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDescr.Location = New System.Drawing.Point(77, 43)
    Me.TxtDescr.MaxLength = 30
    Me.TxtDescr.Name = "TxtDescr"
    Me.TxtDescr.Size = New System.Drawing.Size(336, 20)
    Me.TxtDescr.TabIndex = 2
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(9, 46)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(60, 13)
    Me.Label2.TabIndex = 3
    Me.Label2.Text = "Description"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(9, 74)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(43, 13)
    Me.Label3.TabIndex = 5
    Me.Label3.Text = "Amount"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtAmount
    '
    Me.TxtAmount.Location = New System.Drawing.Point(77, 71)
    Me.TxtAmount.MaxLength = 6
    Me.TxtAmount.Name = "TxtAmount"
    Me.TxtAmount.Size = New System.Drawing.Size(66, 20)
    Me.TxtAmount.TabIndex = 4
    Me.TxtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'FrmPK110C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(424, 116)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtAmount)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtDescr)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtCode)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmPK110C"
    Me.Text = "Maintain Violation Code"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmPK101C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myPKVIOL = New PKVIOL.MyData(myDBConnect)
    MyFrmPK101.TBarNew.Enabled = False
    MyFrmPK101.TBarSave.Enabled = True
    If Not WrkAddMode Then
      MyFrmPK101.TBarDelete.Enabled = True
      MyUtils.SetTxtReadOnly(TxtCode)
    Else
      Exit Sub
    End If

    MyFrmPK101.TBarPrint.Enabled = False
    myPKVIOL.GetOneRecordP(WrkCode)
    TxtCode.Text = WrkCode
    If myPKVIOL.RecordNotFound Then Exit Sub
    With myPKVIOL
      TxtDescr.Text = Trim(._DESCR)
      TxtAmount.Text = ._AMOUNT
    End With
  End Sub

  Private Sub FrmPK101C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmPK101.SbpScreen.Text = "PK101C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub

  Private Sub FrmPK101C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmPK101.TBarNew.Enabled = True
    MyFrmPK101.TBarDelete.Enabled = False
    MyFrmPK101.TBarSave.Enabled = False
    MyFrmPK101.TBarPrint.Enabled = False
    MyFrmPK101B.FormatGrid()
    MyFrmPK101B.Show()
  End Sub
  Public Sub DeleteData()
    Dim Answer As Integer
    Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
    If Answer = vbNo Then
      Exit Sub
    End If
    myPKVIOL.DeleteOneRecordP()
    Me.Close()
  End Sub

  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    myPKVIOL.GetOneRecordP(MyUtils.CnvSng(TxtCode.Text))
    If WrkAddMode Then
      If Not myPKVIOL.RecordNotFound Then
        Me.ErrProv.SetError(TxtCode, "Record already exists")
        Exit Sub
      End If
    End If
    If Not WrkAddMode Then
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myPKVIOL.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      myPKVIOL._CODE = MyUtils.CnvSng(TxtCode.Text)
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myPKVIOL.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()
  End Sub
  Private Sub MovetoFile()
    With myPKVIOL
      ._DESCR = TxtDescr.Text
      ._AMOUNT = MyUtils.CnvSng(TxtAmount.Text)
    End With
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If TxtCode.Text = String.Empty Then
      ErrorField(I) = "code"
      ErrorMsg(I) = "Code is required"
      I = I + 1
    End If

    If TxtDescr.Text = String.Empty Then
      ErrorField(I) = "descr"
      ErrorMsg(I) = "Description is required"
      I = I + 1
    End If

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtCode, "")
    ErrProv.SetError(TxtDescr, "")
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "code"
          ErrProv.SetError(TxtCode, ErrorMsg(I))
        Case "descr"
          ErrProv.SetError(TxtDescr, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub TxtCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAmount.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
End Class
