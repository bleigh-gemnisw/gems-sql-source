Imports System.io
Imports System.Text
Module ImportData

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer

  Dim myUTXREF As UTXREF.MyData
  Dim myUTXREFL1 As UTXREFL1.MyData

  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim DsUTXREF As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim drSel() As Data.DataRow

  Dim WrkCompany As String
  Dim WrkPost As Boolean
  Dim WrkAnd As String
  Dim WrkOr As String

  Public Sub ImpData()

    myUTXREF = New UTXREF.MyData(myDBConnect)
    myUTXREFL1 = New UTXREFL1.MyData(myDBConnect)

    With MyFrmUB307B
      If .RbCTWater.Checked Then WrkCompany = "CTWater"
      WrkPost = .ChkPost.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDs(ds, ds2)
    Else
      ds.Clear()
      ds2.Clear()
    End If

    GetDetail(MyFrmUB307B.LblFilePath.Text)

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .wrkds2 = ds2
      .WrkCompany = WrkCompany
      .WrkPost = WrkPost
      .Show()
    End With

  End Sub
  Private Sub GetDetail(ByVal WrkFile As String)
    Dim WrkStream As FileStream = New FileStream(WrkFile, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim sArray() As String
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim I As Integer
    Dim WrkXref As String
    Dim WrkAcct As Integer
    Dim WrkName As String
    Dim WrkLocation As String

    myFrmProgress = New FrmProgress
    myFrmProgress.Text = "Creating Report..."
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()
    SavePct = 0

    WrkFileSize = WrkStream.Length

NextLine:
    strBuffer = sr.ReadLine
    If strBuffer Is Nothing Then
      GoTo Cleanup
    End If
    I = I + strBuffer.Length
    sArray = Parse(strBuffer, ",")
    WrkAcct = 0
    Select Case WrkCompany
      Case "CTWater"
        WrkName = Trim(sArray(2))
        WrkLocation = Trim(sArray(3)) & " " & Trim(sArray(4))
        For I = 12 To 23
          If MyUtils.CnvSng(sArray(I)) = 0 Then
            Exit For
          End If
          WrkXref = MyUtils.CnvSng(sArray(I))
          UpdateXref(WrkXref, WrkName, WrkLocation)
        Next
    End Select


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
  Private Sub UpdateXref(ByVal WrkXref As String, ByVal WrkName As String, WrkLocation As String)
    Dim WrkAcct As Integer
    Dim WrkUse As String
    WrkUse = ""
    DsUTXREF = myUTXREFL1.GetXRef(WrkXref)
    If DsUTXREF.Tables(0).Rows.Count > 0 Then
      WrkAcct = DsUTXREF.Tables(0).Rows(0).Item("cxacct")
      WrkUse = Trim(DsUTXREF.Tables(0).Rows(0).Item("cxuse"))
    End If

    If DsUTXREF.Tables(0).Rows.Count > 0 Then
      dr = ds.Tables(0).NewRow
      dr.Item("xref") = WrkXref
      dr.Item("listno") = WrkAcct
      dr.Item("name") = WrkName
      dr.Item("location") = WrkLocation
      dr.Item("use") = WrkUse
      ds.Tables(0).Rows.Add(dr)
    Else
      dr = ds2.Tables(0).NewRow
      dr.Item("xref") = WrkXref
      dr.Item("listno") = 0
      dr.Item("name") = WrkName
      dr.Item("location") = WrkLocation
      dr.Item("use") = ""
      ds2.Tables(0).Rows.Add(dr)
    End If

    If WrkPost Then
      If WrkUse = "" And DsUTXREF.Tables(0).Rows.Count > 0 Then
        With myUTXREF
          .GetOneRecordP(WrkAcct, DsUTXREF.Tables(0).Rows(0).Item("cxcode"), WrkXref)
          ._CXUSE = "N"
          .UpdateOneRecordP()
        End With
      End If
    End If

  End Sub
End Module
