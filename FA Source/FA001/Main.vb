Module Main
  Public MyFrmFA001 As FrmFA001
	Public MyFrmFA001B As FrmFA001B
	Public MyFrmFA001C As FrmFA001C
	Public MyFrmComments As FrmComments
	Public MyFrmListAqumt As FrmListAqumt
	Public MyFrmListAstype As FrmListAsType
	Public MyFrmListBldg As FrmListBldg
	Public MyFrmListClass As FrmListClass
	Public MyFrmListDept As FrmListDept
	Public MyFrmListDspmt As FrmListDspmt
	Public MyFrmListEqup As FrmListEqup
	Public MyFrmListGLAcct As FrmListGLAcct
	Public MyFrmListUser1 As FrmListUser1
	Public MyFrmListUser2 As FrmListUser2
	Public MyFrmListUser3 As FrmListUser3
	Public MyFrmListVendor As FrmListVendor
  Public MyFrmSettings As FrmSettings
  Public MyAppSettings As AppSettings
Sub Main()
  StartUp()
  GetSecurity()  '#sec
  GetTown()
  GetAppSettings()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmFA001 = New FrmFA001
  Application.Run(MyFrmFA001)
End Sub
   Public Sub GetAppSettings()
  Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
  Dim sr As IO.StreamReader
  Dim WrkXMLPath As String
  Dim WrkProgName As String

  WrkProgName = Replace(MyUtils.GetProgramName, ".exe", "")
  WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & ".xml"
  If MyUtils.CheckFileExists(WrkXMLPath) Then
   sr = New IO.StreamReader(WrkXMLPath)
   MyAppSettings = New AppSettings
   MyAppSettings = CType(xs.Deserialize(sr), AppSettings)
   sr.Close()
  Else
   MyAppSettings = New AppSettings
  End If
 End Sub
Public Sub SaveAppSettings()
  Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
  Dim sw As IO.StreamWriter
  Dim WrkProgName As String
  Dim WrkXMLPath As String

  WrkProgName = Replace(MyUtils.GetProgramName, ".exe", "")
  WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & ".xml"
  sw = New IO.StreamWriter(WrkXMLPath)
  xs.Serialize(sw, MyAppSettings)
  sw.Close()
