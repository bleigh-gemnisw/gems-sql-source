Public Class FrmUB430B
Inherits System.Windows.Forms.Form
Dim myUTTYPE As UTTYPE.myData
Dim myUTCUST As UTCUST.myData
Dim myUTCUSTAS As UTCUSTAS.myData
Dim myTXINV As TXINV.myData
Dim myTXPROF As TXPROF.myData
Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow

'Screen fields
Dim WrkYear As Integer
Dim WrkUBType As String
Dim WrkTaxType As String
Dim WrkListNo As Integer
Dim WrkFamily As String
Dim WrkDeferred As Decimal
Friend WithEvents LblDeferred As System.Windows.Forms.Label
Friend WithEvents Label21 As System.Windows.Forms.Label
Friend WithEvents BtnVerify As System.Windows.Forms.Button
Friend WithEvents BtnCreate As System.Windows.Forms.Button

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
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TxtYear As System.Windows.Forms.TextBox
Friend WithEvents TxtUBType As System.Windows.Forms.TextBox
Friend WithEvents LinkUBType As System.Windows.Forms.LinkLabel
Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
Friend WithEvents Label9 As System.Windows.Forms.Label
Friend WithEvents Label8 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TxtYear = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.TxtUBType = New System.Windows.Forms.TextBox
Me.LinkUBType = New System.Windows.Forms.LinkLabel
Me.Label8 = New System.Windows.Forms.Label
Me.TxtListNo = New System.Windows.Forms.TextBox
Me.Label9 = New System.Windows.Forms.Label
Me.LblDeferred = New System.Windows.Forms.Label
Me.Label21 = New System.Windows.Forms.Label
Me.BtnVerify = New System.Windows.Forms.Button
Me.BtnCreate = New System.Windows.Forms.Button
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'TxtYear
'
Me.TxtYear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtYear.Location = New System.Drawing.Point(86, 52)
Me.TxtYear.MaxLength = 4
Me.TxtYear.Name = "TxtYear"
Me.TxtYear.Size = New System.Drawing.Size(40, 22)
Me.TxtYear.TabIndex = 0
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(16, 56)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(64, 16)
Me.Label3.TabIndex = 52
Me.Label3.Text = "Billing Year"
'
'TxtUBType
'
Me.TxtUBType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtUBType.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtUBType.Location = New System.Drawing.Point(86, 80)
Me.TxtUBType.MaxLength = 2
Me.TxtUBType.Name = "TxtUBType"
Me.TxtUBType.Size = New System.Drawing.Size(24, 22)
Me.TxtUBType.TabIndex = 3
'
'LinkUBType
'
Me.LinkUBType.Location = New System.Drawing.Point(16, 84)
Me.LinkUBType.Name = "LinkUBType"
Me.LinkUBType.Size = New System.Drawing.Size(68, 16)
Me.LinkUBType.TabIndex = 71
Me.LinkUBType.TabStop = True
Me.LinkUBType.Text = "Bill Type"
'
'Label8
'
Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label8.ForeColor = System.Drawing.Color.Black
Me.Label8.Location = New System.Drawing.Point(16, 9)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(440, 32)
Me.Label8.TabIndex = 354
Me.Label8.Text = "This will create an informational Tax Invoice record for the Assessment deferred " & _
    "amount. This is an optional process and is for lookup purposes ONLY. "
