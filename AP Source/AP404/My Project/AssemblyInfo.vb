' 8/20/20 Fix Stuck Updating AP History screen: Remove progress screen for Updating PO
' 8/28/20 Write PO Number to Ledger
' 8/31/20 Write Fiscal Year to Ledger
' 9/ 9/20 Remove query from Update POMAST (not necessary)
' 4/13/21 Strip quotes from vendor name
' 5/12/21 Rewrite report and ledger posting routines to combine control account amounts
' 9/ 8/21 Show error for negative check(s)
'11/ 9/21 Set FIL10=9999999999 only For control accounts otherwise Set To 0
'11/16/21 Write log if LEDGER file error
'12/ 1/21 Update LEDGER Check Number to refno & chkn, Update GLPST to CD
'10/ 5/22 Limit PRF to 10 chars
'12/ 6/22 Cash account: Use APEBNK account if there else use GLFUND Cash Account
' 4/ 3/23 Change POSUMF Acct to Decimal (was double)
' 6/12/23 Change Ledger Update query to only change Expenditures (TRTYP=X)
'7/12/2024 cchange length of vendor name / truncate it to TDESC from 40 to 30 on post
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("AP404")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Post Checks")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("abf16a62-d654-4f8f-8a74-93098b5c1efc")> 

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
