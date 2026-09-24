Imports System.IO
Imports System.Text
Module ProcessFile

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim found As Boolean
  Dim myTXMVDQ As TXMVDQ.MyData
  Dim myTXMVD As TXMVD.MyData
  Dim myTXMCTL As TXMCTL.MyData
  Dim myTXMSRP As TXMSRP.MyData
  Dim myTXMSRPDEP As TXMSRPDEP.MyData

  Dim ds As DataSet = New DataSet
  Dim sw As StreamWriter
  Dim WrkMSRP As Integer
  Dim WrkSource As String
  Dim WrkOldValue As Integer
  Dim WrkValue As Integer

  'Screen
  Dim WrkPost As Boolean
  Dim WrkIncr As Decimal
  'Control File
  Dim WrkBookPct As Decimal
  Dim WrkMinValue As Integer
  Public Sub PrtReport()

    With MyFrmFixB
      WrkPost = .ChkUpdate.Checked
      WrkIncr = 0
      If .ChkIncr.Checked Then
        WrkIncr = 0.05
      End If
    End With

    myTXMVDQ = New TXMVDQ.MyData(myDBConnect)
    myTXMVD = New TXMVD.MyData(myDBConnect)
    myTXMCTL = New TXMCTL.MyData(myDBConnect)
    myTXMSRP = New TXMSRP.MyData(myDBConnect)
    myTXMSRPDEP = New TXMSRPDEP.MyData(myDBConnect)
    GetTXMCTL()
    GetDetailMV()
  End Sub
  Private Sub GetTXMCTL()
    myTXMCTL = New TXMCTL.MyData(myDBConnect)
    myTXMCTL.GetOneRecordP(1)
    If Not myTXMCTL.RecordNotFound Then
      With myTXMCTL
        WrkBookPct = ._VALPER
        WrkMinValue = ._VALMIN
      End With
    End If
  End Sub
  Private Sub GetDetailMV()
    Dim WrkSort As String
    Dim WrkQry As String
    Dim I As Integer
    Dim J As Integer
    Dim Counter As Integer
    Dim WrkAnd As String
    Dim WrkOr As String

    WrkSort = "MAKE, YEAR, MODEL, CLASS"
    WrkQry = "CAT = '1'"
    WrkAnd = " and "
    WrkOr = " or "
    Counter = 0
    ds = myTXMVDQ.GetQry(WrkSort, WrkQry, 0)

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
      WrkValue = 0
      WrkSource = ""
      With ds.Tables(0).Rows(I)
        WrkMSRP = .Item("msrp")
        WrkOldValue = .Item("VALUE")
        myTXMSRP.GetOneRecordP(Trim(.Item("VINNO")))
        If Not myTXMSRP.RecordNotFound Then
          WrkSource = Trim(myTXMSRP._OVSOURCE)
          If WrkSource <> "" Then
            WrkMSRP = myTXMSRP._OVMSRP
          End If
        End If
          If WrkMSRP > 0 And WrkOldValue > 500 Then
          WrkValue = CalcValue(WrkMSRP, .Item("YEAR"))
          J = WrkValue Mod 10
          If J <> 0 Then
            If J < 5 Then
              WrkValue = WrkValue - J
            Else
              WrkValue = WrkValue + (10 - J)
            End If
          End If
        End If
        If WrkMinValue > 0 And WrkValue > 0 Then
          If WrkMinValue > WrkValue Then
            WrkValue = WrkMinValue
          End If
        End If
        If WrkOldValue = 500 Then
          WrkValue = 500
        End If
        If WrkMSRP = 0 And WrkValue = 0 Then
          WrkValue = WrkOldValue
        End If
        If MyFrmFixB.LblFilePath.Text <> "" Then
          sw.WriteLine(DownloadCSV(I))
        End If
        If WrkPost And WrkValue <> WrkOldValue Then
          UpdateTXMVD(.Item("LIST#"), WrkValue)
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
    myTXMVDQ.CloseFile()
    myTXMVD.CloseFile()
  End Sub
  Private Sub UpdateTXMVD(ByVal WrkListNo As Integer, ByVal WrkValue As Integer)
    myTXMVD.GetOneRecordP(WrkListNo)
    If myTXMVD.RecordNotFound Then Exit Sub

    With myTXMVD
      ._VALUE = WrkValue
      .UpdateOneRecordP()
    End With
  End Sub
  Private Function CalcValue(ByVal WrkMSRP As Integer, ByVal WrkYear As Integer) As Integer
    Dim WrkDeYear As Integer
    Dim WrkValue As Integer
    Dim WrkDepr As Decimal
    'Calculate Assessment Value
    WrkValue = 0
    WrkDeYear = 2024 - WrkYear + 1
    If WrkDeYear < 1 Then
      WrkDeYear = 1
    End If
    WrkDepr = GetTXMSRPDEP(WrkDeYear)
    WrkDepr = WrkDepr + WrkIncr
    If WrkMSRP > 0 Then
      WrkValue = WrkMSRP * WrkDepr * WrkBookPct
    End If
    WrkValue = MyUtils.Round10(WrkValue, "Normal")
    If WrkValue < WrkMinValue Then
      WrkValue = WrkMinValue
    End If
    Return WrkValue
  End Function
  Public Function GetTXMSRPDEP(ByVal DeprYear As Integer) As Decimal
    Dim WrkDepr As Decimal
    If DeprYear < 0 Then DeprYear = 1
    WrkDepr = myTXMSRPDEP.GetDepr(DeprYear)
    Return WrkDepr
  End Function
  Private Function HeadingsCSV() As String
    Dim sb As StringBuilder
    Const CComma As String = ","

    sb = New StringBuilder
    sb.Append("ListNo")
    sb.Append(CComma)
    sb.Append("Name")
    sb.Append(CComma)
    sb.Append("VIN")
    sb.Append(CComma)
    sb.Append("Source")
    sb.Append(CComma)
    sb.Append("MSRP")
    sb.Append(CComma)
    sb.Append("Make")
    sb.Append(CComma)
    sb.Append("Model")
    sb.Append(CComma)
    sb.Append("Year")
    sb.Append(CComma)
    sb.Append("Class")
    sb.Append(CComma)
    sb.Append("Old Value")
    sb.Append(CComma)
    sb.Append("New Value")
    Return sb.ToString
  End Function
  Private Function DownloadCSV(ByVal I As Integer) As String
    Dim sb As StringBuilder
    Const CComma As String = ","

    With ds.Tables(0).Rows(I)
      sb = New StringBuilder
      sb.Append(.Item("LIST#"))
      sb.Append(CComma)
      sb.Append(Trim(Replace(.Item("NAME"), ",", "")))
      sb.Append(CComma)
      sb.Append(Trim(.Item("VINNO")))
      sb.Append(CComma)
      sb.Append(WrkSource)
      sb.Append(CComma)
      sb.Append(WrkMSRP)
      sb.Append(CComma)
      sb.Append(.Item("MAKE"))
      sb.Append(CComma)
      sb.Append(.Item("MODEL"))
      sb.Append(CComma)
      sb.Append(.Item("YEAR"))
      sb.Append(CComma)
      sb.Append(.Item("CLASS"))
      sb.Append(CComma)
      sb.Append(WrkOldValue)
      sb.Append(CComma)
      sb.Append(WrkValue)
    End With
    Return sb.ToString
  End Function
End Module


