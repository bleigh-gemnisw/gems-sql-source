Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXM59AQ As TXM59AQ.MyData

Dim ds As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim ds3 As DataSet = New DataSet
Dim ds4 As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkGLYear As Integer
Dim WrkForms As Boolean
Dim WrkPrtAllow As Boolean
Dim WrkPgm As String
 Public Sub PrtReport()

 myTXM59AQ = New TXM59AQ.mydata(MyDBConnect)

 With MyFrmTO208B
    WrkGLYear = MyUtils.CnvSng(.TxtEldLYear.Text)
    WrkForms = .ChkForms.Checked
    WrkPrtAllow = .ChkPrtAllow.Checked
    WrkPgm = "State"
 End With

 If ds.Tables.Count = 0 Then
  BuildDS()
  BuildDS2()
  ds3 = ds2.Clone
  ds4 = ds2.Clone
 Else
  ds.Clear()
  ds2.Clear()
  ds3.Clear()
  ds4.Clear()
 End If

 GetDetail()

 MyCrViewer = New FrmCrViewer
 MyCrViewer.wrkds = ds
 MyCrViewer.wrkds2 = ds2
 MyCrViewer.wrkds3 = ds3
 MyCrViewer.wrkds4 = ds4
 MyCrViewer.Show()

 End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("ALName", Type.GetType("System.String"))
      .Columns.Add("AFName", Type.GetType("System.String"))
      .Columns.Add("AInit", Type.GetType("System.String"))
      .Columns.Add("ASSN", Type.GetType("System.String"))
      .Columns.Add("SLName", Type.GetType("System.String"))
      .Columns.Add("SFName", Type.GetType("System.String"))
      .Columns.Add("SInit", Type.GetType("System.String"))
      .Columns.Add("SSSN", Type.GetType("System.String"))
      .Columns.Add("PROPLOC", Type.GetType("System.String"))
      .Columns.Add("CITY", Type.GetType("System.String"))
      .Columns.Add("STATE", Type.GetType("System.String"))
      .Columns.Add("ZIP", Type.GetType("System.String"))
      .Columns.Add("MADDR", Type.GetType("System.String"))
      .Columns.Add("MCITY", Type.GetType("System.String"))
      .Columns.Add("MSTATE", Type.GetType("System.String"))
      .Columns.Add("MZIP", Type.GetType("System.String"))
      .Columns.Add("PHONE", Type.GetType("System.String"))
      .Columns.Add("MARRIED", Type.GetType("System.String"))
      .Columns.Add("SINGLE", Type.GetType("System.String"))
      .Columns.Add("DIVORCED", Type.GetType("System.String"))
      .Columns.Add("WIDOW", Type.GetType("System.String"))
      .Columns.Add("LEGALLY", Type.GetType("System.String"))
      .Columns.Add("INCOME", Type.GetType("System.Decimal"))
      .Columns.Add("INTEREST", Type.GetType("System.Decimal"))
      .Columns.Add("SSRR", Type.GetType("System.Decimal"))
      .Columns.Add("OTHER", Type.GetType("System.Decimal"))
      .Columns.Add("TOTAL", Type.GetType("System.Decimal"))
      .Columns.Add("DISRATINGYES", Type.GetType("System.String"))
      .Columns.Add("DISRATINGNO", Type.GetType("System.String"))
      .Columns.Add("SIGNEDMO", Type.GetType("System.String"))
      .Columns.Add("SIGNEDDAY", Type.GetType("System.String"))
      .Columns.Add("SIGNEDYEAR", Type.GetType("System.String"))
      .Columns.Add("XVET", Type.GetType("System.Int32"))
      .Columns.Add("DISINCOMEYES", Type.GetType("System.String"))
      .Columns.Add("DISINCOMENO", Type.GetType("System.String"))
      .Columns.Add("QUALIFYING", Type.GetType("System.Decimal"))
      .Columns.Add("XADDL", Type.GetType("System.Int32"))
      .Columns.Add("XFULL", Type.GetType("System.Int32"))
      .Columns.Add("XLOCAL", Type.GetType("System.Int32"))
      .Columns.Add("XFULLO", Type.GetType("System.Int32"))
      .Columns.Add("RE", Type.GetType("System.String"))
      .Columns.Add("MV", Type.GetType("System.String"))
      .Columns.Add("PP", Type.GetType("System.String"))
      .Columns.Add("SU", Type.GetType("System.String"))
      .Columns.Add("RELIST", Type.GetType("System.String"))
      .Columns.Add("MVLIST", Type.GetType("System.String"))
      .Columns.Add("PPLIST", Type.GetType("System.String"))
      .Columns.Add("SULIST", Type.GetType("System.String"))
      .Columns.Add("ALLOWED", Type.GetType("System.String"))
      .Columns.Add("DISALLOWED", Type.GetType("System.String"))
      .Columns.Add("DISRSN", Type.GetType("System.String"))
      .Columns.Add("ASSRMO", Type.GetType("System.String"))
      .Columns.Add("ASSRDAY", Type.GetType("System.String"))
      .Columns.Add("ASSRYEAR", Type.GetType("System.String"))
    End With
    Ds.Tables.Add(myTable)
  End Sub
 Private Sub BuildDS2()
  Dim myTable As New DataTable
  With myTable
   .TableName = "mytable2"
   .Columns.Add("ListNo", Type.GetType("System.Int32"))
   .Columns.Add("Year", Type.GetType("System.Int32"))
   .Columns.Add("ALName", Type.GetType("System.String"))
   .Columns.Add("AFName", Type.GetType("System.String"))
   .Columns.Add("AInit", Type.GetType("System.String"))
   .Columns.Add("TOTAL", Type.GetType("System.Decimal"))
   .Columns.Add("Reason", Type.GetType("System.String"))
   .Columns.Add("Benefit", Type.GetType("System.Int32"))
  End With
  ds2.Tables.Add(myTable)
 End Sub
