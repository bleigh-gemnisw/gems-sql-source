Imports System.IO
Imports System.Text
Module ImportData

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXREAAQ As TXREAAQ.MyData
  Dim myTXPHIN As TXPHIN.MyData

  Dim WrkSelYear As Integer
  Dim WrkUpdate As Boolean
  Dim ds As DataSet = New DataSet
  Dim sw As StreamWriter
  Public Sub Impdata()
    Dim Good As Boolean

    MyDBName = MyFrmFixB.TxtDBName.Text
    Good = Connect()

    If Not Good Then Exit Sub

    myTXREAAQ = New TXREAAQ.MyData(myDBConnect)
    myTXPHIN = New TXPHIN.MyData(myDBConnect)

    With MyFrmFixB
      WrkSelYear = CnvSng(.TxtYear.Text)
      WrkUpdate = .ChkUpdate.Checked
    End With
    GetDetail()

  End Sub
  Public Function Connect() As Boolean
    Dim Good As Boolean

    myDBConnect = New SQLConnect.DBConnection(MyDBName)
    myDBConnect.Open()
    Good = myDBConnect.IsConnected
    If Not Good Then
      MsgBox("Invalid database name", MsgBoxStyle.Critical, "Check database name")
    End If
    Return Good
  End Function
  Private Sub GetDetail()
    Dim sw As StreamWriter
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim I As Integer

    WrkQry = ""
    If WrkSelYear > 0 Then
      If WrkQry <> "" Then
        WrkQry = WrkQry & " and TXYEAR = " & WrkSelYear - 1
      Else
        WrkQry = "TXYEAR = " & WrkSelYear - 1
      End If
    End If
    WrkSort = ""
    Counter = 0

    ds = myTXREAAQ.GetQry(WrkSort, WrkQry, 0)
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    If MyFrmFixB.LblFilePath.Text <> "" Then
      sw = New StreamWriter(MyFrmFixB.LblFilePath.Text)
      sw.WriteLine(HeadingsCSV)
    End If

    For I = 0 To ds.Tables(0).Rows.Count - 1
      Counter = Counter + 1
      updatefile(I, WrkSelYear)
      updatefile(I, WrkSelYear + 1)
      If MyFrmFixB.LblFilePath.Text <> "" Then
        sw.WriteLine(DownloadCSV(I))
      End If

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
  Private Sub updatefile(ByVal I As Integer, ByVal WrkYear As Integer)
    Dim ds2 As DataSet = New DataSet
    Dim WrkListNo As Integer
    Dim WrkType As String
    Dim WrkGrs As Integer
    Dim WrkA1 As Integer
    Dim WrkA2 As Integer
    Dim WrkA3 As Integer
    Dim WrkA4 As Integer
    Dim WrkA5 As Integer
    Dim WrkA6 As Integer
    Dim WrkA7 As Integer

    With myTXPHIN
      WrkListNo = ds.Tables(0).Rows(I).Item("LIST#")
      WrkType = ds.Tables(0).Rows(I).Item("type")
      .GetOneRecordP(WrkListNo, WrkYear)
      If Not .RecordNotFound Then
        If WrkUpdate Then
          ._ORIA1 = ds.Tables(0).Rows(I).Item("ass1")
          ._ORIA2 = ds.Tables(0).Rows(I).Item("ass2")
          ._ORIA3 = ds.Tables(0).Rows(I).Item("ass3")
          ._ORIA4 = ds.Tables(0).Rows(I).Item("ass4")
          ._ORIA5 = ds.Tables(0).Rows(I).Item("ass5")
          ._ORIA6 = ds.Tables(0).Rows(I).Item("ass6")
          ._ORIA7 = ds.Tables(0).Rows(I).Item("ass7")
          ._ORIC1 = ds.Tables(0).Rows(I).Item("code1")
          ._ORIC2 = ds.Tables(0).Rows(I).Item("code2")
          ._ORIC3 = ds.Tables(0).Rows(I).Item("code3")
          ._ORIC4 = ds.Tables(0).Rows(I).Item("code4")
          ._ORIC5 = ds.Tables(0).Rows(I).Item("code5")
          ._ORIC6 = ds.Tables(0).Rows(I).Item("code6")
          ._ORIC7 = ds.Tables(0).Rows(I).Item("code7")
          'Handle rounding
          WrkGrs = ._CAPGRS + ._ADJGRS + ._AFTGRS
          WrkA1 = ._CAPA1 + ._ADJA1 + ._AFTA1
          WrkA2 = ._CAPA2 + ._ADJA2 + ._AFTA2
          WrkA3 = ._CAPA3 + ._ADJA3 + ._AFTA3
          WrkA4 = ._CAPA4 + ._ADJA4 + ._AFTA4
          WrkA5 = ._CAPA5 + ._ADJA5 + ._AFTA5
          WrkA6 = ._CAPA6 + ._ADJA6 + ._AFTA6
          WrkA7 = ._CAPA7 + ._ADJA7 + ._AFTA7
          ._FULA1 = If(WrkA2 = 0, ._FULGRS, Round((WrkA1 / WrkGrs) * ._FULGRS, 0))
          ._FULA2 = If(WrkA2 = 0, 0, If(WrkA3 = 0, ._FULGRS - ._FULA1, Round((WrkA2 / WrkGRS) * ._FULGRS, 0)))
          ._FULA3 = If(WrkA3 = 0, 0, If(WrkA4 = 0, ._FULGRS - ._FULA1 - ._FULA2, Round((WrkA3 / WrkGRS) * ._FULGRS, 0)))
          ._FULA4 = If(WrkA4 = 0, 0, If(WrkA5 = 0, ._FULGRS - ._FULA1 - ._FULA2 - ._FULA3, Round((WrkA4 / WrkGRS) * ._FULGRS, 0)))
          ._FULA5 = If(WrkA5 = 0, 0, If(WrkA6 = 0, ._FULGRS - ._FULA1 - ._FULA2 - ._FULA3 - ._FULA4, Round((WrkA5 / WrkGRS) * ._FULGRS, 0)))
          ._FULA6 = If(WrkA6 = 0, 0, If(WrkA7 = 0, ._FULGRS - ._FULA1 - ._FULA2 - ._FULA3 - ._FULA4 - ._FULA5, Round((WrkA6 / WrkGRS) * ._FULGRS, 0)))
          ._FULA7 = If(WrkA7 = 0, 0, ._FULGRS - ._FULA1 - ._FULA2 - ._FULA3 - ._FULA4 - ._FULA5 - ._FULA6)
          ._FULC1 = ._CAPC1
          ._FULC2 = ._CAPC2
          ._FULC3 = ._CAPC3
          ._FULC4 = ._CAPC4
          ._FULC5 = ._CAPC5
          ._FULC6 = ._CAPC6
          ._FULC7 = ._CAPC7
          .UpdateOneRecordP()
        End If
      End If
    End With

  End Sub
  Private Function HeadingsCSV() As String
    Dim sb As StringBuilder
    Const CComma As String = ","

    With myTXREAAQ
      sb = New StringBuilder
      sb.Append("ListNo")
      sb.Append(CComma)
      sb.Append("Year")
      sb.Append(CComma)
      sb.Append("Name")
    End With
    Return sb.ToString
  End Function
  Private Function DownloadCSV(ByVal I As Integer) As String
    Dim sb As StringBuilder
    Const CComma As String = ","
    Const cQuote As Char = Chr(34)

    With myTXREAAQ
      sb = New StringBuilder
      sb.Append(ds.Tables(0).Rows(I).Item("LIST#"))
      sb.Append(CComma)
      sb.Append(ds.Tables(0).Rows(I).Item("txyear"))
      sb.Append(CComma)
      sb.Append(cQuote)
      sb.Append(Trim(ds.Tables(0).Rows(I).Item("name")))
      sb.Append(cQuote)
    End With
    Return sb.ToString
  End Function
End Module
