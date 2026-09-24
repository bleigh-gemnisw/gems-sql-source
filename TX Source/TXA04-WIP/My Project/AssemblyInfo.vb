' 2/ 4/21 Add CASHINT code to split payment (Principal/Interest/Fees/Liens)
' 1/26/22 Handle Fees (Copy code from TXA08) 
'12/19/22 Truncate Bank name to 20
' 5/11/23 Add Control Record LIST7 for 7 digit list#
' 7/18/23 Change Bank Array from 100 to 500, Check a 2nd position in file if bank is blank
' 8/28/23 Add Interest Date
'MK 6/17/25 Change to Async processing. Change TCRBCH write to insert records.
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("TXA04")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R. Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Load Bank Services")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("f5d90398-248e-43aa-ad6c-ed03fc9eb295")> 

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
