Imports System.Collections.Generic
Imports System.IO
Imports System.Text

Module PrintTakeOffs

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer

  Public ds As DataSet = New DataSet
  Dim sw As StreamWriter
  Dim dr As Data.DataRow
  Public Sub PrtTakeOffs()

    With MyFrmTX407B
    End With

    If ds.Tables.Count = 0 Then
      BuildDs(ds)
      InitCASHDUE()
    Else
      ds.Clear()
    End If

    GetDetail()
  End Sub
  Private Sub GetDetail()
    Dim WrkStream As FileStream = New FileStream(MyFrmTX407B.LblCSVPath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim myFrmProgress As FrmProgress
    Dim WrkCustID As Long
    Dim WrkVehID As Long
    Dim WrkLease As String
    Dim WrkTown As Integer
    Dim WrkPct As Integer
    Dim SavePct As Integer
    Dim WrkFileSize As Integer
    Dim StrBuffer As String
    Dim Sarray As String()
    Dim I As Integer
    Dim Counter As Integer

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()
    Counter = 0
    WrkFileSize = WrkStream.Length
    StrBuffer = sr.ReadLine
    sw = New StreamWriter(MyFrmTX407B.LblFilePath.Text)

NextLine:
    StrBuffer = sr.ReadLine
    If Trim(StrBuffer) = String.Empty Then
      GoTo CloseFile
    End If
    I = I + StrBuffer.Length
    Sarray = Parse(StrBuffer, ",")
    WrkCustID = MyUtils.CnvSng(Sarray(2))
    WrkLease = Sarray(3)
    WrkVehID = MyUtils.CnvSng(Sarray(4))
    WrkTown = MyUtils.CnvSng(Sarray(5))
    WriteLine(WrkCustID, WrkVehID, WrkLease, WrkTown)

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

CloseFile:
    sr.Close()
    sw.Close()
    myFrmProgress.Close()
  End Sub

  Private Sub WriteLine(ByVal WrkCustID As Long, WrkVehID As Long, WrkLease As String, ByVal WrkTown As Integer)
    Dim sb As StringBuilder
    sb = Nothing
    sb = New StringBuilder
    sb.Append(Date.Today.Year)
    sb.Append(Format(Date.Today.Month, "00"))
    sb.Append(Format(Date.Today.Day, "00"))
    sb.Append("D") 'Delete
    sb.Append(Format(WrkCustID, "0000000000"))
    sb.Append(WrkLease)
    sb.Append(Format(WrkVehID, "000000000"))
    sb.Append(Format(WrkTown, "000"))
    sw.WriteLine(sb.ToString)
  End Sub
End Module
