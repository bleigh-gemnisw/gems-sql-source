Public Class FrmAP101D
  Dim myAPEHST As APEHST.MyData
  Dim myAPEHSTL1 As APEHSTL1.MyData
  Friend WrkVndnr As String
  Friend WrkVennm As String
  Friend WrkInvno As String
  Friend WrkChkpd As Integer
  Friend WrkInvdt As Integer
  Dim ds As DataSet = New DataSet

  Private Sub FrmAP101D_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim WrkChkAmt As Decimal
    myAPEHST = New APEHST.MyData()
    myAPEHST.MyDBConn = myDBConnect
    myAPEHSTL1 = New APEHSTL1.MyData()
    myAPEHSTL1.MyDBConn = myDBConnect
    MyFrmAP101.TbarNew.Enabled = False
    MyFrmAP101.TBarSave.Enabled = True
    MyFrmAP101.TBarDelete.Enabled = False

    LblVndnr.Text = WrkVndnr
    LblVennm.Text = WrkVennm
    LblInvno.Text = WrkInvno
    If WrkChkpd <> 0 Then
      LblChkpd.Text = WrkChkpd
    Else
      LblChkpd.Text = ""
    End If

    If s_chg = False And s_full = False Then    '#sec
      MyFrmAP101.TBarSave.Visible = False
    End If

    With myAPEHST
      .GetOneRecordP(Trim(WrkVndnr), Trim(WrkInvno), 0, WrkChkpd)
      If ._FSCYR > 0 Then
        LblFscyr.Text = ._FSCYR
      Else
        LblFscyr.Text = ""
      End If
      If ._PONBR > 0 Then
        LblPoNbr.Text = ._PONBR
      Else
        LblPoNbr.Text = ""
      End If
      If ._PRJ > 0 Then
        LblPrj.Text = ._PRJ
      Else
        LblPrj.Text = ""
      End If
      LblDsctx.Text = Trim(._DSCTX)
      If ._AMTGR <> 0 Then
        LblAmtgr.Text = Format(._AMTGR, "fixed")
      Else
        LblAmtgr.Text = ""
      End If
      If ._AMTPD <> 0 Then
        LblAmtpd.Text = Format(._AMTPD, "fixed")
      Else
        LblAmtpd.Text = ""
      End If
      If ._PPDT8 > 0 Then
        LblPPdt8.Text = MyUtils.GetDBDate(._PPDT8)
      Else
        LblPPdt8.Text = ""
      End If
      If ._INVD8 > 0 Then
        LblInvd8.Text = MyUtils.GetDBDateMDY(._INVD8)
      Else
        LblInvd8.Text = ""
      End If
      If ._DUED8 > 0 Then
        LblDued8.Text = MyUtils.GetDBDate(._DUED8)
      Else
        LblDued8.Text = ""
      End If
      LblBnkcd.Text = Trim(._BNKCD)
      LblLeopn.Text = ._LEOPN
      If ._F1099 = "Y" Then
        ChkF1099.Checked = True
      Else
        ChkF1099.Checked = False
      End If
      WrkChkAmt = myAPEHSTL1.GetVndnrChk(._VNDNR, ._CHKPD, ._PPDT8)
        If WrkChkAmt > 0 Then
        LblChkAmt.Text = Format(WrkChkAmt, "fixed")
      Else
        LblChkAmt.Text = ""
      End If
      If ._MANUL = "M" Then
        LblManual.Visible = True
      Else
        LblManual.Visible = False
      End If
      If ._AVOID = "V" Then
        LblVoid.Visible = True
      Else
        LblVoid.Visible = False
      End If
    End With
    FormatGrid()

  End Sub
  Private Sub FrmAP101D_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmAP101.SbpScreen.Text = "AP101D"
  MyUtils.CenterForm(Me.ParentForm, Me)
 End Sub
 Private Sub FrmAP101D_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmAP101.TbarNew.Enabled = False
  MyFrmAP101.TBarSave.Enabled = True
  MyFrmAP101C.Show()
 End Sub
  Public Sub FormatGrid()
    ds = myAPEHSTL1.GetVndnrInvL4(WrkVndnr, WrkInvno, WrkChkpd, 100)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).Visible = False
      .Columns(1).Visible = False
      .Columns(2).Visible = False
      .Columns(3).HeaderText = "Amount"
      .Columns(3).DefaultCellStyle.Format = "N2" 'Fixed
      .Columns(3).Width = 80
      .Columns(4).HeaderText = "Fund"
      .Columns(4).Width = 35
      .Columns(5).HeaderText = "Sfund"
      .Columns(5).Width = 35
      .Columns(6).HeaderText = "Dept"
      .Columns(6).Width = 35
      .Columns(7).HeaderText = "Obj"
      .Columns(7).Width = 35
      .Columns(8).HeaderText = "Func"
      .Columns(8).Width = 35
      .Columns(9).HeaderText = "Sfnc"
      .Columns(9).Width = 35
    End With
  End Sub
  Public Sub SaveData()
    Dim WrkSet As String
    Dim WrkWhere As String
    If ChkF1099.Checked Then
      WrkSet = "Set F1099= 'Y'"
    Else
      WrkSet = "Set F1099= 'N'"
    End If
    WrkWhere = "Where VNDNR='" & Trim(WrkVndnr) & "' and INVNO='" & Trim(WrkInvno) &
     "' and CHKPD=" & WrkChkpd & " and recno=0"

    With myAPEHST
      .RunUpdateQuery(WrkSet, WrkWhere)
    End With
    Me.Close()
  End Sub
End Class