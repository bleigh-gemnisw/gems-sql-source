Imports System.Text
Module ProcessFile

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim MyGLFUND As GLFUND.MyData
  Dim MyGLFUNDTo As GLFUND.MyData
  Dim myGLACCTQ As GLACCTQ.MyData
  Dim myGLACCT As GLACCT.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  'General
  Dim WrkFundFrom As Integer
  Dim WrkSfundFrom As Integer
  Dim WrkDeptFrom As Integer
  Dim WrkObjFrom As Integer
  Dim WrkFundTo As Integer
  Dim WrkSfundTo As Integer
  Dim WrkDeptTo As Integer
  Dim WrkObjTo As Integer
  Dim WrkCopied As Integer
  Dim WrkSkipped As Integer

  Public Sub ProcFile()

    MyGLFUND = New GLFUND.MyData
    MyGLFUND.MyDBConn = myDBConnect
    MyGLFUNDTo = New GLFUND.MyData
    MyGLFUNDTo.MyDBConn = myDBConnect
    myGLACCTQ = New GLACCTQ.MyData()
    myGLACCTQ.MyDBConn = myDBConnect
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
    GetDetail()
  End Sub
  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkCopy As String
    Dim Counter As Integer
    Dim WrkAnd As String
    Dim WrkOr As String

    WrkCopy = ""
    With MyFrmGL111B
      WrkFundFrom = MyUtils.CnvSng(.TxtFundFrom.Text)
      WrkFundTo = MyUtils.CnvSng(.TxtFundTo.Text)
      WrkSfundFrom = MyUtils.CnvSng(.TxtSfundFrom.Text)
      WrkSfundTo = MyUtils.CnvSng(.TxtSfundTo.Text)
      WrkDeptFrom = MyUtils.CnvSng(.TxtDeptFrom.Text)
      WrkDeptTo = MyUtils.CnvSng(.TxtDeptTo.Text)
      WrkObjFrom = MyUtils.CnvSng(.TxtObjFrom.Text)
      WrkObjTo = MyUtils.CnvSng(.TxtObjTo.Text)
      If .RbFund.Checked Then WrkCopy = "Fund"
      If .RbDept.Checked Then WrkCopy = "Dept"
      If .RbObj.Checked Then WrkCopy = "Obj"
    End With

    WrkAnd = " and "
    WrkOr = " or "
    WrkCopied = 0
    WrkSkipped = 0

    If WrkCopy = "Fund" Then
      CopyFund()
    End If

    WrkSort = "FDNBR, SFUND"
    WrkQry = "ACREC<>'I' and FDNBR=" & WrkFundFrom & WrkAnd & "SFUND=" & WrkSfundFrom
    If WrkCopy = "Dept" Or WrkCopy = "Obj" Then
      WrkQry = WrkQry & WrkAnd & "DPNBR=" & WrkDeptFrom
    End If
    If WrkCopy = "Obj" Then
      WrkQry = WrkQry & WrkAnd & "OBNBR=" & WrkObjFrom
    End If
    myGLACCTQ.OpenQry(WrkSort, WrkQry)
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myGLACCTQ.ReadQry()
    If Not myGLACCTQ.IsEOF Then
      With myGLACCT
        Counter = Counter + 1
        Select Case WrkCopy
          Case "Fund"
            WrkDeptTo = myGLACCTQ._DPNBR
            WrkObjTo = myGLACCTQ._OBNBR
          Case "Dept"
            WrkObjTo = myGLACCTQ._OBNBR
          Case Else
        End Select
        .GetOneRecordP(WrkFundTo, WrkSfundTo, WrkDeptTo, WrkObjTo, myGLACCTQ._FNPGM, myGLACCTQ._SUBFN)
        If .RecordNotFound Then
          WrkCopied = WrkCopied + 1
          ._ACREC = myGLACCTQ._ACREC
          ._CSHYN = myGLACCTQ._CSHYN
          ._DPNBR = WrkDeptTo
          ._FDNBR = WrkFundTo
          ._FIL02 = myGLACCTQ._FIL02
          ._FIL03 = myGLACCTQ._FIL03
          ._FNPGM = myGLACCTQ._FNPGM
          ._GLDSC = myGLACCTQ._GLDSC
          ._GLTYP = myGLACCTQ._GLTYP
          ._NONPR = myGLACCTQ._NONPR
          ._OBNBR = WrkObjTo
          ._RLNBR = myGLACCTQ._RLNBR
          ._SFUND = WrkSfundTo
          ._SUBFN = myGLACCTQ._SUBFN
          .AddOneRecordP()
        Else
          WrkSkipped = WrkSkipped + 1
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
    myGLACCTQ.CloseFile()
    myGLACCT.CloseFile()
    MyFrmGL111B.LblMsg.Text = "Records Copied=" & WrkCopied & "/Skipped=" & WrkSkipped
  End Sub
  Public Sub CopyFund()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    Application.DoEvents()

    MyGLFUND.GetOneRecordP(WrkFundFrom, WrkSfundFrom)
    If Not MyGLFUND.RecordNotFound Then
      With MyGLFUNDTo
        .GetOneRecordP(WrkFundTo, WrkSfundTo)
        ._ACCFN = MyGLFUND._ACCFN
        ._ACREC = MyGLFUND._ACREC
        ._DPNBR1 = MyGLFUND._DPNBR1
        ._DPNBR2 = MyGLFUND._DPNBR2
        ._DPNBRA = MyGLFUND._DPNBRA
        ._DPNBRC = MyGLFUND._DPNBRC
        ._DPNBRE = MyGLFUND._DPNBRE
        ._DPNBRF = MyGLFUND._DPNBRF
        ._DPNBRR = MyGLFUND._DPNBRR
        ._DSFND = MyGLFUND._DSFND
        ._DSPCT = MyGLFUND._DSPCT
        ._ENTFN = MyGLFUND._ENTFN
        ._FDNBR = WrkFundTo
        ._FDNBR1 = WrkFundTo
        ._FDNBR2 = WrkFundTo
        ._FDNBRA = WrkFundTo
        ._FDNBRC = WrkFundTo
        ._FDNBRE = WrkFundTo
        ._FDNBRF = WrkFundTo
        ._FDNBRR = WrkFundTo
        ._FENDT = MyGLFUND._FENDT
        ._FIL01 = MyGLFUND._FIL01
        ._FNDSC = MyGLFUND._FNDSC
        ._FNPGM1 = MyGLFUND._FNPGM1
        ._FNPGM2 = MyGLFUND._FNPGM2
        ._FNPGMA = MyGLFUND._FNPGMA
        ._FNPGMC = MyGLFUND._FNPGMC
        ._FNPGME = MyGLFUND._FNPGME
        ._FNPGMF = MyGLFUND._FNPGMF
        ._FNPGMR = MyGLFUND._FNPGMR
        ._FSTDT = MyGLFUND._FSTDT
        ._GROUP = MyGLFUND._GROUP
        ._OBNBR1 = MyGLFUND._OBNBR1
        ._OBNBR2 = MyGLFUND._OBNBR2
        ._OBNBRA = MyGLFUND._OBNBRA
        ._OBNBRC = MyGLFUND._OBNBRC
        ._OBNBRE = MyGLFUND._OBNBRE
        ._OBNBRF = MyGLFUND._OBNBRF
        ._OBNBRR = MyGLFUND._OBNBRR
        ._SFUND = WrkSfundTo
        ._SFUND1 = WrkSfundTo
        ._SFUND2 = WrkSfundTo
        ._SFUNDA = WrkSfundTo
        ._SFUNDC = WrkSfundTo
        ._SFUNDE = WrkSfundTo
        ._SFUNDF = WrkSfundTo
        ._SFUNDR = WrkSfundTo
        ._SUBFN1 = MyGLFUND._SUBFN1
        ._SUBFN2 = MyGLFUND._SUBFN2
        ._SUBFNA = MyGLFUND._SUBFNA
        ._SUBFNC = MyGLFUND._SUBFNC
        ._SUBFNE = MyGLFUND._SUBFNE
        ._SUBFNF = MyGLFUND._SUBFNF
        ._SUBFNR = MyGLFUND._SUBFNR
        .AddOneRecordP()
      End With
    End If

Done:
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
End Module
