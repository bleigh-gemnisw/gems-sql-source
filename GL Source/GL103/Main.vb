Imports System.Text
Module Main
  Public MyFrmGL103 As FrmGL103
  Public MyFrmGL103B As FrmGL103B
  Public MyFrmGL103C As FrmGL103C
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmGL103 = New FrmGL103
  Application.Run(MyFrmGL103)
  End Sub
End Module
