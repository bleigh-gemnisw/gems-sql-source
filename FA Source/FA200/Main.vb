Module Main
    Public MyFrmFA200 As FrmFA200
    Public MyFrmFA200B As FrmFA200B
    Public MyFrmListAsType As FrmListAsType
    Public MyFrmListBldg As FrmListBldg
    Public MyFrmListClass As FrmListclass
    Public MyFrmListDept As FrmListDept
    Public MyFrmListEqup As FrmListEqup
    Public MyFrmListUser1 As FrmListUser1
    Public MyFrmListUser2 As FrmListUser2
    Public MyFrmListUser3 As FrmListUser3
    Public MyCrViewer As FrmCrViewer
    Public DataPath As String
   Sub main()
    StartUp()
    GetSecurity()
    GetTown()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmFA200 = New FrmFA200
    Application.Run(MyFrmFA200)
   End Sub
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
End Module
