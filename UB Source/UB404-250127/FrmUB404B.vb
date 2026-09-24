Public Class FrmUB404B
  Inherits System.Windows.Forms.Form

  Friend ds As DataSet = New DataSet
  Dim Wrkdistr As Decimal
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents DtPckRead As System.Windows.Forms.DateTimePicker
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents RbPer4th As System.Windows.Forms.RadioButton
  Friend WithEvents RbPer3rd As System.Windows.Forms.RadioButton
  Friend WithEvents RbPer2nd As System.Windows.Forms.RadioButton
  Friend WithEvents RbPer1st As System.Windows.Forms.RadioButton
  Friend WithEvents RbPerAnnual As System.Windows.Forms.RadioButton
  Dim Wrkdiphas As Decimal
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
Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
Friend WithEvents TxtPhaseTo As System.Windows.Forms.TextBox
Friend WithEvents TxtDistTo As System.Windows.Forms.TextBox
Friend WithEvents TxtUBType As System.Windows.Forms.TextBox
Friend WithEvents TxtPhase As System.Windows.Forms.TextBox
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents LnkDistTo As System.Windows.Forms.LinkLabel
Friend WithEvents LnkUBType As System.Windows.Forms.LinkLabel
Friend WithEvents LnkDist As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TxtPhaseTo = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.TxtDistTo = New System.Windows.Forms.TextBox
Me.LnkDistTo = New System.Windows.Forms.LinkLabel
Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Label4 = New System.Windows.Forms.Label
Me.TxtUBType = New System.Windows.Forms.TextBox
Me.LnkUBType = New System.Windows.Forms.LinkLabel
Me.TxtPhase = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
Me.TxtDist = New System.Windows.Forms.TextBox
Me.LnkDist = New System.Windows.Forms.LinkLabel
Me.GroupBox2 = New System.Windows.Forms.GroupBox
Me.RbPer4th = New System.Windows.Forms.RadioButton
Me.RbPer3rd = New System.Windows.Forms.RadioButton
Me.RbPer2nd = New System.Windows.Forms.RadioButton
Me.RbPer1st = New System.Windows.Forms.RadioButton
Me.RbPerAnnual = New System.Windows.Forms.RadioButton
Me.Label1 = New System.Windows.Forms.Label
Me.DtPckRead = New System.Windows.Forms.DateTimePicker
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox2.SuspendLayout()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'TxtPhaseTo
'
Me.TxtPhaseTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtPhaseTo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtPhaseTo.Location = New System.Drawing.Point(192, 68)
Me.TxtPhaseTo.MaxLength = 2
Me.TxtPhaseTo.Name = "TxtPhaseTo"
Me.TxtPhaseTo.Size = New System.Drawing.Size(24, 22)
Me.TxtPhaseTo.TabIndex = 3
'
'Label3
'
Me.Label3.BackColor = System.Drawing.SystemColors.Control
Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
Me.Label3.Location = New System.Drawing.Point(152, 72)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(40, 14)
Me.Label3.TabIndex = 334
Me.Label3.Text = "Phase"
'
'TxtDistTo
'
Me.TxtDistTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtDistTo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDistTo.Location = New System.Drawing.Point(104, 68)
Me.TxtDistTo.MaxLength = 3
Me.TxtDistTo.Name = "TxtDistTo"
Me.TxtDistTo.Size = New System.Drawing.Size(32, 22)
Me.TxtDistTo.TabIndex = 2
'
'LnkDistTo
'
Me.LnkDistTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkDistTo.Location = New System.Drawing.Point(40, 72)
Me.LnkDistTo.Name = "LnkDistTo"
Me.LnkDistTo.Size = New System.Drawing.Size(48, 16)
Me.LnkDistTo.TabIndex = 330
Me.LnkDistTo.TabStop = True
Me.LnkDistTo.Text = "District"
'
'ErrorProvider1
'
Me.ErrorProvider1.ContainerControl = Me
'
'Label4
'
Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label4.ForeColor = System.Drawing.SystemColors.WindowText
Me.Label4.Location = New System.Drawing.Point(135, 52)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(31, 13)
Me.Label4.TabIndex = 333
Me.Label4.Text = "To"
'
'TxtUBType
'
Me.TxtUBType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtUBType.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtUBType.Location = New System.Drawing.Point(104, 112)
Me.TxtUBType.MaxLength = 2
Me.TxtUBType.Name = "TxtUBType"
Me.TxtUBType.Size = New System.Drawing.Size(24, 22)
Me.TxtUBType.TabIndex = 4
'
'LnkUBType
'
Me.LnkUBType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkUBType.Location = New System.Drawing.Point(40, 118)
Me.LnkUBType.Name = "LnkUBType"
Me.LnkUBType.Size = New System.Drawing.Size(64, 16)
Me.LnkUBType.TabIndex = 331
Me.LnkUBType.TabStop = True
Me.LnkUBType.Text = "Bill Type"
'
'TxtPhase
'
Me.TxtPhase.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtPhase.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtPhase.Location = New System.Drawing.Point(192, 26)
Me.TxtPhase.MaxLength = 2
Me.TxtPhase.Name = "TxtPhase"
Me.TxtPhase.Size = New System.Drawing.Size(24, 22)
Me.TxtPhase.TabIndex = 1
'
'Label5
'
Me.Label5.BackColor = System.Drawing.SystemColors.Control
Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label5.ForeColor = System.Drawing.SystemColors.WindowText
Me.Label5.Location = New System.Drawing.Point(152, 29)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(40, 16)
Me.Label5.TabIndex = 332
Me.Label5.Text = "Phase"
'
'TxtDist
'
Me.TxtDist.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtDist.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDist.Location = New System.Drawing.Point(104, 23)
Me.TxtDist.MaxLength = 3
Me.TxtDist.Name = "TxtDist"
Me.TxtDist.Size = New System.Drawing.Size(32, 22)
Me.TxtDist.TabIndex = 0
'
'LnkDist
'
Me.LnkDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkDist.Location = New System.Drawing.Point(40, 28)
Me.LnkDist.Name = "LnkDist"
Me.LnkDist.Size = New System.Drawing.Size(48, 16)
Me.LnkDist.TabIndex = 329
Me.LnkDist.TabStop = True
Me.LnkDist.Text = "District"
'
'GroupBox2
'
Me.GroupBox2.Controls.Add(Me.RbPer4th)
Me.GroupBox2.Controls.Add(Me.RbPer3rd)
Me.GroupBox2.Controls.Add(Me.RbPer2nd)
Me.GroupBox2.Controls.Add(Me.RbPer1st)
Me.GroupBox2.Controls.Add(Me.RbPerAnnual)
Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox2.ForeColor = System.Drawing.Color.Maroon
Me.GroupBox2.Location = New System.Drawing.Point(249, 12)
Me.GroupBox2.Name = "GroupBox2"
Me.GroupBox2.Size = New System.Drawing.Size(128, 98)
Me.GroupBox2.TabIndex = 335
Me.GroupBox2.TabStop = False
Me.GroupBox2.Text = "Billing Period"
'
'RbPer4th
'
Me.RbPer4th.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbPer4th.ForeColor = System.Drawing.SystemColors.ControlText
Me.RbPer4th.Location = New System.Drawing.Point(8, 80)
Me.RbPer4th.Name = "RbPer4th"
Me.RbPer4th.Size = New System.Drawing.Size(76, 16)
Me.RbPer4th.TabIndex = 307
Me.RbPer4th.Text = "4th Period"
'
'RbPer3rd
'
Me.RbPer3rd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbPer3rd.ForeColor = System.Drawing.SystemColors.ControlText
Me.RbPer3rd.Location = New System.Drawing.Point(8, 64)
Me.RbPer3rd.Name = "RbPer3rd"
Me.RbPer3rd.Size = New System.Drawing.Size(76, 16)
Me.RbPer3rd.TabIndex = 306
Me.RbPer3rd.Text = "3rd Period"
'
'RbPer2nd
'
Me.RbPer2nd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbPer2nd.ForeColor = System.Drawing.SystemColors.ControlText
Me.RbPer2nd.Location = New System.Drawing.Point(8, 48)
Me.RbPer2nd.Name = "RbPer2nd"
Me.RbPer2nd.Size = New System.Drawing.Size(80, 16)
Me.RbPer2nd.TabIndex = 305
Me.RbPer2nd.Text = "2nd Period"
'
'RbPer1st
'
Me.RbPer1st.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbPer1st.ForeColor = System.Drawing.SystemColors.ControlText
Me.RbPer1st.Location = New System.Drawing.Point(8, 32)
Me.RbPer1st.Name = "RbPer1st"
Me.RbPer1st.Size = New System.Drawing.Size(76, 16)
Me.RbPer1st.TabIndex = 304
Me.RbPer1st.Text = "1st Period"
'
'RbPerAnnual
'
Me.RbPerAnnual.Checked = True
Me.RbPerAnnual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbPerAnnual.ForeColor = System.Drawing.SystemColors.ControlText
Me.RbPerAnnual.Location = New System.Drawing.Point(8, 16)
Me.RbPerAnnual.Name = "RbPerAnnual"
Me.RbPerAnnual.Size = New System.Drawing.Size(60, 16)
Me.RbPerAnnual.TabIndex = 303
Me.RbPerAnnual.TabStop = True
Me.RbPerAnnual.Text = "Annual"
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(40, 152)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(108, 20)
Me.Label1.TabIndex = 354
Me.Label1.Text = "Meter Reading Date"
'
'DtPckRead
'
Me.DtPckRead.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckRead.Location = New System.Drawing.Point(148, 152)
Me.DtPckRead.Name = "DtPckRead"
Me.DtPckRead.Size = New System.Drawing.Size(88, 20)
Me.DtPckRead.TabIndex = 353
'
'FrmUB404B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(389, 181)
Me.ControlBox = False
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.DtPckRead)
Me.Controls.Add(Me.GroupBox2)
Me.Controls.Add(Me.TxtDistTo)
Me.Controls.Add(Me.LnkDistTo)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.TxtUBType)
Me.Controls.Add(Me.LnkUBType)
Me.Controls.Add(Me.TxtPhase)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.TxtDist)
Me.Controls.Add(Me.LnkDist)
Me.Controls.Add(Me.TxtPhaseTo)
Me.Controls.Add(Me.Label3)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
Me.MaximizeBox = False
Me.Name = "FrmUB404B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox2.ResumeLayout(False)
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmUB404B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Wrkdistr = 0
  Wrkdiphas = 0
