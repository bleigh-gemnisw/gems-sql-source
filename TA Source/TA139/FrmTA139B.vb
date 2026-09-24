Public Class FrmTA139B
  Inherits System.Windows.Forms.Form
  Dim myTXLOCDA As TXLOCDA.MyData
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
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
  Friend WithEvents TxtMaxTax As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TxtTRF As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents label3 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.label3 = New System.Windows.Forms.Label()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.BtnShow = New System.Windows.Forms.Button()
    Me.GrpData = New System.Windows.Forms.GroupBox()
    Me.TxtTRF = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtMaxTax = New System.Windows.Forms.TextBox()
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
    Me.GrpData.Controls.Add(Me.TxtTRF)
    Me.GrpData.Controls.Add(Me.Label4)
    Me.GrpData.Controls.Add(Me.Label9)
    Me.GrpData.Controls.Add(Me.Label8)
    Me.GrpData.Controls.Add(Me.TxtMaxTax)
    Me.GrpData.Location = New System.Drawing.Point(12, 53)
    Me.GrpData.Name = "GrpData"
    Me.GrpData.Size = New System.Drawing.Size(186, 112)
    Me.GrpData.TabIndex = 36
    Me.GrpData.TabStop = False
    '
    'TxtTRF
    '
    Me.TxtTRF.Location = New System.Drawing.Point(104, 56)
    Me.TxtTRF.MaxLength = 5
    Me.TxtTRF.Name = "TxtTRF"
    Me.TxtTRF.Size = New System.Drawing.Size(47, 20)
    Me.TxtTRF.TabIndex = 1
    Me.TxtTRF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(101, 35)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(60, 13)
    Me.Label4.TabIndex = 48
    Me.Label4.Text = "TRF Adjust"
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(44, 35)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(48, 13)
    Me.Label9.TabIndex = 3
    Me.Label9.Text = "Max Tax"
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(46, 16)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(33, 13)
    Me.Label8.TabIndex = 0
    Me.Label8.Text = "Local"
    '
    'TxtMaxTax
    '
    Me.TxtMaxTax.Location = New System.Drawing.Point(32, 56)
    Me.TxtMaxTax.MaxLength = 12
    Me.TxtMaxTax.Name = "TxtMaxTax"
    Me.TxtMaxTax.Size = New System.Drawing.Size(59, 20)
    Me.TxtMaxTax.TabIndex = 0
    Me.TxtMaxTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'FrmTA139B
    '
    Me.AllowDrop = True
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(210, 178)
    Me.ControlBox = False
    Me.Controls.Add(Me.GrpData)
    Me.Controls.Add(Me.BtnShow)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA139B"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpData.ResumeLayout(False)
    Me.GrpData.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub TA139B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXLOCDA = New TXLOCDA.MyData(myDBConnect)

    MyFrmTA139.TBarNew.Visible = False
    MyFrmTA139.TBarSave.Visible = True
    MyFrmTA139.TBarDelete.Visible = False

    If s_chg = False And s_full = False Then    '#sec
      MyFrmTA139.TBarSave.Visible = False
    End If
    GrpData.Enabled = False
  End Sub
  Private Sub LoadForm(ByVal WrkYear As Integer)
    myTXLOCDA.GetOneRecordP(WrkYear)
    If myTXLOCDA.RecordNotFound Then
      If TxtMaxTax.Text = "" Then
        MsgBox("Tip: you can copy a previous year by viewing it and then key in new year. Screen data is not cleared.", MsgBoxStyle.Exclamation, "Year not found")
      Else
        MsgBox("Change values as needed and save ", MsgBoxStyle.Exclamation, "Year not found")
      End If
      Exit Sub
    End If

    With myTXLOCDA
      TxtMaxTax.Text = ._MAXTAX
      TxtTRF.Text = ._TRFADJ
    End With
  End Sub

  Private Sub TA139B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA139.SbpScreen.Text = "TA139B"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
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
  Public Sub SaveData(ByVal WrkYear As Integer)
    myTXLOCDA.GetOneRecordP(WrkYear)
    With myTXLOCDA
      ._MAXTAX = MyUtils.CnvSng(TxtMaxTax.Text)
      ._TRFADJ = MyUtils.CnvSng(TxtTRF.Text)
    End With
    If myTXLOCDA.RecordNotFound Then
      myTXLOCDA._YEAR = WrkYear
      myTXLOCDA.AddOneRecordP()
    Else
      myTXLOCDA.UpdateOneRecordP()
    End If
  End Sub
  Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
    ShowData()
  End Sub
  Private Sub ShowData()
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
  Private Sub TxtMaxTax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMaxTax.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtTRF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTRF.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
End Class






