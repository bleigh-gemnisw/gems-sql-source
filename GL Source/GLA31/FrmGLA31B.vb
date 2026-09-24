Imports System.Text
Public Class FrmGLA31B
  Inherits System.Windows.Forms.Form
  Dim myTXGLWB As TXGLWB.myData
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Dim myGLACCT As GLACCT.myData
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LnkGLAcct As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtSfcn As System.Windows.Forms.TextBox
    Friend WithEvents TxtFcn As System.Windows.Forms.TextBox
    Friend WithEvents TxtObj As System.Windows.Forms.TextBox
    Friend WithEvents TxtDept As System.Windows.Forms.TextBox
    Friend WithEvents TxtSfund As System.Windows.Forms.TextBox
    Friend WithEvents TxtFund As System.Windows.Forms.TextBox

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LnkGLAcct = New System.Windows.Forms.LinkLabel()
    Me.TxtSfcn = New System.Windows.Forms.TextBox()
    Me.TxtFcn = New System.Windows.Forms.TextBox()
    Me.TxtObj = New System.Windows.Forms.TextBox()
    Me.TxtDept = New System.Windows.Forms.TextBox()
    Me.TxtSfund = New System.Windows.Forms.TextBox()
    Me.TxtFund = New System.Windows.Forms.TextBox()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LnkGLAcct)
    Me.GroupBox1.Controls.Add(Me.TxtSfcn)
    Me.GroupBox1.Controls.Add(Me.TxtFcn)
    Me.GroupBox1.Controls.Add(Me.TxtObj)
    Me.GroupBox1.Controls.Add(Me.TxtDept)
    Me.GroupBox1.Controls.Add(Me.TxtSfund)
    Me.GroupBox1.Controls.Add(Me.TxtFund)
    Me.GroupBox1.Location = New System.Drawing.Point(36, 32)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(333, 56)
    Me.GroupBox1.TabIndex = 7
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Cash Account"
    '
    'LnkGLAcct
    '
    Me.LnkGLAcct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkGLAcct.ForeColor = System.Drawing.Color.Maroon
    Me.LnkGLAcct.Location = New System.Drawing.Point(2, 27)
    Me.LnkGLAcct.Name = "LnkGLAcct"
    Me.LnkGLAcct.Size = New System.Drawing.Size(60, 18)
    Me.LnkGLAcct.TabIndex = 6
    Me.LnkGLAcct.TabStop = True
    Me.LnkGLAcct.Text = "Acct"
    '
    'TxtSfcn
    '
    Me.TxtSfcn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfcn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfcn.Location = New System.Drawing.Point(282, 23)
    Me.TxtSfcn.MaxLength = 4
    Me.TxtSfcn.Name = "TxtSfcn"
    Me.TxtSfcn.Size = New System.Drawing.Size(45, 22)
    Me.TxtSfcn.TabIndex = 5
    '
    'TxtFcn
    '
    Me.TxtFcn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFcn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFcn.Location = New System.Drawing.Point(231, 23)
    Me.TxtFcn.MaxLength = 4
    Me.TxtFcn.Name = "TxtFcn"
    Me.TxtFcn.Size = New System.Drawing.Size(45, 22)
    Me.TxtFcn.TabIndex = 4
    '
    'TxtObj
    '
    Me.TxtObj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObj.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObj.Location = New System.Drawing.Point(195, 23)
    Me.TxtObj.MaxLength = 3
    Me.TxtObj.Name = "TxtObj"
    Me.TxtObj.Size = New System.Drawing.Size(32, 22)
    Me.TxtObj.TabIndex = 3
    '
    'TxtDept
    '
    Me.TxtDept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDept.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDept.Location = New System.Drawing.Point(144, 23)
    Me.TxtDept.MaxLength = 4
    Me.TxtDept.Name = "TxtDept"
    Me.TxtDept.Size = New System.Drawing.Size(45, 22)
    Me.TxtDept.TabIndex = 2
    '
    'TxtSfund
    '
    Me.TxtSfund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfund.Location = New System.Drawing.Point(106, 23)
    Me.TxtSfund.MaxLength = 3
    Me.TxtSfund.Name = "TxtSfund"
    Me.TxtSfund.Size = New System.Drawing.Size(32, 22)
    Me.TxtSfund.TabIndex = 1
    '
    'TxtFund
    '
    Me.TxtFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFund.Location = New System.Drawing.Point(68, 23)
    Me.TxtFund.MaxLength = 3
    Me.TxtFund.Name = "TxtFund"
    Me.TxtFund.Size = New System.Drawing.Size(32, 22)
    Me.TxtFund.TabIndex = 0
    '
    'FrmGLA31B
    '
    Me.AllowDrop = True
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(401, 119)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGLA31B"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub GLA31B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myTXGLWB = New TXGLWB.myData()
  myTXGLWB.mydbconn = myDBConnect
  myGLACCT = New GLACCT.MyData()
  myGLACCT.MyDBConn = myDBConnect

  MyFrmGLA31.TBarNew.Visible = False
  MyFrmGLA31.TBarSave.Visible = True
  MyFrmGLA31.TBarPrint.Visible = False
  MyFrmGLA31.TBarDelete.Visible = False
  myTXGLWB.GetOneRecordP(1)

  If s_chg = False And s_full = False Then    '#sec
    MyFrmGLA31.TBarSave.Visible = False
  End If

  If myTXGLWB.RecordNotFound Then Exit Sub

  With myTXGLWB
   TxtFund.Text = ._FDNRW
   TxtSfund.Text = ._SFURW
   TxtDept.Text = ._DPNRW
   TxtObj.Text = ._OBNRW
   TxtFcn.Text = ._FNPRW
   TxtSfcn.Text = ._SUBRW
  End With