End Sub
Private Sub FrmUB404B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB404.SbpScreen.Text = "UB404B"
  MyFrmUB404.TBarPrint.Enabled = True
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub LnkDistrict_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDist.LinkClicked
  MyFrmListDist = New FrmListDist
  MyFrmListDist.MdiParent = Me.ParentForm
  MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
  MyFrmListDist.WrkPhase = MyUtils.CnvSng(TxtPhase.Text)
  MyFrmListDist.Wrkwhichdist = "F"
  MyFrmListDist.Show()
  Me.Hide()
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtPhase_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub LinkUBType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkUBType.LinkClicked
  MyFrmListUBType = New FrmListUBType
  MyFrmListUBType.MdiParent = Me.ParentForm
  MyFrmListUBType.WrkType = TxtUBType.Text
  MyFrmListUBType.Show()
  Me.Hide()
End Sub

Private Sub LinkDistrictto_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDistTo.LinkClicked
  MyFrmListDist = New FrmListDist
  MyFrmListDist.MdiParent = Me.ParentForm
  MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDistTo.Text)
  MyFrmListDist.WrkPhase = MyUtils.CnvSng(TxtPhaseTo.Text)
  MyFrmListDist.Wrkwhichdist = "T"
  MyFrmListDist.Show()
  Me.Hide()
