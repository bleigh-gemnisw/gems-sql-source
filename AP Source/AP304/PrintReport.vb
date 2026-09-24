Imports System.Text
Imports System.IO
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myVENDORQ As VENDORQ.myData

Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow
'General
Dim WrkAnd As String
Dim WrkOr As String


  Public Sub PrtReport()

  myVENDORQ = New VENDORQ.MyData()
  myVENDORQ.MyDBConn = myDBConnect

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
  End If

  GetDetail()
  If MyFrmAP304B.LblFilePath.Text <> String.Empty Then Exit Sub

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.wrkds = ds
  MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Vndnr", Type.GetType("System.String"))
      .Columns.Add("Vennm", Type.GetType("System.String"))
      .Columns.Add("Vaddr", Type.GetType("System.String"))
      .Columns.Add("Phone", Type.GetType("System.String"))
      .Columns.Add("Fax", Type.GetType("System.String"))
      .Columns.Add("Ornam", Type.GetType("System.String"))
      .Columns.Add("Oraddr", Type.GetType("System.String"))
      .Columns.Add("Pynam", Type.GetType("System.String"))
      .Columns.Add("Pyaddr", Type.GetType("System.String"))
      .Columns.Add("F1099", Type.GetType("System.String"))
      .Columns.Add("Taxid", Type.GetType("System.String"))
      .Columns.Add("Contn", Type.GetType("System.String"))
      .Columns.Add("Vemail", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

  End Sub
Private Sub GetDetail()
Dim sw As StreamWriter
Dim WrkQry As String
Dim WrkSort As String
Dim WrkSortBy As String
'Dim sb As StringBuilder
Dim WrkAddr As String
Dim WrkFull As Boolean
Dim WrkDownload As Boolean
Dim Counter As Integer

WrkSortBy = ""
WrkDownload = False
With MyFrmAP304B
  If .RbName.Checked Then
    WrkSortBy = "Name"
  End If
  If .RbNumeric.Checked Then
    WrkSortBy = "Numeric"
  End If
  If .RbFull.Checked Then
    WrkFull = True
  Else
    WrkFull = False
  End If
  If .LblFilePath.Text <> "" Then
    WrkDownload = True
  End If
End With

WrkAnd = " and "
WrkOr = " or "
WrkSort = ""
Counter = 0
Select Case WrkSortBy
Case "Numeric"
  WrkSort = "VNDNR"
Case "Name"
  WrkSort = "VENNM"
End Select

WrkQry = ""
myVENDORQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

If WrkDownload Then
  sw = New StreamWriter(MyFrmAP304B.LblFilePath.Text)
  sw.WriteLine(HeadingsCSV)
End If

ReadNext:
  myVENDORQ.ReadQry()
  If Not myVENDORQ.IsEOF Then
    With myVENDORQ
      Counter = Counter + 1
      If WrkDownload Then
        sw.WriteLine(DownloadCSV)
      Else
        If Mid(._VNDNR, 1, 1) = "*" Then GoTo NextRec
        dr = ds.Tables(0).NewRow
        dr.Item("vndnr") = Trim(._VNDNR)
        dr.Item("vennm") = Trim(._VENNM)
        WrkAddr = Trim(._VADD1)
        If Trim(._VADD2) <> "" Then
          WrkAddr = WrkAddr & ", " & Trim(._VADD2)
        End If
        If Trim(._VADD3) <> "" Then
          WrkAddr = WrkAddr & ", " & Trim(._VADD3)
        End If
        If Trim(._VADD4) <> "" Then
          WrkAddr = WrkAddr & ", " & Trim(._VADD4)
        End If
        If Trim(._VZIP) <> "" Then
          WrkAddr = WrkAddr & ", " & Trim(._VZIP)
        End If
        If Trim(._VZIPE) <> "" Then
          WrkAddr = WrkAddr & "-" & Trim(._VZIPE)
        End If
        dr.Item("vaddr") = WrkAddr
        If ._VPHON > 0 Then
          dr.Item("phone") = Format(._VPHON, "###-###-####")
        End If
        If ._FAXNO > 0 Then
          dr.Item("fax") = Format(._FAXNO, "###-###-####")
        End If
        dr.Item("ornam") = Trim(._ORNAM)
        WrkAddr = Trim(._ORAD1)
        If Trim(._ORAD2) <> "" Then
          WrkAddr = WrkAddr & ", " & Trim(._ORAD2)
        End If
        If Trim(._ORAD3) <> "" Then
          WrkAddr = WrkAddr & ", " & Trim(._ORAD3)
        End If
        If Trim(._ORAD4) <> "" Then
          WrkAddr = WrkAddr & ", " & Trim(._ORAD4)
        End If
        If Trim(._OZIP) <> "" Then
          WrkAddr = WrkAddr & ", " & Trim(._OZIP)
        End If
        If Trim(._OZIPE) <> "" Then
          WrkAddr = WrkAddr & "-" & Trim(._OZIPE)
        End If
        dr.Item("oraddr") = WrkAddr
        dr.Item("pynam") = Trim(._PYNAM)
        WrkAddr = Trim(._PYAD1)
        If Trim(._PYAD2) <> "" Then
          WrkAddr = WrkAddr & ", " & Trim(._PYAD2)
        End If
        If Trim(._PYAD3) <> "" Then
          WrkAddr = WrkAddr & ", " & Trim(._PYAD3)
        End If
        If Trim(._PYAD4) <> "" Then
          WrkAddr = WrkAddr & ", " & Trim(._PYAD4)
        End If
        If Trim(._PYZIP) <> "" Then
          WrkAddr = WrkAddr & ", " & Trim(._PYZIP)
        End If
        If Trim(._PYZIPE) <> "" Then
          WrkAddr = WrkAddr & "-" & Trim(._PYZIPE)
        End If
        dr.Item("pyaddr") = WrkAddr
        dr.Item("F1099") = Trim(._F1099)
        If ._TAXID > 0 Then
          dr.Item("taxid") = Trim(._TAXID)
        Else
          dr.Item("taxid") = ""
        End If
          dr.Item("contn") = Trim(._CONTN)
          dr.Item("vemail") = Trim(._VEMAIL)
          ds.Tables(0).Rows.Add(dr)
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

If WrkDownload Then
  sw.Flush()
  sw.Close()
End If

myFrmProgress.Close()
myVENDORQ.CloseFile()

End Sub
Private Function DownloadCSV() As String
  Dim sb As StringBuilder
  Dim WrkComma As String
  Dim WrkQuote As String

  WrkComma = ","
  WrkQuote = Chr(34)

  With myVENDORQ
    sb = New StringBuilder
    sb.Append(WrkQuote)
    sb.Append(Trim(._VNDNR))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._VENNM))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._VADD1))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._VADD2))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._VADD3))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._VADD4))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._VZIP))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._VZIPE))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    If ._VPHON > 0 Then
      sb.Append(Format(._VPHON, "###-###-####"))
    End If
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    If ._FAXNO > 0 Then
      sb.Append(Format(._FAXNO, "###-###-####"))
    End If
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._ORNAM))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._ORAD1))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._ORAD2))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._ORAD3))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._ORAD4))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._OZIP))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._OZIPE))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._PYNAM))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._PYAD1))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._PYAD2))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._PYAD3))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._PYAD4))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._PYZIP))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._PYZIPE))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._F1099))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    If ._TAXID > 0 Then
      sb.Append(Trim(._TAXID))
    End If
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._CONTN))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._VEMAIL))
      sb.Append(WrkQuote)
    End With
  Return sb.ToString
