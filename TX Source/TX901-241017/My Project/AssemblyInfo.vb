' 8/19/21 Fix Print edits when enter key pressed (was any key)
' 9/ 1/21 Show error if no balance, post balance due to history (was amount in batch)
'11/ 2/21 Add suspense amount to reports, no balance is not an error, count is suspended accounts
'11/ 3/22 Fix no error if code is blank
'11/15/22 Fix Issue with Next if all records are same (location)
' 5/17/24 Add address lines to Report C
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("TX901")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R. Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Maintain Suspense Batches")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("4cb2b7ee-fb11-43eb-a36f-5aecdc1da025")> 

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





