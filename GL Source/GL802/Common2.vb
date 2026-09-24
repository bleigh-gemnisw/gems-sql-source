Module Common2
  Dim myGLFUND As GLFUND.MyData
  Dim myGLACCT As GLACCT.MyData
  Public Sub InitFiles()
    myGLFUND = New GLFUND.MyData()
    myGLFUND.MyDBConn = myDBConnect
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
  End Sub
  Public Function GetFundDesc(ByVal Fund As Integer) As String
    myGLFUND.GetOneRecordP(Fund, 0)
    If Not myGLFUND.RecordNotFound Then
      GetFundDesc = Format(Fund, "000") & " " & Trim(myGLFUND._FNDSC)
    Else
      GetFundDesc = "*** Unknown ***"
    End If
    Return GetFundDesc
  End Function
  Public Function GetAcctDesc(ByVal Fund As Integer, ByVal Dept As Integer, ByVal Obj As Integer,
    ByVal Func As Integer, Sfunc As Integer) As String
    myGLACCT.GetOneRecordP(Fund, 0, Dept, Obj, Func, Sfunc)
    If Not myGLACCT.RecordNotFound Then
      GetAcctDesc = Trim(myGLACCT._GLDSC)
    Else
      GetAcctDesc = "*** Unknown ***"
    End If
    Return GetAcctDesc
  End Function
  Public Function GetGlTypDesc(ByVal GlType As String) As String
    Dim WrkDesc As String
    WrkDesc = ""
    Select Case GlType
      Case "A"
        WrkDesc = "ASSETS"
      Case "L"
        WrkDesc = "LIABILITY"
      Case "Q"
        WrkDesc = "EQUITY"
    End Select
    Return WrkDesc
  End Function

End Module
