Module PrintReport
Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALCQ As TXREALCQ.myData
Dim myTXLOCAL As TXLOCAL.myData
Dim myTXLOCCD As TXLOCCD.myData
Dim myTXLOCFRZ As TXLOCFRZ.myData
Dim myTPAYMNT As TPAYMNT.MyData
Dim DsTXREALC As DataSet = New DataSet
Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkGLYear As Integer
Dim WrkCode As String
Dim WrkCC As Boolean
Dim WrkBTR As Boolean
Dim WrkSName As Boolean
Dim WrkBnCode(100) As String
Dim WrkBnDesc(100) As String
Dim MrateMillrt As Decimal

  Public Sub PrtReport()

	myTXREALCQ = New TXREALCQ.mydata(MyDBConnect)
	myTXLOCAL = New TXLOCAL.mydata(MyDBConnect)
	myTXLOCCD = New TXLOCCD.mydata(MyDBConnect)
	myTXLOCFRZ = New TXLOCFRZ.mydata(MyDBConnect)
	myTPAYMNT = New TPAYMNT.mydata(MyDBConnect)

  With MyFrmTA230B
    WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
		WrkCode = .TxtCode.Text
		WrkCC = False
		If .ChkCC.Checked Then
			WrkCC = True
		End If
		WrkBTR = False
		If .ChkBAA.Checked Then
			WrkBTR = True
		End If
    WrkSName = False
    If .ChkSName.Checked Then
      WrkSName = True
    End If
  End With

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
  End If

  BufferLOCCD()
	GetMillRate(WrkGLYear, 0)
	GetDetail()

  MyCrViewer = New FrmCrViewer
  With MyCrViewer
    .Wrkds = ds
    .WrkCode = WrkCode
    .Show()
  End With
  End Sub
Friend Sub BuildDS()
  Dim myTable As New DataTable

  With myTable
    .TableName = "mytable"
    .Columns.Add("listno", Type.GetType("System.Int64"))
    .Columns.Add("name", Type.GetType("System.String"))
    .Columns.Add("sname", Type.GetType("System.String"))
    .Columns.Add("proploc", Type.GetType("System.String"))
    .Columns.Add("code", Type.GetType("System.String"))
    .Columns.Add("descr", Type.GetType("System.String"))
    .Columns.Add("localcredit", Type.GetType("System.Decimal"))
  End With
  ds.Tables.Add(myTable)
