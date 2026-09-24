'added these 3 for doing pdf and email
Imports System.Net
Imports System.Net.Mail
Imports CrystalDecisions.Shared


Public Class FrmCrViewer
  Inherits System.Windows.Forms.Form

  Dim myreport As New PrtTX115
  Friend WithEvents btnsend As Button
  Friend Wrkds As DataSet
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
  Friend WithEvents Cr1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents Crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.btnsend = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'Crv1
    '
    Me.Crv1.ActiveViewIndex = -1
    Me.Crv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Crv1.Cursor = System.Windows.Forms.Cursors.Default
    Me.Crv1.Location = New System.Drawing.Point(8, 8)
    Me.Crv1.Name = "Crv1"
    Me.Crv1.Size = New System.Drawing.Size(652, 376)
    Me.Crv1.TabIndex = 0
    '
    'btnsend
    '
    Me.btnsend.Location = New System.Drawing.Point(484, 42)
    Me.btnsend.Name = "btnsend"
    Me.btnsend.Size = New System.Drawing.Size(159, 22)
    Me.btnsend.TabIndex = 1
    Me.btnsend.Text = "Send Email"
    Me.btnsend.UseVisualStyleBackColor = True
    '
    'FrmCrViewer
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(664, 386)
    Me.Controls.Add(Me.btnsend)
    Me.Controls.Add(Me.Crv1)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmCrViewer"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "CrViewer"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    Me.ResumeLayout(False)

  End Sub

#End Region
  Private Sub FrmCrViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    With myreport
      .SetDataSource(Wrkds)
      .SetParameterValue("MyReportTitle", "Tax Type Codes")
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    End With
    With Crv1
      .DisplayToolbar = True
      .ShowGroupTreeButton = False
      .ShowCloseButton = False
      .ShowCopyButton = False
      .ShowRefreshButton = False
      .ShowParameterPanelButton = False
      .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      .ReportSource = myreport
      .Zoom(75)




    End With
    'Added this to export to pdf.
    ExportReport(Crv1)
  End Sub


  Private Sub FrmCrViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    myreport.Close()
    myreport.Dispose()
  End Sub
  'Need this to export report to pdf 
  Public Sub ExportReport(ByVal XCrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer)
    Dim myPDFpath As String
    myPDFpath = "C:\temp\mytest.pdf"


    Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportClass ' Report Name
    CrReport = XCrystalReportViewer.ReportSource

    Try
      CrReport.ExportToDisk(ExportFormatType.PortableDocFormat, myPDFpath)

    Catch err As Exception

      MessageBox.Show(err.ToString())

    End Try
  End Sub
  'added the button to send email
  Private Sub btnsend_Click(sender As Object, e As EventArgs) Handles btnsend.Click
    Dim attachment As System.Net.Mail.Attachment
    Dim attachme As String

    Dim fromemail As String
    Dim toemail As String
    Dim credemail As String
    Dim credpw As String
    Dim mymailserver As String
    Dim mymailport As Integer
    Dim mymailEnableSsl As String
    Dim mymailsubject As String
    Dim mymailbody As String

    'Note to send using gmail the Cred account needs to allow Less secure apps

    ' mymailserver = "smtp.gmail.com"
    mymailserver = "smtp.office365.com"
    mymailport = 587
    mymailEnableSsl = "True"

    mymailbody = "Attachment: Customer's Crystal Report PDF"
    mymailsubject = "works from ms 365 mail too Crystal Report PDF again"

    credemail = "scanman@bearmountainhc.com"
    credpw = "Blank123*"
    fromemail = "scanman@bearmountainhc.com"
    toemail = "kim@gemnisw.com"
    attachme = "C:\temp\mytest.pdf"

    Try
      Using mm As MailMessage = New MailMessage(fromemail, toemail)
        mm.Subject = mymailsubject
        mm.Body = mymailbody

        attachment = New System.Net.Mail.Attachment(attachme) 'file path
        mm.Attachments.Add(attachment)

        mm.IsBodyHtml = True

        Using smtp As SmtpClient = New SmtpClient()
          smtp.Host = mymailserver
          smtp.UseDefaultCredentials = True
          smtp.Credentials = New NetworkCredential With {
                  .UserName = credemail,
                  .Password = credpw
              }
          smtp.Port = mymailport
          smtp.EnableSsl = mymailEnableSsl
          smtp.Send(mm)
          MsgBox("Report Sent", vbInformation)
        End Using
      End Using
    Catch ex As Exception
      'output the error
      MsgBox(ex.Message, vbCritical)
    End Try
  End Sub
End Class
