Module Main
    Public MyFrmDMV As FrmDMV
    Public MyFrmDMVB As FrmDMVB
    Public MyCrViewer As FrmCrViewer
    Public DataPath As String
    'Needed to compile only
    Public MyUserId As String
    Public s_rights As Boolean

   Sub Main()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmDMV = New FrmDMV
    Application.Run(MyFrmDMV)
   End Sub
End Module
