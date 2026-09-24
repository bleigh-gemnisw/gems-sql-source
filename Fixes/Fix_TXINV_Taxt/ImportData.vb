Imports System.IO
Imports System.Text
Module ImportData

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXINV As TXINV.MyData
  Dim myTXHSTL4 As TXHSTL4.MyData

  Dim WrkSelYear As Integer
  Dim WrkSelType As String
  Dim WrkUpdate As Boolean
  Dim ds As DataSet = New DataSet
  Dim sw As StreamWriter
  Dim WrkTax As Decimal
  Dim OldTax As Decimal
  Dim WrkTax1 As Decimal
  Dim WrkTax2 As Decimal
  Dim WrkTax3 As Decimal
  Dim WrkTax4 As Decimal
  Dim WrkPaid As Decimal
  Dim OldPaid As Decimal
  Public Sub Impdata()
    Dim Good As Boolean

    MyDBName = MyFrmFixB.TxtDBName.Text
    Good = Connect()

    If Not Good Then Exit Sub

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXHSTL4 = New TXHSTL4.MyData(myDBConnect)

    With MyFrmFixB
      WrkSelType = .TxtType.Text
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
    If WrkSelType <> "" Then
      WrkQry = "TYPE='" & WrkSelType & "' and bald=0"
    End If
    If WrkSelYear > 0 Then
      If WrkQry <> "" Then
        WrkQry = WrkQry & " and YEAR = " & WrkSelYear
      Else
        WrkQry = "YEAR = " & WrkSelYear
      End If
    End If
    WrkSort = ""
    Counter = 0

    ds = myTXINVQ.GetQry(WrkSort, WrkQry, 0)
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
      updatefile(I)
      If MyFrmFixB.LblFilePath.Text <> "" Then
        If WrkTax <> OldTax Then
          sw.WriteLine(DownloadCSV(I))
        End If
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
  Private Sub updatefile(ByVal I As Integer)
    Dim ds2 As DataSet = New DataSet
    Dim WrkListNo As Integer
    Dim WrkYear As Integer
    Dim WrkType As String
    Dim WrkDiff As Decimal
    Dim J As Integer

    With myTXINV
      WrkListNo = ds.Tables(0).Rows(I).Item("LIST#")
      WrkType = ds.Tables(0).Rows(I).Item("type")
      WrkYear = ds.Tables(0).Rows(I).Item("year")
      OldTax = ds.Tables(0).Rows(I).Item("taxt")
      WrkTax1 = ds.Tables(0).Rows(I).Item("tax1")
      WrkTax2 = ds.Tables(0).Rows(I).Item("tax2")
      WrkTax3 = ds.Tables(0).Rows(I).Item("tx3rd")
      WrkTax4 = ds.Tables(0).Rows(I).Item("tx4th")
      WrkTax = 0
      WrkPaid = 0
      ds2 = myTXHSTL4.GetViewbyList(WrkListNo, WrkYear, WrkType, 0, 100)
      If ds2.Tables(0).Rows.Count = 0 Then 'Skip if no history
        OldTax = 0
        Exit Sub
      End If
      For J = 0 To ds2.Tables(0).Rows.Count - 1
        If ds2.Tables(0).Rows(J).Item("rcode") <> "V" And ds2.Tables(0).Rows(J).Item("rcode") <> "I" Then
          WrkPaid = WrkPaid + ds2.Tables(0).Rows(J).Item("pamt")
        End If
      Next
      If WrkPaid <= 0 Then 'Skip if negative or zero paid 
        OldTax = 0
        Exit Sub
      End If
      .GetOneRecordP(WrkListNo, WrkYear, WrkType)
      ._PAYREC = WrkPaid
      WrkTax = WrkPaid
      WrkDiff = OldTax - WrkTax
      ._TAXT = WrkTax
      If WrkDiff > 0 Then
        ' 1. Reduce Tax1
        Dim reduce1 As Decimal = Math.Min(WrkDiff, WrkTax1)
        WrkTax1 -= reduce1
        WrkDiff -= reduce1

        ' 2. Reduce Tax2 (if there's still more to reduce)
        If WrkDiff > 0 Then
          Dim reduce2 As Decimal = Math.Min(WrkDiff, WrkTax2)
          WrkTax2 -= reduce2
          WrkDiff -= reduce2
        End If

        ' 3. Reduce Tax3
        If WrkDiff > 0 Then
          Dim reduce3 As Decimal = Math.Min(WrkDiff, WrkTax3)
          WrkTax3 -= reduce3
          WrkDiff -= reduce3
        End If

        ' 4. Reduce Tax4
        If WrkDiff > 0 Then
          Dim reduce4 As Decimal = Math.Min(WrkDiff, WrkTax4)
          WrkTax4 -= reduce4
          WrkDiff -= reduce4
        End If
        ._TAX1 = WrkTax1
        ._TAX2 = WrkTax2
        ._TX3RD = WrkTax3
        ._TX4TH = WrkTax4
      End If
      ._PRF = "FixTaxt"
      If WrkUpdate And WrkTax <> OldTax Then
        .UpdateOneRecordP()
      End If
    End With

  End Sub
  Private Function HeadingsCSV() As String
    Dim sb As StringBuilder
    Const CComma As String = ","

    With myTXINVQ
      sb = New StringBuilder
      sb.Append("ListNo")
      sb.Append(CComma)
      sb.Append("Type")
      sb.Append(CComma)
      sb.Append("Year")
      sb.Append(CComma)
      sb.Append("Name")
      sb.Append(CComma)
      sb.Append("Old Tax")
      sb.Append(CComma)
      sb.Append("Tax")
      sb.Append(CComma)
      sb.Append("Diff Tax")
      sb.Append(CComma)
      sb.Append("Tax1")
      sb.Append(CComma)
      sb.Append("Tax2")
      sb.Append(CComma)
      sb.Append("Tax3")
      sb.Append(CComma)
      sb.Append("Tax4")
    End With
    Return sb.ToString
  End Function
  Private Function DownloadCSV(ByVal I As Integer) As String
    Dim sb As StringBuilder
    Const CComma As String = ","
    Const cQuote As Char = Chr(34)

    With myTXINVQ
      sb = New StringBuilder
      sb.Append(ds.Tables(0).Rows(I).Item("LIST#"))
      sb.Append(CComma)
      sb.Append(ds.Tables(0).Rows(I).Item("type"))
      sb.Append(CComma)
      sb.Append(ds.Tables(0).Rows(I).Item("year"))
      sb.Append(CComma)
      sb.Append(cQuote)
      sb.Append(Trim(ds.Tables(0).Rows(I).Item("name")))
      sb.Append(cQuote)
      sb.Append(CComma)
      sb.Append(OldTax)
      sb.Append(CComma)
      sb.Append(WrkTax)
      sb.Append(CComma)
      sb.Append(OldTax - WrkTax)
      sb.Append(CComma)
      sb.Append(WrkTax1)
      sb.Append(CComma)
      sb.Append(WrkTax2)
      sb.Append(CComma)
      sb.Append(WrkTax3)
      sb.Append(CComma)
      sb.Append(WrkTax4)
    End With
    Return sb.ToString
  End Function
End Module
