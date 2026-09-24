Public Class FrmTXE42B
Inherits System.Windows.Forms.Form
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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents TxtToGLYear As System.Windows.Forms.TextBox
Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbSortList As System.Windows.Forms.RadioButton
Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
Friend WithEvents TxtAltFormID As System.Windows.Forms.TextBox
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbBlanket As System.Windows.Forms.RadioButton
Friend WithEvents RbIndivual As System.Windows.Forms.RadioButton
Friend WithEvents LnkAltID As System.Windows.Forms.LinkLabel
Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtTypes = New System.Windows.Forms.TextBox()
    Me.LnkTypes = New System.Windows.Forms.LinkLabel()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtToGLYear = New System.Windows.Forms.TextBox()
    Me.TxtFromGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbSortList = New System.Windows.Forms.RadioButton()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
    Me.TxtAltFormID = New System.Windows.Forms.TextBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbBlanket = New System.Windows.Forms.RadioButton()
    Me.RbIndivual = New System.Windows.Forms.RadioButton()
    Me.LnkAltID = New System.Windows.Forms.LinkLabel()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(22, 24)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(60, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "From Date"
    '
    'DtPckFrom
    '
    Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFrom.Location = New System.Drawing.Point(82, 20)
    Me.DtPckFrom.Name = "DtPckFrom"
    Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
    Me.DtPckFrom.TabIndex = 0
    '
    'DtPckTo
    '
    Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTo.Location = New System.Drawing.Point(242, 20)
    Me.DtPckTo.Name = "DtPckTo"
    Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
    Me.DtPckTo.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(190, 24)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(52, 16)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "To Date"
    '
    'TxtTypes
    '
    Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTypes.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTypes.Location = New System.Drawing.Point(106, 91)
    Me.TxtTypes.MaxLength = 20
    Me.TxtTypes.Name = "TxtTypes"
    Me.TxtTypes.Size = New System.Drawing.Size(148, 20)
    Me.TxtTypes.TabIndex = 4
    '
    'LnkTypes
    '
    Me.LnkTypes.Location = New System.Drawing.Point(20, 94)
    Me.LnkTypes.Name = "LnkTypes"
    Me.LnkTypes.Size = New System.Drawing.Size(80, 16)
    Me.LnkTypes.TabIndex = 35
    Me.LnkTypes.TabStop = True
    Me.LnkTypes.Text = "Types to print"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(220, 59)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(56, 16)
    Me.Label6.TabIndex = 40
    Me.Label6.Text = "(Optional)"
    '
    'TxtToGLYear
    '
    Me.TxtToGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtToGLYear.Location = New System.Drawing.Point(178, 55)
    Me.TxtToGLYear.MaxLength = 4
    Me.TxtToGLYear.Name = "TxtToGLYear"
    Me.TxtToGLYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtToGLYear.TabIndex = 3
    '
    'TxtFromGLYear
    '
    Me.TxtFromGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFromGLYear.Location = New System.Drawing.Point(106, 55)
    Me.TxtFromGLYear.MaxLength = 4
    Me.TxtFromGLYear.Name = "TxtFromGLYear"
    Me.TxtFromGLYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtFromGLYear.TabIndex = 2
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(154, 59)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(16, 16)
    Me.Label4.TabIndex = 39
    Me.Label4.Text = "to"
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(22, 59)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(84, 16)
    Me.Label7.TabIndex = 38
    Me.Label7.Text = "Grand List Year"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbSortList)
    Me.GroupBox2.Controls.Add(Me.RbSortName)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(362, 12)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(132, 63)
    Me.GroupBox2.TabIndex = 41
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Sort Options"
    '
    'RbSortList
    '
    Me.RbSortList.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortList.Checked = True
    Me.RbSortList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortList.Location = New System.Drawing.Point(12, 16)
    Me.RbSortList.Name = "RbSortList"
    Me.RbSortList.Size = New System.Drawing.Size(111, 20)
    Me.RbSortList.TabIndex = 0
    Me.RbSortList.TabStop = True
    Me.RbSortList.Text = "Year/Type/List"
    '
    'RbSortName
    '
    Me.RbSortName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortName.Location = New System.Drawing.Point(12, 36)
    Me.RbSortName.Name = "RbSortName"
    Me.RbSortName.Size = New System.Drawing.Size(111, 20)
    Me.RbSortName.TabIndex = 1
    Me.RbSortName.Text = "Name"
    '
    'TxtAltFormID
    '
    Me.TxtAltFormID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAltFormID.Location = New System.Drawing.Point(125, 125)
    Me.TxtAltFormID.MaxLength = 1
    Me.TxtAltFormID.Name = "TxtAltFormID"
    Me.TxtAltFormID.Size = New System.Drawing.Size(20, 20)
    Me.TxtAltFormID.TabIndex = 72
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbBlanket)
    Me.GroupBox1.Controls.Add(Me.RbIndivual)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(362, 85)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(132, 63)
    Me.GroupBox1.TabIndex = 74
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Form "
    '
    'RbBlanket
    '
    Me.RbBlanket.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbBlanket.Checked = True
    Me.RbBlanket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbBlanket.Location = New System.Drawing.Point(12, 16)
    Me.RbBlanket.Name = "RbBlanket"
    Me.RbBlanket.Size = New System.Drawing.Size(111, 20)
    Me.RbBlanket.TabIndex = 0
    Me.RbBlanket.TabStop = True
    Me.RbBlanket.Text = "Blanket"
    '
    'RbIndivual
    '
    Me.RbIndivual.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbIndivual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbIndivual.Location = New System.Drawing.Point(12, 36)
    Me.RbIndivual.Name = "RbIndivual"
    Me.RbIndivual.Size = New System.Drawing.Size(111, 20)
    Me.RbIndivual.TabIndex = 1
    Me.RbIndivual.Text = "Individual"
    '
    'LnkAltID
    '
    Me.LnkAltID.AutoSize = True
    Me.LnkAltID.Location = New System.Drawing.Point(22, 128)
    Me.LnkAltID.Name = "LnkAltID"
    Me.LnkAltID.Size = New System.Drawing.Size(97, 13)
    Me.LnkAltID.TabIndex = 75
    Me.LnkAltID.TabStop = True
    Me.LnkAltID.Text = "Alternative Form ID"
    '
    'FrmTXE42B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(516, 160)
    Me.ControlBox = False
    Me.Controls.Add(Me.LnkAltID)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.TxtAltFormID)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.TxtToGLYear)
    Me.Controls.Add(Me.TxtFromGLYear)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TxtTypes)
    Me.Controls.Add(Me.LnkTypes)
    Me.Controls.Add(Me.DtPckTo)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.DtPckFrom)
    Me.Controls.Add(Me.Label1)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXE42B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTXE42B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTXE42.SbpScreen.Text = "TXE42"
