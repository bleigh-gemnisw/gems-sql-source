' 9/23/20 Edit for Inactive or Header acct
'12/18/20 Comment out GLEDSUM file
'12/29/20 Fix New button, file issues with glrbch
' 4/14/21 Add Error if Quote entered in Description
' 4/15/21 Write log on LEDGER file error
' 4/22/21 Change GLTYP to use GLACCT
' 6/ 7/21 Write to ORIG for Z Original Budgets
' 7/23/21 Update PrintEdits and PostBatch with GL401 changes, Set Batch to Suspended after post
' 7/27/21 Add Change Batch Date, use Batch date instead of activity & entry dates
' 8/19/21 Fix Print edits when enter key pressed (was any key)
'10/13/21 Flip Debit/Credit
' 2/ 3/22 Change Description to 30 Chars
' 6/ 9/22 Keep Description
' 6/22/22 Post: Change control to use GLTYP from GLACCT (was FundCtl)
'10/ 5/22 LImit PRF to 10 chars
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("GL403")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Maintain Reoccuring J/E")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("7bef41a1-1880-4d39-885e-0dd8dcc68b2c")>

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
