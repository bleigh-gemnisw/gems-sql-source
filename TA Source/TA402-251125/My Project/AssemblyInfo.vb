'12/ 6/18 Check for numeric zip code 
'12/18/18 Fix Residential Zip4 logic
' 4/ 1/19 Append suffix to name & second name
' 3/10/21 Write to LOC# and LOC fields
'11/15/21 Replace Loan Value (Q) with Sale Value (S)
'11/18/21 Delete TAXCOM records, Add error if first list# already in file on append
'11/21/22 Add missing getrecord in restore
' 1/12/12 Change comment clear to M (was S)
'10/28/24 Use MSRP Depreciation to calculate value, Add NonTaxable Category=2, Remove Pricing option, Change Min Value to read only
'12/12/24 Change value rounding to normal
' 1/ 2/25 Temporary: Hard Code depreciation year to 2024
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("TA402")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R. Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Install new MVD File")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("a424fbfa-8d71-4c13-9d52-3698bc82bb74")> 

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
