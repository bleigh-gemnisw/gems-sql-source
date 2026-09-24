Public Class FrmFixB
  Inherits System.Windows.Forms.Form

  Friend ds As DataSet = New DataSet

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
'    Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtDBName As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtType As System.Windows.Forms.TextBox
  Friend WithEvents TxtToList As TextBox
  Friend WithEvents Label4 As Label
  Friend WithEvents Label1 As Label
  Friend WithEvents TxtFromList As TextBox
    Friend WithEvents LblMsg As Label
    Friend WithEvents ChkUpdate As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtDBName = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.ChkUpdate = New System.Windows.Forms.CheckBox()
    Me.TxtFromList = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtToList = New System.Windows.Forms.TextBox()
        Me.LblMsg = New System.Windows.Forms.Label()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'TxtDBName
        '
        Me.TxtDBName.Location = New System.Drawing.Point(100, 23)
        Me.TxtDBName.Name = "TxtDBName"
        Me.TxtDBName.Size = New System.Drawing.Size(126, 20)
        Me.TxtDBName.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Database name"
        '
        'TxtType
        '
        Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtType.Location = New System.Drawing.Point(100, 49)
        Me.TxtType.MaxLength = 5
        Me.TxtType.Name = "TxtType"
        Me.TxtType.Size = New System.Drawing.Size(26, 20)
        Me.TxtType.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Type"
        '
        'ChkUpdate
        '
        Me.ChkUpdate.AutoSize = True
        Me.ChkUpdate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkUpdate.Location = New System.Drawing.Point(27, 114)
        Me.ChkUpdate.Name = "ChkUpdate"
        Me.ChkUpdate.Size = New System.Drawing.Size(67, 17)
        Me.ChkUpdate.TabIndex = 70
        Me.ChkUpdate.Text = "Update?"
        Me.ChkUpdate.UseVisualStyleBackColor = True
        '
        'TxtFromList
        '
        Me.TxtFromList.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFromList.Location = New System.Drawing.Point(100, 75)
        Me.TxtFromList.MaxLength = 7
        Me.TxtFromList.Name = "TxtFromList"
        Me.TxtFromList.Size = New System.Drawing.Size(69, 20)
        Me.TxtFromList.TabIndex = 71
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "List#"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(175, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 13)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "To"
        '
        'TxtToList
        '
        Me.TxtToList.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtToList.Location = New System.Drawing.Point(201, 75)
        Me.TxtToList.MaxLength = 7
        Me.TxtToList.Name = "TxtToList"
        Me.TxtToList.Size = New System.Drawing.Size(69, 20)
        Me.TxtToList.TabIndex = 74
        '
        'LblMsg
        '
        Me.LblMsg.AutoSize = True
        Me.LblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMsg.Location = New System.Drawing.Point(24, 152)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(71, 13)
        Me.LblMsg.TabIndex = 75
        Me.LblMsg.Text = "<Message>"
        '
        'FrmFixB
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(432, 183)
        Me.ControlBox = False
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.TxtToList)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtFromList)
        Me.Controls.Add(Me.ChkUpdate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtDBName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "FrmFixB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FrmFixB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    LblMsg.Text = ""
  End Sub


  Private Sub FrmFixB_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        MyFrmFix.SbpScreen.Text = "FixB"
        MyFrmFix.TBarProcess.Enabled = True
        CenterForm(Me.ParentForm, Me)
    End Sub

    Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
        Dim I As Integer

        For I = 0 To ErrorField.GetUpperBound(0)
            If IsNothing(ErrorField(I)) Then
                Exit For
            End If
        Next

    End Sub
    Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
        Dim I As Integer


        For I = 0 To ErrorField.GetUpperBound(0)
            Select Case ErrorField(I)
                Case Nothing
                    Exit Sub
            End Select
        Next I
    End Sub
    Public Sub RunImport()
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

        Impdata()
        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub


    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
