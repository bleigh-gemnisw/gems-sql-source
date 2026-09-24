Public Class FrmUB230B
	Inherits System.Windows.Forms.Form

	Dim Wrkdistr As Decimal
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents DtPckBill As System.Windows.Forms.DateTimePicker
	Dim Wrkdiphas As Decimal
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
Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbPer4th As System.Windows.Forms.RadioButton
Friend WithEvents RbPer3rd As System.Windows.Forms.RadioButton
Friend WithEvents RbPer2nd As System.Windows.Forms.RadioButton
Friend WithEvents RbPer1st As System.Windows.Forms.RadioButton
Friend WithEvents RbPerAnnual As System.Windows.Forms.RadioButton
Friend WithEvents GrpSorting As System.Windows.Forms.GroupBox
Friend WithEvents RbSortLocation As System.Windows.Forms.RadioButton
Friend WithEvents RbSortList As System.Windows.Forms.RadioButton
Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
Friend WithEvents TxtYear As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TxtPhase As System.Windows.Forms.TextBox
Friend WithEvents Label44 As System.Windows.Forms.Label
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents LnkDistrict As System.Windows.Forms.LinkLabel
Friend WithEvents TxtPhaseTo As System.Windows.Forms.TextBox
Friend WithEvents TxtDistTo As System.Windows.Forms.TextBox
Friend WithEvents TxtUBType As System.Windows.Forms.TextBox
Friend WithEvents LnkDistrictto As System.Windows.Forms.LinkLabel
Friend WithEvents LnkUBType As System.Windows.Forms.LinkLabel
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.GroupBox2 = New System.Windows.Forms.GroupBox
Me.RbPer4th = New System.Windows.Forms.RadioButton
Me.RbPer3rd = New System.Windows.Forms.RadioButton
Me.RbPer2nd = New System.Windows.Forms.RadioButton
Me.RbPer1st = New System.Windows.Forms.RadioButton
Me.RbPerAnnual = New System.Windows.Forms.RadioButton
Me.GrpSorting = New System.Windows.Forms.GroupBox
Me.RbSortLocation = New System.Windows.Forms.RadioButton
Me.RbSortList = New System.Windows.Forms.RadioButton
Me.RbSortName = New System.Windows.Forms.RadioButton
Me.TxtYear = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.TxtPhaseTo = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.TxtDistTo = New System.Windows.Forms.TextBox
Me.LnkDistrictto = New System.Windows.Forms.LinkLabel
Me.Label1 = New System.Windows.Forms.Label
Me.TxtUBType = New System.Windows.Forms.TextBox
Me.LnkUBType = New System.Windows.Forms.LinkLabel
Me.TxtPhase = New System.Windows.Forms.TextBox
Me.Label44 = New System.Windows.Forms.Label
Me.TxtDist = New System.Windows.Forms.TextBox
Me.LnkDistrict = New System.Windows.Forms.LinkLabel
Me.Label4 = New System.Windows.Forms.Label
Me.Label5 = New System.Windows.Forms.Label
Me.DtPckBill = New System.Windows.Forms.DateTimePicker
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox2.SuspendLayout()
Me.GrpSorting.SuspendLayout()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'GroupBox2
'
Me.GroupBox2.Controls.Add(Me.RbPer4th)
Me.GroupBox2.Controls.Add(Me.RbPer3rd)
Me.GroupBox2.Controls.Add(Me.RbPer2nd)
Me.GroupBox2.Controls.Add(Me.RbPer1st)
Me.GroupBox2.Controls.Add(Me.RbPerAnnual)
Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox2.ForeColor = System.Drawing.Color.Maroon
Me.GroupBox2.Location = New System.Drawing.Point(328, 56)
Me.GroupBox2.Name = "GroupBox2"
Me.GroupBox2.Size = New System.Drawing.Size(128, 98)
Me.GroupBox2.TabIndex = 306
Me.GroupBox2.TabStop = False
Me.GroupBox2.Text = "Billing Period"
'
'RbPer4th
'
Me.RbPer4th.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbPer4th.ForeColor = System.Drawing.SystemColors.ControlText
Me.RbPer4th.Location = New System.Drawing.Point(8, 80)
Me.RbPer4th.Name = "RbPer4th"
Me.RbPer4th.Size = New System.Drawing.Size(76, 16)
Me.RbPer4th.TabIndex = 307
Me.RbPer4th.Text = "4th Period"
'
'RbPer3rd
'
Me.RbPer3rd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbPer3rd.ForeColor = System.Drawing.SystemColors.ControlText
Me.RbPer3rd.Location = New System.Drawing.Point(8, 64)
Me.RbPer3rd.Name = "RbPer3rd"
Me.RbPer3rd.Size = New System.Drawing.Size(76, 16)
Me.RbPer3rd.TabIndex = 306
Me.RbPer3rd.Text = "3rd Period"
'
'RbPer2nd
'
Me.RbPer2nd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbPer2nd.ForeColor = System.Drawing.SystemColors.ControlText
Me.RbPer2nd.Location = New System.Drawing.Point(8, 48)
Me.RbPer2nd.Name = "RbPer2nd"
Me.RbPer2nd.Size = New System.Drawing.Size(80, 16)
Me.RbPer2nd.TabIndex = 305
Me.RbPer2nd.Text = "2nd Period"
'
'RbPer1st
'
Me.RbPer1st.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbPer1st.ForeColor = System.Drawing.SystemColors.ControlText
Me.RbPer1st.Location = New System.Drawing.Point(8, 32)
Me.RbPer1st.Name = "RbPer1st"
Me.RbPer1st.Size = New System.Drawing.Size(76, 16)
Me.RbPer1st.TabIndex = 304
Me.RbPer1st.Text = "1st Period"
'
'RbPerAnnual
'
Me.RbPerAnnual.Checked = True
Me.RbPerAnnual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbPerAnnual.ForeColor = System.Drawing.SystemColors.ControlText
Me.RbPerAnnual.Location = New System.Drawing.Point(8, 16)
Me.RbPerAnnual.Name = "RbPerAnnual"
Me.RbPerAnnual.Size = New System.Drawing.Size(60, 16)
Me.RbPerAnnual.TabIndex = 303
Me.RbPerAnnual.TabStop = True
Me.RbPerAnnual.Text = "Annual"
'
'GrpSorting
'
Me.GrpSorting.Controls.Add(Me.RbSortLocation)
Me.GrpSorting.Controls.Add(Me.RbSortList)
Me.GrpSorting.Controls.Add(Me.RbSortName)
Me.GrpSorting.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GrpSorting.ForeColor = System.Drawing.Color.Maroon
Me.GrpSorting.Location = New System.Drawing.Point(192, 56)
Me.GrpSorting.Name = "GrpSorting"
Me.GrpSorting.Size = New System.Drawing.Size(128, 96)
Me.GrpSorting.TabIndex = 305
Me.GrpSorting.TabStop = False
Me.GrpSorting.Text = "Sort Order"
'
'RbSortLocation
'
Me.RbSortLocation.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbSortLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbSortLocation.ForeColor = System.Drawing.SystemColors.ControlText
Me.RbSortLocation.Location = New System.Drawing.Point(8, 64)
Me.RbSortLocation.Name = "RbSortLocation"
Me.RbSortLocation.Size = New System.Drawing.Size(108, 20)
Me.RbSortLocation.TabIndex = 2
Me.RbSortLocation.Text = "Location"
'
'RbSortList
'
Me.RbSortList.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbSortList.Checked = True
Me.RbSortList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbSortList.ForeColor = System.Drawing.SystemColors.ControlText
Me.RbSortList.Location = New System.Drawing.Point(8, 16)
Me.RbSortList.Name = "RbSortList"
Me.RbSortList.Size = New System.Drawing.Size(108, 20)
Me.RbSortList.TabIndex = 0
Me.RbSortList.TabStop = True
Me.RbSortList.Text = "List #"
'
'RbSortName
'
Me.RbSortName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbSortName.ForeColor = System.Drawing.SystemColors.ControlText
Me.RbSortName.Location = New System.Drawing.Point(8, 40)
Me.RbSortName.Name = "RbSortName"
Me.RbSortName.Size = New System.Drawing.Size(108, 20)
Me.RbSortName.TabIndex = 1
Me.RbSortName.Text = "Name"
'
'TxtYear
'
Me.TxtYear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtYear.Location = New System.Drawing.Point(100, 88)
Me.TxtYear.MaxLength = 4
Me.TxtYear.Name = "TxtYear"
Me.TxtYear.Size = New System.Drawing.Size(40, 22)
Me.TxtYear.TabIndex = 325
'
'Label3
'
Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label3.Location = New System.Drawing.Point(16, 92)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(76, 16)
Me.Label3.TabIndex = 326
Me.Label3.Text = "Billing Year"
'
'TxtPhaseTo
'
Me.TxtPhaseTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtPhaseTo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtPhaseTo.Location = New System.Drawing.Point(431, 16)
Me.TxtPhaseTo.MaxLength = 1
Me.TxtPhaseTo.Name = "TxtPhaseTo"
Me.TxtPhaseTo.Size = New System.Drawing.Size(16, 22)
Me.TxtPhaseTo.TabIndex = 319
'
'Label2
'
Me.Label2.BackColor = System.Drawing.SystemColors.Control
Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
Me.Label2.Location = New System.Drawing.Point(385, 20)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(40, 12)
Me.Label2.TabIndex = 324
Me.Label2.Text = "Phase"
'
'TxtDistTo
'
Me.TxtDistTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtDistTo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDistTo.Location = New System.Drawing.Point(340, 16)
Me.TxtDistTo.MaxLength = 3
Me.TxtDistTo.Name = "TxtDistTo"
Me.TxtDistTo.Size = New System.Drawing.Size(32, 22)
Me.TxtDistTo.TabIndex = 318
'
'LnkDistrictto
'
Me.LnkDistrictto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkDistrictto.Location = New System.Drawing.Point(284, 16)
Me.LnkDistrictto.Name = "LnkDistrictto"
Me.LnkDistrictto.Size = New System.Drawing.Size(48, 16)
Me.LnkDistrictto.TabIndex = 317
Me.LnkDistrictto.TabStop = True
Me.LnkDistrictto.Text = "District"
'
'Label1
'
Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
Me.Label1.Location = New System.Drawing.Point(232, 16)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(46, 16)
Me.Label1.TabIndex = 323
Me.Label1.Text = "To"
'
'TxtUBType
'
Me.TxtUBType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtUBType.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtUBType.Location = New System.Drawing.Point(100, 56)
Me.TxtUBType.MaxLength = 2
Me.TxtUBType.Name = "TxtUBType"
Me.TxtUBType.Size = New System.Drawing.Size(24, 22)
Me.TxtUBType.TabIndex = 321
'
'LnkUBType
'
Me.LnkUBType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkUBType.Location = New System.Drawing.Point(12, 56)
Me.LnkUBType.Name = "LnkUBType"
Me.LnkUBType.Size = New System.Drawing.Size(80, 16)
Me.LnkUBType.TabIndex = 320
Me.LnkUBType.TabStop = True
Me.LnkUBType.Text = "Bill Type"
'
'TxtPhase
'
Me.TxtPhase.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtPhase.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtPhase.Location = New System.Drawing.Point(171, 16)
Me.TxtPhase.MaxLength = 1
Me.TxtPhase.Name = "TxtPhase"
Me.TxtPhase.Size = New System.Drawing.Size(16, 22)
Me.TxtPhase.TabIndex = 316
'
'Label44
'
Me.Label44.BackColor = System.Drawing.SystemColors.Control
Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label44.ForeColor = System.Drawing.SystemColors.WindowText
Me.Label44.Location = New System.Drawing.Point(124, 20)
Me.Label44.Name = "Label44"
Me.Label44.Size = New System.Drawing.Size(41, 16)
Me.Label44.TabIndex = 322
Me.Label44.Text = "Phase"
'
'TxtDist
'
Me.TxtDist.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtDist.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDist.Location = New System.Drawing.Point(68, 16)
Me.TxtDist.MaxLength = 3
Me.TxtDist.Name = "TxtDist"
Me.TxtDist.Size = New System.Drawing.Size(32, 22)
Me.TxtDist.TabIndex = 315
'
'LnkDistrict
'
Me.LnkDistrict.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkDistrict.Location = New System.Drawing.Point(12, 16)
Me.LnkDistrict.Name = "LnkDistrict"
Me.LnkDistrict.Size = New System.Drawing.Size(48, 16)
Me.LnkDistrict.TabIndex = 314
Me.LnkDistrict.TabStop = True
Me.LnkDistrict.Text = "District"
'
'Label4
'
Me.Label4.BackColor = System.Drawing.SystemColors.Control
Me.Label4.ForeColor = System.Drawing.SystemColors.WindowText
Me.Label4.Location = New System.Drawing.Point(201, 165)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(146, 14)
Me.Label4.TabIndex = 329
Me.Label4.Text = "(Used for Metered Only)"
'
'Label5
'
Me.Label5.Location = New System.Drawing.Point(12, 163)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(72, 16)
Me.Label5.TabIndex = 328
Me.Label5.Text = "Bill Date"
'
'DtPckBill
'
Me.DtPckBill.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckBill.Location = New System.Drawing.Point(90, 163)
Me.DtPckBill.Name = "DtPckBill"
Me.DtPckBill.Size = New System.Drawing.Size(96, 20)
Me.DtPckBill.TabIndex = 327
'
'FrmUB230B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(470, 195)
Me.ControlBox = False
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.DtPckBill)
Me.Controls.Add(Me.TxtYear)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.TxtPhaseTo)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.TxtDistTo)
Me.Controls.Add(Me.LnkDistrictto)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.TxtUBType)
Me.Controls.Add(Me.LnkUBType)
Me.Controls.Add(Me.TxtPhase)
Me.Controls.Add(Me.Label44)
Me.Controls.Add(Me.TxtDist)
Me.Controls.Add(Me.LnkDistrict)
Me.Controls.Add(Me.GroupBox2)
Me.Controls.Add(Me.GrpSorting)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
Me.MaximizeBox = False
Me.Name = "FrmUB230B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox2.ResumeLayout(False)
Me.GrpSorting.ResumeLayout(False)
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmUB230B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

	Wrkdistr = 0
	Wrkdiphas = 0

