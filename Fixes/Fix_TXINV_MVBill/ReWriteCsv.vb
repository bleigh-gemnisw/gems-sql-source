Imports System.IO
Imports System.Text
Module ReWriteCsv

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVTo As TXINV.MyData

  'Work Fields
  Dim WrkToListNo As Integer
  Dim WrkToYear As Integer
  Dim WrkToType As String

  Public Sub Rewrite()
    myTXINVTo = New TXINV.MyData(myDBConnect)
    GetDetail()
  End Sub
  Private Sub GetDetail()
    Dim WrkStream As FileStream = New FileStream(MyFrmFixB.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim sw As StreamWriter
    Dim strBuffer As String
    Dim SArray As String()
    Dim WrkFileSize As Integer
    Dim WrkLeft As Decimal
    Dim WrkTax As Decimal
    Dim WrkTax1st As Decimal
    Dim WrkTax2nd As Decimal
    Dim WrkCredit As Decimal
    Dim WrkAdjTax As Decimal
    Dim WrkAdj1st As Decimal
    Dim WrkAdj2nd As Decimal
    Dim I As Integer

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    sw = New StreamWriter(MyFrmFixB.LblFilePath.Text & "-cr.csv")
    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine
    sw.WriteLine(strBuffer & ",Credit")

NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      GoTo CloseFiles
    End If

    I = I + strBuffer.Length
    SArray = Parse(strBuffer, ",")
    WrkToListNo = SArray(1)
    WrkToYear = SArray(2)
    WrkToType = SArray(3)

    With myTXINVTo
      .GetOneRecordP(WrkToListNo, WrkToYear, WrkToType)
      If Trim(._ILEASE) <> "OP" Then
        GoTo NextRec
      End If
      If .RecordNotFound Then
        WrkCredit = 0
      Else
        WrkCredit = ._TAXT - ._BALD
        WrkTax = SArray(12)
        If WrkCredit > WrkTax Then
          WrkCredit = WrkTax
        End If
        WrkTax1st = SArray(13)
        WrkTax2nd = SArray(14)
        WrkAdjTax = WrkTax - WrkCredit
        WrkLeft = WrkTax1st - WrkCredit
        If WrkLeft >= 0 Then
          WrkAdj1st = WrkTax1st - WrkCredit
          WrkAdj2nd = WrkTax2nd
        Else
          WrkAdj1st = 0
          WrkAdj2nd = WrkTax2nd + WrkLeft
        End If
      End If
      If WrkCredit <> 0 Then
        strBuffer = Replace(strBuffer, WrkTax, WrkAdjTax, 1, CompareMethod.Text)
        strBuffer = Replace(strBuffer, WrkTax1st, WrkAdj1st, 1, CompareMethod.Text)
        strBuffer = Replace(strBuffer, WrkTax2nd, WrkAdj2nd, 1, CompareMethod.Text)
      End If
      sw.WriteLine(strBuffer & "," & WrkCredit)
    End With

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

CloseFiles:
    sw.Flush()
    sw.Close()
    myFrmProgress.Close()
    myTXINVTo.CloseFile()
  End Sub
End Module






