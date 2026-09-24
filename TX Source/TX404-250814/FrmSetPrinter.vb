Public Class FrmSetPrinter
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
	Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
	Friend WithEvents RbStatement As System.Windows.Forms.RadioButton
	Friend WithEvents RbWarrants As System.Windows.Forms.RadioButton
	Friend WithEvents RbDemand As System.Windows.Forms.RadioButton
	Friend WithEvents RbLien As System.Windows.Forms.RadioButton
	Friend WithEvents RbLetter As System.Windows.Forms.RadioButton
	Friend WithEvents TxtTitle As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents LblTxt As System.Windows.Forms.Label
	Friend WithEvents TxtText As System.Windows.Forms.TextBox
	Friend WithEvents TxtAltFormID As System.Windows.Forms.TextBox
	Friend WithEvents Label3 As System.Windows.Forms.Label
 Friend WithEvents LblPrinter As System.Windows.Forms.Label
 Friend WithEvents label6 As System.Windows.Forms.Label
 Friend WithEvents BtnShowPrinters As System.Windows.Forms.Button
 Friend WithEvents TbMain As System.Windows.Forms.ToolBar
 Friend WithEvents TBarReturn As System.Windows.Forms.ToolBarButton
 Friend WithEvents PrtDialog As System.Windows.Forms.PrintDialog
 Friend WithEvents Label2 As System.Windows.Forms.Label
 Friend WithEvents ChkPreview As System.Windows.Forms.CheckBox
	Friend WithEvents RbIntent As System.Windows.Forms.RadioButton
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSetPrinter))
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.RbStatement = New System.Windows.Forms.RadioButton
Me.RbWarrants = New System.Windows.Forms.RadioButton
Me.RbDemand = New System.Windows.Forms.RadioButton
Me.RbLien = New System.Windows.Forms.RadioButton
Me.RbIntent = New System.Windows.Forms.RadioButton
Me.RbLetter = New System.Windows.Forms.RadioButton
Me.TxtTitle = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.LblTxt = New System.Windows.Forms.Label
Me.TxtText = New System.Windows.Forms.TextBox
Me.TxtAltFormID = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.LblPrinter = New System.Windows.Forms.Label
Me.label6 = New System.Windows.Forms.Label
Me.BtnShowPrinters = New System.Windows.Forms.Button
Me.TbMain = New System.Windows.Forms.ToolBar
Me.TBarReturn = New System.Windows.Forms.ToolBarButton
Me.PrtDialog = New System.Windows.Forms.PrintDialog
Me.Label2 = New System.Windows.Forms.Label
Me.ChkPreview = New System.Windows.Forms.CheckBox
Me.SuspendLayout()
'
'ImageList1
'
Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
Me.ImageList1.Images.SetKeyName(0, "return_24.png")
'
'RbStatement
'
Me.RbStatement.Checked = True
Me.RbStatement.Location = New System.Drawing.Point(75, 12)
Me.RbStatement.Name = "RbStatement"
Me.RbStatement.Size = New System.Drawing.Size(140, 20)
Me.RbStatement.TabIndex = 4
Me.RbStatement.TabStop = True
Me.RbStatement.Tag = "1"
Me.RbStatement.Text = "Delinquent &Statement"
'
'RbWarrants
'
Me.RbWarrants.Location = New System.Drawing.Point(75, 52)
Me.RbWarrants.Name = "RbWarrants"
Me.RbWarrants.Size = New System.Drawing.Size(136, 20)
Me.RbWarrants.TabIndex = 5
Me.RbWarrants.Tag = "3"
Me.RbWarrants.Text = "&Warrant"
'
'RbDemand
'
Me.RbDemand.Location = New System.Drawing.Point(75, 32)
Me.RbDemand.Name = "RbDemand"
Me.RbDemand.Size = New System.Drawing.Size(136, 20)
Me.RbDemand.TabIndex = 6
Me.RbDemand.Tag = "2"
Me.RbDemand.Text = "Demand &Notice"
'
'RbLien
'
Me.RbLien.Location = New System.Drawing.Point(75, 72)
Me.RbLien.Name = "RbLien"
Me.RbLien.Size = New System.Drawing.Size(136, 20)
Me.RbLien.TabIndex = 7
Me.RbLien.Tag = "4"
Me.RbLien.Text = "&Lien for Town Clerk"
'
'RbIntent
'
Me.RbIntent.Location = New System.Drawing.Point(75, 92)
Me.RbIntent.Name = "RbIntent"
Me.RbIntent.Size = New System.Drawing.Size(136, 20)
Me.RbIntent.TabIndex = 8
Me.RbIntent.Tag = "5"
Me.RbIntent.Text = "&Intent to Lien"
'
'RbLetter
'
Me.RbLetter.Location = New System.Drawing.Point(76, 114)
Me.RbLetter.Name = "RbLetter"
Me.RbLetter.Size = New System.Drawing.Size(80, 20)
Me.RbLetter.TabIndex = 9
Me.RbLetter.Tag = "5"
Me.RbLetter.Text = "Letter"
'
'TxtTitle
'
Me.TxtTitle.Location = New System.Drawing.Point(217, 114)
Me.TxtTitle.Name = "TxtTitle"
Me.TxtTitle.Size = New System.Drawing.Size(190, 20)
Me.TxtTitle.TabIndex = 10
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(149, 118)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(62, 13)
Me.Label1.TabIndex = 11
Me.Label1.Text = "Report Title"
'
'LblTxt
'
Me.LblTxt.Location = New System.Drawing.Point(6, 188)
Me.LblTxt.Name = "LblTxt"
Me.LblTxt.Size = New System.Drawing.Size(63, 32)
Me.LblTxt.TabIndex = 13
Me.LblTxt.Text = "Report Text"
Me.LblTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TxtText
'
Me.TxtText.Location = New System.Drawing.Point(75, 142)
Me.TxtText.MaxLength = 1000
Me.TxtText.Multiline = True
Me.TxtText.Name = "TxtText"
Me.TxtText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.TxtText.Size = New System.Drawing.Size(579, 126)
Me.TxtText.TabIndex = 12
'
'TxtAltFormID
'
Me.TxtAltFormID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtAltFormID.Location = New System.Drawing.Point(382, 12)
Me.TxtAltFormID.MaxLength = 1
Me.TxtAltFormID.Name = "TxtAltFormID"
Me.TxtAltFormID.Size = New System.Drawing.Size(20, 20)
Me.TxtAltFormID.TabIndex = 14
'
'Label3
'
Me.Label3.AutoSize = True
Me.Label3.Location = New System.Drawing.Point(279, 16)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(97, 13)
Me.Label3.TabIndex = 15
Me.Label3.Text = "Alternative Form ID"
'
'LblPrinter
'
Me.LblPrinter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblPrinter.Location = New System.Drawing.Point(102, 310)
Me.LblPrinter.Name = "LblPrinter"
Me.LblPrinter.Size = New System.Drawing.Size(287, 16)
Me.LblPrinter.TabIndex = 202
'
'label6
'
Me.label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.label6.Location = New System.Drawing.Point(14, 310)
Me.label6.Name = "label6"
Me.label6.Size = New System.Drawing.Size(82, 16)
Me.label6.TabIndex = 201
Me.label6.Text = "Printer Name"
'
'BtnShowPrinters
'
Me.BtnShowPrinters.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.BtnShowPrinters.Location = New System.Drawing.Point(105, 274)
Me.BtnShowPrinters.Name = "BtnShowPrinters"
Me.BtnShowPrinters.Size = New System.Drawing.Size(96, 24)
Me.BtnShowPrinters.TabIndex = 200
Me.BtnShowPrinters.Text = "Show Printers"
'
'TbMain
'
Me.TbMain.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarReturn})
Me.TbMain.Dock = System.Windows.Forms.DockStyle.None
Me.TbMain.DropDownArrows = True
Me.TbMain.ImageList = Me.ImageList1
Me.TbMain.Location = New System.Drawing.Point(9, 342)
Me.TbMain.Name = "TbMain"
Me.TbMain.ShowToolTips = True
Me.TbMain.Size = New System.Drawing.Size(88, 42)
Me.TbMain.TabIndex = 203
'
'TBarReturn
'
Me.TBarReturn.ImageIndex = 0
Me.TBarReturn.Name = "TBarReturn"
Me.TBarReturn.Text = "Return"
'
'PrtDialog
'
Me.PrtDialog.UseEXDialog = True
'
'Label2
'
Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label2.Location = New System.Drawing.Point(460, 16)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(195, 48)
Me.Label2.TabIndex = 207
Me.Label2.Text = "Settings are for this session and will NOT be saved when program ends"
Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
'
'ChkPreview
'
Me.ChkPreview.AutoSize = True
Me.ChkPreview.Location = New System.Drawing.Point(217, 279)
Me.ChkPreview.Name = "ChkPreview"
Me.ChkPreview.Size = New System.Drawing.Size(100, 17)
Me.ChkPreview.TabIndex = 208
Me.ChkPreview.Text = "Show Preview?"
Me.ChkPreview.UseVisualStyleBackColor = True
'
'FrmSetPrinter
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(667, 386)
Me.Controls.Add(Me.ChkPreview)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.TbMain)
Me.Controls.Add(Me.LblPrinter)
Me.Controls.Add(Me.label6)
Me.Controls.Add(Me.BtnShowPrinters)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.TxtAltFormID)
Me.Controls.Add(Me.LblTxt)
Me.Controls.Add(Me.TxtText)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.TxtTitle)
Me.Controls.Add(Me.RbLetter)
Me.Controls.Add(Me.RbIntent)
Me.Controls.Add(Me.RbLien)
Me.Controls.Add(Me.RbDemand)
Me.Controls.Add(Me.RbWarrants)
Me.Controls.Add(Me.RbStatement)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.KeyPreview = True
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmSetPrinter"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Select Report and Set Printer"
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmSetPrinter_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
	Me.Dispose()