End Sub
Public Function GetFAAqumtDesc(ByVal Code As String) As String
     Dim myFAAQUMT As FAAQUMT.MyData

    myFAAQUMT = New FAAQUMT.MyData()
    myFAAQUMT.MyDBConn = myDBConnect
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myFAAQUMT.GetOneRecordP(Code)
     If Not myFAAQUMT.RecordNotFound Then
       GetFAAqumtDesc = Trim(myFAAQUMT._AQDESC)
     Else
       GetFAAqumtDesc = "*** Unknown ***"
     End If
     Return GetFAAqumtDesc

  End Function
	Public Function GetFAASTypeDesc(ByVal Code As String) As String
		 Dim myFAASTYPE As FAASTYPE.MyData

    myFAASTYPE = New FAASTYPE.MyData()
    myFAASTYPE.MyDBConn = myDBConnect
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myFAASTYPE.GetOneRecordP(Code)
		 If Not myFAASTYPE.RecordNotFound Then
			 GetFAASTypeDesc = Trim(myFAASTYPE._ASDESC)
		 Else
			 GetFAASTypeDesc = "*** Unknown ***"
		 End If
		 Return GetFAASTypeDesc

	End Function
	Public Function GetFAASTypeThreshold(ByVal Code As String) As Integer
		 Dim myFAASTYPE As FAASTYPE.MyData

    myFAASTYPE = New FAASTYPE.MyData()
    myFAASTYPE.MyDBConn = myDBConnect
    If IsNothing(Code) Or Code = "" Then
      Return 0
    End If

    myFAASTYPE.GetOneRecordP(Code)
		 If Not myFAASTYPE.RecordNotFound Then
			 GetFAASTypeThreshold = myFAASTYPE._ASTHLD
		 Else
			 GetFAASTypeThreshold = 0
		 End If
		 Return GetFAASTypeThreshold

	End Function
	Public Function GetFABldgDesc(ByVal Code As String) As String
		 Dim myFABLDG As FABLDG.MyData

    myFABLDG = New FABLDG.MyData()
    myFABLDG.MyDBConn = myDBConnect
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myFABLDG.GetOneRecordP(Code)
		 If Not myFABLDG.RecordNotFound Then
			 GetFABldgDesc = Trim(myFABLDG._BLDESC)
		 Else
			 GetFABldgDesc = "*** Unknown ***"
		 End If
		 Return GetFABldgDesc

	End Function
	Public Function GetFAClassDesc(ByVal Code As String) As String
		 Dim myFACLASS As FACLASS.MyData

    myFACLASS = New FACLASS.MyData()
    myFACLASS.MyDBConn = myDBConnect
    If IsNothing(Code) Or Code = "" Then
			 Return ""
		 End If

		 myFACLASS.GetOneRecordP(Code)
		 If Not myFACLASS.RecordNotFound Then
			 GetFAClassDesc = Trim(myFACLASS._CLDESC)
		 Else
			 GetFAClassDesc = "*** Unknown ***"
		 End If
		 Return GetFAClassDesc

	End Function
	Public Function GetFADeptDesc(ByVal Code As String) As String
		 Dim myFADEPT As FADEPT.MyData

    myFADEPT = New FADEPT.MyData()
    myFADEPT.MyDBConn = myDBConnect
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myFADEPT.GetOneRecordP(Code)
		 If Not myFADEPT.RecordNotFound Then
			 GetFADeptDesc = Trim(myFADEPT._DEDESC)
		 Else
			 GetFADeptDesc = "*** Unknown ***"
		 End If
		 Return GetFADeptDesc

	End Function
	Public Function GetFADspmtDesc(ByVal Code As String) As String
		 Dim myFADSPMT As FADSPMT.MyData

    myFADSPMT = New FADSPMT.MyData()
    myFADSPMT.MyDBConn = myDBConnect
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myFADSPMT.GetOneRecordP(Code)
		 If Not myFADSPMT.RecordNotFound Then
			 GetFADspmtDesc = Trim(myFADSPMT._DSDESC)
		 Else
			 GetFADspmtDesc = "*** Unknown ***"
		 End If
		 Return GetFADspmtDesc

	End Function
	Public Function GetFAEqupDesc(ByVal Code As String) As String
		 Dim myFAEQUP As FAEQUP.MyData

    myFAEQUP = New FAEQUP.MyData()
    myFAEQUP.MyDBConn = myDBConnect
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myFAEQUP.GetOneRecordP(Code)
		 If Not myFAEQUP.RecordNotFound Then
			 GetFAEqupDesc = Trim(myFAEQUP._EQDESC)
		 Else
			 GetFAEqupDesc = "*** Unknown ***"
		 End If
		 Return GetFAEqupDesc

	End Function
	Public Function GetFAUser1Desc(ByVal Code As String) As String
		 Dim myFAUSER1 As FAUSER1.MyData

    myFAUSER1 = New FAUSER1.MyData()
    myFAUSER1.MyDBConn = myDBConnect
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myFAUSER1.GetOneRecordP(Code)
		 If Not myFAUSER1.RecordNotFound Then
			 GetFAUser1Desc = Trim(myFAUSER1._U1DESC)
		 Else
			 GetFAUser1Desc = "*** Unknown ***"
		 End If
		 Return GetFAUser1Desc

	End Function
	Public Function GetFAUser2Desc(ByVal Code As String) As String
		 Dim myFAUSER2 As FAUSER2.MyData

    myFAUSER2 = New FAUSER2.MyData()
    myFAUSER2.MyDBConn = myDBConnect
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myFAUSER2.GetOneRecordP(Code)
		 If Not myFAUSER2.RecordNotFound Then
			 GetFAUser2Desc = Trim(myFAUSER2._U2DESC)
		 Else
			 GetFAUser2Desc = "*** Unknown ***"
		 End If
		 Return GetFAUser2Desc

	End Function
	Public Function GetFAUser3Desc(ByVal Code As String) As String
		 Dim myFAUSER3 As FAUSER3.MyData

    myFAUSER3 = New FAUSER3.MyData()
    myFAUSER3.MyDBConn = myDBConnect
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myFAUSER3.GetOneRecordP(Code)
		 If Not myFAUSER3.RecordNotFound Then
			 GetFAUser3Desc = Trim(myFAUSER3._U3DESC)
		 Else
			 GetFAUser3Desc = "*** Unknown ***"
		 End If
		 Return GetFAUser3Desc

	End Function
	Public Function GetGLACCTDesc(ByVal PFund As Integer, ByVal PSubFund As Integer, _
		ByVal PDept As Integer, ByVal PObject As Integer, ByVal PFunction As Integer, _
		ByVal PSubFunc As Integer) As String
		 Dim myGLACCT As GLACCT.MyData

    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
    If PFund = 0 Then
      Return ""
    End If

    myGLACCT.GetOneRecordP(PFund, PSubFund, PDept, PObject, PFunction, PSubFunc)
		 If Not myGLACCT.RecordNotFound Then
			 GetGLACCTDesc = Trim(myGLACCT._GLDSC)
		 Else
			 GetGLACCTDesc = "*** Unknown ***"
		 End If
		 Return GetGLACCTDesc

	End Function
	Public Function GetVendorName(ByVal Code As String) As String
		Dim myVENDOR As VENDOR.MyData

    myVENDOR = New VENDOR.MyData()
    myVENDOR.MyDBConn = myDBConnect
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myVENDOR.GetOneRecordP(Code)
		If Not myVENDOR.RecordNotFound Then
			GetVendorName = Trim(myVENDOR._VENNM)
		Else
			GetVendorName = "*** Unknown ***"
		End If
		Return GetVendorName

	End Function
End Module
