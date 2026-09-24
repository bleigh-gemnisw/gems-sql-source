Imports System.IO
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Text
Module ProcessFile

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXDCSUMQ As TXDCSUMQ.MyData
  Dim myTXDCSUM As TXDCSUM.MyData
  Dim myTXPPRP As TXPPRP.MyData

  Dim ds As DataSet = New DataSet
  Dim sw As StreamWriter
  'Declaration fields, 9=MV, 25=Penalty
  Dim WrkOldNet9 As Integer
  Dim WrkNet9 As Integer
  Dim WrkOldNet25 As Integer
  Dim WrkNet25 As Integer
  Dim WrkOldGross As Integer
  Dim WrkGross As Integer

  'Screen
  Dim WrkGLYear As Integer
  Dim WrkPost As Boolean
  Public Sub PrtReport()
    myTXDCSUMQ = New TXDCSUMQ.MyData(myDBConnect)
    myTXDCSUM = New TXDCSUM.MyData(myDBConnect)
    myTXPPRP = New TXPPRP.MyData(myDBConnect)

    With MyFrmFixB
      WrkGLYear = .TxtGLYear.Text
      WrkPost = .ChkUpdate.Checked
    End With

    GetDetail()
  End Sub
  Private Sub GetDetail()
    Dim WrkList As Integer
    Dim WrkSort As String
    Dim WrkQry As String
    Dim ArrCode(9) As Integer
    Dim ArrAss(9) As Integer
    Dim WrkPos9 As Integer
    Dim WrkPos25 As Integer
    Dim Counter As Integer
    Dim K As Integer

    WrkSort = "List#,Code"
    WrkQry = "YEAR=" & WrkGLYear & " and code=9"
    Counter = 0
    myTXDCSUMQ.OpenQry(WrkSort, WrkQry)
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    If MyFrmFixB.LblFilePath.Text <> "" Then
      sw = New StreamWriter(MyFrmFixB.LblFilePath.Text)
      sw.WriteLine(HeadingsCSV)
    End If

ReadNext:
    myTXDCSUMQ.ReadQry()
    If Not myTXDCSUMQ.IsEOF Then
      With myTXDCSUMQ
        Counter = Counter + 1
        WrkList = ._LISTNO
        WrkOldNet9 = 0
        WrkOldNet25 = 0
        WrkNet9 = ._NET
        WrkNet25 = 0
        Array.Clear(ArrCode, 0, 10)
        Array.Clear(ArrAss, 0, 10)
        With myTXPPRP
          .GetOneRecordP(WrkList)
          If Not .RecordNotFound Then
            ArrCode(0) = ._CODE1
            ArrCode(1) = ._CODE2
            ArrCode(2) = ._CODE3
            ArrCode(3) = ._CODE4
            ArrCode(4) = ._CODE5
            ArrCode(5) = ._CODE6
            ArrCode(6) = ._CODE7
            ArrCode(7) = ._CODE8
            ArrCode(8) = ._CODE9
            ArrCode(9) = ._CODEA
            ArrAss(0) = ._ASS1
            ArrAss(1) = ._ASS2
            ArrAss(2) = ._ASS3
            ArrAss(3) = ._ASS4
            ArrAss(4) = ._ASS5
            ArrAss(5) = ._ASS6
            ArrAss(6) = ._ASS7
            ArrAss(7) = ._ASS8
            ArrAss(8) = ._ASS9
            ArrAss(9) = ._ASS10
            WrkOldGross = ._GROSS
          End If
        End With

        WrkPos9 = -1
        WrkPos25 = -1
        For K = 0 To 9
          If ArrCode(K) = 9 Or ArrCode(K) = 90 Then
            WrkPos9 = K
            WrkOldNet9 = ArrAss(K)
          End If
          If ArrCode(K) = 25 Or ArrCode(K) = 250 Then
            WrkPos25 = K
            WrkOldNet25 = ArrAss(K)
          End If
        Next
        WrkNet9 = ._NET
        If WrkOldNet25 > 0 Then
          myTXDCSUM.GetOneRecordP(WrkList, WrkGLYear, 25)
          If Not myTXDCSUM.RecordNotFound Then
            WrkNet25 = myTXDCSUM._NET
          End If
        End If
        WrkGross = myTXPPRP._GROSS + WrkNet9 - WrkOldNet9 + WrkNet25 - WrkOldNet25
        If MyFrmFixB.LblFilePath.Text <> "" Then
          sw.WriteLine(DownloadCSV(WrkList, WrkPos9, WrkPos25))
        End If
        If WrkPost And WrkNet9 <> WrkOldNet9 Then
          UpdateTXPPRP(WrkList, WrkPos9, WrkPos25)
        End If
      End With

