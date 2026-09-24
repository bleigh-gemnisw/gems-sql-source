Public Class FrmTA131B
  Inherits System.Windows.Forms.Form
  Dim myTXCDSF As TXCDSF.myData
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
    Friend WithEvents LnkCodeAll As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtCodeAll As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LnkCodeFarm As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtCodeFarm As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LnkCodeOpen As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtCodeOpen As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LnkCodeForest As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtCodeForest As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LnkCode10Mil As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtCode10Mil As System.Windows.Forms.TextBox
    Friend WithEvents label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.label3 = New System.Windows.Forms.Label()
    Me.LnkCodeAll = New System.Windows.Forms.LinkLabel()
    Me.TxtCodeAll = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.LnkCodeFarm = New System.Windows.Forms.LinkLabel()
    Me.TxtCodeFarm = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.LnkCodeForest = New System.Windows.Forms.LinkLabel()
    Me.TxtCodeForest = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.LnkCodeOpen = New System.Windows.Forms.LinkLabel()
    Me.TxtCodeOpen = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.LnkCode10Mil = New System.Windows.Forms.LinkLabel()
    Me.TxtCode10Mil = New System.Windows.Forms.TextBox()
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
    'LnkCodeAll
    '
    Me.LnkCodeAll.AutoSize = True
    Me.LnkCodeAll.Location = New System.Drawing.Point(82, 21)
    Me.LnkCodeAll.Name = "LnkCodeAll"
    Me.LnkCodeAll.Size = New System.Drawing.Size(32, 13)
    Me.LnkCodeAll.TabIndex = 18
    Me.LnkCodeAll.TabStop = True
    Me.LnkCodeAll.Text = "Code"
    '
    'TxtCodeAll
    '
    Me.TxtCodeAll.Location = New System.Drawing.Point(120, 18)
    Me.TxtCodeAll.MaxLength = 3
    Me.TxtCodeAll.Name = "TxtCodeAll"
    Me.TxtCodeAll.Size = New System.Drawing.Size(25, 20)
    Me.TxtCodeAll.TabIndex = 19
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
    Me.Label2.Size = New System.Drawing.Size(18, 13)
    Me.Label2.TabIndex = 21
    Me.Label2.Text = "All"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(40, 47)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(30, 13)
    Me.Label4.TabIndex = 24
    Me.Label4.Text = "Farm"
    '
    'LnkCodeFarm
    '
    Me.LnkCodeFarm.AutoSize = True
    Me.LnkCodeFarm.Location = New System.Drawing.Point(82, 47)
    Me.LnkCodeFarm.Name = "LnkCodeFarm"
    Me.LnkCodeFarm.Size = New System.Drawing.Size(32, 13)
    Me.LnkCodeFarm.TabIndex = 22
    Me.LnkCodeFarm.TabStop = True
    Me.LnkCodeFarm.Text = "Code"
    '
    'TxtCodeFarm
    '
    Me.TxtCodeFarm.Location = New System.Drawing.Point(120, 44)
    Me.TxtCodeFarm.MaxLength = 3
    Me.TxtCodeFarm.Name = "TxtCodeFarm"
    Me.TxtCodeFarm.Size = New System.Drawing.Size(25, 20)
    Me.TxtCodeFarm.TabIndex = 23
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(40, 73)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(36, 13)
    Me.Label5.TabIndex = 27
    Me.Label5.Text = "Forest"
    '
    'LnkCodeForest
    '
    Me.LnkCodeForest.AutoSize = True
    Me.LnkCodeForest.Location = New System.Drawing.Point(82, 73)
    Me.LnkCodeForest.Name = "LnkCodeForest"
    Me.LnkCodeForest.Size = New System.Drawing.Size(32, 13)
    Me.LnkCodeForest.TabIndex = 25
    Me.LnkCodeForest.TabStop = True
    Me.LnkCodeForest.Text = "Code"
    '
    'TxtCodeForest
    '
    Me.TxtCodeForest.Location = New System.Drawing.Point(120, 70)
    Me.TxtCodeForest.MaxLength = 3
    Me.TxtCodeForest.Name = "TxtCodeForest"
    Me.TxtCodeForest.Size = New System.Drawing.Size(25, 20)
    Me.TxtCodeForest.TabIndex = 26
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(40, 97)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(33, 13)
    Me.Label6.TabIndex = 30
    Me.Label6.Text = "Open"
    '
    'LnkCodeOpen
    '
    Me.LnkCodeOpen.AutoSize = True
    Me.LnkCodeOpen.Location = New System.Drawing.Point(82, 97)
    Me.LnkCodeOpen.Name = "LnkCodeOpen"
    Me.LnkCodeOpen.Size = New System.Drawing.Size(32, 13)
    Me.LnkCodeOpen.TabIndex = 28
    Me.LnkCodeOpen.TabStop = True
    Me.LnkCodeOpen.Text = "Code"
    '
    'TxtCodeOpen
    '
    Me.TxtCodeOpen.Location = New System.Drawing.Point(120, 94)
    Me.TxtCodeOpen.MaxLength = 3
    Me.TxtCodeOpen.Name = "TxtCodeOpen"
    Me.TxtCodeOpen.Size = New System.Drawing.Size(25, 20)
    Me.TxtCodeOpen.TabIndex = 29
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(40, 120)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(35, 13)
    Me.Label7.TabIndex = 33
    Me.Label7.Text = "10 Mil"
    '
    'LnkCode10Mil
    '
    Me.LnkCode10Mil.AutoSize = True
    Me.LnkCode10Mil.Location = New System.Drawing.Point(82, 120)
    Me.LnkCode10Mil.Name = "LnkCode10Mil"
    Me.LnkCode10Mil.Size = New System.Drawing.Size(32, 13)
    Me.LnkCode10Mil.TabIndex = 31
    Me.LnkCode10Mil.TabStop = True
    Me.LnkCode10Mil.Text = "Code"
    '
    'TxtCode10Mil
    '
    Me.TxtCode10Mil.Location = New System.Drawing.Point(120, 117)
    Me.TxtCode10Mil.MaxLength = 3
    Me.TxtCode10Mil.Name = "TxtCode10Mil"
    Me.TxtCode10Mil.Size = New System.Drawing.Size(25, 20)
    Me.TxtCode10Mil.TabIndex = 32
    '
    'FrmTA131B
    '
    Me.AllowDrop = True
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(181, 151)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.LnkCode10Mil)
    Me.Controls.Add(Me.TxtCode10Mil)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.LnkCodeOpen)
    Me.Controls.Add(Me.TxtCodeOpen)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.LnkCodeForest)
    Me.Controls.Add(Me.TxtCodeForest)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.LnkCodeFarm)
    Me.Controls.Add(Me.TxtCodeFarm)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LnkCodeAll)
    Me.Controls.Add(Me.TxtCodeAll)
    Me.Controls.Add(Me.label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA131B"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub TA131B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myTXCDSF = New TXCDSF.mydata(MyDBConnect)

  MyFrmTA131.TBarNew.Visible = False
  MyFrmTA131.TBarSave.Visible = True
  MyFrmTA131.TBarPrint.Visible = False
  MyFrmTA131.TBarDelete.Visible = False

  If s_chg = False And s_full = False Then    '#sec
    MyFrmTA131.TBarSave.Visible = False
  End If

  myTXCDSF.GetOneRecordP("ALL")
  If myTXCDSF.RecordNotFound Then Exit Sub

  With myTXCDSF
    TxtCodeAll.Text = ._TCCODE
  End With

  myTXCDSF.GetOneRecordP("FARM")
  With myTXCDSF
    TxtCodeFarm.Text = ._TCCODE
  End With

  myTXCDSF.GetOneRecordP("FORE")
  With myTXCDSF
    TxtCodeForest.Text = ._TCCODE
  End With

  myTXCDSF.GetOneRecordP("OPEN")
  With myTXCDSF
    TxtCodeOpen.Text = ._TCCODE
  End With

  myTXCDSF.GetOneRecordP("10ML")
  With myTXCDSF
    TxtCode10Mil.Text = ._TCCODE
  End With
End Sub
Private Sub TA131B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA131.SbpScreen.Text = "TA131B"
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

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCodeAll.Text), "R")
    If Mid(WrkDesc, 1, 1) = "*" Then
      ErrorField(I) = "all"
      ErrorMsg(I) = "Invalid Assessment Code"
      I = I + 1
    End If

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCodeFarm.Text), "R")
    If Mid(WrkDesc, 1, 1) = "*" Then
      ErrorField(I) = "farm"
      ErrorMsg(I) = "Invalid Assessment Code"
      I = I + 1
    End If

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCodeForest.Text), "R")
    If Mid(WrkDesc, 1, 1) = "*" Then
      ErrorField(I) = "fore"
      ErrorMsg(I) = "Invalid Assessment Code"
      I = I + 1
    End If

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCodeOpen.Text), "R")
    If Mid(WrkDesc, 1, 1) = "*" Then
      ErrorField(I) = "open"
      ErrorMsg(I) = "Invalid Assessment Code"
      I = I + 1
    End If

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode10Mil.Text), "R")
    If Mid(WrkDesc, 1, 1) = "*" Then
      ErrorField(I) = "10ml"
      ErrorMsg(I) = "Invalid Assessment Code"
      I = I + 1
    End If

    If TxtCodeAll.Text = TxtCodeFarm.Text Or TxtCodeAll.Text = TxtCodeForest.Text Or _
       TxtCodeAll.Text = TxtCodeOpen.Text Or TxtCodeFarm.Text = TxtCodeForest.Text Or _
       TxtCodeFarm.Text = TxtCodeOpen.Text Or TxtCodeForest.Text = TxtCodeOpen.Text Then
      ErrorField(I) = "dup"
      ErrorMsg(I) = "Duplicate Code Entered"
      I = I + 1
    End If
  End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtCodeAll, "")
  ErrProv.SetError(TxtCodeFarm, "")
  ErrProv.SetError(TxtCodeForest, "")
  ErrProv.SetError(TxtCodeOpen, "")
  ErrProv.SetError(TxtCode10Mil, "")
  For I = 0 To ErrorField.GetUpperBound(0)
     Select Case ErrorField(I)
       Case "all", "dup"
         ErrProv.SetError(TxtCodeAll, ErrorMsg(I))
       Case "farm"
         ErrProv.SetError(TxtCodeFarm, ErrorMsg(I))
       Case "fore"
         ErrProv.SetError(TxtCodeForest, ErrorMsg(I))
       Case "open"
         ErrProv.SetError(TxtCodeOpen, ErrorMsg(I))
       Case "10ml"
         ErrProv.SetError(TxtCodeOpen, ErrorMsg(I))
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
Public Sub SaveData(ByVal WrkRpt As String, ByVal WrkCode As Integer)
  myTXCDSF.GetOneRecordP(WrkRpt)
  MovetoFile(WrkCode)
  ' added this too
  If myTXCDSF.RecordNotFound Then
    myTXCDSF._TCRPT = WrkRpt
    myTXCDSF.AddOneRecordP()
  Else
    myTXCDSF.UpdateOneRecordP()
  End If
  End Sub
