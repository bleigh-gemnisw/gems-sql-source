' 9/18/19 Add "Annual or" to 1st reading (screen change)
' 1/27/22 Change StreamReader to access as read
'12/12/22 Add CT Water 
' 1/24/23 Add to Duplicate Meter numbers in Meter Detail file
' 2/14/23 Add Option to Recalc EDU
' 5/ 8/24 Norfolk: Add Other format 
' 6/ 6/24 Norfolk: Add to error report when meter number is MULTIPLE (0)
'9/25/24 ProcAcct: If no Xref then check meter number in customer file
'MK 5/15/25 Norfolk: Use Customer number then if not found in UTXREF then use Meter Number 
'MK 7/17/25 Skip Inactive Accounts 
'MK 6/10/26 Norfolk: Only use UTXREF don't look at meter number
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("UB306")> 
<Assembly: AssemblyDescription("")>
<Assembly: AssemblyCompany("")>
<Assembly: AssemblyProduct("Get Meter/Usage Readings")>
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("313ff7d8-651e-473f-b9c1-78a92c6c891a")> 

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
