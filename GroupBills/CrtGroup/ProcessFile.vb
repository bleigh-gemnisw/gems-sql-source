' 6/ 5/23 Last GroupID was double
Imports System.IO
Imports System.Text
Module ProcessFile

  Dim myFrmProgress As FrmProgress
  Dim myDBUtils As DBUtils
  Dim myDBUtils2 As DBUtils
  Dim WrkFile As String
  Dim WrkLastName As Boolean
  Dim WrkReduction As Boolean
  Dim WrkBankCount As Integer
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Public Sub ProcFile()
    With MyFrmMainB
      If MyAppSettings.IsRPM Then
        WrkFile = .LblName.Text
      Else
        WrkFile = .LblName.Text & "2"
      End If
      WrkLastName = .ChkLastName.Checked
      WrkReduction = .ChkReduction.Checked
    End With

    WrkBankCount = 0
    If WrkFile = String.Empty Then
      MsgBox("Unable to continue. Enter valid town number", MsgBoxStyle.Critical, "Missing file name")
      Exit Sub
    End If

    If WrkReduction Then
      ShowReduction()
      Exit Sub
    End If
    SetGroup1()
    SetGroup2()
    SetGroupID()
    ShowReduction()
  End Sub
  Private Sub SetGroup1()
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim Counter As Integer
    Dim WrkRecs As Integer
    Dim I As Integer
    Dim WrkName As String
    Dim WrkName2 As String
    Dim WrkLastName As String
    Dim WrkLastName2 As String
    Dim WrkAddr As String
    Dim WrkCompany As String
    Dim WrkCompanyName As String
    Dim WrkQry As String
    Dim SaveLastName As String
    Dim SaveAddr As String
    Dim WrkPctDone As Decimal

    myDBUtils = New DBUtils
    myDBUtils2 = New DBUtils

    SaveLastName = String.Empty
    SaveAddr = String.Empty
    WrkQry = "BKCD=''"
    'WrkQry = "Group1=" & Quo("23SURENLN")
    ds = myDBUtils.GetQry(WrkFile, "Addr", WrkQry, 0)
    WrkRecs = ds.Tables(0).Rows.Count

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Text = "Processing: Build Group 1"
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        WrkName = CalcName(.Item("name")) & ""
        WrkName2 = CalcName(.Item("name2")) & ""
        WrkCompanyName = String.Empty
        If WrkName2 <> String.Empty And WrkName <> WrkName2 Then
          WrkCompany = ChkCompany(WrkName & "-" & WrkName2)
        Else
          WrkCompany = ChkCompany(WrkName)
        End If
        If WrkCompany <> String.Empty Then
          WrkCompanyName = WrkName
          If WrkName2 <> String.Empty And WrkName <> WrkName2 Then
            If ChkCompany(WrkName2) <> String.Empty Or ChkCompName(WrkName2) <> String.Empty Then
              WrkCompanyName = Mid(WrkName & " " & WrkName2, 1, 50)
            End If
          End If
          If GetDBACompany(WrkName, WrkName2) <> String.Empty Then
            WrkCompanyName = GetDBACompany(WrkName, WrkName2)
          End If
        End If
        WrkLastName = CalcLastName(WrkName)
        WrkLastName2 = CalcLastName(WrkName2)
        WrkAddr = CalcAddr(.Item("addr") & "")
        WrkAddr = CalcPOBox(WrkAddr, .Item("town"))
        If WrkAddr = "" Then
          WrkAddr = CalcAddr(.Item("addr2"))
          WrkAddr = CalcPOBox(WrkAddr, .Item("town"))
        End If
        WrkQry = "TYPE=" & Quo(.Item("type")) & " And RECID=" & .Item("recid")
        ds2 = myDBUtils.GetQry(WrkFile, "", WrkQry, 0)
        ds2.Tables(0).Rows(0).Item("IsCompany") = WrkCompany
        If ds2.Tables(0).Rows(0).Item("IsCompany") = String.Empty Then
          If WrkLastName <> WrkLastName2 Then
            ds2.Tables(0).Rows(0).Item("group1") = WrkAddr & " " & WrkLastName & " " & WrkLastName2
          Else
            ds2.Tables(0).Rows(0).Item("group1") = WrkAddr & " " & WrkLastName
          End If
        Else
          ds2.Tables(0).Rows(0).Item("group1") = WrkAddr & ""
        End If
        If ds2.Tables(0).Rows(0).Item("group1") = "" Then
          ds2.Tables(0).Rows(0).Item("group1") = "."
        End If
        If WrkCompany <> String.Empty Then
          ds2.Tables(0).Rows(0).Item("companyname") = WrkCompanyName
          ds2.Tables(0).Rows(0).Item("lastname") = String.Empty
        Else
          ds2.Tables(0).Rows(0).Item("lastname") = WrkLastName
          ds2.Tables(0).Rows(0).Item("companyname") = String.Empty
        End If
        myDBUtils.UpdateOneRecordP(WrkFile, ds2)
        SaveLastName = WrkLastName
        SaveAddr = WrkAddr
      End With
      Counter = Counter + 1

