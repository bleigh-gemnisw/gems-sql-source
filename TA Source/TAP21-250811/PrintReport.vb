Imports System.Text
Module PrintReport

Dim myTXDCPPQ As TXDCPPQ.myData
Dim myTXDCFRM As TXDCFRM.myData
Dim myTXDCCD As TXDCCD.myData
Dim myTXDCDEP As TXDCDEP.myData
Dim myTXDCEX As TXDCEX.myData
Dim myTXDMCD As TXDMCD.myData
Dim myTXDMDEP As TXDMDEP.myData
Dim myTXDVCD As TXDVCD.myData

Dim WrkYear As Integer
Dim WrkAllFiles As Boolean
Dim WrkMsg As String
  Public Sub PrtReport()
  Dim WrkSort As String
  Dim WrkQry As String
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim Counter As Integer

  myTXDCPPQ = New TXDCPPQ.mydata(MyDBConnect)
  myTXDCFRM = New TXDCFRM.mydata(MyDBConnect)
  myTXDCCD = New TXDCCD.mydata(MyDBConnect)
	myTXDCDEP = New TXDCDEP.mydata(MyDBConnect)
	myTXDCEX = New TXDCEX.mydata(MyDBConnect)
	myTXDMCD = New TXDMCD.mydata(MyDBConnect)
	myTXDMDEP = New TXDMDEP.mydata(MyDBConnect)
	myTXDVCD = New TXDVCD.mydata(MyDBConnect)

	With MyFrmTAP21B
    WrkYear = MyUtils.CnvSng(.TxtYear.Text)
    WrkAllFiles = .RbAllFiles.Checked
	End With

  With myTXDCFRM
    .GetOneRecordP(1)
    ._CURRYR = WrkYear
    .UpdateOneRecordP()
  End With
  CopyTables()
  Counter = 0
  WrkSort = ""
  If WrkAllFiles Then
    WrkQry = "YEAR =" & WrkYear - 1
    myTXDCPPQ.OpenQry(WrkSort, WrkQry)
    MyFrmProgress = New FrmProgress
    MyFrmProgress.Show()
    MyFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXDCPPQ.ReadQry()
    If Not myTXDCPPQ.IsEOF Then
      With myTXDCPPQ
        Counter = Counter + 1
        CopyRecords(._LISTNO, WrkYear)
      End With

NextRec:
      With MyFrmProgress
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

    MyFrmProgress.Close()
    myTXDCPPQ.CloseFile()
  End If

  MsgBox(WrkMsg, MsgBoxStyle.Information, "Copy Files to New Year " & WrkYear & " completed")
  MyFrmTAP21B.TxtYear.Text = String.Empty
End Sub
Private Sub CopyTables()
Dim dsFile As DataSet = New DataSet
Dim sb As StringBuilder
Dim WrkPrevYear As Integer
Dim I As Integer
Dim WrkCopied As Integer
Dim WrkSkipped As Integer

sb = New StringBuilder
WrkPrevYear = WrkYear - 1
WrkCopied = 0
WrkSkipped = 0

dsFile = myTXDCCD.GetAllYear(WrkPrevYear)
If dsFile.Tables(0).Rows.Count > 0 Then
  For I = 0 To (dsFile.Tables(0).Rows.Count - 1)
    With myTXDCCD
      .GetOneRecordP(WrkYear, dsFile.Tables(0).Rows(I).Item("code"), dsFile.Tables(0).Rows(I).Item("ltr"))
      If .RecordNotFound Then
        ._YEAR = WrkYear
        ._CODE = dsFile.Tables(0).Rows(I).Item("code")
        ._LTR = dsFile.Tables(0).Rows(I).Item("ltr")
        ._ASCODE = dsFile.Tables(0).Rows(I).Item("ascode")
        ._ASPCT = dsFile.Tables(0).Rows(I).Item("aspct")
        ._DECODE = dsFile.Tables(0).Rows(I).Item("decode")
        ._DESC = dsFile.Tables(0).Rows(I).Item("desc")
        .AddOneRecordP()
        WrkCopied = WrkCopied + 1
      Else
        WrkSkipped = WrkSkipped + 1
      End If
    End With
  Next
  myTXDCCD.CloseFile()
End If
sb.Append("Property Codes: " & WrkCopied & " Copied, " & WrkSkipped & " Skipped" & vbCrLf)
dsFile.Clear()
WrkCopied = 0
WrkSkipped = 0

dsFile = myTXDCDEP.GetAllYear(WrkPrevYear)
If dsFile.Tables(0).Rows.Count > 0 Then
  For I = 0 To (dsFile.Tables(0).Rows.Count - 1)
    With myTXDCDEP
      .GetOneRecordP(WrkYear, dsFile.Tables(0).Rows(I).Item("decode"), dsFile.Tables(0).Rows(I).Item("yearno"))
      If .RecordNotFound Then
        ._YEAR = WrkYear
        ._DECODE = dsFile.Tables(0).Rows(I).Item("decode")
        ._YEARNO = dsFile.Tables(0).Rows(I).Item("yearno")
        ._PCT = dsFile.Tables(0).Rows(I).Item("pct")
        ._PRIOR = dsFile.Tables(0).Rows(I).Item("prior")
        ._PROPCT = dsFile.Tables(0).Rows(I).Item("propct")
        .AddOneRecordP()
        WrkCopied = WrkCopied + 1
      Else
        WrkSkipped = WrkSkipped + 1
      End If
    End With
  Next
  myTXDCDEP.CloseFile()
