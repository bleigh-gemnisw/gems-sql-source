Public Class FrmSettings
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
Friend WithEvents PrtDialog As System.Windows.Forms.PrintDialog
Friend WithEvents imageList1 As System.Windows.Forms.ImageList
Friend WithEvents TbMain As System.Windows.Forms.ToolBar
Friend WithEvents TBarSave As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarReturn As System.Windows.Forms.ToolBarButton
Friend WithEvents TabCtl1 As System.Windows.Forms.TabControl
Friend WithEvents TabPgPrinter As System.Windows.Forms.TabPage
Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RBValidateModelTMU675 As System.Windows.Forms.RadioButton
Friend WithEvents LblValidatePrinter As System.Windows.Forms.Label
Friend WithEvents BtnShowValidate As System.Windows.Forms.Button
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
Friend WithEvents ChkReceipt As System.Windows.Forms.CheckBox
Friend WithEvents LblReceiptPrinter As System.Windows.Forms.Label
Friend WithEvents label6 As System.Windows.Forms.Label
Friend WithEvents BtnShowReceipt As System.Windows.Forms.Button
Friend WithEvents ChkAdvDriver As System.Windows.Forms.CheckBox
Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
Friend WithEvents RbFontCourier As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents LblPermitPrinter As System.Windows.Forms.Label
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents BtnShowPermit As System.Windows.Forms.Button
Friend WithEvents RbFontArial As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSettings))
    Me.PrtDialog = New System.Windows.Forms.PrintDialog()
    Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarReturn = New System.Windows.Forms.ToolBarButton()
    Me.TBarSave = New System.Windows.Forms.ToolBarButton()
    Me.TabCtl1 = New System.Windows.Forms.TabControl()
    Me.TabPgPrinter = New System.Windows.Forms.TabPage()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblPermitPrinter = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.BtnShowPermit = New System.Windows.Forms.Button()
    Me.GroupBox6 = New System.Windows.Forms.GroupBox()
    Me.ChkReceipt = New System.Windows.Forms.CheckBox()
    Me.LblReceiptPrinter = New System.Windows.Forms.Label()
    Me.label6 = New System.Windows.Forms.Label()
    Me.BtnShowReceipt = New System.Windows.Forms.Button()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.GroupBox7 = New System.Windows.Forms.GroupBox()
    Me.RbFontCourier = New System.Windows.Forms.RadioButton()
    Me.RbFontArial = New System.Windows.Forms.RadioButton()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.ChkAdvDriver = New System.Windows.Forms.CheckBox()
    Me.RBValidateModelTMU675 = New System.Windows.Forms.RadioButton()
    Me.LblValidatePrinter = New System.Windows.Forms.Label()
    Me.BtnShowValidate = New System.Windows.Forms.Button()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TabCtl1.SuspendLayout()
    Me.TabPgPrinter.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox6.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.GroupBox7.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'imageList1
    '
    Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.imageList1.Images.SetKeyName(0, "")
    Me.imageList1.Images.SetKeyName(1, "")
    '
    'TbMain
    '
    Me.TbMain.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarReturn, Me.TBarSave})
    Me.TbMain.Dock = System.Windows.Forms.DockStyle.None
    Me.TbMain.DropDownArrows = True
    Me.TbMain.ImageList = Me.imageList1
    Me.TbMain.Location = New System.Drawing.Point(8, 321)
    Me.TbMain.Name = "TbMain"
    Me.TbMain.ShowToolTips = True
    Me.TbMain.Size = New System.Drawing.Size(88, 50)
    Me.TbMain.TabIndex = 190
    '
    'TBarReturn
    '
    Me.TBarReturn.ImageIndex = 0
    Me.TBarReturn.Name = "TBarReturn"
    Me.TBarReturn.Text = "Return"
    '
    'TBarSave
    '
    Me.TBarSave.ImageIndex = 1
    Me.TBarSave.Name = "TBarSave"
    Me.TBarSave.Text = "Save"
    '
    'TabCtl1
    '
    Me.TabCtl1.Controls.Add(Me.TabPgPrinter)
    Me.TabCtl1.Location = New System.Drawing.Point(8, 8)
    Me.TabCtl1.Name = "TabCtl1"
    Me.TabCtl1.SelectedIndex = 0
    Me.TabCtl1.Size = New System.Drawing.Size(499, 309)
    Me.TabCtl1.TabIndex = 196
    '
    'TabPgPrinter
    '
    Me.TabPgPrinter.Controls.Add(Me.GroupBox1)
    Me.TabPgPrinter.Controls.Add(Me.GroupBox6)
    Me.TabPgPrinter.Controls.Add(Me.GroupBox4)
    Me.TabPgPrinter.Location = New System.Drawing.Point(4, 22)
    Me.TabPgPrinter.Name = "TabPgPrinter"
    Me.TabPgPrinter.Size = New System.Drawing.Size(491, 283)
    Me.TabPgPrinter.TabIndex = 1
    Me.TabPgPrinter.Text = "Printer Setup"
    Me.TabPgPrinter.UseVisualStyleBackColor = True
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LblPermitPrinter)
    Me.GroupBox1.Controls.Add(Me.Label2)
    Me.GroupBox1.Controls.Add(Me.BtnShowPermit)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(13, 199)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(463, 74)
    Me.GroupBox1.TabIndex = 201
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Permit Forms"
    '
    'LblPermitPrinter
    '
    Me.LblPermitPrinter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPermitPrinter.Location = New System.Drawing.Point(94, 55)
    Me.LblPermitPrinter.Name = "LblPermitPrinter"
    Me.LblPermitPrinter.Size = New System.Drawing.Size(287, 16)
    Me.LblPermitPrinter.TabIndex = 7
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(6, 55)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(82, 16)
    Me.Label2.TabIndex = 6
    Me.Label2.Text = "Printer Name"
    '
    'BtnShowPermit
    '
    Me.BtnShowPermit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnShowPermit.Location = New System.Drawing.Point(97, 19)
    Me.BtnShowPermit.Name = "BtnShowPermit"
    Me.BtnShowPermit.Size = New System.Drawing.Size(96, 24)
    Me.BtnShowPermit.TabIndex = 5
    Me.BtnShowPermit.Text = "Show Printers"
    '
    'GroupBox6
    '
    Me.GroupBox6.Controls.Add(Me.ChkReceipt)
    Me.GroupBox6.Controls.Add(Me.LblReceiptPrinter)
    Me.GroupBox6.Controls.Add(Me.label6)
    Me.GroupBox6.Controls.Add(Me.BtnShowReceipt)
    Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox6.Location = New System.Drawing.Point(13, 119)
    Me.GroupBox6.Name = "GroupBox6"
    Me.GroupBox6.Size = New System.Drawing.Size(463, 74)
    Me.GroupBox6.TabIndex = 200
    Me.GroupBox6.TabStop = False
    Me.GroupBox6.Text = "Customer Receipt"
    '
    'ChkReceipt
    '
    Me.ChkReceipt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkReceipt.Location = New System.Drawing.Point(208, 19)
    Me.ChkReceipt.Name = "ChkReceipt"
    Me.ChkReceipt.Size = New System.Drawing.Size(200, 24)
    Me.ChkReceipt.TabIndex = 8
    Me.ChkReceipt.Text = "Check to Activate Receipt Printing"
    '
    'LblReceiptPrinter
    '
    Me.LblReceiptPrinter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblReceiptPrinter.Location = New System.Drawing.Point(94, 55)
    Me.LblReceiptPrinter.Name = "LblReceiptPrinter"
    Me.LblReceiptPrinter.Size = New System.Drawing.Size(287, 16)
    Me.LblReceiptPrinter.TabIndex = 7
    '
    'label6
    '
    Me.label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label6.Location = New System.Drawing.Point(6, 55)
    Me.label6.Name = "label6"
    Me.label6.Size = New System.Drawing.Size(82, 16)
    Me.label6.TabIndex = 6
    Me.label6.Text = "Printer Name"
    '
    'BtnShowReceipt
    '
    Me.BtnShowReceipt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnShowReceipt.Location = New System.Drawing.Point(97, 19)
    Me.BtnShowReceipt.Name = "BtnShowReceipt"
    Me.BtnShowReceipt.Size = New System.Drawing.Size(96, 24)
    Me.BtnShowReceipt.TabIndex = 5
    Me.BtnShowReceipt.Text = "Show Printers"
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.GroupBox7)
    Me.GroupBox4.Controls.Add(Me.GroupBox2)
    Me.GroupBox4.Controls.Add(Me.LblValidatePrinter)
    Me.GroupBox4.Controls.Add(Me.BtnShowValidate)
    Me.GroupBox4.Controls.Add(Me.Label5)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(13, 14)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(463, 99)
    Me.GroupBox4.TabIndex = 198
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Check Endorsement"
    '
    'GroupBox7
    '
    Me.GroupBox7.Controls.Add(Me.RbFontCourier)
    Me.GroupBox7.Controls.Add(Me.RbFontArial)
    Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox7.Location = New System.Drawing.Point(215, 11)
    Me.GroupBox7.Name = "GroupBox7"
    Me.GroupBox7.Size = New System.Drawing.Size(121, 59)
    Me.GroupBox7.TabIndex = 204
    Me.GroupBox7.TabStop = False
    Me.GroupBox7.Text = "Adv Driver Font "
    '
    'RbFontCourier
    '
    Me.RbFontCourier.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFontCourier.Location = New System.Drawing.Point(6, 19)
    Me.RbFontCourier.Name = "RbFontCourier"
    Me.RbFontCourier.Size = New System.Drawing.Size(109, 16)
    Me.RbFontCourier.TabIndex = 1
    Me.RbFontCourier.Text = "Courier New 8/9"
    '
    'RbFontArial
    '
    Me.RbFontArial.Checked = True
    Me.RbFontArial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFontArial.Location = New System.Drawing.Point(6, 37)
    Me.RbFontArial.Name = "RbFontArial"
    Me.RbFontArial.Size = New System.Drawing.Size(109, 16)
    Me.RbFontArial.TabIndex = 0
    Me.RbFontArial.TabStop = True
    Me.RbFontArial.Text = "Arial 10 "
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.ChkAdvDriver)
    Me.GroupBox2.Controls.Add(Me.RBValidateModelTMU675)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(342, 11)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(115, 59)
    Me.GroupBox2.TabIndex = 203
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Validator Model"
    '
    'ChkAdvDriver
    '
    Me.ChkAdvDriver.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkAdvDriver.Checked = True
    Me.ChkAdvDriver.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkAdvDriver.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkAdvDriver.Location = New System.Drawing.Point(18, 35)
    Me.ChkAdvDriver.Name = "ChkAdvDriver"
    Me.ChkAdvDriver.Size = New System.Drawing.Size(89, 20)
    Me.ChkAdvDriver.TabIndex = 204
    Me.ChkAdvDriver.Text = "Adv. Driver?"
    '
    'RBValidateModelTMU675
    '
    Me.RBValidateModelTMU675.Checked = True
    Me.RBValidateModelTMU675.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RBValidateModelTMU675.Location = New System.Drawing.Point(6, 19)
    Me.RBValidateModelTMU675.Name = "RBValidateModelTMU675"
    Me.RBValidateModelTMU675.Size = New System.Drawing.Size(80, 16)
    Me.RBValidateModelTMU675.TabIndex = 1
    Me.RBValidateModelTMU675.TabStop = True
    Me.RBValidateModelTMU675.Text = "TM-U675"
    '
    'LblValidatePrinter
    '
    Me.LblValidatePrinter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblValidatePrinter.Location = New System.Drawing.Point(91, 75)
    Me.LblValidatePrinter.Name = "LblValidatePrinter"
    Me.LblValidatePrinter.Size = New System.Drawing.Size(245, 20)
    Me.LblValidatePrinter.TabIndex = 201
    '
    'BtnShowValidate
    '
    Me.BtnShowValidate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnShowValidate.Location = New System.Drawing.Point(93, 46)
    Me.BtnShowValidate.Name = "BtnShowValidate"
    Me.BtnShowValidate.Size = New System.Drawing.Size(96, 24)
    Me.BtnShowValidate.TabIndex = 199
    Me.BtnShowValidate.Text = "Show Printers"
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(6, 75)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(88, 11)
    Me.Label5.TabIndex = 198
    Me.Label5.Text = "Printer Name"
    '
    'FrmSettings
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(519, 369)
    Me.Controls.Add(Me.TabCtl1)
    Me.Controls.Add(Me.TbMain)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmSettings"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Printer settings"
    Me.TabCtl1.ResumeLayout(False)
    Me.TabPgPrinter.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox6.ResumeLayout(False)
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox7.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region
Private Sub FrmSettings_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
  Me.Dispose()
