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
  Friend WithEvents Label4 As Label
  Friend WithEvents Label3 As Label
  Friend WithEvents Label2 As Label
  Friend WithEvents TxtToYear As TextBox
  Friend WithEvents Label1 As Label
  Friend WithEvents TxtFromYear As TextBox
  Friend WithEvents TBarClear As System.Windows.Forms.ToolBarButton
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelYear))
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarReturn = New System.Windows.Forms.ToolBarButton()
    Me.TBarSep1 = New System.Windows.Forms.ToolBarButton()
    Me.TBarClear = New System.Windows.Forms.ToolBarButton()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtToYear = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtFromYear = New System.Windows.Forms.TextBox()
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
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(12, 20)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(109, 13)
    Me.Label4.TabIndex = 204
    Me.Label4.Text = "If blank then all Years"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(138, 20)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(137, 13)
    Me.Label3.TabIndex = 203
    Me.Label3.Text = "If blank then use From Year"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(136, 39)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(45, 13)
    Me.Label2.TabIndex = 202
    Me.Label2.Text = "To Year"
    '
    'TxtToYear
    '
    Me.TxtToYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtToYear.Location = New System.Drawing.Point(187, 36)
    Me.TxtToYear.MaxLength = 4
    Me.TxtToYear.Name = "TxtToYear"
    Me.TxtToYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtToYear.TabIndex = 201
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 39)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(55, 13)
    Me.Label1.TabIndex = 200
    Me.Label1.Text = "From Year"
    '
    'TxtFromYear
    '
    Me.TxtFromYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFromYear.Location = New System.Drawing.Point(73, 36)
    Me.TxtFromYear.MaxLength = 4
    Me.TxtFromYear.Name = "TxtFromYear"
    Me.TxtFromYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtFromYear.TabIndex = 199
    '
    'FrmSelYear
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(376, 124)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtToYear)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtFromYear)
    Me.Controls.Add(Me.TbMain)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmSelYear"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Select Year(s)"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region
  Private Sub FrmSelYear_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    Me.Dispose()
  End Sub
  Private Sub FrmSelYear_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    TxtFromYear.Text = MySelFromYear
    TxtToYear.Text = MySelToYear
  End Sub
  Private Sub SelClear()
    MySelFromYear = 0
    MySelToYear = 0
    TxtFromYear.Text = ""
    TxtToYear.Text = ""
  End Sub
  Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
    If e.Button Is TBarReturn Then
      MySelFromYear = MyUtils.CnvSng(TxtFromYear.Text)
      MySelToYear = MyUtils.CnvSng(TxtToYear.Text)
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
  Private Sub TxtFromYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtToYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
End Class