End Function
Private Function HeadingsCSV() As String
  Dim sb As StringBuilder
  Dim WrkComma As String

  WrkComma = ","
  sb = New StringBuilder
  sb.Append("Vendor No")
  sb.Append(WrkComma)
  sb.Append("Vendor Name")
  sb.Append(WrkComma)
  sb.Append("Address 1")
  sb.Append(WrkComma)
  sb.Append("Address 2")
  sb.Append(WrkComma)
  sb.Append("Address 3")
  sb.Append(WrkComma)
  sb.Append("Address 4")
  sb.Append(WrkComma)
  sb.Append("Zip")
  sb.Append(WrkComma)
  sb.Append("Zip4")
  sb.Append(WrkComma)
  sb.Append("Phone")
  sb.Append(WrkComma)
  sb.Append("Fax")
  sb.Append(WrkComma)
  sb.Append("Order From")
  sb.Append(WrkComma)
  sb.Append("Order Address 1")
  sb.Append(WrkComma)
  sb.Append("Order Address 2")
  sb.Append(WrkComma)
  sb.Append("Order Address 3")
  sb.Append(WrkComma)
  sb.Append("Order Address 4")
  sb.Append(WrkComma)
  sb.Append("Order Zip")
  sb.Append(WrkComma)
  sb.Append("Order Zip4")
  sb.Append(WrkComma)
  sb.Append("Pay To")
  sb.Append(WrkComma)
  sb.Append("Pay Address 1")
  sb.Append(WrkComma)
  sb.Append("Pay Address 2")
  sb.Append(WrkComma)
  sb.Append("Pay Address 3")
  sb.Append(WrkComma)
  sb.Append("Pay Address 4")
  sb.Append(WrkComma)
  sb.Append("Pay Zip")
  sb.Append(WrkComma)
  sb.Append("Pay Zip4")
  sb.Append(WrkComma)
  sb.Append("F1099")
  sb.Append(WrkComma)
  sb.Append("Tax ID")
  sb.Append(WrkComma)
    sb.Append("Contact Name")
    sb.Append(WrkComma)
    sb.Append("Email")
    Return sb.ToString
End Function
End Module
