'TXINV: Update ADD1: ADD2: BKCD: BKSR: CCM: CITY: CHDATE: CHTIME: DIST:
'TXINV: Update ICODE: LETT: LIEN: LOC: LOCNO: NAME: OID: PHASE: PRF:
'TXINV: Update SNAME: STATE: STCD1: STCD2: STCD3: STCD4: STCD5: ZIP4: ZIP5:
'TXINV: Update SS#: SS2: 
'TXINV: Add
Module Main
  Public MyFrmListBanks As FrmListBanks
  Public MyFrmListBser As FrmListBser
  Public MyFrmTX405 As FrmTX405
  Public MyFrmTX405B As FrmTX405B
  Public MyFrmTX405C As FrmTX405C
  Public MyFrmTX405_NEW As FrmTX405_NEW
  Public MyFrmListCodes As FrmListCodes
  Public MyFrmListExemption As FrmListExemption
  Public MyFrmListHome As FrmListHome
  Public MyFrmListSupCd As FrmListSupCd
  Public MyFrmListTypes As FrmListTypes
  Public MyFrmListVcus As FrmListVcus
  Public MyFrmListVeh As FrmListVeh
  Public MyFrmSelStatus As FrmSelStatus
  Public MyFrmSelTypes As FrmSelTypes
  Public MyFrmSelYear As FrmSelYear
  Public MySelTypes As String
  Public MySelFromYear As Integer
  Public MySelToYear As Integer
  Public MyBlocking As Boolean
  Public MySts As String

  Sub Main()
    StartUp()
    GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTX405 = New FrmTX405
    Application.Run(MyFrmTX405)
  End Sub
  Public Function CalcProRate(ByVal Gross As Single, ByVal Pct As Single) As Single
    CalcProRate = Gross * Pct
    Return CalcProRate
  End Function
  Public Function GetTXBanksDesc(ByVal Code As String) As String
    Dim myTXBANKS As TXBANKS.MyData

    myTXBANKS = New TXBANKS.MyData(myDBConnect)
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myTXBANKS.GetOneRecordP(Code)
    If Not myTXBANKS.RecordNotFound Then
      GetTXBanksDesc = Trim(myTXBANKS._BKNAME)
    Else
      GetTXBanksDesc = "*** Unknown ***"
    End If
    Return GetTXBanksDesc

  End Function
  Public Function GetTXCodeDesc(ByVal Code As Integer, ByVal Type As String) As String
    Dim myTXCODE As TXCODE.MyData

    myTXCODE = New TXCODE.MyData(myDBConnect)
    If IsNothing(Code) Or Code = 0 Then
      Return ""
    End If

    myTXCODE.GetOneRecordP(Code, Type)
    If Not myTXCODE.RecordNotFound Then
      GetTXCodeDesc = Trim(myTXCODE._TCDESC)
    Else
      GetTXCodeDesc = "*** Unknown ***"
    End If
    Return GetTXCodeDesc

  End Function
  Public Function GetTXExem(ByVal Code As String) As String()
    Dim Wrkstr(1) As String
    Dim myTXEXEM As TXEXEM.MyData

    myTXEXEM = New TXEXEM.MyData(myDBConnect)
    If IsNothing(Code) Or Code = "" Then
      Wrkstr(0) = ""
      Wrkstr(1) = ""
      Return Wrkstr
    End If

    myTXEXEM.GetOneRecordP(Code)
    If Not myTXEXEM.RecordNotFound Then
      Wrkstr(0) = myTXEXEM._TFIXAM
      Wrkstr(1) = Trim(myTXEXEM._TDESC)
    Else
      Wrkstr(1) = "*** Unknown ***"
    End If
    Return Wrkstr

  End Function
  Public Function GetTXTypeDesc(ByVal Code As String) As String
    Dim myTXTYPE As TXTYPE.MyData

    myTXTYPE = New TXTYPE.MyData(myDBConnect)
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myTXTYPE.GetOneRecordP(Code)
    If Not myTXTYPE.RecordNotFound Then
      GetTXTypeDesc = Trim(myTXTYPE._TYDESC)
    Else
      GetTXTypeDesc = "*** Unknown ***"
    End If
    myTXTYPE.CloseFile()
    Return GetTXTypeDesc

  End Function
  Public Function GetTXTypeFamily(ByVal Code As String) As String
    Dim myTXTYPE As TXTYPE.MyData

    myTXTYPE = New TXTYPE.MyData(myDBConnect)
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myTXTYPE.GetOneRecordP(Code)
    If Not myTXTYPE.RecordNotFound Then
      GetTXTypeFamily = Trim(myTXTYPE._TXFAM)
    Else
      GetTXTypeFamily = "*** Unknown ***"
    End If
    myTXTYPE.CloseFile()
    Return GetTXTypeFamily

  End Function
  Public Function GetTXSResnDesc(ByVal Code As String) As String
    Dim myTXSRESN As TXSRESN.MyData

    myTXSRESN = New TXSRESN.MyData(myDBConnect)
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myTXSRESN.GetOneRecordP(Code)
    If Not myTXSRESN.RecordNotFound Then
      GetTXSResnDesc = Trim(myTXSRESN._SRDESC)
    Else
      GetTXSResnDesc = "*** Unknown ***"
    End If
    Return GetTXSResnDesc

  End Function
End Module






