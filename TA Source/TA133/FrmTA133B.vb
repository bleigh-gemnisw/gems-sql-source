Public Class FrmTA133B
  Inherits System.Windows.Forms.Form
  Dim myTXHOIN As TXHOIN.myData
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtYear As System.Windows.Forms.TextBox
    Friend WithEvents BtnShow As System.Windows.Forms.Button
    Friend WithEvents GrpData As System.Windows.Forms.GroupBox
    Friend WithEvents TxtUPct1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtLimit1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtMPct4 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtMPct3 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtMPct2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtMPct1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtUPct4 As System.Windows.Forms.TextBox
    Friend WithEvents TxtUPct3 As System.Windows.Forms.TextBox
    Friend WithEvents TxtUPct2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtLimit4 As System.Windows.Forms.TextBox
    Friend WithEvents TxtLimit3 As System.Windows.Forms.TextBox
    Friend WithEvents TxtLimit2 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtUPct5 As System.Windows.Forms.TextBox
    Friend WithEvents TxtLimit5 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtMPct5 As System.Windows.Forms.TextBox
    Friend WithEvents label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.label3 = New System.Windows.Forms.Label
Me.TxtYear = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.BtnShow = New System.Windows.Forms.Button
Me.GrpData = New System.Windows.Forms.GroupBox
Me.Label13 = New System.Windows.Forms.Label
Me.Label12 = New System.Windows.Forms.Label
Me.Label11 = New System.Windows.Forms.Label
Me.Label10 = New System.Windows.Forms.Label
Me.TxtUPct4 = New System.Windows.Forms.TextBox
Me.TxtUPct3 = New System.Windows.Forms.TextBox
Me.TxtUPct2 = New System.Windows.Forms.TextBox
Me.TxtLimit4 = New System.Windows.Forms.TextBox
Me.TxtLimit3 = New System.Windows.Forms.TextBox
Me.TxtLimit2 = New System.Windows.Forms.TextBox
Me.Label9 = New System.Windows.Forms.Label
Me.Label8 = New System.Windows.Forms.Label
Me.Label7 = New System.Windows.Forms.Label
Me.TxtUPct1 = New System.Windows.Forms.TextBox
Me.TxtLimit1 = New System.Windows.Forms.TextBox
Me.Label6 = New System.Windows.Forms.Label
Me.TxtMPct4 = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
Me.TxtMPct3 = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.TxtMPct2 = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.TxtMPct1 = New System.Windows.Forms.TextBox
Me.TxtUPct5 = New System.Windows.Forms.TextBox
Me.TxtLimit5 = New System.Windows.Forms.TextBox
Me.Label14 = New System.Windows.Forms.Label
Me.TxtMPct5 = New System.Windows.Forms.TextBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GrpData.SuspendLayout()
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
'TxtYear
'
Me.TxtYear.Location = New System.Drawing.Point(61, 12)
Me.TxtYear.MaxLength = 4
Me.TxtYear.Name = "TxtYear"
Me.TxtYear.Size = New System.Drawing.Size(35, 20)
Me.TxtYear.TabIndex = 0
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(26, 15)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(29, 13)
Me.Label1.TabIndex = 34
Me.Label1.Text = "Year"
'
'BtnShow
'
Me.BtnShow.Location = New System.Drawing.Point(106, 12)
Me.BtnShow.Name = "BtnShow"
Me.BtnShow.Size = New System.Drawing.Size(48, 19)
Me.BtnShow.TabIndex = 1
Me.BtnShow.Text = "Show"
Me.BtnShow.UseVisualStyleBackColor = True
'
'GrpData
'
Me.GrpData.Controls.Add(Me.TxtUPct5)
Me.GrpData.Controls.Add(Me.TxtLimit5)
Me.GrpData.Controls.Add(Me.Label14)
Me.GrpData.Controls.Add(Me.TxtMPct5)
Me.GrpData.Controls.Add(Me.Label13)
Me.GrpData.Controls.Add(Me.Label12)
Me.GrpData.Controls.Add(Me.Label11)
Me.GrpData.Controls.Add(Me.Label10)
Me.GrpData.Controls.Add(Me.TxtUPct4)
Me.GrpData.Controls.Add(Me.TxtUPct3)
Me.GrpData.Controls.Add(Me.TxtUPct2)
Me.GrpData.Controls.Add(Me.TxtLimit4)
Me.GrpData.Controls.Add(Me.TxtLimit3)
Me.GrpData.Controls.Add(Me.TxtLimit2)
Me.GrpData.Controls.Add(Me.Label9)
Me.GrpData.Controls.Add(Me.Label8)
Me.GrpData.Controls.Add(Me.Label7)
Me.GrpData.Controls.Add(Me.TxtUPct1)
Me.GrpData.Controls.Add(Me.TxtLimit1)
Me.GrpData.Controls.Add(Me.Label6)
Me.GrpData.Controls.Add(Me.TxtMPct4)
Me.GrpData.Controls.Add(Me.Label5)
Me.GrpData.Controls.Add(Me.TxtMPct3)
Me.GrpData.Controls.Add(Me.Label4)
Me.GrpData.Controls.Add(Me.TxtMPct2)
Me.GrpData.Controls.Add(Me.Label2)
Me.GrpData.Controls.Add(Me.TxtMPct1)
Me.GrpData.Location = New System.Drawing.Point(12, 49)
Me.GrpData.Name = "GrpData"
Me.GrpData.Size = New System.Drawing.Size(208, 187)
Me.GrpData.TabIndex = 36
Me.GrpData.TabStop = False
'
'Label13
'
Me.Label13.AutoSize = True
Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label13.Location = New System.Drawing.Point(156, 35)
Me.Label13.Name = "Label13"
Me.Label13.Size = New System.Drawing.Size(23, 13)
Me.Label13.TabIndex = 5
Me.Label13.Text = "Pct"
'
'Label12
'
Me.Label12.AutoSize = True
Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label12.Location = New System.Drawing.Point(139, 16)
Me.Label12.Name = "Label12"
Me.Label12.Size = New System.Drawing.Size(55, 13)
Me.Label12.TabIndex = 2
Me.Label12.Text = "Unmarried"
'
'Label11
'
Me.Label11.AutoSize = True
Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label11.Location = New System.Drawing.Point(102, 35)
Me.Label11.Name = "Label11"
Me.Label11.Size = New System.Drawing.Size(23, 13)
Me.Label11.TabIndex = 4
Me.Label11.Text = "Pct"
'
'Label10
'
Me.Label10.AutoSize = True
Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label10.Location = New System.Drawing.Point(96, 16)
Me.Label10.Name = "Label10"
Me.Label10.Size = New System.Drawing.Size(42, 13)
Me.Label10.TabIndex = 1
Me.Label10.Text = "Married"
'
'TxtUPct4
'
Me.TxtUPct4.Location = New System.Drawing.Point(154, 132)
Me.TxtUPct4.MaxLength = 2
Me.TxtUPct4.Name = "TxtUPct4"
Me.TxtUPct4.Size = New System.Drawing.Size(25, 20)
Me.TxtUPct4.TabIndex = 17
Me.TxtUPct4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'TxtUPct3
'
Me.TxtUPct3.Location = New System.Drawing.Point(154, 108)
Me.TxtUPct3.MaxLength = 2
Me.TxtUPct3.Name = "TxtUPct3"
Me.TxtUPct3.Size = New System.Drawing.Size(25, 20)
Me.TxtUPct3.TabIndex = 14
Me.TxtUPct3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'TxtUPct2
'
Me.TxtUPct2.Location = New System.Drawing.Point(154, 82)
Me.TxtUPct2.MaxLength = 2
Me.TxtUPct2.Name = "TxtUPct2"
Me.TxtUPct2.Size = New System.Drawing.Size(25, 20)
Me.TxtUPct2.TabIndex = 11
Me.TxtUPct2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'TxtLimit4
'
Me.TxtLimit4.Location = New System.Drawing.Point(37, 132)
Me.TxtLimit4.MaxLength = 5
Me.TxtLimit4.Name = "TxtLimit4"
Me.TxtLimit4.Size = New System.Drawing.Size(47, 20)
Me.TxtLimit4.TabIndex = 15
Me.TxtLimit4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'TxtLimit3
'
Me.TxtLimit3.Location = New System.Drawing.Point(37, 108)
Me.TxtLimit3.MaxLength = 5
Me.TxtLimit3.Name = "TxtLimit3"
Me.TxtLimit3.Size = New System.Drawing.Size(47, 20)
Me.TxtLimit3.TabIndex = 12
Me.TxtLimit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'TxtLimit2
'
Me.TxtLimit2.Location = New System.Drawing.Point(37, 82)
Me.TxtLimit2.MaxLength = 5
Me.TxtLimit2.Name = "TxtLimit2"
Me.TxtLimit2.Size = New System.Drawing.Size(47, 20)
Me.TxtLimit2.TabIndex = 9
Me.TxtLimit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label9
'
Me.Label9.AutoSize = True
Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label9.Location = New System.Drawing.Point(46, 35)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(28, 13)
Me.Label9.TabIndex = 3
Me.Label9.Text = "Limit"
'
'Label8
'
Me.Label8.AutoSize = True
Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label8.Location = New System.Drawing.Point(39, 16)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(45, 13)
Me.Label8.TabIndex = 0
Me.Label8.Text = "Income "
'
'Label7
'
Me.Label7.AutoSize = True
Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label7.Location = New System.Drawing.Point(6, 35)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(25, 13)
Me.Label7.TabIndex = 43
Me.Label7.Text = "Tier"
'
'TxtUPct1
'
Me.TxtUPct1.Location = New System.Drawing.Point(154, 56)
Me.TxtUPct1.MaxLength = 2
Me.TxtUPct1.Name = "TxtUPct1"
Me.TxtUPct1.Size = New System.Drawing.Size(25, 20)
Me.TxtUPct1.TabIndex = 8
Me.TxtUPct1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'TxtLimit1
'
Me.TxtLimit1.Location = New System.Drawing.Point(37, 56)
Me.TxtLimit1.MaxLength = 5
Me.TxtLimit1.Name = "TxtLimit1"
Me.TxtLimit1.Size = New System.Drawing.Size(47, 20)
Me.TxtLimit1.TabIndex = 6
Me.TxtLimit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label6
'
Me.Label6.AutoSize = True
Me.Label6.Location = New System.Drawing.Point(10, 135)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(13, 13)
Me.Label6.TabIndex = 40
Me.Label6.Text = "4"
'
'TxtMPct4
'
Me.TxtMPct4.Location = New System.Drawing.Point(100, 132)
Me.TxtMPct4.MaxLength = 2
Me.TxtMPct4.Name = "TxtMPct4"
Me.TxtMPct4.Size = New System.Drawing.Size(25, 20)
Me.TxtMPct4.TabIndex = 16
Me.TxtMPct4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label5
'
Me.Label5.AutoSize = True
Me.Label5.Location = New System.Drawing.Point(10, 111)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(13, 13)
Me.Label5.TabIndex = 38
Me.Label5.Text = "3"
'
'TxtMPct3
'
Me.TxtMPct3.Location = New System.Drawing.Point(100, 108)
Me.TxtMPct3.MaxLength = 2
Me.TxtMPct3.Name = "TxtMPct3"
Me.TxtMPct3.Size = New System.Drawing.Size(25, 20)
Me.TxtMPct3.TabIndex = 13
Me.TxtMPct3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label4
'
Me.Label4.AutoSize = True
Me.Label4.Location = New System.Drawing.Point(10, 85)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(13, 13)
Me.Label4.TabIndex = 36
Me.Label4.Text = "2"
'
'TxtMPct2
'
Me.TxtMPct2.Location = New System.Drawing.Point(100, 82)
Me.TxtMPct2.MaxLength = 2
Me.TxtMPct2.Name = "TxtMPct2"
Me.TxtMPct2.Size = New System.Drawing.Size(25, 20)
Me.TxtMPct2.TabIndex = 10
Me.TxtMPct2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label2
'
Me.Label2.AutoSize = True
Me.Label2.Location = New System.Drawing.Point(10, 59)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(13, 13)
Me.Label2.TabIndex = 34
Me.Label2.Text = "1"
'
'TxtMPct1
'
Me.TxtMPct1.Location = New System.Drawing.Point(100, 56)
Me.TxtMPct1.MaxLength = 2
Me.TxtMPct1.Name = "TxtMPct1"
Me.TxtMPct1.Size = New System.Drawing.Size(25, 20)
Me.TxtMPct1.TabIndex = 7
Me.TxtMPct1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'TxtUPct5
'
Me.TxtUPct5.Location = New System.Drawing.Point(154, 158)
Me.TxtUPct5.MaxLength = 2
Me.TxtUPct5.Name = "TxtUPct5"
Me.TxtUPct5.Size = New System.Drawing.Size(25, 20)
Me.TxtUPct5.TabIndex = 46
Me.TxtUPct5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'TxtLimit5
'
Me.TxtLimit5.Location = New System.Drawing.Point(37, 158)
Me.TxtLimit5.MaxLength = 5
Me.TxtLimit5.Name = "TxtLimit5"
Me.TxtLimit5.Size = New System.Drawing.Size(47, 20)
Me.TxtLimit5.TabIndex = 44
Me.TxtLimit5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label14
'
Me.Label14.AutoSize = True
Me.Label14.Location = New System.Drawing.Point(10, 161)
Me.Label14.Name = "Label14"
Me.Label14.Size = New System.Drawing.Size(13, 13)
Me.Label14.TabIndex = 47
Me.Label14.Text = "5"
'
'TxtMPct5
'
Me.TxtMPct5.Location = New System.Drawing.Point(100, 158)
Me.TxtMPct5.MaxLength = 2
Me.TxtMPct5.Name = "TxtMPct5"
Me.TxtMPct5.Size = New System.Drawing.Size(25, 20)
Me.TxtMPct5.TabIndex = 45
Me.TxtMPct5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'FrmTA133B
'
Me.AllowDrop = True
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(243, 262)
Me.ControlBox = False
Me.Controls.Add(Me.GrpData)
Me.Controls.Add(Me.BtnShow)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.TxtYear)
Me.Controls.Add(Me.label3)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA133B"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GrpData.ResumeLayout(False)
Me.GrpData.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub TA133B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myTXHOIN = New TXHOIN.mydata(MyDBConnect)

  MyFrmTA133.TBarNew.Visible = False
  MyFrmTA133.TBarSave.Visible = True
  MyFrmTA133.TBarDelete.Visible = False

  If s_chg = False And s_full = False Then    '#sec
    MyFrmTA133.TBarSave.Visible = False
  End If
  GrpData.Enabled = False

