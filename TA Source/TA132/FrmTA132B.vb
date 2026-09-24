Public Class FrmTA132B
  Inherits System.Windows.Forms.Form
  Dim myTXCDAG As TXCDAG.myData
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
    Friend WithEvents LnkCode1 As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtCode1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LnkCode2 As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtCode2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LnkCode4 As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtCode4 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LnkCode3 As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtCode3 As System.Windows.Forms.TextBox
    Friend WithEvents label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.label3 = New System.Windows.Forms.Label
Me.LnkCode1 = New System.Windows.Forms.LinkLabel
Me.TxtCode1 = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.Label2 = New System.Windows.Forms.Label
Me.Label4 = New System.Windows.Forms.Label
Me.LnkCode2 = New System.Windows.Forms.LinkLabel
Me.TxtCode2 = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
Me.LnkCode3 = New System.Windows.Forms.LinkLabel
Me.TxtCode3 = New System.Windows.Forms.TextBox
Me.Label6 = New System.Windows.Forms.Label
Me.LnkCode4 = New System.Windows.Forms.LinkLabel
Me.TxtCode4 = New System.Windows.Forms.TextBox
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
'LnkCode1
'
Me.LnkCode1.AutoSize = True
Me.LnkCode1.Location = New System.Drawing.Point(82, 21)
Me.LnkCode1.Name = "LnkCode1"
Me.LnkCode1.Size = New System.Drawing.Size(32, 13)
Me.LnkCode1.TabIndex = 18
Me.LnkCode1.TabStop = True
Me.LnkCode1.Text = "Code"
'
'TxtCode1
'
Me.TxtCode1.Location = New System.Drawing.Point(120, 18)
Me.TxtCode1.MaxLength = 2
Me.TxtCode1.Name = "TxtCode1"
Me.TxtCode1.Size = New System.Drawing.Size(25, 20)
Me.TxtCode1.TabIndex = 19
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(20, 21)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(0, 13)
Me.Label1.TabIndex = 20
'
'Label2
'
Me.Label2.AutoSize = True
Me.Label2.Location = New System.Drawing.Point(40, 21)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(21, 13)
Me.Label2.TabIndex = 21
Me.Label2.Text = "1st"
'
'Label4
'
Me.Label4.AutoSize = True
Me.Label4.Location = New System.Drawing.Point(40, 47)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(25, 13)
Me.Label4.TabIndex = 24
Me.Label4.Text = "2nd"
'
'LnkCode2
'
Me.LnkCode2.AutoSize = True
Me.LnkCode2.Location = New System.Drawing.Point(82, 47)
Me.LnkCode2.Name = "LnkCode2"
Me.LnkCode2.Size = New System.Drawing.Size(32, 13)
Me.LnkCode2.TabIndex = 22
Me.LnkCode2.TabStop = True
Me.LnkCode2.Text = "Code"
'
'TxtCode2
'
Me.TxtCode2.Location = New System.Drawing.Point(120, 44)
Me.TxtCode2.MaxLength = 2
Me.TxtCode2.Name = "TxtCode2"
Me.TxtCode2.Size = New System.Drawing.Size(25, 20)
Me.TxtCode2.TabIndex = 23
'
'Label5
'
Me.Label5.AutoSize = True
Me.Label5.Location = New System.Drawing.Point(40, 73)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(22, 13)
Me.Label5.TabIndex = 27
Me.Label5.Text = "3rd"
'
'LnkCode3
'
Me.LnkCode3.AutoSize = True
Me.LnkCode3.Location = New System.Drawing.Point(82, 73)
Me.LnkCode3.Name = "LnkCode3"
Me.LnkCode3.Size = New System.Drawing.Size(32, 13)
Me.LnkCode3.TabIndex = 25
Me.LnkCode3.TabStop = True
Me.LnkCode3.Text = "Code"
'
'TxtCode3
'
Me.TxtCode3.Location = New System.Drawing.Point(120, 70)
Me.TxtCode3.MaxLength = 2
Me.TxtCode3.Name = "TxtCode3"
Me.TxtCode3.Size = New System.Drawing.Size(25, 20)
Me.TxtCode3.TabIndex = 26
'
'Label6
'
Me.Label6.AutoSize = True
Me.Label6.Location = New System.Drawing.Point(40, 97)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(22, 13)
Me.Label6.TabIndex = 30
Me.Label6.Text = "4th"
'
'LnkCode4
'
Me.LnkCode4.AutoSize = True
Me.LnkCode4.Location = New System.Drawing.Point(82, 97)
Me.LnkCode4.Name = "LnkCode4"
Me.LnkCode4.Size = New System.Drawing.Size(32, 13)
Me.LnkCode4.TabIndex = 28
Me.LnkCode4.TabStop = True
Me.LnkCode4.Text = "Code"
'
'TxtCode4
'
Me.TxtCode4.Location = New System.Drawing.Point(120, 94)
Me.TxtCode4.MaxLength = 2
Me.TxtCode4.Name = "TxtCode4"
Me.TxtCode4.Size = New System.Drawing.Size(25, 20)
Me.TxtCode4.TabIndex = 29
'
'FrmTA132B
'
Me.AllowDrop = True
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(181, 135)
Me.ControlBox = False
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.LnkCode4)
Me.Controls.Add(Me.TxtCode4)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.LnkCode3)
Me.Controls.Add(Me.TxtCode3)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.LnkCode2)
Me.Controls.Add(Me.TxtCode2)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.LnkCode1)
Me.Controls.Add(Me.TxtCode1)
Me.Controls.Add(Me.label3)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA132B"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub TA132B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myTXCDAG = New TXCDAG.mydata(MyDBConnect)

  MyFrmTA132.TBarNew.Visible = False
  MyFrmTA132.TBarSave.Visible = True
  MyFrmTA132.TBarPrint.Visible = False
  MyFrmTA132.TBarDelete.Visible = False

  If s_chg = False And s_full = False Then    '#sec
    MyFrmTA132.TBarSave.Visible = False
  End If

  myTXCDAG.GetOneRecordP(1)
  If myTXCDAG.RecordNotFound Then Exit Sub

  With myTXCDAG
    TxtCode1.Text = ._TCCODE
  End With

  myTXCDAG.GetOneRecordP(2)
  With myTXCDAG
    TxtCode2.Text = ._TCCODE
  End With

  myTXCDAG.GetOneRecordP(3)
  With myTXCDAG
    TxtCode3.Text = ._TCCODE
  End With

  myTXCDAG.GetOneRecordP(4)
  With myTXCDAG
    TxtCode4.Text = ._TCCODE
  End With