NextRec:
      With myFrmProgress
        WrkPct = (Counter / 10) Mod 100
        If SavePct <> WrkPct Then
          WrkPctDone = Math.Round(Counter / WrkRecs, 3) * 100
          .ProgBar1.Value = WrkPct
          .LblMsg.Text = "Records processed: " & Counter & " (" & WrkPctDone & "%)"
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

End_of_file:
    myFrmProgress.Close()

  End Sub
  Private Sub SetGroup2()
    Dim ds As DataSet = New DataSet
    Dim dsGrp As DataSet = New DataSet
    Dim dsUpd As DataSet = New DataSet
    Dim Counter As Integer
    Dim I As Integer
    Dim J As Integer
    Dim WrkName As String
    Dim WrkFirstName As String
    Dim WrkFirstName2 As String
    Dim WrkChkName As String
    Dim WrkChkName2 As String
    Dim SaveGroup1 As String
    Dim WrkQry As String
    Dim WrkRecs As Integer
    Dim WrkPctDone As Decimal

    myDBUtils = New DBUtils
    myDBUtils2 = New DBUtils

    SaveGroup1 = String.Empty
    'WrkQry = "Group1=" & Quo("ATTNTAXDEPT")
    'ds = myDBUtils.GetQry(WrkFile, "Group1", WrkQry, 0)

    WrkQry = "BKCD=''"
    ds = myDBUtils.GetQry(WrkFile, "Group1", WrkQry, 0)
    WrkRecs = ds.Tables(0).Rows.Count

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Text = "Processing: Build Group 2"
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        If SaveGroup1 <> .Item("group1") & "" Then
          WrkFirstName = ""
          WrkFirstName2 = ""
          WrkQry = "GROUP1=" & Quo(.Item("group1") & "") & " and NAME2<>" & Quo(String.Empty)
          dsGrp = myDBUtils.GetQry(WrkFile, "", WrkQry, 0)
          If dsGrp.Tables(0).Rows.Count > 0 Then
            With dsGrp.Tables(0).Rows(0)
              WrkName = CalcName(.Item("name"))
              WrkFirstName = CalcFirstName(WrkName)
              WrkFirstName2 = CalcFirstName(.Item("name2"))
            End With
          End If

          WrkQry = "GROUP1=" & Quo(.Item("group1") & "")
          dsGrp = myDBUtils.GetQry(WrkFile, "", WrkQry, 0)
          For J = 0 To dsGrp.Tables(0).Rows.Count - 1
            dsUpd = myDBUtils.GetOneRecordP(WrkFile, dsGrp.Tables(0).Rows(J).Item("recid"), dsGrp.Tables(0).Rows(J).Item("type"))
            WrkName = CalcName(dsUpd.Tables(0).Rows(0).Item("name"))
            If dsUpd.Tables(0).Rows(0).Item("iscompany") = String.Empty Then
              WrkChkName = CalcFirstName(WrkName)
              WrkChkName2 = CalcFirstName(dsUpd.Tables(0).Rows(0).Item("name2"))
              dsUpd.Tables(0).Rows(0).Item("firstname") = WrkChkName
              dsUpd.Tables(0).Rows(0).Item("suffix") = GetSuffix(WrkName)
              If dsUpd.Tables(0).Rows(0).Item("firstname") = dsUpd.Tables(0).Rows(0).Item("suffix") Then
                WrkChkName = CalcThirdName(WrkName)
                dsUpd.Tables(0).Rows(0).Item("firstname") = WrkChkName
              End If
            Else
              WrkChkName = StripCompany(dsUpd.Tables(0).Rows(0).Item("companyname"))
              WrkChkName = StripCompName(WrkChkName)
              WrkChkName = Left(WrkChkName, 30)
              WrkChkName2 = String.Empty
              dsUpd.Tables(0).Rows(0).Item("firstname") = String.Empty
              dsUpd.Tables(0).Rows(0).Item("suffix") = String.Empty
            End If
            If WrkFirstName = String.Empty Then
              dsUpd.Tables(0).Rows(0).Item("group2") = WrkChkName
            Else
              If WrkChkName = WrkFirstName Or WrkChkName = WrkFirstName2 Or WrkChkName2 = WrkFirstName Or (WrkChkName2 = WrkFirstName2 And WrkChkName2 <> "") Then
                dsUpd.Tables(0).Rows(0).Item("group2") = Left(WrkFirstName & " " & WrkFirstName2, 30)
              Else
                dsUpd.Tables(0).Rows(0).Item("group2") = Left(WrkChkName & " " & WrkChkName2, 30)
              End If
            End If
            If WrkLastName And dsUpd.Tables(0).Rows(0).Item("iscompany") = String.Empty Then
              dsUpd.Tables(0).Rows(0).Item("group2") = "FAMILY"
            End If
            myDBUtils.UpdateOneRecordP(WrkFile, dsUpd)
          Next
        End If
        SaveGroup1 = .Item("group1") & ""
      End With
      Counter = Counter + 1

