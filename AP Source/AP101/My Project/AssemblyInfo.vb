' 1/10/19 Fix edit on vendor number
' 9/15/20 Add Find Fiscal Year, PO Number to PO Inquiry, Change Position to Vendor Sort,
'         Fix Next button (Wrong field), Change grid to 250 rows
' 9/16/20 Update VendorL1 for Suspended (True), Save Suspended flag and show message,
'         Show Voids with pink background 
' 9/21/20 Change Fiscal/YTD to read apehstl1 instead of vendor file
'12/18/20 Add missing fields for save (vsort, contact, zip, address1)
' 7/14/21 Add Ponbr to apehst (L2, L3 & LB), Replace TrueGrid
' 8/17/21 Add single quote edit for vsort and vendor name
' 9/ 7/21 Show Negative Amounts, Show actual check amount (was invoice paid amount)
'12/ 1/21 Show Void Check column and make row red
' 1/19/22 Change Minority Run to Other Income
' 5/18/22 Fix ds initalization
' 6/10/22 Check security for app groupd FI
' 6/23/22 Add Vendor address fields to datagrid
' 7/28/22 Can now update F1099
' 8/ 1/22 Add All/Omit Suspense option, Add Susp Column and change background to pink, Change Check & Invoice date searches
'         to show in descending order
' 9/ 7/23 Show Account Number on PO Detail screen
'11/17/23 Add attachment piece
'11/17/23 Add a Scan and Comments
'12/27/23 Don't change search sort when coming back from Screen C
'1/15/24  change find field to stay o nscreen and not change when hit next
' 7/11/24 increase size of name and address fields to 40   add email field
' 7/17/24 change ap history screen to properly sort dates and check# 
' 7/18/24 disable delete button
' 7/22/24 Change when there is no chkpd from "" to 0

Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("AP101")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Maintain/Inquiry Vendors")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("a52da5d7-0748-4d74-94b6-340d09f6512d")> 

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