'
'TxtListNo
'
Me.TxtListNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtListNo.Location = New System.Drawing.Point(86, 107)
Me.TxtListNo.MaxLength = 6
Me.TxtListNo.Name = "TxtListNo"
Me.TxtListNo.Size = New System.Drawing.Size(52, 22)
Me.TxtListNo.TabIndex = 355
'
'Label9
'
Me.Label9.Location = New System.Drawing.Point(16, 111)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(37, 18)
Me.Label9.TabIndex = 356
Me.Label9.Text = "List #"
'
'LblDeferred
'
Me.LblDeferred.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblDeferred.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LblDeferred.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblDeferred.Location = New System.Drawing.Point(206, 107)
Me.LblDeferred.Name = "LblDeferred"
Me.LblDeferred.Size = New System.Drawing.Size(72, 20)
Me.LblDeferred.TabIndex = 358
Me.LblDeferred.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label21
'
Me.Label21.AutoSize = True
Me.Label21.BackColor = System.Drawing.SystemColors.Control
Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label21.Location = New System.Drawing.Point(152, 111)
Me.Label21.Name = "Label21"
Me.Label21.Size = New System.Drawing.Size(48, 13)
Me.Label21.TabIndex = 357
Me.Label21.Text = "Deferred"
Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight
'
'BtnVerify
'
Me.BtnVerify.Location = New System.Drawing.Point(137, 150)
Me.BtnVerify.Name = "BtnVerify"
Me.BtnVerify.Size = New System.Drawing.Size(73, 30)
Me.BtnVerify.TabIndex = 359
Me.BtnVerify.Text = "Verify"
Me.BtnVerify.UseVisualStyleBackColor = True
'
'BtnCreate
'
Me.BtnCreate.Location = New System.Drawing.Point(228, 150)
Me.BtnCreate.Name = "BtnCreate"
Me.BtnCreate.Size = New System.Drawing.Size(73, 30)
Me.BtnCreate.TabIndex = 360
Me.BtnCreate.Text = "Create"
Me.BtnCreate.UseVisualStyleBackColor = True
'
'FrmUB430B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(444, 192)
Me.ControlBox = False
Me.Controls.Add(Me.BtnCreate)
Me.Controls.Add(Me.BtnVerify)
Me.Controls.Add(Me.LblDeferred)
Me.Controls.Add(Me.Label21)
Me.Controls.Add(Me.TxtListNo)
Me.Controls.Add(Me.Label9)
Me.Controls.Add(Me.Label8)
Me.Controls.Add(Me.LinkUBType)
Me.Controls.Add(Me.TxtUBType)
Me.Controls.Add(Me.TxtYear)
Me.Controls.Add(Me.Label3)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.KeyPreview = True
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmUB430B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

  Public Sub Verify()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    With MyFrmUB430B
      WrkYear = MyUtils.CnvSng(.TxtYear.Text)
      WrkUBType = .TxtUBType.Text
      WrkListNo = MyUtils.CnvSng(.TxtListNo.Text)
    End With
    WrkTaxType = GetUTTYPETaxType(WrkUBType)
    WrkFamily = GetUTTYPEFamily(WrkUBType)

    BtnCreate.Enabled = False
    LblDeferred.Text = ""
    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)
    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If

    Me.Refresh()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    myTXPROF.GetOneRecordP(WrkTaxType, WrkYear, "", 0)
    If myTXPROF.RecordNotFound Then
      MsgBox("Type: " & WrkUBType & vbCrLf & "Year: " & WrkYear, MsgBoxStyle.Critical, "Tax Profile missing")
      Exit Sub
    End If
    LblDeferred.Text = myUTCUSTAS._CADEF
    BtnCreate.Enabled = True
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
Private Sub WriteInvoice(ByVal WrkDeferred As Decimal)

  With myUTCUST
    myTXINV._ICODE = "I"
    myTXINV._DECD = "Y"
    myTXINV._LISTNo = WrkListNo
    myTXINV._YEAR = WrkYear
    myTXINV._TYPE = WrkUBType
    myTXINV._NAME = ._CUNAM1
    myTXINV._SNAME = ._CUNAM2
    If Trim(._CUMAD1) <> "" Then
      myTXINV._ADD1 = ._CUMAD1
      myTXINV._ADD2 = ._CUMAD2
      myTXINV._CITY = ._CUMCTY
      myTXINV._STATE = ._CUMST
      myTXINV._ZIP5 = MyUtils.CnvSng(Mid(._CUMZIP, 1, 5))
      If Len(._CUMZIP) > 5 Then
        myTXINV._ZIP4 = MyUtils.CnvSng(Mid(._CUMZIP, 7, 4))
      End If
    Else
      myTXINV._ADD1 = ._CUADD1
      myTXINV._ADD2 = ._CUADD2
      myTXINV._CITY = ._CUCITY
      myTXINV._STATE = ._CUST
      myTXINV._ZIP5 = MyUtils.CnvSng(Mid(._CUZIP, 1, 5))
      If Len(._CUZIP) > 5 Then
        myTXINV._ZIP4 = MyUtils.CnvSng(Mid(._CUZIP, 7, 4))
      End If
    End If
    myTXINV._DIST = 0
    myTXINV._PDST = ._CUDST
    myTXINV._TAXT = WrkDeferred
    myTXINV._TAX1 = WrkDeferred
    myTXINV._TAX2 = 0
    myTXINV._TX3RD = 0
    myTXINV._TX4TH = 0
    myTXINV._BALD = 0
    myTXINV._BOND = 0
    myTXINV._LOCNo = ._CULOCNO
    myTXINV._LOC = ._CULOC
    myTXINV._MAP = ._CUMAP
    myTXINV._VOL = ._CUVOLM
    myTXINV._IPAGE = ._CUPAGE
    myTXINV._LETT = Mid(._CUNAM1, 1, 1)
    If myTXINV.RecordNotFound Then
      myTXINV.AddOneRecordP()
    End If
  End With
