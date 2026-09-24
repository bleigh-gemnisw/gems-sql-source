Public Class FrmUB350B
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
Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkName As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAddr As System.Windows.Forms.CheckBox
    Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RbSortList As System.Windows.Forms.RadioButton
  Friend WithEvents TxtYear As TextBox
  Friend WithEvents Label2 As Label
  Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.ChkAddr = New System.Windows.Forms.CheckBox()
    Me.ChkName = New System.Windows.Forms.CheckBox()
    Me.ChkPost = New System.Windows.Forms.CheckBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbSortList = New System.Windows.Forms.RadioButton()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(81, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(488, 48)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "This option will update the Billing File with information from the Customer Maste" &
    "r. Only Usage and Metered types will be processed."
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.ChkAddr)
    Me.GroupBox1.Controls.Add(Me.ChkName)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
    Me.GroupBox1.Location = New System.Drawing.Point(32, 112)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(408, 74)
    Me.GroupBox1.TabIndex = 2
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Information to Update"
    '
    'ChkAddr
    '
    Me.ChkAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkAddr.ForeColor = System.Drawing.SystemColors.WindowText
    Me.ChkAddr.Location = New System.Drawing.Point(240, 24)
    Me.ChkAddr.Name = "ChkAddr"
    Me.ChkAddr.Size = New System.Drawing.Size(72, 24)
    Me.ChkAddr.TabIndex = 3
    Me.ChkAddr.Text = "Address"
    '
    'ChkName
    '
    Me.ChkName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkName.ForeColor = System.Drawing.SystemColors.WindowText
    Me.ChkName.Location = New System.Drawing.Point(48, 24)
    Me.ChkName.Name = "ChkName"
    Me.ChkName.Size = New System.Drawing.Size(136, 24)
    Me.ChkName.TabIndex = 2
    Me.ChkName.Text = "Names "
    '
    'ChkPost
    '
    Me.ChkPost.Location = New System.Drawing.Point(32, 192)
    Me.ChkPost.Name = "ChkPost"
    Me.ChkPost.Size = New System.Drawing.Size(148, 24)
    Me.ChkPost.TabIndex = 7
    Me.ChkPost.TabStop = False
    Me.ChkPost.Text = "Post to File?"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbSortList)
    Me.GroupBox2.Controls.Add(Me.RbSortName)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox2.Location = New System.Drawing.Point(488, 112)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(135, 74)
    Me.GroupBox2.TabIndex = 5
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Report Order"
    '
    'RbSortList
    '
    Me.RbSortList.Checked = True
    Me.RbSortList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortList.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbSortList.Location = New System.Drawing.Point(20, 21)
    Me.RbSortList.Name = "RbSortList"
    Me.RbSortList.Size = New System.Drawing.Size(70, 20)
    Me.RbSortList.TabIndex = 5
    Me.RbSortList.TabStop = True
    Me.RbSortList.Text = "List #"
    '
    'RbSortName
    '
    Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortName.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbSortName.Location = New System.Drawing.Point(20, 47)
    Me.RbSortName.Name = "RbSortName"
    Me.RbSortName.Size = New System.Drawing.Size(106, 20)
    Me.RbSortName.TabIndex = 6
    Me.RbSortName.Text = "Name"
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(105, 76)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtYear.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(29, 80)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(59, 13)
    Me.Label2.TabIndex = 7
    Me.Label2.Text = "Billing Year"
    '
    'FrmUB350B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(635, 242)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.ChkPost)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.MaximizeBox = False
    Me.Name = "FrmUB350B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = " "
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmUB350B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub


    Private Sub FrmUB350B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        MyFrmUB350.SbpScreen.Text = "UB350B"
        MyFrmUB350.TBarProcess.Enabled = True
        MyUtils.CenterForm(Me.ParentForm, Me)
    End Sub

    Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
        Dim I As Integer

        For I = 0 To ErrorField.GetUpperBound(0)
            If IsNothing(ErrorField(I)) Then
                Exit For
            End If
        Next
    If Trim(TxtYear.Text) <= "1950" Then
      ErrorMsg(I) = "Invalid Year Entered"
      ErrorField(I) = "txtyear"
      I = I + 1
    End If
    If ChkName.Checked = False And ChkAddr.Checked = False Then
      ErrorField(I) = "cbname"
      ErrorMsg(I) = "No fields selected for update"
      I = I + 1
    End If


  End Sub
    Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
        Dim I As Integer
        ErrProv.SetError(ChkName, "")


        For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "cbname"
          ErrProv.SetError(ChkName, ErrorMsg(I))
        Case "txtyear"
          ErrProv.SetError(TxtYear, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
    End Sub
  Public Sub RunUpdate()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    Dim result As DialogResult
    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If
    If ChkPost.Checked = True Then
      result = MessageBox.Show("Are you sure you want to proceed with the post option?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

      If result = DialogResult.Yes Then
        ' User clicked Yes
        MessageBox.Show("You selected Yes. Proceeding with the post option.", "Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Refresh()
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        UpData()
        Windows.Forms.Cursor.Current = Cursors.Default
      Else
        ' User clicked No
        MessageBox.Show("You selected No. Post option canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Windows.Forms.Cursor.Current = Cursors.Default
      End If
    Else
      Me.Refresh()
      Windows.Forms.Cursor.Current = Cursors.WaitCursor
      UpData()
      Windows.Forms.Cursor.Current = Cursors.Default
    End If

  End Sub

  Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then

      Exit Sub
    End If

    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
End Class






