Public Class FrmTAE02B
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
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbSortList As System.Windows.Forms.RadioButton
Friend WithEvents RbSelAll As System.Windows.Forms.RadioButton
Friend WithEvents RbSelVeterans As System.Windows.Forms.RadioButton
Friend WithEvents RbSelElderly As System.Windows.Forms.RadioButton
Friend WithEvents RbSelNew As System.Windows.Forms.RadioButton
Friend WithEvents RbSortOrig As System.Windows.Forms.RadioButton
Friend WithEvents ChkAddress As System.Windows.Forms.CheckBox
  Friend WithEvents RbSelTaxable As RadioButton
  Friend WithEvents RbSortNew As System.Windows.Forms.RadioButton
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbSelAll = New System.Windows.Forms.RadioButton()
    Me.RbSelVeterans = New System.Windows.Forms.RadioButton()
    Me.RbSelElderly = New System.Windows.Forms.RadioButton()
    Me.RbSelNew = New System.Windows.Forms.RadioButton()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbSortOrig = New System.Windows.Forms.RadioButton()
    Me.RbSortList = New System.Windows.Forms.RadioButton()
    Me.RbSortNew = New System.Windows.Forms.RadioButton()
    Me.ChkAddress = New System.Windows.Forms.CheckBox()
    Me.RbSelTaxable = New System.Windows.Forms.RadioButton()
    Me.GroupBox1.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbSelTaxable)
    Me.GroupBox1.Controls.Add(Me.RbSelAll)
    Me.GroupBox1.Controls.Add(Me.RbSelVeterans)
    Me.GroupBox1.Controls.Add(Me.RbSelElderly)
    Me.GroupBox1.Controls.Add(Me.RbSelNew)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(20, 108)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(136, 122)
    Me.GroupBox1.TabIndex = 4
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Record Selection"
    '
    'RbSelAll
    '
    Me.RbSelAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSelAll.Checked = True
    Me.RbSelAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSelAll.Location = New System.Drawing.Point(12, 16)
    Me.RbSelAll.Name = "RbSelAll"
    Me.RbSelAll.Size = New System.Drawing.Size(116, 20)
    Me.RbSelAll.TabIndex = 0
    Me.RbSelAll.TabStop = True
    Me.RbSelAll.Text = "All"
    '
    'RbSelVeterans
    '
    Me.RbSelVeterans.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSelVeterans.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSelVeterans.Location = New System.Drawing.Point(12, 76)
    Me.RbSelVeterans.Name = "RbSelVeterans"
    Me.RbSelVeterans.Size = New System.Drawing.Size(116, 20)
    Me.RbSelVeterans.TabIndex = 3
    Me.RbSelVeterans.Text = "Veterans"
    '
    'RbSelElderly
    '
    Me.RbSelElderly.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSelElderly.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSelElderly.Location = New System.Drawing.Point(12, 56)
    Me.RbSelElderly.Name = "RbSelElderly"
    Me.RbSelElderly.Size = New System.Drawing.Size(116, 20)
    Me.RbSelElderly.TabIndex = 2
    Me.RbSelElderly.Text = "Elderly Exemption"
    '
    'RbSelNew
    '
    Me.RbSelNew.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSelNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSelNew.Location = New System.Drawing.Point(12, 36)
    Me.RbSelNew.Name = "RbSelNew"
    Me.RbSelNew.Size = New System.Drawing.Size(116, 20)
    Me.RbSelNew.TabIndex = 1
    Me.RbSelNew.Text = "New Construction"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbSortOrig)
    Me.GroupBox2.Controls.Add(Me.RbSortList)
    Me.GroupBox2.Controls.Add(Me.RbSortNew)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(20, 16)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(168, 80)
    Me.GroupBox2.TabIndex = 8
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Sort Options"
    '
    'RbSortOrig
    '
    Me.RbSortOrig.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortOrig.Checked = True
    Me.RbSortOrig.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortOrig.Location = New System.Drawing.Point(12, 16)
    Me.RbSortOrig.Name = "RbSortOrig"
    Me.RbSortOrig.Size = New System.Drawing.Size(140, 20)
    Me.RbSortOrig.TabIndex = 0
    Me.RbSortOrig.TabStop = True
    Me.RbSortOrig.Text = "Original Owners Name"
    '
    'RbSortList
    '
    Me.RbSortList.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortList.Location = New System.Drawing.Point(12, 56)
    Me.RbSortList.Name = "RbSortList"
    Me.RbSortList.Size = New System.Drawing.Size(140, 20)
    Me.RbSortList.TabIndex = 2
    Me.RbSortList.Text = "List Number"
    '
    'RbSortNew
    '
    Me.RbSortNew.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortNew.Location = New System.Drawing.Point(12, 36)
    Me.RbSortNew.Name = "RbSortNew"
    Me.RbSortNew.Size = New System.Drawing.Size(140, 20)
    Me.RbSortNew.TabIndex = 1
    Me.RbSortNew.Text = "New Owners Name"
    '
    'ChkAddress
    '
    Me.ChkAddress.AutoSize = True
    Me.ChkAddress.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkAddress.Location = New System.Drawing.Point(20, 249)
    Me.ChkAddress.Name = "ChkAddress"
    Me.ChkAddress.Size = New System.Drawing.Size(100, 17)
    Me.ChkAddress.TabIndex = 9
    Me.ChkAddress.Text = "Show Address?"
    Me.ChkAddress.UseVisualStyleBackColor = True
    '
    'RbSelTaxable
    '
    Me.RbSelTaxable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSelTaxable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSelTaxable.Location = New System.Drawing.Point(12, 96)
    Me.RbSelTaxable.Name = "RbSelTaxable"
    Me.RbSelTaxable.Size = New System.Drawing.Size(116, 20)
    Me.RbSelTaxable.TabIndex = 4
    Me.RbSelTaxable.Text = "Exempt to Taxable"
    '
    'FrmTAE02B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(212, 278)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkAddress)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTAE02B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.GroupBox1.ResumeLayout(False)
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
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

    Me.Refresh()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    PrtReport()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub FrmTAE02B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAE02.SbpScreen.Text = "TAE02B"
  End Sub
  Private Sub FrmTAE02B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  End Sub

  Private Sub FrmTAE02B_Load(sender As Object, e As EventArgs) Handles MyBase.Load

  End Sub
End Class






