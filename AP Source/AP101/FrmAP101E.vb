Public Class FrmAP101E

  Dim myPOMAST As POMAST.myData
  Dim myPOMASTL6 As POMASTL1.MyData
  Friend WrkFscyr As Integer
  Friend WrkPonbr As Integer
Private Sub FrmAP101E_Load(sender As Object, e As EventArgs) Handles MyBase.Load
  myPOMAST = New POMAST.MyData()
  myPOMAST.MyDBConn = myDBConnect
  myPOMASTL6 = New POMASTL1.MyData()
  myPOMASTL6.MyDBConn = myDBConnect
  MyFrmAP101.TbarNew.Enabled = False
  MyFrmAP101.TBarSave.Enabled = False
  MyFrmAP101.TBarDelete.Enabled = False

  LblFscyr.Text = WrkFscyr
  LblPoNbr.Text = WrkPonbr

  If s_chg = False And s_full = False Then    '#sec
    MyFrmAP101.TBarSave.Visible = False
  End If

  With myPOMAST
    .GetOneRecordP(WrkFscyr, WrkPonbr, 0, 0, 0)
    Select Case Trim(._CMPCD)
    Case "C"
      LblCmpcd.Text = "CLOSED"
    Case "D"
      LblCmpcd.Text = "DELETED"
    Case Else
      LblCmpcd.Text = "OPEN"
    End Select
    If ._RENTD > 0 Then
      LblRentd.Text = MyUtils.GetDBDate(._RENTD)
    Else
      LblRentd.Text = ""
    End If
    LblVndnr.Text = Trim(._VNDNR)
    LblVennm.Text = Trim(._VENNM)
    If ._AMTNT > 0 Then
      LblAmtnt.Text = Format(._AMTNT, "fixed")
    Else
      LblAmtnt.Text = ""
    End If
    If ._AMTGR > 0 Then
      LblAmtgr.Text = Format(._AMTGR, "fixed")
    Else
      LblAmtgr.Text = ""
    End If
    If ._POPEN > 0 Then
      LblPopen.Text = Format(._POPEN, "fixed")
    Else
      LblPopen.Text = ""
    End If
    LblSname.Text = Trim(._SNAME)
    LblSadr1.Text = Trim(._SADR1)
    LblSadr2.Text = Trim(._SADR2)
    LblSadr3.Text = Trim(._SADR3)
    LblSzip.Text = Trim(._SZIP)
    If Trim(._SZIPE) <> "" Then
      LblSzip.Text = LblSzip.Text & "-" & Trim(._SZIPE)
    End If
    LblSadr4.Text = Trim(._SADR4)
    LblRname.Text = Trim(._RNAME)
    LblRadr1.Text = Trim(._RADR1)
    LblRadr2.Text = Trim(._RADR2)
    LblRadr3.Text = Trim(._RADR3)
    LblRadr4.Text = Trim(._RADR4)
    LblRzip.Text = Trim(._RZIP)
    If Trim(._RZIPE) <> "" Then
      LblRzip.Text = LblRzip.Text & "-" & Trim(._RZIPE)
    End If
    If ._FDNBR > 0 Then
      LblAcctNo.Text = BuildAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
    Else
      LblAcctNo.Text = ""
    End If
    If ._ORDSP > 0 Then
      LblOrdsp.Text = ._ORDSP
    Else
      LblOrdsp.Text = ""
    End If
    If ._DSCDL > 0 Then
      LblDscdl.Text = Format(._DSCDL, "fixed")
    Else
      LblDscdl.Text = ""
    End If
    If ._FDNBD > 0 Then
      LblAcctDsc.Text = BuildAcct(._FDNBD, ._SFUDD, ._DPNBD, ._OBNBD, ._FNPGD, ._SUBFD)
    Else
      LblAcctDsc.Text = ""
    End If
    If ._ORSHP > 0 Then
      LblOrshp.Text = ._ORSHP
    Else
      LblOrshp.Text = ""
    End If
    If ._SHPDL > 0 Then
      LblShpdl.Text = Format(._SHPDL, "fixed")
    Else
      LblShpdl.Text = ""
    End If
    If ._FDNBS > 0 Then
      LblAcctShp.Text = BuildAcct(._FDNBS, ._SFUNS, ._DPNBS, ._OBNBS, ._FNPGS, ._SUBFS)
    Else
      LblAcctShp.Text = ""
    End If
    LblManual.Visible = False
    If ._MNAYN = "Y" Then
      LblManual.Visible = True
    End If
    LblPOHasDlt.Visible = False
    If ._PODYN = "Y" Then
      LblPOHasDlt.Visible = True
    End If
  End With
  FormatGrid()
 End Sub
 Private Sub FrmAP101E_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmAP101.SbpScreen.Text = "AP101E"
  MyUtils.CenterForm(Me.ParentForm, Me)
 End Sub
 Private Sub FrmAP101E_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmAP101.TbarNew.Enabled = False
  MyFrmAP101.TBarSave.Enabled = True
  MyFrmAP101C.Show()
 End Sub
  Public Sub FormatGrid()
    Dim ds As DataSet
    ds = myPOMASTL6.GetViewbyPOL6(WrkFscyr, WrkPonbr, 100)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).Visible = False
      .Columns(1).Visible = False
      .Columns(2).HeaderText = "Seq"
      .Columns(2).Width = 30
      .Columns(3).Visible = False
      .Columns(4).HeaderText = "Catalog Number"
      .Columns(4).Width = 150
      .Columns(5).HeaderText = "Description"
      .Columns(5).Width = 200
      .Columns(6).Visible = False
      .Columns(7).Visible = False
      .Columns(8).HeaderText = "Amount"
      .Columns(8).DefaultCellStyle.Format = "N2" 'Fixed
      .Columns(8).Width = 60
      .Columns(9).HeaderText = "Fund"
      .Columns(9).Width = 40
      .Columns(10).HeaderText = "Sfund"
      .Columns(10).Width = 40
      .Columns(11).HeaderText = "Dept"
      .Columns(11).Width = 40
      .Columns(12).HeaderText = "Obj"
      .Columns(12).Width = 40
      .Columns(13).HeaderText = "Func"
      .Columns(13).Width = 40
      .Columns(14).HeaderText = "Sfcn"
      .Columns(14).Width = 40
    End With
  End Sub
End Class