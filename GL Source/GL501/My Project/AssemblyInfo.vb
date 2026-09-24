'10/20/20 Only update Budget amount if record is found
' 6/ 3/21 Delete Budget by fund then add records from glacct 
' 8/10/21 Change calc so that Expense Debit and Revenue Credit adds and opposite subtracts
'12/14/21 Fix GLACCTQ Reader interfering with LEDGERQ Reader (No budgets got written), Read History or LEDGER file, Repace CurrYear calc
'12/21/21 Change amount to decimal then round when writing to budget file
' 4/17/23 Add 4 & 5 years ago
' 6/30/23 On Add Set Dcode & Rev to blank
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("GL501")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Generate Budget File for New Year")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("6fd6df46-4420-4b54-ba6d-71bc5981ddc2")> 

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
