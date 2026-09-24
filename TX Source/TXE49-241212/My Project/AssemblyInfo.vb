' 4/30/18 Change logic to Second name is N/O (Name cannot be changed)
' 7/30/19 Add Name/Address update for UB Types (UTCUST)
' 8/24/20 Change logic to update address if any part of name & address not the same
' 5/19/21 If names are different check if second names match at same address then skip (handle N/O)
' 2/22/22 Fix Back Button from ListTypes
' 5/ 3/23 Change to getqry, use datarow to populate TXINVQ properties
' 5/10/23 UB Types: If names are different check if second names match at same address then skip (handle N/O) 
' 7/25/24 UB Types: Handle blank zip code
'12/ 5/24 Also check second name to skip on exact match
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("TXE49")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("")> 
<Assembly: AssemblyProduct("Update Tax Invoice Names/Address")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: ComVisible(False)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("cf96d1df-ef8b-456e-beb9-670cdf18b98e")> 

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
