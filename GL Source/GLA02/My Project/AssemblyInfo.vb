'12/17/18 Add import file option
' 4/18/19 Fix issue with import file didn't create last batch records
'10/ 8/20 Add Batches Total 
'12/28/20 Fix Fund Security (Wrong column)
' 4/14/21 Add Error if Quote entered in Description
' 4/15/21 Write Log on LEDGER file error
' 6/15/21 Replace TrueGrid
' 8/19/21 Fix Print edits when enter key pressed (was any key)
'10/13/21 Flip Debit/Credit
' 1/27/22 Change StreamReader to access as read
' 2/ 3/22 Change Description to 30 Chars
' 2/28/22 Add AJ & RF codes
' 7/21/22 Add processing for RF code
' 8/12/22 Import: Check for header record and skip it
' 8/30/22 QDS doesn't have adjustment so it's 14 columns not 15
'10/ 5/22 Limit PRF to 10 chars
' 6/24/24 Winchester: Don't code refunds as RF...will go in general fund
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("GLA02")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("")> 
<Assembly: AssemblyProduct("Maintain Tax Receipts Journal Entries")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("1e5bb808-55e3-48a6-accc-80fca01dcb6a")> 

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