End Sub


Private Sub FrmUB230B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmUB230.SbpScreen.Text = "UB230B"
	MyFrmUB230.TBarPrint.Enabled = True
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub LnkDistrict_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDistrict.LinkClicked
	MyFrmListDist = New FrmListDist
	MyFrmListDist.MdiParent = Me.ParentForm
  MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
  MyFrmListDist.WrkPhase = MyUtils.CnvSng(TxtPhase.Text)
  MyFrmListDist.Wrkwhichdist = "F"
  MyFrmListDist.Show()
  Me.Hide()
End Sub
Private Sub LnkDistrictto_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDistrictto.LinkClicked
  MyFrmListDist = New FrmListDist
  MyFrmListDist.MdiParent = Me.ParentForm
  MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDistTo.Text)
  MyFrmListDist.WrkPhase = MyUtils.CnvSng(TxtPhaseTo.Text)
  MyFrmListDist.Wrkwhichdist = "T"
  MyFrmListDist.Show()
  Me.Hide()
End Sub
Private Sub LnkUBType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkUBType.LinkClicked
  MyFrmListUBType = New FrmListUBType
  MyFrmListUBType.MdiParent = Me.ParentForm
  MyFrmListUBType.WrkType = TxtUBType.Text
  MyFrmListUBType.Show()
  Me.Hide()
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtPhase_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPhase.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub txtDistto_Keypressed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDistTo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub txtPhaseto_Keypressed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPhaseTo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    Dim myUTTYPE As UTTYPE.myData

    myUTTYPE = New UTTYPE.mydata(MyDBConnect)

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next
    If MyUtils.CnvSng(TxtYear.Text) = 0 Then
      ErrorField(I) = "Year"
      ErrorMsg(I) = "Invalid Year"
      I = I + 1
      End If
    If MyUtils.CnvSng(TxtDist.Text) > MyUtils.CnvSng(TxtDistTo.Text) Then
      ErrorField(I) = "TxtDist"
      ErrorMsg(I) = "Invalid District Range"
      I = I + 1
      End If
    If MyUtils.CnvSng(TxtDist.Text) = MyUtils.CnvSng(TxtDistTo.Text) And _
      MyUtils.CnvSng(TxtPhase.Text) > MyUtils.CnvSng(TxtPhaseTo.Text) Then
      ErrorField(I) = "TxtPhase"
      ErrorMsg(I) = "Invalid Phase Range"
      I = I + 1
      End If

    myUTTYPE.GetOneRecordP(TxtUBType.Text)
    If myUTTYPE.RecordNotFound Then
      ErrorField(I) = "TxtUBType"
      ErrorMsg(I) = "Invalid Bill Type"
      I = I + 1
    End If

  End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer
		ErrProv.SetError(TxtYear, "")
		ErrProv.SetError(TxtDist, "")
		ErrProv.SetError(TxtPhase, "")
		ErrProv.SetError(TxtUBType, "")

		For I = 0 To ErrorField.GetUpperBound(0)
			Select Case ErrorField(I)
			Case "Year"
				ErrProv.SetError(TxtYear, ErrorMsg(I))
			Case "TxtDist"
				ErrProv.SetError(TxtDist, ErrorMsg(I))
			Case "TxtPhase"
				ErrProv.SetError(TxtPhase, ErrorMsg(I))
			Case "TxtUBType"
				ErrProv.SetError(TxtUBType, ErrorMsg(I))
			Case Nothing
				Exit Sub
			End Select
		Next I
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

		PrtReport()
		Windows.Forms.Cursor.Current = Cursors.Default
End Sub

Private Sub TxtDist_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDist.TextChanged

End Sub
End Class