NextRec:
      With myFrmProgress
        WrkPct = (Counter / 10) Mod 100
        If SavePct <> WrkPct Then
          WrkPctDone = Math.Round(Counter / WrkRecs, 3) * 100
          .ProgBar1.Value = WrkPct
          .LblMsg.Text = "Records processed: " & Counter & " (" & WrkPctDone & "%)"
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

End_of_file:

    With ds.Tables(0).Rows(ds.Tables(0).Rows.Count - 1)
      WrkFirstName = ""
      WrkFirstName2 = ""
      WrkQry = "GROUP1=" & Quo(.Item("group1") & "") & " and NAME2<>" & Quo(String.Empty)
      dsGrp = myDBUtils.GetQry(WrkFile, "", WrkQry, 0)
      If dsGrp.Tables(0).Rows.Count > 0 Then
        With dsGrp.Tables(0).Rows(0)
          WrkName = CalcName(.Item("name"))
          WrkFirstName = CalcFirstName(WrkName)
          WrkFirstName2 = CalcFirstName(.Item("name2"))
        End With
      End If

      WrkQry = "GROUP1=" & Quo(.Item("group1") & "")
      dsGrp = myDBUtils.GetQry(WrkFile, "", WrkQry, 0)
      For J = 0 To dsGrp.Tables(0).Rows.Count - 1
        dsUpd = myDBUtils.GetOneRecordP(WrkFile, dsGrp.Tables(0).Rows(J).Item("recid"), dsGrp.Tables(0).Rows(J).Item("type"))
        WrkName = CalcName(dsUpd.Tables(0).Rows(0).Item("name"))
        If dsUpd.Tables(0).Rows(0).Item("iscompany") = String.Empty Then
          WrkChkName = CalcFirstName(WrkName)
          WrkChkName2 = CalcFirstName(dsUpd.Tables(0).Rows(0).Item("name2"))
          dsUpd.Tables(0).Rows(0).Item("firstname") = WrkChkName
          dsUpd.Tables(0).Rows(0).Item("suffix") = GetSuffix(WrkName)
          If dsUpd.Tables(0).Rows(0).Item("firstname") = dsUpd.Tables(0).Rows(0).Item("suffix") Then
            WrkChkName = CalcThirdName(WrkName)
            dsUpd.Tables(0).Rows(0).Item("firstname") = WrkChkName
          End If
        Else
          WrkChkName = StripCompany(dsUpd.Tables(0).Rows(0).Item("companyname"))
          WrkChkName = StripCompName(WrkChkName)
          WrkChkName = Left(WrkChkName, 30)
          WrkChkName2 = String.Empty
          dsUpd.Tables(0).Rows(0).Item("firstname") = String.Empty
          dsUpd.Tables(0).Rows(0).Item("suffix") = String.Empty
        End If
        If WrkFirstName = String.Empty Then
          dsUpd.Tables(0).Rows(0).Item("group2") = WrkChkName
        Else
          If WrkChkName = WrkFirstName Or WrkChkName = WrkFirstName2 Or WrkChkName2 = WrkFirstName Or (WrkChkName2 = WrkFirstName2 And WrkChkName2 <> "") Then
            dsUpd.Tables(0).Rows(0).Item("group2") = Left(WrkFirstName & " " & WrkFirstName2, 30)
          Else
            dsUpd.Tables(0).Rows(0).Item("group2") = Left(WrkChkName & " " & WrkChkName2, 30)
          End If
        End If
        If WrkLastName And dsUpd.Tables(0).Rows(0).Item("iscompany") = String.Empty Then
          dsUpd.Tables(0).Rows(0).Item("group2") = "FAMILY"
        End If
        myDBUtils.UpdateOneRecordP(WrkFile, dsUpd)
      Next
    End With
    myFrmProgress.Close()

  End Sub
  Private Sub SetGroupID()
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim Counter As Integer
    Dim CntPP As Integer
    Dim CntRE As Integer
    Dim CntMV As Integer
    Dim CntMS As Integer
    Dim I As Integer
    Dim J As Integer
    Dim SaveGroup1 As String
    Dim SaveGroup2 As String
    Dim SaveLen As Integer
    Dim SaveLenRow As Integer
    Dim WrkGroupID As String
    Dim WrkLen As Integer
    Dim WrkQry As String
    Dim WrkPostID As Integer
    Dim WrkRecs As Integer
    Dim WrkPctDone As Decimal

    myDBUtils = New DBUtils
    myDBUtils2 = New DBUtils

    SaveGroup1 = String.Empty
    SaveGroup2 = String.Empty
    WrkPostID = 1
    'WrkQry = "Group1=" & Quo("104SUMMITDR ANANIATIS")
    'ds = myDBUtils.GetQry(WrkFile, "Group1", WrkQry, 0)

    ds = myDBUtils.GetQry(WrkFile, "Group1, Group2, Type", "BKCD=''", 0)
    WrkRecs = ds.Tables(0).Rows.Count

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Text = "Processing: Build GroupID"
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        If SaveGroup1 <> .Item("group1") & "" Or SaveGroup2 <> .Item("group2") Then
          CntPP = 0
          CntRE = 0
          CntMS = 0
          CntMV = 0
          SaveLen = 0
          WrkQry = "GROUP1=" & Quo(.Item("group1") & "") & " and GROUP2=" & Quo(.Item("group2"))
          ds2 = myDBUtils.GetQry(WrkFile, "", WrkQry, 0)
          For J = 0 To ds2.Tables(0).Rows.Count - 1
            Select Case ds2.Tables(0).Rows(J).Item("type")
              Case "P"
                CntPP = CntPP + 1
              Case "R"
                CntRE = CntRE + 1
              Case "M"
                CntMV = CntMV + 1
              Case "S"
                CntMS = CntMS + 1
            End Select
            WrkLen = Len(ds2.Tables(0).Rows(J).Item("name")) + Len(ds2.Tables(0).Rows(J).Item("name2"))
            If WrkLen > SaveLen Then
              SaveLen = WrkLen
              SaveLenRow = J
            End If
          Next

          WrkGroupID = Format(CntRE + CntPP + CntMV + CntMS, "000")
          For J = 0 To ds2.Tables(0).Rows.Count - 1
            ds2.Tables(0).Rows(J).Item("postid") = 0
            ds2.Tables(0).Rows(J).Item("groupid") = WrkGroupID
            If J = SaveLenRow Then
              ds2.Tables(0).Rows(J).Item("postid") = WrkPostID
            End If
          Next
          myDBUtils.UpdateOneRecordP(WrkFile, ds2)
          WrkPostID = WrkPostID + 1
        End If
        SaveGroup1 = .Item("group1") & ""
        SaveGroup2 = .Item("group2")
      End With
      Counter = Counter + 1

