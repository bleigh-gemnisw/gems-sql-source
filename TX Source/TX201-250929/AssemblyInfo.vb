' 6/20/18 Clear Waivered Totals
' 6/ 7/19 Create C/C Detail report
' 8/19/21 Fix Print edits when enter key pressed (was any key)
' 6/ 5/23 Add Control Record CCRND logic
' 9/19/23 Add txcntl grand list year. Get gl year from there, lock field so it cannot be changed
' 11/3/23 add logic for supple t oMinus 1 from GL year if month >=7  and stick not on screen on running for current GLyear
' 6/11/24 Change Skip Category from =3 to <>1
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R. Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Print Ratebooks")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("7A1E7A86-C34C-4953-A04C-B83FBD493F1A")> 

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