End Sub
	Private Sub FrmSetPrinter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		MyFrmTX404.TBarBack.Enabled = False
		MyFrmTX404.TBarPrint.Enabled = False
		MyFrmTX404.TBarSetPrinter.Enabled = False
		MyFrmTX404.TBarSettings.Enabled = False
		TxtTitle.Enabled = False
		TxtText.Enabled = False
    TxtAltFormID.Text = MyAltFormID
		LblPrinter.Text = MyPrinter
		TxtTitle.Text = MyReportTitle
		TxtText.Text = MyReportText
		ChkPreview.Checked = MyPreview
		Select Case MyReportName
		Case "Statement", String.Empty
			RbStatement.Checked = True
		Case "Demand"
			RbDemand.Checked = True
		Case "Warrant"
			RbWarrants.Checked = True
		Case "Lien"
			RbLien.Checked = True
		Case "Intent"
			RbIntent.Checked = True
		Case "Letter"
			RbLetter.Checked = True
		End Select
	End Sub
	Private Sub FrmSetPrinter_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyPrinter = LblPrinter.Text
		MyReportTitle = TxtTitle.Text
		MyReportText = TxtText.Text
		MyPreview = ChkPreview.Checked
    MyAltFormID = TxtAltFormID.Text
    If RbStatement.Checked Then
      MyReportName = "Statement"
    End If
		If RbDemand.Checked Then
			MyReportName = "Demand"
		End If
		If RbWarrants.Checked Then
			MyReportName = "Warrant"
		End If
		If RbLien.Checked Then
			MyReportName = "Lien"
		End If
		If RbIntent.Checked Then
			MyReportName = "Intent"
		End If
		If RbLetter.Checked Then
			MyReportName = "Letter"
		End If
		MyFrmTX404.TBarBack.Enabled = True
		If MyPrinter <> String.Empty Then
			MyFrmTX404.TBarPrint.Enabled = True
		End If
		MyFrmTX404.TBarSetPrinter.Enabled = True
		MyFrmTX404.TBarSettings.Enabled = True
		'Memory Cleanup
		MyFrmSetPrinter = Nothing
	End Sub
