' 7/22/19 Create Detail report
' 6/ 8/23 Trim spaces on Exemption codes
'10/11/23 Add report Summary Accounts
'6/24/25  kb  onfilter of exempt codes set some to true that are now vet .. see FilterCodes function
'MK 6/26/25 Add BJE
'MK 7/14/25 Change totals group 1 to A & C, Group 2 to B
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("TO120")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R. Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("OPM: DVA Veterans Exemptions File")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("ac7c4f96-5cdf-47c6-a246-66d57743b14b")> 

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
