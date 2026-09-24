' 1/ 2/19 Add Archive file option, set G/L year from Control File
' 1/28/19 Change Margins to apply to Portrait also
' 2/ 5/19 Populate dropdown on form load
'11/20/19 Add negative gross for mv types to error report
'11/20/19 Only count taxable in total record count 
' 5/17/21 Set WrkDistAll to false (refresh issue)
' 8/19/21 Fix Print edits when enter key pressed (was any key)
'10/13/21 Omit Transfers (MV/SU)
' 1/ 9/23 Trim exemption code when checking for blank
'11/13/24 Omit MV Category 2 (Non Taxable) records
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
<Assembly: AssemblyProduct("Print Grand List")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("54BA2C8B-BF92-4E0F-9AE5-44835CE8489C")> 

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






