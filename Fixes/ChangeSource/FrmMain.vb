Public Class FrmMain
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
  Friend WithEvents BtnProcess As System.Windows.Forms.Button
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents ChkIA As System.Windows.Forms.CheckBox
  Friend WithEvents ChkGL As System.Windows.Forms.CheckBox
  Friend WithEvents ChkTO As System.Windows.Forms.CheckBox
  Friend WithEvents ChkUB As System.Windows.Forms.CheckBox
  Friend WithEvents ChkTX As System.Windows.Forms.CheckBox
  Friend WithEvents ChkTA As System.Windows.Forms.CheckBox
  Friend WithEvents ChkFA As System.Windows.Forms.CheckBox
  Friend WithEvents ChkAP As System.Windows.Forms.CheckBox
  Friend WithEvents ChkTS As System.Windows.Forms.CheckBox
  Friend WithEvents ChkPO As System.Windows.Forms.CheckBox
  Friend WithEvents ChkPR As System.Windows.Forms.CheckBox
  Friend WithEvents ChkPS As System.Windows.Forms.CheckBox
  Friend WithEvents LblNumPgms As System.Windows.Forms.Label
  Friend WithEvents ChkMR As System.Windows.Forms.CheckBox
  Friend WithEvents ChkBD As System.Windows.Forms.CheckBox
  Friend WithEvents LblNumMods As System.Windows.Forms.Label
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Friend WithEvents TxtSource As TextBox
  Friend WithEvents Label1 As Label
  Friend WithEvents ChkDB400 As System.Windows.Forms.CheckBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.BtnProcess = New System.Windows.Forms.Button()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.ChkBD = New System.Windows.Forms.CheckBox()
    Me.ChkMR = New System.Windows.Forms.CheckBox()
    Me.ChkPS = New System.Windows.Forms.CheckBox()
    Me.ChkTS = New System.Windows.Forms.CheckBox()
    Me.ChkPO = New System.Windows.Forms.CheckBox()
    Me.ChkPR = New System.Windows.Forms.CheckBox()
    Me.ChkAP = New System.Windows.Forms.CheckBox()
    Me.ChkFA = New System.Windows.Forms.CheckBox()
    Me.ChkGL = New System.Windows.Forms.CheckBox()
    Me.ChkTO = New System.Windows.Forms.CheckBox()
    Me.ChkUB = New System.Windows.Forms.CheckBox()
    Me.ChkTX = New System.Windows.Forms.CheckBox()
    Me.ChkTA = New System.Windows.Forms.CheckBox()
    Me.ChkIA = New System.Windows.Forms.CheckBox()
    Me.ChkDB400 = New System.Windows.Forms.CheckBox()
    Me.LblNumPgms = New System.Windows.Forms.Label()
    Me.LblNumMods = New System.Windows.Forms.Label()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.TxtSource = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GroupBox1.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'BtnProcess
    '
    Me.BtnProcess.Location = New System.Drawing.Point(12, 12)
    Me.BtnProcess.Name = "BtnProcess"
    Me.BtnProcess.Size = New System.Drawing.Size(57, 24)
    Me.BtnProcess.TabIndex = 180
    Me.BtnProcess.Text = "Process"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.ChkBD)
    Me.GroupBox1.Controls.Add(Me.ChkMR)
    Me.GroupBox1.Controls.Add(Me.ChkPS)
    Me.GroupBox1.Controls.Add(Me.ChkTS)
    Me.GroupBox1.Controls.Add(Me.ChkPO)
    Me.GroupBox1.Controls.Add(Me.ChkPR)
    Me.GroupBox1.Controls.Add(Me.ChkAP)
    Me.GroupBox1.Controls.Add(Me.ChkFA)
    Me.GroupBox1.Controls.Add(Me.ChkGL)
    Me.GroupBox1.Controls.Add(Me.ChkTO)
    Me.GroupBox1.Controls.Add(Me.ChkUB)
    Me.GroupBox1.Controls.Add(Me.ChkTX)
    Me.GroupBox1.Controls.Add(Me.ChkTA)
    Me.GroupBox1.Controls.Add(Me.ChkIA)
    Me.GroupBox1.Controls.Add(Me.ChkDB400)
    Me.GroupBox1.Location = New System.Drawing.Point(292, 9)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(484, 62)
    Me.GroupBox1.TabIndex = 183
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Include?"
    '
    'ChkBD
    '
    Me.ChkBD.Location = New System.Drawing.Point(337, 37)
    Me.ChkBD.Name = "ChkBD"
    Me.ChkBD.Size = New System.Drawing.Size(44, 19)
    Me.ChkBD.TabIndex = 197
    Me.ChkBD.Text = "BD"
    '
    'ChkMR
    '
    Me.ChkMR.Location = New System.Drawing.Point(281, 37)
    Me.ChkMR.Name = "ChkMR"
    Me.ChkMR.Size = New System.Drawing.Size(44, 19)
    Me.ChkMR.TabIndex = 196
    Me.ChkMR.Text = "MR"
    '
    'ChkPS
    '
    Me.ChkPS.Location = New System.Drawing.Point(176, 37)
    Me.ChkPS.Name = "ChkPS"
    Me.ChkPS.Size = New System.Drawing.Size(40, 19)
    Me.ChkPS.TabIndex = 195
    Me.ChkPS.Text = "PS"
    '
    'ChkTS
    '
    Me.ChkTS.Location = New System.Drawing.Point(226, 37)
    Me.ChkTS.Name = "ChkTS"
    Me.ChkTS.Size = New System.Drawing.Size(44, 19)
    Me.ChkTS.TabIndex = 194
    Me.ChkTS.Text = "TS"
    '
    'ChkPO
    '
    Me.ChkPO.Location = New System.Drawing.Point(126, 37)
    Me.ChkPO.Name = "ChkPO"
    Me.ChkPO.Size = New System.Drawing.Size(44, 19)
    Me.ChkPO.TabIndex = 193
    Me.ChkPO.Text = "PO"
    '
    'ChkPR
    '
    Me.ChkPR.Location = New System.Drawing.Point(67, 37)
    Me.ChkPR.Name = "ChkPR"
    Me.ChkPR.Size = New System.Drawing.Size(50, 19)
    Me.ChkPR.TabIndex = 192
    Me.ChkPR.Text = "PR"
    '
    'ChkAP
    '
    Me.ChkAP.Location = New System.Drawing.Point(8, 37)
    Me.ChkAP.Name = "ChkAP"
    Me.ChkAP.Size = New System.Drawing.Size(53, 19)
    Me.ChkAP.TabIndex = 191
    Me.ChkAP.Text = "AP"
    '
    'ChkFA
    '
    Me.ChkFA.Location = New System.Drawing.Point(176, 15)
    Me.ChkFA.Name = "ChkFA"
    Me.ChkFA.Size = New System.Drawing.Size(44, 18)
    Me.ChkFA.TabIndex = 190
    Me.ChkFA.Text = "FA"
    '
    'ChkGL
    '
    Me.ChkGL.Location = New System.Drawing.Point(126, 15)
    Me.ChkGL.Name = "ChkGL"
    Me.ChkGL.Size = New System.Drawing.Size(44, 18)
    Me.ChkGL.TabIndex = 189
    Me.ChkGL.Text = "GL"
    '
    'ChkTO
    '
    Me.ChkTO.Location = New System.Drawing.Point(281, 15)
    Me.ChkTO.Name = "ChkTO"
    Me.ChkTO.Size = New System.Drawing.Size(41, 17)
    Me.ChkTO.TabIndex = 188
    Me.ChkTO.Text = "TO"
    '
    'ChkUB
    '
    Me.ChkUB.Location = New System.Drawing.Point(393, 15)
    Me.ChkUB.Name = "ChkUB"
    Me.ChkUB.Size = New System.Drawing.Size(44, 18)
    Me.ChkUB.TabIndex = 187
    Me.ChkUB.Text = "UB"
    '
    'ChkTX
    '
    Me.ChkTX.Location = New System.Drawing.Point(337, 15)
    Me.ChkTX.Name = "ChkTX"
    Me.ChkTX.Size = New System.Drawing.Size(40, 16)
    Me.ChkTX.TabIndex = 186
    Me.ChkTX.Text = "TX"
    '
    'ChkTA
    '
    Me.ChkTA.Location = New System.Drawing.Point(226, 15)
    Me.ChkTA.Name = "ChkTA"
    Me.ChkTA.Size = New System.Drawing.Size(40, 16)
    Me.ChkTA.TabIndex = 185
    Me.ChkTA.Text = "TA"
    '
    'ChkIA
    '
    Me.ChkIA.Location = New System.Drawing.Point(67, 15)
    Me.ChkIA.Name = "ChkIA"
    Me.ChkIA.Size = New System.Drawing.Size(40, 16)
    Me.ChkIA.TabIndex = 184
    Me.ChkIA.Text = "IA"
    '
    'ChkDB400
    '
    Me.ChkDB400.Location = New System.Drawing.Point(8, 15)
    Me.ChkDB400.Name = "ChkDB400"
    Me.ChkDB400.Size = New System.Drawing.Size(44, 17)
    Me.ChkDB400.TabIndex = 183
    Me.ChkDB400.Text = "DB"
    '
    'LblNumPgms
    '
    Me.LblNumPgms.AutoSize = True
    Me.LblNumPgms.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNumPgms.Location = New System.Drawing.Point(12, 82)
    Me.LblNumPgms.Name = "LblNumPgms"
    Me.LblNumPgms.Size = New System.Drawing.Size(99, 13)
    Me.LblNumPgms.TabIndex = 186
    Me.LblNumPgms.Text = "<# of programs>"
    '
    'LblNumMods
    '
    Me.LblNumMods.AutoSize = True
    Me.LblNumMods.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNumMods.Location = New System.Drawing.Point(185, 82)
    Me.LblNumMods.Name = "LblNumMods"
    Me.LblNumMods.Size = New System.Drawing.Size(94, 13)
    Me.LblNumMods.TabIndex = 194
    Me.LblNumMods.Text = "<# of modules>"
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
    Me.DataGrdView.Location = New System.Drawing.Point(8, 98)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(764, 344)
    Me.DataGrdView.TabIndex = 195
    '
    'TxtSource
    '
    Me.TxtSource.Location = New System.Drawing.Point(97, 450)
    Me.TxtSource.Name = "TxtSource"
    Me.TxtSource.Size = New System.Drawing.Size(208, 20)
    Me.TxtSource.TabIndex = 196
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(5, 453)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(86, 13)
    Me.Label1.TabIndex = 197
    Me.Label1.Text = "Source Directory"
    '
    'FrmMain
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(784, 475)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtSource)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.LblNumMods)
    Me.Controls.Add(Me.LblNumPgms)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.BtnProcess)
    Me.Name = "FrmMain"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Change Source Utility "
    Me.GroupBox1.ResumeLayout(False)
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyUtils = New Utils.Util
    GetAppSettings()
    TxtSource.Text = MyAppSettings.FilePath
    BuildDS()
    LblNumPgms.Text = String.Empty
    LblNumMods.Text = String.Empty
    ChkDB400.Checked = True
  End Sub
  Private Sub ChgSource()
    If MyAppSettings.FilePath <> TxtSource.Text Then
      MyAppSettings.FilePath = TxtSource.Text
      SaveAppSettings()
    End If
    WrkNumPgms = 0
    WrkNumMods = 0
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    If ChkDB400.Checked Then
      Try
        ShowFolders("db400")
      Catch
      End Try
      Try
        ShowFolders("dbsql")
      Catch
      End Try
    End If
    If ChkIA.Checked Then
      ShowFolders("ia source")
    End If
    If ChkFA.Checked Then
      ShowFolders("fa source")
    End If
    If ChkGL.Checked Then
      ShowFolders("gl source")
    End If
    If ChkTA.Checked Then
      ShowFolders("ta source")
    End If
    If ChkTO.Checked Then
      ShowFolders("to source")
    End If
    If ChkTX.Checked Then
      ShowFolders("tx source")
    End If
    If ChkUB.Checked Then
      ShowFolders("ub source")
    End If

    If ChkAP.Checked Then
      ShowFolders("ap source")
    End If
    If ChkPO.Checked Then
      ShowFolders("po source")
    End If
    If ChkPR.Checked Then
      ShowFolders("pr source")
    End If
    If ChkPS.Checked Then
      ShowFolders("ps source")
    End If
    If ChkTS.Checked Then
      ShowFolders("ts source")
    End If
    If ChkMR.Checked Then
      ShowFolders("mr source")
    End If
    If ChkBD.Checked Then
      ShowFolders("bd source")
    End If

    With DataGrdView
      .RowHeadersWidth = 25
      .DataSource = ds.Tables(0)
      .Refresh()
      .Columns(0).Width = 250
      .Columns(1).Width = 450
    End With
    LblNumPgms.Text = "Program count = " & WrkNumPgms
    LblNumMods.Text = "Module count = " & WrkNumMods
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("SourceName", Type.GetType("System.String"))
      .Columns.Add("FileName", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub BtnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProcess.Click
    ds.Clear()
    ChgSource()
  End Sub

End Class