End Sub
Private Sub FrmTXE42B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(DtPckFrom, "")
    ErrProv.SetError(DtPckTo, "")
    ErrProv.SetError(TxtFromGLYear, "")
    ErrProv.SetError(TxtToGLYear, "")
    ErrProv.SetError(TxtTypes, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "from"
        ErrProv.SetError(DtPckFrom, ErrorMsg(I))
      Case "to"
        ErrProv.SetError(DtPckTo, ErrorMsg(I))
      Case "fromglyear"
        ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
      Case "toglyear"
        ErrProv.SetError(TxtToGLYear, ErrorMsg(I))
      Case "type"
        ErrProv.SetError(TxtTypes, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtFromGLYear.Text) > MyUtils.CnvSng(TxtToGLYear.Text) Then
      ErrorField(I) = "fromglyear"
      ErrorMsg(I) = "Invalid Year Range"
      I = I + 1
      ErrorField(I) = "toglyear"
      ErrorMsg(I) = "Invalid Year Range"
      I = I + 1
    End If

    If DtPckFrom.Value > DtPckTo.Value Then
      ErrorField(I) = "from"
      ErrorMsg(I) = "Invalid Date Range"
      I = I + 1
      ErrorField(I) = "to"
      ErrorMsg(I) = "Invalid Date Range"
      I = I + 1
    End If

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
Private Sub FrmTXE42B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  MyTypes = ""
End Sub
Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
  MyTypes = TxtTypes.Text
  MyFrmSelTypes = New FrmSelTypes
  MyFrmSelTypes.MdiParent = Me.ParentForm
  MyFrmSelTypes.Show()
  Me.Hide()

End Sub
Private Sub TxtFromGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtToGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub LnkAltID_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkAltID.LinkClicked
  MyFrmListAltID = New FrmListAltID
  MyFrmListAltID.MdiParent = Me.ParentForm
  MyFrmListAltID.Show()
End Sub
End Class






