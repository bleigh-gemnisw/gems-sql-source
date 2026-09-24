Imports System.IO
Imports System.Text
Module PrintSingleTakeOff

Dim myTXINV As TXINV.myData
Dim myTXINVLM As TXINVLM.myData
Dim myTXINVLN As TXINVLN.myData
Dim myTXVEHL2 As TXVEHL2.myData

Dim ds As DataSet = New DataSet
Dim dsDetail As DataSet = New DataSet
Dim dr As DataRow
Dim WrkCust As Integer
Dim WrkPost As Boolean
Dim Found As Boolean
  Public Sub PrtSingleTakeOff()
  myTXINVLM = New TXINVLM.mydata(MyDBConnect)
  myTXINVLN = New TXINVLN.mydata(MyDBConnect)
  myTXINV = New TXINV.mydata(MyDBConnect)
  myTXVEHL2 = New TXVEHL2.mydata(MyDBConnect)

  With MyFrmTX407B
    WrkCust = MyUtils.CnvSng(.TxtTakeDMVCustID.Text)
    WrkPost = .ChkPost.Checked
  End With

  InitCASHINT()
  If dsDetail.Tables.Count = 0 Then
    BuildDs2(dsDetail)
  Else
    dsDetail.Clear()
  End If
  ds = myTXVEHL2.GetViewbyPcust(WrkCust, 99999999, 0)
  With MyFrmTX407B
    .ErrProv.SetError(.TxtTakeDMVCustID, "")
    If ds.Tables(0).Rows.Count = 0 Then
      .ErrProv.SetError(.TxtTakeDMVCustID, "Cannot find Cust ID")
      Exit Sub
    End If
  End With
  GetDetail()

End Sub
Private Sub GetDetail()
Dim WrkBalance As Boolean

  WrkBalance = CheckBalance(WrkCust, True)
  If Not WrkBalance Then
    WrkBalance = CheckBalance(WrkCust, False)
  End If

  FormatGrid()
  If Not WrkBalance Then
    FlagTakeoffs()
  Else
    MyFrmTX407B.LblTakeMsg.Text = MyFrmTX407B.LblTakeMsg.Text & " *ALERT* records have a balance due"
  End If

End Sub
Private Sub FlagTakeoffs()
  Dim ds2 As DataSet = New DataSet
  Dim WrkBalance As Boolean
  Dim WrkCountBal As Integer
  Dim WrkCountTake As Integer
  Dim J As Integer

    ds2 = myTXINVLM.GetAllSSNo(WrkCust, 5000, False)
    For J = 0 To ds2.Tables(0).Rows.Count - 1
      With myTXINV
        If ds2.Tables(0).Rows(J).Item("mvflag") <> "Y" And ds2.Tables(0).Rows(J).Item("mvflag") <> "P" Then
          Continue For
        End If
        .GetOneRecordP(ds2.Tables(0).Rows(J).Item("list#"), ds2.Tables(0).Rows(J).Item("year"), _
          ds2.Tables(0).Rows(J).Item("type"))
        WrkBalance = False
        If Not WrkBalance Then
          WrkCountTake = WrkCountTake + 1
          If WrkPost Then
            ._MVFLAG = ""
            .UpdateOneRecordP()
          End If
        Else
          WrkCountBal = WrkCountBal + 1
        End If
      End With
    Next

  If WrkPost Then
    MyFrmTX407B.TxtTakeDMVCustID.Text = ""
    MyFrmTX407B.LblTakeMsg.Text = WrkCust & ": Records Takeoff=" & WrkCountTake
    MyFrmTX407B.ChkPost.Checked = False
  Else
    MyFrmTX407B.LblTakeMsg.Text = "Records to Takeoff=" & WrkCountTake
  End If
  If WrkCountBal > 0 Then
    MyFrmTX407B.LblTakeMsg.Text = MyFrmTX407B.LblTakeMsg.Text & " *ALERT* " & WrkCountBal & " records have a balance due"
  End If
  ds2 = Nothing
End Sub
Private Function CheckBalance(ByVal WrkCust As Integer, ByVal WrkPrimary As Boolean) As Boolean
  Dim ds2 As DataSet = New DataSet
  Dim WrkDue As Decimal
  Dim WrkGracePeriod As Boolean
  Dim I As Integer

  If WrkCust = 0 Then Return False

  If WrkPrimary Then
    ds2 = myTXINVLM.GetAllSSNo(WrkCust, 5000, False)
  Else
    ds2 = myTXINVLN.GetAllSS2(WrkCust, 5000, False)
  End If
  For I = 0 To ds2.Tables(0).Rows.Count - 1
    WrkDue = 0
    If ds2.Tables(0).Rows(I).Item("wbal") > 0 Then
      CalcInterest(ds2.Tables(0).Rows(I).Item("list#"), ds2.Tables(0).Rows(I).Item("type"), _
        ds2.Tables(0).Rows(I).Item("year"), 0, 0, 0, 0, 0, 0, WrkDue, WrkGracePeriod, 0, "")
    End If
    dr = dsDetail.Tables(0).NewRow
    dr.Item("regno") = ""
    dr.Item("list") = ds2.Tables(0).Rows(I).Item("list#")
    dr.Item("type") = ds2.Tables(0).Rows(I).Item("type")
    dr.Item("year") = ds2.Tables(0).Rows(I).Item("year")
    dr.Item("name") = ds2.Tables(0).Rows(I).Item("name")
    dr.Item("dob") = 0
    dr.Item("msg") = WrkDue
    dsDetail.Tables(0).Rows.Add(dr)
    If WrkDue > 0 And Not WrkGracePeriod Then
      Return True
    End If
  Next
  ds2 = Nothing
  Return False
End Function
Public Sub FormatGrid()

  MyFrmTX407B.C1DataGrdList.DataSource = dsDetail.Tables(0)
  MyFrmTX407B.C1DataGrdList.Refresh()
  With MyFrmTX407B.C1DataGrdList
    .Rebind(True)
    .Splits(0).DisplayColumns(0).Visible = False
    .Columns(1).Caption = "List #"
    .Splits(0).DisplayColumns(1).Width = 50
    .Columns(2).Caption = "Type"
    .Splits(0).DisplayColumns(2).Width = 35
    .Columns(3).Caption = "Year"
    .Splits(0).DisplayColumns(3).Width = 35
    .Columns(4).Caption = "Name"
    .Splits(0).DisplayColumns(4).Width = 165
    .Splits(0).DisplayColumns(5).Visible = False
    .Splits(0).DisplayColumns(6).Visible = False
    .Splits(0).DisplayColumns(7).Visible = False
    .Columns(8).Caption = "Balance"
    .Splits(0).DisplayColumns(8).Width = 60
 End With

End Sub
End Module