End Sub

Private Sub txtDistto_Keypressed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub txtPhaseto_Keypressed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    Dim myUTTYPE As UTTYPE.myData

    myUTTYPE = New UTTYPE.mydata(MyDBConnect)

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtDist.Text) > MyUtils.CnvSng(TxtDistTo.Text) Then
      ErrorField(I) = "TxtDist"
      ErrorMsg(I) = "Invalid District Range"
      I = I + 1
      End If
    If MyUtils.CnvSng(TxtDist.Text) = MyUtils.CnvSng(TxtDistTo.Text) And _
      MyUtils.CnvSng(TxtPhase.Text) > MyUtils.CnvSng(TxtPhaseTo.Text) Then
      ErrorField(I) = "TxtPhase"
      ErrorMsg(I) = "Invalid Phase Range"
      I = I + 1
      End If

    myUTTYPE.GetOneRecordP(TxtUBType.Text)
    If myUTTYPE.RecordNotFound Then
      ErrorField(I) = "TxtType"
      ErrorMsg(I) = "Invalid Utility Type"
      I = I + 1
    End If

  End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtDist, "")
    ErrProv.SetError(TxtPhase, "")
    ErrProv.SetError(TxtUBType, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "TxtDist"
        ErrProv.SetError(TxtDist, ErrorMsg(I))
      Case "TxtPhase"
        ErrProv.SetError(TxtPhase, ErrorMsg(I))
      Case "TxtType"
        ErrProv.SetError(TxtUBType, ErrorMsg(I))
      Case Nothing
        Exit Sub
      End Select
    Next I
  End Sub
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
End Class






