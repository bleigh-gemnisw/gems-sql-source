Public Class FrmSelYear
    'Put this code in Main.vb: 
    'Public MySelTypes As String
    Inherits System.Windows.Forms.Form
    Dim ds As DataSet = New DataSet

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
  Friend WithEvents TbMain As System.Windows.Forms.ToolBar
  Friend WithEvents TBarReturn As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarSep1 As System.Windows.Forms.ToolBarButton
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents TxtSelYear As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TBarClear As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelYear))
Me.TbMain = New System.Windows.Forms.ToolBar
Me.TBarReturn = New System.Windows.Forms.ToolBarButton
Me.TBarSep1 = New System.Windows.Forms.ToolBarButton
Me.TBarClear = New System.Windows.Forms.ToolBarButton
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.TxtSelYear = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.SuspendLayout()
'
'TbMain
'
Me.TbMain.Anchor = System.Windows.Forms.AnchorStyles.Bottom
Me.TbMain.AutoSize = False
Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarReturn, Me.TBarSep1, Me.TBarClear})
Me.TbMain.Dock = System.Windows.Forms.DockStyle.None
Me.TbMain.DropDownArrows = True
Me.TbMain.ImageList = Me.ImageList1
Me.TbMain.Location = New System.Drawing.Point(4, 70)
Me.TbMain.Name = "TbMain"
Me.TbMain.ShowToolTips = True
Me.TbMain.Size = New System.Drawing.Size(192, 53)
Me.TbMain.TabIndex = 192
'
'TBarReturn
'
Me.TBarReturn.ImageIndex = 2
Me.TBarReturn.Name = "TBarReturn"
Me.TBarReturn.Text = "&Return"
'
'TBarSep1
'
Me.TBarSep1.Name = "TBarSep1"
Me.TBarSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
'
'TBarClear
'
Me.TBarClear.ImageIndex = 1
Me.TBarClear.Name = "TBarClear"
Me.TBarClear.Text = "&Clear "
'
'ImageList1
'
Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
Me.ImageList1.Images.SetKeyName(0, "")
Me.ImageList1.Images.SetKeyName(1, "")
Me.ImageList1.Images.SetKeyName(2, "")
'
'TxtSelYear
'
Me.TxtSelYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtSelYear.Location = New System.Drawing.Point(71, 24)
Me.TxtSelYear.MaxLength = 4
Me.TxtSelYear.Name = "TxtSelYear"
Me.TxtSelYear.Size = New System.Drawing.Size(36, 20)
Me.TxtSelYear.TabIndex = 193
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(27, 27)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(29, 13)
Me.Label1.TabIndex = 194
Me.Label1.Text = "Year"
'
'FrmSelYear
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(376, 124)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.TxtSelYear)
Me.Controls.Add(Me.TbMain)
Me.KeyPreview = True
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmSelYear"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
Me.Text = "Select Year"
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region
    Private Sub FrmSelYear_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      TxtSelYear.Text = MySelYear
    End Sub
  Private Sub SelClear()
    MySelYear = 0
    TxtSelYear.Text = ""
  End Sub
  Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
    If e.Button Is TBarReturn Then
       MySelYear = MyUtils.CnvSng(TxtSelYear.Text)
       Me.Close()
       Exit Sub
    End If

    If e.Button Is TBarClear Then
      SelClear()
      Exit Sub
    End If

  End Sub

  Private Sub FrmSelYear_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub

  If e.KeyCode = Keys.C Then
    SelClear()
  End If

  If e.KeyCode = Keys.R Then
  End If
  End Sub
Private Sub TxtSelYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSelYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






