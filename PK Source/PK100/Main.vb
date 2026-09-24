Module Main
  Public MyFrmPK100 As FrmPK100
  Public MyFrmPK100B As FrmPK100B
  Public MyFrmPK100C As FrmPK100C
  Public MyFrmListOfcr As FrmListOfcr
  Public MyFrmListViol As FrmListViol
Sub Main()
  StartUp()
  GetSecurity()  '#sec
  GetTown()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmPK100 = New FrmPK100
  Application.Run(MyFrmPK100)
End Sub
  Public Function GetOffcName(ByVal Code As String) As String
     Dim myPKOFCR As PKOFCR.MyData

    myPKOFCR = New PKOFCR.MyData(myDBConnect)
    If IsNothing(Code) Or Code = "" Then
       Return ""
     End If

     myPKOFCR.GetOneRecordP(Code)
     If Not myPKOFCR.RecordNotFound Then
       GetOffcName = Trim(myPKOFCR._OFNAM)
     Else
       GetOffcName = "*** Unknown ***"
     End If
     Return GetOffcName

  End Function
  Public Function GetViolDesc(ByVal Code As Integer) As String
     Dim myPKVIOL As PKVIOL.MyData

    myPKVIOL = New PKVIOL.MyData(myDBConnect)
    If IsNothing(Code) Or Code = 0 Then
       Return ""
     End If

     myPKVIOL.GetOneRecordP(Code)
     If Not myPKVIOL.RecordNotFound Then
       GetViolDesc = Trim(myPKVIOL._DESCR)
     Else
       GetViolDesc = "*** Unknown ***"
     End If
     Return GetViolDesc

  End Function
  Public Function GetViolAmt(ByVal Code As Integer) As Decimal
     Dim myPKVIOL As PKVIOL.MyData

    myPKVIOL = New PKVIOL.MyData(myDBConnect)
    If IsNothing(Code) Or Code = 0 Then
       Return 0
     End If

     myPKVIOL.GetOneRecordP(Code)
     If Not myPKVIOL.RecordNotFound Then
       GetViolAmt = myPKVIOL._AMOUNT
     End If
     Return GetViolAmt

  End Function
End Module
