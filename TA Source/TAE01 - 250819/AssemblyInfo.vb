' 8/11/20 Prevent crash when no mill rate if is found 
' 5/ 5/21 Add Exempt to Taxable option
' 8/30/22 Add reports fields for Coventry, Add TXOPM for Phone
'11/ 1/22 Change GetAddr to only use TXREAL (was using Frozen checkbox)
'11/22/22 Handle single quote in search
' 3/28/23 Control Record PXRND=Y for rounding Pro-Rate Increment to 10
' 7/11/23 Add Search by Second Name
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("")> 
<Assembly: AssemblyDescription("")>
<Assembly: AssemblyCompany("Gemni Software")>
<Assembly: AssemblyProduct("Maintain Pro Rates")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("4663BEFF-D3DC-4CE6-A67E-38CC7CACF6DC")> 

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
