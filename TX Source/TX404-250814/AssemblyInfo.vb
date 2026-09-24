' 4/19/18 Change search by name to use Qryselect (SQL Performance)
' 4/26/18 Change query by name to handle single quotes for SQL Server
' 4/30/18 Add Mymsg parameter to Intent to Lien
' 5/07/18 Change search by name to use Qryselect for SQL only, move code before type query
' 9/19/18 Write Recid to history 
'10/30/18 Write Recid to history (Fees)
'11/15/22 Fix Issue with Next if all records are same (location)
'11/22/22 Handle single quote in search
' 8/ 4/23 Add Balance Dropdown, Change Select Year to Years, Show unposted flag 
' 8/17/23 Save Balance Dropdown selection
' 9/ 5/23 Unposted payment was not showing (Copy refreshds from TXA09)
' 1/21/25 Refreshds: check for ds isnothing
'MK 7/28/25 If SNAME has N/O then use SNAME instead of NAME and remove the N/O
'MK 8/13/25 Add option to remove MV Fee/Flag
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
<Assembly: AssemblyProduct("Online Statements")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("2D15CC46-F96F-42BB-9B1E-A54227CA7887")> 

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






