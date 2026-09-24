' 8/24/20 Disable Print Edit enabled on new batch
' 9/ 3/20 Replace Truegrid
' 9/16/20 Update VendorL1 for Suspended (True)
' 9/22/20 Copy Over Expended code from PO201, Error if Header acct, check discount/ship acct
' 9/23/20 Error if Inactive acct
' 9/29/20 Change update/add Posumf to use summary by acct (was detail lines)
'12/16/20 Set Fiscal year for PrtEdits
'12/23/20 Fix Account Balance calc (encumbrances)
' 1/20/21 Fix Over Expended Edit
' 2/ 3/21 Fix Overexpended date range, remove print all reports code
' 2/ 5/21 Add Edit to Quantity & Unit Price for max value
' 2/25/21 Fix Edit to Quantity & Unit Price for max value
' 4/13/21 Strip out quotes from Vendor Name
' 7/ 9/21 Recovery mode will show already posted as informational (was error)
' 8/ 2/21 Add Error for PO Amount=0
' 8/11/21 Use GLTYP from GLACCT (Was X)
' 8/16/21 Move Quantity & Unit Price edits to Detail (was in header)
' 2/ 4/22 Add Discount And shipping acct required edits When % Or amount entered
' 6/23/22 ListVendor: Add Vendor address fields to datagrid
' 8/ 9/22 Change Entry date to be Batch Posting Date and make it a label field (was date field)
' 8/23/22 301E: Populate RACTD with current date, Populate RENTC
'10/ 5/22 Limit PRF to 10 chars
' 4/ 3/23 Change POSUMF Acct to Decimal (was double)
' 4/13/23 Change location to 4 chars, Add edit for location
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("PO301")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Maintain Purchase Orders")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("8a1ef1a9-7949-4af9-98bb-ec327123c3a7")> 

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
