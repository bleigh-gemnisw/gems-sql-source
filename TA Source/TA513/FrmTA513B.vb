Public Class FrmTA513B
Inherits System.Windows.Forms.Form
Dim WrkClassDesc As String
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
		Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
	Friend WithEvents TxtToYear As System.Windows.Forms.TextBox
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents TxtFromYear As System.Windows.Forms.TextBox
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents LnkToClass As System.Windows.Forms.LinkLabel
	Friend WithEvents TxtToClass As System.Windows.Forms.TextBox
	Friend WithEvents LnkFromClass As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtFromClass As System.Windows.Forms.TextBox
 Friend WithEvents Chkunpriced As System.Windows.Forms.CheckBox
	Friend WithEvents ChkNonTax As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents RbSortName As RadioButton
    Friend WithEvents RbSortMake As RadioButton
    Friend WithEvents RbSortList As RadioButton
    Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TxtToYear = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtFromYear = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LnkToClass = New System.Windows.Forms.LinkLabel()
        Me.TxtToClass = New System.Windows.Forms.TextBox()
        Me.LnkFromClass = New System.Windows.Forms.LinkLabel()
        Me.TxtFromClass = New System.Windows.Forms.TextBox()
        Me.Chkunpriced = New System.Windows.Forms.CheckBox()
        Me.ChkNonTax = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RbSortName = New System.Windows.Forms.RadioButton()
        Me.RbSortMake = New System.Windows.Forms.RadioButton()
        Me.RbSortList = New System.Windows.Forms.RadioButton()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'TxtToYear
        '
        Me.TxtToYear.Location = New System.Drawing.Point(210, 63)
        Me.TxtToYear.MaxLength = 4
        Me.TxtToYear.Name = "TxtToYear"
        Me.TxtToYear.Size = New System.Drawing.Size(32, 20)
        Me.TxtToYear.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(146, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "To Year"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "From Year"
        '
        'TxtFromYear
        '
        Me.TxtFromYear.Location = New System.Drawing.Point(104, 63)
        Me.TxtFromYear.MaxLength = 4
        Me.TxtFromYear.Name = "TxtFromYear"
        Me.TxtFromYear.Size = New System.Drawing.Size(32, 20)
        Me.TxtFromYear.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(146, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "To"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "From"
        '
        'LnkToClass
        '
        Me.LnkToClass.AutoSize = True
        Me.LnkToClass.Location = New System.Drawing.Point(172, 40)
        Me.LnkToClass.Name = "LnkToClass"
        Me.LnkToClass.Size = New System.Drawing.Size(32, 13)
        Me.LnkToClass.TabIndex = 13
        Me.LnkToClass.TabStop = True
        Me.LnkToClass.Text = "Class"
        '
        'TxtToClass
        '
        Me.TxtToClass.Location = New System.Drawing.Point(210, 37)
        Me.TxtToClass.MaxLength = 2
        Me.TxtToClass.Name = "TxtToClass"
        Me.TxtToClass.Size = New System.Drawing.Size(25, 20)
        Me.TxtToClass.TabIndex = 14
        '
        'LnkFromClass
        '
        Me.LnkFromClass.AutoSize = True
        Me.LnkFromClass.Location = New System.Drawing.Point(66, 40)
        Me.LnkFromClass.Name = "LnkFromClass"
        Me.LnkFromClass.Size = New System.Drawing.Size(32, 13)
        Me.LnkFromClass.TabIndex = 11
        Me.LnkFromClass.TabStop = True
        Me.LnkFromClass.Text = "Class"
        '
        'TxtFromClass
        '
        Me.TxtFromClass.Location = New System.Drawing.Point(104, 37)
        Me.TxtFromClass.MaxLength = 2
        Me.TxtFromClass.Name = "TxtFromClass"
        Me.TxtFromClass.Size = New System.Drawing.Size(25, 20)
        Me.TxtFromClass.TabIndex = 12
        '
        'Chkunpriced
        '
        Me.Chkunpriced.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Chkunpriced.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chkunpriced.Location = New System.Drawing.Point(24, 98)
        Me.Chkunpriced.Name = "Chkunpriced"
        Me.Chkunpriced.Size = New System.Drawing.Size(105, 19)
        Me.Chkunpriced.TabIndex = 21
        Me.Chkunpriced.Text = "Only Unpriced?"
        '
        'ChkNonTax
        '
        Me.ChkNonTax.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkNonTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkNonTax.Location = New System.Drawing.Point(149, 98)
        Me.ChkNonTax.Name = "ChkNonTax"
        Me.ChkNonTax.Size = New System.Drawing.Size(105, 19)
        Me.ChkNonTax.TabIndex = 22
        Me.ChkNonTax.Text = "Non Tax Report"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RbSortName)
        Me.GroupBox3.Controls.Add(Me.RbSortMake)
        Me.GroupBox3.Controls.Add(Me.RbSortList)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(280, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(162, 82)
        Me.GroupBox3.TabIndex = 23
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Sort Order"
        '
        'RbSortName
        '
        Me.RbSortName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbSortName.Location = New System.Drawing.Point(12, 56)
        Me.RbSortName.Name = "RbSortName"
        Me.RbSortName.Size = New System.Drawing.Size(144, 20)
        Me.RbSortName.TabIndex = 2
        Me.RbSortName.Text = "Name"
        '
        'RbSortMake
        '
        Me.RbSortMake.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RbSortMake.Checked = True
        Me.RbSortMake.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbSortMake.Location = New System.Drawing.Point(12, 16)
        Me.RbSortMake.Name = "RbSortMake"
        Me.RbSortMake.Size = New System.Drawing.Size(144, 20)
        Me.RbSortMake.TabIndex = 0
        Me.RbSortMake.TabStop = True
        Me.RbSortMake.Text = "Class, Make, Yr, Model"
        '
        'RbSortList
        '
        Me.RbSortList.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RbSortList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbSortList.Location = New System.Drawing.Point(12, 36)
        Me.RbSortList.Name = "RbSortList"
        Me.RbSortList.Size = New System.Drawing.Size(144, 20)
        Me.RbSortList.TabIndex = 1
        Me.RbSortList.Text = "List Number"
        '
        'FrmTA513B
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(444, 146)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.ChkNonTax)
        Me.Controls.Add(Me.Chkunpriced)
        Me.Controls.Add(Me.TxtToYear)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtFromYear)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LnkToClass)
        Me.Controls.Add(Me.TxtToClass)
        Me.Controls.Add(Me.LnkFromClass)
        Me.Controls.Add(Me.TxtFromClass)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTA513B"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Sub RunReport()
		Dim ErrorField(25) As String
		Dim ErrorMsg(25) As String

		WrkClassDesc = String.Empty
		Array.Clear(ErrorField, 0, 25)
		Array.Clear(ErrorMsg, 0, 25)

		EditChecks(ErrorField, ErrorMsg)
		ShowError(ErrorField, ErrorMsg)
		If Not IsNothing(ErrorMsg(0)) Then
			Exit Sub
		End If

		Windows.Forms.Cursor.Current = Cursors.WaitCursor
		PrtReport(WrkClassDesc)
		Windows.Forms.Cursor.Current = Cursors.Default

	End Sub
	Private Sub FrmTA513B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	End Sub