End If
sb.Append("Depreciation Codes: " & WrkCopied & " Copied, " & WrkSkipped & " Skipped" & vbCrLf)
dsFile.Clear()
WrkCopied = 0
WrkSkipped = 0

dsFile = myTXDCEX.GetAllYear(WrkPrevYear)
If dsFile.Tables(0).Rows.Count > 0 Then
   For I = 0 To (dsFile.Tables(0).Rows.Count - 1)
    With myTXDCEX
      .GetOneRecordP(WrkYear, dsFile.Tables(0).Rows(I).Item("code"))
      If .RecordNotFound Then
        ._YEAR = WrkYear
        ._CODE = dsFile.Tables(0).Rows(I).Item("code")
        ._DESC = dsFile.Tables(0).Rows(I).Item("desc")
        ._EXVAL = dsFile.Tables(0).Rows(I).Item("exval")
        .AddOneRecordP()
        WrkCopied = WrkCopied + 1
      Else
        WrkSkipped = WrkSkipped + 1
      End If
    End With
  Next
  myTXDCEX.CloseFile()
End If
sb.Append("Exemptions: " & WrkCopied & " Copied, " & WrkSkipped & " Skipped" & vbCrLf)
dsFile.Clear()
WrkCopied = 0
WrkSkipped = 0

dsFile = myTXDMCD.GetAllYear(WrkPrevYear)
If dsFile.Tables(0).Rows.Count > 0 Then
  For I = 0 To (dsFile.Tables(0).Rows.Count - 1)
    With myTXDMCD
      .GetOneRecordP(WrkYear, dsFile.Tables(0).Rows(I).Item("code"), dsFile.Tables(0).Rows(I).Item("ltr"))
      If .RecordNotFound Then
        ._YEAR = WrkYear
        ._CODE = dsFile.Tables(0).Rows(I).Item("code")
        ._LTR = dsFile.Tables(0).Rows(I).Item("ltr")
        ._ASCODE = dsFile.Tables(0).Rows(I).Item("ascode")
        ._ASPCT = dsFile.Tables(0).Rows(I).Item("aspct")
        .AddOneRecordP()
        WrkCopied = WrkCopied + 1
      Else
        WrkSkipped = WrkSkipped + 1
      End If
    End With
  Next
  myTXDMCD.CloseFile()
End If
sb.Append("MFG & Equip Property Codes: " & WrkCopied & " Copied, " & WrkSkipped & " Skipped" & vbCrLf)
dsFile.Clear()
WrkCopied = 0
WrkSkipped = 0

dsFile = myTXDMDEP.GetAllYear(WrkPrevYear)
If dsFile.Tables(0).Rows.Count > 0 Then
  For I = 0 To (dsFile.Tables(0).Rows.Count - 1)
    With myTXDMDEP
      .GetOneRecordP(WrkYear, dsFile.Tables(0).Rows(I).Item("yearno"))
      If .RecordNotFound Then
        ._YEAR = WrkYear
        ._YEARNO = dsFile.Tables(0).Rows(I).Item("yearno")
        ._PCT = dsFile.Tables(0).Rows(I).Item("pct")
        .AddOneRecordP()
        WrkCopied = WrkCopied + 1
      Else
        WrkSkipped = WrkSkipped + 1
      End If
    End With
  Next
  myTXDMDEP.CloseFile()
End If
sb.Append("MFG & Equip Depreciation Codes: " & WrkCopied & " Copied, " & WrkSkipped & " Skipped" & vbCrLf)
dsFile.Clear()
WrkCopied = 0
WrkSkipped = 0

dsFile = myTXDVCD.GetAllYear(WrkPrevYear)
If dsFile.Tables(0).Rows.Count > 0 Then
  For I = 0 To (dsFile.Tables(0).Rows.Count - 1)
    With myTXDVCD
      .GetOneRecordP(WrkYear, dsFile.Tables(0).Rows(I).Item("code"))
      If .RecordNotFound Then
        ._YEAR = WrkYear
        ._CODE = dsFile.Tables(0).Rows(I).Item("code")
        ._ASCODE = dsFile.Tables(0).Rows(I).Item("ascode")
        ._ASPCT = dsFile.Tables(0).Rows(I).Item("aspct")
        ._DESC = dsFile.Tables(0).Rows(I).Item("desc")
        .AddOneRecordP()
        WrkCopied = WrkCopied + 1
      Else
        WrkSkipped = WrkSkipped + 1
      End If
    End With
  Next
  myTXDVCD.CloseFile()
End If

sb.Append("MV Property Codes: " & WrkCopied & " Copied, " & WrkSkipped & " Skipped" & vbCrLf)
WrkMsg = sb.ToString
End Sub
End Module