End Sub
Private Sub LoadForm(ByVal WrkYear As Integer)
  myTXHOIN.GetOneRecordP(WrkYear, 1)
  If myTXHOIN.RecordNotFound Then
    If TxtLimit1.Text = "" Then
      MsgBox("Tip: you can copy a previous year by viewing it and then key in new year. Screen data is not cleared.", MsgBoxStyle.Exclamation, "Year not found")
    Else
      MsgBox("Change values as needed and save ", MsgBoxStyle.Exclamation, "Year not found")
    End If
    Exit Sub
  End If

  With myTXHOIN
    TxtLimit1.Text = ._LIMIT
    TxtMPct1.Text = MyUtils.Round(._MPERC * 100, 0)
    TxtUPct1.Text = MyUtils.Round(._UPERC * 100, 0)
  End With

  myTXHOIN.GetOneRecordP(WrkYear, 2)
  With myTXHOIN
    TxtLimit2.Text = ._LIMIT
    TxtMPct2.Text = MyUtils.Round(._MPERC * 100, 0)
    TxtUPct2.Text = MyUtils.Round(._UPERC * 100, 0)
  End With

  myTXHOIN.GetOneRecordP(WrkYear, 3)
  With myTXHOIN
    TxtLimit3.Text = ._LIMIT
    TxtMPct3.Text = MyUtils.Round(._MPERC * 100, 0)
    TxtUPct3.Text = MyUtils.Round(._UPERC * 100, 0)
  End With

  myTXHOIN.GetOneRecordP(WrkYear, 4)
  With myTXHOIN
    TxtLimit4.Text = ._LIMIT
    TxtMPct4.Text = MyUtils.Round(._MPERC * 100, 0)
    TxtUPct4.Text = MyUtils.Round(._UPERC * 100, 0)
  End With

  myTXHOIN.GetOneRecordP(WrkYear, 5)
  With myTXHOIN
    TxtLimit5.Text = ._LIMIT
    TxtMPct5.Text = MyUtils.Round(._MPERC * 100, 0)
    TxtUPct5.Text = MyUtils.Round(._UPERC * 100, 0)
  End With
