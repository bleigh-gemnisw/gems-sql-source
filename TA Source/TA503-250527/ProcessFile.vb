Imports System.io
Imports System.Text
Module ProcessFile

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXSUPPQ As TXSUPPQ.MyData
  Dim myTXSUPP2 As TXSUPP2.MyData
  Dim myDBUtils As DBUtils.Utils
  Dim dsTXSUPPQ As DataSet = New DataSet

  Dim ds As DataSet = New DataSet
  Dim dr As DataRow
  Dim WrkStartNo As Integer
  Dim WrkIncr As Boolean
  Public Sub ProcFile()
    Dim Answer As Integer
    Dim WrkMsg As String
    myTXSUPPQ = New TXSUPPQ.MyData(myDBConnect)
    myTXSUPP2 = New TXSUPP2.MyData(myDBConnect)
    myDBUtils = New DBUtils.Utils(myDBConnect)

    With MyFrmTA503B
      WrkStartNo = MyUtils.CnvSng(.TxtStartNo.Text)
      WrkIncr = .ChkIncr.Checked
    End With

    GetDetail()

    WrkMsg = "Click OK to continue or cancel to abort"
    WrkMsg = WrkMsg & vbCrLf & vbCrLf & "WARNING: Do NOT end program once the copy process has started."
    WrkMsg = WrkMsg & vbCrLf & "If program shows as not responding it is STILL RUNNING."
    WrkMsg = WrkMsg & vbCrLf & "If you do NOT get a completion popup message contact hotline."
    Answer = MsgBox(WrkMsg, MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation,
    "Work File will be copied back to Suppl. MV File")
    If Answer = MsgBoxResult.Cancel Then
      Exit Sub
    End If

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.LblMsg.Text = "Copying data..."
    myFrmProgress.ProgBar1.Visible = False
    myFrmProgress.Refresh()
    Application.DoEvents()

    myDBUtils.DeleteAllRecs("TXSUPP")
    myDBUtils.CopyData("TXSUPP2", "TXSUPP")
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

    myDBUtils.DeleteAllRecs("TXSUPP2")
    SaveLetter = ""

    WrkSort = "LETT, NAME"
    WrkQry = ""
    Counter = 0

    myTXSUPPQ.OpenQry(WrkSort, WrkQry)
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXSUPPQ.ReadQry()
    If Not myTXSUPPQ.IsEOF Then
      With myTXSUPPQ
        Counter = Counter + 1
        WrkLetter = Trim(._LETT)
        If SaveLetter <> "" And WrkLetter <> SaveLetter Then
          If WrkIncr Then
            WrkStartNo = WrkStartNo + 10000
            WrkRecNo = 0
          End If
        End If
        SaveLetter = WrkLetter

        myTXSUPP2.GetOneRecordP(WrkStartNo + WrkRecNo)
        With myTXSUPP2
          ._ADD1 = myTXSUPPQ._ADD1
          ._ADD2 = myTXSUPPQ._ADD2
          ._ASS = myTXSUPPQ._ASS
          ._BODY = myTXSUPPQ._BODY
          ._BTC = myTXSUPPQ._BTC
          ._BTR = myTXSUPPQ._BTR
          ._CAT = myTXSUPPQ._CAT
          ._CCCD1 = myTXSUPPQ._CCCD1
          ._CCCD2 = myTXSUPPQ._CCCD2
          ._CCCD3 = myTXSUPPQ._CCCD3
          ._CCCD4 = myTXSUPPQ._CCCD4
          ._CCCD5 = myTXSUPPQ._CCCD5
          ._CCEX = myTXSUPPQ._CCEX
          ._CCGRS = myTXSUPPQ._CCGRS
          ._CCNO = myTXSUPPQ._CCNO
          ._CCRS = myTXSUPPQ._CCRS
          ._CDATE = myTXSUPPQ._CDATE
          ._CEXA1 = myTXSUPPQ._CEXA1
          ._CEXA2 = myTXSUPPQ._CEXA2
          ._CEXA3 = myTXSUPPQ._CEXA3
          ._CEXA4 = myTXSUPPQ._CEXA4
          ._CEXA5 = myTXSUPPQ._CEXA5
          ._CHDATE = myTXSUPPQ._CHDATE
          ._CHTIME = myTXSUPPQ._CHTIME
          ._CITY = myTXSUPPQ._CITY
          ._CLASS = myTXSUPPQ._CLASS
          ._CYCLE = myTXSUPPQ._CYCLE
          ._CYLAX = myTXSUPPQ._CYLAX
          ._DIST = myTXSUPPQ._DIST
          ._DOB = myTXSUPPQ._DOB
          ._EXAM1 = myTXSUPPQ._EXAM1
          ._EXAM2 = myTXSUPPQ._EXAM2
          ._EXAM3 = myTXSUPPQ._EXAM3
          ._EXAM4 = myTXSUPPQ._EXAM4
          ._EXAM5 = myTXSUPPQ._EXAM5
          ._EXCD1 = myTXSUPPQ._EXCD1
          ._EXCD2 = myTXSUPPQ._EXCD2
          ._EXCD3 = myTXSUPPQ._EXCD3
          ._EXCD4 = myTXSUPPQ._EXCD4
          ._EXCD5 = myTXSUPPQ._EXCD5
          ._GWT = myTXSUPPQ._GWT
          ._LEASE = myTXSUPPQ._LEASE
          ._LETT = myTXSUPPQ._LETT
          ._LISTNo = WrkStartNo + WrkRecNo
          ._LNVAL = myTXSUPPQ._LNVAL
          ._LWT = myTXSUPPQ._LWT
          ._MAKE = myTXSUPPQ._MAKE
          ._MODEL = myTXSUPPQ._MODEL
          ._MSRP = myTXSUPPQ._MSRP
          ._NADA = myTXSUPPQ._NADA
          ._NAME = myTXSUPPQ._NAME
          ._OASS = myTXSUPPQ._OASS
          ._OCLS = myTXSUPPQ._OCLS
          ._OCODE = myTXSUPPQ._OCODE
          ._OID = myTXSUPPQ._OID
          ._OLIST = myTXSUPPQ._OLIST
          ._OMAKE = myTXSUPPQ._OMAKE
          ._OMOD = myTXSUPPQ._OMOD
          ._OPVAL = myTXSUPPQ._OPVAL
          ._OREGNo = myTXSUPPQ._OREGNo
          ._ORIG = myTXSUPPQ._ORIG
          ._OVAL = myTXSUPPQ._OVAL
          ._OVIN = myTXSUPPQ._OVIN
          ._OYEAR = myTXSUPPQ._OYEAR
          ._PCCOD = myTXSUPPQ._PCCOD
          ._PCLR = myTXSUPPQ._PCLR
          ._PDST = myTXSUPPQ._PDST
          ._PNET = myTXSUPPQ._PNET
          ._PREG = myTXSUPPQ._PREG
          ._PRF = myTXSUPPQ._PRF
          ._PVAL = myTXSUPPQ._PVAL
          '				._RAD1 = myTXSUPPQ._RAD1
          '				._RAD2 = myTXSUPPQ._RAD2
          ._RATE = myTXSUPPQ._RATE
          ._RCODE = myTXSUPPQ._RCODE
          '				._RCTY = myTXSUPPQ._RCTY
          ._REGNO = myTXSUPPQ._REGNO
          '				._RST = myTXSUPPQ._RST
          '				._RZ4 = myTXSUPPQ._RZ4
          '				._RZ5 = myTXSUPPQ._RZ5
          ._SCAP = myTXSUPPQ._SCAP
          ._SCLR = myTXSUPPQ._SCLR
          ._SEAT = myTXSUPPQ._SEAT
          ._SNAME = myTXSUPPQ._SNAME
          ._SS2 = myTXSUPPQ._SS2
          ._SSNo = myTXSUPPQ._SSNo
          ._STATE = myTXSUPPQ._STATE
          ._TDATE = myTXSUPPQ._TDATE
          ._TIN = myTXSUPPQ._TIN
          ._TRVAL = myTXSUPPQ._TRVAL
          ._TYPE = myTXSUPPQ._TYPE
          ._VALUE = myTXSUPPQ._VALUE
          ._VINNO = myTXSUPPQ._VINNO
          ._XDATE = myTXSUPPQ._XDATE
          ._YEAR = myTXSUPPQ._YEAR
          ._ZIP4 = myTXSUPPQ._ZIP4
          ._ZIP5 = myTXSUPPQ._ZIP5
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
    myTXSUPPQ.CloseFile()
  End Sub
End Module






