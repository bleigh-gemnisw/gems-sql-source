Module PrintShared

Public ds1 As DataSet = New DataSet
Public ds2 As DataSet = New DataSet
'Buffered Data
Public WrkCCRsnCode(50) As String
Public WrkCCRsnDesc(50) As String
  Public Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("CCNo", Type.GetType("System.Int32"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("ReasonDesc", Type.GetType("System.String"))
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("CDate", Type.GetType("System.DateTime"))
      .Columns.Add("UserID", Type.GetType("System.String"))
      .Columns.Add("OrigGross", Type.GetType("System.Int32"))
      .Columns.Add("NewGross", Type.GetType("System.Int32"))
      .Columns.Add("ChgGross", Type.GetType("System.Int32"))
      .Columns.Add("OrigEx", Type.GetType("System.Int32"))
      .Columns.Add("NewEx", Type.GetType("System.Int32"))
      .Columns.Add("ChgEx", Type.GetType("System.Int32"))
      .Columns.Add("OrigNet", Type.GetType("System.Int32"))
      .Columns.Add("NewNet", Type.GetType("System.Int32"))
      .Columns.Add("ChgNet", Type.GetType("System.Int32"))
      .Columns.Add("OrigDue", Type.GetType("System.Double"))
      .Columns.Add("NewDue", Type.GetType("System.Double"))
      .Columns.Add("ChgDue", Type.GetType("System.Double"))
    End With
    ds1.Tables.Add(myTable)

    With myTable2
      .TableName = "mytable2"
      .Columns.Add("tcount", Type.GetType("System.Int32"))
      .Columns.Add("year", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("tgrossincr", Type.GetType("System.Int32"))
      .Columns.Add("tgrossdecr", Type.GetType("System.Int32"))
      .Columns.Add("tgrossdiff", Type.GetType("System.Int32"))
      .Columns.Add("texincr", Type.GetType("System.Int32"))
      .Columns.Add("texdecr", Type.GetType("System.Int32"))
      .Columns.Add("texdiff", Type.GetType("System.Int32"))
      .Columns.Add("tnetincr", Type.GetType("System.Int32"))
      .Columns.Add("tnetdecr", Type.GetType("System.Int32"))
      .Columns.Add("tnetdiff", Type.GetType("System.Int32"))
      .Columns.Add("tdueincr", Type.GetType("System.Double"))
      .Columns.Add("tduedecr", Type.GetType("System.Double"))
      .Columns.Add("tduediff", Type.GetType("System.Double"))
    End With
    ds2.Tables.Add(myTable2)

  End Sub
 Public Sub CalcProrateCode(ByVal In_Type As String, ByVal In_SaleCode As String, _
		ByVal In_Value As Integer, ByRef Out_Prorate As Integer, ByRef Out_AdjNet As Integer, _
		ByRef Out_Pct As Single, ByRef Out_SaleMonth As Integer)

		Dim WrkTxMVPCT As String()

		WrkTxMVPCT = GetTXMVPCT(In_Type, In_SaleCode)
    Out_SaleMonth = MyUtils.CnvSng(WrkTxMVPCT(1))
    Out_Pct = MyUtils.CnvSng(WrkTxMVPCT(0))
    If MyProRateRound Then
      Out_AdjNet = MyUtils.Round10(In_Value * Out_Pct, "Normal")
    Else
      Out_AdjNet = MyUtils.Round(In_Value * Out_Pct, 0)
    End If
    Out_Prorate = In_Value - Out_AdjNet
  End Sub
Public Sub BufferCCReason()
     Dim I As Integer

     Dim myTXCRESN As TXCRESN.myData
     Dim dsTXCRESN As DataSet = New DataSet

     myTXCRESN = New TXCRESN.mydata(MyDBConnect)

     Array.Clear(WrkCCRsnCode, 0, 50)
     Array.Clear(WrkCCRsnDesc, 0, 50)

     dsTXCRESN = myTXCRESN.GetAllData
     For I = 0 To dsTXCRESN.Tables(0).Rows.Count - 1
      With dsTXCRESN.Tables(0).Rows(I)
        WrkCCRsnCode(I) = .Item("cresn")
        WrkCCRsnDesc(I) = .Item("crdesc")
      End With
    Next

End Sub
Public Function LookupCCReason(ByVal Code As String) As Integer
     Dim I As Integer

     For I = 0 To WrkCCRsnCode.GetUpperBound(0)
       If WrkCCRsnCode(I) = "" Then
         Return -1
       End If
       If Code = WrkCCRsnCode(I) Then
         Return I
       End If
    Next

End Function
End Module






