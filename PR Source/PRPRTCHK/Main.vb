Module Main
    Public mydsErn As DataSet = New DataSet
    Public mydsDed As DataSet = New DataSet
    Public MyFrmPRPRTCHK As FrmPRPRTCHK
    Public MyFrmPRPRTCHKB As FrmPRPRTCHKB
    Public MyFrmPRPRTCHKC As FrmPRPRTCHKC
    Public MyFrmListApebnk As FrmListApebnk
    Public MyCrViewer As FrmCrViewer
    Public MyPrtLayout As FrmPrtLayout
    Public MyCheckType As String
    Public MyManualCheckNoSig As Boolean
   Sub Main()
    StartUp()
    GetSecurity()
    MyManualCheckNoSig = GetGNET("APCKM")

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmPRPRTCHK = New FrmPRPRTCHK
    Application.Run(MyFrmPRPRTCHK)
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
    tmpTotal = ((tmpTotal + 10) - CInt(Right$(CStr(tmpTotal), _
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