End Sub
Private Sub FrmUB430B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myUTTYPE = New UTTYPE.mydata(MyDBConnect)
  myUTCUST = New UTCUST.mydata(MyDBConnect)
  myUTCUSTAS = New UTCUSTAS.mydata(MyDBConnect)
  myTXPROF = New TXPROF.mydata(MyDBConnect)
  myTXINV = New TXINV.mydata(MyDBConnect)
  BtnCreate.Enabled = False
End Sub
Private Sub FrmUB430B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB430.SbpScreen.Text = "UB430B"
End Sub
Private Sub FrmUB430B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtUBType, "")
    ErrProv.SetError(TxtYear, "")
    ErrProv.SetError(TxtListNo, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "ubtype"
        ErrProv.SetError(TxtUBType, ErrorMsg(I))
      Case "year"
        ErrProv.SetError(TxtYear, ErrorMsg(I))
      Case "txinv", "utcust", "utcustas", "defer"
        ErrProv.SetError(TxtListNo, ErrorMsg(I))
      Case Nothing
        Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim ds As DataSet = New DataSet
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtYear.Text) = 0 Then
      ErrorField(I) = "year"
      ErrorMsg(I) = "Invalid Year"
      I = I + 1
    End If

    myUTTYPE.GetOneRecordP(TxtUBType.Text)
    If myUTTYPE.RecordNotFound Then
      ErrorField(I) = "ubtype"
      ErrorMsg(I) = "Invalid Bill Type"
      I = I + 1
    End If

    myUTCUSTAS.GetOneRecordP(WrkListNo, WrkUBType)
    If myUTCUSTAS.RecordNotFound Then
      ErrorField(I) = "utcustas"
      ErrorMsg(I) = "No Assessment code"
      I = I + 1
    End If

    If Not myUTCUSTAS.RecordNotFound Then
      If myUTCUSTAS._CADEF = 0 Then
        ErrorField(I) = "defer"
        ErrorMsg(I) = "No Deferred amount"
        I = I + 1
      End If
    End If

    myUTCUST.GetOneRecordP(WrkListNo)
    If myUTCUST.RecordNotFound Then
      ErrorField(I) = "utcust"
      ErrorMsg(I) = "UB Customer record not found"
      I = I + 1
    End If

    myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkTaxType)
    If Not myTXINV.RecordNotFound Then
      ErrorField(I) = "txinv"
      ErrorMsg(I) = "Invoice record exists"
      I = I + 1
    End If
  End Sub
Private Sub TxtYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtListNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub LinkUBType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkUBType.LinkClicked
  MyFrmListUBType = New FrmListUBType
  MyFrmListUBType.MdiParent = Me.ParentForm
  MyFrmListUBType.WrkType = TxtUBType.Text
  MyFrmListUBType.Show()
  Me.Hide()
End Sub
Private Sub BtnVerify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVerify.Click
  Verify()
End Sub
Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
  Verify()
  If LblDeferred.Text = "" Then Exit Sub
  WriteInvoice(LblDeferred.Text)
  LblDeferred.Text = ""
  BtnCreate.Enabled = False
End Sub
End Class







