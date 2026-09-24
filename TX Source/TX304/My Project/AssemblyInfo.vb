' 3/13/18 Add Select Status
' 3/15/18 Add Msg to Lien Notices
' 9/19/18 Write Recid to history
' 7/24/23 Change to getqry, use datarow to populate TXINVQ properties. Select Multiple Types.
' 4/ 1/24 Trim PP Description
' 5/ 1/24 If SNAME has N/O then use SNAME instead of NAME and remove the N/O
' 5/ 6/24 Back out 5/1 change
'3/17/25 - change sort by name sortdata to be name / list#
'7/2/25 - kb - use defert instead of bald if icode = D    
'  TBD    revisit change to look at defer amount instead of bald>0
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("TX304")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R. Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Print Liens, Etc.")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("584effaa-8b08-4e35-9603-b21ae7b126bb")> 

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

