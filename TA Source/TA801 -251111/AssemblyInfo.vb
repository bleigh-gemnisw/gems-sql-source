'10/29/18 Change before bill previous years to look at archive file
' 1/10/19 Add UserID option
' 4/27/21 Replace TrueGrid
'10/27/21 Handle before bills done after bills were posted (make them 0) 
' 9/ 6/22 Change lookup to show error if less than 0 (was less than 1)
'11/11/22 Add BeforeYear to screen, default to TXCNTL Year
' 3/ 1/23 Add Sort by CCNo
' 6/ 5/23 Add Control Record CCRND Logic
' 12/16/24  increase size of  cdesc from 25 to 50    move desc down a lien to  fit
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
<Assembly: AssemblyProduct("C/C Register")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("D935C7F3-E739-4807-809B-1CBC6BD55475")> 

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






