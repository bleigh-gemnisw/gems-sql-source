' 2/ 6/20 Delete check LEDGER activity (was GLACCT)
' 8/31/20 DAP: Change PO to read ponbr (was refno)
' 9 /3/20 Replace True Grid
' 9/24/20 Hide PO number when 0
' 9/30/20 Add PO related entries Screen
'10/ 6/20 Zero Supress refno
'12/14/20 Add views and screens for PR & TX
' 5/10/21 Add Debit/Credit totals on AR & AP
' 7/21/21 Change PO lookup to ponbr (was refno)
' 8/ 2/21 Add Current/History Selection
'10/13/21 Flip Credit and Debit Columns, Show Batch on JE 
' 2/22/22 Add Edit: Quotes not allowed in Description
' 6/10/22 Check security for app groupd FI
' 6/23/22 Validate user permission in DEPSEC 
' 12/13/23 filter depts for only secure to 
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("GL107")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Maintain/Inquiry G/L Accounts")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("cf96d1df-ef8b-456e-beb9-670cdf18b98e")> 

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