NextRec:
      With myFrmProgress
        WrkPct = (Counter / 10) Mod 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .LblMsg.Text = "Records processed: " & Counter
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
      GoTo ReadNext
    End If

    If MyFrmFixB.LblFilePath.Text <> String.Empty Then
      sw.Flush()
      sw.Close()
    End If
    myFrmProgress.Close()
  End Sub
  Private Sub UpdateTXPPRP(ByVal WrkListNo As Integer, WrkPos9 As Integer, WrkPos25 As Integer)
    myTXPPRP.GetOneRecordP(WrkListNo)
    If myTXPPRP.RecordNotFound Then Exit Sub

    With myTXPPRP
      Select Case WrkPos9
        Case 0 : ._ASS1 = WrkNet9
        Case 1 : ._ASS2 = WrkNet9
        Case 2 : ._ASS3 = WrkNet9
        Case 3 : ._ASS4 = WrkNet9
        Case 4 : ._ASS5 = WrkNet9
        Case 5 : ._ASS6 = WrkNet9
        Case 6 : ._ASS7 = WrkNet9
        Case 7 : ._ASS8 = WrkNet9
        Case 8 : ._ASS9 = WrkNet9
        Case 9 : ._ASS10 = WrkNet9
        Case Else
      End Select
      Select Case WrkPos25
        Case 0 : ._ASS1 = WrkNet25
        Case 1 : ._ASS2 = WrkNet25
        Case 2 : ._ASS3 = WrkNet25
        Case 3 : ._ASS4 = WrkNet25
        Case 4 : ._ASS5 = WrkNet25
        Case 5 : ._ASS6 = WrkNet25
        Case 6 : ._ASS7 = WrkNet25
        Case 7 : ._ASS8 = WrkNet25
        Case 8 : ._ASS9 = WrkNet25
        Case 9 : ._ASS10 = WrkNet25
        Case Else
      End Select
      ._GROSS = WrkGross
      ._NET = ._NET + WrkNet9 - WrkOldNet9 + WrkNet25 - WrkOldNet25
      .UpdateOneRecordP()
    End With
  End Sub
  Private Function HeadingsCSV() As String
    Dim sb As StringBuilder
    Const CComma As String = ","

    sb = New StringBuilder
    sb.Append("ListNo")
    sb.Append(CComma)
    sb.Append("Name")
    sb.Append(CComma)
    sb.Append("Bucket9")
    sb.Append(CComma)
    sb.Append("Old Value9")
    sb.Append(CComma)
    sb.Append("New Value9")
    sb.Append(CComma)
    sb.Append("Bucket25")
    sb.Append(CComma)
    sb.Append("Old Value25")
    sb.Append(CComma)
    sb.Append("New Value25")
    sb.Append(CComma)
    sb.Append("Old Gross")
    sb.Append(CComma)
    sb.Append("New Gross")
    Return sb.ToString
  End Function
  Private Function DownloadCSV(ByVal WrkList As Integer, WrkPos9 As Integer, WrkPos25 As Integer) As String
    Dim sb As StringBuilder
    Const CComma As String = ","

    sb = New StringBuilder
    sb.Append(WrkList)
    sb.Append(CComma)
    sb.Append(Trim(myTXPPRP._NAME))
    sb.Append(CComma)
    sb.Append(WrkPos9 + 1)
    sb.Append(CComma)
    sb.Append(WrkOldNet9)
    sb.Append(CComma)
    sb.Append(WrkNet9)
    sb.Append(CComma)
    sb.Append(WrkPos25 + 1)
    sb.Append(CComma)
    sb.Append(WrkOldNet25)
    sb.Append(CComma)
    sb.Append(WrkNet25)
    sb.Append(CComma)
    sb.Append(WrkOldGross)
    sb.Append(CComma)
    sb.Append(WrkGross)
    Return sb.ToString
  End Function
End Module


