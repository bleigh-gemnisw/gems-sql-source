Public Class FrmUB502B
Inherits System.Windows.Forms.Form

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
Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents LnkDistrict As System.Windows.Forms.LinkLabel
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents TxtToReason As System.Windows.Forms.TextBox
Friend WithEvents TxtFromReason As System.Windows.Forms.TextBox
Friend WithEvents TxtToGLYear As System.Windows.Forms.TextBox
Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
Friend WithEvents LnkToReason As System.Windows.Forms.LinkLabel
Friend WithEvents LnkFrmReason As System.Windows.Forms.LinkLabel
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TxtType As System.Windows.Forms.TextBox
Friend WithEvents LnkType As System.Windows.Forms.LinkLabel
Friend WithEvents Label4 As System.Windows.Forms.Label
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.GroupBox3 = New System.Windows.Forms.GroupBox
Me.DtPckTo = New System.Windows.Forms.DateTimePicker
Me.Label2 = New System.Windows.Forms.Label
Me.DtPckFrom = New System.Windows.Forms.DateTimePicker
Me.Label1 = New System.Windows.Forms.Label
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.LnkDistrict = New System.Windows.Forms.LinkLabel
Me.TxtDist = New System.Windows.Forms.TextBox
Me.TxtToReason = New System.Windows.Forms.TextBox
Me.TxtFromReason = New System.Windows.Forms.TextBox
Me.TxtToGLYear = New System.Windows.Forms.TextBox
Me.TxtFromGLYear = New System.Windows.Forms.TextBox
Me.LnkToReason = New System.Windows.Forms.LinkLabel
Me.LnkFrmReason = New System.Windows.Forms.LinkLabel
Me.Label3 = New System.Windows.Forms.Label
Me.Label4 = New System.Windows.Forms.Label
Me.TxtType = New System.Windows.Forms.TextBox
Me.LnkType = New System.Windows.Forms.LinkLabel
Me.GroupBox3.SuspendLayout()
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox1.SuspendLayout()
Me.SuspendLayout()
'
'GroupBox3
'
Me.GroupBox3.Controls.Add(Me.DtPckTo)
Me.GroupBox3.Controls.Add(Me.Label2)
Me.GroupBox3.Controls.Add(Me.DtPckFrom)
Me.GroupBox3.Controls.Add(Me.Label1)
Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox3.Location = New System.Drawing.Point(24, 12)
Me.GroupBox3.Name = "GroupBox3"
Me.GroupBox3.Size = New System.Drawing.Size(286, 52)
Me.GroupBox3.TabIndex = 0
Me.GroupBox3.TabStop = False
Me.GroupBox3.Text = "Date Range"
'
'DtPckTo
'
Me.DtPckTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckTo.Location = New System.Drawing.Point(185, 20)
Me.DtPckTo.Name = "DtPckTo"
Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
Me.DtPckTo.TabIndex = 1
Me.DtPckTo.Value = New Date(2005, 10, 6, 9, 11, 0, 906)
'
'Label2
'
Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label2.Location = New System.Drawing.Point(151, 24)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(28, 16)
Me.Label2.TabIndex = 9
Me.Label2.Text = "To "
'
'DtPckFrom
'
Me.DtPckFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckFrom.Location = New System.Drawing.Point(52, 20)
Me.DtPckFrom.Name = "DtPckFrom"
Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
Me.DtPckFrom.TabIndex = 0
Me.DtPckFrom.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
'
'Label1
'
Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label1.Location = New System.Drawing.Point(12, 20)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(36, 16)
Me.Label1.TabIndex = 7
Me.Label1.Text = "From"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.TxtType)
Me.GroupBox1.Controls.Add(Me.LnkType)
Me.GroupBox1.Controls.Add(Me.LnkDistrict)
Me.GroupBox1.Controls.Add(Me.TxtDist)
Me.GroupBox1.Controls.Add(Me.TxtToReason)
Me.GroupBox1.Controls.Add(Me.TxtFromReason)
Me.GroupBox1.Controls.Add(Me.TxtToGLYear)
Me.GroupBox1.Controls.Add(Me.TxtFromGLYear)
Me.GroupBox1.Controls.Add(Me.LnkToReason)
Me.GroupBox1.Controls.Add(Me.LnkFrmReason)
Me.GroupBox1.Controls.Add(Me.Label3)
Me.GroupBox1.Controls.Add(Me.Label4)
Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox1.Location = New System.Drawing.Point(24, 82)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(211, 125)
Me.GroupBox1.TabIndex = 303
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "Optional Selections"
'
'LnkDistrict
'
Me.LnkDistrict.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkDistrict.Location = New System.Drawing.Point(12, 70)
Me.LnkDistrict.Name = "LnkDistrict"
Me.LnkDistrict.Size = New System.Drawing.Size(40, 16)
Me.LnkDistrict.TabIndex = 314
Me.LnkDistrict.TabStop = True
Me.LnkDistrict.Text = "District"
'
'TxtDist
'
Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDist.Location = New System.Drawing.Point(105, 66)
Me.TxtDist.MaxLength = 3
Me.TxtDist.Name = "TxtDist"
Me.TxtDist.Size = New System.Drawing.Size(28, 20)
Me.TxtDist.TabIndex = 3
'
'TxtToReason
'
Me.TxtToReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtToReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtToReason.Location = New System.Drawing.Point(154, 92)
Me.TxtToReason.MaxLength = 20
Me.TxtToReason.Name = "TxtToReason"
Me.TxtToReason.Size = New System.Drawing.Size(16, 20)
Me.TxtToReason.TabIndex = 5
'
'TxtFromReason
'
Me.TxtFromReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtFromReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFromReason.Location = New System.Drawing.Point(105, 92)
Me.TxtFromReason.MaxLength = 20
Me.TxtFromReason.Name = "TxtFromReason"
Me.TxtFromReason.Size = New System.Drawing.Size(16, 20)
Me.TxtFromReason.TabIndex = 4
'
'TxtToGLYear
'
Me.TxtToGLYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtToGLYear.Location = New System.Drawing.Point(167, 40)
Me.TxtToGLYear.MaxLength = 4
Me.TxtToGLYear.Name = "TxtToGLYear"
Me.TxtToGLYear.Size = New System.Drawing.Size(32, 20)
Me.TxtToGLYear.TabIndex = 2
'
'TxtFromGLYear
'
Me.TxtFromGLYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFromGLYear.Location = New System.Drawing.Point(105, 40)
Me.TxtFromGLYear.MaxLength = 4
Me.TxtFromGLYear.Name = "TxtFromGLYear"
Me.TxtFromGLYear.Size = New System.Drawing.Size(34, 20)
Me.TxtFromGLYear.TabIndex = 1
'
'LnkToReason
'
Me.LnkToReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkToReason.Location = New System.Drawing.Point(128, 95)
Me.LnkToReason.Name = "LnkToReason"
Me.LnkToReason.Size = New System.Drawing.Size(20, 16)
Me.LnkToReason.TabIndex = 311
Me.LnkToReason.TabStop = True
Me.LnkToReason.Text = "to"
'
'LnkFrmReason
'
Me.LnkFrmReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkFrmReason.Location = New System.Drawing.Point(12, 96)
Me.LnkFrmReason.Name = "LnkFrmReason"
Me.LnkFrmReason.Size = New System.Drawing.Size(80, 16)
Me.LnkFrmReason.TabIndex = 310
Me.LnkFrmReason.TabStop = True
Me.LnkFrmReason.Text = "Reason Code"
'
'Label3
'
Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label3.Location = New System.Drawing.Point(145, 43)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(16, 16)
Me.Label3.TabIndex = 309
Me.Label3.Text = "to"
'
'Label4
'
Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label4.Location = New System.Drawing.Point(12, 43)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(84, 16)
Me.Label4.TabIndex = 308
Me.Label4.Text = "Grand List Year"
'
'TxtType
'
Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtType.Location = New System.Drawing.Point(105, 17)
Me.TxtType.MaxLength = 20
Me.TxtType.Name = "TxtType"
Me.TxtType.Size = New System.Drawing.Size(16, 20)
Me.TxtType.TabIndex = 0
'
'LnkType
'
Me.LnkType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkType.Location = New System.Drawing.Point(16, 20)
Me.LnkType.Name = "LnkType"
Me.LnkType.Size = New System.Drawing.Size(80, 16)
Me.LnkType.TabIndex = 316
Me.LnkType.TabStop = True
Me.LnkType.Text = "Type to print"
'
'FrmUB502B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(330, 219)
Me.ControlBox = False
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.GroupBox3)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmUB502B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.GroupBox3.ResumeLayout(False)
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox1.ResumeLayout(False)
Me.GroupBox1.PerformLayout()
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmUB502B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmUB502.SbpScreen.Text = "UB502"
End Sub

