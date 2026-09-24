Public Class FrmTA218B
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
Friend WithEvents LnkDist As System.Windows.Forms.LinkLabel
Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
Friend WithEvents RbSortLoc As System.Windows.Forms.RadioButton
Friend WithEvents ChkAddress As System.Windows.Forms.CheckBox
Friend WithEvents RbSortMap As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbPP As System.Windows.Forms.RadioButton
Friend WithEvents RbRE As System.Windows.Forms.RadioButton
Friend WithEvents RbSortSName As System.Windows.Forms.RadioButton
Friend WithEvents ChkPrtDist As System.Windows.Forms.CheckBox
Friend WithEvents BtnSelCodes As System.Windows.Forms.Button
Friend WithEvents LblCodes As System.Windows.Forms.Label
Friend WithEvents ChkFrozenFile As System.Windows.Forms.CheckBox
Friend WithEvents RbMV As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox1 As GroupBox
  Friend WithEvents RbGrossAcct As RadioButton
  Friend WithEvents RbGrossCode As RadioButton
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTA218B))
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.LnkDist = New System.Windows.Forms.LinkLabel()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.RbSortSName = New System.Windows.Forms.RadioButton()
    Me.RbSortMap = New System.Windows.Forms.RadioButton()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
    Me.RbSortLoc = New System.Windows.Forms.RadioButton()
    Me.ChkAddress = New System.Windows.Forms.CheckBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbMV = New System.Windows.Forms.RadioButton()
    Me.RbPP = New System.Windows.Forms.RadioButton()
    Me.RbRE = New System.Windows.Forms.RadioButton()
    Me.ChkPrtDist = New System.Windows.Forms.CheckBox()
    Me.BtnSelCodes = New System.Windows.Forms.Button()
    Me.LblCodes = New System.Windows.Forms.Label()
    Me.ChkFrozenFile = New System.Windows.Forms.CheckBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbGrossAcct = New System.Windows.Forms.RadioButton()
    Me.RbGrossCode = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    Me.ImageList1.Images.SetKeyName(1, "select type_24.png")
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(68, 259)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(28, 20)
    Me.TxtDist.TabIndex = 3
    '
    'LnkDist
    '
    Me.LnkDist.Location = New System.Drawing.Point(16, 259)
    Me.LnkDist.Name = "LnkDist"
    Me.LnkDist.Size = New System.Drawing.Size(46, 20)
    Me.LnkDist.TabIndex = 69
    Me.LnkDist.TabStop = True
    Me.LnkDist.Text = "District"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.RbSortSName)
    Me.GroupBox3.Controls.Add(Me.RbSortMap)
    Me.GroupBox3.Controls.Add(Me.RbSortName)
    Me.GroupBox3.Controls.Add(Me.RbSortLoc)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(206, 105)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(130, 113)
    Me.GroupBox3.TabIndex = 7
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Sort Order"
    '
    'RbSortSName
    '
    Me.RbSortSName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortSName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortSName.Location = New System.Drawing.Point(12, 38)
    Me.RbSortSName.Name = "RbSortSName"
    Me.RbSortSName.Size = New System.Drawing.Size(102, 20)
    Me.RbSortSName.TabIndex = 1
    Me.RbSortSName.Text = "Second Name"
    '
    'RbSortMap
    '
    Me.RbSortMap.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortMap.Location = New System.Drawing.Point(12, 90)
    Me.RbSortMap.Name = "RbSortMap"
    Me.RbSortMap.Size = New System.Drawing.Size(102, 18)
    Me.RbSortMap.TabIndex = 3
    Me.RbSortMap.Text = "Map"
    '
    'RbSortName
    '
    Me.RbSortName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortName.Checked = True
    Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortName.Location = New System.Drawing.Point(12, 16)
    Me.RbSortName.Name = "RbSortName"
    Me.RbSortName.Size = New System.Drawing.Size(102, 20)
    Me.RbSortName.TabIndex = 0
    Me.RbSortName.TabStop = True
    Me.RbSortName.Text = "Name"
    '
    'RbSortLoc
    '
    Me.RbSortLoc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortLoc.Location = New System.Drawing.Point(12, 64)
    Me.RbSortLoc.Name = "RbSortLoc"
    Me.RbSortLoc.Size = New System.Drawing.Size(102, 20)
    Me.RbSortLoc.TabIndex = 2
    Me.RbSortLoc.Text = "Location"
    '
    'ChkAddress
    '
    Me.ChkAddress.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkAddress.Location = New System.Drawing.Point(19, 307)
    Me.ChkAddress.Name = "ChkAddress"
    Me.ChkAddress.Size = New System.Drawing.Size(117, 17)
    Me.ChkAddress.TabIndex = 5
    Me.ChkAddress.Text = "Show Address?"
    Me.ChkAddress.UseVisualStyleBackColor = True
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbMV)
    Me.GroupBox2.Controls.Add(Me.RbPP)
    Me.GroupBox2.Controls.Add(Me.RbRE)
    Me.GroupBox2.Location = New System.Drawing.Point(8, 105)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(130, 84)
    Me.GroupBox2.TabIndex = 1
    Me.GroupBox2.TabStop = False
    '
    'RbMV
    '
    Me.RbMV.AutoSize = True
    Me.RbMV.Location = New System.Drawing.Point(11, 61)
    Me.RbMV.Name = "RbMV"
    Me.RbMV.Size = New System.Drawing.Size(90, 17)
    Me.RbMV.TabIndex = 16
    Me.RbMV.Text = "Motor Vehicle"
    Me.RbMV.UseVisualStyleBackColor = True
    '
    'RbPP
    '
    Me.RbPP.AutoSize = True
    Me.RbPP.Location = New System.Drawing.Point(11, 38)
    Me.RbPP.Name = "RbPP"
    Me.RbPP.Size = New System.Drawing.Size(108, 17)
    Me.RbPP.TabIndex = 15
    Me.RbPP.Text = "Personal Property"
    Me.RbPP.UseVisualStyleBackColor = True
    '
    'RbRE
    '
    Me.RbRE.Checked = True
    Me.RbRE.Location = New System.Drawing.Point(11, 15)
    Me.RbRE.Name = "RbRE"
    Me.RbRE.Size = New System.Drawing.Size(94, 17)
    Me.RbRE.TabIndex = 14
    Me.RbRE.TabStop = True
    Me.RbRE.Text = "Real Estate"
    Me.RbRE.UseVisualStyleBackColor = True
    '
    'ChkPrtDist
    '
    Me.ChkPrtDist.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPrtDist.Location = New System.Drawing.Point(19, 285)
    Me.ChkPrtDist.Name = "ChkPrtDist"
    Me.ChkPrtDist.Size = New System.Drawing.Size(117, 16)
    Me.ChkPrtDist.TabIndex = 4
    Me.ChkPrtDist.Text = "Use Print Dist?"
    '
    'BtnSelCodes
    '
    Me.BtnSelCodes.Location = New System.Drawing.Point(124, 64)
    Me.BtnSelCodes.Name = "BtnSelCodes"
    Me.BtnSelCodes.Size = New System.Drawing.Size(87, 35)
    Me.BtnSelCodes.TabIndex = 0
    Me.BtnSelCodes.Text = "Select Codes"
    Me.BtnSelCodes.UseVisualStyleBackColor = True
    '
    'LblCodes
    '
    Me.LblCodes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCodes.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblCodes.Location = New System.Drawing.Point(12, 9)
    Me.LblCodes.Name = "LblCodes"
    Me.LblCodes.Size = New System.Drawing.Size(324, 43)
    Me.LblCodes.TabIndex = 208
    Me.LblCodes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'ChkFrozenFile
    '
    Me.ChkFrozenFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkFrozenFile.Location = New System.Drawing.Point(19, 330)
    Me.ChkFrozenFile.Name = "ChkFrozenFile"
    Me.ChkFrozenFile.Size = New System.Drawing.Size(117, 17)
    Me.ChkFrozenFile.TabIndex = 6
    Me.ChkFrozenFile.Text = "Use Frozen List?"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbGrossAcct)
    Me.GroupBox1.Controls.Add(Me.RbGrossCode)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(8, 189)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(130, 62)
    Me.GroupBox1.TabIndex = 209
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Gross"
    '
    'RbGrossAcct
    '
    Me.RbGrossAcct.AutoSize = True
    Me.RbGrossAcct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbGrossAcct.Location = New System.Drawing.Point(11, 38)
    Me.RbGrossAcct.Name = "RbGrossAcct"
    Me.RbGrossAcct.Size = New System.Drawing.Size(95, 17)
    Me.RbGrossAcct.TabIndex = 15
    Me.RbGrossAcct.Text = "Account Gross"
    Me.RbGrossAcct.UseVisualStyleBackColor = True
    '
    'RbGrossCode
    '
    Me.RbGrossCode.AutoSize = True
    Me.RbGrossCode.Checked = True
    Me.RbGrossCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbGrossCode.Location = New System.Drawing.Point(11, 15)
    Me.RbGrossCode.Name = "RbGrossCode"
    Me.RbGrossCode.Size = New System.Drawing.Size(100, 17)
    Me.RbGrossCode.TabIndex = 14
    Me.RbGrossCode.TabStop = True
    Me.RbGrossCode.Text = "Only for Code(s)"
    Me.RbGrossCode.UseVisualStyleBackColor = True
    '
    'FrmTA218B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(348, 358)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.ChkFrozenFile)
    Me.Controls.Add(Me.LblCodes)
    Me.Controls.Add(Me.BtnSelCodes)
    Me.Controls.Add(Me.ChkPrtDist)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.ChkAddress)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.LnkDist)
    Me.Controls.Add(Me.TxtDist)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA218B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
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
		If RbRE.Checked Then
			PrtReportRE()
    End If
    If RbPP.Checked Then
      PrtReportPP()
    End If
    If RbMV.Checked Then
      PrtReportMV()
    End If
    Windows.Forms.Cursor.Current = Cursors.Default
	End Sub
