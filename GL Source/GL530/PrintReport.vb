Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myGLBUDGET As GLBUDGET.myData

  Dim ds As DataSet = New DataSet
  Dim dr As DataRow
  Dim WrkPost As Boolean
  Public Sub PrtReport()
    myGLBUDGET = New GLBUDGET.MyData
    myGLBUDGET.MyDBConn = myDBConnect

    With MyFrmGL530B
      WrkPost = .ChkPost.Checked
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
      .Wrkds = ds
      .WrkPost = WrkPost
      .Show()
    End With

  End Sub
  Public Sub BuildDs(ByRef Ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Acct", Type.GetType("System.String"))
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("Amount", Type.GetType("System.Decimal"))
      .Columns.Add("ErrorMsg", Type.GetType("System.String"))
    End With
    Ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkStream As FileStream = New FileStream(MyFrmGL530B.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim sArray As String()
    Dim WrkFileSize As Integer
    Dim I As Integer
    Dim WrkFund As Integer
    Dim WrkSFund As Integer
    Dim WrkDpnbr As Integer
    Dim WrkObnbr As Integer
    Dim WrkFnpgm As Integer
    Dim WrkSubfn As Integer
    Dim WrkAmount As Long
    Dim WrkErrorMsg As String

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Headings
    strBuffer = sr.ReadLine 'Skip Headings
    strBuffer = sr.ReadLine 'Skip Headings

NextLine:
    strBuffer = sr.ReadLine
    If strBuffer Is Nothing Then
      GoTo End_of_file
      Exit Sub
    End If

    sArray = Parse(strBuffer, ",")
    WrkAmount = MyUtils.CnvSng(sArray(6))
    I = I + strBuffer.Length
    WrkErrorMsg = ""
    BreakAcct(sArray(0), WrkFund, WrkSFund, WrkDpnbr, WrkObnbr, WrkFnpgm, WrkSubfn)
    myGLBUDGET.GetOneRecordP(WrkFund, WrkSFund, WrkDpnbr, WrkObnbr, WrkFnpgm, WrkSubfn)
    If myGLBUDGET.RecordNotFound Then
      WrkErrorMsg = "Invalid Account"
    Else
      If WrkAmount = 0 Then
        WrkErrorMsg = "Amount is 0"
      End If
    End If
    dr = ds.Tables(0).NewRow
    dr.Item("acct") = sArray(0)
    dr.Item("desc") = sArray(1)
    dr.Item("amount") = WrkAmount
    dr.Item("errormsg") = WrkErrorMsg
    ds.Tables(0).Rows.Add(dr)

    If WrkPost And WrkErrorMsg = "" Then
      With myGLBUDGET
        ._BAMT1 = WrkAmount
        .UpdateOneRecordP()
      End With
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

End_of_file:
    sr.Close()
    myFrmProgress.Close()
  End Sub
  Private Sub BreakAcct(ByVal In_Acct As String, ByRef Out_Fund As Integer, ByRef Out_SFund As Integer, ByRef Out_Dept As Integer,
 ByRef Out_Obj As Integer, ByRef Out_Func As Integer, ByRef Out_Subfn As Integer)
    Dim sb As StringBuilder = New StringBuilder

    If Len(In_Acct) = 26 Then
      Out_Fund = Mid(In_Acct, 1, 3)
      Out_SFund = Mid(In_Acct, 5, 3)
      Out_Dept = Mid(In_Acct, 9, 4)
      Out_Obj = Mid(In_Acct, 14, 3)
      Out_Func = Mid(In_Acct, 18, 4)
      Out_Subfn = Mid(In_Acct, 23, 4)
    Else
      Out_Fund = 0
      Out_SFund = 0
      Out_Dept = 0
      Out_Obj = 0
      Out_Func = 0
      Out_Subfn = 0
    End If
  End Sub
End Module
