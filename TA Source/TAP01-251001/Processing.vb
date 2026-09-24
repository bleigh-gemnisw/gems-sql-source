Module Processing
  Dim MyTXDCDEP As TXDCDEP.MyData
  Dim MyTXDCCD As TXDCCD.MyData
  Dim MyTXDCSUM As TXDCSUM.MyData
  Dim MyTXDMCD As TXDMCD.MyData
  Dim MyTXDMDEP As TXDMDEP.MyData
  Dim MyTXDMSUM As TXDMSUM.MyData
  Dim MyTXMSRPDEP As TXMSRPDEP.MyData

  Public Sub CopyRecords(ByVal WrkList As Integer, ByVal WrkYear As Integer)
    Dim MyTXDCASS As TXDCASS.MyData
    Dim MyTXDCBUS As TXDCBUS.MyData
    Dim MyTXDCCOM As TXDCCOM.MyData
    Dim MyTXDCDTL As TXDCDTL.MyData
    Dim MyTXDCEX As TXDCEX.MyData
    Dim MyTXDCEXM As TXDCEXM.MyData
    Dim MyTXDCHOR As TXDCHOR.MyData
    Dim MyTXDCLEE As TXDCLEE.MyData
    Dim MyTXDCLOR As TXDCLOR.MyData
    Dim MyTXDCMOB As TXDCMOB.MyData
    Dim MyTXDCMV As TXDCMV.MyData
    Dim MyTXDCPP As TXDCPP.MyData
    Dim MyTXDCPP_LY As TXDCPP.MyData
    Dim MyTXDCTWN As TXDCTWN.MyData
    Dim MyTXDMPP As TXDMPP.MyData
    Dim MyTXDMPP_LY As TXDMPP.MyData
    Dim MyTXDMLST As TXDMLST.MyData
    Dim MyTXDVPP As TXDVPP.MyData
    Dim MyTXDVPP_LY As TXDVPP.MyData
    Dim MyTXDVPI As TXDVPI.MyData
    Dim MyTXDVPN As TXDVPN.MyData
    Dim ds2 As DataSet = New DataSet
    Dim WrkLastYear As Integer
    Dim WrkNet As Integer
    Dim WrkProrated As Integer
    Dim WrkValue As Integer
    Dim WrkSumNet As Integer
    Dim WrkSumValue As Integer
    Dim WrkYearNo As Integer
    Dim WrkPct As Decimal
    Dim WrkPriorYears As Boolean
    Dim WrkCode As String
    Dim SaveCode As Integer
    Dim SaveLetter As String
    Dim SaveYearNo As Integer
    Dim I As Integer

    MyTXDCASS = New TXDCASS.MyData(myDBConnect)
    MyTXDCBUS = New TXDCBUS.MyData(myDBConnect)
    MyTXDCCD = New TXDCCD.MyData(myDBConnect)
    MyTXDCCOM = New TXDCCOM.MyData(myDBConnect)
    MyTXDCDEP = New TXDCDEP.MyData(myDBConnect)
    MyTXDCDTL = New TXDCDTL.MyData(myDBConnect)
    MyTXDCEX = New TXDCEX.MyData(myDBConnect)
    MyTXDCEXM = New TXDCEXM.MyData(myDBConnect)
    MyTXDCHOR = New TXDCHOR.MyData(myDBConnect)
    MyTXDCLEE = New TXDCLEE.MyData(myDBConnect)
    MyTXDCLOR = New TXDCLOR.MyData(myDBConnect)
    MyTXDCMOB = New TXDCMOB.MyData(myDBConnect)
    MyTXDCMV = New TXDCMV.MyData(myDBConnect)
    MyTXDCPP = New TXDCPP.MyData(myDBConnect)
    MyTXDCPP_LY = New TXDCPP.MyData(myDBConnect)
    MyTXDCTWN = New TXDCTWN.MyData(myDBConnect)
    MyTXDCSUM = New TXDCSUM.MyData(myDBConnect)
    MyTXDMCD = New TXDMCD.MyData(myDBConnect)
    MyTXDMDEP = New TXDMDEP.MyData(myDBConnect)
    MyTXDMPP = New TXDMPP.MyData(myDBConnect)
    MyTXDMPP_LY = New TXDMPP.MyData(myDBConnect)
    MyTXDMLST = New TXDMLST.MyData(myDBConnect)
    MyTXDMSUM = New TXDMSUM.MyData(myDBConnect)
    MyTXDVPP = New TXDVPP.MyData(myDBConnect)
    MyTXDVPP_LY = New TXDVPP.MyData(myDBConnect)
    MyTXDVPI = New TXDVPI.MyData(myDBConnect)
    MyTXDVPN = New TXDVPN.MyData(myDBConnect)
    MyTXMSRPDEP = New TXMSRPDEP.MyData(myDBConnect)

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    Application.DoEvents()
    WrkLastYear = WrkYear - 1

    MyTXDCPP_LY.GetOneRecordP(WrkList, WrkLastYear)
    If Not MyTXDCPP_LY.RecordNotFound Then
      MyTXDCPP.GetOneRecordP(WrkList, WrkYear)
      With MyTXDCPP
        ._LISTNO = WrkList
        ._YEAR = WrkYear
        ._ADATE = 0
        ._ANAME = String.Empty
        ._ASECCD = String.Empty
        ._ATITLE = String.Empty
        ._BDATE = 0
        ._BNAME = String.Empty
        ._BTITLE = String.Empty
        ._BUSCD = Trim(MyTXDCPP_LY._BUSCD)
        ._BUSDES = Trim(MyTXDCPP_LY._BUSDES)
        ._BUSOTH = Trim(MyTXDCPP_LY._BUSOTH)
        ._BUSCAT = Trim(MyTXDCPP_LY._BUSCAT)
        ._BWIT = String.Empty
        ._BWITCD = String.Empty
        ._BWITDT = 0
        ._DADDR = Trim(MyTXDCPP_LY._DADDR)
        ._DBA = Trim(MyTXDCPP_LY._DBA)
        ._DCITY = Trim(MyTXDCPP_LY._DCITY)
        ._DEMAIL = Trim(MyTXDCPP_LY._DEMAIL)
        ._DFAX = Trim(MyTXDCPP_LY._DFAX)
        ._DNAME = Trim(MyTXDCPP_LY._DNAME)
        ._DPHONE = Trim(MyTXDCPP_LY._DPHONE)
        ._DSTATE = Trim(MyTXDCPP_LY._DSTATE)
        ._DZIP4 = MyTXDCPP_LY._DZIP4
        ._DZIP5 = MyTXDCPP_LY._DZIP5
        ._LADDR = Trim(MyTXDCPP_LY._LADDR)
        ._LCITY = Trim(MyTXDCPP_LY._LCITY)
        ._LEMAIL = Trim(MyTXDCPP_LY._LEMAIL)
        ._LFAX = Trim(MyTXDCPP_LY._LFAX)
        ._LNAME = Trim(MyTXDCPP_LY._LNAME)
        ._LOC = Trim(MyTXDCPP_LY._LOC)
        ._LOCNO = Trim(MyTXDCPP_LY._LOCNO)
        ._LPHONE = Trim(MyTXDCPP_LY._LPHONE)
        ._LSTATE = Trim(MyTXDCPP_LY._LSTATE)
        ._LZIP4 = MyTXDCPP_LY._LZIP4
        ._LZIP5 = MyTXDCPP_LY._LZIP5
        ._NOEMPS = MyTXDCPP_LY._NOEMPS
        ._OTHBUS = Trim(MyTXDCPP_LY._OTHBUS)
        ._OWN = Trim(MyTXDCPP_LY._OWN)
        ._OWNAME = Trim(MyTXDCPP_LY._OWNAME)
        ._OWNOTH = Trim(MyTXDCPP_LY._OWNOTH)
        ._OWNTYP = Trim(MyTXDCPP_LY._OWNTYP)
        ._PROPCT = Trim(MyTXDCPP_LY._PROPCT)
        ._RECVDT = 0
        ._SQFEET = Trim(MyTXDCPP_LY._SQFEET)
        ._STRDT = Trim(MyTXDCPP_LY._STRDT)
        .AddOneRecordP()
      End With
    End If

    ds2 = MyTXDCASS.GetByList(WrkList, WrkLastYear)
    If ds2.Tables(0).Rows.Count > 0 Then
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        With MyTXDCASS
          .GetOneRecordP(WrkList, WrkYear, 0)
          ._LISTNO = WrkList
          ._YEAR = WrkYear
          ._SEQNO = ds2.Tables(0).Rows(I).Item("seqno")
          ._ACQCST = ds2.Tables(0).Rows(I).Item("acqcst")
          ._ACQDT = ds2.Tables(0).Rows(I).Item("acqdt")
          ._CODE = ds2.Tables(0).Rows(I).Item("code")
          ._DESC = ds2.Tables(0).Rows(I).Item("desc")
          ._LTR = ds2.Tables(0).Rows(I).Item("ltr")
          .AddOneRecordP()
        End With
      Next
    End If

    ds2 = MyTXDCBUS.GetByList(WrkList, WrkLastYear)
    If ds2.Tables(0).Rows.Count > 0 Then
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        With MyTXDCBUS
          .GetOneRecordP(WrkList, WrkYear, 0)
          ._LISTNO = WrkList
          ._YEAR = WrkYear
          ._SEQNO = ds2.Tables(0).Rows(I).Item("seqno")
          ._BADDR = ds2.Tables(0).Rows(I).Item("baddr")
          ._BCITY = ds2.Tables(0).Rows(I).Item("bcity")
          ._BNAME = ds2.Tables(0).Rows(I).Item("bname")
          ._BSTATE = ds2.Tables(0).Rows(I).Item("bstate")
          ._BZIP4 = ds2.Tables(0).Rows(I).Item("bzip4")
          ._BZIP5 = ds2.Tables(0).Rows(I).Item("bzip5")
          .AddOneRecordP()
        End With
      Next
    End If

    ds2 = MyTXDCCOM.Getcomments(WrkList, WrkLastYear)
    MyFrmTAP01.TBarComments.ImageKey = ""
    If ds2.Tables(0).Rows.Count > 0 Then
      With MyTXDCCOM
        For I = 0 To ds2.Tables(0).Rows.Count - 1
          .GetOneRecordP(WrkList, WrkYear, ds2.Tables(0).Rows(I).Item("seqno"))
          ._CMNT = ds2.Tables(0).Rows(I).Item("cmnt")
          ._SEQNO = ds2.Tables(0).Rows(I).Item("seqno")
          ._LISTNO = WrkList
          ._YEAR = WrkYear
          .AddOneRecordP()
        Next
      End With
      MyFrmTAP01.TBarComments.ImageKey = "comment_24.png"
    End If

    'MK 9/23/25 To fix Rounding issue, move Write to TXDCSUM to after TXDCDTL is written 
    SaveCode = 0
    SaveLetter = String.Empty
    'WrkNet = 0
    'WrkValue = 0
    'WrkSumNet = 0
    'WrkSumValue = 0
    ds2 = MyTXDCDTL.GetByList(WrkList, WrkLastYear)
    If ds2.Tables(0).Rows.Count > 0 Then
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        WrkPriorYears = False
        'If SaveCode <> ds2.Tables(0).Rows(I).Item("code") Then
        '  If SaveCode > 0 Then
        '    WriteTXDCSUM(WrkList, WrkYear, SaveCode, WrkSumValue, WrkSumNet)
        '    WrkSumNet = 0
        '    WrkSumValue = 0
        '  End If
        'End If
        If SaveCode <> ds2.Tables(0).Rows(I).Item("code") Or SaveLetter <> ds2.Tables(0).Rows(I).Item("ltr") Then
          MyTXDCCD.GetOneRecordP(WrkYear, ds2.Tables(0).Rows(I).Item("code"), ds2.Tables(0).Rows(I).Item("ltr"))
        End If
        If Not MyTXDCCD.RecordNotFound Then
          If ds2.Tables(0).Rows(I).Item("code") = 25 Then
            SaveCode = 0
            SaveLetter = String.Empty
            Continue For
          End If
          SaveCode = ds2.Tables(0).Rows(I).Item("code")
          SaveLetter = ds2.Tables(0).Rows(I).Item("ltr")
        Else
          SaveCode = 0
          SaveLetter = String.Empty
          Continue For
        End If
        With MyTXDCDTL
          WrkYearNo = WrkYear - ds2.Tables(0).Rows(I).Item("deyear") + 1
          MyTXDCDEP.GetOneRecordP(WrkYear, MyTXDCCD._DECODE, WrkYearNo)
          If Not MyTXDCDEP.RecordNotFound Then
            .GetOneRecordP(WrkList, WrkYear, SaveCode, SaveLetter, ds2.Tables(0).Rows(I).Item("deyear"))
            If Not .RecordNotFound Then
              ._DECOST = ._DECOST + ds2.Tables(0).Rows(I).Item("decost")
              .UpdateOneRecordP()
            Else
              ._LISTNO = WrkList
              ._YEAR = WrkYear
              ._LTR = SaveLetter
              ._CODE = SaveCode
              ._DECOST = ds2.Tables(0).Rows(I).Item("decost")
              ._DEYEAR = ds2.Tables(0).Rows(I).Item("deyear")
              .AddOneRecordP()
            End If
          Else
            .GetOneRecordP(WrkList, WrkYear, SaveCode, SaveLetter, ds2.Tables(0).Rows(I).Item("deyear") + 1)
            WrkPriorYears = True
            If Not .RecordNotFound Then
              ._DECOST = ._DECOST + ds2.Tables(0).Rows(I).Item("decost")
              .UpdateOneRecordP()
            Else
              ._LISTNO = WrkList
              ._YEAR = WrkYear
              ._LTR = SaveLetter
              ._CODE = SaveCode
              ._DEYEAR = ds2.Tables(0).Rows(I).Item("deyear") + 1
              ._DECOST = ds2.Tables(0).Rows(I).Item("decost")
              .AddOneRecordP()
            End If
          End If
          'If WrkPriorYears Then
          '  MyTXDCDEP.GetOneRecordP(WrkYear, MyTXDCCD._DECODE, WrkYearNo - 1)
          'End If
          'If MyTXDCDEP._PROPCT > 0 Then
          '  WrkProrated = MyUtils.Round(ds2.Tables(0).Rows(I).Item("decost") * (MyTXDCDEP._PROPCT / 100), 0)
          'Else
          '  WrkProrated = ds2.Tables(0).Rows(I).Item("decost")
          'End If
          'WrkPct = MyTXDCDEP._PCT / 100
          'WrkNet = MyUtils.Round(WrkProrated * WrkPct, 0)
          'WrkSumNet = WrkSumNet + WrkNet
          'WrkValue = MyUtils.Round(WrkNet * (MyTXDCCD._ASPCT / 100), 0)
          'WrkSumValue = WrkSumValue + WrkValue
        End With
      Next
    End If

    'Read TXDCDTL records to create TXDCSUM records
    SaveCode = 0
    ds2 = MyTXDCDTL.GetByList(WrkList, WrkYear)
    If ds2.Tables(0).Rows.Count > 0 Then
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        If SaveCode <> ds2.Tables(0).Rows(I).Item("code") Then
          If SaveCode > 0 Then
            WriteTXDCSUM(WrkList, WrkYear, SaveCode, WrkSumValue, WrkSumNet)
            WrkSumNet = 0
            WrkSumValue = 0
          End If
          SaveCode = ds2.Tables(0).Rows(I).Item("code")
        End If
        WrkYearNo = WrkYear - ds2.Tables(0).Rows(I).Item("deyear") + 1
        MyTXDCCD.GetOneRecordP(WrkYear, ds2.Tables(0).Rows(I).Item("code"), ds2.Tables(0).Rows(I).Item("ltr"))
          MyTXDCDEP.GetOneRecordP(WrkYear, Trim(MyTXDCCD._DECODE), WrkYearNo)
          If MyTXDCDEP._PROPCT > 0 Then
            WrkProrated = MyUtils.Round(ds2.Tables(0).Rows(I).Item("decost") * (MyTXDCDEP._PROPCT / 100), 0)
          Else
            WrkProrated = ds2.Tables(0).Rows(I).Item("decost")
          End If
          WrkPct = MyTXDCDEP._PCT / 100
          WrkNet = MyUtils.Round(WrkProrated * WrkPct, 0)
          WrkSumNet = WrkSumNet + WrkNet
          WrkValue = MyUtils.Round(WrkNet * (MyTXDCCD._ASPCT / 100), 0)
          WrkSumValue = WrkSumValue + WrkValue
      Next
    End If
    'MK 9/23/25 End

    If SaveCode > 0 Then
      WriteTXDCSUM(WrkList, WrkYear, SaveCode, WrkSumValue, WrkSumNet)
    End If

    ds2 = MyTXDCEXM.GetByList(WrkList, WrkLastYear)
    If ds2.Tables(0).Rows.Count > 0 Then
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        WrkCode = ds2.Tables(0).Rows(I).Item("code")
        If WrkYear = 2011 Then
          If Mid(WrkCode, 1, 1) = "N" Or Mid(WrkCode, 1, 1) = "R" Then
            WrkCode = "U"
          End If
        End If
        With MyTXDCEXM
          .GetOneRecordP(WrkList, WrkYear, WrkCode)
          MyTXDCEX.GetOneRecordP(WrkYear, WrkCode)
          If Not MyTXDCEX.RecordNotFound Then
            ._STATUS = ds2.Tables(0).Rows(I).Item("status")
            If .RecordNotFound Then
              ._LISTNO = WrkList
              ._YEAR = WrkYear
              ._CODE = WrkCode
              ._VALUE = ds2.Tables(0).Rows(I).Item("value")
              .AddOneRecordP()
            Else
              ._VALUE = ._VALUE + ds2.Tables(0).Rows(I).Item("value")
              .UpdateOneRecordP()
            End If
          End If
        End With
      Next
    End If

    ds2 = MyTXDCHOR.GetByList(WrkList, WrkLastYear)
    If ds2.Tables(0).Rows.Count > 0 Then
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        With MyTXDCHOR
          .GetOneRecordP(WrkList, WrkYear, 0)
          ._LISTNO = WrkList
          ._YEAR = WrkYear
          ._SEQNO = ds2.Tables(0).Rows(I).Item("seqno")
          ._AGE = ds2.Tables(0).Rows(I).Item("age")
          ._BREED = ds2.Tables(0).Rows(I).Item("breed")
          ._QUALCD = ds2.Tables(0).Rows(I).Item("qualcd")
          ._REG = ds2.Tables(0).Rows(I).Item("reg")
          ._SEX = ds2.Tables(0).Rows(I).Item("sex")
          ._VALUE = ds2.Tables(0).Rows(I).Item("value")
          .AddOneRecordP()
        End With
      Next
    End If

    ds2 = MyTXDCLEE.GetByList(WrkList, WrkLastYear)
    If ds2.Tables(0).Rows.Count > 0 Then
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        With MyTXDCLEE
          .GetOneRecordP(WrkList, WrkYear, 0)
          ._LISTNO = WrkList
          ._YEAR = WrkYear
          ._SEQNO = ds2.Tables(0).Rows(I).Item("seqno")
          ._ACQITM = ds2.Tables(0).Rows(I).Item("acqitm")
          ._ADDR = ds2.Tables(0).Rows(I).Item("addr")
          ._CAPLES = ds2.Tables(0).Rows(I).Item("caples")
          ._COST = ds2.Tables(0).Rows(I).Item("cost")
          ._DESC = ds2.Tables(0).Rows(I).Item("desc")
          ._DSPITM = ds2.Tables(0).Rows(I).Item("dspitm")
          ._LESNO = ds2.Tables(0).Rows(I).Item("lesno")
          ._NAME = ds2.Tables(0).Rows(I).Item("name")
          ._RENT = ds2.Tables(0).Rows(I).Item("rent")
          ._SERIAL = ds2.Tables(0).Rows(I).Item("serial")
          ._TERM = ds2.Tables(0).Rows(I).Item("term")
          ._YRINC = ds2.Tables(0).Rows(I).Item("yrinc")
          ._YRMFG = ds2.Tables(0).Rows(I).Item("yrmfg")
          .AddOneRecordP()
        End With
      Next
    End If

    ds2 = MyTXDCLOR.GetByList(WrkList, WrkLastYear)
    If ds2.Tables(0).Rows.Count > 0 Then
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        With MyTXDCLOR
          .GetOneRecordP(WrkList, WrkYear, 0)
          ._LISTNO = WrkList
          ._YEAR = WrkYear
          ._SEQNO = ds2.Tables(0).Rows(I).Item("seqno")
          ._ADDR = ds2.Tables(0).Rows(I).Item("addr")
          ._COSTS = ds2.Tables(0).Rows(I).Item("costs")
          ._DESC = ds2.Tables(0).Rows(I).Item("desc")
          ._LESTYP = ds2.Tables(0).Rows(I).Item("lestyp")
          ._MFG = ds2.Tables(0).Rows(I).Item("mfg")
          ._NAME = ds2.Tables(0).Rows(I).Item("name")
          ._NEWMFG = ds2.Tables(0).Rows(I).Item("newmfg")
          ._NEWTYP = ds2.Tables(0).Rows(I).Item("newtyp")
          ._PHYLOC = ds2.Tables(0).Rows(I).Item("phyloc")
          ._PRICE = ds2.Tables(0).Rows(I).Item("price")
          ._PURCH = ds2.Tables(0).Rows(I).Item("purch")
          ._PURDT = ds2.Tables(0).Rows(I).Item("purdt")
          ._PURFRM = ds2.Tables(0).Rows(I).Item("purfrm")
          ._RENT = ds2.Tables(0).Rows(I).Item("rent")
          ._TERM = ds2.Tables(0).Rows(I).Item("term")
          ._TRAN = ds2.Tables(0).Rows(I).Item("tran")
          .AddOneRecordP()
        End With
      Next
    End If

    ds2 = MyTXDCMOB.GetByList(WrkList, WrkLastYear)
    If ds2.Tables(0).Rows.Count > 0 Then
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        With MyTXDCMOB
          .GetOneRecordP(WrkList, WrkYear, 0)
          ._LISTNO = WrkList
          ._YEAR = WrkYear
          ._SEQNO = ds2.Tables(0).Rows(I).Item("seqno")
          ._BATHS = ds2.Tables(0).Rows(I).Item("baths")
          ._LENGTH = ds2.Tables(0).Rows(I).Item("length")
          ._MAKE = ds2.Tables(0).Rows(I).Item("make")
          ._MODEL = ds2.Tables(0).Rows(I).Item("model")
          ._VALUE = ds2.Tables(0).Rows(I).Item("value")
          ._VINNO = ds2.Tables(0).Rows(I).Item("vinno")
          ._VYEAR = ds2.Tables(0).Rows(I).Item("vyear")
          ._WIDTH = ds2.Tables(0).Rows(I).Item("width")
          .AddOneRecordP()
        End With
      Next
    End If

    ds2 = MyTXDCMV.GetByList(WrkList, WrkLastYear)
    If ds2.Tables(0).Rows.Count > 0 Then
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        With MyTXDCMV
          .GetOneRecordP(WrkList, WrkYear, 0)
          ._LISTNO = WrkList
          ._YEAR = WrkYear
          ._SEQNO = ds2.Tables(0).Rows(I).Item("seqno")
          ._LENGTH = ds2.Tables(0).Rows(I).Item("length")
          ._MAKE = ds2.Tables(0).Rows(I).Item("make")
          ._MODEL = ds2.Tables(0).Rows(I).Item("model")
          ._MSRP = ds2.Tables(0).Rows(I).Item("msrp")
          ._PURDT = ds2.Tables(0).Rows(I).Item("purdt")
          ._PURVL = ds2.Tables(0).Rows(I).Item("purvl")
          'MK 8/11/25 Begin
          '._VALUE = CalcValue(ds2.Tables(0).Rows(I).Item("msrp"), 0, wrkyear)
          If ds2.Tables(0).Rows(I).Item("msrp") > 0 Then
            ._VALUE = CalcValue(ds2.Tables(0).Rows(I).Item("msrp"), 0, WrkYear, ds2.Tables(0).Rows(I).Item("vyear"))
          Else
            ._VALUE = ds2.Tables(0).Rows(I).Item("value")
          End If
          'MK 8/11/25 End
          ._VINNO = ds2.Tables(0).Rows(I).Item("vinno")
          ._VYEAR = ds2.Tables(0).Rows(I).Item("vyear")
          ._WEIGHT = ds2.Tables(0).Rows(I).Item("weight")
          .AddOneRecordP()
        End With
      Next
    End If

    ds2 = MyTXDCTWN.GetByList(WrkList, WrkLastYear)
    If ds2.Tables(0).Rows.Count > 0 Then
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        With MyTXDCTWN
          .GetOneRecordP(WrkList, WrkYear, 0)
          ._LISTNO = WrkList
          ._YEAR = WrkYear
          ._SEQNO = ds2.Tables(0).Rows(I).Item("seqno")
          ._CODE = ds2.Tables(0).Rows(I).Item("code")
          ._COST = ds2.Tables(0).Rows(I).Item("cost")
          ._LOC = ds2.Tables(0).Rows(I).Item("loc")
          ._LOCNO = ds2.Tables(0).Rows(I).Item("locno")
          ._MONTHS = ds2.Tables(0).Rows(I).Item("months")
          .AddOneRecordP()
        End With
      Next
    End If

    MyTXDMPP_LY.GetOneRecordP(WrkList, WrkLastYear)
    If Not MyTXDMPP_LY.RecordNotFound Then
      MyTXDMPP.GetOneRecordP(WrkList, WrkYear)
      If Not MyTXDMPP.RecordNotFound Then
        GoTo CopyDV
      End If
      With MyTXDMPP
        ._LISTNO = WrkList
        ._YEAR = WrkYear
        ._ADDR = Trim(MyTXDMPP_LY._ADDR)
        ._BADDR = Trim(MyTXDMPP_LY._BADDR)
        ._BCITY = Trim(MyTXDMPP_LY._BCITY)
        ._BSTATE = Trim(MyTXDMPP_LY._BSTATE)
        ._BUSACT = Trim(MyTXDMPP_LY._BUSACT)
        ._BZIP4 = MyTXDMPP_LY._BZIP4
        ._BZIP5 = MyTXDMPP_LY._BZIP5
        ._CFAX = MyTXDMPP_LY._CFAX
        ._CITY = Trim(MyTXDMPP_LY._CITY)
        ._CNAME = Trim(MyTXDMPP_LY._CNAME)
        ._CPHONE = MyTXDMPP_LY._CPHONE
        ._CTID = Trim(MyTXDMPP_LY._CTID)
        ._CTITLE = Trim(MyTXDMPP_LY._CTITLE)
        ._EXEMPT = Trim(MyTXDMPP_LY._EXEMPT)
        ._FEDID = Trim(MyTXDMPP_LY._FEDID)
        ._G1MFG = Trim(MyTXDMPP_LY._G1MFG)
        ._G2RES = Trim(MyTXDMPP_LY._G2RES)
        ._G3MACH = Trim(MyTXDMPP_LY._G3MACH)
        ._G4PROD = Trim(MyTXDMPP_LY._G4PROD)
        ._G5MEAS = Trim(MyTXDMPP_LY._G5MEAS)
        ._G6MET = Trim(MyTXDMPP_LY._G6MET)
        ._G7MOV = Trim(MyTXDMPP_LY._G7MOV)
        ._G8BIO = Trim(MyTXDMPP_LY._G8BIO)
        ._G9REC = Trim(MyTXDMPP_LY._G9REC)
        ._LCITY = Trim(MyTXDMPP_LY._LCITY)
        ._LOC = Trim(MyTXDMPP_LY._LOC)
        ._LOCNO = Trim(MyTXDMPP_LY._LOCNO)
        ._LSTATE = Trim(MyTXDMPP_LY._LSTATE)
        ._LZIP4 = MyTXDMPP_LY._LZIP4
        ._LZIP5 = MyTXDMPP_LY._LZIP5
        ._NAME = Trim(MyTXDMPP_LY._NAME)
        ._RADDR = Trim(MyTXDMPP_LY._RADDR)
        ._RCITY = Trim(MyTXDMPP_LY._RCITY)
        ._RCVBEN = Trim(MyTXDMPP_LY._RCVBEN)
        ._RECVDT = 0
        ._RNAME = Trim(MyTXDMPP_LY._RNAME)
        ._RSTATE = Trim(MyTXDMPP_LY._RSTATE)
        ._RZIP4 = MyTXDMPP_LY._RZIP4
        ._RZIP5 = MyTXDMPP_LY._RZIP5
        ._SIGNDT = 0
        ._SIGNED = String.Empty
        ._STATE = Trim(MyTXDMPP_LY._STATE)
        ._ZIP4 = MyTXDMPP_LY._ZIP4
        ._ZIP5 = MyTXDMPP_LY._ZIP5
        .AddOneRecordP()
      End With
    End If

    ds2 = MyTXDMDEP.GetAllYear(WrkYear)
    If ds2.Tables(0).Rows.Count > 1 Then
      SaveYearNo = ds2.Tables(0).Rows(ds2.Tables(0).Rows.Count - 1).Item("yearno")
    End If
    ds2.Clear()

    MyTXDMCD.GetOneRecordP(WrkYear, 13, "")
    ds2 = MyTXDMLST.GetByList(WrkList, WrkLastYear)
    If ds2.Tables(0).Rows.Count > 0 Then
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        With MyTXDMLST
          .GetOneRecordP(WrkList, WrkYear, 0)
          ._LISTNO = WrkList
          ._YEAR = WrkYear
          ._SEQNO = ds2.Tables(0).Rows(I).Item("seqno")
          ._ACQCST = ds2.Tables(0).Rows(I).Item("acqcst")
          ._ACQDT = ds2.Tables(0).Rows(I).Item("acqdt")
          ._GLYEAR = ds2.Tables(0).Rows(I).Item("glyear")
          ._INSDT = ds2.Tables(0).Rows(I).Item("insdt")
          ._IRSCLS = ds2.Tables(0).Rows(I).Item("irscls")
          ._LEASE = ds2.Tables(0).Rows(I).Item("lease")
          ._PRDESC = ds2.Tables(0).Rows(I).Item("prdesc")
          ._PRMOD = ds2.Tables(0).Rows(I).Item("prmod")
          ._PURCH = ds2.Tables(0).Rows(I).Item("purch")
          ._QTY = ds2.Tables(0).Rows(I).Item("qty")
          ._TRANS = ds2.Tables(0).Rows(I).Item("trans")
          .AddOneRecordP()
        End With
        WrkYearNo = WrkYear - ds2.Tables(0).Rows(I).Item("glyear") + 1
        MyTXDMDEP.GetOneRecordP(WrkYear, WrkYearNo)
        If MyTXDMDEP.RecordNotFound Then
          MyTXDMDEP.GetOneRecordP(WrkYear, SaveYearNo)
        End If
        WrkNet = ds2.Tables(0).Rows(I).Item("purch") + ds2.Tables(0).Rows(I).Item("trans")
        WriteTXDMSUM(WrkList, WrkYear, WrkYearNo, WrkNet, ds2.Tables(0).Rows(I).Item("qty"))
      Next
    End If
    ds2.Clear()

    WrkNet = 0
    WrkValue = 0
    ds2 = MyTXDMSUM.GetByList(WrkList, WrkYear)
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      WrkValue = WrkValue + ds2.Tables(0).Rows(I).Item("denet")
      WrkNet = WrkNet + ds2.Tables(0).Rows(I).Item("asnet")
    Next
    ds2.Clear()
    If WrkNet > 0 Then
      With MyTXDCSUM
        .GetOneRecordP(WrkList, WrkYear, 13)
        ._LISTNO = WrkList
        ._YEAR = WrkYear
        ._CODE = 13
        ._NET = WrkNet
        ._STATUS = String.Empty
        ._VALUE = WrkValue
        If .RecordNotFound Then
          .AddOneRecordP()
        Else
          .UpdateOneRecordP()
        End If
      End With
    End If

    ds2 = MyTXDCSUM.GetByList(WrkList, WrkLastYear)
    If ds2.Tables(0).Rows.Count > 0 Then
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        With MyTXDCSUM
          .GetOneRecordP(WrkList, WrkYear, ds2.Tables(0).Rows(I).Item("code"))
          If .RecordNotFound Then
            MyTXDCCD.GetOneRecordP(WrkYear, ds2.Tables(0).Rows(I).Item("code"), String.Empty)
            If MyTXDCCD.RecordNotFound Then
              Continue For
            End If
            If ds2.Tables(0).Rows(I).Item("code") = 25 Then
              Continue For
            End If
            ._LISTNO = WrkList
            ._YEAR = WrkYear
            ._CODE = ds2.Tables(0).Rows(I).Item("code")
            ._NET = ds2.Tables(0).Rows(I).Item("net")
            ._STATUS = String.Empty
            ._VALUE = ds2.Tables(0).Rows(I).Item("value")
            If .RecordNotFound Then
              .AddOneRecordP()
            End If
          End If
        End With
      Next
    End If

