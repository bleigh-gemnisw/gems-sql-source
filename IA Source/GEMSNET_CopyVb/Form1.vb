Imports System.io
Public Class Form1
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
Friend WithEvents LblFileDate As System.Windows.Forms.Label
Friend WithEvents RbUtil As System.Windows.Forms.RadioButton
Friend WithEvents RbSecurity As System.Windows.Forms.RadioButton
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents ChkNewer As System.Windows.Forms.CheckBox
Friend WithEvents BtnReplace As System.Windows.Forms.Button
Friend WithEvents ChkPreview As System.Windows.Forms.CheckBox
Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
Friend WithEvents RbCommon As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.BtnReplace = New System.Windows.Forms.Button()
    Me.LblFileDate = New System.Windows.Forms.Label()
    Me.RbUtil = New System.Windows.Forms.RadioButton()
    Me.RbSecurity = New System.Windows.Forms.RadioButton()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.ChkNewer = New System.Windows.Forms.CheckBox()
    Me.RbCommon = New System.Windows.Forms.RadioButton()
    Me.ChkPreview = New System.Windows.Forms.CheckBox()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'BtnReplace
    '
    Me.BtnReplace.Location = New System.Drawing.Point(392, 8)
    Me.BtnReplace.Name = "BtnReplace"
    Me.BtnReplace.Size = New System.Drawing.Size(56, 24)
    Me.BtnReplace.TabIndex = 180
    Me.BtnReplace.Text = "Replace"
    '
    'LblFileDate
    '
    Me.LblFileDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFileDate.Location = New System.Drawing.Point(464, 16)
    Me.LblFileDate.Name = "LblFileDate"
    Me.LblFileDate.Size = New System.Drawing.Size(168, 16)
    Me.LblFileDate.TabIndex = 181
    Me.LblFileDate.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'RbUtil
    '
    Me.RbUtil.Checked = True
    Me.RbUtil.Location = New System.Drawing.Point(16, 8)
    Me.RbUtil.Name = "RbUtil"
    Me.RbUtil.Size = New System.Drawing.Size(64, 16)
    Me.RbUtil.TabIndex = 184
    Me.RbUtil.TabStop = True
    Me.RbUtil.Text = "Util.vb"
    '
    'RbSecurity
    '
    Me.RbSecurity.Location = New System.Drawing.Point(88, 8)
    Me.RbSecurity.Name = "RbSecurity"
    Me.RbSecurity.Size = New System.Drawing.Size(80, 16)
    Me.RbSecurity.TabIndex = 185
    Me.RbSecurity.Text = "Security.vb"
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(520, 0)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(48, 16)
    Me.Label1.TabIndex = 186
    Me.Label1.Text = "System:"
    '
    'ChkNewer
    '
    Me.ChkNewer.Location = New System.Drawing.Point(16, 32)
    Me.ChkNewer.Name = "ChkNewer"
    Me.ChkNewer.Size = New System.Drawing.Size(112, 16)
    Me.ChkNewer.TabIndex = 189
    Me.ChkNewer.Text = "Replace Newer?"
    '
    'RbCommon
    '
    Me.RbCommon.Location = New System.Drawing.Point(176, 8)
    Me.RbCommon.Name = "RbCommon"
    Me.RbCommon.Size = New System.Drawing.Size(98, 16)
    Me.RbCommon.TabIndex = 190
    Me.RbCommon.Text = "Common.vb"
    '
    'ChkPreview
    '
    Me.ChkPreview.Location = New System.Drawing.Point(134, 34)
    Me.ChkPreview.Name = "ChkPreview"
    Me.ChkPreview.Size = New System.Drawing.Size(77, 16)
    Me.ChkPreview.TabIndex = 191
    Me.ChkPreview.Text = "Preview?"
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView.DefaultCellStyle = DataGridViewCellStyle1
    Me.DataGrdView.Location = New System.Drawing.Point(12, 56)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(616, 370)
    Me.DataGrdView.TabIndex = 192
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(640, 438)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.ChkPreview)
    Me.Controls.Add(Me.RbCommon)
    Me.Controls.Add(Me.ChkNewer)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.RbSecurity)
    Me.Controls.Add(Me.RbUtil)
    Me.Controls.Add(Me.LblFileDate)
    Me.Controls.Add(Me.BtnReplace)
    Me.Name = "Form1"
    Me.Text = "Gems NET CopyVB"
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MySource = "c:\Gems Source SQL\"
    BuildDS()

  End Sub
Private Sub FindSource()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    MyFileName2 = ""
    If RbUtil.Checked Then
      MyFileName = "Util.vb"
    End If
    If RbSecurity.Checked Then
      MyFileName = "security.vb"
    End If
    If RbCommon.Checked Then
      MyFileName = "Common.vb"
    End If
    WrkNewer = False
    If ChkNewer.Checked Then
      WrkNewer = True
    End If

    MyTimeStamp = System.IO.File.GetLastWriteTime(MySource & "ia source\system\" & MyFileName)
    ShowFolders("ap source")
    ShowFolders("ar source")
    ShowFolders("bd source")
    ShowFolders("fa source")
    ShowFolders("gl source")
    ShowFolders("ia source")
    ShowFolders("mr source")
    ShowFolders("pk source")
    ShowFolders("po source")
    ShowFolders("ps source")
    ShowFolders("ta source")
    ShowFolders("to source")
    ShowFolders("ts source")
    ShowFolders("tx source")
    ShowFolders("ub source")

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .DataSource = ds.Tables(0)
      .Refresh()
      .Columns(0).Width = 350
      .Columns(1).Width = 150
      .Columns(2).Width = 70
    End With
    Windows.Forms.Cursor.Current = Cursors.Default
    LblFileDate.Text = MyTimeStamp

End Sub
  Private Sub CopySource()
  Dim WrkSource As String
  Dim WrkSource2 As String
  Dim WrkSourceResx As String
  Dim I As Integer

  WrkSource = MySource & "ia source\system\" & MyFileName
  WrkSource2 = MySource & "ia source\system\" & MyFileName2
  For I = 0 To ds.Tables(0).Rows.Count - 1
    With ds.Tables(0).Rows(I)
      If .Item("status") = "Older" Then
         File.Delete(.Item("sourcename"))
         File.Copy(WrkSource, .Item("sourcename"))
         If MyFileName2 <> "" Then
           WrkSourceResx = Replace(.Item("sourcename"), ".vb", ".resx")
           File.Delete(WrkSourceResx)
           File.Copy(WrkSource2, WrkSourceResx)
         End If
      End If
      If .Item("status") = "Newer" And WrkNewer Then
         File.Delete(.Item("sourcename"))
         File.Copy(WrkSource, .Item("sourcename"))
         If MyFileName2 <> "" Then
           WrkSourceResx = Replace(.Item("sourcename"), ".vb", ".resx")
           File.Delete(WrkSourceResx)
           File.Copy(WrkSource2, WrkSourceResx)
         End If
      End If
    End With
  Next
  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("SourceName", Type.GetType("System.String"))
      .Columns.Add("TimeStamp", Type.GetType("System.String"))
      .Columns.Add("Status", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
Private Sub BtnReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReplace.Click
  ds.Clear()
  FindSource()
  If ChkPreview.Checked = False Then
    CopySource()
  End If
End Sub
End Class
