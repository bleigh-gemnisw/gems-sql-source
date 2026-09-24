'10/21/21 Fix bad negative amounts (All except Expenses)
' 1/ 5/22 Don't omit Budgets from detail
' 1/11/22 For source code 1, Change Description to use APEHST DSCTX field
' 2/ 1/22 Add Lookups for Object and Function
' 2/ 7/22 Change GetAPDescr to return description (was dataset)
' 8/31/22 Change reports from scrde to source (description)
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("GL205")> 
<Assembly: AssemblyDescription("")>
<Assembly: AssemblyCompany("R Walsh Associates, Inc.")>
<Assembly: AssemblyProduct("Print Detail Ledger by Acct")>
<Assembly: AssemblyCopyright("")>
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("13a881d0-1abc-4f35-ae98-6ea4db1a8490")>

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
