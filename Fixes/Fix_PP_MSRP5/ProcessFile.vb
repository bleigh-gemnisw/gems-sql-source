Imports System.IO
Imports System.Text
Module ProcessFile

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim found As Boolean
  Dim myTXDCMV As TXDCMV.MyData
  Dim myTXDCPP As TXDCPP.MyData
  Dim myTXDCSUM As TXDCSUM.MyData
  Dim myTXMCTL As TXMCTL.MyData
  Dim myTXMSRP As TXMSRP.MyData
  Dim myTXMSRPDEP As TXMSRPDEP.MyData

  Dim ds As DataSet = New DataSet
  Dim sw As StreamWriter
  Dim WrkMSRP As Integer
  'Declaration work fields, 9=MV, 25=Penalty
  Dim WrkSource As String
  Dim WrkOldValue9 As Integer
  Dim WrkValue9 As Integer
  Dim WrkOldNet9 As Integer
  Dim WrkNet9 As Integer
  Dim WrkOldValue25 As Integer
  Dim WrkValue25 As Integer
  Dim WrkOldNet25 As Integer
  Dim WrkNet25 As Integer

  'Screen
  Dim WrkGLYear As Integer
  Dim WrkPost As Boolean
  Dim WrkIncr As Decimal
  Dim WrkDecr As Decimal
  'Control File
  Dim WrkBookPct As Decimal
  Dim WrkMinValue As Integer
  Public Sub PrtReport()

    With MyFrmFixB
      WrkGLYear = .TxtGLYear.Text
      WrkPost = .ChkUpdate.Checked
      WrkIncr = 0
      WrkDecr = 0
      If .ChkIncr.Checked Then
        WrkIncr = 0.05
      Else
        WrkDecr = -0.05
      End If
    End With

    myTXDCMV = New TXDCMV.MyData(myDBConnect)
    myTXDCPP = New TXDCPP.MyData(myDBConnect)
    myTXDCSUM = New TXDCSUM.MyData(myDBConnect)
    myTXMCTL = New TXMCTL.MyData(myDBConnect)
    myTXMSRP = New TXMSRP.MyData(myDBConnect)
    myTXMSRPDEP = New TXMSRPDEP.MyData(myDBConnect)
    GetTXMCTL()
    GetDetail()
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
  Private Sub GetDetail()
    Dim WrkList As Integer
    Dim SaveList As Integer
    Dim WrkTValue9 As Integer
    Dim WrkTNet9 As Integer
    Dim WrkTValue25 As Integer
    Dim WrkTNet25 As Integer
    Dim I As Integer
    Dim Counter As Integer

    Counter = 0
    ds = myTXDCMV.GetByYear(WrkGLYear)
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    If MyFrmFixB.LblFilePath.Text <> "" Then
      sw = New StreamWriter(MyFrmFixB.LblFilePath.Text)
      sw.WriteLine(HeadingsCSV)
    End If
    SaveList = 0

