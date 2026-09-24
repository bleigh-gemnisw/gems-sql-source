Public Class FrmTX116B
  Inherits System.Windows.Forms.Form
  Dim myTXPAYCR As TXPAYCR.myData
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
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents label3 As System.Windows.Forms.Label
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TxtURL As System.Windows.Forms.TextBox
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents TxtProd As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents RbPP As System.Windows.Forms.RadioButton
Friend WithEvents TxtPartnr As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.label3 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtURL = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtPartnr = New System.Windows.Forms.TextBox()
    Me.TxtProd = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.RbPP = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'label3
    '
    Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label3.Location = New System.Drawing.Point(-100, 74)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(100, 23)
    Me.label3.TabIndex = 6
    Me.label3.Text = "New file name"
    Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(12, 89)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(39, 18)
    Me.Label1.TabIndex = 7
    Me.Label1.Text = "URL"
    '
    'TxtURL
    '
    Me.TxtURL.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtURL.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtURL.Location = New System.Drawing.Point(82, 85)
    Me.TxtURL.MaxLength = 80
    Me.TxtURL.Name = "TxtURL"
    Me.TxtURL.Size = New System.Drawing.Size(490, 22)
    Me.TxtURL.TabIndex = 2
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(11, 34)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(65, 18)
    Me.Label6.TabIndex = 14
    Me.Label6.Text = "Partner ID"
    '
    'TxtPartnr
    '
    Me.TxtPartnr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPartnr.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtPartnr.Location = New System.Drawing.Point(82, 30)
    Me.TxtPartnr.MaxLength = 5
    Me.TxtPartnr.Name = "TxtPartnr"
    Me.TxtPartnr.Size = New System.Drawing.Size(48, 22)
    Me.TxtPartnr.TabIndex = 0
    '
    'TxtProd
    '
    Me.TxtProd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtProd.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtProd.Location = New System.Drawing.Point(82, 57)
    Me.TxtProd.MaxLength = 5
    Me.TxtProd.Name = "TxtProd"
    Me.TxtProd.Size = New System.Drawing.Size(48, 22)
    Me.TxtProd.TabIndex = 18
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(11, 61)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(65, 18)
    Me.Label2.TabIndex = 19
    Me.Label2.Text = "Product ID"
    '
    'RbPP
    '
    Me.RbPP.AutoSize = True
    Me.RbPP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPP.Checked = True
    Me.RbPP.Location = New System.Drawing.Point(51, 7)
    Me.RbPP.Name = "RbPP"
    Me.RbPP.Size = New System.Drawing.Size(79, 17)
    Me.RbPP.TabIndex = 20
    Me.RbPP.TabStop = True
    Me.RbPP.Text = "Point & Pay"
    Me.RbPP.UseMnemonic = False
    Me.RbPP.UseVisualStyleBackColor = True
    '
    'FrmTX116B
    '
    Me.AllowDrop = True
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(583, 119)
    Me.ControlBox = False
    Me.Controls.Add(Me.RbPP)
    Me.Controls.Add(Me.TxtProd)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtPartnr)
    Me.Controls.Add(Me.TxtURL)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX116B"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub TX116B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myTXPAYCR = New TXPAYCR.mydata(MyDBConnect)

  MyFrmTX116.TBarNew.Visible = False
  MyFrmTX116.TBarSave.Visible = True
  MyFrmTX116.TBarPrint.Visible = False
  MyFrmTX116.TBarDelete.Visible = False
  myTXPAYCR.GetOneRecordP("PP")

  If s_chg = False And s_full = False Then    '#sec
    MyFrmTX116.TBarSave.Visible = False
  End If

  If myTXPAYCR.RecordNotFound Then Exit Sub

  With myTXPAYCR
    'Select ._PROVID
    'Case "PP"
    '  RbPP.Checked = True
    'End Select
    TxtPartnr.Text = Trim(._PARTNR)
    TxtProd.Text = Trim(._PROD)
    TxtURL.Text = Trim(._URL)
  End With
End Sub
Private Sub TX116B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX116.SbpScreen.Text = "TX116B"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Public Sub SaveData()
  myTXPAYCR.GetOneRecordP("PP")
  MovetoFile()
  ' added this too
  If myTXPAYCR.RecordNotFound Then
    myTXPAYCR.AddOneRecordP()
  Else
    myTXPAYCR.UpdateOneRecordP()
  End If
  Me.Close()
  End Sub
Private Sub MovetoFile()
  With myTXPAYCR
    If RbPP.Checked Then
      ._PROVID = "PP"
    End If
    ._PARTNR = TxtPartnr.Text
    ._PROD = TxtProd.Text
    ._URL = TxtURL.Text
  End With
End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtPartnr, "")
  ErrProv.SetError(TxtProd, "")
  ErrProv.SetError(TxtURL, "")
  For I = 0 To ErrorField.GetUpperBound(0)
     Select Case ErrorField(I)
       Case "partnr"
         ErrProv.SetError(TxtPartnr, ErrorMsg(I))
       Case "prod"
         ErrProv.SetError(TxtProd, ErrorMsg(I))
       Case "url"
         ErrProv.SetError(TxtURL, ErrorMsg(I))
       Case Nothing
         Exit Sub
     End Select
     Next I
End Sub
End Class






