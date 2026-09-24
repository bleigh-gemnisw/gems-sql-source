'12/ 6/18 Check for numeric zip code 
' 4/ 1/19 Append suffix to name & second name
'11/15/21 Replace Loan Value (Q) with Sale Value (S)
'11/18/21 Delete TAXCOM records, Add error if first list# already in file on append
'12/22/21 Replace TXMVDCL2 with L1, only lookup by VIN & CustID
'10/24/22 Put back TXMVDCL2 code for Credit Vehicles only 
'11/21/22 Add missing getrecord in restore
' 2/ 9/23 Enable DMV Customer Only option
'12/12/24 Change value rounding to normal
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("TA502")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R. Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Install new Suppl MV File")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("484f7ed3-ef0c-4660-8412-e813ca9ac98a")> 

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
