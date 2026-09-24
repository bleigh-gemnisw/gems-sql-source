' 2/23/21 Add edit/amount for min amount allowed (reduction)
' 2/25/21 Change trntyp to X for control files (was E)
' 4/13/31 Strip out quotes from Vendor Name
' 8/ 9/22 Change PO Date if not in fiscal year date range
'10/ 5/22 Limit PRF to 10 chars
'10/13/22 Zero out header fields on add, Add edit for acct number 
' 4/ 3/23 Change POSUMF Acct to Decimal (was double)
' 5/ 8/23 Allow PO Posting date change (was today)
'12/ 5/23 Change UpdatePOAmt to only update 1 Seqno
'12/20/23 Change UpdatePOAmt to only update 1 Seqno and also Seqno 0
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("PO330")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Change Purchase Order")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("2a1c3d98-43a1-4be1-adb7-35420206ed31")> 

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