CopyDV:
    MyTXDVPP_LY.GetOneRecordP(WrkList, WrkLastYear)
    If Not MyTXDVPP_LY.RecordNotFound Then
      MyTXDVPP.GetOneRecordP(WrkList, WrkYear)
      If Not MyTXDVPP.RecordNotFound Then
        GoTo Done
      End If
      With MyTXDVPP
        ._LISTNO = WrkList
        ._YEAR = WrkYear
        ._ADATE = 0
        ._ADDR = Trim(MyTXDVPP_LY._ADDR)
        ._ANAME = String.Empty
        ._CAMPNM = Trim(MyTXDVPP_LY._CAMPNM)
        ._CHASS = Trim(MyTXDVPP_LY._CHASS)
        ._CITY = Trim(MyTXDVPP_LY._CITY)
        ._CTRAIL = Trim(MyTXDVPP_LY._CTRAIL)
        ._EMAIL = Trim(MyTXDVPP_LY._EMAIL)
        ._ENGINE = Trim(MyTXDVPP_LY._ENGINE)
        ._FAX = MyTXDVPP_LY._FAX
        ._FROMDT = MyTXDVPP_LY._FROMDT
        ._FWHEEL = Trim(MyTXDVPP_LY._FWHEEL)
        ._LENGTH = MyTXDVPP_LY._LENGTH
        ._LOC = Trim(MyTXDVPP_LY._LOC)
        ._LOCNO = Trim(MyTXDVPP_LY._LOCNO)
        ._MAKE = Trim(MyTXDVPP_LY._MAKE)
        ._MHOME = Trim(MyTXDVPP_LY._MHOME)
        ._MODEL = Trim(MyTXDVPP_LY._MODEL)
        ._MODELN = Trim(MyTXDVPP_LY._MODELN)
        'MK 8/18/25 Begin
        ._MSRP = MyTXDVPP_LY._MSRP
        'MK 8/18/25 End
        ._NAME = Trim(MyTXDVPP_LY._NAME)
        ._ODATE = 0
        ._ONAME = String.Empty
        ._PCHASS = Trim(MyTXDVPP_LY._PCHASS)
        ._PHONE = MyTXDVPP_LY._PHONE
        ._PROPYR = Trim(MyTXDVPP_LY._PROPYR)
        ._PURDT = MyTXDVPP_LY._PURDT
        ._PURVL = MyTXDVPP_LY._PURVL
        ._REG = Trim(MyTXDVPP_LY._REG)
        ._REGWH = Trim(MyTXDVPP_LY._REGWH)
        ._SLDON = Trim(MyTXDVPP_LY._SLDON)
        ._SLDOUT = Trim(MyTXDVPP_LY._SLDOUT)
        ._STATE = Trim(MyTXDVPP_LY._STATE)
        ._TODT = MyTXDVPP_LY._TODT
        ._TTRAIL = Trim(MyTXDVPP_LY._TTRAIL)
        ._VYEAR = MyTXDVPP_LY._VYEAR
        ._WDATE = 0
        ._WIDTH = MyTXDVPP_LY._WIDTH
        ._WNAME = String.Empty
        ._ZIP4 = MyTXDVPP_LY._ZIP4
        ._ZIP5 = MyTXDVPP_LY._ZIP5
        .AddOneRecordP()
      End With
    End If

    ds2 = MyTXDVPI.GetByList(WrkList, WrkLastYear)
    If ds2.Tables(0).Rows.Count > 0 Then
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        With MyTXDVPI
          .GetOneRecordP(WrkList, WrkYear, 0)
          ._LISTNO = WrkList
          ._YEAR = WrkYear
          ._METAL = ds2.Tables(0).Rows(I).Item("metal")
          ._SIZE1 = ds2.Tables(0).Rows(I).Item("size1")
          ._SIZE2 = ds2.Tables(0).Rows(I).Item("size2")
          ._VALUE = ds2.Tables(0).Rows(I).Item("value")
          .AddOneRecordP()
        End With
      Next
    End If

    ds2 = MyTXDVPN.GetByList(WrkList, WrkLastYear)
    If ds2.Tables(0).Rows.Count > 0 Then
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        With MyTXDVPN
          .GetOneRecordP(WrkList, WrkYear, 0)
          ._LISTNO = WrkList
          ._YEAR = WrkYear
          ._CAT = ds2.Tables(0).Rows(I).Item("cat")
          ._DESC = ds2.Tables(0).Rows(I).Item("desc")
          ._MAKE = ds2.Tables(0).Rows(I).Item("make")
          ._MODEL = ds2.Tables(0).Rows(I).Item("model")
          ._VALUE = ds2.Tables(0).Rows(I).Item("value")
          ._VYEAR = ds2.Tables(0).Rows(I).Item("vyear")
          .AddOneRecordP()
        End With
      Next
    End If

