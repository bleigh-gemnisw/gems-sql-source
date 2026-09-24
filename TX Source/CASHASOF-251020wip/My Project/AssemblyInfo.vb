'10/26/21 MV/SU: always use C/C add date 
' 7/23/24 Add Defer fields and use them if active (ICODE=D)
'11/18/24 Add code for missing C/C's (No record)
'MK 9/ 4/25 Check CCINT30 for a due date
'MK 10/2/25 Add deferred expired (ICODE="E")
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("CASHASOF")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("RWA")> 
<Assembly: AssemblyProduct("CASHASOF")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("8f8fe61c-5fc7-4013-9304-ae1e66867292")> 

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

