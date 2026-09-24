' 4/23/18 Add PO Select Range
' 8/ 3/21 Fix No Row 1 error
' 5/19/22 Show Detail or A/P Payments
' 6/10/22 Check security for app groupd FI
' 8/ 4/22 ListLoc: Replace TrueGrid, Fix Location Selection
' 8/22/22 Replace RACTD with RENTD
' 3/20/23 Inquiry mode can Print PO's, save year in settings
' 3/23/23 Print Detail/Payments when on detail screen
'12/ 7/23 Add PO Changed by 
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("PO306")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R. Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Print/Inquiry Purchase Orders")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("2dded839-bd4c-4613-8482-295d48f2cba8")> 

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
