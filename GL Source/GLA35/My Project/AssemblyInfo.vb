' 1/15/21 Form B: Change post date to Int32 (Was datetime)
' 2/ 8/21 Change post ledger file to MSCBCHL1 (Was MSCBCH), Alpha sort fields.
' 4/14/21 Add Error if Quote entered in Description
' 4/15/21 Write log on LEDGER file error
' 8/19/21 Fix Print edits when enter key pressed (was any key)
'10/13/21 Flip Debit/Credit, Replace TrueGrid, Disable New When closing batch
' 1/27/22 Change StreamReader to access as read
' 2/ 3/22 Change Description to 30 Chars
'10/ 5/22 Limit PRF to 10 chars
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("GLA35")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("")> 
<Assembly: AssemblyProduct("GLA35")> 
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
