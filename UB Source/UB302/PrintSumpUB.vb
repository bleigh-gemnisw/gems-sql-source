'CVS file(2 fields): Acct, Y or N (Y=Add Sump,N=Delete Sump)
Imports System.IO
Imports System.Text
Module PrintSumpUB

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer

  Dim myUTCUST As UTCUST.MyData
  Dim myUTCUSTRT As UTCUSTRT.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim ds2 As DataSet = New DataSet

  Dim WrkPost As Boolean
  Dim WrkAnd As String
  Dim WrkOr As String
  'Shared Fields
  Dim WrkAcct As Integer
  Dim WrkName As String
  Dim WrkSName As String
  Const myType As String = "Z" 'UB Type
  Const myCode As String = "Z" 'Rate Code
  Public Sub PrtSumpUB()
    myUTCUST = New UTCUST.MyData(myDBConnect)
    myUTCUSTRT = New UTCUSTRT.MyData(myDBConnect)

    With MyFrmUB302B
      WrkPost = .ChkPost.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDs(ds)
      ds2 = ds.Clone
    Else
      ds.Clear()
      ds2.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .wrkds2 = ds2
      .WrkOption = "Sump"
      .WrkPost = WrkPost
      .Show()
    End With

  End Sub
  Private Sub GetDetail()
    Dim WrkStream As FileStream = New FileStream(MyFrmUB302B.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim sArray As String()
    Dim WrkFileSize As Integer
    Dim I As Integer
    Dim WrkSump As String
    Dim WrkMsg As String

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length

NextLine:
    strBuffer = sr.ReadLine
    If strBuffer Is Nothing Then
      GoTo Cleanup
    End If
    sArray = Parse(strBuffer, ",")

    WrkMsg = String.Empty
    WrkAcct = MyUtils.CnvSng(sArray(0))
    WrkSump = sArray(1)
    myUTCUST.GetOneRecordP(WrkAcct)
    If myUTCUST.RecordNotFound Then
      WrkMsg = "*** Account not found ***"
    End If
    If Mid(WrkMsg, 1, 3) <> "***" Then
      dr = ds.Tables(0).NewRow
    Else
      dr = ds2.Tables(0).NewRow
    End If

    I = I + strBuffer.Length
    dr.Item("listno") = WrkAcct
    dr.Item("ubname") = Trim(myUTCUST._CUNAM1)
    dr.Item("location") = Trim(myUTCUST._CULOCNO) & " " & myUTCUST._CULOC
    dr.Item("name") = Trim(WrkName)
    dr.Item("sump") = WrkSump
    dr.Item("errmsg") = WrkMsg
    If Mid(WrkMsg, 1, 3) <> "***" Then
      ds.Tables(0).Rows.Add(dr)
    Else
      ds2.Tables(0).Rows.Add(dr)
    End If
    dr = Nothing

    If WrkPost And WrkMsg = "" Then
      UpdateFiles(WrkSump)
    End If

NextRec:
    With myFrmProgress
      WrkPct = (I / WrkFileSize) * 100
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
    GoTo NextLine

Cleanup:
    sr.Close()
    myFrmProgress.Close()

  End Sub
  Private Sub UpdateFiles(ByVal WrkSump As String)

    With myUTCUST
      If WrkSump = "Y" Then
        ._CUPCAT = "PUMP"
      Else
        ._CUPCAT = ""
      End If
      .UpdateOneRecordP()
      If .ErrMsg <> "" Then
        WriteErrorLog(.ErrMsg)
        Exit Sub
      End If
    End With

    With myUTCUSTRT
      .GetOneRecordP(WrkAcct, myType)
      If WrkSump = "Y" Then
        If .RecordNotFound Then
          ._CRACCT = WrkAcct
          ._CRTYPE = myType
          ._CRCODE = myCode
          .AddOneRecordP()
        End If
      Else
        If Not .RecordNotFound Then
          .DeleteOneRecordP()
        End If
      End If
      If .ErrMsg <> "" Then
        WriteErrorLog(.ErrMsg)
        Exit Sub
      End If
    End With

  End Sub
End Module






