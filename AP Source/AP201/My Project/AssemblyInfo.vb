' 8/24/20 Add overexpended message and report
' 8/28/20 Change PrtAP201 break from vsort to vndnr. Add error amount=0.
' 8/31/20 Write PO number to refno (Reg Accts/Non control)
' 9/ 9/20 Show Detail <> Header message when a PO doesn't match (was adding all detail & header)
'         Finish Code for Recovery mode 
' 9/16/20 Update VendorL1 for Suspended (False)
' 9/23/20 Edit for Header or Inactive Acct
' 9/29/20 Update posumf: if LEOPN="P" update by acct summary otherwise close PO
'         Add code for PO close ledger entries 
' 9/30/20 Fix Expenditure to read acct by summary (was detail)
'10/ 1/20 Report screen enter key check for overexpended is active
'10/14/20 Adjust PO detail records based on summary open amounts
'10/19/20 Change report3 from PO301C to AP201C
'10/21/20 Add PARTIAL to report when applicable
' 3/24/21 Add Edit for same invoice number used
' 4/ 7/21 Change Edit for duplicate invoice
' 5/10/21 Missing Control records in edit when ponbr=0
' 5/28/21 Change GLTYP to always use GLACCT, Add to Expenditure Control only if GLTYP="X"
' 7/15/21 Change Close PO to only close per account in POSUMF and keep open if PO Open Amount > 0
' 7/19/21 Post: Only Expense the amount paid even when closed
' 7/21/21 Post: Only write to Encumbrance & Reserve for Encumbrance Control for PO
' 8/18/21 Post: Change Encumbrance & Reserve for Encumbrance Control to check control amount
' 8/19/21 Fix Print edits when enter key pressed (was any key)
' 8/30/21 Add Edit for Description is required 
' 9/ 3/21 Post: Add code for Credit memo amtyp
'10/22/21 Check for POSUMF Liquated then add detail line
'10/25/21 Set POLIQ="N" for Liability PO's
'11/ 9/21 Set FIL10=9999999999 only for Equity control accounts otherwise set to 0
'11/16/21 Write log if LEDGER file error
'11/17/21 Add Revenue Control, Overexpended applies to only Expenditures
'11/19/21 Set F1099 checkbox from vendor file
' 2/ 3/22 Change Description to 30 Chars
' 5/18/22 Handle double clicking no rows on grids
' 6/15/22 Report: Fix Encumbrance amount when PO has multiple invoices or partials over open amount 
' 6/16/22 Handle PO credit memos
' 6/21/22 Show error if vendor is suspended
' 6/23/22 ListVendor: Add Vendor address fields to datagrid
' 8/ 1/22 ListVendor: Hide susp column
'10/ 5/22 Limit PRF to 10 chars
' 3/ 2/23 OpenBatch: Prevent error if there is no batch record
' 3/20/23 Check for Invalid Fund
' 4/ 3/23 Change POSUMF Acct to Decimal (was double)
' 5/31/23 Check for Invoice already paid
' 6/12/23 Derby: Skip Invoice already paid edit
' 8/21/23 Batches: Ignore double click if there are no batches
'10/16/23 Write Control: Chain to G/L Fund for each control record (was only A/P) 
'11/17/23 when searching vendor if 1099 vendor have it check the 1099 box true
' 4/11/24 Default Leave Encum Open to checked
' 7/17/24 Change report Zoom to 100, Change vendor to TDESC (20 to 30)
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("AP201")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Maintain A/P Batches")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("fa3ddaae-9593-4b0e-9b1f-6a518e627af4")> 

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
