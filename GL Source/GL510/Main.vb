Imports System.Text
Module Main
  Public MyFrmGL510 As FrmGL510
  Public MyFrmGL510B As FrmGL510B
  Public MyFrmListFund As FrmListFund
  Public MyBatch As String
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmGL510 = New FrmGL510
    Application.Run(MyFrmGL510)

   End Sub
Public Function BuildAcct(ByVal Fund As Integer, ByVal SFund As Integer, _
 ByVal Dept As Integer, ByVal Obj As Integer, ByVal Func As Integer, ByVal Subfn As Integer) As String
 Dim sb As StringBuilder = New StringBuilder

 If Fund > 0 Then
  sb.Append(Format(Fund, "000"))
  sb.Append("-")
  sb.Append(Format(SFund, "000"))
  sb.Append("-")
  sb.Append(Format(Dept, "0000"))
  sb.Append("-")
  sb.Append(Format(Obj, "000"))
  sb.Append("-")
  sb.Append(Format(Func, "0000"))
  sb.Append("-")
  sb.Append(Format(Subfn, "0000"))
 Else
  sb.Append(String.Empty)
 End If
 Return sb.ToString
End Function
End Module
