Public Class FrmTX405_NEW
  Inherits System.Windows.Forms.Form
	Dim myTXINV As TXINV.myData
	Dim myTXTYPE As TXTYPE.myData
	Dim myTXPROF As TXPROF.myData
	Dim WrkContinue As Boolean

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
  Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents BtnContinue As System.Windows.Forms.Button
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  Friend WithEvents TxtType As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents LnkType As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.BtnContinue = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.LnkType = New System.Windows.Forms.LinkLabel()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TxtListNo
    '
    Me.TxtListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtListNo.Location = New System.Drawing.Point(112, 40)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(55, 20)
    Me.TxtListNo.TabIndex = 1
    Me.TxtListNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'BtnContinue
    '
    Me.BtnContinue.Location = New System.Drawing.Point(80, 104)
    Me.BtnContinue.Name = "BtnContinue"
    Me.BtnContinue.Size = New System.Drawing.Size(64, 24)
    Me.BtnContinue.TabIndex = 5
    Me.BtnContinue.Text = "&Continue"
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(72, 64)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(32, 16)
    Me.Label1.TabIndex = 228
    Me.Label1.Text = "Year"
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(112, 64)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtYear.TabIndex = 2
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtType.Location = New System.Drawing.Point(112, 16)
    Me.TxtType.MaxLength = 1
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(16, 20)
    Me.TxtType.TabIndex = 0
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(72, 40)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(32, 16)
    Me.Label2.TabIndex = 233
    Me.Label2.Text = "List"
    '
    'LnkType
    '
    Me.LnkType.Location = New System.Drawing.Point(72, 16)
    Me.LnkType.Name = "LnkType"
    Me.LnkType.Size = New System.Drawing.Size(32, 16)
    Me.LnkType.TabIndex = 234
    Me.LnkType.TabStop = True
    Me.LnkType.Text = "Type"
    '
    'FrmTX405_NEW
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(234, 144)
    Me.ControlBox = False
    Me.Controls.Add(Me.LnkType)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtType)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.TxtListNo)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnContinue)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX405_NEW"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "New Tax Invoice Information"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub BtnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnContinue.Click
    Dim WrkAcct As String
    Me.ErrProv.SetError(TxtListNo, "")
    Me.ErrProv.SetError(TxtYear, "")
    Me.ErrProv.SetError(TxtType, "")

		myTXTYPE = New TXTYPE.mydata(MyDBConnect)
		myTXTYPE.GetOneRecordP(TxtType.Text)
		If myTXTYPE.RecordNotFound Then
			Me.ErrProv.SetError(TxtType, "Tax Type is invalid")
			Exit Sub
		End If

    If MyUtils.CnvSng(TxtListNo.Text) = 0 Then
       Me.ErrProv.SetError(TxtListNo, "List No is required")
       Exit Sub
    End If
    If MyUtils.CnvSng(TxtYear.Text) = 0 Then
       Me.ErrProv.SetError(TxtYear, "Year is required")
       Exit Sub
    End If

    myTXPROF = New TXPROF.mydata(MyDBConnect)
    myTXPROF.GetOneRecordP(TxtType.Text, CSng(TxtYear.Text), "", 0)
    If myTXPROF.RecordNotFound Then
      Me.ErrProv.SetError(TxtType, "Type/Year not found in tax profile (TXPROF)")
      Exit Sub
    End If

    myTXINV = New TXINV.mydata(MyDBConnect)
    myTXINV.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text), MyUtils.CnvSng(TxtYear.Text), TxtType.Text)
		If Not myTXINV.RecordNotFound Then
			Me.ErrProv.SetError(TxtType, "Type/List/Year already exists")
			Exit Sub
		End If

    WrkAcct = TxtYear.Text & TxtType.Text & TxtListNo.Text
    ClearSelAcct()
    SelAcct(0) = WrkAcct
    MyFrmTX405B.ProcessScreen(True)

    WrkContinue = True
    Me.Close()

  End Sub
Private Sub FrmTX405_NEW_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
  If Not WrkContinue Then
    MyFrmTX405.TBarNew.Enabled = True
    MyFrmTX405B.Show()
  End If
End Sub
  Private Sub FrmTX405_NEW_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmTX405.TBarNew.Enabled = False
  End Sub
Private Sub LnkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkType.LinkClicked
  MyFrmListTypes = New FrmListTypes
  MyFrmListTypes.MdiParent = Me.ParentForm
  MyFrmListTypes.WrkType = TxtType.Text
  MyFrmListTypes.Show()

End Sub
Private Sub FrmTX405_NEW_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTX405.SbpScreen.Text = "TX405_NEW"
 End Sub
Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