End Sub

Private Sub FrmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  LblValidatePrinter.Text = MyAppSettings.ValidatePrinter
  LblReceiptPrinter.Text = MyAppSettings.ReceiptPrinter
  LblPermitPrinter.Text = MyAppSettings.PermitPrinter
  Select Case MyAppSettings.ValidateModel
  Case "TM-U675"
    RBValidateModelTMU675.Checked = True
  End Select
  Select Case MyAppSettings.ValidateFont
  Case "Arial-10"
    RbFontArial.Checked = True
  Case "Courier New-9", ""
    RbFontCourier.Checked = True
  End Select
  If MyAppSettings.AdvDriver Then
    ChkAdvDriver.Checked = True
  End If
  If MyAppSettings.Receipt Then
    ChkReceipt.Checked = True
  End If

  With MyFrmBD001
    .TBarBack.Enabled = False
    .TBarNew.Enabled = False
    .TBarSettings.Enabled = False
  End With
End Sub
Public Sub SaveData()
  Dim WrkValidateModel As String
  Dim WrkValidateFont As String
  With MyAppSettings
      WrkValidateModel = ""
      If RBValidateModelTMU675.Checked Then
        WrkValidateModel = "TM-U675"
      End If
      WrkValidateFont = ""
      If RbFontArial.Checked Then
        WrkValidateFont = "Arial-10"
      End If
      If RbFontCourier.Checked Then
        WrkValidateFont = "Courier New-9"
      End If
      .ValidatePrinter = LblValidatePrinter.Text
      .ValidateModel = WrkValidateModel
      .ValidateFont = WrkValidateFont
      .ReceiptPrinter = LblReceiptPrinter.Text
      If ChkAdvDriver.Checked Then
        .AdvDriver = True
      Else
        .AdvDriver = False
      End If
      If ChkReceipt.Checked Then
        .Receipt = True
      Else
        .Receipt = False
      End If
      .ReceiptPrinter = LblReceiptPrinter.Text
      .PermitPrinter = LblPermitPrinter.Text
  End With
  SaveAppSettings()
  Me.Close()
