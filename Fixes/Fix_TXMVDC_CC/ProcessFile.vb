Imports System.IO
Imports System.Net.Security
Imports System.Text
Module ProcessFile

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim found As Boolean
  Dim myTXMVDCQ As TXMVDCQ.MyData
  Dim myTXMVDC As TXMVDC.MyData
  Dim myTXCOEB As TXCOEB.MyData
  Dim MyGetTXMVPCT As GetTXMVPCT
  Dim ds As DataSet = New DataSet
  Dim sw As StreamWriter
  Dim WrkOldGross As Integer
  Dim WrkGross As Integer
  Dim WrkNet As Integer
  Dim MyProrateRound As Boolean
  'Screen
  Dim WrkPost As Boolean
  Public Sub PrtReport()

    myTXMVDCQ = New TXMVDCQ.MyData(myDBConnect)
    myTXMVDC = New TXMVDC.MyData(myDBConnect)
    myTXCOEB = New TXCOEB.MyData(myDBConnect)
    MyGetTXMVPCT = New GetTXMVPCT
    MyProrateRound = GetGNET("CCRND")

    GetDetail()
  End Sub
  Private Sub GetDetail()
    Dim WrkProrate As Integer
    Dim WrkExam As Integer
    Dim WrkAdjNet As Integer
    Dim WrkPct As Double
    Dim WrkSaleMonth As Integer
    Dim WrkSort As String
    Dim WrkQry As String
    Dim I As Integer
    Dim Counter As Integer
    Dim WrkAnd As String
    Dim WrkOr As String

    WrkSort = "CCNO"
    With MyFrmFixB
      WrkPost = .ChkUpdate.Checked
    End With

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    Counter = 0
    WrkQry = "CCNO > 0"
    ds = myTXMVDCQ.GetQry(WrkSort, WrkQry, 0)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    If MyFrmFixB.LblFilePath.Text <> "" Then
      sw = New StreamWriter(MyFrmFixB.LblFilePath.Text)
      sw.WriteLine(HeadingsCSV)
    End If

