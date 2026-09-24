Imports System.Text

Module PrintEdits
  Dim myFrmProgress As FrmProgress
  Dim myTSPBCHL1 As TSPBCHL1.MyData
  Dim myTXINV As TXINV.MyData
  Dim dsTSPBCH As DataSet = New DataSet
  Dim ds As DataSet = New DataSet

  Dim WrkPct As Integer
  Dim SavePct As Integer
  'Buffered files
  Dim WrkSupCode(25) As String
  Dim WrkSupDesc(25) As String

  Dim Errors As Boolean

  Public Function PrtEdits(ByVal BatchNo As Integer, ByVal Post As Boolean,
  ByVal PostDate As Date) As Boolean

    myTSPBCHL1 = New TSPBCHL1.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)

    Errors = False
    dsTSPBCH = myTSPBCHL1.GetViewbyBatch(BatchNo, 99999)
    BufferTXSresn()
    BuildPrtDS()
    AddRecords(BatchNo)

    MyFrmCr_PrtEdits = New FrmCr_PrtEdits
    MyFrmCr_PrtEdits.Wrkds = ds
    MyFrmCr_PrtEdits.WrkPost = Post
    MyFrmCr_PrtEdits.WrkPostDate = PostDate
    MyFrmCr_PrtEdits.WrkErrors = Errors
    MyFrmCr_PrtEdits.ShowDialog()
    ds.Tables.Remove("mytable")
    'Memory Cleanup
    myTSPBCHL1 = Nothing
    Return Errors

  End Function
  Sub BuildPrtDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("BatchNo", Type.GetType("System.Int32"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("SuspCd", Type.GetType("System.String"))
      .Columns.Add("SuspDesc", Type.GetType("System.String"))
      .Columns.Add("SuspDt", Type.GetType("System.DateTime"))
      .Columns.Add("Comment", Type.GetType("System.String"))
      .Columns.Add("Dist", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Amount", Type.GetType("System.Decimal"))
      .Columns.Add("SuspAmount", Type.GetType("System.Decimal"))
      .Columns.Add("Error", Type.GetType("System.Boolean"))
    End With
    ds.Tables.Add(myTable)
  End Sub

  Sub AddRecords(ByVal BatchNo As Integer)
    Dim myDr As Data.DataRow
    Dim AddrLine() As String
    Dim I As Integer
    Dim K As Integer

    If dsTSPBCH.Tables(0).Rows.Count = 0 Then
      Errors = True
      Exit Sub
    End If

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (dsTSPBCH.Tables(0).Rows.Count - 1)
      With dsTSPBCH.Tables(0).Rows(I)
        myDr = ds.Tables(0).NewRow
        myDr("batchno") = BatchNo
        myDr("listno") = .Item("list#")
        myDr("type") = .Item("type")
        myDr("typedesc") = GetTXTypeDesc(.Item("type"))
        myDr("year") = .Item("year")
        myDr("suspcd") = .Item("scd")
        K = LookupTxSRESN(.Item("scd"))
        myDr("suspdesc") = WrkSupDesc(K)
        myDr("suspdt") = MyUtils.GetDBDate(.Item("pdate"))
        myDr("comment") = .Item("comm")
        myTXINV.GetOneRecordP(.Item("list#"), .Item("year"), .Item("type"))
        myDr("error") = False
        If Not myTXINV.RecordNotFound Then
          With myTXINV
            myDr("name") = Trim(._NAME)
            AddrLine = SetAddrLine3(._ADD1, ._ADD2, ._CITY, ._STATE, ._ZIP5, ._ZIP4)
            myDr("addr1") = AddrLine(0)
            myDr("addr2") = AddrLine(1)
            myDr("addr3") = AddrLine(2)
            myDr("amount") = dsTSPBCH.Tables(0).Rows(I).Item("taxt")
            If ._ICODE = "S" Then
              myDr("suspamount") = 0
            Else
              myDr("suspamount") = ._BALD
            End If
          End With
        Else
          myDr("name") = "*** Record not found ***"
          myDr("amount") = ds.Tables(0).Rows(I).Item("taxt")
          myDr("suspamount") = 0
          myDr("error") = True
          Errors = True
        End If
        ds.Tables(0).Rows.Add(myDr)
      End With
NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / dsTSPBCH.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    myFrmProgress.Close()
  End Sub
  Public Function SetAddrLine3(ByVal Add1 As String, ByVal Add2 As String, ByVal City As String, ByVal State As String,
   ByVal Zip5 As Integer, ByVal Zip4 As Integer,
   Optional ByVal ZipAlpha As String = "") As String()
    'Returns Address as string array. Blank lines are stripped out. 
    'City, State, Zip5 and Zip4 are combined into one line
    Dim AddrLine(2) As String
    Dim sb As StringBuilder
    Dim I As Integer

    AddrLine(I) = Trim(Add1)
    I = I + 1
    If Trim(Add2) <> "" Then
      AddrLine(I) = Trim(Add2)
      I = I + 1
    End If
    sb = New StringBuilder
    sb.Append(Trim(City))
    sb.Append(", ")
    sb.Append(Trim(State))
    sb.Append(" ")
    If ZipAlpha = "" Then
      sb.Append(Format(Zip5, "00000"))
      If Zip4 > 0 Then
        sb.Append("-")
        sb.Append(Format(Zip4, "0000"))
      End If
    Else
      sb.Append(Trim(ZipAlpha))
    End If
    AddrLine(I) = sb.ToString
    If AddrLine(2) Is Nothing Then
      AddrLine(2) = ""
    End If
    Return AddrLine

  End Function
  Private Sub BufferTXSresn()
    Dim I As Integer

    Dim myTXSRESN As TXSRESN.MyData
    Dim dsTXSRESN As DataSet = New DataSet

    myTXSRESN = New TXSRESN.MyData(myDBConnect)

    dsTXSRESN = myTXSRESN.GetAllData
    For I = 0 To dsTXSRESN.Tables(0).Rows.Count - 1
      With dsTXSRESN.Tables(0).Rows(I)
        WrkSupCode(I) = .Item("sresn")
        WrkSupDesc(I) = .Item("srdesc")
      End With
    Next

  End Sub
  Private Function LookupTxSRESN(ByVal Code As String) As Integer
    Dim I As Integer

    For I = 0 To WrkSupCode.GetUpperBound(0)
      If Trim(WrkSupCode(I)) = "" Then
        Return I
      End If
      If Trim(Code) = Trim(WrkSupCode(I)) Then
        Return I
      End If
    Next

  End Function
End Module