End Sub

Private Sub FrmSettings_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  With MyFrmBD001
    .TBarBack.Enabled = True
    .TBarNew.Enabled = True
    .TBarSettings.Enabled = True
  End With

End Sub

Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
  If e.Button Is TBarReturn Then
    Me.Close()
  End If

  If e.Button Is TBarSave Then
    SaveData()
  End If

End Sub
Private Sub BtnShowValidate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShowValidate.Click
  PrtDialog.PrinterSettings = New Printing.PrinterSettings

  PrtDialog.UseEXDialog = True
  Dim result As DialogResult = PrtDialog.ShowDialog()

  If (result = Windows.Forms.DialogResult.OK) Then
    LblValidatePrinter.Text = PrtDialog.PrinterSettings.PrinterName()
  End If
End Sub
Private Sub BtnShowReceipt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShowReceipt.Click
  PrtDialog.PrinterSettings = New Printing.PrinterSettings
  PrtDialog.UseEXDialog = True

  Dim result As DialogResult = PrtDialog.ShowDialog()

  If (result = Windows.Forms.DialogResult.OK) Then
    LblReceiptPrinter.Text = PrtDialog.PrinterSettings.PrinterName()
  End If

End Sub

Private Sub BtnShowPermit_Click(sender As Object, e As EventArgs) Handles BtnShowPermit.Click
  PrtDialog.PrinterSettings = New Printing.PrinterSettings
  PrtDialog.UseEXDialog = True

  Dim result As DialogResult = PrtDialog.ShowDialog()

  If (result = Windows.Forms.DialogResult.OK) Then
    LblPermitPrinter.Text = PrtDialog.PrinterSettings.PrinterName()
  End If

End Sub
End Class






