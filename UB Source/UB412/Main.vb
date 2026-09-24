Module Main
    Public MyFrmUB412 As FrmUB412
    Public MyFrmUB412B As FrmUB412B
    Public MyFrmListDist As FrmListDist
    Public MyFrmListUBType As FrmListUBType
    Public MyCrViewer As FrmCrViewer
    Public MyTypes As String
    Public WrkProfDist(50) As Integer
		Public WrkProfPhase(50) As Integer
		Public WrkProfDue1(50) As Integer
    Public WrkProfDue2(50) As Integer
    Public MyPayoffBondDay As Boolean
	 Sub Main()
    StartUp()
    GetSecurity()
    If GetGNET("412DY") = "Y" Then MyPayoffBondDay = True

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

		MyFrmUB412 = New FrmUB412
		Application.Run(MyFrmUB412)
	 End Sub
  Public Function GetUTTypeDesc(ByVal Code As String) As String
     Dim myUTTYPE As UTTYPE.myData

     myUTTYPE = New UTTYPE.mydata(MyDBConnect)
     If IsNothing(Code) Or Code = "" Then
       Return ""
     End If

     myUTTYPE.GetOneRecordP(Code)
     If Not myUTTYPE.RecordNotFound Then
       GetUTTypeDesc = Trim(myUTTYPE._TYDESC)
     Else
       GetUTTypeDesc = "*** Unknown ***"
     End If
     Return GetUTTypeDesc

  End Function
	Public Function GetUTTYPEFamily(ByVal Code As String) As String
		 Dim myUTTYPE As UTTYPE.myData

		 myUTTYPE = New UTTYPE.mydata(MyDBConnect)
		 If IsNothing(Code) Or Code = "" Then
			 Return ""
		 End If

		 myUTTYPE.GetOneRecordP(Code)
		 If Not myUTTYPE.RecordNotFound Then
			 GetUTTYPEFamily = Trim(myUTTYPE._TYUTTP)
		 Else
			 GetUTTYPEFamily = ""
		 End If
		 Return GetUTTYPEFamily

	End Function
	Public Function GetUTTYPETaxType(ByVal Code As String) As String
		 Dim myUTTYPE As UTTYPE.myData

		 myUTTYPE = New UTTYPE.mydata(MyDBConnect)
		 If IsNothing(Code) Or Code = "" Then
			 Return ""
		 End If

		 myUTTYPE.GetOneRecordP(Code)
		 If Not myUTTYPE.RecordNotFound Then
			 GetUTTYPETaxType = Trim(myUTTYPE._TYTXTP)
		 Else
			 GetUTTYPETaxType = ""
		 End If
		 Return GetUTTYPETaxType

	End Function
Public Sub BufferTXPROF(ByVal Type As String, ByVal Year As Integer)
		 Dim I As Integer

		 Dim myTXPROF As TXPROF.myData
		 Dim dsTXPROF As DataSet = New DataSet

		 Array.Clear(WrkProfDist, 0, 50)
		 Array.Clear(WrkProfPhase, 0, 50)
		 Array.Clear(WrkProfDue1, 0, 50)
		 Array.Clear(WrkProfDue2, 0, 50)

		 myTXPROF = New TXPROF.mydata(MyDBConnect)
		 dsTXPROF = myTXPROF.GetbyTypeYear(Type, Year)
		 For I = 0 To dsTXPROF.Tables(0).Rows.Count - 1
			With dsTXPROF.Tables(0).Rows(I)
				WrkProfDist(I) = .Item("dist")
        WrkProfPhase(I) = MyUtils.CnvSng(.Item("phs"))
				WrkProfDue1(I) = .Item("prdue1")
				WrkProfDue2(I) = .Item("prdue2")
			End With
		Next

End Sub
Public Function LookupProf(ByVal Dist As Integer, ByVal Phase As Integer) As Integer
		 Dim I As Integer

		 For I = 0 To WrkProfDue1.GetUpperBound(0)
			 If WrkProfDue1(I) = 0 Then
				 Return -1
			 End If
			 If Dist = WrkProfDist(I) And Phase = WrkProfPhase(I) Then
				 Return I
			 End If
		Next

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






