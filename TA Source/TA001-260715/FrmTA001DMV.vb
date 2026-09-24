Public Class FrmTA001DMV
  Dim myTXVEH As TXVEH.MyData
  Dim myTXVEHL1 As TXVEHL1.MyData
  Dim myTXVCUS As TXVCUS.MyData
  Dim ds As DataSet = New DataSet
  Friend WrkVehID As Integer
  Friend WrkPCustID As Integer
  Friend WrkSCustID As Integer
  Friend WrkRegNo As String
  Friend WrkVIN As String
  Friend WrkListNo As Integer
  Friend WrkName As String
  Friend WrkType As String
  Private Sub FrmTA001DMV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXVEH = New TXVEH.MyData(myDBConnect)
    myTXVEHL1 = New TXVEHL1.MyData(myDBConnect)
    myTXVCUS = New TXVCUS.MyData(myDBConnect)

    MyFrmTA001.TBarComments.Enabled = False
    MyFrmTA001.TBarDelete.Enabled = False
    MyFrmTA001.TBarSave.Enabled = False
    MyFrmTA001.TBarAttach.Enabled = False

    LblListNo.Text = WrkListNo
    LoadForm()
  End Sub
  Private Sub LoadForm()
    LblNoMatch.Visible = False
    LblVIN.Visible = False
    If WrkVehID = 0 Then
      ds = myTXVEHL1.GetViewRegNo(WrkRegNo, 1)
      If ds.Tables(0).Rows.Count > 0 Then
        WrkVehID = ds.Tables(0).Rows(0).Item("vehid")
      End If
    End If
    GetDMVData(WrkVehID)
    If WrkPCustID = 0 Then
      WrkPCustID = myTXVEH._PCUST
      WrkSCustID = myTXVEH._SCUST
    End If
    GetDMVPCust(WrkPCustID)
    GetDMVSCust(WrkSCustID)
  End Sub
  Private Sub FrmTA001DMV_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA001.SbpScreen.Text = "TA001DMV"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub FrmTA001DMV_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTA001.TBarSave.Enabled = True
    MyFrmTA001.TBarDelete.Enabled = True
    MyFrmTA001.TBarLog.Enabled = True
    MyFrmTA001.TBarSave.Visible = True   '#sec
    MyFrmTA001.TBarComments.Enabled = True
    MyFrmTA001.TBarAttach.Enabled = True
    'Memory Cleanup
    myTXVEH = Nothing
    myTXVCUS = Nothing
    MyFrmTA001DMV = Nothing
    If WrkType = "M" Then
      MyFrmTA001MV.LblSSNo.Text = TxtSSNo.Text
      MyFrmTA001MV.LblSS2.Text = TxtSS2.Text
      MyFrmTA001MV.LblOid.Text = TxtOid.Text
      MyFrmTA001MV.Show()
    Else
      MyFrmTA001SU.LblSSNo.Text = TxtSSNo.Text
      MyFrmTA001SU.LblSS2.Text = TxtSS2.Text
      MyFrmTA001SU.LblOid.Text = TxtOid.Text
      MyFrmTA001SU.Show()
    End If
  End Sub
  Public Sub GetDMVData(ByVal WrkVehID As Integer)
    With myTXVEH
      .GetOneRecordP(WrkVehID)
      If WrkVIN = Trim(._VINNO) Then
        LblVIN.Visible = False
      Else
        LblVIN.Visible = True
      End If
      LblListNo.Text = WrkListNo
      LblRegID.Text = ._REGID
      LblStrDate.Text = MyUtils.GetDBDate(._STRDT)
      LblEndDate.Text = MyUtils.GetDBDate(._ENDDT)
      TxtOid.Text = WrkVehID
      LblVMake.Text = ._VMAKE
      LblVModel.Text = ._VMODEL
      LblBody.Text = ._BODY
      LblYear.Text = ._YEAR
      LblClass.Text = ._CLASS & " - " & ._CLASSD
      LblRegno.Text = ._REGNO
      LblVinno.Text = ._VINNO
      LblCyaxl.Text = ._CYLAX
      LblVpclr.Text = ._VPCLR
      LblVsclr.Text = ._VSCLR
      LblSeat.Text = ._SEAT
      'Values
      LblOrig.Text = ._ORIG
      LblTrval.Text = ._TRVAL
      LblLnval.Text = ._LNVAL
      LblMSRP.Text = ._MSRP
      'Domiciled
      LblDadd1.Text = ._DADD1
      LblDadd2.Text = ._DADD2
      LblDcity.Text = ._DCITY
      LblDstate.Text = ._DSTATE
      LblDzip.Text = ._DZIPA
      'Lessee
      LblLcustid.Text = ._LCUST
      LblLname.Text = ._LNAME
      LblLbus.Text = ._LBUS
      LblLadd1.Text = ._LADD1
      LblLadd2.Text = ._LADD2
      LblLcity.Text = ._LCITY
      LblLstate.Text = ._LSTATE
      LblLzip.Text = ._LZIPA
    End With
  End Sub
  Public Sub GetDMVPCust(ByVal WrkCustID As Integer)
    'Primary
    TxtSSNo.Text = WrkCustID
    myTXVCUS.GetOneRecordP(WrkCustID)
    With myTXVCUS
      LblPname.Text = ._NAME
      LblPbus.Text = ._BUS
      LblPadd1.Text = ._ADD1
      LblPadd2.Text = ._ADD2
      LblPcity.Text = ._CITY
      LblPstate.Text = ._STATE
      LblPzip.Text = ._ZIPA
      LblRadd1.Text = ._RADD1
      LblRadd2.Text = ._RADD2
      LblRcity.Text = ._RCITY
      LblRstate.Text = ._RSTATE
      LblRzip.Text = ._RZIPA
      LblDob.Visible = False
      If ._DOB > 0 Then
        LblPDOB.Text = MyUtils.GetDBDate(._DOB)
        If WrkType = "M" Then
          If MyUtils.GetDBDate(._DOB) <> MyFrmTA001MV.DtPckDOB.Value Then
            LblDob.Visible = True
          End If
        Else
          If MyUtils.GetDBDate(._DOB) <> MyFrmTA001SU.DtPckDOB.Value Then
            LblDob.Visible = True
          End If
        End If
      Else
        LblPDOB.Text = ""
      End If
      LblPsex.Text = ._SEX
      LblPconfid.Text = ._CONFID
      If ._CONFID = "Y" Then
        LblMsgConf.Visible = True
      End If
    End With
  End Sub
  Public Sub GetDMVSCust(ByVal WrkCustID As Integer)
    'Secondary
    If WrkCustID > 0 Then
      TxtSS2.Text = WrkCustID
      myTXVCUS.GetOneRecordP(WrkCustID)
      With myTXVCUS
        LblSname.Text = ._NAME
        LblSbus.Text = ._BUS
        LblSadd1.Text = ._ADD1
        LblSadd2.Text = ._ADD2
        LblScity.Text = ._CITY
        LblSstate.Text = ._STATE
        LblSzip.Text = ._ZIPA
        If ._DOB > 0 Then
          LblSDOB.Text = MyUtils.GetDBDate(._DOB)
        Else
          LblSDOB.Text = ""
        End If
        LblSsex.Text = ._SEX
        LblSconfid.Text = ._CONFID
        If ._CONFID = "Y" Then
          LblMsgConf.Visible = True
        End If
      End With
    Else
      TabControl1.TabPages.Remove(TpSecondary)
    End If
  End Sub

  Private Sub LnkSS2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkSS2.LinkClicked
    MyFrmListVcus = New FrmListVcus
    MyFrmListVcus.MdiParent = Me.ParentForm
    MyFrmListVcus.WrkName = WrkName
    MyFrmListVcus.WrkPrimary = True
    MyFrmListVcus.Show()
  End Sub

  Private Sub LnkSSno_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkSSno.LinkClicked
    MyFrmListVcus = New FrmListVcus
    MyFrmListVcus.MdiParent = Me.ParentForm
    MyFrmListVcus.WrkName = WrkName
    MyFrmListVcus.WrkPrimary = True
    MyFrmListVcus.Show()
  End Sub

  Private Sub LnkOid_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkOid.LinkClicked
    If MyUtils.CnvSng(TxtSSNo.Text) = 0 Then
      MsgBox("Primary CustID is required", MsgBoxStyle.Exclamation, "Cannot lookup Vehicle ID")
      Exit Sub
    End If

    MyFrmListVeh = New FrmListVeh
    MyFrmListVeh.MdiParent = Me.ParentForm
    MyFrmListVeh.WrkCustID = MyUtils.CnvSng(TxtSSNo.Text)
    MyFrmListVeh.Show()
  End Sub
  Private Sub TxtOid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOid.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSSno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSSNo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSS2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSS2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtOid_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOid.Leave
    If Not IsNothing(myTXVEH) Then
      GetDMVData(MyUtils.CnvSng(TxtOid.Text))
    End If
  End Sub
  Private Sub TxtSSNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSSNo.Leave
    If Not IsNothing(myTXVCUS) Then
      GetDMVPCust(MyUtils.CnvSng(TxtSSNo.Text))
    End If
  End Sub
  Private Sub TxtSS2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSS2.Leave
    If Not IsNothing(myTXVCUS) Then
      GetDMVSCust(MyUtils.CnvSng(TxtSS2.Text))
    End If
  End Sub
End Class





