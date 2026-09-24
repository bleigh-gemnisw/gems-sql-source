Imports System.io
Imports System.Text
Module ProcessFile

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXMVDQ As TXMVDQ.MyData
  Dim myTXMVD2 As TXMVD2.MyData
  Dim myDBUtils As DBUtils.Utils

  Dim ds As DataSet = New DataSet
  Dim dr As DataRow
  Dim WrkStartNo As Integer
  Dim WrkIncr As Boolean
  Public Sub ProcFile()
    Dim Answer As Integer
    Dim WrkMsg As String
    myTXMVDQ = New TXMVDQ.MyData(myDBConnect)
    myTXMVD2 = New TXMVD2.MyData(myDBConnect)
    myDBUtils = New DBUtils.Utils(myDBConnect)

    With MyFrmTA403B
      WrkStartNo = MyUtils.CnvSng(.TxtStartNo.Text)
      WrkIncr = .ChkIncr.Checked
    End With

    GetDetail()

    WrkMsg = "Click OK to continue or cancel to abort"
    WrkMsg = WrkMsg & vbCrLf & vbCrLf & "WARNING: Do NOT end program once the copy process has started."
    WrkMsg = WrkMsg & vbCrLf & "If program shows as not responding it is STILL RUNNING."
    WrkMsg = WrkMsg & vbCrLf & "If you do NOT get a completion popup message contact hotline."
    Answer = MsgBox(WrkMsg, MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation,
    "Work File will be copied back to MV File")
    If Answer = MsgBoxResult.Cancel Then
      Exit Sub
    End If

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.LblMsg.Text = "Copying data..."
    myFrmProgress.ProgBar1.Visible = False
    myFrmProgress.Refresh()
    Application.DoEvents()

    myDBUtils.DeleteAllRecs("TXMVD")
    myDBUtils.CopyData("TXMVD2", "TXMVD")
    myFrmProgress.Close()
    MsgBox("Resequence is done", MsgBoxStyle.Information, "Processing has completed")


  End Sub
  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkRecNo As Integer
    Dim WrkLetter As String
    Dim SaveLetter As String
    Dim Counter As Integer

    myDBUtils.DeleteAllRecs("TXMVD2")
    SaveLetter = ""

    WrkSort = "LETT, NAME"
    WrkQry = ""
    Counter = 0

    myTXMVDQ.OpenQry(WrkSort, WrkQry)
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXMVDQ.ReadQry()
    If Not myTXMVDQ.IsEOF Then
      With myTXMVDQ
        Counter = Counter + 1
        WrkLetter = Trim(._LETT)
        If SaveLetter <> "" And WrkLetter <> SaveLetter Then
          If WrkIncr Then
            WrkStartNo = WrkStartNo + 10000
            WrkRecNo = 0
          End If
        End If
        SaveLetter = WrkLetter

        myTXMVD2.GetOneRecordP(WrkStartNo + WrkRecNo)
        With myTXMVD2
          ._ADD1 = myTXMVDQ._ADD1
          ._ADD2 = myTXMVDQ._ADD2
          ._ASS = myTXMVDQ._ASS
          ._BODY = myTXMVDQ._BODY
          ._BTC = myTXMVDQ._BTC
          ._BTR = myTXMVDQ._BTR
          ._CAT = myTXMVDQ._CAT
          ._CCCD1 = myTXMVDQ._CCCD1
          ._CCCD2 = myTXMVDQ._CCCD2
          ._CCCD3 = myTXMVDQ._CCCD3
          ._CCCD4 = myTXMVDQ._CCCD4
          ._CCCD5 = myTXMVDQ._CCCD5
          ._CCEX = myTXMVDQ._CCEX
          ._CCGRS = myTXMVDQ._CCGRS
          ._CCNO = myTXMVDQ._CCNO
          ._CCRS = myTXMVDQ._CCRS
          ._CDATE = myTXMVDQ._CDATE
          ._CEXA1 = myTXMVDQ._CEXA1
          ._CEXA2 = myTXMVDQ._CEXA2
          ._CEXA3 = myTXMVDQ._CEXA3
          ._CEXA4 = myTXMVDQ._CEXA4
          ._CEXA5 = myTXMVDQ._CEXA5
          ._CHDATE = myTXMVDQ._CHDATE
          ._CHTIME = myTXMVDQ._CHTIME
          ._CITY = myTXMVDQ._CITY
          ._CLASS = myTXMVDQ._CLASS
          ._CYCLE = myTXMVDQ._CYCLE
          ._CYLAX = myTXMVDQ._CYLAX
          ._DIST = myTXMVDQ._DIST
          ._DNBTR = myTXMVDQ._DNBTR
          ._DOB = myTXMVDQ._DOB
          ._DTBTR = myTXMVDQ._DTBTR
          ._EXAM1 = myTXMVDQ._EXAM1
          ._EXAM2 = myTXMVDQ._EXAM2
          ._EXAM3 = myTXMVDQ._EXAM3
          ._EXAM4 = myTXMVDQ._EXAM4
          ._EXAM5 = myTXMVDQ._EXAM5
          ._EXCD1 = myTXMVDQ._EXCD1
          ._EXCD2 = myTXMVDQ._EXCD2
          ._EXCD3 = myTXMVDQ._EXCD3
          ._EXCD4 = myTXMVDQ._EXCD4
          ._EXCD5 = myTXMVDQ._EXCD5
          ._GWT = myTXMVDQ._GWT
          ._LEASE = myTXMVDQ._LEASE
          ._LETT = myTXMVDQ._LETT
          ._LISTNO = WrkStartNo + WrkRecNo
          ._LNVAL = myTXMVDQ._LNVAL
          ._LOC = myTXMVDQ._LOC
          ._LOCNO = myTXMVDQ._LOCNO
          ._LWT = myTXMVDQ._LWT
          ._MAKE = myTXMVDQ._MAKE
          ._MODEL = myTXMVDQ._MODEL
          ._MSRP = myTXMVDQ._MSRP
          ._NADA = myTXMVDQ._NADA
          ._NAME = myTXMVDQ._NAME
          ._OASS = myTXMVDQ._OASS
          ._OCLS = myTXMVDQ._OCLS
          ._OCODE = myTXMVDQ._OCODE
          ._OID = myTXMVDQ._OID
          ._OLIST = myTXMVDQ._OLIST
          ._OMAKE = myTXMVDQ._OMAKE
          ._OMOD = myTXMVDQ._OMOD
          ._OPVAL = myTXMVDQ._OPVAL
          ._OREGNO = myTXMVDQ._OREGNo
          ._ORIG = myTXMVDQ._ORIG
          ._OVAL = myTXMVDQ._OVAL
          ._OVIN = myTXMVDQ._OVIN
          ._OYEAR = myTXMVDQ._OYEAR
          ._PCCOD = myTXMVDQ._PCCOD
          ._PCLR = myTXMVDQ._PCLR
          ._PDST = myTXMVDQ._PDST
          ._PNET = myTXMVDQ._PNET
          ._PREG = myTXMVDQ._PREG
          ._PRF = myTXMVDQ._PRF
          ._RAD1 = myTXMVDQ._RAD1
          ._RAD2 = myTXMVDQ._RAD2
          ._RATE = myTXMVDQ._RATE
          ._RCODE = myTXMVDQ._RCODE
          ._RCTY = myTXMVDQ._RCTY
          ._REGNO = myTXMVDQ._REGNO
          ._RST = myTXMVDQ._RST
          ._RZ4 = myTXMVDQ._RZ4
          ._RZ5 = myTXMVDQ._RZ5
          ._SCAP = myTXMVDQ._SCAP
          ._SCLR = myTXMVDQ._SCLR
          ._SEAT = myTXMVDQ._SEAT
          ._SNAME = myTXMVDQ._SNAME
          ._SS2 = myTXMVDQ._SS2
          ._SSNO = myTXMVDQ._SSNo
          ._STATE = myTXMVDQ._STATE
          ._TDATE = myTXMVDQ._TDATE
          ._TIN = myTXMVDQ._TIN
          ._TRVAL = myTXMVDQ._TRVAL
          ._TYPE = myTXMVDQ._TYPE
          ._VALUE = myTXMVDQ._VALUE
          ._VINNO = myTXMVDQ._VINNO
          ._XDATE = myTXMVDQ._XDATE
          ._YEAR = myTXMVDQ._YEAR
          ._ZIP4 = myTXMVDQ._ZIP4
          ._ZIP5 = myTXMVDQ._ZIP5
          .AddOneRecordP()
        End With
        WrkRecNo = WrkRecNo + 1
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

End_of_file:
    myFrmProgress.Close()
    myTXMVDQ.CloseFile()
  End Sub
End Module






