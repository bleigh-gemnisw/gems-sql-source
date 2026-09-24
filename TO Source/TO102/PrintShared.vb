Imports System.Text
Module PrintShared
'Global
Public WrkAddress As String
Public WrkTownZip As String
Public WrkPhone As String
Public WrkFax As String
Public WrkEmail As String
Public WrkAssrName As String
Public WrkCertYes As String
Public WrkCertNo As String
Public WrkCert As String

Public Sub GetOPMAssr()
  Dim myTXOPM As TXOPM.myData
  Dim sb As StringBuilder = New StringBuilder

  myTXOPM = New TXOPM.mydata(MyDBConnect)
  WrkAddress = ""
  WrkTownZip = ""
  WrkPhone = ""
  WrkFax = ""
  WrkEmail = ""
  WrkAssrName = ""
  WrkCertYes = ""
  WrkCertNo = ""
  WrkCert = ""

  myTXOPM.GetOneRecordP("A")
  If myTXOPM.RecordNotFound Then Exit Sub

  If myTXOPM._PHONE > 0 Then
    WrkPhone = Format(myTXOPM._PHONE, "(###)###-####")
    If myTXOPM._PHONEX > 0 Then
      WrkPhone = WrkPhone & " ext " & myTXOPM._PHONEX
    End If
  End If

  WrkAddress = myTXOPM._ADDR1
  sb.Append(Trim(myTXOPM._CITY))
  sb.Append(",")
  sb.Append(Trim(myTXOPM._STATE))
  sb.Append(" ")
  sb.Append(Format(myTXOPM._ZIP, "00000"))
  If myTXOPM._ZIP4 > 0 Then
    sb.Append("-")
    sb.Append(Format(myTXOPM._ZIP4, "0000"))
  End If
  WrkTownZip = sb.ToString
  sb = Nothing
  If myTXOPM._FAX > 0 Then
    WrkFax = Format(myTXOPM._FAX, "(###)###-####")
  End If
  WrkEmail = myTXOPM._EMAIL
	WrkAssrName = Trim(myTOWN._ASSR)
  If Trim(myTXOPM._CERT) <> String.Empty Then
    WrkCertYes = "X"
    WrkCert = myTXOPM._CERT
  Else
    WrkCertNo = "X"
  End If
End Sub

End Module