Private Sub GetDetail()
Dim WrkQry As String
Dim WrkSort As String
Dim WrkAnd As String
Dim WrkTotCredit As Decimal
Dim SaveList As Integer
Dim Counter As Integer

If myDBConnect.ServerAS400 Then
 WrkAnd = " *and "
Else
 WrkAnd = " and "
 End If

Counter = 0
WrkSort = "LIST#"
WrkQry = "YEAR = " & WrkGLYear
'WrkQry = WrkQry & WrkAnd & "LIST# =163575"
SaveList = 0
WrkTotCredit = 0
myTXM59AQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
 myTXM59AQ.ReadQry()
 If Not myTXM59AQ.IsEOF Then
  With myTXM59AQ
   Counter = Counter + 1
   If Trim(._ALLOW) <> String.Empty Then
     If Trim(._ALLOW) = "Y" Then
       'WrkTotCredit = WrkTotCredit + WrkCredit
     End If
     SaveList = ._LISTNO
   End If
   If WrkPrtAllow Then
     If Trim(._ALLOW) = "Y" Then
       Writeds(WrkPgm)
     End If
   Else
     If Trim(._ALLOW) <> String.Empty Then
       Writeds(WrkPgm)
     End If
   End If
   If Trim(._ALLOW) = "N" Then
     Writeds2()
   End If
   If Trim(._ALLOW) = String.Empty Then
     Writeds3()
   End If
   If Trim(._ALLOW) = "Y" Then
     Writeds4()
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
myTXM59AQ.CloseFile()
MyFrmTO208B.TxtEldLYear.Text = ""
End Sub
  Private Sub Writeds(ByVal WrkPgm As String)
    Dim dr As Data.DataRow
    Dim WrkDate As Date

    With myTXM59AQ
      dr = ds.Tables(0).NewRow
      dr.Item("year") = ._YEAR
      dr.Item("listno") = ._LISTNO
      dr.Item("alname") = Trim(._ALNAME)
      dr.Item("afname") = Trim(._AFNAME)
      dr.Item("ainit") = Trim(._AINIT)
      dr.Item("assn") = Format(._ASSN, "000-00-0000")
      dr.Item("slname") = Trim(._SLNAME)
      dr.Item("sfname") = Trim(._SFNAME)
      dr.Item("sinit") = Trim(._SINIT)
      If Trim(._SLNAME) <> "" Then
        dr.Item("sssn") = Format(._SSSN, "000-00-0000")
      End If
      dr.Item("proploc") = Trim(._LOCNO) & " " & ._LOC
      dr.Item("city") = ._CITY
      dr.Item("state") = ._STATE
      If ._ZIP > 0 Then
        dr.Item("zip") = Format(MyUtils.CnvSng(._ZIP), "00000")
      End If
      dr.Item("maddr") = ._MADDR
      dr.Item("mcity") = ._MCITY
      dr.Item("mstate") = ._MSTATE
      If ._MZIP > 0 Then
        dr.Item("mzip") = Format(MyUtils.CnvSng(._MZIP), "00000")
      End If
      If ._FILING = "M" Then
        dr.Item("married") = "X"
      End If
      If ._FILING = "U" Or ._FILING = "S" Then
        dr.Item("single") = "X"
      End If
      If ._FILING = "D" Then
        dr.Item("divorced") = "X"
      End If
      If ._FILING = "W" Then
        dr.Item("widow") = "X"
      End If
      If ._FILING = "L" Then
        dr.Item("legally") = "X"
      End If
      If ._RATING = "Y" Then
        dr.Item("disratingyes") = "X"
      Else
        dr.Item("disratingno") = "X"
      End If
      dr.Item("income") = ._INCOME
      dr.Item("interest") = ._INT
      dr.Item("ssrr") = ._SSRR
      dr.Item("other") = ._OTHER
      dr.Item("total") = ._INCOME + ._INT + ._SSRR + ._OTHER
      WrkDate = MyUtils.GetDBDate(._DTSIGN)
      dr.Item("signedmo") = Format(WrkDate.Month, "00")
      dr.Item("signedday") = Format(WrkDate.Day, "00")
      dr.Item("signedyear") = WrkDate.Year
      If ._PHONE > 0 Then
        dr.Item("phone") = Format(._PHONE, "(###) ###-0000")
      End If
      Select Case WrkPgm
        Case "State"
          dr.Item("xvet") = ._XVET
          dr.Item("xaddl") = ._XADDL
          dr.Item("xfull") = ._XFULL
          dr.Item("xlocal") = ._XLOCAL
          dr.Item("xfullo") = ._XFULLO
          Select Case ._TYPE
            Case "R"
              dr.Item("re") = "X"
              dr.Item("relist") = ._LISTNO
            Case "P"
              dr.Item("pp") = "X"
              dr.Item("pplist") = ._LISTNO
            Case "M"
              dr.Item("mv") = "X"
              dr.Item("mvlist") = ._LISTNO
            Case "S"
              dr.Item("su") = "X"
              dr.Item("sulist") = ._LISTNO
          End Select
          If ._ALLOW = "Y" Then
            dr.Item("allowed") = "X"
          Else
            dr.Item("disallowed") = "X"
          End If
          dr.Item("disrsn") = ._DISRSN
          If ._DTASSR > 0 Then
            WrkDate = MyUtils.GetDBDate(._DTASSR)
            dr.Item("assrmo") = Format(WrkDate.Month, "00")
            dr.Item("assrday") = Format(WrkDate.Day, "00")
            dr.Item("assryear") = WrkDate.Year
          End If
          'Case "Local"
          '  If .RbLocAllowed.Checked Then
          '    dr.Item("allowed") = "X"
          '  End If
          '  If .RbLocDisallowed.Checked Then
          '    dr.Item("disallowed") = "X"
          '  End If
          '  dr.Item("disrsn") = .TxtLocDisallowReason.Text
          '  If .DtPckLocAssr.Checked Then
          '    dr.Item("assrmo") = Format(.DtPckLocAssr.Value.Month, "00")
          '    dr.Item("assrday") = Format(.DtPckLocAssr.Value.Day, "00")
          '    dr.Item("assryear") = .DtPckLocAssr.Value.Year
          '  End If
          'Case "EBC"
          '  If .RbEBCAllowed.Checked Then
          '    dr.Item("allowed") = "X"
          '  End If
          '  If .RbEBCDisallowed.Checked Then
          '    dr.Item("disallowed") = "X"
          '  End If
          '  dr.Item("disrsn") = .TxtEBCDisallowReason.Text
          '  If .DtPckEBCAssr.Checked Then
          '    dr.Item("assrmo") = Format(.DtPckEBCAssr.Value.Month, "00")
          '    dr.Item("assrday") = Format(.DtPckEBCAssr.Value.Day, "00")
          '    dr.Item("assryear") = .DtPckEBCAssr.Value.Year
          '  End If
          'Case "FBC"
          '  If .RbFBCAllowed.Checked Then
          '    dr.Item("allowed") = "X"
          '  End If
          '  If .RbFBCDisallowed.Checked Then
          '    dr.Item("disallowed") = "X"
          '  End If
          '  dr.Item("disrsn") = .TxtFBCDisallowReason.Text
          '  If .DtPckFBCAssr.Checked Then
          '    dr.Item("assrmo") = Format(.DtPckFBCAssr.Value.Month, "00")
          '    dr.Item("assrday") = Format(.DtPckFBCAssr.Value.Day, "00")
          '    dr.Item("assryear") = .DtPckFBCAssr.Value.Year
          '  End If
      End Select
      ds.Tables(0).Rows.Add(dr)
    End With
  End Sub
  Private Sub Writeds2()
  With myTXM59AQ
    dr = ds2.Tables(0).NewRow
    dr.Item("listno") = ._LISTNO
    dr.Item("year") = ._YEAR
    dr.Item("alname") = ._ALNAME
    dr.Item("afname") = ._AFNAME
    dr.Item("ainit") = ._AINIT
    dr.Item("total") = ._INCOME + ._INT + ._SSRR + ._OTHER
    dr.Item("reason") = ._DISRSN
    dr.Item("benefit") = 0
    ds2.Tables(0).Rows.Add(dr)
  End With
End Sub
Private Sub Writeds3()
  With myTXM59AQ
    dr = ds3.Tables(0).NewRow
    dr.Item("listno") = ._LISTNO
    dr.Item("year") = ._YEAR
    dr.Item("alname") = ._ALNAME
    dr.Item("afname") = ._AFNAME
    dr.Item("ainit") = ._AINIT
    dr.Item("total") = ._INCOME + ._INT + ._SSRR + ._OTHER
    dr.Item("reason") = String.Empty
    dr.Item("benefit") = 0
    ds3.Tables(0).Rows.Add(dr)
  End With
End Sub
Private Sub Writeds4()
  With myTXM59AQ
    dr = ds4.Tables(0).NewRow
    dr.Item("listno") = ._LISTNO
    dr.Item("year") = ._YEAR
    dr.Item("alname") = ._ALNAME
    dr.Item("afname") = ._AFNAME
    dr.Item("ainit") = ._AINIT
    dr.Item("total") = ._INCOME + ._INT + ._SSRR + ._OTHER
    dr.Item("reason") = String.Empty
    dr.Item("benefit") = ._XVET + ._XADDL
    ds4.Tables(0).Rows.Add(dr)
  End With
End Sub
End Module






