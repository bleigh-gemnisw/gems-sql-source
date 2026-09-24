Public Class FrmBD001D
Dim myBDMAST As BDMAST.myData
Dim myBDRATE As BDRATE.myData
Friend WrkRecID As Integer
Friend WrkType As String
Dim WrkPrevType As String
Private Sub FrmBD001D_Load(sender As Object, e As EventArgs) Handles MyBase.Load
  myBDMAST = New BDMAST.mydata(MyDBConnect)
  myBDRATE = New BDRATE.mydata(MyDBConnect)
  Dim ds2 As DataSet = New DataSet

  With myBDMAST
    .GetOneRecordP(WrkRecID)
    WrkPrevType = Trim(._TYPE)
    LblPermitNo.Text = Trim(._PERMNO)
    myBDRATE.GetFirstTier(WrkType)
    LblPermDesc.Text = Trim(myBDRATE._DESC)
    LblName.Text = Trim(._NAME)
    LblLocNo.Text = Trim(._LOCNO)
    LblLoc.Text = Trim(._LOC)
  End With

  If WrkPrevType = WrkType Then
    BtnConfirm.Enabled = False
  End If
End Sub
Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
  With myBDMAST
    ._TYPE = WrkType
    Select Case WrkPrevType
    Case "DEMO"
      ._BLDGAS = ""
      ._CONSTY = ""
      ._DMSIZE = ""
      ._DMSTOR = 0
      ._DMDATE = 0
      ._DMELEC = ""
      ._DMGAS = ""
      ._DMPHON = ""
      ._DMSEPT = ""
      ._DMSWR = ""
      ._DMWPCA = ""
    Case "ELECT"
      ._ELACCT = ""
      ._ELECCD = ""
      ._ELECYR = 0
    Case "FLIQ", "HVAC"
      ._HEATTY = ""
      ._TANK = 0
      ._TANKLO = ""
    Case "P&Z"
      ._ANAME = ""
      ._AADD1 = ""
      ._APCITY = ""
      ._ASTATE = ""
      ._AZIP = 0
      ._APHONE = ""
      ._APROP = ""
      ._ZONE = ""
      ._PZSQ = 0
      ._PZUSE = 0
      ._PZFRNT = ""
      ._PZWATR = ""
    Case Else
      If WrkType = "P&Z" Then
        ._COID = 0
        ._COLIC = ""
        ._CONAME = ""
        ._CONSTY = ""
        ._COPHON = ""
      End If
    End Select
    .UpdateOneRecordP()
  End With
  MyFrmBD001B.FormatGrid()
  MyFrmBD001B.Show()
  Me.Close()
End Sub
End Class





