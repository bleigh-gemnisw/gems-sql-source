Imports System.Text
Module Main
  Public MyFrmGL801 As FrmGL801
  Public MyFrmGL801B As FrmGL801B
  Public MyFrmListGLAcct As FrmListGLAcct
  Public MyFrmListFund As FrmListFund
  Public MyBatch As String
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmGL801 = New FrmGL801
    Application.Run(MyFrmGL801)

   End Sub
Public Function BuildAcct(ByVal Fund As Integer, ByVal SFund As Integer, _
 ByVal Dept As Integer, ByVal Obj As Integer, ByVal Func As Integer, ByVal Subfn As Integer) As String
 Dim sb As StringBuilder = New StringBuilder

 If Fund > 0 Then
  sb.Append(Format(Fund, "000"))
  sb.Append(Format(SFund, "000"))
  sb.Append(Format(Dept, "0000"))
  sb.Append(Format(Obj, "000"))
  sb.Append(Format(Func, "0000"))
  sb.Append(Format(Subfn, "0000"))
 Else
  sb.Append(String.Empty)
 End If
 Return sb.ToString
End Function
Public Sub BreakAcct(ByVal In_Acct As Double, ByRef Out_Fund As Integer, ByRef Out_SFund As Integer, ByRef Out_Dept As Integer, _
 ByRef Out_Obj As Integer, ByRef Out_Func As Integer, ByRef Out_Subfn As Integer)
 Dim sb As StringBuilder = New StringBuilder
 Dim WrkAcct As String
 Dim WrkLen As Integer
 Dim WrkStr As Integer

 WrkAcct = Format(In_Acct, "#####################")
 Select Case Len(WrkAcct)
 Case 19
  WrkLen = 1
 Case 20
  WrkLen = 2
 Case 21
  WrkLen = 3
 End Select
 Out_Fund = Mid(WrkAcct, 1, WrkLen)
 WrkStr = 1 + WrkLen
 Out_SFund = Mid(WrkAcct, WrkStr, 3)
 WrkStr = WrkStr + 3
 Out_Dept = Mid(WrkAcct, WrkStr, 4)
 WrkStr = WrkStr + 4
 Out_Obj = Mid(WrkAcct, WrkStr, 3)
 WrkStr = WrkStr + 3
 Out_Func = Mid(WrkAcct, WrkStr, 4)
 WrkStr = WrkStr + 4
 Out_Subfn = Mid(WrkAcct, WrkStr, 4)
End Sub
End Module