NextRec:
      With myFrmProgress
        WrkPct = (Counter / 10) Mod 100
        If SavePct <> WrkPct Then
          WrkPctDone = Math.Round(Counter / WrkRecs, 3) * 100
          .ProgBar1.Value = WrkPct
          .LblMsg.Text = "Records processed: " & Counter & " (" & WrkPctDone & "%)"
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

End_of_file:

    'With ds.Tables(0).Rows(ds.Tables(0).Rows.Count - 1)
    '  WrkQry = "GROUP1=" & Quo(.Item("group1") & "") & " and GROUP2=" & Quo(.Item("group2"))
    '  ds2 = myDBUtils.GetQry(WrkFile, "", WrkQry, 0)
    '  For J = 0 To ds2.Tables(0).Rows.Count - 1
    '    Select Case ds2.Tables(0).Rows(J).Item("type")
    '      Case "P"
    '        CntPP = CntPP + 1
    '      Case "R"
    '        CntRE = CntRE + 1
    '      Case "M"
    '        CntMV = CntMV + 1
    '      Case "S"
    '        CntMS = CntMS + 1
    '    End Select
    '    WrkLen = Len(ds2.Tables(0).Rows(J).Item("name")) + Len(ds2.Tables(0).Rows(J).Item("name2"))
    '    If WrkLen > SaveLen Then
    '      SaveLen = WrkLen
    '      SaveLenRow = J
    '    End If
    '  Next

    '  WrkGroupID = Format(CntRE + CntPP + CntMV + CntMS, "000")
    '  For J = 0 To ds2.Tables(0).Rows.Count - 1
    '    ds2.Tables(0).Rows(J).Item("postid") = 0
    '    ds2.Tables(0).Rows(J).Item("groupid") = WrkGroupID
    '    If J = SaveLenRow Then
    '      ds2.Tables(0).Rows(J).Item("postid") = WrkPostID
    '    End If
    '  Next
    '  myDBUtils.UpdateOneRecordP(WrkFile, ds2)
    'End With
    myFrmProgress.Close()
    Application.DoEvents()
    SetBankPostID(WrkPostID)

  End Sub
  Private Sub SetBankPostID(WrkLastPostID As Integer)
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim Counter As Integer
    Dim I As Integer
    Dim WrkPostID As Integer
    Dim WrkRecs As Integer
    Dim WrkPctDone As Decimal

    myDBUtils = New DBUtils
    myDBUtils2 = New DBUtils

    WrkPostID = WrkLastPostID + 1
    Counter = 0
    ds = myDBUtils.GetQry(WrkFile, "Bkcd, Name", "BKCD<>''", 0)
    WrkRecs = ds.Tables(0).Rows.Count

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Text = "Processing: Build Bank PostID"
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        .Item("postid") = WrkPostID
        .Item("postsort") = WrkPostID
        WrkBankCount = WrkBankCount + 1
        WrkPostID = WrkPostID + 1
      End With
      Counter = Counter + 1