End Sub
Private Sub TA132B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA132.SbpScreen.Text = "TA132B"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim WrkDesc As String
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode1.Text), "R")
    If Mid(WrkDesc, 1, 1) = "*" Then
      ErrorField(I) = "1"
      ErrorMsg(I) = "Invalid Assessment Code"
      I = I + 1
    End If

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode2.Text), "R")
    If Mid(WrkDesc, 1, 1) = "*" Then
      ErrorField(I) = "2"
      ErrorMsg(I) = "Invalid Assessment Code"
      I = I + 1
    End If

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode3.Text), "R")
    If Mid(WrkDesc, 1, 1) = "*" Then
      ErrorField(I) = "3"
      ErrorMsg(I) = "Invalid Assessment Code"
      I = I + 1
    End If

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode4.Text), "R")
    If Mid(WrkDesc, 1, 1) = "*" Then
      ErrorField(I) = "4"
      ErrorMsg(I) = "Invalid Assessment Code"
      I = I + 1
    End If

    If TxtCode1.Text = TxtCode2.Text Or TxtCode1.Text = TxtCode3.Text Or _
       TxtCode1.Text = TxtCode4.Text Or TxtCode2.Text = TxtCode3.Text Or _
       TxtCode2.Text = TxtCode4.Text Or TxtCode3.Text = TxtCode4.Text Then
      ErrorField(I) = "dup"
      ErrorMsg(I) = "Duplicate Code Entered"
      I = I + 1
    End If
  End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtCode1, "")
  ErrProv.SetError(TxtCode2, "")
  ErrProv.SetError(TxtCode3, "")
  ErrProv.SetError(TxtCode4, "")
  For I = 0 To ErrorField.GetUpperBound(0)
     Select Case ErrorField(I)
       Case "1", "dup"
         ErrProv.SetError(TxtCode1, ErrorMsg(I))
       Case "2"
         ErrProv.SetError(TxtCode2, ErrorMsg(I))
       Case "3"
         ErrProv.SetError(TxtCode3, ErrorMsg(I))
       Case "4"
         ErrProv.SetError(TxtCode4, ErrorMsg(I))
       Case Nothing
         Exit Sub
     End Select
     Next I
End Sub
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
Public Function CheckErrors() As Boolean
  Array.Clear(ErrorField, 0, 25)
  Array.Clear(ErrorMsg, 0, 25)
  EditChecks(ErrorField, ErrorMsg)
  ShowError(ErrorField, ErrorMsg)
  If Not IsNothing(ErrorMsg(0)) Then
    Return True
  End If
  Return False
End Function
Public Sub SaveData(ByVal WrkSeq As Integer, ByVal WrkCode As Integer)
  myTXCDAG.GetOneRecordP(WrkSeq)
  MovetoFile(WrkCode)
  ' added this too
  If myTXCDAG.RecordNotFound Then
    myTXCDAG._TCSEQ = WrkSeq
    myTXCDAG.AddOneRecordP()
  Else
    myTXCDAG.UpdateOneRecordP()
  End If
  End Sub
Private Sub MovetoFile(ByVal WrkCode As Integer)
  With myTXCDAG
    ._TCCODE = WrkCode
  End With
End Sub
Private Sub LnkCodeAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode1.LinkClicked
  MyFrmListCodes = New FrmListCodes
  MyFrmListCodes.MdiParent = Me.ParentForm
  MyFrmListCodes.WrkType = "R"
  MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode1.Text)
  MyFrmListCodes.WrkField = "1"
  MyFrmListCodes.Show()
  Me.Hide()
End Sub
Private Sub LnkCodeFarm_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode2.LinkClicked
  MyFrmListCodes = New FrmListCodes
  MyFrmListCodes.MdiParent = Me.ParentForm
  MyFrmListCodes.WrkType = "R"
  MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode1.Text)
  MyFrmListCodes.WrkField = "2"
  MyFrmListCodes.Show()
  Me.Hide()
End Sub
Private Sub LnkCodeForest_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode3.LinkClicked
  MyFrmListCodes = New FrmListCodes
  MyFrmListCodes.MdiParent = Me.ParentForm
  MyFrmListCodes.WrkType = "R"
  MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode1.Text)
  MyFrmListCodes.WrkField = "3"
  MyFrmListCodes.Show()
  Me.Hide()
End Sub
Private Sub LnkCodeOpen_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode4.LinkClicked
  MyFrmListCodes = New FrmListCodes
  MyFrmListCodes.MdiParent = Me.ParentForm
  MyFrmListCodes.WrkType = "R"
  MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode1.Text)
  MyFrmListCodes.WrkField = "4"
  MyFrmListCodes.Show()
  Me.Hide()
End Sub
End Class






