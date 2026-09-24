Public Class FrmTA001SU_CR
  Inherits System.Windows.Forms.Form
  Dim myTXMVD As TXMVD.MyData
  Dim myTXSUPP As TXSupp.MyData

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
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
  Friend WithEvents RbMV As System.Windows.Forms.RadioButton
  Friend WithEvents RbSU As System.Windows.Forms.RadioButton
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents BtnLookup As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Me.Label2 = New System.Windows.Forms.Label
    Me.TxtListNo = New System.Windows.Forms.TextBox
    Me.RbMV = New System.Windows.Forms.RadioButton
    Me.RbSU = New System.Windows.Forms.RadioButton
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.BtnLookup = New System.Windows.Forms.Button
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(24, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(32, 16)
    Me.Label2.TabIndex = 4
    Me.Label2.Text = "List#"
    '
    'TxtListNo
    '
    Me.TxtListNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtListNo.Location = New System.Drawing.Point(56, 16)
    Me.TxtListNo.MaxLength = 6
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(48, 22)
    Me.TxtListNo.TabIndex = 3
    '
    'RbMV
    '
    Me.RbMV.Checked = True
    Me.RbMV.Location = New System.Drawing.Point(28, 48)
    Me.RbMV.Name = "RbMV"
    Me.RbMV.Size = New System.Drawing.Size(50, 20)
    Me.RbMV.TabIndex = 5
    Me.RbMV.TabStop = True
    Me.RbMV.Text = "MV"
    '
    'RbSU
    '
    Me.RbSU.Location = New System.Drawing.Point(84, 48)
    Me.RbSU.Name = "RbSU"
    Me.RbSU.Size = New System.Drawing.Size(52, 20)
    Me.RbSU.TabIndex = 6
    Me.RbSU.Text = "Suppl"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'BtnLookup
    '
    Me.BtnLookup.Location = New System.Drawing.Point(48, 72)
    Me.BtnLookup.Name = "BtnLookup"
    Me.BtnLookup.Size = New System.Drawing.Size(52, 24)
    Me.BtnLookup.TabIndex = 226
    Me.BtnLookup.Text = "Lookup"
    '
    'FrmTA001SU_CR
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(146, 112)
    Me.Controls.Add(Me.BtnLookup)
    Me.Controls.Add(Me.RbSU)
    Me.Controls.Add(Me.RbMV)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtListNo)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA001SU_CR"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Credit Autofill"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
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
        MyFrmTA001SU.TxtOValue.Text = ._VALUE
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
        MyFrmTA001SU.TxtOValue.Text = ._VALUE
      End With
    End If

    MyFrmTA001SU.LblOListNo.Text = TxtListNo.Text
    Me.Close()

  End Sub
  Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Private Sub FrmTA001SU_CR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmTA001.TBarAttach.Enabled = False
  End Sub
  Private Sub FrmTA001SU_CR_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    'Memory Clenup
    Me.Dispose()
    MyFrmTA001.TBarAttach.Enabled = True
    myTXMVD = Nothing
    myTXSUPP = Nothing
    MyFrmTA001SU_CR = Nothing
  End Sub
End Class