NextRec:
      With myFrmProgress
        WrkPct = (Counter / 10) Mod 100
        If SavePct <> WrkPct Then
          WrkPctDone = Math.Round(Counter / WrkRecs, 3) * 100
          .ProgBar1.Value = WrkPct
          .LblMsg.Text = "Records processed: " & Counter & " (" & WrkPctDone & "%)"
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

End_of_file:
    myDBUtils.UpdateOneRecordP(WrkFile, ds)
    myFrmProgress.Close()
    Application.DoEvents()

  End Sub
  Private Function ChkCompany(ByVal WrkName As String) As String

    Dim ds2 As DataSet = New DataSet
    Dim I As Integer
    Dim Pos As Integer
    Dim WrkStr As String
    Dim WrkStrLen As Integer
    Dim WrkCompany As String

    WrkCompany = String.Empty
    ds2 = myDBUtils2.GetQry("Company", "", "", 0)
    WrkName = Trim(WrkName)

ReadNext:
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        WrkStr = " " & .Item("comptext")
        WrkStrLen = Len(WrkStr)
        Pos = InStr(WrkName, WrkStr, CompareMethod.Text)
        If Pos > 0 Then
          If Pos + WrkStrLen = Len(WrkName) + 1 Then
            WrkCompany = "C-" & .Item("comptext")
            Exit For
          End If
        End If

        WrkStr = " " & .Item("comptext") & " "
        Pos = InStr(WrkName, WrkStr, CompareMethod.Text)
        If Pos > 0 Then
          WrkCompany = "C-" & .Item("comptext")
          Exit For
        End If

        WrkStr = " " & .Item("comptext") & "-"
        Pos = InStr(WrkName, WrkStr, CompareMethod.Text)
        If Pos > 0 Then
          WrkCompany = "C-" & .Item("comptext")
          Exit For
        End If

        WrkStr = "-" & .Item("comptext")
        Pos = InStr(WrkName, WrkStr, CompareMethod.Text)
        WrkStrLen = Len(WrkStr)
        If Pos > 0 Then
          If Pos + WrkStrLen = Len(WrkName) + 1 Then
            WrkCompany = "C-" & .Item("comptext")
            Exit For
          End If
        End If

        WrkStr = .Item("comptext")
        If UCase(WrkStr) = WrkName Then
          WrkCompany = "C-" & .Item("comptext")
          Exit For
        End If
      End With
    Next

    Return WrkCompany

  End Function
  Private Function ChkCompName(ByVal WrkName As String) As String

    Dim ds2 As DataSet = New DataSet
    Dim I As Integer
    Dim Pos As Integer
    Dim WrkStr As String
    Dim WrkStrLen As Integer
    Dim WrkCompany As String

    WrkCompany = String.Empty
    ds2 = myDBUtils2.GetQry("Compname", "", "", 0)
    WrkName = Trim(WrkName)

ReadNext:
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        WrkStr = " " & .Item("comptext")
        WrkStrLen = Len(WrkStr)
        Pos = InStr(WrkName, WrkStr, CompareMethod.Text)
        If Pos > 0 Then
          If Pos + WrkStrLen = Len(WrkName) + 1 Then
            WrkCompany = "N-" & .Item("comptext")
            Exit For
          End If
        End If

        WrkStr = " " & .Item("comptext") & " "
        Pos = InStr(WrkName, WrkStr, CompareMethod.Text)
        If Pos > 0 Then
          WrkCompany = "N-" & .Item("comptext")
          Exit For
        End If

        WrkStr = " " & .Item("comptext") & "-"
        Pos = InStr(WrkName, WrkStr, CompareMethod.Text)
        If Pos > 0 Then
          WrkCompany = "N-" & .Item("comptext")
          Exit For
        End If

        WrkStr = "-" & .Item("comptext")
        Pos = InStr(WrkName, WrkStr, CompareMethod.Text)
        WrkStrLen = Len(WrkStr)
        If Pos > 0 Then
          If Pos + WrkStrLen = Len(WrkName) + 1 Then
            WrkCompany = "N-" & .Item("comptext")
            Exit For
          End If
        End If

        WrkStr = .Item("comptext")
        If UCase(WrkStr) = WrkName Then
          WrkCompany = "N-" & .Item("comptext")
          Exit For
        End If
      End With
    Next

    Return WrkCompany

  End Function
  Private Function GetDBACompany(ByVal WrkName As String, ByVal WrkName2 As String) As String

    Dim Pos As Integer
    Dim WrkStr As String
    Dim WrkFullName As String
    Dim WrkCompany As String

    WrkCompany = String.Empty
    WrkFullName = WrkName & " " & WrkName2
    WrkStr = "dba"
    Pos = InStr(WrkFullName, WrkStr, CompareMethod.Text)
    If Pos > 0 Then
      WrkCompany = Mid(WrkFullName, Pos + 4)
    End If

    Return WrkCompany

  End Function
  Private Function StripCompany(ByVal WrkName As String) As String

    Dim ds2 As DataSet = New DataSet
    Dim I As Integer
    Dim Pos As Integer
    Dim WrkStr As String
    Dim WrkStrLen As Integer
    Dim WrkCompany As String

    WrkCompany = Trim(WrkName)
    ds2 = myDBUtils2.GetQry("Company", "", "", 0)

