' 5/16/18 Change property description to 30 chars
' 1/29/19 If WEBNP control file=Y then write non public to different csv
' 3/11/19 Set timeout to 900 (15 minutes) 
' 3/27/19 Change: If WEBNP control file=Y then write 0 to townbr field
'12/ 2/19 Add Gross,Exam,Net,Eldben,Twnben to csv
' 1/21/20 Add Collection Agency status & message, Add LienMsg to csv.
' 1/29/20 Update FTP Version
' 3/13/20 Add security protocol to runscript
' 3/16/20 Add ability to process Secondary FTP
' 3/23/20 Change userid seperator from @ to +
'10/ 1/20 Non Public: use same query as regular, filter if control flag WEBNP=N
'10 /5/20 Change BuildSelectQryPC to use TYPE IN instead of OR's
'12/ 2/20 Add ProductID to export file from TXPAYID file
' 3/24/21 Change to use passive mode
' 3/25/21 FTP mode: Load webtown if blank
' 4/ 7/21 Don't write leading spaces in loc# to csv
' 6/ 1/20 Put Location number back to right justified
' 8/17/21 Add Codes-Non Public option (restored 9/28)
' 5/ 9/22 Add StripChars to remove bad chars
' 6/14/23 Recompile for Rebex update
' 4/25/24 Change TLS to allow any version
' 7/ 2/24 If Lien Message is blank then make it Blocked instead of Liened
'11/27/24 Make Collection Agency Blocked (was Liened)
' 1/10/25 Change FTP password
' 3/13/25 MV/Suppl: Don't write address lines to file
' 3/25/25 Include Non Public records in Grace Period 
' 6/ 4/25 Mv/Suppl: Don't write location to file
'MK 2/20/26 Include Deferred records
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("TX830")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R. Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Create Tax Payment History (WEBHIST)")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("6099f763-57ed-4786-a2d3-6ffdc8061184")> 

' Version information for an assembly consists of the following four values:
'
'      Major Version
'      Minor Version 
'      Build Number
'      Revision
'
' You can specify all the values or you can default the Build and Revision Numbers 
' by using the '*' as shown below:
<Assembly: AssemblyVersion("1.0.*")> 