Private Sub FrmTA513B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmTA513.SbpScreen.Text = "TA513B"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
	Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer
		ErrProv.SetError(TxtFromClass, "")
		ErrProv.SetError(TxtToClass, "")
		ErrProv.SetError(TxtFromYear, "")
		ErrProv.SetError(TxtToYear, "")

		For I = 0 To ErrorField.GetUpperBound(0)
			Select Case ErrorField(I)
			Case "fromclass"
				ErrProv.SetError(TxtFromClass, ErrorMsg(I))
			Case "toclass"
				ErrProv.SetError(TxtToClass, ErrorMsg(I))
			Case "fromyear"
				ErrProv.SetError(TxtFromYear, ErrorMsg(I))
			Case "toyear"
				ErrProv.SetError(TxtToYear, ErrorMsg(I))
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
    If MyUtils.CnvSng(TxtFromClass.Text) > 0 Then
      WrkClassDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtFromClass.Text), "M")
      If Mid(WrkClassDesc, 1, 3) = "***" Then
        ErrorField(I) = "fromclass"
        ErrorMsg(I) = "Invalid From Class"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtToClass.Text) > 0 Then
      WrkClassDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtToClass.Text), "M")
      If Mid(WrkClassDesc, 1, 3) = "***" Then
        ErrorField(I) = "toclass"
        ErrorMsg(I) = "Invalid To Class"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtFromClass.Text) > MyUtils.CnvSng(TxtToClass.Text) Then
      ErrorField(I) = "fromclass"
      ErrorMsg(I) = "Invalid Class Range"
      I = I + 1
      ErrorField(I) = "toclass"
      ErrorMsg(I) = "Invalid Class Range"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtFromYear.Text) > MyUtils.CnvSng(TxtToYear.Text) Then
      ErrorField(I) = "fromyear"
      ErrorMsg(I) = "Invalid Year Range"
      I = I + 1
      ErrorField(I) = "toyear"
      ErrorMsg(I) = "Invalid Year Range"
      I = I + 1
    End If
  End Sub
Private Sub LnkFromClass_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFromClass.LinkClicked
  MyFrmListCodes = New FrmListCodes
  MyFrmListCodes.MdiParent = Me.ParentForm
  MyFrmListCodes.WrkField = "From"
  MyFrmListCodes.WrkType = "M"
  MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtFromClass.Text)
  MyFrmListCodes.Show()
  Me.Hide()
End Sub
Private Sub LnkToClass_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkToClass.LinkClicked
  MyFrmListCodes = New FrmListCodes
  MyFrmListCodes.MdiParent = Me.ParentForm
  MyFrmListCodes.WrkField = "To"
  MyFrmListCodes.WrkType = "M"
  MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtToClass.Text)
  MyFrmListCodes.Show()
  Me.Hide()
End Sub
Private Sub TxtFromClass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromClass.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtToClass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToClass.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtFromYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtToYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






