Imports System.io
Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXMVDCL2 As TXMVDCL2.myData
Dim myTXMVDC As TXMVDC.myData
Dim myTXVCLS As TXVCLS.myData

Dim ds As DataSet = New DataSet
Dim dr As DataRow
Dim WrkCountName As Integer
Dim WrkCountAddr As Integer
Dim WrkCountMatch As Integer
Dim WrkCountNoMatch As Integer
Dim WrkCountNamesDiff As Integer
Dim WrkCountNoZip As Integer
Dim WrkPeople As Boolean
Dim WrkBusiness As Boolean
Dim WrkAddr As Boolean
Dim WrkPost As Boolean
  Public Sub PrtReport()
	myTXMVDCL2 = New TXMVDCL2.mydata(MyDBConnect)
	myTXMVDC = New TXMVDC.mydata(MyDBConnect)
  myTXVCLS = New TXVCLS.mydata(MyDBConnect)

  With MyFrmTX412B
    WrkPeople = .ChkPeople.Checked
    WrkBusiness = .ChkBusiness.Checked
    WrkAddr = .RbAddr.Checked
    WrkPost = .ChkPost.Checked
  End With

  If ds.Tables.Count = 0 Then
    BuildDs(ds)
  Else
    ds.Clear()
  End If

  If WrkAddr Then
    GetDetailAddr()
  Else
    GetDetailName()
  End If

Done:
  MyCrViewer = New FrmCrViewer
  With MyCrViewer
    .Wrkds = ds
    .WrkCountName = WrkCountName
    .WrkCountAddr = WrkCountAddr
    .WrkCountMatch = WrkCountMatch
    .WrkCountNoMatch = WrkCountNoMatch
    .WrkCountNamesDiff = WrkCountNamesDiff
    .WrkCountNoZip = WrkCountNoZip
    .WrkPost = WrkPost
    .Show()
  End With

  End Sub
