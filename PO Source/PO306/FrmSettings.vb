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
Friend WithEvents GrpPrinter1 As System.Windows.Forms.GroupBox
Friend WithEvents LblPrinter As System.Windows.Forms.Label
Friend WithEvents BtnPrinter As System.Windows.Forms.Button
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents GrpPrinter2 As System.Windows.Forms.GroupBox
Friend WithEvents LblPrinter2 As System.Windows.Forms.Label
Friend WithEvents BtnPrinter2 As System.Windows.Forms.Button
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents GrpPrinter3 As System.Windows.Forms.GroupBox
Friend WithEvents LblPrinter3 As System.Windows.Forms.Label
Friend WithEvents BtnPrinter3 As System.Windows.Forms.Button
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents BtnReset As System.Windows.Forms.Button
Friend WithEvents ChkDrawers As System.Windows.Forms.CheckBox
Friend WithEvents TBarReturn As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSettings))
Me.PrtDialog = New System.Windows.Forms.PrintDialog
Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.TbMain = New System.Windows.Forms.ToolBar
Me.TBarReturn = New System.Windows.Forms.ToolBarButton
Me.TBarSave = New System.Windows.Forms.ToolBarButton
Me.GrpPrinter1 = New System.Windows.Forms.GroupBox
Me.LblPrinter = New System.Windows.Forms.Label
Me.BtnPrinter = New System.Windows.Forms.Button
Me.Label4 = New System.Windows.Forms.Label
Me.GrpPrinter2 = New System.Windows.Forms.GroupBox
Me.LblPrinter2 = New System.Windows.Forms.Label
Me.BtnPrinter2 = New System.Windows.Forms.Button
Me.Label2 = New System.Windows.Forms.Label
Me.GrpPrinter3 = New System.Windows.Forms.GroupBox
Me.LblPrinter3 = New System.Windows.Forms.Label
Me.BtnPrinter3 = New System.Windows.Forms.Button
Me.Label5 = New System.Windows.Forms.Label
Me.Label1 = New System.Windows.Forms.Label
Me.BtnReset = New System.Windows.Forms.Button
Me.ChkDrawers = New System.Windows.Forms.CheckBox
Me.GrpPrinter1.SuspendLayout()
Me.GrpPrinter2.SuspendLayout()
Me.GrpPrinter3.SuspendLayout()
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
Me.TbMain.Location = New System.Drawing.Point(8, 304)
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
'GrpPrinter1
'
Me.GrpPrinter1.Controls.Add(Me.LblPrinter)
Me.GrpPrinter1.Controls.Add(Me.BtnPrinter)
Me.GrpPrinter1.Controls.Add(Me.Label4)
Me.GrpPrinter1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GrpPrinter1.Location = New System.Drawing.Point(12, 61)
Me.GrpPrinter1.Name = "GrpPrinter1"
Me.GrpPrinter1.Size = New System.Drawing.Size(424, 74)
Me.GrpPrinter1.TabIndex = 200
Me.GrpPrinter1.TabStop = False
Me.GrpPrinter1.Text = "Printer 1"
'
'LblPrinter
'
Me.LblPrinter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblPrinter.Location = New System.Drawing.Point(94, 54)
Me.LblPrinter.Name = "LblPrinter"
Me.LblPrinter.Size = New System.Drawing.Size(256, 16)
Me.LblPrinter.TabIndex = 202
'
'BtnPrinter
'
Me.BtnPrinter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.BtnPrinter.Location = New System.Drawing.Point(94, 22)
Me.BtnPrinter.Name = "BtnPrinter"
Me.BtnPrinter.Size = New System.Drawing.Size(96, 25)
Me.BtnPrinter.TabIndex = 201
Me.BtnPrinter.Text = "Show Printers"
'
'Label4
'
Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label4.Location = New System.Drawing.Point(6, 54)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(88, 11)
Me.Label4.TabIndex = 200
Me.Label4.Text = "Printer Name"
'
'GrpPrinter2
'
Me.GrpPrinter2.Controls.Add(Me.LblPrinter2)
Me.GrpPrinter2.Controls.Add(Me.BtnPrinter2)
Me.GrpPrinter2.Controls.Add(Me.Label2)
Me.GrpPrinter2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GrpPrinter2.Location = New System.Drawing.Point(12, 141)
Me.GrpPrinter2.Name = "GrpPrinter2"
Me.GrpPrinter2.Size = New System.Drawing.Size(424, 74)
Me.GrpPrinter2.TabIndex = 201
Me.GrpPrinter2.TabStop = False
Me.GrpPrinter2.Text = "2nd Printer"
'
'LblPrinter2
'
Me.LblPrinter2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblPrinter2.Location = New System.Drawing.Point(94, 54)
Me.LblPrinter2.Name = "LblPrinter2"
Me.LblPrinter2.Size = New System.Drawing.Size(256, 16)
Me.LblPrinter2.TabIndex = 202
'
'BtnPrinter2
'
Me.BtnPrinter2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.BtnPrinter2.Location = New System.Drawing.Point(94, 22)
Me.BtnPrinter2.Name = "BtnPrinter2"
Me.BtnPrinter2.Size = New System.Drawing.Size(96, 25)
Me.BtnPrinter2.TabIndex = 201
Me.BtnPrinter2.Text = "Show Printers"
'
'Label2
'
Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label2.Location = New System.Drawing.Point(6, 54)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(88, 11)
Me.Label2.TabIndex = 200
Me.Label2.Text = "Printer Name"
'
'GrpPrinter3
'
Me.GrpPrinter3.Controls.Add(Me.LblPrinter3)
Me.GrpPrinter3.Controls.Add(Me.BtnPrinter3)
Me.GrpPrinter3.Controls.Add(Me.Label5)
Me.GrpPrinter3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GrpPrinter3.Location = New System.Drawing.Point(12, 221)
Me.GrpPrinter3.Name = "GrpPrinter3"
Me.GrpPrinter3.Size = New System.Drawing.Size(424, 74)
Me.GrpPrinter3.TabIndex = 202
Me.GrpPrinter3.TabStop = False
Me.GrpPrinter3.Text = "3rd Printer"
'
'LblPrinter3
'
Me.LblPrinter3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblPrinter3.Location = New System.Drawing.Point(94, 54)
Me.LblPrinter3.Name = "LblPrinter3"
Me.LblPrinter3.Size = New System.Drawing.Size(256, 16)
Me.LblPrinter3.TabIndex = 202
'
'BtnPrinter3
'
Me.BtnPrinter3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.BtnPrinter3.Location = New System.Drawing.Point(94, 22)
Me.BtnPrinter3.Name = "BtnPrinter3"
Me.BtnPrinter3.Size = New System.Drawing.Size(96, 25)
Me.BtnPrinter3.TabIndex = 201
Me.BtnPrinter3.Text = "Show Printers"
'
'Label5
'
Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label5.Location = New System.Drawing.Point(6, 54)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(88, 11)
Me.Label5.TabIndex = 200
Me.Label5.Text = "Printer Name"
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label1.Location = New System.Drawing.Point(103, 9)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(274, 13)
Me.Label1.TabIndex = 203
Me.Label1.Text = "Set printers for Automatic printing (No Preview)"
'
'BtnReset
'
Me.BtnReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.BtnReset.Location = New System.Drawing.Point(430, 3)
Me.BtnReset.Name = "BtnReset"
Me.BtnReset.Size = New System.Drawing.Size(43, 25)
Me.BtnReset.TabIndex = 204
Me.BtnReset.Text = "Reset"
'
'ChkDrawers
'
Me.ChkDrawers.AutoSize = True
Me.ChkDrawers.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkDrawers.Location = New System.Drawing.Point(12, 38)
Me.ChkDrawers.Name = "ChkDrawers"
Me.ChkDrawers.Size = New System.Drawing.Size(223, 17)
Me.ChkDrawers.TabIndex = 205
Me.ChkDrawers.Text = "Print using Upper/Middle/Lower drawers?"
Me.ChkDrawers.UseVisualStyleBackColor = True
'
'FrmSettings
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(476, 352)
Me.Controls.Add(Me.ChkDrawers)
Me.Controls.Add(Me.BtnReset)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.GrpPrinter3)
Me.Controls.Add(Me.GrpPrinter2)
Me.Controls.Add(Me.GrpPrinter1)
Me.Controls.Add(Me.TbMain)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmSettings"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Printer settings"
Me.GrpPrinter1.ResumeLayout(False)
Me.GrpPrinter2.ResumeLayout(False)
Me.GrpPrinter3.ResumeLayout(False)
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region
Private Sub FrmSettings_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
  Me.Dispose()
