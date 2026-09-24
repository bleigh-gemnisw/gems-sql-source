'10/30/18 Change Social Security numbers and Phone to masked text
' 2/ 4/18 Add LEEL Control File record and local form
' 6/ 4/19 Read Exclude Codes from TXCDAG (was hard coded)
' 2/10/20 Change Federal Adjusted Gross to Federal Gross Income, correct spelling: depreciation
' 2/20/20 Apply Property Percentage to East Lyme local benefit
' 2/24/20 On new record, hide local options based on town (update is OK)
' 9/ 2/21 Error if approved and 0 credit. Error if disallowed reason and approved.
' 1/18/22 Change Local forms to print from xsd (no parms)
' 1/20/22 Save/Delete is only allowed for current G/L, On New autofill in Year from Control file
' 1/24/22 Update TXLOCAL and TXREAL/C Town Benefit (Coventry)
' 2/15/22 Update TXLOCAL and TXREAL/C Town Benefit (East Lyme)
' 4/18/22 East Lyme: Always enable Print State & local forms
' 2/ 8/23 Add up all local credits
' 2/21/23 GetTXREAL: Truncate First and Last name
' 4/20/23 Add LEDAR Control record for Darien Local
' 4/28/23 Darien: Print Local Form, Local if single only show single data and same for married
' 5/ 1/23 Add CalcLocalSplit 
' 5/ 5/23 Add Print Screen
' 5/11/23 Darien Local not deleting TXLOCAL when calclocalsplit=0
' 5/22/23 Darien Local Form, Add Deferral amount to screen
'MK 5/27/25 Darien local benefit cannot be more than the tax limit  
'MK 2/ 9/26 Winchester doesn't have  a local program
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("TO201")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("R. Walsh Associates, Inc.")> 
<Assembly: AssemblyProduct("Maintain OPM M35H")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("4de8a81d-d03d-4ed9-9320-16de66fbeee0")> 

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
