Public Class FrmTXE46B
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
	Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
    Friend WithEvents LinkUBType As LinkLabel
    Friend WithEvents TxtType As TextBox
    Friend WithEvents Chkupdatebacktax As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TxtGLYear = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Chkupdatebacktax = New System.Windows.Forms.CheckBox()
        Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LinkUBType = New System.Windows.Forms.LinkLabel()
        Me.TxtType = New System.Windows.Forms.TextBox()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtGLYear
        '
        Me.TxtGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGLYear.Location = New System.Drawing.Point(175, 32)
        Me.TxtGLYear.MaxLength = 4
        Me.TxtGLYear.Name = "TxtGLYear"
        Me.TxtGLYear.Size = New System.Drawing.Size(36, 20)
        Me.TxtGLYear.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(66, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Grand List Year"
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'Chkupdatebacktax
        '
        Me.Chkupdatebacktax.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Chkupdatebacktax.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chkupdatebacktax.Location = New System.Drawing.Point(64, 91)
        Me.Chkupdatebacktax.Name = "Chkupdatebacktax"
        Me.Chkupdatebacktax.Size = New System.Drawing.Size(147, 30)
        Me.Chkupdatebacktax.TabIndex = 2
        Me.Chkupdatebacktax.Text = "Update records?"
        '
        'LinkUBType
        '
        Me.LinkUBType.Location = New System.Drawing.Point(75, 68)
        Me.LinkUBType.Name = "LinkUBType"
        Me.LinkUBType.Size = New System.Drawing.Size(68, 16)
        Me.LinkUBType.TabIndex = 75
        Me.LinkUBType.TabStop = True
        Me.LinkUBType.Text = "Bill Type"
        '
        'TxtType
        '
        Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtType.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtType.Location = New System.Drawing.Point(183, 64)
        Me.TxtType.MaxLength = 2
        Me.TxtType.Name = "TxtType"
        Me.TxtType.Size = New System.Drawing.Size(24, 22)
        Me.TxtType.TabIndex = 74
        '
        'FrmTXE46B
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(282, 151)
        Me.ControlBox = False
        Me.Controls.Add(Me.LinkUBType)
        Me.Controls.Add(Me.TxtType)
        Me.Controls.Add(Me.Chkupdatebacktax)
        Me.Controls.Add(Me.TxtGLYear)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTXE46B"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FrmTXE46B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        MyFrmTXE46.SbpScreen.Text = "TXE46"
    End Sub


    Private Sub FrmTXE46B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        Me.Refresh()
    End Sub
    Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
        Dim I As Integer
        ErrProv.SetError(TxtGLYear, "")

        For I = 0 To ErrorField.GetUpperBound(0)
            Select Case ErrorField(I)
                Case "glyear"
                    ErrProv.SetError(TxtGLYear, ErrorMsg(I))
                Case Nothing
                    Exit Sub
            End Select
        Next I
    End Sub
    Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    Dim WrkFamily As String

    For I = 0 To ErrorField.GetUpperBound(0)
            If IsNothing(ErrorField(I)) Then
                Exit For
            End If
        Next

        If MyUtils.CnvSng(TxtGLYear.Text) = 0 Then
            ErrorField(I) = "glyear"
            ErrorMsg(I) = "Year is required"
            I = I + 1
        End If
    WrkFamily = GetTXTypeFamily(TxtType.Text)
    If WrkFamily <> "R" And WrkFamily <> "A" And WrkFamily <> "U" Then
      ErrorField(I) = "txtype"
      ErrorMsg(I) = "Tax Type is not allowed"
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
    Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
        e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
    End Sub
  Private Sub FrmTXE46B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub

  Private Sub LinkUBType_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkUBType.LinkClicked
    MyFrmListTypes = New FrmListTypes
    MyFrmListTypes.MdiParent = Me.ParentForm
    MyFrmListTypes.WrkType = TxtType.Text
    MyFrmListTypes.Show()
    Me.Hide()
  End Sub
End Class






