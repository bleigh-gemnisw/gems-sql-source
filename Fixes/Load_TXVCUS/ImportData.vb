Module ImportData
  Dim WrkGLYear As Integer
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXVCUS As TXVCUS.MyData
  Dim myTXVEH As TXVEH.MyData
  Public Sub Impdata()
    Dim Good As Boolean

    MyDBName = MyFrmFixB.TxtDBName.Text
    Good = Connect()

    If Not Good Then Exit Sub

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXVCUS = New TXVCUS.MyData(myDBConnect)
    myTXVEH = New TXVEH.MyData(myDBConnect)
    WriteTXVCUS()
    WriteTXVEH()
    MyFrmFix.Close()
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
  Private Sub WriteTXVCUS()
    Dim SavePcust As Long
    Dim SaveScust As Long
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkAnd As String
    Dim WrkOr As String
    Dim Counter As Integer

    WrkAnd = " and "
    WrkOr = " or "
    WrkQry = "SS#>0" & WrkOr & "SS2>0"
    WrkSort = "SS#, SS2"

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Text = "Processing TXVCUS"
    myFrmProgress.Refresh()
    Application.DoEvents()

    SavePcust = 0
    SaveScust = 0
    myTXINVQ.OpenQry(WrkSort, WrkQry)

ReadNext:
    myTXINVQ.ReadQry()
    If Not myTXINVQ.IsEOF Then
      With myTXINVQ
        Counter = Counter + 1
        If ._SSNo > 0 And SavePcust <> ._SSNo Then
          ProcessVCUS(._SSNo)
        End If
        If ._SS2 > 0 And SaveScust <> ._SS2 Then
          ProcessVCUS(._SS2)
        End If
        SavePcust = ._SSNo
        SaveScust = ._SS2
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
    myTXINVQ.CloseFile()
  End Sub
  Private Sub ProcessVCUS(ByVal WrkCustID As Integer)
    myTXVCUS.GetOneRecordP(WrkCustID)
    If myTXVCUS.RecordNotFound Then
      With myTXVCUS
        ._ADD1 = Trim(myTXINVQ._ADD1)
        ._ADD2 = Trim(myTXINVQ._ADD2)
        ._BUS = ""
        ._CHDATE = 0
        ._CITY = Trim(myTXINVQ._CITY)
        ._CONFID = ""
        ._CUSTID = WrkCustID
        ._DOB = myTXINVQ._DOB
        ._NAME = Trim(myTXINVQ._NAME)
        ._RADD1 = ""
        ._RADD2 = ""
        ._RCITY = ""
        ._RSTATE = ""
        ._RZIPA = ""
        ._SEX = ""
        ._STATE = myTXINVQ._STATE
        If myTXINVQ._ZIP4 = 0 Then
          ._ZIPA = Format(myTXINVQ._ZIP5, "00000")
        Else
          ._ZIPA = Format(myTXINVQ._ZIP5, "00000") & "-" & Format(myTXINVQ._ZIP4, "0000")
        End If
        .AddOneRecordP()
      End With
    End If
  End Sub
  Private Sub WriteTXVEH()
    Dim SaveVeh As Long
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkAnd As String
    Dim WrkOr As String
    Dim Counter As Integer

    WrkAnd = " and "
    WrkOr = " or "
    WrkQry = "OID<>''"
    WrkSort = "OID"

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Text = "Processing TXVEH"
    myFrmProgress.Refresh()
    Application.DoEvents()

    SaveVeh = 0
    myTXINVQ.OpenQry(WrkSort, WrkQry)

ReadNext:
    myTXINVQ.ReadQry()
    If Not myTXINVQ.IsEOF Then
      With myTXINVQ
        Counter = Counter + 1
        If Trim(._OID) <> "" And SaveVeh <> CnvSng(._OID) Then
          ProcessVEH(CnvSng(._OID))
        End If
        SaveVeh = CnvSng(._OID)
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

    If SaveVeh > 0 Then
      ProcessVeh(SaveVeh)
    End If
    myFrmProgress.Close()
    myTXINVQ.CloseFile()
  End Sub
  Private Sub ProcessVEH(ByVal WrkVehID As Integer)
    myTXVeh.GetOneRecordP(WrkVehID)
    If myTXVeh.RecordNotFound Then
      With myTXVEH
        ._BODY = Trim(myTXINVQ._BODY)
        ._CHDATE = 0
        ._CLASS = myTXINVQ._CLASS
        ._CLASSD = ""
        ._CYLAX = 0
        ._DADD1 = Trim(myTXINVQ._ADD1)
        ._DADD2 = Trim(myTXINVQ._ADD2)
        ._DCITY = Trim(myTXINVQ._CITY)
        ._DSTATE = myTXINVQ._STATE
        If myTXINVQ._ZIP4 = 0 Then
          ._DZIPA = Format(myTXINVQ._ZIP5, "00000")
        Else
          ._DZIPA = Format(myTXINVQ._ZIP5, "00000") & "-" & Format(myTXINVQ._ZIP4, "0000")
        End If
        ._ENDDT = 0
        ._GWT = 0
        ._LADD1 = ""
        ._LADD2 = ""
        ._LBUS = ""
        ._LCUST = 0
        ._LEASE = ""
        ._LNAME = ""
        ._LNVAL = 0
        ._LSTATE = ""
        ._LWT = 0
        ._LZIPA = ""
        ._MSRP = 0
        ._NADA = ""
        ._ORIG = 0
        ._PCUST = myTXINVQ._SSNo
        ._REGID = 0
        ._REGNO = Trim(myTXINVQ._IMVREG)
        ._RGLATE = ""
        ._SCUST = myTXINVQ._SS2
        ._SEAT = 0
        ._STRDT = 0
        ._TRVAL = 0
        ._VEHID = WrkVehID
        ._VINNO = Trim(myTXINVQ._IMVIDNo)
        ._VMAKE = Trim(myTXINVQ._MAKE)
        ._VMODEL = Trim(myTXINVQ._MODEL)
        ._VPCLR = ""
        ._VSCLR = ""
        ._YEAR = myTXINVQ._MVYR
        .AddOneRecordP()
      End With
    End If
  End Sub
End Module
