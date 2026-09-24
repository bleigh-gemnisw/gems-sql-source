Public Class FrmTX210B
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
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents RbComplete As System.Windows.Forms.RadioButton
Friend WithEvents RbPaid As System.Windows.Forms.RadioButton
Friend WithEvents RbBalances As System.Windows.Forms.RadioButton
Friend WithEvents TxtType As System.Windows.Forms.TextBox
Friend WithEvents ChkHeaders As System.Windows.Forms.CheckBox
Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents RbAddendum As System.Windows.Forms.RadioButton
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents LnkType As System.Windows.Forms.LinkLabel
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents RbAll As System.Windows.Forms.RadioButton
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbSortList As System.Windows.Forms.RadioButton
Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTX210B))
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.RbAll = New System.Windows.Forms.RadioButton
Me.RbComplete = New System.Windows.Forms.RadioButton
Me.RbAddendum = New System.Windows.Forms.RadioButton
Me.RbPaid = New System.Windows.Forms.RadioButton
Me.RbBalances = New System.Windows.Forms.RadioButton
Me.TxtType = New System.Windows.Forms.TextBox
Me.TxtGLYear = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.ChkHeaders = New System.Windows.Forms.CheckBox
Me.GroupBox3 = New System.Windows.Forms.GroupBox
Me.DtPckTo = New System.Windows.Forms.DateTimePicker
Me.Label2 = New System.Windows.Forms.Label
Me.DtPckFrom = New System.Windows.Forms.DateTimePicker
Me.Label1 = New System.Windows.Forms.Label
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.LnkType = New System.Windows.Forms.LinkLabel
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TxtDist = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.GroupBox2 = New System.Windows.Forms.GroupBox
Me.RbSortList = New System.Windows.Forms.RadioButton
Me.RbSortName = New System.Windows.Forms.RadioButton
Me.GroupBox1.SuspendLayout()
Me.GroupBox3.SuspendLayout()
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox2.SuspendLayout()
Me.SuspendLayout()
'
'ImageList1
'
Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
Me.ImageList1.Images.SetKeyName(0, "")
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.RbAll)
Me.GroupBox1.Controls.Add(Me.RbComplete)
Me.GroupBox1.Controls.Add(Me.RbAddendum)
Me.GroupBox1.Controls.Add(Me.RbPaid)
Me.GroupBox1.Controls.Add(Me.RbBalances)
Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox1.Location = New System.Drawing.Point(12, 171)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(300, 123)
Me.GroupBox1.TabIndex = 6
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "Ratebook Report Selection"
'
'RbAll
'
Me.RbAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbAll.Location = New System.Drawing.Point(12, 96)
Me.RbAll.Name = "RbAll"
Me.RbAll.Size = New System.Drawing.Size(272, 20)
Me.RbAll.TabIndex = 4
Me.RbAll.Text = "All Years (All activity for all G/L years)"
'
'RbComplete
'
Me.RbComplete.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbComplete.Checked = True
Me.RbComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbComplete.Location = New System.Drawing.Point(12, 16)
Me.RbComplete.Name = "RbComplete"
Me.RbComplete.Size = New System.Drawing.Size(272, 20)
Me.RbComplete.TabIndex = 0
Me.RbComplete.TabStop = True
Me.RbComplete.Text = "Complete (All activity for one G/L year)"
'
'RbAddendum
'
Me.RbAddendum.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbAddendum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbAddendum.Location = New System.Drawing.Point(12, 76)
Me.RbAddendum.Name = "RbAddendum"
Me.RbAddendum.Size = New System.Drawing.Size(272, 20)
Me.RbAddendum.TabIndex = 3
Me.RbAddendum.Text = "Addendum (Only C/C adds)"
'
'RbPaid
'
Me.RbPaid.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbPaid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbPaid.Location = New System.Drawing.Point(12, 36)
Me.RbPaid.Name = "RbPaid"
Me.RbPaid.Size = New System.Drawing.Size(272, 20)
Me.RbPaid.TabIndex = 1
Me.RbPaid.Text = "Paid Accounts Only"
'
'RbBalances
'
Me.RbBalances.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbBalances.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbBalances.Location = New System.Drawing.Point(12, 56)
Me.RbBalances.Name = "RbBalances"
Me.RbBalances.Size = New System.Drawing.Size(272, 20)
Me.RbBalances.TabIndex = 2
Me.RbBalances.Text = "Balances Only"
'
'TxtType
'
Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtType.Location = New System.Drawing.Point(116, 12)
Me.TxtType.MaxLength = 20
Me.TxtType.Name = "TxtType"
Me.TxtType.Size = New System.Drawing.Size(18, 20)
Me.TxtType.TabIndex = 1
'
'TxtGLYear
'
Me.TxtGLYear.Location = New System.Drawing.Point(116, 41)
Me.TxtGLYear.MaxLength = 4
Me.TxtGLYear.Name = "TxtGLYear"
Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
Me.TxtGLYear.TabIndex = 2
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(28, 45)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(84, 16)
Me.Label4.TabIndex = 11
Me.Label4.Text = "Grand List Year"
'
'ChkHeaders
'
Me.ChkHeaders.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkHeaders.Checked = True
Me.ChkHeaders.CheckState = System.Windows.Forms.CheckState.Checked
Me.ChkHeaders.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.ChkHeaders.Location = New System.Drawing.Point(27, 93)
Me.ChkHeaders.Name = "ChkHeaders"
Me.ChkHeaders.Size = New System.Drawing.Size(104, 16)
Me.ChkHeaders.TabIndex = 4
Me.ChkHeaders.Text = "Print Headers?"
'
'GroupBox3
'
Me.GroupBox3.Controls.Add(Me.DtPckTo)
Me.GroupBox3.Controls.Add(Me.Label2)
Me.GroupBox3.Controls.Add(Me.DtPckFrom)
Me.GroupBox3.Controls.Add(Me.Label1)
Me.GroupBox3.Location = New System.Drawing.Point(12, 115)
Me.GroupBox3.Name = "GroupBox3"
Me.GroupBox3.Size = New System.Drawing.Size(300, 52)
Me.GroupBox3.TabIndex = 5
Me.GroupBox3.TabStop = False
Me.GroupBox3.Text = "Payment Date Range"
'
'DtPckTo
'
Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckTo.Location = New System.Drawing.Point(196, 20)
Me.DtPckTo.Name = "DtPckTo"
Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
Me.DtPckTo.TabIndex = 1
Me.DtPckTo.Value = New Date(2005, 10, 6, 9, 11, 0, 906)
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(156, 24)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(28, 16)
Me.Label2.TabIndex = 9
Me.Label2.Text = "To "
'
'DtPckFrom
'
Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckFrom.Location = New System.Drawing.Point(52, 20)
Me.DtPckFrom.Name = "DtPckFrom"
Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
Me.DtPckFrom.TabIndex = 0
Me.DtPckFrom.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(12, 20)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(36, 16)
Me.Label1.TabIndex = 7
Me.Label1.Text = "From"
'
'LnkType
'
Me.LnkType.Location = New System.Drawing.Point(32, 16)
Me.LnkType.Name = "LnkType"
Me.LnkType.Size = New System.Drawing.Size(80, 16)
Me.LnkType.TabIndex = 0
Me.LnkType.TabStop = True
Me.LnkType.Text = "Type to print"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'TxtDist
'
Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDist.Location = New System.Drawing.Point(116, 67)
Me.TxtDist.MaxLength = 4
Me.TxtDist.Name = "TxtDist"
Me.TxtDist.Size = New System.Drawing.Size(32, 20)
Me.TxtDist.TabIndex = 3
'
'Label3
'
Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label3.Location = New System.Drawing.Point(28, 70)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(42, 17)
Me.Label3.TabIndex = 55
Me.Label3.Text = "District"
'
'GroupBox2
'
Me.GroupBox2.Controls.Add(Me.RbSortList)
Me.GroupBox2.Controls.Add(Me.RbSortName)
Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox2.Location = New System.Drawing.Point(231, 12)
Me.GroupBox2.Name = "GroupBox2"
Me.GroupBox2.Size = New System.Drawing.Size(96, 58)
Me.GroupBox2.TabIndex = 56
Me.GroupBox2.TabStop = False
Me.GroupBox2.Text = "Sort Options"
'
'RbSortList
'
Me.RbSortList.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbSortList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbSortList.Location = New System.Drawing.Point(6, 30)
Me.RbSortList.Name = "RbSortList"
Me.RbSortList.Size = New System.Drawing.Size(67, 20)
Me.RbSortList.TabIndex = 3
Me.RbSortList.Text = "List #"
'
'RbSortName
'
Me.RbSortName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbSortName.Checked = True
Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbSortName.Location = New System.Drawing.Point(6, 14)
Me.RbSortName.Name = "RbSortName"
Me.RbSortName.Size = New System.Drawing.Size(67, 20)
Me.RbSortName.TabIndex = 1
Me.RbSortName.TabStop = True
Me.RbSortName.Text = "Name"
'
'FrmTX210B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(339, 304)
Me.ControlBox = False
Me.Controls.Add(Me.GroupBox2)
Me.Controls.Add(Me.TxtDist)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.LnkType)
Me.Controls.Add(Me.GroupBox3)
Me.Controls.Add(Me.ChkHeaders)
Me.Controls.Add(Me.TxtGLYear)
Me.Controls.Add(Me.TxtType)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.GroupBox1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX210B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.GroupBox1.ResumeLayout(False)
Me.GroupBox3.ResumeLayout(False)
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
    GetReportMargins()
    PrtReport()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