Public Sub BuildDs(ByRef Ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Class", Type.GetType("System.Int32"))
      .Columns.Add("Regno", Type.GetType("System.String"))
      .Columns.Add("Town", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("OAddrCityST", Type.GetType("System.String"))
      .Columns.Add("NAddrCityST", Type.GetType("System.String"))
      .Columns.Add("ChgDesc", Type.GetType("System.String"))
      .Columns.Add("MVDList", Type.GetType("System.Int32"))
      .Columns.Add("MVDName", Type.GetType("System.String"))
      .Columns.Add("ErrorMsg", Type.GetType("System.String"))
      .Columns.Add("Custid", Type.GetType("System.Int32"))     'added 05/29/26   Ken
    End With
  Ds.Tables.Add(myTable)
End Sub
  Private Sub GetDetailAddr()
    Dim WrkStream As FileStream = New FileStream(MyFrmTX412B.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim sArray As String()
    Dim WrkFileSize As Integer
    Dim I As Integer
    Dim WrkClass As Integer
    Dim WrkRegno As String
    Dim SaveRegno As String
    Dim WrkTown As Integer
    Dim WrkNName As String
    Dim WrkNAddr As String
    Dim WrkNAddr2 As String
    Dim WrkNCity As String
    Dim WrkNState As String
    Dim WrkNZip5 As String
    Dim WrkNZip4 As String
    Dim WrkChgDesc As String
    Dim WrkOName As String
    Dim WrkOAddr As String
    Dim WrkOAddr2 As String
    Dim WrkOCity As String
    Dim WrkOState As String
    Dim WrkOZip5 As String
    Dim WrkOZip4 As String
    Dim WrkMVDList As Integer
    Dim WrkMVDName As String
    Dim WrkRecNo As Integer
    Dim WrkIsName As Boolean
    Dim WrkErrorMsg As String
    Dim WrkCustomerNumber As Integer               'added 5/21/26 ken

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    WrkCountName = 0
    WrkCountAddr = 0
    WrkCountMatch = 0
    WrkCountNoMatch = 0
    WrkCountNamesDiff = 0
    WrkCountNoZip = 0
    strBuffer = sr.ReadLine 'Skip Headings
    SaveRegno = String.Empty

NextLine:
    strBuffer = sr.ReadLine
    If strBuffer Is Nothing Then
      GoTo End_of_file
      Exit Sub
    End If

    sArray = Parse(strBuffer, ",")
    WrkCustomerNumber = 0                           'added 5/21/26 ken                                        
    WrkCustomerNumber = MyUtils.CnvSng(sArray(0))  'added 5/21/26 ken

    WrkRecNo = WrkRecNo + 1
    I = I + strBuffer.Length

    'If WrkPeople And Not WrkBusiness And Trim(sArray(0)) = String.Empty Then         added 5/21/26 ken
    If WrkPeople And Not WrkBusiness And Trim(sArray(4)) = String.Empty Then
      GoTo NextRec
    End If

    'If WrkBusiness And Not WrkPeople And Trim(sArray(3)) = String.Empty Then         added 5/21/26 ken
    If WrkBusiness And Not WrkPeople And Trim(sArray(7)) = String.Empty Then
      GoTo NextRec
    End If

    'WrkClass = GetTXVCLSCode(sArray(6))          added 5/21/26 ken
    WrkClass = GetTXVCLSCode(sArray(3))

    'WrkRegno = sArray(5)                         added 5/21/26 ken
    WrkRegno = sArray(2)

    If SaveRegno = WrkRegno Then GoTo NextRec
    SaveRegno = WrkRegno

    'WrkTown = MyUtils.CnvSng(sArray(4))          added 5/21/26 ken
    WrkTown = MyUtils.CnvSng(sArray(1))

    WrkOName = String.Empty
    WrkOAddr = String.Empty
    WrkOAddr2 = String.Empty
    WrkOCity = String.Empty
    WrkOState = String.Empty
    WrkOZip5 = String.Empty
    WrkOZip4 = String.Empty

    myTXMVDCL2.GetOneRecordP(WrkClass, WrkRegno)

    If Not myTXMVDCL2.RecordNotFound Then
      With myTXMVDCL2
        WrkOName = Trim(._NAME)
        WrkOAddr = Trim(._ADD1)
        WrkOAddr2 = Trim(._ADD2)
        WrkOCity = Trim(._CITY)
        WrkOState = Trim(._STATE)
        WrkOZip5 = Format(._ZIP5, "00000")
        If ._ZIP4 > 0 Then
          WrkOZip4 = Format(._ZIP4, "0000")
        End If
      End With
    End If

    WrkNName = String.Empty

    'If sArray(3) <> String.Empty Then            added 5/21/26 ken
    '  WrkNName = sArray(3)                       added 5/21/26 ken
    If sArray(7) <> String.Empty Then
      WrkNName = sArray(7)
    Else

      'WrkNName = sArray(0)                       added 5/21/26 ken
      WrkNName = sArray(4)

      'If sArray(1) <> String.Empty Then          added 5/21/26 ken
      '  WrkNName = WrkNName & " " & sArray(1)    added 5/21/26 ken
      If sArray(5) <> String.Empty Then
        WrkNName = WrkNName & " " & sArray(5)
      End If

      'If sArray(2) <> String.Empty Then          added 5/21/26 ken
      '  WrkNName = WrkNName & " " & sArray(2)    added 5/21/26 ken
      If sArray(6) <> String.Empty Then
        WrkNName = WrkNName & " " & sArray(6)
      End If

    End If

    'WrkNAddr = sArray(12)                        added 5/21/26 ken
    WrkNAddr = sArray(13)

    'WrkNAddr2 = sArray(13)                       added 5/21/26 ken
    WrkNAddr2 = sArray(14)

    'WrkNCity = sArray(14)                        added 5/21/26 ken
    WrkNCity = sArray(15)

    'WrkNState = sArray(15)                       added 5/21/26 ken
    WrkNState = sArray(16)

    'WrkNZip5 = Mid(sArray(16), 1, 5)             added 5/21/26 ken
    WrkNZip5 = Mid(sArray(17), 1, 5)

    'If Len(sArray(16)) > 5 Then                  added 5/21/26 ken
    If Len(sArray(17)) > 5 Then

      'WrkNZip4 = Mid(sArray(16), 6, 4)           added 5/21/26 ken
      WrkNZip4 = Mid(sArray(17), 7, 4)
    Else
      WrkNZip4 = ""
    End If

    If Trim(WrkOAddr) = WrkNAddr And WrkOCity = WrkNCity And WrkOZip5 = WrkNZip5 And WrkOZip4 = WrkNZip4 Then
      WrkIsName = True
      WrkChgDesc = "NAME"
      '    WrkCountName = WrkCountName + 1
    Else
      WrkIsName = False
      WrkChgDesc = "ADDRESS"
      WrkCountAddr = WrkCountAddr + 1
    End If

    WrkMVDList = 0
    WrkMVDName = ""
    WrkErrorMsg = ""

    If WrkIsName Then
      GoTo NextRec
    End If

    If Not myTXMVDCL2.RecordNotFound Then
      With myTXMVDCL2
        WrkMVDList = ._LISTNO
        WrkMVDName = Trim(._NAME)
        WrkCountMatch = WrkCountMatch + 1
      End With
    Else
      WrkErrorMsg = "*** Record not found ***"
      WrkCountNoMatch = WrkCountNoMatch + 1
    End If

    dr = ds.Tables(0).NewRow
    dr.Item("class") = WrkClass
    dr.Item("regno") = WrkRegno
    dr.Item("town") = WrkTown
    dr.Item("name") = WrkOName

    If WrkMVDList > 0 Then
      If Trim(WrkOName) <> WrkMVDName Then
        WrkCountNamesDiff = WrkCountNamesDiff + 1
        WrkErrorMsg = "*** Names are different ***"
      Else
        WrkMVDName = String.Empty
      End If
    End If

    If WrkIsName Then
      dr.Item("oaddrcityst") = String.Empty
      dr.Item("naddrcityst") = WrkNName
    Else
      dr.Item("oaddrcityst") = BuildAddrCityST(WrkOAddr, WrkOAddr2, WrkOCity, WrkOState, WrkOZip5, WrkOZip4)
      dr.Item("naddrcityst") = BuildAddrCityST(WrkNAddr, WrkNAddr2, WrkNCity, WrkNState, WrkNZip5, WrkNZip4)
      If WrkMVDList > 0 And MyUtils.CnvSng(WrkNZip5) = 0 Then
        WrkCountNoZip = WrkCountNoZip + 1
        WrkErrorMsg = WrkErrorMsg & "*** Zip Code is missing ***"
      End If
    End If

    dr.Item("chgdesc") = WrkChgDesc
    dr.Item("mvdlist") = WrkMVDList
    dr.Item("mvdname") = WrkMVDName
    dr.Item("errormsg") = WrkErrorMsg

    dr.Item("custid") = WrkCustomerNumber          'added 5/29/26 ken

    ds.Tables(0).Rows.Add(dr)

    If WrkPost And WrkMVDList > 0 Then
      myTXMVDC.GetOneRecordP(WrkMVDList)
      With myTXMVDC
        If WrkIsName Then
          ._SNAME = "C/O " & Trim(WrkNName)
        Else
          ._ADD1 = WrkNAddr
          ._ADD2 = WrkNAddr2
          ._CITY = WrkNCity
          ._STATE = WrkNState
          ._ZIP5 = MyUtils.CnvSng(WrkNZip5)
          ._ZIP4 = MyUtils.CnvSng(WrkNZip4)
        End If
        .UpdateOneRecordP()
      End With
    End If

NextRec:
    With myFrmProgress
      WrkPct = (I / WrkFileSize) * 100
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With

    GoTo NextLine

End_of_file:
    sr.Close()
    myFrmProgress.Close()
    myTXMVDCL2.CloseFile()

  End Sub

  Private Sub GetDetailName()
    Dim WrkStream As FileStream = New FileStream(MyFrmTX412B.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim sArray As String()
    Dim WrkFileSize As Integer
    Dim I As Integer
    Dim WrkClass As Integer
    Dim WrkRegno As String
    Dim SaveRegno As String
    Dim WrkTown As Integer
    Dim WrkNName As String
    Dim WrkChgDesc As String
    Dim WrkOName As String
    Dim WrkMVDList As Integer
    Dim WrkMVDName As String
    Dim WrkRecNo As Integer
    Dim WrkIsName As Boolean
    Dim WrkErrorMsg As String
    Dim WrkCustomerNumber As Integer                 'added 5/21/26 ken

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    WrkCountName = 0
    WrkCountAddr = 0
    WrkCountMatch = 0
    WrkCountNoMatch = 0
    WrkCountNamesDiff = 0
    WrkCountNoZip = 0
    strBuffer = sr.ReadLine 'Skip Headings
    SaveRegno = String.Empty

NextLine:
    strBuffer = sr.ReadLine
    If strBuffer Is Nothing Then
      GoTo End_of_file
      Exit Sub
    End If

    sArray = Parse(strBuffer, ",")
    WrkCustomerNumber = 0                          'added 5/21/26 ken     
    WrkCustomerNumber = MyUtils.CnvSng(sArray(0))  'added 5/21/26 ken           

    WrkRecNo = WrkRecNo + 1
    I = I + strBuffer.Length

    'If WrkPeople And Not WrkBusiness And Trim(sArray(3)) = String.Empty Then         added 5/21/26 ken
    If WrkPeople And Not WrkBusiness And Trim(sArray(4)) = String.Empty Then
      GoTo NextRec
    End If

    'If WrkBusiness And Not WrkPeople And Trim(sArray(6)) = String.Empty Then         added 5/21/26 ken
    If WrkBusiness And Not WrkPeople And Trim(sArray(7)) = String.Empty Then
      GoTo NextRec
    End If

    'WrkClass = GetTXVCLSCode(sArray(2))          added 5/21/26 ken
    WrkClass = GetTXVCLSCode(sArray(3))

    'WrkRegno = sArray(1)                         added 5/21/26 ken
    WrkRegno = sArray(2)

    If SaveRegno = WrkRegno Then GoTo NextRec
    SaveRegno = WrkRegno

    'WrkTown = MyUtils.CnvSng(sArray(0))          added 5/21/26 ken
    WrkTown = MyUtils.CnvSng(sArray(1))

    WrkOName = String.Empty
    myTXMVDCL2.GetOneRecordP(WrkClass, WrkRegno)

    If Not myTXMVDCL2.RecordNotFound Then
      With myTXMVDCL2
        WrkOName = Trim(._NAME)
      End With
    End If

    WrkNName = String.Empty

    'If sArray(6) <> String.Empty Then            added 5/21/26 ken
    '  WrkNName = sArray(6)                       added 5/21/26 ken
    If sArray(7) <> String.Empty Then
      WrkNName = sArray(7)
    Else

      'WrkNName = sArray(3)                       added 5/21/26 ken
      WrkNName = sArray(4)

      'If sArray(4) <> String.Empty Then          added 5/21/26 ken
      '  WrkNName = WrkNName & " " & sArray(4)    added 5/21/26 ken
      If sArray(5) <> String.Empty Then
        WrkNName = WrkNName & " " & sArray(5)
      End If

      'If sArray(5) <> String.Empty Then          added 5/21/26 ken
      '  WrkNName = WrkNName & " " & sArray(5)    added 5/21/26 ken
      If sArray(6) <> String.Empty Then
        WrkNName = WrkNName & " " & sArray(6)
      End If

    End If

    WrkChgDesc = "NAME"
    WrkIsName = False

    If Trim(WrkOName) <> WrkNName Then
      WrkIsName = True
      WrkCountName = WrkCountName + 1
    End If

    WrkMVDList = 0
    WrkMVDName = ""
    WrkErrorMsg = ""

    If Not WrkIsName Then
      GoTo NextRec
    End If

    If Not myTXMVDCL2.RecordNotFound Then
      With myTXMVDCL2
        WrkMVDList = ._LISTNO
        WrkMVDName = Trim(._SNAME)
        WrkCountMatch = WrkCountMatch + 1
      End With
    Else
      WrkMVDName = String.Empty
      WrkErrorMsg = "*** Record not found ***"
      WrkCountNoMatch = WrkCountNoMatch + 1
    End If

    dr = ds.Tables(0).NewRow
    dr.Item("class") = WrkClass
    dr.Item("regno") = WrkRegno
    dr.Item("town") = WrkTown
    dr.Item("name") = WrkOName
    dr.Item("oaddrcityst") = String.Empty
    dr.Item("naddrcityst") = WrkNName
    dr.Item("chgdesc") = WrkChgDesc
    dr.Item("mvdlist") = WrkMVDList
    dr.Item("mvdname") = WrkMVDName
    dr.Item("errormsg") = WrkErrorMsg

    dr.Item("custid") = WrkCustomerNumber          'added 5/29/26 ken

    ds.Tables(0).Rows.Add(dr)

    If WrkPost And WrkMVDList > 0 Then
      myTXMVDC.GetOneRecordP(WrkMVDList)
      With myTXMVDC
        If WrkIsName Then
          ._SNAME = "C/O " & Trim(WrkNName)
        End If
        .UpdateOneRecordP()
      End With
    End If

NextRec:
    With myFrmProgress
      WrkPct = (I / WrkFileSize) * 100
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With

    GoTo NextLine

End_of_file:
    sr.Close()
    myFrmProgress.Close()
    myTXMVDCL2.CloseFile()

  End Sub
  Private Function BuildAddrCityST(ByVal Addr As String, ByVal Addr2 As String, ByVal City As String, _
  ByVal State As String, ByVal Zip5 As String, ByVal Zip4 As String) As String
  Dim WrkResult As String
  Dim sb As StringBuilder

  Addr = Trim(Addr)
  City = Trim(City)

  sb = New StringBuilder
  sb.Append(Addr)
  If Addr <> String.Empty And City <> String.Empty Then
    sb.Append(", ")
  End If
  If Addr2 <> String.Empty And City <> String.Empty Then
    sb.Append(Addr2)
    sb.Append(", ")
  End If
  sb.Append(City)
  sb.Append(" ")
  sb.Append(State)
  sb.Append(" ")
  sb.Append(Zip5)
  If Zip4 <> "" Then
    sb.Append("-")
    sb.Append(Zip4)
  End If
  WrkResult = sb.ToString
  sb = Nothing

  Return WrkResult
End Function
Public Function GetTXVCLSCode(ByVal Desc As String) As Integer

   If Desc = "" Then
     Return ""
   End If

   myTXVCLS.GetOneRecordP(Desc)
   If Not myTXVCLS.RecordNotFound Then
     GetTXVCLSCode = myTXVCLS._CLASS
   Else
     GetTXVCLSCode = 0
   End If
   Return GetTXVCLSCode

End Function
End Module