ReadNext:
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        WrkStr = " " & UCase(.Item("comptext"))
        WrkStrLen = Len(WrkStr)
        Pos = InStr(WrkName, WrkStr, CompareMethod.Text)
        If Pos > 0 Then
          If Pos + WrkStrLen = Len(WrkName) + 1 Then
            WrkCompany = Replace(WrkCompany, WrkStr, " ")
          End If
        End If

        WrkStr = " " & UCase(.Item("comptext")) & " "
        Pos = InStr(WrkName, WrkStr, CompareMethod.Text)
        If Pos > 0 Then
          WrkCompany = Replace(WrkCompany, WrkStr, " ")
        End If

        WrkStr = " " & UCase(.Item("comptext")) & "-"
        Pos = InStr(WrkName, WrkStr, CompareMethod.Text)
        If Pos > 0 Then
          WrkCompany = Replace(WrkCompany, WrkStr, " ")
        End If

        WrkStr = "-" & UCase(.Item("comptext"))
        Pos = InStr(WrkName, WrkStr, CompareMethod.Text)
        WrkStrLen = Len(WrkStr)
        If Pos > 0 Then
          If Pos + WrkStrLen = Len(WrkName) + 1 Then
            WrkCompany = Replace(WrkCompany, WrkStr, " ")
          End If
        End If

        WrkStr = UCase(.Item("comptext"))
        If WrkStr = WrkName Then
          WrkCompany = Replace(WrkCompany, WrkStr, "")
        End If
      End With
    Next

    Return WrkCompany

  End Function
  Private Function StripCompName(ByVal WrkName As String) As String

    Dim ds2 As DataSet = New DataSet
    Dim I As Integer
    Dim Pos As Integer
    Dim WrkStr As String
    Dim WrkStrLen As Integer
    Dim WrkCompany As String

    WrkCompany = Trim(WrkName)
    ds2 = myDBUtils2.GetQry("Compname", "", "", 0)

ReadNext:
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        WrkStr = " " & UCase(.Item("comptext"))
        WrkStrLen = Len(WrkStr)
        Pos = InStr(WrkName, WrkStr, CompareMethod.Text)
        If Pos > 0 Then
          If Pos + WrkStrLen = Len(WrkName) + 1 Then
            WrkCompany = Replace(WrkCompany, WrkStr, " ")
          End If
        End If

        WrkStr = " " & UCase(.Item("comptext")) & " "
        Pos = InStr(WrkName, WrkStr, CompareMethod.Text)
        If Pos > 0 Then
          WrkCompany = Replace(WrkCompany, WrkStr, " ")
        End If

        WrkStr = " " & UCase(.Item("comptext")) & "-"
        Pos = InStr(WrkName, WrkStr, CompareMethod.Text)
        If Pos > 0 Then
          WrkCompany = Replace(WrkCompany, WrkStr, " ")
        End If

        WrkStr = "-" & UCase(.Item("comptext"))
        Pos = InStr(WrkName, WrkStr, CompareMethod.Text)
        WrkStrLen = Len(WrkStr)
        If Pos > 0 Then
          If Pos + WrkStrLen = Len(WrkName) + 1 Then
            WrkCompany = Replace(WrkCompany, WrkStr, " ")
          End If
        End If

        WrkStr = UCase(.Item("comptext"))
        If WrkStr = WrkName Then
          WrkCompany = Replace(WrkCompany, WrkStr, "")
        End If
      End With
    Next

    WrkCompany = Replace(WrkCompany, " AND", " ")
    WrkCompany = Replace(WrkCompany, " &", " ")
    WrkCompany = Replace(WrkCompany, " OR", " ")
    WrkCompany = Replace(WrkCompany, "THE ", " ")
    WrkCompany = Replace(WrkCompany, " THE ", " ")
    Return WrkCompany

  End Function
  Private Function GetSuffix(ByVal WrkName As String) As String

    Dim ds3 As DataSet = New DataSet
    Dim I As Integer
    Dim Pos As Integer
    Dim WrkStr As String
    Dim WrkSuffix As String

    WrkSuffix = String.Empty
    ds3 = myDBUtils2.GetQry("Suffix", "", "", 0)

