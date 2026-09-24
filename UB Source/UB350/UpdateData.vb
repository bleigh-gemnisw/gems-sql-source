Imports System.Collections.Generic
Imports System.Text
Module UpdateData

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myUTCUST As UTCUSTQ.MyData
  Dim myUTTYPE As UTTYPE.MyData
  Dim myUTCUSTRT As UTCUSTRT.MyData
  Dim myTXINV As TXINV.MyData
  Dim dsFam As DataSet = New DataSet
  Dim ds As DataSet = New DataSet
  Dim dsInv As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim ds3 As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim wrklistno As Integer
  Dim wrkcbname As Boolean
  Dim wrkcbaddr As Boolean
  Dim wrkyear As Integer
  Dim WrkPost As Boolean

  Dim WrkSortBy As String
  Public Sub UpData()
    myUTCUST = New UTCUSTQ.MyData(myDBConnect)
    myUTCUSTRT = New UTCUSTRT.MyData(myDBConnect)
    myUTTYPE = New UTTYPE.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    dsFam.Tables.Clear()
    ds.Tables.Clear()

    With MyFrmUB350B
      wrkcbname = False
      wrkyear = MyUtils.CnvSng(.TxtYear.Text)
      If .ChkName.Checked = True Then wrkcbname = True
      wrkcbaddr = False
      If .ChkAddr.Checked = True Then wrkcbaddr = True
      If .RbSortName.Checked Then WrkSortBy = "NAME"
      If .RbSortList.Checked Then WrkSortBy = "LIST#"
      If .ChkPost.Checked Then WrkPost = True
    End With
    BuildFamDs(dsFam)
    BuildDs(ds)


    ds.Clear()

    GetDetail()

    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds1 = ds

      .Show()
    End With

  End Sub
  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim wrkzip10 As String
    ' this routine will update txinv with  name and or address from  utcust
    ' Only the fields selected will be updated on an update.

    WrkSort = ""
    WrkQry = ""
    Counter = 0

    myUTCUST.OpenQry(WrkSort, WrkQry)
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myUTCUST.ReadQry()
    If Not myUTCUST.IsEOF Then
      With myUTCUST
        Counter = Counter + 1
        wrklistno = ._CUACCT
      End With
      For Each row As DataRow In dsFam.Tables("mytable").Rows
        Dim wrkubtype As String = row("UBType").ToString()
        Dim wrktxtype As String = row("TXTYPE").ToString()
        myUTCUSTRT.GetOneRecordP(wrklistno, wrkubtype)
        If myUTCUSTRT.RecordNotFound Then
          GoTo readnextfam
        End If
        myTXINV.GetOneRecordP(wrklistno, wrkyear, wrktxtype)
        If myTXINV.RecordNotFound Then   ' no inv record so check if they got another tax type
          GoTo readnextfam
        End If
        With myTXINV
          wrkzip10 = Format(._ZIP5, "00000")
          If ._ZIP4 > 0 Then
            wrkzip10 = wrkzip10 & "-" & Format(._ZIP4, "0000")
          End If

          If (wrkcbname AndAlso (myUTCUST._CUNAM1 <> ._NAME OrElse myUTCUST._CUNAM2 <> ._SNAME)) _
            OrElse (wrkcbaddr AndAlso (myUTCUST._CUADD1 <> ._ADD1 OrElse myUTCUST._CUADD2 <> ._ADD2 _
                    OrElse myUTCUST._CUCITY <> ._CITY OrElse myUTCUST._CUST <> ._STATE _
                    OrElse Trim(myUTCUST._CUZIP) <> wrkzip10)) Then


            'write to datatable
            Dim mismatchRow As DataRow = ds.Tables("mytable").NewRow()
            If WrkSortBy = "NAME" Then
              mismatchRow("sortdata") = $"{myUTCUST._CUNAM1}"
            Else
              mismatchRow("sortdata") = $"{Format(wrklistno, "000000")}-{wrktxtype}"

            End If

            mismatchRow("listno") = wrklistno
            mismatchRow("txyear") = wrkyear
            mismatchRow("txtype") = wrktxtype
            mismatchRow("cname") = myUTCUST._CUNAM1
            mismatchRow("cname2") = myUTCUST._CUNAM2
            mismatchRow("cadd1") = myUTCUST._CUADD1
            mismatchRow("cadd2") = myUTCUST._CUADD2
            mismatchRow("ccity") = myUTCUST._CUCITY
            mismatchRow("cstate") = myUTCUST._CUST
            mismatchRow("czip") = myUTCUST._CUZIP
            mismatchRow("iname") = ._NAME
            mismatchRow("iname2") = ._SNAME
            mismatchRow("iadd1") = ._ADD1
            mismatchRow("iadd2") = ._ADD2
            mismatchRow("icity") = ._CITY
            mismatchRow("istate") = ._STATE
            mismatchRow("izip") = wrkzip10
            ds.Tables("mytable").Rows.Add(mismatchRow)




          End If

        End With
