Public Class FrmTAP13B
  Inherits System.Windows.Forms.Form
  Dim myTXDCFRM As TXDCFRM.myData
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
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents label3 As System.Windows.Forms.Label
Friend WithEvents TxtCurrYr As System.Windows.Forms.TextBox
Friend WithEvents Label12 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.label3 = New System.Windows.Forms.Label
Me.TxtCurrYr = New System.Windows.Forms.TextBox
Me.Label12 = New System.Windows.Forms.Label
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
'TxtCurrYr
'
Me.TxtCurrYr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtCurrYr.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtCurrYr.Location = New System.Drawing.Point(132, 18)
Me.TxtCurrYr.MaxLength = 4
Me.TxtCurrYr.Name = "TxtCurrYr"
Me.TxtCurrYr.Size = New System.Drawing.Size(40, 22)
Me.TxtCurrYr.TabIndex = 26
'
'Label12
'
Me.Label12.Location = New System.Drawing.Point(26, 22)
Me.Label12.Name = "Label12"
Me.Label12.Size = New System.Drawing.Size(100, 16)
Me.Label12.TabIndex = 27
Me.Label12.Text = "Current G/L Year"
'
'FrmTAP13B
'
Me.AllowDrop = True
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(197, 61)
Me.ControlBox = False
Me.Controls.Add(Me.TxtCurrYr)
Me.Controls.Add(Me.Label12)
Me.Controls.Add(Me.label3)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTAP13B"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub TAP13B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myTXDCFRM = New TXDCFRM.mydata(MyDBConnect)
  MyFrmTAP13.TBarNew.Visible = False
  MyFrmTAP13.TBarSave.Visible = True
  MyFrmTAP13.TBarPrint.Visible = False
  MyFrmTAP13.TBarDelete.Visible = False
  myTXDCFRM.GetOneRecordP(1)
  If myTXDCFRM.RecordNotFound Then Exit Sub

  If s_chg = False And s_full = False Then    '#sec
    MyFrmTAP13.TBarSave.Visible = False
  End If
  With myTXDCFRM
    TxtCurrYr.Text = ._CURRYR
  End With
End Sub
Private Sub TAP13B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTAP13.SbpScreen.Text = "TAP13B"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  myTXDCFRM.GetOneRecordP(1)
  MovetoFile()
  ' added this too
  If IsNothing(ErrorMsg(0)) Then
    If myTXDCFRM.RecordNotFound Then
      myTXDCFRM.AddOneRecordP()
    Else
      myTXDCFRM.UpdateOneRecordP()
    End If
  Else
    ShowError(ErrorField, ErrorMsg)
    Exit Sub
  End If
  Me.Close()
  End Sub
Private Sub MovetoFile()
  With myTXDCFRM
    ._CURRYR = MyUtils.CnvSng(TxtCurrYr.Text)
  End With
End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtCurrYr, "")
  For I = 0 To ErrorField.GetUpperBound(0)
     Select Case ErrorField(I)
       Case "curryr"
         ErrProv.SetError(TxtCurrYr, ErrorMsg(I))
       Case Nothing
         Exit Sub
     End Select
     Next I
End Sub
Private Sub TxtCurrYr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCurrYr.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






