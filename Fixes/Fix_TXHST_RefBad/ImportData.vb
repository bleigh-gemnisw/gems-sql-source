Imports System.IO
Imports System.Text
Module ImportData

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXHSTQ As TXHSTQ.MyData
  Dim myTXHSTL4 As TXHSTL4.MyData

  Dim WrkUpdate As Boolean
  Dim ds As DataSet = New DataSet
  Dim WrkInt As Decimal
  Dim WrkDate As Date
  Public Sub Impdata()
    Dim Good As Boolean

    MyDBName = MyFrmFixB.TxtDBName.Text
    Good = Connect()

    If Not Good Then Exit Sub

    myTXHSTQ = New TXHSTQ.MyData(myDBConnect)
    myTXHSTL4 = New TXHSTL4.MyData(myDBConnect)

    With MyFrmFixB
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

    WrkQry = "ADJCD='R' and iamt=0"
    WrkSort = ""
    Counter = 0

    myTXHSTQ.OpenQry(WrkSort, WrkQry)
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    If MyFrmFixB.LblFilePath.Text <> "" Then
      sw = New StreamWriter(MyFrmFixB.LblFilePath.Text)
      sw.WriteLine(HeadingsCSV)
    End If

ReadNext:
    myTXHSTQ.ReadQry()
    If Not myTXHSTQ.IsEOF Then
      Counter = Counter + 1
      updatefile()
      If MyFrmFixB.LblFilePath.Text <> "" Then
        If WrkInt > 0 Then
          sw.WriteLine(DownloadCSV)
        End If
      End If

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
  Private Sub updatefile()
    Dim ds2 As DataSet = New DataSet
    Dim WrkPaid As Decimal
    Dim I As Integer

    WrkInt = 0
    With myTXHSTQ
      WrkPaid = Math.Abs(._PAMT)
      WrkDate = GetDBDate(._PDATE)
      ds2 = myTXHSTL4.GetViewbyList(._LISTNo, ._YEAR, ._TYPE, 0, 100)
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        If Trim(ds2.Tables(0).Rows(I).Item("adjcd")) = "" And ds2.Tables(0).Rows(I).Item("rcode") <> "V" And ds2.Tables(0).Rows(I).Item("rcode") <> "I" Then
          If WrkPaid = Math.Abs(ds2.Tables(0).Rows(I).Item("pamt")) Then
            WrkInt = ds2.Tables(0).Rows(I).Item("iamt")
            Exit Sub
          End If
        End If
      Next
    End With
  End Sub
  Private Function HeadingsCSV() As String
    Dim sb As StringBuilder
    Const CComma As String = ","

    With myTXHSTQ
      sb = New StringBuilder
      sb.Append("ListNo")
      sb.Append(CComma)
      sb.Append("Type")
      sb.Append(CComma)
      sb.Append("Year")
      sb.Append(CComma)
      sb.Append("Interest")
      sb.Append(CComma)
      sb.Append("Date")
    End With
    Return sb.ToString
  End Function
  Private Function DownloadCSV() As String
    Dim sb As StringBuilder
    Const CComma As String = ","

    With myTXHSTQ
      sb = New StringBuilder
      sb.Append(._LISTNo)
      sb.Append(CComma)
      sb.Append(._TYPE)
      sb.Append(CComma)
      sb.Append(._YEAR)
      sb.Append(CComma)
      sb.Append(WrkInt)
      sb.Append(CComma)
      sb.Append(WrkDate)
    End With
    Return sb.ToString
  End Function
End Module
