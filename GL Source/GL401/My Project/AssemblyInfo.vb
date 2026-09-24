' 9/ 2/20 Change GLEBCHL1 Sort order by jrnseq, Fix Seqno order report, Keep descr/ref/proj  
' 9/23/20 Show report error if Transfers are out of balance
' 9/23/20 Add Edit for Header account, Edit for Transfer to be in balance
'10/ 7/20 Add Import File for P/R Journal Entries
'10/21/20 Add Edit Cannot mix Funds for Expenses, Error when transaction not balanced
'12/18/20 Disable GLEDSUM file (comment out)
' 1/ 7/21 Change GLTYP to use from GLACCT 
' 2/22/21 Change update Item to clear sequence on save
' 4/14/21 Add Error if Quote entered in Description. Write log if ledger write fails.
' 4/22/21 Change GLTYP to use from GLACCT (Missed 1)
' 6/ 7/21 Write to ORIG for Z Original Budgets
' 6/ 8/21 Fix Batch Number on Acct report
' 7/ 1/21 Omit budget entries from Revenue Control
' 7/16/21 Write Srcde = 2 to Control Account
' 7/19/21 Write Expenditure Control when applicable, add break to fund control by trnbr
' 7/26/21 Import: Add Derby same format for P/R & G/L, Add File Layout
' 7/17/21 Change File Layout to show Date, Move BCHHDR code to beginning instead of ending and at end update record count
' 8/ 2/21 Write BCHHDR Posting Date at end instead of beginning
' 8/ 6/21 Use GLACCT GLTYP for control account (was fundctltyp)
' 8/ 9/21 Fix Control accounts not totaling correctly
' 8/11/21 Import: Skip blank lines, strip out single quotes
' 8/19/21 Fix Print edits when enter key pressed (was any key)
' 9/ 2/21 Import: Check for valid date otherwise use today's date
' 9/23/21 Add Import Budget Entries, Add Edit Amount cannot be zero
' 9/27/21 Import: Skip blank lines
'10/13/21 Flip Debit/Credit
'11/23/21 Hide Entry Date on Detail screen
'12/23/21 Trim Source (FREEA) to correct compare
' 1/27/22 Change StreamReader to access as read
' 2/ 3/22 Change Description to 30 Chars
' 2/ 4/22 Increase Description size on report
' 5/11/22 Split and create option for P/R Paycor
' 6/ 3/22 Change grid Description to Acct Description
' 6/20/22 Activate code to check batch errors (was commented)
' 8/25/22 Add new Acct Detail report, combine acct and description on reports
'10/ 5/22 Limit PRF to 10 chars
' 3/15/23 Fix issue with Print Layout, only enabled on import screen.
' 6/20/23 Add "" to Description to make sure it won't be null
' 8/16/23 Winchester PR use ReadJournal and prglmap
'10/ 4/23 Winchester: Format date from file by adding slashes (date check failing)
'11/22/23 Change date check to look for a slash, remove Winchester hard code
'11/30/23 Oxford: Hard code PR Entries to run it as Journal Entries but srcde=5 (Winchester does this)
' 7/17/24 Change Report Zoom to 100
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("GL401")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Maintain Journal Entries")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("149eef15-ba31-4e77-8411-a31fe22e6709")> 

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
