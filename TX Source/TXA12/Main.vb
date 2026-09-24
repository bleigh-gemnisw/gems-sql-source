'TXINV: Update BALD: PAYREC:
'TXHST: Add
Module Main
    Public MyFrmTXA12 As FrmTXA12
    Public MyFrmTXA12B As FrmTXA12B
    Public MyFrmTXA12C As FrmTXA12C
    Public MyFrmTXA12Fees As FrmTXA12Fees
    Public MyFrmListTypes As FrmListTypes
    Public MyCrViewer As FrmCrViewer
    Public MyMVFee As Decimal
   Sub Main()
    StartUp()
    GetSecurity()
    GetTXMVFee()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTXA12 = New FrmTXA12
    Application.Run(MyFrmTXA12)
   End Sub
  Public Function GetTXTypeDesc(ByVal Code As String) As String
     Dim myTXTYPE As TXTYPE.myData

     myTXTYPE = New TXTYPE.mydata(MyDBConnect)
     If IsNothing(Code) Then
       Return ""
     End If

     GetTXTypeDesc = ""
     myTXTYPE.GetOneRecordP(Code)
     If Not myTXTYPE.IsEOF Then
       GetTXTypeDesc = myTXTYPE._TYDESC
     Else
       GetTXTypeDesc = "*** Unknown ***"
     End If
     Return GetTXTypeDesc

  End Function
  Public Function GetTXTypeFamily(ByVal Code As String) As String
     Dim myTXTYPE As TXTYPE.myData

     myTXTYPE = New TXTYPE.mydata(MyDBConnect)
     If IsNothing(Code) Then
       Return ""
     End If

     GetTXTypeFamily = ""
     myTXTYPE.GetOneRecordP(Code)
     If Not myTXTYPE.IsEOF Then
       GetTXTypeFamily = myTXTYPE._TXFAM
     Else
       GetTXTypeFamily = ""
     End If
     Return GetTXTypeFamily

  End Function
 Private Sub GetTXMVFee()
  Dim myTXMVFEE As TXMVFEE.myData
  myTXMVFEE = New TXMVFEE.mydata(MyDBConnect)
  myTXMVFEE.GetOneRecordP(1)
  If Not myTXMVFEE.RecordNotFound Then
   MyMVFee = myTXMVFEE._MVFEE
  End If
  myTXMVFEE.CloseFile()
  myTXMVFEE = Nothing
 End Sub
End Module






