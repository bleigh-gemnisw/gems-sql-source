Imports System.Drawing
Imports System.IO
Public Class FrmAttachit
  Inherits System.Windows.Forms.Form

  Dim MyDBConn As SQLConnect.DBConnection
  Dim myDBConnect As SQLConnect.DBConnection
  Dim mvar_UserID As String
  Dim mvar_KeyString As String
  Dim mvar_Program As String
  Dim mvar_rcount As Integer
  Dim mvar_DBConn As SQLConnect.DBConnection

  Friend ds As DataSet = New DataSet

  Dim WrkKey As String
  Dim WrkProgram As String
  Dim WrkPath As String
  Dim mytblfilesreal As TBLFILESREAL.MyData
  Friend WithEvents OpenFileDialog1 As Windows.Forms.OpenFileDialog
  Dim mytblcontrol As TBLCONTROL.MyData
  Friend WithEvents Panelgrid As Windows.Forms.Panel
  Friend WithEvents DataGrdView As Windows.Forms.DataGridView
  Friend WithEvents Paneladd As Windows.Forms.Panel
  Friend WithEvents btnnewattachment As Windows.Forms.Button
  Friend WithEvents txtattachdesc As Windows.Forms.TextBox
  Friend WithEvents btnsaveattach As Windows.Forms.Button
  Friend WithEvents btngetfile As Windows.Forms.Button
  Friend WithEvents txtpath As Windows.Forms.TextBox
  Friend WithEvents txtfile As Windows.Forms.TextBox
  Friend WithEvents lbltoattach As Windows.Forms.Label
  Friend WithEvents btnreturn As Windows.Forms.Button
  Friend WithEvents btndeleteattach As Windows.Forms.Button
  Friend WithEvents btncanceladdattach As Windows.Forms.Button
  Friend WithEvents Label1 As Windows.Forms.Label
  Friend WithEvents Label2 As Windows.Forms.Label
  Friend WithEvents LblErrMsg As Windows.Forms.Label
  Friend WithEvents lblpos As Windows.Forms.Label
  Friend WithEvents TxtPos As Windows.Forms.TextBox
  Friend WithEvents BtnFind As Windows.Forms.Button
  Dim savepath As String

