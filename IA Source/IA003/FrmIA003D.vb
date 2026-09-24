Public Class FrmIA003D
	Dim myGNETPGM As GNETPGM.myData
Private Sub BtnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImport.Click
  Dim Good As Boolean
  Good = RunUpdate()
  If Not Good Then
    MsgBox("Unable to find GNETPGM.XML file. Please contact hotline.", MsgBoxStyle.Critical, "Program aborted")
    Exit Sub
  End If
  ReadXML()
End Sub
Private Sub BtnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExport.Click
	SaveXML()
End Sub
Public Sub ReadXML()
	Dim ds As DataSet = New DataSet
	Dim WrkXMLPath As String
	Dim I As Integer

  WrkXMLPath = MyUtils.GetDataPath() & "GNETPGM.xml"
	ds.ReadXml(WrkXMLPath)
	For I = 0 To ds.Tables(0).Rows.Count - 1
		With myGNETPGM
			.GetOneRecordP(ds.Tables(0).Rows(I).Item("pgmid"))
			If .RecordNotFound Then
				._PGMID = ds.Tables(0).Rows(I).Item("pgmid")
				._PGMDESC = ds.Tables(0).Rows(I).Item("pgmdesc")
				._PGMAPP = ds.Tables(0).Rows(I).Item("pgmapp")
				._PGMEXE = ds.Tables(0).Rows(I).Item("pgmexe")
				.AddOneRecordP()
			End If
		End With
	Next

	MsgBox("File has been imported", MsgBoxStyle.Information, "Import is Done")
End Sub
Public Sub SaveXML()
	Dim ds As DataSet = New DataSet
	Dim WrkXMLPath As String

  myGNETPGM = New GNETPGM.myData()
  myGNETPGM.mydbconn = myDBConnect
  ds = myGNETPGM.PosData("")
  WrkXMLPath = MyUtils.GetDataPath() & "GNETPGM.XML"
	ds.WriteXml(WrkXMLPath)
	MsgBox("File has been exported to " & WrkXMLPath, MsgBoxStyle.Information, "Export is Done")
End Sub
Private Sub FRMIA003D_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
		MyFRMIA003.SbpScreen.Text = "IA003D"
    MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
	Private Sub FrmIA003D_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		MyFRMIA003.TBarNew.Enabled = True
		MyFRMIA003.TBarDelete.Enabled = False
		MyFRMIA003.TBarSave.Enabled = False
		MyFRMIA003.TBarPrint.Enabled = False
		MyFRMIA003.TBarSave.Visible = True
		MyFRMIA003.TBarFTP.Enabled = True
		MyFRMIA003B.FormatGrid()
		MyFRMIA003B.Show()
	End Sub
Private Sub FrmIA003D_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myGNETPGM = New GNETPGM.MyData()
  myGNETPGM.MyDBConn = myDBConnect
  MyFRMIA003.TBarNew.Enabled = False
	MyFRMIA003.TBarDelete.Enabled = False
	MyFRMIA003.TBarSave.Enabled = False
	MyFRMIA003.TBarPrint.Enabled = False
	MyFRMIA003.TBarSave.Visible = False
	MyFRMIA003.TBarFTP.Enabled = False
End Sub
End Class