ReadNext:
    For I = 0 To ds.Tables(0).Rows.Count - 1
      Counter = Counter + 1
      WrkValue9 = 0
      WrkSource = ""
      With ds.Tables(0).Rows(I)
        WrkList = .Item("list#")
        If SaveList <> WrkList And SaveList > 0 Then
          If WrkTValue9 > 0 Then
            WrkOldValue9 = 0
            WrkValue9 = 0
            WrkOldNet9 = 0
            WrkNet9 = 0
            myTXDCSUM.GetOneRecordP(SaveList, WrkGLYear, 9)
            If Not myTXDCSUM.RecordNotFound Then
              WrkOldValue9 = myTXDCSUM._VALUE
              WrkValue9 = WrkTValue9
              WrkOldNet9 = myTXDCSUM._NET
              WrkNet9 = WrkTNet9
            End If
            WrkMSRP = 0
            WrkOldValue25 = 0
            WrkValue25 = 0
            WrkOldNet25 = 0
            WrkNet25 = 0
            myTXDCSUM.GetOneRecordP(SaveList, WrkGLYear, 25)
            If Not myTXDCSUM.RecordNotFound Then
              WrkOldValue25 = myTXDCSUM._VALUE
              WrkValue25 = WrkTValue25 + myTXDCSUM._VALUE
              WrkOldNet25 = myTXDCSUM._NET
              WrkNet25 = WrkTNet25 + myTXDCSUM._NET
            End If
            If MyFrmFixB.LblFilePath.Text <> "" Then
              sw.WriteLine(DownloadCSV("TXDCSUM", SaveList, "", "", 0))
            End If
            If WrkPost Then
              UpdateTXDCSUM(SaveList, WrkGLYear, 9, WrkValue9, WrkNet9)
              UpdateTXDCSUM(SaveList, WrkGLYear, 25, WrkValue25, WrkNet25)
            End If
          End If
          WrkTValue9 = 0
          WrkTNet9 = 0
          WrkTValue25 = 0
          WrkTNet25 = 0
        End If
        WrkMSRP = .Item("msrp")
        WrkOldValue9 = .Item("VALUE")
        WrkValue9 = CalcValue(.Item("vyear"), WrkOldValue9)
        WrkValue9 = CalcMinValue(WrkValue9, WrkOldValue9)
        myTXMSRP.GetOneRecordP(Trim(.Item("VINNO")))
        If Not myTXMSRP.RecordNotFound Then
          WrkSource = Trim(myTXMSRP._OVSOURCE)
          If WrkSource <> "" Then
            WrkMSRP = myTXMSRP._OVMSRP
          End If
        End If
        WrkOldValue25 = 0
        WrkValue25 = 0
        WrkOldNet25 = 0
        WrkNet25 = 0
        WrkOldNet9 = WrkOldValue9 * WrkBookPct
        WrkNet9 = WrkValue9 * WrkBookPct
        myTXDCSUM.GetOneRecordP(WrkList, WrkGLYear, 25)
        If Not myTXDCSUM.RecordNotFound Then
          WrkOldValue25 = WrkOldNet9 * 0.25
          WrkValue25 = WrkNet9 * 0.25
          WrkOldNet25 = WrkOldNet9 * 0.25
          WrkNet25 = WrkNet9 * 0.25
        End If
        If WrkValue9 > 0 And WrkOldValue9 > 0 Then
          WrkTValue9 = WrkTValue9 + WrkValue9
          WrkTNet9 = WrkTNet9 + WrkNet9
          WrkTValue25 = WrkTValue25 + WrkValue25 - WrkOldValue25
          WrkTNet25 = WrkTNet25 + WrkNet25 - WrkOldNet25
          myTXDCPP.GetOneRecordP(WrkList, WrkGLYear)
          If MyFrmFixB.LblFilePath.Text <> "" Then
            sw.WriteLine(DownloadCSV("TXDCMV", WrkList, Trim(Replace(myTXDCPP._OWNAME, ",", "")), Trim(.Item("VINNO")), .Item("VYEAR")))
          End If
          If WrkPost And WrkValue9 <> WrkOldValue9 Then
            UpdateTXDCMV(WrkList, WrkGLYear, .Item("seqno"), WrkValue9)
          End If
        End If
        SaveList = WrkList
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
  End Sub
  Private Sub UpdateTXDCMV(ByVal WrkListNo As Integer, ByVal WrkYear As Integer, ByVal WrkSeqno As Integer, ByVal WrkValue As Integer)
    myTXDCMV.GetOneRecordP(WrkListNo, WrkYear, WrkSeqno)
    If myTXDCMV.RecordNotFound Then Exit Sub

    With myTXDCMV
      ._VALUE = WrkValue
      If ._MSRP = 0 Then
        ._MSRP = WrkMSRP
      End If
      .UpdateOneRecordP()
    End With
  End Sub
  Private Sub UpdateTXDCSUM(ByVal WrkListNo As Integer, ByVal WrkYear As Integer, ByVal WrkCode As Integer, ByVal WrkValue As Integer, ByVal WrkNet As Integer)
    myTXDCSUM.GetOneRecordP(WrkListNo, WrkYear, WrkCode)
    If myTXDCSUM.RecordNotFound Then Exit Sub

    With myTXDCSUM
      ._VALUE = WrkValue
      ._NET = WrkNet
      .UpdateOneRecordP()
    End With
  End Sub
  Private Function CalcValue(ByVal WrkYear As Integer, ByVal WrkOldValue As Integer) As Integer
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
    If WrkMSRP > 0 Then
      WrkDepr = WrkDepr + WrkIncr
      WrkValue = WrkMSRP * WrkDepr
    Else
      If WrkIncr > 0 Then
        WrkMSRP = WrkOldValue / WrkDepr
        WrkDepr = WrkDepr + WrkIncr
        WrkValue = WrkMSRP * WrkDepr
      Else
        WrkDepr = WrkDepr + WrkDecr
        WrkMSRP = WrkOldValue / WrkDepr
        WrkDepr = WrkDepr - WrkDecr
        WrkValue = WrkMSRP * WrkDepr
      End If
      WrkSource = "Calc"
      End If
      'WrkValue = MyUtils.Round10(WrkValue, "Normal")
      If WrkValue < WrkMinValue Then
      WrkValue = WrkMinValue
    End If
    Return WrkValue
  End Function
  Public Function CalcMinValue(ByVal WrkValue As Integer, ByVal WrkOldValue As Integer)
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
    sb.Append("File")
    sb.Append(CComma)
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
    sb.Append("Year")
    sb.Append(CComma)
    sb.Append("Old Value")
    sb.Append(CComma)
    sb.Append("New Value")
    sb.Append(CComma)
    sb.Append("Old Net")
    sb.Append(CComma)
    sb.Append("New Net")
    sb.Append(CComma)
    sb.Append("Old Value25")
    sb.Append(CComma)
    sb.Append("New Value25")
    sb.Append(CComma)
    sb.Append("Old Net25")
    sb.Append(CComma)
    sb.Append("New Net25")
    Return sb.ToString
  End Function
  Private Function DownloadCSV(ByVal WrkFile As String, ByVal WrkList As Integer, WrkName As String, WrkVinno As String,
   WrkVYear As Integer) As String
    Dim sb As StringBuilder
    Const CComma As String = ","

    sb = New StringBuilder
    sb.Append(WrkFile)
    sb.Append(CComma)
    sb.Append(WrkList)
    sb.Append(CComma)
    sb.Append(WrkName)
    sb.Append(CComma)
    sb.Append(WrkVinno)
    sb.Append(CComma)
    sb.Append(WrkSource)
    sb.Append(CComma)
    sb.Append(WrkMSRP)
    sb.Append(CComma)
    sb.Append(WrkVYear)
    sb.Append(CComma)
    sb.Append(WrkOldValue9)
    sb.Append(CComma)
    sb.Append(WrkValue9)
    sb.Append(CComma)
    sb.Append(WrkOldNet9)
    sb.Append(CComma)
    sb.Append(WrkNet9)
    sb.Append(CComma)
    sb.Append(WrkOldValue25)
    sb.Append(CComma)
    sb.Append(WrkValue25)
    sb.Append(CComma)
    sb.Append(WrkOldNet25)
    sb.Append(CComma)
    sb.Append(WrkNet25)
    Return sb.ToString
  End Function
End Module


