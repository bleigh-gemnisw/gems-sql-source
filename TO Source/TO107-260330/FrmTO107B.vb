Public Class FrmTO107B
Inherits System.Windows.Forms.Form
Dim MyTXDIST As TXDIST.myData
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
	Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents ChkFrozenFile As System.Windows.Forms.CheckBox
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents LnkDist As System.Windows.Forms.LinkLabel
Friend WithEvents ChkPrtDist As System.Windows.Forms.CheckBox
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents DtPckPurDate As System.Windows.Forms.DateTimePicker
Friend WithEvents Label36 As System.Windows.Forms.Label
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents LblFilePath As System.Windows.Forms.Label
Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
Friend WithEvents ChkReval As System.Windows.Forms.CheckBox
Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ChkZeroes As CheckBox
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTO107B))
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.ChkFrozenFile = New System.Windows.Forms.CheckBox()
    Me.TxtGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.LnkDist = New System.Windows.Forms.LinkLabel()
    Me.ChkPrtDist = New System.Windows.Forms.CheckBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.DtPckPurDate = New System.Windows.Forms.DateTimePicker()
    Me.Label36 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.ChkReval = New System.Windows.Forms.CheckBox()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ChkZeroes = New System.Windows.Forms.CheckBox()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'TxtDist
        '
        Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDist.Location = New System.Drawing.Point(112, 50)
        Me.TxtDist.MaxLength = 3
        Me.TxtDist.Name = "TxtDist"
        Me.TxtDist.Size = New System.Drawing.Size(28, 20)
        Me.TxtDist.TabIndex = 2
        '
        'ChkFrozenFile
        '
        Me.ChkFrozenFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkFrozenFile.Location = New System.Drawing.Point(23, 143)
        Me.ChkFrozenFile.Name = "ChkFrozenFile"
        Me.ChkFrozenFile.Size = New System.Drawing.Size(130, 17)
        Me.ChkFrozenFile.TabIndex = 5
        Me.ChkFrozenFile.Text = "Use Frozen List?"
        '
        'TxtGLYear
        '
        Me.TxtGLYear.Location = New System.Drawing.Point(112, 26)
        Me.TxtGLYear.MaxLength = 4
        Me.TxtGLYear.Name = "TxtGLYear"
        Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
        Me.TxtGLYear.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(24, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 16)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "Grand List Year"
        '
        'LnkDist
        '
        Me.LnkDist.Location = New System.Drawing.Point(28, 53)
        Me.LnkDist.Name = "LnkDist"
        Me.LnkDist.Size = New System.Drawing.Size(80, 16)
        Me.LnkDist.TabIndex = 1
        Me.LnkDist.TabStop = True
        Me.LnkDist.Text = "District"
        '
        'ChkPrtDist
        '
        Me.ChkPrtDist.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkPrtDist.Location = New System.Drawing.Point(23, 99)
        Me.ChkPrtDist.Name = "ChkPrtDist"
        Me.ChkPrtDist.Size = New System.Drawing.Size(130, 16)
        Me.ChkPrtDist.TabIndex = 4
        Me.ChkPrtDist.Text = "Use Print Dist?"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DtPckPurDate)
        Me.GroupBox1.Controls.Add(Me.Label36)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 175)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(207, 45)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Special - Land only (before date)"
        '
        'DtPckPurDate
        '
        Me.DtPckPurDate.Checked = False
        Me.DtPckPurDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckPurDate.Location = New System.Drawing.Point(101, 16)
        Me.DtPckPurDate.Name = "DtPckPurDate"
        Me.DtPckPurDate.ShowCheckBox = True
        Me.DtPckPurDate.Size = New System.Drawing.Size(96, 20)
        Me.DtPckPurDate.TabIndex = 158
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(11, 16)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(88, 16)
        Me.Label36.TabIndex = 159
        Me.Label36.Text = "Purchase Date"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LblFilePath)
        Me.GroupBox2.Controls.Add(Me.LnkFilePath)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(16, 226)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(408, 72)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "OPM M-37 XML File"
        '
        'LblFilePath
        '
        Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFilePath.Location = New System.Drawing.Point(70, 24)
        Me.LblFilePath.Name = "LblFilePath"
        Me.LblFilePath.Size = New System.Drawing.Size(324, 36)
        Me.LblFilePath.TabIndex = 1
        '
        'LnkFilePath
        '
        Me.LnkFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LnkFilePath.Location = New System.Drawing.Point(12, 24)
        Me.LnkFilePath.Name = "LnkFilePath"
        Me.LnkFilePath.Size = New System.Drawing.Size(52, 16)
        Me.LnkFilePath.TabIndex = 0
        Me.LnkFilePath.TabStop = True
        Me.LnkFilePath.Text = "File Path"
        '
        'ChkReval
        '
        Me.ChkReval.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkReval.Location = New System.Drawing.Point(27, 76)
        Me.ChkReval.Name = "ChkReval"
        Me.ChkReval.Size = New System.Drawing.Size(126, 18)
        Me.ChkReval.TabIndex = 3
        Me.ChkReval.Text = "Reval Year?"
        '
        'ChkZeroes
        '
        Me.ChkZeroes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkZeroes.Location = New System.Drawing.Point(23, 121)
        Me.ChkZeroes.Name = "ChkZeroes"
        Me.ChkZeroes.Size = New System.Drawing.Size(130, 18)
        Me.ChkZeroes.TabIndex = 57
        Me.ChkZeroes.Text = "List# leading Zeroes?"
        '
        'FrmTO107B
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(436, 310)
        Me.ControlBox = False
        Me.Controls.Add(Me.ChkZeroes)
        Me.Controls.Add(Me.ChkReval)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ChkPrtDist)
        Me.Controls.Add(Me.LnkDist)
        Me.Controls.Add(Me.TxtDist)
        Me.Controls.Add(Me.ChkFrozenFile)
        Me.Controls.Add(Me.TxtGLYear)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTO107B"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Sub RunReport()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    MyTXDIST = New TXDIST.mydata(MyDBConnect)

    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    PrtReport()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
Private Sub FrmTO107B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTO107.SbpScreen.Text = "TO107B"
End Sub
Private Sub FrmTO107B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLYear, "")
    ErrProv.SetError(TxtDist, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "glyear"
        ErrProv.SetError(TxtGLYear, ErrorMsg(I))
      Case "dist"
        ErrProv.SetError(TxtDist, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtDist.Text) <> 0 And Not ChkPrtDist.Checked Then
      MyTXDIST.GetOneRecordP(MyUtils.CnvSng(TxtDist.Text))
      If MyTXDIST.RecordNotFound Then
        ErrorField(I) = "dist"
        ErrorMsg(I) = "Invalid District"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtGLYear.Text) = 0 Then
      ErrorField(I) = "glyear"
      ErrorMsg(I) = "G/L Year is required"
      I = I + 1
    End If

  End Sub
Private Sub LnkDist_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDist.LinkClicked
  MyFrmListDist = New FrmListDist
  MyFrmListDist.MdiParent = Me.ParentForm
  MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
  MyFrmListDist.Show()
  Me.Hide()
End Sub
Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub FrmTO107B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Dim WrkTownNo As String
  WrkTownNo = Format(myTOWN._TOWNBR, "000")
  LblFilePath.Text = MyUtils.GetDataPath() & "M37_" & WrkTownNo & ".xml"
End Sub

Private Sub LnkFilePath_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
  With SaveFileDialog1
    .ShowDialog()
    LblFilePath.Text = .FileName
  End With
End Sub
End Class






