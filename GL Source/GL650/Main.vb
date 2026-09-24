
Module Main
  Public MyFrmGL650 As FrmGL650
  Public MyFrmGL650B As FrmGL650B
  Public MyCrViewer As FrmCrViewer
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmGL650 = New FrmGL650
    Application.Run(MyFrmGL650)

   End Sub
  Public Function GetGLACCTDesc(ByVal PFund As Integer, ByVal PSubFund As Integer, _
    ByVal PDept As Integer, ByVal PObject As Integer, ByVal PFunction As Integer, _
    ByVal PSubFunc As Integer) As String
     Dim myGLACCT As GLACCT.myData

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
  Public Function GetGLDEPGroup(ByVal PDept As Integer) As Integer
		 Dim myGLDEP As GLDEP.myData

     myGLDEP = New GLDEP.MyData()
     myGLDEP.MyDBConn = myDBConnect
     If PDept = 0 Then
       Return 0
     End If

		 myGLDEP.GetOneRecordp(PDept)
		 If Not myGLDEP.RecordNotFound Then
			 GetGLDEPGroup = Trim(myGLDEP._DEGRP)
		 Else
			 GetGLDEPGroup = -1
		 End If
     Return GetGLDEPGroup
  End Function
  Public Function GetGLDEPGRPDesc(ByVal PCode As Integer) As String
		 Dim myGLDEPGRP As GLDEPGRP.myData

     myGLDEPGRP = New GLDEPGRP.MyData()
     myGLDEPGRP.MyDBConn = myDBConnect
		 myGLDEPGRP.GetOneRecordp(PCode)
		 If Not myGLDEPGRP.RecordNotFound Then
			 GetGLDEPGRPDesc = Trim(myGLDEPGRP._DESC)
		 Else
			 GetGLDEPGRPDesc = "*** Unknown ***"
		 End If
     Return GetGLDEPGRPDesc
  End Function
  Public Function GetGLDEPGRPExcTot(ByVal PCode As Integer) As Boolean
		 Dim myGLDEPGRP As GLDEPGRP.myData
		 Dim WrkExcTot As Boolean
    
     WrkExcTot = False
     myGLDEPGRP = New GLDEPGRP.MyData()
     myGLDEPGRP.MyDBConn = myDBConnect
     If PCode = 0 Then
       Return WrkExcTot
     End If

		 myGLDEPGRP.GetOneRecordp(PCode)
		 If Not myGLDEPGRP.RecordNotFound Then
				If myGLDEPGRP._EXCTOT = "Y" Then
					WrkExcTot = True
				End If
		 Else
			 WrkExcTot = False
		 End If
     Return WrkExcTot
  End Function
End Module
