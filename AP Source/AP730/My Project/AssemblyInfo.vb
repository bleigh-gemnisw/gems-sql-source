' 1/13/21 Change A record to NEC, B record to NEC: blanks 
' 1/26/21 Show error on invalid Vendor Address, Change A record to Code 1, Change B record to amount 1
' 1/28/21 Zero fill 9 digits TIN field
' 1/21/22 Add B record H & J amounts, move payee name 
' 5/16/22 Add option for resubmit
' 1/26/23 If NEC checked then NEC records otherwise Misc records
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("AP730")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("")>
<Assembly: AssemblyProduct("Create IRSTAX File")>
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
