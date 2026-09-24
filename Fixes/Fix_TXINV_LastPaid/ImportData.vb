Imports System.IO
Imports System.Text
Module ImportData

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXINV As TXINV.MyData
  Dim myTXHSTL4 As TXHSTL4.MyData

  Dim WrkYear As Integer
  Dim WrkUpdate As Boolean
  Dim ds As DataSet = New DataSet
  Dim sw As StreamWriter
  Dim WrkPaidDate As Integer
  Public Sub Impdata()
    Dim Good As Boolean

    MyDBName = MyFrmFixB.TxtDBName.Text
    Good = Connect()

    If Not Good Then Exit Sub

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXHSTL4 = New TXHSTL4.MyData(myDBConnect)

    With MyFrmFixB
      WrkYear = CnvSng(.TxtYear.Text)
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
    Dim I As Integer

    WrkQry = "PAYREC > 0 and TXIDT = 0"
    If WrkYear > 0 Then
      WrkQry = WrkQry & " and YEAR = " & WrkYear
    End If
    WrkSort = ""

    ds = myTXINVQ.GetQry(WrkSort, WrkQry, 0)
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
      updatefile(ds.Tables(0).Rows(I).Item("list#"), ds.Tables(0).Rows(I).Item("year"), ds.Tables(0).Rows(I).Item("type"))
      If WrkPaidDate > 0 And MyFrmFixB.LblFilePath.Text <> "" Then
        sw.WriteLine(DownloadCSV(ds.Tables(0).Rows(I).Item("list#"), ds.Tables(0).Rows(I).Item("year"), ds.Tables(0).Rows(I).Item("type")))
      End If

NextRec:
      With myFrmProgress
        WrkPct = (I / 10) Mod 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .LblMsg.Text = "Records processed: " & I
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
  Private Sub updatefile(ByVal ListNo As Integer, Year As Integer, Type As String)
    Dim ds2 As DataSet = New DataSet
    Dim I As Integer

    WrkPaidDate = 0
    With myTXINV
      .GetOneRecordP(ListNo, Year, Type)
      ds2 = myTXHSTL4.GetViewDscList(._LISTNo, ._YEAR, ._TYPE, 99999999, 100)
      If ds2.Tables(0).Rows.Count = 0 Then Exit Sub
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        If ds2.Tables(0).Rows(I).Item("rcode") <> "V" And ds2.Tables(0).Rows(I).Item("rcode") <> "I" And Trim(ds2.Tables(0).Rows(I).Item("adjcd")) = "" Then
          If ds2.Tables(0).Rows(I).Item("pamt") > 0 Then
            WrkPaidDate = ds2.Tables(0).Rows(I).Item("pdate")
            Exit For
          End If
        End If
      Next
      ._TXIDT = WrkPaidDate
      If WrkUpdate And WrkPaidDate > 0 Then
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
      sb.Append("Paid Date")
    End With
    Return sb.ToString
  End Function
  Private Function DownloadCSV(ByVal ListNo As Integer, Year As Integer, Type As String) As String
    Dim sb As StringBuilder
    Const CComma As String = ","

    sb = New StringBuilder
    sb.Append(ListNo)
    sb.Append(CComma)
    sb.Append(Type)
    sb.Append(CComma)
    sb.Append(Year)
    sb.Append(CComma)
    sb.Append(WrkPaidDate)
    Return sb.ToString
  End Function
End Module
