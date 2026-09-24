Public Class FrmUB501_NEW
  Inherits System.Windows.Forms.Form
  Dim myUTTYPE As UTTYPE.MyData
  Dim myTXINV As TXINV.myData
  Dim WrkContinue As Boolean

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
	Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
	Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents BtnContinue As System.Windows.Forms.Button
	Friend WithEvents TxtYear As System.Windows.Forms.TextBox
	Friend WithEvents TxtType As System.Windows.Forms.TextBox
	Friend WithEvents LnkListNo As System.Windows.Forms.LinkLabel
Friend WithEvents LnkType As System.Windows.Forms.LinkLabel
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.BtnContinue = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.LnkListNo = New System.Windows.Forms.LinkLabel()
    Me.LnkType = New System.Windows.Forms.LinkLabel()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TxtListNo
    '
    Me.TxtListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtListNo.Location = New System.Drawing.Point(56, 40)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(55, 20)
    Me.TxtListNo.TabIndex = 1
    Me.TxtListNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'BtnContinue
    '
    Me.BtnContinue.Location = New System.Drawing.Point(67, 90)
    Me.BtnContinue.Name = "BtnContinue"
    Me.BtnContinue.Size = New System.Drawing.Size(64, 24)
    Me.BtnContinue.TabIndex = 4
    Me.BtnContinue.Text = "&Continue"
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(24, 64)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(32, 16)
    Me.Label1.TabIndex = 228
    Me.Label1.Text = "Year"
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(56, 64)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtYear.TabIndex = 2
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtType.Location = New System.Drawing.Point(56, 16)
    Me.TxtType.MaxLength = 1
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(16, 20)
    Me.TxtType.TabIndex = 0
    '
    'LnkListNo
    '
    Me.LnkListNo.Location = New System.Drawing.Point(24, 40)
    Me.LnkListNo.Name = "LnkListNo"
    Me.LnkListNo.Size = New System.Drawing.Size(24, 16)
    Me.LnkListNo.TabIndex = 233
    Me.LnkListNo.TabStop = True
    Me.LnkListNo.Text = "List"
    '
    'LnkType
    '
    Me.LnkType.Location = New System.Drawing.Point(24, 16)
    Me.LnkType.Name = "LnkType"
    Me.LnkType.Size = New System.Drawing.Size(32, 16)
    Me.LnkType.TabIndex = 234
    Me.LnkType.TabStop = True
    Me.LnkType.Text = "Type"
    '
    'FrmUB501_NEW
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(186, 124)
    Me.Controls.Add(Me.LnkType)
    Me.Controls.Add(Me.LnkListNo)
    Me.Controls.Add(Me.TxtType)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.TxtListNo)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnContinue)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmUB501_NEW"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "New Adjust Information"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

	Private Sub BtnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnContinue.Click
    DoBtnContinue()
   End Sub

  Private Sub FrmUB501_NEW_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXINV = New TXINV.mydata(MyDBConnect)
    WrkContinue = False
    LnkListNo.Enabled = False
    MyFrmUB501.TBarNew.Enabled = False
    MyFrmUB501.TBarPrint.Enabled = False
  End Sub
  Private Sub FrmUB501_NEW_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		If Not WrkContinue Then
			MyFrmUB501.TBarNew.Enabled = True
      MyFrmUB501.TBarPrint.Enabled = True
      MyFrmUB501B.Show()
    End If
    'Memory Cleanup
    myUTTYPE = Nothing
    MyFrmUB501_NEW = Nothing
	End Sub
	Private Sub LnkListNo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkListNo.LinkClicked
		Me.ErrProv.SetError(TxtType, "")

    myUTTYPE = New UTTYPE.MyData(myDBConnect)
    myUTTYPE.GetOneRecordP(TxtType.Text)
    If myUTTYPE.RecordNotFound Then
      Me.ErrProv.SetError(TxtType, "Type not valid")
      Exit Sub
    End If

    MyFrmListInv = New FrmListInv
		MyFrmListInv.MdiParent = Me.ParentForm
		MyFrmListInv.WrkType = TxtType.Text
		MyFrmListInv.Show()
	End Sub

	Private Sub TxtType_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtType.TextChanged
		If TxtType.Text <> "" Then
			LnkListNo.Enabled = True
		End If
	End Sub

Private Sub FrmUB501_NEW_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmUB501.SbpScreen.Text = "UB501_NEW"
	With MyFrmUB501
		.HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
		.HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
	End With
 End Sub
Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
  If Asc(e.KeyChar) = Keys.Enter Then
    DoBtnContinue()
  End If
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
 e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub LnkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkType.LinkClicked
 MyFrmListUBType_Tax = New FrmListUBType_Tax
 MyFrmListUBType_Tax.MdiParent = Me.ParentForm
 MyFrmListUBType_Tax.WrkType = TxtType.Text
 MyFrmListUBType_Tax.Show()
End Sub
  Private Sub DoBtnContinue()
    Me.ErrProv.SetError(TxtListNo, "")
    Me.ErrProv.SetError(TxtYear, "")
    Me.ErrProv.SetError(TxtType, "")

    myUTTYPE = New UTTYPE.MyData(myDBConnect)
    myUTTYPE.GetOneRecordP(TxtType.Text)
    If myUTTYPE.RecordNotFound Then
      Me.ErrProv.SetError(TxtType, "Type not valid")
      Exit Sub
    End If

    If MyUtils.CnvSng(TxtListNo.Text) = 0 Then
      Me.ErrProv.SetError(TxtListNo, "List No is required")
      Exit Sub
    End If
    If MyUtils.CnvSng(TxtYear.Text) = 0 Then
      Me.ErrProv.SetError(TxtYear, "Year is required")
      Exit Sub
    End If
    If TxtType.Text = "" Then
      Me.ErrProv.SetError(TxtType, "Type is required")
      Exit Sub
    End If

    MyFrmUB501C = New FrmUB501C
    With MyFrmUB501C
      .MdiParent = Me.ParentForm
      .WrkCCNo = 0
      .WrkListNo = TxtListNo.Text
      .WrkYear = TxtYear.Text
      .WrkType = TxtType.Text
      .Show()
    End With

    WrkContinue = True
    Me.Close()
  End Sub
End Class