End Sub
Private Sub GLA31B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmGLA31.SbpScreen.Text = "GLA31B"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  myTXGLWB.GetOneRecordP(1)
  MovetoFile()
  EditChecks(ErrorField, ErrorMsg)
  ' added this too
  If myTXGLWB.RecordNotFound Then
    myTXGLWB.AddOneRecordP()
  Else
    myTXGLWB.UpdateOneRecordP()
  End If
  Me.Close()
  End Sub
Private Sub MovetoFile()
  With myTXGLWB
   ._FDNRW = MyUtils.CnvSng(TxtFund.Text)
   ._SFURW = MyUtils.CnvSng(TxtSfund.Text)
   ._DPNRW = MyUtils.CnvSng(TxtDept.Text)
   ._OBNRW = MyUtils.CnvSng(TxtObj.Text)
   ._FNPRW = MyUtils.CnvSng(TxtFcn.Text)
   ._SUBRW = MyUtils.CnvSng(TxtSfcn.Text)
  End With
End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

     If MyUtils.CnvSng(TxtFund.Text) > 0 Or MyUtils.CnvSng(TxtSfund.Text) > 0 Or MyUtils.CnvSng(TxtDept.Text) > 0 Or _
      MyUtils.CnvSng(TxtObj.Text) > 0 Or MyUtils.CnvSng(TxtFcn.Text) > 0 Or MyUtils.CnvSng(TxtSfcn.Text) > 0 Then
      myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFund.Text), MyUtils.CnvSng(TxtSfund.Text), MyUtils.CnvSng(TxtDept.Text), _
        MyUtils.CnvSng(TxtObj.Text), MyUtils.CnvSng(TxtFcn.Text), MyUtils.CnvSng(TxtSfcn.Text))
      If myGLACCT.RecordNotFound Then
        ErrorField(I) = "acctrw"
        ErrorMsg(I) = "Acct is invalid"
        I = I + 1
      End If
    End If
  End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtFund, String.Empty)
  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
    Case "acct"
      ErrProv.SetError(TxtFund, ErrorMsg(I))
    Case Nothing
      Exit Sub
    End Select
  Next I
End Sub
Private Sub LnkGLAcctRW_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkGLAcct.LinkClicked
  Dim WrkAcct As String

  WrkAcct = BuildAcct(MyUtils.CnvSng(TxtFund.Text), MyUtils.CnvSng(TxtSfund.Text), MyUtils.CnvSng(TxtDept.Text), _
    MyUtils.CnvSng(TxtObj.Text), MyUtils.CnvSng(TxtFcn.Text), MyUtils.CnvSng(TxtSfcn.Text))
  MyFrmListGLAcct = New FrmListGLAcct
  MyFrmListGLAcct.MdiParent = Me.ParentForm
  MyFrmListGLAcct.WrkField = ""
  MyFrmListGLAcct.WrkCode = WrkAcct
  MyFrmListGLAcct.Show()
  Me.Hide()
End Sub
Public Function BuildAcct(ByVal Fund As Integer, ByVal SFund As Integer, _
  ByVal Dept As Integer, ByVal Obj As Integer, ByVal Func As Integer, ByVal SFunc As Integer) As String
  Dim sb As StringBuilder = New StringBuilder

  If Fund > 0 Then
    sb.Append(Format(Fund, "000"))
    sb.Append("-")
    sb.Append(Format(SFund, "000"))
    sb.Append("-")
    sb.Append(Format(Dept, "0000"))
    sb.Append("-")
    sb.Append(Format(Obj, "000"))
    sb.Append("-")
    sb.Append(Format(Func, "0000"))
    sb.Append("-")
    sb.Append(Format(SFunc, "0000"))
  Else
    sb.Append(String.Empty)
  End If
  Return sb.ToString
End Function
End Class
