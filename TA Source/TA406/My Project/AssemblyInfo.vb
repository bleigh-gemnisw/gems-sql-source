'12/10/18 Load pricing buffer on form load, add class to lookup
' 4/27/21 Replace TrueGrid
'10/ 4/24 Change pricing to use MSRP, add source
'10/16/24 Add PriceDigestAPI
'10/29/24 Enter Key in source does a save
'12/ 4/24 Check year matches to PriceDigest otherwise it's an error, Round value
'12/18/24 Edit on Source only when MSRP>0, write CAT=2 for Non Tax
'12/26/24 Get PriceDigest Specs if complete=Y then check the checkbox
' 1/ 2/25 Temporary: Hard Code depreciation year to 2024
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("TA406")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R. Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Unpriced Motor Vehicles")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("83c21443-838d-452a-b62a-6abfa3e5d571")> 

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
