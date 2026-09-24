Imports System.io
Imports System.Text
Module Process
Dim myFrmProgress As FrmProgress
Dim WrkTotal As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myGLACCT As GLACCT.MyData
Public Sub ExportGLACCT()
 Dim ds As DataSet = New DataSet
 Dim sb As StringBuilder
 Dim sw As StreamWriter = New StreamWriter(MyFrmGL730B.LblFilePath.Text)
 Dim WrkQry As String
 Dim WrkSort As String
 Dim Counter As Integer
 Const cQuote As String = Chr(34)

 WrkQry = String.Empty
 WrkSort = String.Empty
 Counter = 0

 With MyFrmGL730B
 End With

 myGLACCT = New GLACCT.MyData()
 myGLACCT.MyDBConn = myDBConnect
 ds = myGLACCT.PosData(0, 0, 0, 0, 0, 0, 0)

 myFrmProgress = New FrmProgress
 myFrmProgress.Show()
 myFrmProgress.Refresh()
 Application.DoEvents()

'Write Headings
  sb = New StringBuilder
  sb.Append("Active?")
  sb.Append(",")
  sb.Append("Fund")
  sb.Append(",")
  sb.Append("SFund")
  sb.Append(",")
  sb.Append("Dept")
  sb.Append(",")
  sb.Append("Obj")
  sb.Append(",")
  sb.Append("Func")
  sb.Append(",")
  sb.Append("Sub Func")
  sb.Append(",")
  sb.Append("Descr")
  sb.Append(",")
  sb.Append("Type")
  sw.WriteLine(sb.ToString)

ReadNext:
For I = 0 To (ds.Tables(0).Rows.Count - 1)
  With ds.Tables(0).Rows(I)
   Counter = Counter + 1
   sb = New StringBuilder
   sb.Append(.Item("ACREC"))
   sb.Append(",")
   sb.Append(.Item("FDNBR"))
   sb.Append(",")
   sb.Append(.Item("SFUND"))
   sb.Append(",")
   sb.Append(.Item("DPNBR"))
   sb.Append(",")
   sb.Append(.Item("OBNBR"))
   sb.Append(",")
   sb.Append(.Item("FNPGM"))
   sb.Append(",")
   sb.Append(.Item("SUBFN"))
   sb.Append(",")
   sb.Append(cQuote)
   sb.Append(.Item("GLDSC"))
   sb.Append(cQuote)
   sb.Append(",")
   sb.Append(.Item("GLTYP"))
   sw.WriteLine(sb.ToString)
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
Next

sw.Close()
myFrmProgress.Close()
myGLACCT.CloseFile()
MsgBox(Counter & " records exported", MsgBoxStyle.Information, "Export is done")

End Sub
End Module
