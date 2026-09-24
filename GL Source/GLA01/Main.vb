Imports System.Text
Module Main
  Public MyCRViewer As FrmCrViewer
  Public MyFrmGLA01 As FrmGLA01
	Public MyFrmGLA01B As FrmGLA01B
	Public MyFrmGLA01C As FrmGLA01C
	Public MyFrmListGLAcct As FrmListGLAcct
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmGLA01 = New FrmGLA01
  Application.Run(MyFrmGLA01)
  Exit Sub

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
