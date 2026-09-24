Public Class FrmTA600B
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
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents label1 As System.Windows.Forms.Label
Friend WithEvents CboDatabase As System.Windows.Forms.ComboBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents Chkupdatebacktax As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Chkupdatebacktax = New System.Windows.Forms.CheckBox
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.label1 = New System.Windows.Forms.Label
Me.CboDatabase = New System.Windows.Forms.ComboBox
Me.Label2 = New System.Windows.Forms.Label
Me.TxtGLYear = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Chkupdatebacktax
'
Me.Chkupdatebacktax.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.Chkupdatebacktax.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Chkupdatebacktax.Location = New System.Drawing.Point(25, 92)
Me.Chkupdatebacktax.Name = "Chkupdatebacktax"
Me.Chkupdatebacktax.Size = New System.Drawing.Size(147, 30)
Me.Chkupdatebacktax.TabIndex = 2
Me.Chkupdatebacktax.Text = "Update records?"
'
'label1
'
Me.label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.label1.Location = New System.Drawing.Point(12, 30)
Me.label1.Name = "label1"
Me.label1.Size = New System.Drawing.Size(172, 24)
Me.label1.TabIndex = 14
Me.label1.Text = "Select Fire Dist Database"
'
'CboDatabase
'
Me.CboDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.CboDatabase.Location = New System.Drawing.Point(190, 29)
Me.CboDatabase.Name = "CboDatabase"
Me.CboDatabase.Size = New System.Drawing.Size(180, 21)
Me.CboDatabase.TabIndex = 0
'
'Label2
'
Me.Label2.AutoSize = True
Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label2.Location = New System.Drawing.Point(90, 153)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(280, 13)
Me.Label2.TabIndex = 15
Me.Label2.Text = "NOTICE: Run this program in Town Environment"
'
'TxtGLYear
'
Me.TxtGLYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtGLYear.Location = New System.Drawing.Point(152, 66)
Me.TxtGLYear.MaxLength = 4
Me.TxtGLYear.Name = "TxtGLYear"
Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
Me.TxtGLYear.TabIndex = 1
'
'Label3
'
Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label3.Location = New System.Drawing.Point(22, 67)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(109, 16)
Me.Label3.TabIndex = 70
Me.Label3.Text = "Grand List Year"
'
'FrmTA600B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(443, 175)
Me.ControlBox = False
Me.Controls.Add(Me.TxtGLYear)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.label1)
Me.Controls.Add(Me.CboDatabase)
Me.Controls.Add(Me.Chkupdatebacktax)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA600B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region
    Dim myDbName As DBNames.MyData
    Dim WrkDatabaseName As String
    Dim WrkAttempts As Integer
    Dim DBLocNames As String()
    Dim DBPubNames As String()
    Dim WrkPubRecs As Integer

Private Sub FrmTA600B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA600.SbpScreen.Text = "TA600"
End Sub
Private Sub FrmTA600B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
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

  End Sub

Public Sub RunReport()
    Dim Good As Boolean
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    Good = ConnectDB()
    If Not Good Then Exit Sub

    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If

    Me.Refresh()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    ProcFile()
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub FrmTA600B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Dim DBLocDesc As String()
  Dim DBPubDesc As String()
  Dim I As Integer

  myDbName = New DBNames.MyData
  'Get database names, if any
  DBPubDesc = myDbName.GetDesc(True)
  DBPubNames = myDbName.GetNames(True)
  DBLocDesc = myDbName.GetDesc(False)
  DBLocNames = myDbName.GetNames(False)

  If DBPubDesc.Length > 0 Then
    For I = 0 To DBPubDesc.GetUpperBound(0)
      CboDatabase.Items.Add(DBPubDesc(I))
    Next
  End If
  WrkPubRecs = I
  If DBLocDesc.Length > 0 Then
    For I = 0 To DBLocDesc.GetUpperBound(0)
      CboDatabase.Items.Add(DBLocDesc(I))
    Next
  End If

  WrkAttempts = 0
End Sub
Private Function ConnectDB() As Boolean
  Dim Good As Boolean
  Dim WrkDBName As String

  If CboDatabase.SelectedIndex < 0 Then
    MsgBox("Please Select Database to Log into", MsgBoxStyle.Exclamation, "Login ERROR")
    Return False
  End If

  Windows.Forms.Cursor.Current = Cursors.WaitCursor

  myDBConnect2 = New DBConnect.DBConnection
  If CboDatabase.SelectedIndex() <= (WrkPubRecs - 1) Then
    WrkDBName = DBPubNames(CboDatabase.SelectedIndex())
  Else
    WrkDBName = DBLocNames(CboDatabase.SelectedIndex() - WrkPubRecs)
  End If
  myDBConnect2.pgmDB.DBName = WrkDBName
  Good = myDBConnect2.Connect()
  If Not Good Then
    MsgBox("Error connecting to " & WrkDBName & ": " & myDBConnect2.ErrMsg, MsgBoxStyle.Critical, "Program aborting")
    Return False
  End If

  Return True
End Function
Private Sub TxtGLYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






