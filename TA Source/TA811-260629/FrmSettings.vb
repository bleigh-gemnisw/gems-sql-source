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
Friend WithEvents LblPrinter As System.Windows.Forms.Label
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents BtnShow As System.Windows.Forms.Button
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents ChkAuto As System.Windows.Forms.CheckBox
Friend WithEvents TxtCopies As System.Windows.Forms.TextBox
Friend WithEvents TxtCopiesCR As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TBarReturn As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSettings))
Me.PrtDialog = New System.Windows.Forms.PrintDialog
Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.TbMain = New System.Windows.Forms.ToolBar
Me.TBarReturn = New System.Windows.Forms.ToolBarButton
Me.TBarSave = New System.Windows.Forms.ToolBarButton
Me.LblPrinter = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
Me.BtnShow = New System.Windows.Forms.Button
Me.Label4 = New System.Windows.Forms.Label
Me.ChkAuto = New System.Windows.Forms.CheckBox
Me.TxtCopies = New System.Windows.Forms.TextBox
Me.TxtCopiesCR = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
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
Me.TbMain.Location = New System.Drawing.Point(8, 172)
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
'LblPrinter
'
Me.LblPrinter.Location = New System.Drawing.Point(6, 143)
Me.LblPrinter.Name = "LblPrinter"
Me.LblPrinter.Size = New System.Drawing.Size(256, 16)
Me.LblPrinter.TabIndex = 203
'
'Label3
'
Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label3.Location = New System.Drawing.Point(13, 38)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(143, 17)
Me.Label3.TabIndex = 202
Me.Label3.Text = "Number of Copies (Cert)"
'
'BtnShow
'
Me.BtnShow.Location = New System.Drawing.Point(115, 91)
Me.BtnShow.Name = "BtnShow"
Me.BtnShow.Size = New System.Drawing.Size(96, 25)
Me.BtnShow.TabIndex = 201
Me.BtnShow.Text = "Show Printers"
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(6, 123)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(88, 11)
Me.Label4.TabIndex = 200
Me.Label4.Text = "Printer Name"
'
'ChkAuto
'
Me.ChkAuto.AutoSize = True
Me.ChkAuto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkAuto.Location = New System.Drawing.Point(11, 12)
Me.ChkAuto.Name = "ChkAuto"
Me.ChkAuto.Size = New System.Drawing.Size(173, 17)
Me.ChkAuto.TabIndex = 204
Me.ChkAuto.Text = "Automatic Print (Skip preview)?"
Me.ChkAuto.UseVisualStyleBackColor = True
'
'TxtCopies
'
Me.TxtCopies.Location = New System.Drawing.Point(174, 35)
Me.TxtCopies.Name = "TxtCopies"
Me.TxtCopies.Size = New System.Drawing.Size(28, 20)
Me.TxtCopies.TabIndex = 205
'
'TxtCopiesCR
'
Me.TxtCopiesCR.Location = New System.Drawing.Point(174, 65)
Me.TxtCopiesCR.Name = "TxtCopiesCR"
Me.TxtCopiesCR.Size = New System.Drawing.Size(28, 20)
Me.TxtCopiesCR.TabIndex = 207
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label1.Location = New System.Drawing.Point(13, 68)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(146, 13)
Me.Label1.TabIndex = 206
Me.Label1.Text = "Number of Copies (MV Credit)"
'
'FrmSettings
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(281, 220)
Me.Controls.Add(Me.TxtCopiesCR)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.TxtCopies)
Me.Controls.Add(Me.ChkAuto)
Me.Controls.Add(Me.LblPrinter)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.BtnShow)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.TbMain)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmSettings"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Program and Printer settings"
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  LblPrinter.Text = MyAppSettings.Printer
  If MyAppSettings.Printer = "" Then
    MyAppSettings.Copies = 1
    MyAppSettings.CopiesCR = 1
  Else
    TxtCopies.Text = MyAppSettings.Copies
    TxtCopiesCR.Text = MyAppSettings.CopiesCR
  End If

  If MyAppSettings.Printer = "" Then
    TxtCopies.Enabled = False
    TxtCopiesCR.Enabled = False
    BtnShow.Enabled = False
  Else
    ChkAuto.Checked = True
  End If

  With MyFrmTA811
    .TBarBack.Enabled = False
    .TBarNew.Enabled = False
    .TBarSettings.Enabled = False
  End With
End Sub
Public Sub SaveData()
  MyAppSettings.Copies = MyUtils.CnvSng(TxtCopies.Text)
  MyAppSettings.CopiesCR = MyUtils.CnvSng(TxtCopiesCR.Text)
  MyAppSettings.Printer = LblPrinter.Text
  SaveAppSettings()
  Me.Close()
End Sub

Private Sub FrmSettings_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  With MyFrmTA811
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

Private Sub BntShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
  PrtDialog.UseEXDialog = True
  Dim result As DialogResult = PrtDialog.ShowDialog()

  If (result = Windows.Forms.DialogResult.OK) Then
    LblPrinter.Text = PrtDialog.PrinterSettings.PrinterName()
  End If

End Sub
Private Sub ChkAuto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkAuto.Click
  TxtCopies.Enabled = Not TxtCopies.Enabled
  TxtCopiesCR.Enabled = Not TxtCopiesCR.Enabled
  BtnShow.Enabled = Not BtnShow.Enabled
  If Not BtnShow.Enabled Then
    LblPrinter.Text = ""
  End If
End Sub

Private Sub ChkAuto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAuto.CheckedChanged

End Sub
End Class






