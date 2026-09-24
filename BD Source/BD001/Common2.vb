Module Common2
  Dim myBDCNTL As BDCNTL.myData
  Dim myBDCOM As BDCOM.myData
  Dim myBDRATE As BDRATE.myData
  Public myTXREAL As TXReal.myData
  Dim myCASHINT As CASHINT.MyData
  Dim myTXINVLK As TXINVLK.myData

Public Sub InitFile()
  myBDCNTL = New BDCNTL.mydata(MyDBConnect)
  myTXREAL = New TXReal.mydata(MyDBConnect)
  myBDCNTL.GetOneRecordP("")
 End Sub
Public Sub CheckLic(WrkLic As String, ByRef CoLic1 As String, ByRef CoLic2 As String, ByRef CoLic3 As String, _
  ByRef CoLic4 As String, ByRef CoLic5 As String)

  Dim WrkLics(4) As String
  Dim I As Integer
  WrkLics(0) = Trim(CoLic1)
  WrkLics(1) = Trim(CoLic2)
  WrkLics(2) = Trim(CoLic3)
  WrkLics(3) = Trim(CoLic4)
  WrkLics(4) = Trim(CoLic5)
  For I = 0 To 4 'if found then exit sub
    If WrkLics(I) = WrkLic Then
      Exit Sub
    End If
  Next
  For I = 0 To 4 'find next empty license 
    If WrkLics(I) = "" Then
      Exit For
    End If
  Next
  Select Case I
  Case 0
    CoLic1 = WrkLic
  Case 1
    CoLic2 = WrkLic
  Case 2
    CoLic3 = WrkLic
  Case 3
    CoLic4 = WrkLic
  Case 4
    CoLic5 = WrkLic
  End Select
End Sub
Public Function CalcDelqListNo(WrkListNo As Integer, WrkTaxType As String, WrkTranDate As Date) As Boolean
  Dim ds2 As DataSet = New DataSet
  Dim I As Integer

  myCASHINT = New CASHINT.mydata(MyDBConnect)
  myTXINVLK = New TXINVLK.mydata(MyDBConnect)
  'If RbCash.Checked Or RbCheck.Checked Then
  '  Return False
  'End If

  ds2 = myTXINVLK.GetViewbyList(WrkListNo, WrkTaxType, 999)
  If ds2.Tables(0).Rows.Count = 0 Then
    Return False
  End If

  For I = 0 To ds2.Tables(0).Rows.Count - 1
    With myCASHINT
      If ds2.Tables(0).Rows(I).Item("wbal") > 0 Then
        .In_IntDate = WrkTranDate
        .In_ListNo = WrkListNo
        .In_Type = WrkTaxType
        .In_Year = ds2.Tables(0).Rows(I).Item("year")
        .CalcInterest()
        If .Out_Prin > 0 And Not .Out_GracePeriod Then
          Return True
        End If
      End If
    End With
  Next
  Return False
End Function
Public Function FormatDesc(WrkRecID As Integer) As String
  Dim ds As DataSet
  Dim I As Integer
  Dim WrkStr As String

  myBDCOM = New BDCOM.mydata(MyDBConnect)
  WrkStr = ""
  ds = myBDCOM.Getcomments(WrkRecID)
  For I = 0 To ds.Tables(0).Rows.Count - 1
    If Len(ds.Tables(0).Rows(I).Item("cmnt")) = 59 Then
      WrkStr = WrkStr + ds.Tables(0).Rows(I).Item("cmnt") & " "
    Else
      WrkStr = WrkStr + ds.Tables(0).Rows(I).Item("cmnt")
    End If
  Next
  Return Trim(WrkStr)