readnextfam:
      Next





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
    ' posting at end read through dataset
    If WrkPost Then
      UpdateTXINV()
    End If

    myFrmProgress.Close()
    myUTCUST.CloseFile()
    myUTCUSTRT.CloseFile()
    myTXINV.CloseFile()
  End Sub
  Private Sub UpdateTXINV()
    'routine to be written



    For Each row As DataRow In ds.Tables("mytable").Rows
      Dim listno As Integer = CInt(row("listno"))
      Dim txyear As Integer = CInt(row("txyear"))
      Dim txtype As String = row("txtype").ToString().Trim()

      Dim cname As String = row("cname").ToString().Trim()
      Dim cname2 As String = row("cname2").ToString().Trim()
      Dim cadd1 As String = row("cadd1").ToString().Trim()
      Dim cadd2 As String = row("cadd2").ToString().Trim()
      Dim ccity As String = row("ccity").ToString().Trim()
      Dim cstate As String = row("cstate").ToString().Trim()
      Dim czip As String = row("czip").ToString().Trim()

      ' Extract zip5 and zip4
      Dim zip5 As Integer = If(czip.Length >= 5, CInt(czip.Substring(0, 5)), 0)
      Dim zip4 As Integer = If(czip.Length > 5, CInt(czip.Substring(5).PadLeft(4, "0"c)), 0)

      Dim WrkSet As New List(Of String)()
      Dim WrkWhere As String = $"WHERE list#={listno} AND year={txyear} AND type='{txtype}'"

      ' Build the SET clause based on checkboxes
      If wrkcbname = True Then
        WrkSet.Add($"name='{cname}'")
        WrkSet.Add($"sname='{cname2}'")
      End If

      If wrkcbaddr = True Then
        WrkSet.Add($"add1='{cadd1}'")
        WrkSet.Add($"add2='{cadd2}'")
        WrkSet.Add($"city='{ccity}'")
        WrkSet.Add($"state='{cstate}'")
        WrkSet.Add($"zip5={zip5}")
        WrkSet.Add($"zip4={zip4}")
      End If

      ' Only execute if there are fields to update
      If WrkSet.Count > 0 Then
        Dim WrkSetClause As String = "SET " & String.Join(", ", WrkSet)
        ' Execute the update query
        myTXINV.RunUpdateQuery(WrkSetClause, WrkWhere)
      End If
    Next




  End Sub
  Public Sub BuildDs(ByRef Ds As DataSet)
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("sortdata", Type.GetType("System.String"))
      .Columns.Add("listno", Type.GetType("System.Int32"))
      .Columns.Add("txyear", Type.GetType("System.Int32"))
      .Columns.Add("txtype", Type.GetType("System.String"))
      .Columns.Add("cname", Type.GetType("System.String"))
      .Columns.Add("cname2", Type.GetType("System.String"))
      .Columns.Add("cadd1", Type.GetType("System.String"))
      .Columns.Add("cadd2", Type.GetType("System.String"))
      .Columns.Add("ccity", Type.GetType("System.String"))
      .Columns.Add("cstate", Type.GetType("System.String"))
      .Columns.Add("czip", Type.GetType("System.String"))
      .Columns.Add("iname", Type.GetType("System.String"))
      .Columns.Add("iname2", Type.GetType("System.String"))
      .Columns.Add("iadd1", Type.GetType("System.String"))
      .Columns.Add("iadd2", Type.GetType("System.String"))
      .Columns.Add("icity", Type.GetType("System.String"))
      .Columns.Add("istate", Type.GetType("System.String"))
      .Columns.Add("izip", Type.GetType("System.String"))


    End With
    Ds.Tables.Add(myTable)


  End Sub
  Public Sub BuildFamDs(ByRef DsFam As DataSet)
    Dim ds2 As DataSet = New DataSet
    Dim dr As DataRow
    Dim I As Integer

    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Family", Type.GetType("System.String"))
      .Columns.Add("UBType", Type.GetType("System.String"))
      .Columns.Add("TXTYPE", Type.GetType("System.String"))

    End With
    DsFam.Tables.Add(myTable)

    ds2 = myUTTYPE.GetAllData
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        DsFam.Tables(0).NewRow()
        dr = DsFam.Tables(0).NewRow
        dr("Family") = .Item("tyuttp")
        dr("UBType") = .Item("tytype")
        dr("TXTYPE") = .Item("TyTXTP")
        If .Item("tyuttp") = "U" Or .Item("tyuttp") = "M" Then
          DsFam.Tables(0).Rows.Add(dr)
        End If
      End With
    Next

  End Sub

End Module






