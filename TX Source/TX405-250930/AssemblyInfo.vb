' 4/19/18 Change search by name to use Qryselect also (SQL Performance)
' 4/26/18 Change query by name to handle single quotes for SQL Server
' 5/07/18 Change search by name to use Qryselect for SQL only, move code before type query
'11/28/18 Add process selected items
' 9/12/19 Fix Bond & Bond Paid load & save
' 3/ 3/21 Parse List#, check for full account then fast path it
' 4/13/21 Change all searches to dropdowns, add list# & type search
'11/15/22 Fix Issue with Next if all records are same (location)
'11/22/22 Handle single quote in all searches
'11/23/22 Don't clear name when clicking Find or Next 
' 3/14/23 Make List# 7 digits
' 8/ 4/23 Add Balance Dropdown, Change Select Year to Years, Show unposted flag 
' 7/25/24 Add Defer fields
' 10/1/24 add hyper link table look up for bank code and bank service
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R. Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Tax Invoice Maintainence")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("AA4252BA-9057-43CA-A256-B71A23A51854")> 

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






