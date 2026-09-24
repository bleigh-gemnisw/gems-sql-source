Imports System.Text
Module PrintReport
  Dim myPOMEMO As POMEMO.MyData
  Dim Acct(9) As String
  Dim AcctTot(9) As Decimal
  Public Sub PrtReport(ByVal dsSel As DataSet)

    Dim myPOMASTL1 As POMASTL1.MyData
    Dim myVENDOR As VENDOR.MyData
    Dim dsPOMAST As DataSet = New DataSet
    Dim sb As StringBuilder
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim dr As Data.DataRow
    Dim dr2 As Data.DataRow
    Dim I As Integer
    Dim J As Integer
    Dim K As Integer
    Dim WrkLastRow As Integer
    Dim WrkAcct As String

    If ds.Tables.Count = 0 Then
      BuildDS(ds)
      BuildDS2(ds2)
    Else
      ds.Clear()
      ds2.Clear()
    End If

    myPOMASTL1 = New POMASTL1.MyData()
    myPOMASTL1.MyDBConn = myDBConnect
    myPOMEMO = New POMEMO.MyData()
    myPOMEMO.MyDBConn = myDBConnect
    myVENDOR = New VENDOR.MyData()
    myVENDOR.MyDBConn = myDBConnect

    Windows.Forms.Cursor.Current = Cursors.WaitCursor()
    For I = 0 To (dsSel.Tables(0).Rows.Count - 1)
      With dsSel.Tables(0).Rows(I)
        If .Item("wsel") Then
          Array.Clear(Acct, 0, 9)
          Array.Clear(AcctTot, 0, 9)
          dsPOMAST = myPOMASTL1.GetAllPONo(.Item("fscyr"), .Item("ponbr"), 0)
          WrkLastRow = dsPOMAST.Tables(0).Rows.Count - 1
          For J = 0 To (dsPOMAST.Tables(0).Rows.Count - 1)
            With dsPOMAST.Tables(0).Rows(J)
              If .Item("poseq") = 0 Then
                dr = ds.Tables(0).NewRow()
                dr.Item("fscyr") = .Item("fscyr")
                dr.Item("ponbr") = .Item("ponbr")
                dr.Item("rentd") = MyUtils.GetDBDate(.Item("rentd"))
                dr.Item("sname") = .Item("sname")
                dr.Item("sadr1") = .Item("sadr1")
                dr.Item("sadr2") = .Item("sadr2")
                If .Item("sadr4") = "" Then
                  dr.Item("sadr3") = .Item("sadr3") & " " & .Item("szip")
                  If .Item("szipe") <> "" Then
                    dr.Item("sadr3") = dr.Item("sadr3") & "-" & .Item("szipe")
                  End If
                Else
                  dr.Item("sadr3") = .Item("sadr3")
                  dr.Item("sadr4") = .Item("sadr4") & " " & .Item("szip")
                  If .Item("szipe") <> "" Then
                    dr.Item("sadr4") = dr.Item("sadr4") & "-" & .Item("szipe")
                  End If
                End If
                dr.Item("vndnr") = .Item("vndnr")
                myVENDOR.GetOneRecordP(.Item("vndnr"))
                If Not myVENDOR.RecordNotFound Then
                  With myVENDOR
                    dr.Item("rname") = Trim(._VENNM)
                    dr.Item("radr1") = Trim(._VADD1)
                    dr.Item("radr2") = Trim(._VADD2)
                    If Trim(._VADD4) = "" Then
                      dr.Item("radr3") = Trim(._VADD3) & " " & Trim(._VZIP)
                      If Trim(._VZIPE) <> "" Then
                        dr.Item("radr3") = dr.Item("radr3") & "-" & Trim(._VZIPE)
                      End If
                    Else
                      dr.Item("radr3") = Trim(._VADD3)
                      dr.Item("radr4") = Trim(._VADD4) & " " & Trim(._VZIP)
                      If Trim(._VZIPE) <> "" Then
                        dr.Item("radr4") = dr.Item("radr4") & "-" & Trim(._VZIPE)
                      End If
                    End If
                  End With
                End If
                dr.Item("totvl") = .Item("amtnt")
                dr.Item("memo") = GetPOMEMO(dsPOMAST.Tables(0).Rows(WrkLastRow).Item("fdnbr"),
                 dsPOMAST.Tables(0).Rows(WrkLastRow).Item("sfund"), .Item("lne"))
                If dr.Item("memo") = String.Empty And dsPOMAST.Tables(0).Rows.Count > 1 Then
                  dr.Item("memo") = GetPOMEMO(dsPOMAST.Tables(0).Rows(1).Item("fdnbr"),
                   dsPOMAST.Tables(0).Rows(0).Item("sfund"), .Item("lne"))
                End If
              Else
                dr2 = ds2.Tables(0).NewRow()
                With dsPOMAST.Tables(0).Rows(J)
                  dr2.Item("fscyr") = .Item("fscyr")
                  dr2.Item("ponbr") = .Item("ponbr")
                  dr2.Item("poseq") = .Item("poseq")
                  dr2.Item("rqqty") = .Item("rqqty")
                  dr2.Item("unitp") = .Item("unitp")
                  If .Item("itnbr") <> "" Then
                    dr2.Item("itdsc") = Trim(.Item("itnbr")) & "  " & .Item("itdsc")
                  Else
                    dr2.Item("itdsc") = .Item("itdsc")
                  End If
                  WrkAcct = BuildAcct(.Item("fdnbr"), .Item("sfund"), .Item("dpnbr"),
            .Item("obnbr"), .Item("fnpgm"), .Item("subfn"), "-")
                  dr2.Item("acctno") = WrkAcct
                  If WrkAcct <> String.Empty Then
                    K = LookupAcct(WrkAcct)
                    Acct(K) = WrkAcct
                    AcctTot(K) = AcctTot(K) + .Item("exval")
                  End If
                  dr2.Item("exval") = .Item("exval")
                  ds2.Tables(0).Rows.Add(dr2)
                End With
              End If
            End With
          Next
          sb = New StringBuilder
          For K = 0 To 9
            If Not IsNothing(Acct(K)) Then
              sb.Append(Acct(K))
              sb.AppendLine(MyUtils.JustifyRight(Format(AcctTot(K), "#,###,###,##0.00"), 20))
            End If
          Next
          dr.Item("acctsum") = sb.ToString
          ds.Tables(0).Rows.Add(dr)
          sb = Nothing
        End If
      End With
    Next
    Windows.Forms.Cursor.Current = Cursors.Default

    If ds.Tables(0).Rows.Count = 0 Then
      MsgBox("No records selected.", MsgBoxStyle.Exclamation, "Report cancelled")
      Exit Sub
    End If

    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkPrtPO = True
    MyCrViewer.wrkds = ds
    MyCrViewer.wrkds2 = ds2
    If MyPrinter = String.Empty Then
      MyCrViewer.ShowDialog()
    Else
      MyCrViewer.RunReport()
    End If
    ds2 = Nothing
    MyCrViewer = Nothing
  End Sub
  Public Sub PrtDtlPay()
    Dim myPOMASTL1 As POMASTL1.MyData
    Dim myAPEHSTL1 As APEHSTL1.MyData
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim dsFile As DataSet = New DataSet
    Dim dr As Data.DataRow
    Dim dr2 As Data.DataRow
    Dim WrkFscyr As Integer
    Dim WrkPONbr As Integer
    Dim WrkAcct As String
    Dim I As Integer

    myPOMASTL1 = New POMASTL1.MyData()
    myPOMASTL1.MyDBConn = myDBConnect
    myAPEHSTL1 = New APEHSTL1.MyData()
    myAPEHSTL1.MyDBConn = myDBConnect

    If ds.Tables.Count = 0 Then
      BuildDS(ds)
      BuildDSDtl(ds2)
    Else
      ds.Clear()
      ds2.Clear()
    End If

    Windows.Forms.Cursor.Current = Cursors.WaitCursor()
    dr = ds.Tables(0).NewRow()
    With MyFrmPO306C
      WrkFscyr = MyUtils.CnvSng(.LblFscyr.Text)
      WrkPONbr = MyUtils.CnvSng(.LblPoNbr.Text)
      dr = ds.Tables(0).NewRow()
      dr.Item("fscyr") = WrkFscyr
      dr.Item("ponbr") = WrkPONbr
      dr.Item("rentd") = .LblRentd.Text
      dr.Item("sname") = .LblSname.Text
      dr.Item("sadr1") = .LblSadr1.Text
      dr.Item("sadr2") = .LblSadr2.Text
      dr.Item("sadr3") = .LblSadr3.Text
      dr.Item("sadr4") = .LblSadr4.Text
      dr.Item("vndnr") = .LblVndnr.Text
      dr.Item("rname") = .LblVennm.Text
      dr.Item("radr1") = .LblRadr1.Text
      dr.Item("radr2") = .LblRadr2.Text
      dr.Item("radr3") = .LblRadr3.Text
      dr.Item("radr4") = .LblRadr4.Text
      dr.Item("totvl") = MyUtils.CnvSng(.LblAmtnt.Text)
      ds.Tables(0).Rows.Add(dr)
    End With

    dsFile = myPOMASTL1.GetViewbyPOL6(WrkFscyr, WrkPONbr, 100)
    For I = 0 To dsFile.Tables(0).Rows.Count - 1
      With dsFile.Tables(0).Rows(I)
        dr2 = ds2.Tables(0).NewRow()
        dr2.Item("rptgrp") = "A"
        dr2.Item("fscyr") = WrkFscyr
        dr2.Item("ponbr") = WrkPONbr
        dr2.Item("poseq") = .Item("poseq")
        dr2.Item("rqqty") = .Item("rqqty")
        dr2.Item("unitp") = .Item("unitp")
        If .Item("itnbr") <> "" Then
          dr2.Item("itdsc") = Trim(.Item("itnbr")) & "  " & .Item("itdsc")
        Else
          dr2.Item("itdsc") = .Item("itdsc")
        End If
        WrkAcct = BuildAcct(.Item("fdnbr"), .Item("sfund"), .Item("dpnbr"),
              .Item("obnbr"), .Item("fnpgm"), .Item("subfn"), "-")
        dr2.Item("acctno") = WrkAcct
        dr2.Item("exval") = .Item("exval")
        ds2.Tables(0).Rows.Add(dr2)
      End With
    Next

    dsFile = myAPEHSTL1.GetViewbyPO(WrkFscyr, WrkPONbr)
    For I = 0 To dsFile.Tables(0).Rows.Count - 1
      With dsFile.Tables(0).Rows(I)
        dr2 = ds2.Tables(0).NewRow()
        dr2.Item("rptgrp") = "B"
        dr2.Item("fscyr") = WrkFscyr
        dr2.Item("ponbr") = WrkPONbr
        dr2.Item("chkdt") = Format(.Item("chkdate"), "##/##/####")
        dr2.Item("invdt") = Format(.Item("invd8"), "##/##/####")
        dr2.Item("invno") = .Item("invno")
        dr2.Item("chkpd") = .Item("chkpd")
        dr2.Item("amtnt") = .Item("amtnt")
        dr2.Item("avoid") = .Item("avoid")
        ds2.Tables(0).Rows.Add(dr2)
      End With
    Next

    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkPrtPO = False
    MyCrViewer.wrkds = ds
    MyCrViewer.wrkds2 = ds2
    If MyPrinter = String.Empty Then
      MyCrViewer.ShowDialog()
    Else
      MyCrViewer.RunReportDtl()
    End If
    ds2 = Nothing
    MyCrViewer = Nothing
  End Sub
  Private Function BuildAcct(ByVal Fund As Integer, ByVal SFund As Integer, ByVal Dept As Integer,
  ByVal Obj As Integer, ByVal Func As Integer, ByVal SFunc As Integer, ByVal Sep As String) As String
    Dim sb As StringBuilder = New StringBuilder

    If Fund = 0 Then Return ""

    sb.Append(Format(Fund, "000"))
    sb.Append(Sep)
    sb.Append(Format(SFund, "000"))
    sb.Append(Sep)
    sb.Append(Format(Dept, "0000"))
    sb.Append(Sep)
    sb.Append(Format(Obj, "000"))
    sb.Append(Sep)
    sb.Append(Format(Func, "0000"))
    sb.Append(Sep)
    sb.Append(Format(SFunc, "0000"))
    Return sb.ToString
  End Function

  Private Function GetPOMEMO(ByVal Fund As Integer, ByVal SFund As Integer, ByVal Line As Integer) As String
    Dim sb As StringBuilder = New StringBuilder

    If Fund = 0 Then Return ""

    myPOMEMO.GetOneRecordP(Fund, SFund, Line)
    If Not myPOMEMO.RecordNotFound Then
      With myPOMEMO
        sb.Append(._TEXT01 & vbCrLf)
        sb.Append(._TEXT02 & vbCrLf)
        sb.Append(._TEXT03 & vbCrLf)
        sb.Append(._TEXT04 & vbCrLf)
        sb.Append(._TEXT05 & vbCrLf)
        sb.Append(._TEXT06 & vbCrLf)
        sb.Append(._TEXT07 & vbCrLf)
        sb.Append(._TEXT08 & vbCrLf)
        sb.Append(._TEXT09 & vbCrLf)
        sb.Append(._TEXT10 & vbCrLf)
        sb.Append(._TEXT11 & vbCrLf)
        sb.Append(._TEXT12 & vbCrLf)
        sb.Append(._TEXT13 & vbCrLf)
        sb.Append(._TEXT14 & vbCrLf)
        sb.Append(._TEXT15 & vbCrLf)
      End With
    End If

    Return sb.ToString
  End Function
  Public Sub SetPrtFlag(ByVal dsSel As DataSet)

    Dim myPOMAST As POMAST.MyData
    Dim I As Integer
    myPOMAST = New POMAST.MyData()
    myPOMAST.MyDBConn = myDBConnect

    Windows.Forms.Cursor.Current = Cursors.WaitCursor()
    For I = 0 To (dsSel.Tables(0).Rows.Count - 1)
      With dsSel.Tables(0).Rows(I)
        If .Item("wsel") Then
          myPOMAST.GetOneRecordP(.Item("fscyr"), .Item("ponbr"), .Item("posuf"), 0, 0)
          myPOMAST._PRTFG = "Y"
          myPOMAST.UpdateOneRecordP()
        End If
      End With
    Next
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Private Function LookupAcct(ByVal AcctNo As String) As Integer
    Dim I As Integer

    For I = 0 To Acct.GetUpperBound(0)
      If Acct(I) & "" = "" Then
        Return I
      End If
      If AcctNo = Acct(I) Then
        Return I
      End If
    Next

  End Function
End Module