Private Sub RbStatement_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbStatement.Click
	TxtTitle.Enabled = False
	TxtText.Enabled = True
  LblTxt.Text = "Message"
End Sub
Private Sub RbDemand_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbDemand.Click
	TxtTitle.Enabled = False
  TxtText.Enabled = True
  LblTxt.Text = "Message"
End Sub
Private Sub RbWarrants_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbWarrants.Click
	TxtTitle.Enabled = False
  TxtText.Enabled = True
  LblTxt.Text = "Message"
End Sub
Private Sub RbLien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbLien.Click
	TxtTitle.Enabled = False
	TxtText.Enabled = False
End Sub
Private Sub RbIntent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbIntent.Click
	TxtTitle.Enabled = False
	TxtText.Enabled = False
End Sub
Private Sub RbLetter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbLetter.Click
	TxtTitle.Enabled = True
	TxtText.Enabled = True
	LblTxt.Text = "Report Text"
End Sub
Private Sub BtnShowPrinters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShowPrinters.Click
	PrtDialog.PrinterSettings = New Printing.PrinterSettings

	Dim result As DialogResult = PrtDialog.ShowDialog()

	If (result = Windows.Forms.DialogResult.OK) Then
		LblPrinter.Text = PrtDialog.PrinterSettings.PrinterName()
	End If
End Sub

Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
	Me.Close()
End Sub
End Class