Private Sub FrmTA218B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmTA218.SbpScreen.Text = "TA218B"
End Sub
Private Sub FrmTA218B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
	Me.Refresh()
End Sub
	Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer
		ErrProv.SetError(TxtDist, "")

		For I = 0 To ErrorField.GetUpperBound(0)
			Select Case ErrorField(I)
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

    If MyUtils.CnvSng(TxtDist.Text) <> 0 Then
      MyTXDIST.GetOneRecordP(MyUtils.CnvSng(TxtDist.Text))
      If MyTXDIST.RecordNotFound Then
        ErrorField(I) = "dist"
        ErrorMsg(I) = "Invalid District"
        I = I + 1
      End If
    End If

  End Sub
Private Sub LnkDist_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDist.LinkClicked
  MyFrmListDist = New FrmListDist
  MyFrmListDist.MdiParent = Me.ParentForm
  MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
  MyFrmListDist.Show()
  Me.Hide()
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub RbRE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbRE.Click
	RbSortMap.Enabled = True
  RbSortLoc.Enabled = True
  MySelCodes = String.Empty
	LblCodes.Text = "* ALL Codes *"
	MyFrmTA218.Text = "Real Estate for Assessment Codes"
End Sub
Private Sub RbPP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPP.Click
	RbSortMap.Enabled = False
  RbSortLoc.Enabled = True
  MySelCodes = String.Empty
	LblCodes.Text = "* ALL Codes *"
	MyFrmTA218.Text = "Personal Property for Assessment Codes"
End Sub
Private Sub RbMV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbMV.Click
  RbSortMap.Enabled = False
  RbSortLoc.Enabled = False
  MySelCodes = String.Empty
  LblCodes.Text = "* ALL Codes *"
  MyFrmTA218.Text = "Motor Vehicle for Assessment Codes"
End Sub
Private Sub BtnSelCodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelCodes.Click
    MyFrmSelCodes = New FrmSelCodes
    If RbRE.Checked Then
      MyFrmSelCodes.WrkType = "R"
    End If
    If RbPP.Checked Then
      MyFrmSelCodes.WrkType = "P"
    End If
    If RbMV.Checked Then
      MyFrmSelCodes.WrkType = "M"
    End If
    MyFrmSelCodes.ShowDialog()
    If MySelCodes = "" Then
      LblCodes.Text = "* ALL Codes *"
    Else
      LblCodes.Text = MySelCodes
    End If
End Sub

Private Sub RbPP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbPP.CheckedChanged

End Sub

Private Sub FrmTA218B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  LblCodes.Text = "* ALL Codes *"
  MySelCodes = String.Empty
End Sub

Private Sub RbRE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbRE.CheckedChanged

End Sub

Private Sub LblCodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblCodes.Click

End Sub
End Class






