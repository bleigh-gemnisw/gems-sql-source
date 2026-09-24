' 5/01/18 Add Delinquent List (Location) option
' 5/09/18 Add Omit Amount Above
' 9/19/18 Write Recid to history
'10/31/18 Rearrange screen, Add sortby Name/DOB
' 1/23/19 Add option Omit Bank Coded 
' 8/ 9/23 Change OpenQry to GetQry
' 1/ 3/24 If SNAME has N/O then use SNAME instead of NAME and remove the N/O
' 6/10/24 Replace N/O should include a space also
' 6/20/24 Add report balance due for UB  (norfolk request from kim)
' 8/ 8/24 If SNAME has N/O at end then use SNAME instead of NAME and remove the N/O
'12/12/24 Winchester: Add Omit totals bills below
' 1/22/25 Winchester: Omit totals below now works for any sort
' 2/ 4/25 comment out: 12/26/24 add listno to sort zip 
' 2/14/25 comment out: 12/26/24 add listno to sort name 
' 4/ 4/25 Kensington: Add Omit Total Interest below 
'MK 5/27/25 Kensington: Combine types and is interest based on total (statements/UB balance Due)
'MK 7/ 7/25 Kensington: Use logic from Cash register to calc interest based on both S & W 
'MK 7/30/25 Report8 filter out zero due lines
'MK 9/11/25 Rewrite CalcInterest_219SW 
'MK 9/25/25 Don't write last record if it's equal to 0
'MK 2/16/25 Add Account Group By (Grouping seperated from sort) 
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R. Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Delinquent Statements, Etc.")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

<Assembly: Guid("EA6EBD5C-2AD4-4260-8A4D-7F6C1521B0EE")> 
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