ReadNext:
    For I = 0 To ds.Tables(0).Rows.Count - 1
      Counter = Counter + 1
      WrkGross = 0
      WrkNet = 0
      With ds.Tables(0).Rows(I)
        myTXCOEB.GetOneRecordP(.Item("CCNO"))
        WrkGross = .Item("VALUE") + myTXCOEB._CGRSCH
        If WrkGross < 0 Then
          WrkGross = 0
        End If
        WrkOldGross = .Item("ccgrs")
        WrkExam = myTXCOEB._NTEX1 + myTXCOEB._NTEX2 + myTXCOEB._NTEX3 + myTXCOEB._NTEX4 + myTXCOEB._NTEX5
        CalcProrateCode(Trim(myTXCOEB._CT2MC1), WrkGross, WrkProrate, WrkAdjNet, WrkPct, WrkSaleMonth)
        If WrkSaleMonth > 0 Then
          WrkAdjNet = WrkAdjNet - WrkExam
        Else
          WrkAdjNet = 0
          WrkProrate = 0
        End If
        If .Item("value") > 0 Then
          WrkNet = WrkGross - WrkAdjNet - WrkExam
        Else
          WrkGross = WrkOldGross
          WrkNet = WrkGross - WrkAdjNet - WrkExam
        End If
        If MyFrmFixB.LblFilePath.Text <> "" Then
          sw.WriteLine(DownloadCSV(I, WrkProrate, WrkAdjNet, WrkExam))
        End If
        If WrkPost Then
          UpdateTXMVDC(.Item("LIST#"))
          UpdateTXCOEB(.Item("CCNO"), WrkAdjNet)
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
    Next

    If MyFrmFixB.LblFilePath.Text <> String.Empty Then
      sw.Flush()
      sw.Close()
    End If
    myFrmProgress.Close()
    myTXMVDCQ.CloseFile()
    myTXMVDC.CloseFile()
  End Sub
  Private Sub UpdateTXMVDC(ByVal WrkListNo As Integer)
    myTXMVDC.GetOneRecordP(WrkListNo)
    If myTXMVDC.RecordNotFound Then Exit Sub

    With myTXMVDC
      ._CCGRS = WrkGross
      .UpdateOneRecordP()
    End With
  End Sub
  Private Sub UpdateTXCOEB(ByVal WrkListNo As Integer, ByVal WrkAdjNet As Integer)
    With myTXCOEB
      ._CGRS = WrkGross
      ._NTASS1 = WrkGross
      ._NTNET = WrkNet
      .UpdateOneRecordP()
    End With
  End Sub
  Public Sub CalcProrateCode(ByVal In_SaleCode As String, ByVal In_Value As Integer,
    ByRef Out_Prorate As Integer, ByRef Out_AdjNet As Integer,
    ByRef Out_Pct As Single, ByRef Out_SaleMonth As Integer)

    With MyGetTXMVPCT
      .GetTXMVPCT("M", In_SaleCode)
      Out_SaleMonth = .Month
      Out_Pct = .Pct
    End With
    If Out_SaleMonth = 0 Then
      Out_Prorate = 0
      Out_AdjNet = 0
      Exit Sub
    End If
    If MyProrateRound Then
      Out_AdjNet = MyUtils.Round10(In_Value * Out_Pct, "Normal")
    Else
      Out_AdjNet = MyUtils.Round(In_Value * Out_Pct, 0)
    End If
    Out_Prorate = In_Value - Out_AdjNet
  End Sub
  Private Function HeadingsCSV() As String
    Dim sb As StringBuilder
    Const CComma As String = ","

    sb = New StringBuilder
    sb.Append("CC No")
    sb.Append(CComma)
    sb.Append("ListNo")
    sb.Append(CComma)
    sb.Append("Name")
    sb.Append(CComma)
    sb.Append("Year")
    sb.Append(CComma)
    sb.Append("Old Gross")
    sb.Append(CComma)
    sb.Append("Gross")
    sb.Append(CComma)
    sb.Append("Prorate")
    sb.Append(CComma)
    sb.Append("Exemptions")
    sb.Append(CComma)
    sb.Append("Net")
    Return sb.ToString
  End Function
  Private Function DownloadCSV(ByVal I As Integer, ByVal WrkProrate As Integer, ByVal WrkAdjNet As Integer, ByVal WrkExam As Integer) As String
    Dim sb As StringBuilder
    Const CComma As String = ","

    With ds.Tables(0).Rows(I)
      sb = New StringBuilder
      sb.Append(.Item("CCNo"))
      sb.Append(CComma)
      sb.Append(.Item("LIST#"))
      sb.Append(CComma)
      sb.Append(Trim(.Item("NAME")))
      sb.Append(CComma)
      sb.Append(.Item("YEAR"))
      sb.Append(CComma)
      sb.Append(WrkOldGross)
      sb.Append(CComma)
      sb.Append(WrkGross)
      sb.Append(CComma)
      sb.Append(WrkAdjNet)
      sb.Append(CComma)
      sb.Append(WrkExam)
      sb.Append(CComma)
      sb.Append(WrkNet)
    End With
    Return sb.ToString
  End Function
  Public Function GetGNET(ByVal Code As String) As Boolean
    Dim myGNET As GNET.MyData

    myGNET = New GNET.MyData()
    myGNET.MyDBConn = myDBConnect
    If IsNothing(Code) Or Code = "" Then
      Return False
    End If

    myGNET.GetOneRecordP(Code)
    If Not myGNET.RecordNotFound Then
      If myGNET._VALUE = "Y" Then
        GetGNET = True
      Else
        GetGNET = False
      End If
    Else
      GetGNET = False
    End If
    myGNET.CloseFile()
    myGNET = Nothing
    Return GetGNET

  End Function
End Module