End Function
  Public Sub SaveBDCOM(ByVal WrkRecID As Integer, ByVal WrkDesc As String)
    Dim I As Integer
    Dim WrkLen As Integer
    Dim WrkRecs As Integer
    Dim WrkPos As Integer

    myBDCOM.DeleteKeyComment(WrkRecID)
    WrkLen = Len(WrkDesc)
    WrkRecs = Math.Ceiling(WrkLen / 60)
    For I = 0 To WrkRecs - 1
      WrkPos = (I * 60) + 1
      With myBDCOM
        .GetOneRecordP(WrkRecID, I)
        ._CMNT = Mid(WrkDesc, WrkPos, 60)
        ._SEQNO = I
        ._RECID = WrkRecID
        .AddOneRecordP()
      End With
    Next
  End Sub
  Public Sub DeleteBDCOM(ByVal WrkRecID As Integer)
    myBDCOM.DeleteKeyComment(WrkRecID)
  End Sub

  Public Function CalcFee(ByVal WrkType As String, ByVal WrkValue As Integer) As Decimal
    Dim WrkFeeVal As Decimal
    Dim WrkFeeCert As Decimal
    Dim WrkFeeState As Decimal
    Dim WrkFee As Decimal

    WrkFeeVal = CalcRate(WrkType, WrkValue)
    WrkFeeCert = CalcCert(WrkType)
    If WrkFeeCert > 0 Then
      WrkFeeState = CalcRate("STATE", WrkValue)
    Else
      WrkFeeState = 0
    End If
    WrkFee = WrkFeeVal + WrkFeeCert + WrkFeeState
  Return WrkFee
  End Function
  Public Function CalcRate(ByVal WrkType As String, ByVal WrkValue As Integer) As Decimal
    Dim dsrate As DataSet = New DataSet
    Dim WrkVal As Integer
    Dim WrkValueLeft As Integer
    Dim WrkRate(10) As Decimal
    Dim WrkTier(10) As Integer
    Dim WrkPer(10) As Integer
    Dim WrkCert(10) As Decimal
    Dim WrkMult As Integer
    Dim WrkFee As Decimal
    Dim I As Integer

    myBDRATE = New BDRATE.mydata(MyDBConnect)
    dsrate = myBDRATE.GetAllType(WrkType)
    For I = 0 To dsrate.Tables(0).Rows.Count - 1
      With dsrate.Tables(0).Rows(I)
        WrkRate(I) = .Item("rate")
        WrkTier(I) = .Item("tier")
        WrkPer(I) = .Item("per")
        WrkCert(I) = .Item("cert")
      End With
    Next

    WrkValueLeft = WrkValue
    For I = 0 To 10
      If WrkTier(I) = 0 Or WrkValueLeft = 0 Then Exit For
      If WrkValueLeft > WrkTier(I) Then
        WrkValueLeft = WrkValueLeft - WrkTier(I)
        WrkVal = WrkTier(I)
      Else
        WrkVal = WrkValueLeft
        WrkValueLeft = 0
      End If
      WrkMult = Math.Ceiling(WrkVal / WrkPer(I))
      WrkFee = WrkFee + (WrkMult * WrkRate(I))
    Next
  Return WrkFee
  End Function
  Public Function CalcCert(ByVal WrkType As String) As Decimal
    Dim dsrate As DataSet = New DataSet
    Dim WrkFee As Decimal

    myBDRATE = New BDRATE.mydata(MyDBConnect)
    WrkFee = 0
    dsrate = myBDRATE.GetAllType(WrkType)
    If dsrate.Tables(0).Rows.Count > 0 Then
      WrkFee = dsrate.Tables(0).Rows(0).Item("cert")
    End If
  Return WrkFee
  End Function
Public Function NextPermitNo(ByVal WrkType As String) As Integer
     Dim ds2 As DataSet = New DataSet
     Dim WrkNextNo As Integer

     myBDRATE = New BDRATE.mydata(MyDBConnect)
     ds2 = myBDRATE.GetAllType(WrkType)
     If Trim(ds2.Tables(0).Rows(0).Item("permit")) = "" Then Return 0

     If Not myBDCNTL.RecordNotFound Then
       WrkNextNo = myBDCNTL._LPERM + 1
       myBDCNTL._LPERM = WrkNextNo
       myBDCNTL.UpdateOneRecordP()
       Return WrkNextNo
     End If

End Function
Public Function GetNecYear() As Integer
  Return myBDCNTL._NECYR
End Function
Public Function GetIRCYear() As Integer
  Return myBDCNTL._IRCYR
End Function
End Module






