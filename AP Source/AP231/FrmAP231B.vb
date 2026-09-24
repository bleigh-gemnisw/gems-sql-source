Imports System.Text
Imports System.IO
Public Class FrmAP231B
  Inherits System.Windows.Forms.Form
  Dim MyVENDORQ As VENDORQ.MyData
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents LblFilePath As System.Windows.Forms.Label
  Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
  Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog

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
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.label3 = New System.Windows.Forms.Label
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.LblFilePath = New System.Windows.Forms.Label
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
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
    Me.label3.Size = New System.Drawing.Size(89, 23)
    Me.label3.TabIndex = 6
    Me.label3.Text = "New file name"
    Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LblFilePath)
    Me.GroupBox1.Controls.Add(Me.LnkFilePath)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(30, 44)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(408, 56)
    Me.GroupBox1.TabIndex = 65
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "File Details"
    '
    'LblFilePath
    '
    Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePath.Name = "LblFilePath"
    Me.LblFilePath.Size = New System.Drawing.Size(324, 36)
    Me.LblFilePath.TabIndex = 67
    '
    'LnkFilePath
    '
    Me.LnkFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePath.Location = New System.Drawing.Point(12, 24)
    Me.LnkFilePath.Name = "LnkFilePath"
    Me.LnkFilePath.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePath.TabIndex = 65
    Me.LnkFilePath.TabStop = True
    Me.LnkFilePath.Text = "File Path"
    '
    'FrmAP231B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(464, 165)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmAP231B"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub AP231B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyVENDORQ = New VENDORQ.MyData()
    MyVENDORQ.MyDBConn = myDBConnect
  End Sub
  Private Sub AP231B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmAP231.SbpScreen.Text = "AP231B"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub runData()
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
    CreateFile()
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "path"
          ErrProv.SetError(LblFilePath, ErrorMsg(I))
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

    If LblFilePath.Text = "" Then
      ErrorField(I) = "path"
      ErrorMsg(I) = "File Path cannot be blank. Click on link to set."
      I = I + 1
    End If

  End Sub
  Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
    With SaveFileDialog1
      .Filter = "Text files|*.txt"
      .ShowDialog()
      LblFilePath.Text = .FileName
    End With
  End Sub
  Private Sub CreateFile()
    Dim sw As StreamWriter = New StreamWriter(MyFrmAP231B.LblFilePath.Text)
    Dim sb As StringBuilder
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkPct As Integer
    Dim SavePct As Integer
    Dim Counter As Integer

    WrkQry = ""
    WrkSort = "VENNM"
    Counter = 0
    MyVENDORQ.OpenQry(WrkSort, WrkQry)

    MyFrmProgress = New FrmProgress
    MyFrmProgress.Show()
    MyFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    MyVENDORQ.ReadQry()
    If Not MyVENDORQ.IsEOF Then
      Counter = Counter + 1
      With MyVENDORQ
        'Exclude one-time vendors
        If Mid(._VNDNR, 1, 1) <> "*" Then
          sb = New StringBuilder
          sb.Append(Trim(._VNDNR))
          sb.Append(" | ")
          sb.Append(Trim(._VENNM))
          sw.WriteLine(sb.ToString)
          sb = Nothing
        End If
      End With

NextRec:
      With MyFrmProgress
        WrkPct = (Counter / 10) Mod 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .LblMsg.Text = "Records processed: " & Counter
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
      GoTo ReadNext
    End If

    sw.Close()
    MyFrmProgress.Close()
    MyVENDORQ.CloseFile()
    MsgBox("File has been created", MsgBoxStyle.Information, "Program finished")

  End Sub
End Class
