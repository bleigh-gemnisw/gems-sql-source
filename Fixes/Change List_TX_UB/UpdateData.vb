Imports System.Text
Module UpdateData
  Dim MyTXINV As TXINV.MyData
  Dim MyTXHST As TXHST.MyData
  Dim MyUTCUST As UTCUST.MyData
  Dim MyUTCUSTRT As UTCUSTRT.MyData
  Dim MyUTCUSTMT As UTCUSTMT.MyData
  Dim MyUTXREF As UTXREF.MyData
  Public Sub Impdata()

    Dim Good As Boolean

    MyDBName = MyFrmFixB.TxtDBName.Text
    Good = Connect()

    If Not Good Then Exit Sub
    MyTXHST = New TXHST.MyData(myDBConnect)
    MyTXINV = New TXINV.MyData(myDBConnect)
    MyUTCUST = New UTCUST.MyData(myDBConnect)
    MyUTCUSTRT = New UTCUSTRT.MyData(myDBConnect)
    MyUTCUSTMT = New UTCUSTMT.MyData(myDBConnect)
    MyUTXREF = New UTXREF.MyData(myDBConnect)

    GetDetail()
  End Sub
  Public Function Connect() As Boolean
    Dim Good As Boolean

    myDBConnect = New SQLConnect.DBConnection(MyDBName)
    myDBConnect.Open()
    Good = myDBConnect.IsConnected
    If Not Good Then
      MsgBox("Invalid database name", MsgBoxStyle.Critical, "Check database name")
    End If
    Return Good
  End Function
  Private Sub GetDetail()
    Dim ds As DataSet = New DataSet
    Dim WrkType As String
    Dim WrkFromList As Integer
    Dim WrkToList As Integer
    Dim WrkUpdate As Boolean

    MyFrmFixB.LblMsg.Text = ""
    With MyFrmFixB
      WrkType = .TxtType.Text
      WrkFromList = .TxtFromList.Text
      WrkToList = .TxtToList.Text
      WrkUpdate = .ChkUpdate.Checked
    End With

    ds = MyTXINV.GetAllListNoType(WrkFromList, WrkType)
    If ds.Tables(0).Rows.Count = 0 Then
      MsgBox("Old List not found in TXINV", MsgBoxStyle.Critical, "")
      Exit Sub
    End If

    ds = MyTXINV.GetAllListNoType(WrkToList, WrkType)
    If ds.Tables(0).Rows.Count > 0 Then
      MsgBox("List already in TXINV", MsgBoxStyle.Critical, "")
      Exit Sub
    End If

    MyUTCUST.GetOneRecordP(WrkFromList)
    If MyUTCUST.RecordNotFound Then
      MsgBox("Old List already in UTCUST", MsgBoxStyle.Critical, "")
      Exit Sub
    End If

    MyUTCUST.GetOneRecordP(WrkToList)
    If Not MyUTCUST.RecordNotFound Then
      MsgBox("List already in UTCUST", MsgBoxStyle.Critical, "")
      Exit Sub
    End If

    If WrkUpdate Then
      MyTXINV.RunUpdateQuery("set list#=" & WrkToList, "where list#=" & WrkFromList & " and type='" & WrkType & "'")
      MyTXHST.RunUpdateQuery("set list#=" & WrkToList, "where list#=" & WrkFromList & " and type='" & WrkType & "'")
      MyUTCUST.RunUpdateQuery("set cuacct=" & WrkToList, "where cuacct=" & WrkFromList)
      MyUTCUSTRT.RunUpdateQuery("set cracct=" & WrkToList, "where cracct=" & WrkFromList)
      MyUTCUSTMT.RunUpdateQuery("set cmacct=" & WrkToList, "where cmacct=" & WrkFromList)
      MyUTXREF.RunUpdateQuery("set cxacct=" & WrkToList, "where cxacct=" & WrkFromList)
      MyFrmFixB.LblMsg.Text = "list changed from " & WrkFromList & " to " & WrkToList
      MyFrmFixB.TxtFromList.Text = ""
      MyFrmFixB.TxtToList.Text = ""
      MyFrmFixB.ChkUpdate.Checked = False
    End If

  End Sub
End Module
