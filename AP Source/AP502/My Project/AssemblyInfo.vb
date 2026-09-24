' 9/15/20 Truncate vendor name to 15 for void (was over 20). Escape single quotes.
' 9/22/20 Cleanup void code and show report before posting
'11/ 3/21 Void: Hide check date on screen, Fix Posting date on report, Fix APEHST update syntax, To Check is optional 
'11/16/21 Write log if LEDGER file error
'11/17/21 Control accounts set fil10=9999999999
'12/ 1/21 Always write cash account (was only X & R)
'10/ 5/22 Limit PRF to 10 chars
' 1/17/23 Handle Void with Credit Memos
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("AP502")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Void Checks")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("80667a0a-d240-4760-a32e-437fb53d0c03")> 

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
