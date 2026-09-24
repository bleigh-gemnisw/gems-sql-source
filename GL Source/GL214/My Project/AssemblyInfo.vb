' 3/ 5/18 Change File to output all types (Was only R & X)  
'10/12/18 Make program to be same as as/400, keep non budget report
'11/29/18 Fix crash with creating file headers when no report selected 
'12/26/18 Allow budget credits, use field orig for Original Budget
' 6/11/19 Add Object subtotals
' 7/ 2/19 Fix duplicate records in export file
' 7/ 3/19 Add export option for state (Acct/Descr/Balance)
' 9/13/19 Add option normal report with no fund page breaks
'10/25/19 Add double quotes to csv file for description fields (handle extra comma)
'11/27/19 Fix budget revenue credits not adding correctly
' 9/28/20 Add keypress filter for acct from/to fields
'10/20/20 Add option for Source 6 
'11/12/20 Add Option for Show Previous YTD 
'12/14/20 Add option Show Subtotal by Object
' 1/ 7/21 Add function selection
' 4/ 7/21 Fix typo "A P P R O P R I A T I O N"
' 2/ 1/22 Add Lookups for Object and Function
' 8/15/22 Change Equity control accounts to date range (was day 0)
'11/ 8/22 Add option to select an account
' 2/15/23 GetBalance: Use Previous Dates if showing previous balance
' 7/17/24 Change Report Zoom to 100
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("GL214")> 
<Assembly: AssemblyDescription("Activity Summary")> 
<Assembly: AssemblyCompany("R Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("10926a04-e3fa-4fc0-939e-ad251b53da59")> 

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