End Sub

Private Sub TA133B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA133.SbpScreen.Text = "TA133B"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtLimit2.Text) > 0 And _
      MyUtils.CnvSng(TxtLimit1.Text) > MyUtils.CnvSng(TxtLimit2.Text) Then
        ErrorField(I) = "2"
        ErrorMsg(I) = "Limit must be greater than previous Tier"
        I = I + 1
    End If

    If MyUtils.CnvSng(TxtLimit3.Text) > 0 And _
      MyUtils.CnvSng(TxtLimit2.Text) > MyUtils.CnvSng(TxtLimit3.Text) Then
        ErrorField(I) = "3"
        ErrorMsg(I) = "Limit must be greater than previous Tier"
        I = I + 1
    End If

    If MyUtils.CnvSng(TxtLimit4.Text) > 0 And _
      MyUtils.CnvSng(TxtLimit3.Text) > MyUtils.CnvSng(TxtLimit4.Text) Then
        ErrorField(I) = "4"
        ErrorMsg(I) = "Limit must be greater than previous Tier"
        I = I + 1
    End If

    If MyUtils.CnvSng(TxtLimit5.Text) > 0 And _
      MyUtils.CnvSng(TxtLimit4.Text) > MyUtils.CnvSng(TxtLimit5.Text) Then
        ErrorField(I) = "5"
        ErrorMsg(I) = "Limit must be greater than previous Tier"
        I = I + 1
    End If
  End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtLimit2, "")
  ErrProv.SetError(TxtLimit3, "")
  ErrProv.SetError(TxtLimit4, "")
  ErrProv.SetError(TxtLimit5, "")
  For I = 0 To ErrorField.GetUpperBound(0)
     Select Case ErrorField(I)
       Case "2"
         ErrProv.SetError(TxtLimit2, ErrorMsg(I))
       Case "3"
         ErrProv.SetError(TxtLimit3, ErrorMsg(I))
       Case "4"
         ErrProv.SetError(TxtLimit4, ErrorMsg(I))
       Case "5"
         ErrProv.SetError(TxtLimit5, ErrorMsg(I))
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
Public Sub SaveData(ByVal WrkYear As Integer, ByVal WrkTier As Integer, ByVal WrkLimit As Integer, _
  ByVal WrkMPct As Integer, ByVal WrkUPct As Integer)
  myTXHOIN.GetOneRecordP(WrkYear, WrkTier)
  With myTXHOIN
    ._LIMIT = WrkLimit
    ._MPERC = WrkMPct / 100
    ._UPERC = WrkUPct / 100
  End With
  ' added this too
  If myTXHOIN.RecordNotFound Then
    myTXHOIN._YEAR = WrkYear
    myTXHOIN._TIER = WrkTier
    myTXHOIN.AddOneRecordP()
  Else
    myTXHOIN.UpdateOneRecordP()
  End If
  End Sub
Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
  ShowData()
End Sub
Private Sub ShowData()
  If MyUtils.CnvSng(TxtYear.Text) = 0 Then Exit Sub

  GrpData.Enabled = True
  TxtYear.Enabled = False
  LoadForm(MyUtils.CnvSng(TxtYear.Text))
End Sub
  Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)

    If e.KeyChar = MyUtils.VbKeyEnter Then
      ShowData()
    End If
  End Sub
  Private Sub TxtLimit1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLimit1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtMPct1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMPct1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtUPct1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUPct1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtLimit2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLimit2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtMPct2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMPct2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtUPct2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUPct2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtLimit3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLimit3.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtMPct3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMPct3.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtUPct3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUPct3.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtLimit4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLimit4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtMPct4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMPct4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtUPct4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUPct4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtLimit5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLimit5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtMPct5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMPct5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtUPct5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUPct5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
End Class






