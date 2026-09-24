' 9/14/18 Enable UB option 
' 9/16/19 Split City/ST in Create UB File
' 9/27/19 Allow for 1 postion off in import file (UB)
'11/12/19 Change Create File format
'12/ 2/19 Remove leading 0's from list# (Create File)
'12/ 3/19 Change list# to 5 with leading 0 (Create File)
' 9/29/20 Adjust recieve file positions 
' 1/27/22 Change StreamReader to access as read
'MK 7/17/25 Skip Inactive Accounts 
'MK 7/22/26 Add Sump Pump option
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("UB302")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("")> 
<Assembly: AssemblyProduct("Interface to CompuTel")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("1e5bb808-55e3-48a6-accc-80fca01dcb6a")> 

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