Private Sub MovetoFile(ByVal WrkCode As Integer)
  With myTXCDSF
    ._TCCODE = WrkCode
  End With
End Sub
Private Sub LnkCodeAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCodeAll.LinkClicked
  MyFrmListCodes = New FrmListCodes
  MyFrmListCodes.MdiParent = Me.ParentForm
  MyFrmListCodes.WrkType = "R"
  MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCodeAll.Text)
  MyFrmListCodes.WrkField = "ALL"
  MyFrmListCodes.Show()
  Me.Hide()
End Sub
Private Sub LnkCodeFarm_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCodeFarm.LinkClicked
  MyFrmListCodes = New FrmListCodes
  MyFrmListCodes.MdiParent = Me.ParentForm
  MyFrmListCodes.WrkType = "R"
  MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCodeAll.Text)
  MyFrmListCodes.WrkField = "FARM"
  MyFrmListCodes.Show()
  Me.Hide()
End Sub
Private Sub LnkCodeForest_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCodeForest.LinkClicked
  MyFrmListCodes = New FrmListCodes
  MyFrmListCodes.MdiParent = Me.ParentForm
  MyFrmListCodes.WrkType = "R"
  MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCodeAll.Text)
  MyFrmListCodes.WrkField = "FORE"
  MyFrmListCodes.Show()
  Me.Hide()
End Sub
Private Sub LnkCodeOpen_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCodeOpen.LinkClicked
  MyFrmListCodes = New FrmListCodes
  MyFrmListCodes.MdiParent = Me.ParentForm
  MyFrmListCodes.WrkType = "R"
  MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCodeAll.Text)
  MyFrmListCodes.WrkField = "OPEN"
  MyFrmListCodes.Show()
  Me.Hide()
End Sub
Private Sub LnkCode10Mil_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode10Mil.LinkClicked
  MyFrmListCodes = New FrmListCodes
  MyFrmListCodes.MdiParent = Me.ParentForm
  MyFrmListCodes.WrkType = "R"
  MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCodeAll.Text)
  MyFrmListCodes.WrkField = "10ML"
  MyFrmListCodes.Show()
  Me.Hide()
End Sub
End Class






