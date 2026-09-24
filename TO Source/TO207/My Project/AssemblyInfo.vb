' 7/05/18 Remove edit check for Frozen List # not found
' 7/11/18 Add M59A OPM form
' 1/ 8/19 If no millrate write out 0 (XML file)
' 7/15/20 Include waivered amount in payment split
' 8/ 3/22 Include XLOCAL with XADDL (Was XADDL)
' 7/18/23 Add M59a message to screen
' 7/25/23 Change Glyear to ._YEAR in CalcTaxLoss for Suppl MV
' 7/26/23 Milford: XADDL includes XLOCAL, other towns don't include XLOCAL
' 9/ 4/24 Add TYpe to report and add report sort
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("TO207")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Create M59A OPM File")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("5568f2ff-06dd-45c4-9f8c-ae5b423a4f1a")> 

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