#Region " Windows Form Designer generated code "

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
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAttachit))
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.PictureBox1 = New System.Windows.Forms.PictureBox()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.Panelgrid = New System.Windows.Forms.Panel()
    Me.lblpos = New System.Windows.Forms.Label()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.btnreturn = New System.Windows.Forms.Button()
    Me.btndeleteattach = New System.Windows.Forms.Button()
    Me.btnnewattachment = New System.Windows.Forms.Button()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.Paneladd = New System.Windows.Forms.Panel()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.btncanceladdattach = New System.Windows.Forms.Button()
    Me.lbltoattach = New System.Windows.Forms.Label()
    Me.txtattachdesc = New System.Windows.Forms.TextBox()
    Me.btnsaveattach = New System.Windows.Forms.Button()
    Me.btngetfile = New System.Windows.Forms.Button()
    Me.txtpath = New System.Windows.Forms.TextBox()
    Me.txtfile = New System.Windows.Forms.TextBox()
    Me.LblErrMsg = New System.Windows.Forms.Label()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panelgrid.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Paneladd.SuspendLayout()
    Me.SuspendLayout()
    '
    'PictureBox1
    '
    Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
    Me.PictureBox1.Location = New System.Drawing.Point(683, -2)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(80, 56)
    Me.PictureBox1.TabIndex = 0
    Me.PictureBox1.TabStop = False
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    '
    'OpenFileDialog1
    '
    Me.OpenFileDialog1.FileName = "OpenFileDialog1"
    '
    'Panelgrid
    '
    Me.Panelgrid.Controls.Add(Me.lblpos)
    Me.Panelgrid.Controls.Add(Me.TxtPos)
    Me.Panelgrid.Controls.Add(Me.BtnFind)
    Me.Panelgrid.Controls.Add(Me.Label2)
    Me.Panelgrid.Controls.Add(Me.btnreturn)
    Me.Panelgrid.Controls.Add(Me.btndeleteattach)
    Me.Panelgrid.Controls.Add(Me.btnnewattachment)
    Me.Panelgrid.Controls.Add(Me.DataGrdView)
    Me.Panelgrid.Location = New System.Drawing.Point(18, 57)
    Me.Panelgrid.Name = "Panelgrid"
    Me.Panelgrid.Size = New System.Drawing.Size(735, 307)
    Me.Panelgrid.TabIndex = 215
    '
    'lblpos
    '
    Me.lblpos.Location = New System.Drawing.Point(15, 67)
    Me.lblpos.Name = "lblpos"
    Me.lblpos.Size = New System.Drawing.Size(121, 16)
    Me.lblpos.TabIndex = 223
    Me.lblpos.Text = "Position To Description"
    '
    'TxtPos
    '
    Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPos.Location = New System.Drawing.Point(142, 67)
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(138, 20)
    Me.TxtPos.TabIndex = 221
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(286, 67)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 222
    Me.BtnFind.Text = "&Find"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(13, 286)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(181, 13)
    Me.Label2.TabIndex = 220
    Me.Label2.Text = "Double click row to open attachment"
    '
    'btnreturn
    '
    Me.btnreturn.Location = New System.Drawing.Point(495, 8)
    Me.btnreturn.Name = "btnreturn"
    Me.btnreturn.Size = New System.Drawing.Size(189, 47)
    Me.btnreturn.TabIndex = 219
    Me.btnreturn.Text = "Return"
    Me.btnreturn.UseVisualStyleBackColor = True
    '
    'btndeleteattach
    '
    Me.btndeleteattach.Location = New System.Drawing.Point(273, 6)
    Me.btndeleteattach.Name = "btndeleteattach"
    Me.btndeleteattach.Size = New System.Drawing.Size(189, 47)
    Me.btndeleteattach.TabIndex = 218
    Me.btndeleteattach.Text = "Delete Attachment"
    Me.btndeleteattach.UseVisualStyleBackColor = True
    '
    'btnnewattachment
    '
    Me.btnnewattachment.Location = New System.Drawing.Point(47, 6)
    Me.btnnewattachment.Name = "btnnewattachment"
    Me.btnnewattachment.Size = New System.Drawing.Size(189, 47)
    Me.btnnewattachment.TabIndex = 217
    Me.btnnewattachment.Text = "Add Attachment"
    Me.btnnewattachment.UseVisualStyleBackColor = True
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
    Me.DataGrdView.Location = New System.Drawing.Point(3, 94)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(726, 189)
    Me.DataGrdView.TabIndex = 208
    '
    'Paneladd
    '
    Me.Paneladd.Controls.Add(Me.Label1)
    Me.Paneladd.Controls.Add(Me.btncanceladdattach)
    Me.Paneladd.Controls.Add(Me.lbltoattach)
    Me.Paneladd.Controls.Add(Me.txtattachdesc)
    Me.Paneladd.Controls.Add(Me.btnsaveattach)
    Me.Paneladd.Controls.Add(Me.btngetfile)
    Me.Paneladd.Controls.Add(Me.txtpath)
    Me.Paneladd.Controls.Add(Me.txtfile)
    Me.Paneladd.Location = New System.Drawing.Point(15, 60)
    Me.Paneladd.Name = "Paneladd"
    Me.Paneladd.Size = New System.Drawing.Size(735, 307)
    Me.Paneladd.TabIndex = 216
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(22, 91)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(128, 13)
    Me.Label1.TabIndex = 222
    Me.Label1.Text = "Description of attachment"
    '
    'btncanceladdattach
    '
    Me.btncanceladdattach.Location = New System.Drawing.Point(25, 180)
    Me.btncanceladdattach.Name = "btncanceladdattach"
    Me.btncanceladdattach.Size = New System.Drawing.Size(135, 52)
    Me.btncanceladdattach.TabIndex = 221
    Me.btncanceladdattach.Text = "Cancel Add"
    Me.btncanceladdattach.UseVisualStyleBackColor = True
    '
    'lbltoattach
    '
    Me.lbltoattach.AutoSize = True
    Me.lbltoattach.Location = New System.Drawing.Point(239, 39)
    Me.lbltoattach.Name = "lbltoattach"
    Me.lbltoattach.Size = New System.Drawing.Size(0, 13)
    Me.lbltoattach.TabIndex = 220
    '
    'txtattachdesc
    '
    Me.txtattachdesc.Location = New System.Drawing.Point(212, 88)
    Me.txtattachdesc.Name = "txtattachdesc"
    Me.txtattachdesc.Size = New System.Drawing.Size(421, 20)
    Me.txtattachdesc.TabIndex = 219
    '
    'btnsaveattach
    '
    Me.btnsaveattach.Location = New System.Drawing.Point(25, 122)
    Me.btnsaveattach.Name = "btnsaveattach"
    Me.btnsaveattach.Size = New System.Drawing.Size(135, 52)
    Me.btnsaveattach.TabIndex = 218
    Me.btnsaveattach.Text = "Save attachment"
    Me.btnsaveattach.UseVisualStyleBackColor = True
    '
    'btngetfile
    '
    Me.btngetfile.Location = New System.Drawing.Point(25, 17)
    Me.btngetfile.Name = "btngetfile"
    Me.btngetfile.Size = New System.Drawing.Size(135, 56)
    Me.btngetfile.TabIndex = 217
    Me.btngetfile.Text = "Get file to attach"
    Me.btngetfile.UseVisualStyleBackColor = True
    Me.btngetfile.Visible = False
    '
    'txtpath
    '
    Me.txtpath.Location = New System.Drawing.Point(289, 165)
    Me.txtpath.Name = "txtpath"
    Me.txtpath.Size = New System.Drawing.Size(344, 20)
    Me.txtpath.TabIndex = 216
    Me.txtpath.Visible = False
    '
    'txtfile
    '
    Me.txtfile.Location = New System.Drawing.Point(289, 139)
    Me.txtfile.Name = "txtfile"
    Me.txtfile.Size = New System.Drawing.Size(344, 20)
    Me.txtfile.TabIndex = 215
    Me.txtfile.Visible = False
    '
    'LblErrMsg
    '
    Me.LblErrMsg.AutoSize = True
    Me.LblErrMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblErrMsg.Location = New System.Drawing.Point(12, 24)
    Me.LblErrMsg.Name = "LblErrMsg"
    Me.LblErrMsg.Size = New System.Drawing.Size(117, 15)
    Me.LblErrMsg.TabIndex = 221
    Me.LblErrMsg.Text = "<Error Message>"
    '
    'FrmAttachit
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(762, 382)
    Me.Controls.Add(Me.LblErrMsg)
    Me.Controls.Add(Me.PictureBox1)
    Me.Controls.Add(Me.Panelgrid)
    Me.Controls.Add(Me.Paneladd)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmAttachit"
    Me.ShowIcon = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Attachments"
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panelgrid.ResumeLayout(False)
    Me.Panelgrid.PerformLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Paneladd.ResumeLayout(False)
    Me.Paneladd.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

