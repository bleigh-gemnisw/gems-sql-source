Imports System.Text
Module Main
  Public MyFrmGL102 As FrmGL102
  Public MyFrmGL102B As FrmGL102B
  Public MyFrmGL102C As FrmGL102C
  Public MyFrmListGLAcct As FrmListGLAcct
  Public MyFrmListGroup As FrmListGroup
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmGL102 = New FrmGL102
  Application.Run(MyFrmGL102)
  End Sub
Public Function BuildAcct(ByVal Fund As Integer, ByVal SFund As Integer, _
  ByVal Dept As Integer, ByVal Obj As Integer, ByVal Func As Integer, ByVal SFunc As Integer) As String
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
    sb.Append(Format(SFunc, "0000"))
  Else
    sb.Append(String.Empty)
  End If
  Return sb.ToString
End Function
End Module
