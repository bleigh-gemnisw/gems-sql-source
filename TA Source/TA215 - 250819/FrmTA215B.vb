Public Class FrmTA215B
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
Friend WithEvents TxtIncomeLevel As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtSubdivision As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TxtCategory As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents ChkFrozenFile As System.Windows.Forms.CheckBox
Friend WithEvents TxtTaxExempt As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTA215B))
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Label4 = New System.Windows.Forms.Label
Me.TxtCategory = New System.Windows.Forms.TextBox
Me.TxtSubdivision = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.TxtIncomeLevel = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.ChkFrozenFile = New System.Windows.Forms.CheckBox
Me.TxtTaxExempt = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
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
'Label4
'
Me.Label4.Location = New System.Drawing.Point(38, 30)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(61, 20)
Me.Label4.TabIndex = 56
Me.Label4.Text = "Category"
'
'TxtCategory
'
Me.TxtCategory.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtCategory.Location = New System.Drawing.Point(126, 30)
Me.TxtCategory.MaxLength = 1
Me.TxtCategory.Name = "TxtCategory"
Me.TxtCategory.Size = New System.Drawing.Size(19, 20)
Me.TxtCategory.TabIndex = 50
'
'TxtSubdivision
'
Me.TxtSubdivision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtSubdivision.Location = New System.Drawing.Point(126, 60)
Me.TxtSubdivision.MaxLength = 1
Me.TxtSubdivision.Name = "TxtSubdivision"
Me.TxtSubdivision.Size = New System.Drawing.Size(19, 20)
Me.TxtSubdivision.TabIndex = 57
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(38, 60)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(70, 20)
Me.Label1.TabIndex = 58
Me.Label1.Text = "Subdivision"
'
'TxtIncomeLevel
'
Me.TxtIncomeLevel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtIncomeLevel.Location = New System.Drawing.Point(126, 86)
Me.TxtIncomeLevel.MaxLength = 1
Me.TxtIncomeLevel.Name = "TxtIncomeLevel"
Me.TxtIncomeLevel.Size = New System.Drawing.Size(19, 20)
Me.TxtIncomeLevel.TabIndex = 59
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(38, 89)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(82, 20)
Me.Label2.TabIndex = 60
Me.Label2.Text = "Income Level"
'
'ChkFrozenFile
'
Me.ChkFrozenFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkFrozenFile.Location = New System.Drawing.Point(41, 147)
Me.ChkFrozenFile.Name = "ChkFrozenFile"
Me.ChkFrozenFile.Size = New System.Drawing.Size(117, 17)
Me.ChkFrozenFile.TabIndex = 61
Me.ChkFrozenFile.Text = "Use Frozen List?"
'
'TxtTaxExempt
'
Me.TxtTaxExempt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtTaxExempt.Location = New System.Drawing.Point(126, 114)
Me.TxtTaxExempt.MaxLength = 1
Me.TxtTaxExempt.Name = "TxtTaxExempt"
Me.TxtTaxExempt.Size = New System.Drawing.Size(19, 20)
Me.TxtTaxExempt.TabIndex = 62
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(38, 117)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(82, 20)
Me.Label3.TabIndex = 63
Me.Label3.Text = "Tax Exempt"
'
'FrmTA215B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(189, 189)
Me.ControlBox = False
Me.Controls.Add(Me.TxtTaxExempt)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.ChkFrozenFile)
Me.Controls.Add(Me.TxtIncomeLevel)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.TxtSubdivision)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.TxtCategory)
Me.Controls.Add(Me.Label4)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA215B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
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
Private Sub FrmTA215B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA215.SbpScreen.Text = "TA215B"
End Sub
Private Sub FrmTA215B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next
  End Sub

Private Sub FrmTA215B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  TxtTaxExempt.Text = "X"
End Sub
End Class






