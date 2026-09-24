Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myCKHIST As CKHIST.myData

  Dim ds As DataSet = New DataSet
  Dim dr As DataRow

  Dim strBuffer As String
  Dim WrkUpdate As Boolean
  Public Sub PrtReport()

    myCKHIST = New CKHIST.MyData(myDBConnect)
    With MyFrmAP531B
      WrkUpdate = .ChkUpdate.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDs(ds)
    Else
      ds.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .WrkPost = WrkUpdate
      .Show()
    End With

  End Sub
  Public Sub BuildDs(ByRef Ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Empno", Type.GetType("System.Int32"))
      .Columns.Add("Empname", Type.GetType("System.String"))
      .Columns.Add("Chkdte", Type.GetType("System.DateTime"))
      .Columns.Add("Cknum", Type.GetType("System.Decimal"))
      .Columns.Add("CkAmt", Type.GetType("System.Decimal"))
    End With
    Ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkStream As FileStream = New FileStream(MyFrmAP531B.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Integer
    Dim sArray() As String
    Dim WrkCkNum As Integer
    Dim WrkEmpno As Integer
    Dim WrkEmpName As String
    Dim WrkCkAmt As Integer
    Dim WrkChkdte As Integer
    Dim I As Integer

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length

NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      GoTo Done
    End If

    sArray = Parse(strBuffer, ",")
    I = I + strBuffer.Length
    With myCKHIST
      WrkEmpNo = MyUtils.CnvSng(sArray(0))
      WrkEmpName = Trim(sArray(2))
      WrkCkNum = MyUtils.CnvSng(sArray(3))
      WrkCkAmt = MyUtils.CnvSng(sArray(5))
      WrkChkdte = MyUtils.CnvSng(sArray(7))
      dr = ds.Tables(0).NewRow
      dr("empno") = WrkEmpno
      dr("empname") = WrkEmpName
      dr("chkdte") = MyUtils.GetDBDateMDY(WrkChkdte)
      dr("cknum") = WrkCkNum
      dr("ckamt") = WrkCkAmt
      ds.Tables(0).Rows.Add(dr)

      .GetOneRecordP(WrkCknum)
      If WrkUpdate Then
        ._CHKDTE = WrkChkdte
        ._CKAMT = WrkCkAmt
        ._CKCODE = sArray(6)
        ._CKDATE = MyUtils.CnvSng(sArray(4))
        ._CKNUM = WrkCknum
        ._EMNAME = WrkEmpName
        ._EMPNO = WrkEmpno
        ._PORV = sArray(1)
        .AddOneRecordP()
        If .ErrMsg <> "" Then
          WriteErrorLog(.ErrMsg)
          Exit Sub
        End If
      End If
    End With

NextRec:
    With myFrmProgress
      WrkPct = I / WrkFileSize
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
    GoTo NextLine

Done:
    sr.Close()
    myFrmProgress.Close()
  End Sub
End Module
