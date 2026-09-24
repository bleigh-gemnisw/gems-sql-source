'10/22/18 Change Control File format
' 1/23/19 Change TXINV GLyear to previous year
' 2/20/20 Add name & sname to print for Milford PP 
' 2/24/20 Add control file NOCAM, skip if no CAMA record is found
'10/28/21 Add Reval option & form
' 6/29/22 Default to Show Exemptions
' 2/23/24 Add Print Date and Meets in month to screen and report
' 7/10/24 add option to use RE archive  looks at txrealc and txreaa   also filters out for CC reason code
' 3/20/25 Add option for Personal Property Code, if entered then only print accounts that have that code
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("TA205")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R. Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Change of Assessment Notices")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("a5994719-a45c-4a8d-8173-a789e42cc34c")> 

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
