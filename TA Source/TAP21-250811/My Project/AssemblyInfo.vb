' 8/27/20 Add Option to copy all records
' 8/19/22 Populate missing keys in all getonerecordp (some were blank or zero)
'11/21/22 Add missing getrecord (comments)
' 4/27/23 Inactive status keep it and FILSTS
'10/10/23 Don't copy Declaration to new year if there is no TXPPRP record
'         If TXDMSUM net is zero then don't write to summary code 13
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("TAP21")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("")> 
<Assembly: AssemblyProduct("Copy Tables to New Year")> 
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

