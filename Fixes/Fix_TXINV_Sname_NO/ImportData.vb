Imports System.IO
Imports System.Text
Module ImportData

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXINV As TXINV.MyData

  Dim WrkYear As Integer
  Dim WrkType As String
  Dim WrkUpdate As Boolean
  Dim WrkChg As Boolean
  Dim ds As DataSet = New DataSet
  Dim sw As StreamWriter
  Public Sub Impdata()
    Dim Good As Boolean

    MyDBName = MyFrmFixB.TxtDBName.Text
    Good = Connect()

    If Not Good Then Exit Sub

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)

    With MyFrmFixB
      WrkType = .TxtType.Text
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

    WrkQry = ""
    If WrkType <> "" Then
      WrkQry = "TYPE='" & WrkType & "'"
    End If
    WrkSort = ""
    Counter = 0

    myTXINVQ.OpenQry(WrkSort, WrkQry)
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    If MyFrmFixB.LblFilePath.Text <> "" Then
      sw = New StreamWriter(MyFrmFixB.LblFilePath.Text)
      sw.WriteLine(HeadingsCSV)
    End If

ReadNext:
    myTXINVQ.ReadQry()
    If Not myTXINVQ.IsEOF Then
      Counter = Counter + 1
      updatefile()
      If WrkChg And MyFrmFixB.LblFilePath.Text <> "" Then
        sw.WriteLine(DownloadCSV)
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
    WrkChg = False
    If Mid(myTXINVQ._SNAME, 1, 3) = "N/O" Then
      With myTXINV
        WrkChg = True
        .GetOneRecordP(myTXINVQ._LISTNo, myTXINVQ._YEAR, myTXINVQ._TYPE)
        ._SNAME = Mid(myTXINVQ._SNAME, 5, 31) & " N/O"
        If WrkUpdate Then
          .UpdateOneRecordP()
        End If
      End With
    End If
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
      sb.Append("SName")
      sb.Append(CComma)
      sb.Append("Old Sname")
    End With
    Return sb.ToString
  End Function
  Private Function DownloadCSV() As String
    Dim sb As StringBuilder
    Const CComma As String = ","

    With myTXINVQ
      sb = New StringBuilder
      sb.Append(._LISTNo)
      sb.Append(CComma)
      sb.Append(._TYPE)
      sb.Append(CComma)
      sb.Append(._YEAR)
      sb.Append(CComma)
      sb.Append(Trim(myTXINV._SNAME))
      sb.Append(CComma)
      sb.Append(Trim(._SNAME))
    End With
    Return sb.ToString
  End Function
End Module
