Public Class FrmPrinters
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
Friend WithEvents BtnShow As System.Windows.Forms.Button
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents ChkAuto As System.Windows.Forms.CheckBox
Friend WithEvents TBarReturn As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrinters))
    Me.PrtDialog = New System.Windows.Forms.PrintDialog()
    Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarReturn = New System.Windows.Forms.ToolBarButton()
    Me.TBarSave = New System.Windows.Forms.ToolBarButton()
    Me.LblPrinter = New System.Windows.Forms.Label()
    Me.BtnShow = New System.Windows.Forms.Button()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.ChkAuto = New System.Windows.Forms.CheckBox()
    Me.SuspendLayout()
    '
    'PrtDialog
    '
    Me.PrtDialog.UseEXDialog = True
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
    Me.TbMain.Location = New System.Drawing.Point(8, 118)
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
    Me.LblPrinter.Location = New System.Drawing.Point(110, 87)
    Me.LblPrinter.Name = "LblPrinter"
    Me.LblPrinter.Size = New System.Drawing.Size(256, 16)
    Me.LblPrinter.TabIndex = 203
    '
    'BtnShow
    '
    Me.BtnShow.Location = New System.Drawing.Point(110, 55)
    Me.BtnShow.Name = "BtnShow"
    Me.BtnShow.Size = New System.Drawing.Size(96, 25)
    Me.BtnShow.TabIndex = 201
    Me.BtnShow.Text = "Show Printers"
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(22, 87)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(88, 11)
    Me.Label4.TabIndex = 200
    Me.Label4.Text = "Printer Name"
    '
    'ChkAuto
    '
    Me.ChkAuto.AutoSize = True
    Me.ChkAuto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkAuto.Location = New System.Drawing.Point(12, 12)
    Me.ChkAuto.Name = "ChkAuto"
    Me.ChkAuto.Size = New System.Drawing.Size(173, 17)
    Me.ChkAuto.TabIndex = 204
    Me.ChkAuto.Text = "Automatic Print (Skip preview)?"
    Me.ChkAuto.UseVisualStyleBackColor = True
    '
    'FrmPrinters
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(506, 166)
    Me.Controls.Add(Me.ChkAuto)
    Me.Controls.Add(Me.LblPrinter)
    Me.Controls.Add(Me.BtnShow)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TbMain)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmPrinters"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Setup Printer"
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmPrinters_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  LblPrinter.Text = MyAppSettings.Printer
  If MyAppSettings.Printer = "" Then
    BtnShow.Enabled = False
  Else
    ChkAuto.Checked = True
  End If

  With MyFrmGL403
    .TBarBack.Enabled = False
    .TBarNew.Enabled = False
    .TBarPrinters.Enabled = False
  End With
End Sub
Public Sub SaveData()
  MyAppSettings.Printer = LblPrinter.Text
  MyAppSettings.Printer = LblPrinter.Text
  SaveAppSettings()
  Me.Close()
End Sub

Private Sub FrmPrinters_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  With MyFrmGL403
    .TBarBack.Enabled = True
    .TBarNew.Enabled = True
    .TBarPrinters.Enabled = True
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
  Dim result As DialogResult = PrtDialog.ShowDialog()

  If (result = Windows.Forms.DialogResult.OK) Then
    LblPrinter.Text = PrtDialog.PrinterSettings.PrinterName()
  End If

End Sub
Private Sub ChkAuto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkAuto.Click
  BtnShow.Enabled = Not BtnShow.Enabled
  If Not BtnShow.Enabled Then
    LblPrinter.Text = ""
  End If
End Sub
End Class
