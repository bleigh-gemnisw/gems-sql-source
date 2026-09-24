'12/14/20 Change control acct to Revenue (was Expenditure)
' 1/ 7/21 Change GLTYP to use from GLACCT 
' 1/27/21 Move Delete to Form D and disable delete button on Form C, Add Recalc total to formatgrid
' 7/16/21 Write FIL10=9999999999 to control accounts
' 8/ 6/21 Always use GLACCT GLTYP (D bucket was hard coded X)
' 8/18/21 Cash Control should be fil10=0 (was 9999999999), Add to Revenue Control only if Revenue acct
' 8/19/21 Fix Print edits when enter key pressed (was any key)
' 9/13/23 Add Expenditure Control
'11/16/21 Add Edit: Single Quote not allowed in Description, Write log on LEDGER file error 
' 2/ 3/22 Change Description to 30 Chars
'11/23/22 Change data entry to 1 screen (was 2)
' 8/21/23 Fix Revenue/Expense control when there is a debit account
'10/11/23 Rework posting to use dataset from print edits instead of reading CSHBCH
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("AR101")> 
<Assembly: AssemblyDescription("")>
<Assembly: AssemblyCompany("Gemni Software")>
<Assembly: AssemblyProduct("Cash Receipts")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("6ddb1c0c-a566-47a2-a64c-c8151031eca8")> 

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
