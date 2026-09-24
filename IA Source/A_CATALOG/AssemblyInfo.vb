' 4/ 1/19 Remove True Grid
' 1/29/20 Update FTP version, rework compare code due to sort is now different
'11/30/20 Change Rebex reference to any Verion
' 9/30/21 Change to show warning message at end instead of popup for each file in use
' 2/ 9/23 Add optional Debug parm for debug log (rebexlog.txt)
' 6/14/23 Update Rebex, Skip Rebex SFTP Dll
' 6/27/23 Change FTP Server and use TLS
' 3/ 5/24 Omit certain file groups to not install if not an active app
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("")> 
<Assembly: AssemblyProduct("")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("F12202D7-1FED-45F0-A97C-5ECCEE527EC9")> 

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
