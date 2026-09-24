
Module Main
  Public MyFrmTA202 As FrmTA202
  Public MyFrmTA202B As FrmTA202B
  Public MyFrmTA202C As FrmTA202C
  Public MyFrmTA202D As FrmTA202D
  Public MyFrmTA202E As FrmTA202E
  Public MyFrmListLocalCodes As FrmListLocalCodes
  Public MillRateYear As Integer
  Public GLYear As Integer
  Public MyLocEld As String
  Sub Main()
    StartUp()
    GetSecurity()
    MyLocEld = ""
    If GetGNET("LECOV") = "Y" Then
      MyLocEld = "032"
    End If
    If GetGNET("LEEL") = "Y" Then
      MyLocEld = "045"
    End If
    If GetGNET("LEFRM") = "Y" Then
      MyLocEld = "084"
    End If

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA202 = New FrmTA202
    Application.Run(MyFrmTA202)
  End Sub
  Public Function GetTXLocCdDesc(ByVal Code As String) As String
    Dim myTXLOCCD As TXLOCCD.myData

    myTXLOCCD = New TXLOCCD.mydata(MyDBConnect)
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myTXLOCCD.GetOneRecordP(Code)
    If Not myTXLOCCD.RecordNotFound Then
      GetTXLocCdDesc = Trim(myTXLOCCD._BNDSC)
    Else
      GetTXLocCdDesc = "*** Unknown ***"
    End If
    Return GetTXLocCdDesc

  End Function
Public Function GetMRateLast(ByVal Dist As Integer) As Decimal
  Dim myTXMRATL1 As TXMRATL1.myData
  Dim ds As DataSet = New DataSet

  myTXMRATL1 = New TXMRATL1.mydata(MyDBConnect)
  ds = myTXMRATL1.PosHighYear(Dist, "R")
  If ds.Tables(0).Rows.Count = 0 Then
    ds = myTXMRATL1.PosHighYear(Dist, "")
  End If

    If ds.Tables(0).Rows.Count > 0 Then
      GetMRateLast = ds.Tables(0).Rows(0).Item("mrrate")
      MillRateYear = ds.Tables(0).Rows(0).Item("year")
    Else
      GetMRateLast = 0
      MillRateYear = 0
      MsgBox("Missing Mill Rate for District" & Dist, MsgBoxStyle.Exclamation, "No Mill Rate")
    End If
  End Function
  Public Function GetMRate(ByVal Year As Integer, ByVal Dist As Integer) As Decimal
  Dim myTXMRATE As TXMRATE.myData

  myTXMRATE = New TXMRATE.mydata(MyDBConnect)
  myTXMRATE.GetOneRecordP(Year, "R", Dist)
  If myTXMRATE.RecordNotFound Then
    myTXMRATE.GetOneRecordP(Year, "", Dist)
  End If

  GetMRate = 0
  If Not myTXMRATE.RecordNotFound Then
    GetMRate = myTXMRATE._MRRATE
  End If
End Function
Public Function GetTXCDAGCode(ByVal Seq As Integer) As Integer
     Dim myTXCDAG As TXCDAG.myData

     myTXCDAG = New TXCDAG.mydata(MyDBConnect)
     If Seq = 0 Then
       Return 0
     End If

     myTXCDAG.GetOneRecordP(Seq)
     If Not myTXCDAG.RecordNotFound Then
       GetTXCDAGCode = myTXCDAG._TCCODE
     Else
       GetTXCDAGCode = 0
     End If
     Return GetTXCDAGCode

  End Function
  Private Function GetGNET(ByVal Key As String) As String
    Dim myGNET As GNET.myData

    myGNET = New GNET.MyData()
    myGNET.MyDBConn = myDBConnect
    myGNET.GetOneRecordP(Key)
    With myGNET
      If .RecordNotFound Then Return String.Empty
      Return ._VALUE
    End With

  End Function
End Module