ReadNext:
    For I = 0 To ds3.Tables(0).Rows.Count - 1
      With ds3.Tables(0).Rows(I)
        WrkStr = " " & .Item("sufftext")
        Pos = InStr(WrkName, WrkStr, CompareMethod.Text)
        If Pos > 0 Then
          WrkSuffix = .Item("sufftext")
          Exit For
        End If
      End With
    Next

    Return WrkSuffix

  End Function
  Private Function CalcLastName(ByVal pName As String) As String

    Dim WrkName As String
    Dim Pos As Integer

    pName = Replace(pName, Chr(34), "")
    pName = Replace(pName, "'", "")
    WrkName = pName
    If WrkName <> String.Empty Then
      Pos = InStr(WrkName, " ")
      If Pos > 0 Then
        WrkName = Mid(WrkName, 1, Pos - 1)
      End If
    End If

    Return WrkName
  End Function
  Private Function CalcFirstName(ByVal pName As String) As String

    Dim WrkLastName As String
    Dim WrkFirstName As String
    Dim Pos1 As Integer
    Dim Pos2 As Integer

    WrkFirstName = ""
    If pName = String.Empty Then Return ""

    pName = Replace(pName, Chr(34), "")
    pName = Replace(pName, "'", "")
    Pos1 = InStr(pName, " ")
    If Pos1 > 0 Then
      WrkLastName = Mid(pName, 1, Pos1 - 1)
    End If
    Pos2 = InStr(Pos1 + 1, pName, " ")
    If Pos2 > 0 Then
      WrkFirstName = Mid(pName, Pos1 + 1, Pos2 - Pos1 - 1)
    Else
      WrkFirstName = Mid(pName, Pos1 + 1)
    End If

    Return WrkFirstName
  End Function
  Private Function CalcThirdName(ByVal pName As String) As String

    Dim WrkLastName As String
    Dim WrkFirstName As String
    Dim WrkThirdName As String
    Dim Pos1 As Integer
    Dim Pos2 As Integer
    Dim Pos3 As Integer

    WrkFirstName = ""
    WrkThirdName = ""
    If pName = String.Empty Then Return ""

    pName = Replace(pName, Chr(34), "")
    pName = Replace(pName, "'", "")
    Pos1 = InStr(pName, " ")
    If Pos1 > 0 Then
      WrkLastName = Mid(pName, 1, Pos1 - 1)
    End If
    Pos2 = InStr(Pos1 + 1, pName, " ")
    If Pos2 > 0 Then
      WrkFirstName = Mid(pName, Pos1 + 1, Pos2 - Pos1 - 1)
    Else
      WrkFirstName = Mid(pName, Pos1 + 1)
    End If
    Pos3 = InStr(Pos2 + 1, pName, " ")
    If Pos3 > 0 Then
      WrkThirdName = Mid(pName, Pos2 + 1, Pos3 - Pos2 - 1)
    Else
      WrkThirdName = Mid(pName, Pos2 + 1)
    End If

    Return WrkThirdName
  End Function
  Private Function CalcName(ByVal pName As String) As String

    Dim WrkName As String

    WrkName = pName
    WrkName = Replace(WrkName, "  ", " ")
    WrkName = Replace(WrkName, ".", "")
    WrkName = Replace(WrkName, "'", "")
    WrkName = Replace(WrkName, "&", "")
    WrkName = Replace(WrkName, "%", "")
    WrkName = Replace(WrkName, ",", "")
    WrkName = Replace(WrkName, "-", "")
    WrkName = Replace(WrkName, "*", "")
    WrkName = Replace(WrkName, "C/O ", "")
    WrkName = Replace(WrkName, "(", "")
    WrkName = Replace(WrkName, ")", "")

    Return WrkName
  End Function
  Private Function CalcAddr(ByVal pAddress As String) As String

    Dim WrkAddress As String

    WrkAddress = pAddress
    WrkAddress = Replace(WrkAddress, "'", "")
    WrkAddress = Replace(WrkAddress, "/", "")
    WrkAddress = Replace(WrkAddress, "#", "")
    WrkAddress = Replace(WrkAddress, " AVENUE", " AVE")
    WrkAddress = Replace(WrkAddress, " AVENU", " AVE")
    WrkAddress = Replace(WrkAddress, " AV", " AVE")
    WrkAddress = Replace(WrkAddress, " AVEE", " AVE")
    WrkAddress = Replace(WrkAddress, " CIRCLE", " CIR")
    WrkAddress = Replace(WrkAddress, " COURT", " CT")
    WrkAddress = Replace(WrkAddress, " DRIVE", " DR")
    WrkAddress = Replace(WrkAddress, " HEIGHTS", " HTS")
    WrkAddress = Replace(WrkAddress, " HGTS", " HTS")
    WrkAddress = Replace(WrkAddress, " HT", " HTS")
    WrkAddress = Replace(WrkAddress, " HTSS", " HTS")
    WrkAddress = Replace(WrkAddress, " LANE", " LN")
    WrkAddress = Replace(WrkAddress, " LA", " LN")
    WrkAddress = Replace(WrkAddress, " PARKWAY", " PKY")
    WrkAddress = Replace(WrkAddress, " PLACE", " PL")
    WrkAddress = Replace(WrkAddress, " ROAD", " RD")
    WrkAddress = Replace(WrkAddress, " RIDGE", " RDG")
    WrkAddress = Replace(WrkAddress, " STREET", " ST")
    WrkAddress = Replace(WrkAddress, " TERRACE", " TER")
    WrkAddress = Replace(WrkAddress, " TERR", " TER")
    WrkAddress = Replace(WrkAddress, " ", "")
    WrkAddress = Replace(WrkAddress, ".", "")

    Return WrkAddress
  End Function
  Private Function CalcPOBox(ByVal pAddress As String, ByVal pCity As String) As String

    Dim WrkAddress As String

    WrkAddress = pAddress
    WrkAddress = Replace(WrkAddress, "BOX ", "")
    WrkAddress = Replace(WrkAddress, "PO ", "")
    WrkAddress = Replace(WrkAddress, "POB ", "")
    WrkAddress = Replace(WrkAddress, "POBOX", "")
    WrkAddress = Replace(WrkAddress, "POBOXS", "")

    If WrkAddress <> pAddress Then
      WrkAddress = WrkAddress & " " & pCity
    End If

    Return WrkAddress
  End Function
  Private Sub ShowReduction()
    Dim sb As StringBuilder = New StringBuilder
    Dim sb2 As StringBuilder = New StringBuilder
    Dim ds As DataSet = New DataSet
    Dim WrkQry As String
    Dim wrkAccts As Integer
    Dim WrkBills As Integer
    Dim WrkReduction As Decimal
    Dim I As Integer
    Dim WrkGroupID As Integer
    Dim WrkEnvelopes As Integer

    myDBUtils = New DBUtils

    wrkAccts = 0
    WrkQry = "Type='R'"
    ds = myDBUtils.GetQry(WrkFile, "", WrkQry, 0)
    sb.Append("RE " & ds.Tables(0).Rows.Count & vbCrLf)
    wrkAccts = wrkAccts + ds.Tables(0).Rows.Count

    WrkQry = "Type='P'"
    ds = myDBUtils.GetQry(WrkFile, "", WrkQry, 0)
    sb.Append("PP " & ds.Tables(0).Rows.Count & vbCrLf)
    wrkAccts = wrkAccts + ds.Tables(0).Rows.Count

    WrkQry = "Type='M'"
    ds = myDBUtils.GetQry(WrkFile, "", WrkQry, 0)
    sb.Append("MV " & ds.Tables(0).Rows.Count & vbCrLf)
    wrkAccts = wrkAccts + ds.Tables(0).Rows.Count

    WrkQry = "Type='S'"
    ds = myDBUtils.GetQry(WrkFile, "", WrkQry, 0)
    sb.Append("MS " & ds.Tables(0).Rows.Count & vbCrLf)
    wrkAccts = wrkAccts + ds.Tables(0).Rows.Count

    sb.Append("ACCTS " & wrkAccts & vbCrLf)
    sb.Append("")
    WrkQry = "POSTID > 0"
    ds = myDBUtils.GetQry(WrkFile, "", WrkQry, 0)
    WrkBills = ds.Tables(0).Rows.Count
    sb.Append("BILLS " & WrkBills & vbCrLf)
    sb.Append("")
    sb.Append("BANKS " & WrkBankCount & vbCrLf)
    sb.Append("")
    WrkReduction = (1 - (WrkBills / wrkAccts)) * 100
    sb.Append("REDUCTION " & Format(WrkReduction, "fixed") & vbCrLf)

    sb2.Append("Group, Count, Envelopes" & vbCrLf)
    ds = myDBUtils.GetGroupCounts(WrkFile)
    For I = 0 To ds.Tables(0).Rows.Count - 1
      WrkGroupID = CnvSng(ds.Tables(0).Rows(I).Item("groupid"))
      If ds.Tables(0).Rows(I).Item("groupid") <> "" Then
        WrkEnvelopes = ds.Tables(0).Rows(I).Item("count") / WrkGroupID
      Else
        WrkEnvelopes = 0
      End If
      sb2.Append(WrkGroupID & "," & ds.Tables(0).Rows(I).Item("count") & "," & WrkEnvelopes & vbCrLf)
    Next

    FrmMsg.WrkMsg = sb.ToString
    FrmMsg.WrkMsg2 = sb2.ToString
    FrmMsg.Show()
    'MsgBox(sb.ToString, MsgBoxStyle.Information, WrkFile)
  End Sub
End Module
