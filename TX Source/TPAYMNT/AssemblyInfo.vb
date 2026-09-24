' 3/ 8/23 Add Option ED (EDU rate is 1st half, rest is 2nd half)
' 8/23/23 Add In_Nosbil to skip single bill calc when original 2nd/3rd/4th payment > 0
' 1/ 6/25 Change In_Nosbil logic to only trigger when flag is on
'MK 6/13/25 Restore backup code from 1/6 
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
<Assembly: Guid("33BE410E-63D7-4041-8703-D2DA587AD3AC")> 

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
