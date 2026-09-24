Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Module ImportData

  Dim sw As StreamWriter
  Dim strBuffer As String
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myPOMASTQ As POMASTQ.MyData
  Dim myPOMASTL1 As POMASTL1.MyData
  Dim myPOSUMF As POSUMF.MyData
  Dim myPOSUMFL1 As POSUMFL1.MyData
  Dim myPOSUMFQ As POSUMFQ.MyData
  Dim WrkPost As Boolean
  Public Sub Impdata()

    MyDBName = MyFrmFixB.TxtDBName.Text
    myDBConnect = New SQLConnect.DBConnection(MyDBName)
    myDBConnect.Open()

    myPOMASTQ = New POMASTQ.MyData()
    myPOMASTQ.MyDBConn = myDBConnect
    myPOMASTL1 = New POMASTL1.MyData()
    myPOMASTL1.MyDBConn = myDBConnect
    myPOSUMF = New POSUMF.MyData()
    myPOSUMF.MyDBConn = myDBConnect
    myPOSUMFL1 = New POSUMFL1.MyData()
    myPOSUMFL1.MyDBConn = myDBConnect

    GetDetail()
  End Sub
  Private Sub GetDetail()

    Dim dspo As DataSet = New DataSet
    Dim dssum As DataSet = New DataSet
    Dim WrkAnd As String
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkAcct As Decimal
    Dim WrkAmount As Decimal
    Dim Found As Boolean
    Dim Counter As Integer
    Dim I As Integer
    Dim J As Integer
    WrkAnd = " and "

    With MyFrmFixB
      WrkPost = .ChkPost.Checked
    End With

    sw = New StreamWriter(GetDataPath() & "FixPOMAST.csv")
    WrkQry = "FSCYR>=2022 and POSEQ=0"
    WrkSort = "PONBR"
    myPOMASTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myPOMASTQ.ReadQry()
    If Not myPOMASTQ.IsEOF Then
      With myPOMASTQ
        Counter = Counter + 1
        dspo = myPOMASTL1.GetSumbyAcct(._FSCYR, ._PONBR, ._POSUF, ._POPST)
        dssum = myPOSUMFL1.GetAllPONo(._FSCYR, ._PONBR, 0)
        For I = 0 To dssum.Tables(0).Rows.Count - 1
          Found = False
          For J = 0 To dspo.Tables(0).Rows.Count - 1
            WrkAcct = BuildAcct(dspo.Tables(0).Rows(J).Item("fdnbr"),
              dspo.Tables(0).Rows(J).Item("sfund"), dspo.Tables(0).Rows(J).Item("dpnbr"),
              dspo.Tables(0).Rows(J).Item("obnbr"), dspo.Tables(0).Rows(J).Item("fnpgm"),
              dspo.Tables(0).Rows(J).Item("subfn"))
            If dssum.Tables(0).Rows(I).Item("acct") = WrkAcct Then
              Found = True
              Exit For
            End If
          Next
          If Not Found Then
            sw.WriteLine("Delete POSUMF: " & ._FSCYR & "," & ._PONBR & ",'" & dssum.Tables(0).Rows(I).Item("acct"))
            If WrkPost Then
              myPOSUMF.GetOneRecordP(._FSCYR, ._PONBR, dssum.Tables(0).Rows(I).Item("acct"))
              myPOSUMF.DeleteOneRecordP()
            End If
          End If
        Next

        For I = 0 To dspo.Tables(0).Rows.Count - 1
          Found = False
          WrkAcct = BuildAcct(dspo.Tables(0).Rows(I).Item("fdnbr"),
              dspo.Tables(0).Rows(I).Item("sfund"), dspo.Tables(0).Rows(I).Item("dpnbr"),
              dspo.Tables(0).Rows(I).Item("obnbr"), dspo.Tables(0).Rows(I).Item("fnpgm"),
              dspo.Tables(0).Rows(I).Item("subfn"))
          WrkAmount = dspo.Tables(0).Rows(I).Item("wrksum")
          For J = 0 To dssum.Tables(0).Rows.Count - 1
            If dssum.Tables(0).Rows(J).Item("acct") = WrkAcct Then
              Found = True
              Exit For
            End If
          Next
          If Not Found Then
            sw.WriteLine("Add POSUMF: " & ._FSCYR & "," & ._PONBR & ",'" & WrkAcct)
            myPOSUMF.GetOneRecordP(._FSCYR, ._PONBR, WrkAcct)
            myPOSUMF._POAMT = WrkAmount
            If ._AMTNT = ._POPEN Then
              myPOSUMF._POOPN = WrkAmount
            Else
              myPOSUMF._POOPN = 0
            End If
            If ._POPEN = 0 Then
              myPOSUMF._POPAD = WrkAmount
            Else
              myPOSUMF._POPAD = 0
            End If
            myPOSUMF._FSCYR = ._FSCYR
            myPOSUMF._PONBR = ._PONBR
            myPOSUMF._ACCT = WrkAcct
            If WrkPost Then
              myPOSUMF.AddOneRecordP()
            End If
            If myPOSUMF._POOPN = 0 And myPOSUMF._POPAD = 0 Then
              sw.WriteLine("*Adjust POSUMF: " & ._FSCYR & "," & ._PONBR & ",'" & WrkAcct)
            End If
          End If
          '              If dssum.Tables(0).Rows(J).Item("poamt") <> WrkAmount Then
          '            sw.WriteLine("Update POSUMF: " & ._FSCYR & "," & ._PONBR & ",'" & WrkAcct)
          '         End If
        Next
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

    sw.Flush()
    sw.Close()
    myFrmProgress.Close()
  End Sub
  Private Sub BreakAcct(ByVal In_Acct As String, ByRef Out_Fund As Integer, ByRef Out_SFund As Integer, ByRef Out_Dept As Integer,
 ByRef Out_Obj As Integer, ByRef Out_Func As Integer, ByRef Out_Subfn As Integer)
    Dim sb As StringBuilder = New StringBuilder
    Dim WrkLen As Integer
    Dim WrkStr As Integer

    Select Case Len(In_Acct)
      Case 19
        WrkLen = 1
      Case 20
        WrkLen = 2
      Case 21
        WrkLen = 3
    End Select
    Out_Fund = Mid(In_Acct, 1, WrkLen)
    WrkStr = 1 + WrkLen
    Out_SFund = Mid(In_Acct, WrkStr, 3)
    WrkStr = WrkStr + 3
    Out_Dept = Mid(In_Acct, WrkStr, 4)
    WrkStr = WrkStr + 4
    Out_Obj = Mid(In_Acct, WrkStr, 3)
    WrkStr = WrkStr + 3
    Out_Func = Mid(In_Acct, WrkStr, 4)
    WrkStr = WrkStr + 4
    Out_Subfn = Mid(In_Acct, WrkStr, 4)
  End Sub
  Public Function BuildAcct(ByVal Fund As Integer, ByVal SFund As Integer,
 ByVal Dept As Integer, ByVal Obj As Integer, ByVal Func As Integer, ByVal SFunc As Integer) As String
    Dim sb As StringBuilder = New StringBuilder

    If Fund > 0 Then
      sb.Append(Format(Fund, "000"))
      sb.Append(Format(SFund, "000"))
      sb.Append(Format(Dept, "0000"))
      sb.Append(Format(Obj, "000"))
      sb.Append(Format(Func, "0000"))
      sb.Append(Format(SFunc, "0000"))
    Else
      sb.Append(String.Empty)
    End If
    Return sb.ToString
  End Function
End Module
