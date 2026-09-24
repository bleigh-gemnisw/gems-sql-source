Public Class FrmTA001SU_CR
  Inherits System.Windows.Forms.Form
  Dim myTXMVD As TXMVD.MyData
  Dim myTXSUPP As TXSupp.MyData
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RbManual As RadioButton
    Friend WithEvents BtnLookup As Button
    Friend WithEvents RbSU As RadioButton
    Friend WithEvents RbMV As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtListNo As TextBox
    Friend WithEvents BtnClear As Button
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
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.BtnClear = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbManual = New System.Windows.Forms.RadioButton()
    Me.BtnLookup = New System.Windows.Forms.Button()
    Me.RbSU = New System.Windows.Forms.RadioButton()
    Me.RbMV = New System.Windows.Forms.RadioButton()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'BtnClear
    '
    Me.BtnClear.Location = New System.Drawing.Point(30, 148)
    Me.BtnClear.Name = "BtnClear"
    Me.BtnClear.Size = New System.Drawing.Size(157, 24)
    Me.BtnClear.TabIndex = 228
    Me.BtnClear.Text = "Clear Credit Vehicle Data"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(88, 128)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 13)
    Me.Label1.TabIndex = 229
    Me.Label1.Text = "--- or ---"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbManual)
    Me.GroupBox1.Controls.Add(Me.BtnLookup)
    Me.GroupBox1.Controls.Add(Me.RbSU)
    Me.GroupBox1.Controls.Add(Me.RbMV)
    Me.GroupBox1.Controls.Add(Me.Label2)
    Me.GroupBox1.Controls.Add(Me.TxtListNo)
    Me.GroupBox1.Location = New System.Drawing.Point(7, 12)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(202, 104)
    Me.GroupBox1.TabIndex = 230
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Autofill"
    '
    'RbManual
    '
    Me.RbManual.AutoSize = True
    Me.RbManual.Location = New System.Drawing.Point(137, 47)
    Me.RbManual.Name = "RbManual"
    Me.RbManual.Size = New System.Drawing.Size(60, 17)
    Me.RbManual.TabIndex = 233
    Me.RbManual.Text = "Manual"
    '
    'BtnLookup
    '
    Me.BtnLookup.Location = New System.Drawing.Point(23, 70)
    Me.BtnLookup.Name = "BtnLookup"
    Me.BtnLookup.Size = New System.Drawing.Size(157, 24)
    Me.BtnLookup.TabIndex = 232
    Me.BtnLookup.Text = "Populate Credit Vehicle Data"
    '
    'RbSU
    '
    Me.RbSU.AutoSize = True
    Me.RbSU.Location = New System.Drawing.Point(79, 47)
    Me.RbSU.Name = "RbSU"
    Me.RbSU.Size = New System.Drawing.Size(52, 17)
    Me.RbSU.TabIndex = 231
    Me.RbSU.Text = "Suppl"
    '
    'RbMV
    '
    Me.RbMV.AutoSize = True
    Me.RbMV.Checked = True
    Me.RbMV.Location = New System.Drawing.Point(23, 47)
    Me.RbMV.Name = "RbMV"
    Me.RbMV.Size = New System.Drawing.Size(41, 17)
    Me.RbMV.TabIndex = 230
    Me.RbMV.TabStop = True
    Me.RbMV.Text = "MV"
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(7, 23)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(32, 16)
    Me.Label2.TabIndex = 229
    Me.Label2.Text = "List#"
    '
    'TxtListNo
    '
    Me.TxtListNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtListNo.Location = New System.Drawing.Point(40, 19)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(60, 22)
    Me.TxtListNo.TabIndex = 228
    '
    'FrmTA001SU_CR
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(221, 184)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnClear)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA001SU_CR"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Credit Autofill/Clear"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub BtnLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLookup.Click
    Me.ErrProv.SetError(TxtListNo, "")

    If TxtListNo.Text = "" Then
      Me.ErrProv.SetError(TxtListNo, "List # is required")
      Exit Sub
    End If

    If RbMV.Checked Then
      myTXMVD = New TXMVD.MyData(myDBConnect)
      myTXMVD.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text))
      If myTXMVD.RecordNotFound Then
        Me.ErrProv.SetError(TxtListNo, "Record not found")
        Exit Sub
      End If

      With myTXMVD
        MyFrmTA001SU.TxtOMake.Text = Trim(._MAKE)
        MyFrmTA001SU.TxtOModel.Text = Trim(._MODEL)
        MyFrmTA001SU.TxtOYear.Text = ._YEAR
        MyFrmTA001SU.TxtOClass.Text = ._CLASS
        MyFrmTA001SU.TxtOVIN.Text = Trim(._VINNO)
        MyFrmTA001SU.TxtORegNo.Text = Trim(._REGNO)
        ' MyFrmTA001SU.TxtOValue.Text = ._VALUE
        MyFrmTA001SU.LblValuecr.Text = ._VALUE
      End With
    End If

    If RbSU.Checked Then
      myTXSUPP = New TXSupp.MyData(myDBConnect)
      myTXSUPP.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text))
      If myTXSUPP.RecordNotFound Then
        Me.ErrProv.SetError(TxtListNo, "Record not found")
        Exit Sub
      End If
      With myTXSUPP
        MyFrmTA001SU.TxtOMake.Text = Trim(._MAKE)
        MyFrmTA001SU.TxtOModel.Text = Trim(._MODEL)
        MyFrmTA001SU.TxtOYear.Text = ._YEAR
        MyFrmTA001SU.TxtOClass.Text = ._CLASS
        MyFrmTA001SU.TxtOVIN.Text = Trim(._VINNO)
        MyFrmTA001SU.TxtORegNo.Text = Trim(._REGNO)
        ' MyFrmTA001SU.TxtOValue.Text = ._VALUE
        MyFrmTA001SU.LblValuecr.Text = ._VALUE
      End With
    End If

    'MK 10/29/25 Begin
    MyManual = False
    If RbManual.Checked Then
      MyManual = True
    End If
    'MK 10/29/25 End

    MyFrmTA001SU.LblOListNo.Text = TxtListNo.Text
    Me.Close()

  End Sub

  'MK 11/6/25 Begin
  Private Sub BtnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClear.Click
    With MyFrmTA001SU
      .TxtOMake.Text = String.Empty
      .TxtOModel.Text = String.Empty
      .TxtOYear.Text = String.Empty
      .TxtOClass.Text = String.Empty
      .TxtOVIN.Text = String.Empty
      .TxtORegNo.Text = String.Empty
      .TxtOAss.Text = String.Empty
      .LblValuecr.Text = String.Empty
      .LblOListNo.Text = String.Empty
      .LblMSRPCalcCr.Text = String.Empty
      .LblMSRPcr.Text = String.Empty
    End With
    Me.Close()
  End Sub
  'MK 11/6/25 End
  Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Private Sub FrmTA001SU_CR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmTA001.TBarAttach.Enabled = False
  End Sub
  Private Sub FrmTA001SU_CR_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    'Memory Cleanup
    Me.Dispose()
    MyFrmTA001.TBarAttach.Enabled = True
    myTXMVD = Nothing
    myTXSUPP = Nothing
    MyFrmTA001SU_CR = Nothing
  End Sub

End Class






