Module Main
  Public MyFrmAP403 As FrmAP403
  Public MyFrmAP403B As FrmAP403B
  Public MyFrmAP403C As FrmAP403C
  Public MyFrmListApebnk As FrmListApebnk
  Public MyFrmListVendor As FrmListVendor
  Public MyCrViewer As FrmCrViewer
  Public MyPrtLayout As FrmPrtLayout
  Public MyCheckType As String
  Public MyCheckDetail As Boolean
  Public MyManualCheckNoSig As Boolean 'No Signature
  Public MyManualManCheck As Boolean 'Allow Manual Check
  Sub Main()
    StartUp()
    GetSecurity()
    MyCheckDetail = GetGNET("APCKD")
    MyManualCheckNoSig = GetGNET("APCKM")
    MyManualManCheck = GetGNET("APMCK")

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmAP403 = New FrmAP403
    Application.Run(MyFrmAP403)
  End Sub
  Public Function CalcModulus10(ByVal sNumber As String) As Integer
    'Modulus 10 Check Digit
    Dim tmpTotal As Integer
    Dim i As Integer, f As Byte, tmpStr As String
    For i = 1 To Len(sNumber)
      f = f + 1
      If f = 2 Then
        tmpStr = CInt(Mid$(sNumber, i, 1)) * 2
        If Len(tmpStr) > 1 Then
          tmpTotal = tmpTotal + CInt(Mid$(tmpStr, 1, 1)) + CInt(Mid$(tmpStr, 2, 1))
        Else
          tmpTotal = tmpTotal + CInt(tmpStr)
        End If
        tmpStr = ""
        f = 0
      Else
        tmpTotal = tmpTotal + CInt(Mid$(sNumber, i, 1))
      End If
    Next i
    If Right$(CStr(tmpTotal), 1) = "0" Then
      tmpTotal = 0
    Else
      tmpTotal = ((tmpTotal + 10) - CInt(Right$(CStr(tmpTotal),
  1))) - tmpTotal
    End If
    CalcModulus10 = tmpTotal
  End Function
  Public Function GetAPEBNKName(ByVal Code As String) As String
    Dim myAPEBNK As APEBNK.MyData

    myAPEBNK = New APEBNK.MyData()
    myAPEBNK.MyDBConn = myDBConnect
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myAPEBNK.GetOneRecordP(Code)
    If Not myAPEBNK.RecordNotFound Then
      GetAPEBNKName = Trim(myAPEBNK._BNKNM)
    Else
      GetAPEBNKName = "*** Unknown ***"
    End If
    Return GetAPEBNKName

  End Function
  Public Function GetGNET(ByVal Code As String) As Boolean
    Dim myGNET As GNET.MyData

    myGNET = New GNET.MyData()
    myGNET.MyDBConn = myDBConnect
    If IsNothing(Code) Or Code = "" Then
      Return False
    End If

    myGNET.GetOneRecordP(Code)
    If Not myGNET.RecordNotFound Then
      If myGNET._VALUE = "Y" Then
        GetGNET = True
      End If
    Else
      GetGNET = False
    End If
    myGNET.CloseFile()
    myGNET = Nothing
    Return GetGNET

  End Function
End Module
