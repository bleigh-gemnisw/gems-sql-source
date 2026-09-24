' 9/ 2/20 Change query Recno=0 (was <>0)
' 9/ 8/20 Hide From and To Fund (for phase 2)
' 9/16/20 Update VendorL1 for Suspended (False), Hide Fund From & To (report), 
'         Add sort option, Add Show address option, Omit Voids
' 6/15/21 Replace TrueGrid
' 5/31/22 Add option to Include Voids
' 6/23/22 ListVendor: Add Vendor address fields to datagrid
' 8/ 1/22 ListVendor: Hide susp column
'7/17/24 increase vendor name to 40
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("AP312")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Print Vendor Summary")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("740a2aa1-09e6-4325-b998-98f2724e2bce")> 

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

