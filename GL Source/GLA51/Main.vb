Imports System.Text
Module Main
  Public MyFrmGLA51 As FrmGLA51
  Public MyFrmGLA51B As FrmGLA51B
  Public MyFrmGLA51C As FrmGLA51C
  Public MyFrmListGLAcct As FrmListGLAcct
  Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmGLA51 = New FrmGLA51
    Application.Run(MyFrmGLA51)
   End Sub
 Public Function GetGLACCTDesc(ByVal PFund As Integer, ByVal PSubFund As Integer, _
  ByVal PDept As Integer, ByVal PObject As Integer, ByVal PFunction As Integer, _
  ByVal PSubFunc As Integer) As String
   Dim myGLACCT As GLACCT.MyData

    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
    If PFund = 0 Then
    Return ""
   End If

   myGLACCT.GetOneRecordP(PFund, PSubFund, PDept, PObject, PFunction, PSubFunc)
   If Not myGLACCT.RecordNotFound Then
    GetGLACCTDesc = Trim(myGLACCT._GLDSC)
   Else
    GetGLACCTDesc = "*** Unknown ***"
   End If
   Return GetGLACCTDesc

 End Function
Public Function BuildAcct(ByVal Fund As Integer, ByVal SFund As Integer, ByVal Dept As Integer, ByVal Obj As Integer, _
 ByVal Func As Integer, ByVal Subfn As Integer) As String
 Dim sb As StringBuilder = New StringBuilder

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
 Return sb.ToString
End Function
End Module
