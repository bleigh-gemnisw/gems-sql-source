Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myAPEHSTQ As APEHSTQ.MyData
  Dim myAPCTRL As APCTRL.MyData
  Dim myVENDOR As VENDOR.MyData
  Dim myAP1099P As AP1099P.MyData
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkYear As Integer
  Dim WrkAnd As String
  Dim WrkOr As String

  Public Sub PrtReport()

    myAPEHSTQ = New APEHSTQ.MyData()
    myAPEHSTQ.MyDBConn = myDBConnect
    myAPCTRL = New APCTRL.MyData(myDBConnect)
    myVENDOR = New VENDOR.MyData()
    myVENDOR.MyDBConn = myDBConnect
    myAP1099P = New AP1099P.MyData()
    myAP1099P.MyDBConn = myDBConnect

    With MyFrmAP702B
      WrkYear = MyUtils.CnvSng(.TxtYear.Text)
    End With

    If ds.Tables.Count = 0 Then
      BuildDS(ds)
    Else
      ds.Clear()
    End If
    myAP1099P.DeleteAllRecords()
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .Show()
    End With
  End Sub
  Private Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("vndnr", Type.GetType("System.String"))
      .Columns.Add("vennm", Type.GetType("System.String"))
      .Columns.Add("vadd1", Type.GetType("System.String"))
      .Columns.Add("vadd2", Type.GetType("System.String"))
      .Columns.Add("vadd3", Type.GetType("System.String"))
      .Columns.Add("vadd4", Type.GetType("System.String"))
      .Columns.Add("pynam", Type.GetType("System.String"))
      .Columns.Add("pyad1", Type.GetType("System.String"))
      .Columns.Add("pyad2", Type.GetType("System.String"))
      .Columns.Add("pyad3", Type.GetType("System.String"))
      .Columns.Add("pyad4", Type.GetType("System.String"))
      .Columns.Add("ataxid", Type.GetType("System.String"))
      .Columns.Add("amtpd", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim AddrLine() As String
    Dim PayeeLine() As String
    Dim WrkFrom As Integer
    Dim WrkTo As Integer
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkGroup As String
    Dim WrkZip As String
    Dim Counter As Integer
    If myDBConnect.ServerName = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkFrom = WrkYear & "0101"
    WrkTo = WrkYear & "1231"
    WrkSort = "VNDNR"
    WrkGroup = "VNDNR"
    WrkQry = "PPDT8 >= " & WrkFrom & WrkAnd & "PPDT8 <=" & WrkTo &
  WrkAnd & "RECNO = 0" & WrkAnd & "AVOID<>'V'" & WrkAnd & "F1099='Y'"

    myAPEHSTQ.SumPaidQry(WrkGroup, WrkSort, WrkQry)
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0
    myAPCTRL.GetOneRecordP(1)

ReadNext:
    myAPEHSTQ.ReadQrySum()
    If Not myAPEHSTQ.IsEOF Then
      Counter = Counter + 1
      'Omit under Yearly limit
      If myAPCTRL._YLIM > myAPEHSTQ._SUMAMTPD Then
        GoTo NextRec
      End If
      myVENDOR.GetOneRecordP(myAPEHSTQ._VNDNR)
      AddrLine = SetVndrAddrLine(myVENDOR._VADD1, myVENDOR._VADD2, myVENDOR._VADD3, myVENDOR._VADD4,
     myVENDOR._VZIP, myVENDOR._VZIPE)
      PayeeLine = SetVndrAddrLine(myVENDOR._PYAD1, myVENDOR._PYAD2, myVENDOR._PYAD3, myVENDOR._PYAD4,
     myVENDOR._PYZIP, myVENDOR._PYZIPE)
      'Create Report
      With myAPEHSTQ
        dr = ds.Tables(0).NewRow
        dr.Item("vndnr") = ._VNDNR
        dr.Item("vennm") = myVENDOR._VENNM
        dr.Item("vadd1") = AddrLine(0)
        dr.Item("vadd2") = AddrLine(1)
        dr.Item("vadd3") = AddrLine(2)
        dr.Item("vadd4") = AddrLine(3)
        dr.Item("pynam") = myVENDOR._PYNAM
        dr.Item("pyad1") = PayeeLine(0)
        dr.Item("pyad2") = PayeeLine(1)
        dr.Item("pyad3") = PayeeLine(2)
        dr.Item("pyad4") = PayeeLine(3)
        dr.Item("ataxid") = Format(myVENDOR._TAXID, "000000000")
        dr.Item("amtpd") = ._SUMAMTPD
        ds.Tables(0).Rows.Add(dr)
      End With

      With myAP1099P
        .GetOneRecordP(WrkYear, myAPEHSTQ._VNDNR)
        ._AFEDID = Format(myAPCTRL._FEDID, "000000000")
        ._AMISAM = myAPEHSTQ._SUMAMTPD
        ._APADR1 = Trim(myAPCTRL._FADD1)
        If myAPCTRL._FZIP > 99999 Then
          WrkZip = Format(myAPCTRL._FZIP, "00000-0000")
        Else
          WrkZip = Format(myAPCTRL._FZIP, "00000")
        End If
        If Trim(myAPCTRL._FADD2) <> "" Then
          ._APADR2 = Trim(myAPCTRL._FADD2)
          ._APADR3 = Trim(myAPCTRL._FCITY) & " " & myAPCTRL._FSTATE & " " & WrkZip
        Else
          ._APADR2 = Trim(myAPCTRL._FCITY) & " " & myAPCTRL._FSTATE & " " & WrkZip
          ._APADR3 = ""
        End If
        ._APNAME = Trim(myAPCTRL._FNAME)
        ._APPHON = ""
        ._ARACCT = myAPEHSTQ._VNDNR
        ._ARADR1 = AddrLine(0)
        ._ARADR2 = AddrLine(1)
        ._ARADR3 = AddrLine(2)
        ._ARADR4 = AddrLine(3)
        ._ARNAME = Trim(myVENDOR._VENNM)
        ._ASTCDE = myAPCTRL._FSTATE
        ._ASTEID = Format(myAPCTRL._STEID, "000000000")
        ._ATAXID = Format(myVENDOR._TAXID, "000000000")
        ._AYEAR = WrkYear
        .AddOneRecordP()
        .GetOneRecordP(0, "")
        If Not .RecordNotFound Then
          MsgBox(myAPEHSTQ._VNDNR & " bad data")
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

    myFrmProgress.Close()
    myAPEHSTQ.CloseFile()

  End Sub
  Public Function SetVndrAddrLine(ByVal Add1 As String, ByVal Add2 As String,
   ByVal Add3 As String, ByVal Add4 As String, ByVal Zip5 As String,
   ByVal Zip4 As String) As String()
    'Returns Address as string array. Blank lines are stripped out. 
    Dim AddrLine(3) As String
    Dim sb As StringBuilder
    Dim I As Integer

    Add1 = Trim(Add1)
    Add2 = Trim(Add2)
    Add3 = Trim(Add3)
    Add4 = Trim(Add4)
    Zip5 = Trim(Zip5)
    Zip4 = Trim(Zip4)

    AddrLine(I) = Add1
    If Add2 <> "" Then
      I = I + 1
      AddrLine(I) = Add2
    End If
    If Add3 <> "" Then
      I = I + 1
      AddrLine(I) = Add3
    End If
    If Add4 <> "" Then
      I = I + 1
      AddrLine(I) = Add4
    End If
    If Zip5 <> "" Then
      sb = New StringBuilder
      sb.Append(Zip5)
      If Zip4 <> "" Then
        sb.Append("-")
        sb.Append(Zip4)
      End If
      AddrLine(I) = AddrLine(I) & " " & sb.ToString
    End If
    For I = 2 To 3
      If AddrLine(I) Is Nothing Then
        AddrLine(I) = ""
      End If
    Next
    Return AddrLine

  End Function
End Module
