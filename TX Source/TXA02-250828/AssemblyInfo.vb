' 2/ 1/21 Add CASHINT code to split payment (Principal/Interest/Fees/Liens)
' 7/ 8/21 Change Ledyard to use Webster Types (was normal)
' 7/ 9/21 Add format TaxServ...Normal but has letter types
' 7/12/21 Darien uses Normal Types (was webster), Fix Webster (typo Taxserv)
' 9/ 1/21 Add comment to screen so it can be changed
' 9/ 3/21 Enable comment, Change Taxserv to Bank Service (was lockbox)
' 9/14/21 Add Interest Date (use strdt in BCHHDR)
' 1/17/23 Make sure Ref is 10 chars max, Write Batch record at start and update status at end
' 5/11/23 Normal: Change list# from positions 2-7 to 1-7 
' 8/ 2/23 Webster: Adjust for 7 digit list#
' 8/10/23 Webster East Lyme: Adjust for 7 digit list#
' 1/ 8/24 Webster Coventry: Adjust for 7 digit list#
' 5/ 2/24 Webster Winchester: Adjust for 7 digit list#
'MK 6/12/25 East Lyme: Webster format list# is 6 digits (was 7)
'MK 7/ 2/25 East Lyme: Change type mapping to default (was Webster)
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
<Assembly: AssemblyProduct("Load Bank Receipts")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("6BAC1603-1EC0-4444-852E-0D4798D2C4BF")> 

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