Private Sub LnkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkType.LinkClicked
	MyFrmListUBType_Tax = New FrmListUBType_Tax
	MyFrmListUBType_Tax.MdiParent = Me.ParentForm
	MyFrmListUBType_Tax.WrkType = TxtType.Text
	MyFrmListUBType_Tax.Show()
	Me.Hide()
End Sub
Private Sub FrmUB502B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
	Me.Refresh()
End Sub
	Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer
		ErrProv.SetError(TxtFromGLYear, "")
		ErrProv.SetError(TxtToGLYear, "")
		ErrProv.SetError(TxtType, "")
		ErrProv.SetError(DtPckFrom, "")
		ErrProv.SetError(DtPckTo, "")

		For I = 0 To ErrorField.GetUpperBound(0)
			Select Case ErrorField(I)
			Case "fromglyear"
				ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
			Case "toglyear"
				ErrProv.SetError(TxtToGLYear, ErrorMsg(I))
			Case "type"
				ErrProv.SetError(TxtType, ErrorMsg(I))
			Case "from"
				ErrProv.SetError(DtPckFrom, ErrorMsg(I))
			Case "to"
				ErrProv.SetError(DtPckTo, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtFromGLYear.Text) > MyUtils.CnvSng(TxtToGLYear.Text) Then
      ErrorField(I) = "fromglyear"
      ErrorMsg(I) = "Invalid Year Range"
      I = I + 1
      ErrorField(I) = "toglyear"
      ErrorMsg(I) = "Invalid Year Range"
      I = I + 1
    End If

    If MyUtils.SetDBDate(DtPckFrom.Value) > MyUtils.SetDBDate(DtPckTo.Value) Then
      ErrorField(I) = "to"
      ErrorMsg(I) = "Invalid date Range"
      I = I + 1
    End If

  End Sub

Private Sub LnkFrmReason_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFrmReason.LinkClicked
  MyFrmListCResn = New FrmListCResn
  MyFrmListCResn.MdiParent = Me.ParentForm
  MyFrmListCResn.WrkCode = TxtFromReason.Text
  MyFrmListCResn.WrkField = "From"
  MyFrmListCResn.Show()
  Me.Hide()
End Sub

Private Sub LnkToReason_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkToReason.LinkClicked
  MyFrmListCResn = New FrmListCResn
  MyFrmListCResn.MdiParent = Me.ParentForm
  MyFrmListCResn.WrkCode = TxtToReason.Text
  MyFrmListCResn.WrkField = "To"
  MyFrmListCResn.Show()
  Me.Hide()
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
    PrtReportAfter()
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub

Private Sub FrmUB502B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  DtPckFrom.Value = Now.Date
  DtPckTo.Value = Now.Date
End Sub

Private Sub LnkDistrict_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDistrict.LinkClicked
  MyFrmListDist = New FrmListDist
  MyFrmListDist.MdiParent = Me.ParentForm
  MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
  MyFrmListDist.Show()
  Me.Hide()
End Sub
End Class