Private Sub FrmTX210B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    DtPckFrom.Value = Date.Today
    DtPckTo.Value = Date.Today
End Sub
Private Sub FrmTX210B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX210.SbpScreen.Text = "TX210B"
End Sub

Private Sub LnkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkType.LinkClicked
  MyFrmListTypes = New FrmListTypes
  MyFrmListTypes.MdiParent = Me.ParentForm
  MyFrmListTypes.WrkType = TxtType.Text
  MyFrmListTypes.Show()

End Sub
Private Sub FrmTX210B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLYear, "")
    ErrProv.SetError(TxtType, "")
    ErrProv.SetError(DtPckFrom, "")
    ErrProv.SetError(DtPckTo, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "glyear"
        ErrProv.SetError(TxtGLYear, ErrorMsg(I))
      Case "type"
        ErrProv.SetError(TxtType, ErrorMsg(I))
      Case "from"
        ErrProv.SetError(DtPckFrom, ErrorMsg(I))
      Case "to"
        ErrProv.SetError(DtPckTo, ErrorMsg(I))
      Case Nothing
        Exit Sub
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

    If MyUtils.CnvSng(TxtGLYear.Text) = 0 And TxtGLYear.Enabled Then
      ErrorField(I) = "glyear"
      ErrorMsg(I) = "Invalid Year"
      I = I + 1
    End If

    If TxtType.Text = "" Then
      ErrorField(I) = "type"
      ErrorMsg(I) = "Type is required"
      I = I + 1
    End If

    If MyUtils.SetDBDate(DtPckFrom.Value) > MyUtils.SetDBDate(DtPckTo.Value) Then
      ErrorField(I) = "to"
      ErrorMsg(I) = "Invalid date Range"
      I = I + 1
    End If

  End Sub
Private Sub RbAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbAll.Click
  TxtGLYear.Enabled = False
End Sub
Private Sub RbPaid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPaid.Click
  TxtGLYear.Enabled = True
End Sub
Private Sub RbBalances_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbBalances.Click
  TxtGLYear.Enabled = True
End Sub
Private Sub RbComplete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbComplete.Click
  TxtGLYear.Enabled = True
End Sub
Private Sub RbAddendum_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbAddendum.Click
  TxtGLYear.Enabled = True
End Sub

Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub RbSortList_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbSortList.CheckedChanged

End Sub
End Class