#Region "Constructors"

  'Public Sub New(DBConn As SQLConnect.DBConnection)
  '  MyBase.New()
  '   InitializeComponent()
  '  MyDBConn = DBConn
  ' End Sub
  Public Sub New()
    MyBase.New()
    InitializeComponent()
  End Sub

#End Region
  Public Function getcount() As Integer
    Dim wrkcount As Integer
    MyDBConn = mvar_DBConn
    mytblfilesreal = New TBLFILESREAL.MyData(MyDBConn)
    WrkKey = mvar_KeyString
    WrkProgram = mvar_Program
    wrkcount = mytblfilesreal.getcount(WrkKey, WrkProgram)

    Return wrkcount
  End Function
  Public Sub LoadForm()
    Dim Good As Boolean
    LblErrMsg.Text = ""
    Me.Text = "Attachments: " & mvar_KeyString
    MyDBConn = mvar_DBConn
    mytblcontrol = New TBLCONTROL.MyData(MyDBConn)
    getdefaultpath()
    Good = Directory.Exists(WrkPath)
    If Good Then
      mytblfilesreal = New TBLFILESREAL.MyData(MyDBConn)
      WrkKey = mvar_KeyString
      WrkProgram = mvar_Program
      Call FormatGrid()
    Else
      LblErrMsg.Text = "Invalid Control record path or no permissions"
      btnnewattachment.Enabled = False
      btncanceladdattach.Enabled = False
      btndeleteattach.Enabled = False
    End If
    Me.ShowDialog()
  End Sub
  Public Sub FormatGrid()
    Call ShowGrid()
    With DataGrdView
      .ColumnHeadersDefaultCellStyle.SelectionBackColor = .ColumnHeadersDefaultCellStyle.BackColor
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).Visible = False  'rcdid
      .Columns(1).Visible = False  'MASTERTABLENAME
      .Columns(2).Visible = False  'MASTERTABLEKEY
      .Columns(3).Visible = False   'FILESTORED
      .Columns(4).HeaderText = "Description"   'ATTACHDESC
      .Columns(4).Width = 325
      .Columns(5).HeaderText = "Date/Time"     'ATTACHDATE
      .Columns(5).Width = 125
      .Columns(6).Visible = False            'KEYSTRING
      .Columns(7).HeaderText = "File Name"   'Original file
      .Columns(7).Width = 225
      '.ClearSelection()
    End With
  End Sub
  Public Sub ShowGrid()
    lbltoattach.Text = ""
    If Trim(TxtPos.Text) > "" Then
      ds = mytblfilesreal.PosData(WrkKey, WrkProgram, Trim(TxtPos.Text))
    Else
      ds = mytblfilesreal.PosData(WrkKey, WrkProgram, "")
    End If

    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
    mytblfilesreal.CloseFile()
    If ds.Tables(0).Rows.Count > 0 Then
      Panelgrid.Show()
      Paneladd.Hide()
    Else
      Panelgrid.Show()
      Paneladd.Hide()
    End If
  End Sub
  Public Sub getdefaultpath()
    WrkPath = ""
    mytblcontrol.GetOneRecordP("attachpath")
    If mytblcontrol.RecordNotFound Then
      MsgBox("Missing Control Record", MsgBoxStyle.OkOnly, "Attachments")
      Exit Sub
    End If
    With mytblcontrol
      WrkPath = Trim(._FIELD01)
    End With
  End Sub
  Private Sub btngetfile_Click(sender As Object, e As EventArgs) Handles btngetfile.Click
    lbltoattach.Text = ""
    OpenFileDialog1.ShowDialog()
    txtfile.Text = Path.GetFileName(OpenFileDialog1.FileName)
    txtpath.Text = Path.GetDirectoryName(OpenFileDialog1.FileName) & "\" & txtfile.Text
    lbltoattach.Text = txtpath.Text
  End Sub
  Private Sub btnsaveattach_Click(sender As Object, e As EventArgs) Handles btnsaveattach.Click
    Dim wrkdatetime As String
    Dim wrkdatetime2 As DateTime
    Dim wrkdesc As String
    Dim wrkfilesave As String
    If Trim(txtfile.Text) = "" Then
      MsgBox("NO file attached", MsgBoxStyle.OkOnly, "Attachments")
      Return
    End If

    If Trim(txtattachdesc.Text) = "" Then
      MsgBox("Description must be filled", MsgBoxStyle.OkOnly, "Attachments")
      Return
    End If

    wrkdatetime2 = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
    wrkdatetime = wrkdatetime2.ToString("yyyyMMddHHmmss")
    wrkdesc = txtattachdesc.Text
    savepath = WrkPath
    wrkfilesave = Replace(txtfile.Text, "'", "")

    If System.IO.File.Exists(savepath & "\" & mvar_KeyString & wrkdatetime & wrkfilesave) Then
      MsgBox("File exists", MsgBoxStyle.OkOnly, "Attachments")
    Else
      File.Copy(txtpath.Text, savepath & "\" & mvar_KeyString & wrkdatetime & wrkfilesave)
      mytblfilesreal._MASTERTABLEKEY = 0
      mytblfilesreal._KEYSTRING = mvar_KeyString
      mytblfilesreal._ATTACHDATE = wrkdatetime2
      mytblfilesreal._ATTACHDESC = wrkdesc
      mytblfilesreal._MASTERTABLENAME = mvar_Program
      mytblfilesreal._FILESTORED = mvar_KeyString & wrkdatetime & wrkfilesave
      mytblfilesreal._ORIGINALFILE = Trim(wrkfilesave)
      mytblfilesreal.InsertOneRecordP()
      If mytblfilesreal.ErrMsg <> "" Then
        MsgBox("File not attached..." & mytblfilesreal.ErrMsg, MsgBoxStyle.OkOnly, "Error occurred")
      End If
      '      MsgBox("File attached successfully", MsgBoxStyle.OkOnly, "Attachments")
      Panelgrid.Show()
      Paneladd.Hide()
      FormatGrid()
    End If
  End Sub

  Private Sub btnnewattachment_Click(sender As Object, e As EventArgs) Handles btnnewattachment.Click
    lbltoattach.Text = ""
    txtattachdesc.Text = ""
    btngetfile.Visible = False
    Panelgrid.Hide()
    Paneladd.Show()
    lbltoattach.Text = ""
    OpenFileDialog1.Title = "Select file to attach"
    OpenFileDialog1.FileName = ""
    ' OpenFileDialog1.ShowDialog()
    If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
      txtfile.Text = Path.GetFileName(OpenFileDialog1.FileName)
      txtpath.Text = Path.GetDirectoryName(OpenFileDialog1.FileName) & "\" & txtfile.Text
      lbltoattach.Text = txtpath.Text
      txtattachdesc.Select()
    Else
      MsgBox("Add attachment cancelled by user", MsgBoxStyle.OkOnly, "Attachments")
      Panelgrid.Show()
      Paneladd.Hide()
      FormatGrid()
    End If
  End Sub

  Private Sub btnreturn_Click(sender As Object, e As EventArgs) Handles btnreturn.Click
    Me.Close()
  End Sub

  Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Dim wrkfile As String
    If DataGrdView.RowCount > 0 Then
      wrkfile = DataGrdView.Item(3, DataGrdView.CurrentRow.Index).Value

      Try
        Process.Start(WrkPath & "\" & wrkfile)
      Catch
        MsgBox("Issue trying to open attachment", MsgBoxStyle.OkOnly, "Attachments")

      End Try



    End If
  End Sub

  Private Sub btncanceladdattach_Click(sender As Object, e As EventArgs) Handles btncanceladdattach.Click
    If ds.Tables(0).Rows.Count > 0 Then
      Paneladd.Hide()
      FormatGrid()
      Panelgrid.Show()
    Else
      Me.Close()
    End If

  End Sub

  Private Sub btndeleteattach_Click(sender As Object, e As EventArgs) Handles btndeleteattach.Click
    Dim wrkrec As Integer
    Dim wrkfile As String
    If DataGrdView.SelectedRows.Count < 1 Then
      MsgBox("Please select attachment to delete", MsgBoxStyle.OkOnly, "Attachments")
      Exit Sub
    End If

    If MsgBox("Delete Selected Attachment?", MsgBoxStyle.YesNo, "Attachments") = MsgBoxResult.Yes Then
      wrkfile = DataGrdView.Item(3, DataGrdView.CurrentRow.Index).Value
      wrkrec = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      mytblfilesreal._RCDID = wrkrec
      mytblfilesreal.DeleteSQL()
      Try
        My.Computer.FileSystem.DeleteFile(WrkPath & "\" & wrkfile)
      Catch

      End Try

      FormatGrid()
    End If

  End Sub

  Public Property KeyString() As String
    Get
      KeyString = mvar_KeyString
    End Get
    Set(ByVal Value As String)
      mvar_KeyString = Value
    End Set
  End Property
  Public Property Program() As String
    Get
      Program = mvar_Program
    End Get
    Set(ByVal Value As String)
      mvar_Program = Value
    End Set
  End Property

  Public Property DBConn() As SQLConnect.DBConnection
    Get
      DBConn = mvar_DBConn
    End Get
    Set(ByVal Value As SQLConnect.DBConnection)
      mvar_DBConn = Value
    End Set
  End Property


  Private Sub FrmAttachit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

  End Sub

  Private Sub BtnFind_Click(sender As Object, e As EventArgs) Handles BtnFind.Click

    FormatGrid()
    TxtPos.Text = ""
  End Sub
End Class
