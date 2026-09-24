Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXINVQ As TXINVQ.myData
Dim myTXREALCQ As TXREALCQ.myData
Dim ds As DataSet = New DataSet
Dim DsFile As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkBanksv As String
Dim WrkBankCd As String
Dim WrkGLYear As Integer
Dim WrkBefore As Boolean
Dim WrkAnd As String
Dim WrkOr As String
Public Sub PrtReport()

	myTXINVQ = New TXINVQ.mydata(MyDBConnect)
	myTXREALCQ = New TXREALCQ.mydata(MyDBConnect)

  With MyFrmTX505B
    WrkBanksv = .TxtBankSv.Text
    WrkBankCd = .TxtBankCd.Text
    WrkBefore = .RbBefore.Checked
    WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
  End With

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.wrkds = ds
  MyCrViewer.Show()

End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("Banksv", Type.GetType("System.String"))
      .Columns.Add("Bankcd", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Sname", Type.GetType("System.String"))
      .Columns.Add("AddrCtyST", Type.GetType("System.String"))
      .Columns.Add("Location", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
Private Sub GetDetail()
Dim sb As StringBuilder
Dim WrkSort As String
Dim WrkQry As String
Dim I As Integer
Dim SaveBankSv As String
Dim SaveBankCd As String

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

WrkQry = ""
SaveBankCd = String.Empty
SaveBankSv = String.Empty
If WrkBefore Then
  If WrkBanksv <> String.Empty Then
    WrkQry = "BKSV=" & MyUtils.Quo(WrkBanksv)
  End If
Else
  If WrkBanksv <> String.Empty Then
    WrkQry = "BKSR=" & MyUtils.Quo(WrkBanksv)
  End If
End If
If WrkBankCd <> String.Empty Then
  If WrkQry = "" Then
    WrkQry = "BKCD=" & MyUtils.Quo(WrkBankCd)
  Else
    WrkQry = WrkQry & WrkAnd & "BKCD=" & MyUtils.Quo(WrkBankCd)
  End If
Else
  If WrkQry = "" Then
    WrkQry = "BKCD <> '  '"
  Else
    WrkQry = WrkQry & WrkAnd & "BKCD <> '  '"
  End If
End If
If Not WrkBefore Then
  WrkQry = WrkQry & WrkAnd & "icode<>'I'" & WrkAnd & "TYPE='R'" & WrkAnd & "YEAR=" & WrkGLYear
End If

If WrkBefore Then
  WrkSort = "BKSV, BKCD, NAME, LIST#"
  DsFile = myTXREALCQ.GetQry(WrkSort, WrkQry, 0)
Else
  WrkSort = "BKSR, BKCD, NAME, LIST#"
  DsFile = myTXINVQ.GetQry(WrkSort, WrkQry, 0)
End If
If DsFile.Tables(0).Rows.Count = 0 Then GoTo CloseFiles

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

For I = 0 To (DsFile.Tables(0).Rows.Count - 1)
  With DsFile.Tables(0).Rows(I)
    If WrkBefore Then
      If SaveBankSv <> .Item("bksv") Then
        WrkBanksv = .Item("bksv") & "-" & GetTXBanksServ(.Item("bksv"))
      End If
    Else
      If SaveBankSv <> .Item("bksr") Then
        WrkBanksv = .Item("bksr") & "-" & GetTXBanksServ(.Item("bksr"))
      End If
    End If
    If SaveBankCd <> .Item("bkcd") Then
      WrkBankCd = .Item("bkcd") & "-" & GetTXBanksDesc(.Item("bkcd"))
    End If
    If WrkBefore Then
      SaveBankSv = .Item("bksv")
    Else
      SaveBankSv = .Item("bksr")
    End If
    SaveBankCd = .Item("bkcd")
    dr = ds.Tables(0).NewRow
    dr.Item("banksv") = WrkBanksv
    dr.Item("bankcd") = WrkBankCd
    dr.Item("listno") = .Item("list#")
    dr.Item("name") = .Item("name")
    dr.Item("sname") = .Item("sname")
    sb = New StringBuilder
    sb.Append(.Item("add1"))
    If .Item("add2") <> String.Empty Then
      sb.Append(" ")
      sb.Append(.Item("add2"))
    End If
    sb.Append(" ")
    sb.Append(.Item("city"))
    sb.Append(" ")
    sb.Append(.Item("state"))
    sb.Append(" ")
    sb.Append(Format(.Item("zip5"), "00000"))
    If .Item("zip4") > 0 Then
      sb.Append("-")
      sb.Append(Format(.Item("zip4"), "0000"))
    End If
    dr.Item("addrctyst") = sb.ToString
    sb = Nothing
    dr.Item("location") = Trim(.Item("loc#")) & " " & .Item("loc")
  End With
  ds.Tables(0).Rows.Add(dr)
NextRec:
With myFrmProgress
  WrkPct = ((I + 1) / DsFile.Tables(0).Rows.Count) * 100
  If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .Refresh()
    SavePct = WrkPct
    Application.DoEvents()
  End If
End With
Next

myFrmProgress.Close()

CloseFiles:
myTXREALCQ.CloseFile()
myTXINVQ.CloseFile()

End Sub
End Module






