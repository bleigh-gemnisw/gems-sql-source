Imports System.Text
Module ProcessFile

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALCQ As TXREALCQ.myData
Dim myTXCOEB As TXCOEB.myData
Dim myTXINV As TXINV.myData
Dim myDBUTILS As DBUtils.DbMgr
Dim myTXREALCDst As TXRealC.myData
Dim myTXCOEBDst As TXCOEB.myData

'General
Dim WrkGLYear As Integer
Dim WrkPost As Boolean
Dim WrkAnd As String
Dim WrkOr As String
  Public Sub ProcFile()

  myTXREALCQ = New TXREALCQ.mydata(MyDBConnect)
  myTXCOEB = New TXCOEB.mydata(MyDBConnect)
  myTXINV = New TXINV.mydata(MyDBConnect)
  myDBUTILS = New DBUtils.DbMgr(myDBConnect2.pgmDB)
  myTXREALCDst = New TXRealC.myData(myDBConnect2.pgmDB)
  myTXCOEBDst = New TXCOEB.myData(myDBConnect2.pgmDB)

  With MyFrmTA600B
    WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
    WrkPost = .Chkupdatebacktax.Checked
  End With

  GetDetail()
  End Sub
Private Sub GetDetail()
Dim WrkQry As String
Dim WrkSort As String
Dim Counter As Integer
Dim WrkError As Boolean

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

myDBUTILS.ClearMember(myDBConnect2.pgmDB, "*LIBL/TXREALC", "*FIRST", WrkError)
If WrkError Then
  MsgBox("Unable to clear TXREALC in " & myDBConnect2.ServerName & ". Please contact hotline.", MsgBoxStyle.Critical, "Program aborted")
  myFrmProgress.Close()
  Exit Sub
End If
myDBUTILS.ClearMember(myDBConnect2.pgmDB, "*LIBL/TXCOEB", "*FIRST", WrkError)
If WrkError Then
  MsgBox("Unable to clear TXCOEB in " & myDBConnect2.ServerName & ". Please contact hotline.", MsgBoxStyle.Critical, "Program aborted")
  myFrmProgress.Close()
  Exit Sub
End If

WrkSort = "LIST#"
WrkQry = "pdst=80"
myTXREALCQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
  myTXREALCQ.ReadQry()
  If Not myTXREALCQ.IsEOF Then
    With myTXREALCQ
      Counter = Counter + 1
      If WrkPost Then
        WriteTXREALC()
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


If WrkPost Then
  MsgBox("Record Count = " & Counter, MsgBoxStyle.Information, "Fire District Files created")
Else
  MsgBox("Record Count = " & Counter, MsgBoxStyle.Information, "Fire District Proof")
End If
myFrmProgress.Close()
myTXREALCQ.CloseFile()