End Sub

Private Sub FrmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  LblPrinter.Text = MyPrinter
  LblPrinter2.Text = MyPrinter2
  LblPrinter3.Text = MyPrinter3
  ChkDrawers.Checked = False
  If MyDrawers Then
    ChkDrawers.Checked = True
  End If

  With MyFrmPO306
    .TBarBack.Enabled = False
    .TBarSettings.Enabled = False
  End With
End Sub
Public Sub SaveData()
  With MyAppSettings
    .Printer = LblPrinter.Text
    .Printer2 = LblPrinter2.Text
    .Printer3 = LblPrinter3.Text
    .Drawers = False
    If ChkDrawers.Checked Then
      .Drawers = True
    End If
    MyPrinter = LblPrinter.Text
    MyPrinter2 = LblPrinter2.Text
    MyPrinter3 = LblPrinter3.Text
    MyDrawers = False
    If ChkDrawers.Checked Then
      MyDrawers = True
    End If
  End With

  SaveAppSettings()
  Me.Close()
End Sub

Private Sub FrmSettings_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  With MyFrmPO306
    .TBarBack.Enabled = True
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
Private Sub BtnShowPrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrinter.Click
  PrtDialog.PrinterSettings = New Printing.PrinterSettings

  PrtDialog.UseEXDialog = True
  Dim result As DialogResult = PrtDialog.ShowDialog()

  If (result = Windows.Forms.DialogResult.OK) Then
    LblPrinter.Text = PrtDialog.PrinterSettings.PrinterName()
  End If
End Sub

Private Sub BntShowPrinter2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrinter2.Click
  PrtDialog.PrinterSettings = New Printing.PrinterSettings
  PrtDialog.UseEXDialog = True
  Dim result As DialogResult = PrtDialog.ShowDialog()

  If (result = Windows.Forms.DialogResult.OK) Then
    LblPrinter2.Text = PrtDialog.PrinterSettings.PrinterName()
  End If

End Sub
Private Sub BtnShowPrinter3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrinter3.Click
  PrtDialog.PrinterSettings = New Printing.PrinterSettings
  PrtDialog.UseEXDialog = True

  Dim result As DialogResult = PrtDialog.ShowDialog()

  If (result = Windows.Forms.DialogResult.OK) Then
    LblPrinter3.Text = PrtDialog.PrinterSettings.PrinterName()
  End If

End Sub

Private Sub BtnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReset.Click
  LblPrinter.Text = ""
  LblPrinter2.Text = ""
  LblPrinter3.Text = ""
End Sub
  Private Sub ChkDrawers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkDrawers.Click

  End Sub

Private Sub ChkDrawers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkDrawers.CheckedChanged

End Sub
End Class
