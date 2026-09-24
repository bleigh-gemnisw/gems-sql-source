' 8/23/18 Add Omit Status Codes option
' 9/19/18 Write Recid to history
' 7/ 1/21 Change query TXINVQ to update, Change BuildSelectQryPC
' 3/20/23 Change to getqry, use datarow to populate TXINVQ properties
' 4/18/24 Fix blank year and description on totals report
' 4/23/24 Add sort, change add to insert 
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("TX406")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R. Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Purge Tax Invoice Accounts")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("f6837fa0-4c28-497c-974a-d4a37a245ac3")> 

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