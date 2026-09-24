
Module Main
  Public MyFrmListBanks As FrmListBanks
  Public MyFrmListReal As FrmListReal
  Public MyFrmTX311 As FrmTAE01
  Public MyFrmTX311B As FrmTX311B
  Public MyFrmTX311C As FrmTX311C
  Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTX311 = New FrmTAE01
    Application.Run(MyFrmTX311)
   End Sub
  Public Sub GetAddr(ByVal ListNo As Integer, ByVal Frozen As Boolean)
     Dim myTXREAL As TXReal.myData
     Dim myTXREALC As TXREALC.myData

     If ListNo = 0 Then Exit Sub

     If Frozen Then
       myTXREALC = New TXREALC.mydata(MyDBConnect)
       myTXREALC.GetOneRecordP(ListNo)
       If Not myTXREALC.RecordNotFound Then
         With MyFrmTX311C
          If MyUtils.CnvSng(.TxtReListNo.Text) = 0 Then
            .TxtReListNo.Text = .TxtListNo.Text
          End If
          .TxtName.Text = Trim(myTXREALC._NAME)
          .TxtSname.Text = Trim(myTXREALC._SNAME)
          .TxtAdd1.Text = Trim(myTXREALC._ADD1)
          .TxtAdd2.Text = Trim(myTXREALC._ADD2)
          .TxtCity.Text = Trim(myTXREALC._CITY)
          .TxtState.Text = Trim(myTXREALC._STATE)
          .TxtZip5.Text = Format(myTXREALC._ZIP5, "00000")
          If myTXREALC._ZIP4 > 0 Then
            .TxtZip4.Text = Format(myTXREALC._ZIP4, "0000")
          End If
         .TxtLocNo.Text = Trim(myTXREALC._LOCNO)
         .TxtLoc.Text = Trim(myTXREALC._LOC)
         End With
       End If
     Else
       myTXREAL = New TXReal.mydata(MyDBConnect)
       myTXREAL.GetOneRecordP(ListNo)
       If Not myTXREAL.RecordNotFound Then
         With MyFrmTX311C
          If MyUtils.CnvSng(.TxtReListNo.Text) = 0 Then
            .TxtReListNo.Text = .TxtListNo.Text
          End If
          .TxtName.Text = Trim(myTXREAL._NAME)
          .TxtSname.Text = Trim(myTXREAL._SNAME)
          .TxtAdd1.Text = Trim(myTXREAL._ADD1)
          .TxtAdd2.Text = Trim(myTXREAL._ADD2)
          .TxtCity.Text = Trim(myTXREAL._CITY)
          .TxtState.Text = Trim(myTXREAL._STATE)
          .TxtZip5.Text = Format(myTXREAL._ZIP5, "00000")
          If myTXREAL._ZIP4 > 0 Then
            .TxtZip4.Text = Format(myTXREAL._ZIP4, "0000")
          End If
         .TxtLocNo.Text = Trim(myTXREAL._LOCNO)
         .TxtLoc.Text = Trim(myTXREAL._LOC)
         End With
       End If
     End If
  End Sub
End Module






