Module PostGL
  Dim myTXBATCHL1 As TXBATCHL1.MyData
  Dim myNETGLBCH As NETGLBCH.myData

	Dim dsTXBATCH As DataSet = New DataSet
Public Sub PstGL()

	Dim I As Integer

    myTXBATCHL1 = New TXBATCHL1.MyData(myDBConnect)
    myNETGLBCH = New NETGLBCH.MyData()
    myNETGLBCH.MyDBConn = myDBConnect
    If Not MyTXGL Then GoTo Cleanup

    dsTXBATCH = myTXBATCHL1.GetViewByBatch(MyBatch, MyBatchNo, 9999)
    If dsTXBATCH.Tables(0).Rows.Count = 0 Then GoTo Cleanup

    For I = 0 To (dsTXBATCH.Tables(0).Rows.Count - 1)
      With dsTXBATCH.Tables(0).Rows(I)
        If .Item("jstat") = "V" Then GoTo NextRec
        myNETGLBCH.GetOneRecordP(MyBatchNo, I + 1)
        myNETGLBCH._BATCH = MyBatchNo
        myNETGLBCH._SEQNO = I + 1
        myNETGLBCH._STAT = .Item("jstat")
        myNETGLBCH._LIST = .Item("list#")
        myNETGLBCH._YEAR = .Item("year")
        myNETGLBCH._TYPE = .Item("type")
        myNETGLBCH._PAMT = .Item("pamt")
        myNETGLBCH._IAMT = .Item("iamt")
        myNETGLBCH._LAMT = .Item("lamt")
        myNETGLBCH._PCAMT = .Item("tcamt")
        myNETGLBCH._DIST = .Item("dist")
        'North Branford - C & U post as dist 201
        If myTOWN._TOWNBR = 99 Then
          If .Item("type") = "C" Or .Item("type") = "U" Then
            myNETGLBCH._DIST = 201
          End If
        End If
        myNETGLBCH._ADJCD = .Item("adjcd")
        myNETGLBCH._PENCD = .Item("cpencd")
        myNETGLBCH._PSTDT = MyUtils.SetDBDate(Date.Now.Date)
        myNETGLBCH._PAYDT = MyUtils.SetDBDate(MyReceiptDate)
        myNETGLBCH.AddOneRecordP()
        If myNETGLBCH.ErrMsg <> "" Then
          WriteErrorLog(myNETGLBCH.ErrMsg)
          Exit Sub
        End If
      End With
NextRec:
    Next

    dsTXBATCH.Clear()
	dsTXBATCH = Nothing

Cleanup:
    'Memory Cleanup
    myTXBATCHL1.CloseFile()
    myNETGLBCH.CloseFile()
    myTXBATCHL1 = Nothing
    myNETGLBCH = Nothing
End Sub
End Module






