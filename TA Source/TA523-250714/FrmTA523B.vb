Public Class FrmTA523B
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
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents ChkUpdate As System.Windows.Forms.CheckBox
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbNormal As System.Windows.Forms.RadioButton
Friend WithEvents RbDown As System.Windows.Forms.RadioButton
Friend WithEvents TxtVehYear As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbPriceAll As System.Windows.Forms.RadioButton
Friend WithEvents RbPriceSome As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox3 As GroupBox
  Friend WithEvents RbPct80 As RadioButton
  Friend WithEvents RbPctDefault As RadioButton
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTA523B))
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.ChkUpdate = New System.Windows.Forms.CheckBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbNormal = New System.Windows.Forms.RadioButton()
    Me.RbDown = New System.Windows.Forms.RadioButton()
    Me.TxtVehYear = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbPriceAll = New System.Windows.Forms.RadioButton()
    Me.RbPriceSome = New System.Windows.Forms.RadioButton()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.RbPct80 = New System.Windows.Forms.RadioButton()
    Me.RbPctDefault = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.SuspendLayout()
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'ChkUpdate
    '
    Me.ChkUpdate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkUpdate.Location = New System.Drawing.Point(23, 192)
    Me.ChkUpdate.Name = "ChkUpdate"
    Me.ChkUpdate.Size = New System.Drawing.Size(117, 18)
    Me.ChkUpdate.TabIndex = 2
    Me.ChkUpdate.Text = "Update File?"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbNormal)
    Me.GroupBox1.Controls.Add(Me.RbDown)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(23, 122)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(290, 64)
    Me.GroupBox1.TabIndex = 1
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Last Digit handling method"
    '
    'RbNormal
    '
    Me.RbNormal.AutoSize = True
    Me.RbNormal.Checked = True
    Me.RbNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbNormal.Location = New System.Drawing.Point(6, 19)
    Me.RbNormal.Name = "RbNormal"
    Me.RbNormal.Size = New System.Drawing.Size(258, 17)
    Me.RbNormal.TabIndex = 59
    Me.RbNormal.TabStop = True
    Me.RbNormal.Text = "Normal Rounding (IE: 103 ==> 100, 105 ==> 110)"
    Me.RbNormal.UseVisualStyleBackColor = True
    '
    'RbDown
    '
    Me.RbDown.AutoSize = True
    Me.RbDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbDown.Location = New System.Drawing.Point(6, 41)
    Me.RbDown.Name = "RbDown"
    Me.RbDown.Size = New System.Drawing.Size(253, 17)
    Me.RbDown.TabIndex = 58
    Me.RbDown.Text = "Truncate Down (IE: 103 ==> 100,  105 ==> 100)"
    Me.RbDown.UseVisualStyleBackColor = True
    '
    'TxtVehYear
    '
    Me.TxtVehYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVehYear.Location = New System.Drawing.Point(201, 6)
    Me.TxtVehYear.MaxLength = 4
    Me.TxtVehYear.Name = "TxtVehYear"
    Me.TxtVehYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtVehYear.TabIndex = 0
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(31, 9)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(164, 13)
    Me.Label3.TabIndex = 89
    Me.Label3.Text = "Only price Vehicle Year or higher "
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbPriceAll)
    Me.GroupBox2.Controls.Add(Me.RbPriceSome)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(23, 42)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(295, 35)
    Me.GroupBox2.TabIndex = 88
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Pricing Class Option"
    '
    'RbPriceAll
    '
    Me.RbPriceAll.AutoSize = True
    Me.RbPriceAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPriceAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPriceAll.Location = New System.Drawing.Point(195, 13)
    Me.RbPriceAll.Name = "RbPriceAll"
    Me.RbPriceAll.Size = New System.Drawing.Size(75, 17)
    Me.RbPriceAll.TabIndex = 1
    Me.RbPriceAll.Text = "All Classes"
    Me.RbPriceAll.UseMnemonic = False
    Me.RbPriceAll.UseVisualStyleBackColor = True
    '
    'RbPriceSome
    '
    Me.RbPriceSome.AutoSize = True
    Me.RbPriceSome.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPriceSome.Checked = True
    Me.RbPriceSome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPriceSome.Location = New System.Drawing.Point(15, 13)
    Me.RbPriceSome.Name = "RbPriceSome"
    Me.RbPriceSome.Size = New System.Drawing.Size(153, 17)
    Me.RbPriceSome.TabIndex = 0
    Me.RbPriceSome.TabStop = True
    Me.RbPriceSome.Text = "ONLY Classes 1,2,3,4 & 12"
    Me.RbPriceSome.UseMnemonic = False
    Me.RbPriceSome.UseVisualStyleBackColor = True
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.RbPct80)
    Me.GroupBox3.Controls.Add(Me.RbPctDefault)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(23, 83)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(159, 35)
    Me.GroupBox3.TabIndex = 90
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Value Percentage"
    '
    'RbPct80
    '
    Me.RbPct80.AutoSize = True
    Me.RbPct80.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPct80.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPct80.Location = New System.Drawing.Point(105, 13)
    Me.RbPct80.Name = "RbPct80"
    Me.RbPct80.Size = New System.Drawing.Size(45, 17)
    Me.RbPct80.TabIndex = 1
    Me.RbPct80.Text = "80%"
    Me.RbPct80.UseMnemonic = False
    Me.RbPct80.UseVisualStyleBackColor = True
    '
    'RbPctDefault
    '
    Me.RbPctDefault.AutoSize = True
    Me.RbPctDefault.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPctDefault.Checked = True
    Me.RbPctDefault.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPctDefault.Location = New System.Drawing.Point(15, 13)
    Me.RbPctDefault.Name = "RbPctDefault"
    Me.RbPctDefault.Size = New System.Drawing.Size(59, 17)
    Me.RbPctDefault.TabIndex = 0
    Me.RbPctDefault.TabStop = True
    Me.RbPctDefault.Text = "Default"
    Me.RbPctDefault.UseMnemonic = False
    Me.RbPctDefault.UseVisualStyleBackColor = True
    '
    'FrmTA523B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(331, 224)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.TxtVehYear)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.ChkUpdate)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA523B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

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

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    PrtReport()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
Private Sub FrmTA523B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA523.SbpScreen.Text = "TA523B"
End Sub
Private Sub FrmTA523B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtVehYear, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "vehyear"
        ErrProv.SetError(TxtVehYear, ErrorMsg(I))
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim ds As DataSet = New DataSet
    Dim I As Integer
    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtVehYear.Text) = 0 Then
      ErrorField(I) = "vehyear"
      ErrorMsg(I) = "Vehicle Year is required"
      I = I + 1
    End If
  End Sub
Private Sub TxtVehYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVehYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub FrmTA523B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

End Sub
End Class






