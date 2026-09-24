Imports System.io
Imports System.Text
Module PrintSinglePutOn

Dim myTXINV As TXINV.myData
Dim myTXINVLM As TXINVLM.myData
Dim myTXINVLN As TXINVLN.myData
Dim myTXVEHL2 As TXVEHL2.myData
Dim myTXVCUS As TXVCUS.myData

Dim ds As DataSet = New DataSet
Dim dsDetail As DataSet = New DataSet
Dim dr As DataRow
Dim WrkCust As Integer
Dim WrkPost As Boolean
Dim Found As Boolean
  Public Sub PrtSinglePuton()

  myTXINVLM = New TXINVLM.mydata(MyDBConnect)
  myTXINVLN = New TXINVLN.mydata(MyDBConnect)
  myTXINV = New TXINV.mydata(MyDBConnect)
  myTXVEHL2 = New TXVEHL2.mydata(MyDBConnect)
  myTXVCUS = New TXVCUS.mydata(MyDBConnect)

  With MyFrmTX407B
    WrkCust = MyUtils.CnvSng(.TxtPutDMVCustID.Text)
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
    .ErrProv.SetError(.TxtPutDMVCustID, "")
    If ds.Tables(0).Rows.Count = 0 Then
      .ErrProv.SetError(.TxtPutDMVCustID, "Cannot find Cust ID")
      Exit Sub
    End If
  End With
  GetDetail()

End Sub
Private Sub GetDetail()
  Dim ds2 As DataSet = New DataSet
  Dim WrkPutOn As Integer
  Dim WrkPrev As Integer
  Dim WrkDue As Decimal
  Dim WrkGracePeriod As Boolean
  Dim J As Integer

  ds2 = myTXINVLM.GetAllSSNo(WrkCust, 999, MyBlocking)
  For J = 0 To ds2.Tables(0).Rows.Count - 1
    myTXINV.GetOneRecordP(ds2.Tables(0).Rows(J).Item("list#"), ds2.Tables(0).Rows(J).Item("year"), _
      ds2.Tables(0).Rows(J).Item("type"))
    myTXVCUS.GetOneRecordP(WrkCust)
    If Not myTXVCUS.RecordNotFound Then
      CalcInterest(ds2.Tables(0).Rows(J).Item("list#"), ds2.Tables(0).Rows(J).Item("type"), _
        ds2.Tables(0).Rows(J).Item("year"), 0, 0, 0, 0, 0, 0, WrkDue, WrkGracePeriod, 0, "")
      If WrkDue > 0 And Not WrkGracePeriod Then
        With myTXINV
          If ._BALD <= 0 Then Continue For
          If ._MVFLAG = "Y" Or ._MVFLAG = "P" Then
            WrkPrev = WrkPrev + 1
          Else
            WrkPutOn = WrkPutOn + 1
          End If
          If WrkPost And ._MVFLAG <> "Y" And ._MVFLAG <> "P" Then
            ._MVFLAG = "Y"
            If ._SSNo = 0 Then
              ._SSNo = WrkCust
            End If
            .UpdateOneRecordP()
          End If
          dr = dsDetail.Tables(0).NewRow
          dr.Item("regno") = ._IMVREG
          dr.Item("list") = ._LISTNo
          dr.Item("type") = ._TYPE
          dr.Item("year") = ._YEAR
          dr.Item("name") = ._NAME
          dr.Item("dob") = ._DOB
          dr.Item("msg") = ._MVFLAG
          dsDetail.Tables(0).Rows.Add(dr)
        End With
      End If
    End If
  Next

  ds2 = myTXINVLN.GetAllSS2(WrkCust, 999, MyBlocking)
  For J = 0 To ds2.Tables(0).Rows.Count - 1
    myTXINV.GetOneRecordP(ds2.Tables(0).Rows(J).Item("list#"), ds2.Tables(0).Rows(J).Item("year"), _
      ds2.Tables(0).Rows(J).Item("type"))
    myTXVCUS.GetOneRecordP(WrkCust)
    If Not myTXVCUS.RecordNotFound Then
      CalcInterest(ds2.Tables(0).Rows(J).Item("list#"), ds2.Tables(0).Rows(J).Item("type"), _
        ds2.Tables(0).Rows(J).Item("year"), 0, 0, 0, 0, 0, 0, WrkDue, WrkGracePeriod, 0, "")
      If WrkDue > 0 And Not WrkGracePeriod Then
        With myTXINV
          If ._BALD <= 0 Then Continue For
          If ._MVFLAG = "Y" Or ._MVFLAG = "P" Then
            WrkPrev = WrkPrev + 1
          Else
            WrkPutOn = WrkPutOn + 1
          End If
          If WrkPost And ._MVFLAG <> "Y" And ._MVFLAG <> "P" Then
            ._MVFLAG = "Y"
            If ._SSNo = 0 Then
              ._SSNo = WrkCust
            End If
            .UpdateOneRecordP()
          End If
          dr = dsDetail.Tables(0).NewRow
          dr.Item("regno") = ._IMVREG
          dr.Item("list") = ._LISTNo
          dr.Item("type") = ._TYPE
          dr.Item("year") = ._YEAR
          dr.Item("name") = ._NAME
          dr.Item("dob") = ._DOB
          dr.Item("msg") = ._MVFLAG
          dsDetail.Tables(0).Rows.Add(dr)
        End With
      End If
    End If
  Next

  FormatGrid()
  If WrkPost Then
    MyFrmTX407B.TxtPutDMVCustID.Text = ""
    MyFrmTX407B.LblPutMsg.Text = WrkCust & ": Records Puton=" & WrkPutOn & ", Previously Puton=" & WrkPrev
    MyFrmTX407B.ChkPost.Checked = False
  Else
    MyFrmTX407B.LblPutMsg.Text = "Records to Puton=" & WrkPutOn & ", Previously Puton=" & WrkPrev
  End If
End Sub
Public Sub FormatGrid()

  MyFrmTX407B.C1DataGrdList.DataSource = dsDetail.Tables(0)
  MyFrmTX407B.C1DataGrdList.Refresh()
  With MyFrmTX407B.C1DataGrdList
    .Rebind(True)
    .Columns(0).Caption = "Reg #"
    .Splits(0).DisplayColumns(0).Width = 70
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
    .Columns(8).ValueItems.Values.Clear()
    .Columns(8).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("Y", "Put On"))
    .Columns(8).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("P", "MV Paid"))
    .Columns(8).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("M", "Missing"))
    .Columns(8).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(" ", "To Put On"))
    .Columns(8).ValueItems.Translate = True
    .Columns(8).Caption = "MV Flag"
    .Splits(0).DisplayColumns(8).Width = 60
 End With

End Sub
End Module






