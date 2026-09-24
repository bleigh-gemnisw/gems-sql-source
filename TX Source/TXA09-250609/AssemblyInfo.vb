' 3/15/18 Add Duplicate bill format based on type
' 3/27/18 Prorate duplicate bill due date now uses prorate date (was profile date)
' 4/19/18 Change search by name to use Qryselect (SQL Performance)
' 4/24/18 Change GetbyListno record counting method (C1==>ds)
' 4/26/18 Change query by name to handle single quotes for SQL Server
' 5/07/18 Change search by name to use Qryselect for SQL only, move code before type query
' 7/19/18 Create logical TXINVLH to fix slow performance with balance due by name
' 8/ 3/18 Flip State & Local benefits amounts for duplicate bils
' 8/ 8/18 Add Vehicle tab to DMV screen
' 9/19/18 Write Recid to history
' 9/25/18 Add Chdate key to TXVEHL2
'10/25/18 Change Previous mode to not read twice (was skipping records)
'12/ 6/18 List# entry must be at least 6 chars for fastpath (prevent crash)
' 1/28/19 Update Combined bill to include Usage amount (paid, interest, etc.)
' 2/13/19 Change Combined Bill to look at Tax Type (was Tax family)
' 5/29/19 Show Fee Paid
' 7/ 9/19 MV types: Remove back tax flag by CustID (Was regno) for oldest year
' 7/23/19 MV Types: If prorated, use TXCOEA net assessment field
' 8/13/19 Fix List No view Amt Paid (was negative) and unposted flag (was blank)
' 8/20/19 Change Adjustments receipt to check if advanced driver active
' 8/20/19 Add 4 optional recieved amounts to fill in amount received
' 8/26/19 Fix issue with Adjustment validate (cash/check/credit is null)
' 8/28/19 Add second name to adjust screen and buildds for print direct receipt
'10/10/19 Reorder print all to print reports in tab order
'11/25/19 Show "&" in mailing address
' 1/23/20 Public mode: Remove VIN from search dropdown, Remove VIN from dup bill 
' 3/ 3/21 Add Property Location to description line 1, move down property codes,
'         Show credit amounts on screen TXA094B (Was 0)
' 3/29/21 Add option for PDF Bill
' 8/19/21 Fix Print edits when enter key pressed (was any key)
' 8/25/21 Each Counter Credit payment now uses prodid for that tax type
'10/26/21 Change to MyInterestDate and MyReceiptdate in batch reports (was detail date)
' 2/28/22 Redesign Total Items, Allow more than one screen with continue then Process/Print the items
' 3/ 3/22 Reduce fee if not paid in full
' 3/ 9/22 Fix issues with Next & Back buttons by checking that MyFrmTXA094B is in memory
' 3/16/22 Include credits on Notices, Statements, etc.
' 3/29/22 Rename some screens, Handle complete when amount is 0 (crashed Total screen)
' 6/ 7/22 Change grid results to 100 records
'11/ 1/22 Add GetOneRecordP to comments save
'11/15/22 Fix Issue with Next if all records are same (name,sname,location)
'11/22/22 Strip out single quote from all searches
'12/ 6/22 Prevent Close Batch no record found 
' 1/19/23 Trim fields in FrmTXA09DMV, lock datagrid columns in TXA094 
' 1/25/23 Fix error in UpdateTXINV_MV
' 1/26/23 Fix error with TXHSTL3.SetRange list/year was backwards
' 2/17/23 Make List# wider in grid
' 3/ 2/23 Handle 7 digit list# fast path on keypress
' 3/15/23 DMV: Show all vehicles for custid (was skipping zero bald and not flagged)
' 3/16/23 Format Receipt date to same everywhere
' 5/24/23 Add Attachments
' 6/ 1/23 Inquiry can use attachments, public user cannot see attachments
' 6/ 6/23 Inquiry comments: Assessor option cannot save
' 7/ 6/23 Inquiry Assessor can not use attachments
' 8/ 4/23 Add Due & Balance radio buttons on payment screen...enable only if different amounts
'         Add Balance Dropdown, Change Select Year to Years, Change Amount Recieved to a autofill link
' 8/ 7/23 Add Check number on Receipt
' 8/10/23 Fast Path: Pressing enter will not process if less than 6 chars (invalid)
' 8/22/23 Fix Bond Adjustment not adding back bond interest, Add Leasing to Batch Types
' 9/26/23 Stop Attachment screen return from setting screen ID
'10/25/23 Add VehID to DMV screen grid, show VehID for account, Remove No PutOns message 
'12/18/23 Move Check Number below Credit 
'12/21/23 Add scan searches
' 1/ 3/24 DupBill: If SNAME has N/O then use SNAME instead of NAME and remove the N/O
' 2/12/24 Change Fastpath to run only when list/type/year are all filled in otherwise show a list of matching accounts
' 4/26/24 Change Amount Due to Prin Due
' 6/ 4/24 Change Lien clear to also check that BALD<=0
' 6/10/24 Replace N/O should include a space as well
' 7/22/24 Add Control record BALTL (Show Total Balance Due)
' 7/25/24 Add Deferred logic
' 8/ 8/24 DupBill: If SNAME has N/O at end then use SNAME instead of NAME and remove the N/O
' 8/19/24 change the sort order for Check no on reprotx Y an Z  to be by numeric check no.  this is done usign a formula
'         field in CR and usign CR report sort feature on the formula field.
' 8/27/24 Change all internal batch edits to external reports (Q/S/T/V/Void/W/X/Y/Z/ZB)
' 8/20/24 Add Control Record FPBAL to change Fast Path to look at balance dropdown (IE: Balance Due)
'10/17/24 Check unposted lien and subtract lien due amount (TXA09B)
'10/22/24 Check unposted fees and subtract fee due amount (TXA09B)
'12/10/24 Control record BALTL to always use CASHINT (was only bald>0)
'12/18/24 Change Control record BALTL use CASHINT when bald>=0
'12/30/24 Control record INVDL to show Invoice Detail button
'12/31/24 Add Invoice Detail screen
' 1/22/25 Handle ShowNext end of file error
' 3/26/25 Change verbiage for Deferral (screen)
' 4/ 2/25 Add Open Batch endorse checkbox 
'MK 5/5/25 Add Both Names & Both CustID scans (Search)
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
<Assembly: AssemblyProduct("Cash Register")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("F35172D9-256E-47BB-B47D-62E36A93D83C")> 

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