Done:
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  'MK 8/11/25 Begin
  'Private Function CalcValue(ByVal WrkMSRP As Integer, ByVal WrkOvMSRP As Integer, ByVal WrkYear As Integer) As Integer
  Private Function CalcValue(ByVal WrkMSRP As Integer, ByVal WrkOvMSRP As Integer, ByVal WrkYear As Integer,
    ByVal WrkVehYear As Integer) As Integer
    'MK 8/11/25 End
    Dim WrkDeYear As Integer
    Dim WrkValue As Integer
    Dim WrkDepr As Decimal
    'Calculate Assessment Value
    WrkValue = 0
    'MK 8/11/25 Begin
    'WrkDeYear = 2025 - WrkVehYear + 1
    WrkDeYear = WrkYear - WrkVehYear + 1
    'MK 8/11/25 End
    If WrkDeYear < 1 Then
      WrkDeYear = 1
    End If
    WrkDepr = GetTXMSRPDEP(WrkDeYear)
    If WrkOvMSRP > 0 Then
      WrkValue = WrkOvMSRP * WrkDepr
    Else
      WrkValue = WrkMSRP * WrkDepr
    End If
    If WrkValue < MyMinValue Then
      WrkValue = MyMinValue
    End If
    Return WrkValue
  End Function
  Public Function GetTXMSRPDEP(ByVal DeprYear As Integer) As Decimal
    Dim WrkDepr As Decimal
    If DeprYear < 0 Then DeprYear = 1
    WrkDepr = MyTXMSRPDEP.GetDepr(DeprYear)
    Return WrkDepr
  End Function
  Private Sub WriteTXDCSUM(ByVal WrkList As Integer, ByVal WrkYear As Integer, ByVal WrkCode As Integer, ByVal WrkNet As Long,
  ByVal WrkValue As Long)

    Dim WrkLastYear As Integer
    WrkLastYear = WrkYear - 1

    If MyDeclRound Then
      WrkNet = RoundNumber(WrkNet, "Normal")
    End If
    MyTXDCSUM.GetOneRecordP(WrkList, WrkLastYear, WrkCode)
    If Not MyTXDCSUM.RecordNotFound Then
      With MyTXDCSUM
        .GetOneRecordP(WrkList, WrkYear, WrkCode)
        If .RecordNotFound Then
          ._LISTNO = WrkList
          ._YEAR = WrkYear
          ._CODE = WrkCode
          ._NET = WrkNet
          ._STATUS = String.Empty
          ._VALUE = WrkValue
          .AddOneRecordP()
        Else
          ._NET = ._NET + WrkNet
          ._STATUS = String.Empty
          ._VALUE = ._VALUE + WrkValue
          .UpdateOneRecordP()
        End If
      End With
    End If
  End Sub
  Private Sub WriteTXDMSUM(ByVal WrkList As Integer, ByVal WrkYear As Integer, ByVal WrkDeYear As Integer, ByVal WrkDeCost As Long,
 ByVal WrkQty As Integer)

    Dim WrkLastYear As Integer
    WrkLastYear = WrkYear - 1

    MyTXDMSUM.GetOneRecordP(WrkList, WrkYear, WrkDeYear)
    With MyTXDMSUM
      If .RecordNotFound Then
        ._LISTNO = WrkList
        ._YEAR = WrkYear
        ._DEYEAR = WrkDeYear
        ._QTY = WrkQty
        ._DECOST = ._DECOST + WrkDeCost
        ._DENET = MyUtils.Round(._DECOST * (MyTXDMDEP._PCT / 100), 0)
        ._ASCOST = MyUtils.Round(._DECOST * (MyTXDMCD._ASPCT / 100), 0)
        ._ASNET = MyUtils.Round(._DENET * (MyTXDMCD._ASPCT / 100), 0)
        .AddOneRecordP()
      Else
        ._QTY = ._QTY + WrkQty
        ._DECOST = ._DECOST + WrkDeCost
        ._DENET = MyUtils.Round(._DECOST * (MyTXDMDEP._PCT / 100), 0)
        ._ASCOST = MyUtils.Round(._DECOST * (MyTXDMCD._ASPCT / 100), 0)
        ._ASNET = MyUtils.Round(._DENET * (MyTXDMCD._ASPCT / 100), 0)
        .UpdateOneRecordP()
      End If
    End With
  End Sub
End Module