End Sub
Private Sub WriteTXREALC()

  With myTXREALCDst
    ._LISTNO = myTXREALCQ._LISTNO
    ._NAME = myTXREALCQ._NAME
    ._LETT = myTXREALCQ._LETT
    myTXINV.GetOneRecordP(myTXREALCQ._LISTNO, WrkGLYear, "R")
    If Not .RecordNotFound Then
      ._SNAME = myTXINV._SNAME
      ._ADD1 = myTXINV._ADD1
      ._ADD2 = myTXINV._ADD2
      ._CITY = myTXINV._CITY
      ._STATE = myTXINV._STATE
      ._ZIP5 = myTXINV._ZIP5
      ._ZIP4 = myTXINV._ZIP4
    Else
      ._SNAME = myTXREALCQ._SNAME
      ._ADD1 = myTXREALCQ._ADD1
      ._ADD2 = myTXREALCQ._ADD2
      ._CITY = myTXREALCQ._CITY
      ._STATE = myTXREALCQ._STATE
      ._ZIP5 = myTXREALCQ._ZIP5
      ._ZIP4 = myTXREALCQ._ZIP4
    End If
    ._GROSS = myTXREALCQ._GROSS
    ._NET = myTXREALCQ._GROSS
    ._CODE1 = myTXREALCQ._CODE1
    ._CODE2 = myTXREALCQ._CODE2
    ._CODE3 = myTXREALCQ._CODE3
    ._CODE4 = myTXREALCQ._CODE4
    ._CODE5 = myTXREALCQ._CODE5
    ._CODE6 = myTXREALCQ._CODE6
    ._CODE7 = myTXREALCQ._CODE7
    ._UNIT1 = myTXREALCQ._UNIT1
    ._UNIT2 = myTXREALCQ._UNIT2
    ._UNIT3 = myTXREALCQ._UNIT3
    ._UNIT4 = myTXREALCQ._UNIT4
    ._UNIT5 = myTXREALCQ._UNIT5
    ._UNIT6 = myTXREALCQ._UNIT6
    ._UNIT7 = myTXREALCQ._UNIT7
    ._ASS1 = myTXREALCQ._ASS1
    ._ASS2 = myTXREALCQ._ASS2
    ._ASS3 = myTXREALCQ._ASS3
    ._ASS4 = myTXREALCQ._ASS4
    ._ASS5 = myTXREALCQ._ASS5
    ._ASS6 = myTXREALCQ._ASS6
    ._ASS7 = myTXREALCQ._ASS7
    ._ACRE1 = myTXREALCQ._ACRE1
    ._ACRE2 = myTXREALCQ._ACRE2
    ._ACRE3 = myTXREALCQ._ACRE3
    ._ACRE4 = myTXREALCQ._ACRE4
    ._ACRE5 = myTXREALCQ._ACRE5
    ._ACRE6 = myTXREALCQ._ACRE6
    ._ACRE7 = myTXREALCQ._ACRE7
    ._EXCD1 = ""
    ._EXAM1 = 0
    ._EXCD2 = ""
    ._EXAM2 = 0
    ._EXCD3 = ""
    ._EXAM3 = 0
    ._EXCD4 = ""
    ._EXAM4 = 0
    ._EXCD5 = ""
    ._EXAM5 = 0
    ._EXCD6 = ""
    ._EXAM6 = 0
    ._EXCD7 = ""
    ._EXAM7 = 0
    ._MAP = myTXREALCQ._MAP
    ._LOCNO = myTXREALCQ._LOCNO
    ._LOC = myTXREALCQ._LOC
    ._VOL = myTXREALCQ._VOL
    ._PGE = myTXREALCQ._PGE
    ._CAT = "1"
    ._EXMPT = ""
    ._TYPE = "R"
    .AddOneRecordP()
  End With

End Sub
Private Sub WriteCOEB()

  With myTXCOEBDst
    myTXCOEB.GetOneRecordP(myTXREALCQ._LISTNO)
    ._LISTNo = myTXCOEB._LISTNo
    ._NAME = myTXCOEB._NAME
    ._CCNO = myTXCOEB._CCNO
    ._CGRS = myTXCOEB._CGRS
    ._CGRSCH = myTXCOEB._CGRSCH
    ._CHDATE = myTXCOEB._CHDATE
    ._CHTIME = myTXCOEB._CHTIME
    ._CTYPE = myTXCOEB._CTYPE
    ._EXCHG = 0
    ._NTASS1 = myTXCOEB._NTASS1
    ._NTASS2 = myTXCOEB._NTASS2
    ._NTASS3 = myTXCOEB._NTASS3
    ._NTASS4 = myTXCOEB._NTASS4
    ._NTASS5 = myTXCOEB._NTASS5
    ._NTASS6 = myTXCOEB._NTASS6
    ._NTASS7 = myTXCOEB._NTASS7
    ._NTASS8 = myTXCOEB._NTASS8
    ._NTASS9 = myTXCOEB._NTASS9
    ._NTASSA = myTXCOEB._NTASSA
    ._RSNCD = myTXCOEB._RSNCD
    .AddOneRecordP()
  End With

End Sub
End Module