End Sub
  Private Sub GetDetail()
    Dim DsTXLOCAL As DataSet = New DataSet
    Dim DsTXLOCAL2 As DataSet = New DataSet
    Dim WrkSort As String
    Dim WrkQry As String
    Dim J As Integer
    Dim WrkAnd As String
    Dim WrkOr As String
    Dim Counter As Integer
    Dim Good As Boolean
    Dim WrkLocalAmt As Decimal
    Dim WrkNet As Integer
    Dim WrkTax As Decimal
    Dim WrkBenefit As Decimal
    Dim WrkLocal As Decimal

    If myDBConnect.ServerAS400 Then
      WrkOr = " *or "
      WrkAnd = " *and "
    Else
      WrkOr = " or "
      WrkAnd = " and "
    End If

    Counter = 0
    WrkSort = "NAME, LIST#"
    WrkQry = "TWNBN <> 0"

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
        WrkLocalAmt = 0
        DsTXLOCAL = myTXLOCAL.GetViewbyList(._LISTNO, WrkGLYear, "R", 999)
        If DsTXLOCAL.Tables(0).Rows.Count = 0 Then
          DsTXLOCAL2 = myTXLOCAL.GetViewbyList(._LISTNO, WrkGLYear - 1, "R", 999)
          DsTXLOCAL.Merge(DsTXLOCAL2)
        End If
        If DsTXLOCAL.Tables(0).Rows.Count = 0 Then GoTo NextRec
        For J = 0 To (DsTXLOCAL.Tables(0).Rows.Count - 1)
          Good = True
          If WrkCode <> String.Empty Then
            If WrkCode <> DsTXLOCAL.Tables(0).Rows(J).Item("bencde") Then
              Good = False
            End If
          End If
          If Not Good Then Continue For
          dr = ds.Tables(0).NewRow
          dr.Item("listno") = ._LISTNO
          dr.Item("name") = Trim(._NAME)
          dr.Item("sname") = Trim(._SNAME)
          dr.Item("proploc") = Trim(._LOCNO) & " " & Trim(._LOC)
          With DsTXLOCAL.Tables(0).Rows(J)
            dr.Item("code") = .Item("bencde")
            dr.Item("descr") = LookupLOCCD(.Item("bencde"))
            dr.Item("localcredit") = .Item("benamt")
            WrkLocalAmt = WrkLocalAmt + .Item("benamt")
          End With
          ds.Tables(0).Rows.Add(dr)
        Next
        If WrkLocalAmt = 0 And WrkCode = String.Empty Then
          myTXLOCFRZ.GetOneRecordP(._LISTNO)
          If Not myTXLOCFRZ.RecordNotFound Then
            If WrkCC And ._CCNO > 0 Then
              WrkNet = ._CCGRS - ._CCEX
            Else
              WrkNet = ._NET + ._BTR
            End If
            WrkTax = MyUtils.Round(WrkNet * MrateMillrt, 2)
            With myTPAYMNT
              .In_Year = WrkGLYear
              .In_Type = "R"
              .In_Dst = 0
              .In_Phs = ""
              .In_TaxT = WrkTax
              .CalcPaySplit()
              WrkTax = .Out_TaxT
            End With
            If Trim(._FCCOD) <> "" Then
              If Trim(._FCCOD) = "C" Then
                WrkBenefit = ._FTAX
              Else
                WrkBenefit = WrkTax - ._FTAX
              End If
              WrkLocal = ._TWNBN
            End If
            dr = ds.Tables(0).NewRow
            dr.Item("listno") = ._LISTNO
            dr.Item("name") = Trim(._NAME)
            dr.Item("sname") = Trim(._SNAME)
            dr.Item("proploc") = Trim(._LOCNO) & " " & Trim(._LOC)
            dr.Item("code") = ""
            dr.Item("descr") = "Local Frozen"
            dr.Item("localcredit") = WrkTax - WrkBenefit - myTXLOCFRZ._FRZTAX
            ds.Tables(0).Rows.Add(dr)
          End If
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
    Application.DoEvents()
    myTXREALCQ.CloseFile()

  End Sub
  Public Sub GetMillRate(ByVal WrkGLYear As Integer, ByVal WrkDist As Integer)
Dim myTXMRATE As TXMRATE.myData

myTXMRATE = New TXMRATE.mydata(MyDBConnect)
myTXMRATE.GetOneRecordP(WrkGLYear, "R", WrkDist)
If myTXMRATE.RecordNotFound Then
  myTXMRATE.GetOneRecordP(WrkGLYear, "", WrkDist)
End If
If Not myTXMRATE.RecordNotFound Then
  With myTXMRATE
    MrateMillrt = ._MRRATE
  End With
End If
myTXMRATE.CloseFile()
End Sub
Private Sub BufferLOCCD()
		 Dim I As Integer

		 Dim myTXLOCCD As TXLOCCD.myData
		 Dim dsTXLOCCD As DataSet = New DataSet

		 myTXLOCCD = New TXLOCCD.mydata(MyDBConnect)

		 dsTXLOCCD = myTXLOCCD.GetAllData
		 For I = 0 To dsTXLOCCD.Tables(0).Rows.Count - 1
			With dsTXLOCCD.Tables(0).Rows(I)
				WrkBnCode(I) = .Item("bncode")
				WrkBnDesc(I) = .Item("bndsc")
			End With
		Next

End Sub
Private Function LookupLOCCD(ByVal Code As String) As String
     Dim I As Integer
     Dim WrkDesc As String

     For I = 0 To WrkBnCode.GetUpperBound(0)
      If Trim(WrkBnCode(I)) = "" Then
        Return ""
      End If
      If Trim(Code) = Trim(WrkBnCode(I)) Then
        WrkDesc = WrkBnDesc(I)
        Return WrkDesc
      End If
    Next

    Return ""
End Function
End Module






