' 9/ 8/20 Fix Location grid showing all batches, delete batch not deleting detail,
'         Fix Overexpended report, Fix delete item not deleting, Hide over expended tab when no records
' 9/16/20 Update VendorL1 for Suspended (False)
' 9/17/20 Change Account Balance code, Write Location to field Entpm in bchhdr, Add code to
'         prevent orphan batches, Zero out field Lsbch in batches (not used)
' 9/22/20 Error if Header acct, check discount/ship acct
' 9/23/20 Error if Inactive acct
'12/23/20 Fix Account Balance calc (encumbrances)
' 1/20/21 Fix Over Expended Edit
' 2/ 3/21 Save Button: Change Save Detail to a function for edit check errors,
'         remove print all reports code, Disable print edit on new batch
' 2/ 5/21 Add Edit to Quantity & Unit Price for max value
' 8/16/21 Move Quantity & Unit Price edits to Detail (was in header)
' 8/16/21 Replace TrueGrid
' 1/27/22 Change StreamReader to access as read
' 2/ 4/22 Add Discount and shipping acct required edits when % or amount entered
' 6/23/22 ListVendor: Add Vendor address fields to datagrid
' 8/ 9/22 Change Entry date to be Batch Posting Date and make it a label field (was date field), Show all batches for location
'11/ 7/22 Add Extended Value, default to error when over expended, add over expended balance, prevent orphan detail records
' 8/21/23 Ignore double click when grid is empty
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("PO201")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Maintain Requisitions")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("c1e21a60-4c23-4b46-8c7c-d82d586aa1c9")> 

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
