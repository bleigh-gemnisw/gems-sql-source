'Restoring LEDGER (example)
' 1) delete from ledger & ledhst where fil045='GL802' and pstdt=20200630
' 2) INSERT INTO ledger SELECT * FROM led2020001
' 3) Delete led2020001

' 7/29/21 Post Ledger records with DateTo (Was today's date) and omit those records from delete
' 9/21/21 Fix Fund Balance to ledger
'10/ 5/22 Limit PRF to 10 chars
'10/24/22 Change Ledger Createfile Description to 30 chars
' 7/10/23 Change GLTYP to use GLACCT except for Revenue & Expense control is "Q"
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("GL802")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Close Out Revenues and Expenses")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("d537a7d0-0452-4923-a636-634cab943035")> 

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
