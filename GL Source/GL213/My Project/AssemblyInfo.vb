' 3/ 8/18 Add Optional CSV File
' 6/ 6/19 Add Expended Detail report
'11/20/19 Add optiional all data csv format
' 4/13/20 Fix History Revenue credits to be negative, Change report sort to account number
' 9/28/20 Add keypress filter for account from/to fields
'10/20/20 Add option for Source 6
' 4/ 7/21 Fix typo "A P P R O P R I A T I O N"
' 5/11/21 Add sort Refno at end
' 1/ 5/22 Don't omit Budgets from detail, Change revenue to match GL205
' 1/11/22 For source code 1, Change Description to use APEHST DSCTX field
' 2/ 1/22 Add Lookups for Object and Function
' 2/ 7/22 Change GetAPDescr to return description, Add option for A/P Transactions: Description or Vendor
' 8/31/22 Change reports from scrde to source (description)
'11/ 8/22 Add option to select an account
' 3/14/23 Expended Detail Report: Vendor Name or Vendor Name & Description 
' 6/12/23 Change sort to match as/400
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("GL213")>
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R. Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Print Detail Ledger by Acct/Dept")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("fd786463-c5e8-45fa-a078-27cde0b76c9f")> 

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
