Imports System.Text
Module Main
  Public MyFrmAP101 As FrmAP101
  Public MyFrmAP101B As FrmAP101B
  Public MyFrmAP101C As FrmAP101C
  Public MyFrmAP101D As FrmAP101D
  Public MyFrmAP101E As FrmAP101E
  Public MyFrmListGLAcct As FrmListGLAcct
  Public MyFrmListVENCAT As FrmListVENCAT
  Public MyFrmComments As FrmComments
  Public myFromDate As Date
  Public myToDate As Date
  Public MyInquiryMode As Boolean
  Sub Main()
    Dim TestCmd() As String
    StartUp()

    MyInquiryMode = False
    TestCmd = GetCommandLineArgs()
    If UBound(TestCmd) > 1 Then
      If UCase(TestCmd(2)) = "INQUIRY" Then
        MyInquiryMode = True
      End If
    End If

    GetSecurity("", False)
    If InStr(s_rights, "FI") <= 0 Or Not MyInquiryMode Then
      GetSecurity()
    End If
    If MyInquiryMode Then
      s_full = False
      s_add = False
      s_edit = False
      s_del = False
    End If

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmAP101 = New FrmAP101
    Application.Run(MyFrmAP101)
   End Sub
 Public Function GetGLACCTDesc(ByVal PFund As Integer, ByVal PSubFund As Integer, _
  ByVal PDept As Integer, ByVal PObject As Integer, ByVal PFunction As Integer, _
  ByVal PSubFunc As Integer) As String
   Dim myGLACCT As GLACCT.myData

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
