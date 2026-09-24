Public Class FrmTA222B
    Inherits System.Windows.Forms.Form
		Dim myTXREALBTR As TXRealBTR.myData
    Dim ds As DataSet = New DataSet
    Friend WrkTXREALBTR As Integer
    Friend WrkTxType As String

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
Friend WithEvents lblmessg As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.label3 = New System.Windows.Forms.Label
Me.lblmessg = New System.Windows.Forms.Label
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
Me.label3.Size = New System.Drawing.Size(94, 23)
Me.label3.TabIndex = 6
Me.label3.Text = "New file name"
Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'lblmessg
'
Me.lblmessg.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lblmessg.ForeColor = System.Drawing.Color.Black
Me.lblmessg.Location = New System.Drawing.Point(132, 68)
Me.lblmessg.Name = "lblmessg"
Me.lblmessg.Size = New System.Drawing.Size(324, 44)
Me.lblmessg.TabIndex = 9
Me.lblmessg.Text = "This option will clear all Real Estate records with BTR Data for the Informal Not" & _
    "ices."
Me.lblmessg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'FrmTA222B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(632, 206)
Me.Controls.Add(Me.lblmessg)
Me.Controls.Add(Me.label3)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA222B"
Me.Text = "Clear BTR Data for Informal Notice"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)

End Sub

#End Region

    Private Sub TA222B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
				myTXREALBTR = New TXRealBTR.mydata(MyDBConnect)

        MyFrmTA222.TBarClear.Visible = True
    End Sub

    Private Sub TA222B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        MyFrmTA222.SbpScreen.Text = "TA222B"
        MyUtils.CenterForm(Me.ParentForm, Me)
    End Sub
    Public Sub runClear()
      Dim WrkAnswer As Integer

      WrkAnswer = MessageBox.Show("Proceed with Clear?", "Clear BTR", _
          MessageBoxButtons.YesNo, MessageBoxIcon.Question)
      If WrkAnswer = Windows.Forms.DialogResult.Yes Then
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Me.Refresh()
        myTXREALBTR.ClearBTR()
        MessageBox.Show("Clear of BTR Successful")
        MyFrmTA222.Close()
      Else
        MessageBox.Show("Clear Request Cancelled")
        Windows.Forms.Cursor.Current = Cursors.Default
        Me.Refresh()
      End If

    End Sub
Private Sub lblfilename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblmessg.Click

End Sub
End Class






